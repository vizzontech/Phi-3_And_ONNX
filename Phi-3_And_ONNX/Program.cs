#pragma warning disable SKEXP0070
#pragma warning disable SKEXP0050
#pragma warning disable SKEXP0001
#pragma warning disable SKEXP0010


using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;
var phi3modelPath = @"D:\data\Phi3Models\Phi-3-mini-4k-instruct-onnx\cpu_and_mobile\cpu-int4-rtn-block-32";

var builder = Kernel.CreateBuilder();
builder.AddOnnxRuntimeGenAIChatCompletion("phi-3", phi3modelPath);
var kernel = builder.Build();


// create chat
var chat = kernel.GetRequiredService<IChatCompletionService>();
var history = new ChatHistory();

// run chat
while (true)
{
    Console.Write("Q: ");
    var userQ = Console.ReadLine();
    if (string.IsNullOrEmpty(userQ))
    {
        break;
    }
    history.AddUserMessage(userQ);

    Console.Write($"Phi3: ");
    var response = "";
    var result = chat.GetStreamingChatMessageContentsAsync(history);
    await foreach (var message in result)
    {
        Console.Write(message.Content);
        response += message.Content;
    }
    history.AddAssistantMessage(response);
    Console.WriteLine("");
}

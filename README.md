# Phi-3_And_ONNX


Get and Install Phi-3 models locally. 

	1. Open the terminal and do the following : 

	   cd D:\Data\Phi3Models

	2. git lfs install (https://git-lfs.com/)

	3. git clone https://huggingface.co/microsoft/Phi-3-mini-4k-instruct-onnx
 

Add dependencies (Tools => NuGet Package Manager => Package Manager Console => run following.)

```
Install-Package Microsoft.SemanticKernel.Connectors.Onnx -v 1.16.2-alpha
```

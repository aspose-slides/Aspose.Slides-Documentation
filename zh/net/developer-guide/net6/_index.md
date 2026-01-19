---
title: .NET 6 支持
type: docs
weight: 235
url: /zh/net/net6/
keywords: 
- .NET 6 支持
- 云解决方案
- AWS Lambda
- Azure 函数
- System.Drawing.Common
- GDI
- libgdiplus
- CS0433
- .NET
- C#
- Aspose.Slides
description: "配置 Aspose.Slides for .NET 6，以在现代跨平台 C# 应用程序中创建、编辑和转换 PowerPoint PPT、PPTX 和 ODP 演示文稿。"
---

## **简介**

从 [Aspose.Slides 23.2](https://www.nuget.org/packages/Aspose.Slides.NET/23.2.0) 开始，实现了对 .NET6 的支持。此支持的特殊之处在于 .NET6 不再在 Linux 上支持 System.Drawing.Common（[breaking change](https://learn.microsoft.com/en-us/dotnet/core/compatibility/core-libraries/6.0/system-drawing-common-windows-only)），Slides 将此图形子系统自行实现为 C++ 组件。

Aspose.Slides for .NET 现在在以下平台上无需依赖 GDI/libgdiplus：
* Windows
* Linux

_MacOS_ 支持正在进行中。

## **在 AWS 和 Azure 上使用 .NET 6 版 Slides**

.NET6 是在云端（AWS、Azure 或其他云解决方案）使用 Aspose.Slides 的首选版本。

以前，在 Linux 主机上使用 Aspose.Slides 时，需要安装额外的依赖项（libgdiplus），这常常不方便或不可行（例如，在使用 [AWS Lambda](https://aws.amazon.com/lambda) 时）。使用 .NET6 版 Slides 后，不再需要这些依赖项，部署更加简便。

另一个需要考虑的问题是，在 Windows 主机的云解决方案中使用 Aspose.Slides 时会出现的问题。例如，[Azure Functions](https://learn.microsoft.com/en-us/azure/azure-functions/functions-overview) 对进程有限制，导致在 PDF 导出操作期间出现问题（参见 [this](https://github.com/projectkudu/kudu/wiki/Azure-Web-App-sandbox#unsupported-frameworks)）。使用 Aspose.Slides for .NET6 可以解决此问题。

## **使用 System.Drawing.Common 包和 .NET 6 版 Slides 类 (CS0433: The Type Exists in Both Slides and System.Drawing.Common Error)**

有时，项目中必须同时使用 System.Drawing 和 Slides for .NET6 的依赖项（例如，当 .NET6 项目依赖其他包，而这些包又依赖 System.Drawing 时）。这可能会导致以下冲突错误：

* CS0433: The type 'Image' exists in both 'Aspose.Slides, Version=23.2.0.0, Culture=neutral, PublicKeyToken=716fcc553a201e56' and 'System.Drawing.Common, Version=6.0.0.0
* CS0433: The type 'Graphics' exists in both 'Aspose.Slides, Version=23.2.0.0, Culture=neutral, PublicKeyToken=716fcc553a201e56' and 'System.Drawing.Common, Version=6.0.0.0

在这种情况下，可以对 Aspose.Slides（版本低于 24.8）使用 [extern alias](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/extern-alias)：

1) 从项目的依赖项中选择 Aspose.Slides 程序集，然后单击 **Properties**。  
   ![Aspose Slides 包属性](package_properties.png)

2) 设置别名（例如，“Slides”）。  
   ![Aspose Slides 别名](set_alias.png)

现在，默认使用 System.Drawing.Common 中的类型。需要使用 Aspose.Slides 类型的地方应指定外部程序集别名。  
```c#
extern alias Slides;
using Slides::Aspense.Slides;
```


完整示例：  
```c#
extern alias Slides;
using Slides::Aspose.Slides;

static Slides::System.Drawing.Image GetThumbnail(Presentation pres)
{
    return pres.Slides[0].GetThumbnail();
}
```


从 24.8 版本开始，已删除依赖于 System.Drawing 的已弃用公共 API。针对上述代码示例，您可以如下获取幻灯片图像。  
```cs
static Aspose.Slides.IImage GetThumbnail(Presentation presentation)
{
    return presentation.Slides[0].GetImage();
}
```


新 API 在 [现代 API](/slides/zh/net/modern-api/) 中有更详细的描述。
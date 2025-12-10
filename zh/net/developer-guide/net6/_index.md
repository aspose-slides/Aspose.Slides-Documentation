---
title: .NET 6 支持
type: docs
weight: 235
url: /zh/net/net6/
keywords:
- .NET 6 支持
- 云解决方案
- AWS Lambda
- Azure Functions
- System.Drawing.Common
- GDI
- libgdiplus
- CS0433
- .NET
- C#
- Aspose.Slides
description: "在现代跨平台 C# 应用程序中，配置 Aspose.Slides for .NET 6 以创建、编辑和转换 PowerPoint PPT、PPTX 和 ODP 演示文稿。"
---

## **介绍**

Starting in [Aspose.Slides 23.2](https://www.nuget.org/packages/Aspose.Slides.NET/23.2.0)，实现了对.NET6的支持。此支持的特殊之处在于 .NET6 不再支持 Linux 上的 System.Drawing.Common（[重大更改](https://learn.microsoft.com/en-us/dotnet/core/compatibility/core-libraries/6.0/system-drawing-common-windows-only)），Slides 将此图形子系统自行实现为 C++ 组件。

Aspose.Slides for .NET 现在可以在以下平台上无需依赖 GDI/libgdiplus 工作：
* Windows
* Linux

_MacOS_ 支持正在进行中。

## **在 AWS 和 Azure 上使用 .NET 6 的 Slides**

.NET6 是在云端（AWS、Azure 或其他云解决方案）使用 Aspose.Slides 的首选版本。

以前，在 Linux 主机上使用 Aspose.Slides 时，需要安装额外的依赖 (libgdiplus)，这通常不方便或不切实际（例如，使用 [AWS Lambda](https://aws.amazon.com/lambda) 时）。使用 .NET6 版 Slides 后，不再需要这些依赖，部署因此更加简便。

另一个需要考虑的问题是，在使用 Windows 主机的云解决方案时，Aspose.Slides 会出现问题。例如，[Azure Functions](https://learn.microsoft.com/en-us/azure/azure-functions/functions-overview) 对进程有限制，导致 PDF 导出操作时出现问题（参见[此处](https://github.com/projectkudu/kudu/wiki/Azure-Web-App-sandbox#unsupported-frameworks)）。使用 .NET6 版 Aspose.Slides 可以解决此问题。

## **使用 System.Drawing.Common 包和 .NET 6 的 Slides 类 (CS0433: 类型在 Slides 和 System.Drawing.Common 中均存在错误)**

有时，项目中必须同时使用 System.Drawing 和 .NET6 版 Slides 的依赖（例如，.NET6 项目依赖其他包，而这些包又依赖 System.Drawing）。这可能导致如下冲突错误：

* CS0433: The type 'Image' exists in both 'Aspose.Slides, Version=23.2.0.0, Culture=neutral, PublicKeyToken=716fcc553a201e56' and 'System.Drawing.Common, Version=6.0.0.0
* CS0433: The type 'Graphics' exists in both 'Aspose.Slides, Version=23.2.0.0, Culture=neutral, PublicKeyToken=716fcc553a201e56' and 'System.Drawing.Common, Version=6.0.0.0

In this case, you can use [extern alias](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/extern-alias) for Aspose.Slides (version less than 24.8):
1) 从项目的依赖项中选择 Aspose.Slides 程序集，然后单击 **Properties**。
  ![Aspose Slides package properties](package_properties.png)
2) 设置别名（例如，“Slides”）。
  ![Aspose Slides alias](set_alias.png)

此时，默认使用 System.Drawing.Common 中的类型。需要使用 Aspose.Slides 类型的地方应指定外部程序集别名。
```c#
extern alias Slides;
using Slides::Aspose.Slides;
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


Starting with version 24.8, the deprecated public API with dependencies on System.Drawing has been removed. Regarding the code example above, you can get the slide image as below.
```cs
static Aspose.Slides.IImage GetThumbnail(Presentation presentation)
{
    return presentation.Slides[0].GetImage();
}
```

The new API is described in more detail in [现代 API](/net/modern-api/).
---
title: .NET6 支持
type: docs
weight: 235
url: /zh/net/net6/
keywords: 
- .NET 6
- 云
- AWS
- Azure
description: ".NET6 支持"
---

## 介绍

从 [Aspose.Slides 23.2](https://www.nuget.org/packages/Aspose.Slides.NET/23.2.0) 开始，实现了对.NET6的支持。这项支持的特点在于 .NET6 不再支持 Linux 的 System.Drawing.Common ([重大更改](https://learn.microsoft.com/en-us/dotnet/core/compatibility/core-libraries/6.0/system-drawing-common-windows-only))，而 Slides 则将该图形子系统作为 C++ 组件自行实现。

Aspose.Slides for .NET 现在在以下平台上无需依赖 GDI/libgdiplus：
* Windows
* Linux

_MacOS_ 支持正在进行中。

## 在 AWS 和 Azure 上使用 .NET6 的 Slides

.NET6 是在云中（AWS、Azure 或其他云解决方案）使用 Aspose.Slides 的首选版本。

之前，当在 Linux 主机上使用 Aspose.Slides 时，必须安装额外的依赖项（libgdiplus），这往往不方便或不切实际（例如，在使用 [AWS Lambda](https://aws.amazon.com/lambda) 时）。使用 .NET6 的 Slides 时，不再需要这些依赖项，因此部署变得更加容易。

另一个需要考虑的问题是，当在 Windows 主机的云解决方案中使用 Aspose.Slides 时出现的问题。例如， [Azure Functions](https://learn.microsoft.com/en-us/azure/azure-functions/functions-overview) 对进程存在限制，这在 PDF 导出操作中会导致问题（请参见 [此处](https://github.com/projectkudu/kudu/wiki/Azure-Web-App-sandbox#unsupported-frameworks)）。使用 Aspose.Slides for .NET6 可以解决这个问题。

## 使用 System.Drawing.Common 包和 .NET6 的 Slides 类 (CS0433: 类型在 Slides 和 System.Drawing.Common 中都存在的错误)

有时，项目中必须使用 System.Drawing 和 .NET6 的 Slides 两个依赖项（例如，当 .NET6 项目依赖于其他包，而这些包又依赖于 System.Drawing）。这可能会导致像这样的复杂错误：

* CS0433: 类型 'Image' 同时存在于 'Aspose.Slides, Version=23.2.0.0, Culture=neutral, PublicKeyToken=716fcc553a201e56' 和 'System.Drawing.Common, Version=6.0.0.0'
* CS0433: 类型 'Graphics' 同时存在于 'Aspose.Slides, Version=23.2.0.0, Culture=neutral, PublicKeyToken=716fcc553a201e56' 和 'System.Drawing.Common, Version=6.0.0.0'

在这种情况下，您可以为 Aspose.Slides（版本小于 24.8）使用 [extern alias](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/extern-alias)：
1) 从项目的依赖项中选择 Aspose.Slides 程序集，然后点击 **属性**。
  ![Aspose Slides package properties](package_properties.png)
2) 设置一个别名（例如，"Slides"）。
  ![Aspose Slides alias](set_alias.png)

现在，System.Drawing.Common 的类型将被默认使用。当需要使用 Aspose.Slides 的类型时，应指定外部程序集别名。

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

从 24.8 版本开始，已移除对 System.Drawing 的过时公共 API。关于上面的代码示例，您可以如下获取幻灯片图像。

```cs
static Aspose.Slides.IImage GetThumbnail(Presentation presentation)
{
    return presentation.Slides[0].GetImage();
}
```
新 API 的详细描述可见 [现代 API](/net/modern-api/)。
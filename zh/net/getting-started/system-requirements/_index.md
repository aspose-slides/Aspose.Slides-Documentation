---
title: 系统要求
type: docs
weight: 60
url: /zh/net/system-requirements/
keywords:
- 系统要求
- 支持的平台
- 目标框架
- .NET Framework
- .NET Standard
- libgdiplus
- fontconfig
- Alpine
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "在安装 Aspose.Slides for .NET 之前检查其需求：每个 NuGet 包所针对的框架、受支持的操作系统和处理器，以及 Linux 所需的库和字体。"
---
## **介绍**

Aspose.Slides for .NET 是一个独立的库：它不需要 Microsoft PowerPoint 或 Microsoft Office。它以两个 NuGet 包的形式发布，[Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/) 和 [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/)。两者提供相同的 Aspose.Slides 命名空间和类；它们在目标框架以及绘制幻灯片的方式上有所不同，这决定了它们的运行位置和所需环境。

本文列出了每个包支持的 .NET 版本和平台，以及 Linux 所需的系统库和字体，并以一个检查您环境的简短程序结束。要将包添加到项目，请参阅[安装](/slides/zh/net/installation/)。

## **受支持的 .NET 版本**

每个包针对每个目标框架包含一个 Aspose.Slides 的构建，NuGet 会选择与您项目目标框架匹配的构建。

| 包 | 包中包含的目标框架 | 您的项目可以针对 |
|---|---|---|
| Aspose.Slides.NET | `net462`, `net6.0`, `netstandard2.0` | .NET Framework 4.6.2 或更高版本；.NET 6 或更高版本，包括 .NET 8、.NET 9 和 .NET 10 |
| Aspose.Slides.NET6.CrossPlatform | `net6.0` | .NET 6 或更高版本，包括 .NET 8、.NET 9 和 .NET 10 |

`netstandard2.0` 构建允许 .NET Standard 2.0 类库引用 Aspose.Slides.NET。使用此类库的应用程序会运行与其自身目标框架匹配的构建，例如 .NET 8 应用程序会运行 `net6.0` 构建。

## **受支持的操作系统和处理器**

Aspose.Slides.NET 只包含与处理器无关的（AnyCPU）托管代码，因此它在加载它的 .NET 运行时的处理器架构上运行。它通过 Microsoft 的 System.Drawing.Common 库绘制幻灯片，而该库[仅在 Windows 上]https://learn.microsoft.com/en-us/dotnet/core/compatibility/core-libraries/6.0/system-drawing-common-windows-only。 在 Linux 上，Aspose.Slides.NET 因此需要 `libgdiplus` 库和启动开关，详见[Linux](#linux)。它可在提供 `libgdiplus` 的 Linux 发行版上运行，例如 Debian、Ubuntu 和 Alpine Linux。

Aspose.Slides.NET6.CrossPlatform 使用自己的图形引擎绘制幻灯片。该引擎是本机库，包中每个平台各提供一个构建，因此包仅在以下平台上运行：

| 操作系统 | 处理器 | 备注 |
|---|---|---|
| Windows | x86, x64 | 不支持在 ARM64 上的 Windows。 |
| Linux | x64, ARM64 | 在 x64 上需要 glibc 2.23 或更高版本，在 ARM64 上需要 glibc 2.39 或更高版本。 |
| macOS | x64 (Intel), ARM64 (Apple silicon) |  |

Aspose.Slides.NET6.CrossPlatform 不在基于 musl 而非 glibc 的 Alpine Linux 或其他发行版上运行，也不在使用较旧 glibc 的发行版（如 CentOS 7）上运行。这些系统请使用 Aspose.Slides.NET。

在 Windows 上，Aspose.Slides.NET6.CrossPlatform 的本机库使用 Microsoft Visual C++ 运行时（*MSVCP140.dll* 和 *VCRUNTIME140.dll*，以及 x64 上的 *VCRUNTIME140_1.dll*）。如果目标机器缺少这些文件，请安装[Microsoft Visual C++ 可再发行组件](https://learn.microsoft.com/en-us/cpp/windows/latest-supported-vc-redist?view=msvc-170)。

## **Linux**

这两个包在 Linux 上都需要额外的系统库。若缺少这些库，[创建演示文稿](/slides/zh/net/create-presentation/)中的首个示例将抛出异常而不是保存文件。以下命令适用于 Debian 和 Ubuntu；在这些发行版上，每个库还会带入 DejaVu 字体（`fonts-dejavu-core`），因此文本可以在无需额外字体包的情况下渲染。

### **Aspose.Slides.NET6.CrossPlatform**

该包的 Linux 库需要 `fontconfig` 库：

```bash
sudo apt-get update && sudo apt-get install -y libfontconfig1
```

如果缺少它，创建[演示文稿](https://reference.aspose.com/slides/net/aspose.slides/presentation/)将会失败，并抛出 `TypeInitializationException`，其内部的 `DllNotFoundException` 报告无法打开 `libfontconfig.so.1`。

最小化的基础镜像可能也不包含 `fontconfig`。例如 .NET 8 的 AWS Lambda 基础镜像既不包含 `fontconfig` 也不包含任何字体。在基于该镜像构建的容器中，运行 `dnf install -y fontconfig`，它还会安装 Noto Sans 字体。

### **Aspose.Slides.NET**

该包在 Linux 上需要两项内容：

1. `libgdiplus` 库：

   ```bash
   sudo apt-get update && sudo apt-get install -y libgdiplus
```

2. `System.Drawing.EnableUnixSupport` 开关，需要在应用程序开始时（在任何 Aspose.Slides 调用之前）启用。在使用顶部语句的 *Program.cs* 中，将其放在 `using` 指令之后：

   ```c#
   System.AppContext.SetSwitch("System.Drawing.EnableUnixSupport", true);
   ```

如果缺少 `libgdiplus`，保存演示文稿时会抛出 `TypeInitializationException`，其内部的 `DllNotFoundException` 报告无法加载 `libgdiplus`。如果未启用该开关，内部异常为 `PlatformNotSupportedException: System.Drawing.Common is not supported on non-Windows platforms`。

{{% alert color="warning" title="Warning" %}}
该开关仅适用于 Aspose.Slides.NET 所依赖的 System.Drawing.Common 6 版本。Microsoft 在 System.Drawing.Common 7 中已移除该开关。如果您的项目直接或间接引用了 System.Drawing.Common 7 或更高版本，即使已安装 `libgdiplus` 并启用了开关，Aspose.Slides.NET 在 Linux 上仍会因 `PlatformNotSupportedException` 而失败。在这种情况下，请使用 Aspose.Slides.NET6.CrossPlatform。
{{% /alert %}}

### **Alpine Linux**

在 Alpine Linux 上，请使用带有上述开关的 Aspose.Slides.NET。Alpine 镜像通常不包含任何字体，单独的 `libgdiplus` 也不会安装字体，因此请将 `libgdiplus` 与至少一个字体包一起安装。若没有字体，保存演示文稿时会出现以下错误：

```text
System.ArgumentException: Font '?' cannot be found.
```

**选项 1：DejaVu 字体**

推荐的选项是 `ttf-dejavu` 包：

```dockerfile
RUN apk add --no-cache \
    libgdiplus \
    ttf-dejavu
```

在当前的 Alpine 发行版中，`ttf-dejavu` 会安装 `font-dejavu` 包，该包还会安装 `fontconfig` 以及其依赖的字体工具。

**选项 2：Microsoft 核心字体**

如果您的演示文稿使用 Microsoft 字体，例如 Arial、Times New Roman、Courier New 或 Verdana，请改为安装 Microsoft 核心字体。`update-ms-fonts` 步骤会在构建镜像时下载这些字体，因此构建过程需要网络访问：

```dockerfile
RUN apk add --no-cache \
    libgdiplus \
    fontconfig \
    msttcorefonts-installer \
    && update-ms-fonts \
    && fc-cache -fv
```

### **Globalization Support**

这两个包都需要 .NET 的全球化支持，Linux 上的 .NET 通过 ICU 库提供此支持。在[globalization-invariant mode](https://learn.microsoft.com/en-us/dotnet/core/runtime-config/globalization)下，创建[演示文稿](https://reference.aspose.com/slides/net/aspose.slides/presentation/)会失败，并抛出 `CultureNotFoundException: Only the invariant culture is supported in globalization-invariant mode`。

某些容器镜像会开启此模式。例如，Alpine Linux 的 .NET 运行时镜像（`runtime-deps`、`runtime` 和 `aspnet`）会设置 `DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=true` 并且不包含 ICU。在基于这些镜像构建的镜像中，安装 ICU 并关闭该模式：

```dockerfile
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
RUN apk --no-cache add icu-libs
```

同时确保您的项目文件未将 `InvariantGlobalization` 属性设置为 `true`。

## **Check Your Setup**

要检查包及其依赖是否已就绪，请运行一个保存演示文稿并将幻灯片渲染为图像的程序。保存和渲染使用图形库和字体，这正是上述 Linux 要求提供的。

创建一个控制台应用程序，并按照[安装](/slides/zh/net/installation/)中的说明添加相应的包；用下面的代码替换 *Program.cs* 的内容，然后运行 `dotnet run`。如果在 Linux 上使用 Aspose.Slides.NET，请在 `using` 指令之后添加[Linux](#linux)中所示的 `System.Drawing.EnableUnixSupport` 开关语句。该程序使用顶层语句和 `using` 声明，需要 C# 9 或更高版本。针对 .NET 6 或更高版本的项目默认使用更高的 C# 版本；若项目针对 .NET Framework，请在项目文件的 `PropertyGroup` 中添加 `<LangVersion>latest</LangVersion>`。

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
shape.TextFrame.Text = "Hello, Aspose.Slides!";
presentation.Save("hello.pptx", SaveFormat.Pptx);

using var image = slide.GetImage(1f, 1f);
image.Save("hello.png", ImageFormat.Png);
```

该程序向第一张幻灯片添加一个带文本的矩形，并使用[保存](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/)方法将演示文稿保存为 *hello.pptx*。随后使用[GetImage](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage/)渲染幻灯片，并使用[IImage.Save](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/) 将结果保存为 *hello.png*，格式为 [ImageFormat.Png](https://reference.aspose.com/slides/net/aspose.slides/imageformat/)。比例因子为 1 时，每个点渲染为一个像素，因此默认的 720 × 540 点幻灯片会变为 720 × 540 像素的图像，文本在矩形内可见。若未获取许可证，两个文件都会带有评估水印；请参阅[授权](/slides/zh/net/licensing/)。如果缺少某项要求，程序会在[Linux](#linux)中描述的异常之一处停止。

## **开发工具**

您可以使用任何支持项目目标框架的工具来构建使用 Aspose.Slides 的应用程序：在 Windows、Linux 和 macOS 上使用 .NET SDK 及其 `dotnet` 命令行界面，或在 Windows 上使用 Visual Studio。[安装](/slides/zh/net/installation/)对两者都作了说明。

## **常见问题**

**是否需要安装 Microsoft PowerPoint 才能进行转换和渲染？**

不需要，PowerPoint 并不是必需的。Aspose.Slides 是一个独立的引擎，可用于[创建](/slides/zh/net/create-presentation/)、修改、[转换](/slides/zh/net/convert-presentation/)以及[渲染](/slides/zh/net/convert-powerpoint-to-png/)演示文稿。

**应该使用哪个包？**

在 Windows 上使用 Aspose.Slides.NET，在 Linux 和 macOS 上使用 Aspose.Slides.NET6.CrossPlatform。对于 Alpine Linux、glibc 版本低于上述要求的 Linux 系统，以及针对 .NET Framework 的项目，请使用 Aspose.Slides.NET。每个项目只能添加这两个包中的一个。

**需要哪些字体才能正确渲染？**

演示文稿中使用的字体或其合适的替代字体必须在操作系统中可用。 在 Linux 和 macOS 上，安装演示文稿所需的字体包以获得一致的渲染。 在 Alpine Linux 上，除 `libgdiplus` 外，还需安装至少一个字体包，具体请参见[Alpine Linux](#alpine-linux)。

**为什么自定义字体在 Linux 上显示为回退或缺失的文本？**

如果字体文件的 name-table 条目不一致或损坏，Linux 的字体匹配堆栈（FreeType/fontconfig）可能会选择无效记录，从而导致字体未能解析。使用修正了 name-table 条目的字体版本或安装一致的替代字体即可解决此问题。
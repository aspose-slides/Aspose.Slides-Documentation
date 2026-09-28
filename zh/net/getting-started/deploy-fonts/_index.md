---
title: 在 Linux 和 Docker 中部署 Aspose.Slides 字体
linktitle: 部署字体
type: docs
weight: 145
url: /zh/net/deploy-fonts/
keywords:
- 部署字体
- 安装字体
- Docker 中的字体
- Linux 上的字体
- 缺失的字体
- 字体替代
- Microsoft 核心字体
- ttf-mscorefonts-installer
- 自定义字体
- 默认字体
- 服务器
- 容器
- PDF 转换
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "在 Linux 服务器和 Docker 容器中为 Aspose.Slides for .NET 部署字体：检查哪些字体被替代，在 Debian、Ubuntu 和 Alpine 上安装字体包，添加自定义字体文件，并设置默认字体。"
---
## **概述**

Aspose.Slides 在渲染演示文稿时使用可用的字体来绘制文本，例如在将幻灯片转换为 PDF 或图像时。 Windows 桌面通常拥有演示文稿使用的字体。 Linux 服务器和容器通常只有很少的字体或根本没有，因此 Aspose.Slides 会使用替代字体来绘制文本。 替代字体的字形和宽度不同，导致换行方式不同、文本可能超出形状，并且替代字体缺少的字符无法正确绘制。 如果根本没有安装任何字体，转换会因错误而停止。

本文展示了如何检查 Aspose.Slides 替代了哪些字体、如何在 Debian、Ubuntu 和 Alpine Linux 上安装字体、如何添加自定义字体文件，以及如何设置缺失字体时使用的字体。 示例在官方 .NET 镜像的 Docker 中运行，参见[Run Aspose.Slides for .NET in Docker](/slides/zh/net/how-to-run-aspose-slides-in-docker/)。 包命令是 Dockerfile 指令；在 Linux 服务器上，请以 root 身份运行相同的命令。

有关字体 API 本身，例如在演示文稿中嵌入字体以及回退和替换规则，请参见[PowerPoint Fonts](/slides/zh/net/powerpoint-fonts/).

## **检查哪些字体被替代**

以下控制台应用程序报告了 Aspose.Slides 在当前环境中替代的字体。 创建一个名为 *FontCheck* 的文件夹，并将下面的文件添加到该文件夹中。

*FontCheck.csproj* 引用了 [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/)，该包适用于 Debian 和 Ubuntu。 它还会将可选的 *fonts* 文件夹中的文件复制到应用程序输出；[Load Fonts from the Application Folder](#load-fonts-from-the-application-folder) 部分使用了它。

```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net10.0</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="Aspose.Slides.NET6.CrossPlatform" Version="26.9.0" />
    <None Update="fonts/**" CopyToOutputDirectory="PreserveNewest" />
  </ItemGroup>

</Project>
```

*Program.cs* 为每个字体名称在幻灯片上添加一个文本框，并通过 [LatinFont](https://reference.aspose.com/slides/zh/net/aspose.slides/baseportionformat/latinfont/) 属性分配字体。 字体名称来源于命令行；如果没有参数，应用程序会检查 Calibri、Arial 和 Times New Roman。 它会打印 Aspose.Slides 查找字体的文件夹（[FontsLoader.GetFontFolders](https://reference.aspose.com/slides/zh/net/aspose.slides/fontsloader/getfontfolders/)），将幻灯片渲染为 *output/fonts.pdf*，并打印 [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/zh/net/aspose.slides/ifontsmanager/getsubstitutions/) 报告的替代情况。 文首的两个可选步骤——加载 *fonts* 文件夹和读取 `DEFAULT_FONT` 变量——将在本文后面解释。

```c#
using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

// 要检查的字体：命令行参数，或三种常见的 Office 字体。
var fontNames = args.Length > 0 ? args : new[] { "Calibri", "Arial", "Times New Roman" };

// 从应用程序旁边的 fonts 文件夹加载字体文件（如果存在）。
var appFontFolder = Path.Combine(AppContext.BaseDirectory, "fonts");
if (Directory.Exists(appFontFolder))
{
    FontsLoader.LoadExternalFonts(new[] { appFontFolder });
}

// 如果已设置 DEFAULT_FONT 环境变量，则使用该变量中指定的字体来处理缺失字体的文本。
var loadOptions = new LoadOptions();
var defaultFont = Environment.GetEnvironmentVariable("DEFAULT_FONT");
if (!string.IsNullOrEmpty(defaultFont))
{
    loadOptions.DefaultRegularFont = defaultFont;
}

var fontFolders = FontsLoader.GetFontFolders().Distinct();
Console.WriteLine($"Font folders: {string.Join(", ", fontFolders)}");

using var presentation = new Presentation(loadOptions);
var slide = presentation.Slides[0];
for (var i = 0; i < fontNames.Length; i++)
{
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50 + i * 80, 600, 60);
    shape.TextFrame.Text = $"This text is set in {fontNames[i]}.";
    shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.LatinFont = new FontData(fontNames[i]);
}

Directory.CreateDirectory("output");
presentation.Save(Path.Combine("output", "fonts.pdf"), SaveFormat.Pdf);

var substitutions = presentation.FontsManager.GetSubstitutions().ToList();
if (substitutions.Count == 0)
{
    Console.WriteLine("No font substitutions.");
}
else
{
    Console.WriteLine("Font substitutions:");
    foreach (var substitution in substitutions)
    {
        Console.WriteLine($"  {substitution.OriginalFontName} -> {substitution.SubstitutedFontName}");
    }
}
```

*.dockerignore* 用于将本地构建结果排除在构建上下文之外：

```text
bin/
obj/
output/
```

*Dockerfile* 使用 .NET SDK 镜像构建应用程序，并在 .NET 运行时镜像上运行。 运行时阶段会安装 Aspose.Slides.NET6.CrossPlatform 所需的 `libfontconfig1`，以及 DejaVu 字体。 [Run Aspose.Slides for .NET in Docker](/slides/zh/net/how-to-run-aspose-slides-in-docker/) 对每条指令进行了说明。

```dockerfile
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY FontCheck.csproj .
RUN dotnet restore
COPY . .
RUN dotnet publish --no-restore -c Release -o /app

FROM mcr.microsoft.com/dotnet/runtime:10.0
RUN apt-get update \
    && apt-get install -y --no-install-recommends libfontconfig1 fonts-dejavu-core \
    && rm -rf /var/lib/apt/lists/*
WORKDIR /app
COPY --from=build /app .
RUN mkdir output && chown $APP_UID output
USER $APP_UID
ENTRYPOINT ["dotnet", "FontCheck.dll"]
```

构建镜像并运行检查：

```bash
docker build -t font-check .
docker run --rm font-check
```

该镜像仅包含 DejaVu 字体，因此这三种字体全部被替换为 DejaVu Sans：

```text
Font folders: /usr/share/fonts, /usr/local/share/fonts, .local/share/fonts, /app/.fonts
Font substitutions:
  Calibri -> DejaVu Sans
  Arial -> DejaVu Sans
  Times New Roman -> DejaVu Sans
```

要检查您自己的演示文稿的字体，请将字体名称作为参数传递，例如 `docker run --rm font-check "Segoe UI" Consolas`。 要将 *output/fonts.pdf* 从容器中复制出来，请使用[Copy the Output to Your Machine](/slides/zh/net/how-to-run-aspose-slides-in-docker/#copy-the-output-to-your-machine) 中的命令。

## **在 Debian 和 Ubuntu 上安装字体**

### **Microsoft 核心字体**

`ttf-mscorefonts-installer` 包会下载并安装微软的 Web 核心字体，其中包括 Arial、Times New Roman、Courier New、Verdana、Georgia 和 Trebuchet MS。 这些字体受微软最终用户许可协议 (EULA) 约束，只有在接受 EULA 后该包才会安装字体。 Docker 构建无法响应提示，导致安装程序拒绝 EULA 并不安装任何字体，而 `apt-get install` 仍然报告成功。 在安装包之前，请使用 `debconf-set-selections` **先**接受 EULA。

在 *Dockerfile* 中，将运行时阶段安装这些包的 `RUN` 指令替换为：

```dockerfile
RUN echo "ttf-mscorefonts-installer msttcorefonts/accepted-mscorefonts-eula select true" | debconf-set-selections \
    && apt-get update \
    && apt-get install -y --no-install-recommends libfontconfig1 fonts-dejavu-core ttf-mscorefonts-installer \
    && rm -rf /var/lib/apt/lists/*
```

重新构建镜像并使用相同的两条命令再次运行检查。 Arial 和 Times New Roman 现在已安装：

```text
Font folders: /usr/share/fonts, /usr/local/share/fonts, .local/share/fonts, /app/.fonts
Font substitutions:
  Calibri -> Arial
```

Calibri 是 Aspose.Slides 创建的演示文稿的默认字体，但它不属于核心字体，因此仍然会被替代。 请参见[Set a Default Font for Missing Fonts](#set-a-default-font-for-missing-fonts)。

在 Debian 上，该包位于 `contrib` 仓库组件中，而 Debian 镜像默认未启用该组件；默认的 .NET 8 和 .NET 9 镜像基于 Debian 12。 在同一指令中启用 `contrib`：

```dockerfile
RUN sed -i 's/^Components: main$/Components: main contrib/' /etc/apt/sources.list.d/debian.sources \
    && echo "ttf-mscorefonts-installer msttcorefonts/accepted-mscorefonts-eula select true" | debconf-set-selections \
    && apt-get update \
    && apt-get install -y --no-install-recommends libfontconfig1 fonts-dejavu-core ttf-mscorefonts-installer \
    && rm -rf /var/lib/apt/lists/*
```

基于 Ubuntu 的 .NET 10 镜像已经启用 `multiverse`，该 Ubuntu 组件包含此包。

### **其他字体包**

Debian 和 Ubuntu 还提供了自由授权的字体包，例如：

| 包 | 字体 |
|---|---|
| `fonts-dejavu-core` | DejaVu Sans, DejaVu Serif, DejaVu Sans Mono |
| `fonts-liberation` | Liberation Sans、Serif 和 Mono，具有与 Arial、Times New Roman 和 Courier New 相同的度量 |
| `fonts-crosextra-carlito` | Carlito，具有与 Calibri 相同的度量 |
| `fonts-crosextra-caladea` | Caladea，具有与 Cambria 相同的度量 |

使用相同的 `RUN` 指令在其中加入 `apt-get install` 安装它们。 Aspose.Slides.NET6.CrossPlatform 不会应用 Linux 字体配置的字体别名：即使安装了 `fonts-liberation`，Arial 文本仍然使用通用替代字体绘制，而不是 Liberation Sans。 若要使用度量兼容的字体来替代缺失的字体，请将其设为[default font](#set-a-default-font-for-missing-fonts) 或添加[font substitution rule](/slides/zh/net/font-substitution/)。

## **添加自定义字体文件**

发行版未打包的字体，例如贵组织的字体或您在服务器上有授权使用的其他字体，可以以字体文件的形式添加。 将字体文件（例如 *.ttf* 文件）放在 *FontCheck* 文件夹内的 *fonts* 文件夹中。 以下示例使用了 Carlito 的文件，这是一种与 Calibri 度量相同的字体，您可以从[Google Fonts](https://fonts.google.com/specimen/Carlito) 下载。

### **在系统字体文件夹中安装字体**

Aspose.Slides 会读取在 `Font folders` 行中列出的文件夹中的字体。 若要为镜像中的所有应用程序安装字体，请将它们复制到 */usr/local/share/fonts*，该文件夹用于本地安装的字体。 在 *Dockerfile* 的运行时阶段，在安装软件包的 `RUN` 指令之后添加以下指令：

```dockerfile
COPY fonts/ /usr/local/share/fonts/
```

### **从应用程序文件夹加载字体**

您也可以不在镜像中安装字体，而是随应用程序一起打包并使用 [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/zh/net/aspose.slides/fontsloader/loadexternalfonts/) 加载它们。 此后这些字体仅对 Aspose.Slides 可用，并随应用程序一起部署。 *FontCheck* 就是这样做的：*FontCheck.csproj* 将 *fonts* 文件夹复制到应用程序输出，*Program.cs* 在创建演示文稿之前将该文件夹传递给 `LoadExternalFonts`。 [Custom Font](/slides/zh/net/custom-font/) 说明了其他提供字体的方式，例如从内存加载。

重新构建镜像，然后检查 Calibri 和 Carlito：

```bash
docker build -t font-check .
docker run --rm font-check Calibri Carlito
```

应用程序文件夹现在出现在字体文件夹列表中，Carlito 不再被替代：

```text
Font folders: /app/fonts, /usr/share/fonts, /usr/local/share/fonts, .local/share/fonts, /app/.fonts
Font substitutions:
  Calibri -> Arial
```

## **为缺失的字体设置默认字体**

当字体缺失时，Aspose.Slides 会使用自己选择的替代字体。 若要自行指定替代字体，请设置 [LoadOptions](https://reference.aspose.com/slides/zh/net/aspose.slides/loadoptions/) 的 [DefaultRegularFont](https://reference.aspose.com/slides/zh/net/aspose.slides/loadoptions/defaultregularfont/) 属性，并将该选项传递给 [Presentation](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/) 构造函数。 *FontCheck* 从 `DEFAULT_FONT` 环境变量读取字体名称。 加载 Carlito 后，可将其用于缺失的字体：

```bash
docker run --rm -e DEFAULT_FONT=Carlito font-check
```

现在 Calibri 使用 Carlito 绘制，Carlito 的字符宽度与 Calibri 相同，因而文本保持原有换行：

```text
Font folders: /app/fonts, /usr/share/fonts, /usr/local/share/fonts, .local/share/fonts, /app/.fonts
Font substitutions:
  Calibri -> Carlito
```

默认字体会替换所有缺失的字体。 若要为单个字体映射，例如将 Arial 映射为 Liberation Sans、将 Calibri 映射为 Carlito，请使用[font substitution rules](/slides/zh/net/font-substitution/)。 规则会更改渲染结果，但 `GetSubstitutions` 并不反映这些规则，因此请在输出文件中检查实际使用的字体。 对于亚洲文字，还需设置 [DefaultAsianFont](https://reference.aspose.com/slides/zh/net/aspose.slides/loadoptions/defaultasianfont/)，请参见[Default Font](/slides/zh/net/default-font/)。

## **在 Alpine Linux 上安装字体**

在 Alpine Linux 上，使用 Aspose.Slides.NET 包；[Run on Alpine Linux](/slides/zh/net/how-to-run-aspose-slides-in-docker/#run-on-alpine-linux) 列出了对项目的更改。 对 *FontCheck* 进行相同的修改：替换包引用，在 *Program.cs* 中添加 `SetSwitch` 语句，并使用以下运行时阶段，该阶段同样会安装 Microsoft 核心字体：

```dockerfile
FROM mcr.microsoft.com/dotnet/runtime:10.0-alpine
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
RUN apk add --no-cache icu-libs libgdiplus font-dejavu msttcorefonts-installer \
    && update-ms-fonts \
    && fc-cache -f
WORKDIR /app
COPY --from=build /app .
RUN mkdir output && chown $APP_UID output
USER $APP_UID
ENTRYPOINT ["dotnet", "FontCheck.dll"]
```

`update-ms-fonts` 下载并安装与 Debian 和 Ubuntu 包相同的 Microsoft 核心字体，其 EULA 同样适用。 `fc-cache` 更新字体缓存。

在 Linux 上使用 Aspose.Slides.NET 时，字体配置库（fontconfig）会为缺失的字体选择替代字体，而 `GetSubstitutions` 并不会报告它，因此 *FontCheck* 会打印 `No font substitutions.` 若要查看某个字体名称实际使用的字体，请在容器中查询 fontconfig：

```bash
docker run --rm --entrypoint fc-match font-check Arial
```

安装了 Microsoft 核心字体后，Arial 将使用 Arial 本身：

```text
Arial.ttf: "Arial" "Regular"
```

如果未安装这些字体，而 `RUN` 指令仅安装 `icu-libs libgdiplus font-dejavu`，同样的命令会输出：

```text
DejaVuSans.ttf: "DejaVu Sans" "Book"
```

## **常见问题**

**为什么在服务器上转换演示文稿时外观会不同？**

服务器没有演示文稿使用的字体，导致 Aspose.Slides 使用字形宽度不同的替代字体绘制文本。 使用演示文稿的字体名称运行 *FontCheck* 来查看哪些字体被替代，然后安装这些字体或从应用程序文件夹加载它们。

**构建已安装 ttf-mscorefonts-installer，但 Arial 仍被替代。原因何在？**

EULA 在安装包之前未被接受，导致安装程序跳过了字体。 在 `apt-get install` 之前添加 `debconf-set-selections` 命令，参考[Microsoft Core Fonts](#microsoft-core-fonts)，然后重新构建镜像。

**打开 PDF 的电脑需要这些字体吗？**

不需要。 在这些示例中，PDF 已嵌入用于绘制文本的字体，因此在任何电脑上显示效果相同。 这些字体仅在 Aspose.Slides 渲染演示文稿的环境中需要。
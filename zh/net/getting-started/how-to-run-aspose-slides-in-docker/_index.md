---
title: 在 Docker 中运行 Aspose.Slides for .NET
linktitle: Docker
type: docs
weight: 140
url: /zh/net/how-to-run-aspose-slides-in-docker/
keywords:
- Docker
- Dockerfile
- Docker 容器
- 多阶段构建
- 容器镜像
- Linux
- Ubuntu
- Alpine
- libfontconfig
- libgdiplus
- 字体
- PDF 转换
- PowerPoint
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "在 Docker 中构建并运行 Aspose.Slides for .NET 控制台应用程序：使用官方 .NET 镜像的多阶段 Dockerfile、所需的 Linux 库和字体，以及如何将生成的文件复制到您的机器。"
---
## **概述**

本文演示如何在 Docker 容器中运行 Aspose.Slides for .NET。您将构建一个小型控制台应用程序，该程序创建包含文本框的演示文稿并将其转换为 PDF，将其与基于 Microsoft 官方 .NET 镜像的多阶段 Dockerfile 打包，运行容器，并将生成的文件复制到本机。文章还列出了 Aspose.Slides 在容器中所需的 Linux 库和字体，并在最后提供了针对 Alpine Linux 的变体。

您只需在机器上安装 Docker。构建镜像使用的 .NET SDK 已包含在构建镜像中，无需额外安装。要安装 Docker，请参见[获取 Docker](https://docs.docker.com/get-started/get-docker/)。

## **选择包和基础镜像**

默认的 .NET 10 容器镜像基于 Ubuntu 24.04。对于这些镜像，请使用[Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/) 包。它需要 `fontconfig` 库，而 .NET 运行时镜像既不包含该库也不包含任何字体，因此本文的 Dockerfile 会同时安装两者。

Aspose.Slides.NET6.CrossPlatform 不在 Alpine Linux 上运行。对于基于 Alpine 的镜像，请使用带有 `libgdiplus` 的[Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/) 包，具体请参见[在 Alpine Linux 上运行](#run-on-alpine-linux)。[安装](/slides/zh/net/installation/) 对比了这两个包。

## **创建项目**

创建名为 *HelloSlidesDocker* 的文件夹并向其中添加以下三个文件。

*HelloSlidesDocker.csproj* 描述了一个针对 .NET 10 的控制台应用程序（即下面使用的容器镜像版本），并引用 Aspose.Slides.NET6.CrossPlatform。将包版本设为[NuGet](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/) 上列出的最新版本。

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
  </ItemGroup>

</Project>
```

*Program.cs* 创建一个[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)，在其第一张幻灯片上添加一个带文本的矩形，并使用[Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) 方法分别保存为 PPTX 和 PDF。两个文件均位于工作目录下的 *output* 文件夹中。随后，应用程序使用[IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) 列出在 PDF 渲染期间被替换的字体，以便您查看容器是否已安装演示文稿使用的字体。

```c#
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

var outputFolder = "output";
Directory.CreateDirectory(outputFolder);

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
shape.TextFrame.Text = "Hello from a Docker container!";

var pptxPath = Path.Combine(outputFolder, "hello.pptx");
var pdfPath = Path.Combine(outputFolder, "hello.pdf");
presentation.Save(pptxPath, SaveFormat.Pptx);
presentation.Save(pdfPath, SaveFormat.Pdf);

foreach (var substitution in presentation.FontsManager.GetSubstitutions())
{
    Console.WriteLine($"Font substitution: {substitution.OriginalFontName} -> {substitution.SubstitutedFontName}");
}

Console.WriteLine($"Saved {pptxPath} and {pdfPath}");
```

*.dockerignore* 将本地构建的 *bin* 和 *obj* 文件夹以及之前运行的输出排除在 Docker 构建上下文之外，从而只使用源文件构建镜像。

```text
bin/
obj/
output/
```

## **编写 Dockerfile**

在同一文件夹中添加名为 *Dockerfile* 的文件：

```dockerfile
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY HelloSlidesDocker.csproj .
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
ENTRYPOINT ["dotnet", "HelloSlidesDocker.dll"]
```

该文件包含两个阶段：

- **构建阶段** 从 .NET SDK 镜像开始。它首先复制项目文件并恢复 NuGet 包，以便只要项目文件不变，Docker 就会复用该层。随后复制源码并将应用发布到 */app*。
- **运行阶段** 从更小的 .NET 运行时镜像开始，该镜像不包含 SDK，只复制已发布的应用。它会安装两个包：
  - `libfontconfig1`：Aspose.Slides.NET6.CrossPlatform 启动时会加载此库；若缺少会抛出 `DllNotFoundException`，提示 `libfontconfig.so.1`。
  - `fonts-dejavu-core`：运行时镜像不含字体，而 Aspose.Slides 至少需要一种已安装字体来绘制文本；若没有字体会抛出 `InvalidOperationException: Cannot find any fonts installed on the system.`。未安装的字体会使用替代字体绘制。DejaVu 系列是一个小型字体集，可实现基本的文本渲染；若要使用演示文稿设计时使用的字体，请参见[部署字体](/slides/zh/net/deploy-fonts/)。

  使用 `--no-install-recommends` 并删除软件包列表可保持镜像体积小。最后几行创建 *output* 文件夹，将其所有权交给官方 .NET 镜像定义的非 root `app` 用户（其用户 ID 存于 `APP_UID` 变量），并以该用户运行应用。

对于 ASP.NET Core 应用，请将运行阶段的基础镜像改为 `mcr.microsoft.com/dotnet/aspnet:10.0`。该镜像同样基于 Ubuntu，所需软件包相同。

## **构建并运行容器**

在 *HelloSlidesDocker* 文件夹中打开终端。构建镜像后运行容器：

```bash
docker build -t hello-slides .
docker run --name hello-slides-run hello-slides
```

首次构建会下载基础镜像和 NuGet 包，因此耗时比后续构建更长。容器运行应用后退出，并打印：

```text
Font substitution: Calibri -> DejaVu Sans
Saved output/hello.pptx and output/hello.pdf
```

首行显示文本使用了 Calibri（新建演示文稿的默认字体），但该字体未安装在镜像中，导致 Aspose.Slides 使用 DejaVu Sans 绘制文本。PDF 中的文本是真实的、可选中的 DejaVu Sans 字体。未提供授权时，Aspose.Slides 还会在每张保存的幻灯片上添加评估水印，详见[授权](/slides/zh/net/licensing/)。

## **将输出复制到本机**

文件位于已停止容器的 */app/output* 文件夹中。将它们复制到本机的 *output* 文件夹后，删除容器：

```bash
docker cp hello-slides-run:/app/output/. ./output
docker rm hello-slides-run
```

这两条命令在 Bash、PowerShell 和 Windows 命令提示符中行为相同。

在 Linux 上，您也可以将本机文件夹挂载到容器，使应用直接写入该文件夹：

```bash
mkdir -p output
docker run --rm --user "$(id -u):$(id -g)" -v "$(pwd)/output:/app/output" hello-slides
```

`--user` 选项使用您的用户和组 ID 运行应用，从而能够写入您创建的文件夹，且文件归属您本人。`--rm` 参数在容器停止后将其删除。

## **在 Alpine Linux 上运行**

要在基于 Alpine 的镜像中运行应用，请改用 Aspose.Slides.NET 包并修改运行阶段。构建阶段保持不变。

1. 在 *HelloSlidesDocker.csproj* 中替换包引用：

   ```xml
   <PackageReference Include="Aspose.Slides.NET" Version="26.9.0" />
   ```

2. 在 *Program.cs* 中，在 `using` 指令之后、首次调用 Aspose.Slides 之前添加以下语句，以启用 Aspose.Slides.NET 在 Linux 上使用的 System.Drawing 支持：

   ```c#
   System.AppContext.SetSwitch("System.Drawing.EnableUnixSupport", true);
   ```

3. 在 *Dockerfile* 中，将运行阶段（第二个 `FROM` 之后的所有内容）替换为：

   ```dockerfile
   FROM mcr.microsoft.com/dotnet/runtime:10.0-alpine
   ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
   RUN apk add --no-cache icu-libs libgdiplus font-dejavu
   WORKDIR /app
   COPY --from=build /app .
   RUN mkdir output && chown $APP_UID output
   USER $APP_UID
   ENTRYPOINT ["dotnet", "HelloSlidesDocker.dll"]
   ```

Alpine 阶段会安装三个软件包并修改一个设置：

- `libgdiplus`：Aspose.Slides.NET 在 Linux 上使用的图形库。
- `font-dejavu`：提供字体。若缺少任何字体，转换会因 `System.ArgumentException: Font '?' cannot be found` 而停止。
- `icu-libs` 与 `DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false`：提供地区性数据。Alpine .NET 镜像默认以全局化不变模式运行，在该模式下 Aspose.Slides 会因缺少 `en-US` 区域信息而抛出 `CultureNotFoundException`。

使用前述相同的命令构建、运行并复制输出。在该镜像上，应用仅打印 `Saved` 行：在 Linux 上使用 Aspose.Slides.NET 时，fontconfig 会为缺失的字体选择替代字体，而 [GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) 不会列出该替代字体。[部署字体](/slides/zh/net/deploy-fonts/) 说明了如何检查实际使用的字体。

## **常见问题**

**应用因 “Unable to load shared library 'libaspose.slides.drawing.capi…'” 而停止。缺少什么？**

在 Ubuntu 和 Debian 镜像上，需要安装 `libfontconfig1` 包；错误信息会列出无法打开的 `libfontconfig.so.1`。在 Alpine Linux 上，该信息表明正在使用 Aspose.Slides.NET6.CrossPlatform，请切换至 Aspose.Slides.NET，步骤见[在 Alpine Linux 上运行](#run-on-alpine-linux)。

**PDF 中的文字字体与 PowerPoint 中不同，为什么？**

演示文稿使用的字体未安装在镜像中，导致 Aspose.Slides 使用替代字体绘制文本。应用的输出会列出每个被替换的字体。请参阅[部署字体](/slides/zh/net/deploy-fonts/) 了解如何在镜像中安装字体或从应用文件夹加载字体。

**我需要在本机安装 .NET SDK 吗？**

不需要。构建阶段在 SDK 镜像内部编译应用。仅当您想在 Docker 之外构建和运行应用时才需要本机 SDK，详见[安装](/slides/zh/net/installation/)。
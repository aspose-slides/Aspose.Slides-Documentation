---
title: 安装
type: docs
weight: 70
url: /zh/nodejs-net/installation/
keywords:
- 下载 Aspose.Slides
- 安装 Aspose.Slides
- Aspose.Slides 安装
- Windows
- macOS
- Linux
- JavaScript
- Node.js
description: "从 npm 在 Windows 或 Linux 上为 Node.js via .NET 安装 Aspose.Slides：先决条件、edge-js 覆盖、一次性 NuGet 恢复，以及创建演示文稿的第一个程序。"
---
## **概述**

Aspose.Slides for Node.js via .NET 是 npm 包 `aspose.slides.via.net`。它通过 [edge-js](https://github.com/agracio/edge-js) 桥在 Node.js 中运行 Aspose.Slides .NET 库，因此需要同时安装 Node.js 和 .NET。

本文将带你从全新机器创建一个创建演示文稿的示例程序。共四个步骤：创建包含 edge-js 覆盖的项目、从 npm 安装包、一次性恢复包的 .NET 依赖项、以及从项目文件夹运行脚本。

## **先决条件**

- **Node.js 22 或 24 LTS**，x64 构建，来自 [nodejs.org](https://nodejs.org/en/download)。
- **.NET SDK 8 或更高**，来自 [dotnet.microsoft.com](https://dotnet.microsoft.com/download)。仅 .NET 运行时不足以完成：下面的恢复步骤需要 SDK，脚本运行时桥接也需要 SDK。运行 `dotnet --list-sdks` 检查已安装的 SDK。
- **仅限 Linux**：
  - 构建工具 `python3`、`make` 和 `g++`，因为在 Linux 上 npm 会在安装期间编译 edge-js；
  - fontconfig 库，Aspose.Slides 原生绘图库需要加载该库。

  在 Debian 上，这些包为 `python3`、`make`、`g++` 和 `libfontconfig1`。

本文中的步骤已在以下平台上测试：

| 平台 | 结果 |
|---|---|
| Windows x64，使用 Node.js 22 或 24 | 可运行。已安装 Microsoft Visual C++ 可再发行组件并进行测试。 |
| Linux x64，使用 Node.js 22 或 24，系统 OpenSSL 与 Node.js 内置的 OpenSSL 属于同一发行系列，例如 Debian 13 | 可运行。 |
| Linux，两个 OpenSSL 版本不同，例如 Debian 12 | 当创建演示文稿时，Node.js 会因段错误崩溃。 |
| macOS | 未验证。 |

在 Linux 上，请在开始前比较两个版本。第一个命令打印 Node.js 内置的 OpenSSL 版本；第二个打印系统版本。使用两个版本的主次号相同的系统，例如 `3.5`：

```sh
node -p process.versions.openssl
openssl version
```

如果找不到 `openssl` 命令，请先安装 `openssl` 包。

## **创建项目**

在项目文件夹中创建目录、初始化，并添加一个覆盖项，告诉 npm 安装哪个 edge-js 版本：

```sh
mkdir hello-slides
cd hello-slides
npm init -y
npm pkg set overrides.edge-js=26.1.0
```

该包会请求一个较旧的 edge-js 发行版，其预编译的 Windows 二进制文件仅支持到 Node.js 20，因此如果不添加覆盖，Windows 上的第一个脚本会出现 “The edge module has not been pre-compiled for node.js version”。该命令会将覆盖写入 `package.json` 的 `overrides` 部分；请在安装包之前添加它。

## **安装包**

从 npm 安装 Aspose.Slides for Node.js via .NET：

```sh
npm install aspose.slides.via.net
```

安装过程中，包会将其原生绘图库（文件名中包含 `aspose.slides.drawing.capi` 的文件）复制到项目文件夹中，位于 `package.json` 同目录。

该包也以 ZIP 档案形式发布在 [releases.aspose.com](https://releases.aspose.com/slides/nodejs-net/)。本文仅涉及通过 npm 的安装方式。

## **恢复 .NET 依赖**

包中包含 Aspose.Slides .NET 程序集，但不包含这些程序集所依赖的 20 个 NuGet 包。运行时，.NET 会在 NuGet 包缓存中查找它们：Windows 上为 `%USERPROFILE%\.nuget\packages`，Linux 上为 `~/.nuget/packages`，或者 `NUGET_PACKAGES` 环境变量指定的文件夹。如果缺失，首个脚本会报 “assembly specified in the dependencies manifest was not found”。

为填充缓存，在项目文件夹中创建名为 `deps` 的子文件夹，并在其中保存以下文件，文件名为 `deps.csproj`。每个 `PackageDownload` 项会下载对应版本的 NuGet 包；不会进行任何编译。

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <TargetFramework>net8.0</TargetFramework>
  </PropertyGroup>
  <ItemGroup>
    <PackageDownload Include="Humanizer.Core" Version="[2.14.1]" />
    <PackageDownload Include="Microsoft.Bcl.AsyncInterfaces" Version="[6.0.0]" />
    <PackageDownload Include="Microsoft.CodeAnalysis.Common" Version="[4.5.0]" />
    <PackageDownload Include="Microsoft.CodeAnalysis.CSharp" Version="[4.5.0]" />
    <PackageDownload Include="Microsoft.CodeAnalysis.CSharp.Workspaces" Version="[4.5.0]" />
    <PackageDownload Include="Microsoft.CodeAnalysis.VisualBasic" Version="[4.5.0]" />
    <PackageDownload Include="Microsoft.CodeAnalysis.VisualBasic.Workspaces" Version="[4.5.0]" />
    <PackageDownload Include="Microsoft.CodeAnalysis.Workspaces.Common" Version="[4.5.0]" />
    <PackageDownload Include="Microsoft.DotNet.InternalAbstractions" Version="[1.0.0]" />
    <PackageDownload Include="Microsoft.Extensions.DependencyModel" Version="[7.0.0]" />
    <PackageDownload Include="Newtonsoft.Json" Version="[13.0.3]" />
    <PackageDownload Include="System.Composition.AttributedModel" Version="[6.0.0]" />
    <PackageDownload Include="System.Composition.Convention" Version="[6.0.0]" />
    <PackageDownload Include="System.Composition.Hosting" Version="[6.0.0]" />
    <PackageDownload Include="System.Composition.Runtime" Version="[6.0.0]" />
    <PackageDownload Include="System.Composition.TypedParts" Version="[6.0.0]" />
    <PackageDownload Include="System.IO.Pipelines" Version="[6.0.3]" />
    <PackageDownload Include="System.Reflection.Metadata" Version="[6.0.1]" />
    <PackageDownload Include="System.Text.Encodings.Web" Version="[7.0.0]" />
    <PackageDownload Include="System.Text.Json" Version="[7.0.0]" />
  </ItemGroup>
</Project>
```

随后在项目文件夹中执行恢复：

```sh
dotnet restore deps/deps.csproj
```

此步骤在每台机器上只需执行一次，而不是每个项目一次：包会保存在 NuGet 缓存中，后续同一机器上的项目会复用它们。恢复完成后，可删除 `deps` 文件夹。

## **运行第一个程序**

在项目文件夹中创建名为 `hello.js` 的文件，内容如下。该脚本创建一个演示文稿，在第一张幻灯片上添加一个包含文字 “Hello, World!” 的矩形，并将结果保存为 `hello.pptx`：

```javascript
const asposeSlides = require("aspose.slides.via.net");
const { Presentation, ShapeType, SaveFormat } = asposeSlides;

// 新的演示文稿包含一个空幻灯片。
const presentation = new Presentation();
try {
    const slide = presentation.slides.get(0);

    // 位置和大小的单位是点（1/72 英寸）：x、y、宽度、高度。
    const rectangle = slide.shapes.addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
    rectangle.addTextFrame("Hello, World!");

    presentation.save("hello.pptx", SaveFormat.Pptx);
    console.log("Saved hello.pptx");
} finally {
    // 释放支持此演示文稿的 .NET 对象。
    presentation.dispose();
}
```

在项目文件夹中运行：

```sh
node hello.js
```

脚本会打印 `Saved hello.pptx`。打开 `hello.pptx` 可看到一张包含填充矩形和文本的幻灯片。未授权情况下，Aspose.Slides 还会添加评估水印；请参阅 [评估 Aspose.Slides](/slides/zh/nodejs-net/evaluate-aspose-slides/) 和 [许可](/slides/zh/nodejs-net/licensing/)。

{{% alert color="info" title="Note" %}}
请从包含 `package.json` 的项目文件夹运行脚本。相对路径（例如 `hello.pptx`）会相对于当前文件夹解析，在某些机器上，从其他文件夹启动的脚本可能无法创建演示文稿。
{{% /alert %}}

JavaScript API 镜像 Aspose.Slides for .NET：类名保持 .NET 名称，属性和方法采用 camelCase（`Slides` 变为 `slides`，`AddAutoShape` 变为 `addAutoShape`），集合项通过 `get(index)` 读取。该包暂无单独的 API 参考，请使用 [Aspose.Slides for .NET API 参考](https://reference.aspose.com/slides/net/) 查阅类和成员详情，例如 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 和 [ShapeCollection.AddAutoShape](https://reference.aspose.com/slides/net/aspose.slides/shapecollection/addautoshape/)。

## **常见问题**

**“The edge module has not been pre-compiled for node.js version” 是什么意思？**

npm 安装了包要求的旧版 edge-js。请按照 [创建项目](#创建项目) 中的说明添加覆盖，然后再次运行 `npm install`。

**“assembly specified in the dependencies manifest was not found” 是什么意思？**

.NET 依赖未出现在 NuGet 缓存中。同一次运行还会报 “edge.initializeClrFunc is not a function”。请按照 [恢复 .NET 依赖](#恢复-.net-依赖) 执行一次，然后再次运行脚本。

**在 Linux 上出现 “The edge native module is not available” 是什么意思？**

`npm install` 时未编译 edge-js，例如缺少 `python3`、`make` 或 `g++`。npm 不会将此视为错误。请安装相应的构建工具，然后在项目文件夹中运行 `npm rebuild edge-js`。

**创建演示文稿时出现空的 “Error” 是为什么？**

在 Linux 上，请确保已安装 fontconfig 库（Debian 上为 `libfontconfig1`）；未安装时原生绘图库无法加载。任何系统上，还请确认脚本是从项目文件夹运行的。

**为什么 Node.js 在 Linux 上会因段错误崩溃？**

系统 OpenSSL 与 Node.js 内置的 OpenSSL 属于不同的发行系列。请参照 [先决条件](#先决条件) 中的比较方法，使用两者版本号相同的发行版或 Node.js 构建。

**每个项目都需要重复执行 NuGet 恢复吗？**

不需要。恢复步骤会填充用户账户的 NuGet 缓存，同一机器上的所有项目都会共享该缓存。
---
title: Aspose.Slides for .NET 6 跨平台
type: docs
weight: 237
url: /net/slides-for-net-6-cross-platform
keywords: Aspose.Slides, .NET, 跨平台
description: Aspose.Slides for .NET 6 跨平台
---

1. 跨平台的 Aspose.Slides for .NET6 可用于 .NET 7 和未来的 .NET 版本。

2. **先决条件**：要使用跨平台版本的 Aspose.Slides for .NET 6，您需要从产品 [发布页面](https://releases.aspose.com/slides/net/) 下载 Aspose.Slides 包。Aspose.Slides NuGet 包不适用，因为它仅为 .NET 标准提供跨平台支持。

3. **要求**：[系统要求](https://docs.aspose.com/slides/net/system-requirements/)。请注意，Aspose.Slides for .NET 6 和 .NET 7 需要 GLIBC 2.23 及更高版本的 Linux x86_x64。**CentOS** 7（其 GLIBC 版本为 2.14）不受支持。要在 CentOS 7 或其他不满足要求的系统（如 Alpine）上使用 Slides，请获取 Aspose.Slides for .NETStandard。

## **获取和使用跨平台 Aspose.Slides**

1. 从 [发布页面](https://releases.aspose.com/slides/net/) 下载最新的 Aspose.Slides ZIP 包。

2. 解压 *\Aspose.Slides.zip\Aspose.Slides\net6.0\crossplatform* 中的文件，并将它们放置在将用于您项目中的依赖项的文件夹中。

3. 添加对 Aspose.Slides.dll 的引用

   ![add-project-reference-visual-studio](add-project-reference-visual-studio.png)

   在我们的示例（如下）中，库位于项目文件夹的路径：*ConsoleApp\libs\Aspose.Slides\net6.0\crossplatform\...*

   ![browse-console-app](browse-console-app.jpg)

4. 通过将以下指令添加到 csproj 项目文件中，将剩余文件（Aspose.Slides 依赖的文件）放置在输出目录：
```
<ItemGroup>

   <None Update="libs\Aspose.Slides\net6.0\crossplatform\aspose.slides.drawing.capi_vc14x64.dll">
         <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
                  <TargetPath>aspose.slides.drawing.capi_vc14x64.dll</TargetPath>
   </None>

   <None Update="libs\Aspose.Slides\net6.0\crossplatform\aspose.slides.drawing.capi_vc14x86.dll">
         <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
                  <TargetPath>aspose.slides.drawing.capi_vc14x86.dll</TargetPath>
   </None>

   <None Update="libs\Aspose.Slides\net6.0\crossplatform\Aspose.Slides.xml">
         <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
                  <TargetPath>Aspose.Slides.xml</TargetPath>
   </None>

   <None Update="libs\Aspose.Slides\net6.0\crossplatform\libaspose.slides.drawing.capi_appleclang.dylib">
         <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
                  <TargetPath>libaspose.slides.drawing.capi_appleclang.dylib</TargetPath>
   </None>

   <None Update="libs\Aspose.Slides\net6.0\crossplatform\libaspose.slides.drawing.capi_x86_64_libstdcpp_libc2.23.so">
         <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
                  <TargetPath>libaspose.slides.drawing.capi_x86_64_libstdcpp_libc2.23.so</TargetPath>
   </None>

</ItemGroup>
```

5. 注意 TargetPath。

   默认情况下，`<CopyToOutputDirectory>` 复制文件时保留它们的相对路径，但我们需要依赖库进入生成输出的相同文件夹（Aspose.Slides.dll 的位置）。

## 注意事项

### **System.Drawing.Common 仅支持 Windows**

从 .NET 6 开始，System.Drawing.Common（提供 GDI+ 支持）的支持仅在 [Windows](https://learn.microsoft.com/en-us/dotnet/core/compatibility/core-libraries/6.0/system-drawing-common-windows-only) 中可用。Aspose.Slides for .NET 依赖于 GDI+。此外，Aspose.Slides 公共 API 包含来自 System.Drawing.Common 包的类型（Bitmap，Metafile，Graphics 等）。

### **专有图形子系统**

为了解决破坏性变更问题（取消了对 System.Drawing.Common 的跨平台支持），Aspose.Slides 从版本 23.6 开始使用自己实现的图形子系统。

支持的系统有：**Windows**、**Linux** 和 **macOS**。

Aspose.Slides 跨平台是一组库：

| Aspose.Slides.dll                                          | 负责所有 Aspose.Slides 逻辑的主要 .NET 程序集    |
| ---------------------------------------------------------- | ---------------------------------------------------------- |
| aspose.slides.drawing.capi_vc14x64.dll                     | 依赖项：Win x64 的图形子系统实现    |
| aspose.slides.drawing.capi_vc14x86.dll                     | 依赖项：Win x86 的图形子系统实现    |
| libaspose.slides.drawing.capi_x86_64_libstdcpp_libc2.23.so | 依赖项：Linux（x86/x64）的图形子系统实现 |
| libaspose.slides.drawing.capi_appleclang.dylib             | 依赖项：macOS 的图形子系统实现      |

Aspose.Slides.dll 使用系统所需的库。这些库通常位于文件系统中与 Aspose.Slides.dll 相同的位置。

### **Aspose.Slides 公共 API 和来自 System.Drawing.Common 的类型。解决名称冲突问题的解决方案**

Aspose.Slides 公共 API Slides 使用来自 System.Drawing.Common 的类型（Bitmap，Metafile，Graphics 等）。为了促进过渡到新的 Aspose.Slides 跨平台产品，并避免在 Slides 公共 API 中引入许多破坏性变更，专有的图形子系统实现**复制**了来自 System.Drawing.Common 的类型和命名空间。

因此，如果您在 Linux 环境中开发或工作，您只需使用 Aspose.Slides 作为依赖项——整个 API 保持不变。

**潜在问题**：上述设置有其缺点。例如，如果您在 Windows 中开发并且有使用原始 System.Drawing.Common 的项目，您可能会遇到与 Aspose.Slides 类型的冲突。

**解决方案**：您可以使用 extern alias 来解决该问题。请参见 [**使用 System.Drawing.Common 包和 Slides for .NET6 类（CS0433：类型在 Slides 和 System.Drawing.Common 中都存在的错误**)](https://docs.aspose.com/slides/net/net6/#using-the-systemdrawingcommon-package-and-slides-for-net6-classes-cs0433-the-type-exists-in-both-slides-and-systemdrawingcommon-error)。

Slides 团队正在处理将产生简化和统一公共 API 的任务。

### **NuGet 和 ZIP 包**

* NuGet Aspose.Slides for .NET 当前不支持跨平台的 Aspose.Slides for .NET 6。

* NuGet Aspose.Slides for .NET 包支持对 .NET Standard 的跨平台支持，但不支持 .NET 6。

* Aspose.Slides 的跨平台版本作为 ZIP 包提供，位于 [发布页面](https://releases.aspose.com/slides/net/)。

* ZIP 包包含以下文件夹结构：

  ├───net2.0

  ├───net3.5

  ├───net3.5_ClientProfile

  ├───net4.0

  ├───net4.0_ClientProfile

  ├───net6.0

  │  ├───crossplatform

  │  └───win

  ├───netstandard2.0

  └───netstandard2.1

* 每个文件夹包含与其对应的 .NET 版本的程序集。net6.0 有两个版本：win 和 crossplatform。后者包含跨平台的 Aspose.Slides.dll 及其所有依赖项。该文件夹的解压内容可用作跨平台开发和其他 Aspose.Slides 使用实例中的依赖项添加。
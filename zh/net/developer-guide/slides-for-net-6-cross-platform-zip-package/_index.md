---
title: Aspose.Slides for .NET 6 跨平台 (ZIP 包)
type: docs
weight: 237
url: /zh/net/slides-for-net-6-cross-platform-zip-package/
aliases:
  - /net/slides-for-net-6-cross-platform/
keywords:
- 跨平台
- .NET 6
- GLIBC
- csproj
- 目标路径
- 依赖库
- Aspose.Slides.dll
- System.Drawing.Common
- 名称冲突
- 外部别名
- CS0433
- PowerPoint
- OpenDocument
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 6 在 Windows、Linux 和 macOS 上构建跨平台 C# 应用程序，以创建、编辑和转换 PowerPoint PPT、PPTX 和 ODP 文件。"
---
## **概述**

本文说明如何从 ZIP 包中使用 Aspose.Slides for .NET 6 Cross-Platform。它描述了如何下载包、解压 `net6.0/crossplatform` 文件夹中的文件、添加对 `Aspose.Slides.dll` 的引用，以及如何配置项目文件，以便将所需的依赖库复制到应用程序输出目录。

本文还介绍了跨平台包的内容，包括主要的 Aspose.Slides .NET 程序集以及适用于 Windows、Linux 和 macOS 的平台特定图形子系统库。

{{% alert title="Note" color="info" %}}
Aspose.Slides for .NET 6 Cross-Platform 也可以通过[NuGet](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform)获取。
{{% /alert %}}

## **从 ZIP 包使用跨平台 Aspose.Slides**

1. 从[Release Page](https://releases.aspose.com/slides/zh/net/)下载最新 Aspose.Slides 的 ZIP 包。 

2. 解压 *Aspose.Slides.zip\Aspose.Slides\net6.0\crossplatform* 中的文件，并将它们放入项目中用作依赖的文件夹。

3. 添加对 Aspose.Slides.dll 的引用。

   ![add-project-reference-visual-studio](add-project-reference-visual-studio.png)

   在我们的示例（如下）中，库位于项目文件夹的以下路径：*ConsoleApp\libs\Aspose.Slides\net6.0\crossplatform\...*

   ![browse-console-app](browse-console-app.jpg)

4. 将其余 Aspose.Slides 所依赖的文件通过在 csproj 项目文件中添加指令的方式放入输出目录：

```xml
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

   <None Update="libs\Aspose.Slides\net6.0\crossplatform\libaspose.slides.drawing.capi_appleclang_x86_64.dylib">
         <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
         <TargetPath>libaspose.slides.drawing.capi_appleclang_x86_64.dylib</TargetPath>
   </None>

   <None Update="libs\Aspose.Slides\net6.0\crossplatform\libaspose.slides.drawing.capi_appleclang_arm64.dylib">
         <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
         <TargetPath>libaspose.slides.drawing.capi_appleclang_arm64.dylib</TargetPath>
   </None>

   <None Update="libs\Aspose.Slides\net6.0\crossplatform\libaspose.slides.drawing.capi_x86_64_libstdcpp_libc2.23.so">
         <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
         <TargetPath>libaspose.slides.drawing.capi_x86_64_libstdcpp_libc2.23.so</TargetPath>
   </None>

</ItemGroup>
```

5. 注意 `TargetPath`。

   默认情况下，`<CopyToOutputDirectory>` 会在保留相对路径的同时复制文件，但我们需要将依赖库复制到与输出生成位置（Aspose.Slides.dll 所在位置）相同的文件夹。

## **注意事项**

### **专有图形子系统**

Aspose.Slides 跨平台是一组库：

| Aspose.Slides.dll                                          | 负责所有 Aspose.Slides 逻辑的主要 .NET 程序集 |
| ---------------------------------------------------------- | ------------------------------------------------ |
| aspose.slides.drawing.capi_vc14x64.dll                     | 依赖：适用于 Win x64 的图形子系统实现 |
| aspose.slides.drawing.capi_vc14x86.dll                     | 依赖：适用于 Win x86 的图形子系统实现 |
| libaspose.slides.drawing.capi_x86_64_libstdcpp_libc2.23.so | 依赖：适用于 Linux (x86/x64) 的图形子系统实现 |
| libaspose.slides.drawing.capi_appleclang_x86_64.dylib      | 依赖：适用于 macOS AMD64 (x86-64/x64) 的图形子系统实现 |
| libaspose.slides.drawing.capi_appleclang_arm64.dylib       | 依赖：适用于 macOS ARM64 (AArch64) 的图形子系统实现 |

Aspose.Slides.dll 会使用运行系统所需的库。这些库通常与 Aspose.Slides.dll 位于同一位置。

### **ZIP 包结构**

ZIP 包包含以下文件夹结构：

Aspose.Slides
├─── net6.0
│   ├─── crossplatform
│   └─── default
├─── net20
├─── net462
└─── netstandard2.0

* 每个文件夹包含对应 .NET 版本的程序集。net6.0 有两个版本：default 和 crossplatform。后者包含跨平台的 Aspose.Slides.dll 及其所有依赖项。解压此文件夹的内容可作为跨平台开发和其他 Aspose.Slides 使用场景的依赖添加到项目中。

## **参见**

- [System Requirements](/slides/zh/net/system-requirements/)
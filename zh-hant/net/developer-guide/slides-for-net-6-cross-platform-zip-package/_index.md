---
title: Aspose.Slides for .NET 6 跨平台 (ZIP 套件)
type: docs
weight: 237
url: /zh-hant/net/slides-for-net-6-cross-platform-zip-package/
aliases:
  - /net/slides-for-net-6-cross-platform/
keywords:
- 跨平台
- .NET 6
- GLIBC
- csproj
- 目標路徑
- 相依函式庫
- Aspose.Slides.dll
- System.Drawing.Common
- 名稱衝突
- 外部別名
- CS0433
- PowerPoint
- OpenDocument
- 簡報
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 6 建置跨平台的 C# 應用程式，可在 Windows、Linux 與 macOS 上建立、編輯與轉換 PowerPoint PPT、PPTX 與 ODP 檔案。"
---
## **概觀**

本文說明如何從 ZIP 套件使用 Aspose.Slides for .NET 6 Cross-Platform。它描述了如何下載套件、從 `net6.0/crossplatform` 資料夾解壓檔案、加入對 `Aspose.Slides.dll` 的參考，並設定專案檔，使所需的相依函式庫會複製到應用程式的輸出目錄。

本文亦說明跨平台套件的內容，包括主要的 Aspose.Slides .NET 程式集以及針對 Windows、Linux 與 macOS 的平台特定圖形子系統函式庫。

{{% alert title="注意" color="info" %}}

Aspose.Slides for .NET 6 Cross-Platform 也可從[NuGet](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform)取得。

{{% /alert %}}

## **從 ZIP 套件使用跨平台 Aspose.Slides**

1. 從[Release Page](https://releases.aspose.com/slides/zh-hant/net/)下載最新版 Aspose.Slides 的 ZIP 套件。

2. 從 *Aspose.Slides.zip\Aspose.Slides\net6.0\crossplatform* 解壓檔案，並將它們放置在專案中用作相依性的資料夾內。

3. 加入對 Aspose.Slides.dll 的參考。

   ![add-project-reference-visual-studio](add-project-reference-visual-studio.png)

   在我們的範例（如下）中，函式庫位於專案資料夾的以下路徑：*ConsoleApp\libs\Aspose.Slides\net6.0\crossplatform\...*

   ![browse-console-app](browse-console-app.jpg)

4. 透過在 csproj 專案檔加入以下指示，將其餘（Aspose.Slides 所依賴的）檔案放入輸出目錄：

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

   預設情況下，`<CopyToOutputDirectory>` 會在保留相對路徑的同時複製檔案，但我們需要將相依函式庫複製到產生輸出的相同資料夾（Aspose.Slides.dll 所在位置）。

## **備註**

### **專有圖形子系統**

Aspose.Slides 跨平台是一組函式庫：

| Aspose.Slides.dll                                          | 主要 .NET 程式集，負責所有 Aspose.Slides 邏輯                                 |
| ---------------------------------------------------------- | -------------------------------------------------------------------------- |
| aspose.slides.drawing.capi_vc14x64.dll                     | 相依性：Windows x64 圖形子系統實作                                            |
| aspose.slides.drawing.capi_vc14x86.dll                     | 相依性：Windows x86 圖形子系統實作                                            |
| libaspose.slides.drawing.capi_x86_64_libstdcpp_libc2.23.so | 相依性：Linux (x86/x64) 圖形子系統實作                                        |
| libaspose.slides.drawing.capi_appleclang_x86_64.dylib      | 相依性：macOS AMD64 (x86-64/x64) 圖形子系統實作                               |
| libaspose.slides.drawing.capi_appleclang_arm64.dylib       | 相依性：macOS ARM64 (AArch64) 圖形子系統實作                                 |

Aspose.Slides.dll 會使用執行系統所需的圖形子系統函式庫。這些函式庫通常與 Aspose.Slides.dll 位於同一位置。

### **ZIP 套件結構**

ZIP 套件包含以下資料夾結構：

Aspose.Slides
├─── net6.0
│   ├─── crossplatform
│   └─── default
├─── net20
├─── net462
└─── netstandard2.0

* 每個資料夾內都有對應 .NET 版本的程式集。net6.0 有兩個版本：default 與 crossplatform；後者包含跨平台的 Aspose.Slides.dll 及其所有相依性。此資料夾解壓後的內容可作為跨平台開發或其他 Aspose.Slides 使用情境的相依性加入專案。

## **另見**

- [系統需求](/slides/zh-hant/net/system-requirements/)
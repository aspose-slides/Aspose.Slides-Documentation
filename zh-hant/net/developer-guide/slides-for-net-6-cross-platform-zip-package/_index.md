---
title: Aspose.Slides for .NET 6 跨平台 (ZIP 套件)
type: docs
weight: 237
url: /zh-hant/net/slides-for-net-6-cross-platform-zip-package/
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
- extern 別名
- CS0433
- PowerPoint
- OpenDocument
- 簡報
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 6 在 Windows、Linux 與 macOS 上構建跨平台 C# 應用程式，能建立、編輯與轉換 PowerPoint PPT、PPTX 及 ODP 檔案。"
---
## **概觀**

本文說明如何從 ZIP 套件使用 Aspose.Slides for .NET 6 Cross-Platform。它描述了如何下載套件、解壓縮 `net6.0/crossplatform` 資料夾中的檔案、加入對 `Aspose.Slides.dll` 的參考，並設定專案檔以便將所需的相依庫複製到應用程式輸出目錄。

本文亦說明跨平台套件的內容，包括主要的 Aspose.Slides .NET 組件以及適用於 Windows、Linux 和 macOS 的平台特定圖形子系統庫。

{{% alert title="注意" color="primary" %}}
Aspose.Slides for .NET 6 Cross-Platform 也可從 [NuGet](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform) 取得。
{{% /alert %}}

## **從 ZIP 套件使用跨平台 Aspose.Slides**

1. 從 [Release Page](https://releases.aspose.com/slides/zh-hant/net/) 下載最新 Aspose.Slides 的 ZIP 套件。

2. 解壓縮 *Aspose.Slides.zip\Aspose.Slides\net6.0\crossplatform* 中的檔案，並將它們放入專案中用作相依性的資料夾。

3. 加入對 Aspose.Slides.dll 的參考。

   ![add-project-reference-visual-studio](add-project-reference-visual-studio.png)

   在我們的範例（如下）中，函式庫位於專案資料夾的以下路徑：*ConsoleApp\libs\Aspose.Slides\net6.0\crossplatform\...*

   ![browse-console-app](browse-console-app.jpg)

4. 將其餘（Aspose.Slides 所依賴的）檔案放入輸出目錄，方法是於 csproj 專案檔中加入以下指示：

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

   預設情況下，`<CopyToOutputDirectory>` 會在保留相對路徑的同時複製檔案，但我們需要將相依的函式庫放到產生輸出的相同資料夾（Aspose.Slides.dll 所在位置）。

## **注意事項**

### **專有圖形子系統**

| Aspose.Slides.dll                                          | 負責所有 Aspose.Slides 邏輯的主要 .NET 組件                 |
| ---------------------------------------------------------- | ---------------------------------------------------------- |
| aspose.slides.drawing.capi_vc14x64.dll                     | 相依性：Win x64 圖形子系統實作                               |
| aspose.slides.drawing.capi_vc14x86.dll                     | 相依性：Win x64 圖形子系統實作                               |
| libaspose.slides.drawing.capi_x86_64_libstdcpp_libc2.23.so | 相依性：適用於 Linux (x86/x64) 的圖形子系統實作           |
| libaspose.slides.drawing.capi_appleclang_x86_64.dylib      | 相依性：macOS AMD64 (x86-64/x64) 圖形子系統實作           |
| libaspose.slides.drawing.capi_appleclang_arm64.dylib       | 相依性：macOS ARM64 (AArch64) 圖形子系統實作               |

Aspose.Slides.dll 會使用執行環境所需的函式庫。這些函式庫通常與 Aspose.Slides.dll 位於相同的目錄中。

### **ZIP 套件結構**

ZIP 套件包含以下資料夾結構：

  Aspose.Slides

  ├─── net6.0

  │  ├─── crossplatform

  │  └─── default

  ├─── net20

  ├─── net462

  └─── netstandard2.0

* 每個資料夾皆包含對應 .NET 版本的組件。net6.0 有兩個版本：default 與 crossplatform。後者包含跨平台的 Aspose.Slides.dll 以及所有相依性。解壓縮此資料夾的內容可作為專案的相依項目，用於跨平台開發以及其他 Aspose.Slides 的使用情境。

## **相關參考**

- [系統需求](/slides/zh-hant/net/system-requirements/)
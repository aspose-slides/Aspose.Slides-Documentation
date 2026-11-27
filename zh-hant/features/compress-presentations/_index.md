---
title: 壓縮簡報
description: 透過壓縮圖片與移除未使用的內容來減少簡報檔案大小。
type: docs
url: /zh-hant/features/compress-presentations/
weight: 250
feature_id: compress-presentations
feature_group: operations
translationKey: slides-feature-compress-presentations
feature_catalogue_version: 3
feature_guides:
- /slides/net/low-code-presentation-operations/
- /slides/net/image/
---
## **概觀**

壓縮圖片，在不再需要時移除已裁剪的影像區域，並在儲存前選擇簡報壓縮設定。此功能對於包含大量照片或重複媒體的簡報特別有用。節省的容量取決於您所選擇的內容與設定。

## **使用範例**

此 C# 範例載入 `input.pptx`，壓縮簡報，並將其儲存為 `compressed.pptx`。

使用 Aspose.Slides for .NET 26.11 或更新版本。設定方法請參閱 [安裝 Aspose.Slides for .NET](/slides/zh-hant/net/installation/)。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");
Compress.CompressPresentation(presentation);
presentation.Save("compressed.pptx", SaveFormat.Pptx);
```


<!-- visual-explanation:compress-presentations:start -->
[![相同比例的圖片渲染前後對比，接著顯示測量的 PPTX 檔案大小條與儲存的影像尺寸。](visual-compress-presentations-1adbf86268a5.svg)](visual-compress-presentations-1adbf86268a5.svg)

*在單一合成細節網格測試器上測量：584,030 → 128,323 位元組。兩個渲染使用相同的比例與 252 × 336 點的框架。壓縮會移除裁切的邊緣，並將儲存的影像縮減至 525 × 700 像素；節省的容量取決於原始檔案。*
<!-- visual-explanation:compress-presentations:end -->

## **常見問題**

### **這是單一檔案整體優化開關嗎？**

Aspose.Slides for .NET 26.11 新增了 [Compress.CompressPresentation](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compresspresentation/)，它結合了未使用的版面/母版移除、嵌入字型子集化以及 150 DPI 圖片壓縮。它會永久移除已裁剪的圖片區域。若僅處理圖片，請使用 [Compress.CompressImages](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compressimages/)；如需更細緻的控制，請參閱 [individual-picture compression example](/slides/zh-hant/net/examples/optimization-batch/compression/)。自 26.11 版起，同樣的整體簡報呼叫也可在 Java、透過 Java 的 Node.js、透過 .NET 的 Python 以及 C++ 中使用。本範例及本頁面的連結皆針對 .NET。

### **影像壓縮會改變可編輯的文字或圖表嗎？**

圖片壓縮僅針對圖片資料，並不會影響可編輯的文字或圖表資料。請檢查圖片，因為重新調整大小或再壓縮可能會降低其細節。

### **我應該如何為簡報影像選擇解析度？**

請根據顯示的圖片尺寸以及預期的螢幕或列印用途來選擇目標解析度。對於大螢幕、列印以及細節豐富的圖表，保留較高解析度較為適合，且在捨棄原始檔案前請比對渲染結果。

## **指南**

- [在 .NET 中壓縮整個簡報](/slides/zh-hant/net/low-code-presentation-operations/#compress-the-whole-presentation)
- [在 .NET 中最佳化簡報的影像管理](/slides/zh-hant/net/image/)

相關功能：[移除未使用的母版、版面與媒體](/slides/zh-hant/features/remove-unused-content/).

## 可執行的 .NET 範例

- [減少簡報大小](/slides/zh-hant/net/examples/optimization-batch/compression/)
---
title: 壓縮簡報
description: 透過壓縮圖像與移除未使用的內容來減少簡報檔案大小。
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
## **概述**

壓縮圖片，當不再需要時移除已裁切的圖像區域，並在儲存前選擇簡報壓縮設定。這對包含大量相片或重複媒體的簡報特別有用。節省的大小取決於內容和所選設定。

## **使用範例**

此 C# 範例載入 `input.pptx`，壓縮簡報，並將其儲存為 `compressed.pptx`。

使用 Aspose.Slides for .NET 26.11 或更新版本。設定方式請參閱 [安裝 Aspose.Slides for .NET](/slides/zh-hant/net/installation/).

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");
Compress.CompressPresentation(presentation);
presentation.Save("compressed.pptx", SaveFormat.Pptx);
```

## **常見問題**

### **這是一個單一的全檔案最佳化開關嗎？**

Aspose.Slides for .NET 26.11 新增了 [Compress.CompressPresentation](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compresspresentation/)，它結合了未使用的版面配置/母版移除、嵌入字型子集化以及 150 DPI 圖片壓縮。它會永久移除已裁切的圖片區域。若只處理圖片，請使用 [Compress.CompressImages](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compressimages/)；想要更細緻的控制，請查看 [individual-picture compression example](/slides/zh-hant/net/examples/optimization-batch/compression/)。這些新協助工具僅適用於上述 .NET 版本；如需其他 SDK，請參閱相應指南。

### **圖片壓縮會更改可編輯的文字或圖表嗎？**

圖片壓縮的目標是圖片資料，而非可編輯的文字或圖表資料。請檢查圖像，因為重新調整大小或重新壓縮可能會降低其細節。

### **應如何為簡報圖片選擇解析度？**

根據顯示的圖片尺寸以及預期的螢幕或列印用途來選擇目標解析度。對於大型螢幕、列印及詳細圖表，請保留較高解析度，並在丟棄原始檔之前比較渲染結果。

## **指南**

- [在 .NET 中壓縮整個簡報](/slides/zh-hant/net/low-code-presentation-operations/#compress-the-whole-presentation)
- [在 .NET 中最佳化簡報的影像管理](/slides/zh-hant/net/image/)

相關功能：[移除未使用的母版、版面配置和媒體](/slides/zh-hant/features/remove-unused-content/).

## 可執行的 .NET 範例

- [減少簡報大小](/slides/zh-hant/net/examples/optimization-batch/compression/)
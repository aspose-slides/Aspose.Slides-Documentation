---
title: 壓縮簡報
description: 透過影像壓縮減少簡報大小並儲存設定。
type: docs
url: /zh-hant/features/compress-presentations/
weight: 250
feature_id: compress-presentations
feature_group: operations
translationKey: slides-feature-compress-presentations
feature_catalogue_version: 3
feature_guides:
- /slides/net/image/
---
## **概觀**

壓縮圖片，當裁剪的圖像區域不再需要時將其移除，並在儲存前選擇簡報的壓縮設定。這對於包含大量照片或重複媒體的簡報特別有用。可節省的容量取決於內容與所選設定。

## **使用範例**

此 C# 範例使用 Aspose.Slides for .NET。它會產生一個 1600 × 900 像素的漸層 PNG，將其插入小圖片框，並儲存為 *before.pptx*。接著將該圖片壓縮至目標解析度 96 DPI，並儲存為 *compressed.pptx*。比較兩個檔案的大小與預覽：節省的效果取決於輸入圖片與顯示尺寸。

設定方式請參見[Install Aspose.Slides for .NET](/slides/zh-hant/net/installation/)。

```csharp
using System;
using System.Drawing;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using (var bitmap = new Bitmap(1600, 900))
{
    for (var y = 0; y < bitmap.Height; y++)
        for (var x = 0; x < bitmap.Width; x++)
            bitmap.SetPixel(x, y, Color.FromArgb(x % 256, y % 256, (x + y) % 256));
    bitmap.Save("large.png", System.Drawing.Imaging.ImageFormat.Png);
}
using var presentation = new Presentation();
var title = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 40, 20, 500, 60);
title.TextFrame.Text = "Photo";
var bytes = File.ReadAllBytes("large.png");
var image = presentation.Images.AddImage(bytes);
var picture = presentation.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 40, 120, 240, 135, image);
presentation.Save("before.pptx", SaveFormat.Pptx);
var compressed = picture.PictureFormat.CompressImage(true, 96f);
Console.WriteLine($"Picture compressed: {compressed}");
presentation.Save("compressed.pptx", SaveFormat.Pptx);
using var preview = presentation.Slides[0].GetImage(1f, 1f);
preview.Save("compressed.png", ImageFormat.Png);
```

## **常見問題**

### **這是單一全檔案的最佳化開關嗎？**

Aspose.Slides for .NET 26.11 新增了[Compress.CompressPresentation](/slides/zh-hant/net/low-code-presentation-operations/#compress-the-whole-presentation) ，可同時執行未使用的版面配置/母版移除、嵌入字型子集化以及 150 DPI 圖片壓縮，並永久移除裁剪的圖片區域。若僅處理圖片，請使用 Compress.CompressImages；若需要更細緻的控制，請保留上述每張圖片的工作流程。這些新輔助功能僅限於指定的 .NET 版本；其他 SDK 請參考相應指南。

### **圖片壓縮會改變可編輯的文字或圖表嗎？**

圖片壓縮僅針對圖片資料，不會影響可編輯的文字或圖表資料。請檢查圖像，因為調整大小或重新壓縮可能會降低細節。

### **應該如何為簡報圖片選擇解析度？**

依據顯示的圖片大小與預期的螢幕或列印用途選擇目標解析度。對於大型螢幕、列印或細節圖示保留較高解析度，並在捨棄原始檔前先比較渲染結果。

## **指南**

- [Optimize Image Management in Presentations in .NET](/slides/zh-hant/net/image/)

相關功能：[Remove unused masters, layouts and media](/slides/zh-hant/features/remove-unused-content/)。

## 可執行的 .NET 範例

- [Reduce Presentation Size](/slides/zh-hant/net/examples/optimization-batch/compression/)
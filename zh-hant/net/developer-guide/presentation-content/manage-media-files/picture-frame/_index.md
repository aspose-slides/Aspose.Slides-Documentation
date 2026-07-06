---
title: 在 .NET 中管理投影片的圖片框
linktitle: 圖片框
type: docs
weight: 10
url: /zh-hant/net/picture-frame/
keywords:
- 圖片框
- 新增圖片框
- 建立圖片框
- 新增影像
- 建立影像
- 擷取影像
- 點陣影像
- 向量影像
- 裁剪影像
- 裁剪區域
- StretchOff 屬性
- 圖片框格式設定
- 圖片框屬性
- 相對比例
- 影像效果
- 長寬比
- 影像透明度
- PowerPoint
- OpenDocument
- 投影片
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 在 PowerPoint 與 OpenDocument 投影片中新增圖片框。簡化工作流程並提升投影片設計。"
---
## **簡介**

圖片框是一種包含影像的形狀——它就像是框中的圖片。

您可以透過圖片框將影像新增至投影片。如此一來，您即能透過格式化圖片框來調整影像的格式。

{{% alert title="提示" color="primary" %}} 
Aspose 提供免費的轉換工具——[JPEG 轉 PowerPoint](https://products.aspose.app/slides/zh-hant/import/jpg-to-ppt) 和 [PNG 轉 PowerPoint](https://products.aspose.app/slides/zh-hant/import/png-to-ppt)——讓使用者能快速從影像建立投影片。 
{{% /alert %}} 

## **建立圖片框**

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation) 類別的執行個體。  
2. 透過索引取得投影片的參考。  
3. 透過將影像新增至與投影片關聯的 [IImagescollection](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iimagecollection)，建立 [IPPImage](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ippimage) 物件以填充形狀。  
4. 指定影像的寬度與高度。  
5. 透過參考投影片關聯的形狀物件所公開的 `AddPictureFrame` 方法，基於影像的寬度與高度建立 [PictureFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/pictureframe)。  
6. 將包含圖片的圖片框新增至投影片。  
7. 將修改後的投影片寫入為 PPTX 檔案。  

以下 C# 程式碼示範如何建立圖片框：

```c#
// 實例化代表 PPTX 檔案的 Presentation 類別
using (Presentation pres = new Presentation())
{
    // 取得第一張投影片
    ISlide slide = pres.Slides[0];

    // 載入影像並將其加入投影片的影像集合
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // 新增具有相同高度與寬度的圖片框
    IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, ppImage.Width, ppImage.Height, ppImage);

    // 對圖片框套用一些格式設定
    pictureFrame.LineFormat.FillFormat.FillType = FillType.Solid;
    pictureFrame.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
    pictureFrame.LineFormat.Width = 20;
    pictureFrame.Rotation = 45;

    // 將投影片寫入 PPTX 檔案
    pres.Save("RectPicFrameFormat_out.pptx", SaveFormat.Pptx);
}
```

{{% alert color="warning" %}} 
圖片框讓您能快速以影像建立投影片。結合 Aspose.Slides 的儲存選項，您可以操作輸入/輸出以將影像從一種格式轉換為另一種格式。您可能想參閱以下頁面：轉換 [image to JPG](https://products.aspose.com/slides/zh-hant/net/conversion/image-to-jpg/)；轉換 [JPG to image](https://products.aspose.com/slides/zh-hant/net/conversion/jpg-to-image/)；轉換 [JPG to PNG](https://products.aspose.com/slides/zh-hant/net/conversion/jpg-to-png/)、轉換 [PNG to JPG](https://products.aspose.com/slides/zh-hant/net/conversion/png-to-jpg/)；轉換 [PNG to SVG](https://products.aspose.com/slides/zh-hant/net/conversion/png-to-svg/)、轉換 [SVG to PNG](https://products.aspose.com/slides/zh-hant/net/conversion/svg-to-png/)。 
{{% /alert %}}

## **使用相對比例建立圖片框**

透過調整影像的相對縮放，您可以建立更複雜的圖片框。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation) 類別的執行個體。  
2. 透過索引取得投影片的參考。  
3. 將影像新增至投影片的影像集合。  
4. 透過將影像新增至與投影片關聯的 [IImagescollection](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iimagecollection)，建立 [IPPImage](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ippimage) 物件以填充形狀。  
5. 指定圖片框中影像的相對寬度與高度。  
6. 將修改後的投影片寫入為 PPTX 檔案。  

以下 C# 程式碼示範如何使用相對比例建立圖片框：

```c#
// 實例化代表 PPTX 檔案的 Presentation 類別
using (Presentation presentation = new Presentation())
{
    // 載入影像並將其加入投影片的影像集合
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = presentation.Images.AddImage(image);
    image.Dispose();

    // 在投影片上新增圖片框
    IPictureFrame pictureFrame = presentation.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, ppImage);

    // 設定相對縮放的寬度與高度
    pictureFrame.RelativeScaleHeight = 0.8f;
    pictureFrame.RelativeScaleWidth = 1.35f;

    // 儲存投影片
    presentation.Save("Adding Picture Frame with Relative Scale_out.pptx", SaveFormat.Pptx);
}
```

## **從圖片框擷取點陣圖影像**

您可以從 [PictureFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/pictureframe) 物件中擷取點陣圖影像，並以 PNG、JPG 等格式儲存。以下程式碼示範如何從文件「sample.pptx」擷取影像並以 PNG 格式儲存。

```c#
using (var presentation = new Presentation("sample.pptx"))
{
    var firstSlide = presentation.Slides[0];
    var firstShape = firstSlide.Shapes[0];

    if (firstShape is IPictureFrame pictureFrame)
    {
        var image = pictureFrame.PictureFormat.Picture.Image.SystemImage;
        image.Save("slide_1_shape_1.png", ImageFormat.Png);
    }
}
```

## **從圖片框擷取 SVG 影像**

當投影片包含放在 [PictureFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/pictureframe/) 形狀中的 SVG 圖形時，Aspose.Slides for .NET 可讓您以完整保真度取得原始向量影像。透過遍歷投影片的形狀集合，您可以辨識每個 [PictureFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/pictureframe/)，檢查底層的 [IPPImage](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ippimage/) 是否包含 SVG 內容，然後將該影像以原生 SVG 格式儲存至磁碟或串流。

以下程式碼示範如何從圖片框擷取 SVG 影像：

```cs
using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = slide.Shapes[0];

if (shape is IPictureFrame pictureFrame)
{
    var svgImage = pictureFrame.PictureFormat.Picture.Image.SvgImage;
    if (svgImage != null)
    {
        File.WriteAllText("output.svg", svgImage.SvgContent);
    }
}
```

## **取得影像的透明度**

Aspose.Slides 允許您取得套用於影像的透明度效果。以下 C# 程式碼示範此操作：

```c#
using (var presentation = new Presentation("Test.pptx"))
{
    var pictureFrame = (IPictureFrame)presentation.Slides[0].Shapes[0];
    var imageTransform = pictureFrame.PictureFormat.Picture.ImageTransform;
    foreach (var effect in imageTransform)
    {
        if (effect is IAlphaModulateFixed alphaModulateFixed)
        {
            var transparencyValue = 100 - alphaModulateFixed.Amount;
            Console.WriteLine("Picture transparency: " + transparencyValue);
        }
    }
}
```

## **取得影像的亮度與對比度**

Aspose.Slides 允許您取得套用於影像的亮度與對比度效果。[ILuminance](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.effects/iluminance/) 介面代表此影像變換效果。

以下 C# 程式碼示範如何從圖片框取得亮度與對比度設定：

```csharp
using (var presentation = new Presentation("sample.pptx"))
{
    var slide = presentation.Slides[0];
    var shape = slide.Shapes[0];
    var pictureFrame = (IPictureFrame)shape;

    var imageTransform = pictureFrame.PictureFormat.Picture.ImageTransform;
    foreach (var effect in imageTransform)
    {
        if (effect is ILuminance luminanceEffect)
        {
            var luminance = luminanceEffect.GetEffective();
            var brightness = luminance.Brightness;
            var contrast = luminance.Contrast;

            Console.WriteLine("Brightness: " + brightness);
            Console.WriteLine("Contrast: " + contrast);
        }
    }
}
```

{{% alert color="primary" %}} 
所有套用於影像的效果皆可在 [Aspose.Slides.Effects](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.effects/) 中找到。 
{{% /alert %}}

## **圖片框格式設定**

Aspose.Slides 提供許多可套用於圖片框的格式設定選項。使用這些選項，您可以調整圖片框以符合特定需求。

1. 建立 [Presentation](http://www.aspose.com/api/net/slides/zh-hant/aspose.slides/) 類別的執行個體。  
2. 透過索引取得投影片的參考。  
3. 透過將影像新增至與投影片關聯的 [IImagescollection](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iimagecollection)，建立 [IPPImage](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ippimage) 物件以填充形狀。  
4. 指定影像的寬度與高度。  
5. 透過 [IShapes](http://www.aspose.com/api/net/slides/zh-hant/aspose.slides/ishapecollection) 物件的 [AddPictureFrame](http://www.aspose.com/api/net/slides/zh-hant/aspose.slides/ishapecollection/methods/addpictureframe) 方法，基於影像的寬度與高度建立 `PictureFrame`。  
6. 將包含圖片的圖片框新增至投影片。  
7. 設定圖片框的線條顏色。  
8. 設定圖片框的線條寬度。  
9. 以正值或負值旋轉圖片框。  
   * 正值會順時針旋轉影像。  
   * 負值會逆時針旋轉影像。  
10. 再次將圖片框（含圖片）新增至投影片。  
11. 將修改後的投影片寫入為 PPTX 檔案。  

以下 C# 程式碼示範圖片框的格式設定流程：

```c#
// 實例化代表 PPTX 檔案的 Presentation 類別
using (Presentation presentation = new Presentation())
{
    // 取得第一張投影片
    ISlide slide = presentation.Slides[0];

    // 載入影像並將其加入投影片的影像集合
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = presentation.Images.AddImage(image);
    image.Dispose();

    // 新增具有相同高度與寬度的圖片框
    IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, ppImage.Width, ppImage.Height, ppImage);

    // 對圖片框套用一些格式設定
    pictureFrame.LineFormat.FillFormat.FillType = FillType.Solid;
    pictureFrame.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
    pictureFrame.LineFormat.Width = 20;
    pictureFrame.Rotation = 45;

    // 將投影片寫入 PPTX 檔案
    presentation.Save("RectPicFrameFormat_out.pptx", SaveFormat.Pptx);
}
```

{{% alert color="primary" %}} 
Aspose 最近開發了免費的 [Collage Maker](https://products.aspose.app/slides/zh-hant/collage)。如果您需要 [合併 JPG/JPEG](https://products.aspose.app/slides/zh-hant/collage/jpg) 或 PNG 影像、[從照片建立格線](https://products.aspose.app/slides/zh-hant/collage/photo-grid)，可使用此服務。 
{{% /alert %}}

## **以連結方式新增影像**

為減少投影片檔案大小，您可以透過連結新增影像（或影片），而非直接將檔案內嵌於投影片中。以下 C# 程式碼示範如何將影像與影片新增至佔位元：

```c#
using (var presentation = new Presentation("input.pptx"))
{
    var shapesToRemove = new List<IShape>();
    int shapesCount = presentation.Slides[0].Shapes.Count;

    for (var i = 0; i < shapesCount; i++)
    {
        var autoShape = presentation.Slides[0].Shapes[i];

        if (autoShape.Placeholder == null)
        {
            continue;
        }

        switch (autoShape.Placeholder.Type)
        {
            case PlaceholderType.Picture:
                var pictureFrame = presentation.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle,
                        autoShape.X, autoShape.Y, autoShape.Width, autoShape.Height, null);

                pictureFrame.PictureFormat.Picture.LinkPathLong =
                    "https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg";

                shapesToRemove.Add(autoShape);
                break;

            case PlaceholderType.Media:
                var videoFrame = presentation.Slides[0].Shapes.AddVideoFrame(
                    autoShape.X, autoShape.Y, autoShape.Width, autoShape.Height, "");

                videoFrame.PictureFormat.Picture.LinkPathLong =
                    "https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg";

                videoFrame.LinkPathLong = "https://youtu.be/t_1LYZ102RA";

                shapesToRemove.Add(autoShape);
                break;
        }
    }

    foreach (var shape in shapesToRemove)
    {
        presentation.Slides[0].Shapes.Remove(shape);
    }

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **裁剪影像**

以下 C# 程式碼示範如何裁剪投影片上現有的影像：

```c#
using (Presentation presentation = new Presentation())
{
    // 建立新的影像物件
    IImage image = Images.FromFile(imagePath);
    IPPImage newImage = presentation.Images.AddImage(image);
    image.Dispose();

    // 新增 PictureFrame 到投影片
    IPictureFrame picFrame = presentation.Slides[0].Shapes.AddPictureFrame(
        ShapeType.Rectangle, 100, 100, 420, 250, newImage);

    // 裁剪影像（百分比值）
    picFrame.PictureFormat.CropLeft = 23.6f;
    picFrame.PictureFormat.CropRight = 21.5f;
    picFrame.PictureFormat.CropTop = 3;
    picFrame.PictureFormat.CropBottom = 31;

    // 儲存結果
    presentation.Save("PictureFrameCrop.pptx", SaveFormat.Pptx);
}
```

## **刪除圖片的裁剪區域**

若需刪除框中影像的裁剪區域，可使用 [IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) 方法。此方法會傳回裁剪後的影像，若不需要裁剪則傳回原始影像。

以下 C# 程式碼示範此操作：

```c#
using (Presentation presentation = new Presentation("PictureFrameCrop.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // 取得第一張投影片的 PictureFrame
    IPictureFrame picFrame = slide.Shapes[0] as IPictureFrame;

    // 刪除 PictureFrame 影像的裁剪區域，並回傳裁剪後的影像
    IPPImage croppedImage = picFrame.PictureFormat.DeletePictureCroppedAreas();

    // 儲存結果
    presentation.Save("PictureFrameDeleteCroppedAreas.pptx", SaveFormat.Pptx);
}
```

{{% alert title="注意" color="warning" %}} 
[IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) 方法會將裁剪後的影像加入投影片的影像集合。若影像僅用於已處理的 [PictureFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/pictureframe/)，此設定可減少投影片大小；否則，最終投影片中的影像數量會增加。

此方法在裁剪過程中會將 WMF/EMF 中繪圖檔轉換為點陣 PNG 影像。 
{{% /alert %}}

## **壓縮影像**

您可以使用 [IPictureFillFormat.CompressImage](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ipicturefillformat/compressimage/) 方法壓縮投影片中的圖片。此方法會根據形狀大小與指定的解析度減少影像尺寸，並可選擇刪除裁剪區域。

它的作用類似於 PowerPoint 的 **圖片格式 → 壓縮圖片 → 解析度** 功能。

以下 C# 範例示範如何透過指定目標解析度並選擇性刪除裁剪區域來壓縮投影片中的影像：

```csharp
using (Presentation presentation = new Presentation("demo.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IPictureFrame pictureFrame = slide.Shapes[0] as IPictureFrame;

    // 以目標解析度 150 DPI（Web 解析度）壓縮影像，並移除裁剪區域。
    bool result = pictureFrame.PictureFormat.CompressImage(true, PicturesCompression.Dpi150);

    // 檢查壓縮的結果。
    if (result)
    {
        Console.WriteLine("Image successfully compressed.");
    }
    else
    {
        Console.WriteLine("Image compression failed or no changes were necessary.");
    }

    presentation.Save("CompressedImage.pptx", SaveFormat.Pptx);
}
```

或直接使用自訂 DPI 值：

```csharp
using (Presentation presentation = new Presentation("demo.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IPictureFrame pictureFrame = slide.Shapes[0] as IPictureFrame;

    // 壓縮影像至 150 DPI（網路解析度），並移除裁剪區域。
    pictureFrame.PictureFormat.CompressImage(true, 150f);

    presentation.Save("CompressedImage.pptx", SaveFormat.Pptx);
}
```

{{% alert title="注意" color="warning" %}} 
此方法會根據形狀大小與提供的 DPI 將影像轉換為較低解析度。裁剪區域亦可被刪除以優化檔案大小。  
若影像為中繪圖檔（WMF/EMF）或 SVG，則不會套用壓縮。JPEG 的品質會根據解析度保持或略有降低，與 PowerPoint 處理高解析度 JPEG 的方式相同。 
{{% /alert %}}

## **鎖定長寬比**

若希望包含影像的形狀在變更影像尺寸後仍保留長寬比，可使用 [IPictureFrameLock.AspectRatioLocked](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ipictureframelock/aspectratiolocked/) 屬性設定 *鎖定長寬比*。

以下 C# 程式碼示範如何鎖定形狀的長寬比：

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    ILayoutSlide layout = pres.LayoutSlides.GetByType(SlideLayoutType.Custom);
    ISlide emptySlide = pres.Slides.AddEmptySlide(layout);

    IImage image = Images.FromFile("image.png");
    IPPImage presImage = pres.Images.AddImage(image);
    image.Dispose();

    IPictureFrame pictureFrame = emptySlide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, presImage.Width, presImage.Height, presImage);

    // 設定形狀在調整大小時保留長寬比
    pictureFrame.PictureFrameLock.AspectRatioLocked = true;
}
```

{{% alert title="注意" color="warning" %}} 
此 *鎖定長寬比* 設定僅保留形狀的長寬比，不會影響其所含的影像。 
{{% /alert %}}

## **使用 StretchOff 屬性**

透過 [IPictureFillFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ipicturefillformat) 介面與 [PictureFillFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/picturefillformat) 類別的 [StretchOffsetLeft](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/picturefillformat/properties/stretchoffsetleft)、[StretchOffsetTop](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/picturefillformat/properties/stretchoffsettop)、[StretchOffsetRight](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/picturefillformat/properties/stretchoffsetright) 與 [StretchOffsetBottom](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/picturefillformat/properties/stretchoffsetbottom) 屬性，您可以指定填充矩形。

當對影像指定拉伸時，來源矩形會依填充矩形的比例縮放。填充矩形的每一邊皆以相對於形狀邊界盒相應邊的百分比偏移定義。正百分比表示內縮，負百分比表示外延。

1. 建立 [Presentation](http://www.aspose.com/api/net/slides/zh-hant/aspose.slides/) 類別的執行個體。  
2. 透過索引取得投影片的參考。  
3. 新增矩形 `AutoShape`。  
4. 建立影像。  
5. 設定形狀的填充類型。  
6. 設定形狀的圖片填充模式。  
7. 新增設定好的影像以填充形狀。  
8. 依形狀邊界盒的相應邊設定影像偏移。  
9. 將修改後的投影片寫入為 PPTX 檔案。  

以下 C# 程式碼示範使用 StretchOff 屬性的流程：

```c#
using (Presentation pres = new Presentation())
{
    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    IPictureFrame pictureFrame = pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 400, 400, ppImage);

    // 設定影像在形狀內部從各側拉伸
    pictureFrame.PictureFormat.PictureFillMode = PictureFillMode.Stretch;
    pictureFrame.PictureFormat.StretchOffsetLeft = 24;
    pictureFrame.PictureFormat.StretchOffsetRight = 24;
    pictureFrame.PictureFormat.StretchOffsetTop = 24;
    pictureFrame.PictureFormat.StretchOffsetBottom = 24;

    pres.Save("imageStretch.pptx", SaveFormat.Pptx);
}
```

## **常見問題**

**如何得知圖片框支援哪些影像格式？**  
Aspose.Slides 透過指派給 [PictureFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/pictureframe/) 的影像物件，支援點陣影像（PNG、JPEG、BMP、GIF 等）與向量影像（例如 SVG）。支援的格式列表通常與投影片與影像轉換引擎的功能相互重疊。

**大量加入大型影像會如何影響 PPTX 的大小與效能？**  
內嵌大型影像會增加檔案大小與記憶體使用量；以連結方式加入影像可減少投影片大小，但需要確保外部檔案保持可存取。Aspose.Slides 提供以連結方式加入影像的功能，以降低檔案大小。

**如何防止影像物件被意外移動或調整大小？**  
使用針對 [PictureFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/pictureframe/) 的 [shape locks](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/pictureframe/pictureframelock/)（例如停用移動或調整大小）。鎖定機制於形狀的「保護」相關文章中說明，適用於包括 [PictureFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/pictureframe/) 在內的多種形狀類型。

**在匯出投影片為 PDF/影像時，SVG 向量的保真度是否會保留？**  
Aspose.Slides 允許從 [PictureFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/pictureframe/) 擷取原始 SVG 向量。當匯出為 PDF（/slides/zh-hant/net/convert-powerpoint-to-pdf/）或點陣格式（/slides/zh-hant/net/convert-powerpoint-to-png/）時，結果可能會根據匯出設定被光柵化；然而，原始 SVG 仍以向量形式儲存，這一點可透過擷取行為得到驗證。
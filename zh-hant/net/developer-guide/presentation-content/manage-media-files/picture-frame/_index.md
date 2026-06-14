---
title: 在 .NET 中管理簡報的圖片框
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
- 裁切影像
- 已裁切區域
- StretchOff 屬性
- 圖片框格式設定
- 圖片框屬性
- 相對縮放
- 影像效果
- 長寬比
- 影像透明度
- PowerPoint
- OpenDocument
- 簡報
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 在 PowerPoint 與 OpenDocument 簡報中新增圖片框。簡化工作流程並提升投影片設計。"
---
## **Introduction**

圖片框是一種包含影像的形狀——就像框中的圖片。  

您可以透過圖片框將影像加入投影片。如此一來，您可以藉由格式化圖片框來調整影像的格式。  

{{% alert  title="Tip" color="primary" %}} 

Aspose 提供免費的轉換器—[JPEG 轉 PowerPoint](https://products.aspose.app/slides/zh-hant/import/jpg-to-ppt) 與 [PNG 轉 PowerPoint](https://products.aspose.app/slides/zh-hant/import/png-to-ppt)—讓使用者能夠快速從影像建立簡報。  

{{% /alert %}} 

## **Create a Picture Frame**

1. 建立 [Presentation ](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation) 類別的實例。  
2. 透過索引取得投影片的參照。  
3. 透過將影像新增至與簡報物件相關聯的 [IImagescollection](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iimagecollection)，建立 [IPPImage](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ippimage) 物件，以用於填充形狀。  
4. 指定影像的寬度與高度。  
5. 透過與參照投影片相關聯之形狀物件所公開的 `AddPictureFrame` 方法，根據影像的寬度與高度建立 [PictureFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/pictureframe)。  
6. 將圖片框（含圖片）新增至投影片。  
7. 將修改後的簡報寫入為 PPTX 檔案。  

```c#
// 建立代表 PPTX 檔案的 Presentation 類別實例
using (Presentation pres = new Presentation())
{
    // 取得第一張投影片
    ISlide slide = pres.Slides[0];

    // 載入影像並將其加入簡報的影像集合
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // 新增具有相同高度與寬度的圖片框
    IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, ppImage.Width, ppImage.Height, ppImage);

    // 為圖片框套用一些格式設定
    pictureFrame.LineFormat.FillFormat.FillType = FillType.Solid;
    pictureFrame.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
    pictureFrame.LineFormat.Width = 20;
    pictureFrame.Rotation = 45;

    // 將簡報寫入 PPTX 檔案
    pres.Save("RectPicFrameFormat_out.pptx", SaveFormat.Pptx);
}
```

{{% alert color="warning" %}} 

圖片框讓您能夠快速以影像建立簡報投影片。將圖片框與 Aspose.Slides 的儲存選項結合，您便可操作輸入/輸出以將影像從一種格式轉換為另一種格式。您可能想參考以下頁面：convert [image to JPG](https://products.aspose.com/slides/zh-hant/net/conversion/image-to-jpg/); convert [JPG to image](https://products.aspose.com/slides/zh-hant/net/conversion/jpg-to-image/); convert [JPG to PNG](https://products.aspose.com/slides/zh-hant/net/conversion/jpg-to-png/), convert [PNG to JPG](https://products.aspose.com/slides/zh-hant/net/conversion/png-to-jpg/); convert [PNG to SVG](https://products.aspose.com/slides/zh-hant/net/conversion/png-to-svg/), convert [SVG to PNG](https://products.aspose.com/slides/zh-hant/net/conversion/svg-to-png/).  

{{% /alert %}}

## **Create a Picture Frame with Relative Scale**

透過調整影像的相對縮放，您可以建立更複雜的圖片框。  

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation) 類別的實例。  
2. 透過索引取得投影片的參照。  
3. 將影像新增至簡報的影像集合中。  
4. 透過將影像新增至與簡報物件相關聯的 [IImagescollection](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iimagecollection)，建立 [IPPImage](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ippimage) 物件，以用於填充形狀。  
5. 在圖片框中指定影像的相對寬度與高度。  
6. 將修改後的簡報寫入為 PPTX 檔案。  

```c#
// 建立代表 PPTX 檔案的 Presentation 類別實例
using (Presentation presentation = new Presentation())
{
    // 載入影像並將其加入簡報的影像集合
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = presentation.Images.AddImage(image);
    image.Dispose();

    // 在投影片上新增圖片框
    IPictureFrame pictureFrame = presentation.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, ppImage);

    // 設定相對縮放的寬度與高度
    pictureFrame.RelativeScaleHeight = 0.8f;
    pictureFrame.RelativeScaleWidth = 1.35f;

    // 儲存簡報
    presentation.Save("Adding Picture Frame with Relative Scale_out.pptx", SaveFormat.Pptx);
}
```

## **Extract Raster Images from Picture Frames**

您可以從 [PictureFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/pictureframe) 物件中擷取點陣圖影像，並儲存為 PNG、JPG 及其他格式。下方的程式碼範例示範如何從文件 “sample.pptx” 中擷取影像並儲存為 PNG 格式。  

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

## **Extract SVG Images from Picture Frames**

當簡報的 [PictureFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/pictureframe/) 形狀中放置 SVG 圖形時，Aspose.Slides for .NET 可讓您完整保留地取得原始向量圖像。透過遍歷投影片的形狀集合，您可以識別每個 [PictureFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/pictureframe/)，檢查底層的 [IPPImage](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ippimage/) 是否包含 SVG 內容，然後將該圖像以原生 SVG 格式儲存至磁碟或串流。  

以下程式碼範例示範如何從圖片框中擷取 SVG 圖像：  

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

## **Get Transparency of an Image**

Aspose.Slides 允許您取得套用在影像上的透明度效果。以下 C# 程式碼示範此操作：  

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

{{% alert color="primary" %}} 
所有套用於影像的效果皆可在 [Aspose.Slides.Effects](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.effects/) 中找到。  
{{% /alert %}}

## **Picture Frame Formatting**

Aspose.Slides 提供多種可套用於圖片框的格式設定選項。使用這些選項，您可以調整圖片框以符合特定需求。  

1. 建立 [Presentation](http://www.aspose.com/api/net/slides/zh-hant/aspose.slides/) 類別的實例。  
2. 透過索引取得投影片的參照。  
3. 透過將影像新增至與簡報物件相關聯的 [IImagescollection](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iimagecollection)，建立 [IPPImage](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ippimage) 物件，以用於填充形狀。  
4. 指定影像的寬度與高度。  
5. 透過與參照投影片相關聯之 [IShapes](http://www.aspose.com/api/net/slides/zh-hant/aspose.slides/ishapecollection) 物件所公開的 [AddPictureFrame](http://www.aspose.com/api/net/slides/zh-hant/aspose.slides/ishapecollection/methods/addpictureframe) 方法，根據影像的寬度與高度建立 `PictureFrame`。  
6. 將圖片框（含圖片）新增至投影片。  
7. 設定圖片框的線條顏色。  
8. 設定圖片框的線條寬度。  
9. 以正值或負值旋轉圖片框。  
   * 正值會使影像順時針旋轉。  
   * 負值會使影像逆時針旋轉。  
10. 將圖片框（含圖片）新增至投影片。  
11. 將修改後的簡報寫入為 PPTX 檔案。  

```c#
// 建立代表 PPTX 檔案的 Presentation 類別實例
using (Presentation presentation = new Presentation())
{
    // 取得第一張投影片
    ISlide slide = presentation.Slides[0];

    // 載入影像並將其加入簡報的影像集合
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = presentation.Images.AddImage(image);
    image.Dispose();

    // 新增一個與圖片等高度與寬度相同的圖片框
    IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, ppImage.Width, ppImage.Height, ppImage);

    // 為圖片框套用一些格式設定
    pictureFrame.LineFormat.FillFormat.FillType = FillType.Solid;
    pictureFrame.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
    pictureFrame.LineFormat.Width = 20;
    pictureFrame.Rotation = 45;

    // 將簡報寫入 PPTX 檔案
    presentation.Save("RectPicFrameFormat_out.pptx", SaveFormat.Pptx);
}
```

{{% alert color="primary" %}}

Aspose 最近開發了 [免費 Collage Maker](https://products.aspose.app/slides/zh-hant/collage)。若您需要 [合併 JPG/JPEG](https://products.aspose.app/slides/zh-hant/collage/jpg) 或 PNG 影像，或 [從照片建立格線](https://products.aspose.app/slides/zh-hant/collage/photo-grid)，都可以使用此服務。  

{{% /alert %}}

## **Add an Image as a Link**

為避免簡報檔案過大，您可以透過鏈結加入影像（或影片），而非直接將檔案嵌入簡報中。以下 C# 程式碼示範如何將影像與影片加入佔位區：  

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

## **Crop Images**

以下 C# 程式碼示範如何裁切投影片上的現有影像：  

```c#
using (Presentation presentation = new Presentation())
{
    // 建立新的影像物件
    IImage image = Images.FromFile(imagePath);
    IPPImage newImage = presentation.Images.AddImage(image);
    image.Dispose();

    // 在投影片上新增 PictureFrame
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

## **Delete Cropped Areas of a Picture**

若您想刪除框內影像的裁切區域，可使用 [IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) 方法。若不需要裁切，該方法會回傳原始影像。  

以下 C# 程式碼示範此操作：  

```c#
using (Presentation presentation = new Presentation("PictureFrameCrop.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // 取得第一張投影片的 PictureFrame
    IPictureFrame picFrame = slide.Shapes[0] as IPictureFrame;

    // 刪除 PictureFrame 影像的已裁切區域並回傳裁切後的影像
    IPPImage croppedImage = picFrame.PictureFormat.DeletePictureCroppedAreas();

    // 儲存結果
    presentation.Save("PictureFrameDeleteCroppedAreas.pptx", SaveFormat.Pptx);
}
```

{{% alert title="NOTE" color="warning" %}} 

[IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) 方法會將裁切後的影像加入簡報的影像集合。若該影像僅在已處理的 [PictureFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/pictureframe/) 中使用，這種設定可減少簡報大小。否則，最終簡報中的影像數量會增加。  

此方法在裁切操作中會將 WMF/EMF 中繪圖檔轉換為點陣 PNG 影像。  

{{% /alert %}}

## **Compress Images**

您可以使用 [IPictureFillFormat.CompressImage](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ipicturefillformat/compressimage/) 方法壓縮簡報中的圖片。此方法會根據形狀大小與指定的解析度縮減影像大小，並可選擇刪除裁切區域。  

它會調整圖片的大小與解析度，類似於 PowerPoint 的 **圖片格式 → 壓縮圖片 → 解析度** 功能。  

以下 C# 範例示範如何透過指定目標解析度並選擇性移除裁切區域來壓縮簡報中的影像：  

```csharp
using (Presentation presentation = new Presentation("demo.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IPictureFrame pictureFrame = slide.Shapes[0] as IPictureFrame;

    // 使用目標解析度 150 DPI（網路解析度）壓縮影像，並移除已裁切區域。
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

    // 將影像壓縮至 150 DPI（網路解析度），並移除已裁切區域。
    pictureFrame.PictureFormat.CompressImage(true, 150f);

    presentation.Save("CompressedImage.pptx", SaveFormat.Pptx);
}
```

{{% alert title="NOTE" color="warning" %}} 

此方法會根據形狀的大小與提供的 DPI 將影像轉為較低解析度。也可刪除裁切區域以最佳化檔案大小。若影像為 WMF/EMF 中繪圖檔或 SVG，則不會套用壓縮。JPEG 的品質會依解析度稍有保留或下降，與 PowerPoint 處理高解析度 JPEG 的方式相同。  

{{% /alert %}}

## **Lock Aspect Ratio**

若您希望包含影像的形狀在更改影像尺寸後仍保持其長寬比，可使用 [IPictureFrameLock.AspectRatioLocked](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ipictureframelock/aspectratiolocked/) 屬性設定 *Lock Aspect Ratio*。  

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

    // 設定形狀在調整大小時保留長寬比例
    pictureFrame.PictureFrameLock.AspectRatioLocked = true;
}
```

{{% alert title="NOTE" color="warning" %}} 

此 *Lock Aspect Ratio* 設定僅保留形狀的長寬比，並不會鎖定其內部的影像。  

{{% /alert %}}

## **Use the StretchOff Property**

使用 [StretchOffsetLeft](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/picturefillformat/properties/stretchoffsetleft)、[StretchOffsetTop](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/picturefillformat/properties/stretchoffsettop)、[StretchOffsetRight](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/picturefillformat/properties/stretchoffsetright) 以及 [StretchOffsetBottom](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/picturefillformat/properties/stretchoffsetbottom) 屬性，您可以指定填充矩形。  

當對影像指定拉伸時，來源矩形會依比例縮放以符合指定的填充矩形。填充矩形的每一邊皆以相對於形狀邊界盒相應邊緣的百分比偏移定義。正百分比表示內縮，負百分比表示外延。  

1. 建立 [Presentation](http://www.aspose.com/api/net/slides/zh-hant/aspose.slides/) 類別的實例。  
2. 透過索引取得投影片的參照。  
3. 新增矩形 `AutoShape`。  
4. 建立影像。  
5. 設定形狀的填充類型。  
6. 設定形狀的圖片填充模式。  
7. 加入設定好的影像以填充形狀。  
8. 指定影像相對於形狀邊界盒相應邊緣的偏移量。  
9. 將修改後的簡報寫入為 PPTX 檔案。  

以下 C# 程式碼示範使用 StretchOff 屬性的流程：  

```c#
using (Presentation pres = new Presentation())
{
    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    IPictureFrame pictureFrame = pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 400, 400, ppImage);

    // 設定影像在形狀本體的四側伸展
    pictureFrame.PictureFormat.PictureFillMode = PictureFillMode.Stretch;
    pictureFrame.PictureFormat.StretchOffsetLeft = 24;
    pictureFrame.PictureFormat.StretchOffsetRight = 24;
    pictureFrame.PictureFormat.StretchOffsetTop = 24;
    pictureFrame.PictureFormat.StretchOffsetBottom = 24;

    pres.Save("imageStretch.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**如何找出 PictureFrame 支援的影像格式？**

Aspose.Slides 透過指派給 [PictureFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/pictureframe/) 的影像物件，同時支援點陣影像（PNG、JPEG、BMP、GIF 等）與向量影像（例如 SVG）。支援的格式清單大致與投影片與影像轉換引擎的功能相吻合。  

**大量加入大型影像會如何影響 PPTX 的大小與效能？**

嵌入大型影像會增加檔案大小與記憶體使用量；使用鏈結加入影像可減少簡報大小，但必須確保外部檔案仍可存取。Aspose.Slides 提供以鏈結方式加入影像的功能，以降低檔案大小。  

**如何防止意外移動/調整影像物件？**

可對 [PictureFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/pictureframe/) 使用 [shape locks](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/pictureframe/pictureframelock/)，例如停用移動或調整大小。鎖定機制在形狀的保護文章中有說明，且支援多種形狀類型，包括 [PictureFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/pictureframe/)。  

**將簡報匯出為 PDF/影像時，SVG 向量的完整性是否得到保留？**

Aspose.Slides 允許從 [PictureFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/pictureframe/) 提取原始 SVG 向量。匯出為 PDF 或點陣格式時，結果可能會根據匯出設定被光柵化；但可透過擷取行為確認原始 SVG 仍以向量形式存放。
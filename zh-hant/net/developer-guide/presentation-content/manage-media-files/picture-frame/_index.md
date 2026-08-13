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
- 新增圖像
- 建立圖像
- 擷取圖像
- 點陣圖像
- 向量圖像
- 裁剪圖像
- 已裁剪區域
- StretchOff 屬性
- 圖片框格式化
- 圖片框屬性
- 相對縮放
- 圖像效果
- 長寬比
- 圖像透明度
- PowerPoint
- OpenDocument
- 簡報
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 為 PowerPoint 和 OpenDocument 簡報新增圖片框。簡化工作流程並提升投影片設計。"
---
## **簡介**

圖片框是一種包含圖像的形狀——它就像框中的圖片。

您可以透過圖片框將圖像加入投影片。這樣，您就能透過格式化圖片框來格式化圖像。

{{% alert  title="Tip" color="info" %}} 
Aspose 提供免費轉換器——[JPEG 轉 PowerPoint](https://products.aspose.app/slides/zh-hant/import/jpg-to-ppt) 與 [PNG 轉 PowerPoint](https://products.aspose.app/slides/zh-hant/import/png-to-ppt)——讓使用者能夠快速從圖像建立簡報。 
{{% /alert %}} 

## **建立圖片框**

1. 建立 [Presentation ](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation)類別的實例。 
2. 透過索引取得投影片的參考。 
3. 透過將圖像加入與簡報物件關聯的 [IImagescollection](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iimagecollection) 中，建立 [IPPImage](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ippimage) 物件，以填充形狀。 
4. 指定圖像的寬度與高度。 
5. 透過與參考投影片關聯的 shape 物件所公開的 `AddPictureFrame` 方法，根據圖像的寬度與高度建立 [PictureFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/pictureframe)。 
6. 將圖片框（包含圖片）加入投影片。 
7. 將修改後的簡報寫入為 PPTX 檔案。 

以下 C# 程式碼示範如何建立圖片框：

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// 實例化代表 PPTX 檔案的 Presentation 類別
using (Presentation pres = new Presentation())
{
    // 取得第一張投影片
    ISlide slide = pres.Slides[0];

    // 載入圖像並將其加入簡報的圖像集合
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
圖片框讓您能快速以圖像建立簡報投影片。當您將圖片框與 Aspose.Slides 的儲存選項結合時，即可操作輸入/輸出，以將圖像從一種格式轉換為另一種格式。您可能想參考以下頁面：將 [圖像 轉 JPG](https://products.aspose.com/slides/zh-hant/net/conversion/image-to-jpg/) 轉換；將 [JPG 轉 圖像](https://products.aspose.com/slides/zh-hant/net/conversion/jpg-to-image/) 轉換；將 [JPG 轉 PNG](https://products.aspose.com/slides/zh-hant/net/conversion/jpg-to-png/) 轉換，將 [PNG 轉 JPG](https://products.aspose.com/slides/zh-hant/net/conversion/png-to-jpg/) 轉換；將 [PNG 轉 SVG](https://products.aspose.com/slides/zh-hant/net/conversion/png-to-svg/) 轉換，將 [SVG 轉 PNG](https://products.aspose.com/slides/zh-hant/net/conversion/svg-to-png/) 轉換。 
{{% /alert %}} 

## **建立具有相對縮放的圖片框**

透過調整圖像的相對縮放，您可以建立更複雜的圖片框。 

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation)類別的實例。 
2. 透過索引取得投影片的參考。 
3. 將圖像加入簡報的圖像集合中。 
4. 透過將圖像加入與簡報物件關聯的 [IImagescollection](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iimagecollection) 中，建立 [IPPImage](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ippimage) 物件，以填充形狀。 
5. 指定圖像在圖片框中的相對寬度與高度。 
6. 將修改後的簡報寫入為 PPTX 檔案。 

以下 C# 程式碼示範如何建立具有相對縮放的圖片框：

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// 實例化代表 PPTX 檔案的 Presentation 類別
using (Presentation presentation = new Presentation())
{
    // 載入圖像並將其加入簡報的圖像集合
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

## **從圖片框擷取點陣圖像**

您可以從 [PictureFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/pictureframe) 物件中擷取點陣圖像，並將其儲存為 PNG、JPG 等格式。以下程式碼範例示範如何從文件 "sample.pptx" 中擷取圖像並以 PNG 格式儲存。

```c#
using Aspose.Slides;

using (var presentation = new Presentation("sample.pptx"))
{
    var firstSlide = presentation.Slides[0];
    var firstShape = firstSlide.Shapes[0];

    if (firstShape is IPictureFrame pictureFrame)
    {
        var ppImage = pictureFrame.PictureFormat.Picture.Image;
        ppImage.Image.Save("slide_1_shape_1.png", ImageFormat.Png);
    }
}
```

## **從圖片框擷取 SVG 圖像**

當簡報中包含放置於 [PictureFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/pictureframe/) 形狀內的 SVG 圖形時，Aspose.Slides for .NET 可讓您以完整保真度取得原始向量圖像。透過遍歷投影片的形狀集合，您可以辨識每個 [PictureFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/pictureframe/)，檢查底層的 [IPPImage](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ippimage/) 是否包含 SVG 內容，然後將該圖像以其原生 SVG 格式儲存至磁碟或串流。

以下程式碼範例示範如何從圖片框中擷取 SVG 圖像：

```cs
using Aspose.Slides;

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

## **取得圖像的透明度**

Aspose.Slides 讓您取得套用於圖像的透明度效果。以下 C# 程式碼示範此操作：

```c#
using Aspose.Slides;
using Aspose.Slides.Effects;

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

## **取得圖像的亮度與對比度**

Aspose.Slides 讓您取得套用於圖像的亮度與對比度效果。[ILuminance](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.effects/iluminance/) 介面表示此圖像變換效果。

以下 C# 程式碼示範如何從圖片框取得亮度與對比度設定：

```csharp
using Aspose.Slides;
using Aspose.Slides.Effects;

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

{{% alert color="info" %}} 
所有套用於圖像的效果皆可在 [Aspose.Slides.Effects](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.effects/) 中找到。 
{{% /alert %}}

## **圖片框格式化**

Aspose.Slides 提供許多可套用於圖片框的格式化選項。使用這些選項，您可以調整圖片框以符合特定需求。

1. 建立 [Presentation](http://www.aspose.com/api/net/slides/zh-hant/aspose.slides/) 類別的實例。 
2. 透過索引取得投影片的參考。 
3. 透過將圖像加入與簡報物件關聯的 [IImagescollection](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iimagecollection) 中，建立 [IPPImage](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ippimage) 物件，以填充形狀。 
4. 指定圖像的寬度與高度。 
5. 透過與參考投影片關聯的 [IShapes](http://www.aspose.com/api/net/slides/zh-hant/aspose.slides/ishapecollection) 物件所公開的 [AddPictureFrame](http://www.aspose.com/api/net/slides/zh-hant/aspose.slides/ishapecollection/methods/addpictureframe) 方法，根據圖像的寬度與高度建立 `PictureFrame`。 
6. 將圖片框（包含圖片）加入投影片。 
7. 設定圖片框的線條顏色。 
8. 設定圖片框的線條寬度。 
9. 以正值或負值旋轉圖片框。  
   * 正值會順時針旋轉圖像。  
   * 負值會逆時針旋轉圖像。 
10. 將圖片框（包含圖片）加入投影片。 
11. 將修改後的簡報寫入為 PPTX 檔案。 

以下 C# 程式碼示範圖片框格式化流程：

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// 實例化代表 PPTX 檔案的 Presentation 類別
using (Presentation presentation = new Presentation())
{
    // 取得第一張投影片
    ISlide slide = presentation.Slides[0];

    // 載入圖像並將其加入簡報的圖像集合
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = presentation.Images.AddImage(image);
    image.Dispose();

    // 新增具有圖像相同高度與寬度的圖片框
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

{{% alert color="info" %}} 
Aspose 最近開發了免費的 [Collage Maker](https://products.aspose.app/slides/zh-hant/collage)。如果您需要 [合併 JPG/JPEG](https://products.aspose.app/slides/zh-hant/collage/jpg) 或 PNG 圖像、[從相片建立格子](https://products.aspose.app/slides/zh-hant/collage/photo-grid)，可以使用此服務。 
{{% /alert %}}

## **將圖像作為連結加入**

為了減少簡報檔大小，您可以透過連結加入圖像（或影片），而非直接將檔案嵌入簡報。以下 C# 程式碼示範如何將圖像與影片加入佔位符：

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

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

## **裁剪圖像**

以下 C# 程式碼示範如何裁剪投影片上現有的圖像：

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    // 建立新的影像物件
    IImage image = Images.FromFile("aspose-logo.jpg");
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

## **刪除圖片框的裁剪區域**

如果您想刪除框中圖像的裁剪區域，可以使用 [IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) 方法。若不需要裁剪，該方法會傳回原始圖像。

以下 C# 程式碼示範此操作：

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("PictureFrameCrop.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // 取得第一張投影片上的 PictureFrame
    IPictureFrame picFrame = slide.Shapes[0] as IPictureFrame;

    // 刪除 PictureFrame 圖像的裁剪區域並回傳裁剪後的圖像
    IPPImage croppedImage = picFrame.PictureFormat.DeletePictureCroppedAreas();

    // 儲存結果
    presentation.Save("PictureFrameDeleteCroppedAreas.pptx", SaveFormat.Pptx);
}
```

{{% alert title="NOTE" color="warning" %}} 
[IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) 方法會將裁剪後的圖像加入簡報的圖像集合。若該圖像僅用於已處理的 [PictureFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/pictureframe/)，此設定可減少簡報大小；否則，最終簡報中的圖像數量會增加。 

此方法會在裁剪操作中將 WMF/EMF 中繪圖檔轉換為點陣 PNG 圖像。 
{{% /alert %}}

## **壓縮圖像**

您可以使用 [IPictureFillFormat.CompressImage](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ipicturefillformat/compressimage/) 方法壓縮簡報中的圖片。此方法會根據形狀大小與指定的解析度縮減圖像大小，並可選擇刪除裁剪區域。 

它的運作方式類似 PowerPoint 的 **圖片格式 → 壓縮圖片 → 解析度** 功能。

以下 C# 範例示範如何透過指定目標解析度並選擇性移除裁剪區域來壓縮簡報中的圖像：

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("demo.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IPictureFrame pictureFrame = slide.Shapes[0] as IPictureFrame;

    // 以目標解析度 150 DPI（網頁解析度）壓縮圖像，並移除裁剪區域。
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
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("demo.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IPictureFrame pictureFrame = slide.Shapes[0] as IPictureFrame;

    // 壓縮圖像至 150 DPI（網頁解析度），同時移除裁剪區域。
    pictureFrame.PictureFormat.CompressImage(true, 150f);

    presentation.Save("CompressedImage.pptx", SaveFormat.Pptx);
}
```

{{% alert title="NOTE" color="warning" %}} 
此方法會根據形狀大小與提供的 DPI 降低圖像解析度。亦可刪除裁剪區域以優化檔案大小。  
若圖像為 WMF/EMF 或 SVG 中繪圖檔，則不會套用壓縮。JPEG 的品質亦會依解析度稍微降低，與 PowerPoint 處理高解析度 JPEG 的方式相同。 
{{% /alert %}}

## **鎖定長寬比**

若您希望包含圖像的形狀在變更圖像尺寸後仍保持長寬比，可使用 [IPictureFrameLock.AspectRatioLocked](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ipictureframelock/aspectratiolocked/) 屬性設定 *鎖定長寬比*。 

以下 C# 程式碼示範如何鎖定形狀的長寬比：

```c#
using Aspose.Slides;

using (Presentation pres = new Presentation("pres.pptx"))
{
    ILayoutSlide layout = pres.LayoutSlides.GetByType(SlideLayoutType.Custom);
    ISlide emptySlide = pres.Slides.AddEmptySlide(layout);

    IImage image = Images.FromFile("image.png");
    IPPImage presImage = pres.Images.AddImage(image);
    image.Dispose();

    IPictureFrame pictureFrame = emptySlide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, presImage.Width, presImage.Height, presImage);

    // 設定形狀在調整大小時保持長寬比
    pictureFrame.PictureFrameLock.AspectRatioLocked = true;
}
```

{{% alert title="NOTE" color="warning" %}} 
此 *鎖定長寬比* 設定僅保留形狀本身的長寬比，而非其內含圖像。 
{{% /alert %}}

## **使用 StretchOff 屬性**

使用 [IPictureFillFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ipicturefillformat) 介面及 [PictureFillFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/picturefillformat) 類別的 [StretchOffsetLeft](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/picturefillformat/properties/stretchoffsetleft)、[StretchOffsetTop](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/picturefillformat/properties/stretchoffsettop)、[StretchOffsetRight](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/picturefillformat/properties/stretchoffsetright) 與 [StretchOffsetBottom](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/picturefillformat/properties/stretchoffsetbottom) 屬性，您可以指定填充矩形。 

當為圖像指定拉伸時，來源矩形會依比例縮放以符合指定的填充矩形。填充矩形的每個邊緣皆以相對於形狀邊界盒對應邊緣的百分比偏移定義。正值表示內縮，負值表示外延。

1. 建立 [Presentation](http://www.aspose.com/api/net/slides/zh-hant/aspose.slides/) 類別的實例。 
2. 透過索引取得投影片的參考。 
3. 新增矩形 `AutoShape`。 
4. 建立圖像。 
5. 設定形狀的填充類型。 
6. 設定形狀的圖片填充模式。 
7. 新增設定好的圖像以填充形狀。 
8. 指定圖像相對於形狀邊界盒對應邊緣的偏移量。 
9. 將修改後的簡報寫入為 PPTX 檔案。 

以下 C# 程式碼示範使用 StretchOff 屬性的流程：

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    IPictureFrame pictureFrame = pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 400, 400, ppImage);

    // 設定圖像在形狀內部從四側拉伸
    pictureFrame.PictureFormat.PictureFillMode = PictureFillMode.Stretch;
    pictureFrame.PictureFormat.StretchOffsetLeft = 24;
    pictureFrame.PictureFormat.StretchOffsetRight = 24;
    pictureFrame.PictureFormat.StretchOffsetTop = 24;
    pictureFrame.PictureFormat.StretchOffsetBottom = 24;

    pres.Save("imageStretch.pptx", SaveFormat.Pptx);
}
```

## **常見問題**

### 如何查詢 PictureFrame 支援的圖像格式？

Aspose.Slides 透過指派給 [PictureFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/pictureframe/) 的圖像物件，同時支援點陣圖像（PNG、JPEG、BMP、GIF 等）與向量圖像（如 SVG）。支援的格式清單通常與投影片與圖像轉換引擎的功能相互重疊。

### 在 PPTX 中加入大量大圖像會如何影響檔案大小與效能？

嵌入大型圖像會增加檔案大小與記憶體使用量；使用連結方式加入圖像可減少簡報大小，但需要確保外部檔案仍可存取。Aspose.Slides 提供以連結方式加入圖像的功能，以降低檔案尺寸。

### 如何防止圖像物件被意外移動/調整大小？

可對 [PictureFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/pictureframe/) 使用 [shape locks](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/pictureframe/pictureframelock/)（例如停用移動或調整大小）。鎖定機制於保護文章中另行說明，支援包括 [PictureFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/pictureframe/) 在內的各種形狀類型。

### 在將簡報匯出為 PDF/圖像時，SVG 向量的完整性是否得以保留？

Aspose.Slides 允許從 [PictureFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/pictureframe/) 中提取原始 SVG 向量。匯出為 PDF 或點陣格式時，結果可能會根據匯出設定被光柵化；然而，提取行為證明原始 SVG 仍以向量形式存儲。
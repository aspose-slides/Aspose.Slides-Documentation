---
title: 管理 .NET 簡報背景
linktitle: 投影片背景
type: docs
weight: 20
url: /zh-hant/net/presentation-background/
keywords:
- 簡報背景
- 投影片背景
- 純色
- 漸層色
- 影像背景
- 背景透明度
- 背景屬性
- PowerPoint
- OpenDocument
- 簡報
- .NET
- C#
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for .NET 在 PowerPoint 和 OpenDocument 檔案中設定動態背景，並提供程式碼技巧以提升您的簡報效果。"
---
## **簡介**

純色、漸層與影像常用於投影片背景。您可以為 **普通投影片**（單一投影片）或 **母版投影片**（同時套用於多張投影片）設定背景。

![PowerPoint 背景](powerpoint-background.png)

## **為普通投影片設定純色背景**

Aspose.Slides 允許您在簡報中為特定投影片設定純色背景，即使簡報使用母版投影片。變更僅套用於所選投影片。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/) 類別的實例。
2. 將投影片的 [BackgroundType](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/backgroundtype/) 設為 `OwnBackground`。
3. 將投影片背景的 [FillType](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/filltype/) 設為 `Solid`。
4. 使用 [FillFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/fillformat/) 上的 [SolidFillColor](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/fillformat/solidfillcolor/) 屬性來指定純色背景顏色。
5. 儲存已修改的簡報。

以下 C# 範例說明如何將藍色純色設定為普通投影片的背景：

```cs
// 建立 Presentation 類別的實例。
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // 將投影片的背景顏色設定為藍色。
    slide.Background.Type = BackgroundType.OwnBackground;
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Blue;

    // 將簡報儲存至磁碟。
    presentation.Save("SolidColorBackground.pptx", SaveFormat.Pptx);
}
```

## **為母版投影片設定純色背景**

Aspose.Slides 允許您在簡報的母版投影片上設定純色背景。母版投影片作為控制所有投影片格式的範本，因此當您為母版投影片的背景選擇純色時，會套用至每一張投影片。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/) 類別的實例。
2. 將母版投影片的 [BackgroundType](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/backgroundtype/)（透過 `masters`）設為 `OwnBackground`。
3. 將母版投影片背景的 [FillType](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/filltype/) 設為 `Solid`。
4. 使用 [SolidFillColor](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/fillformat/solidfillcolor/) 來指定純色背景顏色。
5. 儲存已修改的簡報。

以下 C# 範例說明如何將純色（森林綠）設定為母版投影片的背景：

```cs
// 建立 Presentation 類別的實例。
using (Presentation presentation = new Presentation())
{
    IMasterSlide masterSlide = presentation.Masters[0];

    // 將母版投影片的背景顏色設定為森林綠。
    masterSlide.Background.Type = BackgroundType.OwnBackground;
    masterSlide.Background.FillFormat.FillType = FillType.Solid;
    masterSlide.Background.FillFormat.SolidFillColor.Color = Color.ForestGreen;

    // 將簡報儲存至磁碟。
    presentation.Save("MasterSlideBackground.pptx", SaveFormat.Pptx);
}
```

## **為投影片設定漸層背景**

漸層是透過顏色逐漸變化而產生的圖形效果。作為投影片背景時，漸層能讓簡報看起來更具藝術感與專業感。Aspose.Slides 允許您將漸層色設定為投影片的背景。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/) 類別的實例。
2. 將投影片的 [BackgroundType](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/backgroundtype/) 設為 `OwnBackground`。
3. 將投影片背景的 [FillType](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/filltype/) 設為 `Gradient`。
4. 使用 [FillFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/fillformat/) 上的 [GradientFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/fillformat/gradientformat/) 屬性來配置您偏好的漸層設定。
5. 儲存已修改的簡報。

以下 C# 範例說明如何將漸層色設定為投影片的背景：

```cs
// 建立 Presentation 類別的實例。
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // 對背景套用漸層效果。
    slide.Background.Type = BackgroundType.OwnBackground;
    slide.Background.FillFormat.FillType = FillType.Gradient;
    slide.Background.FillFormat.GradientFormat.TileFlip = TileFlip.FlipBoth;

    // 將簡報儲存至磁碟。
    presentation.Save("GradientBackground.pptx", SaveFormat.Pptx);
}
```

## **將影像設定為投影片背景**

除了純色與漸層填色外，Aspose.Slides 也允許您使用影像作為投影片背景。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/) 類別的實例。
2. 將投影片的 [BackgroundType](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/backgroundtype/) 設為 `OwnBackground`。
3. 將投影片背景的 [FillType](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/filltype/) 設為 `Picture`。
4. 載入您想作為投影片背景的影像。
5. 將影像加入簡報的影像集合。
6. 使用 [FillFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/fillformat/) 上的 [PictureFillFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/fillformat/picturefillformat/) 屬性將影像指定為背景。
7. 儲存已修改的簡報。

以下 C# 範例說明如何將影像設定為投影片的背景：

```c#
 // 建立 Presentation 類別的實例。
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // 設定背景影像屬性。
    slide.Background.Type = BackgroundType.OwnBackground;
    slide.Background.FillFormat.FillType = FillType.Picture;
    slide.Background.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;

    // 載入影像。
    IImage image = Images.FromFile("Tulips.jpg");
    // 將影像加入簡報的影像集合。
    IPPImage ppImage = presentation.Images.AddImage(image);
    image.Dispose();

    slide.Background.FillFormat.PictureFillFormat.Picture.Image = ppImage;

    // 將簡報儲存至磁碟。
    presentation.Save("ImageAsBackground.pptx", SaveFormat.Pptx);
}
```

以下程式碼範例說明如何將背景填充類型設定為平鋪圖片並修改平鋪屬性：

```cs
using (Presentation presentation = new Presentation())
{
    ISlide firstSlide = presentation.Slides[0];

    IBackground background = firstSlide.Background;

    background.Type = BackgroundType.OwnBackground;
    background.FillFormat.FillType = FillType.Picture;

    IPPImage ppImage;
    using (IImage newImage = Aspose.Slides.Images.FromFile("image.png"))
        ppImage = presentation.Images.AddImage(newImage);

    // 設定用於背景填充的影像。
    IPictureFillFormat backPictureFillFormat = background.FillFormat.PictureFillFormat;
    backPictureFillFormat.Picture.Image = ppImage;

    // 將圖片填充模式設定為平鋪並調整平鋪屬性。
    backPictureFillFormat.PictureFillMode = PictureFillMode.Tile;
    backPictureFillFormat.TileOffsetX = 15f;
    backPictureFillFormat.TileOffsetY = 15f;
    backPictureFillFormat.TileScaleX = 46f;
    backPictureFillFormat.TileScaleY = 87f;
    backPictureFillFormat.TileAlignment = RectangleAlignment.Center;
    backPictureFillFormat.TileFlip = TileFlip.FlipY;

    presentation.Save("TileBackground.pptx", SaveFormat.Pptx);
}
```

{{% alert color="primary" %}}
閱讀更多： [**平鋪圖片作為紋理**](/slides/zh-hant/net/shape-formatting/#tile-picture-as-texture)
{{% /alert %}}

### **變更背景影像透明度**

您可能想調整投影片背景影像的透明度，以突顯投影片內容。以下 C# 程式碼說明如何變更投影片背景影像的透明度：

```cs
var transparencyValue = 30; // 例如。

// Get the collection of picture transform operations.
var imageTransform = slide.Background.FillFormat.PictureFillFormat.Picture.ImageTransform;

// Find an existing fixed-percentage transparency effect.
var transparencyOperation = null as IAlphaModulateFixed;
foreach (var operation in imageTransform)
{
    if (operation is IAlphaModulateFixed alphaModulateFixed)
    {
        transparencyOperation = alphaModulateFixed;
        break;
    }
}

// Set the new transparency value.
if (transparencyOperation == null)
{
    imageTransform.AddAlphaModulateFixedEffect(100 - transparencyValue);
}
else
{
    transparencyOperation.Amount = (100 - transparencyValue);
}
```

## **取得投影片背景值**

Aspose.Slides 提供 [IBackgroundEffectiveData](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ibackgroundeffectivedata/) 介面以取得投影片的實際背景值。此介面可取得實際的 [FillFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ibackgroundeffectivedata/fillformat/) 與 [EffectFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ibackgroundeffectivedata/effectformat/)。

使用 [BaseSlide](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/baseslide/) 類別的 `background` 屬性，您可以取得投影片的實際背景。

以下 C# 範例說明如何取得投影片的實際背景值：

```cs
// 建立 Presentation 類別的實例。
using (Presentation presentation = new Presentation("Sample.pptx"))
{
    ISlide slide = presentation.Slides[0];  

    // 取得有效的背景，同時考慮母版、版面配置與主題。
    IBackgroundEffectiveData effBackground = slide.Background.GetEffective();

    if (effBackground.FillFormat.FillType == FillType.Solid)
        Console.WriteLine("Fill color: " + effBackground.FillFormat.SolidFillColor);
    else
        Console.WriteLine("Fill type: " + effBackground.FillFormat.FillType);
}
```

## **常見問題**

**我能重設自訂背景並恢復佈景主題/版面配置的背景嗎？**

是。移除投影片的自訂填色，背景將再次從相應的 [layout](/slides/zh-hant/net/slide-layout/)/[master](/slides/zh-hant/net/slide-master/) 投影片（即 [theme background](/slides/zh-hant/net/presentation-theme/)）繼承。

**如果我之後變更簡報的佈景主題，背景會發生什麼變化？**

如果投影片有自己的填色，則不會改變。若背景是從 [layout](/slides/zh-hant/net/slide-layout/)/[master](/slides/zh-hant/net/slide-master/) 繼承的，則會更新以符合 [new theme](/slides/zh-hant/net/presentation-theme/)。
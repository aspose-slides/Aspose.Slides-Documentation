---
title: 在 .NET 中管理簡報背景
linktitle: 投影片背景
type: docs
weight: 20
url: /zh-hant/net/presentation-background/
keywords:
- 簡報背景
- 投影片背景
- 純色
- 漸層色
- 圖片背景
- 背景透明度
- 背景屬性
- PowerPoint
- OpenDocument
- 簡報
- .NET
- C#
- Aspose.Slides
description: "學習如何使用 Aspose.Slides for .NET 在 PowerPoint 和 OpenDocument 檔案中設定動態背景，並透過程式碼技巧提升您的簡報效果。"
---
## **簡介**

純色、漸層與圖片是投影片背景的常見使用方式。您可以為 **普通投影片**（單張投影片）或 **母片投影片**（一次套用多張投影片）設定背景。

![PowerPoint background](powerpoint-background.png)

## **為普通投影片設定純色背景**

Aspose.Slides 允許您為簡報中的特定投影片設定純色背景，即使簡報使用了母片。此變更僅套用於所選投影片。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/) 類別的實例。
2. 將投影片的 [BackgroundType](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/backgroundtype/) 設為 `OwnBackground`。
3. 將投影片背景的 [FillType](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/filltype/) 設為 `Solid`。
4. 使用 [FillFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/fillformat/) 上的 [SolidFillColor](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/fillformat/solidfillcolor/) 屬性來指定純色背景顏色。
5. 儲存已修改的簡報。

下面的 C# 範例示範如何將藍色純色設為普通投影片的背景：

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

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

## **為母片投影片設定純色背景**

Aspose.Slides 允許您為簡報的母片投影片設定純色背景。母片投影片作為模板，控制所有投影片的格式，因此為母片的背景選擇純色時，會套用到每一張投影片。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/) 類別的實例。
2. 透過 `masters` 將母片投影片的 [BackgroundType](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/backgroundtype/) 設為 `OwnBackground`。
3. 將母片投影片背景的 [FillType](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/filltype/) 設為 `Solid`。
4. 使用 [SolidFillColor](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/fillformat/solidfillcolor/) 來指定純色背景顏色。
5. 儲存已修改的簡報。

下面的 C# 範例示範如何將森林綠設定為母片投影片的純色背景：

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// 建立 Presentation 類別的實例。
using (Presentation presentation = new Presentation())
{
    IMasterSlide masterSlide = presentation.Masters[0];

    // 將母片投影片的背景顏色設定為森林綠。
    masterSlide.Background.Type = BackgroundType.OwnBackground;
    masterSlide.Background.FillFormat.FillType = FillType.Solid;
    masterSlide.Background.FillFormat.SolidFillColor.Color = Color.ForestGreen;

    // 將簡報儲存至磁碟。
    presentation.Save("MasterSlideBackground.pptx", SaveFormat.Pptx);
}
```

## **為投影片設定漸層背景**

漸層是一種透過顏色逐漸變化所產生的圖形效果。作為投影片背景時，漸層能讓簡報看起來更具藝術感與專業感。Aspose.Slides 允許您為投影片設定漸層顏色背景。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/) 類別的實例。
2. 將投影片的 [BackgroundType](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/backgroundtype/) 設為 `OwnBackground`。
3. 將投影片背景的 [FillType](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/filltype/) 設為 `Gradient`。
4. 使用 [FillFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/fillformat/) 上的 [GradientFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/fillformat/gradientformat/) 屬性來配置您偏好的漸層設定。
5. 儲存已修改的簡報。

下面的 C# 範例示範如何將漸層顏色設為投影片的背景：

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// 建立 Presentation 類別的實例。
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // 套用漸層效果至背景。
    slide.Background.Type = BackgroundType.OwnBackground;
    slide.Background.FillFormat.FillType = FillType.Gradient;
    slide.Background.FillFormat.GradientFormat.TileFlip = TileFlip.FlipBoth;

    // 將簡報儲存至磁碟。
    presentation.Save("GradientBackground.pptx", SaveFormat.Pptx);
}
```

## **將圖片設定為投影片背景**

除了純色與漸層填充外，Aspose.Slides 也允許您使用圖片作為投影片背景。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/) 類別的實例。
2. 將投影片的 [BackgroundType](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/backgroundtype/) 設為 `OwnBackground`。
3. 將投影片背景的 [FillType](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/filltype/) 設為 `Picture`。
4. 載入您想作為投影片背景的圖片。
5. 將圖片加入簡報的圖片集合。
6. 使用 [FillFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/fillformat/) 上的 [PictureFillFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/fillformat/picturefillformat/) 屬性將圖片指定為背景。
7. 儲存已修改的簡報。

下面的 C# 範例示範如何將圖片設定為投影片的背景：

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// 建立 Presentation 類別的實例。
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // 設定背景圖片屬性。
    slide.Background.Type = BackgroundType.OwnBackground;
    slide.Background.FillFormat.FillType = FillType.Picture;
    slide.Background.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;

    // 載入圖片。
    IImage image = Images.FromFile("Tulips.jpg");
    // 將圖片加入簡報的圖片集合。
    IPPImage ppImage = presentation.Images.AddImage(image);
    image.Dispose();

    slide.Background.FillFormat.PictureFillFormat.Picture.Image = ppImage;

    // 將簡報儲存至磁碟。
    presentation.Save("ImageAsBackground.pptx", SaveFormat.Pptx);
}
```

下面的程式碼範例示範如何將背景填充類型設定為平鋪圖片並修改平鋪屬性：

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    ISlide firstSlide = presentation.Slides[0];

    IBackground background = firstSlide.Background;

    background.Type = BackgroundType.OwnBackground;
    background.FillFormat.FillType = FillType.Picture;

    IPPImage ppImage;
    using (IImage newImage = Aspose.Slides.Images.FromFile("image.png"))
        ppImage = presentation.Images.AddImage(newImage);

    // 設定背景填充使用的圖片。
    IPictureFillFormat backPictureFillFormat = background.FillFormat.PictureFillFormat;
    backPictureFillFormat.Picture.Image = ppImage;

    // 將圖片填充模式設定為平鋪，並調整平鋪屬性。
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

{{% alert color="info" %}}

閱讀更多： [**Tile Picture As Texture**](/slides/zh-hant/net/shape-formatting/#tile-picture-as-texture)。

{{% /alert %}}

### **變更背景圖片透明度**

您可能想調整投影片背景圖片的透明度，以突顯投影片內容。以下 C# 程式碼示範如何變更投影片背景圖片的透明度：

```cs
using Aspose.Slides;
using Aspose.Slides.Effects;
using Aspose.Slides.Export;

var transparencyValue = 30; // 例如。

using (Presentation presentation = new Presentation("ImageAsBackground.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // 取得圖片變換操作的集合。
    var imageTransform = slide.Background.FillFormat.PictureFillFormat.Picture.ImageTransform;

    // 尋找現有的固定百分比透明度效果。
    var transparencyOperation = null as IAlphaModulateFixed;
    foreach (var operation in imageTransform)
    {
        if (operation is IAlphaModulateFixed alphaModulateFixed)
        {
            transparencyOperation = alphaModulateFixed;
            break;
        }
    }

    // 設定新的透明度值。
    if (transparencyOperation == null)
    {
        imageTransform.AddAlphaModulateFixedEffect(100 - transparencyValue);
    }
    else
    {
        transparencyOperation.Amount = (100 - transparencyValue);
    }

    presentation.Save("ImageBackgroundTransparency.pptx", SaveFormat.Pptx);
}
```

## **取得投影片背景值**

Aspose.Slides 提供 [IBackgroundEffectiveData](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ibackgroundeffectivedata/) 介面，用於取得投影片的實際背景值。此介面揭露實際的 [FillFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ibackgroundeffectivedata/fillformat/) 和 [EffectFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ibackgroundeffectivedata/effectformat/)。

透過 [BaseSlide](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/baseslide/) 類別的 `background` 屬性，您可以取得投影片的實際背景。

下面的 C# 範例示範如何取得投影片的實際背景值：

```cs
using Aspose.Slides;

// 建立 Presentation 類別的實例。
using (Presentation presentation = new Presentation("Sample.pptx"))
{
    ISlide slide = presentation.Slides[0];  

    // 取得實際背景，會考慮母片、版面配置與主題。
    IBackgroundEffectiveData effBackground = slide.Background.GetEffective();

    if (effBackground.FillFormat.FillType == FillType.Solid)
        Console.WriteLine("Fill color: " + effBackground.FillFormat.SolidFillColor);
    else
        Console.WriteLine("Fill type: " + effBackground.FillFormat.FillType);
}
```

## **常見問題**

### 我可以重設自訂背景並恢復佈景主題/版面配置的背景嗎？

可以。移除投影片的自訂填充後，背景會再次從對應的 [layout](/slides/zh-hant/net/slide-layout/)/[master](/slides/zh-hant/net/slide-master/) 投影片（即 [theme background](/slides/zh-hant/net/presentation-theme/)）繼承。

### 若稍後更改簡報的佈景主題，背景會發生什麼變化？

如果投影片已設定自己的填充，則不會變動。若背景是從 [layout](/slides/zh-hant/net/slide-layout/)/[master](/slides/zh-hant/net/slide-master/) 繼承的，則會隨新佈景主題更新。
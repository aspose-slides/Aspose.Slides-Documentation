---
title: 管理 Android 上的簡報背景
linktitle: 投影片背景
type: docs
weight: 20
url: /zh-hant/androidjava/presentation-background/
keywords:
- 簡報背景
- 投影片背景
- 純色
- 漸層顏色
- 影像背景
- 背景透明度
- 背景屬性
- PowerPoint
- OpenDocument
- 簡報
- Android
- Java
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Android 透過 Java 在 PowerPoint 與 OpenDocument 檔案中設定動態背景，並提供程式碼技巧提升您的簡報效果。"
---
## **介紹**

實色、漸層和影像通常用於投影片背景。您可以為 **普通投影片**（單一投影片）或 **母版投影片**（一次套用到多張投影片）設定背景。

![PowerPoint 背景](powerpoint-background.png)

## **為普通投影片設定實色背景**

Aspose.Slides 允許您為簡報中的特定投影片設定實色背景，即使簡報使用了母版投影片。此變更僅套用於所選投影片。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/) 類別的執行個體。
2. 將投影片的 [BackgroundType](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/backgroundtype/) 設定為 `OwnBackground`。
3. 將投影片背景的 [FillType](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/filltype/) 設定為 `Solid`。
4. 使用 [FillFormat](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/fillformat/) 上的 [getSolidFillColor](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/fillformat/#getSolidFillColor--) 方法指定實色背景顏色。
5. 保存已修改的簡報。

以下 Java 範例說明如何將藍色實色設定為普通投影片的背景：

```java
// 建立 Presentation 類別的實例。
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // 設定投影片的背景顏色為藍色。
    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    
    // 將簡報儲存至磁碟。
    presentation.save("SolidColorBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **為母版投影片設定實色背景**

Aspose.Slides 允許您為簡報的母版投影片設定實色背景。母版投影片作為控制所有投影片格式的範本，當您為母版投影片的背景選擇實色時，會套用至每一張投影片。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/) 類別的執行個體。
2. 透過 `getMasters` 取得母版投影片，並將其 [BackgroundType](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/backgroundtype/) 設定為 `OwnBackground`。
3. 將母版投影片背景的 [FillType](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/filltype/) 設定為 `Solid`。
4. 使用 [getSolidFillColor](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/fillformat/#getSolidFillColor--) 方法指定實色背景顏色。
5. 保存已修改的簡報。

以下 Java 範例說明如何將綠色實色設定為母版投影片的背景：

```java
// 建立 Presentation 類別的實例。
Presentation presentation = new Presentation();
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

    // 將母版投影片的背景顏色設定為森林綠。
    masterSlide.getBackground().setType(BackgroundType.OwnBackground);
    masterSlide.getBackground().getFillFormat().setFillType(FillType.Solid);
    masterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.GREEN);

    // 將簡報儲存至磁碟。
    presentation.save("MasterSlideBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **為投影片設定漸層背景**

漸層是一種透過顏色逐漸變化產生的圖形效果。作為投影片背景時，漸層可使簡報更具藝術感與專業感。Aspose.Slides 允許您將漸層色設定為投影片的背景。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/) 類別的執行個體。
2. 將投影片的 [BackgroundType](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/backgroundtype/) 設定為 `OwnBackground`。
3. 將投影片背景的 [FillType](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/filltype/) 設定為 `Gradient`。
4. 使用 [FillFormat](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/fillformat/) 上的 [getGradientFormat](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/fillformat/#getGradientFormat--) 方法設定您偏好的漸層參數。
5. 保存已修改的簡報。

以下 Java 範例說明如何將漸層色設定為投影片的背景：

```java
// 建立 Presentation 類別的實例。
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    
    // 將漸層效果套用到背景。
    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Gradient);
    slide.getBackground().getFillFormat().getGradientFormat().setTileFlip(TileFlip.FlipBoth);

    // 將簡報儲存至磁碟。
    presentation.save("GradientBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **將影像設定為投影片背景**

除了實色與漸層外，Aspose.Slides 亦支援使用影像作為投影片背景。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/) 類別的執行個體。
2. 將投影片的 [BackgroundType](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/backgroundtype/) 設定為 `OwnBackground`。
3. 將投影片背景的 [FillType](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/filltype/) 設定為 `Picture`。
4. 載入您想作為投影片背景的影像。
5. 將影像加入簡報的影像集合中。
6. 使用 [FillFormat](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/fillformat/) 上的 [getPictureFillFormat](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/fillformat/#getPictureFillFormat--) 方法將影像指派為背景。
7. 保存已修改的簡報。

以下 Java 範例說明如何將影像設定為投影片的背景：

```java
// 建立 Presentation 類別的實例。
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // 設定背景影像屬性。
    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Picture);
    slide.getBackground().getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
    
    // 載入影像。
    IImage image = Images.fromFile("Tulips.jpg");
    // 將影像加入簡報的影像集合。
    IPPImage ppImage = presentation.getImages().addImage(image);
    image.dispose();

    slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().setImage(ppImage);
    
    // 將簡報儲存至磁碟。
    presentation.save("ImageAsBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

以下程式碼範例示範如何將背景填充類型設為平鋪圖案，並調整平鋪屬性：

```java
Presentation presentation = new Presentation();
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    IBackground background = firstSlide.getBackground();

    background.setType(BackgroundType.OwnBackground);
    background.getFillFormat().setFillType(FillType.Picture);

    IImage newImage = Images.fromFile("image.png");
    IPPImage ppImage = presentation.getImages().addImage(newImage);
    newImage.dispose();

    // 設定用於背景填充的影像。
    IPictureFillFormat backPictureFillFormat = background.getFillFormat().getPictureFillFormat();
    backPictureFillFormat.getPicture().setImage(ppImage);

    // 將圖案填充模式設為平鋪，並調整平鋪屬性。
    backPictureFillFormat.setPictureFillMode(PictureFillMode.Tile);
    backPictureFillFormat.setTileOffsetX(15f);
    backPictureFillFormat.setTileOffsetY(15f);
    backPictureFillFormat.setTileScaleX(46f);
    backPictureFillFormat.setTileScaleY(87f);
    backPictureFillFormat.setTileAlignment(RectangleAlignment.Center);
    backPictureFillFormat.setTileFlip(TileFlip.FlipY);

    presentation.save("TileBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert color="primary" %}}
閱讀更多：[**Tile Picture As Texture**](/slides/zh-hant/androidjava/shape-formatting/#tile-picture-as-texture)。
{{% /alert %}}

### **變更背景影像透明度**

您可能需要調整投影片背景影像的透明度，以突顯投影片內容。下列 Java 程式碼示範如何變更投影片背景影像的透明度：

```java
int transparencyValue = 30; // 例如。

// Get the collection of picture transform operations.
IImageTransformOperationCollection imageTransform = slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().getImageTransform();

// Find an existing fixed-percentage transparency effect.
IAlphaModulateFixed transparencyOperation = null;
for (IImageTransformOperation operation : imageTransform) {
    if (operation instanceof IAlphaModulateFixed) {
        transparencyOperation = (IAlphaModulateFixed)operation;
        break;
    }
}

// Set the new transparency value.
if (transparencyOperation == null) {
    imageTransform.addAlphaModulateFixedEffect(100 - transparencyValue);
}
else {
    transparencyOperation.setAmount(100 - transparencyValue);
}
```

## **取得投影片背景值**

Aspose.Slides 提供 [IBackgroundEffectiveData](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ibackgroundeffectivedata/) 介面，用於擷取投影片的實際背景值。此介面會公開實際的 [FillFormat](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ibackgroundeffectivedata/#getFillFormat--) 和 [EffectFormat](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ibackgroundeffectivedata/#getEffectFormat--)。

使用 [BaseSlide](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/baseslide/) 類別的 `getBackground` 方法，即可取得投影片的實際背景。

以下 Java 範例說明如何取得投影片的實際背景值：

```java
// 建立 Presentation 類別的實例。
Presentation presentation = new Presentation("Sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // 取得有效的背景，考慮母版、版面配置與主題。
    IBackgroundEffectiveData effBackground = slide.getBackground().getEffective();
    
    if (effBackground.getFillFormat().getFillType() == FillType.Solid)
        System.out.println("Fill color: " + effBackground.getFillFormat().getSolidFillColor());
    else
        System.out.println("Fill type: " + effBackground.getFillFormat().getFillType());
} finally {
    presentation.dispose();
}
```

## **常見問題**

**我可以重設自訂背景並還原主題/版面配置的背景嗎？**

是的。移除投影片的自訂填充後，背景會重新繼承自對應的 [layout](/slides/zh-hant/androidjava/slide-layout/)/[master](/slides/zh-hant/androidjava/slide-master/) 投影片（即 [theme background](/slides/zh-hant/androidjava/presentation-theme/)）。

**如果稍後變更簡報的主題，背景會怎樣？**

若投影片已自行設定填充，則不會變更。若背景是從 [layout](/slides/zh-hant/androidjava/slide-layout/)/[master](/slides/zh-hant/androidjava/slide-master/) 繼承的，則會隨新的主題更新。
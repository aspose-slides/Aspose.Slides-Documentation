---
title: 管理 JavaScript 中的簡報背景
linktitle: 投影片背景
type: docs
weight: 20
url: /zh-hant/nodejs-java/presentation-background/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Node.js 為 PowerPoint 與 OpenDocument 檔案設定動態背景，並透過程式碼技巧提升您的簡報效果。"
---
## **簡介**

純色、漸層與影像常被用作投影片背景。您可以為 **普通投影片**（單一投影片）或 **母片投影片**（同時套用於多張投影片）設定背景。

![PowerPoint 背景](powerpoint-background.png)

## **為普通投影片設定純色背景**

Aspose.Slides 允許您為簡報中的特定投影片設定純色背景，即使簡報使用了母片。此變更僅套用於所選投影片。

1. 建立一個 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/) 類別的實例。
2. 將投影片的 [BackgroundType](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/backgroundtype/) 設為 `OwnBackground`。
3. 將投影片背景的 [FillType](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/filltype/) 設為 `Solid`。
4. 使用 [FillFormat](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/fillformat/) 上的 [getSolidFillColor](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/fillformat/#getSolidFillColor--) 方法指定純色背景顏色。
5. 儲存已修改的簡報。

以下 JavaScript 範例示範如何將藍色純色設定為普通投影片的背景：

```js
// 建立 Presentation 類別的實例。
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    // 將投影片的背景顏色設定為藍色。
    slide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    
    // 將簡報儲存至磁碟。
    presentation.save("SolidColorBackground.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **為母片投影片設定純色背景**

Aspose.Slides 允許您為簡報的母片投影片設定純色背景。母片投影片作為範本，控制所有投影片的格式，因此當您為母片背景選擇純色時，會套用至每張投影片。

1. 建立一個 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/) 類別的實例。
2. 透過 `getMasters` 取得母片投影片，將其 [BackgroundType](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/backgroundtype/) 設為 `OwnBackground`。
3. 將母片投影片背景的 [FillType](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/filltype/) 設為 `Solid`。
4. 使用 [getSolidFillColor](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/fillformat/#getSolidFillColor--) 方法指定純色背景顏色。
5. 儲存已修改的簡報。

以下 JavaScript 範例示範如何將綠色純色設定為母片投影片的背景：

```js
// 建立 Presentation 類別的實例。
let presentation = new aspose.slides.Presentation();
try {
    let masterSlide = presentation.getMasters().get_Item(0);

    // 將母片投影片的背景顏色設定為森林綠。
    masterSlide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));
    masterSlide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    masterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GREEN"));

    // 將簡報儲存至磁碟。
    presentation.save("MasterSlideBackground.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **為投影片設定漸層背景**

漸層是一種透過顏色逐漸變化產生的圖形效果。將漸層用作投影片背景，可使簡報更具藝術性與專業感。Aspose.Slides 允許您為投影片設定漸層顏色作為背景。

1. 建立一個 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/) 類別的實例。
2. 將投影片的 [BackgroundType](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/backgroundtype/) 設為 `OwnBackground`。
3. 將投影片背景的 [FillType](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/filltype/) 設為 `Gradient`。
4. 使用 [FillFormat](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/fillformat/) 上的 [getGradientFormat](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/fillformat/#getGradientFormat) 方法設定您想要的漸層屬性。
5. 儲存已修改的簡報。

以下 JavaScript 範例示範如何將漸層顏色設定為投影片的背景：

```js
// 建立 Presentation 類別的實例。
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    //    將漸層效果套用到背景。
    slide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));
    slide.getBackground().getFillFormat().getGradientFormat().setTileFlip(aspose.slides.TileFlip.FlipBoth);

    //    將簡報儲存至磁碟。
    presentation.save("GradientBackground.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **將影像設為投影片背景**

除了純色與漸層填色外，Aspose.Slides 亦支援使用影像作為投影片背景。

1. 建立一個 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/) 類別的實例。
2. 將投影片的 [BackgroundType](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/backgroundtype/) 設為 `OwnBackground`。
3. 將投影片背景的 [FillType](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/filltype/) 設為 `Picture`。
4. 載入您想用作背景的影像。
5. 將影像加入簡報的 ImageCollection。
6. 使用 [FillFormat](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/fillformat/) 上的 [getPictureFillFormat](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/fillformat/#getPictureFillFormat) 方法將影像指定為背景。
7. 儲存已修改的簡報。

以下 JavaScript 範例示範如何將影像設定為投影片的背景：

```js
// 建立 Presentation 類別的實例。
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    // 設定背景影像屬性。
    slide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
    slide.getBackground().getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);

    // 載入影像。
    let image = aspose.slides.Images.fromFile("Tulips.jpg");
    // 將影像加入簡報的影像集合。
    let ppImage = presentation.getImages().addImage(image);
    image.dispose();

    slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().setImage(ppImage);
    
    // 將簡報儲存至磁碟。
    presentation.save("ImageAsBackground.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

以下程式碼範例示範如何將背景填色類型設為平鋪圖片，並修改平鋪屬性：

```js
let presentation = new aspose.slides.Presentation();
try {
    let firstSlide = presentation.getSlides().get_Item(0);

    let background = firstSlide.getBackground();

    background.setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));
    background.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));

    let newImage = aspose.slides.Images.fromFile("image.png");
    let ppImage = presentation.getImages().addImage(newImage);
    newImage.dispose();

    // 設定用於背景填充的影像。
    let backPictureFillFormat = background.getFillFormat().getPictureFillFormat();
    backPictureFillFormat.getPicture().setImage(ppImage);

    // 將圖片填充模式設為平鋪，並調整平鋪屬性。
    backPictureFillFormat.setPictureFillMode(aspose.slides.PictureFillMode.Tile);
    backPictureFillFormat.setTileOffsetX(15.0);
    backPictureFillFormat.setTileOffsetY(15.0);
    backPictureFillFormat.setTileScaleX(46.0);
    backPictureFillFormat.setTileScaleY(87.0);
    backPictureFillFormat.setTileAlignment(java.newByte(aspose.slides.RectangleAlignment.Center));
    backPictureFillFormat.setTileFlip(aspose.slides.TileFlip.FlipY);

    presentation.save("TileBackground.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert color="primary" %}}

閱讀更多：[**平鋪圖片作為紋理**](/slides/zh-hant/nodejs-java/shape-formatting/#tile-picture-as-texture)。

{{% /alert %}}

### **變更背景影像透明度**

您可能想調整投影片背景影像的透明度，以使投影片內容更為突出。以下 JavaScript 程式碼示範如何變更投影片背景影像的透明度：

```js
var transparencyValue = 30; // 例如。

// 取得圖片轉換操作的集合。
var imageTransform = slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().getImageTransform();

// 尋找現有的固定百分比透明度效果。
var transparencyOperation = null;
for (let i = 0; i < imageTransform.size(); i++) {
    let operation = imageTransform.get_Item(i);
    if (java.instanceOf(operation, "com.aspose.slides.AlphaModulateFixed")) {
        transparencyOperation = operation;
        break;
    }
}

// 設定新的透明度值。
if (transparencyOperation == null) {
    imageTransform.addAlphaModulateFixedEffect(100 - transparencyValue);
} else {
    transparencyOperation.setAmount(100 - transparencyValue);
}
```

## **取得投影片背景值**

Aspose.Slides 提供 `BackgroundEffectiveData` 類別，用於取得投影片的實際背景值。此類別會公開實際的 [FillFormat](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/fillformat/) 與 [EffectFormat](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/effectformat/)。

使用 [BaseSlide](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/baseslide/) 類別的 `getBackground` 方法，即可取得投影片的實際背景。

以下 JavaScript 範例示範如何取得投影片的實際背景值：

```js
// 建立 Presentation 類別的實例。
let presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);

    // 取得實際背景，考慮母片、版面配置與佈景主題。
    let effBackground = slide.getBackground().getEffective();

    if (effBackground.getFillFormat().getFillType() == aspose.slides.FillType.Solid)
        console.log("Fill color:", effBackground.getFillFormat().getSolidFillColor().toString());
    else
        console.log("Fill type:", effBackground.getFillFormat().getFillType());
} finally {
    presentation.dispose();
}
```

## **常見問題**

**是否可以重設自訂背景，並恢復佈景主題/版面配置的背景？**

可以。移除投影片的自訂填色後，背景會再次從相應的 [layout](/slides/zh-hant/nodejs-java/slide-layout/)/[master](/slides/zh-hant/nodejs-java/slide-master/) 投影片（即 [theme background](/slides/zh-hant/nodejs-java/presentation-theme/)）繼承。

**如果之後更改簡報的佈景主題，背景會發生什麼變化？**

若投影片已有自己的填色，則保持不變。若背景是從 [layout](/slides/zh-hant/nodejs-java/slide-layout/)/[master](/slides/zh-hant/nodejs-java/slide-master/) 繼承的，則會依新佈景主題自動更新。
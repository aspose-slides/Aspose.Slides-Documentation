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
- 圖片背景
- 背景透明度
- 背景屬性
- PowerPoint
- OpenDocument
- 簡報
- Android
- Java
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Android 透過 Java 為 PowerPoint 與 OpenDocument 檔案設定動態背景，並提供程式碼技巧以提升您的簡報效果。"
---
## **簡介**

實色、漸層和圖片通常用於投影片的背景。您可以為 **普通投影片**（單一投影片）或 **母片投影片**（一次套用至多張投影片）設定背景。

![PowerPoint 背景](powerpoint-background.png)

## **為普通投影片設定實色背景**

Aspose.Slides 允許您為簡報中的特定投影片設定實色作為背景——即使簡報使用母片。此變更僅套用於所選投影片。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/) 類別的實例。
2. 將投影片的 [BackgroundType](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/backgroundtype/) 設為 `OwnBackground`。
3. 將投影片背景的 [FillType](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/filltype/) 設為 `Solid`。
4. 使用 [FillFormat](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/fillformat/) 上的 [getSolidFillColor](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/fillformat/#getSolidFillColor--) 方法指定實色背景顏色。
5. 儲存已修改的簡報。

以下 Java 範例示範如何將藍色實色設定為普通投影片的背景：

```java
import com.aspose.slides.*;
import java.awt.Color;

// 建立 Presentation 類別的實例。
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // 將投影片的背景顏色設定為藍色。
    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    
    // 將簡報儲存至磁碟。
    presentation.save("SolidColorBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **為母片投影片設定實色背景**

Aspose.Slides 允許您為簡報中的母片投影片設定實色作為背景。母片充當控制所有投影片格式的範本，當您為母片的背景選擇實色時，會套用至每一張投影片。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/) 類別的實例。
2. 將母片的 [BackgroundType](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/backgroundtype/)（透過 `getMasters`）設定為 `OwnBackground`。
3. 將母片背景的 [FillType](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/filltype/) 設為 `Solid`。
4. 使用 [FillFormat](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/fillformat/) 上的 [getSolidFillColor](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/fillformat/#getSolidFillColor--) 方法指定實色背景顏色。
5. 儲存已修改的簡報。

以下 Java 範例示範如何將綠色實色設定為母片投影片的背景：

```java
import com.aspose.slides.*;
import java.awt.Color;

// 建立 Presentation 類別的實例。
Presentation presentation = new Presentation();
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

    // 將母片投影片的背景顏色設定為綠色。
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

漸層是透過顏色逐漸變化所產生的圖形效果。作為投影片背景時，漸層可以讓簡報看起來更具藝術感與專業度。Aspose.Slides 允許您將漸層顏色設定為投影片的背景。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/) 類別的實例。
2. 將投影片的 [BackgroundType](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/backgroundtype/) 設為 `OwnBackground`。
3. 將投影片背景的 [FillType](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/filltype/) 設為 `Gradient`。
4. 使用 [FillFormat](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/fillformat/) 上的 [getGradientFormat](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/fillformat/#getGradientFormat--) 方法配置您偏好的漸層設定。
5. 儲存已修改的簡報。

以下 Java 範例示範如何將漸層顏色設定為投影片的背景：

```java
import com.aspose.slides.*;
import java.awt.Color;

// 建立 Presentation 類別的實例。
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    
    // 套用漸層效果至背景。
    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Gradient);

    IGradientFormat gradientFormat = slide.getBackground().getFillFormat().getGradientFormat();
    gradientFormat.setTileFlip(TileFlip.FlipBoth);

    // 加入漸層顏色。若沒有漸層停止點，背景會回退為預設的黑白漸層。
    gradientFormat.getGradientStops().add(0f, Color.CYAN);
    gradientFormat.getGradientStops().add(1f, Color.BLUE);

    // 將簡報儲存至磁碟。
    presentation.save("GradientBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **將圖片設為投影片背景**

除了實色與漸層填充外，Aspose.Slides 還允許您使用圖片作為投影片背景。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/) 類別的實例。
2. 將投影片的 [BackgroundType](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/backgroundtype/) 設為 `OwnBackground`。
3. 將投影片背景的 [FillType](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/filltype/) 設為 `Picture`。
4. 載入您想作為投影片背景的圖片。
5. 將圖片加入簡報的圖片集合中。
6. 使用 [FillFormat](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/fillformat/) 上的 [getPictureFillFormat](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/fillformat/#getPictureFillFormat--) 方法將圖片指定為背景。
7. 儲存已修改的簡報。

以下 Java 範例示範如何將圖片設定為投影片的背景：

```java
import com.aspose.slides.*;

// 建立 Presentation 類別的實例。
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // 設定背景圖片屬性。
    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Picture);
    slide.getBackground().getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
    
    // 載入圖片。
    IImage image = Images.fromFile("Tulips.jpg");
    // 將圖片加入簡報的圖片集合。
    IPPImage ppImage = presentation.getImages().addImage(image);
    image.dispose();

    slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().setImage(ppImage);
    
    // 將簡報儲存至磁碟。
    presentation.save("ImageAsBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

以下程式碼範例示範如何將背景填充類型設定為平鋪圖片，並修改平鋪屬性：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    IBackground background = firstSlide.getBackground();

    background.setType(BackgroundType.OwnBackground);
    background.getFillFormat().setFillType(FillType.Picture);

    IImage newImage = Images.fromFile("image.png");
    IPPImage ppImage = presentation.getImages().addImage(newImage);
    newImage.dispose();

    // 設定用於背景填充的圖片。
    IPictureFillFormat backPictureFillFormat = background.getFillFormat().getPictureFillFormat();
    backPictureFillFormat.getPicture().setImage(ppImage);

    // 將圖片填充模式設定為平鋪，並調整平鋪屬性。
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

{{% alert color="info" %}}
閱讀更多： [**平鋪圖片作為紋理**](/slides/zh-hant/androidjava/shape-formatting/#tile-picture-as-texture)。
{{% /alert %}}

### **變更背景圖片透明度**

您可能想調整投影片背景圖片的透明度，以突顯投影片內容。以下 Java 程式碼示範如何變更投影片背景圖片的透明度：

```java
import com.aspose.slides.*;

int transparencyValue = 30; // 例如。

Presentation presentation = new Presentation("Sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // 取得圖片變換操作的集合。
    IImageTransformOperationCollection imageTransform = slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().getImageTransform();

    // 尋找已存在的固定百分比透明度效果。
    IAlphaModulateFixed transparencyOperation = null;
    for (IImageTransformOperation operation : imageTransform) {
        if (operation instanceof IAlphaModulateFixed) {
            transparencyOperation = (IAlphaModulateFixed)operation;
            break;
        }
    }

    // 設定新的透明度值。
    if (transparencyOperation == null) {
        imageTransform.addAlphaModulateFixedEffect(100 - transparencyValue);
    }
    else {
        transparencyOperation.setAmount(100 - transparencyValue);
    }

    presentation.save("TransparentBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **取得投影片背景值**

Aspose.Slides 提供 [IBackgroundEffectiveData](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ibackgroundeffectivedata/) 介面，用於取得投影片的有效背景值。此介面公開有效的 [FillFormat](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ibackgroundeffectivedata/#getFillFormat--) 和 [EffectFormat](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ibackgroundeffectivedata/#getEffectFormat--)。

使用 [BaseSlide](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/baseslide/) 類別的 `getBackground` 方法，您可以取得投影片的有效背景。

以下 Java 範例示範如何取得投影片的有效背景值：

```java
import com.aspose.slides.*;

// 建立 Presentation 類別的實例。
Presentation presentation = new Presentation("Sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // 取得有效的背景，考慮母片、版面配置與主題。
    IBackgroundEffectiveData effBackground = slide.getBackground().getEffective();
    
    if (effBackground.getFillFormat().getFillType() == FillType.Solid)
        System.out.println("Fill color: " + effBackground.getFillFormat().getSolidFillColor());
    else
        System.out.println("Fill type: " + effBackground.getFillFormat().getFillType());
} finally {
    presentation.dispose();
}
```

## **FAQ**

### **我可以重設自訂背景並恢復佈景主題/版面配置背景嗎？**

可以。移除投影片的自訂填充，即可再次從相應的 [layout](/slides/zh-hant/androidjava/slide-layout/)/[master](/slides/zh-hant/androidjava/slide-master/) 投影片（即 [theme background](/slides/zh-hant/androidjava/presentation-theme/)）繼承背景。

### **如果之後變更簡報的佈景主題，背景會發生什麼變化？**

如果投影片已擁有自己的填充，則不會改變。若背景是從 [layout](/slides/zh-hant/androidjava/slide-layout/)/[master](/slides/zh-hant/androidjava/slide-master/) 繼承的，則會依新主題更新。
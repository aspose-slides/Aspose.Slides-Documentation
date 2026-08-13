---
title: 在 Java 中管理簡報背景
linktitle: 投影片背景
type: docs
weight: 20
url: /zh-hant/java/presentation-background/
keywords:
- 簡報背景
- 投影片背景
- 純色
- 漸層顏色
- 圖像背景
- 背景透明度
- 背景屬性
- PowerPoint
- OpenDocument
- 簡報
- Java
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Java 為 PowerPoint 和 OpenDocument 檔案設定動態背景，並提供程式碼技巧以提升您的簡報。"
---
## **簡介**

實色顏色、漸層與影像常被用於投影片背景。您可以為 **普通投影片**（單一投影片）或 **母片**（同時套用至多張投影片）設定背景。

![PowerPoint background](powerpoint-background.png)

## **為普通投影片設定實色背景**

Aspose.Slides 允許您為簡報中的特定投影片設定實色背景──即使該簡報使用母片。此變更僅套用於所選投影片。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/) 類別的實例。
2. 將投影片的 [BackgroundType](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/backgroundtype/) 設為 `OwnBackground`。
3. 將投影片背景的 [FillType](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/filltype/) 設為 `Solid`。
4. 使用 [FillFormat](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/fillformat/) 上的 [getSolidFillColor](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/fillformat/#getSolidFillColor--) 方法來指定實色背景顏色。
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

## **為母片設定實色背景**

Aspose.Slides 允許您為簡報的母片設定實色背景。母片作為控制所有投影片格式的模板，因此當您為母片背景選擇實色時，會套用至每張投影片。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/) 類別的實例。
2. 透過 `getMasters`，將母片的 [BackgroundType](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/backgroundtype/) 設為 `OwnBackground`。
3. 將母片背景的 [FillType](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/filltype/) 設為 `Solid`。
4. 使用 [FillFormat](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/fillformat/) 上的 [getSolidFillColor](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/fillformat/#getSolidFillColor--) 方法來指定實色背景顏色。
5. 儲存已修改的簡報。

以下 Java 範例示範如何將綠色實色設定為母片的背景：

```java
import com.aspose.slides.*;
import java.awt.Color;

// 建立 Presentation 類別的實例。
Presentation presentation = new Presentation();
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

    // 將母片的背景顏色設定為綠色。
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

漸層是透過顏色逐漸變化所產生的圖形效果。作為投影片背景時，漸層能讓簡報更具藝術感與專業感。Aspose.Slides 允許您將漸層顏色設定為投影片的背景。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/) 類別的實例。
2. 將投影片的 [BackgroundType](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/backgroundtype/) 設為 `OwnBackground`。
3. 將投影片背景的 [FillType](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/filltype/) 設為 `Gradient`。
4. 使用 [FillFormat](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/fillformat/) 上的 [getGradientFormat](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/fillformat/#getGradientFormat--) 方法來設定喜好的漸層參數。
5. 儲存已修改的簡報。

以下 Java 範例示範如何將漸層顏色設定為投影片的背景：

```java
import com.aspose.slides.*;
import java.awt.Color;

// 建立 Presentation 類別的實例。
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    
    // 對背景套用漸層效果。
    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Gradient);

    IGradientFormat gradientFormat = slide.getBackground().getFillFormat().getGradientFormat();
    gradientFormat.setTileFlip(TileFlip.FlipBoth);

    // 新增漸層顏色。若未設定漸層停止點，背景會退回為預設的黑白漸層。
    gradientFormat.getGradientStops().add(0f, Color.CYAN);
    gradientFormat.getGradientStops().add(1f, Color.BLUE);

    // 將簡報儲存至磁碟。
    presentation.save("GradientBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **將影像設定為投影片背景**

除了實色與漸層填充外，Aspose.Slides 也允許您使用影像作為投影片背景。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/) 類別的實例。
2. 將投影片的 [BackgroundType](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/backgroundtype/) 設為 `OwnBackground`。
3. 將投影片背景的 [FillType](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/filltype/) 設為 `Picture`。
4. 載入您想用作投影片背景的影像。
5. 將影像加入簡報的影像集合中。
6. 使用 [FillFormat](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/fillformat/) 上的 [getPictureFillFormat](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/fillformat/#getPictureFillFormat--) 方法將影像指派為背景。
7. 儲存已修改的簡報。

以下 Java 範例示範如何將影像設定為投影片的背景：

```java
import com.aspose.slides.*;

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

    // 設定用於背景填充的影像。
    IPictureFillFormat backPictureFillFormat = background.getFillFormat().getPictureFillFormat();
    backPictureFillFormat.getPicture().setImage(ppImage);

    // 設定圖片填充模式為平鋪並調整平鋪屬性。
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
閱讀更多：[**Tile Picture As Texture**](/slides/zh-hant/java/shape-formatting/#tile-picture-as-texture)。
{{% /alert %}}

### **變更背景影像透明度**

您可能希望調整投影片背景影像的透明度，以突顯投影片內容。以下 Java 程式碼示範如何變更投影片背景影像的透明度：

```java
import com.aspose.slides.*;

int transparencyValue = 30; // 例如。

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // 取得圖片轉換操作的集合。
    IImageTransformOperationCollection imageTransform = slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().getImageTransform();

    // 找到現有的固定百分比透明度效果。
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

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **取得投影片背景值**

Aspose.Slides 提供 [IBackgroundEffectiveData](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ibackgroundeffectivedata/) 介面，以取得投影片的有效背景值。此介面會公開有效的 [FillFormat](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ibackgroundeffectivedata/#getFillFormat--) 與 [EffectFormat](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ibackgroundeffectivedata/#getEffectFormat--)。

使用 [BaseSlide](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/baseslide/) 類別的 `getBackground` 方法，即可取得投影片的有效背景。

以下 Java 範例示範如何取得投影片的有效背景值：

```java
import com.aspose.slides.*;

// 建立 Presentation 類別的實例。
Presentation presentation = new Presentation("Sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // 取得有效的背景，考慮母片、版面配置與佈景主題。
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

### 我可以重設自訂背景並還原佈景主題/版面配置背景嗎？

是的。移除投影片的自訂填充，背景將會再次從相應的 [layout](/slides/zh-hant/java/slide-layout/)/[master](/slides/zh-hant/java/slide-master/) 投影片（即 [theme background](/slides/zh-hant/java/presentation-theme/)）繼承。

### 如果稍後變更簡報的佈景主題，背景會怎樣？

如果投影片已有自己的填充，則不會改變。如果背景是從 [layout](/slides/zh-hant/java/slide-layout/)/[master](/slides/zh-hant/java/slide-master/) 繼承，則會依新佈景主題而更新。
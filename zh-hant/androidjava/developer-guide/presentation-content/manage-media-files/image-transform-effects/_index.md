---
title: 在 Android 上管理簡報中的圖像變換效果
linktitle: 圖像變換效果
type: docs
weight: 11
url: /zh-hant/androidjava/image-transform-effects/
keywords:
- 圖像變換
- 圖片效果
- 亮度
- 對比度
- 灰階
- 雙調
- 色調
- HSL
- 色彩取代
- 模糊
- 透明度
- Alpha 效果
- 效果鏈
- PowerPoint
- 簡報
- Android
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Android（Java 版）套用、串接、檢查、移除並驗證圖片框的圖像變換效果。"
---
## **概述**

Aspose.Slides 將圖片調整表示為有序的圖像變換操作集合。對於圖片框，從框架的 [ISlidesPicture](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidespicture/) 開始，並存取 [ISlidesPicture.getImageTransform](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidespicture/#getImageTransform--)。返回的 [IImageTransformOperationCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/) 允許您附加、列舉、檢查、移除及清除效果，而無需重新寫入原始圖像位元組。

本文示範了亮度與對比度、顏色轉換、模糊、透明度、有序效果鏈、有效值、移除以及 PPTX 回圈驗證的完整工作流程。

## **了解效果擁有權與圖像重複使用**

一個圖像資源與顯示它的圖片是不同的物件：

- [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ippimage/) 儲存或參照由簡報擁有的來源圖像資料。
- [ISlidesPicture](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidespicture/) 屬於圖片填充，參照圖像資源，同時儲存圖像變換集合。
- [IPictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframe/) 是簡報形狀，擁有相關的圖片填充、幾何、裁切設定以及其他框架層級的格式設定。

因此，圖像變換操作不會修改 [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ippimage/) 中的位元組。當同一個 `IPPImage` 多次傳遞給 [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) 時，每個新圖片框都會取得自己的 `ISlidesPicture` 與自己的變換集合。對一個框套用灰階不會讓其他框變灰，即使它們共用相同的嵌入圖像資源。

相同的 `ISlidesPicture.getImageTransform` 模型亦用於其他圖片填充，例如形狀或投影片背景。以下範例聚焦於圖片框。

## **使用有效的參數範圍與單位**

示範的方法使用以下語意範圍與單位。即使特定程式庫版本未立即拒絕所有超出範圍的值，仍請將值限制在此範圍內；目標簡報格式可能會在儲存或 PowerPoint 開啟檔案時正規化、忽略或拒絕無效資料。

| 操作 | 參數 | 有效範圍與單位 |
|---|---|---|
| [addBrightnessContrastEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addBrightnessContrastEffect-float-float-) | `brightness`, `contrast` | `-100` 到 `100`，百分比；`0` 使元件保持不變。 |
| [addGrayScaleEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addGrayScaleEffect--) | 無 | 無數值參數。Alpha 保持不變。 |
| [addDuotoneEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addDuotoneEffect--) | `color1`, `color2` | 提供兩個顏色分別對應深色與淺色像素。`android.graphics.Color` 使用的 RGB 與 alpha 通道值範圍為 `0` 到 `255`。 |
| [addTintEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addTintEffect-float-float-) | `hue`, `amount` | 色相 (`hue`) 介於 `0`（含）至 `360`（不含），單位為度；Amount 為 `-100` 到 `100`，百分比。 |
| [addHSLEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addHSLEffect-float-float-float-) | `hue`, `saturation`, `luminance` | 色相 (`hue`) 介於 `0`（含）至 `360`（不含），單位為度；飽和度與亮度為 `-100` 到 `100`，百分比。 |
| [addColorReplaceEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addColorReplaceEffect--) | `color` | 替換顏色的通道值範圍為 `0` 到 `255`。現有的 alpha 值保持不變。 |
| [addBlurEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addBlurEffect-double-boolean-) | `radius`, `grow` | 半徑為非負值，單位為點（points）；`grow` 為布林值，控制模糊內容是否可延伸超出原始邊界。 |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaModulateFixedEffect-float-) | `amount` | 非負百分比。使用 `0` 到 `100` 進行一般的不透明度縮放：`0` 為完全透明，`100` 保留現有 alpha。 |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaReplaceEffect-float-) | `alpha` | `0` 到 `100`，百分比不透明度。 |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaBiLevelEffect-float-) | `threshold` | `0` 到 `100`，百分比 alpha 閾值。低於此值的像素變為透明，等於或高於此值的像素變為不透明。 |

對於固定的 alpha 調變，透明度與不透明度是互補的。例如，35% 透明度對應的 alpha 調變量為 65%。

## **套用亮度與對比度**

[IImageTransformOperationCollection.addBrightnessContrastEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addBrightnessContrastEffect-float-float-) 會回傳一個 [IBrightnessContrast](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibrightnesscontrast/) 操作。其純量設定在建立操作時即提供。[BrightnessContrast.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/brightnesscontrast/#getEffective--) 會回傳計算後的唯讀值，可供檢查或記錄。

以下範例將亮度提升 15%，對比度提升 20%，然後在不修改嵌入圖像的情況下呈現預覽：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }
    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 400, 260, image);

    IImageTransformOperationCollection imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
    IBrightnessContrast brightnessContrast = imageTransform.addBrightnessContrastEffect(15f, 20f);

    IBrightnessContrastEffectiveData effectiveValues = brightnessContrast.getEffective();
    System.out.println("Brightness: " + effectiveValues.getBrightness() + "%");
    System.out.println("Contrast: " + effectiveValues.getContrast() + "%");

    IImage preview = slide.getImage();
    try {
        preview.save("brightness-contrast-preview.png", ImageFormat.Png);
    } finally {
        preview.dispose();
    }
} finally {
    presentation.dispose();
}
```

[BrightnessContrast](https://reference.aspose.com/slides/androidjava/com.aspose.slides/brightnesscontrast/) 為 Office 2010 圖片效果擴充，較標準 DrawingML 亮度效果的可移植性差。當亮度與對比度必須在 PPTX 回圈後仍保持可編輯時，請使用 [IImageTransformOperationCollection.addLuminanceEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addLuminanceEffect-float-float-)，並在重新開啟檔案後驗證結果。格式限制章節會更詳細說明此差異。

## **套用顏色轉換**

顏色效果可以獨立套用於重複使用同一圖像資源的不同圖片框。以下範例建立五個框，分別套用灰階、雙調、色調、HSL 調整與顏色取代。

[IDuotone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iduotone/) 包含兩個可獨立編輯的顏色參數：`color1` 映射暗像素，`color2` 映射亮像素。這使其成為一個設定比單一純量更複雜的效果範例。

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    IPictureFrame grayFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 180, 120, image);
    grayFrame.getPictureFormat().getPicture().getImageTransform().addGrayScaleEffect();

    IPictureFrame duotoneFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 220, 20, 180, 120, image);
    IDuotone duotone = duotoneFrame.getPictureFormat().getPicture().getImageTransform().addDuotoneEffect();
    duotone.getColor1().setColor(Color.rgb(0, 0, 128));
    duotone.getColor2().setColor(Color.rgb(255, 215, 0));

    IPictureFrame tintFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 420, 20, 180, 120, image);
    tintFrame.getPictureFormat().getPicture().getImageTransform().addTintEffect(210f, 35f);

    IPictureFrame hslFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 120, 170, 180, 120, image);
    hslFrame.getPictureFormat().getPicture().getImageTransform().addHSLEffect(30f, 20f, -10f);

    IPictureFrame replacementFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 320, 170, 180, 120, image);
    IColorReplace colorReplacement = replacementFrame.getPictureFormat().getPicture().getImageTransform().addColorReplaceEffect();
    colorReplacement.getColor().setColor(Color.rgb(100, 149, 237));

    presentation.save("color-transformations.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[addColorReplaceEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addColorReplaceEffect--) 會以固定顏色取代每個像素的顏色，同時保留 alpha。它不同於 [addColorChangeEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addColorChangeEffect--)，後者會將一個來源顏色映射到另一個目標顏色，且同時暴露來源與目標顏色的格式。

### **套用亮度閾值**

亮度閾值可以讓掃描頁面的淡淡痕跡更易於與背景區分。[addGrayScaleEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addGrayScaleEffect--) 保留中間的灰階階調。[addBiLevelEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addBiLevelEffect-float-) 將亮度映射為黑或白，而 [addAlphaBiLevelEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaBiLevelEffect-float-) 則對不透明度套用閾值。

亮度閾值範圍為 0% 到 100%，包含兩端。低於閾值的像素變黑；等於或高於閾值的像素變白。提升閾值會使更多階調變黑，因為更多像素落在截斷以下。

下載 [grayscale-swatches.png](grayscale-swatches.png) 至工作目錄。每個標籤顯示 0 到 255 之間的原始灰階等級。範例將原始圖置於兩個副本之旁，並在簡報中儲存每個副本的閾值。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(720, 150, SlideSizeScaleType.DoNotScale);
    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();

    IPPImage image;
    IImage sourceImage = Images.fromFile("grayscale-swatches.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    String[] captions = { "Original", "Threshold 20%", "Threshold 60%" };
    IPictureFrame[] frames = new IPictureFrame[captions.length];
    for (int i = 0; i < captions.length; i++) {
        float x = 12 + 240 * i;
        IAutoShape label = shapes.addAutoShape(ShapeType.Rectangle, x, 12, 216, 36);
        label.getTextFrame().setText(captions[i]);
        frames[i] = shapes.addPictureFrame(ShapeType.Rectangle, x, 60, 216, 72, image);
    }

    frames[1].getPictureFormat().getPicture().getImageTransform().addBiLevelEffect(20f);
    frames[2].getPictureFormat().getPicture().getImageTransform().addBiLevelEffect(60f);

    presentation.save("luminance-threshold.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

在 PowerPoint 中開啟輸出簡報以比較三個框。標示為 96 的樣本大約有 38% 亮度（96 / 255）。在 20% 閾值時會變白，60% 閾值時會變黑。

![原始灰階樣本與亮度閾值 20% 與 60% 下的黑白結果並排](luminance-threshold.png)

## **加入模糊、透明度與 Alpha 效果**

[addBlurEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addBlurEffect-double-boolean-) 會影響所有顏色通道，包括 alpha。當模糊邊緣可能延伸超出原圖範圍時，將 `grow` 設為 `true`。

若需均勻透明度，請使用 [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaModulateFixedEffect-float-)。它會乘以每個已有的 alpha 值，使部分透明像素仍保持比例差異。[addAlphaReplaceEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaReplaceEffect-float-) 則會為所有像素指派單一 alpha 值。[addAlphaBiLevelEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaBiLevelEffect-float-) 會根據閾值將 alpha 轉為兩個等級。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    IPictureFrame blurredFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 200, 140, image);
    IBlur blur = blurredFrame.getPictureFormat().getPicture().getImageTransform().addBlurEffect(4.5, true);
    blur.setRadius(5);

    IPictureFrame transparentFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 240, 20, 200, 140, image);
    IAlphaModulateFixed alphaModulate = transparentFrame.getPictureFormat().getPicture().getImageTransform().addAlphaModulateFixedEffect(65f);
    alphaModulate.setAmount(60f);

    IPictureFrame uniformAlphaFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 180, 200, 140, image);
    uniformAlphaFrame.getPictureFormat().getPicture().getImageTransform().addAlphaReplaceEffect(55f);

    IPictureFrame binaryAlphaFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 240, 180, 200, 140, image);
    IAlphaBiLevel alphaBiLevel = binaryAlphaFrame.getPictureFormat().getPicture().getImageTransform().addAlphaBiLevelEffect(50f);
    alphaBiLevel.setThreshold(45f);
    binaryAlphaFrame.getPictureFormat().getPicture().getImageTransform().addAlphaInverseEffect();

    presentation.save("blur-and-alpha-effects.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

其他無參數的 alpha 操作包括 [addAlphaCeilingEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaCeilingEffect--)（將每個非零 alpha 變為完全不透明）、[addAlphaFloorEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaFloorEffect--)（將低於 100% 的 alpha 變為完全透明）以及 [addAlphaInverseEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaInverseEffect--)（將 alpha 變為 `100% - alpha`）。

## **建立有序的效果鏈**

每個 `add...Effect` 方法皆會將新操作附加至集合的末端。渲染器將集合視為有序管線：第 0 個操作的輸出成為第 1 個操作的輸入，依此類推。因此，以不同順序排列相同操作可能產生不同圖像。

例如，先套用灰階再套用色調會先移除色彩資訊，然後為亮度結果重新著色。相反的順序則會再次移除色調。類似地，alpha 取代可以覆寫先前操作計算的 alpha 值，而 alpha 調變則保留其相對差異。

以下範例建立四個操作的鏈，儲存為 PPTX，重新開啟簡報，檢查操作類型與順序，並呈現重新開啟的結果：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }
    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 400, 260, image);

    IImageTransformOperationCollection imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
    imageTransform.addGrayScaleEffect();
    imageTransform.addTintEffect(220f, 25f);
    imageTransform.addBlurEffect(2.5, false);
    imageTransform.addAlphaModulateFixedEffect(80f);

    presentation.save("image-transform-chain.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

Presentation reopenedPresentation = new Presentation("image-transform-chain.pptx");
try {
    IShape reopenedShape = reopenedPresentation.getSlides().get_Item(0).getShapes().get_Item(0);

    if (reopenedShape instanceof IPictureFrame) {
        IPictureFrame reopenedFrame = (IPictureFrame) reopenedShape;
        IImageTransformOperationCollection reopenedTransform = reopenedFrame.getPictureFormat().getPicture().getImageTransform();
        boolean orderIsPreserved = reopenedTransform.size() == 4 && 
                reopenedTransform.get_Item(0) instanceof IGrayScale && 
                reopenedTransform.get_Item(1) instanceof ITint && 
                reopenedTransform.get_Item(2) instanceof IBlur && 
                reopenedTransform.get_Item(3) instanceof IAlphaModulateFixed;
        System.out.println(orderIsPreserved ? "The effect chain was preserved." : "The effect chain changed during the round trip.");

        IImage renderedSlide = reopenedPresentation.getSlides().get_Item(0).getImage();
        try {
            renderedSlide.save("reopened-effect-chain.png", ImageFormat.Png);
        } finally {
            renderedSlide.dispose();
        }
    } else {
        System.out.println("The reopened shape is not a picture frame.");
    }
} finally {
    reopenedPresentation.dispose();
}
```

此集合不會強制相容性矩陣，將顏色、alpha 與模糊操作限制在不同鏈中。它們可結合使用，但組合未必都有實用性。固定顏色取代會移除先前顏色效果產生的 RGB 變化；在雙調之後套用灰階會移除兩個選定的顏色；而 alpha ceiling、floor、replace 或 bi‑level 操作可能會刪除先前建立的 alpha 細節。請依照期望的像素處理順序建立鏈，而非將其項目視為無序的格式旗標。

<!-- visual-explanation:image-transform-effects:start -->
[![The same image passes through grayscale then tint, and tint then grayscale. The two final grayscale images have different tones.](visual-image-transform-effects-49aa72211f3a.svg)](visual-image-transform-effects-49aa72211f3a.svg)

*In this illustrative Aspose.Slides for .NET 26.11 render, a 220° tint at 25% leaves the grayscale image unchanged. Applying the same tint before grayscale produces different tones.*
<!-- visual-explanation:image-transform-effects:end -->

## **檢查可編輯與有效值**

可編輯的操作是儲存在 `ISlidesPicture.getImageTransform` 中的物件。根據效果不同，可能會直接暴露可寫成員。例如，[IBlur](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iblur/) 暴露可寫的 `radius` 與 `grow`，[IAlphaModulateFixed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ialphamodulatefixed/) 暴露可寫的 `amount`，[IAlphaBiLevel](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ialphabilevel/) 暴露可寫的 `threshold`。像 [IDuotone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iduotone/) 這類顏色效果則會暴露可變的 [IColorFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icolorformat/) 物件。

某些操作介面（包括 [IBrightnessContrast](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibrightnesscontrast/)、[IHSL](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihsl/)、[ITint](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itint/)、[IAlphaReplace](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ialphareplace/)）不會將其建立時的純量以可寫屬性公開。若要變更這些設定，必須先移除該操作，然後在所需位置加入替代操作。

`getEffective()` 回傳的有效資料為計算後的唯讀值。它對於解析主題相關顏色以及讀取渲染器使用的正規化值很有用，但並非另一個編輯介面。以下範例列舉鏈並檢查具備對應 API 的有效值：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("image-transform-chain.pptx");
try {
    IPictureFrame pictureFrame = null;

    for (IShape shape : presentation.getSlides().get_Item(0).getShapes()) {
        if (shape instanceof IPictureFrame) {
            pictureFrame = (IPictureFrame) shape;
            break;
        }
    }

    if (pictureFrame != null) {
        IImageTransformOperationCollection imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();

        for (int index = 0; index < imageTransform.size(); index++) {
            IImageTransformOperation operation = imageTransform.get_Item(index);
            System.out.println(index + ": " + operation.getClass().getSimpleName());

            if (operation instanceof IBrightnessContrast) {
                IBrightnessContrastEffectiveData data = ((IBrightnessContrast) operation).getEffective();
                System.out.println("  Brightness: " + data.getBrightness());
                System.out.println("  Contrast: " + data.getContrast());
            } else if (operation instanceof ILuminance) {
                ILuminanceEffectiveData data = ((ILuminance) operation).getEffective();
                System.out.println("  Brightness: " + data.getBrightness());
                System.out.println("  Contrast: " + data.getContrast());
            } else if (operation instanceof IDuotone) {
                IDuotoneEffectiveData data = ((IDuotone) operation).getEffective();
                System.out.println("  Dark color: " + data.getColor1());
                System.out.println("  Light color: " + data.getColor2());
            } else if (operation instanceof IColorReplace) {
                IColorReplaceEffectiveData data = ((IColorReplace) operation).getEffective();
                System.out.println("  Replacement color: " + data.getColor());
            } else if (operation instanceof IHSL) {
                IHSLEffectiveData data = ((IHSL) operation).getEffective();
                System.out.println("  HSL: " + data.getHue() + ", " + data.getSaturation() + ", " + data.getLuminance());
            } else if (operation instanceof ITint) {
                ITintEffectiveData data = ((ITint) operation).getEffective();
                System.out.println("  Tint: " + data.getHue() + ", " + data.getAmount());
            } else if (operation instanceof IBlur) {
                IBlurEffectiveData data = ((IBlur) operation).getEffective();
                System.out.println("  Blur radius: " + data.getRadius() + " pt");
            } else if (operation instanceof IAlphaModulateFixed) {
                IAlphaModulateFixedEffectiveData data = ((IAlphaModulateFixed) operation).getEffective();
                System.out.println("  Alpha amount: " + data.getAmount() + "%");
            } else if (operation instanceof IAlphaReplace) {
                IAlphaReplaceEffectiveData data = ((IAlphaReplace) operation).getEffective();
                System.out.println("  Replacement alpha: " + data.getAlpha() + "%");
            } else if (operation instanceof IAlphaBiLevel) {
                IAlphaBiLevelEffectiveData data = ((IAlphaBiLevel) operation).getEffective();
                System.out.println("  Alpha threshold: " + data.getThreshold() + "%");
            }
        }
    }
} finally {
    presentation.dispose();
}
```

無參數的效果（例如灰階、alpha ceiling、alpha inverse）仍會有有效資料物件，只是沒有可列印的純量設定。它們在集合中的存在與位置即為重要資訊。

## **移除或清除圖像變換**

使用 [IImageTransformOperationCollection.removeAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#removeAt-int-) 依索引移除單一操作。因為移除後索引會變動，請先搜尋目標再在列舉完成後移除。使用 [ImageTransformOperationCollection.clear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imagetransformoperationcollection/#clear--) 可一次移除整個鏈。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("image-transform-chain.pptx");
try {
    IPictureFrame pictureFrame = null;

    for (IShape shape : presentation.getSlides().get_Item(0).getShapes()) {
        if (shape instanceof IPictureFrame) {
            pictureFrame = (IPictureFrame) shape;
            break;
        }
    }

    if (pictureFrame != null) {
        IImageTransformOperationCollection imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
        int blurIndex = -1;

        for (int index = 0; index < imageTransform.size(); index++) {
            if (imageTransform.get_Item(index) instanceof IBlur) {
                blurIndex = index;
                break;
            }
        }

        if (blurIndex >= 0) {
            imageTransform.removeAt(blurIndex);
            System.out.println("The blur operation was removed.");
        }

        imageTransform.clear();
        System.out.println("Remaining operations: " + imageTransform.size());
        presentation.save("image-transforms-cleared.pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

移除或清除變換僅會改變圖片的格式設定，並不會刪除、重新壓縮或以其他方式改變重複使用的 [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ippimage/) 資源。

## **考慮簡報格式與匯出目標**

圖像變換起源於 DrawingML，因此 PPTX 是效果鏈的首選可編輯格式。即便使用 PPTX，也不是所有操作都有相同的可移植性：

- 標準 DrawingML 操作（如亮度、灰階、雙調、色調、HSL、模糊及一般 alpha 操作）最有機會在 PPTX 回圈後存活。若需保留，請務必重新開啟產生的檔案並檢查集合。
- [BrightnessContrast](https://reference.aspose.com/slides/androidjava/com.aspose.slides/brightnesscontrast/) 為 Office 2010 擴充，而非標準 DrawingML 亮度操作。可用於記憶體內渲染，但無法保證在儲存與重新開啟 PPTX 後仍保留為可編輯的 [IBrightnessContrast](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibrightnesscontrast/)。若需持久的亮度與對比度調整，請偏好使用 [addLuminanceEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addLuminanceEffect-float-float-)。
- 二進位 PPT 格式早於完整的 DrawingML 效果模型。儲存為 PPT 可能會省略不支援的操作、將鏈縮減為支援的子集，或以近似方式呈現外觀。不要將 PPT 用作複雜可編輯鏈的驗證格式。
- 渲染為 PNG、JPEG、TIFF、PDF、SVG、HTML 或其他視覺輸出時，會將支援的鏈套用於最終呈現。這些輸出不包含可編輯的 `IImageTransformOperationCollection`；光柵格式會將結果平鋪成像素，文件/向量匯出則儲存其自己的渲染表示。
- 效果不會使連結圖像變成自包含。渲染連結圖片仍然依賴於簡報載入時連結資源的可用性。

不同的簡報消費端可能會以不同方式處理邊緣案例，特別是同時結合多個 alpha 或顏色量化操作時。對於關鍵輸出，請同時測試可編輯回圈與最終匯出格式，並使用與生產環境相同的 Aspose.Slides 版本。

## **常見問題**

**Do image transform effects modify the embedded image data?**  
**影像變換效果會修改嵌入的圖像資料嗎？**  

No. The operations belong to the `ISlidesPicture` used by the picture fill. The underlying `IPPImage` bytes remain unchanged.  
不會。這些操作屬於圖片填充使用的 `ISlidesPicture`，底層的 `IPPImage` 位元組保持不變。

**Will two picture frames that reuse the same image share their effects?**  
**重複使用相同圖像的兩個圖片框會共享它們的效果嗎？**  

No. Reusing an `IPPImage` avoids duplicate image data, but each picture frame normally has a separate `ISlidesPicture` and image transform collection.  
不會。重複使用 `IPPImage` 可避免圖像資料重複，但每個圖片框通常都有各自的 `ISlidesPicture` 與圖像變換集合。

**Can color, blur, and alpha effects be combined?**  
**顏色、模糊與 alpha 效果可以結合使用嗎？**  

Yes. The collection accepts them in one ordered chain. Consider what each operation does to the output of the previous one because replacement and threshold operations may discard earlier color or alpha detail.  
可以。集合接受它們以單一有序鏈的方式排列。請考慮每個操作對前一個操作輸出的影響，因為取代與閾值操作可能會捨棄較早的顏色或 alpha 細節。

**Why are effective values read-only?**  
**為什麼有效值是唯讀的？**  

Effective data represents calculated values used for rendering, including resolved colors. Edit the operation stored in the transform collection where writable members exist; otherwise remove it and add a replacement with new creation parameters.  
有效資料代表渲染時使用的計算值，包含已解析的顏色。請在變換集合中編輯有可寫成員的操作；若無，則移除該操作並以新參數加入替代操作。

**Which format should I use to preserve a transform chain?**  
**應該使用哪種格式才能保留變換鏈？**  

Use PPTX and verify the file by reopening it. Legacy PPT cannot represent the full DrawingML effect model, and rendered export formats preserve appearance rather than editable transform operations.  
使用 PPTX，並透過重新開啟檔案驗證。舊版 PPT 無法呈現完整的 DrawingML 效果模型，且匯出的視覺格式只保留外觀，而非可編輯的變換操作。
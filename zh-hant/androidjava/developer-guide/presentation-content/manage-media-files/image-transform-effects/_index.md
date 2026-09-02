---
title: 在 Android 上管理簡報中的影像變換效果
linktitle: 影像變換效果
type: docs
weight: 11
url: /zh-hant/androidjava/image-transform-effects/
keywords:
- 影像變換
- 圖片效果
- 亮度
- 對比度
- 灰階
- 雙調
- 色調
- HSL
- 顏色替換
- 模糊
- 透明度
- Alpha 效果
- 效果鏈
- PowerPoint
- 簡報
- Android
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Android（Java）套用、鏈結、檢查、移除並驗證圖片框的影像變換效果。"
---
## **概觀**

Aspose.Slides 將圖片調整表示為有序的影像變換操作集合。對於圖片框，從框的 [ISlidesPicture](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/islidespicture/) 開始，存取 [ISlidesPicture.getImageTransform](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/islidespicture/#getImageTransform--)。回傳的 [IImageTransformOperationCollection](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iimagetransformoperationcollection/) 讓您可以追加、列舉、檢查、移除以及清除效果，而不必重新寫入原始影像位元組。

本文示範了完整的工作流程，包括亮度與對比度、顏色變換、模糊、透明度、有序效果鏈、有效值、移除以及 PPTX 循環驗證。

## **了解效果所有權與影像重複使用**

影像資源與顯示該影像的圖片是不同的物件：

- [IPPImage](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ippimage/) 儲存或參照簡報擁有的來源影像資料。
- [ISlidesPicture](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/islidespicture/) 屬於圖片填色，參照影像資源，同時儲存影像變換集合。
- [IPictureFrame](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ipictureframe/) 為投影片形狀，擁有相關的圖片填色、幾何、裁切設定以及其他框層級格式。

因此，影像變換操作不會修改 [IPPImage](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ippimage/) 中的位元組。當同一個 `IPPImage` 被多次傳遞給 [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) 時，每個新圖片框都會取得自己的 `ISlidesPicture` 與自己的變換集合。對其中一個框套用灰階不會使其他框變成灰階，即使它們共用相同的嵌入式影像資源。

相同的 `ISlidesPicture.getImageTransform` 模型也被其他圖片填色使用，例如形狀或投影片背景。以下範例聚焦於圖片框。

## **使用有效的參數範圍與單位**

示範的方法使用下列語意範圍與單位。即使特定函式庫版本不會立即拒絕每個超出範圍的值，也請維持在這些範圍內；目標簡報格式可能在儲存或 PowerPoint 開啟檔案時正規化、忽略或拒絕無效資料。

| 操作 | 參數 | 有效範圍與單位 |
|---|---|---|
| [addBrightnessContrastEffect](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addBrightnessContrastEffect-float-float-) | `brightness`, `contrast` | `-100` 至 `100`，百分比；`0` 表示保持元件不變。 |
| [addGrayScaleEffect](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addGrayScaleEffect--) | 無 | 無數值參數。Alpha 保持不變。 |
| [addDuotoneEffect](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addDuotoneEffect--) | `color1`, `color2` | 兩個顏色分別對應暗色與亮色像素。`android.graphics.Color` 使用的 RGB 與 alpha 通道值範圍為 `0` 至 `255`。 |
| [addTintEffect](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addTintEffect-float-float-) | `hue`, `amount` | 色相為 `0`（含）至 `360`（未含）度；`amount` 為 `-100` 至 `100`，百分比。 |
| [addHSLEffect](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addHSLEffect-float-float-float-) | `hue`, `saturation`, `luminance` | 色相為 `0`（含）至 `360`（未含）度；飽和度與亮度為 `-100` 至 `100`，百分比。 |
| [addColorReplaceEffect](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addColorReplaceEffect--) | `color` | 替換顏色使用的通道值在 `0` 至 `255` 之間。現有的 alpha 值保持不變。 |
| [addBlurEffect](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addBlurEffect-double-boolean-) | `radius`, `grow` | 半徑為非負數，單位為點（points）；`grow` 為布林值，決定模糊內容是否可延伸至原始邊界之外。 |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaModulateFixedEffect-float-) | `amount` | 非負百分比。使用 `0` 至 `100` 進行普通不透明度縮放：`0` 為完全透明，`100` 保留現有 alpha。 |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaReplaceEffect-float-) | `alpha` | `0` 至 `100`，百分比不透明度。 |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaBiLevelEffect-float-) | `threshold` | `0` 至 `100`，百分比 alpha 閾值。低於閾值的像素變為透明，等於或高於閾值的像素變為不透明。 |

對於固定的 alpha 調變，透明度與不透明度是互補的。例如，35% 的透明度對應 65% 的 alpha 調變量。

## **套用亮度與對比度**

[IImageTransformOperationCollection.addBrightnessContrastEffect](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addBrightnessContrastEffect-float-float-) 會回傳一個 [IBrightnessContrast](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ibrightnesscontrast/) 操作。其純量設定在建立操作時提供。[IBrightnessContrast.getEffective](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ibrightnesscontrast/#getEffective--) 會回傳計算後的唯讀值，可供檢查或記錄。

以下範例將亮度提升 15%，對比度提升 20%，然後產生預覽而不修改嵌入的影像：

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

[BrightnessContrast](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/brightnesscontrast/) 是 Office 2010 的圖片效果延伸，較不具可移植性，若需在 PPTX 循環後仍保持可編輯，請使用 [IImageTransformOperationCollection.addLuminanceEffect](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addLuminanceEffect-float-float-) 並在重新開啟檔案後驗證結果。格式限制章節對此區別有更詳細說明。

## **套用顏色變換**

即使多個圖片框共用同一影像資源，也能獨立套用顏色效果。以下範例建立五個框，分別套用灰階、雙調、色調、HSL 調整與顏色替換。

[IDuotone](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iduotone/) 包含兩個可獨立編輯的顏色參數：`color1` 對應暗像素，`color2` 對應亮像素。這是個顯示設定較為複雜、超過單一純量值的效​​果範例。

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

[addColorReplaceEffect](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addColorReplaceEffect--) 會以固定顏色取代每個像素的顏色，同時保留 alpha。它不同於 [addColorChangeEffect](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addColorChangeEffect--)，後者會將一個來源顏色映射到另一個顏色，且同時公開來源與目標顏色的格式。

## **新增模糊、透明度與 Alpha 效果**

[addBlurEffect](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addBlurEffect-double-boolean-) 會影響所有顏色通道，包括 alpha。當模糊邊緣可能超出原始圖片範圍時，請將 `grow` 設為 `true`。

若需均勻透明度，使用 [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaModulateFixedEffect-float-)。它會將每個既有 alpha 值乘以指定比例，因而保留部分透明像素之間的相對差異。[addAlphaReplaceEffect](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaReplaceEffect-float-) 則會將所有像素的 alpha 設為相同值。[addAlphaBiLevelEffect](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaBiLevelEffect-float-) 會根據閾值將 alpha 轉為兩個層級。

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

其他無參數的 alpha 操作還包括 [addAlphaCeilingEffect](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaCeilingEffect--)（將每個非零 alpha 變為完全不透明）、[addAlphaFloorEffect](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaFloorEffect--)（將低於 100% 的 alpha 變為完全透明）以及 [addAlphaInverseEffect](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaInverseEffect--)（將 alpha 變為 `100% - alpha`）。

## **建立有序的效果鏈**

每個 `add...Effect` 方法都會將新操作附加至集合的末端。渲染器會將集合視為有序的管線：操作 0 的輸出成為操作 1 的輸入，依此類推。因此，以不同順序排列相同操作可能產生不同的影像。

例如，先執行灰階再執行色調會先去除色彩資訊，然後對亮度結果重新著色。若先執行色調再執行灰階，則會再次去除色調。類似地，alpha 替換會覆寫先前操作計算的 alpha 值，而 alpha 調變則保留它們之間的相對差異。

以下範例建立四個操作的鏈，將其儲存為 PPTX，重新開啟簡報，檢查操作類型與順序，並渲染重新開啟的結果：

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

此集合不會強制相容性矩陣，限制顏色、alpha 與模糊操作只能在不同鏈中使用。它們可以組合，但組合未必都有意義。固定的顏色替換會移除先前顏色效果產生的 RGB 變化；在雙調之後再執行灰階會移除兩個選取的顏色；alpha ceiling、floor、replace 或 bi‑level 操作會捨棄先前建立的 alpha 細節。請根據所需的像素處理序列構建鏈，而非將其項目視為無序的格式旗標。

## **檢查可編輯與有效值**

可編輯的操作是儲存在 `ISlidesPicture.getImageTransform` 中的物件。依據效果不同，可能直接公開可寫成員。例如，[IBlur](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iblur/) 會公開可寫的 `radius` 與 `grow`，[IAlphaModulateFixed](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ialphamodulatefixed/) 會公開可寫的 `amount`，[IAlphaBiLevel](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ialphabilevel/) 會公開可寫的 `threshold`。像 [IDuotone](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iduotone/) 這類顏色效果會公開可變的 [IColorFormat](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/icolorformat/) 物件。

某些操作介面（例如 [IBrightnessContrast](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ibrightnesscontrast/)、[IHSL](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ihsl/)、[ITint](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/itint/)、[IAlphaReplace](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ialphareplace/)）不會將建立時的純量公開為可寫屬性。若要變更這些設定，請先移除該操作，再在需要的位置加入替代操作。

`getEffective()` 回傳的有效資料是計算後的唯讀值。它可用於解析主題相依的顏色，並取得渲染器實際使用的正規化值，但不是另一個可編輯的介面。以下範例列舉鏈並在相應的 API 提供時檢查有效值：

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

雖然灰階、alpha ceiling、alpha inverse 等無參數效果仍有有效資料物件，但沒有可列印的純量設定。它們在集合中的存在與位置即為重要資訊。

## **移除或清除影像變換**

使用 [IImageTransformOperationCollection.removeAt](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iimagetransformoperationcollection/#removeAt-int-) 依索引移除單一操作。因為移除後索引會變動，請先搜尋目標再於列舉完畢後移除。使用 [ImageTransformOperationCollection.clear](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/imagetransformoperationcollection/#clear--) 可一次清除整個鏈。

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

移除或清除變換僅會改變圖片的格式設定，並不會刪除、重新壓縮或以其他方式更改重複使用的 [IPPImage](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ippimage/) 資源。

## **考慮簡報格式與輸出目標**

影像變換起源於 DrawingML，故 PPTX 為效果鏈的首選可編輯格式。即使是 PPTX，也不是所有操作都有相同的可移植性：

- 標準 DrawingML 操作（如 luminance、grayscale、duotone、tint、HSL、blur 以及常見的 alpha 操作）最有可能在 PPTX 循環後仍然保留。若有保存需求，請務必重新開啟產生的檔案並檢查集合。
- [BrightnessContrast](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/brightnesscontrast/) 為 Office 2010 的延伸，而非標準 DrawingML luminance 操作。它可用於記憶體內渲染，但無法保證在儲存與重新開啟 PPTX 後仍以可編輯的 [IBrightnessContrast](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ibrightnesscontrast/) 形式存在。請使用 [addLuminanceEffect](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addLuminanceEffect-float-float-) 以取得持久的亮度與對比度調整。
- 舊版 PPT 二進位格式早於完整的 DrawingML 效果模型。儲存為 PPT 可能會省略不支援的操作、將鏈縮減為受支援子集，或以近似方式呈現。不要將 PPT 作為驗證複雜可編輯鏈的格式。
- 輸出為 PNG、JPEG、TIFF、PDF、SVG、HTML 或其他視覺格式時，會將支援的鏈套用至最終渲染結果。這些輸出不會包含可編輯的 `IImageTransformOperationCollection`；點陣格式會把結果鋪平為像素，文件/向量匯出則儲存自己的渲染表示。
- 效果並不會使鏈結的影像變成自包含。渲染鏈結圖片仍然需要在載入簡報時能取得該鏈結資源。

不同的簡報消費端在處理邊緣案例時可能表現不同，特別是同時結合多個 alpha 或顏色量化操作時。對於關鍵輸出，請使用與生產環境相同的 Aspose.Slides 版本，同時測試可編輯的循環與最終匯出格式。

## **常見問題**

**影像變換效果會修改嵌入的影像資料嗎？**

不會。這些操作屬於圖片填色所使用的 `ISlidesPicture`，底層的 `IPPImage` 位元組保持不變。

**重複使用同一影像的兩個圖片框會共享它們的效果嗎？**

不會。重複使用 `IPPImage` 只是避免影像資料重複存儲，但每個圖片框通常都有各自的 `ISlidesPicture` 與影像變換集合。

**顏色、模糊與 alpha 效果可以組合使用嗎？**

可以。集合接受它們在同一有序鏈中。請考慮每個操作對前一步輸出的影響，因為替換與閾值操作可能會捨棄先前的顏色或 alpha 細節。

**為何有效值是唯讀的？**

有效資料代表渲染時使用的計算值，包含已解析的顏色。請在變換集合中編輯具有可寫成員的操作；若無可寫成員，請將該操作移除，並以新的建立參數加入替代操作。

**應使用哪種格式才能保留變換鏈？**

使用 PPTX 並於產生後重新開啟以驗證。舊版 PPT 無法完整表示 DrawingML 效果模型，而視覺匯出格式僅保留外觀，無法保留可編輯的變換操作。
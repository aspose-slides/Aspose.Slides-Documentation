---
title: 使用 Java 管理簡報中的影像變換效果
linktitle: 影像變換效果
type: docs
weight: 11
url: /zh-hant/java/image-transform-effects/
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
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Java 套用、串接、檢查、移除與驗證圖片框的影像變換效果。"
---
## **概觀**

Aspose.Slides 將圖片調整表示為有序的影像變換操作集合。對於圖片框，從框架的 [ISlidesPicture](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/islidespicture/) 開始，並存取 [ISlidesPicture.getImageTransform](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/islidespicture/#getImageTransform--)。返還的 [IImageTransformOperationCollection](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iimagetransformoperationcollection/) 允許您在不重新寫入原始影像位元組的情況下附加、列舉、檢查、移除和清除效果。

本文示範完整的工作流程，包括亮度與對比度、顏色變換、模糊、透明度、有序效果鏈、有效值、移除以及 PPTX 循環驗證。

## **了解效果所有權與影像重用**

影像資源與顯示它的圖片是不同的物件：

- [IPPImage](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ippimage/) 儲存或參照屬於簡報的來源影像資料。
- [ISlidesPicture](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/islidespicture/) 屬於圖片填充，參照影像資源同時儲存影像變換集合。
- [IPictureFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ipictureframe/) 是投影片形狀，擁有相關的圖片填充、幾何、裁切設定以及其他框架層級的格式設定。

因此，影像變換操作不會修改 [IPPImage](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ippimage/) 中的位元組。當同一個 `IPPImage` 多次傳遞給 [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) 時，每個新圖片框都會取得自己的 `ISlidesPicture` 與自己的變換集合。對其中一個框套用灰階不會使其他框變成灰階，即使它們共用相同的嵌入式影像資源。

相同的 `ISlidesPicture.getImageTransform` 模型也用於其他圖片填充，例如形狀或投影片背景。以下範例聚焦於圖片框。

## **使用有效的參數範圍與單位**

示範的方法使用下列語意範圍與單位。即使特定程式庫版本不會立即拒絕所有超出範圍的值，仍請將值限制於這些範圍；目標簡報格式在儲存或 PowerPoint 開啟檔案時可能會正規化、忽略或拒絕無效資料。

| Operation | Parameters | Valid range and unit |
|---|---|---|
| [addBrightnessContrastEffect](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iimagetransformoperationcollection/#addBrightnessContrastEffect-float-float-) | `brightness`, `contrast` | `-100` 到 `100`，百分比；`0` 表示保持元件不變。 |
| [addGrayScaleEffect](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iimagetransformoperationcollection/#addGrayScaleEffect--) | None | 無數值參數。Alpha 保持不變。 |
| [addDuotoneEffect](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iimagetransformoperationcollection/#addDuotoneEffect--) | `color1`, `color2` | 兩個顏色分別對應暗像素與亮像素。`java.awt.Color` 的 RGB 與 Alpha 通道使用 `0` 到 `255`。 |
| [addTintEffect](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iimagetransformoperationcollection/#addTintEffect-float-float-) | `hue`, `amount` | 色相 `0`（含）到 `360`（未含）度；幅度 `-100` 到 `100`，百分比。 |
| [addHSLEffect](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iimagetransformoperationcollection/#addHSLEffect-float-float-float-) | `hue`, `saturation`, `luminance` | 色相 `0`（含）到 `360`（未含）度；飽和度與亮度 `-100` 到 `100`，百分比。 |
| [addColorReplaceEffect](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iimagetransformoperationcollection/#addColorReplaceEffect--) | `color` | 替換顏色的通道值為 `0` 到 `255`。現有 Alpha 值保持不變。 |
| [addBlurEffect](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iimagetransformoperationcollection/#addBlurEffect-double-boolean-) | `radius`, `grow` | 半徑為非負值，以點為單位；`grow` 為布林值，控制模糊內容是否可延伸至原始邊界之外。 |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaModulateFixedEffect-float-) | `amount` | 非負百分比。使用 `0` 到 `100` 進行普通不透明度縮放：`0` 完全透明，`100` 保留原始 Alpha。 |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaReplaceEffect-float-) | `alpha` | `0` 到 `100`，百分比不透明度。 |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaBiLevelEffect-float-) | `threshold` | `0` 到 `100`，百分比 Alpha 閾值。低於此值的像素變為透明；等於或高於此值的像素變為不透明。 |

對於固定 Alpha 調變，透明度與不透明度是互補的。例如，35% 透明度相當於 Alpha 調變量 65%。

## **套用亮度與對比度**

[IImageTransformOperationCollection.addBrightnessContrastEffect](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iimagetransformoperationcollection/#addBrightnessContrastEffect-float-float-) 會返回一個 [IBrightnessContrast](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ibrightnesscontrast/) 操作。其標量設定在建立操作時提供。[IBrightnessContrast.getEffective](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ibrightnesscontrast/#getEffective--) 會返回計算後的唯讀值，可供檢查或記錄。

以下範例將亮度提高 15%，對比度提高 20%，然後在不修改嵌入影像的情況下渲染預覽：

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    byte[] imageData = Files.readAllBytes(Paths.get("photo.png"));
    IPPImage image = presentation.getImages().addImage(imageData);
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

[BrightnessContrast](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/brightnesscontrast/) 是 Office 2010 的圖片效果擴充，較不易於跨平台。當亮度與對比度必須在 PPTX 循環後仍保持可編輯時，請使用 [IImageTransformOperationCollection.addLuminanceEffect](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iimagetransformoperationcollection/#addLuminanceEffect-float-float-)，並在重新開啟檔案後驗證結果。格式限制章節會更詳細說明此區別。

## **套用顏色變換**

顏色效果可以獨立套用於重用同一影像資源的不同圖片框。以下範例建立五個框，分別套用灰階、雙調、色調、HSL 調整與顏色替換。

[IDuotone](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iduotone/) 含有兩個可獨立編輯的顏色參數：`color1` 對應暗像素，`color2` 對應亮像素。這是一個設定較為複雜、超過單一標量值的範例。

```java
import com.aspose.slides.*;
import java.awt.Color;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    byte[] imageData = Files.readAllBytes(Paths.get("photo.png"));
    IPPImage image = presentation.getImages().addImage(imageData);

    IPictureFrame grayFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 180, 120, image);
    grayFrame.getPictureFormat().getPicture().getImageTransform().addGrayScaleEffect();

    IPictureFrame duotoneFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 220, 20, 180, 120, image);
    IDuotone duotone = duotoneFrame.getPictureFormat().getPicture().getImageTransform().addDuotoneEffect();
    duotone.getColor1().setColor(new Color(0, 0, 128));
    duotone.getColor2().setColor(new Color(255, 215, 0));

    IPictureFrame tintFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 420, 20, 180, 120, image);
    tintFrame.getPictureFormat().getPicture().getImageTransform().addTintEffect(210f, 35f);

    IPictureFrame hslFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 120, 170, 180, 120, image);
    hslFrame.getPictureFormat().getPicture().getImageTransform().addHSLEffect(30f, 20f, -10f);

    IPictureFrame replacementFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 320, 170, 180, 120, image);
    IColorReplace colorReplacement = replacementFrame.getPictureFormat().getPicture().getImageTransform().addColorReplaceEffect();
    colorReplacement.getColor().setColor(new Color(100, 149, 237));

    presentation.save("color-transformations.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[addColorReplaceEffect](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iimagetransformoperationcollection/#addColorReplaceEffect--) 會將每個像素的顏色替換為固定顏色，同時保留 Alpha。它不同於 [addColorChangeEffect](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iimagetransformoperationcollection/#addColorChangeEffect--)，後者會將一個來源顏色映射到另一個顏色，且同時公開來源與目標的顏色格式。

## **加入模糊、透明度與 Alpha 效果**

[addBlurEffect](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iimagetransformoperationcollection/#addBlurEffect-double-boolean-) 會影響所有顏色通道，包括 Alpha。當模糊邊緣可能延伸超出原始圖片範圍時，請將 `grow` 設為 `true`。

若需要均勻的透明度，請使用 [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaModulateFixedEffect-float-)。它會將每個現有 Alpha 值相乘，因此部分透明的像素仍保持比例差異。[addAlphaReplaceEffect](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaReplaceEffect-float-) 則是將所有像素設定為相同的 Alpha 值。[addAlphaBiLevelEffect](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaBiLevelEffect-float-) 會根據閾值把 Alpha 轉為兩個層級。

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    byte[] imageData = Files.readAllBytes(Paths.get("photo.png"));
    IPPImage image = presentation.getImages().addImage(imageData);

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

其他無參數的 Alpha 操作包括 [addAlphaCeilingEffect](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaCeilingEffect--)（將所有非零 Alpha 設為完全不透明）、[addAlphaFloorEffect](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaFloorEffect--)（將低於 100% 的 Alpha 設為完全透明）以及 [addAlphaInverseEffect](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaInverseEffect--)（將 Alpha 變為 `100% - alpha`）。

## **建構有序的效果鏈**

每個 `add...Effect` 方法都會將新操作附加到集合的末端。渲染器會依序使用集合作為管線：操作 0 的輸出成為操作 1 的輸入，依此類推。因此，以不同順序執行相同操作可能產生不同影像。

舉例來說，先做灰階再做色調會先移除色彩資訊，再對亮度結果重新著色；而先做色調再做灰階則會再次移除色調。類似地，Alpha 替換可以覆寫先前操作計算的 Alpha，而 Alpha 調變則會保留其相對差異。

以下範例建立四個操作的鏈、儲存為 PPTX、重新開啟簡報、檢查操作類型與順序，並渲染重新開啟的結果：

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    byte[] imageData = Files.readAllBytes(Paths.get("photo.png"));
    IPPImage image = presentation.getImages().addImage(imageData);
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

此集合並未施加限制矩陣將顏色、Alpha 與模糊操作限制在不同链中。它們可以結合使用，但組合不一定有意義。固定顏色替換會移除先前顏色效果產生的 RGB 變化；灰階在雙調之後會移除兩種選定的顏色；Alpha 天花板、底部、替換或雙層操作則可能捨棄先前產生的 Alpha 細節。請依所需的像素處理順序建立鏈，而非將其項目視為無序的格式旗標。

## **檢查可編輯與有效值**

可編輯的操作是儲存在 `ISlidesPicture.getImageTransform` 中的物件。依效果不同，它可能直接公開可寫成員。例如，[IBlur](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iblur/) 會公開可寫的 `radius` 與 `grow`，[IAlphaModulateFixed](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ialphamodulatefixed/) 會公開可寫的 `amount`，以及 [IAlphaBiLevel](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ialphabilevel/) 會公開可寫的 `threshold`。像 [IDuotone](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iduotone/) 這類顏色效果會公開可變的 [IColorFormat](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/icolorformat/) 物件。

某些操作介面，例如 [IBrightnessContrast](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ibrightnesscontrast/)、[IHSL](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ihsl/)、[ITint](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/itint/) 與 [IAlphaReplace](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ialphareplace/)，不會將建立時的標量公開為可寫屬性。若要變更這些設定，必須先移除該操作，然後在所需位置加入新的取代操作。

`getEffective()` 回傳的有效資料是計算後的唯讀值。它對於解析主題相關顏色與取得渲染器使用的正規化值很有用，但不是另一個編輯介面。以下範例列舉鏈並在相應 API 提供時檢查有效值：

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

沒有參數的效果，如灰階、Alpha 天花板與 Alpha 反轉，仍會有有效資料物件，只是沒有可列印的標量設定。它們在集合中的存在與位置才是重要資訊。

## **移除或清除影像變換**

使用 [IImageTransformOperationCollection.removeAt](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iimagetransformoperationcollection/#removeAt-int-) 依索引移除單一操作。因為移除後索引會改變，請先搜尋目標再於列舉後移除。使用 [ImageTransformOperationCollection.clear](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/imagetransformoperationcollection/#clear--) 可一次清除整個鏈。

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

移除或清除變換僅會改變圖片格式設定，並不會刪除、重新壓縮或以其他方式更改重用的 [IPPImage](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ippimage/) 資源。

## **考慮簡報格式與匯出目標**

影像變換來源於 DrawingML，故 PPTX 是效果鏈的首選可編輯格式。即便使用 PPTX，也不是所有操作都有相同的可移植性：

- 標準 DrawingML 操作（如亮度、灰階、雙調、色調、HSL、模糊與一般 Alpha 操作）最有可能在 PPTX 循環後仍然存留。若需保留，請一定重新開啟產生的檔案並檢查集合。
- [BrightnessContrast](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/brightnesscontrast/) 為 Office 2010 的擴充，非標準 DrawingML 亮度操作。它可用於記憶體渲染，但在儲存並重新開啟 PPTX 後不保證仍為可編輯的 [IBrightnessContrast](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ibrightnesscontrast/)。請使用 [addLuminanceEffect](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iimagetransformoperationcollection/#addLuminanceEffect-float-float-) 以取得持久的亮度與對比度調整。
- 舊版 PPT 二進位格式在完整 DrawingML 效果模型出現之前就已存在。儲存為 PPT 可能會省略不支援的操作、將鏈縮減為支援的子集合，或以近似方式呈現。不要將 PPT 作為驗證複雜可編輯鏈的格式。
- 匯出為 PNG、JPEG、TIFF、PDF、SVG、HTML 或其他視覺輸出時，會將支援的鏈套用於渲染結果。這些輸出不會包含可編輯的 `IImageTransformOperationCollection`；點陣格式會將結果平鋪為像素，文件/向量匯出則保存其自行的渲染表示。
- 效果不會使連結的影像變成自包含。渲染連結圖片仍然依賴於載入簡報時連結資源可用。

不同的簡報消費者在處理邊緣案例時可能有不同的渲染結果，特別是當多個 Alpha 或顏色量化操作結合時。對於關鍵輸出，請使用與生產環境相同的 Aspose.Slides 版本，同時測試可編輯的循環與最終匯出格式。

## **常見問答**

**影像變換效果會修改嵌入的影像資料嗎？**

不會。這些操作屬於圖片填充所使用的 `ISlidesPicture`。底層的 `IPPImage` 位元組保持不變。

**重用同一影像的兩個圖片框會共享它們的效果嗎？**

不會。重用 `IPPImage` 可避免影像資料重複，但每個圖片框通常都有各自的 `ISlidesPicture` 與影像變換集合。

**可以同時結合顏色、模糊與 Alpha 效果嗎？**

可以。集合允許在同一有序鏈中混合它們。請考慮每個操作對前一步輸出的影響，因為替換與閾值操作可能會捨棄先前的顏色或 Alpha 細節。

**為什麼有效值是唯讀的？**

有效資料代表渲染時使用的計算值，包括解析過的顏色。請在變換集合中編輯那些具有可寫成員的操作；若無可寫屬性，則需移除該操作並以新建立參數加入取代。

**哪種格式能保留變換鏈？**

使用 PPTX 並在重新開啟後驗證檔案。舊版 PPT 無法完整表示 DrawingML 效果模型，而渲染匯出格式僅保留外觀，未保留可編輯的變換操作。
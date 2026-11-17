---
title: 使用 Java 在簡報中管理圖像變換效果
linktitle: 圖像變換效果
type: docs
weight: 11
url: /zh-hant/java/image-transform-effects/
keywords:
- 圖像變換
- 圖片效果
- 亮度
- 對比度
- 灰階
- 雙色調
- 色調
- HSL
- 顏色取代
- 模糊
- 透明度
- Alpha 效果
- 效果鏈
- PowerPoint
- 簡報
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Java 套用、鏈接、檢查、移除並驗證圖片框的圖像變換效果。"
---
## **概觀**

Aspose.Slides 將圖片調整表示為一個有序的圖像變換操作集合。對於圖片框，從框架的 [ISlidesPicture](https://reference.aspose.com/slides/java/com.aspose.slides/islidespicture/) 開始，並存取 [ISlidesPicture.getImageTransform](https://reference.aspose.com/slides/java/com.aspose.slides/islidespicture/#getImageTransform--)。返回的 [IImageTransformOperationCollection](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/) 允許您追加、列舉、檢查、移除和清除效果，而無需重新寫入原始圖像位元組。

本文示範了亮度與對比度、顏色轉換、模糊、透明度、有序效果鏈、有效值、移除以及 PPTX 循環驗證的完整工作流程。

## **了解效果所有權與圖像重用**

圖像資源與顯示該圖像的圖片是不同的物件：

- [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/ippimage/) **存儲或參照演示文稿擁有的來源圖像資料**。
- [ISlidesPicture](https://reference.aspose.com/slides/java/com.aspose.slides/islidespicture/) **屬於圖片填充，參照圖像資源，同時保存圖像變換集合**。
- [IPictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframe/) **是擁有相關圖片填充、幾何形狀、裁剪設定以及其他框級格式的投影片形狀**。

因此，圖像變換操作不會修改 [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/ippimage/) 中的位元組。當同一個 `IPPImage` 多次傳遞給 [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) 時，每個新圖片框都會取得自己的 `ISlidesPicture` 以及自己的變換集合。對其中一個框套用灰階不會使其他框變成灰階，即使它們共用相同的嵌入圖像資源。

相同的 `ISlidesPicture.getImageTransform` 模型也用於其他圖片填充，例如形狀或投影片背景。以下範例聚焦於圖片框。

## **使用有效的參數範圍與單位**

示範的方法使用下列語意範圍與單位。即使特定程式庫版本不會立即拒絕所有超出範圍的值，也請將值限制在這些範圍內；目標簡報格式可能在儲存或 PowerPoint 開啟檔案時正規化、忽略或拒絕無效資料。

| 操作 | 參數 | 有效範圍與單位 |
|---|---|---|
| [addBrightnessContrastEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addBrightnessContrastEffect-float-float-) | `brightness`, `contrast` | `-100` 到 `100`，百分比；`0` 表示保持元件不變 |
| [addGrayScaleEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addGrayScaleEffect--) | 無 | 無數值參數。Alpha 保持不變 |
| [addDuotoneEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addDuotoneEffect--) | `color1`, `color2` | 兩種顏色分別對應深色與淺色像素。`java.awt.Color` 的 RGB 與 Alpha 通道使用 `0` 到 `255` |
| [addTintEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addTintEffect-float-float-) | `hue`, `amount` | 色相 `0`（含）到 `360`（不含）度；色調量 `-100` 到 `100`，百分比 |
| [addHSLEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addHSLEffect-float-float-float-) | `hue`, `saturation`, `luminance` | 色相 `0`（含）到 `360`（不含）度；飽和度與亮度 `-100` 到 `100`，百分比 |
| [addColorReplaceEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addColorReplaceEffect--) | `color` | 替換顏色的通道值範圍 `0` 到 `255`，Alpha 保持不變 |
| [addBlurEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addBlurEffect-double-boolean-) | `radius`, `grow` | 半徑為非負值，以點（point）為單位；`grow` 為布林值，控制模糊內容是否可延伸超出原始邊界 |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaModulateFixedEffect-float-) | `amount` | 非負百分比。使用 `0` 到 `100` 進行普通不透明度縮放：`0` 為全透明，`100` 保持原始 Alpha |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaReplaceEffect-float-) | `alpha` | `0` 到 `100`，百分比不透明度 |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaBiLevelEffect-float-) | `threshold` | `0` 到 `100`，百分比 Alpha 閾值。低於此值的像素變為透明，等於或高於此值的像素變為不透明 |

對於固定的 Alpha 調變，透明度與不透明度互為補數。例如，35% 透明度對應的 Alpha 調變量為 65%。

## **套用亮度與對比度**

[IImageTransformOperationCollection.addBrightnessContrastEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addBrightnessContrastEffect-float-float-) 會回傳一個 [IBrightnessContrast](https://reference.aspose.com/slides/java/com.aspose.slides/ibrightnesscontrast/) 操作。其純量設定在建立操作時提供。[BrightnessContrast.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/brightnesscontrast/#getEffective--) 會回傳計算後的唯讀值，可供檢查或記錄。

以下範例將亮度提升 15%，對比度提升 20%，然後在不修改嵌入圖像的情況下呈現預覽：

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

[BrightnessContrast](https://reference.aspose.com/slides/java/com.aspose.slides/brightnesscontrast/) 是 Office 2010 圖片效果擴充，較不具可移植性，較標準的 DrawingML 亮度效果差。若需要在 PPTX 循環後仍能編輯亮度與對比度，請使用 [IImageTransformOperationCollection.addLuminanceEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addLuminanceEffect-float-float-)，並在重新開啟檔案後驗證結果。格式限制章節會更詳細說明此區別。

## **套用顏色轉換**

顏色效果可獨立套用於重用同一圖像資源的不同圖片框。以下範例建立五個框，分別套用灰階、雙色調、色調、HSL 調整與顏色取代。

[IDuotone](https://reference.aspose.com/slides/java/com.aspose.slides/iduotone/) 包含兩個可獨立編輯的顏色參數：`color1` 對應暗像素，`color2` 對應亮像素。此例說明了設定比單一純量更複雜的效果。

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

[addColorReplaceEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addColorReplaceEffect--) 會將每個像素的顏色取代為固定顏色，同時保留 Alpha。它不同於 [addColorChangeEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addColorChangeEffect--)，後者將來源顏色映射至目標顏色，且同時暴露來源與目標的顏色格式。

### **套用亮度閾值**

亮度閾值可讓掃描頁面的淡淡標記較易於從背景中辨識。[addGrayScaleEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addGrayScaleEffect--) 會保留中間的灰階色階。[addBiLevelEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addBiLevelEffect-float-) 會將亮度映射為黑或白，而 [addAlphaBiLevelEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaBiLevelEffect-float-) 則對不透明度套用閾值。

亮度閾值範圍為 0% 到 100%，包含兩端。低於閾值的像素變為黑色；等於或高於閾值的像素變為白色。提升閾值會使更多色階變為黑色，因為更多像素落在閾值以下。

下載 [grayscale-swatches.png](grayscale-swatches.png) 到工作目錄。每個標籤顯示原始灰階等級（0~255）。範例將原圖與兩個副本並排放置，並在簡報中保存每個副本的閾值設定。

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(720, 150, SlideSizeScaleType.DoNotScale);
    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();

    byte[] imageData = Files.readAllBytes(Paths.get("grayscale-swatches.png"));
    IPPImage image = presentation.getImages().addImage(imageData);

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

在 PowerPoint 中開啟輸出簡報以比較三個框。標示為 96 的色板其亮度約為 38%（96/255）。在 20% 閾值時變為白色，60% 閾值時變為黑色。

![原始灰階色板旁的黑白結果，亮度閾值分別為 20% 與 60%](luminance-threshold.png)

## **加入模糊、透明度與 Alpha 效果**

[addBlurEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addBlurEffect-double-boolean-) 會影響所有色彩通道，包括 Alpha。當模糊邊緣可能超出原始圖片範圍時，將 `grow` 設為 `true`。

若需均勻透明度，請使用 [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaModulateFixedEffect-float-)。它會乘以每個既有 Alpha 值，使部分透明像素仍保持相對差異。[addAlphaReplaceEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaReplaceEffect-float-) 會將所有像素的 Alpha 設為同一值。[addAlphaBiLevelEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaBiLevelEffect-float-) 會根據閾值將 Alpha 轉換為兩個層級。

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

其他無參數的 Alpha 操作包括 [addAlphaCeilingEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaCeilingEffect--)（將所有非零 Alpha 設為完全不透明）、[addAlphaFloorEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaFloorEffect--)（將低於 100% 的 Alpha 設為完全透明）以及 [addAlphaInverseEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaInverseEffect--)（將 Alpha 變為 `100% - alpha`）。

## **建立有序效果鏈**

每個 `add...Effect` 方法會將新操作附加在集合的末端。渲染器將集合視為有序管線：操作 0 的輸出成為操作 1 的輸入，依此類推。因此，相同的操作若以不同順序排列，會產生不同的影像。

例如，先灰階再色調會先移除色彩資訊，然後為亮度結果重新上色；先色調再灰階則會再次移除色調。類似地，Alpha 取代可覆寫先前操作計算的 Alpha，Alpha 調變則保留其相對差異。

以下範例建立四步驟的效果鏈，將其儲存為 PPTX，重新開啟簡報，檢查操作類型與順序，並渲染重新開啟的結果：

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

該集合並未強制相容性矩陣限制顏色、Alpha 與模糊操作必須分開鏈接。它們可以組合使用，但組合不一定實用。固定的顏色取代會移除先前顏色效果產生的 RGB 變化；在雙色調之後再套用灰階會移除兩種選取的顏色；Alpha 天花板、底部、取代或雙層操作會捨棄先前產生的 Alpha 細節。請根據期望的像素處理順序來構建鏈，而非將項目視為無序的格式標誌。

<!-- visual-explanation:image-transform-effects:start -->
[![相同圖像先經過灰階再色調，與先經過色調再灰階。兩個最終的灰階圖像呈現不同的色調。](visual-image-transform-effects-49aa72211f3a.svg)](visual-image-transform-effects-49aa72211f3a.svg)

*在此 Aspose.Slides for .NET 26.11 的示意渲染中，220° 色調以 25% 施加於灰階圖像時不會改變其外觀。先套用相同色調再執行灰階會產生不同的色調。*
<!-- visual-explanation:image-transform-effects:end -->

## **檢查可編輯與有效值**

可編輯的操作是儲存在 `ISlidesPicture.getImageTransform` 中的物件。根據效果的不同，可能直接公開可寫成員。例如，[IBlur](https://reference.aspose.com/slides/java/com.aspose.slides/iblur/) 會公開可寫的 `radius` 與 `grow`，[IAlphaModulateFixed](https://reference.aspose.com/slides/java/com.aspose.slides/ialphamodulatefixed/) 會公開可寫的 `amount`，以及 [IAlphaBiLevel](https://reference.aspose.com/slides/java/com.aspose.slides/ialphabilevel/) 會公開可寫的 `threshold`。像 [IDuotone](https://reference.aspose.com/slides/java/com.aspose.slides/iduotone/) 這類顏色效果則會公開可變更的 [IColorFormat](https://reference.aspose.com/slides/java/com.aspose.slides/icolorformat/) 物件。

某些操作介面，例如 [IBrightnessContrast](https://reference.aspose.com/slides/java/com.aspose.slides/ibrightnesscontrast/)、[IHSL](https://reference.aspose.com/slides/java/com.aspose.slides/ihsl/)、[ITint](https://reference.aspose.com/slides/java/com.aspose.slides/itint/)、[IAlphaReplace](https://reference.aspose.com/slides/java/com.aspose.slides/ialphareplace/)，不會將其建立時的純量以可寫屬性暴露。若要變更這些設定，請移除該操作並在所需位置加入替代操作。

`getEffective()` 回傳的有效資料是計算後的唯讀值。它對解析主題相關的顏色與讀取渲染器使用的正規化值很有幫助，但並非另一個編輯介面。以下範例列舉鏈中的操作，並在相應的 API 提供時檢查有效值：

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

沒有參數的效果（如灰階、Alpha 天花板、Alpha 反相）仍會有有效資料物件，但沒有可列印的純量設定。它們的存在與在集合中的位置即為重要資訊。

## **移除或清除圖像變換**

使用 [IImageTransformOperationCollection.removeAt](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#removeAt-int-) 依索引移除單一操作。因為移除後索引會改變，請先搜尋目標，完成列舉後再移除。使用 [ImageTransformOperationCollection.clear](https://reference.aspose.com/slides/java/com.aspose.slides/imagetransformoperationcollection/#clear--) 可清除整個鏈。

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

移除或清除變換只會改變圖片格式，並不會刪除、重新壓縮或以其他方式修改被重用的 [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/ippimage/) 資源。

## **考慮簡報格式與匯出目標**

圖像變換源於 DrawingML，因此 PPTX 為效果鏈的首選可編輯格式。即使使用 PPTX，也不是所有操作都具相同的可移植性：

- 標準 DrawingML 操作（如亮度、灰階、雙色調、色調、HSL、模糊與常見 Alpha 操作）最有可能在 PPTX 循環後仍保留。若有保存需求，務必重新開啟產生的檔案並檢查集合。
- [BrightnessContrast](https://reference.aspose.com/slides/java/com.aspose.slides/brightnesscontrast/) 為 Office 2010 的擴充，而非標準 DrawingML 亮度操作。它可用於記憶體渲染，但不保證在儲存與重新開啟 PPTX 後仍以可編輯的 [IBrightnessContrast](https://reference.aspose.com/slides/java/com.aspose.slides/ibrightnesscontrast/) 形式存在。請優先使用 [addLuminanceEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addLuminanceEffect-float-float-) 以獲得持久的亮度與對比度調整。
- 二進位 PPT 格式早於完整的 DrawingML 效果模型。儲存為 PPT 可能會省略不受支援的操作、將鏈縮減為支援子集，或近似外觀。不要將 PPT 用作複雜可編輯鏈的驗證格式。
- 渲染為 PNG、JPEG、TIFF、PDF、SVG、HTML 或其他視覺輸出時，會將支援的鏈套用於渲染結果。這些輸出不會包含可編輯的 `IImageTransformOperationCollection`；光柵格式會將結果平鋪為像素，文件/向量匯出則存儲其自身的渲染表示。
- 效果不會使連結圖像自行封閉。渲染連結圖片仍依賴於載入簡報時可取得的連結資源。

不同的簡報讀取程式可能對邊緣情況有不同的渲染結果，尤其是同時結合多個 Alpha 或顏色量化操作時。對於關鍵輸出，請使用生產環境中相同的 Aspose.Slides 版本，同時測試可編輯的循環與最終匯出格式。

## **常見問題**

**圖像變換效果會修改嵌入的圖像資料嗎？**

不會。這些操作屬於圖片填充所使用的 `ISlidesPicture`，底層的 `IPPImage` 位元組保持不變。

**重用同一圖像的兩個圖片框會共享它們的效果嗎？**

不會。重用 `IPPImage` 可以避免重複的圖像資料，但每個圖片框通常都有各自的 `ISlidesPicture` 及圖像變換集合。

**顏色、模糊與 Alpha 效果可以一起使用嗎？**

可以。集合接受它們在同一有序鏈中。請考慮每個操作對前一個輸出的影響，因為取代與閾值操作可能會捨棄先前的顏色或 Alpha 細節。

**為什麼有效值是唯讀的？**

有效資料代表渲染時使用的計算值，包括已解析的顏色。請在變換集合中編輯具有可寫成員的操作；若無可寫屬性，請移除該操作並以新參數加入替代項。

**應該使用哪種格式來保留變換鏈？**

使用 PPTX 並透過重新開啟檔案驗證。舊版 PPT 無法完整表示 DrawingML 效果模型，且渲染匯出格式僅保留外觀而非可編輯的變換操作。
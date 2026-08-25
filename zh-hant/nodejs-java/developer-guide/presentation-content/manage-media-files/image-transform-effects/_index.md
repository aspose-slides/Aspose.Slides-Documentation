---
title: "在簡報中使用 JavaScript 管理圖像變換效果"
linktitle: "圖像變換效果"
type: docs
weight: 11
url: /zh-hant/nodejs-java/image-transform-effects/
keywords:
- 圖像變換
- 圖片效果
- 亮度
- 對比
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
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 Aspose.Slides for Node.js（透過 Java）為圖片框套用、鏈接、檢查、移除及驗證圖像變換效果。"
---
## **概觀**

Aspose.Slides 將圖片調整表示為有序的圖像變換操作集合。對於圖片框，從框的 [Picture](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/picture/) 開始，並存取 [Picture.getImageTransform](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/picture/)。返回的 [ImageTransformOperationCollection](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/imagetransformoperationcollection/) 允許您追加、列舉、檢查、移除以及清除效果，而不必重新寫入原始圖像位元組。

本文示範了完整的工作流程，包括亮度與對比、顏色變換、模糊、透明度、有序效果鏈、有效值、移除，以及 PPTX 往返驗證。

## **了解效果所有權與圖像重用**

圖像資源與顯示它的圖片是不同的物件：

- [PPImage](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ppimage/) 儲存或參照由簡報擁有的來源圖像資料。
- [Picture](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/picture/) 屬於圖片填充，參照圖像資源，同時保存圖像變換集合。
- [PictureFrame](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/pictureframe/) 是投影片形狀，擁有相關的圖片填充、幾何、裁切設定以及其他框級格式。

因此，圖像變換操作不會修改 [PPImage](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ppimage/) 中的位元組。當相同的 [PPImage](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ppimage/) 多次傳遞給 [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/shapecollection/) 時，每個新圖片框會獲得自己的 [Picture](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/picture/) 與其獨立的變換集合。對一個框套用灰階不會讓其他框變灰，即使它們共用相同的嵌入圖像資源。

相同的 [Picture.getImageTransform](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/picture/) 模型也用於其他圖片填充，例如形狀或投影片背景。以下範例聚焦於圖片框。

## **使用有效的參數範圍與單位**

演示方法使用以下語義範圍與單位。即使特定程式庫版本未立即拒絕所有超出範圍的值，也請將值限制在此範圍內；目標簡報格式可能在保存或 PowerPoint 開啟檔案時正規化、忽略或拒絕無效資料。

| 操作 | 參數 | 有效範圍與單位 |
|---|---|---|
| [addBrightnessContrastEffect](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `brightness`, `contrast` | `-100` 到 `100`，百分比；`0` 保持元件不變。 |
| [addGrayScaleEffect](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/imagetransformoperationcollection/) | 無 | 無數值參數。Alpha 保持不變。 |
| [addDuotoneEffect](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `color1`, `color2` | 兩個顏色分別對應暗像素與亮像素。`java.awt.Color` 的 RGB 與 alpha 通道使用 `0` 到 `255`。 |
| [addTintEffect](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `hue`, `amount` | 色相 `0`（含）到 `360`（未含）度；`amount` 為 `-100` 到 `100`，百分比。 |
| [addHSLEffect](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `hue`, `saturation`, `luminance` | 色相 `0`（含）到 `360`（未含）度；飽和度與亮度為 `-100` 到 `100`，百分比。 |
| [addColorReplaceEffect](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `color` | 替換顏色的通道值為 `0` 到 `255`。現有的 alpha 值保持不變。 |
| [addBlurEffect](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `radius`, `grow` | 半徑為非負，以點為單位；`grow` 為布林值，控制模糊內容是否可延伸超出原始邊界。 |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `amount` | 非負百分比。使用 `0` 到 `100` 進行一般的不透明度縮放：`0` 完全透明，`100` 保持現有 alpha。 |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `alpha` | `0` 到 `100`，百分比不透明度。 |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `threshold` | `0` 到 `100`，百分比 alpha 閾值。低於閾值的變為透明，等於或高於閾值的變為不透明。 |

對於固定的 alpha 調變，透明度與不透明度是互補的。例如，35% 透明度對應的 alpha 調變量為 65%。

## **套用亮度與對比**

[ImageTransformOperationCollection.addBrightnessContrastEffect](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/imagetransformoperationcollection/) 會返回一個 [BrightnessContrast](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/brightnesscontrast/) 操作。其標量設定在建立操作時提供。[BrightnessContrast.getEffective](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/brightnesscontrast/) 會返回計算後的唯讀值，可供檢查或記錄。

以下範例將亮度提升 15%，對比提升 20%，然後在不修改嵌入圖像的情況下渲染預覽：

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 50, 400, 260, image);
    const imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
    const brightnessContrast = imageTransform.addBrightnessContrastEffect(15, 20);

    const effectiveValues = brightnessContrast.getEffective();
    console.log("Brightness: " + effectiveValues.getBrightness() + "%");
    console.log("Contrast: " + effectiveValues.getContrast() + "%");

    const preview = slide.getImage();
    try {
        preview.save("brightness-contrast-preview.png", aspose.slides.ImageFormat.Png);
    } finally {
        preview.dispose();
    }
} finally {
    presentation.dispose();
}
```

[BrightnessContrast](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/brightnesscontrast/) 是 Office 2010 圖片效果擴充，較標準 DrawingML 亮度效果可移植性差。若需在 PPTX 往返後仍保持可編輯，請使用 [ImageTransformOperationCollection.addLuminanceEffect](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/imagetransformoperationcollection/) 並在重新開啟檔案後驗證結果。格式限制章節會更詳細說明此差異。

## **套用顏色變換**

顏色效果可以獨立套用於重用同一圖像資源的不同圖片框。以下範例建立五個框，分別套用灰階、雙調、色調、HSL 調整與顏色替換。

[Duotone](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/duotone/) 包含兩個可分別編輯的顏色參數：`color1` 映射暗像素，`color2` 映射亮像素。此範例可說明設定較複雜的效果。

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const grayFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 20, 20, 180, 120, image);
    grayFrame.getPictureFormat().getPicture().getImageTransform().addGrayScaleEffect();

    const duotoneFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 220, 20, 180, 120, image);
    const duotone = duotoneFrame.getPictureFormat().getPicture().getImageTransform().addDuotoneEffect();
    duotone.getColor1().setColor(java.newInstanceSync("java.awt.Color", 0, 0, 128));
    duotone.getColor2().setColor(java.newInstanceSync("java.awt.Color", 255, 215, 0));

    const tintFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 420, 20, 180, 120, image);
    tintFrame.getPictureFormat().getPicture().getImageTransform().addTintEffect(210, 35);

    const hslFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 120, 170, 180, 120, image);
    hslFrame.getPictureFormat().getPicture().getImageTransform().addHSLEffect(30, 20, -10);

    const replacementFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 320, 170, 180, 120, image);
    const colorReplacement = replacementFrame.getPictureFormat().getPicture().getImageTransform().addColorReplaceEffect();
    colorReplacement.getColor().setColor(java.newInstanceSync("java.awt.Color", 100, 149, 237));

    presentation.save("color-transformations.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[addColorReplaceEffect](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/imagetransformoperationcollection/) 會將每個像素的顏色替換為固定顏色，同時保留 alpha。它不同於 [addColorChangeEffect](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/imagetransformoperationcollection/)，後者將一個來源顏色映射到另一個目標顏色，且同時公開來源與目標顏色的格式。

## **加入模糊、透明度與 Alpha 效果**

[addBlurEffect](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/imagetransformoperationcollection/) 會影響所有顏色通道，包括 alpha。若模糊邊緣可能超出原始圖片範圍，請將 `grow` 設為 `true`。

若需均勻透明度，使用 [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/imagetransformoperationcollection/)。它會乘以每個現有的 alpha 值，使部分透明像素保持比例差異。[addAlphaReplaceEffect](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/imagetransformoperationcollection/) 則是將所有像素統一為同一 alpha 值。[addAlphaBiLevelEffect](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/imagetransformoperationcollection/) 會根據閾值將 alpha 轉換為兩層。

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const blurredFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 20, 20, 200, 140, image);
    const blur = blurredFrame.getPictureFormat().getPicture().getImageTransform().addBlurEffect(4.5, true);
    blur.setRadius(5);

    const transparentFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 240, 20, 200, 140, image);
    const alphaModulate = transparentFrame.getPictureFormat().getPicture().getImageTransform().addAlphaModulateFixedEffect(65);
    alphaModulate.setAmount(60);

    const uniformAlphaFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 20, 180, 200, 140, image);
    uniformAlphaFrame.getPictureFormat().getPicture().getImageTransform().addAlphaReplaceEffect(55);

    const binaryAlphaFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 240, 180, 200, 140, image);
    const alphaBiLevel = binaryAlphaFrame.getPictureFormat().getPicture().getImageTransform().addAlphaBiLevelEffect(50);
    alphaBiLevel.setThreshold(45);
    binaryAlphaFrame.getPictureFormat().getPicture().getImageTransform().addAlphaInverseEffect();

    presentation.save("blur-and-alpha-effects.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

其他無參數的 alpha 操作包括 [addAlphaCeilingEffect](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/imagetransformoperationcollection/)，將所有非零 alpha 變為完全不透明；[addAlphaFloorEffect](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/imagetransformoperationcollection/)，將所有低於 100% 的 alpha 變為完全透明；以及 [addAlphaInverseEffect](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/imagetransformoperationcollection/)，將 alpha 變為 `100% - alpha`。

## **建立有序的效果鏈**

每個 `add...Effect` 方法都會將新操作追加到集合的末端。渲染器將集合視為有序流水線：操作 0 的輸出成為操作 1 的輸入，依此類推。因此，同樣的操作若以不同順序排列，可能產生不同的圖像。

例如，先執行灰階再執行色調會先移除色彩資訊，然後對亮度結果重新著色。若先執行色調再執行灰階，則會再次移除色調。類似地，Alpha 替換可以覆寫先前操作計算的 alpha，而 Alpha 調變則保留相對差異。

以下範例建立四個操作的鏈，保存為 PPTX，重新開啟簡報，檢查操作類型與順序，並渲染重新開啟的結果：

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 50, 400, 260, image);
    const imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
    imageTransform.addGrayScaleEffect();
    imageTransform.addTintEffect(220, 25);
    imageTransform.addBlurEffect(2.5, false);
    imageTransform.addAlphaModulateFixedEffect(80);

    presentation.save("image-transform-chain.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

const reopenedPresentation = new aspose.slides.Presentation("image-transform-chain.pptx");
try {
    const reopenedShape = reopenedPresentation.getSlides().get_Item(0).getShapes().get_Item(0);

    if (java.instanceOf(reopenedShape, "com.aspose.slides.IPictureFrame")) {
        const reopenedTransform = reopenedShape.getPictureFormat().getPicture().getImageTransform();
        const orderIsPreserved = reopenedTransform.size() === 4 &&
            java.instanceOf(reopenedTransform.get_Item(0), "com.aspose.slides.IGrayScale") &&
            java.instanceOf(reopenedTransform.get_Item(1), "com.aspose.slides.ITint") &&
            java.instanceOf(reopenedTransform.get_Item(2), "com.aspose.slides.IBlur") &&
            java.instanceOf(reopenedTransform.get_Item(3), "com.aspose.slides.IAlphaModulateFixed");
        console.log(orderIsPreserved ? "The effect chain was preserved." : "The effect chain changed during the round trip.");

        const renderedSlide = reopenedPresentation.getSlides().get_Item(0).getImage();
        try {
            renderedSlide.save("reopened-effect-chain.png", aspose.slides.ImageFormat.Png);
        } finally {
            renderedSlide.dispose();
        }
    } else {
        console.log("The reopened shape is not a picture frame.");
    }
} finally {
    reopenedPresentation.dispose();
}
```

此集合不會強制兼容性矩陣限制顏色、alpha 與模糊操作必須分屬不同鏈。它們可以組合使用，但組合未必都有意義。固定的顏色替換會移除先前彩色效果產生的 RGB 變化；灰階在雙調之後會移除兩個選定顏色；Alpha ceiling、floor、replace 或 bi‑level 操作可能會捨棄先前建立的 alpha 細節。請依照期望的像素處理順序建立鏈，而非將項目視為無序的格式旗標。

## **檢查可編輯與有效值**

可編輯的操作即存於 [Picture.getImageTransform](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/picture/) 中的物件。依效果不同，可能直接暴露可寫成員。例如，[Blur](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/blur/) 暴露可寫的 `radius` 與 `grow`，[AlphaModulateFixed](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/alphamodulatefixed/) 暴露可寫的 `amount`，[AlphaBiLevel](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/alphabilevel/) 暴露可寫的 `threshold`。像 [Duotone](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/duotone/) 這類顏色效果則暴露可變更的 [ColorFormat](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/colorformat/) 物件。

某些操作，如 [BrightnessContrast](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/brightnesscontrast/)、[HSL](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/hsl/)、[Tint](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/tint/)、[AlphaReplace](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/alphareplace/)，不會將其建立時的標量以可寫屬性公開。若要變更這些設定，需先移除該操作，然後在所需位置加入新的取代操作。

`getEffective()` 回傳的有效資料是計算後的唯讀物件。它對於解析主題相關顏色與取得渲染器使用的正規化值很有用，但並非另一個編輯介面。以下範例列舉鏈並檢查那些 API 提供的有效值：

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("image-transform-chain.pptx");
try {
    const shapes = presentation.getSlides().get_Item(0).getShapes();
    let pictureFrame = null;

    for (let index = 0; index < shapes.size(); index++) {
        const shape = shapes.get_Item(index);
        if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
            pictureFrame = shape;
            break;
        }
    }

    if (pictureFrame != null) {
        const imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();

        for (let index = 0; index < imageTransform.size(); index++) {
            const operation = imageTransform.get_Item(index);
            console.log(index + ": " + operation.getClass().getSimpleName());

            if (java.instanceOf(operation, "com.aspose.slides.IBrightnessContrast")) {
                const data = operation.getEffective();
                console.log("  Brightness: " + data.getBrightness());
                console.log("  Contrast: " + data.getContrast());
            } else if (java.instanceOf(operation, "com.aspose.slides.ILuminance")) {
                const data = operation.getEffective();
                console.log("  Brightness: " + data.getBrightness());
                console.log("  Contrast: " + data.getContrast());
            } else if (java.instanceOf(operation, "com.aspose.slides.IDuotone")) {
                const data = operation.getEffective();
                console.log("  Dark color: " + data.getColor1());
                console.log("  Light color: " + data.getColor2());
            } else if (java.instanceOf(operation, "com.aspose.slides.IColorReplace")) {
                const data = operation.getEffective();
                console.log("  Replacement color: " + data.getColor());
            } else if (java.instanceOf(operation, "com.aspose.slides.IHSL")) {
                const data = operation.getEffective();
                console.log("  HSL: " + data.getHue() + ", " + data.getSaturation() + ", " + data.getLuminance());
            } else if (java.instanceOf(operation, "com.aspose.slides.ITint")) {
                const data = operation.getEffective();
                console.log("  Tint: " + data.getHue() + ", " + data.getAmount());
            } else if (java.instanceOf(operation, "com.aspose.slides.IBlur")) {
                const data = operation.getEffective();
                console.log("  Blur radius: " + data.getRadius() + " pt");
            } else if (java.instanceOf(operation, "com.aspose.slides.IAlphaModulateFixed")) {
                const data = operation.getEffective();
                console.log("  Alpha amount: " + data.getAmount() + "%");
            } else if (java.instanceOf(operation, "com.aspose.slides.IAlphaReplace")) {
                const data = operation.getEffective();
                console.log("  Replacement alpha: " + data.getAlpha() + "%");
            } else if (java.instanceOf(operation, "com.aspose.slides.IAlphaBiLevel")) {
                const data = operation.getEffective();
                console.log("  Alpha threshold: " + data.getThreshold() + "%");
            }
        }
    }
} finally {
    presentation.dispose();
}
```

雖然灰階、alpha ceiling、alpha inverse 等無參數效果仍會產生有效資料物件，但沒有可列印的標量設定。它們在集合中的存在與位置即為重要資訊。

## **移除或清除圖像變換**

使用 [ImageTransformOperationCollection.removeAt](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/imagetransformoperationcollection/) 依索引移除單一操作。因為移除後索引會變動，請先搜尋目標再在列舉後移除。使用 [ImageTransformOperationCollection.clear](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/imagetransformoperationcollection/) 可一次移除整條鏈。

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("image-transform-chain.pptx");
try {
    const shapes = presentation.getSlides().get_Item(0).getShapes();
    let pictureFrame = null;

    for (let index = 0; index < shapes.size(); index++) {
        const shape = shapes.get_Item(index);
        if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
            pictureFrame = shape;
            break;
        }
    }

    if (pictureFrame != null) {
        const imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
        let blurIndex = -1;

        for (let index = 0; index < imageTransform.size(); index++) {
            if (java.instanceOf(imageTransform.get_Item(index), "com.aspose.slides.IBlur")) {
                blurIndex = index;
                break;
            }
        }

        if (blurIndex >= 0) {
            imageTransform.removeAt(blurIndex);
            console.log("The blur operation was removed.");
        }

        imageTransform.clear();
        console.log("Remaining operations: " + imageTransform.size());
        presentation.save("image-transforms-cleared.pptx", aspose.slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

移除或清除變換僅會改變圖片格式，並不會刪除、重新壓縮或以其他方式更改重用的 [PPImage](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ppimage/) 資源。

## **考慮簡報格式與匯出目標**

圖像變換起源於 DrawingML，故 PPTX 為效果鏈的首選可編輯格式。即使使用 PPTX，也不是每個操作的可移植性皆相同：

- 標準 DrawingML 操作（如亮度、灰階、雙調、色調、HSL、模糊以及常見的 alpha 操作）最有可能在 PPTX 往返後仍然存活。若需保存，請始終重新開啟產生的檔案並檢查集合。
- [BrightnessContrast](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/brightnesscontrast/) 為 Office 2010 擴充，而非標準 DrawingML 亮度操作。可用於記憶體渲染，但保存並重新開啟 PPTX 後，無法保證仍為可編輯的 [BrightnessContrast](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/brightnesscontrast/) 操作。請改用 [addLuminanceEffect](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/imagetransformoperationcollection/) 以獲得持久的亮度與對比調整。
- 舊版 PPT 格式早於完整的 DrawingML 效果模型。保存為 PPT 可能會省略不支援的操作、將鏈縮減為支援子集，或近似外觀。不要將 PPT 作為複雜可編輯鏈的驗證格式。
- 渲染為 PNG、JPEG、TIFF、PDF、SVG、HTML 或其他視覺輸出時，會將支援的鏈套用於最終外觀。這些輸出不會包含可編輯的 [ImageTransformOperationCollection](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/imagetransformoperationcollection/)；光柵格式會將結果平鋪成像素，文件/向量匯出則存儲自己的渲染表示。
- 效果不會使連結圖像變為自包含。若圖片是連結的，渲染時仍須確保連結資源可在簡報載入時取得。

不同的簡報消費者在處理多個 alpha 或顏色量化操作組合時可能表現不同。對於關鍵輸出，請同時測試可編輯的往返以及最終匯出格式，並使用與生產環境相同的 Aspose.Slides 版本。

## **FAQ**

**圖像變換效果會修改嵌入的圖像資料嗎？**

不會。這些操作屬於用於圖片填充的 [Picture](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/picture/)。底層的 [PPImage](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ppimage/) 位元組保持不變。

**兩個重用相同圖像的圖片框會共享它們的效果嗎？**

不會。重用 [PPImage](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ppimage/) 可避免重複的圖像資料，但每個圖片框通常都有獨立的 [Picture](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/picture/) 以及圖像變換集合。

**顏色、模糊與 alpha 效果可以結合使用嗎？**

可以。集合允許在同一有序鏈中加入它們。請考慮每個操作對前一個操作輸出的影響，因為替換與閾值操作可能會丟棄先前的顏色或 alpha 細節。

**為什麼有效值是唯讀的？**

有效資料代表渲染時使用的計算值，包括解析後的顏色。若操作在變換集合中有可寫成員，請直接編輯該操作；若無，請移除該操作並以新的建立參數加入替代品。

**應該使用哪種格式才能保留變換鏈？**

請使用 PPTX，並在重新開啟檔案後驗證。舊版 PPT 無法完整表示 DrawingML 效果模型，且渲染匯出格式僅保留外觀而非可編輯的變換操作。
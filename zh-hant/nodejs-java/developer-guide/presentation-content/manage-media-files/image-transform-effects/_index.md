---
title: 使用 JavaScript 管理簡報中的圖像變換效果
linktitle: 圖像變換效果
type: docs
weight: 11
url: /zh-hant/nodejs-java/image-transform-effects/
keywords:
- 圖像變換
- 圖片效果
- 亮度
- 對比度
- 灰階
- 雙調
- 色調
- HSL
- 顏色取代
- 模糊
- 透明度
- Alpha 效果
- 效果鏈
- PowerPoint
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 Aspose.Slides for Node.js 透過 Java，套用、串接、檢查、移除並驗證圖片框的圖像變換效果。"
---
## **概述**

Aspose.Slides 以有序的圖像變換操作集合來表示圖片調整。對於圖片框，從框的 [Picture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/) 開始，並存取 [Picture.getImageTransform](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/)。返回的 [ImageTransformOperationCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) 允許您追加、列舉、檢查、移除以及清除效果，而無需重新寫入原始圖像位元組。

本文示範了亮度與對比度、顏色變換、模糊、透明度、有序效果鏈、有效值、移除以及 PPTX 循環驗證的完整工作流程。

## **了解效果所有權與圖像重用**

圖像資源與顯示它的圖片是不同的物件：

- [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/) 儲存或參照由簡報擁有的原始圖像資料。
- [Picture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/) 屬於圖片填充，指向圖像資源，同時儲存圖像變換集合。
- [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/) 是擁有相關圖片填充、幾何形狀、裁剪設定與其他框級格式的投影片形狀。

因此，圖像變換操作不會修改 [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/) 中的位元組。當相同的 [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/) 多次傳遞給 [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/) 時，每個新圖片框都會取得自己的 [Picture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/) 以及自己的變換集合。對其中一個框套用灰階不會使其他框變成灰階，即使它們都重用了相同的嵌入圖像資源。

相同的 [Picture.getImageTransform](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/) 模型也被其他圖片填充使用，例如形狀或投影片背景。以下範例著重於圖片框。

## **使用有效的參數範圍與單位**

示範的方法使用下列語意範圍與單位。即使特定程式庫版本未立即拒絕每個超出範圍的值，也請保持在這些範圍內；目標簡報格式可能在儲存或 PowerPoint 開啟檔案時正規化、忽略或拒絕無效資料。

| 操作 | 參數 | 有效範圍與單位 |
|---|---|---|
| [addBrightnessContrastEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `brightness`, `contrast` | `-100` 到 `100`，百分比；`0` 表示保持元件不變。 |
| [addGrayScaleEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | 無 | 無數值參數。Alpha 不變。 |
| [addDuotoneEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `color1`, `color2` | 兩種顏色分別用於深色與亮色像素。`java.awt.Color` 中的 RGB 與 Alpha 通道使用 `0` 到 `255`。 |
| [addTintEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `hue`, `amount` | 色相 `0`（含）到 `360`（不含）度；色量為 `-100` 到 `100`，百分比。 |
| [addHSLEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `hue`, `saturation`, `luminance` | 色相 `0`（含）到 `360`（不含）度；飽和度與亮度為 `-100` 到 `100`，百分比。 |
| [addColorReplaceEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `color` | 替換顏色的通道值為 `0` 到 `255`。既有的 Alpha 不變。 |
| [addBlurEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `radius`, `grow` | 半徑為非負值，單位為點；`grow` 為布林值，控制模糊內容是否可延伸至原始邊界之外。 |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `amount` | 非負百分比。使用 `0` 到 `100` 進行普通不透明度縮放：`0` 為完全透明，`100` 保留既有 Alpha。 |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `alpha` | `0` 到 `100`，百分比不透明度。 |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `threshold` | `0` 到 `100`，百分比 Alpha 閾值。低於此值的像素變為透明，等於或高於此值的像素變為不透明。 |

對於固定的 Alpha 調製，透明度與不透明度是互補的。例如，35% 的透明度對應於 65% 的 Alpha 調製量。

## **套用亮度與對比度**

[ImageTransformOperationCollection.addBrightnessContrastEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) 會回傳一個 [BrightnessContrast](https://reference.aspose.com/slides/nodejs-java/aspose.slides/brightnesscontrast/) 操作。其純量設定在建立操作時即提供。[BrightnessContrast.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/brightnesscontrast/) 會回傳計算後的唯讀值，可供檢查或記錄。

以下範例將亮度提升 15%，對比度提升 20%，然後在不修改嵌入圖像的情況下產生預覽：

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

[BrightnessContrast](https://reference.aspose.com/slides/nodejs-java/aspose.slides/brightnesscontrast/) 是 Office 2010 圖片效果的擴充，較標準 DrawingML 亮度效果的可移植性差。當需在 PPTX 循環後仍保持可編輯的亮度與對比度時，請使用 [ImageTransformOperationCollection.addLuminanceEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) 並在重新開啟檔案後驗證結果。格式限制說明段落會進一步闡述此差異。

## **套用顏色變換**

顏色效果可獨立套用於重用同一圖像資源的不同圖片框。以下範例建立五個框，分別套用灰階、雙調、色調、HSL 調整與顏色取代。

[Duotone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/duotone/) 包含兩個可獨立編輯的顏色參數：`color1` 用於暗像素，`color2` 用於亮像素。這使它成為一個設定較單一純量更複雜的效果範例。

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

[addColorReplaceEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) 會以固定顏色取代每個像素的顏色，同時保留 Alpha。它不同於 [addColorChangeEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/)，後者會將一個來源顏色映射為另一個顏色，並公開來源與目標的顏色格式。

### **套用亮度閾值**

亮度閾值可讓掃描頁面上的淡淡痕跡較易於從背景中辨識。[addGrayScaleEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) 保留中間的灰階色階。[addBiLevelEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) 將亮度映射為黑或白，而 [addAlphaBiLevelEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) 則對不透明度套用閾值。

亮度閾值範圍為 0% 至 100%（含），低於閾值的像素變為黑色，等於或高於閾值的像素變為白色。提高閾值會使更多色階變為黑色，因為更多像素落在截止點以下。

下載 [grayscale-swatches.png](grayscale-swatches.png) 至工作目錄。每個標籤顯示原始灰階等級，範圍為 0 到 255。範例將原始圖置於兩個副本旁，並將每個副本的閾值寫入簡報。

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    presentation.getSlideSize().setSize(720, 150, slides.SlideSizeScaleType.DoNotScale);
    const shapes = presentation.getSlides().get_Item(0).getShapes();

    const sourceImage = slides.Images.fromFile("grayscale-swatches.png");
    let image;
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const captions = ["Original", "Threshold 20%", "Threshold 60%"];
    const frames = [];
    for (let i = 0; i < captions.length; i++) {
        const x = 12 + 240 * i;
        const label = shapes.addAutoShape(slides.ShapeType.Rectangle, x, 12, 216, 36);
        label.getTextFrame().setText(captions[i]);
        const frame = shapes.addPictureFrame(slides.ShapeType.Rectangle, x, 60, 216, 72, image);
        frames.push(frame);
    }

    frames[1].getPictureFormat().getPicture().getImageTransform().addBiLevelEffect(20);
    frames[2].getPictureFormat().getPicture().getImageTransform().addBiLevelEffect(60);
    
    presentation.save("luminance-threshold.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

在 PowerPoint 中開啟輸出簡報以比較三個框。標示為 96 的樣本其亮度約為 38%（96/255）。在 20% 閾值時變為白色，於 60% 閾值時變為黑色。

![原始灰階樣本旁的黑白結果（亮度閾值為 20% 與 60%）](luminance-threshold.png)

## **加入模糊、透明度與 Alpha 效果**

[addBlurEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) 會影響所有顏色通道，包括 Alpha。當模糊邊緣可能延伸超出原始圖片範圍時，將 `grow` 設為 `true`。

若需統一透明度，請使用 [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/)。它會乘算每個既有的 Alpha 值，使部分透明像素仍保持相對差異。[addAlphaReplaceEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) 則會將所有像素指派同一 Alpha 值。[addAlphaBiLevelEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) 會依閾值將 Alpha 轉為兩個層級。

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

其他無參數的 Alpha 操作包括 [addAlphaCeilingEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/)，會使所有非零 Alpha 變為完全不透明；[addAlphaFloorEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/)，會使所有低於 100% 的 Alpha 變為完全透明；以及 [addAlphaInverseEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/)，會將 Alpha 變為 `100% - alpha`。

## **建構有序的效果鏈**

每個 `add...Effect` 方法都會將新操作追加至集合的末端。渲染程式會依序使用集合作為管線：操作 0 的輸出成為操作 1 的輸入，依此類推。因此，以不同順序排列相同操作會產生不同圖像。

舉例而言，先灰階再色調會先移除色彩資訊，再為亮度結果重新著色。先色調再灰階則會再次移除色調。類似地，Alpha 取代可以覆寫先前操作計算的 Alpha，而 Alpha 調製則保留其相對差異。

以下範例建構包含四個操作的鏈、儲存為 PPTX、重新開啟簡報、檢查操作類型與順序，並渲染重新開啟的結果：

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

此集合不會強加相容性矩陣限制顏色、Alpha 與模糊操作必須分開鏈。它們可以組合使用，但組合未必有意義。固定顏色取代會移除先前顏色效果產生的 RGB 變化；灰階在雙調之後會移除兩個選定顏色；Alpha 天花板、底板、取代或二階操作則可能捨棄先前創建的 Alpha 細節。請依據所需的像素處理順序構建鏈，而非將其視為無序的格式化旗標。


<!-- visual-explanation:image-transform-effects:start -->
[![相同圖像先經過灰階再色調，與先色調再灰階的結果。兩個最終的灰階圖像色調不同。](visual-image-transform-effects-49aa72211f3a.svg)](visual-image-transform-effects-49aa72211f3a.svg)

*此圖示為 Aspose.Slides for .NET 26.11 的渲染結果，220° 色調、25% 透明度下灰階圖像保持不變。先套用相同色調再灰階會產生不同的色調。*
<!-- visual-explanation:image-transform-effects:end -->

## **檢查可編輯與有效值**

可編輯的操作是存於 [Picture.getImageTransform](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/) 的物件。依效果不同，可能直接公開可寫成員。例如，[Blur](https://reference.aspose.com/slides/nodejs-java/aspose.slides/blur/) 公开可寫的 `radius` 與 `grow`，[AlphaModulateFixed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/alphamodulatefixed/) 公开可寫的 `amount`，[AlphaBiLevel](https://reference.aspose.com/slides/nodejs-java/aspose.slides/alphabilevel/) 公开可寫的 `threshold`。像 [Duotone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/duotone/) 這類顏色效果則會公開可變的 [ColorFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/colorformat/) 物件。

某些操作，如 [BrightnessContrast](https://reference.aspose.com/slides/nodejs-java/aspose.slides/brightnesscontrast/)、[HSL](https://reference.aspose.com/slides/nodejs-java/aspose.slides/hsl/)、[Tint](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tint/)、[AlphaReplace](https://reference.aspose.com/slides/nodejs-java/aspose.slides/alphareplace/)，不會將其建立時的純量曝光為可寫屬性。若要變更這些設定，請移除該操作並在所需位置新增替代項。

`getEffective()` 回傳的有效資料是計算後的唯讀值。它有助於解析主題依賴的顏色，並讀取渲染程式使用的正規化值，但並非另一個編輯介面。以下範例列舉鏈並在對應的 API 提供時檢查有效值：

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

無參數的效果，例如灰階、Alpha 天花板與 Alpha 反轉，仍會有有效資料物件，只是沒有可列印的純量設定。它們在集合中的存在與位置即為重要資訊。

## **移除或清除圖像變換**

使用 [ImageTransformOperationCollection.removeAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) 依索引移除單一操作。因為移除後索引會變動，請先搜尋目標再於列舉後移除。使用 [ImageTransformOperationCollection.clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) 可一次清除整個鏈。

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

移除或清除變換僅會改變圖片格式，並不會刪除、重新壓縮或以其他方式改變被重用的 [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/) 資源。

## **考量簡報格式與匯出目標**

圖像變換起源於 DrawingML，因此 PPTX 是效果鏈的首選可編輯格式。即使使用 PPTX，並非所有操作皆具有相同的可移植性：

- 標準 DrawingML 操作（如亮度、灰階、雙調、色調、HSL、模糊以及常見 Alpha 操作）最有可能在 PPTX 循環後仍然存在。若有保存需求，務必重新開啟產生的檔案並檢查集合。
- [BrightnessContrast](https://reference.aspose.com/slides/nodejs-java/aspose.slides/brightnesscontrast/) 為 Office 2010 的擴充，而非標準 DrawingML 亮度操作。可用於記憶體內渲染，但無法保證在儲存與重新開啟 PPTX 後仍保持可編輯的 [BrightnessContrast](https://reference.aspose.com/slides/nodejs-java/aspose.slides/brightnesscontrast/) 操作。請改用 [addLuminanceEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) 以獲得持久的亮度與對比度調整。
- 舊的二進位 PPT 格式早於完整的 DrawingML 效果模型。儲存為 PPT 可能會省略不支援的操作、將鏈縮減為支援的子集，或以近似方式呈現。不要將 PPT 作為複雜可編輯鏈的驗證格式。
- 渲染至 PNG、JPEG、TIFF、PDF、SVG、HTML 或其他視覺輸出時，會將支援的鏈套用於最終外觀。這些輸出不會包含可編輯的 [ImageTransformOperationCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/)；點陣圖格式會將結果平鋪為像素，文件/向量匯出則儲存其自己的渲染表示。
- 效果不會使連結圖像變成自包含。渲染連結圖片仍然依賴於載入簡報時可取得的連結資源。

不同的簡報使用者可能會對邊緣案例有不同的渲染結果，尤其在結合多個 Alpha 或顏色量化操作時。對於關鍵輸出，請使用與生產環境相同的 Aspose.Slides 版本，測試可編輯的循環與最終匯出格式。

## **常見問題**

**圖像變換效果會修改嵌入的圖像資料嗎？**

不會。這些操作屬於用於圖片填充的 [Picture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/)。底層的 [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/) 位元組保持不變。

**兩個重用相同圖像的圖片框會共享它們的效果嗎？**

不會。重用 [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/) 可避免重複的圖像資料，但每個圖片框通常都有各自的 [Picture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/) 與圖像變換集合。

**顏色、模糊與 Alpha 效果可以一起使用嗎？**

可以。集合允許在同一有序鏈中加入它們。請考慮每個操作對先前輸出的影響，因為取代與閾值操作可能會捨棄先前的顏色或 Alpha 細節。

**為什麼有效值是唯讀的？**

有效資料代表渲染時使用的計算值，包括已解析的顏色。若操作中有可寫成員，請直接編輯存於變換集合中的操作；若沒有，請移除該操作並加入帶有新建立參數的替代項。

**應該使用哪種格式來保留變換鏈？**

使用 PPTX 並透過重新開啟檔案驗證。舊版 PPT 無法完整呈現 DrawingML 效果模型，而已渲染的匯出格式僅保留外觀，並不包含可編輯的變換操作。
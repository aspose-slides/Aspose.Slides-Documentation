---
title: 使用 JavaScript 在簡報中管理圖片框架
linktitle: 圖片框架
type: docs
weight: 10
url: /zh-hant/nodejs-java/picture-frame/
keywords:
- 圖片框架
- 新增圖片框架
- 建立圖片框架
- 內嵌圖像
- 連結圖像
- 擷取圖像
- 光柵圖像
- SVG 圖像
- 裁剪圖像
- 刪除裁剪區域
- 壓縮圖像
- StretchOffset
- 圖片框架格式設定
- 相對縮放
- 圖像效果
- 長寬比
- PowerPoint
- OpenDocument
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 Aspose.Slides for Node.js 透過 JavaScript 在簡報中建立、格式化、連結、裁剪、擷取與壓縮圖片框架。"
---
## **概述**

圖片框架是顯示圖像的投影片形狀。在 Aspose.Slides 中，圖像資源與顯示它的形狀是分開的物件：a [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/) 透過其 [ImageCollection](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/imagecollection/) 擁有內嵌圖像資源，而 [PictureFrame](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/pictureframe/) 控制圖像的位置、大小、線條格式、旋轉、裁剪、圖片效果以及其他框架層級設定。

此分離在同一圖像需要顯示多次時非常有用。將圖像加入簡報一次，保留回傳的 [PPImage](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ppimage/)，在建立圖片框架時使用該圖像資源。

圖片框架可以包含 PNG 或 JPEG 等光柵圖像以及 SVG 向量圖像。它們也可以參照連結圖像，而不是將圖像位元組儲存在簡報中。此選擇會影響可攜性、檔案大小、擷取與匯出行為，因此在套用格式或最佳化之前，先決定圖像應如何儲存是有益的。

## **新增與格式化內嵌圖像**

對於內嵌圖像，將圖像資料加入簡報，並使用 [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/shapecollection/#addPictureFrame-int-float-float-float-float-aspose.slides.PPImage-) 建立圖片框架。圖像會成為簡報套件的一部份，因而在移動到其他電腦時仍保持自包含。

以下範例加入 PNG 圖像，依圖像的原生尺寸建立框架，並套用線條格式與旋轉：

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("image.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 100, image.getWidth(), image.getHeight(), image);
    pictureFrame.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    pictureFrame.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    pictureFrame.getLineFormat().setWidth(3);
    pictureFrame.setRotation(15);

    presentation.save("picture-frame.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

圖片框架控制顯示的幾何形狀；變更框架大小不會改變內嵌圖像資源中儲存的原始像素尺寸。此區別在之後裁剪或壓縮圖像時變得重要。

## **使用相對縮放**

[PictureFrame](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/pictureframe/) 透過 [setRelativeScaleWidth](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/pictureframe/#setRelativeScaleWidth-float-) 與 [setRelativeScaleHeight](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/pictureframe/#setRelativeScaleHeight-float-) 暴露框架的相對寬度與高度縮放。`1.0` 的值對應於原始圖片大小的 100%。相對縮放在需要保留與來源圖像尺寸關係而非手動計算最終尺寸的工作流程中相當有用。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("image.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 50, 100, 100, image);
    pictureFrame.setRelativeScaleWidth(java.newFloat(1.35));
    pictureFrame.setRelativeScaleHeight(java.newFloat(0.8));

    presentation.save("relative-scale.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

相對縮放會變更框架的縮放設定；它不會重新取樣或壓縮內嵌圖像。

## **內嵌與連結圖像**

內嵌圖片將圖像資料儲存在簡報內部，因而是可攜性與可預測渲染最安全的選擇。連結圖片則透過 [Picture.setLinkPathLong](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/picture/#setLinkPathLong-java.lang.String-) 方法儲存外部位置，而不是以相同方式嵌入圖像資料。

連結圖像可以減少 PPTX 中儲存的圖像資料量，但會產生外部相依性。連結的檔案必須保持可供開啟或渲染簡報的應用程式存取。若路徑變更、檔案移動或資源不可用，連結圖片可能無法如預期顯示。對於必須以電子郵件傳送、存檔或在隔離環境中渲染的簡報，內嵌圖像通常較可靠。

### **新增連結圖像**

以下範例建立圖片框架並指向本機圖像檔案。它僅處理圖像連結；影片連結是另一套媒體工作流程，故此範例未混入。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const path = require("path");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 50, 320, 180, null);
    const linkPath = path.resolve("image.png");
    pictureFrame.getPictureFormat().getPicture().setLinkPathLong(linkPath);

    presentation.save("linked-image.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

在有意管理外部檔案時使用連結。不要僅將其作為壓縮的替代方案：一個帶有破損圖像相依性的較小 PPTX 通常不如較大的自包含簡報實用。

## **從圖片框架擷取圖像**

在從現有簡報擷取圖像之前，先確認形狀實際上是 [PictureFrame](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/pictureframe/) 且包含內嵌圖像。連結圖片框架可能不含可以相同方式擷取的圖像位元組。

### **擷取光柵圖像**

現代圖像 API 直接使用 [IImage](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/iimage/)。以下範例在投影片上找到第一個內嵌光柵圖片並以 PNG 保存：

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    for (let i = 0; i < slide.getShapes().size(); i++) {
        const shape = slide.getShapes().get_Item(i);
        if (!java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
            continue;
        }

        const embeddedImage = shape.getPictureFormat().getPicture().getImage();
        if (embeddedImage == null || embeddedImage.getSvgImage() != null) {
            continue;
        }

        const rasterImage = embeddedImage.getImage();
        try {
            rasterImage.save("extracted-image.png", aspose.slides.ImageFormat.Png);
        } finally {
            rasterImage.dispose();
        }
        break;
    }
} finally {
    presentation.dispose();
}
```

透過 [IImage.save](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/iimage/#save) 保存會將擷取的圖像轉換為請求的輸出格式。若需要簡報內儲存的編碼位元組而非已轉換的光柵檔案，請使用圖像資源的二進位資料。

### **擷取 SVG 圖像**

對於 SVG 圖片，[PPImage](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ppimage/) 會暴露一個 [SvgImage](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/svgimage/) 物件。這讓您可以直接取得 SVG 資料，而不必先將圖片光柵化。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const fs = require("fs");
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    for (let i = 0; i < slide.getShapes().size(); i++) {
        const shape = slide.getShapes().get_Item(i);
        if (!java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
            continue;
        }

        const embeddedImage = shape.getPictureFormat().getPicture().getImage();
        const svgImage = embeddedImage != null ? embeddedImage.getSvgImage() : null;
        if (svgImage == null) {
            continue;
        }

        fs.writeFileSync("extracted-image.svg", svgImage.getSvgData());
        break;
    }
} finally {
    presentation.dispose();
}
```

將 SVG 內容保持為 SVG 可在簡報中保留向量來源。PNG 或 JPEG 等光柵匯出必須將向量內容渲染為像素。PDF 或 SVG 投影片匯出同樣是渲染操作，因此匯出的圖形不應被視為原始內嵌 SVG 的逐位元複製；需要原始向量資源時，請使用內嵌的 [SvgImage.getSvgData](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/svgimage/#getSvgData--) 資料。

## **裁剪圖像**

裁剪會變更框架內可見的圖像區域。[PictureFillFormat](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/picturefillformat/) 上的裁剪值是相對於來源圖像尺寸的百分比。裁剪最初不會刪除內嵌圖像中隱藏的像素；它僅改變可見區域。

以下範例安全地找到圖片框架並套用裁剪值：

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    let pictureFrame = null;

    for (let i = 0; i < slide.getShapes().size(); i++) {
        const shape = slide.getShapes().get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
            pictureFrame = shape;
            break;
        }
    }

    if (pictureFrame != null) {
        pictureFrame.getPictureFormat().setCropLeft(java.newFloat(23.6));
        pictureFrame.getPictureFormat().setCropRight(java.newFloat(21.5));
        pictureFrame.getPictureFormat().setCropTop(java.newFloat(3));
        pictureFrame.getPictureFormat().setCropBottom(java.newFloat(31));
        presentation.save("cropped-image.pptx", aspose.slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

因為隱藏的圖像資料仍然存在，裁剪可以稍後更改而不會失去原始像素。若檔案大小比可逆性更重要，可依下節說明實際移除裁剪區域。

## **移除裁剪的圖像資料**

[PictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--) 會移除當前裁剪矩形之外的圖像資料，並返回結果圖像資源。這可以減少檔案大小，但屬於破壞性最佳化：簡報儲存後，被移除的像素將無法再進行取消裁剪的操作。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    let pictureFrame = null;

    for (let i = 0; i < slide.getShapes().size(); i++) {
        const shape = slide.getShapes().get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
            pictureFrame = shape;
            break;
        }
    }

    if (pictureFrame != null) {
        const croppedImage = pictureFrame.getPictureFormat().deletePictureCroppedAreas();
        if (croppedImage != null) {
            presentation.save("cropped-data-removed.pptx", aspose.slides.SaveFormat.Pptx);
        }
    }
} finally {
    presentation.dispose();
}
```

此方法可能在簡報中新增一個圖像資源。如果原始圖像同時被其他圖片框架使用，這些框架仍需要其現有資源，因此刪除裁剪區域不一定會減少圖像總數。使用此方法裁剪 WMF 或 EMF 內容會將裁剪結果光柵化為 PNG。

## **壓縮光柵圖像**

[PictureFillFormat.compressImage](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/picturefillformat/#compressImage-boolean-int-) 會相對於圖片顯示的大小降低光柵圖像解析度。它也可以在同一次操作中移除裁剪區域。當圖像被重新調整大小或裁剪時，方法回傳 `true`；若不需要變更則回傳 `false`。

當標準目標解析度足夠時，使用預定義的 [PicturesCompression](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/picturescompression/) 值：

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    let pictureFrame = null;

    for (let i = 0; i < slide.getShapes().size(); i++) {
        const shape = slide.getShapes().get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
            pictureFrame = shape;
            break;
        }
    }

    if (pictureFrame != null) {
        const compressed = pictureFrame.getPictureFormat().compressImage(true, aspose.slides.PicturesCompression.Dpi150);
        console.log(compressed ? "The image was compressed." : "No compression was necessary.");
        presentation.save("compressed-image.pptx", aspose.slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

若需要特定目標，可傳入自訂的正 DPI 值取代預定義值。

壓縮僅適用於光柵圖像。SVG 與中繼檔內容不會因此光柵壓縮工作流程而減少。也請記住，較低的解析度與已刪除的裁剪區域無法從最佳化後的簡報中復原。選擇目標解析度時，應以圖像實際檢視或匯出時的最大尺寸為基準，而非全局套用最低 DPI。

## **檢視圖像效果**

圖片效果儲存在框架使用的圖片上。圖像變換集合可能包含透明度的固定 Alpha 調變以及亮度的亮度與對比度等效果。以下範例安全地讀取投影片上第一個圖片框架的兩類效果：

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    let pictureFrame = null;

    for (let i = 0; i < slide.getShapes().size(); i++) {
        const shape = slide.getShapes().get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
            pictureFrame = shape;
            break;
        }
    }

    if (pictureFrame != null) {
        const imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
        for (let i = 0; i < imageTransform.size(); i++) {
            const effect = imageTransform.get_Item(i);
            if (java.instanceOf(effect, "com.aspose.slides.IAlphaModulateFixed")) {
                const transparency = 100 - effect.getAmount();
                console.log("Transparency: " + transparency);
            }

            if (java.instanceOf(effect, "com.aspose.slides.ILuminance")) {
                const luminance = effect.getEffective();
                console.log("Brightness: " + luminance.getBrightness());
                console.log("Contrast: " + luminance.getContrast());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

這些效果會改變圖像在框架中的渲染方式；它們不會改寫原始內嵌圖像的位元組。

## **鎖定圖片框架幾何形狀**

[PictureFrameLock](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/pictureframelock/) 設定控制哪種編輯操作會對圖片框架被停用。例如，[setAspectRatioLocked](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/pictureframelock/#setAspectRatioLocked-boolean-) 在調整大小時保留形狀的比例。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("image.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 100, image.getWidth(), image.getHeight(), image);
    pictureFrame.getPictureFrameLock().setAspectRatioLocked(true);

    presentation.save("locked-picture-frame.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

此鎖定套用於圖片框架形狀本身。它不會強制來源圖像重新取樣或永久改變為相同的長寬比。

## **調整 StretchOffset 值**

當圖片填充模式為 stretch 時，[PictureFillFormat](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/picturefillformat/) 上的 stretch‑offset 值定義相對於圖片框架邊界盒的填充矩形。正百分比會從邊緣產生內縮，負百分比則產生外伸。

這與裁剪不同。裁剪值決定來源圖像的哪一部分可見；stretch offset 變更可見圖片填充被拉伸的矩形。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("image.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 10, 10, 400, 300, image);
    pictureFrame.getPictureFormat().setPictureFillMode(java.newByte(aspose.slides.PictureFillMode.Stretch));
    pictureFrame.getPictureFormat().setStretchOffsetLeft(java.newFloat(12));
    pictureFrame.getPictureFormat().setStretchOffsetRight(java.newFloat(12));
    pictureFrame.getPictureFormat().setStretchOffsetTop(java.newFloat(8));
    pictureFrame.getPictureFormat().setStretchOffsetBottom(java.newFloat(8));

    presentation.save("stretch-offsets.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

使用 stretch offset 來放置填充。若目標是隱藏來源圖像邊緣，請使用裁剪屬性。

## **儲存、檔案大小與匯出考量**

將圖像儲存與圖片框架格式分別處理時，主要的取捨較易管理：

- **Embedded images** 使簡報自包含，對於共享與伺服器端渲染最可靠，但大型光柵圖像會增加 PPTX 大小與記憶體使用。
- **Linked images** 可以保持套件較小，然而簡報依賴於外部檔案在儲存路徑或位置仍然可用。
- **Cropping** 起始為非破壞性。隱藏的像素會保留於內嵌中，直到明確刪除裁剪區域或在壓縮時移除。
- **Compression** 可大幅減少過大光柵圖像的檔案大小，但會犧牲來源解析度。應在確定投影片上實際顯示尺寸後再套用。
- **SVG images** 若向量保留重要，應保持為 SVG。需要向量資源本身時，直接擷取內嵌 SVG。光柵投影片匯出始終會將渲染的投影片轉為像素。
- **Repeated images** 應盡可能重複使用現有的 [PPImage](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ppimage/) 資源，而不是在簡報工作流程中多次載入同一檔案。

對於大型簡報，圖像最佳化通常在選擇性執行時最有效：將標誌與圖表保留為向量內容，依實際顯示大小壓縮照片，只在不需日後編輯時移除裁剪像素，除非相依性管理是部署設計的一部份，否則避免使用外部連結。

## **FAQ**

**圖片框架與圖像資源有何不同？**

[PPImage](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ppimage/) 代表與簡報關聯的圖像資源。[PictureFrame](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/pictureframe/) 則是投影片上的形狀，用於顯示圖像並儲存框架層級的幾何與格式設定，如大小、旋轉、裁剪值、效果與鎖定。

**我應該內嵌還是連結圖像？**

當簡報必須可攜、存檔或在未存取外部資源的情況下渲染時，請內嵌圖像。僅在有意將圖像檔案保留於 PPTX 之外且能可靠維護外部位置時才使用連結圖像。

**裁剪會減少 PPTX 檔案大小嗎？**

不會。普通的裁剪設定會隱藏來源圖像的部分，但仍保留底層像素。若要永久移除這些像素，可使用 [PictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--) 或在壓縮時移除裁剪區域。

**壓縮後能恢復圖像品質嗎？**

不能。壓縮會降低儲存的光柵解析度，移除裁剪區域則會丟棄圖像資料。如需日後進行高解析度編輯，請在簡報外保留原始來源圖像。

**SVG 圖像該如何處理？**

在向量保真度重要時，將 SVG 內容保留為 SVG。內嵌的 [SvgImage](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/svgimage/) 可直接擷取。將投影片渲染為 PNG 或 JPEG 等光柵格式會將 SVG 向量光柵化。

**如何避免在讀取現有投影片時產生不安全的轉型？**

在使用圖片框架專屬成員之前，先檢查形狀類型。對 [PictureFrame](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/pictureframe/) 進行 `java.instanceOf` 檢查，可避免無效的轉型，並讓程式碼能處理不含圖片框架的投影片。
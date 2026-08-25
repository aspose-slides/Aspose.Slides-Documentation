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
- 內嵌影像
- 連結影像
- 擷取影像
- 點陣圖影像
- SVG 影像
- 裁剪影像
- 刪除已裁剪區域
- 壓縮影像
- StretchOffset
- 圖片框架格式設定
- 相對比例
- 影像效果
- 長寬比
- PowerPoint
- OpenDocument
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 Aspose.Slides for Node.js 於 Java 中建立、格式化、連結、裁剪、擷取及壓縮簡報中的圖片框架。"
---
## **概覽**

圖片框架是顯示影像的投影片形狀。在 Aspose.Slides 中，影像資源與顯示它的形狀是分開的物件：一個 [簡報](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/) 透過其 [影像集合](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/imagecollection/) 擁有內嵌影像資源，而一個 [圖片框架](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/pictureframe/) 控制影像的位置、大小、線條格式、旋轉、裁剪、圖片效果以及其他框架層級設定。

當相同影像顯示多次時，這種分離很有用。將影像加入簡報一次，保留回傳的 [PPImage](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ppimage/)，並在建立圖片框架時使用該影像資源。

圖片框架可以包含 PNG 或 JPEG 等點陣圖，以及 SVG 向量圖。它們也可以參照連結影像而不是將影像位元組儲存在簡報內。此選擇會影響可移植性、檔案大小、擷取及匯出行為，因此在套用格式或最佳化之前，先決定影像應如何儲存是很有幫助的。

## **新增與格式化內嵌影像**

對於內嵌影像，將影像資料加入簡報並使用 [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/shapecollection/#addPictureFrame-int-float-float-float-float-aspose.slides.PPImage-) 建立圖片框架。影像會成為簡報套件的一部分，因而在移至其他電腦時仍能保持自包含。

以下範例加入 PNG 影像、以影像的原始尺寸建立框架，並套用線條格式與旋轉：

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

圖片框架控制顯示的幾何形狀；變更框架大小不會改變內嵌影像資源中儲存的原始像素尺寸。在之後裁剪或壓縮影像時，這個差異相當重要。

## **使用相對比例**

[圖片框架](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/pictureframe/) 透過 [setRelativeScaleWidth](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/pictureframe/#setRelativeScaleWidth-float-) 與 [setRelativeScaleHeight](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/pictureframe/#setRelativeScaleHeight-float-) 暴露相對寬度與高度的縮放。值 `1.0` 代表原始圖片大小的 100%。相對比例在工作流程必須保留與來源影像尺寸的關聯，而非手動計算最終尺寸時非常有用。

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

相對比例會變更框架的縮放設定；它不會重新取樣或壓縮內嵌影像。

## **內嵌與連結影像**

內嵌圖片將影像資料儲存在簡報內，因此是可移植性與可預測呈現最安全的選擇。連結圖片則透過 [Picture.setLinkPathLong](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/picture/#setLinkPathLong-java.lang.String-) 方法儲存外部位置，而不是以相同方式嵌入影像資料。

連結影像可以減少 PPTX 中的影像資料量，但會產生外部相依性。連結的檔案必須保持可供開啟或渲染簡報的應用程式存取。若路徑變更、檔案移動或資源不可用，連結圖片可能不會如預期顯示。對於必須透過電子郵件傳送、存檔或在隔離環境中渲染的簡報，內嵌影像通常較為可靠。

### **新增連結影像**

以下範例建立圖片框架並指向本機影像檔案。它僅處理影像連結；影片連結屬於另一個媒體工作流程，故此範例未混入。

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

在外部檔案管理是刻意行為時使用連結。不要僅將其作為壓縮的替代方案：一個帶有破損影像相依性的小型 PPTX 通常不如較大且自包含的簡報實用。

## **從圖片框架擷取影像**

在從現有簡報擷取影像之前，先確認形狀實際上是 [圖片框架](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/pictureframe/) 且其中包含內嵌影像。連結圖片框架可能不會包含可以相同方式擷取的影像位元組。

### **擷取點陣圖影像**

現代影像 API 直接使用 [IImage](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/iimage/)。以下範例在投影片上找到第一個內嵌點陣圖並將其儲存為 PNG：

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

透過 [IImage.save](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/iimage/#save) 儲存會將擷取的影像轉換為要求的輸出格式。如果需要簡報中儲存的編碼位元組，而非已轉換的點陣檔，請改用影像資源的二進位資料。

### **擷取 SVG 影像**

對於 SVG 圖片，[PPImage](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ppimage/) 會公開一個 [SvgImage](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/svgimage/) 物件。這讓您能直接取得 SVG 資料，而不必先將圖片光柵化。

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

將 SVG 內容保留為 SVG 可在簡報內保留向量來源。PNG 或 JPEG 等點陣匯出必須將向量內容渲染成像素。PDF 或 SVG 投影片匯出同樣是一種渲染操作，因此匯出的圖形不該被視為原始內嵌 SVG 的逐位元複製；當需要原始向量資源本身時，請使用內嵌的 [SvgImage.getSvgData](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/svgimage/#getSvgData--) 資料。

## **裁剪影像**

裁剪會變更框架內可見的影像部分。[PictureFillFormat](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/picturefillformat/) 上的裁剪值是相對於來源影像尺寸的百分比。裁剪不會立即從內嵌影像中刪除隱藏的像素；它僅改變可見區域。

以下範例安全地找出圖片框架並套用裁剪值：

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

因為隱藏的影像資料仍然存在，之後可在不失去原始像素的情況下變更裁剪。如果檔案大小比可逆性更重要，則可如下一節所述實際移除裁剪區域。

## **移除裁剪影像資料**

[PictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--) 會移除當前裁剪矩形之外的影像資料，並回傳結果影像資源。這可以減少檔案大小，但屬於破壞性最佳化：簡報儲存後，已移除的像素將不再可用於日後的取消裁剪操作。

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

此方法可能為簡報新增一個影像資源。若原始影像同時被其他圖片框架使用，這些框架仍需其現有資源，因此刪除裁剪區域不一定會減少影像總數。使用此方法裁剪 WMF 或 EMF 內容會將裁剪結果光柵化為 PNG。

## **壓縮點陣圖影像**

[PictureFillFormat.compressImage](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/picturefillformat/#compressImage-boolean-int-) 會根據圖片實際顯示的尺寸降低點陣圖解析度。它也可以在同一操作中移除裁剪區域。若影像被重新尺寸化或裁剪，方法會回傳 `true`；若無需變更則回傳 `false`。

當標準目標解析度足夠時，可使用預定義的 [PicturesCompression](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/picturescompression/) 值：

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

如果需要特定目標，可傳入自訂的正 DPI 值以取代預定義值。

壓縮僅適用於點陣圖。SVG 與圖形檔內容不會受到此點陣壓縮工作流程的影響。同時請記住，較低的解析度與已刪除的裁剪區域無法從最佳化後的簡報中復原。請根據影像實際檢視或匯出時的最大尺寸來選擇目標解析度，而非全局使用最低 DPI。

## **管理影像變形效果**

有關亮度、對比、顏色變換、模糊、透明度效果、有序鏈、檢查、移除以及來回驗證的完整工作流程，請參閱 [Image Transform Effects](/slides/zh-hant/nodejs-java/image-transform-effects/)。

## **鎖定圖片框架幾何形狀**

[PictureFrameLock](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/pictureframelock/) 設定控制哪些編輯操作會被禁用於圖片框架。例如，[setAspectRatioLocked](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/pictureframelock/#setAspectRatioLocked-boolean-) 會在調整大小時保持形狀的比例。

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

此鎖定套用於圖片框架形狀本身，並不會強制來源影像重新取樣或永久改變為相同的長寬比。

## **調整 StretchOffset 值**

當圖片填充模式為 stretch 時，[PictureFillFormat](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/picturefillformat/) 上的 stretch‑offset 值會相對於圖片框架的邊界框定義填充矩形。正的百分比會從邊緣向內縮進，負的百分比則向外延伸。

這與裁剪不同。裁剪值決定來源影像哪一部分可見；stretch offset 則改變可見圖片填充被拉伸的矩形。

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

使用 stretch offset 來調整填充位置。若目標是隱藏來源影像的邊緣，請使用裁剪屬性。

## **儲存、檔案大小與匯出考量**

在將影像儲存與圖片框架格式化分開處理時，主要的取捨較易管理：

- **內嵌影像** 使簡報自包含，對於分享與伺服器端渲染最可靠，但大型點陣圖會增加 PPTX 大小與記憶體使用。
- **連結影像** 可讓套件較小，但簡報依賴外部檔案必須在儲存的路徑或位置保持可用。
- **裁剪** 起初是非破壞性的。隱藏的像素會保留在內嵌中，直至明確刪除裁剪區域或在壓縮時移除。
- **壓縮** 可大幅減少過大點陣圖的檔案大小，但會犧牲來源解析度。應在確定投影片上實際顯示尺寸後再執行。
- **SVG 影像** 在向量保留重要時應保持為 SVG。需要向量資源時直接擷取內嵌 SVG。點陣投影片匯出始終會將渲染的投影片轉換為像素。
- **重複影像** 應盡可能重用現有的 [PPImage](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ppimage/) 資源，而非在簡報工作流程中多次載入相同檔案。

對於大型簡報，影像最佳化通常在選擇性執行時最有效：將標誌與圖表保留為向量內容，依實際顯示大小壓縮照片，僅在後續編輯不需要時移除裁剪像素，除非部署設計已納入相依性管理，否則避免使用外部連結。

## **常見問題**

**圖片框架與影像資源有何差異？**

[PPImage](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ppimage/) 代表與簡報關聯的影像資源。[圖片框架](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/pictureframe/) 則是投影片上的形狀，用於顯示影像並儲存框架層級的幾何與格式設定，如大小、旋轉、裁剪值、效果與鎖定。

**應該內嵌還是連結影像？**

當簡報必須可移植、存檔或在未存取外部資源的情況下渲染時，請內嵌影像。僅在刻意將影像檔案保留在 PPTX 之外且能可靠維護外部位置時才使用連結。

**裁剪會減少 PPTX 檔案大小嗎？**

單獨的裁剪不會。一般的裁剪設定會隱藏來源影像的部分，但仍保留底層像素。若這些像素可被永久移除，請使用 [PictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--) 或結合裁剪區域移除的影像壓縮。

**壓縮後能恢復影像品質嗎？**

不能。壓縮會降低儲存的點陣解析度，且移除裁剪區域會捨棄影像資料。若日後需要高解析度編輯，請將原始來源影像保留在簡報之外。

**應該如何處理 SVG 影像？**

當向量忠實度重要時，保留 SVG 內容為 SVG。內嵌的 [SvgImage](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/svgimage/) 可直接擷取。將投影片渲染為 PNG 或 JPEG 等點陣格式時，SVG 會被光柵化為投影片圖像的一部分。

**如何避免在讀取現有投影片時發生不安全的型別轉換？**

在使用圖片框架特有成員之前，先檢查形狀類型。對 [圖片框架](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/pictureframe/) 做 `java.instanceOf` 檢查，可避免無效的型別轉換，並讓程式碼能處理不含圖片框架的投影片。
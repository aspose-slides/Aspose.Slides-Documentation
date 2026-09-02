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
- 嵌入式影像
- 連結式影像
- 提取影像
- 點陣圖影像
- SVG 影像
- 裁剪影像
- 刪除裁剪區域
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
description: "使用 Aspose.Slides for Node.js 於 JavaScript 中建立、格式化、連結、裁剪、提取與壓縮簡報中的圖片框架。"
---
## **概觀**

圖片框架是一種在投影片上顯示影像的形狀。在 Aspose.Slides 中，影像資源與顯示它的形狀是分開的物件：一個[Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/) 透過其[ImageCollection](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/imagecollection/) 擁有嵌入的影像資源，而[PictureFrame](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/pictureframe/) 控制影像的位置、大小、線條格式、旋轉、裁剪、圖片效果與其他框架層級的設定。

當同一張影像需要顯示多次時，這種分離非常有用。只需將影像加入簡報一次，保留回傳的[PPImage](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ppimage/)，在建立圖片框架時使用該影像資源。

圖片框架可以容納 PNG 或 JPEG 等點陣圖以及 SVG 向量圖。它們也可以引用連結式影像，而不是將影像位元組儲存在簡報內。選擇哪種方式會影響可移植性、檔案大小、提取與匯出行為，因此在套用格式或最佳化之前，先決定影像的儲存方式是很重要的。

## **新增與格式化嵌入式影像**

對於嵌入式影像，將影像資料加入簡報，並使用[ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/shapecollection/#addPictureFrame-int-float-float-float-float-aspose.slides.PPImage-) 建立圖片框架。影像會成為簡報套件的一部份，因而在搬移到其他電腦時仍保持自足。

以下範例加入 PNG 影像，依影像本身尺寸建立框架，並套用線條格式與旋轉：

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

圖片框架控制顯示的幾何形狀；變更框架大小不會改變嵌入影像資源中原始像素的尺寸。此區別在之後進行裁剪或壓縮時相當重要。

## **使用相對比例**

[PictureFrame](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/pictureframe/) 透過[setRelativeScaleWidth](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/pictureframe/#setRelativeScaleWidth-float-) 與[setRelativeScaleHeight](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/pictureframe/#setRelativeScaleHeight-float-) 暴露相對寬度與高度的比例。`1.0` 代表 100% 的原始圖片大小。相對比例在工作流程需要保留與來源影像尺寸的關係，而不必手動計算最終尺寸時非常有用。

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

相對比例會變更框架的縮放設定；它不會重新取樣或壓縮嵌入的影像。

## **嵌入式與連結式影像**

嵌入式圖片將影像資料儲存在簡報內，因而是最安全的可移植性與可預測渲染選擇。連結式圖片則透過[Picture.setLinkPathLong](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/picture/#setLinkPathLong-java.lang.String-) 方法將外部位置儲存，而不是以相同方式嵌入影像資料。

連結式影像可以減少 PPTX 中的影像資料量，但會產生外部相依性。連結的檔案必須保持可供開啟或渲染簡報的應用程式存取。若路徑變更、檔案被移動或資源無法取得，連結圖片可能無法如預期顯示。對於必須透過電子郵件傳送、歸檔或在隔離環境中渲染的簡報，嵌入式影像通常較為可靠。

### **新增連結式影像**

以下範例建立圖片框架，並指向本機影像檔案。此範例僅處理影像連結；影片連結屬於另一套媒體工作流程，故此處未混入。

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

在外部檔案管理是刻意的情況下使用連結。不要僅將其視為壓縮的替代方案：帶有破損連結的 小型 PPTX 往往不如較大且自足的簡報實用。

## **從圖片框架提取影像**

在從現有簡報提取影像之前，請先確認形狀實際上是[PictureFrame](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/pictureframe/) 且包含嵌入式影像。連結式圖片框架可能不含可直接提取的影像位元組。

### **提取點陣圖影像**

現代影像 API 直接使用[IImage](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/iimage/)。以下範例在投影片上找到第一個嵌入的點陣圖，並將其存為 PNG：

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

透過[IImage.save](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/iimage/#save) 儲存會將提取的影像轉換為要求的輸出格式。如果需要的是簡報中儲存的編碼位元組，而非轉換後的點陣檔，請直接使用影像資源的二進位資料。

### **提取 SVG 影像**

對於 SVG 圖片，[PPImage](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ppimage/) 會公開一個[SvgImage](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/svgimage/) 物件。這讓您直接取得 SVG 資料，而不必先將圖片點陣化。

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

將 SVG 內容保留為 SVG 可在簡報內保留向量來源。像 PNG 或 JPEG 這樣的點陣匯出必然將向量內容渲染成像素。PDF 或 SVG 投影片匯出同樣屬於渲染操作，因此匯出的圖形不應被視為原始嵌入 SVG 的逐位元拷貝；在需要原始向量資源時，請使用嵌入的[SvgImage.getSvgData](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/svgimage/#getSvgData--) 資料。

## **裁剪影像**

裁剪會改變在框架內可見的影像部分。[PictureFillFormat](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/picturefillformat/) 的裁剪值以來源影像尺寸的百分比表示。裁剪最初不會刪除嵌入影像中被隱藏的像素，只是改變可見區域。

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

因為隱藏的影像資料仍然存在，稍後可以變更裁剪而不會失去原始像素。若檔案大小比可逆性更重要，可如下一節所述實際移除裁剪區域。

## **移除裁剪後的影像資料**

[PictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--) 會移除目前裁剪矩形之外的影像資料，並回傳結果影像資源。這可以減少檔案大小，但屬於破壞性最佳化：簡報儲存後，被移除的像素將無法再進行取消裁剪的操作。

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

此方法可能會在簡報中加入新的影像資源。如果原始影像同時被其他圖片框架使用，這些框架仍需要其既有資源，因此刪除裁剪區域未必會減少影像總數。使用此方法裁剪 WMF 或 EMF 內容會將裁剪結果點陣化為 PNG。

## **壓縮點陣圖影像**

[PictureFillFormat.compressImage](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/picturefillformat/#compressImage-boolean-int-) 會依圖片實際顯示大小降低點陣圖解析度。它也可在同一次操作中移除裁剪區域。該方法在影像被重新調整大小或裁剪時回傳 `true`，在未需變更時回傳 `false`。

當標準目標解析度足以時，可使用預定義的[PicturesCompression](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/picturescompression/) 值：

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

如果需要特定目標，亦可傳入自訂的正值 DPI。

壓縮僅針對點陣圖影像。SVG 與圖形檔案不會受到此點陣壓縮工作流程的影響。亦請記得，較低的解析度與已刪除的裁剪區域無法從最佳化後的簡報中復原。請根據影像實際檢視或匯出的最大尺寸來選擇目標解析度，而非全局套用最低 DPI。

## **管理影像變換效果**

若需完整的亮度、對比、顏色變換、模糊、透明度、排序鏈、檢查、刪除與往返驗證工作流程，請參閱[Image Transform Effects](/nodejs-java/image-transform-effects/)。

## **鎖定圖片框架幾何形狀**

[PictureFrameLock](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/pictureframelock/) 設定控制哪些編輯操作會被停用。例如，[setAspectRatioLocked](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/pictureframelock/#setAspectRatioLocked-boolean-) 在調整大小時保留形狀的比例。

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

當圖片填充模式為 stretch 時，[PictureFillFormat](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/picturefillformat/) 上的 stretch‑offset 值定義相對於圖片框架邊界框的填充矩形。正百分比會從邊緣內縮，負百分比則會向外伸展。

這與裁剪不同。裁剪值決定來源影像的哪一部分可見；stretch offset 則改變可見圖片填充被拉伸的矩形。

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

使用 stretch offset 來放置填充。若目的是隱藏來源影像的邊緣，請使用裁剪屬性。

## **儲存、檔案大小與匯出考量**

將影像儲存與圖片框架格式分開處理時，主要的取捨較易管理：

- **嵌入式影像** 使簡報自足，是分享與伺服器端渲染最可靠的選擇，但大型點陣圖會增加 PPTX 大小與記憶體使用量。
- **連結式影像** 能讓套件保持較小，但簡報必須依賴外部檔案在指定路徑或位置仍可存取。
- **裁剪** 初期為非破壞性。隱藏的像素仍保留於嵌入影像中，直至明確刪除裁剪區域或在壓縮時移除。
- **壓縮** 能顯著縮小過大點陣圖的檔案大小，但會犧牲來源解析度。應在確定投影片上最終顯示尺寸後再執行。
- **SVG 影像** 在需要保留向量完整性的情況下應保持為 SVG。需要向量資源時直接提取嵌入的 SVG。點陣化的投影片匯出始終會將渲染的投影片轉為像素。
- **重複使用的影像** 應盡可能重用已有的[PPImage](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ppimage/)資源，而非在工作流程中多次載入同一檔案。

對於大型簡報，影像最佳化通常在選擇性執行時最有效：將標誌與圖表保留為向量內容，依實際顯示大小壓縮相片，僅在不需日後編輯時移除裁剪像素，並避免使用外部連結，除非相依管理是部署設計的一部分。

## **常見問題**

**圖片框架與影像資源有何不同？**  
[PPImage](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ppimage/) 代表與簡報關聯的影像資源。[PictureFrame](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/pictureframe/) 則是投影片上的形狀，用於顯示影像並儲存框架層級的幾何與格式資訊，如大小、旋轉、裁剪值、效果與鎖定。

**應該嵌入還是連結影像？**  
當簡報必須具備可移植性、歸檔或在無外部資源存取的情況下渲染時，請嵌入影像。僅在刻意將影像檔案置於 PPTX 之外且能可靠維護外部位置時才使用連結。

**裁剪會減少 PPTX 檔案大小嗎？**  
不會。普通的裁剪設定會隱藏來源影像的部分，但仍保留底層像素。若要永久移除這些像素，請使用[PictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--) 或在壓縮時同時移除裁剪區域。

**壓縮後能恢復影像品質嗎？**  
不能。壓縮會降低儲存的點陣解析度，且移除裁剪區域會捨棄影像資料。若日後可能需要高解析度編輯，請將原始來源影像保留在簡報外部。

**SVG 影像該如何處理？**  
在向量完整性重要時，請保留 SVG 內容為 SVG。嵌入的[SvgImage](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/svgimage/) 可直接提取。將投影片渲染為 PNG 或 JPEG 會將 SVG 向量點陣化。

**如何避免在讀取既有投影片時產生不安全的型別轉換？**  
在使用圖片框架專屬成員前先檢查形狀類型。對[PictureFrame](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/pictureframe/) 進行`java.instanceOf` 檢查，可避免無效的型別轉換，並讓程式碼能正確處理不含圖片框架的投影片。
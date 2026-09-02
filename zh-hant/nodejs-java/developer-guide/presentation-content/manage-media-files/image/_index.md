---
title: 使用 JavaScript 優化投影片中的圖像管理
linktitle: 管理圖像
type: docs
weight: 10
url: /zh-hant/nodejs-java/image/
keywords:
- 加入圖像
- 加入圖片
- 取代圖像
- 圖像集合
- 圖片框架
- 連結圖像
- 背景
- 加入 PNG
- 加入 JPG
- 加入 SVG
- SVG 轉形狀
- 外部 SVG 資源
- PowerPoint
- OpenDocument
- 投影片
- Node.js
- JavaScript
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Node.js via Java 在 PowerPoint 與 OpenDocument 投影片中加入、重複使用、連結、取代與管理點陣圖與 SVG 圖像。"
---
## **簡介**

Aspose.Slides for Node.js via Java 提供了多種處理圖像的方式，每種方式皆有其不同的用途。您可以將圖像儲存在投影片中、在圖片框架中顯示、用作投影片背景、連結至外部圖像、取代共用圖像資源，或將 SVG 內容轉換為可編輯的形狀。

本文章聚焦於圖像資源以及它們在投影片中的使用方式。若需了解對單一圖片框架的裁切、透明度、效果、拉伸等格式設定，請參閱 [圖片框架](/slides/zh-hant/nodejs-java/picture-frame/)。

## **了解圖像模型**

以下 API 概念彼此密切相關，但並不互換：

- The [演示文稿圖像集合](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/imagecollection/) 儲存演示文稿使用的圖像資源。使用 [ImageCollection.addImage](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/imagecollection/) 以加入圖像資料並取得一個 [PPImage](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ppimage/) 資源。
- A [圖片框架](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/pictureframe/) 是在投影片、布局或母片上顯示圖像的形狀。使用 [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/shapecollection/) 來將圖像資源放置於投影片上。
- 投影片背景使用圖像作為投影片填充的一部份，而非作為形狀，因此其行為不同於圖片框架。
- [PPImage.replaceImage](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ppimage/) 可取代圖像資源。若多個演示文稿元素使用該資源，全部都會改為使用取代後的圖像。
- 將 SVG 轉換為形狀會產生可編輯的投影片形狀。轉換完畢後，內容不再以單一圖片資源管理。

典型的工作流程因此為：將圖像資料加入圖像集合，取得一個 [PPImage]，然後在一個或多個圖片框架或填充中使用該資源。

## **新增內嵌圖像**

要插入本機圖像，請載入檔案、將其加入圖像集合，並建立使用返回的 [PPImage] 資源的圖片框架。

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    let image;
    const sourceImage = aspose.slides.Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        if (sourceImage != null) {
            sourceImage.dispose();
        }
    }

    const slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 20, 20, 320, 180, image);

    presentation.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

以此方式加入的圖像會內嵌於演示文稿中，因而最終檔案不依賴原始圖像檔案的可用性。

### **從網路新增圖像**

當圖像可透過 HTTP 或 HTTPS 取得時，下載其位元組、將其加入演示文稿圖像集合，並以與本機圖像相同的方式使用返回的圖像資源。

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const http = require("http");
const https = require("https");
const java = require("java");

function downloadBytes(url) {
    return new Promise((resolve, reject) => {
        const client = url.startsWith("https:") ? https : http;
        client.get(url, (response) => {
            if (response.statusCode < 200 || response.statusCode >= 300) {
                response.resume();
                reject(new Error(`HTTP ${response.statusCode}`));
                return;
            }

            const chunks = [];
            response.on("data", (chunk) => chunks.push(chunk));
            response.on("end", () => resolve(Buffer.concat(chunks)));
        }).on("error", reject);
    });
}

(async () => {
    const imageData = await downloadBytes("https://example.com/image.png");
    const javaBytes = java.newArray("byte", Array.from(imageData));

    const presentation = new aspose.slides.Presentation();
    try {
        const image = presentation.getImages().addImage(javaBytes);
        const slide = presentation.getSlides().get_Item(0);
        slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 20, 20, 320, 180, image);

        presentation.save("presentation-from-web.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
})();
```

在長時間執行的應用程式中，請重複使用 HTTP 用戶端或符合應用需求的連線管理策略，而非反覆建立不必要的網路基礎設施。若來源不受信任，亦請驗證遠端 URL、回應大小與內容類型。

## **跨投影片重複使用圖像**

如果同一圖像需要多次使用，請僅在演示文稿中加入一次，並在建立其他圖片框架時重複使用返回的 [PPImage]。這樣可避免重複載入相同來源資料，並讓共用圖像資源與其使用關係更加明確。

對於需要自動出現在多張投影片上的圖形（例如公司標誌），建議將圖片框架放在 [投影片母片](/slides/zh-hant/nodejs-java/slide-master/) 或布局上，而非在每張投影片中各自新增等效形狀。

## **將圖像作為投影片背景使用**

背景圖像是指派給投影片填充的圖像；它不會以圖片框架形狀的方式加入。這在圖像需要覆蓋整個投影片背景且不應被視為普通投影片物件來操作時非常有用。

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("background.jpg");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        if (sourceImage != null) {
            sourceImage.dispose();
        }
    }

    const backgroundType = java.newByte(aspose.slides.BackgroundType.OwnBackground);
    slide.getBackground().setType(backgroundType);

    const fillType = java.newByte(aspose.slides.FillType.Picture);
    slide.getBackground().getFillFormat().setFillType(fillType);

    slide.getBackground().getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);
    slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().setImage(image);

    presentation.save("background-image.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

如需其他背景選項（包括母片與布局背景），請參閱 [演示文稿背景](/slides/zh-hant/nodejs-java/presentation-background/)。

## **內嵌圖像與連結圖像**

內嵌與連結圖像在可移植性與檔案大小上各有取捨：

- **內嵌圖像**：圖像資料儲存在演示文稿內。演示文稿為自包含檔案，但檔案大小會包含圖像資料。
- **連結圖像**：演示文稿僅儲存指向外部圖像的路徑或 URL。此方式可減少演示文稿大小，但外部資源必須在開啟或轉譯時仍可存取。

可透過 [Picture.setLinkPathLong](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/picture/) 指定外部路徑或 URL，來建立連結圖片，而非內嵌圖像資料。

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 20, 20, 320, 180, null);
    pictureFrame.getPictureFormat().getPicture().setLinkPathLong("https://example.com/image.png");

    presentation.save("linked-image.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

僅在部署環境能可靠存取外部資源時才使用連結圖像。若投影片必須離線使用或在不同系統間搬移，內嵌圖像通常較安全。

## **處理 SVG 圖像**

SVG 為向量格式，適合用於圖示、圖表與其他應該在放大時仍保持細節的圖形。Aspose.Slides 同時支援將 SVG 作為圖像資源與作為可編輯投影片形狀的來源。

### **將 SVG 新增為圖像**

建立一個 [SvgImage](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/svgimage/)，將其加入圖像集合，並在圖片框架中使用產生的圖像資源。

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const fs = require("fs");

const presentation = new aspose.slides.Presentation();
try {
    const svgContent = fs.readFileSync("icon.svg", "utf8");
    const svgImage = new aspose.slides.SvgImage(svgContent);

    const image = presentation.getImages().addImage(svgImage);
    const slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 20, 20, 200, 200, image);

    presentation.save("svg-image.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **具有外部資源的 SVG 檔案**

SVG 可以參照外部圖像、樣式表或字型。針對此類情況，[SvgImage](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/svgimage/) 提供接受 [ExternalResourceResolver](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/externalresourceresolver/) 以及基礎 URI 的建構子。解析器可將相對 URI 映射至允許的絕對 URI，並回傳要求資源的資料流。

解析器在 Aspose.Slides 處理 SVG 時會提供外部資源，但不會將 SVG 重新寫成自包含文件。若 SVG 必須保持可移植，請將所需資源直接嵌入 SVG（例如使用 `data:` URI 連結圖像）。

當 SVG 檔案來自不受信任來源時，請限制解析器可存取的協定、檔案位置與主機。網路解析器亦應套用逾時、回應大小限制與內容驗證。

### **將 SVG 轉換為可編輯形狀**

Aspose.Slides 能將 SVG 轉換為一組可編輯的投影片形狀，類似 PowerPoint 的對應指令。

![PowerPoint 快顯功能表](img_01_01.png)

使用接受 SVG 圖像的 [ShapeCollection.addGroupShape](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/shapecollection/) 重載來執行轉換。

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const fs = require("fs");

const presentation = new aspose.slides.Presentation();
try {
    const svgContent = fs.readFileSync("diagram.svg", "utf8");
    const svgImage = new aspose.slides.SvgImage(svgContent);

    const slideSize = presentation.getSlideSize().getSize();
    const slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addGroupShape(svgImage, 0, 0, slideSize.getWidth(), slideSize.getHeight());

    presentation.save("editable-svg-shapes.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

當需要將個別向量元素編輯為 PowerPoint 形狀時，請使用 SVG 轉形狀的方式。若 SVG 只需顯示，保留為圖像較為簡單，且可避免產生大量獨立形狀。

## **取代現有圖像資源**

當您希望取代已有的圖像資源時，請使用 [PPImage.replaceImage](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ppimage/)。此功能對於共用圖形（如標誌）特別有用。

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const imageToReplace = presentation.getImages().get_Item(0);

    const replacementImage = aspose.slides.Images.fromFile("new-logo.png");
    try {
        imageToReplace.replaceImage(replacementImage);
    } finally {
        if (replacementImage != null) {
            replacementImage.dispose();
        }
    }

    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

如果多個圖片框架、背景、母片或布局使用相同的圖像資源，取代該資源會同時更新所有使用處。若僅需變更單一圖片框架，請為該框架指派不同圖像，而非取代共用資源。

[PPImage.replaceImage](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ppimage/) 亦提供接受位元組陣列或其他 [PPImage] 的重載。

## **實務圖像管理指引**

### **控制演示文稿大小**

大型點陣圖會使演示文稿不必要地變大。請使用符合實際顯示尺寸的來源圖像、盡可能重複使用共用圖像資源，並避免重複嵌入相同的高解析度圖形。

對於已放入圖片框架的點陣圖，您可以使用 [PictureFillFormat.compressImage](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/picturefillformat/) 依所選解析度與裁切設定壓縮圖像資料。此屬於圖片框架處理，而非圖像集合管理，相關格式操作請參閱 [圖片框架](/slides/zh-hant/nodejs-java/picture-frame/)。

### **在內嵌與連結內容之間做選擇**

內嵌可使演示文稿具可移植性，因為所有必要的圖像資料都隨檔案一起攜帶。連結則可減少檔案大小，但會產生外部依賴。僅在該依賴可接受且穩定時才使用連結。

### **重複使用共用品牌圖示**

對於重複出現的標誌、水印或裝飾圖形，請使用單一圖像資源並重複使用。若圖形屬於演示文稿設計而非投影片內容，請將其放在母片或布局上，讓相應的投影片自動繼承。

### **確保 SVG 資源可移植**

自包含的 SVG 較易於搬移且能一致呈現，較不依賴外部檔案或網路資源。若可能，請在匯入 SVG 前將所需資源嵌入。僅在必須編輯個別向量元素時才將 SVG 轉換為形狀。

### **使用現代跨平台圖像 API**

對於新的 Node.js via Java 程式碼，請使用 Aspose.Slides 的 [IImage](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/iimage/) 與 [Images](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/images/) API，取代基於 `java.awt.image.BufferedImage` 的舊版公開 API。遷移指引請參考 [現代 API](/slides/zh-hant/nodejs-java/modern-api/)。

WMF 與 EMF 需特別考量。當這些格式透過 [IImage](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/iimage/) 傳遞時，[ImageCollection.addImage](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/imagecollection/) 會先將中繼檔轉換為點陣 PNG 後插入。若需保留中繼檔資料，請使用接受資料流的 [ImageCollection.addImage](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/imagecollection/) 重載。從試算表或其他產品產生 EMF 內容屬於另一套整合工作流程，本文不予討論。

## **常見問題**

**圖像集合與圖片框架有何差異？**  
圖像集合儲存可重複使用的圖像資源。圖片框架則是投影片上的形狀，用於顯示這些資源，並提供裁切、特效等圖片專屬的格式設定。

**如何一次取代所有相同的標誌？**  
如果標誌已作為單一圖像資源共用，請使用 [PPImage.replaceImage](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ppimage/) 取代該資源。若要在整個演示文稿中維持品牌一致性，也可以將標誌放在母片或布局上，以減少重複的投影片內容。

**為什麼連結圖像在另一台電腦上會消失？**  
連結圖片依賴其外部檔案或 URL。若該資源在其他電腦上無法存取，連結圖像便會不可用。當演示文稿必須自包含時，請將圖像內嵌。

**插入的 SVG 能否編輯為 PowerPoint 形狀？**  
可以。使用 [ShapeCollection.addGroupShape](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/shapecollection/) 轉換 SVG；轉換後的群組會包含可編輯的投影片形狀，而不是單一的 SVG 圖片。

**如何讓包含大量圖像的演示文稿保持較小體積？**  
重複使用共用圖像資源、避免使用過大點陣圖來源、在適當時機壓縮可壓縮的點陣圖、將重複的品牌圖示放在母片或布局上，且僅在外部依賴可接受時才使用連結圖像。
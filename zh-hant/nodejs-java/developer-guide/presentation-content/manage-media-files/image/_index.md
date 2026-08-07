---
title: 使用 JavaScript 優化簡報中的圖片管理
linktitle: 管理圖片
type: docs
weight: 10
url: /zh-hant/nodejs-java/image/
keywords:
- 新增圖片
- 新增圖片
- 新增點陣圖
- 替換圖片
- 替換圖片
- 來自網路
- 背景
- 新增 PNG
- 新增 JPG
- 新增 SVG
- 外部 SVG 資源
- SVG 解析器
- 連結的 SVG 圖片
- SVG 字型
- 新增 EMF
- 新增 WMF
- 新增 TIFF
- PowerPoint
- OpenDocument
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 Aspose.Slides for Node.js via Java，簡化 PowerPoint 與 OpenDocument 的圖片管理，提升效能並自動化工作流程。"
---
## **簡介**

圖片讓簡報更具吸引力且視覺上更佳。在 Microsoft PowerPoint 中，您可以從檔案、網路或其他來源將圖片插入投影片。類似地，Aspose.Slides 也允許您以多種方式將圖片加入簡報投影片。

{{% alert  title="Tip" color="primary" %}} 
Aspose 提供免費的轉換工具——[JPEG to PowerPoint](https://products.aspose.app/slides/zh-hant/import/jpg-to-ppt) 與 [PNG to PowerPoint](https://products.aspose.app/slides/zh-hant/import/png-to-ppt)——讓您能快速從圖片建立簡報。 
{{% /alert %}} 

{{% alert title="Info" color="info" %}}
如果您想將圖片作為圖片框插入——尤其是計畫調整大小、套用效果或使用其他標準格式選項——請參閱 [Picture Frame](/slides/zh-hant/nodejs-java/picture-frame/)。 
{{% /alert %}} 

{{% alert title="Note" color="warning" %}}
您可以將圖片從一種格式轉換為另一種格式。請參考以下頁面：convert [image to JPG](https://products.aspose.com/slides/zh-hant/nodejs-java/conversion/image-to-jpg/)、[JPG to image](https://products.aspose.com/slides/zh-hant/nodejs-java/conversion/jpg-to-image/)、[JPG to PNG](https://products.aspose.com/slides/zh-hant/nodejs-java/conversion/jpg-to-png/)、[PNG to JPG](https://products.aspose.com/slides/zh-hant/nodejs-java/conversion/png-to-jpg/)、[PNG to SVG](https://products.aspose.com/slides/zh-hant/nodejs-java/conversion/png-to-svg/)、以及 [SVG to PNG](https://products.aspose.com/slides/zh-hant/nodejs-java/conversion/svg-to-png/)。 
{{% /alert %}}

Aspose.Slides 支援 JPEG、PNG、BMP、GIF 等常見圖片格式。

## **將本機儲存的圖片加入投影片**

您可以將一或多張儲存在電腦上的圖片加入簡報投影片。下列 JavaScript 範例程式碼說明如何將圖片加入投影片：

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const pres = new aspose.slides.Presentation();
try {
    const slide = pres.getSlides().get_Item(0);

    let picture;
    const image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }

    slide.getShapes().addPictureFrame(
        aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, picture);

    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **將網路圖片加入投影片**

如果您要加入投影片的圖片未儲存在本機，亦可直接從網路加入。下列 JavaScript 範例程式碼說明如何從網路將圖片加入投影片：

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const pres = new aspose.slides.Presentation();
try {
    const slide = pres.getSlides().get_Item(0);

    const imageUrl = java.newInstanceSync("java.net.URL", "[REPLACE WITH URL]");
    const inputStream = imageUrl.openStream();
    try {
        let picture;
        const image = aspose.slides.Images.fromStream(inputStream);
        try {
            picture = pres.getImages().addImage(image);
        } finally {
            if (image != null) {
                image.dispose();
            }
        }

        slide.getShapes().addPictureFrame(
            aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, picture);
    } finally {
        if (inputStream != null) {
            inputStream.close();
        }
    }

    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **將圖片加入投影片母片**

投影片母片儲存並控制使用該母片之投影片的主題與版面配置。當您將圖片加入投影片母片時，該圖片會出現在所有基於該母片的投影片上。下列 JavaScript 範例程式碼說明如何將圖片加入投影片母片：

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const pres = new aspose.slides.Presentation();
try {
    const slide = pres.getSlides().get_Item(0);
    const masterSlide = slide.getLayoutSlide().getMasterSlide();

    let picture;
    const image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }

    masterSlide.getShapes().addPictureFrame(
        aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, picture);

    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **將圖片設定為投影片背景**

您可以將圖片作為一或多張投影片的背景。有關詳細資訊，請參閱 *[Setting Images as Backgrounds for Slides](/slides/zh-hant/nodejs-java/presentation-background/#setting-images-as-background-for-slides)*。

## **將 SVG 加入簡報**

可使用 [SvgImage](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/svgimage/) 類別將 SVG 內容加入簡報。產生的 SVG 圖片物件隨後可加入簡報的 ImageCollection，並用於建立圖片框。

下列 JavaScript 範例匯入一段自包含的 SVG 字串。此 SVG 中使用的所有圖片、樣式與其他資源皆直接嵌入於 SVG 內容中。

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const svgContent =
    "<svg xmlns='http://www.w3.org/2000/svg' width='320' height='180'>" +
    "    <rect width='320' height='180' fill='#4F81BD'/>" +
    "    <circle cx='160' cy='90' r='55' fill='#F2F2F2'/>" +
    "</svg>";

const presentation = new aspose.slides.Presentation();
try {
    const svgImage = new aspose.slides.SvgImage(svgContent);
    const image = presentation.getImages().addImage(svgImage);

    presentation.getSlides().get_Item(0).getShapes().addPictureFrame(
        aspose.slides.ShapeType.Rectangle,
        20, 20, image.getWidth(), image.getHeight(), image);

    presentation.save("self-contained-svg.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **匯入含有外部資源的 SVG 內容**

從設計工具、圖表編輯器、圖示系統或網路管線匯出的 SVG 檔案可能會參考儲存在 SVG 文件之外的資源。例如，SVG 可能包含 `images/photo.png` 的圖片連結、CSS `url(...)` 值，或字型 URL。

要匯入此類 SVG 內容，請提供外部資源解析器，並與基礎 URI 一起傳遞給相應的 [SvgImage](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/svgimage/) 建構函式。基礎 URI 用於識別 SVG 文件的位置，並解析相對連結。

`SvgImage` 類別提供以下資訊存取功能：

- `getSvgContent()` 以字串回傳 SVG 標記。
- `getSvgData()` 以位元組陣列回傳 SVG 內容。
- `getBaseUri()` 以字串回傳用於相對連結的基礎 URI。
- `getExternalResourceResolver()` 以物件回傳指派給 SVG 圖片的解析器。

### **實作外部資源解析器**

此解析器有兩個方法：

- `resolveUri` 結合基礎 URI 與相對資源連結，回傳絕對 URI。若無法解析或不允許，回傳 `null`。
- `getEntity` 以可讀的 Java 串流回傳絕對資源 URI。若資源缺失、被封鎖或無法取得，回傳 `null`。必要時亦可回傳備援串流。

下列輔助程式建立一個僅從允許的本機目錄載入連結資源的解析器。網路資源與目錄外的路徑皆被封鎖。未解析的圖片連結會回傳可選的備援圖片。

```javascript
const fs = require("fs");
const path = require("path");
const java = require("java");
const { fileURLToPath, pathToFileURL } = require("url");

function isInsideAllowedRoot(resourcePath, allowedRoot) {
    const relativePath = path.relative(allowedRoot, resourcePath);

    return relativePath === "" ||
        (relativePath !== ".." &&
         !relativePath.startsWith(".." + path.sep) &&
         !path.isAbsolute(relativePath));
}

function isImageFile(filePath) {
    const extension = path.extname(filePath).toLowerCase();
    return [".png", ".jpg", ".jpeg", ".gif", ".bmp"].includes(extension);
}

function createLocalSvgResourceResolver(allowedRoot, fallbackImageData) {
    const normalizedRoot = path.resolve(allowedRoot);

    return java.newProxy("com.aspose.slides.IExternalResourceResolver", {
        resolveUri: function(baseUri, relativeUri) {
            if (baseUri == null || baseUri.trim() === "" ||
                    relativeUri == null || relativeUri.trim() === "") {
                return null;
            }

            try {
                const absoluteAddress = new URL(relativeUri, baseUri);

                // 此解析器刻意僅允許本機檔案。
                if (absoluteAddress.protocol !== "file:") {
                    return null;
                }

                const resourcePath = path.resolve(fileURLToPath(absoluteAddress));
                if (!isInsideAllowedRoot(resourcePath, normalizedRoot)) {
                    return null;
                }

                return pathToFileURL(resourcePath).href;
            } catch (e) {
                return null;
            }
        },

        getEntity: function(absoluteUri) {
            try {
                const resourceUrl = new URL(absoluteUri);
                if (resourceUrl.protocol !== "file:") {
                    return null;
                }

                const resourcePath = path.resolve(fileURLToPath(resourceUrl));
                if (!isInsideAllowedRoot(resourcePath, normalizedRoot)) {
                    return null;
                }

                if (fs.existsSync(resourcePath)) {
                    return java.newInstanceSync("java.io.FileInputStream", resourcePath);
                }

                // 僅在影像資源時使用備援。回傳影像串流
                // 對缺少的字型或樣式表回傳影像串流是不合法的。
                if (fallbackImageData != null && isImageFile(resourcePath)) {
                    const javaBytes = java.newArray("byte", Array.from(fallbackImageData));
                    return java.newInstanceSync("java.io.ByteArrayInputStream", javaBytes);
                }
            } catch (e) {
                return null;
            }

            return null;
        }
    });
}
```

### **在 SVG 匯入期間解析連結資源**

假設 `assets/diagram.svg` 包含以下相對參考：

```xml
<image href="images/photo.png" x="20" y="20" width="320" height="180" />
```

下列 JavaScript 範例將 SVG 檔案的 URI 作為基礎 URI，並提供自訂解析器。解析器會將相對圖片連結轉換為絕對 URI，並在 Aspose.Slides 處理 SVG 時回傳包含該資源的串流。

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const fs = require("fs");
const path = require("path");
const { pathToFileURL } = require("url");

const svgFilePath = path.resolve("assets", "diagram.svg");
const assetDirectory = path.dirname(svgFilePath);
const svgContent = fs.readFileSync(svgFilePath, "utf8");

// 基礎 URI 代表 SVG 文件的位置。
const baseUri = pathToFileURL(svgFilePath).href;

let fallbackImageData = null;
const fallbackImagePath = path.join(assetDirectory, "fallback.png");
if (fs.existsSync(fallbackImagePath)) {
    fallbackImageData = fs.readFileSync(fallbackImagePath);
}

const resolver = createLocalSvgResourceResolver(assetDirectory, fallbackImageData);
const svgImage = new aspose.slides.SvgImage(svgContent, resolver, baseUri);

// SvgImage 提供來源內容、二進位資料、基礎 URI 與解析器。
const importedContent = svgImage.getSvgContent();
const importedData = svgImage.getSvgData();
const importedBaseUri = svgImage.getBaseUri();
const importedResolver = svgImage.getExternalResourceResolver();

const presentation = new aspose.slides.Presentation();
try {
    const image = presentation.getImages().addImage(svgImage);

    presentation.getSlides().get_Item(0).getShapes().addPictureFrame(
        aspose.slides.ShapeType.Rectangle,
        20, 20, image.getWidth(), image.getHeight(), image);

    presentation.save("svg-with-linked-resources.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`SvgImage` 類別亦提供接受 SVG 位元組陣列的多載，以及接受串流、外部資源解析器與基礎 URI 的工廠方法。

{{% alert title="Important" color="warning" %}}
資源解析器在 Aspose.Slides 處理與渲染 SVG 時，使外部資源可用。它不會修改原始 SVG 標記，也不會自動將已解析的資源嵌入其中。

當 SVG 圖片加入簡報的 ImageCollection 時，PPTX 檔案可能同時包含原始 SVG 表示與點陣備援圖像。連結資源可能出現在產生的備援圖像中，而相對連結如 `images/photo.png` 則保持在儲存的 SVG 中不變。若原始外部資源不可取得，呈現原生 SVG 表示的應用程式可能會省略該連結內容。
{{% /alert %}}

### **建立可攜帶的 SVG 圖片**

若要建立不依賴外部檔案的 SVG 圖片，請在建立 `SvgImage` 前先使 SVG 成為自包含。舉例而言，將連結的圖片 URL 替換為包含圖片資料的 `data:` URI：

```xml
<image href="data:image/png;base64,..." x="20" y="20" width="320" height="180" />
```

在將所有必要資源嵌入 SVG 內容後，建立 `SvgImage`、將其加入簡報的 ImageCollection，並如前例所示插入圖片框。

### **處理缺失或被封鎖的資源**

當資源 URI 無效、被禁止或無法解析時，`resolveUri` 應回傳 `null`。當資源無法讀取時，`getEntity` 應回傳 `null`。Aspose.Slides 會在可能的情況下繼續處理 SVG 而不使用該資源。

對於缺失的資源可回傳備援串流，但其內容必須與請求的資源類型相容。例如，僅在缺少圖片時回傳圖片串流，而非字型或樣式表。

{{% alert title="Security" color="warning" %}}
不要從不受信任的 SVG 檔案解析任意檔案路徑或不受限制的網路 URL。請限制允許的協定、目錄與主機。對於網路資源，亦應套用連線逾時、回應大小限制與內容驗證。
{{% /alert %}}

## **將 SVG 轉換為形狀集合**

Aspose.Slides 可以將 SVG 轉換為形狀集合，功能類似於 PowerPoint：

![PowerPoint Popup Menu](img_01_01.png)

此功能透過 [ShapeCollection](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ShapeCollection) 類別的 [addGroupShape](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ShapeCollection#addGroupShape-aspose.slides.ISvgImage-float-float-float-float-) 方法的多載實作，該方法的第一個參數接受 SVG 圖片物件。

下列 JavaScript 範例說明如何使用此方法將 SVG 檔案轉換為形狀集合：

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const fs = require("fs");
const java = require("java");

// 來源 SVG 檔案名稱。
const svgFileName = "sample.svg";

// 輸出簡報檔案名稱。
const outPptxPath = "presentation.pptx";

// 建立新的簡報。
const presentation = new aspose.slides.Presentation();
try {
    // 讀取 SVG 檔案內容。
    const svgContent = java.newArray("byte", Array.from(fs.readFileSync(svgFileName)));

    // 建立 SvgImage 物件。
    const svgImage = new aspose.slides.SvgImage(svgContent);

    // 取得投影片尺寸。
    const slideSize = presentation.getSlideSize().getSize();

    // 將 SVG 圖片轉換為形狀群組並依投影片尺寸縮放。
    presentation.getSlides().get_Item(0).getShapes().addGroupShape(
        svgImage, 0.0, 0.0, slideSize.getWidth(), slideSize.getHeight());

    // 以 PPTX 格式儲存簡報。
    presentation.save(outPptxPath, aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **將圖片以 EMF 形式加入投影片**

Aspose.Slides for Node.js via Java 允許您使用 Aspose.Cells 從 Excel 工作表產生 EMF 圖片，並將其加入簡報投影片。

下列 JavaScript 範例說明如何執行此操作：

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const book = java.newInstanceSync("aspose.cells.Workbook", "chart.xlsx");
const sheet = book.getWorksheets().get(0);

const options = java.newInstanceSync("aspose.cells.ImageOrPrintOptions");
options.setHorizontalResolution(200);
options.setVerticalResolution(200);
options.setImageType(java.getStaticFieldValue("ImageType", "EMF"));

// 將工作簿儲存至串流。
const sr = java.newInstanceSync("SheetRender", sheet, options);
const pres = new aspose.slides.Presentation();
try {
    pres.getSlides().removeAt(0);

    for (let j = 0; j < sr.getPageCount(); j++) {
        const emfSheetName = "test" + sheet.getName() + " Page" + (j + 1) + ".out.emf";
        sr.toImage(j, emfSheetName);

        // 直接加入檔案，使圖片保留為向量 EMF 而非轉換為點陣圖。
        let picture;
        const imageStream = java.newInstanceSync("java.io.FileInputStream", emfSheetName);
        try {
            picture = pres.getImages().addImage(imageStream);
        } finally {
            imageStream.close();
        }

        const slide = pres.getSlides().addEmptySlide(
            pres.getLayoutSlides().getByType(aspose.slides.SlideLayoutType.Blank));
        slide.getShapes().addPictureFrame(
            aspose.slides.ShapeType.Rectangle,
            0,
            0,
            pres.getSlideSize().getSize().getWidth(),
            pres.getSlideSize().getSize().getHeight(),
            picture);
    }

    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **取代 ImageCollection 中的圖片**

Aspose.Slides 讓您取代儲存在簡報 ImageCollection 中的圖片，包括投影片形狀使用的圖片。本節說明更新集合中圖片的多種方式。您可以使用原始位元組資料、[IImage](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/iimage/) 實例，或已存在於集合中的其他圖片來取代目標圖片。

請依照以下步驟操作：

1. 使用 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/) 類別載入含有圖片的簡報檔案。  
2. 從檔案將新圖片載入為位元組陣列。  
3. 使用位元組陣列將目標圖片換成新圖片。  
4. 在第二種做法中，將圖片載入為 [IImage](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/iimage/) 物件，並以該物件取代目標圖片。  
5. 在第三種做法中，使用已存在於簡報 ImageCollection 中的圖片取代目標圖片。  
6. 將修改後的簡報寫入為 PPTX 檔案。

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const fs = require("fs");
const java = require("java");

// 實例化代表簡報檔案的 Presentation 類別。
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    // 第一種方法。
    const imageData = java.newArray("byte", Array.from(fs.readFileSync("image0.jpeg")));
    let oldImage = presentation.getImages().get_Item(0);
    oldImage.replaceImage(imageData);

    // 第二種方法。
    const newImage = aspose.slides.Images.fromFile("image1.png");
    try {
        oldImage = presentation.getImages().get_Item(1);
        oldImage.replaceImage(newImage);
    } finally {
        if (newImage != null) {
            newImage.dispose();
        }
    }

    // 第三種方法。
    oldImage = presentation.getImages().get_Item(2);
    oldImage.replaceImage(presentation.getImages().get_Item(3));

    // 將簡報儲存至檔案。
    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="Info" color="info" %}}
利用 Aspose 免費的 [Text to GIF](https://products.aspose.app/slides/zh-hant/text-to-gif) 轉換器，您可以輕鬆將文字動畫化並產生 GIF。
{{% /alert %}}

## **常見問題**

**插入後原始圖片解析度是否保持不變？**  
是的。來源像素會被保留，但最終顯示效果取決於投影片上 [picture](/slides/zh-hant/nodejs-java/picture-frame/) 的縮放方式以及儲存時的壓縮情形。

**一次取代大量投影片中的相同商標的最佳方式是什麼？**  
將商標放在母片或版面配置上，並在簡報的 ImageCollection 中取代它——此變更會自動傳遞至所有使用該資源的元件。

**插入的 SVG 能否轉換為可編輯的形狀？**  
可以。您可以將 SVG 轉換為形狀群組，之後各個部分即可透過標準形狀屬性進行編輯。

**如何一次為多張投影片設定相同的背景圖片？**  
在母片或相關版面配置上 [Assign the image as the background](/slides/zh-hant/nodejs-java/presentation-background/)，使用該母片/版面的投影片皆會繼承背景。

**如何防止因過多圖片導致簡報檔案過大？**  
重複使用單一圖片資源而非副本，選擇合理的解析度，儲存時使用壓縮，並在適當情況下將重複圖形放在母片上。
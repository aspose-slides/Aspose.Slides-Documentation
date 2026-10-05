---
title: 使用 JavaScript 管理簡報中的 OLE
linktitle: 管理 OLE
type: docs
weight: 40
url: /zh-hant/nodejs-java/manage-ole/
keywords:
- OLE 物件
- 物件連結與嵌入
- 新增 OLE
- 嵌入 OLE
- 新增物件
- 嵌入物件
- 新增檔案
- 嵌入檔案
- 已連結物件
- 已連結檔案
- 變更 OLE
- OLE 圖示
- OLE 標題
- 擷取 OLE
- 擷取物件
- 擷取檔案
- PowerPoint
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 Aspose.Slides for Node.js via Java，優化 PowerPoint 與 OpenDocument 檔案中的 OLE 物件管理。輕鬆嵌入、更新與匯出 OLE 內容。"
---
## **簡介**

{{% alert color="info" title="Note" %}}

OLE（Object Linking & Embedding）是 Microsoft 的技術，允許在一個應用程式中建立的資料與物件透過連結或嵌入的方式放置於另一個應用程式中。 

{{% /alert %}} 

考慮在 Microsoft Excel 中建立的圖表，該圖表隨後被放入 PowerPoint 投影片中。此 Excel 圖表即被視為 OLE 物件。 

- OLE 物件可能顯示為圖示。在此情況下，當您雙擊圖示時，圖表會在其相關的應用程式（Excel）中開啟，或會要求您選擇開啟或編輯物件的應用程式。
- OLE 物件也可能直接顯示其實際內容，例如圖表的內容。在此情況下，圖表會在 PowerPoint 中被啟用，圖表介面會載入，您可以在 PowerPoint 內修改圖表的資料。

[Aspose.Slides for Node.js via Java](https://products.aspose.com/slides/nodejs-java/) allows you to insert OLE Objects into slides as OLE object frames ([OleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/OleObjectFrame)).

## **將 OLE 物件框架加入投影片**

假設您已在 Microsoft Excel 中建立圖表，並希望使用 Aspose.Slides for Node.js via Java 將其以 OLE 物件框架的形式嵌入投影片中，您可以這樣做：

1. 建立 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) 類別的實例。  
1. 透過索引取得投影片的參考。  
1. 將 Excel 檔案讀取為位元組陣列。  
1. 將 [OleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/OleObjectFrame) 加入投影片，其中包含位元組陣列以及其他 OLE 物件資訊。  
1. 將修改後的簡報寫入為 PPTX 檔案。  

以下範例示範，我們使用 Aspose.Slides for Node.js via Java 將 Excel 檔案中的圖表加入投影片，作為 OLE 物件框架。**注意**，[OleEmbeddedDataInfo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/OleEmbeddedDataInfo) 建構函式接受可嵌入物件的副檔名作為第二個參數。此副檔名讓 PowerPoint 能正確辨識檔案類型，並選擇適當的應用程式開啟此 OLE 物件。

```javascript
const asposeSlides = require("aspose.slides.via.java");
const fs = require("fs");
const java = require("java");

var presentation = new asposeSlides.Presentation();
var slideSize = presentation.getSlideSize().getSize();
var slide = presentation.getSlides().get_Item(0);

// Prepare data for the OLE object.
var oleStream = fs.readFileSync("book.xlsx");
var fileData = Array.from(oleStream);
var dataInfo = new asposeSlides.OleEmbeddedDataInfo(java.newArray("byte", fileData), "xlsx");

// Add the OLE object frame to the slide.
slide.getShapes().addOleObjectFrame(0, 0, slideSize.getWidth(), slideSize.getHeight(), dataInfo);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

### **新增已連結的 OLE 物件框架**

Aspose.Slides for Node.js via Java 允許您新增一個 [OleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/OleObjectFrame)，不嵌入資料，而僅以檔案的連結方式加入。

以下 JavaScript 程式碼示範如何將帶有連結 Excel 檔案的 [OleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/OleObjectFrame) 加入投影片：

```javascript
const asposeSlides = require("aspose.slides.via.java");

var presentation = new asposeSlides.Presentation();
var slide = presentation.getSlides().get_Item(0);

// 新增帶有連結 Excel 檔案的 OLE 物件框架。
slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **存取 OLE 物件框架**

如果 OLE 物件已嵌入於投影片中，您可以這樣輕鬆找出或存取它：

1. 透過建立 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) 類別的實例，載入包含嵌入式 OLE 物件的簡報。  
2. 使用索引取得投影片的參照。  
3. 存取 [OleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/OleObjectFrame) 形狀。在本例中，我們使用先前建立的、第一張投影片上僅有一個形狀的 PPTX。  
4. 一旦取得 OLE 物件框架，即可對其執行任何操作。  

以下範例示範，存取 OLE 物件框架（嵌入投影片的 Excel 圖表物件）以及其檔案資料。

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);
var shape = slide.getShapes().get_Item(0);

if (java.instanceOf(shape, "com.aspose.slides.OleObjectFrame")) {
    var oleFrame = shape;
    
    // 取得嵌入檔案的資料。
    var fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

    // 取得嵌入檔案的副檔名。
    var fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();

    // ...
}
```

### **存取已連結 OLE 物件框架屬性**

Aspose.Slides 允許您存取已連結 OLE 物件框架的屬性。

以下 JavaScript 程式碼示範如何檢查 OLE 物件是否已連結，並取得連結檔案的路徑：

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation("sample.ppt");
var slide = presentation.getSlides().get_Item(0);
var shape = slide.getShapes().get_Item(0);

if (java.instanceOf(shape, "com.aspose.slides.OleObjectFrame")) {
    var oleFrame = shape;

    // 檢查 OLE 物件是否已連結。
    if (oleFrame.isObjectLink()) {
        // 輸出連結檔案的完整路徑。
        console.log("OLE object frame is linked to:", oleFrame.getLinkPathLong());

        // 若存在，輸出連結檔案的相對路徑。
        // 僅 PPT 簡報能包含相對路徑。
        if (oleFrame.getLinkPathRelative() != null && oleFrame.getLinkPathRelative() != "") {
            console.log("OLE object frame relative path:", oleFrame.getLinkPathRelative());
        }
    }
}

presentation.dispose();
```

## **變更 OLE 物件資料**

{{% alert color="info" title="Note" %}}

在本節中，以下程式碼範例使用 [Aspose.Cells for Java](https://docs.aspose.com/cells/java/)。

{{% /alert %}}

如果 OLE 物件已嵌入於投影片中，您可以這樣存取該物件並修改其資料：

1. 透過建立 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) 類別的實例，載入包含嵌入式 OLE 物件的簡報。  
2. 透過索引取得投影片的參考。  
3. 存取 OLE 物件框架形狀。在本例中，我們使用先前建立的、第一張投影片上有一個形狀的 PPTX。  
4. 一旦取得 OLE 物件框架，即可對其執行任何操作。  
5. 建立 `Workbook` 物件並存取 OLE 資料。  
6. 取得目標 `Worksheet` 並修改資料。  
7. 將更新後的 `Workbook` 儲存至串流。  
8. 從串流變更 OLE 物件資料。  

以下範例示範，取得 OLE 物件框架（嵌入投影片的 Excel 圖表物件），並修改其檔案資料以更新圖表資料。

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);
var shape = slide.getShapes().get_Item(0);

if (java.instanceOf(shape, "com.aspose.slides.OleObjectFrame")) {
    var oleFrame = shape;

    var embeddedData = Array.from(oleFrame.getEmbeddedData().getEmbeddedFileData());
    var oleStream = java.newInstanceSync("java.io.ByteArrayInputStream", java.newArray("byte", embeddedData));

    // 以 Workbook 物件讀取 OLE 物件資料。
    var workbook = java.newInstanceSync("com.aspose.cells.Workbook", oleStream);

    var newOleStream = java.newInstanceSync("java.io.ByteArrayOutputStream");

    // 修改 workbook 資料。
    workbook.getWorksheets().get(0).getCells().get(0, 4).putValue("E");
    workbook.getWorksheets().get(0).getCells().get(1, 4).putValue(12);
    workbook.getWorksheets().get(0).getCells().get(2, 4).putValue(14);
    workbook.getWorksheets().get(0).getCells().get(3, 4).putValue(15);

    var fileOptions = java.newInstanceSync("com.aspose.cells.OoxmlSaveOptions", java.getStaticFieldValue("com.aspose.cells.SaveFormat", "XLSX"));
    workbook.save(newOleStream, fileOptions);

    // 變更 OLE 框架物件資料。
    var newFileData = java.newArray("byte", Array.from(newOleStream.toByteArray()));
    var newData = new asposeSlides.OleEmbeddedDataInfo(newFileData, oleFrame.getEmbeddedData().getEmbeddedFileExtension());
    oleFrame.setEmbeddedData(newData);

    newOleStream.close();
    oleStream.close();
}

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **在投影片中嵌入其他檔案類型**

除了 Excel 圖表之外，Aspose.Slides for Node.js via Java 也允許您在投影片中嵌入其他類型的檔案。例如，您可以將 HTML、PDF 與 ZIP 檔案作為物件插入。當使用者雙擊插入的物件時，系統會自動以相應的程式開啟，或會提示使用者選擇適當的程式來開啟它。

以下 JavaScript 程式碼示範如何將 HTML 與 ZIP 嵌入投影片：

```javascript
const asposeSlides = require("aspose.slides.via.java");
const fs = require("fs");
const java = require("java");

var presentation = new asposeSlides.Presentation();
var slide = presentation.getSlides().get_Item(0);

var htmlBuffer = fs.readFileSync("sample.html");
var htmlData = Array.from(htmlBuffer);
var htmlDataInfo = new asposeSlides.OleEmbeddedDataInfo(java.newArray("byte", htmlData), "html");
var htmlOleFrame = slide.getShapes().addOleObjectFrame(150, 120, 50, 50, htmlDataInfo);
htmlOleFrame.setObjectIcon(true);

var zipBuffer = fs.readFileSync("sample.zip");
var zipData = Array.from(zipBuffer);
var zipDataInfo = new asposeSlides.OleEmbeddedDataInfo(java.newArray("byte", zipData), "zip");
var zipOleFrame = slide.getShapes().addOleObjectFrame(150, 220, 50, 50, zipDataInfo);
zipOleFrame.setObjectIcon(true);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **設定嵌入物件的檔案類型**

在處理簡報時，您可能需要將舊的 OLE 物件取代為新的，或將不支援的 OLE 物件換成支援的。Aspose.Slides for Node.js via Java 允許您設定嵌入物件的檔案類型，從而更新 OLE 框架資料或其副檔名。

以下 JavaScript 程式碼示範如何將嵌入的 OLE 物件檔案類型設定為 `zip`：

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);
var oleFrame = slide.getShapes().get_Item(0);

var fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();
var oleFileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

console.log("Current embedded file extension is:", fileExtension);

// 變更檔案類型為 ZIP.
var fileData = java.newArray("byte", Array.from(oleFileData));
oleFrame.setEmbeddedData(new asposeSlides.OleEmbeddedDataInfo(fileData, "zip"));

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **設定嵌入物件的圖示影像與標題**

嵌入 OLE 物件後，系統會自動加入由圖示影像組成的預覽。此預覽即是使用者在存取或開啟 OLE 物件前所看到的畫面。若您希望在預覽中使用特定的影像與文字作為元素，可透過 Aspose.Slides for Node.js via Java 設定圖示影像與標題。

以下 JavaScript 程式碼示範如何為嵌入的物件設定圖示影像與標題：

```javascript
const asposeSlides = require("aspose.slides.via.java");

var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);
var oleFrame = slide.getShapes().get_Item(0);

// 新增影像至簡報資源。
var image = asposeSlides.Images.fromFile("image.png");
var oleImage = presentation.getImages().addImage(image);
image.dispose();

// 設定 OLE 預覽的標題與影像。
oleFrame.setSubstitutePictureTitle("My title");
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(true);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **防止 OLE 物件框架被調整大小或重新定位**

在將已連結的 OLE 物件加入簡報投影片後，若於 PowerPoint 開啟簡報，可能會看到要求更新連結的訊息。點選「Update Links」按鈕可能會因 PowerPoint 從已連結的 OLE 物件更新資料並重新整理預覽，而導致 OLE 物件框架的大小與位置改變。若要阻止 PowerPoint 提示更新物件資料，請以 `false` 呼叫 [setUpdateAutomatic](https://reference.aspose.com/slides/nodejs-java/aspose.slides/oleobjectframe/#setUpdateAutomatic) 方法（屬於 [OleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/oleobjectframe/) 類別）：

```javascript
const asposeSlides = require("aspose.slides.via.java");

var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);
var oleFrame = slide.getShapes().get_Item(0);

oleFrame.setUpdateAutomatic(false);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **擷取嵌入的檔案**

Aspose.Slides for Node.js via Java 允許您以以下方式擷取投影片中以 OLE 物件嵌入的檔案：

1. 建立包含欲擷取之 OLE 物件的 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) 類別實例。  
2. 遍歷簡報中的所有形狀，並存取 [OLEObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/oleobjectframe) 形狀。  
3. 從 OLE 物件框架取得嵌入檔案的資料，並寫入磁碟。  

以下 JavaScript 程式碼示範如何將投影片中以 OLE 物件嵌入的檔案擷取出來：

```javascript
const asposeSlides = require("aspose.slides.via.java");
const fs = require("fs");
const java = require("java");

var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);

for (var index = 0; index < slide.getShapes().size(); index++) {
    var shape = slide.getShapes().get_Item(index);

    if (java.instanceOf(shape, "com.aspose.slides.OleObjectFrame")) {
        var oleFrame = shape;

        var fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();
        var fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();

        var filePath = "OLE_object_" + index + fileExtension;
        fs.writeFileSync(filePath, Buffer.from(fileData));
    }
}

presentation.dispose();
```

## **常見問題**

**在將投影片匯出為 PDF/圖像時，會呈現 OLE 內容嗎？**

投影片上可見的內容會被渲染——即圖示/替代圖像（預覽）。「即時」的 OLE 內容不會在渲染過程中執行。若有需要，請自行設定預覽圖像，以確保匯出 PDF 後的外觀如預期。  
若同時要將嵌入的檔案保留為 PDF 附件，請以 `true` 呼叫 [setIncludeOleData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/#setIncludeOleData)。此選項預設為停用。欲參考範例與檢查附件的說明，請見 [Preserve Embedded OLE Files as PDF Attachments](/slides/zh-hant/nodejs-java/convert-powerpoint-to-pdf/#preserve-embedded-ole-files-as-pdf-attachments)。

**如何在投影片上鎖定 OLE 物件，使使用者在 PowerPoint 中無法移動/編輯？**

鎖定形狀：Aspose.Slides 提供形狀層級的鎖定功能。這並非加密，但可有效防止意外的編輯與移動。

**在 PPTX 格式中，已連結 OLE 物件的相對路徑會被保留嗎？**

在 PPTX 中，並未保留「相對路徑」資訊——僅有完整路徑。相對路徑僅存在於舊版 PPT 格式。為了可移植性，建議使用可靠的絕對路徑/可存取的 URI，或直接嵌入檔案。
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
- 新增 物件
- 嵌入 物件
- 新增 檔案
- 嵌入 檔案
- 已連結 物件
- 已連結 檔案
- 變更 OLE
- OLE 圖示
- OLE 標題
- 提取 OLE
- 提取 物件
- 提取 檔案
- PowerPoint
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 Aspose.Slides for Node.js via Java 優化在 PowerPoint 和 OpenDocument 檔案中的 OLE 物件管理。無縫地嵌入、更新與匯出 OLE 內容。"
---
## **簡介**

{{% alert color="primary" %}} 
OLE（Object Linking & Embedding）是 Microsoft 的技術，允許在一個應用程式中建立的資料和物件透過連結或嵌入的方式放置到另一個應用程式中。 
{{% /alert %}} 

以在 Microsoft Excel 中建立的圖表為例。此圖表隨後被放入 PowerPoint 投影片中。該 Excel 圖表即被視為 OLE 物件。 

- OLE 物件可能會以圖示的形式顯示。此時，雙擊圖示會在其關聯的應用程式（Excel）中開啟圖表，或會要求您選擇用於開啟或編輯物件的應用程式。 
- OLE 物件也可能直接顯示實際內容，例如圖表的內容。此時，圖表會在 PowerPoint 中被啟動，圖表介面載入，您即可在 PowerPoint 內修改圖表資料。 

[Aspose.Slides for Node.js via Java](https://products.aspose.com/slides/zh-hant/nodejs-java/) 允許您將 OLE 物件插入投影片中作為 OLE 物件框架（[OleObjectFrame](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/OleObjectFrame)）。 

## **在投影片中新增 OLE 物件框架**

假設您已在 Microsoft Excel 中建立圖表，且希望使用 Aspose.Slides for Node.js via Java 將其嵌入投影片作為 OLE 物件框架，您可以這樣做：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Presentation) 類別的實例。  
2. 透過索引取得投影片的參考。  
3. 將 Excel 檔案讀取為位元組陣列。  
4. 將含有位元組陣列及其他 OLE 物件資訊的 [OleObjectFrame](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/OleObjectFrame) 新增至投影片。  
5. 將修改後的簡報寫入為 PPTX 檔案。  

在下方範例中，我們使用 Aspose.Slides for Node.js via Java 將 Excel 檔案中的圖表新增為投影片的 OLE 物件框架。  
**注意**，[OleEmbeddedDataInfo](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/OleEmbeddedDataInfo) 建構函式將可嵌入物件的副檔名作為第二個參數。此副檔名讓 PowerPoint 能正確辨識檔案類型並選擇正確的應用程式開啟此 OLE 物件。 

```javascript
var presentation = new asposeSlides.Presentation();
var slideSize = presentation.getSlideSize().getSize();
var slide = presentation.getSlides().get_Item(0);

// 為 OLE 物件準備資料。
var oleStream = fs.readFileSync("book.xlsx");
var fileData = Array.from(oleStream);
var dataInfo = new asposeSlides.OleEmbeddedDataInfo(java.newArray("byte", fileData), "xlsx");

// 將 OLE 物件框架新增至投影片。
slide.getShapes().addOleObjectFrame(0, 0, slideSize.getWidth(), slideSize.getHeight(), dataInfo);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

### **新增連結的 OLE 物件框架**

Aspose.Slides for Node.js via Java 允許您新增一個不嵌入資料、僅以檔案連結方式的 [OleObjectFrame](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/OleObjectFrame)。  

以下 JavaScript 程式碼示範如何將帶有連結 Excel 檔案的 [OleObjectFrame](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/OleObjectFrame) 新增至投影片： 

```javascript
var presentation = new asposeSlides.Presentation();
var slide = presentation.getSlides().get_Item(0);

// 新增一個連結 Excel 檔案的 OLE 物件框架。
slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **存取 OLE 物件框架**

如果投影片中已嵌入 OLE 物件，您可以這樣輕鬆找到或存取它：

1. 透過建立 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Presentation) 類別的實例，載入含有嵌入 OLE 物件的簡報。  
2. 使用索引取得投影片的參考。  
3. 存取 [OleObjectFrame] 形狀。在本範例中，我們使用先前建立的、第一張投影片僅有一個形狀的 PPTX。  
4. 取得 OLE 物件框架後，即可對其執行任何操作。  

在下方範例中，存取了一個 OLE 物件框架（嵌入於投影片中的 Excel 圖表物件）以及其檔案資料。 

```javascript
var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);
var shape = slide.getShapes().get_Item(0);

if (java.instanceOf(shape, "com.aspose.slides.OleObjectFrame")) {
    var oleFrame = shape;
    
    // 取得嵌入檔案資料。
    var fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

    // 取得嵌入檔案的副檔名。
    var fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();

    // ...
}
```

### **存取連結 OLE 物件框架屬性**

Aspose.Slides 讓您能存取連結 OLE 物件框架的屬性。  

以下 JavaScript 程式碼說明如何檢查 OLE 物件是否為連結，並取得連結檔案的路徑： 

```javascript
var presentation = new asposeSlides.Presentation("sample.ppt");
var slide = presentation.getSlides().get_Item(0);
var shape = slide.getShapes().get_Item(0);

if (java.instanceOf(shape, "com.aspose.slides.OleObjectFrame")) {
    var oleFrame = shape;

    // 檢查 OLE 物件是否為連結。
    if (oleFrame.isObjectLink()) {
        // 列印連結檔案的完整路徑。
        console.log("OLE object frame is linked to:", oleFrame.getLinkPathLong());

        // 列印連結檔案的相對路徑（如果存在）。
        // 只有 PPT 簡報可以包含相對路徑。
        if (oleFrame.getLinkPathRelative() != null && oleFrame.getLinkPathRelative() != "") {
            console.log("OLE object frame relative path:", oleFrame.getLinkPathRelative());
        }
    }
}

presentation.dispose();
```

## **變更 OLE 物件資料**

{{% alert color="primary" %}} 
在本節中，以下程式碼範例使用 [Aspose.Cells for Java](/cells/java/)。 
{{% /alert %}} 

如果投影片已嵌入 OLE 物件，您可以這樣輕鬆存取該物件並修改其資料：

1. 透過建立 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Presentation) 類別的實例，載入含有嵌入 OLE 物件的簡報。  
2. 透過索引取得投影片的參考。  
3. 存取 OLE 物件框架形狀。在本範例中，我們使用先前建立的、第一張投影片僅有一個形狀的 PPTX。  
4. 取得 OLE 物件框架後，即可對其執行任何操作。  
5. 建立 `Workbook` 物件並存取 OLE 資料。  
6. 取得目標 `Worksheet` 並修改資料。  
7. 將更新後的 `Workbook` 儲存至串流中。  
8. 從串流變更 OLE 物件資料。  

在下方範例中，存取了一個 OLE 物件框架（嵌入於投影片中的 Excel 圖表物件），並修改其檔案資料以更新圖表資料。 

```javascript
var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);
var shape = slide.getShapes().get_Item(0);

if (java.instanceOf(shape, "com.aspose.slides.OleObjectFrame")) {
    var oleFrame = shape;

    var oleStream = java.newInstanceSync("java.io.ByteArrayInputStream", oleFrame.getEmbeddedData().getEmbeddedFileData());

    // 將 OLE 物件資料讀取為 Workbook 物件。
    var workbook = java.newInstanceSync("Workbook", oleStream);

    var newOleStream = java.newInstanceSync("java.io.ByteArrayOutputStream");

    // 修改 Workbook 資料。
    workbook.getWorksheets().get(0).getCells().get(0, 4).putValue("E");
    workbook.getWorksheets().get(0).getCells().get(1, 4).putValue(12);
    workbook.getWorksheets().get(0).getCells().get(2, 4).putValue(14);
    workbook.getWorksheets().get(0).getCells().get(3, 4).putValue(15);

    var fileOptions = java.newInstanceSync("OoxmlSaveOptions", java.getStaticFieldValue("com.aspose.cells.SaveFormat", "XLSX"));
    workbook.save(newOleStream, fileOptions);

    // 變更 OLE 框架物件資料。
    var newData = new asposeSlides.OleEmbeddedDataInfo(newOleStream.toByteArray(), oleFrame.getEmbeddedData().getEmbeddedFileExtension());
    oleFrame.setEmbeddedData(newData);

    newOleStream.close();
    oleStream.close();
}

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **在投影片中嵌入其他檔案類型**

除了 Excel 圖表外，Aspose.Slides for Node.js via Java 還允許您將其他類型的檔案嵌入投影片。例如，您可以將 HTML、PDF、ZIP 檔案作為物件插入。使用者雙擊已插入的物件時，會自動在相關程式中開啟，或提示使用者選擇適當的程式來開啟它。  

以下 JavaScript 程式碼示範如何將 HTML 與 ZIP 嵌入投影片： 

```javascript
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

在處理簡報時，您可能需要將舊的 OLE 物件替換為新物件，或將不支援的 OLE 物件換成支援的。Aspose.Slides for Node.js via Java 允許您設定嵌入物件的檔案類型，以便更新 OLE 框架資料或其副檔名。  

以下 JavaScript 程式碼示範如何將嵌入的 OLE 物件檔案類型設定為 `zip`： 

```javascript
var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);
var oleFrame = slide.getShapes().get_Item(0);

var fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();
var oleFileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

console.log("Current embedded file extension is:", fileExtension);

// Change the file type to ZIP.
var fileData = java.newArray("byte", Array.from(oleFileData));
oleFrame.setEmbeddedData(new asposeSlides.OleEmbeddedDataInfo(fileData, "zip"));

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **設定嵌入物件的圖示圖片與標題**

嵌入 OLE 物件後，系統會自動新增由圖示圖片組成的預覽。此預覽即是使用者在存取或開啟 OLE 物件前所看到的畫面。若您想在預覽中使用特定的圖片與文字，可透過 Aspose.Slides for Node.js via Java 設定圖示圖片與標題。  

以下 JavaScript 程式碼示範如何為嵌入的物件設定圖示圖片與標題： 

```javascript
var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);
var oleFrame = slide.getShapes().get_Item(0);

// 將影像新增至簡報資源。
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

## **防止 OLE 物件框架被重新調整大小與重新定位**

在投影片中新增連結的 OLE 物件後，若在 PowerPoint 中開啟簡報，可能會出現要求更新連結的訊息。點擊「Update Links」按鈕可能會因 PowerPoint 從連結的 OLE 物件更新資料並重新整理預覽，而改變 OLE 物件框架的大小與位置。為防止 PowerPoint 提示更新物件資料，可使用 [OleObjectFrame](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/oleobjectframe/) 類別的 `setUpdateAutomatic` 方法，並將值設為 `false`： 

```javascript
oleFrame.setUpdateAutomatic(false);
```

## **擷取嵌入的檔案**

Aspose.Slides for Node.js via Java 允許您以以下方式擷取投影片中嵌入為 OLE 物件的檔案：

1. 建立包含欲擷取之 OLE 物件的 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Presentation) 類別實例。  
2. 遍歷簡報中的所有形狀，存取 [OLEObjectFrame] 形狀。  
3. 從 OLE 物件框架取得嵌入檔案的資料，並寫入磁碟。  

以下 JavaScript 程式碼示範如何將投影片中以 OLE 物件形式嵌入的檔案擷取出來： 

```javascript
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

**在將投影片匯出為 PDF/影像時，會渲染 OLE 內容嗎？**  
投影片上可見的內容會被渲染——即圖示/替代影像（預覽）。在渲染過程中不會執行「即時」的 OLE 內容。如有需要，請自行設定預覽圖片，以確保匯出 PDF 時呈現預期的外觀。  

**如何在投影片上鎖定 OLE 物件，使使用者在 PowerPoint 中無法移動或編輯？**  
鎖定形狀：Aspose.Slides 提供形狀層級的鎖定功能。這不是加密，但能有效避免誤編輯與移動。  

**在 PPTX 格式中，連結 OLE 物件的相對路徑會被保留嗎？**  
在 PPTX 中不會保留「相對路徑」資訊——僅有完整路徑。相對路徑僅存在於舊版 PPT 格式。為提升可攜性，建議使用可靠的絕對路徑、可存取的 URI，或直接嵌入檔案。
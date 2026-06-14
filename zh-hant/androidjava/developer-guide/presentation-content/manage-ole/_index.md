---
title: 在 Android 上管理簡報中的 OLE
linktitle: 管理 OLE
type: docs
weight: 40
url: /zh-hant/androidjava/manage-ole/
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
- Android
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Android via Java，優化在 PowerPoint 與 OpenDocument 檔案中的 OLE 物件管理。無縫嵌入、更新與匯出 OLE 內容。"
---
## **簡介**

{{% alert color="primary" %}} 

OLE（Object Linking & Embedding）是一項 Microsoft 技術，可讓在某個應用程式中建立的資料與物件，透過鏈結或嵌入的方式放置於其他應用程式中。

{{% /alert %}} 

想像在 MS Excel 中建立的圖表，隨後將該圖表放入 PowerPoint 投影片中。此 Excel 圖表即視為 OLE 物件。

- OLE 物件可能顯示為圖示。在此情況下，雙擊圖示會在其關聯的應用程式（Excel）中開啟圖表，或會要求您選取用於開啟或編輯物件的應用程式。
- OLE 物件也可能顯示實際內容，例如圖表的內容。在此情況下，圖表會在 PowerPoint 中被啟動，圖表介面載入，您即可在 PowerPoint 內修改圖表資料。

[Aspose.Slides for Android via Java](https://products.aspose.com/slides/zh-hant/androidjava/) 允許您將 OLE 物件插入投影片中作為 OLE 物件框架（[OleObjectFrame](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/OleObjectFrame)）。

## **將 OLE 物件框架新增至投影片**

假設您已在 Microsoft Excel 中建立圖表，並希望使用 Aspose.Slides for Android via Java 將其嵌入投影片作為 OLE 物件框架，您可以這樣做：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/Presentation) 類別的實例。
1. 透過索引取得投影片的參考。
1. 將 Excel 檔案讀取為位元組陣列。
1. 將包含位元組陣列及其他 OLE 物件資訊的 [OleObjectFrame](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/OleObjectFrame) 新增至投影片。
1. 將修改後的簡報寫入為 PPTX 檔案。

以下範例示範，使用 Aspose.Slides for Android via Java 將 Excel 檔案中的圖表新增為投影片的 OLE 物件框架。**注意**，[OleEmbeddedDataInfo](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/OleEmbeddedDataInfo) 建構函式接受可嵌入物件的副檔名作為第二個參數。此副檔名讓 PowerPoint 能正確辨識檔案類型並選擇適當的應用程式開啟此 OLE 物件。

```java
Presentation presentation = new Presentation();
SizeF slideSize = presentation.getSlideSize().getSize();
ISlide slide = presentation.getSlides().get_Item(0);

// 為 OLE 物件準備資料。
File file = new File("book.xlsx");
byte fileData[] = new byte[(int) file.length()];
BufferedInputStream bis = new BufferedInputStream(new FileInputStream(file));
DataInputStream dis = new DataInputStream(bis);
dis.readFully(fileData);

IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(fileData, "xlsx");

// 將 OLE 物件框架新增至投影片。
slide.getShapes().addOleObjectFrame(0, 0, slideSize.getWidth(), slideSize.getHeight(), dataInfo);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

### **新增已連結的 OLE 物件框架**

Aspose.Slides for Android via Java 允許您新增一個不嵌入資料、僅以檔案連結方式的 [OleObjectFrame](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/OleObjectFrame)。

以下 Java 程式碼示範如何將帶有連結 Excel 檔案的 [OleObjectFrame](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/OleObjectFrame) 新增至投影片：

```java
Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// 新增具有已連結 Excel 檔案的 OLE 物件框架。
slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **存取 OLE 物件框架**

如果投影片中已嵌入 OLE 物件，您可以透過以下方式輕鬆尋找或存取它：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/Presentation) 類別的實例，以載入包含嵌入 OLE 物件的簡報。
2. 使用索引取得投影片的參考。
3. 存取 [OleObjectFrame](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/OleObjectFrame) 形狀。
   在本例中，我們使用先前建立的 PPTX，該 PPTX 的第一張投影片僅有一個形狀。接著將該物件 *轉型* 為 [IOleObjectFrame](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ioleobjectframe/)。此即為欲存取的 OLE 物件框架。
4. 取得 OLE 物件框架後，您即可對其執行任何操作。

以下範例示範如何存取 OLE 物件框架（嵌入投影片的 Excel 圖表物件）及其檔案資料。

```java 
Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;
    
    // 取得嵌入檔案資料。
    byte[] fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

    // 取得嵌入檔案的副檔名。
    String fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();

    // ...
}
```

### **存取已連結 OLE 物件框架屬性**

Aspose.Slides 允許您存取已連結 OLE 物件框架的屬性。

以下 Java 程式碼示範如何檢查 OLE 物件是否已連結，並取得連結檔案的路徑：

```java
Presentation presentation = new Presentation("sample.ppt");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;

    // 檢查 OLE 物件是否已連結。
    if (oleFrame.isObjectLink()) {
        // 輸出連結檔案的完整路徑。
        System.out.println("OLE object frame is linked to: " + oleFrame.getLinkPathLong());

        // 輸出連結檔案的相對路徑（如果存在）。
        // 只有 PPT 簡報可以包含相對路徑。
        if (oleFrame.getLinkPathRelative() != null && !oleFrame.getLinkPathRelative().isEmpty()) {
            System.out.println("OLE object frame relative path: " + oleFrame.getLinkPathRelative());
        }
    }
}

presentation.dispose();
```

## **變更 OLE 物件資料**

{{% alert color="primary" %}} 

在本節中，下方的程式碼範例使用 [Aspose.Cells for Android via Java](/cells/androidjava/)。

{{% /alert %}}

如果投影片中已嵌入 OLE 物件，您可以透過以下方式輕鬆存取該物件並修改其資料：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/Presentation) 類別的實例，以載入包含嵌入 OLE 物件的簡報。
2. 透過索引取得投影片的參考。
3. 存取 OLE 物件框架形狀。
   在本例中，我們使用先前建立的 PPTX，該 PPTX 的第一張投影片僅有一個形狀。我們將該物件 *轉型* 為 [IOleObjectFrame](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ioleobjectframe/)。此即為欲存取的 OLE 物件框架。
4. 取得 OLE 物件框架後，您即可對其執行任何操作。
5. 建立 `Workbook` 物件並存取 OLE 資料。
6. 取得目標 `Worksheet` 並修改資料。
7. 將更新後的 `Workbook` 儲存至串流。
8. 從串流變更 OLE 物件資料。

以下範例示範存取 OLE 物件框架（嵌入投影片的 Excel 圖表物件），並修改其檔案資料以更新圖表資料。

```java 
Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;

    ByteArrayInputStream oleStream = new ByteArrayInputStream(oleFrame.getEmbeddedData().getEmbeddedFileData());

    // 以 Workbook 物件讀取 OLE 物件資料。
    Workbook workbook = new Workbook(oleStream);

    ByteArrayOutputStream newOleStream = new ByteArrayOutputStream();

    // 修改 Workbook 資料。
    workbook.getWorksheets().get(0).getCells().get(0, 4).putValue("E");
    workbook.getWorksheets().get(0).getCells().get(1, 4).putValue(12);
    workbook.getWorksheets().get(0).getCells().get(2, 4).putValue(14);
    workbook.getWorksheets().get(0).getCells().get(3, 4).putValue(15);

    OoxmlSaveOptions fileOptions = new OoxmlSaveOptions(com.aspose.cells.SaveFormat.XLSX);
    workbook.save(newOleStream, fileOptions);

    // 變更 OLE 框架物件資料。
    IOleEmbeddedDataInfo newData = new OleEmbeddedDataInfo(newOleStream.toByteArray(), oleFrame.getEmbeddedData().getEmbeddedFileExtension());
    oleFrame.setEmbeddedData(newData);
}

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **在投影片中嵌入其他檔案類型**

除了 Excel 圖表外，Aspose.Slides for Android via Java 亦允許您將其他類型的檔案嵌入投影片。例如，您可以將 HTML、PDF 與 ZIP 檔案插入為物件。使用者雙擊插入的物件時，會自動於相關程式開啟，或會提示使用者選取適當的程式開啟。

以下 Java 程式碼示範如何將 HTML 與 ZIP 嵌入投影片：

```java
Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

File fileHtml = new File("sample.html");
byte htmlData[] = new byte[(int) fileHtml.length()];
BufferedInputStream bisHtml = new BufferedInputStream(new FileInputStream(fileHtml));
DataInputStream disHtml = new DataInputStream(bisHtml);
disHtml.readFully(htmlData);
IOleEmbeddedDataInfo htmlDataInfo = new OleEmbeddedDataInfo(htmlData, "html");
IOleObjectFrame htmlOleFrame = slide.getShapes().addOleObjectFrame(150, 120, 50, 50, htmlDataInfo);
htmlOleFrame.setObjectIcon(true);

File fileZip = new File("sample.zip");
byte zipData[] = new byte[(int) fileZip.length()];
BufferedInputStream bisZip = new BufferedInputStream(new FileInputStream(fileZip));
DataInputStream disZip = new DataInputStream(bisZip);
disZip.readFully(zipData);
IOleEmbeddedDataInfo zipDataInfo = new OleEmbeddedDataInfo(zipData, "zip");
IOleObjectFrame zipOleFrame = slide.getShapes().addOleObjectFrame(150, 220, 50, 50, zipDataInfo);
zipOleFrame.setObjectIcon(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **設定嵌入物件的檔案類型**

在處理簡報時，您可能需要將舊的 OLE 物件取代為新物件，或將不支援的 OLE 物件換成受支援的。Aspose.Slides for Android via Java 允許您設定嵌入物件的檔案類型，從而更新 OLE 框架的資料或其副檔名。

以下 Java 程式碼示範如何將嵌入的 OLE 物件檔案類型設定為 `zip`：

```java
Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

String fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();
byte[] fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

System.out.println("Current embedded file extension is: " + fileExtension);

// Change the file type to ZIP.
oleFrame.setEmbeddedData(new OleEmbeddedDataInfo(fileData, "zip"));

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **為嵌入物件設定圖示影像與標題**

嵌入 OLE 物件後，系統會自動加入由圖示影像組成的預覽。此預覽即為使用者在存取或開啟 OLE 物件前所看到的畫面。如果您想在預覽中使用特定的影像與文字，可使用 Aspose.Slides for Android via Java 設定圖示影像與標題。

以下 Java 程式碼示範如何為嵌入的物件設定圖示影像與標題：

```java
Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

// 將影像新增至簡報資源。
File file = new File("image.png");
byte imageData[] = new byte[(int) file.length()];
BufferedInputStream bis = new BufferedInputStream(new FileInputStream(file));
DataInputStream dis = new DataInputStream(bis);
dis.readFully(imageData);
IPPImage oleImage = presentation.getImages().addImage(imageData);

// Set a title and the image for the OLE preview.
oleFrame.setSubstitutePictureTitle("My title");
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **防止 OLE 物件框架被重新調整大小與重新定位**

在投影片中新增已連結的 OLE 物件後，若於 PowerPoint 開啟簡報，可能會顯示要求更新連結的訊息。點選「Update Links」按鈕可能會因 PowerPoint 從已連結的 OLE 物件更新資料並重新整理預覽，而改變 OLE 物件框架的大小與位置。為防止 PowerPoint 提示更新物件資料，請將 [IOleObjectFrame](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ioleobjectframe/) 介面的 `setUpdateAutomatic` 方法設為 `false`：

```java
oleFrame.setUpdateAutomatic(false);
```

## **擷取嵌入的檔案**

Aspose.Slides for Android via Java 允許您以以下方式擷取投影片中以 OLE 物件嵌入的檔案：

1. 建立包含您欲擷取之 OLE 物件的 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/Presentation) 類別實例。
2. 遍歷簡報中的所有形狀，並存取 [OLEObjectFrame](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/oleobjectframe) 形狀。
3. 從 OLE 物件框架取得嵌入檔案的資料，並寫入磁碟。

以下 Java 程式碼示範如何將投影片中嵌入的檔案以 OLE 物件形式擷取：

```java
Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);

for (int index = 0; index < slide.getShapes().size(); index++) {
    IShape shape = slide.getShapes().get_Item(index);

    if (shape instanceof IOleObjectFrame) {
        IOleObjectFrame oleFrame = (IOleObjectFrame) shape;

        byte[] fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();
        String fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();

        FileOutputStream fos = new FileOutputStream(new File("OLE_object_" + index + fileExtension));
        fos.write(fileData);
        fos.close();
    }
}

presentation.dispose();
```

## **FAQ**

**匯出投影片為 PDF/影像時，會渲染 OLE 內容嗎？**

僅渲染投影片上可見的部分——圖示/替代影像（預覽）。在渲染過程中不會執行「即時」的 OLE 內容。如有需要，請自行設定預覽圖像，以確保匯出 PDF 時呈現預期的外觀。

**如何在投影片上鎖定 OLE 物件，使使用者在 PowerPoint 中無法移動或編輯它？**

鎖定形狀：Aspose.Slides 提供形狀層級的鎖定功能。這並非加密，但可有效防止意外的編輯與移動。

**為何在開啟簡報時，已連結的 Excel 物件會「跳動」或變更大小？**

PowerPoint 可能會重新整理已連結 OLE 的預覽。若要保持穩定的外觀，請遵循 [Worksheet Resizing 的作業解決方案](/slides/zh-hant/androidjava/working-solution-for-worksheet-resizing/)——將框架調整至符合範圍，或將範圍縮放至固定框架，並設定適當的替代影像。

**在 PPTX 格式中，已連結 OLE 物件的相對路徑會被保留嗎？**

在 PPTX 中不會保留「相對路徑」資訊—僅有完整路徑。相對路徑僅出現在舊版 PPT 格式。為提升可移植性，建議使用可靠的絕對路徑/可存取的 URI，或直接嵌入檔案。
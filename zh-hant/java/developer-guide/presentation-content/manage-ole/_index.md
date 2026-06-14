---
title: 使用 Java 管理簡報中的 OLE
linktitle: 管理 OLE
type: docs
weight: 40
url: /zh-hant/java/manage-ole/
keywords:
- OLE 物件
- 物件連結與嵌入
- 新增 OLE
- 嵌入 OLE
- 新增 物件
- 嵌入 物件
- 新增 檔案
- 嵌入 檔案
- 連結 物件
- 連結 檔案
- 變更 OLE
- OLE 圖示
- OLE 標題
- 提取 OLE
- 提取 物件
- 提取 檔案
- PowerPoint
- 簡報
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Java 優化在 PowerPoint 和 OpenDocument 檔案中的 OLE 物件管理。無縫地嵌入、更新與匯出 OLE 內容。"
---
## **簡介**

{{% alert color="primary" %}} 

OLE（Object Linking & Embedding）是 Microsoft 的一項技術，可讓在一個應用程式中建立的資料和物件透過連結或嵌入方式放置到另一個應用程式中。 

{{% /alert %}} 

想像在 MS Excel 中建立的圖表，然後將該圖表放入 PowerPoint 投影片中。該 Excel 圖表即視為 OLE 物件。 

- OLE 物件可能以圖示方式出現。在此情況下，雙擊圖示會在其關聯的應用程式（Excel）中開啟圖表，或會要求您選擇用於開啟或編輯物件的應用程式。 
- OLE 物件也可能直接顯示實際內容，例如圖表本身。此時，圖表在 PowerPoint 中被啟用，圖表介面載入，您可以在 PowerPoint 內修改圖表資料。

[Aspose.Slides for Java](https://products.aspose.com/slides/zh-hant/java/) 允許您將 OLE 物件插入投影片，作為 OLE 物件框 ([OleObjectFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/OleObjectFrame))。

## **將 OLE 物件框新增至投影片**

假設您已在 Microsoft Excel 中建立圖表，並希望使用 Aspose.Slides for Java 將其嵌入投影片作為 OLE 物件框，您可以這樣做：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/Presentation) 類別的實例。  
1. 透過索引取得投影片的參考。  
1. 以位元組陣列方式讀取 Excel 檔案。  
1. 將 [OleObjectFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/OleObjectFrame) 加入投影片，並提供位元組陣列及其他 OLE 物件資訊。  
1. 將修改後的簡報寫入為 PPTX 檔案。  

在下方範例中，我們使用 Aspose.Slides for Java 將 Excel 檔案中的圖表新增為投影片上的 OLE 物件框。  
**注意**，[OleEmbeddedDataInfo](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/OleEmbeddedDataInfo) 建構式的第二個參數是可嵌入物件的副檔名。此副檔名讓 PowerPoint 正確辨識檔案類型並選擇適當的應用程式開啟此 OLE 物件。

``` java 
Presentation presentation = new Presentation();
Dimension2D slideSize = presentation.getSlideSize().getSize();
ISlide slide = presentation.getSlides().get_Item(0);

// 準備 OLE 物件的資料。
byte[] fileData = Files.readAllBytes(Paths.get("book.xlsx"));
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(fileData, "xlsx");

// 將 OLE 物件框新增至投影片。
slide.getShapes().addOleObjectFrame(0, 0, (float)slideSize.getWidth(), (float)slideSize.getHeight(), dataInfo);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

### **新增連結的 OLE 物件框**

Aspose.Slides for Java 允許您新增 [OleObjectFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/OleObjectFrame)，不嵌入資料，而僅提供檔案的連結。  

以下 Java 程式碼示範如何將帶有連結 Excel 檔案的 [OleObjectFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/OleObjectFrame) 新增至投影片：

```java
Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// 新增一個含有連結 Excel 檔案的 OLE 物件框。
slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **存取 OLE 物件框**

如果投影片中已嵌入 OLE 物件，您可以這樣輕鬆找出或存取它：

1. 透過建立 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/Presentation) 類別的實例，載入包含嵌入 OLE 物件的簡報。  
2. 使用索引取得投影片的參考。  
3. 取得 [OleObjectFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/OleObjectFrame) 形狀。在本例中，我們使用先前建立的 PPTX，該檔案的第一張投影片僅有一個形狀。我們接著將該物件 *cast* 為 [IOleObjectFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IOleObjectFrame)。這就是要存取的 OLE 物件框。  
4. 一旦取得 OLE 物件框，即可對其執行任何操作。  

以下範例中，存取了一個 OLE 物件框（嵌入投影片的 Excel 圖表物件）及其檔案資料。

``` java 
Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;
    
    // 取得嵌入檔案的資料。
    byte[] fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

    // 取得嵌入檔案的副檔名。
    String fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();

    // ...
}
```

### **存取連結 OLE 物件框屬性**

Aspose.Slides 允許您存取連結 OLE 物件框的屬性。  

以下 Java 程式碼示範如何檢查 OLE 物件是否為連結，並取得連結檔案的路徑：

```java
Presentation presentation = new Presentation("sample.ppt");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;

    // 檢查 OLE 物件是否為連結。
    if (oleFrame.isObjectLink()) {
        // 印出連結檔案的完整路徑。
        System.out.println("OLE object frame is linked to: " + oleFrame.getLinkPathLong());

        // 若存在，印出連結檔案的相對路徑。
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

在本節中，以下程式碼範例使用 [Aspose.Cells for Java](/cells/java/)。 

{{% /alert %}} 

如果投影片中已嵌入 OLE 物件，您可以這樣輕鬆存取該物件並修改其資料：

1. 透過建立 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/Presentation) 類別的實例，載入包含嵌入 OLE 物件的簡報。  
2. 透過索引取得投影片的參考。  
3. 取得 OLE 物件框形狀。在本例中，我們使用先前建立的 PPTX，該檔案的第一張投影片僅有一個形狀。我們接著將該物件 *cast* 為 [IOleObjectFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IOleObjectFrame)。這就是要存取的 OLE 物件框。  
4. 一旦取得 OLE 物件框，即可對其執行任何操作。  
5. 建立 `Workbook` 物件並存取 OLE 資料。  
6. 取得目標 `Worksheet` 並修改資料。  
7. 将更新后的 `Workbook` 儲存至串流。  
8. 從串流變更 OLE 物件資料。  

以下範例中，存取了一個 OLE 物件框（嵌入投影片的 Excel 圖表物件），並修改其檔案資料以更新圖表資料。

``` java 
Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;

    ByteArrayInputStream oleStream = new ByteArrayInputStream(oleFrame.getEmbeddedData().getEmbeddedFileData());

    // 讀取 OLE 物件資料為 Workbook 物件。
    Workbook workbook = new Workbook(oleStream);

    ByteArrayOutputStream newOleStream = new ByteArrayOutputStream();

    // 修改工作簿資料。
    workbook.getWorksheets().get(0).getCells().get(0, 4).putValue("E");
    workbook.getWorksheets().get(0).getCells().get(1, 4).putValue(12);
    workbook.getWorksheets().get(0).getCells().get(2, 4).putValue(14);
    workbook.getWorksheets().get(0).getCells().get(3, 4).putValue(15);

    OoxmlSaveOptions fileOptions = new OoxmlSaveOptions(com.aspose.cells.SaveFormat.XLSX);
    workbook.save(newOleStream, fileOptions);

    // 變更 OLE 框的物件資料。
    IOleEmbeddedDataInfo newData = new OleEmbeddedDataInfo(newOleStream.toByteArray(), oleFrame.getEmbeddedData().getEmbeddedFileExtension());
    oleFrame.setEmbeddedData(newData);
}

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **在投影片中嵌入其他檔案類型**

除了 Excel 圖表外，Aspose.Slides for Java 還允許您將其他類型的檔案嵌入投影片。例如，您可以將 HTML、PDF 與 ZIP 檔案插入為物件。使用者雙擊插入的物件時，會自動在相關程式中開啟，或會提示使用者選擇適當的程式來開啟。

以下 Java 程式碼示範如何將 HTML 與 ZIP 嵌入投影片：

```java
Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

byte[] htmlData = Files.readAllBytes(Paths.get("sample.html"));
IOleEmbeddedDataInfo htmlDataInfo = new OleEmbeddedDataInfo(htmlData, "html");
IOleObjectFrame htmlOleFrame = slide.getShapes().addOleObjectFrame(150, 120, 50, 50, htmlDataInfo);
htmlOleFrame.setObjectIcon(true);

byte[] zipData = Files.readAllBytes(Paths.get("sample.zip"));
IOleEmbeddedDataInfo zipDataInfo = new OleEmbeddedDataInfo(zipData, "zip");
IOleObjectFrame zipOleFrame = slide.getShapes().addOleObjectFrame(150, 220, 50, 50, zipDataInfo);
zipOleFrame.setObjectIcon(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **設定嵌入物件的檔案類型**

在處理簡報時，您可能需要將舊的 OLE 物件取代為新物件，或將不受支援的 OLE 物件換成受支援的物件。Aspose.Slides for Java 允許您為嵌入的物件設定檔案類型，從而更新 OLE 框資料或其副檔名。

以下 Java 程式碼示範如何將嵌入 OLE 物件的檔案類型設定為 `zip`：

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

嵌入 OLE 物件後，系統會自動加入由圖示影像組成的預覽。此預覽即是使用者在存取或開啟 OLE 物件前所看到的畫面。若您想使用特定影像與文字作為預覽元素，可透過 Aspose.Slides for Java 設定圖示影像與標題。

以下 Java 程式碼示範如何為嵌入物件設定圖示影像與標題：

```java
Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

// 將影像新增至簡報資源。
byte[] imageData = Files.readAllBytes(Paths.get("image.png"));
IPPImage oleImage = presentation.getImages().addImage(imageData);

// 設定 OLE 預覽的標題與影像。
oleFrame.setSubstitutePictureTitle("My title");
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **防止 OLE 物件框被調整大小與重新定位**

在將連結的 OLE 物件新增至簡報投影片後，若在 PowerPoint 中開啟該簡報，可能會看到要求更新連結的訊息。點選「Update Links」按鈕可能會因 PowerPoint 從連結的 OLE 物件更新資料並重新整理預覽，而導致 OLE 物件框的大小與位置變更。為避免 PowerPoint 提示更新物件資料，請將 [IOleObjectFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ioleobjectframe/) 介面的 `setUpdateAutomatic` 方法設為 `false`：

```java
oleFrame.setUpdateAutomatic(false);
```

## **擷取嵌入檔案**

Aspose.Slides for Java 允許您以以下方式擷取投影片中以 OLE 物件形式嵌入的檔案：

1. 建立包含欲擷取之 OLE 物件的 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/Presentation) 類別實例。  
2. 迭代簡報中的所有形狀，並存取 [OLEObjectFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/oleobjectframe) 形狀。  
3. 從 OLE 物件框取得嵌入檔案的資料，並寫入磁碟。  

以下 Java 程式碼示範如何將投影片中嵌入的檔案作為 OLE 物件擷取：

```java
Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);

for (int index = 0; index < slide.getShapes().size(); index++) {
    IShape shape = slide.getShapes().get_Item(index);

    if (shape instanceof IOleObjectFrame) {
        IOleObjectFrame oleFrame = (IOleObjectFrame) shape;

        byte[] fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();
        String fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();

        Path filePath = Paths.get("OLE_object_" + index + fileExtension);
        Files.write(filePath, fileData);
    }
}

presentation.dispose();
```

## **常見問題**

**在將投影片匯出為 PDF/影像時，OLE 內容會被呈現嗎？**

投影片上可見的部份會被渲染——圖示/替代圖像（預覽）。在渲染過程中不會執行「即時」的 OLE 內容。如有需要，請自行設定預覽圖像，以確保匯出 PDF 時呈現預期的外觀。

**如何在投影片上鎖定 OLE 物件，使使用者無法在 PowerPoint 中移動或編輯它？**

鎖定形狀：Aspose.Slides 提供 [形狀層級的鎖定](/slides/zh-hant/java/applying-protection-to-presentation/)。這並非加密，但可有效防止意外的編輯與移動。

**為何在開啟簡報時，連結的 Excel 物件會「跳動」或變更大小？**

PowerPoint 可能會重新整理連結 OLE 的預覽。為了獲得穩定外觀，請遵循 [工作表調整大小的解決方案](/slides/zh-hant/java/working-solution-for-worksheet-resizing/)——將框架調整至範圍大小，或將範圍縮放至固定框架，並設定適當的替代圖像。

**在 PPTX 格式中，連結 OLE 物件的相對路徑會被保留嗎？**

在 PPTX 中不提供「相對路徑」資訊——僅有完整路徑。相對路徑僅在較舊的 PPT 格式中存在。為了可攜性，建議使用可靠的絕對路徑、可存取的 URI 或直接嵌入。
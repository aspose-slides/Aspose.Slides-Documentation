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
- 擷取 OLE
- 提取 物件
- 提取 檔案
- PowerPoint 
- 簡報
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Java 優化在 PowerPoint 和 OpenDocument 檔案中的 OLE 物件管理。無縫地嵌入、更新和匯出 OLE 內容。"
---
## **簡介**

{{% alert color="info" %}} 

OLE（Object Linking & Embedding）是 Microsoft 的一項技術，允許在一個應用程式中建立的資料與物件透過連結或嵌入的方式放置到另一個應用程式中。 

{{% /alert %}} 

考慮在 Microsoft Excel 中建立的圖表，然後將該圖表放入 PowerPoint 投影片中。此 Excel 圖表即被視為 OLE 物件。 

- OLE 物件可能會顯示為圖示。此情況下，當您雙擊圖示時，圖表會在其關聯的應用程式（Excel）中開啟，或會要求您選取開啟或編輯物件的應用程式。  
- OLE 物件也可能直接顯示實際內容，例如圖表本身。此時，圖表會在 PowerPoint 中被啟動，圖表介面會載入，您可以在 PowerPoint 內修改圖表的資料。

[Aspose.Slides for Java](https://products.aspose.com/slides/zh-hant/java/) 允許您將 OLE 物件插入投影片作為 OLE 物件框架（[OleObjectFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/OleObjectFrame)）。

## **將 OLE 物件框架新增至投影片**

假設您已在 Microsoft Excel 中建立圖表，並希望使用 Aspose.Slides for Java 將其以 OLE 物件框架的形式嵌入投影片，可依下列方式操作：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/Presentation) 類別的實例。  
1. 透過索引取得投影片的參照。  
1. 將 Excel 檔案讀取為位元組陣列。  
1. 將包含位元組陣列以及 OLE 物件其他資訊的 [OleObjectFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/OleObjectFrame) 新增至投影片。  
1. 將修改後的簡報寫入為 PPTX 檔案。

在下方範例中，我們使用 Aspose.Slides for Java 將 Excel 檔案中的圖表以 OLE 物件框架的形式新增至投影片。  
**注意** [OleEmbeddedDataInfo](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/OleEmbeddedDataInfo) 建構函式接受可嵌入物件的副檔名作為第二個參數。此副檔名讓 PowerPoint 能正確辨識檔案類型並選擇正確的應用程式開啟此 OLE 物件。

``` java 
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
Dimension2D slideSize = presentation.getSlideSize().getSize();
ISlide slide = presentation.getSlides().get_Item(0);

// Prepare data for the OLE object.
byte[] fileData = Files.readAllBytes(Paths.get("book.xlsx"));
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(fileData, "xlsx");

// Add the OLE object frame to the slide.
slide.getShapes().addOleObjectFrame(0, 0, (float)slideSize.getWidth(), (float)slideSize.getHeight(), dataInfo);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

### **新增連結的 OLE 物件框架**

Aspose.Slides for Java 允許您新增一個 [OleObjectFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/OleObjectFrame) 而不嵌入資料，只提供檔案的連結。

以下 Java 程式碼示範如何將連結至 Excel 檔案的 [OleObjectFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/OleObjectFrame) 新增至投影片：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// 新增一個連結 Excel 檔案的 OLE 物件框架。
slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **存取 OLE 物件框架**

如果 OLE 物件已嵌入於投影片中，您可以透過以下方式輕鬆找出或存取它：

1. 以建立 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/Presentation) 類別的實例方式載入含有嵌入 OLE 物件的簡報。  
2. 使用索引取得投影片的參照。  
3. 存取 [OleObjectFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/OleObjectFrame) 形狀。  
   在本例中，我們使用先前建立的僅在第一張投影片上有一個形狀的 PPTX。接著 *cast* 該物件為 [IOleObjectFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IOleObjectFrame)。這就是我們欲存取的 OLE 物件框架。  
4. 一旦取得 OLE 物件框架，即可對其執行任何操作。

在下方範例中，我們存取了一個 OLE 物件框架（嵌入於投影片的 Excel 圖表物件）及其檔案資料。

``` java 
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;
    
    // 取得嵌入的檔案資料。
    byte[] fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

    // 取得嵌入檔案的副檔名。
    String fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();

    // ...
}
```

### **存取連結 OLE 物件框架屬性**

Aspose.Slides 允許您存取連結 OLE 物件框架的屬性。

以下 Java 程式碼示範如何檢查 OLE 物件是否為連結，並取得連結檔案的路徑：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.ppt");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;

    // 檢查 OLE 物件是否為連結。
    if (oleFrame.isObjectLink()) {
        // 輸出連結檔案的完整路徑。
        System.out.println("OLE object frame is linked to: " + oleFrame.getLinkPathLong());

        // 若存在，輸出連結檔案的相對路徑。
        // 只有 PPT 簡報可能包含相對路徑。
        if (oleFrame.getLinkPathRelative() != null && !oleFrame.getLinkPathRelative().isEmpty()) {
            System.out.println("OLE object frame relative path: " + oleFrame.getLinkPathRelative());
        }
    }
}

presentation.dispose();
```

## **變更 OLE 物件資料**

{{% alert color="info" %}} 

在本節中，以下程式碼範例使用 [Aspose.Cells for Java](/cells/java/)。 

{{% /alert %}}

如果 OLE 物件已嵌入於投影片中，您可以輕鬆存取該物件並修改其資料：

1. 以建立 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/Presentation) 類別的實例方式載入含有嵌入 OLE 物件的簡報。  
2. 透過索引取得投影片的參照。  
3. 存取 OLE 物件框架形狀。  
   在本例中，我們使用先前建立的在第一張投影片上僅有一個形狀的 PPTX，然後 *cast* 該物件為 [IOleObjectFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IOleObjectFrame)。這就是欲存取的 OLE 物件框架。  
4. 一旦取得 OLE 物件框架，即可對其執行任何操作。  
5. 建立 `Workbook` 物件並存取 OLE 資料。  
6. 取得目標 `Worksheet` 並修改資料。  
7. 將更新後的 `Workbook` 儲存至串流。  
8. 從串流變更 OLE 物件資料。

在下方範例中，我們存取了一個 OLE 物件框架（嵌入於投影片的 Excel 圖表），並修改其檔案資料以更新圖表資料。

``` java 
import com.aspose.slides.*;
import com.aspose.cells.Workbook;
import com.aspose.cells.OoxmlSaveOptions;
import java.io.ByteArrayInputStream;
import java.io.ByteArrayOutputStream;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;

    ByteArrayInputStream oleStream = new ByteArrayInputStream(oleFrame.getEmbeddedData().getEmbeddedFileData());

    // 將 OLE 物件資料讀取為 Workbook 物件。
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

除 Excel 圖表外，Aspose.Slides for Java 亦允許您將其他類型的檔案嵌入投影片。例如，您可以將 HTML、PDF 與 ZIP 檔案作為物件插入。使用者雙擊插入的物件時，會自動於相關程式開啟，或提示使用者選取適當的程式開啟。

以下 Java 程式碼示範如何將 HTML 與 ZIP 檔案嵌入投影片：

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

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

在處理簡報時，您可能需要將舊的 OLE 物件取代為新的，或將不受支援的 OLE 物件換成受支援的。Aspose.Slides for Java 允許您設定嵌入物件的檔案類型，進而更新 OLE 框架資料或其副檔名。

以下 Java 程式碼示範如何將嵌入 OLE 物件的檔案類型設定為 `zip`：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

String fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();
byte[] fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

System.out.println("Current embedded file extension is: " + fileExtension);

// 變更檔案類型為 ZIP.
oleFrame.setEmbeddedData(new OleEmbeddedDataInfo(fileData, "zip"));

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **設定嵌入物件的圖示影像與標題**

嵌入 OLE 物件後，系統會自動加入由圖示影像組成的預覽。此預覽即使用者在存取或開啟 OLE 物件前所看到的畫面。若您想使用特定的圖像與文字作為預覽元素，可透過 Aspose.Slides for Java 設定圖示影像與標題。

以下 Java 程式碼示範如何為嵌入物件設定圖示影像與標題：

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

// 將影像新增至簡報資源中。
byte[] imageData = Files.readAllBytes(Paths.get("image.png"));
IPPImage oleImage = presentation.getImages().addImage(imageData);

// 設定 OLE 預覽的標題與影像。
oleFrame.setSubstitutePictureTitle("My title");
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **防止 OLE 物件框架被重新調整大小與重新定位**

在將連結的 OLE 物件加入簡報投影片後，若在 PowerPoint 中開啟簡報，可能會出現要求更新連結的訊息。點擊「Update Links」按鈕可能會改變 OLE 物件框架的大小與位置，因為 PowerPoint 會從連結的 OLE 物件更新資料並重新整理物件預覽。為防止 PowerPoint 提示更新物件資料，請將 [IOleObjectFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ioleobjectframe/) 介面的 `setUpdateAutomatic` 方法設為 `false`：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

oleFrame.setUpdateAutomatic(false);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **擷取嵌入的檔案**

Aspose.Slides for Java 允許您以以下方式擷取投影片中以 OLE 物件形式嵌入的檔案：

1. 建立包含欲擷取 OLE 物件之簡報的 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/Presentation) 類別實例。  
2. 迭代簡報中的所有形狀，存取 [OLEObjectFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/oleobjectframe) 形狀。  
3. 從 OLE 物件框架取得嵌入檔案的資料，並寫入磁碟。

以下 Java 程式碼示範如何將投影片中以 OLE 物件形式嵌入的檔案擷取出來：

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

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

### 在將投影片匯出為 PDF/影像時，OLE 內容會被渲染嗎？

會渲染投影片上可見的部分——即圖示/替代影像（預覽）。「即時」的 OLE 內容在渲染過程中不會被執行。如有需要，可自行設定預覽影像，以確保匯出 PDF 時的外觀如預期。

### 如何在投影片上鎖定 OLE 物件，使使用者無法在 PowerPoint 中移動或編輯？

鎖定形狀：Aspose.Slides 提供 [shape-level locks](/slides/zh-hant/java/applying-protection-to-presentation/)。這並非加密，但可有效防止意外編輯與移動。

### 為什麼在開啟簡報時，連結的 Excel 物件會「跳動」或改變大小？

PowerPoint 可能會重新整理連結 OLE 的預覽。若需穩定外觀，請參考 [Working Solution for Worksheet Resizing](/slides/zh-hant/java/working-solution-for-worksheet-resizing/) 的作法——將框架調整至範圍大小，或將範圍縮放至固定框架並設定適當的替代影像。

### PPTX 格式會保留連結 OLE 物件的相對路徑嗎？

在 PPTX 中不會保留「相對路徑」資訊——僅存全路徑。相對路徑僅見於舊版 PPT 格式。為提升可移植性，建議使用可靠的絕對路徑/可存取的 URI 或直接嵌入。
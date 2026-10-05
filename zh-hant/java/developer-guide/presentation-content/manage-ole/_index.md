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
description: "使用 Aspose.Slides for Java 優化在 PowerPoint 與 OpenDocument 檔案中的 OLE 物件管理。無縫嵌入、更新及匯出 OLE 內容。"
---
## **簡介**

{{% alert color="info" title="Note" %}}

OLE（Object Linking & Embedding）是 Microsoft 的一項技術，可讓在一個應用程式中建立的資料與物件，透過連結或嵌入的方式放入另一個應用程式。

{{% /alert %}} 

想像在 Microsoft Excel 中建立了一個圖表，然後將該圖表放入 PowerPoint 投影片中。此 Excel 圖表即被視為 OLE 物件。

- OLE 物件可能會顯示為圖示。此時，雙擊圖示會在其關聯的應用程式（Excel）中開啟圖表，或會提示您選擇開啟或編輯該物件的應用程式。
- OLE 物件也可能直接顯示實際內容，例如圖表本身。此時，圖表會在 PowerPoint 中被啟動，介面載入，您可以在 PowerPoint 內修改圖表資料。

[Aspose.Slides for Java](https://products.aspose.com/slides/java/) 允許您將 OLE 物件插入投影片，作為 OLE 物件框架（[OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/OleObjectFrame)）。

## **將 OLE 物件框架新增至投影片**

假設您已在 Microsoft Excel 中建立了圖表，並希望使用 Aspose.Slides for Java 以 OLE 物件框架的方式將其嵌入投影片，可依照下列步驟操作：

1. 建立 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) 類別的實例。
1. 透過索引取得投影片的參考。
1. 將 Excel 檔案讀取為位元組陣列。
1. 將包含位元組陣列與其他 OLE 物件資訊的 [OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/OleObjectFrame) 新增至投影片。
1. 將修改後的簡報寫入為 PPTX 檔案。

以下範例示範如何使用 Aspose.Slides for Java，將 Excel 檔案中的圖表以 OLE 物件框架的形式新增至投影片。  
**注意**  [OleEmbeddedDataInfo](https://reference.aspose.com/slides/java/com.aspose.slides/OleEmbeddedDataInfo) 的建構函式接受可嵌入物件的副檔名作為第二個參數。此副檔名可讓 PowerPoint 正確辨識檔案類型，並選擇適當的應用程式開啟此 OLE 物件。

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

### **新增已連結的 OLE 物件框架**

Aspose.Slides for Java 允許您在不嵌入資料的情況下，僅透過檔案連結新增 [OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/OleObjectFrame)。

以下 Java 程式碼示範如何在投影片中加入連結至 Excel 檔案的 [OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/OleObjectFrame)：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// 新增一個連結至 Excel 檔案的 OLE 物件框架。
slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **存取 OLE 物件框架**

如果投影片已嵌入 OLE 物件，您可以透過以下方式輕鬆找出或存取它：

1. 以建立 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) 類別的實例，載入包含已嵌入 OLE 物件的簡報。
2. 使用索引取得投影片的參考。
3. 取得 [OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/OleObjectFrame) 形狀。  
   在本範例中，我們使用先前建立的僅在第一張投影片上有一個形狀的 PPTX，然後 *cast* 該物件為 [IOleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IOleObjectFrame)。這就是要存取的 OLE 物件框架。
4. 取得 OLE 物件框架後，您即可對其執行任何操作。

以下範例示範如何存取嵌入於投影片中的 OLE 物件框架（Excel 圖表物件）以及其檔案資料。

``` java 
import com.aspose.slides.*;

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
        // 列印連結檔案的完整路徑。
        System.out.println("OLE object frame is linked to: " + oleFrame.getLinkPathLong());

        // 若存在，列印連結檔案的相對路徑。
        // 只有 PPT 簡報可以包含相對路徑。
        if (oleFrame.getLinkPathRelative() != null && !oleFrame.getLinkPathRelative().isEmpty()) {
            System.out.println("OLE object frame relative path: " + oleFrame.getLinkPathRelative());
        }
    }
}

presentation.dispose();
```

## **變更 OLE 物件資料**

{{% alert color="info" title="Note" %}}

本節的程式碼範例使用 [Aspose.Cells for Java](https://docs.aspose.com/cells/java/)。

{{% /alert %}}

如果投影片已嵌入 OLE 物件，您可以透過以下方式輕鬆存取該物件並修改其資料：

1. 以建立 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) 類別的實例，載入包含已嵌入 OLE 物件的簡報。
2. 透過索引取得投影片的參考。 
3. 取得 OLE 物件框架形狀。  
   在本範例中，我們使用先前建立的僅在第一張投影片上有一個形狀的 PPTX，然後 *cast* 該物件為 [IOleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IOleObjectFrame)。這就是要存取的 OLE 物件框架。
4. 取得 OLE 物件框架後，您即可對其執行任何操作。
5. 建立 `Workbook` 物件並存取 OLE 資料。
6. 取得所需的 `Worksheet`，並修改資料。
7. 將更新後的 `Workbook` 儲存至串流。
8. 從串流變更 OLE 物件資料。

以下範例示範如何存取嵌入於投影片中的 OLE 物件框架（Excel 圖表物件），並修改其檔案資料以更新圖表資料。

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

    // 以 Workbook 物件讀取 OLE 物件資料。
    Workbook workbook = new Workbook(oleStream);

    ByteArrayOutputStream newOleStream = new ByteArrayOutputStream();

    // 修改工作簿資料。
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

除了 Excel 圖表之外，Aspose.Slides for Java 還允許您將其他類型的檔案嵌入投影片。例如，您可以將 HTML、PDF 與 ZIP 檔案作為物件插入。當使用者雙擊插入的物件時，會自動於相關程式開啟，或提示使用者選擇適當的程式開啟。

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

在處理簡報時，您可能需要將舊的 OLE 物件取代為新的，或將不受支援的 OLE 物件換成受支援的。Aspose.Slides for Java 允許您為嵌入物件設定檔案類型，從而更新 OLE 框架資料或其副檔名。

以下 Java 程式碼示範如何將嵌入的 OLE 物件的檔案類型設定為 `zip`：

```java
import com.aspose.slides.*;

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

## **設定嵌入物件的圖示影像與標題**

嵌入 OLE 物件後，系統會自動加入一個圖示影像作為預覽。這是使用者在存取或開啟 OLE 物件前所看到的畫面。如果您想要使用特定的影像與文字作為預覽元素，可透過 Aspose.Slides for Java 設定圖示影像與標題。

以下 Java 程式碼示範如何為嵌入的物件設定圖示影像與標題：

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

// 將影像新增至簡報資源。
byte[] imageData = Files.readAllBytes(Paths.get("image.png"));
IPPImage oleImage = presentation.getImages().addImage(imageData);

// Set a title and the image for the OLE preview.
oleFrame.setSubstitutePictureTitle("My title");
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **防止 OLE 物件框架被調整大小與重新定位**

在投影片中加入已連結的 OLE 物件後，開啟 PowerPoint 時可能會看到提示訊息要求更新連結。按下「Update Links」按鈕可能會因 PowerPoint 從連結的 OLE 物件更新資料並重新整理預覽，而導致 OLE 物件框架的大小與位置發生變化。若要防止 PowerPoint 提示更新物件資料，請以 `false` 呼叫 [IOleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ioleobjectframe/) 介面的 [setUpdateAutomatic](https://reference.aspose.com/slides/java/com.aspose.slides/ioleobjectframe/#setUpdateAutomatic-boolean-) 方法：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

oleFrame.setUpdateAutomatic(false);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **擷取嵌入檔案**

Aspose.Slides for Java 允許您依下列步驟擷取投影片中作為 OLE 物件嵌入的檔案：

1. 建立包含欲擷取之 OLE 物件的 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) 類別實例。
2. 迭代簡報中的所有形狀，存取 [OLEObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/oleobjectframe) 形狀。
3. 由 OLE 物件框架取得嵌入檔案的資料，並寫入磁碟。

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

## **FAQ**

**匯出投影片為 PDF/影像時，會渲染 OLE 內容嗎？**

投影片上可見的部分會被渲染—即圖示/替代影像（預覽）。「即時」的 OLE 內容不會在渲染過程中執行。若需要，請自行設定預覽影像，以確保在匯出 PDF 時呈現預期外觀。

若也想將嵌入的檔案保留為 PDF 附件，請以 `true` 呼叫 [setIncludeOleData](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setIncludeOleData-boolean-)。此選項預設為關閉。相關範例與檢查附件的方法請參考 [保留嵌入 OLE 檔案為 PDF 附件](/slides/zh-hant/java/convert-powerpoint-to-pdf/#preserve-embedded-ole-files-as-pdf-attachments)。

**如何在投影片上鎖定 OLE 物件，使使用者無法在 PowerPoint 中移動或編輯？**

鎖定形狀：Aspose.Slides 提供[形狀層級鎖定](/slides/zh-hant/java/applying-protection-to-presentation/)。這並非加密，但可有效防止意外的編輯與移動。

**為什麼在開啟簡報時，已連結的 Excel 物件會「跳動」或改變大小？**

PowerPoint 可能會重新整理已連結 OLE 的預覽。若希望外觀穩定，請遵循[工作表調整大小的解決方案](/slides/zh-hant/java/working-solution-for-worksheet-resizing/)——將框架調整為符合範圍，或將範圍縮放至固定框架並設定適當的替代影像。

**PPTX 格式會保留已連結 OLE 物件的相對路徑嗎？**

在 PPTX 中不會保留「相對路徑」資訊——僅有完整路徑。相對路徑僅在較舊的 PPT 格式中存在。為了可移植性，建議使用可靠的絕對路徑/可存取的 URI 或直接嵌入檔案。
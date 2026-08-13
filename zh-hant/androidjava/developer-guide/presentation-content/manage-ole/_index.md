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
- 擷取 物件
- 擷取 檔案
- PowerPoint
- 簡報
- Android
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Android via Java，優化在 PowerPoint 與 OpenDocument 檔案中的 OLE 物件管理。無縫嵌入、更新與匯出 OLE 內容。"
---
## **簡介**

{{% alert color="info" %}} 

OLE（物件連結與嵌入）是微軟技術，可讓在一個應用程式中建立的資料與物件透過連結或嵌入方式置於另一個應用程式中。 

{{% /alert %}} 

以在 Microsoft Excel 中建立的圖表為例。該圖表隨後被放入 PowerPoint 投影片中。此 Excel 圖表即被視為 OLE 物件。 

- OLE 物件可能以圖示形式顯示。此時，雙擊圖示會在其相關應用程式（Excel）中開啟圖表，或會要求您選取開啟或編輯該物件的應用程式。 
- OLE 物件也可能直接顯示實際內容，例如圖表的內容。此時，圖表在 PowerPoint 中被啟用，圖表介面載入，您可以在 PowerPoint 內修改圖表資料。

Aspose.Slides for Android via Java 允許您將 OLE 物件插入投影片中作為 OLE 物件框架（[OleObjectFrame](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/OleObjectFrame)）。

## **將 OLE 物件框架新增至投影片**

假設您已在 Microsoft Excel 中建立圖表，並希望使用 Aspose.Slides for Android via Java 將其嵌入投影片作為 OLE 物件框架，您可以這樣做：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/Presentation) 類別的實例。  
1. 透過索引取得投影片的參照。  
1. 將 Excel 檔案讀取為位元組陣列。  
1. 將 [OleObjectFrame](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/OleObjectFrame) 新增至投影片，並包含位元組陣列及其他 OLE 物件資訊。  
1. 將修改後的簡報寫入為 PPTX 檔案。  

以下範例中，我們使用 Aspose.Slides for Android via Java，將 Excel 檔案中的圖表新增為投影片的 OLE 物件框架。  
**注意**，[OleEmbeddedDataInfo](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/OleEmbeddedDataInfo) 建構函式接受可嵌入物件的副檔名作為第二個參數。此副檔名讓 PowerPoint 能正確辨識檔案類型，並選擇適當的應用程式開啟此 OLE 物件。

```java 
import com.aspose.slides.*;
import java.io.BufferedInputStream;
import java.io.DataInputStream;
import java.io.File;
import java.io.FileInputStream;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation();
Dimension2D slideSize = presentation.getSlideSize().getSize();
ISlide slide = presentation.getSlides().get_Item(0);

// 準備 OLE 物件的資料。
File file = new File("book.xlsx");
byte fileData[] = new byte[(int) file.length()];
BufferedInputStream bis = new BufferedInputStream(new FileInputStream(file));
DataInputStream dis = new DataInputStream(bis);
dis.readFully(fileData);

IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(fileData, "xlsx");

// 將 OLE 物件框架新增至投影片。
slide.getShapes().addOleObjectFrame(0, 0, (float) slideSize.getWidth(), (float) slideSize.getHeight(), dataInfo);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

### **新增連結的 OLE 物件框架**

Aspose.Slides for Android via Java 允許您新增一個 [OleObjectFrame](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/OleObjectFrame)，不嵌入資料，而僅以檔案連結方式。  

以下 Java 程式碼示範如何將帶有連結 Excel 檔案的 [OleObjectFrame](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/OleObjectFrame) 新增至投影片：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// 新增一個帶有連結 Excel 檔案的 OLE 物件框架。
slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **存取 OLE 物件框架**

如果投影片中已有嵌入的 OLE 物件，您可以這樣輕鬆找到或存取它：

1. 透過建立 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/Presentation) 類別的實例，載入含有嵌入 OLE 物件的簡報。  
2. 使用索引取得投影片的參照。  
3. 存取 [OleObjectFrame](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/OleObjectFrame) 形狀。  
在本範例中，我們使用先前建立的 PPTX，該檔案在第一張投影片上僅有一個形狀。接著將該物件 *cast* 為 [IOleObjectFrame](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ioleobjectframe/)。此即為欲存取的 OLE 物件框架。  
4. 取得 OLE 物件框架後，您即可對其執行任何操作。  

以下範例中，存取了 OLE 物件框架（嵌入投影片的 Excel 圖表物件）及其檔案資料。

```java 
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

### **存取連結 OLE 物件框架屬性**

Aspose.Slides 允許您存取連結的 OLE 物件框架屬性。  

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
        // 只有 PPT 簡報可包含相對路徑。
        if (oleFrame.getLinkPathRelative() != null && !oleFrame.getLinkPathRelative().isEmpty()) {
            System.out.println("OLE object frame relative path: " + oleFrame.getLinkPathRelative());
        }
    }
}

presentation.dispose();
```

## **變更 OLE 物件資料**

{{% alert color="info" %}} 

在本節中，以下程式碼範例使用 [Aspose.Cells for Android via Java](/cells/androidjava/)。  

{{% /alert %}}

如果投影片中已有嵌入的 OLE 物件，您可以這樣輕鬆存取該物件並修改其資料：

1. 透過建立 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/Presentation) 類別的實例，載入含有嵌入 OLE 物件的簡報。  
2. 使用索引取得投影片的參照。  
3. 存取 OLE 物件框架形狀。  
在本範例中，我們使用先前建立的 PPTX，該檔案在第一張投影片上僅有一個形狀。接著將該物件 *cast* 為 [IOleObjectFrame](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ioleobjectframe/)。此即為欲存取的 OLE 物件框架。  
4. 取得 OLE 物件框架後，您即可對其執行任何操作。  
5. 建立 `Workbook` 物件並存取 OLE 資料。  
6. 取得目標的 `Worksheet` 並修改資料。  
7. 將更新後的 `Workbook` 儲存至串流。  
8. 從串流變更 OLE 物件資料。  

以下範例中，存取了 OLE 物件框架（嵌入投影片的 Excel 圖表物件），並修改其檔案資料以更新圖表資料。

```java 
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

除了 Excel 圖表外，Aspose.Slides for Android via Java 還允許您在投影片中嵌入其他類型的檔案。例如，您可以將 HTML、PDF 與 ZIP 檔案插入為物件。當使用者雙擊插入的物件時，會自動在相關程式中開啟，或提示使用者選取適當的程式開啟。  

以下 Java 程式碼示範如何將 HTML 與 ZIP 嵌入投影片中：

```java
import com.aspose.slides.*;
import java.io.BufferedInputStream;
import java.io.DataInputStream;
import java.io.File;
import java.io.FileInputStream;

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

在處理簡報時，您可能需要將舊的 OLE 物件換成新的，或將不支援的 OLE 物件替換為支援的。Aspose.Slides for Android via Java 允許您設定嵌入物件的檔案類型，進而更新 OLE 框架資料或其副檔名。  

以下 Java 程式碼示範如何將嵌入的 OLE 物件檔案類型設定為 `zip`：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

String fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();
byte[] fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

System.out.println("Current embedded file extension is: " + fileExtension);

// 將檔案類型變更為 ZIP.
oleFrame.setEmbeddedData(new OleEmbeddedDataInfo(fileData, "zip"));

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **設定嵌入物件的圖示圖片與標題**

嵌入 OLE 物件後，系統會自動新增由圖示圖片組成的預覽。此預覽是使用者在存取或開啟 OLE 物件前看到的畫面。如果您想在預覽中使用特定的圖片與文字，您可以透過 Aspose.Slides for Android via Java 設定圖示圖片與標題。  

以下 Java 程式碼示範如何為嵌入的物件設定圖示圖片與標題：

```java
import com.aspose.slides.*;
import java.io.BufferedInputStream;
import java.io.DataInputStream;
import java.io.File;
import java.io.FileInputStream;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

// 將影像新增至簡報資源中。
File file = new File("image.png");
byte imageData[] = new byte[(int) file.length()];
BufferedInputStream bis = new BufferedInputStream(new FileInputStream(file));
DataInputStream dis = new DataInputStream(bis);
dis.readFully(imageData);
IPPImage oleImage = presentation.getImages().addImage(imageData);

// 設定 OLE 預覽的標題與影像。
oleFrame.setSubstitutePictureTitle("My title");
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **防止 OLE 物件框架被調整大小與重新定位**

在投影片中新增連結的 OLE 物件後，若於 PowerPoint 開啟簡報，可能會出現要求更新連結的訊息。點擊「Update Links」按鈕可能會改變 OLE 物件框架的大小與位置，因為 PowerPoint 會從連結的 OLE 物件更新資料並重新整理物件預覽。為防止 PowerPoint 提示更新物件資料，請將 [IOleObjectFrame](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ioleobjectframe/) 介面的 `setUpdateAutomatic` 方法設為 `false`：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

    oleFrame.setUpdateAutomatic(false);

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **擷取嵌入檔案**

Aspose.Slides for Android via Java 允許您以以下方式擷取投影片中嵌入的 OLE 物件檔案：

1. 建立包含欲擷取之 OLE 物件的 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/Presentation) 類別實例。  
2. 遍歷簡報中的所有形狀，並存取 [OLEObjectFrame](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/oleobjectframe) 形狀。  
3. 從 OLE 物件框架取得嵌入檔案的資料，並寫入磁碟。  

以下 Java 程式碼示範如何將投影片中嵌入的檔案作為 OLE 物件擷取：

```java
import com.aspose.slides.*;
import java.io.File;
import java.io.FileOutputStream;

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

## **常見問題**

### 匯出投影片為 PDF/影像時，會渲染 OLE 內容嗎？

投影片上可見的部分會被渲染——即圖示/替代圖片（預覽）。「即時」的 OLE 內容在渲染過程中不會執行。如有需要，請自行設定預覽圖片，以確保匯出 PDF 時的外觀符合預期。

### 如何在投影片上鎖定 OLE 物件，使使用者在 PowerPoint 中無法移動或編輯它？

鎖定形狀：Aspose.Slides 提供形狀層級的鎖定功能。這不是加密，但能有效防止意外的編輯與移動。

### 為何在開啟簡報時，連結的 Excel 物件會「跳動」或變更大小？

PowerPoint 可能會重新整理連結 OLE 的預覽。為取得穩定的外觀，請遵循 [Worksheet Resizing 的作業解決方案](/slides/zh-hant/androidjava/working-solution-for-worksheet-resizing/)——將框架調整至範圍，或將範圍縮放至固定框架，並設定適當的替代圖片。

### PPTX 格式是否會保留連結 OLE 物件的相對路徑？

在 PPTX 中不支援「相對路徑」資訊——僅儲存完整路徑。相對路徑僅在較舊的 PPT 格式中出現。為確保可攜性，建議使用可靠的絕對路徑/可存取的 URI 或直接嵌入。
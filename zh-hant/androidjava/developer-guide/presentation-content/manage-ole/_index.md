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
- 連結物件
- 連結檔案
- 變更 OLE
- OLE 圖示
- OLE 標題
- 抽取 OLE
- 抽取物件
- 抽取檔案
- PowerPoint
- 簡報
- Android
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Android via Java 優化在 PowerPoint 與 OpenDocument 檔案中的 OLE 物件管理。無縫嵌入、更新與匯出 OLE 內容。"
---
## **介紹**

{{% alert color="info" title="Note" %}}
OLE（Object Linking & Embedding）是 Microsoft 的技術，允許在一個應用程式中建立的資料和物件透過連結或內嵌的方式放置到另一個應用程式中。 
{{% /alert %}} 

考慮在 MS Excel 中建立的圖表。該圖表接著被放入 PowerPoint 投影片中。此 Excel 圖表即被視為 OLE 物件。 

- OLE 物件可能以圖示方式顯示。此時，當您雙擊圖示時，圖表會在其關聯的應用程式（Excel）中開啟，或系統會要求您選擇要開啟或編輯物件的應用程式。
- OLE 物件也可能直接顯示實際內容，例如圖表本身。此時，圖表在 PowerPoint 中被啟動，圖表介面載入，您可以在 PowerPoint 內修改圖表的資料。

[Aspose.Slides for Android via Java](https://products.aspose.com/slides/androidjava/) 允許您將 OLE 物件插入投影片，作為 OLE 物件框架（[OleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleObjectFrame)）。

## **新增 OLE 物件框架到投影片**

假設您已在 Microsoft Excel 中建立圖表，並希望使用 Aspose.Slides for Android via Java 以 OLE 物件框架的方式將其嵌入投影片，您可以這樣做：

1. 建立 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) 類別的實例。
2. 透過索引取得投影片的參考。
3. 將 Excel 檔案讀取為位元組陣列。
4. 將包含位元組陣列及其他 OLE 物件資訊的 [OleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleObjectFrame) 新增至投影片。
5. 將修改後的簡報寫入為 PPTX 檔案。

在下方範例中，我們使用 Aspose.Slides for Android via Java 將 Excel 檔案中的圖表以 OLE 物件框架的形式加入投影片。  
**Note**，[OleEmbeddedDataInfo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleEmbeddedDataInfo) 建構子接受可嵌入物件的副檔名作為第二個參數。此副檔名讓 PowerPoint 能正確辨識檔案類型並選擇正確的程式開啟此 OLE 物件。

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

// Prepare data for the OLE object.
File file = new File("book.xlsx");
byte fileData[] = new byte[(int) file.length()];
BufferedInputStream bis = new BufferedInputStream(new FileInputStream(file));
DataInputStream dis = new DataInputStream(bis);
dis.readFully(fileData);

IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(fileData, "xlsx");

// Add the OLE object frame to the slide.
slide.getShapes().addOleObjectFrame(0, 0, (float) slideSize.getWidth(), (float) slideSize.getHeight(), dataInfo);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

### **新增 連結 OLE 物件框架**

Aspose.Slides for Android via Java 允許您新增一個 [OleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleObjectFrame) 而不嵌入資料，只保留檔案的連結。

以下 Java 程式碼示範如何將連結至 Excel 檔案的 [OleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleObjectFrame) 新增至投影片：

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

若投影片中已嵌入 OLE 物件，您可以透過以下方式輕鬆找出或存取它：

1. 透過建立 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) 類別的實例，載入含有嵌入 OLE 物件的簡報。
2. 使用索引取得投影片的參考。
3. 存取 [OleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleObjectFrame) 形狀。  
   在本例中，我們使用先前建立的僅在第一張投影片上有一個形狀的 PPTX，然後將該物件 *cast* 為 [IOleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleobjectframe/)。這就是我們想要存取的 OLE 物件框架。
4. 取得 OLE 物件框架後，您即可對其執行任何操作。

下列範例示範如何存取 OLE 物件框架（即嵌入於投影片的 Excel 圖表物件）以及其檔案資料。

```java 
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
在本節中，以下程式碼範例使用 [Aspose.Cells for Android via Java](https://docs.aspose.com/cells/androidjava/)。
{{% /alert %}}

若投影片中已嵌入 OLE 物件，您可以透過以下方式輕鬆存取該物件並修改其資料：

1. 透過建立 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) 類別的實例，載入含有嵌入 OLE 物件的簡報。
2. 使用索引取得投影片的參考。 
3. 存取 OLE 物件框架形狀。  
   在本例中，我們使用先前建立的僅在第一張投影片上有一個形狀的 PPTX，然後將該物件 *cast* 為 [IOleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleobjectframe/)。這就是我們想要存取的 OLE 物件框架。
4. 取得 OLE 物件框架後，您即可對其執行任何操作。
5. 建立 `Workbook` 物件並存取 OLE 資料。
6. 存取目標 `Worksheet` 並修改資料。
7. 將更新後的 `Workbook` 儲存至串流。
8. 從串流中變更 OLE 物件資料。

下方範例示範如何存取嵌入於投影片的 OLE 物件框架（Excel 圖表），並修改其檔案資料以更新圖表資料。

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

    // 更改 OLE 框架物件資料。
    IOleEmbeddedDataInfo newData = new OleEmbeddedDataInfo(newOleStream.toByteArray(), oleFrame.getEmbeddedData().getEmbeddedFileExtension());
    oleFrame.setEmbeddedData(newData);
}

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **在投影片中嵌入其他檔案類型**

除了 Excel 圖表外，Aspose.Slides for Android via Java 亦支援將其他類型的檔案嵌入投影片。例如，您可以將 HTML、PDF 與 ZIP 檔案作為物件插入。當使用者雙擊插入的物件時，會自動在相關程式中開啟，或提示使用者選擇適當的程式開啟。

以下 Java 程式碼示範如何將 HTML 與 ZIP 檔案嵌入投影片：

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

在處理簡報時，您可能需要將舊的 OLE 物件取代為新的，或將不受支援的 OLE 物件換成受支援的。Aspose.Slides for Android via Java 允許您設定嵌入物件的檔案類型，從而更新 OLE 框架的資料或副檔名。

以下 Java 程式碼示範如何將嵌入 OLE 物件的檔案類型設定為 `zip`：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

String fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();
byte[] fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

System.out.println("Current embedded file extension is: " + fileExtension);

// 更改檔案類型為 ZIP.
oleFrame.setEmbeddedData(new OleEmbeddedDataInfo(fileData, "zip"));

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **設定嵌入物件的圖示影像與標題**

嵌入 OLE 物件後，系統會自動新增一個由圖示影像組成的預覽。這個預覽即是使用者在存取或開啟 OLE 物件前所看到的畫面。如果您想使用特定的影像與文字作為預覽的元素，可以透過 Aspose.Slides for Android via Java 設定圖示影像與標題。

以下 Java 程式碼示範如何為嵌入物件設定圖示影像與標題：

```java
import com.aspose.slides.*;
import java.io.BufferedInputStream;
import java.io.DataInputStream;
import java.io.File;
import java.io.FileInputStream;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

// 將圖片加入簡報資源。
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

## **防止 OLE 物件框架被重新調整大小或重新定位**

在投影片中加入連結 OLE 物件後，若於 PowerPoint 開啟簡報，可能會出現要求更新連結的訊息。點選「Update Links」按鈕可能會因 PowerPoint 從連結 OLE 物件更新資料並重新整理預覽，而改變 OLE 物件框架的大小與位置。若要防止 PowerPoint 提示更新物件資料，請以 `false` 呼叫 [setUpdateAutomatic](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleobjectframe/#setUpdateAutomatic-boolean-) 方法，設定於 [IOleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleobjectframe/) 介面：

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

## **抽取嵌入檔案**

Aspose.Slides for Android via Java 允許您以以下方式抽取投影片中作為 OLE 物件嵌入的檔案：

1. 建立包含欲抽取 OLE 物件之 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) 類別的實例。
2. 迭代簡報中的所有形狀，存取 [OLEObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/oleobjectframe) 形狀。
3. 從 OLE 物件框架取得嵌入檔案的資料，並寫入磁碟。

以下 Java 程式碼示範如何抽取投影片中以 OLE 物件形式嵌入的檔案：

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

**在將投影片匯出為 PDF/影像時，會呈現 OLE 內容嗎？**

投影片上可見的部分會被渲染——圖示/替代影像（預覽）。「即時」的 OLE 內容在渲染過程中不會被執行。若有需要，請自行設定預覽影像，以確保匯出 PDF 後的外觀如預期。

若同時想將嵌入的檔案保留為 PDF 附件，請以 `true` 呼叫 [setIncludeOleData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setIncludeOleData-boolean-)。此選項預設為關閉。相關範例與檢查附件的說明請參見 [將嵌入 OLE 檔案保存為 PDF 附件](/slides/zh-hant/androidjava/convert-powerpoint-to-pdf/#preserve-embedded-ole-files-as-pdf-attachments)。

**如何鎖定投影片上的 OLE 物件，使使用者在 PowerPoint 中無法移動或編輯？**

鎖定形狀：Aspose.Slides 提供形狀層級的鎖定功能。這不是加密，但可有效防止意外的編輯與移動。

**為何在開啟簡報時，連結的 Excel 物件會「跳動」或變更尺寸？**

PowerPoint 可能會重新整理連結 OLE 的預覽。若需穩定的外觀，請遵循 [工作表重新調整大小的解決方案](/slides/zh-hant/androidjava/working-solution-for-worksheet-resizing/)——將框架調整至範圍大小，或將範圍縮放至固定框架並設定適當的替代影像。

**PPTX 格式會保留連結 OLE 物件的相對路徑嗎？**

在 PPTX 中，沒有「相對路徑」資訊——僅保留完整路徑。相對路徑僅出現在舊版 PPT 格式。為提升可移植性，建議使用可靠的絕對路徑/可存取的 URI 或直接嵌入檔案。
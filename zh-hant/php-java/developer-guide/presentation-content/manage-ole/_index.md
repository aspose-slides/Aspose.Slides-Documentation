---
title: 使用 PHP 在簡報中管理 OLE
linktitle: 管理 OLE
type: docs
weight: 40
url: /zh-hant/php-java/manage-ole/
keywords:
- OLE 物件
- 物件鏈結與嵌入
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
- 擷取 OLE
- 擷取 物件
- 擷取 檔案
- PowerPoint
- 簡報
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides for PHP via Java，優化 PowerPoint 與 OpenDocument 檔案中的 OLE 物件管理。輕鬆嵌入、更新與匯出 OLE 內容。"
---
## **簡介**

{{% alert color="info" title="Note" %}}
OLE（Object Linking & Embedding）是微軟技術，可讓在一個應用程式中建立的資料和物件透過鏈結或嵌入方式放入另一個應用程式中。 
{{% /alert %}} 

考慮在 Microsoft Excel 中建立的圖表。該圖表接著被放入 PowerPoint 投影片中。此 Excel 圖表即被視為 OLE 物件。 

- OLE 物件可能以圖示形式顯示。此時，當您雙擊圖示時，圖表會在其關聯的應用程式 (Excel) 中開啟，或系統會要求您選擇應用程式來開啟或編輯該物件。  
- OLE 物件也可能直接顯示實際內容，例如圖表的內容。此時，圖表在 PowerPoint 中被啟用，圖表介面載入，您可以在 PowerPoint 內修改圖表資料。  

[Aspose.Slides for PHP via Java](https://products.aspose.com/slides/php-java/) 允許您將 OLE 物件作為 OLE 物件框插入投影片中（[OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/)）。

## **將 OLE 物件框新增至投影片**

假設您已在 Microsoft Excel 中建立圖表，並希望使用 Aspose.Slides for PHP via Java 將其作為 OLE 物件框嵌入投影片中，您可以按照以下步驟操作：

1. 建立 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 類別的執行個體。  
2. 透過索引取得投影片的參考。  
3. 將 Excel 檔案讀取為位元組陣列。  
4. 將 [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/) 新增至投影片，並提供位元組陣列及其他 OLE 物件資訊。  
5. 將修改後的簡報寫入為 PPTX 檔案。  

在下方範例中，我們使用 Aspose.Slides for PHP via Java，將 Excel 檔案中的圖表新增為 OLE 物件框至投影片中。  
**注意**，[OleEmbeddedDataInfo](https://reference.aspose.com/slides/php-java/aspose.slides/oleembeddeddatainfo/) 建構函式將可嵌入物件的副檔名作為第二個參數。此副檔名讓 PowerPoint 正確解讀檔案類型並選擇適當的應用程式來開啟此 OLE 物件。

```php
$presentation = new Presentation();
$slideSize = $presentation->getSlideSize()->getSize();
$slide = $presentation->getSlides()->get_Item(0);

// Prepare data for the OLE object.
$fileData = file_get_contents("book.xlsx");
$dataInfo = new OleEmbeddedDataInfo($fileData, "xlsx");

// Add the OLE object frame to the slide.
$slide->getShapes()->addOleObjectFrame(0, 0, $slideSize->getWidth(), $slideSize->getHeight(), $dataInfo);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

### **新增已連結的 OLE 物件框**

Aspose.Slides for PHP via Java 允許您新增一個不嵌入資料、僅以檔案連結方式的 [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/)。  

以下 PHP 程式碼示範如何將帶有連結 Excel 檔案的 [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/) 新增至投影片：
```php
$presentation = new Presentation();
$slide = $presentation->getSlides()->get_Item(0);

// 新增具有連結 Excel 檔案的 OLE 物件框。
$slide->getShapes()->addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **存取 OLE 物件框**

如果投影片中已嵌入 OLE 物件，您可以透過以下方式輕鬆找到或存取它：

1. 透過建立 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 類別的執行個體，載入含有嵌入 OLE 物件的簡報。  
2. 以索引取得投影片的參考。  
3. 取得 [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/) 形狀。在本例中，我們使用先前建立的 PPTX，該檔案在第一張投影片上僅有一個形狀。  
4. 取得 OLE 物件框後，您即可對其執行任何操作。  

在下方範例中，存取了 OLE 物件框（嵌入投影片的 Excel 圖表物件）及其檔案資料。  
```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$shape = $slide->getShapes()->get_Item(0);

if (java_instanceof($shape, new JavaClass("com.aspose.slides.OleObjectFrame"))) {
    $oleFrame = $shape;
    
    // 取得嵌入檔案資料。
    $fileData = $oleFrame->getEmbeddedData()->getEmbeddedFileData();

    // 取得嵌入檔案的副檔名。
    $fileExtension = $oleFrame->getEmbeddedData()->getEmbeddedFileExtension();

    // ...
}
```

### **存取已連結 OLE 物件框屬性**

Aspose.Slides 允許您存取已連結 OLE 物件框的屬性。  

以下 PHP 程式碼示範如何檢查 OLE 物件是否為已連結，並取得連結檔案的路徑：
```php
$presentation = new Presentation("sample.ppt");
$slide = $presentation->getSlides()->get_Item(0);
$shape = $slide->getShapes()->get_Item(0);

if (java_instanceof($shape, new JavaClass("com.aspose.slides.OleObjectFrame"))) {
    $oleFrame = $shape;

    // 檢查 OLE 物件是否為已連結。
    if (java_values($oleFrame->isObjectLink()) != 0) {
        // 輸出連結檔案的完整路徑。
        echo "OLE object frame is linked to: " . $oleFrame->getLinkPathLong() . PHP_EOL;

        // 若存在，輸出連結檔案的相對路徑。
        // 只有 PPT 簡報可以包含相對路徑。
        $relativePath = java_values($oleFrame->getLinkPathRelative());
        if (!is_null($relativePath) && $relativePath !== "") {
            echo "OLE object frame relative path: " . $oleFrame->getLinkPathRelative() . PHP_EOL;
        }
    }
}

$presentation->dispose();
```

## **變更 OLE 物件資料**

{{% alert color="info" title="Note" %}}
在本節中，下方程式碼範例使用 [Aspose.Cells for PHP via Java](https://docs.aspose.com/cells/php-java/)。
{{% /alert %}}

如果投影片中已嵌入 OLE 物件，您可以透過以下方式輕鬆存取該物件並修改其資料：

1. 透過建立 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 類別的執行個體，載入含有嵌入 OLE 物件的簡報。  
2. 以索引取得投影片的參考。  
3. 取得 [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/) 形狀。在本例中，我們使用先前建立的 PPTX，該檔案在第一張投影片上僅有一個形狀。  
4. 取得 OLE 物件框後，您即可對其執行任何操作。  
5. 建立 `Workbook` 物件並存取 OLE 資料。  
6. 取得目標 `Worksheet`，並修改資料。  
7. 將更新後的 `Workbook` 儲存至串流中。  
8. 從串流變更 OLE 物件資料。  

在下方範例中，存取了 OLE 物件框（嵌入投影片的 Excel 圖表物件），並修改其檔案資料以更新圖表資料。
```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$shape = $slide->getShapes()->get_Item(0);

if (java_instanceof($shape, new JavaClass("com.aspose.slides.OleObjectFrame"))) {
    $oleFrame = $shape;

    $oleStream = new Java("java.io.ByteArrayInputStream", $oleFrame->getEmbeddedData()->getEmbeddedFileData());

    // 將 OLE 物件資料讀取為 Workbook 物件。
    $workbook = new Workbook($oleStream);

    $newOleStream = new Java("java.io.ByteArrayOutputStream");

    // 修改工作簿資料。
    $workbook->getWorksheets()->get(0)->getCells()->get(0, 4)->putValue("E");
    $workbook->getWorksheets()->get(0)->getCells()->get(1, 4)->putValue(12);
    $workbook->getWorksheets()->get(0)->getCells()->get(2, 4)->putValue(14);
    $workbook->getWorksheets()->get(0)->getCells()->get(3, 4)->putValue(15);

    $fileOptions = new OoxmlSaveOptions(SaveFormat::XLSX);
    $workbook->save($newOleStream, $fileOptions);

    // 變更 OLE 框物件資料。
    $newData = new OleEmbeddedDataInfo($newOleStream->toByteArray(), $oleFrame->getEmbeddedData()->getEmbeddedFileExtension());
    $oleFrame->setEmbeddedData($newData);

    $newOleStream->close();
    $oleStream->close();
}

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **在投影片中嵌入其他檔案類型**

除了 Excel 圖表外，Aspose.Slides for PHP via Java 也允許您將其他類型的檔案嵌入投影片。例如，您可以插入 HTML、PDF 與 ZIP 檔案作為物件。當使用者雙擊插入的物件時，會自動以相關程式開啟，或系統會提示使用者選擇適當的程式開啟。  

以下 PHP 程式碼示範如何將 HTML 與 ZIP 檔案嵌入投影片：
```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);

$htmlData = file_get_contents("sample.html");
$htmlDataInfo = new OleEmbeddedDataInfo($htmlData, "html");
$htmlOleFrame = $slide->getShapes()->addOleObjectFrame(150, 120, 50, 50, $htmlDataInfo);
$htmlOleFrame->setObjectIcon(true);

$zipData = file_get_contents("sample.zip");
$zipDataInfo = new OleEmbeddedDataInfo($zipData, "zip");
$zipOleFrame = $slide->getShapes()->addOleObjectFrame(150, 220, 50, 50, $zipDataInfo);
$zipOleFrame->setObjectIcon(true);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **設定嵌入物件的檔案類型**

處理簡報時，您可能需要將舊的 OLE 物件取代為新物件，或將不受支援的 OLE 物件換成受支援的。Aspose.Slides for PHP via Java 允許您設定嵌入物件的檔案類型，以便更新 OLE 框資料或其副檔名。  

以下 PHP 程式碼示範如何將嵌入的 OLE 物件檔案類型設定為 `zip`：
```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$oleFrame = $slide->getShapes()->get_Item(0);

$fileExtension = $oleFrame->getEmbeddedData()->getEmbeddedFileExtension();
$fileData = $oleFrame->getEmbeddedData()->getEmbeddedFileData();

echo "Current embedded file extension is: " . $fileExtension . PHP_EOL;

// Change the file type to ZIP.
$oleFrame->setEmbeddedData(new OleEmbeddedDataInfo($fileData, "zip"));

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **設定嵌入物件的圖示影像與標題**

嵌入 OLE 物件後，系統會自動加入由圖示影像組成的預覽。此預覽是使用者在存取或開啟 OLE 物件前所見的畫面。如需使用特定影像與文字作為預覽元素，可使用 Aspose.Slides for PHP via Java 設定圖示影像與標題。  

以下 PHP 程式碼示範如何為嵌入的物件設定圖示影像與標題：
```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$oleFrame = $slide->getShapes()->get_Item(0);

// 新增影像至簡報資源。
$imageData = file_get_contents("image.png");
$oleImage = $presentation->getImages()->addImage($imageData);

// Set a title and the image for the OLE preview.
$oleFrame->setSubstitutePictureTitle("My title");
$oleFrame->getSubstitutePictureFormat()->getPicture()->setImage($oleImage);
$oleFrame->setObjectIcon(true);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **防止 OLE 物件框被重新調整大小與重新定位**

將已連結的 OLE 物件新增至簡報投影片後，於 PowerPoint 開啟簡報時，可能會看到要求更新連結的訊息。點選「Update Links」按鈕可能會因 PowerPoint 從已連結的 OLE 物件更新資料並重新整理物件預覽，而改變 OLE 物件框的大小與位置。若要防止 PowerPoint 提示更新物件資料，請以 `false` 呼叫 [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/) 類別的 [setUpdateAutomatic](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/#setUpdateAutomatic) 方法：
```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$oleFrame = $slide->getShapes()->get_Item(0);

$oleFrame->setUpdateAutomatic(false);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **擷取嵌入檔案**

Aspose.Slides for PHP via Java 允許您透過以下方式擷取投影片中以 OLE 物件形式嵌入的檔案：

1. 建立含有欲擷取 OLE 物件之 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 類別的執行個體。  
2. 迭代簡報中的所有形狀，並存取 [OLEObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/) 形狀。  
3. 從 OLE 物件框取得嵌入檔案的資料，並寫入磁碟。  

以下 PHP 程式碼示範如何將投影片中嵌入的檔案以 OLE 物件方式擷取：
```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);

$shapeCount = java_values($slide->getShapes()->size());
for ($index = 0; $index < $shapeCount; $index++) {
    $shape = $slide->getShapes()->get_Item($index);

    if (java_instanceof($shape, new JavaClass("com.aspose.slides.OleObjectFrame"))) {
        $oleFrame = $shape;

        $fileData = $oleFrame->getEmbeddedData()->getEmbeddedFileData();
        $fileExtension = $oleFrame->getEmbeddedData()->getEmbeddedFileExtension();

        $filePath = "OLE_object_" . $index . $fileExtension;
        file_put_contents($filePath, $fileData);
    }
}

$presentation->dispose();
```

## **常見問題**

**在將投影片匯出為 PDF/影像時，會渲染 OLE 內容嗎？**

投影片上可見的部分會被渲染——即圖示/替代影像（預覽）。「即時」的 OLE 內容在渲染過程中不會執行。如有需要，可自行設定預覽影像，以確保匯出 PDF 時呈現預期的外觀。  
若要同時將嵌入的檔案保留為 PDF 附件，請以 `true` 呼叫 [setIncludeOleData](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/#setIncludeOleData)。此選項預設為停用。範例與檢查附件的說明請參閱 [Preserve Embedded OLE Files as PDF Attachments](/slides/zh-hant/php-java/convert-powerpoint-to-pdf/#preserve-embedded-ole-files-as-pdf-attachments)。

**如何在投影片上鎖定 OLE 物件，使使用者在 PowerPoint 中無法移動/編輯？**

鎖定形狀：Aspose.Slides 提供形狀層級的鎖定功能。這並非加密，但可有效防止意外的編輯與移動。

**在 PPTX 格式中，已連結 OLE 物件的相對路徑會被保留嗎？**

在 PPTX 中，不會保留「相對路徑」資訊—僅有完整路徑。相對路徑僅出現在舊版 PPT 格式。為了可移植性，建議使用可靠的絕對路徑或可存取的 URI，或直接嵌入。
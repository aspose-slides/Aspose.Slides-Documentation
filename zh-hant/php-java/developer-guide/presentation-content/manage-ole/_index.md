---
title: 使用 PHP 管理簡報中的 OLE
linktitle: 管理 OLE
type: docs
weight: 40
url: /zh-hant/php-java/manage-ole/
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
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides for PHP via Java，優化 PowerPoint 與 OpenDocument 檔案中的 OLE 物件管理，輕鬆嵌入、更新與匯出 OLE 內容。"
---
## **簡介**

{{% alert color="primary" %}} 

OLE（Object Linking & Embedding）是微軟的技術，允許在一個應用程式中建立的資料與物件透過連結或嵌入的方式放置於另一個應用程式中。 

{{% /alert %}} 

想像在 Microsoft Excel 中建立的圖表，然後將該圖表放入 PowerPoint 投影片中。此 Excel 圖表即被視為 OLE 物件。 

- OLE 物件可能顯示為圖示。此情況下，雙擊圖示時，圖表會在其關聯的應用程式（Excel）中開啟，或會要求您選取開啟或編輯物件的應用程式。 
- OLE 物件也可能直接顯示其實際內容，例如圖表本身。此時，圖表在 PowerPoint 中被啟動，圖表介面載入，您即可在 PowerPoint 內修改圖表資料。

[Aspose.Slides for PHP via Java](https://products.aspose.com/slides/zh-hant/php-java/) 允許您將 OLE 物件插入投影片，作為 OLE 物件框（[OleObjectFrame](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/oleobjectframe/)）。

## **將 OLE 物件框加入投影片**

假設您已在 Microsoft Excel 中建立了圖表，並希望使用 Aspose.Slides for PHP via Java 將其以 OLE 物件框嵌入投影片，可按以下方式操作：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/) 類別的執行個體。  
1. 透過索引取得投影片的參照。  
1. 以位元組陣列方式讀取 Excel 檔案。  
1. 將 [OleObjectFrame](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/oleobjectframe/) 加入投影片，並提供位元組陣列以及其他 OLE 物件資訊。  
1. 將修改後的簡報寫出為 PPTX 檔案。  

在下方範例中，我們使用 Aspose.Slides for PHP via Java，將 Excel 檔案中的圖表作為 OLE 物件框加入投影片。  
**注意**，[OleEmbeddedDataInfo](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/oleembeddeddatainfo/) 建構函式的第二個參數是可嵌入物件的副檔名。此副檔名讓 PowerPoint 能正確判斷檔案類型，並選擇適當的應用程式開啟此 OLE 物件。

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

### **新增連結的 OLE 物件框**

Aspose.Slides for PHP via Java 允許您新增一個不嵌入資料、僅以檔案連結方式的 [OleObjectFrame](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/oleobjectframe/)。

以下 PHP 程式碼示範如何將連結至 Excel 檔案的 [OleObjectFrame](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/oleobjectframe/) 加入投影片：

```php
$presentation = new Presentation();
$slide = $presentation->getSlides()->get_Item(0);

// 新增一個連結至 Excel 檔案的 OLE 物件框。
$slide->getShapes()->addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **存取 OLE 物件框**

若投影片中已嵌入 OLE 物件，您可以透過以下方式輕鬆查找或存取它：

1. 透過建立 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/) 類別的執行個體，載入已嵌入 OLE 物件的簡報。  
2. 使用索引取得投影片的參照。  
3. 存取 [OleObjectFrame](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/oleobjectframe/) 形狀。於本範例中，我們使用先前建立的 PPTX，該檔案在第一張投影片上僅有一個形狀。  
4. 取得 OLE 物件框後，您可以對其執行任何操作。  

以下範例示範如何存取 OLE 物件框（嵌入於投影片的 Excel 圖表物件）及其檔案資料。

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

### **存取連結的 OLE 物件框屬性**

Aspose.Slides 允許您存取連結的 OLE 物件框屬性。

以下 PHP 程式碼示範如何檢查 OLE 物件是否為連結，並取得連結檔案的路徑：

```php
$presentation = new Presentation("sample.ppt");
$slide = $presentation->getSlides()->get_Item(0);
$shape = $slide->getShapes()->get_Item(0);

if (java_instanceof($shape, new JavaClass("com.aspose.slides.OleObjectFrame"))) {
    $oleFrame = $shape;

    // 檢查 OLE 物件是否為連結。
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

{{% alert color="primary" %}} 

本節的程式碼範例使用 [Aspose.Cells for PHP via Java](/cells/php-java/)。 

{{% /alert %}}

若投影片中已嵌入 OLE 物件，您可以透過以下方式存取該物件並修改其資料：

1. 透過建立 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/) 類別的執行個體，載入已嵌入 OLE 物件的簡報。  
2. 使用索引取得投影片的參照。  
3. 存取 [OleObjectFrame](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/oleobjectframe/) 形狀。於本範例中，我們使用先前建立的 PPTX，該檔案在第一張投影片上僅有一個形狀。  
4. 取得 OLE 物件框後，您可以對其執行任何操作。  
5. 建立 `Workbook` 物件並存取 OLE 資料。  
6. 存取目標 `Worksheet` 並修改資料。  
7. 將更新後的 `Workbook` 儲存至串流。  
8. 從串流變更 OLE 物件資料。  

以下範例示範如何存取 OLE 物件框（嵌入於投影片的 Excel 圖表物件），並修改其檔案資料以更新圖表資料。

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$shape = $slide->getShapes()->get_Item(0);

if (java_instanceof($shape, new JavaClass("com.aspose.slides.OleObjectFrame"))) {
    $oleFrame = $shape;

    $oleStream = new ByteArrayInputStream($oleFrame->getEmbeddedData()->getEmbeddedFileData());

    // 將 OLE 物件資料讀取為 Workbook 物件。
    $workbook = new Workbook($oleStream);

    $newOleStream = new Java("java.io.ByteArrayOutputStream");

    // 修改 Workbook 資料。
    $workbook->getWorksheets()->get(0)->getCells()->get(0, 4)->putValue("E");
    $workbook->getWorksheets()->get(0)->getCells()->get(1, 4)->putValue(12);
    $workbook->getWorksheets()->get(0)->getCells()->get(2, 4)->putValue(14);
    $workbook->getWorksheets()->get(0)->getCells()->get(3, 4)->putValue(15);

    $fileOptions = new OoxmlSaveOptions(SaveFormat::XLSX);
    $workbook->save($newOleStream, $fileOptions);

    // 變更 OLE 物件框的資料。
    $newData = new OleEmbeddedDataInfo($newOleStream->toByteArray(), $oleFrame->getEmbeddedData()->getEmbeddedFileExtension());
    $oleFrame->setEmbeddedData($newData);

    $newOleStream->close();
    $oleStream->close();
}

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **在投影片中嵌入其他檔案類型**

除了 Excel 圖表，Aspose.Slides for PHP via Java 還允許您將其他類型的檔案嵌入投影片。例如，您可以將 HTML、PDF 與 ZIP 檔案作為物件插入。使用者雙擊插入的物件時，會自動以相關程式開啟，或出現提示讓使用者選取適當的程式。

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

在處理簡報時，您可能需要將舊的 OLE 物件替換為新的，或將不支援的 OLE 物件替換為支援的。Aspose.Slides for PHP via Java 允許您為嵌入物件設定檔案類型，從而更新 OLE 框資料或其副檔名。

以下 PHP 程式碼示範如何將嵌入 OLE 物件的檔案類型設為 `zip`：

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

## **設定嵌入物件的圖示與標題**

嵌入 OLE 物件後，系統會自動加入包含圖示的預覽。此預覽即為使用者在存取或開啟 OLE 物件前看到的內容。若您希望使用特定圖像與文字作為預覽元素，可透過 Aspose.Slides for PHP via Java 設定圖示圖像與標題。

以下 PHP 程式碼示範如何為嵌入物件設定圖示圖像與標題：

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$oleFrame = $slide->getShapes()->get_Item(0);

// 新增影像至簡報資源中。
$imageData = file_get_contents("image.png");
$oleImage = $presentation->getImages()->addImage($imageData);

// 設定 OLE 預覽的標題與影像。
$oleFrame->setSubstitutePictureTitle("My title");
$oleFrame->getSubstitutePictureFormat()->getPicture()->setImage($oleImage);
$oleFrame->setObjectIcon(true);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **防止 OLE 物件框被重新調整大小與重新定位**

將連結的 OLE 物件加入簡報投影片後，於 PowerPoint 開啟簡報時，可能會看到提示要求更新連結。點擊「Update Links」按鈕可能會因 PowerPoint 從連結的 OLE 物件更新資料並重新整理物件預覽，而改變 OLE 物件框的大小與位置。若要防止 PowerPoint 提示更新物件資料，請將 [OleObjectFrame](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/oleobjectframe/) 類別的 `setUpdateAutomatic` 方法設為 `false`：

```php
$oleFrame->setUpdateAutomatic(false);
```

## **提取嵌入的檔案**

Aspose.Slides for PHP via Java 允許您依下列步驟提取投影片中作為 OLE 物件嵌入的檔案：

1. 建立包含欲提取 OLE 物件的 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/) 類別的執行個體。  
2. 逐一遍歷簡報中的所有形狀，存取 [OLEObjectFrame](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/oleobjectframe/) 形狀。  
3. 從 OLE 物件框取得嵌入檔案的資料，並寫入磁碟。  

以下 PHP 程式碼示範如何將投影片中以 OLE 物件形式嵌入的檔案提取出來：

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

**匯出投影片為 PDF/影像時，OLE 內容會被呈現嗎？**

會呈現投影片上可見的內容——圖示/替代影像（預覽）。「即時」的 OLE 內容不會在渲染過程中執行。如有需要，請自行設定預覽影像，以確保在匯出 PDF 時的外觀如預期。

**如何將 OLE 物件鎖定在投影片上，使使用者在 PowerPoint 中無法移動/編輯它？**

鎖定形狀：Aspose.Slides 提供形狀層級的鎖定功能。這並非加密，但可有效防止意外的編輯與移動。

**PPTX 格式會保留連結 OLE 物件的相對路徑嗎？**

在 PPTX 中不會保存「相對路徑」資訊——僅有完整路徑。相對路徑僅存在於較舊的 PPT 格式。若需可攜性，建議使用可靠的絕對路徑/可存取的 URI，或直接嵌入檔案。
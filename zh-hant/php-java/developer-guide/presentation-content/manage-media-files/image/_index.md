---
title: 使用 PHP 優化簡報中的影像管理
linktitle: 管理影像
type: docs
weight: 10
url: /zh-hant/php-java/image/
keywords:
- 新增影像
- 新增圖片
- 新增點陣圖
- 取代影像
- 取代圖片
- 來自網路
- 背景
- 新增 PNG
- 新增 JPG
- 新增 SVG
- 外部 SVG 資源
- SVG 解析器
- 連結的 SVG 圖片
- SVG 字型
- 新增 EMF
- 新增 WMF
- 新增 TIFF
- PowerPoint
- OpenDocument
- 簡報
- EMF
- SVG
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides for PHP via Java，簡化 PowerPoint 與 OpenDocument 中的影像管理，優化效能並自動化工作流程。"
---
## **簡介**

圖片使簡報更具吸引力且更具視覺效果。 在 Microsoft PowerPoint 中，您可以從檔案、網路或其他來源將圖片插入投影片。 同樣地，Aspose.Slides 允許您以多種方式將圖片新增至簡報投影片。

{{% alert  title="Tip" color="primary" %}} 

Aspose 提供免費的轉換器—[JPEG 轉 PowerPoint](https://products.aspose.app/slides/zh-hant/import/jpg-to-ppt) 與 [PNG 轉 PowerPoint](https://products.aspose.app/slides/zh-hant/import/png-to-ppt)—讓您能快速從圖片建立簡報。 

{{% /alert %}} 

{{% alert title="Info" color="info" %}}

如果您想將圖片作為圖片框添加——尤其是計畫調整大小、套用效果或使用其他標準格式化選項——請參閱 [Picture Frame](/slides/zh-hant/php-java/picture-frame/)。 

{{% /alert %}} 

{{% alert title="Note" color="warning" %}}

您可以將圖片從一種格式轉換為另一種格式。請參閱以下頁面：轉換 [image to JPG](https://products.aspose.com/slides/zh-hant/php-java/conversion/image-to-jpg/)、[JPG to image](https://products.aspose.com/slides/zh-hant/php-java/conversion/jpg-to-image/)、[JPG to PNG](https://products.aspose.com/slides/zh-hant/php-java/conversion/jpg-to-png/)、[PNG to JPG](https://products.aspose.com/slides/zh-hant/php-java/conversion/png-to-jpg/)、[PNG to SVG](https://products.aspose.com/slides/zh-hant/php-java/conversion/png-to-svg/)、以及 [SVG to PNG](https://products.aspose.com/slides/zh-hant/php-java/conversion/svg-to-png/)。 

{{% /alert %}}

Aspose.Slides 支援 JPEG、PNG、BMP、GIF 等常見格式的圖片。

## **將本機儲存的圖片加入投影片**

您可以將電腦上儲存的一或多張圖片加入簡報投影片。以下 PHP 範例程式碼示範如何將圖片加入投影片：

```php
$pres = new Presentation();
try {
    $slide = $pres->getSlides()->get_Item(0);

    $picture = null;
    $image = Images::fromFile("image.png");
    try {
        $picture = $pres->getImages()->addImage($image);
    } finally {
        if (!java_is_null($image)) {
            $image->dispose();
        }
    }

    $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $picture);

    $pres->save("pres.pptx", SaveFormat::Pptx);
} finally {
    $pres->dispose();
}
```

## **從網路將圖片加入投影片**

如果您要加入投影片的圖片未儲存在本機，您可以直接從網路加入。

以下 PHP 範例程式碼示範如何從網路將圖片加入投影片：

```php
$pres = new Presentation();
try {
    $slide = $pres->getSlides()->get_Item(0);

    $imageUrl = new Java("java.net.URL", "[REPLACE WITH URL]");
    $connection = $imageUrl->openConnection();
    $inputStream = $connection->getInputStream();

    $outputStream = new Java("java.io.ByteArrayOutputStream");
    $Array = new JavaClass("java.lang.reflect.Array");
    $Byte = (new JavaClass("java.lang.Byte"))->TYPE;

    try {
        $buffer = $Array->newInstance($Byte, 1024);

        while (($read = java_values($inputStream->read($buffer, 0, $Array->getLength($buffer)))) != -1) {
            $outputStream->write($buffer, 0, $read);
        }

        $outputStream->flush();

        $image = $pres->getImages()->addImage($outputStream->toByteArray());
        $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $image);
    } finally {
        if (!java_is_null($inputStream)) {
            $inputStream->close();
        }
        $outputStream->close();
    }

    $pres->save("pres.pptx", SaveFormat::Pptx);
} catch (JavaException $e) {
} finally {
    $pres->dispose();
}
```

## **將圖片加入投影片母片**

投影片母片會儲存並控制使用該母片之投影片的佈景主題與版面配置。將圖片加入投影片母片後，該圖片會出現在所有以此母片為基礎的投影片上。

以下 PHP 範例程式碼示範如何將圖片加入投影片母片：

```php
$pres = new Presentation();
try {
    $slide = $pres->getSlides()->get_Item(0);
    $masterSlide = $slide->getLayoutSlide()->getMasterSlide();

    $picture = null;
    $image = Images::fromFile("image.png");
    try {
        $picture = $pres->getImages()->addImage($image);
    } finally {
        if (!java_is_null($image)) {
            $image->dispose();
        }
    }

    $masterSlide->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $picture);

    $pres->save("pres.pptx", SaveFormat::Pptx);
} finally {
    $pres->dispose();
}
```

## **將圖片作為投影片背景**

您可以將圖片作為一或多張投影片的背景。詳情請參閱 *[Setting Images as Backgrounds for Slides](/slides/zh-hant/php-java/presentation-background/#setting-images-as-background-for-slides)*。

## **將 SVG 加入簡報**

可使用 [SvgImage](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/svgimage/) 類別將 SVG 內容加入簡報。產生的 SVG 圖片物件隨後可加入簡報的圖片集合，並用於建立圖片框。

以下 PHP 範例匯入一段自包含的 SVG 字串。所有圖片、樣式與其他資源皆直接嵌入於 SVG 內容中。

```php
$svgContent =
    "<svg xmlns='http://www.w3.org/2000/svg' width='320' height='180'>" .
    "    <rect width='320' height='180' fill='#4F81BD'/>" .
    "    <circle cx='160' cy='90' r='55' fill='#F2F2F2'/>" .
    "</svg>";

$presentation = new Presentation();
try {
    $svgImage = new SvgImage($svgContent);
    $image = $presentation->getImages()->addImage($svgImage);

    $presentation->getSlides()->get_Item(0)->getShapes()->addPictureFrame(
        ShapeType::Rectangle,
        20,
        20,
        $image->getWidth(),
        $image->getHeight(),
        $image
    );

    $presentation->save("self-contained-svg.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **匯入含外部資源的 SVG 內容**

從設計工具、圖表編輯器、圖示系統或網路管線匯出的 SVG 檔案可能會參考儲存在 SVG 文件之外的資源。例如，SVG 可能包含 `images/photo.png` 之圖片連結、CSS `url(...)` 值，或字型 URL。

要匯入此類 SVG 內容，請建立一個 [ExternalResourceResolver](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/externalresourceresolver/) 實作，並將其與基礎 URI 一起傳遞給相應的 [SvgImage](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/svgimage/) 建構函式。基礎 URI 會指示 SVG 文件的位置，並用於解析相對連結。

SVG 圖片物件提供存取匯入 SVG 資訊的介面：

- `getSvgContent()` 會回傳 SVG 標記字串。
- `getSvgData()` 會回傳 SVG 內容的位元組陣列。
- `getBaseUri()` 會回傳用於相對連結的基礎 URI。
- `getExternalResourceResolver()` 會回傳指派給 SVG 圖片的解析器。

### **實作外部資源解析器**

此解析器具備兩個方法：

- `resolveUri` 會結合基礎 URI 與相對資源連結並回傳絕對 URI。若無法解析或不允許，回傳 `null`。
- `getEntity` 會為絕對資源 URI 回傳可讀取的串流。若資源缺失、被封鎖或無法取得，回傳 `null`。必要時也可回傳備援串流。

以下解析器僅從允許的本機目錄載入連結資源。網路資源與超出允許目錄的路徑皆會被阻擋。對於無法解析的圖片連結，會回傳備援圖片。

```php
class LocalSvgResourceResolver extends ExternalResourceResolver
{
    private $allowedRoot;
    private $fallbackImageData;

    public function __construct($allowedRoot, $fallbackImageData)
    {
        parent::__construct();

        $Paths = new JavaClass("java.nio.file.Paths");
        $this->allowedRoot = $Paths->get($allowedRoot)->toAbsolutePath()->normalize();
        $this->fallbackImageData = $fallbackImageData;
    }

    public function resolveUri($baseUri, $relativeUri)
    {
        if ($baseUri === null || trim(java_values($baseUri)) === "" ||
            $relativeUri === null || trim(java_values($relativeUri)) === "") {
            return null;
        }

        try {
            $URI = new JavaClass("java.net.URI");
            $baseAddress = $URI->create($baseUri);
            $absoluteAddress = $baseAddress->resolve($relativeUri);

            // 此解析器僅允許本機檔案。
            if (strcasecmp(java_values($absoluteAddress->getScheme()), "file") !== 0) {
                return null;
            }

            $Paths = new JavaClass("java.nio.file.Paths");
            $resourcePath = $Paths->get($absoluteAddress)->toAbsolutePath()->normalize();

            if (!$this->isInsideAllowedRoot($resourcePath)) {
                return null;
            }

            return $resourcePath->toUri()->toString();
        } catch (JavaException $e) {
            return null;
        }
    }

    public function getEntity($absoluteUri)
    {
        try {
            $URI = new JavaClass("java.net.URI");
            $resourceUri = $URI->create($absoluteUri);

            if (strcasecmp(java_values($resourceUri->getScheme()), "file") !== 0) {
                return null;
            }

            $Paths = new JavaClass("java.nio.file.Paths");
            $resourcePath = $Paths->get($resourceUri)->toAbsolutePath()->normalize();

            if (!$this->isInsideAllowedRoot($resourcePath)) {
                return null;
            }

            $Files = new JavaClass("java.nio.file.Files");
            if (java_values($Files->exists($resourcePath))) {
                return $Files->newInputStream($resourcePath);
            }

            // 僅在圖像資源時使用備援。返回圖像串流
            // 對於缺失的字型或樣式表則無效。
            if ($this->fallbackImageData !== null && $this->isImageFile($resourcePath)) {
                return new Java("java.io.ByteArrayInputStream", $this->fallbackImageData);
            }
        } catch (JavaException $e) {
            return null;
        }

        return null;
    }

    private function isInsideAllowedRoot($resourcePath)
    {
        return java_values($resourcePath->normalize()->startsWith($this->allowedRoot));
    }

    private function isImageFile($path)
    {
        $fileName = strtolower(java_values($path->getFileName()->toString()));

        return str_ends_with($fileName, ".png") ||
            str_ends_with($fileName, ".jpg") ||
            str_ends_with($fileName, ".jpeg") ||
            str_ends_with($fileName, ".gif") ||
            str_ends_with($fileName, ".bmp");
    }
}
```

### **在 SVG 匯入期間解析鏈結資源**

假設 `assets/diagram.svg` 內含如下相對參照：

```xml
<image href="images/photo.png" x="20" y="20" width="320" height="180" />
```

以下 PHP 範例將 SVG 檔案 URI 作為基礎 URI 並提供自訂解析器。解析器會將相對圖片連結轉換為絕對 URI，並在 Aspose.Slides 處理 SVG 時回傳包含該資源的串流。

```php
$Paths = new JavaClass("java.nio.file.Paths");
$Files = new JavaClass("java.nio.file.Files");
$StandardCharsets = new JavaClass("java.nio.charset.StandardCharsets");

$svgFilePath = $Paths->get("assets", "diagram.svg")->toAbsolutePath()->normalize();
$assetDirectory = $svgFilePath->getParent();

$svgData = $Files->readAllBytes($svgFilePath);
$svgContent = new Java("java.lang.String", $svgData, $StandardCharsets->UTF_8);

// 基礎 URI 代表 SVG 文件的位置。
$baseUri = $svgFilePath->toUri()->toString();

$fallbackImageData = null;
$fallbackImagePath = $assetDirectory->resolve("fallback.png");
if (java_values($Files->exists($fallbackImagePath))) {
    $fallbackImageData = $Files->readAllBytes($fallbackImagePath);
}

$resolver = new LocalSvgResourceResolver(java_values($assetDirectory->toString()), $fallbackImageData);
$svgImage = new SvgImage($svgContent, $resolver, $baseUri);

// SVG 圖片物件揭露來源內容、二進位資料、基礎 URI 與解析器。
$importedContent = $svgImage->getSvgContent();
$importedData = $svgImage->getSvgData();
$importedBaseUri = $svgImage->getBaseUri();
$importedResolver = $svgImage->getExternalResourceResolver();

$presentation = new Presentation();
try {
    $image = $presentation->getImages()->addImage($svgImage);

    $presentation->getSlides()->get_Item(0)->getShapes()->addPictureFrame(
        ShapeType::Rectangle,
        20,
        20,
        $image->getWidth(),
        $image->getHeight(),
        $image
    );

    $presentation->save("svg-with-linked-resources.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

`SvgImage` 類別同時提供接受 SVG 位元組陣列或輸入串流、外部資源解析器與基礎 URI 的多載版本。

{{% alert title="Important" color="warning" %}}

資源解析器在 Aspose.Slides 處理與渲染 SVG 時使外部資源可用，並不會修改原始 SVG 標記，也不會自動將解析出的資源嵌入其中。

當 SVG 圖片被加入簡報的圖片集合時，PPTX 檔案可能同時包含原始 SVG 表示與點陣備援圖像。連結資源可能出現在產生的備援圖像中，而像 `images/photo.png` 之相對連結則保持在儲存的 SVG 中不變。若原始外部資源無法取得，渲染原生 SVG 表示的應用程式可能會省略該連結內容。

{{% /alert %}}

### **建立可攜帶的 SVG 圖片**

若要建立不依賴外部檔案的 SVG 圖片，請在建立 `SvgImage` 前先將 SVG 變為自包含。例如，將連結的圖片 URL 替換為包含圖片資料的 `data:` URI：

```xml
<image href="data:image/png;base64,..." x="20" y="20" width="320" height="180" />
```

在所有必要資源嵌入 SVG 內容之後，建立 `SvgImage`、將其加入簡報圖片集合，並如前例所示插入圖片框。

### **處理遺失或阻擋的資源**

當資源 URI 無效、被禁止或無法解析時，`resolveUri` 應回傳 `null`。當資源無法讀取時，`getEntity` 應回傳 `null`。Aspose.Slides 在可能的情況下會在缺少該資源的情況下繼續處理 SVG。

對於遺失的資源可回傳備援串流，但其內容必須與請求的資源類型相容。例如，只在遺失圖片時回傳圖片串流，而非字型或樣式表。

{{% alert title="Security" color="warning" %}}

切勿從不受信任的 SVG 檔案解析任意檔案路徑或不受限制的網路 URL。請限制允許的協定、目錄與主機。對於網路資源，亦需設定連線逾時、回應大小限制與內容驗證。

{{% /alert %}}

## **將 SVG 轉換為形狀集合**

Aspose.Slides 可以將 SVG 轉換為形狀集合，類似 PowerPoint 中的對應功能：

![PowerPoint Popup Menu](img_01_01.png)

此功能是透過 [ShapeCollection](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shapecollection/) 類別的 [addGroupShape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shapecollection/addgroupshape/) 方法的多載實作，該方法接受一個 [SvgImage](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/svgimage/) 物件作為第一個參數。

以下 PHP 範例示範如何使用此方法將 SVG 檔案轉換為形狀集合：

```php
// 來源 SVG 檔案名稱。
$svgFileName = "sample.svg";

// 輸出簡報檔案名稱。
$outPptxPath = "presentation.pptx";

// 建立新的簡報。
$presentation = new Presentation();
try {
    // 讀取 SVG 檔案內容。
    $Array = new JavaClass("java.lang.reflect.Array");
    $Byte = (new JavaClass("java.lang.Byte"))->TYPE;

    $dis = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", $svgFileName));
    try {
        $svgContent = $Array->newInstance($Byte, $dis->available());
        $dis->readFully($svgContent);
    } finally {
        if (!java_is_null($dis)) {
            $dis->close();
        }
    }

    // 建立 SvgImage 物件。
    $svgImage = new SvgImage($svgContent);

    // 取得投影片尺寸。
    $slideSize = $presentation->getSlideSize()->getSize();

    // 將 SVG 圖片轉換為形狀群組並縮放至投影片尺寸。
    $presentation->getSlides()->get_Item(0)->getShapes()->addGroupShape(
        $svgImage,
        0.0,
        0.0,
        $slideSize->getWidth(),
        $slideSize->getHeight()
    );

    // 以 PPTX 格式儲存簡報。
    $presentation->save($outPptxPath, SaveFormat::Pptx);
} catch (JavaException $e) {
} finally {
    $presentation->dispose();
}
```

## **將圖片作為 EMF 加入投影片**

Aspose.Slides for PHP via Java 允許您使用 Aspose.Cells 從 Excel 工作表產生 EMF 圖片，並將其加入簡報投影片。

以下 PHP 範例示範如何執行此操作：

```php
$book = new Workbook("chart.xlsx");
$sheet = $book->getWorksheets()->get(0);

$options = new ImageOrPrintOptions();
$options->setHorizontalResolution(200);
$options->setVerticalResolution(200);
$options->setImageType(ImageType::EMF);

// 將活頁簿儲存至串流。
$sr = new SheetRender($sheet, $options);
$pres = new Presentation();
try {
    $pres->getSlides()->removeAt(0);

    for ($j = 0; $j < java_values($sr->getPageCount()); $j++) {
        $emfSheetName = "test" . $sheet->getName() . " Page" . ($j + 1) . ".out.emf";
        $sr->toImage($j, $emfSheetName);

        // 新增檔案時保持原樣，使圖片保持向量 EMF 而非轉為點陣圖。
        $picture = null;
        $imageStream = new Java("java.io.FileInputStream", $emfSheetName);
        try {
            $picture = $pres->getImages()->addImage($imageStream);
        } finally {
            $imageStream->close();
        }

        $slide = $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->getByType(SlideLayoutType::Blank));
        $slide->getShapes()->addPictureFrame(
            ShapeType::Rectangle,
            0,
            0,
            $pres->getSlideSize()->getSize()->getWidth(),
            $pres->getSlideSize()->getSize()->getHeight(),
            $picture
        );
    }

    $pres->save("output.pptx", SaveFormat::Pptx);
} catch (JavaException $e) {
} finally {
    $pres->dispose();
}
```

## **替換影像集合中的圖片**

Aspose.Slides 允許您替換儲存在簡報影像集合中的圖片，包括投影片形狀使用的圖片。本節說明多種更新集合中圖片的方法。您可以使用原始位元組資料、[IImage](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/iimage/) 實例，或已存在於集合中的另一張圖片來替換圖片。

請依照以下步驟操作：

1. 使用 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/) 類別載入包含圖片的簡報檔案。
1. 從檔案載入新圖片為位元組陣列。
1. 使用位元組陣列將目標圖片替換為新圖片。
1. 在第二種方式中，將圖片載入為 [IImage](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/iimage/) 物件，並以該物件替換目標圖片。
1. 在第三種方式中，將目標圖片替換為已存在於簡報影像集合中的圖片。
1. 將修改後的簡報寫出為 PPTX 檔案。

```php
// 實例化代表簡報檔案的 Presentation 類別。
$presentation = new Presentation("sample.pptx");
try {
    // 第一種方式。
    $imagePath = (new Java("java.io.File", "image0.jpeg"))->toPath();
    $imageData = (new JavaClass("java.nio.file.Files"))->readAllBytes($imagePath);
    $oldImage = $presentation->getImages()->get_Item(0);
    $oldImage->replaceImage($imageData);

    // 第二種方式。
    $newImage = Images::fromFile("image1.png");
    try {
        $oldImage = $presentation->getImages()->get_Item(1);
        $oldImage->replaceImage($newImage);
    } finally {
        if (!java_is_null($newImage)) {
            $newImage->dispose();
        }
    }

    // 第三種方式。
    $oldImage = $presentation->getImages()->get_Item(2);
    $oldImage->replaceImage($presentation->getImages()->get_Item(3));

    // 將簡報儲存至檔案。
    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

{{% alert title="Info" color="info" %}}

使用 Aspose 的免費 [Text to GIF](https://products.aspose.app/slides/zh-hant/text-to-gif) 轉換器，您可以輕鬆為文字添加動畫並產生 GIF。

{{% /alert %}}

## **常見問題**

**插入後原始圖片的解析度是否保持不變？**

是的。來源像素會被保留，但最終外觀取決於 [picture](/slides/zh-hant/php-java/picture-frame/) 在投影片上的縮放方式以及儲存時的壓縮情形。

**一次取代多張投影片上相同的商標的最佳方法是什麼？**

將商標放在母片或版面配置上，並在簡報的影像集合中替換它——所有使用該資源的元素都會同步更新。

**插入的 SVG 可以轉換為可編輯的形狀嗎？**

可以。您可以將 SVG 轉換為形狀群組，之後各個部件即可使用標準形狀屬性進行編輯。

**如何一次為多張投影片設定相同的背景圖片？**

在母片或相關版面配置上 [將圖片指定為背景](/slides/zh-hant/php-java/presentation-background/)，所有使用該母片/版面的投影片都會繼承該背景。

**如何防止因大量圖片而使簡報檔案過大？**

重複使用同一圖片資源而非複製，選擇適當的解析度，儲存時進行壓縮，必要時將重複圖形保留在母片上。
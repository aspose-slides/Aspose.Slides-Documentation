---
title: 使用 PHP 管理投影片中的圖片框
linktitle: 圖片框
type: docs
weight: 10
url: /zh-hant/php-java/picture-frame/
keywords:
- 圖片框
- 新增圖片框
- 建立圖片框
- 嵌入影像
- 連結影像
- 提取影像
- 點陣圖影像
- SVG 影像
- 裁切影像
- 刪除裁切區域
- 壓縮影像
- StretchOffset
- 圖片框格式設定
- 相對比例
- 影像效果
- 長寬比
- PowerPoint
- OpenDocument
- 投影片
- PHP
- Aspose.Slides
description: "在投影片中使用 Aspose.Slides for PHP via Java 建立、格式設定、連結、裁切、提取與壓縮圖片框。"
---
## **概觀**

圖片框是一種投影片形狀，用於顯示影像。在 Aspose.Slides 中，影像資源與顯示它的形狀是分開的物件：一個[Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/) 透過其 [ImageCollection](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/imagecollection/) 持有嵌入的影像資源，而 [PictureFrame](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/pictureframe/) 控制影像的位置、大小、線條格式、旋轉、裁切、圖片效果，以及其他框層級設定。

此分離在同一張影像顯示多次時相當有用。將影像加入投影片一次，保留回傳的 [PPImage](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/ppimage/)，在建立圖片框時使用該影像資源。

圖片框可以包含 PNG 或 JPEG 等點陣圖，也可以包含 SVG 向量圖。它們也可以參照連結的影像，而不是將影像位元組儲存在投影片中。此選擇會影響可移植性、檔案大小、提取與匯出行為，因此在套用格式或最佳化之前，先決定影像的儲存方式是很重要的。

## **新增與格式化嵌入影像**

對於嵌入的影像，將影像資料加入投影片，並使用 [ShapeCollection::addPictureFrame](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shapecollection/addpictureframe/) 建立圖片框。影像會成為投影片封包的一部份，因而在移動至其他電腦時仍保持自包含。

以下範例加入 JPEG 影像，依影像的原始尺寸建立框，並套用線條格式與旋轉：

```php
use aspose\slides\FillType;
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceImage = Images::fromFile("photo.jpg");
    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        if (!java_is_null($sourceImage)) {
            $sourceImage->dispose();
        }
    }

    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 100, $image->getWidth(), $image->getHeight(), $image);
    $pictureFrame->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $pictureFrame->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $pictureFrame->getLineFormat()->setWidth(3);
    $pictureFrame->setRotation(15);

    $presentation->save("picture-frame.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

圖片框控制顯示的幾何形狀；變更框的大小不會改變嵌入影像資源中儲存的原始像素尺寸。此區別在之後裁切或壓縮影像時相當重要。

## **使用相對比例**

[PictureFrame](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/pictureframe/) 透過 [setRelativeScaleWidth](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/pictureframe/setrelativescalewidth/) 與 [setRelativeScaleHeight](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/pictureframe/setrelativescaleheight/) 釋出相對寬度與高度的縮放。`1.0` 代表原始圖片大小的 100%。相對比例在需要保留與來源影像尺寸關係的工作流程中很有用，而不必手動計算最終尺寸。

```php
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceImage = Images::fromFile("photo.jpg");
    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        if (!java_is_null($sourceImage)) {
            $sourceImage->dispose();
        }
    }

    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, $image);
    $pictureFrame->setRelativeScaleWidth(1.35);
    $pictureFrame->setRelativeScaleHeight(0.8);

    $presentation->save("relative-scale.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

相對比例會變更框的縮放設定；它不會重新採樣或壓縮嵌入的影像。

## **嵌入與連結影像**

嵌入的圖片將影像資料儲存在投影片內，因而是最安全的可移植性與可預測渲染的選擇。連結的圖片則透過 [Picture::setLinkPathLong](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/picture/setlinkpathlong/) 方法儲存外部位置，而不是以相同方式嵌入影像資料。

連結影像可減少 PPTX 中儲存的影像資料量，但會產生外部相依性。連結的檔案必須保持可供開啟或渲染投影片的應用程式存取。若路徑變更、檔案移動或資源不可用，連結圖片可能無法如預期顯示。對於必須以電子郵件傳送、封存或在隔離環境中渲染的投影片，嵌入影像通常較為可靠。

### **新增連結影像**

以下範例建立圖片框並指向本機影像檔。此範例僅處理影像連結；影片連結屬於另一套媒體工作流程，故此處未混入。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 50, 320, 180, null);
    $linkedImageFile = new Java("java.io.File", "linked-image.jpg");
    $pictureFrame->getPictureFormat()->getPicture()->setLinkPathLong($linkedImageFile->getAbsolutePath());

    $presentation->save("linked-image.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

在外部檔案管理是刻意的情況下使用連結。切勿僅將其作為壓縮的替代方案：一個帶有斷裂影像相依性的較小 PPTX 通常不如較大且自包含的投影片有用。

## **從圖片框提取影像**

在從現有投影片提取影像之前，先確認形狀實際上是 [PictureFrame](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/pictureframe/) 且包含嵌入影像。連結的圖片框可能不含可直接提取的影像位元組。

### **提取點陣圖影像**

現代影像 API 直接使用 [IImage](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/iimage/)。以下範例在投影片上找到第一個嵌入的點陣圖，並將其儲存為 PNG：

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapeCount = java_values($slide->getShapes()->size());

    for ($index = 0; $index < $shapeCount; $index++) {
        $shape = $slide->getShapes()->get_Item($index);
        if (!java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
            continue;
        }

        $embeddedImage = $shape->getPictureFormat()->getPicture()->getImage();
        if (java_is_null($embeddedImage) || !java_is_null($embeddedImage->getSvgImage())) {
            continue;
        }

        $rasterImage = $embeddedImage->getImage();
        try {
            $rasterImage->save("extracted-image.png", ImageFormat::Png);
        } finally {
            if (!java_is_null($rasterImage)) {
                $rasterImage->dispose();
            }
        }
        break;
    }
} finally {
    $presentation->dispose();
}
```

透過 [IImage::save](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/iimage/#save) 儲存會將提取的影像轉換為請求的輸出格式。若需要投影片中儲存的編碼位元組，而非已轉換的點陣檔，請使用影像資源的二進位資料。

### **提取 SVG 影像**

對於 SVG 圖片，[PPImage](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/ppimage/) 會公開一個 [SvgImage](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/svgimage/) 物件。這讓您可以直接取得 SVG 資料，而不必先將圖片光柵化。

```php
use aspose\slides\Presentation;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapeCount = java_values($slide->getShapes()->size());

    for ($index = 0; $index < $shapeCount; $index++) {
        $shape = $slide->getShapes()->get_Item($index);
        if (!java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
            continue;
        }

        $embeddedImage = $shape->getPictureFormat()->getPicture()->getImage();
        $svgImage = java_is_null($embeddedImage) ? null : $embeddedImage->getSvgImage();
        if ($svgImage === null || java_is_null($svgImage)) {
            continue;
        }

        $outputStream = new Java("java.io.FileOutputStream", "extracted-image.svg");
        try {
            $outputStream->write($svgImage->getSvgData());
        } finally {
            $outputStream->close();
        }
        break;
    }
} finally {
    $presentation->dispose();
}
```

將 SVG 內容保留為 SVG 可在投影片內保留向量來源。PNG 或 JPEG 等點陣匯出必須將向量內容渲染成像素。PDF 或 SVG 投影片匯出同樣是渲染操作，因此匯出的圖形不應被視為原始嵌入 SVG 的逐位元拷貝；若需要原始向量資源，請使用嵌入的 [SvgImage::getSvgData](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/svgimage/getsvgdata/) 資料。

## **裁切影像**

裁切會變更框內可見的影像部份。[PictureFillFormat](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/picturefillformat/) 上的裁切值以來源影像尺寸的百分比表示。裁切不會立即從嵌入的影像中刪除隱藏的像素，它只會改變可見區域。

以下範例安全地找到圖片框並套用裁切值：

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $pictureFrame = null;
    $shapeCount = java_values($slide->getShapes()->size());

    for ($index = 0; $index < $shapeCount; $index++) {
        $shape = $slide->getShapes()->get_Item($index);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
            $pictureFrame = $shape;
            break;
        }
    }

    if ($pictureFrame !== null) {
        $pictureFrame->getPictureFormat()->setCropLeft(23.6);
        $pictureFrame->getPictureFormat()->setCropRight(21.5);
        $pictureFrame->getPictureFormat()->setCropTop(3);
        $pictureFrame->getPictureFormat()->setCropBottom(31);
        $presentation->save("cropped-image.pptx", SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

因為隱藏的影像資料仍然存在，之後可在不失去原始像素的情況下調整裁切。如果檔案大小比可逆性更重要，則可如下一節所述實際移除裁切區域。

## **移除裁切影像資料**

[PictureFillFormat::deletePictureCroppedAreas](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) 會移除目前裁切矩形之外的影像資料，並回傳結果影像資源。這可以減少檔案大小，但屬於破壞性最佳化：投影片儲存後，已移除的像素將無法再進行取消裁切的操作。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("cropped-image.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $pictureFrame = null;
    $shapeCount = java_values($slide->getShapes()->size());

    for ($index = 0; $index < $shapeCount; $index++) {
        $shape = $slide->getShapes()->get_Item($index);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
            $pictureFrame = $shape;
            break;
        }
    }

    if ($pictureFrame !== null) {
        $croppedImage = $pictureFrame->getPictureFormat()->deletePictureCroppedAreas();
        if (!java_is_null($croppedImage)) {
            $presentation->save("cropped-data-removed.pptx", SaveFormat::Pptx);
        }
    }
} finally {
    $presentation->dispose();
}
```

此方法可能會在投影片中加入新的影像資源。若原始影像同時被其他圖片框使用，這些框仍需要其既有資源，因此刪除裁切區域不一定會減少總影像數量。使用此方法裁切 WMF 或 EMF 內容會將裁切結果光柵化為 PNG。

## **壓縮點陣圖影像**

[PictureFillFormat::compressImage](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/picturefillformat/#compressImage_boolean_int_) 會根據圖片顯示大小相對降低點陣圖解析度。它也可以在同一次操作中移除裁切區域。當影像被重新調整大小或裁切時，方法會回傳 `true`；若不需要變更則回傳 `false`。

當標準目標解析度足以時，可使用預先定義的 [PicturesCompression](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/picturescompression/) 值：

```php
use aspose\slides\PicturesCompression;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $pictureFrame = null;
    $shapeCount = java_values($slide->getShapes()->size());

    for ($index = 0; $index < $shapeCount; $index++) {
        $shape = $slide->getShapes()->get_Item($index);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
            $pictureFrame = $shape;
            break;
        }
    }

    if ($pictureFrame !== null) {
        $compressed = $pictureFrame->getPictureFormat()->compressImage(true, PicturesCompression::Dpi150);
        echo $compressed ? "The image was compressed." : "No compression was necessary.";
        $presentation->save("compressed-image.pptx", SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

若需要特定目標，可傳入自訂的正 DPI 數值代替預定義值。

壓縮僅適用於點陣圖。SVG 與圖形檔內容不會透過此點陣壓縮工作流程減少。也請記得，較低的解析度與已刪除的裁切區域無法從最佳化後的投影片中復原。請根據影像實際檢視或匯出的最大尺寸來決定目標解析度，而非全局套用最低 DPI。

## **檢查影像效果**

圖片效果儲存在框使用的圖片上。影像變換集合可能包含透明度的固定 Alpha 調變以及亮度的亮度與對比度。以下範例安全地讀取投影片上第一個圖片框的兩種效果：

```php
use aspose\slides\Presentation;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $pictureFrame = null;
    $shapeCount = java_values($slide->getShapes()->size());

    for ($index = 0; $index < $shapeCount; $index++) {
        $shape = $slide->getShapes()->get_Item($index);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
            $pictureFrame = $shape;
            break;
        }
    }

    if ($pictureFrame !== null) {
        $imageTransform = $pictureFrame->getPictureFormat()->getPicture()->getImageTransform();
        $effectCount = java_values($imageTransform->size());

        for ($index = 0; $index < $effectCount; $index++) {
            $effect = $imageTransform->get_Item($index);

            if (java_instanceof($effect, new JavaClass("com.aspose.slides.AlphaModulateFixed"))) {
                $transparency = 100 - java_values($effect->getAmount());
                echo "Transparency: " . $transparency . PHP_EOL;
            }

            if (java_instanceof($effect, new JavaClass("com.aspose.slides.Luminance"))) {
                $luminance = $effect->getEffective();
                echo "Brightness: " . java_values($luminance->getBrightness()) . PHP_EOL;
                echo "Contrast: " . java_values($luminance->getContrast()) . PHP_EOL;
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

這些效果會改變框內影像的渲染方式；它們不會改寫原始嵌入的影像位元組。

## **鎖定圖片框幾何形狀**

[PictureFrameLock](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/pictureframelock/) 設定控制哪些編輯操作會被禁用。例如，[setAspectRatioLocked](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/pictureframelock/setaspectratiolocked/) 在調整大小時保留形狀的比例。

```php
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceImage = Images::fromFile("photo.jpg");
    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        if (!java_is_null($sourceImage)) {
            $sourceImage->dispose();
        }
    }

    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 100, $image->getWidth(), $image->getHeight(), $image);
    $pictureFrame->getPictureFrameLock()->setAspectRatioLocked(true);

    $presentation->save("locked-picture-frame.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

此鎖套用於圖片框形狀本身。它不會強制將來源影像重新取樣或永久改為相同的長寬比。

## **調整 StretchOffset 值**

當圖片填充模式為 stretch 時，[PictureFillFormat](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/picturefillformat/) 上的 stretch‑offset 值定義相對於圖片框邊界框的填充矩形。正百分比會從邊緣向內縮進，負百分比則向外延伸。

這與裁切不同。裁切值決定來源影像的哪個部份可見；stretch offset 則變更可見圖片填充被拉伸的矩形。

```php
use aspose\slides\Images;
use aspose\slides\PictureFillMode;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceImage = Images::fromFile("photo.png");
    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        if (!java_is_null($sourceImage)) {
            $sourceImage->dispose();
        }
    }

    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 400, 300, $image);
    $pictureFrame->getPictureFormat()->setPictureFillMode(PictureFillMode::Stretch);
    $pictureFrame->getPictureFormat()->setStretchOffsetLeft(12);
    $pictureFrame->getPictureFormat()->setStretchOffsetRight(12);
    $pictureFrame->getPictureFormat()->setStretchOffsetTop(8);
    $pictureFrame->getPictureFormat()->setStretchOffsetBottom(8);

    $presentation->save("stretch-offsets.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

使用 stretch offset 來放置填充。若目標是隱藏來源影像的邊緣，請使用裁切屬性。

## **儲存、檔案大小與匯出考量**

當影像儲存與圖片框格式分別處理時，主要權衡更易管理：

- **嵌入影像** 使投影片自包含，對於共享與伺服器端渲染最為可靠，但大型點陣圖會增加 PPTX 大小與記憶體使用。
- **連結影像** 可以讓封包更小，但投影片依賴外部檔案在指定路徑或位置仍可存取。
- **裁切** 初始為非破壞性。隱藏的像素會保留，直到明確刪除裁切區域或在壓縮時移除。
- **壓縮** 能大幅減少過大點陣圖的檔案大小，但會犧牲來源解析度。應在確定投影片上最終尺寸後再套用。
- **SVG 影像** 若向量保留重要，應保持為 SVG。需要向量資源時直接提取嵌入的 SVG。點陣式投影片匯出始終會將渲染的投影片轉換為像素。
- **重複影像** 應盡可能重複使用已存在的 [PPImage](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/ppimage/) 資源，而非在工作流程中多次載入相同檔案。

對於大型投影片，影像最佳化通常在有選擇性執行時最有效：將標誌與圖表保留為向量內容，依實際顯示尺寸壓縮照片，只在不需要日後編輯時移除裁切像素，並除非部署設計已考慮相依性管理，否則避免使用外部連結。

## **常見問題集**

**圖片框與影像資源有何不同？**

[PPImage](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/ppimage/) 代表與投影片相關聯的影像資源。[PictureFrame](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/pictureframe/) 則是投影片上的形狀，用於顯示影像並儲存框層級的幾何與格式資訊，如尺寸、旋轉、裁切值、效果與鎖定。

**應該嵌入還是連結影像？**

當投影片必須可移植、封存或在沒有外部資源的情況下渲染時，請嵌入影像。只有在有意將影像檔案保留在 PPTX 之外且能可靠維護外部位置時才使用連結。

**裁切會減少 PPTX 檔案大小嗎？**

單純的裁切不會。正常的裁切設定會隱藏來源影像的部份，但仍保留底層像素。若想永久移除這些像素，可使用 [PictureFillFormat::deletePictureCroppedAreas](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) 或在壓縮時同時移除裁切區域。

**壓縮後可以恢復影像品質嗎？**

不能。壓縮會降低儲存的點陣解析度，且移除裁切區域會丟棄影像資料。若日後可能需要高解析度編輯，請在投影片外保留原始來源影像。

**SVG 影像應如何處理？**

在向量保真度重要時，應將 SVG 內容保留為 SVG。可直接提取嵌入的 [SvgImage](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/svgimage/)。將投影片渲染為 PNG 或 JPEG 等點陣格式時，SVG 會被光柵化為投影片影像。

**如何避免在讀取現有投影片時的不安全轉型？**

在使用圖片框特定成員之前，先檢查形狀類型。對 [PictureFrame](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/pictureframe/) 進行 `java_instanceof` 檢查，可避免無效的轉型，並讓程式碼能處理不含圖片框的投影片。
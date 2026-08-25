---
title: 使用 PHP 在簡報中管理圖片框架
linktitle: 圖片框架
type: docs
weight: 10
url: /zh-hant/php-java/picture-frame/
keywords:
- 圖片框架
- 新增圖片框架
- 建立圖片框架
- 嵌入式圖像
- 連結圖像
- 提取圖像
- 點陣圖像
- SVG 圖像
- 裁切圖像
- 刪除裁切區域
- 壓縮圖像
- StretchOffset
- 圖片框架格式設定
- 相對縮放
- 圖像效果
- 長寬比
- PowerPoint
- OpenDocument
- 簡報
- PHP
- Aspose.Slides
description: "使用透過 Java 的 Aspose.Slides for PHP，在簡報中建立、格式化、連結、裁切、提取與壓縮圖片框架。"
---
## **概觀**

圖片框架是一種在投影片上顯示圖像的形狀。在 Aspose.Slides 中，圖像資源與顯示它的形狀是分離的物件：一個[Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/)透過其[ImageCollection](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/imagecollection/)擁有內嵌圖像資源，而[PictureFrame](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/pictureframe/)控制圖像的位置、大小、線條格式、旋轉、裁切、圖片效果以及其他框架層級的設定。

當同一張圖像需要顯示多次時，這種分離非常有用。只需將圖像加入簡報一次，保留返回的[PPImage](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/ppimage/)，在建立圖片框架時重複使用該圖像資源。

圖片框架可以包含 PNG 或 JPEG 等點陣圖，也可以包含 SVG 向量圖。它們也可以引用連結圖像，而非將圖像位元組儲存在簡報中。此選擇會影響可移植性、檔案大小、提取與匯出行為，因此在套用格式或最佳化之前，先決定圖像的儲存方式是很有必要的。

## **新增與格式化嵌入式圖像**

對於嵌入式圖像，將圖像資料加入簡報，並使用[ShapeCollection::addPictureFrame](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shapecollection/addpictureframe/)建立圖片框架。圖像會成為簡報套件的一部份，因而在移動至其他電腦時簡報仍保持自包含。

以下範例加入 JPEG 圖像，依圖像的原始尺寸建立框架，並套用線條格式與旋轉：

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

圖片框架控制顯示的幾何形狀；變更框架大小不會改變嵌入圖像資源中儲存的原始像素尺寸。此區別在之後裁切或壓縮圖像時變得重要。

## **使用相對縮放**

[PictureFrame](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/pictureframe/) 透過[setRelativeScaleWidth](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/pictureframe/setrelativescalewidth/)與[setRelativeScaleHeight](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/pictureframe/setrelativescaleheight/)公開相對寬度與高度的縮放。`1.0` 的值對應於原始圖片大小的 100%。相對縮放在工作流程需要維持與來源圖像大小的關係，而非手動計算最終尺寸時相當有用。

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

相對縮放會變更框架的縮放設定；它不會重新取樣或壓縮嵌入圖像。

## **嵌入與連結圖像**

嵌入式圖片將圖像資料存放於簡報內，因此是可移植性與可預測渲染最安全的選擇。連結式圖片則是透過[Picture::setLinkPathLong](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/picture/setlinkpathlong/)方法保存外部位置，而非以相同方式嵌入圖像資料。

連結圖像可以減少 PPTX 中的圖像資料量，但會產生外部相依性。連結的檔案必須在開啟或渲染簡報的應用程式仍能存取。若路徑變更、檔案搬移或資源無法取得，連結圖片可能無法如預期顯示。對於必須以電子郵件傳送、保存或在隔離環境中渲染的簡報，嵌入式圖像通常較為可靠。

### **新增連結圖像**

以下範例建立一個圖片框架，並指向本機圖像檔案。此範例僅處理圖像連結；影片連結屬於另一個媒體工作流程，故此處未混入。

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

在外部檔案管理是刻意行為時使用連結。不要僅將它們視為壓縮的替代方案：一個包含破損圖像相依性的較小 PPTX 通常不如較大且自包含的簡報有用。

## **從圖片框架提取圖像**

在從現有簡報提取圖像之前，先確認形狀實際上是[PictureFrame](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/pictureframe/)，且它包含嵌入式圖像。連結式圖片框架可能不含可直接提取的圖像位元組。

### **提取點陣圖像**

新版圖像 API 直接使用[IImage](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/iimage/)。以下範例在投影片上找出第一個嵌入的點陣圖片，並將其另存為 PNG：

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

透過[IImage::save](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/iimage/#save)儲存會將提取的圖像轉換為請求的輸出格式。如果您需要儲存在簡報中的編碼位元組，而不是已轉換的點陣檔，請使用圖像資源的二進位資料。

### **提取 SVG 圖像**

對於 SVG 圖片，[PPImage](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/ppimage/) 會公開一個[SvgImage](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/svgimage/) 物件。這讓您可以直接取得 SVG 資料，而不必先將圖片光柵化。

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

將 SVG 內容保留為 SVG 可以在簡報內保留向量來源。PNG 或 JPEG 等光柵匯出必然將該向量內容渲染成像素。PDF 或 SVG 投影片匯出同樣是一個渲染動作，因此匯出的圖形不應被視為原始嵌入 SVG 的位元對位元拷貝；當需要原始向量資源時，請使用嵌入的[SvgImage::getSvgData](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/svgimage/getsvgdata/)資料。

## **裁切圖像**

裁切會改變框架內可見的圖像部分。[PictureFillFormat](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/picturefillformat/) 上的裁切值是相對於來源圖像尺寸的百分比。裁切最初不會刪除隱藏的像素，只是變更可見區域。

以下範例安全地找到圖片框架並套用裁切值：

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

因為隱藏的圖像資料仍然存在，之後仍可變更裁切而不失去原始像素。若檔案大小比可逆性更重要，可如下一節所述實際移除裁切區域。

## **移除裁切圖像資料**

[PictureFillFormat::deletePictureCroppedAreas](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) 會移除當前裁切矩形之外的圖像資料，並返回結果圖像資源。這可以減少檔案大小，但屬於破壞性最佳化：簡報儲存後，被移除的像素將無法再進行取消裁切的操作。

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

此方法可能會向簡報新增一個圖像資源。若原始圖像同時被其他圖片框架使用，這些框架仍需要其現有資源，所以刪除裁切區域不一定會減少總圖像數量。使用此方法裁切 WMF 或 EMF 內容會將裁切結果光柵化為 PNG。

## **壓縮點陣圖像**

[PictureFillFormat::compressImage](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/picturefillformat/#compressImage_boolean_int_) 會相對於圖片顯示尺寸降低點陣圖解析度。它也可以在同一次操作中移除裁切區域。當圖像被重新調整大小或裁切時，方法回傳 `true`；若無需變更則回傳 `false`。

當標準目標解析度足夠時，可使用預先定義的[PicturesCompression](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/picturescompression/) 值：

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

若需要特定目標，可傳入自訂的正 DPI 數值取代預設值。

壓縮僅適用於點陣圖像。SVG 與圖形檔內容不會受到此點陣壓縮工作流程的影響。也請記得，較低的解析度與已刪除的裁切區域無法從最佳化後的簡報中復原。應根據圖像實際檢視或匯出的最大尺寸來決定目標解析度，而非全域套用最低 DPI。

## **管理圖像變換效果**

欲取得涵蓋亮度、對比度、顏色變換、模糊、透明度效果、有序鏈、檢查、移除與往返驗證的完整工作流程，請參考[Image Transform Effects](/php-java/image-transform-effects/)。

## **鎖定圖片框架幾何形狀**

[PictureFrameLock](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/pictureframelock/) 設定控制哪些編輯操作會被禁用於圖片框架。例如，[setAspectRatioLocked](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/pictureframelock/setaspectratiolocked/) 會在調整大小時保持形狀比例。

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

此鎖定套用於圖片框架形狀本身，並不會強迫來源圖像重新取樣或永久改變為相同的長寬比。

## **調整 StretchOffset 值**

當圖片填充模式為 stretch 時，[PictureFillFormat](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/picturefillformat/) 上的 stretch‑offset 值會相對於圖片框架的邊界框定義填充矩形。正百分比會從邊緣向內縮進，負百分比則向外延伸。

這與裁切不同。裁切值決定來源圖像的可見部分；stretch offset 則改變可見圖片填充被拉伸到的矩形。

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

使用 stretch offset 來定位填充。若目的是隱藏來源圖像的邊緣，則使用裁切屬性。

## **儲存、檔案大小與匯出考量**

將圖像儲存與圖片框架格式化分開處理時，主要的取捨較易管理：

- **嵌入式圖像** 使簡報自包含，對於分享與伺服器端渲染最可靠，但大型點陣圖會增加 PPTX 大小與記憶體使用。
- **連結式圖像** 可以讓套件更小，但簡報依賴外部檔案必須仍能在儲存的路徑或位置存取。
- **裁切** 起初是非破壞性的。隱藏的像素會保留在嵌入圖像中，直到明確刪除裁切區域或在壓縮時移除。
- **壓縮** 能顯著減少過大點陣圖的檔案大小，但會犧牲來源解析度。應在確定投影片上最終顯示尺寸後再執行。
- **SVG 圖像** 若向量保真度重要，應保留為 SVG。當需要向量資源本身時，直接提取嵌入的 SVG。光柵化的投影片匯出始終會將渲染後的投影片轉為像素。
- **重複圖像** 應盡可能重複使用現有的[PPImage](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/ppimage/)資源，而非在簡報工作流程中重複載入相同檔案。

對於大型簡報，圖像最佳化通常在有選擇性地執行時效果最佳：將商標與圖表保留為向量內容，依實際顯示大小壓縮照片，僅在不需日後編輯時移除裁切像素，除非部署設計中已納入相依性管理，否則避免使用外部連結。

## **常見問題**

**圖片框架與圖像資源有何差異？**

[PPImage](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/ppimage/) 代表與簡報關聯的圖像資源。[PictureFrame](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/pictureframe/) 則是投影片上的形狀，用於顯示圖像並儲存框架層級的幾何與格式（如大小、旋轉、裁切值、效果與鎖定）。

**應該嵌入還是連結圖像？**

當簡報必須可移植、保存或在沒有外部資源的情況下渲染時，請嵌入圖像。僅在刻意將圖像檔案保留於 PPTX 之外且能可靠維護外部位置時才使用連結圖像。

**裁切會減少 PPTX 檔案大小嗎？**

本身不會。一般的裁切設定會隱藏來源圖像的部分，但仍保留底層像素。若想永久減少檔案大小，請使用[PictureFillFormat::deletePictureCroppedAreas](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) 或在壓縮時移除裁切區域。

**壓縮後能恢復圖像品質嗎？**

不能。壓縮會降低儲存的點陣解析度，且移除裁切區域會丟棄圖像資料。若日後可能需要高解析度編輯，請在簡報外保留原始來源圖像。

**SVG 圖像應如何處理？**

當向量 fidelity 重要時，應保留 SVG 為 SVG。可直接提取嵌入的[SvgImage](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/svgimage/)。將投影片渲染為 PNG 或 JPEG 等光柵格式時，SVG 會被光柵化為像素。

**如何避免在讀取現有投影片時發生不安全的型別轉換？**

在使用圖片框架特定成員之前，先檢查形狀類型。對[PictureFrame](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/pictureframe/) 進行`java_instanceof`檢查，可避免無效的型別轉換，並讓程式碼能處理不含圖片框架的投影片。
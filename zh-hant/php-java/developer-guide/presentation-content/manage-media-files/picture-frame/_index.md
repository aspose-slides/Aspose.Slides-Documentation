---
title: 使用 PHP 管理投影片中的圖片框架
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
- 擷取圖像
- 點陣圖像
- SVG 圖像
- 裁切圖像
- 刪除裁切區域
- 壓縮圖像
- 拉伸偏移
- 圖片框架格式設定
- 相對縮放
- 圖像效果
- 長寬比
- PowerPoint
- OpenDocument
- 投影片
- PHP
- Aspose.Slides
description: "在投影片中使用 Aspose.Slides for PHP via Java 建立、格式化、連結、裁切、擷取與壓縮圖片框架。"
---
## **概述**

圖片框架是一種顯示圖像的投影片形狀。在 Aspose.Slides 中，圖像資源與顯示它的形狀是分離的物件：一個 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/) 透過其 [ImageCollection](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/imagecollection/) 擁有嵌入式圖像資源，而一個 [PictureFrame](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/pictureframe/) 控制圖像的位置、大小、線條格式、旋轉、裁切、圖片效果以及其他框架層級設定。

當同一圖像需要顯示多次時，這種分離非常有用。只需將圖像加入投影片一次，保留回傳的 [PPImage](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/ppimage/)，在建立圖片框架時使用該圖像資源。

圖片框架可以包含 PNG 或 JPEG 等點陣圖，以及 SVG 向量圖。它們也可以引用連結的圖像，而不是將圖像位元組儲存在投影片中。此選擇會影響可攜性、檔案大小、擷取與匯出行為，因此在套用格式或優化之前，先決定圖像的儲存方式是很有幫助的。

## **新增與格式化嵌入式圖像**

對於嵌入式圖像，將圖像資料加入投影片，並使用 [ShapeCollection::addPictureFrame](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shapecollection/addpictureframe/) 建立圖片框架。圖像會成為投影片套件的一部分，所以投影片在移動到其他電腦時仍然是自包含的。

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

[PictureFrame](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/pictureframe/) 透過 [setRelativeScaleWidth](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/pictureframe/setrelativescalewidth/) 與 [setRelativeScaleHeight](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/pictureframe/setrelativescaleheight/) 暴露框架的相對寬度與高度縮放。`1.0` 代表原始圖片大小的 100%。相對縮放在工作流程需要保留與來源圖像尺寸的比例關係，而不是手動計算最終尺寸時非常有用。

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

## **嵌入式與連結圖像**

嵌入式圖片將圖像資料儲存在投影片內，因而是可攜性與可預測渲染的最安全選擇。連結圖片則透過 [Picture::setLinkPathLong](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/picture/setlinkpathlong/) 方法儲存外部位置，而不是以相同方式嵌入圖像資料。

連結圖像可以減少 PPTX 中的圖像資料量，但會引入外部相依性。連結檔案必須保持對開啟或渲染投影片的應用程式可存取。若路徑變更、檔案移動或資源無法取得，連結圖片可能無法如預期顯示。對於必須透過電子郵件、存檔或在隔離環境中渲染的投影片，嵌入圖像通常較為可靠。

### **新增連結圖像**

以下範例建立一個圖片框架，並指向本機圖像檔案。它僅處理圖像連結；影片連結屬於另一個媒體工作流程，故此範例未混入。

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

在外部檔案管理是刻意的情況下使用連結。不要僅將其當作壓縮的替代方案：一個帶有斷裂圖像相依性的 PPTX 通常不如較大且自包含的投影片實用。

## **從圖片框架擷取圖像**

在從現有投影片擷取圖像之前，先確認形狀實際上是 [PictureFrame](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/pictureframe/)，且它包含嵌入圖像。連結圖片框架可能不包含可直接擷取的圖像位元組。

### **擷取點陣圖像**

現代圖像 API 直接使用 [IImage](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/iimage/)。以下範例在投影片上找到第一個嵌入的點陣圖片，並以 PNG 格式儲存：

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

透過 [IImage::save](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/iimage/#save) 儲存會將擷取的圖像轉換為請求的輸出格式。如果需要投影片中儲存的編碼位元組，而非已轉換的點陣檔，請使用圖像資源的二進位資料。

### **擷取 SVG 圖像**

對於 SVG 圖片，[PPImage](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/ppimage/) 會暴露一個 [SvgImage](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/svgimage/) 物件。這讓您可以直接取得 SVG 資料，而不必先將圖片光柵化。

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

將 SVG 內容保留為 SVG 可在投影片中保留向量來源。PNG 或 JPEG 等點陣匯出必然將向量內容呈現為像素。PDF 或 SVG 投影片匯出亦屬於渲染操作，因此匯出的圖形不應被視為原始嵌入 SVG 的逐位元複製；當需要原始向量資源時，請使用嵌入的 [SvgImage::getSvgData](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/svgimage/getsvgdata/) 資料。

## **裁切圖像**

裁切會變更框架內可見的圖像部分。[PictureFillFormat](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/picturefillformat/) 上的裁切值以來源圖像尺寸的百分比表示。裁切不會立即從嵌入圖像中刪除隱藏的像素；它僅改變可見區域。

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

由於隱藏的圖像資料仍然存在，之後可以變更裁切而不會遺失原始像素。若檔案大小比可逆性更重要，請如下一節所述將裁切區域實際移除。

## **移除已裁切的圖像資料**

[PictureFillFormat::deletePictureCroppedAreas](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) 會移除目前裁切矩形之外的圖像資料，並返回新的圖像資源。此操作可減少檔案大小，但屬於破壞性優化：投影片儲存後，已移除的像素將無法再進行復原裁切。

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

此方法可能會向投影片加入新的圖像資源。如果原始圖像同時被其他圖片框架使用，這些框架仍需要其現有資源，因此刪除裁切區域不一定會減少圖像總數。使用此方法裁切 WMF 或 EMF 內容時，會將裁切結果光柵化為 PNG。

## **壓縮點陣圖像**

[PictureFillFormat::compressImage](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/picturefillformat/#compressImage_boolean_int_) 會相對於圖片顯示大小降低點陣圖解析度。它也可以在同一次操作中移除裁切區域。當圖像被重新調整大小或裁切時，方法傳回 `true`；若不需要變更則傳回 `false`。

當標準目標解析度足以時，使用預定義的 [PicturesCompression](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/picturescompression/) 值：

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

若需要特定目標，亦可傳入自訂的正 DPI 數值取代預定義值。

壓縮僅適用於點陣圖像。SVG 及圖形檔內容不會受到此點陣壓縮工作流程的影響。亦請記住，較低的解析度與已刪除的裁切區域無法從已優化的投影片中復原。請根據圖像實際被觀看或匯出的最大尺寸來選擇目標解析度，而非全域套用最低 DPI。

## **管理圖像變換效果**

欲取得涵蓋亮度、對比度、色彩變換、模糊、透明度效果、順序鏈、檢查、移除與來回驗證的完整工作流程，請參閱 [Image Transform Effects](/slides/zh-hant/php-java/image-transform-effects/)。

## **鎖定圖片框架幾何形狀**

[PictureFrameLock](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/pictureframelock/) 設定可控制哪些編輯操作對圖片框架被停用。例如，[setAspectRatioLocked](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/pictureframelock/setaspectratiolocked/) 會在調整大小時保留形狀比例。

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

此鎖定套用於圖片框架形狀本身，並不會迫使來源圖像重新取樣或永久改變為相同的寬高比。

## **調整 StretchOffset 值**

當圖片填充模式為拉伸時，[PictureFillFormat](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/picturefillformat/) 上的 stretch‑offset 值定義相對於圖片框架邊界盒的填充矩形。正百分比會從邊緣內縮，負百分比則會向外擴展。

這與裁切不同。裁切值決定來源圖像的哪一部分可見；stretch offset 則改變可見圖片填充被拉伸進入的矩形。

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

使用 stretch offset 進行填充定位。若目標是隱藏來源圖像的邊緣，請使用裁切屬性。

## **儲存、檔案大小與匯出考量**

將圖像儲存與圖片框架格式化分開處理時，主要的取捨較易掌控：

- **嵌入式圖像** 使投影片自包含，對於分享與伺服器端渲染最可靠，但大型點陣圖會增加 PPTX 大小與記憶體使用量。
- **連結圖像** 可以讓套件保持較小，但投影片依賴外部檔案在指定路徑或位置仍然可用。
- **裁切** 初始為非破壞性。隱藏的像素會保留在嵌入圖像中，直到明確刪除裁切區域或在壓縮時移除。
- **壓縮** 可大幅減少過大點陣圖的檔案大小，但會犧牲來源解析度。應在已知投影片上實際顯示尺寸後才套用。
- **SVG 圖像** 若向量保留很重要，應保持為 SVG。需要向量資源本身時，可直接擷取嵌入的 SVG。點陣投影片匯出永遠會將渲染的投影片轉換為像素。
- **重複使用的圖像** 應盡可能重用已有的 [PPImage](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/ppimage/) 資源，而不是在工作流程中重複載入相同檔案。

對於大型投影片，圖像最佳化通常在選擇性執行時最有效：將商標與圖表保留為向量內容，根據實際顯示尺寸壓縮照片，僅在不需要日後編輯時移除裁切像素，除非相依性管理是部署設計的一部份，否則避免使用外部連結。

## **常見問與答**

**圖片框架與圖像資源有何差別？**

[PPImage](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/ppimage/) 代表與投影片關聯的圖像資源。[PictureFrame](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/pictureframe/) 則是投影片上的一個形狀，用來顯示圖像並儲存框架層級的幾何與格式設定，例如大小、旋轉、裁切值、效果與鎖定。

**我應該嵌入還是連結圖像？**

當投影片必須具備可攜性、存檔或在沒有外部資源存取的情況下渲染時，請嵌入圖像。僅在有意將圖像檔案保留在 PPTX 之外且能可靠維護外部位置時，才使用連結圖像。

**裁切會減少 PPTX 檔案大小嗎？**

單純的裁切不會。一般裁切設定會隱藏來源圖像的部分，但仍保留底層像素。若要永久移除這些像素，可使用 [PictureFillFormat::deletePictureCroppedAreas](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) 或在壓縮時同時移除裁切區域。

**壓縮後我可以恢復圖像品質嗎？**

不能。壓縮會降低儲存的點陣解析度，且移除裁切區域會捨棄圖像資料。若日後可能需要高解析度編輯，請在投影片外保留原始來源圖像。

**SVG 圖像應如何處理？**

當向量保真度重要時，請保留 SVG 內容為 SVG。可直接擷取嵌入的 [SvgImage](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/svgimage/)。將投影片渲染為 PNG 或 JPEG 等點陣格式時，會將 SVG 轉換為像素。

**如何避免在讀取現有投影片時的不安全轉型？**

在使用圖片框架專屬成員之前，先檢查形狀類型。對 [PictureFrame](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/pictureframe/) 進行 `java_instanceof` 檢查，可避免無效的轉型，並讓程式碼能處理不含圖片框架的投影片。
---
title: 管理 PHP 中的簡報圖形
linktitle: 圖形操作
type: docs
weight: 40
url: /zh-hant/php-java/shape-manipulations/
keywords:
- PowerPoint 圖形
- 簡報圖形
- 投影片上的圖形
- 尋找圖形
- 複製圖形
- 移除圖形
- 隱藏圖形
- 更改圖形順序
- 取得 interop 圖形 ID
- 圖形替代文字
- 圖形版面格式
- 圖形為 SVG
- 圖形轉 SVG
- 對齊圖形
- 翻轉圖形
- PowerPoint
- 簡報
- PHP
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for PHP via Java 識別、複製、移除、隱藏、重新排序、匯出、對齊及翻轉簡報圖形。"
---
## **概觀**

Aspose.Slides for PHP via Java 會將投影片上的圖形表示為有序的[ShapeCollection](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shapecollection/)。此集合同時是您尋找與修改圖形的地方，也是它們堆疊順序的來源：索引 `0` 為最背面的圖形，而最後一個索引則為最前面的圖形。

本篇文章遵循此模型。首先說明如何可靠地識別圖形，接著示範如何複製、移除、隱藏與重新排序圖形。最後的章節涵蓋版面層級的格式設定、SVG 匯出、對齊與翻轉設定。每個範例皆獨立，您可以只使用工作流程中需要的操作。

## **識別與尋找圖形**

在處理已知檔案時，集合索引很方便，但它們不是穩定的識別子。新增、移除或重新排序圖形都會改變其索引。請依據簡報的編寫與維護方式選擇識別子：

- [Name](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shape/getname/) 對於由開發人員控制的範本很有用，且在 PowerPoint 的「選取窗格」中易於檢視。名稱可以編輯，但不保證唯一，若程式碼依賴名稱須訂定命名慣例。
- [AlternativeText](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shape/getalternativetext/) 在已提供可存取性說明或作者自訂標籤的情況下很實用。它會顯示給使用者，可能會本地化或為可存取性重新編寫，亦不保證唯一。不要將有意義的可存取性文字靜默地作為資料庫鍵使用。
- [OfficeInteropShapeId](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shape/getofficeinteropshapeid/) 是唯讀的識別子，在投影片內唯一，對應 PowerPoint interop 所使用的圖形 ID。當與 PowerPoint 整合或需要在圖形生命週期內保持不含歧義的參照時使用。被複製或重新建立的圖形是不同的圖形，會取得自己的 ID。

相關的[Shape::getUniqueId](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shape/getuniqueid/) 方法會回傳具有簡報範圍的識別子，但該識別子僅供外掛使用，可能被重新指派，不應視為永久的外部鍵。若長期身份識別很重要，請在應用程式資料中保留對映，並驗證預期的圖形仍然存在。

以下範例以精確比較方式依名稱搜尋，並回報投影片範圍的 interop ID。當範本未包含預期圖形時，程式會回報該結果，而不會繼續使用錯誤的物件。

```php
use aspose\slides\Presentation;

$presentation = new Presentation("input.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $targetShape = null;

    $shapes = $slide->getShapes();
    $shapeCount = java_values($shapes->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        $shapeName = java_values($shape->getName());
        if ($shapeName === "RevenueChart") {
            $targetShape = $shape;
            break;
        }
    }

    if ($targetShape === null) {
        echo "The shape 'RevenueChart' was not found on slide 1." . PHP_EOL;
    } else {
        $shapeName = java_values($targetShape->getName());
        $interopId = java_values($targetShape->getOfficeInteropShapeId());
        echo "Found " . $shapeName . "; interop ID: " . $interopId . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

當操作限定於特定圖形類型時，請在使用類型特定成員前檢查執行時類別。此範例僅在命名的物件為[AutoShape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/autoshape/) 時，才更新文字與替代文字。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("input.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $candidate = null;

    $shapes = $slide->getShapes();
    $shapeCount = java_values($shapes->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        $shapeName = java_values($shape->getName());
        if ($shapeName === "StatusLabel") {
            $candidate = $shape;
            break;
        }
    }

    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
    if ($candidate !== null && java_instanceof($candidate, $autoShapeClass)) {
        $candidate->getTextFrame()->setText("Approved");
        $candidate->setAlternativeText("Approval status: approved");
        $presentation->save("identified-shape.pptx", SaveFormat::Pptx);
    } else {
        echo "'StatusLabel' is missing or is not an AutoShape." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

## **修改圖形集合**

新增、複製、移除與重新排序方法會立即作用於集合。如果操作改變了圖形的數量或順序，請勿繼續依賴先前捕獲的索引。

### **複製圖形**

[ShapeCollection::addClone](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shapecollection/addclone/) 會建立獨立的副本並附加至目標集合的末端。[ShapeCollection::insertClone](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shapecollection/insertclone/) 也會建立副本，但會放置在指定的 Z 順序索引。接受座標的重載會在不變更大小的情況下移動副本；接受寬度與高度的重載則可以同時調整大小。

範例建立目的投影片，將帶標籤的矩形複製到前方，並在背後插入第二個副本。對任一副本的變更不會影響來源圖形。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideLayoutType;

$presentation = new Presentation();
try {
    $sourceSlide = $presentation->getSlides()->get_Item(0);
    $sourceShape = $sourceSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 40, 180, 60);
    $sourceShape->setName("SourceLabel");
    $sourceShape->getTextFrame()->setText("Source");

    $blankLayout = $presentation->getMasters()->get_Item(0)->getLayoutSlides()->getByType(SlideLayoutType::Blank);
    $destinationSlide = $presentation->getSlides()->addEmptySlide($blankLayout);

    $frontCloneShape = $destinationSlide->getShapes()->addClone($sourceShape, 80, 80);
    $frontCloneShape->setName("FrontClone");
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
    if (java_instanceof($frontCloneShape, $autoShapeClass)) {
        $frontCloneShape->getTextFrame()->setText("Front clone");
    } else {
        echo "The front clone is not an AutoShape; its text was not changed." . PHP_EOL;
    }

    $backCloneShape = $destinationSlide->getShapes()->insertClone(0, $sourceShape, 80, 180);
    $backCloneShape->setName("BackClone");
    if (java_instanceof($backCloneShape, $autoShapeClass)) {
        $backCloneShape->getTextFrame()->setText("Back clone");
    } else {
        echo "The back clone is not an AutoShape; its text was not changed." . PHP_EOL;
    }

    $presentation->save("cloned-shapes.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

複製會把圖形的內容與格式一起複製，包括名稱與替代文字。若這些值必須唯一，請為副本指派新的邏輯識別子。複雜圖形使用的資源由簡報處理，但副本仍是集合中的新項目，擁有新的圖形身份。

### **移除圖形**

[ShapeCollection::remove](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shapecollection/remove/) 會從其集合中刪除特定圖形物件。於索引式迭代中同時移除多個符合項目時，請從集合尾端向前遍歷，以確保每個剩餘索引仍然有效。

此範例移除所有具有指定名稱的圖形。它在當前索引讀取圖形，而非固定的集合項目，且未不必要地轉型圖形。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $keepShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 40, 140, 60);
    $keepShape->setName("Keep");

    $firstTemporaryShape = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 220, 40, 80, 80);
    $firstTemporaryShape->setName("Temporary");

    $secondTemporaryShape = $slide->getShapes()->addAutoShape(ShapeType::Triangle, 340, 40, 100, 80);
    $secondTemporaryShape->setName("Temporary");

    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = $shapeCount - 1; $shapeIndex >= 0; $shapeIndex--) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        $shapeName = java_values($shape->getName());
        if ($shapeName === "Temporary") {
            $slide->getShapes()->remove($shape);
        }
    }

    $presentation->save("removed-shapes.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

移除後，圖形總數與後續圖形的索引會改變。對未受影響的圖形使用參照比使用已儲存的索引更可靠。同時請考慮連接線、動畫與其他可能參照被移除物件的簡報功能；移除可見圖形可能會改變超出投影片外觀的內容。

### **隱藏圖形**

將[Shape::setHidden](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shape/sethidden/) 設為 `true` 會保留圖形於集合中，但阻止其在一般投影片放映時顯示。其索引、格式與內容仍可供程式碼存取，因此隱藏適用於可能日後復原的可選元素。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $visibleShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 40, 160, 60);
    $visibleShape->setName("VisibleLabel");

    $optionalShape = $slide->getShapes()->addAutoShape(ShapeType::Moon, 240, 40, 100, 100);
    $optionalShape->setName("OptionalDecoration");

    $shapes = $slide->getShapes();
    $shapeCount = java_values($shapes->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        $shapeName = java_values($shape->getName());
        if ($shapeName === "OptionalDecoration") {
            $shape->setHidden(true);
        }
    }

    $presentation->save("hidden-shape.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

隱藏並非刪除或安全機制。使用者或程式碼仍可發現並取消隱藏，且它仍是簡報檔案的一部份。

### **變更 Z 順序**

重疊的圖形會依集合順序繪製。[ShapeCollection::reorder](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shapecollection/reorder/) 會將現有圖形移至目標索引，且不會複製。索引 `0` 為背面；`size() - 1` 為前面。

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $blueRectangle = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 220, 120);
    $blueRectangle->setName("BlueRectangle");
    $blueRectangle->getFillFormat()->setFillType(FillType::Solid);
    $blueRectangle->getFillFormat()->getSolidFillColor()->setColor(new Java("java.awt.Color", 0, 0, 255));

    $orangeEllipse = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 180, 140, 220, 120);
    $orangeEllipse->setName("OrangeEllipse");
    $orangeEllipse->getFillFormat()->setFillType(FillType::Solid);
    $orangeEllipse->getFillFormat()->getSolidFillColor()->setColor(new Java("java.awt.Color", 255, 165, 0));

    $frontIndex = java_values($slide->getShapes()->size()) - 1;
    $slide->getShapes()->reorder($frontIndex, $blueRectangle);
    $presentation->save("reordered-shapes.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

矩形最先建立，最初位於橢圓的背後。將其移至最終索引即會變成前面。請在加入或複製所有相關圖形後再最後確定 Z 順序，因為這些操作會在集合中追加或插入新項目，可能改變預期的堆疊。

## **檢查版面投影片上的圖形**

普通投影片、版面投影片與母片都有各自的圖形集合。版面集合中的圖形並非與普通投影片上類似位置圖形相同的物件。當需要了解或變更版面提供的格式時，請檢查版面圖形。

以下範例讀取每個版面圖形的[FillFormat](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shape/getfillformat/)與[LineFormat](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shape/getlineformat/)，且不假設每個圖形都是 `AutoShape`。

```php
use aspose\slides\Presentation;

$presentation = new Presentation("input.pptx");
try {
    $layoutSlides = $presentation->getLayoutSlides();
    $layoutSlideCount = java_values($layoutSlides->size());
    for ($layoutIndex = 0; $layoutIndex < $layoutSlideCount; $layoutIndex++) {
        $layoutSlide = $layoutSlides->get_Item($layoutIndex);
        $layoutShapes = $layoutSlide->getShapes();
        $layoutShapeCount = java_values($layoutShapes->size());
        for ($shapeIndex = 0; $shapeIndex < $layoutShapeCount; $shapeIndex++) {
            $shape = $layoutShapes->get_Item($shapeIndex);
            $fillType = java_values($shape->getFillFormat()->getFillType());
            $lineWidth = java_values($shape->getLineFormat()->getWidth());
            $layoutName = java_values($layoutSlide->getName());
            $shapeName = java_values($shape->getName());
            echo $layoutName . " / " . $shapeName . ": fill=" . $fillType . ", line width=" . $lineWidth . PHP_EOL;
        }
    }
} finally {
    $presentation->dispose();
}
```

編輯版面可能會影響使用該版面的多張投影片。變更版面圖形前，請先確定普通投影片是繼承該物件還是具有本地覆寫，並測試所有使用該版面的投影片。

## **將圖形匯出為 SVG**

[Shape::writeAsSvg](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shape/writeassvg/) 會將單一圖形的渲染內容寫入串流。結果僅包含該圖形，並不包括整張投影片的背景或鄰近圖形。

```php
use aspose\slides\Presentation;

$presentation = new Presentation("input.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapeCount = java_values($slide->getShapes()->size());

    if ($shapeCount === 0) {
        echo "Slide 1 does not contain a shape to export." . PHP_EOL;
    } else {
        $shape = $slide->getShapes()->get_Item(0);
        $svgStream = null;
        try {
            $svgStream = new Java("java.io.FileOutputStream", "shape.svg");
            $shape->writeAsSvg($svgStream);
        } catch (JavaException $exception) {
            echo "The SVG file could not be written: " . $exception->getMessage() . PHP_EOL;
        } finally {
            if ($svgStream !== null && !java_is_null($svgStream)) {
                $svgStream->close();
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

渲染時請保持簡報開啟狀態。輸出取決於圖形的格式以及字型、圖像等資源。若需要整個組合，請匯出投影片而非單一圖形。呼叫端擁有串流的所有權，必須負責關閉它。

## **對齊圖形**

[SlideUtil::alignShapes](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/slideutil/alignshapes/) 的重載可對全部圖形或選取的集合索引進行對齊。[ShapesAlignmentType](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shapesalignmenttype/) 指定邊緣、中心線或分布模式。將 `alignToSlide` 設為 `true` 以使用投影片邊緣；設為 `false` 則相對於彼此對齊選取的圖形。

此範例將三個圖形對齊至投影片的上緣。返回的圖形參考會在對齊前立即轉換為其目前的索引。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\ShapesAlignmentType;
use aspose\slides\SlideUtil;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $firstShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 60, 80, 120, 50);
    $secondShape = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 240, 160, 120, 50);
    $thirdShape = $slide->getShapes()->addAutoShape(ShapeType::Triangle, 420, 240, 120, 50);
    $firstShape->setName("FirstAlignedShape");
    $secondShape->setName("SecondAlignedShape");
    $thirdShape->setName("ThirdAlignedShape");

    $shapeIndexes = [
        java_values($slide->getShapes()->indexOf($firstShape)),
        java_values($slide->getShapes()->indexOf($secondShape)),
        java_values($slide->getShapes()->indexOf($thirdShape))
    ];

    SlideUtil::alignShapes(ShapesAlignmentType::AlignTop, true, $slide, $shapeIndexes);
    $presentation->save("aligned-shapes.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

對齊會改變位置，而非 Z 順序。相對對齊通常至少需要兩個圖形，而水平或垂直分布則需要足夠的圖形以定義間距。若在呼叫方法前修改了集合，請重新計算索引。

## **翻轉圖形**

[ShapeFrame](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shapeframe/) 類別儲存位置、大小、水平與垂直翻轉設定，以及旋轉。其 `getFlipH` 與 `getFlipV` 值使用[NullableBool](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/nullablebool/)：`True` 代表啟用翻轉，`False` 代表停用，`NotDefined` 代表保留未指定/預設狀態。

以下輸入簡報包含一個未翻轉的圖形。

![翻轉前的圖形](shape_to_be_flipped.png)

範例保留其他所有框架值，僅取代兩個翻轉設定。這很重要，因為指派新的[Frame](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shape/setframe/) 會取代完整的框架。

```php
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeFrame;

$presentation = new Presentation("sample.pptx");
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $frame = $shape->getFrame();

    $horizontalFlip = java_values($frame->getFlipH());
    $verticalFlip = java_values($frame->getFlipV());
    echo "Horizontal flip before change: " . $horizontalFlip . PHP_EOL;
    echo "Vertical flip before change: " . $verticalFlip . PHP_EOL;

    $shape->setFrame(new ShapeFrame($frame->getX(), $frame->getY(), $frame->getWidth(), $frame->getHeight(), NullableBool::True, NullableBool::True, $frame->getRotation()));

    $presentation->save("flipped-shape.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

儲存後的圖形會水平與垂直鏡像，同時保持位置、大小與旋轉。

![翻轉後的圖形](flipped_shape.png)

## **常見問答**

**我可以使用集合索引作為圖形識別子嗎？**

只能在集合在使用索引前不會改變的短暫處理情境下使用。對於已編寫的範本，建議使用經驗證的 `Name` 或 `AlternativeText` 慣例；對於投影片範圍的 interop 工作則使用 `OfficeInteropShapeId`。

**隱藏圖形會將它從 Z 順序中移除嗎？**

不會。隱藏的圖形仍保留在集合中的相同索引。它仍可被尋找、重新排序、編輯或再次設為可見。

**為什麼複製的圖形會出現在另一個圖形前面？**

`addClone` 會將副本附加至集合的末端，亦即 Z 順序的最前面。若要指定初始索引，可使用 `insertClone`，或在全部圖形加入後使用 `reorder`。
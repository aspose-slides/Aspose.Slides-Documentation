---
title: 在 PHP 中管理簡報圖形
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
- 變更圖形順序
- 取得 interop 圖形 ID
- 圖形替代文字
- 圖形調整點
- 預設圖形調整
- 圖形幾何
- 圖形版面格式
- 圖形為 SVG
- 圖形轉 SVG
- 對齊圖形
- 翻轉圖形
- PowerPoint
- 簡報
- PHP
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for PHP via Java 識別、調整、複製、移除、隱藏、重新排序、匯出、對齊與翻轉簡報圖形。"
---
## **概觀**

Aspose.Slides for PHP via Java 以有序的 [ShapeCollection](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shapecollection/) 來表示投影片上的圖形。此集合同時是您尋找與修改圖形的地方，也是它們堆疊順序的來源：索引 `0` 為最背面的圖形，而最後一個索引為最前面的圖形。

本篇文章遵循此模型。它首先說明如何可靠地識別圖形並修改預設的圖形調整點，接著示範如何複製、移除、隱藏與重新排序圖形。最後的章節涵蓋版面層級的格式設定、SVG 匯出、對齊與翻轉設定。每個範例皆獨立，您可以僅使用工作流程所需的操作。

## **識別與尋找圖形**

在處理已知檔案時，集合索引很方便，但它們不是固定的識別碼。新增、移除或重新排序圖形都會改變其索引。請依照簡報的製作與維護方式選擇識別方式：

- [Name](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shape/getname/) 適用於開發者控制的範本，且在 PowerPoint 的「選取窗格」中易於檢視。名稱可編輯且不保證唯一，若程式碼依賴名稱，請建立命名慣例。
- [AlternativeText](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shape/getalternativetext/) 適合已有存取性說明或作者提供的標籤已識別圖形的情況。它會顯示給使用者，可本地化或為可存取性重新撰寫，但同樣不保證唯一。切勿在未經檢查下將有意義的可存取文字作為資料庫鍵使用。
- [OfficeInteropShapeId](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shape/getofficeinteropshapeid/) 為唯讀識別碼，在投影片內唯一，對應 PowerPoint interop 使用的圖形 ID。於與 PowerPoint 整合或需在圖形生命週期內取得明確參照時使用。被複製或重新建立的圖形會是不同的圖形，並取得自己的 ID。

相關的 [Shape::getUniqueId](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shape/getuniqueid/) 方法會回傳投影片範圍的識別碼，但此識別碼僅供外掛使用，可能會被重新指派，不應視為永久的外部鍵。若長期身分辨識至關重要，請在應用程式資料中保留對應關係，並驗證預期圖形仍然存在。

以下範例使用精確比較以名稱搜尋，並回報投影片範圍的 interop ID。當範本未包含預期的圖形時，程式會回報該結果而不會繼續使用錯誤的物件。

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

當操作特定於圖形類型時，請先檢查執行時類別再使用類型專屬的成員。此範例僅在命名物件為 [AutoShape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/autoshape/) 時更新文字與 alternative text。

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

## **識別與修改預設圖形調整**

預設幾何圖形可能會暴露調整點，用以控制角落大小、箭頭比例或弧度等特徵。請透過唯讀的 [GeometryShape::getAdjustments](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/geometryshape/#getAdjustments) 集合取得它們。集合本身由圖形提供，但每個 [AdjustValue](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/adjustvalue/) 內含可變更的值。

不要只依賴固定的集合索引。遍歷調整項目並檢查唯讀的 [AdjustValue::getType](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/adjustvalue/#getType) 方法，其回傳的 [ShapeAdjustmentType](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shapeadjustmenttype/) 值說明了調整控制的內容。唯讀的 [AdjustValue::getName](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/adjustvalue/getname/) 方法提供額外的識別資訊，特別在同一預設含有多個相同語意類型的調整時非常有用。

使用與調整意義相符的值方法：

| 調整類型 | 目的 | 要變更的值 |
|---|---|---|
| `CornerSize` | 圓角的大小 | [setRawValue](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/adjustvalue/setrawvalue/) |
| `ArrowTailThickness` | 箭尾的粗細 | `setRawValue` |
| `ArrowheadLength` | 箭頭的長度 | `setRawValue` |
| `ArrowheadWidth` | 箭頭的寬度 | `setRawValue` |
| `StartAngle` | 扇形或弧線的起始角度 | [setAngleValue](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/adjustvalue/setanglevalue/) |
| `EndAngle` | 扇形或弧線的結束角度 | `setAngleValue` |

`getType` 與 `getName` 皆回傳唯讀資訊。`getRawValue` 與 `setRawValue` 使用預設幾何單位的整數，而 `getAngleValue` 與 `setAngleValue` 使用以度為單位的角度。調整的數量、順序、意義與有效範圍取決於預設的 [GeometryShape::getShapeType](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/geometryshape/#getShapeType)。對某一預設有效的值，對另一預設可能無效或產生不同效果。

當 `getType` 回傳 `ShapeAdjustmentType::Custom` 時，API 無法辨識標準語意。檢查 `getName`、預設類型與現有值，除非已知預期的意義與範圍，否則保持調整不變。即使是已識別的類型，也請先確認同一類型是否出現多次再選擇值。[Connector](/slides/zh-hant/php-java/connector/) 文章說明了連接線彎曲調整的情況。

以下完整範例建立三種預設圖形的預設與修改版本。它遍歷每個調整，回報名稱與類型，透過 `setRawValue` 變更與大小相關的值，透過 `setAngleValue` 變更角度，並儲存結果。左側欄保留預設幾何，右側欄顯示調整後的圓角矩形、四向箭頭與扇形。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeAdjustmentType;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // 為預設和調整後的圖形欄位添加標題。
    $defaultColumnLabel = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 20, 250, 30);
    $defaultColumnLabel->getTextFrame()->setText("Default preset geometry");
    $adjustedColumnLabel = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 390, 20, 250, 30);
    $adjustedColumnLabel->getTextFrame()->setText("Modified adjustment values");

    $slide->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 80, 70, 160, 70);
    $modifiedRoundedRectangle = $slide->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 430, 70, 160, 70);
    $modifiedRoundedRectangle->setName("ModifiedRoundedRectangle");

    $slide->getShapes()->addAutoShape(ShapeType::QuadArrow, 80, 180, 160, 110);
    $modifiedArrow = $slide->getShapes()->addAutoShape(ShapeType::QuadArrow, 430, 180, 160, 110);
    $modifiedArrow->setName("ModifiedQuadArrow");

    $slide->getShapes()->addAutoShape(ShapeType::Pie, 95, 330, 130, 130);
    $modifiedPie = $slide->getShapes()->addAutoShape(ShapeType::Pie, 445, 330, 130, 130);
    $modifiedPie->setName("ModifiedPie");

    $shapesToAdjust = [
        $modifiedRoundedRectangle,
        $modifiedArrow,
        $modifiedPie
    ];

    foreach ($shapesToAdjust as $shape) {
        $adjustmentCount = java_values($shape->getAdjustments()->size());
        for ($adjustmentIndex = 0; $adjustmentIndex < $adjustmentCount; $adjustmentIndex++) {
            $adjustment = $shape->getAdjustments()->get_Item($adjustmentIndex);
            $shapeName = java_values($shape->getName());
            $adjustmentName = java_values($adjustment->getName());
            $adjustmentType = java_values($adjustment->getType());
            echo $shapeName . " / " . $adjustmentName . ": " . $adjustmentType . PHP_EOL;

            switch ($adjustmentType) {
                case ShapeAdjustmentType::CornerSize:
                    $adjustment->setRawValue(5000);
                    break;
                case ShapeAdjustmentType::ArrowTailThickness:
                    $adjustment->setRawValue(25000);
                    break;
                case ShapeAdjustmentType::ArrowheadLength:
                    $adjustment->setRawValue(30000);
                    break;
                case ShapeAdjustmentType::ArrowheadWidth:
                    $adjustment->setRawValue(40000);
                    break;
                case ShapeAdjustmentType::StartAngle:
                    $adjustment->setAngleValue(30);
                    break;
                case ShapeAdjustmentType::EndAngle:
                    $adjustment->setAngleValue(300);
                    break;
                case ShapeAdjustmentType::Custom:
                    echo "Custom adjustment '" . $adjustmentName . "' was not changed." . PHP_EOL;
                    break;
            }
        }
    }

    $presentation->save("preset-shape-adjustments.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

在變更值之前先檢查語意類型，使程式碼明確表達意圖，並避免假設不同預設圖形的相同集合索引具有相同意義。

## **修改圖形集合**

新增、複製、移除與重新排序方法會立即作用於集合。如果操作改變了圖形的數量或順序，請勿在該操作之後仍依賴先前取得的索引。

### **複製圖形**

[ShapeCollection::addClone](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shapecollection/addclone/) 會建立獨立的副本並附加至目標集合的末端。 [ShapeCollection::insertClone](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shapecollection/insertclone/) 也會建立副本，但會放置在指定的 Z 順序索引。接受座標的重載會在不變更大小的情況下移動副本；接受寬度與高度的重載則可同時調整大小。

以下範例建立一個目標投影片，將標記的矩形複製至最前面，並在最後插入第二個副本於最背面。對任一副本的變更不會影響來源圖形。

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

複製會將圖形的內容與格式（包括名稱與 alternative text）一起複製。若這些值必須唯一，請為副本指派新的邏輯識別碼。複雜圖形所使用的資源由簡報管理，但副本仍是新的集合項目，擁有新的圖形身分。

### **移除圖形**

[ShapeCollection::remove](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shapecollection/remove/) 會從其集合中刪除特定的圖形物件。若在索引迭代過程中移除多個符合條件的圖形，請從結尾開始遍歷，以確保剩餘索引仍然有效。

此範例移除所有具有指定名稱的圖形。它在當前索引讀取圖形，而非固定的集合項目，且不會不必要地轉型圖形。

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

移除後，圖形計數與後續圖形的索引會改變。對未受影響的圖形的參照較保存的索引更可靠。同時請考慮連接線、動畫與其他可能參照被移除物件的簡報功能；移除可見圖形可能會改變投影片外觀之外的更多內容。

### **隱藏圖形**

將 [Shape::setHidden](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shape/sethidden/) 設為 `true` 會保留圖形於集合中，但阻止它在一般投影片放映中顯示。其索引、格式與內容仍可供程式碼存取，故隱藏適用於可能稍後恢復的可選元素。

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

隱藏不是刪除或安全保護。使用者或程式碼仍可發現並取消隱藏該物件，且它仍是簡報檔案的一部份。

### **變更 Z 順序**

重疊的圖形會依集合順序繪製。[ShapeCollection::reorder](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shapecollection/reorder/) 會將現有圖形移動至目標索引，而不會複製它。索引 `0` 為最背面；`size() - 1` 為最前面。

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

矩形最先建立，最初位於橢圓之後。將它移至最後的索引即會置於前方。於加入或複製所有相關圖形後再最終確定 Z 順序，因為這些操作會在集合中新增或插入項目，可能改變原本的堆疊順序。

## **檢視版面投影片上的圖形**

普通投影片、版面投影片與母版投影片各自擁有獨立的圖形集合。版面集合中的圖形並非與普通投影片上同樣位置的圖形同一物件。當您需要了解或變更版面提供的格式時，請檢視版面圖形。

以下範例讀取每個版面圖形的 [FillFormat](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shape/getfillformat/) 與 [LineFormat](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shape/getlineformat/)，且不假設每個圖形皆為 `AutoShape`。

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

編輯版面可能會影響使用該版面的多張投影片。變更版面圖形前，請先確定普通投影片是繼承該物件還是有本地覆寫，並測試所有使用該版面的投影片。

## **將圖形匯出為 SVG**

[Shape::writeAsSvg](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shape/writeassvg/) 會將單一圖形的渲染內容寫入串流。結果僅包含該圖形，而非整個投影片背景或鄰近圖形。

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

在渲染期間請保持簡報開啟。輸出受圖形格式以及字型、影像等資源影響。若需要整個組合，請匯出投影片而非單一圖形。呼叫端負責擁有串流並須自行關閉。

## **對齊圖形**

[SlideUtil::alignShapes](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/slideutil/alignshapes/) 的多載可對齊全部圖形或選取的集合索引。 [ShapesAlignmentType](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shapesalignmenttype/) 指定邊緣、中心線或分佈模式。將 `alignToSlide` 設為 `true` 會使用投影片邊緣；設為 `false` 則相對於彼此對齊已選取的圖形。

此範例將三個圖形對齊到投影片的上緣。返回的圖形參照會在對齊前立即轉換為目前的索引。

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

對齊會變更位置，而非 Z 順序。相對對齊通常至少需要兩個圖形，而水平或垂直分佈則需足夠的圖形以定義間距。若在呼叫方法前修改了集合，請重新計算索引。

## **翻轉圖形**

[ShapeFrame](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shapeframe/) 類別儲存位置、大小、水平與垂直翻轉設定，以及旋轉角度。其 `getFlipH` 與 `getFlipV` 之值使用 [NullableBool](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/nullablebool/) ：`True` 代表啟用翻轉，`False` 代表停用，`NotDefined` 則保留未指定/預設狀態。

以下輸入簡報中僅有一個未翻轉的圖形。

![The shape before flipping](shape_to_be_flipped.png)

此範例保留其他所有框架值，僅取代兩個翻轉設定。這點很重要，因為指派新 [Frame](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shape/setframe/) 會取代整個框架。

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

儲存的圖形會在保持位置、大小與旋轉的同時，水平與垂直鏡像翻轉。

![The shape after flipping](flipped_shape.png)

## **常見問答**

**我可以使用集合索引作為圖形識別碼嗎？**

僅在集合不會在使用索引前變更的短暫處理情境下可行。對於已製作的範本，建議使用已驗證的 `Name` 或 `AlternativeText` 慣例；若為投影片範圍的 interop 工作，則使用 `OfficeInteropShapeId`。

**隱藏圖形會將它從 Z 順序中移除嗎？**

不會。隱藏的圖形仍保留在集合中且索引不變。它仍可被找到、重新排序、編輯或再次顯示。

**為什麼複製的圖形會出現在另一個圖形的前面？**

`addClone` 會將副本附加至集合的末端，也就是 Z 順序的最前面。若想指定初始索引，可使用 `insertClone`，或在全部圖形加入後使用 `reorder`。

**我可以使用固定索引來識別預設圖形調整嗎？**

僅在已驗證確切的預設與集合布局後才可。建議遍歷 `GeometryShape::getAdjustments` 並檢查 `AdjustValue::getType`；當同一語意類型出現多次時，使用 `AdjustValue::getName` 作為額外資訊。
---
title: 管理 PHP 中的簡報占位符
linktitle: 管理占位符
type: docs
weight: 10
url: /zh-hant/php-java/manage-placeholder/
keywords:
- 占位符
- 文字占位符
- 圖片占位符
- 圖表占位符
- 內容占位符
- 提示文字
- PowerPoint
- 簡報
- PHP
- Aspose.Slides
description: "學習如何檢查與編輯文字、圖片、圖表與內容占位符，並透過 Aspose.Slides for PHP via Java 了解占位符繼承。"
---
## **概述**

占位符是一種形狀，用於在簡報範本中為特定類型的內容保留位置。常見的例子包括標題、內文、圖片、圖表以及通用內容占位符。與普通形狀不同，占位符可以從版面投影片或母片繼承其位置、大小、格式以及其他設定。

Aspose.Slides 透過 [Shape::getPlaceholder](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getplaceholder/) 方法公開占位符資訊。該方法會回傳一個 [Placeholder](https://reference.aspose.com/slides/php-java/aspose.slides/placeholder/) 物件，若為普通形狀則回傳 `null`。使用 [Placeholder::getType](https://reference.aspose.com/slides/php-java/aspose.slides/placeholder/gettype/) 可判斷占位符預期容納的內容類型。

在了解占位符類型後，形狀類別仍然很重要：

- 空的文字、圖片、圖表或內容占位符通常以 [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) 代表。
- 已填入圖片的占位符可以以 [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/) 代表。
- 已填入圖表的占位符可以以 [Chart](https://reference.aspose.com/slides/php-java/aspose.slides/chart/) 代表。
- 內容占位符可以包含多種內容。請同時檢查 [Placeholder::getType](https://reference.aspose.com/slides/php-java/aspose.slides/placeholder/gettype/) 以及執行時的形狀類別，而不要假設每個占位符都是 [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/)。

{{% alert color="warning" title="Warning" %}}
[Placeholder::getType](https://reference.aspose.com/slides/php-java/aspose.slides/placeholder/gettype/) 只描述占位符的角色；它無法保證形狀的執行時類別。存取文字、圖片、圖表、表格或多媒體相關成員之前，務必先進行類型檢查。
{{% /alert %}}

## **了解占位符繼承**

占位符形成層級結構：

1. 母片投影片定義可重複使用的樣式，並在某些情況下提供母片層級的占位符。
2. 版面投影片定義一或多張普通投影片使用的排列，且可以從母片繼承。
3. 普通投影片包含該投影片的占位符，並可從其版面繼承。

呼叫 [Shape::getBasePlaceholder](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getbaseplaceholder/) 可向上移動一層層級。投影片占位符通常回傳其版面占位符；版面占位符則可以回傳其母片占位符。若形狀沒有基礎占位符，該方法會回傳 `null`。

以下範例列出第一張投影片上的占位符，並報告其基礎占位符：

```php
use aspose\slides\Presentation;

$presentation = new Presentation("template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $shapeCountValue = $shapes->size();
    $shapeCount = java_values($shapeCountValue);

    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        $placeholder = $shape->getPlaceholder();
        if (java_is_null($placeholder)) {
            continue;
        }

        $placeholderTypeValue = $placeholder->getType();
        $placeholderType = java_values($placeholderTypeValue);
        $shapeClass = $shape->getClass();
        $shapeClassNameValue = $shapeClass->getSimpleName();
        $shapeClassName = java_values($shapeClassNameValue);
        echo "Slide placeholder: " . $placeholderType . "; shape class: " . $shapeClassName . PHP_EOL;

        $layoutPlaceholder = $shape->getBasePlaceholder();
        if (!java_is_null($layoutPlaceholder)) {
            $layoutPlaceholderInfo = $layoutPlaceholder->getPlaceholder();
            if (!java_is_null($layoutPlaceholderInfo)) {
                $layoutPlaceholderTypeValue = $layoutPlaceholderInfo->getType();
                $layoutPlaceholderType = java_values($layoutPlaceholderTypeValue);
                echo "  Layout placeholder: " . $layoutPlaceholderType . PHP_EOL;
            }

            $masterPlaceholder = $layoutPlaceholder->getBasePlaceholder();
            if (!java_is_null($masterPlaceholder)) {
                $masterPlaceholderInfo = $masterPlaceholder->getPlaceholder();
                if (!java_is_null($masterPlaceholderInfo)) {
                    $masterPlaceholderTypeValue = $masterPlaceholderInfo->getType();
                    $masterPlaceholderType = java_values($masterPlaceholderTypeValue);
                    echo "  Master placeholder: " . $masterPlaceholderType . PHP_EOL;
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

編輯普通投影片上的占位符會為該投影片建立或變更本機覆寫。編輯相關的版面或母片則會影響仍繼承該設定的所有投影片。普通形狀本身沒有基礎占位符，也不會僅因佔用相同座標而開始繼承。

## **移除占位符狀態**

在調整範本時，使用 [Shape::removePlaceholder](https://reference.aspose.com/slides/php-java/aspose.slides/shape/removeplaceholder/) 可將現有物件保留為普通形狀。其 [getPlaceholder](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getplaceholder/) 方法會回傳 `null`，但形狀仍保留在投影片的集合中。相較之下，使用 [ShapeCollection::remove](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/remove/) 會將形狀從該集合中刪除。

以下範例需要 `template.pptx`，該檔案至少包含一張投影片，且第一張投影片上有非空的文字占位符。請使用從其版面或母片繼承格式的占位符，以觀察移除關係的效果。範例會檢查相同的形狀仍然存在，然後再次對現在的普通形狀呼叫該方法，最後儲存結果。

{{% alert color="warning" title="Warning" %}}
移除占位符狀態不會自動保留繼承的外觀設定。下列範例刻意保持這些設定不變，因而輸出可能看起來不同。完全繼承位置與大小的形狀在呼叫後可能會變成座標與尺寸皆為零，導致即使仍在集合中也看不見。
{{% /alert %}}

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapeCount = java_values($slide->getShapes()->size());
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
    $found = false;

    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (!java_instanceof($shape, $autoShapeClass)) {
            continue;
        }

        $placeholder = $shape->getPlaceholder();
        $textFrame = $shape->getTextFrame();
        if (java_is_null($placeholder) || java_is_null($textFrame)) {
            continue;
        }

        $textValue = $textFrame->getText();
        if (java_is_null($textValue)) {
            continue;
        }
        $text = java_values($textValue);
        if ($text === "") {
            continue;
        }

        $shape->removePlaceholder();

        $placeholder = $shape->getPlaceholder();
        $retainedShape = $slide->getShapes()->get_Item($shapeIndex);
        $sameShapeValue = $shape->equals($retainedShape);
        $sameShape = java_values($sameShapeValue);
        $remainingCountValue = $slide->getShapes()->size();
        $remainingCount = java_values($remainingCountValue);
        echo "Placeholder removed: " . (java_is_null($placeholder) ? "true" : "false") . PHP_EOL;
        echo "Same shape retained: " . ($sameShape ? "true" : "false") . PHP_EOL;
        echo "Shape count unchanged: " . ($remainingCount === $shapeCount ? "true" : "false") . PHP_EOL;

        // 對普通形狀呼叫此方法不會產生任何影響。
        $shape->removePlaceholder();
        $found = true;
        break;
    }

    if ($found) {
        $presentation->save("placeholder-status-removed.pptx", SaveFormat::Pptx);
    } else {
        echo "No nonempty text placeholder was found on the first slide." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

對於符合條件的占位符，三項檢查皆會印出 `true`。文字仍會保留，但繼承的位置、大小、旋轉、字型、段落對齊、文字框邊距、垂直錨點、填色與線條設定等，可能在移除占位符關係後發生變化。例如，繼承的標題格式可能會退回普通文字格式。更多版面資訊請參閱 [Slide Layout](/slides/zh-hant/php-java/slide-layout/)。

為了保留預期的外觀，請在呼叫前取得解析後的位置、大小與旋轉，並將必要的有效格式值複製到個別變數。可透過 [PortionFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/portionformat/geteffective/)、[ParagraphFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/geteffective/)、[TextFrameFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/geteffective/)、[FillFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/geteffective/)、[LineFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/geteffective/) 取得這些值。不要僅依賴有效格式物件，因為在移除關係後其文字格式值可能會改變。之後請明確將取得的值套用回普通形狀，包括字型系列、大小、樣式、顏色、段落設定、文字框設定、填色與線條等。

繼承的形狀幾何也可能需要透過 [GeometryShape::setShapeType](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setShapeType) 明確指定。對於矩形文字占位符而言，這意味著要指定 [ShapeType::Rectangle](https://reference.aspose.com/slides/php-java/aspose.slides/shapetype/)；僅恢復填色與線條可能無法恢復可見的矩形。含有額外效果或更複雜格式的範本亦需同樣處理這些設定。

## **變更占位符中的文字**

標題、居中標題、副標題、內文與文字占位符通常支援文字。使用前請先檢查是否為 [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/)，再呼叫其 [getTextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/gettextframe/) 方法。

以下範例會更新第一張投影片上的第一個標題占位符，並儲存結果：

```php
use aspose\slides\PlaceholderType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $shapeCountValue = $shapes->size();
    $shapeCount = java_values($shapeCountValue);
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
    $titleShape = null;

    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        if (!java_instanceof($shape, $autoShapeClass)) {
            continue;
        }

        $placeholder = $shape->getPlaceholder();
        if (java_is_null($placeholder)) {
            continue;
        }

        $placeholderTypeValue = $placeholder->getType();
        $placeholderType = java_values($placeholderTypeValue);
        if ($placeholderType === PlaceholderType::Title || $placeholderType === PlaceholderType::CenteredTitle) {
            $titleShape = $shape;
            break;
        }
    }

    if ($titleShape === null) {
        throw new RuntimeException("The first slide does not contain a title placeholder.");
    }

    $titleShape->getTextFrame()->setText("Quarterly Business Review");
    $presentation->save("title-placeholder-updated.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

此模式避免將圖片、圖表、表格或多媒體占位符當作 [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) 物件處理，也會以目的而非脆弱的形狀索引來識別占位符。

## **在版面設定提示文字**

提示文字是空白占位符中顯示的設計時指示，例如 *Click to add title*。請在版面占位符上設定自訂提示文字，而不是透過普通投影片的形狀集合來存取。可先透過 [Slide::getLayoutSlide](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getLayoutSlide) 取得版面，並遍歷 [BaseSlide::getShapes](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getShapes) 回傳的集合。

以下範例會變更第一張投影片使用的版面上的標題與副標題提示文字：

```php
use aspose\slides\PlaceholderType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $layoutSlide = $slide->getLayoutSlide();
    $shapes = $layoutSlide->getShapes();
    $shapeCountValue = $shapes->size();
    $shapeCount = java_values($shapeCountValue);
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");

    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        if (!java_instanceof($shape, $autoShapeClass)) {
            continue;
        }

        $placeholder = $shape->getPlaceholder();
        if (java_is_null($placeholder)) {
            continue;
        }

        $placeholderTypeValue = $placeholder->getType();
        $placeholderType = java_values($placeholderTypeValue);
        if ($placeholderType === PlaceholderType::Title || $placeholderType === PlaceholderType::CenteredTitle) {
            $shape->getTextFrame()->setText("Enter a concise slide title");
        } elseif ($placeholderType === PlaceholderType::Subtitle) {
            $shape->getTextFrame()->setText("Enter a subtitle or reporting period");
        }
    }

    $presentation->save("custom-placeholder-prompts.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

提示文字並非普通投影片內容。它僅供 PowerPoint 等編輯應用程式在空白占位符時顯示說明。一旦使用者或程式提供實際內容，提示文字就不再顯示。變更提示文字也不會取代使用該版面的投影片上已存在的文字。

## **更新圖片占位符**

有兩種情況需要處理：

- 若圖片占位符已被填入且以 [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/) 表示，請透過 [PictureFillFormat::getPicture](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/getpicture/) 與 [Picture::setImage](https://reference.aspose.com/slides/php-java/aspose.slides/picture/#setImage) 取代圖片。
- 若仍是空的占位符，請使用 [ShapeCollection::addPictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addpictureframe/) 在占位符座標處加入圖片框，並移除空的占位符。

以下範例同時支援兩種情況，並儲存簡報：

```php
use aspose\slides\PlaceholderType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation("picture-template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $shapeCountValue = $shapes->size();
    $shapeCount = java_values($shapeCountValue);
    $pictureFrameClass = new JavaClass("com.aspose.slides.PictureFrame");
    $picturePlaceholder = null;

    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        $placeholder = $shape->getPlaceholder();
        if (java_is_null($placeholder)) {
            continue;
        }

        $placeholderTypeValue = $placeholder->getType();
        $placeholderType = java_values($placeholderTypeValue);
        if ($placeholderType === PlaceholderType::Picture) {
            $picturePlaceholder = $shape;
            break;
        }
    }

    if ($picturePlaceholder === null) {
        throw new RuntimeException("The first slide does not contain a picture placeholder.");
    }

    $imageData = file_get_contents("replacement.png");
    $image = $presentation->getImages()->addImage($imageData);

    if (java_instanceof($picturePlaceholder, $pictureFrameClass)) {
        $picture = $picturePlaceholder->getPictureFormat()->getPicture();
        $picture->setImage($image);
    } else {
        $x = $picturePlaceholder->getX();
        $y = $picturePlaceholder->getY();
        $width = $picturePlaceholder->getWidth();
        $height = $picturePlaceholder->getHeight();
        $shapes->addPictureFrame(ShapeType::Rectangle, $x, $y, $width, $height, $image);
        $shapes->remove($picturePlaceholder);
    }

    $presentation->save("picture-placeholder-updated.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

對於空白占位符所建立的替代物是一個本機圖片框，而非新占位符，因為 [Shape::getPlaceholder](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getplaceholder/) 並未提供設定子。它保留了預留位置，但不再繼承占位符特有的行為。若保留占位符關係很重要，請先在 PowerPoint 中建立並填入占位符，然後再使用 Aspose.Slides 更新產生的 [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/)。

關於圖片透明度、裁切及其他圖片專屬效果，請參閱 [Manage Picture Frames](/slides/zh-hant/php-java/picture-frame/)。這些操作屬於圖片框或圖片填充，與占位符中繼資料無關。

## **操作圖表與內容占位符**

已填入的圖表占位符可以以 [Chart](https://reference.aspose.com/slides/php-java/aspose.slides/chart/) 代表。以下範例同時依據占位符類型與執行時類別找出此圖表，變更其標題，並儲存檔案：

```php
use aspose\slides\PlaceholderType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("chart-template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $shapeCountValue = $shapes->size();
    $shapeCount = java_values($shapeCountValue);
    $chartClass = new JavaClass("com.aspose.slides.Chart");
    $placeholderChart = null;

    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        if (!java_instanceof($shape, $chartClass)) {
            continue;
        }

        $placeholder = $shape->getPlaceholder();
        if (java_is_null($placeholder)) {
            continue;
        }

        $placeholderTypeValue = $placeholder->getType();
        $placeholderType = java_values($placeholderTypeValue);
        if ($placeholderType === PlaceholderType::Chart) {
            $placeholderChart = $shape;
            break;
        }
    }

    if ($placeholderChart === null) {
        throw new RuntimeException("The first slide does not contain a populated chart placeholder.");
    }

    $placeholderChart->setTitle(true);
    $placeholderChart->getChartTitle()->addTextFrameForOverriding("Quarterly Revenue");
    $presentation->save("chart-placeholder-updated.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

一般內容占位符通常具有 [PlaceholderType::Object](https://reference.aspose.com/slides/php-java/aspose.slides/placeholdertype/)。在 PowerPoint 中，它充當多種內容類型的啟動器，包括圖表、表格、圖示、圖片與多媒體。填入後，請檢查實際的形狀類別以了解其包含的內容。特定版面也可能暴露 [PlaceholderType::Chart](https://reference.aspose.com/slides/php-java/aspose.slides/placeholdertype/)、[PlaceholderType::Table](https://reference.aspose.com/slides/php-java/aspose.slides/placeholdertype/)、[PlaceholderType::Picture](https://reference.aspose.com/slides/php-java/aspose.slides/placeholdertype/)、[PlaceholderType::Media](https://reference.aspose.com/slides/php-java/aspose.slides/placeholdertype/)、[PlaceholderType::Diagram](https://reference.aspose.com/slides/php-java/aspose.slides/placeholdertype/)。

Aspose.Slides 不會僅透過變更 [Placeholder::getType](https://reference.aspose.com/slides/php-java/aspose.slides/placeholder/gettype/) 就將空的 [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) 占位符轉換為 [Chart](https://reference.aspose.com/slides/php-java/aspose.slides/chart/)；類型無法透過類別變更。若要以程式方式填充空的圖表或內容區域，請在占位符座標處加入所需物件，然後移除空的占位符。以下範例示範如何為圖表執行此操作：

```php
use aspose\slides\ChartType;
use aspose\slides\PlaceholderType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("content-template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $shapeCountValue = $shapes->size();
    $shapeCount = java_values($shapeCountValue);
    $targetPlaceholder = null;

    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        $placeholder = $shape->getPlaceholder();
        if (java_is_null($placeholder)) {
            continue;
        }

        $placeholderTypeValue = $placeholder->getType();
        $placeholderType = java_values($placeholderTypeValue);
        if ($placeholderType === PlaceholderType::Chart || $placeholderType === PlaceholderType::Object) {
            $targetPlaceholder = $shape;
            break;
        }
    }

    if ($targetPlaceholder === null) {
        throw new RuntimeException("The first slide does not contain a chart or content placeholder.");
    }

    $x = $targetPlaceholder->getX();
    $y = $targetPlaceholder->getY();
    $width = $targetPlaceholder->getWidth();
    $height = $targetPlaceholder->getHeight();
    $chart = $shapes->addChart(ChartType::ClusteredColumn, $x, $y, $width, $height);
    $chart->setTitle(true);
    $chart->getChartTitle()->addTextFrameForOverriding("Quarterly Revenue");
    $shapes->remove($targetPlaceholder);
    $presentation->save("content-placeholder-replaced-with-chart.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

新增的圖表是一個普通的本機圖表。它佔用占位符的區域，但不會從版面占位符繼承。當需要替換其類別、系列或活頁簿資料時，請使用專門的 [chart management articles](/slides/zh-hant/php-java/powerpoint-charts/)。

## **完整範例：更新文字或影像內容**

以下端對端範例會開啟範本、在第一張投影片上搜尋標題或圖片占位符、檢查占位符與形狀類型、更新相應的內容，最後儲存輸出。此範例刻意避免假設形狀索引或將每個占位符視為相同類別。

```php
use aspose\slides\PlaceholderType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation("template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $shapeCountValue = $shapes->size();
    $shapeCount = java_values($shapeCountValue);
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
    $pictureFrameClass = new JavaClass("com.aspose.slides.PictureFrame");
    $updated = false;

    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        $placeholder = $shape->getPlaceholder();
        if (java_is_null($placeholder)) {
            continue;
        }

        $placeholderTypeValue = $placeholder->getType();
        $placeholderType = java_values($placeholderTypeValue);

        if (($placeholderType === PlaceholderType::Title || $placeholderType === PlaceholderType::CenteredTitle) && java_instanceof($shape, $autoShapeClass)) {
            $shape->getTextFrame()->setText("Quarterly Business Review");
            $updated = true;
            break;
        }

        if ($placeholderType === PlaceholderType::Picture) {
            $imageData = file_get_contents("replacement.png");
            $image = $presentation->getImages()->addImage($imageData);

            if (java_instanceof($shape, $pictureFrameClass)) {
                $picture = $shape->getPictureFormat()->getPicture();
                $picture->setImage($image);
            } else {
                $x = $shape->getX();
                $y = $shape->getY();
                $width = $shape->getWidth();
                $height = $shape->getHeight();
                $shapes->addPictureFrame(ShapeType::Rectangle, $x, $y, $width, $height, $image);
                $shapes->remove($shape);
            }

            $updated = true;
            break;
        }
    }

    if (!$updated) {
        throw new RuntimeException("No supported title or picture placeholder was found on the first slide.");
    }

    $presentation->save("placeholder-content-updated.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **常見問題**

**什麼是基礎占位符？**

基礎占位符是指在版面或母片上對應的形狀，其他占位符皆由其繼承。請使用 [Shape::getBasePlaceholder](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getbaseplaceholder/) 取得它。普通本機形狀會回傳 `null`，因為它不屬於占位符層級。

**我可以透過編輯版面占位符來變更所有投影片的標題嗎？**

您可以透過版面變更繼承的格式或提示文字，但現有的標題內容儲存在普通投影片上。若要在整個簡報中取代實際的標題文字，必須遍歷投影片並更新每個標題占位符。

**如何管理日期、投影片編號、頁首與頁尾占位符？**

請在相應的投影片、版面、母片、備註或講義範圍使用頁首與頁尾管理員。完整範例請參考 [Manage Presentation Header and Footer](/slides/zh-hant/php-java/presentation-header-and-footer/)。
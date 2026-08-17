---
title: 管理 PHP 中的簡報佔位符
linktitle: 管理佔位符
type: docs
weight: 10
url: /zh-hant/php-java/manage-placeholder/
keywords:
- 佔位符
- 文字佔位符
- 圖片佔位符
- 圖表佔位符
- 內容佔位符
- 提示文字
- PowerPoint
- 簡報
- PHP
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for PHP via Java 檢查與編輯文字、圖片、圖表與內容佔位符，並理解佔位符的繼承機制。"
---
## **概覽**

佔位符是一種形狀，用於在簡報範本中保留特定類型內容的位置。常見的例子包括標題、內文、圖片、圖表以及通用內容佔位符。與普通形狀不同，佔位符可以從佈局投影片或母片繼承其位置、大小、格式及其他設定。

Aspose.Slides 透過 [Shape::getPlaceholder](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shape/getplaceholder/) 方法公開佔位符資訊。此方法會回傳一個 [Placeholder](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/placeholder/) 物件，對於普通形狀則回傳 `null`。使用 [Placeholder::getType](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/placeholder/gettype/) 來判斷佔位符預期容納的內容。

在取得佔位符類型後，形狀類別仍然很重要：

- 空的文字、圖片、圖表或內容佔位符通常以 [AutoShape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/autoshape/) 代表。
- 已填入圖片的佔位符可以以 [PictureFrame](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/pictureframe/) 表示。
- 已填入圖表的佔位符可以以 [Chart](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chart/) 表示。
- 內容佔位符可以包含多種內容。請同時檢查 [Placeholder::getType](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/placeholder/gettype/) 以及執行時的形狀類別，而不要假設每個佔位符都是 [AutoShape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/autoshape/)。

{{% alert color="warning" title="Warning" %}}
[Placeholder::getType](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/placeholder/gettype/) 說明了佔位符的角色；它不保證形狀的執行時類別。存取文字、圖片、圖表、表格或媒體相關成員前，請務必先進行類型檢查。
{{% /alert %}}

## **了解佔位符繼承**

佔位符形成層級結構：

1. 母片定義可重複使用的樣式，且在某些情況下會包含母片層級的佔位符。
2. 佈局投影片定義一或多張普通投影片的排列方式，並可從母片繼承。
3. 普通投影片包含該投影片的佔位符，且可從其佈局繼承。

呼叫 [Shape::getBasePlaceholder](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shape/getbaseplaceholder/) 可向上移動一層層級。投影片佔位符通常回傳其佈局佔位符；佈局佔位符則可回傳其母片佔位符。若形狀沒有基礎佔位符，方法會回傳 `null`。

以下範例列出第一張投影片的佔位符，並報告其基礎佔位符：

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

在普通投影片上編輯佔位符會為該投影片建立或變更本機覆寫。編輯相關的佈局或母片則可能影響仍在繼承該設定的所有投影片。普通本機形狀沒有基礎佔位符，也不會僅因佔據相同座標而開始繼承。

## **變更佔位符內的文字**

標題、置中標題、副標題、內文與文字佔位符通常支援文字。使用前請先確認是 [AutoShape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/autoshape/)，再呼叫其 [getTextFrame](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/autoshape/gettextframe/) 方法。

以下範例更新第一張投影片的第一個標題佔位符，並儲存結果：

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

此模式避免將圖片、圖表、表格或媒體佔位符當作 [AutoShape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/autoshape/) 物件來處理。它亦以用途辨識佔位符，而非依賴脆弱的形狀索引。

## **在版面上設定提示文字**

提示文字是設計時顯示在空佔位符中的指示，例如 *Click to add title*。請在版面佔位符上設定自訂提示文字，而不是透過普通投影片的形狀集合去取得。可透過 [Slide::getLayoutSlide](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/slide/#getLayoutSlide) 取得版面，然後遍歷由 [BaseSlide::getShapes](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/baseslide/#getShapes) 回傳的集合。

以下範例變更第一張投影片所使用版面的標題與副標題提示文字：

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

提示文字不是普通投影片內容。它僅供 PowerPoint 等編輯應用程式在空佔位符中顯示。使用者或程式提供真實內容後，提示文字就不再顯示。變更提示文字也不會取代使用該版面的投影片上已存在的文字。

## **更新圖片佔位符**

需要處理兩種情況：

- 若圖片佔位符已被填入，且以 [PictureFrame](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/pictureframe/) 表示，請透過 [PictureFillFormat::getPicture](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/picturefillformat/getpicture/) 與 [SlidesPicture::setImage](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/slidespicture/setimage/) 取代影像。
- 若仍是空的佔位符，請使用 [ShapeCollection::addPictureFrame](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shapecollection/addpictureframe/) 在佔位符座標新增圖片框，並移除空的佔位符。

以下範例同時支援上述兩種情況，並儲存簡報：

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

為空佔位符建立的取代物是一個本機圖片框，而非新佔位符，因為 [Shape::getPlaceholder](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shape/getplaceholder/) 並未提供設定子。它保留了保留位置，但不再繼承佔位符特有的行為。若必須保留佔位符關係，請先在 PowerPoint 中建立並填入佔位符，然後再以 Aspose.Slides 更新產生的 [PictureFrame](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/pictureframe/)。

若需影像透明度、裁剪及其他圖片特有效果，請參閱 [管理圖片框架](/slides/zh-hant/php-java/picture-frame/)。這些操作屬於圖片框或圖片填充，而非佔位符的中繼資料。

## **使用圖表與內容佔位符**

已填入的圖表佔位符可以以 [Chart](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chart/) 表示。以下範例同時依據佔位符類型與執行時類別找出此圖表，變更其標題，並儲存檔案：

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

一般內容佔位符通常具有 [PlaceholderType::Object](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/placeholdertype/)。在 PowerPoint 中，它充當多種內容類型的啟動器，包括圖表、表格、圖示、圖片與媒體。填入後，請檢查實際的形狀類別以了解其包含的內容。特化的版面亦可能曝光 [PlaceholderType::Chart]、[PlaceholderType::Table]、[PlaceholderType::Picture]、[PlaceholderType::Media] 或 [PlaceholderType::Diagram]。

Aspose.Slides 不會僅透過變更 [Placeholder::getType](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/placeholder/gettype/) 就將空的 [AutoShape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/autoshape/) 佔位符轉換為 [Chart]；類型無法透過類別變更。若要以程式方式填入空的圖表或內容區域，請在佔位符座標加入所需物件，然後移除空的佔位符。以下範例示範如何為圖表執行此操作：

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

新增的圖表是一個普通的本機圖表。它佔據佔位符的區域，但不會繼承自版面佔位符。需要替換其類別、系列或活頁簿資料時，請使用專門的 [圖表管理文章](/slides/zh-hant/php-java/powerpoint-charts/)。

## **完整範例：更新文字或影像內容**

以下端對端範例開啟範本，於第一張投影片搜尋標題或圖片佔位符，檢查佔位符與形狀類型，更新相應內容，並儲存輸出。此範例刻意避免假設形狀索引或將每個佔位符視為相同類別：

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

## **FAQ**

**什麼是基礎佔位符？**

基礎佔位符是指在佈局或母片上對應的形狀，其他佔位符會從其繼承。使用 [Shape::getBasePlaceholder](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shape/getbaseplaceholder/) 取得。普通本機形狀會回傳 `null`，因為它不屬於佔位符層級。

**我可以透過編輯版面佔位符來變更所有投影片的標題嗎？**

您可以透過版面變更繼承的格式或提示文字，但實際的標題內容儲存在普通投影片上。若要取代簡報中所有投影片的標題文字，需要遍歷投影片並更新每個標題佔位符。

**如何管理日期、投影片編號、頁首和頁尾佔位符？**

請在相應的投影片、版面、母片、備註或講義範圍使用標題與頁尾管理器。參閱 [管理簡報頁首與頁尾](/slides/zh-hant/php-java/presentation-header-and-footer/) 以取得完整範例。
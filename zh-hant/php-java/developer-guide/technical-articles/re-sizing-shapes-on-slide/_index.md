---
title: 在 PHP 中調整簡報投影片上的圖形大小
type: docs
weight: 130
url: /zh-hant/php-java/resizing-shapes-on-slide/
aliases:
  - /php-java/re-sizing-shapes-on-slide/
keywords:
  - 調整圖形大小
  - 變更圖形尺寸
  - PowerPoint
  - OpenDocument
  - 簡報
  - PHP
  - Aspose.Slides
description: 使用 Aspose.Slides for PHP via Java 輕鬆調整 PowerPoint 與 OpenDocument 投影片上的圖形大小——自動化投影片版面調整並提升生產力。
---
## **概覽**

當您變更簡報的投影片尺寸時，可能也需要調整與重新定位圖形，以符合新的尺寸。本文說明如何手動縮放圖形，以及如何處理投影片、母片與版面配置中的表格。

## **調整圖形大小**

為了保留每個圖形的相對位置和大小，請將其水平座標與寬度乘以新投影片寬度與原始寬度的比率。再以相應的高度比率套用於其垂直座標與高度。

第一個範例載入投影片中不含表格的簡報，將投影片尺寸變更為 A4，並儲存結果。它使用 [SlideSize::setSize](https://reference.aspose.com/slides/php-java/aspose.slides/slidesize/setsize/) 搭配 [SlideSizeScaleType::DoNotScale](https://reference.aspose.com/slides/php-java/aspose.slides/slidesizescaletype/)，讓隨後的迴圈負責縮放。這些比率沒有單位；圖形的位置與尺寸以點 (point) 為單位測量。不同的寬度與高度比率可能會造成圖形變形，且變更圖形尺寸不會同步縮放其字型大小。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideSizeScaleType;
use aspose\slides\SlideSizeType;

$presentation = new Presentation("sample.pptx");
try {
    // 計算獨立的水平和垂直縮放因子。
    $originalSize = $presentation->getSlideSize()->getSize();
    $presentation->getSlideSize()->setSize(SlideSizeType::A4Paper, SlideSizeScaleType::DoNotScale);
    $targetSize = $presentation->getSlideSize()->getSize();
    $widthRatio = java_values($targetSize->getWidth()) / java_values($originalSize->getWidth());
    $heightRatio = java_values($targetSize->getHeight()) / java_values($originalSize->getHeight());

    for ($slideIndex = 0; $slideIndex < java_values($presentation->getSlides()->size()); $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        for ($shapeIndex = 0; $shapeIndex < java_values($slide->getShapes()->size()); $shapeIndex++) {
            $shape = $slide->getShapes()->get_Item($shapeIndex);
            $shape->setWidth(java_values($shape->getWidth()) * $widthRatio);
            $shape->setHeight(java_values($shape->getHeight()) * $heightRatio);
            $shape->setX(java_values($shape->getX()) * $widthRatio);
            $shape->setY(java_values($shape->getY()) * $heightRatio);
        }
    }

    $presentation->save("output.pptx", SaveFormat::Pptx);
}
finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Note" %}}
表格需要單獨處理：需縮放其欄寬與列高，而不是直接設定表格的整體寬度與高度。若儲存格內容需要更多空間，列高可能會保持大於所要求的大小。
{{% /alert %}}

第二個範例支援表格，並在儲存已調整大小的簡報之前，處理母片與版面配置及個別投影片上的圖形。其輔助程式會針對每個 [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/)，透過 [Column::setWidth](https://reference.aspose.com/slides/php-java/aspose.slides/column/setwidth/) 縮放欄寬，並以 [Row::setMinimalHeight](https://reference.aspose.com/slides/php-java/aspose.slides/row/setminimalheight/) 設定最小列高。然後僅縮放表格的位置，而不會單獨縮放其整體尺寸。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideSizeScaleType;
use aspose\slides\SlideSizeType;

class ShapeResizer {
    public function resizeShapes($shapes, $widthRatio, $heightRatio) {
        $tableClass = new JavaClass("com.aspose.slides.Table");
        for ($shapeIndex = 0; $shapeIndex < java_values($shapes->size()); $shapeIndex++) {
            $shape = $shapes->get_Item($shapeIndex);
            if (java_instanceof($shape, $tableClass)) {
                $table = $shape;
                // 表格的尺寸受欄寬與列高控制。
                for ($columnIndex = 0; $columnIndex < java_values($table->getColumns()->size()); $columnIndex++) {
                    $column = $table->getColumns()->get_Item($columnIndex);
                    $column->setWidth(java_values($column->getWidth()) * $widthRatio);
                }

                for ($rowIndex = 0; $rowIndex < java_values($table->getRows()->size()); $rowIndex++) {
                    $row = $table->getRows()->get_Item($rowIndex);
                    $row->setMinimalHeight(java_values($row->getMinimalHeight()) * $heightRatio);
                }
            }
            else {
                $shape->setWidth(java_values($shape->getWidth()) * $widthRatio);
                $shape->setHeight(java_values($shape->getHeight()) * $heightRatio);
            }

            $shape->setX(java_values($shape->getX()) * $widthRatio);
            $shape->setY(java_values($shape->getY()) * $heightRatio);
        }
    }
}

$presentation = new Presentation("sample.pptx");
try {
    // 計算獨立的水平與垂直縮放因子。
    $originalSize = $presentation->getSlideSize()->getSize();
    $presentation->getSlideSize()->setSize(SlideSizeType::A4Paper, SlideSizeScaleType::DoNotScale);
    $targetSize = $presentation->getSlideSize()->getSize();
    $widthRatio = java_values($targetSize->getWidth()) / java_values($originalSize->getWidth());
    $heightRatio = java_values($targetSize->getHeight()) / java_values($originalSize->getHeight());

    $resizer = new ShapeResizer();

    // 調整母片、版面配置以及各個投影片上定義的圖形大小。
    for ($masterIndex = 0; $masterIndex < java_values($presentation->getMasters()->size()); $masterIndex++) {
        $master = $presentation->getMasters()->get_Item($masterIndex);
        $resizer->resizeShapes($master->getShapes(), $widthRatio, $heightRatio);

        for ($layoutSlideIndex = 0; $layoutSlideIndex < java_values($master->getLayoutSlides()->size()); $layoutSlideIndex++) {
            $layoutSlide = $master->getLayoutSlides()->get_Item($layoutSlideIndex);
            $resizer->resizeShapes($layoutSlide->getShapes(), $widthRatio, $heightRatio);
        }
    }

    for ($slideIndex = 0; $slideIndex < java_values($presentation->getSlides()->size()); $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $resizer->resizeShapes($slide->getShapes(), $widthRatio, $heightRatio);
    }

    $presentation->save("output.pptx", SaveFormat::Pptx);
}
finally {
    $presentation->dispose();
}
```

## **常見問題**

**調整投影片大小後，為什麼圖形會變形或被截斷？**

如果在變更投影片尺寸時未對圖形進行縮放，它們會保留原始的位置與尺寸，可能會超出投影片範圍。使用不同的寬度與高度比率進行縮放亦會造成圖形變形。

**提供的程式碼能適用於所有圖形類型嗎？**

第一個範例直接變更圖形邊界，適用於不含表格的投影片。第二個範例則單獨處理表格。請檢查最終的版面配置，特別是文字與表格，因為這些範例不會縮放字型大小，且表格內容可能限制列高。

**在調整投影片大小時，如何調整表格尺寸？**

依寬度比率縮放欄寬，依高度比率縮放最小列高，然後如第二個範例所示，縮放表格的位置。

**此調整大小的方式能適用於母片與版面配置投影片嗎？**

會的。第二個範例會遍歷 [Presentation::getMasters](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getmasters/) 及每個母片的 [MasterSlide::getLayoutSlides](https://reference.aspose.com/slides/php-java/aspose.slides/masterslide/getlayoutslides/)，並對其圖形套用相同的調整大小邏輯。

**我可以在調整大小的同時變更投影片方向（直向/橫向）嗎？**

可以。於變更投影片尺寸後、讀取目標尺寸前，呼叫 [SlideSize::setOrientation](https://reference.aspose.com/slides/php-java/aspose.slides/slidesize/setorientation/)，使縮放係數反映最終的方向。

**我能設定的投影片尺寸有上限嗎？**

您可以使用 [SlideSize::setSize](https://reference.aspose.com/slides/php-java/aspose.slides/slidesize/setsize/) 指定自訂的投影片尺寸。支援的尺寸亦取決於簡報格式以及用來開啟檔案的應用程式。

**如何防止具有固定長寬比的圖形變形？**

對寬度與高度使用相同的縮放係數。若要讓原始版面配置適應新的投影片尺寸，請同時使用寬度與高度比率中較小的那一個來縮放尺寸與位置。這樣可保留比例，但可能會在某一邊留下未使用的空間。
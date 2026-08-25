---
title: 使用 PHP 管理簡報中的投影片節段
linktitle: 投影片節段
type: docs
weight: 90
url: /zh-hant/php-java/slide-section/
keywords:
  - 建立節段
  - 新增節段
  - 編輯節段
  - 變更節段
  - 節段名稱
  - 取得節段投影片
  - 處理節段投影片
  - PowerPoint
  - 簡報
  - PHP
  - Aspose.Slides
description: "使用 Aspose.Slides for PHP via Java 管理投影片節段：在 PPTX 簡報中建立、重新命名、重新排序、取得及處理節段投影片。"
---
## **簡介**

節段將連續投影片組織成具名稱的群組，且不會更改投影片內容。使用 Aspose.Slides for PHP via Java，您可以透過[Presentation::getSections](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/Presentation/#getSections)方法建立、重新排序、重新命名、檢查以及移除節段。

當以下情況時，節段特別有用：

- 大型簡報需要依邏輯主題或章節切分；
- 不同投影片群組指派給不同的協作者；
- 需要以群組方式處理、移動或合併投影片。

請選擇能簡潔說明分組投影片目的的節段名稱。由於節段是簡報結構的一部分，請使用節段 API 判斷隸屬關係，而非依投影片位置推斷。

## **建立與管理節段**

使用[SectionCollection::addSection](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/SectionCollection/#addSection)可透過指定名稱與起始投影片建立節段。Aspose.Slides 會根據簡報目前的節段結構決定哪些投影片屬於該節段。

相同的[SectionCollection](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/SectionCollection/)亦可讓您：

- 使用[SectionCollection::reorderSectionWithSlides](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/SectionCollection/#reorderSectionWithSlides)將節段連同其投影片一起移動；
- 使用[SectionCollection::removeSection](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/SectionCollection/#removeSection)僅移除節段定義，保留其投影片；
- 使用[SectionCollection::removeSectionWithSlides](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/SectionCollection/#removeSectionWithSlides)同時移除節段與其投影片；
- 使用[SectionCollection::appendEmptySection](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/SectionCollection/#appendEmptySection)於結尾加入空節段。

以下範例建立兩個節段，移動其中一個，將其連同投影片一起移除，最後再加入一個空節段：

```php
use aspose\slides\Presentation;

$presentation = new Presentation();
try {
    $titleSlide = $presentation->getSlides()->get_Item(0);
    $layoutSlide = $presentation->getLayoutSlides()->get_Item(0);
    $presentation->getSlides()->addEmptySlide($layoutSlide);
    $resultsSlide = $presentation->getSlides()->addEmptySlide($layoutSlide);
    $presentation->getSlides()->addEmptySlide($layoutSlide);

    $presentation->getSections()->addSection("Introduction", $titleSlide);
    $resultsSection = $presentation->getSections()->addSection("Results", $resultsSlide);

    $presentation->getSections()->reorderSectionWithSlides($resultsSection, 0);
    $presentation->getSections()->removeSectionWithSlides($resultsSection);
    $presentation->getSections()->appendEmptySection("Appendix");
} finally {
    $presentation->dispose();
}
```

執行上述操作後，簡報會包含 `Introduction` 節段及其投影片，並有一個空的 `Appendix` 節段。`Results` 節段及其投影片則已被移除。

## **重新命名節段**

要重新命名節段，呼叫其[Section::setName](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/Section/#setName)方法。節段的投影片與位置不會受到影響。

以下範例建立一個節段並變更其名稱：

```php
use aspose\slides\Presentation;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $section = $presentation->getSections()->addSection("Overview", $slide);
    $section->setName("Introduction");
} finally {
    $presentation->dispose();
}
```

## **從節段取得投影片**

[Presentation::getSections](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/Presentation/#getSections)方法會回傳一個[SectionCollection](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/SectionCollection/)，您可以依索引逐一處理。對於每個[Section](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/Section/)，呼叫[Section::getSlidesListOfSection](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/Section/#getSlidesListOfSection)即可取得目前屬於該節段的投影片。此方法回傳一個[SectionSlideCollection](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/SectionSlideCollection/)，提供計數與索引存取。

以下範例建立兩個已填充的節段與一個空節段，然後列印每個節段的[name](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/Section/#getName)、[identifier](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/Section/#getSectionId)、[starting slide](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/Section/#getStartedFromSlide)、投影片數量與投影片編號。示例使用[SectionCollection::get_Item](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/SectionCollection/#get_Item)與[SectionSlideCollection::get_Item](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/SectionSlideCollection/#get_Item)進行索引存取。對於空節段，回傳的集合大小為零，且不會呼叫`get_Item`。

```php
use aspose\slides\Presentation;

$presentation = new Presentation();
try {
    $firstSlide = $presentation->getSlides()->get_Item(0);
    $layoutSlide = $presentation->getLayoutSlides()->get_Item(0);
    $presentation->getSlides()->addEmptySlide($layoutSlide);
    $thirdSlide = $presentation->getSlides()->addEmptySlide($layoutSlide);

    $presentation->getSections()->addSection("Introduction", $firstSlide);
    $presentation->getSections()->addSection("Details", $thirdSlide);
    $presentation->getSections()->appendEmptySection("Appendix");

    $sections = $presentation->getSections();
    $sectionCount = java_values($sections->size());
    for ($sectionIndex = 0; $sectionIndex < $sectionCount; $sectionIndex++) {
        $section = $sections->get_Item($sectionIndex);
        $sectionSlides = $section->getSlidesListOfSection();
        $startingSlide = java_is_null($section->getStartedFromSlide()) ? "none" : java_values($section->getStartedFromSlide()->getSlideNumber());
        $slideCount = java_values($sectionSlides->size());

        echo "Section: " . java_values($section->getName()) . PHP_EOL;
        echo "ID: " . java_values($section->getSectionId()) . PHP_EOL;
        echo "Starting slide: " . $startingSlide . PHP_EOL;
        echo "Slide count: " . $slideCount . PHP_EOL;

        if ($slideCount > 0) {
            echo "First slide via get_Item: " . java_values($sectionSlides->get_Item(0)->getSlideNumber()) . PHP_EOL;
        }

        echo "Slide numbers:";
        for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
            $slide = $sectionSlides->get_Item($slideIndex);
            echo " " . java_values($slide->getSlideNumber());
        }
        echo PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

節段的隸屬關係由簡報的節段結構決定。不要僅依[Section::getStartedFromSlide](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/Section/#getStartedFromSlide)、投影片索引以及下一節段的起始投影片手動計算範圍。

結構性編輯可能同時變更節段回傳的投影片以及它們的投影片編號。這包括重新排序投影片、將投影片複製至節段、一起移動節段與其投影片、移除投影片以及移除節段。下一個範例在每次此類變更後呼叫[Section::getSlidesListOfSection](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/Section/#getSlidesListOfSection)，而不是保留對先前邊界的假設。

```php
use aspose\slides\Presentation;

$presentation = new Presentation();
try {
    $firstSlide = $presentation->getSlides()->get_Item(0);
    $layoutSlide = $presentation->getLayoutSlides()->get_Item(0);
    $presentation->getSlides()->addEmptySlide($layoutSlide);
    $thirdSlide = $presentation->getSlides()->addEmptySlide($layoutSlide);
    $presentation->getSlides()->addEmptySlide($layoutSlide);
    $firstSection = $presentation->getSections()->addSection("First", $firstSlide);
    $secondSection = $presentation->getSections()->addSection("Second", $thirdSlide);

    $printSectionSlides = function ($label, $section) {
        $sectionSlides = $section->getSlidesListOfSection();
        $slideCount = java_values($sectionSlides->size());
        echo $label . " (" . $slideCount . " slides):";
        for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
            $slide = $sectionSlides->get_Item($slideIndex);
            echo " " . java_values($slide->getSlideNumber());
        }
        echo PHP_EOL;
    };

    $printSectionSlides("Initially", $firstSection);

    $slidesBeforeClone = $firstSection->getSlidesListOfSection();
    $presentation->getSlides()->addClone($slidesBeforeClone->get_Item(0), $firstSection);
    $printSectionSlides("After cloning into the section", $firstSection);

    $slidesBeforeReorder = $firstSection->getSlidesListOfSection();
    $firstSectionPosition = java_values($slidesBeforeReorder->get_Item(0)->getSlideNumber()) - 1;
    $lastSlideIndex = java_values($slidesBeforeReorder->size()) - 1;
    $presentation->getSlides()->reorder($firstSectionPosition, $slidesBeforeReorder->get_Item($lastSlideIndex));
    $printSectionSlides("After reordering slides", $firstSection);

    $presentation->getSections()->reorderSectionWithSlides($firstSection, 1);
    $printSectionSlides("After moving the section", $firstSection);

    $slidesBeforeRemoval = $firstSection->getSlidesListOfSection();
    $presentation->getSlides()->remove($slidesBeforeRemoval->get_Item(0));
    $printSectionSlides("After removing a slide", $firstSection);

    $presentation->getSections()->removeSectionWithSlides($secondSection);
    $remainingSections = $presentation->getSections();
    $remainingSectionCount = java_values($remainingSections->size());
    for ($sectionIndex = 0; $sectionIndex < $remainingSectionCount; $sectionIndex++) {
        $section = $remainingSections->get_Item($sectionIndex);
        $printSectionSlides("Remaining section", $section);
    }
} finally {
    $presentation->dispose();
}
```

每當投影片或節段被重新排序、複製、移動或移除時，請再次呼叫[Section::getSlidesListOfSection](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/Section/#getSlidesListOfSection)。這可確保後續處理與目前的簡報結構保持一致。

PPT（PowerPoint 97–2003）格式不會保留節段中繼資料。請於支援節段的格式（如 PPTX）中使用此工作流程；轉換為 PPT 會移除後續迭代所需的節段結構。

## **常見問題**

**將簡報儲存為 PPT（PowerPoint 97–2003）格式時，節段會被保留嗎？**

不會。PPT 格式不支援節段中繼資料，儲存為 `.ppt` 時會失去節段分組。

**是否可以「隱藏」整個節段？**

不行。節段本身沒有可見性狀態。若要隱藏其內容，必須對節段內的每張投影片呼叫[Slide::setHidden](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/Slide/#setHidden)。

**如何找出包含特定投影片的節段？**

遍歷[Presentation::getSections](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/Presentation/#getSections)回傳的集合，對每個節段呼叫[Section::getSlidesListOfSection](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/Section/#getSlidesListOfSection)，將回傳的投影片與目標投影片比較。對於非空節段，[Section::getStartedFromSlide](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/Section/#getStartedFromSlide) 會回傳其第一張投影片；對於空節段，則回傳 `null`。
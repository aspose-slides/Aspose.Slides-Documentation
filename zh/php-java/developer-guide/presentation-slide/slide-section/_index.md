---
title: 使用 PHP 在演示文稿中管理幻灯片章节
linktitle: 幻灯片章节
type: docs
weight: 90
url: /zh/php-java/slide-section/
keywords:
- 创建章节
- 添加章节
- 编辑章节
- 更改章节
- 章节名称
- 检索章节幻灯片
- 处理章节幻灯片
- PowerPoint
- 演示文稿
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides for PHP via Java 管理幻灯片章节：在 PPTX 演示文稿中创建、重命名、重新排序、检索和处理章节幻灯片。"
---
## **介绍**

章节将连续的幻灯片组织成具名的组，而不更改幻灯片内容。使用 Aspose.Slides for PHP via Java，您可以通过[Presentation::getSections](https://reference.aspose.com/slides/zh/php-java/aspose.slides/Presentation/#getSections)方法创建、重新排序、重命名、检查和删除章节。

章节在以下情况下尤其有用：

- 大型演示文稿需要划分为逻辑主题或章节；
- 不同的幻灯片组分配给不同的协作者；
- 幻灯片需要作为整体进行处理、移动或合并。

请选择能够简洁描述分组幻灯片用途的章节名称。由于章节是演示文稿结构的一部分，请使用章节 API 来确定成员关系，而不是根据幻灯片位置推断。

## **创建和管理章节**

使用[SectionCollection::addSection](https://reference.aspose.com/slides/zh/php-java/aspose.slides/SectionCollection/#addSection)通过指定名称和起始幻灯片来创建章节。Aspose.Slides 会根据演示文稿当前的章节结构确定哪些幻灯片属于该章节。

同一[SectionCollection](https://reference.aspose.com/slides/zh/php-java/aspose.slides/SectionCollection/)还可用于：

- 使用[SectionCollection::reorderSectionWithSlides](https://reference.aspose.com/slides/zh/php-java/aspose.slides/SectionCollection/#reorderSectionWithSlides)移动章节及其幻灯片；
- 使用[SectionCollection::removeSection](https://reference.aspose.com/slides/zh/php-java/aspose.slides/SectionCollection/#removeSection)仅删除章节定义，保留其幻灯片；
- 使用[SectionCollection::removeSectionWithSlides](https://reference.aspose.com/slides/zh/php-java/aspose.slides/SectionCollection/#removeSectionWithSlides)删除章节及其幻灯片；
- 使用[SectionCollection::appendEmptySection](https://reference.aspose.com/slides/zh/php-java/aspose.slides/SectionCollection/#appendEmptySection)在末尾添加空章节。

以下示例创建了两个章节，移动其中一个，连同其幻灯片一起删除它，并追加一个空章节：

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

这些操作完成后，演示文稿包含带有幻灯片的`Introduction`章节和一个空的`Appendix`章节。`Results`章节及其幻灯片已被删除。

## **重命名章节**

要重命名章节，请调用其[Section::setName](https://reference.aspose.com/slides/zh/php-java/aspose.slides/Section/#setName)方法。章节的幻灯片和位置保持不变。

以下示例创建一个章节并更改其名称：

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

## **从章节检索幻灯片**

[Presentation::getSections](https://reference.aspose.com/slides/zh/php-java/aspose.slides/Presentation/#getSections)方法返回一个[SectionCollection](https://reference.aspose.com/slides/zh/php-java/aspose.slides/SectionCollection/)，您可以按索引对其进行处理。对于每个[Section](https://reference.aspose.com/slides/zh/php-java/aspose.slides/Section/)，调用[Section::getSlidesListOfSection](https://reference.aspose.com/slides/zh/php-java/aspose.slides/Section/#getSlidesListOfSection)即可获取当前属于该章节的幻灯片。该方法返回一个[SectionSlideCollection](https://reference.aspose.com/slides/zh/php-java/aspose.slides/SectionSlideCollection/)，提供计数和索引访问。

以下示例创建了两个填充章节和一个空章节，然后打印每个章节的[name](https://reference.aspose.com/slides/zh/php-java/aspose.slides/Section/#getName)、[identifier](https://reference.aspose.com/slides/zh/php-java/aspose.slides/Section/#getSectionId)、[starting slide](https://reference.aspose.com/slides/zh/php-java/aspose.slides/Section/#getStartedFromSlide)、幻灯片计数和幻灯片编号。它使用[SectionCollection::get_Item](https://reference.aspose.com/slides/zh/php-java/aspose.slides/SectionCollection/#get_Item)和[SectionSlideCollection::get_Item](https://reference.aspose.com/slides/zh/php-java/aspose.slides/SectionSlideCollection/#get_Item)进行索引访问。对于空章节，返回的集合大小为零，且未调用`get_Item`。

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

章节成员由演示文稿的章节结构决定。不要通过手动计算[Section::getStartedFromSlide](https://reference.aspose.com/slides/zh/php-java/aspose.slides/Section/#getStartedFromSlide)、幻灯片索引以及下一个章节的起始幻灯片来确定章节范围。

结构性编辑可能会改变返回给章节的幻灯片以及它们的幻灯片编号。这包括重新排序幻灯片、将幻灯片克隆到章节、连同幻灯片一起移动章节、删除幻灯片以及删除章节。下面的示例在每次此类更改后调用[Section::getSlidesListOfSection](https://reference.aspose.com/slides/zh/php-java/aspose.slides/Section/#getSlidesListOfSection)，而不是保留对章节先前边界的假设。

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

每当幻灯片或章节被重新排序、克隆、移动或删除时，请再次调用[Section::getSlidesListOfSection](https://reference.aspose.com/slides/zh/php-java/aspose.slides/Section/#getSlidesListOfSection)。这可确保后续处理与当前的演示文稿结构保持一致。

PPT（PowerPoint 97–2003）格式不保留章节元数据。请使用支持章节的格式（如 PPTX）进行此工作流；转换为 PPT 会移除后续迭代所需的章节结构。

## **常见问题**

**Are sections preserved when saving to the PPT (PowerPoint 97–2003) format?**

否。PPT 格式不支持章节元数据，保存为 .ppt 时章节分组会丢失。

**Can an entire section be "hidden"?**

否。章节本身没有可见性状态。若要隐藏其内容，需要对章节中的每个幻灯片调用[Slide::setHidden](https://reference.aspose.com/slides/zh/php-java/aspose.slides/Slide/#setHidden)。

**How can I find the section that contains a slide?**

遍历[Presentation::getSections](https://reference.aspose.com/slides/zh/php-java/aspose.slides/Presentation/#getSections)返回的集合，对每个章节调用[Section::getSlidesListOfSection](https://reference.aspose.com/slides/zh/php-java/aspose.slides/Section/#getSlidesListOfSection)，并将返回的幻灯片与目标幻灯片进行比较。对于非空章节，[Section::getStartedFromSlide](https://reference.aspose.com/slides/zh/php-java/aspose.slides/Section/#getStartedFromSlide)返回其第一张幻灯片；对于空章节，则返回`null`。
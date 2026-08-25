---
title: Управление разделами слайдов в презентациях с PHP
linktitle: Раздел слайда
type: docs
weight: 90
url: /ru/php-java/slide-section/
keywords:
- создать раздел
- добавить раздел
- редактировать раздел
- изменить раздел
- имя раздела
- получить слайды раздела
- обработать слайды раздела
- PowerPoint
- презентация
- PHP
- Aspose.Slides
description: "Управляйте разделами слайдов с помощью Aspose.Slides for PHP via Java: создавайте, переименовывайте, переупорядочивайте, получайте и обрабатывайте слайды разделов в презентациях PPTX."
---
## **Введение**

Разделы упорядочивают последовательные слайды в именованные группы, не изменяя содержимое слайдов. С помощью Aspose.Slides for PHP via Java вы можете создавать, переупорядочивать, переименовывать, просматривать и удалять разделы через метод [Presentation::getSections](https://reference.aspose.com/slides/ru/php-java/aspose.slides/Presentation/#getSections).

Разделы особенно полезны, когда:

- большая презентация должна быть разбита на логические темы или главы;
- разные группы слайдов назначаются разным сотрудникам;
- слайды нужно обрабатывать, перемещать или объединять группами.

Выбирайте короткие названия разделов, которые описывают назначение сгруппированных слайдов. Поскольку разделы являются частью структуры презентации, используйте API разделов для определения принадлежности, а не выводите её из позиций слайдов.

## **Создание и управление разделами**

Используйте [SectionCollection::addSection](https://reference.aspose.com/slides/ru/php-java/aspose.slides/SectionCollection/#addSection) для создания раздела, указав его имя и начальный слайд. Aspose.Slides определяет, какие слайды входят в раздел, основываясь на текущей структуре разделов презентации.

Тот же объект [SectionCollection](https://reference.aspose.com/slides/ru/php-java/aspose.slides/SectionCollection/) также позволяет:

- переместить раздел вместе с его слайдами, используя [SectionCollection::reorderSectionWithSlides](https://reference.aspose.com/slides/ru/php-java/aspose.slides/SectionCollection/#reorderSectionWithSlides);
- удалить только определение раздела с помощью [SectionCollection::removeSection](https://reference.aspose.com/slides/ru/php-java/aspose.slides/SectionCollection/#removeSection), при этом слайды сохраняются;
- удалить раздел и его слайды с помощью [SectionCollection::removeSectionWithSlides](https://reference.aspose.com/slides/ru/php-java/aspose.slides/SectionCollection/#removeSectionWithSlides);
- добавить пустой раздел в конец с помощью [SectionCollection::appendEmptySection](https://reference.aspose.com/slides/ru/php-java/aspose.slides/SectionCollection/#appendEmptySection).

В следующем примере создаются два раздела, один из них перемещается, затем удаляется вместе со своими слайдами, и добавляется пустой раздел:

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

После этих операций презентация содержит раздел `Introduction` со своими слайдами и пустой раздел `Appendix`. Раздел `Results` и его слайды были удалены.

## **Переименование разделов**

Чтобы переименовать раздел, вызовите его метод [Section::setName](https://reference.aspose.com/slides/ru/php-java/aspose.slides/Section/#setName). Слайды раздела и его позиция остаются без изменений.

В следующем примере создаётся раздел и меняется его имя:

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

## **Получение слайдов из разделов**

Метод [Presentation::getSections](https://reference.aspose.com/slides/ru/php-java/aspose.slides/Presentation/#getSections) возвращает объект [SectionCollection](https://reference.aspose.com/slides/ru/php-java/aspose.slides/SectionCollection/), которым можно работать по индексу. Для каждого [Section](https://reference.aspose.com/slides/ru/php-java/aspose.slides/Section/) вызывайте [Section::getSlidesListOfSection](https://reference.aspose.com/slides/ru/php-java/aspose.slides/Section/#getSlidesListOfSection), чтобы получить слайды, принадлежащие данному разделу в текущий момент. Метод возвращает объект [SectionSlideCollection](https://reference.aspose.com/slides/ru/php-java/aspose.slides/SectionSlideCollection/), предоставляющий количество элементов и доступ по индексу.

В следующем примере создаются два заполненных раздела и один пустой раздел, затем выводятся [name](https://reference.aspose.com/slides/ru/php-java/aspose.slides/Section/#getName), [identifier](https://reference.aspose.com/slides/ru/php-java/aspose.slides/Section/#getSectionId), [starting slide](https://reference.aspose.com/slides/ru/php-java/aspose.slides/Section/#getStartedFromSlide), количество слайдов и номера слайдов каждого раздела. Для доступа по индексу используются [SectionCollection::get_Item](https://reference.aspose.com/slides/ru/php-java/aspose.slides/SectionCollection/#get_Item) и [SectionSlideCollection::get_Item](https://reference.aspose.com/slides/ru/php-java/aspose.slides/SectionSlideCollection/#get_Item). Для пустого раздела возвращаемая коллекция имеет размер ноль, и `get_Item` не вызывается.

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

Принадлежность к разделу определяется структурой разделов презентации. Не вычисляйте диапазон раздела вручную, исходя из [Section::getStartedFromSlide](https://reference.aspose.com/slides/ru/php-java/aspose.slides/Section/#getStartedFromSlide), индексов слайдов и начального слайда следующего раздела.

Структурные изменения могут изменить как набор слайдов, возвращаемых для раздела, так и их номера. К таким изменениям относятся переупорядочивание слайдов, клонирование слайда в раздел, перемещение раздела вместе с его слайдами, удаление слайдов и удаление разделов. В следующем примере после каждого такого изменения вызывается [Section::getSlidesListOfSection](https://reference.aspose.com/slides/ru/php-java/aspose.slides/Section/#getSlidesListOfSection), вместо того чтобы полагаться на прежние границы раздела.

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

Вызывайте [Section::getSlidesListOfSection](https://reference.aspose.com/slides/ru/php-java/aspose.slides/Section/#getSlidesListOfSection) снова каждый раз, когда слайды или разделы переупорядочиваются, клонируются, перемещаются или удаляются. Это обеспечивает согласованность последующей обработки с текущей структурой презентации.

Формат PPT (PowerPoint 97–2003) не сохраняет метаданные разделов. Используйте этот рабочий процесс с форматом, поддерживающим разделы, например PPTX; преобразование в PPT удаляет структуру разделов, необходимую для последующей итерации.

## **Часто задаваемые вопросы**

**Сохраняются ли разделы при сохранении в формате PPT (PowerPoint 97–2003)?**

Нет. Формат PPT не поддерживает метаданные разделов, поэтому группировка по разделам теряется при сохранении в .ppt.

**Можно ли полностью «скрыть» раздел?**

Нет. У раздела нет состояния видимости. Чтобы скрыть его содержимое, вызовите [Slide::setHidden](https://reference.aspose.com/slides/ru/php-java/aspose.slides/Slide/#setHidden) для каждого слайда в разделе.

**Как найти раздел, содержащий определённый слайд?**

Переберите коллекцию, возвращаемую [Presentation::getSections](https://reference.aspose.com/slides/ru/php-java/aspose.slides/Presentation/#getSections), вызовите [Section::getSlidesListOfSection](https://reference.aspose.com/slides/ru/php-java/aspose.slides/Section/#getSlidesListOfSection) для каждого раздела и сравните полученные слайды с целым слайдом. Для непустого раздела [Section::getStartedFromSlide](https://reference.aspose.com/slides/ru/php-java/aspose.slides/Section/#getStartedFromSlide) возвращает его первый слайд; для пустого раздела возвращается `null`.
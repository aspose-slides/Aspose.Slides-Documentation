---
title: Управление руководящими линиями в презентациях в PHP
linktitle: Руководящие линии
type: docs
weight: 85
url: /ru/php-java/drawing-guides/
keywords:
- руководящая линия
- горизонтальная линия
- вертикальная линия
- линия выравнивания
- просмотр слайда
- мастер‑слайд
- макетный слайд
- мастер заметок
- мастер раздаточных материалов
- PowerPoint
- презентация
- PHP
- Aspose.Slides
description: "Добавление, доступ и очистка горизонтальных и вертикальных руководящих линий в презентациях PowerPoint с помощью Aspose.Slides for PHP via Java."
---
## **Обзор**

Руководящие линии – это регулируемые горизонтальные и вертикальные линии, которые помогают пользователям последовательно выравнивать фигуры при редактировании презентации в PowerPoint. Они особенно полезны, когда приложение генерирует презентацию, которую затем будет дорабатывать вручную: приложение может сохранить те же вспомогательные средства выравнивания, которыми должны пользоваться авторы при добавлении или перемещении содержимого.

Руководящие линии являются средствами редактирования, а не содержимым слайда. Они не отображаются в режиме показа слайдов и не включаются в вывод. Aspose.Slides for PHP via Java предоставляет их через класс [DrawingGuidesCollection](https://reference.aspose.com/slides/ru/php-java/aspose.slides/drawingguidescollection/). Руководящая линия представлена классом [DrawingGuide](https://reference.aspose.com/slides/ru/php-java/aspose.slides/drawingguide/) и имеет ориентацию, позицию и цвет.

Позиция измеряется в пунктах от верхнего левого угла соответствующего слайда или шаблона. Вертикальная линия использует горизонтальную координату, обычно от нуля до ширины слайда. Горизонтальная линия использует вертикальную координату, обычно от нуля до высоты слайда.

## **Добавить руководящие линии в режим просмотра слайда**

Используйте [CommonSlideViewProperties::getDrawingGuides](https://reference.aspose.com/slides/ru/php-java/aspose.slides/commonslideviewproperties/#getDrawingGuides) для управления руководящими линиями, отображаемыми при редактировании обычных слайдов. Вызовите [DrawingGuidesCollection::add](https://reference.aspose.com/slides/ru/php-java/aspose.slides/drawingguidescollection/#add), передав значение [Orientation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/orientation/) и позицию в пунктах.

Следующий пример добавляет одну вертикальную линию справа от центра слайда и одну горизонтальную линию ниже него:

```php
use aspose\slides\Orientation;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slideSize = $presentation->getSlideSize()->getSize();
    $slideWidth = java_values($slideSize->getWidth());
    $slideHeight = java_values($slideSize->getHeight());
    $guides = $presentation->getViewProperties()->getSlideViewProperties()->getDrawingGuides();

    $guides->add(Orientation::Vertical, $slideWidth / 2 + 12.5);
    $guides->add(Orientation::Horizontal, $slideHeight / 2 + 12.5);

    $presentation->save("drawing-guides.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Получить доступ к руководящим линиям**

Методы [DrawingGuidesCollection::getCount](https://reference.aspose.com/slides/ru/php-java/aspose.slides/drawingguidescollection/#getCount) и [DrawingGuidesCollection::get_Item](https://reference.aspose.com/slides/ru/php-java/aspose.slides/drawingguidescollection/#get_Item) предоставляют доступ к существующим линиям. Методы [DrawingGuide::getOrientation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/drawingguide/#getOrientation), [DrawingGuide::getPosition](https://reference.aspose.com/slides/ru/php-java/aspose.slides/drawingguide/#getPosition) и [DrawingGuide::getColor](https://reference.aspose.com/slides/ru/php-java/aspose.slides/drawingguide/#getColor) возвращают значения, которые также можно изменить с помощью соответствующих методов‑установщиков.

Следующий пример считывает руководящие линии режима просмотра слайда из презентации, созданной выше:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("drawing-guides.pptx");
try {
    $guides = $presentation->getViewProperties()->getSlideViewProperties()->getDrawingGuides();
    $guideCount = java_values($guides->getCount());

    for ($index = 0; $index < $guideCount; $index++) {
        $guide = $guides->get_Item($index);
        $orientation = java_values($guide->getOrientation());
        $position = java_values($guide->getPosition());
        $color = java_values($guide->getColor()->toString());
        echo sprintf("Guide %d: orientation = %d, position = %.2f, color = %s", $index, $orientation, $position, $color) . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

## **Добавить руководящие линии к мастеру и макетным слайдам**

У слайда‑мастера и каждого из его макетных слайдов могут быть свои коллекции руководящих линий. Используйте [MasterSlide::getDrawingGuides](https://reference.aspose.com/slides/ru/php-java/aspose.slides/masterslide/#getDrawingGuides) для мастера слайда и [LayoutSlide::getDrawingGuides](https://reference.aspose.com/slides/ru/php-java/aspose.slides/layoutslide/#getDrawingGuides) для макетного слайда.

Следующий пример добавляет вертикальную линию к первому мастеру слайда и горизонтальную линию к первому макетному слайду:

```php
use aspose\slides\Orientation;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slideSize = $presentation->getSlideSize()->getSize();
    $slideWidth = java_values($slideSize->getWidth());
    $slideHeight = java_values($slideSize->getHeight());
    $masterGuides = $presentation->getMasters()->get_Item(0)->getDrawingGuides();
    $layoutGuides = $presentation->getLayoutSlides()->get_Item(0)->getDrawingGuides();

    $masterGuides->add(Orientation::Vertical, $slideWidth / 2 - 20);
    $layoutGuides->add(Orientation::Horizontal, $slideHeight / 2 + 20);

    $presentation->save("master-layout-drawing-guides.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Добавить руководящие линии к мастерам заметок и раздаточных материалов**

Мастера заметок и мастера раздаточных материалов также поддерживают руководящие линии. Используйте [MasterNotesSlide::getDrawingGuides](https://reference.aspose.com/slides/ru/php-java/aspose.slides/masternotesslide/#getDrawingGuides) и [MasterHandoutSlide::getDrawingGuides](https://reference.aspose.com/slides/ru/php-java/aspose.slides/masterhandoutslide/#getDrawingGuides) для доступа к их коллекциям. Если в презентации отсутствует один из этих мастеров, получите соответствующий менеджер с помощью [Presentation::getMasterNotesSlideManager](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/#getMasterNotesSlideManager) или [Presentation::getMasterHandoutSlideManager](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/#getMasterHandoutSlideManager), затем создайте мастер по умолчанию с помощью `setDefaultMasterNotesSlide` или `setDefaultMasterHandoutSlide`.

Следующий пример добавляет горизонтальную линию к мастеру заметок и вертикальную линию к мастеру раздаточных материалов:

```php
use aspose\slides\Orientation;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $notesSize = $presentation->getNotesSize()->getSize();
    $notesWidth = java_values($notesSize->getWidth());
    $notesHeight = java_values($notesSize->getHeight());
    $notesMaster = $presentation->getMasterNotesSlideManager()->setDefaultMasterNotesSlide();
    $handoutMaster = $presentation->getMasterHandoutSlideManager()->setDefaultMasterHandoutSlide();

    $notesMaster->getDrawingGuides()->add(Orientation::Horizontal, $notesHeight / 2 + 50);
    $handoutMaster->getDrawingGuides()->add(Orientation::Vertical, $notesWidth / 2 - 50);

    $presentation->save("notes-handout-drawing-guides.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Очистить руководящие линии**

Вызовите [DrawingGuidesCollection::clear](https://reference.aspose.com/slides/ru/php-java/aspose.slides/drawingguidescollection/#clear), чтобы удалить все линии из определённой коллекции. Очистка одной коллекции не влияет на линии, хранящиеся в другой области.

Следующий пример очищает руководящие линии режима просмотра слайда и все линии на мастерах слайдов, макетных слайдах, мастере заметок и мастере раздаточных материалов без создания отсутствующих мастеров:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation-with-guides.pptx");
try {
    $presentation->getViewProperties()->getSlideViewProperties()->getDrawingGuides()->clear();

    $masterCount = java_values($presentation->getMasters()->size());
    for ($index = 0; $index < $masterCount; $index++) {
        $presentation->getMasters()->get_Item($index)->getDrawingGuides()->clear();
    }

    $layoutCount = java_values($presentation->getLayoutSlides()->size());
    for ($index = 0; $index < $layoutCount; $index++) {
        $presentation->getLayoutSlides()->get_Item($index)->getDrawingGuides()->clear();
    }

    $notesMaster = $presentation->getMasterNotesSlideManager()->getMasterNotesSlide();
    if (!java_is_null($notesMaster)) {
        $notesMaster->getDrawingGuides()->clear();
    }

    $handoutMaster = $presentation->getMasterHandoutSlideManager()->getMasterHandoutSlide();
    if (!java_is_null($handoutMaster)) {
        $handoutMaster->getDrawingGuides()->clear();
    }

    $presentation->save("presentation-without-guides.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**Появляются ли руководящие линии в показе слайдов или экспортированных изображениях?**

Нет. Руководящие линии служат вспомогательными средствами выравнивания при редактировании и не отображаются как содержимое презентации.

**Можно ли добавить руководящую линию напрямую к отдельному обычному слайду?**

Руководящие линии для редактирования обычных слайдов хранятся в свойствах просмотра слайдов презентации. Отдельные коллекции линий доступны для мастеров слайдов, макетных слайдов, мастеров заметок и мастеров раздаточных материалов.

**Какие единицы измерения используются для позиций линий?**

Позиции указываются в пунктах, где 72 пункта равны одному дюйму. Вертикальные позиции измеряются от левого края, а горизонтальные позиции — от верхнего края.

**Удаление руководящих линий удаляет ли формы или изменяет содержимое слайда?**

Нет. Метод [DrawingGuidesCollection::clear](https://reference.aspose.com/slides/ru/php-java/aspose.slides/drawingguidescollection/#clear) удаляет только линии в выбранной коллекции. Формы и другое содержимое слайда остаются без изменений.
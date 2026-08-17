---
title: Управление заполнителями презентаций в PHP
linktitle: Управление заполнителями
type: docs
weight: 10
url: /ru/php-java/manage-placeholder/
keywords:
- заполнитель
- текстовый заполнитель
- заполнитель изображения
- заполнитель диаграммы
- заполнитель содержимого
- текст подсказки
- PowerPoint
- презентация
- PHP
- Aspose.Slides
description: "Узнайте, как просматривать и редактировать текстовые, графические, диаграммные и контентные заполнители, а также понять наследование заполнителей с помощью Aspose.Slides для PHP через Java."
---
## **Обзор**

Заполнитель — это фигура, которая резервирует позицию для определённого типа содержимого в шаблоне презентации. Распространённые примеры: заголовок, основной текст, изображение, диаграмма и универсальные заполнители содержимого. В отличие от обычной фигуры, заполнитель может наследовать своё положение, размер, форматирование и другие параметры от слайда‑макета или слайда‑шаблона.

Aspose.Slides предоставляет информацию о заполнителе через метод [Shape::getPlaceholder](https://reference.aspose.com/slides/ru/php-java/aspose.slides/shape/getplaceholder/). Метод возвращает объект [Placeholder](https://reference.aspose.com/slides/ru/php-java/aspose.slides/placeholder/) или `null` для обычной фигуры. Используйте [Placeholder::getType](https://reference.aspose.com/slides/ru/php-java/aspose.slides/placeholder/gettype/), чтобы определить, какой контент предназначен для заполнителя.

Класс фигуры остаётся важным после того, как известен тип заполнителя:

- Пустой текстовый, графический, диаграммный или контентный заполнитель обычно представлен фигурой [AutoShape](https://reference.aspose.com/slides/ru/php-java/aspose.slides/autoshape/).
- Заполненный графический заполнитель может быть представлен объектом [PictureFrame](https://reference.aspose.com/slides/ru/php-java/aspose.slides/pictureframe/).
- Заполненный диаграммный заполнитель может быть представлен объектом [Chart](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chart/).
- Контентный заполнитель может содержать несколько типов содержимого. Проверяйте как [Placeholder::getType](https://reference.aspose.com/slides/ru/php-java/aspose.slides/placeholder/gettype/), так и класс фигуры во время выполнения, а не полагайтесь на то, что каждый заполнитель — это [AutoShape](https://reference.aspose.com/slides/ru/php-java/aspose.slides/autoshape/).

{{% alert color="warning" title="Warning" %}}
[Placeholder::getType](https://reference.aspose.com/slides/ru/php-java/aspose.slides/placeholder/gettype/) описывает роль заполнителя; он не гарантирует класс фигуры во время выполнения. Всегда проверяйте тип перед доступом к成员ам, специфичным для текста, изображения, диаграммы, таблицы или медиа.
{{% /alert %}}

## **Понимание наследования заполнителей**

Заполнители образуют иерархию:

1. Слайд‑шаблон определяет переиспользуемые стили и, в некоторых случаях, заполнители уровня шаблона.
2. Слайд‑макет определяет расположение, используемое одним или несколькими обычными слайдами, и может наследоваться от шаблона.
3. Обычный слайд содержит заполнители для данного слайда и может наследовать их от своего макета.

Вызовите [Shape::getBasePlaceholder](https://reference.aspose.com/slides/ru/php-java/aspose.slides/shape/getbaseplaceholder/), чтобы перейти на один уровень выше в этой иерархии. Заполнитель слайда обычно возвращает свой заполнитель‑макет; заполнитель‑макет может вернуть свой заполнитель‑шаблон. Метод возвращает `null`, когда у фигуры нет базового заполнителя.

Следующий пример выводит заполнители на первом слайде и сообщает их базовые заполнители:

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

Редактирование заполнителя на обычном слайде создаёт или изменяет локальное переопределение для этого слайда. Редактирование связанного макета или шаблона может затронуть все слайды, которые всё ещё наследуют эту настройку. Обычная локальная фигура не имеет базового заполнителя и не начинает наследоваться просто потому, что занимает те же координаты.

## **Изменить текст в заполнительe**

Заполнители заголовка, центрального заголовка, подзаголовка, основного текста и текста обычно поддерживают текст. Проверяйте наличие [AutoShape](https://reference.aspose.com/slides/ru/php-java/aspose.slides/autoshape/) перед использованием её метода [getTextFrame](https://reference.aspose.com/slides/ru/php-java/aspose.slides/autoshape/gettextframe/).

В этом примере обновляется первый заполнитель заголовка на первом слайде и сохраняется результат:

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

Такой подход избегает обработки графических, диаграммных, таблицных или медиа‑заполнителей как объектов [AutoShape](https://reference.aspose.com/slides/ru/php-java/aspose.slides/autoshape/). Он также идентифицирует заполнитель по назначению, а не опирается на хрупкий индекс фигуры.

## **Установить подсказочный текст в макете**

Подсказочный текст — это инструкция, отображаемая в пустом заполнительe во время разработки, например *Нажмите, чтобы добавить заголовок*. Устанавливайте пользовательский подсказочный текст в заполнителье макета, а не через коллекцию фигур обычного слайда. Получите макет через [Slide::getLayoutSlide](https://reference.aspose.com/slides/ru/php-java/aspose.slides/slide/#getLayoutSlide) и пройдитесь по коллекции, возвращаемой [BaseSlide::getShapes](https://reference.aspose.com/slides/ru/php-java/aspose.slides/baseslide/#getShapes).

Следующий пример изменяет подсказки заголовка и подзаголовка в макете, используемом первым слайдом:

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

Подсказочный текст — это не обычный контент слайда. Он предназначен для пустых заполнителей в редактирующих приложениях, таких как PowerPoint. Как только пользователь или программа предоставляют реальное содержимое, подсказка больше не отображается. Изменение подсказки также не заменяет существующий текст на слайдах, использующих этот макет.

## **Обновить графический заполнитель**

Существует два варианта обработки:

- Если графический заполнитель уже заполнен и представлен [PictureFrame](https://reference.aspose.com/slides/ru/php-java/aspose.slides/pictureframe/), замените изображение через [PictureFillFormat::getPicture](https://reference.aspose.com/slides/ru/php-java/aspose.slides/picturefillformat/getpicture/) и [SlidesPicture::setImage](https://reference.aspose.com/slides/ru/php-java/aspose.slides/slidespicture/setimage/).
- Если он всё ещё пуст, добавьте графическую рамку в координатах заполнителя с помощью [ShapeCollection::addPictureFrame](https://reference.aspose.com/slides/ru/php-java/aspose.slides/shapecollection/addpictureframe/) и удалите пустой заполнитель.

Следующий пример поддерживает оба случая и сохраняет презентацию:

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

Замена, созданная для пустого заполнителя, представляет собой локальную графическую рамку, а не новый заполнитель, потому что [Shape::getPlaceholder](https://reference.aspose.com/slides/ru/php-java/aspose.slides/shape/getplaceholder/) не предоставляет сеттера. Она сохраняет зарезервированную позицию, но больше не наследует поведение, специфичное для заполнителя. Если важно сохранить связь с заполнителем, подготовьте и заполните заполнитель в PowerPoint заранее, а затем обновите полученный [PictureFrame](https://reference.aspose.com/slides/ru/php-java/aspose.slides/pictureframe/) с помощью Aspose.Slides.

Для прозрачности изображений, обрезки и других эффектов, специфичных для графики, смотрите раздел [Manage Picture Frames](/slides/ru/php-java/picture-frame/). Эти операции относятся к графической рамке или заполнению изображения, а не к метаданным заполнителя.

## **Работа с диаграммными и контентными заполнителями**

Заполненный диаграммный заполнитель может быть представлен [Chart](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chart/). В этом примере ищется такая диаграмма по типу заполнителя и классу во время выполнения, меняется её заголовок и сохраняется файл:

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

Общий контентный заполнитель обычно имеет тип [PlaceholderType::Object](https://reference.aspose.com/slides/ru/php-java/aspose.slides/placeholdertype/). В PowerPoint он служит «запускателем» для нескольких типов содержимого, включая диаграммы, таблицы, схемы, изображения и медиа. После заполнения проверяйте реальный класс фигуры, чтобы узнать, что она содержит. Специализированные макеты могут также выдавать типы [PlaceholderType::Chart](https://reference.aspose.com/slides/ru/php-java/aspose.slides/placeholdertype/), [PlaceholderType::Table](https://reference.aspose.com/slides/ru/php-java/aspose.slides/placeholdertype/), [PlaceholderType::Picture](https://reference.aspose.com/slides/ru/php-java/aspose.slides/placeholdertype/), [PlaceholderType::Media](https://reference.aspose.com/slides/ru/php-java/aspose.slides/placeholdertype/), или [PlaceholderType::Diagram](https://reference.aspose.com/slides/ru/php-java/aspose.slides/placeholdertype/).

Aspose.Slides не преобразует пустой заполнитель [AutoShape](https://reference.aspose.com/slides/ru/php-java/aspose.slides/autoshape/) в [Chart](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chart/) простым изменением [Placeholder::getType](https://reference.aspose.com/slides/ru/php-java/aspose.slides/placeholder/gettype/); тип нельзя изменить через класс. Чтобы программно заполнить пустую область диаграммы или контента, добавьте требуемый объект в координаты заполнителя и затем удалите пустой заполнитель. Ниже пример для диаграммы:

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

Добавленная диаграмма — это обычная локальная диаграмма. Она занимает область заполнителя, но не наследует свойства макетного заполнителя. Используйте специализированные статьи по управлению [chart management articles](/slides/ru/php-java/powerpoint-charts/), когда нужно заменить категории, серии или данные рабочей книги.

## **Полный пример: обновление текста или изображения**

Следующий сквозной пример открывает шаблон, ищет на первом слайде либо заполнитель заголовка, либо графический заполнитель, проверяет типы заполнителя и фигуры, обновляет соответствующее содержимое и сохраняет результат. Пример намеренно не полагается на индекс фигуры и не рассматривает каждый заполнитель как объект одного класса.

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

**Что такое базовый заполнитель?**

Базовый заполнитель — это соответствующая фигура на макете или шаблоне, от которой наследуется другой заполнитель. Используйте [Shape::getBasePlaceholder](https://reference.aspose.com/slides/ru/php-java/aspose.slides/shape/getbaseplaceholder/), чтобы получить его. Обычная локальная фигура возвращает `null`, потому что она не является частью иерархии заполнителей.

**Можно ли изменить все заголовки слайдов, редактируя заполнитель макета?**

Можно изменить наследуемое форматирование или подсказочный текст через макет, но фактический заголовочный контент хранится на обычных слайдах. Чтобы заменить реальный текст заголовков во всей презентации, пройдитесь по слайдам и обновите каждый заполнитель заголовка.

**Как управлять заполнителями даты, номера слайда, верхнего и нижнего колонтитулов?**

Используйте менеджеры верхнего и нижнего колонтитулов на соответствующем уровне — слайд, макет, шаблон, заметки или раздаточный материал. См. [Manage Presentation Header and Footer](/slides/ru/php-java/presentation-header-and-footer/) для полных примеров.
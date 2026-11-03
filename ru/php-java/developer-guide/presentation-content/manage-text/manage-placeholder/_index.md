---
title: Управление заполнителями презентации в PHP
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
description: "Узнайте, как просматривать и редактировать текстовые, графические, диаграммные и содержательные заполнители, а также понять наследование заполнителей с помощью Aspose.Slides для PHP через Java."
---
## **Обзор**

Заполнитель — это фигура, которая резервирует позицию для определённого типа содержимого в шаблоне презентации. Частыми примерами являются заголовок, основной текст, изображение, диаграмма и заполнитель общего назначения. В отличие от обычной фигуры, заполнитель может наследовать своё положение, размер, форматирование и другие параметры от макетного слайда или слайда‑шаблона.

Aspose.Slides предоставляет информацию о заполнителях через метод [Shape::getPlaceholder](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getplaceholder/). Метод возвращает объект [Placeholder](https://reference.aspose.com/slides/php-java/aspose.slides/placeholder/) или `null` для обычной фигуры. Используйте [Placeholder::getType](https://reference.aspose.com/slides/php-java/aspose.slides/placeholder/gettype/) для определения того, что предполагается разместить в заполнитель.

Класс фигуры всё равно важен после того, как известен тип заполнителя:

- Пустой текстовый, графический, диаграммный или содержательный заполнитель обычно представлен объектом [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/).
- Заполненный графический заполнитель может быть представлен объектом [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/).
- Заполненный диаграммный заполнитель может быть представлен объектом [Chart](https://reference.aspose.com/slides/php-java/aspose.slides/chart/).
- Содержательный заполнитель может содержать несколько типов контента. Проверяйте как [Placeholder::getType](https://reference.aspose.com/slides/php-java/aspose.slides/placeholder/gettype/), так и класс фигуры во время выполнения, а не делайте предположения, что каждый заполнитель — это [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/).

{{% alert color="warning" title="Warning" %}}
[Placeholder::getType](https://reference.aspose.com/slides/php-java/aspose.slides/placeholder/gettype/) описывает роль заполнителя; он не гарантирует класс фигуры во время выполнения. Всегда проверяйте тип перед доступом к членам, специфичным для текста, изображения, диаграммы, таблицы или медиа.
{{% /alert %}}

## **Понимание наследования заполнителей**

Заполнители образуют иерархию:

1. Слайд‑шаблон определяет переиспользуемые стили и, в некоторых случаях, заполнители уровня шаблона.
2. Макетный слайд определяет расположение, используемое одним или несколькими обычными слайдами, и может наследоваться от шаблона.
3. Обычный слайд содержит заполнители для этого слайда и может наследоваться от своего макета.

Вызовите [Shape::getBasePlaceholder](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getbaseplaceholder/) для перехода на один уровень выше в этой иерархии. Заполнитель обычного слайда обычно возвращает свой макетный заполнитель; макетный заполнитель может вернуть свой шаблонный заполнитель. Метод возвращает `null`, когда у фигуры нет базового заполнителя.

Следующий пример выводит заполнители первого слайда и их базовые заполнители:

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

Редактирование заполнителя на обычном слайде создаёт или изменяет локальное переопределение для этого слайда. Редактирование соответствующего макета или шаблона может затронуть все слайды, которые всё ещё наследуют эту настройку. Обычная локальная фигура не имеет базового заполнителя и не начинает наследовать лишь потому, что занимает те же координаты.

## **Удаление статуса заполнителя**

При адаптации шаблона используйте [Shape::removePlaceholder](https://reference.aspose.com/slides/php-java/aspose.slides/shape/removeplaceholder/) для сохранения существующего объекта как обычной фигуры. Его метод [getPlaceholder](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getplaceholder/) возвращает `null`, но фигура остаётся в коллекции слайда. В отличие от этого, [ShapeCollection::remove](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/remove/) удаляет фигуру из этой коллекции.

Следующий пример требует файл `template.pptx` с хотя бы одним слайдом и непустым текстовым заполнителем на первом слайде. Используйте заполнитель с форматированием, наследованным от макета или шаблона, чтобы увидеть эффект удаления этой связи. Пример проверяет, что та же фигура остаётся, вызывает метод ещё раз для теперь уже обычной фигуры и сохраняет результат.

{{% alert color="warning" title="Warning" %}}
Удаление статуса заполнителя не сохраняет автоматически унаследованные параметры внешнего вида. В примере ниже эти параметры намеренно оставлены без изменений, поэтому результат может выглядеть иначе. Фигура, чьи позиция и размер полностью наследованы, может после вызова иметь нулевые координаты и размеры и стать невидимой, хотя остаётся в коллекции.
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

        // Вызов метода у обычной фигуры не имеет эффекта.
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

Для соответствующего заполнителя все три проверки выводят `true`. Текст остаётся, но унаследованные позиция, размер, вращение, шрифт, выравнивание абзаца, отступы текстового фрейма, вертикальная привязка, заливка и параметры линии могут измениться после снятия связи заполнителя. Например, унаследованное форматирование заголовка может вернуться к обычному текстовому формату. Подробнее о макетах см. в статье [Slide Layout](/slides/ru/php-java/slide-layout/).

Чтобы сохранить желаемый внешний вид, зафиксируйте разрешённые позицию, размер и вращение до вызова и скопируйте требуемые эффективные значения форматирования в отдельные переменные. Получить их можно через [PortionFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/portionformat/geteffective/), [ParagraphFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/geteffective/), [TextFrameFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/geteffective/), [FillFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/geteffective/), и [LineFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/geteffective/). Не полагайтесь только на объекты эффективного форматирования, так как их значения могут измениться после удаления связи. Явно примените зафиксированные значения к обычной фигуре позже, включая семейство шрифта, размер, стиль, цвет, параметры абзаца, настройки текстового фрейма, заливку и линию, используемые в вашем шаблоне.

Унаследованную геометрию фигуры также может потребоваться задать явно через [GeometryShape::setShapeType](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setShapeType). Для прямоугольного текстового заполнителя это означает назначить [ShapeType::Rectangle](https://reference.aspose.com/slides/php-java/aspose.slides/shapetype/); простое восстановление только заливки и линии может не вернуть видимый прямоугольник. Шаблоны с дополнительными эффектами или более сложным форматированием требуют обработки и этих параметров.

## **Изменение текста в заполнителе**

Заполнители заголовка, центрированного заголовка, подзаголовка, основного текста и обычного текста обычно поддерживают текст. Перед использованием метода [getTextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/gettextframe/) проверьте, что это [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/).

Следующий пример обновляет первый заголовочный заполнитель на первом слайде и сохраняет результат:

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

Этот шаблон избегает обращения к заполнителям изображений, диаграмм, таблиц или медиа как к объектам [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/). Он также идентифицирует заполнитель по назначению, а не полагается на хрупкий индекс фигуры.

## **Установка текста‑подсказки в макете**

Текст‑подсказка — это инструкция, отображаемая в пустом заполнителе во время разработки, например *Нажмите, чтобы добавить заголовок*. Задайте пользовательскую подсказку в заполнителе макета, а не пытайтесь достать её через обычную коллекцию фигур слайда. Доступ к макету получайте через [Slide::getLayoutSlide](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getLayoutSlide) и перебирайте коллекцию, возвращаемую [BaseSlide::getShapes](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getShapes).

Следующий пример меняет подсказки заголовка и подзаголовка в макете, используемом первым слайдом:

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

Текст‑подсказка — это не обычное содержимое слайда. Он предназначен для пустых заполнителей в приложениях редактирования, таких как PowerPoint. После того как пользователь или программа вставит реальное содержимое, подсказка перестаёт отображаться. Изменение подсказки также не заменяет существующий текст на слайдах, использующих данный макет.

## **Обновление графического заполнителя**

Есть два случая:

- Если графический заполнитель уже заполнен и представлен объектом [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/), замените изображение через [PictureFillFormat::getPicture](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/getpicture/) и [Picture::setImage](https://reference.aspose.com/slides/php-java/aspose.slides/picture/#setImage).
- Если это всё ещё пустой заполнитель, добавьте графический фрейм в координаты заполнителя через [ShapeCollection::addPictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addpictureframe/) и удалите пустой заполнитель.

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

Замена, созданная для пустого заполнителя, — локальный графический фрейм, а не новый заполнитель, потому что [Shape::getPlaceholder](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getplaceholder/) не предоставляет сеттер. Он сохраняет зарезервированную позицию, но больше не наследует поведение заполняемого элемента. Если сохранение связи заполнителя критично, подготовьте и заполните заполнитель в PowerPoint сначала, а затем обновите полученный [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/) с помощью Aspose.Slides.

Для прозрачности изображения, обрезки и других эффектов, специфичных для графики, см. статью [Manage Picture Frames](/slides/ru/php-java/picture-frame/). Эти операции относятся к графическому фрейму или заполнению, а не к метаданным заполнителя.

## **Работа с диаграммными и содержательными заполнителями**

Заполненный диаграммный заполнитель может быть представлен объектом [Chart](https://reference.aspose.com/slides/php-java/aspose.slides/chart/). Этот пример ищет такую диаграмму по типу заполнителя и классу выполнения, изменяет её заголовок и сохраняет файл:

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

Обычный содержательный заполнитель обычно имеет тип [PlaceholderType::Object](https://reference.aspose.com/slides/php-java/aspose.slides/placeholdertype/). В PowerPoint он выступает в роли запуска для нескольких типов контента, включая диаграммы, таблицы, схемы, изображения и медиа. После заполнения проверьте реальный класс фигуры, чтобы узнать, что она содержит. Специализированные макеты могут также предоставлять [PlaceholderType::Chart](https://reference.aspose.com/slides/php-java/aspose.slides/placeholdertype/), [PlaceholderType::Table](https://reference.aspose.com/slides/php-java/aspose.slides/placeholdertype/), [PlaceholderType::Picture](https://reference.aspose.com/slides/php-java/aspose.slides/placeholdertype/), [PlaceholderType::Media](https://reference.aspose.com/slides/php-java/aspose.slides/placeholdertype/), или [PlaceholderType::Diagram](https://reference.aspose.com/slides/php-java/aspose.slides/placeholdertype/).

Aspose.Slides не преобразует пустой [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/)‑заполнитель в [Chart](https://reference.aspose.com/slides/php-java/aspose.slides/chart/) простым изменением [Placeholder::getType](https://reference.aspose.com/slides/php-java/aspose.slides/placeholder/gettype/); тип нельзя изменить через класс. Чтобы программно заполнить пустую диаграмму или область содержимого, добавьте требуемый объект в координаты заполнителя, а затем удалите пустой заполнитель. Следующий пример делает это для диаграммы:

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

Добавленная диаграмма — обычная локальная диаграмма. Она занимает область заполнителя, но не наследует параметры от макетного заполнителя. При необходимости заменить категории, серии или данные книги используйте специализированные статьи по управлению [диаграммами](/slides/ru/php-java/powerpoint-charts/).

## **Полный пример: обновление текста или изображения**

Следующий сквозной пример открывает шаблон, ищет на первом слайде либо заголовочный, либо графический заполнитель, проверяет типы заполнителя и фигуры, обновляет соответствующее содержимое и сохраняет результат. Пример специально избегает предположений о индексе фигуры или о том, что каждый заполнитель принадлежит к одному и тому же классу.

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

Базовый заполнитель — это соответствующая фигура на макете или шаблоне, от которой другой заполнитель наследует свойства. Используйте [Shape::getBasePlaceholder](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getbaseplaceholder/) для его получения. Обычная локальная фигура возвращает `null`, потому что она не является частью иерархии заполнителей.

**Могу ли я изменить все заголовки слайдов, редактируя заполнитель макета?**

Вы можете изменить унаследованное форматирование или текст‑подсказку через макет, но фактическое содержимое заголовков хранится на обычных слайдах. Чтобы заменить реальный текст заголовков во всей презентации, перебирайте слайды и обновляйте каждый заголовочный заполнитель.

**Как управлять заполнителями даты, номера слайда, верхнего/нижнего колонтитула?**

Используйте менеджеры верхних и нижних колонтитулов в соответствующей области: слайд, макет, шаблон, заметки или раздаточный материал. См. статью [Manage Presentation Header and Footer](/slides/ru/php-java/presentation-header-and-footer/) для полных примеров.
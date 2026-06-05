---
title: Управление мастер‑слайдами презентации в PHP
linktitle: Мастер‑слайд
type: docs
weight: 70
url: /ru/php-java/slide-master/
keywords:
- мастер‑слайд
- мастер‑слайд
- PPT-мастер‑слайд
- множество мастер‑слайдов
- сравнение мастер‑слайдов
- фон
- заполнитель
- клонирование мастер‑слайда
- копирование мастер‑слайда
- дублирование мастер‑слайда
- неиспользуемый мастер‑слайд
- PowerPoint
- OpenDocument
- презентация
- PHP
- Aspose.Slides
description: "Управление мастер‑слайдами в Aspose.Slides для PHP через Java: доступ, редактирование, клонирование, сравнение и удаление мастер‑слайдов в презентациях PowerPoint и OpenDocument."
---
## **Обзор**

**Слайд‑мастер** определяет общие настройки дизайна для группы слайдов. Он может содержать общие фигуры, логотипы, фон, стили текста, параметры темы и параметры нижнего колонтитула. В PowerPoint редактирование слайд‑мастера — обычный способ поддерживать презентацию в едином стиле без повторения одинакового форматирования на каждом слайде.

Aspose.Slides for PHP via Java поддерживает ту же модель. Презентация может содержать один или несколько мастер‑слайдов, каждый из которых может включать несколько слайдов‑разметки. Обычные слайды обычно не ссылаются напрямую на мастер‑слайд. Вместо этого обычный слайд использует слайд‑разметку, а эта разметка принадлежит мастер‑слайду.

Иерархия выглядит так:

1. **Слайд‑мастер** – определяет общий дизайн и тему.  
1. **Слайд‑разметка** – определяет конкретное расположение заполнителей и форматирование уровня разметки.  
1. **Обычный слайд** – содержит фактическое содержимое презентации и использует одну слайд‑разметку.

![Иерархия мастер‑слайдов, слайдов‑разметки и обычных слайдов](slide-master_2.jpg)

В Aspose.Slides слайд‑мастер представлен классом [MasterSlide](https://reference.aspose.com/slides/ru/php-java/aspose.slides/masterslide/). Все мастер‑слайды в презентации доступны через метод [Presentation.getMasters](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/#getMasters), который возвращает объект [MasterSlideCollection](https://reference.aspose.com/slides/ru/php-java/aspose.slides/masterslidecollection/).

{{% alert color="info" title="Inheritance" %}}
Когда одно и то же свойство определено на нескольких уровнях, более конкретный уровень имеет приоритет. Например, если мастер‑слайд и слайд‑разметка оба задают фон, слайды, основанные на этой разметке, используют фон разметки. Подробнее о слайдах‑разметке см. в статье [Apply or Change Slide Layouts](/slides/ru/php-java/slide-layout/).
{{% /alert %}}

## **Доступ к мастер‑слайдам**

В PowerPoint вы можете открыть режим просмотра Слайд‑мастер через **View** > **Slide Master**.

![Команда Слайд‑мастер на вкладке Вид в PowerPoint](slide-master_3.jpg)

В Aspose.Slides используйте метод `getMasters` для доступа к мастер‑слайдам:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $firstMasterSlide = $presentation->getMasters()->get_Item(0);
    $masterSlideCount = $presentation->getMasters()->size();
    $firstMasterLayoutSlideCount = $firstMasterSlide->getLayoutSlides()->size();

    echo "Master slides: " . $masterSlideCount . PHP_EOL;
    echo "Layouts in the first master: " . $firstMasterLayoutSlideCount . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

Также можно получить мастер‑слайд, используемый обычным слайдом, через его разметку:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $layoutSlide = $slide->getLayoutSlide();
    $masterSlide = $layoutSlide->getMasterSlide();
    $masterSlideName = $masterSlide->getName();

    echo $masterSlideName . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **Что содержит мастер‑слайд**

Мастер‑слайд — объект, похожий на обычный слайд. Он наследует [BaseSlide](https://reference.aspose.com/slides/ru/php-java/aspose.slides/baseslide/), поэтому предоставляет многие из тех же свойств, что и обычные и разметочные слайды. Специфичные для мастера члены перечислены на странице API [MasterSlide](https://reference.aspose.com/slides/ru/php-java/aspose.slides/masterslide/).

Часто используемые члены мастер‑слайда:

| Элемент | Назначение |
| --- | --- |
| `getBackground` | Устанавливает фон уровня мастера. |
| `getShapes` | Хранит фигуры, размещённые на мастере, такие как логотипы, рамки изображений и общий текст. |
| `getLayoutSlides` | Хранит слайды‑разметки, принадлежащие мастеру. |
| `getThemeManager` | Предоставляет доступ к API темы мастера. |
| `getHeaderFooterManager` | Управляет верхними и нижними колонтитулами, датами и номерами слайдов для мастера и его дочерних разметок. |
| `getDependingSlides` | Возвращает обычные слайды, зависящие от мастера через их разметки. |

## **Добавление изображения в мастер‑слайд**

Когда вы добавляете изображение в мастер‑слайд, оно появляется на слайдах, использующих разметки этого мастера. Это удобно для логотипов, водяных знаков, декоративных полос и других повторяющихся визуальных элементов.

Следующий пример добавляет логотип на первый мастер‑слайд:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $masterSlide = $presentation->getMasters()->get_Item(0);
    $logoImage = Images::fromFile("logo.png");
    try {
        $presentationImage = $presentation->getImages()->addImage($logoImage);
    } finally {
        $logoImage->dispose();
    }

    $masterSlide->getShapes()->addPictureFrame(
        ShapeType::Rectangle,
        20,
        20,
        80,
        80,
        $presentationImage
    );

    $presentation->save("presentation-with-logo.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Подробнее о рамках изображений см. в статье [Picture Frame](/slides/ru/php-java/picture-frame/).

## **Работа с заполнителями**

Заполнители обычно определяются на слайдах‑разметке. Мастер‑слайд предоставляет общий стиль и тему, которые наследуют эти разметки, а каждая разметка решает, какие заполнители доступны и где они расположены.

В PowerPoint команды заполнителей доступны в режиме просмотра Слайд‑мастер.

![Команда Вставить заполнитель в режиме Слайд‑мастер PowerPoint](slide-master_5.png)

Чтобы добавить новые заполнители с помощью Aspose.Slides, работайте с слайдом‑разметкой, принадлежащим мастеру:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $masterSlide = $presentation->getMasters()->get_Item(0);
    $blankLayoutSlideName = "Custom Blank";
    $blankLayoutSlide = $masterSlide->getLayoutSlides()->add(
        SlideLayoutType::Blank,
        $blankLayoutSlideName
    );

    $blankLayoutSlide->getPlaceholderManager()->addTextPlaceholder(
        60,
        120,
        600,
        80
    );

    $presentation->getSlides()->addEmptySlide($blankLayoutSlide);
    $presentation->save("presentation-with-placeholder.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Также можно форматировать фигуры заполнителей, уже существующие на мастере. В следующем примере находится заполнитель заголовка и применяется линейная градиентная заливка:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $masterSlide = $presentation->getMasters()->get_Item(0);
    $titlePlaceholder = findPlaceholder($masterSlide, PlaceholderType::Title);

    if (!java_is_null($titlePlaceholder)) {
        $redGradientColor = java("java.awt.Color")->RED;
        $purpleGradientColor = new Java("java.awt.Color", 128, 0, 128);

        $fillFormat = $titlePlaceholder->getFillFormat();
        $fillFormat->setFillType(FillType::Gradient);
        $gradientFormat = $fillFormat->getGradientFormat();
        $gradientFormat->setGradientShape(GradientShape::Linear);
        $gradientStops = $gradientFormat->getGradientStops();
        $gradientStops->add(0, $redGradientColor);
        $gradientStops->add(255, $purpleGradientColor);
    }

    $presentation->save("presentation-title-style.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}

function findPlaceholder($masterSlide, $placeholderType)
{
    $shapesCount = java_values($masterSlide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapesCount; $shapeIndex++) {
        $shape = $masterSlide->getShapes()->get_Item($shapeIndex);
        $placeholder = $shape->getPlaceholder();

        if (!java_is_null($placeholder) && java_values($placeholder->getType()) == $placeholderType) {
            return $shape;
        }
    }

    return null;
}
```

![Отформатированный заполнитель заголовка, унаследованный обычными слайдами](slide-master_8.png)

Больше вариантов форматирования заполнителей и текста см. в статьях [Set Prompt Text in Placeholder](/slides/ru/php-java/manage-placeholder/) и [Text Formatting](/slides/ru/php-java/text-formatting/).

## **Изменение фона мастер‑слайда**

Фон мастера наследуется разметками и слайдами, которые его не переопределяют. Ниже пример установки сплошного фонового цвета для первого мастер‑слайда:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $masterSlide = $presentation->getMasters()->get_Item(0);
    $forestGreenColor = new Java("java.awt.Color", 34, 139, 34);

    $background = $masterSlide->getBackground();
    $background->setType(BackgroundType::OwnBackground);
    $fillFormat = $background->getFillFormat();
    $fillFormat->setFillType(FillType::Solid);
    $fillFormat->getSolidFillColor()->setColor($forestGreenColor);

    $presentation->save("presentation-master-background.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Связанные темы см. в [Presentation Background](/slides/ru/php-java/presentation-background/) и [Presentation Theme](/slides/ru/php-java/presentation-theme/).

## **Клонирование мастер‑слайда в другую презентацию**

Используйте `addClone` из [MasterSlideCollection](https://reference.aspose.com/slides/ru/php-java/aspose.slides/masterslidecollection/) для копирования мастер‑слайда в другую презентацию. Скопированный мастер затем может использоваться разметками и слайдами в целевой презентации.

```php
$sourcePresentation = new Presentation("source.pptx");
$destinationPresentation = new Presentation("destination.pptx");
try {
    $sourceMasterSlide = $sourcePresentation->getMasters()->get_Item(0);
    $clonedMasterSlide = $destinationPresentation->getMasters()->addClone($sourceMasterSlide);

    $destinationPresentation->save("destination-with-master.pptx", SaveFormat::Pptx);
} finally {
    $destinationPresentation->dispose();
    $sourcePresentation->dispose();
}
```

Если необходимо клонировать обычные слайды вместе с их мастером, см. в статье [Clone Slides](/slides/ru/php-java/clone-slides/).

## **Добавление нескольких мастер‑слайдов**

Презентация может содержать несколько мастер‑слайдов. Это полезно, когда разные разделы требуют различного брендинга, структуры страниц или параметров темы.

![Команды PowerPoint для вставки и управления мастер‑слайдами](slide-master_9.jpg)

Следующий пример клонирует мастер‑слайд по умолчанию, задаёт клону иной фон, создаёт разметку под этим клоном и добавляет новый слайд на основе этой разметки:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $defaultMasterSlide = $presentation->getMasters()->get_Item(0);
    $sectionMasterSlide = $presentation->getMasters()->addClone($defaultMasterSlide);
    $lightSteelBlueColor = new Java("java.awt.Color", 176, 196, 222);

    $background = $sectionMasterSlide->getBackground();
    $background->setType(BackgroundType::OwnBackground);
    $fillFormat = $background->getFillFormat();
    $fillFormat->setFillType(FillType::Solid);
    $fillFormat->getSolidFillColor()->setColor($lightSteelBlueColor);

    $sourceBlankLayout = $defaultMasterSlide->getLayoutSlides()->get_Item(0);
    $sectionBlankLayout = $sectionMasterSlide->getLayoutSlides()->addClone($sourceBlankLayout);

    $presentation->getSlides()->addEmptySlide($sectionBlankLayout);
    $presentation->save("presentation-with-multiple-masters.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Сравнение мастер‑слайдов**

Мастер‑слайды можно сравнивать с помощью метода `equals`, унаследованного от [BaseSlide](https://reference.aspose.com/slides/ru/php-java/aspose.slides/baseslide/). Сравнение проверяет структуру и статическое содержание, такие как фигуры, текст, форматирование, анимации и другие параметры слайдов. Оно не сравнивает уникальные идентификаторы, например ID слайдов, или динамические значения заполнителей, такие как текущая дата.

```php
$firstPresentation = new Presentation("first.pptx");
$secondPresentation = new Presentation("second.pptx");
try {
    $firstPresentationMasterCount = java_values($firstPresentation->getMasters()->size());
    $secondPresentationMasterCount = java_values($secondPresentation->getMasters()->size());

    for ($firstMasterIndex = 0; $firstMasterIndex < $firstPresentationMasterCount; $firstMasterIndex++) {
        for ($secondMasterIndex = 0; $secondMasterIndex < $secondPresentationMasterCount; $secondMasterIndex++) {
            $firstMasterSlide = $firstPresentation->getMasters()->get_Item($firstMasterIndex);
            $secondMasterSlide = $secondPresentation->getMasters()->get_Item($secondMasterIndex);
            $areMasterSlidesEqual = $firstMasterSlide->equals($secondMasterSlide);

            if ($areMasterSlidesEqual) {
                echo "first.pptx master #" . $firstMasterIndex .
                    " equals second.pptx master #" . $secondMasterIndex . PHP_EOL;
            }
        }
    }
} finally {
    $secondPresentation->dispose();
    $firstPresentation->dispose();
}
```

Подробнее см. в статье [Compare Presentation Slides](/slides/ru/php-java/compare-slides/).

## **Установка режима мастер‑слайда как представление по умолчанию**

Используйте метод `setLastView` у [ViewProperties](https://reference.aspose.com/slides/ru/php-java/aspose.slides/viewproperties/) для управления тем, какое представление PowerPoint открывает первым. Ниже пример открытия презентации в режиме Слайд‑мастер:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $presentation->getViewProperties()->setLastView(ViewType::SlideMasterView);
    $presentation->save("presentation-master-view.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Больше параметров просмотра см. в статье [Save Presentation](/slides/ru/php-java/save-presentation/).

## **Удаление неиспользуемых мастер‑слайдов**

Иногда презентации содержат мастер‑слайды, которые больше не используются ни одним обычным слайдом. Удаление таких мастеров может уменьшить размер файла и упростить обслуживание шаблона.

Вызовите `removeUnused` из [MasterSlideCollection](https://reference.aspose.com/slides/ru/php-java/aspose.slides/masterslidecollection/) для удаления неиспользуемых мастеров из коллекции `getMasters`:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $presentation->getMasters()->removeUnused(true);
    $presentation->save("presentation-clean.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Можно также воспользоваться методом низкого кода `removeUnusedMasterSlides` из класса [Compress](https://reference.aspose.com/slides/ru/php-java/aspose.slides/compress/):

```php
$presentation = new Presentation("presentation.pptx");
try {
    Compress::removeUnusedMasterSlides($presentation);
    $presentation->save("presentation-clean.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**В чём разница между мастер‑слайдом и слайдом‑разметкой?**  
Мастер‑слайд определяет общие настройки дизайна, такие как тема, фон, общие фигуры и стили текста. Слайд‑разметка принадлежит мастер‑слайду и задаёт конкретное расположение заполнителей. Обычный слайд использует слайд‑разметку, поэтому наследует свойства как разметки, так и мастера.

**Может ли одна презентация содержать несколько мастер‑слайдов?**  
Да. Презентация может включать несколько мастер‑слайдов. Используйте несколько мастеров, когда разные разделы требуют различных визуальных систем или брендинга.

**Куда лучше добавлять заполнители: в мастер‑слайд или в слайд‑разметку?**  
В большинстве случаев добавляйте заполнители в слайды‑разметку. Общие визуальные элементы и общие форматы размещайте на мастер‑слайде, а заполнительные области контента — на разметках, которые будут использовать обычные слайды.

**Можно ли удалить мастер‑слайд, который ещё используется?**  
Нет. Мастер‑слайд, имеющий зависимые слайды, нельзя безопасно удалить напрямую. Сначала переместите эти слайды к разметкам другого мастера или воспользуйтесь методом очистки, который удалит только неиспользуемые мастеры.
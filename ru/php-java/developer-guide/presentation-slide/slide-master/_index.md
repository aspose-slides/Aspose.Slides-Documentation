---
title: Управление мастер-слайдами презентации в PHP
linktitle: Мастер-слайд
type: docs
weight: 70
url: /ru/php-java/slide-master/
keywords:
- мастер слайда
- мастер-слайд
- PPT мастер-слайд
- несколько мастер-слайдов
- сравнение мастер-слайдов
- фон
- заполнитель
- клонирование мастер-слайда
- копирование мастер-слайда
- дублирование мастер-слайда
- неиспользуемый мастер-слайд
- PowerPoint
- OpenDocument
- презентация
- PHP
- Aspose.Slides
description: "Управляйте мастер-слайдами в Aspose.Slides for PHP via Java: доступ, редактирование, клонирование, сравнение и удаление мастер-слайдов в презентациях PowerPoint и OpenDocument."
---
## **Обзор**

**Мастер‑слайд** определяет общие параметры дизайна для группы слайдов. Он может содержать общие формы, логотипы, фоны, стили текста, настройки темы и нижних колонтитулов. В PowerPoint редактирование мастер‑слайда — обычный способ поддерживать презентацию в едином стиле без повторения одинакового форматирования на каждом слайде.

Aspose.Slides for PHP via Java поддерживает ту же модель. Презентация может содержать один или несколько мастер‑слайдов, каждый из которых может содержать несколько шаблонных слайдов. Обычные слайды обычно не ссылаются напрямую на мастер‑слайд. Вместо этого обычный слайд использует шаблонный слайд, а этот шаблонный слайд принадлежит мастер‑слайду.

Иерархия выглядит так:

1. **Мастер‑слайд** — определяет общий дизайн и тему.  
1. **Шаблонный слайд** — определяет конкретное расположение заполнителей и форматирование уровня шаблона.  
1. **Обычный слайд** — содержит фактическое содержимое презентации и использует один шаблонный слайд.

![Иерархия мастер‑слайдов, шаблонных слайдов и обычных слайдов](slide-master_2.jpg)

В Aspose.Slides мастер‑слайд представлен классом [MasterSlide](https://reference.aspose.com/slides/ru/php-java/aspose.slides/masterslide/). Все мастер‑слайды в презентации доступны через метод [Presentation.getMasters](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/#getMasters), который возвращает объект [MasterSlideCollection](https://reference.aspose.com/slides/ru/php-java/aspose.slides/masterslidecollection/).

{{% alert color="info" title="Inheritance" %}}
Когда одно и то же свойство определено на нескольких уровнях, приоритет имеет более специфичный уровень. Например, если мастер‑слайд и шаблонный слайд оба задают фон, слайды, основанные на этом шаблоне, используют фон шаблона. Подробнее о шаблонных слайдах см. в разделе [Применить или изменить макет слайдов](/slides/ru/php-java/slide-layout/).
{{% /alert %}}

## **Доступ к мастер‑слайдам**

В PowerPoint можно открыть режим просмотра мастер‑слайда через **Вид** > **Мастер‑слайды**.

![Команда Мастер‑слайд на вкладке Вид в PowerPoint](slide-master_3.jpg)

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

Также можно получить мастер‑слайд, используемый обычным слайдом, через его шаблон:

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

Мастер‑слайд — объект, похожий на обычный слайд. Он наследует [BaseSlide](https://reference.aspose.com/slides/ru/php-java/aspose.slides/baseslide/), поэтому предоставляет многие из тех же свойств слайда, которые используются обычными и шаблонными слайдами. Специфичные для мастера члены перечислены на странице API [MasterSlide](https://reference.aspose.com/slides/ru/php-java/aspose.slides/masterslide/).

Часто используемые члены мастер‑слайда включают:

| Член | Назначение |
| --- | --- |
| `getBackground` | Задает фон на уровне мастер‑слайда. |
| `getShapes` | Содержит формы, размещённые на мастере, такие как логотипы, рамки изображений и общий текст. |
| `getLayoutSlides` | Содержит шаблонные слайды, принадлежащие мастеру. |
| `getThemeManager` | Предоставляет доступ к API темы мастера. |
| `getHeaderFooterManager` | Управляет заголовками, колонтитулами, датами и номерами слайдов для мастера и его дочерних шаблонов. |
| `getDependingSlides` | Возвращает обычные слайды, зависящие от мастера через их шаблоны. |

## **Добавление изображения в мастер‑слайд**

Когда вы добавляете изображение в мастер‑слайд, оно появляется на слайдах, использующих шаблоны этого мастера. Это удобно для логотипов, водяных знаков, декоративных полос и других повторяющихся визуальных элементов.

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

Подробнее о рамках изображений см. в разделе [Рамка изображения](/slides/ru/php-java/picture-frame/).

## **Управление видимостью графики мастера**

Используйте [BaseSlide::setShowMasterShapes](https://reference.aspose.com/slides/ru/php-java/aspose.slides/baseslide/#setShowMasterShapes), чтобы скрыть унаследованную графику мастера, такую как логотипы или декоративные формы, без их удаления из мастера. Передайте `false` в [Slide::setShowMasterShapes](https://reference.aspose.com/slides/ru/php-java/aspose.slides/slide/#setShowMasterShapes) на слайде, где нужно скрыть эту графику, и оставьте `true` на слайдах, где её следует отображать.

Следующий автономный пример создаёт синюю декоративную полосу на мастере и два слайда, использующие один и тот же пустой шаблон. Полоса видна на первом слайде и скрыта на втором. Входная презентация или изображение не требуются.

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideLayoutType;

$presentation = new Presentation();
try {
    $masterSlide = $presentation->getMasters()->get_Item(0);
    $layoutSlide = $masterSlide->getLayoutSlides()->getByType(SlideLayoutType::Blank);
    $layoutSlide->setShowMasterShapes(true);

    $slideHeight = java_values($presentation->getSlideSize()->getSize()->getHeight());
    $band = $masterSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 0, 0, 60, $slideHeight);
    $bandColor = new Java("java.awt.Color", 70, 130, 180);
    $band->getFillFormat()->setFillType(FillType::Solid);
    $band->getFillFormat()->getSolidFillColor()->setColor($bandColor);
    $band->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);

    $visibleSlide = $presentation->getSlides()->get_Item(0);
    $visibleSlide->setLayoutSlide($layoutSlide);
    $visibleSlide->getShapes()->clear();

    $hiddenSlide = $presentation->getSlides()->addEmptySlide($layoutSlide);

    $visibleSlide->setShowMasterShapes(true);
    $hiddenSlide->setShowMasterShapes(false);

    $presentation->save("master-graphics.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Пример использует шаблон **Blank**, поставляемый с новой презентацией, и удаляет собственные заполнители начального слайда.

### **Выбор области применения настройки**

Обычный слайд использует свой мастер через [Slide::getLayoutSlide](https://reference.aspose.com/slides/ru/php-java/aspose.slides/slide/#getLayoutSlide) и [LayoutSlide::getMasterSlide](https://reference.aspose.com/slides/ru/php-java/aspose.slides/layoutslide/#getMasterSlide). Установка свойства на отдельном слайде влияет только на него. Передача `false` в [LayoutSlide::setShowMasterShapes](https://reference.aspose.com/slides/ru/php-java/aspose.slides/layoutslide/#setShowMasterShapes) скрывает графику мастера для всех слайдов, использующих этот общий шаблон, даже если их собственная настройка `true`. Чтобы скрыть графику только на одном слайде, измените свойство самого слайда и оставьте общий шаблон без изменений.

Настройка не поддерживается как управление видимостью непосредственно на мастер‑слайде. На мастере [getShowMasterShapes](https://reference.aspose.com/slides/ru/php-java/aspose.slides/masterslide/#getShowMasterShapes) всегда возвращает `false`, а передача `true` в [setShowMasterShapes](https://reference.aspose.com/slides/ru/php-java/aspose.slides/masterslide/#setShowMasterShapes) вызывает исключение. Применяйте её к обычному слайду или к шаблону.

### **Отличие графики от фона**

| Операция | Эффект |
| --- | --- |
| Скрыть графику мастера | Управляет видимостью унаследованных форм мастера без их удаления или изменения собственных форм слайда. |
| Изменить заливку фона слайда | Меняет цвет, градиент или изображение фона. Графика мастера — отдельные формы и может оставаться видимой над этим фоном. См. [Фон презентации](/slides/ru/php-java/presentation-background/). |
| Удалить форму из мастера | Удаляет общую форму‑источник, поэтому она больше недоступна ни одному слайду, использующему этот мастер. |

## **Работа с заполнителями**

Заполнители обычно определяются на шаблонных слайдах. Мастер‑слайд предоставляет общий стиль и тему, которые наследуют эти шаблоны, а каждый шаблон решает, какие заполнители доступны и где они расположены.

В PowerPoint команды заполнителей доступны в режиме просмотра мастер‑слайда.

![Команда Вставить заполнитель в режиме просмотра мастер‑слайдов PowerPoint](slide-master_5.png)

Чтобы добавить новые заполнители с помощью Aspose.Slides, работайте с шаблонным слайдом, принадлежащим мастеру:

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

Вы также можете форматировать уже существующие формы заполнителей на мастер‑слайде. В следующем примере находится заполнитель заголовка и применяется линейная градиентная заливка:

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

![Отформатированный заголовок‑заполнитель, унаследованный обычными слайдами](slide-master_8.png)

Более подробные параметры заполнителей и форматирования текста см. в разделах [Установить подсказочный текст в заполнителе](/slides/ru/php-java/manage-placeholder/) и [Форматирование текста](/slides/ru/php-java/text-formatting/).

## **Изменение фона мастер‑слайда**

Фон мастера наследуется шаблонами и слайдами, если они не переопределяют его. Следующий пример задаёт сплошной цвет фона для первого мастер‑слайда:

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

См. также разделы [Фон презентации](/slides/ru/php-java/presentation-background/) и [Тема презентации](/slides/ru/php-java/presentation-theme/).

## **Клонирование мастер‑слайда в другую презентацию**

Используйте `addClone` из [MasterSlideCollection](https://reference.aspose.com/slides/ru/php-java/aspose.slides/masterslidecollection/) для копирования мастер‑слайда в другую презентацию. Скопированный мастер затем может использоваться шаблонами и слайдами в целевой презентации.

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

Если нужно клонировать обычные слайды вместе с их мастером, см. раздел [Клонирование слайдов](/slides/ru/php-java/clone-slides/).

## **Добавление нескольких мастер‑слайдов**

Презентация может содержать несколько мастер‑слайдов. Это полезно, когда разные разделы требуют разного брендинга, структуры страниц или настроек темы.

![Команды PowerPoint для вставки и управления мастер‑слайдами](slide-master_9.jpg)

Следующий пример клонирует мастер‑слайд по умолчанию, задаёт клону другой фон, создаёт шаблон под этим клонированным мастером и добавляет новый слайд на основе этого шаблона:

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

Мастер‑слайды можно сравнивать с помощью метода `equals`, унаследованного от [BaseSlide](https://reference.aspose.com/slides/ru/php-java/aspose.slides/baseslide/). Сравнение проверяет структуру и статическое содержимое, такое как формы, текст, форматирование, анимацию и другие параметры слайда. Оно не сравнивает уникальные идентификаторы, например ID слайдов, или динамические значения заполнителей, такие как текущая дата.

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

Подробнее см. в разделе [Сравнение слайдов презентации](/slides/ru/php-java/compare-slides/).

## **Установка просмотра мастер‑слайда как представления по умолчанию**

Используйте метод `setLastView` класса [ViewProperties](https://reference.aspose.com/slides/ru/php-java/aspose.slides/viewproperties/) для управления тем, какое представление PowerPoint открывает первым. Следующий пример открывает презентацию в режиме просмотра мастер‑слайда:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $presentation->getViewProperties()->setLastView(ViewType::SlideMasterView);
    $presentation->save("presentation-master-view.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Дополнительные параметры просмотра см. в разделе [Сохранить презентацию](/slides/ru/php-java/save-presentation/).

## **Удаление неиспользуемых мастер‑слайдов**

Иногда презентации содержат мастер‑слайды, которые больше не используются никакими обычными слайдами. Удаление неиспользуемых мастеров может уменьшить размер файла и упростить обслуживание шаблонов.

Используйте `removeUnused` из [MasterSlideCollection](https://reference.aspose.com/slides/ru/php-java/aspose.slides/masterslidecollection/) для удаления неиспользуемых мастеров из коллекции `getMasters`:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $presentation->getMasters()->removeUnused(true);
    $presentation->save("presentation-clean.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Также можно воспользоваться методом низкоуровневого кода `removeUnusedMasterSlides` класса [Compress](https://reference.aspose.com/slides/ru/php-java/aspose.slides/compress/):

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

**В чём разница между мастер‑слайдом и шаблонным слайдом?**

Мастер‑слайд определяет общие параметры дизайна, такие как тема, фон, общие формы и стили текста. Шаблонный слайд принадлежит мастер‑слайду и определяет конкретное расположение заполнителей. Обычный слайд использует шаблонный слайд, поэтому наследует свойства как шаблона, так и мастера.

**Можно ли в одной презентации иметь несколько мастер‑слайдов?**

Да. Презентация может содержать несколько мастер‑слайдов. Используйте несколько мастеров, когда разные разделы требуют разных визуальных систем или брендинга.

**Следует ли добавлять заполнители в мастер‑слайд или в шаблонный слайд?**

В большинстве случаев заполнители добавляются в шаблонные слайды. Общие визуальные элементы и общие форматирования помещайте в мастер‑слайд, а заполнители контента — в шаблоны, которые будут использовать обычные слайды.

**Можно ли удалить мастер‑слайд, который всё ещё используется?**

Нет. Мастер‑слайд, имеющий зависимые слайды, нельзя безопасно удалить напрямую. Сначала переместите эти слайды в шаблоны другого мастера или используйте метод очистки неиспользуемых мастеров, который удаляет только те мастера, которые не задействованы.
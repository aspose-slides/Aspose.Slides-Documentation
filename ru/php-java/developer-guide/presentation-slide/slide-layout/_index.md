---
title: Применение или изменение макетов слайдов в PHP
linktitle: Макет слайда
type: docs
weight: 60
url: /ru/php-java/slide-layout/
keywords:
- макет слайда
- макет содержимого
- заполнитель
- дизайн презентации
- дизайн слайда
- неиспользуемый макет
- видимость нижнего колонтитула
- заглавный слайд
- заголовок и содержание
- заголовок раздела
- два содержания
- сравнение
- только заголовок
- пустой макет
- содержание с подписью
- картинка с подписью
- заголовок и вертикальный текст
- вертикальный заголовок и текст
- PowerPoint
- OpenDocument
- презентация
- PHP
- Aspose.Slides
description: "Управляйте и настраивайте макеты слайдов в Aspose.Slides для PHP через Java. Исследуйте типы макетов, управление заполнителями и видимость нижних колонтитулов с помощью примеров кода."
---

## **Обзор**

Макет слайда определяет расположение полей‑заполнителей и форматирование содержимого на слайде. Он управляет тем, какие заполнители доступны и где они отображаются. Макеты слайдов помогают быстро и последовательно создавать презентации — независимо от того, просты они или сложны. Некоторые из наиболее часто используемых макетов слайдов в PowerPoint:

**Макет Titile Slide** — содержит два текстовых заполнителя: один для заголовка и один для подзаголовка.

**Макет Title and Content** — имеет меньший заполнитель заголовка в верхней части и более крупный ниже для основного содержимого (текст, маркированные списки, диаграммы, изображения и др.).

**Пустой макет** — не содержит заполнителей, предоставляя полный контроль над созданием слайда с нуля.

Макеты слайдов являются частью шаблона слайда (slide master), который является верхнеуровневым слайдом, определяющим стили макетов для всей презентации. Вы можете получить доступ к макетам и изменять их через шаблон слайда — по типу, имени или уникальному идентификатору. Либо можно редактировать конкретный макет напрямую в презентации.

Для работы с макетами слайдов в Aspose.Slides for PHP можно использовать:

- Методы, такие как [getLayoutSlides](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getLayoutSlides) и [getMasters](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getMasters) класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)
- Типы, такие как [LayoutSlide](https://reference.aspose.com/slides/php-java/aspose.slides/layoutslide/), [MasterLayoutSlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/masterlayoutslidecollection/), [LayoutPlaceholderManager](https://reference.aspose.com/slides/php-java/aspose.slides/layoutplaceholdermanager/) и [LayoutSlideHeaderFooterManager](https://reference.aspose.com/slides/php-java/aspose.slides/layoutslideheaderfootermanager/)

{{% alert title="Info" color="info" %}}

Чтобы узнать больше о работе с шаблонами слайдов, ознакомьтесь со статьёй [Slide Master](/slides/ru/php-java/slide-master/).

{{% /alert %}}

## **Добавление макетов слайдов в презентацию**

Для настройки внешнего вида и структуры ваших слайдов может потребоваться добавить новые макеты в презентацию. Aspose.Slides for PHP позволяет проверить наличие нужного макета, при необходимости добавить его и использовать для вставки слайдов на основе этого макета.

1. Создайте объект класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
1. Получите доступ к [MasterLayoutSlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/masterlayoutslidecollection/).
1. Проверьте, существует ли требуемый макет в коллекции. Если нет — добавьте нужный макет.
1. Добавьте пустой слайд на основе только что созданного макета.
1. Сохраните презентацию.

Ниже приведён пример кода PHP, демонстрирующий добавление макета слайда в презентацию PowerPoint:
```php
// Создайте экземпляр класса Presentation, представляющего файл PowerPoint.
$presentation = new Presentation("Sample.pptx");
try {
    // Пройдитесь по типам макетов слайдов, чтобы выбрать макет слайда.
    $layoutSlides = $presentation->getMasters()->get_Item(0)->getLayoutSlides();
    $layoutSlide = null;
    if (!java_is_null($layoutSlides->getByType(SlideLayoutType::TitleAndObject))) {
        $layoutSlide = $layoutSlides->getByType(SlideLayoutType::TitleAndObject);
    } else {
        $layoutSlide = $layoutSlides->getByType(SlideLayoutType::Title);
    }

    if (java_is_null($layoutSlide)) {
        // Ситуация, когда презентация не содержит всех типов макетов.
        // Файл презентации содержит только типы макетов Blank и Custom.
        // Однако макеты слайдов с пользовательскими типами могут иметь узнаваемые имена,
        // например "Title", "Title and Content" и т.д., которые можно использовать для выбора макета слайда.
        // Вы также можете опираться на набор типов фигур‑заполнителей.
        // Например, слайд Title должен иметь только тип заполнителя Title и т.п.
        foreach($layoutSlides as $titleAndObjectLayoutSlide) {
            if (java_values($titleAndObjectLayoutSlide->getName()) == "Title and Object") {
                $layoutSlide = $titleAndObjectLayoutSlide;
                break;
            }
        }

        if (java_is_null($layoutSlide)) {
            foreach($layoutSlides as $titleLayoutSlide) {
                if (java_values($titleLayoutSlide->getName()) == "Title") {
                    $layoutSlide = $titleLayoutSlide;
                    break;
                }
            }

            if (java_is_null($layoutSlide)) {
                $layoutSlide = $layoutSlides->getByType(SlideLayoutType::Blank);
                if (java_is_null($layoutSlide)) {
                    $layoutSlide = $layoutSlides->add(SlideLayoutType::TitleAndObject, "Title and Object");
                }
            }
        }
    }

    // Добавьте пустой слайд, используя добавленный макет слайда.
    $presentation->getSlides()->insertEmptySlide(0, $layoutSlide);

    // Сохраните презентацию на диск.
    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```


## **Удаление неиспользуемых макетов слайдов**

Aspose.Slides предоставляет метод [removeUnusedLayoutSlides](https://reference.aspose.com/slides/php-java/aspose.slides/compress/#removeUnusedLayoutSlides) класса [Compress](https://reference.aspose.com/slides/php-java/aspose.slides/compress/), позволяющий удалить ненужные и неиспользуемые макеты слайдов.

Следующий пример кода PHP показывает, как удалить макет слайда из презентации PowerPoint:
```php
$presentation = new Presentation("Presentation.pptx");
try {
    Compress::removeUnusedLayoutSlides($presentation);
    $presentation->save("Output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```


## **Добавление заполнителей в макеты слайдов**

Aspose.Slides предоставляет метод [LayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/php-java/aspose.slides/layoutslide/#getPlaceholderManager), который позволяет добавлять новые заполнители в макет слайда.

Этот менеджер содержит методы для следующих типов заполнителей:

| Заполнитель PowerPoint | Метод [LayoutPlaceholderManager](https://reference.aspose.com/slides/php-java/aspose.slides/layoutplaceholdermanager/) |
| ---------------------- | ------------------------------------------------------------------------------------------------------------------- |
| ![Content](content.png) | addContentPlaceholder(float x, float y, float width, float height) |
| ![Content (Vertical)](contentV.png) | addVerticalContentPlaceholder(float x, float y, float width, float height) |
| ![Text](text.png) | addTextPlaceholder(float x, float y, float width, float height) |
| ![Text (Vertical)](textV.png) | addVerticalTextPlaceholder(float x, float y, float width, float height) |
| ![Picture](picture.png) | addPicturePlaceholder(float x, float y, float width, float height) |
| ![Chart](chart.png) | addChartPlaceholder(float x, float y, float width, float height) |
| ![Table](table.png) | addTablePlaceholder(float x, float y, float width, float height) |
| ![SmartArt](smartart.png) | addSmartArtPlaceholder(float x, float y, float width, float height) |
| ![Media](media.png) | addMediaPlaceholder(float x, float y, float width, float height) |
| ![Online Image](onlineimage.png) | addOnlineImagePlaceholder(float x, float y, float width, float height) |

Ниже показан PHP‑код, демонстрирующий добавление новых фигур‑заполнителей в пустой (Blank) макет слайда:
```php
$presentation = new Presentation();
try {
    // Получить пустой макет слайда.
    $layout = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Blank);

    // Получить менеджер заполнителей макетного слайда.
    $placeholderManager = $layout->getPlaceholderManager();

    // Добавить различные заполнители к пустому макету слайда.
    $placeholderManager->addContentPlaceholder(20, 20, 310, 270);
    $placeholderManager->addVerticalTextPlaceholder(350, 20, 350, 270);
    $placeholderManager->addChartPlaceholder(20, 310, 310, 180);
    $placeholderManager->addTablePlaceholder(350, 310, 350, 180);

    // Добавить новый слайд с пустым макетом.
    $newSlide = $presentation->getSlides()->addEmptySlide($layout);

    $presentation->save("Placeholders.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```


Результат:

![The placeholders on the layout slide](add_placeholders.png)

## **Установка видимости нижнего колонтитула для макета слайда**

В презентациях PowerPoint элементы нижнего колонтитула, такие как дата, номер слайда и пользовательский текст, могут отображаться или скрываться в зависимости от макета слайда. Aspose.Slides for PHP позволяет управлять видимостью этих заполнителей нижнего колонтитула. Это полезно, когда необходимо, чтобы некоторые макеты показывали информацию нижнего колонтитула, а другие оставались чистыми.

1. Создайте объект класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
1. Получите ссылку на макет слайда по его индексу.
1. Установите видимость заполнителя нижнего колонтитула слайда.
1. Установите видимость заполнителя номера слайда.
1. Установите видимость заполнителя даты/времени.
1. Сохраните презентацию.

Пример кода PHP, показывающий, как задать видимость нижнего колонтитула слайда:
```php
$presentation = new Presentation("Presentation.ppt");
try {
    $headerFooterManager = $presentation->getLayoutSlides()->get_Item(0)->getHeaderFooterManager();

    if (!$headerFooterManager->isFooterVisible()) {
        $headerFooterManager->setFooterVisibility(true);
    }

    if (!$headerFooterManager->isSlideNumberVisible()) {
        $headerFooterManager->setSlideNumberVisibility(true);
    }

    if (!$headerFooterManager->isDateTimeVisible()) {
        $headerFooterManager->setDateTimeVisibility(true);
    }

    $headerFooterManager->setFooterText("Footer text");
    $headerFooterManager->setDateTimeText("Date and time text");

    $presentation->save("Presentation.ppt", SaveFormat::Ppt);
} finally {
    $presentation->dispose();
}
```


## **Установка видимости нижних колонтитулов у дочерних слайдов**

​В презентациях PowerPoint элементы нижнего колонтитула, такие как дата, номер слайда и пользовательский текст, могут быть управляемы на уровне шаблона слайда, чтобы обеспечить единообразие во всех макетах. Aspose.Slides for PHP позволяет задать видимость и содержимое этих заполнителей на шаблоне слайда и распространить эти настройки на все дочерние макеты.

1. Создайте объект класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
1. Получите ссылку на шаблон слайда по его индексу.
1. Сделайте видимыми все нижние колонтитулы шаблона и его дочерних макетов.
1. Сделайте видимыми все номера слайдов шаблона и его дочерних макетов.
1. Сделайте видимыми все заполнители даты/времени шаблона и его дочерних макетов.
1. Сохраните презентацию.

Пример кода PHP, демонстрирующий эту операцию:
```php
$presentation = new Presentation("presentation.ppt");
try {
    $headerFooterManager = $presentation->getMasters()->get_Item(0)->getHeaderFooterManager();

    $headerFooterManager->setFooterAndChildFootersVisibility(true);
    $headerFooterManager->setSlideNumberAndChildSlideNumbersVisibility(true);
    $headerFooterManager->setDateTimeAndChildDateTimesVisibility(true);

    $headerFooterManager->setFooterAndChildFootersText("Footer text");
    $headerFooterManager->setDateTimeAndChildDateTimesText("Date and time text");

    $presentation->save("Output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```


## **FAQ**

**В чём разница между шаблоном слайда и макетом слайда?**

Шаблон слайда задаёт общую тему и форматирование по умолчанию, тогда как макеты слайдов определяют конкретные расположения заполнителей для разных типов содержимого.

**Можно ли скопировать макет слайда из одной презентации в другую?**

Да, можно клонировать макет слайда из коллекции макетов одной презентации (доступно через метод [getLayoutSlides](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getLayoutSlides)) и вставить его в другую презентацию с помощью метода `addClone`.

**Что происходит, если удалить макет слайда, который всё ещё используется?**

Если попытаться удалить макет, на который ссылается хотя бы один слайд, Aspose.Slides выбросит исключение [PptxEditException](https://reference.aspose.com/slides/php-java/aspose.slides/pptxeditexception/). Чтобы избежать этого, используйте [removeUnusedLayoutSlides](https://reference.aspose.com/slides/php-java/aspose.slides/compress/#removeUnusedLayoutSlides), который безопасно удалит только неиспользуемые макеты.
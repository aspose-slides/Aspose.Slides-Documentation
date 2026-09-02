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
- два содержимого
- сравнение
- только заголовок
- пустой макет
- содержимое с подписью
- изображение с подписью
- заголовок и вертикальный текст
- вертикальный заголовок и текст
- PowerPoint
- OpenDocument
- презентация
- PHP
- Aspose.Slides
description: "Применяйте, создавайте и изменяйте макеты слайдов в Aspose.Slides для PHP через Java, добавляйте заполнители, удаляйте неиспользуемые макеты и управляйте видимостью нижнего колонтитула."
---
## **Обзор**

Макет слайда определяет расположение и форматирование заполнителей, таких как заголовки, текст, изображения, диаграммы и таблицы. Применение макета обеспечивает слайдам единообразную структуру, позволяя каждому слайду содержать собственное содержание.

Самые распространённые макеты включают:

- **Title Slide**: Содержит заполнители заголовка и подзаголовка.
- **Title and Content**: Содержит заполнитель заголовка и универсальный заполнитель содержимого.
- **Blank**: Не содержит заполнителей содержимого и полезен, когда каждую форму нужно позиционировать вручную.

## **Понимание наследования макета**

Презентация имеет три взаимосвязанных уровня:

1. A [master slide](https://reference.aspose.com/slides/ru/php-java/aspose.slides/masterslide/) определяет тему, общие форматы, фоны и общие объекты.
1. A [layout slide](https://reference.aspose.com/slides/ru/php-java/aspose.slides/layoutslide/) принадлежит мастеру и определяет конкретное расположение заполнителей.
1. A [normal slide](https://reference.aspose.com/slides/ru/php-java/aspose.slides/slide/) использует один макет и хранит введённое для этого слайда содержание.

Обычный слайд наследует тему и форматирование от своего макета, а макет наследует их от мастера. Значение, установленное непосредственно на обычном слайде, переопределяет унаследованное значение на этом уровне. Когда создаётся обычный слайд, его формы‑заполнители генерируются из выбранного макета, тогда как содержимое, введённое в эти заполнители, принадлежит обычному слайду.

Добавьте необходимые заполнители в макет до создания из него слайдов. Добавление другого заполнителя в макет позже не добавит автоматически соответствующую форму‑заполнитель к уже существующим обычным слайдам.

Эти отношения имеют два важных следствия:

- Изменение унаследованного форматирования или геометрии существующих заполнителей в макете может обновить каждый слайд, зависящий от него. Перед редактированием уже используемого макета проверьте его зависимые слайды и просмотрите получившуюся презентацию.
- Макет, который всё ещё используется слайдом, нельзя удалить. Сначала переназначьте его зависимые слайды на другой макет или удаляйте только неиспользуемые макеты.

Для получения дополнительной информации о верхнем уровне этой иерархии смотрите [Slide Master](/slides/ru/php-java/slide-master/).

## **Выбор и применение макета слайда**

Используйте тип макета, когда презентация следует стандартным определениям макетов PowerPoint. Имена макетов могут редактироваться пользователем и локализоваться, поэтому выбор по имени менее надёжен, если только вы не контролируете исходный шаблон.

В следующем примере ищется **Title and Content** на первом мастере. Если этот макет недоступен, происходит намеренный переход к **Blank**. Вторая проверка на null необходима, потому что презентация может содержать только пользовательские макеты. Затем выбранный макет применяется к первому обычному слайду с помощью метода [Slide.setLayoutSlide](https://reference.aspose.com/slides/ru/php-java/aspose.slides/slide/#setLayoutSlide).

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideLayoutType;

$presentation = new Presentation("input.pptx");
try {
    $layoutSlides = $presentation->getMasters()->get_Item(0)->getLayoutSlides();
    $targetLayout = $layoutSlides->getByType(SlideLayoutType::TitleAndObject);

    if (java_is_null($targetLayout)) {
        $targetLayout = $layoutSlides->getByType(SlideLayoutType::Blank);
    }

    if (java_is_null($targetLayout)) {
        throw new \RuntimeException("The first master does not contain a suitable layout slide.");
    }

    $presentation->getSlides()->get_Item(0)->setLayoutSlide($targetLayout);
    $presentation->save("output-with-new-layout.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Изменение макета слайда не удаляет обычные формы, добавленные непосредственно на слайд. Однако позиции заполнителей, унаследованное форматирование и соответствие между существующими заполнителями и новым макетом могут измениться, поэтому проверяйте результат при переключении между существенно различными макетами.

## **Добавление макета слайда**

Выбор и создание — это отдельные операции. Предыдущий пример выбирает существующий макет; он не создаёт его. Чтобы создать макет, вызовите метод [MasterLayoutSlideCollection.add](https://reference.aspose.com/slides/ru/php-java/aspose.slides/masterlayoutslidecollection/#add) у коллекции макетов целевого мастера.

В следующем примере всегда добавляется новый **Title and Content** макет с именем `Report Title and Content`, после чего добавляется обычный слайд, основанный на нём. Имена макетов должны быть уникальными в пределах коллекции.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideLayoutType;

$presentation = new Presentation("input.pptx");
try {
    $masterSlide = $presentation->getMasters()->get_Item(0);
    $reportLayout = $masterSlide->getLayoutSlides()->add(SlideLayoutType::TitleAndObject, "Report Title and Content");
    $presentation->getSlides()->addEmptySlide($reportLayout);

    $presentation->save("output-with-report-layout.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Добавляйте макет только тогда, когда шаблон действительно нуждается в дополнительной переиспользуемой структуре. Если подходящий макет уже существует, выберите и повторно используйте его вместо создания дубликата.

## **Добавление заполнителей к макету слайда**

Метод [LayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/ru/php-java/aspose.slides/layoutslide/#getPlaceholderManager) предоставляет [LayoutPlaceholderManager](https://reference.aspose.com/slides/ru/php-java/aspose.slides/layoutplaceholdermanager/) для добавления форм‑заполнителей в макет.

| Заполнитель PowerPoint | `LayoutPlaceholderManager` Method |
| ---------------------- | --------------------------------- |
| ![Содержание](content.png) | [`addContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ru/php-java/aspose.slides/layoutplaceholdermanager/#addContentPlaceholder) |
| ![Содержание (вертикальное)](contentV.png) | [`addVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ru/php-java/aspose.slides/layoutplaceholdermanager/#addVerticalContentPlaceholder) |
| ![Текст](text.png) | [`addTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ru/php-java/aspose.slides/layoutplaceholdermanager/#addTextPlaceholder) |
| ![Текст (вертикальный)](textV.png) | [`addVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ru/php-java/aspose.slides/layoutplaceholdermanager/#addVerticalTextPlaceholder) |
| ![Изображение](picture.png) | [`addPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ru/php-java/aspose.slides/layoutplaceholdermanager/#addPicturePlaceholder) |
| ![Диаграмма](chart.png) | [`addChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ru/php-java/aspose.slides/layoutplaceholdermanager/#addChartPlaceholder) |
| ![Таблица](table.png) | [`addTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ru/php-java/aspose.slides/layoutplaceholdermanager/#addTablePlaceholder) |
| ![SmartArt](smartart.png) | [`addSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ru/php-java/aspose.slides/layoutplaceholdermanager/#addSmartArtPlaceholder) |
| ![Media](media.png) | [`addMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ru/php-java/aspose.slides/layoutplaceholdermanager/#addMediaPlaceholder) |
| ![Онлайн‑изображение](onlineImage.png) | [`addOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ru/php-java/aspose.slides/layoutplaceholdermanager/#addOnlineImagePlaceholder) |

В следующем примере проверяется наличие макета **Blank**, в него добавляются четыре заполнителя, после чего создаётся обычный слайд, использующий изменённый макет. Порядок намеренный: заполнители добавляются до создания обычного слайда, чтобы Aspose.Slides мог генерировать соответствующие формы‑заполнители на этом слайде.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideLayoutType;

$presentation = new Presentation();
try {
    $blankLayout = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Blank);

    if (java_is_null($blankLayout)) {
        throw new \RuntimeException("The presentation does not contain a Blank layout slide.");
    }

    $placeholderManager = $blankLayout->getPlaceholderManager();
    $placeholderManager->addContentPlaceholder(20, 20, 310, 270);
    $placeholderManager->addVerticalTextPlaceholder(350, 20, 350, 270);
    $placeholderManager->addChartPlaceholder(20, 310, 310, 180);
    $placeholderManager->addTablePlaceholder(350, 310, 350, 180);

    $presentation->getSlides()->addEmptySlide($blankLayout);
    $presentation->save("output-with-placeholders.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Результат:

![Заполнители на макете слайда](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
Изменение унаследованного форматирования или геометрии существующих заполнителей в макете может повлиять на зависимые слайды. Недавно добавленный заполнитель макета не заполняется автоматически в существующих обычных слайдах. Тестируйте изменения макета на копии презентации и проверяйте каждый зависимый слайд.
{{% /alert %}}

## **Удаление неиспользуемых макетов слайдов**

Используйте метод [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/ru/php-java/aspose.slides/compress/#removeUnusedLayoutSlides) для удаления макетов, на которые не ссылается ни один обычный слайд. Метод оставляет нетронутыми макеты, которые всё ещё используются.

```php
use aspose\slides\Compress;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("input.pptx");
try {
    Compress::removeUnusedLayoutSlides($presentation);
    $presentation->save("output-without-unused-layouts.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Чтобы удалить конкретный макет, сначала используйте его метод [hasDependingSlides](https://reference.aspose.com/slides/ru/php-java/aspose.slides/layoutslide/#hasDependingSlides) или [getDependingSlides](https://reference.aspose.com/slides/ru/php-java/aspose.slides/layoutslide/#getDependingSlides). Переназначьте все зависимые слайды перед вызовом [LayoutSlide.remove](https://reference.aspose.com/slides/ru/php-java/aspose.slides/layoutslide/#remove). Попытка удалить используемый макет вызывает [PptxEditException](https://reference.aspose.com/slides/ru/php-java/aspose.slides/pptxeditexception/).

## **Управление видимостью нижнего колонтитула на макете слайда**

У макета есть собственные заполнители нижнего колонтитула, номера слайда и даты/времени. Используйте метод [LayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/ru/php-java/aspose.slides/layoutslide/#getHeaderFooterManager), чтобы управлять этими заполнителями для одного макета. Это полезно, например, когда макеты содержимого должны показывать нижний колонтитул, а макеты заголовков — нет.

В следующем примере безопасно выбирается макет и делаются видимыми его элементы нижнего колонтитула:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideLayoutType;

$presentation = new Presentation("input.pptx");
try {
    $layoutSlide = $presentation->getLayoutSlides()->getByType(SlideLayoutType::TitleAndObject);

    if (java_is_null($layoutSlide)) {
        $layoutSlide = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Blank);
    }

    if (java_is_null($layoutSlide)) {
        throw new \RuntimeException("The presentation does not contain a suitable layout slide.");
    }

    $headerFooterManager = $layoutSlide->getHeaderFooterManager();
    $headerFooterManager->setFooterVisibility(true);
    $headerFooterManager->setSlideNumberVisibility(true);
    $headerFooterManager->setDateTimeVisibility(true);
    $headerFooterManager->setFooterText("Footer text");
    $headerFooterManager->setDateTimeText("Date and time text");

    $presentation->save("output-with-layout-footers.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Управление видимостью нижнего колонтитула на мастере и его дочерних макетах**

Чтобы применить единые настройки нижнего колонтитула по всей иерархии мастера, используйте метод [MasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/ru/php-java/aspose.slides/masterslide/#getHeaderFooterManager). Методы распространения [MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/ru/php-java/aspose.slides/masterslideheaderfootermanager/) работают на мастер, его зависимые макеты слайдов и обычные слайды; они не нацелены только на один обычный слайд.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("input.pptx");
try {
    $headerFooterManager = $presentation->getMasters()->get_Item(0)->getHeaderFooterManager();
    $headerFooterManager->setFooterAndChildFootersVisibility(true);
    $headerFooterManager->setSlideNumberAndChildSlideNumbersVisibility(true);
    $headerFooterManager->setDateTimeAndChildDateTimesVisibility(true);
    $headerFooterManager->setFooterAndChildFootersText("Footer text");
    $headerFooterManager->setDateTimeAndChildDateTimesText("Date and time text");

    $presentation->save("output-with-master-footers.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**В чём разница между мастером слайда и макетом слайда?**

Мастер‑слайд определяет тему презентации и общие форматы. Макет‑слайд принадлежит мастеру и задаёт одну переиспользуемую раскладку заполнителей. Обычные слайды используют эти макеты и хранят содержимое, специфичное для слайда.

**Можно ли скопировать макет‑слайда из одной презентации в другую?**

Да. Добавьте копию в целевую коллекцию с помощью метода [addClone](https://reference.aspose.com/slides/ru/php-java/aspose.slides/globallayoutslidecollection/#addClone). При копировании между презентациями также проверьте шрифты, темы, изображения и другие ресурсы, используемые исходным макетом.

**Что происходит, когда я изменяю макет, который уже используется?**

Зависимые слайды наследуют изменения макета, если они не переопределяют затронутое форматирование или объекты локально. Поэтому геометрия заполнителей и унаследованные стили могут измениться сразу на множестве слайдов. Используйте [getDependingSlides](https://reference.aspose.com/slides/ru/php-java/aspose.slides/layoutslide/#getDependingSlides), чтобы определить затронутые слайды перед редактированием макета.

**Что произойдёт, если удалить макет, который всё ещё используется?**

Aspose.Slides генерирует [PptxEditException](https://reference.aspose.com/slides/ru/php-java/aspose.slides/pptxeditexception/). Сначала переназначьте зависимые слайды или используйте [removeUnusedLayoutSlides](https://reference.aspose.com/slides/ru/php-java/aspose.slides/compress/#removeUnusedLayoutSlides), чтобы удалить только неиспользуемые макеты.
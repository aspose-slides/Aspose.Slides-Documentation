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
- титульный слайд
- заголовок и содержимое
- заголовок раздела
- два содержимых
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
description: "Применяйте, создавайте и изменяйте макеты слайдов в Aspose.Slides для PHP через Java, добавляйте заполнители, удаляйте неиспользуемые макеты и контролируйте видимость нижнего колонтитула."
---
## **Обзор**

Макет слайда определяет позиции и форматирование заполнителей, таких как заголовки, текст, изображения, диаграммы и таблицы. Применение макета даёт слайдам единообразную структуру, позволяя каждому слайду содержать собственный контент.

Самыми распространёнными макетами являются:

- **Титульный слайд**: содержит заполнители заголовка и подзаголовка.  
- **Заголовок и содержимое**: содержит заполнитель заголовка и общий заполнитель содержимого.  
- **Пустой**: не содержит заполнителей содержимого и удобен, когда все фигуры размещаются вручную.

## **Понимание наследования макетов**

Презентация имеет три взаимосвязанных уровня:

1. [master slide](https://reference.aspose.com/slides/ru/php-java/aspose.slides/masterslide/) определяет тему, общие параметры форматирования, фоны и общие объекты.  
1. [layout slide](https://reference.aspose.com/slides/ru/php-java/aspose.slides/layoutslide/) принадлежит мастеру и задаёт конкретное расположение заполнителей.  
1. [normal slide](https://reference.aspose.com/slides/ru/php-java/aspose.slides/slide/) использует один макет и хранит введённый для него контент.

Обычный слайд наследует тему и форматирование от своего макета, а макет — от своего мастера. Значение, установленное непосредственно на обычном слайде, переопределяет унаследованное значение на этом уровне. При создании обычного слайда его фигуры‑заполнители генерируются из выбранного макета, тогда как контент, введённый в эти заполнители, принадлежит обычному слайду.

Добавьте необходимые заполнители в макет до создания из него слайдов. Добавление позже нового заполнителя в макет не создаст автоматически соответствующую фигуру‑заполнитель в уже существующих обычных слайдах.

Эти отношения имеют две важные последствия:

- Изменение унаследованного форматирования или геометрии существующего заполнителя в макете может обновить каждый слайд, который от него зависит. Прежде чем редактировать макет, уже используемый в презентации, проверьте его зависимые слайды и просмотрите получившуюся презентацию.  
- Макет, который всё ещё используется слайдом, нельзя удалить. Сначала переназначьте его зависимые слайды на другой макет или удаляйте только неиспользуемые макеты.

Для получения дополнительной информации о верхнем уровне этой иерархии см. [Slide Master](/slides/ru/php-java/slide-master/).

Чтобы скрыть унаследованные логотипы или декоративные фигуры мастера на одном слайде или через общий макет, см. [Control the Visibility of Master Graphics](/slides/ru/php-java/slide-master/). Пример сравнивает два слайда, использующие один и тот же мастер.

## **Выбор и применение макета слайда**

Используйте тип макета, когда презентация следует стандартным определениям макетов PowerPoint. Имена макетов редактируются пользователем и могут быть локализованы, поэтому выбор по имени менее надёжен, если только вы не контролируете исходный шаблон.

В следующем примере ищется **Title and Content** на первом мастере. Если этот макет недоступен, происходит намеренный переход к **Blank**. Вторую проверку на `null` необходимо выполнить, потому что презентация может содержать только пользовательские макеты. Выбранный макет затем применяется к первому обычному слайду методом [Slide.setLayoutSlide](https://reference.aspose.com/slides/ru/php-java/aspose.slides/slide/#setLayoutSlide).

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

Изменение макета слайда не удаляет обычные фигуры, добавленные непосредственно в слайд. Однако позиции заполнителей, унаследованное форматирование и соответствие между существующими заполнителями и новым макетом могут измениться, поэтому проверяйте результат при переключении между существенно различными макетами.

## **Добавление макета слайда**

Выбор и создание — отдельные операции. В предыдущем примере выбирается существующий макет; он не создаётся. Чтобы создать макет, вызовите метод [MasterLayoutSlideCollection.add](https://reference.aspose.com/slides/ru/php-java/aspose.slides/masterlayoutslidecollection/#add) у коллекции макетов целевого мастера.

В следующем примере всегда добавляется новый макет **Title and Content** с именем `Report Title and Content`, после чего создаётся обычный слайд на его основе. Имена макетов должны быть уникальны в пределах коллекции.

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

Добавляйте макет только тогда, когда шаблон действительно нуждается в ещё одной повторно используемой структуре. Если подходящий макет уже существует, выберите и переиспользуйте его вместо создания дубликата.

## **Добавление заполнителей в макет слайда**

Метод [LayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/ru/php-java/aspose.slides/layoutslide/#getPlaceholderManager) возвращает объект [LayoutPlaceholderManager](https://reference.aspose.com/slides/ru/php-java/aspose.slides/layoutplaceholdermanager/) для добавления фигур‑заполнителей в макет.

| Заполнитель PowerPoint | `LayoutPlaceholderManager` Метод |
| ---------------------- | -------------------------------- |
| ![Содержание](content.png) | [`addContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ru/php-java/aspose.slides/layoutplaceholdermanager/#addContentPlaceholder) |
| ![Содержание (вертикальное)](contentV.png) | [`addVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ru/php-java/aspose.slides/layoutplaceholdermanager/#addVerticalContentPlaceholder) |
| ![Текст](text.png) | [`addTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ru/php-java/aspose.slides/layoutplaceholdermanager/#addTextPlaceholder) |
| ![Текст (вертикальный)](textV.png) | [`addVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ru/php-java/aspose.slides/layoutplaceholdermanager/#addVerticalTextPlaceholder) |
| ![Изображение](picture.png) | [`addPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ru/php-java/aspose.slides/layoutplaceholdermanager/#addPicturePlaceholder) |
| ![Диаграмма](chart.png) | [`addChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ru/php-java/aspose.slides/layoutplaceholdermanager/#addChartPlaceholder) |
| ![Таблица](table.png) | [`addTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ru/php-java/aspose.slides/layoutplaceholdermanager/#addTablePlaceholder) |
| ![SmartArt](smartart.png) | [`addSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ru/php-java/aspose.slides/layoutplaceholdermanager/#addSmartArtPlaceholder) |
| ![Медиа](media.png) | [`addMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ru/php-java/aspose.slides/layoutplaceholdermanager/#addMediaPlaceholder) |
| ![Онлайн‑изображение](onlineImage.png) | [`addOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ru/php-java/aspose.slides/layoutplaceholdermanager/#addOnlineImagePlaceholder) |

В следующем примере проверяется наличие макета **Blank**, в него добавляются четыре заполнителя, а затем создаётся обычный слайд, использующий модифицированный макет. Порядок намеренно выбран: заполнители добавляются до создания обычного слайда, чтобы Aspose.Slides мог сгенерировать соответствующие фигуры‑заполнители на этом слайде.

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
Изменение унаследованного форматирования или геометрии существующих заполнителей макета может повлиять на зависимые слайды. Нововведённый заполнитель макета не будет автоматически добавлен в уже существующие обычные слайды. Тестируйте изменения макета на копии презентации и проверяйте каждый зависимый слайд.
{{% /alert %}}

## **Удаление неиспользуемых макетов слайдов**

Используйте метод [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/ru/php-java/aspose.slides/compress/#removeUnusedLayoutSlides) для удаления макетов, на которые не ссылаются обычные слайды. Метод сохраняет макеты, находящиеся в использовании.

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

Чтобы удалить конкретный макет, сначала вызовите его метод [hasDependingSlides](https://reference.aspose.com/slides/ru/php-java/aspose.slides/layoutslide/#hasDependingSlides) или [getDependingSlides](https://reference.aspose.com/slides/ru/php-java/aspose.slides/layoutslide/#getDependingSlides). Переназначьте все зависимые слайды перед вызовом [LayoutSlide.remove](https://reference.aspose.com/slides/ru/php-java/aspose.slides/layoutslide/#remove). Попытка удалить используемый макет приводит к исключению [PptxEditException](https://reference.aspose.com/slides/ru/php-java/aspose.slides/pptxeditexception/).

## **Управление видимостью нижнего колонтитула на макете слайда**

У макета есть собственные заполнители нижнего колонтитула, номера слайда и даты/времени. Используйте метод [LayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/ru/php-java/aspose.slides/layoutslide/#getHeaderFooterManager) для управления этими заполнителями в рамках одного макета. Это полезно, например, когда макеты содержимого должны отображать нижний колонтитул, а титульные — нет.

В следующем примере безопасно выбирается макет и делаются его элементы нижнего колонтитула видимыми:

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

Чтобы задать согласованные настройки нижних колонтитулов по всей иерархии мастера, используйте метод [MasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/ru/php-java/aspose.slides/masterslide/#getHeaderFooterManager). Методы распространения [MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/ru/php-java/aspose.slides/masterslideheaderfootermanager/) работают как с мастером, так и с его зависимыми макетами и обычными слайдами; они не направлены только на один обычный слайд.

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

**В чём разница между мастер‑слайдом и макетом слайда?**

Мастер‑слайд определяет тему презентации и общие параметры форматирования. Макет‑слайд принадлежит мастеру и задаёт один повторно используемый набор заполнителей. Обычные слайды используют эти макеты и хранят контент, специфичный для конкретного слайда.

**Можно ли скопировать макет‑слайд из одной презентации в другую?**

Да. Добавьте копию в целевую коллекцию с помощью метода [addClone](https://reference.aspose.com/slides/ru/php-java/aspose.slides/globallayoutslidecollection/#addClone). При копировании между презентациями также проверьте шрифты, темы, изображения и другие ресурсы, используемые исходным макетом.

**Что происходит, если я изменяю макет, который уже используется?**

Зависимые слайды наследуют изменения макета, если они не переопределили затронутое форматирование или объекты локально. Геометрия заполнителей и унаследованные стили могут изменить внешний вид множества слайдов одновременно. Используйте [getDependingSlides](https://reference.aspose.com/slides/ru/php-java/aspose.slides/layoutslide/#getDependingSlides), чтобы определить затронутые слайды перед редактированием макета.

**Что произойдёт, если попытаться удалить макет, который всё ещё используется?**

Aspose.Slides выбросит исключение [PptxEditException](https://reference.aspose.com/slides/ru/php-java/aspose.slides/pptxeditexception/). Сначала переназначьте зависимые слайды или используйте [removeUnusedLayoutSlides](https://reference.aspose.com/slides/ru/php-java/aspose.slides/compress/#removeUnusedLayoutSlides) для удаления только неиспользуемых макетов.
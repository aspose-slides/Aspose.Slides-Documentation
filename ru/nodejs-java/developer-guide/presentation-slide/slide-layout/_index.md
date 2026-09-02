---
title: Применение или изменение макетов слайдов в JavaScript
linktitle: Макет слайда
type: docs
weight: 60
url: /ru/nodejs-java/slide-layout/
keywords:
- макет слайда
- макет содержимого
- заполнитель
- дизайн презентации
- дизайн слайда
- неиспользуемый макет
- видимость колонтитула
- титульный слайд
- заголовок и содержание
- заголовок раздела
- два содержимых
- сравнение
- только заголовок
- пустой макет
- содержание с подписью
- изображение с подписью
- заголовок и вертикальный текст
- вертикальный заголовок и текст
- PowerPoint
- OpenDocument
- презентация
- Node.js
- JavaScript
- Aspose.Slides
description: "Применяйте, создавайте и изменяйте макеты слайдов в Aspose.Slides для Node.js через Java, добавляйте заполнители, удаляйте неиспользуемые макеты и управляйте видимостью колонтитула."
---
## **Обзор**

Макет слайда определяет позиции и форматирование заполнителей, таких как заголовки, текст, изображения, диаграммы и таблицы. Применение макета придаёт слайдам согласованную структуру, позволяя каждому слайду содержать собственное содержание.

Самыми распространёнными макетами являются:

- **Title Slide**: Содержит заполнители заголовка и подзаголовка.
- **Title and Content**: Содержит заполнитель заголовка и универсальный заполнитель содержимого.
- **Blank**: Не содержит заполнителей содержимого и полезен, когда все объекты размещаются вручную.

## **Понимание наследования макетов**

Презентация имеет три связанных уровня:

1. A [master slide](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/masterslide/) определяет тему, общие форматирования, фоны и общие объекты.
2. A [layout slide](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/layoutslide/) принадлежит мастеру и определяет конкретное расположение заполнителей.
3. A [normal slide](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/slide/) использует один макет и хранит введённое для него содержание.

Обычный слайд наследует тему и форматирование от своего макета, а макет наследует их от своего мастера. Значение, установленное непосредственно для обычного слайда, переопределяет унаследованное значение на этом уровне. При создании обычного слайда его заполнители‑фигуры генерируются из выбранного макета, тогда как содержимое, введённое в эти заполнители, принадлежит обычному слайду.

Добавьте необходимые заполнители к макету перед созданием слайдов из него. Добавление другого заполнителя к макету позже не добавит автоматически соответствующую форму‑заполнитель в существующие обычные слайды.

Эта связь имеет два важных следствия:

- Изменение унаследованного форматирования или геометрии существующего заполнителя на макете может обновить каждый слайд, который от него зависит. Перед редактированием уже используемого макета проверьте зависимые слайды и просмотрите получившуюся презентацию.
- Макет, который всё ещё используется слайдом, нельзя удалить. Сначала переназначьте его зависимые слайды на другой макет или удалите только неиспользуемые макеты.

Для получения дополнительной информации о верхнем уровне этой иерархии см. [Slide Master](/slides/ru/nodejs-java/slide-master/).

## **Выбор и применение макета слайда**

Используйте значение [SlideLayoutType](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/slidelayouttype/), когда презентация следует стандартным определениям макетов PowerPoint. Имена макетов редактируются пользователем и могут быть локализованы, поэтому выбор по имени менее надёжен, если вы не контролируете исходный шаблон.

В следующем примере ищется **Title and Content** на первом мастере. Если этот макет недоступен, он намеренно переключается на **Blank**. Вторичная проверка на null необходима, потому что презентация может содержать только пользовательские макеты. Затем выбранный макет применяется к первому обычному слайду через метод [Slide.setLayoutSlide](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/slide/#setLayoutSlide).

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("input.pptx");
try {
    let layoutSlides = presentation.getMasters().get_Item(0).getLayoutSlides();
    let titleAndObjectLayoutType = java.newByte(aspose.slides.SlideLayoutType.TitleAndObject);
    let blankLayoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
    let targetLayout = layoutSlides.getByType(titleAndObjectLayoutType);

    if (targetLayout === null) {
        targetLayout = layoutSlides.getByType(blankLayoutType);
    }

    if (targetLayout === null) {
        throw new Error("The first master does not contain a suitable layout slide.");
    }

    presentation.getSlides().get_Item(0).setLayoutSlide(targetLayout);
    presentation.save("output-with-new-layout.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Изменение макета слайда не удаляет обычные формы, добавленные напрямую на слайд. Однако позиция заполнителей, унаследованное форматирование и соответствие между существующими заполнителями и новым макетом могут измениться, поэтому проверяйте результат при переключении между существенно разными макетами.

## **Добавление макета‑слайда**

Выбор и создание – отдельные операции. В предыдущем примере выбирается существующий макет; он не создаётся. Чтобы создать макет, вызовите метод [MasterLayoutSlideCollection.add](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/masterlayoutslidecollection/#add) у коллекции макетов целевого мастера.

В следующем примере всегда добавляется новый макет **Title and Content** с именем `Report Title and Content`, затем на его основе создаётся обычный слайд. Имена макетов должны быть уникальными в пределах коллекции.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("input.pptx");
try {
    let masterSlide = presentation.getMasters().get_Item(0);
    let titleAndObjectLayoutType = java.newByte(aspose.slides.SlideLayoutType.TitleAndObject);
    let reportLayout = masterSlide.getLayoutSlides().add(titleAndObjectLayoutType, "Report Title and Content");
    presentation.getSlides().addEmptySlide(reportLayout);

    presentation.save("output-with-report-layout.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Добавляйте макет только тогда, когда шаблон действительно нуждается в новой переиспользуемой структуре. Если подходящий макет уже существует, выберите и используйте его вместо создания дубликата.

## **Добавление заполнителей к макету‑слайду**

Метод [LayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/layoutslide/#getPlaceholderManager) предоставляет объект [LayoutPlaceholderManager](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/layoutplaceholdermanager/) для добавления форм‑заполнителей к макету.

| Заполнитель PowerPoint              | ``LayoutPlaceholderManager`` Метод |
| ----------------------------------- | --------------------------------- |
| ![Content](content.png)             | [`addContentPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/layoutplaceholdermanager/#addContentPlaceholder) |
| ![Content (Vertical)](contentV.png) | [`addVerticalContentPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/layoutplaceholdermanager/#addVerticalContentPlaceholder) |
| ![Text](text.png)                   | [`addTextPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/layoutplaceholdermanager/#addTextPlaceholder) |
| ![Text (Vertical)](textV.png)       | [`addVerticalTextPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/layoutplaceholdermanager/#addVerticalTextPlaceholder) |
| ![Picture](picture.png)             | [`addPicturePlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/layoutplaceholdermanager/#addPicturePlaceholder) |
| ![Chart](chart.png)                 | [`addChartPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/layoutplaceholdermanager/#addChartPlaceholder) |
| ![Table](table.png)                 | [`addTablePlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/layoutplaceholdermanager/#addTablePlaceholder) |
| ![SmartArt](smartart.png)           | [`addSmartArtPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/layoutplaceholdermanager/#addSmartArtPlaceholder) |
| ![Media](media.png)                 | [`addMediaPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/layoutplaceholdermanager/#addMediaPlaceholder) |
| ![Online Image](onlineImage.png)    | [`addOnlineImagePlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/layoutplaceholdermanager/#addOnlineImagePlaceholder) |

В следующем примере проверяется наличие макета **Blank**, к нему добавляются четыре заполнителя, после чего создаётся обычный слайд, использующий изменённый макет. Порядок намеренный: заполнители добавляются до создания обычного слайда, чтобы Aspose.Slides мог генерировать соответствующие формы‑заполнители на этом слайде.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let blankLayoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
    let blankLayout = presentation.getLayoutSlides().getByType(blankLayoutType);

    if (blankLayout === null) {
        throw new Error("The presentation does not contain a Blank layout slide.");
    }

    let placeholderManager = blankLayout.getPlaceholderManager();
    placeholderManager.addContentPlaceholder(20, 20, 310, 270);
    placeholderManager.addVerticalTextPlaceholder(350, 20, 350, 270);
    placeholderManager.addChartPlaceholder(20, 310, 310, 180);
    placeholderManager.addTablePlaceholder(350, 310, 350, 180);

    presentation.getSlides().addEmptySlide(blankLayout);
    presentation.save("output-with-placeholders.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Результат:

![The placeholders on the layout slide](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
Изменение унаследованного форматирования или геометрии существующих заполнителей макета может повлиять на зависимые слайды. Ново‑добавленный заполнитель макета не заполняется автоматически в существующие обычные слайды. Тестируйте изменения макета на копии презентации и проверяйте каждый зависимый слайд.
{{% /alert %}}

## **Удаление неиспользуемых макетов‑слайдов**

Используйте метод [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/compress/#removeUnusedLayoutSlides) для удаления макетов, на которые не ссылаются обычные слайды. Метод оставляет в системе макеты, которые всё ещё используются.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("input.pptx");
try {
    aspose.slides.Compress.removeUnusedLayoutSlides(presentation);
    presentation.save("output-without-unused-layouts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Чтобы удалить конкретный макет, сначала используйте его метод [hasDependingSlides](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/layoutslide/#hasDependingSlides) или [getDependingSlides](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/layoutslide/#getDependingSlides). Переназначьте любые зависимые слайды перед вызовом [LayoutSlide.remove](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/layoutslide/#remove). Попытка удалить используемый макет вызывает [PptxEditException](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/pptxeditexception/).

## **Управление видимостью колонтитулов на макете‑слайде**

У макета есть собственные заполнители колонтитулов, номеров слайдов и даты/времени. Используйте метод [LayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/layoutslide/#getHeaderFooterManager) для управления этими заполнителями у одного макета. Это полезно, например, когда заполнители контента должны показывать колонтитулы, а заполнители заголовков — нет.

В следующем примере безопасно выбирается макет и делают его элементы колонтитула видимыми:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("input.pptx");
try {
    let titleAndObjectLayoutType = java.newByte(aspose.slides.SlideLayoutType.TitleAndObject);
    let blankLayoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
    let layoutSlide = presentation.getLayoutSlides().getByType(titleAndObjectLayoutType);

    if (layoutSlide === null) {
        layoutSlide = presentation.getLayoutSlides().getByType(blankLayoutType);
    }

    if (layoutSlide === null) {
        throw new Error("The presentation does not contain a suitable layout slide.");
    }

    let headerFooterManager = layoutSlide.getHeaderFooterManager();
    headerFooterManager.setFooterVisibility(true);
    headerFooterManager.setSlideNumberVisibility(true);
    headerFooterManager.setDateTimeVisibility(true);
    headerFooterManager.setFooterText("Footer text");
    headerFooterManager.setDateTimeText("Date and time text");

    presentation.save("output-with-layout-footers.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Управление видимостью колонтитулов на мастере и его дочерних макетах**

Чтобы применить согласованные настройки колонтитулов по всей иерархии мастера, используйте метод [MasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/masterslide/#getHeaderFooterManager). Методы распространения [MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/masterslideheaderfootermanager/) работают с мастером, его зависимыми макетами‑слайдами и обычными слайдами; они не нацелены только на один обычный слайд.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("input.pptx");
try {
    let headerFooterManager = presentation.getMasters().get_Item(0).getHeaderFooterManager();
    headerFooterManager.setFooterAndChildFootersVisibility(true);
    headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true);
    headerFooterManager.setDateTimeAndChildDateTimesVisibility(true);
    headerFooterManager.setFooterAndChildFootersText("Footer text");
    headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text");

    presentation.save("output-with-master-footers.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**В чём разница между мастер‑слайдом и макетом‑слайдом?**

Мастер‑слайд определяет тему презентации и общие форматирования. Макет‑слайд принадлежит мастеру и определяет одну переиспользуемую раскладку заполнителей. Обычные слайды используют эти макеты и хранят содержание, специфичное для конкретного слайда.

**Можно ли скопировать макет‑слайд из одной презентации в другую?**

Да. Добавьте копию в целевую коллекцию с помощью метода [addClone](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/globallayoutslidecollection/#addClone). При копировании между презентациями также проверьте шрифты, темы, изображения и другие ресурсы, используемые исходным макетом.

**Что происходит, если изменить макет, который уже используется?**

Зависимые слайды наследуют изменения макета, если только они не переопределили затронутое форматирование или объекты локально. Геометрия заполнителей и унаследованный стиль могут измениться сразу на многих слайдах. Используйте [getDependingSlides](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/layoutslide/#getDependingSlides), чтобы определить затронутые слайды перед редактированием макета.

**Что произойдёт, если попытаться удалить макет, который всё ещё используется?**

Aspose.Slides бросит [PptxEditException](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/pptxeditexception/). Сначала переназначьте зависимые слайды или используйте [removeUnusedLayoutSlides](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/compress/#removeUnusedLayoutSlides) для удаления только непереключённых макетов.
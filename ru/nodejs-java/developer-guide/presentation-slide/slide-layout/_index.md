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
- видимость нижнего колонтитула
- титульный слайд
- заголовок и содержание
- заголовок раздела
- двойное содержимое
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
description: "Применяйте, создавайте и модифицируйте макеты слайдов в Aspose.Slides для Node.js через Java, добавляйте заполнители, удаляйте неиспользуемые макеты и управляйте видимостью нижних колонтитулов."
---
## **Обзор**

Слайд‑макет определяет позиции и форматирование заполнителей, таких как заголовки, текст, изображения, диаграммы и таблицы. Применение макета обеспечивает слайдам согласованную структуру, позволяя каждому слайду содержать собственное содержание.

Самые часто используемые макеты включают:

- **Title Slide**: Содержит заполнители заголовка и подзаголовка.
- **Title and Content**: Содержит заполнитель заголовка и универсальный заполнитель содержимого.
- **Blank**: Не содержит заполнителей содержимого и полезен, когда каждая форма будет позиционироваться вручную.

## **Понимание наследования макетов**

Презентация имеет три связанных уровня:

1. A [главный слайд](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/masterslide/) определяет тему, общие форматирования, фон и общие объекты.
1. A [слайд макета](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/layoutslide/) принадлежит главному слайду и определяет конкретное расположение заполнителей.
1. A [обычный слайд](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/slide/) использует один макет и хранит введённое для этого слайда содержание.

Обычный слайд наследует тему и форматирование от своего макета, а макет наследует их от главного слайда. Значение, установленное непосредственно на обычном слайде, переопределяет унаследованное значение на этом уровне. При создании обычного слайда его формы‑заполнители генерируются из выбранного макета, тогда как содержание, введённое в эти заполнители, принадлежит обычному слайду.

Добавьте необходимые заполнители в макет до создания из него слайдов. Добавление другого заполнителя в макет позже не создаёт автоматически соответствующую форму‑заполнитель в уже существующих обычных слайдах.

У этих отношений есть два важных последствия:

- Изменение унаследованного форматирования или геометрии существующих заполнителей макета может обновить каждый слайд, зависящий от него. Перед редактированием используемого макета проверьте его зависимые слайды и результатирующую презентацию.
- Макет, который всё ещё используется слайдом, нельзя удалить. Сначала переназначьте его зависимые слайды на другой макет или удаляйте только неиспользуемые макеты.

Для получения дополнительной информации о верхнем уровне этой иерархии см. [Слайд‑мастер](/slides/ru/nodejs-java/slide-master/).

Чтобы скрыть унаследованные логотипы или декоративные элементы мастера на отдельном слайде или через общий макет, см. [Управление видимостью графики мастера](/slides/ru/nodejs-java/slide-master/). Пример сравнивает два слайда, использующие один и тот же мастер.

## **Выбор и применение макета слайда**

Используйте значение [SlideLayoutType](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/slidelayouttype/), когда презентация следует стандартным определениям макетов PowerPoint. Имена макетов редактируемы пользователем и могут быть локализованы, поэтому выбор по имени менее надёжен, если вы не контролируете исходный шаблон.

Следующий пример ищет **Title and Content** на первом мастере. Если этот макет недоступен, он намеренно переключается на **Blank**. Вторая проверка на null необходима, потому что презентация может содержать только пользовательские макеты. Затем выбранный макет применяется к первому обычному слайду через метод [Slide.setLayoutSlide](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/slide/#setLayoutSlide).

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

Изменение макета слайда не удаляет обычные формы, добавленные напрямую к слайду. Однако позиции заполнителей, унаследованное форматирование и соответствие между существующими заполнителями и новым макетом могут измениться, поэтому проверяйте результат при переключении между существенно различными макетами.

## **Добавление макета слайда**

Выбор и создание — отдельные операции. В предыдущем примере выбирается существующий макет; он не создаётся. Чтобы создать макет, вызовите метод [MasterLayoutSlideCollection.add](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/masterlayoutslidecollection/#add) в коллекции макетов целевого мастера.

Следующий пример всегда добавляет новый макет **Title and Content** с именем `Report Title and Content`, а затем добавляет обычный слайд на его основе. Имена макетов должны быть уникальными в пределах коллекции.

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

Добавляйте макет только тогда, когда шаблон действительно нуждается в новой переиспользуемой структуре. Если подходящий макет уже существует, выбирайте и переиспользуйте его вместо создания дубликата.

## **Добавление заполнителей в макетный слайд**

Метод [LayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/layoutslide/#getPlaceholderManager) предоставляет [LayoutPlaceholderManager](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/layoutplaceholdermanager/) для добавления форм‑заполнителей в макет.

| Заполнитель PowerPoint | `LayoutPlaceholderManager` Метод |
| ---------------------- | -------------------------------- |
| ![Содержание](content.png) | [`addContentPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/layoutplaceholdermanager/#addContentPlaceholder) |
| ![Содержание (Вертикальное)](contentV.png) | [`addVerticalContentPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/layoutplaceholdermanager/#addVerticalContentPlaceholder) |
| ![Текст](text.png) | [`addTextPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/layoutplaceholdermanager/#addTextPlaceholder) |
| ![Текст (Вертикальное)](textV.png) | [`addVerticalTextPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/layoutplaceholdermanager/#addVerticalTextPlaceholder) |
| ![Изображение](picture.png) | [`addPicturePlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/layoutplaceholdermanager/#addPicturePlaceholder) |
| ![Диаграмма](chart.png) | [`addChartPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/layoutplaceholdermanager/#addChartPlaceholder) |
| ![Таблица](table.png) | [`addTablePlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/layoutplaceholdermanager/#addTablePlaceholder) |
| ![SmartArt](smartart.png) | [`addSmartArtPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/layoutplaceholdermanager/#addSmartArtPlaceholder) |
| ![Медиа](media.png) | [`addMediaPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/layoutplaceholdermanager/#addMediaPlaceholder) |
| ![Онлайн‑изображение](onlineImage.png) | [`addOnlineImagePlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/layoutplaceholdermanager/#addOnlineImagePlaceholder) |

Следующий пример проверяет наличие макета **Blank**, добавляет к нему четыре заполнителя и затем создаёт обычный слайд, использующий изменённый макет. Порядок намеренный: заполнители добавляются до создания обычного слайда, чтобы Aspose.Slides мог сгенерировать соответствующие формы‑заполнители на этом слайде.

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

![Заполнители на макетном слайде](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
Изменение унаследованного форматирования или геометрии существующих заполнителей макета может затронуть зависимые слайды. Ново‑добавленный заполнитель макета не заполняется автоматически в уже существующих обычных слайдах. Тестируйте изменения макета на копии презентации и проверяйте каждый зависимый слайд.
{{% /alert %}}

## **Удаление неиспользуемых макетов слайдов**

Используйте метод [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/compress/#removeUnusedLayoutSlides) для удаления макетов, на которые не ссылается ни один обычный слайд. Метод оставляет нетронутыми макеты, которые всё ещё используются.

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

Чтобы удалить конкретный макет, сначала используйте его метод [hasDependingSlides](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/layoutslide/#hasDependingSlides) или [getDependingSlides](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/layoutslide/#getDependingSlides). Переназначьте любые зависимые слайды перед вызовом [LayoutSlide.remove](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/layoutslide/#remove). Попытка удалить используемый макет вызывает исключение [PptxEditException](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/pptxeditexception/).

## **Управление видимостью нижних колонтитулов на макетном слайде**

У макета есть собственные заполнители нижнего колонтитула, номера слайда и даты‑времени. Используйте метод [LayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/layoutslide/#getHeaderFooterManager) для управления этими заполнителями в одном макете. Это полезно, когда, например, макеты содержимого должны показывать колонтитулы, а макеты заголовков — нет.

Следующий пример безопасно выбирает макет и делает его элементы нижнего колонтитула видимыми:

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

## **Управление видимостью нижних колонтитулов на мастере и его дочерних макетах**

Чтобы применить согласованные настройки колонтитулов по всей иерархии мастера, используйте метод [MasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/masterslide/#getHeaderFooterManager). Методы распространения [MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/masterslideheaderfootermanager/) работают на мастере и его зависимых макетных и обычных слайдах; они не ориентированы только на один обычный слайд.

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

**В чем разница между мастером слайда и макетным слайдом?**

Мастер слайда определяет тему презентации и общие параметры форматирования. Макетный слайд принадлежит мастеру и определяет одну переиспользуемую раскладку заполнителей. Обычные слайды используют эти макеты и хранят содержание, специфичное для конкретного слайда.

**Могу ли я скопировать макетный слайд из одной презентации в другую?**

Да. Добавьте копию в целевую коллекцию с помощью метода [addClone](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/globallayoutslidecollection/#addClone). При копировании между презентациями также проверьте шрифты, темы, изображения и другие ресурсы, используемые исходным макетом.

**Что происходит, когда я изменяю уже используемый макет?**

Зависимые слайды наследуют изменения макета, если они не переопределили затронутое форматирование или объекты локально. Геометрия заполнителей и унаследованные стили могут измениться сразу на многих слайдах. Используйте [getDependingSlides](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/layoutslide/#getDependingSlides), чтобы определить затронутые слайды до редактирования макета.

**Что произойдет, если я удалю макет, который всё ещё используется?**

Aspose.Slides генерирует исключение [PptxEditException](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/pptxeditexception/). Сначала переназначьте зависимые слайды или используйте [removeUnusedLayoutSlides](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/compress/#removeUnusedLayoutSlides) для удаления только неупомянутых макетов.
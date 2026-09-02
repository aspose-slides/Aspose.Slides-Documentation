---
title: Получить эффективные свойства фигур из презентаций на JavaScript
linktitle: Эффективные свойства
type: docs
weight: 50
url: /ru/nodejs-java/shape-effective-properties/
keywords:
- свойства фигур
- свойства камеры
- освещение
- скос фигуры
- текстовый кадр
- стиль текста
- высота шрифта
- формат заполнения
- PowerPoint
- презентация
- Node.js
- JavaScript
- Aspose.Slides
description: "Узнайте, как использовать Aspose.Slides for Node.js via Java для различения локального, унаследованного и эффективного форматирования фигур в презентациях PowerPoint."
---
## **Поймите локальные, унаследованные и эффективные свойства**

Форматирование PowerPoint может поступать из нескольких источников. Значение, хранящееся непосредственно в объекте, является его **локальным значением**. Если это значение не задано, PowerPoint ищет источники форматирования у родителя, такие как значение по умолчанию абзаца, стиль текста, макет или шаблон слайда, тема или параметры по умолчанию уровня презентации. Эти значения являются **унаследованными значениями**. Значение, которое остаётся после разрешения всей иерархии, — это **эффективное значение** — значение, используемое для отображения объекта.

Например, часть текста может не определять собственный размер шрифта. Ее локальное значение [getFontHeight](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/portionformat/#getFontHeight) тогда равно `NaN`, что означает «не установлено здесь». Часть может унаследовать высоту от абзаца, стиля текста по умолчанию презентации или другого применимого источника. Вызов [getEffective](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/portionformat/#getEffective) у формата части возвращает окончательно разрешённую высоту.

Используйте два типа данных форматирования для разных целей:

- Читать или изменять локальный объект формата, такой как [PortionFormat](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/portionformat/), когда нужно контролировать, где определено значение.
- Читать [Эффективные данные, возвращаемые PortionFormat.getEffective](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/portionformat/#getEffective) когда нужен окончательный отрендеренный результат. Эффективные данные только для чтения.

Перед запуском примеров [установите Aspose.Slides for Node.js via Java](/slides/ru/nodejs-java/installation/).

## **Сравнение локальных, унаследованных и эффективных значений**

Следующий полностью пример создаёт фигуру и задаёт высоту шрифта на уровнях презентации, абзаца и части. Каждый шаг выводит значения, определённые на этих уровнях, и получающееся эффективное значение для той же части текста. Он также демонстрирует, почему эффективные данные необходимо считывать заново после изменений форматирования.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

function formatLocalValue(value) {
    return Number.isNaN(value) ? "<not set>" : value.toString();
}

function printFontHeights(caption, presentation, paragraph, portion) {
    const presentationValue = presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().getFontHeight();
    const paragraphValue = paragraph.getParagraphFormat().getDefaultPortionFormat().getFontHeight();
    const localValue = portion.getPortionFormat().getFontHeight();

    // Прочитать эффективные данные после предыдущих изменений.
    const effectiveValue = portion.getPortionFormat().getEffective().getFontHeight();

    console.log(caption);
    console.log("  Presentation default: " + formatLocalValue(presentationValue));
    console.log("  Paragraph default:    " + formatLocalValue(paragraphValue));
    console.log("  Portion local:        " + formatLocalValue(localValue));
    console.log("  Portion effective:    " + effectiveValue);
}

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 500, 80, false);
    const textFrame = shape.addTextFrame("Effective formatting");
    const paragraph = textFrame.getParagraphs().get_Item(0);
    const portion = paragraph.getPortions().get_Item(0);

    // Определить унаследованные значения на двух разных уровнях.
    presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().setFontHeight(20);
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(28);

    printFontHeights("The portion inherits from the paragraph", presentation, paragraph, portion);

    // Локальное значение в части переопределяет оба унаследованных значения.
    portion.getPortionFormat().setFontHeight(36);
    printFontHeights("A local value overrides inherited values", presentation, paragraph, portion);

    // Изменение унаследованного значения не переопределяет существующее локальное значение.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(30);
    printFontHeights("The local value still has priority", presentation, paragraph, portion);

    // Сбросить локальное значение. Теперь часть снова наследует значение от абзаца.
    portion.getPortionFormat().setFontHeight(java.newFloat(Number.NaN));
    printFontHeights("The local value is cleared", presentation, paragraph, portion);

    // Сбросить значение абзаца. Теперь результат берётся из значения по умолчанию презентации.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(java.newFloat(Number.NaN));
    printFontHeights("The paragraph value is cleared", presentation, paragraph, portion);

    presentation.save("effective-properties.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Приоритет в этом примере: локальное форматирование части, затем форматирование абзаца, затем значение по умолчанию презентации. Другие объекты могут иметь разные цепочки наследования, но принцип тот же: более конкретное явное значение выигрывает, и [getEffective](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/portionformat/#getEffective) возвращает окончательный результат.

## **Получение эффективных свойств текста**

Форматирование текста распределено по нескольким объектам:

- [TextFrameFormat.getEffective](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/textframeformat/#getEffective) определяет свойства текстового кадра, такие как поля, привязка, автоподгонка и вертикальное направление текста.
- [TextStyle.getEffective](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/textstyle/#getEffective) определяет форматирование абзаца для каждого уровня стиля текста.
- [ParagraphFormat.getEffective](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/paragraphformat/#getEffective) определяет свойства абзаца, такие как выравнивание, отступы и маркировка.
- [PortionFormat.getEffective](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/portionformat/#getEffective) определяет свойства символов, такие как высота шрифта, шрифт, цвет, полужирный и курсив.

Для следующего примера файл `text-formatting.pptx` должен содержать как минимум один слайд и одну [AutoShape](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/autoshape/) с непустым текстовым кадром. AutoShape может находиться в любой позиции коллекции фигур; код ищет подходящий объект и проверяет его перед использованием.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

function hasNonEmptyText(shape) {
    if (shape.getTextFrame() == null) {
        return false;
    }
    if (shape.getTextFrame().getParagraphs().getCount() === 0) {
        return false;
    }
    return shape.getTextFrame().getParagraphs().get_Item(0).getPortions().getCount() > 0;
}

function findAutoShapeWithText(slide) {
    for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
        const candidate = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(candidate, "com.aspose.slides.AutoShape") && hasNonEmptyText(candidate)) {
            return candidate;
        }
    }
    return null;
}

const presentation = new aspose.slides.Presentation("text-formatting.pptx");
try {
    if (presentation.getSlides().size() === 0) {
        throw new Error("The presentation contains no slides.");
    }

    const shape = findAutoShapeWithText(presentation.getSlides().get_Item(0));
    if (shape == null) {
        throw new Error("The first slide must contain an AutoShape with non-empty text.");
    }

    const textFrame = shape.getTextFrame();
    const paragraph = textFrame.getParagraphs().get_Item(0);
    const portion = paragraph.getPortions().get_Item(0);

    const textFrameEffective = textFrame.getTextFrameFormat().getEffective();
    const paragraphEffective = paragraph.getParagraphFormat().getEffective();
    const portionEffective = portion.getPortionFormat().getEffective();

    console.log("Text frame margins:");
    console.log("  Left: " + textFrameEffective.getMarginLeft());
    console.log("  Top: " + textFrameEffective.getMarginTop());
    console.log("  Right: " + textFrameEffective.getMarginRight());
    console.log("  Bottom: " + textFrameEffective.getMarginBottom());
    console.log("Paragraph alignment: " + paragraphEffective.getAlignment());
    console.log("Font height: " + portionEffective.getFontHeight());
    console.log("Bold: " + portionEffective.getFontBold());

    const effectiveTextStyle = textFrame.getTextFrameFormat().getTextStyle().getEffective();
    for (let level = 0; level < 9; level++) {
        const levelEffective = effectiveTextStyle.getLevel(level);
        console.log("Level " + level + " indent: " + levelEffective.getIndent());
    }
} finally {
    presentation.dispose();
}
```

## **Получение эффективных 3D‑свойств**

[ThreeDFormat.getEffective](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/threedformat/#getEffective) возвращает один объект эффективных данных, группирующий все разрешённые 3D‑настройки. Его методы [getCamera](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/threedformat/#getCamera), [getLightRig](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/threedformat/#getLightRig), [getBevelTop](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/threedformat/#getBevelTop) и [getBevelBottom](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/threedformat/#getBevelBottom) предоставляют соответствующие эффективные данные. Чтение этих связанных настроек вместе упрощает понимание конечного 3D‑вида фигуры.

Для этого примера файл `shape-3d.pptx` должен содержать как минимум одну фигуру на первом слайде. Примените к этой фигуре настройки 3D‑камеры, освещения или скоса, если хотите, чтобы результат содержал значения, отличные от значений по умолчанию.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("shape-3d.pptx");
try {
    if (presentation.getSlides().size() === 0 || presentation.getSlides().get_Item(0).getShapes().size() === 0) {
        throw new Error("The first slide must contain a shape.");
    }

    const shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const threeDEffective = shape.getThreeDFormat().getEffective();

    console.log("Camera:");
    console.log("  Type: " + threeDEffective.getCamera().getCameraType());
    console.log("  Field of view: " + threeDEffective.getCamera().getFieldOfViewAngle());
    console.log("  Zoom: " + threeDEffective.getCamera().getZoom());

    console.log("Light rig:");
    console.log("  Type: " + threeDEffective.getLightRig().getLightType());
    console.log("  Direction: " + threeDEffective.getLightRig().getDirection());

    console.log("Top bevel:");
    console.log("  Type: " + threeDEffective.getBevelTop().getBevelType());
    console.log("  Width: " + threeDEffective.getBevelTop().getWidth());
    console.log("  Height: " + threeDEffective.getBevelTop().getHeight());
} finally {
    presentation.dispose();
}
```

## **Получение эффективного форматирования таблицы**

Форматирование таблицы может поступать из стиля таблицы и из форматов, применённых к всей таблице, колонке, строке или отдельной ячейке. При конфликте явно заданных заливок приоритет следующий: ячейка, строка, колонка и затем вся таблица. Эффективный формат ячейки — это окончательный формат, используемый для её отрисовки.

Для этого примера файл `table-formatting.pptx` должен содержать как минимум одну таблицу на первом слайде. У таблицы должно быть как минимум одна строка и один столбец. Код ищет объект [Table](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/table/) вместо того, чтобы предполагать, что `getShapes().get_Item(0)` является таблицей.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

function findTable(slide) {
    for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
        const shape = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.Table")) {
            return shape;
        }
    }
    return null;
}

const presentation = new aspose.slides.Presentation("table-formatting.pptx");
try {
    if (presentation.getSlides().size() === 0) {
        throw new Error("The presentation contains no slides.");
    }

    const table = findTable(presentation.getSlides().get_Item(0));
    if (table == null) {
        throw new Error("The first slide must contain a table.");
    }
    if (table.getRows().size() === 0 || table.getColumns().size() === 0) {
        throw new Error("The table must contain at least one cell.");
    }

    const tableEffective = table.getTableFormat().getEffective();
    const rowEffective = table.getRows().get_Item(0).getRowFormat().getEffective();
    const columnEffective = table.getColumns().get_Item(0).getColumnFormat().getEffective();
    const cellEffective = table.get_Item(0, 0).getCellFormat().getEffective();

    console.log("Table fill: " + tableEffective.getFillFormat().getFillType());
    console.log("Row fill: " + rowEffective.getFillFormat().getFillType());
    console.log("Column fill: " + columnEffective.getFillFormat().getFillType());
    console.log("Final cell fill: " + cellEffective.getFillFormat().getFillType());
} finally {
    presentation.dispose();
}
```

Если вам нужен цвет, а не только тип заливки, сначала проверьте эффективный [getFillType](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/fillformat/#getFillType), а затем используйте метод, соответствующий этому типу — например, [getSolidFillColor](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/fillformat/#getSolidFillColor) для сплошной заливки.

## **Повторное чтение эффективных данных после изменений**

Эффективные данные описывают иерархию форматирования на момент их разрешения. Вызовите `getEffective` снова после изменения любого элемента, участвующего в этой иерархии, включая:

- локальное форматирование объекта;
- значения по умолчанию абзаца или текстового кадра;
- стиль таблицы, таблицу, колонку, строку или формат ячейки;
- форматирование макета или шаблона слайда;
- данные темы или значения по умолчанию уровня презентации;
- макет или шаблон, назначенный слайду.

Не храните объект эффективных данных как постоянный снимок. Aspose.Slides может кэшировать некоторые эффективные данные внутри, и последующий вызов `getEffective` может обновить эти данные. Если необходимо сравнить значения до и после изменения, скопируйте нужные скалярные значения — например, высоту шрифта, цвет, выравнивание или ширину скоса — в свои переменные перед внесением изменения.

Чтобы изменить значение, обновите соответствующий локальный объект формата, а затем вызовите `getEffective` для проверки результата. Объекты эффективных данных сами по себе только для чтения.

## **FAQ**

**Как определить, какой уровень предоставил эффективное значение?**

Эффективные данные содержат окончательное значение, а не его источник. Просмотрите применимые локальные объекты, начиная с самого конкретного уровня и двигаясь наружу. Для текста это может быть часть, абзац, текстовый кадр, макет, шаблон, тема и значения по умолчанию презентации. Неопределённые значения, такие как `NaN` или `null`, указывают, что поиск продолжается на следующем уровне.

**Что происходит, если ни один уровень не определяет свойство?**

Aspose.Slides определяет соответствующее значение по умолчанию PowerPoint или библиотеки. Это разрешённое значение появляется в эффективных данных, даже если ни один локальный объект явно его не задаёт.

**Почему эффективное значение иногда совпадает с локальным?**

Локальное значение выиграло в расчёте наследования. Это ожидаемо, когда свойство явно задано в объекте и никакое более конкретное правило его не переопределяет.

**Когда следует использовать локальные данные вместо эффективных?**

Используйте локальные данные для просмотра или редактирования определённого уровня форматирования. Используйте эффективные данные, когда нужен окончательный вид после применения наследования, правил темы и соответствующих стилей. [Полный пример сравнения](#compare-local-inherited-and-effective-values) демонстрирует оба подхода в одном рабочем процессе.
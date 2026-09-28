---
title: Форматирование текста презентации в JavaScript
linktitle: Форматирование текста
type: docs
weight: 50
url: /ru/nodejs-java/text-formatting/
keywords:
- выравнивание абзаца
- стиль текста
- фон текста
- прозрачность текста
- межсимвольный интервал
- свойства шрифта
- семейство шрифтов
- вращение текста
- угол вращения
- текстовая рамка
- межстрочный интервал
- свойство автоподгонки
- привязка текстовой рамки
- табуляция текста
- язык по умолчанию
- PowerPoint
- OpenDocument
- презентация
- Node.js
- JavaScript
- Aspose.Slides
description: "Форматирование и стилизация текста в презентациях PowerPoint и OpenDocument с использованием Aspose.Slides для Node.js через Java. Настройка шрифтов, цветов, выравнивания и многое другое."
---
## **Обзор**

Эта статья показывает, как форматировать текст в презентациях PowerPoint и OpenDocument с помощью Aspose.Slides для Node.js через Java. Рассматриваются фоновые цвета, прозрачность, межсимвольный интервал, свойства шрифта, вращение, интервалы абзацев, поведение автоподгонки, привязка текста, табуляция и настройки языка.

Если не указано иное, примеры используют [sample.pptx](sample.pptx). Первая фигура на первом слайде — текстовое поле, и его первый абзац содержит текст, показанный ниже. Индексы слайдов и фигур начинаются с нуля. Примеры, выбирающие жирные части, используют эффективное форматирование, включая унаследованное жирное форматирование:

![Sample text](sample_text.png)

Чтобы найти и выделить буквальный текст или совпадения регулярных выражений, см. [Search and Replace Text](/slides/ru/nodejs-java/search-and-replace-text/).

## **Установить цвет фона текста**

Используйте [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/paragraphformat/#getDefaultPortionFormat--) чтобы задать цвет подсветки по умолчанию для абзаца, или [BasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/baseportionformat/#getHighlightColor--) для отдельных частей текста.

Следующий пример задаёт светло-серую подсветку как значение по умолчанию для первого абзаца. Явные цвета подсветки у отдельных частей имеют приоритет над этим значением по умолчанию:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Установить цвет подсветки для всего абзаца.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getHighlightColor().setColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));

    presentation.save("gray_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Результат:

![The gray paragraph](gray_paragraph.png)

Пример кода ниже демонстрирует, как задать цвет фона **для текстовых частей с жирным шрифтом**:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const portions = paragraph.getPortions();
    const portionCount = portions.getCount();

    for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
        const portion = portions.get_Item(portionIndex);
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // Установить цвет подсветки для текстовой части.
            portion.getPortionFormat().getHighlightColor().setColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));
        }
    }

    presentation.save("gray_text_portions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Результат:

![The gray text portions](gray_text_portions.png)

## **Выровнять абзацы текста**

Используйте [ParagraphFormat.setAlignment](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) чтобы задать выравнивание абзаца внутри текстовой рамки. Значение может быть центрировано, выровнено по левому, правому краю, выпрямлено и т.д.

Следующий пример кода показывает, как выровнять абзац **по центру**:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Установить выравнивание абзаца по центру.
    paragraph.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.Center);

    presentation.save("aligned_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Результат:

![The aligned paragraph](aligned_paragraph.png)

## **Установить прозрачность текста**

Прозрачность текста контролируется через альфа‑компонент цвета, назначенного [BasePortionFormat.getFillFormat](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/baseportionformat/#getFillFormat--). В примерах ниже `alpha = 50` — это значение альфа‑канала ARGB в диапазоне 0–255, а не процент прозрачности.

Пример кода ниже показывает, как применить прозрачность к **целому абзацу**:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const alpha = 50;
const transparentBlack = java.newInstanceSync("java.awt.Color", 0, 0, 0, alpha);
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const fillFormat = paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat();

    // Установить цвет заливки текста в прозрачный цвет.
    fillFormat.setFillType(java.newByte(aspose.slides.FillType.Solid));
    fillFormat.getSolidFillColor().setColor(transparentBlack);

    presentation.save("transparent_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Результат:

![The transparent paragraph](transparent_paragraph.png)

Следующий пример кода показывает, как применить прозрачность к **текстовым частям с жирным шрифтом**:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const alpha = 50;
const transparentBlack = java.newInstanceSync("java.awt.Color", 0, 0, 0, alpha);
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const portions = paragraph.getPortions();
    const portionCount = portions.getCount();

    for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
        const portion = portions.get_Item(portionIndex);
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            const fillFormat = portion.getPortionFormat().getFillFormat();

            // Установить прозрачность текстовой части.
            fillFormat.setFillType(java.newByte(aspose.slides.FillType.Solid));
            fillFormat.getSolidFillColor().setColor(transparentBlack);
        }
    }

    presentation.save("transparent_text_portions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Результат:

![The transparent text portions](transparent_text_portions.png)

## **Установить межсимвольный интервал текста**

Используйте [BasePortionFormat.setSpacing](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/baseportionformat/#setSpacing-float-) для увеличения или уменьшения интервала между символами в текстовом поле. В примерах добавляются 3 пункта интервала; отрицательные значения сжимают текст.

Следующий JavaScript‑код показывает, как расширить межсимвольный интервал в **целом абзаце**:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Примечание: используйте отрицательные значения, чтобы сжать межсимвольный интервал.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3); // Расширить межсимвольный интервал.

    presentation.save("character_spacing_in_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Результат:

![The character spacing in the paragraph](character_spacing_in_paragraph.png)

Пример кода ниже показывает, как расширить межсимвольный интервал в **текстовых частях с жирным шрифтом**:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const portions = paragraph.getPortions();
    const portionCount = portions.getCount();

    for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
        const portion = portions.get_Item(portionIndex);
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // Примечание: используйте отрицательные значения, чтобы сжать межсимвольный интервал.
            portion.getPortionFormat().setSpacing(3); // Расширить межсимвольный интервал.
        }
    }

    presentation.save("character_spacing_in_text_portions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Результат:

![The character spacing in the text portions](character_spacing_in_text_portions.png)

### **Отключить кернинг для определённых шрифтов**

В некоторых случаях текст, отрисованный Aspose.Slides, может выглядеть немного плотнее, чем тот же текст в PowerPoint. Это может происходить, потому что PowerPoint игнорирует данные кернинга для некоторых шрифтов, даже если шрифт содержит корректную информацию о кернинге и кернинг включён в настройках PowerPoint.

Чтобы в таких случаях сделать вывод более похожим на PowerPoint, можно отключить кернинг для текстовых частей, использующих затронутый шрифт. Установите [BasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/baseportionformat/#setKerningMinimalSize-float-) в значение, превышающее реальный размер шрифта. Этот пример требует файл «presentation.pptx» с текстовым полем в первой фигуре на первом слайде. Он проверяет эффективные имена шрифтов, включая унаследованные, и задаёт порог в 100 пунктов для частей, использующих Roboto. Это отключает кернинг для соответствующих частей, размер шрифта которых ниже 100 пунктов:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraphs = autoShape.getTextFrame().getParagraphs();
    const paragraphCount = paragraphs.getCount();
    const targetFont = "Roboto";

    for (let paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++) {
        const portions = paragraphs.get_Item(paragraphIndex).getPortions();
        const portionCount = portions.getCount();

        for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
            const portion = portions.get_Item(portionIndex);
            const portionFormat = portion.getPortionFormat().getEffective();
            const latinFont = portionFormat.getLatinFont();
            const eastAsianFont = portionFormat.getEastAsianFont();
            const complexScriptFont = portionFormat.getComplexScriptFont();

            if ((latinFont !== null && latinFont.getFontName() === targetFont) ||
                (eastAsianFont !== null && eastAsianFont.getFontName() === targetFont) ||
                (complexScriptFont !== null && complexScriptFont.getFontName() === targetFont)) {
                portion.getPortionFormat().setKerningMinimalSize(100);
            }
        }
    }

    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Для текста ниже порога данная настройка предотвращает кернинг и может помочь согласовать отображение Aspose.Slides с визуальным выводом PowerPoint для шрифтов, затронутых этим специфическим для PowerPoint поведением.

## **Управлять свойствами шрифта текста**

Свойства шрифта можно задать на уровне абзаца через [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/paragraphformat/#getDefaultPortionFormat--) или для отдельных частей через [PortionFormat](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/portionformat/).

Следующий пример задаёт для первого абзаца шрифт Times New Roman 12 пунктов с жирным, курсивом и пунктирным подчёркиванием. Явное форматирование отдельных частей имеет приоритет над этими значениями по умолчанию:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const defaultPortionFormat = paragraph.getParagraphFormat().getDefaultPortionFormat();

    // Установить свойства шрифта для абзаца.
    defaultPortionFormat.setFontHeight(12);
    defaultPortionFormat.setFontBold(java.newByte(aspose.slides.NullableBool.True));
    defaultPortionFormat.setFontItalic(java.newByte(aspose.slides.NullableBool.True));
    defaultPortionFormat.setFontUnderline(java.newByte(aspose.slides.TextUnderlineType.Dotted));
    defaultPortionFormat.setLatinFont(new aspose.slides.FontData("Times New Roman"));

    presentation.save("font_properties_for_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Результат:

![The font properties for the paragraph](font_properties_for_paragraph.png)

Следующий пример применяет Times New Roman 13 пунктов, курсив и пунктирное подчёркивание к частям, у которых эффективное форматирование является жирным:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const portions = paragraph.getPortions();
    const portionCount = portions.getCount();

    for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
        const portion = portions.get_Item(portionIndex);
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            const portionFormat = portion.getPortionFormat();

            // Установить свойства шрифта для текстовой части.
            portionFormat.setFontHeight(13);
            portionFormat.setFontItalic(java.newByte(aspose.slides.NullableBool.True));
            portionFormat.setFontUnderline(java.newByte(aspose.slides.TextUnderlineType.Dotted));
            portionFormat.setLatinFont(new aspose.slides.FontData("Times New Roman"));
        }
    }

    presentation.save("font_properties_for_text_portions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Результат:

![The font properties for text portions](font_properties_for_text_portions.png)

## **Установить вращение текста**

Используйте [TextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-) чтобы задать предопределённую ориентацию текста внутри фигуры.

Следующий пример кода задаёт ориентацию текста в фигуре как [TextVerticalType.Vertical270](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/textverticaltype/), что вращает текст **на 90 градусов против часовой стрелки**:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    autoShape.getTextFrame().getTextFrameFormat().setTextVerticalType(java.newByte(aspose.slides.TextVerticalType.Vertical270));

    presentation.save("text_rotation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Результат:

![The text rotation](text_rotation.png)

## **Установить пользовательский угол вращения для текстовых рамок**

Используйте [TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/textframeformat/#setRotationAngle-float-) чтобы задать кастомный угол вращения для [TextFrame](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/textframe/).

Пример кода ниже вращает текстовую рамку на 3 градуса по часовой стрелке внутри фигуры:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    autoShape.getTextFrame().getTextFrameFormat().setRotationAngle(3);

    presentation.save("custom_text_rotation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Результат:

![The custom text rotation](custom_text_rotation.png)

## **Установить межстрочный интервал абзацев**

Aspose.Slides предоставляет [ParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/paragraphformat/#setSpaceAfter-float-), [ParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/paragraphformat/#setSpaceBefore-float-) и [ParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/paragraphformat/#setSpaceWithin-float-) для управления интервалами абзацев. Эти свойства используются так:

* Задайте положительное значение, чтобы указать межстрочный интервал в процентах от высоты строки.  
* Задайте отрицательное значение, чтобы указать интервал в пунктах.

Следующий пример задаёт интервал внутри первого абзаца как 200 % от высоты строки (двойной интервал):

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);

    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getParagraphFormat().setSpaceWithin(200);

    presentation.save("line_spacing.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Результат:

![The line spacing within the paragraph](line_spacing.png)

## **Управлять переносом строк**

Правила переноса строк в абзаце полезны в узких текстовых блоках и презентациях, где смешивается латинский и восточноазиатский тексты. Следующие методы принадлежат [ParagraphFormat](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/paragraphformat/), поэтому они применяются ко всему абзацу:

- [setLatinLineBreak](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/paragraphformat/#setLatinLineBreak-byte-) управляет правилами переноса для латинского текста. В смешанном тексте изменение этого параметра может также изменить место переноса соседнего восточноазиатского текста и знаков пунктуации.  
- [setEastAsianLineBreak](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/paragraphformat/#setEastAsianLineBreak-byte-) управляет правилами переноса для восточноазиатского текста, включая ограничения на символы в начале и в конце строки.

Эти правила не заменяют [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/textframeformat/#setWrapText-byte-), который включает автоматический перенос внутри текстовой рамки. Они влияют на раскладку, когда происходит перенос; они не вставляют символы переноса строки. Явный перенос заставляет начать новую строку внутри абзаца независимо от доступной ширины.

Следующий автономный пример создаёт узкий текстовый блок, содержащий китайский и латинский тексты. Он явно задаёт обе опции переноса и сохраняет файл «line_breaking.pptx». Чтобы поэкспериментировать с любой из правил, измените соответствующее значение, оставив другое без изменений. В примере используется Arial 24 пт и SimSun, ширина рамки 160 пт и нулевые горизонтальные отступы. [TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/textframeformat/#setAutofitType-byte-) вызывается с [TextAutofitType.None](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/textautofittype/), чтобы размеры текста и рамки оставались фиксированными.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 160, 300);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    const textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setWrapText(java.newByte(aspose.slides.NullableBool.True));
    textFrame.getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.None));
    textFrame.getTextFrameFormat().setMarginLeft(0);
    textFrame.getTextFrameFormat().setMarginRight(0);

    const paragraph = textFrame.getParagraphs().get_Item(0);
    paragraph.setText("中文排版测试，PowerPoint 中文演示。");

    const format = paragraph.getParagraphFormat();
    format.setAlignment(aspose.slides.TextAlignment.Left);
    format.getDefaultPortionFormat().setFontHeight(24);
    const latinFont = new aspose.slides.FontData("Arial");
    format.getDefaultPortionFormat().setLatinFont(latinFont);
    const eastAsianFont = new aspose.slides.FontData("SimSun");
    format.getDefaultPortionFormat().setEastAsianFont(eastAsianFont);
    format.getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const textColor = java.getStaticFieldValue("java.awt.Color", "BLACK");
    format.getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(textColor);
    format.setLatinLineBreak(java.newByte(aspose.slides.NullableBool.False));
    format.setEastAsianLineBreak(java.newByte(aspose.slides.NullableBool.True));

    presentation.save("line_breaking.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Управлять висячей пунктуацией**

[ParagraphFormat.setHangingPunctuation](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/paragraphformat/#setHangingPunctuation-byte-) позволяет пунктуации, которой это разрешено, выступать за правый край строки вместо того, чтобы занимать следующую строку. Это применяется ко всему абзацу и отличается от висячего отступа.

Следующий автономный пример включает висячую пунктуацию в текстовой рамке шириной 100 пт и сохраняет файл «hanging_punctuation.pptx». При Arial 24 пт и нулевых горизонтальных отступах конечная точка остаётся после слова «sentence» и выступает за правый край текста. Установите свойство в [NullableBool.False](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/nullablebool/), чтобы сравнить: при этих настройках точка занимает отдельную строку. Перенос включён, а автоподгонка отключена, чтобы зафиксировать доступную ширину.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 100, 200);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    const textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setWrapText(java.newByte(aspose.slides.NullableBool.True));
    textFrame.getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.None));
    textFrame.getTextFrameFormat().setMarginLeft(0);
    textFrame.getTextFrameFormat().setMarginRight(0);

    const paragraph = textFrame.getParagraphs().get_Item(0);
    paragraph.setText("Simple text, next sentence.");

    const format = paragraph.getParagraphFormat();
    format.setAlignment(aspose.slides.TextAlignment.Left);
    format.getDefaultPortionFormat().setFontHeight(24);
    const latinFont = new aspose.slides.FontData("Arial");
    format.getDefaultPortionFormat().setLatinFont(latinFont);
    format.getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const textColor = java.getStaticFieldValue("java.awt.Color", "BLACK");
    format.getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(textColor);
    format.setHangingPunctuation(java.newByte(aspose.slides.NullableBool.True));

    presentation.save("hanging_punctuation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Не каждый знак пунктуации может "висеть". Видимый результат зависит от наличия шрифта и раскладки: изменение шрифта, ширины, отступов или настроек автоподгонки может убрать визуальную разницу.

## **Установить тип автоподгонки для текстовых рамок**

[TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/textframeformat/#setAutofitType-byte-) определяет, как текст ведёт себя, когда превышает границы своего контейнера. Используйте его, чтобы контролировать, будет ли текст сжиматься, выходить за пределы или автоматически изменять размер фигуры. Следующий пример настраивает фигуру так, чтобы она изменяла размер под текст, и сохраняет результат в файл «autofit_type.pptx».

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    autoShape.getTextFrame().getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.Shape));

    presentation.save("autofit_type.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Чтобы подсчитать строки после автоматического переноса и увидеть, как меняется ширина текста или фигуры, см. [Count Rendered Lines](/slides/ru/nodejs-java/manage-paragraph/). Само количество строк не указывает, выходит ли текст за границы контейнера.

## **Установить привязку текстовых рамок**

[TextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/textframeformat/#setAnchoringType-byte-) определяет, как текст размещается вертикально внутри фигуры, например, вверху, посередине или внизу. Следующий пример привязывает текст к нижней части первой фигуры и сохраняет результат в файл «text_anchor.pptx».

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    autoShape.getTextFrame().getTextFrameFormat().setAnchoringType(java.newByte(aspose.slides.TextAnchorType.Bottom));

    presentation.save("text_anchor.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Установить табуляцию текста**

Используйте [ParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/paragraphformat/#setDefaultTabSize-float-) и [ParagraphFormat.getTabs](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/paragraphformat/#getTabs--) для настройки табуляций в абзаце. Следующий пример задаёт интервал табуляции по умолчанию 100 пт и добавляет табуляцию, выровненную по левому краю, на позиции 30 пт. Эти настройки влияют на текст, содержащий символы табуляции.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);

    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getParagraphFormat().setDefaultTabSize(100);
    paragraph.getParagraphFormat().getTabs().add(30, java.newByte(aspose.slides.TabAlignment.Left));

    presentation.save("paragraph_tabs.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Результат:

![The paragraph tabs](paragraph_tabs.png)

## **Установить язык проверки орфографии**

Aspose.Slides предоставляет [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/baseportionformat/#setLanguageId-java.lang.String-), позволяющий задать язык проверки орфографии для части текста. Язык проверки определяет, какой язык будет использоваться для проверки орфографии и грамматики в PowerPoint.

Следующий пример требует файл «presentation.pptx» с текстовым полем в первой фигуре на первом слайде и как минимум один абзац. Он заменяет содержимое первого абзаца на «1。», задаёт шрифт SimSun и назначает язык проверки упрощённого китайского (`zh-CN`). Затем сохраняет результат в файл «proofing_language.pptx»:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);

    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    const font = new aspose.slides.FontData("SimSun");
    const textPortion = new aspose.slides.Portion();
    textPortion.getPortionFormat().setComplexScriptFont(font);
    textPortion.getPortionFormat().setEastAsianFont(font);
    textPortion.getPortionFormat().setLatinFont(font);

    // Установить идентификатор языка проверки орфографии.
    textPortion.getPortionFormat().setLanguageId("zh-CN");

    textPortion.setText("1。");
    paragraph.getPortions().add(textPortion);

    presentation.save("proofing_language.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Установить язык по умолчанию**

Используйте [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) чтобы задать язык по умолчанию для текста, создаваемого при загрузке или создании презентации. Следующий пример создаёт презентацию с английским (США) в качестве языка текста по умолчанию, добавляет текстовое поле и выводит `en-US` для первой части текста.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

const presentation = new aspose.slides.Presentation(loadOptions);
try {
    const slide = presentation.getSlides().get_Item(0);

    // Добавить новую прямоугольную фигуру с текстом.
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 150, 50);
    shape.getTextFrame().setText("Sample text");

    // Проверить язык первой части текста.
    const portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    console.log(portion.getPortionFormat().getLanguageId());
} finally {
    presentation.dispose();
}
```

## **Установить стиль текста по умолчанию**

Чтобы применить форматирование текста по умолчанию на уровне презентации, используйте [Presentation.getDefaultTextStyle](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/#getDefaultTextStyle--).

Следующий пример задаёт 14‑пунктовый жирный шрифт как значение по умолчанию для абзацев первого уровня в новой презентации и сохраняет её в файл «default_text_style.pptx». Текст может наследовать эти настройки, если только более конкретное форматирование не переопределит их.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    // Получить формат абзаца верхнего уровня.
    const paragraphFormat = presentation.getDefaultTextStyle().getLevel(0);

    if (paragraphFormat !== null) {
        paragraphFormat.getDefaultPortionFormat().setFontHeight(14);
        paragraphFormat.getDefaultPortionFormat().setFontBold(java.newByte(aspose.slides.NullableBool.True));
    }

    presentation.save("default_text_style.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Извлечь текст с эффектом All-Caps**

В PowerPoint применение эффекта **All Caps** к шрифту делает текст заглавным на слайде, даже если он был введён в нижнем регистре. При получении такой части текста с помощью Aspose.Slides библиотека возвращает текст точно так, как он был введён. Чтобы сопоставить отображаемый текст, проверьте [TextCapType](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/textcaptype/) и преобразуйте возвращённую строку в верхний регистр, когда значение равно `All`.

Этот пример требует файл «sample2.pptx» с текстовым полем в первой фигуре на первом слайде. В первой части первого абзаца содержится «Hello, Aspose!», к которому применён эффект All Caps, как показано ниже.

![The All Caps effect](all_caps_effect.png)

Пример кода ниже показывает, как извлечь текст с применённым эффектом **All Caps**:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("sample2.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    
    const autoShape = slide.getShapes().get_Item(0);
    const textPortion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);

    console.log("Original text: " + textPortion.getText());

    const textFormat = textPortion.getPortionFormat().getEffective();
    if (textFormat.getTextCapType() === aspose.slides.TextCapType.All) {
        const text = textPortion.getText().toUpperCase();
        console.log("All-Caps effect: " + text);
    }
} finally {
    presentation.dispose();
}
```

Вывод:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **FAQ**

**Как изменить текст в таблице на слайде?**

Чтобы изменить текст в таблице на слайде, используйте [Table](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/table/). Пройдитесь по ячейкам и обновите каждую через [Cell.getTextFrame](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/cell/#getTextFrame--) и форматирование абзацев через [Paragraph.getParagraphFormat](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/paragraph/#getParagraphFormat--).

**Как применить градиентный цвет к тексту на слайде PowerPoint?**

Чтобы применить градиентный цвет к тексту, используйте [BasePortionFormat.getFillFormat](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/baseportionformat/#getFillFormat--). Установите [FillFormat.setFillType](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/fillformat/#setFillType-byte-) в значение [FillType.Gradient](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/filltype/) и настройте точки градиента, направление и прозрачность.
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
- интервал между символами
- свойства шрифта
- семейство шрифтов
- вращение текста
- угол вращения
- текстовый кадр
- межстрочный интервал
- свойство автоподгонки
- привязка текстового кадра
- табуляция текста
- язык по умолчанию
- PowerPoint
- OpenDocument
- презентация
- Node.js
- JavaScript
- Aspose.Slides
description: "Форматирование и стилизация текста в презентациях PowerPoint и OpenDocument с помощью Aspose.Slides для Node.js через Java. Настраивайте шрифты, цвета, выравнивание и многое другое."
---
## **Обзор**

В этой статье показано, как форматировать текст в презентациях PowerPoint и OpenDocument с помощью Aspose.Slides для Node.js через Java. Рассматриваются фоновые цвета, прозрачность, интервал между символами, свойства шрифта, вращение, интервал между абзацами, поведение автоподгонки, привязка текста, табуляция и языковые настройки.

Если не указано иначе, примеры используют [sample.pptx](sample.pptx). Первая фигура на первом слайде — это текстовое поле, а его первый абзац содержит показанный ниже текст. Индексы слайдов и фигур начинаются с нуля. Примеры, выделяющие жирные части, используют эффективное форматирование, включая унаследованное жирное форматирование:

![Пример текста](sample_text.png)

Чтобы найти и выделить буквальный текст или совпадения по регулярному выражению, см. [Search and Replace Text](/slides/ru/nodejs-java/search-and-replace-text/).

## **Установка фонового цвета текста**

Используйте [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) для задания цвета подсветки по умолчанию для абзаца или [BasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#getHighlightColor) для отдельных частей текста.

Следующий пример задает светло-серую подсветку как значение по умолчанию для первого абзаца. Явные цвета подсветки у отдельных частей имеют приоритет над этим значением по умолчанию:

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

![Серый абзац](gray_paragraph.png)

Ниже пример кода, демонстрирующий, как установить фоновый цвет для **частей текста с полужирным шрифтом**:

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
            // Установить цвет подсветки для части текста.
            portion.getPortionFormat().getHighlightColor().setColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));
        }
    }

    presentation.save("gray_text_portions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Результат:

![Серые части текста](gray_text_portions.png)

## **Выравнивание абзацев текста**

Используйте [ParagraphFormat.setAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setAlignment) для установки выравнивания абзаца внутри текстового кадра. Значение может быть центрированным, выровненным по левому краю, по правому краю, по ширине и т.д.

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

![Выровненный абзац](aligned_paragraph.png)

## **Выравнивание шрифтов внутри строки**

Используйте [ParagraphFormat.setFontAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setFontAlignment) для вертикального выравнивания частей текста с разными размерами шрифта внутри строки. Эта настройка применяется к всему абзацу и управляет выравниванием внутри каждой его строки.

Следующий автономный пример создает четыре подписанных текстовых поля на одном слайде. Каждый абзац содержит один и тот же текст размером 18, 36 и 54 пункта с разным выравниванием шрифта. Используются Arial, отключены автоподгонка и перенос, а размеры текстовых кадров достаточны для одной строки.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const alignments = [aspose.slides.FontAlignment.Baseline, aspose.slides.FontAlignment.Top, aspose.slides.FontAlignment.Center, aspose.slides.FontAlignment.Bottom];
    const alignmentNames = ["Baseline", "Top", "Center", "Bottom"];
    const fontSizes = [18, 36, 54];

    for (let i = 0; i < alignments.length; i++) {
        const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 30, 20 + i * 130, 660, 120);
        shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

        const textFrame = shape.getTextFrame();
        textFrame.getTextFrameFormat().setAnchoringType(java.newByte(aspose.slides.TextAnchorType.Top));
        textFrame.getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.None));
        textFrame.getTextFrameFormat().setWrapText(java.newByte(aspose.slides.NullableBool.False));

        const label = textFrame.getParagraphs().get_Item(0);
        label.setText(alignmentNames[i]);
        label.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.Left);
        label.getParagraphFormat().getDefaultPortionFormat().setFontHeight(14);
        label.getParagraphFormat().getDefaultPortionFormat().setLatinFont(new aspose.slides.FontData("Arial"));
        label.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        label.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));

        const paragraph = new aspose.slides.Paragraph();
        paragraph.getParagraphFormat().setFontAlignment(alignments[i]);
        paragraph.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.Left);
        paragraph.getParagraphFormat().getDefaultPortionFormat().setLatinFont(new aspose.slides.FontData("Arial"));
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));

        for (const fontSize of fontSizes) {
            const portion = new aspose.slides.Portion("Ag ");
            portion.getPortionFormat().setFontHeight(fontSize);
            paragraph.getPortions().add(portion);
        }

        textFrame.getParagraphs().add(paragraph);
    }

    presentation.save("font_alignment.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Результат:

![Сравнение базовой линии, верхнего, центрального и нижнего выравнивания шрифта при смешанных размерах шрифта](font_alignment.png)

Выравнивание шрифта использует метрики шрифта, поэтому видимые границы отдельных букв не всегда совпадают точно. Пример включает заглавную букву и нисходящий элемент, чтобы показать разницу между базовой линией и нижним выравниванием. Доступность шрифта и его замена, используемые символы и разница в размерах шрифта влияют на результат. Размеры кадров, поля, межстрочный интервал, перенос и автоподгонка также влияют на разметку; при сравнении режимов используйте одинаковые шрифты и настройки разметки.

Эта настройка отличается от [ParagraphFormat.setAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setAlignment), контролирующей горизонтальное выравнивание абзаца, и от [TextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setAnchoringType), которая позиционирует текстовый блок вертикально внутри фигуры. Форматирование надстрочного и нижстрочного текста через [BasePortionFormat.setEscapement](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setEscapement) сдвигает отдельные части относительно базовой линии, а не задает выравнивание шрифта для линий абзаца.

## **Установка прозрачности текста**

Прозрачность текста управляется альфа‑компонентой цвета, назначенного [BasePortionFormat.getFillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#getFillFormat). В примерах ниже `alpha = 50` — это значение альфа‑канала ARGB в диапазоне 0–255, а не процент прозрачности.

Ниже пример кода, показывающий, как применить прозрачность к **всему абзацу**:

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

![Прозрачный абзац](transparent_paragraph.png)

Следующий пример кода показывает, как применить прозрачность к **частям текста с полужирным шрифтом**:

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

            // Установить прозрачность части текста.
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

![Прозрачные части текста](transparent_text_portions.png)

## **Установка интервала между символами текста**

Используйте [BasePortionFormat.setSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setSpacing) для расширения или сжатия интервала между символами в текстовом поле. Примеры добавляют 3 пункта интервала; отрицательные значения сжимают текст.

Следующий JavaScript‑код показывает, как расширить интервал между символами в **всём абзаце**:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Примечание: используйте отрицательные значения для сжатия интервала между символами.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3); // Расширить интервал между символами.

    presentation.save("character_spacing_in_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Результат:

![Интервал между символами в абзаце](character_spacing_in_paragraph.png)

Ниже пример кода, показывающий, как расширить интервал между символами в **частях текста с полужирным шрифтом**:

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
            // Примечание: используйте отрицательные значения для сжатия интервала между символами.
            portion.getPortionFormat().setSpacing(3); // Расширить интервал между символами.
        }
    }

    presentation.save("character_spacing_in_text_portions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Результат:

![Интервал между символами в частях текста](character_spacing_in_text_portions.png)

### **Отключение кернинга для конкретных шрифтов**

В некоторых случаях текст, отрисованный Aspose.Slides, может выглядеть слегка более плотно, чем тот же текст в PowerPoint. Это может происходить, потому что PowerPoint может игнорировать данные кернинга для определённых шрифтов, даже если шрифт содержит корректную информацию о кернинге и кернинг включён в настройках PowerPoint.

Чтобы приблизить результат к PowerPoint в таких случаях, можно отключить кернинг для частей текста, использующих проблемный шрифт. Установите [BasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setKerningMinimalSize) в значение, превышающее фактический размер шрифта. Этот пример требует файла "presentation.pptx" с текстовым полем в качестве первой фигуры на первом слайде. Он проверяет эффективные имена шрифтов, включая унаследованные, и задаёт порог 100 пунктов для частей, использующих Roboto. Это отключает кернинг для соответствующих частей с размером шрифта ниже 100 пунктов:

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

Для соответствующего текста ниже порога эта настройка препятствует применению кернинга и может помочь согласовать рендеринг Aspose.Slides с визуальным выводом PowerPoint для шрифтов, затронутых этим специфическим поведением PowerPoint.

## **Управление свойствами шрифта текста**

Свойства шрифта можно задать на уровне абзаца через [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) или для отдельных частей через [PortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portionformat/).

Следующий пример задаёт для первой части абзаца шрифт Times New Roman 12 пунктов с полужирным, курсивом и пунктирным подчёркиванием. Явное форматирование отдельных частей имеет приоритет над этими значениями по умолчанию.

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

![Свойства шрифта для абзаца](font_properties_for_paragraph.png)

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

            // Установить свойства шрифта для части текста.
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

![Свойства шрифта для частей текста](font_properties_for_text_portions.png)

## **Контроль нормализации высоты текста**

Используйте [BasePortionFormat.setNormaliseHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setNormaliseHeight) при воспроизведении типографии шаблона или исследовании различий в высоте символов. В PowerPoint включение нормализации растягивает или сжимает отдельные символы по вертикали, чтобы они имели одинаковую видимую высоту внутри части текста. Это не гарантирует одинаковую высоту текста между разными шрифтами.

Установите свойство в [NullableBool.True или False](https://reference.aspose.com/slides/nodejs-java/aspose.slides/nullablebool/) для явного включения или отключения нормализации. `NullableBool.NotDefined` оставляет локальную настройку неопределённой, позволяя части наследовать значение, например, от [getDefaultPortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) абзаца. Это не означает `False`. Используйте [PortionFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portionformat/#getEffective) и читайте [IBasePortionFormatEffectiveData.getNormaliseHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformateffectivedata/#getNormaliseHeight--) для получения разрешённого булевого значения.

Следующий автономный пример требует установленного **Arial**. Он создаёт два текстовых блока, содержащих одинаковые заглавные буквы, строчные буквы, нисходящие элементы и акцентированные символы размером 54 пункта. Оба абзаца включают нормализацию по умолчанию. Верхняя часть явно отключает её; нижняя наследует. Размеры кадров, поля и межабзацевый интервал одинаковы, перенос и автоподгонка отключены для сохранения сравнимости. Пример выводит `False: false` и `NotDefined: true`, затем сохраняет "text_height_normalization.pptx".

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const settings = [aspose.slides.NullableBool.False, aspose.slides.NullableBool.NotDefined];
    const settingNames = ["False", "NotDefined"];

    for (let i = 0; i < settings.length; i++) {
        const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 30, 60 + i * 200, 660, 150);
        shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

        const textFrame = shape.getTextFrame();
        textFrame.setText("Hxgjpq ÅÉ 0123");
        textFrame.getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.None));
        textFrame.getTextFrameFormat().setWrapText(java.newByte(aspose.slides.NullableBool.False));
        textFrame.getTextFrameFormat().setAnchoringType(java.newByte(aspose.slides.TextAnchorType.Top));
        textFrame.getTextFrameFormat().setMarginTop(0);
        textFrame.getTextFrameFormat().setMarginLeft(0);

        const paragraph = textFrame.getParagraphs().get_Item(0);
        paragraph.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.Left);
        paragraph.getParagraphFormat().setSpaceBefore(0);
        paragraph.getParagraphFormat().setSpaceAfter(0);
        paragraph.getParagraphFormat().setSpaceWithin(100);
        paragraph.getParagraphFormat().getDefaultPortionFormat().setNormaliseHeight(java.newByte(aspose.slides.NullableBool.True));

        const portion = paragraph.getPortions().get_Item(0);
        const font = new aspose.slides.FontData("Arial");
        portion.getPortionFormat().setLatinFont(font);
        portion.getPortionFormat().setFontHeight(54);
        portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        const textColor = java.getStaticFieldValue("java.awt.Color", "BLACK");
        portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(textColor);
        portion.getPortionFormat().setNormaliseHeight(java.newByte(settings[i]));

        console.log(settingNames[i] + ": " + portion.getPortionFormat().getEffective().getNormaliseHeight());
    }

    presentation.save("text_height_normalization.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Сравнение ниже экспортировано из сохранённой презентации. В верхнем ряду нормализация отключена (`False`); в нижнем ряду она наследуется (`NotDefined` → `True`). Оставьте установленным Arial, чтобы воспроизвести вид.

![Текст Arial 54 пункта с отключённой нормализацией сверху и наследуемой нормализацией снизу](text_height_normalization.png)

Нормализация изменяет высоту символов без изменения назначенного значения [getFontHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#getFontHeight), которое задаёт размер шрифта в пунктах. Межстрочный интервал абзаца управляется [setSpaceWithin](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setSpaceWithin), а [setAutofitType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setAutofitType) текстового кадра контролирует, как текст или его контейнер регулируются для подгонки. Эти настройки служат разным целям и могут независимо влиять на общую разметку. Подробнее о форматировании абзацев и наследовании см. в разделе [Manage Paragraph](/slides/ru/nodejs-java/manage-paragraph/).

## **Применение и удаление зачёркивания**

Используйте [BasePortionFormat.setStrikethroughType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setStrikethroughType) для части текста, чтобы отобразить исправления, отменённые термины или прежние цены без удаления оригинального текста. Установите в [TextStrikethroughType.Single или Double](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textstrikethroughtype/) для одной или двух линий через текст.

Чтобы удалить зачёркивание, передайте [TextStrikethroughType.None](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textstrikethroughtype/#None). Это явно отключает эффект, даже если окружающее форматирование задаёт зачёркивание. В отличие от этого, [TextStrikethroughType.NotDefined](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textstrikethroughtype/#NotDefined) оставляет локальную настройку неопределённой, позволяя части наследовать форматирование, например, от абзаца. Это не гарантирует удаление зачёркивания. Используйте [PortionFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portionformat/#getEffective) для чтения результирующего форматирования, включая унаследованные значения.

Следующий автономный пример создаёт три сравнения цен. Каждый абзац имеет отдельные части для названия, предыдущей цены и текущей цены, поэтому только предыдущая цена подвергается изменению. В первой строке применено и затем удалено зачёркивание; остальные строки сохраняют одиночное и двойное зачёркивание. Изменение этой настройки сохраняет текст и его остальное форматирование, включая полужирную предыдущую цену.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 620, 220);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getTextFrame().getParagraphs().clear();

    const labels = ["None: ", "Single: ", "Double: "];

    for (const label of labels) {
        const paragraph = new aspose.slides.Paragraph();
        paragraph.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.Left);
        paragraph.getParagraphFormat().setSpaceAfter(20);

        const format = paragraph.getParagraphFormat().getDefaultPortionFormat();
        format.setFontHeight(28);
        const font = new aspose.slides.FontData("Arial");
        format.setLatinFont(font);
        format.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        const textColor = java.getStaticFieldValue("java.awt.Color", "BLACK");
        format.getFillFormat().getSolidFillColor().setColor(textColor);

        const labelPortion = new aspose.slides.Portion(label);
        paragraph.getPortions().add(labelPortion);

        const previousPrice = new aspose.slides.Portion("$100");
        previousPrice.getPortionFormat().setFontBold(java.newByte(aspose.slides.NullableBool.True));
        paragraph.getPortions().add(previousPrice);
        const currentPrice = new aspose.slides.Portion(" → $80");
        paragraph.getPortions().add(currentPrice);

        shape.getTextFrame().getParagraphs().add(paragraph);
    }

    const paragraphs = shape.getTextFrame().getParagraphs();

    // Применить зачёркивание, затем явно удалить его у первой предыдущей цены.
    paragraphs.get_Item(0).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(java.newByte(aspose.slides.TextStrikethroughType.Single));
    paragraphs.get_Item(0).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(java.newByte(aspose.slides.TextStrikethroughType.None));

    paragraphs.get_Item(1).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(java.newByte(aspose.slides.TextStrikethroughType.Single));
    paragraphs.get_Item(2).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(java.newByte(aspose.slides.TextStrikethroughType.Double));

    presentation.save("strikethrough.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Результат сверху вниз: без зачёркивания, одиночное зачёркивание и двойное зачёркивание.

![Предыдущие цены без зачёркивания, с одиночным зачёркиванием и с двойным зачёркиванием](strikethrough.png)

## **Установка вращения текста**

Используйте [TextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType) для задания предопределённой ориентации текста внутри фигуры.

Следующий пример кода задаёт ориентацию текста в фигуре как [TextVerticalType.Vertical270](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textverticaltype/), что вращает текст **на 90 градусов против часовой стрелки**:

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

![Вращение текста](text_rotation.png)

## **Отображение цифр рядом в вертикальном тексте**

Чтобы оставить двузначное число вместе в вертикальной японской метке, поместите обе цифры в одну часть текста и вызовите [BasePortionFormat.setKumimoji](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setKumimoji) для форматирования этой части. В примере используется [TextVerticalType.EastAsianVertical](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textverticaltype/#EastAsianVertical) и 40‑пунктовый MS Gothic для обеих меток. Единственное различие — значение [NullableBool](https://reference.aspose.com/slides/nodejs-java/aspose.slides/nullablebool/), передаваемое числовой части.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const font = new aspose.slides.FontData("MS Gothic");
    const textColor = java.getStaticFieldValue("java.awt.Color", "BLACK");
    const settings = [aspose.slides.NullableBool.True, aspose.slides.NullableBool.False];
    let x = 120;

    for (const kumimoji of settings) {
        const label = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, x, 48, 120, 420);
        label.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        label.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

        const frame = label.addTextFrame("");
        frame.getTextFrameFormat().setTextVerticalType(java.newByte(aspose.slides.TextVerticalType.EastAsianVertical));

        const paragraph = frame.getParagraphs().get_Item(0);
        const format = paragraph.getParagraphFormat().getDefaultPortionFormat();
        format.setLatinFont(font);
        format.setEastAsianFont(font);
        format.setFontHeight(40);
        format.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        format.getFillFormat().getSolidFillColor().setColor(textColor);

        const digits = new aspose.slides.Portion("12");
        digits.getPortionFormat().setKumimoji(java.newByte(kumimoji));

        const portions = paragraph.getPortions();
        portions.clear();
        portions.add(new aspose.slides.Portion("令和"));
        portions.add(digits);
        portions.add(new aspose.slides.Portion("年"));
        x += 240;
    }
    presentation.save("vertical_date.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

В PowerPoint левая метка (`True`) показывает цифры вертикально и рядом между 和 и 年. Правая метка (`False`) вращает пару цифр на 90 градусов по часовой стрелке. Окружающие японские символы остаются вертикальными в обеих метках.

![Сравнение вертикальных дат в PowerPoint с вертикальными цифрами слева и вращёнными цифрами справа](vertical_date.png)

## **Установка пользовательского вращения для текстовых кадров**

Используйте [TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setRotationAngle) для задания пользовательского угла вращения [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/).

Ниже пример кода, вращающего текстовый кадр на 3 градуса по часовой стрелке внутри фигуры:

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

![Пользовательское вращение текста](custom_text_rotation.png)

## **Установка межстрочного интервала абзацев**

Aspose.Slides предоставляет [ParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setSpaceAfter), [ParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setSpaceBefore) и [ParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setSpaceWithin) для управления интервалом абзацев. Эти свойства используются так:

* Положительное значение задаёт межстрочный интервал в процентах от высоты строки.
* Отрицательное значение задаёт межстрочный интервал в пунктах.

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

![Межстрочный интервал внутри абзаца](line_spacing.png)

## **Управление разрывом строк**

Правила разрыва строк абзаца полезны в узких текстовых блоках и презентациях, где смешан латинский и восточноазиатский текст. Ниже перечисленные методы принадлежат [ParagraphFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/), поэтому они применяются ко всему абзацу:

- [setLatinLineBreak](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setLatinLineBreak) управляет правилами разрыва латинского текста. В смешанном тексте изменение этого параметра может также влиять на перенос соседнего восточноазиатского текста и пунктуации.
- [setEastAsianLineBreak](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setEastAsianLineBreak) управляет правилами разрыва восточноазиатского текста, включая ограничения на символы в начале и конце строки.

Эти правила не заменяют [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setWrapText), который включает автоматический перенос внутри текстового кадра. Они влияют на разметку, когда происходит перенос; они не вставляют символы разрыва строк. Явный разрыв строки принудительно создаёт новую строку внутри абзаца независимо от доступной ширины.

Следующий автономный пример создаёт узкий текстовый блок с китайским и латинским текстом. Он явно задаёт оба параметра разрыва и сохраняет "line_breaking.pptx". Чтобы поэкспериментировать с любым из правил, измените соответствующее значение, оставив другое неизменным. В примере используется Arial 24 пункта и SimSun, ширина кадра 160 пунктов и нулевые горизонтальные поля текстового кадра. [TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setAutofitType) вызывается с [TextAutofitType.None](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textautofittype/), чтобы размеры текста и кадра оставались фиксированными.

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

## **Управление «висучей» пунктуацией**

[ParagraphFormat.setHangingPunctuation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setHangingPunctuation) позволяет допускаемой пунктуации выходить за правый край строки вместо того, чтобы занимать следующую строку. Применяется ко всему абзацу и отличается от «висущего» отступа.

Следующий автономный пример включает «висучую» пунктуацию в текстовом кадре шириной 100 пунктов и сохраняет "hanging_punctuation.pptx". При Arial 24 пункта и нулевых горизонтальных полях последняя точка остаётся после слова «sentence» и выступает за правый край текста. Установите свойство в [NullableBool.False](https://reference.aspose.com/slides/nodejs-java/aspose.slides/nullablebool/) для сравнения: при этих настройках точка занимает отдельную строку. Перенос включён, автоподгонка отключена, чтобы фиксировать доступную ширину.

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

Не каждый знак пунктуации может «висеть». Описанные выше [условия шрифта и разметки](#control-line-breaking) также применимы к этому сравнению: изменение шрифта, доступной ширины, полей или автоподгонки может удалить видимую разницу.

## **Установка типа автоподгонки для текстовых кадров**

[TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setAutofitType) определяет, как текст ведёт себя, когда превышает границы своего контейнера. Используйте его, чтобы управлять тем, будет ли текст сжиматься, выходить за пределы или автоматически менять размер фигуры. Следующий пример настраивает фигуру на изменение размера под текст и сохраняет результат в "autofit_type.pptx".

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

Чтобы подсчитать строки после автоматического переноса и увидеть, как меняются ширина текста или фигуры, см. [Count Rendered Lines](/slides/ru/nodejs-java/manage-paragraph/). Само количество строк не указывает, выходит ли текст за границы контейнера.

## **Установка привязки текстовых кадров**

[TextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setAnchoringType) определяет, как текст позиционируется вертикально внутри фигуры, например, вверху, посередине или внизу. Следующий пример привязывает текст к нижней части первой фигуры и сохраняет результат в "text_anchor.pptx".

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

## **Установка табуляции текста**

Используйте [ParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setDefaultTabSize) и [ParagraphFormat.getTabs](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#getTabs) для настройки табуляций в абзаце. Следующий пример задаёт интервал табуляций по умолчанию 100 пунктов и добавляет левый таб‑стоп на 30 пунктов. Эти настройки влияют на текст, содержащий символы табуляции.

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

![Табуляции абзаца](paragraph_tabs.png)

## **Установка языка проверки правописания**

Aspose.Slides предоставляет [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setLanguageId), позволяющий задать язык проверки правописания для части текста. Язык проверки определяет язык, используемый для проверки орфографии и грамматики в PowerPoint.

Следующий пример требует "presentation.pptx" с текстовым полем в качестве первой фигуры на первом слайде и как минимум одного абзаца. Он заменяет содержимое первого абзаца на «1。», задаёт SimSun в качестве шрифта и назначает язык проверки Simplified Chinese (`zh-CN`). Сохраняет результат в "proofing_language.pptx":

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

    // Установить идентификатор языка проверки правописания.
    textPortion.getPortionFormat().setLanguageId("zh-CN");

    textPortion.setText("1。");
    paragraph.getPortions().add(textPortion);

    presentation.save("proofing_language.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Копирование метаданных языка**

При копировании многоязычного текста из шаблона сохраняйте как [BasePortionFormat.getLanguageId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#getLanguageId), так и [BasePortionFormat.getAlternativeLanguageId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#getAlternativeLanguageId). Следующий автономный пример создаёт исходную часть с английским (США) в качестве основного языка и французским в качестве альтернативного, затем копирует текст и идентификаторы в часть новой презентации.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const source = new aspose.slides.Portion("Hello! Bonjour!");
source.getPortionFormat().setLanguageId("en-US");
source.getPortionFormat().setAlternativeLanguageId("fr-FR");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 80);
    const paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    const destination = new aspose.slides.Portion();
    destination.setText(source.getText());
    destination.getPortionFormat().setLanguageId(source.getPortionFormat().getLanguageId());
    // Если у источника нет альтернативного языка, null очищает значение в получателе.
    destination.getPortionFormat().setAlternativeLanguageId(source.getPortionFormat().getAlternativeLanguageId());
    paragraph.getPortions().add(destination);

    presentation.save("copied_language_metadata.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Чтобы попробовать источник без альтернативного языка, опустите присвоение `"fr-FR"`. Тогда альтернативный идентификатор будет `null`, и тот же оператор копирования сохранит его отсутствие без введения значения по умолчанию, даже если у назначения ранее был задан альтернативный язык.

Эти идентификаторы хранят метаданные языка. Сохранение их не определяет, какой словарь PowerPoint выберет для проверки орфографии или грамматики.

## **Установка языка по умолчанию**

Используйте [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/#setDefaultTextLanguage) для определения языка по умолчанию для текста, создаваемого при загрузке или создании презентации. Следующий пример создаёт презентацию с английским (США) в качестве языка текста по умолчанию, добавляет текстовое поле и выводит `en-US` для первой части текста.

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

## **Установка стиля текста по умолчанию**

Чтобы применить форматирование текста по умолчанию на уровне презентации, используйте [Presentation.getDefaultTextStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getDefaultTextStyle).

Следующий пример задаёт шрифт 14 пунктов полужирным в качестве значения по умолчанию для абзацев верхнего уровня в новой презентации и сохраняет её как "default_text_style.pptx". Текст может наследовать эти значения, если более специфичное форматирование не переопределяет их.

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

## **Извлечение текста с эффектом «Все заглавные»**

В PowerPoint применение эффекта **All Caps** к шрифту делает текст отображаемым заглавными буквами на слайде, даже если он был введён строчными. При получении такой части текста с помощью Aspose.Slides библиотека возвращает текст точно так, как он был введён. Чтобы получить отображаемый текст, проверьте [TextCapType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textcaptype/) и при значении `All` преобразуйте возвращённую строку к верхнему регистру.

Этот пример требует "sample2.pptx" с текстовым полем в качестве первой фигуры на первом слайде. Его первый абзац содержит первую часть с «Hello, Aspose!», к которой применён эффект All Caps, как показано ниже.

![Эффект All Caps](all_caps_effect.png)

Ниже пример кода, показывающий, как извлечь текст с применённым эффектом **All Caps**:

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

Чтобы изменить текст в таблице на слайде, используйте [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/). Пройдитесь по ячейкам и обновите каждую ячейку через [Cell.getTextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#getTextFrame) и форматирование абзаца через [Paragraph.getParagraphFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/#getParagraphFormat).

**Как применить градиентный цвет к тексту на слайде PowerPoint?**

Чтобы применить градиентный цвет к тексту, используйте [BasePortionFormat.getFillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#getFillFormat). Установите [FillFormat.setFillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/#setFillType) в [FillType.Gradient](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/) и настройте градиентные остановки, направление и прозрачность.
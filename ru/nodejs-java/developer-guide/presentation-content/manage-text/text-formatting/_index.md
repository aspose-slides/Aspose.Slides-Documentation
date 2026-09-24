---
title: Форматирование текста презентации на JavaScript
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
- поворот текста
- угол поворота
- текстовый фрейм
- межстрочный интервал
- свойство автоподгонки
- якорь текстового фрейма
- табуляция текста
- язык по умолчанию
- PowerPoint
- OpenDocument
- презентация
- Node.js
- JavaScript
- Aspose.Slides
description: "Форматировать и стилизовать текст в презентациях PowerPoint и OpenDocument с использованием Aspose.Slides для Node.js через Java. Настраивайте шрифты, цвета, выравнивание и многое другое."
---
## **Обзор**

В этой статье показано, как форматировать текст в презентациях PowerPoint и OpenDocument с использованием Aspose.Slides для Node.js через Java. Рассматриваются фоновые цвета, прозрачность, межсимвольный интервал, свойства шрифтов, поворот, интервал между абзацами, поведение автоподгонки, привязка текста, табуляция и настройки языка.

В приведённых ниже примерах мы будем использовать файл с именем «sample.pptx», который содержит один текстовый блок на первом слайде со следующим текстом:

![Пример текста](sample_text.png)

Чтобы найти и выделить буквальный текст или совпадения регулярного выражения, см. [Поиск и замена текста](/slides/ru/nodejs-java/search-and-replace-text/).

## **Установить цвет фона текста**

Используйте [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/paragraphformat/#getDefaultPortionFormat--) для установки цвета подсветки по умолчанию для абзаца, или используйте [BasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/baseportionformat/#getHighlightColor--) для отдельных текстовых фрагментов.

Следующий пример кода демонстрирует, как установить цвет фона для **всего абзаца**:

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

Следующий пример кода демонстрирует, как установить цвет фона для **текстовых фрагментов с полужирным шрифтом**:

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
            // Установить цвет подсветки для текстового фрагмента.
            portion.getPortionFormat().getHighlightColor().setColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));
        }
    }

    presentation.save("gray_text_portions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Серые текстовые фрагменты](gray_text_portions.png)

## **Выровнять абзацы текста**

Используйте [ParagraphFormat.setAlignment](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) для установки выравнивания абзаца внутри текстового фрейма. Значение может быть по центру, по левому краю, по правому краю, по ширине и т.д.

Следующий пример кода демонстрирует, как выровнять абзац **по центру**:

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

![Выровненный абзац](aligned_paragraph.png)

## **Установить прозрачность текста**

Прозрачность текста управляется альфа‑компонентой цвета, назначенного [BasePortionFormat.getFillFormat](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/baseportionformat/#getFillFormat--). В приведённых ниже примерах `alpha = 50` — это значение альфа‑канала ARGB в диапазоне 0–255, а не процент прозрачности.

Пример кода ниже демонстрирует, как применить прозрачность к **всему абзацу**:

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

![Прозрачный абзац](transparent_paragraph.png)

Следующий пример кода демонстрирует, как применить прозрачность к **текстовым фрагментам с полужирным шрифтом**:

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

            // Установить прозрачность текстового фрагмента.
            fillFormat.setFillType(java.newByte(aspose.slides.FillType.Solid));
            fillFormat.getSolidFillColor().setColor(transparentBlack);
        }
    }

    presentation.save("transparent_text_portions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Прозрачные текстовые фрагменты](transparent_text_portions.png)

## **Установить межсимвольный интервал для текста**

Используйте [BasePortionFormat.setSpacing](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/baseportionformat/#setSpacing-float-) для увеличения или уменьшения интервала между символами в текстовом поле.

Следующий код JavaScript демонстрирует, как расширить межсимвольный интервал в **всём абзаце**:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Примечание: используйте отрицательные значения для сжатия межсимвольного интервала.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3); // Увеличить межсимвольный интервал.

    presentation.save("character_spacing_in_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Межсимвольный интервал в абзаце](character_spacing_in_paragraph.png)

Следующий пример кода демонстрирует, как расширить межсимвольный интервал в **текстовых фрагментах с полужирным шрифтом**:

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
            // Примечание: используйте отрицательные значения для сжатия межсимвольного интервала.
            portion.getPortionFormat().setSpacing(3); // Увеличить межсимвольный интервал.
        }
    }

    presentation.save("character_spacing_in_text_portions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Межсимвольный интервал в текстовых фрагментах](character_spacing_in_text_portions.png)

### **Отключить кернинг для определённых шрифтов**

В некоторых случаях текст, отрисованный Aspose.Slides, может выглядеть слегка плотнее, чем тот же текст в PowerPoint. Это может происходить потому, что PowerPoint может игнорировать данные кернинга для определённых шрифтов, даже если шрифт содержит корректные данные кернинга и кернинг включён в настройках PowerPoint.

Чтобы сделать отрисованный вывод ближе к тому, как он выглядит в PowerPoint, в таких случаях можно отключить кернинг для текстовых фрагментов, использующих затронутый шрифт. Установите [BasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/baseportionformat/#setKerningMinimalSize-float-) в значение, значительно превышающее фактический размер шрифта:

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
            const portionFormat = portion.getPortionFormat();
            const latinFont = portionFormat.getLatinFont();
            const eastAsianFont = portionFormat.getEastAsianFont();
            const complexScriptFont = portionFormat.getComplexScriptFont();

            if ((latinFont !== null && latinFont.getFontName() === targetFont) ||
                (eastAsianFont !== null && eastAsianFont.getFontName() === targetFont) ||
                (complexScriptFont !== null && complexScriptFont.getFontName() === targetFont)) {
                portionFormat.setKerningMinimalSize(100);
            }
        }
    }

    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Этот параметр предотвращает применение кернинга к соответствующим текстовым фрагментам и может помочь согласовать визуальный вывод Aspose.Slides с выводом PowerPoint для шрифтов, затронутых этим специфическим поведением PowerPoint.

## **Управление свойствами шрифта текста**

Свойства шрифта можно задать на уровне абзаца через [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/paragraphformat/#getDefaultPortionFormat--) или для отдельных фрагментов через [PortionFormat](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/portionformat/).

Следующий код задаёт шрифт и стиль текста для всего абзаца: он применяет размер шрифта, полужирный, курсив, пунктирное подчёркивание и шрифт Times New Roman ко всем фрагментам в абзаце.

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

![Свойства шрифта для абзаца](font_properties_for_paragraph.png)

Следующий пример кода применяет аналогичные свойства к **текстовым фрагментам с полужирным шрифтом**:

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

            // Установить свойства шрифта для текстового фрагмента.
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

![Свойства шрифта для текстовых фрагментов](font_properties_for_text_portions.png)

## **Установить поворот текста**

Используйте [TextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-) для установки предопределённой ориентации текста внутри фигуры.

Следующий пример кода задаёт ориентацию текста в фигуре как `Vertical270`, что поворачивает текст **на 90 градусов против часовой стрелки**:

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

![Поворот текста](text_rotation.png)

## **Установить пользовательский поворот для текстовых фреймов**

Используйте [TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/textframeformat/#setRotationAngle-float-) для установки пользовательского угла поворота для [TextFrame](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/textframe/).

Следующий пример кода поворачивает текстовый фрейм на 3 градуса по часовой стрелке внутри фигуры:

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

![Пользовательский поворот текста](custom_text_rotation.png)

## **Установить интервал строк в абзацах**

Aspose.Slides предоставляет [ParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/paragraphformat/#setSpaceAfter-float-), [ParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/paragraphformat/#setSpaceBefore-float-) и [ParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/paragraphformat/#setSpaceWithin-float-) для управления интервалом абзацев. Эти свойства используются следующим образом:

* Используйте положительное значение, чтобы указать интервал строк в процентах от высоты строки.
* Используйте отрицательное значение, чтобы указать интервал строк в пунктах.

Следующий пример кода демонстрирует, как задать интервал строк внутри абзаца:

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

![Интервал строк в абзаце](line_spacing.png)

## **Установить тип автоподгонки для текстовых фреймов**

[TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/textframeformat/#setAutofitType-byte-) определяет, как текст ведёт себя, когда превышает границы своего контейнера. Используйте его, чтобы контролировать, будет ли текст сжиматься, выходить за пределы или автоматически изменять размер фигуры.

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

Чтобы подсчитать строки после автоматического переноса и увидеть, как меняются ширина текста или фигуры, смотрите [Подсчитать отрисованные строки](/slides/ru/nodejs-java/manage-paragraph/). Само количество строк не указывает, превышает ли текст границы своего контейнера.

## **Установить привязку текстовых фреймов**

[TextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/textframeformat/#setAnchoringType-byte-) определяет, как текст размещается вертикально внутри фигуры, например вверху, посередине или внизу.

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

Используйте [ParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/paragraphformat/#setDefaultTabSize-float-) и [ParagraphFormat.getTabs](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/paragraphformat/#getTabs--) для настройки табуляций в абзаце.

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

![Табуляции абзаца](paragraph_tabs.png)

## **Установить язык проверки**

Aspose.Slides предоставляет [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/baseportionformat/#setLanguageId-java.lang.String-), который позволяет задать язык проверки для текстового фрагмента. Язык проверки определяет язык, используемый для проверки орфографии и грамматики в PowerPoint.

Следующий пример кода демонстрирует, как задать язык проверки для текстового фрагмента:

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

    // Установить идентификатор языка проверки.
    textPortion.getPortionFormat().setLanguageId("zh-CN");

    textPortion.setText("1。");
    paragraph.getPortions().add(textPortion);

    presentation.save("proofing_language.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Установить язык по умолчанию**

Используйте [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) для определения языка по умолчанию для текста, создаваемого при загрузке или создании презентации.

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

    // Проверить язык первого фрагмента.
    const portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    console.log(portion.getPortionFormat().getLanguageId());
} finally {
    presentation.dispose();
}
```

## **Установить стиль текста по умолчанию**

Чтобы применить форматирование текста по умолчанию на уровне презентации, используйте [Presentation.getDefaultTextStyle](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/#getDefaultTextStyle--).

Следующий пример кода демонстрирует, как задать шрифт по умолчанию с полужирным начертанием и размером 14 пунктов для всего текста на всех слайдах новой презентации.

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

## **Извлечь текст с эффектом All Caps**

В PowerPoint применение эффекта шрифта **All Caps** переводит текст в верхний регистр на слайде, даже если он был введён строчными буквами. При получении такого текстового фрагмента с помощью Aspose.Slides библиотека возвращает текст точно в том виде, в каком он был введён. Чтобы соответствовать отображаемому тексту, проверьте [TextCapType](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/textcaptype/) и преобразуйте возвращённую строку в верхний регистр, когда значение равно `All`.

Предположим, у нас есть следующий текстовый блок на первом слайде файла sample2.pptx.

![Эффект All Caps](all_caps_effect.png)

Следующий пример кода демонстрирует, как извлечь текст с применённым эффектом **All Caps**:

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

## **Часто задаваемые вопросы**

**Как изменить текст в таблице на слайде?**

Чтобы изменить текст в таблице на слайде, используйте [Table](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/table/). Пройдитесь по ячейкам и обновите каждую ячейку через [Cell.getTextFrame](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/cell/#getTextFrame--) и форматирование абзацев через [Paragraph.getParagraphFormat](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/paragraph/#getParagraphFormat--).

**Как применить градиентный цвет к тексту на слайде PowerPoint?**

Чтобы применить градиентный цвет к тексту, используйте [BasePortionFormat.getFillFormat](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/baseportionformat/#getFillFormat--). Установите [FillFormat.setFillType](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/fillformat/#setFillType-byte-) в значение [FillType.Gradient](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/filltype/) и настройте стопы градиента, направление и прозрачность.
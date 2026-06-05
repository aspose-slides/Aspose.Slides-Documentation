---
title: Форматирование текста презентации в JavaScript
linktitle: Форматирование текста
type: docs
weight: 50
url: /ru/nodejs-java/text-formatting/
keywords:
- выделение текста
- регулярное выражение
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
- свойство автоподбора
- привязка текстовой рамки
- табуляция текста
- язык по умолчанию
- PowerPoint
- OpenDocument
- презентация
- Node.js
- JavaScript
- Aspose.Slides
description: "Форматируйте и стилизуйте текст в презентациях PowerPoint и OpenDocument с помощью Aspose.Slides для Node.js через Java. Настраивайте шрифты, цвета, выравнивание и многое другое."
---
## **Обзор**

В этой статье показано, как форматировать текст в презентациях PowerPoint и OpenDocument с помощью Aspose.Slides для Node.js через Java. Охватываются подсветка, фоновые цвета, прозрачность, межсимвольный интервал, свойства шрифта, вращение, интервалы абзацев, поведение автоподбора, привязка текста, табуляция и параметры языка.

В примерах ниже мы будем использовать файл с именем **sample.pptx**, который содержит один текстовый блок на первом слайде со следующим текстом:

![Пример текста](sample_text.png)

## **Подсветка текста**

Используйте метод [TextFrame.highlightText](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/textframe/#highlightText-java.lang.String-java.awt.Color-) , когда необходимо подсветить текст, соответствующий заданному образцу внутри текстового фрейма. Метод применяет цвет подсветки к найденным фрагментам текста и может использоваться совместно с [TextSearchOptions](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/textsearchoptions/) для управления способом поиска, например для совпадения только целых слов.

Кодовый пример ниже подсвечивает все вхождения символов **"try"**, а затем подсвечивает только полное слово **"to"**.

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const textFrame = shape.getTextFrame();

    // Выделить слово "try" в фигуре.
    textFrame.highlightText("try", java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));

    const searchOptions = new aspose.slides.TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);

    // Выделить слово "to" в фигуре.
    textFrame.highlightText("to", java.getStaticFieldValue("java.awt.Color", "MAGENTA"), searchOptions, null);

    presentation.save("highlighted_text.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Результат:

![Подсвеченный текст](highlighted_text.png)

## **Подсветка текста с помощью регулярных выражений**

Метод [TextFrame.highlightRegex](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/textframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-aspose.slides.IFindResultCallback-) подсвечивает совпадения, найденные регулярным выражением. В Node.js через Java этот API доступен через [TextFrame](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/textframe/).

Кодовый пример ниже подсвечивает все слова, содержащие **семь или более символов**:

```javascript
const Pattern = java.import("java.util.regex.Pattern");
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const regex = Pattern.compile("\\b[^\\s]{7,}\\b");

    // Выделить все слова из семи или более символов.
    shape.getTextFrame().highlightRegex(regex, java.getStaticFieldValue("java.awt.Color", "YELLOW"), null);

    presentation.save("highlighted_text_using_regex.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Результат:

![Подсвеченный текст с использованием регулярного выражения](highlighted_text_using_regex.png)

## **Установить фоновый цвет текста**

Используйте [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/paragraphformat/#getDefaultPortionFormat--) для установки цвета подсветки по умолчанию для абзаца или [PortionFormat.getHighlightColor](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/portionformat/#getHighlightColor--) для отдельных текстовых фрагментов.

Следующий кодовый пример демонстрирует, как задать фон для **всего абзаца**:

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
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

Кодовый пример ниже показывает, как задать фон для **текстовых фрагментов с жирным шрифтом**:

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
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

Результат:

![Серые текстовые фрагменты](gray_text_portions.png)

## **Выравнивание абзацев текста**

Используйте [ParagraphFormat.setAlignment](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/paragraphformat/#setAlignment-byte-) для установки выравнивания абзаца внутри текстового фрейма. Значения могут быть центрированным, выравненным по левому, правому краю, по ширине и т.д.

Следующий кодовый пример показывает, как выровнять абзац по **центру**:

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Установить выравнивание абзаца по центру.
    paragraph.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.Center);

    presentation.save("aligned_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Результат:

![Выравненный абзац](aligned_paragraph.png)

## **Установить прозрачность текста**

Прозрачность текста задаётся через альфа‑компонент цвета, назначенного [PortionFormat.getFillFormat](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/portionformat/#getFillFormat--). В приведённых ниже примерах `alpha = 50` — это ARGB‑значение альфа‑канала в диапазоне 0‑255, а не процент прозрачности.

Кодовый пример ниже показывает, как применить прозрачность к **всему абзацу**:

```javascript
const alpha = 50;
const transparentBlack = java.newInstanceSync("java.awt.Color", 0, 0, 0, alpha);
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
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

Следующий кодовый пример демонстрирует, как применить прозрачность к **текстовым фрагментам с жирным шрифтом**:

```javascript
const alpha = 50;
const transparentBlack = java.newInstanceSync("java.awt.Color", 0, 0, 0, alpha);
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
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

Результат:

![Прозрачные текстовые фрагменты](transparent_text_portions.png)

## **Установить межсимвольный интервал текста**

Используйте [BasePortionFormat.setSpacing](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/baseportionformat/#setSpacing-float-) для увеличения или уменьшения расстояния между символами в текстовом блоке.

Следующий JavaScript‑код показывает, как расширить межсимвольный интервал в **всём абзаце**:

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Примечание: используйте отрицательные значения для сжатия межсимвольного интервала.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3); // Увеличить межсимвольный интервал.

    presentation.save("character_spacing_in_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Результат:

![Межсимвольный интервал в абзаце](character_spacing_in_paragraph.png)

Кодовый пример ниже показывает, как расширить межсимвольный интервал в **текстовых фрагментах с жирным шрифтом**:

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
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

Результат:

![Межсимвольный интервал в текстовых фрагментах](character_spacing_in_text_portions.png)

### **Отключить кернинг для определенных шрифтов**

В некоторых случаях текст, отрисованный Aspose.Slides, выглядит слегка более плотно, чем тот же текст в PowerPoint. Это может происходить, потому что PowerPoint игнорирует данные о кернинге для некоторых шрифтов, даже если шрифт содержит корректную информацию о кернинге и кернинг включён в настройках PowerPoint.

Чтобы результат был ближе к отображению в PowerPoint, можно отключить кернинг для текстовых фрагментов, использующих проблемный шрифт. Установите [BasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/baseportionformat/#setKerningMinimalSize-float-) на значение, значительно превышающее фактический размер шрифта:

```javascript
const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
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

Это предотвращает применение кернинга к соответствующим фрагментам текста и помогает согласовать визуальное отображение Aspose.Slides с PowerPoint для затронутых шрифтов.

## **Управление свойствами шрифта текста**

Свойства шрифта можно задать на уровне абзаца через [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/paragraphformat/#getDefaultPortionFormat--) или на отдельных фрагментах через [PortionFormat](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/portionformat/).

Следующий код задаёт шрифт и стиль текста для всего абзаца: применяется размер шрифта, полужирный, курсив, пунктирное подчеркивание и шрифт Times New Roman для всех фрагментов абзаца.

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
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

Кодовый пример ниже применяет аналогичные свойства к **текстовым фрагментам с жирным шрифтом**:

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
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

Результат:

![Свойства шрифта для текстовых фрагментов](font_properties_for_text_portions.png)

## **Установить вращение текста**

Используйте [TextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-) для установки предопределённой ориентации текста внутри фигуры.

Следующий кодовый пример задаёт ориентацию текста в фигуре как `Vertical270`, что вращает текст **на 90 градусов против часовой стрелки**:

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setTextVerticalType(java.newByte(aspose.slides.TextVerticalType.Vertical270));

    presentation.save("text_rotation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Результат:

![Вращение текста](text_rotation.png)

## **Установить пользовательский угол поворота для текстовых рамок**

Используйте [TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/textframeformat/#setRotationAngle-float-) для задания произвольного угла поворота для [TextFrame](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/textframe/).

Кодовый пример ниже поворачивает текстовый фрейм на 3 градуса по часовой стрелке внутри фигуры:

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setRotationAngle(3);

    presentation.save("custom_text_rotation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Результат:

![Пользовательское вращение текста](custom_text_rotation.png)

## **Установить межстрочный интервал абзацев**

Aspose.Slides предоставляет методы [ParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/paragraphformat/#setSpaceAfter-float-), [ParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/paragraphformat/#setSpaceBefore-float-) и [ParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/paragraphformat/#setSpaceWithin-float-) для управления интервалами абзацев. Эти свойства используются следующим образом:

* Укажите положительное значение, чтобы задать межстрочный интервал в процентах от высоты строки.
* Укажите отрицательное значение, чтобы задать межстрочный интервал в пунктах.

Следующий кодовый пример показывает, как задать межстрочный интервал в абзаце:

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    paragraph.getParagraphFormat().setSpaceWithin(200);

    presentation.save("line_spacing.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Результат:

![Межстрочный интервал в абзаце](line_spacing.png)

## **Установить тип автоподбора для текстовых рамок**

[TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/textframeformat/#setAutofitType-byte-) определяет, как текст будет вести себя, если он превышает границы контейнера. Используйте его, чтобы контролировать, будет ли текст уменьшаться, выходить за пределы или автоматически изменять размер фигуры.

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.Shape));

    presentation.save("autofit_type.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Установить привязку текстовых рамок**

[TextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/textframeformat/#setAnchoringType-byte-) определяет вертикальное позиционирование текста внутри фигуры, например вверху, по центру или внизу.

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setAnchoringType(java.newByte(aspose.slides.TextAnchorType.Bottom));

    presentation.save("text_anchor.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Установить табуляцию текста**

Используйте [ParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/paragraphformat/#setDefaultTabSize-float-) и [ParagraphFormat.getTabs](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/paragraphformat/#getTabs--) для настройки табуляций в абзаце.

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    paragraph.getParagraphFormat().setDefaultTabSize(100);
    paragraph.getParagraphFormat().getTabs().add(30, java.newByte(aspose.slides.TabAlignment.Left));

    presentation.save("paragraph_tabs.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Результат:

![Табуляция абзаца](paragraph_tabs.png)

## **Установить язык проверки текста**

Aspose.Slides предоставляет [PortionFormat.setLanguageId](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) , который позволяет задать язык проверки для текстового фрагмента. Язык проверки определяет, какой язык используется для проверки орфографии и грамматики в PowerPoint.

Следующий кодовый пример показывает, как задать язык проверки для текстового фрагмента:

```javascript
const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    const font = new aspose.slides.FontData("SimSun");
    const textPortion = new aspose.slides.Portion();
    textPortion.getPortionFormat().setComplexScriptFont(font);
    textPortion.getPortionFormat().setEastAsianFont(font);
    textPortion.getPortionFormat().setLatinFont(font);

    // Установить Id проверочного языка.
    textPortion.getPortionFormat().setLanguageId("zh-CN");

    textPortion.setText("1.");
    paragraph.getPortions().add(textPortion);

    presentation.save("proofing_language.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Установить язык по умолчанию**

Используйте [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) для определения языка текста по умолчанию при загрузке или создании презентации.

```javascript
const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

const presentation = new aspose.slides.Presentation(loadOptions);
try {
    const slide = presentation.getSlides().get_Item(0);

    // Добавить новую прямоугольную форму с текстом.
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

Для применения форматирования текста по умолчанию на уровне презентации используйте [Presentation.getDefaultTextStyle](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/#getDefaultTextStyle--).

Следующий кодовый пример задаёт шрифт по умолчанию — жирный, размер 14 pt — для всего текста во всех слайдах новой презентации.

```javascript
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

В PowerPoint применение эффекта **All Caps** делает текст заглавным на слайде, даже если он был введён строчными буквами. При получении такого фрагмента текста с помощью Aspose.Slides библиотека возвращает текст точно в том виде, в котором он был введён. Чтобы получить отображаемый вариант, проверьте [TextCapType](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/textcaptype/) и при значении `All` преобразуйте полученную строку в верхний регистр.

Предположим, у нас есть следующий текстовый блок на первом слайде файла **sample2.pptx**.

![Эффект All Caps](all_caps_effect.png)

Кодовый пример ниже показывает, как извлечь текст с применённым эффектом **All Caps**:

```javascript
const presentation = new aspose.slides.Presentation("sample2.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
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

Для изменения текста в таблице на слайде используйте [Table](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/table/). Пройдитесь по ячейкам и обновите каждую через [Cell.getTextFrame](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/cell/#getTextFrame--) и форматирование абзацев через [Paragraph.getParagraphFormat](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/paragraph/#getParagraphFormat--).

**Как применить градиентный цвет к тексту в слайде PowerPoint?**

Для применения градиентного цвета к тексту используйте [PortionFormat.getFillFormat](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/portionformat/#getFillFormat--). Установите [FillFormat.setFillType](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/fillformat/#setFillType-byte-) на [FillType.Gradient](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/filltype/) и настройте градиентные остановки, направление и прозрачность.
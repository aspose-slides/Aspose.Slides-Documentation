---
title: Формат текста презентации на Android
linktitle: Форматирование текста
type: docs
weight: 50
url: /ru/androidjava/text-formatting/
keywords:
- подсветка текста
- регулярное выражение
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
- presentation
- Android
- Java
- Aspose.Slides
description: "Форматировать и стилизовать текст в презентациях PowerPoint и OpenDocument с помощью Aspose.Slides для Android через Java. Настраивайте шрифты, цвета, выравнивание и многое другое."
---
## **Обзор**

В этой статье показано, как форматировать текст в презентациях PowerPoint и OpenDocument с помощью Aspose.Slides для Android через Java. Рассматриваются подсветка, фоновые цвета, прозрачность, интервал между символами, свойства шрифта, вращение, интервал между абзацами, поведение автоподгонки, привязка текста, табуляторы и настройки языка.

В примерах ниже используется файл **sample.pptx**, содержащий один текстовый блок на первом слайде со следующим текстом:

![Пример текста](sample_text.png)

## **Подсветка текста**

Используйте метод [ITextFrame.highlightText](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ITextFrame#highlightText-java.lang.String-java.lang.Integer-) для подсветки текста, совпадающего с заданным образцом внутри текстового фрейма. Метод применяет цвет подсветки к подходящим фрагментам текста и может использоваться вместе с [ITextSearchOptions](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ITextSearchOptions) для управления способом поиска, например, для сопоставления только целых слов.

Пример кода ниже подсвечивает все вхождения символов **"try"**, а затем подсвечивает только полное слово **"to"**.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    // Получить первую фигуру с первого слайда.
    IAutoShape shape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // Подсветить слово "try" в фигуре.
    shape.getTextFrame().highlightText("try", Color.rgb(173, 216, 230));

    TextSearchOptions searchOptions = new TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);

    // Подсветить слово "to" в фигуре.
    int violetColor = Color.rgb(238, 130, 238);
    shape.getTextFrame().highlightText("to", violetColor, searchOptions, null);

    presentation.save("highlighted_text.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Результат:

![Подсвеченный текст](highlighted_text.png)

## **Подсветка текста с использованием регулярных выражений**

Метод [ITextFrame.highlightRegex](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ITextFrame#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-) подсвечивает найденные регулярным выражением совпадения текста.

Пример кода ниже подсвечивает все слова, содержащие **семь или более символов**:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape shape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    java.util.regex.Pattern regex = java.util.regex.Pattern.compile("\\b[^\\s]{7,}\\b");

    // Подсветить все слова, содержащие семь или более символов.
    shape.getTextFrame().highlightRegex(regex, Color.YELLOW, null);

    presentation.save("highlighted_text_using_regex.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Результат:

![Подсвеченный текст с помощью регулярного выражения](highlighted_text_using_regex.png)

## **Установка фонового цвета текста**

Используйте [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/IParagraphFormat#getDefaultPortionFormat--) для установки цвета подсветки по умолчанию для абзаца или [IBasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/IBasePortionFormat#getHighlightColor--) для отдельных текстовых фрагментов.

Следующий пример кода показывает, как установить фон **для всего абзаца**:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Установить цвет подсветки для всего абзаца.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getHighlightColor().setColor(Color.LTGRAY);

    presentation.save("gray_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Результат:

![Серый абзац](gray_paragraph.png)

Пример кода ниже демонстрирует, как установить фон **для текстовых фрагментов с полужирным шрифтом**:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (int portionIndex = 0; portionIndex < paragraph.getPortions().getCount(); portionIndex++) {
        IPortion portion = paragraph.getPortions().get_Item(portionIndex);

        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // Установить цвет подсветки для текстового фрагмента.
            portion.getPortionFormat().getHighlightColor().setColor(Color.LTGRAY);
        }
    }

    presentation.save("gray_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Результат:

![Серые текстовые фрагменты](gray_text_portions.png)

## **Выравнивание текстовых абзацев**

Используйте [IParagraphFormat.setAlignment](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/IParagraphFormat#setAlignment-byte-) для задания выравнивания абзаца внутри текстового фрейма. Значение может быть центрированным, выровненным по левому, правому краю, по ширине и т.д.

Следующий пример кода показывает, как выровнять абзац **по центру**:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Установить выравнивание абзаца по центру.
    paragraph.getParagraphFormat().setAlignment(TextAlignment.Center);

    presentation.save("aligned_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Результат:

![Выровненный абзац](aligned_paragraph.png)

## **Установка прозрачности текста**

Прозрачность текста контролируется альфа‑компонентой цвета, задаваемой для [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/IBasePortionFormat#getFillFormat--). В примерах ниже `alpha = 50` — это значение канала ARGB в диапазоне 0‑255, а не процент прозрачности.

Пример кода ниже показывает, как применить прозрачность **к целому абзацу**:

```java
int alpha = 50;

Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Установить цвет заливки текста в прозрачный цвет.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.argb(alpha, 0, 0, 0));

    presentation.save("transparent_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Результат:

![Прозрачный абзац](transparent_paragraph.png)

Следующий пример кода показывает, как применить прозрачность **к текстовым фрагментам с полужирным шрифтом**:

```java
int alpha = 50;

Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (int portionIndex = 0; portionIndex < paragraph.getPortions().getCount(); portionIndex++) {
        IPortion portion = paragraph.getPortions().get_Item(portionIndex);

        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // Установить прозрачность текстового фрагмента.
            portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
            portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.argb(alpha, 0, 0, 0));
        }
    }

    presentation.save("transparent_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Результат:

![Прозрачные текстовые фрагменты](transparent_text_portions.png)

## **Установка интервала между символами**

Используйте [IBasePortionFormat.setSpacing](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/IBasePortionFormat#setSpacing-float-) для расширения или сжатия интервала между символами в текстовом боксе.

Следующий Java‑код показывает, как расширить интервал между символами **весь абзац**:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Примечание: используйте отрицательные значения для сжатия интервала между символами.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3); // Расширить интервал между символами.

    presentation.save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Результат:

![Интервал между символами в абзаце](character_spacing_in_paragraph.png)

Пример кода ниже показывает, как расширить интервал **в текстовых фрагментах с полужирным шрифтом**:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (int portionIndex = 0; portionIndex < paragraph.getPortions().getCount(); portionIndex++) {
        IPortion portion = paragraph.getPortions().get_Item(portionIndex);

        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // Примечание: используйте отрицательные значения для сжатия интервала между символами.
            portion.getPortionFormat().setSpacing(3); // Расширить интервал между символами.
        }
    }

    presentation.save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Результат:

![Интервал между символами в текстовых фрагментах](character_spacing_in_text_portions.png)

### **Отключение кернинга для отдельных шрифтов**

В некоторых случаях текст, отрисованный Aspose.Slides, выглядит чуть плотнее, чем тот же текст в PowerPoint. Это происходит потому, что PowerPoint может игнорировать данные кернинга для определённых шрифтов, даже если шрифт содержит корректную информацию о кернинге и кернинг включён в настройках PowerPoint.

Чтобы привести вывод к виду PowerPoint, можно отключить кернинг для текстовых фрагментов, использующих затронутый шрифт. Установите [IBasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/IBasePortionFormat#setKerningMinimalSize-float-) в значение, заметно превышающее фактический размер шрифта:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    String targetFont = "Roboto";

    for (int paragraphIndex = 0; paragraphIndex < autoShape.getTextFrame().getParagraphs().getCount(); paragraphIndex++) {
        IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(paragraphIndex);

        for (int portionIndex = 0; portionIndex < paragraph.getPortions().getCount(); portionIndex++) {
            IPortion portion = paragraph.getPortions().get_Item(portionIndex);
            IFontData latinFont = portion.getPortionFormat().getLatinFont();
            IFontData eastAsianFont = portion.getPortionFormat().getEastAsianFont();
            IFontData complexScriptFont = portion.getPortionFormat().getComplexScriptFont();

            boolean usesTargetFont =
                    latinFont != null && targetFont.equals(latinFont.getFontName()) ||
                    eastAsianFont != null && targetFont.equals(eastAsianFont.getFontName()) ||
                    complexScriptFont != null && targetFont.equals(complexScriptFont.getFontName());

            if (usesTargetFont) {
                portion.getPortionFormat().setKerningMinimalSize(100);
            }
        }
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Эта настройка предотвращает применение кернинга к соответствующим фрагментам текста и помогает согласовать визуальный вывод Aspose.Slides с PowerPoint для шрифтов, на которые влияет это специфическое поведение PowerPoint.

## **Управление свойствами шрифта текста**

Свойства шрифта можно задать на уровне абзаца через [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/IParagraphFormat#getDefaultPortionFormat--) или для отдельных фрагментов через [IPortionFormat](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/IPortionFormat).

Следующий код задаёт шрифт и стиль текста для **всего абзаца**: устанавливает размер шрифта, полужирный, курсив, пунктирное подчеркивание и шрифт Times New Roman для всех фрагментов абзаца.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Установить свойства шрифта для абзаца.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(12);
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontBold(NullableBool.True);
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontItalic(NullableBool.True);
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontUnderline(TextUnderlineType.Dotted);
    paragraph.getParagraphFormat().getDefaultPortionFormat().setLatinFont(new FontData("Times New Roman"));

    presentation.save("font_properties_for_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Результат:

![Свойства шрифта для абзаца](font_properties_for_paragraph.png)

Пример кода ниже применяет аналогичные свойства **к текстовым фрагментам с полужирным шрифтом**:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (int portionIndex = 0; portionIndex < paragraph.getPortions().getCount(); portionIndex++) {
        IPortion portion = paragraph.getPortions().get_Item(portionIndex);

        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // Установить свойства шрифта для текстового фрагмента.
            portion.getPortionFormat().setFontHeight(13);
            portion.getPortionFormat().setFontItalic(NullableBool.True);
            portion.getPortionFormat().setFontUnderline(TextUnderlineType.Dotted);
            portion.getPortionFormat().setLatinFont(new FontData("Times New Roman"));
        }
    }

    presentation.save("font_properties_for_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Результат:

![Свойства шрифта для текстовых фрагментов](font_properties_for_text_portions.png)

## **Установка вращения текста**

Используйте [ITextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ITextFrameFormat#setTextVerticalType-byte-) для задания предопределённой ориентации текста внутри фигуры.

Следующий пример кода задаёт ориентацию текста в фигуре как `Vertical270`, что вращает текст **на 90 градусов против часовой стрелки**:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setTextVerticalType(TextVerticalType.Vertical270);

    presentation.save("text_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Результат:

![Вращение текста](text_rotation.png)

## **Установка пользовательского вращения для текстовых фреймов**

Используйте [ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ITextFrameFormat#setRotationAngle-float-) для задания произвольного угла вращения для [ITextFrame](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ITextFrame).

Пример кода ниже вращает текстовый фрейм на 3 градуса по часовой стрелке внутри фигуры:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setRotationAngle(3);

    presentation.save("custom_text_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Результат:

![Пользовательское вращение текста](custom_text_rotation.png)

## **Установка межстрочного интервала абзацев**

Aspose.Slides предоставляет [IParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/IParagraphFormat#setSpaceAfter-float-), [IParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/IParagraphFormat#setSpaceBefore-float-) и [IParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/IParagraphFormat#setSpaceWithin-float-) для управления интервалом между абзацами. Эти свойства используются следующим образом:

* Положительное значение задаёт межстрочный интервал в процентах от высоты строки.
* Отрицательное значение задаёт интервал в пунктах.

Следующий пример кода показывает, как задать межстрочный интервал внутри абзаца:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    paragraph.getParagraphFormat().setSpaceWithin(200);

    presentation.save("line_spacing.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Результат:

![Межстрочный интервал внутри абзаца](line_spacing.png)

## **Установка типа автоподгонки для текстовых фреймов**

Метод [ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ITextFrameFormat#setAutofitType-byte-) определяет, как текст будет вести себя, когда выходит за границы контейнера. Используйте его для управления тем, будет ли текст сжиматься, обрезаться или автоматически изменять размер фигуры.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setAutofitType(TextAutofitType.Shape);

    presentation.save("autofit_type.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Установка привязки текста в фреймах**

Метод [ITextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ITextFrameFormat#setAnchoringType-byte-) определяет вертикальное расположение текста внутри фигуры, например сверху, посередине или снизу.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setAnchoringType(TextAnchorType.Bottom);

    presentation.save("text_anchor.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Настройка табуляции текста**

Используйте [IParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/IParagraphFormat#setDefaultTabSize-float-) и [IParagraphFormat.getTabs](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/IParagraphFormat#getTabs--) для конфигурации табуляций в абзаце.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    paragraph.getParagraphFormat().setDefaultTabSize(100);
    paragraph.getParagraphFormat().getTabs().add(30, TabAlignment.Left);

    presentation.save("paragraph_tabs.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Результат:

![Табуляции абзаца](paragraph_tabs.png)

## **Установка языка проверки правописания**

Aspose.Slides предоставляет [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/IBasePortionFormat#setLanguageId-java.lang.String-), позволяющий задать язык проверки правописания для текстового фрагмента. Язык проверки определяет язык, используемый для орфографических и грамматических проверок в PowerPoint.

Следующий пример кода показывает, как задать язык проверки правописания для текстового фрагмента:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    FontData font = new FontData("SimSun");

    Portion textPortion = new Portion();
    textPortion.getPortionFormat().setComplexScriptFont(font);
    textPortion.getPortionFormat().setEastAsianFont(font);
    textPortion.getPortionFormat().setLatinFont(font);

    // Установить идентификатор языка проверки правописания.
    textPortion.getPortionFormat().setLanguageId("zh-CN");

    textPortion.setText("1。");
    paragraph.getPortions().add(textPortion);

    presentation.save("proofing_language.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Установка языка по умолчанию**

Используйте [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/LoadOptions#setDefaultTextLanguage-java.lang.String-) для определения языка по умолчанию для текста, создаваемого при загрузке или создании презентации.

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

Presentation presentation = new Presentation(loadOptions);
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Добавить новую прямоугольную форму с текстом.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 50);
    shape.getTextFrame().setText("Sample text");

    // Проверить язык первого фрагмента.
    IPortion portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    System.out.println(portion.getPortionFormat().getLanguageId());
} finally {
    presentation.dispose();
}
```

## **Установка стиля текста по умолчанию**

Для применения форматирования текста по умолчанию на уровне презентации используйте [IPresentation.getDefaultTextStyle](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/IPresentation#getDefaultTextStyle--).

Следующий пример кода показывает, как задать шрифт по умолчанию полужирным размером 14 pt для всего текста на слайдах новой презентации.

```java
Presentation presentation = new Presentation();
try {
    // Получить формат абзаца верхнего уровня.
    IParagraphFormat paragraphFormat = presentation.getDefaultTextStyle().getLevel(0);

    if (paragraphFormat != null) {
        paragraphFormat.getDefaultPortionFormat().setFontHeight(14);
        paragraphFormat.getDefaultPortionFormat().setFontBold(NullableBool.True);
    }

    presentation.save("default_text_style.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Извлечение текста с эффектом “Все заглавные”**

В PowerPoint применение эффекта **All Caps** делает текст заглавным на слайде, даже если он был введён в нижнем регистре. При получении такого текстового фрагмента через Aspose.Slides библиотека возвращает исходный ввод. Чтобы отобразить текст так, как он выглядит, проверьте [TextCapType](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/TextCapType) и при значении `All` преобразуйте возвращённую строку в верхний регистр.

Предположим, что на первом слайде файла **sample2.pptx** находится следующий текстовый блок.

![Эффект All Caps](all_caps_effect.png)

Пример кода ниже показывает, как извлечь текст с применённым эффектом **All Caps**:

```java
Presentation presentation = new Presentation("sample2.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IPortion textPortion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);

    System.out.println("Original text: " + textPortion.getText());

    IPortionFormatEffectiveData textFormat = textPortion.getPortionFormat().getEffective();
    if (textFormat.getTextCapType() == TextCapType.All) {
        String text = textPortion.getText().toUpperCase();
        System.out.println("All-Caps effect: " + text);
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

Для изменения текста в таблице используйте [ITable](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ITable). Пройдитесь по ячейкам и обновите каждую через [ICell.getTextFrame](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ICell#getTextFrame--) и форматирование абзаца через [IParagraph.getParagraphFormat](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/IParagraph#getParagraphFormat--).

**Как применить градиентный цвет к тексту в слайде PowerPoint?**

Для применения градиентного цвета используйте [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/IBasePortionFormat#getFillFormat--). Установите [IFillFormat.setFillType](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/IFillFormat#setFillType-int-) в значение [FillType.Gradient](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/FillType) и настройте точки градиента, направление и прозрачность.
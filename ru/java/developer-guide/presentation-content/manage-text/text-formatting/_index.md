---
title: Форматирование текста презентации в Java
linktitle: Форматирование текста
type: docs
weight: 50
url: /ru/java/text-formatting/
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
- текстовая рамка
- межстрочный интервал
- свойство автоподгонки
- привязка текстовой рамки
- табуляция текста
- язык по умолчанию
- PowerPoint
- OpenDocument
- презентация
- Java
- Aspose.Slides
description: "Форматируйте и оформляйте текст в презентациях PowerPoint и OpenDocument с помощью Aspose.Slides для Java. Настраивайте шрифты, цвета, выравнивание и многое другое."
---
## **Обзор**

Эта статья показывает, как форматировать текст в презентациях PowerPoint и OpenDocument с помощью Aspose.Slides for Java. Она охватывает фоновые цвета, прозрачность, интервал между символами, свойства шрифта, вращение, интервалы между абзацами, поведение автоподгонки, привязку текста, табуляцию и настройки языка.

В примерах ниже мы будем использовать файл с именем "sample.pptx", который содержит один текстовый блок на первом слайде со следующим текстом:

![Sample text](sample_text.png)

Чтобы найти и выделить буквальный текст или совпадения регулярных выражений, см. [Search and Replace Text](/slides/ru/java/search-and-replace-text/).

## **Установить цвет фона текста**

Используйте [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) для установки цвета подсветки по умолчанию для абзаца, или используйте [IBasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ibaseportionformat/#getHighlightColor--) для отдельных текстовых фрагментов.

Следующий пример кода показывает, как установить цвет фона для **всего абзаца**:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Установить цвет подсветки для всего абзаца.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getHighlightColor().setColor(Color.LIGHT_GRAY);

    presentation.save("gray_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Результат:

![The gray paragraph](gray_paragraph.png)

Ниже показан пример кода, который задаёт цвет фона для **текстовых фрагментов с полужирным шрифтом**:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // Установить цвет подсветки для текстового фрагмента.
            portion.getPortionFormat().getHighlightColor().setColor(Color.LIGHT_GRAY);
        }
    }

    presentation.save("gray_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Результат:

![The gray text portions](gray_text_portions.png)

## **Выровнять абзацы текста**

Используйте [IParagraphFormat.setAlignment](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) чтобы задать выравнивание абзаца внутри текстовой рамки. Значение может быть центрированным, выровненным по левому краю, правому краю, по ширине и т.д.

Следующий пример кода показывает, как выровнять абзац **по центру**:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Установить выравнивание абзаца по центру.
    paragraph.getParagraphFormat().setAlignment(TextAlignment.Center);

    presentation.save("aligned_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Результат:

![The aligned paragraph](aligned_paragraph.png)

## **Установить прозрачность текста**

Прозрачность текста контролируется через альфа‑компонент цвета, назначенного [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ibaseportionformat/#getFillFormat--). В примерах ниже `alpha = 50` — это значение альфа‑канала ARGB в диапазоне 0–255, а не процент прозрачности.

Пример кода, показывающий, как применить прозрачность к **всему абзацу**:

```java
import com.aspose.slides.*;
import java.awt.Color;

int alpha = 50;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Установить цвет заливки текста в прозрачный цвет.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(new Color(0, 0, 0, alpha));

    presentation.save("transparent_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Результат:

![The transparent paragraph](transparent_paragraph.png)

Следующий пример кода демонстрирует применение прозрачности к **текстовым фрагментам с полужирным шрифтом**:

```java
import com.aspose.slides.*;
import java.awt.Color;

int alpha = 50;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // Установить прозрачность текстового фрагмента.
            portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
            portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(new Color(0, 0, 0, alpha));
        }
    }

    presentation.save("transparent_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Результат:

![The transparent text portions](transparent_text_portions.png)

## **Установить интервал между символами**

Используйте [IBasePortionFormat.setSpacing](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ibaseportionformat/#setSpacing-float-) для увеличения или уменьшения интервала между символами в текстовом блоке.

Следующий Java‑код показывает, как увеличить интервал между символами в **всём абзаце**:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Примечание: используйте отрицательные значения для сжатия межсимвольного интервала.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3); // Увеличить межсимвольный интервал.

    presentation.save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Результат:

![The character spacing in the paragraph](character_spacing_in_paragraph.png)

Пример кода ниже показывает, как увеличить интервал между символами в **текстовых фрагментах с полужирным шрифтом**:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // Примечание: используйте отрицательные значения для сжатия межсимвольного интервала.
            portion.getPortionFormat().setSpacing(3); // Увеличить межсимвольный интервал.
        }
    }

    presentation.save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Результат:

![The character spacing in the text portions](character_spacing_in_text_portions.png)

### **Отключить кернинг для конкретных шрифтов**

В некоторых случаях текст, отрисованный Aspose.Slides, может выглядеть чуть плотнее, чем тот же текст в PowerPoint. Это происходит потому, что PowerPoint может игнорировать данные кернинга для определённых шрифтов, даже если шрифт содержит корректную информацию о кернинге и кернинг включён в настройках PowerPoint.

Чтобы сделать вывод более похожим на PowerPoint в подобных ситуациях, можно отключить кернинг для текстовых фрагментов, использующих затронутый шрифт. Установите [IBasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ibaseportionformat/#setKerningMinimalSize-float-) в значение, значительно превышающее фактический размер шрифта:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    String targetFont = "Roboto";

    for (IParagraph paragraph : autoShape.getTextFrame().getParagraphs()) {
        for (IPortion portion : paragraph.getPortions()) {
            IPortionFormat portionFormat = portion.getPortionFormat();

            if ((portionFormat.getLatinFont() != null &&
                 portionFormat.getLatinFont().getFontName().equals(targetFont)) ||
                (portionFormat.getEastAsianFont() != null &&
                 portionFormat.getEastAsianFont().getFontName().equals(targetFont)) ||
                (portionFormat.getComplexScriptFont() != null &&
                 portionFormat.getComplexScriptFont().getFontName().equals(targetFont))) {
                portionFormat.setKerningMinimalSize(100);
            }
        }
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Эта настройка предотвращает применение кернинга к соответствующим текстовым фрагментам и помогает согласовать рендеринг Aspose.Slides с визуальным выводом PowerPoint для шрифтов, затронутых этим специфическим поведением PowerPoint.

## **Управление свойствами шрифта текста**

Свойства шрифта можно задать на уровне абзаца через [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) или для отдельных фрагментов через [IPortionFormat](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iportionformat/).

Следующий код задаёт шрифт и стиль текста для всего абзаца: применяется размер шрифта, полужирный, курсив, пунктирное подчеркивание и шрифт Times New Roman для всех фрагментов абзаца.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Задать свойства шрифта для абзаца.
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

![The font properties for the paragraph](font_properties_for_paragraph.png)

Ниже пример кода, применяющего аналогичные свойства к **текстовым фрагментам с полужирным шрифтом**:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // Задать свойства шрифта для текстового фрагмента.
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

![The font properties for text portions](font_properties_for_text_portions.png)

## **Установить вращение текста**

Используйте [ITextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/ru/java/com.aspose.slides/itextframeformat/#setTextVerticalType-byte-) чтобы задать предопределённую ориентацию текста внутри фигуры.

Следующий пример кода устанавливает ориентацию текста в фигуре в `Vertical270`, что вращает текст **на 90 градусов против часовой стрелки**:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setTextVerticalType(TextVerticalType.Vertical270);

    presentation.save("text_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Результат:

![The text rotation](text_rotation.png)

## **Установить пользовательское вращение для текстовых рамок**

Используйте [ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/ru/java/com.aspose.slides/itextframeformat/#setRotationAngle-float-) чтобы задать пользовательский угол вращения для [ITextFrame](https://reference.aspose.com/slides/ru/java/com.aspose.slides/itextframe/).

Пример кода ниже вращает текстовую рамку на 3 градуса по часовой стрелке внутри фигуры:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setRotationAngle(3);

    presentation.save("custom_text_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Результат:

![The custom text rotation](custom_text_rotation.png)

## **Установить межстрочный интервал абзацев**

Aspose.Slides предоставляет [IParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iparagraphformat/#setSpaceAfter-float-), [IParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iparagraphformat/#setSpaceBefore-float-) и [IParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iparagraphformat/#setSpaceWithin-float-) для управления интервалами абзацев. Эти свойства используются следующим образом:

* Используйте положительное значение, чтобы задать межстрочный интервал в процентах от высоты строки.
* Используйте отрицательное значение, чтобы задать межстрочный интервал в пунктах.

Следующий пример кода показывает, как задать межстрочный интервал внутри абзаца:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    paragraph.getParagraphFormat().setSpaceWithin(200);

    presentation.save("line_spacing.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Результат:

![The line spacing within the paragraph](line_spacing.png)

## **Установить тип автоподгонки для текстовых рамок**

[ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/ru/java/com.aspose.slides/itextframeformat/#setAutofitType-byte-) определяет, как текст будет вести себя, когда превышает границы своего контейнера. Используйте его, чтобы управлять тем, будет ли текст сжиматься, выходить за пределы или автоматически изменять размер фигуры.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setAutofitType(TextAutofitType.Shape);

    presentation.save("autofit_type.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Чтобы подсчитать строки после автоматического переноса и увидеть, как меняется ширина текста или фигуры, см. [Count Rendered Lines](/slides/ru/java/manage-paragraph/). Само количество строк не указывает, выходит ли текст за пределы контейнера.

## **Установить привязку текстовых рамок**

[ITextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/ru/java/com.aspose.slides/itextframeformat/#setAnchoringType-byte-) определяет, как текст позиционируется вертикально внутри фигуры, например, вверху, посередине или внизу.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setAnchoringType(TextAnchorType.Bottom);

    presentation.save("text_anchor.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Установить табуляцию текста**

Используйте [IParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iparagraphformat/#setDefaultTabSize-float-) и [IParagraphFormat.getTabs](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iparagraphformat/#getTabs--) для настройки табуляций в абзаце.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    paragraph.getParagraphFormat().setDefaultTabSize(100);
    paragraph.getParagraphFormat().getTabs().add(30, TabAlignment.Left);

    presentation.save("paragraph_tabs.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Результат:

![The paragraph tabs](paragraph_tabs.png)

## **Установить язык проверки орфографии**

Aspose.Slides предоставляет [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-), который позволяет задать язык проверки орфографии для текстового фрагмента. Язык проверки определяет, какой язык используется для проверки правописания и грамматики в PowerPoint.

Следующий пример кода показывает, как задать язык проверки орфографии для текстового фрагмента:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);

    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    FontData font = new FontData("SimSun");

    Portion textPortion = new Portion();
    textPortion.getPortionFormat().setComplexScriptFont(font);
    textPortion.getPortionFormat().setEastAsianFont(font);
    textPortion.getPortionFormat().setLatinFont(font);

    // Установить идентификатор языка проверки орфографии.
    textPortion.getPortionFormat().setLanguageId("zh-CN");

    textPortion.setText("1。");
    paragraph.getPortions().add(textPortion);

    presentation.save("proofing_language.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Установить язык по умолчанию**

Используйте [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/ru/java/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) чтобы определить язык по умолчанию для текста, создаваемого при загрузке или создании презентации.

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

Presentation presentation = new Presentation(loadOptions);
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Добавить новую форму прямоугольника с текстом.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 50);
    shape.getTextFrame().setText("Sample text");

    // Проверить язык первой части текста.
    IPortion portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    System.out.println(portion.getPortionFormat().getLanguageId());
} finally {
    presentation.dispose();
}
```

## **Установить стиль текста по умолчанию**

Чтобы применить форматирование текста по умолчанию на уровне презентации, используйте [IPresentation.getDefaultTextStyle](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ipresentation/#getDefaultTextStyle--).

Следующий пример кода показывает, как задать шрифт полужирный размером 14 пунктов для всего текста во всех слайдах новой презентации.

```java
import com.aspose.slides.*;

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

## **Извлечь текст с эффектом “Все заглавные”**

В PowerPoint применение эффекта шрифта **All Caps** делает так, что текст отображается заглавными буквами на слайде, даже если изначально был введён строчными. При получении такого текстового фрагмента с помощью Aspose.Slides библиотека возвращает текст точно в том виде, в каком он был введён. Чтобы получить отображаемый текст, проверьте [TextCapType](https://reference.aspose.com/slides/ru/java/com.aspose.slides/textcaptype/) и преобразуйте возвращённую строку в верхний регистр, когда значение равно `All`.

Допустим, у нас есть следующий текстовый блок на первом слайде файла sample2.pptx.

![The All Caps effect](all_caps_effect.png)

Пример кода ниже показывает, как извлечь текст с применённым эффектом **All Caps**:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample2.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
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

Чтобы изменить текст в таблице на слайде, используйте [ITable](https://reference.aspose.com/slides/ru/java/com.aspose.slides/itable/). Проходите по ячейкам и обновляйте каждую ячейку через [ICell.getTextFrame](https://reference.aspose.com/slides/ru/java/com.aspose.slides/icell/#getTextFrame--) и форматирование абзацев через [IParagraph.getParagraphFormat](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iparagraph/#getParagraphFormat--).

**Как применить градиентный цвет к тексту в слайде PowerPoint?**

Чтобы применить градиентный цвет к тексту, используйте [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ibaseportionformat/#getFillFormat--). Установите [IFillFormat.setFillType](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ifillformat/#setFillType-byte-) в [FillType.Gradient](https://reference.aspose.com/slides/ru/java/com.aspose.slides/filltype/) и настройте градиентные стопы, направление и прозрачность.
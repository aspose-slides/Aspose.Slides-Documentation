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
- межсимвольный интервал
- свойства шрифта
- семейство шрифтов
- вращение текста
- угол вращения
- текстовый фрейм
- межстрочный интервал
- свойство автоподгонки
- привязка текстового фрейма
- табуляция текста
- язык по умолчанию
- PowerPoint
- OpenDocument
- презентация
- Java
- Aspose.Slides
description: "Форматирование и стилизация текста в презентациях PowerPoint и OpenDocument с использованием Aspose.Slides для Java. Настройка шрифтов, цветов, выравнивания и прочего."
---
## **Обзор**

Эта статья показывает, как форматировать текст в презентациях PowerPoint и OpenDocument с использованием Aspose.Slides для Java. В ней рассматриваются цвета фона, прозрачность, межсимвольный интервал, свойства шрифта, вращение, интервалы абзацев, поведение автоподгонки, привязка текста, табуляция и настройки языка.

В примерах ниже мы будем использовать файл с именем «sample.pptx», который содержит один текстовый блок на первом слайде со следующим текстом:

![Пример текста](sample_text.png)

Чтобы найти и выделить буквальный текст или совпадения регулярных выражений, см. [Поиск и замена текста](/slides/ru/java/search-and-replace-text/).

## **Установка цвета фона текста**

Используйте [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) для установки цвета подсветки по умолчанию для абзаца, либо используйте [IBasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ibaseportionformat/#getHighlightColor--) для отдельных фрагментов текста.

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

![Серый абзац](gray_paragraph.png)

Пример кода ниже демонстрирует, как установить цвет фона для **фрагментов текста с полужирным шрифтом**:

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
            // Установить цвет подсветки для фрагмента текста.
            portion.getPortionFormat().getHighlightColor().setColor(Color.LIGHT_GRAY);
        }
    }

    presentation.save("gray_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Результат:

![Серые фрагменты текста](gray_text_portions.png)

## **Выравнивание абзацев текста**

Используйте [IParagraphFormat.setAlignment](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) для установки выравнивания абзаца внутри текстового фрейма. Значение может быть центрировано, выровнено по левому краю, по правому, по ширине и т.д.

Следующий пример кода показывает, как выровнять абзац по **центру**:

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

![Выровненный абзац](aligned_paragraph.png)

## **Установка прозрачности текста**

Прозрачность текста контролируется через альфа‑компонент цвета, назначенного [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ibaseportionformat/#getFillFormat--). В примерах ниже `alpha = 50` — это значение альфа‑канала ARGB в диапазоне 0–255, а не процент прозрачности.

Пример кода ниже показывает, как применить прозрачность к **всему абзацу**:

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

![Прозрачный абзац](transparent_paragraph.png)

Следующий пример кода показывает, как применить прозрачность к **фрагментам текста с полужирным шрифтом**:

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
            // Установить прозрачность фрагмента текста.
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

![Прозрачные фрагменты текста](transparent_text_portions.png)

## **Установка межсимвольного интервала для текста**

Используйте [IBasePortionFormat.setSpacing](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ibaseportionformat/#setSpacing-float-) для увеличения или уменьшения расстояния между символами в текстовом блоке.

Следующий Java‑код показывает, как расширить межсимвольный интервал в **всём абзаце**:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Примечание: используйте отрицательные значения, чтобы сжать межсимвольный интервал.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3); // Увеличить межсимвольный интервал.

    presentation.save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Результат:

![Межсимвольный интервал в абзаце](character_spacing_in_paragraph.png)

Пример кода ниже показывает, как расширить межсимвольный интервал в **фрагментах текста с полужирным шрифтом**:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // Примечание: используйте отрицательные значения, чтобы сжать межсимвольный интервал.
            portion.getPortionFormat().setSpacing(3); // Увеличить межсимвольный интервал.
        }
    }

    presentation.save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Результат:

![Межсимвольный интервал в фрагментах текста](character_spacing_in_text_portions.png)

### **Отключение кёрнинга для определённых шрифтов**

В некоторых случаях текст, отрисованный Aspose.Slides, может выглядеть несколько плотнее, чем тот же текст в PowerPoint. Это может происходить потому, что PowerPoint игнорирует данные кёрнинга для некоторых шрифтов, даже если шрифт содержит корректную информацию о кёрнинге и кёрнинг включён в настройках PowerPoint.

Чтобы отрисованный результат был ближе к выводу PowerPoint в таких случаях, можно отключить кёрнинг для фрагментов текста, использующих затронутый шрифт. Установите [IBasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ibaseportionformat/#setKerningMinimalSize-float-) в значение, значительно превышающее фактический размер шрифта:

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

Эта настройка препятствует применению кёрнинга к соответствующим фрагментам текста и может помочь согласовать вывод Aspose.Slides с визуальным выводом PowerPoint для шрифтов, затронутых этим специфическим поведением PowerPoint.

## **Управление свойствами шрифта текста**

Свойства шрифта можно задавать на уровне абзаца через [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) или для отдельных фрагментов через [IPortionFormat](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iportionformat/).

Следующий код задаёт шрифт и стиль текста для всего абзаца: он применяет размер шрифта, полужирное начертание, курсив, пунктирное подчеркивание и шрифт Times New Roman ко всем фрагментам в абзаце.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
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

![Свойства шрифта абзаца](font_properties_for_paragraph.png)

Пример кода ниже применяет аналогичные свойства к **фрагментам текста с полужирным шрифтом**:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // Установить свойства шрифта для фрагмента текста.
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

![Свойства шрифта фрагментов текста](font_properties_for_text_portions.png)

## **Установка вращения текста**

Используйте [ITextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/ru/java/com.aspose.slides/itextframeformat/#setTextVerticalType-byte-) для установки предопределённой ориентации текста внутри фигуры.

Пример кода ниже устанавливает ориентацию текста в фигуре на `Vertical270`, что вращает текст **на 90 градусов против часовой стрелки**:

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

![Вращение текста](text_rotation.png)

## **Установка пользовательского вращения для текстовых фреймов**

Используйте [ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/ru/java/com.aspose.slides/itextframeformat/#setRotationAngle-float-) для задания пользовательского угла вращения для [ITextFrame](https://reference.aspose.com/slides/ru/java/com.aspose.slides/itextframe/).

Пример кода ниже вращает текстовый фрейм на 3 градуса по часовой стрелке внутри фигуры:

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

![Пользовательское вращение текста](custom_text_rotation.png)

## **Установка межстрочного интервала абзацев**

Aspose.Slides предоставляет [IParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iparagraphformat/#setSpaceAfter-float-), [IParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iparagraphformat/#setSpaceBefore-float-), и [IParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iparagraphformat/#setSpaceWithin-float-) для управления интервалом абзацев. Эти свойства используются следующим образом:

* Используйте положительное значение, чтобы указать межстрочный интервал в процентах от высоты строки.
* Используйте отрицательное значение, чтобы указать межстрочный интервал в пунктах.

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

![Межстрочный интервал в абзаце](line_spacing.png)

## **Установка типа автоподгонки для текстовых фреймов**

[ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/ru/java/com.aspose.slides/itextframeformat/#setAutofitType-byte-) определяет, как текст ведёт себя, когда превышает границы своего контейнера. Используйте его, чтобы контролировать, будет ли текст уменьшаться, выходить за пределы или автоматически изменять размер фигуры.

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

## **Установка привязки текстовых фреймов**

[ITextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/ru/java/com.aspose.slides/itextframeformat/#setAnchoringType-byte-) определяет, как текст позиционируется вертикально внутри фигуры, например вверху, по центру или внизу.

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

## **Установка табуляции текста**

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

![Табуляции абзаца](paragraph_tabs.png)

## **Установка языка проверки правописания**

Aspose.Slides предоставляет [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-), позволяя задать язык проверки правописания для фрагмента текста. Язык проверки определяет язык, используемый для проверки орфографии и грамматики в PowerPoint.

Следующий пример кода показывает, как установить язык проверки правописания для фрагмента текста:

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

    // Установить идентификатор языка проверки.
    textPortion.getPortionFormat().setLanguageId("zh-CN");

    textPortion.setText("1。");
    paragraph.getPortions().add(textPortion);

    presentation.save("proofing_language.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Установка языка по умолчанию**

Используйте [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/ru/java/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) для определения языка по умолчанию для текста, создаваемого при загрузке или создании презентации.

```java
import com.aspose.slides.*;

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

Чтобы применить форматирование текста по умолчанию на уровне презентации, используйте [IPresentation.getDefaultTextStyle](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ipresentation/#getDefaultTextStyle--).

Следующий пример кода показывает, как задать шрифт по умолчанию полужирным размером 14 пунктов для всего текста на всех слайдах в новой презентации.

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

## **Извлечение текста с эффектом ПРОПИСНЫХ БУКВ**

В PowerPoint применение эффекта шрифта **All Caps** делает текст заглавными буквами на слайде, даже если он был изначально набран строчными. При получении такого фрагмента текста с помощью Aspose.Slides библиотека возвращает текст точно таким, каким он был введён. Чтобы соответствовать отображаемому тексту, проверьте [TextCapType](https://reference.aspose.com/slides/ru/java/com.aspose.slides/textcaptype/) и преобразуйте возвращённую строку в верхний регистр, когда значение равно `All`.

Допустим, у нас есть следующий текстовый блок на первом слайде файла sample2.pptx.

![Эффект всех прописных](all_caps_effect.png)

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

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **FAQ**

**Как изменить текст в таблице на слайде?**

Для изменения текста в таблице на слайде используйте [ITable](https://reference.aspose.com/slides/ru/java/com.aspose.slides/itable/). Переберите ячейки и обновите каждую ячейку через [ICell.getTextFrame](https://reference.aspose.com/slides/ru/java/com.aspose.slides/icell/#getTextFrame--) и форматирование абзацев через [IParagraph.getParagraphFormat](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iparagraph/#getParagraphFormat--).

**Как применить градиентный цвет к тексту в слайде PowerPoint?**

Чтобы применить градиентный цвет к тексту, используйте [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ibaseportionformat/#getFillFormat--). Установите [IFillFormat.setFillType](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ifillformat/#setFillType-byte-) в значение [FillType.Gradient](https://reference.aspose.com/slides/ru/java/com.aspose.slides/filltype/) и настройте точки градиента, направление и прозрачность.
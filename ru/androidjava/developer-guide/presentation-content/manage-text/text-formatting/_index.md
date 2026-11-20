---
title: Форматирование текста презентации на Android
linktitle: Форматирование текста
type: docs
weight: 50
url: /ru/androidjava/text-formatting/
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
- Android
- Java
- Aspose.Slides
description: "Форматируйте и стилизуйте текст в презентациях PowerPoint и OpenDocument с помощью Aspose.Slides для Android через Java. Настраивайте шрифты, цвета, выравнивание и многое другое."
---
## **Обзор**

В этой статье показано, как форматировать текст в презентациях PowerPoint и OpenDocument с помощью Aspose.Slides для Android через Java. Рассматриваются цвета фона, прозрачность, интервалы между символами, свойства шрифтов, вращение, интервалы между абзацами, поведение автоподгонки, привязка текста, табуляция и настройки языка.

Если не указано иначе, в примерах используется [sample.pptx](sample.pptx). Первая фигура на первом слайде — это текстовое поле, и его первый абзац содержит показанный ниже текст. Индексы слайдов и фигур нумеруются с нуля. Примеры, в которых выделяются жирные части, используют эффективное форматирование, включая унаследованное жирное форматирование:

![Пример текста](sample_text.png)

Чтобы найти и выделить буквальный текст или совпадения регулярных выражений, см. [Поиск и замена текста](/slides/ru/androidjava/search-and-replace-text/).

## **Установить цвет фона текста**

Используйте [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) чтобы установить цвет подсветки по умолчанию для абзаца, либо используйте [IBasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#getHighlightColor--) для отдельных текстовых частей.

Следующий пример задаёт светло‑серую подсветку как значение по умолчанию для первого абзаца. Явные цвета подсветки в отдельных частях имеют приоритет перед этим значением по умолчанию:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
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

Пример кода ниже демонстрирует, как установить цвет фона для **текстовых частей с жирным шрифтом**:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // Установить цвет подсветки для текстовой части.
            portion.getPortionFormat().getHighlightColor().setColor(Color.LTGRAY);
        }
    }

    presentation.save("gray_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Результат:

![Серые текстовые части](gray_text_portions.png)

## **Выровнять абзацы текста**

Используйте [IParagraphFormat.setAlignment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) чтобы установить выравнивание абзаца внутри текстовой рамки. Значение может быть центрировано, выровнено по левому краю, по правому краю, выровнено по ширине и т.д.

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

![Выровненный абзац](aligned_paragraph.png)

## **Выровнять шрифты в строке**

Используйте [IParagraphFormat.setFontAlignment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setFontAlignment-int-) чтобы вертикально выровнять текстовые части разных размеров шрифта в одной строке. Эта настройка применяется ко всему абзацу и контролирует выравнивание внутри каждой строки.

Следующий автономный пример создаёт четыре помеченных текстовых поля на одном слайде. Каждый абзац содержит одинаковый текст размером 18, 36 и 54 пункта с разным выравниванием шрифта. Используется Arial, отключены автоподгонка и перенос, а текстовые рамки достаточно велики для одной строки.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int[] alignments = { FontAlignment.Baseline, FontAlignment.Top, FontAlignment.Center, FontAlignment.Bottom };
    String[] alignmentNames = { "Baseline", "Top", "Center", "Bottom" };
    float[] fontSizes = { 18f, 36f, 54f };

    for (int i = 0; i < alignments.length; i++) {
        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 20 + i * 130, 660, 120);
        shape.getFillFormat().setFillType(FillType.NoFill);
        shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

        ITextFrame textFrame = shape.getTextFrame();
        textFrame.getTextFrameFormat().setAnchoringType(TextAnchorType.Top);
        textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.None);
        textFrame.getTextFrameFormat().setWrapText(NullableBool.False);

        IParagraph label = textFrame.getParagraphs().get_Item(0);
        label.setText(alignmentNames[i]);
        label.getParagraphFormat().setAlignment(TextAlignment.Left);
        label.getParagraphFormat().getDefaultPortionFormat().setFontHeight(14);
        label.getParagraphFormat().getDefaultPortionFormat().setLatinFont(new FontData("Arial"));
        label.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
        label.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);

        Paragraph paragraph = new Paragraph();
        paragraph.getParagraphFormat().setFontAlignment(alignments[i]);
        paragraph.getParagraphFormat().setAlignment(TextAlignment.Left);
        paragraph.getParagraphFormat().getDefaultPortionFormat().setLatinFont(new FontData("Arial"));
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);

        for (float fontSize : fontSizes) {
            Portion portion = new Portion("Ag ");
            portion.getPortionFormat().setFontHeight(fontSize);
            paragraph.getPortions().add(portion);
        }

        textFrame.getParagraphs().add(paragraph);
    }

    presentation.save("font_alignment.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Результат:

![Сравнение выравнивания шрифтов по базовой линии, верхнему, центру и нижнему при смешанных размерах шрифта](font_alignment.png)

Выравнивание шрифтов использует метрики шрифта, поэтому видимые края отдельных букв не всегда совмещаются точно. В примере присутствует и заглавная буква, и нижний вынос, чтобы показать различие между базовой линией и нижним выравниванием. Доступность шрифта и его подстановка, используемые символы и различие в размерах шрифта влияют на результат. Размеры рамки, отступы, межстрочный интервал, перенос и автоподгонка также влияют на раскладку; при сравнении режимов используйте одинаковые шрифты и настройки макета.

Эта настройка отличается от [IParagraphFormat.setAlignment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-), который управляет горизонтальным выравниванием абзаца, и от [ITextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setAnchoringType-byte-), который позиционирует текстовый блок вертикально внутри фигуры. Форматирование надстрочного и подстрочного текста через [IBasePortionFormat.setEscapement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#setEscapement-float-) сдвигает отдельные части относительно базовой линии, а не задаёт выравнивание шрифта для строк абзаца.

## **Установить прозрачность текста**

Прозрачность текста управляется альфа‑компонентой цвета, назначенного [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#getFillFormat--). В примерах ниже `alpha = 50` — это значение альфа‑канала ARGB в диапазоне 0–255, а не процент прозрачности.

Пример кода ниже показывает, как применить прозрачность к **всему абзацу**:

```java
import com.aspose.slides.*;
import android.graphics.Color;

int alpha = 50;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
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

Следующий пример кода показывает, как применить прозрачность к **текстовым частям с жирным шрифтом**:

```java
import com.aspose.slides.*;
import android.graphics.Color;

int alpha = 50;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // Установить прозрачность текстовой части.
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

![Прозрачные текстовые части](transparent_text_portions.png)

## **Установить интервал между символами текста**

Используйте [IBasePortionFormat.setSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#setSpacing-float-) чтобы увеличить или уменьшить интервал между символами в текстовом поле. В примерах добавляется интервал в 3 пункта; отрицательные значения сжимают текст.

Следующий код Java показывает, как увеличить интервал между символами в **всём абзаце**:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Примечание: используйте отрицательные значения для сжатия интервала между символами.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3); // Увеличить интервал между символами.

    presentation.save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Результат:

![Интервал между символами в абзаце](character_spacing_in_paragraph.png)

Пример кода ниже показывает, как увеличить интервал между символами в **текстовых частях с жирным шрифтом**:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // Примечание: используйте отрицательные значения для сжатия интервала между символами.
            portion.getPortionFormat().setSpacing(3); // Увеличить интервал между символами.
        }
    }

    presentation.save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Результат:

![Интервал между символами в текстовых частях](character_spacing_in_text_portions.png)

### **Отключить кернинг для конкретных шрифтов**

В некоторых случаях текст, отрисованный Aspose.Slides, выглядит чуть плотнее, чем тот же текст в PowerPoint. Это может происходить потому, что PowerPoint игнорирует данные кернинга для некоторых шрифтов, даже если шрифт содержит корректные данные и кернинг включён в настройках PowerPoint.

Чтобы сделать результат ближе к PowerPoint, можно отключить кернинг для текстовых частей, использующих затронутый шрифт. Установите [IBasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#setKerningMinimalSize-float-) в значение, большее фактического размера шрифта. Пример требует файл "presentation.pptx" с текстовым полем в первой фигуре первого слайда. Он проверяет эффективные имена шрифтов, включая унаследованные, и задаёт порог в 100 пунктов для частей, использующих Roboto. Это отключает кернинг для совпадающих частей, у которых размер шрифта ниже 100 пунктов:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    String targetFont = "Roboto";

    for (IParagraph paragraph : autoShape.getTextFrame().getParagraphs()) {
        for (IPortion portion : paragraph.getPortions()) {
            IPortionFormatEffectiveData portionFormat = portion.getPortionFormat().getEffective();

            if ((portionFormat.getLatinFont() != null &&
                 portionFormat.getLatinFont().getFontName().equals(targetFont)) ||
                (portionFormat.getEastAsianFont() != null &&
                 portionFormat.getEastAsianFont().getFontName().equals(targetFont)) ||
                (portionFormat.getComplexScriptFont() != null &&
                 portionFormat.getComplexScriptFont().getFontName().equals(targetFont))) {
                portion.getPortionFormat().setKerningMinimalSize(100);
            }
        }
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Для текста ниже порога такая настройка предотвращает кернинг и помогает согласовать рендеринг Aspose.Slides с визуальным выводом PowerPoint для шрифтов, затронутых этим специфическим для PowerPoint поведением.

## **Управление свойствами шрифта текста**

Свойства шрифта можно задавать на уровне абзаца через [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) или для отдельных частей через [IPortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iportionformat/).

Следующий пример задаёт для первого абзаца шрифт Times New Roman 12 пунктов, жирный, курсив и пунктирное подчеркивание. Явное форматирование отдельных частей имеет приоритет над этими значениями по умолчанию.

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

![Свойства шрифта для абзаца](font_properties_for_paragraph.png)

Следующий пример применяет к частям, у которых эффективное форматирование жирное, шрифт Times New Roman 13 пунктов, курсив и пунктирное подчеркивание:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // Установить свойства шрифта для текстовой части.
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

![Свойства шрифта для текстовых частей](font_properties_for_text_portions.png)

## **Управление нормализацией высоты текста**

Используйте [IBasePortionFormat.setNormaliseHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#setNormaliseHeight-byte-) при воспроизведении типографии шаблона или исследовании различий в высоте символов. В PowerPoint включение нормализации растягивает или сжимает отдельные символы по вертикали, чтобы они имели одинаковую видимую высоту внутри текстовой части. Это не гарантирует одинаковую высоту текста для разных шрифтов.

Установите свойство в [NullableBool.True or False](https://reference.aspose.com/slides/androidjava/com.aspose.slides/nullablebool/) для явного включения или отключения нормализации. `NullableBool.NotDefined` оставляет локальную настройку неустановленной, позволяя части наследовать значение, например, из [getDefaultPortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) абзаца. Это не то же самое, что `False`. Используйте [IPortionFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iportionformat/#getEffective--) и читайте [IBasePortionFormatEffectiveData.getNormaliseHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformateffectivedata/#getNormaliseHeight--) для получения окончательного булевого значения.

Следующий автономный пример требует установленный **Arial**. Он создаёт два текстовых блока, содержащие одинаковые заглавные буквы, строчные, нижние выносы и буквенные символы с ударениями размером 54 пункта. Оба абзаца включают нормализацию по умолчанию. Верхняя часть явно отключает её; нижняя наследует настройку. Размеры рамок, отступы и интервалы между абзацами идентичны, перенос и автоподгонка отключены для сохранения согласованности сравнения. Пример выводит `False: false` и `NotDefined: true`, затем сохраняет файл "text_height_normalization.pptx".

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    byte[] settings = { NullableBool.False, NullableBool.NotDefined };
    String[] settingNames = { "False", "NotDefined" };

    for (int i = 0; i < settings.length; i++) {
        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 60 + i * 200, 660, 150);
        shape.getFillFormat().setFillType(FillType.NoFill);
        shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

        ITextFrame textFrame = shape.getTextFrame();
        textFrame.setText("Hxgjpq ÅÉ 0123");
        textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.None);
        textFrame.getTextFrameFormat().setWrapText(NullableBool.False);
        textFrame.getTextFrameFormat().setAnchoringType(TextAnchorType.Top);
        textFrame.getTextFrameFormat().setMarginTop(0);
        textFrame.getTextFrameFormat().setMarginLeft(0);

        IParagraph paragraph = textFrame.getParagraphs().get_Item(0);
        paragraph.getParagraphFormat().setAlignment(TextAlignment.Left);
        paragraph.getParagraphFormat().setSpaceBefore(0);
        paragraph.getParagraphFormat().setSpaceAfter(0);
        paragraph.getParagraphFormat().setSpaceWithin(100);
        paragraph.getParagraphFormat().getDefaultPortionFormat().setNormaliseHeight(NullableBool.True);

        IPortion portion = paragraph.getPortions().get_Item(0);
        FontData font = new FontData("Arial");
        portion.getPortionFormat().setLatinFont(font);
        portion.getPortionFormat().setFontHeight(54);
        portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
        portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
        portion.getPortionFormat().setNormaliseHeight(settings[i]);

        System.out.println(settingNames[i] + ": " + portion.getPortionFormat().getEffective().getNormaliseHeight());
    }

    presentation.save("text_height_normalization.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Сравнение ниже экспортировано из сохранённой презентации. В верхней строке нормализация отключена (`False`); в нижней строке она унаследована (`NotDefined` → `True`). Оставьте установленный Arial, чтобы воспроизвести внешний вид.

![Текст Arial 54 пункта с отключенной нормализацией сверху и унаследованной нормализацией снизу](text_height_normalization.png)

Нормализация изменяет высоту символов без изменения назначенного значения [getFontHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#getFontHeight--), которое задаёт размер шрифта в пунктах. Абзацный [setSpaceWithin](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setSpaceWithin-float-) контролирует межстрочный интервал, а [setAutofitType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setAutofitType-byte-) в текстовой рамке управляет тем, как текст или её контейнер подстраивается под размер. Эти настройки служат разным целям и могут независимо влиять на общую раскладку. Дополнительные сведения о форматировании абзацев и наследовании см. в разделе [Manage Paragraph](/slides/ru/androidjava/manage-paragraph/).

## **Применить и убрать зачеркивание**

Используйте [IBasePortionFormat.setStrikethroughType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#setStrikethroughType-byte-) на текстовой части, чтобы отобразить исправления, отменённые термины или прежние цены без удаления исходного текста. Установите значение [TextStrikethroughType.Single or Double](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textstrikethroughtype/) для одной или двух линий через текст.

Чтобы убрать зачеркивание, передайте [TextStrikethroughType.None](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textstrikethroughtype/#None). Это явно отключает эффект, даже если окружающее форматирование задаёт зачеркивание. В отличие от этого, [TextStrikethroughType.NotDefined](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textstrikethroughtype/#NotDefined) оставляет локальную настройку неопределенной, позволяя части наследовать форматирование, например, от абзаца. Это не гарантирует удаление зачеркивания. Используйте [IPortionFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iportionformat/#getEffective--) для чтения итогового форматирования, включая унаследованные значения.

Следующий автономный пример создает три сравнения цен. В каждом абзаце отдельные части для метки, прошлой цены и текущей цены, поэтому только прошлая цена затрагивается. В первой строке зачеркивание применяется, а затем удаляется; остальные строки сохраняют одинарное и двойное зачеркивание. Изменение этой настройки сохраняет текст и его прочее форматирование, включая жирную прошлую цену.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 620, 220);
    shape.getFillFormat().setFillType(FillType.NoFill);
    shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
    shape.getTextFrame().getParagraphs().clear();

    String[] labels = { "None: ", "Single: ", "Double: " };

    for (String label : labels) {
        Paragraph paragraph = new Paragraph();
        paragraph.getParagraphFormat().setAlignment(TextAlignment.Left);
        paragraph.getParagraphFormat().setSpaceAfter(20);

        IPortionFormat format = paragraph.getParagraphFormat().getDefaultPortionFormat();
        format.setFontHeight(28);
        FontData font = new FontData("Arial");
        format.setLatinFont(font);
        format.getFillFormat().setFillType(FillType.Solid);
        format.getFillFormat().getSolidFillColor().setColor(Color.BLACK);

        Portion labelPortion = new Portion(label);
        paragraph.getPortions().add(labelPortion);

        Portion previousPrice = new Portion("$100");
        previousPrice.getPortionFormat().setFontBold(NullableBool.True);
        paragraph.getPortions().add(previousPrice);
        Portion currentPrice = new Portion(" → $80");
        paragraph.getPortions().add(currentPrice);

        shape.getTextFrame().getParagraphs().add(paragraph);
    }

    IParagraphCollection paragraphs = shape.getTextFrame().getParagraphs();

    // Применить зачеркивание, затем явно удалить его из первой предыдущей цены.
    paragraphs.get_Item(0).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.Single);
    paragraphs.get_Item(0).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.None);

    paragraphs.get_Item(1).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.Single);
    paragraphs.get_Item(2).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.Double);

    presentation.save("strikethrough.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Результат сверху вниз: без зачеркивания, с одинарным зачеркиванием и с двойным зачеркиванием.

![Предыдущие цены без зачеркивания, с одинарным зачеркиванием и с двойным зачеркиванием](strikethrough.png)

## **Установить вращение текста**

Используйте [ITextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setTextVerticalType-byte-) чтобы задать предопределённую ориентацию текста внутри фигуры.

Следующий пример кода задаёт ориентацию текста в фигуре как [TextVerticalType.Vertical270](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textverticaltype/), что вращает текст **на 90 градусов против часовой стрелки**:

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

## **Установить пользовательское вращение для текстовых рамок**

Используйте [ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setRotationAngle-float-) чтобы задать пользовательский угол вращения для [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/).

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

![Пользовательское вращение текста](custom_text_rotation.png)

## **Установить межстрочный интервал абзацев**

Aspose.Slides предоставляет [IParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setSpaceAfter-float-), [IParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setSpaceBefore-float-) и [IParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setSpaceWithin-float-) для управления интервалами абзацев. Эти свойства используются следующим образом:

* Используйте положительное значение, чтобы задать межстрочный интервал в процентах от высоты строки.
* Используйте отрицательное значение, чтобы задать межстрочный интервал в пунктах.

Следующий пример задаёт интервал внутри первого абзаца как 200 % от высоты строки (двойной интервал):

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

## **Управление разрывом строк**

Правила разрыва строк абзаца полезны в узких текстовых блоках и презентациях, где смешаны латинский и восточноазиатский тексты. Нижеуказанные методы принадлежат [IParagraphFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/), поэтому они применяются к целому абзацу:

- [setLatinLineBreak](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setLatinLineBreak-byte-) контролирует правила разрыва строк для латиницы. В смешанном тексте изменение может также изменить место переноса соседнего восточноазиатского текста и пунктуации.
- [setEastAsianLineBreak](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setEastAsianLineBreak-byte-) контролирует правила разрыва строк для восточноазиатского текста, включая ограничения на символы в начале и конце строки.

Эти правила не заменяют [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setWrapText-byte-), который включает автоматический перенос внутри текстовой рамки. Они влияют на раскладку при переносе, но не вставляют символы разрыва строки. Явный разрыв строки заставляет начать новую строку в абзаце независимо от доступной ширины.

Следующий автономный пример создаёт узкий текстовый блок, содержащий китайский и латинский тексты. Он явно задаёт обе опции разрыва строк и сохраняет файл "line_breaking.pptx". Чтобы поэкспериментировать с любой из правил, измените соответствующее значение, оставив остальные настройки неизменными. В примере используется Arial и SimSun размером 24 пункта, ширина рамки 160 пунктов и нулевые горизонтальные отступы рамки. [ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setAutofitType-byte-) вызывается с [TextAutofitType.None](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textautofittype/), чтобы размер текста и рамки оставались фиксированными.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 160, 300);
    shape.getFillFormat().setFillType(FillType.NoFill);

    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setWrapText(NullableBool.True);
    textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.None);
    textFrame.getTextFrameFormat().setMarginLeft(0);
    textFrame.getTextFrameFormat().setMarginRight(0);

    IParagraph paragraph = textFrame.getParagraphs().get_Item(0);
    paragraph.setText("中文排版测试，PowerPoint 中文演示。");

    IParagraphFormat format = paragraph.getParagraphFormat();
    format.setAlignment(TextAlignment.Left);
    format.getDefaultPortionFormat().setFontHeight(24);
    FontData latinFont = new FontData("Arial");
    format.getDefaultPortionFormat().setLatinFont(latinFont);
    FontData eastAsianFont = new FontData("SimSun");
    format.getDefaultPortionFormat().setEastAsianFont(eastAsianFont);
    format.getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    format.getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    format.setLatinLineBreak(NullableBool.False);
    format.setEastAsianLineBreak(NullableBool.True);

    presentation.save("line_breaking.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Управление нависающей пунктуацией**

[IParagraphFormat.setHangingPunctuation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setHangingPunctuation-byte-) позволяет допускаемой пунктуации выступать за правый край строки вместо того, чтобы занимать следующую строку. Применяется ко всему абзацу и отличается от висячего отступа.

Следующий автономный пример включает нависающую пунктуацию в 100‑пунктовой широкой текстовой рамке и сохраняет файл "hanging_punctuation.pptx". При 24‑пунктовом Arial и нулевых горизонтальных отступах конечная точка остаётся после слова «sentence» и выступает за правый край текста. Установите свойство в [NullableBool.False](https://reference.aspose.com/slides/androidjava/com.aspose.slides/nullablebool/) для сравнения: при этих настройках точка занимает отдельную строку. Перенос включён, автоподгонка отключена, чтобы ширина оставалась фиксированной.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 100, 200);
    shape.getFillFormat().setFillType(FillType.NoFill);

    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setWrapText(NullableBool.True);
    textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.None);
    textFrame.getTextFrameFormat().setMarginLeft(0);
    textFrame.getTextFrameFormat().setMarginRight(0);

    IParagraph paragraph = textFrame.getParagraphs().get_Item(0);
    paragraph.setText("Simple text, next sentence.");

    IParagraphFormat format = paragraph.getParagraphFormat();
    format.setAlignment(TextAlignment.Left);
    format.getDefaultPortionFormat().setFontHeight(24);
    FontData latinFont = new FontData("Arial");
    format.getDefaultPortionFormat().setLatinFont(latinFont);
    format.getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    format.getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    format.setHangingPunctuation(NullableBool.True);

    presentation.save("hanging_punctuation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Не каждый знак пунктуации может нависать. Указанные выше [условия шрифта и макета](#control-line-breaking) также применимы к этому сравнению: изменение шрифта, доступной ширины, отступов или настроек автоподгонки может убрать видимую разницу.

## **Установить тип автоподгонки для текстовых рамок**

[ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setAutofitType-byte-) определяет, как текст ведёт себя, когда превышает границы контейнера. Используйте её для управления тем, сжимается ли текст, выходит за пределы или автоматически изменяет размер фигуры. В следующем примере фигура настроена на изменение размера под текст, результат сохраняется в файл "autofit_type.pptx".

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

Чтобы подсчитать строки после автоматического переноса и увидеть, как изменяется ширина текста или фигуры, см. [Count Rendered Lines](/slides/ru/androidjava/manage-paragraph/). Само количество строк не указывает, выходит ли текст за пределы контейнера.

## **Установить привязку текстовых рамок**

[ITextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setAnchoringType-byte-) определяет, как текст позиционируется вертикально внутри фигуры, например, вверху, по центру или внизу. Следующий пример привязывает текст к нижней части первой фигуры и сохраняет результат в файл "text_anchor.pptx".

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

Используйте [IParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setDefaultTabSize-float-) и [IParagraphFormat.getTabs](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#getTabs--) для настройки табуляций в абзаце. В следующем примере задаётся интервал табуляций по умолчанию 100 пунктов и добавляется левый таб‑стоп на 30 пунктов. Эти настройки влияют на текст, содержащий символы табуляции.

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

![Табуляция абзаца](paragraph_tabs.png)

## **Установить язык проверки правописания**

Aspose.Slides предоставляет [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-), который позволяет задать язык проверки правописания для текстовой части. Язык проверки определяет язык, используемый для проверки орфографии и грамматики в PowerPoint.

Следующий пример требует файл "presentation.pptx" с текстовым полем в первой фигуре первого слайда и как минимум одним абзацем. Он заменяет содержимое первого абзаца на «1。», задаёт SimSun как шрифт и назначает язык проверки упрощённого китайского (`zh-CN`). Результат сохраняется в файл "proofing_language.pptx":

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

    // Установить Id языка проверки.
    textPortion.getPortionFormat().setLanguageId("zh-CN");

    textPortion.setText("1。");
    paragraph.getPortions().add(textPortion);

    presentation.save("proofing_language.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Копировать метаданные языка**

При копировании многоязычного текста из шаблона необходимо сохранять как [IBasePortionFormat.getLanguageId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#getLanguageId--), так и [IBasePortionFormat.getAlternativeLanguageId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#getAlternativeLanguageId--). Следующий автономный пример создаёт исходную часть с языком US English и альтернативным языком French и копирует текст и идентификаторы в часть новой презентации.

```java
import com.aspose.slides.*;

Portion source = new Portion("Hello! Bonjour!");
source.getPortionFormat().setLanguageId("en-US");
source.getPortionFormat().setAlternativeLanguageId("fr-FR");

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 80);
    IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    Portion destination = new Portion();
    destination.setText(source.getText());
    destination.getPortionFormat().setLanguageId(source.getPortionFormat().getLanguageId());
    // Если у источника нет альтернативного языка, null очищает значение назначения.
    destination.getPortionFormat().setAlternativeLanguageId(source.getPortionFormat().getAlternativeLanguageId());
    paragraph.getPortions().add(destination);

    presentation.save("copied_language_metadata.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Чтобы попробовать источник без альтернативного языка, опустите присвоение «fr-FR». Тогда альтернативный идентификатор будет `null`, и то же выражение копирования сохранит его отсутствие без введения значения по умолчанию, даже если в назначении ранее был указан альтернативный язык.

Эти идентификаторы хранят языковые метаданные. Их сохранение не определяет, какой словарь PowerPoint выберет для проверки орфографии или грамматики.

## **Установить язык по умолчанию**

Используйте [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) для определения языка текста по умолчанию при загрузке или создании презентации. В следующем примере создаётся презентация с английским (США) как языком текста по умолчанию, добавляется текстовое поле и выводится `en-US` для первой текстовой части.

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

Presentation presentation = new Presentation(loadOptions);
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Добавить новую прямоугольную фигуру с текстом.
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

Чтобы задать форматирование текста по умолчанию на уровне презентации, используйте [IPresentation.getDefaultTextStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentation/#getDefaultTextStyle--).

В следующем примере задаётся шрифт 14 пунктов, жирный, как значение по умолчанию для абзацев верхнего уровня в новой презентации и сохраняется в файл "default_text_style.pptx". Текст может наследовать эти значения, если более конкретное форматирование их не переопределит.

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

## **Извлечь текст с эффектом All-Caps**

В PowerPoint применение эффекта шрифта **All Caps** делает текст отображаемым заглавными буквами на слайде, даже если он изначально набран строчными. При получении такой части текста с помощью Aspose.Slides библиотека возвращает текст точно в том виде, в каком он был введён. Чтобы получить отображаемый вариант, проверьте [TextCapType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textcaptype/) и преобразуйте возвращённую строку в верхний регистр, когда значение равно `All`.

Этот пример требует файл "sample2.pptx" с текстовым полем в первой фигуре первого слайда. Первая часть первого абзаца содержит «Hello, Aspose!», к которой применён эффект All Caps, как показано ниже.

![Эффект All Caps](all_caps_effect.png)

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

Для изменения текста в таблице на слайде используйте [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/). Пройдитесь по ячейкам и обновите каждую через [ICell.getTextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getTextFrame--) и форматирование абзаца через [IParagraph.getParagraphFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/#getParagraphFormat--).

**Как применить градиентный цвет к тексту на слайде PowerPoint?**

Для применения градиентного цвета к тексту используйте [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#getFillFormat--). Установите [IFillFormat.setFillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#setFillType-byte-) в [FillType.Gradient](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) и настройте градиентные стопы, направление и прозрачность.
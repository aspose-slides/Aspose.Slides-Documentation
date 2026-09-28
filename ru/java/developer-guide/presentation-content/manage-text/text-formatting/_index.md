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
- текстовый кадр
- межстрочный интервал
- свойство автоподгонки
- привязка текстового кадра
- табуляция текста
- язык по умолчанию
- PowerPoint
- OpenDocument
- презентация
- Java
- Aspose.Slides
description: "Форматируйте и стилизуйте текст в презентациях PowerPoint и OpenDocument с помощью Aspose.Slides для Java. Настраивайте шрифты, цвета, выравнивание и многое другое."
---
## **Обзор**

В этой статье показано, как форматировать текст в презентациях PowerPoint и OpenDocument с помощью Aspose.Slides для Java. Описываются цвета фона, прозрачность, межсимвольный интервал, свойства шрифтов, вращение, интервалы абзацев, поведение автоподгонки, привязка текста, табуляции и настройки языка.

Если не указано иначе, примеры используют [sample.pptx](sample.pptx). Первая фигура на первом слайде – это текстовое поле, и его первый абзац содержит текст, показанный ниже. Индексы слайдов и фигур нумеруются с нуля. Примеры, выбирающие жирные фрагменты, используют эффективное форматирование, включая унаследованное жирное форматирование:

![Пример текста](sample_text.png)

Чтобы найти и выделить буквальный текст или совпадения регулярных выражений, см. [Поиск и замена текста](/slides/ru/java/search-and-replace-text/).

## **Установить цвет фона текста**

Используйте [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) для установки цвета подсветки по умолчанию для абзаца или [IBasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ibaseportionformat/#getHighlightColor--) для отдельных фрагментов текста.

Следующий пример задаёт светло-серую подсветку по умолчанию для первого абзаца. Явные цвета подсветки у отдельных фрагментов имеют приоритет над этим значением по умолчанию:

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

Ниже приведён пример кода, демонстрирующий, как установить цвет фона для **фрагментов текста с жирным шрифтом**:

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

![Серые фрагменты текста](gray_text_portions.png)

## **Выравнивание абзацев текста**

Используйте [IParagraphFormat.setAlignment](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) для установки выравнивания абзаца внутри текстового кадра. Значение может быть по центру, по левому краю, по правому краю, выровнено по ширине и т.д.

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

## **Установить прозрачность текста**

Прозрачность текста управляется альфа‑компонентой цвета, присвоенного [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ibaseportionformat/#getFillFormat--). В приведённых ниже примерах `alpha = 50` — это значение альфа‑канала ARGB в диапазоне 0–255, а не процент прозрачности.

Ниже показан пример кода, который применяет прозрачность к **целому абзацу**:

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

Следующий пример кода показывает, как применить прозрачность к **фрагментам текста с жирным шрифтом**:

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

![Прозрачные фрагменты текста](transparent_text_portions.png)

## **Установить межсимвольный интервал текста**

Используйте [IBasePortionFormat.setSpacing](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ibaseportionformat/#setSpacing-float-) для увеличения или уменьшения интервала между символами в текстовом поле. В примерах добавляется 3 поинта интервала; отрицательные значения сжимают текст.

Ниже приведён Java‑код, показывающий, как увеличить межсимвольный интервал в **всём абзаце**:

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

![Межсимвольный интервал в абзаце](character_spacing_in_paragraph.png)

Пример кода ниже демонстрирует увеличение межсимвольного интервала в **фрагментах текста с жирным шрифтом**:

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

![Межсимвольный интервал в фрагментах текста](character_spacing_in_text_portions.png)

### **Отключить кернинг для конкретных шрифтов**

В некоторых случаях текст, отрисованный Aspose.Slides, может выглядеть немного плотнее, чем тот же текст в PowerPoint. Это может происходить, потому что PowerPoint игнорирует данные кернинга для определённых шрифтов, даже если шрифт содержит корректную информацию о кернинге и кернинг включён в настройках PowerPoint.

Чтобы сделать вывод более похожим на PowerPoint, вы можете отключить кернинг для фрагментов текста, использующих затронутый шрифт. Установите [IBasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ibaseportionformat/#setKerningMinimalSize-float-) в значение, превышающее фактический размер шрифта. В этом примере требуется файл «presentation.pptx» с текстовым полем в качестве первой фигуры на первом слайде. Пример проверяет эффективные имена шрифтов, включая унаследованные, и устанавливает порог в 100 поинтов для фрагментов, использующих Roboto. Это отключит кернинг для соответствующих фрагментов с размером шрифта ниже 100 поинтов:

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

Для текста ниже порога данная настройка отключает кернинг и может помочь согласовать рендеринг Aspose.Slides с визуальным выводом PowerPoint для шрифтов, на которые влияет данное специфическое поведение PowerPoint.

## **Управление свойствами шрифта текста**

Свойства шрифта можно задавать на уровне абзаца через [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) или для отдельных фрагментов через [IPortionFormat](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iportionformat/).

Следующий пример задаёт для первого абзаца шрифт Times New Roman 12 пт с жирным, курсивом и пунктирным подчёркиванием по умолчанию. Явное форматирование отдельных фрагментов имеет приоритет над этими настройками по умолчанию:

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

Следующий пример применяет к фрагментам, у которых эффективное форматирование жирное, шрифт Times New Roman 13 пт, курсив и пунктирное подчёркивание:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
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

![Свойства шрифта фрагментов текста](font_properties_for_text_portions.png)

## **Установить вращение текста**

Используйте [ITextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/ru/java/com.aspose.slides/itextframeformat/#setTextVerticalType-byte-) для установки предопределённой ориентации текста внутри фигуры.

Следующий пример кода устанавливает ориентацию текста в фигуре на [TextVerticalType.Vertical270](https://reference.aspose.com/slides/ru/java/com.aspose.slides/textverticaltype/), что вращает текст **на 90 градусов против часовой стрелки**:

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

## **Установить пользовательское вращение текстовых кадров**

Используйте [ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/ru/java/com.aspose.slides/itextframeformat/#setRotationAngle-float-) для установки произвольного угла вращения для [ITextFrame](https://reference.aspose.com/slides/ru/java/com.aspose.slides/itextframe/).

Пример кода ниже вращает текстовый кадр на 3 градуса по часовой стрелке внутри фигуры:

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

Aspose.Slides предоставляет [IParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iparagraphformat/#setSpaceAfter-float-), [IParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iparagraphformat/#setSpaceBefore-float-) и [IParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iparagraphformat/#setSpaceWithin-float-) для управления интервалами абзацев. Эти свойства используются следующим образом:

* Положительное значение задаёт межстрочный интервал в процентах от высоты строки.
* Отрицательное значение задаёт межстрочный интервал в пунктах.

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

![Межстрочный интервал внутри абзаца](line_spacing.png)

## **Управление разрывом строк**

Правила разрыва строк в абзаце полезны в узких текстовых блоках и презентациях, где смешиваются латинский и восточноазиатский текст. Следующие методы принадлежат [IParagraphFormat](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iparagraphformat/), поэтому они применяются к целому абзацу:

- [setLatinLineBreak](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iparagraphformat/#setLatinLineBreak-byte-) управляет правилами разрыва строк для латиницы. В смешанном тексте изменение этого параметра также может изменить место переноса соседнего восточноазиатского текста и пунктуации.
- [setEastAsianLineBreak](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iparagraphformat/#setEastAsianLineBreak-byte-) управляет правилами разрыва строк для восточноазиатского текста, включая ограничения на символы в начале и конце строки.

Эти правила не заменяют [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/ru/java/com.aspose.slides/itextframeformat/#setWrapText-byte-), который включает автоматический перенос внутри текстового кадра. Они влияют на разметку, когда происходит перенос; они не вставляют символы разрыва строки. Явный разрыв строки заставляет начать новую строку в абзаце независимо от доступной ширины.

Следующий самостоятельный пример создаёт узкий текстовый блок, содержащий китайский и латинский текст. Он явно задаёт обе опции разрыва строк и сохраняет «line_breaking.pptx». Чтобы поэкспериментировать с любой из правил, измените соответствующее значение, оставив другое неизменным. В примере используется шрифт Arial 24 пт и SimSun, ширина кадра 160 пт и нулевые горизонтальные отступы текстового кадра. [ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/ru/java/com.aspose.slides/itextframeformat/#setAutofitType-byte-) вызывается с [TextAutofitType.None](https://reference.aspose.com/slides/ru/java/com.aspose.slides/textautofittype/), чтобы размер текста и размеры кадра оставались фиксированными:

```java
import com.aspose.slides.*;
import java.awt.Color;

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

## **Управление «висящей» пунктуацией**

[IParagraphFormat.setHangingPunctuation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iparagraphformat/#setHangingPunctuation-byte-) позволяет допускаемой пунктуации выходить за правый край строки вместо того, чтобы занимать следующую строку. Применяется ко всему абзацу и отличается от «висящего» отступа.

Следующий самостоятельный пример включает «висящую» пунктуацию в текстовом кадре шириной 100 пт и сохраняет «hanging_punctuation.pptx». При шрифте Arial 24 пт и нулевых горизонтальных отступах конечная точка остаётся после слова «sentence» и выходит за правый край текста. Установите свойство в [NullableBool.False](https://reference.aspose.com/slides/ru/java/com.aspose.slides/nullablebool/), чтобы сравнить: при этих настройках точка занимает отдельную строку. Перенос включён, автоподгонка отключена, чтобы ширина оставалась фиксированной.

```java
import com.aspose.slides.*;
import java.awt.Color;

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

Не каждый знаковый символ может «висеть». Видимый результат зависит от наличия шрифта и разметки: изменение шрифта, доступной ширины, отступов или настроек автоподгонки может убрать видимую разницу.

## **Установить тип автоподгонки для текстовых кадров**

[ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/ru/java/com.aspose.slides/itextframeformat/#setAutofitType-byte-) определяет, как текст ведёт себя, когда превышает границы своего контейнера. Используйте его, чтобы контролировать, будет ли текст сжиматься, выходить за пределы или автоматически изменять размер фигуры. Следующий пример настраивает фигуру так, чтобы она изменялась в размере под текст, и сохраняет результат в «autofit_type.pptx».

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

Чтобы подсчитать строки после автоматического переноса и увидеть, как изменение ширины текста или фигуры влияет на результат, см. [Count Rendered Lines](/slides/ru/java/manage-paragraph/). Само количество строк не указывает, выходит ли текст за пределы контейнера.

## **Установить привязку текстовых кадров**

[ITextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/ru/java/com.aspose.slides/itextframeformat/#setAnchoringType-byte-) определяет, как текст позиционируется вертикально внутри фигуры, например, вверху, по середине или внизу. Следующий пример привязывает текст к нижней части первой фигуры и сохраняет результат в «text_anchor.pptx».

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

Используйте [IParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iparagraphformat/#setDefaultTabSize-float-) и [IParagraphFormat.getTabs](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iparagraphformat/#getTabs--) для настройки табуляций в абзаце. Следующий пример задаёт интервал табуляции по умолчанию 100 пт и добавляет левый табулятор на 30 пт. Эти настройки влияют на текст, содержащий символы табуляции.

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

## **Установить язык проверки орфографии**

Aspose.Slides предоставляет [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-), позволяя задать язык проверки орфографии для фрагмента текста. Язык проверки определяет, какой язык будет использоваться для проверки правописания и грамматики в PowerPoint.

Следующий пример требует файл «presentation.pptx» с текстовым полем в качестве первой фигуры на первом слайде и как минимум одним абзацем. Он заменяет содержимое первого абзаца на «1。», устанавливает SimSun в качестве шрифта и задаёт язык проверки Simplified Chinese (`zh-CN`). Результат сохраняется в «proofing_language.pptx»:

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

Используйте [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/ru/java/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) для определения языка текста по умолчанию, создаваемого при загрузке или создании презентации. Следующий пример создаёт презентацию с английским (США) в качестве языка текста по умолчанию, добавляет текстовое поле и выводит `en-US` для его первого фрагмента текста.

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

    // Проверить язык первого фрагмента.
    IPortion portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    System.out.println(portion.getPortionFormat().getLanguageId());
} finally {
    presentation.dispose();
}
```

## **Установить стиль текста по умолчанию**

Чтобы применить форматирование текста по умолчанию на уровне презентации, используйте [IPresentation.getDefaultTextStyle](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ipresentation/#getDefaultTextStyle--).

Следующий пример задаёт 14‑пт жирный шрифт в качестве стиля по умолчанию для абзацев верхнего уровня в новой презентации и сохраняет её в «default_text_style.pptx». Текст может наследовать эти настройки, если более конкретное форматирование их не переопределяет.

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

## **Извлечение текста с эффектом «Все заглавные»**

В PowerPoint применение эффекта шрифта **All Caps** делает текст заглавным на слайде, даже если изначально он был введён строчными буквами. При получении такого фрагмента текста с помощью Aspose.Slides библиотека возвращает текст точно в том виде, в каком он был введён. Чтобы сопоставить отображаемый текст, проверьте [TextCapType](https://reference.aspose.com/slides/ru/java/com.aspose.slides/textcaptype/) и преобразуйте возвращённую строку в верхний регистр, если значение равно `All`.

Этот пример требует файл «sample2.pptx» с текстовым полем в качестве первой фигуры на первом слайде. Первый фрагмент первого абзаца содержит «Hello, Aspose!», к которому применён эффект All Caps, как показано ниже.

![Эффект All Caps](all_caps_effect.png)

Пример кода ниже показывает, как извлечь текст с применённым **All Caps** эффектом:

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

Чтобы изменить текст в таблице на слайде, используйте [ITable](https://reference.aspose.com/slides/ru/java/com.aspose.slides/itable/). Пройдитесь по ячейкам и обновите каждую ячейку через [ICell.getTextFrame](https://reference.aspose.com/slides/ru/java/com.aspose.slides/icell/#getTextFrame--) и форматирование абзаца через [IParagraph.getParagraphFormat](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iparagraph/#getParagraphFormat--).

**Как применить градиентный цвет к тексту в слайде PowerPoint?**

Чтобы применить градиентный цвет к тексту, используйте [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ibaseportionformat/#getFillFormat--). Установите [IFillFormat.setFillType](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ifillformat/#setFillType-byte-) в [FillType.Gradient](https://reference.aspose.com/slides/ru/java/com.aspose.slides/filltype/) и настройте градиентные стопы, направление и прозрачность.
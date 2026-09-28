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
- межсимвольный интервал
- свойства шрифта
- семейство шрифтов
- поворот текста
- угол поворота
- текстовый кадр
- межстрочный интервал
- свойство автоподгонки
- привязка текстового кадра
- табуляция текста
- язык по умолчанию
- PowerPoint
- OpenDocument
- презентация
- Android
- Java
- Aspose.Slides
description: "Форматирование и стилизация текста в презентациях PowerPoint и OpenDocument с использованием Aspose.Slides для Android через Java. Настройте шрифты, цвета, выравнивание и многое другое."
---
## **Обзор**

Эта статья показывает, как форматировать текст в презентациях PowerPoint и OpenDocument с помощью Aspose.Slides for Android через Java. Описываются цвета фона, прозрачность, межсимвольный интервал, свойства шрифта, вращение, интервалы между абзацами, поведение автоподгонки, привязка текста, табуляция и языковые настройки.

Если не указано иное, примеры используют [sample.pptx](sample.pptx). Первая форма на первом слайде — это текстовое поле, а его первый абзац содержит текст, показанный ниже. Индексы слайдов и форм начинаются с нуля. Примеры, выделяющие жирные части, используют эффективное форматирование, включая унаследованное жирное форматирование:

![Пример текста](sample_text.png)

Чтобы найти и выделить буквальный текст или совпадения по регулярному выражению, смотрите [Поиск и замена текста](/slides/ru/androidjava/search-and-replace-text/).

## **Установить цвет фона текста**

Используйте [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) чтобы задать цвет выделения по умолчанию для абзаца, или [IBasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ibaseportionformat/#getHighlightColor--) для отдельных текстовых частей.

В следующем примере задаётся светло‑серый цвет выделения как значение по умолчанию для первого абзаца. Явные цвета выделения у отдельных частей имеют приоритет над этим значением по умолчанию:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Установить цвет выделения для всего абзаца.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getHighlightColor().setColor(Color.LTGRAY);

    presentation.save("gray_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Результат:

![Серый абзац](gray_paragraph.png)

Ниже пример кода, демонстрирующий, как установить цвет фона **текстовых частей с жирным шрифтом**:

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
            // Установить цвет выделения для текстовой части.
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

## **Выравнивание абзацев текста**

Используйте [IParagraphFormat.setAlignment](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) чтобы задать выравнивание абзаца внутри текстового кадра. Значение может быть по центру, по левому краю, по правому краю, с выравниванием по ширине и т.д.

В следующем примере показано, как выровнять абзац **по центру**:

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

Прозрачность текста управляется альфа‑компонентой цвета, назначенного [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ibaseportionformat/#getFillFormat--). В примерах ниже `alpha = 50` — это значение альфа‑канала ARGB в диапазоне 0–255, а не процент прозрачности.

Ниже пример кода, демонстрирующий, как применить прозрачность к **всему абзацу**:

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

## **Установить межсимвольный интервал текста**

Используйте [IBasePortionFormat.setSpacing](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ibaseportionformat/#setSpacing-float-) чтобы увеличить или уменьшить интервал между символами в текстовом поле. В примерах добавляется 3 пункта интервала; отрицательные значения сжимают текст.

Ниже показан Java‑код, который расширяет межсимвольный интервал в **весь абзац**:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Примечание: используйте отрицательные значения, чтобы сжать межсимвольный интервал.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3); // Расширить межсимвольный интервал.

    presentation.save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Результат:

![Межсимвольный интервал в абзаце](character_spacing_in_paragraph.png)

Ниже пример кода, который расширяет межсимвольный интервал в **текстовых частях с жирным шрифтом**:

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
            portion.getPortionFormat().setSpacing(3); // Расширить межсимвольный интервал.
        }
    }

    presentation.save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Результат:

![Межсимвольный интервал в текстовых частях](character_spacing_in_text_portions.png)

### **Отключить кернинг для конкретных шрифтов**

В некоторых случаях текст, отрисованный Aspose.Slides, может выглядеть немного плотнее, чем тот же текст в PowerPoint. Это может происходить, потому что PowerPoint игнорирует данные кернинга для некоторых шрифтов, даже если шрифт содержит корректную информацию о кернинге и кернинг включён в параметрах PowerPoint.

Чтобы сделать вывод более похожим на PowerPoint, можно отключить кернинг для текстовых частей, использующих затронутый шрифт. Установите [IBasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ibaseportionformat/#setKerningMinimalSize-float-) в значение, превышающее фактический размер шрифта. Этот пример требует файла "presentation.pptx" с текстовым полем в первой форме первого слайда. Он проверяет эффективные имена шрифтов, включая унаследованные, и задаёт порог в 100 пунктов для частей, использующих Roboto. Это отключает кернинг для соответствующих частей с размером шрифта ниже 100 пунктов:

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

Для текста, попадающего под порог, данная настройка предотвращает кернинг и может помочь согласовать рендеринг Aspose.Slides с визуальным выводом PowerPoint для шрифтов, затронутых этим специфическим поведением PowerPoint.

## **Управление свойствами шрифта текста**

Свойства шрифта можно задавать на уровне абзаца через [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) или для отдельных частей через [IPortionFormat](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iportionformat/).

В следующем примере задаётся шрифт первого абзаца по умолчанию: Times New Roman 12 пунктов, жирный, курсив и пунктирное подчеркивание. Явное форматирование отдельных частей имеет приоритет над этими значениями по умолчанию:

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

В следующем примере применяется Times New Roman 13 пунктов, курсив и пунктирное подчеркивание к частям, у которых эффективное форматирование включает жирный шрифт:

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

## **Установить поворот текста**

Используйте [ITextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/itextframeformat/#setTextVerticalType-byte-) чтобы задать предопределённую ориентацию текста внутри формы.

В следующем примере код задаёт ориентацию текста в форме [TextVerticalType.Vertical270](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/textverticaltype/), которая вращает текст **на 90 градусов против часовой стрелки**:

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

![Поворот текста](text_rotation.png)

## **Установить пользовательский поворот для текстовых кадров**

Используйте [ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/itextframeformat/#setRotationAngle-float-) чтобы задать произвольный угол поворота для [ITextFrame](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/itextframe/).

Ниже пример кода, который вращает текстовый кадр на 3 градуса по часовой стрелке внутри формы:

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

![Пользовательский поворот текста](custom_text_rotation.png)

## **Установить межстрочный интервал абзацев**

Aspose.Slides предоставляет [IParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iparagraphformat/#setSpaceAfter-float-), [IParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iparagraphformat/#setSpaceBefore-float-) и [IParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iparagraphformat/#setSpaceWithin-float-) для управления интервалами абзацев. Эти свойства используются следующим образом:

* Положительное значение задаёт межстрочный интервал в процентах от высоты строки.
* Отрицательное значение задаёт межстрочный интервал в пунктах.

В следующем примере задаётся интервал внутри первого абзаца равный 200 % от высоты строки (двойной интервал):

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

Правила разрыва строк в абзацах полезны при работе с узкими текстовыми блоками и презентациями, содержащими одновременно латинский и восточно‑азиатский текст. Ниже приведённые методы относятся к [IParagraphFormat](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iparagraphformat/), поэтому они применяются ко всему абзацу:

- [setLatinLineBreak](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iparagraphformat/#setLatinLineBreak-byte-) управляет правилами разрыва латинского текста. В смешанном тексте изменение этого параметра может также изменить место переноса прилегающего восточно‑азиатского текста и знаков препинания.
- [setEastAsianLineBreak](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iparagraphformat/#setEastAsianLineBreak-byte-) управляет правилами разрыва восточно‑азиатского текста, включая ограничения на символы в начале и конце строки.

Эти правила не заменяют [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/itextframeformat/#setWrapText-byte-), который включает автоматический перенос внутри текстового кадра. Они влияют на компоновку при наличии переноса; они не вставляют символы разрыва строки. Явный разрыв строки заставляет начать новую строку в абзаце независимо от доступной ширины.

Ниже автономный пример, создающий узкий текстовый блок, содержащий китайский и латинский текст. Он явно задаёт обе опции разрыва строк и сохраняет файл "line_breaking.pptx". Чтобы поэкспериментировать с тем или иным правилом, измените соответствующее значение, оставив другое без изменений. В примере используется Arial 24 пункта и SimSun, ширина кадра 160 пунктов и нулевые горизонтальные отступы текстового кадра. [ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/itextframeformat/#setAutofitType-byte-) вызывается с [TextAutofitType.None](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/textautofittype/), чтобы размер текста и размеры кадра оставались фиксированными:

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

## **Управление висячей пунктуацией**

[IParagraphFormat.setHangingPunctuation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iparagraphformat/#setHangingPunctuation-byte-) позволяет разрешённой пунктуации выходить за правый край строки вместо размещения её на следующей строке. Применяется ко всему абзацу и отличается от висячего отступа.

Ниже автономный пример, включающий висячую пунктуацию в текстовом кадре шириной 100 пунктов и сохраняющий файл "hanging_punctuation.pptx". При Arial 24 пункта и нулевых горизонтальных отступах конечная точка остаётся после слова "sentence" и выходит за правый край текста. Установите свойство в значение [NullableBool.False](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/nullablebool/) для сравнения: при этих настройках точка занимает отдельную строку. Перенос включён, автоподгонка отключена, чтобы фиксировать доступную ширину.

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

Не каждый знак пунктуации может "висеть". Видимый результат зависит от наличия шрифта и разметки: изменение шрифта, доступной ширины, отступов или параметров автоподгонки может убрать визуальную разницу.

## **Установить тип автоподгонки для текстовых кадров**

[ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/itextframeformat/#setAutofitType-byte-) определяет, как текст ведёт себя, когда превышает границы своего контейнера. Используйте его, чтобы контролировать, будет ли текст уменьшаться, выходить за пределы или автоматически изменять размер формы. В следующем примере задаётся масштабирование формы так, чтобы она подстраивалась под текст, и сохраняется результат в файл "autofit_type.pptx".

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

Чтобы подсчитать строки после автоматического переноса и увидеть, как меняются текст или ширина формы, смотрите [Count Rendered Lines](/slides/ru/androidjava/manage-paragraph/). Само количество строк не указывает, выходит ли текст за пределы контейнера.

## **Установить привязку текстовых кадров**

[ITextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/itextframeformat/#setAnchoringType-byte-) определяет, как текст позиционируется по вертикали внутри формы, например, вверху, посередине или внизу. В следующем примере текст привязывается к нижней части первой формы и сохраняется в файл "text_anchor.pptx".

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

Используйте [IParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iparagraphformat/#setDefaultTabSize-float-) и [IParagraphFormat.getTabs](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iparagraphformat/#getTabs--) для настройки табуляций в абзаце. В следующем примере задаётся интервал табуляции по умолчанию 100 пунктов и добавляется табуляция, выровненная по левому краю, на позиции 30 пунктов. Эти настройки влияют на текст, содержащий символы табуляции.

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

Aspose.Slides предоставляет [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-), позволяющий задать язык проверки правописания для текстовой части. Язык проверки определяет, какой язык будет использоваться для проверки орфографии и грамматики в PowerPoint.

В следующем примере требуется файл "presentation.pptx" с текстовым полем в первой форме первого слайда и как минимум одним абзацем. Он заменяет содержимое первого абзаца на "1。", задаёт SimSun в качестве шрифта и устанавливает язык проверки Simplified Chinese (`zh-CN`). Результат сохраняется в файл "proofing_language.pptx":

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

    // Установить Id проверочного языка.
    textPortion.getPortionFormat().setLanguageId("zh-CN");

    textPortion.setText("1。");
    paragraph.getPortions().add(textPortion);

    presentation.save("proofing_language.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Установить язык по умолчанию**

Используйте [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) чтобы задать язык по умолчанию для текста, создаваемого при загрузке или создании презентации. В следующем примере создаётся презентация с американским английским в качестве языка текста по умолчанию, добавляется текстовое поле и выводится `en-US` для первой текстовой части.

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

    // Проверить язык первой части.
    IPortion portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    System.out.println(portion.getPortionFormat().getLanguageId());
} finally {
    presentation.dispose();
}
```

## **Установить стиль текста по умолчанию**

Чтобы применить форматирование текста по умолчанию на уровне презентации, используйте [IPresentation.getDefaultTextStyle](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ipresentation/#getDefaultTextStyle--).

В следующем примере задаётся шрифт 14 пунктов, жирный, как стиль по умолчанию для абзацев верхнего уровня в новой презентации, и сохраняется в файл "default_text_style.pptx". Текст может наследовать эти значения, если не переопределён более специфичным форматированием.

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

## **Извлекать текст с эффектом прописных букв**

В PowerPoint применение эффекта **All Caps** (все заглавные) делает текст заглавным на слайде, даже если он был набран строчными буквами. При получении такой текстовой части с помощью Aspose.Slides библиотека возвращает текст точно в том виде, в каком он был введён. Чтобы отразить отображаемый текст, проверьте [TextCapType](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/textcaptype/) и при значении `All` преобразуйте возвращённую строку в верхний регистр.

Этот пример требует файл "sample2.pptx" с текстовым полем в первой форме первого слайда. Первая часть первого абзаца содержит "Hello, Aspose!" с применённым эффектом All Caps, как показано ниже.

![Эффект All Caps](all_caps_effect.png)

Ниже пример кода, показывающий, как извлечь текст с применённым эффектом **All Caps**:

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

Чтобы изменить текст в таблице на слайде, используйте [ITable](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/itable/). Пройдитесь по ячейкам и обновите каждую ячейку через [ICell.getTextFrame](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/icell/#getTextFrame--) и форматирование абзацев через [IParagraph.getParagraphFormat](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iparagraph/#getParagraphFormat--).

**Как применить градиентный цвет к тексту на слайде PowerPoint?**

Для применения градиентного цвета к тексту используйте [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ibaseportionformat/#getFillFormat--). Установите [IFillFormat.setFillType](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ifillformat/#setFillType-byte-) в значение [FillType.Gradient](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/filltype/) и настройте градиентные остановки, направление и прозрачность.
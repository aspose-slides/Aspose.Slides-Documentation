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
- поворот текста
- угол поворота
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
description: "Форматировать и оформлять текст в презентациях PowerPoint и OpenDocument с помощью Aspose.Slides для Java. Настройте шрифты, цвета, выравнивание и многое другое."
---
## **Обзор**

Эта статья показывает, как форматировать текст в презентациях PowerPoint и OpenDocument с использованием Aspose.Slides for Java. Она охватывает цвета фона, прозрачность, межсимвольный интервал, свойства шрифтов, поворот, интервал между абзацами, поведение автоподгонки, привязку текста, табуляцию и параметры языка.

Если не указано иное, примеры используют [sample.pptx](sample.pptx). Первая фигура на первом слайде представляет собой текстовое поле, и первый абзац содержит показанный ниже текст. И индексы слайдов, и индексы фигур начинаются с нуля. Примеры, выбирающие жирные части, используют эффективное форматирование, включая унаследованное жирное форматирование:

![Пример текста](sample_text.png)

Чтобы найти и выделить буквальный текст или совпадения регулярных выражений, см. [Поиск и замена текста](/slides/ru/java/search-and-replace-text/).

## **Установка цвета фона текста**

Используйте [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) чтобы задать цвет выделения по умолчанию для абзаца, или используйте [IBasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#getHighlightColor--) для отдельных текстовых частей.

Следующий пример задаёт светло-серый цвет выделения по умолчанию для первого абзаца. Явные цвета выделения в отдельных частях имеют приоритет над этим значением по умолчанию:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Установить цвет выделения для всего абзаца.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getHighlightColor().setColor(Color.LIGHT_GRAY);

    presentation.save("gray_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Результат:

![Серый абзац](gray_paragraph.png)

Ниже пример кода, демонстрирующий, как задать цвет фона для **текстовых частей с жирным шрифтом**:

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
            // Установить цвет выделения для текстовой части.
            portion.getPortionFormat().getHighlightColor().setColor(Color.LIGHT_GRAY);
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

Используйте [IParagraphFormat.setAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) чтобы задать выравнивание абзаца внутри текстовой рамки. Значение может быть центрировано, выровнено по левому краю, правому краю, по ширине и т.д.

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

![Выравненный абзац](aligned_paragraph.png)

## **Выравнивание шрифтов внутри строки**

Используйте [IParagraphFormat.setFontAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setFontAlignment-int-) чтобы вертикально выровнять текстовые части разных размеров шрифта в одной строке. Эта настройка применяется ко всему абзацу и управляет выравниванием внутри каждой его строки.

Следующий самостоятельный пример создаёт четыре помеченных текстовых поля на одном слайде. Каждый абзац содержит один и тот же текст размером 18, 36 и 54 пункта с разным выравниванием шрифта. Он использует Arial, отключает автоподгонку и перенос, и делает текстовые рамки достаточно большими для одной строки.

```java
import com.aspose.slides.*;
import java.awt.Color;

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

![Сравнение выравнивания шрифтов по базовой линии, верху, центру и низу при смешанных размерах шрифтов](font_alignment.png)

Выравнивание шрифтов использует метрики шрифта, поэтому видимые границы отдельных букв не всегда точно совпадают. В примере присутствуют как заглавная буква, так и нижняя часть символа, чтобы показать разницу между выравниванием по базовой линии и по низу. Доступность шрифтов и их подстановка, используемые символы и разница в размерах шрифтов влияют на результат. Размеры рамки, отступы, межстрочный интервал, перенос и автоподгонка также влияют на раскладку; при сравнении режимов используйте одинаковые шрифты и параметры макета.

Эта настройка отличается от [IParagraphFormat.setAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setAlignment-int-), который управляет горизонтальным выравниванием абзаца, и от [ITextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setAnchoringType-byte-), который позиционирует текстовый блок вертикально внутри своей формы. Форматирование надстрочного и нижстрочного индекса через [IBasePortionFormat.setEscapement](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setEscapement-float-) сдвигает отдельные части относительно базовой линии вместо установки выравнивания шрифта для строк абзаца.

## **Установка прозрачности текста**

Прозрачность текста управляется альфа‑компонентой цвета, назначенного [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#getFillFormat--). В примерах ниже `alpha = 50` — это значение альфа‑канала ARGB в диапазоне 0–255, а не процент прозрачности.

Следующий пример показывает, как применить прозрачность к **всему абзацу**:

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

Следующий пример показывает, как применить прозрачность к **текстовым частям с жирным шрифтом**:

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
            // Установить прозрачность текстовой части.
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

![Прозрачные текстовые части](transparent_text_portions.png)

## **Установка межсимвольного интервала текста**

Используйте [IBasePortionFormat.setSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setSpacing-float-) чтобы увеличить или уменьшить интервал между символами в текстовом поле. В примерах добавляется интервал в 3 пункта; отрицательные значения сжимают текст.

Следующий Java‑код показывает, как расширить межсимвольный интервал в **всём абзаце**:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Примечание: используйте отрицательные значения, чтобы сжать расстояние между символами.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3); // Увеличить межсимвольный интервал.

    presentation.save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Результат:

![Межсимвольный интервал в абзаце](character_spacing_in_paragraph.png)

Ниже пример кода, демонстрирующий, как расширить межсимвольный интервал в **текстовых частях с жирным шрифтом**:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // Примечание: используйте отрицательные значения, чтобы сжать расстояние между символами.
            portion.getPortionFormat().setSpacing(3); // Увеличить межсимвольный интервал.
        }
    }

    presentation.save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Результат:

![Межсимвольный интервал в текстовых частях](character_spacing_in_text_portions.png)

### **Отключение кёрнинга для определённых шрифтов**

В некоторых случаях текст, отрисованный Aspose.Slides, выглядит чуть более сжатым, чем тот же текст в PowerPoint. Это может происходить, потому что PowerPoint иногда игнорирует данные кёрнинга для определённых шрифтов, даже если шрифт содержит корректную информацию о кёрнинге и кёрнинг включён в настройках PowerPoint.

Чтобы сделать вывод более похожим на PowerPoint, можно отключить кёрнинг для текстовых частей, использующих проблемный шрифт. Установите [IBasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setKerningMinimalSize-float-) в значение, превышающее фактический размер шрифта. Этот пример требует файл «presentation.pptx» с текстовым полем как первой фигурой на первом слайде. Он проверяет эффективные имена шрифтов, включая унаследованные, и задаёт порог в 100 пунктов для частей, использующих Roboto. Это отключает кёрнинг для соответствующих частей, размер шрифта которых ниже 100 пунктов:

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

Для текста, попадающего под порог, эта настройка предотвращает кёрнинг и может помочь согласовать вывод Aspose.Slides с визуальным отображением PowerPoint для шрифтов, затронутых этим специфическим поведением PowerPoint.

## **Управление свойствами шрифта текста**

Свойства шрифта можно задать на уровне абзаца через [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) или для отдельных частей через [IPortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iportionformat/).

Следующий пример задаёт для первого абзаца шрифт Times New Roman 12 пунктов с жирным, курсивным и пунктирным подчёркиванием. Явное форматирование отдельных частей имеет приоритет над этими значениями по умолчанию:

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

Следующий пример применяет Times New Roman 13 пунктов, курсив и пунктирное подчеркивание к частям, у которых эффективное форматирование — жирное:

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

## **Установка поворота текста**

Используйте [ITextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setTextVerticalType-byte-), чтобы задать предопределённую ориентацию текста внутри формы.

Следующий пример кода задаёт ориентацию текста в форме [TextVerticalType.Vertical270](https://reference.aspose.com/slides/java/com.aspose.slides/textverticaltype/), что вращает текст **на 90 градусов против часовой стрелки**:

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

## **Установка пользовательского поворота для текстовых рамок**

Используйте [ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setRotationAngle-float-), чтобы задать собственный угол поворота для [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/).

Следующий пример кода вращает текстовую рамку **на 3 градуса по часовой стрелке** внутри формы:

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

## **Установка интервала строк в абзацах**

Aspose.Slides предоставляет [IParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setSpaceAfter-float-), [IParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setSpaceBefore-float-) и [IParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setSpaceWithin-float-) для управления интервалом абзацев. Эти свойства используются так:

* Используйте положительное значение, чтобы задать межстрочный интервал в процентах от высоты строки.
* Используйте отрицательное значение, чтобы задать межстрочный интервал в пунктах.

Следующий пример задаёт интервал внутри первого абзаца в 200 % от высоты строки (двойной интервал):

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

## **Управление переносом строк**

Правила переноса строк абзаца полезны в узких текстовых блоках и презентациях, где смешаны латинский и восточноазиатский тексты. Следующие методы принадлежат [IParagraphFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/), поэтому они применяются ко всему абзацу:

- [setLatinLineBreak](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setLatinLineBreak-byte-) управляет правилами переноса для латинского текста. В смешанном тексте изменение этого параметра может также изменить места переноса соседнего восточноазиатского текста и знаков препинания.
- [setEastAsianLineBreak](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setEastAsianLineBreak-byte-) управляет правилами переноса для восточноазиатского текста, включая ограничения на символы в начале и в конце строки.

Эти правила не заменяют [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setWrapText-byte-), который включает автоматический перенос внутри текстовой рамки. Они влияют на макет при переносе, но не вставляют символы переноса. Явный перенос принудительно создаёт новую строку в абзаце независимо от доступной ширины.

Следующий самостоятельный пример создаёт узкий текстовый блок, содержащий китайский и латинский текст. Он явно задаёт оба параметра переноса и сохраняет файл «line_breaking.pptx». Чтобы поэкспериментировать с любым из правил, измените соответствующее значение, оставив другое фиксированным. В примере используется Arial 24 пункта и SimSun, ширина рамки 160 пунктов и нулевые горизонтальные отступы рамки. [ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setAutofitType-byte-) вызывается с [TextAutofitType.None](https://reference.aspose.com/slides/java/com.aspose.slides/textautofittype/), чтобы размеры текста и рамки оставались фиксированными.

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

## **Управление висячей пунктуацией**

[IParagraphFormat.setHangingPunctuation](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setHangingPunctuation-byte-) позволяет допускаемой пунктуации выступать за правый край строки вместо того, чтобы занимать следующую строку. Это применяется ко всему абзацу и отличается от висячего отступа.

Следующий самостоятельный пример включает висячую пунктуацию в 100‑пунктовой широкой текстовой рамке и сохраняет файл «hanging_punctuation.pptx». При Arial 24 пункта и нулевых горизонтальных отступах последний точка остаётся после слова «sentence» и выходит за правый край текста. Чтобы сравнить, установите свойство в [NullableBool.False](https://reference.aspose.com/slides/java/com.aspose.slides/nullablebool/). При этих настройках точка будет находиться на отдельной строке. Перенос включён, автоподгонка отключена, чтобы фиксировать доступную ширину.

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

Не каждый знак пунктуации может «висеть». Условия [шрифта и разметки, описанные выше](#control-line-breaking) также применимы к этому сравнению: изменение шрифта, доступной ширины, отступов или настроек автоподгонки может убрать видимую разницу.

## **Установка типа автоподгонки для текстовых рамок**

[ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setAutofitType-byte-) определяет, как текст ведёт себя, когда превышает границы своего контейнера. Используйте его, чтобы контролировать, будет ли текст сжиматься, выходить за границы или автоматически менять размер формы. Следующий пример настраивает форму так, чтобы она изменялась под размер текста, и сохраняет результат в файл «autofit_type.pptx».

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

Чтобы подсчитать строки после автоматического переноса и увидеть, как меняется результат при изменении ширины текста или формы, см. [Подсчёт отображённых строк](/slides/ru/java/manage-paragraph/). Само количество строк не указывает, выходит ли текст за пределы контейнера.

## **Установка привязки текстовых рамок**

[ITextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setAnchoringType-byte-) определяет, как текст позиционируется вертикально внутри формы, например, вверху, по середине или внизу. Следующий пример привязывает текст к нижней части первой формы и сохраняет результат в файл «text_anchor.pptx».

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

Используйте [IParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setDefaultTabSize-float-) и [IParagraphFormat.getTabs](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#getTabs--) для настройки табуляций в абзаце. Следующий пример задаёт интервал табуляции по умолчанию 100 пунктов и добавляет табуляцию, выровненную по левому краю, на позиции 30 пунктов. Эти настройки влияют на текст, содержащий символы табуляции.

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

## **Установка языка проверки правописания**

Aspose.Slides предоставляет [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-), который позволяет задать язык проверки правописания для текстовой части. Язык проверки определяет, какой язык используется для проверки орфографии и грамматики в PowerPoint.

Следующий пример требует файл «presentation.pptx» с текстовым полем как первой фигурой на первом слайде и хотя бы одним абзацем. Он заменяет содержимое первого абзаца на «1。», задаёт SimSun в качестве шрифта и присваивает упрощённый китайский язык проверки правописания (`zh-CN`). Затем сохраняет результат в файл «proofing_language.pptx»:

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

    // Установить Id языка проверки правописания.
    textPortion.getPortionFormat().setLanguageId("zh-CN");

    textPortion.setText("1。");
    paragraph.getPortions().add(textPortion);

    presentation.save("proofing_language.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Установка языка по умолчанию**

Используйте [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) для определения языка по умолчанию для текста, создаваемого при загрузке или создании презентации. Следующий пример создаёт презентацию с американским английским в качестве языка текста по умолчанию, добавляет текстовое поле и выводит `en-US` для первой текстовой части.

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

    // Проверить язык первой части.
    IPortion portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    System.out.println(portion.getPortionFormat().getLanguageId());
} finally {
    presentation.dispose();
}
```

## **Установка стиля текста по умолчанию**

Для применения формата текста по умолчанию на уровне презентации используйте [IPresentation.getDefaultTextStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentation/#getDefaultTextStyle--).

Следующий пример задаёт шрифт 14 пунктов, жирный, в качестве стиля по умолчанию для абзацев верхнего уровня в новой презентации и сохраняет её в файл «default_text_style.pptx». Текст может наследовать эти значения, если более конкретное форматирование их не переопределит.

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

## **Извлечение текста с эффектом всех заглавных букв**

В PowerPoint применение эффекта **All Caps** делает текст отображаемым заглавными буквами, даже если он был введён строчными. При получении такой текстовой части через Aspose.Slides библиотека возвращает текст точно в том виде, в каком он был введён. Чтобы получить то, что видно, проверьте [TextCapType](https://reference.aspose.com/slides/java/com.aspose.slides/textcaptype/) и преобразуйте возвращённую строку в верхний регистр, когда значение равно `All`.

Этот пример требует файл «sample2.pptx» с текстовым полем как первой фигурой на первом слайде. В первом абзаце первой части содержится «Hello, Aspose!», к которому применён эффект All Caps, как показано ниже.

![Эффект всех заглавных букв](all_caps_effect.png)

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

## **Часто задаваемые вопросы**

**Как изменить текст в таблице на слайде?**

Для изменения текста в таблице на слайде используйте [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/itable/). Пройдите по ячейкам и обновите каждую ячейку через [ICell.getTextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getTextFrame--) и форматирование абзаца через [IParagraph.getParagraphFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getParagraphFormat--).

**Как применить градиентный цвет к тексту на слайде PowerPoint?**

Чтобы применить градиентный цвет к тексту, используйте [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#getFillFormat--). Установите [IFillFormat.setFillType](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#setFillType-byte-) в значение [FillType.Gradient](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) и настройте градиентные стопы, направление и прозрачность.
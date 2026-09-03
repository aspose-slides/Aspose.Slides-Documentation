---
title: Управление текстовыми полями в презентациях с использованием Java
linktitle: Управление текстовым полем
type: docs
weight: 20
url: /ru/java/manage-textbox/
keywords:
- текстовое поле
- текстовый кадр
- добавить текст
- обновить текст
- создать текстовое поле
- проверить текстовое поле
- добавить колонку текста
- добавить гиперссылку
- PowerPoint
- презентация
- Java
- Aspose.Slides
description: "Создавайте, определяйте, форматируйте и обновляйте текстовые поля в презентациях PowerPoint и OpenDocument с использованием Aspose.Slides для Java."
---
## **Введение**

В Aspose.Slides for Java текст слайдов хранится в текстовых кадрах, которые принадлежат фигурам. Интерфейс [IAutoShape](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iautoshape/) представляет наиболее распространённую форму, содержащую текст, и предоставляет её текст через метод [IAutoShape.getTextFrame](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iautoshape/#getTextFrame--).

{{% alert color="info" title="Note" %}}
Каждая автофигура реализует [IShape](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ishape/), но не каждая фигура является автофигурой или поддерживает текстовый кадр. При обработке существующей презентации проверяйте, что фигура реализует [IAutoShape](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iautoshape/) перед тем как получить доступ к её тексту.
{{% /alert %}}

## **Создание текстового поля на слайде**

Чтобы создать текстовое поле, добавьте автофигуру на слайд, добавьте текст в её текстовый кадр и сохраните презентацию. Ниже приведён пример, создающий прямоугольное текстовое поле:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape textBox = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 300, 50);
    textBox.addTextFrame("Aspose TextBox");

    presentation.save("TextBox.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Координаты и размеры, передаваемые в [IShapeCollection.addAutoShape](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ishapecollection/#addAutoShape-int-float-float-float-float-) измеряются в пунктах. [IAutoShape.addTextFrame](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) инициализирует текстовый кадр переданным текстом.

## **Проверка формы текстового поля**

Используйте метод [IAutoShape.isTextBox](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iautoshape/#isTextBox--) чтобы определить, считается ли автофигура текстовым полем. Это полезно, когда презентация содержит как автофигуры с текстом, так и исключительно графические автофигуры.

![Текстовое поле и фигура](istextbox.png)

В следующем примере проверяется каждая автофигура в презентации:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape textBox = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 120, 40);
    textBox.addTextFrame("Text box");
    slide.getShapes().addAutoShape(ShapeType.Ellipse, 150, 10, 40, 40);

    for (ISlide currentSlide : presentation.getSlides()) {
        for (IShape shape : currentSlide.getShapes()) {
            if (shape instanceof IAutoShape) {
                IAutoShape autoShape = (IAutoShape) shape;
                System.out.println(autoShape.isTextBox() ? "The shape is a text box." : "The shape is not a text box.");
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Новая добавленная автофигура не считается текстовым полем, пока не содержит непустой текст. Вы можете задать этот текст через [IAutoShape.addTextFrame](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) или [ITextFrame.setText](https://reference.aspose.com/slides/ru/java/com.aspose.slides/itextframe/#setText-java.lang.String-). Добавление или присвоение пустой строки приводит к тому, что [IAutoShape.isTextBox](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iautoshape/#isTextBox--) возвращает `false`:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 40);
    shape1.addTextFrame("Shape 1");
    System.out.println(shape1.isTextBox());

    IAutoShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 70, 100, 40);
    shape2.getTextFrame().setText("Shape 2");
    System.out.println(shape2.isTextBox());

    IAutoShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 130, 100, 40);
    shape3.addTextFrame("");
    System.out.println(shape3.isTextBox());

    IAutoShape shape4 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 190, 100, 40);
    shape4.getTextFrame().setText("");
    System.out.println(shape4.isTextBox());
} finally {
    presentation.dispose();
}
```

Первые два вызова выводят `true`; последние два — `false`.

## **Найти форму, владеющую текстовым кадром**

Общий код обработки текста может получать объект [ITextFrame](https://reference.aspose.com/slides/ru/java/com.aspose.slides/itextframe/) без знания, какой объект презентации его содержит. Используйте только для чтения метод [ITextFrame.getParentShape](https://reference.aspose.com/slides/ru/java/com.aspose.slides/itextframe/#getParentShape--) чтобы вернуться к его владельцу — [IShape](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ishape/).

Для текстового кадра, принадлежащего автофигуре или другой фигуре с текстом, [ITextFrame.getParentShape](https://reference.aspose.com/slides/ru/java/com.aspose.slides/itextframe/#getParentShape--) возвращает владельца, а [ITextFrame.getParentCell](https://reference.aspose.com/slides/ru/java/com.aspose.slides/itextframe/#getParentCell--) возвращает `null`. Проверьте возвращаемое значение перед доступом к нему. Чтобы определить как владельцев фигур, так и ячеек таблиц, включая фигуры, связанные с узлами SmartArt, см. [Поиск и замена текста](/slides/ru/java/search-and-replace-text/).

## **Добавление колонок в текстовое поле**

Метод [ITextFrameFormat.setColumnCount](https://reference.aspose.com/slides/ru/java/com.aspose.slides/itextframeformat/#setColumnCount-int-) делит текстовый кадр на колонки, а [ITextFrameFormat.setColumnSpacing](https://reference.aspose.com/slides/ru/java/com.aspose.slides/itextframeformat/#setColumnSpacing-double-) задаёт расстояние между колонками в пунктах. Оба параметра относятся к [ITextFrameFormat](https://reference.aspose.com/slides/ru/java/com.aspose.slides/itextframeformat/) и могут быть изменены через текстовый кадр существующего текстового поля. Текст перераспределяется между колонками внутри одной фигуры; он не продолжается в другую фигуру.

В следующем примере создаётся трёхколоночное текстовое поле с интервалом 10 пунктов между колонками, сохраняется презентация и читаются сохранённые настройки из выходного файла:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape textBox = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 200);
    textBox.addTextFrame("This text is distributed automatically across all columns in the text box.");

    ITextFrameFormat textFrameFormat = textBox.getTextFrame().getTextFrameFormat();
    textFrameFormat.setColumnCount(3);
    textFrameFormat.setColumnSpacing(10);

    presentation.save("TextBoxColumns.pptx", SaveFormat.Pptx);

    Presentation savedPresentation = new Presentation("TextBoxColumns.pptx");
    try {
        IAutoShape savedTextBox = (IAutoShape) savedPresentation.getSlides().get_Item(0).getShapes().get_Item(0);
        ITextFrameFormat savedFormat = savedTextBox.getTextFrame().getTextFrameFormat();
        System.out.println("Columns: " + savedFormat.getColumnCount() + "; spacing: " + savedFormat.getColumnSpacing() + " points");
    } finally {
        savedPresentation.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **Извлечение текста из отдельных колонок**

Используйте [ITextFrame.splitTextByColumns](https://reference.aspose.com/slides/ru/java/com.aspose.slides/itextframe/#splitTextByColumns--) чтобы получить текст, присвоенный каждой визуальной колонке в существующем текстовом кадре. Метод возвращает одну строку для каждой колонки в порядке чтения по колонкам. Текстовый кадр с одной колонкой возвращает массив из одного элемента, а пустая колонка представлена пустой строкой. Строки содержат только обычный текст; форматирование на уровне частей не сохраняется.

Это полезно, когда необходимо:
- Извлечь текст, сохранив порядок чтения по колонкам.
- Индексировать или сравнивать содержимое слайдов с несколькими колонками.
- Экспортировать каждую колонку в отдельный файл, поле базы данных или другое место назначения.
- Проверить, как текст перераспределяется после изменения количества колонок с помощью [ITextFrameFormat.setColumnCount](https://reference.aspose.com/slides/ru/java/com.aspose.slides/itextframeformat/#setColumnCount-int-), интервала с помощью [ITextFrameFormat.setColumnSpacing](https://reference.aspose.com/slides/ru/java/com.aspose.slides/itextframeformat/#setColumnSpacing-double-), шрифта или размера текстового кадра.

Метод сообщает о тексте, распределённом внутри текущего [ITextFrame](https://reference.aspose.com/slides/ru/java/com.aspose.slides/itextframe/); он не автоматически перемещает текст между отдельными фигурами или текстовыми полями. Распределение колонок может зависеть от доступных шрифтов и других настроек макета текста, поэтому убедитесь, что необходимые шрифты доступны, когда важна согласованность результатов.

В следующем примере загружается презентация, находится первая автофигура с несколькими колонками и текстовым кадром, читается её настроенное количество колонок, и текст из каждой колонки записывается в отдельный файл. Фигуры, не предоставляющие текстовый кадр, пропускаются.

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Presentation presentation = new Presentation("MultiColumnText.pptx");
try {
    IAutoShape textBox = null;
    for (IShape shape : presentation.getSlides().get_Item(0).getShapes()) {
        if (shape instanceof IAutoShape) {
            IAutoShape autoShape = (IAutoShape) shape;
            if (autoShape.getTextFrame() != null) {
                int columnCount = autoShape.getTextFrame().getTextFrameFormat().getColumnCount();
                if (columnCount > 1) {
                    textBox = autoShape;
                    break;
                }
            }
        }
    }

    if (textBox == null) {
        System.out.println("No multi-column text frame was found.");
    } else {
        ITextFrame textFrame = textBox.getTextFrame();
        int configuredColumnCount = textFrame.getTextFrameFormat().getColumnCount();
        String[] columnTexts = textFrame.splitTextByColumns();

        System.out.println("Configured columns: " + configuredColumnCount);

        for (int columnIndex = 0; columnIndex < columnTexts.length; columnIndex++) {
            int columnNumber = columnIndex + 1;
            String columnText = columnTexts[columnIndex];
            System.out.println("Column " + columnNumber + ": " + columnText);
            Path outputPath = Paths.get("Column-" + columnNumber + ".txt");
            byte[] textBytes = columnText.getBytes(StandardCharsets.UTF_8);
            try {
                Files.write(outputPath, textBytes);
            } catch (IOException exception) {
                System.out.println("Could not write column " + columnNumber + ": " + exception.getMessage());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Обновление текста**

Чтобы обновить текст во всей презентации, пройдите по слайдам и фигурам, выберите автофигуры и затем отредактируйте их текстовые части. Работа на уровне частей позволяет изменять как текст, так и форматирование символов.

В следующем примере каждое вхождение `years` заменяется на `months` в тексте автофигур, и каждую затронутую часть делают полужирной:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("Text.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (!(shape instanceof IAutoShape)) {
                continue;
            }

            IAutoShape autoShape = (IAutoShape) shape;
            ITextFrame textFrame = autoShape.getTextFrame();
            if (textFrame == null) {
                continue;
            }

            for (IParagraph paragraph : textFrame.getParagraphs()) {
                for (IPortion portion : paragraph.getPortions()) {
                    String text = portion.getText();
                    if (text != null && text.contains("years")) {
                        portion.setText(text.replace("years", "months"));
                        portion.getPortionFormat().setFontBold(NullableBool.True);
                    }
                }
            }
        }
    }

    presentation.save("TextChanged.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Этот обход обновляет текст только в автофигурах. Текст, хранящийся в таблицах, диаграммах, SmartArt или сгруппированных фигурах, требует обхода соответствующих коллекций этих объектов.

## **Добавление текстового поля со ссылкой**

Гиперссылка может быть привязана к определённой части текста, поэтому только этот текст будет кликабельным. Используйте [IHyperlinkManager.setExternalHyperlinkClick](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ihyperlinkmanager/#setExternalHyperlinkClick-java.lang.String-) чтобы связать часть с внешним URL.

В следующем примере создаётся связанный текст и сохраняется в презентацию:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape textBox = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 200, 50);
    textBox.addTextFrame("Aspose.Slides");

    IPortion textPortion = textBox.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    textPortion.getPortionFormat().getHyperlinkManager().setExternalHyperlinkClick("https://www.aspose.com/");

    presentation.save("Hyperlink.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**В чём разница между текстовым полем и текстовым заполнительом на слайде‑мастре или макете?**

[заполнитель](/slides/ru/java/manage-placeholder/) может наследовать своё положение и форматирование от [главный слайд](https://reference.aspose.com/slides/ru/java/com.aspose.slides/masterslide/) или [слайд макета](https://reference.aspose.com/slides/ru/java/com.aspose.slides/layoutslide/). Обычное текстовое поле — независимая фигура на слайде, где оно создано, и не приобретает поведение заполнителя при изменении макета.

**Как заменить текст, не изменяя текста в диаграммах, таблицах или SmartArt?**

Ограничьте обход фигурами, реализующими [IAutoShape](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iautoshape/), как показано в примере Обновление текста. Диаграммы, таблицы и SmartArt хранят текст в собственных моделях объектов, поэтому они не изменяются этим циклом.
---
title: Управление текстовыми полями в презентациях на Android
linktitle: Управление текстовым полем
type: docs
weight: 20
url: /ru/androidjava/manage-textbox/
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
- Android
- Java
- Aspose.Slides
description: "Создавайте, определяйте, форматируйте и обновляйте текстовые поля в презентациях PowerPoint и OpenDocument с помощью Aspose.Slides для Android через Java."
---
## **Введение**

В Aspose.Slides for Android via Java текст слайдов хранится в текстовых кадрах, которые принадлежат фигурам. Интерфейс [IAutoShape](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iautoshape/) представляет наиболее распространённую форму, содержащую текст, и предоставляет доступ к его тексту через метод [IAutoShape.getTextFrame](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iautoshape/#getTextFrame--) .

{{% alert color="info" title="Note" %}}

Каждая автофигура реализует [IShape](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ishape/), но не каждая фигура является автофигурой или поддерживает текстовый кадр. При обработке существующей презентации проверьте, реализует ли фигура [IAutoShape](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iautoshape/) перед доступом к её тексту.

{{% /alert %}}

## **Создание текстового поля на слайде**

Чтобы создать текстовое поле, добавьте автофигуру на слайд, добавьте текст в её текстовый кадр и сохраните презентацию. В следующем примере создаётся прямоугольное текстовое поле:

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

Координаты и размеры, передаваемые в [IShapeCollection.addAutoShape](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ishapecollection/#addAutoShape-int-float-float-float-float-), измеряются в пунктах. [IAutoShape.addTextFrame](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) инициализирует текстовый кадр переданным текстом.

## **Проверка, является ли фигура текстовым полем**

Используйте метод [IAutoShape.isTextBox](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iautoshape/#isTextBox--) для определения, рассматривается ли автофигура как текстовое поле. Это полезно, когда презентация содержит как текстовые, так и чисто графические автофигуры.

![Текстовое поле и фигура](istextbox.png)

В следующем примере проверяются все автофигуры в презентации:

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

Недавно добавленная автофигура не считается текстовым полем, пока она не содержит непустой текст. Вы можете задать этот текст с помощью [IAutoShape.addTextFrame](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) или [ITextFrame.setText](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/itextframe/#setText-java.lang.String-). Добавление или присвоение пустой строки приводит к тому, что [IAutoShape.isTextBox](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iautoshape/#isTextBox--) возвращает `false`:

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

Общий код обработки текста может получать объект [ITextFrame](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/itextframe/) без знания, к какой презентации он принадлежит. Используйте только для чтения метод [ITextFrame.getParentShape](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/itextframe/#getParentShape--) для перехода к его владеющей [IShape](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ishape/).

Для текстового кадра, принадлежащего автофигуре или другой фигуре, содержащей текст, [ITextFrame.getParentShape](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/itextframe/#getParentShape--) возвращает владельца, а [ITextFrame.getParentCell](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/itextframe/#getParentCell--) возвращает `null`. Проверьте возвращаемое значение перед доступом к нему. Чтобы определить как фигурные, так и ячейки таблиц, включая фигуры, связанные с узлами SmartArt, см. [Search and Replace Text](/slides/ru/androidjava/search-and-replace-text/).

## **Добавить столбцы в текстовое поле**

Метод [ITextFrameFormat.setColumnCount](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/itextframeformat/#setColumnCount-int-) делит текстовый кадр на столбцы, а [ITextFrameFormat.setColumnSpacing](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/itextframeformat/#setColumnSpacing-double-) задаёт интервал между столбцами в пунктах. Оба параметра относятся к [ITextFrameFormat](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/itextframeformat/) и могут быть изменены через текстовый кадр существующего текстового поля. Текст перераспределяется между столбцами внутри одной фигуры; он не переходит в другую фигуру.

В следующем примере создаётся трёхколонковое текстовое поле с интервалом 10 пунктов между столбцами, сохраняется презентация и из выходного файла считываются сохранённые параметры:

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

## **Извлечение текста из отдельных столбцов**

Используйте [ITextFrame.splitTextByColumns](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/itextframe/#splitTextByColumns--) для получения текста, назначенного каждому визуальному столбцу в существующем текстовом кадре. Метод возвращает одну строку для каждого столбца в порядке чтения по столбцам. Текстовый кадр с одним столбцом возвращает массив из одного элемента, пустой столбец представляется пустой строкой. Строки содержат только простой текст; форматирование на уровне частей не сохраняется.

Это полезно, когда необходимо:

- Извлекать текст, сохраняя порядок чтения по столбцам.
- Индексировать или сравнивать содержимое слайдов с несколькими столбцами.
- Экспортировать каждый столбец в отдельный файл, поле базы данных или другое место назначения.
- Анализировать, как текст перераспределяется после изменения количества столбцов с помощью [ITextFrameFormat.setColumnCount](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/itextframeformat/#setColumnCount-int-), интервала с помощью [ITextFrameFormat.setColumnSpacing](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/itextframeformat/#setColumnSpacing-double-), шрифта или размера текстового кадра.

Метод сообщает текст, распределённый внутри текущего [ITextFrame](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/itextframe/); он не автоматически переносит текст между отдельными фигурами или текстовыми полями. Распределение столбцов может зависеть от доступных шрифтов и других параметров разметки текста, поэтому убедитесь, что необходимые шрифты доступны, когда важна согласованность результатов.

В следующем примере загружается презентация, находится первая автофигура с несколькими столбцами и текстовым кадром, считывается её настроенное количество столбцов и текст из каждого столбца записывается в отдельный файл. Фигуры без текстового кадра пропускаются.

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.IOException;
import java.nio.charset.StandardCharsets;

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
            String outputPath = "Column-" + columnNumber + ".txt";
            byte[] textBytes = columnText.getBytes(StandardCharsets.UTF_8);
            try (FileOutputStream outputStream = new FileOutputStream(outputPath)) {
                outputStream.write(textBytes);
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

Чтобы обновить текст во всей презентации, пройдите по слайдам и фигурам, выберите автофигуры и отредактируйте их текстовые части. Работа на уровне частей позволяет изменять как текст, так и форматирование символов.

В следующем примере каждый вхождение `years` заменяется на `months` в тексте автофигур, а каждую затронутую часть делают жирной:

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

## **Добавить текстовое поле с гиперссылкой**

Гиперссылка может быть назначена конкретной текстовой части, поэтому только этот фрагмент действует как кликабельная ссылка. Используйте [IHyperlinkManager.setExternalHyperlinkClick](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ihyperlinkmanager/#setExternalHyperlinkClick-java.lang.String-) для привязки части к внешнему URL.

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

**What is the difference between a text box and a text placeholder on a master or layout slide?**

[placeholder](/slides/ru/androidjava/manage-placeholder/) может наследовать своё положение и форматирование от [master slide](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/masterslide/) или [layout slide](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/layoutslide/). Обычное текстовое поле — это независимая фигура на том слайде, где оно было создано, и не приобретает поведения заполнителя при изменении макета.

**How can I replace text without changing text in charts, tables, or SmartArt?**

Ограничьте обход фигурами, реализующими [IAutoShape](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iautoshape/), как показано в примере «Обновление текста». Диаграммы, таблицы и SmartArt хранят текст в своих собственных моделях объектов, поэтому они не изменяются этим циклом.
---
title: Управление текстовыми блоками в презентациях с использованием JavaScript
linktitle: Управление текстовым блоком
type: docs
weight: 20
url: /ru/nodejs-java/manage-textbox/
keywords:
  - текстовый блок
  - текстовый кадр
  - добавить текст
  - обновить текст
  - создать текстовый блок
  - проверить текстовый блок
  - добавить текстовую колонку
  - добавить гиперссылку
  - PowerPoint
  - презентация
  - Node.js
  - JavaScript
  - Aspose.Slides
description: "Создавайте, определяйте, форматируйте и обновляйте текстовые блоки в презентациях PowerPoint и OpenDocument с использованием Aspose.Slides для Node.js через Java."
---
## **Введение**

В Aspose.Slides for Node.js via Java текст слайдов хранится в текстовых кадрах, которые принадлежат фигурам. Класс [AutoShape](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/autoshape/) представляет наиболее распространённую фигуру, содержащую текст, и предоставляет доступ к её тексту через метод [AutoShape.getTextFrame](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/autoshape/#getTextFrame).

{{% alert color="info" title="Note" %}}

Каждая автофигура наследуется от [Shape](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/shape/), но не каждая фигура является автофигурой или поддерживает текстовый кадр. При обработке существующей презентации проверяйте, является ли фигура экземпляром [AutoShape](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/autoshape/) перед доступом к её тексту.

{{% /alert %}}

## **Создание текстового блока на слайде**

Для создания текстового блока добавьте автофигуру на слайд, добавьте текст в её текстовый кадр и сохраните презентацию. Следующий пример создаёт прямоугольный текстовый блок:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const textBox = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 75, 300, 50);
    textBox.addTextFrame("Aspose TextBox");

    presentation.save("TextBox.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Координаты и размеры, передаваемые в [ShapeCollection.addAutoShape](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/shapecollection/#addAutoShape), измеряются в пунктах. [AutoShape.addTextFrame](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/autoshape/#addTextFrame) инициализирует текстовый кадр переданным текстом.

## **Проверка, является ли фигура текстовым блоком**

Используйте метод [AutoShape.isTextBox](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/autoshape/#isTextBox), чтобы определить, рассматривается ли автофигура как текстовый блок. Это полезно, когда презентация содержит как текстовые, так и чисто графические автофигуры.

![Текстовый блок и фигура](istextbox.png)

Следующий пример проверяет каждую автофигуру в презентации:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const textBox = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 120, 40);
    textBox.addTextFrame("Text box");
    slide.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 150, 10, 40, 40);

    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const currentSlide = presentation.getSlides().get_Item(slideIndex);
        for (let shapeIndex = 0; shapeIndex < currentSlide.getShapes().size(); shapeIndex++) {
            const shape = currentSlide.getShapes().get_Item(shapeIndex);
            if (java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
                console.log(shape.isTextBox() ? "The shape is a text box." : "The shape is not a text box.");
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Новоя добавленная автофигура не считается текстовым блоком, пока в ней нет непустого текста. Вы можете задать этот текст через [AutoShape.addTextFrame](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/autoshape/#addTextFrame) или [TextFrame.setText](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/textframe/#setText). Добавление или присвоение пустой строки оставляет метод [AutoShape.isTextBox](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/autoshape/#isTextBox) возвращающим `false`:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape1 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 40);
    shape1.addTextFrame("Shape 1");
    console.log(shape1.isTextBox());

    const shape2 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 70, 100, 40);
    shape2.getTextFrame().setText("Shape 2");
    console.log(shape2.isTextBox());

    const shape3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 130, 100, 40);
    shape3.addTextFrame("");
    console.log(shape3.isTextBox());

    const shape4 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 190, 100, 40);
    shape4.getTextFrame().setText("");
    console.log(shape4.isTextBox());
} finally {
    presentation.dispose();
}
```

Первые два вызова выводят `true`; последние два — `false`.

## **Найти фигуру, владеющую текстовым кадром**

Общий код обработки текста может получать объект [TextFrame](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/textframe/) без информации, какой объект презентации его содержит. Используйте только для чтения метод [TextFrame.getParentShape](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/textframe/#getParentShape), чтобы перейти к владеющей [Shape](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/shape/).

Для текстового кадра, принадлежащего автофигуре или другой фигуре, содержащей текст, [TextFrame.getParentShape](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/textframe/#getParentShape) возвращает владельца, а [TextFrame.getParentCell](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/textframe/#getParentCell) возвращает `null`. Проверьте возвращаемое значение перед доступом к нему. Чтобы определить как фигуру‑владельца, так и владельца ячейки таблицы, включая фигуры, связанные с узлами SmartArt, смотрите [Search and Replace Text](/slides/ru/nodejs-java/search-and-replace-text/).

## **Добавление столбцов в текстовый блок**

Метод [TextFrameFormat.setColumnCount](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/textframeformat/#setColumnCount) делит текстовый кадр на столбцы, а [TextFrameFormat.setColumnSpacing](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/textframeformat/#setColumnSpacing) задаёт расстояние между столбцами в пунктах. Оба параметра относятся к [TextFrameFormat](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/textframeformat/) и могут быть изменены через текстовый кадр существующего текстового блока. Текст перенесётся между столбцами внутри одной фигуры; он не будет продолжаться в другой фигуре.

Следующий пример создаёт трёхколоночный текстовый блок с расстоянием 10 пунктов между столбцами, сохраняет презентацию и считывает сохранённые настройки из выходного файла:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const textBox = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 300, 200);
    textBox.addTextFrame("This text is distributed automatically across all columns in the text box.");

    const textFrameFormat = textBox.getTextFrame().getTextFrameFormat();
    textFrameFormat.setColumnCount(3);
    textFrameFormat.setColumnSpacing(10);

    presentation.save("TextBoxColumns.pptx", aspose.slides.SaveFormat.Pptx);

    const savedPresentation = new aspose.slides.Presentation("TextBoxColumns.pptx");
    try {
        const savedTextBox = savedPresentation.getSlides().get_Item(0).getShapes().get_Item(0);
        const savedFormat = savedTextBox.getTextFrame().getTextFrameFormat();
        console.log("Columns: " + savedFormat.getColumnCount() + "; spacing: " + savedFormat.getColumnSpacing() + " points");
    } finally {
        savedPresentation.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **Извлечение текста из отдельных столбцов**

Используйте [TextFrame.splitTextByColumns](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/textframe/#splitTextByColumns), чтобы получить текст, назначенный каждому визуальному столбцу в существующем текстовом кадре. Метод возвращает одну строку для каждого столбца в порядке чтения по столбцам. Текстовый кадр с одним столбцом возвращает массив из одного элемента, а пустой столбец представляется пустой строкой. Строки содержат только обычный текст; форматирование на уровне частей не сохраняется.

Это полезно, когда требуется:

- Извлекать текст, сохраняя его порядок чтения по столбцам.  
- Индексировать или сравнивать содержание слайдов с несколькими столбцами.  
- Экспортировать каждый столбец в отдельный файл, поле базы данных или другое место.  
- Проверять, как текст перераспределяется после изменения количества столбцов с помощью [TextFrameFormat.setColumnCount](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/textframeformat/#setColumnCount), расстояния между столбцами с помощью [TextFrameFormat.setColumnSpacing](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/textframeformat/#setColumnSpacing), шрифта или размера текстового кадра.

Метод сообщает о тексте, распределённом внутри текущего [TextFrame](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/textframe/); он не перенесёт текст автоматически между отдельными фигурами или текстовыми блоками. Распределение по столбцам может зависеть от доступных шрифтов и других настроек разметки текста, поэтому убедитесь, что необходимые шрифты доступны, когда важна согласованность результатов.

Следующий пример загружает презентацию, находит первую автофигуру с несколькими столбцами и текстовым кадром, считывает её настроенное количество столбцов и записывает текст из каждого столбца в отдельный файл. Фигуры без текстового кадра пропускаются.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const fs = require("fs");

const presentation = new aspose.slides.Presentation("MultiColumnText.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    let textBox = null;
    for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
        const shape = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
            const textFrame = shape.getTextFrame();
            if (textFrame != null) {
                const columnCount = textFrame.getTextFrameFormat().getColumnCount();
                if (columnCount > 1) {
                    textBox = shape;
                    break;
                }
            }
        }
    }

    if (textBox == null) {
        console.log("No multi-column text frame was found.");
    } else {
        const textFrame = textBox.getTextFrame();
        const configuredColumnCount = textFrame.getTextFrameFormat().getColumnCount();
        const columnTexts = textFrame.splitTextByColumns();

        console.log("Configured columns: " + configuredColumnCount);

        for (let columnIndex = 0; columnIndex < columnTexts.length; columnIndex++) {
            const columnNumber = columnIndex + 1;
            const columnText = columnTexts[columnIndex];
            console.log("Column " + columnNumber + ": " + columnText);
            const outputPath = "Column-" + columnNumber + ".txt";
            try {
                fs.writeFileSync(outputPath, columnText, "utf8");
            } catch (error) {
                console.log("Could not write column " + columnNumber + ": " + error.message);
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Обновление текста**

Чтобы обновить текст во всей презентации, пройдитесь по слайдам и фигурам, выберите автофигуры и отредактируйте их текстовые части. Работа на уровне частей позволяет изменять как текст, так и форматирование символов.

Следующий пример заменяет каждое вхождение `years` на `months` в тексте автофигур и делает каждую затронутую часть полужирной:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const fontBold = java.newByte(aspose.slides.NullableBool.True);
const presentation = new aspose.slides.Presentation("Text.pptx");
try {
    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);
            if (!java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
                continue;
            }

            const textFrame = shape.getTextFrame();
            if (textFrame == null) {
                continue;
            }

            for (let paragraphIndex = 0; paragraphIndex < textFrame.getParagraphs().getCount(); paragraphIndex++) {
                const paragraph = textFrame.getParagraphs().get_Item(paragraphIndex);
                for (let portionIndex = 0; portionIndex < paragraph.getPortions().getCount(); portionIndex++) {
                    const portion = paragraph.getPortions().get_Item(portionIndex);
                    const text = portion.getText();
                    if (text != null && text.includes("years")) {
                        portion.setText(text.replace(/years/g, "months"));
                        portion.getPortionFormat().setFontBold(fontBold);
                    }
                }
            }
        }
    }

    presentation.save("TextChanged.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Этот обход обновляет текст только в автофигурах. Текст, хранящийся в таблицах, диаграммах, SmartArt или сгруппированных фигурах, требует обхода соответствующих коллекций этих объектов.

## **Добавление текстового блока с гиперссылкой**

Гиперссылка может быть привязана к конкретной части текста, поэтому только эта часть будет вести себя как кликабельная ссылка. Используйте [HyperlinkManager.setExternalHyperlinkClick](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/hyperlinkmanager/#setExternalHyperlinkClick), чтобы связать часть с внешним URL.

Следующий пример создаёт связанный текст и сохраняет его в презентацию:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const textBox = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 150, 200, 50);
    textBox.addTextFrame("Aspose.Slides");

    const textPortion = textBox.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    textPortion.getPortionFormat().getHyperlinkManager().setExternalHyperlinkClick("https://www.aspose.com/");

    presentation.save("Hyperlink.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**В чём разница между текстовым блоком и текстовым заполнителем на главном или макетном слайде?**

[placeholder](/slides/ru/nodejs-java/manage-placeholder/) может наследовать своё положение и форматирование от [master slide](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/masterslide/) или [layout slide](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/layoutslide/). Обычный текстовый блок — это независимая фигура на том слайде, где он был создан, и не приобретает поведение заполнителя при изменении макета.

**Как заменить текст, не меняя текст в диаграммах, таблицах или SmartArt?**

Ограничьте обход фигурами, являющимися экземплярами [AutoShape](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/autoshape/), как показано в примере «Обновление текста». Диаграммы, таблицы и SmartArt хранят текст в своих собственных модели объектов, поэтому они не изменяются этим циклом.
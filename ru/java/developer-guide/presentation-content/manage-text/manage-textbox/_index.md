---
title: Управление текстовыми ящиками в презентациях с помощью Java
linktitle: Управление текстовым ящиком
type: docs
weight: 20
url: /ru/java/manage-textbox/
keywords:
- текстовый ящик
- текстовый фрейм
- добавить текст
- обновить текст
- создать текстовый ящик
- проверить текстовый ящик
- добавить колонку текста
- добавить гиперссылку
- PowerPoint
- презентация
- Java
- Aspose.Slides
description: "Aspose.Slides for Java упрощает создание, редактирование и клонирование текстовых ящиков в файлах PowerPoint и OpenDocument, повышая эффективность автоматизации ваших презентаций."
---
## **Введение**

Текст на слайдах обычно находится в текстовых ящиках или фигурах. Поэтому, чтобы добавить текст на слайд, вам необходимо добавить текстовый ящик и затем поместить в него текст. Aspose.Slides for Java предоставляет интерфейс [IAutoShape](https://reference.aspose.com/slides/ru/java/com.aspose.slides/IAutoShape), который позволяет добавить фигуру, содержащую текст.

{{% alert title="Info" color="info" %}}
Aspose.Slides также предоставляет интерфейс [IShape](https://reference.aspose.com/slides/ru/java/com.aspose.slides/IShape), который позволяет добавлять фигуры на слайды. Однако не все фигуры, добавленные через интерфейс `IShape`, могут содержать текст. А фигуры, добавленные через интерфейс [IAutoShape](https://reference.aspose.com/slides/ru/java/com.aspose.slides/IAutoShape), могут содержать текст. 
{{% /alert %}}

{{% alert title="Note" color="warning" %}} 
Поэтому, работая с фигурой, к которой вы хотите добавить текст, рекомендуется проверить и подтвердить, что она была приведена к интерфейсу `IAutoShape`. Только тогда вы сможете работать с [TextFrame](https://reference.aspose.com/slides/ru/java/com.aspose.slides/TextFrame), который является свойством `IAutoShape`. См. раздел [Update Text](https://docs.aspose.com/slides/ru/java/manage-textbox/#update-text) на этой странице. 
{{% /alert %}}

## **Создать текстовый ящик на слайде**

Чтобы создать текстовый ящик на слайде, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/Presentation). 
2. Получите ссылку на первый слайд в только что созданной презентации. 
3. Добавьте объект [IAutoShape](https://reference.aspose.com/slides/ru/java/com.aspose.slides/IAutoShape) с [ShapeType](https://reference.aspose.com/slides/ru/java/com.aspose.slides/IGeometryShape#setShapeType-int-) , установленным в `Rectangle`, в указанной позиции на слайде и получите ссылку на только что добавленный объект `IAutoShape`. 
4. Добавьте свойство `TextFrame` к объекту `IAutoShape`, которое будет содержать текст. В примере ниже мы добавили такой текст: *Aspose TextBox* 
5. Наконец запишите файл PPTX через объект `Presentation`. 

Этот код Java — реализация описанных выше шагов — показывает, как добавить текст на слайд:

```java
import com.aspose.slides.*;

// Создаёт экземпляр Presentation
Presentation pres = new Presentation();
try {
    // Получает первый слайд в презентации
    ISlide sld = pres.getSlides().get_Item(0);

    // Добавляет AutoShape с типом Rectangle
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // Добавляет TextFrame к прямоугольнику
    ashp.addTextFrame(" ");

    // Получает доступ к текстовому фрейму
    ITextFrame txtFrame = ashp.getTextFrame();

    // Создаёт объект Paragraph для текстового фрейма
    IParagraph para = txtFrame.getParagraphs().get_Item(0);

    // Создаёт объект Portion для абзаца
    IPortion portion = para.getPortions().get_Item(0);

    // Устанавливает текст
    portion.setText("Aspose TextBox");

    // Сохраняет презентацию на диск
    pres.save("TextBox_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Проверка наличия формы текстового ящика**

Aspose.Slides предоставляет метод [isTextBox](https://reference.aspose.com/slides/ru/java/com.aspose.slides/autoshape/#isTextBox--) из интерфейса [IAutoShape](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iautoshape/), позволяющий исследовать фигуры и определять текстовые ящики.

![Text box and shape](istextbox.png)

Этот код Java показывает, как проверить, был ли объект создан как текстовый ящик:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ForEach.shape(presentation, (shape, slide, index) -> {
        if (shape instanceof IAutoShape) {
            IAutoShape autoShape = (IAutoShape) shape;
            System.out.println(autoShape.isTextBox() ? "shape is a text box" : "shape is not a text box");
        }
    });
} finally {
    presentation.dispose();
}
```

Обратите внимание, что если вы просто добавляете автографику с помощью метода `addAutoShape` из интерфейса [IShapeCollection](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ishapecollection/), метод `isTextBox` у автографики вернёт `false`. Однако после добавления текста к автографике с помощью метода `addTextFrame` или `setText` свойство `isTextBox` вернёт `true`.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

IAutoShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 40);
// shape1.isTextBox() возвращает false
shape1.addTextFrame("shape 1");
// shape1.isTextBox() возвращает true

IAutoShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 110, 100, 40);
// shape2.isTextBox() возвращает false
shape2.getTextFrame().setText("shape 2");
// shape2.isTextBox() возвращает true

IAutoShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 210, 100, 40);
// shape3.isTextBox() возвращает false
shape3.addTextFrame("");
// shape3.isTextBox() возвращает false

IAutoShape shape4 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 310, 100, 40);
// shape4.isTextBox() возвращает false
shape4.getTextFrame().setText("");
// shape4.isTextBox() возвращает false
```

## **Найти форму, владеющую TextFrame**

В общем коде обработки текста вы можете получить объект [ITextFrame](https://reference.aspose.com/slides/ru/java/com.aspose.slides/itextframe/) без предварительного знания, к какой презентации он относится. Используйте метод [ITextFrame.getParentShape](https://reference.aspose.com/slides/ru/java/com.aspose.slides/itextframe/#getParentShape--) для перехода к владеющей [IShape](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ishape/).

Для TextFrame, принадлежащего [IAutoShape](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iautoshape/) или другой фигуре, содержащей текст, метод [ITextFrame.getParentShape](https://reference.aspose.com/slides/ru/java/com.aspose.slides/itextframe/#getParentShape--) возвращает владельца, а метод [ITextFrame.getParentCell](https://reference.aspose.com/slides/ru/java/com.aspose.slides/itextframe/#getParentCell--) возвращает `null`. Оба метода предоставляют только читаемую навигацию, поэтому их вызов не меняет владения. Всегда проверяйте возвращаемое значение на `null` перед обращением к фигуре.

Для полного примера, идентифицирующего владельцев фигур и ячеек таблиц, включая фигуры, связанные с узлами SmartArt, см. [Search and Replace Text](/slides/ru/java/search-and-replace-text/).

## **Добавить столбцы в текстовый ящик**

Aspose.Slides предоставляет свойства [ColumnCount](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ITextFrameFormat#setColumnCount-int-) и [ColumnSpacing](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ITextFrameFormat#setColumnSpacing-double-) (из интерфейса [ITextFrameFormat](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ITextFrameFormat) и класса [TextFrameFormat](https://reference.aspose.com/slides/ru/java/com.aspose.slides/TextFrameFormat)), которые позволяют добавить столбцы в текстовые ящики. Вы можете задать количество столбцов в ящике и установить расстояние в пунктах между столбцами. 

Этот код Java демонстрирует описанную операцию:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    // Получает первый слайд в презентации
    ISlide slide = pres.getSlides().get_Item(0);

    // Добавляет AutoShape с типом Rectangle
    IAutoShape aShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

    // Добавляет TextFrame к прямоугольнику
    aShape.addTextFrame("All these columns are limited to be within a single text container -- " +
            "you can add or delete text and the new or remaining text automatically adjusts " +
            "itself to flow within the container. You cannot have text flow from one container " +
            "to other though -- we told you PowerPoint's column options for text are limited!");

    // Получает формат текста TextFrame
    ITextFrameFormat format = aShape.getTextFrame().getTextFrameFormat();

    // Указывает количество столбцов в TextFrame
    format.setColumnCount(3);

    // Указывает расстояние между столбцами
    format.setColumnSpacing(10);

    // Сохраняет презентацию
    pres.save("ColumnCount.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Добавить столбцы в TextFrame**

Aspose.Slides for Java предоставляет свойство [ColumnCount](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ITextFrameFormat#setColumnCount-int-) (из интерфейса [ITextFrameFormat](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ITextFrameFormat)), которое позволяет добавить столбцы в TextFrame. С помощью этого свойства можно указать желаемое количество столбцов в TextFrame. 

Этот код Java показывает, как добавить столбец внутри TextFrame:

```java
import com.aspose.slides.*;

String outPptxFileName = "ColumnsTest.pptx";
Presentation pres = new Presentation();
try {
    IAutoShape shape1 = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);
    ITextFrameFormat format = shape1.getTextFrame().getTextFrameFormat();

    format.setColumnCount(2);
    shape1.getTextFrame().setText("All these columns are forced to stay within a single text container -- " +
            "you can add or delete text - and the new or remaining text automatically adjusts " +
            "itself to stay within the container. You cannot have text spill over from one container " +
            "to other, though -- because PowerPoint's column options for text are limited!");
    pres.save(outPptxFileName, SaveFormat.Pptx);

    Presentation test = new Presentation(outPptxFileName);
    try {
        IAutoShape autoShape = (IAutoShape)test.getSlides().get_Item(0).getShapes().get_Item(0);
        System.out.println("Column count: " + autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        System.out.println("Column spacing: " + autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
    } finally {
        if (test != null) test.dispose();
    }

    format.setColumnSpacing(20);
    pres.save(outPptxFileName, SaveFormat.Pptx);

    Presentation test1 = new Presentation(outPptxFileName);
    try {
        IAutoShape autoShape = (IAutoShape)test1.getSlides().get_Item(0).getShapes().get_Item(0);
        System.out.println("Column count: " + autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        System.out.println("Column spacing: " + autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
    } finally {
        if (test1 != null) test1.dispose();
    }

    format.setColumnCount(3);
    format.setColumnSpacing(15);
    pres.save(outPptxFileName, SaveFormat.Pptx);

    Presentation test2 = new Presentation(outPptxFileName);
    try {
        IAutoShape autoShape = (IAutoShape)test2.getSlides().get_Item(0).getShapes().get_Item(0);
        System.out.println("Column count: " + autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        System.out.println("Column spacing: " + autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
    } finally {
        if (test2 != null) test2.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Обновить текст**

Aspose.Slides позволяет изменить или обновить текст, содержащийся в текстовом ящике, либо все тексты в презентации. 

Этот код Java демонстрирует операцию, при которой все тексты в презентации обновляются или заменяются:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("text.pptx");
try {
    for (ISlide slide : pres.getSlides())
    {
        for (IShape shape : slide.getShapes())
        {
            if (shape instanceof IAutoShape) //Проверяет, поддерживает ли фигура текстовый фрейм (IAutoShape). 
            {
                IAutoShape autoShape = (IAutoShape)shape; 
                for (IParagraph paragraph : autoShape.getTextFrame().getParagraphs()) //Итерирует абзацы в текстовом фрейме
                {
                    for (IPortion portion : paragraph.getPortions()) //Итерирует каждую часть в абзаце
                    {
                        portion.setText(portion.getText().replace("years", "months")); //Изменяет текст
                        portion.getPortionFormat().setFontBold(NullableBool.True); //Изменяет форматирование
                    }
                }
            }
        }
    }

    //Сохраняет изменённую презентацию
    pres.save("text-changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Добавить текстовый ящик со ссылкой** 

Вы можете вставить ссылку внутрь текстового ящика. При щелчке по ящику пользователи будут перенаправлены к открытию ссылки. 

Чтобы добавить текстовый ящик, содержащий ссылку, выполните следующие шаги:

1. Создайте экземпляр класса `Presentation`. 
2. Получите ссылку на первый слайд в только что созданной презентации. 
3. Добавьте объект `AutoShape` с `ShapeType`, установленным в `Rectangle`, в указанной позиции на слайде и получите ссылку на только что добавленный объект AutoShape. 
4. Добавьте `TextFrame` к объекту `AutoShape`, которое содержит *Aspose TextBox* как текст по умолчанию. 
5. Создайте экземпляр класса `IHyperlinkManager`. 
6. Назначьте объект `IHyperlinkManager` свойству [HyperlinkClick](https://reference.aspose.com/slides/ru/java/com.aspose.slides/Shape#getHyperlinkClick--) — ссылке, связанной с выбранной частью `TextFrame`. 
7. Наконец запишите файл PPTX через объект `Presentation`. 

Этот код Java — реализация описанных выше шагов — показывает, как добавить текстовый ящик со ссылкой на слайд:

```java
import com.aspose.slides.*;

// Создаёт экземпляр класса Presentation, представляющего файл PPTX
Presentation pres = new Presentation();
try {
    // Получает первый слайд в презентации
    ISlide slide = pres.getSlides().get_Item(0);

    // Добавляет объект AutoShape с типом Rectangle
    IShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 150, 50);

    // Приводит форму к типу AutoShape
    IAutoShape pptxAutoShape = (IAutoShape)shape;

    // Получает доступ к свойству ITextFrame, связанному с AutoShape
    pptxAutoShape.addTextFrame("");

    ITextFrame textFrame = pptxAutoShape.getTextFrame();

    // Добавляет текст в фрейм
    textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).setText("Aspose.Slides");

    // Устанавливает гиперссылку для текста части
    IHyperlinkManager hyperlinkManager = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).
            getPortionFormat().getHyperlinkManager();
    hyperlinkManager.setExternalHyperlinkClick("http://www.aspose.com");

    // Сохраняет PPTX‑презентацию
    pres.save("hLink_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**В чём разница между текстовым ящиком и текстовым заполнителем при работе с мастер‑слайдами?**

[Заполнитель](/slides/ru/java/manage-placeholder/) наследует стиль/положение от [мастера](https://reference.aspose.com/slides/ru/java/com.aspose.slides/masterslide/) и может быть переопределён на [макетах](https://reference.aspose.com/slides/ru/java/com.aspose.slides/layoutslide/), тогда как обычный текстовый ящик — независимый объект на конкретном слайде и не меняется при переключении макетов.

**Как выполнить массовую замену текста во всей презентации, не затрагивая текст внутри диаграмм, таблиц и SmartArt?**

Ограничьте перебор только автофигурами, имеющими TextFrame, и исключите вложенные объекты ([диаграммы](https://reference.aspose.com/slides/ru/java/com.aspose.slides/chart/), [таблицы](https://reference.aspose.com/slides/ru/java/com.aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/ru/java/com.aspose.slides/smartart/)), проходя их коллекции отдельно или пропуская такие типы объектов.
---
title: Управление текстовыми полями в презентациях на Android
linktitle: Управление текстовым полем
type: docs
weight: 20
url: /ru/androidjava/manage-textbox/
keywords:
- текстовое поле
- текстовый фрейм
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
description: "Aspose.Slides for Android via Java облегчает создание, редактирование и клонирование текстовых полей в файлах PowerPoint и OpenDocument, улучшая автоматизацию презентаций."
---

Тексты на слайдах обычно находятся в текстовых полях или фигурах. Поэтому, чтобы добавить текст на слайд, нужно добавить текстовое поле и затем поместить туда текст. Aspose.Slides for Android via Java предоставляет интерфейс [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape), который позволяет добавить фигуру, содержащую текст.

{{% alert title="Информация" color="info" %}}
Aspose.Slides также предоставляет интерфейс [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape), который позволяет добавлять фигуры на слайды. Однако не все фигуры, добавленные через интерфейс `IShape`, могут содержать текст. Фигуры, добавленные через интерфейс [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape), могут содержать текст.
{{% /alert %}}

{{% alert title="Примечание" color="warning" %}} 
Поэтому, работая с фигурой, в которую нужно добавить текст, рекомендуется проверить и убедиться, что она была приведена к интерфейсу `IAutoShape`. Только тогда вы сможете работать с [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrame), который является свойством `IAutoShape`. См. раздел [Update Text](https://docs.aspose.com/slides/androidjava/manage-textbox/#update-text) на этой странице.
{{% /alert %}}

## **Создание текстового поля на слайде**

Чтобы создать текстовое поле на слайде, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Получите ссылку на первый слайд в только что созданной презентации. 
3. Добавьте объект [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape) с типом `ShapeType` (установленным в `Rectangle`) в указанную позицию на слайде и получите ссылку на только что добавленный объект `IAutoShape`.
4. Добавьте свойство `TextFrame` к объекту `IAutoShape`, которое будет содержать текст. В примере ниже мы добавили такой текст: *Aspose TextBox*
5. Наконец, запишите файл PPTX через объект `Presentation`. 

Этот Java‑код — реализация описанных шагов — показывает, как добавить текст на слайд:
```java
// Создаёт объект Presentation
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


## **Проверка на форму текстового поля**

Aspose.Slides предоставляет метод [isTextBox](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/#isTextBox--) интерфейса [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/), позволяющий проверять фигуры и определять текстовые поля.

![Текстовое поле и фигура](istextbox.png)

Этот Java‑код показывает, как проверить, была ли фигура создана как текстовое поле: 
```java
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


Обратите внимание, что если вы просто добавите автоги́рамму с помощью метода `addAutoShape` интерфейса [IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/), метод `isTextBox` у автоги́раммы вернёт `false`. Однако после добавления текста к автоги́рамме с помощью метода `addTextFrame` или `setText` свойство `isTextBox` вернёт `true`.
```java
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


## **Добавление столбцов в текстовое поле**

Aspose.Slides предоставляет свойства [ColumnCount](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrameFormat#setColumnCount-int-) и [ColumnSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrameFormat#setColumnSpacing-double-) (из интерфейса [ITextFrameFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrameFormat) и класса [TextFrameFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrameFormat)), которые позволяют добавлять столбцы в текстовые поля. Вы можете задать количество столбцов в текстовом поле и установить расстояние между столбцами в пунктах.

Этот Java‑код демонстрирует описанную операцию: 
```java
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

    // Указывает количество колонок в TextFrame
    format.setColumnCount(3);

    // Указывает отступ между колонками
    format.setColumnSpacing(10);

    // Сохраняет презентацию
    pres.save("ColumnCount.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Добавление столбцов в текстовый фрейм**

Aspose.Slides for Android via Java предоставляет свойство [ColumnCount](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrameFormat#setColumnCount-int-) (из интерфейса [ITextFrameFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrameFormat)), которое позволяет добавлять столбцы в текстовые фреймы. С помощью этого свойства можно указать желаемое количество столбцов в текстовом фрейме.

Этот Java‑код показывает, как добавить столбец внутри текстового фрейма:
```java
String outPptxFileName = "ColumnsTest.pptx";
Presentation pres = new Presentation();
try {
    IAutoShape shape1 = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);
    TextFrameFormat format = (TextFrameFormat)shape1.getTextFrame().getTextFrameFormat();

    format.setColumnCount(2);
    shape1.getTextFrame().setText("All these columns are forced to stay within a single text container -- " +
            "you can add or delete text - and the new or remaining text automatically adjusts " +
            "itself to stay within the container. You cannot have text spill over from one container " +
            "to other, though -- because PowerPoint's column options for text are limited!");
    pres.save(outPptxFileName, SaveFormat.Pptx);

    Presentation test = new Presentation(outPptxFileName);
    try {
        IAutoShape autoShape = ((AutoShape)test.getSlides().get_Item(0).getShapes().get_Item(0));
        Assert.assertTrue(2 == autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        Assert.assertTrue(Double.NaN == autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
    } finally {
        if (test != null) test.dispose();
    }

    format.setColumnSpacing(20);
    pres.save(outPptxFileName, SaveFormat.Pptx);

    Presentation test1 = new Presentation(outPptxFileName);
    try {
        IAutoShape autoShape = ((AutoShape)test1.getSlides().get_Item(0).getShapes().get_Item(0));
        Assert.assertTrue(2 == autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        Assert.assertTrue(20 == autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
    } finally {
        if (test1 != null) test1.dispose();
    }

    format.setColumnCount(3);
    format.setColumnSpacing(15);
    pres.save(outPptxFileName, SaveFormat.Pptx);

    Presentation test2 = new Presentation(outPptxFileName);
    try {
        IAutoShape autoShape = ((AutoShape)test2.getSlides().get_Item(0).getShapes().get_Item(0));
        Assert.assertTrue(3 == autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        Assert.assertTrue(15 == autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
    } finally {
        if (test2 != null) test2.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```


## **Обновление текста**

Aspose.Slides позволяет изменять или обновлять текст, содержащийся в текстовом поле, либо все тексты в презентации. 

Этот Java‑код демонстрирует операцию, при которой все тексты в презентации обновляются или изменяются:
```java
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


## **Добавление текстового поля со ссылкой** 

Можно вставить ссылку внутри текстового поля. При клике по полю пользователи будут перенаправлены на открытую ссылку. 

Чтобы добавить текстовое поле, содержащее ссылку, выполните следующие шаги:

1. Создайте экземпляр класса `Presentation`. 
2. Получите ссылку на первый слайд в только что созданной презентации. 
3. Добавьте объект `AutoShape` с типом `ShapeType`, установленным в `Rectangle`, в указанную позицию на слайде и получите ссылку на только что добавленный объект AutoShape.
4. Добавьте `TextFrame` к объекту `AutoShape`, которое содержит *Aspose TextBox* в качестве текста по умолчанию. 
5. Создайте экземпляр класса `IHyperlinkManager`. 
6. Присвойте объект `IHyperlinkManager` свойству [HyperlinkClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Shape#getHyperlinkClick--) у выбранной части `TextFrame`.
7. Наконец, запишите файл PPTX через объект `Presentation`. 

Этот Java‑код — реализация описанных шагов — показывает, как добавить текстовое поле со ссылкой на слайд:
```java
// Создаёт объект Presentation, представляющий PPTX
Presentation pres = new Presentation();
try {
    // Получает первый слайд в презентации
    ISlide slide = pres.getSlides().get_Item(0);

    // Добавляет объект AutoShape с типом Rectangle
    IShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 150, 50);

    // Приводит форму к AutoShape
    IAutoShape pptxAutoShape = (IAutoShape)shape;

    // Получает свойство ITextFrame, связанное с AutoShape
    pptxAutoShape.addTextFrame("");

    ITextFrame textFrame = pptxAutoShape.getTextFrame();

    // Добавляет текст в фрейм
    textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).setText("Aspose.Slides");

    // Устанавливает гиперссылку для текста части
    IHyperlinkManager hyperlinkManager = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).
            getPortionFormat().getHyperlinkManager();
    hyperlinkManager.setExternalHyperlinkClick("http://www.aspose.com");

    // Сохраняет презентацию PPTX
    pres.save("hLink_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**В чём разница между текстовым полем и заполнителем текста при работе с макетными слайдами?**

[заполнитель](/slides/ru/androidjava/manage-placeholder/) наследует стиль/позицию от [мастера](https://reference.aspose.com/slides/androidjava/com.aspose.slides/masterslide/) и может быть переопределён на [макетах](https://reference.aspose.com/slides/androidjava/com.aspose.slides/layoutslide/), тогда как обычное текстовое поле — это независимый объект на конкретном слайде и не меняется при переключении макетов.

**Как выполнить массовую замену текста во всей презентации, не затрагивая текст внутри диаграмм, таблиц и SmartArt?**

Ограничьте итерацию авто‑фигур, имеющих текстовые фреймы, и исключите встроенные объекты ([диаграммы](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chart/), [таблицы](https://reference.aspose.com/slides/androidjava/com.aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/smartart/)), проходя их коллекции отдельно или пропуская такие типы объектов.
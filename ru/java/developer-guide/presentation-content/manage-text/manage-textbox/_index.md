---
title: Управление текстовым полем
type: docs
weight: 20
url: /ru/java/manage-textbox/
description: Создайте текстовое поле на слайдах PowerPoint с использованием Java. Добавьте столбец в текстовое поле или текстовую рамку на слайдах PowerPoint с использованием Java. Добавьте текстовое поле с гиперссылкой на слайды PowerPoint с использованием Java.
---


Тексты на слайдах обычно находятся в текстовых полях или фигурах. Поэтому, чтобы добавить текст на слайд, вам нужно создать текстовое поле и затем поместить текст внутрь текстового поля. Aspose.Slides для Java предоставляет интерфейс [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape), который позволяет добавлять фигуру, содержащую некоторый текст.

{{% alert title="Информация" color="info" %}}

Aspose.Slides также предоставляет интерфейс [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShape), который позволяет добавлять фигуры на слайды. Однако не все фигуры, добавленные через интерфейс `IShape`, могут содержать текст. Но фигуры, добавленные через интерфейс [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape), могут содержать текст. 

{{% /alert %}}

{{% alert title="Примечание" color="warning" %}} 

Поэтому, когда вы имеете дело с фигурой, к которой хотите добавить текст, вам, возможно, стоит проверить и подтвердить, что она была приведена к интерфейсу `IAutoShape`. Только тогда вы сможете работать с [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrame), который является свойством под `IAutoShape`. См. раздел [Обновить текст](https://docs.aspose.com/slides/java/manage-textbox/#update-text) на этой странице. 

{{% /alert %}}

## **Создание текстового поля на слайде**

Чтобы создать текстовое поле на слайде, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation). 
2. Получите ссылку на первый слайд в только что созданной презентации. 
3. Добавьте объект [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape) с установленным [ShapeType](https://reference.aspose.com/slides/java/com.aspose.slides/IGeometryShape#setShapeType-int-) как `Rectangle` в заданной позиции на слайде и получите ссылку на только что добавленный объект `IAutoShape`. 
4. Добавьте свойство `TextFrame` к объекту `IAutoShape`, которое будет содержать текст. В приведенном ниже примере мы добавили этот текст: *Aspose TextBox*
5. Наконец, запишите файл PPTX через объект `Presentation`. 

Этот код на Java — реализация перечисленных выше шагов — показывает, как добавить текст на слайд:

```java
// Создание экземпляра Presentation
Presentation pres = new Presentation();
try {
    // Получение первого слайда в презентации
    ISlide sld = pres.getSlides().get_Item(0);

    // Добавление AutoShape с типом, установленным как Rectangle
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // Добавление TextFrame в Rectangle
    ashp.addTextFrame(" ");

    // Доступ к текстовому полю
    ITextFrame txtFrame = ashp.getTextFrame();

    // Создание объекта Paragraph для текстового поля
    IParagraph para = txtFrame.getParagraphs().get_Item(0);

    // Создание объекта Portion для абзаца
    IPortion portion = para.getPortions().get_Item(0);

    // Установка текста
    portion.setText("Aspose TextBox");

    // Сохранение презентации на диск
    pres.save("TextBox_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Проверка на текстовое поле**

Aspose.Slides предоставляет свойство [isTextBox()](https://reference.aspose.com/slides/java/com.aspose.slides/autoshape/#isTextBox--) (из класса [AutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/autoshape/)), чтобы позволить вам проверять фигуры и находить текстовые поля.

![Текстовое поле и фигура](istextbox.png)

Этот код на Java показывает, как проверить, было ли создано фигура как текстовое поле: 

```java
Presentation pres = new Presentation("pres.pptx");
try {
    ForEach.shape(pres, (shape, slide, index) ->
    {
        if (shape instanceof AutoShape)
        {
            AutoShape autoShape = (AutoShape)shape;
            System.out.println(autoShape.isTextBox() ? "фигура является текстовым полем" : "фигура не является текстовым полем");
        }
    });
} finally {
    if (pres != null) pres.dispose();
}
```

## **Добавление столбца в текстовое поле**

Aspose.Slides предоставляет свойства [ColumnCount](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrameFormat#setColumnCount-int-) и [ColumnSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrameFormat#setColumnSpacing-double-) (из интерфейса [ITextFrameFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrameFormat) и класса [TextFrameFormat](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat)), которые позволяют добавлять столбцы в текстовые поля. Вы можете указать количество столбцов в текстовом поле и задать расстояние в пунктах между столбцами. 

Этот код на Java демонстрирует описанную операцию: 

```java
Presentation pres = new Presentation();
try {
    // Получение первого слайда в презентации
    ISlide slide = pres.getSlides().get_Item(0);

    // Добавление AutoShape с типом, установленным как Rectangle
    IAutoShape aShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

    // Добавление TextFrame в Rectangle
    aShape.addTextFrame("Все эти столбцы ограничены оставаться в одном текстовом контейнере — " +
            "вы можете добавлять или удалять текст, и новый или оставшийся текст автоматически подстраивается " +
            "под контейнер. Тем не менее, текст не может перетекать из одного контейнера " +
            "в другой, потому что мы говорили, что опции для текста в PowerPoint ограничены!");

    // Получение текстового формата TextFrame
    ITextFrameFormat format = aShape.getTextFrame().getTextFrameFormat();

    // Определение количества столбцов в TextFrame
    format.setColumnCount(3);

    // Определение расстояния между столбцами
    format.setColumnSpacing(10);

    // Сохранение презентации
    pres.save("ColumnCount.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Добавление столбца в текстовую рамку**
Aspose.Slides для Java предоставляет свойство [ColumnCount](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrameFormat#setColumnCount-int-) (из интерфейса [ITextFrameFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrameFormat)), которое позволяет вам добавлять столбцы в текстовые рамки. С помощью этого свойства вы можете указать предпочитаемое количество столбцов в текстовой рамке. 

Этот код на Java показывает, как добавить столбец внутри текстовой рамки:

```java
String outPptxFileName = "ColumnsTest.pptx";
Presentation pres = new Presentation();
try {
    IAutoShape shape1 = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);
    TextFrameFormat format = (TextFrameFormat)shape1.getTextFrame().getTextFrameFormat();

    format.setColumnCount(2);
    shape1.getTextFrame().setText("Все эти столбцы вынуждены оставаться в одном текстовом контейнере — " +
            "вы можете добавлять или удалять текст — и новый или оставшийся текст автоматически подстраивается " +
            "под контейнер. Текст не может выливаться из одного контейнера " +
            "в другой, потому что у PowerPoint ограничены возможности для текста!");
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

Aspose.Slides позволяет вам изменять или обновлять текст, содержащийся в текстовом поле, или все тексты, содержащиеся в презентации. 

Этот код на Java демонстрирует операцию, в которой все тексты в презентации обновляются или изменяются:

```java
Presentation pres = new Presentation("text.pptx");
try {
    for (ISlide slide : pres.getSlides())
    {
        for (IShape shape : slide.getShapes())
        {
            if (shape instanceof IAutoShape) // Проверяет, поддерживает ли фигура текстовое поле (IAutoShape). 
            {
                IAutoShape autoShape = (IAutoShape)shape; 
                for (IParagraph paragraph : autoShape.getTextFrame().getParagraphs()) // Итерация по абзацам в текстовом поле
                {
                    for (IPortion portion : paragraph.getPortions()) // Итерация по каждой части в абзаце
                    {
                        portion.setText(portion.getText().replace("years", "months")); // Изменение текста
                        portion.getPortionFormat().setFontBold(NullableBool.True); // Изменение форматирования
                    }
                }
            }
        }
    }

    // Сохранение измененной презентации
    pres.save("text-changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Добавление текстового поля с гиперссылкой** 

Вы можете вставить ссылку внутри текстового поля. Когда текстовое поле будет нажато, пользователи будут перенаправлены на открытие ссылки. 

 Чтобы добавить текстовое поле, содержащее ссылку, выполните следующие шаги:

1. Создайте экземпляр класса `Presentation`. 
2. Получите ссылку на первый слайд в только что созданной презентации. 
3. Добавьте объект `AutoShape` с установленным `ShapeType` как `Rectangle` в заданной позиции на слайде и получите ссылку на только что добавленный объект AutoShape.
4. Добавьте `TextFrame` к объекту `AutoShape`, который содержит *Aspose TextBox* как свой текст по умолчанию. 
5. Создайте экземпляр класса `IHyperlinkManager`. 
6. Назначьте объект `IHyperlinkManager` свойству [HyperlinkClick](https://reference.aspose.com/slides/java/com.aspose.slides/Shape#getHyperlinkClick--) с которым связано ваше предпочтительное порционное значение `TextFrame`. 
7. Наконец, запишите файл PPTX через объект `Presentation`. 

Этот код на Java — реализация перечисленных выше шагов — показывает, как добавить текстовое поле с гиперссылкой на слайд:

```java
// Создание экземпляра класса Presentation, представляющего PPTX
Presentation pres = new Presentation();
try {
    // Получение первого слайда в презентации
    ISlide slide = pres.getSlides().get_Item(0);

    // Добавление объекта AutoShape с типом, установленным как Rectangle
    IShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 150, 50);

    // Приведение фигуры к AutoShape
    IAutoShape pptxAutoShape = (IAutoShape)shape;

    // Доступ к свойству ITextFrame, связанному с AutoShape
    pptxAutoShape.addTextFrame("");

    ITextFrame textFrame = pptxAutoShape.getTextFrame();

    // Добавление текста в рамку
    textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).setText("Aspose.Slides");

    // Установка гиперссылки для текста порции
    IHyperlinkManager hyperlinkManager = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).
            getPortionFormat().getHyperlinkManager();
    hyperlinkManager.setExternalHyperlinkClick("http://www.aspose.com");

    // Сохранение презентации PPTX
    pres.save("hLink_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```
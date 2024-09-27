---
title: Управление текстовым полем
type: docs
weight: 20
url: /ru/androidjava/manage-textbox/
description: Создание текстового поля на слайдах PowerPoint с использованием Java. Добавление столбца в текстовом поле или текстовом фрейме на слайдах PowerPoint с использованием Java. Добавление текстового поля с гиперссылкой на слайды PowerPoint с использованием Java.
---


Тексты на слайдах обычно размещаются в текстовых полях или фигурах. Поэтому, чтобы добавить текст на слайд, нужно добавить текстовое поле и затем поместить текст внутрь текстового поля. Aspose.Slides для Android через Java предоставляет интерфейс [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape), который позволяет добавлять фигуры с содержанием текста.

{{% alert title="Информация" color="info" %}}

Aspose.Slides также предоставляет интерфейс [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape), который позволяет добавлять фигуры на слайды. Однако не все фигуры, добавленные через интерфейс `IShape`, могут содержать текст. Но фигуры, добавленные через интерфейс [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape), могут содержать текст.

{{% /alert %}}

{{% alert title="Замечание" color="warning" %}} 

Поэтому, работая с фигурой, в которую вы хотите добавить текст, вы можете проверить и подтвердить, что она была приведена через интерфейс `IAutoShape`. Только тогда вы сможете работать с [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrame), который является свойством интерфейса `IAutoShape`. Смотрите раздел [Обновление текста](https://docs.aspose.com/slides/androidjava/manage-textbox/#update-text) на этой странице.

{{% /alert %}}

## **Создание текстового поля на слайде**

Чтобы создать текстовое поле на слайде, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Получите ссылку на первый слайд в только что созданной презентации. 
3. Добавьте объект [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape) с типом [ShapeType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IGeometryShape#setShapeType-int-) установленным как `Rectangle` в заданной позиции на слайде и получите ссылку на только что добавленный объект `IAutoShape`.
4. Добавьте свойство `TextFrame` к объекту `IAutoShape`, которое будет содержать текст. В примере ниже мы добавили следующий текст: *Aspose TextBox*.
5. Наконец, запишите файл PPTX через объект `Presentation`. 

Этот код на Java — реализация вышеописанных шагов — показывает, как добавить текст на слайд:

```java
// Создает экземпляр Presentation
Presentation pres = new Presentation();
try {
    // Получает первый слайд в презентации
    ISlide sld = pres.getSlides().get_Item(0);

    // Добавляет AutoShape с типом, установленным как Rectangle
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // Добавляет TextFrame к прямоугольнику
    ashp.addTextFrame(" ");

    // Получает доступ к текстовому фрейму
    ITextFrame txtFrame = ashp.getTextFrame();

    // Создает объект Paragraph для текстового фрейма
    IParagraph para = txtFrame.getParagraphs().get_Item(0);

    // Создает объект Portion для абзаца
    IPortion portion = para.getPortions().get_Item(0);

    // Устанавливает текст
    portion.setText("Aspose TextBox");

    // Сохраняет презентацию на диск
    pres.save("TextBox_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Проверка фигуры текстового поля**

Aspose.Slides предоставляет свойство [isTextBox()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/autoshape/#isTextBox--) (из класса [AutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/autoshape/)), чтобы вы могли проверить фигуры и найти текстовые поля.

![Текстовое поле и фигура](istextbox.png)

Этот код на Java показывает, как проверить, была ли фигура создана как текстовое поле: 

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

Aspose.Slides предоставляет свойства [ColumnCount](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrameFormat#setColumnCount-int-) и [ColumnSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrameFormat#setColumnSpacing-double-) (из интерфейса [ITextFrameFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrameFormat) и класса [TextFrameFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrameFormat)), которые позволяют добавлять столбцы в текстовые поля. Вы можете указать количество столбцов в текстовом поле и установить расстояние в пунктах между столбцами.

Этот код на Java демонстрирует описанную операцию: 

```java
Presentation pres = new Presentation();
try {
    // Получает первый слайд в презентации
    ISlide slide = pres.getSlides().get_Item(0);

    // Добавляет AutoShape с типом, установленным как Rectangle
    IAutoShape aShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

    // Добавляет TextFrame к прямоугольнику
    aShape.addTextFrame("Все эти столбцы ограничены в рамках одного текстового контейнера -- " +
            "вы можете добавлять или удалять текст, и новый или оставшийся текст автоматически подстраивается " +
            "для размещения внутри контейнера. Вы не можете передавать текст из одного контейнера " +
            "в другой -- мы говорили вам, что варианты колонок PowerPoint для текста ограничены!");

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


## **Добавление столбца в текстовый фрейм**
Aspose.Slides для Android через Java предоставляет свойство [ColumnCount](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrameFormat#setColumnCount-int-) (из интерфейса [ITextFrameFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrameFormat)), которое позволяет вам добавлять столбцы в текстовые фреймы. С помощью этого свойства вы можете указать предпочтительное количество столбцов в текстовом фрейме.

Этот код на Java показывает, как добавить столбец внутри текстового фрейма:

```java
String outPptxFileName = "ColumnsTest.pptx";
Presentation pres = new Presentation();
try {
    IAutoShape shape1 = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);
    TextFrameFormat format = (TextFrameFormat)shape1.getTextFrame().getTextFrameFormat();

    format.setColumnCount(2);
    shape1.getTextFrame().setText("Все эти столбцы заставляют оставаться в рамках одного текстового контейнера -- " +
            "вы можете добавлять или удалять текст - и новый или оставшийся текст автоматически подстраивается " +
            "для размещения внутри контейнера. Вы не можете, чтобы текст переходил из одного контейнера " +
            "в другой, однако -- потому что варианты колонок PowerPoint для текста ограничены!");
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

Aspose.Slides позволяет изменять или обновлять текст, содержащийся в текстовом поле, или все тексты, содержащиеся в презентации. 

Этот код на Java демонстрирует операцию, в ходе которой все тексты в презентации обновляются или изменяются:

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
                for (IParagraph paragraph : autoShape.getTextFrame().getParagraphs()) //Итерирует по абзацам в текстовом фрейме
                {
                    for (IPortion portion : paragraph.getPortions()) //Итерирует по каждой части в абзаце
                    {
                        portion.setText(portion.getText().replace("years", "months")); //Изменяет текст
                        portion.getPortionFormat().setFontBold(NullableBool.True); //Изменяет форматирование
                    }
                }
            }
        }
    }

    //Сохраняет измененную презентацию
    pres.save("text-changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Добавление текстового поля с гиперссылкой** 

Вы можете вставить ссылку в текстовое поле. Когда текстовое поле будет нажато, пользователи будут перенаправлены на открытие ссылки. 

 Чтобы добавить текстовое поле с гиперссылкой, выполните следующие шаги:

1. Создайте экземпляр класса `Presentation`. 
2. Получите ссылку на первый слайд в только что созданной презентации. 
3. Добавьте объект `AutoShape` с `ShapeType`, установленным как `Rectangle`, в заданной позиции на слайде и получите ссылку на только что добавленный объект AutoShape.
4. Добавьте `TextFrame` к объекту `AutoShape`, который содержит *Aspose TextBox* в качестве текста по умолчанию. 
5. Создайте экземпляр класса `IHyperlinkManager`. 
6. Присвойте объект `IHyperlinkManager` свойству [HyperlinkClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Shape#getHyperlinkClick--) , связанному с вашей предпочтительной частью `TextFrame`.
7. Наконец, запишите файл PPTX через объект `Presentation`. 

Этот код на Java — реализация вышеописанных шагов — показывает, как добавить текстовое поле с гиперссылкой на слайд:

```java
// Создает экземпляр класса Presentation, представляющий PPTX
Presentation pres = new Presentation();
try {
    // Получает первый слайд в презентации
    ISlide slide = pres.getSlides().get_Item(0);

    // Добавляет объект AutoShape с типом, установленным как Rectangle
    IShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 150, 50);

    // Приводит фигуру к AutoShape
    IAutoShape pptxAutoShape = (IAutoShape)shape;

    // Получает доступ к свойству ITextFrame, связанному с AutoShape
    pptxAutoShape.addTextFrame("");

    ITextFrame textFrame = pptxAutoShape.getTextFrame();

    // Добавляет некоторый текст в фрейм
    textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).setText("Aspose.Slides");

    // Устанавливает гиперссылку для текста части
    IHyperlinkManager hyperlinkManager = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).
            getPortionFormat().getHyperlinkManager();
    hyperlinkManager.setExternalHyperlinkClick("http://www.aspose.com");

    // Сохраняет PPTX-презентацию
    pres.save("hLink_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```
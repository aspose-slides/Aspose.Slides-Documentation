---
title: Управление текстовым полем
type: docs
weight: 20
url: /ru/net/manage-textbox/
keywords:
- текстовое поле
- текстовый кадр
- добавить текст
- обновить текст
- текстовое поле со ссылкой
- PowerPoint
- презентация
- C#
- Csharp
- Aspose.Slides for .NET
description: "Управляйте текстовым полем или текстовым кадром в презентациях PowerPoint с помощью C# или .NET"
---

Текст на слайдах обычно находится в текстовых полях или фигурах. Поэтому, чтобы добавить текст на слайд, необходимо сначала добавить текстовое поле, а затем поместить в него текст. 

Чтобы вы могли добавить фигуру, способную содержать текст, Aspose.Slides для .NET предоставляет интерфейс [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape). 

{{% alert title="Note" color="warning" %}} 

Aspose.Slides также предоставляет интерфейс [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape), позволяющий добавлять фигуры на слайды. Однако не все фигуры, добавленные через интерфейс `IShape`, могут содержать текст. Фигуры, добавленные через интерфейс [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape), обычно содержат текст. 

Поэтому, работая с существующей фигурой, к которой вы хотите добавить текст, рекомендуется проверить и убедиться, что она была приведена к интерфейсу `IAutoShape`. Только тогда вы сможете работать со свойством [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/properties/textframe), которое находится в `IAutoShape`. См. раздел [Update Text](https://docs.aspose.com/slides/net/manage-textbox/#update-text) на этой странице. 

{{% /alert %}}

## **Создание текстового поля на слайде**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation). 
2. Получите ссылку на первый слайд по его индексу. 
3. Добавьте объект [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape) с [ShapeType](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/properties/shapetype), установленным в `Rectangle`, в указанную позицию на слайде и получите ссылку на вновь добавленный объект `IAutoShape`. 
4. Добавьте свойство `TextFrame` к объекту `IAutoShape`, которое будет содержать текст. В приведённом примере мы добавили следующий текст: *Aspose TextBox* 
5. Наконец, запишите файл PPTX через объект `Presentation`. 

Этот код C# — реализация вышеуказанных шагов — показывает, как добавить текст на слайд:
```c#
// Создает экземпляр PresentationEx
using (Presentation pres = new Presentation())
{

    // Получает первый слайд в презентации
    ISlide sld = pres.Slides[0];

    // Добавляет AutoShape с типом Rectangle
    IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // Добавляет TextFrame к прямоугольнику
    ashp.AddTextFrame(" ");

    // Получает доступ к текстовому кадру
    ITextFrame txtFrame = ashp.TextFrame;

    // Создает объект Paragraph для текстового кадра
    IParagraph para = txtFrame.Paragraphs[0];

    // Создает объект Portion для абзаца
    IPortion portion = para.Portions[0];

    // Устанавливает текст
    portion.Text = "Aspose TextBox";

    // Сохраняет презентацию на диск
    pres.Save("TextBox_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```


## **Проверка наличия текстового поля**

Aspose.Slides предоставляет свойство [IsTextBox](https://reference.aspose.com/slides/net/aspose.slides/autoshape/istextbox/) из интерфейса [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/), позволяющее проверять фигуры и определять текстовые поля.

![Текстовое поле и фигура](istextbox.png)

Этот код C# показывает, как проверить, была ли фигура создана как текстовое поле: 
```c#
using (Presentation presentation = new Presentation("sample.pptx"))
{
    Aspose.Slides.LowCode.ForEach.Shape(presentation, (shape, slide, index) =>
    {
        if (shape is IAutoShape autoShape)
        {
            Console.WriteLine(autoShape.IsTextBox ? "shape is a text box" : "shape is not a text box");
        }
    });
}
```


Обратите внимание, что если вы просто добавите автофигуру с помощью метода `AddAutoShape` из интерфейса [IShapeCollection](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/), свойство `IsTextBox` у автофигуры вернёт `false`. Однако после добавления текста в автофигуру с помощью метода `AddTextFrame` или свойства `Text` свойство `IsTextBox` вернёт `true`. 
```cs
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IAutoShape shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 40);
    // shape1.IsTextBox равно false
    shape1.AddTextFrame("shape 1");
    // shape1.IsTextBox равно true

    IAutoShape shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 110, 100, 40);
    // shape2.IsTextBox равно false
    shape2.TextFrame.Text = "shape 2";
    // shape2.IsTextBox равно true

    IAutoShape shape3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 210, 100, 40);
    // shape3.IsTextBox равно false
    shape3.AddTextFrame("");
    // shape3.IsTextBox равно false

    IAutoShape shape4 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 310, 100, 40);
    // shape4.IsTextBox равно false
    shape4.TextFrame.Text = "";
    // shape4.IsTextBox равно false
}
```


## **Добавление столбцов в текстовое поле**

Aspose.Slides предоставляет свойства [ColumnCount](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/properties/columncount) и [ColumnSpacing](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/properties/columnspacing) (из интерфейса [ITextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat) и класса [TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/textframeformat)), позволяющие добавить столбцы в текстовые поля. Вы можете указать количество столбцов в текстовом поле и задать расстояние в пунктах между столбцами. 

Этот код на C# демонстрирует описанную операцию: 
```c#
using (Presentation presentation = new Presentation())
{
	// Получает первый слайд в презентации
	ISlide slide = presentation.Slides[0];

	// Добавляет AutoShape с типом Rectangle
	IAutoShape aShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

	// Добавляет TextFrame к прямоугольнику
	aShape.AddTextFrame("All these columns are limited to be within a single text container -- " +
	"you can add or delete text and the new or remaining text automatically adjusts " +
	"itself to flow within the container. You cannot have text flow from one container " +
	"to other though -- we told you PowerPoint's column options for text are limited!");

	// Получает формат текста TextFrame
	ITextFrameFormat format = aShape.TextFrame.TextFrameFormat;

	// Указывает количество столбцов в TextFrame
	format.ColumnCount = 3;

	// Указывает расстояние между столбцами
	format.ColumnSpacing = 10;

	// Сохраняет презентацию
	presentation.Save("ColumnCount.pptx", SaveFormat.Pptx);
}
```


## **Добавление столбца в текстовый кадр**

Aspose.Slides for .NET предоставляет свойство [ColumnCount](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/properties/columncount) (из интерфейса [ITextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat)), которое позволяет добавить столбцы в текстовые кадры. С помощью этого свойства вы можете указать требуемое количество столбцов в текстовом кадре. 

Этот код C# показывает, как добавить столбец внутри текстового кадра:
```c#
string outPptxFileName = "ColumnsTest.pptx";
using (Presentation pres = new Presentation())
{
    IAutoShape shape1 = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);
    TextFrameFormat format = (TextFrameFormat)shape1.TextFrame.TextFrameFormat;

    format.ColumnCount = 2;
    shape1.TextFrame.Text = "All these columns are forced to stay within a single text container -- " +
                                "you can add or delete text - and the new or remaining text automatically adjusts " +
                                "itself to stay within the container. You cannot have text spill over from one container " +
                                "to other, though -- because PowerPoint's column options for text are limited!";
    pres.Save(outPptxFileName, SaveFormat.Pptx);

    using (Presentation test = new Presentation(outPptxFileName))
    {
        Debug.Assert(2 == ((AutoShape)test.Slides[0].Shapes[0]).TextFrame.TextFrameFormat.ColumnCount);
        Debug.Assert(double.NaN == ((AutoShape)test.Slides[0].Shapes[0]).TextFrame.TextFrameFormat.ColumnSpacing);
    }

    format.ColumnSpacing = 20;
    pres.Save(outPptxFileName, SaveFormat.Pptx);

    using (Presentation test = new Presentation(outPptxFileName))
    {
        Debug.Assert(2 == ((AutoShape)test.Slides[0].Shapes[0]).TextFrame.TextFrameFormat.ColumnCount);
        Debug.Assert(20 == ((AutoShape)test.Slides[0].Shapes[0]).TextFrame.TextFrameFormat.ColumnSpacing);
    }

    format.ColumnCount = 3;
    format.ColumnSpacing = 15;
    pres.Save(outPptxFileName, SaveFormat.Pptx);

    using (Presentation test = new Presentation(outPptxFileName))
    {
        Debug.Assert(3 == ((AutoShape)test.Slides[0].Shapes[0]).TextFrame.TextFrameFormat.ColumnCount);
        Debug.Assert(15 == ((AutoShape)test.Slides[0].Shapes[0]).TextFrame.TextFrameFormat.ColumnSpacing);
    }
}
```


## **Обновление текста**

Aspose.Slides позволяет изменять или обновлять текст, содержащийся в текстовом поле, либо весь текст, содержащийся в презентации. 

Этот код C# демонстрирует операцию, при которой весь текст в презентации обновляется или изменяется:
```c#
using(Presentation pres = new Presentation("text.pptx"))
{
   foreach (ISlide slide in pres.Slides)
   {
       foreach (IShape shape in slide.Shapes)
       {
           if (shape is IAutoShape autoShape) //Проверяет, поддерживает ли фигура текстовый кадр (IAutoShape). 
           {
              foreach (IParagraph paragraph in autoShape.TextFrame.Paragraphs) //Перебирает абзацы в текстовом кадре
               {
                   foreach (IPortion portion in paragraph.Portions) //Перебирает каждую часть в абзаце
                   {
                       portion.Text = portion.Text.Replace("years", "months"); //Изменяет текст
                       portion.PortionFormat.FontBold = NullableBool.True; //Изменяет форматирование
                   }
               }
           }
       }
   }
  
   //Сохраняет изменённую презентацию
   pres.Save("text-changed.pptx", SaveFormat.Pptx);
}
```


## **Добавление текстового поля со ссылкой** 

Вы можете вставить ссылку внутрь текстового поля. При щелчке по полю пользователи переходят по ссылке. 

1. Создайте экземпляр класса `Presentation`. 
2. Получите ссылку на первый слайд по его индексу.  
3. Добавьте объект `AutoShape` с `ShapeType`, установленным в `Rectangle`, в указанную позицию на слайде и получите ссылку на вновь добавленный объект AutoShape. 
4. Добавьте `TextFrame` к объекту `AutoShape`, содержащий *Aspose TextBox* в качестве текста по умолчанию. 
5. Создайте экземпляр класса `IHyperlinkManager`. 
6. Назначьте объект `IHyperlinkManager` свойству [HyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/shape/properties/hyperlinkclick), связанному с нужной частью `TextFrame`. 
7. Наконец, запишите файл PPTX через объект `Presentation`. 

Этот код C# — реализация вышеуказанных шагов — показывает, как добавить текстовое поле со ссылкой на слайд:
```c#
// Создаёт экземпляр класса Presentation, представляющего PPTX
Presentation pptxPresentation = new Presentation();

// Получает первый слайд в презентации
ISlide slide = pptxPresentation.Slides[0];

// Добавляет объект AutoShape с типом Rectangle
IShape pptxShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 150, 150, 50);

// Преобразует форму к AutoShape
IAutoShape pptxAutoShape = (IAutoShape)pptxShape;

// Получает доступ к свойству ITextFrame, связанному с AutoShape
pptxAutoShape.AddTextFrame("");

ITextFrame ITextFrame = pptxAutoShape.TextFrame;

// Добавляет некоторый текст в кадр
ITextFrame.Paragraphs[0].Portions[0].Text = "Aspose.Slides";

// Устанавливает гиперссылку для текста части
IHyperlinkManager HypMan = ITextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkManager;
HypMan.SetExternalHyperlinkClick("http://www.aspose.com");

// Сохраняет PPTX-презентацию
pptxPresentation.Save("hLinkPPTX_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```


## **Часто задаваемые вопросы**

**В чём разница между текстовым полем и заполняющим текстом (placeholder) при работе с образцами слайдов?**

[placeholder](/slides/ru/net/manage-placeholder/) наследует стиль/позицию от [master](https://reference.aspose.com/slides/net/aspose.slides/masterslide/) и может быть переопределён на [layouts](https://reference.aspose.com/slides/net/aspose.slides/layoutslide/), тогда как обычное текстовое поле является независимым объектом на конкретном слайде и не меняется при переключении макетов.

**Как выполнить массовую замену текста во всей презентации, не затрагивая текст внутри диаграмм, таблиц и SmartArt?**

Ограничьте итерацию автофигурами, имеющими текстовые кадры, и исключите встроенные объекты ([charts](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/), [tables](https://reference.aspose.com/slides/net/aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/net/aspose.slides.smartart/smartart/)), обходя их коллекции отдельно или пропуская такие типы объектов.
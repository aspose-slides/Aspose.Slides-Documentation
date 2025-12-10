---
title: Управление текстовыми полями в презентациях в .NET
linktitle: Управление текстовым полем
type: docs
weight: 20
url: /ru/net/manage-textbox/
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
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides для .NET упрощает создание, редактирование и клонирование текстовых полей в файлах PowerPoint и OpenDocument, улучшая автоматизацию ваших презентаций."
---

Текст на слайдах обычно находится в текстовых полях или фигурах. Поэтому, чтобы добавить текст на слайд, сначала нужно добавить текстовое поле, а затем поместить текст внутрь этого поля. 

Чтобы добавить форму, способную содержать текст, Aspose.Slides для .NET предоставляет интерфейс [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape) . 

{{% alert title="Note" color="warning" %}} 

Aspose.Slides также предоставляет интерфейс [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape) , позволяющий добавлять фигуры на слайды. Однако не все фигуры, добавленные через интерфейс `IShape`, могут содержать текст. Фигуры, добавленные через интерфейс [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape) , обычно содержат текст. 

Поэтому, работая с существующей фигурой, к которой вы хотите добавить текст, следует проверить и убедиться, что она приведена к интерфейсу `IAutoShape`. Только тогда вы сможете работать с [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/properties/textframe) , который является свойством `IAutoShape`. См. раздел [Обновление текста](https://docs.aspose.com/slides/net/manage-textbox/#update-text) . 

{{% /alert %}}

## **Создание текстового поля на слайде**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) .  
2. Получите ссылку на первый слайд по его индексу.  
3. Добавьте объект [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape) с параметром [ShapeType](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/properties/shapetype) , установленным в `Rectangle` , в указанную позицию на слайде и получите ссылку на только что добавленный объект `IAutoShape` .  
4. Добавьте свойство `TextFrame` к объекту `IAutoShape`, которое будет содержать текст. В приведённом ниже примере мы добавили такой текст: *Aspose TextBox*  
5. Наконец, запишите файл PPTX через объект `Presentation` .  

Этот код C# — реализация вышеописанных шагов — показывает, как добавить текст на слайд:  
```c#
    // Создаёт экземпляр PresentationEx
    using (Presentation pres = new Presentation())
    {
        // Получает первый слайд в презентации
        ISlide sld = pres.Slides[0];

        // Добавляет AutoShape с типом Rectangle
        IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

        // Добавляет TextFrame к прямоугольнику
        ashp.AddTextFrame(" ");

        // Получает доступ к текстовому фрейму
        ITextFrame txtFrame = ashp.TextFrame;

        // Создаёт объект Paragraph для текстового фрейма
        IParagraph para = txtFrame.Paragraphs[0];

        // Создаёт объект Portion для абзаца
        IPortion portion = para.Portions[0];

        // Устанавливает текст
        portion.Text = "Aspose TextBox";

        // Сохраняет презентацию на диск
        pres.Save("TextBox_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
```


## **Проверка наличия формы текстового поля**

Aspose.Slides предоставляет свойство [IsTextBox](https://reference.aspose.com/slides/net/aspose.slides/autoshape/istextbox/) интерфейса [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) , позволяющее проверять фигуры и определять текстовые поля.

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


Обратите внимание, что если вы просто добавите автографику с помощью метода `AddAutoShape` интерфейса [IShapeCollection](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/) , свойство `IsTextBox` автографики вернёт `false`. Однако после добавления текста в автографику через метод `AddTextFrame` или свойство `Text`, свойство `IsTextBox` вернёт `true`.  
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

Aspose.Slides предоставляет свойства [ColumnCount](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/properties/columncount) и [ColumnSpacing](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/properties/columnspacing) (из интерфейса [ITextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat) и класса [TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/textframeformat)) , позволяющие добавлять столбцы в текстовые поля. Вы можете указать количество столбцов в текстовом поле и задать расстояние в пунктах между столбцами. 

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

	// Задает количество колонок в TextFrame
	format.ColumnCount = 3;

	// Задает расстояние между колонками
	format.ColumnSpacing = 10;

	// Сохраняет презентацию
	presentation.Save("ColumnCount.pptx", SaveFormat.Pptx);
}
```


## **Добавление столбцов в текстовый фрейм**

Aspose.Slides для .NET предоставляет свойство [ColumnCount](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/properties/columncount) , из интерфейса [ITextFrameFormat] , которое позволяет добавлять столбцы в текстовые фреймы. С помощью этого свойства можно задать желаемое количество столбцов в текстовом фрейме. 

Этот код C# показывает, как добавить столбец внутри текстового фрейма:  
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

Aspose.Slides позволяет изменять или обновлять текст, содержащийся в текстовом поле, либо все тексты в презентации. 

Этот код C# демонстрирует операцию, при которой все тексты в презентации обновляются или изменяются:  
```c#
using(Presentation pres = new Presentation("text.pptx"))
{
   foreach (ISlide slide in pres.Slides)
   {
       foreach (IShape shape in slide.Shapes)
       {
           if (shape is IAutoShape autoShape) //Проверяет, поддерживает ли фигура текстовый фрейм (IAutoShape). 
           {
              foreach (IParagraph paragraph in autoShape.TextFrame.Paragraphs) //Итерирует абзацы в текстовом фрейме
               {
                   foreach (IPortion portion in paragraph.Portions) //Итерирует каждую часть в абзаце
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


## **Добавление текстового поля с гиперссылкой**

Вы можете вставить ссылку внутрь текстового поля. При щелчке по полю пользователи будут перенаправлены для открытия ссылки. 

1. Создайте экземпляр класса `Presentation` .  
2. Получите ссылку на первый слайд по его индексу.  
3. Добавьте объект `AutoShape` с `ShapeType`, установленным в `Rectangle` , в указанную позицию на слайде и получите ссылку на только что добавленный объект AutoShape .  
4. Добавьте `TextFrame` к объекту `AutoShape`, содержащий *Aspose TextBox* в качестве текста по умолчанию.  
5. Создайте экземпляр класса `IHyperlinkManager` .  
6. Назначьте объект `IHyperlinkManager` свойству [HyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/shape/properties/hyperlinkclick) , связанному с выбранной частью `TextFrame` .  
7. Наконец, запишите файл PPTX через объект `Presentation` .  

Этот код C# — реализация вышеописанных шагов — показывает, как добавить текстовое поле с гиперссылкой на слайд:  
```c#
// Создаёт экземпляр класса Presentation, представляющего PPTX
Presentation pptxPresentation = new Presentation();

// Получает первый слайд в презентации
ISlide slide = pptxPresentation.Slides[0];

// Добавляет объект AutoShape с типом Rectangle
IShape pptxShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 150, 150, 50);

// Приводит форму к AutoShape
IAutoShape pptxAutoShape = (IAutoShape)pptxShape;

// Получает свойство ITextFrame, связанное с AutoShape
pptxAutoShape.AddTextFrame("");

ITextFrame ITextFrame = pptxAutoShape.TextFrame;

// Добавляет текст в фрейм
ITextFrame.Paragraphs[0].Portions[0].Text = "Aspose.Slides";

// Устанавливает гиперссылку для текста части
IHyperlinkManager HypMan = ITextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkManager;
HypMan.SetExternalHyperlinkClick("http://www.aspose.com");

// Сохраняет PPTX-презентацию
pptxPresentation.Save("hLinkPPTX_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```


## **FAQ**

**В чём разница между текстовым полем и текстовым заполнителем при работе с главными слайдами?**

Заполнитель ([placeholder](/slides/ru/net/manage-placeholder/)) наследует стиль/позицию от [главного шаблона](https://reference.aspose.com/slides/net/aspose.slides/masterslide/) и может быть переопределён на [макетах](https://reference.aspose.com/slides/net/aspose.slides/layoutslide/), тогда как обычное текстовое поле является самостоятельным объектом на конкретном слайде и не меняется при переключении макетов.

**Как выполнить массовую замену текста во всей презентации, не затрагивая текст в диаграммах, таблицах и SmartArt?**

Ограничьте перебор автографикой, имеющей текстовые фреймы, и исключите вложенные объекты ([диаграммы](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/), [таблицы](https://reference.aspose.com/slides/net/aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/net/aspose.slides.smartart/smartart/)) , проходя их коллекции отдельно или пропуская такие типы объектов.
---
title: Управление текстовым полем
type: docs
weight: 20
url: /net/manage-textbox/
keywords: "Текстовое поле, Текстовый фрейм, Добавить текстовое поле, Текстовое поле с гиперссылкой, C#, Csharp, Aspose.Slides для .NET"
description: "Добавление текстового поля или текстового фрейма в презентации PowerPoint на C# или .NET"
---

Тексты на слайдах обычно существуют в текстовых полях или формах. Поэтому, чтобы добавить текст на слайд, сначала нужно добавить текстовое поле, а затем поместить текст внутрь текстового поля.

Чтобы позволить вам добавить фигуру, которая может содержать текст, Aspose.Slides для .NET предоставляет интерфейс [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape).

{{% alert title="Примечание" color="warning" %}}

Aspose.Slides также предоставляет интерфейс [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape), чтобы вы могли добавлять фигуры на слайды. Однако не все фигуры, добавленные через интерфейс `IShape`, могут содержать текст. Обычно фигуры, добавленные через интерфейс [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape), содержат текст.

Таким образом, при работе с существующей фигурой, к которой вы хотите добавить текст, вы можете проверить и подтвердить, что она была приведена к интерфейсу `IAutoShape`. Только тогда вы сможете работать с [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/properties/textframe), который является свойством под `IAutoShape`. См. раздел [Обновление текста](https://docs.aspose.com/slides/net/manage-textbox/#update-text) на этой странице.

{{% /alert %}}

## **Создание текстового поля на слайде**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Получите ссылку на первый слайд по его индексу.
3. Добавьте объект [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape) с установленным [ShapeType](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/properties/shapetype) как `Rectangle` в указанной позиции на слайде и получите ссылку на вновь добавленный объект `IAutoShape`.
4. Добавьте свойство `TextFrame` к объекту `IAutoShape`, которое будет содержать текст. В приведенном ниже примере мы добавили следующий текст: *Aspose TextBox*.
5. Наконец, запишите файл PPTX через объект `Presentation`.

Этот код на C# — реализация вышеприведенных шагов — показывает, как добавить текст на слайд:

```c#
// Создание экземпляра PresentationEx
using (Presentation pres = new Presentation())
{

    // Получает первый слайд в презентации
    ISlide sld = pres.Slides[0];

    // Добавляет AutoShape с типом, установленным как Rectangle
    IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // Добавляет TextFrame к прямоугольнику
    ashp.AddTextFrame(" ");

    // Получает доступ к текстовому фрейму
    ITextFrame txtFrame = ashp.TextFrame;

    // Создает объект Paragraph для текстового фрейма
    IParagraph para = txtFrame.Paragraphs[0];

    // Создает объект Portion для параграфа
    IPortion portion = para.Portions[0];

    // Устанавливает текст
    portion.Text = "Aspose TextBox";

    // Сохраняет презентацию на диск
    pres.Save("TextBox_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Проверка фигуры текстового поля**

Aspose.Slides предоставляет свойство [IsTextBox](https://reference.aspose.com/slides/net/aspose.slides/autoshape/istextbox/) (из класса [AutoShape](https://reference.aspose.com/slides/net/aspose.slides/autoshape/)), чтобы вы могли исследовать фигуры и находить текстовые поля.

![Текстовое поле и фигура](istextbox.png)

Этот код на C# показывает, как проверить, была ли фигура создана как текстовое поле:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    Aspose.Slides.LowCode.ForEach.Shape(pres, (shape, slide, index) =>
    {
        if (shape is AutoShape autoShape)
        {
            Console.WriteLine(autoShape.IsTextBox ? "фигура является текстовым полем" : "фигура не является текстовым полем");
        }
    });
}
```

## **Добавление столбца в текстовое поле**

Aspose.Slides предоставляет свойства [ColumnCount](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/properties/columncount) и [ColumnSpacing](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/properties/columnspacing) (из интерфейса [ITextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat) и класса [TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/textframeformat)), чтобы вы могли добавлять столбцы в текстовые поля. Вы можете указать количество столбцов в текстовом поле, а затем указать расстояние в пунктах между столбцами.

Этот код на C# иллюстрирует описанную операцию:

```c#
using (Presentation presentation = new Presentation())
{
	// Получает первый слайд в презентации
	ISlide slide = presentation.Slides[0];

	// Добавляет AutoShape с типом, установленным как Rectangle
	IAutoShape aShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

	// Добавляет TextFrame к прямоугольнику
	aShape.AddTextFrame("Все эти столбцы ограничены одним текстовым контейнером -- " +
	"вы можете добавлять или удалять текст, и новый или оставшийся текст автоматически подстраивается " +
	"в пределах контейнера. Текст не может перемещаться из одного контейнера в другой — " +
	"мы говорим вам, что параметры столбцов PowerPoint для текста ограничены!");

	// Получает текстовый формат TextFrame
	ITextFrameFormat format = aShape.TextFrame.TextFrameFormat;

	// Указывает количество столбцов в TextFrame
	format.ColumnCount = 3;

	// Указывает расстояние между столбцами
	format.ColumnSpacing = 10;

	// Сохраняет презентацию
	presentation.Save("ColumnCount.pptx", SaveFormat.Pptx);
}
```

## **Добавление столбца в текстовый фрейм**

Aspose.Slides для .NET предоставляет свойство [ColumnCount](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/properties/columncount) (из интерфейса [ITextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat)), который позволяет добавлять столбцы в текстовые фреймы. Через это свойство вы можете указать предпочитаемое количество столбцов в текстовом фрейме.

Этот код на C# показывает, как добавить столбец внутри текстового фрейма:

```c#
string outPptxFileName = "ColumnsTest.pptx";
using (Presentation pres = new Presentation())
{
    IAutoShape shape1 = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);
    TextFrameFormat format = (TextFrameFormat)shape1.TextFrame.TextFrameFormat;

    format.ColumnCount = 2;
    shape1.TextFrame.Text = "Все эти столбцы вынуждены оставаться в пределах одного текстового контейнера -- " +
                                "вы можете добавлять или удалять текст - и новый или оставшийся текст автоматически подстраивается " +
                                "в пределах контейнера. Текст не может пролиться из одного контейнера в другой, однако, -- потому что параметры столбцов PowerPoint для текста ограничены!";
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

Aspose.Slides позволяет вам изменять или обновлять текст, содержащийся в текстовом поле или во всех текстах, содержащихся в презентации.

Этот код на C# демонстрирует операцию, при которой все тексты в презентации обновляются или изменяются:

```c#
using(Presentation pres = new Presentation("text.pptx"))
{
   foreach (ISlide slide in pres.Slides)
   {
       foreach (IShape shape in slide.Shapes)
       {
           if (shape is IAutoShape autoShape) // Проверяет, поддерживает ли фигура текстовый фрейм (IAutoShape).
           {
              foreach (IParagraph paragraph in autoShape.TextFrame.Paragraphs) // Итерирует по параграфам в текстовом фрейме
               {
                   foreach (IPortion portion in paragraph.Portions) // Итерирует по каждому порции в параграфе
                   {
                       portion.Text = portion.Text.Replace("years", "months"); // Изменяет текст
                       portion.PortionFormat.FontBold = NullableBool.True; // Изменяет форматирование
                   }
               }
           }
       }
   }
  
   // Сохраняет изменённую презентацию
   pres.Save("text-changed.pptx", SaveFormat.Pptx);
}
```

## **Добавление текстового поля с гиперссылкой**

Вы можете вставить ссылку внутри текстового поля. Когда текстовое поле будет нажато, пользователи будут направлены на открытие ссылки.

1. Создайте экземпляр класса `Presentation`.
2. Получите ссылку на первый слайд по его индексу.
3. Добавьте объект `AutoShape` с установленным `ShapeType` как `Rectangle` в указанной позиции на слайде и получите ссылку на вновь добавленный объект AutoShape.
4. Добавьте `TextFrame` к объекту `AutoShape`, который содержит *Aspose TextBox* в качестве своего текста по умолчанию.
5. Создайте экземпляр класса `IHyperlinkManager`.
6. Присвойте объект `IHyperlinkManager` свойству [HyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/shape/properties/hyperlinkclick), связанному с вашей предпочтительной порцией `TextFrame`.
7. Наконец, запишите файл PPTX через объект `Presentation`.

Этот код на C# — реализация вышеприведенных шагов — показывает, как добавить текстовое поле с гиперссылкой на слайд:

```c#
// Создание экземпляра класса Presentation, представляющего PPTX
Presentation pptxPresentation = new Presentation();

// Получает первый слайд в презентации
ISlide slide = pptxPresentation.Slides[0];

// Добавляет объект AutoShape с типом, установленным как Rectangle
IShape pptxShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 150, 150, 50);

// Приводит фигуру к AutoShape
IAutoShape pptxAutoShape = (IAutoShape)pptxShape;

// Получает доступ к свойству ITextFrame, связанному с AutoShape
pptxAutoShape.AddTextFrame("");

ITextFrame ITextFrame = pptxAutoShape.TextFrame;

// Добавляет текст в фрейм
ITextFrame.Paragraphs[0].Portions[0].Text = "Aspose.Slides";

// Устанавливает гиперссылку для текста порции
IHyperlinkManager HypMan = ITextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkManager;
HypMan.SetExternalHyperlinkClick("http://www.aspose.com");

// Сохраняет PPTX-презентацию
pptxPresentation.Save("hLinkPPTX_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```
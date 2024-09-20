---
title: Управление гиперссылками
type: docs
weight: 20
url: /net/manage-hyperlinks/
keywords: "Добавить гиперссылку, Презентация PowerPoint, Гиперссылка PowerPoint, текстовая гиперссылка, гиперссылка на слайд, гиперссылка на фигуру, гиперссылка на изображение, гиперссылка на видео, .NET, C#, Csharp"
description: "Добавить гиперссылку в презентацию PowerPoint на C# или .NET"
---

Гиперссылка — это ссылка на объект или данные или место в чем-то. Вот некоторые распространенные гиперссылки в презентациях PowerPoint:

* Ссылки на веб-сайты внутри текстов, фигур или медиа
* Ссылки на слайды

Aspose.Slides для .NET позволяет выполнять множество задач, связанных с гиперссылками в презентациях.

{{% alert color="primary" %}} 

Вы можете ознакомиться с простым, [бесплатным онлайн-редактором PowerPoint от Aspose.](https://products.aspose.app/slides/editor)

{{% /alert %}} 

## **Добавление гиперссылок URL**

### **Добавление гиперссылок URL к текстам**

Этот код на C# показывает, как добавить гиперссылку на веб-сайт к тексту:

```c#
using (Presentation presentation = new Presentation())
{
	IAutoShape shape1 = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, false);
	shape1.AddTextFrame("Aspose: File Format APIs");
	shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
	shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick.Tooltip = "Более 70% компаний из списка Fortune 100 доверяют API Aspose";
	shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 32;

	presentation.Save("presentation-out.pptx", SaveFormat.Pptx);
}
```

### **Добавление гиперссылок URL к фигурам или рамкам**

Этот пример кода на C# показывает, как добавить гиперссылку на веб-сайт к фигуре:

```c#
using (Presentation pres = new Presentation())
{
    IShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 600, 50);
    
    shape.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
    shape.HyperlinkClick.Tooltip = "Более 70% компаний из списка Fortune 100 доверяют API Aspose";

    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```

### **Добавление гиперссылок URL к медиа**

Aspose.Slides позволяет добавлять гиперссылки к изображениям, аудио и видеофайлам.

Этот пример кода показывает, как добавить гиперссылку к **изображению**:

```c#
using (Presentation pres = new Presentation())
{
    // Добавляет изображение в презентацию
    IPPImage image = pres.Images.AddImage(File.ReadAllBytes("image.png"));
    // Создает рамку изображения на слайде 1 на основе ранее добавленного изображения
    IPictureFrame pictureFrame = pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);

    pictureFrame.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
    pictureFrame.HyperlinkClick.Tooltip = "Более 70% компаний из списка Fortune 100 доверяют API Aspose";

    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```

Этот пример кода показывает, как добавить гиперссылку к **аудиофайлу**:

```c#
using (Presentation pres = new Presentation())
{
    IAudio audio = pres.Audios.AddAudio(File.ReadAllBytes("audio.mp3"));
    IAudioFrame audioFrame = pres.Slides[0].Shapes.AddAudioFrameEmbedded(10, 10, 100, 100, audio);

    audioFrame.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
    audioFrame.HyperlinkClick.Tooltip = "Более 70% компаний из списка Fortune 100 доверяют API Aspose";

    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```

Этот пример кода показывает, как добавить гиперссылку к **видео**:

``` csharp
using (Presentation pres = new Presentation())
{
    IVideo video = pres.Videos.AddVideo(File.ReadAllBytes("video.avi"));
    IVideoFrame videoFrame = pres.Slides[0].Shapes.AddVideoFrame(10, 10, 100, 100, video);

    videoFrame.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
    videoFrame.HyperlinkClick.Tooltip = "Более 70% компаний из списка Fortune 100 доверяют API Aspose";

    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```

{{%  alert  title="Совет"  color="primary"  %}} 

Вы можете ознакомиться с *[Управление OLE](https://docs.aspose.com/slides/net/manage-ole/)*.

{{% /alert %}}


## **Использование гиперссылок для создания оглавления**

Поскольку гиперссылки позволяют добавлять ссылки на объекты или места, вы можете использовать их для создания оглавления.

Этот пример кода показывает, как создать оглавление с гиперссылками:

```c#
using (var presentation = new Presentation())
{
    var firstSlide = presentation.Slides[0];
    var secondSlide = presentation.Slides.AddEmptySlide(firstSlide.LayoutSlide);

    var contentTable = firstSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 300, 100);
    contentTable.FillFormat.FillType = FillType.NoFill;
    contentTable.LineFormat.FillFormat.FillType = FillType.NoFill;
    contentTable.TextFrame.Paragraphs.Clear();

    var paragraph = new Paragraph();
    paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    paragraph.Text = "Название слайда 2 .......... ";

    var linkPortion = new Portion();
    linkPortion.Text = "Страница 2";
    linkPortion.PortionFormat.HyperlinkManager.SetInternalHyperlinkClick(secondSlide);

    paragraph.Portions.Add(linkPortion);
    contentTable.TextFrame.Paragraphs.Add(paragraph);

    presentation.Save("link_to_slide.pptx", SaveFormat.Pptx);
}
```

## **Форматирование гиперссылок**

### **Цвет**

С помощью свойства [ColorSource](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/properties/colorsource) в интерфейсе [IHyperlink](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink) вы можете установить цвет для гиперссылок, а также получить информацию о цвете из гиперссылок. Эта функция была впервые введена в PowerPoint 2019, поэтому изменения, касающиеся свойства, не применяются к более ранним версиям PowerPoint.

Этот пример кода демонстрирует операцию, в которой гиперссылки с разными цветами добавляются на тот же слайд:

```c#
using (Presentation presentation = new Presentation())
{
    IAutoShape shape1 = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 450, 50, false);
    shape1.AddTextFrame("Это пример цветной гиперссылки.");
    shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
    shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick.ColorSource = HyperlinkColorSource.PortionFormat;
    shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.FillType = FillType.Solid;
    shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.SolidFillColor.Color = Color.Red;

    IAutoShape shape2 = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 450, 50, false);
    shape2.AddTextFrame("Это пример обычной гиперссылки.");
    shape2.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com/");

    presentation.Save("presentation-out-hyperlink.pptx", SaveFormat.Pptx);
}
```
### **Звук**

Aspose.Slides предоставляет следующие свойства, чтобы выделить гиперссылку с помощью звука:
- [IHyperlink.Sound](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/properties/sound) 
- [IHyperlink.StopSoundOnClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/properties/stopsoundonclick)

#### **Добавить звук гиперссылки**

Этот код на C# показывает, как установить гиперссылку, которая воспроизводит звук и останавливает его с помощью другой гиперссылки:

```c#
using (Presentation pres = new Presentation())
{
	// Добавляет новый аудиофайл в коллекцию аудио презентации
	IAudio playSound = pres.Audios.AddAudio(File.ReadAllBytes("sampleaudio.wav"));

	ISlide firstSlide = pres.Slides[0];

	// Добавляет новую фигуру с гиперссылкой на следующий слайд
	IShape firstShape = firstSlide.Shapes.AddAutoShape(ShapeType.SoundButton, 100, 100, 100, 50);
	firstShape.HyperlinkClick = Hyperlink.NextSlide;

	// Проверяет гиперссылку на "Без звука"
	if (!firstShape.HyperlinkClick.StopSoundOnClick && firstShape.HyperlinkClick.Sound == null)
	{
		// Устанавливает гиперссылку, воспроизводящую звук
		firstShape.HyperlinkClick.Sound = playSound;
	}

	// Добавляет пустой слайд 
	ISlide secondSlide = pres.Slides.AddEmptySlide(firstSlide.LayoutSlide);

	// Добавляет новую фигуру с гиперссылкой "NoAction"
	IShape secondShape = secondSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 100, 50);
	secondShape.HyperlinkClick = Hyperlink.NoAction;

	// Устанавливает флаг гиперссылки "Остановить предыдущий звук"
	secondShape.HyperlinkClick.StopSoundOnClick = true;

	pres.Save("hyperlink-sound.pptx", SaveFormat.Pptx);
}
```

#### **Извлечение звука гиперссылки**

Этот код на C# показывает, как извлечь звук, используемый в гиперссылке:

```c#
using (Presentation pres = new Presentation("hyperlink-sound.pptx"))
{
	ISlide firstSlide = pres.Slides[0];

	// Получает первую гиперссылку фигуры
	IHyperlink link = firstSlide.Shapes[0].HyperlinkClick;

	if (link.Sound != null)
	{
		// Извлекает звук гиперссылки в виде массива байтов
		byte[] audioData = link.Sound.BinaryData;
	}
}
```

## **Удаление гиперссылок в презентациях**

### **Удаление гиперссылок из текстов**

Этот код на C# показывает, как удалить гиперссылку из текста на слайде презентации:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    ISlide slide = pres.Slides[0];
    foreach (IShape shape in slide.Shapes)
    {
        IAutoShape autoShape = shape as IAutoShape;
        if (autoShape != null)
        {
            foreach (IParagraph paragraph in autoShape.TextFrame.Paragraphs)
            {
                foreach (IPortion portion in paragraph.Portions)
                {
                    portion.PortionFormat.HyperlinkManager.RemoveHyperlinkClick();
                }
            }
        }
    }
    
    pres.Save("pres-removed-hyperlinks.pptx", SaveFormat.Pptx);
}
```

### **Удаление гиперссылок из фигур или рамок**

Этот код на C# показывает, как удалить гиперссылку из фигуры на слайде презентации: 

```csharp
using (Presentation pres = new Presentation("demo.pptx")) 
{ 
   ISlide slide = pres.Slides[0]; 
   foreach (IShape shape in slide.Shapes) 
     { 
       shape.HyperlinkManager.RemoveHyperlinkClick(); 
     } 
   pres.Save("pres-removed-hyperlinks.pptx", SaveFormat.Pptx); 
}
```

## **Изменяемая гиперссылка**

Класс [Hyperlink](https://reference.aspose.com/slides/net/aspose.slides/hyperlink) изменяемый. С помощью этого класса вы можете изменить значения для следующих свойств:

- [IHyperlink.TargetFrame](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/properties/targetframe)
- [IHyperlink.Tooltip](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/properties/tooltip)
- [IHyperlink.History](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/properties/history)
- [IHyperlink.HighlightClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/properties/highlightclick)

Сниппет кода показывает, как добавить гиперссылку на слайд и позже отредактировать ее подсказку:

```c#
using (Presentation presentation = new Presentation())
{   
   IAutoShape shape1 = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, false);    
    
   shape1.AddTextFrame("Aspose: File Format APIs");
    
   shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
    
    shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick.Tooltip = "Более 70% компаний из списка Fortune 100 доверяют API Aspose";
    
    shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 32;
    
 presentation.Save("presentation-out.pptx", SaveFormat.Pptx);
}
```




## **Поддерживаемые свойства в IHyperlinkQueries**

Вы можете получить доступ к IHyperlinkQueries из презентации, слайда или текста, для которого определена гиперссылка. 

- [IPresentation.HyperlinkQueries](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/properties/hyperlinkqueries)
- [IBaseSlide.HyperlinkQueries](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/properties/hyperlinkqueries)
- [ITextFrame.HyperlinkQueries](https://reference.aspose.com/slides/net/aspose.slides/itextframe/properties/hyperlinkqueries)

Класс IHyperlinkQueries поддерживает следующие методы и свойства: 

- [IHyperlinkQueries.GetHyperlinkClicks();](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/methods/gethyperlinkclicks)
- [IHyperlinkQueries.GetHyperlinkMouseOvers();](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/methods/gethyperlinkmouseovers)
- [IHyperlinkQueries.GetAnyHyperlinks();](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/methods/getanyhyperlinks)
- [IHyperlinkQueries.RemoveAllHyperlinks();](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/methods/removeallhyperlinks)
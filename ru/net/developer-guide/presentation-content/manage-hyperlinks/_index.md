---
title: Управление гиперссылками
type: docs
weight: 20
url: /ru/net/manage-hyperlinks/
keywords: "Добавить гиперссылку, Презентация PowerPoint, Гиперссылка PowerPoint, гиперссылка текста, гиперссылка слайда, гиперссылка фигуры, гиперссылка изображения, гиперссылка видео, .NET, C#, Csharp"
description: "Добавить гиперссылку в презентацию PowerPoint на C# или .NET"
---

Гиперссылка — это ссылка на объект, данные или место в документе. Ниже приведены распространённые гиперссылки в презентациях PowerPoint:

* Ссылки на веб‑сайты в тексте, фигурах или медиафайлах
* Ссылки на слайды

Aspose.Slides for .NET позволяет выполнять множество задач, связанных с гиперссылками в презентациях. 

{{% alert color="primary" %}} 

Возможно, вам будет интересно ознакомиться с простым, [бесплатным онлайн‑редактором PowerPoint.](https://products.aspose.app/slides/editor)

{{% /alert %}} 

## **Добавление URL‑гиперссылок**

### **Добавление URL‑гиперссылок в текст**

Этот код C# показывает, как добавить веб‑сайт в виде гиперссылки к тексту:
```c#
using (Presentation presentation = new Presentation())
{
	IAutoShape shape1 = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, false);
	shape1.AddTextFrame("Aspose: File Format APIs");
	shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
	shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick.Tooltip = "More than 70% Fortune 100 companies trust Aspose APIs";
	shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 32;

	presentation.Save("presentation-out.pptx", SaveFormat.Pptx);
}
```


### **Добавление URL‑гиперссылок в фигуры или фреймы**

Этот пример кода на C# показывает, как добавить веб‑сайт в виде гиперссылки к фигуре:
```c#
using (Presentation pres = new Presentation())
{
    IShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 600, 50);
    
    shape.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
    shape.HyperlinkClick.Tooltip = "More than 70% Fortune 100 companies trust Aspose APIs";

    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```


### **Добавление URL‑гиперссылок в медиафайлы**

Aspose.Slides позволяет добавлять гиперссылки к изображениям, аудио‑ и видеофайлам. 

Этот пример кода показывает, как добавить гиперссылку к **изображению**:
```c#
using (Presentation pres = new Presentation())
{
    // Добавляет изображение в презентацию
    IPPImage image = pres.Images.AddImage(File.ReadAllBytes("image.png"));
    // Создает рамку изображения на слайде 1 на основе ранее добавленного изображения
    IPictureFrame pictureFrame = pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);

    pictureFrame.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
    pictureFrame.HyperlinkClick.Tooltip = "More than 70% Fortune 100 companies trust Aspose APIs";

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
    audioFrame.HyperlinkClick.Tooltip = "More than 70% Fortune 100 companies trust Aspose APIs";

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
    videoFrame.HyperlinkClick.Tooltip = "More than 70% Fortune 100 companies trust Aspose APIs";

    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```


{{%  alert  title="Tip"  color="primary"  %}} 

Возможно, вам будет интересно посмотреть *[Управление OLE](https://docs.aspose.com/slides/net/manage-ole/)*.

{{% /alert %}}

## **Использование гиперссылок для создания оглавления**

Поскольку гиперссылки позволяют добавлять ссылки на объекты или места, их можно использовать для создания оглавления. 

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
    paragraph.Text = "Title of slide 2 .......... ";

    var linkPortion = new Portion();
    linkPortion.Text = "Page 2";
    linkPortion.PortionFormat.HyperlinkManager.SetInternalHyperlinkClick(secondSlide);

    paragraph.Portions.Add(linkPortion);
    contentTable.TextFrame.Paragraphs.Add(paragraph);

    presentation.Save("link_to_slide.pptx", SaveFormat.Pptx);
}
```


## **Форматирование гиперссылок**

### **Цвет**

С помощью свойства [ColorSource] в интерфейсе [IHyperlink] можно задавать цвет гиперссылок и также получать информацию о цвете из гиперссылок. Эта возможность впервые появилась в PowerPoint 2019, поэтому изменения, связанные со свойством, не применимы к более старым версиям PowerPoint.

Этот пример кода демонстрирует операцию, при которой гиперссылки с разными цветами были добавлены на один слайд:
```c#
using (Presentation presentation = new Presentation())
{
    IAutoShape shape1 = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 450, 50, false);
    shape1.AddTextFrame("This is a sample of colored hyperlink.");
    shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
    shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick.ColorSource = HyperlinkColorSource.PortionFormat;
    shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.FillType = FillType.Solid;
    shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.SolidFillColor.Color = Color.Red;

    IAutoShape shape2 = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 450, 50, false);
    shape2.AddTextFrame("This is a sample of usual hyperlink.");
    shape2.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com/");

    presentation.Save("presentation-out-hyperlink.pptx", SaveFormat.Pptx);
}
```

### **Звук**

Aspose.Slides предоставляет следующие свойства, позволяющие подчеркнуть гиперссылку звуком:
- [IHyperlink.Sound](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/properties/sound) 
- [IHyperlink.StopSoundOnClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/properties/stopsoundonclick)

#### **Добавление звука к гиперссылке**

Этот код C# показывает, как задать гиперссылку, воспроизводящую звук, и остановить его другой гиперссылкой:
```c#
using (Presentation pres = new Presentation())
{
	// Добавляет новый аудио в коллекцию аудио презентации
	IAudio playSound = pres.Audios.AddAudio(File.ReadAllBytes("sampleaudio.wav"));

	ISlide firstSlide = pres.Slides[0];

	// Добавляет новую фигуру со ссылкой на следующий слайд
	IShape firstShape = firstSlide.Shapes.AddAutoShape(ShapeType.SoundButton, 100, 100, 100, 50);
	firstShape.HyperlinkClick = Hyperlink.NextSlide;

	// Проверяет гиперссылку на отсутствие звука
	if (!firstShape.HyperlinkClick.StopSoundOnClick && firstShape.HyperlinkClick.Sound == null)
	{
		// Устанавливает гиперссылку, которая воспроизводит звук
		firstShape.HyperlinkClick.Sound = playSound;
	}

	// Добавляет пустой слайд 
	ISlide secondSlide = pres.Slides.AddEmptySlide(firstSlide.LayoutSlide);

	// Добавляет новую фигуру с гиперссылкой NoAction
	IShape secondShape = secondSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 100, 50);
	secondShape.HyperlinkClick = Hyperlink.NoAction;

	// Устанавливает флаг гиперссылки «Остановить предыдущий звук»
	secondShape.HyperlinkClick.StopSoundOnClick = true;

	pres.Save("hyperlink-sound.pptx", SaveFormat.Pptx);
}
```


#### **Извлечение звука из гиперссылки**

Этот код C# показывает, как извлечь звук, использованный в гиперссылке:
```c#
using (Presentation pres = new Presentation("hyperlink-sound.pptx"))
{
	ISlide firstSlide = pres.Slides[0];

	// Получает гиперссылку первой фигуры
	IHyperlink link = firstSlide.Shapes[0].HyperlinkClick;

	if (link.Sound != null)
	{
		// Извлекает звук гиперссылки в массив байт
		byte[] audioData = link.Sound.BinaryData;
	}
}
```


## **Удаление гиперссылок в презентациях**

### **Удаление гиперссылок из текста**

Этот код C# показывает, как удалить гиперссылку из текста на слайде презентации:
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


### **Удаление гиперссылок из фигур или фреймов**

Этот код C# показывает, как удалить гиперссылку из фигуры на слайде презентации: 
``` csharp
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

Класс [Hyperlink] изменяемый. С его помощью можно изменять значения следующих свойств:

- [IHyperlink.TargetFrame](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/properties/targetframe)
- [IHyperlink.Tooltip](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/properties/tooltip)
- [IHyperlink.History](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/properties/history)
- [IHyperlink.HighlightClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/properties/highlightclick)

Этот фрагмент кода показывает, как добавить гиперссылку на слайд и позже изменить её всплывающую подсказку:
```c#
using (Presentation presentation = new Presentation())
{   
   IAutoShape shape1 = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, false);    
    
   shape1.AddTextFrame("Aspose: File Format APIs");
    
   shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
    
    shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick.Tooltip = "More than 70% Fortune 100 companies trust Aspose APIs";
    
    shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 32;
    
 presentation.Save("presentation-out.pptx", SaveFormat.Pptx);
}
```


## **Поддерживаемые свойства в IHyperlinkQueries**

К IHyperlinkQueries можно получить доступ из презентации, слайда или текста, для которого определена гипер ссылка. 

- [IPresentation.HyperlinkQueries](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/properties/hyperlinkqueries)
- [IBaseSlide.HyperlinkQueries](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/properties/hyperlinkqueries)
- [ITextFrame.HyperlinkQueries](https://reference.aspose.com/slides/net/aspose.slides/itextframe/properties/hyperlinkqueries)

Класс IHyperlinkQueries поддерживает следующие методы и свойства: 

- [IHyperlinkQueries.GetHyperlinkClicks();](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/methods/gethyperlinkclicks)
- [IHyperlinkQueries.GetHyperlinkMouseOvers();](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/methods/gethyperlinkmouseovers)
- [IHyperlinkQueries.GetAnyHyperlinks();](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/methods/getanyhyperlinks)
- [IHyperlinkQueries.RemoveAllHyperlinks();](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/methods/removeallhyperlinks)

## **FAQ**

**Как можно создать внутреннюю навигацию не только к слайду, но и к «разделу» или к первому слайду раздела?**

Разделы в PowerPoint — это группы слайдов; навигация технически направлена на конкретный слайд. Чтобы «перейти к разделу», обычно создают ссылку на его первый слайд.

**Могу ли я прикрепить гиперссылку к элементам слайд‑мастера, чтобы она работала на всех слайдах?**

Да. Элементы слайд‑мастера и макета поддерживают гиперссылки. Такие ссылки отображаются на дочерних слайдах и кликабельны во время показа.

**Сохранятся ли гиперссылки при экспорте в PDF, HTML, изображения или видео?**

В [PDF](/slides/ru/net/convert-powerpoint-to-pdf/) и [HTML](/slides/ru/net/convert-powerpoint-to-html/) ссылки, как правило, сохраняются. При экспорте в [изображения](/slides/ru/net/convert-powerpoint-to-png/) и [видео](/slides/ru/net/convert-powerpoint-to-video/) кликабельность не сохраняется из‑за характера этих форматов (растровые кадры/видео не поддерживают гиперссылки).
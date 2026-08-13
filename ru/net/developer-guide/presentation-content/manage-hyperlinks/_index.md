---
title: Управление гиперссылками презентаций в .NET
linktitle: Управление гиперссылкой
type: docs
weight: 20
url: /ru/net/manage-hyperlinks/
keywords:
- добавить URL
- добавить гиперссылку
- создать гиперссылку
- форматировать гиперсылку
- удалить гиперссылку
- обновить гиперссылку
- гиперссылка в тексте
- гиперссылка на слайд
- гиперссылка на фигуру
- гиперссылка на изображение
- гиперссылка на видео
- изменяемая гиперссылка
- PowerPoint
- OpenDocument
- презентация
- .NET
- C#
- Aspose.Slides
description: "Легко управляйте гиперссылками в презентациях PowerPoint и OpenDocument с помощью Aspose.Slides для .NET — улучшайте интерактивность и рабочий процесс за считанные минуты."
---
## **Введение**

Гиперссылка — это ссылка на объект, данные или место в документе. Ниже перечислены типичные гиперссылки в презентациях PowerPoint:

* Ссылки на веб‑сайты в тексте, фигурах или медиа
* Ссылки на слайды

Aspose.Slides for .NET позволяет выполнять множество операций с гиперссылками в презентациях. 

{{% alert color="info" %}} 

Возможно, вам будет интересно попробовать простой [бесплатный онлайн‑редактор PowerPoint.](https://products.aspose.app/slides/ru/editor)

{{% /alert %}} 

## **Добавить гиперссылки URL**

### **Добавить гиперссылки URL к тексту**

Этот C# код показывает, как добавить веб‑ссылку к тексту:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

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

### **Добавить гиперссылки URL к фигурам или кадрам**

Этот пример кода на C# показывает, как добавить веб‑ссылку к фигуре:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    IShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 600, 50);
    
    shape.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
    shape.HyperlinkClick.Tooltip = "More than 70% Fortune 100 companies trust Aspose APIs";

    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```

### **Добавить гиперссылки URL к медиа**

Aspose.Slides позволяет добавлять гиперссылки к изображениям, аудио‑ и видеофайлам. 

Этот пример кода показывает, как добавить гиперссылку к **изображению**:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

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
using Aspose.Slides;
using Aspose.Slides.Export;

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
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    IVideo video = pres.Videos.AddVideo(File.ReadAllBytes("video.avi"));
    IVideoFrame videoFrame = pres.Slides[0].Shapes.AddVideoFrame(10, 10, 100, 100, video);

    videoFrame.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
    videoFrame.HyperlinkClick.Tooltip = "More than 70% Fortune 100 companies trust Aspose APIs";

    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```

{{%  alert  title="Tip"  color="info"  %}} 

Возможно, вам будет полезно посмотреть *[Управление OLE](https://docs.aspose.com/slides/ru/net/manage-ole/)*.

{{% /alert %}}


## **Использовать гиперссылки для создания оглавления**

Поскольку гиперссылки позволяют добавлять ссылки на объекты или места, их можно использовать для создания оглавления. 

Этот пример кода показывает, как создать оглавление с гиперссылками:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

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

## **Форматировать гиперссылки**

### **Цвет**

С помощью свойства [ColorSource](https://reference.aspose.com/slides/ru/net/aspose.slides/ihyperlink/properties/colorsource) в интерфейсе [IHyperlink](https://reference.aspose.com/slides/ru/net/aspose.slides/ihyperlink) вы можете задавать цвет гиперссылок и получать информацию о цвете гиперссылок. Эта возможность впервые появилась в PowerPoint 2019, поэтому изменения свойства не применимы к более ранним версиям PowerPoint.

Этот пример кода демонстрирует операцию, когда гиперссылки разных цветов были добавлены на один и тот же слайд:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

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

Aspose.Slides предоставляет следующие свойства, позволяющие усилить гиперссылку звуком:
- [IHyperlink.Sound](https://reference.aspose.com/slides/ru/net/aspose.slides/ihyperlink/properties/sound) 
- [IHyperlink.StopSoundOnClick](https://reference.aspose.com/slides/ru/net/aspose.slides/ihyperlink/properties/stopsoundonclick)

#### **Добавить звук к гиперссылке**

Этот C# код показывает, как задать гиперссылку, воспроизводящую звук, и остановить её другой гиперссылкой:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
	// Добавляет новый аудио в коллекцию аудио презентации
	IAudio playSound = pres.Audios.AddAudio(File.ReadAllBytes("sampleaudio.wav"));

	ISlide firstSlide = pres.Slides[0];

	// Добавляет новую фигуру с гиперссылкой на следующий слайд
	IShape firstShape = firstSlide.Shapes.AddAutoShape(ShapeType.SoundButton, 100, 100, 100, 50);
	firstShape.HyperlinkClick = Hyperlink.NextSlide;

	// Проверяет гиперссылку на отсутствие звука
	if (!firstShape.HyperlinkClick.StopSoundOnClick && firstShape.HyperlinkClick.Sound == null)
	{
		// Устанавливает гиперссылку, воспроизводящую звук
		firstShape.HyperlinkClick.Sound = playSound;
	}

	// Добавляет пустой слайд 
	ISlide secondSlide = pres.Slides.AddEmptySlide(firstSlide.LayoutSlide);

	// Добавляет новую фигуру с гиперссылкой NoAction
	IShape secondShape = secondSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 100, 50);
	secondShape.HyperlinkClick = Hyperlink.NoAction;

	// Устанавливает флаг гиперссылки "Остановить предыдущий звук"
	secondShape.HyperlinkClick.StopSoundOnClick = true;

	pres.Save("hyperlink-sound.pptx", SaveFormat.Pptx);
}
```

#### **Извлечь звук из гиперссылки**

Этот C# код показывает, как извлечь звук, используемый в гиперссылке:

```c#
using Aspose.Slides;

using (Presentation pres = new Presentation("hyperlink-sound.pptx"))
{
	ISlide firstSlide = pres.Slides[0];

	// Получает гиперссылку первой фигуры
	IHyperlink link = firstSlide.Shapes[0].HyperlinkClick;

	if (link.Sound != null)
	{
		// Извлекает звук гиперссылки в массив байтов
		byte[] audioData = link.Sound.BinaryData;
	}
}
```

## **Удалить гиперссылки из презентаций**

### **Удалить гиперссылки из текста**

Этот C# код показывает, как удалить гиперссылку из текста на слайде презентации:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

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

### **Удалить гиперссылки из фигур или кадров**

Этот C# код показывает, как удалить гиперссылку из фигуры на слайде презентации: 

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;

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

Класс [Hyperlink](https://reference.aspose.com/slides/ru/net/aspose.slides/hyperlink) изменяемый. С его помощью можно менять значения следующих свойств:

- [IHyperlink.TargetFrame](https://reference.aspose.com/slides/ru/net/aspose.slides/ihyperlink/properties/targetframe)
- [IHyperlink.Tooltip](https://reference.aspose.com/slides/ru/net/aspose.slides/ihyperlink/properties/tooltip)
- [IHyperlink.History](https://reference.aspose.com/slides/ru/net/aspose.slides/ihyperlink/properties/history)
- [IHyperlink.HighlightClick](https://reference.aspose.com/slides/ru/net/aspose.slides/ihyperlink/properties/highlightclick)

Этот фрагмент кода показывает, как добавить гиперссылку на слайд и позже изменить её всплывающую подсказку:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

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

Вы можете получить доступ к IHyperlinkQueries из презентации, слайда или текстового кадра, для которых определена гиперссылка. 

- [IPresentation.HyperlinkQueries](https://reference.aspose.com/slides/ru/net/aspose.slides/ipresentation/properties/hyperlinkqueries)
- [IBaseSlide.HyperlinkQueries](https://reference.aspose.com/slides/ru/net/aspose.slides/ibaseslide/properties/hyperlinkqueries)
- [ITextFrame.HyperlinkQueries](https://reference.aspose.com/slides/ru/net/aspose.slides/itextframe/properties/hyperlinkqueries)

Класс IHyperlinkQueries поддерживает следующие методы и свойства: 

- [IHyperlinkQueries.GetHyperlinkClicks();](https://reference.aspose.com/slides/ru/net/aspose.slides/ihyperlinkqueries/methods/gethyperlinkclicks)
- [IHyperlinkQueries.GetHyperlinkMouseOvers();](https://reference.aspose.com/slides/ru/net/aspose.slides/ihyperlinkqueries/methods/gethyperlinkmouseovers)
- [IHyperlinkQueries.GetAnyHyperlinks();](https://reference.aspose.com/slides/ru/net/aspose.slides/ihyperlinkqueries/methods/getanyhyperlinks)
- [IHyperlinkQueries.RemoveAllHyperlinks();](https://reference.aspose.com/slides/ru/net/aspose.slides/ihyperlinkqueries/methods/removeallhyperlinks)

## **FAQ**

### Как создать внутреннюю навигацию не только к слайду, но и к «разделу» или первому слайду раздела?

Разделы в PowerPoint — это группы слайдов; навигация технически направлена на конкретный слайд. Чтобы «перейти к разделу», обычно связываются с его первым слайдом.

### Можно ли привязать гиперссылку к элементам шаблона слайдов, чтобы она работала на всех слайдах?

Да. Элементы макета и шаблона поддерживают гиперссылки. Такие ссылки отображаются на дочерних слайдах и кликабельны во время показа.

### Сохранятся ли гиперссылки при экспорте в PDF, HTML, изображения или видео?

В [PDF](/slides/ru/net/convert-powerpoint-to-pdf/) и [HTML](/slides/ru/net/convert-powerpoint-to-html/) да — ссылки, как правило, сохраняются. При экспорте в [изображения](/slides/ru/net/convert-powerpoint-to-png/) и [видео](/slides/ru/net/convert-powerpoint-to-video/) кликабельность не переносится из‑за особенностей этих форматов (растровые кадры/видео не поддерживают гиперссылки).
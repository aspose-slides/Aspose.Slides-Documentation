---
title: Gestire i collegamenti ipertestuali della presentazione in .NET
linktitle: Gestire collegamento ipertestuale
type: docs
weight: 20
url: /it/net/manage-hyperlinks/
keywords:
- aggiungi URL
- aggiungi collegamento ipertestuale
- crea collegamento ipertestuale
- formatta collegamento ipertestuale
- rimuovi collegamento ipertestuale
- aggiorna collegamento ipertestuale
- collegamento ipertestuale nel testo
- collegamento ipertestuale nella diapositiva
- collegamento ipertestuale alla forma
- collegamento ipertestuale all'immagine
- collegamento ipertestuale al video
- collegamento ipertestuale modificabile
- PowerPoint
- OpenDocument
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Gestisci facilmente i collegamenti ipertestuali nelle presentazioni PowerPoint e OpenDocument con Aspose.Slides per .NET—migliora l'interattività e il flusso di lavoro in pochi minuti."
---
## **Introduzione**

Un collegamento ipertestuale è un riferimento a un oggetto, a dei dati o a un punto in qualcosa. Questi sono collegamenti ipertestuali comuni nelle presentazioni PowerPoint:

* Collegamenti a siti web all'interno di testo, forme o media
* Collegamenti a diapositive

Aspose.Slides per .NET ti consente di eseguire molte attività relative ai collegamenti ipertestuali nelle presentazioni. 

{{% alert color="info" %}} 
Potresti voler provare Aspose simple, [editor PowerPoint online gratuito.](https://products.aspose.app/slides/it/editor)
{{% /alert %}} 

## **Aggiungere collegamenti URL**

### **Aggiungere collegamenti URL al testo**

Questo codice C# mostra come aggiungere un collegamento a un sito web a del testo:

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

### **Aggiungere collegamenti URL a forme o cornici**

Questo esempio di codice in C# mostra come aggiungere un collegamento a un sito web a una forma:

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

### **Aggiungere collegamenti URL a file multimediali**

Aspose.Slides consente di aggiungere collegamenti ipertestuali a immagini, file audio e video. 

Questo esempio di codice mostra come aggiungere un collegamento a un'**immagine**:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    // Aggiunge immagine alla presentazione
    IPPImage image = pres.Images.AddImage(File.ReadAllBytes("image.png"));
    // Crea un frame immagine nella diapositiva 1 basato sull'immagine aggiunta in precedenza
    IPictureFrame pictureFrame = pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);

    pictureFrame.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
    pictureFrame.HyperlinkClick.Tooltip = "More than 70% Fortune 100 companies trust Aspose APIs";

    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```
Questo esempio di codice mostra come aggiungere un collegamento a un **file audio**:

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
Questo esempio di codice mostra come aggiungere un collegamento a un **video**:

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

{{%  alert  title="Suggerimento"  color="info"  %}} 
Potresti voler vedere *[Gestisci OLE](https://docs.aspose.com/slides/it/net/manage-ole/)*.
{{% /alert %}}

## **Utilizzare i collegamenti ipertestuali per creare un indice**

Poiché i collegamenti ipertestuali consentono di aggiungere riferimenti a oggetti o luoghi, è possibile usarli per creare un indice.

Questo esempio di codice mostra come creare un indice con collegamenti ipertestuali:

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

## **Formattare i collegamenti ipertestuali**

### **Colore**

Con la proprietà [ColorSource](https://reference.aspose.com/slides/it/net/aspose.slides/ihyperlink/properties/colorsource) nell'interfaccia [IHyperlink](https://reference.aspose.com/slides/it/net/aspose.slides/ihyperlink), è possibile impostare il colore per i collegamenti ipertestuali e anche ottenere le informazioni sul colore dai collegamenti. La funzionalità è stata introdotta per la prima volta in PowerPoint 2019, quindi le modifiche relative a questa proprietà non si applicano alle versioni più vecchie di PowerPoint.

Questo esempio di codice dimostra un'operazione in cui sono stati aggiunti collegamenti ipertestuali con colori diversi alla stessa diapositiva:

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
### **Suono**

Aspose.Slides fornisce queste proprietà per consentire di enfatizzare un collegamento ipertestuale con un suono:
- [IHyperlink.Sound](https://reference.aspose.com/slides/it/net/aspose.slides/ihyperlink/properties/sound) 
- [IHyperlink.StopSoundOnClick](https://reference.aspose.com/slides/it/net/aspose.slides/ihyperlink/properties/stopsoundonclick)

#### **Aggiungere un suono al collegamento ipertestuale**

Questo codice C# mostra come impostare il collegamento ipertestuale che riproduce un suono e fermarlo con un altro collegamento:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
	// Aggiunge nuovo audio alla collezione audio della presentazione
	IAudio playSound = pres.Audios.AddAudio(File.ReadAllBytes("sampleaudio.wav"));

	ISlide firstSlide = pres.Slides[0];

	// Aggiunge nuova forma con il collegamento ipertestuale alla diapositiva successiva
	IShape firstShape = firstSlide.Shapes.AddAutoShape(ShapeType.SoundButton, 100, 100, 100, 50);
	firstShape.HyperlinkClick = Hyperlink.NextSlide;

	// Verifica il collegamento ipertestuale per "Nessun suono"
	if (!firstShape.HyperlinkClick.StopSoundOnClick && firstShape.HyperlinkClick.Sound == null)
	{
		// Imposta il collegamento ipertestuale che riproduce il suono
		firstShape.HyperlinkClick.Sound = playSound;
	}

	// Aggiunge la diapositiva vuota 
	ISlide secondSlide = pres.Slides.AddEmptySlide(firstSlide.LayoutSlide);

	// Aggiunge nuova forma con il collegamento NoAction
	IShape secondShape = secondSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 100, 50);
	secondShape.HyperlinkClick = Hyperlink.NoAction;

	// Imposta il flag del collegamento ipertestuale "Interrompi suono precedente"
	secondShape.HyperlinkClick.StopSoundOnClick = true;

	pres.Save("hyperlink-sound.pptx", SaveFormat.Pptx);
}
```

#### **Estrarre il suono di un collegamento ipertestuale**

Questo codice C# mostra come estrarre il suono utilizzato in un collegamento ipertestuale:

```c#
using Aspose.Slides;

using (Presentation pres = new Presentation("hyperlink-sound.pptx"))
{
	ISlide firstSlide = pres.Slides[0];

	// Ottiene il collegamento ipertestuale della prima forma
	IHyperlink link = firstSlide.Shapes[0].HyperlinkClick;

	if (link.Sound != null)
	{
		// Estrae il suono del collegamento ipertestuale in un array di byte
		byte[] audioData = link.Sound.BinaryData;
	}
}
```

## **Rimuovere i collegamenti ipertestuali dalle presentazioni**

### **Rimuovere i collegamenti ipertestuali dal testo**

Questo codice C# mostra come rimuovere il collegamento ipertestuale da un testo in una diapositiva di una presentazione:

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

### **Rimuovere i collegamenti ipertestuali da forme o cornici**

Questo codice C# mostra come rimuovere il collegamento ipertestuale da una forma in una diapositiva di una presentazione: 

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

## **Collegamento ipertestuale modificabile**

La classe [Hyperlink](https://reference.aspose.com/slides/it/net/aspose.slides/hyperlink) è modificabile. Con questa classe, è possibile cambiare i valori di queste proprietà:

- [IHyperlink.TargetFrame](https://reference.aspose.com/slides/it/net/aspose.slides/ihyperlink/properties/targetframe)
- [IHyperlink.Tooltip](https://reference.aspose.com/slides/it/net/aspose.slides/ihyperlink/properties/tooltip)
- [IHyperlink.History](https://reference.aspose.com/slides/it/net/aspose.slides/ihyperlink/properties/history)
- [IHyperlink.HighlightClick](https://reference.aspose.com/slides/it/net/aspose.slides/ihyperlink/properties/highlightclick)

Il frammento di codice mostra come aggiungere un collegamento ipertestuale a una diapositiva e modificarne il tooltip in seguito:

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

## **Proprietà supportate in IHyperlinkQueries**

È possibile accedere a IHyperlinkQueries da una presentazione, diapositiva o testo per cui è definito il collegamento ipertestuale. 

- [IPresentation.HyperlinkQueries](https://reference.aspose.com/slides/it/net/aspose.slides/ipresentation/properties/hyperlinkqueries)
- [IBaseSlide.HyperlinkQueries](https://reference.aspose.com/slides/it/net/aspose.slides/ibaseslide/properties/hyperlinkqueries)
- [ITextFrame.HyperlinkQueries](https://reference.aspose.com/slides/it/net/aspose.slides/itextframe/properties/hyperlinkqueries)

La classe IHyperlinkQueries supporta questi metodi e proprietà: 

- [IHyperlinkQueries.GetHyperlinkClicks();](https://reference.aspose.com/slides/it/net/aspose.slides/ihyperlinkqueries/methods/gethyperlinkclicks)
- [IHyperlinkQueries.GetHyperlinkMouseOvers();](https://reference.aspose.com/slides/it/net/aspose.slides/ihyperlinkqueries/methods/gethyperlinkmouseovers)
- [IHyperlinkQueries.GetAnyHyperlinks();](https://reference.aspose.com/slides/it/net/aspose.slides/ihyperlinkqueries/methods/getanyhyperlinks)
- [IHyperlinkQueries.RemoveAllHyperlinks();](https://reference.aspose.com/slides/it/net/aspose.slides/ihyperlinkqueries/methods/removeallhyperlinks)

## **FAQ**

### Come posso creare una navigazione interna non solo a una diapositiva, ma a una "sezione" o alla prima diapositiva di una sezione?

Le sezioni in PowerPoint sono raggruppamenti di diapositive; la navigazione tecnicamente punta a una diapositiva specifica. Per "navigare a una sezione", in genere si collega alla sua prima diapositiva.

### Posso allegare un collegamento ipertestuale agli elementi del master slide in modo che funzioni su tutte le diapositive?

Sì. Gli elementi del master slide e del layout supportano i collegamenti ipertestuali. Tali collegamenti appaiono sulle diapositive figlie e sono cliccabili durante la presentazione.

### I collegamenti ipertestuali saranno preservati durante l'esportazione in PDF, HTML, immagini o video?

In [PDF](/slides/it/net/convert-powerpoint-to-pdf/) e [HTML](/slides/it/net/convert-powerpoint-to-html/), sì — i collegamenti sono generalmente preservati. Quando si esporta in [immagini](/slides/it/net/convert-powerpoint-to-png/) e [video](/slides/it/net/convert-powerpoint-to-video/), la funzionalità di clic non sarà mantenuta a causa della natura di questi formati (i fotogrammi raster/video non supportano i collegamenti ipertestuali).
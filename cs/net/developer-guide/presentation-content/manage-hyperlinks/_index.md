---
title: Správa hypertextových odkazů v prezentacích v .NET
linktitle: Správa hypertextového odkazu
type: docs
weight: 20
url: /cs/net/manage-hyperlinks/
keywords:
- přidat URL
- přidat hypertextový odkaz
- vytvořit hypertextový odkaz
- formátovat hypertextový odkaz
- odstranit hypertextový odkaz
- aktualizovat hypertextový odkaz
- hypertextový odkaz v textu
- hypertextový odkaz na snímek
- hypertextový odkaz na tvar
- hypertextový odkaz na obrázek
- hypertextový odkaz na video
- měnitelný hypertextový odkaz
- PowerPoint
- OpenDocument
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Jednoduše spravujte hypertextové odkazy v prezentacích PowerPoint a OpenDocument pomocí Aspose.Slides pro .NET—zvyšte interaktivitu a efektivitu práce během několika minut."
---
## **Úvod**

Hyperlink je odkaz na objekt, data nebo místo v něčem. Toto jsou běžné hypertextové odkazy v prezentacích PowerPoint:

* Odkazy na webové stránky uvnitř textu, tvarů nebo médií
* Odkazy na snímky

Aspose.Slides pro .NET vám umožňuje provádět mnoho úkolů souvisejících s hypertextovými odkazy v prezentacích. 

{{% alert color="primary" %}} 

Možná budete chtít vyzkoušet jednoduchý, [bezplatný online editor PowerPointu.](https://products.aspose.app/slides/cs/editor)

{{% /alert %}} 

## **Přidání URL hypertextových odkazů**

### **Přidání URL hypertextových odkazů do textu**

Tento C# kód ukazuje, jak přidat hypertextový odkaz na webovou stránku do textu:

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

### **Přidání URL hypertextových odkazů do tvarů nebo rámců**

Tento ukázkový kód v C# ukazuje, jak přidat hypertextový odkaz na webovou stránku do tvaru:

```c#
using (Presentation pres = new Presentation())
{
    IShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 600, 50);
    
    shape.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
    shape.HyperlinkClick.Tooltip = "More than 70% Fortune 100 companies trust Aspose APIs";

    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```

### **Přidání URL hypertextových odkazů k médiím**

Aspose.Slides vám umožňuje přidávat hypertextové odkazy k obrázkům, audio a video souborům. 

Tento ukázkový kód ukazuje, jak přidat hypertextový odkaz k **obrázku**:

```c#
using (Presentation pres = new Presentation())
{
    // Přidá obrázek do prezentace
    IPPImage image = pres.Images.AddImage(File.ReadAllBytes("image.png"));
    // Vytvoří rámeček obrázku na snímku 1 na základě dříve přidaného obrázku
    IPictureFrame pictureFrame = pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);

    pictureFrame.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
    pictureFrame.HyperlinkClick.Tooltip = "More than 70% Fortune 100 companies trust Aspose APIs";

    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```

Tento ukázkový kód ukazuje, jak přidat hypertextový odkaz k **audio souboru**:

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

Tento ukázkový kód ukazuje, jak přidat hypertextový odkaz k **videu**:

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

Možná budete chtít zobrazit *[Spravovat OLE](https://docs.aspose.com/slides/cs/net/manage-ole/)*.

{{% /alert %}}

## **Použití hypertextových odkazů k vytvoření obsahu**

Protože hypertextové odkazy vám umožňují přidávat odkazy na objekty či místa, můžete je použít k vytvoření obsahu.

Tento ukázkový kód ukazuje, jak vytvořit obsah s hypertextovými odkazy:

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

## **Formátování hypertextových odkazů**

### **Barva**

Pomocí vlastnosti [ColorSource](https://reference.aspose.com/slides/cs/net/aspose.slides/ihyperlink/properties/colorsource) v rozhraní [IHyperlink](https://reference.aspose.com/slides/cs/net/aspose.slides/ihyperlink) můžete nastavit barvu hypertextových odkazů a také získat informace o barvě z hypertextových odkazů. Tato funkce byla poprvé představena v PowerPointu 2019, takže změny související s touto vlastností se nevztahují na starší verze PowerPointu.

Tento ukázkový kód demonstruje operaci, při níž byly na stejný snímek přidány hypertextové odkazy s různými barvami:

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
### **Zvuk**

Aspose.Slides poskytuje tyto vlastnosti, které vám umožní zdůraznit hypertextový odkaz zvukem:
- [IHyperlink.Sound](https://reference.aspose.com/slides/cs/net/aspose.slides/ihyperlink/properties/sound) 
- [IHyperlink.StopSoundOnClick](https://reference.aspose.com/slides/cs/net/aspose.slides/ihyperlink/properties/stopsoundonclick)

#### **Přidání zvuku k hypertextovému odkazu**

Tento C# kód ukazuje, jak nastavit hypertextový odkaz, který přehrává zvuk, a zastavit jej pomocí dalšího hypertextového odkazu:

```c#
using (Presentation pres = new Presentation())
{
	// Přidá nový zvuk do kolekce zvuků prezentace
	IAudio playSound = pres.Audios.AddAudio(File.ReadAllBytes("sampleaudio.wav"));

	ISlide firstSlide = pres.Slides[0];

	// Přidá nový tvar s hypertextovým odkazem na následující snímek
	IShape firstShape = firstSlide.Shapes.AddAutoShape(ShapeType.SoundButton, 100, 100, 100, 50);
	firstShape.HyperlinkClick = Hyperlink.NextSlide;

	// Kontroluje hypertextový odkaz pro "Žádný zvuk"
	if (!firstShape.HyperlinkClick.StopSoundOnClick && firstShape.HyperlinkClick.Sound == null)
	{
		// Nastaví hypertextový odkaz, který přehrává zvuk
		firstShape.HyperlinkClick.Sound = playSound;
	}

	// Přidá prázdný snímek 
	ISlide secondSlide = pres.Slides.AddEmptySlide(firstSlide.LayoutSlide);

	// Přidá nový tvar s hypertextovým odkazem NoAction
	IShape secondShape = secondSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 100, 50);
	secondShape.HyperlinkClick = Hyperlink.NoAction;

	// Nastaví příznak hypertextového odkazu "Zastavit předchozí zvuk"
	secondShape.HyperlinkClick.StopSoundOnClick = true;

	pres.Save("hyperlink-sound.pptx", SaveFormat.Pptx);
}
```

#### **Extrahování zvuku z hypertextového odkazu**

Tento C# kód ukazuje, jak extrahovat zvuk použitý v hypertextovém odkazu:

```c#
using (Presentation pres = new Presentation("hyperlink-sound.pptx"))
{
	ISlide firstSlide = pres.Slides[0];

	// Získá hypertextový odkaz prvního tvaru
	IHyperlink link = firstSlide.Shapes[0].HyperlinkClick;

	if (link.Sound != null)
	{
		// Extrahuje zvuk hypertextového odkazu do pole bajtů
		byte[] audioData = link.Sound.BinaryData;
	}
}
```

## **Odstranění hypertextových odkazů z prezentací**

### **Odstranění hypertextových odkazů z textu**

Tento C# kód ukazuje, jak odstranit hypertextový odkaz z textu na snímku prezentace:

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

### **Odstranění hypertextových odkazů z tvarů nebo rámců**

Tento C# kód ukazuje, jak odstranit hypertextový odkaz z tvaru na snímku prezentace: 

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

## **Měnný hypertextový odkaz**

Třída [Hyperlink](https://reference.aspose.com/slides/cs/net/aspose.slides/hyperlink) je měnná. S touto třídou můžete měnit hodnoty těchto vlastností:

- [IHyperlink.TargetFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/ihyperlink/properties/targetframe)
- [IHyperlink.Tooltip](https://reference.aspose.com/slides/cs/net/aspose.slides/ihyperlink/properties/tooltip)
- [IHyperlink.History](https://reference.aspose.com/slides/cs/net/aspose.slides/ihyperlink/properties/history)
- [IHyperlink.HighlightClick](https://reference.aspose.com/slides/cs/net/aspose.slides/ihyperlink/properties/highlightclick)

Ukázkový úryvek kódu ukazuje, jak přidat hypertextový odkaz na snímek a později upravit jeho popisek:

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

## **Podporované vlastnosti v IHyperlinkQueries**

K IHyperlinkQueries můžete přistupovat z prezentace, snímku nebo textu, pro který je hypertextový odkaz definován. 

- [IPresentation.HyperlinkQueries](https://reference.aspose.com/slides/cs/net/aspose.slides/ipresentation/properties/hyperlinkqueries)
- [IBaseSlide.HyperlinkQueries](https://reference.aspose.com/slides/cs/net/aspose.slides/ibaseslide/properties/hyperlinkqueries)
- [ITextFrame.HyperlinkQueries](https://reference.aspose.com/slides/cs/net/aspose.slides/itextframe/properties/hyperlinkqueries)

Třída IHyperlinkQueries podporuje tyto metody a vlastnosti: 

- [IHyperlinkQueries.GetHyperlinkClicks();](https://reference.aspose.com/slides/cs/net/aspose.slides/ihyperlinkqueries/methods/gethyperlinkclicks)
- [IHyperlinkQueries.GetHyperlinkMouseOvers();](https://reference.aspose.com/slides/cs/net/aspose.slides/ihyperlinkqueries/methods/gethyperlinkmouseovers)
- [IHyperlinkQueries.GetAnyHyperlinks();](https://reference.aspose.com/slides/cs/net/aspose.slides/ihyperlinkqueries/methods/getanyhyperlinks)
- [IHyperlinkQueries.RemoveAllHyperlinks();](https://reference.aspose.com/slides/cs/net/aspose.slides/ihyperlinkqueries/methods/removeallhyperlinks)

## **Často kladené otázky**

**Jak mohu vytvořit vnitřní navigaci nejen na snímek, ale i na „sekci“ nebo první snímek sekce?**

Sekce v PowerPointu jsou seskupení snímků; navigace technicky cílí na konkrétní snímek. Pro „navigaci do sekce“ obvykle odkazujete na její první snímek.

**Mohu připojit hypertextový odkaz k prvkům hlavní šablony, aby fungoval na všech snímcích?**

Ano. Prvky hlavní šablony a rozvržení podporují hypertextové odkazy. Tyto odkazy se zobrazí na podřízených snímcích a jsou klikatelné během prezentace.

**Zůstanou hypertextové odkazy zachovány při exportu do PDF, HTML, obrázků nebo videa?**

V [PDF](/slides/cs/net/convert-powerpoint-to-pdf/) a [HTML](/slides/cs/net/convert-powerpoint-to-html/) ano—odkazy jsou obecně zachovány. Při exportu do [obrázků](/slides/cs/net/convert-powerpoint-to-png/) a [videí](/slides/cs/net/convert-powerpoint-to-video/) klikatelnost nepřetrvá kvůli povaze těchto formátů (rastrální snímky/video nepodporují hypertextové odkazy).
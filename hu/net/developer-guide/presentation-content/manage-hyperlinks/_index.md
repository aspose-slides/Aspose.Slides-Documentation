---
title: Prezentációs hiperhivatkozások kezelése .NET-ben
linktitle: Hiperhivatkozás kezelése
type: docs
weight: 20
url: /hu/net/manage-hyperlinks/
keywords:
  - URL hozzáadása
  - hiperhivatkozás hozzáadása
  - hiperhivatkozás létrehozása
  - hiperhivatkozás formázása
  - hiperhivatkozás eltávolítása
  - hiperhivatkozás frissítése
  - szöveges hiperhivatkozás
  - diára mutató hiperhivatkozás
  - alakzatra mutató hiperhivatkozás
  - képre mutató hiperhivatkozás
  - videóra mutató hiperhivatkozás
  - módosítható hiperhivatkozás
  - PowerPoint
  - OpenDocument
  - prezentáció
  - .NET
  - C#
  - Aspose.Slides
description: "Könnyedén kezelheti a hiperhivatkozásokat PowerPoint és OpenDocument prezentációkban az Aspose.Slides for .NET segítségével — növelje az interaktivitást és a munkafolyamatot percek alatt."
---
## **Bevezetés**

A hiperhivatkozás egy hivatkozás egy objektumra, adatra vagy egy helyre valamiben. Ezek gyakori hiperhivatkozások PowerPoint‑prezentációkban:

* Weboldalakra mutató hivatkozások szövegekben, alakzatokban vagy médiában
* Diára mutató hivatkozások

Az Aspose.Slides for .NET lehetővé teszi, hogy számos feladatot végezzen el a prezentációkban lévő hiperhivatkozásokkal kapcsolatban. 

{{% alert color="primary" %}} 
Érdemes kipróbálni az Aspose egyszerű, ingyenes online PowerPoint szerkesztőt.[free online PowerPoint editor.](https://products.aspose.app/slides/hu/editor)
{{% /alert %}} 

## **URL hiperhivatkozások hozzáadása**

### **URL hiperhivatkozások hozzáadása szöveghez**

Ez a C# kód megmutatja, hogyan adhat hozzá egy weboldal hiperhivatkozást egy szöveghez:

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

### **URL hiperhivatkozások hozzáadása alakzatokhoz vagy keretekhez**

Ez a C# minta kód megmutatja, hogyan adhat hozzá egy weboldal hiperhivatkozást egy alakzathoz:

```c#
using (Presentation pres = new Presentation())
{
    IShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 600, 50);
    
    shape.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
    shape.HyperlinkClick.Tooltip = "More than 70% Fortune 100 companies trust Aspose APIs";

    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```

### **URL hiperhivatkozások hozzáadása médiához**

Az Aspose.Slides lehetővé teszi, hogy hiperhivatkozásokat adjon képekhez, hang‑ és videófájlokhoz. 

Ez a példa kód megmutatja, hogyan adjon hiperhivatkozást egy **képre**:

```c#
using (Presentation pres = new Presentation())
{
    // Képet ad a prezentációhoz
    IPPImage image = pres.Images.AddImage(File.ReadAllBytes("image.png"));
    // Képkeretet hoz létre az 1. dián a korábban hozzáadott kép alapján
    IPictureFrame pictureFrame = pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);

    pictureFrame.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
    pictureFrame.HyperlinkClick.Tooltip = "More than 70% Fortune 100 companies trust Aspose APIs";

    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```

Ez a példa kód megmutatja, hogyan adjon hiperhivatkozást egy **hangfájlra**:

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

Ez a példa kód megmutatja, hogyan adjon hiperhivatkozást egy **videóra**:

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
Érdemes megnézni a *[Manage OLE](https://docs.aspose.com/slides/hu/net/manage-ole/)*.
{{% /alert %}}

## **Hiperhivatkozások használata tartalomjegyzék létrehozásához**

Mivel a hiperhivatkozások lehetővé teszik hivatkozások hozzáadását objektumokra vagy helyekre, használhatja őket tartalomjegyzék létrehozásához. 

Ez a minta kód megmutatja, hogyan hozhat létre egy tartalomjegyzéket hiperhivatkozásokkal:

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

## **Hiperhivatkozások formázása**

### **Szín**

A [ColorSource](https://reference.aspose.com/slides/hu/net/aspose.slides/ihyperlink/properties/colorsource) tulajdonsággal a [IHyperlink](https://reference.aspose.com/slides/hu/net/aspose.slides/ihyperlink) felületén beállíthatja a hiperhivatkozások színét, és lekérheti a színinformációt is. A funkciót először a PowerPoint 2019‑ben vezették be, ezért a tulajdonságra vonatkozó változtatások nem alkalmazhatók a régebbi PowerPoint‑verziókra.

Ez a példa kód bemutat egy műveletet, ahol különböző színű hiperhivatkozásokat adtak hozzá ugyanahhoz a diához:

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

### **Hang**

Az Aspose.Slides ezeket a tulajdonságokat biztosítja, hogy hangsúlyozza a hiperhivatkozást egy hanggal:
- [IHyperlink.Sound](https://reference.aspose.com/slides/hu/net/aspose.slides/ihyperlink/properties/sound) 
- [IHyperlink.StopSoundOnClick](https://reference.aspose.com/slides/hu/net/aspose.slides/ihyperlink/properties/stopsoundonclick)

#### **Hiperhivatkozás hangjának hozzáadása**

Ez a C# kód megmutatja, hogyan állíthat be egy olyan hiperhivatkozást, amely hangot lejátszik, és egy másik hiperhivatkozással állítja le:

```c#
using (Presentation pres = new Presentation())
{
	// Új hangot ad a prezentáció hanggyűjteményéhez
	IAudio playSound = pres.Audios.AddAudio(File.ReadAllBytes("sampleaudio.wav"));

	ISlide firstSlide = pres.Slides[0];

	// Új alakzatot ad hozzá a következő diára mutató hiperhivatkozással
	IShape firstShape = firstSlide.Shapes.AddAutoShape(ShapeType.SoundButton, 100, 100, 100, 50);
	firstShape.HyperlinkClick = Hyperlink.NextSlide;

	// Ellenőrzi a hiperhivatkozást a "Nincs hang" esetére
	if (!firstShape.HyperlinkClick.StopSoundOnClick && firstShape.HyperlinkClick.Sound == null)
	{
		// Beállítja a hangot lejátszó hiperhivatkozást
		firstShape.HyperlinkClick.Sound = playSound;
	}

	// Üres diát ad hozzá 
	ISlide secondSlide = pres.Slides.AddEmptySlide(firstSlide.LayoutSlide);

	// Új alakzatot ad hozzá a NoAction hiperhivatkozással
	IShape secondShape = secondSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 100, 50);
	secondShape.HyperlinkClick = Hyperlink.NoAction;

	// Beállítja a hiperhivatkozás "Előző hang leállítása" jelzőjét
	secondShape.HyperlinkClick.StopSoundOnClick = true;

	pres.Save("hyperlink-sound.pptx", SaveFormat.Pptx);
}
```

#### **Hiperhivatkozás hangjának kinyerése**

Ez a C# kód megmutatja, hogyan nyerheti ki egy hiperhivatkozásban használt hangot:

```c#
using (Presentation pres = new Presentation("hyperlink-sound.pptx"))
{
	ISlide firstSlide = pres.Slides[0];

	// Lekéri az első alakzat hiperhivatkozását
	IHyperlink link = firstSlide.Shapes[0].HyperlinkClick;

	if (link.Sound != null)
	{
		// Kinyeri a hiperhivatkozás hangját bájt tömbbe
		byte[] audioData = link.Sound.BinaryData;
	}
}
```

## **Hiperhivatkozások eltávolítása a prezentációkból**

### **Hiperhivatkozások eltávolítása szövegből**

Ez a C# kód megmutatja, hogyan távolíthatja el a hiperhivatkozást egy szövegből egy prezentációs dián:

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

### **Hiperhivatkozások eltávolítása alakzatokból vagy keretekből**

Ez a C# kód megmutatja, hogyan távolíthatja el a hiperhivatkozást egy alakzatról egy prezentációs dián: 

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

## **Módosítható hiperhivatkozás**

A [Hyperlink](https://reference.aspose.com/slides/hu/net/aspose.slides/hyperlink) osztály módosítható. Ezzel az osztállyal megváltoztathatja az alábbi tulajdonságok értékét:

- [IHyperlink.TargetFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/ihyperlink/properties/targetframe)
- [IHyperlink.Tooltip](https://reference.aspose.com/slides/hu/net/aspose.slides/ihyperlink/properties/tooltip)
- [IHyperlink.History](https://reference.aspose.com/slides/hu/net/aspose.slides/ihyperlink/properties/history)
- [IHyperlink.HighlightClick](https://reference.aspose.com/slides/hu/net/aspose.slides/ihyperlink/properties/highlightclick)

A kódrészlet megmutatja, hogyan adjon hiperhivatkozást egy diára, és később szerkessze a tooltip‑jét:

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

## **Támogatott tulajdonságok az IHyperlinkQueries‑ben**

Hozzáférhet az IHyperlinkQueries‑hez egy prezentációból, diából vagy szövegkeretből, amelyhez a hiperhivatkozás definiálva van. 

- [IPresentation.HyperlinkQueries](https://reference.aspose.com/slides/hu/net/aspose.slides/ipresentation/properties/hyperlinkqueries)
- [IBaseSlide.HyperlinkQueries](https://reference.aspose.com/slides/hu/net/aspose.slides/ibaseslide/properties/hyperlinkqueries)
- [ITextFrame.HyperlinkQueries](https://reference.aspose.com/slides/hu/net/aspose.slides/itextframe/properties/hyperlinkqueries)

Az IHyperlinkQueries osztály támogatja ezeket a metódusokat és tulajdonságokat: 

- [IHyperlinkQueries.GetHyperlinkClicks();](https://reference.aspose.com/slides/hu/net/aspose.slides/ihyperlinkqueries/methods/gethyperlinkclicks)
- [IHyperlinkQueries.GetHyperlinkMouseOvers();](https://reference.aspose.com/slides/hu/net/aspose.slides/ihyperlinkqueries/methods/gethyperlinkmouseovers)
- [IHyperlinkQueries.GetAnyHyperlinks();](https://reference.aspose.com/slides/hu/net/aspose.slides/ihyperlinkqueries/methods/getanyhyperlinks)
- [IHyperlinkQueries.RemoveAllHyperlinks();](https://reference.aspose.com/slides/hu/net/aspose.slides/ihyperlinkqueries/methods/removeallhyperlinks)

## **GYIK**

**Hogyan hozhatok létre belső navigációt nem csak egy diára, hanem egy „szakaszra” vagy egy szakasz első diájára?**

A PowerPoint‑ban a szakaszok a diákat csoportosítják; a navigáció technikailag egy konkrét diára irányul. „Szakaszra navigáláshoz” általában az első diájára mutató hivatkozást kell létrehozni.

**Csatolhatok hiperhivatkozást a mesterdia elemeihez, hogy minden dián működjön?**

Igen. A mesterdia és elrendezés elemei támogatják a hiperhivatkozásokat. Az ilyen hivatkozások megjelennek a gyermekdiákon, és kattinthatóak a diavetítés során.

**Megmaradnak a hiperhivatkozások PDF, HTML, képek vagy videó exportálásakor?**

A [PDF](/slides/hu/net/convert-powerpoint-to-pdf/) és [HTML](/slides/hu/net/convert-powerpoint-to-html/) esetén igen – a linkek általában megmaradnak. A [képek](/slides/hu/net/convert-powerpoint-to-png/) és [videó](/slides/hu/net/convert-powerpoint-to-video/) exportálásakor a kattinthatóság nem marad meg, mivel ezek a formátumok (raszteres képkockák/videó) nem támogatják a hiperhivatkozásokat.
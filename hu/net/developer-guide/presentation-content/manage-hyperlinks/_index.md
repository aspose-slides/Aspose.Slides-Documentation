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

A hiperhivatkozás egy objektumra, adatra vagy helyre mutató hivatkozás. Ezek a leggyakoribb hiperhivatkozások a PowerPoint‑prezentációkban:

* Weboldalakra mutató hivatkozások szövegekben, alakzatokban vagy médiában
* Diákra mutató hivatkozások

Az Aspose.Slides for .NET lehetővé teszi számos, a hiperhivatkozásokkal kapcsolatos feladat végrehajtását a prezentációkban. 

{{% alert color="info" %}} 

Érdemes megnézni az Aspose egyszerű, [ingyenes online PowerPoint szerkesztőjét.](https://products.aspose.app/slides/hu/editor)

{{% /alert %}} 

## **URL‑hivatkozások hozzáadása**

### **URL‑hivatkozások hozzáadása szöveghez**

Ez a C# kód megmutatja, hogyan adhatunk weboldal‑hivatkozást egy szöveghez:

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

### **URL‑hivatkozások hozzáadása alakzatokhoz vagy keretekhez**

Ez a C# példa megmutatja, hogyan adhatunk weboldal‑hivatkozást egy alakzathoz:

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

### **URL‑hivatkozások hozzáadása médiához**

Az Aspose.Slides lehetővé teszi hivatkozások hozzáadását képekhez, hang- és videofájlokhoz. 

Ez a példa megmutatja, hogyan adhatunk hivatkozást egy **képre**:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

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

Ez a példa megmutatja, hogyan adhatunk hivatkozást egy **hangfájlra**:

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

Ez a példa megmutatja, hogyan adhatunk hivatkozást egy **videóra**:

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

Érdemes megnézni a *[OLE kezelése](https://docs.aspose.com/slides/hu/net/manage-ole/)* oldalt.

{{% /alert %}}


## **Hiperhivatkozások használata tartalomjegyzék létrehozásához**

Mivel a hiperhivatkozások lehetővé teszik objektumokra vagy helyekre mutató hivatkozások hozzáadását, felhasználhatók tartalomjegyzék létrehozására is. 

Ez a példa megmutatja, hogyan hozhatunk létre tartalomjegyzéket hiperhivatkozásokkal:

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

## **Hiperhivatkozások formázása**

### **Szín**

A [IHyperlink](https://reference.aspose.com/slides/hu/net/aspose.slides/ihyperlink) interfész [ColorSource](https://reference.aspose.com/slides/hu/net/aspose.slides/ihyperlink/properties/colorsource) tulajdonságával beállítható a hiperhivatkozások színe, valamint lekérdezhető a színinformáció. A funkció először a PowerPoint 2019‑ben jelent meg, így a tulajdonságra vonatkozó módosítások nem alkalmazhatók a régebbi PowerPoint‑verziókra.

Ez a példa bemutatja, hogyan adhatunk különböző színű hiperhivatkozásokat ugyanarra a diára:

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
### **Hang**

Az Aspose.Slides a következő tulajdonságokkal teszi lehetővé a hiperhivatkozás hanggal való kiemelését:
- [IHyperlink.Sound](https://reference.aspose.com/slides/hu/net/aspose.slides/ihyperlink/properties/sound) 
- [IHyperlink.StopSoundOnClick](https://reference.aspose.com/slides/hu/net/aspose.slides/ihyperlink/properties/stopsoundonclick)

#### **Hiperhivatkozás hangjának hozzáadása**

Ez a C# kód megmutatja, hogyan állítható be egy hangot lejátékozó hiperhivatkozás, illetve hogyan állítható le egy másik hiperhivatkozással:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
	// Új hangot ad a prezentáció hanggyűjteményéhez
	IAudio playSound = pres.Audios.AddAudio(File.ReadAllBytes("sampleaudio.wav"));

	ISlide firstSlide = pres.Slides[0];

	// Új alakzatot ad hozzá a hiperhivatkozással a következő diára
	IShape firstShape = firstSlide.Shapes.AddAutoShape(ShapeType.SoundButton, 100, 100, 100, 50);
	firstShape.HyperlinkClick = Hyperlink.NextSlide;

	// Ellenőrzi a hiperhivatkozást "Nincs hang"
	if (!firstShape.HyperlinkClick.StopSoundOnClick && firstShape.HyperlinkClick.Sound == null)
	{
		// Beállítja a hangot lejátékozó hiperhivatkozást
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

Ez a C# kód megmutatja, hogyan nyerhető ki egy hiperhivatkozáshoz rendelt hang:

```c#
using Aspose.Slides;

using (Presentation pres = new Presentation("hyperlink-sound.pptx"))
{
	ISlide firstSlide = pres.Slides[0];

	// Lekéri az első alakzat hiperhivatkozását
	IHyperlink link = firstSlide.Shapes[0].HyperlinkClick;

	if (link.Sound != null)
	{
		// Kivonja a hiperhivatkozás hangját bájt tömbbe
		byte[] audioData = link.Sound.BinaryData;
	}
}
```

## **Hiperhivatkozások eltávolítása a prezentációkból**

### **Hiperhivatkozások eltávolítása szövegből**

Ez a C# kód megmutatja, hogyan távolítható el egy hiperhivatkozás egy szövegből a prezentációs dián:

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

### **Hiperhivatkozások eltávolítása alakzatokból vagy keretekből**

Ez a C# kód megmutatja, hogyan távolítható el egy hiperhivatkozás egy alakzatról a prezentációs dián: 

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

## **Módosítható hiperhivatkozás**

A [Hyperlink](https://reference.aspose.com/slides/hu/net/aspose.slides/hyperlink) osztály módosítható. Ezzel az osztállyal megváltoztatható a következő tulajdonságok értéke:

- [IHyperlink.TargetFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/ihyperlink/properties/targetframe)
- [IHyperlink.Tooltip](https://reference.aspose.com/slides/hu/net/aspose.slides/ihyperlink/properties/tooltip)
- [IHyperlink.History](https://reference.aspose.com/slides/hu/net/aspose.slides/ihyperlink/properties/history)
- [IHyperlink.HighlightClick](https://reference.aspose.com/slides/hu/net/aspose.slides/ihyperlink/properties/highlightclick)

Ez a kódrészlet megmutatja, hogyan adhatunk hiperhivatkozást egy diára, majd később módosíthatjuk a felbukkanó szöveget (tooltip):

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

## **Támogatott tulajdonságok az IHyperlinkQueries‑ben**

Az IHyperlinkQueries‑hez hozzáférhetünk egy prezentációból, diából vagy szövegkeretből, amelyhez a hiperhivatkozás definiálva van. 

- [IPresentation.HyperlinkQueries](https://reference.aspose.com/slides/hu/net/aspose.slides/ipresentation/properties/hyperlinkqueries)
- [IBaseSlide.HyperlinkQueries](https://reference.aspose.com/slides/hu/net/aspose.slides/ibaseslide/properties/hyperlinkqueries)
- [ITextFrame.HyperlinkQueries](https://reference.aspose.com/slides/hu/net/aspose.slides/itextframe/properties/hyperlinkqueries)

Az IHyperlinkQueries osztály a következő metódusokat és tulajdonságokat támogatja: 

- [IHyperlinkQueries.GetHyperlinkClicks();](https://reference.aspose.com/slides/hu/net/aspose.slides/ihyperlinkqueries/methods/gethyperlinkclicks)
- [IHyperlinkQueries.GetHyperlinkMouseOvers();](https://reference.aspose.com/slides/hu/net/aspose.slides/ihyperlinkqueries/methods/gethyperlinkmouseovers)
- [IHyperlinkQueries.GetAnyHyperlinks();](https://reference.aspose.com/slides/hu/net/aspose.slides/ihyperlinkqueries/methods/getanyhyperlinks)
- [IHyperlinkQueries.RemoveAllHyperlinks();](https://reference.aspose.com/slides/hu/net/aspose.slides/ihyperlinkqueries/methods/removeallhyperlinks)

## **GYIK**

### Hogyan hozhatok létre belső navigációt, nem csak egy diára, hanem egy „szakaszra” vagy egy szakasz első diájára?

A PowerPoint‑szakaszok a diák csoportosításai; a navigáció technikailag egy konkrét diát céloz meg. Egy „szakaszra” navigáláshoz általában a szakasz első diájára kell hivatkozni.

### Csatolhatok-e hiperhivatkozást a mesterdia‑diák elemeire, hogy az összes dián működjön?

Igen. A mesterdia‑dia és a sablon elemei támogatják a hiperhivatkozásokat. Az ilyen linkek megjelennek a gyermekdiákon, és a bemutató során kattinthatók.

### Megmaradnak‑e a hiperhivatkozások PDF, HTML, képek vagy videó exportálása esetén?

A [PDF](/slides/hu/net/convert-powerpoint-to-pdf/) és a [HTML](/slides/hu/net/convert-powerpoint-to-html/) esetén igen – a linkek általában megmaradnak. Képek [images](/slides/hu/net/convert-powerpoint-to-png/) és videó [video](/slides/hu/net/convert-powerpoint-to-video/) exportálása során a kattinthatóság nem marad meg, mivel ezek a formátumok (raster képkockák/videó) nem támogatják a hiperhivatkozásokat.
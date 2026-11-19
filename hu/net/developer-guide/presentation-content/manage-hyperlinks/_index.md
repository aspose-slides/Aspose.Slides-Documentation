---
title: Manage Presentation Hyperlinks in .NET
linktitle: Manage Hyperlinks
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
- dia hiperhivatkozás
- alakzat hiperhivatkozás
- kép hiperhivatkozás
- videó hiperhivatkozás
- módosítható hiperhivatkozás
- PowerPoint
- OpenDocument
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Hiperhivatkozások hozzáadása, formázása, frissítése és eltávolítása PowerPoint és OpenDocument prezentációkban az Aspose.Slides for .NET segítségével, C# példákkal."
---
## **Bevezetés**

Egy hiperhivatkozás a prezentáció tartalmát kapcsolja össze egy weboldallal vagy a prezentáción belüli helyszínnel. A PowerPointban a hiperhivatkozások általában két célra szolgálnak:

* Weboldal megnyitása szövegből, alakzatból vagy média keretből.
* Ugrás egy másik diára, például egy tartalomjegyzékből.

Az Aspose.Slides for .NET lehetővé teszi ezeknek a linkeknek a hozzáadását, megjelenésük és hangjuk vezérlését, tulajdonságaik frissítését és eltávolítását. Az alábbi példák bemutatják, hogyan dolgozhatunk hiperhivatkozásokkal egyedi elemeknél, illetve hogyan érhetjük el őket a prezentáció, dia vagy szövegkeret szintjén.

{{% alert color="info" title="Note" %}}
Szerkesztheti a prezentációkat a [ingyenes online Aspose PowerPoint szerkesztő](https://products.aspose.app/slides/editor) segítségével is.
{{% /alert %}}

## **URL-hyperlinkek hozzáadása**

Webcím (URL) hozzárendelhető szöveghez, alakzathoz vagy média kerethez. A hiperhivatkozásnak a hozzárendelésére szolgáló elem határozza meg a kattintható területet: egy szövegrész a kiválasztott szöveget teszi kattinthatóvá, míg egy alakzat vagy keret az egész diáobjektumot linkeli.

A relatív hiperhivatkozásokat tartalmazó prezentációk esetén tekintse meg a [Hyperlink Base kezelése](/slides/hu/net/presentation-properties/#manage-the-hyperlink-base) oldalt a dokumentumszintű alap beolvasásához, módosításához vagy törléséhez.

### **URL-hyperlinkek hozzáadása szöveghez**

A szöveget egy weboldalra linkelni a szövegrész **[Hyperlink](https://reference.aspose.com/slides/net/aspose.slides/hyperlink/)** tulajdonságának **[HyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/portionformat/hyperlinkclick/)** beállításával lehet, ahogyan az alább látható. Csak ez a szövegrész lesz kattintható.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var textShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, false);
textShape.AddTextFrame("Aspose: File Format APIs");
var portionFormat = textShape.TextFrame.Paragraphs[0].Portions[0].PortionFormat;
portionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
portionFormat.HyperlinkClick.Tooltip = "Explore Aspose file format APIs";
portionFormat.FontHeight = 32;

presentation.Save("presentation-out.pptx", SaveFormat.Pptx);
```

### **URL-hyperlinkek hozzáadása alakzatokhoz és média keretekhez**

A téglalap **[HyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/shape/hyperlinkclick/)** tulajdonságának egy URL-re való beállítása az egész területet kattinthatóvá teszi. A **[Tooltip](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/tooltip/)** tippet jelenít meg a felhasználó számára, amikor az egeret a téglalap fölé viszi. Ugyanazok a tulajdonságok vonatkoznak kép-, hang- és videókeretekre is.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 600, 50);

shape.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
shape.HyperlinkClick.Tooltip = "Explore Aspose file format APIs";

presentation.Save("presentation-out.pptx", SaveFormat.Pptx);
```

## **Hiperhivatkozások használata tartalomjegyzék létrehozásához**

Belső hiperhivatkozások lehetővé teszik, hogy az olvasó a tartalomjegyzékből konkrét diára ugorjon. Az alábbi példa a **[SetInternalHyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/setinternalhyperlinkclick/)** metódust használja, hogy az első dia „Page 2” szövegét a második diára linkelje.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var firstSlide = presentation.Slides[0];
var secondSlide = presentation.Slides.AddEmptySlide(firstSlide.LayoutSlide);

var tableOfContents = firstSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 300, 100);
tableOfContents.FillFormat.FillType = FillType.NoFill;
tableOfContents.LineFormat.FillFormat.FillType = FillType.NoFill;
tableOfContents.TextFrame.Paragraphs.Clear();

var paragraph = new Paragraph();
paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
paragraph.Text = "Title of slide 2 .......... ";

var linkPortion = new Portion();
linkPortion.Text = "Page 2";
linkPortion.PortionFormat.HyperlinkManager.SetInternalHyperlinkClick(secondSlide);

paragraph.Portions.Add(linkPortion);
tableOfContents.TextFrame.Paragraphs.Add(paragraph);

presentation.Save("link_to_slide.pptx", SaveFormat.Pptx);
```

## **Hiperhivatkozások formázása**

Megváltoztathatja a linkelt szöveg színét, lejátszhat vagy leállíthat hangot, amikor az olvasó aktiválja a linket, és beállíthatja a lebegő tippet is.

### **Szín**

Az **[IHyperlink](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/)** **[ColorSource](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/colorsource/)** tulajdonsága határozza meg, hogy a hiperhivatkozás a prezentáció hiperlink színét vagy a szövegrész formázását használja. Egy egyéni szövegszín alkalmazásához válassza a **[HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/net/aspose.slides/hyperlinkcolorsource/)** értéket, és állítsa be a rész kitöltőszínét. Ez a funkció a PowerPoint 2019‑ben jelent meg; régebbi verziók nem alkalmazzák ezt a beállítást.

Ebben a példában a **[ColorSource](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/colorsource/)** beállítása az első linken pirosra változtatja a szöveg színét. A második link a prezentáció hiperlink színét használja.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var coloredShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 450, 50, false);
coloredShape.AddTextFrame("This hyperlink uses a custom color.");
var coloredPortionFormat = coloredShape.TextFrame.Paragraphs[0].Portions[0].PortionFormat;
coloredPortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
coloredPortionFormat.HyperlinkClick.ColorSource = HyperlinkColorSource.PortionFormat;
coloredPortionFormat.FillFormat.FillType = FillType.Solid;
coloredPortionFormat.FillFormat.SolidFillColor.Color = Color.Red;

var defaultShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 450, 50, false);
defaultShape.AddTextFrame("This hyperlink uses the default color.");
defaultShape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com/");

presentation.Save("presentation-out-hyperlink.pptx", SaveFormat.Pptx);
```

### **Hang**

Egy hiperhivatkozás lejátszhat hangot aktiváláskor, vagy leállíthat már játszott hangot. A következő tulajdonságokkal állíthatók be ezek a viselkedések:

- **[IHyperlink.Sound](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/sound/)** határozza meg a hiperlinkhez társított hangot.
- **[IHyperlink.StopSoundOnClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/stopsoundonclick/)** szabályozza, hogy a hiperlink aktiválása megállítsa‑e az előző hangot.

#### **Hiperlink hang hozzáadása**

Az első dia gombja a **[Sound](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/sound/)** használatával egy WAV‑fájlból származó hangot játszik le, amikor az olvasó rákattint a továbblépéshez. A második dia egy külön gombja a **[StopSoundOnClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/stopsoundonclick/)** segítségével leállítja a lejátszást, és a felhasználót azon a dián tartja.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var audioData = File.ReadAllBytes("sampleaudio.wav");
var hyperlinkSound = presentation.Audios.AddAudio(audioData);

var firstSlide = presentation.Slides[0];

var playButton = firstSlide.Shapes.AddAutoShape(ShapeType.SoundButton, 100, 100, 100, 50);
playButton.HyperlinkClick = Hyperlink.NextSlide;

if (!playButton.HyperlinkClick.StopSoundOnClick && playButton.HyperlinkClick.Sound == null)
{
    playButton.HyperlinkClick.Sound = hyperlinkSound;
}

var secondSlide = presentation.Slides.AddEmptySlide(firstSlide.LayoutSlide);

var stopButton = secondSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 100, 50);
stopButton.HyperlinkClick = Hyperlink.NoAction;

stopButton.HyperlinkClick.StopSoundOnClick = true;

presentation.Save("hyperlink-sound.pptx", SaveFormat.Pptx);
```

#### **Hiperlink hang kinyerése**

Az alábbi példa megnyitja a fent létrehozott prezentációt, és a **[Sound](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/sound/)** és **[BinaryData](https://reference.aspose.com/slides/net/aspose.slides/iaudio/binarydata/)** segítségével a első alakzat hiperlink hangját memóriába olvassa.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("hyperlink-sound.pptx");

if (presentation.Slides.Count > 0 && presentation.Slides[0].Shapes.Count > 0)
{
    var hyperlink = presentation.Slides[0].Shapes[0].HyperlinkClick;
    var sound = hyperlink?.Sound;
    if (sound != null)
    {
        var audioData = sound.BinaryData;
        Console.WriteLine($"Extracted {audioData.Length} bytes of hyperlink audio.");
    }
    else
    {
        Console.WriteLine("The first shape has no hyperlink sound.");
    }
}
else
{
    Console.WriteLine("The presentation has no first slide or shape to inspect.");
}
```

### **Tooltip és interakciós beállítások**

A hiperlinket szöveghez vagy alakzathoz hozzárendelve a következő **[IHyperlink](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/)** tulajdonságok frissíthetők:

- **[Tooltip](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/tooltip/)** a megjelenítendő tippet adja a linkhez.
- **[TargetFrame](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/targetframe/)** a célkeretet határozza meg egy anyag HTML‑keretstruktúrában, ha releváns.
- **[History](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/history/)** szabályozza, hogy a link aktiválása hozzáadja‑e a célt a megtekintett hyperlinkek listájához.
- **[HighlightClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/highlightclick/)** szabályozza, hogy a hiperlink kattintáskor ki legyen‑e emelve.

## **Hiperlinkek eltávolítása a prezentációkból**

A **[GetAnyHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/getanyhyperlinks/)** használatával összegyűjthetők a hyperlink konténerek, beleértve a szövegrész‑linkeket is, mielőtt módosítaná őket. Az alábbi példa mindkét aktiválási típust eltávolítja az első diáról. Egyes típusok eltávolításához hívja csak a **[RemoveHyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/removehyperlinkclick/)** vagy a **[RemoveHyperlinkMouseOver](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/removehyperlinkmouseover/)** metódust; a kattintási művelet eltávolítása nem távolítja el az egér‑over megfelelőjét.

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("pres.pptx");

if (presentation.Slides.Count > 0)
{
    var containers = presentation.Slides[0].HyperlinkQueries.GetAnyHyperlinks().ToList();
    foreach (var container in containers)
    {
        container.HyperlinkManager.RemoveHyperlinkClick();
        container.HyperlinkManager.RemoveHyperlinkMouseOver();
    }
    presentation.Save("pres-removed-hyperlinks.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("The presentation has no slides to process.");
}
```

Feltétel nélküli eltávolításhoz a **[RemoveAllHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/removeallhyperlinks/)** mindkét aktiválási típust egy hívással törli a kiválasztott hatókörben. Szelektív takarítás és a mester‑, elrendezés‑ és jegyzet‑diák lefedéséhez lásd a **[Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks)** részt.

### **SmartArt szöveg cseréje előtt a hyperlinkek törlése**

Amikor egy meglévő SmartArt‑csomópontban lévő bekezdést cserél, a szövegrészek törlése régi hyperlinket hagyhat működésben. A bekezdést a **[ISmartArtNode.TextFrame](https://reference.aspose.com/slides/net/aspose.slides.smartart/ismartartnode/textframe/)**‑en keresztül szerezze meg. A részek törlése előtt hívja a **[RemoveAllHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/removeallhyperlinks/)**‑t a csomópont alakzatának **[HyperlinkQueries](https://reference.aspose.com/slides/net/aspose.slides/itextframe/hyperlinkqueries/)**‑án keresztül. Ez a módszer az adott keret minden hyperlinket eltávolít, beleértve a többi bekezdés linkjeit is.

A példa azt feltételezi, hogy az első dia harmadik alakzata egy SmartArt‑grafika. A negyedik csomópont első bekezdését cseréli. Ebben a prezentációban a csomópont első alakzata jeleníti meg azt a bekezdést.

Mindkét részlet hozzáadása után a példa a **[GetEffective](https://reference.aspose.com/slides/net/aspose.slides/iportionformat/geteffective/)**‑el olvassa a tényleges formázást. A tényleges **[HyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/iportionformateffectivedata/hyperlinkclick/)** tulajdonság az első részhez új hyperlinket ad vissza, a másodikhoz pedig `null`‑t.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.SmartArt;

using var presentation = new Presentation("SmartArtHyperlink.pptx");
var slide = presentation.Slides[0];

var smartArt = (ISmartArt)slide.Shapes[2];
var node = smartArt.AllNodes[3];
var paragraph = node.TextFrame.Paragraphs[0];

node.Shapes[0].TextFrame.HyperlinkQueries.RemoveAllHyperlinks();
paragraph.Portions.Clear();

var link = new Portion("New reference");
link.PortionFormat.HyperlinkClick = new Hyperlink("https://example.com/new");
paragraph.Portions.Add(link);
var text = new Portion(" (updated)");
paragraph.Portions.Add(text);

Console.WriteLine(link.PortionFormat.GetEffective().HyperlinkClick.ExternalUrl); // https://example.com/new
Console.WriteLine(text.PortionFormat.GetEffective().HyperlinkClick?.ToString() ?? "null"); // null
```

## **Teljes hyperlink leltár építése**

A prezentáció közzététele előtt érdemes feljegyezni az interaktív műveleteket és a webes linkeket is. A **[GetAnyHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/getanyhyperlinks/)** **[IHyperlinkContainer](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkcontainer/)** objektumokat ad vissza, nem egy egyszerű URL‑lista. Vizsgálja meg a **[HyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkcontainer/hyperlinkclick/)** és a **[HyperlinkMouseOver](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkcontainer/hyperlinkmouseover/)** tulajdonságokat minden konténeren. Ezek függetlenek: egy konténer mindkét műveletet tartalmazhatja, így egy teljes jelentés akár két sort is igényel egy konténerhez.

Csak alakzati szintű hyperlinkek keresése kihagyhatja a szövegrészekhez csatolt linkeket. Használja a megfelelő hatókört, és őrizze meg a visszakapott konténereket, hogy később frissíthesse vagy eltávolíthassa a műveleteket.

### **Prezentáció, dia és szövegkeret hatókörök lekérdezése**

Az **[IHyperlinkQueries](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/)** interfész elérhető a **[IPresentation.HyperlinkQueries](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/hyperlinkqueries/)**, **[IBaseSlide.HyperlinkQueries](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/hyperlinkqueries/)** és **[ITextFrame.HyperlinkQueries](https://reference.aspose.com/slides/net/aspose.slides/itextframe/hyperlinkqueries/)**‑on keresztül. Minden hatókör ugyanazokat a lekérdezéseket támogatja:

- **[GetHyperlinkClicks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/gethyperlinkclicks/)** kattintási művelettel rendelkező konténereket ad vissza.
- **[GetHyperlinkMouseOvers](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/gethyperlinkmouseovers/)** egér‑over művelettel rendelkező konténereket ad vissza.
- **[GetAnyHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/getanyhyperlinks/)** bármely vagy mindkét művelettel rendelkező konténereket ad vissza.

Ez a példa kattintási és egér‑over műveleteket rendel hozzá egy alakzathoz és annak szövegéhez, valamint egy makró‑műveletet egy külön gombhoz. Összehasonlítja a **[GetAnyHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/getanyhyperlinks/)** által visszaadott konténereket az egyes aktiválási típusok számlálásaival. Egy szövegkeret‑lekérdezés csak a szövegben található linkeket számlálja. A körülvevő alakzat saját műveletei a dia‑ és prezentáció‑lekérdezésekben is megjelennek.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var destination = presentation.Slides.AddEmptySlide(slide.LayoutSlide);
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 60);
shape.TextFrame.Text = "Click the text to go to slide 2";
shape.HyperlinkManager.SetExternalHyperlinkClick("https://example.com/");
shape.HyperlinkClick.Tooltip = "Public website";
shape.HyperlinkManager.SetExternalHyperlinkMouseOver("file:///C:/private/report.xlsx");

var portionFormat = shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat;
portionFormat.HyperlinkManager.SetInternalHyperlinkClick(destination);
portionFormat.HyperlinkManager.SetExternalHyperlinkMouseOver("https://example.com/help");
var macroButton = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 120, 200, 60);
macroButton.HyperlinkManager.SetMacroHyperlinkClick("ReviewPresentation");

PrintCounts("Presentation", presentation.HyperlinkQueries);
PrintCounts("Slide 1", slide.HyperlinkQueries);
PrintCounts("Text frame", shape.TextFrame.HyperlinkQueries);
presentation.Save("hyperlink-audit-input.pptx", SaveFormat.Pptx);

static void PrintCounts(string scope, IHyperlinkQueries queries)
{
    var clickContainers = queries.GetHyperlinkClicks();
    var mouseOverContainers = queries.GetHyperlinkMouseOvers();
    var allContainers = queries.GetAnyHyperlinks();
    Console.WriteLine($"{scope}: click={clickContainers.Count}, mouse-over={mouseOverContainers.Count}, any={allContainers.Count}");
}
```

Ebben a példában a prezentáció‑ és dia‑lekérdezések egyenként három kattintási konténert, két egér‑over konténert és három “bármely” konténert jeleznek. A szövegkeret‑lekérdezés minden kategóriában egy konténert jelent.

### **Műveletek és célpontok osztályozása**

Használja az **[IHyperlink.ActionType](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/actiontype/)**‑t a művelet értelmezéséhez, mielőtt a célt elemzi. A **[HyperlinkActionType](https://reference.aspose.com/slides/net/aspose.slides/hyperlinkactiontype/)** értékek a webnavigáción túl további lehetőségeket fednek le:

| Értékek | Jelentés egy audit során |
| --- | --- |
| `Hyperlink` | Külső hiperlink; ellenőrizze az URL‑t és annak sémáját. |
| `JumpSpecificSlide` | Belső navigáció egy meghatározott diára. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | Beépített diavetítés‑navigáció, a diavetítés kontextusában értelmezve. |
| `JumpEndShow`, `StartCustomSlideShow` | Az aktuális bemutató befejezése vagy egy egyedi bemutató indítása. |
| `StartMacro` | Makró végrehajtása. |
| `StartProgram` | Program indítása. |
| `OpenFile`, `OpenPresentation` | Fájl vagy másik prezentáció megnyitása; külön ellenőrizze a web‑URL‑ektől. |
| `StartStopMedia` | Média lejátszás indítása vagy leállítása. |
| `NoAction`, `Unknown` | Nincs navigációs művelet, vagy ismeretlen művelet, amely felülvizsgálatot igényel. |

Olvassa ki a külső célpontokat a **[ExternalUrl](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/externalurl/)**‑ból, a belső célpontokat a **[TargetSlide](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/targetslide/)**‑ból. Belső műveletek és beépített parancsok esetén előfordulhat, hogy nincs külső URL; egy üres URL nem jelenti azt, hogy a konténernek nincs művelete. Őrizze meg a **[ExternalUrlOriginal](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/externalurloriginal/)**‑t, ha eltér a normalizált URL‑től, és adja hozzá a **[Tooltip](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/tooltip/)**‑t, ha elérhető.

### **Hiperlinkek jelentése, tisztítása és ellenőrzése**

Ez a .NET 6+ példa megnyitja a korábbi példában létrehozott prezentációt, és minden művelethez egy JSON‑rekordot ír. A **[GetAnyHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/getanyhyperlinks/)**‑t használja a normál diák, mesterek, elrendezések és jegyzetek konténerének összegyűjtéséhez, beleértve a jegyzet‑ és kiadók mestereket is, ha vannak. Referencia‑egyenlőséget használ a konténerek egyszeri számlálásához, alkalmazza az alább leírt szabályt, majd a mentett prezentációt újra megnyitva ellenőrzi mind a kattintási, mind az egér‑over műveleteket.

A jelentés egy 1‑től induló dia‑indexet és a **[SlideId](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/slideid/)**‑t tartalmaz, ahol elérhető. A **[ISlideComponent.Slide](https://reference.aspose.com/slides/net/aspose.slides/islidecomponent/slide/)** adja meg a tulajdonos diát a támogatott konténerekhez. Mesterek, elrendezések és jegyzetek nem rendelkeznek szokásos dia‑indexszel, ezért hatókörük szerint azonosítják őket. Az alakzat‑konténereket és a szövegrész‑formázási konténereket külön jelölik; egyéb konténer‑típusok megtartják a futás‑időbeli típusnevet. Minden konténer kap egy jelentés‑helyi azonosítót, hogy a két művelet összekapcsolható legyen.

Ez a szándékosan szigorú alkalmazási szabály csak abszolút HTTPS‑URL‑eket és érvényes belső dia‑célpontokat engedélyezi. Elutasítja a makrókat, programokat, fájl‑műveleteket, egyéb diavetítés‑parancsokat, ismeretlen műveleteket és egyéb URL‑sémákat. Ezek az elutasítások szabályalkotási döntések, nem az Aspose.Slides biztonsági megítélése. Az HTTPS önmagában nem jelent megbízhatóságot: adjon hozzá host‑fehérlistákat és egyéb ellenőrzéseket az alkalmazásához. Az eredeti és a normalizált külső URL‑ket egyaránt ellenőrzik. A példa metaadatokat ellenőriz anélkül, hogy a linkekre kattintana vagy műveleteket futtatna.

Javításhoz a konténer **[HyperlinkManager](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkcontainer/hyperlinkmanager/)** támogatja a **[SetExternalHyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/setexternalhyperlinkclick/)**, **[RemoveHyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/removehyperlinkclick/)** és **[RemoveHyperlinkMouseOver](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/removehyperlinkmouseover/)** metódusokat. Itt a tiltott külső kattintási linkeket egy fix HTTPS‑céloldalra cserélik; a többi tiltott kattintást és egér‑over műveletet függetlenül eltávolítják. Állítsa a `replaceExternalClicks`‑t `false`‑ra, ha minden szabálysértést el akar távolítani. Válasszon egy alkalmazás‑saját helyettesítő oldalt a kiadás előtt.

A jelentés export‑jelzője egy konzervatív PDF‑ellenőrzési politikát alkalmaz: jelöli az egér‑over műveleteket és minden, az externális link vagy konkrét dia‑ugráson kívül eső esetet potenciálisan nem támogatottként. Ez egy felülvizsgálati tipp, nem képesség‑teszt vagy garancia arra, hogy a nem jelölt linkek megmaradnak az exportkor. A támogatott **[PDF](/slides/hu/net/convert-powerpoint-to-pdf/)** és **[HTML](/slides/hu/net/convert-powerpoint-to-html/)** exportok megőrizhetik a hyperlinkeket, a művelet, az export‑opciók és a nézők függvényében. A raszteres **[images](/slides/hu/net/convert-powerpoint-to-png/)** és **[video](/slides/hu/net/convert-powerpoint-to-video/)** nem őrizhetik meg az interaktív hyperlinkeket; ilyen kimenetek auditálásakor minden műveletet jelölni kell.

```csharp
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Aspose.Slides;
using Aspose.Slides.Export;

const bool replaceExternalClicks = true;
const string replacementUrl = "https://example.com/blocked-link";
using var presentation = new Presentation("hyperlink-audit-input.pptx");
var containers = CollectContainers(presentation);
var rows = new List<object>();

for (var index = 0; index < containers.Count; index++)
{
    var container = containers[index];
    AddRow(container.HyperlinkClick, "click", container, index + 1);
    AddRow(container.HyperlinkMouseOver, "mouse-over", container, index + 1);
}

var jsonOptions = new JsonSerializerOptions { WriteIndented = true };
var json = JsonSerializer.Serialize(rows, jsonOptions);
File.WriteAllText("hyperlink-audit.json", json);

foreach (var container in containers)
{
    var click = container.HyperlinkClick;
    if (PolicyViolation(click) != null)
    {
        if (replaceExternalClicks && click.ActionType == HyperlinkActionType.Hyperlink)
        {
            container.HyperlinkManager.SetExternalHyperlinkClick(replacementUrl);
        }
        else
        {
            container.HyperlinkManager.RemoveHyperlinkClick();
        }
    }
    if (PolicyViolation(container.HyperlinkMouseOver) != null)
    {
        container.HyperlinkManager.RemoveHyperlinkMouseOver();
    }
}

presentation.Save("hyperlink-sanitized.pptx", SaveFormat.Pptx);
using var reopened = new Presentation("hyperlink-sanitized.pptx");
var remainingContainers = CollectContainers(reopened);
var violations = 0;
foreach (var container in remainingContainers)
{
    if (PolicyViolation(container.HyperlinkClick) != null) violations++;
    if (PolicyViolation(container.HyperlinkMouseOver) != null) violations++;
}
Console.WriteLine($"Audit rows: {rows.Count}; prohibited actions after reopening: {violations}");
if (violations != 0)
{
    Console.WriteLine("Verification failed: do not distribute the saved presentation.");
    Environment.ExitCode = 1;
}

void AddRow(IHyperlink? link, string activation, IHyperlinkContainer container, int containerId)
{
    if (link == null) return;
    var ownerSlide = (container as ISlideComponent)?.Slide;
    var targetSlide = link.TargetSlide;
    var violation = PolicyViolation(link);
    var ownerType = container is IShape ? "Shape" : container is IPortionFormat ? "Text portion" : container.GetType().Name;
    var ordinaryAction = link.ActionType == HyperlinkActionType.Hyperlink || link.ActionType == HyperlinkActionType.JumpSpecificSlide;
    rows.Add(new
    {
        ContainerId = containerId,
        SlideIndex = SlideIndex(presentation, ownerSlide),
        SlideId = ownerSlide?.SlideId,
        Scope = ownerSlide?.GetType().Name,
        OwnerType = ownerType,
        Activation = activation,
        ActionType = link.ActionType.ToString(),
        ExternalUrl = link.ExternalUrl,
        TargetSlideIndex = SlideIndex(presentation, targetSlide),
        TargetSlideId = targetSlide?.SlideId,
        Tooltip = link.Tooltip,
        OriginalExternalUrl = link.ExternalUrlOriginal != link.ExternalUrl ? link.ExternalUrlOriginal : null,
        PotentiallyUnsafe = violation != null,
        PolicyViolation = violation,
        TargetExport = "PDF",
        PotentiallyUnsupportedByExport = activation == "mouse-over" || !ordinaryAction
    });
}

static int? SlideIndex(IPresentation presentation, IBaseSlide? slide)
{
    for (var index = 0; index < presentation.Slides.Count; index++)
    {
        if (ReferenceEquals(presentation.Slides[index], slide)) return index + 1;
    }
    return null;
}

static string? PolicyViolation(IHyperlink? link)
{
    if (link == null) return null;
    if (link.ActionType == HyperlinkActionType.JumpSpecificSlide)
    {
        return link.TargetSlide == null ? "Missing target slide" : null;
    }
    if (link.ActionType != HyperlinkActionType.Hyperlink) return "Action is not allowed";
    if (!IsHttps(link.ExternalUrl)) return "Normalized URL is not absolute HTTPS";
    var original = link.ExternalUrlOriginal;
    if (!string.IsNullOrEmpty(original) && !IsHttps(original)) return "Original URL is not absolute HTTPS";
    return null;
}

static bool IsHttps(string? value)
{
    return Uri.TryCreate(value, UriKind.Absolute, out var uri) && uri.Scheme == Uri.UriSchemeHttps;
}

static List<IHyperlinkContainer> CollectContainers(IPresentation presentation)
{
    var found = new List<IHyperlinkContainer>();
    found.AddRange(presentation.HyperlinkQueries.GetAnyHyperlinks());
    foreach (var master in presentation.Masters) AddScope(master);
    foreach (var layout in presentation.LayoutSlides) AddScope(layout);
    foreach (var slide in presentation.Slides) AddScope(slide.NotesSlideManager.NotesSlide);
    AddScope(presentation.MasterNotesSlideManager.MasterNotesSlide);
    AddScope(presentation.MasterHandoutSlideManager.MasterHandoutSlide);
    return found.Distinct<IHyperlinkContainer>(ReferenceEqualityComparer.Instance).ToList();

    void AddScope(IBaseSlide? slide)
    {
        if (slide != null) found.AddRange(slide.HyperlinkQueries.GetAnyHyperlinks());
    }
}
```

A fenti bemenettel a jelentés öt műveleti sort tartalmaz. A fájl egér‑over link és a makró‑kattintás eltávolításra kerül, míg a HTTPS‑linkek és a belső dia‑navigáció megmarad. Az ellenőrzés nulla tiltott műveletet jelez. Egy tiltott külső kattintási URL‑t tartalmazó bemenet a csere‑ágat is bemutatja. Egy engedélyezett kattintással és tiltott egér‑overrel rendelkező konténer megtartja a kattintási műveletet.

Ez a szelektív tisztítás eltér a **[RemoveAllHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/removeallhyperlinks/)**‑től, amely a kiválasztott hatókörben mindkét aktiválási típust eltávolítja a szabályoktól függetlenül. Az itt vizsgált ellenőrzés csak a hyperlink műveleteket nézi; nem távolítja el a beágyazott VBA‑projektet, OLE‑objektumokat vagy egyéb aktív tartalmakat, és nem ellenőrzi a kiexportált PDF vagy HTML fájlt.

## **GYIK**

**Hogyan linkelhetek egy szekcióra vagy annak első diájára?**

A PowerPoint szekciók diák csoportjai, de egy belső hiperhivatkozás egyedi diához irányul. A szekcióhoz való navigáció létrehozásához linkelje az első diát a szekcióban.

**Csatolhatok hiperhivatkozást a mesterdia elemeihez, hogy minden dián működjön?**

Igen. A mesterdia és elrendezés elemei támogatják a hiperhivatkozásokat. Ezek a linkek a diavetítés során elérhetők azoknál a diákon, amelyek a megfelelő mestert vagy elrendezést használják.

**Megmaradnak a hiperhivatkozások PDF, HTML, képek vagy videó exportálásakor?**

A támogatott PDF és HTML exportok megőrizhetik a hiperhivatkozásokat; a raszteres képek és a videó nem. Lásd az export‑szempontokat a **[Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks)** részben.
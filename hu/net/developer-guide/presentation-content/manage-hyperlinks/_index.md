---
title: Prezentációs hiperhivatkozások kezelése .NET-ben
linktitle: Hiperhivatkozások kezelése
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

A hiperhivatkozás összekapcsolja a prezentáció tartalmát egy weboldallal vagy a prezentáción belüli egy helyszínnel. A PowerPointban a hiperhivatkozások általában két célra szolgálnak:

* Weboldal megnyitása szövegből, alakzatból vagy médiakeretből.
* Navigálás egy másik diára, például egy tartalomjegyzékből.

Az Aspose.Slides for .NET lehetővé teszi ezeknek a hivatkozásoknak a hozzáadását, megjelenésük és hangjuk vezérlését, tulajdonságaik frissítését és eltávolítását. Az alábbi példák bemutatják, hogyan lehet hiperhivatkozásokkal dolgozni egyedi elemeknél, valamint hogyan lehet hozzáférni a hiperhivatkozásokhoz a prezentáció, dia vagy szövegkeret szintjén.

{{% alert color="info" title="Note" %}}

A prezentációkat a [ingyenes online Aspose PowerPoint szerkesztő](https://products.aspose.app/slides/editor) segítségével is szerkesztheti.

{{% /alert %}} 

## **URL hiperhivatkozások hozzáadása**

Weboldal URL-t rendelhet szöveghez, alakzathoz vagy médiakerethez. Az elem, amelyhez a hiperhivatkozást rendeli, meghatározza a kattintható területet: a szövegrész linkeli a kijelölt szöveget, míg az alakzat vagy keret a diaobjektumot linkeli.

Relatív hiperhivatkozásokat tartalmazó prezentációk esetén nézze meg a [A hiperhivatkozás alapjának kezelése](/slides/hu/net/presentation-properties/#manage-the-hyperlink-base) útmutatót, hogy elolvassa, módosítsa vagy törölje a dokumentumszintű alapot.

### **URL hiperhivatkozások hozzáadása szöveghez**

A szöveget egy weboldalra linkeléshez rendelje hozzá a [Hyperlink](https://reference.aspose.com/slides/net/aspose.slides/hyperlink/) objektumot a szövegrész [HyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/portionformat/hyperlinkclick/) tulajdonságához, ahogy az alább látható. Csak ez a szövegrész lesz kattintható.

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

### **URL hiperhivatkozások hozzáadása alakzatokhoz és médiakeretekhez**

Az alakzat vagy keret kattinthatóvá tételéhez állítsa be a [HyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/shape/hyperlinkclick/) tulajdonságát. A hiperhivatkozás az objektumhoz tartozik, nem egy benne lévő szövegrészhez.

Ugyanez a megközelítés alkalmazható kép-, hang- és videokeretekre: rendelje a hiperhivatkozást a kerethez, és szükség esetén állítsa be a link [Tooltip](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/tooltip/) attribútumát.

Az alábbi példa egy téglalapot tesz kattinthatóvá:

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

A belső hiperhivatkozások lehetővé teszik, hogy az olvasók a tartalomjegyzékből egy adott diára ugorjanak. Az alábbi példa a [SetInternalHyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/setinternalhyperlinkclick/) metódust használja, hogy az első dia „Page 2” szövegét a második diára linkelje.

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

### **Szín**

Az [IHyperlink](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/) [ColorSource](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/colorsource/) tulajdonsága határozza meg, hogy a hiperhivatkozás a prezentáció hiperhivatkozás-színét vagy a szövegrész formázását használja-e. Egy egyéni szövegszín alkalmazásához válassza a [HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/net/aspose.slides/hyperlinkcolorsource/) értéket, és állítsa be a rész kitöltőszínét. Ez a funkció a PowerPoint 2019‑ben került bevezetésre; a régebbi verziók nem alkalmazzák ezt a beállítást.

Az alábbi példa két szöveges hiperhivatkozást ad ugyanarra a diára. Az első piros szövegkitöltést használ, míg a második az alapértelmezett hiperhivatkozás-színt tartja meg.

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

A hiperhivatkozás aktiváláskor lejátszhat egy hangot, vagy leállíthat egy már futó hangot. Az alábbi tulajdonságokkal állíthatja be ezeket a viselkedéseket:

- [IHyperlink.Sound](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/sound/) határozza meg a hiperhivatkozáshoz társított audiót.
- [IHyperlink.StopSoundOnClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/stopsoundonclick/) szabályozza, hogy a hiperhivatkozás aktiválása leállítsa‑e az előző hangot.

#### **Hiperhivatkozás hangjának hozzáadása**

Az alábbi példa betölti a `sampleaudio.wav` fájlt, és egy gombhoz rendeli az első dián. A gomb megnyomásakor a hang lejátszódik, és a következő diára navigál. Egy másik alakzat ugyanazon a dián leállítja az előző hangot a kattintáskor, anélkül, hogy navigációt végezne.

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

#### **Hiperhivatkozás hangjának kinyerése**

Az alábbi példa megnyitja a fenti példában létrehozott prezentációt, és a [Sound](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/sound/) és a [BinaryData](https://reference.aspose.com/slides/net/aspose.slides/iaudio/binarydata/) segítségével beolvassa az első alakzat hiperhivatkozás-audióját a memóriába.

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

A hiperhivatkozás szöveghez vagy alakzathoz való hozzárendelése után frissítheti a következő [IHyperlink](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/) tulajdonságokat:

- [Tooltip](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/tooltip/) a megjelenő szöveges tippet határozza meg a linkhez.
- [TargetFrame](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/targetframe/) a szülő HTML‑framesetben megcélzott keretet jelöli, ha alkalmazható.
- [History](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/history/) szabályozza, hogy a link aktiválása felvegye‑e a célt a megtekintett hiperhivatkozások listájába.
- [HighlightClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/highlightclick/) meghatározza, hogy a hiperhivatkozás kattintáskor kiemelésre kerül‑e.

## **Hiperhivatkozások eltávolítása a prezentációkból**

A [GetAnyHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) segítségével először gyűjtse össze a hiperhivatkozás‑konténereket, beleértve a szövegrész‑linkeket is, mielőtt módosítaná őket. Az alábbi példa eltávolítja mindkét aktiválási típust az első diáról. Egy típus eltávolításához csak a [RemoveHyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/removehyperlinkclick/) vagy a [RemoveHyperlinkMouseOver](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/removehyperlinkmouseover/) hívást használja; egy kattintási művelet eltávolítása nem vonja vissza az egér‑over megfelelőjét.

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

Feltétel nélküli eltávolításhoz a [RemoveAllHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/removeallhyperlinks/) mindkét aktiválási típust egy hívásban törli a kiválasztott hatókörben. Szelektív takarításhoz és a master‑ek, elrendezések és jegyzetek lefedéséhez tekintse meg a [Hiperhivatkozások jelentése, tisztítása és ellenőrzése](#report-sanitize-and-verify-hyperlinks) részt.

## **Átfogó hiperhivatkozás‑leltár összeállítása**

A prezentáció terjesztése előtt készítsen leltárt az interaktív műveletekről és a webes linkekről. A [GetAnyHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) [IHyperlinkContainer](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkcontainer/) objektumokat ad vissza, nem egy egyszerű URL‑lista. Vizsgálja meg mind a [HyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkcontainer/hyperlinkclick/) , mind a [HyperlinkMouseOver](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkcontainer/hyperlinkmouseover/) tulajdonságokat minden egyes konténeren. Ezek függetlenek: egy konténer mindkét műveletet is tartalmazhat, ezért egy teljes jelentéshez akár két sorra is szükség lehet konténerenként.

Az alakzatszintű hiperhivatkozások vizsgálata kimaradhat a szövegrész‑linkekhez kapcsolt hivatkozásokról. Használja a megfelelő hatókört, és tartsa meg a visszakapott konténereket, hogy később frissíthesse vagy eltávolíthassa a műveleteiket.

### **Prezentáció, dia és szövegkeret hatókörök lekérdezése**

Az [IHyperlinkQueries](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/) felület a [IPresentation.HyperlinkQueries](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/hyperlinkqueries/), [IBaseSlide.HyperlinkQueries](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/hyperlinkqueries/) és [ITextFrame.HyperlinkQueries](https://reference.aspose.com/slides/net/aspose.slides/itextframe/hyperlinkqueries/) segítségével érhető el. Minden hatókör ugyanazokat a lekérdezéseket támogatja:

- [GetHyperlinkClicks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/gethyperlinkclicks/) kattintási művelettel rendelkező konténereket ad vissza.
- [GetHyperlinkMouseOvers](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/gethyperlinkmouseovers/) egér‑over művelettel rendelkező konténereket ad vissza.
- [GetAnyHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) mindkét vagy bármelyik művelettel rendelkező konténereket ad vissza.

Az alábbi példa létrehozza a `hyperlink-audit-input.pptx`‑et egy külső kattintási linkkel, egy fájl egér‑over linkkel, egy belső dia‑navigációval, egy szöveg egér‑over linkkel és egy makró‑művelettel. A példában egyik művelet sem hajtódik végre. A három lekérdezés minden hatókörben használható; a számlálók konténereket jelentenek, nem a műveletek összegét. A szövegkeret‑hatókör kizárja a körülvevő alakzat saját linkjeit.

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

Ebben a példában a prezentáció‑ és dia‑lekérdezések három kattintási, két egér‑over és három összesített konténert jelentenek. A szövegkeret‑lekérdezés egy konténert ad minden kategóriában.

### **Műveletek és célpontok osztályozása**

Az [IHyperlink.ActionType](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/actiontype/) segítségével értelmezze a műveletet, mielőtt a célpontot vizsgálná. A [HyperlinkActionType](https://reference.aspose.com/slides/net/aspose.slides/hyperlinkactiontype/) értékek a webes navigáción túl is kiterjednek:

| Értékek | Jelentés jelentésben |
| --- | --- |
| `Hyperlink` | Külső hiperhivatkozás; vizsgálja meg az URL‑t és annak sémáját. |
| `JumpSpecificSlide` | Belső navigáció egy adott diára. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | Beépített diavetítés‑navigáció, a diavetítés kontextusában értelmezett. |
| `JumpEndShow`, `StartCustomSlideShow` | Az aktuális bemutató befejezése vagy egy egyéni bemutató indítása. |
| `StartMacro` | Makró végrehajtása. |
| `StartProgram` | Program indítása. |
| `OpenFile`, `OpenPresentation` | Fájl vagy másik prezentáció megnyitása; külön kezelendő a webes URL‑ktől. |
| `StartStopMedia` | Média lejátszás indítása vagy leállítása. |
| `NoAction`, `Unknown` | Nincs navigációs művelet, vagy ismeretlen művelet, amely felülvizsgálatot igényel. |

Olvassa ki a külső célpontokat az [ExternalUrl](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/externalurl/) segítségével, a belső célpontokat pedig a [TargetSlide](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/targetslide/) mezőből. A belső műveletek és a beépített parancsok gyakran nem rendelkeznek külső URL‑lel; egy üres URL nem jelenti azt, hogy a konténernek nincs művelete. Tartsa meg az [ExternalUrlOriginal](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/externalurloriginal/) értékét, ha eltér a normalizált URL‑től, és adja hozzá a [Tooltip](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/tooltip/)‑et, ha elérhető.

### **Hiperhivatkozások jelentése, tisztítása és ellenőrzése**

Az alábbi .NET 6+ példa egy meglévő prezentációt (a fenti bemeneti fájlt) beolvas, a `hyperlink-audit.json`‑t írja, egy szabályzatot alkalmaz, a `hyperlink-sanitized.pptx`‑t menti, majd újra megnyitja, hogy újra ellenőrizze mindkét aktiválási típust. A módosítások előtt a konténereket gyűjti, és referenciális egyenlőséget használ, hogy ne dolgozza fel ugyanazt a konténert kétszer. A prezentáció‑lekérdezések a szokásos diákra vonatkoznak; a csomagon belüli átfogó leltárhoz explicit módon lekérdezi a master‑eket, elrendezéseket, jegyzeteket és a jegyzet‑, valamint a kézibeszámoló‑master‑eket, ha jelen vannak.

A jelentés egy egy‑alapú dianévszámot és a rendelkezésre álló [SlideId](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/slideid/)‑t rögzíti. Az [ISlideComponent.Slide](https://reference.aspose.com/slides/net/aspose.slides/islidecomponent/slide/) a támogatott konténerekhez a tulajdonos diát adja vissza. A master‑ek, elrendezések és jegyzetek nem rendelkeznek szokásos diaindexszel, ezért a hatókörük alapján azonosítjuk őket. Az alakzat‑konténereket és a szövegrész‑formázási konténereket külön jelöljük; a többi konténer a futás‑idő típusnevével marad. Minden konténer kap egy jelentés‑helyi azonosítót, hogy a két művelet összekapcsolható legyen.

Ez a szándékosan korlátozó alkalmazási szabályzat csak abszolút HTTPS‑URL‑eket és érvényes belső dia‑célpontokat engedélyez. A makrókat, programokat, fájl‑műveleteket, egyéb diavetítés‑műveleteket, ismeretlen műveleteket és egyéb URL‑sémákat elutasítja. Ezek az elutasítások szabályzat‑döntések, nem az Aspose.Slides biztonsági ítélete. A HTTPS önmagában nem teremt bizalmat: adjon hozzá hoszt‑fehérlistákat és egyéb ellenőrzéseket az alkalmazásához. Mind az eredeti, mind a normalizált külső URL‑ket ellenőrizzük. A példa metaadat‑ellenőrzést végez anélkül, hogy a linkeket követné vagy a műveleteket lefuttatná.

Javításhoz a konténer [HyperlinkManager](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkcontainer/hyperlinkmanager/) támogatja a [SetExternalHyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/setexternalhyperlinkclick/), a [RemoveHyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/removehyperlinkclick/) és a [RemoveHyperlinkMouseOver](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/removehyperlinkmouseover/) metódusokat. Itt a tiltott külső kattintási linkek egy rögzített HTTPS‑céloldalra cserélődnek; a többi tiltott kattintás és a tiltott egér‑over művelet külön‑külön kerül eltávolításra. Állítsa a `replaceExternalClicks`‑t `false`‑ra, ha minden szabálysértést el szeretne távolítani. Válasszon egy alkalmazás‑tulajdonú csereoldalt a telepítés előtt.

A jelentés export‑jelzője konzervatív PDF‑ellenőrzési szabályzatot használ: az egér‑over műveleteket és minden egyéb, mint a külső link vagy egy specifikus dia‑ugrás, potenciálisan nem támogatottként jelöli. Ez egy ellenőrzési tipp, nem képesség‑teszt vagy garancia arra, hogy a jelöletlen linkek megmaradnak az export során. A támogatott [PDF](/slides/hu/net/convert-powerpoint-to-pdf/) és [HTML](/slides/hu/net/convert-powerpoint-to-html/) exportok megőrizhetik a hiperhivatkozásokat, a művelet, az export‑opciók és a megjelenítő függvényében. A raszteres [images](/slides/hu/net/convert-powerpoint-to-png/) és [video](/slides/hu/net/convert-powerpoint-to-video/) nem tudják megőrizni az interaktív hiperhivatkozásokat; ezeknél az audit során minden műveletet jelöljen.

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

A fenti bemenettel a jelentés öt műveleti sort tartalmaz. A fájl egér‑over link és a makró‑kattintás eltávolításra kerül, míg a HTTPS‑linkek és a belső dia‑navigáció megmarad. Az ellenőrzés nulla tiltott műveletet jelez. Egy tiltott külső kattintási URL‑t tartalmazó bemenet a cserélő ágat is futtatja. Egy engedélyezett kattintással és tiltott egér‑overrel rendelkező konténer megtartja a kattintási műveletet.

Ez a szelektív takarítás eltér a [RemoveAllHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/removeallhyperlinks/) működésétől, amely a kiválasztott hatókörön belül a szabálysértésektől függetlenül eltávolítja mindkét aktiválási típust. A jelen ellenőrzés csak a hiperhivatkozás‑műveleteket vizsgálja; nem távolítja el a beágyazott VBA‑projket, OLE‑objektumokat vagy egyéb aktív tartalmakat, és nem ellenőrzi a kiexportált PDF‑ vagy HTML‑fájlt.

## **GYIK**

**Hogyan linkelhetek egy szakaszra vagy annak első diájára?**

A PowerPointban a szakaszok diákat csoportosítanak, de egy belső hiperhivatkozás egyetlen diát céloz meg. A szakaszra való navigáláshoz linkelje a szakasz első diájára.

**Csatolhatok-e hiperhivatkozást a mesterdia‑elemekhez, hogy minden dián működjön?**

Igen. A mesterdia‑ és elrendezés‑elemek támogatják a hiperhivatkozásokat. Ezek a linkek a diavetítés során elérhetők azoknál a diáknál, amelyek a megfelelő mester‑ vagy elrendezés‑elemet használják.

**Megmaradnak‑e a hiperhivatkozások PDF, HTML, képek vagy videó exportálásakor?**

A támogatott PDF‑ és HTML‑exportok megőrizhetik a hiperhivatkozásokat; a raszteres képek és videó nem. Lásd az export‑szempontokat a [Hiperhivatkozások jelentése, tisztítása és ellenőrzése](#report-sanitize-and-verify-hyperlinks) részben.
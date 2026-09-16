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

A hiperhivatkozás a bemutató tartalmát kapcsolja össze egy weboldallal vagy a bemutatón belüli helyszínnel. A PowerPointban a hiperhivatkozások általában két célra szolgálnak:

* Weboldal megnyitása szövegből, alakzatból vagy médiakeretből.
* Másik diára navigálás, például a tartalomjegyzékből.

Az Aspose.Slides for .NET lehetővé teszi ezen hivatkozások hozzáadását, megjelenésük és hangjuk vezérlését, tulajdonságaik frissítését és eltávolítását. Az alábbi példák bemutatják, hogyan dolgozhatunk hiperhivatkozásokkal egyedi elemeknél, valamint hogyan érhetjük el őket a prezentáció, dia vagy szövegkeret szintjén.

{{% alert color="info" title="Megjegyzés" %}}
A prezentációkat szerkesztheti a [ingyenes online Aspose PowerPoint szerkesztő](https://products.aspose.app/slides/hu/editor) segítségével.
{{% /alert %}} 

## **URL hiperhivatkozások hozzáadása**

Weboldal URL-jét hozzárendelheti szöveghez, alakzathoz vagy médiakerethez. Az a elem, amelyhez a hiperhivatkozást rendeli, meghatározza a kattintható területet: egy szövegrész a kijelölt szöveget kapcsolja, míg egy alakzat vagy keret a diaobjektust.

### **URL hiperhivatkozások hozzáadása szöveghez**

A szöveg weboldalhoz kapcsolásához rendelje a [Hyperlink](https://reference.aspose.com/slides/hu/net/aspose.slides/hyperlink/) objektumot a szövegrész [HyperlinkClick](https://reference.aspose.com/slides/hu/net/aspose.slides/portionformat/hyperlinkclick/) tulajdonságához, ahogy az alább látható. Csak az adott szövegrész lesz kattintható.

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

Ahhoz, hogy egy alakzat vagy keret kattintható legyen, állítsa be a [HyperlinkClick](https://reference.aspose.com/slides/hu/net/aspose.slides/shape/hyperlinkclick/) tulajdonságát. A hiperhivatkozás az objektumhoz tartozik, nem a benne lévő szövegrészhez.

Ugyanez a megközelítés alkalmazható kép-, audio- és videókeretekre: rendelje a hiperhivatkozást a kerethez, és szükség esetén állítsa be a link [Tooltip](https://reference.aspose.com/slides/hu/net/aspose.slides/ihyperlink/tooltip/) attribútumát.

Az alábbi példa egy négyzetet tesz kattinthatóvá:

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

Belső hiperhivatkozások lehetővé teszik az olvasók számára, hogy a tartalomjegyzékből egy adott diára ugorjanak. Az alábbi példa a [SetInternalHyperlinkClick](https://reference.aspose.com/slides/hu/net/aspose.slides/ihyperlinkmanager/setinternalhyperlinkclick/) metódust használja, hogy az első dia „2. oldal” szövegét a második diára linkelje.

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

Az [IHyperlink](https://reference.aspose.com/slides/hu/net/aspose.slides/ihyperlink/) [ColorSource](https://reference.aspose.com/slides/hu/net/aspose.slides/ihyperlink/colorsource/) tulajdonsága határozza meg, hogy a hiperhivatkozás a prezentáció hiperhivatkozás színét vagy a szövegrész formázását használja-e. Egyéni szövegszín alkalmazásához válassza a [HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/hu/net/aspose.slides/hyperlinkcolorsource/) értéket, és állítsa be a rész kitöltőszínét. Ez a funkció a PowerPoint 2019‑ben került bevezetésre; a korábbi verziók nem alkalmazzák ezt a beállítást.

Az alábbi példa két szöveges hiperhivatkozást ad ugyanarra a diára. Az első piros szöveggel, a második az alapértelmezett hiperhivatkozási színnel rendelkezik.

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

A hiperhivatkozás aktiváláskor hangot játszhat le, vagy leállíthat egy már lejátszott hangot. Az alábbi tulajdonságokkal állíthatja be ezeket a viselkedéseket:

- [IHyperlink.Sound](https://reference.aspose.com/slides/hu/net/aspose.slides/ihyperlink/sound/) adja meg a hiperhivatkozáshoz társított audiót.
- [IHyperlink.StopSoundOnClick](https://reference.aspose.com/slides/hu/net/aspose.slides/ihyperlink/stopsoundonclick/) határozza meg, hogy a hiperhivatkozás aktiválása leállítsa‑e az előző hangot.

#### **Hiperhivatkozás hangjának hozzáadása**

Az alábbi példa betölti a `sampleaudio.wav` fájlt, és egy gombhoz társítja az első dián. A gomb megnyomása lejátsza a hangot és a következő diára lép. Egy második alakzat ugyanazon a dián megnyomáskor leállítja az előző hangot, anélkül hogy navigációt végezne.

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

Az alábbi példa megnyitja a fent létrehozott prezentációt, és a [Sound](https://reference.aspose.com/slides/hu/net/aspose.slides/ihyperlink/sound/) és [BinaryData](https://reference.aspose.com/slides/hu/net/aspose.slides/iaudio/binarydata/) segítségével beolvassa az első alakzat hiperhivatkozási audióját memóriába.

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

A hiperhivatkozás szöveggel vagy alakzattal való hozzárendelése után frissítheti az alábbi [IHyperlink](https://reference.aspose.com/slides/hu/net/aspose.slides/ihyperlink/) tulajdonságokat:

- [Tooltip](https://reference.aspose.com/slides/hu/net/aspose.slides/ihyperlink/tooltip/) a linkhez megjelenő tipp szövegét adja meg.
- [TargetFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/ihyperlink/targetframe/) a célkeretet határozza meg egy szülő HTML framesetben, ha alkalmazható.
- [History](https://reference.aspose.com/slides/hu/net/aspose.slides/ihyperlink/history/) szabályozza, hogy a link aktiválása felvételre kerüljön‑e a megtekintett hiperhivatkozások listájába.
- [HighlightClick](https://reference.aspose.com/slides/hu/net/aspose.slides/ihyperlink/highlightclick/) beállítja, hogy a hiperhivatkozás ki legyen‑e emelve kattintáskor.

## **Hiperhivatkozások eltávolítása a prezentációkból**

A [GetAnyHyperlinks](https://reference.aspose.com/slides/hu/net/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) segítségével gyűjtheti össze a hiperhivatkozás‑konténereket, beleértve a szövegrész‑linkeket is, mielőtt módosítaná őket. Az alábbi példa mindkét aktivációs típust eltávolítja az első diáról. Ha csak egy típust akar eltávolítani, hívja csak a [RemoveHyperlinkClick](https://reference.aspose.com/slides/hu/net/aspose.slides/ihyperlinkmanager/removehyperlinkclick/) vagy a [RemoveHyperlinkMouseOver](https://reference.aspose.com/slides/hu/net/aspose.slides/ihyperlinkmanager/removehyperlinkmouseover/) metódust; egy kattintási művelet eltávolítása nem távolítja el a rá mutató egér‑over műveletet.

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

Feltétel nélküli eltávolításhoz a [RemoveAllHyperlinks](https://reference.aspose.com/slides/hu/net/aspose.slides/ihyperlinkqueries/removeallhyperlinks/) mindkét aktivációs típust egy hívásban eltávolítja a kiválasztott hatókörben. Szelektív tisztításhoz, a mesterek, elrendezések és jegyzetek lefedéséhez lásd a [Jelentés, szűrés és ellenőrzés a hiperhivatkozásokra](#report-sanitize-and-verify-hyperlinks) részt.

## **Teljes hiperhivatkozás‑leltár összeállítása**

Mielőtt terjesztené a prezentációt, készítsen leltárt az interaktív műveletekről és a webes hivatkozásokról. A [GetAnyHyperlinks](https://reference.aspose.com/slides/hu/net/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) [IHyperlinkContainer](https://reference.aspose.com/slides/hu/net/aspose.slides/ihyperlinkcontainer/) objektumokat ad vissza, nem egy lapos URL‑lista. Vizsgálja meg mind a [HyperlinkClick](https://reference.aspose.com/slides/hu/net/aspose.slides/ihyperlinkcontainer/hyperlinkclick/), mind a [HyperlinkMouseOver](https://reference.aspose.com/slides/hu/net/aspose.slides/ihyperlinkcontainer/hyperlinkmouseover/) tulajdonságot minden konténeren. Ezek függetlenek: ugyanaz a konténer tartalmazhat mindkét műveletet, így egy teljes jelentés akár két sorra is szükség lehet konténerenként.

Csak az alakzat‑szintű hiperhivatkozások vizsgálata kihagyhatja a szövegrészekhez csatolt linkeket. Kérdezze le a megfelelő hatókört, és őrizze meg a visszakapott konténereket, hogy később frissíthesse vagy eltávolíthassa azok műveleteit.

### **Prezentáció, dia és szövegkeret hatókörök lekérdezése**

Az [IHyperlinkQueries](https://reference.aspose.com/slides/hu/net/aspose.slides/ihyperlinkqueries/) felület elérhető a [IPresentation.HyperlinkQueries](https://reference.aspose.com/slides/hu/net/aspose.slides/ipresentation/hyperlinkqueries/), [IBaseSlide.HyperlinkQueries](https://reference.aspose.com/slides/hu/net/aspose.slides/ibaseslide/hyperlinkqueries/) és [ITextFrame.HyperlinkQueries](https://reference.aspose.com/slides/hu/net/aspose.slides/itextframe/hyperlinkqueries/) segítségével. Minden hatókör ugyanazokat a lekérdezéseket támogatja:

- [GetHyperlinkClicks](https://reference.aspose.com/slides/hu/net/aspose.slides/ihyperlinkqueries/gethyperlinkclicks/) a kattintási művelettel rendelkező konténereket adja vissza.
- [GetHyperlinkMouseOvers](https://reference.aspose.com/slides/hu/net/aspose.slides/ihyperlinkqueries/gethyperlinkmouseovers/) a egér‑over művelettel rendelkező konténereket adja vissza.
- [GetAnyHyperlinks](https://reference.aspose.com/slides/hu/net/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) mindkét vagy egyetlen művelettel rendelkező konténereket adja vissza.

Az alábbi példa létrehozza a `hyperlink-audit-input.pptx` fájlt egy külső kattintási linkkel, egy fájl egér‑over linkkel, belső dia navigációval, egy szöveg‑egér‑over linkkel és egy makró‑művelettel. A példa nem hajtja végre ezeket a műveleteket. A három lekérdezés minden hatókörben ugyanúgy működik; a számlálók konténereket adnak vissza, nem a műveletek összes számát. A szövegkeret hatókör kizárja a körülvevő alakzat saját linkjeit.

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

Ebben a példában a prezentáció‑ és dia‑lekérdezések három kattintási konténert, két egér‑over konténert és három, bármelyik művelettel rendelkező konténert jeleznek. A szövegkeret lekérdezés minden kategóriában egy konténert ad vissza.

### **Műveletek és célok osztályozása**

Használja az [IHyperlink.ActionType](https://reference.aspose.com/slides/hu/net/aspose.slides/ihyperlink/actiontype/) értéket a művelet értelmezéséhez, mielőtt a célra vonatkozó információt vizsgálná. A [HyperlinkActionType](https://reference.aspose.com/slides/hu/net/aspose.slides/hyperlinkactiontype/) értékek a webnavigáción túl is kiterjednek:

| Values | Meaning for an audit |
| --- | --- |
| `Hyperlink` | Külső hiperhivatkozás; ellenőrizze az URL‑t és annak sémáját. |
| `JumpSpecificSlide` | Belső navigáció egy adott diára. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | Beépített diavetítés‑navigáció, a diavetítés kontextusában értelmezve. |
| `JumpEndShow`, `StartCustomSlideShow` | Az aktuális előadás befejezése vagy egy egyedi előadás indítása. |
| `StartMacro` | Makró végrehajtása. |
| `StartProgram` | Program indítása. |
| `OpenFile`, `OpenPresentation` | Fájl vagy másik prezentáció megnyitása; web‑URL‑től külön kezelendő. |
| `StartStopMedia` | Média lejátszás indítása vagy leállítása. |
| `NoAction`, `Unknown` | Nincsen navigációs művelet, vagy ismeretlen művelet, amely felülvizsgálatot igényel. |

A külső célokat az [ExternalUrl](https://reference.aspose.com/slides/hu/net/aspose.slides/ihyperlink/externalurl/) adja meg, a belső célokat a [TargetSlide](https://reference.aspose.com/slides/hu/net/aspose.slides/ihyperlink/targetslide/) jelöli. Belső műveletek és beépített parancsok esetén előfordulhat, hogy nincs külső URL; egy üres URL nem jelenti azt, hogy a konténernek nincs művelete. A [ExternalUrlOriginal](https://reference.aspose.com/slides/hu/net/aspose.slides/ihyperlink/externalurloriginal/) értéket őrizze meg, ha eltér a normalizált URL‑től, és adja hozzá a [Tooltip](https://reference.aspose.com/slides/hu/net/aspose.slides/ihyperlink/tooltip/) tartalmát, ha elérhető.

### **Hiperhivatkozások jelentése, szűrése és ellenőrzése**

Az alábbi .NET 6+ példa beolvas egy meglévő prezentációt (használja a fent létrehozott fájlt), kiírja a `hyperlink-audit.json` fájlt, alkalmaz egy szabályt, elmenti a `hyperlink-sanitized.pptx`‑et, majd újra megnyitja, hogy újra ellenőrizze mindkét aktivációs típust. A konténereket a módosítás előtt gyűjti, és referenciális egyenlőséget használ annak elkerülésére, hogy ugyanazt a konténert kétszer dolgozza fel. A prezentáció‑lekérdezések a szokásos diákra vonatkoznak; a csomag‑szintű leltárhoz kifejezetten lekérdezi a mestereket, elrendezéseket, jegyzeteket, valamint a jegyzet‑ és füzet‑mestereket, ha léteznek.

A jelentés egy egy‑alapú diaszámot és a [SlideId](https://reference.aspose.com/slides/hu/net/aspose.slides/ibaseslide/slideid/)‑t rögzíti, ha elérhető. Az [ISlideComponent.Slide](https://reference.aspose.com/slides/hu/net/aspose.slides/islidecomponent/slide/) biztosítja a tulajdonos diát a támogatott konténerekhez. A mesterek, elrendezések és jegyzetek nem rendelkeznek hagyományos diaszámmal, ezért a hatókörük alapján azonosítjuk őket. Az alakzat‑konténereket és a szövegrész‑formázási konténereket külön jelöljük; egyéb konténer‑típusok megtartják a futásidejű típusnévüket. Minden konténer kap egy jelentés‑belső azonosítót, hogy a két művelet összekapcsolható legyen.

Ez a szándékosan szigorú alkalmazási szabály csak abszolút HTTPS URL‑ket és érvényes belső dia‑célokat engedélyezi. Elutasítja a makrókat, programokat, fájl‑műveleteket, egyéb diavetítés‑műveleteket, ismeretlen műveleteket és egyéb URL‑sémákat. Ezek az elutasítások szabályalkotási döntések, nem az Aspose.Slides biztonsági ítéletei. Az HTTPS önmagában nem teremt bizalmat: adjon meg engedélyezett host‑listákat és egyéb ellenőrzéseket a saját alkalmazásához. Mind az eredeti, mind a normalizált külső URL‑ket ellenőrzi a rendszer. A példa metaadat‑ellenőrzést végez hivatkozások követése vagy műveletek futtatása nélkül.

Javításkor a konténer [HyperlinkManager](https://reference.aspose.com/slides/hu/net/aspose.slides/ihyperlinkcontainer/hyperlinkmanager/) támogatja a [SetExternalHyperlinkClick](https://reference.aspose.com/slides/hu/net/aspose.slides/ihyperlinkmanager/setexternalhyperlinkclick/), a [RemoveHyperlinkClick](https://reference.aspose.com/slides/hu/net/aspose.slides/ihyperlinkmanager/removehyperlinkclick/) és a [RemoveHyperlinkMouseOver](https://reference.aspose.com/slides/hu/net/aspose.slides/ihyperlinkmanager/removehyperlinkmouseover/) metódusokat. Itt a tiltott külső kattintási linkek egy rögzített HTTPS céloldalra cserélődnek; a többi tiltott kattintás és egér‑over művelet önállóan el lesz távolítva. Állítsa a `replaceExternalClicks`‑t `false`‑ra, ha minden szabálysértést el kíván távolítani. Válasszon alkalmazás‑saját helyettesítő oldalt a bevezetés előtt.

A jelentés export‑zászlója egy konzervatív PDF‑ellenőrzési szabályt alkalmaz: megjelöli az egér‑over műveleteket és mindent, ami nem külső link vagy adott dia‑ugrás, lehetséges, hogy nem támogatott. Ez egy felülvizsgálati tipp, nem funkció‑teszt vagy garancia arra, hogy a jelöletlen linkek exportáláskor megmaradnak. A támogatott [PDF](/slides/hu/net/convert-powerpoint-to-pdf/) és [HTML](/slides/hu/net/convert-powerpoint-to-html/) exportok megőrizhetik a hiperhivatkozásokat, a művelet, az export‑opciók és a megtekintő függvényében. Raszteres [képek](/slides/hu/net/convert-powerpoint-to-png/) és [videók](/slides/hu/net/convert-powerpoint-to-video/) nem tudják megőrizni az interaktív hiperhivatkozásokat; ilyen kimenetek auditálásakor minden művelet megjelölendő.

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

A fenti bemenet alapján a jelentés öt műveleti sort tartalmaz. A fájl egér‑over link és a makró‑kattintás eltávolításra kerül, míg a HTTPS linkek és a belső dia‑navigáció megmarad. Az ellenőrzés nulla tiltott műveletet jelez. Egy tiltott külső kattintási URL‑t tartalmazó bemenet a csere‑ágat is végrehajtja. Egy engedélyezett kattintással és tiltott egér‑overrel rendelkező konténer megtartja a kattintási műveletét.

Ez a szelektív tisztítás eltér a [RemoveAllHyperlinks](https://reference.aspose.com/slides/hu/net/aspose.slides/ihyperlinkqueries/removeallhyperlinks/) viselkedésétől, amely a szabályoktól függetlenül eltávolítja mindkét aktivációs típust a kiválasztott hatókörben. Az itt végzett ellenőrzés csak a hiperhivatkozás‑műveleteket nézi; nem távolítja el a beágyazott VBA‑projket, OLE‑objektumokat vagy egyéb aktív tartalmakat, és nem validálja a kiexportált PDF‑ vagy HTML‑fájlokat.

## **GYIK**

**Hogyan linkelhetek egy szekcióra vagy annak első diájára?**

A PowerPointban a szekciók diák csoportjai, de egy belső hiperhivatkozás egyedi diára mutat. A szekcióra való navigáláshoz linkelje az első diát abban a szekcióban.

**Csatolhatok‑e hiperhivatkozást a mester‑dia elemeihez, hogy minden dián működjön?**

Igen. A mester‑dia és az elrendezés elemei támogatják a hiperhivatkozásokat. Ezek a linkek a vetítés során elérhetők azoknál a diáknál, amelyek a megfelelő mestert vagy elrendezést használják.

**Megtartják‑e a hiperhivatkozásokat PDF, HTML, képek vagy videó exportálásakor?**

A támogatott PDF és HTML exportok megőrizhetik a hiperhivatkozásokat; a raszteres képek és a videó nem. Lásd a [Jelentés, szűrés és ellenőrzés a hiperhivatkozásokra](#report-sanitize-and-verify-hyperlinks) részt a kiexportálási szempontokról.
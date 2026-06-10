---
title: Prezentáció slide masterek kezelése .NET-ben
linktitle: Dia master
type: docs
weight: 80
url: /hu/net/slide-master/
keywords:
- dia master
- master dia
- PPT master dia
- több master dia
- master diák összehasonlítása
- háttér
- helyőrző
- master dia klónozása
- master dia másolása
- master dia duplikálása
- használaton kívüli master dia
- PowerPoint
- OpenDocument
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Slide masterek kezelése az Aspose.Slides for .NET-ben: hozzáférés, szerkesztés, klónozás, összehasonlítás és master diák eltávolítása PowerPoint és OpenDocument prezentációkban."
---
## **Áttekintés**

Egy **slide master** meghatározza a közös tervezési beállításokat egy diacsoport számára. Tartalmazhat közös alakzatokat, logókat, háttérképeket, szövegstílusokat, téma‑beállításokat és láblécbeállításokat. A PowerPointban a slide master szerkesztése a szokásos módja annak, hogy a bemutató egységes maradjon anélkül, hogy minden dián megismételné a formázást.

Aspose.Slides for .NET támogatja ugyanazt a modellt. Egy bemutató egy vagy több master slide‑t tartalmazhat, és minden master slide több layout slide‑t is tartalmazhat. A normál diák általában nem hivatkoznak közvetlenül egy master slide‑ra. Ehelyett egy normál dia egy layout slide‑ot használ, amely egy master slide‑hoz tartozik.

A hierarchia:

1. **Slide master** - meghatározza a közös tervezést és témát.  
1. **Layout slide** - meghatározza a helyőrzők és az elrendezési szintű formázás konkrét elrendezését.  
1. **Normal slide** - tartalmazza a tényleges bemutató tartalmat, és egy layout slide‑ot használ.

![A master diák, layout diák és normál diák hierarchiája](slide-master_2.jpg)

Az Aspose.Slides‑ban a slide master a [IMasterSlide](https://reference.aspose.com/slides/hu/net/aspose.slides/imasterslide/) interfész által van képviselve. A bemutató összes master slide‑ja elérhető a [Presentation.Masters](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/masters/) gyűjteményen keresztül, amely a [IMasterSlideCollection](https://reference.aspose.com/slides/hu/net/aspose.slides/imasterslidecollection/) implementálja.

{{% alert color="info" title="Inheritance" %}}
Amikor ugyanaz a tulajdonság több szinten is definiálva van, a specifikusabb szint nyer. Például, ha egy master slide és egy layout slide is meghatároz egy hátteret, akkor a layout alapján készült diák a layout háttérszínét használják. További információ a layout diákról a [Apply or Change Slide Layouts](/slides/hu/net/slide-layout/) oldalon található.
{{% /alert %}}

## **A slide master-ek elérése**

PowerPointban a Slide Master nézetet a **View** > **Slide Master** menüpontból nyithatja meg.

![A Slide Master parancs a PowerPoint Nézet fülön](slide-master_3.jpg)

Az Aspose.Slides‑ban a `Masters` gyűjteményt használja a master slide‑ok eléréséhez:

```csharp
using var presentation = new Presentation("presentation.pptx");

var firstMasterSlide = presentation.Masters[0];
var masterSlideCount = presentation.Masters.Count;
var firstMasterLayoutSlideCount = firstMasterSlide.LayoutSlides.Count;

Console.WriteLine("Master slides: " + masterSlideCount);
Console.WriteLine("Layouts in the first master: " + firstMasterLayoutSlideCount);
```

Egy normál dia által használt master slide‑ot a saját layoutján keresztül is lekérhetjük:

```csharp
using var presentation = new Presentation("presentation.pptx");

var slide = presentation.Slides[0];
var layoutSlide = slide.LayoutSlide;
var masterSlide = layoutSlide.MasterSlide;
var masterSlideName = masterSlide.Name;

Console.WriteLine(masterSlideName);
```

## **Mit tartalmaz egy Slide Master**

A master slide egy dia‑szerű objektum. Implementálja a [IBaseSlide](https://reference.aspose.com/slides/hu/net/aspose.slides/ibaseslide/) interfészt, így ugyanazokat a dia‑tulajdonságokat teszi elérhetővé, mint a normál és layout diák. A master‑specifikus tagok a [IMasterSlide](https://reference.aspose.com/slides/hu/net/aspose.slides/imasterslide/) API‑oldalon vannak felsorolva.

A gyakran használt master slide tagok a következők:

| Tag | Leírás |
| --- | --- |
| `Background` | Beállítja a master szintű dia háttérét. |
| `Shapes` | Tárolja a masteren elhelyezett alakzatokat, mint logók, képkockák és megosztott szöveg. |
| `LayoutSlides` | Tárolja a masterhez tartozó layout diákat. |
| `ThemeManager` | Hozzáférést biztosít a master téma API‑khoz. |
| `HeaderFooterManager` | Kezeli a fejléceket, lábléceket, dátumokat és dia számokat a master és annak alatti layoutok számára. |
| `GetDependingSlides` | Visszaadja azokat a normál diákat, amelyek a layoutjaikon keresztül a masterre támaszkodnak. |

## **Kép hozzáadása a Slide Masterhez**

Amikor egy képet ad hozzá egy master slide‑hoz, az a master‑hoz tartozó layout‑okat használó diákon is megjelenik. Hasznos logók, vízjelek, díszszalagok és egyéb ismétlődő vizuális elemek esetén.

```csharp
using var presentation = new Presentation("presentation.pptx");

var masterSlide = presentation.Masters[0];
var logoBytes = File.ReadAllBytes("logo.png");
var logoImage = presentation.Images.AddImage(logoBytes);

masterSlide.Shapes.AddPictureFrame(
    ShapeType.Rectangle,
    x: 20,
    y: 20,
    width: 80,
    height: 80,
    image: logoImage);

presentation.Save("presentation-with-logo.pptx", SaveFormat.Pptx);
```

További információ a képkockákról a [Picture Frame](/slides/hu/net/picture-frame/) oldalon található.

## **Helyőrzőkkel való munka**

A helyőrzők általában a layout diákon vannak definiálva. A master slide biztosítja a közös stílust és témát, amelyet a layout‑ok örökölnek, míg minden egyes layout dönt arról, hogy mely helyőrzők állnak rendelkezésre és hol helyezkednek el.

PowerPointban a helyőrzőparancsok a Slide Master nézetben érhetők el.

![A Helyőrző beszúrása parancs a PowerPoint Slide Master nézetben](slide-master_5.png)

Új helyőrzők hozzáadásához az Aspose.Slides‑ban dolgozzunk a master‑hez tartozó layout slide‑on:

```csharp
using var presentation = new Presentation("presentation.pptx");

var masterSlide = presentation.Masters[0];
var blankLayoutSlide =
    masterSlide.LayoutSlides.GetByType(SlideLayoutType.Blank) ??
    masterSlide.LayoutSlides.Add(SlideLayoutType.Blank, "Blank");

blankLayoutSlide.PlaceholderManager.AddTextPlaceholder(
    x: 60,
    y: 120,
    width: 600,
    height: 80);

presentation.Slides.AddEmptySlide(blankLayoutSlide);
presentation.Save("presentation-with-placeholder.pptx", SaveFormat.Pptx);
```

Már meglévő helyőrző alakzatokat is formázhat a master slide‑on. Az alábbi példa megkeresi a cím helyőrzőt és lineáris gradient kitöltést alkalmaz rá:

```csharp
using var presentation = new Presentation("presentation.pptx");

var masterSlide = presentation.Masters[0];
var titlePlaceholder = FindPlaceholder(masterSlide, PlaceholderType.Title);

if (titlePlaceholder != null)
{
    var redGradientColor = Color.FromArgb(255, 0, 0);
    var purpleGradientColor = Color.FromArgb(128, 0, 128);

    titlePlaceholder.FillFormat.FillType = FillType.Gradient;
    titlePlaceholder.FillFormat.GradientFormat.GradientShape = GradientShape.Linear;
    titlePlaceholder.FillFormat.GradientFormat.GradientStops.Add(0, redGradientColor);
    titlePlaceholder.FillFormat.GradientFormat.GradientStops.Add(255, purpleGradientColor);
}

presentation.Save("presentation-title-style.pptx", SaveFormat.Pptx);

static IAutoShape? FindPlaceholder(IMasterSlide masterSlide, PlaceholderType placeholderType)
{
    foreach (var shape in masterSlide.Shapes)
    {
        if (shape is IAutoShape { Placeholder: not null } autoShape &&
            autoShape.Placeholder.Type == placeholderType)
        {
            return autoShape;
        }
    }

    return null;
}
```

![Formázott cím helyőrző, amelyet a normál diák örökölnek](slide-master_8.png)

További helyőrző‑ és szövegformázási lehetőségek a [Set Prompt Text in Placeholder](/slides/hu/net/manage-placeholder/) és a [Text Formatting](/slides/hu/net/text-formatting/) oldalon találhatók.

## **Slide Master háttér módosítása**

A master háttér öröklődik a layout‑ok és azok a diák számára, amelyek nem írják felül. Az alábbi példa egy egyszínű háttérszínt állít be az első master slide‑ra:

```csharp
using var presentation = new Presentation("presentation.pptx");

var masterSlide = presentation.Masters[0];

masterSlide.Background.Type = BackgroundType.OwnBackground;
masterSlide.Background.FillFormat.FillType = FillType.Solid;
masterSlide.Background.FillFormat.SolidFillColor.Color = Color.ForestGreen;

presentation.Save("presentation-master-background.pptx", SaveFormat.Pptx);
```

Kapcsolódó témák: [Presentation Background](/slides/hu/net/presentation-background/) és [Presentation Theme](/slides/hu/net/presentation-theme/).

## **Slide Master klónozása egy másik bemutatóba**

A [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/hu/net/aspose.slides/imasterslidecollection/addclone/) segítségével egy master slide‑t másolhat egy másik bemutatóba. A másolt master ezután a célbemutató layout‑jai és diái számára használható.

```csharp
using var sourcePresentation = new Presentation("source.pptx");
using var destinationPresentation = new Presentation("destination.pptx");

var sourceMasterSlide = sourcePresentation.Masters[0];
var clonedMasterSlide = destinationPresentation.Masters.AddClone(sourceMasterSlide);

destinationPresentation.Save("destination-with-master.pptx", SaveFormat.Pptx);
```

Ha a normál diákot is a saját master‑jével együtt kívánja klónozni, lásd a [Clone Slides](/slides/hu/net/clone-slides/) oldalt.

## **Több Slide Master hozzáadása**

Egy bemutató több master slide‑t is tartalmazhat. Hasznos, ha különböző szakaszok más‑más márkázást, oldalszerkezetet vagy téma‑beállításokat igényelnek.

![PowerPoint parancsok a master diák beszúrásához és kezeléséhez](slide-master_9.jpg)

Az alábbi példa klónozza az alapértelmezett master‑t, a klónnak más háttérszínt ad, egy layout‑ot hoz létre a klónozott master alatt, majd egy új diát ad hozzá ehhez a layout‑hoz:

```csharp
using var presentation = new Presentation("presentation.pptx");

var defaultMasterSlide = presentation.Masters[0];
var sectionMasterSlide = presentation.Masters.AddClone(defaultMasterSlide);

sectionMasterSlide.Background.Type = BackgroundType.OwnBackground;
sectionMasterSlide.Background.FillFormat.FillType = FillType.Solid;
sectionMasterSlide.Background.FillFormat.SolidFillColor.Color = Color.LightSteelBlue;

var sourceBlankLayout =
    defaultMasterSlide.LayoutSlides.GetByType(SlideLayoutType.Blank) ??
    defaultMasterSlide.LayoutSlides[0];
var sectionBlankLayout = sectionMasterSlide.LayoutSlides.AddClone(sourceBlankLayout);

presentation.Slides.AddEmptySlide(sectionBlankLayout);
presentation.Save("presentation-with-multiple-masters.pptx", SaveFormat.Pptx);
```

## **Slide Master‑ek összehasonlítása**

A master slide‑ek összehasonlíthatók az [IBaseSlide](https://reference.aspose.com/slides/hu/net/aspose.slides/ibaseslide/) által örökölt `Equals` metódussal. Az összehasonlítás a struktúrát és a statikus tartalmakat (alakzatok, szöveg, formázás, animációk, egyéb dia‑beállítások) vizsgálja. Nem hasonlítja össze az egyedi azonosítókat (például dia‑ID‑k) vagy a dinamikus helyőrzőértékeket (például a aktuális dátumot).

```csharp
using var firstPresentation = new Presentation("first.pptx");
using var secondPresentation = new Presentation("second.pptx");

var firstPresentationMasterCount = firstPresentation.Masters.Count;
var secondPresentationMasterCount = secondPresentation.Masters.Count;

for (var firstMasterIndex = 0; firstMasterIndex < firstPresentationMasterCount; firstMasterIndex++)
{
    for (var secondMasterIndex = 0; secondMasterIndex < secondPresentationMasterCount; secondMasterIndex++)
    {
        var firstMasterSlide = firstPresentation.Masters[firstMasterIndex];
        var secondMasterSlide = secondPresentation.Masters[secondMasterIndex];
        var areMasterSlidesEqual = firstMasterSlide.Equals(secondMasterSlide);

        if (areMasterSlidesEqual)
        {
            Console.WriteLine(
                "first.pptx master #{0} equals second.pptx master #{1}",
                firstMasterIndex,
                secondMasterIndex);
        }
    }
}
```

További információ a [Compare Presentation Slides](/slides/hu/net/compare-slides/) oldalon.

## **Slide Master nézet beállítása alapértelmezett nézetnek**

A [ViewProperties](https://reference.aspose.com/slides/hu/net/aspose.slides/viewproperties/) `LastView` tulajdonságával szabályozhatja, hogy a PowerPoint melyik nézetet nyissa meg először. Az alábbi példa a bemutatót Slide Master nézetben nyitja meg:

```csharp
using var presentation = new Presentation("presentation.pptx");

presentation.ViewProperties.LastView = ViewType.SlideMasterView;
presentation.Save("presentation-master-view.pptx", SaveFormat.Pptx);
```

További nézetbeállítások a [Save Presentation](/slides/hu/net/save-presentation/) oldalon találhatók.

## **Használaton kívüli master slide‑ok eltávolítása**

Előfordulhat, hogy egy bemutató tartalmaz olyan master slide‑okat, amelyeket már egyetlen normál dia sem használ. A használaton kívüli master‑ok eltávolítása csökkentheti a fájlméretet és egyszerűsítheti a sablonkarbantartást.

A `Masters` gyűjteményből a [MasterSlideCollection.RemoveUnused](https://reference.aspose.com/slides/hu/net/aspose.slides/masterslidecollection/removeunused/) metódussal távolíthatja el a használaton kívüli master‑okat:

```csharp
using var presentation = new Presentation("presentation.pptx");

presentation.Masters.RemoveUnused(ignorePreserveField: true);
presentation.Save("presentation-clean.pptx", SaveFormat.Pptx);
```

Alacsony kóddal a [Compress.RemoveUnusedMasterSlides](https://reference.aspose.com/slides/hu/net/aspose.slides.lowcode/compress/removeunusedmasterslides/) metódust is használhatja:

```csharp
using var presentation = new Presentation("presentation.pptx");

Aspose.Slides.LowCode.Compress.RemoveUnusedMasterSlides(presentation);
presentation.Save("presentation-clean.pptx", SaveFormat.Pptx);
```

## **GYIK**

**Mi a különbség a slide master és a layout slide között?**  
A slide master a közös tervezési beállításokat (téma, háttér, közös alakzatok, szövegstílusok) határozza meg. Egy layout slide egy master slide‑hoz tartozik, és egy adott helyőrző‑elrendezést definiál. Egy normál dia egy layout slide‑ot használ, így mind a layout, mind a master beállításait örökli.

**Tartalmazhat egy bemutató több slide master‑t?**  
Igen. Egy bemutató több slide master‑t is tartalmazhat. Használjon több master‑t, ha a különböző szakaszok eltérő vizuális rendszert vagy márkázást igényelnek.

**Helyőrzőket a master slide‑ra vagy a layout slide‑ra kell-e felvennem?**  
A legtöbb esetben a helyőrzőket a layout slide‑okra helyezzük. A közös vizuális elemeket és a közös formázást a master slide‑ra, a tartalomhelyőrzőket pedig a layout slide‑okra tesszük.

**Törölhetek egy még használatban lévő master slide‑t?**  
Nem. Egy olyan master slide, amelyhez függő diák tartoznak, nem távolítható el közvetlenül. Először mozgassa át ezeket a diákot egy másik master alatti layout‑ra, vagy használjon olyan takarítási módszert, amely csak a nem használt master slide‑okat távolítja el.
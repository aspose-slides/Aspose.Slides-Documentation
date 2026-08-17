---
title: Diaelrendezések alkalmazása vagy módosítása .NET-ben
linktitle: Diaelrendezés
type: docs
weight: 60
url: /hu/net/slide-layout/
keywords:
- diaelrendezés
- tartalomelrendezés
- helykitöltő
- prezentációtervezés
- diatervezés
- nem használt elrendezés
- lábléc láthatóság
- címdiára
- cím és tartalom
- szakaszfejléc
- két tartalom
- összehasonlítás
- csak cím
- üres elrendezés
- tartalom felirattal
- kép felirattal
- cím és függőleges szöveg
- függőleges cím és szöveg
- PowerPoint
- OpenDocument
- prezentáció
- C#
- .NET
- Aspose.Slides
description: "Diaelrendezések alkalmazása, létrehozása és módosítása az Aspose.Slides for .NET-ben, helykitöltők hozzáadása, nem használt elrendezések eltávolítása és a lábléc láthatóságának szabályozása."
---
## **Áttekintés**

Egy diaelrendezés meghatározza a helykitöltők, például címek, szövegek, képek, diagramok és táblázatok pozícióját és formázását. Az elrendezés alkalmazása egységes struktúrát biztosít a diák számára, miközben minden dia saját tartalmát tartalmazhatja.

A leggyakoribb elrendezések a következők:

- **Címdiára**: Cím és alcím helykitöltőket tartalmaz.
- **Cím és Tartalom**: Cím helykitöltőt és általános célú tartalmi helykitöltőt tartalmaz.
- **Üres**: Nem tartalmaz tartalomhelykitöltőket, és akkor hasznos, ha minden alakzatot kézzel helyezünk el.

## **Az Elrendezés Öröklődésének Megértése**

Egy prezentációnak három kapcsolódó szintje van:

1. Egy [master slide](https://reference.aspose.com/slides/hu/net/aspose.slides/imasterslide/) definiálja a témát, a közös formázást, a háttérképeket és a közös objektumokat.
1. Egy [layout slide](https://reference.aspose.com/slides/hu/net/aspose.slides/ilayoutslide/) egy mesterhez tartozik, és egy adott helykitöltő elrendezést határoz meg.
1. Egy [normal slide](https://reference.aspose.com/slides/hu/net/aspose.slides/islide/) egy elrendezést használ, és tárolja a diára beírt tartalmat.

A normál dia az elrendezéstől örökli a témát és a formázást, az elrendezés pedig a mestertől. Egy normál dián közvetlenül beállított érték felülírja az örökölt értéket azon a szinten. Amikor egy normál dia létrejön, a helykitöltő alakzatok a kiválasztott elrendezésből generálódnak, míg a helykitöltőkbe beírt tartalom a normál dia része.

Adjon meg szükséges helykitöltőket egy elrendezéshez, mielőtt diákat hozna létre belőle. Egy elrendezéshez később egy további helykitöltő hozzáadása nem hoz létre automatikusan megfelelő helykitöltő alakzatot a már létező normál diákon.

Ennek a kapcsolatnak két fontos következménye van:

- Az örökölt formázás vagy a meglévő helykitöltő geometria módosítása egy elrendezésen minden arra függő diát frissíthet. Mielőtt egy már használt elrendezést szerkesztené, ellenőrizze a függő diákat, és tekintse át a keletkezett prezentációt.
- Egy elrendezést, amelyet még egy dia használ, nem lehet eltávolítani. Először rendelje át a függő diákat egy másik elrendezéshez, vagy csak a nem használt elrendezéseket távolítsa el.

További információért a hierarchia felső szintjéről lásd a [Slide Master](/slides/hu/net/slide-master/) oldalt.

## **Diaelrendezés Kiválasztása és Alkalmazása**

Használjon elrendezéstípust, ha a prezentáció a szabványos PowerPoint elrendezésdefiníciókat követi. Az elrendezésneveket a felhasználó szerkesztheti és lokalizálhatja, ezért a név alapján történő kiválasztás kevésbé megbízható, hacsak nem irányítja a forrássablont.

A következő példa az első mesteren keresi a **Title and Content** elrendezést. Ha ez az elrendezés nem érhető el, szándékosan a **Blank** elrendezésre tér vissza. A második null ellenőrzés szükséges, mert egy prezentáció csak egyedi elrendezéseket tartalmazhat. A kiválasztott elrendezést ezután a [ISlide.LayoutSlide](https://reference.aspose.com/slides/hu/net/aspose.slides/islide/layoutslide/) tulajdonságon keresztül alkalmazzák az első normál diára.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");

var layoutSlides = presentation.Masters[0].LayoutSlides;
var targetLayout = layoutSlides.GetByType(SlideLayoutType.TitleAndObject) ?? layoutSlides.GetByType(SlideLayoutType.Blank);

if (targetLayout == null)
{
    throw new InvalidOperationException("The first master does not contain a suitable layout slide.");
}

presentation.Slides[0].LayoutSlide = targetLayout;
presentation.Save("output-with-new-layout.pptx", SaveFormat.Pptx);
```

Az elrendezés megváltoztatása nem távolít el közvetlenül a diahoz hozzáadott szokásos alakzatokat. Azonban a helykitöltők pozíciója, az örökölt formázás és a meglévő helykitöltők és az új elrendezés közötti megfelelés megváltozhat, ezért ellenőrizze a kimenetet, amikor jelentősen eltérő elrendezések között vált.

## **Elrendezés Dia Hozzáadása**

A kiválasztás és a létrehozás külön műveletek. Az előző példa egy meglévő elrendezést választ ki; nem hoz létre újat. Elrendezés létrehozásához hívja meg a [IMasterLayoutSlideCollection.Add](https://reference.aspose.com/slides/hu/net/aspose.slides/masterlayoutslidecollection/add/) metódust a célmester elrendezésgyűjteményén.

A következő példa mindig hozzáad egy új **Title and Content** elrendezést `Report Title and Content` néven, majd egy azt felhasználó normál diát hoz létre. Az elrendezésneveknek egyedinek kell lenniük a gyűjteményen belül.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");

var masterSlide = presentation.Masters[0];
var reportLayout = masterSlide.LayoutSlides.Add(SlideLayoutType.TitleAndObject, "Report Title and Content");
presentation.Slides.AddEmptySlide(reportLayout);

presentation.Save("output-with-report-layout.pptx", SaveFormat.Pptx);
```

Csak akkor adjon hozzá egy elrendezést, ha a sablon valóban szükséges egy további újrahasználható struktúrára. Ha már létezik egy megfelelő elrendezés, válassza ki és használja újra a duplikálás helyett.

## **Helykitöltők Hozzáadása egy Elrendezés Diához**

Az [ILayoutSlide.PlaceholderManager](https://reference.aspose.com/slides/hu/net/aspose.slides/ilayoutslide/placeholdermanager/) tulajdonság egy [ILayoutPlaceholderManager](https://reference.aspose.com/slides/hu/net/aspose.slides/ilayoutplaceholdermanager/) szolgáltatót ad a helykitöltő alakzatok elrendezéshez történő hozzáadásához.

| PowerPoint Helykitöltő            | `ILayoutPlaceholderManager` Metódus |
| ---------------------------------- | ----------------------------------- |
| ![Tartalom](content.png)           | [`AddContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hu/net/aspose.slides/layoutplaceholdermanager/addcontentplaceholder/) |
| ![Tartalom (Függőleges)](contentV.png) | [`AddVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hu/net/aspose.slides/layoutplaceholdermanager/addverticalcontentplaceholder/) |
| ![Szöveg](text.png)                | [`AddTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hu/net/aspose.slides/layoutplaceholdermanager/addtextplaceholder/) |
| ![Szöveg (Függőleges)](textV.png) | [`AddVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hu/net/aspose.slides/layoutplaceholdermanager/addverticaltextplaceholder/) |
| ![Kép](picture.png)                | [`AddPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hu/net/aspose.slides/layoutplaceholdermanager/addpictureplaceholder/) |
| ![Diagram](chart.png)              | [`AddChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hu/net/aspose.slides/layoutplaceholdermanager/addchartplaceholder/) |
| ![Táblázat](table.png)             | [`AddTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hu/net/aspose.slides/layoutplaceholdermanager/addtableplaceholder/) |
| ![SmartArt](smartart.png)          | [`AddSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hu/net/aspose.slides/layoutplaceholdermanager/addsmartartplaceholder/) |
| ![Média](media.png)                | [`AddMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hu/net/aspose.slides/layoutplaceholdermanager/addmediaplaceholder/) |
| ![Online Kép](onlineImage.png)     | [`AddOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hu/net/aspose.slides/layoutplaceholdermanager/addonlineimageplaceholder/) |

A következő példa ellenőrzi, hogy létezik-e a **Blank** elrendezés, négy helykitöltőt ad hozzá, majd egy normál diát hoz létre a módosított elrendezés használatával. A sorrend szándékos: a helykitöltőket a normál dia létrehozása előtt adjuk hozzá, így az Aspose.Slides a megfelelő helykitöltő alakzatokat generálja azon a dián.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var blankLayout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);

if (blankLayout == null)
{
    throw new InvalidOperationException("The presentation does not contain a Blank layout slide.");
}

var placeholderManager = blankLayout.PlaceholderManager;
placeholderManager.AddContentPlaceholder(20, 20, 310, 270);
placeholderManager.AddVerticalTextPlaceholder(350, 20, 350, 270);
placeholderManager.AddChartPlaceholder(20, 310, 310, 180);
placeholderManager.AddTablePlaceholder(350, 310, 350, 180);

presentation.Slides.AddEmptySlide(blankLayout);
presentation.Save("output-with-placeholders.pptx", SaveFormat.Pptx);
```

Az eredmény:

![A helykitöltők az elrendezés dián](add_placeholders.png)

{{% alert color="warning" title="Figyelmeztetés" %}}
Az örökölt formázás vagy a meglévő elrendezés helykitöltőinek geometriai módosítása befolyásolhatja a függő diákot. Egy újonnan hozzáadott elrendezéshelykitöltő nem kerül vissza a meglévő normál diákba. Tesztelje az elrendezés módosításait a prezentáció egy másolatán, és ellenőrizze minden függő diát.
{{% /alert %}}

## **Nem Használt Elrendezés Diák Eltávolítása**

Használja a [Compress.RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/hu/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) metódust a olyan elrendezések eltávolításához, amelyeket egy normál dia sem hivatkozik. A metódus érintetlenül hagyja azokat az elrendezéseket, amelyek még használatban vannak.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");

Compress.RemoveUnusedLayoutSlides(presentation);
presentation.Save("output-without-unused-layouts.pptx", SaveFormat.Pptx);
```

Egy konkrét elrendezés eltávolításához először használja a [HasDependingSlides](https://reference.aspose.com/slides/hu/net/aspose.slides/ilayoutslide/hasdependingslides/) tulajdonságot vagy a [GetDependingSlides](https://reference.aspose.com/slides/hu/net/aspose.slides/ilayoutslide/getdependingslides/) metódust. Mielőtt meghívná az [ILayoutSlide.Remove](https://reference.aspose.com/slides/hu/net/aspose.slides/ilayoutslide/remove/) metódust, rendelje át a függő diákat. Egy használt elrendezés eltávolításának kísérlete [PptxEditException](https://reference.aspose.com/slides/hu/net/aspose.slides/pptxeditexception/) kivételt dob.

## **Lábléc Láthatóságának Szabályozása egy Elrendezés Dián**

Egy elrendezésnek saját lábléc, dia‑szám és dátum‑idő helykitöltői vannak. Használja az [ILayoutSlide.HeaderFooterManager](https://reference.aspose.com/slides/hu/net/aspose.slides/ilayoutslide/headerfootermanager/) tulajdonságot ezen helykitöltők egy elrendezésre való szabályozásához. Ez hasznos például, ha a tartalom elrendezéseknek láblécet kell mutatniuk, a címdia‑elrendezéseknek pedig nem.

A következő példa biztonságosan kiválaszt egy elrendezést, és láthatóvá teszi a lábléc elemeit:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");

var layoutSlide = presentation.LayoutSlides.GetByType(SlideLayoutType.TitleAndObject) ?? presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);

if (layoutSlide == null)
{
    throw new InvalidOperationException("The presentation does not contain a suitable layout slide.");
}

var headerFooterManager = layoutSlide.HeaderFooterManager;
headerFooterManager.SetFooterVisibility(true);
headerFooterManager.SetSlideNumberVisibility(true);
headerFooterManager.SetDateTimeVisibility(true);
headerFooterManager.SetFooterText("Footer text");
headerFooterManager.SetDateTimeText("Date and time text");

presentation.Save("output-with-layout-footers.pptx", SaveFormat.Pptx);
```

## **Lábléc Láthatóságának Szabályozása egy Mesteren és Gyermek Elrendezésein**

Az egységes lábléc beállítások alkalmazásához egy mesterhierarchiában használja az [IMasterSlide.HeaderFooterManager](https://reference.aspose.com/slides/hu/net/aspose.slides/imasterslide/headerfootermanager/) tulajdonságot. Az [IMasterSlideHeaderFooterManager](https://reference.aspose.com/slides/hu/net/aspose.slides/imasterslideheaderfootermanager/) terjesztési metódusai a mesterre, annak függő elrendezés-díáira és normál diáira hatnak; nem csak egyetlen normál diára céloznak.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");

var headerFooterManager = presentation.Masters[0].HeaderFooterManager;
headerFooterManager.SetFooterAndChildFootersVisibility(true);
headerFooterManager.SetSlideNumberAndChildSlideNumbersVisibility(true);
headerFooterManager.SetDateTimeAndChildDateTimesVisibility(true);
headerFooterManager.SetFooterAndChildFootersText("Footer text");
headerFooterManager.SetDateTimeAndChildDateTimesText("Date and time text");

presentation.Save("output-with-master-footers.pptx", SaveFormat.Pptx);
```

## **GYIK**

**Mi a különbség a mesterdia és az elrendezés dia között?**

A mesterdia definiálja a prezentáció témáját és a közös formázást. Egy elrendezés dia a mesterhez tartozik, és egy újrahasználható helykitöltő elrendezést határoz meg. A normál diák ezeket az elrendezéseket használják, és a dia‑specifikus tartalmat tárolják.

**Másolhatok elrendezés-diát egyik prezentációból a másikba?**

Igen. A [AddClone](https://reference.aspose.com/slides/hu/net/aspose.slides/globallayoutslidecollection/addclone/) metódussal adjon egy másolatot a célgyűjteményhez. Másoláskor ellenőrizze a betűtípusokat, témákat, képeket és a forrás elrendezés által használt egyéb erőforrásokat.

**Mi történik, ha módosítok egy már használt elrendezést?**

A függő diák öröklik az elrendezés módosításait, hacsak nem felülírják a formázást vagy az objektumokat helyileg. A helykitöltő geometria és az örökölt stílus ezért egyszerre sok dián változhat. Használja a [GetDependingSlides](https://reference.aspose.com/slides/hu/net/aspose.slides/ilayoutslide/getdependingslides/) metódust, hogy azonosítsa az érintett diákot, mielőtt szerkesztené az elrendezést.

**Mi történik, ha eltávolítok egy még használatban lévő elrendezést?**

Az Aspose.Slides [PptxEditException](https://reference.aspose.com/slides/hu/net/aspose.slides/pptxeditexception/) kivételt dob. Először rendelje át a függő diákat, vagy használja a [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/hu/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) metódust, hogy csak a nem hivatkozott elrendezéseket távolítsa el.
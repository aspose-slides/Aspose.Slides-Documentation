---
title: Diaelrendezések alkalmazása vagy módosítása .NET-ben
linktitle: Diaelrendezés
type: docs
weight: 60
url: /hu/net/slide-layout/
keywords:
- diaelrendezés
- tartalomelrendezés
- helyőrző
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
description: "Diaelrendezések alkalmazása, létrehozása és módosítása az Aspose.Slides for .NET-ben, helyőrzők hozzáadása, nem használt elrendezések eltávolítása és a lábléc láthatóságának szabályozása."
---
## **Áttekintés**

A diaelrendezés meghatározza a helyőrzők, például címek, szöveg, képek, diagramok és táblázatok pozícióit és formázását. Az elrendezés alkalmazása következetes szerkezetet biztosít a diák számára, miközben lehetővé teszi, hogy minden dia saját tartalmat tartalmazzon.

A leggyakoribb elrendezések a következők:

- **Címdiára**: Tartalmazza a cím és alcím helyőrzőit.
- **Cím és Tartalom**: Tartalmaz egy cím helyőrzőt és egy általános célú tartalom helyőrzőt.
- **Üres**: Nem tartalmaz tartalomhelyőrzőket, és akkor hasznos, ha minden alakzatot manuálisan helyezünk el.

## **Az elrendezés öröklődésének megértése**

Egy prezentációnak három kapcsolódó szintje van:

1. A [master slide](https://reference.aspose.com/slides/hu/net/aspose.slides/imasterslide/) meghatározza a témát, a közös formázást, a háttérképeket és a közös objektumokat.
1. A [layout slide](https://reference.aspose.com/slides/hu/net/aspose.slides/ilayoutslide/) egy masterhez tartozik, és meghatároz egy adott helyőrző elrendezést.
1. A [normal slide](https://reference.aspose.com/slides/hu/net/aspose.slides/islide/) egy elrendezést használ, és tárolja az adott dia számára bevitt tartalmat.

A normál dia a témát és a formázást a saját elrendezéséből örökli, az elrendezés pedig a masterből. A normál dián közvetlenül beállított érték felülírja az örökölt értéket ezen a szinten. Amikor egy normál diát létrehoznak, a helyőrző alakzatok a kiválasztott elrendezésből generálódnak, míg a helyőrzőkbe bevitt tartalom a normál diához tartozik.

Adjon hozzá szükséges helyőrzőket egy elrendezéshez, mielőtt diák készülnek belőle. Egy másik helyőrző későbbi hozzáadása az elrendezéshez nem ad automatikusan megfelelő helyőrző alakzatot a meglévő normál diákhoz.

Ennek a kapcsolatnak két fontos következménye van:

- Az örökölt formázás vagy egy meglévő helyőrző geometria megváltoztatása egy elrendezésen frissítheti az összes tőle függő diát. Mielőtt egy már használt elrendezést szerkesztenénk, ellenőrizzük a függő diákot és tekintsük át a keletkezett prezentációt.
- Olyan elrendezést, amelyet még egy dia használ, nem lehet eltávolítani. Először rendelje át a hozzá tartozó diát egy másik elrendezésre, vagy csak a nem használt elrendezéseket távolítsa el.

További információkért a hierarchia legfelső szintjéről, lásd a [Slide Master](/slides/hu/net/slide-master/) oldalt.

Az örökölt logók vagy dekoratív master alakzatok elrejtéséhez egy dián vagy egy megosztott elrendezésen keresztül, lásd a [Control the Visibility of Master Graphics](/slides/hu/net/slide-master/) oldalt. A példa két, ugyanazt a mastert használó diát hasonlít össze.

## **Diaelrendezés kiválasztása és alkalmazása**

Használjon elrendezéstípust, amikor a prezentáció a szabványos PowerPoint elrendezésdefiníciókat követi. Az elrendezésneveket a felhasználó szerkesztheti és lokalizálhatja, ezért a név alapú kiválasztás kevésbé megbízható, hacsak nem a forrás sablont irányítja.

Az alábbi példa a **Title and Content** elrendezést keresi az első masterben. Ha ez az elrendezés nem érhető el, szándékosan a **Blank** elrendezésre tér vissza. A második null ellenőrzés szükséges, mivel egy prezentáció csak egyedi elrendezéseket tartalmazhat. A kiválasztott elrendezés ezután alkalmazásra kerül az első normál diára a [ISlide.LayoutSlide](https://reference.aspose.com/slides/hu/net/aspose.slides/islide/layoutslide/) tulajdonságon keresztül.

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

Egy dia elrendezésének megváltoztatása nem távolítja el a dia közvetlenül hozzáadott normál alakzatokat. Azonban a helyőrzők pozíciója, az örökölt formázás és a meglévő helyőrzők és az új elrendezés közötti megfelelés változhat, ezért ellenőrizze a kimenetet, amikor jelentősen eltérő elrendezések között vált.

## **Elrendezésdia hozzáadása**

A kiválasztás és a létrehozás külön műveletek. Az előző példa egy meglévő elrendezést választ ki; nem hoz létre újat. Egy elrendezés létrehozásához hívja meg a [IMasterLayoutSlideCollection.Add](https://reference.aspose.com/slides/hu/net/aspose.slides/masterlayoutslidecollection/add/) metódust a cél master elrendezésgyűjteményén.

Az alábbi példa mindig hozzáad egy új **Title and Content** elrendezést `Report Title and Content` névvel, majd egy normál diát ad hozzá, amely ezt használja. Az elrendezésneveknek egyedieknek kell lenniük a gyűjteményen belül.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");

var masterSlide = presentation.Masters[0];
var reportLayout = masterSlide.LayoutSlides.Add(SlideLayoutType.TitleAndObject, "Report Title and Content");
presentation.Slides.AddEmptySlide(reportLayout);

presentation.Save("output-with-report-layout.pptx", SaveFormat.Pptx);
```

Csak akkor adjon hozzá elrendezést, ha a sablon valóban egy újra felhasználható struktúrát igényel. Ha már létezik megfelelő elrendezés, válassza ki és használja újra ahelyett, hogy másolatot hozna létre.

## **Helyőrzők hozzáadása egy elrendezésdiához**

A [ILayoutSlide.PlaceholderManager](https://reference.aspose.com/slides/hu/net/aspose.slides/ilayoutslide/placeholdermanager/) property provides an [ILayoutPlaceholderManager](https://reference.aspose.com/slides/hu/net/aspose.slides/ilayoutplaceholdermanager/) for adding placeholder shapes to a layout.

| PowerPoint helyőrző | `ILayoutPlaceholderManager` metódus |
| ------------------- | ----------------------------------- |
| ![Tartalom](content.png) | [`AddContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hu/net/aspose.slides/layoutplaceholdermanager/addcontentplaceholder/) |
| ![Tartalom (Függőleges)](contentV.png) | [`AddVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hu/net/aspose.slides/layoutplaceholdermanager/addverticalcontentplaceholder/) |
| ![Szöveg](text.png) | [`AddTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hu/net/aspose.slides/layoutplaceholdermanager/addtextplaceholder/) |
| ![Szöveg (Függőleges)](textV.png) | [`AddVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hu/net/aspose.slides/layoutplaceholdermanager/addverticaltextplaceholder/) |
| ![Kép](picture.png) | [`AddPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hu/net/aspose.slides/layoutplaceholdermanager/addpictureplaceholder/) |
| ![Diagram](chart.png) | [`AddChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hu/net/aspose.slides/layoutplaceholdermanager/addchartplaceholder/) |
| ![Táblázat](table.png) | [`AddTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hu/net/aspose.slides/layoutplaceholdermanager/addtableplaceholder/) |
| ![SmartArt](smartart.png) | [`AddSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hu/net/aspose.slides/layoutplaceholdermanager/addsmartartplaceholder/) |
| ![Média](media.png) | [`AddMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hu/net/aspose.slides/layoutplaceholdermanager/addmediaplaceholder/) |
| ![Online kép](onlineImage.png) | [`AddOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hu/net/aspose.slides/layoutplaceholdermanager/addonlineimageplaceholder/) |

Az alábbi példa ellenőrzi, hogy a **Blank** elrendezés létezik-e, négy helyőrzőt ad hozzá, majd egy normál diát hoz létre, amely a módosított elrendezést használja. A sorrend szándékos: a helyőrzőket a normál dia létrehozása előtt adják hozzá, így az Aspose.Slides képes a megfelelő helyőrző alakzatokat létrehozni azon a dián.

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

![A helyőrzők az elrendezésdiai](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
Az örökölt formázás vagy a meglévő elrendezéshelyőrzők geometria megváltoztatása befolyásolhatja a függő diákat. Egy újonnan hozzáadott elrendezéshelyőrző nem kerül visszatöltésre a meglévő normál diákba. Tesztelje az elrendezésváltozásokat egy prezentáció másolatán, és ellenőrizze minden függő diát.
{{% /alert %}}

## **Használaton kívüli elrendezésdiák eltávolítása**

Használja a [Compress.RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/hu/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) metódust a olyan elrendezések eltávolításához, amelyeket egyetlen normál dia sem hivatkozik. A metódus érintetlenül hagyja azokat az elrendezéseket, amelyek még használatban vannak.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");

Compress.RemoveUnusedLayoutSlides(presentation);
presentation.Save("output-without-unused-layouts.pptx", SaveFormat.Pptx);
```

Egy konkrét elrendezés eltávolításához először használja a [HasDependingSlides](https://reference.aspose.com/slides/hu/net/aspose.slides/ilayoutslide/hasdependingslides/) property vagy a [GetDependingSlides](https://reference.aspose.com/slides/hu/net/aspose.slides/ilayoutslide/getdependingslides/) metódust. A [ILayoutSlide.Remove](https://reference.aspose.com/slides/hu/net/aspose.slides/ilayoutslide/remove/) hívása előtt rendelje át a függő diákot. Egy használt elrendezés eltávolítására kísérlet [PptxEditException](https://reference.aspose.com/slides/hu/net/aspose.slides/pptxeditexception/)-t vált ki.

## **Lábléc láthatóságának vezérlése egy elrendezésdian**

Egy elrendezés saját lábléc, dia-szám és dátum-idő helyőrzőkkel rendelkezik. Használja a [ILayoutSlide.HeaderFooterManager](https://reference.aspose.com/slides/hu/net/aspose.slides/ilayoutslide/headerfootermanager/) property-t ezeknek a helyőrzőknek a vezérlésére egyetlen elrendezésnél. Ez hasznos például, ha a tartalom elrendezéseknek láblécet kell mutatniuk, míg a cím elrendezéseknek nem.

Az alábbi példa egy elrendezést biztonságosan választ ki, és láthatóvá teszi annak lábléc elemeit:

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

## **Lábléc láthatóságának vezérlése egy masteren és annak gyermek elrendezésein**

A következetes lábléc beállítások alkalmazásához egy master hierarchián belül használja a [IMasterSlide.HeaderFooterManager](https://reference.aspose.com/slides/hu/net/aspose.slides/imasterslide/headerfootermanager/) property-t. A [IMasterSlideHeaderFooterManager](https://reference.aspose.com/slides/hu/net/aspose.slides/imasterslideheaderfootermanager/) propagációs metódusai a masterre, annak függő elrendezésdiáira és normál diasoraira hatnak; nem csak egyetlen normál diára céloznak.

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

## **FAQ**

**Mi a különbség a master diák és az elrendezésdia között?**

A master slide meghatározza a prezentáció témáját és a közös formázást. Az elrendezésdia egy masterhez tartozik, és egy újra felhasználható helyőrző elrendezést határoz meg. A normál diák ezeket az elrendezéseket használják, és a diára jellemző tartalmat tárolják.

**Átmásolhatok egy elrendezésdiát egy prezentációról a másikra?**

Igen. Egy másolatot adjon a célgyűjteményhez az [AddClone](https://reference.aspose.com/slides/hu/net/aspose.slides/globallayoutslidecollection/addclone/) metódussal. Másoláskor prezentációk között ellenőrizze a betűtípusokat, témákat, képeket és egyéb források használatát, amelyeket a forráselrendezés használ.

**Mi történik, ha módosítok egy már használatban lévő elrendezést?**

A függő diák öröklik az elrendezés módosításait, hacsak helyben nem írják felül az érintett formázást vagy objektumokat. Így a helyőrző geometria és az örökölt stílus sok dián egyszerre változhat. Használja a [GetDependingSlides](https://reference.aspose.com/slides/hu/net/aspose.slides/ilayoutslide/getdependingslides/) metódust a módosított diák azonosításához, mielőtt szerkesztené az elrendezést.

**Mi történik, ha eltávolítok egy még használatban lévő elrendezést?**

Az Aspose.Slides [PptxEditException](https://reference.aspose.com/slides/hu/net/aspose.slides/pptxeditexception/)-t dob. Először rendelje át a függő diákot, vagy használja a [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/hu/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) metódust, hogy csak a nem hivatkozott elrendezéseket távolítsa el.
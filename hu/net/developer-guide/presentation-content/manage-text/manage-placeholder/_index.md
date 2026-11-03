---
title: Prezentációhelyőrzők kezelése .NET-ben
linktitle: Helyőrzők kezelése
type: docs
weight: 10
url: /hu/net/manage-placeholder/
keywords:
- helyőrző
- szöveges helyőrző
- kép helyőrző
- diagram helyőrző
- tartalom helyőrző
- prompt szöveg
- PowerPoint
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Ismerje meg, hogyan ellenőrizheti és szerkesztheti a szöveg, kép, diagram és tartalom helyőrzőket, valamint hogyan értheti meg a helyőrző öröklődést az Aspose.Slides for .NET segítségével."
---
## **Áttekintés**

A helyőrző egy alakzat, amely helyet foglal le a bemutató sablonban egy adott típusú tartalom számára. Gyakori példák a cím, törzs, kép, diagram és általános célú tartalom helyőrzői. Egy egyszerű alakzattól eltérően a helyőrző örökölheti pozícióját, méretét, formázását és egyéb beállításait egy elrendezési vagy mester diától.

Az Aspose.Slides a [IShape.Placeholder](https://reference.aspose.com/slides/net/aspose.slides/ishape/placeholder/) tulajdonságon keresztül teszi elérhetővé a helyőrző információkat. A tulajdonság egy [IPlaceholder](https://reference.aspose.com/slides/net/aspose.slides/iplaceholder/) objektumot ad vissza, vagy `null`‑t egy normál alakzat esetén. Használja az [IPlaceholder.Type](https://reference.aspose.com/slides/net/aspose.slides/iplaceholder/type/) értékét annak meghatározásához, hogy milyen tartalmat szántak a helyőrzőnek.

Az alakzat interfész még mindig fontos, miután ismeri a helyőrző típusát:

- Egy üres szöveg, kép, diagram vagy tartalom helyőrző általában egy [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) által van képviselve.
- Egy kitöltött kép helyőrző egy [IPictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ipictureframe/) által képviselhető.
- Egy kitöltött diagram helyőrző egy [IChart](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/) által képviselhető.
- Egy tartalom helyőrző többféle tartalmat is tartalmazhat. Ellenőrizze az [IPlaceholder.Type](https://reference.aspose.com/slides/net/aspose.slides/iplaceholder/type/) és a futásidejű alakzat interfészt is, ahelyett, hogy azt feltételezné, hogy minden helyőrző egy [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/).

{{% alert color="warning" title="Warning" %}}
[IPlaceholder.Type](https://reference.aspose.com/slides/net/aspose.slides/iplaceholder/type/) leírja a helyőrző szerepét; nem garantálja az alakzat futásidejű típusát. Mindig végezzen típusellenőrzést a szöveg, kép, diagram, táblázat vagy média‑specifikus tagok elérése előtt.
{{% /alert %}}

## **A helyőrző öröklődés megértése**

A helyőrzők hierarchiát alkotnak:

1. A mesterszintű dia definiálja az újrahasznosítható stílusokat, és egyes esetekben a mesterszintű helyőrzőket.
2. Az elrendezési dia definiálja a kiosztást, amelyet egy vagy több normál dia használ, és örökölhet a mestertől.
3. Egy normál dia tartalmazza az adott dia helyőrzőit, és örökölhet az elrendezéséből.

Hívja a [IShape.GetBasePlaceholder](https://reference.aspose.com/slides/net/aspose.slides/ishape/getbaseplaceholder/) metódust, hogy egy szinttel feljebb lépjen ebben a hierarchiában. Egy diahelyőrző általában visszaadja az elrendezési helyőrzőt; egy elrendezési helyőrző visszaadhatja a mester helyőrzőt. A metódus `null`‑t ad, ha az alakzatnak nincs alaphelyőrzője.

A következő példa felsorolja az első dián lévő helyőrzőket, és jelentést készít azok alaphelyőrzőiről:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("template.pptx");
var slide = presentation.Slides[0];

foreach (var shape in slide.Shapes)
{
    if (shape.Placeholder == null)
    {
        continue;
    }

    var placeholderType = shape.Placeholder.Type;
    var typeName = shape.GetType().Name;
    Console.WriteLine($"Slide placeholder: {placeholderType}; shape interface: {typeName}");

    var layoutPlaceholder = shape.GetBasePlaceholder();
    if (layoutPlaceholder != null)
    {
        var layoutPlaceholderType = layoutPlaceholder.Placeholder?.Type;
        Console.WriteLine($"  Layout placeholder: {layoutPlaceholderType}");

        var masterPlaceholder = layoutPlaceholder.GetBasePlaceholder();
        if (masterPlaceholder != null)
        {
            var masterPlaceholderType = masterPlaceholder.Placeholder?.Type;
            Console.WriteLine($"  Master placeholder: {masterPlaceholderType}");
        }
    }
}
```

Egy normál dián lévő helyőrző szerkesztése helyi felülbírálást hoz létre vagy módosít az adott diához. A kapcsolódó elrendezés vagy mester szerkesztése hatással lehet az összes diára, amely még örökli ezt a beállítást. Egy helyi egyszerű alakzatnak nincs alaphelyőrzője, és nem kezd el örökölni csak azért, mert ugyanazokat a koordinátákat foglalja el.

## **Helyőrző állapot eltávolítása**

Sablon módosításakor használja a [IShape.RemovePlaceholder](https://reference.aspose.com/slides/net/aspose.slides/ishape/removeplaceholder/) metódust, hogy egy meglévő objektumot egyszerű alakzatként tartson meg. A [Placeholder](https://reference.aspose.com/slides/net/aspose.slides/ishape/placeholder/) tulajdonsága `null`‑ra változik, de az alakzat a dia gyűjteményében marad. Ezzel szemben a [IShapeCollection.Remove](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/remove/) törli az alakzatot a gyűjteményből.

A következő példához `template.pptx` fájlra van szükség, amely legalább egy diát és egy nem üres szöveghelyőrzőt tartalmaz az első dián. Használjon egy olyan helyőrzőt, amelynek formázása az elrendezésből vagy a mesterből öröklődik, hogy lássa a kapcsolat eltávolításának hatását. A példa ellenőrzi, hogy ugyanaz az alakzat megmarad, újból meghívja a metódust a most már egyszerű alakzatra, és elmenti az eredményt.

{{% alert color="warning" title="Warning" %}}
A helyőrző állapot eltávolítása nem őrzi meg automatikusan az örökölt megjelenési beállításokat. Az alábbi példa szándékosan változatlanul hagyja ezeket a beállításokat, ezért a kimenet eltérő lehet. Egy teljesen örökölt pozícióval és mérettel rendelkező alakzat a hívás után nulla koordinátákat és méreteket kaphat, és láthatatlanná válhat, még ha továbbra is a gyűjteményben marad is.
{{% /alert %}}

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("template.pptx");
var slide = presentation.Slides[0];
var found = false;

for (var index = 0; index < slide.Shapes.Count; index++)
{
    if (slide.Shapes[index] is not IAutoShape shape || 
        shape.Placeholder == null || 
        string.IsNullOrEmpty(shape.TextFrame?.Text))
    {
        continue;
    }

    var shapeCount = slide.Shapes.Count;
    shape.RemovePlaceholder();

    Console.WriteLine($"Placeholder removed: {shape.Placeholder == null}");
    Console.WriteLine($"Same shape retained: {ReferenceEquals(slide.Shapes[index], shape)}");
    Console.WriteLine($"Shape count unchanged: {slide.Shapes.Count == shapeCount}");

    // Az egyszerű alakzaton a metódus hívása nem jár hatással.
    shape.RemovePlaceholder();
    found = true;
    break;
}

if (found)
{
    presentation.Save("placeholder-status-removed.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("No nonempty text placeholder was found on the first slide.");
}
```

Egy egyező helyőrző esetén mindhárom ellenőrzés `True` értéket ad. A szöveg megmarad, de az örökölt pozíció, méret, forgatás, betűtípus, bekezdésigazítás, szövegdoboz margók, függőleges rögzítés, kitöltés és vonal beállítások megváltozhatnak, amikor a helyőrző kapcsolatot eltávolítják. Például az örökölt címsor formázása visszatérhet az egyszerű szövegformázáshoz. További információkért az elrendezésekről lásd a [Slide Layout](/slides/hu/net/slide-layout/) oldalt.

A kívánt megjelenés megőrzéséhez a hívás előtt rögzítse a feloldott pozíciót, méretet és forgatást, és másolja a szükséges hatékony formázási értékeket külön változókba. Ezeket az értékeket a [IPortionFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/iportionformat/geteffective/), [IParagraphFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/geteffective/), [ITextFrameFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/geteffective/), [IFillFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/geteffective/), és [ILineFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/geteffective/) segítségével szerezze be. Ne támaszkodjon csak a hatékony formátum objektumok megtartására, mivel a szövegformázási értékek a kapcsolat eltávolítása után megváltozhatnak. Kifejezetten alkalmazza a rögzített értékeket a egyszerű alakzatra ezután, beleértve a betűcsaládot, méretet, stílust, színt, bekezdésbeállításokat, szövegdoboz beállításokat, kitöltést és vonalat, amelyet a sablon használ.

Az örökölt alakzat geometriáját is explicit módon kell hozzárendelni a [IGeometryShape.ShapeType](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/shapetype/) segítségével. Egy téglalap alakú szöveghelyőrző esetén ez a [ShapeType.Rectangle](https://reference.aspose.com/slides/net/aspose.slides/shapetype/) beállítását jelenti; csak a kitöltés és vonal helyreállítása nem biztos, hogy visszaállítja a látható téglalapot. A további hatásokat vagy összetettebb formázást tartalmazó sablonok esetén ezeket a beállításokat is kezelni kell.

## **Szöveg módosítása egy helyőrzőben**

A cím, középre igazított cím, alcím, törzs és szöveghelyőrzők általában támogatják a szöveget. Ellenőrizze, hogy egy [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) van‑e, mielőtt a [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/textframe/) tulajdonságát használja.

Ez a példa frissíti az első dia első címhelyőrzőjét, és elmenti az eredményt:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("template.pptx");
var slide = presentation.Slides[0];
IAutoShape? titleShape = null;

foreach (var shape in slide.Shapes)
{
    if (shape is not IAutoShape autoShape || autoShape.Placeholder == null)
    {
        continue;
    }

    var placeholderType = autoShape.Placeholder.Type;
    if (placeholderType == PlaceholderType.Title || placeholderType == PlaceholderType.CenteredTitle)
    {
        titleShape = autoShape;
        break;
    }
}

if (titleShape == null)
{
    throw new InvalidOperationException("The first slide does not contain a title placeholder.");
}

titleShape.TextFrame.Text = "Quarterly Business Review";
presentation.Save("title-placeholder-updated.pptx", SaveFormat.Pptx);
```

Ez a minta elkerüli a kép, diagram, táblázat vagy média helyőrzők [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) típusra való átkasztását. Emellett a helyőrzőt a célja alapján azonosítja, ahelyett, hogy egy törékeny alakzat indexre támaszkodna.

## **Prompt szöveg beállítása az elrendezésen**

A prompt szöveg egy tervezési‑időbeli utasítás, amely egy üres helyőrzőben jelenik meg, például *Kattintson a cím hozzáadásához*. Állítson be egyedi prompt szöveget az elrendezési helyőrzőn, ahelyett, hogy egy normál dia alakzategyűjteményén keresztül próbálná elérni. Az elrendezéshez férjen hozzá a [ISlide.LayoutSlide](https://reference.aspose.com/slides/net/aspose.slides/islide/layoutslide/) segítségével, és iteráljon a [ILayoutSlide.Shapes](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/shapes/) elemein.

A következő példa megváltoztatja a cím és alcím promptjait az első dia által használt elrendezésen:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("template.pptx");
var layoutSlide = presentation.Slides[0].LayoutSlide;

foreach (var shape in layoutSlide.Shapes)
{
    if (shape is not IAutoShape autoShape || autoShape.Placeholder == null)
    {
        continue;
    }

    switch (autoShape.Placeholder.Type)
    {
        case PlaceholderType.Title:
        case PlaceholderType.CenteredTitle:
            autoShape.TextFrame.Text = "Enter a concise slide title";
            break;
        case PlaceholderType.Subtitle:
            autoShape.TextFrame.Text = "Enter a subtitle or reporting period";
            break;
    }
}

presentation.Save("custom-placeholder-prompts.pptx", SaveFormat.Pptx);
```

A prompt szöveg nem normál dia tartalom. Üres helyőrzők számára készült szerkesztőalkalmazásokban, például a PowerPointban. Amint a felhasználó vagy program valódi tartalmat ad meg, a prompt már nem jelenik meg. A prompt módosítása nem helyettesíti a már létező szöveget azokat a diákon, amelyek az elrendezést használják.

## **Kép helyőrző frissítése**

Két esetet kell kezelni:

- Ha a kép helyőrző már ki van töltve és egy [IPictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ipictureframe/) által van képviselve, cserélje ki a képet a [IPictureFillFormat.Picture](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/picture/) és a [ISlidesPicture.Image](https://reference.aspose.com/slides/net/aspose.slides/islidespicture/image/) segítségével.
- Ha még üres helyőrző, adjon egy képkeretet a helyőrző koordinátáihoz a [IShapeCollection.AddPictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addpictureframe/) segítségével, és távolítsa el az üres helyőrzőt.

A következő példa mindkét esetet támogatja, és elmenti a prezentációt:

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("picture-template.pptx");
var slide = presentation.Slides[0];
IShape? picturePlaceholder = null;

foreach (var shape in slide.Shapes)
{
    if (shape.Placeholder?.Type == PlaceholderType.Picture)
    {
        picturePlaceholder = shape;
        break;
    }
}

if (picturePlaceholder == null)
{
    throw new InvalidOperationException("The first slide does not contain a picture placeholder.");
}

var imageBytes = File.ReadAllBytes("replacement.png");
var image = presentation.Images.AddImage(imageBytes);

if (picturePlaceholder is IPictureFrame pictureFrame)
{
    pictureFrame.PictureFormat.Picture.Image = image;
}
else
{
    slide.Shapes.AddPictureFrame(ShapeType.Rectangle, picturePlaceholder.X, picturePlaceholder.Y, picturePlaceholder.Width, picturePlaceholder.Height, image);
    slide.Shapes.Remove(picturePlaceholder);
}

presentation.Save("picture-placeholder-updated.pptx", SaveFormat.Pptx);
```

Az üres helyőrzőhöz létrehozott csere egy helyi képkeret, nem új helyőrző, mivel az [IShape.Placeholder](https://reference.aspose.com/slides/net/aspose.slides/ishape/placeholder/) csak olvasható. Megőrzi a fenntartott pozíciót, de már nem örököl a helyőrző‑specifikus viselkedést. Ha a helyőrző kapcsolat megőrzése lényeges, először készítse el és töltse ki a helyőrzőt a PowerPointban, majd frissítse a keletkezett [IPictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ipictureframe/) elemet az Aspose.Slides használatával.

Az átlátszóság, vágás és egyéb kép‑specifikus hatások kezeléséhez lásd a [Manage Picture Frames](/slides/hu/net/picture-frame/) oldalt. Ezek a műveletek a képkerethez vagy a kép kitöltéséhez tartoznak, nem a helyőrző metaadataihoz.

## **Diagram és tartalom helyőrzőkkel való munka**

Egy kitöltött diagram helyőrző egy [IChart](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/) által van képviselve. Ez a példa megtalálja az ilyen diagramot a helyőrző típus és a futásidejű interfész alapján, megváltoztatja a címét, és elmenti a fájlt:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("chart-template.pptx");
var slide = presentation.Slides[0];
IChart? placeholderChart = null;

foreach (var shape in slide.Shapes)
{
    if (shape is IChart chart && shape.Placeholder?.Type == PlaceholderType.Chart)
    {
        placeholderChart = chart;
        break;
    }
}

if (placeholderChart == null)
{
    throw new InvalidOperationException("The first slide does not contain a populated chart placeholder.");
}

placeholderChart.HasTitle = true;
placeholderChart.ChartTitle.AddTextFrameForOverriding("Quarterly Revenue");
presentation.Save("chart-placeholder-updated.pptx", SaveFormat.Pptx);
```

Egy általános tartalom helyőrző általában a [PlaceholderType.Object](https://reference.aspose.com/slides/net/aspose.slides/placeholdertype/) típust használja. A PowerPointban ez többféle tartalomtípus indítójaként működik, beleértve a diagramokat, táblázatokat, diagramokat, képeket és médiát. Miután kitöltötték, vizsgálja meg a tényleges alakzat interfészt, hogy megtudja, mit tartalmaz. Specializált elrendezések is kiteszik a [PlaceholderType.Chart](https://reference.aspose.com/slides/net/aspose.slides/placeholdertype/), [PlaceholderType.Table](https://reference.aspose.com/slides/net/aspose.slides/placeholdertype/), [PlaceholderType.Picture](https://reference.aspose.com/slides/net/aspose.slides/placeholdertype/), [PlaceholderType.Media](https://reference.aspose.com/slides/net/aspose.slides/placeholdertype/), vagy [PlaceholderType.Diagram](https://reference.aspose.com/slides/net/aspose.slides/placeholdertype/) típusokat.

Az Aspose.Slides nem alakítja át egy üres [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) helyőrzőt egy [IChart](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/) típusra egyszerűen az [IPlaceholder.Type](https://reference.aspose.com/slides/net/aspose.slides/iplaceholder/type/) módosításával; a típus csak olvasható. Egy üres diagram vagy tartalomterület programozott feltöltéséhez adja hozzá a szükséges objektumot a helyőrző koordinátáihoz, majd távolítsa el az üres helyőrzőt. A következő példa ezt egy diagram esetében mutatja be:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("content-template.pptx");
var slide = presentation.Slides[0];
IShape? targetPlaceholder = null;

foreach (var shape in slide.Shapes)
{
    if (shape.Placeholder?.Type is PlaceholderType.Chart or PlaceholderType.Object)
    {
        targetPlaceholder = shape;
        break;
    }
}

if (targetPlaceholder == null)
{
    throw new InvalidOperationException("The first slide does not contain a chart or content placeholder.");
}

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, targetPlaceholder.X, targetPlaceholder.Y, targetPlaceholder.Width, targetPlaceholder.Height);
chart.HasTitle = true;
chart.ChartTitle.AddTextFrameForOverriding("Quarterly Revenue");
slide.Shapes.Remove(targetPlaceholder);
presentation.Save("content-placeholder-replaced-with-chart.pptx", SaveFormat.Pptx);
```

A hozzáadott diagram egy egyszerű helyi diagram. Elfoglalja a helyőrző területét, de nem örököl az elrendezési helyőrzőtől. Használja a dedikált [chart management articles](/slides/hu/net/powerpoint-charts/) cikkeket, amikor a kategóriákat, sorozatokat vagy munkafüzet adatokat kell cserélnie.

## **Teljes példa: Szöveg vagy kép tartalom frissítése**

A következő end-to-end példa megnyit egy sablont, az első dián keres egy cím‑ vagy képhelyőrzőt, ellenőrzi a helyőrző és az alakzat típusait, frissíti a megfelelő tartalmat, és elmenti a kimenetet. A példa szándékosan elkerüli a shape index feltételezését vagy minden helyőrző egyetlen interfészre való átkasztását.

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("template.pptx");
var slide = presentation.Slides[0];
var updated = false;

foreach (var shape in slide.Shapes)
{
    if (shape.Placeholder == null)
    {
        continue;
    }

    var placeholderType = shape.Placeholder.Type;

    if ((placeholderType == PlaceholderType.Title || placeholderType == PlaceholderType.CenteredTitle) && shape is IAutoShape titleShape)
    {
        titleShape.TextFrame.Text = "Quarterly Business Review";
        updated = true;
        break;
    }

    if (placeholderType == PlaceholderType.Picture)
    {
        var imageBytes = File.ReadAllBytes("replacement.png");
        var image = presentation.Images.AddImage(imageBytes);

        if (shape is IPictureFrame pictureFrame)
        {
            pictureFrame.PictureFormat.Picture.Image = image;
        }
        else
        {
            slide.Shapes.AddPictureFrame(ShapeType.Rectangle, shape.X, shape.Y, shape.Width, shape.Height, image);
            slide.Shapes.Remove(shape);
        }

        updated = true;
        break;
    }
}

if (!updated)
{
    throw new InvalidOperationException("No supported title or picture placeholder was found on the first slide.");
}

presentation.Save("placeholder-content-updated.pptx", SaveFormat.Pptx);
```

## **FAQ**

**Mi az az alaphelyőrző?**

Az alaphelyőrző az elrendezésen vagy a mesteren lévő megfelelő alakzat, amelyből egy másik helyőrző örököl. Használja a [IShape.GetBasePlaceholder](https://reference.aspose.com/slides/net/aspose.slides/ishape/getbaseplaceholder/) metódust a lekéréséhez. Egy egyszerű helyi alakzat `null`‑t ad vissza, mivel nem része a helyőrző hierarchiának.

**Módosíthatom az összes dia címét egy elrendezési helyőrző szerkesztésével?**

Az elrendezésen keresztül módosíthatja az örökölt formázást vagy a prompt szöveget, de a meglévő cím tartalma a normál diákon van tárolva. A tényleges cím szöveg cseréjéhez a prezentációban iteráljon a diákon, és frissítse minden címhelyőrzőt.

**Hogyan kezeljem a dátum, dia‑szám, fejléc és lábléc helyőrzőket?**

Használja a fejléc‑ és lábléckezelőket a megfelelő dián, elrendezésen, mesteren, jegyzeten vagy szórólap tartományban. Lásd a [Manage Presentation Header and Footer](/slides/hu/net/presentation-header-and-footer/) oldalt a teljes példákért.
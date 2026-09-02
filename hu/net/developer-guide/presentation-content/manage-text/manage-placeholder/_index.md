---
title: Prezentációhelyfoglalók kezelése .NET-ben
linktitle: Helyfoglalók kezelése
type: docs
weight: 10
url: /hu/net/manage-placeholder/
keywords:
- helyfoglaló
- szöveghelyfoglaló
- képhelyfoglaló
- diagramhelyfoglaló
- tartalomhelyfoglaló
- prompt szöveg
- PowerPoint
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Tanulja meg, hogyan ellenőrizze és szerkessze a szöveg, kép, diagram és tartalomhelyfoglalókat, és értsen meg a helyfoglalók öröklődését az Aspose.Slides .NET-hez."
---
## **Áttekintés**

A helyfoglaló egy alakzat, amely egy meghatározott típusú tartalom számára foglal helyet egy bemutató sablonban. Gyakori példák a cím, szövegtest, kép, diagram és általános célú tartalomhelyfoglalók. Egy szokásos alakzattól eltérően a helyfoglaló örökölheti a pozícióját, méretét, formázását és egyéb beállításait egy elrendezési diáról vagy mester diárról.

Az Aspose.Slides a helyfoglaló információkat a [IShape.Placeholder](https://reference.aspose.com/slides/hu/net/aspose.slides/ishape/placeholder/) tulajdonságon keresztül teszi elérhetővé. A tulajdonság egy [IPlaceholder](https://reference.aspose.com/slides/hu/net/aspose.slides/iplaceholder/) objektumot vagy `null`‑t ad vissza egy normál alakzatra. Használd a [IPlaceholder.Type](https://reference.aspose.com/slides/hu/net/aspose.slides/iplaceholder/type/) értéket annak meghatározásához, hogy a helyfoglaló milyen tartalmat vár.

Az alakzat interfészje továbbra is számít, miután ismered a helyfoglaló típusát:

- Egy üres szöveg, kép, diagram vagy tartalomhelyfoglaló általában egy [IAutoShape](https://reference.aspose.com/slides/hu/net/aspose.slides/iautoshape/) segítségével jelenik meg.
- Egy kitöltött képhelyfoglaló egy [IPictureFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/ipictureframe/) lehet.
- Egy kitöltött diagramhelyfoglaló egy [IChart](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichart/) lehet.
- Egy tartalomhelyfoglaló többféle tartalmat is tartalmazhat. Ellenőrizd mind a [IPlaceholder.Type](https://reference.aspose.com/slides/hu/net/aspose.slides/iplaceholder/type/), mind a futásidejű alakzat interfészét, ahelyett, hogy azt feltételeznéd, minden helyfoglaló egy [IAutoShape](https://reference.aspose.com/slides/hu/net/aspose.slides/iautoshape/).

{{% alert color="warning" title="Warning" %}}
[IPlaceholder.Type](https://reference.aspose.com/slides/hu/net/aspose.slides/iplaceholder/type/) egy helyfoglaló szerepét írja le; nem garantálja az alakzat futásidejű típusát. Mindig végezz típusellenőrzést, mielőtt szöveg, kép, diagram, táblázat vagy média‑specifikus tagokhoz férnél hozzá.
{{% /alert %}}

## **Helyfoglalók öröklődésének megértése**

A helyfoglalók hierarchiát alkotnak:

1. Egy mester dia újrahasználható stílusokat definiál, és egyes esetekben mester‑szintű helyfoglalókat is tartalmaz.
2. Egy elrendezési dia meghatározza a elrendezést, amelyet egy vagy több normál dia használ, és örökölhet a mestertől.
3. Egy normál dia tartalmazza a saját helyfoglalóit, és örökölhet az elrendezéséből.

Használd a [IShape.GetBasePlaceholder](https://reference.aspose.com/slides/hu/net/aspose.slides/ishape/getbaseplaceholder/) metódust a hierarchia egy szinttel feljebb lépéshez. Egy dia helyfoglalója általában visszaadja az elrendezési helyfoglalóját; egy elrendezési helyfoglaló visszaadhatja a mester helyfoglalóját. A metódus `null`‑t ad, ha az alakzatnak nincs alapterületű helyfoglalója.

A következő példa felsorolja az első dián lévő helyfoglalókat, és jelentést készít azok alapterületű helyfoglalóiról:

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

Egy helyfoglaló szerkesztése egy normál dián helyi felülírást hoz létre vagy módosít az adott diára. A kapcsolódó elrendezés vagy mester szerkesztése minden olyan dia esetén hatással lehet, amely még örökli azt a beállítást. Egy helyi egyszerű alakzatnak nincs alapterületű helyfoglalója, és nem kezd el örökölni csak azért, mert ugyanazokat a koordinátákat foglalja el.

## **Szöveg módosítása helyfoglalóban**

A cím, középre igazított cím, alcím, szövegtest és szöveghelyfoglalók általában támogatják a szöveget. Ellenőrizd, hogy [IAutoShape](https://reference.aspose.com/slides/hu/net/aspose.slides/iautoshape/) típusú-e, mielőtt a [TextFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/iautoshape/textframe/) tulajdonságát használnád.

Ez a példa frissíti az első címhelyfoglalót az első dián, és elmenti az eredményt:

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

Ez a minta elkerüli a kép-, diagram-, táblázat- vagy médiahelyfoglalók [IAutoShape](https://reference.aspose.com/slides/hu/net/aspose.slides/iautoshape/)-re való átkasztását. Emellett a helyfoglalót a célja alapján azonosítja, nem egy törékeny alakzat indexre támaszkodva.

## **Prompt szöveg beállítása elrendezésen**

A prompt szöveg egy tervezési‑időben megjelenő utasítás, amely egy üres helyfoglalóban jelenik meg, például *Kattintson a cím hozzáadásához*. Állíts be egyedi prompt szöveget az elrendezési helyfoglalón, ahelyett, hogy a normál dia alakzatekercsén keresztül próbálnád elérni. Az elrendezéshez a [ISlide.LayoutSlide](https://reference.aspose.com/slides/hu/net/aspose.slides/islide/layoutslide/) segítségével férhetsz hozzá, és iterálj a [ILayoutSlide.Shapes](https://reference.aspose.com/slides/hu/net/aspose.slides/ibaseslide/shapes/) gyűjteményén.

A következő példa megváltoztatja a cím és az alcím promptjait azon elrendezésen, amelyet az első dia használ:

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

A prompt szöveg nem normál dia tartalom. Az üres helyfoglalókhoz szerkesztő alkalmazásokban, például a PowerPointban készült. Amint a felhasználó vagy a program valós tartalmat ad meg, a prompt többé nem jelenik meg. A prompt módosítása nem írja felül a már meglévő szöveget az olyan diákon, amelyek használják az elrendezést.

## **Képhelyfoglaló frissítése**

Két esetet kell kezelni:

- Ha a képhelyfoglaló már ki van töltve, és egy [IPictureFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/ipictureframe/) képviseli, cseréld ki a képet a [IPictureFillFormat.Picture](https://reference.aspose.com/slides/hu/net/aspose.slides/ipicturefillformat/picture/) és az [ISlidesPicture.Image](https://reference.aspose.com/slides/hu/net/aspose.slides/islidespicture/image/) segítségével.
- Ha még üres helyfoglaló, adj hozzá egy képkeretet a helyfoglaló koordinátáihoz a [IShapeCollection.AddPictureFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/ishapecollection/addpictureframe/) segítségével, majd távolítsd el az üres helyfoglalót.

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

Az üres helyfoglalóhoz létrehozott csere egy helyi képkeret, nem új helyfoglaló, mert a [IShape.Placeholder](https://reference.aspose.com/slides/hu/net/aspose.slides/ishape/placeholder/) csak olvasható. Megtartja a lefoglalt pozíciót, de már nem örököl helyfoglaló‑specifikus viselkedést. Ha a helyfoglaló kapcsolat megtartása lényeges, először PowerPointban hozd létre és töltsd ki a helyfoglalót, majd frissítsd a kapott [IPictureFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/ipictureframe/) objektumot az Aspose.Slides‑szel.

A kép átlátszóságával, vágásával és egyéb kép‑specifikus hatásaival kapcsolatos információkért tekintsd meg a [Manage Picture Frames](/slides/hu/net/picture-frame/) dokumentumot. Ezek a műveletek a képkereten vagy a kép kitöltésén hajtódnak végre, nem a helyfoglaló metaadataikon.

## **Diagram- és tartalomhelyfoglalók kezelése**

Egy kitöltött diagramhelyfoglaló egy [IChart](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichart/) lehet. Ez a példa mind a helyfoglaló típusa, mind a futásidejű interfész alapján megtalálja a diagramot, megváltoztatja a címét, és elmenti a fájlt:

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

Egy általános tartalomhelyfoglaló általában a [PlaceholderType.Object](https://reference.aspose.com/slides/hu/net/aspose.slides/placeholdertype/) értékkel rendelkezik. A PowerPointban ez egy indítóként működik többféle tartalomtípushoz, beleértve a diagramokat, táblázatokat, diagrammákat, képeket és médiát. Miután kitöltötték, vizsgáld meg a tényleges alakzat interfészét, hogy megtudd, mit tartalmaz. Specializált elrendezések a [PlaceholderType.Chart](https://reference.aspose.com/slides/hu/net/aspose.slides/placeholdertype/), [PlaceholderType.Table](https://reference.aspose.com/slides/hu/net/aspose.slides/placeholdertype/), [PlaceholderType.Picture](https://reference.aspose.com/slides/hu/net/aspose.slides/placeholdertype/), [PlaceholderType.Media](https://reference.aspose.com/slides/hu/net/aspose.slides/placeholdertype/), vagy [PlaceholderType.Diagram](https://reference.aspose.com/slides/hu/net/aspose.slides/placeholdertype/) típusokat is kiexponálhatják.

Az Aspose.Slides nem konvertál egy üres [IAutoShape](https://reference.aspose.com/slides/hu/net/aspose.slides/iautoshape/) helyfoglalót [IChart](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichart/)-ra pusztán a [IPlaceholder.Type](https://reference.aspose.com/slides/hu/net/aspose.slides/iplaceholder/type/) módosításával; a típus csak olvasható. Egy üres diagram vagy tartalomterület programozott feltöltéséhez add hozzá a szükséges objektumot a helyfoglaló koordinátáihoz, majd távolítsd el az üres helyfoglalót. A következő példa ezt végzi egy diagram esetében:

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

A hozzáadott diagram egy egyszerű helyi diagram. Elfoglalja a helyfoglaló területét, de nem örököl az elrendezési helyfoglalóból. Használd a dedikált [chart management articles](/slides/hu/net/powerpoint-charts/) anyagokat, ha cserélni kell a kategóriákat, sorozatokat vagy munkafüzet adatokat.

## **Teljes példa: Szöveg vagy kép tartalom frissítése**

Az alábbi végponttól‑végpontig terjedő példa megnyit egy sablont, az első dián keres egy cím‑ vagy képhelyfoglalót, ellenőrzi a helyfoglaló és alakzat típusát, frissíti a megfelelő tartalmat, és elmenti a kimenetet. A példa kifejezetten kerül minden alakzat index vagy minden helyfoglaló egységes interfészre való átkasztását.

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

## **GYIK**

**Mi az alapterületű (base) helyfoglaló?**

Egy alapterületű helyfoglaló az elrendezésen vagy a mesteren lévő megfelelő alakzat, amelyből egy másik helyfoglaló örököl. Használd a [IShape.GetBasePlaceholder](https://reference.aspose.com/slides/hu/net/aspose.slides/ishape/getbaseplaceholder/) metódust a lekéréséhez. Egy egyszerű helyi alakzat `null`‑t ad vissza, mert nem része a helyfoglaló hierarchiának.

**Módosíthatom az összes dia címet egy elrendezési helyfoglaló szerkesztésével?**

Az örökölt formázást vagy a prompt szöveget módosíthatod egy elrendezésen keresztül, de a meglévő cím tartalom a normál diákon van tárolva. Az összes cím szövegének tényleges cseréjéhez iterálj a diákon, és frissítsd minden címhelyfoglalót.

**Hogyan kezelem a dátum, dia‑szám, fejléc és lábléc helyfoglalókat?**

Használd a fejléc‑ és lábléc kezelőket a megfelelő dia, elrendezés, mester, jegyzet vagy kézbesítő szinten. Lásd a [Manage Presentation Header and Footer](/slides/hu/net/presentation-header-and-footer/) oldalt a teljes példákért.
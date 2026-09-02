---
title: Rajzolási segédvonalak kezelése PowerPoint‑prezentációkban .NET‑ben
linktitle: Rajzolási segédvonalak
type: docs
weight: 85
url: /hu/net/drawing-guides/
keywords:
- rajzolási segédvonal
- vízszintes segédvonal
- függőleges segédvonal
- igazítási segédvonal
- dia nézet
- minta dia
- elrendezési dia
- jegyzet minta
- szórólap minta
- PowerPoint
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Vízszintes és függőleges rajzolási segédvonalak hozzáadása, elérése és törlése PowerPoint‑prezentációkban az Aspose.Slides for .NET használatával."
---
## **Áttekintés**

A rajzolási segédvonalak állítható vízszintes és függőleges vonalak, amelyek segítik a felhasználókat a formák egységes igazításában a PowerPoint‑ban történő prezentációszerkesztés során. Különösen hasznosak, ha egy alkalmazás generál egy prezentációt, amelyet később kézzel finomítanak: az alkalmazás elmentheti ugyanazokat az igazítási segédeszközöket, amelyeket a szerzőknek követniük kell a tartalom hozzáadásakor vagy mozgatásakor.

A rajzolási segédvonalak szerkesztési segédeszközök, nem diáktartalom. Nem jelennek meg diavetítésben vagy a renderelt kimenetben. Az Aspose.Slides for .NET a [IDrawingGuidesCollection](https://reference.aspose.com/slides/hu/net/aspose.slides/idrawingguidescollection/) interfészen keresztül teszi elérhetővé őket. Egy segédvonalat a [IDrawingGuide](https://reference.aspose.com/slides/hu/net/aspose.slides/idrawingguide/) képvisel, és rendelkezik iránnyal, pozícióval és színnel.

A pozíció pontban van megadva a megfelelő dia vagy minta bal felső sarkától számítva. A függőleges segédvonal vízszintes koordinátát használ, általában a nulla és a dia szélessége között. A vízszintes segédvonal függőleges koordinátát használ, általában a nulla és a dia magassága között.

## **Segédvonalak hozzáadása a dia nézethez**

Használja a [ICommonSlideViewProperties.DrawingGuides](https://reference.aspose.com/slides/hu/net/aspose.slides/icommonslideviewproperties/drawingguides/) tulajdonságot a normál diák szerkesztése közben megjelenő segédvonalak kezeléséhez. Hívja meg a [IDrawingGuidesCollection.Add](https://reference.aspose.com/slides/hu/net/aspose.slides/idrawingguidescollection/add/) metódust egy [Orientation](https://reference.aspose.com/slides/hu/net/aspose.slides/orientation/) értékkel és egy pontban megadott pozícióval.

Az alábbi példa egy függőleges segédvonalat ad hozzá a dia középpontja jobb oldalához, valamint egy vízszintes segédvonalat alatta:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var slideSize = presentation.SlideSize.Size;
var guides = presentation.ViewProperties.SlideViewProperties.DrawingGuides;

guides.Add(Orientation.Vertical, slideSize.Width / 2 + 12.5f);
guides.Add(Orientation.Horizontal, slideSize.Height / 2 + 12.5f);

presentation.Save("drawing-guides.pptx", SaveFormat.Pptx);
```

## **Rajzolási segédvonalak elérése**

A [IDrawingGuidesCollection.Count](https://reference.aspose.com/slides/hu/net/aspose.slides/idrawingguidescollection/count/) tulajdonság és az indexelő biztosítja a meglévő segédvonalak elérését. A [IDrawingGuide.Orientation](https://reference.aspose.com/slides/hu/net/aspose.slides/idrawingguide/orientation/), a [IDrawingGuide.Position](https://reference.aspose.com/slides/hu/net/aspose.slides/idrawingguide/position/) és a [IDrawingGuide.Color](https://reference.aspose.com/slides/hu/net/aspose.slides/idrawingguide/color/) tulajdonságok olvashatók vagy módosíthatók.

Az alábbi példa beolvassa a fenti prezentációban létrehozott dia‑nézet segédvonalakat:

```csharp
using Aspose.Slides;

using var presentation = new Presentation("drawing-guides.pptx");

var guides = presentation.ViewProperties.SlideViewProperties.DrawingGuides;

for (var index = 0; index < guides.Count; index++)
{
    var guide = guides[index];
    Console.WriteLine($"Guide {index}: orientation = {guide.Orientation}, position = {guide.Position}, color = {guide.Color}");
}
```

## **Segédvonalak hozzáadása a minta‑ és elrendezési diákhoz**

Egy minta‑dia és minden hozzá tartozó elrendezési dia saját rajzolási‑segédvonal‑gyűjteménnyel rendelkezhet. Használja a [IMasterSlide.DrawingGuides](https://reference.aspose.com/slides/hu/net/aspose.slides/imasterslide/drawingguides/) interfészt a minta‑dia esetén, és az [ILayoutSlide.DrawingGuides](https://reference.aspose.com/slides/hu/net/aspose.slides/ilayoutslide/drawingguides/) interfészt az elrendezési dia esetén.

Az alábbi példa egy függőleges segédvonalat ad az első minta‑diához és egy vízszintes segédvonalat az első elrendezési diához:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var slideSize = presentation.SlideSize.Size;
var masterGuides = presentation.Masters[0].DrawingGuides;
var layoutGuides = presentation.LayoutSlides[0].DrawingGuides;

masterGuides.Add(Orientation.Vertical, slideSize.Width / 2 - 20f);
layoutGuides.Add(Orientation.Horizontal, slideSize.Height / 2 + 20f);

presentation.Save("master-layout-drawing-guides.pptx", SaveFormat.Pptx);
```

## **Segédvonalak hozzáadása a jegyzet‑ és szórólap‑mintákhoz**

A jegyzet‑minták és a szórólap‑minták is támogatják a rajzolási segédvonalakat. Használja a [IMasterNotesSlide.DrawingGuides](https://reference.aspose.com/slides/hu/net/aspose.slides/imasternotesslide/drawingguides/) és a [IMasterHandoutSlide.DrawingGuides](https://reference.aspose.com/slides/hu/net/aspose.slides/imasterhandoutslide/drawingguides/) interfészeket a gyűjteményeik eléréséhez. Ha a prezentáció nem tartalmaz ilyen mintát, a [IMasterNotesSlideManager.SetDefaultMasterNotesSlide](https://reference.aspose.com/slides/hu/net/aspose.slides/imasternotesslidemanager/setdefaultmasternotesslide/) vagy a [IMasterHandoutSlideManager.SetDefaultMasterHandoutSlide](https://reference.aspose.com/slides/hu/net/aspose.slides/imasterhandoutslidemanager/setdefaultmasterhandoutslide/) létrehozza az alapértelmezett mintát és visszaadja azt.

Az alábbi példa egy vízszintes segédvonalat ad egy jegyzet‑mintahoz és egy függőleges segédvonalat egy szórólap‑mintahez:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var notesSize = presentation.NotesSize.Size;
var notesMaster = presentation.MasterNotesSlideManager.SetDefaultMasterNotesSlide();
var handoutMaster = presentation.MasterHandoutSlideManager.SetDefaultMasterHandoutSlide();

notesMaster.DrawingGuides.Add(Orientation.Horizontal, notesSize.Height / 2 + 50f);
handoutMaster.DrawingGuides.Add(Orientation.Vertical, notesSize.Width / 2 - 50f);

presentation.Save("notes-handout-drawing-guides.pptx", SaveFormat.Pptx);
```

## **Rajzolási segédvonalak törlése**

Hívja meg a [IDrawingGuidesCollection.Clear](https://reference.aspose.com/slides/hu/net/aspose.slides/idrawingguidescollection/clear/) metódust a kívánt gyűjteményben lévő összes segédvonal eltávolításához. Egy gyűjtemény törlése nem érinti a másik hatókörben tárolt segédvonalakat.

Az alábbi példa törli a dia‑nézet segédvonalakat, valamint a dia‑minták, elrendezési diák, jegyzet‑minta és szórólap‑minta összes segédvonalát a hiányzó minták létrehozása nélkül:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation-with-guides.pptx");

presentation.ViewProperties.SlideViewProperties.DrawingGuides.Clear();

foreach (var masterSlide in presentation.Masters)
{
    masterSlide.DrawingGuides.Clear();
}

foreach (var layoutSlide in presentation.LayoutSlides)
{
    layoutSlide.DrawingGuides.Clear();
}

var notesMaster = presentation.MasterNotesSlideManager.MasterNotesSlide;
if (notesMaster != null)
{
    notesMaster.DrawingGuides.Clear();
}

var handoutMaster = presentation.MasterHandoutSlideManager.MasterHandoutSlide;
if (handoutMaster != null)
{
    handoutMaster.DrawingGuides.Clear();
}

presentation.Save("presentation-without-guides.pptx", SaveFormat.Pptx);
```

## **GYIK**

**Megjelennek a rajzolási segédvonalak diavetítésben vagy exportált képeken?**

Nem. A rajzolási segédvonalak szerkesztési igazítási segédeszközök, és nem jelennek meg a prezentáció tartalmaként.

**Hozzáadható-e rajzolási segédvonal közvetlenül egy egyedi normál diához?**

A normál diák szerkesztési segédvonalai a prezentáció dia‑nézet tulajdonságaiban tárolódnak. Külön segédvonal‑gyűjtemények érhetők el a dia‑minták, elrendezési diák, jegyzet‑minták és szórólap‑minták számára.

**Milyen mértékegységet használnak a segédvonal pozíciói?**

A pozíciókat pontban adják meg, ahol 72 pont egy hüvelyknek felel meg. A függőleges pozíciókat a bal szélről, a vízszintes pozíciókat a felső szélről mérik.

**A rajzolási segédvonalak törlése eltávolítja-e a formákat vagy módosítja a diatartalmat?**

Nem. A `Clear` metódus csak a kiválasztott gyűjteményben lévő segédvonalakat távolítja el. A formák és a többi diatartalom változatlan marad.
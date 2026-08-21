---
title: Hantera ritningsguider i presentationer i .NET
linktitle: Ritningsguider
type: docs
weight: 85
url: /sv/net/drawing-guides/
keywords:
- ritningsguide
- horisontell guide
- vertikal guide
- justeringsguide
- bildvy
- masterbild
- layoutbild
- anteckningsmaster
- utdelningsmaster
- PowerPoint
- presentation
- .NET
- C#
- Aspose.Slides
description: "Lägg till, få åtkomst till och rensa horisontella och vertikala ritningsguider i PowerPoint-presentationer med Aspose.Slides för .NET."
---
## **Översikt**

Ritningsguider är justerbara horisontella och vertikala linjer som hjälper användare att justera former konsekvent när de redigerar en presentation i PowerPoint. De är särskilt användbara när ett program genererar en presentation som senare ska finjusteras manuellt: programmet kan spara samma justeringshjälpmedel som författare bör följa när de lägger till eller flyttar innehåll.

Ritningsguider är redigeringshjälpmedel, inte bildinnehåll. De visas inte i en bildspelsvisning eller renderad output. Aspose.Slides för .NET exponerar dem via gränssnittet [IDrawingGuidesCollection](https://reference.aspose.com/slides/sv/net/aspose.slides/idrawingguidescollection/). En guide representeras av [IDrawingGuide](https://reference.aspose.com/slides/sv/net/aspose.slides/idrawingguide/) och har en orientering, en position och en färg.

Positionen mäts i punkter från det övre vänstra hörnet av den relevanta bilden eller masterbilden. En vertikal guide använder en horisontell koordinat, vanligtvis mellan noll och bildens bredd. En horisontell guide använder en vertikal koordinat, vanligtvis mellan noll och bildens höjd.

## **Lägg till guider i bildvyn**

Använd [ICommonSlideViewProperties.DrawingGuides](https://reference.aspose.com/slides/sv/net/aspose.slides/icommonslideviewproperties/drawingguides/) för att hantera guider som visas medan du redigerar vanliga bilder. Anropa [IDrawingGuidesCollection.Add](https://reference.aspose.com/slides/sv/net/aspose.slides/idrawingguidescollection/add/) med ett [Orientation](https://reference.aspose.com/slides/sv/net/aspose.slides/orientation/)‑värde och en position i punkter.

Följande exempel lägger till en vertikal guide till höger om bildens centrum och en horisontell guide under den:

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

## **Åtkomst till ritningsguider**

Egenskapen [IDrawingGuidesCollection.Count](https://reference.aspose.com/slides/sv/net/aspose.slides/idrawingguidescollection/count/) och indexeraren ger åtkomst till befintliga guider. Egenskaperna [IDrawingGuide.Orientation](https://reference.aspose.com/slides/sv/net/aspose.slides/idrawingguide/orientation/), [IDrawingGuide.Position](https://reference.aspose.com/slides/sv/net/aspose.slides/idrawingguide/position/) och [IDrawingGuide.Color](https://reference.aspose.com/slides/sv/net/aspose.slides/idrawingguide/color/) kan läsas eller ändras.

Följande exempel läser bildvygsguiderna från presentationen som skapades ovan:

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

## **Lägg till guider till master- och layoutbilder**

En bildmaster och var och en av dess layoutbilder kan ha egna samlingar av ritningsguider. Använd [IMasterSlide.DrawingGuides](https://reference.aspose.com/slides/sv/net/aspose.slides/imasterslide/drawingguides/) för en masterbild och [ILayoutSlide.DrawingGuides](https://reference.aspose.com/slides/sv/net/aspose.slides/ilayoutslide/drawingguides/) för en layoutbild.

Följande exempel lägger till en vertikal guide till den första masterbilden och en horisontell guide till den första layoutbilden:

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

## **Lägg till guider till antecknings- och utdelningsmastrar**

Anteckningsmastrar och utdelningsmastrar stöder också ritningsguider. Använd [IMasterNotesSlide.DrawingGuides](https://reference.aspose.com/slides/sv/net/aspose.slides/imasternotesslide/drawingguides/) och [IMasterHandoutSlide.DrawingGuides](https://reference.aspose.com/slides/sv/net/aspose.slides/imasterhandoutslide/drawingguides/) för att komma åt deras samlingar. Om en presentation inte innehåller någon av dessa mastrar skapar [IMasterNotesSlideManager.SetDefaultMasterNotesSlide](https://reference.aspose.com/slides/sv/net/aspose.slides/imasternotesslidemanager/setdefaultmasternotesslide/) eller [IMasterHandoutSlideManager.SetDefaultMasterHandoutSlide](https://reference.aspose.com/slides/sv/net/aspose.slides/imasterhandoutslidemanager/setdefaultmasterhandoutslide/) standardmastern och returnerar den.

Följande exempel lägger till en horisontell guide till en anteckningsmaster och en vertikal guide till en utdelningsmaster:

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

## **Rensa ritningsguider**

Anropa [IDrawingGuidesCollection.Clear](https://reference.aspose.com/slides/sv/net/aspose.slides/idrawingguidescollection/clear/) för att ta bort alla guider från en viss samling. Att rensa en samling påverkar inte guider som lagras i en annan omfattning.

Följande exempel rensar bildvygsguiderna och alla guider på bildmastrar, layoutbilder, anteckningsmastern och utdelningsmastern utan att skapa saknade mastrar:

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

## **Vanliga frågor**

**Visas ritningsguider i ett bildspel eller exporterade bilder?**

Nej. Ritningsguider är justeringshjälpmedel för redigering och renderas inte som presentationsinnehåll.

**Kan en ritningsguide läggas till direkt på en enskild normal bild?**

Redigeringsguider för normala bilder lagras i presentationens bildvygsegenskaper. Separata guide‑samlingar finns för bildmastrar, layoutbilder, anteckningsmastrar och utdelningsmastrar.

**Vilka enheter används för guidepositioner?**

Positioner anges i punkter, där 72 punkter motsvarar en tum. Vertikala positioner mäts från vänster kant och horisontella positioner mäts från övre kanten.

**Tar rensning av ritningsguider bort former eller förändrar bildinnehåll?**

Nej. Metoden `Clear` tar bara bort guiderna i den valda samlingen. Former och annat bildinnehåll förblir oförändrade.
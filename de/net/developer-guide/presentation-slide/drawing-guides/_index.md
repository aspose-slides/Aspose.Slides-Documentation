---
title: Verwalten von Zeichnungshilfen in Präsentationen in .NET
linktitle: Zeichnungshilfen
type: docs
weight: 85
url: /de/net/drawing-guides/
keywords:
- Zeichnungshilfe
- Horizontale Hilfslinie
- Vertikale Hilfslinie
- Ausrichtungshilfe
- Folienansicht
- Master-Folie
- Layout-Folie
- Notizen-Master
- Handzettel-Master
- PowerPoint
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Fügen Sie horizontale und vertikale Zeichnungshilfen in PowerPoint-Präsentationen mit Aspose.Slides für .NET hinzu, greifen Sie darauf zu und entfernen Sie sie."
---
## **Übersicht**

Zeichnungshilfen sind verstellbare horizontale und vertikale Linien, die Benutzern helfen, Formen beim Bearbeiten einer Präsentation in PowerPoint konsistent auszurichten. Sie sind besonders nützlich, wenn eine Anwendung eine Präsentation generiert, die später manuell verfeinert wird: Die Anwendung kann dieselben Ausrichtungshilfen speichern, denen die Autoren beim Hinzufügen oder Verschieben von Inhalten folgen sollten.

Zeichnungshilfen sind Bearbeitungshilfen, keine Folieninhalte. Sie erscheinen nicht in einer Diashow oder gerenderten Ausgabe. Aspose.Slides für .NET stellt sie über das Interface [IDrawingGuidesCollection](https://reference.aspose.com/slides/de/net/aspose.slides/idrawingguidescollection/) bereit. Eine Hilfslinie wird durch [IDrawingGuide](https://reference.aspose.com/slides/de/net/aspose.slides/idrawingguide/) repräsentiert und hat eine Orientierung, eine Position und eine Farbe.

Die Position wird in Punkten vom oberen linken Rand der jeweiligen Folie oder des Masters gemessen. Eine vertikale Hilfslinie verwendet eine horizontale Koordinate, typischerweise zwischen Null und der Folienbreite. Eine horizontale Hilfslinie verwendet eine vertikale Koordinate, typischerweise zwischen Null und der Folienhöhe.

## **Hilfslinien zur Folienansicht hinzufügen**

Verwenden Sie [ICommonSlideViewProperties.DrawingGuides](https://reference.aspose.com/slides/de/net/aspose.slides/icommonslideviewproperties/drawingguides/), um die während der Bearbeitung normaler Folien angezeigten Hilfslinien zu verwalten. Rufen Sie [IDrawingGuidesCollection.Add](https://reference.aspose.com/slides/de/net/aspose.slides/idrawingguidescollection/add/) mit einem [Orientation](https://reference.aspose.com/slides/de/net/aspose.slides/orientation/)-Wert und einer Position in Punkten auf.

Das folgende Beispiel fügt eine vertikale Hilfslinie rechts vom Folienmittelpunkt und eine horizontale Hilfslinie darunter hinzu:

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

## **Zugriff auf Zeichnungshilfen**

Die Eigenschaft und der Indexer [IDrawingGuidesCollection.Count](https://reference.aspose.com/slides/de/net/aspose.slides/idrawingguidescollection/count/) ermöglichen den Zugriff auf vorhandene Hilfslinien. Die Eigenschaften [IDrawingGuide.Orientation](https://reference.aspose.com/slides/de/net/aspose.slides/idrawingguide/orientation/), [IDrawingGuide.Position](https://reference.aspose.com/slides/de/net/aspose.slides/idrawingguide/position/) und [IDrawingGuide.Color](https://reference.aspose.com/slides/de/net/aspose.slides/idrawingguide/color/) können gelesen oder geändert werden.

Das folgende Beispiel liest die Hilfslinien der Folienansicht aus der oben erstellten Präsentation:

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

## **Hilfslinien zu Master‑ und Layout‑Folien hinzufügen**

Ein Folienmaster und jede seiner Layoutfolien können eigene Zeichnungshilfen‑Sammlungen besitzen. Verwenden Sie [IMasterSlide.DrawingGuides](https://reference.aspose.com/slides/de/net/aspose.slides/imasterslide/drawingguides/) für einen Master‑Slide und [ILayoutSlide.DrawingGuides](https://reference.aspose.com/slides/de/net/aspose.slides/ilayoutslide/drawingguides/) für einen Layout‑Slide.

Das folgende Beispiel fügt einer ersten Master‑Folien eine vertikale Hilfslinie und einer ersten Layout‑Folien eine horizontale Hilfslinie hinzu:

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

## **Hilfslinien zu Notizen‑ und Handzettel‑Mastern hinzufügen**

Notizen‑Master und Handzettel‑Master unterstützen ebenfalls Zeichnungshilfen. Verwenden Sie [IMasterNotesSlide.DrawingGuides](https://reference.aspose.com/slides/de/net/aspose.slides/imasternotesslide/drawingguides/) und [IMasterHandoutSlide.DrawingGuides](https://reference.aspose.com/slides/de/net/aspose.slides/imasterhandoutslide/drawingguides/), um auf deren Sammlungen zuzugreifen. Wenn eine Präsentation keinen dieser Master enthält, erstellt [IMasterNotesSlideManager.SetDefaultMasterNotesSlide](https://reference.aspose.com/slides/de/net/aspose.slides/imasternotesslidemanager/setdefaultmasternotesslide/) bzw. [IMasterHandoutSlideManager.SetDefaultMasterHandoutSlide](https://reference.aspose.com/slides/de/net/aspose.slides/imasterhandoutslidemanager/setdefaultmasterhandoutslide/) den Standard‑Master und gibt ihn zurück.

Das folgende Beispiel fügt einem Notizen‑Master eine horizontale Hilfslinie und einem Handzettel‑Master eine vertikale Hilfslinie hinzu:

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

## **Zeichnungshilfen löschen**

Rufen Sie [IDrawingGuidesCollection.Clear](https://reference.aspose.com/slides/de/net/aspose.slides/idrawingguidescollection/clear/) auf, um jede Hilfslinie aus einer bestimmten Sammlung zu entfernen. Das Löschen einer Sammlung wirkt sich nicht auf in einem anderen Umfang gespeicherte Hilfslinien aus.

Das folgende Beispiel löscht die Hilfslinien der Folienansicht sowie alle Hilfslinien auf Folienmastern, Layout‑Folien, dem Notizen‑Master und dem Handzettel‑Master, ohne fehlende Master zu erstellen:

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

## **FAQ**

**Erscheinen Zeichnungshilfen in einer Diashow oder exportierten Bildern?**

Nein. Zeichnungshilfen sind Ausrichtungshilfen für die Bearbeitung und werden nicht als Präsentationsinhalt gerendert.

**Kann eine Zeichnungshilfe direkt zu einer einzelnen normalen Folie hinzugefügt werden?**

Bearbeitungshilfen für Normalfolien werden in den Folienansichts‑Eigenschaften der Präsentation gespeichert. Separate Hilfslinien‑Sammlungen stehen für Folien‑Master, Layout‑Folien, Notizen‑Master und Handzettel‑Master zur Verfügung.

**Welche Einheiten werden für die Positionen von Hilfslinien verwendet?**

Positionen werden in Punkten angegeben, wobei 72 Punkte einem Zoll entsprechen. Vertikale Positionen werden vom linken Rand gemessen, horizontale Positionen vom oberen Rand.

**Entfernt das Löschen von Zeichnungshilfen Formen oder ändert den Folieninhalt?**

Nein. Die Methode `Clear` entfernt nur die Hilfslinien in der ausgewählten Sammlung. Formen und anderer Folieninhalt bleiben unverändert.
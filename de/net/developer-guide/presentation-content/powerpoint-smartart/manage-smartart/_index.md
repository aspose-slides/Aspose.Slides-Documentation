---
title: SmartArt in PowerPoint-Präsentationen in .NET verwalten
linktitle: SmartArt verwalten
type: docs
weight: 10
url: /de/net/manage-smartart/
keywords:
- SmartArt
- SmartArt-Text
- Layouttyp
- Versteckte Eigenschaft
- Organisationsdiagramm
- Bild-Organisationsdiagramm
- PowerPoint
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Erfahren Sie, wie Sie PowerPoint‑SmartArt mit Aspose.Slides für .NET erstellen und bearbeiten, mithilfe klarer C#‑Codebeispiele, die das Entwerfen und die Automatisierung von Folien beschleunigen."
---
## **Übersicht**

SmartArt ist ein PowerPoint‑Diagramm, das aus Knoten, Knotformen und einem Layout besteht. Mit Aspose.Slides für .NET können Sie SmartArt erstellen, Text aus dessen Knoten lesen, das Layout ändern, verborgene Knoten überprüfen, Organisationsdiagrammlayouts konfigurieren und Bild‑Organisationsdiagramme erstellen.

## **Text aus einem SmartArt‑Objekt abrufen**

Ein SmartArt‑Knoten kann ein oder mehrere Formen enthalten. Um Text aus den Knotformen zu lesen, iterieren Sie über [ISmartArt.AllNodes](https://reference.aspose.com/slides/net/aspose.slides.smartart/ismartart/allnodes/), dann lesen Sie das [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) , das von [ISmartArtShape.TextFrame](https://reference.aspose.com/slides/net/aspose.slides.smartart/ismartartshape/textframe/) zurückgegeben wird.

Das Beispiel benötigt eine Präsentation mit mindestens einer Folie und einem SmartArt‑Objekt als erste Form auf dieser Folie. Es gibt jeden verfügbaren Textrahmen in der Konsole aus.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.SmartArt;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var smartArt = (ISmartArt) slide.Shapes[0];
foreach (var node in smartArt.AllNodes)
{
    foreach (var nodeShape in node.Shapes)
    {
        if (nodeShape.TextFrame != null)
        {
            Console.WriteLine(nodeShape.TextFrame.Text);
        }
    }
}
```

## **Layouttyp eines SmartArt‑Objekts ändern**

Das SmartArt‑Layout bestimmt, wie Knoten angeordnet und verbunden werden. Das folgende Beispiel erstellt ein SmartArt‑Objekt mit dem [SmartArtLayoutType](https://reference.aspose.com/slides/net/aspose.slides.smartart/smartartlayouttype/)‑Wert `BasicBlockList`, ändert ihn zu `BasicProcess` und speichert die Präsentation. Die an [IShapeCollection.AddSmartArt](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addsmartart/) übergebenen Position und Größe werden in Punkt gemessen. Setzen Sie [ISmartArt.Layout](https://reference.aspose.com/slides/net/aspose.slides.smartart/ismartart/layout/), um das Layout zu ändern.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var smartArt = slide.Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);
smartArt.Layout = SmartArtLayoutType.BasicProcess;

presentation.Save("ChangeSmartArtLayout.pptx", SaveFormat.Pptx);
```

## **Prüfen, ob ein SmartArt‑Knoten verborgen ist**

[ISmartArtNode.IsHidden](https://reference.aspose.com/slides/net/aspose.slides.smartart/ismartartnode/ishidden/) gibt an, ob der Knoten im SmartArt‑Datenmodell verborgen ist. Verborgene Knoten können in der Struktur existieren, selbst wenn das ausgewählte Layout sie nicht als sichtbare Diagrammelemente darstellt.

Das folgende Beispiel fügt einem SmartArt‑Objekt, das den [SmartArtLayoutType](https://reference.aspose.com/slides/net/aspose.slides.smartart/smartartlayouttype/)‑Wert `RadialCycle` verwendet, einen Knoten hinzu und überprüft den verborgenen Zustand des hinzugefügten Knotens. Es gibt eine Meldung aus, wenn der Knoten verborgen ist, und speichert das Diagramm.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var smartArt = slide.Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);
var node = smartArt.AllNodes.AddNode();
var isHidden = node.IsHidden;

if (isHidden)
{
    Console.WriteLine("The node is hidden in the SmartArt data model.");
}

presentation.Save("CheckSmartArtHiddenProperty.pptx", SaveFormat.Pptx);
```

## **Organisationsdiagramm‑Layout abrufen oder festlegen**

Für SmartArt‑Diagramme, die ein Organisationsdiagramm‑Layout verwenden, definiert [ISmartArtNode.OrganizationChartLayout](https://reference.aspose.com/slides/net/aspose.slides.smartart/ismartartnode/organizationchartlayout/) , wie untergeordnete Knoten unter einem übergeordneten Knoten angeordnet werden. Sie können z. B. festlegen, dass untergeordnete Knoten links, rechts oder an beiden Seiten hängen, abhängig vom ausgewählten [OrganizationChartLayoutType](https://reference.aspose.com/slides/net/aspose.slides.smartart/organizationchartlayouttype/).

Das folgende Beispiel erstellt ein Organisationsdiagramm und setzt das Layout für den ersten Knoten auf den [OrganizationChartLayoutType](https://reference.aspose.com/slides/net/aspose.slides.smartart/organizationchartlayouttype/)‑Wert `LeftHanging`. Der nullbasierte Index `0` wählt den ersten Knoten der obersten Ebene aus; seine untergeordneten Knoten verwenden die gewählte Anordnung. Die geänderte Präsentation wird anschließend gespeichert.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var smartArt = slide.Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);
var rootNode = smartArt.Nodes[0];
rootNode.OrganizationChartLayout = OrganizationChartLayoutType.LeftHanging;

presentation.Save("OrganizationChartLayout.pptx", SaveFormat.Pptx);
```

## **Bild‑Organisationsdiagramm erstellen**

Ein Bild‑Organisationsdiagramm ist ein SmartArt‑Layout, das für Hierarchie‑Diagramme mit Bild‑Platzhaltern entwickelt wurde. Verwenden Sie den [SmartArtLayoutType](https://reference.aspose.com/slides/net/aspose.slides.smartart/smartartlayouttype/)‑Wert `PictureOrganizationChart`, wenn Sie das SmartArt‑Objekt zu einer Folie hinzufügen. Dieses Beispiel speichert ein Diagramm mit Bild‑Platzhaltern; es füllt die Platzhalter nicht mit Bildern.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var smartArt = slide.Shapes.AddSmartArt(0, 0, 400, 400, SmartArtLayoutType.PictureOrganizationChart);

presentation.Save("PictureOrganizationChart.pptx", SaveFormat.Pptx);
```

## **Legacy‑Diagramme in Gruppen von Formen konvertieren**

Beim Modernisieren einer bestehenden Präsentation müssen Sie möglicherweise ein Organisationsdiagramm aktualisieren, das ursprünglich in PowerPoint 97–2003 erstellt wurde. Aspose.Slides stellt diese Legacy‑Diagramme als [ILegacyDiagram](https://reference.aspose.com/slides/net/aspose.slides/ilegacydiagram/)‑Objekte dar. Verwenden Sie [LegacyDiagram.ConvertToGroupShape](https://reference.aspose.com/slides/net/aspose.slides/legacydiagram/converttogroupshape/), um ein Diagramm in eine Gruppe von Formen zu konvertieren, damit Sie einzelne Bildelemente bearbeiten können. Weitere Details finden Sie in der [LegacyDiagram API Reference](https://reference.aspose.com/slides/net/aspose.slides/legacydiagram/).

Die Konvertierung fügt der Formensammlung eine neue Gruppe hinzu, ohne das ursprüngliche Diagramm zu entfernen. Nach erfolgreicher Konvertierung entfernen Sie das Original mit [IShapeCollection.Remove](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/remove/), um doppelte Inhalte zu vermeiden. Sammeln Sie die Legacy‑Diagramme vor der Konvertierung in ein Array, damit das Hinzufügen und Entfernen von Formen die Iteration nicht stört.

Das folgende Beispiel öffnet eine Präsentation, durchsucht jede Folie, konvertiert die Diagramme in Gruppen von Formen und speichert die aktualisierte Präsentation als PPTX.

```csharp
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("legacy-diagrams.ppt");

foreach (var slide in presentation.Slides)
{
    var legacyDiagrams = slide.Shapes.OfType<ILegacyDiagram>().ToArray();
    foreach (var legacyDiagram in legacyDiagrams)
    {
        var groupShape = legacyDiagram.ConvertToGroupShape();

        if (groupShape != null)
        {
            slide.Shapes.Remove(legacyDiagram);
        }
    }
}

presentation.Save("modernized.pptx", SaveFormat.Pptx);
```

Die gespeicherte Präsentation enthält bearbeitbare Gruppen von Formen anstelle der konvertierten Legacy‑Diagramme, wobei keine Originaldiagramme mehr daneben vorhanden sind. Öffnen Sie die PPTX in PowerPoint, um einzelne Elemente innerhalb jeder Gruppe zu bearbeiten, z. B. deren Text, Füllung oder Position.

## **FAQ**

**Unterstützt SmartArt Spiegeln oder Umkehren für RTL‑Sprachen?**

Ja. Die [IsReversed](https://reference.aspose.com/slides/net/aspose.slides.smartart/smartart/isreversed/)‑Eigenschaft wechselt die Diagrammrichtung von links‑nach‑rechts zu rechts‑nach‑links oder zurück, wenn das ausgewählte SmartArt‑Layout die Umkehrung unterstützt.

**Wie kann ich SmartArt auf derselben Folie oder in eine andere Präsentation kopieren und dabei die Formatierung beibehalten?**

Sie können die [SmartArt‑Form klonen](/slides/de/net/shape-manipulations/) mit [ShapeCollection.AddClone](https://reference.aspose.com/slides/net/aspose.slides/shapecollection/addclone/) oder die gesamte Folie, die die SmartArt enthält, [klonen](/slides/de/net/clone-slides/). Beide Ansätze bewahren Größe, Position und Formatierung.

**Wie render ich SmartArt zu einem Rasterbild für die Vorschau oder den Web‑Export?**

[Rendern Sie die Folie](/slides/de/net/convert-powerpoint-to-png/) oder die gesamte Präsentation zu PNG oder JPEG. SmartArt wird als Teil der Folie gerendert.

**Wie finde ich ein bestimmtes SmartArt‑Objekt auf einer Folie, wenn mehrere vorhanden sind?**

Setzen Sie einen eindeutigen [AlternativeText](https://reference.aspose.com/slides/net/aspose.slides/shape/alternativetext/)‑ oder [Name](https://reference.aspose.com/slides/net/aspose.slides/shape/name/)‑Wert auf die SmartArt‑Form, suchen Sie nach diesem Wert in [Slide.Shapes](https://reference.aspose.com/slides/net/aspose.slides/baseslide/shapes/), und prüfen Sie anschließend, ob die gefundene Form ein [ISmartArt](https://reference.aspose.com/slides/net/aspose.slides.smartart/ismartart/) ist.
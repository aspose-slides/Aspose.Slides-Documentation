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
description: "Erfahren Sie, wie Sie PowerPoint‑SmartArt mit Aspose.Slides für .NET erstellen und bearbeiten, mithilfe klarer C#‑Codebeispiele, die die Foliengestaltung und Automatisierung beschleunigen."
---
## **Übersicht**

SmartArt ist ein PowerPoint-Diagramm, das aus Knoten, Knotformen und einem Layout besteht. Mit Aspose.Slides für .NET können Sie SmartArt erstellen, Text aus seinen Knoten lesen, das Layout ändern, versteckte Knoten prüfen, Organisationsdiagramm‑Layouts konfigurieren und Bild‑Organisationsdiagramme erstellen.

## **Text aus einem SmartArt-Objekt abrufen**

Ein SmartArt‑Knoten kann ein oder mehrere Shapes enthalten. Um den sichtbaren Text zu lesen, iterieren Sie über [ISmartArt.AllNodes](https://reference.aspose.com/slides/de/net/aspose.slides.smartart/ismartart/allnodes/), und lesen dann das von [ISmartArtShape.TextFrame](https://reference.aspose.com/slides/de/net/aspose.slides.smartart/ismartartshape/textframe/) zurückgegebene [ITextFrame](https://reference.aspose.com/slides/de/net/aspose.slides/itextframe/).

```c#
using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    if (slide.Shapes[0] is ISmartArt smartArt)
    {
        foreach (ISmartArtNode node in smartArt.AllNodes)
        {
            foreach (ISmartArtShape nodeShape in node.Shapes)
            {
                if (nodeShape.TextFrame != null)
                {
                    Console.WriteLine(nodeShape.TextFrame.Text);
                }
            }
        }
    }
}
```

## **Layouttyp eines SmartArt-Objekts ändern**

Das SmartArt‑Layout bestimmt, wie Knoten angeordnet und verbunden werden. Das folgende Beispiel erstellt ein SmartArt‑Objekt mit dem Wert `BasicBlockList` des [SmartArtLayoutType](https://reference.aspose.com/slides/de/net/aspose.slides.smartart/smartartlayouttype/), ändert ihn auf den Wert `BasicProcess` und speichert die Präsentation.

```c#
using (Presentation presentation = new Presentation())
{
    ISmartArt smartArt = presentation.Slides[0].Shapes.AddSmartArt(
        10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

    smartArt.Layout = SmartArtLayoutType.BasicProcess;

    presentation.Save("ChangeSmartArtLayout_out.pptx", SaveFormat.Pptx);
}
```

## **Prüfen, ob ein SmartArt‑Knoten verborgen ist**

[ISmartArtNode.IsHidden](https://reference.aspose.com/slides/de/net/aspose.slides.smartart/ismartartnode/ishidden/) gibt an, ob der Knoten im SmartArt‑Datenmodell verborgen ist. Verborgene Knoten können in der Struktur existieren, selbst wenn das ausgewählte Layout sie nicht als sichtbare Diagrammelemente darstellt.

Das folgende Beispiel fügt einem SmartArt‑Objekt, das den Wert `RadialCycle` des [SmartArtLayoutType](https://reference.aspose.com/slides/de/net/aspose.slides.smartart/smartartlayouttype/) verwendet, einen Knoten hinzu und prüft den verborgenen Zustand des Knotens.

```c#
using (Presentation presentation = new Presentation())
{
    ISmartArt smartArt = presentation.Slides[0].Shapes.AddSmartArt(
        10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

    ISmartArtNode node = smartArt.AllNodes.AddNode();
    bool isHidden = node.IsHidden;

    if (isHidden)
    {
        Console.WriteLine("The node is hidden in the SmartArt data model.");
    }

    presentation.Save("CheckSmartArtHiddenProperty_out.pptx", SaveFormat.Pptx);
}
```

## **Organisationsdiagramm‑Layout abrufen oder festlegen**

Für SmartArt‑Diagramme, die ein Organisationsdiagramm‑Layout verwenden, definiert [ISmartArtNode.OrganizationChartLayout](https://reference.aspose.com/slides/de/net/aspose.slides.smartart/ismartartnode/organizationchartlayout/), wie Kindknoten unter einem Elternknoten angeordnet werden. Beispielsweise können Sie Kindknoten abhängig vom ausgewählten [OrganizationChartLayoutType](https://reference.aspose.com/slides/de/net/aspose.slides.smartart/organizationchartlayouttype/) links, rechts oder an beiden Seiten „hängen lassen“.

Das folgende Beispiel erstellt ein Organisationsdiagramm und legt das Layout für den ersten Knoten auf den Wert `LeftHanging` des [OrganizationChartLayoutType](https://reference.aspose.com/slides/de/net/aspose.slides.smartart/organizationchartlayouttype/) fest.

```c#
using (Presentation presentation = new Presentation())
{
    ISmartArt smartArt = presentation.Slides[0].Shapes.AddSmartArt(
        10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

    ISmartArtNode rootNode = smartArt.Nodes[0];
    rootNode.OrganizationChartLayout = OrganizationChartLayoutType.LeftHanging;

    presentation.Save("OrganizationChartLayout_out.pptx", SaveFormat.Pptx);
}
```

## **Bild‑Organisationsdiagramm erstellen**

Ein Bild‑Organisationsdiagramm ist ein SmartArt‑Layout, das für Hierarchie‑Diagramme mit Bildplatzhaltern konzipiert ist. Verwenden Sie den Wert `PictureOrganizationChart` des [SmartArtLayoutType](https://reference.aspose.com/slides/de/net/aspose.slides.smartart/smartartlayouttype/), wenn Sie das SmartArt‑Objekt zu einer Folie hinzufügen.

```c#
using (Presentation presentation = new Presentation())
{
    ISmartArt smartArt = presentation.Slides[0].Shapes.AddSmartArt(
        0, 0, 400, 400, SmartArtLayoutType.PictureOrganizationChart);

    presentation.Save("PictureOrganizationChart_out.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Unterstützt SmartArt Spiegeln oder Umkehren für RTL‑Sprachen?**

Ja. Die Eigenschaft [IsReversed](https://reference.aspose.com/slides/de/net/aspose.slides.smartart/smartart/isreversed/) ändert die Diagrammrichtung von links‑nach‑rechts zu rechts‑nach‑links bzw. zurück, sofern das ausgewählte SmartArt‑Layout eine Umkehrung unterstützt.

**Wie kann ich SmartArt auf derselben Folie oder in einer anderen Präsentation kopieren und dabei die Formatierung beibehalten?**

Sie können die SmartArt‑Shape mit [clone the SmartArt shape](/slides/de/net/shape-manipulations/) und [ShapeCollection.AddClone](https://reference.aspose.com/slides/de/net/aspose.slides/shapecollection/addclone/) klonen oder die komplette Folie, die die SmartArt enthält, [clone the whole slide](/slides/de/net/clone-slides/) duplizieren. Beide Verfahren erhalten Größe, Position und Formatierung.

**Wie rendere ich SmartArt in ein Rasterbild für die Vorschau oder den Web‑Export?**

Sie können die Folie mit [Render the slide](/slides/de/net/convert-powerpoint-to-png/) oder die gesamte Präsentation in PNG oder JPEG rendern. SmartArt wird dabei als Teil der Folie gerendert.

**Wie kann ich ein bestimmtes SmartArt‑Objekt auf einer Folie finden, wenn mehrere vorhanden sind?**

Legen Sie einen eindeutigen [AlternativeText](https://reference.aspose.com/slides/de/net/aspose.slides/shape/alternativetext/) oder [Name](https://reference.aspose.com/slides/de/net/aspose.slides/shape/name/) Wert für die SmartArt‑Shape fest, durchsuchen Sie [Slide.Shapes](https://reference.aspose.com/slides/de/net/aspose.slides/baseslide/shapes/) nach diesem Wert und prüfen Sie anschließend, ob das gefundene Shape ein [ISmartArt](https://reference.aspose.com/slides/de/net/aspose.slides.smartart/ismartart/) ist.
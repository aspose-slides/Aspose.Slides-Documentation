---
title: SmartArt verwalten
type: docs
weight: 10
url: /de/net/manage-smartart/
keywords: "SmartArt, Text aus SmartArt, Organisationsdiagramm, Bildorganisationsdiagramm, PowerPoint-Präsentation, C#, Csharp, Aspose.Slides für .NET"
description: "SmartArt und Organisationsdiagramm in PowerPoint-Präsentationen in C# oder .NET"
---

## **Text aus SmartArt abrufen**
Die TextFrame‑Eigenschaft wurde nun zur ISmartArtShape‑Schnittstelle bzw. zur SmartArtShape‑Klasse hinzugefügt. Diese Eigenschaft ermöglicht es, den gesamten Text aus SmartArt zu erhalten, nicht nur den Text der Knoten. Der folgende Beispielcode hilft Ihnen, Text aus einem SmartArt‑Knoten zu erhalten.
```c#
using (Presentation pres = new Presentation("Presentation.pptx"))
{
	ISlide slide = pres.Slides[0];
	ISmartArt smartArt = (ISmartArt)slide.Shapes[0];

	ISmartArtNodeCollection smartArtNodes = smartArt.AllNodes;
	foreach (ISmartArtNode smartArtNode in smartArtNodes)
	{
		foreach (ISmartArtShape nodeShape in smartArtNode.Shapes)
		{
			if (nodeShape.TextFrame != null)
				Console.WriteLine(nodeShape.TextFrame.Text);
		}
	}
}
```


## **Layouttyp von SmartArt ändern**
Um den Layouttyp von SmartArt zu ändern, befolgen Sie bitte die folgenden Schritte:

- Erstellen Sie eine Instanz der Klasse `Presentation`.
- Holen Sie die Referenz einer Folie über deren Index.
- Fügen Sie SmartArt BasicBlockList hinzu.
- Ändern Sie LayoutType zu BasicProcess.
- Schreiben Sie die Präsentation als PPTX‑Datei.

Im unten angegebenen Beispiel haben wir einen Verbinder zwischen zwei Formen hinzugefügt.
```c#
using (Presentation presentation = new Presentation())
{
    // SmartArt BasicProcess hinzufügen
    ISmartArt smart = presentation.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

    // LayoutType zu BasicProcess ändern
    smart.Layout = SmartArtLayoutType.BasicProcess;

    // Präsentation speichern
    presentation.Save("ChangeSmartArtLayout_out.pptx", SaveFormat.Pptx);
}
```


## **Versteckte Eigenschaft von SmartArt prüfen**
Bitte beachten Sie, dass die Methode com.aspose.slides.ISmartArtNode.isHidden() true zurückgibt, wenn dieser Knoten im Datenmodell ein versteckter Knoten ist. Um die versteckte Eigenschaft eines beliebigen SmartArt‑Knotens zu prüfen, befolgen Sie bitte die folgenden Schritte:

- Erstellen Sie eine Instanz der Klasse `Presentation`.
- Fügen Sie SmartArt RadialCycle hinzu.
- Fügen Sie einen Knoten zu SmartArt hinzu.
- Prüfen Sie die isHidden‑Eigenschaft.
- Schreiben Sie die Präsentation als PPTX‑Datei.

Im unten angegebenen Beispiel haben wir einen Verbinder zwischen zwei Formen hinzugefügt.
```c#
using (Presentation presentation = new Presentation())
{
    // SmartArt BasicProcess hinzufügen
    ISmartArt smart = presentation.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

    // Knoten zu SmartArt hinzufügen
    ISmartArtNode node = smart.AllNodes.AddNode();

    // Prüfe isHidden-Eigenschaft
    bool hidden = node.IsHidden; // Gibt true zurück

    if (hidden)
    {
        // Einige Aktionen oder Benachrichtigungen durchführen
    }
    // Präsentation speichern
    presentation.Save("CheckSmartArtHiddenProperty_out.pptx", SaveFormat.Pptx);
}
```


## **Organisation‑Diagrammtyp abrufen oder festlegen**
Die Methoden com.aspose.slides.ISmartArtNode.getOrganizationChartLayout() und setOrganizationChartLayout(int) ermöglichen das Abrufen bzw. Festlegen des Organisation‑Diagrammtyps, der dem aktuellen Knoten zugeordnet ist. Um den Organisation‑Diagrammtyp abzurufen oder festzulegen, befolgen Sie bitte die folgenden Schritte:

- Erstellen Sie eine Instanz der Klasse `Presentation`.
- Fügen Sie SmartArt auf der Folie hinzu.
- Rufen Sie den Organisation‑Diagrammtyp ab oder legen Sie ihn fest.
- Schreiben Sie die Präsentation als PPTX‑Datei.

Im unten angegebenen Beispiel haben wir einen Verbinder zwischen zwei Formen hinzugefügt.
```c#
using (Presentation presentation = new Presentation())
{
    // SmartArt BasicProcess hinzufügen
    ISmartArt smart = presentation.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

    // Organisationsdiagrammtyp abrufen oder festlegen
    smart.Nodes[0].OrganizationChartLayout = OrganizationChartLayoutType.LeftHanging;

    // Präsentation speichern
    presentation.Save("OrganizeChartLayoutType_out.pptx", SaveFormat.Pptx);
}
```


## **Picture‑Organisationsdiagramm erstellen**
Aspose.Slides für .NET bietet eine einfache API zum Erstellen von PictureOrganization‑Diagrammen auf unkomplizierte Weise. So erstellen Sie ein Diagramm auf einer Folie:

1. Erstellen Sie eine Instanz der `Presentation`‑Klasse.
1. Holen Sie die Referenz einer Folie über ihren Index.
1. Fügen Sie ein Diagramm mit Standarddaten und dem gewünschten Typ (ChartType.PictureOrganizationChart) hinzu.
1. Schreiben Sie die modifizierte Präsentation in eine PPTX‑Datei.

Der folgende Code wird verwendet, um ein Diagramm zu erstellen.
```c#
public static void Run()
{
	using (Presentation pres = new Presentation("test.pptx"))
	{
		ISmartArt smartArt = pres.Slides[0].Shapes.AddSmartArt(0, 0, 400, 400, SmartArtLayoutType.PictureOrganizationChart);
		pres.Save("OrganizationChart.pptx", SaveFormat.Pptx);
	}			
}
```


## **FAQ**

**Unterstützt SmartArt das Spiegeln/Umkehren für RTL-Sprachen?**

Ja. Die [IsReversed](https://reference.aspose.com/slides/net/aspose.slides.smartart/smartart/isreversed/)‑Eigenschaft ändert die Diagrammrichtung (LTR/RTL), wenn der ausgewählte SmartArt‑Typ eine Umkehrung unterstützt.

**Wie kann ich SmartArt auf dieselbe Folie oder in eine andere Präsentation kopieren und dabei die Formatierung beibehalten?**

Sie können die SmartArt‑Form über die Shape‑Sammlung [klonen](/slides/de/net/shape-manipulations/) ([ShapeCollection.AddClone](https://reference.aspose.com/slides/net/aspose.slides/shapecollection/addclone/)) oder die gesamte Folie, die diese Form enthält, [klonen](/slides/de/net/clone-slides/). Beide Ansätze erhalten Größe, Position und Stil.

**Wie rendere ich SmartArt zu einem Raster-Bild für Vorschau oder Web-Export?**

[Rendern Sie die Folie](/slides/de/net/convert-powerpoint-to-png/) (oder die gesamte Präsentation) zu PNG/JPEG über die API, die Folien/Präsentationen in Bilder umwandelt – SmartArt wird dabei als Teil der Folie gezeichnet.

**Wie kann ich programmgesteuert ein bestimmtes SmartArt auf einer Folie auswählen, wenn mehrere vorhanden sind?**

Eine gängige Praxis ist die Verwendung von [alternativem Text](https://reference.aspose.com/slides/net/aspose.slides/shape/alternativetext/) (Alt‑Text) oder einem [Name](https://reference.aspose.com/slides/net/aspose.slides/shape/name/) und das Suchen nach der Form anhand dieses Attributs innerhalb von [Slide.Shapes](https://reference.aspose.com/slides/net/aspose.slides/baseslide/shapes/). Anschließend prüfen Sie den Typ, um sicherzustellen, dass es sich um [SmartArt](https://reference.aspose.com/slides/net/aspose.slides.smartart/smartart/) handelt. Die Dokumentation beschreibt typische Techniken zum Finden und Arbeiten mit Formen.
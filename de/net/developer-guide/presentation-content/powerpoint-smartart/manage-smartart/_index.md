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
- versteckte Eigenschaft
- Organisationsdiagramm
- Bild-Organisationsdiagramm
- PowerPoint
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Erfahren Sie, wie Sie PowerPoint SmartArt mit Aspose.Slides für .NET erstellen und bearbeiten, indem Sie klare C#-Code-Beispiele verwenden, die das Erstellen von Folien und die Automatisierung beschleunigen."
---

## **Text aus einem SmartArt-Objekt abrufen**
Die TextFrame‑Eigenschaft wurde nun zum ISmartArtShape‑Interface und zur SmartArtShape‑Klasse hinzugefügt. Diese Eigenschaft ermöglicht es, den gesamten Text aus SmartArt abzurufen, wenn nicht nur Knoten‑Text vorhanden ist. Der folgende Beispielcode hilft Ihnen, Text aus einem SmartArt‑Knoten zu erhalten.
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




## **Layouttyp eines SmartArt-Objekts ändern**
Um den Layouttyp von SmartArt zu ändern, führen Sie die folgenden Schritte aus:

- Erstellen Sie eine Instanz der `Presentation`‑Klasse.
- Holen Sie die Referenz einer Folie über deren Index.
- Fügen Sie SmartArt BasicBlockList hinzu.
- Ändern Sie LayoutType zu BasicProcess.
- Speichern Sie die Präsentation als PPTX‑Datei.

Im unten gezeigten Beispiel haben wir einen Verbinder zwischen zwei Formen hinzugefügt.
```c#
using (Presentation presentation = new Presentation())
{
    // SmartArt BasicProcess hinzufügen 
    ISmartArt smart = presentation.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

    // LayoutTyp zu BasicProcess ändern
    smart.Layout = SmartArtLayoutType.BasicProcess;

    // Präsentation speichern
    presentation.Save("ChangeSmartArtLayout_out.pptx", SaveFormat.Pptx);
}
```




## **Versteckte Eigenschaft eines SmartArt-Objekts überprüfen**
Bitte beachten Sie, dass die Methode com.aspose.slides.ISmartArtNode.isHidden() true zurückgibt, wenn dieser Knoten im Datenmodell ein versteckter Knoten ist. Um die versteckte Eigenschaft eines beliebigen SmartArt‑Knotens zu prüfen, führen Sie die folgenden Schritte aus:

- Erstellen Sie eine Instanz der `Presentation`‑Klasse.
- Fügen Sie SmartArt RadialCycle hinzu.
- Fügen Sie dem SmartArt einen Knoten hinzu.
- Überprüfen Sie die isHidden‑Eigenschaft.
- Speichern Sie die Präsentation als PPTX‑Datei.

Im unten gezeigten Beispiel haben wir einen Verbinder zwischen zwei Formen hinzugefügt.
```c#
using (Presentation presentation = new Presentation())
{
    // SmartArt BasicProcess hinzufügen 
    ISmartArt smart = presentation.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

    // Knoten zu SmartArt hinzufügen 
    ISmartArtNode node = smart.AllNodes.AddNode();

    // isHidden-Eigenschaft prüfen
    bool hidden = node.IsHidden; // Gibt true zurück

    if (hidden)
    {
        // Einige Aktionen oder Benachrichtigungen ausführen
    }
    // Präsentation speichern
    presentation.Save("CheckSmartArtHiddenProperty_out.pptx", SaveFormat.Pptx);
}
```




## **Organisationsdiagrammtyp abrufen oder festlegen**
Die Methoden com.aspose.slides.ISmartArtNode.getOrganizationChartLayout() und setOrganizationChartLayout(int) ermöglichen das Abrufen bzw. Festlegen des Organisationsdiagrammtyps, der dem aktuellen Knoten zugeordnet ist. Um den Organisationsdiagrammtyp abzurufen oder festzulegen, führen Sie die folgenden Schritte aus:

- Erstellen Sie eine Instanz der `Presentation`‑Klasse.
- Fügen Sie SmartArt auf der Folie hinzu.
- Rufen Sie den Organisationsdiagrammtyp ab oder setzen Sie ihn.
- Speichern Sie die Präsentation als PPTX‑Datei.

Im unten gezeigten Beispiel haben wir einen Verbinder zwischen zwei Formen hinzugefügt.
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





## **Ein Bild‑Organisationsdiagramm erstellen**
Aspose.Slides für .NET bietet eine einfache API zum Erstellen von PictureOrganization‑Diagrammen auf unkomplizierte Weise. So erstellen Sie ein Diagramm auf einer Folie:

1. Erstellen Sie eine Instanz der `Presentation`‑Klasse.
1. Holen Sie die Referenz einer Folie über deren Index.
1. Fügen Sie ein Diagramm mit Standarddaten und dem gewünschten Typ (ChartType.PictureOrganizationChart) hinzu.
1. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

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

**Unterstützt SmartArt das Spiegeln/Umdrehen für RTL‑Sprachen?**

Ja. Die [IsReversed](https://reference.aspose.com/slides/net/aspose.slides.smartart/smartart/isreversed/)‑Eigenschaft ändert die Diagrammrichtung (LTR/RTL), wenn der ausgewählte SmartArt‑Typ eine Umkehrung unterstützt.

**Wie kann ich SmartArt auf derselben Folie oder in eine andere Präsentation kopieren und dabei die Formatierung beibehalten?**

Sie können die [SmartArt‑Form](/slides/de/net/shape-manipulations/) über die Shapes‑Sammlung ([ShapeCollection.AddClone](https://reference.aspose.com/slides/net/aspose.slides/shapecollection/addclone/)) klonen oder die gesamte Folie, die diese Form enthält, [klonen](/slides/de/net/clone-slides/). Beide Ansätze erhalten Größe, Position und Stil.

**Wie rendere ich SmartArt zu einem Rasterbild für die Vorschau oder den Web‑Export?**

Sie können die [Folie rendern](/slides/de/net/convert-powerpoint-to-png/) (oder die gesamte Präsentation) zu PNG/JPEG über die API rendern, die Folien/Präsentationen in Bilder konvertiert – SmartArt wird als Teil der Folie gezeichnet.

**Wie kann ich programmgesteuert ein bestimmtes SmartArt auf einer Folie auswählen, wenn mehrere vorhanden sind?**

Eine gängige Praxis ist die Verwendung von [alternativem Text](https://reference.aspose.com/slides/net/aspose.slides/shape/alternativetext/) (Alt‑Text) oder einem [Name](https://reference.aspose.com/slides/net/aspose.slides/shape/name/) und die Suche nach der Form anhand dieses Attributs innerhalb von [Slide.Shapes](https://reference.aspose.com/slides/net/aspose.slides/baseslide/shapes/). Anschließend prüfen Sie den Typ, um sicherzustellen, dass es sich um [SmartArt](https://reference.aspose.com/slides/net/aspose.slides.smartart/smartart/) handelt. Die Dokumentation beschreibt typische Techniken zum Finden und Arbeiten mit Formen.
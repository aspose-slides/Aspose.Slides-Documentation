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
description: "Lernen Sie, PowerPoint SmartArt mit Aspose.Slides für .NET zu erstellen und zu bearbeiten, anhand klarer C#-Codebeispiele, die das Folien-Design und die Automatisierung beschleunigen."
---

## **Text aus SmartArt abrufen**
Die TextFrame‑Eigenschaft wurde nun zur ISmartArtShape‑Schnittstelle bzw. zur SmartArtShape‑Klasse hinzugefügt. Diese Eigenschaft ermöglicht es, den gesamten Text aus SmartArt abzurufen, falls nicht nur der Text der Knoten vorhanden ist. Der folgende Beispielcode hilft Ihnen, Text aus einem SmartArt‑Knoten zu erhalten.
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
Um den Layouttyp von SmartArt zu ändern, führen Sie die untenstehenden Schritte aus:

- Erstellen Sie eine Instanz der Klasse `Presentation`.
- Holen Sie die Referenz einer Folie über deren Index.
- Fügen Sie SmartArt BasicBlockList hinzu.
- Ändern Sie LayoutType zu BasicProcess.
- Speichern Sie die Präsentation als PPTX-Datei.  
Im untenstehenden Beispiel haben wir einen Verbinder zwischen zwei Formen hinzugefügt.
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
Bitte beachten Sie, dass die Methode com.aspose.slides.ISmartArtNode.isHidden() true zurückgibt, wenn dieser Knoten im Datenmodell ausgeblendet ist. Um die versteckte Eigenschaft eines beliebigen SmartArt‑Knotens zu prüfen, führen Sie die folgenden Schritte aus:

- Erstellen Sie eine Instanz der Klasse `Presentation`.
- Fügen Sie SmartArt RadialCycle hinzu.
- Fügen Sie dem SmartArt einen Knoten hinzu.
- Prüfen Sie die isHidden‑Eigenschaft.
- Speichern Sie die Präsentation als PPTX-Datei.

Im untenstehenden Beispiel haben wir einen Verbinder zwischen zwei Formen hinzugefügt.
```c#
using (Presentation presentation = new Presentation())
{
    // SmartArt BasicProcess hinzufügen 
    ISmartArt smart = presentation.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

    // Knoten zum SmartArt hinzufügen 
    ISmartArtNode node = smart.AllNodes.AddNode();

    // isHidden‑Eigenschaft prüfen
    bool hidden = node.IsHidden; // Gibt true zurück

    if (hidden)
    {
        // Einige Aktionen oder Benachrichtigungen ausführen
    }
    // Präsentation speichern
    presentation.Save("CheckSmartArtHiddenProperty_out.pptx", SaveFormat.Pptx);
}
```




## **Organisation‑Diagrammtyp abrufen oder festlegen**
Die Methoden com.aspose.slides.ISmartArtNode.getOrganizationChartLayout() und setOrganizationChartLayout(int) ermöglichen das Abrufen bzw. Festlegen des Organisation‑Diagrammtyps, der dem aktuellen Knoten zugeordnet ist. Um den Organisation‑Diagrammtyp abzurufen oder festzulegen, führen Sie die folgenden Schritte aus:

- Erstellen Sie eine Instanz der Klasse `Presentation`.
- Fügen Sie SmartArt auf einer Folie hinzu.
- Rufen Sie den Organisation‑Diagrammtyp ab oder legen Sie ihn fest.
- Speichern Sie die Präsentation als PPTX-Datei.  
Im untenstehenden Beispiel haben wir einen Verbinder zwischen zwei Formen hinzugefügt.
```c#
using (Presentation presentation = new Presentation())
{
    // SmartArt BasicProcess hinzufügen 
    ISmartArt smart = presentation.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

    // OrganisationDiagrammtyp abrufen oder festlegen 
    smart.Nodes[0].OrganizationChartLayout = OrganizationChartLayoutType.LeftHanging;

    // Präsentation speichern
    presentation.Save("OrganizeChartLayoutType_out.pptx", SaveFormat.Pptx);
}
```





## **Picture‑Organisations‑Diagramm erstellen**
Aspose.Slides für .NET bietet eine einfache API zum Erstellen von PictureOrganization‑Diagrammen. So erstellen Sie ein Diagramm auf einer Folie:

1. Erstellen Sie eine Instanz der `Presentation`‑Klasse.
2. Holen Sie die Referenz einer Folie über deren Index.
3. Fügen Sie ein Diagramm mit Standarddaten und dem gewünschten Typ (ChartType.PictureOrganizationChart) hinzu.
4. Schreiben Sie die geänderte Präsentation in eine PPTX‑Datei

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

**Unterstützt SmartArt Spiegeln/Umkehren für RTL-Sprachen?**

Ja. Die [IsReversed](https://reference.aspose.com/slides/net/aspose.slides.smartart/smartart/isreversed/)‑Eigenschaft ändert die Diagrammrichtung (LTR/RTL), wenn der ausgewählte SmartArt‑Typ die Umkehrung unterstützt.

**Wie kann ich SmartArt auf derselben Folie oder in einer anderen Präsentation kopieren und dabei die Formatierung beibehalten?**

Sie können die [SmartArt‑Form klonen](/slides/de/net/shape-manipulations/) über die Formen‑Sammlung ([ShapeCollection.AddClone](https://reference.aspose.com/slides/net/aspose.slides/shapecollection/addclone/)) oder die gesamte Folie, die diese Form enthält, [klonen](/slides/de/net/clone-slides/). Beide Vorgehensweisen erhalten Größe, Position und Stil.

**Wie rendere ich SmartArt zu einem Rasterbild für die Vorschau oder den Web‑Export?**

[Rendern Sie die Folie](/slides/de/net/convert-powerpoint-to-png/) (oder die gesamte Präsentation) zu PNG/JPEG über die API, die Folien/Präsentationen in Bilder konvertiert – SmartArt wird dabei als Teil der Folie dargestellt.

**Wie kann ich programmgesteuert ein bestimmtes SmartArt auf einer Folie auswählen, wenn mehrere vorhanden sind?**

Eine gängige Praxis besteht darin, [alternativen Text](https://reference.aspose.com/slides/net/aspose.slides/shape/alternativetext/) (Alt‑Text) oder einen [Namen](https://reference.aspose.com/slides/net/aspose.slides/shape/name/) zu verwenden und die Form anhand dieses Attributs in [Slide.Shapes](https://reference.aspose.com/slides/net/aspose.slides/baseslide/shapes/) zu suchen, dann den Typ zu überprüfen, um sicherzustellen, dass es sich um [SmartArt](https://reference.aspose.com/slides/net/aspose.slides.smartart/smartart/) handelt. Die Dokumentation beschreibt typische Techniken zum Finden und Arbeiten mit Formen.
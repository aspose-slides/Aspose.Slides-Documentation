---
title: SmartArt verwalten
type: docs
weight: 10
url: /de/net/manage-smartart/
keywords: "SmartArt, Text von SmartArt, Organisationstyp-Diagramm, Bild-Organisationsdiagramm, PowerPoint-Präsentation, C#, Csharp, Aspose.Slides für .NET"
description: "SmartArt und Organisationstyp-Diagramm in PowerPoint-Präsentationen in C# oder .NET"
---

## **Text von SmartArt abrufen**
Jetzt wurde die TextFrame-Eigenschaft zum ISmartArtShape-Interface und zur SmartArtShape-Klasse hinzugefügt. Diese Eigenschaft ermöglicht es Ihnen, gesamten Text von SmartArt abzurufen, sofern nicht nur Knotentext vorhanden ist. Der folgende Beispielcode hilft Ihnen, Text aus einem SmartArt-Knoten zu erhalten.

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
Um den Layouttyp von SmartArt zu ändern, folgen Sie bitte den folgenden Schritten:

- Erstellen Sie eine Instanz der `Presentation`-Klasse.
- Erhalten Sie die Referenz einer Folie, indem Sie ihren Index verwenden.
- Fügen Sie SmartArt BasicBlockList hinzu.
- Ändern Sie den Layouttyp in BasicProcess.
- Schreiben Sie die Präsentation als PPTX-Datei.
  Im folgenden Beispiel haben wir einen Connector zwischen zwei Formen hinzugefügt.

```c#
using (Presentation presentation = new Presentation())
{
    // Fügen Sie SmartArt BasicProcess hinzu 
    ISmartArt smart = presentation.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

    // Ändern Sie den Layouttyp in BasicProcess
    smart.Layout = SmartArtLayoutType.BasicProcess;

    // Präsentation speichern
    presentation.Save("ChangeSmartArtLayout_out.pptx", SaveFormat.Pptx);
}
```



## **Versteckte Eigenschaft von SmartArt überprüfen**
Bitte beachten Sie, dass die Methode com.aspose.slides.ISmartArtNode.isHidden() true zurückgibt, wenn dieser Knoten ein versteckter Knoten im Datenmodell ist. Um die versteckte Eigenschaft eines beliebigen Knotens von SmartArt zu überprüfen, folgen Sie bitte den folgenden Schritten:

- Erstellen Sie eine Instanz der `Presentation`-Klasse.
- Fügen Sie SmartArt RadialCycle hinzu.
- Fügen Sie einen Knoten zu SmartArt hinzu.
- Überprüfen Sie die isHidden-Eigenschaft.
- Schreiben Sie die Präsentation als PPTX-Datei.

Im folgenden Beispiel haben wir einen Connector zwischen zwei Formen hinzugefügt.

```c#
using (Presentation presentation = new Presentation())
{
    // Fügen Sie SmartArt BasicProcess hinzu 
    ISmartArt smart = presentation.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

    // Fügen Sie einen Knoten zu SmartArt hinzu 
    ISmartArtNode node = smart.AllNodes.AddNode();

    // Überprüfen Sie die isHidden-Eigenschaft
    bool hidden = node.IsHidden; // Gibt true zurück

    if (hidden)
    {
        // Führen Sie einige Aktionen oder Benachrichtigungen durch
    }
    // Präsentation speichern
    presentation.Save("CheckSmartArtHiddenProperty_out.pptx", SaveFormat.Pptx);
}
```



## **Organisationstyp-Diagramm abrufen oder festlegen**
Die Methoden com.aspose.slides.ISmartArtNode.getOrganizationChartLayout(), setOrganizationChartLayout(int) ermöglichen das Abrufen oder Festlegen des Organisationstyp-Diagramms, das mit dem aktuellen Knoten verbunden ist. Um den Organisationstyp-Diagramm abzurufen oder festzulegen, folgen Sie bitte den folgenden Schritten:

- Erstellen Sie eine Instanz der `Presentation`-Klasse.
- Fügen Sie SmartArt auf die Folie hinzu.
- Abrufen oder Festlegen des Organisationstyp-Diagramms.
- Schreiben Sie die Präsentation als PPTX-Datei.
  Im folgenden Beispiel haben wir einen Connector zwischen zwei Formen hinzugefügt.

```c#
using (Presentation presentation = new Presentation())
{
    // Fügen Sie SmartArt BasicProcess hinzu 
    ISmartArt smart = presentation.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

    // Abrufen oder Festlegen des Organisationstyp-Diagramms 
    smart.Nodes[0].OrganizationChartLayout = OrganizationChartLayoutType.LeftHanging;

    // Präsentation speichern
    presentation.Save("OrganizeChartLayoutType_out.pptx", SaveFormat.Pptx);
}
```




## **Bild-Organisationsdiagramm erstellen**
Aspose.Slides für .NET bietet eine einfache API zum Erstellen von Bild-Organisationsdiagrammen auf einfache Weise. Um ein Diagramm auf einer Folie zu erstellen:

1. Erstellen Sie eine Instanz der `Presentation`-Klasse.
1. Erhalten Sie die Referenz einer Folie durch ihren Index.
1. Fügen Sie ein Diagramm mit Standarddaten zusammen mit dem gewünschten Typ (ChartType.PictureOrganizationChart) hinzu.
1. Schreiben Sie die bearbeitete Präsentation in eine PPTX-Datei.

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
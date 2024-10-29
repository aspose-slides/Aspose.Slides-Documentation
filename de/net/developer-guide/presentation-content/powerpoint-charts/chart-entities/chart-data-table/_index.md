---
title: Diagrammdaten Tabelle
type: docs
url: /de/net/chart-data-table/
keywords: "Schriftarten, Diagrammdaten Tabelle, PowerPoint-Präsentation, C#, Csharp, Aspose.Slides für .NET"
description: "Schriftarteigenschaften für die Diagrammdaten Tabelle in PowerPoint-Präsentationen in C# oder .NET setzen"
---

## **Schriftarteigenschaften für Diagrammdaten Tabelle setzen**
Aspose.Slides für .NET bietet Unterstützung für die Farbänderung von Kategorien in einer Serienfarbe.

1. Instanziiere [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klassenobjekt.
2. Füge ein Diagramm auf der Folie hinzu.
3. Setze die Diagrammtabelle.
4. Setze die Schriftgröße.
5. Speichere die modifizierte Präsentation.

Nachfolgend ein Beispiel:

```c#
using (Presentation pres = new Presentation("test.pptx"))
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

	chart.HasDataTable = true;

	chart.ChartDataTable.TextFormat.PortionFormat.FontBold = NullableBool.True;
	chart.ChartDataTable.TextFormat.PortionFormat.FontHeight = 20;

	pres.Save("output.pptx", SaveFormat.Pptx);
}
```
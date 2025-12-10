---
title: Diagrammdatentabellen in Präsentationen in .NET anpassen
linktitle: Datentabelle
type: docs
url: /de/net/chart-data-table/
keywords:
- Diagrammdaten
- Datentabelle
- Schrifteigenschaften
- PowerPoint
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Diagrammdatentabellen in .NET für PPT und PPTX mit Aspose.Slides anpassen, um Effizienz und Attraktivität von Präsentationen zu steigern."
---

## **Schriftart-Eigenschaften für eine Diagrammdatentabelle festlegen**
Aspose.Slides für .NET bietet Unterstützung für das Ändern der Farbe von Kategorien in einer Serienfarbe.

1. Instanziieren Sie das [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klassenobjekt.
1. Fügen Sie dem Folie ein Diagramm hinzu.
1. Setzen Sie die Diagrammtabelle.
1. Stellen Sie die Schriftgröße ein.
1. Speichern Sie die geänderte Präsentation.

Nachstehendes Beispiel wird angezeigt.
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


## **FAQ**

**Kann ich kleine Legenden‑Schlüssel neben den Werten in der Datentabelle des Diagramms anzeigen?**

Ja. Die Datentabelle unterstützt [legend keys](https://reference.aspose.com/slides/net/aspose.slides.charts/datatable/showlegendkey/), und Sie können sie ein‑ oder ausschalten.

**Wird die Datentabelle beim Export der Präsentation nach PDF, HTML oder Bildern beibehalten?**

Ja. Aspose.Slides rendert das Diagramm als Teil der Folie, sodass das exportierte [PDF](/slides/de/net/convert-powerpoint-to-pdf/)/[HTML](/slides/de/net/convert-powerpoint-to-html/)/[image](/slides/de/net/convert-powerpoint-to-png/) das Diagramm mit seiner Datentabelle enthält.

**Werden Datentabellen für Diagramme unterstützt, die aus einer Vorlagendatei stammen?**

Ja. Für jedes Diagramm, das aus einer bestehenden Präsentation oder Vorlage geladen wird, können Sie prüfen und ändern, ob eine Datentabelle [is shown](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/hasdatatable/) wird, indem Sie die Eigenschaften des Diagramms verwenden.

**Wie kann ich schnell herausfinden, welche Diagramme in einer Datei die Datentabelle aktiviert haben?**

Untersuchen Sie die Eigenschaft jedes Diagramms, die angibt, ob die Datentabelle [is shown](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/hasdatatable/) wird, und iterieren Sie über die Folien, um die Diagramme zu identifizieren, bei denen sie aktiviert ist.
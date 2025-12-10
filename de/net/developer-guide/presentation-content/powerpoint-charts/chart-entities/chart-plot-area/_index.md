---
title: Anpassen von Plotbereichen von Präsentationsdiagrammen in .NET
linktitle: Plotbereich
type: docs
url: /de/net/chart-plot-area/
keywords:
- Diagramm
- Plotbereich
- Plotbereich Breite
- Plotbereich Höhe
- Plotbereich Größe
- Layoutmodus
- PowerPoint
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Entdecken Sie, wie Sie Plotbereiche von Diagrammen in PowerPoint-Präsentationen mit Aspose.Slides für .NET anpassen können. Verbessern Sie mühelos die Visualisierung Ihrer Folien."
---

## **Breite und Höhe eines Diagramm-Plotbereichs abrufen**
Aspose.Slides für .NET stellt eine einfache API bereit.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse.  
2. Greifen Sie auf die erste Folie zu.  
3. Fügen Sie ein Diagramm mit Standarddaten hinzu.  
4. Rufen Sie die Methode IChart.ValidateChartLayout() auf, bevor Sie die tatsächlichen Werte erhalten.  
5. Ermittelt die tatsächliche X-Position (links) des Diagrammelements relativ zur linken oberen Ecke des Diagramms.  
6. Ermittelt die tatsächliche obere Position des Diagrammelements relativ zur linken oberen Ecke des Diagramms.  
7. Ermittelt die tatsächliche Breite des Diagrammelements.  
8. Ermittelt die tatsächliche Höhe des Diagrammelements.  
```c#
using (Presentation pres = new Presentation("test.Pptx"))
{
    Chart chart = (Chart)pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 500, 350);
    chart.ValidateChartLayout();

    double x = chart.PlotArea.ActualX;
    double y = chart.PlotArea.ActualY;
    double w = chart.PlotArea.ActualWidth;
    double h = chart.PlotArea.ActualHeight;
	
	// Präsentation mit Diagramm speichern
	pres.Save("Chart_out.pptx", SaveFormat.Pptx);
}
```


## **Layoutmodus eines Diagramm-Plotbereichs festlegen**
Aspose.Slides für .NET bietet eine einfache API zum Festlegen des Layoutmodus des Diagramm-Plotbereichs. Die Eigenschaft **LayoutTargetType** wurde zu den Klassen **ChartPlotArea** und **IChartPlotArea** hinzugefügt. Wenn das Layout des Plotbereichs manuell definiert ist, gibt diese Eigenschaft an, ob der Plotbereich nach seinem Inneren (ohne Achsen und Achsenbeschriftungen) oder nach außen (einschließlich Achsen und Achsenbeschriftungen) ausgerichtet werden soll. Es gibt zwei mögliche Werte, die im Enum **LayoutTargetType** definiert sind.

- **LayoutTargetType.Inner** – gibt an, dass die Größe des Plotbereichs die Größe des Plotbereichs bestimmt, ohne die Teilstriche und Achsenbeschriftungen.  
- **LayoutTargetType.Outer** – gibt an, dass die Größe des Plotbereichs die Größe des Plotbereichs, die Teilstriche und die Achsenbeschriftungen bestimmt.  

Beispielcode ist unten angegeben.  
```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 100, 600, 400);
    chart.PlotArea.AsILayoutable.X = 0.2f;
    chart.PlotArea.AsILayoutable.Y = 0.2f;
    chart.PlotArea.AsILayoutable.Width = 0.7f;
    chart.PlotArea.AsILayoutable.Height = 0.7f;
    chart.PlotArea.LayoutTargetType = LayoutTargetType.Inner;

    presentation.Save("SetLayoutMode_outer.pptx", SaveFormat.Pptx);
}
```


## **FAQ**

**In welchen Einheiten werden ActualX, ActualY, ActualWidth und ActualHeight zurückgegeben?**

In Punkten; 1 Zoll = 72 Punkte. Dies sind Aspose.Slides‑Koordinateneinheiten.

**Wie unterscheidet sich der Plotbereich vom Diagrammbereich in Bezug auf den Inhalt?**

Der Plotbereich ist der Datenzeichnungsbereich (Serien, Gitternetzlinien, Trendlinien usw.); der Diagrammbereich umfasst die umliegenden Elemente (Titel, Legende usw.). In 3D‑Diagrammen beinhaltet der Plotbereich zudem die Wände/Boden und die Achsen.

**Wie werden die X‑, Y‑, Breiten‑ und Höhenwerte des Plotbereichs interpretiert, wenn das Layout manuell ist?**

Sie sind Bruchteile (0–1) der Gesamtabmessungen des Diagramms; in diesem Modus ist die automatische Positionierung deaktiviert und die von Ihnen festgelegten Bruchteile werden verwendet.

**Warum hat sich die Position des Plotbereichs nach dem Hinzufügen/Bewegen der Legende geändert?**

Die Legende befindet sich im Diagrammbereich außerhalb des Plotbereichs, beeinflusst jedoch das Layout und den verfügbaren Raum, sodass sich der Plotbereich verschieben kann, wenn die automatische Positionierung aktiv ist. (Dies ist das Standardverhalten von PowerPoint‑Diagrammen.)
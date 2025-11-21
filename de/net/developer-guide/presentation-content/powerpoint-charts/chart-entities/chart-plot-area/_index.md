---
title: Diagramm‑Plot‑Bereiche in Präsentationen in .NET anpassen
linktitle: Plot‑Bereich
type: docs
url: /de/net/chart-plot-area/
keywords:
- Diagramm
- Plot‑Bereich
- Plot‑Bereich Breite
- Plot‑Bereich Höhe
- Plot‑Bereich Größe
- Layoutmodus
- PowerPoint
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Entdecken Sie, wie Sie Plotbereiche von Diagrammen in PowerPoint‑Präsentationen mit Aspose.Slides für .NET anpassen. Verbessern Sie Ihre Folienvisualisierung mühelos."
---

## **Breite und Höhe des Diagramm‑Plot‑Bereichs abrufen**
Aspose.Slides für .NET stellt eine einfache API zur Verfügung für .  

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)‑Klasse.  
1. Greifen Sie auf die erste Folie zu.  
1. Fügen Sie ein Diagramm mit Standarddaten hinzu.  
1. Rufen Sie die Methode IChart.ValidateChartLayout() auf, bevor Sie die tatsächlichen Werte erhalten.  
1. Ermittelt die tatsächliche X‑Position (links) des Diagrammelements relativ zur linken oberen Ecke des Diagramms.  
1. Ermittelt die tatsächliche Y‑Position (oben) des Diagrammelements relativ zur linken oberen Ecke des Diagramms.  
1. Ermittelt die tatsächliche Breite des Diagrammelements.  
1. Ermittelt die tatsächliche Höhe des Diagrammelements.  
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




## **Layout‑Modus des Diagramm‑Plot‑Bereichs festlegen**
Aspose.Slides für .NET bietet eine einfache API zum Festlegen des Layout‑Modus des Diagramm‑Plot‑Bereichs. Die Eigenschaft **LayoutTargetType** wurde zu den Klassen **ChartPlotArea** und **IChartPlotArea** hinzugefügt. Wenn das Layout des Plot‑Bereichs manuell definiert wird, gibt diese Eigenschaft an, ob der Plot‑Bereich nach seinem Inneren (ohne Achsen und Achsenbeschriftungen) oder nach seinem Äußeren (einschließlich Achsen und Achsenbeschriftungen) ausgerichtet werden soll. Es gibt zwei mögliche Werte, die im **LayoutTargetType**‑Enum definiert sind.

- **LayoutTargetType.Inner** – gibt an, dass die Größe des Plot‑Bereichs die Größe des Plot‑Bereichs bestimmt, ohne die Tick‑Marks und Achsenbeschriftungen.  
- **LayoutTargetType.Outer** – gibt an, dass die Größe des Plot‑Bereichs die Größe des Plot‑Bereichs, die Tick‑Marks und die Achsenbeschriftungen bestimmt.  

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

In Punkten; 1 Zoll = 72 Punkte. Dies sind Koordinateneinheiten von Aspose.Slides.

**Wie unterscheidet sich der Plot‑Bereich vom Diagrammbereich in Bezug auf den Inhalt?**

Der Plot‑Bereich ist der Datenzeichnungsbereich (Serien, Gitternetzlinien, Trendlinien usw.); der Diagrammbereich umfasst die umgebenden Elemente (Titel, Legende usw.). In 3D‑Diagrammen schließt der Plot‑Bereich außerdem die Wände/Boden und die Achsen ein.

**Wie werden die X‑, Y‑, Breiten‑ und Höhenwerte des Plot‑Bereichs interpretiert, wenn das Layout manuell ist?**

Sie sind Bruchteile (0–1) der Gesamtabmessungen des Diagramms; in diesem Modus ist die automatische Positionierung deaktiviert und die von Ihnen festgelegten Bruchteile werden verwendet.

**Warum änderte sich die Position des Plot‑Bereichs nach dem Hinzufügen/Bewegen der Legende?**

Die Legende befindet sich im Diagrammbereich außerhalb des Plot‑Bereichs, beeinflusst jedoch das Layout und den verfügbaren Platz, sodass der Plot‑Bereich verschoben werden kann, wenn die automatische Positionierung aktiv ist. (Dies ist das Standardverhalten von PowerPoint‑Diagrammen.)
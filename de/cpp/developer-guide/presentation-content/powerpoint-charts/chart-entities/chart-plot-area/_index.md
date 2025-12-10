---
title: "Plotbereiche von Präsentationsdiagrammen in C++ anpassen"
linktitle: "Plotbereich"
type: docs
url: /de/cpp/chart-plot-area/
keywords:
- Diagramm
- Plotbereich
- Plotbereichsbreite
- Plotbereichshöhe
- Plotbereichsgröße
- Layoutmodus
- PowerPoint
- Präsentation
- C++
- Aspose.Slides
description: "Entdecken Sie, wie Sie Plotbereiche von Diagrammen in PowerPoint-Präsentationen mit Aspose.Slides für C++ anpassen können. Verbessern Sie mühelos die Visualisierung Ihrer Folien."
---

## **Breite und Höhe eines Chart-Plotbereichs abrufen**
Aspose.Slides für C++ stellt eine einfache API für . 

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) Klasse.
1. Greifen Sie auf die erste Folie zu.
1. Fügen Sie ein Diagramm mit Standarddaten hinzu.
1. Rufen Sie die Methode IChart::ValidateChartLayout() auf, bevor Sie die tatsächlichen Werte erhalten.
1. Ermittelt den tatsächlichen X-Standort (links) des Diagrammelements relativ zur linken oberen Ecke des Diagramms.
1. Ermittelt das tatsächliche obere Ende des Diagrammelements relativ zur linken oberen Ecke des Diagramms.
1. Ermittelt die tatsächliche Breite des Diagrammelements.
1. Ermittelt die tatsächliche Höhe des Diagrammelements.
``` cpp
auto pres = System::MakeObject<Presentation>(u"test.Pptx");
    
auto chart = System::ExplicitCast<Chart>(pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::ClusteredColumn, 100.0f, 100.0f, 500.0f, 350.0f));
chart->ValidateChartLayout();

double x = chart->get_PlotArea()->get_ActualX();
double y = chart->get_PlotArea()->get_ActualY();
double w = chart->get_PlotArea()->get_ActualWidth();
double h = chart->get_PlotArea()->get_ActualHeight();

// Präsentation mit Diagramm speichern
pres->Save(u"Chart_out.pptx", SaveFormat::Pptx);
```


## **Layoutmodus eines Chart-Plotbereichs festlegen**
Aspose.Slides für C++ stellt eine einfache API bereit, um den Layoutmodus des Chart-Plotbereichs festzulegen. Die Eigenschaft **LayoutTargetType** wurde zu den Klassen **ChartPlotArea** und **IChartPlotArea** hinzugefügt. Wenn das Layout des Plotbereichs manuell definiert wird, gibt diese Eigenschaft an, ob der Plotbereich nach seiner Innenfläche (ohne Achsen und Achsenbeschriftungen) oder nach seiner Außenfläche (einschließlich Achsen und Achsenbeschriftungen) ausgerichtet werden soll. Es gibt zwei mögliche Werte, die im **LayoutTargetType**-Enum definiert sind.

- **LayoutTargetType.Inner** - gibt an, dass die Größe des Plotbereichs die Größe des Plotbereichs bestimmt, ohne die Teilstriche und Achsenbeschriftungen.
- **LayoutTargetType.Outer** - gibt an, dass die Größe des Plotbereichs die Größe des Plotbereichs, die Teilstriche und die Achsenbeschriftungen bestimmt.

Sample code is given below.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SetLayoutMode-SetLayoutMode.cpp" >}}

## **FAQ**

**In welchen Einheiten werden ActualX, ActualY, ActualWidth und ActualHeight zurückgegeben?**

In Punkten; 1 Zoll = 72 Punkte. Dies sind Koordinateneinheiten von Aspose.Slides.

**Wie unterscheidet sich der Plotbereich vom Diagrammbereich hinsichtlich des Inhalts?**

Der Plotbereich ist der Bereich, in dem die Daten gezeichnet werden (Serien, Gitternetzlinien, Trendlinien usw.); der Diagrammbereich umfasst die umliegenden Elemente (Titel, Legende usw.). In 3‑D‑Diagrammen enthält der Plotbereich außerdem die Wände/den Boden und die Achsen.

**Wie werden die X-, Y-, Breiten- und Höhenwerte des Plotbereichs interpretiert, wenn das Layout manuell ist?**

Sie sind Bruchteile (0‑1) der Gesamtabmessungen des Diagramms; in diesem Modus ist die automatische Positionierung deaktiviert und die von Ihnen festgelegten Bruchteile werden verwendet.

**Warum hat sich die Position des Plotbereichs geändert, nachdem die Legende hinzugefügt/verschoben wurde?**

Die Legende befindet sich im Diagrammbereich außerhalb des Plotbereichs, beeinflusst jedoch das Layout und den verfügbaren Platz, sodass der Plotbereich sich verschieben kann, wenn die automatische Positionierung aktiv ist. (Dies ist das standardmäßige Verhalten von PowerPoint‑Diagrammen.)
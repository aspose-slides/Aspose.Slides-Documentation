---
title: Anpassen von Plotbereichen von Präsentationsdiagrammen in C++
linktitle: Plotbereich
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
description: "Entdecken Sie, wie Sie Plotbereiche von Diagrammen in PowerPoint‑Präsentationen mit Aspose.Slides für C++ anpassen können. Verbessern Sie mühelos die Visualisierung Ihrer Folien."
---
## **Übersicht**

Dieser Artikel zeigt, wie man mit dem Plotbereich eines Diagramms in Aspose.Slides arbeitet. Er erklärt, wie man die tatsächliche Position und Größe des Plotbereichs erhält, indem man das Diagrammlayout validiert und anschließend die Werte für X, Y, Breite und Höhe ausliest.

Er demonstriert außerdem, wie man den Layoutmodus des Plotbereichs konfiguriert, wenn das Layout manuell festgelegt wird, wobei `LayoutTargetType` verwendet wird, um zu definieren, ob der Plotbereich anhand seines inneren Bereichs oder anhand seines äußeren Bereichs zusammen mit Achsen und Achsenbeschriftungen berechnet wird.

## **Breite und Höhe eines Diagramm‑Plotbereichs abrufen**
Aspose.Slides für C++ bietet eine einfache API für .

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/cpp/class/aspose.slides.presentation) Klasse.
1. Greifen Sie auf die erste Folie zu.
1. Fügen Sie ein Diagramm mit Standarddaten hinzu.
1. Rufen Sie die Methode IChart::ValidateChartLayout() auf, um die tatsächlichen Werte zu erhalten.
1. Gibt die tatsächliche X‑Position (links) des Diagrammelements relativ zur linken oberen Ecke des Diagramms zurück.
1. Gibt die tatsächliche obere Position des Diagrammelements relativ zur linken oberen Ecke des Diagramms zurück.
1. Gibt die tatsächliche Breite des Diagrammelements zurück.
1. Gibt die tatsächliche Höhe des Diagrammelements zurück.

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


## **Layoutmodus eines Diagramm‑Plotbereichs festlegen**
Aspose.Slides für C++ bietet eine einfache API, um den Layoutmodus des Diagramm‑Plotbereichs festzulegen. Die Eigenschaft **LayoutTargetType** wurde zu den Klassen **ChartPlotArea** und **IChartPlotArea** hinzugefügt. Wenn das Layout des Plotbereichs manuell definiert wird, gibt diese Eigenschaft an, ob der Plotbereich anhand seines Inneren (ohne Achsen und Achsenbeschriftungen) oder Außen (einschließlich Achsen und Achsenbeschriftungen) angeordnet wird. Es gibt zwei mögliche Werte, die im **LayoutTargetType**‑Enum definiert sind.

- **LayoutTargetType.Inner** – gibt an, dass die Größe des Plotbereichs die Größe des Plotbereichs bestimmt, ohne die Tick‑Marks und Achsenbeschriftungen.
- **LayoutTargetType.Outer** – gibt an, dass die Größe des Plotbereichs die Größe des Plotbereichs, die Tick‑Marks und die Achsenbeschriftungen bestimmt.

Beispielcode ist unten angegeben.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SetLayoutMode-SetLayoutMode.cpp" >}}

## **FAQ**

**In welchen Einheiten werden ActualX, ActualY, ActualWidth und ActualHeight zurückgegeben?**

In Punkten; 1 Zoll = 72 Punkte. Dies sind die Koordinateneinheiten von Aspose.Slides.

**Wie unterscheidet sich der Plotbereich vom Diagrammbereich hinsichtlich des Inhalts?**

Der Plotbereich ist der Zeichenbereich für Daten (Serien, Gitternetzlinien, Trendlinien usw.); der Diagrammbereich beinhaltet die umgebenden Elemente (Titel, Legende usw.). Bei 3D‑Diagrammen umfasst der Plotbereich außerdem die Wände/Boden und die Achsen.

**Wie werden X, Y, Breite und Höhe des Plotbereichs interpretiert, wenn das Layout manuell ist?**

Sie sind Bruchteile (0–1) der Gesamtabmessungen des Diagramms; in diesem Modus ist die automatische Positionierung deaktiviert und die von Ihnen festgelegten Bruchteile werden verwendet.

**Warum änderte sich die Position des Plotbereichs nach dem Hinzufügen/Bewegen der Legende?**

Die Legende befindet sich im Diagrammbereich außerhalb des Plotbereichs, beeinflusst jedoch das Layout und den verfügbaren Raum, sodass sich der Plotbereich verschieben kann, wenn die automatische Positionierung aktiv ist. (Dies ist das Standardverhalten von PowerPoint‑Diagrammen.)
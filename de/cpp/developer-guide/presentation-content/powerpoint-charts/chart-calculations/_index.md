---
title: Optimieren von Diagrammberechnungen für Präsentationen in C++
linktitle: Diagrammberechnungen
type: docs
weight: 50
url: /de/cpp/chart-calculations/
keywords:
- Diagrammberechnungen
- Diagrammelemente
- Elementposition
- tatsächliche Position
- Kindelement
- Elternelement
- Diagrammwerte
- tatsächlicher Wert
- PowerPoint
- Präsentation
- C++
- Aspose.Slides
description: "Verstehen Sie Diagrammberechnungen, Datenaktualisierungen und Präzisionssteuerung in Aspose.Slides für C++ für PPT und PPTX, mit praktischen C++-Codebeispielen."
---

## **Tatsächliche Werte von Diagrammelementen berechnen**
Aspose.Slides for C++ bietet eine einfache API zum Abrufen dieser Eigenschaften. Dies hilft Ihnen, die tatsächlichen Werte von Diagrammelementen zu berechnen. Die tatsächlichen Werte umfassen die Position von Elementen, die das IActualLayout-Interface implementieren (IActualLayout::get_ActualX(), IActualLayout::get_ActualY(), IActualLayout::get_ActualWidth(), IActualLayout::get_ActualHeight()) und die tatsächlichen Achsenwerte (IAxis::get_ActualMaxValue(), IAxis::get_ActualMinValue(), IAxis::get_ActualMajorUnit(), IAxis::get_ActualMinorUnit(), IAxis::get_ActualMajorUnitScale(), IAxis::get_ActualMinorUnitScale()).
``` cpp
auto pres = System::MakeObject<Presentation>(u"test.pptx");
    
auto chart = System::ExplicitCast<Chart>(pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::ClusteredColumn, 100.0f, 100.0f, 500.0f, 350.0f));
chart->ValidateChartLayout();

double x = chart->get_PlotArea()->get_ActualX();
double y = chart->get_PlotArea()->get_ActualY();
double w = chart->get_PlotArea()->get_ActualWidth();
double h = chart->get_PlotArea()->get_ActualHeight();

// Präsentation speichern
pres->Save(u"Result.pptx", SaveFormat::Pptx);
```


## **Tatsächliche Position von übergeordneten Diagrammelementen berechnen**
Aspose.Slides for C++ bietet eine einfache API zum Abrufen dieser Eigenschaften. Methoden von IActualLayout liefern Informationen über die tatsächliche Position des übergeordneten Diagrammelements. Es ist erforderlich, zuvor die Methode IChart::ValidateChartLayout() aufzurufen, um die Eigenschaften mit den tatsächlichen Werten zu füllen.
``` cpp
// Leere Präsentation erstellen
auto pres = System::MakeObject<Presentation>();

auto chart = System::ExplicitCast<Chart>(pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::ClusteredColumn, 100.0f, 100.0f, 500.0f, 350.0f));
chart->ValidateChartLayout();

double x = chart->get_PlotArea()->get_ActualX();
double y = chart->get_PlotArea()->get_ActualY();
double w = chart->get_PlotArea()->get_ActualWidth();
double h = chart->get_PlotArea()->get_ActualHeight();
```


## **Diagrammelemente ausblenden**
Dieses Thema hilft Ihnen zu verstehen, wie Informationen aus einem Diagramm ausgeblendet werden können. Mit Aspose.Slides for C++ können Sie **Titel, Vertikale Achse, Horizontale Achse** und **Gitternetzlinien** aus dem Diagramm ausblenden. Das nachstehende Codebeispiel zeigt, wie diese Eigenschaften verwendet werden.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-HideInformationFromChart-HideInformationFromChart.cpp" >}}

## **Datenbereich für ein Diagramm festlegen**
Aspose.Slides for C++ bietet die einfachste API, um den Datenbereich für ein Diagramm auf einfachste Weise festzulegen. So setzen Sie den Datenbereich für ein Diagramm:

- Öffnen Sie eine Instanz der Klasse Presentation, die ein Diagramm enthält.
- Holen Sie sich den Verweis auf eine Folie über deren Index.
- Durchlaufen Sie alle Shapes, um das gewünschte Diagramm zu finden.
- Greifen Sie auf die Diagrammdaten zu und setzen Sie den Bereich.
- Speichern Sie die geänderte Präsentation als PPTX-Datei.

Die folgenden Codebeispiele zeigen, wie ein Diagramm aktualisiert wird.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetDataRange-SetDataRange.cpp" >}}

## **FAQ**

**Funktionieren externe Excel-Arbeitsmappen als Datenquelle und wie wirkt sich das auf die Neuberechnung aus?**

Ja. Ein Diagramm kann auf eine externe Arbeitsmappe verweisen: Wenn Sie die externe Quelle verbinden oder aktualisieren, werden Formeln und Werte aus dieser Arbeitsmappe übernommen, und das Diagramm spiegelt die Aktualisierungen während Öffnen/Bearbeiten wider. Die API ermöglicht es Ihnen, den Pfad zur [externen Arbeitsmappe](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/setexternalworkbook/) anzugeben und die verknüpften Daten zu verwalten.

**Kann ich Trendlinien berechnen und anzeigen, ohne die Regression selbst zu implementieren?**

Ja. [Trendlinien](/slides/de/cpp/trend-line/) (linear, exponentiell und weitere) werden von Aspose.Slides hinzugefügt und aktualisiert; ihre Parameter werden automatisch aus den Seriendaten neu berechnet, sodass Sie keine eigenen Berechnungen implementieren müssen.

**Wenn eine Präsentation mehrere Diagramme mit externen Verknüpfungen enthält, kann ich steuern, welche Arbeitsmappe jedes Diagramm für berechnete Werte verwendet?**

Ja. Jedes Diagramm kann auf seine eigene [externe Arbeitsmappe](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/setexternalworkbook/) verweisen, oder Sie können pro Diagramm eine externe Arbeitsmappe erstellen/ersetzen, unabhängig von den anderen.
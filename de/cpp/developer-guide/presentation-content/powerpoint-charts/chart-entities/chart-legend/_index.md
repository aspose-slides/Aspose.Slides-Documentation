---
title: Diagrammlegenden in Präsentationen mit C++ anpassen
linktitle: Diagrammlegende
type: docs
url: /de/cpp/chart-legend/
keywords:
- Diagrammlegende
- Legendenposition
- Schriftgröße
- PowerPoint
- Präsentation
- C++
- Aspose.Slides
description: "Passen Sie Diagrammlegenden mit Aspose.Slides für C++ an, um PowerPoint-Präsentationen mit individuell formatierter Legende zu optimieren."
---
## **Übersicht**

Aspose.Slides for C++ bietet Optionen zum Anpassen von Diagrammlegenden in PowerPoint‑Präsentationen. Dieser Artikel zeigt, wie man eine Legende positioniert und dimensioniert, die Schriftgröße für die gesamte Legende festlegt, einen einzelnen Legendeeintrag formatiert und ausgewählte Einträge ausblendet oder wiederherstellt.

Die FAQ behandelt verwandte Verhaltensweisen, darunter das Reservieren von Platz für die Legende, das Anzeigen mehrzeiliger Beschriftungen und das Erben von Formatierungen aus dem Präsentationsthema.

## **Positionierung der Legende**

Verwenden Sie die Methoden [set_X](https://reference.aspose.com/slides/cpp/aspose.slides.charts/legend/set_x/), [set_Y](https://reference.aspose.com/slides/cpp/aspose.slides.charts/legend/set_y/), [set_Width](https://reference.aspose.com/slides/cpp/aspose.slides.charts/legend/set_width/) und [set_Height](https://reference.aspose.com/slides/cpp/aspose.slides.charts/legend/set_height/) der Legende, um ihre Position und Größe als Bruchteile der Diagramm­abmessungen anzugeben.

Dieses Beispiel erstellt eine Präsentation und fügt der ersten Folie ein gruppiertes Säulendiagramm mit Standarddaten hinzu. Durch Teilen der gewünschten Legenden‑Offsets und -Abmessungen durch die Breite bzw. Höhe des Diagramms werden sie in relative Werte umgewandelt: Die Legende ist um 50 Punkte vom linken oberen Eck des Diagramms versetzt und hat die Größe 100 × 100 Punkte.

```cpp
#include <system/shared_ptr.h>
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ILegend.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50, 50, 500, 500);

// Ausdruck der Legendenposition und -größe relativ zum Diagramm.
chart->get_Legend()->set_X(50 / chart->get_Width());
chart->get_Legend()->set_Y(50 / chart->get_Height());
chart->get_Legend()->set_Width(100 / chart->get_Width());
chart->get_Legend()->set_Height(100 / chart->get_Height());

presentation->Save(u"legend_position.pptx", SaveFormat::Pptx);
```

## **Schriftgröße einer Legende festlegen**

Verwenden Sie die Methode [get_TextFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/legend/get_textformat/), um auf die Textformatierung der Legende zuzugreifen, und [set_FontHeight](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_fontheight/), um die Schriftgröße in Punkten festzulegen.

Dieses Beispiel erstellt ein Diagramm mit Standarddaten und setzt den Legendentext auf 20 Punkte. Außerdem deaktiviert es automatische Grenzen für die vertikale Achse und legt deren Bereich von ‑5 bis 10 fest.

```cpp
#include <system/shared_ptr.h>
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ILegend.h>
#include <DOM/Chart/IChartTextFormat.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <DOM/Chart/IChartPortionFormat.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50, 50, 600, 400);

chart->get_Legend()->get_TextFormat()->get_PortionFormat()->set_FontHeight(20);
chart->get_Axes()->get_VerticalAxis()->set_IsAutomaticMinValue(false);
chart->get_Axes()->get_VerticalAxis()->set_MinValue(-5);
chart->get_Axes()->get_VerticalAxis()->set_IsAutomaticMaxValue(false);
chart->get_Axes()->get_VerticalAxis()->set_MaxValue(10);

presentation->Save(u"legend_font_size.pptx", SaveFormat::Pptx);
```

## **Schriftgröße eines einzelnen Legendeeintrags festlegen**

Verwenden Sie die von der Methode [get_Entries](https://reference.aspose.com/slides/cpp/aspose.slides.charts/legend/get_entries/) der Legende zurückgegebene Sammlung, um die Formatierung eines bestimmten Eintrags zu ändern. Eintragsindizes beginnen bei Null, sodass Index `1` den zweiten Eintrag bezeichnet.

Dieses Beispiel erstellt ein gruppiertes Säulendiagramm, dessen Standarddaten mindestens zwei Serien enthalten. Es formatiert den zweiten Legendeeintrag mit fett, kursiv und blauem Text in 20 Punkten.

```cpp
#include <system/shared_ptr.h>
#include <drawing/color.h>
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ILegend.h>
#include <DOM/Chart/IChartTextFormat.h>
#include <DOM/Chart/ILegendEntryCollection.h>
#include <DOM/Chart/ILegendEntryProperties.h>
#include <DOM/Chart/IChartPortionFormat.h>
#include <DOM/NullableBool.h>
#include <DOM/IFillFormat.h>
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
auto textFormat = chart->get_Legend()->get_Entries()->idx_get(1)->get_TextFormat();

textFormat->get_PortionFormat()->set_FontBold(NullableBool::True);
textFormat->get_PortionFormat()->set_FontHeight(20);
textFormat->get_PortionFormat()->set_FontItalic(NullableBool::True);
textFormat->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
textFormat->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Blue());

presentation->Save(u"legend_entry_format.pptx", SaveFormat::Pptx);
```

## **Einzelne Legendeeinträge ausblenden**

Um eine Hilfsserie aus der Legende auszuschließen, während ihre Daten sichtbar bleiben, rufen Sie [ILegendEntryProperties::set_Hide](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ilegendentryproperties/set_hide/) mit `true` über [IChartSeries::get_RelatedLegendEntry](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_relatedlegendentry/) auf. Dadurch wird nur der ausgewählte Legendeeintrag ausgeblendet; die Serie oder ihre Datenpunkte werden nicht entfernt. Im Gegensatz dazu blendet ein Aufruf von [IChart::set_HasLegend](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/set_haslegend/) mit `false` die gesamte Legende aus.

Das nachstehende Beispiel erstellt ein gruppiertes Säulendiagramm mit mehreren Serien unter Verwendung von Standarddaten. Es blendet den Legendeeintrag der zweiten Serie (Index `1`) aus und speichert die Präsentation. Anschließend wird der Eintrag wiederhergestellt, indem `set_Hide` mit `false` aufgerufen wird, und es wird eine zweite Kopie gespeichert. Die Säulen bleiben in beiden Dateien sichtbar.

```cpp
#include <system/shared_ptr.h>
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ILegend.h>
#include <DOM/Chart/ILegendEntryProperties.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeries.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
chart->set_HasLegend(true);

auto legendEntry = chart->get_ChartData()->get_Series()->idx_get(1)->get_RelatedLegendEntry();

legendEntry->set_Hide(true);
presentation->Save(u"hidden_legend_entry.pptx", SaveFormat::Pptx);

// Wiederherstellen des gleichen Eintrags ohne Änderung der Diagrammdaten.
legendEntry->set_Hide(false);
presentation->Save(u"restored_legend_entry.pptx", SaveFormat::Pptx);
```

Der Vergleich unten zeigt dasselbe Diagramm mit allen sichtbaren Einträgen und mit dem ausgeblendeten zweiten Eintrag. Die Säulen der zweiten Serie bleiben unverändert.

![Comparison of a chart with all legend entries visible and with Series 2 hidden from the legend; all columns remain visible.](hide-legend-entry.png)

In Säulen-, Balken- und Liniendiagrammen identifizieren Legendeeinträge die Serien. Bei Kreisdiagrammen identifizieren sie einzelne Datenpunkte (Scheiben), daher verwenden Sie stattdessen [IChartDataPoint::get_RelatedLegendEntry](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapoint/get_relatedlegendentry/) auf der ausgewählten Scheibe. Die API dokumentiert diese Datenpunkt‑Methode für die Diagrammtypen `Pie`, `Pie3D`, `ExplodedPie`, `ExplodedPie3D`, `PieOfPie` und `BarOfPie`. Gehen Sie nicht davon aus, dass sie für Donut‑Diagramme gilt, die in dieser Liste nicht enthalten sind.

## **FAQ**

**Kann ich das Diagramm dazu bringen, Platz für die Legende zu reservieren, anstatt sie zu überlagern?**

Ja. Rufen Sie [set_Overlay](https://reference.aspose.com/slides/cpp/aspose.slides.charts/legend/set_overlay/) mit `false` auf, um Platz für die Legende zu reservieren, anstatt sie den Zeichenbereich überlappen zu lassen.

**Kann ich mehrzeilige Legendenbeschriftungen erstellen?**

Ja. Lange Beschriftungen können umbrechen, wenn die verfügbare Breite nicht ausreicht. Sie können auch Zeilenumbrüche in Seriennamen einfügen, um Zeilenumbrüche zu erzwingen.

**Wie kann ich die Legende an das Farbschema des Präsentationsthemas anpassen?**

Lassen Sie die Farben, Füllungen und Schriftarten der Legende unverändert, damit sie die Formatierung des Themas erben kann. Explizite Formatierungen überschreiben die entsprechenden Theme‑Einstellungen.
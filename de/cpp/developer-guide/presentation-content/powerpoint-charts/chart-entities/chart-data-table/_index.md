---
title: Diagrammdatentabellen in Präsentationen mit C++ anpassen
linktitle: Datentabelle
type: docs
url: /de/cpp/chart-data-table/
keywords:
- Diagrammdaten
- Datentabelle
- Schriftarteigenschaften
- PowerPoint
- Präsentation
- C++
- Aspose.Slides
description: "Passen Sie Diagrammdatentabellen in C++ für PPT und PPTX mit Aspose.Slides an, um die Effizienz und Attraktivität von Präsentationen zu steigern."
---
## **Übersicht**

Dieser Artikel erklärt, wie man mit Diagrammdatentabellen in Aspose.Slides arbeitet. Er zeigt, wie man eine Datentabelle für ein Diagramm anzeigt und deren Textformatierung anpasst, indem man Schriftarteigenschaften wie Fettstil und Schriftgröße festlegt. Das Beispiel demonstriert das Laden einer Präsentation, das Hinzufügen eines Diagramms, das Aktivieren der Diagrammdatentabelle, das Anwenden von Schriftarteinstellungen und das Speichern der aktualisierten Präsentation.

## **Schriftarteigenschaften für eine Diagrammdatentabelle festlegen**
Aspose.Slides for C++ ermöglicht das Ändern von Schriftarteigenschaften für eine Diagrammdatentabelle.

1. Instanziieren Sie ein Objekt der Klasse [Presentation](https://reference.aspose.com/slides/de/cpp/class/aspose.slides.presentation).
1. Fügen Sie ein Diagramm zur Folie hinzu.
1. Setzen Sie die Diagrammtabelle.
1. Legen Sie die Schriftgröße fest.
1. Speichern Sie die geänderte Präsentation.

Ein Beispiel ist unten angegeben.

``` cpp
auto pres = System::MakeObject<Presentation>(u"test.pptx");
    
auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f);

chart->set_HasDataTable(true);

chart->get_ChartDataTable()->get_TextFormat()->get_PortionFormat()->set_FontBold(NullableBool::True);
chart->get_ChartDataTable()->get_TextFormat()->get_PortionFormat()->set_FontHeight(20.0f);

pres->Save(u"output.pptx", SaveFormat::Pptx);
```

## **FAQ**

**Kann ich kleine Legenden‑Schlüssel neben den Werten in der Diagrammdatentabelle anzeigen?**

Ja. Die Datentabelle unterstützt [Legenden‑Schlüssel](https://reference.aspose.com/slides/de/cpp/aspose.slides.charts/datatable/set_showlegendkey/), und Sie können sie ein- oder ausschalten.

**Wird die Datentabelle beim Exportieren der Präsentation nach PDF, HTML oder Bildern beibehalten?**

Ja. Aspose.Slides rendert das Diagramm als Teil der Folie, so dass das exportierte [PDF](/slides/de/cpp/convert-powerpoint-to-pdf/)/[HTML](/slides/de/cpp/convert-powerpoint-to-html/)/[Bild](/slides/de/cpp/convert-powerpoint-to-png/) das Diagramm mit seiner Datentabelle enthält.

**Werden Datentabellen für Diagramme unterstützt, die aus einer Vorlagendatei stammen?**

Ja. Für jedes Diagramm, das aus einer vorhandenen Präsentation oder Vorlage geladen wird, können Sie mithilfe der Diagrammeigenschaften prüfen und ändern, ob eine Datentabelle [angezeigt wird](https://reference.aspose.com/slides/de/cpp/aspose.slides.charts/chart/set_hasdatatable/).

**Wie kann ich schnell herausfinden, welche Diagramme in einer Datei die Datentabelle aktiviert haben?**

Überprüfen Sie die Eigenschaft jedes Diagramms, die angibt, ob die Datentabelle [angezeigt wird](https://reference.aspose.com/slides/de/cpp/aspose.slides.charts/chart/get_hasdatatable/), und durchlaufen Sie die Folien, um die Diagramme zu ermitteln, bei denen sie aktiviert ist.
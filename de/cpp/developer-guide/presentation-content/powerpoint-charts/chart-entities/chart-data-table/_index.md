---
title: Diagramm-Daten Tabelle
type: docs
url: /de/cpp/chart-data-table/
---

## **Schriftart-Eigenschaften für Diagramm-Daten Tabelle festlegen**
Aspose.Slides für C++ ermöglicht es, die Schriftart-Eigenschaften für eine Diagramm-Daten Tabelle zu ändern. 

1. Instanziieren Sie [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) Klassenobjekt.
1. Fügen Sie ein Diagramm auf der Folie hinzu.
1. Setzen Sie die Diagrammtabelle.
1. Legen Sie die Schriftgröße fest.
1. Speichern Sie die modifizierte Präsentation.

Im Folgenden ist ein beispielhaftes Beispiel gegeben. 

``` cpp
auto pres = System::MakeObject<Presentation>(u"test.pptx");
    
auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f);

chart->set_HasDataTable(true);

chart->get_ChartDataTable()->get_TextFormat()->get_PortionFormat()->set_FontBold(NullableBool::True);
chart->get_ChartDataTable()->get_TextFormat()->get_PortionFormat()->set_FontHeight(20.0f);

pres->Save(u"output.pptx", SaveFormat::Pptx);
```
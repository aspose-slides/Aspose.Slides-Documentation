---
title: Diagrammdatentabellen in Präsentationen mit C++ anpassen
linktitle: Datentabelle
type: docs
url: /de/cpp/chart-data-table/
keywords:
- Diagrammdaten
- Datentabelle
- Schrifteigenschaften
- PowerPoint
- Präsentation
- C++
- Aspose.Slides
description: "Passen Sie Diagrammdatentabellen in C++ für PPT und PPTX mit Aspose.Slides an, um Effizienz und Attraktivität in Präsentationen zu steigern."
---

## **Schrifteigenschaften für eine Diagrammdatentabelle festlegen**
Aspose.Slides für C++ ermöglicht das Ändern von Schrifteigenschaften für eine Diagrammdatentabelle.  

1. Instanzieren Sie das Klassenobjekt [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
1. Fügen Sie dem Folie ein Diagramm hinzu.
1. Legen Sie die Diagrammtabelle fest.
1. Legen Sie die Schriftgröße fest.
1. Speichern Sie die geänderte Präsentation.

Nachstehendes Beispiel wird angegeben.  
``` cpp
auto pres = System::MakeObject<Presentation>(u"test.pptx");
    
auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f);

chart->set_HasDataTable(true);

chart->get_ChartDataTable()->get_TextFormat()->get_PortionFormat()->set_FontBold(NullableBool::True);
chart->get_ChartDataTable()->get_TextFormat()->get_PortionFormat()->set_FontHeight(20.0f);

pres->Save(u"output.pptx", SaveFormat::Pptx);
```


## **FAQ**

**Kann ich kleine Legenden‑Schlüssel neben den Werten in der Datentabelle des Diagramms anzeigen?**

Ja. Die Datentabelle unterstützt [legend keys](https://reference.aspose.com/slides/cpp/aspose.slides.charts/datatable/set_showlegendkey/), und Sie können sie ein‑ oder ausschalten.

**Wird die Datentabelle beim Exportieren der Präsentation in PDF, HTML oder Bilder beibehalten?**

Ja. Aspose.Slides rendert das Diagramm als Teil der Folie, sodass das exportierte [PDF](/slides/de/cpp/convert-powerpoint-to-pdf/)/[HTML](/slides/de/cpp/convert-powerpoint-to-html/)/[image](/slides/de/cpp/convert-powerpoint-to-png/) das Diagramm mit seiner Datentabelle enthält.

**Werden Datentabellen für Diagramme unterstützt, die aus einer Vorlagendatei stammen?**

Ja. Für jedes Diagramm, das aus einer bestehenden Präsentation oder Vorlage geladen wird, können Sie prüfen und ändern, ob eine Datentabelle [ist angezeigt](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chart/set_hasdatatable/) mittels der Diagrammeigenschaften.

**Wie kann ich schnell herausfinden, welche Diagramme in einer Datei die Datentabelle aktiviert haben?**

Untersuchen Sie die Eigenschaft jedes Diagramms, die angibt, ob die Datentabelle [ist angezeigt](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chart/get_hasdatatable/) und iterieren Sie durch die Folien, um die Diagramme zu identifizieren, bei denen sie aktiviert ist.
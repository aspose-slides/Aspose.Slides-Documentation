---
title: Grafiek-gegevens-tabellen aanpassen in presentaties met C++
linktitle: Gegevenstabel
type: docs
url: /nl/cpp/chart-data-table/
keywords:
- grafiekgegevens
- gegevenstabel
- lettertype-eigenschappen
- PowerPoint
- presentatie
- C++
- Aspose.Slides
description: "Pas grafiek-gegevens-tabellen aan in C++ voor PPT en PPTX met Aspose.Slides om de efficiëntie en aantrekkelijkheid van presentaties te verhogen."
---
## **Overzicht**

Dit artikel legt uit hoe u met gegevens‑tabellen voor grafieken in Aspose.Slides werkt. Het laat zien hoe u een gegevens‑tabel voor een grafiek weergeeft en de tekstopmaak aanpast door lettertype‑eigenschappen zoals vetstijl en letterhoogte in te stellen. Het voorbeeld toont het laden van een presentatie, het toevoegen van een grafiek, het inschakelen van de grafiek‑gegevens‑tabel, het toepassen van lettertype‑instellingen en het opslaan van de bijgewerkte presentatie.

## **Lettertype‑eigenschappen instellen voor een grafiek‑gegevens‑tabel**
Aspose.Slides for C++ maakt het mogelijk om lettertype‑eigenschappen voor een grafiek‑gegevens‑tabel te wijzigen.  

1. Instantieer de [Presentation](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.presentation) klasse‑object.
1. Voeg een grafiek toe op de dia.
1. Stel de grafiek‑tabel in.
1. Stel de lettergrootte in.
1. Sla de gewijzigde presentatie op.

Hieronder staat een voorbeeld.  

``` cpp
auto pres = System::MakeObject<Presentation>(u"test.pptx");
    
auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f);

chart->set_HasDataTable(true);

chart->get_ChartDataTable()->get_TextFormat()->get_PortionFormat()->set_FontBold(NullableBool::True);
chart->get_ChartDataTable()->get_TextFormat()->get_PortionFormat()->set_FontHeight(20.0f);

pres->Save(u"output.pptx", SaveFormat::Pptx);
```

## **FAQ**

**Can I show small legend keys next to the values in the chart’s data table?**

Ja. De gegevens‑tabel ondersteunt [legend keys](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/datatable/set_showlegendkey/), en u kunt ze in- of uitschakelen.

**Will the data table be preserved when exporting the presentation to PDF, HTML, or images?**

Ja. Aspose.Slides rendert de grafiek als onderdeel van de dia, zodat de geëxporteerde [PDF](/slides/nl/cpp/convert-powerpoint-to-pdf/)/[HTML](/slides/nl/cpp/convert-powerpoint-to-html/)/[image](/slides/nl/cpp/convert-powerpoint-to-png/) de grafiek met zijn gegevens‑tabel bevat.

**Are data tables supported for charts that come from a template file?**

Ja. Voor elke grafiek die uit een bestaande presentatie of sjabloon wordt geladen, kunt u via de eigenschappen van de grafiek controleren en wijzigen of een gegevens‑tabel [wordt weergegeven](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/chart/set_hasdatatable/) is.

**How can I quickly find which charts in a file have the data table enabled?**

Inspecteer de eigenschap van elke grafiek die aangeeft of de gegevens‑tabel [is shown](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/chart/get_hasdatatable/) is, en doorloop de dia’s om de grafieken te identificeren waarbij deze is ingeschakeld.
---
title: Aanpassen van grafiek‑gegevens‑tabellen in presentaties met C++
linktitle: Gegevens‑tabel
type: docs
url: /nl/cpp/chart-data-table/
keywords:
- grafiekdata
- gegevens‑tabel
- lettertype‑eigenschappen
- PowerPoint
- presentatie
- C++
- Aspose.Slides
description: "Pas grafiek‑gegevens‑tabellen aan in C++ voor PPT en PPTX met Aspose.Slides om de efficiëntie en aantrekkelijkheid van presentaties te verhogen."
---
## **Overzicht**

Dit artikel legt uit hoe je met gegevens‑tabellen voor grafieken in Aspose.Slides werkt. Het laat zien hoe je een gegevens‑tabel voor een grafiek weergeeft en de tekstopmaak aanpast door lettertype‑eigenschappen in te stellen, zoals vette stijl en lettergrootte. Het voorbeeld toont het laden van een presentatie, het toevoegen van een grafiek, het inschakelen van de gegevens‑tabel voor de grafiek, het toepassen van lettertype‑instellingen en het opslaan van de bijgewerkte presentatie.

## **Lettertype‑eigenschappen instellen voor een grafiek‑gegevens‑tabel**
Aspose.Slides voor C++ maakt het mogelijk om lettertype‑eigenschappen voor een grafiek‑gegevens‑tabel te wijzigen.  

1. Instantieer een [Presentation](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.presentation) klasse‑object.  
1. Voeg een grafiek toe aan de dia.  
1. Stel de grafiek‑tabel in.  
1. Stel de letterhoogte in.  
1. Sla de aangepaste presentatie op.  

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

**Kan ik kleine legende‑sleutels naast de waarden in de gegevens‑tabel van de grafiek weergeven?**

Ja. De gegevens‑tabel ondersteunt [legend keys](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/datatable/set_showlegendkey/), en je kunt ze in- of uitschakelen.

**Wordt de gegevens‑tabel behouden bij het exporteren van de presentatie naar PDF, HTML of afbeeldingen?**

Ja. Aspose.Slides rendert de grafiek als onderdeel van de dia, zodat de geëxporteerde [PDF](/slides/nl/cpp/convert-powerpoint-to-pdf/)/[HTML](/slides/nl/cpp/convert-powerpoint-to-html/)/[image](/slides/nl/cpp/convert-powerpoint-to-png/) de grafiek met zijn gegevens‑tabel bevat.

**Worden gegevens‑tabellen ondersteund voor grafieken die afkomstig zijn uit een sjabloonbestand?**

Ja. Voor elke grafiek die uit een bestaande presentatie of sjabloon is geladen, kun je via de eigenschappen van de grafiek controleren en wijzigen of een gegevens‑tabel [wordt weergegeven](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/chart/set_hasdatatable/) wordt.

**Hoe kan ik snel vinden welke grafieken in een bestand de gegevens‑tabel ingeschakeld hebben?**

Inspecteer de eigenschap van elke grafiek die aangeeft of de gegevens‑tabel [wordt weergegeven](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/chart/get_hasdatatable/) wordt en doorloop de dia's om de grafieken te identificeren waarvoor deze is ingeschakeld.
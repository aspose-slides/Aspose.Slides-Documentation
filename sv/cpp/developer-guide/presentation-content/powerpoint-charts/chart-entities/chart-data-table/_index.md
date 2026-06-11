---
title: Anpassa diagramdatatabeller i presentationer med С++
linktitle: Datatabell
type: docs
url: /sv/cpp/chart-data-table/
keywords:
- diagramdata
- datatabell
- teckensnittsegenskaper
- PowerPoint
- presentation
- С++
- Aspose.Slides
description: "Anpassa diagramdatatabeller i С++ för PPT och PPTX med Aspose.Slides för att öka effektiviteten och attraktiviteten i presentationer."
---
## **Översikt**

Denna artikel förklarar hur man arbetar med diagramdatatabeller i Aspose.Slides. Den visar hur man visar en datatabell för ett diagram och anpassar dess textformatering genom att ange teckensnittsegenskaper såsom fet stil och teckenhöjd. Exemplet demonstrerar hur man laddar en presentation, lägger till ett diagram, aktiverar diagrammets datatabell, tillämpar teckensnittinställningar och sparar den uppdaterade presentationen.

## **Ange teckensnittsegenskaper för en diagramdatatabell**
Aspose.Slides för C++ tillåter att ändra teckensnittsegenskaper för en diagramdatatabell.  

1. Instansiera [Presentation](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.presentation) klassobjekt.  
1. Lägg till ett diagram på bilden.  
1. Ange diagramtabell.  
1. Ange teckenhöjd.  
1. Spara den modifierade presentationen.  

Nedan följer ett exempel.  

``` cpp
auto pres = System::MakeObject<Presentation>(u"test.pptx");
    
auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f);

chart->set_HasDataTable(true);

chart->get_ChartDataTable()->get_TextFormat()->get_PortionFormat()->set_FontBold(NullableBool::True);
chart->get_ChartDataTable()->get_TextFormat()->get_PortionFormat()->set_FontHeight(20.0f);

pres->Save(u"output.pptx", SaveFormat::Pptx);
```

## **Vanliga frågor**

**Kan jag visa små legendar-nycklar bredvid värdena i diagrammets datatabell?**

Ja. Datatabellen stöder [legend keys](https://reference.aspose.com/slides/sv/cpp/aspose.slides.charts/datatable/set_showlegendkey/), och du kan slå på eller av dem.

**Kommer datatabellen att bevaras vid export av presentationen till PDF, HTML eller bilder?**

Ja. Aspose.Slides renderar diagrammet som en del av bilden, så den exporterade [PDF](/slides/sv/cpp/convert-powerpoint-to-pdf/)/[HTML](/slides/sv/cpp/convert-powerpoint-to-html/)/[image](/slides/sv/cpp/convert-powerpoint-to-png/) innehåller diagrammet med dess datatabell.

**Stöds datatabeller för diagram som kommer från en mallfil?**

Ja. För alla diagram som laddas från en befintlig presentation eller mall kan du kontrollera och ändra om en datatabell [is shown](https://reference.aspose.com/slides/sv/cpp/aspose.slides.charts/chart/set_hasdatatable/) med diagrammets egenskaper.

**Hur kan jag snabbt hitta vilka diagram i en fil som har datatabellen aktiverad?**

Inspektera varje diagrams egenskap som indikerar om datatabellen [is shown](https://reference.aspose.com/slides/sv/cpp/aspose.slides.charts/chart/get_hasdatatable/) och gå igenom bilderna för att identifiera de diagram där den är aktiverad.
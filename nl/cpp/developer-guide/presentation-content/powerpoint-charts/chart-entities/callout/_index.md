---
title: Beheer callouts in presentatiediagrammen met С++
linktitle: Callout
type: docs
url: /nl/cpp/callout/
keywords:
- grafiekcallout
- callout gebruiken
- gegevenslabel
- labelopmaak
- PowerPoint
- presentatie
- С++
- Aspose.Slides
description: "Maak en stijl callouts in Aspose.Slides voor С++ met beknopte codevoorbeelden, compatibel met PPT en PPTX om presentatieworkflows te automatiseren."
---
## **Overzicht**

Dit artikel legt uit hoe u kunt werken met callouts voor gegevenslabels van grafieken in Aspose.Slides. Het laat zien hoe u de `set_ShowLabelAsDataCallout`-methode gebruikt om labels als callouts weer te geven, hoe u callout‑gerelateerde labelinstellingen voor een doughnut‑diagram configureert, en geeft aan dat callouts en hun uiterlijk behouden blijven wanneer presentaties worden geëxporteerd naar PDF, HTML5, SVG en raster‑afbeeldingsformaten.

## **Callouts gebruiken**
Nieuwe eigenschap **ShowLabelAsDataCallout** is toegevoegd aan de klasse **DataLabelFormat** en de interface **IDataLabelFormat**, die bepaalt of het gegevenslabel van een opgegeven diagram als data‑callout of als gegevenslabel wordt weergegeven. In het onderstaande voorbeeld hebben we de Callouts ingesteld.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-DisplayChartLabels-DisplayChartLabels.cpp" >}}

## **Callout instellen voor een doughnut‑diagram**
Aspose.Slides voor C++ biedt ondersteuning voor het instellen van de callout‑vorm van serie‑gegevenslabels voor een doughnut‑diagram. Hieronder staat een voorbeeld.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddDoughnutCallout-AddDoughnutCallout.cpp" >}}

## **Veelgestelde vragen**

**Worden callouts behouden bij het converteren van een presentatie naar PDF, HTML5, SVG of afbeeldingen?**

Ja. Callouts maken deel uit van de grafiekweergave, dus wanneer u exporteert naar [PDF](/slides/nl/cpp/convert-powerpoint-to-pdf/), [HTML5](/slides/nl/cpp/export-to-html5/), [SVG](/slides/nl/cpp/render-a-slide-as-an-svg-image/) of [rasterafbeeldingen](/slides/nl/cpp/convert-powerpoint-to-png/), blijven ze behouden samen met de opmaak van de dia.

**Werken aangepaste lettertypen in callouts, en kan hun uiterlijk behouden blijven bij export?**

Ja. Aspose.Slides ondersteunt het [insluiten van lettertypen](/slides/nl/cpp/embedded-font/) in de presentatie en beheert het insluiten van lettertypen tijdens exporten, zoals [PDF](/slides/nl/cpp/convert-powerpoint-to-pdf/), zodat de callouts er op verschillende systemen identiek uitzien.
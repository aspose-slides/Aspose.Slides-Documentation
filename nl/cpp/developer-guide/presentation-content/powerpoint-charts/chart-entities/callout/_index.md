---
title: Beheer call-outs in presentatiediagrammen met C++
linktitle: Callout
type: docs
url: /nl/cpp/callout/
keywords:
- grafiek callout
- callout gebruiken
- gegevenslabel
- labelopmaak
- PowerPoint
- presentatie
- C++
- Aspose.Slides
description: "Maak en style call-outs in Aspose.Slides voor C++ met beknopte codevoorbeelden, compatibel met PPT en PPTX om presentatieworkflows te automatiseren."
---
## **Overzicht**

Dit artikel legt uit hoe je met call-outs voor gegevenslabels van diagrammen in Aspose.Slides werkt. Het laat zien hoe je de `set_ShowLabelAsDataCallout`‑methode gebruikt om labels als call-outs weer te geven, hoe je call-out‑gerelateerde labelinstellingen voor een donut‑diagram configureert, en geeft aan dat call-outs en hun weergave behouden blijven wanneer presentaties worden geëxporteerd naar PDF, HTML5, SVG en raster‑afbeeldingsformaten.

## **Call-outs gebruiken**
De nieuwe eigenschap **ShowLabelAsDataCallout** is toegevoegd aan de klasse **DataLabelFormat** en de interface **IDataLabelFormat**, die bepaalt of het gegevenslabel van een specifiek diagram wordt weergegeven als data‑call-out of als gegevenslabel. In het onderstaande voorbeeld hebben we de call-outs ingesteld.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-DisplayChartLabels-DisplayChartLabels.cpp" >}}

## **Call-out instellen voor een donut‑diagram**
Aspose.Slides voor C++ biedt ondersteuning voor het instellen van de call‑out‑vorm van de series‑gegevenslabels voor een donut‑diagram. Hieronder staat een voorbeeld.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddDoughnutCallout-AddDoughnutCallout.cpp" >}}

## **FAQ**

**Worden call-outs behouden bij het converteren van een presentatie naar PDF, HTML5, SVG of afbeeldingen?**

Ja. Call-outs zijn onderdeel van de diagramweergave, dus wanneer je exporteert naar [PDF](/slides/nl/cpp/convert-powerpoint-to-pdf/), [HTML5](/slides/nl/cpp/export-to-html5/), [SVG](/slides/nl/cpp/render-a-slide-as-an-svg-image/) of [raster images](/slides/nl/cpp/convert-powerpoint-to-png/), blijven ze behouden samen met de opmaak van de dia.

**Werken aangepaste lettertypen in call-outs, en kan hun uiterlijk behouden blijven bij export?**

Ja. Aspose.Slides ondersteunt het [inbedden van lettertypen](/slides/nl/cpp/embedded-font/) in de presentatie en beheert het insluiten van lettertypen tijdens exports zoals [PDF](/slides/nl/cpp/convert-powerpoint-to-pdf/), zodat de call-outs er op verschillende systemen identiek uitzien.
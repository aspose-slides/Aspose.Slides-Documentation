---
title: Grafiektabelgegevens aanpassen in presentaties met JavaScript
linktitle: Gegevenstabel
type: docs
url: /nl/nodejs-java/chart-data-table/
keywords:
- grafiekgegevens
- gegevenstabel
- lettertype-eigenschappen
- PowerPoint
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Pas grafiektabelgegevens aan in JavaScript voor PPT en PPTX met Aspose.Slides voor Node.js via Java om de efficiëntie en aantrekkelijkheid van presentaties te verhogen."
---
## **Overzicht**

Dit artikel legt uit hoe u met grafiektabelgegevens in Aspose.Slides werkt. Het laat zien hoe u een gegevens‑tabel voor een grafiek weergeeft en de tekstopmaak aanpast door lettertype‑eigenschappen in te stellen, zoals vette stijl en letterhoogte. Het voorbeeld laat zien hoe u een presentatie laadt, een grafiek toevoegt, de grafiektabel inschakelt, lettertype‑instellingen toepast en de bijgewerkte presentatie opslaat.

Het bevat ook beknopte antwoorden op veelgestelde vragen over het tonen van legende‑sleutels in een grafiektabel, het behouden van de tabel bij export, werken met grafieken die uit bestaande presentaties of sjablonen zijn geladen, en het identificeren van grafieken waarin de tabel is ingeschakeld.

## **Lettertype‑eigenschappen instellen voor grafiektabel**

Aspose.Slides voor Node.js via Java biedt ondersteuning voor het wijzigen van de kleur van categorieën in een seriekleur.  

1. Instantiseer [Presentatie](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation)‑klasseobject.  
1. Voeg een grafiek toe aan de dia.  
1. Stel de grafiektabel in.  
1. Stel de letterhoogte in.  
1. Sla de gewijzigde presentatie op.  

Hieronder staat een voorbeeld.  

```javascript
// Lege presentatie maken
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setDataTable(true);
    chart.getChartDataTable().getTextFormat().getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    chart.getChartDataTable().getTextFormat().getPortionFormat().setFontHeight(20);
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Kan ik kleine legende‑sleutels naast de waarden in de gegevens‑tabel van de grafiek weergeven?**

Ja. De gegevens‑tabel ondersteunt [legende‑sleutels](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/datatable/setshowlegendkey/), en u kunt ze in- of uitschakelen.

**Wordt de gegevens‑tabel bewaard bij het exporteren van de presentatie naar PDF, HTML of afbeeldingen?**

Ja. Aspose.Slides rendert de grafiek als onderdeel van de dia, dus de geëxporteerde [PDF](/slides/nl/nodejs-java/convert-powerpoint-to-pdf/)/[HTML](/slides/nl/nodejs-java/convert-powerpoint-to-html/)/[image](/slides/nl/nodejs-java/convert-powerpoint-to-png/) bevat de grafiek met zijn gegevens‑tabel.

**Worden gegevens‑tabellen ondersteund voor grafieken die uit een sjabloonbestand komen?**

Ja. Voor elke grafiek die uit een bestaande presentatie of sjabloon is geladen, kunt u controleren en wijzigen of een gegevens‑tabel [is shown](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chart/hasdatatable/) met de eigenschappen van de grafiek.

**Hoe kan ik snel vinden welke grafieken in een bestand de gegevens‑tabel ingeschakeld hebben?**

Inspecteer de eigenschap van elke grafiek die aangeeft of de gegevens‑tabel [is shown](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chart/hasdatatable/) en loop door de dia's om de grafieken te identificeren waarvoor deze is ingeschakeld.
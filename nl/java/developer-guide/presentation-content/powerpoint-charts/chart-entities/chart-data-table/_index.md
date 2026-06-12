---
title: Grafiekgegevens tabellen aanpassen in presentaties met Java
linktitle: Gegevens tabel
type: docs
url: /nl/java/chart-data-table/
keywords:
- grafiekgegevens
- gegevens tabel
- lettertype-eigenschappen
- PowerPoint
- presentatie
- Java
- Aspose.Slides
description: "Pas grafiekgegevens tabellen aan in Java voor PPT en PPTX met Aspose.Slides om de efficiëntie en aantrekkelijkheid van presentaties te verbeteren."
---
## **Overzicht**

Dit artikel legt uit hoe u werkt met gegevens tabellen voor grafieken in Aspose.Slides. Het laat zien hoe u een gegevens tabel voor een grafiek weergeeft en de tekstopmaak aanpast door lettertype‑eigenschappen in te stellen, zoals vette stijl en letterhoogte. Het voorbeeld toont het laden van een presentatie, het toevoegen van een grafiek, het inschakelen van de grafiek‑gegevens tabel, het toepassen van lettertype‑instellingen en het opslaan van de bijgewerkte presentatie.

Het bevat ook korte antwoorden op veelgestelde vragen over het weergeven van legenda‑sleutels in een grafiek‑gegevens tabel, het behouden van de gegevens tabel bij export, werken met grafieken die geladen zijn uit bestaande presentaties of sjablonen, en het identificeren van grafieken waarbij de gegevens tabel is ingeschakeld.

## **Lettertype‑eigenschappen instellen voor een grafiek‑gegevens tabel**
Aspose.Slides for Java biedt ondersteuning voor het wijzigen van de kleur van categorieën in een serie‑kleur.  

1. Instantieer een [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Presentation)‑klasseobject.  
1. Voeg een grafiek toe aan de dia.  
1. Stel de grafiek‑tabel in.  
1. Stel de letterhoogte in.  
1. Sla de gewijzigde presentatie op.  

Zie onderstaand voorbeeld.  

```java
// Lege presentatie maken
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    chart.setDataTable(true);

    chart.getChartDataTable().getTextFormat().getPortionFormat().setFontBold(NullableBool.True);
    chart.getChartDataTable().getTextFormat().getPortionFormat().setFontHeight(20);

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Kan ik kleine legenda‑sleutels naast de waarden in de gegevens tabel van de grafiek weergeven?**

Ja. De gegevens tabel ondersteunt [legenda‑sleutels](https://reference.aspose.com/slides/nl/java/com.aspose.slides/datatable/#setShowLegendKey-boolean-), en u kunt ze in‑ of uitschakelen.

**Wordt de gegevens tabel behouden bij het exporteren van de presentatie naar PDF, HTML of afbeeldingen?**

Ja. Aspose.Slides rendert de grafiek als onderdeel van de dia, waardoor de geëxporteerde [PDF](/slides/nl/java/convert-powerpoint-to-pdf/)/[HTML](/slides/nl/java/convert-powerpoint-to-html/)/[image](/slides/nl/java/convert-powerpoint-to-png/) de grafiek met zijn gegevens tabel bevat.

**Worden gegevens tabellen ondersteund voor grafieken die uit een sjabloonbestand komen?**

Ja. Voor elke grafiek die geladen is uit een bestaande presentatie of sjabloon kunt u controleren en wijzigen of een gegevens tabel [is shown](https://reference.aspose.com/slides/nl/java/com.aspose.slides/chart/#hasDataTable--) wordt weergegeven via de eigenschappen van de grafiek.

**Hoe kan ik snel vinden welke grafieken in een bestand de gegevens tabel ingeschakeld hebben?**

Inspecteer de eigenschap van elke grafiek die aangeeft of de gegevens tabel [is shown](https://reference.aspose.com/slides/nl/java/com.aspose.slides/chart/#hasDataTable--) wordt weergegeven en doorloop de dia's om de grafieken te identificeren waarvoor deze is ingeschakeld.
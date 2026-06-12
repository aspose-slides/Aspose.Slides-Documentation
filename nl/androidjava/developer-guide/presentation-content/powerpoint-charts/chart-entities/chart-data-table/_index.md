---
title: Grafiekgegevenstabellen aanpassen in presentaties op Android
linktitle: Gegevenstabel
type: docs
url: /nl/androidjava/chart-data-table/
keywords:
- grafiekgegevens
- gegevenstabel
- lettertype-eigenschappen
- PowerPoint
- presentatie
- Android
- Java
- Aspose.Slides
description: "Pas grafiekgegevens tabellen aan in Java voor PPT en PPTX met Aspose.Slides voor Android om de efficiëntie en aantrekkelijkheid van presentaties te verhogen."
---
## **Overzicht**

Dit artikel legt uit hoe u kunt werken met gegevens tabellen voor diagrammen in Aspose.Slides. Het toont hoe u een gegevens tabel voor een diagram kunt weergeven en de tekstopmaak kunt aanpassen door lettertype‑eigenschappen in te stellen, zoals vetgedrukt stijl en letterhoogte. Het voorbeeld laat zien hoe een presentatie te laden, een diagram toe te voegen, de gegevens tabel van het diagram in te schakelen, lettertype‑instellingen toe te passen en de bijgewerkte presentatie op te slaan.

## **Lettertype‑eigenschappen instellen voor een gegevens tabel van een diagram**

Aspose.Slides for Android via Java biedt ondersteuning voor het wijzigen van de kleur van categorieën in een reekskleur.

1. Initialiseer het [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation) klasse‑object.
2. Voeg een diagram toe op de dia.
3. Stel de diagramtabel in.
4. Stel de letterhoogte in.
5. Sla de gewijzigde presentatie op.

Hieronder wordt een voorbeeld gegeven.

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

## **Veelgestelde vragen**

**Kan ik kleine legenda‑sleutels naast de waarden in de gegevens tabel van het diagram weergeven?**

Ja. De gegevens tabel ondersteunt [legenda‑sleutels](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/datatable/#setShowLegendKey-boolean-), en u kunt ze in- of uitschakelen.

**Wordt de gegevens tabel behouden bij het exporteren van de presentatie naar PDF, HTML of afbeeldingen?**

Ja. Aspose.Slides rendert het diagram als onderdeel van de dia, zodat de geëxporteerde [PDF](/slides/nl/androidjava/convert-powerpoint-to-pdf/)/[HTML](/slides/nl/androidjava/convert-powerpoint-to-html/)/[image](/slides/nl/androidjava/convert-powerpoint-to-png/) het diagram met de gegevens tabel bevat.

**Worden gegevens tabellen ondersteund voor diagrammen die uit een sjabloonbestand komen?**

Ja. Voor elk diagram dat is geladen uit een bestaande presentatie of sjabloon, kunt u controleren en wijzigen of een gegevens tabel [wordt weergegeven](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/chart/#hasDataTable--) via de eigenschappen van het diagram.

**Hoe kan ik snel vinden welke diagrammen in een bestand de gegevens tabel ingeschakeld hebben?**

Inspecteer de eigenschap van elk diagram die aangeeft of de gegevens tabel [wordt weergegeven](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/chart/#hasDataTable--) wordt weergegeven en doorloop de dia’s om de diagrammen te identificeren waarbij deze is ingeschakeld.
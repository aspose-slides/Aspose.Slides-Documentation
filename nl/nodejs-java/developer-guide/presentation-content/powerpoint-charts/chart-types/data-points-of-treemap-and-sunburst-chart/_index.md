---
title: Aangepaste gegevenspunten in Treemap‑ en Sunburst‑grafieken met JavaScript
linktitle: Gegevenspunten in Treemap‑ en Sunburst‑grafieken
type: docs
url: /nl/nodejs-java/data-points-of-treemap-and-sunburst-chart/
weight: 40
keywords:
- treemap‑grafiek
- sunburst‑grafiek
- hiërarchische grafiek
- gegevenspunt
- gegevenslabel
- takkleur
- PowerPoint
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Leer hoe je hiërarchische gegevens kunt creëren en niveaus, labels en kleuren kunt aanpassen in Treemap‑en Sunburst‑grafieken met Aspose.Slides voor Node.js via Java."
---
## **Overzicht**

Treemap‑ en Sunburst‑grafieken tonen dezelfde soort hiërarchische data, maar gebruiken verschillende lay‑outs. Een Treemap tekent de hiërarchie als geneste rechthoeken waarvan de gebieden de bladwaarden weergeven. Een Sunburst tekent deze als concentrische ringen: groepen op het hoogste niveau staan dicht bij het midden, en bladcategorieën bevinden zich op de buitenste ring.

In Aspose.Slides for Node.js via Java is elke numerieke waarde een [ChartDataPoint](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chartdatapoint/). De [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chartdatapoint/#getDataPointLevels)‑methode geeft toegang tot het blad en de bovenliggende groepen. Dit artikel legt die koppeling uit en laat zien hoe je beide grafiektype's maakt en opmaakt met dezelfde voorbeelddata.

![Een Treemap‑grafiek met consument‑ en bedrijfs‑takken](treemap-hierarchy.png)

![Een Sunburst‑grafiek met dezelfde consument‑ en bedrijfs‑hiërarchie](sunburst-hierarchy.png)

## **Begrijp categorieën, gegevenspunten en niveaus**

De onderstaande voorbeelddata bevat drie categorieniveaus en één numerieke reeks:

| Tak | Stam | Blad | Omzet |
| --- | --- | --- | ---: |
| Consumer | Computers | Laptops | 12 |
| Consumer | Computers | Desktops | 8 |
| Consumer | Mobile | Phones | 15 |
| Consumer | Mobile | Tablets | 6 |
| Business | Services | Consulting | 10 |
| Business | Services | Support | 7 |
| Business | Software | Licenses | 11 |
| Business | Software | Subscriptions | 14 |

Elke rij maakt één bladcategorie en één gegevenspunt aan. De niveaus van de categoriegroepering beschrijven het pad van dat blad naar zijn bovenliggende niveaus. Voor de eerste rij is het pad `Consumer > Computers > Laptops`.

De indexen die door [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chartdatapoint/#getDataPointLevels) worden geretourneerd, lopen van het blad naar boven:

| `getDataPointLevels()` index | Logisch niveau | Treemap‑representatie | Sunburst‑representatie |
| ---: | --- | --- | --- |
| `0` | Blad | Waarde‑rechthoek | Segment op buitenste ring |
| `1` | Stam | Ouder‑rechthoek of -header | Segment op middelste ring |
| `2` | Tak | Rechthoek of -header op hoogste niveau | Segment op binnenste ring |

Deze volgorde is voor beide grafiektype's gelijk, ook al verschillen de visuele lay‑outs. Een bovenliggend segment wordt gedeeld door meerdere bladeren. Om het op te maken, gebruik je het overeenkomstige niveau van het eerste gegevenspunt in die groep. Bijvoorbeeld, de `Consumer`‑tak begint met het `Laptops`‑punt, terwijl de `Software`‑stam begint met het `Licenses`‑punt. Verwijzingen naar die punten bijhouden is duidelijker en veiliger dan onverklaarde uitdrukkingen zoals `dataPoints.get_Item(0)` of `dataPoints.get_Item(6)`.

## **Maak en pas beide grafiektype's aan**

Het volgende volledige voorbeeld maakt een Treemap op de eerste dia en een Sunburst op de tweede dia. Het bouwt de hiërarchie, toont de waarde voor `Tablets`, past vaste kleuren toe op geselecteerde niveaus, formatteert een tak‑label en slaat de presentatie op.

```javascript
const presentation = new aspose.slides.Presentation();
try {
    const worksheetIndex = 0;
    const leafLevelIndex = 0;
    const stemLevelIndex = 1;
    const branchLevelIndex = 2;

    const branchNames = [
        "Consumer", "Consumer", "Consumer", "Consumer",
        "Business", "Business", "Business", "Business"
    ];
    const stemNames = [
        "Computers", "Computers", "Mobile", "Mobile",
        "Services", "Services", "Software", "Software"
    ];
    const leafNames = [
        "Laptops", "Desktops", "Phones", "Tablets",
        "Consulting", "Support", "Licenses", "Subscriptions"
    ];
    const revenues = [12, 8, 15, 6, 10, 7, 11, 14];
    const dataPointCount = leafNames.length;

    const chartTypes = [
        aspose.slides.ChartType.Treemap,
        aspose.slides.ChartType.Sunburst
    ];
    const chartCount = chartTypes.length;
    const layoutSlide = presentation.getLayoutSlides().get_Item(0);

    for (let chartIndex = 0; chartIndex < chartCount; chartIndex++) {
        const chartType = chartTypes[chartIndex];
        let slide;

        if (chartIndex === 0) {
            slide = presentation.getSlides().get_Item(0);
        } else {
            slide = presentation.getSlides().addEmptySlide(layoutSlide);
        }

        const chart = slide.getShapes().addChart(chartType, 40, 40, 640, 440);
        chart.setTitle(false);
        chart.setLegend(false);

        const chartData = chart.getChartData();
        chartData.getCategories().clear();
        chartData.getSeries().clear();

        const workbook = chartData.getChartDataWorkbook();
        workbook.clear(worksheetIndex);

        // Voeg de bladcategorieën toe. Een groepeeritem wordt alleen ingesteld wanneer een nieuwe groep begint;
        // de volgende categorieën blijven in die groep totdat een ander item wordt ingesteld.
        for (let dataIndex = 0; dataIndex < dataPointCount; dataIndex++) {
            const rowIndex = dataIndex + 1;
            const leafName = leafNames[dataIndex];
            const categoryCell = workbook.getCell(worksheetIndex, rowIndex, 2, leafName);
            const category = chartData.getCategories().add(categoryCell);

            const stemName = stemNames[dataIndex];
            const startsNewStem = dataIndex === 0 || stemName !== stemNames[dataIndex - 1];
            if (startsNewStem) {
                category.getGroupingLevels().setGroupingItem(stemLevelIndex, stemName);
            }

            const branchName = branchNames[dataIndex];
            const startsNewBranch = dataIndex === 0 || branchName !== branchNames[dataIndex - 1];
            if (startsNewBranch) {
                category.getGroupingLevels().setGroupingItem(branchLevelIndex, branchName);
            }
        }

        const seriesNameCell = workbook.getCell(worksheetIndex, 0, 3, "Revenue");
        const series = chartData.getSeries().add(seriesNameCell, chartType);
        series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(true);

        let laptopsDataPoint = null;
        let tabletsDataPoint = null;
        let licensesDataPoint = null;

        for (let dataIndex = 0; dataIndex < dataPointCount; dataIndex++) {
            const rowIndex = dataIndex + 1;
            const leafName = leafNames[dataIndex];
            const revenue = revenues[dataIndex];
            const valueCell = workbook.getCell(worksheetIndex, rowIndex, 3, revenue);
            let dataPoint;

            if (chartType === aspose.slides.ChartType.Treemap) {
                dataPoint = series.getDataPoints().addDataPointForTreemapSeries(valueCell);
            } else {
                dataPoint = series.getDataPoints().addDataPointForSunburstSeries(valueCell);
            }

            if (leafName === "Laptops") {
                laptopsDataPoint = dataPoint;
            } else if (leafName === "Tablets") {
                tabletsDataPoint = dataPoint;
            } else if (leafName === "Licenses") {
                licensesDataPoint = dataPoint;
            }
        }

        // Toon de categorie en waarde op het blad Tablets.
        const tabletsLeafLevel = tabletsDataPoint.getDataPointLevels().get_Item(leafLevelIndex);
        const tabletsLabelFormat = tabletsLeafLevel.getLabel().getDataLabelFormat();
        tabletsLabelFormat.setShowCategoryName(true);
        tabletsLabelFormat.setShowValue(true);
        tabletsLabelFormat.setSeparator("\n");
        tabletsLabelFormat.setNumberFormat("$0");

        // Formatteer de Consumer‑tak via het eerste blad in die tak.
        const consumerBranchLevel = laptopsDataPoint.getDataPointLevels().get_Item(branchLevelIndex);
        const consumerBranchFill = consumerBranchLevel.getFormat().getFill();
        const consumerBranchColor = java.newInstanceSync("java.awt.Color", 31, 78, 121);
        consumerBranchFill.setFillType(java.newByte(aspose.slides.FillType.Solid));
        consumerBranchFill.getSolidFillColor().setColor(consumerBranchColor);

        const consumerLabelFormat = consumerBranchLevel.getLabel().getDataLabelFormat();
        consumerLabelFormat.setShowCategoryName(true);
        consumerLabelFormat.setShowSeriesName(false);
        const consumerLabelTextFill = consumerLabelFormat.getTextFormat().getPortionFormat().getFillFormat();
        const whiteColor = java.getStaticFieldValue("java.awt.Color", "WHITE");
        consumerLabelTextFill.setFillType(java.newByte(aspose.slides.FillType.Solid));
        consumerLabelTextFill.getSolidFillColor().setColor(whiteColor);

        // Formatteer de Software‑stam via het eerste blad in die stam.
        const softwareStemLevel = licensesDataPoint.getDataPointLevels().get_Item(stemLevelIndex);
        const softwareStemFill = softwareStemLevel.getFormat().getFill();
        const softwareStemColor = java.newInstanceSync("java.awt.Color", 112, 173, 71);
        softwareStemFill.setFillType(java.newByte(aspose.slides.FillType.Solid));
        softwareStemFill.getSolidFillColor().setColor(softwareStemColor);

        // ParentLabelLayout beïnvloedt de bovenliggende labels van Treemap; Sunburst gebruikt ringsegmenten.
        if (chartType === aspose.slides.ChartType.Treemap) {
            series.setParentLabelLayout(aspose.slides.ParentLabelLayoutType.Overlapping);
        }
    }

    presentation.save("hierarchical-charts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

De categoriecellen en waarde‑cellen gebruiken dezelfde werkbladrij, zodat hun collectieposities op één lijn blijven. Werk je met een bestaande grafiek in plaats van er een nieuwe te maken, inspecteer dan eerst de categorierijen en sla benoemde verwijzingen op naar de gegevenspunten en niveaus die je wilt opmaken.

## **Gedrag en praktische overwegingen**

### **Verschillen tussen Treemap en Sunburst**

- Een Treemap gebruikt oppervlakte om de waarde weer te geven en geneste rechthoeken om de hiërarchie weer te geven. De [ChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chartseries/#setParentLabelLayout)‑methode bepaalt hoe bovenliggende labels verschijnen in dit grafiektype.
- Een Sunburst gebruikt hoek om de waarde weer te geven en ringdiepte om de hiërarchie weer te geven. [ChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chartseries/#setParentLabelLayout) heeft geen invloed op de ringlabels.
- Beide grafiektype's gebruiken dezelfde categoriegroeperingsniveaus en dezelfde blad‑naar‑bovenliggende volgorde die door [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chartdatapoint/#getDataPointLevels) wordt geretourneerd, zodat de code voor het bouwen van data en het opmaken van niveaus gedeeld kan worden.
- Bovenliggende waarden worden berekend uit hun afstammende bladeren. Voeg geen aparte numerieke punten toe voor takken of stammen.

### **Sorteren en segmentvolgorde**

De lay‑outengine van de grafiek bepaalt de uiteindelijke plaatsing van rechthoeken en ringsegmenten. Groepeer verwante categorie­rijen voordat je ze toevoegt, maar vertrouw niet op een specifieke rechthoekpositie of start‑hoek. Als volgorde betekenis heeft, neem die dan op in de labels of gebruik een grafiektype met een expliciete categorische as.

### **Thema en vaste kleuren**

Niet‑opgemaakte grafiekniveaus erven kleuren uit het presentatiethema. Het voorbeeld gebruikt expliciete RGB‑vullingen voor voorspelbare uitvoer. Als de grafiek thema‑veranderingen moet volgen, gebruik dan schemavarianten in plaats van vaste RGB‑waarden en vermijd het overschrijven van elk niveau. Controleer ook het label‑contrast na het wijzigen van een tak‑ of stam‑vulling.

### **Labels en beschikbare ruimte**

PowerPoint kan labels verbergen of afkappen wanneer een segment te klein is. Het vergroten van de grafiek, verkorten van categorienamen of minder labelvelden tonen levert meestal een duidelijker resultaat op. Een label kan de categorienaam, serienaam en waarde combineren via [DataLabelFormat](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/datalabelformat/), maar het inschakelen van elke veld maakt hiërarchische grafieken vaak moeilijk leesbaar.

### **Export en weergave**

Opslaan als PPTX houdt de grafiek bewerkbaar. Wanneer Aspose.Slides de presentatie rendert naar PDF of een afbeelding, worden de ondersteunde vullingen en labelinstellingen met de grafiek meegeleverd. Font‑substitutie en kleine verschillen in beschikbare lay‑outruimte kunnen regelafbreking of label‑zichtbaarheid beïnvloeden, dus installeer de vereiste lettertypen en controleer belangrijke exportdoelen.

## **FAQ**

**Waarom beïnvloedt het wijzigen van een bovenliggend niveau meerdere bladeren?**

Een tak of stam is een gedeeld visueel segment. De [ChartDataPointLevel](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chartdatapointlevel/) kan via een afgeleid blad worden bereikt, maar de opmaak behoort tot het gedeelde bovenliggende segment, niet alleen tot dat blad.

**Waarom ontbreekt een datalabel?**

Schakel eerst de benodigde velden in op het label‑object [DataLabelFormat](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/datalabelformat/). Controleer daarna of het segment voldoende ruimte heeft. Treemap‑bovenliggende‑label‑lay‑out, grafiekafmetingen, label‑lengte, lettergrootte en het aantal ingeschakelde velden bepalen allemaal of een label kan worden getoond.

**Kan ik de exacte volgorde of coördinaten van segmenten instellen?**

Je kunt de volgorde van de bronrijen beheren en elke groep aaneengesloten houden, maar je kunt geen exacte Treemap‑rechthoeken of Sunburst‑hoeken toewijzen. De lay‑outengine berekent ze op basis van de hiërarchie, waarden en beschikbare ruimte.

**Waarom veranderen kleuren na een thema‑wijziging van de presentatie?**

Thema‑gebaseerde vullingen volgen het presentatiethema. Gebruik expliciete RGB‑kleuren voor niveaus die constant moeten blijven, of behoud schemavarianten wanneer je wilt dat ze zich aanpassen aan een nieuw thema.

**Wordt aangepaste opmaak bewaard bij export naar PDF en afbeeldingen?**

Ja, ondersteunde grafiekvullingen en labelinstellingen worden meegenomen tijdens het renderen. Zorg voor de benodigde lettertypen en test de uiteindelijke exportgrootte, want label‑passing is lay‑out‑afhankelijk.

## **Zie ook**

- [Treemap‑grafieken maken](/slides/nl/nodejs-java/create-chart/#creating-tree-map-charts)
- [Sunburst‑grafieken maken](/slides/nl/nodejs-java/create-chart/#creating-sunburst-charts)
- [Presentatie‑grafieken exporteren](/slides/nl/nodejs-java/export-chart/)
- [Presentatiethema's beheren](/slides/nl/nodejs-java/presentation-theme/)
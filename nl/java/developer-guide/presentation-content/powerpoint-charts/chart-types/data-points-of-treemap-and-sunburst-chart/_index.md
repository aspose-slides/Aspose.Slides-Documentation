---
title: Pas gegevenspunten aan in Treemap‑ en Sunburst‑grafieken in Java
linktitle: Gegevenspunten in Treemap‑ en Sunburst‑grafieken
type: docs
url: /nl/java/data-points-of-treemap-and-sunburst-chart/
weight: 40
keywords:
- treemap-grafiek
- sunburst-grafiek
- hiërarchische grafiek
- gegevenspunt
- gegevenslabel
- takkleur
- PowerPoint
- presentatie
- Java
- Aspose.Slides
description: "Leer hoe u hiërarchische gegevens maakt en niveaus, labels en kleuren aanpast in Treemap‑ en Sunburst‑grafieken met Aspose.Slides voor Java."
---
## **Overzicht**

Treemap‑ en Sunburst‑grafieken tonen dezelfde soort hiërarchische gegevens, maar ze gebruiken verschillende lay‑outs. Een Treemap tekent de hiërarchie als geneste rechthoeken waarvan de oppervlakten de bladwaarden vertegenwoordigen. Een Sunburst tekent deze als concentrische ringen: top‑niveau groepen bevinden zich dicht bij het centrum, en bladcategorieën staan op de buitenste ring.

In Aspose.Slides for Java is elke numerieke waarde een [IChartDataPoint](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ichartdatapoint/). De [IChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ichartdatapoint/#getDataPointLevels--)‑methode biedt toegang tot het blad en zijn bovenliggende groepen. Dit artikel legt die mapping uit en laat zien hoe beide grafiektypeën te maken en op te maken vanuit dezelfde voorbeeldgegevens.

![A Treemap chart with Consumer and Business branches](treemap-hierarchy.png)

![A Sunburst chart with the same Consumer and Business hierarchy](sunburst-hierarchy.png)

## **Begrijp categorieën, datapunten en niveaus**

Het onderstaande voorbeeld bevat drie categorieniveaus en één numerieke reeks:

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

Elke rij creëert één bladcategorie en één datapunt. De categorie‑groeperingsniveaus beschrijven het pad van dat blad naar zijn ouders. Voor de eerste rij is het pad `Consumer > Computers > Laptops`.

De indexen die door [IChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ichartdatapoint/#getDataPointLevels--) worden geretourneerd, lopen van het blad omhoog:

| `getDataPointLevels()` index | Logisch niveau | Treemap‑weergave | Sunburst‑weergave |
| ---: | --- | --- | --- |
| `0` | Blad | Waarde‑rechthoek | Buiten-ring segment |
| `1` | Stam | Ouder‑rechthoek of -kop | Midden‑ring segment |
| `2` | Tak | Top‑niveau rechthoek of -kop | Binnen‑ring segment |

Deze volgorde is hetzelfde voor beide grafiektypeën, ook al verschillen hun visuele lay‑outs. Een oudersegment wordt gedeeld door meerdere bladeren. Om het op te maken, gebruik je het overeenkomstige niveau van het eerste datapunt in die groep. Bijvoorbeeld, de tak `Consumer` begint met het punt `Laptops`, terwijl de stam `Software` begint met het punt `Licenses`. Referenties naar die punten bijhouden is duidelijker en veiliger dan onduidelijke uitdrukkingen zoals `dataPoints.get_Item(0)` of `dataPoints.get_Item(6)`.

## **Maak en pas beide grafiektypeën aan**

Het volgende volledige voorbeeld maakt een Treemap op de eerste dia en een Sunburst op de tweede dia. Het bouwt de hiërarchie, toont de waarde voor `Tablets`, past vaste kleuren toe op geselecteerde niveaus, formatteert een tak‑label en slaat de presentatie op.

```java
Presentation presentation = new Presentation();
try {
    final int worksheetIndex = 0;
    final int leafLevelIndex = 0;
    final int stemLevelIndex = 1;
    final int branchLevelIndex = 2;

    String[] branchNames = {
        "Consumer", "Consumer", "Consumer", "Consumer",
        "Business", "Business", "Business", "Business"
    };
    String[] stemNames = {
        "Computers", "Computers", "Mobile", "Mobile",
        "Services", "Services", "Software", "Software"
    };
    String[] leafNames = {
        "Laptops", "Desktops", "Phones", "Tablets",
        "Consulting", "Support", "Licenses", "Subscriptions"
    };
    double[] revenues = {12, 8, 15, 6, 10, 7, 11, 14};
    int dataPointCount = leafNames.length;

    int[] chartTypes = {ChartType.Treemap, ChartType.Sunburst};
    int chartCount = chartTypes.length;
    ILayoutSlide layoutSlide = presentation.getLayoutSlides().get_Item(0);

    for (int chartIndex = 0; chartIndex < chartCount; chartIndex++) {
        int chartType = chartTypes[chartIndex];
        ISlide slide;

        if (chartIndex == 0) {
            slide = presentation.getSlides().get_Item(0);
        } else {
            slide = presentation.getSlides().addEmptySlide(layoutSlide);
        }

        IChart chart = slide.getShapes().addChart(chartType, 40, 40, 640, 440);
        chart.setTitle(false);
        chart.setLegend(false);

        IChartData chartData = chart.getChartData();
        chartData.getCategories().clear();
        chartData.getSeries().clear();

        IChartDataWorkbook workbook = chartData.getChartDataWorkbook();
        workbook.clear(worksheetIndex);

        // Voeg de bladcategorieën toe. Een groeperingsitem wordt alleen ingesteld wanneer een nieuwe groep begint;
        // de daaropvolgende categorieën blijven in die groep totdat een ander item wordt ingesteld.
        for (int dataIndex = 0; dataIndex < dataPointCount; dataIndex++) {
            int rowIndex = dataIndex + 1;
            String leafName = leafNames[dataIndex];
            IChartDataCell categoryCell = workbook.getCell(worksheetIndex, rowIndex, 2, leafName);
            IChartCategory category = chartData.getCategories().add(categoryCell);

            String stemName = stemNames[dataIndex];
            boolean startsNewStem = dataIndex == 0;
            if (dataIndex > 0) {
                String previousStemName = stemNames[dataIndex - 1];
                startsNewStem = !stemName.equals(previousStemName);
            }
            if (startsNewStem) {
                category.getGroupingLevels().setGroupingItem(stemLevelIndex, stemName);
            }

            String branchName = branchNames[dataIndex];
            boolean startsNewBranch = dataIndex == 0;
            if (dataIndex > 0) {
                String previousBranchName = branchNames[dataIndex - 1];
                startsNewBranch = !branchName.equals(previousBranchName);
            }
            if (startsNewBranch) {
                category.getGroupingLevels().setGroupingItem(branchLevelIndex, branchName);
            }
        }

        IChartDataCell seriesNameCell = workbook.getCell(worksheetIndex, 0, 3, "Revenue");
        IChartSeries series = chartData.getSeries().add(seriesNameCell, chartType);
        series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(true);

        IChartDataPoint laptopsDataPoint = null;
        IChartDataPoint tabletsDataPoint = null;
        IChartDataPoint licensesDataPoint = null;

        for (int dataIndex = 0; dataIndex < dataPointCount; dataIndex++) {
            int rowIndex = dataIndex + 1;
            String leafName = leafNames[dataIndex];
            double revenue = revenues[dataIndex];
            IChartDataCell valueCell = workbook.getCell(worksheetIndex, rowIndex, 3, revenue);
            IChartDataPoint dataPoint;

            if (chartType == ChartType.Treemap) {
                dataPoint = series.getDataPoints().addDataPointForTreemapSeries(valueCell);
            } else {
                dataPoint = series.getDataPoints().addDataPointForSunburstSeries(valueCell);
            }

            if ("Laptops".equals(leafName)) {
                laptopsDataPoint = dataPoint;
            } else if ("Tablets".equals(leafName)) {
                tabletsDataPoint = dataPoint;
            } else if ("Licenses".equals(leafName)) {
                licensesDataPoint = dataPoint;
            }
        }

        // Toon de categorie en waarde op het blad Tablets.
        IChartDataPointLevel tabletsLeafLevel = tabletsDataPoint.getDataPointLevels().get_Item(leafLevelIndex);
        IDataLabelFormat tabletsLabelFormat = tabletsLeafLevel.getLabel().getDataLabelFormat();
        tabletsLabelFormat.setShowCategoryName(true);
        tabletsLabelFormat.setShowValue(true);
        tabletsLabelFormat.setSeparator("\n");
        tabletsLabelFormat.setNumberFormat("$0");

        // Formatteer de Consumer tak via het eerste blad in die tak.
        IChartDataPointLevel consumerBranchLevel = laptopsDataPoint.getDataPointLevels().get_Item(branchLevelIndex);
        IFillFormat consumerBranchFill = consumerBranchLevel.getFormat().getFill();
        Color consumerBranchColor = new Color(31, 78, 121);
        consumerBranchFill.setFillType(FillType.Solid);
        consumerBranchFill.getSolidFillColor().setColor(consumerBranchColor);

        IDataLabelFormat consumerLabelFormat = consumerBranchLevel.getLabel().getDataLabelFormat();
        consumerLabelFormat.setShowCategoryName(true);
        consumerLabelFormat.setShowSeriesName(false);
        IFillFormat consumerLabelTextFill = consumerLabelFormat.getTextFormat().getPortionFormat().getFillFormat();
        consumerLabelTextFill.setFillType(FillType.Solid);
        consumerLabelTextFill.getSolidFillColor().setColor(Color.WHITE);

        // Formatteer de Software stam via het eerste blad in die stam.
        IChartDataPointLevel softwareStemLevel = licensesDataPoint.getDataPointLevels().get_Item(stemLevelIndex);
        IFillFormat softwareStemFill = softwareStemLevel.getFormat().getFill();
        Color softwareStemColor = new Color(112, 173, 71);
        softwareStemFill.setFillType(FillType.Solid);
        softwareStemFill.getSolidFillColor().setColor(softwareStemColor);

        // ParentLabelLayout beïnvloedt Treemap‑bovenliggende labels; Sunburst gebruikt ringsegmenten.
        if (chartType == ChartType.Treemap) {
            series.setParentLabelLayout(ParentLabelLayoutType.Overlapping);
        }
    }

    presentation.save("hierarchical-charts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

De categoriecellen en waardecellen gebruiken dezelfde werkbladrij, zodat hun verzamelingsposities uitgelijnd blijven. Wanneer je met een bestaande grafiek werkt in plaats van er één te maken, inspecteer dan eerst de categorierijen en sla benoemde referenties op naar de datapunten en niveaus die je wilt opmaken.

## **Gedrag en praktische overwegingen**

### **Verschillen tussen Treemap en Sunburst**

- Een Treemap gebruikt oppervlakte om waarde te communiceren en geneste rechthoeken om hiërarchie te communiceren. De [IChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ichartseries/#setParentLabelLayout-int-)‑methode bepaalt hoe bovenliggende labels verschijnen in dit grafiektype.
- Een Sunburst gebruikt hoek om waarde te communiceren en ringdiepte om hiërarchie te communiceren. [IChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ichartseries/#setParentLabelLayout-int-) beheert de ringlabels niet.
- Beide grafiektypeën gebruiken dezelfde categorie‑groeperingsniveaus en dezelfde blad‑naar‑ouder‑volgorde die door [IChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ichartdatapoint/#getDataPointLevels--) wordt geretourneerd, zodat de code voor het bouwen van data en voor het opmaken van niveaus kan worden gedeeld.
- Bovenliggende waarden worden berekend uit hun afstammende bladeren. Voeg geen aparte numerieke punten toe voor takken of stammen.

### **Sorteren en segmentvolgorde**

De grafiek‑layoutengine bepaalt de uiteindelijke plaatsing van rechthoeken en ringsegmenten. Plaats gerelateerde categorierijen samen voordat je ze toevoegt, maar vertrouw niet op een specifieke rechthoekpositie of starthoek. Als de volgorde betekenis heeft, neem deze dan op in de labels of gebruik een grafiektype met een expliciete categorie‑as.

### **Thema en vaste kleuren**

Niet‑opgemaakte grafiekniveaus erven kleuren uit het presentatiethema. Het voorbeeld gebruikt expliciete RGB‑vullingen voor voorspelbare uitvoer. Als de grafiek thema‑wijzigingen moet volgen, gebruik dan schema‑kleuren in plaats van vaste RGB‑waarden en vermijd het overschrijven van elk niveau. Controleer ook het labelcontrast nadat je een tak‑ of stam‑vulling hebt aangepast.

### **Labels en beschikbare ruimte**

PowerPoint kan labels verbergen of inkorten wanneer een segment te klein is. Het vergroten van de grafiek, verkorten van categorienamen of minder labelvelden tonen levert doorgaans een duidelijker resultaat op. Een label kan de categorienaam, serienaam en waarde combineren via [IDataLabelFormat](https://reference.aspose.com/slides/nl/java/com.aspose.slides/idatalabelformat/), maar het inschakelen van elk veld maakt hiërarchische grafieken vaak moeilijk leesbaar.

### **Export en weergave**

Opslaan als PPTX houdt de grafiek bewerkbaar. Wanneer Aspose.Slides de presentatie rendert naar PDF of een afbeelding, worden de ondersteunde vullingen en labelinstellingen meegenomen in de grafiek. Lettertype‑substitutie en kleine verschillen in beschikbare layout‑ruimte kunnen regelafbreking of labelzichtbaarheid wijzigen, dus installeer de benodigde lettertypen en controleer belangrijke exportdoelen.

## **FAQ**

**Waarom beïnvloedt het wijzigen van een bovenliggend niveau meerdere bladeren?**

Een tak of stam is een gedeeld visueel segment. Het [IChartDataPointLevel](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ichartdatapointlevel/) kan worden bereikt via een afstammend blad, maar de opmaak behoort toe aan het gedeelde bovenliggende segment, niet alleen aan dat blad.

**Waarom ontbreekt een datalabel?**

Schakel eerst de vereiste velden in op het label‑object [IDataLabelFormat](https://reference.aspose.com/slides/nl/java/com.aspose.slides/idatalabelformat/). Controleer vervolgens of het segment voldoende ruimte heeft. Treemap‑bovenliggende‑label‑layout, grafiekafmetingen, label‑lengte, lettergrootte en het aantal ingeschakelde velden bepalen allemaal of een label kan worden weergegeven.

**Kan ik de exacte volgorde of coördinaten van segmenten instellen?**

Je kunt de bron‑rijvolgorde regelen en elke groep aaneengesloten houden, maar je kunt geen exacte Treemap‑rechthoeken of Sunburst‑hoeken toewijzen. De layoutengine berekent ze op basis van de hiërarchie, waarden en beschikbare ruimte.

**Waarom veranderen kleuren wanneer het presentatiethema wijzigt?**

Thema‑gebaseerde vullingen zijn bedoeld om de presentatie‑palet te volgen. Pas expliciete RGB‑kleuren toe op de niveaus die vast moeten blijven, of behoud schema‑kleuren als je je wilt aanpassen aan een nieuw thema.

**Wordt aangepaste opmaak behouden bij PDF‑ en afbeeldingsexport?**

Ja, ondersteunde grafiek‑vullingen en labelinstellingen worden meegenomen tijdens het renderen. Zorg voor de vereiste lettertypen en test de uiteindelijke exportgrootte, want label‑passing is afhankelijk van de layout.

## **Zie ook**

- [Create Treemap charts](/slides/nl/java/create-chart/#create-tree-map-charts)
- [Create Sunburst charts](/slides/nl/java/create-chart/#create-sunburst-charts)
- [Export presentation charts](/slides/nl/java/export-chart/)
- [Manage presentation themes](/slides/nl/java/presentation-theme/)
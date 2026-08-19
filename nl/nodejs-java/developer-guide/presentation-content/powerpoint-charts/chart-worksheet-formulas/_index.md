---
title: Diagramwerkbladformules toepassen in presentaties met JavaScript
linktitle: Werkbladformules
type: docs
weight: 70
url: /nl/nodejs-java/chart-worksheet-formulas/
keywords:
- diagram spreadsheet
- diagramwerkblad
- diagramformule
- werkbladformule
- spreadsheetformule
- diagramdataboek
- formuleberekening
- logische constante
- numerieke constante
- stringconstante
- foutconstante
- rekenkundige operator
- vergelijkingsoperator
- A1-stijl
- R1C1-stijl
- voorgedefinieerde functie
- PowerPoint
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Excel‑achtige formules toepassen in Aspose.Slides voor Node.js via Java‑diagramwerkbladen, waarden opnieuw berekenen en de resultaten gebruiken in PowerPoint‑diagrammen."
---
## **Overzicht**

PowerPoint‑diagrammen slaan hun brongegevens meestal op in een ingesloten werkblad. In Aspose.Slides voor Node.js via Java kunt u dat werkblad benaderen via het chart‑data‑workbook, invoerwaarden schrijven, formules toewijzen aan cellen, ondersteunde formules berekenen en de berekende cellen gebruiken als diagramgegevens.

Dit artikel legt de volledige formule‑workflow uit: een diagram maken, het werkblad vullen, A1‑stijl‑ of R1C1‑stijl‑formules toewijzen, ze opnieuw berekenen, de berekende waarden lezen, die cellen aan een diagramserie koppelen en de presentatie opslaan. Het beschrijft ook de ondersteunde formule‑syntaxis, de ingebouwde functie‑subset, cache‑waarden, niet‑ondersteunde formules en spreadsheet‑specifieke fouten.

## **Diagramwerkbladen en Formules**

Een diagramwerkblad bevat de categorieën, serienaam­en en waarden die door een diagram worden gebruikt. In PowerPoint kunt u het werkblad inspecteren door de diagram‑data‑editor te openen:

![PowerPoint‑diagram met geopend ingesloten werkblad, toont categorie‑ en seriedata](chart-worksheet-formulas_1.png)

In Aspose.Slides wordt het werkblad blootgesteld via de [ChartDataWorkbook](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chartdataworkbook/)‑klasse. Gebruik [ChartDataCell.setFormula](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chartdatacell/#setFormula-java.lang.String-) voor A1‑stijl‑formules en [ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chartdatacell/#setR1C1Formula-java.lang.String-) voor R1C1‑stijl‑formules. Na het wijzigen van invoercellen of formules, roep [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--) aan om ondersteunde formules opnieuw te berekenen en de bijbehorende celwaarden bij te werken.

Een berekende cel geeft nog steeds haar resultaat bloot via [ChartDataCell.getValue](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chartdatacell/#getValue--). Dit is belangrijk wanneer u een formuleresultaat in code moet inspecteren of de cel als diagramdatumpunt wilt gebruiken.

## **Een diagram maken en werkblad‑formules berekenen**

Het volgende voorbeeld demonstreert een end‑to‑end workflow. Het maakt een gegroepeerd kolomdiagram, wist de voorbeeldgegevens, schrijft kwartaalomzet‑ en kostenwaarden, berekent winst met formules, leest de resultaten, gebruikt de berekende cellen als diagramwaarden en slaat de presentatie op.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 350);
    const workbook = chart.getChartData().getChartDataWorkbook();
    const worksheetIndex = 0;

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    workbook.clear(worksheetIndex);

    const category1 = workbook.getCell(worksheetIndex, "A2", "Q1");
    const category2 = workbook.getCell(worksheetIndex, "A3", "Q2");
    const category3 = workbook.getCell(worksheetIndex, "A4", "Q3");

    workbook.getCell(worksheetIndex, "B1", "Revenue");
    workbook.getCell(worksheetIndex, "C1", "Expenses");
    workbook.getCell(worksheetIndex, "D1", "Profit");

    workbook.getCell(worksheetIndex, "B2").setValue(120.0);
    workbook.getCell(worksheetIndex, "C2").setValue(80.0);
    workbook.getCell(worksheetIndex, "B3").setValue(150.0);
    workbook.getCell(worksheetIndex, "C3").setValue(95.0);
    workbook.getCell(worksheetIndex, "B4").setValue(135.0);
    workbook.getCell(worksheetIndex, "C4").setValue(110.0);

    const profit1 = workbook.getCell(worksheetIndex, "D2");
    const profit2 = workbook.getCell(worksheetIndex, "D3");
    const profit3 = workbook.getCell(worksheetIndex, "D4");

    profit1.setFormula("B2-C2");
    profit2.setFormula("B3-C3");
    profit3.setFormula("B4-C4");

    workbook.calculateFormulas();

    const q1Profit = profit1.getValue(); // 40
    const q2Profit = profit2.getValue(); // 55
    const q3Profit = profit3.getValue(); // 25

    console.log("Q1 profit: " + q1Profit);
    console.log("Q2 profit: " + q2Profit);
    console.log("Q3 profit: " + q3Profit);

    chart.getChartData().getCategories().add(category1);
    chart.getChartData().getCategories().add(category2);
    chart.getChartData().getCategories().add(category3);

    const profitSeries = chart.getChartData().getSeries().add(workbook.getCell(worksheetIndex, "D1"), chart.getType());
    profitSeries.getDataPoints().addDataPointForBarSeries(profit1);
    profitSeries.getDataPoints().addDataPointForBarSeries(profit2);
    profitSeries.getDataPoints().addDataPointForBarSeries(profit3);
    profitSeries.getLabels().getDefaultDataLabelFormat().setShowValue(true);

    presentation.save("chart-formulas.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

De diagramdatapunten verwijzen naar `D2:D4`, dus het diagram gebruikt de berekende winstwaarden. Er is geen aparte diagram‑verversingsaanroep in deze workflow: bereken eerst het werkboek opnieuw, gebruik of sla vervolgens de diagramgegevens op die naar de berekende cellen wijzen.

## **A1‑stijlformules gebruiken**

A1‑notatie identificeert kolommen met letters en rijen met cijfers. Wijs A1‑stijl‑expressies toe via [ChartDataCell.setFormula](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chartdatacell/#setFormula-java.lang.String-).

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 500, 300);
    const workbook = chart.getChartData().getChartDataWorkbook();

    workbook.getCell(0, "C3").setValue(10);
    workbook.getCell(0, "F2").setValue(2);
    workbook.getCell(0, "G2").setValue(3);
    workbook.getCell(0, "H2").setValue(4);

    const cell = workbook.getCell(0, "A2");
    cell.setFormula("C3+SUM(F2:H2)");

    workbook.calculateFormulas();

    const value = cell.getValue(); // 19
} finally {
    presentation.dispose();
}
```

Veelvoorkomende A1‑referentievormen zijn:

| Referentie | Relatief | Absoluut | Gemengd |
|---|---|---|---|
| Cel | `A2` | `$A$2` | `A$2`, `$A2` |
| Rij | `2:2` | `$2:$2` | — |
| Kolom | `A:A` | `$A:$A` | — |
| Bereik | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

Relatieve verwijzingen kunnen veranderen wanneer een formule wordt verplaatst of gekopieerd door een spreadsheet‑toepassing. Absolute verwijzingen houden beide coördinaten vast, terwijl gemengde verwijzingen alleen een rij of een kolom fixeren.

## **R1C1‑stijlformules gebruiken**

R1C1‑notatie identificeert zowel rijen als kolommen numeriek. Relatieve verwijzingen gebruiken offsets in vierkante haakjes. Wijs deze syntaxis toe via [ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chartdatacell/#setR1C1Formula-java.lang.String-).

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 500, 300);
    const workbook = chart.getChartData().getChartDataWorkbook();

    workbook.getCell(0, "B2").setValue(12);
    workbook.getCell(0, "C2").setValue(5);

    const cell = workbook.getCell(0, "D2");
    cell.setR1C1Formula("RC[-2]-RC[-1]");

    workbook.calculateFormulas();

    const value = cell.getValue(); // 7
} finally {
    presentation.dispose();
}
```

Veelvoorkomende R1C1‑referentievormen zijn:

| Referentie | Relatief | Absoluut | Gemengd |
|---|---|---|---|
| Cel | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| Rij | `R[2]` | `R2` | — |
| Kolom | `C[3]` | `C3` | — |
| Bereik | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

Bijvoorbeeld, in cel `D2` betekent `RC[-2]` de cel in dezelfde rij twee kolommen naar links (`B2`).

## **Formule‑constanten en operatoren**

De ingebouwde formule‑evaluator ondersteunt logische waarden, numerieke literals, strings, spreadsheet‑foutwaarden, rekenkundige operatoren en vergelijkingsoperatoren.

### **Constanten en letterlijke waarden**

| Type | Voorbeelden | Opmerkingen |
|---|---|---|
| Logisch | `TRUE`, `FALSE` | Kan direct worden gebruikt in logische uitdrukkingen, zoals `A2=TRUE`. |
| Numeriek | `1`, `0.5`, `.3`, `1E-2` | Zowel gewone als wetenschappelijke notatie worden ondersteund. |
| Tekst | `"abc"`, `"2/3/2020 12:00"` | Tekst‑literals staan tussen dubbele aanhalingstekens binnen de formule. |
| Foutresultaat | `#DIV/0!`, `#N/A`, `#REF!` | Een geldige formule kan resulteren in een spreadsheet‑foutwaarde in plaats van een normaal resultaat. |

Dit voorbeeld gebruikt verschillende constanttypen:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 500, 300);
    const workbook = chart.getChartData().getChartDataWorkbook();

    workbook.getCell(0, "A2").setValue(false);
    workbook.getCell(0, "B2").setFormula("A2=TRUE");
    workbook.getCell(0, "C2").setFormula("1+0.5");
    workbook.getCell(0, "D2").setFormula(".3*1E-2");
    workbook.getCell(0, "E2").setFormula("\"abc\"");
    workbook.getCell(0, "F2").setFormula("2/0");

    workbook.calculateFormulas();

    const logicalValue = workbook.getCell(0, "B2").getValue(); // false
    const numericValue = workbook.getCell(0, "C2").getValue(); // 1.5
    const scientificValue = workbook.getCell(0, "D2").getValue(); // 0.003
    const stringValue = workbook.getCell(0, "E2").getValue(); // abc
    const errorValue = workbook.getCell(0, "F2").getValue(); // #DIV/0!
} finally {
    presentation.dispose();
}
```

### **Rekenkundige operatoren**

| Operator | Betekenis | Voorbeeld |
|---|---|---|
| `+` | Optelling of eenvoudig plus | `2+3` |
| `-` | Aftrekking of negatie | `2-3`, `-3` |
| `*` | Vermenigvuldiging | `2*3` |
| `/` | Deling | `2/3` |
| `%` | Percentage | `30%` |
| `^` | Exponent | `2^3` |

Gebruik haakjes om de evaluatievolgorde expliciet te maken, bijvoorbeeld `(A2+B2)*C2`.

### **Vergelijkingsoperatoren**

Vergelijkings­expressies retourneren logische waarden.

| Operator | Betekenis | Voorbeeld |
|---|---|---|
| `=` | Gelijk aan | `A2=3` |
| `<>` | Niet gelijk aan | `A2<>3` |
| `>` | Groter dan | `A2>3` |
| `>=` | Groter dan of gelijk aan | `A2>=3` |
| `<` | Kleiner dan | `A2<3` |
| `<=` | Kleiner dan of gelijk aan | `A2<=3` |

## **Ondersteunde vooraf gedefinieerde functies**

Aspose.Slides bevat een ingebouwde formule‑evaluator voor diagramwerkbladen, maar het is geen volledige Excel‑rekenmachine. De gedocumenteerde functie‑set is beperkt tot de onderstaande functies. Ga er niet van uit dat een willekeurige Excel‑functie opnieuw kan worden berekend door [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--).

| Functie | Doel of ondersteunde vorm | Voorbeeld |
|---|---|---|
| `ABS` | Absolute waarde | `ABS(A2)` |
| `AVERAGE` | Rekenkundig gemiddelde | `AVERAGE(B2:B5)` |
| `CEILING` | Afronden naar boven op een veelvoud | `CEILING(A2,5)` |
| `CHOOSE` | Een waarde selecteren op index | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | Tekstwaarden samenvoegen | `CONCAT(A2,B2)` |
| `CONCATENATE` | Tekstwaarden samenvoegen | `CONCATENATE(A2," ",B2)` |
| `DATE` | Een datumwaarde aanmaken met het 1900‑datumstelsel | `DATE(2026,8,19)` |
| `DAYS` | Het aantal dagen tussen data retourneren | `DAYS(B2,A2)` |
| `FIND` | Een tekstwaarde in een andere zoeken | `FIND("-",A2)` |
| `FINDB` | Byte‑georiënteerd zoeken | `FINDB("a",A2)` |
| `IF` | Voorwaardelijk resultaat | `IF(A2>0,A2,0)` |
| `INDEX` | Referentie‑vorm | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | Vector‑vorm | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | Vector‑vorm | `MATCH(A2,B2:B5,0)` |
| `MAX` | Maximale waarde | `MAX(B2:B5)` |
| `SUM` | Som van waarden | `SUM(B2:B5)` |
| `VLOOKUP` | Verticaal zoeken | `VLOOKUP(A2,B2:D10,3,FALSE)` |

De beperkingen in de tabel zijn significant: `INDEX` wordt gedocumenteerd in referentie‑vorm, terwijl `LOOKUP` en `MATCH` in hun vector‑vormen staan. `DATE` gebruikt het 1900‑datumstelsel. Functies die hier niet worden genoemd, moeten als niet‑ondersteund door de Aspose.Slides‑formule‑evaluator worden beschouwd, tenzij ze afzonderlijk worden gedocumenteerd.

## **Herberekening en cache‑waarden**

Spreadsheet‑bestanden bewaren doorgaans zowel een formule als de laatst berekende waarde. Aspose.Slides kan daarom een cache‑waarde lezen van [ChartDataCell.getValue](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chartdatacell/#getValue--) wanneer een presentatie wordt geladen en de betreffende diagramgegevens niet zijn gewijzigd.

Na het wijzigen van invoercellen of formules, vertrouw niet op een oude cache‑resultaat. Roep [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--) aan voordat u berekende waarden leest of diagramgegevens opslaat die ervan afhankelijk zijn.

Voor formules buiten de ondersteunde subset kan Aspose.Slides de formule niet parseren of de afhankelijkheden niet vaststellen. Als het werkboek is aangepast, kan de vorige cache‑waarde niet langer als betrouwbaar worden beschouwd. In dat geval kan het lezen van de waarde van een cel met niet‑ondersteunde data een [CellUnsupportedDataException](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/cellunsupporteddataexception/) veroorzaken.

Als uw diagram afhankelijk is van Excel‑functies die Aspose.Slides niet evalueert, bereken die formules met een spreadsheet‑engine die ze ondersteunt en schrijf de resulterende waarden terug naar het diagram‑werkboek. Vervang niet‑ondersteunde formules door geraden waarden.

## **Formule‑fouten afhandelen**

Er zijn twee verschillende soorten problemen te onderscheiden.

Een formule kan geldig zijn maar een spreadsheet‑foutwaarde opleveren, zoals `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!` of `#VALUE!`. In dat geval is het fout‑token een celresultaat en kan het worden geretourneerd via [ChartDataCell.getValue](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chartdatacell/#getValue--).

Een formule kan ook falen tijdens het parseren, bij een verwijzing, een afhankelijkheid of op het niveau van ondersteunde data. Aspose.Slides biedt spreadsheet‑specifieke uitzonderingen voor deze gevallen: [CellInvalidFormulaException](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/cellcircularreferenceexception/) en [CellUnsupportedDataException](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/cellunsupporteddataexception/).

Wanneer formules afkomstig zijn van sjablonen of gebruikersinvoer, vang dan fouten rond herberekening en waarde‑toegang. De foutdetails identificeren het onderliggende spreadsheet‑probleem:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 500, 300);
    const workbook = chart.getChartData().getChartDataWorkbook();
    const cell = workbook.getCell(0, "A2");
    cell.setFormula("SUM(B2:B5)");

    try {
        workbook.calculateFormulas();
        console.log(cell.getValue());
    } catch (error) {
        console.error("Formula processing error: " + error.message);
    }
} finally {
    presentation.dispose();
}
```

## **Praktische beperkingen**

De formule‑ondersteuning in diagramwerkbladen is bedoeld voor een gedefinieerde subset van spreadsheet‑berekeningen, niet voor volledige Excel‑compatibiliteit. Houd deze beperkingen in gedachten bij het ontwerpen van een rapportage‑workflow:

- Gebruik alleen de gedocumenteerde constanten, operatoren, verwijzingen en functies wanneer u wilt dat Aspose.Slides formules opnieuw berekent.
- Herbereken na het wijzigen van cellen waarvan de formule‑resultaten afhankelijk zijn.
- Beschouw cache‑waarden uit geladen presentaties als momentopnamen, niet als vervanging voor herberekening na bewerkingen.
- Test formules uit bestaande sjablonen voordat u vertrouwt op hun berekende waarden, vooral wanneer ze functies gebruiken die niet in de lijst staan.
- Voor formules die een volledige spreadsheet‑rekenmachine vereisen, bereken ze extern en update vervolgens het diagram‑werkboek met de verkregen waarden.

## **FAQ**

**Wat is het verschil tussen [ChartDataCell.setFormula](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chartdatacell/#setFormula-java.lang.String-) en [ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chartdatacell/#setR1C1Formula-java.lang.String-)?**

[ChartDataCell.setFormula](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chartdatacell/#setFormula-java.lang.String-) slaat een A1‑stijl‑expressie op, zoals `B2-C2`. [ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chartdatacell/#setR1C1Formula-java.lang.String-) slaat een R1C1‑stijl‑expressie op, zoals `RC[-2]-RC[-1]`. Gebruik de notatie die het beste past bij hoe u formules genereert of kopieert.

**Moet ik de cel zelf lezen of de waarde na berekening?**

[ChartDataWorkbook.getCell](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chartdataworkbook/#getCell-int-java.lang.String-) retourneert een [ChartDataCell](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chartdatacell/). Om het berekende resultaat te verkrijgen, roep de [ChartDataCell.getValue](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chartdatacell/#getValue--)‑methode van die cel aan na herberekening.

**Wanneer moet ik [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--) aanroepen?**

Roep [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--) aan nadat u invoerwaarden of formules hebt gewijzigd en voordat u afhankelijk bent van de berekende resultaten. Dit werkt de waarden van formules die de ingebouwde evaluator ondersteunt bij.

**Ondersteunt Aspose.Slides elke Excel‑functie?**

Nee. De ingebouwde evaluator ondersteunt een gedocumenteerde subset van functies. Functies buiten die subset mogen niet als correct herberekend worden beschouwd. Als volledige Excel‑formule‑compatibiliteit vereist is, voer de berekening dan uit met een geschikte spreadsheet‑engine en schrijf de eindwaarden naar het diagram‑werkboek.

**Wat gebeurt er als een geladen presentatie een niet‑ondersteunde formule bevat?**

Als de diagramgegevens niet zijn gewijzigd, kan het werkboek nog steeds een eerder berekende cache‑waarde bevatten. Nadat gerelateerde data is aangepast, is die cache‑waarde mogelijk niet meer geldig. Het benaderen van een cel waarvan de formule niet kan worden verwerkt kan een [CellUnsupportedDataException](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/cellunsupporteddataexception/) opleveren.

**Zijn formule‑foutwaarden hetzelfde als uitzonderingen?**

Nee. Een resultaat zoals `#DIV/0!` is een spreadsheet‑waarde die ontstaat uit een geldige berekening. Uitzonderingen zoals [CellInvalidFormulaException](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/cellinvalidformulaexception/) of [CellCircularReferenceException](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/cellcircularreferenceexception/) geven aan dat de formule niet normaal kan worden verwerkt.

**Werk een diagram automatisch bij wanneer een formulecel verandert?**

Een diagramserie kan naar werkboekcellen verwijzen. Bereken eerst het werkboek opnieuw, sla vervolgens de presentatie op of render deze. Als de diagramdatapunten naar de berekende cellen verwijzen, gebruikt het diagram die bijgewerkte celwaarden; een aparte diagram‑verversingsmethode is niet nodig voor deze workflow.

**Kunnen diagrammen een extern Excel‑werkboek gebruiken?**

Ja, diagramgegevens kunnen worden geconfigureerd om een extern werkboek te gebruiken via de diagram‑data‑API. Het formule‑berekeningsproces dat in dit artikel wordt beschreven, heeft echter alleen betrekking op het diagram‑werkboek en de formule‑subset die door Aspose.Slides wordt geëvalueerd. Ga er niet van uit dat [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--) volledige herberekening van willekeurige formules in een extern XLSX‑bestand biedt.

**Kan ik formules gebruiken die naar een ander werkblad of werkboek verwijzen?**

Excel‑stijl‑verwijzingen kunnen in diagram‑werkboeken voorkomen, maar de formule‑evaluatie is beperkt door de ondersteunde parser en functie‑set. Als een cross‑sheet‑ of externe verwijzing essentieel is, controleer dan die exacte formule met uw specifieke versie van Aspose.Slides. Voor workflows die brede Excel‑referentie‑compatibiliteit vereisen, bereken het werkboek extern en schrijf de opgeloste waarden terug naar de diagram‑data.

**Moeten formulestringen beginnen met `=`?**

De Aspose.Slides‑API‑voorbeelden wijzen uitdrukkingen toe zoals `B2-C2` of `SUM(B2:B5)` zonder een leidende `=`. Het gebruik van die vorm houdt gegenereerde formules consistent met de gedocumenteerde API‑voorbeelden.
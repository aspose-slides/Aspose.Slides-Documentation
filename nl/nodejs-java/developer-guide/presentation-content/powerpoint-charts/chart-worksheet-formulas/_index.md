---
title: Formules voor grafiekwerkbladen toepassen in presentaties met JavaScript
linktitle: Werkbladformules
type: docs
weight: 70
url: /nl/nodejs-java/chart-worksheet-formulas/
keywords:
- grafiek spreadsheet
- grafiek werkblad
- grafiekformule
- werkbladformule
- spreadsheetformule
- grafiekgegevens werkboek
- formuleberekening
- voorkeurscultuur
- cultuurspecifieke formule
- DBCS
- logische constante
- numerieke constante
- tekstconstante
- foutconstante
- rekenkundige operator
- vergelijkingsoperator
- A1 stijl
- R1C1 stijl
- voorgedefinieerde functie
- PowerPoint
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Excel-achtige formules toepassen in Aspose.Slides voor Node.js via Java-grafiekwerkbladen, waarden opnieuw berekenen en de resultaten gebruiken in PowerPoint-grafieken."
---
## **Overzicht**

PowerPoint‑grafieken slaan hun brongegevens meestal op in een ingebed werkblad. In Aspose.Slides voor Node.js via Java kun je dat werkblad benaderen via de grafiek‑databoekwerkmap, invoerwaarden schrijven, formules toewijzen aan cellen, ondersteunde formules berekenen en de berekende cellen gebruiken als grafiek‑gegevens.

Dit artikel beschrijft de volledige formule‑workflow: een grafiek maken, het werkblad vullen, A1‑ of R1C1‑formules toewijzen, ze opnieuw berekenen, de berekende waarden lezen, die cellen verbinden met een grafiekreeks en de presentatie opslaan. Het beschrijft tevens de ondersteunde formulasyntaxis, de ingebouwde functieverzameling, gecachete waarden, niet‑ondersteunde formules en spreadsheet‑specifieke fouten.

## **Grafiekwerkbladen en Formules**

Een grafiekwerkblad bevat de categorieën, reeks‑namen en waarden die door een grafiek worden gebruikt. In PowerPoint kun je het werkblad inspecteren door de grafiek‑gegevenseditor te openen:

![PowerPoint‑grafiek met zijn ingebedde werkblad geopend, met categorie‑ en reeksen‑gegevens weergegeven](chart-worksheet-formulas_1.png)

In Aspose.Slides wordt het werkblad blootgesteld via de [ChartDataWorkbook](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chartdataworkbook/)‑klasse. Gebruik [ChartDataCell.setFormula](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chartdatacell/#setFormula-java.lang.String-) voor A1‑formules en [ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chartdatacell/#setR1C1Formula-java.lang.String-) voor R1C1‑formules. Na het wijzigen van invoercellen of formules roep je [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--) aan om de ondersteunde formules opnieuw te berekenen en de corresponderende celwaarden bij te werken.

Een berekende cel onthult nog steeds zijn resultaat via [ChartDataCell.getValue](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chartdatacell/#getValue--). Dit is belangrijk wanneer je in code een formule‑resultaat wilt inspecteren of de cel als grafiekgegevens‑punt wilt gebruiken.

## **Een Grafiek Maken en Werkbladformules Berekenen**

Het volgende voorbeeld toont een end‑to‑end‑workflow. Het maakt een gegroepeerde kolomgrafiek, wist de voorbeeldgegevens, schrijft kwartaalomzet‑ en -kosten‑waarden, berekent winst met formules, leest de resultaten, gebruikt de berekende cellen als grafiekwaarden en slaat de presentatie op.

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

De grafiekdatapunten refereren `D2:D4`, zodat de grafiek de berekende winstwaarden gebruikt. Er is geen aparte grafiek‑verversingsaanroep in deze workflow: bereken eerst het werkblad, gebruik vervolgens of sla de grafiekgegevens op die naar de berekende cellen wijzen.

## **Gebruik A1‑Stijl Formules**

A1‑notatie identificeert kolommen met letters en rijen met cijfers. Wijs A1‑stijlexpressies toe via [ChartDataCell.setFormula](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chartdatacell/#setFormula-java.lang.String-).

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

Relatieve verwijzingen kunnen veranderen wanneer een formule wordt verplaatst of gekopieerd door een spreadsheet‑applicatie. Absolute verwijzingen houden beide coördinaten vast, terwijl gemengde verwijzingen alleen een rij of een kolom fixeren.

## **Gebruik R1C1‑Stijl Formules**

R1C1‑notatie identificeert zowel rijen als kolommen numeriek. Relatieve verwijzingen gebruiken offsets tussen vierkante haken. Wijs deze syntaxis toe via [ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chartdatacell/#setR1C1Formula-java.lang.String-).

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

## **Formule‑Constanten en Operatoren**

De ingebouwde formule‑evaluator ondersteunt logische waarden, numerieke literalens, strings, spreadsheet‑foutwaarden, rekenkundige operatoren en vergelijkingsoperatoren.

### **Constanten en Literalens**

| Type | Voorbeelden | Opmerkingen |
|---|---|---|
| Logisch | `TRUE`, `FALSE` | Kan direct worden gebruikt in logische expressies zoals `A2=TRUE`. |
| Numeriek | `1`, `0.5`, `.3`, `1E-2` | Gewone en wetenschappelijke notatie worden ondersteund. |
| String | `"abc"`, `"2/3/2020 12:00"` | Tekst‑literalens worden tussen dubbele aanhalingstekens geplaatst binnen de formule. |
| Foutresultaat | `#DIV/0!`, `#N/A`, `#REF!` | Een geldige formule kan evalueren tot een spreadsheet‑foutwaarde in plaats van een normaal resultaat. |

Dit voorbeeld gebruikt verschillende constante‑types:

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

    const logicalValue = workbook.getCell(0, "B2").getValue(); // onwaar
    const numericValue = workbook.getCell(0, "C2").getValue(); // 1.5
    const scientificValue = workbook.getCell(0, "D2").getValue(); // 0.003
    const stringValue = workbook.getCell(0, "E2").getValue(); // abc
    const errorValue = workbook.getCell(0, "F2").getValue(); // #DIV/0!
} finally {
    presentation.dispose();
}
```

### **Rekenkundige Operatoren**

| Operator | Betekenis | Voorbeeld |
|---|---|---|
| `+` | Optelling of unair plus | `2+3` |
| `-` | Aftrekking of negatie | `2-3`, `-3` |
| `*` | Vermenigvuldiging | `2*3` |
| `/` | Deling | `2/3` |
| `%` | Procent | `30%` |
| `^` | Exponentiële macht | `2^3` |

Gebruik haakjes om de evaluatievolgorde expliciet te maken, bijvoorbeeld `(A2+B2)*C2`.

### **Vergelijkingsoperatoren**

Vergelijkingsexpressies geven logische waarden terug.

| Operator | Betekenis | Voorbeeld |
|---|---|---|
| `=` | Gelijk aan | `A2=3` |
| `<>` | Niet gelijk aan | `A2<>3` |
| `>` | Groter dan | `A2>3` |
| `>=` | Groter dan of gelijk aan | `A2>=3` |
| `<` | Kleiner dan | `A2<3` |
| `<=` | Kleiner dan of gelijk aan | `A2<=3` |

## **Ondersteunde Vooraf Gedefinieerde Functies**

Aspose.Slides bevat een ingebouwde formule‑evaluator voor grafiekwerkbladen, maar het is geen volledige Excel‑rekenmachine. De gedocumenteerde functieverzameling is beperkt tot de onderstaande functies. Ga er niet van uit dat een willekeurige Excel‑functie kan worden herberekend door [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--).

| Functie | Doel of ondersteunde vorm | Voorbeeld |
|---|---|---|
| `ABS` | Absolute waarde | `ABS(A2)` |
| `AVERAGE` | Aritmetisch gemiddelde | `AVERAGE(B2:B5)` |
| `CEILING` | Rond een getal naar boven af op een veelvoud | `CEILING(A2,5)` |
| `CHOOSE` | Selecteer een waarde op index | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | Voeg tekstwaarden samen | `CONCAT(A2,B2)` |
| `CONCATENATE` | Voeg tekstwaarden samen | `CONCATENATE(A2," ",B2)` |
| `DATE` | Maak een datumwaarde met het 1900‑datumssysteem | `DATE(2026,8,19)` |
| `DAYS` | Retourneert het aantal dagen tussen datums | `DAYS(B2,A2)` |
| `FIND` | Zoek een tekstreeks binnen een andere | `FIND("-",A2)` |
| `FINDB` | Byte‑georiënteerd tekstreeks‑zoek | `FINDB("a",A2)` |
| `IF` | Voorwaardelijk resultaat | `IF(A2>0,A2,0)` |
| `INDEX` | Referentie‑vorm | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | Vector‑vorm | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | Vector‑vorm | `MATCH(A2,B2:B5,0)` |
| `MAX` | Maximumwaarde | `MAX(B2:B5)` |
| `SUM` | Som van waarden | `SUM(B2:B5)` |
| `VLOOKUP` | Verticale zoekopdracht | `VLOOKUP(A2,B2:D10,3,FALSE)` |

De restricties in de tabel zijn belangrijk: `INDEX` wordt gedocumenteerd in referentie‑vorm, terwijl `LOOKUP` en `MATCH` in hun vector‑vorm staan. `DATE` gebruikt het 1900‑datumssysteem. Functies die hier niet vermeld staan, moeten als niet‑ondersteund worden beschouwd door de Aspose.Slides‑formule‑evaluator, tenzij ze afzonderlijk zijn gedocumenteerd.

## **Formules Berekenen met een Voorkeurscultuur**

Sommige werkblad‑functies interpreteren tekst volgens cultuur‑specifieke regels. Dit is vooral belangrijk voor functies die zijn bedoeld voor talen die dubbele‑byte‑karaktersets (DBCS) gebruiken. Om dergelijke formules correct te berekenen, maak je een [LoadOptions](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/loadoptions/), stel je de voorkeurscultuur in met [SpreadsheetOptions.setPreferredCulture](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/spreadsheetoptions/#setPreferredCulture), wijs je de spreadsheet‑opties toe via [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/loadoptions/#setSpreadsheetOptions) en laad je vervolgens de presentatie.

Het volgende voorbeeld selecteert de Japanse cultuur, opent een presentatie met de geconfigureerde laadopties en roept [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--) aan voor elk grafiek‑werkboek:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const japaneseCulture = java.newInstanceSync("java.util.Locale", "ja", "JP");

const spreadsheetOptions = new aspose.slides.SpreadsheetOptions();
spreadsheetOptions.setPreferredCulture(japaneseCulture);

const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setSpreadsheetOptions(spreadsheetOptions);

const presentation = new aspose.slides.Presentation("presentation.pptx", loadOptions);
try {
    const slides = presentation.getSlides();
    for (let slideIndex = 0; slideIndex < slides.size(); slideIndex++) {
        const shapes = slides.get_Item(slideIndex).getShapes();
        for (let shapeIndex = 0; shapeIndex < shapes.size(); shapeIndex++) {
            const shape = shapes.get_Item(shapeIndex);
            if (java.instanceOf(shape, "com.aspose.slides.IChart")) {
                shape.getChartData().getChartDataWorkbook().calculateFormulas();
            }
        }
    }
} finally {
    presentation.dispose();
}
```

De voorkeurscultuur maakt deel uit van de presentatie‑laadconfiguratie, dus stel deze in voordat je een [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/)‑instantie maakt. Gebruik de cultuur die door de werkboek‑formules wordt verwacht; bijvoorbeeld `ja-JP` voor formules die de Japanse DBCS‑rekenregels volgen.

## **Herberekenen en Gecacheerde Waarden**

Spreadsheet‑bestanden slaan doorgaans zowel een formule als de laatst berekende waarde op. Aspose.Slides kan daarom een gecacheerde waarde lezen via [ChartDataCell.getValue](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chartdatacell/#getValue--) wanneer een presentatie wordt geladen en de betreffende grafiekgegevens niet zijn gewijzigd.

Na het wijzigen van invoercellen of formules moet je niet vertrouwen op een oude gecachede uitkomst. Roep [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--) aan voordat je berekende waarden leest of grafiekgegevens opslaat die daarop vertrouwen.

Voor formules buiten de ondersteunde deelverzameling kan Aspose.Slides de formule mogelijk niet parseren of de afhankelijkheden vaststellen. Als het werkboek is aangepast, kan de vorige gecachede waarde niet langer als betrouwbaar worden beschouwd. In dat geval kan het lezen van een cel met niet‑ondersteunde data een [CellUnsupportedDataException](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/cellunsupporteddataexception/) veroorzaken.

Als je grafiek afhankelijk is van Excel‑functies die Aspose.Slides niet evalueert, bereken die formules dan met een spreadsheet‑engine die ze ondersteunt en schrijf de resulterende waarden terug naar het grafiek‑werkboek. Vervang niet‑ondersteunde formules niet door geraden waarden.

## **Formuleringsfouten Afhandelen**

Er zijn twee verschillende soorten problemen te onderscheiden.

Een formule kan geldig zijn maar een spreadsheet‑foutresultaat opleveren, zoals `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!` of `#VALUE!`. In dat geval is het fouttoken een celresultaat en kan het worden geretourneerd via [ChartDataCell.getValue](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chartdatacell/#getValue--).

Een formule kan ook falen op het gebied van parsing, referentie, afhankelijkheid of ondersteunde data. Aspose.Slides biedt spreadsheet‑specifieke uitzonderingen voor deze gevallen: [CellInvalidFormulaException](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/cellcircularreferenceexception/) en [CellUnsupportedDataException](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/cellunsupporteddataexception/).

Wanneer formules afkomstig zijn uit sjablonen of door de gebruiker worden ingevoerd, vang dan fouten af tijdens het herberekenen en het benaderen van waarden. De foutdetails identificeren het onderliggende spreadsheet‑probleem:

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

## **Praktische Beperkingen**

De formule‑ondersteuning in grafiekwerkbladen is bedoeld voor een gedefinieerde subset van spreadsheet‑berekeningen, niet voor volledige Excel‑compatibiliteit. Houd deze beperkingen in gedachten bij het ontwerpen van een rapportage‑workflow:

- Gebruik alleen de gedocumenteerde constanten, operatoren, verwijzingen en functies wanneer je wilt dat Aspose.Slides formules herberekent.
- Herbereken na het wijzigen van cellen waar formule‑resultaten van afhangen.
- Beschouw gecachete waarden uit geladen presentaties als momentopnames, niet als vervanging voor herberekening na bewerkingen.
- Test formules uit bestaande sjablonen voordat je vertrouwt op hun berekende waarden, vooral wanneer ze functies buiten de gedocumenteerde lijst gebruiken.
- Voor formules die een volledige spreadsheet‑rekenmachine vereisen, bereken ze extern en werk daarna het grafiek‑werkboek bij met de resulterende waarden.

## **FAQ**

**Wat is het verschil tussen [ChartDataCell.setFormula](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chartdatacell/#setFormula-java.lang.String-) en [ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chartdatacell/#setR1C1Formula-java.lang.String-)?**

[ChartDataCell.setFormula](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chartdatacell/#setFormula-java.lang.String-) slaat een A1‑stijl expressie op, zoals `B2-C2`. [ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chartdatacell/#setR1C1Formula-java.lang.String-) slaat een R1C1‑stijl expressie op, zoals `RC[-2]-RC[-1]`. Gebruik de notatie die het beste past bij hoe je formules genereert of kopieert.

**Moet ik de cel zelf lezen of de waarde na berekening?**

[ChartDataWorkbook.getCell](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chartdataworkbook/#getCell-int-java.lang.String-) retourneert een [ChartDataCell](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chartdatacell/). Om het berekende resultaat te verkrijgen, roep je de [ChartDataCell.getValue](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chartdatacell/#getValue--)‑methode van die cel aan na herberekening.

**Wanneer moet ik [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--) aanroepen?**

Roep [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--) aan nadat je invoerwaarden of formules hebt gewijzigd en voordat je afhankelijk bent van de berekende resultaten. Dit werkt de waarden van de door de ingebouwde evaluator ondersteunde formules bij.

**Ondersteunt Aspose.Slides elke Excel‑functie?**

Nee. De ingebouwde evaluator ondersteunt een gedocumenteerde subset van functies. Functies buiten die subset mogen niet worden verondersteld correct te worden herberekend. Als volledige Excel‑formule‑compatibiliteit vereist is, voer dan de berekening uit met een geschikte spreadsheet‑engine en schrijf de eindwaarden naar het grafiek‑werkboek.

**Wat gebeurt er als een geladen presentatie een niet‑ondersteunde formule bevat?**

Als de grafiekgegevens niet zijn gewijzigd, kan het werkboek nog steeds een eerder berekende, gecachete waarde bevatten. Nadat gerelateerde data is aangepast, is die gecachete waarde mogelijk niet meer geldig. Het benaderen van een cel waarvan de formule niet kan worden verwerkt, kan een [CellUnsupportedDataException](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/cellunsupporteddataexception/) veroorzaken.

**Zijn formule‑foutwaarden hetzelfde als uitzonderingen?**

Nee. Een resultaat zoals `#DIV/0!` is een spreadsheet‑waarde die voortkomt uit een geldige berekening. Uitzonderingen zoals [CellInvalidFormulaException](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/cellinvalidformulaexception/) of [CellCircularReferenceException](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/cellcircularreferenceexception/) geven aan dat de formule niet normaal kan worden verwerkt.

**Werk een grafiek automatisch bij wanneer een formulecel verandert?**

Een grafiekreeks kan verwijzen naar werkbladcellen. Herbereken eerst het werkboek, sla daarna de presentatie op of render deze. Als de grafiekdatapunten naar de berekende cellen verwijzen, gebruikt de grafiek die bijgewerkte celwaarden; er is geen aparte grafiek‑verversingsmethode vereist voor deze workflow.

**Kunnen grafieken een extern Excel‑werkboek gebruiken?**

Ja, grafiekgegevens kunnen worden geconfigureerd om een extern werkboek te gebruiken via de grafiek‑data‑API. De hier beschreven formule‑berekeningsworkflow heeft echter betrekking op het grafiek‑werkboek en de door Aspose.Slides geëvalueerde formulesubset. Ga er niet van uit dat [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--) volledige herberekening van willekeurige formules in een extern XLSX‑bestand biedt.

**Kan ik formules gebruiken die naar een ander werkblad of werkboek verwijzen?**

Excel‑stijl verwijzingen kunnen bestaan in grafiek‑werkboeken, maar de formule‑evaluatie is beperkt tot de ondersteunde parser en functieverzameling. Als een kruis‑sheet‑ of externe verwijzing essentieel is, controleer die exacte formule met jouw doel‑Aspose.Slides‑versie. Voor workflows die brede Excel‑verwijzingscompatibiliteit vereisen, bereken het werkboek extern en schrijf de opgeloste waarden terug naar de grafiekgegevens.

**Moeten formule‑strings beginnen met `=`?**

De Aspose.Slides‑API‑voorbeelden wijzen expressies toe zoals `B2-C2` of `SUM(B2:B5)` zonder een leidende `=`. Het gebruik van die vorm houdt gegenereerde formules consistent met de gedocumenteerde API‑voorbeelden.
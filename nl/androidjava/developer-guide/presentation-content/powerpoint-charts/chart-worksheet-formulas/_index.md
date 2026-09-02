---
title: Toepassen van grafiek‑werkbladformules in presentaties op Android
linktitle: Werkbladformules
type: docs
weight: 70
url: /nl/androidjava/chart-worksheet-formulas/
keywords:
- grafiek spreadsheet
- grafiek werkblad
- grafiekformule
- werkbladformule
- spreadsheetformule
- grafiekdatawerkmap
- formuleberekening
- voorkeurscultuur
- cultuurspecifieke formule
- DBCS
- logische constante
- numerieke constante
- tekenreeksconstante
- foutconstante
- rekenkundige operator
- vergelijkingsoperator
- A1-stijl
- R1C1-stijl
- voorgedefinieerde functie
- PowerPoint
- presentatie
- Android
- Java
- Aspose.Slides
description: "Pas Excel‑stijlfomules toe in Aspose.Slides voor Android via Java‑grafiek‑werkbladen, bereken waarden opnieuw en gebruik de resultaten in PowerPoint‑grafieken."
---
## **Overzicht**

PowerPoint‑grafieken slaan hun brongegevens doorgaans op in een ingesloten werkblad. In Aspose.Slides voor Android via Java kun je dat werkblad benaderen via de werkmap voor chart‑gegevens, invoerwaarden schrijven, formules toewijzen aan cellen, ondersteunde formules berekenen en de berekende cellen gebruiken als grafiekgegevens.

Dit artikel legt de volledige formule‑werkstroom uit: maak een grafiek, vul het werkblad, wijs A1‑ of R1C1‑formules toe, re‑calculeer ze, lees de berekende waarden, koppel die cellen aan een grafiekserie en sla de presentatie op. Het beschrijft tevens de ondersteunde formule‑syntaxis, de ingebouwde functiesubset, gecachete waarden, niet‑ondersteunde formules en spreadsheet‑specifieke fouten.

## **Grafiek‑werkbladen en formules**

Een grafiek‑werkblad bevat de categorieën, serienaam​en en waarden die door een grafiek worden gebruikt. In PowerPoint kun je het werkblad bekijken door de grafiek‑gegevenseditor te openen:

![PowerPoint‑grafiek met het ingesloten werkblad geopend, met categorie‑ en seriedata weergegeven](chart-worksheet-formulas_1.png)

In Aspose.Slides wordt het werkblad beschikbaar gesteld via de interface [IChartDataWorkbook](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ichartdataworkbook/). Gebruik [IChartDataCell.setFormula](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-) voor A1‑formules en [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-) voor R1C1‑formules. Na het wijzigen van invoercellen of formules roep je [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) aan om ondersteunde formules opnieuw te berekenen en de bijbehorende celwaarden bij te werken.

Een berekende cel geeft nog steeds zijn resultaat weer via [IChartDataCell.getValue](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ichartdatacell/#getValue--). Dit is belangrijk wanneer je het resultaat van een formule in code moet inspecteren of de cel als een grafiek‑datapunt wilt gebruiken.

## **Maak een grafiek en bereken werkblad‑formules**

Het volgende voorbeeld toont een volledige werkstroom. Het maakt een gegroepeerde kolomgrafiek, wist de voorbeeldgegevens, schrijft kwartaalomzet‑ en -kostenwaarden, berekent winst met formules, leest de resultaten, gebruikt de berekende cellen als grafiekwaarden en slaat de presentatie op.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 350);
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    int worksheetIndex = 0;

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    workbook.clear(worksheetIndex);

    IChartDataCell category1 = workbook.getCell(worksheetIndex, "A2", "Q1");
    IChartDataCell category2 = workbook.getCell(worksheetIndex, "A3", "Q2");
    IChartDataCell category3 = workbook.getCell(worksheetIndex, "A4", "Q3");

    workbook.getCell(worksheetIndex, "B1", "Revenue");
    workbook.getCell(worksheetIndex, "C1", "Expenses");
    workbook.getCell(worksheetIndex, "D1", "Profit");

    workbook.getCell(worksheetIndex, "B2").setValue(120.0);
    workbook.getCell(worksheetIndex, "C2").setValue(80.0);
    workbook.getCell(worksheetIndex, "B3").setValue(150.0);
    workbook.getCell(worksheetIndex, "C3").setValue(95.0);
    workbook.getCell(worksheetIndex, "B4").setValue(135.0);
    workbook.getCell(worksheetIndex, "C4").setValue(110.0);

    IChartDataCell profit1 = workbook.getCell(worksheetIndex, "D2");
    IChartDataCell profit2 = workbook.getCell(worksheetIndex, "D3");
    IChartDataCell profit3 = workbook.getCell(worksheetIndex, "D4");

    profit1.setFormula("B2-C2");
    profit2.setFormula("B3-C3");
    profit3.setFormula("B4-C4");

    workbook.calculateFormulas();

    double q1Profit = ((Number) profit1.getValue()).doubleValue(); // 40
    double q2Profit = ((Number) profit2.getValue()).doubleValue(); // 55
    double q3Profit = ((Number) profit3.getValue()).doubleValue(); // 25

    System.out.println("Q1 profit: " + q1Profit);
    System.out.println("Q2 profit: " + q2Profit);
    System.out.println("Q3 profit: " + q3Profit);

    chart.getChartData().getCategories().add(category1);
    chart.getChartData().getCategories().add(category2);
    chart.getChartData().getCategories().add(category3);

    IChartSeries profitSeries = chart.getChartData().getSeries().add(workbook.getCell(worksheetIndex, "D1"), chart.getType());
    profitSeries.getDataPoints().addDataPointForBarSeries(profit1);
    profitSeries.getDataPoints().addDataPointForBarSeries(profit2);
    profitSeries.getDataPoints().addDataPointForBarSeries(profit3);
    profitSeries.getLabels().getDefaultDataLabelFormat().setShowValue(true);

    presentation.save("chart-formulas.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

De grafiekdatapunten verwijzen naar `D2:D4`, dus de grafiek gebruikt de berekende winstwaarden. Er is geen aparte grafiek‑verversingsaanroep in deze workflow: bereken eerst de werkmap opnieuw, en gebruik of sla daarna de grafiekgegevens op die naar de berekende cellen wijzen.

## **Gebruik A1‑formules**

A1‑notatie identificeert kolommen met letters en rijen met cijfers. Wijs A1‑expressies toe via [IChartDataCell.setFormula](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-).

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300);
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    workbook.getCell(0, "C3").setValue(10);
    workbook.getCell(0, "F2").setValue(2);
    workbook.getCell(0, "G2").setValue(3);
    workbook.getCell(0, "H2").setValue(4);

    IChartDataCell cell = workbook.getCell(0, "A2");
    cell.setFormula("C3+SUM(F2:H2)");

    workbook.calculateFormulas();

    Object value = cell.getValue(); // 19
} finally {
    presentation.dispose();
}
```

Veelvoorkomende A1‑referentie‑vormen zijn:

| Referentie | Relatief | Absoluut | Gemengd |
|---|---|---|---|
| Cel | `A2` | `$A$2` | `A$2`, `$A2` |
| Rij | `2:2` | `$2:$2` | — |
| Kolom | `A:A` | `$A:$A` | — |
| Bereik | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

Relatieve referenties kunnen wijzigen wanneer een formule wordt verplaatst of gekopieerd door een spreadsheet‑toepassing. Absolute referenties houden beide coördinaten vast, terwijl gemengde referenties alleen een rij of een kolom vastzetten.

## **Gebruik R1C1‑formules**

R1C1‑notatie identificeert zowel rijen als kolommen numeriek. Relatieve referenties gebruiken offset‑waarden in vierkante haken. Wijs deze syntaxis toe via [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-).

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300);
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    workbook.getCell(0, "B2").setValue(12);
    workbook.getCell(0, "C2").setValue(5);

    IChartDataCell cell = workbook.getCell(0, "D2");
    cell.setR1C1Formula("RC[-2]-RC[-1]");

    workbook.calculateFormulas();

    Object value = cell.getValue(); // 7
} finally {
    presentation.dispose();
}
```

Veelvoorkomende R1C1‑referentie‑vormen zijn:

| Referentie | Relatief | Absoluut | Gemengd |
|---|---|---|---|
| Cel | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| Rij | `R[2]` | `R2` | — |
| Kolom | `C[3]` | `C3` | — |
| Bereik | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

Bijvoorbeeld, in cel `D2` betekent `RC[-2]` de cel in dezelfde rij twee kolommen naar links (`B2`).

## **Formule‑constanten en operatoren**

De ingebouwde formule‑evaluator ondersteunt logische waarden, numerieke literal​en, tekenreeksen, spreadsheet‑foutwaarden, rekenkundige operatoren en vergelijkingsoperatoren.

### **Constanten en literal​en**

| Type | Voorbeelden | Opmerkingen |
|---|---|---|
| Logisch | `TRUE`, `FALSE` | Kan rechtstreeks worden gebruikt in logische expressies zoals `A2=TRUE`. |
| Numeriek | `1`, `0.5`, `.3`, `1E-2` | Komma‑ en wetenschappelijke notatie worden ondersteund. |
| Tekenreeks | `"abc"`, `"2/3/2020 12:00"` | Tekenreeks‑literal​en worden tussen dubbele aanhalingstekens geplaatst binnen de formule. |
| Foutresultaat | `#DIV/0!`, `#N/A`, `#REF!` | Een geldige formule kan resulteren in een spreadsheet‑foutwaarde in plaats van een normaal resultaat. |

Dit voorbeeld gebruikt verschillende constant‑typen:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300);
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    workbook.getCell(0, "A2").setValue(false);
    workbook.getCell(0, "B2").setFormula("A2=TRUE");
    workbook.getCell(0, "C2").setFormula("1+0.5");
    workbook.getCell(0, "D2").setFormula(".3*1E-2");
    workbook.getCell(0, "E2").setFormula("\"abc\"");
    workbook.getCell(0, "F2").setFormula("2/0");

    workbook.calculateFormulas();

    Object logicalValue = workbook.getCell(0, "B2").getValue(); // onwaar
    Object numericValue = workbook.getCell(0, "C2").getValue(); // 1.5
    Object scientificValue = workbook.getCell(0, "D2").getValue(); // 0.003
    Object stringValue = workbook.getCell(0, "E2").getValue(); // abc
    Object errorValue = workbook.getCell(0, "F2").getValue(); // #DIV/0!
} finally {
    presentation.dispose();
}
```

### **Rekenkundige operatoren**

| Operator | Betekenis | Voorbeeld |
|---|---|---|
| `+` | Optelling of unair plus | `2+3` |
| `-` | Aftrekking of negatie | `2-3`, `-3` |
| `*` | Vermenigvuldiging | `2*3` |
| `/` | Deling | `2/3` |
| `%` | Procent | `30%` |
| `^` | Exponentiële macht | `2^3` |

Gebruik haakjes om de volgorde van evaluatie expliciet te maken, bijvoorbeeld `(A2+B2)*C2`.

### **Vergelijkingsoperatoren**

Vergelijkingsexpressies retourneren logische waarden.

| Operator | Betekenis | Voorbeeld |
|---|---|---|
| `=` | Gelijk aan | `A2=3` |
| `<>` | Niet gelijk aan | `A2<>3` |
| `>` | Groter dan | `A2>3` |
| `>=` | Groter dan of gelijk aan | `A2>=3` |
| `<` | Kleiner dan | `A2<3` |
| `<=` | Kleiner dan of gelijk aan | `A2<=3` |

## **Ondersteunde vooraf gedefinieerde functies**

Aspose.Slides bevat een ingebouwde formule‑evaluator voor grafiek‑werkbladen, maar het is geen volledige Excel‑rekenmachine. De gedocumenteerde functielijst is beperkt tot de onderstaande functies. Ga er niet van uit dat een willekeurige Excel‑functie kan worden herberekend door [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ichartdataworkbook/#calculateFormulas--).

| Functie | Doel of ondersteunde vorm | Voorbeeld |
|---|---|---|
| `ABS` | Absolute waarde | `ABS(A2)` |
| `AVERAGE` | Rekenkundig gemiddelde | `AVERAGE(B2:B5)` |
| `CEILING` | Afronden naar boven tot een veelvoud | `CEILING(A2,5)` |
| `CHOOSE` | Selecteer een waarde op index | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | Tekstwaarden samenvoegen | `CONCAT(A2,B2)` |
| `CONCATENATE` | Tekstwaarden samenvoegen | `CONCATENATE(A2," ",B2)` |
| `DATE` | Datumwaarde maken met het 1900‑datumstelsel | `DATE(2026,8,19)` |
| `DAYS` | Aantal dagen tussen datums retourneren | `DAYS(B2,A2)` |
| `FIND` | Zoek een tekstwaarde binnen een andere | `FIND("-",A2)` |
| `FINDB` | Byte‑georiënteerd zoeken in tekst | `FINDB("a",A2)` |
| `IF` | Voorwaardelijk resultaat | `IF(A2>0,A2,0)` |
| `INDEX` | Referentie‑vorm | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | Vector‑vorm | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | Vector‑vorm | `MATCH(A2,B2:B5,0)` |
| `MAX` | Maximumwaarde | `MAX(B2:B5)` |
| `SUM` | Som van waarden | `SUM(B2:B5)` |
| `VLOOKUP` | Verticale zoektocht | `VLOOKUP(A2,B2:D10,3,FALSE)` |

De beperkingen in de tabel zijn belangrijk: `INDEX` wordt gedocumenteerd in referentie‑vorm, terwijl `LOOKUP` en `MATCH` in hun vector‑vormen staan. `DATE` gebruikt het 1900‑datumstelsel. Functies en kenmerken die hier niet worden genoemd, moeten worden beschouwd als niet‑ondersteund door de Aspose.Slides‑formule‑evaluator, tenzij ze afzonderlijk zijn gedocumenteerd.

## **Formules berekenen met een voorkeurs‑cultuur**

Sommige functies van de grafiek‑werkmap interpreteren tekst volgens cultuur‑specifieke regels. Dit is vooral belangrijk voor functies bedoeld voor talen die double‑byte‑tekensets (DBCS) gebruiken. Om dergelijke formules correct te berekenen, create [LoadOptions](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/loadoptions/), stel de voorkeurs‑cultuur in met [SpreadsheetOptions.setPreferredCulture](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/spreadsheetoptions/#setPreferredCulture-java.util.Locale-), wijs de spreadsheet‑opties toe via [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/loadoptions/#setSpreadsheetOptions-com.aspose.slides.ISpreadsheetOptions-), en laad vervolgens de presentatie.

Het volgende voorbeeld selecteert de Japanse cultuur, opent een presentatie met de geconfigureerde load‑options, en roept [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) aan voor elke grafiek‑werkmap:

```java
import com.aspose.slides.*;
import java.util.Locale;

Locale japaneseCulture = Locale.forLanguageTag("ja-JP");

ISpreadsheetOptions spreadsheetOptions = new SpreadsheetOptions();
spreadsheetOptions.setPreferredCulture(japaneseCulture);

LoadOptions loadOptions = new LoadOptions();
loadOptions.setSpreadsheetOptions(spreadsheetOptions);

Presentation presentation = new Presentation("presentation.pptx", loadOptions);
try {
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IChart) {
                IChart chart = (IChart) shape;
                chart.getChartData().getChartDataWorkbook().calculateFormulas();
            }
        }
    }
} finally {
    presentation.dispose();
}
```

De voorkeurs‑cultuur maakt deel uit van de configuratie voor het laden van de presentatie, dus stel deze in vóór het aanmaken van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/) instantie. Gebruik de cultuur die de werkmap‑formules verwachten; bijvoorbeeld `ja-JP` voor formules die de Japanse DBCS‑rekenregels moeten volgen.

## **Herberekening en gecachete waarden**

Spreadsheet‑bestanden slaan doorgaans zowel een formule als de laatst berekende waarde op. Aspose.Slides kan daardoor een gecachete waarde lezen via [IChartDataCell.getValue](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ichartdatacell/#getValue--) wanneer een presentatie wordt geladen en de bijbehorende grafiekgegevens niet gewijzigd zijn.

Na het wijzigen van invoercellen of formules moet je niet vertrouwen op een oude gecachete waarde. Roep [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) aan voordat je berekende waarden leest of grafiekgegevens opslaat die ervan afhankelijk zijn.

Voor formules buiten de ondersteunde subset kan Aspose.Slides de formule mogelijk niet parseren of de afhankelijkheden bepalen. Als de werkmap is aangepast, kan de eerdere gecachete waarde niet meer als betrouwbaar worden beschouwd. In dat geval kan het lezen van de waarde van een cel met niet‑ondersteunde data een [CellUnsupportedDataException](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/cellunsupporteddataexception/) veroorzaken.

Als je grafiek afhankelijk is van Excel‑functies die Aspose.Slides niet evalueert, bereken die formules met een spreadsheet‑engine die ze ondersteunt en schrijf de resulterende waarden terug naar de grafiek‑werkmap. Vervang niet‑ondersteunde formules niet door geschatte waarden.

## **Formule‑fouten afhandelen**

Er zijn twee verschillende soorten problemen te onderscheiden.

Een formule kan geldig zijn maar een spreadsheet‑foutresultaat opleveren, zoals `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!` of `#VALUE!`. In dat geval is het fout‑token een celresultaat en kan het worden geretourneerd via [IChartDataCell.getValue](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ichartdatacell/#getValue--).

Een formule kan ook falen op het niveau van parseren, referentie, afhankelijkheid of ondersteunde data. Aspose.Slides biedt daarvoor spreadsheet‑specifieke uitzonderingen: [CellInvalidFormulaException](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/cellcircularreferenceexception/), en [CellUnsupportedDataException](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/cellunsupporteddataexception/).

Wanneer formules afkomstig zijn van sjablonen of gebruikersinvoer, behandel deze uitzonderingen rond herberekening en het benaderen van waarden:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300);
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    IChartDataCell cell = workbook.getCell(0, "A2");
    cell.setFormula("SUM(B2:B5)");

    try {
        workbook.calculateFormulas();
        System.out.println(cell.getValue());
    } catch (CellInvalidFormulaException ex) {
        System.err.println("Invalid formula: " + ex.getMessage());
    } catch (CellInvalidReferenceException ex) {
        System.err.println("Invalid cell reference: " + ex.getMessage());
    } catch (CellCircularReferenceException ex) {
        System.err.println("Circular reference: " + ex.getMessage());
    } catch (CellUnsupportedDataException ex) {
        System.err.println("Unsupported spreadsheet data: " + ex.getMessage());
    }
} finally {
    presentation.dispose();
}
```

## **Praktische beperkingen**

De formule‑ondersteuning in grafiek‑werkbladen is bedoeld voor een gedefinieerde subset van spreadsheet‑berekeningen, niet voor volledige Excel‑compatibiliteit. Houd deze beperkingen in gedachten bij het ontwerpen van een rapportage‑werkstroom:

- Gebruik alleen de gedocumenteerde constanten, operatoren, referenties en functies wanneer je wilt dat Aspose.Slides formules herberekent.
- Herbereken na het wijzigen van cellen waarvan de formule‑resultaten afhankelijk zijn.
- Beschouw gecachete waarden uit geladen presentaties als momentopnamen, niet als vervanging voor herberekening na bewerkingen.
- Test formules uit bestaande sjablonen voordat je vertrouwt op hun berekende waarden, vooral wanneer ze functies buiten de gedocumenteerde lijst gebruiken.
- Voor formules die een volledige spreadsheet‑rekenmachine vereisen, bereken ze extern en werk daarna de grafiek‑werkmap bij met de resulterende waarden.

## **FAQ**

**Wat is het verschil tussen [IChartDataCell.setFormula](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-) en [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-)?**

[IChartDataCell.setFormula](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-) slaat een A1‑stijl‑expressie op, bijvoorbeeld `B2-C2`. [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-) slaat een R1C1‑stijl‑expressie op, bijvoorbeeld `RC[-2]-RC[-1]`. Gebruik de notatie die het best aansluit bij hoe je formules genereert of kopieert.

**Moet ik na berekening de cel zelf of de waarde ervan lezen?**

[IChartDataWorkbook.getCell](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ichartdataworkbook/#getCell-int-java.lang.String-) retourneert een [IChartDataCell](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ichartdatacell/). Om het berekende resultaat te krijgen, roep je die cel’s [IChartDataCell.getValue](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ichartdatacell/#getValue--) methode aan na herberekening.

**Wanneer moet ik [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) aanroepen?**

Roep [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) aan nadat je invoerwaarden of formules hebt gewijzigd en voordat je afhankelijk bent van de berekende resultaten. Dit werkt de waarden van formules bij die de ingebouwde evaluator ondersteunt.

**Ondersteunt Aspose.Slides elke Excel‑functie?**

Nee. De ingebouwde evaluator ondersteunt een gedocumenteerde subset van functies. Functies buiten die subset moeten niet worden verondersteld correct te herberekenen. Als volledige Excel‑formule‑compatibiliteit vereist is, voer dan de berekening uit met een geschikte spreadsheet‑engine en schrijf de uiteindelijke waarden naar de grafiek‑werkmap.

**Wat gebeurt er als een geladen presentatie een niet‑ondersteunde formule bevat?**

Als de grafiekgegevens niet zijn gewijzigd, kan de werkmap nog een eerder berekende gecachete waarde bevatten. Nadat gerelateerde data is aangepast, kan die gecachete waarde ongeldig zijn. Het benaderen van een cel waarvan de formule niet kan worden verwerkt kan een [CellUnsupportedDataException](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/cellunsupporteddataexception/) veroorzaken.

**Zijn formule‑foutwaarden hetzelfde als Java‑exceptions?**

Nee. Een resultaat zoals `#DIV/0!` is een spreadsheet‑waarde die voortkomt uit een geldige berekening. Exceptions zoals [CellInvalidFormulaException](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/cellinvalidformulaexception/) of [CellCircularReferenceException](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/cellcircularreferenceexception/) geven aan dat de formule niet normaal kan worden verwerkt.

**Werkt een grafiek automatisch bij wanneer een formulecel verandert?**

Een grafiekserie kan verwijzen naar werkmapcellen. Bereken eerst de werkmap opnieuw, sla dan de presentatie op of render deze. Als de grafiekdatapunten naar de berekende cellen verwijzen, gebruikt de grafiek die bijgewerkte celwaarden; een aparte grafiek‑verversingsmethode is niet nodig voor deze workflow.

**Kunnen grafieken een extern Excel‑werkboek gebruiken?**

Ja, grafiekgegevens kunnen worden geconfigureerd om een extern werkboek te gebruiken via de chart‑data‑API. Het beschreven formule‑berekeningsproces echter betreft alleen de grafiek‑werkmap en de door Aspose.Slides geëvalueerde functie‑subset. Ga er niet van uit dat [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) volledige herberekening van willekeurige formules in een extern XLSX‑bestand biedt.

**Kan ik formules gebruiken die naar een ander werkblad of werkboek verwijzen?**

Excel‑stijl referenties kunnen in grafiek‑werkboeken voorkomen, maar formule‑evaluatie is beperkt tot de ondersteunde parser en functieset. Als een kruis‑sheet‑ of externe referentie essentieel is, controleer dan die exacte formule met de versie van Aspose.Slides die je gebruikt. Voor workflows die brede Excel‑referentie‑compatibiliteit vereisen, bereken de werkmap extern en schrijf de opgeloste waarden terug naar de grafiek‑gegevens.

**Moeten formule‑strings beginnen met `=`?**

De Aspose.Slides‑API‑voorbeelden wijzen uitdrukkingen toe zoals `B2-C2` of `SUM(B2:B5)` zonder een leidende `=`. Het gebruik van die vorm houdt gegenereerde formules consistent met de gedocumenteerde API‑voorbeelden.
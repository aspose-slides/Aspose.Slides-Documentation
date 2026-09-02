---
title: Formules voor diagramwerkbladen toepassen in presentaties in Java
linktitle: Werkbladformules
type: docs
weight: 70
url: /nl/java/chart-worksheet-formulas/
keywords:
- diagram spreadsheet
- diagram werkblad
- diagramformule
- werkbladformule
- spreadsheetformule
- diagramgegevens-werkmap
- formuleberekening
- logische constante
- numerieke constante
- stringconstante
- foutconstante
- rekenkundige operator
- vergelijkingsoperator
- A1‑stijl
- R1C1‑stijl
- vooraf gedefinieerde functie
- PowerPoint
- presentatie
- Java
- Aspose.Slides
description: "Excel‑stijlformules toepassen in Aspose.Slides voor Java‑diagramwerkbladen, waarden opnieuw berekenen en de resultaten gebruiken in PowerPoint‑diagrammen."
---
## **Overzicht**

PowerPoint‑diagrammen slaan hun brongegevens meestal op in een ingesloten werkblad. In Aspose.Slides for Java kun je dat werkblad benaderen via de chart‑data‑workbook, invoerwaarden schrijven, formules aan cellen toekennen, ondersteunde formules berekenen en de berekende cellen gebruiken als diagramgegevens.

Dit artikel legt de volledige formule‑werkstroom uit: een diagram maken, het werkblad vullen, A1‑ of R1C1‑formules toekennen, ze opnieuw berekenen, de berekende waarden lezen, die cellen koppelen aan een diagramreeks en de presentatie opslaan. Het beschrijft ook de ondersteunde formule‑syntaxis, de ingebouwde functie‑subset, gecachete waarden, niet‑ondersteunde formules en spreadsheet‑specifieke fouten.

## **Diagram‑werkbladen en Formules**

Een diagram‑werkblad bevat de categorieën, reeksnamen en waarden die een diagram gebruikt. In PowerPoint kun je het werkblad inspecteren door de diagram‑data‑editor te openen:

![PowerPoint-diagram met zijn ingesloten werkblad geopend, met categorie‑ en seriedata](chart-worksheet-formulas_1.png)

In Aspose.Slides wordt het werkblad blootgesteld via de [IChartDataWorkbook](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ichartdataworkbook/) interface. Gebruik [IChartDataCell.setFormula](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-) voor A1‑stijl formules en [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-) voor R1C1‑stijl formules. Nadat je invoercellen of formules hebt gewijzigd, roep je [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) aan om ondersteunde formules opnieuw te berekenen en de bijbehorende celwaarden bij te werken.

Een berekende cel geeft nog steeds zijn resultaat weer via [IChartDataCell.getValue](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ichartdatacell/#getValue--). Dit is belangrijk wanneer je een formule‑resultaat in code moet inspecteren of de cel als diagramdatapunt wilt gebruiken.

## **Een Diagram maken en Werkbladformules Berekenen**

Het volgende voorbeeld demonstreert een end‑to‑end‑werkstroom. Het maakt een gegroepeerd kolomdiagram, wist de voorbeeldgegevens, schrijft kwartaalomzet‑ en kostenwaarden, berekent winst met formules, leest de resultaten, gebruikt de berekende cellen als diagramwaarden en slaat de presentatie op.

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

De diagramdatapunten verwijzen naar `D2:D4`, zodat het diagram de berekende winstwaarden gebruikt. Er is geen aparte diagram‑verversingsaanroep in deze werkstroom: bereken eerst de workbook, gebruik daarna of sla de diagramgegevens op die naar de berekende cellen wijzen.

## **Gebruik A1‑Stijl Formules**

A1‑notatie identificeert kolommen met letters en rijen met cijfers. Ken A1‑stijl uitdrukkingen toe via [IChartDataCell.setFormula](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-).

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

Veelvoorkomende A1‑referentievormen zijn:

| Referentie | Relatief | Absoluut | Gemengd |
|---|---|---|---|
| Cel | `A2` | `$A$2` | `A$2`, `$A2` |
| Rij | `2:2` | `$2:$2` | — |
| Kolom | `A:A` | `$A:$A` | — |
| Bereik | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

Relatieve referenties kunnen wijzigen wanneer een formule wordt verplaatst of gekopieerd door een spreadsheet‑applicatie. Absolute referenties houden beide coördinaten vast, terwijl gemengde referenties alleen een rij of een kolom fixeren.

## **Gebruik R1C1‑Stijl Formules**

R1C1‑notatie identificeert zowel rijen als kolommen numeriek. Relatieve referenties gebruiken offsets tussen vierkante haken. Ken deze syntaxis toe via [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-).

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

Veelvoorkomende R1C1‑referentievormen zijn:

| Referentie | Relatief | Absoluut | Gemengd |
|---|---|---|---|
| Cel | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| Rij | `R[2]` | `R2` | — |
| Kolom | `C[3]` | `C3` | — |
| Bereik | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

Bijvoorbeeld, in cel `D2` betekent `RC[-2]` de cel in dezelfde rij twee kolommen naar links (`B2`).

## **Formule‑Constanten en Operatoren**

De ingebouwde formule‑evaluator ondersteunt logische waarden, numerieke literalies, tekenreeksen, spreadsheet‑foutwaarden, rekenkundige operatoren en vergelijkingsoperatoren.

### **Constanten en Literalies**

| Type | Voorbeelden | Opmerkingen |
|---|---|---|
| Logisch | `TRUE`, `FALSE` | Kan rechtstreeks worden gebruikt in logische uitdrukkingen zoals `A2=TRUE`. |
| Numeriek | `1`, `0.5`, `.3`, `1E-2` | Gewone en wetenschappelijke notatie worden ondersteund. |
| Tekst | `"abc"`, `"2/3/2020 12:00"` | Tekst‑literalies staan tussen dubbele aanhalingstekens binnen de formule. |
| Foutresultaat | `#DIV/0!`, `#N/A`, `#REF!` | Een geldige formule kan een spreadsheet‑foutwaarde opleveren in plaats van een normaal resultaat. |

Dit voorbeeld gebruikt verschillende constanten:

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

    Object logicalValue = workbook.getCell(0, "B2").getValue(); // false
    Object numericValue = workbook.getCell(0, "C2").getValue(); // 1.5
    Object scientificValue = workbook.getCell(0, "D2").getValue(); // 0.003
    Object stringValue = workbook.getCell(0, "E2").getValue(); // abc
    Object errorValue = workbook.getCell(0, "F2").getValue(); // #DIV/0!
} finally {
    presentation.dispose();
}
```

### **Rekenkundige Operatoren**

| Operator | Betekenis | Voorbeeld |
|---|---|---|
| `+` | Optelling of eenheidsteken | `2+3` |
| `-` | Aftrekking of negatie | `2-3`, `-3` |
| `*` | Vermenigvuldiging | `2*3` |
| `/` | Deling | `2/3` |
| `%` | Procent | `30%` |
| `^` | Exponent | `2^3` |

Gebruik haakjes om de evaluatievolgorde expliciet te maken, bijvoorbeeld `(A2+B2)*C2`.

### **Vergelijkingsoperatoren**

Vergelijkings­expressies leveren logische waarden op.

| Operator | Betekenis | Voorbeeld |
|---|---|---|
| `=` | Gelijk aan | `A2=3` |
| `<>` | Niet gelijk aan | `A2<>3` |
| `>` | Groter dan | `A2>3` |
| `>=` | Groter dan of gelijk aan | `A2>=3` |
| `<` | Kleiner dan | `A2<3` |
| `<=` | Kleiner dan of gelijk aan | `A2<=3` |

## **Ondersteunde Vooraf Gedefinieerde Functies**

Aspose.Slides bevat een ingebouwde formule‑evaluator voor diagram‑werkbladen, maar het is geen volledige Excel‑rekenmachine. De gedocumenteerde functieset is beperkt tot de onderstaande functies. Ga er niet van uit dat een willekeurige Excel‑functie kan worden herberekend door [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ichartdataworkbook/#calculateFormulas--).

| Functie | Doel of ondersteunde vorm | Voorbeeld |
|---|---|---|
| `ABS` | Absolute waarde | `ABS(A2)` |
| `AVERAGE` | Gemiddelde | `AVERAGE(B2:B5)` |
| `CEILING` | Afronden naar boven op een veelvoud | `CEILING(A2,5)` |
| `CHOOSE` | Waarde selecteren op index | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | Tekstwaarden samenvoegen | `CONCAT(A2,B2)` |
| `CONCATENATE` | Tekstwaarden samenvoegen | `CONCATENATE(A2," ",B2)` |
| `DATE` | Datumelement maken met 1900‑datum­systeem | `DATE(2026,8,19)` |
| `DAYS` | Aantal dagen tussen datums | `DAYS(B2,A2)` |
| `FIND` | Eén tekstwaarde binnen een andere vinden | `FIND("-",A2)` |
| `FINDB` | Byte‑georiënteerd zoeken | `FINDB("a",A2)` |
| `IF` | Voorwaardelijk resultaat | `IF(A2>0,A2,0)` |
| `INDEX` | Referentie‑vorm | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | Vector‑vorm | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | Vector‑vorm | `MATCH(A2,B2:B5,0)` |
| `MAX` | Maximumwaarde | `MAX(B2:B5)` |
| `SUM` | Som van waarden | `SUM(B2:B5)` |
| `VLOOKUP` | Verticaal opzoeken | `VLOOKUP(A2,B2:D10,3,FALSE)` |

De beperkingen in de tabel zijn belangrijk: `INDEX` wordt gedocumenteerd in referentie‑vorm, terwijl `LOOKUP` en `MATCH` in hun vector‑vorm staan. `DATE` gebruikt het 1900‑datum­systeem. Functies die hier niet worden vermeld, moeten worden beschouwd als niet‑ondersteund door de Aspose.Slides‑formule‑evaluator, tenzij ze elders specifiek worden gedocumenteerd.

## **Hernieuw Berekening en Gecachete Waarden**

Spreadsheet‑bestanden slaan doorgaans zowel een formule als de laatst berekende waarde op. Aspose.Slides kan daarom een gecachete waarde lezen via [IChartDataCell.getValue](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ichartdatacell/#getValue--) wanneer een presentatie wordt geladen en de relevante diagramgegevens niet zijn gewijzigd.

Na het wijzigen van invoercellen of formules, moet je niet vertrouwen op een oude gecachete uitkomst. Roep [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) aan vóór het lezen van berekende waarden of het opslaan van diagramgegevens die erop leunen.

Voor formules buiten de ondersteunde subset kan Aspose.Slides de formule mogelijk niet parseren of de afhankelijkheden niet vaststellen. Als het workbook is gewijzigd, kan de vorige gecachete waarde niet langer als betrouwbaar worden beschouwd. In dat geval kan het lezen van de waarde van een cel met niet‑ondersteunde gegevens een [CellUnsupportedDataException](https://reference.aspose.com/slides/nl/java/com.aspose.slides/cellunsupporteddataexception/) veroorzaken.

Als je diagram afhankelijk is van Excel‑functies die Aspose.Slides niet evalueert, bereken die formules dan met een spreadsheet‑engine die ze ondersteunt en schrijf de resulterende waarden terug naar het diagram‑workbook. Vervang niet‑ondersteunde formules door geraden waarden.

## **Formule‑Fouten Afhandelen**

Er zijn twee verschillende soorten problemen.

Een formule kan geldig zijn maar een spreadsheet‑foutresultaat opleveren, zoals `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!` of `#VALUE!`. In dit geval is het fout‑token een celresultaat en kan het worden geretourneerd via [IChartDataCell.getValue](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ichartdatacell/#getValue--).

Een formule kan ook falen tijdens het parseren, bij referenties, afhankelijkheden of op het niveau van ondersteunde data. Aspose.Slides biedt spreadsheet‑specifieke uitzonderingen voor deze gevallen: [CellInvalidFormulaException](https://reference.aspose.com/slides/nl/java/com.aspose.slides/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/nl/java/com.aspose.slides/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/nl/java/com.aspose.slides/cellcircularreferenceexception/) en [CellUnsupportedDataException](https://reference.aspose.com/slides/nl/java/com.aspose.slides/cellunsupporteddataexception/).

Wanneer formules afkomstig zijn van sjablonen of gebruikersinvoer, behandel deze uitzonderingen rond herberekening en waarde‑toegang:

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

## **Praktische Beperkingen**

De formule‑ondersteuning in diagram‑werkbladen is bedoeld voor een gedefinieerde subset van spreadsheet‑berekeningen, niet voor volledige Excel‑compatibiliteit. Houd rekening met deze beperkingen bij het ontwerpen van een rapportage‑werkstroom:

- Gebruik alleen de gedocumenteerde constanten, operatoren, referenties en functies wanneer je Aspose.Slides wilt laten herberekenen.
- Herbereken na het wijzigen van cellen waarvan de formule‑resultaten afhangen.
- Beschouw gecachete waarden uit geladen presentaties als momentopnamen, niet als vervanging voor herberekening na bewerkingen.
- Test formules uit bestaande sjablonen voordat je vertrouwt op hun berekende waarden, vooral wanneer ze functies buiten de gedocumenteerde lijst gebruiken.
- Voor formules die een volledige spreadsheet‑rekenmachine vereisen, bereken ze extern en werk vervolgens het diagram‑workbook bij met de resulterende waarden.

## **FAQ**

**Wat is het verschil tussen [IChartDataCell.setFormula](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-) en [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-)?**

[IChartDataCell.setFormula](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-) slaat een A1‑stijl expressie op, bijvoorbeeld `B2-C2`. [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-) slaat een R1C1‑stijl expressie op, bijvoorbeeld `RC[-2]-RC[-1]`. Gebruik de notatie die het beste past bij hoe je formules genereert of kopieert.

**Moet ik de cel zelf of de waarde ervan lezen na berekening?**

[IChartDataWorkbook.getCell](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ichartdataworkbook/#getCell-int-java.lang.String-) geeft een [IChartDataCell](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ichartdatacell/) terug. Om het berekende resultaat te verkrijgen, roep je de [IChartDataCell.getValue](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ichartdatacell/#getValue--) methode van die cel aan na herberekening.

**Wanneer moet ik [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) aanroepen?**

Roep [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) aan nadat je invoerwaarden of formules hebt gewijzigd en voordat je afhankelijk bent van de berekende resultaten. Dit werkt de waarden van formules die de ingebouwde evaluator ondersteunt bij.

**Ondersteunt Aspose.Slides elke Excel‑functie?**

Nee. De ingebouwde evaluator ondersteunt een gedocumenteerde subset van functies. Functies buiten die subset moeten niet worden verondersteld correct te worden herberekend. Als volledige Excel‑formule‑compatibiliteit vereist is, voer dan de berekening uit met een geschikte spreadsheet‑engine en schrijf de eindwaarden naar het diagram‑workbook.

**Wat gebeurt er als een geladen presentatie een niet‑ondersteunde formule bevat?**

Als de diagramgegevens niet zijn gewijzigd, kan het workbook nog een eerder berekende gecachete waarde bevatten. Nadat gerelateerde data is aangepast, is die gecachete waarde mogelijk niet meer geldig. Het benaderen van een cel waarvan de formule niet kan worden verwerkt, kan een [CellUnsupportedDataException](https://reference.aspose.com/slides/nl/java/com.aspose.slides/cellunsupporteddataexception/) veroorzaken.

**Zijn formule‑foutwaarden hetzelfde als Java‑exceptions?**

Nee. Een resultaat zoals `#DIV/0!` is een spreadsheet‑waarde die voortkomt uit een geldige berekening. Exceptions zoals [CellInvalidFormulaException](https://reference.aspose.com/slides/nl/java/com.aspose.slides/cellinvalidformulaexception/) of [CellCircularReferenceException](https://reference.aspose.com/slides/nl/java/com.aspose.slides/cellcircularreferenceexception/) geven aan dat de formule niet normaal kan worden verwerkt.

**Werkt een diagram automatisch bij wanneer een formulecel verandert?**

Een diagramreeks kan naar workbook‑cellen verwijzen. Bereken eerst het workbook, sla vervolgens de presentatie op of render deze. Als de diagramdatapunten naar de berekende cellen verwijzen, gebruikt het diagram die bijgewerkte celwaarden; er is geen aparte diagram‑verversingsmethode nodig voor deze werkstroom.

**Kunnen diagrammen een extern Excel‑workbook gebruiken?**

Ja, diagramgegevens kunnen worden geconfigureerd om een extern workbook te gebruiken via de diagram‑data‑API. Het hier beschreven formule‑berekeningsproces heeft echter betrekking op het diagram‑data‑workbook en de door Aspose.Slides geëvalueerde formule‑subset. Ga er niet van uit dat [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) volledige herberekening van willekeurige formules in een extern XLSX‑bestand biedt.

**Kan ik formules gebruiken die naar een ander werkblad of workbook verwijzen?**

Excel‑stijl verwijzingen kunnen in diagram‑workbooks bestaan, maar de formule‑evaluatie is beperkt tot de ondersteunde parser en functieset. Als een cross‑sheet of externe verwijzing essentieel is, valideer dan de exacte formule met de versie van Aspose.Slides die je gebruikt. Voor werkstromen die brede Excel‑referentie‑compatibiliteit vereisen, bereken het workbook extern en schrijf de opgeloste waarden terug naar de diagramgegevens.

**Moeten formule‑strings beginnen met `=`?**

De Aspose.Slides‑API‑voorbeelden wijzen uitdrukkingen toe zoals `B2-C2` of `SUM(B2:B5)` zonder een leidende `=`. Het gebruik van die vorm houdt gegenereerde formules consistent met de gedocumenteerde API‑voorbeelden.
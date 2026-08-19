---
title: Formules voor diagram‑werkbladen toepassen in presentaties in PHP
linktitle: Werkbladformules
type: docs
weight: 70
url: /nl/php-java/chart-worksheet-formulas/
keywords:
- diagram‑spreadsheet
- diagram‑werkblad
- diagram‑formule
- werkbladformule
- spreadsheet‑formule
- diagram‑data‑werkboek
- formule‑berekening
- logische constante
- numerieke constante
- string‑constante
- fout‑constante
- rekenkundige operator
- vergelijkingsoperator
- A1‑stijl
- R1C1‑stijl
- voorgedefinieerde functie
- PowerPoint
- presentatie
- PHP
- Aspose.Slides
description: "Excel‑achtige formules toepassen in Aspose.Slides voor PHP via Java‑diagram‑werkbladen, waarden opnieuw berekenen en de resultaten gebruiken in PowerPoint‑diagrammen."
---
## **Overzicht**

PowerPoint-diagrammen slaan hun brongegevens meestal op in een ingebed werkblad. In Aspose.Slides voor PHP via Java kun je dat werkblad benaderen via het chart‑data‑workbook, invoerwaarden schrijven, formules aan cellen toewijzen, ondersteunde formules berekenen en de berekende cellen gebruiken als diagramgegevens.

Dit artikel legt de volledige formule‑workflow uit: maak een diagram, vul het werkblad, wijs A1‑stijl‑ of R1C1‑stijl‑formules toe, herschrijf ze, lees de berekende waarden, koppel die cellen aan een diagramserie en sla de presentatie op. Het beschrijft bovendien de ondersteunde formulesyntaxis, de ingebouwde functiebereik, gecachte waarden, niet‑ondersteunde formules en spreadsheet‑specifieke fouten.

## **Diagram‑werkbladen en formules**

Een diagram‑werkblad bevat de categorieën, serienaam en waarden die door een diagram worden gebruikt. In PowerPoint kun je het werkblad inspecteren door de diagram‑data‑editor te openen:

![PowerPoint-diagram met zijn ingebedde werkblad geopend, met categorie‑ en seriedata weergegeven](chart-worksheet-formulas_1.png)

In Aspose.Slides wordt het werkblad blootgesteld via de [ChartDataWorkbook](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartdataworkbook/)‑klasse. Gebruik [ChartDataCell::setFormula](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartdatacell/#setFormula) voor A1‑stijl formules en [ChartDataCell::setR1C1Formula](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartdatacell/#setR1C1Formula) voor R1C1‑stijl formules. Na het wijzigen van invoercellen of formules, roep [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartdataworkbook/#calculateFormulas) aan om ondersteunde formules opnieuw te berekenen en de bijbehorende celwaarden bij te werken.

Een berekende cel geeft nog steeds zijn resultaat weer via [ChartDataCell::getValue](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartdatacell/#getValue). Dit is belangrijk wanneer je een formule‑resultaat in code moet inspecteren of de cel als diagramdatumpunt wilt gebruiken.

## **Maak een diagram en bereken werkblad‑formules**

Het volgende voorbeeld toont een end‑to‑end workflow. Het maakt een gegroepeerd kolomdiagram, wist de voorbeelddata, schrijft kwartaalomzet‑ en kostenwaarden, berekent winst met formules, leest de resultaten, gebruikt de berekende cellen als diagramwaarden en slaat de presentatie op.

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 350);
    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $worksheetIndex = 0;

    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    $workbook->clear($worksheetIndex);

    $category1 = $workbook->getCell($worksheetIndex, "A2", "Q1");
    $category2 = $workbook->getCell($worksheetIndex, "A3", "Q2");
    $category3 = $workbook->getCell($worksheetIndex, "A4", "Q3");

    $workbook->getCell($worksheetIndex, "B1", "Revenue");
    $workbook->getCell($worksheetIndex, "C1", "Expenses");
    $workbook->getCell($worksheetIndex, "D1", "Profit");

    $workbook->getCell($worksheetIndex, "B2")->setValue(120.0);
    $workbook->getCell($worksheetIndex, "C2")->setValue(80.0);
    $workbook->getCell($worksheetIndex, "B3")->setValue(150.0);
    $workbook->getCell($worksheetIndex, "C3")->setValue(95.0);
    $workbook->getCell($worksheetIndex, "B4")->setValue(135.0);
    $workbook->getCell($worksheetIndex, "C4")->setValue(110.0);

    $profit1 = $workbook->getCell($worksheetIndex, "D2");
    $profit2 = $workbook->getCell($worksheetIndex, "D3");
    $profit3 = $workbook->getCell($worksheetIndex, "D4");

    $profit1->setFormula("B2-C2");
    $profit2->setFormula("B3-C3");
    $profit3->setFormula("B4-C4");

    $workbook->calculateFormulas();

    $q1Profit = java_values($profit1->getValue()); // 40
    $q2Profit = java_values($profit2->getValue()); // 55
    $q3Profit = java_values($profit3->getValue()); // 25

    echo "Q1 profit: " . $q1Profit . PHP_EOL;
    echo "Q2 profit: " . $q2Profit . PHP_EOL;
    echo "Q3 profit: " . $q3Profit . PHP_EOL;

    $chart->getChartData()->getCategories()->add($category1);
    $chart->getChartData()->getCategories()->add($category2);
    $chart->getChartData()->getCategories()->add($category3);

    $profitSeries = $chart->getChartData()->getSeries()->add($workbook->getCell($worksheetIndex, "D1"), $chart->getType());
    $profitSeries->getDataPoints()->addDataPointForBarSeries($profit1);
    $profitSeries->getDataPoints()->addDataPointForBarSeries($profit2);
    $profitSeries->getDataPoints()->addDataPointForBarSeries($profit3);
    $profitSeries->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);

    $presentation->save("chart-formulas.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

De diagramdatapunten refereren naar `D2:D4`, zodat het diagram de berekende winstwaarden gebruikt. Er is geen aparte diagram‑verversingsaanroep in deze workflow: bereken eerst het werkboek, gebruik of sla vervolgens de diagramdata op die naar de berekende cellen wijzen.

## **Gebruik A1‑stijl formules**

A1‑notatie identificeert kolommen met letters en rijen met cijfers. Wijs A1‑stijl‑expressies toe via [ChartDataCell::setFormula](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartdatacell/#setFormula).

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 500, 300);
    $workbook = $chart->getChartData()->getChartDataWorkbook();

    $workbook->getCell(0, "C3")->setValue(10);
    $workbook->getCell(0, "F2")->setValue(2);
    $workbook->getCell(0, "G2")->setValue(3);
    $workbook->getCell(0, "H2")->setValue(4);

    $cell = $workbook->getCell(0, "A2");
    $cell->setFormula("C3+SUM(F2:H2)");

    $workbook->calculateFormulas();

    $value = java_values($cell->getValue()); // 19
} finally {
    $presentation->dispose();
}
```

Veelvoorkomende A1‑referentie‑vormen zijn:

| Referentie | Relatief | Absoluut | Gemengd |
|---|---|---|---|
| Cel | `A2` | `$A$2` | `A$2`, `$A2` |
| Rij | `2:2` | `$2:$2` | — |
| Kolom | `A:A` | `$A:$A` | — |
| Bereik | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

Relatieve referenties kunnen wijzigen wanneer een formule wordt verplaatst of gekopieerd door een spreadsheet‑applicatie. Absolute referenties houden beide coördinaten vast, terwijl gemengde referenties alleen een rij of een kolom vastzetten.

## **Gebruik R1C1‑stijl formules**

R1C1‑notatie identificeert zowel rijen als kolommen numeriek. Relatieve referenties gebruiken offset‑waarden tussen vierkante haakjes. Wijs deze syntaxis toe via [ChartDataCell::setR1C1Formula](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartdatacell/#setR1C1Formula).

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 500, 300);
    $workbook = $chart->getChartData()->getChartDataWorkbook();

    $workbook->getCell(0, "B2")->setValue(12);
    $workbook->getCell(0, "C2")->setValue(5);

    $cell = $workbook->getCell(0, "D2");
    $cell->setR1C1Formula("RC[-2]-RC[-1]");

    $workbook->calculateFormulas();

    $value = java_values($cell->getValue()); // 7
} finally {
    $presentation->dispose();
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

De ingebouwde formule‑evaluator ondersteunt logische waarden, numerieke literalwaarden, strings, spreadsheet‑foutwaarden, rekenkundige operatoren en vergelijkingsoperatoren.

### **Constanten en literalwaarden**

| Type | Voorbeelden | Notities |
|---|---|---|
| Logisch | `TRUE`, `FALSE` | Kan rechtstreeks in logische expressies worden gebruikt, zoals `A2=TRUE`. |
| Numeriek | `1`, `0.5`, `.3`, `1E-2` | Gewone en wetenschappelijke notatie worden ondersteund. |
| String | `"abc"`, `"2/3/2020 12:00"` | Tekst‑literalwaarden staan tussen dubbele aanhalingstekens in de formule. |
| Foutresultaat | `#DIV/0!`, `#N/A`, `#REF!` | Een geldige formule kan evalueren tot een spreadsheet‑foutwaarde in plaats van een normaal resultaat. |

Dit voorbeeld gebruikt verschillende constante‑typen:

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 500, 300);
    $workbook = $chart->getChartData()->getChartDataWorkbook();

    $workbook->getCell(0, "A2")->setValue(false);
    $workbook->getCell(0, "B2")->setFormula("A2=TRUE");
    $workbook->getCell(0, "C2")->setFormula("1+0.5");
    $workbook->getCell(0, "D2")->setFormula(".3*1E-2");
    $workbook->getCell(0, "E2")->setFormula("\"abc\"");
    $workbook->getCell(0, "F2")->setFormula("2/0");

    $workbook->calculateFormulas();

    $logicalValue = java_values($workbook->getCell(0, "B2")->getValue()); // false
    $numericValue = java_values($workbook->getCell(0, "C2")->getValue()); // 1.5
    $scientificValue = java_values($workbook->getCell(0, "D2")->getValue()); // 0.003
    $stringValue = java_values($workbook->getCell(0, "E2")->getValue()); // abc
    $errorValue = java_values($workbook->getCell(0, "F2")->getValue()); // #DIV/0!
} finally {
    $presentation->dispose();
}
```

### **Rekenkundige operatoren**

| Operator | Betekenis | Voorbeeld |
|---|---|---|
| `+` | Optelling of unaire plus | `2+3` |
| `-` | Aftrekking of negatie | `2-3`, `-3` |
| `*` | Vermenigvuldiging | `2*3` |
| `/` | Deling | `2/3` |
| `%` | Percentage | `30%` |
| `^` | Machtsverheffing | `2^3` |

Gebruik haakjes om de volgorde van evaluatie expliciet te maken, bijvoorbeeld `(A2+B2)*C2`.

### **Vergelijkingsoperatoren**

Vergelijkings‑expressies geven logische waarden terug.

| Operator | Betekenis | Voorbeeld |
|---|---|---|
| `=` | Gelijk aan | `A2=3` |
| `<>` | Niet gelijk aan | `A2<>3` |
| `>` | Groter dan | `A2>3` |
| `>=` | Groter dan of gelijk aan | `A2>=3` |
| `<` | Kleiner dan | `A2<3` |
| `<=` | Kleiner dan of gelijk aan | `A2<=3` |

## **Ondersteunde vooraf gedefinieerde functies**

Aspose.Slides bevat een ingebouwde formule‑evaluator voor diagram‑werkbladen, maar het is geen volledige Excel‑rekenmachine. De gedocumenteerde functieset is beperkt tot de functies hieronder. Ga er niet van uit dat een willekeurige Excel‑functie kan worden herberekend door [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartdataworkbook/#calculateFormulas).

| Functie | Doel of ondersteunde vorm | Voorbeeld |
|---|---|---|
| `ABS` | Absolute waarde | `ABS(A2)` |
| `AVERAGE` | Rekenkundig gemiddelde | `AVERAGE(B2:B5)` |
| `CEILING` | Rond een getal omhoog af naar een veelvoud | `CEILING(A2,5)` |
| `CHOOSE` | Selecteer een waarde op index | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | Voeg tekstwaarden samen | `CONCAT(A2,B2)` |
| `CONCATENATE` | Voeg tekstwaarden samen | `CONCATENATE(A2," ",B2)` |
| `DATE` | Maak een datumwaarde met het 1900‑datumsysteem | `DATE(2026,8,19)` |
| `DAYS` | Retourneer het aantal dagen tussen data | `DAYS(B2,A2)` |
| `FIND` | Zoek een tekstwaarde in een andere | `FIND("-",A2)` |
| `FINDB` | Byte‑georiënteerd tekst zoeken | `FINDB("a",A2)` |
| `IF` | Voorwaardelijk resultaat | `IF(A2>0,A2,0)` |
| `INDEX` | Referentie‑vorm | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | Vector‑vorm | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | Vector‑vorm | `MATCH(A2,B2:B5,0)` |
| `MAX` | Maximale waarde | `MAX(B2:B5)` |
| `SUM` | Som van waarden | `SUM(B2:B5)` |
| `VLOOKUP` | Verticaal zoeken | `VLOOKUP(A2,B2:D10,3,FALSE)` |

De beperkingen in de tabel zijn belangrijk: `INDEX` wordt gedocumenteerd in referentie‑vorm, terwijl `LOOKUP` en `MATCH` in hun vector‑vormen staan. `DATE` gebruikt het 1900‑datumsysteem. Functies die hier niet vermeld staan, moeten worden beschouwd als niet‑ondersteund door de Aspose.Slides‑formule‑evaluator tenzij ze apart gedocumenteerd zijn.

## **Herberekenen en gecachte waarden**

Spreadsheet‑bestanden slaan doorgaans zowel een formule als de laatst berekende waarde op. Aspose.Slides kan daarom een gecachte waarde lezen via [ChartDataCell::getValue](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartdatacell/#getValue) wanneer een presentatie wordt geladen en de relevante diagramdata niet is gewijzigd.

Na het wijzigen van invoercellen of formules, vertrouw niet op een oude gecachte uitkomst. Roep [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartdataworkbook/#calculateFormulas) aan vóór het lezen van berekende waarden of het opslaan van diagramdata die ervan afhankelijk is.

Voor formules buiten de ondersteunde subset kan Aspose.Slides de formule mogelijk niet parseren of de afhankelijkheden niet bepalen. Als het werkboek is aangepast, kan de vorige gecachte waarde niet langer als betrouwbaar worden beschouwd. In dat geval kan het lezen van een cel met niet‑ondersteunde data een [CellUnsupportedDataException](https://reference.aspose.com/slides/nl/php-java/aspose.slides/cellunsupporteddataexception/) veroorzaken.

Als je diagram afhankelijk is van Excel‑functies die Aspose.Slides niet evalueert, bereken die formules met een spreadsheet‑engine die ze ondersteunt en schrijf de resulterende waarden terug naar het diagram‑werkboek. Vervang niet‑ondersteunde formules niet door geraden waarden.

## **Afhandelen van formule‑fouten**

Er zijn twee verschillende soorten problemen te onderscheiden.

Een formule kan geldig zijn maar een spreadsheet‑foutresultaat opleveren, zoals `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!` of `#VALUE!`. In dat geval is het fout‑token een celresultaat en kan het worden geretourneerd via [ChartDataCell::getValue](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartdatacell/#getValue).

Een formule kan ook falen tijdens het parseren, bij referenties, afhankelijkheden of omdat de data niet wordt ondersteund. Aspose.Slides biedt spreadsheet‑specifieke uitzonderingen voor deze gevallen: [CellInvalidFormulaException](https://reference.aspose.com/slides/nl/php-java/aspose.slides/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/nl/php-java/aspose.slides/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/nl/php-java/aspose.slides/cellcircularreferenceexception/) en [CellUnsupportedDataException](https://reference.aspose.com/slides/nl/php-java/aspose.slides/cellunsupporteddataexception/).

In PHP via Java worden Java‑uitzonderingen via `JavaException` zichtbaar gemaakt. Wanneer formules uit sjablonen of van gebruikers komen, bewaar ze rond herberekening en waarde‑toegang. De Java‑uitzondering die in de stack‑trace wordt gerapporteerd, identificeert de specifieke spreadsheet‑fout:

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 500, 300);
    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $cell = $workbook->getCell(0, "A2");
    $cell->setFormula("SUM(B2:B5)");

    try {
        $workbook->calculateFormulas();
        echo java_values($cell->getValue()) . PHP_EOL;
    } catch (JavaException $ex) {
        $ex->printStackTrace();
    }
} finally {
    $presentation->dispose();
}
```

## **Praktische beperkingen**

De formule‑ondersteuning in diagram‑werkbladen is bedoeld voor een gedefinieerde subset van spreadsheet‑berekeningen, niet voor volledige Excel‑compatibiliteit. Houd deze beperkingen in gedachten bij het ontwerpen van een rapportage‑workflow:

- Gebruik alleen de gedocumenteerde constanten, operatoren, referenties en functies wanneer je wilt dat Aspose.Slides formules herberekent.
- Herbereken na het wijzigen van cellen waarvan de formule‑resultaten afhankelijk zijn.
- Beschouw gecachte waarden uit geladen presentaties als momentopnames, niet als vervanging voor herberekening na bewerkingen.
- Test formules uit bestaande sjablonen voordat je vertrouwt op hun berekende waarden, vooral wanneer ze functies buiten de gedocumenteerde lijst gebruiken.
- Voor formules die een volledige spreadsheet‑rekenmachine vereisen, bereken ze extern en werk vervolgens het diagram‑werkboek bij met de resulterende waarden.

## **FAQ**

**Wat is het verschil tussen [ChartDataCell::setFormula](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartdatacell/#setFormula) en [ChartDataCell::setR1C1Formula](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartdatacell/#setR1C1Formula)?**

[ChartDataCell::setFormula](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartdatacell/#setFormula) slaat een A1‑stijl‑expressie op, zoals `B2-C2`. [ChartDataCell::setR1C1Formula](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartdatacell/#setR1C1Formula) slaat een R1C1‑stijl‑expressie op, zoals `RC[-2]-RC[-1]`. Gebruik de notatie die het beste past bij hoe je formules genereert of kopieert.

**Moet ik de cel zelf of de waarde lezen na berekening?**

[ChartDataWorkbook::getCell](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartdataworkbook/#getCell) retourneert een [ChartDataCell](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartdatacell/). Om het berekende resultaat te verkrijgen, roep je de [ChartDataCell::getValue](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartdatacell/#getValue)‑methode van die cel aan na herberekening.

**Wanneer moet ik [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartdataworkbook/#calculateFormulas) aanroepen?**

Roep [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartdataworkbook/#calculateFormulas) aan nadat je invoerwaarden of formules hebt gewijzigd en voordat je afhankelijk bent van de berekende resultaten. Dit werkt de waarden van de formules die de ingebouwde evaluator ondersteunt bij.

**Ondersteunt Aspose.Slides elke Excel‑functie?**

Nee. De ingebouwde evaluator ondersteunt een gedocumenteerde subset van functies. Functies buiten die subset moeten niet worden verondersteld correct te worden herberekend. Als volledige Excel‑formule‑compatibiliteit vereist is, voer je de berekening uit met een geschikte spreadsheet‑engine en schrijf je de uiteindelijke waarden naar het diagram‑werkboek.

**Wat gebeurt er als een geladen presentatie een niet‑ondersteunde formule bevat?**

Als de diagramdata niet is gewijzigd, kan het werkboek nog steeds een eerder berekende gecachte waarde bevatten. Nadat gerelateerde data is aangepast, kan die gecachte waarde ongeldig zijn. Het benaderen van een cel waarvan de formule niet kan worden verwerkt, kan een [CellUnsupportedDataException](https://reference.aspose.com/slides/nl/php-java/aspose.slides/cellunsupporteddataexception/) veroorzaken.

**Zijn formule‑foutwaarden hetzelfde als PHP‑uitzonderingen?**

Nee. Een resultaat zoals `#DIV/0!` is een spreadsheet‑waarde die voortkomt uit een geldige berekening. Fouten bij het verwerken van een spreadsheet, zoals [CellInvalidFormulaException](https://reference.aspose.com/slides/nl/php-java/aspose.slides/cellinvalidformulaexception/) of [CellCircularReferenceException](https://reference.aspose.com/slides/nl/php-java/aspose.slides/cellcircularreferenceexception/), zijn Java‑uitzonderingen die via `JavaException` naar PHP worden geprojecteerd.

**Vernieuwt een diagram automatisch wanneer een formulecel verandert?**

Een diagramserie kan naar werkboekcellen refereren. Bereken eerst het werkboek, sla daarna de presentatie op of render deze. Als de diagramdatapunten naar de berekende cellen verwijzen, gebruikt het diagram die bijgewerkte celwaarden; er is geen aparte diagram‑verversingsmethode nodig voor deze workflow.

**Kunnen diagrammen een extern Excel‑werkboek gebruiken?**

Ja, diagramdata kan worden geconfigureerd om een extern werkboek te gebruiken via de diagram‑data‑API. Echter, de formule‑berekeningsworkflow die in dit artikel wordt beschreven, heeft betrekking op het diagram‑werkboek en de formule‑subset die door Aspose.Slides wordt geëvalueerd. Ga er niet van uit dat [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartdataworkbook/#calculateFormulas) volledige herberekening van willekeurige formules in een extern XLSX‑bestand biedt.

**Kan ik formules gebruiken die naar een ander werkblad of werkboek verwijzen?**

Excel‑achtige referenties kunnen in diagram‑werkboeken voorkomen, maar formule‑evaluatie is beperkt tot de ondersteunde parser en functiebereik. Als een cross‑sheet‑ of externe referentie essentieel is, valideer dan die exacte formule met jouw specifieke Aspose.Slides‑versie. Voor workflows die brede Excel‑referentie‑compatibiliteit vereisen, bereken het werkboek extern en schrijf de opgeloste waarden terug naar de diagramdata.

**Moeten formule‑strings beginnen met `=`?**

De Aspose.Slides‑API‑voorbeelden wijzen expressies toe zoals `B2-C2` of `SUM(B2:B5)` zonder een leidend `=`. Het gebruik van die vorm houdt de gegenereerde formules consistent met de gedocumenteerde API‑voorbeelden.
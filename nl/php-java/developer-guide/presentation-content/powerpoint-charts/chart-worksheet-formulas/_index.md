---
title: Formules voor diagramwerkbladen toepassen in presentaties in PHP
linktitle: Werkbladformules
type: docs
weight: 70
url: /nl/php-java/chart-worksheet-formulas/
keywords:
- grafiek spreadsheet
- diagram werkblad
- diagramformule
- werkbladformule
- spreadsheetformule
- diagramdataboek
- formuleberekening
- voorkeurscultuur
- cultuurspecifieke formule
- DBCS
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
- PHP
- Aspose.Slides
description: "Excel-achtige formules toepassen in Aspose.Slides voor PHP via Java-diagramwerkbladen, waarden opnieuw berekenen en de resultaten gebruiken in PowerPoint-diagrammen."
---
## **Overzicht**

PowerPoint‑diagrammen slaan hun brongegevens meestal op in een ingesloten werkblad. In Aspose.Slides voor PHP via Java kun je dat werkblad benaderen via de diagram‑databoek, invoerwaarden schrijven, formules toewijzen aan cellen, ondersteunde formules berekenen en de berekende cellen gebruiken als diagramgegevens.

Dit artikel legt de volledige formule‑werkstroom uit: een diagram maken, het werkblad vullen, A1‑stijl‑ of R1C1‑stijl‑formules toewijzen, ze opnieuw berekenen, de berekende waarden lezen, die cellen verbinden met een diagramreeks en de presentatie opslaan. Het beschrijft ook de ondersteunde formulesyntaxis, de ingebouwde functiebasis, gecachete waarden, niet‑ondersteunde formules en spreadsheet‑specifieke fouten.

## **Diagram‑werkbladen en formules**

Een diagram‑werkblad bevat de categorieën, reeksnamen en waarden die door een diagram worden gebruikt. In PowerPoint kun je het werkblad inspecteren door de diagram‑gegevenseditor te openen:

![PowerPoint‑diagram met zijn ingesloten werkblad geopend, met categorie‑ en reeksen‑gegevens weergegeven](chart-worksheet-formulas_1.png)

In Aspose.Slides wordt het werkblad blootgesteld via de [ChartDataWorkbook](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartdataworkbook/)‑klasse. Gebruik [ChartDataCell::setFormula](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartdatacell/#setFormula) voor A1‑stijlformules en [ChartDataCell::setR1C1Formula](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartdatacell/#setR1C1Formula) voor R1C1‑stijlformules. Na het wijzigen van invoercellen of formules roep je [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartdataworkbook/#calculateFormulas) aan om ondersteunde formules opnieuw te berekenen en de overeenkomstige celwaarden bij te werken.

Een berekende cel geeft nog steeds zijn resultaat weer via [ChartDataCell::getValue](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartdatacell/#getValue). Dit is belangrijk wanneer je een formuleresultaat in code moet inspecteren of de cel als diagramdatapunt wilt gebruiken.

## **Maak een diagram en bereken werkbladformules**

Het volgende voorbeeld toont een volledige werkstroom. Het maakt een gegroepeerd kolomdiagram, wist de voorbeeldgegevens, schrijft kwartaalomzet‑ en kostenwaarden, berekent winst met formules, leest de resultaten, gebruikt de berekende cellen als diagramwaarden en slaat de presentatie op.

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

De diagramdatapunten verwijzen naar `D2:D4`, zodat het diagram de berekende winstwaarden gebruikt. Er is geen aparte diagram‑verversingsaanroep in deze werkstroom: bereken eerst het werkboek, gebruik of sla vervolgens de diagramgegevens op die naar de berekende cellen wijzen.

## **Gebruik A1‑stijlformules**

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

Veelvoorkomende A1‑referentie­vormen zijn:

| Referentie | Relatief | Absoluut | Gemengd |
|---|---|---|---|
| Cel | `A2` | `$A$2` | `A$2`, `$A2` |
| Rij | `2:2` | `$2:$2` | — |
| Kolom | `A:A` | `$A:$A` | — |
| Bereik | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

Relatieve verwijzingen kunnen wijzigen wanneer een formule wordt verplaatst of gekopieerd door een spreadsheet‑applicatie. Absolute verwijzingen houden beide coördinaten vast, terwijl gemengde verwijzingen alleen een rij of een kolom vastzetten.

## **Gebruik R1C1‑stijlformules**

R1C1‑notatie identificeert zowel rijen als kolommen numeriek. Relatieve verwijzingen gebruiken offset‑notaties tussen vierkante haakjes. Wijs deze syntaxis toe via [ChartDataCell::setR1C1Formula](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartdatacell/#setR1C1Formula).

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

Veelvoorkomende R1C1‑referentie­vormen zijn:

| Referentie | Relatief | Absoluut | Gemengd |
|---|---|---|---|
| Cel | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| Rij | `R[2]` | `R2` | — |
| Kolom | `C[3]` | `C3` | — |
| Bereik | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

Bijvoorbeeld, in cel `D2` betekent `RC[-2]` de cel in dezelfde rij twee kolommen naar links (`B2`).

## **Formule‑constanten en‑operatoren**

De ingebouwde formule‑evaluator ondersteunt logische waarden, numerieke literals, tekenreeksen, spreadsheet‑foutwaarden, rekenkundige operatoren en vergelijking­operatoren.

### **Constanten en literals**

| Type | Voorbeelden | Opmerkingen |
|---|---|---|
| Logisch | `TRUE`, `FALSE` | Kan direct worden gebruikt in logische uitdrukkingen zoals `A2=TRUE`. |
| Numeriek | `1`, `0.5`, `.3`, `1E-2` | Gewone en wetenschappelijke notaties worden ondersteund. |
| Tekst | `"abc"`, `"2/3/2020 12:00"` | Tekst‑literals staan tussen dubbele aanhalingstekens binnen de formule. |
| Foutresultaat | `#DIV/0!`, `#N/A`, `#REF!` | Een geldige formule kan evalueren tot een spreadsheet‑foutwaarde i.p.v. een normaal resultaat. |

Dit voorbeeld gebruikt verschillende constant‑typen:

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

    $logicalValue = java_values($workbook->getCell(0, "B2")->getValue()); // onwaar
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
| `+` | Optelling of unair plus | `2+3` |
| `-` | Aftrekking of negatie | `2-3`, `-3` |
| `*` | Vermenigvuldiging | `2*3` |
| `/` | Deling | `2/3` |
| `%` | Percentage | `30%` |
| `^` | Machtsverheffing | `2^3` |

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

## **Ondersteunde vooraf gedefinieerde functies**

Aspose.Slides bevat een ingebouwde formule‑evaluator voor diagram‑werkbladen, maar het is geen volledige Excel‑rekenmachine. De gedocumenteerde functiebasis is beperkt tot de onderstaande functies. Ga er niet van uit dat een willekeurige Excel‑functie kan worden herberekend via [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartdataworkbook/#calculateFormulas).

| Functie | Doel of ondersteunde vorm | Voorbeeld |
|---|---|---|
| `ABS` | Absolute waarde | `ABS(A2)` |
| `AVERAGE` | Rekenkundig gemiddelde | `AVERAGE(B2:B5)` |
| `CEILING` | Afronden naar boven op een veelvoud | `CEILING(A2,5)` |
| `CHOOSE` | Waarde selecteren op index | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | Tekstwaarden samenvoegen | `CONCAT(A2,B2)` |
| `CONCATENATE` | Tekstwaarden samenvoegen | `CONCATENATE(A2," ",B2)` |
| `DATE` | Datumwaarde aanmaken met 1900‑datumstelsel | `DATE(2026,8,19)` |
| `DAYS` | Aantal dagen tussen data | `DAYS(B2,A2)` |
| `FIND` | Een tekstwaarde in een andere zoeken | `FIND("-",A2)` |
| `FINDB` | Byte‑georiënteerd zoeken | `FINDB("a",A2)` |
| `IF` | Conditionele uitkomst | `IF(A2>0,A2,0)` |
| `INDEX` | Referentie‑vorm | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | Vector‑vorm | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | Vector‑vorm | `MATCH(A2,B2:B5,0)` |
| `MAX` | Maximumwaarde | `MAX(B2:B5)` |
| `SUM` | Som van waarden | `SUM(B2:B5)` |
| `VLOOKUP` | Verticaal zoeken | `VLOOKUP(A2,B2:D10,3,FALSE)` |

De beperkingen in de tabel zijn belangrijk: `INDEX` wordt gedocumenteerd in referentie‑vorm, terwijl `LOOKUP` en `MATCH` in hun vector‑vormen staan. `DATE` gebruikt het 1900‑datumstelsel. Functies die hier niet staan, moeten als niet‑ondersteund worden beschouwd door de Aspose.Slides‑formule‑evaluator, tenzij afzonderlijk gedocumenteerd.

## **Formules berekenen met een voorkeurscultuur**

Sommige formules in een diagram‑werkboek interpreteren tekst volgens cultuur‑specifieke regels. Dit is vooral relevant voor functies bedoeld voor talen die dubbel‑byte‑karaktersets (DBCS) gebruiken. Om zulke formules correct te berekenen, maak je een [LoadOptions](https://reference.aspose.com/slides/nl/php-java/aspose.slides/loadoptions/), stel je de voorkeurscultuur in met [SpreadsheetOptions::setPreferredCulture](https://reference.aspose.com/slides/nl/php-java/aspose.slides/spreadsheetoptions/#setPreferredCulture), wijs je de spreadsheet‑opties toe via [LoadOptions::setSpreadsheetOptions](https://reference.aspose.com/slides/nl/php-java/aspose.slides/loadoptions/#setSpreadsheetOptions) en laad je vervolgens de presentatie.

Het volgende voorbeeld selecteert de Japanse cultuur, opent een presentatie met de geconfigureerde laadopties en roept [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartdataworkbook/#calculateFormulas) aan voor elk diagram‑werkboek:

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\SpreadsheetOptions;

$japaneseCulture = new Java("java.util.Locale", "ja", "JP");

$spreadsheetOptions = new SpreadsheetOptions();
$spreadsheetOptions->setPreferredCulture($japaneseCulture);

$loadOptions = new LoadOptions();
$loadOptions->setSpreadsheetOptions($spreadsheetOptions);

$chartClass = new JavaClass("com.aspose.slides.IChart");
$presentation = new Presentation("presentation.pptx", $loadOptions);
try {
    $slideCount = java_values($presentation->getSlides()->size());
    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $shapeCount = java_values($slide->getShapes()->size());
        for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
            $shape = $slide->getShapes()->get_Item($shapeIndex);
            if (java_instanceof($shape, $chartClass)) {
                $shape->getChartData()->getChartDataWorkbook()->calculateFormulas();
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

De voorkeurscultuur maakt deel uit van de laadsconfiguratie, dus specificeer deze vóór het aanmaken van de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/)‑instantie. Gebruik de cultuur die de werkboek‑formules verwachten; bijvoorbeeld `ja-JP` voor formules die Japans DBCS‑calculatieregels volgen.

## **Herberekening en gecachete waarden**

Spreadsheet‑bestanden slaan meestal zowel een formule als de laatst berekende waarde op. Aspose.Slides kan daarom een gecachete waarde lezen via [ChartDataCell::getValue](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartdatacell/#getValue) wanneer een presentatie wordt geladen en de betreffende diagramgegevens niet zijn gewijzigd.

Na het wijzigen van invoercellen of formules moet je niet vertrouwen op een oude gecachete uitkomst. Roep [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartdataworkbook/#calculateFormulas) aan vóór het lezen van berekende waarden of het opslaan van diagramgegevens die ervan afhankelijk zijn.

Voor formules buiten de ondersteunde subset kan Aspose.Slides de formule niet parseren of de afhankelijkheden niet bepalen. Als het werkboek is gewijzigd, is de vorige gecachete waarde niet langer betrouwbaar. In dat geval kan het lezen van een cel met niet‑ondersteunde data een [CellUnsupportedDataException](https://reference.aspose.com/slides/nl/php-java/aspose.slides/cellunsupporteddataexception/) veroorzaken.

Als je diagram afhankelijk is van Excel‑functies die Aspose.Slides niet evalueert, bereken die formules dan met een spreadsheet‑engine die ze ondersteunt en schrijf de resulterende waarden terug naar het diagram‑werkboek. Vervang niet‑ondersteunde formules door geschatte waarden.

## **Foutafhandeling voor formules**

Er zijn twee verschillende soorten problemen te onderscheiden.

Een formule kan geldig zijn maar een spreadsheet‑foutresultaat opleveren, zoals `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!` of `#VALUE!`. In dat geval is het fout‑token een cel‑resultaat en kan het worden geretourneerd via [ChartDataCell::getValue](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartdatacell/#getValue).

Een formule kan ook falen tijdens het parseren, de referentie, afhankelijkheid of gegevens‑ondersteuning. Aspose.Slides levert spreadsheet‑specifieke uitzonderingen voor deze gevallen: [CellInvalidFormulaException](https://reference.aspose.com/slides/nl/php-java/aspose.slides/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/nl/php-java/aspose.slides/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/nl/php-java/aspose.slides/cellcircularreferenceexception/) en [CellUnsupportedDataException](https://reference.aspose.com/slides/nl/php-java/aspose.slides/cellunsupporteddataexception/).

In PHP via Java worden Java‑uitzonderingen weggestuurd via `JavaException`. Wanneer formules afkomstig zijn van sjablonen of gebruikersinvoer, behandel ze dan rond herberekening en waarde‑toegang. De Java‑uitzondering die in de stack‑trace wordt gerapporteerd, identificeert de specifieke spreadsheet‑fout:

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
- Herbereken nadat je cellen hebt gewijzigd waarvan de formule‑resultaten afhankelijk zijn.
- Beschouw gecachete waarden uit geladen presentaties als momentopnames, niet als vervanging voor herberekening na bewerkingen.
- Test formules uit bestaande sjablonen voordat je vertrouwt op hun berekende waarden, vooral wanneer ze functies buiten de gedocumenteerde lijst gebruiken.
- Voor formules die een volledige spreadsheet‑rekenmachine nodig hebben, bereken ze extern en werk daarna het diagram‑werkboek bij met de resulterende waarden.

## **FAQ**

**Wat is het verschil tussen [ChartDataCell::setFormula](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartdatacell/#setFormula) en [ChartDataCell::setR1C1Formula](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartdatacell/#setR1C1Formula)?**

[ChartDataCell::setFormula](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartdatacell/#setFormula) slaat een A1‑stijl‑expressie op, bijvoorbeeld `B2-C2`. [ChartDataCell::setR1C1Formula](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartdatacell/#setR1C1Formula) slaat een R1C1‑stijl‑expressie op, bijvoorbeeld `RC[-2]-RC[-1]`. Gebruik de notatie die het beste past bij hoe je formules genereert of kopieert.

**Moet ik de cel zelf lezen of de waarde ervan na berekening?**

[ChartDataWorkbook::getCell](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartdataworkbook/#getCell) retourneert een [ChartDataCell](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartdatacell/). Om het berekende resultaat te verkrijgen, roep je de methode [ChartDataCell::getValue](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartdatacell/#getValue) van die cel aan na herberekening.

**Wanneer moet ik [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartdataworkbook/#calculateFormulas) aanroepen?**

Roep [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartdataworkbook/#calculateFormulas) aan nadat je invoerwaarden of formules hebt gewijzigd en voordat je afhankelijk bent van de berekende resultaten. Dit werkt de waarden van formules die de ingebouwde evaluator ondersteunt bij.

**Ondersteunt Aspose.Slides elke Excel‑functie?**

Nee. De ingebouwde evaluator ondersteunt alleen een gedocumenteerde subset van functies. Functies buiten die subset mogen niet worden verondersteld correct te worden herberekend. Als volledige Excel‑formule‑compatibiliteit vereist is, voer dan de berekening uit met een geschikte spreadsheet‑engine en schrijf de eindwaarden naar het diagram‑werkboek.

**Wat gebeurt er als een geladen presentatie een niet‑ondersteunde formule bevat?**

Als de diagram‑gegevens niet zijn gewijzigd, kan het werkboek nog steeds een eerder berekende gecachete waarde bevatten. Nadat gerelateerde gegevens zijn aangepast, is die gecachete waarde mogelijk niet meer geldig. Het benaderen van een cel waarvan de formule niet kan worden verwerkt, kan een [CellUnsupportedDataException](https://reference.aspose.com/slides/nl/php-java/aspose.slides/cellunsupporteddataexception/) veroorzaken.

**Zijn foutwaarden van formules hetzelfde als PHP‑uitzonderingen?**

Nee. Een resultaat zoals `#DIV/0!` is een spreadsheet‑waarde die ontstaat bij een geldige berekening. Falende spreadsheet‑verwerking, zoals [CellInvalidFormulaException](https://reference.aspose.com/slides/nl/php-java/aspose.slides/cellinvalidformulaexception/) of [CellCircularReferenceException](https://reference.aspose.com/slides/nl/php-java/aspose.slides/cellcircularreferenceexception/), zijn Java‑uitzonderingen die via `JavaException` naar PHP worden doorgegeven.

**Wordt een diagram automatisch bijgewerkt wanneer een formulecel verandert?**

Een diagramreeks kan verwijzen naar werkboekcellen. Herbereken eerst het werkboek en sla vervolgens de presentatie op of render deze. Als de diagramdatapunten naar de berekende cellen verwijzen, gebruikt het diagram de bijgewerkte waarden; een aparte diagram‑verversingsmethode is voor deze werkstroom niet nodig.

**Kunnen diagrammen een extern Excel‑werkboek gebruiken?**

Ja, diagramgegevens kunnen worden geconfigureerd om een extern werkboek te gebruiken via de diagram‑data‑API. Het formule‑berekeningsproces dat in dit artikel wordt beschreven, heeft echter alleen betrekking op het diagram‑werkboek en de formule‑subset die door Aspose.Slides wordt geëvalueerd. Ga er niet van uit dat [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartdataworkbook/#calculateFormulas) volledige herberekening van willekeurige formules in een extern XLSX‑bestand biedt.

**Kan ik formules gebruiken die naar een ander werkblad of werkboek verwijzen?**

Excel‑stijl‑verwijzingen kunnen in diagram‑werkboeken voorkomen, maar de evaluatie is beperkt tot de ondersteunde parser en functiebasis. Als een cross‑sheet‑ of externe verwijzing essentieel is, controleer dan of de exacte formule met jouw doel‑Aspose.Slides‑versie werkt. Voor workflows die brede Excel‑referentie‑compatibiliteit vereisen, bereken het werkboek extern en schrijf de opgeloste waarden terug naar de diagramgegevens.

**Moeten formulestringen beginnen met `=`?**

De Aspose.Slides‑API‑voorbeelden stellen uitdrukkingen zoals `B2-C2` of `SUM(B2:B5)` zonder leidende `=` in. Het gebruik van die vorm houdt de gegenereerde formules consistent met de gedocumenteerde API‑voorbeelden.
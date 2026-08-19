---
title: Använd diagramarbetsbladsformler i presentationer i PHP
linktitle: Arbetsbladsformler
type: docs
weight: 70
url: /sv/php-java/chart-worksheet-formulas/
keywords:
- diagramkalkylblad
- diagramarbetsblad
- diagramformel
- arbetsbladsformel
- kalkylbladsformel
- diagramarbetsbok
- formelberäkning
- logisk konstant
- numerisk konstant
- strängkonstant
- felkonstant
- aritmetisk operator
- jämförelseoperator
- A1-stil
- R1C1-stil
- fördefinierad funktion
- PowerPoint
- presentation
- PHP
- Aspose.Slides
description: "Använd Excel‑liknande formler i Aspose.Slides för PHP via Java‑diagramarbetsblad, beräkna om värden och använd resultaten i PowerPoint‑diagram."
---
## **Översikt**

PowerPoint-diagram lagrar vanligtvis sina källdata i ett inbäddat arbetsblad. I Aspose.Slides för PHP via Java kan du komma åt det arbetsbladet via diagrammets dataarbetsbok, skriva indata, tilldela formler till celler, beräkna stödda formler och använda de beräknade cellerna som diagramdata.

Denna artikel förklarar hela formelarbetsflödet: skapa ett diagram, fyll i dess arbetsblad, tilldela A1‑stil‑ eller R1C1‑stil‑formler, beräkna dem, läs de beräknade värdena, koppla dessa celler till en diagramserie och spara presentationen. Den beskriver också den stödda formulasyntaxen, den inbyggda funktionsuppsättningen, cachade värden, icke‑stödda formler och kalkylblads‑specifika fel.

## **Diagramarbetsblad och formler**

Ett diagramarbetsblad innehåller kategorier, serienamn och värden som används av ett diagram. I PowerPoint kan du inspektera arbetsbladet genom att öppna diagrammets dataredigerare:

![PowerPoint-diagram med sitt inbäddade arbetsblad öppet, vilket visar kategori- och seriedata](chart-worksheet-formulas_1.png)

I Aspose.Slides exponeras arbetsbladet via klassen [ChartDataWorkbook](https://reference.aspose.com/slides/sv/php-java/aspose.slides/chartdataworkbook/). Använd [ChartDataCell::setFormula](https://reference.aspose.com/slides/sv/php-java/aspose.slides/chartdatacell/#setFormula) för A1‑stil‑formler och [ChartDataCell::setR1C1Formula](https://reference.aspose.com/slides/sv/php-java/aspose.slides/chartdatacell/#setR1C1Formula) för R1C1‑stil‑formler. Efter att du har ändrat indata‑celler eller formler, anropa [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/sv/php-java/aspose.slides/chartdataworkbook/#calculateFormulas) för att beräkna stödda formler och uppdatera motsvarande cellvärden.

En beräknad cell exponeras fortfarande genom [ChartDataCell::getValue](https://reference.aspose.com/slides/sv/php-java/aspose.slides/chartdatacell/#getValue). Detta är viktigt när du behöver inspektera ett formelresultat i kod eller använda cellen som ett diagramdatapunkt.

## **Skapa ett diagram och beräkna arbetsbladsformler**

Följande exempel demonstrerar ett end‑to‑end‑arbetsflöde. Det skapar ett staplat kolumndiagram, rensar exempeldata, skriver kvartalsvisa intäkts‑ och kostnadsvärden, beräknar vinst med formler, läser resultaten, använder de beräknade cellerna som diagramvärden och sparar presentationen.

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

Diagramdatapunkterna refererar till `D2:D4`, så diagrammet använder de beräknade vinstvärdena. Det finns inget separat diagram‑uppdateringsanrop i detta arbetsflöde: beräkna arbetsboken först, använd eller spara sedan diagramdata som pekar på de beräknade cellerna.

## **Använd A1‑stilformler**

A1‑notation identifierar kolumner med bokstäver och rader med siffror. Tilldela A1‑stil‑uttryck via [ChartDataCell::setFormula](https://reference.aspose.com/slides/sv/php-java/aspose.slides/chartdatacell/#setFormula).

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

Vanliga A1‑referensformer är:

| Referens | Relativ | Absolut | Blandad |
|---|---|---|---|
| Cell | `A2` | `$A$2` | `A$2`, `$A2` |
| Rad | `2:2` | `$2:$2` | — |
| Kolumn | `A:A` | `$A:$A` | — |
| Område | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

Relativa referenser kan förändras när en formel flyttas eller kopieras av ett kalkylbladsprogram. Absoluta referenser håller båda koordinaterna fasta, medan blandade referenser fixerar endast en rad eller en kolumn.

## **Använd R1C1‑stilformler**

R1C1‑notation identifierar både rader och kolumner numeriskt. Relativa referenser använder förskjutningar i hakparenteser. Tilldela denna syntax via [ChartDataCell::setR1C1Formula](https://reference.aspose.com/slides/sv/php-java/aspose.slides/chartdatacell/#setR1C1Formula).

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

Vanliga R1C1‑referensformer är:

| Referens | Relativ | Absolut | Blandad |
|---|---|---|---|
| Cell | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| Rad | `R[2]` | `R2` | — |
| Kolumn | `C[3]` | `C3` | — |
| Område | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

Till exempel, i cell `D2` betyder `RC[-2]` cellen i samma rad två kolumner till vänster (`B2`).

## **Formelkostanter och operatorer**

Den inbyggda formelutvärderaren stöder logiska värden, numeriska litteraler, strängar, kalkylblads‑felvärden, aritmetiska operatorer och jämförelseoperatorer.

### **Konstanter och litteraler**

| Typ | Exempel | Anmärkning |
|---|---|---|
| Logisk | `TRUE`, `FALSE` | Kan användas direkt i logiska uttryck såsom `A2=TRUE`. |
| Numerisk | `1`, `0.5`, `.3`, `1E-2` | Vanlig och vetenskaplig notation stöds. |
| Sträng | `"abc"`, `"2/3/2020 12:00"` | Textlitteraler omges av dubbla citattecken i formeln. |
| Felresultat | `#DIV/0!`, `#N/A`, `#REF!` | En giltig formel kan utvärderas till ett kalkylblads‑felvärde i stället för ett normalt resultat. |

Detta exempel använder flera olika konstanttyper:

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

### **Arimetiska operatorer**

| Operator | Betydelse | Exempel |
|---|---|---|
| `+` | Addition eller unärt plus | `2+3` |
| `-` | Subtraktion eller negation | `2-3`, `-3` |
| `*` | Multiplikation | `2*3` |
| `/` | Division | `2/3` |
| `%` | Procent | `30%` |
| `^` | Exponentiering | `2^3` |

Använd parenteser för att göra utvärderingsordningen explicit, exempelvis `(A2+B2)*C2`.

### **Jämförelseoperatorer**

Jämförelseuttryck returnerar logiska värden.

| Operator | Betydelse | Exempel |
|---|---|---|
| `=` | Lika med | `A2=3` |
| `<>` | Inte lika med | `A2<>3` |
| `>` | Större än | `A2>3` |
| `>=` | Större än eller lika med | `A2>=3` |
| `<` | Mindre än | `A2<3` |
| `<=` | Mindre än eller lika med | `A2<=3` |

## **Stödda fördefinierade funktioner**

Aspose.Slides innehåller en inbyggd formelutvärderare för diagramarbetsblad, men den är inte en komplett Excel‑beräkningsmotor. Den dokumenterade funktionsuppsättningen är begränsad till funktionerna nedan. Anta inte att en godtycklig Excel‑funktion kan beräknas av [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/sv/php-java/aspose.slides/chartdataworkbook/#calculateFormulas).

| Funktion | Syfte eller stödform | Exempel |
|---|---|---|
| `ABS` | Absolutvärde | `ABS(A2)` |
| `AVERAGE` | Arismetiskt medelvärde | `AVERAGE(B2:B5)` |
| `CEILING` | Runda upp till närmaste multipel | `CEILING(A2,5)` |
| `CHOOSE` | Välj ett värde efter index | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | Slå ihop textvärden | `CONCAT(A2,B2)` |
| `CONCATENATE` | Slå ihop textvärden | `CONCATENATE(A2," ",B2)` |
| `DATE` | Skapa ett datumvärde med 1900‑datumsystemet | `DATE(2026,8,19)` |
| `DAYS` | Returnera antalet dagar mellan datum | `DAYS(B2,A2)` |
| `FIND` | Hitta en textsträng inuti en annan | `FIND("-",A2)` |
| `FINDB` | Byte‑orienterad textsökning | `FINDB("a",A2)` |
| `IF` | Villkorligt resultat | `IF(A2>0,A2,0)` |
| `INDEX` | Referensform | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | Vektorform | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | Vektorform | `MATCH(A2,B2:B5,0)` |
| `MAX` | Maximalt värde | `MAX(B2:B5)` |
| `SUM` | Summera värden | `SUM(B2:B5)` |
| `VLOOKUP` | Vertikal uppslagning | `VLOOKUP(A2,B2:D10,3,FALSE)` |

Begränsningarna i tabellen är betydelsefulla: `INDEX` är dokumenterad i referensform, medan `LOOKUP` och `MATCH` är dokumenterade i sina vektorformer. `DATE` använder 1900‑datumsystemet. Funktioner som inte listas här bör betraktas som icke‑stödda av Aspose.Slides formelutvärderare såvida de inte dokumenteras separat.

## **Oberäkning och cachade värden**

Kalkylbladsfiler lagrar ofta både en formel och dess senast beräknade värde. Aspose.Slides kan därför läsa ett cachat värde från [ChartDataCell::getValue](https://reference.aspose.com/slides/sv/php-java/aspose.slides/chartdatacell/#getValue) när en presentation laddas och den relevanta diagramdatan inte har ändrats.

Efter att du har ändrat indata‑celler eller formler, förlita dig inte på ett gammalt cache‑resultat. Anropa [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/sv/php-java/aspose.slides/chartdataworkbook/#calculateFormulas) innan du läser beräknade värden eller sparar diagramdata som beror på dem.

För formler utanför den stödde delmängden kan Aspose.Slides vara oförmögen att tolka formeln eller fastställa dess beroenden. Om arbetsboken har modifierats kan det tidigare cachade värdet inte längre betraktas som pålitligt. I ett sådant fall kan läsning av en cell med icke‑stödd data kasta [CellUnsupportedDataException](https://reference.aspose.com/slides/sv/php-java/aspose.slides/cellunsupporteddataexception/).

Om ditt diagram beror på Excel‑funktioner som Aspose.Slides inte utvärderar, beräkna dessa formler med en kalkylblads­motor som stöder dem och skriv tillbaka de resulterande värdena till diagramarbetsboken. Ersätt inte icke‑stödda formler med gissade värden.

## **Hantera formelfel**

Det finns två olika typer av problem att särskilja.

En formel kan vara giltig men producera ett kalkylblads‑felresultat såsom `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!` eller `#VALUE!`. I detta fall är fel‑tokenen ett cellresultat och kan returneras via [ChartDataCell::getValue](https://reference.aspose.com/slides/sv/php-java/aspose.slides/chartdatacell/#getValue).

En formel kan också misslyckas vid parsning, referens, beroende eller stödd‑datatnivå. Aspose.Slides tillhandahåller kalkylblads‑specifika undantag för dessa fall: [CellInvalidFormulaException](https://reference.aspose.com/slides/sv/php-java/aspose.slides/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/sv/php-java/aspose.slides/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/sv/php-java/aspose.slides/cellcircularreferenceexception/) och [CellUnsupportedDataException](https://reference.aspose.com/slides/sv/php-java/aspose.slides/cellunsupporteddataexception/).

I PHP via Java exponeras Java‑undantag via `JavaException`. När formler kommer från mallar eller användarinmatning, hantera dem runt beräkning och värdeåtkomst. Det Java‑undantag som rapporteras i stack‑spåret identifierar det specifika kalkylblads‑felet:

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

## **Praktiska begränsningar**

Formelstödet i diagramarbetsblad är avsett för en definierad delmängd av kalkylbladsberäkningar, inte för full Excel‑kompatibilitet. Ha dessa begränsningar i åtanke när du designar ett rapporterings‑arbetsflöde:

- Använd endast de dokumenterade konstanterna, operatorerna, referenserna och funktionerna när du vill att Aspose.Slides ska beräkna formler.
- Beräkna efter att du har ändrat celler som formelresultaten beror på.
- Betrakta cachade värden från inlästa presentationer som ögonblicksbilder, inte som ersättning för beräkning efter redigering.
- Testa formler från befintliga mallar innan du förlitar dig på deras beräknade värden, särskilt när de använder funktioner utanför den dokumenterade listan.
- För formler som kräver en fullständig kalkylblads‑beräkningsmotor, beräkna dem externt och uppdatera sedan diagramarbetsboken med de resulterande värdena.

## **FAQ**

**Vad är skillnaden mellan [ChartDataCell::setFormula](https://reference.aspose.com/slides/sv/php-java/aspose.slides/chartdatacell/#setFormula) och [ChartDataCell::setR1C1Formula](https://reference.aspose.com/slides/sv/php-java/aspose.slides/chartdatacell/#setR1C1Formula)?**

[ChartDataCell::setFormula](https://reference.aspose.com/slides/sv/php-java/aspose.slides/chartdatacell/#setFormula) lagrar ett A1‑stil‑uttryck såsom `B2-C2`. [ChartDataCell::setR1C1Formula](https://reference.aspose.com/slides/sv/php-java/aspose.slides/chartdatacell/#setR1C1Formula) lagrar ett R1C1‑stil‑uttryck såsom `RC[-2]-RC[-1]`. Använd den notation som bäst matchar hur du genererar eller kopierar formler.

**Behöver jag läsa själva cellen eller dess värde efter beräkning?**

[ChartDataWorkbook::getCell](https://reference.aspose.com/slides/sv/php-java/aspose.slides/chartdataworkbook/#getCell) returnerar ett [ChartDataCell](https://reference.aspose.com/slides/sv/php-java/aspose.slides/chartdatacell/). För att få det beräknade resultatet, anropa den cellens [ChartDataCell::getValue](https://reference.aspose.com/slides/sv/php-java/aspose.slides/chartdatacell/#getValue) efter beräkning.

**När ska jag anropa [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/sv/php-java/aspose.slides/chartdataworkbook/#calculateFormulas)?**

Anropa [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/sv/php-java/aspose.slides/chartdataworkbook/#calculateFormulas) efter att du har ändrat indata‑värden eller formler och innan du förlitar dig på de beräknade resultaten. Detta uppdaterar värdena för formler som den inbyggda utvärderaren stöder.

**Stöder Aspose.Slides varje Excel‑funktion?**

Nej. Den inbyggda utvärderaren stöder en dokumenterad delmängd av funktioner. Funktioner utanför den delmängden bör inte antas beräknas korrekt. Om full Excel‑formelkompatibilitet krävs, utför beräkningen med en lämplig kalkylblads‑motor och skriv de slutgiltiga värdena till diagramarbetsboken.

**Vad händer om en inläst presentation innehåller en icke‑stödd formel?**

Om diagramdatan inte har förändrats kan arbetsboken fortfarande innehålla ett tidigare beräknat cachat värde. När relaterade data modifieras kan detta cachade värde vara ogiltigt. Att komma åt en cell vars formel inte kan hanteras kan kasta [CellUnsupportedDataException](https://reference.aspose.com/slides/sv/php-java/aspose.slides/cellunsupporteddataexception/).

**Är formelfelvärden samma sak som PHP‑undantag?**

Nej. Ett resultat som `#DIV/0!` är ett kalkylblads‑värde producerat av en giltig beräkning. Fel i kalkylblads‑hantering såsom [CellInvalidFormulaException](https://reference.aspose.com/slides/sv/php-java/aspose.slides/cellinvalidformulaexception/) eller [CellCircularReferenceException](https://reference.aspose.com/slides/sv/php-java/aspose.slides/cellcircularreferenceexception/) är Java‑undantag som exponeras för PHP via `JavaException`.

**Uppdateras ett diagram automatiskt när en formelcell ändras?**

En diagramserie kan referera till arbetsbokens celler. Beräkna arbetsboken först, spara eller rendera sedan presentationen. Om diagramdatapunkterna refererar till de beräknade cellerna använder diagrammet de uppdaterade cellvärdena; ingen separat diagram‑uppdateringsmetod krävs för detta arbetsflöde.

**Kan diagram använda ett externt Excel‑arbetsbok?**

Ja, diagramdata kan konfigureras att använda en extern arbetsbok via diagram‑data‑API:t. Däremot rör sig formelberäkningsarbetsflödet som beskrivs i denna artikel enbart kring diagramarbetsboken och den formeldelmängd som Aspose.Slides utvärderar. Anta inte att [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/sv/php-java/aspose.slides/chartdataworkbook/#calculateFormulas) ger full beräkning av godtyckliga formler i en extern XLSX‑fil.

**Kan jag använda formler som refererar till ett annat arbetsblad eller arbetsbok?**

Excel‑stil‑referenser kan finnas i diagramarbetsböcker, men formelutvärderingen är begränsad av den stödda parsern och funktionsuppsättningen. Om en kors‑blad‑ eller extern referens är nödvändig, verifiera att exakt formel stöds i den version av Aspose.Slides du använder. För arbetsflöden som kräver bred Excel‑referenskkompatibilitet, beräkna arbetsboken externt och skriv tillbaka de lösta värdena till diagramdatan.

**Ska formelsträngar börja med `=`?**

Aspose.Slides‑API‑exemplen tilldelar uttryck såsom `B2-C2` eller `SUM(B2:B5)` utan inledande `=`. Att använda den formen håller genererade formler konsekventa med de dokumenterade API‑exemplen.
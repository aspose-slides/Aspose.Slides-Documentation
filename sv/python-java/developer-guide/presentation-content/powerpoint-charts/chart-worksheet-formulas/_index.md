---
title: Tillämpa diagramkalkylbladsformler i presentationer i Python via Java
linktitle: Kalkylbladsformler
type: docs
weight: 70
url: /sv/python-java/chart-worksheet-formulas/
keywords:
- diagramkalkylblad
- diagramkalkylblad
- diagramformel
- kalkylbladsformel
- kalkylbladsformel
- diagramdatabok
- formelberäkning
- föredragen kultur
- kulturspecifik formel
- DBCS
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
- Python
- Java
- Aspose.Slides
description: "Tillämpa Excel-stil-formler i Aspose.Slides för Python via Java diagramkalkylblad, beräkna om värden och använda resultaten i PowerPoint-diagram."
---
## **Översikt**

PowerPoint-diagram lagrar vanligtvis sina källdata i ett inbäddat kalkylblad. I Aspose.Slides för Python via Java kan du komma åt det kalkylbladet via diagramdataboken, skriva indata, tilldela formler till celler, beräkna stödda formler och använda de beräknade cellerna som diagramdata.

Denna artikel förklarar hela formelarbetsflödet: skapa ett diagram, fyll i dess kalkylblad, tilldela A1‑stil‑ eller R1C1‑stil‑formler, beräkna om dem, läs de beräknade värdena, anslut de cellerna till en diagramserie och spara presentationen. Den beskriver också den stödda Formel‑syntaxen, den inbyggda funktionsuppsättningen, cachade värden, icke‑stödda formler och kalkylblads‑specifika fel.

## **Diagram‑kalkylblad och formler**

Ett diagram‑kalkylblad innehåller kategorier, serienamn och värden som används av ett diagram. I PowerPoint kan du inspektera kalkylbladet genom att öppna diagramdataredigeraren:

![PowerPoint‑diagram med sitt inbäddade kalkylblad öppet, visar kategori‑ och seriedata](chart-worksheet-formulas_1.png)

I Aspose.Slides exponeras kalkylbladet via klassen [ChartDataWorkbook](https://reference.aspose.com/slides/sv/python-java/aspose.slides/chartdataworkbook/). Använd [ChartDataCell.setFormula](https://reference.aspose.com/slides/sv/python-java/aspose.slides/chartdatacell/#setFormula) för A1‑stil‑formler och [ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/sv/python-java/aspose.slides/chartdatacell/#setR1C1Formula) för R1C1‑stil‑formler. Efter att du ändrat indata‑celler eller formler, anropa [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/sv/python-java/aspose.slides/chartdataworkbook/#calculateFormulas) för att beräkna om stödda formler och uppdatera motsvarande cellvärden.

En beräknad cell exponerar fortfarande sitt resultat via [ChartDataCell.getValue](https://reference.aspose.com/slides/sv/python-java/aspose.slides/chartdatacell/#getValue). Detta är viktigt när du behöver inspektera ett formelresultat i kod eller använda cellen som ett diagramdatapunkt.

## **Skapa ett diagram och beräkna kalkylblads‑formler**

Följande exempel demonstrerar ett end‑to‑end‑arbetsflöde. Det skapar ett klustrat stapeldiagram, rensar exempeldata, skriver kvartalsvisa intäkts‑ och kostnadsvärden, beräknar vinst med formler, läser resultaten, använder de beräknade cellerna som diagramvärden och sparar presentationen.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 350)
    workbook = chart.getChartData().getChartDataWorkbook()
    worksheet_index = 0

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()
    workbook.clear(worksheet_index)

    category1 = workbook.getCell(worksheet_index, "A2", "Q1")
    category2 = workbook.getCell(worksheet_index, "A3", "Q2")
    category3 = workbook.getCell(worksheet_index, "A4", "Q3")

    workbook.getCell(worksheet_index, "B1", "Revenue")
    workbook.getCell(worksheet_index, "C1", "Expenses")
    workbook.getCell(worksheet_index, "D1", "Profit")

    workbook.getCell(worksheet_index, "B2").setValue(120.0)
    workbook.getCell(worksheet_index, "C2").setValue(80.0)
    workbook.getCell(worksheet_index, "B3").setValue(150.0)
    workbook.getCell(worksheet_index, "C3").setValue(95.0)
    workbook.getCell(worksheet_index, "B4").setValue(135.0)
    workbook.getCell(worksheet_index, "C4").setValue(110.0)

    profit1 = workbook.getCell(worksheet_index, "D2")
    profit2 = workbook.getCell(worksheet_index, "D3")
    profit3 = workbook.getCell(worksheet_index, "D4")

    profit1.setFormula("B2-C2")
    profit2.setFormula("B3-C3")
    profit3.setFormula("B4-C4")

    workbook.calculateFormulas()

    q1_profit = float(profit1.getValue()) # 40
    q2_profit = float(profit2.getValue()) # 55
    q3_profit = float(profit3.getValue()) # 25

    print("Q1 profit: ", q1_profit)
    print("Q2 profit: ", q2_profit)
    print("Q3 profit: ", q3_profit)

    chart.getChartData().getCategories().add(category1)
    chart.getChartData().getCategories().add(category2)
    chart.getChartData().getCategories().add(category3)

    profit_series = chart.getChartData().getSeries().add(workbook.getCell(worksheet_index, "D1"), chart.getType())
    profit_series.getDataPoints().addDataPointForBarSeries(profit1)
    profit_series.getDataPoints().addDataPointForBarSeries(profit2)
    profit_series.getDataPoints().addDataPointForBarSeries(profit3)
    profit_series.getLabels().getDefaultDataLabelFormat().setShowValue(True)

    presentation.save("chart-formulas.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Diagramdatapunkterna refererar till `D2:D4`, så diagrammet använder de beräknade vinstvärdena. Det finns inget separat diagram‑uppdaterings‑anrop i detta arbetsflöde: beräkna först kalkylbladet, använd eller spara sedan diagramdata som pekar på de beräknade cellerna.

## **Använd A1‑stil‑formler**

A1‑notation identifierar kolumner med bokstäver och rader med siffror. Tilldela A1‑stil‑uttryck via [ChartDataCell.setFormula](https://reference.aspose.com/slides/sv/python-java/aspose.slides/chartdatacell/#setFormula).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300)
    workbook = chart.getChartData().getChartDataWorkbook()

    workbook.getCell(0, "C3").setValue(10)
    workbook.getCell(0, "F2").setValue(2)
    workbook.getCell(0, "G2").setValue(3)
    workbook.getCell(0, "H2").setValue(4)

    cell = workbook.getCell(0, "A2")
    cell.setFormula("C3+SUM(F2:H2)")

    workbook.calculateFormulas()

    value = cell.getValue() # 19
finally:
    presentation.dispose()
```

Vanliga A1‑referensformer är:

| Referens | Relativ | Absolut | Blandad |
|---|---|---|---|
| Cell | `A2` | `$A$2` | `A$2`, `$A2` |
| Rad | `2:2` | `$2:$2` | — |
| Kolumn | `A:A` | `$A:$A` | — |
| Område | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

Relativa referenser kan förändras när en formel flyttas eller kopieras i ett kalkylbladsprogram. Absoluta referenser håller båda koordinaterna fasta, medan blandade referenser fixerar endast en rad eller en kolumn.

## **Använd R1C1‑stil‑formler**

R1C1‑notation identifierar både rader och kolumner numeriskt. Relativa referenser använder förskjutningar i hakparenteser. Tilldela denna syntax via [ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/sv/python-java/aspose.slides/chartdatacell/#setR1C1Formula).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300)
    workbook = chart.getChartData().getChartDataWorkbook()

    workbook.getCell(0, "B2").setValue(12)
    workbook.getCell(0, "C2").setValue(5)

    cell = workbook.getCell(0, "D2")
    cell.setR1C1Formula("RC[-2]-RC[-1]")

    workbook.calculateFormulas()

    value = cell.getValue() # 7
finally:
    presentation.dispose()
```

Vanliga R1C1‑referensformer är:

| Referens | Relativ | Absolut | Blandad |
|---|---|---|---|
| Cell | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| Rad | `R[2]` | `R2` | — |
| Kolumn | `C[3]` | `C3` | — |
| Område | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

Till exempel, i cell `D2` betyder `RC[-2]` cellen i samma rad två kolumner åt vänster (`B2`).

## **Formel‑konstanter och operatorer**

Den inbyggda formelutvärderaren stöder logiska värden, numeriska litteraler, strängar, kalkylblads‑felvärden, aritmetiska operatorer och jämförelseoperatorer.

### **Konstanter och litteraler**

| Typ | Exempel | Notering |
|---|---|---|
| Logisk | `TRUE`, `FALSE` | Kan användas direkt i logiska uttryck såsom `A2=TRUE`. |
| Numerisk | `1`, `0.5`, `.3`, `1E-2` | Vanlig och vetenskaplig notation stöds. |
| Sträng | `"abc"`, `"2/3/2020 12:00"` | Textlitteraler omges av dubbla citationstecken i formeln. |
| Felresultat | `#DIV/0!`, `#N/A`, `#REF!` | En giltig formel kan utvärderas till ett kalkylblads‑felvärde istället för ett normalt resultat. |

Detta exempel använder flera konstanttyper:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300)
    workbook = chart.getChartData().getChartDataWorkbook()

    workbook.getCell(0, "A2").setValue(False)
    workbook.getCell(0, "B2").setFormula("A2=TRUE")
    workbook.getCell(0, "C2").setFormula("1+0.5")
    workbook.getCell(0, "D2").setFormula(".3*1E-2")
    workbook.getCell(0, "E2").setFormula("\"abc\"")
    workbook.getCell(0, "F2").setFormula("2/0")

    workbook.calculateFormulas()

    logical_value = workbook.getCell(0, "B2").getValue() # Falskt
    numeric_value = workbook.getCell(0, "C2").getValue() # 1.5
    scientific_value = workbook.getCell(0, "D2").getValue() # 0.003
    string_value = workbook.getCell(0, "E2").getValue() # abc
    error_value = workbook.getCell(0, "F2").getValue() # #DIV/0!
finally:
    presentation.dispose()
```

### **Aritmetiska operatorer**

| Operator | Betydelse | Exempel |
|---|---|---|
| `+` | Addition eller unary plus | `2+3` |
| `-` | Subtraktion eller negation | `2-3`, `-3` |
| `*` | Multiplikation | `2*3` |
| `/` | Division | `2/3` |
| `%` | Procent | `30%` |
| `^` | Potens | `2^3` |

Använd parenteser för att göra evalueringsordning explicit, t.ex. `(A2+B2)*C2`.

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

Aspose.Slides inkluderar en inbyggd formelutvärderare för diagram‑kalkylblad, men den är inte en komplett Excel‑beräkningsmotor. Den dokumenterade funktionsuppsättningen är begränsad till funktionerna nedan. Anta inte att en godtycklig Excel‑funktion kan beräknas av [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/sv/python-java/aspose.slides/chartdataworkbook/#calculateFormulas).

| Funktion | Syfte eller stödd form | Exempel |
|---|---|---|
| `ABS` | Absolutvärde | `ABS(A2)` |
| `AVERAGE` | Medelvärde | `AVERAGE(B2:B5)` |
| `CEILING` | Avrunda uppåt till närmaste multipel | `CEILING(A2,5)` |
| `CHOOSE` | Välj ett värde med index | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | Slå samman textvärden | `CONCAT(A2,B2)` |
| `CONCATENATE` | Slå samman textvärden | `CONCATENATE(A2," ",B2)` |
| `DATE` | Skapa ett datumvärde med 1900‑datumsystemet | `DATE(2026,8,19)` |
| `DAYS` | Returnera antalet dagar mellan datum | `DAYS(B2,A2)` |
| `FIND` | Hitta en textsträng i en annan | `FIND("-",A2)` |
| `FINDB` | Byte‑orienterad textsökning | `FINDB("a",A2)` |
| `IF` | Villkorligt resultat | `IF(A2>0,A2,0)` |
| `INDEX` | Referensform | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | Vektorform | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | Vektorform | `MATCH(A2,B2:B5,0)` |
| `MAX` | Maximumvärde | `MAX(B2:B5)` |
| `SUM` | Summera värden | `SUM(B2:B5)` |
| `VLOOKUP` | Vertikal sökning | `VLOOKUP(A2,B2:D10,3,FALSE)` |

Begränsningarna i tabellen är betydelsefulla: `INDEX` dokumenteras i referensform, medan `LOOKUP` och `MATCH` dokumenteras i sina vektorformer. `DATE` använder 1900‑datumsystemet. Funktioner som inte listas här bör betraktas som ej stödjade av Aspose.Slides‑formelutvärderaren, såvida de inte dokumenteras separat.

## **Beräkna formler med en föredragen kultur**

Vissa kalkylblads‑funktioner tolkar text enligt kultur‑specifika regler. Detta är särskilt viktigt för funktioner avsedda för språk som använder dubbel‑byte‑teckenuppsättningar (DBCS). För att beräkna sådana formler korrekt, skapa [LoadOptions](https://reference.aspose.com/slides/sv/python-java/aspose.slides/loadoptions/), sätt den föredragna kulturen med [SpreadsheetOptions.setPreferredCulture](https://reference.aspose.com/slides/sv/python-java/aspose.slides/spreadsheetoptions/#setPreferredCulture), tilldela kalkylbladsalternativen via [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/sv/python-java/aspose.slides/loadoptions/#setSpreadsheetOptions) och ladda sedan presentationen.

Följande exempel väljer den japanska kulturen, öppnar en presentation med de konfigurerade laddningsalternativen och anropar [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/sv/python-java/aspose.slides/chartdataworkbook/#calculateFormulas) för varje diagram‑kalkylblad:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, LoadOptions, Presentation, SpreadsheetOptions
from java.util import Locale

japanese_culture = Locale.forLanguageTag("ja-JP")

spreadsheet_options = SpreadsheetOptions()
spreadsheet_options.setPreferredCulture(japanese_culture)

load_options = LoadOptions()
load_options.setSpreadsheetOptions(spreadsheet_options)

presentation = Presentation("presentation.pptx", load_options)
try:
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if isinstance(shape, Chart):
                shape.getChartData().getChartDataWorkbook().calculateFormulas()
finally:
    presentation.dispose()
```

Den föredragna kulturen är en del av presentations‑laddningskonfigurationen, så ange den innan du skapar [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/)-instansen. Använd den kultur som krävs av kalkylblads‑formlerna; exempelvis `ja-JP` för formler som ska följa japanska DBCS‑beräkningsregler.

## **Omberäkning och cachade värden**

Kalkylbladsfiler lagrar ofta både en formel och dess senast beräknade värde. Aspose.Slides kan därför läsa ett cachat värde från [ChartDataCell.getValue](https://reference.aspose.com/slides/sv/python-java/aspose.slides/chartdatacell/#getValue) när en presentation laddas och den relevanta diagramdata inte har ändrats.

Efter att du ändrat indata‑celler eller formler, förlita dig inte på ett gammalt cachat resultat. Anropa [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/sv/python-java/aspose.slides/chartdataworkbook/#calculateFormulas) innan du läser beräknade värden eller sparar diagramdata som beror på dem.

För formler utanför den stödda delmängden kan Aspose.Slides vara oförmögen att pars:a formeln eller fastställa dess beroenden. Om kalkylbladet har modifierats kan det tidigare cachade värdet inte längre anses pålitligt. I sådana fall kan läsning av en cell med osupporterad data leda till [CellUnsupportedDataException](https://reference.aspose.com/slides/sv/python-java/aspose.slides/cellunsupporteddataexception/).

Om ditt diagram beror på Excel‑funktioner som Aspose.Slides inte utvärderar, beräkna dessa formler med en kalkylblads‑motor som stöder dem och skriv tillbaka de resulterande värdena till diagram‑kalkylbladet. Ersätt inte osupporterade formler med gissade värden.

## **Hantera formelfel**

Det finns två olika typer av problem att skilja på.

En formel kan vara giltig men producera ett kalkylblads‑felresultat såsom `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!` eller `#VALUE!`. I detta fall är fel‑tokenen ett cellresultat och kan returneras via [ChartDataCell.getValue](https://reference.aspose.com/slides/sv/python-java/aspose.slides/chartdatacell/#getValue).

En formel kan också misslyckas vid parsning, referens, beroende eller på den stödda‑datatypen. Aspose.Slides tillhandahåller kalkylblads‑specifika undantag för dessa fall: [CellInvalidFormulaException](https://reference.aspose.com/slides/sv/python-java/aspose.slides/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/sv/python-java/aspose.slides/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/sv/python-java/aspose.slides/cellcircularreferenceexception/), och [CellUnsupportedDataException](https://reference.aspose.com/slides/sv/python-java/aspose.slides/cellunsupporteddataexception/).

När formler kommer från mallar eller användarinmatning, hantera dessa undantag runt omberäkning och värdeåtkomst:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CellCircularReferenceException, CellInvalidFormulaException, CellInvalidReferenceException, CellUnsupportedDataException, ChartType, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300)
    workbook = chart.getChartData().getChartDataWorkbook()
    cell = workbook.getCell(0, "A2")
    cell.setFormula("SUM(B2:B5)")

    try:
        workbook.calculateFormulas()
        print(cell.getValue())
    except CellInvalidFormulaException as ex:
        print("Invalid formula: " + str(ex.getMessage()))
    except CellInvalidReferenceException as ex:
        print("Invalid cell reference: " + str(ex.getMessage()))
    except CellCircularReferenceException as ex:
        print("Circular reference: " + str(ex.getMessage()))
    except CellUnsupportedDataException as ex:
        print("Unsupported spreadsheet data: " + str(ex.getMessage()))
finally:
    presentation.dispose()
```

## **Praktiska begränsningar**

Formelstöd i diagram‑kalkylblad är avsett för en definierad delmängd kalkylbladsberäkningar, inte för full Excel‑kompatibilitet. Ha dessa begränsningar i åtanke när du designar ett rapporterings‑arbetsflöde:

- Använd endast de dokumenterade konstanterna, operatorerna, referenserna och funktionerna när du vill att Aspose.Slides ska beräkna formler.
- Omberäkna efter att du ändrat de celler som formelresultaten beror på.
- Betrakta cachade värden från inlästa presentationer som ögonblicksbilder, inte som en ersättning för omberäkning efter redigering.
- Testa formler från befintliga mallar innan du förlitar dig på deras beräknade värden, särskilt när de använder funktioner utanför den dokumenterade listan.
- För formler som kräver en komplett kalkylblads‑beräkningsmotor, beräkna dem externt och uppdatera sedan diagram‑kalkylbladet med de resulterande värdena.

## **FAQ**

**Vad är skillnaden mellan [ChartDataCell.setFormula](https://reference.aspose.com/slides/sv/python-java/aspose.slides/chartdatacell/#setFormula) och [ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/sv/python-java/aspose.slides/chartdatacell/#setR1C1Formula)?**

[ChartDataCell.setFormula](https://reference.aspose.com/slides/sv/python-java/aspose.slides/chartdatacell/#setFormula) lagrar ett A1‑stil‑uttryck såsom `B2-C2`. [ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/sv/python-java/aspose.slides/chartdatacell/#setR1C1Formula) lagrar ett R1C1‑stil‑uttryck såsom `RC[-2]-RC[-1]`. Använd den notation som bäst matchar hur du genererar eller kopierar formler.

**Behöver jag läsa själva cellen eller dess värde efter beräkning?**

[ChartDataWorkbook.getCell](https://reference.aspose.com/slides/sv/python-java/aspose.slides/chartdataworkbook/#getCell) returnerar en [ChartDataCell](https://reference.aspose.com/slides/sv/python-java/aspose.slides/chartdatacell/). För att få det beräknade resultatet, anropa den cellens [ChartDataCell.getValue](https://reference.aspose.com/slides/sv/python-java/aspose.slides/chartdatacell/#getValue) efter omberäkning.

**När bör jag anropa [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/sv/python-java/aspose.slides/chartdataworkbook/#calculateFormulas)?**

Anropa [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/sv/python-java/aspose.slides/chartdataworkbook/#calculateFormulas) efter att du ändrat indata‑värden eller formler och innan du är beroende av de beräknade resultaten. Detta uppdaterar värdena för formler som den inbyggda utvärderaren stödjer.

**Stöder Aspose.Slides varje Excel‑funktion?**

Nej. Den inbyggda utvärderaren stödjer en dokumenterad delmängd funktioner. Funktioner utanför den delmängden bör inte antas kunna beräknas korrekt. Om full Excel‑formelkompatibilitet krävs, utför beräkningen med en lämplig kalkylblads‑motor och skriv de slutliga värdena till diagram‑kalkylbladet.

**Vad händer om en inläst presentation innehåller en osupporterad formel?**

Om diagramdata inte har ändrats kan kalkylbladet fortfarande innehålla ett tidigare beräknat cachat värde. Efter att relevant data har modifierats kan detta cachade värde vara ogiltigt. Att komma åt en cell vars formel inte kan hanteras kan leda till [CellUnsupportedDataException](https://reference.aspose.com/slides/sv/python-java/aspose.slides/cellunsupporteddataexception/).

**Är formelfelvärden samma sak som undantag?**

Nej. Ett resultat som `#DIV/0!` är ett kalkylblads‑värde genererat av en giltig beräkning. Undantag som [CellInvalidFormulaException](https://reference.aspose.com/slides/sv/python-java/aspose.slides/cellinvalidformulaexception/) eller [CellCircularReferenceException](https://reference.aspose.com/slides/sv/python-java/aspose.slides/cellcircularreferenceexception/) indikerar att formeln inte kan bearbetas normalt.

**Uppdateras ett diagram automatiskt när en formelcell ändras?**

En diagramserie kan referera till kalkylblads‑celler. Beräkna kalkylbladet först, spara eller rendera sedan presentationen. Om diagramdatapunkterna refererar till de beräknade cellerna använder diagrammet de uppdaterade cellvärdena; inget separat diagram‑uppdaterings‑metod krävs för detta arbetsflöde.

**Kan diagram använda ett externt Excel‑kalkylblad?**

Ja, diagramdata kan konfigureras att använda ett externt kalkylblad via diagram‑datat API‑t. Dock avser arbetsflödet som beskrivs i denna artikel diagram‑kalkylbladet och den formel‑delmängd som evalueras av Aspose.Slides. Anta inte att [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/sv/python-java/aspose.slides/chartdataworkbook/#calculateFormulas) ger fullständig omberäkning av godtyckliga formler i en extern XLSX‑fil.

**Kan jag använda formler som refererar till ett annat kalkylblad eller arbetsbok?**

Excel‑stil‑referenser kan finnas i diagram‑kalkylblad, men formelutvärderingen är begränsad av den stödjade parsern och funktionsuppsättningen. Om en kors‑blad‑ eller extern referens är väsentlig, verifiera exakt formel med din mål‑version av Aspose.Slides. För arbetsflöden som kräver bred Excel‑referens‑kompatibilitet, beräkna kalkylbladet externt och skriv tillbaka de lösta värdena till diagram‑data.

**Ska formel‑strängar börja med `=`?**

Aspose.Slides‑API‑exemplen tilldelar uttryck som `B2-C2` eller `SUM(B2:B5)` utan ett inledande `=`. Att använda den formen håller genererade formler i linje med de dokumenterade API‑exemplen.
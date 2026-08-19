---
title: Använd diagramkalkylbladsformler i presentationer med Python
linktitle: Kalkylbladsformler
type: docs
weight: 70
url: /sv/python-net/chart-worksheet-formulas/
keywords:
- diagramkalkylblad
- diagramarbetsblad
- diagramformel
- kalkylbladsformel
- kalkylbladsformel
- diagramdataarbetsbok
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
- Python
- Aspose.Slides
description: "Använd Excel-liknande formler i Aspose.Slides för Python via .NET-diagramkalkylblad, beräkna om värden och använd resultaten i PowerPoint-diagram."
---
## **Översikt**

PowerPoint‑diagram lagrar vanligtvis sina källdata i ett inbäddat kalkylblad. I Aspose.Slides for Python via .NET kan du komma åt det kalkylbladet via diagramdata‑arbetsboken, skriva in värden, tilldela formler till celler, beräkna stödda formler och använda de beräknade cellerna som diagramdata.

Denna artikel förklarar hela formelarbetsflödet: skapa ett diagram, fyll i dess kalkylblad, tilldela A1‑ eller R1C1‑formler, beräkna om dem, läs de beräknade värdena, anslut dessa celler till en diagramserie och spara presentationen. Den beskriver också stödd formelsyntax, den inbyggda funktionsuppsättningen, cachade värden, osupporterade formler och kalkylblads‑specifika fel.

## **Diagram‑kalkylblad och formler**

Ett diagram‑kalkylblad innehåller de kategorier, serienamn och värden som används av ett diagram. I PowerPoint kan du inspektera kalkylbladet genom att öppna diagramdata‑redigeraren:

![PowerPoint‑diagram med sitt inbäddade kalkylblad öppet, visar kategori‑ och seriedata](chart-worksheet-formulas_1.png)

I Aspose.Slides exponeras kalkylbladet via [chart data workbook](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/ichartdataworkbook/). Använd egenskapen [formula](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/ichartdatacell/formula/) för A1‑formler och egenskapen [r1c1_formula](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/ichartdatacell/r1c1_formula/) för R1C1‑formler. Efter att du ändrat inmatningsceller eller formler, anropa [calculate_formulas](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/) för att beräkna om stödda formler och uppdatera motsvarande cellvärden.

En beräknad cell exponerar fortfarande sitt resultat via egenskapen [value](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/ichartdatacell/value/). Detta är viktigt när du behöver inspektera ett formelresultat i kod eller använda cellen som ett diagramdatapunkt.

## **Skapa ett diagram och beräkna kalkylblads‑formler**

Följande exempel visar ett end‑to‑end‑arbetsflöde. Det skapar ett staplat kolumndiagram, rensar exempeldata, skriver kvartalsvisa intäkts‑ och kostnadsvärden, beräknar vinst med formler, läser resultaten, använder de beräknade cellerna som diagramvärden och sparar presentationen.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 350)
    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()
    workbook.clear(worksheet_index)

    category1 = workbook.get_cell(worksheet_index, "A2", "Q1")
    category2 = workbook.get_cell(worksheet_index, "A3", "Q2")
    category3 = workbook.get_cell(worksheet_index, "A4", "Q3")

    workbook.get_cell(worksheet_index, "B1", "Revenue")
    workbook.get_cell(worksheet_index, "C1", "Expenses")
    workbook.get_cell(worksheet_index, "D1", "Profit")

    workbook.get_cell(worksheet_index, "B2").value = 120.0
    workbook.get_cell(worksheet_index, "C2").value = 80.0
    workbook.get_cell(worksheet_index, "B3").value = 150.0
    workbook.get_cell(worksheet_index, "C3").value = 95.0
    workbook.get_cell(worksheet_index, "B4").value = 135.0
    workbook.get_cell(worksheet_index, "C4").value = 110.0

    profit1 = workbook.get_cell(worksheet_index, "D2")
    profit2 = workbook.get_cell(worksheet_index, "D3")
    profit3 = workbook.get_cell(worksheet_index, "D4")

    profit1.formula = "B2-C2"
    profit2.formula = "B3-C3"
    profit3.formula = "B4-C4"

    workbook.calculate_formulas()

    q1_profit = profit1.value  # 40
    q2_profit = profit2.value  # 55
    q3_profit = profit3.value  # 25

    print(f"Q1 profit: {q1_profit}")
    print(f"Q2 profit: {q2_profit}")
    print(f"Q3 profit: {q3_profit}")

    chart.chart_data.categories.add(category1)
    chart.chart_data.categories.add(category2)
    chart.chart_data.categories.add(category3)

    profit_series = chart.chart_data.series.add(workbook.get_cell(worksheet_index, "D1"), chart.type)
    profit_series.data_points.add_data_point_for_bar_series(profit1)
    profit_series.data_points.add_data_point_for_bar_series(profit2)
    profit_series.data_points.add_data_point_for_bar_series(profit3)
    profit_series.labels.default_data_label_format.show_value = True

    presentation.save("chart-formulas.pptx", slides.export.SaveFormat.PPTX)
```

Diagramdatapunkterna refererar `D2:D4`, så diagrammet använder de beräknade vinstvärdena. Det finns inget separat diagram‑uppdateringsanrop i detta arbetsflöde: beräkna arbetsboken först, använd eller spara sedan diagramdata som pekar på de beräknade cellerna.

## **Använd A1‑stil‑formler**

A1‑notation identifierar kolumner med bokstäver och rader med siffror. Tilldela A1‑stil‑uttryck via [IChartDataCell.formula](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/ichartdatacell/formula/).

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 300)
    workbook = chart.chart_data.chart_data_workbook

    workbook.get_cell(0, "C3").value = 10
    workbook.get_cell(0, "F2").value = 2
    workbook.get_cell(0, "G2").value = 3
    workbook.get_cell(0, "H2").value = 4

    cell = workbook.get_cell(0, "A2")
    cell.formula = "C3+SUM(F2:H2)"

    workbook.calculate_formulas()

    value = cell.value  # 19
```

Vanliga A1‑referensformer är:

| Referens | Relativ | Absolut | Blandet |
|---|---|---|---|
| Cell | `A2` | `$A$2` | `A$2`, `$A2` |
| Rad | `2:2` | `$2:$2` | — |
| Kolumn | `A:A` | `$A:$A` | — |
| Område | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

Relativa referenser kan ändras när en formel flyttas eller kopieras i ett kalkylbladsprogram. Absoluta referenser håller båda koordinaterna fasta, medan blandade referenser fixar endast en rad eller en kolumn.

## **Använd R1C1‑stil‑formler**

R1C1‑notation identifierar både rader och kolumner numeriskt. Relativa referenser använder avstånd i hakparenteser. Tilldela denna syntax via [IChartDataCell.r1c1_formula](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/ichartdatacell/r1c1_formula/).

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 300)
    workbook = chart.chart_data.chart_data_workbook

    workbook.get_cell(0, "B2").value = 12
    workbook.get_cell(0, "C2").value = 5

    cell = workbook.get_cell(0, "D2")
    cell.r1c1_formula = "RC[-2]-RC[-1]"

    workbook.calculate_formulas()

    value = cell.value  # 7
```

Vanliga R1C1‑referensformer är:

| Referens | Relativ | Absolut | Blandet |
|---|---|---|---|
| Cell | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| Rad | `R[2]` | `R2` | — |
| Kolumn | `C[3]` | `C3` | — |
| Område | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

Till exempel, i cell `D2` betyder `RC[-2]` cellen i samma rad två kolumner åt vänster (`B2`).

## **Formelkonstanter och operatorer**

Den inbyggda formelutvärderaren stödjer logiska värden, numeriska literalvärden, strängar, kalkylblads‑felvärden, aritmetiska operatorer och jämförelseoperatorer.

### **Konstanter och literaler**

| Typ | Exempel | Kommentar |
|---|---|---|
| Logisk | `TRUE`, `FALSE` | Kan användas direkt i logiska uttryck såsom `A2=TRUE`. |
| Numerisk | `1`, `0.5`, `.3`, `1E-2` | Vanlig och vetenskaplig notation stöds. |
| Sträng | `"abc"`, `"2/3/2020 12:00"` | Textliteral omsluts av dubbla citationstecken i formeln. |
| Felresultat | `#DIV/0!`, `#N/A`, `#REF!` | En giltig formel kan utvärderas till ett kalkylblads‑felvärde istället för ett normalt resultat. |

Detta exempel använder flera konstanttyper:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 300)
    workbook = chart.chart_data.chart_data_workbook

    workbook.get_cell(0, "A2").value = False
    workbook.get_cell(0, "B2").formula = "A2=TRUE"
    workbook.get_cell(0, "C2").formula = "1+0.5"
    workbook.get_cell(0, "D2").formula = ".3*1E-2"
    workbook.get_cell(0, "E2").formula = "\"abc\""
    workbook.get_cell(0, "F2").formula = "2/0"

    workbook.calculate_formulas()

    logical_value = workbook.get_cell(0, "B2").value  # Falskt
    numeric_value = workbook.get_cell(0, "C2").value  # 1.5
    scientific_value = workbook.get_cell(0, "D2").value  # 0.003
    string_value = workbook.get_cell(0, "E2").value  # abc
    error_value = workbook.get_cell(0, "F2").value  # #DIV/0!
```

### **Aritmetiska operatorer**

| Operator | Betydelse | Exempel |
|---|---|---|
| `+` | Addition eller unärt plustecken | `2+3` |
| `-` | Subtraktion eller negation | `2-3`, `-3` |
| `*` | Multiplikation | `2*3` |
| `/` | Division | `2/3` |
| `%` | Procent | `30%` |
| `^` | Upphöjning | `2^3` |

Använd parenteser för att göra utvärderingsordningen explicit, t.ex. `(A2+B2)*C2`.

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

Aspose.Slides innehåller en inbyggd formelutvärderare för diagram‑kalkylblad, men den är inte en komplett Excel‑beräkningsmotor. Den dokumenterade funktionsuppsättningen är begränsad till funktionerna nedan. Anta inte att en godtycklig Excel‑funktion kan omberäknas av [calculate_formulas](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/).

| Funktion | Syfte eller stödform | Exempel |
|---|---|---|
| `ABS` | Absolutvärde | `ABS(A2)` |
| `AVERAGE` | Aritmetiskt medelvärde | `AVERAGE(B2:B5)` |
| `CEILING` | Runda upp till ett multipel | `CEILING(A2,5)` |
| `CHOOSE` | Välj ett värde efter index | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | Sammanfoga textvärden | `CONCAT(A2,B2)` |
| `CONCATENATE` | Sammanfoga textvärden | `CONCATENATE(A2," ",B2)` |
| `DATE` | Skapa ett datumvärde med 1900‑datumsystemet | `DATE(2026,8,19)` |
| `DAYS` | Returnera antal dagar mellan datum | `DAYS(B2,A2)` |
| `FIND` | Hitta en textsträng i en annan | `FIND("-",A2)` |
| `FINDB` | Byte‑orienterad textsökning | `FINDB("a",A2)` |
| `IF` | Villkorligt resultat | `IF(A2>0,A2,0)` |
| `INDEX` | Referensform | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | Vektorform | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | Vektorform | `MATCH(A2,B2:B5,0)` |
| `MAX` | Maximumvärde | `MAX(B2:B5)` |
| `SUM` | Summera värden | `SUM(B2:B5)` |
| `VLOOKUP` | Vertikal uppslagning | `VLOOKUP(A2,B2:D10,3,FALSE)` |

Begränsningarna i tabellen är betydande: `INDEX` är dokumenterad i referensform, medan `LOOKUP` och `MATCH` är dokumenterade i sina vektorformer. `DATE` använder 1900‑datumsystemet. Funktioner och funktioner som inte listas här bör betraktas som osupporterade av Aspose.Slides‑formelutvärderaren, såvida de inte är dokumenterade separat.

## **Ombedning och cachade värden**

Kalkylbladsfiler lagrar ofta både en formel och dess senast beräknade värde. Aspose.Slides kan därför läsa ett cachat värde från [IChartDataCell.value](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/ichartdatacell/value/) när en presentation laddas och den relevanta diagramdatan inte har ändrats.

Efter att du har ändrat inmatningsceller eller formler, förlita dig inte på ett gammalt cachat resultat. Anropa [ChartDataWorkbook.calculate_formulas](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/) innan du läser beräknade värden eller sparar diagramdata som beror på dem.

För formler utanför den stödda uppsättningen kan Aspose.Slides misslyckas med att parsra formeln eller fastställa dess beroenden. Om arbetsboken har modifierats kan det tidigare cachade värdet inte längre anses pålitligt. I sådana situationer kan läsning av värdet i en cell med osupporterad data kasta [CellUnsupportedDataException](https://reference.aspose.com/slides/sv/python-net/aspose.slides.spreadsheet/cellunsupporteddataexception/).

Om ditt diagram är beroende av Excel‑funktioner som Aspose.Slides inte utvärderar, beräkna dessa formler med en kalkylblads‑motor som stödjer dem och skriv tillbaka de resulterande värdena till diagramarbetsboken. Ersätt inte osupporterade formler med gissade värden.

## **Hantera formelfel**

Det finns två olika typer av problem att skilja på.

En formel kan vara giltig men producera ett kalkylblads‑felresultat såsom `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!` eller `#VALUE!`. I så fall är fel‑tokenen ett cellresultat och kan returneras via `value`.

En formel kan också misslyckas vid parsning, referens, beroende eller stödd‑datatnivå. Aspose.Slides tillhandahåller kalkylblads‑specifika undantag för dessa fall: [CellInvalidFormulaException](https://reference.aspose.com/slides/sv/python-net/aspose.slides.spreadsheet/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/sv/python-net/aspose.slides.spreadsheet/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/sv/python-net/aspose.slides.spreadsheet/cellcircularreferenceexception/) och [CellUnsupportedDataException](https://reference.aspose.com/slides/sv/python-net/aspose.slides.spreadsheet/cellunsupporteddataexception/).

När formler kommer från mallar eller användarinmatning, hantera dessa undantag runt omberäkning och värdeåtkomst:

```python
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.slides.spreadsheet as spreadsheet

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 300)
    workbook = chart.chart_data.chart_data_workbook
    cell = workbook.get_cell(0, "A2")
    cell.formula = "SUM(B2:B5)"

    try:
        workbook.calculate_formulas()
        print(cell.value)
    except spreadsheet.CellInvalidFormulaException as ex:
        print(f"Invalid formula: {ex}")
    except spreadsheet.CellInvalidReferenceException as ex:
        print(f"Invalid cell reference: {ex}")
    except spreadsheet.CellCircularReferenceException as ex:
        print(f"Circular reference: {ex}")
    except spreadsheet.CellUnsupportedDataException as ex:
        print(f"Unsupported spreadsheet data: {ex}")
```

## **Praktiska begränsningar**

Formelstödet i diagram‑kalkylblad är avsett för en definierad delmängd av kalkylbladsberäkningar, inte för fullständig Excel‑kompatibilitet. Ha dessa begränsningar i åtanke när du designar ett rapporterings‑arbetsflöde:

- Använd endast de dokumenterade konstanterna, operatorerna, referenserna och funktionerna när du vill att Aspose.Slides skall omberäkna formler.
- Omberäkna efter att du har ändrat celler som formelresultaten beror på.
- Betrakta cachade värden från laddade presentationer som ögonblicksbilder, inte som en ersättning för omberäkning efter redigering.
- Testa formler från befintliga mallar innan du förlitar dig på deras beräknade värden, särskilt om de använder funktioner utanför den dokumenterade listan.
- För formler som kräver en fullständig kalkylblads­beräkningsmotor, beräkna dem externt och uppdatera sedan diagramarboken med de resulterande värdena.

## **FAQ**

**Vad är skillnaden mellan `formula` och `r1c1_formula`?**

[formula](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/ichartdatacell/formula/) lagrar ett A1‑stilsuttryck såsom `B2-C2`. [r1c1_formula](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/ichartdatacell/r1c1_formula/) lagrar ett R1C1‑stilsuttryck såsom `RC[-2]-RC[-1]`. Använd den notation som bäst matchar hur du genererar eller kopierar formler.

**Behöver jag läsa själva cellen eller dess värde efter beräkning?**

[ChartDataWorkbook.get_cell](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/chartdataworkbook/get_cell/) returnerar en `IChartDataCell`. För att få det beräknade resultatet, läs den cellens [value](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/ichartdatacell/value/)‑egenskap efter omberäkning.

**När ska jag anropa `calculate_formulas`?**

Anropa [calculate_formulas](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/) efter att du har ändrat inmatningsvärden eller formler och innan du är beroende av de beräknade resultaten. Detta uppdaterar värdena för formler som den inbyggda utvärderaren stödjer.

**Stöder Aspose.Slides alla Excel‑funktioner?**

Nej. Den inbyggda utvärderaren stödjer en dokumenterad delmängd av funktioner. Funktioner utanför den delmängden bör inte antas omberäknas korrekt. Om full Excel‑formelkompatibilitet krävs, utför beräkningen med en lämplig kalkylblads‑motor och skriv de sista värdena till diagramarboken.

**Vad händer om en laddad presentation innehåller en osupporterad formel?**

Om diagramdata inte har förändrats kan arbetsboken fortfarande innehålla ett tidigare beräknat cachat värde. Efter att relaterad data har ändrats kan det cachade värdet vara ogiltigt. Att komma åt en cell vars formel inte kan hanteras kan kasta [CellUnsupportedDataException](https://reference.aspose.com/slides/sv/python-net/aspose.slides.spreadsheet/cellunsupporteddataexception/).

**Är formelfelvärden samma sak som Python‑undantag?**

Nej. Ett resultat som `#DIV/0!` är ett kalkylblads‑värde som produceras av en giltig beräkning. Undantag såsom [CellInvalidFormulaException](https://reference.aspose.com/slides/sv/python-net/aspose.slides.spreadsheet/cellinvalidformulaexception/) eller [CellCircularReferenceException](https://reference.aspose.com/slides/sv/python-net/aspose.slides.spreadsheet/cellcircularreferenceexception/) indikerar att formeln inte kan bearbetas normalt.

**Uppdateras ett diagram automatiskt när en formelcell ändras?**

En diagramserie kan referera till arbetsbokens celler. Omberäkna arbetsboken först, spara eller rendera sedan presentationen. Om diagramdatapunkterna refererar till de beräknade cellerna använder diagrammet de uppdaterade cellvärdena; inget separat diagram‑uppdateringsmetod krävs för detta arbetsflöde.

**Kan diagram använda ett externt Excel‑arbetsbok?**

Ja, diagramdata kan konfigureras att använda en extern arbetsbok via diagram‑data‑API:et. Dock avser arbetsflödet som beskrivs i denna artikel diagramarboken och formelunderuppsättningen som utvärderas av Aspose.Slides. Anta inte att [calculate_formulas](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/) ger fullständig omberäkning av godtyckliga formler i en extern XLSX‑fil.

**Kan jag använda formler som refererar till ett annat kalkylblad eller arbetsbok?**

Excel‑stil‑referenser kan finnas i diagramarböcker, men formelutvärderingen är begränsad av den stödjande parsern och funktionsuppsättningen. Om en tvär‑blad‑ eller extern referens är nödvändig, verifiera exakt formel med din målversion av Aspose.Slides. För arbetsflöden som kräver bred Excel‑referenskompatibilitet, beräkna arbetsboken externt och skriv tillbaka de lösta värdena till diagramdatan.

**Ska formelsträngar börja med `=`?**

Aspose.Slides‑API‑exemplen tilldelar uttryck såsom `B2-C2` eller `SUM(B2:B5)` utan inledande `=`. Att använda den formen håller genererade formler i linje med de dokumenterade API‑exemplen.
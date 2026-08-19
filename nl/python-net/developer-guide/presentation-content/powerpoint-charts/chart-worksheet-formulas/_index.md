---
title: Formules voor grafiekwerkbladen toepassen in presentaties met Python
linktitle: Werkbladformules
type: docs
weight: 70
url: /nl/python-net/chart-worksheet-formulas/
keywords:
- grafiek spreadsheet
- grafiek werkblad
- grafiekformule
- werkbladformule
- spreadsheetformule
- grafiekgegevenswerkboek
- formuleberekening
- logische constante
- numerieke constante
- stringconstante
- foutconstante
- rekenkundige operator
- vergelijkingsoperator
- A1-stijl
- R1C1-stijl
- vooraf gedefinieerde functie
- PowerPoint
- presentatie
- Python
- Aspose.Slides
description: "Pas Excel-achtige formules toe in Aspose.Slides voor Python via .NET-grafiekwerkbladen, bereken waarden opnieuw en gebruik de resultaten in PowerPoint-grafieken."
---
## **Overzicht**

PowerPoint‑grafieken slaan hun brongegevens meestal op in een ingebed werkblad. In Aspose.Slides for Python via .NET kunt u dat werkblad benaderen via het grafiekgegevenswerkboek, invoerwaarden schrijven, formules aan cellen toewijzen, ondersteunde formules berekenen en de berekende cellen gebruiken als grafiekgegevens.

Dit artikel legt de volledige formule‑workflow uit: een grafiek maken, het werkblad vullen, A1‑stijl‑ of R1C1‑stijl‑formules toewijzen, ze opnieuw berekenen, de berekende waarden lezen, die cellen aan een grafiekreeks koppelen en de presentatie opslaan. Het beschrijft ook de ondersteunde formule‑syntaxis, de ingebouwde functiebasis, gecachte waarden, niet‑ondersteunde formules en spreadsheet‑specifieke fouten.

## **Grafiekwerkbladen en Formules**

Een grafiekwerkblad bevat de categorieën, serienaam­en en waarden die door een grafiek worden gebruikt. In PowerPoint kunt u het werkblad inspecteren door de grafiekgegevens‑editor te openen:

![PowerPoint-grafiek met het ingebedde werkblad geopend, met categorie- en seriedata](chart-worksheet-formulas_1.png)

In Aspose.Slides wordt het werkblad blootgesteld via de [grafiekgegevenswerkboek](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/ichartdataworkbook/). Gebruik de [formula](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/ichartdatacell/formula/)‑eigenschap voor A1‑stijl‑formules en de [r1c1_formula](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/ichartdatacell/r1c1_formula/)‑eigenschap voor R1C1‑stijl‑formules. Na het wijzigen van invoercellen of formules, roep [calculate_formulas](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/) aan om ondersteunde formules opnieuw te berekenen en de bijbehorende celwaarden bij te werken.

Een berekende cel onthult nog steeds het resultaat via de [value](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/ichartdatacell/value/)‑eigenschap. Dit is belangrijk wanneer u een formule‑resultaat in code moet inspecteren of de cel als een grafiekdatapunt wilt gebruiken.

## **Een grafiek maken en werkbladformules berekenen**

Het volgende voorbeeld demonstreert een end‑to‑end workflow. Het maakt een gegroepeerde kolomgrafiek, wist de voorbeeldgegevens, schrijft kwartaalomzet‑ en kostwaarden, berekent winst met formules, leest de resultaten, gebruikt de berekende cellen als grafiekwaarden en slaat de presentatie op.

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

De grafiekdatapunten verwijzen naar `D2:D4`, dus de grafiek gebruikt de berekende winstwaarden. Er is geen aparte grafiek‑verversingsaanroep in deze workflow: bereken eerst het werkboek opnieuw, gebruik of sla vervolgens de grafiekgegevens op die naar de berekende cellen wijzen.

## **A1‑stijl formules gebruiken**

A1‑notatie identificeert kolommen met letters en rijen met cijfers. Ken A1‑stijl‑expressies toe via [IChartDataCell.formula](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/ichartdatacell/formula/).

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

Gebruikelijke A1‑referentie‑vormen zijn:

| Referentie | Relatief | Absoluut | Gemengd |
|---|---|---|---|
| Cel | `A2` | `$A$2` | `A$2`, `$A2` |
| Rij | `2:2` | `$2:$2` | — |
| Kolom | `A:A` | `$A:$A` | — |
| Gebied | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

Relatieve referenties kunnen wijzigen wanneer een formule wordt verplaatst of gekopieerd door een spreadsheet‑applicatie. Absolute referenties houden beide coördinaten vast, terwijl gemengde referenties alleen een rij of een kolom fixeren.

## **R1C1‑stijl formules gebruiken**

R1C1‑notatie identificeert zowel rijen als kolommen numeriek. Relatieve referenties gebruiken offsets in vierkante haken. Ken deze syntaxis toe via [IChartDataCell.r1c1_formula](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/ichartdatacell/r1c1_formula/).

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

Gebruikelijke R1C1‑referentie‑vormen zijn:

| Referentie | Relatief | Absoluut | Gemengd |
|---|---|---|---|
| Cel | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| Rij | `R[2]` | `R2` | — |
| Kolom | `C[3]` | `C3` | — |
| Gebied | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

Bijvoorbeeld, in cel `D2` betekent `RC[-2]` de cel in dezelfde rij twee kolommen naar links (`B2`).

## **Formule‑constanten en operatoren**

De ingebouwde formule‑evaluator ondersteunt logische waarden, numerieke literal­en, tekst, spreadsheet‑foutwaarden, rekenkundige operatoren en vergelijkingsoperatoren.

### **Constanten en Literalen**

| Type | Voorbeelden | Opmerkingen |
|---|---|---|
| Logisch | `TRUE`, `FALSE` | Kan direct in logische expressies worden gebruikt, bijvoorbeeld `A2=TRUE`. |
| Numeriek | `1`, `0.5`, `.3`, `1E-2` | Zowel gewone als wetenschappelijke notatie worden ondersteund. |
| Tekst | `"abc"`, `"2/3/2020 12:00"` | Tekstliteral­en staan tussen dubbele aanhalingstekens binnen de formule. |
| Foutresultaat | `#DIV/0!`, `#N/A`, `#REF!` | Een geldige formule kan resulteren in een spreadsheet‑foutwaarde in plaats van een normaal resultaat. |

Dit voorbeeld gebruikt verschillende constanten‑typen:

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

    logical_value = workbook.get_cell(0, "B2").value  # Onwaar
    numeric_value = workbook.get_cell(0, "C2").value  # 1.5
    scientific_value = workbook.get_cell(0, "D2").value  # 0.003
    string_value = workbook.get_cell(0, "E2").value  # abc
    error_value = workbook.get_cell(0, "F2").value  # #DIV/0!
```

### **Aritmetische operatoren**

| Operator | Betekenis | Voorbeeld |
|---|---|---|
| `+` | Optelling of unair plusteken | `2+3` |
| `-` | Aftrekking of negatie | `2-3`, `-3` |
| `*` | Vermenigvuldiging | `2*3` |
| `/` | Deling | `2/3` |
| `%` | Procent | `30%` |
| `^` | Exponent | `2^3` |

Gebruik haakjes om de evaluatievolgorde expliciet te maken, bijvoorbeeld `(A2+B2)*C2`.

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

Aspose.Slides bevat een ingebouwde formule‑evaluator voor grafiekwerkbladen, maar het is geen volledige Excel‑rekenengine. De gedocumenteerde functieset is beperkt tot de onderstaande functies. Ga er niet van uit dat een willekeurige Excel‑functie kan worden herberekend door [calculate_formulas](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/).

| Functie | Doel of ondersteunde vorm | Voorbeeld |
|---|---|---|
| `ABS` | Absolute waarde | `ABS(A2)` |
| `AVERAGE` | Reken­kundig gemiddelde | `AVERAGE(B2:B5)` |
| `CEILING` | Rond een getal omhoog af naar een veelvoud | `CEILING(A2,5)` |
| `CHOOSE` | Selecteer een waarde op index | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | Samenvoegen van tekstwaarden | `CONCAT(A2,B2)` |
| `CONCATENATE` | Samenvoegen van tekstwaarden | `CONCATENATE(A2," ",B2)` |
| `DATE` | Maak een datumwaarde met het 1900‑datumssysteem | `DATE(2026,8,19)` |
| `DAYS` | Retourneer het aantal dagen tussen datums | `DAYS(B2,A2)` |
| `FIND` | Zoek een tekstwaarde binnen een andere | `FIND("-",A2)` |
| `FINDB` | Byte‑georiënteerd tekst zoeken | `FINDB("a",A2)` |
| `IF` | Voorwaardelijk resultaat | `IF(A2>0,A2,0)` |
| `INDEX` | Referentie‑vorm | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | Vector‑vorm | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | Vector‑vorm | `MATCH(A2,B2:B5,0)` |
| `MAX` | Maximumwaarde | `MAX(B2:B5)` |
| `SUM` | Som van waarden | `SUM(B2:B5)` |
| `VLOOKUP` | Verticaal zoeken | `VLOOKUP(A2,B2:D10,3,FALSE)` |

De beperkingen in de tabel zijn significant: `INDEX` wordt gedocumenteerd in referentie‑vorm, terwijl `LOOKUP` en `MATCH` in hun vector‑vormen staan. `DATE` gebruikt het 1900‑datumssysteem. Functies die hier niet worden vermeld, moeten als niet‑ondersteund door de Aspose.Slides‑formula‑evaluator worden beschouwd, tenzij ze afzonderlijk zijn gedocumenteerd.

## **Herberekening en gecachte waarden**

Spreadsheet‑bestanden bewaren meestal zowel een formule als de laatst berekende waarde. Aspose.Slides kan daarom een gecachte waarde lezen via [IChartDataCell.value](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/ichartdatacell/value/) wanneer een presentatie wordt geladen en de betreffende grafiekgegevens niet zijn gewijzigd.

Na het wijzigen van invoercellen of formules, vertrouw niet op een oude gecachte uitkomst. Roep [ChartDataWorkbook.calculate_formulas](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/) aan vóór het lezen van berekende waarden of het opslaan van grafiekgegevens die ervan afhangen.

Voor formules buiten de ondersteunde subset kan Aspose.Slides de formule mogelijk niet parseren of de afhankelijkheden niet vaststellen. Als het werkboek is aangepast, kan de vorige gecachte waarde niet langer als betrouwbaar worden beschouwd. In die situatie kan het lezen van de waarde van een cel met niet‑ondersteunde data een [CellUnsupportedDataException](https://reference.aspose.com/slides/nl/python-net/aspose.slides.spreadsheet/cellunsupporteddataexception/) veroorzaken.

Als uw grafiek afhankelijk is van Excel‑functies die Aspose.Slides niet evalueert, bereken die formules met een spreadsheet‑engine die ze ondersteunt en schrijf de resulterende waarden terug naar het grafiekwerkboek. Vervang niet‑ondersteunde formules niet door geschatte waarden.

## **Formulefouten afhandelen**

Er zijn twee verschillende soorten problemen te onderscheiden.

Een formule kan geldig zijn maar een spreadsheet‑foutresultaat opleveren, zoals `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!` of `#VALUE!`. In dat geval is het fout‑token een celresultaat en kan via `value` worden geretourneerd.

Een formule kan ook falen tijdens het parseren, bij referenties, afhankelijkheden of een niet‑ondersteund‑datumniveau. Aspose.Slides biedt spreadsheet‑specifieke uitzonderingen voor deze gevallen: [CellInvalidFormulaException](https://reference.aspose.com/slides/nl/python-net/aspose.slides.spreadsheet/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/nl/python-net/aspose.slides.spreadsheet/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/nl/python-net/aspose.slides.spreadsheet/cellcircularreferenceexception/) en [CellUnsupportedDataException](https://reference.aspose.com/slides/nl/python-net/aspose.slides.spreadsheet/cellunsupporteddataexception/).

Wanneer formules afkomstig zijn van sjablonen of gebruikersinvoer, handel deze uitzonderingen af rond herberekening en het benaderen van waarden:

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

## **Praktische beperkingen**

De formule‑ondersteuning in grafiekwerkbladen is bedoeld voor een gedefinieerde subset van spreadsheet‑berekeningen, niet voor volledige Excel‑compatibiliteit. Houd deze beperkingen in gedachten bij het ontwerpen van een rapportage‑workflow:

- Gebruik alleen de gedocumenteerde constanten, operatoren, referenties en functies wanneer u wilt dat Aspose.Slides formules opnieuw berekent.
- Bereken opnieuw na het wijzigen van cellen waarvan de formule‑resultaten afhangen.
- Beschouw gecachte waarden uit geladen presentaties als momentopnames, niet als vervanging voor herberekening na bewerkingen.
- Test formules uit bestaande sjablonen voordat u vertrouwt op hun berekende waarden, vooral wanneer ze functies gebruiken die niet in de documentatie staan.
- Voor formules die een volledige spreadsheet‑rekenengine nodig hebben, berekent u ze extern en werkt u daarna het grafiekwerkboek bij met de resulterende waarden.

## **FAQ**

**Wat is het verschil tussen `formula` en `r1c1_formula`?**

[formula](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/ichartdatacell/formula/) slaat een A1‑stijl‑expressie op, bijvoorbeeld `B2-C2`. [r1c1_formula](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/ichartdatacell/r1c1_formula/) slaat een R1C1‑stijl‑expressie op, bijvoorbeeld `RC[-2]-RC[-1]`. Gebruik de notatie die het beste past bij hoe u formules genereert of kopieert.

**Moet ik de cel zelf lezen of de waarde na berekening?**

[ChartDataWorkbook.get_cell](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartdataworkbook/get_cell/) retourneert een `IChartDataCell`. Om het berekende resultaat te verkrijgen, leest u de [value](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/ichartdatacell/value/)‑eigenschap van die cel na herberekening.

**Wanneer moet ik `calculate_formulas` aanroepen?**

Roep [calculate_formulas](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/) aan nadat u invoerwaarden of formules hebt gewijzigd en voordat u afhankelijk bent van de berekende resultaten. Dit werkt de waarden van formules die de ingebouwde evaluator ondersteunt bij.

**Ondersteunt Aspose.Slides elke Excel‑functie?**

Nee. De ingebouwde evaluator ondersteunt alleen een gedocumenteerde subset van functies. Functies buiten die subset moeten niet worden verondersteld correct te herberekenen. Als volledige Excel‑formule‑compatibiliteit vereist is, voert u de berekening uit met een geschikte spreadsheet‑engine en schrijft u de definitieve waarden naar het grafiekwerkboek.

**Wat gebeurt er als een geladen presentatie een niet‑ondersteunde formule bevat?**

Als de grafiekgegevens niet zijn gewijzigd, kan het werkboek nog een eerder berekende gecachte waarde bevatten. Nadat gerelateerde data is aangepast, kan die gecachte waarde mogelijk niet meer geldig zijn. Het benaderen van een cel waarvan de formule niet kan worden verwerkt, kan een [CellUnsupportedDataException](https://reference.aspose.com/slides/nl/python-net/aspose.slides.spreadsheet/cellunsupporteddataexception/) veroorzaken.

**Zijn formule‑foutwaarden hetzelfde als Python‑exceptions?**

Nee. Een resultaat zoals `#DIV/0!` is een spreadsheet‑waarde die wordt geproduceerd door een geldige berekening. Exceptions zoals [CellInvalidFormulaException](https://reference.aspose.com/slides/nl/python-net/aspose.slides.spreadsheet/cellinvalidformulaexception/) of [CellCircularReferenceException](https://reference.aspose.com/slides/nl/python-net/aspose.slides.spreadsheet/cellcircularreferenceexception/) geven aan dat de formule niet normaal kan worden verwerkt.

**Wordt een grafiek automatisch bijgewerkt wanneer een formulecel wijzigt?**

Een grafiekreeks kan verwijzen naar werkboekcellen. Bereken eerst het werkboek opnieuw, sla daarna de presentatie op of render deze. Als de grafiekdatapunten naar de berekende cellen verwijzen, gebruikt de grafiek die bijgewerkte celwaarden; een aparte grafiek‑verversingsmethode is niet nodig voor deze workflow.

**Kunnen grafieken een extern Excel‑werkboek gebruiken?**

Ja, grafiekgegevens kunnen worden geconfigureerd om een extern werkboek te gebruiken via de grafiek‑gegevens‑API. Echter, de formule‑berekeningsworkflow die in dit artikel wordt beschreven, heeft betrekking op het grafiekwerkboek en de formule‑subset die door Aspose.Slides wordt geëvalueerd. Ga er niet van uit dat [calculate_formulas](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/) volledige herberekening van willekeurige formules in een extern XLSX‑bestand biedt.

**Kan ik formules gebruiken die naar een ander werkblad of werkboek verwijzen?**

Excel‑stijl‑referenties kunnen in grafiekwerkboeken voorkomen, maar formule‑evaluatie is beperkt tot de ondersteunde parser en functieset. Als een cross‑sheet‑ of externe referentie essentieel is, controleer dan die exacte formule met uw doel‑Aspose.Slides‑versie. Voor workflows die brede Excel‑referentie‑compatibiliteit vereisen, berekent u het werkboek extern en schrijft u de opgeloste waarden terug naar de grafiekgegevens.

**Moeten formule‑strings beginnen met `=`?**

De Aspose.Slides‑API‑voorbeelden wijzen expressies toe zoals `B2-C2` of `SUM(B2:B5)` zonder een leidende `=`. Het gebruik van die vorm houdt gegenereerde formules consistent met de gedocumenteerde API‑voorbeelden.
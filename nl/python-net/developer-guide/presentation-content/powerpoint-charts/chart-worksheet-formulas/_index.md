---
title: Formules voor diagramwerkbladen toepassen in presentaties met Python
linktitle: Werkbladformules
type: docs
weight: 70
url: /nl/python-net/chart-worksheet-formulas/
keywords:
- grafiek werkblad
- grafiek werkblad
- grafiekformule
- werkbladformule
- werkbladformule
- grafiekgegevenswerkboek
- formuleberekening
- voorkeurstaal
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
- Python
- Aspose.Slides
description: "Pas Excel‑achtige formules toe in Aspose.Slides voor Python via .NET diagramwerkbladen, bereken waarden opnieuw en gebruik de resultaten in PowerPoint‑diagrammen."
---
## **Overzicht**

PowerPoint-diagrammen slaan hun brongegevens meestal op in een ingesloten werkblad. In Aspose.Slides for Python via .NET kun je dat werkblad benaderen via het **werkblad met grafiekgegevens**, invoerwaarden schrijven, formules aan cellen toewijzen, ondersteunde formules berekenen en de berekende cellen gebruiken als diagramgegevens.

Dit artikel legt de volledige formule‑workflow uit: een diagram maken, het werkblad vullen, A1‑stijl‑ of R1C1‑stijl‑formules toewijzen, ze opnieuw berekenen, de berekende waarden lezen, die cellen koppelen aan een diagramreeks en de presentatie opslaan. Het beschrijft ook de ondersteunde formulesyntaxis, de ingebouwde subset van functies, gecachete waarden, niet‑ondersteunde formules en spreadsheet‑specifieke fouten.

## **Diagramwerkbladen en Formules**

Een diagramwerkblad bevat de categorieën, reeksnamen en waarden die door een diagram worden gebruikt. In PowerPoint kun je het werkblad inspecteren door de diagram‑data‑editor te openen:

![PowerPoint-diagram met geopend ingesloten werkblad, waarin categorie‑ en reeksen‑data worden getoond](chart-worksheet-formulas_1.png)

In Aspose.Slides wordt het werkblad blootgesteld via het [werkblad met grafiekgegevens](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/ichartdataworkbook/). Gebruik de [formula](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/ichartdatacell/formula/)‑eigenschap voor A1‑stijl‑formules en de [r1c1_formula](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/ichartdatacell/r1c1_formula/)‑eigenschap voor R1C1‑stijl‑formules. Nadat je invoercellen of formules hebt gewijzigd, roep je [calculate_formulas](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/) aan om ondersteunde formules opnieuw te berekenen en de bijbehorende celwaarden bij te werken.

Een berekende cel geeft nog steeds zijn resultaat weer via de [value](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/ichartdatacell/value/)‑eigenschap. Dit is belangrijk wanneer je een formule‑resultaat in code wilt inspecteren of de cel wilt gebruiken als diagramdatumpunt.

## **Een Diagram Maken en Werkblad‑Formules Berekenen**

Het volgende voorbeeld toont een end‑to‑end‑workflow. Het maakt een gegroepeerd kolomdiagram, wist de voorbeelddata, schrijft kwartaalomzet‑ en kostengegevens, berekent winst met formules, leest de resultaten, gebruikt de berekende cellen als diagramwaarden en slaat de presentatie op.

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

De diagramdatapunten verwijzen naar `D2:D4`, zodat het diagram de berekende winstwaarden gebruikt. Er is geen aparte diagram‑verversingsaanroep in deze workflow: bereken eerst het werkboek, gebruik daarna of sla de diagramdata op die naar de berekende cellen verwijst.

## **A1‑Stijl‑Formules Gebruiken**

A1‑notatie identificeert kolommen met letters en rijen met cijfers. Wijs A1‑stijl‑expressies toe via [IChartDataCell.formula](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/ichartdatacell/formula/).

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

Veelvoorkomende A1‑referentievormen zijn:

| Referentie | Relatief | Absoluut | Gemengd |
|---|---|---|---|
| Cel | `A2` | `$A$2` | `A$2`, `$A2` |
| Rij | `2:2` | `$2:$2` | — |
| Kolom | `A:A` | `$A:$A` | — |
| Bereik | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

Relatieve referenties kunnen veranderen wanneer een formule wordt verplaatst of gekopieerd door een spreadsheet‑applicatie. Absolute referenties houden beide coördinaten vast, terwijl gemengde referenties alleen een rij of een kolom vastzetten.

## **R1C1‑Stijl‑Formules Gebruiken**

R1C1‑notatie identificeert zowel rijen als kolommen numeriek. Relatieve referenties gebruiken offset‑waarden tussen vierkante haken. Wijs deze syntaxis toe via [IChartDataCell.r1c1_formula](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/ichartdatacell/r1c1_formula/).

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

Veelvoorkomende R1C1‑referentievormen zijn:

| Referentie | Relatief | Absoluut | Gemengd |
|---|---|---|---|
| Cel | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| Rij | `R[2]` | `R2` | — |
| Kolom | `C[3]` | `C3` | — |
| Bereik | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

Bijvoorbeeld, in cel `D2` betekent `RC[-2]` de cel in dezelfde rij twee kolommen naar links (`B2`).

## **Formule‑Constanten en Operatoren**

De ingebouwde formule‑evaluator ondersteunt logische waarden, numerieke literal, strings, spreadsheet‑foutwaarden, rekenkundige operatoren en vergelijkingsoperatoren.

### **Constanten en Literal’s**

| Type | Voorbeelden | Opmerkingen |
|---|---|---|
| Logisch | `TRUE`, `FALSE` | Kan direct worden gebruikt in logische expressies zoals `A2=TRUE`. |
| Numeriek | `1`, `0.5`, `.3`, `1E-2` | Gewone en wetenschappelijke notatie worden ondersteund. |
| String | `"abc"`, `"2/3/2020 12:00"` | Tekstliteral staat tussen dubbele aanhalingstekens binnen de formule. |
| Foutresultaat | `#DIV/0!`, `#N/A`, `#REF!` | Een geldige formule kan evalueren tot een spreadsheet‑foutwaarde in plaats van een normaal resultaat. |

Dit voorbeeld gebruikt verschillende constant‑types:

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

### **Rekenkundige Operatoren**

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

Aspose.Slides bevat een ingebouwde formule‑evaluator voor diagram‑werkbladen, maar het is geen volledige Excel‑rekenmachine. De gedocumenteerde functieverzameling is beperkt tot de onderstaande functies. Ga er niet van uit dat een willekeurige Excel‑functie kan worden gerecalculeerd door [calculate_formulas](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/).

| Functie | Doel of ondersteunde vorm | Voorbeeld |
|---|---|---|
| `ABS` | Absolute waarde | `ABS(A2)` |
| `AVERAGE` | Rekenkundig gemiddelde | `AVERAGE(B2:B5)` |
| `CEILING` | Afronden naar boven tot een veelvoud | `CEILING(A2,5)` |
| `CHOOSE` | Een waarde selecteren op index | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | Tekstwaarden samenvoegen | `CONCAT(A2,B2)` |
| `CONCATENATE` | Tekstwaarden samenvoegen | `CONCATENATE(A2," ",B2)` |
| `DATE` | Een datumwaarde maken met het 1900‑datumsysteem | `DATE(2026,8,19)` |
| `DAYS` | Aantal dagen tussen twee data | `DAYS(B2,A2)` |
| `FIND` | Eén tekstwaarde binnen een andere zoeken | `FIND("-",A2)` |
| `FINDB` | Byte‑georiënteerd tekst zoeken | `FINDB("a",A2)` |
| `IF` | Voorwaardelijk resultaat | `IF(A2>0,A2,0)` |
| `INDEX` | Referentie‑vorm | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | Vector‑vorm | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | Vector‑vorm | `MATCH(A2,B2:B5,0)` |
| `MAX` | Maximale waarde | `MAX(B2:B5)` |
| `SUM` | Som van waarden | `SUM(B2:B5)` |
| `VLOOKUP` | Verticale zoekopdracht | `VLOOKUP(A2,B2:D10,3,FALSE)` |

De beperkingen in de tabel zijn belangrijk: `INDEX` wordt gedocumenteerd in referentie‑vorm, terwijl `LOOKUP` en `MATCH` in hun vector‑vorm staan. `DATE` gebruikt het 1900‑datumsysteem. Functies die hier niet staan, moeten worden beschouwd als niet‑ondersteund door de Aspose.Slides‑formule‑evaluator, tenzij ze apart gedocumenteerd zijn.

## **Formules Berekenen met een Voorkeurstaal**

Sommige werkboek‑functies interpreteren tekst volgens cultuur‑specifieke regels. Dit is vooral belangrijk voor functies bedoeld voor talen die dubbel‑byte‑karaktersets (DBCS) gebruiken. Om dergelijke formules correct te berekenen, maak je een [LoadOptions](https://reference.aspose.com/slides/nl/python-net/aspose.slides/loadoptions/), stel je [SpreadsheetOptions.preferred_culture](https://reference.aspose.com/slides/nl/python-net/aspose.slides/spreadsheetoptions/) in via [LoadOptions.spreadsheet_options](https://reference.aspose.com/slides/nl/python-net/aspose.slides/loadoptions/spreadsheet_options/), en laad je daarna de presentatie.

Het onderstaande voorbeeld selecteert de Japanse cultuur, opent een presentatie met de geconfigureerde laadopties, en roept [ChartDataWorkbook.calculate_formulas](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/) aan voor elk diagramwerkboek:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

load_options = slides.LoadOptions()
load_options.spreadsheet_options.preferred_culture = "ja-JP"

with slides.Presentation("presentation.pptx", load_options) as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if isinstance(shape, charts.Chart):
                shape.chart_data.chart_data_workbook.calculate_formulas()
```

De voorkeurstaal maakt deel uit van de presentatielaad‑configuratie, dus stel je die in vóór het aanmaken van de [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/)‑instantie. Gebruik de cultuur die de werkboek‑formules verwachten; bijvoorbeeld `ja-JP` voor formules die de Japanse DBCS‑regels moeten volgen.

## **Herberekening en Geprepareerde Waarden**

Spreadsheet‑bestanden slaan vaak zowel een formule als de laatst berekende waarde op. Aspose.Slides kan daarom een gecachte waarde lezen van [IChartDataCell.value](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/ichartdatacell/value/) wanneer een presentatie wordt geladen en de betreffende diagramdata niet is gewijzigd.

Nadat je invoercellen of formules wijzigt, mag je niet vertrouwen op een oude gecachte uitkomst. Roep [ChartDataWorkbook.calculate_formulas](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/) aan voordat je berekende waarden leest of diagramdata opslaat die daarvan afhankelijk is.

Voor formules buiten de ondersteunde subset kan Aspose.Slides de formule niet parseren of de afhankelijkheden niet vaststellen. Als het werkboek is aangepast, kan de eerdere gecachte waarde niet langer als betrouwbaar worden beschouwd. In dat geval kan het lezen van de waarde van een cel met niet‑ondersteunde data een [CellUnsupportedDataException](https://reference.aspose.com/slides/nl/python-net/aspose.slides.spreadsheet/cellunsupporteddataexception/) veroorzaken.

Als je diagram afhankelijk is van Excel‑functies die Aspose.Slides niet evalueert, bereken die formules dan met een spreadsheet‑engine die ze ondersteunt en schrijf de resulterende waarden terug naar het diagramwerkboek. Vervang niet‑ondersteunde formules niet door geraden waarden.

## **Formule‑Fouten Afhandelen**

Er zijn twee verschillende soorten problemen te onderscheiden.

Een formule kan geldig zijn maar een spreadsheet‑foutresultaat opleveren, zoals `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!` of `#VALUE!`. In dat geval is het fout‑token een celresultaat en kan het via `value` worden geretourneerd.

Een formule kan ook falen tijdens het parsen, bij referenties, afhankelijkheden of omdat de data niet ondersteund wordt. Aspose.Slides biedt spreadsheet‑specifieke uitzonderingen voor deze gevallen: [CellInvalidFormulaException](https://reference.aspose.com/slides/nl/python-net/aspose.slides.spreadsheet/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/nl/python-net/aspose.slides.spreadsheet/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/nl/python-net/aspose.slides.spreadsheet/cellcircularreferenceexception/) en [CellUnsupportedDataException](https://reference.aspose.com/slides/nl/python-net/aspose.slides.spreadsheet/cellunsupporteddataexception/).

Wanneer formules afkomstig zijn uit sjablonen of gebruikersinvoer, verwerk dan deze uitzonderingen rondom herberekening en waarde‑toegang:

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

## **Praktische Beperkingen**

De formulesupport in diagramwerkbladen is bedoeld voor een gedefinieerde subset van spreadsheet‑berekeningen, niet voor volledige Excel‑compatibiliteit. Houd deze beperkingen in gedachten bij het ontwerpen van een rapportage‑workflow:

- Gebruik alleen de gedocumenteerde constanten, operatoren, referenties en functies wanneer je wilt dat Aspose.Slides formules herberekent.
- Herbereken na het wijzigen van cellen waarvan de formule‑resultaten afhangen.
- Beschouw gecachte waarden uit geladen presentaties als een momentopname, niet als vervanging voor herberekening na bewerkingen.
- Test formules uit bestaande sjablonen voordat je vertrouwt op hun berekende waarden, vooral wanneer ze functies buiten de gedocumenteerde lijst gebruiken.
- Voor formules die een volledige spreadsheet‑rekenmachine vereisen, bereken ze extern en werk daarna het diagramwerkboek bij met de resulterende waarden.

## **FAQ**

**Wat is het verschil tussen `formula` en `r1c1_formula`?**

[formula](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/ichartdatacell/formula/) slaat een A1‑stijl‑expressie op, zoals `B2-C2`. [r1c1_formula](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/ichartdatacell/r1c1_formula/) slaat een R1C1‑stijl‑expressie op, zoals `RC[-2]-RC[-1]`. Gebruik de notatie die het beste past bij hoe je formules genereert of kopieert.

**Moet ik de cel zelf of de waarde lezen na berekening?**

[ChartDataWorkbook.get_cell](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartdataworkbook/get_cell/) retourneert een `IChartDataCell`. Om het berekende resultaat te verkrijgen, lees je de [value](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/ichartdatacell/value/)‑eigenschap van die cel na herberekening.

**Wanneer moet ik `calculate_formulas` aanroepen?**

Roep [calculate_formulas](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/) aan nadat je invoerwaarden of formules hebt gewijzigd en voordat je afhankelijk bent van de berekende resultaten. Dit werkt de waarden van formules die de ingebouwde evaluator ondersteunt bij.

**Ondersteunt Aspose.Slides elke Excel‑functie?**

Nee. De ingebouwde evaluator ondersteunt een gedocumenteerde subset van functies. Functies buiten die subset moeten niet worden verondersteld correct te worden herberekend. Als volledige Excel‑formule‑compatibiliteit vereist is, voer de berekening dan uit met een geschikte spreadsheet‑engine en schrijf de eindwaarden naar het diagramwerkboek.

**Wat gebeurt er als een geladen presentatie een niet‑ondersteunde formule bevat?**

Als de diagramdata niet is gewijzigd, kan het werkboek nog steeds een eerder berekende gecachte waarde bevatten. Nadat gerelateerde data is aangepast, is die gecachte waarde mogelijk niet meer geldig. Het benaderen van een cel waarvan de formule niet kan worden verwerkt, kan een [CellUnsupportedDataException](https://reference.aspose.com/slides/nl/python-net/aspose.slides.spreadsheet/cellunsupporteddataexception/) veroorzaken.

**Zijn formule‑foutwaarden hetzelfde als Python‑uitzonderingen?**

Nee. Een resultaat zoals `#DIV/0!` is een spreadsheet‑waarde die voortkomt uit een geldige berekening. Uitzonderingen zoals [CellInvalidFormulaException](https://reference.aspose.com/slides/nl/python-net/aspose.slides.spreadsheet/cellinvalidformulaexception/) of [CellCircularReferenceException](https://reference.aspose.com/slides/nl/python-net/aspose.slides.spreadsheet/cellcircularreferenceexception/) geven aan dat de formule niet normaal kan worden verwerkt.

**Werkt een diagram automatisch bij wanneer een formulecel verandert?**

Een diagramreeks kan verwijzen naar werkboekcellen. Bereken eerst het werkboek, sla daarna de presentatie op of render deze. Als de diagramdatapunten naar de berekende cellen verwijzen, gebruikt het diagram die bijgewerkte celwaarden; er is geen aparte diagram‑verversingsmethode vereist voor deze workflow.

**Kunnen diagrammen een extern Excel‑werkboek gebruiken?**

Ja, diagramdata kan worden geconfigureerd om een extern werkboek te gebruiken via de diagram‑data‑API. De hier beschreven formule‑berekeningsworkflow betreft echter het diagramwerkboek en de formule‑subset die door Aspose.Slides wordt geëvalueerd. Ga er niet van uit dat [calculate_formulas](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/) volledige herberekening van willekeurige formules in een extern XLSX‑bestand biedt.

**Kan ik formules gebruiken die verwijzen naar een ander werkblad of werkboek?**

Excel‑stijl‑referenties kunnen in diagramwerkboeken voorkomen, maar de formule‑evaluatie is beperkt tot de ondersteunde parser en functieverzameling. Als een cross‑sheet‑ of externe verwijzing essentieel is, controleer dan die exacte formule met jouw versie van Aspose.Slides. Voor workflows die brede Excel‑referentie‑compatibiliteit vereisen, bereken het werkboek extern en schrijf de opgeloste waarden terug naar de diagramdata.

**Moeten formule‑strings beginnen met `=`?**

De Aspose.Slides‑API‑voorbeelden wijzen expressies toe zoals `B2-C2` of `SUM(B2:B5)` zonder een leidende `=`. Het gebruik van die vorm houdt gegenereerde formules consistent met de gedocumenteerde API‑voorbeelden.
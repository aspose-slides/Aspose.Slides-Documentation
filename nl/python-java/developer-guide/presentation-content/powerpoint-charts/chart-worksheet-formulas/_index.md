---
title: Formules voor grafiekwerkbladen toepassen in presentaties met Python via Java
linktitle: Werkbladformules
type: docs
weight: 70
url: /nl/python-java/chart-worksheet-formulas/
keywords:
- grafiek spreadsheet
- grafiek werkblad
- grafiekformule
- werkbladformule
- spreadsheetformule
- grafiekdataboek
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
- A1-stijl
- R1C1-stijl
- vooraf gedefinieerde functie
- PowerPoint
- presentatie
- Python
- Java
- Aspose.Slides
description: "Excel-achtige formules toepassen in Aspose.Slides voor Python via Java grafiekwerkbladen, waarden opnieuw berekenen en de resultaten gebruiken in PowerPoint-grafieken."
---
## **Overzicht**

PowerPoint-diagrammen slaan hun brongegevens meestal op in een ingesloten werkblad. In Aspose.Slides for Python via Java kun je dat werkblad benaderen via de grafiekdataboek, invoergegevens schrijven, formules toewijzen aan cellen, ondersteunde formules berekenen en de berekende cellen gebruiken als grafiekgegevens.

Dit artikel legt de volledige formule-workflow uit: een grafiek maken, het werkblad vullen, A1-stijl- of R1C1-stijl-formules toewijzen, ze opnieuw berekenen, de berekende waarden lezen, die cellen koppelen aan een grafiekreeks en de presentatie opslaan. Het beschrijft ook de ondersteunde formulesyntaxis, de ingebouwde functie-subset, gecachete waarden, niet-ondersteunde formules en spreadsheet-specifieke fouten.

## **Grafiekwerkbladen en Formules**

Een grafiekwerkblad bevat de categorieën, reeksnamen en waarden die door een grafiek worden gebruikt. In PowerPoint kun je het werkblad inspecteren door de grafiekgegevens-editor te openen:

![PowerPoint-grafiek met geopend ingesloten werkblad, met categorie- en reeksengegevens](chart-worksheet-formulas_1.png)

In Aspose.Slides wordt het werkblad blootgesteld via de klasse [ChartDataWorkbook](https://reference.aspose.com/slides/nl/python-java/aspose.slides/chartdataworkbook/) . Gebruik [ChartDataCell.setFormula](https://reference.aspose.com/slides/nl/python-java/aspose.slides/chartdatacell/#setFormula) voor A1-stijl-formules en [ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/nl/python-java/aspose.slides/chartdatacell/#setR1C1Formula) voor R1C1-stijl-formules. Nadat je invoercellen of formules hebt gewijzigd, roep je [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/nl/python-java/aspose.slides/chartdataworkbook/#calculateFormulas) aan om ondersteunde formules opnieuw te berekenen en de bijbehorende celwaarden bij te werken.

Een berekende cel geeft nog steeds zijn resultaat weer via [ChartDataCell.getValue](https://reference.aspose.com/slides/nl/python-java/aspose.slides/chartdatacell/#getValue) . Dit is belangrijk wanneer je een formule-resultaat in code moet inspecteren of de cel als een grafiekdatapunt wilt gebruiken.

## **Een grafiek maken en werkbladformules berekenen**

Het onderstaande voorbeeld toont een end-to-end-workflow. Het maakt een gegroepeerde kolomgrafiek, wist de voorbeeldgegevens, schrijft kwartaalomzet- en uitgavenwaarden, berekent winst met formules, leest de resultaten, gebruikt de berekende cellen als grafiekwaarden en slaat de presentatie op.

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

De grafiekdatapunten verwijzen naar `D2:D4`, zodat de grafiek de berekende winstwaarden gebruikt. Er is geen aparte grafiek-verversingsaanroep in deze workflow: bereken het werkboek eerst opnieuw, en gebruik of sla daarna de grafiekgegevens op die naar de berekende cellen wijzen.

## **A1-stijl-formules gebruiken**

De A1-notatie identificeert kolommen met letters en rijen met cijfers. Wijs A1-stijl-expressies toe via [ChartDataCell.setFormula](https://reference.aspose.com/slides/nl/python-java/aspose.slides/chartdatacell/#setFormula) .

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

Veelvoorkomende A1-referentie-vormen zijn:

| Referentie | Relatief | Absoluut | Gemengd |
|---|---|---|---|
| Cel | `A2` | `$A$2` | `A$2`, `$A2` |
| Rij | `2:2` | `$2:$2` | — |
| Kolom | `A:A` | `$A:$A` | — |
| Bereik | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

Relatieve referenties kunnen veranderen wanneer een formule door een spreadsheet-toepassing wordt verplaatst of gekopieerd. Absolute referenties houden beide coördinaten vast, terwijl gemengde referenties alleen een rij of een kolom vastzetten.

## **R1C1-stijl-formules gebruiken**

De R1C1-notatie identificeert zowel rijen als kolommen numeriek. Relatieve referenties gebruiken offset-waarden tussen vierkante haken. Wijs deze syntaxis toe via [ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/nl/python-java/aspose.slides/chartdatacell/#setR1C1Formula) .

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

Veelvoorkomende R1C1-referentie-vormen zijn:

| Referentie | Relatief | Absoluut | Gemengd |
|---|---|---|---|
| Cel | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| Rij | `R[2]` | `R2` | — |
| Kolom | `C[3]` | `C3` | — |
| Bereik | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

Bijvoorbeeld, in cel `D2` betekent `RC[-2]` de cel in dezelfde rij twee kolommen naar links (`B2`).

## **Formule-constanten en operatoren**

De ingebouwde formule-evaluator ondersteunt logische waarden, numerieke literals, strings, spreadsheet-foutwaarden, rekenkundige operatoren en vergelijkingsoperatoren.

### **Constanten en literalen**

| Type | Voorbeelden | Opmerkingen |
|---|---|---|
| Logisch | `TRUE`, `FALSE` | Kan direct worden gebruikt in logische uitdrukkingen zoals `A2=TRUE`. |
| Numeriek | `1`, `0.5`, `.3`, `1E-2` | Gebruik van gewone en wetenschappelijke notatie wordt ondersteund. |
| Tekst | `"abc"`, `"2/3/2020 12:00"` | Tekst-literals worden tussen dubbele aanhalingstekens geplaatst binnen de formule. |
| Foutresultaat | `#DIV/0!`, `#N/A`, `#REF!` | Een geldige formule kan evalueren tot een spreadsheet-foutwaarde in plaats van een normaal resultaat. |

Dit voorbeeld gebruikt verschillende constanten:

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

    logical_value = workbook.getCell(0, "B2").getValue() # False
    numeric_value = workbook.getCell(0, "C2").getValue() # 1.5
    scientific_value = workbook.getCell(0, "D2").getValue() # 0.003
    string_value = workbook.getCell(0, "E2").getValue() # abc
    error_value = workbook.getCell(0, "F2").getValue() # #DIV/0!
finally:
    presentation.dispose()
```

### **Rekenoperatoren**

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

Vergelijkingsuitdrukkingen geven logische waarden terug.

| Operator | Betekenis | Voorbeeld |
|---|---|---|
| `=` | Gelijk aan | `A2=3` |
| `<>` | Niet gelijk aan | `A2<>3` |
| `>` | Groter dan | `A2>3` |
| `>=` | Groter dan of gelijk aan | `A2>=3` |
| `<` | Kleiner dan | `A2<3` |
| `<=` | Kleiner dan of gelijk aan | `A2<=3` |

## **Ondersteunde Vooraf gedefinieerde Functies**

Aspose.Slides bevat een ingebouwde formule-evaluator voor grafiekwerkbladen, maar het is geen volledige Excel-rekenmachine. De gedocumenteerde functiebasis is beperkt tot de onderstaande functies. Neem niet aan dat een willekeurige Excel-functie herberekend kan worden door [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/nl/python-java/aspose.slides/chartdataworkbook/#calculateFormulas) .

| Functie | Doel of ondersteunde vorm | Voorbeeld |
|---|---|---|
| `ABS` | Absolute waarde | `ABS(A2)` |
| `AVERAGE` | Rekenkundig gemiddelde | `AVERAGE(B2:B5)` |
| `CEILING` | Afronden naar boven op een veelvoud | `CEILING(A2,5)` |
| `CHOOSE` | Selecteer een waarde op index | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | Tekstwaarden samenvoegen | `CONCAT(A2,B2)` |
| `CONCATENATE` | Tekstwaarden samenvoegen | `CONCATENATE(A2," ",B2)` |
| `DATE` | Datumwaarde maken volgens 1900-datumsysteem | `DATE(2026,8,19)` |
| `DAYS` | Het aantal dagen tussen data teruggeven | `DAYS(B2,A2)` |
| `FIND` | Zoek een tekstwaarde in een andere | `FIND("-",A2)` |
| `FINDB` | Byte-georienteerd zoeken | `FINDB("a",A2)` |
| `IF` | Voorwaardelijk resultaat | `IF(A2>0,A2,0)` |
| `INDEX` | Referentie-vorm | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | Vector-vorm | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | Vector-vorm | `MATCH(A2,B2:B5,0)` |
| `MAX` | Maximumwaarde | `MAX(B2:B5)` |
| `SUM` | Som van waarden | `SUM(B2:B5)` |
| `VLOOKUP` | Verticale opzoeking | `VLOOKUP(A2,B2:D10,3,FALSE)` |

De beperkingen in de tabel zijn belangrijk: `INDEX` is gedocumenteerd in referentie-vorm, terwijl `LOOKUP` en `MATCH` zijn gedocumenteerd in hun vector-vormen. `DATE` gebruikt het 1900-datumsysteem. Functies en kenmerken die hier niet staan, moeten worden beschouwd als niet-ondersteund door de Aspose.Slides-formule-evaluator, tenzij ze afzonderlijk worden gedocumenteerd.

## **Formules Berekenen met een Voorkeurscultuur**

Sommige grafiek-werkboekfuncties interpreteren tekst volgens cultuurspecifieke regels. Dit is met name belangrijk voor functies bedoeld voor talen die dubbele-byte-tekensets (DBCS) gebruiken. Om dergelijke formules correct te berekenen, maak je een [LoadOptions](https://reference.aspose.com/slides/nl/python-java/aspose.slides/loadoptions/) , stel je de voorkeurscultuur in met [SpreadsheetOptions.setPreferredCulture](https://reference.aspose.com/slides/nl/python-java/aspose.slides/spreadsheetoptions/#setPreferredCulture) , wijs je de spreadsheet-opties toe via [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/nl/python-java/aspose.slides/loadoptions/#setSpreadsheetOptions) , en laad je vervolgens de presentatie.

Het onderstaande voorbeeld selecteert de Japanse cultuur, opent een presentatie met de geconfigureerde laadopties en roept [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/nl/python-java/aspose.slides/chartdataworkbook/#calculateFormulas) aan voor elk grafiek-werkboek:

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

De voorkeurscultuur maakt deel uit van de configuratie voor het laden van een presentatie, dus geef deze op voordat je een [Presentation]-instantie maakt. Gebruik de cultuur die door de werkboek-formules wordt verwacht; bijvoorbeeld `ja-JP` voor formules die de Japanse DBCS-rekenregels moeten volgen.

## **Herberekening en Gecachete Waarden**

Spreadsheet-bestanden slaan meestal zowel een formule als de laatst berekende waarde op. Aspose.Slides kan daarom een gecachete waarde lezen via [ChartDataCell.getValue](https://reference.aspose.com/slides/nl/python-java/aspose.slides/chartdatacell/#getValue) wanneer een presentatie wordt geladen en de relevante grafiekgegevens niet zijn gewijzigd.

Nadat je invoercellen of formules hebt gewijzigd, moet je niet vertrouwen op een oude gecachete uitkomst. Roep [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/nl/python-java/aspose.slides/chartdataworkbook/#calculateFormulas) aan vóór het lezen van berekende waarden of het opslaan van grafiekgegevens die ervan afhangen.

Voor formules buiten de ondersteunde subset kan Aspose.Slides de formule mogelijk niet parseren of de afhankelijkheden vaststellen. Als het werkboek is aangepast, kan de vorige gecachete waarde niet langer als betrouwbaar worden beschouwd. In dat geval kan het lezen van de waarde van een cel met niet-ondersteunde gegevens een [CellUnsupportedDataException](https://reference.aspose.com/slides/nl/python-java/aspose.slides/cellunsupporteddataexception/) veroorzaken.

Als je grafiek afhankelijk is van Excel-functies die Aspose.Slides niet evalueert, bereken die formules dan met een spreadsheet-engine die ze ondersteunt en schrijf de resulterende waarden terug naar het grafiek-werkboek. Vervang niet-ondersteunde formules niet door geraden waarden.

## **Formule-fouten afhandelen**

Er zijn twee verschillende soorten problemen te onderscheiden.

Een formule kan geldig zijn maar een spreadsheet-foutresultaat opleveren, zoals `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!` of `#VALUE!`. In dat geval is het fout-token een celresultaat en kan het worden teruggegeven via [ChartDataCell.getValue](https://reference.aspose.com/slides/nl/python-java/aspose.slides/chartdatacell/#getValue) .

Een formule kan ook falen op parse-, referentie-, afhankelijkheids- of ondersteunde-datumniveau. Aspose.Slides biedt spreadsheet-specifieke uitzonderingen voor deze gevallen: [CellInvalidFormulaException](https://reference.aspose.com/slides/nl/python-java/aspose.slides/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/nl/python-java/aspose.slides/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/nl/python-java/aspose.slides/cellcircularreferenceexception/) en [CellUnsupportedDataException](https://reference.aspose.com/slides/nl/python-java/aspose.slides/cellunsupporteddataexception/) .

Wanneer formules afkomstig zijn van sjablonen of gebruikersinvoer, verwerk deze uitzonderingen rond herberekening en waarde-toegang:

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

## **Praktische Beperkingen**

De formule-ondersteuning in grafiekwerkbladen is bedoeld voor een gedefinieerde subset van spreadsheet-berekeningen, niet voor volledige Excel-compatibiliteit. Houd deze beperkingen in gedachten bij het ontwerpen van een rapportage-workflow:

- Gebruik alleen de gedocumenteerde constanten, operatoren, referenties en functies wanneer je wilt dat Aspose.Slides formules opnieuw berekent.
- Herbereken nadat je cellen hebt gewijzigd waarvan de formule-resultaten afhankelijk zijn.
- Beschouw gecachete waarden uit geladen presentaties als momentopnamen, niet als vervanging van herberekening na bewerkingen.
- Test formules uit bestaande sjablonen voordat je vertrouwt op hun berekende waarden, vooral wanneer ze functies gebruiken die niet in de documentatie staan.
- Voor formules die een volledige spreadsheet-rekenmachine vereisen, bereken ze extern en werk daarna het grafiek-werkboek bij met de resulterende waarden.

## **FAQ**

**Wat is het verschil tussen [ChartDataCell.setFormula](https://reference.aspose.com/slides/nl/python-java/aspose.slides/chartdatacell/#setFormula) en [ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/nl/python-java/aspose.slides/chartdatacell/#setR1C1Formula)?**

[ChartDataCell.setFormula] slaat een A1-stijl-expressie op, bijvoorbeeld `B2-C2`. [ChartDataCell.setR1C1Formula] slaat een R1C1-stijl-expressie op, bijvoorbeeld `RC[-2]-RC[-1]`. Gebruik de notatie die het beste past bij hoe je formules genereert of kopieert.

**Moet ik de cel zelf of de waarde lezen na berekening?**

[ChartDataWorkbook.getCell] geeft een [ChartDataCell] terug. Om het berekende resultaat te verkrijgen, roep je na herberekening de [ChartDataCell.getValue]-methode van die cel aan.

**Wanneer moet ik [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/nl/python-java/aspose.slides/chartdataworkbook/#calculateFormulas) aanroepen?**

Roep [ChartDataWorkbook.calculateFormulas] aan nadat je invoerwaarden of formules hebt gewijzigd en voordat je afhankelijk bent van de berekende resultaten. Dit werkt de waarden van formules bij die door de ingebouwde evaluator worden ondersteund.

**Ondersteunt Aspose.Slides elke Excel-functie?**

Nee. De ingebouwde evaluator ondersteunt een gedocumenteerde subset van functies. Functies buiten die subset mogen niet worden verondersteld correct te herberekenen. Als volledige Excel-formule-compatibiliteit vereist is, voer de berekening dan uit met een geschikte spreadsheet-engine en schrijf de uiteindelijke waarden naar het grafiek-werkboek.

**Wat gebeurt er als een geladen presentatie een niet-ondersteunde formule bevat?**

Als de grafiekgegevens niet zijn gewijzigd, kan het werkboek nog steeds een eerder berekende gecachete waarde bevatten. Nadat gerelateerde gegevens zijn aangepast, is die gecachete waarde mogelijk niet meer geldig. Het benaderen van een cel waarvan de formule niet kan worden verwerkt kan een [CellUnsupportedDataException](https://reference.aspose.com/slides/nl/python-java/aspose.slides/cellunsupporteddataexception/) veroorzaken.

**Zijn formule-foutwaarden hetzelfde als uitzonderingen?**

Nee. Een resultaat zoals `#DIV/0!` is een spreadsheet-waarde die voortkomt uit een geldige berekening. Uitzonderingen zoals [CellInvalidFormulaException](https://reference.aspose.com/slides/nl/python-java/aspose.slides/cellinvalidformulaexception/) of [CellCircularReferenceException](https://reference.aspose.com/slides/nl/python-java/aspose.slides/cellcircularreferenceexception/) geven aan dat de formule niet normaal kan worden verwerkt.

**Werk een grafiek automatisch bij wanneer een formule-cel verandert?**

Een grafiekreeks kan naar werkboekcellen verwijzen. Bereken het werkboek eerst opnieuw, en sla vervolgens de presentatie op of render deze. Als de grafiekdatapunten naar de berekende cellen verwijzen, gebruikt de grafiek die bijgewerkte celwaarden; een aparte grafiek-verversingsmethode is niet nodig voor deze workflow.

**Kunnen grafieken een extern Excel-werkboek gebruiken?**

Ja, grafiekgegevens kunnen worden geconfigureerd om een extern werkboek te gebruiken via de grafiek-gegevens-API. Het formule-berekeningsproces dat in dit artikel wordt beschreven heeft echter betrekking op het grafiek-databoek en de door Aspose.Slides geëvalueerde formule-subset. Neem niet aan dat [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/nl/python-java/aspose.slides/chartdataworkbook/#calculateFormulas) volledige herberekening van willekeurige formules in een extern XLSX-bestand biedt.

**Kan ik formules gebruiken die naar een ander werkblad of werkboek verwijzen?**

Excel-achtige referenties kunnen voorkomen in grafiek-werkboeken, maar formule-evaluatie is beperkt door de ondersteunde parser en functiebasis. Als een cross-sheet- of externe referentie cruciaal is, valideer dan die exacte formule met de versie van Aspose.Slides die je gebruikt. Voor workflows die brede Excel-referentie-compatibiliteit vereisen, bereken je het werkboek extern en schrijf je de opgeloste waarden terug naar de grafiekgegevens.

**Moeten formule-strings beginnen met `=`?**

De Aspose.Slides-API-voorbeelden wijzen expressies toe zoals `B2-C2` of `SUM(B2:B5)` zonder een leidende `=`. Het gebruik van die vorm houdt de gegenereerde formules consistent met de gedocumenteerde API-voorbeelden.
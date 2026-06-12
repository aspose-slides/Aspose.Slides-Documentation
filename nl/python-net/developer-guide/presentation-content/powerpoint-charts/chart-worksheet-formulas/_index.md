---
title: Diagramwerkbladformules toepassen in presentaties met Python
linktitle: Werkbladformules
type: docs
weight: 70
url: /nl/python-net/chart-worksheet-formulas/
keywords:
- diagram-spreadsheet
- diagram-werkblad
- diagramformule
- werkbladformule
- spreadsheet-formule
- gegevensbron
- logische constante
- numerieke constante
- tekenreeks-constante
- fout-constante
- rekenkundige constante
- vergelijkingsoperator
- A1-stijl
- R1C1-stijl
- vooraf gedefinieerde functie
- PowerPoint
- OpenDocument
- presentatie
- Python
- Aspose.Slides
description: "Excel-achtige formules toepassen in Aspose.Slides voor Python via .NET diagramwerkbladen en rapporten automatiseren in PPT-, PPTX- en ODP-bestanden."
---
## **Overzicht**

Een diagramwerkblad is de gegevensbron achter een diagram in een presentatie. Het slaat categorie‑ en serie‑namen op samen met de numerieke waarden die door het diagram worden weergegeven. In Aspose.Slides is dit werkblad beschikbaar via het diagram‑databoek, waarmee u programmeermatig met diagramgegevens kunt werken.

Dit artikel legt uit hoe u werkbladformules in diagramgegevens kunt gebruiken zodat celwaarden automatisch berekend en bijgewerkt worden in plaats van handmatig ingevoerd te worden. Het toont hoe u formules toewijst, zowel A1‑ als R1C1‑stijl‑referenties gebruikt, werkboek‑formules opnieuw laat berekenen, en werkt met de ondersteunde constanten, operatoren, celreferenties en vooraf gedefinieerde functies die beschikbaar zijn voor diagramwerkbladen in presentaties.

## **Over diagram‑spreadsheet‑formule in een presentatie**
**Chart spreadsheet** (of diagram‑werkblad) in een presentatie is de gegevensbron van het diagram. Een diagram‑spreadsheet bevat gegevens die op grafische wijze in het diagram worden weergegeven. Wanneer u een diagram in PowerPoint maakt, wordt het bijbehorende werkblad automatisch aangemaakt. Een diagram‑werkblad wordt aangemaakt voor alle soorten diagrammen: lijndiagram, staafdiagram, sunburst‑diagram, cirkeldiagram, enz. Om de diagram‑spreadsheet in PowerPoint te zien, moet u dubbelklikken op het diagram:

![todo:image_alt_text](chart-worksheet-formulas_1.png)

De diagram‑spreadsheet bevat de namen van diagram‑elementen (Categorie‑naam: *Category1*, Serie‑naam) en een tabel met numerieke gegevens die passen bij deze categorieën en series. Standaard, wanneer u een nieuw diagram aanmaakt, worden de diagram‑spreadsheet‑gegevens ingesteld op de standaardwaarden. Daarna kunt u de spreadsheet‑gegevens handmatig in het werkblad wijzigen.

Meestal vertegenwoordigt het diagram ingewikkelde gegevens (bijv. financiële analisten, wetenschappelijke analisten), met cellen die berekend worden op basis van waarden in andere cellen of andere dynamische gegevens. Het handmatig berekenen van een celwaarde en hard‑coderen in de cel maakt het moeilijk om later te wijzigen. Als u de waarde van een bepaalde cel wijzigt, moeten alle daarvan afhankelijke cellen ook worden bijgewerkt. Bovendien kunnen tabelgegevens afhankelijk zijn van gegevens uit andere tabellen, waardoor een complex presentatiedatamodel ontstaat dat op een eenvoudige en flexibele manier moet worden bijgewerkt.

**Chart‑spreadsheet‑formule** in een presentatie is een uitdrukking om automatisch diagram‑spreadsheet‑gegevens te berekenen en bij te werken. Een spreadsheet‑formule definieert de gegevens‑berekeningslogica voor een bepaalde cel of een set cellen. Een spreadsheet‑formule is een wiskundige of logische formule die gebruikmaakt van: celreferenties, wiskundige functies, logische operatoren, rekenkundige operatoren, conversiefuncties, tekenreeks‑constanten, enz. De definitie van de formule wordt in een cel geschreven, en die cel bevat geen eenvoudige waarde. De spreadsheet‑formule berekent de waarde en retourneert deze, waarna de waarde aan de cel wordt toegewezen. Diagram‑spreadsheet‑formules in presentaties zijn feitelijk dezelfde als Excel‑formules, en dezelfde standaardfuncties, operatoren en constanten worden ondersteund voor hun implementatie.

In [**Aspose.Slides**](https://products.aspose.com/slides/nl/python-net/) wordt de diagram‑spreadsheet weergegeven met de eigenschap 
[**Chart.ChartData.ChartDataWorkbook**](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/ichartdata/) van het type 
[**IChartDataWorkbook**](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/ichartdataworkbook/). 
Een spreadsheet‑formule kan worden toegewezen en gewijzigd met de eigenschap 
[**formula**](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/ichartdatacell/). 
De volgende functionaliteit wordt ondersteund voor formules in Aspose.Slides:

- Logische constanten
- Numerieke constanten
- Tekenreeks‑constanten
- Fout‑constanten
- Rekenkundige operatoren
- Vergelijkingsoperatoren
- A1‑stijl celreferenties
- R1C1‑stijl celreferenties
- Vooraf gedefinieerde functies

Typisch slaan spreadsheets de laatst berekende formulewaarden op. Als na het laden van de presentatie de diagramgegevens niet zijn gewijzigd, geeft de eigenschap **IChartDataCell.Value** die waarden terug bij het lezen. Maar als de spreadsheet‑gegevens wel zijn gewijzigd, werpt het lezen van de eigenschap **ChartDataCell.Value** een **CellUnsupportedDataException** voor de niet‑ondersteunde formules. Dit komt doordat wanneer formules succesvol worden geparseerd, de cel‑afhankelijkheden worden vastgesteld en de juistheid van de laatste waarden wordt bepaald. Als een formule echter niet kan worden geparseerd, kan de juistheid van de celwaarde niet worden gegarandeerd.

## **Diagram‑spreadsheet‑formule toevoegen aan een presentatie**
Eerst voegt u een diagram met voorbeeldgegevens toe aan de eerste dia van een nieuwe presentatie met [add_chart](https://reference.aspose.com/slides/nl/python-net/aspose.slides/ishapecollection/). Het werkblad van het diagram wordt automatisch aangemaakt en kan worden benaderd via de eigenschap [**chart_data_workbook**](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/ichartdata/).

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 150, 150, 500, 300)
    workbook = chart.chart_data.chart_data_workbook
    # ...
```

Laten we enkele waarden in cellen schrijven met de eigenschap [**value**](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/ichartdatacell/) van het type **Object**, wat betekent dat u elke waarde aan de eigenschap kunt toewijzen:

```py
    workbook.get_cell(0, "F2").value = -2.5
    workbook.get_cell(0, "G3").value = 6.3
    workbook.get_cell(0, "H4").value = 3
```

Om nu een formule in de cel te schrijven, kunt u de eigenschap [**formula**](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/ichartdatacell/) gebruiken:

```py
    workbook.get_cell(0, "B2").formula = "F2+G3+H4+1"
```

*Opmerking*: [**IChartDataCell.Formula**](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/ichartdatacell/) eigenschap wordt gebruikt om A1‑stijl celreferenties in te stellen.

Om de [r1c1_formula](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/ichartdatacell/) celreferentie in te stellen, kunt u de eigenschap [**r1c1_formula**](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/ichartdatacell/) gebruiken:

```py
    workbook.get_cell(0, "C2").r1c1_formula = "R[1]C[4]/R[2]C[5]"
```

Gebruik vervolgens de methode [**calculate_formulas**](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartdataworkbook/) om alle formules in het werkboek te berekenen en de bijbehorende celwaarden bij te werken:

```py
    workbook.calculate_formulas()
    print(workbook.get_cell(0, "B2").value) # 7.8
    print(workbook.get_cell(0, "C2").value) # 2.1
```

## **Logische constanten**
U kunt logische constanten zoals *FALSE* en *TRUE* gebruiken in cel‑formules:

## **Numerieke constanten**
Cijfers kunnen in gewone of wetenschappelijke notatie worden gebruikt om een diagram‑spreadsheet‑formule te maken:

## **Tekenreeks‑constanten**
Een tekenreeks‑ (of letterlijke) constante is een specifieke waarde die precies zo wordt gebruikt en niet verandert. Tekenreeks‑constanten kunnen zijn: datums, teksten, cijfers, enz.:

## **Fout‑constanten**
Soms is het niet mogelijk het resultaat met de formule te berekenen. In dat geval wordt de foutcode in de cel weergegeven in plaats van de waarde. Elk type fout heeft een specifieke code:

- #DIV/0! – formule probeert te delen door nul.
- #GETTING_DATA – kan in een cel verschijnen terwijl de waarde nog wordt berekend.
- #N/A – informatie ontbreekt of is niet beschikbaar. Mogelijke redenen: de cellen die in de formule worden gebruikt zijn leeg, een extra spatie, een spelfout, enz.
- #NAME? – een bepaalde cel of ander formule‑object kan niet worden gevonden op basis van de naam.
- #NULL! – kan verschijnen wanneer er een fout in de formule staat, bijvoorbeeld: (,) of een spatie in plaats van dubbele punt (:).
- #NUM! – het numerieke getal in de formule kan ongeldig, te groot of te klein zijn, enz.
- #REF! – ongeldige celreferentie.
- #VALUE! – onverwacht type waarde. Bijvoorbeeld een tekenreekswaarde in een numerieke cel.

## **Rekenkundige operatoren**
U kunt alle rekenkundige operatoren gebruiken in diagram‑werkblad‑formules:

|**Operator**|**Betekenis**|**Voorbeeld**|
| :- | :- | :- |
|+ (plusteken)|Optelling of eenvoudig plus|2 + 3|
|- (minteken)|Aftrekking of negatie|2 - 3<br>-3|
|* (asterisk)|Vermenigvuldiging|2 * 3|
|/ (schuine streep)|Deling|2 / 3|
|% (procentteken)|Procent|30%|
|^ (circumflex)|Exponentiatie|2 ^ 3|

*Opmerking*: Om de volgorde van de evaluatie te wijzigen, omsluit u het deel van de formule dat eerst moet worden berekend met haakjes.

## **Vergelijkingsoperatoren**
U kunt de waarden van cellen vergelijken met de vergelijkingsoperatoren. Wanneer twee waarden met deze operatoren worden vergeleken, is het resultaat een logische waarde, *TRUE* of FALSE:

|**Operator**|**Betekenis**|**Voorbeeld**|
| :- | :- | :- |
|= (gelijk‑teken)|Gelijk aan|A2 = 3|
|<> (ongelijk‑teken)|Niet gelijk aan|A2 <> 3|
|> (groter‑dan teken)|Groter dan|A2 > 3|
|>= (groter‑of‑gelijk‑dan teken)|Groter dan of gelijk aan|A2 >= 3|
|< (kleiner‑dan teken)|Kleiner dan|A2 < 3|
|<= (kleiner‑of‑gelijk‑dan teken)|Kleiner dan of gelijk aan|A2 <= 3|

## **A1‑stijl celreferenties**
**A1‑stijl celreferenties** worden gebruikt voor werkbladen waarbij de kolom een letter‑identifier heeft (bijv. "*A*") en de rij een numerieke identifier (bijv. "*1*"). A1‑stijl celreferenties kunnen op de volgende manier worden gebruikt:

|**Celreferentie**|**Voorbeeld**|||
| :- | :- | :- | :- |
||Absoluut|Relatief|Gemengd|
|Cel|$A$2|A2|<p>A$2</p><p>$A2</p>|
|Rij|$2:$2|2:2|-|
|Kolom|$A:$A|A:A|-|
|Bereik|$A$2:$C$4|A2:C4|<p>$A$2:C4</p><p>A$2:$C4</p>|

Hier is een voorbeeld van hoe een A1‑stijl celreferentie in een formule te gebruiken:

## **R1C1‑stijl celreferenties**
**R1C1‑stijl celreferenties** worden gebruikt voor werkbladen waarbij zowel een rij als een kolom een numerieke identifier heeft. R1C1‑stijl celreferenties kunnen op de volgende manier worden gebruikt:

|**Celreferentie**|**Voorbeeld**|||
| :- | :- | :- | :- |
||Absoluut|Relatief|Gemengd|
|Cel|R2C3|R[2]C[3]|R2C[3]<br>R[2]C3|
|Rij|R2|R[2]|-|
|Kolom|C3|C[3]|-|
|Bereik|R2C3:R5C7|R[2]C[3]:R[5]C[7]|R2C3:R[5]C[7]<br>R[2]C3:R5C[7]|

Hier is een voorbeeld van hoe een R1C1‑stijl celreferentie in een formule te gebruiken:

## **Vooraf gedefinieerde functies**
Er zijn vooraf gedefinieerde functies die in de formules kunnen worden gebruikt om de implementatie te vereenvoudigen. Deze functies omvatten de meest gebruikte bewerkingen, zoals:

- ABS
- AVERAGE
- CEILING
- CHOOSE
- CONCAT
- CONCATENATE
- DATE (1900 date system)
- DAYS
- FIND
- FINDB
- IF
- INDEX (reference form)
- LOOKUP (vector form)
- MATCH (vector form)
- MAX
- SUM
- VLOOKUP

## **FAQ**

**Zijn externe Excel‑bestanden ondersteund als gegevensbron voor een diagram met formules?**

Ja. Aspose.Slides ondersteunt externe werkboeken als een [chart's data source](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartdatasourcetype/), waarmee u formules uit een XLSX‑bestand buiten de presentatie kunt gebruiken.

**Kunnen diagramformules bladen binnen hetzelfde werkboek refereren op basis van de bladnaam?**

Ja. Formules volgen het standaard Excel‑referentiemodel, zodat u andere bladen binnen hetzelfde werkboek of een extern werkboek kunt refereren. Voor externe referenties moet u het pad en de werkboeknaam opnemen volgens de Excel‑syntaxis.
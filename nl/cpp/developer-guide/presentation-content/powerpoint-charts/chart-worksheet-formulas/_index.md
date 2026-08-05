---
title: Grafiek-werkbladformules toepassen in presentaties met C++
linktitle: Werkbladformules
type: docs
weight: 70
url: /nl/cpp/chart-worksheet-formulas/
keywords:
- grafiek-spreadsheet
- grafiek-werkblad
- grafiekformule
- werkbladformule
- spreadsheetformule
- gegevensbron
- logische constante
- numerieke constante
- tekenreeksconstante
- foutconstante
- rekenkundige constante
- vergelijkingsoperator
- A1‑stijl
- R1C1‑stijl
- vooraf gedefinieerde functie
- PowerPoint
- presentatie
- C++
- Aspose.Slides
description: "Excel‑achtige formules toepassen in Aspose.Slides voor C++‑grafiekwerkbladen en rapporten automatiseren in PPT‑ en PPTX‑bestanden."
---
## **Overzicht**

Een chart worksheet is de gegevensbron achter een grafiek in een presentatie. Het slaat categorie‑ en serienamen op samen met de numerieke waarden die door de grafiek worden weergegeven. In Aspose.Slides is dit werkblad beschikbaar via de chart data workbook, waarmee u programmatisch met grafiekgegevens kunt werken.

Dit artikel legt uit hoe u worksheet‑formules in chart data kunt gebruiken zodat celwaarden automatisch berekend en bijgewerkt worden in plaats van handmatig ingevoerd. Het toont hoe u formules toewijst, zowel A1‑style als R1C1‑style referenties gebruikt, workbook‑formules opnieuw berekent, en werkt met de ondersteunde constanten, operatoren, celreferenties en vooraf gedefinieerde functies die beschikbaar zijn voor chart worksheets in presentaties.

## **Over chart‑spreadsheet‑formules in presentaties**
**Chart spreadsheet** (of chart worksheet) in een presentatie is de gegevensbron van de grafiek. Chart spreadsheet bevat gegevens die grafisch worden weergegeven in de grafiek. Wanneer u een grafiek maakt in PowerPoint, wordt het bijbehorende werkblad automatisch aangemaakt. Het chart worksheet wordt aangemaakt voor alle soorten grafieken: lijngrafiek, staafgrafiek, sunburst‑grafiek, taartgrafiek, enz. Om het chart spreadsheet in PowerPoint te zien, dubbelklikt u op de grafiek:

![todo:image_alt_text](chart-worksheet-formulas_1.png)

Chart spreadsheet bevat de namen van grafiekelementen (Category Name: *Category1*, Serie Name) en een tabel met numerieke gegevens die passen bij deze categorieën en series. Standaard, wanneer u een nieuwe grafiek maakt, worden de chart spreadsheet‑gegevens ingesteld op de standaarddata. Daarna kunt u de spreadsheet‑gegevens in het werkblad handmatig wijzigen.

Meestal vertegenwoordigt de grafiek complexe data (bijv. financiële of wetenschappelijke analyses), met cellen die worden berekend vanuit waarden in andere cellen of uit andere dynamische gegevens. Het handmatig berekenen van een celwaarde en hard‑coderen ervan maakt toekomstige wijzigingen moeilijk. Als u de waarde van een bepaalde cel wijzigt, moeten alle afhankelijke cellen ook worden bijgewerkt. Bovendien kunnen tabelgegevens afhankelijk zijn van gegevens uit andere tabellen, waardoor een complex presentatiedataschema ontstaat dat op een eenvoudige en flexibele manier moet kunnen worden bijgewerkt.

**Chart spreadsheet‑formule** in een presentatie is een expressie om chart spreadsheet‑data automatisch te berekenen en bij te werken. Een spreadsheet‑formule definieert de berekeningslogica voor een bepaalde cel of een reeks cellen. Een spreadsheet‑formule is een wiskundige of logische formule die gebruikmaakt van: celreferenties, wiskundige functies, logische operatoren, rekenkundige operatoren, conversiefuncties, tekenreeks‑constant­en, enz. De definitie van de formule wordt in een cel geschreven, en deze cel bevat geen eenvoudige waarde. De spreadsheet‑formule berekent de waarde en geeft deze terug, waarna de waarde aan de cel wordt toegewezen. Chart spreadsheet‑formules in presentaties zijn eigenlijk dezelfde als Excel‑formules, en dezelfde standaardfuncties, operatoren en constanten worden ondersteund voor hun implementatie.

In [**Aspose.Slides**](https://products.aspose.com/slides/nl/cpp/) wordt chart spreadsheet weergegeven met de 
[**ChartData::get_ChartDataWorkbook()**](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.charts.chart_data#a32097093561723a10df0a57dc91acaea)‑methode van het
[**IChartDataWorkbook**](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.charts.i_chart_data_workbook)‑type. 
Spreadsheet‑formule kan worden toegewezen en gewijzigd met 
[**IChartDataCell::set_Formula()**](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.charts.i_chart_data_cell#a6806c6a40e025e6834c4c5f3af3cf692)‑methode. 
De volgende functionaliteit wordt ondersteund voor formules in Aspose.Slides:

- Logische constanten
- Numerieke constanten
- Tekenreeks‑constanten
- Fout‑constanten
- Reken­operatoren
- Vergelijkings‑operatoren
- A1‑style celreferenties
- R1C1‑style celreferenties
- Vooraf gedefinieerde functies



Typisch slaan spreadsheets de laatst berekende formule‑waarden op. Als na het laden van de presentatie de grafiekdata niet zijn gewijzigd, retourneert de **IChartDataCell.get_Value()**‑methode die waarden bij het lezen. Maar als spreadsheet‑data zijn gewijzigd, gooit **ChartDataCell.get_Value()** een **CellUnsupportedDataException** voor de niet‑ondersteunde formules. Dit komt omdat wanneer formules succesvol worden geparseerd, de cel‑afhankelijkheden worden bepaald en de juistheid van de laatste waarden wordt vastgesteld. Als een formule niet kan worden geparseerd, kan de juistheid van de celwaarde niet worden gegarandeerd.


## **Een chart‑spreadsheet‑formule aan een presentatie toevoegen**
Eerst voegt u een grafiek toe aan de eerste dia van een nieuwe presentatie met 
[IShapeCollection::AddChart()](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.i_shape_collection#a2cd4d47fc5c536012ee15b3a69486374). 
Het werkblad van de grafiek wordt automatisch aangemaakt en kan worden benaderd met 
[**ChartData::get_ChartDataWorkbook()**](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.charts.chart_data#a32097093561723a10df0a57dc91acaea)‑methode:

``` cpp
auto presentation = System::MakeObject<Presentation>();
    
auto chart = presentation->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::ClusteredColumn, 150.0f, 150.0f, 500.0f, 300.0f);
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();

// ...
```

Laten we enkele waarden in cellen schrijven met 
[**IChartDataCell.set_Value()**](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.charts.i_chart_data_cell#ad85809f520195e09225abae9002635ec)‑methode 
van het type **Object**, wat betekent dat u elke waarde aan de methode kunt doorgeven:

``` cpp
workbook->GetCell(0, u"F2")->set_Value(System::ObjectExt::Box<double>(-2.5));
workbook->GetCell(0, u"G3")->set_Value(System::ObjectExt::Box<double>(6.3));
workbook->GetCell(0, u"H4")->set_Value(System::ObjectExt::Box<int32_t>(3));
```

Nu, om een formule in de cel te schrijven, kunt u de 
[**IChartDataCell::set_Formula()**](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.charts.i_chart_data_cell#a6806c6a40e025e6834c4c5f3af3cf692)‑methode gebruiken:

*Note*: [**IChartDataCell::set_Formula()**](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.charts.i_chart_data_cell#a6806c6a40e025e6834c4c5f3af3cf692)‑methode wordt gebruikt om A1‑style celreferenties in te stellen. 

Om de R1C1Formula‑celreferentie in te stellen, kunt u de [**IChartDataCell::set_R1C1Formula()**](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.charts.i_chart_data_cell#a47f5825dd38d0dddb11ecc3a43d388c7)‑methode gebruiken:

Vervolgens, als u de waarden van de cellen B2 en C2 leest, zullen ze worden berekend:

``` cpp
auto value1 = cell1->get_Value(); // 7.8
auto value2 = cell2->get_Value(); // 2.1
```


## **Logische constanten**
U kunt logische constanten zoals *FALSE* en *TRUE* gebruiken in cel‑formules:


## **Numerieke constanten**
Getallen kunnen in gewone of wetenschappelijke notatie worden gebruikt om chart spreadsheet‑formules te maken:


## **Tekenreeks‑constanten**
Een tekenreeks‑ (of literal) constante is een specifieke waarde die precies zo wordt gebruikt en niet verandert. Tekenreeks‑constanten kunnen zijn: datums, teksten, getallen, enz.:

## **Fout‑constanten**
Soms is het niet mogelijk het resultaat te berekenen met de formule. In dat geval wordt de foutcode in de cel getoond in plaats van de waarde. Elke type fout heeft een specifieke code:

- #DIV/0! - formule probeert te delen door nul.
- #GETTING_DATA - kan worden weergegeven in een cel terwijl de waarde nog wordt berekend.
- #N/A - informatie is ontbrekend of niet beschikbaar. Oorzaken kunnen zijn: de cellen die in de formule worden gebruikt zijn leeg, een extra spatie, een spelfout, enz.
- #NAME? - een bepaalde cel of ander formule‑object kan niet worden gevonden op naam. 
- #NULL! - kan verschijnen wanneer er een fout in de formule zit, zoals:  (,) of een spatie in plaats van een dubbele punt (:).
- #NUM! - het numerieke deel in de formule is ongeldig, te lang of te klein, enz.
- #REF! - ongeldige celreferentie.
- #VALUE! - onverwacht type waarde. Bijvoorbeeld, een tekenreekswaarde ingesteld op een numerieke cel.


## **Rekenkundige operatoren**
U kunt alle rekenkundige operatoren gebruiken in chart worksheet‑formules:

|**Operator**|**Betekenis**|**Voorbeeld**|
| :- | :- | :- |
|+ (plus teken)|Optelling of unair plus|2 + 3|
|- (min teken)|Aftrekking of negatie|2 - 3<br>-3|
|* (asterisk)|Vermenigvuldiging|2 * 3|
|/ (slash)|Deling|2 / 3|
|% (percentage teken)|Procent|30%|
|^ (caret)|Exponentiatie|2 ^ 3|

*Note*: Om de volgorde van evaluatie te wijzigen, zet u het deel van de formule dat eerst moet worden berekend tussen haakjes.


## **Vergelijkingsoperatoren**
U kunt de waarden van cellen vergelijken met de vergelijkingsoperatoren. Wanneer twee waarden worden vergeleken met deze operatoren, is het resultaat een logische waarde, *TRUE* of *FALSE*:

|**Operator**|**Betekenis**|**Betekenis**|
| :- | :- | :- |
|= (gelijk‑teken)|Gelijk aan|A2 = 3|
|<> (niet‑gelijk‑teken)|Niet gelijk aan|A2 <> 3|
|> (groter‑dan teken)|Groter dan|A2 > 3|
|>= (groter‑dan‑of‑gelijk‑teken)|Groter dan of gelijk aan|A2 >= 3|
|< (kleiner‑dan teken)|Kleiner dan|A2 < 3|
|<= (kleiner‑dan‑of‑gelijk‑teken)|Kleiner dan of gelijk aan|A2 <= 3|

## **A1‑style celreferenties**
**A1‑style celreferenties** worden gebruikt voor werkbladen waarbij de kolom een letter‑identificatie heeft (bijv. "*A*") en de rij een numerieke identificatie (bijv. "*1*"). A1‑style celreferenties kunnen als volgt worden gebruikt:

|**Celreferentie**|**Voorbeeld**|**Absoluut**|**Relatief**|**Gemengd**|
| :- | :- | :- | :- | :- |
|Cel|$A$2|A2|<p>A$2</p><p>$A2</p>|
|Rij|$2:$2|2:2|-|
|Kolom|$A:$A|A:A|-|
|Bereik|$A$2:$C$4|A2:C4|<p>$A$2:C4</p><p>A$2:$C4</p>|

Hier volgt een voorbeeld hoe een A1‑style celreferentie in een formule te gebruiken:

## **R1C1‑style celreferenties**
**R1C1‑style celreferenties** worden gebruikt voor werkbladen waarbij zowel rij als kolom een numerieke identificatie hebben. R1C1‑style celreferenties kunnen als volgt worden gebruikt:

|**Celreferentie**|**Voorbeeld**|**Absoluut**|**Relatief**|**Gemengd**|
| :- | :- | :- | :- | :- |
|Cel|R2C3|R[2]C[3]|R2C[3]<br>R[2]C3|
|Rij|R2|R[2]|-|
|Kolom|C3|C[3]|-|
|Bereik|R2C3:R5C7|R[2]C[3]:R[5]C[7]|R2C3:R[5]C[7]<br>R[2]C3:R5C[7]|

Hier volgt een voorbeeld hoe een R1C1‑style celreferentie in een formule te gebruiken:

## **Vooraf gedefinieerde functies**
Er zijn vooraf gedefinieerde functies die in formules kunnen worden gebruikt om hun implementatie te vereenvoudigen. Deze functies omvatten de meest gebruikte bewerkingen, zoals:

- ABS
- AVERAGE
- CEILING
- CHOOSE
- CONCAT
- CONCATENATE
- DATE (1900 datumsysteem)
- DAYS
- FIND
- FINDB
- IF
- INDEX (referentie‑vorm)
- LOOKUP (vector‑vorm)
- MATCH (vector‑vorm)
- MAX
- SUM
- VLOOKUP

## **FAQ**

**Worden externe Excel‑bestanden ondersteund als gegevensbron voor een grafiek met formules?**

Ja. Aspose.Slides ondersteunt externe werkboeken als een [chart's data source](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/chartdatasourcetype/), waardoor u formules uit een XLSX buiten de presentatie kunt gebruiken.

**Kunnen grafiekformules verwijzen naar bladen binnen hetzelfde werkboek op bladnaam?**

Ja. Formules volgen het standaard Excel‑referentiemodel, dus u kunt andere bladen binnen hetzelfde werkboek of een extern werkboek refereren. Voor externe verwijzingen moet het pad en de werkboeknaam met Excel‑syntaxis worden opgegeven.
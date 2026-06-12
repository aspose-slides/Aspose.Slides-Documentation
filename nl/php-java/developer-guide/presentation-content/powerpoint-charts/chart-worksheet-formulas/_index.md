---
title: Chart-werkbladformules toepassen in presentaties met PHP
linktitle: Werkbladformules
type: docs
weight: 70
url: /nl/php-java/chart-worksheet-formulas/
keywords:
- grafiek spreadsheet
- grafiek werkblad
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
- A1 stijl
- R1C1 stijl
- vooraf gedefinieerde functie
- PowerPoint
- presentatie
- PHP
- Aspose.Slides
description: "Excel-achtige formules toepassen in Aspose.Slides voor PHP via Java-grafiekwerkbladen en rapporten automatiseren in PPT- en PPTX-bestanden."
---
## **Overzicht**

Een grafiekwerkblad is de gegevensbron achter een grafiek in een presentatie. Het slaat categorie‑ en serienaam op, samen met de numerieke waarden die door de grafiek worden weergegeven. In Aspose.Slides is dit werkblad beschikbaar via de grafiek‑databoekwerk, waarmee u programmatisch met grafiekgegevens kunt werken.

Dit artikel legt uit hoe u werkblad‑formules in grafiekgegevens kunt gebruiken, zodat celwaarden automatisch worden berekend en bijgewerkt in plaats van handmatig ingevoerd. Het toont hoe u formules toewijst, zowel A1‑stijl‑ als R1C1‑stijl‑referenties gebruikt, werkblad‑formules opnieuw berekent, en werkt met de ondersteunde constanten, operatoren, celreferenties en vooraf gedefinieerde functies die beschikbaar zijn voor grafiekwerkbladen in presentaties.

## **Over chart‑spreadsheetformules in presentaties**
**Chart spreadsheet** (of chart worksheet) in een presentatie is de gegevensbron van de grafiek. Chart spreadsheet bevat gegevens die grafisch worden weergegeven in de grafiek. Wanneer u een grafiek in PowerPoint maakt, wordt het bijbehorende werkblad automatisch aangemaakt. Het werkblad wordt aangemaakt voor alle soorten grafieken: lijngrafiek, staafgrafiek, sunburst‑grafiek, cirkeldiagram, enz. Om het chart‑spreadsheet in PowerPoint te zien, dubbelklikt u op de grafiek:

![todo:image_alt_text](chart-worksheet-formulas_1.png)


Chart spreadsheet bevat de namen van grafiekelementen (Categorie‑naam: *Category1*, Serie‑naam) en een tabel met numerieke gegevens die bij deze categorieën en series horen. Standaard, wanneer u een nieuwe grafiek maakt, worden de chart‑spreadsheet‑gegevens ingesteld op de standaardwaarden. Vervolgens kunt u de spreadsheet‑gegevens handmatig in het werkblad wijzigen.

Meestal stelt de grafiek gecompliceerde gegevens voor (bijv. financieel of wetenschappelijk), waarbij cellen worden berekend op basis van waarden in andere cellen of andere dynamische gegevens. Het handmatig berekenen van een celwaarde en hardcoderen ervan in de cel maakt latere wijzigingen moeilijk. Als u de waarde van een bepaalde cel wijzigt, moeten alle afhankelijke cellen ook worden bijgewerkt. Bovendien kunnen tabelgegevens afhangen van gegevens uit andere tabellen, waardoor een complex presentatiedatamodel ontstaat dat eenvoudig en flexibel moet kunnen worden bijgewerkt.

**Chart spreadsheet‑formule** in een presentatie is een expressie om chart‑spreadsheet‑gegevens automatisch te berekenen en bij te werken. Een spreadsheet‑formule definieert de berekeningslogica voor een bepaalde cel of een set cellen. Een spreadsheet‑formule is een wiskundige of logische formule die gebruikmaakt van: celreferenties, wiskundige functies, logische operatoren, rekenkundige operatoren, conversiefuncties, tekenreeks‑constanten, enz. De definitie van de formule wordt in een cel geschreven; die cel bevat geen eenvoudige waarde. De spreadsheet‑formule berekent de waarde en geeft deze terug, waarna de waarde aan de cel wordt toegewezen. Chart‑spreadsheet‑formules in presentaties zijn feitelijk dezelfde als Excel‑formules, en er worden dezelfde standaardfuncties, operatoren en constanten ondersteund voor hun implementatie.

In [**Aspose.Slides**](https://products.aspose.com/slides/nl/php-java/) wordt chart‑spreadsheet weergegeven met
[**ChartData::getChartDataWorkbook**](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartdata/#getChartDataWorkbook)‑methode van het
[**ChartDataWorkbook**](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartdataworkbook/)‑type.
Spreadsheet‑formule kan worden toegewezen en gewijzigd met 
[**ChartDataCell::setFormula**](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartdatacell/#setFormula)‑methode.
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


Typisch slaan spreadsheets de laatst berekende formulewaarden op. Als de presentatielading de grafiekgegevens niet heeft gewijzigd, geeft de [**ChartDataCell::getValue**](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartdatacell/#getValue)‑methode die waarden terug bij het lezen. Maar als spreadsheet‑gegevens zijn gewijzigd, wordt bij het lezen van de waarde een [**CellUnsupportedDataException**](https://reference.aspose.com/slides/nl/php-java/aspose.slides/CellUnsupportedDataException) gegooid voor de niet‑ondersteunde formules. Dit komt doordat, wanneer formules succesvol worden geparseerd, de celafhankelijkheden worden bepaald en de juistheid van de laatste waarden wordt vastgesteld. Als een formule niet kan worden geparseerd, kan de juistheid van de celwaarde niet worden gegarandeerd.

## **Een chart‑spreadsheet‑formule toevoegen aan een presentatie**
Voeg eerst een grafiek toe aan de eerste dia van een nieuwe presentatie met 
[ShapeCollection::addChart](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shapecollection/#addChart).
Het werkblad van de grafiek wordt automatisch aangemaakt en kan worden benaderd met 
[**ChartData::getChartDataWorkbook**](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartdata/#getChartDataWorkbook)‑methode:



```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 150, 150, 500, 300);
    $workbook = $chart->getChartData()->getChartDataWorkbook();
    # ...
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Laten we enkele waarden in cellen schrijven met [**ChartDataCell::setValue**](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartdatacell/#setValue)‑methode van het **Object**‑type, wat betekent dat u elke waarde kunt instellen:

```php
  $workbook->getCell(0, "F2")->setValue(-2.5);
  $workbook->getCell(0, "G3")->setValue(6.3);
  $workbook->getCell(0, "H4")->setValue(3);
```

Nu, om een formule in de cel te schrijven, kunt u de 
[**ChartDataCell::setFormula**](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartdatacell/#setFormula)‑methode gebruiken.

*Opmerking*: [**ChartDataCell::setFormula**](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartdatacell/#setFormula)‑methode wordt gebruikt om A1‑stijl celreferenties in te stellen. 

Om een formule in R1C1‑stijl in te stellen, kunt u de [**ChartDataCell::setR1C1Formula**](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartdatacell/#setR1C1Formula)‑methode gebruiken.

Vervolgens, als u de waarden uit de cellen B2 en C2 probeert te lezen, worden deze berekend:

```php
  $value1 = $cell1->getValue();// 7.8

  $value2 = $cell2->getValue();// 2.1


```

## **Logische constanten**
U kunt logische constanten zoals *FALSE* en *TRUE* gebruiken in cel‑formules:

```php
  $workbook->getCell(0, "A2")->setValue(false);
  $cell = $workbook->getCell(0, "B2");
  $cell->setFormula("A2 = TRUE");
  $value = $cell->getValue();// de waarde bevat boolean "false"


```

## **Numerieke constanten**
Nummers kunnen in gewone of wetenschappelijke notatie worden gebruikt om een chart‑spreadsheet‑formule te maken:

```php
  $workbook->getCell(0, "A2")->setFormula("1 + 0.5");
  $workbook->getCell(0, "B2")->setFormula(".3 * 1E-2");

```

## **Tekenreeks‑constanten**
Een tekenreeks‑ (of letterlijke) constante is een specifieke waarde die precies zo wordt gebruikt en niet verandert. Tekenreeks‑constanten kunnen zijn: datums, teksten, getallen, enz.:

```php
  $workbook->getCell(0, "A2")->setFormula("\"abc\"");
  $workbook->getCell(0, "B2")->setFormula("\"2/3/2020 12:00\"");

```

## **Fout‑constanten**
Soms is het niet mogelijk het resultaat van de formule te berekenen. In dat geval wordt de foutcode in de cel weergegeven in plaats van de waarde. Elke fout heeft een specifieke code:

- #DIV/0! - formule probeert te delen door nul.
- #GETTING_DATA - kan op een cel verschijnen terwijl de waarde nog wordt berekend.
- #N/A - informatie ontbreekt of is niet beschikbaar. Mogelijke oorzaken: de cellen die in de formule worden gebruikt zijn leeg, een extra spatie‑teken, spelfout, enz.
- #NAME? - een bepaalde cel of ander formule‑object kan niet worden gevonden op naam. 
- #NULL! - kan verschijnen wanneer er een fout in de formule zit, zoals  (,) of een spatie‑teken in plaats van een dubbele punt (:).
- #NUM! - het numerieke onderdeel in de formule kan ongeldig, te lang of te klein zijn, enz.
- #REF! - ongeldige celreferentie.
- #VALUE! - onverwacht type waarde. Bijvoorbeeld, een tekenreekswaarde ingesteld op een numerieke cel.

```php
  $cell = $workbook->getCell(0, "A2");
  $cell->setFormula("2 / 0");
  $value = $cell->getValue();// de waarde bevat de tekenreeks "#DIV/0!"


```

## **Rekenkundige operatoren**
U kunt alle rekenkundige operatoren gebruiken in formules van het grafiekwerkblad:

|**Operator**|**Betekenis**|**Voorbeeld**|
| :- | :- | :- |
|+ (plus‑teken)|Optelling of unair plus|2 + 3|
|- (min‑teken)|Aftrekking of negatie|2 - 3<br>-3|
|* (asterisk)|Vermenigvuldiging|2 * 3|
|/ (schuin streepje)|Deling|2 / 3|
|% (procentteken)|Percentage|30%|
|^ (caret)|Exponentiatie|2 ^ 3|

*Opmerking*: Om de volgorde van evaluatie te wijzigen, plaatst u het deel van de formule dat eerst moet worden berekend tussen haakjes.

## **Vergelijkingsoperatoren**
U kunt de waarden van cellen vergelijken met de vergelijkingsoperatoren. Wanneer twee waarden worden vergeleken met deze operatoren, is het resultaat een logische waarde, *TRUE* of *FALSE*:

|**Operator**|**Betekenis**|**Voorbeeld**|
| :- | :- | :- |
|= (gelijk‑teken)|Gelijk aan|A2 = 3|
|<> (niet‑gelijk‑teken)|Niet gelijk aan|A2 <> 3|
|> (groter‑dan‑teken)|Groter dan|A2 > 3|
|>= (groter‑dan‑of‑gelijk‑teken)|Groter dan of gelijk aan|A2 >= 3|
|< (kleiner‑dan‑teken)|Kleiner dan|A2 < 3|
|<= (kleiner‑dan‑of‑gelijk‑teken)|Kleiner dan of gelijk aan|A2 <= 3|

## **A1‑stijl celreferenties**
**A1‑stijl celreferenties** worden gebruikt voor werkbladen waarbij de kolom een letter‑identificatie heeft (bijv. "*A*") en de rij een numerieke identificatie (bijv. "*1*"). A1‑stijl celreferenties kunnen op de volgende manier worden gebruikt:

|**Celreferentie**|**Voorbeeld**| | |
| :- | :- | :- | :- |
| |Absoluut|Relatief|Gemengd|
|Cel|$A$2|A2|<p>A$2</p><p>$A2</p>|
|Rij|$2:$2|2:2|-|
|Kolom|$A:$A|A:A|-|
|Bereik|$A$2:$C$4|A2:C4|<p>$A$2:C4</p><p>A$2:$C4</p>|


Hier is een voorbeeld van hoe u een A1‑stijl celreferentie in een formule gebruikt:

```php
  $workbook->getCell(0, "A2")->setFormula("C3 + SUM(F2:H5)");

```

## **R1C1‑stijl celreferenties**
**R1C1‑stijl celreferenties** worden gebruikt voor werkbladen waarbij zowel rij als kolom een numerieke identificatie hebben. R1C1‑stijl celreferenties kunnen op de volgende manier worden gebruikt:

|**Celreferentie**|**Voorbeeld**| | |
| :- | :- | :- | :- |
| |Absoluut|Relatief|Gemengd|
|Cel|R2C3|R[2]C[3]|R2C[3]<br>R[2]C3|
|Rij|R2|R[2]|-|
|Kolom|C3|C[3]|-|
|Bereik|R2C3:R5C7|R[2]C[3]:R[5]C[7]|R2C3:R[5]C[7]<br>R[2]C3:R5C[7]|


Hier is een voorbeeld van hoe u een R1C1‑stijl celreferentie in een formule gebruikt:

```php
  $workbook->getCell(0, "A2")->setR1C1Formula("R2C4 + SUM(R5C6:R7C9)");

```

## **Vooraf gedefinieerde functies**
Er zijn vooraf gedefinieerde functies die in formules kunnen worden gebruikt om de implementatie te vereenvoudigen. Deze functies omvatten de meest voorkomende bewerkingen, zoals:

- ABS
- AVERAGE
- CEILING
- CHOOSE
- CONCAT
- CONCATENATE
- DATE (1900‑datumsysteem)
- DAYS
- FIND
- FINDB
- IF
- INDEX (referentievorm)
- LOOKUP (vectorvorm)
- MATCH (vectorvorm)
- MAX
- SUM
- VLOOKUP

## **FAQ**

**Worden externe Excel‑bestanden ondersteund als gegevensbron voor een grafiek met formules?**

Ja. Aspose.Slides ondersteunt externe werkboeken als een [chart's data source](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartdatasourcetype/), waardoor u formules uit een XLSX buiten de presentatie kunt gebruiken.

**Kunnen grafiekformules verwijzen naar bladen binnen hetzelfde werkboek op bladnaam?**

Ja. Formules volgen het standaard Excel‑referentiemodel, zodat u andere bladen binnen hetzelfde werkboek of een extern werkboek kunt refereren. Voor externe verwijzingen voegt u het pad en de werkboeknaam toe volgens de Excel‑syntaxis.
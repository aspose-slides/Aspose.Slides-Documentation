---
title: Chart-werkbladformules toepassen in presentaties met Java
linktitle: Werkbladformules
type: docs
weight: 70
url: /nl/java/chart-worksheet-formulas/
keywords:
- grafiek-spreadsheet
- grafiek-werkblad
- grafiekformule
- werkbladformule
- spreadsheet-formule
- gegevensbron
- logische constante
- numerieke constante
- tekenreeks-constante
- foutconstante
- rekenkundige constante
- vergelijkingsoperator
- A1-stijl
- R1C1-stijl
- vooraf gedefinieerde functie
- PowerPoint
- presentatie
- Java
- Aspose.Slides
description: "Pas Excel-achtige formules toe in Aspose.Slides voor Java-chart-werkbladen en automatiseer rapporten in PPT- en PPTX-bestanden."
---
## **Overzicht**

Een chart‑werkblad is de gegevensbron achter een diagram in een presentatie. Het slaat categorienamen en serienamen op, samen met de numerieke waarden die door het diagram worden weergegeven. In Aspose.Slides is dit werkblad beschikbaar via de chart‑data‑workbook, die je in staat stelt om programmatisch met diagramgegevens te werken.

Dit artikel legt uit hoe je werkblad‑formules in chart‑gegevens kunt gebruiken zodat celwaarden automatisch kunnen worden berekend en bijgewerkt in plaats van handmatig ingevoerd te worden. Het toont hoe je formules toewijst, zowel A1‑stijl‑ als R1C1‑stijl‑verwijzingen gebruikt, werkboek‑formules opnieuw berekent en werkt met de ondersteunde constanten, operatoren, celverwijzingen en vooraf gedefinieerde functies die beschikbaar zijn voor chart‑werkbladen in presentaties.

## **Over chart‑spreadsheet‑formules in presentaties**
**Chart spreadsheet** (of chart worksheet) in presentatie is de gegevensbron van het diagram. Chart spreadsheet bevat gegevens die grafisch op het diagram worden weergegeven. Wanneer je een diagram maakt in PowerPoint, wordt het bijbehorende werkblad automatisch aangemaakt. Een chart‑werkblad wordt aangemaakt voor alle diagramtypen: lijndiagram, staafdiagram, sunburst‑diagram, cirkeldiagram, enz. Om het chart‑spreadsheet in PowerPoint te zien, dubbelklik je op het diagram:

![todo:image_alt_text](chart-worksheet-formulas_1.png)


Chart spreadsheet bevat de namen van diagram­elementen (Category Name: *Category1*, Serie Name) en een tabel met numerieke gegevens die bij deze categorieën en series horen. Standaard, wanneer je een nieuw diagram maakt, worden de chart‑spreadsheet‑gegevens ingesteld op de standaardgegevens. Daarna kun je de spreadsheet‑gegevens in het werkblad handmatig wijzigen.

Meestal vertegenwoordigt het diagram complexe gegevens (bijv. financiële analisten, wetenschappelijke analisten), waarbij cellen worden berekend op basis van waarden in andere cellen of andere dynamische gegevens. Het handmatig berekenen van een celwaarde en deze hardcoderen in de cel maakt het moeilijk om deze later te wijzigen. Als je de waarde van een bepaalde cel wijzigt, moeten alle cellen die ervan afhankelijk zijn ook worden bijgewerkt. Bovendien kunnen tabelgegevens afhankelijk zijn van gegevens uit andere tabellen, waardoor een complex presentatiedatamodel ontstaat dat eenvoudig en flexibel moet kunnen worden bijgewerkt.

**Chart spreadsheet‑formule** in een presentatie is een expressie om chart‑spreadsheet‑gegevens automatisch te berekenen en bij te werken. Een spreadsheet‑formule definieert de logica voor de gegevensberekening voor een bepaalde cel of een reeks cellen. Een spreadsheet‑formule is een wiskundige formule of een logische formule, die gebruikmaakt van: celverwijzingen, wiskundige functies, logische operatoren, rekenkundige operatoren, conversiefuncties, tekenreeks‑constanten, enz. De definitie van de formule wordt in een cel geschreven, en deze cel bevat geen eenvoudige waarde. De spreadsheet‑formule berekent de waarde en geeft deze terug; daarna wordt deze waarde aan de cel toegewezen. Chart‑spreadsheet‑formules in presentaties zijn eigenlijk dezelfde als Excel‑formules, en er worden dezelfde standaardfuncties, operatoren en constanten ondersteund voor hun implementatie.

In [**Aspose.Slides**](https://products.aspose.com/slides/nl/java/) wordt chart‑spreadsheet weergegeven met 
[**Chart.getChartData.getChartDataWorkbook**](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IChartData#getChartDataWorkbook--) methode van het
[**IChartDataWorkbook**](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IChartDataWorkbook) type. 
Spreadsheet‑formule kan worden toegewezen en gewijzigd met 
[**IChartDataCell.setFormula**](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IChartDataCell#setFormula-java.lang.String-) methode. 
De volgende functionaliteit wordt ondersteund voor formules in Aspose.Slides:

- Logische constanten
- Numerieke constanten
- Tekenreeks‑constanten
- Fout‑constanten
- Rekenkundige operatoren
- Vergelijkingsoperatoren
- A1‑stijl celverwijzingen
- R1C1‑stijl celverwijzingen
- Vooraf gedefinieerde functies


Typisch slaan spreadsheets de laatst berekende formulewaarden op. Als na het laden van de presentatie de diagramgegevens niet zijn gewijzigd, retourneert de [**IChartDataCell.getValue**](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IChartDataCell#getValue--) methode die waarden bij het lezen. Maar als de spreadsheet‑gegevens wel gewijzigd zijn, gooit bij het lezen van de eigenschap **ChartDataCell.Value** een [**CellUnsupportedDataException**](https://reference.aspose.com/slides/nl/java/com.aspose.slides/CellUnsupportedDataException) voor de niet‑ondersteunde formules. Dit komt omdat wanneer formules succesvol worden geparseerd, de cel‑afhankelijkheden worden bepaald en de juistheid van de laatste waarden wordt vastgesteld. Als een formule echter niet kan worden geparseerd, kan de juistheid van de celwaarde niet worden gegarandeerd.

## **Een chart‑spreadsheet‑formule toevoegen aan een presentatie**
Eerst voeg je een diagram toe aan de eerste dia van een nieuwe presentatie met 
[IShapeCollection.getShapes.addChart](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IShapeCollection#addChart-int-float-float-float-float-). 
Het werkblad van het diagram wordt automatisch aangemaakt en is toegankelijk via 
[**Chart.getChartData.getChartDataWorkbook**](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IChartData#getChartDataWorkbook--) methode:



```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 150, 150, 500, 300);

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    // ...
} finally {
    if (pres != null) pres.dispose();
}
```

Laten we enkele waarden in cellen schrijven met 
[**IChartDataCell.setValue**](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IChartDataCell#setValue-java.lang.Object-) eigenschap 
van het type **Object**, wat betekent dat je elke waarde kunt toewijzen aan de eigenschap:

```java
workbook.getCell(0, "F2").setValue(-2.5);

workbook.getCell(0, "G3").setValue(6.3);

workbook.getCell(0, "H4").setValue(3);
```

Nu, om een formule in de cel te schrijven, kun je de 
[**IChartDataCell.setFormula**](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IChartDataCell#setFormula-java.lang.String-) methode gebruiken:

*Opmerking*: [**IChartDataCell.setFormula**](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IChartDataCell#setFormula-java.lang.String-) methode wordt gebruikt om A1‑stijl celverwijzingen in te stellen. 

Om de [R1C1Formula](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IChartDataCell#getR1C1Formula--) celreferentie in te stellen, kun je de [**IChartDataCell.setR1C1Formula**](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IChartDataCell#setR1C1Formula-java.lang.String-) methode gebruiken:

Vervolgens, als je de waarden uit de cellen B2 en C2 leest, worden ze berekend:

```java
Object value1 = cell1.getValue(); // 7.8

Object value2 = cell2.getValue(); // 2.1
```

## **Logische constanten**
Je kunt logische constanten zoals *FALSE* en *TRUE* gebruiken in cel‑formules:

```java
workbook.getCell(0, "A2").setValue(false);
IChartDataCell cell = workbook.getCell(0, "B2");
cell.setFormula("A2 = TRUE");
Object value = cell.getValue(); // de waarde bevat de booleaanse "false"
```

## **Numerieke constanten**
Getallen kunnen in gewone of wetenschappelijke notatie worden gebruikt om chart‑spreadsheet‑formules te maken:

```java
workbook.getCell(0, "A2").setFormula("1 + 0.5");
workbook.getCell(0, "B2").setFormula(".3 * 1E-2");
```

## **Tekenreeks‑constanten**
Een tekenreeks‑ (of letter‑) constante is een specifieke waarde die exact wordt gebruikt en niet verandert. Tekenreeks‑constanten kunnen zijn: datums, teksten, getallen, enz.:

```java
workbook.getCell(0, "A2").setFormula("\"abc\"");
workbook.getCell(0, "B2").setFormula("\"2/3/2020 12:00\"");
```

## **Fout‑constanten**
Soms is het niet mogelijk om het resultaat te berekenen met de formule. In dat geval wordt de foutcode in de cel weergegeven in plaats van de waarde. Elke fout heeft een specifieke code:

- #DIV/0! – formule probeert te delen door nul.
- #GETTING_DATA – kan in een cel verschijnen terwijl de waarde nog wordt berekend.
- #N/A – informatie ontbreekt of is niet beschikbaar. Mogelijke oorzaken: de cellen die in de formule worden gebruikt zijn leeg, er staat een extra spatie, een spelfout, enz.
- #NAME? – een bepaalde cel of ander formule‑object kan niet worden gevonden op naam. 
- #NULL! – kan verschijnen wanneer er een fout in de formule staat, zoals:  (,) of een spatie in plaats van een dubbele punt (:).
- #NUM! – het numerieke onderdeel van de formule is ongeldig, te lang of te kort, enz.
- #REF! – ongeldige celreferentie.
- #VALUE! – onverwacht type waarde. Bijvoorbeeld, een tekenreekswaarde toegewezen aan een numerieke cel.

```java
IChartDataCell cell = workbook.getCell(0, "A2");
cell.setFormula("2 / 0");
Object value = cell.getValue(); // de waarde bevat de tekenreeks "#DIV/0!"
```

## **Rekenkundige operatoren**
Je kunt alle rekenkundige operatoren gebruiken in chart‑werkblad‑formules:

|**Operator**|**Betekenis**|**Voorbeeld**|
| :- | :- | :- |
|+ (plus‑teken)|Additie of unair plus|2 + 3|
|- (min‑teken)|Aftrekking of negatie|2 - 3<br>-3|
|* (asterisk)|Vermenigvuldiging|2 * 3|
|/ (schuine streep)|Deling|2 / 3|
|% (procentteken)|Procent|30%|
|^ (caret)|Exponentiëring|2 ^ 3|

*Opmerking*: Om de volgorde van evaluatie te wijzigen, plaats je haakjes rond het deel van de formule dat eerst moet worden berekend.

## **Vergelijkingsoperatoren**
Je kunt de waarden van cellen vergelijken met de vergelijkingsoperatoren. Wanneer twee waarden met deze operatoren worden vergeleken, levert het resultaat een logische waarde op: *TRUE* of *FALSE*:

|**Operator**|**Betekenis**|**Betekenis**|
| :- | :- | :- |
|= (gelijk‑teken)|Gelijk aan|A2 = 3|
|<> (niet‑gelijk‑teken)|Niet gelijk aan|A2 <> 3|
|> (groter‑dan‑teken)|Groter dan|A2 > 3|
|>= (groter‑dan‑of‑gelijk‑teken)|Groter dan of gelijk aan|A2 >= 3|
|< (kleiner‑dan‑teken)|Kleiner dan|A2 < 3|
|<= (kleiner‑dan‑of‑gelijk‑teken)|Kleiner dan of gelijk aan|A2 <= 3|

## **A1‑stijl celverwijzingen**
**A1‑stijl celverwijzingen** worden gebruikt voor werkbladen waarbij de kolom een letter‑identificator heeft (bijv. "*A*") en de rij een numerieke identificator (bijv. "*1*"). A1‑stijl celverwijzingen kunnen als volgt worden gebruikt:

|**Celreferentie**|**Voorbeeld**|||
| :- | :- | :- | :- |
||Absoluut|Relatief|Gemengd|
|Cel|$A$2|A2|<p>A$2</p><p>$A2</p>|
|Rij|$2:$2|2:2|-|
|Kolom|$A:$A|A:A|-|
|Bereik|$A$2:$C$4|A2:C4|<p>$A$2:C4</p><p>A$2:$C4</p>|


Hier is een voorbeeld van hoe je een A1‑stijl celreferentie in een formule gebruikt:

```java
workbook.getCell(0, "A2").setFormula("C3 + SUM(F2:H5)");
```

## **R1C1‑stijl celverwijzingen**
**R1C1‑stijl celverwijzingen** worden gebruikt voor werkbladen waarbij zowel rij als kolom een numerieke identifier hebben. R1C1‑stijl celverwijzingen kunnen als volgt worden gebruikt:

|**Celreferentie**|**Voorbeeld**|||
| :- | :- | :- | :- |
||Absoluut|Relatief|Gemengd|
|Cel|R2C3|R[2]C[3]|R2C[3]<br>R[2]C3|
|Rij|R2|R[2]|-|
|Kolom|C3|C[3]|-|
|Bereik|R2C3:R5C7|R[2]C[3]:R[5]C[7]|R2C3:R[5]C[7]<br>R[2]C3:R5C[7]|


Hier is een voorbeeld van hoe je een R1C1‑stijl celreferentie in een formule gebruikt:

```java
workbook.getCell(0, "A2").setR1C1Formula("R2C4 + SUM(R5C6:R7C9)");
```

## **Vooraf gedefinieerde functies**
Er zijn vooraf gedefinieerde functies die in formules kunnen worden gebruikt om hun implementatie te vereenvoudigen. Deze functies omvatten de meest gebruikte bewerkingen, zoals: 

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
- INDEX (referentie‑vorm)
- LOOKUP (vector‑vorm)
- MATCH (vector‑vorm)
- MAX
- SUM
- VLOOKUP

## **FAQ**

**Worden externe Excel‑bestanden ondersteund als gegevensbron voor een diagram met formules?**

Ja. Aspose.Slides ondersteunt externe werkboeken als een [chart's data source](https://reference.aspose.com/slides/nl/java/com.aspose.slides/chartdatasourcetype/), waardoor je formules uit een XLSX buiten de presentatie kunt gebruiken.

**Kunnen diagram‑formules verwijzen naar bladen binnen hetzelfde werkboek op bladnaam?**

Ja. Formules volgen het standaard Excel‑referentiemodel, zodat je andere bladen binnen hetzelfde werkboek of een extern werkboek kunt refereren. Voor externe verwijzingen moet je het pad en de werkboeknaam opnemen volgens de Excel‑syntaxis.
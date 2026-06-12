---
title: Toepassen van grafiekwerkbladformules in presentaties op Android
linktitle: Werkbladformules
type: docs
weight: 70
url: /nl/androidjava/chart-worksheet-formulas/
keywords:
- grafiek‑spreadsheet
- grafiekwerkblad
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
- Android
- Java
- Aspose.Slides
description: "Pas Excel‑achtige formules toe in Aspose.Slides voor Android via Java‑grafiekwerkbladen en automatiseer rapporten in PPT‑ en PPTX‑bestanden."
---
## **Overzicht**

Een grafiekwerkblad is de gegevensbron achter een grafiek in een presentatie. Het slaat categorie‑ en serie‑namen op samen met de numerieke waarden die door de grafiek worden weergegeven. In Aspose.Slides is dit werkblad beschikbaar via het diagramgegevens‑werkboek, waarmee u programmatisch met diagramgegevens kunt werken.

Dit artikel legt uit hoe u werkbladformules in diagramgegevens kunt gebruiken zodat celwaarden automatisch berekend en bijgewerkt worden in plaats van handmatig ingevoerd te worden. Het laat zien hoe u formules toewijst, zowel A1‑stijl‑ als R1C1‑stijloverwijzingen gebruikt, werkboekformules opnieuw berekent en werkt met de ondersteunde constanten, operatoren, celverwijzingen en vooraf gedefinieerde functies die beschikbaar zijn voor grafiekwerkbladen in presentaties.

## **Over grafiek‑spreadsheet‑formules in presentaties**
**Grafiek‑spreadsheet** (of grafiekwerkblad) in een presentatie is de gegevensbron van de grafiek. Een grafiek‑spreadsheet bevat gegevens die op de grafiek grafisch worden weergegeven. Wanneer u een grafiek maakt in PowerPoint, wordt het bijbehorende werkblad automatisch aangemaakt. Een grafiekwerkblad wordt aangemaakt voor alle soorten grafieken: lijngrafiek, staafgrafiek, sunburst‑grafiek, cirkeldiagram, enz. Om de grafiek‑spreadsheet in PowerPoint te zien, moet u dubbelklikken op de grafiek:

![todo:image_alt_text](chart-worksheet-formulas_1.png)


Een grafiek‑spreadsheet bevat de namen van grafiekelementen (Categorie‑naam: *Category1*, Serie‑naam) en een tabel met numerieke gegevens die bij deze categorieën en series passen. Standaard, wanneer u een nieuwe grafiek maakt, worden de grafiek‑spreadsheet‑gegevens ingesteld op de standaardgegevens. Vervolgens kunt u de spreadsheet‑gegevens in het werkblad handmatig aanpassen.

Normaal gesproken vertegenwoordigt de grafiek complexe gegevens (bijv. financiële analisten, wetenschappelijke analisten), met cellen die berekend worden op basis van waarden in andere cellen of uit andere dynamische gegevens. Het handmatig berekenen van de celwaarde en hardcoderen daarvan in de cel maakt het moeilijk om later te wijzigen. Als u de waarde van een bepaalde cel wijzigt, moeten alle afhankelijkheden ook bijgewerkt worden. Bovendien kunnen tabelgegevens afhangen van gegevens uit andere tabellen, waardoor een complex presentatiedataschema ontstaat dat op een eenvoudige en flexibele manier moet worden bijgewerkt.

**Grafiek‑spreadsheet‑formule** in een presentatie is een uitdrukking om automatisch grafiek‑spreadsheet‑gegevens te berekenen en bij te werken. Een spreadsheet‑formule definieert de gegevensberekeningslogica voor een bepaalde cel of een set cellen. Een spreadsheet‑formule is een wiskundige of logische formule die gebruikmaakt van: celverwijzingen, rekenfuncties, logische operatoren, rekenoperatoren, conversiefuncties, tekenreeks‑constant(en), enz. De definitie van de formule wordt in een cel geschreven, en deze cel bevat geen eenvoudige waarde. De spreadsheet‑formule berekent de waarde en retourneert deze, waarna deze waarde aan de cel wordt toegewezen. Grafiek‑spreadsheet‑formules in presentaties zijn in feite dezelfde als Excel‑formules, en er worden dezelfde standaardfuncties, operatoren en constanten ondersteund voor hun implementatie.

In [**Aspose.Slides**](https://products.aspose.com/slides/nl/androidjava/) wordt de grafiek‑spreadsheet weergegeven met de methode [**Chart.getChartData.getChartDataWorkbook**](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IChartData#getChartDataWorkbook--) van het type [**IChartDataWorkbook**](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IChartDataWorkbook). Een spreadsheet‑formule kan worden toegewezen en gewijzigd met de methode [**IChartDataCell.setFormula**](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IChartDataCell#setFormula-java.lang.String-).

De volgende functionaliteit wordt ondersteund voor formules in Aspose.Slides:

- Logische constanten
- Numerieke constanten
- Tekenreeks‑constanten
- Fout‑constanten
- Rekenoperatoren
- Vergelijkingsoperatoren
- A1‑stijlcellenverwijzingen
- R1C1‑stijlcellenverwijzingen
- Vooraf gedefinieerde functies

Typisch slaan spreadsheets de laatst berekende formulewaarden op. Als na het laden van de presentatie de diagramgegevens niet gewijzigd zijn, retourneert de methode [**IChartDataCell.getValue**](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IChartDataCell#getValue--) die waarden bij het lezen. Maar als de spreadsheet‑gegevens zijn gewijzigd, wordt bij het lezen van de eigenschap **ChartDataCell.Value** een [**CellUnsupportedDataException**](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/CellUnsupportedDataException) gegooid voor de niet‑ondersteunde formules. Dit komt doordat wanneer formules succesvol worden geparseerd, de cel‑afhankelijkheden worden bepaald en de juistheid van de laatste waarden wordt vastgesteld. Maar als de formule niet kan worden geparseerd, kan de juistheid van de celwaarde niet worden gegarandeerd.

## **Een grafiek‑spreadsheet‑formule toevoegen aan een presentatie**
Eerst voegt u een grafiek toe aan de eerste dia van een nieuwe presentatie met [IShapeCollection.getShapes.addChart](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IShapeCollection#addChart-int-float-float-float-float-). Het werkblad van de grafiek wordt automatisch aangemaakt en kan worden benaderd met de methode [**Chart.getChartData.getChartDataWorkbook**](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IChartData#getChartDataWorkbook--) :

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

Laten we enkele waarden in cellen schrijven met de eigenschap [**IChartDataCell.setValue**](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IChartDataCell#setValue-java.lang.Object-) van het type **Object**, wat betekent dat u elke waarde aan de eigenschap kunt toewijzen:

```java
workbook.getCell(0, "F2").setValue(-2.5);

workbook.getCell(0, "G3").setValue(6.3);

workbook.getCell(0, "H4").setValue(3);
```

Nu, om een formule aan de cel toe te wijzen, kunt u de methode [**IChartDataCell.setFormula**](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IChartDataCell#setFormula-java.lang.String-) gebruiken:

*Opmerking*: De methode [**IChartDataCell.setFormula**](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IChartDataCell#setFormula-java.lang.String-) wordt gebruikt om A1‑stijlcellenverwijzingen in te stellen.

Om de [R1C1Formula](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IChartDataCell#getR1C1Formula--) celverwijzing in te stellen, kunt u de methode [**IChartDataCell.setR1C1Formula**](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IChartDataCell#setR1C1Formula-java.lang.String-) gebruiken:

Als u vervolgens de waarden uit de cellen B2 en C2 probeert te lezen, worden ze berekend:

```java
Object value1 = cell1.getValue(); // 7.8

Object value2 = cell2.getValue(); // 2.1
```

## **Logische constanten**
U kunt logische constanten zoals *FALSE* en *TRUE* gebruiken in cel‑formules:

```java
workbook.getCell(0, "A2").setValue(false);
IChartDataCell cell = workbook.getCell(0, "B2");
cell.setFormula("A2 = TRUE");
Object value = cell.getValue(); // de waarde bevat booleaanse "false"
```

## **Numerieke constanten**
Getallen kunnen in gewone of wetenschappelijke notatie worden gebruikt om een grafiek‑spreadsheet‑formule te maken:

```java
workbook.getCell(0, "A2").setFormula("1 + 0.5");
workbook.getCell(0, "B2").setFormula(".3 * 1E-2");
```

## **Tekenreeks‑constanten**
Een tekenreeks‑ (of letter‑) constante is een specifieke waarde die precies zo wordt gebruikt en niet verandert. Tekenreeks‑constanten kunnen zijn: datums, teksten, getallen, enz.:

```java
workbook.getCell(0, "A2").setFormula("\"abc\"");
workbook.getCell(0, "B2").setFormula("\"2/3/2020 12:00\"");
```

## **Fout‑constanten**
Soms is het niet mogelijk om het resultaat met de formule te berekenen. In dat geval wordt de foutcode in de cel weergegeven in plaats van de waarde. Elk type fout heeft een specifieke code:

- #DIV/0! – formule probeert te delen door nul.
- #GETTING_DATA – kan worden weergegeven in een cel terwijl de waarde nog wordt berekend.
- #N/A – informatie ontbreekt of is niet beschikbaar. Mogelijke oorzaken: de cellen die in de formule worden gebruikt zijn leeg, er staat een extra spatie, een spelfout, enz.
- #NAME? – een bepaalde cel of ander formule‑object kan niet worden gevonden op naam.
- #NULL! – kan verschijnen wanneer er een fout in de formule zit, zoals: (,) of een spatie gebruikt in plaats van een dubbele punt (:).
- #NUM! – het numerieke deel van de formule kan onjuist, te lang of te klein zijn, enz.
- #REF! – ongeldige celverwijzing.
- #VALUE! – onverwacht waarde‑type. Bijvoorbeeld, een tekenreekswaarde ingesteld op een numerieke cel.

```java
IChartDataCell cell = workbook.getCell(0, "A2");
cell.setFormula("2 / 0");
Object value = cell.getValue(); // de waarde bevat de tekenreeks "#DIV/0!"
```

## **Rekenoperatoren**
U kunt alle rekenoperatoren gebruiken in grafiek‑werkblad‑formules:

|**Operator**|**Betekenis**|**Voorbeeld**|
| :- | :- | :- |
|+ (plus sign)|Optelling of unair plus|2 + 3|
|- (minus sign)|Aftrekking of ontkenning|2 - 3<br>-3|
|* (asterisk)|Vermenigvuldiging|2 * 3|
|/ (forward slash)|Deling|2 / 3|
|% (percent sign)|Percentage|30%|
|^ (caret)|Exponentiatie|2 ^ 3|

*Opmerking*: Om de volgorde van evaluatie te wijzigen, zet u het deel van de formule dat eerst moet worden berekend tussen haakjes.

## **Vergelijkingsoperatoren**
U kunt de waarden van cellen vergelijken met de vergelijkingsoperatoren. Wanneer twee waarden met deze operatoren worden vergeleken, is het resultaat een logische waarde, *TRUE* of FALSE:

|**Operator**|**Betekenis**|**Voorbeeld**|
| :- | :- | :- |
|= (equal sign)|Gelijk aan|A2 = 3|
|<> (not equal sign)|Niet gelijk aan|A2 <> 3|
|> (greater than sign)|Groter dan|A2 > 3|
|>= (greater than or equal to sign)|Groter dan of gelijk aan|A2 >= 3|
|< (less than sign)|Kleiner dan|A2 < 3|
|<= (less than or equal to sign)|Kleiner dan of gelijk aan|A2 <= 3|

## **A1‑stijlcellenverwijzingen**
**A1‑stijlcellenverwijzingen** worden gebruikt voor werkbladen waarbij de kolom een letter‑identificatie heeft (bijv. “*A*”) en de rij een numerieke identificatie (bijv. “*1*”). A1‑stijlcellenverwijzingen kunnen op de volgende manier worden gebruikt:

|**Celverwijzing**|**Voorbeeld**|||
| :- | :- | :- | :- |
||Absoluut|Relatief|Gemengd|
|Cel|$A$2|A2|<p>A$2</p><p>$A2</p>|
|Rij|$2:$2|2:2|-|
|Kolom|$A:$A|A:A|-|
|Bereik|$A$2:$C$4|A2:C4|<p>$A$2:C4</p><p>A$2:$C4</p>|

Hier is een voorbeeld van hoe een A1‑stijlcellenverwijzing in een formule te gebruiken:

```java
workbook.getCell(0, "A2").setFormula("C3 + SUM(F2:H5)");
```

## **R1C1‑stijlcellenverwijzingen**
**R1C1‑stijlcellenverwijzingen** worden gebruikt voor werkbladen waarbij zowel de rij als de kolom een numerieke identificatie hebben. R1C1‑stijlcellenverwijzingen kunnen op de volgende manier worden gebruikt:

|**Celverwijzing**|**Voorbeeld**|||
| :- | :- | :- | :- |
||Absoluut|Relatief|Gemengd|
|Cel|R2C3|R[2]C[3]|R2C[3]<br>R[2]C3|
|Rij|R2|R[2]|-|
|Kolom|C3|C[3]|-|
|Bereik|R2C3:R5C7|R[2]C[3]:R[5]C[7]|R2C3:R[5]C[7]<br>R[2]C3:R5C[7]|

Hier is een voorbeeld van hoe een R1C1‑stijlcellenverwijzing in een formule te gebruiken:

```java
workbook.getCell(0, "A2").setR1C1Formula("R2C4 + SUM(R5C6:R7C9)");
```

## **Vooraf gedefinieerde functies**
Er zijn vooraf gedefinieerde functies die in de formules kunnen worden gebruikt om hun implementatie te vereenvoudigen. Deze functies bevatten de meest gebruikte bewerkingen, zoals:

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

**Worden externe Excel‑bestanden ondersteund als gegevensbron voor een grafiek met formules?**

Ja. Aspose.Slides ondersteunt externe werkboeken als [gegevensbron van een grafiek](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/chartdatasourcetype/), waardoor u formules uit een XLSX‑bestand buiten de presentatie kunt gebruiken.

**Kunnen grafiekformules bladnamen binnen hetzelfde werkboek refereren?**

Ja. Formules volgen het standaard Excel‑referentiemodel, zodat u andere bladen binnen hetzelfde werkboek of een extern werkboek kunt refereren. Voor externe referenties neemt u het pad en de werkboeknaam op volgens de Excel‑syntaxis.
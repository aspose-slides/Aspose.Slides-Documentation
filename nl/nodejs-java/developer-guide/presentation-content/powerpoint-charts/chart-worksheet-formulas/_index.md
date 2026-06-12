---
title: Grafiekwerkbladformules toepassen in presentaties met JavaScript
linktitle: Werkbladformules
type: docs
weight: 70
url: /nl/nodejs-java/chart-worksheet-formulas/
keywords:
- grafiekrekenblad
- grafiekwerkblad
- grafiekformule
- werkbladformule
- rekenbladformule
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Pas Excel‑achtige formules toe in Aspose.Slides voor Node.js via Java‑grafiekwerkbladen en automatiseer rapporten in PPT‑ en PPTX‑bestanden met JavaScript."
---
## **Overzicht**

Een grafiekwerkblad is de gegevensbron achter een grafiek in een presentatie. Het slaat categorie‑ en serienaam­men op samen met de numerieke waarden die door de grafiek worden weergegeven. In Aspose.Slides is dit werkblad beschikbaar via het grafiek‑databoek, waarmee je programmatisch met grafiekgegevens kunt werken.

Dit artikel legt uit hoe je werkbladformules in grafiekgegevens kunt gebruiken zodat celwaarden automatisch berekend en bijgewerkt worden in plaats van handmatig ingevoerd. Het laat zien hoe je formules toekent, zowel A1‑ als R1C1‑stijl verwijzingen gebruikt, werkboekformules opnieuw berekent, en werkt met de ondersteunde constanten, operatoren, celverwijzingen en vooraf gedefinieerde functies die beschikbaar zijn voor grafiekwerkbladen in presentaties.

## **Over grafiek‑rekenbladformule in een presentatie**
**Grafiekrekenblad** (of grafiekwerkblad) in een presentatie is de gegevensbron van de grafiek. Het grafiekrekenblad bevat gegevens die grafisch in de grafiek worden weergegeven. Wanneer je een grafiek in PowerPoint maakt, wordt het bijbehorende werkblad automatisch aangemaakt. Het grafiekwerkblad wordt aangemaakt voor alle soorten grafieken: lijngrafiek, staafgrafiek, sunburst‑grafiek, taartgrafiek, enz. Om het grafiekrekenblad in PowerPoint te zien, moet je dubbelklikken op de grafiek:

![todo:image_alt_text](chart-worksheet-formulas_1.png)


Het grafiekrekenblad bevat de namen van grafelementen (Categorie‑naam: *Category1*, Serie‑naam) en een tabel met numerieke gegevens die bij deze categorieën en series passen. Standaard, wanneer je een nieuwe grafiek maakt, worden de grafiekrekenblad‑gegevens ingesteld op de standaardgegevens. Daarna kun je de rekenbladgegevens handmatig in het werkblad aanpassen.

Gewoonlijk vertegenwoordigt de grafiek gecompliceerde gegevens (bijv. financiële analisten, wetenschappelijke analisten), met cellen die berekend worden op basis van waarden in andere cellen of andere dynamische gegevens. Het handmatig berekenen van de celwaarde en hard‑coderen in de cel maakt het moeilijk om later wijzigingen aan te brengen. Als je de waarde van een bepaalde cel wijzigt, moeten alle afhankelijkere cellen ook bijgewerkt worden. Bovendien kunnen tabelgegevens afhankelijk zijn van gegevens uit andere tabellen, waardoor een complex presentatiedataset‑schema ontstaat dat op een eenvoudige en flexibele manier moet kunnen worden bijgewerkt.

**Grafiekrekenbladformule** in een presentatie is een uitdrukking die grafiekrekenblad‑gegevens automatisch berekent en bijwerkt. Een rekenbladformule definieert de gegevens‑berekeningslogica voor een bepaalde cel of een set cellen. Een rekenbladformule is een wiskundige formule of een logische formule, die gebruik maakt van: celverwijzingen, wiskundige functies, logische operatoren, rekenkundige operatoren, conversiefuncties, tekenreeks‑constanten, enz. De definitie van de formule wordt in een cel geschreven, en deze cel bevat geen eenvoudige waarde. De rekenbladformule berekent de waarde en retourneert deze, waarna de waarde aan de cel wordt toegewezen. Grafiekrekenbladformules in presentaties zijn eigenlijk dezelfde als Excel‑formules, en er worden dezelfde standaardfuncties, operatoren en constanten ondersteund voor hun implementatie.

In [**Aspose.Slides**](https://products.aspose.com/slides/nl/nodejs-java/) wordt het grafiekrekenblad vertegenwoordigd door de methode
[**Chart.getChartData.getChartDataWorkbook**](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ChartData#getChartDataWorkbook--) van het type
[**ChartDataWorkbook**](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ChartDataWorkbook).
Een rekenbladformule kan worden toegekend en gewijzigd met de
[**ChartDataCell.setFormula**](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ChartDataCell#setFormula-java.lang.String-) methode.
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

Doorgaans slaan spreadsheets de laatst berekende formulewaarden op. Als na het laden van de presentatie de grafiekgegevens niet gewijzigd zijn, geeft de methode [**ChartDataCell.getValue**](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ChartDataCell#getValue--) die waarden terug tijdens het lezen. Maar als de spreadsheet‑gegevens wel zijn gewijzigd, gooit het lezen van de **ChartDataCell.Value**‑property de [**CellUnsupportedDataException**](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/CellUnsupportedDataException) voor de niet‑ondersteunde formules. Dit komt doordat wanneer formules succesvol worden geparseerd, de cel‑afhankelijkheden worden bepaald en de juistheid van de laatste waarden wordt vastgesteld. Indien de formule echter niet kan worden geparseerd, kan de juistheid van de celwaarde niet worden gegarandeerd.

## **Grafiekrekenbladformule toevoegen aan een presentatie**
Eerst voeg je een grafiek toe aan de eerste dia van een nieuwe presentatie met 
[ShapeCollection.getShapes.addChart](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ShapeCollection#addChart-int-float-float-float-float-).
Het werkblad van de grafiek wordt automatisch aangemaakt en kan worden benaderd met de 
[**Chart.getChartData.getChartDataWorkbook**](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ChartData#getChartDataWorkbook--) methode:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 150, 150, 500, 300);
    var workbook = chart.getChartData().getChartDataWorkbook();
    // ...
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Laten we enkele waarden in cellen schrijven met de 
[**ChartDataCell.setValue**](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ChartDataCell#setValue-java.lang.Object-) eigenschap 
van het type **Object**, wat betekent dat je elke waarde aan de eigenschap kunt toewijzen:

```javascript
workbook.getCell(0, "F2").setValue(-2.5);
workbook.getCell(0, "G3").setValue(6.3);
workbook.getCell(0, "H4").setValue(3);
```

Om nu een formule in de cel te schrijven, kun je de 
[**ChartDataCell.setFormula**](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ChartDataCell#setFormula-java.lang.String-) methode gebruiken:

*Opmerking*: [**ChartDataCell.setFormula**](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ChartDataCell#setFormula-java.lang.String-) methode wordt gebruikt om A1‑stijl celverwijzingen in te stellen. 

Om de [R1C1Formula](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ChartDataCell#getR1C1Formula--) celverwijzing in te stellen, kun je de [**ChartDataCell.setR1C1Formula**](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ChartDataCell#setR1C1Formula-java.lang.String-) methode gebruiken:

Als je vervolgens de waarden van de cellen B2 en C2 leest, worden ze berekend:

```javascript
var value1 = cell1.getValue();// 7.8
var value2 = cell2.getValue();// 2.1
```

## **Logische constanten**
Je kunt logische constanten zoals *FALSE* en *TRUE* gebruiken in cel‑formules:

```javascript
workbook.getCell(0, "A2").setValue(false);
var cell = workbook.getCell(0, "B2");
cell.setFormula("A2 = TRUE");
var value = cell.getValue();// de waarde bevat de boolean "false"
```

## **Numerieke constanten**
Getallen kunnen in gewone of wetenschappelijke notatie worden gebruikt om een grafiekrekenbladformule te maken:

```javascript
workbook.getCell(0, "A2").setFormula("1 + 0.5");
workbook.getCell(0, "B2").setFormula(".3 * 1E-2");
```

## **Tekenreeks‑constanten**
Een tekenreeks‑ (of letterlijke) constante is een specifieke waarde die precies zo wordt gebruikt en niet verandert. Tekenreeks‑constanten kunnen zijn: datums, teksten, getallen, enz.:

```javascript
workbook.getCell(0, "A2").setFormula("\"abc\"");
workbook.getCell(0, "B2").setFormula("\"2/3/2020 12:00\"");
```

## **Fout‑constanten**
Soms is het niet mogelijk om het resultaat met de formule te berekenen. In dat geval wordt in de cel een foutcode weergegeven in plaats van de waarde. Elke fout heeft een specifieke code:

- #DIV/0! – formule probeert te delen door nul.
- #GETTING_DATA – kan worden weergegeven in een cel, terwijl de waarde nog wordt berekend.
- #N/A – informatie ontbreekt of is niet beschikbaar. Mogelijke oorzaken: de cellen die in de formule worden gebruikt zijn leeg, er staat een extra spatie, typefout, enz.
- #NAME? – een bepaalde cel of ander formule‑object kan niet gevonden worden op naam.
- #NULL! – kan verschijnen wanneer er een fout in de formule staat, bijvoorbeeld:  (,) of een spatie in plaats van een dubbele punt (:).
- #NUM! – het numerieke deel in de formule kan ongeldig, te lang of te kort zijn, enz.
- #REF! – ongeldige celverwijzing.
- #VALUE! – onverwacht type waarde. Bijvoorbeeld een tekenreekswaarde in een numerieke cel.

```javascript
var cell = workbook.getCell(0, "A2");
cell.setFormula("2 / 0");
var value = cell.getValue();// de waarde bevat de tekenreeks "#DIV/0!"
```

## **Rekenkundige operatoren**
Je kunt alle rekenkundige operatoren gebruiken in grafiekwerkblad‑formules:

|**Operator**|**Betekenis**|**Voorbeeld**|
| :- | :- | :- |
|+ (plus‑teken) |Optelling of unair plus|2 + 3|
|- (minus‑teken) |Aftrekking of negatie |2 - 3<br>-3|
|* (asterisk) |Vermenigvuldiging |2 * 3|
|/ (slash) |Deling |2 / 3|
|% (procentteken) |Procent |30%|
|^ (caret) |Exponentiatie |2 ^ 3|

*Opmerking*: Om de volgorde van evaluatie te wijzigen, omring je het deel van de formule dat eerst berekend moet worden met haakjes.

## **Vergelijkingsoperatoren**
Je kunt de waarden van cellen vergelijken met de vergelijkingsoperatoren. Wanneer twee waarden met deze operatoren worden vergeleken, is het resultaat een logische waarde, *TRUE* of FALSE:

|**Operator**|**Betekenis**|**Voorbeeld**|
| :- | :- | :- |
|= (gelijk‑teken) |Gelijk aan |A2 = 3|
|<> (niet‑gelijk‑teken) |Niet gelijk aan|A2 <> 3|
|> (groter‑dan‑teken) |Groter dan|A2 > 3|
|>= (groter‑dan‑of‑gelijk‑teken) |Groter dan of gelijk aan|A2 >= 3|
|< (kleiner‑dan‑teken) |Kleiner dan|A2 < 3|
|<= (kleiner‑dan‑of‑gelijk‑teken) |Kleiner dan of gelijk aan|A2 <= 3|

## **A1‑stijl celverwijzingen**
**A1‑stijl celverwijzingen** worden gebruikt voor werkbladen waarbij de kolom een letter‑identificatie heeft (bijv. “*A*”) en de rij een numerieke identificatie (bijv. “*1*”). A1‑stijl celverwijzingen kunnen op de volgende manier worden gebruikt:

|**Celverwijzing**|**Voorbeeld**|||
| :- | :- | :- | :- |
||Absoluut |Relatief |Gemengd|
|Cel |$A$2 |A2|<p>A$2</p><p>$A2</p>|
|Rij |$2:$2 |2:2 |-|
|Kolom |$A:$A |A:A |-|
|Bereik |$A$2:$C$4 |A2:C4|<p>$A$2:C4</p><p>A$2:$C4</p>|

Hier is een voorbeeld van hoe je een A1‑stijl celverwijzing in een formule gebruikt:

```javascript
workbook.getCell(0, "A2").setFormula("C3 + SUM(F2:H5)");
```

## **R1C1‑stijl celverwijzingen**
**R1C1‑stijl celverwijzingen** worden gebruikt voor werkbladen waarbij zowel rij als kolom een numerieke identificatie hebben. R1C1‑stijl celverwijzingen kunnen op de volgende manier worden gebruikt:

|**Celverwijzing**|**Voorbeeld**|||
| :- | :- | :- | :- |
||Absoluut |Relatief |Gemengd|
|Cel |R2C3|R[2]C[3]|R2C[3]<br>R[2]C3|
|Rij |R2|R[2]|-|
|Kolom |C3|C[3]|-|
|Bereik |R2C3:R5C7|R[2]C[3]:R[5]C[7] |R2C3:R[5]C[7]<br>R[2]C3:R5C[7]|

Hier is een voorbeeld van hoe je een R1C1‑stijl celverwijzing in een formule gebruikt:

```javascript
workbook.getCell(0, "A2").setR1C1Formula("R2C4 + SUM(R5C6:R7C9)");
```

## **Vooraf gedefinieerde functies**
Er zijn vooraf gedefinieerde functies die in de formules kunnen worden gebruikt om hun implementatie te vereenvoudigen. Deze functies omvatten de meestgebruikte bewerkingen, zoals: 

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

Ja. Aspose.Slides ondersteunt externe werkboeken als een [gegevensbron van de grafiek](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chartdatasourcetype/), waardoor je formules uit een XLSX‑bestand buiten de presentatie kunt gebruiken.

**Kunnen grafiekformules naar werkbladen binnen hetzelfde werkboek refereren op bladnaam?**

Ja. Formules volgen het standaard Excel‑referentiemodel, zodat je naar andere bladen binnen hetzelfde werkboek of een extern werkboek kunt verwijzen. Voor externe verwijzingen neem je het pad en de werkboeknaam op volgens de Excel‑syntaxis.
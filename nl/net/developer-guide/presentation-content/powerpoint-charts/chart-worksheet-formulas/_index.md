---
title: Formules voor grafiekwerkbladen toepassen in presentaties in .NET
linktitle: Werkbladformules
type: docs
weight: 70
url: /nl/net/chart-worksheet-formulas/
keywords:
- grafiek spreadsheet
- grafiek werkblad
- grafiek formule
- werkbladformule
- spreadsheetformule
- gegevensbron
- logische constante
- numerieke constante
- tekenreeksconstante
- foutconstante
- rekenkundige constante
- vergelijkingsoperator
- A1-stijl
- R1C1-stijl
- vooraf gedefinieerde functie
- PowerPoint
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Pas Excel-achtige formules toe in Aspose.Slides voor .NET grafiekwerkbladen en automatiseer rapporten in PPT- en PPTX-bestanden."
---
## **Overzicht**

Een chart worksheet is de gegevensbron achter een grafiek in een presentatie. Het slaat categorie‑ en serienaam op samen met de numerieke waarden die door de grafiek worden weergegeven. In Aspose.Slides is dit werkblad beschikbaar via de chart data workbook, die je in staat stelt om programmatisch met grafiekgegevens te werken.

Dit artikel legt uit hoe je werkbladformules in chart‑data kunt gebruiken zodat celwaarden automatisch kunnen worden berekend en bijgewerkt in plaats van handmatig in te voeren. Het laat zien hoe je formules toewijst, zowel A1‑stijl‑ als R1C1‑stijl‑referenties gebruikt, werkbladformules opnieuw berekent en werkt met de ondersteunde constanten, operatoren, celreferenties en vooraf gedefinieerde functies die beschikbaar zijn voor chart‑werkbladen in presentaties.

## **Over chart‑spreadsheet‑formules in presentaties**
**Chart spreadsheet** (of chart worksheet) in een presentatie is de gegevensbron van de grafiek. Chart spreadsheet bevat data die op de grafiek grafisch worden weergegeven. Wanneer je een grafiek maakt in PowerPoint, wordt het bijbehorende werkblad automatisch ook aangemaakt. Chart worksheet wordt aangemaakt voor alle typen grafieken: lijngrafiek, staafgrafiek, sunburst‑grafiek, cirkeldiagram, enz. Om het chart spreadsheet in PowerPoint te zien, dubbelklik je op de grafiek:

![todo:image_alt_text](chart-worksheet-formulas_1.png)



Chart spreadsheet bevat de namen van grafikelementen (Category Name: *Category1*, Serie Name) en een tabel met numerieke gegevens die passen bij deze categorieën en series. Standaard, wanneer je een nieuwe grafiek maakt – worden de chart spreadsheet‑gegevens ingesteld met de standaardgegevens. Daarna kun je de spreadsheet‑gegevens handmatig in het werkblad wijzigen.

Meestal representeert de grafiek gecompliceerde data (bijv. financiële analisten, wetenschappelijke analisten), met cellen die berekend worden op basis van waarden in andere cellen of uit andere dynamische data. Het handmatig berekenen van een celwaarde en hard‑coderen ervan in de cel, maakt het moeilijk om later wijzigingen aan te brengen. Als je de waarde van een bepaalde cel verandert, moeten alle cellen die ervan afhankelijk zijn ook worden bijgewerkt. Bovendien kunnen tabelgegevens afhankelijk zijn van data uit andere tabellen, waardoor een complex presentatiedataschema ontstaat dat makkelijk en flexibel bijgewerkt moet kunnen worden.

**Chart spreadsheet‑formule** in een presentatie is een expressie om chart spreadsheet‑data automatisch te berekenen en bij te werken. Een spreadsheet‑formule definieert de databerekeningslogica voor een bepaalde cel of een set cellen. Een spreadsheet‑formule is een wiskundige of logische formule, die gebruikmaakt van: celreferenties, wiskundige functies, logische operatoren, rekenkundige operatoren, conversiefuncties, tekenreeks‑constanten, enz. De definitie van de formule wordt in een cel geschreven, en deze cel bevat geen eenvoudige waarde. De spreadsheet‑formule berekent de waarde en retourneert deze, waarna de waarde aan de cel wordt toegewezen. Chart spreadsheet‑formules in presentaties zijn eigenlijk dezelfde als Excel‑formules, en dezelfde standaardfuncties, operatoren en constanten worden ondersteund voor hun implementatie.

In [**Aspose.Slides**](https://products.aspose.com/slides/nl/net/) wordt chart spreadsheet weergegeven met 
[**Chart.ChartData.ChartDataWorkbook**](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichartdata/properties/chartdataworkbook) eigenschap van de
[**IChartDataWorkbook**](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichartdataworkbook) type. 
Spreadsheet‑formule kan worden toegewezen en gewijzigd via 
[**IChartDataCell.Formula**](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichartdatacell/properties/formula) eigenschap. 
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



Typisch slaan spreadsheets de laatst berekende formulewaarden op. Als na het laden van de presentatie de grafiekdata niet zijn gewijzigd - **IChartDataCell.Value** eigenschap retourneert die waarden bij het lezen. Maar, als spreadsheet‑data wel is gewijzigd, gooit bij het lezen van **ChartDataCell.Value** eigenschap de **CellUnsupportedDataException** voor de niet‑ondersteunde formules. Dit komt omdat wanneer formules succesvol worden geparseerd, de cel‑afhankelijkheden worden bepaald en de juistheid van de laatste waarden wordt vastgesteld. Als een formule echter niet kan worden geparseerd, kan de juistheid van de celwaarde niet worden gegarandeerd.
## **Voeg een chart spreadsheet‑formule toe aan een presentatie**
Eerst voeg je een grafiek met wat voorbeelddata toe aan de eerste dia van een nieuwe presentatie met 
[IShapeCollection.Shapes.AddChart](https://reference.aspose.com/slides/nl/net/aspose.slides.ishapecollection/addchart/methods/1). 
Het werkblad van de grafiek wordt automatisch aangemaakt en kan worden benaderd via 
[**Chart.ChartData.ChartDataWorkbook**](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichartdata/properties/chartdataworkbook) eigenschap:



``` csharp

using (var presentation = new Presentation())

{

    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 150, 150, 500, 300);

    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

    // ...

}

```



Laten we wat waarden in cellen schrijven met 
[**IChartDataCell.Value**](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichartdatacell/properties/value) eigenschap 
van het type **Object**, wat betekent dat je elke waarde aan de eigenschap kunt toewijzen:



``` csharp

workbook.GetCell(0, "F2").Value = -2.5;

workbook.GetCell(0, "G3").Value = 6.3;

workbook.GetCell(0, "H4").Value = 3;

```



Om nu een formule in de cel te schrijven, kun je de 
[**IChartDataCell.Formula**](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichartdatacell/properties/formula) eigenschap gebruiken:

``` csharp
workbook.GetCell(0, "B2").Formula = "F2+G3+H4+1";
```

*Opmerking*: [**IChartDataCell.Formula**](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichartdatacell/properties/formula) eigenschap wordt gebruikt om A1‑stijl celreferenties in te stellen. 



Om de [R1C1Formula](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichartdatacell/properties/r1c1formula) celreferentie in te stellen, kun je de [**IChartDataCell.R1C1Formula**](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichartdatacell/properties/r1c1formula) eigenschap gebruiken:

``` csharp
workbook.GetCell(0, "C2").R1C1Formula = "R[1]C[4]/R[2]C[5]";
```

Gebruik vervolgens de [**IChartDataWorkbook.CalculateFormulas**](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/chartdataworkbook/methods/calculateformulas) methode om alle formules binnen het werkboek te berekenen en de bijbehorende celwaarden bij te werken:



``` csharp
workbook.CalculateFormulas();

object value1 = workbook.GetCell(0, "B2"); // 7.8

object value2 = workbook.GetCell(0, "C2"); // 2.1

```


## **Logische constanten**
Je kunt logische constanten zoals *FALSE* en *TRUE* gebruiken in cel‑formules:




## **Numerieke constanten**
Getallen kunnen worden gebruikt in gewone of wetenschappelijke notaties om een chart spreadsheet‑formule te maken:




## **Tekenreeks‑constanten**
Een tekenreeks‑ (of letterlijke) constante is een specifieke waarde die wordt gebruikt zoals hij is en niet verandert. Tekenreeks‑constanten kunnen zijn: datums, tekst, nummers, enz.:




## **Fout‑constanten**
Soms is het niet mogelijk om het resultaat te berekenen met de formule. In dat geval wordt de foutcode in de cel getoond in plaats van de waarde. Elke fouttype heeft een specifieke code:

- #DIV/0! - formule probeert te delen door nul.
- #GETTING_DATA - kan worden weergegeven in een cel terwijl de waarde nog wordt berekend.
- #N/A - informatie ontbreekt of is niet beschikbaar. Mogelijke oorzaken: de cellen die in de formule worden gebruikt zijn leeg, een extra spatie‑teken, een typfout, enz.
- #NAME? - een bepaalde cel of ander formule‑object kan niet worden gevonden op basis van de naam. 
- #NULL! - kan verschijnen wanneer er een fout in de formule staat, zoals:  (,) of een spatie‑teken in plaats van een dubbele punt (:).
- #NUM! - het numerieke deel in de formule kan ongeldig, te lang of te klein zijn, enz.
- #REF! - ongeldige celreferentie.
- #VALUE! - onverwacht type waarde. Bijvoorbeeld, een tekenreekswaarde ingesteld op een numerieke cel.




## **Rekenkundige operatoren**
Je kunt alle rekenkundige operatoren gebruiken in chart worksheet‑formules:



|**Operator** |**Betekenis** |**Voorbeeld**|
| :- | :- | :- |
|+ (plus) |Optelling of unair plus|2 + 3|
|- (min) |Aftrekking of negatie |2 - 3<br>-3|
|* (asterisk)|Vermenigvuldiging |2 * 3|
|/ (slash)|Deling |2 / 3|
|% (procent)|Procent|30%|
|^ (caret)|Exponentiatie|2 ^ 3|


*Opmerking*: Om de volgorde van evaluatie te wijzigen, zet je het deel van de formule dat eerst moet worden berekend tussen haakjes.


## **Vergelijkingsoperatoren**
Je kunt de waarden van cellen vergelijken met de vergelijkingsoperatoren. Wanneer twee waarden worden vergeleken met deze operatoren, is het resultaat een logische waarde, *TRUE* of FALSE:



|**Operator** |**Betekenis** |**Voorbeeld**|
| :- | :- | :- |
|= (gelijk) |Gelijk aan |A2 = 3|
|<> (niet gelijk) |Niet gelijk aan|A2 <> 3|
|> (groter) |Groter dan|A2 > 3|
|>= (groter‑of‑gelijk) |Groter dan of gelijk aan|A2 >= 3|
|< (kleiner) |Kleiner dan|A2 < 3|
|<= (kleiner‑of‑gelijk) |Kleiner dan of gelijk aan|A2 <= 3|

## **A1‑stijl celreferenties**
**A1‑stijl celreferenties** worden gebruikt voor werkbladen waarin de kolom een letter‑identificatie heeft (bijv. "*A*") en de rij een numerieke identificatie (bijv. "*1*"). A1‑stijl celreferenties kunnen op de volgende manier worden gebruikt:



|**Celreferentie**|**Voorbeeld**|||
| :- | :- | :- | :- |
||Absoluut |Relatief |Gemengd|
|Cel |$A$2 |A2|<p>A$2</p><p>$A2</p>|
|Rij |$2:$2 |2:2 |-|
|Kolom |$A:$A |A:A |-|
|Bereik |$A$2:$C$4 |A2:C4|<p>$A$2:C4</p><p>A$2:$C4</p>|


Hier is een voorbeeld hoe je een A1‑stijl celreferentie in een formule gebruikt:




## **R1C1‑stijl celreferenties**
**R1C1‑stijl celreferenties** worden gebruikt voor werkbladen waarin zowel een rij als een kolom een numerieke identifier hebben. R1C1‑stijl celreferenties kunnen op de volgende manier worden gebruikt:



|**Celreferentie**|**Voorbeeld**|||
| :- | :- | :- | :- |
||Absoluut |Relatief |Gemengd|
|Cel |R2C3|R[2]C[3]|R2C[3]<br>R[2]C3|
|Rij |R2|R[2]|-|
|Kolom |C3|C[3]|-|
|Bereik |R2C3:R5C7|R[2]C[3]:R[5]C[7] |R2C3:R[5]C[7]<br>R[2]C3:R5C[7]|


Hier is een voorbeeld hoe je een A1‑stijl celreferentie in een formule gebruikt:




## **Vooraf gedefinieerde functies**
Er zijn vooraf gedefinieerde functies die in formules kunnen worden gebruikt om hun implementatie te vereenvoudigen. Deze functies omvatten de meest gebruikte bewerkingen, zoals: 

- ABS
- AVERAGE
- CEILING
- CHOOSE
- CONCAT
- CONCATENATE
- DATE (1900‑datumstelsel)
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

Ja. Aspose.Slides ondersteunt externe werkboeken als een [chart's data source](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/chartdatasourcetype/), waardoor je formules uit een XLSX buiten de presentatie kunt gebruiken.

**Kunnen grafiekformules bladen binnen hetzelfde werkboek refereren op bladnaam?**

Ja. Formules volgen het standaard Excel‑referentiemodel, zodat je andere bladen binnen hetzelfde werkboek of een extern werkboek kunt refereren. Voor externe referenties voeg je het pad en de werkboeknaam toe volgens de Excel‑syntaxis.
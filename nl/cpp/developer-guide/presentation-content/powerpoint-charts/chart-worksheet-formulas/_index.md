---
title: Grafiek‑werkbladformules toepassen in presentaties met С++
linktitle: Werkbladformules
type: docs
weight: 70
url: /nl/cpp/chart-worksheet-formulas/
keywords:
- grafiek‑spreadsheet
- grafiek‑werkblad
- grafiekformule
- werkbladformule
- spreadsheet‑formule
- gegevensbron
- logische constante
- numerieke constante
- tekenreeks‑constante
- foutconstante
- rekenkundige constante
- vergelijkingsoperator
- A1‑stijl
- R1C1‑stijl
- vooraf gedefinieerde functie
- PowerPoint
- presentatie
- С++
- Aspose.Slides
description: "Excel‑achtige formules toepassen in Aspose.Slides voor С++ grafiek‑werkbladen en rapporten automatiseren in PPT‑ en PPTX‑bestanden."
---
## **Overzicht**

Een chart‑werkblad is de gegevensbron achter een grafiek in een presentatie. Het slaat categorie‑ en serienaam op samen met de numerieke waarden die door de grafiek worden weergegeven. In Aspose.Slides is dit werkblad beschikbaar via de chart‑data‑workbook, waarmee je programmatisch met grafiekgegevens kunt werken.

Dit artikel legt uit hoe je werkbladsformules in grafiekgegevens kunt gebruiken zodat celwaarden automatisch kunnen worden berekend en bijgewerkt in plaats van handmatig ingevoerd. Het laat zien hoe je formules toewijst, zowel A1‑ als R1C1‑stijl referenties gebruikt, de werkboek‑formules opnieuw berekent, en werkt met de ondersteunde constanten, operatoren, celreferenties en vooraf gedefinieerde functies die beschikbaar zijn voor grafiek‑werkbladen in presentaties.

## **Over chart‑spreadsheet‑formules in presentaties**
**Chart‑spreadsheet** (of chart‑werkblad) in een presentatie is de gegevensbron van de grafiek. Chart‑spreadsheet bevat gegevens die grafisch op de grafiek worden weergegeven. Wanneer je een grafiek maakt in PowerPoint, wordt het werkblad dat bij deze grafiek hoort automatisch aangemaakt. Een chart‑werkblad wordt aangemaakt voor alle typen grafieken: lijngrafiek, staafgrafiek, sunburst‑grafiek, cirkeldiagram, enz. Om de chart‑spreadsheet in PowerPoint te zien, dubbelklik je op de grafiek:

![todo:image_alt_text](chart-worksheet-formulas_1.png)

Chart‑spreadsheet bevat de namen van grafiekelementen (Category Name: *Category1*, Serie Name) en een tabel met numerieke data die bij deze categorieën en series passen. Standaard, wanneer je een nieuwe grafiek maakt, worden de chart‑spreadsheet‑gegevens ingesteld met de standaardgegevens. Daarna kun je de spreadsheet‑gegevens handmatig in het werkblad wijzigen.

Meestal stelt de grafiek complexe gegevens voor (bijv. financiële analisten, wetenschappelijke analisten), waarbij cellen worden berekend op basis van waarden in andere cellen of uit andere dynamische data. Het handmatig berekenen van een celwaarde en deze hard‑coderen in de cel maakt het moeilijk om later wijzigingen door te voeren. Als je de waarde van een bepaalde cel wijzigt, moeten alle daarvan afhankelijke cellen ook worden bijgewerkt. Bovendien kunnen tabelgegevens afhankelijk zijn van data uit andere tabellen, waardoor een complex presentatiedataschema ontstaat dat op een gemakkelijke en flexibele manier moet worden bijgewerkt.

**Chart‑spreadsheet‑formule** in een presentatie is een expressie om automatisch grafiek‑spreadsheet‑data te berekenen en bij te werken. Een spreadsheet‑formule definieert de databerekeningslogica voor een bepaalde cel of een set cellen. Een spreadsheet‑formule is een wiskundige of logische formule die gebruik maakt van: celreferenties, wiskundige functies, logische operatoren, rekenkundige operatoren, conversiefuncties, tekenreeks‑constant(e)n, enz. De definitie van de formule wordt in een cel geschreven, en deze cel bevat geen eenvoudige waarde. De spreadsheet‑formule berekent de waarde en geeft die terug; vervolgens wordt deze waarde aan de cel toegewezen. Chart‑spreadsheet‑formules in presentaties zijn eigenlijk dezelfde als Excel‑formules, en er worden dezelfde standaardfuncties, operatoren en constanten ondersteund voor hun implementatie.

In [**Aspose.Slides**](https://products.aspose.com/slides/nl/cpp/) wordt de chart‑spreadsheet weergegeven met 
[**ChartData::get_ChartDataWorkbook()**](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.charts.chart_data#a32097093561723a10df0a57dc91acaea)‑methode van het
[**IChartDataWorkbook**](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.charts.i_chart_data_workbook)‑type. 
Spreadsheet‑formules kunnen worden toegewezen en gewijzigd met 
[**IChartDataCell::set_Formula()**](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.charts.i_chart_data_cell#a6806c6a40e025e6834c4c5f3af3cf692)‑methode. 
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



Typisch slaan spreadsheets de laatst berekende formule‑waarden op. Als na het laden van de presentatie de grafiekgegevens niet zijn gewijzigd, retourneert **IChartDataCell.get_Value()** die waarden tijdens het lezen. Maar als de spreadsheet‑data is gewijzigd, gooit **ChartDataCell.get_Value()** een **CellUnsupportedDataException** voor de niet‑ondersteunde formules. Dit komt doordat wanneer formules succesvol worden geparseerd, de cel‑afhankelijkheden worden bepaald en de correctheid van de laatste waarden wordt vastgesteld. Als een formule niet kan worden geparseerd, kan de correctheid van de celwaarde niet gegarandeerd worden.


## **Een chart‑spreadsheet‑formule toevoegen aan een presentatie**
Voeg eerst een grafiek toe aan de eerste dia van een nieuwe presentatie met 
[IShapeCollection::AddChart()](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.i_shape_collection#a2cd4d47fc5c536012ee15b3a69486374). 
Het werkblad van de grafiek wordt automatisch aangemaakt en kan benaderd worden met 
[**ChartData::get_ChartDataWorkbook()**](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.charts.chart_data#a32097093561723a10df0a57dc91acaea)‑methode:



``` cpp
auto presentation = System::MakeObject<Presentation>();
    
auto chart = presentation->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::ClusteredColumn, 150.0f, 150.0f, 500.0f, 300.0f);
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();

// ...
```



Laten we enkele waarden in cellen schrijven met 
[**IChartDataCell.set_Value()**](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.charts.i_chart_data_cell#ad85809f520195e09225abae9002635ec)‑methode 
van het **Object**‑type, wat betekent dat je elke waarde aan de methode kunt doorgeven:



``` cpp
workbook->GetCell(0, u"F2")->set_Value(System::ObjectExt::Box<double>(-2.5));
workbook->GetCell(0, u"G3")->set_Value(System::ObjectExt::Box<double>(6.3));
workbook->GetCell(0, u"H4")->set_Value(System::ObjectExt::Box<int32_t>(3));
```



Om nu een formule in de cel te schrijven, kun je de 
[**IChartDataCell::set_Formula()**](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.charts.i_chart_data_cell#a6806c6a40e025e6834c4c5f3af3cf692)‑methode gebruiken:





*Opmerking*: [**IChartDataCell::set_Formula()**](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.charts.i_chart_data_cell#a6806c6a40e025e6834c4c5f3af3cf692)‑methode wordt gebruikt om A1‑stijl celreferenties in te stellen. 



Om de R1C1Formula‑celreferentie in te stellen, kun je de [**IChartDataCell::set_R1C1Formula()**](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.charts.i_chart_data_cell#a47f5825dd38d0dddb11ecc3a43d388c7)‑methode gebruiken:





Als je vervolgens de waarden van de cellen B2 en C2 uitleest, worden ze berekend:



``` cpp
auto value1 = cell1->get_Value(); // 7.8
auto value2 = cell2->get_Value(); // 2.1
```


## **Logische constanten**
Je kunt logische constanten zoals *FALSE* en *TRUE* gebruiken in cel‑formules:




## **Numerieke constanten**
Nummers kunnen in gewone of wetenschappelijke notatie worden gebruikt om een chart‑spreadsheet‑formule te maken:




## **Tekenreeks‑constanten**
Een tekenreeks‑ (of literal‑) constante is een specifieke waarde die precies zo wordt gebruikt en niet verandert. Tekenreeks‑constanten kunnen zijn: datums, teksten, getallen, enz.:




## **Fout‑constanten**
Soms is het niet mogelijk het resultaat van een formule te berekenen. In dat geval wordt de foutcode in de cel weergegeven in plaats van de waarde. Elke fout heeft een specifieke code:

- #DIV/0! - formule probeert te delen door nul.
- #GETTING_DATA - kan op een cel verschijnen terwijl de waarde nog wordt berekend.
- #N/A - informatie ontbreekt of is niet beschikbaar. Mogelijke oorzaken: gebruikte cellen in de formule zijn leeg, een extra spatie, typefout, enz.
- #NAME? - een bepaalde cel of andere formule‑objecten kunnen niet worden gevonden op naam. 
- #NULL! - kan verschijnen bij een fout in de formule, zoals:  (,) of een spatie in plaats van een dubbelepunt (:).
- #NUM! - het numerieke onderdeel in de formule is ongeldig, te lang of te klein, enz.
- #REF! - ongeldige celreferentie.
- #VALUE! - onverwacht type waarde. Bijvoorbeeld een tekenreekswaarde ingesteld op een numerieke cel.




## **Rekenkundige operatoren**
Je kunt alle rekenkundige operatoren gebruiken in formules van het chart‑werkblad:



|**Operator**|**Betekenis**|**Voorbeeld**|
| :- | :- | :- |
|+ (plus)|Optelling of unair plus|2 + 3|
|- (min)|Aftrekking of negatie|2 - 3<br>-3|
|* (asterisk)|Vermenigvuldiging|2 * 3|
|/ (slash)|Deling|2 / 3|
|% (percent)|Procent|30%|
|^ (caret)|Exponentiatie|2 ^ 3|


*Opmerking*: Om de volgorde van evaluatie te wijzigen, zet je het deel van de formule dat eerst moet worden berekend tussen haakjes.


## **Vergelijkingsoperatoren**
Je kunt de waarden van cellen vergelijken met de vergelijkingsoperatoren. Wanneer twee waarden met deze operatoren worden vergeleken, is het resultaat een logische waarde *TRUE* of *FALSE*:



|**Operator**|**Betekenis**|**Voorbeeld**|
| :- | :- | :- |
|= (gelijk)|Gelijk aan|A2 = 3|
|<> (niet‑gelijk)|Niet gelijk aan|A2 <> 3|
|> (groter dan)|Groter dan|A2 > 3|
|>= (groter‑of‑gelijk)|Groter dan of gelijk aan|A2 >= 3|
|< (kleiner dan)|Kleiner dan|A2 < 3|
|<= (kleiner‑of‑gelijk)|Kleiner dan of gelijk aan|A2 <= 3|


## **A1‑stijl celreferenties**
**A1‑stijl celreferenties** worden gebruikt voor werkbladen waarbij de kolom een letter‑identificatie heeft (bijv. "*A*") en de rij een numerieke identificatie (bijv. "*1*"). A1‑stijl celreferenties kunnen op de volgende manier worden gebruikt:



|**Celverwijzing**|**Absoluut**|**Relatief**|**Gemengd**|
| :- | :- | :- | :- |
|Cel|$A$2|A2|<p>A$2</p><p>$A2</p>|
|Rij|$2:$2|2:2|-|
|Kolom|$A:$A|A:A|-|
|Bereik|$A$2:$C$4|A2:C4|<p>$A$2:C4</p><p>A$2:$C4</p>|


Hier is een voorbeeld van hoe een A1‑stijl celreferentie in een formule te gebruiken:




## **R1C1‑stijl celreferenties**
**R1C1‑stijl celreferenties** worden gebruikt voor werkbladen waarbij zowel een rij als een kolom een numerieke identificatie heeft. R1C1‑stijl celreferenties kunnen op de volgende manier worden gebruikt:



|**Celverwijzing**|**Absoluut**|**Relatief**|**Gemengd**|
| :- | :- | :- | :- |
|Cel|R2C3|R[2]C[3]|R2C[3]<br>R[2]C3|
|Rij|R2|R[2]|-|
|Kolom|C3|C[3]|-|
|Bereik|R2C3:R5C7|R[2]C[3]:R[5]C[7]|R2C3:R[5]C[7]<br>R[2]C3:R5C[7]|


Hier is een voorbeeld van hoe een R1C1‑stijl celreferentie in een formule te gebruiken:




## **Vooraf gedefinieerde functies**
Er zijn vooraf gedefinieerde functies die in formules kunnen worden gebruikt om hun implementatie te vereenvoudigen. Deze functies omvatten de meest gebruikte bewerkingen, zoals: 

- ABS
- AVERAGE
- CEILING
- CHOOSE
- CONCAT
- CONCATENATE
- DATE (1900‑datumensysteem)
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

## **Veelgestelde vragen**

**Worden externe Excel‑bestanden ondersteund als gegevensbron voor een grafiek met formules?**

Ja. Aspose.Slides ondersteunt externe werkboeken als een [chart’s data source](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/chartdatasourcetype/), waardoor je formules uit een XLSX buiten de presentatie kunt gebruiken.

**Kunnen grafiekformules verwijzen naar bladen binnen hetzelfde werkboek op blad‑naam?**

Ja. Formules volgen het standaard Excel‑referentiemodel, zodat je andere bladen binnen hetzelfde werkboek of een extern werkboek kunt refereren. Voor externe referenties voeg je het pad en de werkboeknaam toe volgens de Excel‑syntaxis.
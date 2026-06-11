---
title: "Applicera diagramarkbladsformler i presentationer med PHP"
linktitle: "Arkbladsformler"
type: docs
weight: 70
url: /sv/php-java/chart-worksheet-formulas/
keywords:
  - diagramkalkylblad
  - diagramarkblad
  - diagramformel
  - arkbladsformel
  - kalkylbladsformel
  - datakälla
  - logisk konstant
  - numerisk konstant
  - strängkonstant
  - felkonstant
  - aritmetisk konstant
  - jämförelseoperator
  - A1 stil
  - R1C1 stil
  - fördefinierad funktion
  - PowerPoint
  - presentation
  - PHP
  - Aspose.Slides
description: "Använd Excel‑liknande formler i Aspose.Slides för PHP via Java‑diagramarkblad och automatisera rapporter i PPT‑ och PPTX‑filer."
---
## **Översikt**

Ett diagramarkblad är datakällan bakom ett diagram i en presentation. Det lagrar kategori- och serienamn tillsammans med de numeriska värden som visas i diagrammet. I Aspose.Slides är detta arkblad tillgängligt via diagramdataboken, som gör att du kan arbeta med diagramdata programmässigt.

Denna artikel förklarar hur du använder arkbladsformler i diagramdata så att cellvärden kan beräknas och uppdateras automatiskt i stället för att matas in manuellt. Den visar hur du tilldelar formler, använder både A1‑stil och R1C1‑stil referenser, beräknar om arbetsboksformler och arbetar med de stödjade konstanterna, operatorerna, cellreferenserna och fördefinierade funktionerna som finns för diagramarkblad i presentationer.

## **Om diagram‑kalkylbladsformler i presentationer**
**Diagram‑kalkylblad** (eller diagramarkblad) i en presentation är diagrammets datakälla. Diagram‑kalkylbladet innehåller data som visas i diagrammet på ett grafiskt sätt. När du skapar ett diagram i PowerPoint skapas också det tillhörande arkbladet automatiskt. Diagramarkbladet skapas för alla diagramtyper: linjediagram, stapeldiagram, solstråle‑diagram, cirkeldiagram osv. För att se diagram‑kalkylbladet i PowerPoint ska du dubbelklicka på diagrammet:

![todo:image_alt_text](chart-worksheet-formulas_1.png)


Diagram‑kalkylbladet innehåller namn på diagramdelar (Kategorinamn: *Category1*, Serienamn) och en tabell med numeriska data som motsvarar dessa kategorier och serier. Som standard, när du skapar ett nytt diagram – sätts diagram‑kalkylbladsdata till standarddata. Därefter kan du ändra kalkylbladsdata i arkbladet manuellt.

Vanligtvis representerar diagrammet komplicerade data (t.ex. finansiella analytiker, vetenskapliga analytiker) där celler beräknas utifrån värden i andra celler eller från annan dynamisk data. Att beräkna en cells värde manuellt och hårdkoda det i cellen gör det svårt att ändra i framtiden. Om du ändrar värdet i en viss cell måste alla beroende celler också uppdateras. Dessutom kan tabelldata bero på data från andra tabeller, vilket skapar ett komplext presentationsdatatema som måste kunna uppdateras på ett enkelt och flexibelt sätt.

**Diagram‑kalkylbladsformel** i en presentation är ett uttryck för att automatiskt beräkna och uppdatera diagram‑kalkylbladsdata. En kalkylbladsformel definierar beräkningslogiken för en viss cell eller en uppsättning celler. En kalkylbladsformel är en matematisk eller logisk formel som använder: cellreferenser, matematiska funktioner, logiska operatorer, aritmetiska operatorer, konverteringsfunktioner, strängkonstanter osv. Formelfunktionen skrivs in i en cell, och den här cellen innehåller inte ett enkelt värde. Kalkylbladsformeln beräknar värdet och returnerar det, sedan tilldelas detta värde cellen. Diagram‑kalkylbladsformler i presentationer är i själva verket samma som Excel‑formler, och de stödjer samma standardfunktioner, operatorer och konstanter för sin implementering.

I [**Aspose.Slides**](https://products.aspose.com/slides/sv/php-java/) representeras diagram‑kalkylbladet med
[**ChartData::getChartDataWorkbook**](https://reference.aspose.com/slides/sv/php-java/aspose.slides/chartdata/#getChartDataWorkbook)‑metoden av
[**ChartDataWorkbook**](https://reference.aspose.com/slides/sv/php-java/aspose.slides/chartdataworkbook/)-typen.
Kalkylbladsformel kan tilldelas och ändras med
[**ChartDataCell::setFormula**](https://reference.aspose.com/slides/sv/php-java/aspose.slides/chartdatacell/#setFormula)‑metoden.
Följande funktionalitet stödjs för formler i Aspose.Slides:

- Logiska konstanter
- Numeriska konstanter
- Strängkonstanter
- Felkonstanter
- Aritmetiska operatorer
- Jämförelseoperatorer
- A1‑stil cellreferenser
- R1C1‑stil cellreferenser
- Fördefinierade funktioner


Typiskt lagrar kalkylblad de senast beräknade formelvärdena. Om diagramdata inte ändras efter att presentationen har lästs in – returnerar [**ChartDataCell::getValue**](https://reference.aspose.com/slides/sv/php-java/aspose.slides/chartdatacell/#getValue)‑metoden dessa värden vid läsning. Men om kalkylbladsdata har ändrats, kastas [**CellUnsupportedDataException**](https://reference.aspose.com/slides/sv/php-java/aspose.slides/CellUnsupportedDataException) för de stödjande formlerna när värdet läses. Detta beror på att när formler har parsats framgångsrikt bestäms cellberoenden och korrektheten av de sista värdena. Om formeln däremot inte kan parsas kan korrektheten av cellvärdet inte garanteras.

## **Lägg till en diagram‑kalkylbladsformel i en presentation**
Först, lägg till ett diagram på den första bilden i en ny presentation med
[ShapeCollection::addChart](https://reference.aspose.com/slides/sv/php-java/aspose.slides/shapecollection/#addChart).
Diagramets arkblad skapas automatiskt och kan nås med
[**ChartData::getChartDataWorkbook**](https://reference.aspose.com/slides/sv/php-java/aspose.slides/chartdata/#getChartDataWorkbook)‑metoden:



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

Låt oss skriva några värden i celler med [**ChartDataCell::setValue**](https://reference.aspose.com/slides/sv/php-java/aspose.slides/chartdatacell/#setValue)‑metoden av **Object**‑typen, vilket betyder att du kan sätta vilket värde som helst:

```php
  $workbook->getCell(0, "F2")->setValue(-2.5);
  $workbook->getCell(0, "G3")->setValue(6.3);
  $workbook->getCell(0, "H4")->setValue(3);

```

Nu, för att skriva en formel till en cell, kan du använda
[**ChartDataCell::setFormula**](https://reference.aspose.com/slides/sv/php-java/aspose.slides/chartdatacell/#setFormula)‑metoden.

*Obs*: [**ChartDataCell::setFormula**](https://reference.aspose.com/slides/sv/php-java/aspose.slides/chartdatacell/#setFormula)‑metoden används för att sätta A1‑stil cellreferenser. 

För att sätta en formel i R1C1‑stil kan du använda
[**ChartDataCell::setR1C1Formula**](https://reference.aspose.com/slides/sv/php-java/aspose.slides/chartdatacell/#setR1C1Formula)‑metoden.

Sedan, om du försöker läsa värdena från cellerna B2 och C2, kommer de att beräknas:

```php
  $value1 = $cell1->getValue();// 7.8

  $value2 = $cell2->getValue();// 2.1


```

## **Logiska konstanter**
Du kan använda logiska konstanter såsom *FALSE* och *TRUE* i cellformler:

```php
  $workbook->getCell(0, "A2")->setValue(false);
  $cell = $workbook->getCell(0, "B2");
  $cell->setFormula("A2 = TRUE");
  $value = $cell->getValue();// värdet innehåller boolesk "false"


```

## **Numeriska konstanter**
Tal kan användas i vanlig eller vetenskaplig notation för att skapa diagram‑kalkylbladsformler:

```php
  $workbook->getCell(0, "A2")->setFormula("1 + 0.5");
  $workbook->getCell(0, "B2")->setFormula(".3 * 1E-2");

```

## **Strängkonstanter**
Sträng‑ (eller litteral‑)konstant är ett specifikt värde som används som det är och ändras inte. Strängkonstanter kan vara: datum, texter, tal osv.:

```php
  $workbook->getCell(0, "A2")->setFormula("\"abc\"");
  $workbook->getCell(0, "B2")->setFormula("\"2/3/2020 12:00\"");

```

## **Felkonstanter**
Ibland är det inte möjligt att beräkna resultatet med formeln. I sådant fall visas felkoden i cellen i stället för dess värde. Varje feltyp har en specifik kod:

- #DIV/0! – formeln försöker dividera med noll.
- #GETTING_DATA – kan visas i en cell medan dess värde fortfarande beräknas.
- #N/A – information saknas eller är inte tillgänglig. Orsaker kan vara: de celler som används i formeln är tomma, ett extra mellanslag, felstavning osv.
- #NAME? – en viss cell eller annat formelobjekt kan inte hittas med sitt namn. 
- #NULL! – kan uppstå när det finns ett misstag i formeln, som  (,) eller ett mellanslag istället för ett kolon (:).
- #NUM! – talet i formeln kan vara ogiltigt, för långt eller för kort osv.
- #REF! – ogiltig cellreferens.
- #VALUE! – oväntad värdetyp. Till exempel, ett strängvärde placerat i en numerisk cell.

```php
  $cell = $workbook->getCell(0, "A2");
  $cell->setFormula("2 / 0");
  $value = $cell->getValue();// värdet innehåller strängen "#DIV/0!"


```

## **Aritmetiska operatorer**
Du kan använda alla aritmetiska operatorer i diagram‑arkbladsformler:

|**Operator**|**Betydelse**|**Exempel**|
| :- | :- | :- |
|+ (plus‑tecken)|Addition eller unärt plus|2 + 3|
|- (minus‑tecken)|Subtraktion eller negation|2 - 3<br>-3|
|* (asterisk)|Multiplikation|2 * 3|
|/ (snedstreck)|Division|2 / 3|
|% (procenttecken)|Procent|30%|
|^ (caret)|Exponentiering|2 ^ 3|

*Obs*: För att ändra utvärderingsordning, omge den del av formeln som ska beräknas först med parenteser.

## **Jämförelseoperatorer**
Du kan jämföra cellvärden med jämförelseoperatorer. När två värden jämförs med dessa operatorer blir resultatet ett logiskt värde, antingen *TRUE* eller *FALSE*:

|**Operator**|**Betydelse**|**Betydelse**|
| :- | :- | :- |
|= (lika med)|Lika med|A2 = 3|
|<> (inte lika med)|Inte lika med|A2 <> 3|
|> (större än)|Större än|A2 > 3|
|>= (större än eller lika med)|Större än eller lika med|A2 >= 3|
|< (mindre än)|Mindre än|A2 < 3|
|<= (mindre än eller lika med)|Mindre än eller lika med|A2 <= 3|

## **A1‑stil cellreferenser**
**A1‑stil cellreferenser** används för arkblad där kolumnen har en bokstavsidentifierare (t.ex. "*A*") och raden har en numerisk identifierare (t.ex. "*1*"). A1‑stil cellreferenser kan användas på följande sätt:

|**Cellreferens**|**Exempel**|**Absolut**|**Relativ**|**Blandad**|
| :- | :- | :- | :- | :- |
|Cell|$A$2|A2|<p>A$2</p><p>$A2</p>|
|Rad|$2:$2|2:2|-|
|Kolumn|$A:$A|A:A|-|
|Omfång|$A$2:$C$4|A2:C4|<p>$A$2:C4</p><p>A$2:$C4</p>|


Här är ett exempel på hur man använder A1‑stil cellreferens i en formel:

```php
  $workbook->getCell(0, "A2")->setFormula("C3 + SUM(F2:H5)");

```

## **R1C1‑stil cellreferenser**
**R1C1‑stil cellreferenser** används för arkblad där både rad och kolumn har numeriska identifierare. R1C1‑stil cellreferenser kan användas på följande sätt:

|**Cellreferens**|**Exempel**|**Absolut**|**Relativ**|**Blandad**|
| :- | :- | :- | :- | :- |
|Cell|R2C3|R[2]C[3]|R2C[3]<br>R[2]C3|
|Rad|R2|R[2]|-|
|Kolumn|C3|C[3]|-|
|Omfång|R2C3:R5C7|R[2]C[3]:R[5]C[7]|R2C3:R[5]C[7]<br>R[2]C3:R5C[7]|


Här är ett exempel på hur man använder R1C1‑stil cellreferens i en formel:

```php
  $workbook->getCell(0, "A2")->setR1C1Formula("R2C4 + SUM(R5C6:R7C9)");

```

## **Fördefinierade funktioner**
Det finns fördefinierade funktioner som kan användas i formler för att förenkla deras implementering. Dessa funktioner kapslar de mest vanligt använda operationerna, såsom:

- ABS
- AVERAGE
- CEILING
- CHOOSE
- CONCAT
- CONCATENATE
- DATE (1900‑datumsystem)
- DAYS
- FIND
- FINDB
- IF
- INDEX (referensform)
- LOOKUP (vektorsform)
- MATCH (vektorsform)
- MAX
- SUM
- VLOOKUP

## **Vanliga frågor**

**Stöds externa Excel‑filer som datakälla för ett diagram med formler?**

Ja. Aspose.Slides stöder externa arbetsböcker som en [diagramdatas källa](https://reference.aspose.com/slides/sv/php-java/aspose.slides/chartdatasourcetype/), vilket låter dig använda formler från en XLSX‑fil utanför presentationen.

**Kan diagram‑formler referera till blad i samma arbetsbok via bladnamn?**

Ja. Formler följer den standardiserade Excel‑referensmodellen, så du kan referera till andra blad i samma arbetsbok eller en extern arbetsbok. För externa referenser, inkludera sökväg och arbetsbokens namn med Excel‑syntax.
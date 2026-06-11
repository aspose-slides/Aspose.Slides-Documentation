---
title: Använd diagramarbetsbladsformler i presentationer med JavaScript
linktitle: Arbetsbladsformler
type: docs
weight: 70
url: /sv/nodejs-java/chart-worksheet-formulas/
keywords:
- diagramkalkylblad
- diagramark
- diagramformel
- arbetsbladsformel
- kalkylbladsformel
- datakälla
- logisk konstant
- numerisk konstant
- strängkonstant
- felkonstant
- aritmetisk konstant
- jämförelsoperator
- A1-stil
- R1C1-stil
- fördefinierad funktion
- PowerPoint
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Använd Excel‑liknande formler i Aspose.Slides för Node.js via Java‑diagramark och automatisera rapporter i PPT‑ och PPTX‑filer med JavaScript."
---
## **Översikt**

Ett diagramark är datakällan bakom ett diagram i en presentation. Det lagrar kategori‑ och serienamn tillsammans med de numeriska värden som visas i diagrammet. I Aspose.Slides är detta ark tillgängligt via diagramdataboken, vilket gör att du kan arbeta med diagramdata programmässigt.

Denna artikel förklarar hur du använder arkelformler i diagramdata så att cellvärden kan beräknas och uppdateras automatiskt i stället för att matas in manuellt. Den visar hur du tilldelar formler, använder både A1‑stil‑ och R1C1‑stil‑referenser, omräknar arbetsbokens formler och arbetar med de stödjade konstanterna, operatorerna, cellreferenserna och fördefinierade funktionerna som finns för diagramark i presentationer.

## **Om diagramkalkylbladsformel i presentation**
**Diagramkalkylblad** (eller diagramark) i en presentation är diagrammets datakälla. Diagramkalkylbladet innehåller data som visas i diagrammet i grafisk form. När du skapar ett diagram i PowerPoint skapas det tillhörande arket automatiskt. Diagramark skapas för alla diagramtyper: linjediagram, stapeldiagram, solstråle‑diagram, cirkeldiagram osv. För att se diagramkalkylbladet i PowerPoint ska du dubbelklicka på diagrammet:

![todo:image_alt_text](chart-worksheet-formulas_1.png)


Diagramkalkylbladet innehåller namnen på diagrammets element (Kategorinamn: *Category1*, Serienamn) och en tabell med numeriska data som hör till dessa kategorier och serier. Som standard, när du skapar ett nytt diagram ‑ diagramkalkylbladsdata fylls i med standarddata. Därefter kan du ändra kalkylbladsdata i arket manuellt.

Vanligtvis representerar diagrammet komplicerade data (t.ex. finansiella analyser, vetenskapliga analyser) med celler som beräknas från värden i andra celler eller från annan dynamisk data. Att beräkna ett cellvärde manuellt och hårdkoda det i cellen gör det svårt att ändra i framtiden. Om du ändrar värdet i en viss cell måste alla beroende celler också uppdateras. Dessutom kan tabelldata bero på data från andra tabeller, vilket skapar ett komplext presentationsdataschema som behöver uppdateras på ett enkelt och flexibelt sätt.

**Diagramkalkylbladsformel** i en presentation är ett uttryck för att automatiskt beräkna och uppdatera diagramkalkylbladsdata. Kalkylbladsformeln definierar beräkningslogiken för en viss cell eller ett cellområde. En kalkylbladsformel är en matematisk eller logisk formel som använder: cellreferenser, matematiska funktioner, logiska operatorer, aritmetiska operatorer, konverteringsfunktioner, strängkonstanter osv. Formeln skrivs in i en cell som då inte innehåller ett enkelt värde. Kalkylbladsformeln beräknar värdet och returnerar det, varefter värdet tilldelas cellen. Diagramkalkylbladsformler i presentationer är i praktiken desamma som Excel‑formler, och samma standardfunktioner, operatorer och konstanter stöds.

I [**Aspose.Slides**](https://products.aspose.com/slides/sv/nodejs-java/) representeras diagramkalkylbladet med
[**Chart.getChartData.getChartDataWorkbook**](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ChartData#getChartDataWorkbook--)‑metoden på typen
[**ChartDataWorkbook**](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ChartDataWorkbook).
Kalkylbladsformel kan tilldelas och ändras med
[**ChartDataCell.setFormula**](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ChartDataCell#setFormula-java.lang.String-)‑metoden.
Följande funktionalitet stöds för formler i Aspose.Slides:

- Logiska konstanter
- Numeriska konstanter
- Strängkonstanter
- Felkonstanter
- Aritmetiska operatorer
- Jämförelsoperatorer
- A1‑stil‑cellreferenser
- R1C1‑stil‑cellreferenser
- Fördefinierade funktioner


Vanligtvis lagrar kalkylblad de senast beräknade formelvärdena. Om diagramdata inte ändrades efter att presentationen laddats ‑ [**ChartDataCell.getValue**](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ChartDataCell#getValue--)‑metoden returnerar dessa värden vid läsning. Men om kalkylbladsdata har ändrats, så kastar **ChartDataCell.Value**‑egenskapen [**CellUnsupportedDataException**](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/CellUnsupportedDataException) för de formler som inte stöds. Detta beror på att när formler har parsats korrekt bestäms cellberoenden och korrektheten för de senaste värdena. Om formeln inte kan parsas kan korrektheten för cellvärdet inte garanteras.

## **Lägg till diagramkalkylbladsformel i presentation**
Först lägger du till ett diagram på den första sliden i en ny presentation med
[ShapeCollection.getShapes.addChart](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ShapeCollection#addChart-int-float-float-float-float-).
Diagrammets ark skapas automatiskt och kan nås med
[**Chart.getChartData.getChartDataWorkbook**](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ChartData#getChartDataWorkbook--)‑metoden:



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

Skriv några värden i celler med
[**ChartDataCell.setValue**](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ChartDataCell#setValue-java.lang.Object-)‑egenskapen
av typen **Object**, vilket innebär att du kan tilldela vilket värde som helst till egenskapen:

```javascript
workbook.getCell(0, "F2").setValue(-2.5);
workbook.getCell(0, "G3").setValue(6.3);
workbook.getCell(0, "H4").setValue(3);
```

För att skriva en formel i en cell kan du använda
[**ChartDataCell.setFormula**](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ChartDataCell#setFormula-java.lang.String-)‑metoden:

*Obs*: [**ChartDataCell.setFormula**](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ChartDataCell#setFormula-java.lang.String-)‑metoden används för att ange A1‑stil‑cellreferenser.

För att ange en [R1C1Formula](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ChartDataCell#getR1C1Formula--)‑cellreferens kan du använda
[**ChartDataCell.setR1C1Formula**](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ChartDataCell#setR1C1Formula-java.lang.String-)‑metoden:

När du sedan läser värdena från cellerna B2 och C2 kommer de att beräknas:

```javascript
var value1 = cell1.getValue();// 7.8
var value2 = cell2.getValue();// 2.1
```

## **Logiska konstanter**
Du kan använda logiska konstanter såsom *FALSE* och *TRUE* i cellformler:

```javascript
workbook.getCell(0, "A2").setValue(false);
var cell = workbook.getCell(0, "B2");
cell.setFormula("A2 = TRUE");
var value = cell.getValue();// värdet innehåller booleskt "false"
```

## **Numeriska konstanter**
Tal kan användas i vanlig eller vetenskaplig notation för att skapa diagramkalkylbladsformler:

```javascript
workbook.getCell(0, "A2").setFormula("1 + 0.5");
workbook.getCell(0, "B2").setFormula(".3 * 1E-2");
```

## **Strängkonstanter**
En sträng‑ (eller literal)‑konstant är ett specifikt värde som används exakt som det är och som inte förändras. Strängkonstanter kan vara: datum, texter, tal osv.:

```javascript
workbook.getCell(0, "A2").setFormula("\"abc\"");
workbook.getCell(0, "B2").setFormula("\"2/3/2020 12:00\"");
```

## **Felkonstanter**
Ibland går det inte att beräkna ett resultat med formeln. I så fall visas en felkod i cellen i stället för värdet. Varje feltyp har en specifik kod:

- #DIV/0! ‑ formeln försöker dividera med noll.
- #GETTING_DATA ‑ kan visas i en cell medan dess värde fortfarande beräknas.
- #N/A ‑ information saknas eller är inte tillgänglig. Orsaker kan vara: cellerna i formeln är tomma, ett extra mellanslag, felstavning osv.
- #NAME? ‑ en viss cell eller annat formelobjekt kan inte hittas med sitt namn.
- #NULL! ‑ kan uppstå när formeln innehåller ett fel, t.ex. (,) eller ett mellanslag där ett kolon (:) bör stå.
- #NUM! ‑ det numeriska värdet i formeln är ogiltigt, för långt eller för kort osv.
- #REF! ‑ ogiltig cellreferens.
- #VALUE! ‑ oväntad värdetyp. Till exempel en sträng i en numerisk cell.

```javascript
var cell = workbook.getCell(0, "A2");
cell.setFormula("2 / 0");
var value = cell.getValue();// värdet innehåller strängen "#DIV/0!"
```

## **Aritmetiska operatorer**
Du kan använda alla aritmetiska operatorer i diagramarksformler:

|**Operator**|**Betydelse**|**Exempel**|
| :- | :- | :- |
|+ (plus‑tecken)|Addition eller unary plus|2 + 3|
|- (minus‑tecken)|Subtraktion eller negation|2 - 3<br>-3|
|* (asterisk)|Multiplikation|2 * 3|
|/ (snedstreck)|Division|2 / 3|
|% (procenttecken)|Procent|30%|
|^ (cirkumflex)|Exponentiering|2 ^ 3|

*Obs*: För att ändra utvärderingsordning, omge den del av formeln som ska beräknas först med parenteser.

## **Jämförelsoperatorer**
Du kan jämföra cellvärden med jämförelsoperatorerna. När två värden jämförs med dessa operatorer blir resultatet ett logiskt värde, antingen *TRUE* eller *FALSE*:

|**Operator**|**Betydelse**|**Resultat**|
| :- | :- | :- |
|= (lika‑tecken)|Lika med|A2 = 3|
|<> (inte lika‑tecken)|Inte lika med|A2 <> 3|
|> (större‑än‑tecken)|Större än|A2 > 3|
|>= (större‑eller‑lika‑tecken)|Större än eller lika med|A2 >= 3|
|< (mindre‑än‑tecken)|Mindre än|A2 < 3|
|<= (mindre‑eller‑lika‑tecken)|Mindre än eller lika med|A2 <= 3|

## **A1‑stil‑cellreferenser**
**A1‑stil‑cellreferenser** används för kalkylblad där kolumnen har en bokstavsidentifierare (t.ex. "*A*") och raden har en numerisk identifierare (t.ex. "*1*"). A1‑stil‑cellreferenser kan användas på följande sätt:

|**Cellreferens**|**Exempel**| | |
| :- | :- | :- | :- |
| | Absolut | Relativ | Blandad |
|Cell|$A$2|A2|<p>A$2</p><p>$A2</p>|
|Rad|$2:$2|2:2|-|
|Kolumn|$A:$A|A:A|-|
|Område|$A$2:$C$4|A2:C4|<p>$A$2:C4</p><p>A$2:$C4</p>|


Här är ett exempel på hur man använder en A1‑stil‑cellreferens i en formel:

```javascript
workbook.getCell(0, "A2").setFormula("C3 + SUM(F2:H5)");
```

## **R1C1‑stil‑cellreferenser**
**R1C1‑stil‑cellreferenser** används för kalkylblad där både rad och kolumn har numeriska identifierare. R1C1‑stil‑cellreferenser kan användas på följande sätt:

|**Cellreferens**|**Exempel**| | |
| :- | :- | :- | :- |
| | Absolut | Relativ | Blandad |
|Cell|R2C3|R[2]C[3]|R2C[3]<br>R[2]C3|
|Rad|R2|R[2]|-|
|Kolumn|C3|C[3]|-|
|Område|R2C3:R5C7|R[2]C[3]:R[5]C[7]|R2C3:R[5]C[7]<br>R[2]C3:R5C[7]|


Här är ett exempel på hur man använder en R1C1‑stil‑cellreferens i en formel:

```javascript
workbook.getCell(0, "A2").setR1C1Formula("R2C4 + SUM(R5C6:R7C9)");
```

## **Fördefinierade funktioner**
Det finns fördefinierade funktioner som kan användas i formler för att förenkla deras implementering. Dessa funktioner kapslar in de mest använda operationerna, såsom:

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

## **FAQ**

**Stöds externa Excel‑filer som datakälla för ett diagram med formler?**

Ja. Aspose.Slides stöder externa arbetsböcker som ett [diagram‑datakällas](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chartdatasourcetype/), vilket gör att du kan använda formler från en XLSX‑fil utanför presentationen.

**Kan diagramformler referera till blad i samma arbetsbok med bladnamn?**

Ja. Formler följer den vanliga Excel‑referensmodellen, så du kan referera till andra blad i samma arbetsbok eller en extern arbetsbok. För externa referenser inkluderar du sökväg och arbetsboksnamn med Excel‑syntaxen.
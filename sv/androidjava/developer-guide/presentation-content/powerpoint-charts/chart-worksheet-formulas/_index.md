---
title: Tillämpa diagramarkbladsformler i presentationer på Android
linktitle: Arkbladsformler
type: docs
weight: 70
url: /sv/androidjava/chart-worksheet-formulas/
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
- A1-stil
- R1C1-stil
- fördefinierad funktion
- PowerPoint
- presentation
- Android
- Java
- Aspose.Slides
description: "Tillämpa Excel-liknande formler i Aspose.Slides för Android via Java-diagramarkblad och automatisera rapporter i PPT- och PPTX-filer."
---
## **Översikt**

Ett diagramarkblad är datakällan bakom ett diagram i en presentation. Det lagrar kategori‑ och serienamn tillsammans med de numeriska värden som diagrammet visar. I Aspose.Slides är detta arkblad tillgängligt via diagramdataboken, vilket låter dig arbeta med diagramdata programatiskt.

Den här artikeln förklarar hur du använder arkbladsformler i diagramdata så att cellvärden kan beräknas och uppdateras automatiskt istället för att matas in manuellt. Den visar hur du tilldelar formler, använder både A1‑stil och R1C1‑stil referenser, omberäknar arbetsbokens formler och arbetar med de stödjade konstanterna, operatorerna, cellreferenserna och fördefinierade funktionerna som finns för diagramarkblad i presentationer.

## **Om diagramkalkylbladsformler i presentationer**
**Diagramkalkylblad** (eller diagramarkblad) i en presentation är diagrammets datakälla. Diagramkalkylbladet innehåller data som visas i diagrammet på ett grafiskt sätt. När du skapar ett diagram i PowerPoint skapas också det arkblad som är kopplat till diagrammet automatiskt. Diagramarkblad skapas för alla typer av diagram: linjediagram, stapeldiagram, soluppgångsdiagram, cirkeldiagram osv. För att se diagramkalkylbladet i PowerPoint ska du dubbelklicka på diagrammet:

![todo:image_alt_text](chart-worksheet-formulas_1.png)


Diagramkalkylbladet innehåller namnen på diagrammets element (Kategorinamn: *Category1*, Serienamn) och en tabell med numeriska data som hör till dessa kategorier och serier. Som standard, när du skapar ett nytt diagram – sätts diagramkalkylbladsdata till standarddata. Du kan sedan ändra kalkylbladsdata i arkbladet manuellt.

Vanligtvis representerar diagrammet komplicerade data (t.ex. finansiella analyser, vetenskapliga analyser) med celler som beräknas från värden i andra celler eller från annan dynamisk data. Att beräkna ett cellvärde manuellt och skriva in det hårdkodat i cellen gör det svårt att ändra det i framtiden. Om du ändrar värdet i en viss cell måste alla celler som är beroende av den också uppdateras. Dessutom kan tabelldata bero på data från andra tabeller, vilket skapar ett komplext presentationsdatatema som måste uppdateras på ett enkelt och flexibelt sätt.

**Diagramkalkylbladsformel** i en presentation är ett uttryck för att automatiskt beräkna och uppdatera diagramkalkylbladsdata. Kalkylbladsformeln definierar databeräkningslogiken för en viss cell eller en uppsättning celler. Kalkylbladsformeln är en matematisk formel eller en logisk formel som använder: cellreferenser, matematiska funktioner, logiska operatorer, aritmetiska operatorer, konverteringsfunktioner, strängkonstanter osv. Definitionen av formeln skrivs in i en cell, och den cellen innehåller inte ett enkelt värde. Kalkylbladsformeln beräknar värdet och returnerar det, sedan tilldelas detta värde till cellen. Diagramkalkylbladsformler i presentationer är i själva verket samma som Excel‑formler, och de stöder samma standardfunktioner, operatorer och konstanter för sin implementering.

I [**Aspose.Slides**](https://products.aspose.com/slides/sv/androidjava/) representeras diagramkalkylbladet med
[**Chart.getChartData.getChartDataWorkbook**](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IChartData#getChartDataWorkbook--)‑metoden i
[**IChartDataWorkbook**](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IChartDataWorkbook)‑typen.
Kalkylbladsformel kan tilldelas och ändras med
[**IChartDataCell.setFormula**](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IChartDataCell#setFormula-java.lang.String-)‑metoden.
Följande funktioner stöds för formler i Aspose.Slides:

- Logiska konstanter
- Numeriska konstanter
- Strängkonstanter
- Felkonstanter
- Aritmetiska operatorer
- Jämförelseoperatorer
- A1‑stil cellreferenser
- R1C1‑stil cellreferenser
- Fördefinierade funktioner


Typiskt lagrar kalkylblad de senast beräknade formelvärdena. Om diagramdata inte ändrats efter att presentationen har lästs in – returnerar [**IChartDataCell.getValue**](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IChartDataCell#getValue--)‑metoden dessa värden vid läsning. Men om kalkylbladsdata har ändrats, kastas **ChartDataCell.Value**‑egenskapen ett [**CellUnsupportedDataException**](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/CellUnsupportedDataException) för de ej stödda formlerna. Detta beror på att när formler har parserats framgångsrikt bestäms cellberoenden och korrektheten för de sista värdena. Om formeln inte kan parseras kan korrektheten för cellvärdet inte garanteras.

## **Lägg till en diagramkalkylbladsformel i en presentation**
Börja med att lägga till ett diagram på den första bilden i en ny presentation med
[IShapeCollection.getShapes.addChart](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IShapeCollection#addChart-int-float-float-float-float-).
Diagrammets arkblad skapas automatiskt och kan nås med
[**Chart.getChartData.getChartDataWorkbook**](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IChartData#getChartDataWorkbook--)‑metoden:

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

Låt oss skriva några värden i celler med
[**IChartDataCell.setValue**](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IChartDataCell#setValue-java.lang.Object-)‑egenskapen
av typen **Object**, vilket betyder att du kan tilldela vilket värde som helst till egenskapen:

```java
workbook.getCell(0, "F2").setValue(-2.5);

workbook.getCell(0, "G3").setValue(6.3);

workbook.getCell(0, "H4").setValue(3);
```

Nu, för att skriva en formel till cellen, kan du använda
[**IChartDataCell.setFormula**](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IChartDataCell#setFormula-java.lang.String-)‑metoden:

*Note*: [**IChartDataCell.setFormula**](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IChartDataCell#setFormula-java.lang.String-)‑metoden används för att ange A1‑stil cellreferenser. 

För att ange [R1C1Formula](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IChartDataCell#getR1C1Formula--)‑cellreferensen kan du använda
[**IChartDataCell.setR1C1Formula**](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IChartDataCell#setR1C1Formula-java.lang.String-)‑metoden:

När du sedan läser värdena från cellerna B2 och C2 beräknas de automatiskt:

```java
Object value1 = cell1.getValue(); // 7.8

Object value2 = cell2.getValue(); // 2.1
```

## **Logiska konstanter**
Du kan använda logiska konstanter såsom *FALSE* och *TRUE* i cellformler:

```java
workbook.getCell(0, "A2").setValue(false);
IChartDataCell cell = workbook.getCell(0, "B2");
cell.setFormula("A2 = TRUE");
Object value = cell.getValue(); // värdet innehåller boolean "false"
```

## **Numeriska konstanter**
Tal kan användas i vanlig eller vetenskaplig notation för att skapa diagramkalkylbladsformler:

```java
workbook.getCell(0, "A2").setFormula("1 + 0.5");
workbook.getCell(0, "B2").setFormula(".3 * 1E-2");
```

## **Strängkonstanter**
Sträng‑ (eller litteral‑)konstant är ett specifikt värde som används exakt som det är och förändras inte. Strängkonstanter kan vara: datum, texter, tal osv.:

```java
workbook.getCell(0, "A2").setFormula("\"abc\"");
workbook.getCell(0, "B2").setFormula("\"2/3/2020 12:00\"");
```

## **Felkonstanter**
Ibland är det inte möjligt att beräkna resultatet med formeln. I så fall visas felkoden i cellen istället för dess värde. Varje feltyp har en specifik kod:

- #DIV/0! – formeln försöker dividera med noll.
- #GETTING_DATA – kan visas i en cell medan dess värde fortfarande beräknas.
- #N/A – information saknas eller är inte tillgänglig. Orsaker kan vara: cellerna som används i formeln är tomma, ett extra mellanslag, felstavning osv.
- #NAME? – en viss cell eller annat formelobjekt kan inte hittas med dess namn.
- #NULL! – kan uppstå vid ett fel i formeln, t.ex. (,) eller ett mellanslag som används i stället för ett kolon (:).
- #NUM! – det numeriska i formeln kan vara ogiltigt, för långt eller för kort osv.
- #REF! – ogiltig cellreferens.
- #VALUE! – oväntad värdetyp. Till exempel, en sträng som tilldelats en numerisk cell.

```java
IChartDataCell cell = workbook.getCell(0, "A2");
cell.setFormula("2 / 0");
Object value = cell.getValue(); // värdet innehåller strängen "#DIV/0!"
```

## **Aritmetiska operatorer**
Du kan använda alla aritmetiska operatorer i diagramarkbladsformler:

|**Operator**|**Betydelse**|**Exempel**|
| :- | :- | :- |
|+ (plus‑tecken)|Addition eller unary plus|2 + 3|
|- (minus‑tecken)|Subtraktion eller negation|2 - 3<br>-3|
|* (asterisk)|Multiplikation|2 * 3|
|/ (snedstreck)|Division|2 / 3|
|% (procenttecken)|Procent|30%|
|^ (caret)|Exponentiering|2 ^ 3|

*Note*: För att ändra beräkningsordningen, omge den del av formeln som ska beräknas först med parenteser.

## **Jämförelseoperatorer**
Du kan jämföra cellvärden med jämförelseoperatorerna. När två värden jämförs med dessa operatorer blir resultatet ett logiskt värde, antingen *TRUE* eller *FALSE*:

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

|**Cellreferens**|**Exempel**|||
| :- | :- | :- | :- |
||Absolut|Relativ|Blandad|
|Cell|$A$2|A2|<p>A$2</p><p>$A2</p>|
|Rad|$2:$2|2:2|-|
|Kolumn|$A:$A|A:A|-|
|Område|$A$2:$C$4|A2:C4|<p>$A$2:C4</p><p>A$2:$C4</p>|


Här är ett exempel på hur man använder A1‑stil cellreferens i en formel:

```java
workbook.getCell(0, "A2").setFormula("C3 + SUM(F2:H5)");
```

## **R1C1‑stil cellreferenser**
**R1C1‑stil cellreferenser** används för arkblad där både rad och kolumn har numeriska identifierare. R1C1‑stil cellreferenser kan användas på följande sätt:

|**Cellreferens**|**Exempel**|||
| :- | :- | :- | :- |
||Absolut|Relativ|Blandad|
|Cell|R2C3|R[2]C[3]|R2C[3]<br>R[2]C3|
|Rad|R2|R[2]|-|
|Kolumn|C3|C[3]|-|
|Område|R2C3:R5C7|R[2]C[3]:R[5]C[7]|R2C3:R[5]C[7]<br>R[2]C3:R5C[7]|


Här är ett exempel på hur man använder R1C1‑stil cellreferens i en formel:

```java
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

Ja. Aspose.Slides stöder externa arbetsböcker som en [diagramdatas källa](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/chartdatasourcetype/), vilket låter dig använda formler från en XLSX‑fil utanför presentationen.

**Kan diagramformler referera till blad i samma arbetsbok med bladnamn?**

Ja. Formler följer den standardiserade Excel‑referensmodellen, så du kan referera till andra blad i samma arbetsbok eller en extern arbetsbok. För externa referenser inkluderas sökväg och arbetsbokens namn enligt Excel‑syntax.
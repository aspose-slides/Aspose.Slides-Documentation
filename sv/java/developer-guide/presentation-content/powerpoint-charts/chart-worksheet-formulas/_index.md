---
title: Tillämpa diagramarbetsbladsformler i presentationer med Java
linktitle: Arbetsbladsformler
type: docs
weight: 70
url: /sv/java/chart-worksheet-formulas/
keywords:
- diagramkalkylblad
- diagramarbetsblad
- diagramformel
- arbetsbladsformel
- kalkylbladsformel
- datakälla
- logisk konstant
- numerisk konstant
- strängkonstant
- felkonstant
- aritmetisk konstant
- jämförelseoperator
- A1‑stil
- R1C1‑stil
- fördefinierad funktion
- PowerPoint
- presentation
- Java
- Aspose.Slides
description: "Tillämpa Excel‑liknande formler i Aspose.Slides för Java‑diagramarbetsblad och automatisera rapporter i PPT‑ och PPTX‑filer."
---
## **Översikt**

Ett diagramarbetsblad är datakällan bakom ett diagram i en presentation. Det lagrar kategori- och serienamn tillsammans med de numeriska värden som visas i diagrammet. I Aspose.Slides är detta arbetsblad tillgängligt via diagramdataarbetsboken, vilket gör att du kan arbeta med diagramdata programatiskt.

Denna artikel förklarar hur du använder arbetsbladsformler i diagramdata så att cellvärden kan beräknas och uppdateras automatiskt istället för att matas in manuellt. Den visar hur du tilldelar formler, använder både A1‑stil och R1C1‑stil referenser, omberäknar arbetsboksformler och arbetar med de stödda konstanterna, operatorerna, cellreferenserna och fördefinierade funktionerna som finns tillgängliga för diagramarbetsblad i presentationer.

## **Om diagramkalkylbladsformler i presentationer**
**Diagramkalkylblad** (eller diagramarbetsblad) i en presentation är diagrammets datakälla. Diagramkalkylbladet innehåller data som visas i diagrammet på ett grafiskt sätt. När du skapar ett diagram i PowerPoint skapas arbetsbladet som är kopplat till diagrammet automatiskt. Diagramarbetsblad skapas för alla typer av diagram: linjediagram, stapeldiagram, solstråle‑diagram, cirkeldiagram osv. För att se diagramkalkylbladet i PowerPoint ska du dubbelklicka på diagrammet:

![todo:image_alt_text](chart-worksheet-formulas_1.png)


Diagramkalkylbladet innehåller namnen på diagrammets element (Kategorinamn: *Category1*, Serienamn) och en tabell med numeriska data som passar dessa kategorier och serier. Som standard, när du skapar ett nytt diagram – sätts diagramkalkylbladsdata till standarddata. Därefter kan du ändra kalkylbladsdata i arbetsbladet manuellt.

Vanligtvis representerar diagrammet komplicerade data (t.ex. finansiella analytiker, vetenskapliga analytiker), med celler som beräknas från värden i andra celler eller från annan dynamisk data. Att beräkna ett celvärde manuellt och hårdkoda det i cellen gör det svårt att ändra i framtiden. Om du ändrar värdet i en viss cell, måste alla celler som beror på den också uppdateras. Dessutom kan tabelldata bero på data från andra tabeller, vilket skapar ett komplext presentationsdataskema som behöver uppdateras på ett enkelt och flexibelt sätt.

**Diagramkalkylbladsformel** i en presentation är ett uttryck för att automatiskt beräkna och uppdatera diagramkalkylbladsdata. Kalkylbladsformeln definierar data‑beräkningslogiken för en viss cell eller en uppsättning celler. Kalkylbladsformeln är en matematikformel eller en logisk formel som använder: cellreferenser, matematiska funktioner, logiska operatorer, aritmetiska operatorer, konverteringsfunktioner, strängkonstanter osv. Definitionen av formeln skrivs in i en cell, och den cellen innehåller inte ett enkelt värde. Kalkylbladsformeln beräknar värdet och returnerar det, sedan tilldelas detta värde till cellen. Diagramkalkylbladsformler i presentationer är faktiskt samma som Excel‑formler, och samma standardfunktioner, operatorer och konstanter stöds för deras implementering.

In [**Aspose.Slides**](https://products.aspose.com/slides/sv/java/) diagramkalkylblad representeras med
[**Chart.getChartData.getChartDataWorkbook**](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IChartData#getChartDataWorkbook--) metod av
[**IChartDataWorkbook**](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IChartDataWorkbook) typen.
Kalkylbladsformel kan tilldelas och ändras med
[**IChartDataCell.setFormula**](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IChartDataCell#setFormula-java.lang.String-) metod.
Följande funktionalitet stöds för formler i Aspose.Slides:

- Logiska konstanter
- Numeriska konstanter
- Strängkonstanter
- Felkonstanter
- Aritmetiska operatorer
- Jämförelseoperatorer
- A1‑stil cellreferenser
- R1C1‑stil cellreferenser
- Fördefinierade funktioner

Vanligtvis lagrar kalkylblad de senast beräknade formelvärdena. Om diagramdata efter att presentationen laddats inte har ändrats – returnerar metoden [**IChartDataCell.getValue**](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IChartDataCell#getValue--) dessa värden vid läsning. Men om kalkylbladsdata har ändrats, kastar läsning av egenskapen **ChartDataCell.Value** ett [**CellUnsupportedDataException**](https://reference.aspose.com/slides/sv/java/com.aspose.slides/CellUnsupportedDataException) för de icke‑stödda formlerna. Detta beror på att när formler framgångsrikt har parsats, bestäms cellberoenden och korrektheten av de senaste värdena. Om formeln inte kan parsas kan korrektheten av cellvärdet inte garanteras.

## **Lägg till en diagramkalkylbladsformel i en presentation**
Först, lägg till ett diagram på den första bilden i en ny presentation med [IShapeCollection.getShapes.addChart](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IShapeCollection#addChart-int-float-float-float-float-). Diagrammets arbetsblad skapas automatiskt och kan nås med
[**Chart.getChartData.getChartDataWorkbook**](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IChartData#getChartDataWorkbook--) metod:

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
[**IChartDataCell.setValue**](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IChartDataCell#setValue-java.lang.Object-) egenskap
av typen **Object**, vilket betyder att du kan sätta vilket värde som helst på egenskapen:

```java
workbook.getCell(0, "F2").setValue(-2.5);

workbook.getCell(0, "G3").setValue(6.3);

workbook.getCell(0, "H4").setValue(3);
```

Nu för att skriva en formel till cellen kan du använda
[**IChartDataCell.setFormula**](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IChartDataCell#setFormula-java.lang.String-) metoden:

*Obs*: [**IChartDataCell.setFormula**](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IChartDataCell#setFormula-java.lang.String-) metoden används för att ange A1‑stil cellreferenser.

För att ange [R1C1Formula] cellreferens kan du använda [**IChartDataCell.setR1C1Formula**](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IChartDataCell#setR1C1Formula-java.lang.String-) metoden:

Därefter, om du försöker läsa värdena från cellerna B2 och C2, kommer de att beräknas:

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
Object value = cell.getValue(); // värdet innehåller booleskt "false"
```

## **Numeriska konstanter**
Tal kan användas i vanlig eller vetenskaplig notation för att skapa diagramkalkylbladsformler:

```java
workbook.getCell(0, "A2").setFormula("1 + 0.5");
workbook.getCell(0, "B2").setFormula(".3 * 1E-2");
```

## **Strängkonstanter**
Sträng (eller litteral) konstant är ett specifikt värde som används som det är och förändras inte. Strängkonstanter kan vara: datum, texter, tal osv.:

```java
workbook.getCell(0, "A2").setFormula("\"abc\"");
workbook.getCell(0, "B2").setFormula("\"2/3/2020 12:00\"");
```

## **Felkonstanter**
Ibland är det inte möjligt att beräkna resultatet med formeln. I så fall visas felkoden i cellen i stället för dess värde. Varje feltyp har en specifik kod:

- #DIV/0! – formeln försöker dividera med noll.
- #GETTING_DATA – kan visas i en cell medan dess värde fortfarande beräknas.
- #N/A – information saknas eller är inte tillgänglig. Orsaker kan vara: cellerna som används i formeln är tomma, ett extra mellanslag, felstavning osv.
- #NAME? – en viss cell eller annat formelobjekt kan inte hittas med dess namn.
- #NULL! – kan visas när det finns ett fel i formeln, t.ex. (,) eller ett mellanslag används i stället för ett kolontecken (:).
- #NUM! – det numeriska i formeln kan vara ogiltigt, för långt eller för kort osv.
- #REF! – ogiltig cellreferens.
- #VALUE! – oväntad värdetyp. Till exempel, en strängvärde sattt i en numerisk cell.

```java
IChartDataCell cell = workbook.getCell(0, "A2");
cell.setFormula("2 / 0");
Object value = cell.getValue(); // värdet innehåller strängen "#DIV/0!"
```

## **Aritmetiska operatorer**
Du kan använda alla aritmetiska operatorer i diagramarbetsbladsformler:

|**Operator**|**Betydelse**|**Exempel**|
| :- | :- | :- |
|+ (plus sign)|Addition eller unärt plus|2 + 3|
|- (minus sign)|Subtraktion eller negation|2 - 3<br>-3|
|* (asterisk)|Multiplikation|2 * 3|
|/ (forward slash)|Division|2 / 3|
|% (percent sign)|Procent|30%|
|^ (caret)|Exponentiering|2 ^ 3|

*Obs*: För att ändra evalueringsordning, omslut den del av formeln som ska beräknas först med parenteser.

## **Jämförelseoperatorer**
Du kan jämföra cellvärden med jämförelseoperatorerna. När två värden jämförs med dessa operatorer blir resultatet ett logiskt värde, antingen *TRUE* eller FALSE:

|**Operator**|**Betydelse**|**Exempel**|
| :- | :- | :- |
|= (equal sign)|Lika med|A2 = 3|
|<> (not equal sign)|Inte lika med|A2 <> 3|
|> (greater than sign)|Större än|A2 > 3|
|>= (greater than or equal to sign)|Större än eller lika med|A2 >= 3|
|< (less than sign)|Mindre än|A2 < 3|
|<= (less than or equal to sign)|Mindre än eller lika med|A2 <= 3|

## **A1‑stil cellreferenser**
**A1‑stil cellreferenser** används för arbetsblad där kolumnen har en bokstavsidentifierare (t.ex. "*A*") och raden har en numerisk identifierare (t.ex. "*1*"). A1‑stil cellreferenser kan användas på följande sätt:

|**Cellreferens**|**Exempel**|||
| :- | :- | :- | :- |
||Absolut|Relativ|Blandet|
|Cell|$A$2|A2|<p>A$2</p><p>$A2</p>|
|Row|$2:$2|2:2|-|
|Column|$A:$A|A:A|-|
|Range|$A$2:$C$4|A2:C4|<p>$A$2:C4</p><p>A$2:$C4</p>|

Här är ett exempel på hur man använder A1‑stil cellreferens i en formel:

```java
workbook.getCell(0, "A2").setFormula("C3 + SUM(F2:H5)");
```

## **R1C1‑stil cellreferenser**
**R1C1‑stil cellreferenser** används för arbetsblad där både rad och kolumn har numerisk identifierare. R1C1‑stil cellreferenser kan användas på följande sätt:

|**Cellreferens**|**Exempel**|||
| :- | :- | :- | :- |
||Absolut|Relativ|Blandet|
|Cell|R2C3|R[2]C[3]|R2C[3]<br>R[2]C3|
|Row|R2|R[2]|-|
|Column|C3|C[3]|-|
|Range|R2C3:R5C7|R[2]C[3]:R[5]C[7]|R2C3:R[5]C[7]<br>R[2]C3:R5C[7]|

Här är ett exempel på hur man använder R1C1‑stil cellreferens i en formel:

```java
workbook.getCell(0, "A2").setR1C1Formula("R2C4 + SUM(R5C6:R7C9)");
```

## **Fördefinierade funktioner**
Det finns fördefinierade funktioner som kan användas i formlerna för att förenkla deras implementering. Dessa funktioner kapslar in de mest använda operationerna, såsom:

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

**Stöds externa Excel‑filer som datakälla för ett diagram med formler?**

Ja. Aspose.Slides stödjer externa arbetsböcker som en [diagramdatakälla](https://reference.aspose.com/slides/sv/java/com.aspose.slides/chartdatasourcetype/), vilket låter dig använda formler från en XLSX fil utanför presentationen.

**Kan diagramformler referera till blad inom samma arbetsbok med bladnamn?**

Ja. Formler följer Excels standardreferensmodell, så du kan referera till andra blad i samma arbetsbok eller en extern arbetsbok. För externa referenser, inkludera sökväg och arbetsboksnamn med Excel‑syntax.
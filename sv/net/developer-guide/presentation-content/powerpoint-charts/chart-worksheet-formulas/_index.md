---
title: Använd diagrambladformler i presentationer i .NET
linktitle: Bladformler
type: docs
weight: 70
url: /sv/net/chart-worksheet-formulas/
keywords:
- diagramkalkylblad
- diagramblad
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
- A1-stil
- R1C1-stil
- fördefinierad funktion
- PowerPoint
- presentation
- .NET
- C#
- Aspose.Slides
description: "Använd Excel-liknande formler i Aspose.Slides för .NET-diagramblad och automatisera rapporter i PPT- och PPTX-filer."
---
## **Översikt**

Ett diagramblad är datakällan bakom ett diagram i en presentation. Det lagrar kategori‑ och serienamn tillsammans med de numeriska värden som visas av diagrammet. I Aspose.Slides är detta blad tillgängligt via diagramdataboken, vilket gör att du kan arbeta med diagramdata programmässigt.

Denna artikel förklarar hur du använder bladformler i diagramdata så att cellvärden kan beräknas och uppdateras automatiskt istället för att anges manuellt. Den visar hur du tilldelar formler, använder både A1‑stil och R1C1‑stil referenser, beräknar om arbetsbokens formler och arbetar med de stödjade konstanterna, operatorerna, cellreferenserna och fördefinierade funktionerna som finns för diagramblad i presentationer.

## **Om diagramkalkylbladsformler i presentationer**
**Chart spreadsheet** (eller chart worksheet) i en presentation är datakällan för diagrammet. Diagrambladet innehåller data som representeras i diagrammet på ett grafiskt sätt. När du skapar ett diagram i PowerPoint skapas bladet som är kopplat till diagrammet automatiskt. Diagramblad skapas för alla typer av diagram: linjediagram, stapeldiagram, sunburst‑diagram, cirkeldiagram osv. För att se diagrambladet i PowerPoint ska du dubbelklicka på diagrammet:

![todo:image_alt_text](chart-worksheet-formulas_1.png)

Diagrambladet innehåller namnen på diagrammets element (Category Name: *Category1*, Serie Name) och en tabell med numeriska data som hör till dessa kategorier och serier. Som standard, när du skapar ett nytt diagram – sätts diagrambladets data till standarddata. Därefter kan du ändra bladdata i kalkylbladet manuellt.

Vanligtvis representerar diagrammet komplicerade data (t.ex. finansiella eller vetenskapliga analyser), med celler som beräknas från värden i andra celler eller från annan dynamisk data. Att beräkna en cells värde manuellt och hårdkoda det i cellen gör det svårt att ändra i framtiden. Om du ändrar värdet i en viss cell måste alla celler som är beroende av den också uppdateras. Dessutom kan tabelldata bero på data från andra tabeller, vilket skapar ett komplext presentationsdataskema som behöver uppdateras på ett enkelt och flexibelt sätt.

**Chart spreadsheet formula** i en presentation är ett uttryck för att automatiskt beräkna och uppdatera diagrambladets data. Kalkylbladsformeln definierar data‑beräkningslogiken för en viss cell eller en mängd celler. Kalkylbladsformeln är en matematisk eller logisk formel som använder: cellreferenser, matematiska funktioner, logiska operatorer, aritmetiska operatorer, konverteringsfunktioner, strängkonstanter osv. Formeldefinitionen skrivs in i en cell, och denna cell innehåller inte ett enkelt värde. Kalkylbladsformeln beräknar värdet och returnerar det, varpå värdet tilldelas cellen. Diagramkalkylbladsformler i presentationer är i princip samma som Excel‑formler, och de stödjer samma standardfunktioner, operatorer och konstanter för deras implementering.

I [**Aspose.Slides**](https://products.aspose.com/slides/sv/net/) diagramblad representeras med 
[**Chart.ChartData.ChartDataWorkbook**](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/ichartdata/properties/chartdataworkbook) egenskapen av 
[**IChartDataWorkbook**](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/ichartdataworkbook) typen. 
Kalkylbladsformel kan tilldelas och ändras med 
[**IChartDataCell.Formula**](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/ichartdatacell/properties/formula) egenskapen. 
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

Typiskt lagrar kalkylblad de senast beräknade formelvärdena. Om diagramdata inte ändrades efter att presentationen laddats – returnerar **IChartDataCell.Value**‑egenskapen de värdena vid läsning. Men om kalkylbladsdata har ändrats, kastar läsning av **ChartDataCell.Value**‑egenskapen **CellUnsupportedDataException** för de icke‑stödda formlerna. Detta beror på att när formler lyckas parsas fastställs cellberoenden och korrektheten av de senaste värdena. Om formeln inte kan parsas kan korrektheten av cellvärdet inte garanteras.

## **Lägg till en diagramkalkylbladsformel i en presentation**
Först, lägg till ett diagram med några exempeldata på den första bilden i en ny presentation med 
[IShapeCollection.Shapes.AddChart](https://reference.aspose.com/slides/sv/net/aspose.slides.ishapecollection/addchart/methods/1). 
Diagrammets arbetsblad skapas automatiskt och kan nås med 
[**Chart.ChartData.ChartDataWorkbook**](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/ichartdata/properties/chartdataworkbook) egenskapen:

``` csharp

using (var presentation = new Presentation())

{

    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 150, 150, 500, 300);

    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

    // ...

}

```

Låt oss skriva några värden i celler med 
[**IChartDataCell.Value**](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/ichartdatacell/properties/value) egenskapen 
av typen **Object**, vilket betyder att du kan sätta vilket värde som helst på egenskapen:

``` csharp

workbook.GetCell(0, "F2").Value = -2.5;

workbook.GetCell(0, "G3").Value = 6.3;

workbook.GetCell(0, "H4").Value = 3;

```

Nu, för att skriva en formel till cellen, kan du använda 
[**IChartDataCell.Formula**](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/ichartdatacell/properties/formula) egenskapen:

``` csharp
workbook.GetCell(0, "B2").Formula = "F2+G3+H4+1";
```

*Obs*: [**IChartDataCell.Formula**](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/ichartdatacell/properties/formula) egenskapen används för att ange A1‑stil cellreferenser. 

För att sätta [R1C1Formula](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/ichartdatacell/properties/r1c1formula) cellreferensen kan du använda [**IChartDataCell.R1C1Formula**](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/ichartdatacell/properties/r1c1formula) egenskapen:

``` csharp
workbook.GetCell(0, "C2").R1C1Formula = "R[1]C[4]/R[2]C[5]";
```

Använd sedan [**IChartDataWorkbook.CalculateFormulas**](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/chartdataworkbook/methods/calculateformulas) metoden för att beräkna alla formler i arbetsboken och uppdatera motsvarande cellvärden:

``` csharp
workbook.CalculateFormulas();

object value1 = workbook.GetCell(0, "B2"); // 7.8

object value2 = workbook.GetCell(0, "C2"); // 2.1

```

## **Logiska konstanter**
Du kan använda logiska konstanter såsom *FALSE* och *TRUE* i cellformler:

## **Numeriska konstanter**
Tal kan användas i vanlig eller vetenskaplig notation för att skapa diagramkalkylbladsformler:

## **Strängkonstanter**
Sträng‑ (eller literal‑) konstanter är specifika värden som används som de är och förändras inte. Strängkonstanter kan vara: datum, texter, siffror osv.:

## **Felkonstanter**
Ibland är det inte möjligt att beräkna resultatet med formeln. I så fall visas felkoden i cellen i stället för dess värde. Varje feltyp har en specifik kod:

- #DIV/0! – formeln försöker dividera med noll.
- #GETTING_DATA – kan visas i en cell medan dess värde fortfarande beräknas.
- #N/A – information saknas eller är inte tillgänglig. Orsaker kan vara: cellerna som används i formeln är tomma, ett extra blanksteg, felstavning osv.
- #NAME? – en viss cell eller annat formelobjekt kan inte hittas med dess namn.
- #NULL! – kan uppstå när det finns ett fel i formeln, som t.ex. (,) eller ett mellanslag används i stället för ett kolon (:).
- #NUM! – det numeriska värdet i formeln kan vara ogiltigt, för långt eller för kort osv.
- #REF! – ogiltig cellreferens.
- #VALUE! – oväntad värdetyper. Till exempel ett textvärde i en numerisk cell.

## **Aritmetiska operatorer**
Du kan använda alla aritmetiska operatorer i diagrambladets formler:

|**Operator**|**Betydelse**|**Exempel**|
| :- | :- | :- |
|+ (plus sign)|Addition eller unärt plus|2 + 3|
|- (minus sign)|Subtraktion eller negation|2 - 3<br>-3|
|* (asterisk)|Multiplikation|2 * 3|
|/ (forward slash)|Division|2 / 3|
|% (percent sign)|Procent|30%|
|^ (caret)|Exponentiering|2 ^ 3|

*Obs*: För att ändra utvärderingsordningen, omge den del av formeln som ska beräknas först med parenteser.

## **Jämförelseoperatorer**
Du kan jämföra cellvärden med jämförelseoperatorerna. När två värden jämförs med dessa operatorer blir resultatet ett logiskt värde antingen *TRUE* eller *FALSE*:

|**Operator**|**Betydelse**|**Betydelse**|
| :- | :- | :- |
|= (equal sign)|Lika med|A2 = 3|
|<> (not equal sign)|Inte lika med|A2 <> 3|
|> (greater than sign)|Större än|A2 > 3|
|>= (greater than or equal to sign)|Större än eller lika med|A2 >= 3|
|< (less than sign)|Mindre än|A2 < 3|
|<= (less than or equal to sign)|Mindre än eller lika med|A2 <= 3|

## **A1-stil cellreferenser**
**A1‑stil cellreferenser** används för kalkylblad där kolumnen har en bokstavsidentifierare (t.ex. "*A*") och raden har en numerisk identifierare (t.ex. "*1*"). A1‑stil cellreferenser kan användas på följande sätt:

|**Cellreferens**|**Exempel**|||
| :- | :- | :- | :- |
||Absolut|Relativ|Blandad|
|Cell|$A$2|A2|<p>A$2</p><p>$A2</p>|
|Rad|$2:$2|2:2|-|
|Kolumn|$A:$A|A:A|-|
|Omfång|$A$2:$C$4|A2:C4|<p>$A$2:C4</p><p>A$2:$C4</p>|

Här är ett exempel på hur man använder A1‑stil cellreferens i en formel:

## **R1C1-stil cellreferenser**
**R1C1‑stil cellreferenser** används för kalkylblad där både rad och kolumn har numeriska identifierare. R1C1‑stil cellreferenser kan användas på följande sätt:

|**Cellreferens**|**Exempel**|||
| :- | :- | :- | :- |
||Absolut|Relativ|Blandad|
|Cell|R2C3|R[2]C[3]|R2C[3]<br>R[2]C3|
|Rad|R2|R[2]|-|
|Kolumn|C3|C[3]|-|
|Omfång|R2C3:R5C7|R[2]C[3]:R[5]C[7]|R2C3:R[5]C[7]<br>R[2]C3:R5C[7]|

Här är ett exempel på hur man använder R1C1‑stil cellreferens i en formel:

## **Fördefinierade funktioner**
Det finns fördefinierade funktioner som kan användas i formler för att förenkla deras implementering. Dessa funktioner kapslar in de mest använda operationerna, såsom:

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

Ja. Aspose.Slides stödjer externa arbetsböcker som en [chart's data source](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/chartdatasourcetype/), vilket låter dig använda formler från en XLSX‑fil utanför presentationen.

**Kan diagramformler referera till blad inom samma arbetsbok med bladnamn?**

Ja. Formler följer den standard‑Excel‑referensmodell som används i Excel, så du kan referera till andra blad inom samma arbetsbok eller en extern arbetsbok. För externa referenser inkluderas sökväg och arbetsboksnamn enligt Excel‑syntaxen.
---
title: Tillämpa diagrambladformler i presentationer med Python
linktitle: Bladformler
type: docs
weight: 70
url: /sv/python-net/chart-worksheet-formulas/
keywords:
- diagramkalkylblad
- diagramblad
- diagramformel
- bladformel
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
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Använd Excel-liknande formler i Aspose.Slides för Python via .NET diagramblad och automatisera rapporter i PPT-, PPTX- och ODP-filer."
---
## **Översikt**

Ett diagramblad är datakällan bakom ett diagram i en presentation. Det lagrar kategori- och serienamn tillsammans med de numeriska värden som visas i diagrammet. I Aspose.Slides är detta blad tillgängligt via diagramdataboken, vilket gör att du kan arbeta med diagramdata programatiskt.

Den här artikeln förklarar hur du använder bladformler i diagramdata så att cellvärden kan beräknas och uppdateras automatiskt i stället för att anges manuellt. Den visar hur man tilldelar formler, använder både A1‑stil‑ och R1C1‑stil‑referenser, omberäknar arbetsboksformler samt arbetar med de stödjade konstanterna, operatorerna, cellreferenserna och fördefinierade funktionerna som finns tillgängliga för diagramblad i presentationer.

## **Om diagramkalkylbladsformel i en presentation**
**Diagramkalkylblad** (eller diagramblad) i en presentation är diagrammets datakälla. Diagramkalkylbladet innehåller data som visas i diagrammet på ett grafiskt sätt. När du skapar ett diagram i PowerPoint skapas bladet som är kopplat till diagrammet automatiskt också. Diagramblad skapas för alla diagramtyper: linjediagram, stapeldiagram, solutspridd diagram, cirkeldiagram osv. För att se diagramkalkylbladet i PowerPoint ska du dubbelklicka på diagrammet:

![todo:image_alt_text](chart-worksheet-formulas_1.png)



Diagramkalkylbladet innehåller namnen på diagrammets element (Kategorinamn: *Category1*, Serienamn) och en tabell med numeriska data som motsvarar dessa kategorier och serier. Som standard, när du skapar ett nytt diagram – sätts diagramkalkylbladsdata till standarddata. Därefter kan du ändra kalkylbladsdata i bladet manuellt.

Vanligtvis representerar diagrammet komplicerade data (t.ex. finansiella analytiker, vetenskapliga analytiker) med celler som beräknas från värden i andra celler eller från annan dynamisk data. Att beräkna en cells värde manuellt och hårdkoda det i cellen gör det svårt att ändra i framtiden. Om du ändrar värdet i en viss cell, måste alla celler som är beroende av den också uppdateras. Dessutom kan tabelldata bero på data från andra tabeller, vilket skapar ett komplext presentationsdataskema som behöver uppdateras på ett enkelt och flexibelt sätt.

**Diagramkalkylbladsformel** i en presentation är ett uttryck som automatiskt beräknar och uppdaterar diagramkalkylbladsdata. Kalkylbladsformeln definierar databeräkningslogiken för en viss cell eller en uppsättning celler. En kalkylbladsformel är en matematikformel eller en logisk formel som använder: cellreferenser, matematiska funktioner, logiska operatorer, aritmetiska operatorer, konverteringsfunktioner, strängkonstanter osv. Formelförklaringen skrivs in i en cell, och den cellen innehåller inte ett enkelt värde. Kalkylbladsformeln beräknar värdet och returnerar det, varpå detta värde tilldelas cellen. Diagramkalkylbladsformler i presentationer är i själva verket samma som Excel‑formler, och de stöder samma standardfunktioner, operatorer och konstanter för sin implementering.

I [**Aspose.Slides**](https://products.aspose.com/slides/sv/python-net/) representeras diagramkalkylbladet med egenskapen [**Chart.ChartData.ChartDataWorkbook**](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/ichartdata/) av typen [**IChartDataWorkbook**](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/ichartdataworkbook/). Kalkylbladsformeln kan tilldelas och ändras med egenskapen [**formula**](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/ichartdatacell/). Följande funktionalitet stöds för formler i Aspose.Slides:

- Logiska konstanter
- Numeriska konstanter
- Strängkonstanter
- Felkonstanter
- Aritmetiska operatorer
- Jämförelseoperatorer
- A1‑stil‑cellreferenser
- R1C1‑stil‑cellreferenser
- Fördefinierade funktioner

Vanligtvis lagrar kalkylblad de senast beräknade formelvärdena. Om diagramdata inte har ändrats efter att presentationen laddats – returnerar egenskapen **IChartDataCell.Value** dessa värden vid läsning. Men om kalkylbladsdata har ändrats, så kastar egenskapen **ChartDataCell.Value** ett **CellUnsupportedDataException** för de icke‑stödda formlerna. Detta beror på att när formler har parsats korrekt bestäms cellberoenden och korrektheten för de senaste värdena. Men om formeln inte kan parsas kan korrektheten för cellvärdet inte garanteras.

## **Lägg till diagramkalkylbladsformel i en presentation**
Börja med att lägga till ett diagram med några exempeldata på den första bilden i en ny presentation med [add_chart](https://reference.aspose.com/slides/sv/python-net/aspose.slides/ishapecollection/). Diagrammets blad skapas automatiskt och kan nås med egenskapen [**chart_data_workbook**](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/ichartdata/).

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 150, 150, 500, 300)
    workbook = chart.chart_data.chart_data_workbook
    # ...
```

Låt oss skriva några värden i celler med egenskapen [**value**](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/ichartdatacell/) av typen **Object**, vilket betyder att du kan sätta vilket värde som helst på egenskapen:

```py
    workbook.get_cell(0, "F2").value = -2.5
    workbook.get_cell(0, "G3").value = 6.3
    workbook.get_cell(0, "H4").value = 3
```

För att nu skriva en formel till cellen kan du använda egenskapen [**formula**](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/ichartdatacell/):

```py
    workbook.get_cell(0, "B2").formula = "F2+G3+H4+1"
```

*Obs*: [**IChartDataCell.Formula**](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/ichartdatacell/) egenskapen används för att ange A1‑stil‑cellreferenser.

För att ange cellreferensen [r1c1_formula](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/ichartdatacell/) kan du använda egenskapen [**r1c1_formula**](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/ichartdatacell/):

```py
    workbook.get_cell(0, "C2").r1c1_formula = "R[1]C[4]/R[2]C[5]"
```

Använd sedan metoden [**calculate_formulas**](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/chartdataworkbook/) för att beräkna alla formler i arbetsboken och uppdatera motsvarande cellvärden:

```py
    workbook.calculate_formulas()
    print(workbook.get_cell(0, "B2").value) # 7.8
    print(workbook.get_cell(0, "C2").value) # 2.1
```

## **Logiska konstanter**
Du kan använda logiska konstanter såsom *FALSE* och *TRUE* i cellformler:

## **Numeriska konstanter**
Tal kan användas i vanlig eller vetenskaplig notation för att skapa diagramkalkylbladsformler:

## **Strängkonstanter**
En sträng‑ (eller litteral) konstant är ett specifikt värde som används som det är och inte förändras. Strängkonstanter kan vara: datum, texter, tal osv.:

## **Felkonstanter**
Ibland är det inte möjligt att beräkna resultatet med formeln. I så fall visas felkoden i cellen i stället för dess värde. Varje feltyp har en specifik kod:

- #DIV/0! – formeln försöker dividera med noll.
- #GETTING_DATA – kan visas i en cell medan dess värde fortfarande beräknas.
- #N/A – information saknas eller är otillgänglig. Några orsaker kan vara: cellerna som används i formeln är tomma, ett extra mellanslag, felstavning osv.
- #NAME? – en viss cell eller annat formelobjekt kan inte hittas enligt dess namn.
- #NULL! – kan uppstå när det finns ett fel i formeln, t.ex. (,) eller ett mellanslag används i stället för ett kolon (:).
- #NUM! – den numeriska värdet i formeln kan vara ogiltigt, för långt eller för kort osv.
- #REF! – ogiltig cellreferens.
- #VALUE! – oväntad värdetyp. Till exempel, en strängvärde som sätts i en numerisk cell.

## **Aritmetiska operatorer**
Du kan använda alla aritmetiska operatorer i diagrambladets formler:

|**Operator**|**Betydelse**|**Exempel**|
| :- | :- | :- |
|+ (plustecken)|Addition eller unär plus|2 + 3|
|- (minustecken)|Subtraktion eller negation|2 - 3<br>-3|
|* (asterisk)|Multiplikation|2 * 3|
|/ (snedstreck)|Division|2 / 3|
|% (procenttecken)|Procent|30%|
|^ (caret)|Exponentiering|2 ^ 3|

*Obs*: För att ändra utvärderingsordningen, omge den del av formeln som ska beräknas först med parenteser.

## **Jämförelseoperatorer**
Du kan jämföra cellvärden med jämförelseoperatorerna. När två värden jämförs med dessa operatorer blir resultatet ett logiskt värde, antingen *TRUE* eller *FALSE*:

|**Operator**|**Betydelse**|**Exempel**|
| :- | :- | :- |
|= (likhetstecken)|Lika med|A2 = 3|
|<> (inte lika med)|Inte lika med|A2 <> 3|
|> (större‑än‑tecken)|Större än|A2 > 3|
|>= (större‑eller‑lika‑tecken)|Större än eller lika med|A2 >= 3|
|< (mindre‑än‑tecken)|Mindre än|A2 < 3|
|<= (mindre‑eller‑lika‑tecken)|Mindre än eller lika med|A2 <= 3|

## **A1‑stil‑cellreferenser**
**A1‑stil‑cellreferenser** används för kalkylblad där kolumnen har en bokstavsidentifierare (t.ex. "*A*") och raden har en numerisk identifierare (t.ex. "*1*"). A1‑stil‑cellreferenser kan användas på följande sätt:

|**Cellreferens**|**Exempel**|||
| :- | :- | :- | :- |
||Absolut|Relativ|Blandad|
|Cell|$A$2|A2|<p>A$2</p><p>$A2</p>|
|Row|$2:$2|2:2|-|
|Column|$A:$A|A:A|-|
|Range|$A$2:$C$4|A2:C4|<p>$A$2:C4</p><p>A$2:$C4</p>|

Här är ett exempel på hur man använder en A1‑stil‑cellreferens i en formel:

## **R1C1‑stil‑cellreferenser**
**R1C1‑stil‑cellreferenser** används för kalkylblad där både rad och kolumn har numerisk identifierare. R1C1‑stil‑cellreferenser kan användas på följande sätt:

|**Cellreferens**|**Exempel**|||
| :- | :- | :- | :- |
||Absolut|Relativ|Blandad|
|Cell|R2C3|R[2]C[3]|R2C[3]<br>R[2]C3|
|Row|R2|R[2]|-|
|Column|C3|C[3]|-|
|Range|R2C3:R5C7|R[2]C[3]:R[5]C[7]|R2C3:R[5]C[7]<br>R[2]C3:R5C[7]|

Här är ett exempel på hur man använder en A1‑stil‑cellreferens i en formel:

## **Fördefinierade funktioner**
Det finns fördefinierade funktioner som kan användas i formler för att förenkla deras implementation. Dessa funktioner kapslar in de mest använda operationerna, såsom:

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

Ja. Aspose.Slides stöder externa arbetsböcker som ett [diagramdatakälla](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/chartdatasourcetype/), vilket låter dig använda formler från en XLSX utanför presentationen.

**Kan diagramformler referera till blad inom samma arbetsbok med bladnamn?**

Ja. Formler följer den standardiserade Excel‑referensmodellen, så du kan referera till andra blad i samma arbetsbok eller en extern arbetsbok. För externa referenser inkluderas sökväg och arbetsboksnamn enligt Excel‑syntax.
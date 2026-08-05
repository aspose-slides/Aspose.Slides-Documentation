---
title: Använd diagramarbetsbladsformler i presentationer med C++
linktitle: Arbetsbladsformler
type: docs
weight: 70
url: /sv/cpp/chart-worksheet-formulas/
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
- A1-stil
- R1C1-stil
- fördefinierad funktion
- PowerPoint
- presentation
- C++
- Aspose.Slides
description: "Använd Excel-liknande formler i Aspose.Slides för C++-diagramarbetsblad och automatisera rapporter i PPT- och PPTX-filer."
---
## **Översikt**

Ett diagramarbetsblad är datakällan bakom ett diagram i en presentation. Det lagrar kategori‑ och serienamn tillsammans med de numeriska värden som visas i diagrammet. I Aspose.Slides är detta arbetsblad tillgängligt via diagramdataboken, vilket gör att du kan arbeta med diagramdata programmässigt.

Den här artikeln förklarar hur du använder arbetsbladsformler i diagramdata så att cellvärden kan beräknas och uppdateras automatiskt istället för att matas in manuellt. Den visar hur du tilldelar formler, använder både A1‑stil och R1C1‑stil referenser, omberäknar arbetsboksformler samt arbetar med de stödjade konstanterna, operatorerna, cellreferenserna och fördefinierade funktionerna som finns för diagramarbetsblad i presentationer.

## **Om diagramkalkylbladsformler i presentationer**
**Diagramkalkylblad** (eller diagramarbetsblad) i en presentation är diagrammets datakälla. Diagramkalkylbladet innehåller data som visas i diagrammet på ett grafiskt sätt. När du skapar ett diagram i PowerPoint skapas arbetsbladet som är kopplat till diagrammet automatiskt. Diagramarbetsblad skapas för alla typer av diagram: linjediagram, stapeldiagram, solstråle‑diagram, cirkeldiagram osv. För att se diagramkalkylbladet i PowerPoint ska du dubbelklicka på diagrammet:

![todo:image_alt_text](chart-worksheet-formulas_1.png)

Diagramkalkylbladet innehåller namnen på diagrammets element (Kategorinamn: *Category1*, Serienamn) och en tabell med numeriska data som motsvarar dessa kategorier och serier. Som standard, när du skapar ett nytt diagram – så sätts diagramkalkylbladsdata till standarddata. Därefter kan du ändra kalkylbladsdata i arbetsbladet manuellt.

Vanligtvis representerar diagrammet komplicerade data (t.ex. finansiella analytiker, vetenskapliga analytiker) med celler som beräknas från värden i andra celler eller från annan dynamisk data. Att beräkna en cells värde manuellt och hårdkoda det i cellen gör det svårt att ändra i framtiden. Om du ändrar värdet i en viss cell måste alla celler som beror på den också uppdateras. Dessutom kan tabelldata bero på data från andra tabeller, vilket skapar ett komplext presentationsdataschema som behöver uppdateras på ett enkelt och flexibelt sätt.

**Diagramkalkylbladsformel** i en presentation är ett uttryck för att automatiskt beräkna och uppdatera diagramkalkylbladsdata. Kalkylbladsformeln definierar beräkningslogiken för en viss cell eller en uppsättning celler. En kalkylbladsformel är en matematisk eller logisk formel som använder: cellreferenser, matematiska funktioner, logiska operatorer, aritmetiska operatorer, konverteringsfunktioner, strängkonstanter osv. Formelddefinitionen skrivs in i en cell, och den cellen innehåller inte ett enkelt värde. Kalkylbladsformeln beräknar värdet och returnerar det, varefter värdet tilldelas cellen. Diagramkalkylbladsformler i presentationer är i praktiken samma som Excel‑formler, och de stödjer samma standardfunktioner, operatorer och konstanter för deras implementering.

I [**Aspose.Slides**](https://products.aspose.com/slides/sv/cpp/) representeras diagramkalkylbladet med metoden [**ChartData::get_ChartDataWorkbook()**](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.charts.chart_data#a32097093561723a10df0a57dc91acaea) av typen [**IChartDataWorkbook**](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.charts.i_chart_data_workbook). Kalkylbladsformeln kan tilldelas och ändras med metoden [**IChartDataCell::set_Formula()**](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.charts.i_chart_data_cell#a6806c6a40e025e6834c4c5f3af3cf692).

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

Vanligtvis lagrar kalkylblad de senast beräknade formelvärdena. Om diagramdata inte har ändrats efter att presentationen har lästs in – returnerar metoden **IChartDataCell.get_Value()** dessa värden vid läsning. Men om kalkylbladsdata har ändrats, kastar metoden **ChartDataCell.get_Value()** en **CellUnsupportedDataException** för de formler som inte stöds. Detta beror på att när formler lyckas parsas bestäms cellberoenden och riktigheten av de senaste värdena. Om en formel däremot inte kan parsas kan cellvärdets korrekthet inte garanteras.

## **Lägg till en diagramkalkylbladsformel i en presentation**
Först, lägg till ett diagram på den första bilden i en ny presentation med [IShapeCollection::AddChart()](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.i_shape_collection#a2cd4d47fc5c536012ee15b3a69486374). Arbetsbladet för diagrammet skapas automatiskt och kan nås med metoden [**ChartData::get_ChartDataWorkbook()**](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.charts.chart_data#a32097093561723a10df0a57dc91acaea):

``` cpp
auto presentation = System::MakeObject<Presentation>();
    
auto chart = presentation->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::ClusteredColumn, 150.0f, 150.0f, 500.0f, 300.0f);
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();

// ...
```

Låt oss skriva några värden i celler med metoden [**IChartDataCell.set_Value()**](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.charts.i_chart_data_cell#ad85809f520195e09225abae9002635ec) för typen **Object**, vilket betyder att du kan skicka vilket värde som helst till metoden:

``` cpp
workbook->GetCell(0, u"F2")->set_Value(System::ObjectExt::Box<double>(-2.5));
workbook->GetCell(0, u"G3")->set_Value(System::ObjectExt::Box<double>(6.3));
workbook->GetCell(0, u"H4")->set_Value(System::ObjectExt::Box<int32_t>(3));
```

För att nu skriva en formel till cellen kan du använda metoden [**IChartDataCell::set_Formula()**](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.charts.i_chart_data_cell#a6806c6a40e025e6834c4c5f3af3cf692):

*Obs*: Metoden [**IChartDataCell::set_Formula()**](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.charts.i_chart_data_cell#a6806c6a40e025e6834c4c5f3af3cf692) används för att ange A1‑stil cellreferenser.

För att ange R1C1‑formelcellreferensen kan du använda metoden [**IChartDataCell::set_R1C1Formula()**](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.charts.i_chart_data_cell#a47f5825dd38d0dddb11ecc3a43d388c7):

``` cpp
auto value1 = cell1->get_Value(); // 7.8
auto value2 = cell2->get_Value(); // 2.1
```

## **Logiska konstanter**
Du kan använda logiska konstanter som *FALSE* och *TRUE* i cellformler:

## **Numeriska konstanter**
Tal kan användas i vanlig eller vetenskaplig notation för att skapa diagramkalkylbladsformler:

## **Strängkonstanter**
En sträng‑ (eller literal) konstant är ett specifikt värde som används som det är och inte förändras. Strängkonstanter kan vara: datum, texter, tal osv.:

## **Felkonstanter**
Ibland går det inte att beräkna resultatet med formeln. I så fall visas felkoden i cellen i stället för dess värde. Varje feltyp har en specifik kod:

- #DIV/0! – formeln försöker dividera med noll.
- #GETTING_DATA – kan visas i en cell medan dess värde fortfarande beräknas.
- #N/A – information saknas eller är otillgänglig. Orsaker kan vara: cellerna som används i formeln är tomma, ett extra mellanslag, felstavning osv.
- #NAME? – en viss cell eller annat formelobjekt kan inte hittas med dess namn.
- #NULL! – kan uppstå när det finns ett fel i formeln, t.ex. (,) eller ett mellanslag som använts i stället för ett kolon (:).
- #NUM! – det numeriska i formeln kan vara ogiltigt, för långt eller för kort osv.
- #REF! – ogiltig cellreferens.
- #VALUE! – oväntad värdetyp. Till exempel, ett strängvärde i en numerisk cell.

## **Aritmetiska operatorer**
Du kan använda alla aritmetiska operatorer i diagramarbetsbladsformler:

|**Operator**|**Betydelse**|**Exempel**|
| :- | :- | :- |
|+ (plus‑tecken) |Addition eller unärt plustecken|2 + 3|
|- (minus‑tecken) |Subtraktion eller negation |2 - 3<br>-3|
|* (asterisk) |Multiplikation |2 * 3|
|/ (snedstreck) |Division |2 / 3|
|% (procenttecken) |Procent |30%|
|^ (caret) |Exponentiering |2 ^ 3|

*Obs*: För att ändra beräkningsordningen, omge den del av formeln som ska beräknas först med parenteser.

## **Jämförelseoperatorer**
Du kan jämföra cellvärden med jämförelseoperatorerna. När två värden jämförs med dessa operatorer blir resultatet ett logiskt värde, antingen *TRUE* eller *FALSE*:

|**Operator**|**Betydelse**|**Exempel**|
| :- | :- | :- |
|= (likhetstecken) |Lika med |A2 = 3|
|<> (inte lika med) |Inte lika med|A2 <> 3|
|> (större‑än‑tecken) |Större än|A2 > 3|
|>= (större‑eller‑lika‑tecken) |Större än eller lika med|A2 >= 3|
|< (mindre‑än‑tecken) |Mindre än|A2 < 3|
|<= (mindre‑eller‑lika‑tecken) |Mindre än eller lika med|A2 <= 3|

## **A1‑stil cellreferenser**
**A1‑stil cellreferenser** används för arbetsblad där kolumnen har en bokstavsidentifierare (t.ex. "*A*") och raden har en numerisk identifierare (t.ex. "*1*"). A1‑stil cellreferenser kan användas på följande sätt:

|**Cellreferens**|**Exempel**|**Absolut**|**Relativ**|**Blandad**|
| :- | :- | :- | :- | :- |
|Cell|$A$2|A2|<p>A$2</p><p>$A2</p>|
|Row|$2:$2|2:2|-|
|Column|$A:$A|A:A|-|
|Range|$A$2:$C$4|A2:C4|<p>$A$2:C4</p><p>A$2:$C4</p>|

Här är ett exempel på hur man använder en A1‑stil cellreferens i en formel:

## **R1C1‑stil cellreferenser**
**R1C1‑stil cellreferenser** används för arbetsblad där både rad och kolumn har numeriska identifierare. R1C1‑stil cellreferenser kan användas på följande sätt:

|**Cellreferens**|**Exempel**|**Absolut**|**Relativ**|**Blandad**|
| :- | :- | :- | :- | :- |
|Cell|R2C3|R[2]C[3]|R2C[3]<br>R[2]C3|
|Row|R2|R[2]|-|
|Column|C3|C[3]|-|
|Range|R2C3:R5C7|R[2]C[3]:R[5]C[7]|R2C3:R[5]C[7]<br>R[2]C3:R5C[7]|

Här är ett exempel på hur man använder en A1‑stil cellreferens i en formel:

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

Ja. Aspose.Slides stöder externa arbetsböcker som en [diagramdatasökälla](https://reference.aspose.com/slides/sv/cpp/aspose.slides.charts/chartdatasourcetype/), vilket gör att du kan använda formler från en XLSX utanför presentationen.

**Kan diagramformler referera till blad inom samma arbetsbok med bladnamn?**

Ja. Formler följer den standardiserade Excel‑referensmodellen, så du kan referera till andra blad i samma arbetsbok eller en extern arbetsbok. För externa referenser inkluderas sökväg och arbetsboksnamn enligt Excel‑syntax.
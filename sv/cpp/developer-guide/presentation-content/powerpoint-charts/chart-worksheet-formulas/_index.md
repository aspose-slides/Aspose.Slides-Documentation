---
title: Använd diagramarbetsbladsformler i presentationer med С++
linktitle: Arbetsbladsformler
type: docs
weight: 70
url: /sv/cpp/chart-worksheet-formulas/
keywords:
- diagram kalkylblad
- diagram arbetsblad
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
- A1 stil
- R1C1 stil
- fördefinierad funktion
- PowerPoint
- presentation
- С++
- Aspose.Slides
description: "Använd Excel-liknande formler i Aspose.Slides för С++ diagramarbetsblad och automatisera rapporter i PPT- och PPTX-filer."
---
## **Översikt**

Ett diagramarbetsblad är datakällan bakom ett diagram i en presentation. Det lagrar kategori‑ och serienamn tillsammans med de numeriska värden som visas i diagrammet. I Aspose.Slides är detta arbetsblad tillgängligt via diagramdataboken, som låter dig arbeta med diagramdata programatiskt.

Den här artikeln förklarar hur du använder arbetsbladsformler i diagramdata så att cellvärden kan beräknas och uppdateras automatiskt i stället för att matas in manuellt. Den visar hur du tilldelar formler, använder både A1‑stil och R1C1‑stil referenser, omräknar arbetsboksformler och arbetar med de stödjade konstanterna, operatorerna, cellreferenserna och fördefinierade funktionerna som finns för diagramarbetsblad i presentationer.

## **Om diagram‑kalkylbladsformler i presentationer**
**Diagram‑kalkylblad** (eller diagramarbetsblad) i en presentation är datakällan för diagrammet. Diagram‑kalkylbladet innehåller data som visas i diagrammet på ett grafiskt sätt. När du skapar ett diagram i PowerPoint skapas arbetsbladet som är kopplat till diagrammet automatiskt. Diagramarbetsblad skapas för alla diagramtyper: linjediagram, stapeldiagram, solros‑diagram, cirkeldiagram osv. För att se diagram‑kalkylbladet i PowerPoint ska du dubbelklicka på diagrammet:

![todo:image_alt_text](chart-worksheet-formulas_1.png)

Diagram‑kalkylbladet innehåller namnen på diagrammets element (Kategorinamn: *Category1*, Serienamn) och en tabell med numeriska data som motsvarar dessa kategorier och serier. Som standard, när du skapar ett nytt diagram – sätts diagram‑kalkylbladsdata till standardvärden. Därefter kan du ändra kalkylbladsdata i arbetsbladet manuellt.

Vanligtvis representerar diagrammet komplicerade data (t.ex. finansiella eller vetenskapliga analyser) där celler beräknas från värden i andra celler eller från dynamiska data. Att beräkna en cells värde manuellt och hårdkoda det i cellen gör framtida ändringar svåra. Om du ändrar värdet i en viss cell måste alla beroende celler också uppdateras. Dessutom kan tabelldata bero på data från andra tabeller, vilket skapar ett komplext presentationsdataskema som behöver uppdateras på ett enkelt och flexibelt sätt.

**Diagram‑kalkylbladsformel** i en presentation är ett uttryck som automatiskt beräknar och uppdaterar diagram‑kalkylbladsdata. Formeln definierar beräkningslogiken för en viss cell eller ett antal celler. En kalkylbladsformel är en matematisk eller logisk formel som använder: cellreferenser, matematiska funktioner, logiska operatorer, aritmetiska operatorer, konverteringsfunktioner, strängkonstanter osv. Formeldefinitionen skrivs in i en cell, och den cellen innehåller inte ett enkelt värde. Kalkylbladsformeln beräknar värdet och returnerar det, varefter värdet tilldelas cellen. Diagram‑kalkylbladsformler i presentationer är i praktiken samma som Excel‑formler, och de stödjer samma standardfunktioner, operatorer och konstanter.

I [**Aspose.Slides**](https://products.aspose.com/slides/sv/cpp/) representeras diagram‑kalkylbladet med 
[**ChartData::get_ChartDataWorkbook()**](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.charts.chart_data#a32097093561723a10df0a57dc91acaea)-metoden för 
[**IChartDataWorkbook**](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.charts.i_chart_data_workbook)-typen. 
Kalkylbladsformel kan tilldelas och ändras med 
[**IChartDataCell::set_Formula()**](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.charts.i_chart_data_cell#a6806c6a40e025e6834c4c5f3af3cf692)-metoden. 
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

Vanligtvis lagrar kalkylblad de senast beräknade formelvärdena. Om diagramdata inte ändras efter att presentationen har laddats, returnerar **IChartDataCell.get_Value()**‑metoden de värdena vid läsning. Men om kalkylbladsdata har ändrats, kastar **ChartDataCell.get_Value()**‑metoden **CellUnsupportedDataException** för de icke‑stödda formlerna. Detta beror på att när formler har parserats korrekt, bestäms cellberoenden och korrektheten för de sista värdena fastställs. Om formeln däremot inte kan parseras, kan korrektheten för cellvärdet inte garanteras.

## **Lägg till en diagram‑kalkylbladsformel i en presentation**
Börja med att lägga till ett diagram på den första bilden i en ny presentation med 
[IShapeCollection::AddChart()](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.i_shape_collection#a2cd4d47fc5c536012ee15b3a69486374). 
Diagrammets arbetsblad skapas automatiskt och kan nås med 
[**ChartData::get_ChartDataWorkbook()**](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.charts.chart_data#a32097093561723a10df0a57dc91acaea)-metoden:

``` cpp
auto presentation = System::MakeObject<Presentation>();
    
auto chart = presentation->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::ClusteredColumn, 150.0f, 150.0f, 500.0f, 300.0f);
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();

// ...
```

Låt oss skriva några värden i celler med 
[**IChartDataCell.set_Value()**](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.charts.i_chart_data_cell#ad85809f520195e09225abae9002635ec)-metoden 
av typen **Object**, vilket betyder att du kan skicka vilket värde som helst till metoden:

``` cpp
workbook->GetCell(0, u"F2")->set_Value(System::ObjectExt::Box<double>(-2.5));
workbook->GetCell(0, u"G3")->set_Value(System::ObjectExt::Box<double>(6.3));
workbook->GetCell(0, u"H4")->set_Value(System::ObjectExt::Box<int32_t>(3));
```

Nu, för att skriva en formel till cellen, kan du använda 
[**IChartDataCell::set_Formula()**](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.charts.i_chart_data_cell#a6806c6a40e025e6834c4c5f3af3cf692)-metoden:

*Obs*: [**IChartDataCell::set_Formula()**](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.charts.i_chart_data_cell#a6806c6a40e025e6834c4c5f3af3cf692)-metoden används för att ange A1‑stil cellreferenser. 

För att ange cellreferensen i R1C1‑stil kan du använda [**IChartDataCell::set_R1C1Formula()**](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.charts.i_chart_data_cell#a47f5825dd38d0dddb11ecc3a43d388c7)-metoden:

Sedan, om du läser värdena från cellerna B2 och C2, kommer de att beräknas:

``` cpp
auto value1 = cell1->get_Value(); // 7.8
auto value2 = cell2->get_Value(); // 2.1
```

## **Logiska konstanter**
Du kan använda logiska konstanter såsom *FALSE* och *TRUE* i cellformler:

## **Numeriska konstanter**
Tal kan användas i vanlig eller vetenskaplig notation för att skapa diagram‑kalkylbladsformler:

## **Strängkonstanter**
En sträng‑ (eller literal‑) konstant är ett specifikt värde som används exakt som det är och ändras inte. Strängkonstanter kan vara: datum, texter, tal osv.:

## **Felkonstanter**
Ibland är det inte möjligt att beräkna resultatet med formeln. I sådana fall visas en felkod i cellen i stället för värdet. Varje feltyp har en specifik kod:

- #DIV/0! – formeln försöker dividera med noll.
- #GETTING_DATA – kan visas i en cell medan dess värde fortfarande beräknas.
- #N/A – information saknas eller är inte tillgänglig. Orsaker kan vara: cellerna som används i formeln är tomma, ett extra blanksteg, felstavning osv.
- #NAME? – en viss cell eller annat formelobjekt kan inte hittas med sitt namn.
- #NULL! – kan uppstå när formeln innehåller ett fel, t.ex. (,) eller ett blanksteg i stället för ett kolon (:).
- #NUM! – det numeriska värdet i formeln är ogiltigt, för långt eller för kort osv.
- #REF! – ogiltig cellreferens.
- #VALUE! – oväntad värdetyp. Till exempel en sträng som tilldelats en numerisk cell.

## **Aritmetiska operatorer**
Du kan använda alla aritmetiska operatorer i diagramarbetsbladsformler:

|**Operator**|**Betydelse**|**Exempel**|
| :- | :- | :- |
|+ (plus)|Addition eller unärt plus|2 + 3|
|- (minus)|Subtraktion eller negation|2 - 3<br>-3|
|* (asterisk)|Multiplikation|2 * 3|
|/ (snedstreck)|Division|2 / 3|
|% (procent)|Procent|30%|
|^ (caret)|Exponentiering|2 ^ 3|

*Obs*: För att ändra utvärderingsordningen, omge den del av formeln som ska beräknas först med parenteser.

## **Jämförelseoperatorer**
Du kan jämföra cellers värden med jämförelseoperatorer. När två värden jämförs med dessa operatorer blir resultatet ett logiskt värde, antingen *TRUE* eller *FALSE*:

|**Operator**|**Betydelse**|**Betydelse**|
| :- | :- | :- |
|= (lika med)|Lika med|A2 = 3|
|<> (inte lika med)|Inte lika med|A2 <> 3|
|> (större än)|Större än|A2 > 3|
|>= (större än eller lika med)|Större än eller lika med|A2 >= 3|
|< (mindre än)|Mindre än|A2 < 3|
|<= (mindre än eller lika med)|Mindre än eller lika med|A2 <= 3|

## **A1‑stil cellreferenser**
**A1‑stil cellreferenser** används för arbetsblad där kolumnen har en bokstavsidentifierare (t.ex. "*A*") och raden har en numerisk identifierare (t.ex. "*1*"). A1‑stil cellreferenser kan användas på följande sätt:

|**Cellreferens**|**Exempel**| | |
| :- | :- | :- | :- |
| |Absolut|Relativ|Blandad|
|Cell|$A$2|A2|<p>A$2</p><p>$A2</p>|
|Rad|$2:$2|2:2|-|
|Kolumn|$A:$A|A:A|-|
|Område|$A$2:$C$4|A2:C4|<p>$A$2:C4</p><p>A$2:$C4</p>|

Här är ett exempel på hur man använder en A1‑stil cellreferens i en formel:

## **R1C1‑stil cellreferenser**
**R1C1‑stil cellreferenser** används för arbetsblad där både rad och kolumn har numeriska identifierare. R1C1‑stil cellreferenser kan användas på följande sätt:

|**Cellreferens**|**Exempel**| | |
| :- | :- | :- | :- |
| |Absolut|Relativ|Blandad|
|Cell|R2C3|R[2]C[3]|R2C[3]<br>R[2]C3|
|Rad|R2|R[2]|-|
|Kolumn|C3|C[3]|-|
|Område|R2C3:R5C7|R[2]C[3]:R[5]C[7]|R2C3:R[5]C[7]<br>R[2]C3:R5C[7]|

Här är ett exempel på hur man använder en R1C1‑stil cellreferens i en formel:

## **Fördefinierade funktioner**
Det finns fördefinierade funktioner som kan användas i formler för att förenkla deras implementering. Dessa funktioner kapslar in de mest använda operationerna, till exempel:

- ABS
- AVERAGE
- CEILING
- CHOOSE
- CONCAT
- CONCATENATE
- DATE (1900‑datumssystem)
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

Ja. Aspose.Slides stödjer externa arbetsböcker som en [chart's data source](https://reference.aspose.com/slides/sv/cpp/aspose.slides.charts/chartdatasourcetype/), vilket låter dig använda formler från en XLSX‑fil utanför presentationen.

**Kan diagram‑formler referera till blad i samma arbetsbok genom bladnamn?**

Ja. Formler följer den standardiserade Excel‑referensmodellen, så du kan referera till andra blad i samma arbetsbok eller en extern arbetsbok. För externa referenser, inkludera sökväg och arbetsboksnamn med Excel‑syntax.
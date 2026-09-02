---
title: Tillämpa diagramarbetsbladsformler i presentationer med JavaScript
linktitle: Arbetsbladsformler
type: docs
weight: 70
url: /sv/nodejs-java/chart-worksheet-formulas/
keywords:
- diagram kalkylblad
- diagramarbetsblad
- diagramformel
- arbetsbladsformel
- kalkylbladsformel
- diagramdatabok
- formelberäkning
- logisk konstant
- numerisk konstant
- strängkonstant
- felkonstant
- aritmetisk operator
- jämförelseoperator
- A1-stil
- R1C1-stil
- fördefinierad funktion
- PowerPoint
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Tillämpa Excel‑liknande formler i Aspose.Slides för Node.js via Java‑diagramarbetsblad, omberäkna värden och använd resultaten i PowerPoint‑diagram."
---
## **Översikt**

PowerPoint-diagram lagrar vanligtvis sina källdata i ett inbäddat arbetsblad. I Aspose.Slides för Node.js via Java kan du komma åt det arbetsbladet via diagramdatabokboken, skriva inmatningsvärden, tilldela formler till celler, beräkna stödda formler och använda de beräknade cellerna som diagramdata.

Denna artikel förklarar hela formelarbetsflödet: skapa ett diagram, fyll i dess arbetsblad, tilldela A1‑stil‑ eller R1C1‑stil‑formler, omberäkna dem, läs de beräknade värdena, anslut dessa celler till en diagramserie och spara presentationen. Den beskriver också den stödda formlsyntaxen, den inbyggda funktionsundersatsen, cachade värden, icke‑stödda formler och kalkylblads‑specifika fel.

## **Diagramarbetsblad och formler**

Ett diagramarbetsblad innehåller kategorier, serienamn och värden som används av ett diagram. I PowerPoint kan du inspektera arbetsbladet genom att öppna diagramdatoredigeraren:

![PowerPoint-diagram med sitt inbäddade arbetsblad öppet, visar kategori‑ och seriedata](chart-worksheet-formulas_1.png)

I Aspose.Slides exponeras arbetsbladet via klassen [ChartDataWorkbook](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chartdataworkbook/). Använd [ChartDataCell.setFormula](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chartdatacell/#setFormula-java.lang.String-) för A1‑stil‑formler och [ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chartdatacell/#setR1C1Formula-java.lang.String-) för R1C1‑stil‑formler. Efter att du har ändrat inmatningsceller eller formler, anropa [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--) för att omberäkna stödda formler och uppdatera motsvarande cellvärden.

En beräknad cell exponerar fortfarande sitt resultat via [ChartDataCell.getValue](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chartdatacell/#getValue--). Detta är viktigt när du behöver inspektera ett formelresultat i kod eller använda cellen som ett diagramdatapunkt.

## **Skapa ett diagram och beräkna arbetsbladsformler**

Följande exempel visar ett end‑to‑end‑arbetsflöde. Det skapar ett grupperat stapeldiagram, rensar exempeldata, skriver kvartalsintäkter och -kostnader, beräknar vinst med formler, läser resultaten, använder de beräknade cellerna som diagramvärden och sparar presentationen.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 350);
    const workbook = chart.getChartData().getChartDataWorkbook();
    const worksheetIndex = 0;

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    workbook.clear(worksheetIndex);

    const category1 = workbook.getCell(worksheetIndex, "A2", "Q1");
    const category2 = workbook.getCell(worksheetIndex, "A3", "Q2");
    const category3 = workbook.getCell(worksheetIndex, "A4", "Q3");

    workbook.getCell(worksheetIndex, "B1", "Revenue");
    workbook.getCell(worksheetIndex, "C1", "Expenses");
    workbook.getCell(worksheetIndex, "D1", "Profit");

    workbook.getCell(worksheetIndex, "B2").setValue(120.0);
    workbook.getCell(worksheetIndex, "C2").setValue(80.0);
    workbook.getCell(worksheetIndex, "B3").setValue(150.0);
    workbook.getCell(worksheetIndex, "C3").setValue(95.0);
    workbook.getCell(worksheetIndex, "B4").setValue(135.0);
    workbook.getCell(worksheetIndex, "C4").setValue(110.0);

    const profit1 = workbook.getCell(worksheetIndex, "D2");
    const profit2 = workbook.getCell(worksheetIndex, "D3");
    const profit3 = workbook.getCell(worksheetIndex, "D4");

    profit1.setFormula("B2-C2");
    profit2.setFormula("B3-C3");
    profit3.setFormula("B4-C4");

    workbook.calculateFormulas();

    const q1Profit = profit1.getValue(); // 40
    const q2Profit = profit2.getValue(); // 55
    const q3Profit = profit3.getValue(); // 25

    console.log("Q1 profit: " + q1Profit);
    console.log("Q2 profit: " + q2Profit);
    console.log("Q3 profit: " + q3Profit);

    chart.getChartData().getCategories().add(category1);
    chart.getChartData().getCategories().add(category2);
    chart.getChartData().getCategories().add(category3);

    const profitSeries = chart.getChartData().getSeries().add(workbook.getCell(worksheetIndex, "D1"), chart.getType());
    profitSeries.getDataPoints().addDataPointForBarSeries(profit1);
    profitSeries.getDataPoints().addDataPointForBarSeries(profit2);
    profitSeries.getDataPoints().addDataPointForBarSeries(profit3);
    profitSeries.getLabels().getDefaultDataLabelFormat().setShowValue(true);

    presentation.save("chart-formulas.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Diagramdatapunkterna refererar `D2:D4`, så diagrammet använder de beräknade värdena för vinst. Det finns inget separat diagram‑uppdateringsanrop i detta arbetsflöde: omberäkna arbetsboken först, sedan använd eller spara diagramdata som pekar på de beräknade cellerna.

## **Använd A1‑stil‑formler**

A1‑notation identifierar kolumner med bokstäver och rader med siffror. Tilldela A1‑stil‑uttryck via [ChartDataCell.setFormula](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chartdatacell/#setFormula-java.lang.String-).

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 500, 300);
    const workbook = chart.getChartData().getChartDataWorkbook();

    workbook.getCell(0, "C3").setValue(10);
    workbook.getCell(0, "F2").setValue(2);
    workbook.getCell(0, "G2").setValue(3);
    workbook.getCell(0, "H2").setValue(4);

    const cell = workbook.getCell(0, "A2");
    cell.setFormula("C3+SUM(F2:H2)");

    workbook.calculateFormulas();

    const value = cell.getValue(); // 19
} finally {
    presentation.dispose();
}
```

Vanliga A1‑referensformat är:

| Referens | Relativ | Absolut | Blandad |
|---|---|---|---|
| Cell | `A2` | `$A$2` | `A$2`, `$A2` |
| Rad | `2:2` | `$2:$2` | — |
| Kolumn | `A:A` | `$A:$A` | — |
| Intervall | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

Relativa referenser kan ändras när en formel flyttas eller kopieras av ett kalkylbladsprogram. Absoluta referenser håller båda koordinaterna fasta, medan blandade referenser fixerar endast en rad eller en kolumn.

## **Använd R1C1‑stil‑formler**

R1C1‑notation identifierar både rader och kolumner numeriskt. Relativa referenser använder avstånd i hakparenteser. Tilldela denna syntax via [ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chartdatacell/#setR1C1Formula-java.lang.String-).

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 500, 300);
    const workbook = chart.getChartData().getChartDataWorkbook();

    workbook.getCell(0, "B2").setValue(12);
    workbook.getCell(0, "C2").setValue(5);

    const cell = workbook.getCell(0, "D2");
    cell.setR1C1Formula("RC[-2]-RC[-1]");

    workbook.calculateFormulas();

    const value = cell.getValue(); // 7
} finally {
    presentation.dispose();
}
```

Vanliga R1C1‑referensformat är:

| Referens | Relativ | Absolut | Blandad |
|---|---|---|---|
| Cell | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| Rad | `R[2]` | `R2` | — |
| Kolumn | `C[3]` | `C3` | — |
| Intervall | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

Till exempel, i cell `D2` betyder `RC[-2]` cellen i samma rad två kolumner åt vänster (`B2`).

## **Formelkonstanter och operatorer**

Den inbyggda formelutvärderaren stöder logiska värden, numeriska literaler, strängar, kalkylblads‑felvärden, aritmetiska operatorer och jämförelseoperatorer.

### **Konstanter och litteraler**

| Typ | Exempel | Anmärkning |
|---|---|---|
| Logisk | `TRUE`, `FALSE` | Kan användas direkt i logiska uttryck som `A2=TRUE`. |
| Numerisk | `1`, `0.5`, `.3`, `1E-2` | Vanlig och vetenskaplig notation stöds. |
| Sträng | `"abc"`, `"2/3/2020 12:00"` | Textlitteraler omges av dubbla citattecken i formeln. |
| Felresultat | `#DIV/0!`, `#N/A`, `#REF!` | En giltig formel kan utvärderas till ett kalkylbladsfelvärde i stället för ett normalt resultat. |

Detta exempel använder flera konstanttyper:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 500, 300);
    const workbook = chart.getChartData().getChartDataWorkbook();

    workbook.getCell(0, "A2").setValue(false);
    workbook.getCell(0, "B2").setFormula("A2=TRUE");
    workbook.getCell(0, "C2").setFormula("1+0.5");
    workbook.getCell(0, "D2").setFormula(".3*1E-2");
    workbook.getCell(0, "E2").setFormula("\"abc\"");
    workbook.getCell(0, "F2").setFormula("2/0");

    workbook.calculateFormulas();

    const logicalValue = workbook.getCell(0, "B2").getValue(); // falskt
    const numericValue = workbook.getCell(0, "C2").getValue(); // 1.5
    const scientificValue = workbook.getCell(0, "D2").getValue(); // 0.003
    const stringValue = workbook.getCell(0, "E2").getValue(); // abc
    const errorValue = workbook.getCell(0, "F2").getValue(); // #DIV/0!
} finally {
    presentation.dispose();
}
```

### **Aritmetiska operatorer**

| Operator | Betydelse | Exempel |
|---|---|---|
| `+` | Addition eller unärt plustecken | `2+3` |
| `-` | Subtraktion eller negation | `2-3`, `-3` |
| `*` | Multiplikation | `2*3` |
| `/` | Division | `2/3` |
| `%` | Procent | `30%` |
| `^` | Upphöjning | `2^3` |

Använd parenteser för att göra utvärderingsordningen explicit, t.ex. `(A2+B2)*C2`.

### **Jämförelseoperatorer**

Jämförelseuttryck returnerar logiska värden.

| Operator | Betydelse | Exempel |
|---|---|---|
| `=` | Lika med | `A2=3` |
| `<>` | Inte lika med | `A2<>3` |
| `>` | Större än | `A2>3` |
| `>=` | Större än eller lika med | `A2>=3` |
| `<` | Mindre än | `A2<3` |
| `<=` | Mindre än eller lika med | `A2<=3` |

## **Stödda fördefinierade funktioner**

Aspose.Slides innehåller en inbyggd formelutvärderare för diagramarbetsblad, men den är inte en fullständig Excel‑beräkningsmotor. Den dokumenterade funktionsuppsättningen är begränsad till funktionerna nedan. Anta inte att en godtycklig Excel‑funktion kan omberäknas av [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--).

| Funktion | Syfte eller stödjande form | Exempel |
|---|---|---|
| `ABS` | Absolutvärde | `ABS(A2)` |
| `AVERAGE` | Medelvärde | `AVERAGE(B2:B5)` |
| `CEILING` | Runda upp till ett multipel | `CEILING(A2,5)` |
| `CHOOSE` | Välj ett värde efter index | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | Sammanfoga textvärden | `CONCAT(A2,B2)` |
| `CONCATENATE` | Sammanfoga textvärden | `CONCATENATE(A2," ",B2)` |
| `DATE` | Skapa ett datumvärde med 1900‑datumsystemet | `DATE(2026,8,19)` |
| `DAYS` | Returnera antalet dagar mellan datum | `DAYS(B2,A2)` |
| `FIND` | Hitta en textsträng i en annan | `FIND("-",A2)` |
| `FINDB` | Byte‑orienterad textsökning | `FINDB("a",A2)` |
| `IF` | Villkorligt resultat | `IF(A2>0,A2,0)` |
| `INDEX` | Referensform | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | Vektorform | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | Vektorform | `MATCH(A2,B2:B5,0)` |
| `MAX` | Största värde | `MAX(B2:B5)` |
| `SUM` | Summera värden | `SUM(B2:B5)` |
| `VLOOKUP` | Vertikal sökning | `VLOOKUP(A2,B2:D10,3,FALSE)` |

Begränsningarna i tabellen är betydande: `INDEX` är dokumenterad i referensform, medan `LOOKUP` och `MATCH` är dokumenterade i sina vektorformer. `DATE` använder 1900‑datumsystemet. Funktioner som inte listas bör betraktas som ej stödda av Aspose.Slides formelutvärderare om de inte är dokumenterade separat.

## **Omberäkning och cachade värden**

Kalkylbladsfiler lagrar vanligtvis både en formel och dess senast beräknade värde. Aspose.Slides kan därför läsa ett cachat värde från [ChartDataCell.getValue](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chartdatacell/#getValue--) när en presentation laddas och relevant diagramdata inte har ändrats.

Efter att du har ändrat inmatningsceller eller formler, förlita dig inte på ett gammalt cache‑resultat. Anropa [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--) innan du läser beräknade värden eller sparar diagramdata som beror på dem.

För formler utanför den stödda undersatsen kan Aspose.Slides misslyckas med att tolka formeln eller fastställa dess beroenden. Om arbetsboken har modifierats kan det tidigare cachade värdet inte längre anses tillförlitligt. I sådant fall kan läsning av en cell med osupporterad data kasta [CellUnsupportedDataException](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/cellunsupporteddataexception/).

Om ditt diagram beror på Excel‑funktioner som Aspose.Slides inte utvärderar, beräkna dessa formler med en kalkylbladsmotor som stödjer dem och skriv tillbaka de resulterande värdena till diagramarboken. Ersätt inte osupporterade formler med gissade värden.

## **Hantera formelfel**

Det finns två olika typer av problem att särskilja.

En formel kan vara giltig men producera ett kalkylbladsfel som `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!` eller `#VALUE!`. I detta fall är fel‑tokenen ett cellresultat och kan returneras via [ChartDataCell.getValue](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chartdatacell/#getValue--).

En formel kan även misslyckas vid parsning, referens, beroende eller på den stödda datanivån. Aspose.Slides tillhandahåller kalkylblads‑specifika undantag för dessa situationer: [CellInvalidFormulaException](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/cellcircularreferenceexception/) och [CellUnsupportedDataException](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/cellunsupporteddataexception/).

När formler kommer från mallar eller användarinmatning, fånga fel kring omberäkning och värdeåtkomst. Fel‑detaljerna identifierar det underliggande kalkylbladsproblemet:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 500, 300);
    const workbook = chart.getChartData().getChartDataWorkbook();
    const cell = workbook.getCell(0, "A2");
    cell.setFormula("SUM(B2:B5)");

    try {
        workbook.calculateFormulas();
        console.log(cell.getValue());
    } catch (error) {
        console.error("Formula processing error: " + error.message);
    }
} finally {
    presentation.dispose();
}
```

## **Praktiska begränsningar**

Formelstödet i diagramarbetsblad är avsett för en definierad undersats av kalkylbladsberäkningar, inte för full Excel‑kompatibilitet. Ha dessa begränsningar i åtanke när du designar ett rapporteringsarbetsflöde:

- Använd endast de dokumenterade konstanterna, operatorerna, referenserna och funktionerna när du vill att Aspose.Slides ska omberäkna formler.
- Ombereäkna efter att du har ändrat celler som formelresultaten beror på.
- Betrakta cachade värden från laddade presentationer som ögonblicksbilder, inte som ersättning för omberäkning efter redigering.
- Testa formler från befintliga mallar innan du förlitar dig på deras beräknade värden, särskilt när de använder funktioner utanför den dokumenterade listan.
- För formler som kräver en fullständig kalkylbladsberäkningsmotor, beräkna dem externt och uppdatera sedan diagramarboken med de resulterande värdena.

## **FAQ**

**Vad är skillnaden mellan [ChartDataCell.setFormula](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chartdatacell/#setFormula-java.lang.String-) och [ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chartdatacell/#setR1C1Formula-java.lang.String-)?**

[ChartDataCell.setFormula](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chartdatacell/#setFormula-java.lang.String-) lagrar ett A1‑stil‑uttryck såsom `B2-C2`. [ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chartdatacell/#setR1C1Formula-java.lang.String-) lagrar ett R1C1‑stil‑uttryck såsom `RC[-2]-RC[-1]`. Använd den notation som bäst motsvarar hur du genererar eller kopierar formler.

**Behöver jag läsa själva cellen eller dess värde efter beräkning?**

[ChartDataWorkbook.getCell](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chartdataworkbook/#getCell-int-java.lang.String-) returnerar en [ChartDataCell](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chartdatacell/). För att få det beräknade resultatet, anropa den cellens [ChartDataCell.getValue](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chartdatacell/#getValue--) efter omberäkning.

**När ska jag anropa [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--)?**

Anropa [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--) efter att du har ändrat inmatningsvärden eller formler och innan du är beroende av de beräknade resultaten. Detta uppdaterar värdena för formler som den inbyggda utvärderaren stöder.

**Stöder Aspose.Slides varje Excel‑funktion?**

Nej. Den inbyggda utvärderaren stödjer en dokumenterad undersats av funktioner. Funktioner utanför den undersatsen bör inte antas kunna omberäknas korrekt. Om full Excel‑formelkompatibilitet krävs, utför beräkningen med en lämplig kalkylbladsmotor och skriv de slutgiltiga värdena till diagramarboken.

**Vad händer om en laddad presentation innehåller en osupporterad formel?**

Om diagramdata inte har förändrats kan arbetsboken fortfarande innehålla ett tidigare beräknat cachat värde. Efter att relaterad data har modifierats kan det cachade värdet vara ogiltigt. Att komma åt en cell vars formel inte kan hanteras kan kasta [CellUnsupportedDataException](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/cellunsupporteddataexception/).

**Är formelfelvärden samma sak som undantag?**

Nej. Ett resultat såsom `#DIV/0!` är ett kalkylbladsvärde som produceras av en giltig beräkning. Undantag som [CellInvalidFormulaException](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/cellinvalidformulaexception/) eller [CellCircularReferenceException](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/cellcircularreferenceexception/) indikerar att formeln inte kan bearbetas normalt.

**Uppdateras ett diagram automatiskt när en formelcell ändras?**

En diagramserie kan referera arbetsbokens celler. Ombereäkna arbetsboken först, sedan spara eller rendera presentationen. Om diagramdatapunkterna refererar de beräknade cellerna använder diagrammet de uppdaterade cellvärdena; inget separat diagram‑uppdateringsmetod krävs för detta arbetsflöde.

**Kan diagram använda en extern Excel‑arbetsbok?**

Ja, diagramdata kan konfigureras att använda en extern arbetsbok via diagramdatans API. Däremot gäller arbetsflödet för formelberäkning som beskrivs i denna artikel endast diagramarboken och den formelundersats som Aspose.Slides utvärderar. Anta inte att [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--) ger full omberäkning av godtyckliga formler i en extern XLSX‑fil.

**Kan jag använda formler som refererar ett annat arbetsblad eller en annan arbetsbok?**

Excel‑liknande referenser kan finnas i diagramarboken, men formelutvärderingen är begränsad av den stödda parsern och funktionsuppsättningen. Om ett kors‑ark‑ eller externt referens är väsentligt, verifiera exakt formel med den Aspose.Slides‑version du använder. För arbetsflöden som kräver bred Excel‑referenskompatibilitet, beräkna arbetsboken externt och skriv tillbaka de lösta värdena till diagramdata.

**Ska formelsträngar börja med `=`?**

Aspose.Slides‑API‑exemplen tilldelar uttryck såsom `B2-C2` eller `SUM(B2:B5)` utan ett inledande `=`. Att använda den formen håller genererade formler i enlighet med de dokumenterade API‑exemplen.
---
title: "Applicera diagramkalkylbladsformler i presentationer med JavaScript"
linktitle: "Kalkylbladsformler"
type: docs
weight: 70
url: /sv/nodejs-java/chart-worksheet-formulas/
keywords:
- diagramkalkylblad
- diagramarbetsblad
- diagramformel
- arbetsbladsformel
- kalkylbladsformel
- diagramdatabok
- formelberäkning
- föredragen kultur
- kultur‑specifik formel
- DBCS
- logisk konstant
- numerisk konstant
- strängkonstant
- felkonstant
- aritmetisk operator
- jämförelseoperator
- A1‑stil
- R1C1‑stil
- fördefinierad funktion
- PowerPoint
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Applicera Excel‑liknande formler i Aspose.Slides för Node.js via Java‑diagramarbetsblad, beräkna om värden och använd resultaten i PowerPoint‑diagram."
---
## **Översikt**

PowerPoint-diagram lagrar vanligtvis sina källdata i ett inbäddat kalkylblad. I Aspose.Slides för Node.js via Java kan du komma åt det kalkylbladet via diagramdataboken, skriva in värden, tilldela formler till celler, beräkna stödjade formler och använda de beräknade cellerna som diagramdata.

Denna artikel förklarar hela formelarbetsflödet: skapa ett diagram, fylla i dess kalkylblad, tilldela A1‑stil‑ eller R1C1‑stil‑formler, beräkna om dem, läsa de beräknade värdena, koppla dessa celler till en diagramserie och spara presentationen. Den beskriver också den stödda formelsyntaxen, den inbyggda funktionsuppsättningen, cachade värden, ej stödda formler och kalkylblads‑specifika fel.

## **Diagramkalkylblad och formler**

Ett diagramkalkylblad innehåller de kategorier, seriernamn och värden som används av ett diagram. I PowerPoint kan du inspektera kalkylbladet genom att öppna diagramdataredigeraren:

![PowerPoint-diagram med sitt inbäddade kalkylblad öppet, som visar kategori‑ och seriedata](chart-worksheet-formulas_1.png)

I Aspose.Slides exponeras kalkylbladet via klassen [ChartDataWorkbook](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chartdataworkbook/). Använd [ChartDataCell.setFormula](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chartdatacell/#setFormula-java.lang.String-) för A1‑stil‑formler och [ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chartdatacell/#setR1C1Formula-java.lang.String-) för R1C1‑stil‑formler. Efter att ha ändrat inmatningsceller eller formler, anropa [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--) för att beräkna om stödjade formler och uppdatera motsvarande cellvärden.

En beräknad cell exponeras fortfarande via [ChartDataCell.getValue](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chartdatacell/#getValue--). Detta är viktigt när du behöver inspektera ett formelresultat i kod eller använda cellen som ett diagramdatapunkt.

## **Skapa ett diagram och beräkna kalkylbladsformler**

Följande exempel demonstrerar ett komplett arbetsflöde. Det skapar ett staplat kolumndiagram, rensar exempeldata, skriver in kvartalsvisa intäkts‑ och kostnadsvärden, beräknar vinst med formler, läser resultaten, använder de beräknade cellerna som diagramvärden och sparar presentationen.

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

Diagramdatapunkterna refererar `D2:D4`, så diagrammet använder de beräknade vinstvärdena. Det finns inget separat diagram‑uppdateringsanrop i detta arbetsflöde: beräkna först kalkylboken, använd eller spara sedan diagramdata som pekar på de beräknade cellerna.

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

Vanliga A1‑referensformer är:

| Referens | Relativ | Absolut | Blandad |
|---|---|---|---|
| Cell | `A2` | `$A$2` | `A$2`, `$A2` |
| Rad | `2:2` | `$2:$2` | — |
| Kolumn | `A:A` | `$A:$A` | — |
| Område | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

Relativa referenser kan förändras när en formel flyttas eller kopieras i ett kalkylprogram. Absoluta referenser håller båda koordinaterna fasta, medan blandade referenser fixerar endast en rad eller en kolumn.

## **Använd R1C1‑stil‑formler**

R1C1‑notation identifierar både rader och kolumner numeriskt. Relativa referenser använder förskjutningar i hakparenteser. Tilldela denna syntax via [ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chartdatacell/#setR1C1Formula-java.lang.String-).

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

Vanliga R1C1‑referensformer är:

| Referens | Relativ | Absolut | Blandad |
|---|---|---|---|
| Cell | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| Rad | `R[2]` | `R2` | — |
| Kolumn | `C[3]` | `C3` | — |
| Område | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

Till exempel, i cell `D2` betyder `RC[-2]` cellen i samma rad två kolumner till vänster (`B2`).

## **Formelkodkonstanter och operatorer**

Den inbyggda formelutvärderaren stödjer logiska värden, numeriska litteraler, strängar, kalkylblads‑felvärden, aritmetiska operatorer och jämförelsesoperatorer.

### **Konstanter och litteraler**

| Typ | Exempel | Anmärkningar |
|---|---|---|
| Logisk | `TRUE`, `FALSE` | Kan användas direkt i logiska uttryck såsom `A2=TRUE`. |
| Numerisk | `1`, `0.5`, `.3`, `1E-2` | Vanlig och vetenskaplig notation stödjs. |
| Sträng | `"abc"`, `"2/3/2020 12:00"` | Textlitteraler omsluts av dubbla citattecken i formeln. |
| Felresultat | `#DIV/0!`, `#N/A`, `#REF!` | En giltig formel kan utvärderas till ett kalkylblads‑felvärde i stället för ett normalt resultat. |

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
| `+` | Addition eller positivt unärt | `2+3` |
| `-` | Subtraktion eller negation | `2-3`, `-3` |
| `*` | Multiplikation | `2*3` |
| `/` | Division | `2/3` |
| `%` | Procent | `30%` |
| `^` | Upphöjning | `2^3` |

Använd parenteser för att göra utvärderingsordningen explicit, till exempel `(A2+B2)*C2`.

### **Jämförelsesoperatorer**

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

Aspose.Slides innehåller en inbyggd formelutvärderare för diagramkalkylblad, men den är inte en komplett Excel‑beräkningsmotor. Den dokumenterade funktionsuppsättningen är begränsad till funktionerna nedan. Anta inte att en godtycklig Excel‑funktion kan beräknas av [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--).

| Funktion | Syfte eller stödjad form | Exempel |
|---|---|---|
| `ABS` | Absolutvärde | `ABS(A2)` |
| `AVERAGE` | Aritmetiskt medelvärde | `AVERAGE(B2:B5)` |
| `CEILING` | Runda upp ett tal till en multipel | `CEILING(A2,5)` |
| `CHOOSE` | Välj ett värde efter index | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | Sammanfoga textvärden | `CONCAT(A2,B2)` |
| `CONCATENATE` | Sammanfoga textvärden | `CONCATENATE(A2," ",B2)` |
| `DATE` | Skapa ett datumvärde med 1900‑datumsystemet | `DATE(2026,8,19)` |
| `DAYS` | Returnera antal dagar mellan datum | `DAYS(B2,A2)` |
| `FIND` | Hitta en textsträng i en annan | `FIND("-",A2)` |
| `FINDB` | Byte‑orienterad textsökning | `FINDB("a",A2)` |
| `IF` | Villkorligt resultat | `IF(A2>0,A2,0)` |
| `INDEX` | Referensform | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | Vektorform | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | Vektorform | `MATCH(A2,B2:B5,0)` |
| `MAX` | Maximumvärde | `MAX(B2:B5)` |
| `SUM` | Summera värden | `SUM(B2:B5)` |
| `VLOOKUP` | Vertikal sökning | `VLOOKUP(A2,B2:D10,3,FALSE)` |

Begränsningarna i tabellen är betydande: `INDEX` dokumenteras i referensform, medan `LOOKUP` och `MATCH` dokumenteras i sina vektorformer. `DATE` använder 1900‑datumsystemet. Funktioner och egenskaper som inte listas här bör betraktas som ej stödda av Aspose.Slides‑formelutvärderaren, såvida de inte dokumenteras separat.

## **Beräkna formler med föredragen kultur**

Vissa kalkylbladsfunktioner tolkar text enligt kultur‑specifika regler. Detta är särskilt viktigt för funktioner avsedda för språk som använder dubbelbyte‑teckenuppsättningar (DBCS). För att beräkna sådana formler korrekt, skapa ett [LoadOptions](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/loadoptions/), sätt den föredragna kulturen med [SpreadsheetOptions.setPreferredCulture](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/spreadsheetoptions/#setPreferredCulture), tilldela kalkylbladsalternativen via [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/loadoptions/#setSpreadsheetOptions) och ladda sedan presentationen.

Följande exempel väljer den japanska kulturen, öppnar en presentation med de konfigurerade inläsningsalternativen och anropar [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--) för varje diagramkalkylbok:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const japaneseCulture = java.newInstanceSync("java.util.Locale", "ja", "JP");

const spreadsheetOptions = new aspose.slides.SpreadsheetOptions();
spreadsheetOptions.setPreferredCulture(japaneseCulture);

const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setSpreadsheetOptions(spreadsheetOptions);

const presentation = new aspose.slides.Presentation("presentation.pptx", loadOptions);
try {
    const slides = presentation.getSlides();
    for (let slideIndex = 0; slideIndex < slides.size(); slideIndex++) {
        const shapes = slides.get_Item(slideIndex).getShapes();
        for (let shapeIndex = 0; shapeIndex < shapes.size(); shapeIndex++) {
            const shape = shapes.get_Item(shapeIndex);
            if (java.instanceOf(shape, "com.aspose.slides.IChart")) {
                shape.getChartData().getChartDataWorkbook().calculateFormulas();
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Den föredragna kulturen är en del av konfigurationen för presentationsladdning, så ange den innan du skapar [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/)-instansen. Använd den kultur som diagramkalkylbokens formler förväntar sig; till exempel `ja-JP` för formler som ska följa japanska DBCS‑beräkningsregler.

## **Omberäkning och cachade värden**

Kalkylbladsfiler lagrar vanligtvis både en formel och dess senast beräknade värde. Aspose.Slides kan därför läsa ett cachat värde från [ChartDataCell.getValue](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chartdatacell/#getValue--) när en presentation laddas och den relevanta diagramdatan inte har ändrats.

Efter att ha ändrat inmatningsceller eller formler, förlita dig inte på ett gammalt cached‑resultat. Anropa [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--) innan du läser beräknade värden eller sparar diagramdata som beror på dem.

För formler utanför den stödda delmängden kan Aspose.Slides misslyckas med att parsa formeln eller fastställa dess beroenden. Om kalkylboken har ändrats kan det tidigare cachade värdet inte längre anses pålitligt. I sådana fall kan läsning av en cells värde med osupporterad data utlösa [CellUnsupportedDataException](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/cellunsupporteddataexception/).

Om ditt diagram är beroende av Excel‑funktioner som Aspose.Slides inte utvärderar, beräkna dessa formler med en kalkylblads‑motor som stödjer dem och skriv tillbaka de resulterande värdena till diagramkalkylboken. Ersätt inte osupporterade formler med gissade värden.

## **Hantera formelfel**

Det finns två olika typer av problem att skilja på.

En formel kan vara giltig men producera ett kalkylblads‑felresultat såsom `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!` eller `#VALUE!`. I så fall är fel‑tokenen ett cellresultat och kan returneras via [ChartDataCell.getValue](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chartdatacell/#getValue--).

En formel kan också misslyckas vid parsning, referens, beroende eller på stödjande‑databasisnivå. Aspose.Slides tillhandahåller kalkylblads‑specifika undantag för dessa fall: [CellInvalidFormulaException](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/cellcircularreferenceexception/) och [CellUnsupportedDataException](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/cellunsupporteddataexception/).

När formler kommer från mallar eller användarinmatning, fånga fel kring omberäkning och värdeåtkomst. Feldetaljerna identifierar det underliggande kalkylbladsproblemet:

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

Formelstödet i diagramkalkylblad är avsett för en definierad delmängd av kalkylbladsberäkningar, inte för full Excel‑kompatibilitet. Ha dessa begränsningar i åtanke när du designar ett rapporteringsarbetsflöde:

- Använd endast de dokumenterade konstanterna, operatorerna, referenserna och funktionerna när du vill att Aspose.Slides ska beräkna formler.
- Omberäkna efter att ha ändrat celler som formelresultat beror på.
- Behandla cachade värden från inlästa presentationer som snapshots, inte som ersättning för omberäkning efter redigering.
- Testa formler från befintliga mallar innan du förlitar dig på deras beräknade värden, särskilt när de använder funktioner utanför den dokumenterade listan.
- För formler som kräver en fullständig kalkylblads‑beräkningsmotor, beräkna dem externt och uppdatera sedan diagramkalkylboken med de resulterande värdena.

## **FAQ**

**Vad är skillnaden mellan [ChartDataCell.setFormula](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chartdatacell/#setFormula-java.lang.String-) och [ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chartdatacell/#setR1C1Formula-java.lang.String-)?**

[ChartDataCell.setFormula](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chartdatacell/#setFormula-java.lang.String-) lagrar ett A1‑stil‑uttryck såsom `B2-C2`. [ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chartdatacell/#setR1C1Formula-java.lang.String-) lagrar ett R1C1‑stil‑uttryck såsom `RC[-2]-RC[-1]`. Använd den notation som bäst matchar hur du genererar eller kopierar formler.

**Behöver jag läsa själva cellen eller dess värde efter beräkning?**

[ChartDataWorkbook.getCell](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chartdataworkbook/#getCell-int-java.lang.String-) returnerar ett [ChartDataCell](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chartdatacell/). För att hämta det beräknade resultatet, anropa den cellens [ChartDataCell.getValue](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chartdatacell/#getValue--)‑metod efter omberäkning.

**När ska jag anropa [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--)?**

Anropa [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--) efter att ha ändrat inmatningsvärden eller formler och innan du är beroende av de beräknade resultaten. Detta uppdaterar värdena för de formler som den inbyggda utvärderaren stödjer.

**Stöder Aspose.Slides varje Excel‑funktion?**

Nej. Den inbyggda utvärderaren stödjer en dokumenterad delmängd av funktioner. Funktioner utanför den delmängden bör inte antas beräknas korrekt. Om full Excel‑formelkompatibilitet krävs, utför beräkningen med en lämplig kalkylblads‑motor och skriv de slutgiltiga värdena till diagramkalkylboken.

**Vad händer om en inläst presentation innehåller en osupporterad formel?**

Om diagramdatan inte har ändrats kan kalkylboken fortfarande innehålla ett tidigare beräknat cachat värde. Efter att relaterad data har modifierats kan det cachade värdet vara ogiltigt. Åtkomst till en cell vars formel inte kan hanteras kan utlösa [CellUnsupportedDataException](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/cellunsupporteddataexception/).

**Är formelfelvärden desamma som undantag?**

Nej. Ett resultat som `#DIV/0!` är ett kalkylblads‑värde skapat av en giltig beräkning. Undantag som [CellInvalidFormulaException](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/cellinvalidformulaexception/) eller [CellCircularReferenceException](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/cellcircularreferenceexception/) indikerar att formeln inte kan bearbetas normalt.

**Uppdateras ett diagram automatiskt när en formelcell förändras?**

En diagramserie kan referera kalkylblads­celler. Beräkna först kalkylboken, spara eller rendera sedan presentationen. Om diagramdatapunkterna refererar de beräknade cellerna använder diagrammet de uppdaterade värdena; inget separat diagram‑uppdateringsmetod behövs för detta arbetsflöde.

**Kan diagram använda ett externt Excel‑kalkylblad?**

Ja, diagramdata kan konfigureras att använda ett externt kalkylblad via diagram‑data‑API:t. Däremot avser arbetsflödet för formelberäkning som beskrivs i denna artikel diagramkalkylboken och formeldelmängden som utvärderas av Aspose.Slides. Anta inte att [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--) ger fullständig omberäkning av godtyckliga formler i en extern XLSX‑fil.

**Kan jag använda formler som refererar ett annat kalkylblad eller arbetsbok?**

Excel‑stil‑referenser kan finnas i diagramkalkylböcker, men formelutvärderingen är begränsad av den stödda parsern och funktionsuppsättningen. Om en kors‑blad‑ eller extern referens är väsentlig, verifiera att den exakta formeln fungerar med din mål‑version av Aspose.Slides. För arbetsflöden som kräver bred Excel‑referens‑kompatibilitet, beräkna arbetsboken externt och skriv tillbaka de lösta värdena till diagramdatan.

**Ska formelsträngar börja med `=`?**

Aspose.Slides‑API‑exemplen tilldelar uttryck såsom `B2-C2` eller `SUM(B2:B5)` utan inledande `=`. Att använda den formen håller genererade formler i linje med de dokumenterade API‑exemplen.
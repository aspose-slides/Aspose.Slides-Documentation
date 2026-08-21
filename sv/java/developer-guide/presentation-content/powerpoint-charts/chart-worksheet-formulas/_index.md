---
title: Använd diagramkalkylbladsformler i presentationer i Java
linktitle: Kalkylbladsformler
type: docs
weight: 70
url: /sv/java/chart-worksheet-formulas/
keywords:
- diagramkalkylblad
- diagramarbetsblad
- diagramformel
- arbetsbladsformel
- kalkylbladsformel
- diagramdataarbetsbok
- formelberakning
- foretrad kultur
- kulturspecifik formel
- DBCS
- logisk konstant
- numerisk konstant
- strangkonstant
- felkonstant
- aritmetisk operator
- jamforrelsoperator
- A1-stil
- R1C1-stil
- fordefinierad funktion
- PowerPoint
- presentation
- Java
- Aspose.Slides
description: "Anvand Excel-liknande formler i Aspose.Slides for Java diagramarbetsblad, berakna om varlden och anvand resultaten i PowerPoint-diagram."
---
## **Översikt**

PowerPoint-diagram lagrar vanligtvis sina källdata i ett inbäddat kalkylblad. I Aspose.Slides för Java kan du komma åt det kalkylbladet via diagramdataarbetsboken, skriva inmatningsvärden, tilldela formler till celler, beräkna stödda formler och använda de beräknade cellerna som diagramdata.

Denna artikel förklarar den kompletta formelarbetsflödet: skapa ett diagram, fylla i dess kalkylblad, tilldela A1‑stil‑ eller R1C1‑stil‑formler, omberäkna dem, läsa de beräknade värdena, koppla dessa celler till en diagramserie och spara presentationen. Den beskriver också den stödda formlsyntaxen, den inbyggda funktionsdelmängden, cachade värden, ej‑stödda formler och kalkylblads‑specifika fel.

## **Diagramkalkylblad och formler**

Ett diagramkalkylblad innehåller kategorierna, seriernas namn och värden som används av ett diagram. I PowerPoint kan du inspektera kalkylbladet genom att öppna diagramdataredigeraren:

![PowerPoint‑diagram med sitt inbäddade kalkylblad öppet, som visar kategori‑ och seriedata](chart-worksheet-formulas_1.png)

I Aspose.Slides exponeras kalkylbladet via gränssnittet [IChartDataWorkbook](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ichartdataworkbook/) . Använd [IChartDataCell.setFormula](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-) för A1‑stil‑formler och [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-) för R1C1‑stil‑formler. Efter att du har ändrat inmatningsceller eller formler, anropa [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) för att beräkna stödda formler och uppdatera de motsvarande cellvärdena.

En beräknad cell exponerar fortfarande sitt resultat via [IChartDataCell.getValue](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ichartdatacell/#getValue--) . Detta är viktigt när du behöver inspektera ett formelresultat i kod eller använda cellen som ett diagramdatapunkt.

## **Skapa ett diagram och beräkna kalkylbladsformler**

Följande exempel visar ett komplett arbetsflöde. Det skapar ett grupperat stapeldiagram, rensar exempeldata, skriver kvartalsintäkter och utgiftssiffror, beräknar vinst med formler, läser resultaten, använder de beräknade cellerna som diagramvärden och sparar presentationen.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 350);
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    int worksheetIndex = 0;

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    workbook.clear(worksheetIndex);

    IChartDataCell category1 = workbook.getCell(worksheetIndex, "A2", "Q1");
    IChartDataCell category2 = workbook.getCell(worksheetIndex, "A3", "Q2");
    IChartDataCell category3 = workbook.getCell(worksheetIndex, "A4", "Q3");

    workbook.getCell(worksheetIndex, "B1", "Revenue");
    workbook.getCell(worksheetIndex, "C1", "Expenses");
    workbook.getCell(worksheetIndex, "D1", "Profit");

    workbook.getCell(worksheetIndex, "B2").setValue(120.0);
    workbook.getCell(worksheetIndex, "C2").setValue(80.0);
    workbook.getCell(worksheetIndex, "B3").setValue(150.0);
    workbook.getCell(worksheetIndex, "C3").setValue(95.0);
    workbook.getCell(worksheetIndex, "B4").setValue(135.0);
    workbook.getCell(worksheetIndex, "C4").setValue(110.0);

    IChartDataCell profit1 = workbook.getCell(worksheetIndex, "D2");
    IChartDataCell profit2 = workbook.getCell(worksheetIndex, "D3");
    IChartDataCell profit3 = workbook.getCell(worksheetIndex, "D4");

    profit1.setFormula("B2-C2");
    profit2.setFormula("B3-C3");
    profit3.setFormula("B4-C4");

    workbook.calculateFormulas();

    double q1Profit = ((Number) profit1.getValue()).doubleValue(); // 40
    double q2Profit = ((Number) profit2.getValue()).doubleValue(); // 55
    double q3Profit = ((Number) profit3.getValue()).doubleValue(); // 25

    System.out.println("Q1 profit: " + q1Profit);
    System.out.println("Q2 profit: " + q2Profit);
    System.out.println("Q3 profit: " + q3Profit);

    chart.getChartData().getCategories().add(category1);
    chart.getChartData().getCategories().add(category2);
    chart.getChartData().getCategories().add(category3);

    IChartSeries profitSeries = chart.getChartData().getSeries().add(workbook.getCell(worksheetIndex, "D1"), chart.getType());
    profitSeries.getDataPoints().addDataPointForBarSeries(profit1);
    profitSeries.getDataPoints().addDataPointForBarSeries(profit2);
    profitSeries.getDataPoints().addDataPointForBarSeries(profit3);
    profitSeries.getLabels().getDefaultDataLabelFormat().setShowValue(true);

    presentation.save("chart-formulas.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Diagramdatapunkterna refererar till `D2:D4`, så diagrammet använder de beräknade vinstvärdena. Det finns inget separat diagramuppdateringsanrop i detta arbetsflöde: beräkna arbetsboken först, sedan använd eller spara diagramdata som pekar på de beräknade cellerna.

## **Använd A1‑stil‑formler**

A1‑notation identifierar kolumner med bokstäver och rader med siffror. Tilldela A1‑stil‑uttryck via [IChartDataCell.setFormula](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-).

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300);
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    workbook.getCell(0, "C3").setValue(10);
    workbook.getCell(0, "F2").setValue(2);
    workbook.getCell(0, "G2").setValue(3);
    workbook.getCell(0, "H2").setValue(4);

    IChartDataCell cell = workbook.getCell(0, "A2");
    cell.setFormula("C3+SUM(F2:H2)");

    workbook.calculateFormulas();

    Object value = cell.getValue(); // 19
} finally {
    presentation.dispose();
}
```

Vanliga A1‑referensformer är:

| Referens | Relativ | Absolut | Blandad |
|---|---|---|---|
| Cell | `A2` | `$A$2` | `A$2`, `$A2` |
| Row | `2:2` | `$2:$2` | — |
| Column | `A:A` | `$A:$A` | — |
| Range | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

Relativa referenser kan förändras när en formel flyttas eller kopieras av ett kalkylbladsprogram. Absoluta referenser behåller båda koordinaterna fasta, medan blandade referenser fixerar endast en rad eller en kolumn.

## **Använd R1C1‑stil‑formler**

R1C1‑notation identifierar både rader och kolumner numeriskt. Relativa referenser använder förskjutningar i hakparenteser. Tilldela denna syntax via [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-).

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300);
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    workbook.getCell(0, "B2").setValue(12);
    workbook.getCell(0, "C2").setValue(5);

    IChartDataCell cell = workbook.getCell(0, "D2");
    cell.setR1C1Formula("RC[-2]-RC[-1]");

    workbook.calculateFormulas();

    Object value = cell.getValue(); // 7
} finally {
    presentation.dispose();
}
```

| Referens | Relativ | Absolut | Blandad |
|---|---|---|---|
| Cell | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| Row | `R[2]` | `R2` | — |
| Column | `C[3]` | `C3` | — |
| Range | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

Till exempel, i cell `D2` betyder `RC[-2]` cellen i samma rad två kolumner åt vänster (`B2`).

## **Formelkonstanter och operatorer**

Den inbyggda formelutvärderaren stödjer logiska värden, numeriska litteraler, strängar, kalkylbladsfelvärden, aritmetiska operatorer och jämförelsoperatorer.

### **Konstanter och litteraler**

| Typ | Exempel | Anmärkningar |
|---|---|---|
| Logisk | `TRUE`, `FALSE` | Kan användas direkt i logiska uttryck såsom `A2=TRUE`. |
| Numerisk | `1`, `0.5`, `.3`, `1E-2` | Vanlig och vetenskaplig notation stöds. |
| Sträng | `"abc"`, `"2/3/2020 12:00"` | Textlitteraler omsluts av dubbla citationstecken i formeln. |
| Felresultat | `#DIV/0!`, `#N/A`, `#REF!` | En giltig formel kan utvärderas till ett kalkylbladsfelvärde istället för ett normalt resultat. |

Detta exempel använder flera konstanttyper:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300);
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    workbook.getCell(0, "A2").setValue(false);
    workbook.getCell(0, "B2").setFormula("A2=TRUE");
    workbook.getCell(0, "C2").setFormula("1+0.5");
    workbook.getCell(0, "D2").setFormula(".3*1E-2");
    workbook.getCell(0, "E2").setFormula("\"abc\"");
    workbook.getCell(0, "F2").setFormula("2/0");

    workbook.calculateFormulas();

    Object logicalValue = workbook.getCell(0, "B2").getValue(); // falskt
    Object numericValue = workbook.getCell(0, "C2").getValue(); // 1.5
    Object scientificValue = workbook.getCell(0, "D2").getValue(); // 0.003
    Object stringValue = workbook.getCell(0, "E2").getValue(); // abc
    Object errorValue = workbook.getCell(0, "F2").getValue(); // #DIV/0!
} finally {
    presentation.dispose();
}
```

### **Aritmetiska operatorer**

| Operator | Betydelse | Exempel |
|---|---|---|
| `+` | Addition eller unär plus | `2+3` |
| `-` | Subtraktion eller negation | `2-3`, `-3` |
| `*` | Multiplikation | `2*3` |
| `/` | Division | `2/3` |
| `%` | Procent | `30%` |
| `^` | Exponentiering | `2^3` |

Använd parenteser för att göra evalueringsordningen explicit, till exempel `(A2+B2)*C2`.

### **Jämförelseoperatorer**

| Operator | Betydelse | Exempel |
|---|---|---|
| `=` | Lika med | `A2=3` |
| `<>` | Inte lika med | `A2<>3` |
| `>` | Större än | `A2>3` |
| `>=` | Större än eller lika med | `A2>=3` |
| `<` | Mindre än | `A2<3` |
| `<=` | Mindre än eller lika med | `A2<=3` |

## **Stödda fördefinierade funktioner**

Aspose.Slides innehåller en inbyggd formelutvärderare för diagramkalkylblad, men det är inte en komplett Excel‑beräkningsmotor. Den dokumenterade funktionsuppsättningen är begränsad till funktionerna nedan. Anta inte att en godtycklig Excel‑funktion kan omberäknas av [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ichartdataworkbook/#calculateFormulas--).

| Funktion | Syfte eller stödd form | Exempel |
|---|---|---|
| `ABS` | Absolutvärde | `ABS(A2)` |
| `AVERAGE` | Aritmetiskt medelvärde | `AVERAGE(B2:B5)` |
| `CEILING` | Avrunda ett tal uppåt till en multipel | `CEILING(A2,5)` |
| `CHOOSE` | Välj ett värde efter index | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | Kombinera textvärden | `CONCAT(A2,B2)` |
| `CONCATENATE` | Kombinera textvärden | `CONCATENATE(A2," ",B2)` |
| `DATE` | Skapa ett datumvärde med 1900‑datumssystemet | `DATE(2026,8,19)` |
| `DAYS` | Returnera antalet dagar mellan datum | `DAYS(B2,A2)` |
| `FIND` | Hitta en textsträng i en annan | `FIND("-",A2)` |
| `FINDB` | Byte‑orienterad textsökning | `FINDB("a",A2)` |
| `IF` | Villkorligt resultat | `IF(A2>0,A2,0)` |
| `INDEX` | Referensform | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | Vektorform | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | Vektorform | `MATCH(A2,B2:B5,0)` |
| `MAX` | Maximalt värde | `MAX(B2:B5)` |
| `SUM` | Summera värden | `SUM(B2:B5)` |
| `VLOOKUP` | Vertikal uppslagning | `VLOOKUP(A2,B2:D10,3,FALSE)` |

Begränsningarna i tabellen är betydande: `INDEX` är dokumenterad i referensform, medan `LOOKUP` och `MATCH` är dokumenterade i sina vektorformer. `DATE` använder 1900‑datumssystemet. Funktioner och egenskaper som inte listas här bör betraktas som ej stödda av Aspose.Slides formelutvärderare om de inte är dokumenterade separat.

## **Beräkna formler med föredragen kultur**

Några diagramarbetsboksfunktioner tolkar text enligt kulturspecifika regler. Detta är särskilt viktigt för funktioner avsedda för språk som använder dubbelbyte‑teckenuppsättningar (DBCS). För att korrekt beräkna sådana formler, skapa [LoadOptions](https://reference.aspose.com/slides/sv/java/com.aspose.slides/loadoptions/), ange den föredragna kulturen med [SpreadsheetOptions.setPreferredCulture](https://reference.aspose.com/slides/sv/java/com.aspose.slides/spreadsheetoptions/#setPreferredCulture-java.util.Locale-), tilldela kalkylbladsalternativen via [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/sv/java/com.aspose.slides/loadoptions/#setSpreadsheetOptions-com.aspose.slides.ISpreadsheetOptions-), och ladda sedan presentationen.

Följande exempel väljer den japanska kulturen, öppnar en presentation med de konfigurerade inläsningsalternativen och anropar [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) för varje diagramarbetsbok:

```java
import com.aspose.slides.*;
import java.util.Locale;

Locale japaneseCulture = Locale.forLanguageTag("ja-JP");

ISpreadsheetOptions spreadsheetOptions = new SpreadsheetOptions();
spreadsheetOptions.setPreferredCulture(japaneseCulture);

LoadOptions loadOptions = new LoadOptions();
loadOptions.setSpreadsheetOptions(spreadsheetOptions);

Presentation presentation = new Presentation("presentation.pptx", loadOptions);
try {
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IChart) {
                IChart chart = (IChart) shape;
                chart.getChartData().getChartDataWorkbook().calculateFormulas();
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Den föredragna kulturen är en del av presentationsläsningskonfigurationen, så ange den innan du skapar [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/). Använd den kultur som förväntas av arbetsboksformlerna; till exempel, använd `ja-JP` för formler som ska följa japanska DBCS‑beräkningsregler.

## **Omberäkning och cachade värden**

Kalkylbladsfiler lagrar vanligtvis både en formel och dess senast beräknade värde. Aspose.Slides kan därför läsa ett cachat värde från [IChartDataCell.getValue](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ichartdatacell/#getValue--) när en presentation laddas och den relevanta diagramdata inte har ändrats.

Efter att du har ändrat inmatningsceller eller formler, förlita dig inte på ett gammalt cachelagrat resultat. Anropa [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) innan du läser beräknade värden eller sparar diagramdata som beror på dem.

För formler utanför den stödda delmängden kan Aspose.Slides vara oförmögen att tolka formeln eller fastställa dess beroenden. Om arbetsboken har ändrats kan det tidigare cachade värdet inte längre anses pålitligt. I en sådan situation kan läsning av värdet i en cell med ej‑stödd data kasta [CellUnsupportedDataException](https://reference.aspose.com/slides/sv/java/com.aspose.slides/cellunsupporteddataexception/).

Om ditt diagram beror på Excel‑funktioner som Aspose.Slides inte utvärderar, beräkna dessa formler med en kalkylbladsmotor som stödjer dem och skriv tillbaka de resulterande värdena till diagramarbetsboken. Ersätt inte ej‑stödda formler med gissade värden.

## **Hantera formelfel**

Det finns två olika typer av problem att skilja på.

En formel kan vara giltig men producera ett kalkylbladsfelresultat såsom `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!` eller `#VALUE!`. I så fall är fel‑tokenen ett cellresultat och kan returneras via [IChartDataCell.getValue](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ichartdatacell/#getValue--).

En formel kan även misslyckas vid tolkning, referens, beroende eller på stödd‑datat‑nivå. Aspose.Slides tillhandahåller kalkylblads‑specifika undantag för dessa fall: [CellInvalidFormulaException](https://reference.aspose.com/slides/sv/java/com.aspose.slides/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/sv/java/com.aspose.slides/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/sv/java/com.aspose.slides/cellcircularreferenceexception/), och [CellUnsupportedDataException](https://reference.aspose.com/slides/sv/java/com.aspose.slides/cellunsupporteddataexception/).

När formler kommer från mallar eller användarinmatning, hantera dessa undantag runt omberäkning och värdeåtkomst:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300);
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    IChartDataCell cell = workbook.getCell(0, "A2");
    cell.setFormula("SUM(B2:B5)");

    try {
        workbook.calculateFormulas();
        System.out.println(cell.getValue());
    } catch (CellInvalidFormulaException ex) {
        System.err.println("Invalid formula: " + ex.getMessage());
    } catch (CellInvalidReferenceException ex) {
        System.err.println("Invalid cell reference: " + ex.getMessage());
    } catch (CellCircularReferenceException ex) {
        System.err.println("Circular reference: " + ex.getMessage());
    } catch (CellUnsupportedDataException ex) {
        System.err.println("Unsupported spreadsheet data: " + ex.getMessage());
    }
} finally {
    presentation.dispose();
}
```

## **Praktiska begränsningar**

Formelstödet i diagramkalkylblad är avsett för en definierad delmängd av kalkylbladsberäkningar, inte för full Excel‑kompatibilitet. Ha dessa begränsningar i åtanke när du designar ett rapporteringsarbetsflöde:

- Använd endast de dokumenterade konstanterna, operatorerna, referenserna och funktionerna när du behöver att Aspose.Slides omberäknar formler.
- Omberäkna efter att du har ändrat celler som formelresultat beror på.
- Behandla cachade värden från inlästa presentationer som ögonblicksbilder, inte som en ersättning för omberäkning efter redigeringar.
- Testa formler från befintliga mallar innan du litar på deras beräknade värden, särskilt när de använder funktioner utanför den dokumenterade listan.
- För formler som kräver en fullständig kalkylbladsberäkningsmotor, beräkna dem externt och uppdatera sedan diagramarbetsboken med de resulterande värdena.

## **FAQ**

**Vad är skillnaden mellan [IChartDataCell.setFormula](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-) och [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-)?**

[IChartDataCell.setFormula](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-) lagrar ett A1‑stil‑uttryck såsom `B2-C2`. [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-) lagrar ett R1C1‑stil‑uttryck såsom `RC[-2]-RC[-1]`. Använd den notation som bäst matchar hur du genererar eller kopierar formler.

**Behöver jag läsa själva cellen eller dess värde efter beräkning?**

[IChartDataWorkbook.getCell](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ichartdataworkbook/#getCell-int-java.lang.String-) returnerar en [IChartDataCell](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ichartdatacell/). För att få det beräknade resultatet, anropa den cellens [IChartDataCell.getValue](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ichartdatacell/#getValue--)‑metod efter omberäkning.

**När bör jag anropa [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ichartdataworkbook/#calculateFormulas--)?**

Anropa [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) efter att du har ändrat inmatningsvärden eller formler och innan du förlitar dig på de beräknade resultaten. Detta uppdaterar värdena för formler som den inbyggda utvärderaren stödjer.

**Stöder Aspose.Slides varje Excel‑funktion?**

Nej. Den inbyggda utvärderaren stödjer en dokumenterad delmängd av funktioner. Funktioner utanför den delmängden bör inte antas omberäknas korrekt. Om full Excel‑formelkompatibilitet krävs, utför beräkningen med en lämplig kalkylbladsmotor och skriv de slutliga värdena till diagramarbetsboken.

**Vad händer om en inläst presentation innehåller en ej‑stödd formel?**

Om diagramdata inte har ändrats kan arbetsboken fortfarande innehålla ett tidigare beräknat cachat värde. Efter att relaterad data har ändrats kan det cachade värdet vara ogiltigt. Att komma åt en cell vars formel inte kan hanteras kan kasta [CellUnsupportedDataException](https://reference.aspose.com/slides/sv/java/com.aspose.slides/cellunsupporteddataexception/).

**Är formelfelvärden samma som Java‑undantag?**

Nej. Ett resultat som `#DIV/0!` är ett kalkylbladsvärde som produceras av en giltig beräkning. Undantag som [CellInvalidFormulaException](https://reference.aspose.com/slides/sv/java/com.aspose.slides/cellinvalidformulaexception/) eller [CellCircularReferenceException](https://reference.aspose.com/slides/sv/java/com.aspose.slides/cellcircularreferenceexception/) indikerar att formeln inte kan bearbetas normalt.

**Uppdateras ett diagram automatiskt när en formelcell ändras?**

Ett diagramserie kan referera till arbetsbokens celler. Omberäkna arbetsboken först, spara eller rendera sedan presentationen. Om diagramdatapunkterna refererar till de beräknade cellerna använder diagrammet de uppdaterade cellvärdena; ingen separat diagramuppdateringsmetod krävs för detta arbetsflöde.

**Kan diagram använda en extern Excel‑arbetsbok?**

Ja, diagramdata kan konfigureras att använda en extern arbetsbok via diagramdata‑API:et. Däremot gäller arbetsflödet för formelberäkning som beskrivs i den här artikeln diagramarbetsboken och den formeldelmängd som evalueras av Aspose.Slides. Anta inte att [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) ger fullständig omberäkning av godtyckliga formler i en extern XLSX‑fil.

**Kan jag använda formler som refererar till ett annat kalkylblad eller en annan arbetsbok?**

Excel‑liknande referenser kan finnas i diagramarbetsböcker, men formelutvärderingen är begränsad av den stödda parsern och funktionsuppsättningen. Om en kors‑blad‑ eller extern referens är nödvändig, verifiera den exakta formeln med din mål‑version av Aspose.Slides. För arbetsflöden som kräver bred Excel‑referenskompatibilitet, beräkna arbetsboken externt och skriv de upplösta värdena tillbaka till diagramdata.

**Ska formelsträngar börja med `=`?**

Aspose.Slides‑API‑exemplen tilldelar uttryck såsom `B2-C2` eller `SUM(B2:B5)` utan ett inledande `=`. Att använda den formen håller genererade formler i linje med de dokumenterade API‑exemplen.
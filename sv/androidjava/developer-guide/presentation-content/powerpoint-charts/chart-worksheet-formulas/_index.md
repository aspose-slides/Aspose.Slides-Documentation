---
title: Applicera diagramarbetsbladsformler i presentationer på Android
linktitle: Arbetsbladsformler
type: docs
weight: 70
url: /sv/androidjava/chart-worksheet-formulas/
keywords:
- diagramkalkylblad
- diagram arbetsblad
- diagramformel
- arbetsbladsformel
- kalkylbladsformel
- diagramdataarbetsbok
- formelberäkning
- logisk konstant
- numerisk konstant
- strängkonstant
- felkonstant
- aritmetisk operator
- jämförelsoperator
- A1-stil
- R1C1-stil
- fördefinierad funktion
- PowerPoint
- presentation
- Android
- Java
- Aspose.Slides
description: "Använd Excel‑liknande formler i Aspose.Slides för Android via Java‑diagramarbetsblad, omberäkna värden och använd resultaten i PowerPoint‑diagram."
---
## **Översikt**

PowerPoint‑diagram lagrar vanligtvis sina källdata i ett inbäddat kalkylblad. I Aspose.Slides för Android via Java kan du komma åt det kalkylbladet via diagramdatabokens arbetsbok, skriva indata, tilldela formler till celler, beräkna stödjade formler och använda de beräknade cellerna som diagramdata.

Denna artikel förklarar hela formelarbetsflödet: skapa ett diagram, fyll i dess kalkylblad, tilldela A1‑ eller R1C1‑stils formler, beräkna dem igen, läs de beräknade värdena, koppla dessa celler till en diagramserie och spara presentationen. Den beskriver också den stödjade formlsyntaxen, den inbyggda funktionsuppsättningen, cachade värden, ej stödjade formler och kalkylblads‑specifika fel.

## **Diagram‑kalkylblad och formler**

Ett diagram‑kalkylblad innehåller kategorier, serienamn och värden som används av ett diagram. I PowerPoint kan du inspektera kalkylbladet genom att öppna diagramdataredigeraren:

![PowerPoint‑diagram med sitt inbäddade kalkylblad öppet, visar kategori‑ och seriedata](chart-worksheet-formulas_1.png)

I Aspose.Slides exponeras kalkylbladet via gränssnittet [IChartDataWorkbook](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ichartdataworkbook/). Använd [IChartDataCell.setFormula](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-) för A1‑stils formler och [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-) för R1C1‑stils formler. Efter att du har ändrat indata‑celler eller formler, anropa [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) för att omberäkna stödjade formler och uppdatera motsvarande cellvärden.

En beräknad cell exponerar fortfarande sitt resultat via [IChartDataCell.getValue](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ichartdatacell/#getValue--). Detta är viktigt när du behöver inspektera ett formelresultat i kod eller använda cellen som ett diagramdatapunkt.

## **Skapa ett diagram och beräkna kalkylbladsformler**

Följande exempel visar ett end‑to‑end‑arbetsflöde. Det skapar ett grupperat stapeldiagram, rensar exemplardata, skriver in kvartalsintäkter och kostnadsvärden, beräknar vinst med formler, läser resultaten, använder de beräknade cellerna som diagramvärden och sparar presentationen.

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

Diagramdatapunkterna refererar `D2:D4`, så diagrammet använder de beräknade vinstvärdena. Det finns inget separat diagram‑uppdateringsanrop i detta arbetsflöde: omberäkna arbetsboken först, använd eller spara sedan diagramdata som pekar på de beräknade cellerna.

## **Använd A1‑stils formler**

A1‑notation identifierar kolumner med bokstäver och rader med siffror. Tilldela A1‑stils uttryck via [IChartDataCell.setFormula](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-).

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
| Rad | `2:2` | `$2:$2` | — |
| Kolumn | `A:A` | `$A:$A` | — |
| Område | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

Relativa referenser kan ändras när en formel flyttas eller kopieras av ett kalkylbladsprogram. Absoluta referenser håller båda koordinaterna fasta, medan blandade referenser fixerar endast en rad eller en kolumn.

## **Använd R1C1‑stils formler**

R1C1‑notation identifierar både rader och kolumner numeriskt. Relativa referenser använder förskjutningar i hakparenteser. Tilldela denna syntax via [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-).

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

Vanliga R1C1‑referensformer är:

| Referens | Relativ | Absolut | Blandad |
|---|---|---|---|
| Cell | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| Rad | `R[2]` | `R2` | — |
| Kolumn | `C[3]` | `C3` | — |
| Område | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

Till exempel, i cellen `D2` betyder `RC[-2]` cellen i samma rad två kolumner åt vänster (`B2`).

## **Formelkonstanter och operatorer**

Den inbyggda formelutvärderaren stödjer logiska värden, numeriska litteraler, strängar, kalkylblads‑felvärden, aritmetiska operatorer och jämförelsoperatorer.

### **Konstanter och litteraler**

| Typ | Exempel | Notering |
|---|---|---|
| Logisk | `TRUE`, `FALSE` | Kan användas direkt i logiska uttryck såsom `A2=TRUE`. |
| Numerisk | `1`, `0.5`, `.3`, `1E-2` | Vanlig och vetenskaplig notation stödjs. |
| Sträng | `"abc"`, `"2/3/2020 12:00"` | Textlitteraler omsluts av dubbla citationstecken i formeln. |
| Felresultat | `#DIV/0!`, `#N/A`, `#REF!` | En giltig formel kan utvärderas till ett kalkylblads‑felvärde istället för ett normalt resultat. |

Detta exempel använder flera konstanstyper:

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
| `+` | Addition eller unärt plus | `2+3` |
| `-` | Subtraktion eller negation | `2-3`, `-3` |
| `*` | Multiplikation | `2*3` |
| `/` | Division | `2/3` |
| `%` | Procent | `30%` |
| `^` | Upphöjning | `2^3` |

Använd parenteser för att göra utvärderingsordningen explicit, exempelvis `(A2+B2)*C2`.

### **Jämförelsoperatorer**

Jämförelseuttryck returnerar logiska värden.

| Operator | Betydelse | Exempel |
|---|---|---|
| `=` | Lika med | `A2=3` |
| `<>` | Inte lika med | `A2<>3` |
| `>` | Större än | `A2>3` |
| `>=` | Större än eller lika med | `A2>=3` |
| `<` | Mindre än | `A2<3` |
| `<=` | Mindre än eller lika med | `A2<=3` |

## **Supporterade fördefinierade funktioner**

Aspose.Slides innehåller en inbyggd formelutvärderare för diagram‑kalkylblad, men den är inte en komplett Excel‑beräkningsmotor. Den dokumenterade funktionsuppsättningen är begränsad till funktionerna nedan. Anta inte att en godtycklig Excel‑funktion kan omberäknas av [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ichartdataworkbook/#calculateFormulas--).

| Funktion | Syfte eller stödd form | Exempel |
|---|---|---|
| `ABS` | Absolutvärde | `ABS(A2)` |
| `AVERAGE` | Medelvärde | `AVERAGE(B2:B5)` |
| `CEILING` | Runda upp till närmaste multipel | `CEILING(A2,5)` |
| `CHOOSE` | Välj ett värde efter index | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | Slå ihop textvärden | `CONCAT(A2,B2)` |
| `CONCATENATE` | Slå ihop textvärden | `CONCATENATE(A2," ",B2)` |
| `DATE` | Skapa datumvärde med 1900‑datumsystemet | `DATE(2026,8,19)` |
| `DAYS` | Returnera antal dagar mellan datum | `DAYS(B2,A2)` |
| `FIND` | Hitta en textsträng i en annan | `FIND("-",A2)` |
| `FINDB` | Byte‑orienterad textsökning | `FINDB("a",A2)` |
| `IF` | Villkorligt resultat | `IF(A2>0,A2,0)` |
| `INDEX` | Referensform | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | Vektorform | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | Vektorform | `MATCH(A2,B2:B5,0)` |
| `MAX` | Maximalt värde | `MAX(B2:B5)` |
| `SUM` | Summan av värden | `SUM(B2:B5)` |
| `VLOOKUP` | Vertikal sökning | `VLOOKUP(A2,B2:D10,3,FALSE)` |

Begränsningarna i tabellen är viktiga: `INDEX` dokumenteras i referensform, medan `LOOKUP` och `MATCH` dokumenteras i sina vektorformer. `DATE` använder 1900‑datumsystemet. Funktioner som inte listas här bör betraktas som ej stödjade av Aspose.Slides‑formelutvärderaren om de inte dokumenteras separat.

## **Omräkning och cachade värden**

Kalkylbladsfiler lagrar vanligtvis både en formel och dess senast beräknade värde. Aspose.Slides kan därför läsa ett cachat värde från [IChartDataCell.getValue](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ichartdatacell/#getValue--) när en presentation laddas och relevant diagramdata inte har ändrats.

Efter att du har ändrat indata‑celler eller formler, förlita dig inte på ett gammalt cache‑resultat. Anropa [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) innan du läser beräknade värden eller sparar diagramdata som beror på dem.

För formler utanför den stödjade delmängden kan Aspose.Slides misslyckas med att tolka formeln eller fastställa dess beroenden. Om arbetsboken har modifierats kan det tidigare cachade värdet inte längre anses pålitligt. I sådana fall kan läsning av en cell med ej stödjad data orsaka [CellUnsupportedDataException](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/cellunsupporteddataexception/).

Om ditt diagram är beroende av Excel‑funktioner som Aspose.Slides inte utvärderar, beräkna dessa formler med en kalkylblads‑motor som stödjer dem och skriv tillbaka de resulterande värdena till diagramarbetsboken. Ersätt inte ej stödjade formler med gissade värden.

## **Hantera formelfel**

Det finns två olika typer av problem att särskilja.

En formel kan vara giltig men producera ett kalkylblads‑felresultat såsom `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!` eller `#VALUE!`. I så fall är fel‑tokenen ett cellresultat och kan returneras via [IChartDataCell.getValue](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ichartdatacell/#getValue--).

En formel kan också misslyckas vid parsning, referens, beroende eller stöddata‑nivå. Aspose.Slides tillhandahåller kalkylblads‑specifika undantag för dessa fall: [CellInvalidFormulaException](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/cellcircularreferenceexception/) och [CellUnsupportedDataException](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/cellunsupporteddataexception/).

När formler kommer från mallar eller användarinmatning, hantera dessa undantag runt omräkning och värdeaccess:

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

Formelstödet i diagram‑kalkylblad är avsett för en definierad delmängd av kalkylbladsberäkningar, inte för full Excel‑kompatibilitet. Ha dessa begränsningar i åtanke när du designar ett rapporteringsarbetsflöde:

- Använd endast de dokumenterade konstanterna, operatorerna, referenserna och funktionerna när du vill att Aspose.Slides ska omberäkna formler.
- Omberäkna efter att du har ändrat celler som formelresultaten beror på.
- Betrakta cachade värden från laddade presentationer som ögonblicksbilder, inte som ersättning för omräkning efter redigering.
- Testa formler från befintliga mallar innan du förlitar dig på deras beräknade värden, särskilt när de använder funktioner utanför den dokumenterade listan.
- För formler som kräver en fullständig kalkylblads‑beräkningsmotor, beräkna dem externt och uppdatera sedan diagramarboken med de resulterande värdena.

## **FAQ**

**Vad är skillnaden mellan [IChartDataCell.setFormula](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-) och [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-)?**

[IChartDataCell.setFormula](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-) lagrar ett A1‑stils uttryck såsom `B2-C2`. [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-) lagrar ett R1C1‑stils uttryck såsom `RC[-2]-RC[-1]`. Använd den notation som bäst matchar hur du genererar eller kopierar formler.

**Behöver jag läsa själva cellen eller dess värde efter beräkning?**

[IChartDataWorkbook.getCell](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ichartdataworkbook/#getCell-int-java.lang.String-) returnerar en [IChartDataCell](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ichartdatacell/). För att få det beräknade resultatet, anropa den cellens [IChartDataCell.getValue](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ichartdatacell/#getValue--) efter omräkning.

**När ska jag anropa [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ichartdataworkbook/#calculateFormulas--)?**

Anropa [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) efter att du har ändrat indata‑värden eller formler och innan du förlitar dig på de beräknade resultaten. Detta uppdaterar värdena för formler som den inbyggda utvärderaren stödjer.

**Stöder Aspose.Slides alla Excel‑funktioner?**

Nej. Den inbyggda utvärderaren stödjer en dokumenterad delmängd av funktioner. Funktioner utanför den delmängden får inte antas beräknas korrekt. Om full Excel‑formelkompatibilitet krävs, utför beräkningen med en lämplig kalkylblads‑motor och skriv de slutgiltiga värdena till diagramarboken.

**Vad händer om en inläst presentation innehåller en ej stödjad formel?**

Om diagramdata inte har förändrats kan arbetsboken fortfarande innehålla ett tidigare beräknat cachat värde. Efter att relaterad data har modifierats kan detta cachade värde vara ogiltigt. Att komma åt en cell vars formel inte kan hanteras kan ge ett [CellUnsupportedDataException](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/cellunsupporteddataexception/).

**Är formelfelvärden samma som Java‑undantag?**

Nej. Ett resultat som `#DIV/0!` är ett kalkylblads‑värde som produceras av en giltig beräkning. Undantag som [CellInvalidFormulaException](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/cellinvalidformulaexception/) eller [CellCircularReferenceException](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/cellcircularreferenceexception/) indikerar att formeln inte kan bearbetas normalt.

**Uppdateras ett diagram automatiskt när en formelcell ändras?**

En diagramserie kan referera till arbetsbokens celler. Omberäkna arbetsboken först, spara eller rendera sedan presentationen. Om diagramdatapunkterna refererar till de beräknade cellerna använder diagrammet de uppdaterade värdena; inget separat diagram‑uppdateringsmetod krävs för detta arbetsflöde.

**Kan diagram använda ett externt Excel‑arbetsbok?**

Ja, diagramdata kan konfigureras att använda en extern arbetsbok via diagram‑data‑API:et. Dock gäller formelberäkningsarbetsflödet i den här artikeln endast diagramarboken och den formeldelning som utvärderas av Aspose.Slides. Anta inte att [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) ger fullständig omräkning av godtyckliga formler i en extern XLSX‑fil.

**Kan jag använda formler som refererar till ett annat kalkylblad eller arbetsbok?**

Excel‑stilreferenser kan finnas i diagramarböcker, men formelutvärderingen är begränsad av den stödjade parsern och funktionsuppsättningen. Om ett kors‑blad‑ eller externt referens är väsentligt, verifiera att exakt formel fungerar med din mål‑version av Aspose.Slides. För arbetsflöden som kräver bred Excel‑referenskompatibilitet, beräkna arbetsboken externt och skriv tillbaka de upplösta värdena till diagramdata.

**Ska formelsträngar börja med `=`?**

Aspose.Slides‑API‑exempel tilldelar uttryck såsom `B2-C2` eller `SUM(B2:B5)` utan inledande `=`. Att använda den formen håller genererade formler konsekventa med de dokumenterade API‑exemplen.
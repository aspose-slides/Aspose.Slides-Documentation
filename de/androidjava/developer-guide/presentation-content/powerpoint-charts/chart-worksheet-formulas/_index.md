---
title: Diagramm-Arbeitsblatt-Formeln in Präsentationen auf Android anwenden
linktitle: Arbeitsblatt-Formeln
type: docs
weight: 70
url: /de/androidjava/chart-worksheet-formulas/
keywords:
- Diagramm-Tabellenkalkulation
- Diagramm-Arbeitsblatt
- Diagramm-Formel
- Arbeitsblatt-Formel
- Tabellenkalkulations-Formel
- Diagrammdaten-Arbeitsmappe
- Formelberechnung
- Logische Konstante
- Numerische Konstante
- Zeichenketten-Konstante
- Fehlerkonstante
- Arithmetischer Operator
- Vergleichsoperator
- A1-Stil
- R1C1-Stil
- Vordefinierte Funktion
- PowerPoint
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Wenden Sie Excel-ähnliche Formeln in Aspose.Slides für Android über Java-Diagramm-Arbeitsblätter an, berechnen Sie Werte neu und nutzen Sie die Ergebnisse in PowerPoint-Diagrammen."
---
## **Übersicht**

PowerPoint‑Diagramme speichern ihre Quelldaten in der Regel in einem eingebetteten Arbeitsblatt. In Aspose.Slides für Android via Java können Sie über die Diagrammdaten‑Arbeitsmappe auf dieses Arbeitsblatt zugreifen, Eingabewerte schreiben, Formeln Zellen zuweisen, unterstützte Formeln berechnen und die berechneten Zellen als Diagrammdaten verwenden.

Dieser Artikel erklärt den vollständigen Formel‑Workflow: ein Diagramm erstellen, das Arbeitsblatt füllen, A1‑ bzw. R1C1‑Formeln zuweisen, sie neu berechnen, die berechneten Werte auslesen, diese Zellen mit einer Diagrammreihe verknüpfen und die Präsentation speichern. Außerdem wird die unterstützte Formelsyntax, das integrierte Funktions‑Subset, zwischengespeicherte Werte, nicht unterstützte Formeln und tabellenspezifische Fehler beschrieben.

## **Diagramm‑Arbeitsblätter und Formeln**

Ein Diagramm‑Arbeitsblatt enthält die Kategorien, Seriennamen und Werte, die von einem Diagramm verwendet werden. In PowerPoint können Sie das Arbeitsblatt anzeigen, indem Sie den Diagrammdaten‑Editor öffnen:

![PowerPoint‑Diagramm mit geöffnetem eingebettetem Arbeitsblatt, das Kategorie‑ und Seriendaten zeigt](chart-worksheet-formulas_1.png)

In Aspose.Slides wird das Arbeitsblatt über die Schnittstelle [IChartDataWorkbook](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ichartdataworkbook/) bereitgestellt. Verwenden Sie [IChartDataCell.setFormula](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-) für A1‑Formeln und [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-) für R1C1‑Formeln. Nach dem Ändern von Eingabezellen oder Formeln rufen Sie [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) auf, um unterstützte Formeln neu zu berechnen und die entsprechenden Zellwerte zu aktualisieren.

Eine berechnete Zelle gibt ihr Ergebnis weiterhin über [IChartDataCell.getValue](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ichartdatacell/#getValue--) zurück. Das ist wichtig, wenn Sie das Formelresultat im Code prüfen oder die Zelle als Diagrammdatenpunkt verwenden müssen.

## **Ein Diagramm erstellen und Arbeitsblatt‑Formeln berechnen**

Das folgende Beispiel demonstriert einen End‑to‑End‑Workflow. Es erzeugt ein gruppiertes Säulendiagramm, löscht die Beispieldaten, schreibt Quartals‑Umsatz‑ und Aufwandswerte, berechnet den Gewinn mit Formeln, liest die Ergebnisse aus, verwendet die berechneten Zellen als Diagrammw Werte und speichert die Präsentation.

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

Die Diagrammdatenpunkte verweisen auf `D2:D4`, sodass das Diagramm die berechneten Gewinnwerte nutzt. Es gibt keinen separaten Diagramm‑Aktualisierungsaufruf in diesem Workflow: Zuerst das Arbeitsbuch neu berechnen, dann die Diagrammdaten verwenden oder speichern, die auf die berechneten Zellen zeigen.

## **A1‑Formeln verwenden**

Die A1‑Notation identifiziert Spalten mit Buchstaben und Zeilen mit Zahlen. Weisen Sie A1‑Ausdrücke über [IChartDataCell.setFormula](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-) zu.

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

Übliche A1‑Bezugformen sind:

| Bezug | Relativ | Absolut | Gemischt |
|---|---|---|---|
| Zelle | `A2` | `$A$2` | `A$2`, `$A2` |
| Zeile | `2:2` | `$2:$2` | — |
| Spalte | `A:A` | `$A:$A` | — |
| Bereich | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

Relative Bezüge können sich ändern, wenn eine Formel von einer Tabellenkalkulations‑Anwendung verschoben oder kopiert wird. Absolute Bezüge halten beide Koordinaten fest, während gemischte Bezüge nur eine Zeile oder eine Spalte fixieren.

## **R1C1‑Formeln verwenden**

Die R1C1‑Notation identifiziert sowohl Zeilen als auch Spalten numerisch. Relative Bezüge verwenden Offsets in eckigen Klammern. Weisen Sie diese Syntax über [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-) zu.

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

Übliche R1C1‑Bezugformen sind:

| Bezug | Relativ | Absolut | Gemischt |
|---|---|---|---|
| Zelle | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| Zeile | `R[2]` | `R2` | — |
| Spalte | `C[3]` | `C3` | — |
| Bereich | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

Beispiel: In Zelle `D2` bedeutet `RC[-2]` die Zelle in derselben Zeile, zwei Spalten links (`B2`).

## **Formelkonstanten und Operatoren**

Der integrierte Formelevaluator unterstützt logische Werte, numerische Literale, Zeichenketten, tabellenspezifische Fehlerwerte, arithmetische Operatoren und Vergleichsoperatoren.

### **Konstanten und Literale**

| Typ | Beispiele | Hinweis |
|---|---|---|
| Logisch | `TRUE`, `FALSE` | Kann direkt in logischen Ausdrücken wie `A2=TRUE` verwendet werden. |
| Numerisch | `1`, `0.5`, `.3`, `1E-2` | Dezimal‑ und wissenschaftliche Notation werden unterstützt. |
| Zeichenkette | `"abc"`, `"2/3/2020 12:00"` | Textliterale werden innerhalb der Formel in doppelte Anführungszeichen gesetzt. |
| Fehlergebnis | `#DIV/0!`, `#N/A`, `#REF!` | Eine gültige Formel kann statt eines normalen Ergebnisses einen Tabellen‑Fehlerwert ergeben. |

Dieses Beispiel nutzt mehrere Konstantentypen:

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

    Object logicalValue = workbook.getCell(0, "B2").getValue(); // false
    Object numericValue = workbook.getCell(0, "C2").getValue(); // 1.5
    Object scientificValue = workbook.getCell(0, "D2").getValue(); // 0.003
    Object stringValue = workbook.getCell(0, "E2").getValue(); // abc
    Object errorValue = workbook.getCell(0, "F2").getValue(); // #DIV/0!
} finally {
    presentation.dispose();
}
```

### **Arithmetische Operatoren**

| Operator | Bedeutung | Beispiel |
|---|---|---|
| `+` | Addition oder Vorzeichen Plus | `2+3` |
| `-` | Subtraktion oder Negation | `2-3`, `-3` |
| `*` | Multiplikation | `2*3` |
| `/` | Division | `2/3` |
| `%` | Prozent | `30%` |
| `^` | Potenz | `2^3` |

Verwenden Sie Klammern, um die Auswertungsreihenfolge explizit zu machen, z. B. `(A2+B2)*C2`.

### **Vergleichsoperatoren**

Vergleichsausdrücke liefern logische Werte.

| Operator | Bedeutung | Beispiel |
|---|---|---|
| `=` | Gleich | `A2=3` |
| `<>` | Ungleich | `A2<>3` |
| `>` | Größer als | `A2>3` |
| `>=` | Größer‑ oder gleich | `A2>=3` |
| `<` | Kleiner als | `A2<3` |
| `<=` | Kleiner‑ oder gleich | `A2<=3` |

## **Unterstützte vordefinierte Funktionen**

Aspose.Slides enthält einen integrierten Formelevaluator für Diagramm‑Arbeitsblätter, ist jedoch keine vollständige Excel‑Berechnungs‑Engine. Der dokumentierte Funktionsumfang ist auf die nachfolgend aufgeführten Funktionen beschränkt. Gehen Sie nicht davon aus, dass eine beliebige Excel‑Funktion von [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) neu berechnet werden kann.

| Funktion | Zweck oder unterstützte Form | Beispiel |
|---|---|---|
| `ABS` | Absoluter Wert | `ABS(A2)` |
| `AVERAGE` | Arithmetisches Mittel | `AVERAGE(B2:B5)` |
| `CEILING` | Auf ein Vielfaches aufrunden | `CEILING(A2,5)` |
| `CHOOSE` | Wert nach Index auswählen | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | Textwerte verketten | `CONCAT(A2,B2)` |
| `CONCATENATE` | Textwerte verketten | `CONCATENATE(A2," ",B2)` |
| `DATE` | Datumwert nach 1900‑Datumsystem erstellen | `DATE(2026,8,19)` |
| `DAYS` | Anzahl der Tage zwischen Daten | `DAYS(B2,A2)` |
| `FIND` | Einen Textwert in einem anderen finden | `FIND("-",A2)` |
| `FINDB` | Byte‑orientierte Textsuche | `FINDB("a",A2)` |
| `IF` | Bedingtes Ergebnis | `IF(A2>0,A2,0)` |
| `INDEX` | Referenzform | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | Vektorform | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | Vektorform | `MATCH(A2,B2:B5,0)` |
| `MAX` | Maximalwert | `MAX(B2:B5)` |
| `SUM` | Summe | `SUM(B2:B5)` |
| `VLOOKUP` | Vertikaler Suchen | `VLOOKUP(A2,B2:D10,3,FALSE)` |

Die in der Tabelle gezeigten Einschränkungen sind wesentlich: `INDEX` wird in Referenzform dokumentiert, während `LOOKUP` und `MATCH` in ihrer Vektorform dokumentiert sind. `DATE` verwendet das 1900‑Datumsystem. Funktionen, die hier nicht aufgeführt sind, sollten als nicht unterstützt durch den Aspose.Slides‑Formelevaluator angesehen werden, sofern sie nicht separat dokumentiert sind.

## **Neuberechnung und zwischengespeicherte Werte**

Tabellen‑Dateien speichern häufig sowohl eine Formel als auch deren zuletzt berechneten Wert. Aspose.Slides kann daher beim Laden einer Präsentation einen zwischengespeicherten Wert aus [IChartDataCell.getValue](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ichartdatacell/#getValue--) auslesen, wenn die zugehörigen Diagrammdaten nicht geändert wurden.

Nach dem Ändern von Eingabezellen oder Formeln sollten Sie sich nicht auf ein altes zwischengespeichertes Ergebnis verlassen. Rufen Sie [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) auf, bevor Sie berechnete Werte auslesen oder Diagrammdaten speichern, die von ihnen abhängen.

Für Formeln außerhalb des unterstützten Subsets kann Aspose.Slides die Formel eventuell nicht parsen oder ihre Abhängigkeiten ermitteln. Wurde das Arbeitsbuch geändert, ist der vorherige zwischengespeicherte Wert nicht mehr zuverlässig. In diesem Fall kann das Auslesen des Werts einer Zelle mit nicht unterstützten Daten die Ausnahme [CellUnsupportedDataException](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/cellunsupporteddataexception/) auslösen.

Wenn Ihr Diagramm Excel‑Funktionen nutzt, die Aspose.Slides nicht auswertet, berechnen Sie diese Formeln mit einer Tabellen‑Engine, die sie unterstützt, und schreiben Sie die resultierenden Werte zurück in das Diagramm‑Arbeitsbuch. Ersetzen Sie nicht unterstützte Formeln durch geschätzte Werte.

## **Formelfehler behandeln**

Es gibt zwei unterschiedliche Arten von Problemen.

Eine Formel kann gültig sein, aber ein Tabellen‑Fehlerergebnis wie `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!` oder `#VALUE!` erzeugen. In diesem Fall ist das Fehlertoken ein Zellen‑Ergebnis und kann über [IChartDataCell.getValue](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ichartdatacell/#getValue--) zurückgegeben werden.

Eine Formel kann zudem beim Parsen, bei Referenzen, Abhängigkeiten oder wegen nicht unterstützter Daten fehlschlagen. Aspose.Slides liefert dafür tabellenspezifische Ausnahmen: [CellInvalidFormulaException](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/cellcircularreferenceexception/) und [CellUnsupportedDataException](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/cellunsupporteddataexception/).

Wenn Formeln aus Vorlagen oder Benutzereingaben stammen, fangen Sie diese Ausnahmen beim Neuberechnen und beim Zugriff auf Werte ab:

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

## **Praktische Einschränkungen**

Die Formelunterstützung in Diagramm‑Arbeitsblättern ist für einen definierten Teilbereich von Tabellen‑Berechnungen gedacht, nicht für vollständige Excel‑Kompatibilität. Berücksichtigen Sie diese Beschränkungen beim Entwurf eines Reporting‑Workflows:

- Verwenden Sie nur die dokumentierten Konstanten, Operatoren, Bezüge und Funktionen, wenn Aspose.Slides Formeln neu berechnen soll.
- Berechnen Sie nach Änderungen an Zellen, von denen Formelergebnisse abhängen, neu.
- Betrachten Sie zwischengespeicherte Werte aus geladenen Präsentationen als Schnappschüsse, nicht als Ersatz für eine Neuberechnung nach Bearbeitungen.
- Testen Sie Formeln aus bestehenden Vorlagen, bevor Sie sich auf ihre berechneten Werte verlassen, insbesondere wenn sie Funktionen außerhalb der dokumentierten Liste nutzen.
- Für Formeln, die eine vollständige Tabellen‑Berechnungs‑Engine erfordern, berechnen Sie sie extern und aktualisieren anschließend das Diagramm‑Arbeitsbuch mit den resultierenden Werten.

## **FAQ**

**Was ist der Unterschied zwischen [IChartDataCell.setFormula](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-) und [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-)?**

[IChartDataCell.setFormula](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-) speichert einen A1‑Ausdruck wie `B2-C2`. [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-) speichert einen R1C1‑Ausdruck wie `RC[-2]-RC[-1]`. Verwenden Sie die Notation, die am besten zu Ihrer Formelgenerierung oder -kopie passt.

**Muss ich nach der Berechnung die Zelle selbst oder ihren Wert auslesen?**

[IChartDataWorkbook.getCell](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ichartdataworkbook/#getCell-int-java.lang.String-) gibt ein [IChartDataCell](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ichartdatacell/) zurück. Um das berechnete Ergebnis zu erhalten, rufen Sie die Methode [IChartDataCell.getValue](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ichartdatacell/#getValue--) der Zelle nach der Neuberechnung auf.

**Wann soll ich [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) aufrufen?**

Rufen Sie [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) nach dem Ändern von Eingabewerten oder Formeln und bevor Sie von den berechneten Ergebnissen abhängen, auf. Dies aktualisiert die Werte der Formeln, die der integrierte Evaluator unterstützt.

**Unterstützt Aspose.Slides jede Excel‑Funktion?**

Nein. Der integrierte Evaluator unterstützt nur ein dokumentiertes Teilset von Funktionen. Funktionen außerhalb dieses Teilsets sollten nicht als korrekt neu berechenbar angenommen werden. Wenn vollständige Excel‑Formel‑Kompatibilität nötig ist, führen Sie die Berechnung mit einer geeigneten Tabellen‑Engine durch und schreiben Sie die Endwerte in das Diagramm‑Arbeitsbuch.

**Was passiert, wenn eine geladene Präsentation eine nicht unterstützte Formel enthält?**

Wenn die Diagrammdaten nicht geändert wurden, kann das Arbeitsbuch weiterhin einen zuvor berechneten zwischengespeicherten Wert enthalten. Nach einer Änderung der zugehörigen Daten ist dieser Wert möglicherweise nicht mehr gültig. Der Zugriff auf eine Zelle, deren Formel nicht verarbeitet werden kann, kann die Ausnahme [CellUnsupportedDataException](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/cellunsupporteddataexception/) auslösen.

**Sind Formelfehlerwerte gleichbedeutend mit Java‑Ausnahmen?**

Nein. Ein Ergebnis wie `#DIV/0!` ist ein Tabellenwert, der durch eine gültige Berechnung entsteht. Ausnahmen wie [CellInvalidFormulaException](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/cellinvalidformulaexception/) oder [CellCircularReferenceException](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/cellcircularreferenceexception/) zeigen an, dass die Formel nicht normal verarbeitet werden kann.

**Aktualisiert sich ein Diagramm automatisch, wenn sich eine Formezelle ändert?**

Eine Diagrammserie kann auf Arbeitsbuchzellen verweisen. Berechnen Sie das Arbeitsbuch zuerst neu und speichern oder rendern Sie anschließend die Präsentation. Wenn die Diagrammdatenpunkte auf die berechneten Zellen verweisen, nutzt das Diagramm diese aktualisierten Zellwerte; ein separater Diagramm‑Aktualisierungs‑Aufruf ist für diesen Workflow nicht erforderlich.

**Können Diagramme ein externes Excel‑Arbeitsbuch verwenden?**

Ja, Diagrammdaten können über die Diagrammdaten‑API so konfiguriert werden, dass sie ein externes Arbeitsbuch nutzen. Der in diesem Artikel beschriebene Formel‑Berechnungs‑Workflow bezieht sich jedoch auf das Diagramm‑Arbeitsbuch und das von Aspose.Slides evaluierte Formel‑Subset. Gehen Sie nicht davon aus, dass [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) eine vollständige Neuberechnung beliebiger Formeln in einer externen XLSX‑Datei liefert.

**Kann ich Formeln verwenden, die sich auf ein anderes Arbeitsblatt oder Arbeitsbuch beziehen?**

Excel‑artige Bezüge können in Diagramm‑Arbeitsbüchern vorkommen, aber die Formelauswertung ist durch den unterstützten Parser und das Funktionsset begrenzt. Wenn ein bereichsübergreifender oder externer Bezug unabdingbar ist, prüfen Sie die exakte Formel mit Ihrer Ziel‑Aspose.Slides‑Version. Für Workflows, die umfassende Excel‑Bezugskompatibilität erfordern, berechnen Sie das Arbeitsbuch extern und schreiben die aufgelösten Werte zurück in die Diagrammdaten.

**Müssen Formelkettungen mit `=` beginnen?**

Die Aspose.Slides‑API‑Beispiele weisen Ausdrücke wie `B2-C2` oder `SUM(B2:B5)` ohne führendes `=` zu. Die Verwendung dieser Form hält erzeugte Formeln konsistent mit den dokumentierten API‑Beispielen.
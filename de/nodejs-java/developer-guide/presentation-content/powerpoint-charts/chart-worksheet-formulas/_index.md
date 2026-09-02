---
title: Diagramm-Arbeitsblatt-Formeln in Präsentationen mit JavaScript anwenden
linktitle: Arbeitsblatt-Formeln
type: docs
weight: 70
url: /de/nodejs-java/chart-worksheet-formulas/
keywords:
- Diagramm-Tabellenkalkulation
- Diagramm-Arbeitsblatt
- Diagramm-Formel
- Arbeitsblatt-Formel
- Tabellenkalkulations-Formel
- Diagramm-Datenarbeitsbuch
- Formelberechnung
- logische Konstante
- numerische Konstante
- Zeichenketten-Konstante
- Fehler-Konstante
- arithmetischer Operator
- Vergleichsoperator
- A1-Stil
- R1C1-Stil
- vordefinierte Funktion
- PowerPoint
- Präsentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Excel-artige Formeln in Aspose.Slides für Node.js via Java Diagramm-Arbeitsblätter anwenden, Werte neu berechnen und die Ergebnisse in PowerPoint-Diagrammen verwenden."
---
## **Übersicht**

PowerPoint‑Diagramme speichern ihre Quelldaten in der Regel in einem eingebetteten Arbeitsblatt. In Aspose.Slides für Node.js via Java können Sie über das Diagrammdaten‑Arbeitsbuch auf dieses Arbeitsblatt zugreifen, Eingabewerte schreiben, Formeln Zellen zuweisen, unterstützte Formeln berechnen und die berechneten Zellen als Diagrammdaten verwenden.

Dieser Artikel erklärt den vollständigen Formel‑Workflow: ein Diagramm erstellen, sein Arbeitsblatt füllen, A1‑ oder R1C1‑Formeln zuweisen, sie neu berechnen, die berechneten Werte lesen, diese Zellen einer Diagramm‑Serie zuordnen und die Präsentation speichern. Außerdem wird die unterstützte Formelsyntax, der integrierte Funktionsumfang, zwischengespeicherte Werte, nicht unterstützte Formeln und tabellenspezifische Fehler beschrieben.

## **Diagramm‑Arbeitsblätter und Formeln**

Ein Diagramm‑Arbeitsblatt enthält die Kategorien, Seriennamen und Werte, die von einem Diagramm verwendet werden. In PowerPoint können Sie das Arbeitsblatt einsehen, indem Sie den Diagrammdaten‑Editor öffnen:

![PowerPoint‑Diagramm mit geöffnetem eingebettetem Arbeitsblatt, das Kategorie‑ und Seriendaten zeigt](chart-worksheet-formulas_1.png)

In Aspose.Slides wird das Arbeitsblatt über die Klasse [ChartDataWorkbook](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/chartdataworkbook/) bereitgestellt. Verwenden Sie [ChartDataCell.setFormula](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/chartdatacell/#setFormula-java.lang.String-) für A1‑Formeln und [ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/chartdatacell/#setR1C1Formula-java.lang.String-) für R1C1‑Formeln. Nachdem Sie Eingabezellen oder Formeln geändert haben, rufen Sie [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--) auf, um unterstützte Formeln neu zu berechnen und die entsprechenden Zellwerte zu aktualisieren.

Eine berechnete Zelle gibt ihr Ergebnis weiterhin über [ChartDataCell.getValue](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/chartdatacell/#getValue--) zurück. Das ist wichtig, wenn Sie ein Formel‑Ergebnis im Code inspizieren oder die Zelle als Diagrammdatenpunkt verwenden müssen.

## **Ein Diagramm erstellen und Arbeitsblatt‑Formeln berechnen**

Das folgende Beispiel demonstriert einen End‑zu‑End‑Workflow. Es erstellt ein gruppiertes Säulendiagramm, löscht die Beispieldaten, schreibt quartalsweise Umsatz‑ und Aufwand‑Werte, berechnet den Gewinn mit Formeln, liest die Ergebnisse, verwendet die berechneten Zellen als Diagrammwerte und speichert die Präsentation.

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

Die Diagrammdatenpunkte verweisen auf `D2:D4`, sodass das Diagramm die berechneten Gewinnwerte nutzt. Es gibt keinen separaten Diagramm‑Refresh‑Aufruf in diesem Workflow: Zuerst das Arbeitsbuch neu berechnen, dann die Diagrammdaten verwenden oder speichern, die auf die berechneten Zellen zeigen.

## **Verwenden von A1‑Stil‑Formeln**

Die A1‑Notation identifiziert Spalten mit Buchstaben und Zeilen mit Zahlen. Weisen Sie A1‑Stil‑Ausdrücke über [ChartDataCell.setFormula](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/chartdatacell/#setFormula-java.lang.String-) zu.

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

Häufige A1‑Referenzformen sind:

| Referenz | Relativ | Absolut | Gemischt |
|---|---|---|---|
| Zelle | `A2` | `$A$2` | `A$2`, `$A2` |
| Zeile | `2:2` | `$2:$2` | — |
| Spalte | `A:A` | `$A:$A` | — |
| Bereich | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

Relative Verweise können sich ändern, wenn eine Formel von einer Tabellenkalkulations‑Anwendung verschoben oder kopiert wird. Absolute Verweise halten beide Koordinaten fest, während gemischte Verweise nur eine Zeile oder eine Spalte fixieren.

## **Verwenden von R1C1‑Stil‑Formeln**

Die R1C1‑Notation identifiziert sowohl Zeilen als auch Spalten numerisch. Relative Verweise nutzen Offsets in eckigen Klammern. Weisen Sie diese Syntax über [ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/chartdatacell/#setR1C1Formula-java.lang.String-) zu.

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

Häufige R1C1‑Referenzformen sind:

| Referenz | Relativ | Absolut | Gemischt |
|---|---|---|---|
| Zelle | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| Zeile | `R[2]` | `R2` | — |
| Spalte | `C[3]` | `C3` | — |
| Bereich | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

Beispiel: In Zelle `D2` bedeutet `RC[-2]` die Zelle in derselben Zeile, zwei Spalten nach links (`B2`).

## **Formelkonstanten und Operatoren**

Der integrierte Formelauswerter unterstützt logische Werte, numerische Literale, Zeichenketten, Tabellen‑Fehlerwerte, arithmetische Operatoren und Vergleichsoperatoren.

### **Konstanten und Literale**

| Typ | Beispiele | Hinweise |
|---|---|---|
| Logisch | `TRUE`, `FALSE` | Können direkt in logischen Ausdrücken wie `A2=TRUE` verwendet werden. |
| Numerisch | `1`, `0.5`, `.3`, `1E-2` | Dezimal‑ und wissenschaftliche Notation werden unterstützt. |
| Zeichenkette | `"abc"`, `"2/3/2020 12:00"` | Text‑Literale werden innerhalb der Formel in doppelte Anführungszeichen gesetzt. |
| Fehlerwert | `#DIV/0!`, `#N/A`, `#REF!` | Eine gültige Formel kann statt eines normalen Ergebnisses zu einem Tabellen‑Fehlerwert auswerten. |

Dieses Beispiel verwendet mehrere Konstantentypen:

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

    const logicalValue = workbook.getCell(0, "B2").getValue(); // false
    const numericValue = workbook.getCell(0, "C2").getValue(); // 1.5
    const scientificValue = workbook.getCell(0, "D2").getValue(); // 0.003
    const stringValue = workbook.getCell(0, "E2").getValue(); // abc
    const errorValue = workbook.getCell(0, "F2").getValue(); // #DIV/0!
} finally {
    presentation.dispose();
}
```

### **Arithmetische Operatoren**

| Operator | Bedeutung | Beispiel |
|---|---|---|
| `+` | Addition oder Vorzeichen‑Plus | `2+3` |
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
| `>=` | Größer‑oder‑gleich | `A2>=3` |
| `<` | Kleiner als | `A2<3` |
| `<=` | Kleiner‑oder‑gleich | `A2<=3` |

## **Unterstützte vordefinierte Funktionen**

Aspose.Slides enthält einen integrierten Formelauswerter für Diagramm‑Arbeitsblätter, ist jedoch keine vollständige Excel‑Berechnungs‑Engine. Der dokumentierte Funktionsumfang ist auf die nachfolgend aufgeführten Funktionen beschränkt. Gehen Sie nicht davon aus, dass eine beliebige Excel‑Funktion von [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--) neu berechnet werden kann.

| Funktion | Zweck oder unterstützte Form | Beispiel |
|---|---|---|
| `ABS` | Absolutwert | `ABS(A2)` |
| `AVERAGE` | Arithmetisches Mittel | `AVERAGE(B2:B5)` |
| `CEILING` | Auf ein Vielfaches aufrunden | `CEILING(A2,5)` |
| `CHOOSE` | Wert nach Index auswählen | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | Textwerte verknüpfen | `CONCAT(A2,B2)` |
| `CONCATENATE` | Textwerte verknüpfen | `CONCATENATE(A2," ",B2)` |
| `DATE` | Datumwert nach 1900‑System erstellen | `DATE(2026,8,19)` |
| `DAYS` | Anzahl der Tage zwischen Daten | `DAYS(B2,A2)` |
| `FIND` | Text in anderem Text finden | `FIND("-",A2)` |
| `FINDB` | Byte‑orientierte Textsuche | `FINDB("a",A2)` |
| `IF` | Bedingtes Ergebnis | `IF(A2>0,A2,0)` |
| `INDEX` | Referenz‑Form | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | Vektor‑Form | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | Vektor‑Form | `MATCH(A2,B2:B5,0)` |
| `MAX` | Maximalwert | `MAX(B2:B5)` |
| `SUM` | Summe | `SUM(B2:B5)` |
| `VLOOKUP` | Vertikaler Suchen | `VLOOKUP(A2,B2:D10,3,FALSE)` |

Die in der Tabelle gezeigten Einschränkungen sind bedeutsam: `INDEX` ist in der Referenz‑Form dokumentiert, während `LOOKUP` und `MATCH` in ihrer Vektor‑Form angegeben sind. `DATE` verwendet das 1900‑Datumssystem. Funktionen, die hier nicht aufgeführt sind, sollten als nicht unterstützt vom Aspose.Slides‑Formelauswerter angesehen werden, sofern sie nicht gesondert dokumentiert sind.

## **Neuberechnung und zwischengespeicherte Werte**

Tabellen‑Dateien speichern häufig sowohl eine Formel als auch deren zuletzt berechneten Wert. Aspose.Slides kann daher einen zwischengespeicherten Wert von [ChartDataCell.getValue](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/chartdatacell/#getValue--) lesen, wenn eine Präsentation geladen wird und die relevanten Diagrammdaten nicht geändert wurden.

Nachdem Sie Eingabezellen oder Formeln geändert haben, dürfen Sie sich nicht auf ein altes zwischengespeichertes Ergebnis verlassen. Rufen Sie vor dem Lesen berechneter Werte oder dem Speichern von Diagrammdaten, die davon abhängen, [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--) auf.

Für Formeln außerhalb des unterstützten Teilbereichs kann Aspose.Slides die Formel möglicherweise nicht parsen oder ihre Abhängigkeiten ermitteln. Wenn das Arbeitsbuch modifiziert wurde, kann der vorherige zwischengespeicherte Wert nicht mehr als zuverlässig angesehen werden. In diesem Fall kann das Lesen des Werts einer Zelle mit nicht unterstützten Daten die Ausnahme [CellUnsupportedDataException](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/cellunsupporteddataexception/) auslösen.

Falls Ihr Diagramm Excel‑Funktionen verwendet, die Aspose.Slides nicht auswertet, berechnen Sie diese Formeln mit einer Tabellen‑Engine, die sie unterstützt, und schreiben Sie die resultierenden Werte zurück in das Diagramm‑Arbeitsbuch. Ersetzen Sie nicht unterstützte Formeln durch geschätzte Werte.

## **Umgang mit Formel‑Fehlern**

Es gibt zwei unterschiedliche Arten von Problemen.

Eine Formel kann gültig sein, aber ein Tabellen‑Fehlerergebnis wie `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!` oder `#VALUE!` erzeugen. In diesem Fall ist das Fehlertoken ein Zell‑Ergebnis und kann über [ChartDataCell.getValue](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/chartdatacell/#getValue--) zurückgegeben werden.

Eine Formel kann außerdem beim Parsen, bei Referenzen, Abhängigkeiten oder im unterstützten‑Daten‑Bereich fehlschlagen. Aspose.Slides liefert dafür tabellenspezifische Ausnahmen: [CellInvalidFormulaException](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/cellcircularreferenceexception/) und [CellUnsupportedDataException](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/cellunsupporteddataexception/).

Wenn Formeln aus Vorlagen oder Benutzereingaben stammen, fangen Sie Fehler rund um die Neuberechnung und den Wertzugriff ab. Die Fehlerinformationen identifizieren das zugrunde liegende Tabellen‑Problem:

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

## **Praktische Einschränkungen**

Die Formelfunktionalität in Diagramm‑Arbeitsblättern ist für einen definierten Teilbereich von Tabellen‑Berechnungen gedacht, nicht für vollständige Excel‑Kompatibilität. Beachten Sie diese Beschränkungen beim Entwerfen eines Reporting‑Workflows:

- Verwenden Sie nur die dokumentierten Konstanten, Operatoren, Referenzen und Funktionen, wenn Aspose.Slides Formeln neu berechnen soll.
- Berechnen Sie neu, nachdem Sie Zellen geändert haben, von denen Formelergebnisse abhängen.
- Betrachten Sie zwischengespeicherte Werte aus geladenen Präsentationen als Schnappschüsse, nicht als Ersatz für eine Neuberechnung nach Änderungen.
- Testen Sie Formeln aus bestehenden Vorlagen, bevor Sie sich auf deren berechnete Werte verlassen, insbesondere wenn sie Funktionen außerhalb der dokumentierten Liste verwenden.
- Für Formeln, die eine vollständige Tabellen‑Berechnungs‑Engine erfordern, führen Sie die Berechnung extern durch und aktualisieren anschließend das Diagramm‑Arbeitsbuch mit den resultierenden Werten.

## **FAQ**

**Was ist der Unterschied zwischen [ChartDataCell.setFormula](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/chartdatacell/#setFormula-java.lang.String-) und [ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/chartdatacell/#setR1C1Formula-java.lang.String-)?**

[ChartDataCell.setFormula](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/chartdatacell/#setFormula-java.lang.String-) speichert einen A1‑Stil‑Ausdruck wie `B2-C2`. [ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/chartdatacell/#setR1C1Formula-java.lang.String-) speichert einen R1C1‑Stil‑Ausdruck wie `RC[-2]-RC[-1]`. Verwenden Sie die Notation, die am besten zu Ihrer Formel‑Erzeugung oder zum Kopieren passt.

**Muss ich nach der Berechnung die Zelle selbst oder ihren Wert lesen?**

[ChartDataWorkbook.getCell](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/chartdataworkbook/#getCell-int-java.lang.String-) liefert ein [ChartDataCell](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/chartdatacell/). Um das berechnete Ergebnis zu erhalten, rufen Sie nach der Neuberechnung die Methode [ChartDataCell.getValue](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/chartdatacell/#getValue--) dieser Zelle auf.

**Wann sollte ich [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--) aufrufen?**

Rufen Sie [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--) nach dem Ändern von Eingabewerten oder Formeln und bevor Sie von den berechneten Ergebnissen abhängen, auf. Dadurch werden die Werte der Formeln aktualisiert, die der integrierte Auswerter unterstützt.

**Unterstützt Aspose.Slides jede Excel‑Funktion?**

Nein. Der integrierte Auswerter unterstützt nur einen dokumentierten Teilbereich von Funktionen. Funktionen außerhalb dieses Teilbereichs sollten nicht als korrekt neu berechnet angenommen werden. Wenn volle Excel‑Formel‑Kompatibilität benötigt wird, führen Sie die Berechnung mit einer geeigneten Tabellen‑Engine durch und schreiben Sie die finalen Werte in das Diagramm‑Arbeitsbuch.

**Was passiert, wenn eine geladene Präsentation eine nicht unterstützte Formel enthält?**

Wenn die Diagrammdaten nicht geändert wurden, kann das Arbeitsbuch noch einen zuvor berechneten, zwischengespeicherten Wert enthalten. Nachdem zugehörige Daten geändert wurden, ist dieser zwischengespeicherte Wert möglicherweise nicht mehr gültig. Der Zugriff auf eine Zelle, deren Formel nicht verarbeitet werden kann, kann die Ausnahme [CellUnsupportedDataException](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/cellunsupporteddataexception/) auslösen.

**Sind Formel‑Fehlerwerte dasselbe wie Ausnahmen?**

Nein. Ein Ergebnis wie `#DIV/0!` ist ein Tabellenwert, der aus einer gültigen Berechnung resultiert. Ausnahmen wie [CellInvalidFormulaException](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/cellinvalidformulaexception/) oder [CellCircularReferenceException](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/cellcircularreferenceexception/) zeigen an, dass die Formel nicht regulär verarbeitet werden kann.

**Wird ein Diagramm automatisch aktualisiert, wenn sich eine Formel‑Zelle ändert?**

Eine Diagramm‑Serie kann auf Zellen des Arbeitsbuchs verweisen. Berechnen Sie zuerst das Arbeitsbuch neu und speichern oder rendern Sie dann die Präsentation. Verweisen die Diagrammdatenpunkte auf die berechneten Zellen, nutzt das Diagramm die aktualisierten Zellwerte; ein separater Diagramm‑Refresh‑Aufruf ist hierfür nicht erforderlich.

**Können Diagramme ein externes Excel‑Arbeitsbuch verwenden?**

Ja, Diagrammdaten können so konfiguriert werden, dass sie ein externes Arbeitsbuch über die Diagrammdaten‑API nutzen. Der in diesem Artikel beschriebene Formel‑Berechnungs‑Workflow bezieht sich jedoch auf das Diagramm‑Arbeitsbuch und den von Aspose.Slides ausgewerteten Formel‑Teilbereich. Gehen Sie nicht davon aus, dass [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--) eine vollständige Neuberechnung beliebiger Formeln in einer externen XLSX‑Datei durchführt.

**Kann ich Formeln verwenden, die auf ein anderes Arbeitsblatt oder Arbeitsbuch verweisen?**

Excel‑artige Referenzen können in Diagramm‑Arbeitsbüchern vorkommen, aber die Formelauswertung ist durch den unterstützten Parser und Funktionsumfang begrenzt. Wenn ein Querverweis über Arbeitsblätter oder ein externer Verweis essentiell ist, prüfen Sie die genaue Formel mit Ihrer Ziel‑Aspose.Slides‑Version. Für Workflows, die eine breite Excel‑Referenz‑Kompatibilität benötigen, berechnen Sie das Arbeitsbuch extern und schreiben die aufgelösten Werte zurück in die Diagrammdaten.

**Müssen Formelfehen mit `=` beginnen?**

Die Aspose.Slides‑API‑Beispiele weisen Ausdrücke wie `B2-C2` oder `SUM(B2:B5)` ohne führendes `=` zu. Die Verwendung dieser Form hält erzeugte Formeln konsistent mit den dokumentierten API‑Beispielen.
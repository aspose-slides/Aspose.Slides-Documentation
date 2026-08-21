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
- Diagramm-Daten-Arbeitsbuch
- Formel-Berechnung
- bevorzugte Kultur
- kulturspezifische Formel
- DBCS
- logische Konstante
- numerische Konstante
- Zeichenketten-Konstante
- Fehlerkonstante
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
description: "Excel-artige Formeln in Aspose.Slides für Node.js via Java-Diagramm-Arbeitsblätter anwenden, Werte neu berechnen und die Ergebnisse in PowerPoint-Diagrammen verwenden."
---
## **Übersicht**

PowerPoint‑Diagramme speichern ihre Quelldaten in der Regel in einem eingebetteten Arbeitsblatt. In Aspose.Slides für Node.js via Java können Sie über das ChartDataWorkbook auf dieses Arbeitsblatt zugreifen, Eingabewerte schreiben, Formeln Zellen zuweisen, unterstützte Formeln berechnen und die berechneten Zellen als Diagrammdaten verwenden.

Dieser Artikel erklärt den vollständigen Formel‑Workflow: Ein Diagramm erstellen, das Arbeitsblatt füllen, A1‑ oder R1C1‑Formeln zuweisen, sie neu berechnen, die berechneten Werte auslesen, diese Zellen einer Diagrammserie zuordnen und die Präsentation speichern. Außerdem werden die unterstützte Formelsyntax, die integrierte Funktionsuntermenge, zwischengespeicherte Werte, nicht unterstützte Formeln und tabellenspezifische Fehler beschrieben.

## **Diagramm‑Arbeitsblätter und Formeln**

Ein Diagramm‑Arbeitsblatt enthält die Kategorien, Seriennamen und Werte, die von einem Diagramm verwendet werden. In PowerPoint können Sie das Arbeitsblatt prüfen, indem Sie den Diagrammdaten‑Editor öffnen:

![PowerPoint‑Diagramm mit geöffnetem eingebettetem Arbeitsblatt, das Kategorie‑ und Seriendaten anzeigt](chart-worksheet-formulas_1.png)

In Aspose.Slides wird das Arbeitsblatt über die Klasse [ChartDataWorkbook](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/chartdataworkbook/) bereitgestellt. Verwenden Sie [ChartDataCell.setFormula](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/chartdatacell/#setFormula-java.lang.String-) für A1‑Formeln und [ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/chartdatacell/#setR1C1Formula-java.lang.String-) für R1C1‑Formeln. Nachdem Sie Eingabezellen oder Formeln geändert haben, rufen Sie [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--) auf, um unterstützte Formeln neu zu berechnen und die entsprechenden Zellenwerte zu aktualisieren.

Eine berechnete Zelle gibt ihr Ergebnis weiterhin über [ChartDataCell.getValue](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/chartdatacell/#getValue--) frei. Dies ist wichtig, wenn Sie ein Formel­ergebnis im Code prüfen oder die Zelle als Diagrammdatenpunkt verwenden müssen.

## **Diagramm erstellen und Arbeitsblatt‑Formeln berechnen**

Das folgende Beispiel demonstriert einen End‑to‑End‑Workflow. Es erstellt ein gruppiertes Säulendiagramm, löscht die Beispieldaten, schreibt Quartalsumsatz‑ und Ausgabenwerte, berechnet den Gewinn mit Formeln, liest die Ergebnisse, verwendet die berechneten Zellen als Diagrammwerte und speichert die Präsentation.

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

Die Diagrammdatenpunkte verweisen auf `D2:D4`, sodass das Diagramm die berechneten Gewinnwerte nutzt. Es gibt keinen separaten Aufruf zum Diagramm‑Refresh in diesem Workflow: Berechnen Sie zuerst das Arbeitsbuch, dann verwenden oder speichern Sie die Diagrammdaten, die auf die berechneten Zellen zeigen.

## **A1‑Stil‑Formeln verwenden**

Die A1‑Notation identifiziert Spalten mit Buchstaben und Zeilen mit Zahlen. Weisen Sie A1‑Ausdrücke über [ChartDataCell.setFormula](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/chartdatacell/#setFormula-java.lang.String-) zu.

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

Übliche A1‑Referenzformen sind:

| Referenz | Relativ | Absolut | Gemischt |
|---|---|---|---|
| Zelle | `A2` | `$A$2` | `A$2`, `$A2` |
| Zeile | `2:2` | `$2:$2` | — |
| Spalte | `A:A` | `$A:$A` | — |
| Bereich | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

Relative Verweise können sich ändern, wenn eine Formel von einer Tabellenkalkulations‑Anwendung verschoben oder kopiert wird. Absolute Verweise halten beide Koordinaten fest, gemischte Verweise fixieren nur eine Zeile oder eine Spalte.

## **R1C1‑Stil‑Formeln verwenden**

Die R1C1‑Notation identifiziert sowohl Zeilen als auch Spalten numerisch. Relative Verweise verwenden Offsets in eckigen Klammern. Weisen Sie diese Syntax über [ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/chartdatacell/#setR1C1Formula-java.lang.String-) zu.

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

Übliche R1C1‑Referenzformen sind:

| Referenz | Relativ | Absolut | Gemischt |
|---|---|---|---|
| Zelle | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| Zeile | `R[2]` | `R2` | — |
| Spalte | `C[3]` | `C3` | — |
| Bereich | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

Beispielsweise bedeutet in Zelle `D2` `RC[-2]` die Zelle in derselben Zeile, zwei Spalten links (`B2`).

## **Formelkonstanten und Operatoren**

Der integrierte Formelauswerter unterstützt logische Werte, numerische Literale, Zeichenketten, tabellenspezifische Fehlervarianten, arithmetische Operatoren und Vergleichsoperatoren.

### **Konstanten und Literale**

| Typ | Beispiele | Hinweise |
|---|---|---|
| Logisch | `TRUE`, `FALSE` | Können direkt in logischen Ausdrücken wie `A2=TRUE` verwendet werden. |
| Numerisch | `1`, `0.5`, `.3`, `1E-2` | Dezimal‑ und Wissenschaftsschreibweise werden unterstützt. |
| String | `"abc"`, `"2/3/2020 12:00"` | Text‑Literal‑Werte werden in Anführungszeichen innerhalb der Formel geschrieben. |
| Fehlerergebnis | `#DIV/0!`, `#N/A`, `#REF!` | Eine gültige Formel kann anstelle eines normalen Ergebnisses einen Tabellen‑Fehlerwert ergeben. |

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
| `+` | Addition oder unäres Plus | `2+3` |
| `-` | Subtraktion oder Negation | `2-3`, `-3` |
| `*` | Multiplikation | `2*3` |
| `/` | Division | `2/3` |
| `%` | Prozent | `30%` |
| `^` | Exponentiation | `2^3` |

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

Aspose.Slides enthält einen integrierten Formelauswerter für Diagramm‑Arbeitsblätter, ist jedoch keine vollständige Excel‑Berechnungs‑Engine. Der dokumentierte Funktionsumfang ist auf die nachfolgend aufgelisteten Funktionen beschränkt. Gehen Sie nicht davon aus, dass eine beliebige Excel‑Funktion von [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--) neu berechnet werden kann.

| Funktion | Zweck oder unterstützte Form | Beispiel |
|---|---|---|
| `ABS` | Betrag | `ABS(A2)` |
| `AVERAGE` | Arithmetischer Mittelwert | `AVERAGE(B2:B5)` |
| `CEILING` | Auf ein Vielfaches aufrunden | `CEILING(A2,5)` |
| `CHOOSE` | Wert nach Index auswählen | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | Textwerte verbinden | `CONCAT(A2,B2)` |
| `CONCATENATE` | Textwerte verbinden | `CONCATENATE(A2," ",B2)` |
| `DATE` | Datumswert nach 1900‑System erzeugen | `DATE(2026,8,19)` |
| `DAYS` | Anzahl der Tage zwischen Daten | `DAYS(B2,A2)` |
| `FIND` | Text in anderem Text finden | `FIND("-",A2)` |
| `FINDB` | Byte‑orientierte Textsuche | `FINDB("a",A2)` |
| `IF` | Bedingtes Ergebnis | `IF(A2>0,A2,0)` |
| `INDEX` | Referenzform | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | Vektorform | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | Vektorform | `MATCH(A2,B2:B5,0)` |
| `MAX` | Maximalwert | `MAX(B2:B5)` |
| `SUM` | Summe | `SUM(B2:B5)` |
| `VLOOKUP` | Vertikaler SVerweis | `VLOOKUP(A2,B2:D10,3,FALSE)` |

Die in der Tabelle gezeigten Einschränkungen sind bedeutsam: `INDEX` wird in Referenzform dokumentiert, während `LOOKUP` und `MATCH` in ihrer Vektorform beschrieben werden. `DATE` verwendet das 1900‑Datumsystem. Funktionen, die hier nicht aufgelistet sind, sollten als nicht unterstützt vom Aspose.Slides‑Formelauswerter behandelt werden, sofern sie nicht gesondert dokumentiert sind.

## **Formeln mit bevorzugter Kultur berechnen**

Einige Arbeitsbuch‑Funktionen interpretieren Text nach kulturspezifischen Regeln. Das ist besonders wichtig für Funktionen, die für Sprachen mit DBCS (Double‑Byte‑Character‑Set) gedacht sind. Um solche Formeln korrekt zu berechnen, erstellen Sie ein [LoadOptions](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/loadoptions/)-Objekt, setzen die bevorzugte Kultur mit [SpreadsheetOptions.setPreferredCulture](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/spreadsheetoptions/#setPreferredCulture), weisen die Tabellen‑Optionen über [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/loadoptions/#setSpreadsheetOptions) zu und laden anschließend die Präsentation.

Das folgende Beispiel wählt die japanische Kultur, öffnet eine Präsentation mit den konfigurierten Lademöglichkeiten und ruft [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--) für jedes Diagramm‑Arbeitsbuch auf:

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

Die bevorzugte Kultur ist Teil der Präsentations‑Lade‑Konfiguration, also geben Sie sie an, bevor Sie ein [Presentation](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/)‑Objekt erstellen. Verwenden Sie die Kultur, die von den Arbeitsbuch‑Formeln erwartet wird; beispielsweise `ja-JP` für Formeln, die japanische DBCS‑Berechnungsregeln anwenden.

## **Neuberechnung und zwischengespeicherte Werte**

Tabellendateien speichern häufig sowohl die Formel als auch deren zuletzt berechneten Wert. Aspose.Slides kann daher einen zwischengespeicherten Wert über [ChartDataCell.getValue](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/chartdatacell/#getValue--) lesen, wenn eine Präsentation geladen wird und die zugehörigen Diagrammdaten nicht verändert wurden.

Nachdem Sie Eingabezellen oder Formeln geändert haben, dürfen Sie sich nicht auf ein altes zwischengespeichertes Ergebnis verlassen. Rufen Sie [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--) auf, bevor Sie berechnete Werte lesen oder Diagrammdaten speichern, die von ihnen abhängen.

Für Formeln außerhalb des unterstützten Teilbereichs kann Aspose.Slides die Formel möglicherweise nicht parsen oder ihre Abhängigkeiten ermitteln. Wenn das Arbeitsbuch geändert wurde, ist der vorherige zwischengespeicherte Wert nicht mehr zuverlässig. In diesem Fall kann das Lesen des Werts einer Zelle mit nicht unterstützten Daten die Ausnahme [CellUnsupportedDataException](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/cellunsupporteddataexception/) auslösen.

Wenn Ihr Diagramm auf Excel‑Funktionen angewiesen ist, die Aspose.Slides nicht auswertet, berechnen Sie diese Formeln mit einer Tabellen‑Engine, die sie unterstützt, und schreiben Sie die resultierenden Werte zurück in das Diagramm‑Arbeitsbuch. Ersetzen Sie nicht‑unterstützte Formeln durch geschätzte Werte.

## **Formelfehler behandeln**

Es gibt zwei unterschiedliche Arten von Problemen zu unterscheiden.

Eine Formel kann gültig sein, aber ein Tabellen‑Fehlergebnis wie `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!` oder `#VALUE!` erzeugen. In diesem Fall ist das Fehlertoken ein Zellen‑Ergebnis und kann über [ChartDataCell.getValue](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/chartdatacell/#getValue--) zurückgegeben werden.

Eine Formel kann zudem beim Parsen, beim Verweis, bei Abhängigkeiten oder wegen nicht unterstützter Daten scheitern. Aspose.Slides bietet hierfür tabellenspezifische Ausnahmen: [CellInvalidFormulaException](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/cellcircularreferenceexception/) und [CellUnsupportedDataException](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/cellunsupporteddataexception/).

Wenn Formeln aus Vorlagen oder Benutzereingaben stammen, fangen Sie Fehler rund um die Neuberechnung und den Wertzugriff ab. Die Fehlerdetails zeigen das zugrunde liegende Tabellen‑Problem an:

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

Die Formelunterstützung in Diagramm‑Arbeitsblättern ist für einen definierten Teilbereich von Tabellenberechnungen gedacht, nicht für vollständige Excel‑Kompatibilität. Beachten Sie diese Einschränkungen bei der Planung eines Reporting‑Workflows:

- Verwenden Sie ausschließlich die dokumentierten Konstanten, Operatoren, Verweise und Funktionen, wenn Aspose.Slides die Formeln neu berechnen soll.
- Berechnen Sie nach Änderungen von Zellen, von denen das Formel­ergebnis abhängt, neu.
- Betrachten Sie zwischengespeicherte Werte aus geladenen Präsentationen als Schnappschüsse, nicht als Ersatz für eine Neu­berechnung nach Änderungen.
- Testen Sie Formeln aus vorhandenen Vorlagen, bevor Sie sich auf ihre berechneten Werte verlassen, insbesondere wenn sie Funktionen außerhalb der dokumentierten Liste verwenden.
- Für Formeln, die eine vollständige Tabellen‑Berechnungs‑Engine benötigen, berechnen Sie sie extern und aktualisieren anschließend das Diagramm‑Arbeitsbuch mit den resultierenden Werten.

## **FAQ**

**Was ist der Unterschied zwischen [ChartDataCell.setFormula](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/chartdatacell/#setFormula-java.lang.String-) und [ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/chartdatacell/#setR1C1Formula-java.lang.String-)?**

[ChartDataCell.setFormula](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/chartdatacell/#setFormula-java.lang.String-) speichert einen A1‑Stil‑Ausdruck wie `B2-C2`. [ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/chartdatacell/#setR1C1Formula-java.lang.String-) speichert einen R1C1‑Stil‑Ausdruck wie `RC[-2]-RC[-1]`. Verwenden Sie die Notation, die am besten zu Ihrer Formel‑Erzeugung oder -Kopie passt.

**Muss ich die Zelle selbst oder ihren Wert nach der Berechnung lesen?**

[ChartDataWorkbook.getCell](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/chartdataworkbook/#getCell-int-java.lang.String-) liefert ein [ChartDataCell](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/chartdatacell/). Um das berechnete Ergebnis zu erhalten, rufen Sie nach der Neuberechnung die Methode [ChartDataCell.getValue](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/chartdatacell/#getValue--) der Zelle auf.

**Wann sollte ich [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--) aufrufen?**

Rufen Sie [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--) nach Änderungen von Eingabewerten oder Formeln und bevor Sie von den berechneten Ergebnissen abhängen, auf. Dadurch werden die Werte aller Formeln, die der integrierte Auswerter unterstützt, aktualisiert.

**Unterstützt Aspose.Slides jede Excel‑Funktion?**

Nein. Der integrierte Auswerter unterstützt nur eine dokumentierte Teilmenge von Funktionen. Funktionen außerhalb dieser Teilmenge sollten nicht als korrekt neu berechnet vorausgesetzt werden. Wenn volle Excel‑Formel‑Kompatibilität erforderlich ist, führen Sie die Berechnung mit einer geeigneten Tabellen‑Engine durch und schreiben Sie die Endwerte in das Diagramm‑Arbeitsbuch.

**Was passiert, wenn eine geladene Präsentation eine nicht unterstützte Formel enthält?**

Falls die Diagrammdaten nicht geändert wurden, kann das Arbeitsbuch noch einen zuvor berechneten, zwischengespeicherten Wert enthalten. Nach einer Modifikation der zugehörigen Daten ist dieser Wert möglicherweise nicht mehr gültig. Der Zugriff auf eine Zelle, deren Formel nicht verarbeitet werden kann, kann die Ausnahme [CellUnsupportedDataException](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/cellunsupporteddataexception/) auslösen.

**Sind Formelfehlerwerte dasselbe wie Ausnahmen?**

Nein. Ein Ergebnis wie `#DIV/0!` ist ein Tabellenwert, der durch eine gültige Berechnung erzeugt wurde. Ausnahmen wie [CellInvalidFormulaException](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/cellinvalidformulaexception/) oder [CellCircularReferenceException](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/cellcircularreferenceexception/) weisen darauf hin, dass die Formel nicht regulär verarbeitet werden kann.

**Wird ein Diagramm automatisch aktualisiert, wenn sich eine Formelzelle ändert?**

Eine Diagrammserie kann auf Arbeitsbuch‑Zellen verweisen. Berechnen Sie das Arbeitsbuch zuerst, und speichern oder rendern Sie dann die Präsentation. Wenn die Diagrammdatenpunkte die berechneten Zellen referenzieren, nutzt das Diagramm die aktualisierten Zellwerte; ein separater Diagramm‑Refresh‑Aufruf ist für diesen Workflow nicht erforderlich.

**Können Diagramme ein externes Excel‑Arbeitsbuch verwenden?**

Ja, Diagrammdaten können so konfiguriert werden, dass sie ein externes Arbeitsbuch über die Diagrammdaten‑API nutzen. Der in diesem Artikel beschriebene Formel‑Berechnungs‑Workflow bezieht sich jedoch ausschließlich auf das Diagramm‑Arbeitsbuch und den von Aspose.Slides ausgewerteten Funktions‑Teilbereich. Gehen Sie nicht davon aus, dass [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--) eine vollständige Neuberechnung beliebiger Formeln in einer externen XLSX‑Datei liefert.

**Kann ich Formeln verwenden, die ein anderes Arbeitsblatt oder Arbeitsbuch referenzieren?**

Excel‑artige Verweise können in Diagramm‑Arbeitsbüchern vorkommen, aber die Formelauswertung ist durch den unterstützten Parser und Funktionsumfang eingeschränkt. Wenn ein bereichs‑ oder externes Verweis unverzichtbar ist, prüfen Sie die genaue Formel mit Ihrer Ziel‑Aspose.Slides‑Version. Für Workflows, die eine umfassende Excel‑Referenz‑Kompatibilität erfordern, berechnen Sie das Arbeitsbuch extern und schreiben die aufgelösten Werte zurück in die Diagrammdaten.

**Müssen Formelzeichenketten mit `=` beginnen?**

Die Aspose.Slides‑API‑Beispiele setzen Ausdrücke wie `B2-C2` oder `SUM(B2:B5)` ohne führendes `=` ein. Die Verwendung dieser Form hält generierte Formeln konsistent mit den dokumentierten API‑Beispielen.
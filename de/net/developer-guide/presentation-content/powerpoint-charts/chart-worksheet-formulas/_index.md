---
title: Diagramm‑Arbeitsblatt‑Formeln in Präsentationen in .NET anwenden
linktitle: Arbeitsblatt‑Formeln
type: docs
weight: 70
url: /de/net/chart-worksheet-formulas/
keywords:
- Diagramm‑Tabellenkalkulation
- Diagramm‑Arbeitsblatt
- Diagramm‑Formel
- Arbeitsblatt‑Formel
- Tabellenkalkulations‑Formel
- Diagramm‑Daten‑Arbeitsmappe
- Formel‑Berechnung
- Logische Konstante
- Numerische Konstante
- Zeichenketten‑Konstante
- Fehlerkonstante
- Arithmetischer Operator
- Vergleichsoperator
- A1‑Stil
- R1C1‑Stil
- Vordefinierte Funktion
- PowerPoint
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Excel‑ähnliche Formeln in Aspose.Slides für .NET Diagramm‑Arbeitsblätter anwenden, Werte neu berechnen und die Ergebnisse in PowerPoint‑Diagrammen verwenden."
---
## **Übersicht**

PowerPoint‑Diagramme speichern ihre Quelldaten in der Regel in einem eingebetteten Arbeitsblatt. In Aspose.Slides für .NET können Sie über die Chart‑Daten‑Arbeitsmappe auf dieses Arbeitsblatt zugreifen, Eingabewerte schreiben, Formeln Zellen zuweisen, unterstützte Formeln berechnen und die berechneten Zellen als Diagrammdaten verwenden.

Dieser Artikel erklärt den vollständigen Formel‑Workflow: Erstellen eines Diagramms, Befüllen des Arbeitsblatts, Zuweisen von A1‑ oder R1C1‑Formeln, erneutes Berechnen, Auslesen der berechneten Werte, Verbinden dieser Zellen mit einer Diagramm‑Serie und Speichern der Präsentation. Er beschreibt außerdem die unterstützte Formelsyntax, den integrierten Funktionsumfang, zwischengespeicherte Werte, nicht unterstützte Formeln und tabellenspezifische Fehler.

## **Diagramm‑Arbeitsblätter und Formeln**

Ein Diagramm‑Arbeitsblatt enthält die Kategorien, Seriennamen und Werte, die von einem Diagramm verwendet werden. In PowerPoint können Sie das Arbeitsblatt anzeigen, indem Sie den Diagrammdaten‑Editor öffnen:

![PowerPoint‑Diagramm mit geöffnetem eingebettetem Arbeitsblatt, das Kategorien‑ und Seriendaten zeigt](chart-worksheet-formulas_1.png)

In Aspose.Slides wird das Arbeitsblatt über das [Chart‑Data‑Workbook](https://reference.aspose.com/slides/de/net/aspose.slides.charts/ichartdataworkbook/) bereitgestellt. Verwenden Sie die [Formula](https://reference.aspose.com/slides/de/net/aspose.slides.charts/ichartdatacell/formula/)-Eigenschaft für A1‑Formeln und die [R1C1Formula](https://reference.aspose.com/slides/de/net/aspose.slides.charts/ichartdatacell/r1c1formula/)-Eigenschaft für R1C1‑Formeln. Nachdem Sie Eingabezellen oder Formeln geändert haben, rufen Sie [CalculateFormulas](https://reference.aspose.com/slides/de/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/) auf, um unterstützte Formeln neu zu berechnen und die entsprechenden Zellenwerte zu aktualisieren.

Eine berechnete Zelle stellt ihr Ergebnis weiterhin über die [Value](https://reference.aspose.com/slides/de/net/aspose.slides.charts/ichartdatacell/value/)-Eigenschaft bereit. Das ist wichtig, wenn Sie ein Formelergebnis im Code inspizieren oder die Zelle als Diagrammdatenpunkt verwenden müssen.

## **Erstellen eines Diagramms und Berechnen von Arbeitsblatt‑Formeln**

Das folgende Beispiel demonstriert einen End‑to‑End‑Workflow. Es erstellt ein gruppiertes Säulendiagramm, löscht die Beispieldaten, schreibt Quartals‑Umsatz‑ und Kostenwerte, berechnet den Gewinn mit Formeln, liest die Ergebnisse, verwendet die berechneten Zellen als Diagrammwerte und speichert die Präsentation.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 350);
var workbook = chart.ChartData.ChartDataWorkbook;
var worksheetIndex = 0;

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();
workbook.Clear(worksheetIndex);

var category1 = workbook.GetCell(worksheetIndex, "A2", "Q1");
var category2 = workbook.GetCell(worksheetIndex, "A3", "Q2");
var category3 = workbook.GetCell(worksheetIndex, "A4", "Q3");

workbook.GetCell(worksheetIndex, "B1", "Revenue");
workbook.GetCell(worksheetIndex, "C1", "Expenses");
workbook.GetCell(worksheetIndex, "D1", "Profit");

workbook.GetCell(worksheetIndex, "B2").Value = 120.0;
workbook.GetCell(worksheetIndex, "C2").Value = 80.0;
workbook.GetCell(worksheetIndex, "B3").Value = 150.0;
workbook.GetCell(worksheetIndex, "C3").Value = 95.0;
workbook.GetCell(worksheetIndex, "B4").Value = 135.0;
workbook.GetCell(worksheetIndex, "C4").Value = 110.0;

var profit1 = workbook.GetCell(worksheetIndex, "D2");
var profit2 = workbook.GetCell(worksheetIndex, "D3");
var profit3 = workbook.GetCell(worksheetIndex, "D4");

profit1.Formula = "B2-C2";
profit2.Formula = "B3-C3";
profit3.Formula = "B4-C4";

workbook.CalculateFormulas();

var q1Profit = Convert.ToDouble(profit1.Value); // 40
var q2Profit = Convert.ToDouble(profit2.Value); // 55
var q3Profit = Convert.ToDouble(profit3.Value); // 25

Console.WriteLine($"Q1 profit: {q1Profit}");
Console.WriteLine($"Q2 profit: {q2Profit}");
Console.WriteLine($"Q3 profit: {q3Profit}");

chart.ChartData.Categories.Add(category1);
chart.ChartData.Categories.Add(category2);
chart.ChartData.Categories.Add(category3);

var profitSeries = chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, "D1"), chart.Type);
profitSeries.DataPoints.AddDataPointForBarSeries(profit1);
profitSeries.DataPoints.AddDataPointForBarSeries(profit2);
profitSeries.DataPoints.AddDataPointForBarSeries(profit3);
profitSeries.Labels.DefaultDataLabelFormat.ShowValue = true;

presentation.Save("chart-formulas.pptx", SaveFormat.Pptx);
```

Die Diagrammpunkte verweisen auf `D2:D4`, sodass das Diagramm die berechneten Gewinnwerte nutzt. Es gibt keinen separaten Diagramm‑Aktualisierungsaufruf in diesem Workflow: Berechnen Sie zuerst die Arbeitsmappe, dann verwenden oder speichern Sie die Diagrammdaten, die auf die berechneten Zellen verweisen.

## **Verwenden von A1‑Formeln**

Die A1‑Notation identifiziert Spalten mit Buchstaben und Zeilen mit Zahlen. Weisen Sie A1‑Ausdrücke über [IChartDataCell.Formula](https://reference.aspose.com/slides/de/net/aspose.slides.charts/ichartdatacell/formula/) zu.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 300);
var workbook = chart.ChartData.ChartDataWorkbook;

workbook.GetCell(0, "C3").Value = 10;
workbook.GetCell(0, "F2").Value = 2;
workbook.GetCell(0, "G2").Value = 3;
workbook.GetCell(0, "H2").Value = 4;

var cell = workbook.GetCell(0, "A2");
cell.Formula = "C3+SUM(F2:H2)";

workbook.CalculateFormulas();

var value = cell.Value; // 19
```

Übliche A1‑Bezugformen sind:

| Bezug | Relativ | Absolut | Gemischt |
|---|---|---|---|
| Zelle | `A2` | `$A$2` | `A$2`, `$A2` |
| Zeile | `2:2` | `$2:$2` | — |
| Spalte | `A:A` | `$A:$A` | — |
| Bereich | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

Relative Bezüge können sich ändern, wenn eine Formel von einer Tabellenkalkulations‑Anwendung verschoben oder kopiert wird. Absolute Bezüge halten beide Koordinaten fest, während gemischte Bezüge nur eine Zeile oder eine Spalte fixieren.

## **Verwenden von R1C1‑Formeln**

Die R1C1‑Notation identifiziert sowohl Zeilen als auch Spalten numerisch. Relative Bezüge nutzen Offsets in eckigen Klammern. Weisen Sie diese Syntax über [IChartDataCell.R1C1Formula](https://reference.aspose.com/slides/de/net/aspose.slides.charts/ichartdatacell/r1c1formula/) zu.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 300);
var workbook = chart.ChartData.ChartDataWorkbook;

workbook.GetCell(0, "B2").Value = 12;
workbook.GetCell(0, "C2").Value = 5;

var cell = workbook.GetCell(0, "D2");
cell.R1C1Formula = "RC[-2]-RC[-1]";

workbook.CalculateFormulas();

var value = cell.Value; // 7
```

Übliche R1C1‑Bezugformen sind:

| Bezug | Relativ | Absolut | Gemischt |
|---|---|---|---|
| Zelle | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| Zeile | `R[2]` | `R2` | — |
| Spalte | `C[3]` | `C3` | — |
| Bereich | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

Beispiel: In Zelle `D2` bedeutet `RC[-2]` die Zelle in derselben Zeile zwei Spalten nach links (`B2`).

## **Formel‑Konstanten und Operatoren**

Der integrierte Formelauswerter unterstützt logische Werte, numerische Literale, Zeichenketten, Tabellen‑Fehlerwerte, arithmetische Operatoren und Vergleichsoperatoren.

### **Konstanten und Literale**

| Typ | Beispiele | Hinweise |
|---|---|---|
| Logisch | `TRUE`, `FALSE` | Können direkt in logischen Ausdrücken wie `A2=TRUE` verwendet werden. |
| Numerisch | `1`, `0.5`, `.3`, `1E-2` | Dezimal‑ und wissenschaftliche Schreibweise werden unterstützt. |
| Zeichenkette | `"abc"`, `"2/3/2020 12:00"` | Text‑Literal wird innerhalb der Formel in doppelte Anführungszeichen gesetzt. |
| Fehlerwert | `#DIV/0!`, `#N/A`, `#REF!` | Eine gültige Formel kann statt eines normalen Ergebnisses einen Tabellen‑Fehlerwert ergeben. |

Dieses Beispiel verwendet mehrere Konstantentypen:

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 300);
var workbook = chart.ChartData.ChartDataWorkbook;

workbook.GetCell(0, "A2").Value = false;
workbook.GetCell(0, "B2").Formula = "A2=TRUE";
workbook.GetCell(0, "C2").Formula = "1+0.5";
workbook.GetCell(0, "D2").Formula = ".3*1E-2";
workbook.GetCell(0, "E2").Formula = "\"abc\"";
workbook.GetCell(0, "F2").Formula = "2/0";

workbook.CalculateFormulas();

var logicalValue = workbook.GetCell(0, "B2").Value; // Falsch
var numericValue = workbook.GetCell(0, "C2").Value; // 1.5
var scientificValue = workbook.GetCell(0, "D2").Value; // 0.003
var stringValue = workbook.GetCell(0, "E2").Value; // abc
var errorValue = workbook.GetCell(0, "F2").Value; // #DIV/0!
```

### **Arithmetische Operatoren**

| Operator | Bedeutung | Beispiel |
|---|---|---|
| `+` | Addition oder unäres Plus | `2+3` |
| `-` | Subtraktion oder Negation | `2-3`, `-3` |
| `*` | Multiplikation | `2*3` |
| `/` | Division | `2/3` |
| `%` | Prozent | `30%` |
| `^` | Potenzierung | `2^3` |

Verwenden Sie Klammern, um die Auswertungsreihenfolge explizit zu machen, z. B. `(A2+B2)*C2`.

### **Vergleichsoperatoren**

Vergleichsausdrücke liefern logische Werte.

| Operator | Bedeutung | Beispiel |
|---|---|---|
| `=` | Gleich | `A2=3` |
| `<>` | Ungleich | `A2<>3` |
| `>` | Größer als | `A2>3` |
| `>=` | Größer‑gleich | `A2>=3` |
| `<` | Kleiner als | `A2<3` |
| `<=` | Kleiner‑gleich | `A2<=3` |

## **Unterstützte vordefinierte Funktionen**

Aspose.Slides enthält einen integrierten Formelauswerter für Diagramm‑Arbeitsblätter, ist jedoch kein vollständiger Excel‑Berechnungs‑Engine. Der dokumentierte Funktionsumfang ist auf die untenstehenden Funktionen beschränkt. Gehen Sie nicht davon aus, dass eine beliebige Excel‑Funktion von [CalculateFormulas](https://reference.aspose.com/slides/de/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/) neu berechnet werden kann.

| Funktion | Zweck oder unterstützte Form | Beispiel |
|---|---|---|
| `ABS` | Absolutwert | `ABS(A2)` |
| `AVERAGE` | Arithmetisches Mittel | `AVERAGE(B2:B5)` |
| `CEILING` | Auf ein Vielfaches aufrunden | `CEILING(A2,5)` |
| `CHOOSE` | Wert nach Index auswählen | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | Textwerte verbinden | `CONCAT(A2,B2)` |
| `CONCATENATE` | Textwerte verbinden | `CONCATENATE(A2," ",B2)` |
| `DATE` | Datum mit 1900‑Datumsystem erzeugen | `DATE(2026,8,19)` |
| `DAYS` | Anzahl der Tage zwischen Daten | `DAYS(B2,A2)` |
| `FIND` | Text in anderem Text finden | `FIND("-",A2)` |
| `FINDB` | Byte‑orientierte Textsuche | `FINDB("a",A2)` |
| `IF` | Bedingtes Ergebnis | `IF(A2>0,A2,0)` |
| `INDEX` | Referenz‑Form | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | Vektor‑Form | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | Vektor‑Form | `MATCH(A2,B2:B5,0)` |
| `MAX` | Maximalwert | `MAX(B2:B5)` |
| `SUM` | Summe | `SUM(B2:B5)` |
| `VLOOKUP` | Vertikaler SVERWEIS | `VLOOKUP(A2,B2:D10,3,FALSE)` |

Die in der Tabelle gezeigten Einschränkungen sind wesentlich: `INDEX` wird in Referenz‑Form dokumentiert, während `LOOKUP` und `MATCH` in ihrer Vektor‑Form angegeben werden. `DATE` nutzt das 1900‑Datumsystem. Funktionen, die hier nicht aufgeführt sind, sollten als nicht unterstützt vom Aspose.Slides‑Formelauswerter betrachtet werden, sofern sie nicht gesondert dokumentiert sind.

## **Neuberechnung und zwischengespeicherte Werte**

Tabellendateien speichern häufig sowohl die Formel als auch den zuletzt berechneten Wert. Aspose.Slides kann daher beim Laden einer Präsentation den zwischengespeicherten Wert aus [IChartDataCell.Value](https://reference.aspose.com/slides/de/net/aspose.slides.charts/ichartdatacell/value/) lesen, solange die zugehörigen Diagrammdaten nicht geändert wurden.

Nachdem Sie Eingabezellen oder Formeln geändert haben, dürfen Sie sich nicht auf ein altes zwischengespeichertes Ergebnis verlassen. Rufen Sie [IChartDataWorkbook.CalculateFormulas](https://reference.aspose.com/slides/de/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/) auf, bevor Sie berechnete Werte lesen oder Diagrammdaten speichern, die von ihnen abhängen.

Für Formeln außerhalb des unterstützten Teilbereichs kann Aspose.Slides die Formel ggf. nicht parsen oder ihre Abhängigkeiten ermitteln. Wenn die Arbeitsmappe geändert wurde, ist der vorherige Zwischenspeicherwert nicht mehr zuverlässig. In diesem Fall kann das Auslesen des Werts einer Zelle mit nicht unterstützten Daten die Ausnahme [CellUnsupportedDataException](https://reference.aspose.com/slides/de/net/aspose.slides.spreadsheet/cellunsupporteddataexception/) auslösen.

Wenn Ihr Diagramm Excel‑Funktionen verwendet, die Aspose.Slides nicht auswertet, berechnen Sie diese Formeln mit einer Tabellen‑Engine, die sie unterstützt, und schreiben die Ergebnisse zurück in die Diagramm‑Arbeitsmappe. Ersetzen Sie nicht unterstützte Formeln durch geschätzte Werte.

## **Umgang mit Formel‑Fehlern**

Es gibt zwei verschiedene Arten von Problemen, die zu unterscheiden sind.

Eine Formel kann gültig sein, aber ein Tabellen‑Fehlerergebnis wie `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!` oder `#VALUE!` erzeugen. In diesem Fall ist das Fehlertoken ein Zellen‑Ergebnis und kann über `Value` zurückgegeben werden.

Eine Formel kann außerdem beim Parsen, beim Bezug, bei Abhängigkeiten oder bei unterstützten Daten fehlschlagen. Aspose.Slides stellt dafür tabellenspezifische Ausnahmen bereit: [CellInvalidFormulaException](https://reference.aspose.com/slides/de/net/aspose.slides.spreadsheet/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/de/net/aspose.slides.spreadsheet/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/de/net/aspose.slides.spreadsheet/cellcircularreferenceexception/) und [CellUnsupportedDataException](https://reference.aspose.com/slides/de/net/aspose.slides.spreadsheet/cellunsupporteddataexception/).

Wenn Formeln aus Vorlagen oder Benutzereingaben stammen, behandeln Sie diese Ausnahmen rund um die Neuberechnung und den Wertezugriff:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Spreadsheet;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 300);
var workbook = chart.ChartData.ChartDataWorkbook;
var cell = workbook.GetCell(0, "A2");
cell.Formula = "SUM(B2:B5)";

try
{
    workbook.CalculateFormulas();
    Console.WriteLine(cell.Value);
}
catch (CellInvalidFormulaException ex)
{
    Console.Error.WriteLine($"Invalid formula: {ex.Message}");
}
catch (CellInvalidReferenceException ex)
{
    Console.Error.WriteLine($"Invalid cell reference: {ex.Message}");
}
catch (CellCircularReferenceException ex)
{
    Console.Error.WriteLine($"Circular reference: {ex.Message}");
}
catch (CellUnsupportedDataException ex)
{
    Console.Error.WriteLine($"Unsupported spreadsheet data: {ex.Message}");
}
```

## **Praktische Beschränkungen**

Die Formelunterstützung in Diagramm‑Arbeitsblättern ist für einen definierten Teilbereich von Tabellenberechnungen gedacht, nicht für vollständige Excel‑Kompatibilität. Berücksichtigen Sie diese Einschränkungen beim Entwurf eines Reporting‑Workflows:

- Verwenden Sie nur die dokumentierten Konstanten, Operatoren, Bezüge und Funktionen, wenn Aspose.Slides die Formeln neu berechnen soll.
- Berechnen Sie nach Änderungen von Zellen, von denen Formel­ergebnisse abhängen, neu.
- Betrachten Sie zwischengespeicherte Werte aus geladenen Präsentationen als Momentaufnahmen, nicht als Ersatz für eine Neuberechnung nach Änderungen.
- Testen Sie Formeln aus bestehenden Vorlagen, bevor Sie sich auf deren berechnete Werte verlassen, insbesondere wenn sie Funktionen außerhalb der dokumentierten Liste nutzen.
- Für Formeln, die einen vollständigen Tabellen‑Berechnungs‑Engine benötigen, berechnen Sie sie extern und aktualisieren anschließend das Diagramm‑Arbeitsblatt mit den resultierenden Werten.

## **FAQ**

**Was ist der Unterschied zwischen `Formula` und `R1C1Formula`?**

[Formula](https://reference.aspose.com/slides/de/net/aspose.slides.charts/ichartdatacell/formula/) speichert einen A1‑Ausdruck wie `B2-C2`. [R1C1Formula](https://reference.aspose.com/slides/de/net/aspose.slides.charts/ichartdatacell/r1c1formula/) speichert einen R1C1‑Ausdruck wie `RC[-2]-RC[-1]`. Verwenden Sie die Notation, die am besten zu Ihrer Art der Formelerstellung oder -kopie passt.

**Muss ich nach der Berechnung die Zelle selbst oder deren Wert lesen?**

[IChartDataWorkbook.GetCell](https://reference.aspose.com/slides/de/net/aspose.slides.charts/ichartdataworkbook/getcell/) liefert ein `IChartDataCell`. Um das berechnete Ergebnis zu erhalten, lesen Sie nach der Neuberechnung die [Value](https://reference.aspose.com/slides/de/net/aspose.slides.charts/ichartdatacell/value/)-Eigenschaft dieser Zelle.

**Wann sollte ich `CalculateFormulas` aufrufen?**

Rufen Sie [CalculateFormulas](https://reference.aspose.com/slides/de/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/) nach Änderungen von Eingabewerten oder Formeln und bevor Sie von den berechneten Ergebnissen abhängen, auf. Damit werden die Werte der Formeln aktualisiert, die der integrierte Auswerter unterstützt.

**Unterstützt Aspose.Slides jede Excel‑Funktion?**

Nein. Der integrierte Auswerter unterstützt nur einen dokumentierten Teilbereich von Funktionen. Funktionen außerhalb dieses Teilbereichs sollten nicht als korrekt neu berechnet angesehen werden. Wenn vollständige Excel‑Formel‑Kompatibilität erforderlich ist, führen Sie die Berechnung mit einer geeigneten Tabellen‑Engine durch und schreiben die endgültigen Werte in das Diagramm‑Arbeitsblatt.

**Was passiert, wenn eine geladene Präsentation eine nicht unterstützte Formel enthält?**

Wenn die Diagrammdaten nicht geändert wurden, kann die Arbeitsmappe noch einen zuvor berechneten zwischengespeicherten Wert enthalten. Nachdem die zugehörigen Daten geändert wurden, ist dieser Zwischenspeicherwert möglicherweise nicht mehr gültig. Der Zugriff auf eine Zelle, deren Formel nicht verarbeitet werden kann, kann die Ausnahme [CellUnsupportedDataException](https://reference.aspose.com/slides/de/net/aspose.slides.spreadsheet/cellunsupporteddataexception/) auslösen.

**Sind Formel‑Fehlerwerte das Gleiche wie .NET‑Ausnahmen?**

Nein. Ein Ergebnis wie `#DIV/0!` ist ein Tabellenwert, der durch eine gültige Berechnung erzeugt wird. Ausnahmen wie [CellInvalidFormulaException](https://reference.aspose.com/slides/de/net/aspose.slides.spreadsheet/cellinvalidformulaexception/) oder [CellCircularReferenceException](https://reference.aspose.com/slides/de/net/aspose.slides.spreadsheet/cellcircularreferenceexception/) weisen darauf hin, dass die Formel nicht normal verarbeitet werden kann.

**Wird ein Diagramm automatisch aktualisiert, wenn sich der Wert einer Formelzelle ändert?**

Eine Diagramm‑Serie kann Arbeitsblatt‑Zellen referenzieren. Berechnen Sie zuerst die Arbeitsmappe neu und speichern oder rendern Sie dann die Präsentation. Wenn die Diagrammpunkte die berechneten Zellen referenzieren, nutzt das Diagramm die aktualisierten Zellwerte; ein separater Diagramm‑Refresh‑Aufruf ist für diesen Workflow nicht erforderlich.

**Können Diagramme ein externes Excel‑Arbeitsblatt verwenden?**

Ja, Diagrammdaten können so konfiguriert werden, dass sie ein externes Arbeitsblatt über die Diagramm‑Daten‑API nutzen. Der in diesem Artikel beschriebene Formel‑Berechnungs‑Workflow bezieht sich jedoch auf das Diagramm‑Arbeitsblatt und den von Aspose.Slides ausgewerteten Formel‑Teilbereich. Gehen Sie nicht davon aus, dass [CalculateFormulas](https://reference.aspose.com/slides/de/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/) eine vollständige Neuberechnung beliebiger Formeln in einer externen XLSX‑Datei durchführt.

**Kann ich Formeln verwenden, die ein anderes Arbeitsblatt oder eine andere Arbeitsmappe referenzieren?**

Excel‑ähnliche Bezüge können in Diagramm‑Arbeitsblättern vorkommen, aber die Formel‑Auswertung ist durch den unterstützten Parser und Funktionsumfang begrenzt. Wenn ein Bezug über mehrere Tabellenblätter oder externe Arbeitsmappen wesentlich ist, prüfen Sie die genaue Formel mit Ihrer Zielversion von Aspose.Slides. Für Workflows, die eine umfassende Excel‑Bezugskompatibilität erfordern, berechnen Sie die Arbeitsmappe extern und schreiben die aufgelösten Werte zurück in die Diagrammdaten.

**Müssen Formel‑Zeichenketten mit `=` beginnen?**

Die Aspose.Slides‑API‑Beispiele weisen Ausdrücke wie `B2-C2` oder `SUM(B2:B5)` ohne führendes `=` zu. Die Verwendung dieser Form hält erzeugte Formeln konsistent mit den dokumentierten API‑Beispielen.
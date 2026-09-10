---
title: Diagramm‑Arbeitsblatt‑Formeln in Präsentationen mit Python via Java anwenden
linktitle: Arbeitsblatt‑Formeln
type: docs
weight: 70
url: /de/python-java/chart-worksheet-formulas/
keywords:
- Diagramm‑Tabellenkalkulation
- Diagramm‑Arbeitsblatt
- Diagramm‑Formel
- Arbeitsblatt‑Formel
- Tabellenkalkulations‑Formel
- Diagramm‑Daten‑Arbeitsmappe
- Formel‑Berechnung
- Bevorzugte Kultur
- Kulturspezifische Formel
- DBCS
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
- Python
- Java
- Aspose.Slides
description: "Excel‑ähnliche Formeln in Aspose.Slides für Python via Java Diagramm‑Arbeitsblätter anwenden, Werte neu berechnen und die Ergebnisse in PowerPoint‑Diagrammen verwenden."
---
## **Übersicht**

PowerPoint-Diagramme speichern ihre Quelldaten normalerweise in einem eingebetteten Arbeitsblatt. In Aspose.Slides für Python via Java können Sie über das ChartDataWorkbook auf dieses Arbeitsblatt zugreifen, Eingabewerte schreiben, Formeln Zellen zuweisen, unterstützte Formeln berechnen und die berechneten Zellen als Diagrammdaten verwenden.

Dieser Artikel erklärt den vollständigen Formel‑Workflow: ein Diagramm erstellen, sein Arbeitsblatt befüllen, A1‑ oder R1C1‑Formeln zuweisen, sie neu berechnen, die berechneten Werte lesen, diese Zellen mit einer Diagramm‑Serie verbinden und die Präsentation speichern. Außerdem wird die unterstützte Formelsyntax, die eingebaute Funktionsuntermenge, zwischengespeicherte Werte, nicht unterstützte Formeln und tabellenspezifische Fehler beschrieben.

## **Diagramm‑Arbeitsblätter und Formeln**

Ein Diagramm‑Arbeitsblatt enthält die Kategorien, Seriennamen und Werte, die von einem Diagramm verwendet werden. In PowerPoint können Sie das Arbeitsblatt inspizieren, indem Sie den Diagrammdaten‑Editor öffnen:

![PowerPoint chart with its embedded worksheet open, showing category and series data](chart-worksheet-formulas_1.png)

In Aspose.Slides wird das Arbeitsblatt über die Klasse [ChartDataWorkbook](https://reference.aspose.com/slides/de/python-java/aspose.slides/chartdataworkbook/) bereitgestellt. Verwenden Sie [ChartDataCell.setFormula](https://reference.aspose.com/slides/de/python-java/aspose.slides/chartdatacell/#setFormula) für A1‑Formeln und [ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/de/python-java/aspose.slides/chartdatacell/#setR1C1Formula) für R1C1‑Formeln. Nachdem Sie Eingabezellen oder Formeln geändert haben, rufen Sie [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/de/python-java/aspose.slides/chartdataworkbook/#calculateFormulas) auf, um unterstützte Formeln neu zu berechnen und die entsprechenden Zellenwerte zu aktualisieren.

Eine berechnete Zelle gibt ihr Ergebnis weiterhin über [ChartDataCell.getValue](https://reference.aspose.com/slides/de/python-java/aspose.slides/chartdatacell/#getValue) zurück. Das ist wichtig, wenn Sie das Formelresultat im Code prüfen oder die Zelle als Diagrammdatenpunkt verwenden müssen.

## **Ein Diagramm erstellen und Arbeitsblatt‑Formeln berechnen**

Das folgende Beispiel demonstriert einen End‑zu‑End‑Workflow. Es erstellt ein gruppiertes Säulendiagramm, löscht die Beispieldaten, schreibt Quartalsumsatz‑ und -ausgabewerte, berechnet den Gewinn mit Formeln, liest die Ergebnisse, verwendet die berechneten Zellen als Diagrammw wert und speichert die Präsentation.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 350)
    workbook = chart.getChartData().getChartDataWorkbook()
    worksheet_index = 0

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()
    workbook.clear(worksheet_index)

    category1 = workbook.getCell(worksheet_index, "A2", "Q1")
    category2 = workbook.getCell(worksheet_index, "A3", "Q2")
    category3 = workbook.getCell(worksheet_index, "A4", "Q3")

    workbook.getCell(worksheet_index, "B1", "Revenue")
    workbook.getCell(worksheet_index, "C1", "Expenses")
    workbook.getCell(worksheet_index, "D1", "Profit")

    workbook.getCell(worksheet_index, "B2").setValue(120.0)
    workbook.getCell(worksheet_index, "C2").setValue(80.0)
    workbook.getCell(worksheet_index, "B3").setValue(150.0)
    workbook.getCell(worksheet_index, "C3").setValue(95.0)
    workbook.getCell(worksheet_index, "B4").setValue(135.0)
    workbook.getCell(worksheet_index, "C4").setValue(110.0)

    profit1 = workbook.getCell(worksheet_index, "D2")
    profit2 = workbook.getCell(worksheet_index, "D3")
    profit3 = workbook.getCell(worksheet_index, "D4")

    profit1.setFormula("B2-C2")
    profit2.setFormula("B3-C3")
    profit3.setFormula("B4-C4")

    workbook.calculateFormulas()

    q1_profit = float(profit1.getValue()) # 40
    q2_profit = float(profit2.getValue()) # 55
    q3_profit = float(profit3.getValue()) # 25

    print("Q1 profit: ", q1_profit)
    print("Q2 profit: ", q2_profit)
    print("Q3 profit: ", q3_profit)

    chart.getChartData().getCategories().add(category1)
    chart.getChartData().getCategories().add(category2)
    chart.getChartData().getCategories().add(category3)

    profit_series = chart.getChartData().getSeries().add(workbook.getCell(worksheet_index, "D1"), chart.getType())
    profit_series.getDataPoints().addDataPointForBarSeries(profit1)
    profit_series.getDataPoints().addDataPointForBarSeries(profit2)
    profit_series.getDataPoints().addDataPointForBarSeries(profit3)
    profit_series.getLabels().getDefaultDataLabelFormat().setShowValue(True)

    presentation.save("chart-formulas.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Die Diagrammdatenpunkte verweisen auf `D2:D4`, sodass das Diagramm die berechneten Gewinnwerte nutzt. Es gibt in diesem Workflow keinen separaten Diagramm‑Aktualisierungsaufruf: Berechnen Sie zuerst das Arbeitsblatt, dann verwenden oder speichern Sie die Diagrammdaten, die auf die berechneten Zellen verweisen.

## **A1‑Formeln verwenden**

Die A1‑Notation identifiziert Spalten mit Buchstaben und Zeilen mit Zahlen. Weisen Sie A1‑Ausdrücke über [ChartDataCell.setFormula](https://reference.aspose.com/slides/de/python-java/aspose.slides/chartdatacell/#setFormula) zu.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300)
    workbook = chart.getChartData().getChartDataWorkbook()

    workbook.getCell(0, "C3").setValue(10)
    workbook.getCell(0, "F2").setValue(2)
    workbook.getCell(0, "G2").setValue(3)
    workbook.getCell(0, "H2").setValue(4)

    cell = workbook.getCell(0, "A2")
    cell.setFormula("C3+SUM(F2:H2)")

    workbook.calculateFormulas()

    value = cell.getValue() # 19
finally:
    presentation.dispose()
```

Gängige A1‑Bezugsformen sind:

| Bezug | Relativ | Absolut | Gemischt |
|---|---|---|---|
| Zelle | `A2` | `$A$2` | `A$2`, `$A2` |
| Zeile | `2:2` | `$2:$2` | — |
| Spalte | `A:A` | `$A:$A` | — |
| Bereich | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

Relative Bezüge können sich ändern, wenn eine Formel von einer Tabellenkalkulations‑Anwendung verschoben oder kopiert wird. Absolute Bezüge halten beide Koordinaten fest, während gemischte Bezüge nur eine Zeile oder eine Spalte fixieren.

## **R1C1‑Formeln verwenden**

Die R1C1‑Notation identifiziert sowohl Zeilen als auch Spalten numerisch. Relative Bezüge verwenden Offsets in eckigen Klammern. Verwenden Sie diese Syntax über [ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/de/python-java/aspose.slides/chartdatacell/#setR1C1Formula).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300)
    workbook = chart.getChartData().getChartDataWorkbook()

    workbook.getCell(0, "B2").setValue(12)
    workbook.getCell(0, "C2").setValue(5)

    cell = workbook.getCell(0, "D2")
    cell.setR1C1Formula("RC[-2]-RC[-1]")

    workbook.calculateFormulas()

    value = cell.getValue() # 7
finally:
    presentation.dispose()
```

Gängige R1C1‑Bezugsformen sind:

| Bezug | Relativ | Absolut | Gemischt |
|---|---|---|---|
| Zelle | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| Zeile | `R[2]` | `R2` | — |
| Spalte | `C[3]` | `C3` | — |
| Bereich | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

Beispiel: In Zelle `D2` bedeutet `RC[-2]` die Zelle in derselben Zeile zwei Spalten links (`B2`).

## **Formelkonstanten und Operatoren**

Der eingebaute Formelevaluator unterstützt logische Werte, numerische Literale, Zeichenketten, Tabellen‑Fehlerwerte, arithmetische Operatoren und Vergleichsoperatoren.

### **Konstanten und Literale**

| Typ | Beispiele | Hinweis |
|---|---|---|
| Logisch | `TRUE`, `FALSE` | Kann direkt in logischen Ausdrücken wie `A2=TRUE` verwendet werden. |
| Numerisch | `1`, `0.5`, `.3`, `1E-2` | Dezimal‑ und wissenschaftliche Notation werden unterstützt. |
| Zeichenkette | `"abc"`, `"2/3/2020 12:00"` | Text‑Literal wird innerhalb der Formel in doppelte Anführungszeichen gesetzt. |
| Fehlerwert | `#DIV/0!`, `#N/A`, `#REF!` | Eine gültige Formel kann anstelle eines normalen Ergebnisses zu einem Tabellen‑Fehlerwert auswerten. |

Dieses Beispiel verwendet mehrere Konstantentypen:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300)
    workbook = chart.getChartData().getChartDataWorkbook()

    workbook.getCell(0, "A2").setValue(False)
    workbook.getCell(0, "B2").setFormula("A2=TRUE")
    workbook.getCell(0, "C2").setFormula("1+0.5")
    workbook.getCell(0, "D2").setFormula(".3*1E-2")
    workbook.getCell(0, "E2").setFormula("\"abc\"")
    workbook.getCell(0, "F2").setFormula("2/0")

    workbook.calculateFormulas()

    logical_value = workbook.getCell(0, "B2").getValue() # Falsch
    numeric_value = workbook.getCell(0, "C2").getValue() # 1.5
    scientific_value = workbook.getCell(0, "D2").getValue() # 0.003
    string_value = workbook.getCell(0, "E2").getValue() # abc
    error_value = workbook.getCell(0, "F2").getValue() # #DIV/0!
finally:
    presentation.dispose()
```

### **Arithmetische Operatoren**

| Operator | Bedeutung | Beispiel |
|---|---|---|
| `+` | Addition oder Vorzeichen plus | `2+3` |
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
| `>=` | Größer‑ oder gleich | `A2>=3` |
| `<` | Kleiner als | `A2<3` |
| `<=` | Kleiner‑ oder gleich | `A2<=3` |

## **Unterstützte vordefinierte Funktionen**

Aspose.Slides enthält einen eingebauten Formelevaluator für Diagramm‑Arbeitsblätter, ist jedoch keine vollständige Excel‑Berechnungs‑Engine. Der dokumentierte Funktionsumfang ist auf die untenstehenden Funktionen beschränkt. Gehen Sie nicht davon aus, dass eine beliebige Excel‑Funktion von [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/de/python-java/aspose.slides/chartdataworkbook/#calculateFormulas) neu berechnet werden kann.

| Funktion | Zweck oder unterstützte Form | Beispiel |
|---|---|---|
| `ABS` | Absolutwert | `ABS(A2)` |
| `AVERAGE` | Arithmetisches Mittel | `AVERAGE(B2:B5)` |
| `CEILING` | Auf ein Vielfaches aufrunden | `CEILING(A2,5)` |
| `CHOOSE` | Wert nach Index auswählen | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | Textwerte verketten | `CONCAT(A2,B2)` |
| `CONCATENATE` | Textwerte verketten | `CONCATENATE(A2," ",B2)` |
| `DATE` | Datumswert im 1900‑Datumssystem erzeugen | `DATE(2026,8,19)` |
| `DAYS` | Anzahl der Tage zwischen Daten zurückgeben | `DAYS(B2,A2)` |
| `FIND` | Textwert in anderem finden | `FIND("-",A2)` |
| `FINDB` | Byte‑orientierte Textsuche | `FINDB("a",A2)` |
| `IF` | Bedingtes Ergebnis | `IF(A2>0,A2,0)` |
| `INDEX` | Bezug‑form | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | Vektorform | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | Vektorform | `MATCH(A2,B2:B5,0)` |
| `MAX` | Maximalwert | `MAX(B2:B5)` |
| `SUM` | Summieren | `SUM(B2:B5)` |
| `VLOOKUP` | Vertikaler Suchen | `VLOOKUP(A2,B2:D10,3,FALSE)` |

Die in der Tabelle gezeigten Einschränkungen sind bedeutend: `INDEX` wird in Bezug‑Form dokumentiert, während `LOOKUP` und `MATCH` in ihrer Vektorform dokumentiert sind. `DATE` verwendet das 1900‑Datumsystem. Funktionen, die hier nicht aufgeführt sind, sollten als nicht unterstützt vom Aspose.Slides‑Formelevaluator gelten, sofern sie nicht gesondert dokumentiert werden.

## **Formeln mit bevorzugter Kultur berechnen**

Einige Arbeitsblatt‑Funktionen interpretieren Text nach kulturspezifischen Regeln. Das ist besonders wichtig für Funktionen, die für Sprachen mit doppelbyte‑Zeichensätzen (DBCS) gedacht sind. Um solche Formeln korrekt zu berechnen, erstellen Sie ein [LoadOptions](https://reference.aspose.com/slides/de/python-java/aspose.slides/loadoptions/), setzen die bevorzugte Kultur mit [SpreadsheetOptions.setPreferredCulture](https://reference.aspose.com/slides/de/python-java/aspose.slides/spreadsheetoptions/#setPreferredCulture), weisen die Tabellenoptionen über [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/de/python-java/aspose.slides/loadoptions/#setSpreadsheetOptions) zu und laden anschließend die Präsentation.

Das folgende Beispiel wählt die japanische Kultur aus, öffnet eine Präsentation mit den konfigurierten Ladeoptionen und ruft [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/de/python-java/aspose.slides/chartdataworkbook/#calculateFormulas) für jedes Diagramm‑Arbeitsbuch auf:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, LoadOptions, Presentation, SpreadsheetOptions
from java.util import Locale

japanese_culture = Locale.forLanguageTag("ja-JP")

spreadsheet_options = SpreadsheetOptions()
spreadsheet_options.setPreferredCulture(japanese_culture)

load_options = LoadOptions()
load_options.setSpreadsheetOptions(spreadsheet_options)

presentation = Presentation("presentation.pptx", load_options)
try:
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if isinstance(shape, Chart):
                shape.getChartData().getChartDataWorkbook().calculateFormulas()
finally:
    presentation.dispose()
```

Die bevorzugte Kultur ist Teil der Präsentations‑Ladekonfiguration, daher geben Sie sie an, bevor Sie eine Instanz von [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/) erstellen. Verwenden Sie die Kultur, die von den Arbeitsblatt‑Formeln erwartet wird; z. B. `ja-JP` für Formeln, die japanische DBCS‑Berechnungsregeln befolgen sollen.

## **Neuberechnung und zwischengespeicherte Werte**

Tabellendateien speichern häufig sowohl eine Formel als auch ihren zuletzt berechneten Wert. Aspose.Slides kann daher beim Laden einer Präsentation einen zwischengespeicherten Wert aus [ChartDataCell.getValue](https://reference.aspose.com/slides/de/python-java/aspose.slides/chartdatacell/#getValue) lesen, sofern die zugehörigen Diagrammdaten nicht geändert wurden.

Nachdem Sie Eingabezellen oder Formeln geändert haben, verlassen Sie sich nicht auf ein altes zwischengespeichertes Ergebnis. Rufen Sie [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/de/python-java/aspose.slides/chartdataworkbook/#calculateFormulas) auf, bevor Sie berechnete Werte lesen oder Diagrammdaten speichern, die von ihnen abhängen.

Für Formeln außerhalb des unterstützten Teilbereichs kann Aspose.Slides die Formel möglicherweise nicht parsen oder deren Abhängigkeiten bestimmen. Wenn das Arbeitsbuch modifiziert wurde, ist der vorherige zwischengespeicherte Wert nicht mehr zuverlässig. In diesem Fall kann das Lesen des Wertes einer Zelle mit nicht unterstützten Daten die Ausnahme [CellUnsupportedDataException](https://reference.aspose.com/slides/de/python-java/aspose.slides/cellunsupporteddataexception/) auslösen.

Wenn Ihr Diagramm Excel‑Funktionen verwendet, die Aspose.Slides nicht auswertet, berechnen Sie diese Formeln mit einer Tabellen‑Engine, die sie unterstützt, und schreiben Sie die resultierenden Werte zurück in das Diagramm‑Arbeitsbuch. Ersetzen Sie nicht unterstützte Formeln durch geschätzte Werte.

## **Formel‑Fehler behandeln**

Es gibt zwei unterschiedliche Arten von Problemen zu unterscheiden.

Eine Formel kann gültig sein, aber ein Tabellen‑Fehlerergebnis wie `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!` oder `#VALUE!` erzeugen. In diesem Fall ist das Fehler‑Token ein Zellen‑Ergebnis und kann über [ChartDataCell.getValue](https://reference.aspose.com/slides/de/python-java/aspose.slides/chartdatacell/#getValue) zurückgegeben werden.

Eine Formel kann auch beim Parsen, Referenzieren, bei Abhängigkeiten oder auf Ebene unterstützter Daten fehlschlagen. Aspose.Slides stellt hierfür tabellenspezifische Ausnahmen bereit: [CellInvalidFormulaException](https://reference.aspose.com/slides/de/python-java/aspose.slides/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/de/python-java/aspose.slides/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/de/python-java/aspose.slides/cellcircularreferenceexception/) und [CellUnsupportedDataException](https://reference.aspose.com/slides/de/python-java/aspose.slides/cellunsupporteddataexception/).

Wenn Formeln aus Vorlagen oder Benutzereingaben stammen, fangen Sie diese Ausnahmen beim Neuberechnen und beim Zugriff auf Werte ab:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CellCircularReferenceException, CellInvalidFormulaException, CellInvalidReferenceException, CellUnsupportedDataException, ChartType, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300)
    workbook = chart.getChartData().getChartDataWorkbook()
    cell = workbook.getCell(0, "A2")
    cell.setFormula("SUM(B2:B5)")

    try:
        workbook.calculateFormulas()
        print(cell.getValue())
    except CellInvalidFormulaException as ex:
        print("Invalid formula: " + str(ex.getMessage()))
    except CellInvalidReferenceException as ex:
        print("Invalid cell reference: " + str(ex.getMessage()))
    except CellCircularReferenceException as ex:
        print("Circular reference: " + str(ex.getMessage()))
    except CellUnsupportedDataException as ex:
        print("Unsupported spreadsheet data: " + str(ex.getMessage()))
finally:
    presentation.dispose()
```

## **Praktische Einschränkungen**

Die Formelunterstützung in Diagramm‑Arbeitsblättern ist für einen definierten Teilbereich von Tabellenkalkulations‑Berechnungen gedacht, nicht für vollständige Excel‑Kompatibilität. Berücksichtigen Sie diese Beschränkungen beim Entwerfen eines Reporting‑Workflows:

- Verwenden Sie nur die dokumentierten Konstanten, Operatoren, Bezüge und Funktionen, wenn Aspose.Slides Formeln neu berechnen soll.
- Rechnen Sie nach Änderungen von Zellen, von denen Formel‑Ergebnisse abhängen, neu.
- Betrachten Sie zwischengespeicherte Werte aus geladenen Präsentationen als Schnappschüsse, nicht als Ersatz für die Neuberechnung nach Änderungen.
- Testen Sie Formeln aus bestehenden Vorlagen, bevor Sie sich auf deren berechnete Werte verlassen, insbesondere wenn sie Funktionen außerhalb der dokumentierten Liste verwenden.
- Für Formeln, die eine vollständige Tabellen‑Berechnungs‑Engine erfordern, führen Sie die Berechnung extern durch und aktualisieren anschließend das Diagramm‑Arbeitsbuch mit den resultierenden Werten.

## **FAQ**

**Was ist der Unterschied zwischen [ChartDataCell.setFormula](https://reference.aspose.com/slides/de/python-java/aspose.slides/chartdatacell/#setFormula) und [ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/de/python-java/aspose.slides/chartdatacell/#setR1C1Formula)?**

[ChartDataCell.setFormula](https://reference.aspose.com/slides/de/python-java/aspose.slides/chartdatacell/#setFormula) speichert einen A1‑Ausdruck wie `B2-C2`. [ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/de/python-java/aspose.slides/chartdatacell/#setR1C1Formula) speichert einen R1C1‑Ausdruck wie `RC[-2]-RC[-1]`. Verwenden Sie die Notation, die am besten zu Ihrer Erzeugungs‑ oder Kopierweise von Formeln passt.

**Muss ich nach der Berechnung die Zelle selbst oder ihren Wert lesen?**

[ChartDataWorkbook.getCell](https://reference.aspose.com/slides/de/python-java/aspose.slides/chartdataworkbook/#getCell) gibt ein [ChartDataCell](https://reference.aspose.com/slides/de/python-java/aspose.slides/chartdatacell/) zurück. Um das berechnete Ergebnis zu erhalten, rufen Sie nach der Neuberechnung die Methode [ChartDataCell.getValue](https://reference.aspose.com/slides/de/python-java/aspose.slides/chartdatacell/#getValue) dieser Zelle auf.

**Wann sollte ich [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/de/python-java/aspose.slides/chartdataworkbook/#calculateFormulas) aufrufen?**

Rufen Sie [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/de/python-java/aspose.slides/chartdataworkbook/#calculateFormulas) nach Änderungen von Eingabewerten oder Formeln und bevor Sie von den berechneten Ergebnissen abhängig sind, auf. Dadurch werden die Werte von Formeln aktualisiert, die vom eingebauten Evaluator unterstützt werden.

**Unterstützt Aspose.Slides jede Excel‑Funktion?**

Nein. Der eingebaute Evaluator unterstützt nur einen dokumentierten Teilbereich von Funktionen. Funktionen außerhalb dieses Teilbereichs sollten nicht als korrekt neu berechnet angenommen werden. Wenn vollständige Excel‑Formel‑Kompatibilität erforderlich ist, führen Sie die Berechnung mit einer geeigneten Tabellen‑Engine durch und schreiben Sie die Endwerte in das Diagramm‑Arbeitsbuch.

**Was passiert, wenn eine geladene Präsentation eine nicht unterstützte Formel enthält?**

Wenn die Diagrammdaten nicht geändert wurden, kann das Arbeitsbuch noch einen zuvor berechneten zwischengespeicherten Wert enthalten. Nach einer Änderung der zugehörigen Daten ist dieser zwischengespeicherte Wert möglicherweise nicht mehr gültig. Der Zugriff auf eine Zelle, deren Formel nicht verarbeitet werden kann, kann die Ausnahme [CellUnsupportedDataException](https://reference.aspose.com/slides/de/python-java/aspose.slides/cellunsupporteddataexception/) auslösen.

**Sind Formel‑Fehlerwerte dasselbe wie Ausnahmen?**

Nein. Ein Ergebnis wie `#DIV/0!` ist ein Tabellenwert, der durch eine gültige Berechnung erzeugt wurde. Ausnahmen wie [CellInvalidFormulaException](https://reference.aspose.com/slides/de/python-java/aspose.slides/cellinvalidformulaexception/) oder [CellCircularReferenceException](https://reference.aspose.com/slides/de/python-java/aspose.slides/cellcircularreferenceexception/) zeigen an, dass die Formel nicht regulär verarbeitet werden kann.

**Aktualisiert ein Diagramm automatisch, wenn sich eine Formel‑Zelle ändert?**

Eine Diagramm‑Serie kann auf Arbeitsblatt‑Zellen verweisen. Berechnen Sie zuerst das Arbeitsblatt, dann speichern oder rendern Sie die Präsentation. Wenn die Diagrammdatenpunkte auf die berechneten Zellen verweisen, verwendet das Diagramm diese aktualisierten Zellwerte; ein separater Diagramm‑Aktualisierungs‑Aufruf ist für diesen Workflow nicht erforderlich.

**Können Diagramme ein externes Excel‑Arbeitsbuch verwenden?**

Ja, Diagrammdaten können über die Diagrammdaten‑API so konfiguriert werden, dass sie ein externes Arbeitsbuch nutzen. Der in diesem Artikel beschriebene Formel‑Berechnungs‑Workflow bezieht sich jedoch auf das Diagramm‑Arbeitsbuch und den von Aspose.Slides ausgewerteten Funktions‑Teilbereich. Gehen Sie nicht davon aus, dass [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/de/python-java/aspose.slides/chartdataworkbook/#calculateFormulas) eine vollständige Neuberechnung beliebiger Formeln in einer externen XLSX‑Datei liefert.

**Kann ich Formeln verwenden, die auf ein anderes Arbeitsblatt oder Arbeitsbuch verweisen?**

Excel‑artige Verweise können in Diagramm‑Arbeitsbüchern existieren, aber die Formelauswertung ist durch den unterstützten Parser und Funktionsumfang begrenzt. Wenn ein übergreifender Blatt‑ oder externer Verweis erforderlich ist, prüfen Sie die exakte Formel mit Ihrer Ziel‑Aspose.Slides‑Version. Für Workflows, die breite Excel‑Verweis‑Kompatibilität benötigen, berechnen Sie das Arbeitsbuch extern und schreiben die aufgelösten Werte zurück in die Diagrammdaten.

**Müssen Formel‑Strings mit `=` beginnen?**

Die Aspose.Slides‑API‑Beispiele weisen Ausdrücke wie `B2-C2` oder `SUM(B2:B5)` ohne führendes `=` zu. Die Verwendung dieser Form bewahrt die Konsistenz der generierten Formeln mit den dokumentierten API‑Beispielen.
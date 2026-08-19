---
title: Diagramm‑Arbeitsblatt‑Formeln in Präsentationen mit Python anwenden
linktitle: Arbeitsblatt-Formeln
type: docs
weight: 70
url: /de/python-net/chart-worksheet-formulas/
keywords:
- Diagramm‑Tabellenkalkulation
- Diagramm‑Arbeitsblatt
- Diagramm‑Formel
- Arbeitsblatt‑Formel
- Tabellenkalkulations‑Formel
- Diagramm‑Daten‑Arbeitsmappe
- Formel‑Berechnung
- logische Konstante
- numerische Konstante
- Zeichenketten‑Konstante
- Fehler‑Konstante
- arithmetischer Operator
- Vergleichsoperator
- A1‑Stil
- R1C1‑Stil
- vordefinierte Funktion
- PowerPoint
- Präsentation
- Python
- Aspose.Slides
description: "Excel‑artige Formeln in Aspose.Slides für Python über .NET‑Diagramm‑Arbeitsblätter anwenden, Werte neu berechnen und die Ergebnisse in PowerPoint‑Diagrammen verwenden."
---
## **Übersicht**

PowerPoint‑Diagramme speichern ihre Quelldaten in der Regel in einem eingebetteten Arbeitsblatt. In Aspose.Slides für Python via .NET können Sie über die Diagrammdaten‑Arbeitsmappe auf dieses Arbeitsblatt zugreifen, Eingabewerte schreiben, Formeln in Zellen zuweisen, unterstützte Formeln berechnen und die berechneten Zellen als Diagrammdaten verwenden.

Dieser Artikel erklärt den kompletten Formel‑Workflow: Erstellen eines Diagramms, Befüllen des Arbeitsblatts, Zuweisen von A1‑ oder R1C1‑Formeln, Neuberechnen, Auslesen der berechneten Werte, Verbinden dieser Zellen mit einer Diagrammreihe und Speichern der Präsentation. Außerdem werden die unterstützte Formelsyntax, das eingebaute Funktions‑Subset, zwischengespeicherte Werte, nicht unterstützte Formeln und tabellenspezifische Fehler beschrieben.

## **Diagramm‑Arbeitsblätter und Formeln**

Ein Diagramm‑Arbeitsblatt enthält die Kategorien, Reihen‑Namen und Werte, die von einem Diagramm verwendet werden. In PowerPoint können Sie das Arbeitsblatt inspizieren, indem Sie den Diagrammdaten‑Editor öffnen:

![PowerPoint‑Diagramm mit geöffnetem eingebettetem Arbeitsblatt, das Kategorien‑ und Reihen‑Daten zeigt](chart-worksheet-formulas_1.png)

In Aspose.Slides wird das Arbeitsblatt über die [Diagrammdaten‑Arbeitsmappe](https://reference.aspose.com/slides/de/python-net/aspose.slides.charts/ichartdataworkbook/) bereitgestellt. Verwenden Sie die [formula](https://reference.aspose.com/slides/de/python-net/aspose.slides.charts/ichartdatacell/formula/)‑Eigenschaft für A1‑Formeln und die [r1c1_formula](https://reference.aspose.com/slides/de/python-net/aspose.slides.charts/ichartdatacell/r1c1_formula/)‑Eigenschaft für R1C1‑Formeln. Nachdem Sie Eingabezellen oder Formeln geändert haben, rufen Sie [calculate_formulas](https://reference.aspose.com/slides/de/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/) auf, um unterstützte Formeln neu zu berechnen und die entsprechenden Zellenwerte zu aktualisieren.

Eine berechnete Zelle liefert ihr Ergebnis weiterhin über die [value](https://reference.aspose.com/slides/de/python-net/aspose.slides.charts/ichartdatacell/value/)‑Eigenschaft. Das ist wichtig, wenn Sie ein Formel­ergebnis im Code inspizieren oder die Zelle als Diagrammdatenpunkt verwenden müssen.

## **Ein Diagramm erstellen und Arbeitsblatt‑Formeln berechnen**

Das folgende Beispiel demonstriert einen End‑zu‑End‑Workflow. Es erzeugt ein gruppiertes Säulendiagramm, löscht die Beispieldaten, schreibt quartalsweise Umsatz‑ und Aufwandswerte, berechnet den Gewinn mit Formeln, liest die Ergebnisse aus, verwendet die berechneten Zellen als Diagrammwwerte und speichert die Präsentation.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 350)
    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()
    workbook.clear(worksheet_index)

    category1 = workbook.get_cell(worksheet_index, "A2", "Q1")
    category2 = workbook.get_cell(worksheet_index, "A3", "Q2")
    category3 = workbook.get_cell(worksheet_index, "A4", "Q3")

    workbook.get_cell(worksheet_index, "B1", "Revenue")
    workbook.get_cell(worksheet_index, "C1", "Expenses")
    workbook.get_cell(worksheet_index, "D1", "Profit")

    workbook.get_cell(worksheet_index, "B2").value = 120.0
    workbook.get_cell(worksheet_index, "C2").value = 80.0
    workbook.get_cell(worksheet_index, "B3").value = 150.0
    workbook.get_cell(worksheet_index, "C3").value = 95.0
    workbook.get_cell(worksheet_index, "B4").value = 135.0
    workbook.get_cell(worksheet_index, "C4").value = 110.0

    profit1 = workbook.get_cell(worksheet_index, "D2")
    profit2 = workbook.get_cell(worksheet_index, "D3")
    profit3 = workbook.get_cell(worksheet_index, "D4")

    profit1.formula = "B2-C2"
    profit2.formula = "B3-C3"
    profit3.formula = "B4-C4"

    workbook.calculate_formulas()

    q1_profit = profit1.value  # 40
    q2_profit = profit2.value  # 55
    q3_profit = profit3.value  # 25

    print(f"Q1 profit: {q1_profit}")
    print(f"Q2 profit: {q2_profit}")
    print(f"Q3 profit: {q3_profit}")

    chart.chart_data.categories.add(category1)
    chart.chart_data.categories.add(category2)
    chart.chart_data.categories.add(category3)

    profit_series = chart.chart_data.series.add(workbook.get_cell(worksheet_index, "D1"), chart.type)
    profit_series.data_points.add_data_point_for_bar_series(profit1)
    profit_series.data_points.add_data_point_for_bar_series(profit2)
    profit_series.data_points.add_data_point_for_bar_series(profit3)
    profit_series.labels.default_data_label_format.show_value = True

    presentation.save("chart-formulas.pptx", slides.export.SaveFormat.PPTX)
```

Die Diagrammdatenpunkte verweisen auf `D2:D4`, sodass das Diagramm die berechneten Gewinnwerte nutzt. Es gibt keinen separaten Aufruf zum Diagramm‑Aktualisieren in diesem Workflow: Berechnen Sie zuerst die Arbeitsmappe, dann verwenden oder speichern Sie die Diagrammdaten, die auf die berechneten Zellen verweisen.

## **A1‑Style‑Formeln verwenden**

Die A1‑Notation identifiziert Spalten mit Buchstaben und Zeilen mit Zahlen. Weisen Sie A1‑Ausdrücke über [IChartDataCell.formula](https://reference.aspose.com/slides/de/python-net/aspose.slides.charts/ichartdatacell/formula/) zu.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 300)
    workbook = chart.chart_data.chart_data_workbook

    workbook.get_cell(0, "C3").value = 10
    workbook.get_cell(0, "F2").value = 2
    workbook.get_cell(0, "G2").value = 3
    workbook.get_cell(0, "H2").value = 4

    cell = workbook.get_cell(0, "A2")
    cell.formula = "C3+SUM(F2:H2)"

    workbook.calculate_formulas()

    value = cell.value  # 19
```

Übliche A1‑Bezugsformen sind:

| Bezug | Relativ | Absolut | Gemischt |
|---|---|---|---|
| Zelle | `A2` | `$A$2` | `A$2`, `$A2` |
| Zeile | `2:2` | `$2:$2` | — |
| Spalte | `A:A` | `$A:$A` | — |
| Bereich | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

Relative Bezüge können sich ändern, wenn eine Formel von einer Tabellenkalkulations‑Anwendung verschoben oder kopiert wird. Absolute Bezüge halten beide Koordinaten fest, während gemischte Bezüge nur Zeile oder Spalte fixieren.

## **R1C1‑Style‑Formeln verwenden**

Die R1C1‑Notation identifiziert sowohl Zeilen als auch Spalten numerisch. Relative Bezüge verwenden Offsets in eckigen Klammern. Weisen Sie diese Syntax über [IChartDataCell.r1c1_formula](https://reference.aspose.com/slides/de/python-net/aspose.slides.charts/ichartdatacell/r1c1_formula/) zu.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 300)
    workbook = chart.chart_data.chart_data_workbook

    workbook.get_cell(0, "B2").value = 12
    workbook.get_cell(0, "C2").value = 5

    cell = workbook.get_cell(0, "D2")
    cell.r1c1_formula = "RC[-2]-RC[-1]"

    workbook.calculate_formulas()

    value = cell.value  # 7
```

Übliche R1C1‑Bezugsformen sind:

| Bezug | Relativ | Absolut | Gemischt |
|---|---|---|---|
| Zelle | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| Zeile | `R[2]` | `R2` | — |
| Spalte | `C[3]` | `C3` | — |
| Bereich | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

Beispiel: In Zelle `D2` bedeutet `RC[-2]` die Zelle in derselben Zeile, zwei Spalten nach links (`B2`).

## **Formel‑Konstanten und Operatoren**

Der eingebaute Formelauswerter unterstützt logische Werte, numerische Literale, Zeichenketten, Tabellenspezifische Fehlerwerte, arithmetische Operatoren und Vergleichsoperatoren.

### **Konstanten und Literale**

| Typ | Beispiele | Hinweise |
|---|---|---|
| Logisch | `TRUE`, `FALSE` | Können direkt in logischen Ausdrücken wie `A2=TRUE` verwendet werden. |
| Numerisch | `1`, `0.5`, `.3`, `1E-2` | Dezimal‑ und wissenschaftliche Schreibweise werden unterstützt. |
| Zeichenkette | `"abc"`, `"2/3/2020 12:00"` | Text‑Literale werden innerhalb der Formel in doppelte Anführungszeichen gesetzt. |
| Fehlerwert | `#DIV/0!`, `#N/A`, `#REF!` | Eine gültige Formel kann statt eines normalen Ergebnisses einen Tabellenspeziﬁchen Fehlerwert ergeben. |

Dieses Beispiel nutzt mehrere Konstantentypen:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 300)
    workbook = chart.chart_data.chart_data_workbook

    workbook.get_cell(0, "A2").value = False
    workbook.get_cell(0, "B2").formula = "A2=TRUE"
    workbook.get_cell(0, "C2").formula = "1+0.5"
    workbook.get_cell(0, "D2").formula = ".3*1E-2"
    workbook.get_cell(0, "E2").formula = "\"abc\""
    workbook.get_cell(0, "F2").formula = "2/0"

    workbook.calculate_formulas()

    logical_value = workbook.get_cell(0, "B2").value  # Falsch
    numeric_value = workbook.get_cell(0, "C2").value  # 1.5
    scientific_value = workbook.get_cell(0, "D2").value  # 0.003
    string_value = workbook.get_cell(0, "E2").value  # abc
    error_value = workbook.get_cell(0, "F2").value  # #DIV/0!
```

### **Arithmetische Operatoren**

| Operator | Bedeutung | Beispiel |
|---|---|---|
| `+` | Addition oder einfaches Plus | `2+3` |
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

Aspose.Slides enthält einen integrierten Formelauswerter für Diagramm‑Arbeitsblätter, ist jedoch keine vollständige Excel‑Berechnungs‑Engine. Der dokumentierte Funktionsumfang ist auf die nachstehende Tabelle beschränkt. Gehen Sie nicht davon aus, dass eine beliebige Excel‑Funktion von [calculate_formulas](https://reference.aspose.com/slides/de/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/) neu berechnet werden kann.

| Funktion | Zweck bzw. unterstützte Form | Beispiel |
|---|---|---|
| `ABS` | Absoluter Wert | `ABS(A2)` |
| `AVERAGE` | Arithmetisches Mittel | `AVERAGE(B2:B5)` |
| `CEILING` | Auf ein Vielfaches aufrunden | `CEILING(A2,5)` |
| `CHOOSE` | Wert nach Index auswählen | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | Textwerte verketten | `CONCAT(A2,B2)` |
| `CONCATENATE` | Textwerte verketten | `CONCATENATE(A2," ",B2)` |
| `DATE` | Datumswert nach 1900‑System erzeugen | `DATE(2026,8,19)` |
| `DAYS` | Anzahl der Tage zwischen Daten | `DAYS(B2,A2)` |
| `FIND` | Text in anderem Text finden | `FIND("-",A2)` |
| `FINDB` | Byte‑orientierte Textsuche | `FINDB("a",A2)` |
| `IF` | Bedingtes Ergebnis | `IF(A2>0,A2,0)` |
| `INDEX` | Bezugsform | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | Vektorform | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | Vektorform | `MATCH(A2,B2:B5,0)` |
| `MAX` | Maximalwert | `MAX(B2:B5)` |
| `SUM` | Summe | `SUM(B2:B5)` |
| `VLOOKUP` | Vertikaler SVERWEIS | `VLOOKUP(A2,B2:D10,3,FALSE)` |

Die in der Tabelle gezeigten Einschränkungen sind wesentlich: `INDEX` wird in der Bezugsform dokumentiert, während `LOOKUP` und `MATCH` in ihren Vektorformen dokumentiert sind. `DATE` verwendet das 1900‑Datumssystem. Funktionen, die hier nicht aufgeführt sind, sollten als nicht unterstützt vom Aspose.Slides‑Formelauswerter behandelt werden, sofern sie nicht gesondert dokumentiert sind.

## **Neuberechnung und zwischengespeicherte Werte**

Tabellendateien speichern häufig sowohl eine Formel als auch deren zuletzt berechneten Wert. Aspose.Slides kann daher beim Laden einer Präsentation und unverändertem Diagrammdaten‑Workbook den zwischengespeicherten Wert aus [IChartDataCell.value](https://reference.aspose.com/slides/de/python-net/aspose.slides.charts/ichartdatacell/value/) lesen.

Nachdem Sie Eingabezellen oder Formeln geändert haben, dürfen Sie sich nicht auf ein altes Cache‑Ergebnis verlassen. Rufen Sie [ChartDataWorkbook.calculate_formulas](https://reference.aspose.com/slides/de/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/) auf, bevor Sie berechnete Werte lesen oder Diagrammdaten, die davon abhängen, speichern.

Für Formeln außerhalb des unterstützten Subsets kann Aspose.Slides die Formel nicht parsen oder ihre Abhängigkeiten nicht ermitteln. Wenn das Workbook geändert wurde, ist der vorherige zwischengespeicherte Wert nicht mehr zuverlässig. In diesem Fall kann das Auslesen des Wertes einer Zelle mit nicht unterstützten Daten die Ausnahme [CellUnsupportedDataException](https://reference.aspose.com/slides/de/python-net/aspose.slides.spreadsheet/cellunsupporteddataexception/) auslösen.

Wenn Ihr Diagramm von Excel‑Funktionen abhängt, die Aspose.Slides nicht auswertet, berechnen Sie diese Formeln mit einer Tabellen‑Engine, die sie unterstützt, und schreiben Sie die resultierenden Werte zurück in das Diagramm‑Workbook. Ersetzen Sie nicht‑unterstützte Formeln nicht durch geschätzte Werte.

## **Formelfehler behandeln**

Es sind zwei unterschiedliche Problemarten zu unterscheiden.

Eine Formel kann gültig sein, aber ein Tabellenspezifisches Fehlerergebnis wie `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!` oder `#VALUE!` erzeugen. In diesem Fall ist das Fehler‑Token ein Zellergebnis und kann über `value` zurückgegeben werden.

Eine Formel kann auch beim Parsen, beim Bezug, bei Abhängigkeiten oder bei nicht unterstützten Daten fehlschlagen. Aspose.Slides stellt dafür tabellenspezifische Ausnahmen bereit: [CellInvalidFormulaException](https://reference.aspose.com/slides/de/python-net/aspose.slides.spreadsheet/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/de/python-net/aspose.slides.spreadsheet/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/de/python-net/aspose.slides.spreadsheet/cellcircularreferenceexception/) und [CellUnsupportedDataException](https://reference.aspose.com/slides/de/python-net/aspose.slides.spreadsheet/cellunsupporteddataexception/).

Wenn Formeln aus Vorlagen oder Benutzereingaben stammen, fangen Sie diese Ausnahmen beim Neuberechnen und beim Zugriff auf den Wert ab:

```python
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.slides.spreadsheet as spreadsheet

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 300)
    workbook = chart.chart_data.chart_data_workbook
    cell = workbook.get_cell(0, "A2")
    cell.formula = "SUM(B2:B5)"

    try:
        workbook.calculate_formulas()
        print(cell.value)
    except spreadsheet.CellInvalidFormulaException as ex:
        print(f"Invalid formula: {ex}")
    except spreadsheet.CellInvalidReferenceException as ex:
        print(f"Invalid cell reference: {ex}")
    except spreadsheet.CellCircularReferenceException as ex:
        print(f"Circular reference: {ex}")
    except spreadsheet.CellUnsupportedDataException as ex:
        print(f"Unsupported spreadsheet data: {ex}")
```

## **Praktische Einschränkungen**

Die Formelsupport in Diagramm‑Arbeitsblättern ist für einen definierten Teilbereich von Tabellen‑Berechnungen gedacht, nicht für volle Excel‑Kompatibilität. Beachten Sie diese Beschränkungen beim Entwerfen eines Reporting‑Workflows:

- Verwenden Sie nur die dokumentierten Konstanten, Operatoren, Bezüge und Funktionen, wenn Aspose.Slides Formeln neu berechnen soll.
- Berechnen Sie nach Änderungen an Zellen, von denen Formel­ergebnisse abhängen, neu.
- Betrachten Sie zwischengespeicherte Werte aus geladenen Präsentationen als Schnappschüsse, nicht als Ersatz für eine Neuberechnung nach Änderungen.
- Testen Sie Formeln aus bestehenden Vorlagen, bevor Sie sich auf deren berechnete Werte verlassen, insbesondere wenn sie Funktionen außerhalb der dokumentierten Liste nutzen.
- Für Formeln, die eine vollständige Tabellen‑Berechnungs‑Engine erfordern, berechnen Sie diese extern und aktualisieren anschließend das Diagramm‑Workbook mit den resultierenden Werten.

## **FAQ**

**Was ist der Unterschied zwischen `formula` und `r1c1_formula`?**

[formula](https://reference.aspose.com/slides/de/python-net/aspose.slides.charts/ichartdatacell/formula/) speichert einen A1‑Stil‑Ausdruck wie `B2-C2`. [r1c1_formula](https://reference.aspose.com/slides/de/python-net/aspose.slides.charts/ichartdatacell/r1c1_formula/) speichert einen R1C1‑Stil‑Ausdruck wie `RC[-2]-RC[-1]`. Verwenden Sie die Notation, die am besten zu Ihrer Formel‑Erzeugung oder -Kopie passt.

**Muss ich nach der Berechnung die Zelle selbst oder ihren Wert lesen?**

[ChartDataWorkbook.get_cell](https://reference.aspose.com/slides/de/python-net/aspose.slides.charts/chartdataworkbook/get_cell/) gibt ein `IChartDataCell` zurück. Um das berechnete Ergebnis zu erhalten, lesen Sie nach der Neuberechnung die [value](https://reference.aspose.com/slides/de/python-net/aspose.slides.charts/ichartdatacell/value/)‑Eigenschaft dieser Zelle.

**Wann sollte ich `calculate_formulas` aufrufen?**

Rufen Sie [calculate_formulas](https://reference.aspose.com/slides/de/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/) nach Änderungen an Eingabewerten oder Formeln und bevor Sie die berechneten Ergebnisse benötigen, auf. Dies aktualisiert die Werte der Formeln, die der integrierte Auswerter unterstützt.

**Unterstützt Aspose.Slides jede Excel‑Funktion?**

Nein. Der integrierte Auswerter unterstützt nur ein dokumentiertes Subset von Funktionen. Funktionen außerhalb dieses Subsets sollten nicht als korrekt neu berechenbar angenommen werden. Wenn vollständige Excel‑Formel‑Kompatibilität erforderlich ist, führen Sie die Berechnung mit einer geeigneten Tabellen‑Engine durch und schreiben Sie die endgültigen Werte in das Diagramm‑Workbook.

**Was passiert, wenn eine geladene Präsentation eine nicht unterstützte Formel enthält?**

Wenn die Diagrammdaten nicht verändert wurden, kann das Workbook noch einen zuvor berechneten zwischengespeicherten Wert enthalten. Nach einer Änderung der zugehörigen Daten ist dieser Cache‑Wert möglicherweise nicht mehr gültig. Der Zugriff auf eine Zelle, deren Formel nicht verarbeitet werden kann, kann die Ausnahme [CellUnsupportedDataException](https://reference.aspose.com/slides/de/python-net/aspose.slides.spreadsheet/cellunsupporteddataexception/) auslösen.

**Sind Formelfehlerwerte dasselbe wie Python‑Ausnahmen?**

Nein. Ein Ergebnis wie `#DIV/0!` ist ein Tabellenspezifischer Wert, der durch eine gültige Berechnung entsteht. Ausnahmen wie [CellInvalidFormulaException](https://reference.aspose.com/slides/de/python-net/aspose.slides.spreadsheet/cellinvalidformulaexception/) oder [CellCircularReferenceException](https://reference.aspose.com/slides/de/python-net/aspose.slides.spreadsheet/cellcircularreferenceexception/) zeigen an, dass die Formel nicht normal verarbeitet werden kann.

**Wird ein Diagramm automatisch aktualisiert, wenn sich eine Formel‑Zelle ändert?**

Eine Diagramm‑Reihe kann auf Workbook‑Zellen verweisen. Berechnen Sie das Workbook zuerst, dann speichern oder rendern Sie die Präsentation. Wenn die Diagrammdatenpunkte die berechneten Zellen referenzieren, verwendet das Diagramm diese aktualisierten Werte; ein separater Diagramm‑Refresh‑Aufruf ist für diesen Workflow nicht erforderlich.

**Können Diagramme ein externes Excel‑Workbook verwenden?**

Ja, Diagrammdaten können so konfiguriert werden, dass sie ein externes Workbook über die Diagrammdaten‑API nutzen. Der in diesem Artikel beschriebene Formel‑Berechnungs‑Workflow bezieht sich jedoch auf das Diagramm‑Workbook und das von Aspose.Slides bewertete Formelsubset. Gehen Sie nicht davon aus, dass [calculate_formulas](https://reference.aspose.com/slides/de/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/) eine vollständige Neuberechnung beliebiger Formeln in einer externen XLSX‑Datei liefert.

**Kann ich Formeln verwenden, die auf ein anderes Arbeitsblatt oder Workbook verweisen?**

Excel‑Stil‑Verweise können in Diagramm‑Workbooks vorkommen, doch die Formel­auswertung ist durch den unterstützten Parser und Funktionsumfang begrenzt. Wenn ein Querverweis unerlässlich ist, prüfen Sie die genaue Formel mit Ihrer Ziel‑Aspose.Slides‑Version. Für Workflows, die breite Excel‑Verweis‑Kompatibilität benötigen, berechnen Sie das Workbook extern und schreiben die aufgelösten Werte zurück in die Diagrammdaten.

**Müssen Formelfeld‑Zeichenketten mit `=` beginnen?**

Die Aspose.Slides‑API‑Beispiele weisen Ausdrücke wie `B2-C2` oder `SUM(B2:B5)` ohne führendes `=` zu. Die Verwendung dieser Form hält erzeugte Formeln konsistent zu den dokumentierten API‑Beispielen.
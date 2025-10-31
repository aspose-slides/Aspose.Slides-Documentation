---
title: Diagramm-Arbeitsblatt-Formeln in Präsentationen mit Python
linktitle: Arbeitsblatt-Formeln
type: docs
weight: 70
url: /de/python-net/chart-worksheet-formulas/
keywords:
- Diagramm-Tabellenblatt
- Diagramm-Arbeitsblatt
- Diagramm-Formel
- Arbeitsblatt-Formel
- Tabellenblatt-Formel
- Datenquelle
- logische Konstante
- numerische Konstante
- Zeichenkettenkonstante
- Fehlerkonstante
- arithmetische Konstante
- Vergleichsoperator
- A1-Stil
- R1C1-Stil
- vordefinierte Funktion
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Aspose.Slides
description: "Wenden Sie Excel‑ähnliche Formeln in Aspose.Slides für Python via .NET‑Diagramm‑Tabellenblätter an und automatisieren Sie Berichte in PPT, PPTX und ODP‑Dateien."
---

## **Über Diagramm‑Tabellenblatt‑Formeln in Präsentationen**
**Diagramm‑Tabellenblatt** (oder Diagramm‑Arbeitsblatt) in einer Präsentation ist die Datenquelle des Diagramms. Diagramm‑Tabellenblatt enthält Daten, die im Diagramm grafisch dargestellt werden. Wenn Sie ein Diagramm in PowerPoint erstellen, wird das dem Diagramm zugehörige Arbeitsblatt automatisch ebenfalls erstellt. Das Arbeitsblatt wird für alle Diagramm‑Typen erstellt: Liniendiagramm, Balkendiagramm, Sunburst‑Diagramm, Kreisdiagramm usw. Um das Diagramm‑Tabellenblatt in PowerPoint zu sehen, doppelklicken Sie das Diagramm:

![todo:image_alt_text](chart-worksheet-formulas_1.png)

Diagramm‑Tabellenblatt enthält die Namen der Diagrammelemente (Kategorie‑Name: *Category1*, Serien‑Name) und eine Tabelle mit numerischen Daten, die zu diesen Kategorien und Serien passen. Standardmäßig wird beim Erstellen eines neuen Diagramms das Diagramm‑Tabellenblatt‑Daten‑Set mit Beispieldaten befüllt. Anschließend können Sie die Tabellendaten im Arbeitsblatt manuell ändern.

In der Regel stellt das Diagramm komplexe Daten dar (z. B. Finanz‑ oder Wissenschaftsanalyse), bei denen Zellen aus den Werten anderer Zellen oder aus dynamischen Daten berechnet werden. Den Wert einer Zelle manuell zu berechnen und hart zu kodieren, erschwert spätere Änderungen. Wenn Sie den Wert einer bestimmten Zelle ändern, müssen alle davon abhängigen Zellen ebenfalls aktualisiert werden. Darüber hinaus können Tabellendaten von Daten anderer Tabellen abhängen, wodurch ein komplexes Präsentations‑Datenschema entsteht, das einfach und flexibel aktualisiert werden muss.

**Diagramm‑Tabellenblatt‑Formel** in einer Präsentation ist ein Ausdruck, der die Daten des Diagramm‑Tabellenblatts automatisch berechnet und aktualisiert. Eine Tabellenblatt‑Formel definiert die Berechnungslogik für eine bestimmte Zelle oder einen Zellenbereich. Eine Tabellenblatt‑Formel ist eine mathematische oder logische Formel, die verwendet: Zellreferenzen, mathematische Funktionen, logische Operatoren, arithmetische Operatoren, Konvertierungsfunktionen, Zeichenkettenkonstanten usw. Die Definition der Formel wird in eine Zelle geschrieben, die keinen einfachen Wert enthält. Die Formel berechnet den Wert, gibt ihn zurück und der Wert wird der Zelle zugewiesen. Diagramm‑Tabellenblatt‑Formeln in Präsentationen sind im Wesentlichen dieselben wie Excel‑Formeln, und dieselben Standard‑Funktionen, Operatoren und Konstanten werden unterstützt.

In [**Aspose.Slides**](https://products.aspose.com/slides/python-net/) wird das Diagramm‑Tabellenblatt über die Eigenschaft 
[**Chart.ChartData.ChartDataWorkbook**](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdata/) des 
[**IChartDataWorkbook**](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdataworkbook/) Typs dargestellt. 
Formeln können über die Eigenschaft 
[**formula**](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdatacell/) zugewiesen und geändert werden. 
Die folgende Funktionalität wird für Formeln in Aspose.Slides unterstützt:

- Logische Konstanten
- Numerische Konstanten
- Zeichenketten‑Konstanten
- Fehler‑Konstanten
- Arithmetische Operatoren
- Vergleichsoperatoren
- A1‑Stil‑Zellreferenzen
- R1C1‑Stil‑Zellreferenzen
- Vordefinierte Funktionen

Typischerweise speichern Tabellenblätter die zuletzt berechneten Formelwerte. Wenn nach dem Laden der Präsentation die Diagrammdaten nicht geändert wurden, gibt die Eigenschaft **IChartDataCell.Value** diese Werte beim Lesen zurück. Wenn jedoch die Tabellendaten geändert wurden, wirft das Lesen von **ChartDataCell.Value** die **CellUnsupportedDataException** für nicht unterstützte Formeln. Das liegt daran, dass beim erfolgreichen Parsen einer Formel die Zellabhängigkeiten ermittelt und die Korrektheit der letzten Werte bestimmt werden. Kann eine Formel nicht geparst werden, lässt sich die Korrektheit des Zellenwertes nicht garantieren.

## **Diagramm‑Tabellenblatt‑Formel zur Präsentation hinzufügen**
Fügen Sie zuerst einem neuen Präsentations‑Slide ein Diagramm mit Beispieldaten hinzu, indem Sie 
[add_chart](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/) verwenden. 
Das Arbeitsblatt des Diagramms wird automatisch erstellt und kann über die Eigenschaft 
[**chart_data_workbook**](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdata/) angesprochen werden:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 150, 150, 500, 300)
    workbook = chart.chart_data.chart_data_workbook
    # ...
```

Schreiben Sie einige Werte in Zellen über die 
[**value**](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdatacell/)‑Eigenschaft des **Object**‑Typs, die es Ihnen ermöglicht, jedem Datentyp zuzuweisen:

```py
    workbook.get_cell(0, "F2").value = -2.5
    workbook.get_cell(0, "G3").value = 6.3
    workbook.get_cell(0, "H4").value = 3
```

Um eine Formel in die Zelle zu schreiben, können Sie die 
[**formula**](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdatacell/)‑Eigenschaft verwenden:

```py
    workbook.get_cell(0, "B2").formula = "F2+G3+H4+1"
```

*Hinweis*: Die Eigenschaft [**IChartDataCell.Formula**](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdatacell/) wird verwendet, um A1‑Stil‑Zellreferenzen zu setzen.  

Um die 
[r1c1_formula](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdatacell/)‑Zellreferenz zu setzen, können Sie die 
[**r1c1_formula**](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdatacell/)‑Eigenschaft verwenden:

```py
    workbook.get_cell(0, "C2").r1c1_formula = "R[1]C[4]/R[2]C[5]"
```

Anschließend verwenden Sie die Methode 
[**calculate_formulas**](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/), um alle Formeln im Arbeitsbuch zu berechnen und die entsprechenden Zellwerte zu aktualisieren:

```py
    workbook.calculate_formulas()
    print(workbook.get_cell(0, "B2").value) # 7.8
    print(workbook.get_cell(0, "C2").value) # 2.1
```

## **Logische Konstanten**
Sie können logische Konstanten wie *FALSE* und *TRUE* in Zellformeln verwenden:

## **Numerische Konstanten**
Zahlen können in dezimaler oder wissenschaftlicher Notation verwendet werden, um Diagramm‑Tabellenblatt‑Formeln zu erstellen:

## **Zeichenketten‑Konstanten**
Eine Zeichenketten‑ (oder Literal‑)Konstante ist ein fester Wert, der unverändert verwendet wird. Zeichenketten‑Konstanten können sein: Datumswerte, Texte, Zahlen usw.:

## **Fehler‑Konstanten**
Manchmal lässt sich das Ergebnis einer Formel nicht berechnen. In diesem Fall wird im Feld stattdessen ein Fehlercode angezeigt. Jeder Fehlertyp hat einen spezifischen Code:

- #DIV/0! – Formel versucht, durch Null zu dividieren.
- #GETTING_DATA – kann in einer Zelle erscheinen, während ihr Wert noch berechnet wird.
- #N/A – Information fehlt oder ist nicht verfügbar. Gründe können sein: Die in der Formel verwendeten Zellen sind leer, ein zusätzliches Leerzeichen, ein Rechtschreibfehler usw.
- #NAME? – eine bestimmte Zelle oder ein anderes Formelelement kann nicht über ihren Namen gefunden werden.
- #NULL! – tritt auf, wenn ein Fehler in der Formel vorliegt, z. B. (,) oder ein Leerzeichen anstelle eines Doppelpunkts (:).
- #NUM! – die numerische Angabe in der Formel ist ungültig, zu groß oder zu klein usw.
- #REF! – ungültige Zellreferenz.
- #VALUE! – unerwarteter Werttyp. Zum Beispiel ein Zeichenkettenwert in einer numerischen Zelle.

## **Arithmetische Operatoren**
Sie können alle arithmetischen Operatoren in Diagramm‑Arbeitsblatt‑Formeln verwenden:

|**Operator**|**Bedeutung**|**Beispiel**|
| :- | :- | :- |
|+ (Pluszeichen)|Addition oder unäres Plus|2 + 3|
|- (Minuszeichen)|Subtraktion oder Negation|2 - 3<br>-3|
|* (Sternchen)|Multiplikation|2 * 3|
|/ (Schrägstrich)|Division|2 / 3|
|% (Prozentzeichen)|Prozent|30%|
|^ (Caret)|Exponentiation|2 ^ 3|

*Hinweis*: Um die Auswertungsreihenfolge zu ändern, setzen Sie den zu berechnenden Teil in Klammern.

## **Vergleichsoperatoren**
Sie können Zellwerte mit Vergleichsoperatoren vergleichen. Das Ergebnis ist ein logischer Wert, entweder *TRUE* oder *FALSE*:

|**Operator**|**Bedeutung**|**Beispiel**|
| :- | :- | :- |
|= (Gleichheitszeichen)|Gleich|A2 = 3|
|<> (Ungleichheitszeichen)|Ungleich|A2 <> 3|
|> (Größer‑als‑Zeichen)|Größer als|A2 > 3|
|>= (Größer‑oder‑gleich‑Zeichen)|Größer oder gleich|A2 >= 3|
|< (Kleiner‑als‑Zeichen)|Kleiner als|A2 < 3|
|<= (Kleiner‑oder‑gleich‑Zeichen)|Kleiner oder gleich|A2 <= 3|

## **A1‑Stil‑Zellreferenzen**
**A1‑Stil‑Zellreferenzen** werden in Arbeitsblättern verwendet, bei denen die Spalte einen Buchstaben (z. B. "*A*") und die Zeile eine Zahl (z. B. "*1*") hat. A1‑Stil‑Zellreferenzen können wie folgt verwendet werden:

|**Zellreferenz**|**Beispiel**|||
| :- | :- | :- | :- |
||Absolut|Relativ|Gemischt|
|Zelle|$A$2|A2|<p>A$2</p><p>$A2</p>|
|Zeile|$2:$2|2:2|-|
|Spalte|$A:$A|A:A|-|
|Bereich|$A$2:$C$4|A2:C4|<p>$A$2:C4</p><p>A$2:$C4</p>|

Hier ein Beispiel, wie man eine A1‑Stil‑Zellreferenz in einer Formel verwendet:

## **R1C1‑Stil‑Zellreferenzen**
**R1C1‑Stil‑Zellreferenzen** werden in Arbeitsblättern verwendet, bei denen sowohl Zeile als auch Spalte numerisch identifiziert werden. R1C1‑Stil‑Zellreferenzen können wie folgt verwendet werden:

|**Zellreferenz**|**Beispiel**|||
| :- | :- | :- | :- |
||Absolut|Relativ|Gemischt|
|Zelle|R2C3|R[2]C[3]|R2C[3]<br>R[2]C3|
|Zeile|R2|R[2]|-|
|Spalte|C3|C[3]|-|
|Bereich|R2C3:R5C7|R[2]C[3]:R[5]C[7]|R2C3:R[5]C[7]<br>R[2]C3:R5C[7]|

Hier ein Beispiel, wie man eine R1C1‑Stil‑Zellreferenz in einer Formel verwendet:

## **Vordefinierte Funktionen**
Es gibt vordefinierte Funktionen, die in Formeln verwendet werden können, um deren Implementierung zu vereinfachen. Diese Funktionen kapseln die am häufigsten genutzten Vorgänge, wie zum Beispiel:

- ABS
- AVERAGE
- CEILING
- CHOOSE
- CONCAT
- CONCATENATE
- DATE (1900‑Datumsystem)
- DAYS
- FIND
- FINDB
- IF
- INDEX (Referenzform)
- LOOKUP (Vektorform)
- MATCH (Vektorform)
- MAX
- SUM
- VLOOKUP

## **FAQ**

**Werden externe Excel‑Dateien als Datenquelle für ein Diagramm mit Formeln unterstützt?**

Ja. Aspose.Slides unterstützt externe Arbeitsmappen als [Diagramm‑Datenquelle](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatasourcetype/), wodurch Sie Formeln aus einer XLSX‑Datei außerhalb der Präsentation verwenden können.

**Können Diagramm‑Formeln Tabellenblätter im selben Arbeitsbuch per Blattname referenzieren?**

Ja. Formeln folgen dem üblichen Excel‑Referenzmodell, sodass Sie andere Blätter im selben Arbeitsbuch oder in einer externen Arbeitsmappe referenzieren können. Für externe Referenzen geben Sie Pfad und Dateinamen nach Excel‑Syntax an.
---
title: Diagramm‑Arbeitsblatt‑Formeln in Präsentationen mit Python anwenden
linktitle: Arbeitsblatt‑Formeln
type: docs
weight: 70
url: /de/python-net/chart-worksheet-formulas/
keywords:
- Diagramm‑Tabellenkalkulation
- Diagramm‑Arbeitsblatt
- Diagramm‑Formel
- Arbeitsblatt‑Formel
- Tabellenkalkulations‑Formel
- Datenquelle
- logische Konstante
- numerische Konstante
- Zeichenketten‑Konstante
- Fehler‑Konstante
- arithmetische Konstante
- Vergleichsoperator
- A1‑Stil
- R1C1‑Stil
- vordefinierte Funktion
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Aspose.Slides
description: "Excel‑ähnliche Formeln in Aspose.Slides für Python über .NET‑Diagramm‑Arbeitsblätter anwenden und Berichte in PPT-, PPTX‑ und ODP‑Dateien automatisieren."
---

## **Über Diagramm‑Tabellenkalkulationsformel in der Präsentation**
**Chart spreadsheet** (oder **chart worksheet**) in der Präsentation ist die Datenquelle des Diagramms. Chart spreadsheet enthält Daten, die im Diagramm grafisch dargestellt werden. Wenn Sie ein Diagramm in PowerPoint erstellen, wird das dem Diagramm zugehörige Arbeitsblatt automatisch ebenfalls erstellt. Das Diagramm‑Arbeitsblatt wird für alle Diagrammtypen erstellt: Liniendiagramm, Balkendiagramm, Sunburst‑Diagramm, Kreisdiagramm usw. Um das Diagramm‑Arbeitsblatt in PowerPoint zu sehen, doppelklicken Sie das Diagramm:

![todo:image_alt_text](chart-worksheet-formulas_1.png)



Chart spreadsheet enthält die Namen von Diagrammelementen (Category Name: *Category1*, Serie Name) und eine Tabelle mit numerischen Daten, die zu diesen Kategorien und Serien passen. standardmäßig werden beim Erstellen eines neuen Diagramms die Diagrammdaten mit Beispieldaten vorbelegt. Anschließend können Sie die Arbeitsblattdaten manuell im Arbeitsblatt ändern.

In der Regel stellt das Diagramm komplexe Daten dar (z. B. Finanzanalysen, wissenschaftliche Analysen) und enthält Zellen, die aus den Werten anderer Zellen oder aus anderen dynamischen Daten berechnet werden. Den Zellenwert manuell zu berechnen und fest in die Zelle zu schreiben, macht spätere Änderungen schwierig. Wenn Sie den Wert einer bestimmten Zelle ändern, müssen alle davon abhängigen Zellen ebenfalls aktualisiert werden. Außerdem können Tabellendaten von Daten anderer Tabellen abhängen, was ein komplexes Präsentationsdaten‑Schema erzeugt, das einfach und flexibel aktualisiert werden muss.

**Chart spreadsheet formula** in der Präsentation ist ein Ausdruck, der die Diagrammdaten automatisch berechnet und aktualisiert. Eine Spreadsheet‑Formel definiert die Datenberechnungslogik für eine bestimmte Zelle oder eine Reihe von Zellen. Eine Spreadsheet‑Formel ist eine mathematische oder logische Formel, die verwendet: Zellreferenzen, mathematische Funktionen, logische Operatoren, arithmetische Operatoren, Konvertierungsfunktionen, Zeichenketten‑Konstanten usw. Die Definition der Formel wird in eine Zelle geschrieben, die keinen einfachen Wert enthält. Die Spreadsheet‑Formel berechnet den Wert, gibt ihn zurück und dieser Wert wird der Zelle zugewiesen. Chart‑Spreadsheet‑Formeln in Präsentationen entsprechen exakt Excel‑Formeln, und es werden dieselben Standard‑Funktionen, Operatoren und Konstanten unterstützt.

In [**Aspose.Slides**](https://products.aspose.com/slides/python-net/) wird das Diagramm‑Arbeitsblatt über die
[**Chart.ChartData.ChartDataWorkbook**](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdata/)‑Eigenschaft des
[**IChartDataWorkbook**](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdataworkbook/)‑Typs dargestellt. 
Eine Spreadsheet‑Formel kann über die 
[**formula**](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdatacell/)‑Eigenschaft zugewiesen und geändert werden. 
Folgende Funktionalitäten werden für Formeln in Aspose.Slides unterstützt:

- Logische Konstanten
- Numerische Konstanten
- Zeichenketten‑Konstanten
- Fehler‑Konstanten
- Arithmetische Operatoren
- Vergleichsoperatoren
- A1‑Style Zellreferenzen
- R1C1‑Style Zellreferenzen
- Vorgegebene Funktionen



Typischerweise speichern Arbeitsblätter die zuletzt berechneten Formelergebnisse. Wenn nach dem Laden der Präsentation die Diagrammdaten nicht geändert wurden, liefert die **IChartDataCell.Value**‑Eigenschaft diese Werte beim Lesen. Wurden die Arbeitsblattdaten jedoch geändert, wirft das Lesen der **ChartDataCell.Value**‑Eigenschaft die **CellUnsupportedDataException** für nicht unterstützte Formeln. Das liegt daran, dass bei erfolgreich geparsten Formeln die Zellabhängigkeiten ermittelt werden und die Korrektheit der letzten Werte bestimmt wird. Kann eine Formel nicht geparst werden, kann die Korrektheit des Zellenwertes nicht garantiert werden.
## **Chart‑Spreadsheet‑Formel zur Präsentation hinzufügen**
Zuerst fügen Sie mit 
[add_chart](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/) ein Diagramm mit Beispieldaten zur ersten Folie einer neuen Präsentation hinzu. 
Das Arbeitsblatt des Diagramms wird automatisch erstellt und kann über die 
[**chart_data_workbook**](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdata/)‑Eigenschaft zugegriffen werden:
```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 150, 150, 500, 300)
    workbook = chart.chart_data.chart_data_workbook
    # ...
```




Schreiben Sie einige Werte in Zellen mit der 
[**value**](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdatacell/)‑Eigenschaft des Typs **Object**, was bedeutet, dass Sie beliebige Werte zuweisen können:
```py
    workbook.get_cell(0, "F2").value = -2.5
    workbook.get_cell(0, "G3").value = 6.3
    workbook.get_cell(0, "H4").value = 3
```




Um nun eine Formel in die Zelle zu schreiben, verwenden Sie die 
[**formula**](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdatacell/)‑Eigenschaft:
```py
    workbook.get_cell(0, "B2").formula = "F2+G3+H4+1"
```


*Hinweis*: [**IChartDataCell.Formula**](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdatacell/)‑Eigenschaft wird verwendet, um A1‑Style Zellreferenzen zu setzen. 



Um die [r1c1_formula](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdatacell/)‑Zellreferenz zu setzen, verwenden Sie die [**r1c1_formula**](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdatacell/)‑Eigenschaft:
```py
    workbook.get_cell(0, "C2").r1c1_formula = "R[1]C[4]/R[2]C[5]"
```


Anschließend nutzen Sie die [**calculate_formulas**](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/)‑Methode, um alle Formeln im Arbeitsbuch zu berechnen und die entsprechenden Zellenwerte zu aktualisieren:
```py
    workbook.calculate_formulas()
    print(workbook.get_cell(0, "B2").value) # 7.8
    print(workbook.get_cell(0, "C2").value) # 2.1
```



## **Logische Konstanten**
Sie können logische Konstanten wie *FALSE* und *TRUE* in Zellenformeln verwenden:




## **Numerische Konstanten**
Zahlen können in Dezimal‑ oder wissenschaftlicher Schreibweise verwendet werden, um Diagramm‑Spreadsheet‑Formeln zu erstellen:




## **Zeichenketten‑Konstanten**
Eine Zeichenketten‑ (oder Literal‑)Konstante ist ein fester Wert, der unverändert verwendet wird. Zeichenketten‑Konstanten können sein: Datumsangaben, Texte, Zahlen usw.:




## **Fehler‑Konstanten**
Manchmal ist es nicht möglich, das Ergebnis durch die Formel zu berechnen. In diesem Fall wird im Feld ein Fehlercode anstelle des Werts angezeigt. Jeder Fehlertyp hat einen spezifischen Code:

- #DIV/0! – Formel versucht, durch null zu teilen.
- #GETTING_DATA – kann in einer Zelle angezeigt werden, während ihr Wert noch berechnet wird.
- #N/A – Information fehlt oder ist nicht verfügbar. Gründe können sein: leere Zellen in der Formel, ein zusätzliches Leerzeichen, Rechtschreibfehler usw.
- #NAME? – ein bestimmtes Zell‑ oder Formelobjekt kann nicht über seinen Namen gefunden werden.
- #NULL! – tritt auf, wenn ein Fehler in der Formel vorliegt, z. B.  (,) oder ein Leerzeichen anstelle eines Doppelpunkts (:).
- #NUM! – die in der Formel angegebene Zahl ist ungültig, zu lang oder zu klein usw.
- #REF! – ungültige Zellreferenz.
- #VALUE! – unerwarteter Werttyp. Zum Beispiel ein Zeichenkettenwert in einer numerischen Zelle.




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


*Hinweis*: Um die Auswertungsreihenfolge zu ändern, setzen Sie den zuerst zu berechnenden Teil in Klammern.


## **Vergleichsoperatoren**
Sie können Zellwerte mit Vergleichsoperatoren vergleichen. Das Ergebnis ist ein logischer Wert, entweder *TRUE* oder *FALSE*:



|**Operator**|**Bedeutung**|**Bedeutung**|
| :- | :- | :- |
|= (Gleichheitszeichen)|Gleich|A2 = 3|
|<> (Ungleichheitszeichen)|Ungleich|A2 <> 3|
|> (Größer‑als‑Zeichen)|Größer als|A2 > 3|
|>= (Größer‑als‑oder‑gleich‑Zeichen)|Größer‑als‑oder‑gleich|A2 >= 3|
|< (Kleiner‑als‑Zeichen)|Kleiner als|A2 < 3|
|<= (Kleiner‑als‑oder‑gleich‑Zeichen)|Kleiner‑als‑oder‑gleich|A2 <= 3|

## **A1‑Style Zellreferenzen**
**A1‑Style Zellreferenzen** werden für Arbeitsblätter verwendet, bei denen die Spalte einen Buchstaben‑Identifier (z. B. "*A*") und die Zeile einen numerischen Identifier (z. B. "*1*") hat. A1‑Style Zellreferenzen können wie folgt verwendet werden:



|**Zellreferenz**|**Beispiel**|||
| :- | :- | :- | :- |
||Absolut|Relativ|Gemischt|
|Zelle|$A$2|A2|<p>A$2</p><p>$A2</p>|
|Zeile|$2:$2|2:2|-|
|Spalte|$A:$A|A:A|-|
|Bereich|$A$2:$C$4|A2:C4|<p>$A$2:C4</p><p>A$2:$C4</p>|


Hier ein Beispiel, wie man eine A1‑Style Zellreferenz in einer Formel verwendet:




## **R1C1‑Style Zellreferenzen**
**R1C1‑Style Zellreferenzen** werden für Arbeitsblätter verwendet, bei denen sowohl Zeile als auch Spalte einen numerischen Identifier besitzen. R1C1‑Style Zellreferenzen können wie folgt verwendet werden:



|**Zellreferenz**|**Beispiel**|||
| :- | :- | :- | :- |
||Absolut|Relativ|Gemischt|
|Zelle|R2C3|R[2]C[3]|R2C[3]<br>R[2]C3|
|Zeile|R2|R[2]|-|
|Spalte|C3|C[3]|-|
|Bereich|R2C3:R5C7|R[2]C[3]:R[5]C[7]|R2C3:R[5]C[7]<br>R[2]C3:R5C[7]|


Hier ein Beispiel, wie man eine R1C1‑Style Zellreferenz in einer Formel verwendet:




## **Vordefinierte Funktionen**
Es gibt vordefinierte Funktionen, die in Formeln verwendet werden können, um deren Implementierung zu vereinfachen. Diese Funktionen kapseln häufig genutzte Operationen, wie zum Beispiel: 

- ABS
- AVERAGE
- CEILING
- CHOOSE
- CONCAT
- CONCATENATE
- DATE (1900‑Datumssystem)
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

Ja. Aspose.Slides unterstützt externe Arbeitsmappen als [Diagrammdatenquelle](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatasourcetype/), sodass Sie Formeln aus einer XLSX‑Datei außerhalb der Präsentation verwenden können.

**Können Diagramm‑Formeln Blätter innerhalb derselben Arbeitsmappe per Blattname referenzieren?**

Ja. Formeln folgen dem üblichen Excel‑Referenzmodell, sodass Sie andere Blätter derselben Arbeitsmappe oder einer externen Arbeitsmappe referenzieren können. Für externe Referenzen geben Sie Pfad und Arbeitsmappennamen gemäß Excel‑Syntax an.
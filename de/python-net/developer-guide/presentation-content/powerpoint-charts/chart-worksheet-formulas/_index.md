---
title: Diagramm Arbeitsblattformeln
type: docs
weight: 70
url: /de/python-net/chart-worksheet-formulas/
keywords: "Diagramm Tabellenkalkulation, Diagramm Formel, PowerPoint Präsentation, Python, Aspose.Slides für Python über .NET"
description: "Diagramm Tabellenkalkulation und Formel in PowerPoint Präsentation in Python"
---


## **Über die Diagramm Tabellenkalkulationsformel in Präsentationen**
**Diagramm Tabellenkalkulation** (oder Diagramm Arbeitsblatt) in Präsentationen ist die Datenquelle des Diagramms. Die Diagramm Tabellenkalkulation enthält Daten, die auf grafische Weise im Diagramm dargestellt werden. Wenn Sie ein Diagramm in PowerPoint erstellen, wird das Arbeitsblatt, das mit diesem Diagramm verknüpft ist, automatisch erstellt. Das Diagramm Arbeitsblatt wird für alle Arten von Diagrammen erstellt: Liniendiagramm, Säulendiagramm, Sonnenblumen-Diagramm, Kreisdiagramm usw. Um die Diagramm Tabellenkalkulation in PowerPoint zu sehen, sollten Sie doppelt auf das Diagramm klicken:

![todo:image_alt_text](chart-worksheet-formulas_1.png)



Die Diagramm Tabellenkalkulation enthält die Namen der Diagrammelemente (Kategorie Name: *Kategorie1*, Serienname) und eine Tabelle mit numerischen Daten, die den Kategorien und Serien entsprechen. Standardmäßig, wenn Sie ein neues Diagramm erstellen - sind die Daten der Diagramm Tabellenkalkulation mit den Standarddaten festgelegt. Anschließend können Sie die Tabellenkalkulationsdaten im Arbeitsblatt manuell ändern.

In der Regel repräsentiert das Diagramm komplizierte Daten (z.B. Finanzanalysten, wissenschaftliche Analysten), die Zellen haben, die aus den Werten in anderen Zellen oder aus anderen dynamischen Daten berechnet werden. Den Wert einer Zelle manuell zu berechnen und ihn fest in die Zelle einzugeben, erschwert eine zukünftige Änderung. Wenn Sie den Wert einer bestimmten Zelle ändern, müssen auch alle abhängigen Zellen aktualisiert werden. Darüber hinaus können Tabellendaten von Daten aus anderen Tabellen abhängen, was eine komplexe Datenpräsentationsstruktur schafft, die einfach und flexibel aktualisiert werden muss.

**Diagramm Tabellenkalkulationsformel** in Präsentationen ist ein Ausdruck zur automatischen Berechnung und Aktualisierung der Daten der Diagramm Tabellenkalkulation. Die Tabellenkalkulationsformel definiert die Datenberechnungslogik für eine bestimmte Zelle oder eine Gruppe von Zellen. Eine Tabellenkalkulationsformel ist eine mathematische Formel oder eine logische Formel, die verwendet: Zellreferenzen, mathematische Funktionen, logische Operatoren, arithmetische Operatoren, Konvertierungsfunktionen, Stringkonstanten usw. Die Definition der Formel wird in eine Zelle geschrieben, und diese Zelle enthält keinen einfachen Wert. Die Tabellenkalkulationsformel berechnet den Wert und gibt ihn zurück, dann wird dieser Wert der Zelle zugewiesen. Die Diagramm Tabellenkalkulationsformeln in Präsentationen sind tatsächlich dieselben wie Excel-Formeln, und es werden dieselben Standardfunktionen, Operatoren und Konstanten zur Implementierung unterstützt.

In [**Aspose.Slides**](https://products.aspose.com/slides/python-net/) wird die Diagramm Tabellenkalkulation durch die 
[**Chart.ChartData.ChartDataWorkbook**](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdata/) Eigenschaft des 
[**IChartDataWorkbook**](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdataworkbook/) Typs dargestellt. 
Die Tabellenkalkulationsformel kann mit der 
[**formula**](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdatacell/) Eigenschaft zugewiesen und geändert werden. 
Die folgende Funktionalität wird für Formeln in Aspose.Slides unterstützt:

- Logische Konstanten
- Numerische Konstanten
- Stringkonstanten
- Fehlerkonstanten
- Arithmetische Operatoren
- Vergleichsoperatoren
- A1-Style Zellreferenzen
- R1C1-Style Zellreferenzen
- Vorgegebene Funktionen



In der Regel speichern Tabellenkalkulationen die zuletzt berechneten Formelwerte. Wenn nach dem Laden der Präsentation die Diagrammdaten nicht geändert wurden - gibt die **IChartDataCell.Value** Eigenschaft diese Werte beim Lesen zurück. Wenn jedoch die Tabellenkalkulationsdaten geändert wurden, löst die **ChartDataCell.Value** Eigenschaft eine **CellUnsupportedDataException** für die nicht unterstützten Formeln aus. Dies liegt daran, dass beim erfolgreichen Parsen der Formeln die Zellabhängigkeiten bestimmt und die Korrektheit der letzten Werte festgestellt wird. Wenn die Formel jedoch nicht geparst werden kann, kann die Korrektheit des Zellwerts nicht garantiert werden.
## **Diagramm Tabellenkalkulationsformel zur Präsentation hinzufügen**
Zuerst fügen Sie ein Diagramm mit einigen Beispieldaten zur ersten Folie einer neuen Präsentation hinzu mit 
[add_chart](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/). 
Das Arbeitsblatt des Diagramms wird automatisch erstellt und kann mit der 
[**chart_data_workbook**](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdata/) Eigenschaft aufgerufen werden:



```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 150, 150, 500, 300)
    workbook = chart.chart_data.chart_data_workbook
    # ...
```



Lassen Sie uns einige Werte in Zellen mit der 
[**value**](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdatacell/) Eigenschaft 
des **Object** Typs schreiben, was bedeutet, dass Sie beliebige Werte für die Eigenschaft festlegen können:



```py
    workbook.get_cell(0, "F2").value = -2.5
    workbook.get_cell(0, "G3").value = 6.3
    workbook.get_cell(0, "H4").value = 3
```



Nun, um eine Formel in die Zelle zu schreiben, können Sie die 
[**formula**](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdatacell/) Eigenschaft verwenden:

```py
    workbook.get_cell(0, "B2").formula = "F2+G3+H4+1"
```

*Hinweis*: [**IChartDataCell.Formula**](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdatacell/) Eigenschaft wird verwendet, um A1-Style Zellreferenzen festzulegen. 



Um die [r1c1_formula](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdatacell/) Zellreferenz festzulegen, können Sie die [**r1c1_formula**](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdatacell/) Eigenschaft verwenden:

```py
    workbook.get_cell(0, "C2").r1c1_formula = "R[1]C[4]/R[2]C[5]"
```

Verwenden Sie dann die [**calculate_formulas**](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/) Methode, um alle Formeln innerhalb des Arbeitsbuchs zu berechnen und die entsprechenden Zellwerte zu aktualisieren:



```py
    workbook.calculate_formulas()
    print(workbook.get_cell(0, "B2").value) # 7.8
    print(workbook.get_cell(0, "C2").value) # 2.1
```


## **Logische Konstanten**
Sie können logische Konstanten wie *FALSE* und *TRUE* in Zellformeln verwenden:




## **Numerische Konstanten**
Zahlen können in gängiger oder wissenschaftlicher Notation verwendet werden, um Diagramm Tabellenkalkulationsformeln zu erstellen:




## **String Konstanten**
Eine String (oder literale) Konstante ist ein spezifischer Wert, der so verwendet wird, wie er ist und sich nicht ändert. Stringkonstanten können sein: Daten, Texte, Zahlen usw.:




## **Fehler Konstanten**
Manchmal ist es nicht möglich, das Ergebnis anhand der Formel zu berechnen. In diesem Fall wird der Fehlercode anstelle seines Wertes in der Zelle angezeigt. Jeder Fehlerart hat einen spezifischen Code:

- #DIV/0! - die Formel versucht, durch Null zu teilen.
- #GETTING_DATA - kann in einer Zelle angezeigt werden, während ihr Wert noch berechnet wird.
- #N/A - Informationen fehlen oder sind nicht verfügbar. Einige Gründe können sein: die in der Formel verwendeten Zellen sind leer, ein zusätzlicher Leerraum, Schreibfehler usw.
- #NAME? - eine bestimmte Zelle oder andere Formelobjekte können nicht unter ihrem Namen gefunden werden. 
- #NULL! - kann erscheinen, wenn ein Fehler in der Formel vorliegt, wie:  (,) oder ein Leerzeichen anstelle eines Doppelpunktes (:).
- #NUM! - die Zahl in der Formel kann ungültig, zu lang oder zu klein sein usw.
- #REF! - ungültige Zellreferenz.
- #VALUE! - unerwarteter Werttyp. Zum Beispiel: Stringwert, der in einer numerischen Zelle gesetzt wurde.




## **Arithmetische Operatoren**
Sie können alle arithmetischen Operatoren in Diagramm Arbeitsblattformeln verwenden:



|**Operator** |**Bedeutung** |**Beispiel**|
| :- | :- | :- |
|+ (Pluszeichen) |Addition oder unärer Plus|2 + 3|
|- (Minuszeichen) |Subtraktion oder Negation |2 - 3<br>-3|
|* (Stern)|Multiplikation |2 * 3|
|/ (Schrägstrich)|Division |2 / 3|
|% (Prozentzeichen) |Prozent |30%|
|^ (Zirkumflex) |Exponentiation |2 ^ 3|


*Hinweis*: Um die Reihenfolge der Auswertung zu ändern, schließen Sie den Teil der Formel, der zuerst berechnet werden soll, in Klammern ein.


## **Vergleichsoperatoren**
Sie können die Werte der Zellen mit den Vergleichsoperatoren vergleichen. Wenn zwei Werte mit diesen Operatoren verglichen werden, ist das Ergebnis ein logischer Wert, entweder *TRUE* oder FALSE:



|**Operator** |**Bedeutung** |**Bedeutung** |
| :- | :- | :- |
|= (gleiches Zeichen) |Gleich |A2 = 3|
|<> (ungleich Zeichen) |Ungleich|A2 <> 3|
|> (größer als Zeichen) |Größer als|A2 > 3|
|>= (größer als oder gleich Zeichen)|Größer als oder gleich zu|A2 >= 3|
|< (weniger als Zeichen)|Weniger als|A2 < 3|
|<= (weniger als oder gleich Zeichen)|Weniger als oder gleich zu|A2 <= 3|

## **A1-Style Zellreferenzen**
**A1-Style Zellreferenzen** werden für die Arbeitsblätter verwendet, bei denen die Spalte einen Buchstaben als Identifikator hat (z.B. "*A*") und die Zeile eine numerische Kennung hat (z.B. "*1*"). A1-Style Zellreferenzen können wie folgt verwendet werden:



|**Zellreferenz**|**Beispiel**|||
| :- | :- | :- | :- |
||Absolut |Relativ |Gemischt|
|Zelle |$A$2 |A2|<p>A$2</p><p>$A2</p>|
|Zeile |$2:$2 |2:2 |-|
|Spalte |$A:$A |A:A |-|
|Bereich |$A$2:$C$4 |A2:C4|<p>$A$2:C4</p><p>A$2:$C4</p>|


Hier ist ein Beispiel, wie eine A1-Style Zellreferenz in einer Formel verwendet wird:




## **R1C1-Style Zellreferenzen**
**R1C1-Style Zellreferenzen** werden für die Arbeitsblätter verwendet, bei denen sowohl die Zeile als auch die Spalte einen numerischen Identifikator haben. R1C1-Style Zellreferenzen können wie folgt verwendet werden:



|**Zellreferenz**|**Beispiel**|||
| :- | :- | :- | :- |
||Absolut |Relativ |Gemischt|
|Zelle |R2C3|R[2]C[3]|R2C[3]<br>R[2]C3|
|Zeile |R2|R[2]|-|
|Spalte |C3|C[3]|-|
|Bereich |R2C3:R5C7|R[2]C[3]:R[5]C[7] |R2C3:R[5]C[7]<br>R[2]C3:R5C[7]|


Hier ist ein Beispiel, wie eine A1-Style Zellreferenz in einer Formel verwendet wird:




## **Vorgegebene Funktionen**
Es gibt vorgegebene Funktionen, die in den Formeln verwendet werden können, um deren Implementierung zu vereinfachen. Diese Funktionen kapseln die am häufigsten verwendeten Operationen ein, wie: 

- ABS
- AVERAGE
- CEILING
- CHOOSE
- CONCAT
- CONCATENATE
- DATE (1900 Datensystem)
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
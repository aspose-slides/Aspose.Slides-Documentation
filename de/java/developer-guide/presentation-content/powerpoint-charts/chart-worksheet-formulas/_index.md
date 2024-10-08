---
title: Diagramm Arbeitsblattformeln
type: docs
weight: 70
url: /de/java/chart-worksheet-formulas/
keywords: "powerpoint gleichungen, powerpoint tabellenformeln"
description: "PowerPoint Gleichungen und Tabellenformeln"
---


## **Über Diagramm Tabellenformeln in Präsentationen**
**Diagramm Tabelle** (oder Diagramm Arbeitsblatt) in der Präsentation ist die Datenquelle des Diagramms. Die Diagramm Tabelle enthält Daten, die auf dem Diagramm grafisch dargestellt werden. Wenn Sie ein Diagramm in PowerPoint erstellen, wird das mit diesem Diagramm verbundene Arbeitsblatt automatisch erstellt. Das Diagramm Arbeitsblatt wird für alle Arten von Diagrammen erstellt: Liniendiagramm, Balkendiagramm, Sonnenblenden-Diagramm, Kreisdiagramm usw. Um die Diagramm Tabelle in PowerPoint zu sehen, sollten Sie doppelt auf das Diagramm klicken:

![todo:image_alt_text](chart-worksheet-formulas_1.png)


Die Diagramm Tabelle enthält die Namen der Diagrammelemente (Kategorie Name: *Kategorie1*, Serien Name) und eine Tabelle mit numerischen Daten, die zu diesen Kategorien und Serien gehören. Standardmäßig werden beim Erstellen eines neuen Diagramms die Daten der Diagramm Tabelle mit den Standarddaten gesetzt. Dann können Sie die Tabellen Daten im Arbeitsblatt manuell ändern.

In der Regel stellt das Diagramm komplizierte Daten dar (z.B. Finanzanalysten, wissenschaftliche Analysten), bei denen Zellen vorhanden sind, die aus Werten in anderen Zellen oder aus anderen dynamischen Daten berechnet werden. Den Wert einer Zelle manuell zu berechnen und ihn in die Zelle fest einzugeben, macht es schwierig, ihn in Zukunft zu ändern. Wenn Sie den Wert einer bestimmten Zelle ändern, müssen auch alle Zellen, die davon abhängen, aktualisiert werden. Darüber hinaus können die Tabellendaten von den Daten anderer Tabellen abhängen, was ein komplexes Präsentationsdaten-Schema schafft, das auf einfache und flexible Weise aktualisiert werden muss.

**Diagramm Tabellenformel** in der Präsentation ist ein Ausdruck, um die Daten der Diagramm Tabelle automatisch zu berechnen und zu aktualisieren. Eine Tabellenformel definiert die Datenberechnungslogik für eine bestimmte Zelle oder eine Gruppe von Zellen. Eine Tabellenformel ist eine mathematische Formel oder eine logische Formel, die Zellenverweise, mathematische Funktionen, logische Operatoren, arithmetische Operatoren, Umrechnungsfunktionen, Zeichenkonstanten usw. verwendet. Die Definition der Formel wird in eine Zelle geschrieben, und diese Zelle enthält keinen einfachen Wert. Die Tabellenformel berechnet den Wert und gibt ihn zurück, dann wird dieser Wert der Zelle zugewiesen. Die Diagramm Tabellenformeln in Präsentationen sind tatsächlich die gleichen wie Excel-Formeln, und es werden die gleichen Standardfunktionen, Operatoren und Konstanten für deren Implementierung unterstützt.

In [**Aspose.Slides**](https://products.aspose.com/slides/java/) wird die Diagramm Tabelle mit der 
[**Chart.getChartData.getChartDataWorkbook**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartData#getChartDataWorkbook--) Methode des
[**IChartDataWorkbook**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataWorkbook) Typs dargestellt. 
Die Tabellenformel kann mit der 
[**IChartDataCell.setFormula**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataCell#setFormula-java.lang.String-) Methode zugewiesen und geändert werden. 
Die folgende Funktionalität wird für Formeln in Aspose.Slides unterstützt:

- Logische Konstanten
- Numerische Konstanten
- Zeichenkonstanten
- Fehlerkonstanten
- Arithmetische Operatoren
- Vergleichsoperatoren
- A1-Stil Zellenverweise
- R1C1-Stil Zellenverweise
- Vorher definierte Funktionen


Typischerweise speichern Tabellen die zuletzt berechneten Formelwerte. Wenn nach dem Laden der Präsentation die Diagrammdaten nicht geändert wurden - gibt die Methode [**IChartDataCell.getValue**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataCell#getValue--) diese Werte zurück, während sie gelesen werden. Wenn sich jedoch die Tabellen Daten geändert haben, wird beim Lesen der **ChartDataCell.Value**-Eigenschaft die 
[**CellUnsupportedDataException**](https://reference.aspose.com/slides/java/com.aspose.slides/CellUnsupportedDataException) für nicht unterstützte Formeln ausgelöst. Dies liegt daran, dass beim erfolgreichen Parsen der Formeln die Zellenabhängigkeiten bestimmt und die Richtigkeit der letzten Werte überprüft wird. Wenn die Formel jedoch nicht geparst werden kann, kann die Richtigkeit des Zellwerts nicht garantiert werden.

## **Diagramm Tabellenformel zur Präsentation hinzufügen**
Zuerst fügen Sie ein Diagramm zur ersten Folie einer neuen Präsentation mit 
[IShapeCollection.getShapes.addChart](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addChart-int-float-float-float-float-). 
Das Arbeitsblatt des Diagramms wird automatisch erstellt und kann mit der 
[**Chart.getChartData.getChartDataWorkbook**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartData#getChartDataWorkbook--) Methode zugegriffen werden:



```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 150, 150, 500, 300);

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    // ...
} finally {
    if (pres != null) pres.dispose();
}
```

Lass uns einige Werte in Zellen mit der 
[**IChartDataCell.setValue**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataCell#setValue-java.lang.Object-) Eigenschaft
des **Object** Typs schreiben, was bedeutet, dass Sie jeden Wert dieser Eigenschaft zuweisen können:

```java
workbook.getCell(0, "F2").setValue(-2.5);

workbook.getCell(0, "G3").setValue(6.3);

workbook.getCell(0, "H4").setValue(3);
```

Jetzt können Sie, um eine Formel in die Zelle zu schreiben, die 
[**IChartDataCell.setFormula**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataCell#setFormula-java.lang.String-) Methode verwenden:

*Hinweis*: Die [**IChartDataCell.setFormula**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataCell#setFormula-java.lang.String-) Methode wird verwendet, um A1-Stil Zellenverweise zu setzen. 

Um den [R1C1Formula](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataCell#getR1C1Formula--) Zellenverweis zu setzen, können Sie die [**IChartDataCell.setR1C1Formula**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataCell#setR1C1Formula-java.lang.String-) Methode verwenden:

Wenn Sie dann versuchen, die Werte aus den Zellen B2 und C2 zu lesen, werden sie berechnet:

```java
Object value1 = cell1.getValue(); // 7.8

Object value2 = cell2.getValue(); // 2.1
```

## **Logische Konstanten**
Sie können logische Konstanten wie *FALSE* und *TRUE* in Zellformeln verwenden:

```java
workbook.getCell(0, "A2").setValue(false);
IChartDataCell cell = workbook.getCell(0, "B2");
cell.setFormula("A2 = TRUE");
Object value = cell.getValue(); // der Wert enthält "false"
```

## **Numerische Konstanten**
Zahlen können in gewöhnlichen oder wissenschaftlichen Notationen verwendet werden, um eine Diagramm Tabellenformel zu erstellen:

```java
workbook.getCell(0, "A2").setFormula("1 + 0.5");
workbook.getCell(0, "B2").setFormula(".3 * 1E-2");
```

## **Zeichenkonstanten**
Eine Zeichenkonstante (oder literale Konstante) ist ein spezifischer Wert, der so verwendet wird, wie er ist und sich nicht ändert. Zeichenkonstanten können: Daten, Texte, Zahlen usw. sein:

```java
workbook.getCell(0, "A2").setFormula("\"abc\"");
workbook.getCell(0, "B2").setFormula("\"2/3/2020 12:00\"");
```

## **Fehlerkonstanten**
Manchmal ist es nicht möglich, das Ergebnis durch die Formel zu berechnen. In diesem Fall wird der Fehlercode anstelle seines Wertes in der Zelle angezeigt. Jeder Art von Fehler hat einen spezifischen Code:

- #DIV/0! - die Formel versucht, durch Null zu dividieren.
- #GETTING_DATA - kann auf einer Zelle angezeigt werden, während ihr Wert noch berechnet wird.
- #N/A - Informationen fehlen oder sind nicht verfügbar. Einige Gründe können sein: die Zellen, die in der Formel verwendet wurden, sind leer, ein zusätzliches Leerzeichen, Schreibfehler usw.
- #NAME? - eine bestimmte Zelle oder andere Formelobjekte können nicht unter ihrem Namen gefunden werden.
- #NULL! - kann erscheinen, wenn ein Fehler in der Formel vorliegt, wie:  (,) oder ein Leerzeichen anstelle eines Doppelpunktes (:).
- #NUM! - die Zahl in der Formel kann ungültig, zu lang oder zu klein sein, usw.
- #REF! - ungültiger Zellenverweis.
- #VALUE! - unerwarteter Werttyp. Zum Beispiel, ein Zeichenwert, der in einer numerischen Zelle gesetzt wird.

```java
IChartDataCell cell = workbook.getCell(0, "A2");
cell.setFormula("2 / 0");
Object value = cell.getValue(); // der Wert enthält den String "#DIV/0!"
```

## **Arithmetische Operatoren**
Sie können alle arithmetischen Operatoren in Diagramm Arbeitsblattformeln verwenden:

|**Operator** |**Bedeutung** |**Beispiel**|
| :- | :- | :- |
|+ (Pluszeichen) |Addition oder unärer Plus|2 + 3|
|- (Minuszeichen) |Subtraktion oder Negation |2 - 3<br>-3|
|* (Sternchen)|Multiplikation |2 * 3|
|/ (Schrägstrich)|Division |2 / 3|
|% (Prozentzeichen) |Prozent |30%|
|^ (Zirkumflex) |Exponentiation |2 ^ 3|

*Hinweis*: Um die Reihenfolge der Auswertung zu ändern, setzen Sie den Teil der Formel, der zuerst berechnet werden soll, in Klammern.

## **Vergleichsoperatoren**
Sie können die Werte von Zellen mit den Vergleichsoperatoren vergleichen. Wenn zwei Werte mit diesen Operatoren verglichen werden, ist das Ergebnis ein logischer Wert, entweder *TRUE* oder FALSE:

|**Operator** |**Bedeutung** |**Bedeutung** |
| :- | :- | :- |
|= (Gleichheitszeichen) |Gleich |A2 = 3|
|<> (ungleich Zeichen) |Ungleich|A2 <> 3|
|> (größer als Zeichen) |Größer als|A2 > 3|
|>= (größer oder gleich Zeichen)|Größer oder gleich|A2 >= 3|
|< (kleiner als Zeichen)|Kleiner als|A2 < 3|
|<= (kleiner oder gleich Zeichen)|Kleiner oder gleich|A2 <= 3|

## **A1-Stil Zellenverweise**
**A1-Stil Zellenverweise** werden für die Arbeitsblätter verwendet, bei denen die Spalte eine Buchstabenkennung (z.B. "*A*") und die Zeile eine nummerische Kennung (z.B. "*1*") hat. A1-Stil Zellenverweise können wie folgt verwendet werden:

|**Zellenverweis**|**Beispiel**|||
| :- | :- | :- | :- |
||Absolut |Relativ |Gemischt|
|Zelle |$A$2 |A2|<p>A$2</p><p>$A2</p>|
|Zeile |$2:$2 |2:2 |-|
|Spalte |$A:$A |A:A |-|
|Bereich |$A$2:$C$4 |A2:C4|<p>$A$2:C4</p><p>A$2:$C4</p>|


Hier ist ein Beispiel, wie man einen A1-Stil Zellenverweis in einer Formel verwendet:

```java
workbook.getCell(0, "A2").setFormula("C3 + SUM(F2:H5)");
```

## **R1C1-Stil Zellenverweise**
**R1C1-Stil Zellenverweise** werden für die Arbeitsblätter verwendet, bei denen sowohl eine Zeile als auch eine Spalte die nummerische Kennung haben. R1C1-Stil Zellenverweise können wie folgt verwendet werden:

|**Zellenverweis**|**Beispiel**|||
| :- | :- | :- | :- |
||Absolut |Relativ |Gemischt|
|Zelle |R2C3|R[2]C[3]|R2C[3]<br>R[2]C3|
|Zeile |R2|R[2]|-|
|Spalte |C3|C[3]|-|
|Bereich |R2C3:R5C7|R[2]C[3]:R[5]C[7] |R2C3:R[5]C[7]<br>R[2]C3:R5C[7]|


Hier ist ein Beispiel, wie man einen A1-Stil Zellenverweis in einer Formel verwendet:

```java
workbook.getCell(0, "A2").setR1C1Formula("R2C4 + SUM(R5C6:R7C9)");
```

## **Vorher definierte Funktionen**
Es gibt vorher definierte Funktionen, die in den Formeln verwendet werden können, um ihre Implementierung zu vereinfachen. Diese Funktionen kapseln die am häufigsten verwendeten Operationen ein, wie:

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
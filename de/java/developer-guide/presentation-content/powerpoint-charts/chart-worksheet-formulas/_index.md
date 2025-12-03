---
title: Diagramm-Arbeitsblatt-Formeln in Präsentationen mit Java anwenden
linktitle: Arbeitsblatt-Formeln
type: docs
weight: 70
url: /de/java/chart-worksheet-formulas/
keywords:
- Diagramm-Tabellenblatt
- Diagramm-Arbeitsblatt
- Diagramm-Formel
- Arbeitsblatt-Formel
- Tabellenkalkulationsformel
- Datenquelle
- Logische Konstante
- Numerische Konstante
- Zeichenkettenkonstante
- Fehlerkonstante
- Arithmetische Konstante
- Vergleichsoperator
- A1-Stil
- R1C1-Stil
- Vordefinierte Funktion
- PowerPoint
- Präsentation
- Java
- Aspose.Slides
description: "Excel-ähnliche Formeln in Aspose.Slides für Java-Diagramm-Arbeitsblätter anwenden und Berichte in PPT- und PPTX-Dateien automatisieren."
---

## **Über Diagramm‑Tabellen‑Formel in der Präsentation**
**Chart spreadsheet** (oder chart worksheet) in der Präsentation ist die Datenquelle des Diagramms. Das Chart‑Spreadsheet enthält Daten, die im Diagramm grafisch dargestellt werden. Wenn Sie ein Diagramm in PowerPoint erstellen, wird das zugehörige Arbeitsblatt automatisch erstellt. Das Diagramm‑Arbeitsblatt wird für alle Diagrammtypen erstellt: Liniendiagramm, Balkendiagramm, Sunburst‑Diagramm, Kreisdiagramm usw. Um das Chart‑Spreadsheet in PowerPoint zu sehen, doppelklicken Sie auf das Diagramm:

![todo:image_alt_text](chart-worksheet-formulas_1.png)


Das Chart‑Spreadsheet enthält die Namen der Diagrammelemente (Category Name: *Category1*, Serie Name) und eine Tabelle mit numerischen Daten, die zu diesen Kategorien und Serien passen. Standardmäßig werden beim Erstellen eines neuen Diagramms die Chart‑Spreadsheet‑Daten mit Standardwerten belegt. Anschließend können Sie die Tabellendaten im Arbeitsblatt manuell ändern.

In der Regel stellt das Diagramm komplexe Daten dar (z. B. Finanzanalysten, Wissenschaftler), bei denen Zellen aus den Werten anderer Zellen oder aus dynamischen Daten berechnet werden. Das manuelle Berechnen des Zellenwerts und das harte Kodieren in die Zelle erschwert spätere Änderungen. Wenn Sie den Wert einer bestimmten Zelle ändern, müssen alle davon abhängigen Zellen ebenfalls aktualisiert werden. Darüber hinaus können Tabellendaten von Daten anderer Tabellen abhängen, was ein komplexes Präsentations‑Datenschema erzeugt, das leicht und flexibel aktualisiert werden muss.

**Chart‑Spreadsheet‑Formel** in der Präsentation ist ein Ausdruck, der die Chart‑Spreadsheet‑Daten automatisch berechnet und aktualisiert. Eine Spreadsheet‑Formel definiert die Berechnungslogik für eine bestimmte Zelle oder einen Zellenbereich. Die Formel ist eine mathematische oder logische Formel, die verwendet: Zellreferenzen, mathematische Funktionen, logische Operatoren, arithmetische Operatoren, Konvertierungsfunktionen, Zeichenkettenkonstanten usw. Die Definition der Formel wird in eine Zelle geschrieben; diese Zelle enthält keinen einfachen Wert. Die Spreadsheet‑Formel berechnet den Wert und gibt ihn zurück, dann wird dieser Wert der Zelle zugewiesen. Chart‑Spreadsheet‑Formeln in Präsentationen entsprechen den Excel‑Formeln und unterstützen dieselben Standardfunktionen, Operatoren und Konstanten.

In [**Aspose.Slides**](https://products.aspose.com/slides/java/) wird das Chart‑Spreadsheet mit der
[**Chart.getChartData.getChartDataWorkbook**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartData#getChartDataWorkbook--)‑Methode des
[**IChartDataWorkbook**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataWorkbook)-Typs dargestellt. 
Eine Spreadsheet‑Formel kann mit 
[**IChartDataCell.setFormula**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataCell#setFormula-java.lang.String-) zugewiesen und geändert werden. 
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


Typischerweise speichern Tabellen die zuletzt berechneten Formelergebnisse. Wenn nach dem Laden der Präsentation die Diagrammdaten nicht geändert wurden, liefert die [**IChartDataCell.getValue**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataCell#getValue--)‑Methode diese Werte beim Lesen. Wenn jedoch die Tabellendaten geändert wurden, wirft das Lesen der **ChartDataCell.Value**‑Eigenschaft die [**CellUnsupportedDataException**](https://reference.aspose.com/slides/java/com.aspose.slides/CellUnsupportedDataException)‑Ausnahme für nicht unterstützte Formeln. Das liegt daran, dass bei erfolgreich geparsten Formeln die Zellenabhängigkeiten ermittelt und die Korrektheit der letzten Werte bestimmt wird. Können Formeln nicht geparst werden, lässt sich die Korrektheit des Zellenwerts nicht garantieren.

## **Diagramm‑Tabellen‑Formel zur Präsentation hinzufügen**
Zuerst fügen Sie einer neuen Präsentation auf der ersten Folie ein Diagramm mit 
[IShapeCollection.getShapes.addChart](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addChart-int-float-float-float-float-) hinzu. 
Das Arbeitsblatt des Diagramms wird automatisch erstellt und kann mit 
[**Chart.getChartData.getChartDataWorkbook**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartData#getChartDataWorkbook--) aufgerufen werden:
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


Schreiben Sie einige Werte in Zellen mit 
[**IChartDataCell.setValue**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataCell#setValue-java.lang.Object-)‑Eigenschaft 
des **Object**‑Typs, was bedeutet, dass Sie jeden Wert zuweisen können:
```java
workbook.getCell(0, "F2").setValue(-2.5);

workbook.getCell(0, "G3").setValue(6.3);

workbook.getCell(0, "H4").setValue(3);
```


Um nun eine Formel in die Zelle zu schreiben, verwenden Sie die 
[**IChartDataCell.setFormula**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataCell#setFormula-java.lang.String-)‑Methode:

*Hinweis*: [**IChartDataCell.setFormula**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataCell#setFormula-java.lang.String-) wird verwendet, um A1‑Style Zellreferenzen zu setzen. 

Um die [R1C1Formula](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataCell#getR1C1Formula--)‑Zellreferenz zu setzen, können Sie die [**IChartDataCell.setR1C1Formula**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataCell#setR1C1Formula-java.lang.String-)‑Methode verwenden:

Wenn Sie dann die Werte aus den Zellen B2 und C2 auslesen, werden sie berechnet:
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
Object value = cell.getValue(); // Der Wert enthält den booleschen Wert "false"
```


## **Numerische Konstanten**
Zahlen können in Dezimal‑ oder wissenschaftlicher Notation verwendet werden, um Diagramm‑Tabellen‑Formeln zu erstellen:
```java
workbook.getCell(0, "A2").setFormula("1 + 0.5");
workbook.getCell(0, "B2").setFormula(".3 * 1E-2");
```


## **Zeichenketten‑Konstanten**
Eine Zeichenketten‑ (oder Literal‑)Konstante ist ein fester Wert, der unverändert verwendet wird. Zeichenketten‑Konstanten können sein: Daten, Texte, Zahlen usw.:
```java
workbook.getCell(0, "A2").setFormula("\"abc\"");
workbook.getCell(0, "B2").setFormula("\"2/3/2020 12:00\"");
```


## **Fehler‑Konstanten**
Manchmal ist es nicht möglich, das Ergebnis der Formel zu berechnen. In diesem Fall wird im Feld ein Fehlercode anstelle des Werts angezeigt. Jeder Fehlertyp hat einen eigenen Code:

- #DIV/0! – Formel versucht, durch Null zu teilen.
- #GETTING_DATA – kann in einer Zelle angezeigt werden, während ihr Wert noch berechnet wird.
- #N/A – Information fehlt oder ist nicht verfügbar. Ursachen können sein: leere Zellen, ein zusätzliches Leerzeichen, Schreibfehler usw.
- #NAME? – ein bestimmtes Feld oder andere Formelobjekte können nicht über ihren Namen gefunden werden. 
- #NULL! – kann auftreten, wenn ein Fehler in der Formel vorliegt, z. B.  (,) oder ein Leerzeichen anstelle eines Doppelpunkts (:).
- #NUM! – die numerische Angabe in der Formel ist ungültig, zu lang oder zu kurz usw.
- #REF! – ungültige Zellreferenz.
- #VALUE! – unerwarteter Werttyp. Zum Beispiel ein Zeichenkettenwert in einer numerischen Zelle.
```java
IChartDataCell cell = workbook.getCell(0, "A2");
cell.setFormula("2 / 0");
Object value = cell.getValue(); // Der Wert enthält die Zeichenkette "#DIV/0!"
```


## **Arithmetische Operatoren**
Sie können alle arithmetischen Operatoren in Diagramm‑Arbeitsblatt‑Formeln verwenden:

|**Operator**|**Bedeutung**|**Beispiel**|
| :- | :- | :- |
|+ (Pluszeichen)|Addition oder unäres Plus|2 + 3|
|- (Minuszeichen)|Subtraktion oder Negation|2 - 3<br>-3|
|* (Stern)|Multiplikation|2 * 3|
|/ (Schrägstrich)|Division|2 / 3|
|% (Prozentzeichen)|Prozent|30%|
|^ (Caret)|Exponentiation|2 ^ 3|

*Hinweis*: Um die Reihenfolge der Auswertung zu ändern, setzen Sie den zuerst zu berechnenden Teil der Formel in Klammern.

## **Vergleichsoperatoren**
Sie können Zellwerte mit den Vergleichsoperatoren vergleichen. Beim Vergleich zweier Werte liefert dieser Operator einen logischen Wert, entweder *TRUE* oder *FALSE*:

|**Operator**|**Bedeutung**|**Beispiel**|
| :- | :- | :- |
|= (Gleichheitszeichen)|Gleich|A2 = 3|
|<> (Ungleichheitszeichen)|Ungleich|A2 <> 3|
|> (Größer‑als‑Zeichen)|Größer als|A2 > 3|
|>= (Größer‑als‑oder‑gleich‑Zeichen)|Größer‑als‑oder‑gleich|A2 >= 3|
|< (Kleiner‑als‑Zeichen)|Kleiner als|A2 < 3|
|<= (Kleiner‑als‑oder‑gleich‑Zeichen)|Kleiner‑als‑oder‑gleich|A2 <= 3|

## **A1‑Style Zellreferenzen**
**A1‑Style Zellreferenzen** werden für Arbeitsblätter verwendet, bei denen die Spalte mit einem Buchstaben (z. B. "*A*") und die Zeile mit einer Zahl (z. B. "*1*") gekennzeichnet ist. A1‑Style Zellreferenzen können wie folgt verwendet werden:

|**Zellreferenz**|**Beispiel**| | |
| :- | :- | :- | :- |
| |Absolute|Relativ|Gemischt|
|Zelle|$A$2|A2|<p>A$2</p><p>$A2</p>|
|Zeile|$2:$2|2:2|-|
|Spalte|$A:$A|A:A|-|
|Bereich|$A$2:$C$4|A2:C4|<p>$A$2:C4</p><p>A$2:$C4</p>|


Hier ein Beispiel, wie man eine A1‑Style Zellreferenz in einer Formel verwendet:
```java
workbook.getCell(0, "A2").setFormula("C3 + SUM(F2:H5)");
```


## **R1C1‑Style Zellreferenzen**
**R1C1‑Style Zellreferenzen** werden für Arbeitsblätter verwendet, bei denen sowohl Zeile als auch Spalte numerisch gekennzeichnet sind. R1C1‑Style Zellreferenzen können wie folgt verwendet werden:

|**Zellreferenz**|**Beispiel**| | |
| :- | :- | :- | :- |
| |Absolute|Relativ|Gemischt|
|Zelle|R2C3|R[2]C[3]|R2C[3]<br>R[2]C3|
|Zeile|R2|R[2]|-|
|Spalte|C3|C[3]|-|
|Bereich|R2C3:R5C7|R[2]C[3]:R[5]C[7]|R2C3:R[5]C[7]<br>R[2]C3:R5C[7]|


Hier ein Beispiel, wie man eine R1C1‑Style Zellreferenz in einer Formel verwendet:
```java
workbook.getCell(0, "A2").setR1C1Formula("R2C4 + SUM(R5C6:R7C9)");
```


## **Vordefinierte Funktionen**
Es gibt vordefinierte Funktionen, die in Formeln verwendet werden können, um deren Implementierung zu vereinfachen. Diese Funktionen kapseln die am häufigsten genutzten Operationen, wie:

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

Ja. Aspose.Slides unterstützt externe Arbeitsmappen als [Datenquelle des Diagramms](https://reference.aspose.com/slides/java/com.aspose.slides/chartdatasourcetype/), sodass Sie Formeln aus einer XLSX‑Datei außerhalb der Präsentation nutzen können.

**Können Diagramm‑Formeln Blätter innerhalb derselben Arbeitsmappe per Blattname referenzieren?**

Ja. Formeln folgen dem standardisierten Excel‑Referenzmodell, sodass Sie andere Blätter derselben Arbeitsmappe oder einer externen Arbeitsmappe referenzieren können. Für externe Referenzen geben Sie Pfad und Dateinamen nach Excel‑Syntax an.
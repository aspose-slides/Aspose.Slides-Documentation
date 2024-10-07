---
title: Diagramm-Arbeitsblatt-Formeln
type: docs
weight: 70
url: /androidjava/chart-worksheet-formulas/
keywords: "powerpoint gleichungen, powerpoint tabellenformeln"
description: "PowerPoint-Gleichungen und Tabellenformeln"
---


## **Über Diagramm-Arbeitsblattformeln in Präsentationen**
**Diagramm-Arbeitsblatt** (oder Diagramm-Arbeitsblatt) in der Präsentation ist die Datenquelle des Diagramms. Das Diagramm-Arbeitsblatt enthält Daten, die grafisch im Diagramm dargestellt werden. Wenn Sie ein Diagramm in PowerPoint erstellen, wird das mit diesem Diagramm verbundene Arbeitsblatt automatisch erstellt. Das Diagramm-Arbeitsblatt wird für alle Arten von Diagrammen erstellt: Liniengrafik, Balkendiagramm, Sonnenblumen-Diagramm, Kreisdiagramm usw. Um das Diagramm-Arbeitsblatt in PowerPoint zu sehen, sollten Sie doppelt auf das Diagramm klicken:

![todo:image_alt_text](chart-worksheet-formulas_1.png)


Das Diagramm-Arbeitsblatt enthält die Namen der Diagrammelemente (Kategorienname: *Kategorie1*, Serienname) und eine Tabelle mit numerischen Daten, die für diese Kategorien und Serien passend sind. Standardmäßig werden beim Erstellen eines neuen Diagramms die Daten des Diagramm-Arbeitsblatts mit den Standarddaten festgelegt. Dann können Sie die Daten des Arbeitsblatts manuell ändern.

Normalerweise stellt das Diagramm komplizierte Daten dar (z. B. Finanzanalysten, wissenschaftliche Analysten), die Zellen haben, die aus den Werten in anderen Zellen oder aus anderen dynamischen Daten berechnet werden. Das manuelle Berechnen des Wertes einer Zelle und das Hardcodieren in die Zelle macht es schwierig, diesen in der Zukunft zu ändern. Wenn Sie den Wert einer bestimmten Zelle ändern, müssen auch alle von ihm abhängigen Zellen aktualisiert werden. Darüber hinaus können die Tabellendaten von Daten aus anderen Tabellen abhängig sein, was ein komplexes Präsentationsdatenschema schafft, das leicht und flexibel aktualisiert werden muss.

**Diagramm-Arbeitsblattformel** in der Präsentation ist ein Ausdruck, um automatisch Daten des Diagramm-Arbeitsblatts zu berechnen und zu aktualisieren. Die Arbeitsblattformel definiert die Datenberechnungslogik für eine bestimmte Zelle oder eine Gruppe von Zellen. Eine Arbeitsblattformel ist eine mathematische oder logische Formel, die verwendet: Zellreferenzen, mathematische Funktionen, logische Operatoren, arithmetische Operatoren, Konvertierungsfunktionen, Zeichenkonstanten usw. Die Definition der Formel wird in einer Zelle geschrieben, und diese Zelle enthält keinen einfachen Wert. Die Arbeitsblattformel berechnet den Wert und gibt ihn zurück, dann wird dieser Wert der Zelle zugewiesen. Diagramm-Arbeitsblattformeln in Präsentationen sind tatsächlich die gleichen wie Excel-Formeln, und es werden die gleichen Standardfunktionen, Operatoren und Konstanten unterstützt.

In [**Aspose.Slides**](https://products.aspose.com/slides/androidjava/) wird das Diagramm-Arbeitsblatt mit der Methode 
[**Chart.getChartData.getChartDataWorkbook**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartData#getChartDataWorkbook--) des
[**IChartDataWorkbook**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartDataWorkbook) Typs dargestellt.
Die Arbeitsblattformel kann mit der 
[**IChartDataCell.setFormula**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartDataCell#setFormula-java.lang.String-) Methode zugewiesen und geändert werden.
Die folgende Funktionalität wird für Formeln in Aspose.Slides unterstützt:

- Logische Konstanten
- Numerische Konstanten
- Zeichenkonstanten
- Fehlerkonstanten
- Arithmetische Operatoren
- Vergleichsoperatoren
- A1-Stil Zellreferenzen
- R1C1-Stil Zellreferenzen
- Vorgegebene Funktionen


Typischerweise speichern Tabellen die zuletzt berechneten Formelwerte. Wenn nach dem Laden der Präsentation die Daten des Diagramms nicht geändert wurden, gibt die [**IChartDataCell.getValue**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartDataCell#getValue--) Methode diese Werte beim Lesen zurück. Wenn jedoch die Daten des Arbeitsblatts geändert wurden, wird beim Lesen der **ChartDataCell.Value** Eigenschaft die 
[**CellUnsupportedDataException**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/CellUnsupportedDataException) für die nicht unterstützten Formeln ausgelöst. Dies liegt daran, dass die Abhängigkeiten der Zellen bestimmt und die Richtigkeit der letzten Werte festgelegt wird, wenn die Formeln erfolgreich analysiert werden. Wenn die Formel jedoch nicht geparst werden kann, kann die Richtigkeit des Zellwerts nicht garantiert werden.

## **Diagramm-Arbeitsblattformel zur Präsentation hinzufügen**
Zuerst fügen Sie ein Diagramm zur ersten Folie einer neuen Präsentation mit 
[IShapeCollection.getShapes.addChart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addChart-int-float-float-float-float-).
Das Arbeitsblatt des Diagramms wird automatisch erstellt und kann mit der 
[**Chart.getChartData.getChartDataWorkbook**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartData#getChartDataWorkbook--) Methode aufgerufen werden:



```java
Präsentation pres = new Präsentation();
try {
    IChart diagramm = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 150, 150, 500, 300);

    IChartDataWorkbook arbeitsbuch = diagramm.getChartData().getChartDataWorkbook();

    // ...
} finally {
    if (pres != null) pres.dispose();
}
```

Lassen Sie uns einige Werte in Zellen mit der 
[**IChartDataCell.setValue**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartDataCell#setValue-java.lang.Object-) Eigenschaft des **Object** Typs schreiben, was bedeutet, dass Sie jeden Wert auf die Eigenschaft setzen können:

```java
arbeitsbuch.getCell(0, "F2").setValue(-2.5);

arbeitsbuch.getCell(0, "G3").setValue(6.3);

arbeitsbuch.getCell(0, "H4").setValue(3);
```

Jetzt, um die Formel in die Zelle zu schreiben, können Sie die 
[**IChartDataCell.setFormula**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartDataCell#setFormula-java.lang.String-) Methode verwenden:

*Hinweis*: Die [**IChartDataCell.setFormula**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartDataCell#setFormula-java.lang.String-) Methode wird verwendet, um A1-Stil Zellreferenzen festzulegen. 

Um die [R1C1Formel](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartDataCell#getR1C1Formula--) Zellreferenz festzulegen, können Sie die [**IChartDataCell.setR1C1Formula**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartDataCell#setR1C1Formula-java.lang.String-) Methode verwenden:

Wenn Sie dann versuchen, die Werte aus den Zellen B2 und C2 zu lesen, werden sie berechnet:

```java
Object wert1 = cell1.getValue(); // 7.8

Object wert2 = cell2.getValue(); // 2.1
```

## **Logische Konstanten**
Sie können logische Konstanten wie *FALSE* und *TRUE* in Zellformeln verwenden:

```java
arbeitsbuch.getCell(0, "A2").setValue(false);
IChartDataCell zelle = arbeitsbuch.getCell(0, "B2");
zelle.setFormula("A2 = TRUE");
Object wert = zelle.getValue(); // der Wert enthält boolean "false"
```

## **Numerische Konstanten**
Zahlen können in gängigen oder wissenschaftlichen Notationen verwendet werden, um die Diagramm-Arbeitsblattformel zu erstellen:

```java
arbeitsbuch.getCell(0, "A2").setFormula("1 + 0.5");
arbeitsbuch.getCell(0, "B2").setFormula(".3 * 1E-2");
```

## **Zeichenkonstanten**
Eine Zeichenkonstante (oder literale Konstante) ist ein spezifischer Wert, der so verwendet wird, wie er ist und sich nicht ändert. Zeichenkonstanten können: Daten, Texte, Zahlen usw. sein:

```java
arbeitsbuch.getCell(0, "A2").setFormula("\"abc\"");
arbeitsbuch.getCell(0, "B2").setFormula("\"2/3/2020 12:00\"");
```

## **Fehlerkonstanten**
Manchmal ist es nicht möglich, das Ergebnis durch die Formel zu berechnen. In diesem Fall wird anstelle des Wertes der Fehlercode in der Zelle angezeigt. Jeder Fehler hat einen spezifischen Code:

- #DIV/0! - die Formel versucht, durch Null zu teilen.
- #GETTING_DATA - kann in einer Zelle angezeigt werden, während ihr Wert noch berechnet wird.
- #N/A - Information fehlt oder ist nicht verfügbar. Einige Gründe können sein: die Zellen, die in der Formel verwendet werden, sind leer, ein zusätzliches Leerzeichen, Schreibfehler usw.
- #NAME? - eine bestimmte Zelle oder andere Formelobjekte können nicht unter ihrem Namen gefunden werden. 
- #NULL! - kann auftreten, wenn es einen Fehler in der Formel gibt, z. B.:  (,) oder ein Leerzeichen anstelle eines Doppelpunktes (:).
- #NUM! - die Zahl in der Formel kann ungültig, zu lang oder zu klein sein usw.
- #REF! - ungültige Zellreferenz.
- #VALUE! - unerwarteter Werttyp. Zum Beispiel, ein Zeichenwert, der in eine numerische Zelle gesetzt wird.

```java
IChartDataCell zelle = arbeitsbuch.getCell(0, "A2");
zelle.setFormula("2 / 0");
Object wert = zelle.getValue(); // der Wert enthält den String "#DIV/0!"
```

## **Arithmetische Operatoren**
Sie können alle arithmetischen Operatoren in Diagramm-Arbeitsblattformeln verwenden:

|**Operator** |**Bedeutung** |**Beispiel**|
| :- | :- | :- |
|+ (Pluszeichen) |Addition oder unärer Plus|2 + 3|
|- (Minuszeichen) |Subtraktion oder Negation |2 - 3<br>-3|
|* (Stern)|Multiplikation |2 * 3|
|/ (Schrägstrich)|Division |2 / 3|
|% (Prozentzeichen) |Prozent |30%|
|^ (Caret) |Exponentiation |2 ^ 3|

*Hinweis*: Um die Reihenfolge der Auswertung zu ändern, schließen Sie den Teil der Formel, der zuerst berechnet werden soll, in Klammern ein.

## **Vergleichsoperatoren**
Sie können die Werte von Zellen mit den Vergleichsoperatoren vergleichen. Wenn zwei Werte mit diesen Operatoren verglichen werden, ist das Ergebnis ein logischer Wert entweder *TRUE* oder FALSE:

|**Operator** |**Bedeutung** |**Bedeutung** |
| :- | :- | :- |
|= (Gleichheitszeichen) |Gleich zu |A2 = 3|
|<> (Ungleichheitszeichen) |Nicht gleich zu|A2 <> 3|
|> (Größer als Zeichen) |Größer als|A2 > 3|
|>= (Größer gleich Zeichen)|Größer als oder gleich|A2 >= 3|
|< (Kleiner als Zeichen)|Kleiner als|A2 < 3|
|<= (Kleiner gleich Zeichen)|Kleiner als oder gleich|A2 <= 3|

## **A1-Stil Zellreferenzen**
**A1-Stil Zellreferenzen** werden für die Arbeitsblätter verwendet, bei denen die Spalte einen Buchstaben-Identifikator (z. B. "*A*") hat und die Zeile einen numerischen Identifikator (z. B. "*1*"). A1-Stil Zellreferenzen können folgendermaßen verwendet werden:

|**Zellreferenz**|**Beispiel**|||
| :- | :- | :- | :- |
||Absolut |Relativ |Gemischt|
|Zelle |$A$2 |A2|<p>A$2</p><p>$A2</p>|
|Zeile |$2:$2 |2:2 |-|
|Spalte |$A:$A |A:A |-|
|Bereich |$A$2:$C$4 |A2:C4|<p>$A$2:C4</p><p>A$2:$C4</p>|


Hier ist ein Beispiel, wie Sie eine A1-Stil Zellreferenz in einer Formel verwenden:

```java
arbeitsbuch.getCell(0, "A2").setFormula("C3 + SUM(F2:H5)");
```

## **R1C1-Stil Zellreferenzen**
**R1C1-Stil Zellreferenzen** werden für die Arbeitsblätter verwendet, bei denen sowohl eine Zeile als auch eine Spalte den numerischen Identifikator haben. R1C1-Stil Zellreferenzen können folgendermaßen verwendet werden:

|**Zellreferenz**|**Beispiel**|||
| :- | :- | :- | :- |
||Absolut |Relativ |Gemischt|
|Zelle |R2C3|R[2]C[3]|R2C[3]<br>R[2]C3|
|Zeile |R2|R[2]|-|
|Spalte |C3|C[3]|-|
|Bereich |R2C3:R5C7|R[2]C[3]:R[5]C[7] |R2C3:R[5]C[7]<br>R[2]C3:R5C[7]|


Hier ist ein Beispiel, wie Sie eine A1-Stil Zellreferenz in einer Formel verwenden:

```java
arbeitsbuch.getCell(0, "A2").setR1C1Formula("R2C4 + SUM(R5C6:R7C9)");
```

## **Vorgegebene Funktionen**
Es gibt vorgegebene Funktionen, die in den Formeln verwendet werden können, um deren Implementierung zu vereinfachen. Diese Funktionen kapseln die am häufigsten verwendeten Operationen ein, wie: 

- ABS
- AVERAGE
- CEILING
- CHOOSE
- CONCAT
- CONCATENATE
- DATE (1900-Datensystem)
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
---
title: Anwenden von Diagramm-Arbeitsblatt-Formeln in Präsentationen auf Android
linktitle: Arbeitsblatt-Formeln
type: docs
weight: 70
url: /de/androidjava/chart-worksheet-formulas/
keywords:
- Diagramm-Tabellenkalkulation
- Diagramm-Arbeitsblatt
- Diagramm-Formel
- Arbeitsblatt-Formel
- Tabellenkalkulations-Formel
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
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Wenden Sie Excel‑ähnliche Formeln in Aspose.Slides für Android über Java‑Diagramm‑Arbeitsblätter an und automatisieren Sie Berichte in PPT‑ und PPTX‑Dateien."
---

## **Über Diagramm‑Tabellenkalkulationen in Präsentationen**
**Diagramm‑Tabellenkalkulation** (oder Diagramm‑Arbeitsblatt) in einer Präsentation ist die Datenquelle des Diagramms. Die Diagramm‑Tabellenkalkulation enthält Daten, die im Diagramm grafisch dargestellt werden. Wenn Sie in PowerPoint ein Diagramm erstellen, wird das dem Diagramm zugehörige Arbeitsblatt ebenfalls automatisch erstellt. Das Diagramm‑Arbeitsblatt wird für alle Diagrammtypen erstellt: Liniendiagramm, Balkendiagramm, Sunburst‑Diagramm, Kreisdiagramm usw. Um die Diagramm‑Tabellenkalkulation in PowerPoint zu sehen, sollten Sie doppelt auf das Diagramm klicken:

![todo:image_alt_text](chart-worksheet-formulas_1.png)


Die Diagramm‑Tabellenkalkulation enthält die Namen der Diagrammelemente (Kategoriename: *Category1*, Serienname) und eine Tabelle mit numerischen Daten, die zu diesen Kategorien und Serien passen. Standardmäßig werden beim Erstellen eines neuen Diagramms die Daten der Diagramm‑Tabellenkalkulation mit den Standarddaten gesetzt. Danach können Sie die Tabellendaten im Arbeitsblatt manuell ändern.

In der Regel stellt das Diagramm komplexe Daten dar (z. B. Finanzanalysten, Wissenschaftler), bei denen Zellen aus den Werten anderer Zellen oder aus anderen dynamischen Daten berechnet werden. Den Zellwert manuell zu berechnen und fest in die Zelle zu schreiben, erschwert zukünftige Änderungen. Ändern Sie den Wert einer bestimmten Zelle, müssen alle davon abhängigen Zellen ebenfalls aktualisiert werden. Darüber hinaus können Tabellendaten von anderen Tabellen abhängen, was ein komplexes Präsentationsdatenschema erzeugt, das einfach und flexibel aktualisiert werden muss.

**Diagramm‑Tabellenkalkulations‑Formel** in einer Präsentation ist ein Ausdruck, der die Daten der Diagramm‑Tabellenkalkulation automatisch berechnet und aktualisiert. Eine Tabellenkalkulations‑Formel definiert die Datenberechnungslogik für eine bestimmte Zelle oder einen Zellbereich. Eine Tabellenkalkulations‑Formel ist eine mathematische oder logische Formel, die verwendet: Zellbezüge, mathematische Funktionen, logische Operatoren, arithmetische Operatoren, Konvertierungsfunktionen, Zeichenketten‑Konstanten usw. Die Definition der Formel wird in einer Zelle geschrieben, und diese Zelle enthält keinen einfachen Wert. Die Formel berechnet den Wert und gibt ihn zurück, dann wird dieser Wert der Zelle zugewiesen. Diagramm‑Tabellenkalkulations‑Formeln in Präsentationen entsprechen tatsächlich Excel‑Formeln, und dieselben Standardfunktionen, Operatoren und Konstanten werden für deren Umsetzung unterstützt.

In [**Aspose.Slides**](https://products.aspose.com/slides/androidjava/) wird die Diagramm‑Tabellenkalkulation mit der Methode [**Chart.getChartData.getChartDataWorkbook**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartData#getChartDataWorkbook--) des Typs [**IChartDataWorkbook**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartDataWorkbook) dargestellt. Eine Tabellenkalkulations‑Formel kann mit der Methode [**IChartDataCell.setFormula**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartDataCell#setFormula-java.lang.String-) zugewiesen und geändert werden. Die folgende Funktionalität wird für Formeln in Aspose.Slides unterstützt:

- Logische Konstanten
- Numerische Konstanten
- Zeichenketten‑Konstanten
- Fehler‑Konstanten
- Arithmetische Operatoren
- Vergleichsoperatoren
- A1‑Stil Zellbezüge
- R1C1‑Stil Zellbezüge
- Vordefinierte Funktionen


Typischerweise speichern Tabellenkalkulationen die zuletzt berechneten Formelergebnisse. Wenn nach dem Laden der Präsentation die Diagrammdaten nicht geändert wurden, gibt die Methode [**IChartDataCell.getValue**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartDataCell#getValue--) diese Werte beim Lesen zurück. Wurden jedoch die Tabellendaten geändert, wirft das Lesen der Eigenschaft **ChartDataCell.Value** eine [**CellUnsupportedDataException**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/CellUnsupportedDataException) für nicht unterstützte Formeln. Das liegt daran, dass beim erfolgreichen Parsen von Formeln die Zellabhängigkeiten ermittelt und die Korrektheit der letzten Werte bestätigt wird. Kann eine Formel nicht geparst werden, lässt sich die Korrektheit des Zellwerts nicht garantieren.

## **Eine Diagramm‑Tabellenkalkulations‑Formel zu einer Präsentation hinzufügen**
Zunächst fügen Sie mit [IShapeCollection.getShapes.addChart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addChart-int-float-float-float-float-) ein Diagramm zur ersten Folie einer neuen Präsentation hinzu. Das Arbeitsblatt des Diagramms wird automatisch erstellt und kann mit der Methode [**Chart.getChartData.getChartDataWorkbook**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartData#getChartDataWorkbook--) zugegriffen werden:
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


Schreiben wir einige Werte in Zellen mit der Eigenschaft [**IChartDataCell.setValue**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartDataCell#setValue-java.lang.Object-) des Typs **Object**, was bedeutet, dass Sie beliebige Werte in die Eigenschaft schreiben können:
```java
workbook.getCell(0, "F2").setValue(-2.5);

workbook.getCell(0, "G3").setValue(6.3);

workbook.getCell(0, "H4").setValue(3);
```


Um jetzt eine Formel in die Zelle zu schreiben, können Sie die Methode [**IChartDataCell.setFormula**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartDataCell#setFormula-java.lang.String-) verwenden:

*Hinweis*: Die Methode [**IChartDataCell.setFormula**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartDataCell#setFormula-java.lang.String-) wird verwendet, um A1‑Stil Zellbezüge zu setzen.  

Um den [R1C1Formula](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartDataCell#getR1C1Formula--) Zellbezug zu setzen, können Sie die Methode [**IChartDataCell.setR1C1Formula**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartDataCell#setR1C1Formula-java.lang.String-) verwenden:

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
Object value = cell.getValue(); // Der Wert enthält den booleschen Wert "false"
```


## **Numerische Konstanten**
Zahlen können in dezimaler oder wissenschaftlicher Notation verwendet werden, um eine Diagramm‑Tabellenkalkulations‑Formel zu erstellen:
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
Manchmal ist es nicht möglich, das Ergebnis durch die Formel zu berechnen. In diesem Fall wird im Feld anstelle des Wertes ein Fehlercode angezeigt. Jeder Fehlertyp hat einen speziellen Code:

- #DIV/0! – Formel versucht, durch Null zu teilen.
- #GETTING_DATA – kann in einer Zelle angezeigt werden, während ihr Wert noch berechnet wird.
- #N/A – Information fehlt oder ist nicht verfügbar. Ursachen können sein: leere Zellen in der Formel, ein zusätzliches Leerzeichen, Rechtschreibfehler usw.
- #NAME? – ein bestimmtes Zell‑ oder Formelelement kann nicht über seinen Namen gefunden werden.
- #NULL! – tritt auf, wenn in der Formel ein Fehler wie (,) oder ein Leerzeichen anstelle eines Doppelpunkts (:) verwendet wird.
- #NUM! – die numerische Angabe in der Formel ist ungültig, zu lang oder zu klein usw.
- #REF! – ungültiger Zellbezug.
- #VALUE! – unerwarteter Werttyp, z. B. ein Zeichenkettenwert in einer numerischen Zelle.
```java
IChartDataCell cell = workbook.getCell(0, "A2");
cell.setFormula("2 / 0");
Object value = cell.getValue(); // der Wert enthält die Zeichenkette "#DIV/0!"
```


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

*Hinweis*: Um die Auswertungsreihenfolge zu ändern, setzen Sie den Teil der Formel, der zuerst berechnet werden soll, in Klammern.

## **Vergleichsoperatoren**
Sie können die Werte von Zellen mit den Vergleichsoperatoren vergleichen. Beim Vergleich von zwei Werten wird ein logischer Wert (*TRUE* oder *FALSE*) zurückgegeben:

|**Operator**|**Bedeutung**|**Bedeutung**|
| :- | :- | :- |
|= (Gleichheitszeichen)|Gleich|A2 = 3|
|<> (Ungleichheitszeichen)|Ungleich|A2 <> 3|
|> (Größer‑als‑Zeichen)|Größer als|A2 > 3|
|>= (Größer‑als‑oder‑gleich‑Zeichen)|Größer‑als‑oder‑gleich|A2 >= 3|
|< (Kleiner‑als‑Zeichen)|Kleiner als|A2 < 3|
|<= (Kleiner‑als‑oder‑gleich‑Zeichen)|Kleiner‑als‑oder‑gleich|A2 <= 3|

## **A1‑Stil Zellbezüge**
**A1‑Stil Zellbezüge** werden in Arbeitsblättern verwendet, bei denen die Spalte durch einen Buchstaben (z. B. *A*) und die Zeile durch eine Zahl (z. B. *1*) identifiziert wird. A1‑Stil Zellbezüge können wie folgt verwendet werden:

|**Zellbezug**|**Beispiel**|**Absolut**|**Relativ**|**Gemischt**|
| :- | :- | :- | :- | :- |
|Zelle|$A$2|A2|<p>A$2</p><p>$A2</p>|
|Zeile|$2:$2|2:2|-|
|Spalte|$A:$A|A:A|-|
|Bereich|$A$2:$C$4|A2:C4|<p>$A$2:C4</p><p>A$2:$C4</p>|


Hier ist ein Beispiel, wie man einen A1‑Stil Zellbezug in einer Formel verwendet:
```java
workbook.getCell(0, "A2").setFormula("C3 + SUM(F2:H5)");
```


## **R1C1‑Stil Zellbezüge**
**R1C1‑Stil Zellbezüge** werden in Arbeitsblättern verwendet, bei denen sowohl Zeile als auch Spalte durch Zahlen identifiziert werden. R1C1‑Stil Zellbezüge können wie folgt verwendet werden:

|**Zellbezug**|**Beispiel**|**Absolut**|**Relativ**|**Gemischt**|
| :- | :- | :- | :- | :- |
|Zelle|R2C3|R[2]C[3]|R2C[3]<br>R[2]C3|
|Zeile|R2|R[2]|-|
|Spalte|C3|C[3]|-|
|Bereich|R2C3:R5C7|R[2]C[3]:R[5]C[7]|R2C3:R[5]C[7]<br>R[2]C3:R5C[7]|


Hier ist ein Beispiel, wie man einen R1C1‑Stil Zellbezug in einer Formel verwendet:
```java
workbook.getCell(0, "A2").setR1C1Formula("R2C4 + SUM(R5C6:R7C9)");
```


## **Vordefinierte Funktionen**
Es gibt vordefinierte Funktionen, die in Formeln verwendet werden können, um deren Implementierung zu vereinfachen. Diese Funktionen kapseln die am häufigsten genutzten Operationen, wie zum Beispiel:

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

Ja. Aspose.Slides unterstützt externe Arbeitsmappen als [Diagrammdatenquelle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdatasourcetype/), sodass Sie Formeln aus einer XLSX‑Datei außerhalb der Präsentation verwenden können.

**Können Diagramm‑Formeln Blätter im selben Arbeitsbuch per Blattname referenzieren?**

Ja. Formeln folgen dem standardmäßigen Excel‑Referenzmodell, sodass Sie andere Blätter im selben Arbeitsbuch oder in einem externen Arbeitsbuch referenzieren können. Für externe Referenzen geben Sie Pfad und Arbeitsbuchnamen nach Excel‑Syntax an.
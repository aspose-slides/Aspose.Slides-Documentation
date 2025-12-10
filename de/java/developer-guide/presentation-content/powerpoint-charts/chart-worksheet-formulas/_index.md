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
- Tabellenblatt-Formel
- Datenquelle
- logische Konstante
- numerische Konstante
- Zeichenketten-Konstante
- Fehler-Konstante
- arithmetische Konstante
- Vergleichsoperator
- A1-Stil
- R1C1-Stil
- vordefinierte Funktion
- PowerPoint
- Präsentation
- Java
- Aspose.Slides
description: "Excel-ähnliche Formeln in Aspose.Slides für Java-Diagramm-Arbeitsblätter anwenden und Berichte in PPT- und PPTX-Dateien automatisieren."
---

## **Über Diagramm‑Tabellenblatt‑Formeln in Präsentationen**
**Diagramm‑Tabellenblatt** (oder Diagramm‑Arbeitsblatt) in einer Präsentation ist die Datenquelle des Diagramms. Das Diagramm‑Tabellenblatt enthält Daten, die im Diagramm grafisch dargestellt werden. Wenn Sie in PowerPoint ein Diagramm erstellen, wird das zugehörige Arbeitsblatt automatisch erzeugt. Das Diagramm‑Arbeitsblatt wird für alle Diagrammtypen erstellt: Liniendiagramm, Balkendiagramm, Sunburst‑Diagramm, Kreisdiagramm usw. Um das Diagramm‑Tabellenblatt in PowerPoint zu sehen, doppelklicken Sie auf das Diagramm:

![todo:image_alt_text](chart-worksheet-formulas_1.png)


Das Diagramm‑Tabellenblatt enthält die Namen von Diagrammelementen (Kategorienname: *Category1*, Serienname) und eine Tabelle mit numerischen Daten, die zu diesen Kategorien und Serien passen. Standardmäßig werden beim Erstellen eines neuen Diagramms die Daten des Diagramm‑Tabellenblatts mit Standardwerten gefüllt. Anschließend können Sie die Tabellendaten im Arbeitsblatt manuell ändern.

Üblicherweise stellt das Diagramm komplexe Daten dar (z. B. Finanzanalysen, wissenschaftliche Analysen), wobei Zellen aus den Werten anderer Zellen oder aus anderen dynamischen Daten berechnet werden. Einen Zellenwert manuell zu berechnen und fest in die Zelle zu schreiben, erschwert spätere Änderungen. Wenn Sie den Wert einer bestimmten Zelle ändern, müssen alle von ihr abhängigen Zellen ebenfalls aktualisiert werden. Darüber hinaus können Tabellendaten von Daten anderer Tabellen abhängen, wodurch ein komplexes Präsentationsdatenschema entsteht, das einfach und flexibel aktualisiert werden muss.

**Diagramm‑Tabellenblatt‑Formel** in einer Präsentation ist ein Ausdruck, der die Daten des Diagramm‑Tabellenblatts automatisch berechnet und aktualisiert. Eine Tabellenblatt‑Formel definiert die Datenberechnungslogik für eine bestimmte Zelle oder einen Zellbereich. Eine Tabellenblatt‑Formel ist eine mathematische oder logische Formel, die verwendet: Zellbezüge, mathematische Funktionen, logische Operatoren, arithmetische Operatoren, Konvertierungsfunktionen, Zeichenkettenkonstanten usw. Die Definition der Formel wird in eine Zelle geschrieben, und diese Zelle enthält keinen einfachen Wert. Die Formel berechnet den Wert und gibt ihn zurück, dann wird dieser Wert der Zelle zugewiesen. Diagramm‑Tabellenblatt‑Formeln in Präsentationen entsprechen exakt Excel‑Formeln, und dieselben Standardfunktionen, Operatoren und Konstanten werden unterstützt.

In [**Aspose.Slides**](https://products.aspose.com/slides/java/) wird das Diagramm‑Tabellenblatt durch die Methode 
[**Chart.getChartData.getChartDataWorkbook**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartData#getChartDataWorkbook--) des Typs 
[**IChartDataWorkbook**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataWorkbook) dargestellt. 
Tabellenblatt‑Formeln können mit  
[**IChartDataCell.setFormula**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataCell#setFormula-java.lang.String-) zugewiesen und geändert werden. 
Folgende Funktionalitäten werden für Formeln in Aspose.Slides unterstützt:

- Logische Konstanten
- Numerische Konstanten
- Zeichenketten‑Konstanten
- Fehler‑Konstanten
- Arithmetische Operatoren
- Vergleichsoperatoren
- A1‑Stil‑Zellbezüge
- R1C1‑Stil‑Zellbezüge
- Vorgegebene Funktionen


Typischerweise speichern Arbeitsblätter die zuletzt berechneten Formelergebnisse. Wenn nach dem Laden der Präsentation die Diagrammdaten nicht geändert wurden, liefert die Methode [**IChartDataCell.getValue**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataCell#getValue--) diese Werte beim Lesen. Wenn jedoch die Tabellendaten geändert wurden, wirft das Lesen der Eigenschaft **ChartDataCell.Value** die Ausnahme [**CellUnsupportedDataException**](https://reference.aspose.com/slides/java/com.aspose.slides/CellUnsupportedDataException) für nicht unterstützte Formeln. Das liegt daran, dass beim erfolgreichen Parsen einer Formel die Zellabhängigkeiten ermittelt und die Korrektheit der letzten Werte geprüft werden. Kann die Formel nicht geparst werden, kann die Korrektheit des Zellwerts nicht garantiert werden.

## **Hinzufügen einer Diagramm‑Tabellenblatt‑Formel zu einer Präsentation**
Fügen Sie zunächst einem neuen Präsentations‑Slide ein Diagramm hinzu mit 
[IShapeCollection.getShapes.addChart](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addChart-int-float-float-float-float-). 
Das Arbeitsblatt des Diagramms wird automatisch erstellt und kann über die Methode  
[**Chart.getChartData.getChartDataWorkbook**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartData#getChartDataWorkbook--) zugegriffen werden:
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


Schreiben wir einige Werte in Zellen mit der Eigenschaft  
[**IChartDataCell.setValue**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataCell#setValue-java.lang.Object-) vom Typ **Object**, was bedeutet, dass Sie beliebige Werte setzen können:
```java
workbook.getCell(0, "F2").setValue(-2.5);

workbook.getCell(0, "G3").setValue(6.3);

workbook.getCell(0, "H4").setValue(3);
```


Um nun eine Formel in die Zelle zu schreiben, können Sie die Methode  
[**IChartDataCell.setFormula**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataCell#setFormula-java.lang.String-) verwenden:

*Hinweis*: [**IChartDataCell.setFormula**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataCell#setFormula-java.lang.String-) wird verwendet, um A1‑Stil‑Zellbezüge zu setzen. 

Um den [R1C1Formula](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataCell#getR1C1Formula--)‑Zellbezug zu setzen, können Sie die Methode [**IChartDataCell.setR1C1Formula**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataCell#setR1C1Formula-java.lang.String-) nutzen:

Wenn Sie anschließend die Werte aus den Zellen B2 und C2 auslesen, werden sie berechnet:
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
Zahlen können in Dezimal‑ oder wissenschaftlicher Schreibweise verwendet werden, um Diagramm‑Tabellenblatt‑Formeln zu erstellen:
```java
workbook.getCell(0, "A2").setFormula("1 + 0.5");
workbook.getCell(0, "B2").setFormula(".3 * 1E-2");
```


## **Zeichenketten‑Konstanten**
Eine Zeichenketten‑ (oder Literal‑)Konstante ist ein fester Wert, der unverändert übernommen wird. Zeichenketten‑Konstanten können sein: Daten, Texte, Zahlen usw.:
```java
workbook.getCell(0, "A2").setFormula("\"abc\"");
workbook.getCell(0, "B2").setFormula("\"2/3/2020 12:00\"");
```


## **Fehler‑Konstanten**
Manchmal kann das Ergebnis einer Formel nicht berechnet werden. In diesem Fall wird im Feld stattdessen ein Fehlercode angezeigt. Jeder Fehlertyp hat einen spezifischen Code:

- #DIV/0! – Formel versucht, durch Null zu teilen.
- #GETTING_DATA – kann in einer Zelle erscheinen, während ihr Wert noch berechnet wird.
- #N/A – Information fehlt oder ist nicht verfügbar. Gründe können sein: leere Zellen im Bezug, ein zusätzliches Leerzeichen, Schreibfehler usw.
- #NAME? – ein bestimmtes Zell‑ oder Formelobjekt kann nicht über seinen Namen gefunden werden. 
- #NULL! – kann auftreten, wenn ein Formel­fehler wie (,) oder ein Leerzeichen anstelle eines Doppelpunkts (:) vorliegt.
- #NUM! – die in der Formel angegebene Zahl ist ungültig, zu groß oder zu klein usw.
- #REF! – ungültiger Zellbezug.
- #VALUE! – unerwarteter Werttyp, z. B. eine Zeichenkette in einer numerischen Zelle.
```java
IChartDataCell cell = workbook.getCell(0, "A2");
cell.setFormula("2 / 0");
Object value = cell.getValue(); // Der Wert enthält die Zeichenkette "#DIV/0!"
```


## **Arithmetische Operatoren**
Sie können alle arithmetischen Operatoren in Diagramm‑Arbeitsblatt‑Formeln verwenden:

|**Operator** |**Bedeutung** |**Beispiel**|
| :- | :- | :- |
|+ (Plus) |Addition oder unäres Plus|2 + 3|
|- (Minus) |Subtraktion oder Negation |2 - 3<br>-3|
|* (Sternchen)|Multiplikation |2 * 3|
|/ (Schrägstrich)|Division |2 / 3|
|% (Prozentzeichen) |Prozent |30%|
|^ (Caret) |Potenzierung |2 ^ 3|

*Hinweis*: Um die Auswertungsreihenfolge zu ändern, setzen Sie den zuerst zu berechnenden Teil in Klammern.

## **Vergleichsoperatoren**
Sie können Zellwerte mit Vergleichsoperatoren vergleichen. Das Ergebnis ist ein logischer Wert, entweder *TRUE* oder *FALSE*:

|**Operator** |**Bedeutung** |**Beispiel**|
| :- | :- | :- |
|= (Gleichheitszeichen) |Gleich |A2 = 3|
|<> (Ungleichheitszeichen) |Ungleich |A2 <> 3|
|> (Größer‑als‑Zeichen) |Größer |A2 > 3|
|>= (Größer‑oder‑gleich‑Zeichen)|Größer oder gleich |A2 >= 3|
|< (Kleiner‑als‑Zeichen)|Kleiner |A2 < 3|
|<= (Kleiner‑oder‑gleich‑Zeichen)|Kleiner oder gleich |A2 <= 3|

## **A1‑Stil‑Zellbezüge**
**A1‑Stil‑Zellbezüge** werden in Arbeitsblättern verwendet, bei denen die Spalte einen Buchstaben (z. B. "*A*") und die Zeile eine Zahl (z. B. "*1*") hat. A1‑Stil‑Zellbezüge können wie folgt verwendet werden:

|**Zellbezug**|**Beispiel**|||
| :- | :- | :- | :- |
||Absolut |Relativ |Gemischt|
|Zelle |$A$2 |A2|<p>A$2</p><p>$A2</p>|
|Zeile |$2:$2 |2:2 |-|
|Spalte |$A:$A |A:A |-|
|Bereich |$A$2:$C$4 |A2:C4|<p>$A$2:C4</p><p>A$2:$C4</p>|


Ein Beispiel für die Verwendung eines A1‑Stil‑Zellbezugs in einer Formel:
```java
workbook.getCell(0, "A2").setFormula("C3 + SUM(F2:H5)");
```


## **R1C1‑Stil‑Zellbezüge**
**R1C1‑Stil‑Zellbezüge** werden in Arbeitsblättern verwendet, bei denen sowohl Zeile als auch Spalte numerisch gekennzeichnet sind. R1C1‑Stil‑Zellbezüge können wie folgt verwendet werden:

|**Zellbezug**|**Beispiel**|||
| :- | :- | :- | :- |
||Absolut |Relativ |Gemischt|
|Zelle |R2C3|R[2]C[3]|R2C[3]<br>R[2]C3|
|Zeile |R2|R[2]|-|
|Spalte |C3|C[3]|-|
|Bereich |R2C3:R5C7|R[2]C[3]:R[5]C[7] |R2C3:R[5]C[7]<br>R[2]C3:R5C[7]|


Ein Beispiel für die Verwendung eines R1C1‑Stil‑Zellbezugs in einer Formel:
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

Ja. Aspose.Slides unterstützt externe Arbeitsmappen als [Datenquelle für Diagramme](https://reference.aspose.com/slides/java/com.aspose.slides/chartdatasourcetype/), sodass Sie Formeln aus einer XLSX‑Datei außerhalb der Präsentation verwenden können.

**Können Diagramm‑Formeln Arbeitsblätter innerhalb derselben Arbeitsmappe per Blattname referenzieren?**

Ja. Formeln folgen dem Standard‑Excel‑Referenzmodell, sodass Sie andere Blätter innerhalb derselben Arbeitsmappe oder einer externen Arbeitsmappe referenzieren können. Für externe Bezüge geben Sie Pfad und Arbeitsmappennamen nach Excel‑Syntax an.
---
title: Diagramm-Tabellenblatt-Formeln
type: docs
weight: 70
url: /de/nodejs-java/chart-worksheet-formulas/
keywords: "PowerPoint Gleichungen, PowerPoint Tabellenblatt-Formeln"
description: "PowerPoint Gleichungen und Tabellenblatt-Formeln"
---

## **Über Diagramm‑Tabellenformel in der Präsentation**
**Diagramm‑Tabellenblatt** (oder Diagramm‑Arbeitsblatt) in der Präsentation ist die Datenquelle des Diagramms.  
Das Diagramm‑Tabellenblatt enthält Daten, die im Diagramm grafisch dargestellt werden. Wenn Sie ein Diagramm in PowerPoint erstellen, wird das dem Diagramm zugehörige Arbeitsblatt ebenfalls automatisch erstellt. Diagramm‑Arbeitsblätter werden für alle Diagrammtypen erstellt: Liniendiagramm, Balkendiagramm, Sunburst‑Diagramm, Kreisdiagramm usw. Um das Diagramm‑Tabellenblatt in PowerPoint zu sehen, doppelklicken Sie auf das Diagramm:

![todo:image_alt_text](chart-worksheet-formulas_1.png)


Das Diagramm‑Tabellenblatt enthält die Namen der Diagrammelemente (Kategorie‑Name: *Category1*, Serien‑Name) und eine Tabelle mit numerischen Daten, die zu diesen Kategorien und Serien passen. Standardmäßig werden beim Erstellen eines neuen Diagramms die Diagramm‑Tabellendaten mit den Standarddaten befüllt. Anschließend können Sie die Tabellendaten im Arbeitsblatt manuell ändern.

Üblicherweise stellt das Diagramm komplizierte Daten dar (z. B. Finanzanalysen, wissenschaftliche Analysen) und enthält Zellen, die aus den Werten anderer Zellen oder aus anderen dynamischen Daten berechnet werden. Den Zellwert manuell zu berechnen und fest in die Zelle zu schreiben, erschwert zukünftige Änderungen. Wenn Sie den Wert einer bestimmten Zelle ändern, müssen alle von ihr abhängigen Zellen ebenfalls aktualisiert werden. Darüber hinaus können Tabellendaten von Daten anderer Tabellen abhängen, was ein komplexes Präsentationsdatenschema erzeugt, das auf einfache und flexible Weise aktualisiert werden muss.

**Diagramm‑Tabellenformel** in einer Präsentation ist ein Ausdruck, der Diagramm‑Tabellendaten automatisch berechnet und aktualisiert. Eine Tabellenformel definiert die Datenberechnungslogik für eine bestimmte Zelle oder einen Zellensatz. Eine Tabellenformel ist eine mathematische oder logische Formel, die verwendet: Zellbezüge, mathematische Funktionen, logische Operatoren, arithmetische Operatoren, Konvertierungsfunktionen, Zeichenkettenkonstanten usw. Die Definition der Formel wird in eine Zelle geschrieben, die keinen einfachen Wert enthält. Die Tabellenformel berechnet den Wert und gibt ihn zurück, danach wird dieser Wert der Zelle zugewiesen. Diagramm‑Tabellenformeln in Präsentationen entsprechen exakt Excel‑Formeln und unterstützen dieselben Standardfunktionen, Operatoren und Konstanten.

Im [**Aspose.Slides**](https://products.aspose.com/slides/nodejs-java/) wird das Diagramm‑Tabellenblatt durch die Methode [**Chart.getChartData.getChartDataWorkbook**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartData#getChartDataWorkbook--) des Typs [**ChartDataWorkbook**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartDataWorkbook) dargestellt.  
Eine Tabellenformel kann mit der Methode [**ChartDataCell.setFormula**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartDataCell#setFormula-java.lang.String-) zugewiesen und geändert werden.

Die folgende Funktionalität wird für Formeln in Aspose.Slides unterstützt:

- Logische Konstanten
- Numerische Konstanten
- Zeichenketten‑Konstanten
- Fehlerkonstanten
- Arithmetische Operatoren
- Vergleichsoperatoren
- A1‑Style Zellbezüge
- R1C1‑Style Zellbezüge
- Vordefinierte Funktionen

Typischerweise speichern Tabellen die zuletzt berechneten Formelwerte. Wenn nach dem Laden der Präsentation die Diagrammdaten nicht geändert wurden, gibt die Methode [**ChartDataCell.getValue**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartDataCell#getValue--) diese Werte beim Lesen zurück. Ändern sich jedoch die Tabellendaten, wird beim Lesen der Eigenschaft **ChartDataCell.Value** die Ausnahme [**CellUnsupportedDataException**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/CellUnsupportedDataException) für nicht unterstützte Formeln ausgelöst. Das liegt daran, dass nach erfolgreichem Parsen der Formeln die Zellabhängigkeiten und die Korrektheit der letzten Werte ermittelt werden. Kann die Formel jedoch nicht geparst werden, lässt sich die Korrektheit des Zellwerts nicht garantieren.

## **Diagramm‑Tabellenformel zur Präsentation hinzufügen**
Zunächst fügen Sie einer neuen Präsentation auf der ersten Folie ein Diagramm hinzu mit der Methode [ShapeCollection.getShapes.addChart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#addChart-int-float-float-float-float-).  
Das Arbeitsblatt des Diagramms wird automatisch erstellt und kann über die Methode [**Chart.getChartData.getChartDataWorkbook**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartData#getChartDataWorkbook--) zugegriffen werden:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 150, 150, 500, 300);
    var workbook = chart.getChartData().getChartDataWorkbook();
    // ...
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


Schreiben wir einige Werte in Zellen mit der Eigenschaft [**ChartDataCell.setValue**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartDataCell#setValue-java.lang.Object-) des Typs **Object**, was bedeutet, dass Sie jeder Eigenschaft einen beliebigen Wert zuweisen können:
```javascript
workbook.getCell(0, "F2").setValue(-2.5);
workbook.getCell(0, "G3").setValue(6.3);
workbook.getCell(0, "H4").setValue(3);
```


Um eine Formel in die Zelle zu schreiben, können Sie die Methode [**ChartDataCell.setFormula**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartDataCell#setFormula-java.lang.String-) verwenden:

*Hinweis*: Die Methode [**ChartDataCell.setFormula**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartDataCell#setFormula-java.lang.String-) wird verwendet, um A1‑Style Zellbezüge festzulegen.

Um den Zellbezug [R1C1Formula](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartDataCell#getR1C1Formula--) zu setzen, können Sie die Methode [**ChartDataCell.setR1C1Formula**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartDataCell#setR1C1Formula-java.lang.String-) verwenden:
```javascript
var value1 = cell1.getValue();// 7.8
var value2 = cell2.getValue();// 2.1
```


## **Logische Konstanten**
Sie können logische Konstanten wie *FALSE* und *TRUE* in Zellformeln verwenden:
```javascript
workbook.getCell(0, "A2").setValue(false);
var cell = workbook.getCell(0, "B2");
cell.setFormula("A2 = TRUE");
var value = cell.getValue();// der Wert enthält den booleschen Wert "false"
```


## **Numerische Konstanten**
Zahlen können in dezimaler oder wissenschaftlicher Schreibweise verwendet werden, um Diagramm‑Tabellenformeln zu erstellen:
```javascript
workbook.getCell(0, "A2").setFormula("1 + 0.5");
workbook.getCell(0, "B2").setFormula(".3 * 1E-2");
```


## **Zeichenketten‑Konstanten**
Eine Zeichenketten‑(oder Literal‑)Konstante ist ein spezifischer Wert, der unverändert verwendet wird und sich nicht ändert. Zeichenketten‑Konstanten können sein: Daten, Texte, Zahlen usw.:
```javascript
workbook.getCell(0, "A2").setFormula("\"abc\"");
workbook.getCell(0, "B2").setFormula("\"2/3/2020 12:00\"");
```


## **Fehlerkonstanten**
Manchmal ist es nicht möglich, das Ergebnis mit der Formel zu berechnen. In diesem Fall wird im Feld anstelle des Wertes ein Fehlercode angezeigt. Jeder Fehlertyp hat einen spezifischen Code:

- #DIV/0! – Formel versucht, durch Null zu teilen.
- #GETTING_DATA – kann in einer Zelle angezeigt werden, während ihr Wert noch berechnet wird.
- #N/A – Information fehlt oder ist nicht verfügbar. Gründe können sein: Die in der Formel verwendeten Zellen sind leer, ein zusätzliches Leerzeichen, ein Tippfehler usw.
- #NAME? – Eine bestimmte Zelle oder ein anderes Formelelement kann unter diesem Namen nicht gefunden werden.
- #NULL! – kann auftreten, wenn ein Fehler in der Formel vorliegt, z. B.: (,) oder ein Leerzeichen anstelle eines Doppelpunkts (:).
- #NUM! – die im Formel verwendete Zahl kann ungültig, zu groß oder zu klein sein usw.
- #REF! – ungültiger Zellbezug.
- #VALUE! – unerwarteter Werttyp. Zum Beispiel ein Zeichenkettenwert in einer numerischen Zelle.
```javascript
var cell = workbook.getCell(0, "A2");
cell.setFormula("2 / 0");
var value = cell.getValue();// der Wert enthält die Zeichenkette "#DIV/0!"
```


## **Arithmetische Operatoren**
Sie können alle arithmetischen Operatoren in Diagramm‑Arbeitsblatt‑Formeln verwenden:

|**Operator**|**Bedeutung**|**Beispiel**|
| :- | :- | :- |
|+ (plus sign)|Addition oder unäres Plus|2 + 3|
|- (minus sign)|Subtraktion oder Negation|2 - 3<br>-3|
|* (asterisk)|Multiplikation|2 * 3|
|/ (forward slash)|Division|2 / 3|
|% (percent sign)|Prozent|30%|
|^ (caret)|Exponentialfunktion|2 ^ 3|

*Hinweis*: Um die Reihenfolge der Auswertung zu ändern, setzen Sie den zuerst zu berechnenden Teil der Formel in Klammern.

## **Vergleichsoperatoren**
Sie können die Werte von Zellen mit den Vergleichsoperatoren vergleichen. Wenn zwei Werte mit diesen Operatoren verglichen werden, ergibt das einen logischen Wert, entweder *TRUE* oder *FALSE*:

|**Operator**|**Bedeutung**|**Beispiel**|
| :- | :- | :- |
|= (equal sign)|Gleich|A2 = 3|
|<> (not equal sign)|Ungleich|A2 <> 3|
|> (greater than sign)|Größer als|A2 > 3|
|>= (greater than or equal to sign)|Größer oder gleich|A2 >= 3|
|< (less than sign)|Kleiner als|A2 < 3|
|<= (less than or equal to sign)|Kleiner oder gleich|A2 <= 3|

## **A1‑Style Zellbezüge**
**A1‑Style Zellbezüge** werden für Arbeitsblätter verwendet, bei denen die Spalte einen Buchstaben‑Identifier (z. B. „*A*“) und die Zeile einen numerischen Identifier (z. B. „*1*“) hat. A1‑Style Zellbezüge können folgendermaßen verwendet werden:

|**Zellbezug**|**Beispiel**|||
| :- | :- | :- | :- |
||Absolut|Relativ|Gemischt|
|Zelle|$A$2|A2|<p>A$2</p><p>$A2</p>|
|Zeile|$2:$2|2:2|-|
|Spalte|$A:$A|A:A|-|
|Bereich|$A$2:$C$4|A2:C4|<p>$A$2:C4</p><p>A$2:$C4</p>|
```javascript
workbook.getCell(0, "A2").setFormula("C3 + SUM(F2:H5)");
```


## **R1C1‑Style Zellbezüge**
**R1C1‑Style Zellbezüge** werden für Arbeitsblätter verwendet, bei denen sowohl Zeile als auch Spalte einen numerischen Identifier besitzen. R1C1‑Style Zellbezüge können folgendermaßen verwendet werden:

|**Zellbezug**|**Beispiel**|||
| :- | :- | :- | :- |
||Absolut|Relativ|Gemischt|
|Zelle|R2C3|R[2]C[3]|R2C[3]<br>R[2]C3|
|Zeile|R2|R[2]|-|
|Spalte|C3|C[3]|-|
|Bereich|R2C3:R5C7|R[2]C[3]:R[5]C[7]|R2C3:R[5]C[7]<br>R[2]C3:R5C[7]|
```javascript
workbook.getCell(0, "A2").setR1C1Formula("R2C4 + SUM(R5C6:R7C9)");
```


## **Vordefinierte Funktionen**
Es gibt vordefinierte Funktionen, die in Formeln verwendet werden können, um deren Implementierung zu vereinfachen. Diese Funktionen kapseln die am häufigsten genutzten Vorgänge, wie zum Beispiel:

- ABS
- AVERAGE
- CEILING
- CHOOSE
- CONCAT
- CONCATENATE
- DATE (1900 date system)
- DAYS
- FIND
- FINDB
- IF
- INDEX (reference form)
- LOOKUP (vector form)
- MATCH (vector form)
- MAX
- SUM
- VLOOKUP

## **FAQ**

**Werden externe Excel‑Dateien als Datenquelle für ein Diagramm mit Formeln unterstützt?**

Ja. Aspose.Slides unterstützt externe Arbeitsmappen als [Diagramm‑Datenquelle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatasourcetype/), wodurch Sie Formeln aus einer XLSX‑Datei außerhalb der Präsentation verwenden können.

**Können Diagramm‑Formeln Arbeitsblätter innerhalb derselben Arbeitsmappe per Blattname referenzieren?**

Ja. Formeln folgen dem Standard‑Excel‑Referenzmodell, sodass Sie andere Blätter innerhalb derselben Arbeitsmappe oder einer externen Arbeitsmappe referenzieren können. Für externe Referenzen geben Sie Pfad und Arbeitsmappennamen mit Excel‑Syntax an.
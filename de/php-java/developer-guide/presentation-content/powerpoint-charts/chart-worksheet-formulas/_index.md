---
title: Diagramm‑Arbeitsblatt‑Formeln in Präsentationen mit PHP anwenden
linktitle: Arbeitsblatt‑Formeln
type: docs
weight: 70
url: /de/php-java/chart-worksheet-formulas/
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
- Präsentation
- PHP
- Aspose.Slides
description: "Excel‑ähnliche Formeln in Aspose.Slides für PHP über Java‑Diagramm‑Arbeitsblätter anwenden und Berichte für PPT‑ und PPTX‑Dateien automatisieren."
---

## **Über Diagramm‑Tabellenkalkulationsformeln in Präsentationen**
**Diagramm‑Tabellenkalkulation** (oder Diagramm‑Arbeitsblatt) in einer Präsentation ist die Datenquelle des Diagramms. Die Diagramm‑Tabellenkalkulation enthält Daten, die im Diagramm grafisch dargestellt werden. Wenn Sie ein Diagramm in PowerPoint erstellen, wird das zugehörige Arbeitsblatt automatisch erstellt. Das Diagramm‑Arbeitsblatt wird für alle Diagrammtypen erstellt: Liniendiagramm, Balkendiagramm, Sonnenblumen‑Diagramm, Kreisdiagramm usw. Um die Diagramm‑Tabellenkalkulation in PowerPoint zu sehen, doppelklicken Sie auf das Diagramm:

![todo:image_alt_text](chart-worksheet-formulas_1.png)


Die Diagramm‑Tabellenkalkulation enthält die Namen der Diagrammelemente (Kategoriename: *Category1*, Serienname) und eine Tabelle mit numerischen Daten, die zu diesen Kategorien und Serien passen. Standardmäßig, wenn Sie ein neues Diagramm erstellen, werden die Daten der Diagramm‑Tabellenkalkulation mit den Standarddaten gesetzt. Anschließend können Sie die Tabellendaten im Arbeitsblatt manuell ändern.

Normalerweise stellt das Diagramm komplexe Daten dar (z. B. Finanz‑ oder Wissenschaftsanalyse), bei denen Zellen aus den Werten anderer Zellen oder aus dynamischen Daten berechnet werden. Die manuelle Eingabe eines Zellwerts und das Hard‑Coden erschwert zukünftige Änderungen. Wenn Sie den Wert einer bestimmten Zelle ändern, müssen alle von ihr abhängigen Zellen ebenfalls aktualisiert werden. Darüber hinaus können Tabellendaten von Daten anderer Tabellen abhängen, was ein komplexes Präsentationsdatenschema erzeugt, das leicht und flexibel aktualisiert werden muss.

**Diagramm‑Tabellenkalkulationsformel** in einer Präsentation ist ein Ausdruck, der die Daten der Tabellenkalkulation automatisch berechnet und aktualisiert. Eine Tabellenkalkulationsformel definiert die Berechnungslogik für eine bestimmte Zelle oder einen Zellbereich. Sie ist eine mathematische oder logische Formel, die verwendet: Zellreferenzen, mathematische Funktionen, logische Operatoren, arithmetische Operatoren, Konvertierungsfunktionen, Zeichenkettenkonstanten usw. Die Definition der Formel wird in eine Zelle geschrieben; diese Zelle enthält keinen einfachen Wert. Die Formel berechnet den Wert, gibt ihn zurück und der Wert wird der Zelle zugewiesen. Diagramm‑Tabellenkalkulationsformeln in Präsentationen entsprechen exakt Excel‑Formeln und unterstützen dieselben Standardfunktionen, Operatoren und Konstanten.

In [**Aspose.Slides**](https://products.aspose.com/slides/php-java/) wird die Diagramm‑Tabellenkalkulation über die
[**Chart.getChartData.getChartDataWorkbook**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartData#getChartDataWorkbook--)‑Methode des
[**IChartDataWorkbook**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartDataWorkbook)‑Typs dargestellt.
Eine Tabellenkalkulationsformel kann mit
[**IChartDataCell.setFormula**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartDataCell#setFormula-java.lang.String-) zugewiesen und geändert werden.
Die folgende Funktionalität wird für Formeln in Aspose.Slides unterstützt:

- Logische Konstanten
- Numerische Konstanten
- Zeichenketten‑Konstanten
- Fehler‑Konstanten
- Arithmetische Operatoren
- Vergleichsoperatoren
- A1‑Style‑Zellreferenzen
- R1C1‑Style‑Zellreferenzen
- Vorgefertigte Funktionen


Typischerweise speichern Tabellenkalkulationen die zuletzt berechneten Formelergebnisse. Wenn nach dem Laden der Präsentation die Diagrammdaten nicht geändert wurden, gibt die
[**IChartDataCell.getValue**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartDataCell#getValue--)‑Methode diese Werte beim Lesen zurück. Wird jedoch die Tabellendaten geändert, wirft das Lesen der **ChartDataCell.Value**‑Eigenschaft die
[**CellUnsupportedDataException**](https://reference.aspose.com/slides/php-java/aspose.slides/CellUnsupportedDataException)‑Ausnahme für nicht unterstützte Formeln. Das liegt daran, dass bei erfolgreicher Analyse einer Formel die Zellabhängigkeiten ermittelt und die Korrektheit der letzten Werte bestimmt werden. Kann eine Formel nicht analysiert werden, lässt sich die Korrektheit des Zellwerts nicht garantieren.

## **Fügen Sie einer Präsentation eine Diagramm‑Tabellenkalkulationsformel hinzu**
Fügen Sie zunächst einer neuen Präsentation auf der ersten Folie ein Diagramm hinzu mit
[IShapeCollection.getShapes.addChart](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addChart-int-float-float-float-float-).
Das Arbeitsblatt des Diagramms wird automatisch erstellt und kann über
[**Chart.getChartData.getChartDataWorkbook**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartData#getChartDataWorkbook--)‑Methode abgerufen werden:
```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 150, 150, 500, 300);
    $workbook = $chart->getChartData()->getChartDataWorkbook();
    # ...
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


Schreiben wir einige Werte in Zellen mit der
[**IChartDataCell.setValue**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartDataCell#setValue-java.lang.Object-)‑Eigenschaft des **Object**‑Typs, was bedeutet, dass Sie beliebige Werte setzen können:
```php
  $workbook->getCell(0, "F2")->setValue(-2.5);
  $workbook->getCell(0, "G3")->setValue(6.3);
  $workbook->getCell(0, "H4")->setValue(3);

```


Um nun eine Formel in die Zelle zu schreiben, können Sie die
[**IChartDataCell.setFormula**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartDataCell#setFormula-java.lang.String-)‑Methode verwenden:

*Hinweis*: [**IChartDataCell.setFormula**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartDataCell#setFormula-java.lang.String-) wird verwendet, um A1‑Style‑Zellreferenzen zu setzen. 

Um die [R1C1Formula](https://reference.aspose.com/slides/php-java/aspose.slides/IChartDataCell#getR1C1Formula--)‑Zellreferenz zu setzen, können Sie die
[**IChartDataCell.setR1C1Formula**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartDataCell#setR1C1Formula-java.lang.String-)‑Methode verwenden:

Wenn Sie dann die Werte aus den Zellen B2 und C2 lesen, werden sie berechnet:
```php
  $value1 = $cell1->getValue();// 7.8

  $value2 = $cell2->getValue();// 2.1


```


## **Logische Konstanten**
Sie können logische Konstanten wie *FALSE* und *TRUE* in Zellformeln verwenden:
```php
  $workbook->getCell(0, "A2")->setValue(false);
  $cell = $workbook->getCell(0, "B2");
  $cell->setFormula("A2 = TRUE");
  $value = $cell->getValue();// Der Wert enthält den booleschen Wert "false"
```


## **Numerische Konstanten**
Zahlen können in dezimaler oder wissenschaftlicher Notation verwendet werden, um Diagramm‑Tabellenkalkulationsformeln zu erstellen:
```php
  $workbook->getCell(0, "A2")->setFormula("1 + 0.5");
  $workbook->getCell(0, "B2")->setFormula(".3 * 1E-2");

```


## **Zeichenketten‑Konstanten**
Eine Zeichenketten‑ (oder Literal‑)Konstante ist ein fester Wert, der unverändert verwendet wird. Zeichenketten‑Konstanten können sein: Daten, Texte, Zahlen usw.:
```php
  $workbook->getCell(0, "A2")->setFormula("\"abc\"");
  $workbook->getCell(0, "B2")->setFormula("\"2/3/2020 12:00\"");

```


## **Fehler‑Konstanten**
Manchmal ist es nicht möglich, das Ergebnis mit der Formel zu berechnen. In diesem Fall wird im Zellinhalt stattdessen der Fehlercode angezeigt. Jeder Fehlertyp hat einen spezifischen Code:

- #DIV/0! - Formel versucht, durch Null zu dividieren.
- #GETTING_DATA - kann in einer Zelle angezeigt werden, während ihr Wert noch berechnet wird.
- #N/A - Information fehlt oder ist nicht verfügbar. Gründe können sein: leere Zellen in der Formel, ein zusätzliches Leerzeichen, Tippfehler usw.
- #NAME? - ein bestimmtes Zell‑ oder Formelobjekt kann nicht über seinen Namen gefunden werden.
- #NULL! - kann auftreten, wenn in der Formel ein Fehler wie (,) oder ein Leerzeichen anstelle eines Doppelpunkts (:) verwendet wird.
- #NUM! - die numerische Angabe in der Formel ist ungültig, zu lang oder zu klein usw.
- #REF! - ungültige Zellreferenz.
- #VALUE! - unerwarteter Werttyp, z. B. ein Zeichenkettenwert in einer numerischen Zelle.
```php
  $cell = $workbook->getCell(0, "A2");
  $cell->setFormula("2 / 0");
  $value = $cell->getValue();// Der Wert enthält die Zeichenkette "#DIV/0!"


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

*Hinweis*: Um die Reihenfolge der Auswertung zu ändern, setzen Sie den zu berechnenden Teil in Klammern.

## **Vergleichsoperatoren**
Sie können Zellwerte mit den Vergleichsoperatoren vergleichen. Das Ergebnis ist ein logischer Wert, entweder *TRUE* oder *FALSE*:

|**Operator**|**Bedeutung**|**Bedeutung**|
| :- | :- | :- |
|= (Gleichheitszeichen)|Gleich|A2 = 3|
|<> (Ungleichheitszeichen)|Ungleich|A2 <> 3|
|> (Größer‑als‑Zeichen)|Größer als|A2 > 3|
|>= (Größer‑oder‑gleich‑Zeichen)|Größer oder gleich|A2 >= 3|
|< (Kleiner‑als‑Zeichen)|Kleiner als|A2 < 3|
|<= (Kleiner‑oder‑gleich‑Zeichen)|Kleiner oder gleich|A2 <= 3|

## **A1‑Style‑Zellreferenzen**
**A1‑Style‑Zellreferenzen** werden für Arbeitsblätter verwendet, bei denen die Spalte einen Buchstaben (z. B. *A*) und die Zeile eine Zahl (z. B. *1*) hat. Sie können wie folgt verwendet werden:

|**Zellreferenz**|**Beispiel**|**Absolut**|**Relativ**|**Gemischt**|
| :- | :- | :- | :- | :- |
|Zelle|$A$2|A2|<p>A$2</p><p>$A2</p>|
|Zeile|$2:$2|2:2|-|
|Spalte|$A:$A|A:A|-|
|Bereich|$A$2:$C$4|A2:C4|<p>$A$2:C4</p><p>A$2:$C4</p>|

Hier ein Beispiel, wie man eine A1‑Style‑Zellreferenz in einer Formel verwendet:
```php
  $workbook->getCell(0, "A2")->setFormula("C3 + SUM(F2:H5)");
```


## **R1C1‑Style‑Zellreferenzen**
**R1C1‑Style‑Zellreferenzen** werden für Arbeitsblätter verwendet, bei denen sowohl Zeile als auch Spalte numerisch gekennzeichnet sind. Sie können wie folgt verwendet werden:

|**Zellreferenz**|**Beispiel**|**Absolut**|**Relativ**|**Gemischt**|
| :- | :- | :- | :- | :- |
|Zelle|R2C3|R[2]C[3]|R2C[3]<br>R[2]C3|
|Zeile|R2|R[2]|-|
|Spalte|C3|C[3]|-|
|Bereich|R2C3:R5C7|R[2]C[3]:R[5]C[7]|R2C3:R[5]C[7]<br>R[2]C3:R5C[7]|

Hier ein Beispiel, wie man eine R1C1‑Style‑Zellreferenz in einer Formel verwendet:
```php
  $workbook->getCell(0, "A2")->setR1C1Formula("R2C4 + SUM(R5C6:R7C9)");
```


## **Vordefinierte Funktionen**
Es gibt vordefinierte Funktionen, die in Formeln verwendet werden können, um deren Implementierung zu vereinfachen. Diese Funktionen kapseln häufig genutzte Operationen, wie :

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
- INDEX (Referenz‑Form)
- LOOKUP (Vektor‑Form)
- MATCH (Vektor‑Form)
- MAX
- SUM
- VLOOKUP

## **FAQ**

**Werden externe Excel‑Dateien als Datenquelle für ein Diagramm mit Formeln unterstützt?**

Ja. Aspose.Slides unterstützt externe Arbeitsmappen als [Datenquelle eines Diagramms](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatasourcetype/), sodass Sie Formeln aus einer XLSX‑Datei außerhalb der Präsentation verwenden können.

**Können Diagramm‑Formeln Tabellenblätter im selben Arbeitsbuch per Blattname referenzieren?**

Ja. Formeln folgen dem standardmäßigen Excel‑Referenzmodell, sodass Sie andere Blätter im selben Arbeitsbuch oder in einer externen Arbeitsmappe referenzieren können. Für externe Referenzen geben Sie Pfad und Arbeitsbuchnamen gemäß der Excel‑Syntax an.
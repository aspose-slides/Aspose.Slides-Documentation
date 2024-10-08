---
title: Diagramm Arbeitsblattformeln
type: docs
weight: 70
url: /de/php-java/chart-worksheet-formulas/
keywords: "powerpoint gleichungen, powerpoint spreadsheet formeln"
description: "PowerPoint Gleichungen und Tabellenkalkulationsformeln"
---


## **Über Diagramm Tabellenkalkulationsformeln in Präsentationen**
**Diagramm Tabellenkalkulation** (oder Diagramm Arbeitsblatt) in Präsentationen ist die Datenquelle des Diagramms. Das Diagramm Tabellenkalkulationsblatt enthält Daten, die grafisch im Diagramm dargestellt werden. Wenn Sie in PowerPoint ein Diagramm erstellen, wird das Arbeitsblatt, das mit diesem Diagramm verbunden ist, ebenfalls automatisch erstellt. Das Diagramm Arbeitsblatt wird für alle Arten von Diagrammen erstellt: Liniendiagramm, Balkendiagramm, Sonnenburst-Diagramm, Kreisdiagramm usw. Um das Diagramm Tabellenkalkulationsblatt in PowerPoint zu sehen, sollten Sie doppelt auf das Diagramm klicken:

![todo:image_alt_text](chart-worksheet-formulas_1.png)


Das Diagramm Tabellenkalkulationsblatt enthält die Namen der Diagrammelemente (Kategoriename: *Kategorie1*, Serienname) und eine Tabelle mit numerischen Daten, die zu diesen Kategorien und Serien passen. Standardmäßig werden die Daten des Diagramm Tabellenkalkulationsblatts beim Erstellen eines neuen Diagramms mit den Standarddaten gesetzt. Dann können Sie die Daten im Arbeitsblatt manuell ändern.

In der Regel stellt das Diagramm komplizierte Daten dar (z. B. Finanzanalysten, wissenschaftliche Analysten), mit Zellen, die aus den Werten in anderen Zellen oder aus anderen dynamischen Daten berechnet werden. Den Wert einer Zelle manuell zu berechnen und ihn hart in die Zelle einzufügen, erschwert es, ihn in Zukunft zu ändern. Wenn Sie den Wert einer bestimmten Zelle ändern, müssen auch alle von ihr abhängigen Zellen aktualisiert werden. Darüber hinaus können die Tabellendaten von den Daten anderer Tabellen abhängen, was ein komplexes Präsentationsdatenschema schafft, das auf einfache und flexible Weise aktualisiert werden muss.

**Die Formel für das Diagramm Tabellenkalkulationsblatt** in einer Präsentation ist ein Ausdruck, um die Daten des Diagramm Tabellenkalkulationsblatts automatisch zu berechnen und zu aktualisieren. Die Tabellenkalkulationsformel definiert die Datenberechnungslogik für eine bestimmte Zelle oder eine Gruppe von Zellen. Eine Tabellenkalkulationsformel ist eine mathematische Formel oder eine logische Formel, die verwendet: Zellenreferenzen, mathematische Funktionen, logische Operatoren, arithmetische Operatoren, Umwandlungsfunktionen, Zeichenfolgenkonstanten usw. Die Definition der Formel wird in eine Zelle geschrieben, und diese Zelle enthält keinen einfachen Wert. Die Tabellenkalkulationsformel berechnet den Wert und gibt ihn zurück, dann wird dieser Wert der Zelle zugewiesen. Diagramm Tabellenkalkulationsformeln in Präsentationen sind tatsächlich die gleichen wie Excel-Formeln, und es werden die gleichen Standardfunktionen, Operatoren und Konstanten zu deren Implementierung unterstützt.

Im [**Aspose.Slides**](https://products.aspose.com/slides/php-java/) wird das Diagramm Tabellenkalkulationsblatt dargestellt durch die 
[**Chart.getChartData.getChartDataWorkbook**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartData#getChartDataWorkbook--) Methode des 
[**IChartDataWorkbook**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartDataWorkbook) Typs.
Formeln für Tabellenkalkulationszellen können mit der 
[**IChartDataCell.setFormula**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartDataCell#setFormula-java.lang.String-) Methode zugewiesen und geändert werden.
Die folgende Funktionalität wird für Formeln in Aspose.Slides unterstützt:

- Logische Konstanten
- Numerische Konstanten
- Zeichenfolgenkonstanten
- Fehlerkonstanten
- Arithmetische Operatoren
- Vergleichsoperatoren
- A1-Zellenreferenzen
- R1C1-Zellenreferenzen
- Vorgegebene Funktionen


Typischerweise speichern Tabellenkalkulationen die zuletzt berechneten Werte der Formel. Wenn nach dem Laden der Präsentation die Diagrammdaten nicht geändert wurden - gibt die [**IChartDataCell.getValue**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartDataCell#getValue--) Methode diese Werte beim Lesen zurück. Wenn jedoch die Daten der Tabelle geändert wurden, wird beim Lesen der **ChartDataCell.Value**-Eigenschaft eine 
[**CellUnsupportedDataException**](https://reference.aspose.com/slides/php-java/aspose.slides/CellUnsupportedDataException) für die nicht unterstützten Formeln ausgelöst. Dies geschieht, weil bei erfolgreich geparsten Formeln die Zellabhängigkeiten bestimmt und die Richtigkeit der letzten Werte festgelegt wird. Aber wenn die Formel nicht geparst werden kann, kann die Richtigkeit des Zellwerts nicht garantiert werden.

## **Diagramm Tabellenkalkulationsformel zur Präsentation hinzufügen**
Zuerst fügen Sie ein Diagramm zur ersten Folie einer neuen Präsentation mit 
[IShapeCollection.getShapes.addChart](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addChart-int-float-float-float-float-) hinzu.
Das Arbeitsblatt des Diagramms wird automatisch erstellt und kann mit der 
[**Chart.getChartData.getChartDataWorkbook**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartData#getChartDataWorkbook--) Methode aufgerufen werden:



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

Jetzt schreiben wir einige Werte in Zellen mit der 
[**IChartDataCell.setValue**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartDataCell#setValue-java.lang.Object-) Eigenschaft 
des **Object** Typs, was bedeutet, dass Sie jeden Wert der Eigenschaft zuweisen können:

```php
  $workbook->getCell(0, "F2")->setValue(-2.5);
  $workbook->getCell(0, "G3")->setValue(6.3);
  $workbook->getCell(0, "H4")->setValue(3);

```

Um nun eine Formel in die Zelle zu schreiben, können Sie die 
[**IChartDataCell.setFormula**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartDataCell#setFormula-java.lang.String-) Methode verwenden:

*Hinweis*: Die [**IChartDataCell.setFormula**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartDataCell#setFormula-java.lang.String-) Methode wird verwendet, um A1-Zellenreferenzen festzulegen. 

Um die 
[R1C1Formula](https://reference.aspose.com/slides/php-java/aspose.slides/IChartDataCell#getR1C1Formula--) Zellenreferenz festzulegen, können Sie die 
[**IChartDataCell.setR1C1Formula**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartDataCell#setR1C1Formula-java.lang.String-) Methode verwenden:

Wenn Sie dann versuchen, die Werte aus den Zellen B2 und C2 zu lesen, werden diese berechnet:

```php
  $value1 = $cell1->getValue();// 7.8

  $value2 = $cell2->getValue();// 2.1


```

## **Logische Konstanten**
Sie können in Zellenformeln logische Konstanten wie *FALSE* und *TRUE* verwenden:

```php
  $workbook->getCell(0, "A2")->setValue(false);
  $cell = $workbook->getCell(0, "B2");
  $cell->setFormula("A2 = TRUE");
  $value = $cell->getValue();// der Wert enthält "false"


```

## **Numerische Konstanten**
Zahlen können in gewöhnlichen oder wissenschaftlichen Notationen verwendet werden, um Diagramm Tabellenkalkulationsformeln zu erstellen:

```php
  $workbook->getCell(0, "A2")->setFormula("1 + 0.5");
  $workbook->getCell(0, "B2")->setFormula(".3 * 1E-2");

```

## **Zeichenfolgenkonstanten**
Eine Zeichenfolgenkonstante (oder literale Konstante) ist ein spezifischer Wert, der so verwendet wird, wie er ist, und nicht ändert. Zeichenfolgenkonstanten können Daten, Texte, Zahlen usw. sein:

```php
  $workbook->getCell(0, "A2")->setFormula("\"abc\"");
  $workbook->getCell(0, "B2")->setFormula("\"2/3/2020 12:00\"");

```

## **Fehlerkonstanten**
Manchmal ist es nicht möglich, das Ergebnis durch die Formel zu berechnen. In diesem Fall wird der Fehlerton in der Zelle anstelle seines Wertes angezeigt. Jeder Fehler hat einen spezifischen Code:

- #DIV/0! - Die Formel versucht, durch null zu teilen.
- #GETTING_DATA - kann in einer Zelle angezeigt werden, während sein Wert noch berechnet wird.
- #N/A - Informationen fehlen oder sind nicht verfügbar. Einige Gründe können sein: die in der Formel verwendeten Zellen sind leer, ein zusätzliches Leerzeichen, Schreibfehler usw.
- #NAME? - Eine bestimmte Zelle oder andere Formelobjekte können nicht unter ihrem Namen gefunden werden. 
- #NULL! - kann erscheinen, wenn ein Fehler in der Formel vorliegt, wie:  (,) oder ein Leerzeichen anstelle eines Doppelpunktes (:).
- #NUM! - die Zahl in der Formel kann ungültig, zu lang oder zu klein sein usw.
- #REF! - ungültige Zellenreferenz.
- #VALUE! - unerwarteter Werttyp. Zum Beispiel, ein Strings-Wert wird in einer numerischen Zelle gesetzt.

```php
  $cell = $workbook->getCell(0, "A2");
  $cell->setFormula("2 / 0");
  $value = $cell->getValue();// der Wert enthält den String "#DIV/0!"


```

## **Arithmetische Operatoren**
Sie können alle arithmetischen Operatoren in Diagramm Arbeitsblattformeln verwenden:

|**Operator** |**Bedeutung** |**Beispiel**|
| :- | :- | :- |
|+ (Pluszeichen) |Addition oder unäres Plus|2 + 3|
|- (Minuszeichen) |Subtraktion oder Negation |2 - 3<br>-3|
|* (Sternchen)|Multiplikation |2 * 3|
|/ (Schrägstrich)|Division |2 / 3|
|% (Prozentzeichen) |Prozent |30%|
|^ (Zirkumflex) |Exponentiation |2 ^ 3|

*Hinweis*: Um die Reihenfolge der Auswertung zu ändern, schließen Sie den Teil der Formel, der zuerst berechnet werden soll, in Klammern ein.

## **Vergleichsoperatoren**
Sie können die Werte von Zellen mit den Vergleichsoperatoren vergleichen. Wenn zwei Werte mit diesen Operatoren verglichen werden, ist das Ergebnis ein logischer Wert entweder *TRUE* oder FALSE:

|**Operator** |**Bedeutung** |**Bedeutung** |
| :- | :- | :- |
|= (gleiches Zeichen) |Gleich zu |A2 = 3|
|<> (ungleiches Zeichen) |Ungleich zu|A2 <> 3|
|> (größer als Zeichen) |Größer als|A2 > 3|
|>= (größer oder gleich als Zeichen)|Größer als oder gleich zu|A2 >= 3|
|< (kleiner als Zeichen)|Kleiner als|A2 < 3|
|<= (kleiner oder gleich als Zeichen)|Kleiner oder gleich zu|A2 <= 3|

## **A1-Zellenreferenzen**
**A1-Zellenreferenzen** werden für die Arbeitsblätter verwendet, bei denen die Spalte einen Buchstaben als Identifikator hat (z. B. "*A*") und die Zeile einen numerischen Identifikator hat (z. B. "*1*"). A1-Zellenreferenzen können auf folgende Weise verwendet werden:

|**Zellenreferenz**|**Beispiel**|||
| :- | :- | :- | :- |
||Absolut |Relativ |Mischform|
|Zelle |$A$2 |A2|<p>A$2</p><p>$A2</p>|
|Zeile |$2:$2 |2:2 |-|
|Spalte |$A:$A |A:A |-|
|Bereich |$A$2:$C$4 |A2:C4|<p>$A$2:C4</p><p>A$2:$C4</p>|


Hier ist ein Beispiel, wie man eine A1-Zellenreferenz in einer Formel verwendet:

```php
  $workbook->getCell(0, "A2")->setFormula("C3 + SUM(F2:H5)");

```

## **R1C1-Zellenreferenzen**
**R1C1-Zellenreferenzen** werden für die Arbeitsblätter verwendet, bei denen sowohl eine Zeile als auch eine Spalte einen numerischen Identifikator haben. R1C1-Zellenreferenzen können auf folgende Weise verwendet werden:

|**Zellenreferenz**|**Beispiel**|||
| :- | :- | :- | :- |
||Absolut |Relativ |Mischform|
|Zelle |R2C3|R[2]C[3]|R2C[3]<br>R[2]C3|
|Zeile |R2|R[2]|-|
|Spalte |C3|C[3]|-|
|Bereich |R2C3:R5C7|R[2]C[3]:R[5]C[7] |R2C3:R[5]C[7]<br>R[2]C3:R5C[7]|


Hier ist ein Beispiel, wie man eine A1-Zellenreferenz in einer Formel verwendet:

```php
  $workbook->getCell(0, "A2")->setR1C1Formula("R2C4 + SUM(R5C6:R7C9)");

```

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
- LOOKUP (Vektorkform)
- MATCH (Vektorkform)
- MAX
- SUM
- VLOOKUP
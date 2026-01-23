---
title: Diagramm‑Arbeitsblatt‑Formeln in Präsentationen mit PHP anwenden
linktitle: Arbeitsblatt‑Formeln
type: docs
weight: 70
url: /de/php-java/chart-worksheet-formulas/
keywords:
- Diagramm‑Tabellenblatt
- Diagramm‑Arbeitsblatt
- Diagramm‑Formel
- Arbeitsblatt‑Formel
- Tabellenblatt‑Formel
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
description: "Excel‑ähnliche Formeln in Aspose.Slides für PHP über Java‑Diagramm‑Arbeitsblätter anwenden und Berichte in PPT‑ und PPTX‑Dateien automatisieren."
---

## **Über Diagramm‑Tabellendatenformeln in Präsentationen**
**Diagramm‑Tabellendaten** (oder Diagramm‑Arbeitsblatt) in einer Präsentation ist die Datenquelle des Diagramms. Diagramm‑Tabellendaten enthalten Daten, die im Diagramm grafisch dargestellt werden. Wenn Sie in PowerPoint ein Diagramm erstellen, wird das dem Diagramm zugehörige Arbeitsblatt automatisch ebenfalls erstellt. Diagramm‑Arbeitsblätter werden für alle Diagrammtypen erstellt: Liniendiagramm, Balkendiagramm, Sonnenstrahl‑Diagramm, Kreisdiagramm usw. Um das Diagramm‑Arbeitsblatt in PowerPoint zu sehen, doppelklicken Sie das Diagramm:

![todo:image_alt_text](chart-worksheet-formulas_1.png)


Diagramm‑Tabellendaten enthalten die Namen von Diagrammelementen (Kategoriename: *Category1*, Serienname) und eine Tabelle mit numerischen Daten, die zu diesen Kategorien und Serien passen. Standardmäßig werden beim Erstellen eines neuen Diagramms die Diagramm‑Tabellendaten mit Standarddaten gesetzt. Dann können Sie die Tabellendaten im Arbeitsblatt manuell ändern.

Üblicherweise stellt das Diagramm komplizierte Daten dar (z. B. Finanzanalysten, Wissenschaftsanalyse), bei denen Zellen aus den Werten anderer Zellen oder aus dynamischen Daten berechnet werden. Den Wert einer Zelle manuell zu berechnen und fest in die Zelle zu schreiben, erschwert zukünftige Änderungen. Wenn Sie den Wert einer bestimmten Zelle ändern, müssen alle davon abhängigen Zellen ebenfalls aktualisiert werden. Darüber hinaus können Tabellendaten von Daten anderer Tabellen abhängen, was ein komplexes Präsentationsdatenschema erzeugt, das leicht und flexibel aktualisiert werden muss.

**Diagramm‑Tabellendatenformel** in einer Präsentation ist ein Ausdruck, der die Diagramm‑Tabellendaten automatisch berechnet und aktualisiert. Eine Tabellendatenformel definiert die Datenberechnungslogik für eine bestimmte Zelle oder einen Zellbereich. Eine Tabellendatenformel ist eine mathematische oder logische Formel, die verwendet: Zellreferenzen, mathematische Funktionen, logische Operatoren, arithmetische Operatoren, Umwandlungsfunktionen, Zeichenkettenkonstanten usw. Die Definition der Formel wird in eine Zelle geschrieben; diese Zelle enthält keinen einfachen Wert. Die Tabellendatenformel berechnet den Wert und gibt ihn zurück, dann wird dieser Wert der Zelle zugewiesen. Diagramm‑Tabellendatenformeln in Präsentationen sind im Wesentlichen dieselben wie Excel‑Formeln, und sie unterstützen dieselben Standardfunktionen, Operatoren und Konstanten.

In [**Aspose.Slides**](https://products.aspose.com/slides/php-java/) wird das Diagramm‑Tabellendaten‑Workbook durch die Methode  
[**ChartData::getChartDataWorkbook**](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/#getChartDataWorkbook) des Typs  
[**ChartDataWorkbook**](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/) dargestellt.  
Eine Tabellendatenformel kann zugewiesen und geändert werden mit 
[**ChartDataCell::setFormula**](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/#setFormula).  
Folgende Funktionalität wird für Formeln in Aspose.Slides unterstützt:

- Logische Konstanten
- Numerische Konstanten
- Zeichenketten‑Konstanten
- Fehler‑Konstanten
- Arithmetische Operatoren
- Vergleichsoperatoren
- A1‑Stil Zellreferenzen
- R1C1‑Stil Zellreferenzen
- Vorgefertigte Funktionen


Typischerweise speichern Arbeitsblätter die zuletzt berechneten Formelergebnisse. Wenn nach dem Laden der Präsentation die Diagrammdaten nicht geändert wurden, gibt die Methode [**ChartDataCell::getValue**](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/#getValue) diese Werte beim Lesen zurück. Haben sich Tabellendaten jedoch geändert, wird beim Lesen der Wert die [**CellUnsupportedDataException**](https://reference.aspose.com/slides/php-java/aspose.slides/CellUnsupportedDataException) für nicht unterstützte Formeln ausgelöst. Das liegt daran, dass bei erfolgreichem Parsen einer Formel die Zellabhängigkeiten ermittelt und die Korrektheit der letzten Werte bestimmt werden. Kann die Formel nicht geparst werden, lässt sich die Korrektheit des Zellwertes nicht garantieren.

## **Eine Diagramm‑Tabellendatenformel zu einer Präsentation hinzufügen**
Fügen Sie zunächst einem neuen Präsentationsdokument ein Diagramm zur ersten Folie hinzu mit  
[ShapeCollection::addChart](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addChart).  
Das Arbeitsblatt des Diagramms wird automatisch erstellt und lässt sich über die Methode  
[**ChartData::getChartDataWorkbook**](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/#getChartDataWorkbook) ansprechen:
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


Schreiben wir einige Werte in Zellen mit der Methode [**ChartDataCell::setValue**](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/#setValue) des Typs **Object**, was bedeutet, dass Sie jeden Wert setzen können:
```php
  $workbook->getCell(0, "F2")->setValue(-2.5);
  $workbook->getCell(0, "G3")->setValue(6.3);
  $workbook->getCell(0, "H4")->setValue(3);

```


Um eine Formel in die Zelle zu schreiben, können Sie die  
[**ChartDataCell::setFormula**](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/#setFormula)‑Methode verwenden.

*Hinweis*: [**ChartDataCell::setFormula**](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/#setFormula) wird verwendet, um A1‑Stil Zellreferenzen zu setzen. 

Um eine Formel im R1C1‑Stil zu setzen, können Sie die Methode [**ChartDataCell::setR1C1Formula**](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/#setR1C1Formula) benutzen.

Wenn Sie dann versuchen, die Werte aus den Zellen B2 und C2 zu lesen, werden sie berechnet:
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
  $value = $cell->getValue();// der Wert enthält den booleschen "false"
```


## **Numerische Konstanten**
Zahlen können in üblichen oder wissenschaftlichen Schreibweisen verwendet werden, um Diagramm‑Tabellendatenformeln zu erstellen:
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
Manchmal ist es nicht möglich, das Ergebnis durch die Formel zu berechnen. In diesem Fall wird im Feld anstelle des Wertes ein Fehlercode angezeigt. Jeder Fehlertyp hat einen spezifischen Code:

- #DIV/0! – Formel versucht, durch Null zu teilen.
- #GETTING_DATA – kann in einer Zelle erscheinen, während ihr Wert noch berechnet wird.
- #N/A – Information fehlt oder ist nicht verfügbar. Gründe können sein: leere Zellen in der Formel, ein zusätzliches Leerzeichen, Rechtschreibfehler usw.
- #NAME? – ein bestimmtes Feld oder ein anderes Formelelement kann nicht über seinen Namen gefunden werden. 
- #NULL! – kann auftreten, wenn in der Formel ein Fehler wie (,) oder ein Leerzeichen anstelle eines Doppelpunkts (:) verwendet wird.
- #NUM! – die numerische Angabe in der Formel ist ungültig, zu lang oder zu klein usw.
- #REF! – ungültige Zellreferenz.
- #VALUE! – unerwarteter Werttyp, z. B. Zeichenkette in einer numerischen Zelle.
```php
  $cell = $workbook->getCell(0, "A2");
  $cell->setFormula("2 / 0");
  $value = $cell->getValue();// der Wert enthält die Zeichenkette "#DIV/0!"
```


## **Arithmetische Operatoren**
Sie können alle arithmetischen Operatoren in Diagramm‑Arbeitsblattformeln verwenden:

|**Operator** |**Bedeutung** |**Beispiel**|
| :- | :- | :- |
|+ (Pluszeichen) |Addition oder unäres Plus|2 + 3|
|- (Minuszeichen) |Subtraktion oder Negation |2 - 3<br>-3|
|* (Stern)|Multiplikation |2 * 3|
|/ (Schrägstrich)|Division |2 / 3|
|% (Prozentzeichen) |Prozent |30%|
|^ (Caret) |Exponentiation |2 ^ 3|

*Hinweis*: Um die Auswertungsreihenfolge zu ändern, setzen Sie den zuerst zu berechnenden Teil der Formel in Klammern.

## **Vergleichsoperatoren**
Sie können Zellwerte mit Vergleichsoperatoren vergleichen. Beim Vergleich zweier Werte ergibt sich ein logischer Wert, entweder *TRUE* oder FALSE:

|**Operator** |**Bedeutung** |**Beispiel**|
| :- | :- | :- |
|= (Gleichheitszeichen) |Gleich |A2 = 3|
|<> (Ungleichheitszeichen) |Ungleich|A2 <> 3|
|> (größer‑als Zeichen) |Größer als|A2 > 3|
|>= (größer‑oder‑gleich Zeichen)|Größer oder gleich|A2 >= 3|
|< (kleiner‑als Zeichen)|Kleiner als|A2 < 3|
|<= (kleiner‑oder‑gleich Zeichen)|Kleiner oder gleich|A2 <= 3|

## **A1‑Stil Zellreferenzen**
**A1‑Stil Zellreferenzen** werden verwendet, wenn die Spalten durch Buchstaben (z. B. "*A*") und die Zeilen durch Zahlen (z. B. "*1*") gekennzeichnet sind. A1‑Stil Zellreferenzen können folgendermaßen verwendet werden:

|**Zellreferenz**|**Beispiel**|**Absolut**|**Relativ**|**Gemischt**|
| :- | :- | :- | :- | :- |
|Zelle |$A$2 |A2|A$2|$A2|
|Zeile |$2:$2 |2:2|–|–|
|Spalte |$A:$A |A:A|–|–|
|Bereich |$A$2:$C$4 |A2:C4|$A$2:C4|A$2:$C$4|

Beispiel für die Verwendung einer A1‑Stil Zellreferenz in einer Formel:
```php
  $workbook->getCell(0, "A2")->setFormula("C3 + SUM(F2:H5)");
```


## **R1C1‑Stil Zellreferenzen**
**R1C1‑Stil Zellreferenzen** werden verwendet, wenn sowohl Zeile als auch Spalte numerisch bezeichnet werden. R1C1‑Stil Zellreferenzen können folgendermaßen verwendet werden:

|**Zellreferenz**|**Beispiel**|**Absolut**|**Relativ**|**Gemischt**|
| :- | :- | :- | :- | :- |
|Zelle |R2C3|R[2]C[3]|R2C[3]|R[2]C3|
|Zeile |R2|R[2]|–|–|
|Spalte |C3|C[3]|–|–|
|Bereich |R2C3:R5C7|R[2]C[3]:R[5]C[7]|R2C3:R[5]C[7]|R[2]C3:R5C7|

Beispiel für die Verwendung einer R1C1‑Stil Zellreferenz in einer Formel:
```php
  $workbook->getCell(0, "A2")->setR1C1Formula("R2C4 + SUM(R5C6:R7C9)");
```


## **Vordefinierte Funktionen**
Es gibt vordefinierte Funktionen, die in Formeln verwendet werden können, um deren Implementierung zu vereinfachen. Diese Funktionen kapseln die am häufigsten genutzten Operationen, z. B.:

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
- INDEX (Referenz‑Form)
- LOOKUP (Vektor‑Form)
- MATCH (Vektor‑Form)
- MAX
- SUM
- VLOOKUP

## **FAQ**

**Werden externe Excel‑Dateien als Datenquelle für ein Diagramm mit Formeln unterstützt?**

Ja. Aspose.Slides unterstützt externe Arbeitsmappen als [Diagramm‑Datenquelle](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatasourcetype/), sodass Sie Formeln aus einer XLSX‑Datei außerhalb der Präsentation verwenden können.

**Können Diagramm‑Formeln Blätter innerhalb derselben Arbeitsmappe per Blattname referenzieren?**

Ja. Formeln folgen dem üblichen Excel‑Referenzmodell, sodass Sie andere Blätter derselben Arbeitsmappe oder einer externen Arbeitsmappe referenzieren können. Für externe Referenzen geben Sie Pfad und Arbeitsmappendatei mit der Excel‑Syntax an.
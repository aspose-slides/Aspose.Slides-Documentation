---
title: Diagramm‑Tabellenblatt‑Formeln in Präsentationen in PHP anwenden
linktitle: Tabellenblatt‑Formeln
type: docs
weight: 70
url: /de/php-java/chart-worksheet-formulas/
keywords:
- Diagramm‑Tabellenkalkulation
- Diagramm‑Tabellenblatt
- Diagramm‑Formel
- Tabellenblatt‑Formel
- Tabellenkalkulations‑Formel
- Diagramm‑Daten‑Arbeitsmappe
- Formel‑Berechnung
- Logische Konstante
- Numerische Konstante
- Zeichenketten‑Konstante
- Fehler‑Konstante
- Arithmetischer Operator
- Vergleichsoperator
- A1‑Stil
- R1C1‑Stil
- Vordefinierte Funktion
- PowerPoint
- Präsentation
- PHP
- Aspose.Slides
description: "Wenden Sie Excel‑ähnliche Formeln in Aspose.Slides für PHP via Java auf Diagramm‑Tabellenblätter an, berechnen Sie Werte neu und nutzen Sie die Ergebnisse in PowerPoint‑Diagrammen."
---
## **Übersicht**

PowerPoint‑Diagramme speichern ihre Quelldaten normalerweise in einem eingebetteten Tabellenblatt. In Aspose.Slides für PHP via Java können Sie über die Diagrammdaten‑Arbeitsmappe auf dieses Tabellenblatt zugreifen, Eingabewerte schreiben, Formeln zu Zellen zuweisen, unterstützte Formeln berechnen und die berechneten Zellen als Diagrammdaten verwenden.

Dieser Artikel erklärt den vollständigen Formelar­beitsablauf: Erstellen eines Diagramms, Befüllen des Tabellenblatts, Zuweisen von A1‑ oder R1C1‑Formeln, Neuberechnen, Auslesen der berechneten Werte, Verbinden dieser Zellen mit einer Diagrammserie und Speichern der Präsentation. Außerdem wird die unterstützte Formelsyntax, die eingebaute Funktionsuntermenge, zwischengespeicherte Werte, nicht unterstützte Formeln und tabellenkalkulations­spezifische Fehler beschrieben.

## **Diagramm‑Tabellenblätter und Formeln**

Ein Diagramm‑Tabellenblatt enthält die Kategorien, Seriennamen und Werte, die von einem Diagramm verwendet werden. In PowerPoint können Sie das Tabellenblatt überprüfen, indem Sie den Diagrammdaten‑Editor öffnen:

![PowerPoint-Diagramm mit geöffnetem eingebettetem Tabellenblatt, das Kategorie‑ und Seriendaten anzeigt](chart-worksheet-formulas_1.png)

In Aspose.Slides wird das Tabellenblatt über die Klasse [ChartDataWorkbook](https://reference.aspose.com/slides/de/php-java/aspose.slides/chartdataworkbook/) bereitgestellt. Verwenden Sie [ChartDataCell::setFormula](https://reference.aspose.com/slides/de/php-java/aspose.slides/chartdatacell/#setFormula) für A1‑Stil‑Formeln und [ChartDataCell::setR1C1Formula](https://reference.aspose.com/slides/de/php-java/aspose.slides/chartdatacell/#setR1C1Formula) für R1C1‑Stil‑Formeln. Nachdem Sie Eingabezellen oder Formeln geändert haben, rufen Sie [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/de/php-java/aspose.slides/chartdataworkbook/#calculateFormulas) auf, um unterstützte Formeln neu zu berechnen und die entsprechenden Zellenwerte zu aktualisieren.

Eine berechnete Zelle gibt ihr Ergebnis weiterhin über [ChartDataCell::getValue](https://reference.aspose.com/slides/de/php-java/aspose.slides/chartdatacell/#getValue) zurück. Dies ist wichtig, wenn Sie ein Formel­ergebnis im Code prüfen oder die Zelle als Diagrammdatenpunkt verwenden müssen.

## **Erstellen eines Diagramms und Berechnen von Tabellenblatt‑Formeln**

Das folgende Beispiel demonstriert einen End‑zu‑End‑Arbeitsablauf. Es erstellt ein gruppiertes Säulendiagramm, leert die Beispieldaten, schreibt Quartalsumsätze und -ausgaben, berechnet den Gewinn mit Formeln, liest die Ergebnisse, verwendet die berechneten Zellen als Diagrammw­erte und speichert die Präsentation.

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 350);
    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $worksheetIndex = 0;

    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    $workbook->clear($worksheetIndex);

    $category1 = $workbook->getCell($worksheetIndex, "A2", "Q1");
    $category2 = $workbook->getCell($worksheetIndex, "A3", "Q2");
    $category3 = $workbook->getCell($worksheetIndex, "A4", "Q3");

    $workbook->getCell($worksheetIndex, "B1", "Revenue");
    $workbook->getCell($worksheetIndex, "C1", "Expenses");
    $workbook->getCell($worksheetIndex, "D1", "Profit");

    $workbook->getCell($worksheetIndex, "B2")->setValue(120.0);
    $workbook->getCell($worksheetIndex, "C2")->setValue(80.0);
    $workbook->getCell($worksheetIndex, "B3")->setValue(150.0);
    $workbook->getCell($worksheetIndex, "C3")->setValue(95.0);
    $workbook->getCell($worksheetIndex, "B4")->setValue(135.0);
    $workbook->getCell($worksheetIndex, "C4")->setValue(110.0);

    $profit1 = $workbook->getCell($worksheetIndex, "D2");
    $profit2 = $workbook->getCell($worksheetIndex, "D3");
    $profit3 = $workbook->getCell($worksheetIndex, "D4");

    $profit1->setFormula("B2-C2");
    $profit2->setFormula("B3-C3");
    $profit3->setFormula("B4-C4");

    $workbook->calculateFormulas();

    $q1Profit = java_values($profit1->getValue()); // 40
    $q2Profit = java_values($profit2->getValue()); // 55
    $q3Profit = java_values($profit3->getValue()); // 25

    echo "Q1 profit: " . $q1Profit . PHP_EOL;
    echo "Q2 profit: " . $q2Profit . PHP_EOL;
    echo "Q3 profit: " . $q3Profit . PHP_EOL;

    $chart->getChartData()->getCategories()->add($category1);
    $chart->getChartData()->getCategories()->add($category2);
    $chart->getChartData()->getCategories()->add($category3);

    $profitSeries = $chart->getChartData()->getSeries()->add($workbook->getCell($worksheetIndex, "D1"), $chart->getType());
    $profitSeries->getDataPoints()->addDataPointForBarSeries($profit1);
    $profitSeries->getDataPoints()->addDataPointForBarSeries($profit2);
    $profitSeries->getDataPoints()->addDataPointForBarSeries($profit3);
    $profitSeries->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);

    $presentation->save("chart-formulas.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Die Diagrammdatenpunkte verweisen auf `D2:D4`, sodass das Diagramm die berechneten Gewinnwerte verwendet. Es gibt keinen separaten Diagramm‑Aktualisierungs‑Aufruf in diesem Ablauf: Berechnen Sie zuerst die Arbeitsmappe und verwenden bzw. speichern Sie dann die Diagrammdaten, die auf die berechneten Zellen zeigen.

## **Verwenden von A1‑Stil‑Formeln**

Die A1‑Notation identifiziert Spalten mit Buchstaben und Zeilen mit Zahlen. Weisen Sie A1‑Stil‑Ausdrücke über [ChartDataCell::setFormula](https://reference.aspose.com/slides/de/php-java/aspose.slides/chartdatacell/#setFormula) zu.

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 500, 300);
    $workbook = $chart->getChartData()->getChartDataWorkbook();

    $workbook->getCell(0, "C3")->setValue(10);
    $workbook->getCell(0, "F2")->setValue(2);
    $workbook->getCell(0, "G2")->setValue(3);
    $workbook->getCell(0, "H2")->setValue(4);

    $cell = $workbook->getCell(0, "A2");
    $cell->setFormula("C3+SUM(F2:H2)");

    $workbook->calculateFormulas();

    $value = java_values($cell->getValue()); // 19
} finally {
    $presentation->dispose();
}
```

Übliche A1‑Referenzformen sind:

| Referenz | Relativ | Absolut | Gemischt |
|---|---|---|---|
| Zelle | `A2` | `$A$2` | `A$2`, `$A2` |
| Zeile | `2:2` | `$2:$2` | — |
| Spalte | `A:A` | `$A:$A` | — |
| Bereich | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

Relative Referenzen können sich ändern, wenn eine Formel von einer Tabellenkalkulations‑Anwendung verschoben oder kopiert wird. Absolute Referenzen halten beide Koordinaten fest, während gemischte Referenzen nur eine Zeile oder eine Spalte fixieren.

## **Verwenden von R1C1‑Stil‑Formeln**

Die R1C1‑Notation identifiziert Zeilen und Spalten numerisch. Relative Referenzen verwenden Offsets in eckigen Klammern. Weisen Sie diese Syntax über [ChartDataCell::setR1C1Formula](https://reference.aspose.com/slides/de/php-java/aspose.slides/chartdatacell/#setR1C1Formula) zu.

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 500, 300);
    $workbook = $chart->getChartData()->getChartDataWorkbook();

    $workbook->getCell(0, "B2")->setValue(12);
    $workbook->getCell(0, "C2")->setValue(5);

    $cell = $workbook->getCell(0, "D2");
    $cell->setR1C1Formula("RC[-2]-RC[-1]");

    $workbook->calculateFormulas();

    $value = java_values($cell->getValue()); // 7
} finally {
    $presentation->dispose();
}
```

Übliche R1C1‑Referenzformen sind:

| Referenz | Relativ | Absolut | Gemischt |
|---|---|---|---|
| Zelle | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| Zeile | `R[2]` | `R2` | — |
| Spalte | `C[3]` | `C3` | — |
| Bereich | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

Beispiel: In Zelle `D2` bedeutet `RC[-2]` die Zelle in derselben Zeile zwei Spalten nach links (`B2`).

## **Formelkonstanten und Operatoren**

Der integrierte Formelauswerter unterstützt logische Werte, numerische Literale, Zeichenketten, tabellenkalkulations‑Fehlerwerte, arithmetische Operatoren und Vergleichsoperatoren.

### **Konstanten und Literale**

| Typ | Beispiele | Hinweise |
|---|---|---|
| Logisch | `TRUE`, `FALSE` | Können direkt in logischen Ausdrücken wie `A2=TRUE` verwendet werden. |
| Numerisch | `1`, `0.5`, `.3`, `1E-2` | Dezimal‑ und wissenschaftliche Notation werden unterstützt. |
| Zeichenkette | `"abc"`, `"2/3/2020 12:00"` | Text‑Literals werden innerhalb der Formel in doppelte Anführungszeichen gesetzt. |
| Fehlerwert | `#DIV/0!`, `#N/A`, `#REF!` | Eine gültige Formel kann als Ergebnis einen Tabellenkalkulations‑Fehlerwert statt eines normalen Resultats liefern. |

Dieses Beispiel verwendet mehrere Konstantentypen:

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 500, 300);
    $workbook = $chart->getChartData()->getChartDataWorkbook();

    $workbook->getCell(0, "A2")->setValue(false);
    $workbook->getCell(0, "B2")->setFormula("A2=TRUE");
    $workbook->getCell(0, "C2")->setFormula("1+0.5");
    $workbook->getCell(0, "D2")->setFormula(".3*1E-2");
    $workbook->getCell(0, "E2")->setFormula("\"abc\"");
    $workbook->getCell(0, "F2")->setFormula("2/0");

    $workbook->calculateFormulas();

    $logicalValue = java_values($workbook->getCell(0, "B2")->getValue()); // false
    $numericValue = java_values($workbook->getCell(0, "C2")->getValue()); // 1.5
    $scientificValue = java_values($workbook->getCell(0, "D2")->getValue()); // 0.003
    $stringValue = java_values($workbook->getCell(0, "E2")->getValue()); // abc
    $errorValue = java_values($workbook->getCell(0, "F2")->getValue()); // #DIV/0!
} finally {
    $presentation->dispose();
}
```

### **Arithmetische Operatoren**

| Operator | Bedeutung | Beispiel |
|---|---|---|
| `+` | Addition oder Vorzeichen‑Plus | `2+3` |
| `-` | Subtraktion oder Negation | `2-3`, `-3` |
| `*` | Multiplikation | `2*3` |
| `/` | Division | `2/3` |
| `%` | Prozent | `30%` |
| `^` | Potenzierung | `2^3` |

Verwenden Sie Klammern, um die Auswertungsreihenfolge explizit zu machen, z. B. `(A2+B2)*C2`.

### **Vergleichsoperatoren**

Vergleichsausdrücke liefern logische Werte.

| Operator | Bedeutung | Beispiel |
|---|---|---|
| `=` | Gleich | `A2=3` |
| `<>` | Ungleich | `A2<>3` |
| `>` | Größer als | `A2>3` |
| `>=` | Größer‑oder‑gleich | `A2>=3` |
| `<` | Kleiner als | `A2<3` |
| `<=` | Kleiner‑oder‑gleich | `A2<=3` |

## **Unterstützte vordefinierte Funktionen**

Aspose.Slides enthält einen integrierten Formelauswerter für Diagramm‑Tabellenblätter, ist jedoch keine vollständige Excel‑Rechenengine. Der dokumentierte Funktionsumfang ist auf die unten stehenden Funktionen beschränkt. Gehen Sie nicht davon aus, dass eine beliebige Excel‑Funktion von [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/de/php-java/aspose.slides/chartdataworkbook/#calculateFormulas) neu berechnet werden kann.

| Funktion | Zweck oder unterstützte Form | Beispiel |
|---|---|---|
| `ABS` | Absoluter Wert | `ABS(A2)` |
| `AVERAGE` | Arithmetisches Mittel | `AVERAGE(B2:B5)` |
| `CEILING` | Auf ein Vielfaches aufrunden | `CEILING(A2,5)` |
| `CHOOSE` | Auswahl nach Index | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | Textwerte verbinden | `CONCAT(A2,B2)` |
| `CONCATENATE` | Textwerte verbinden | `CONCATENATE(A2," ",B2)` |
| `DATE` | Datum nach 1900‑System erstellen | `DATE(2026,8,19)` |
| `DAYS` | Anzahl Tage zwischen Daten | `DAYS(B2,A2)` |
| `FIND` | Text in anderem Text finden | `FIND("-",A2)` |
| `FINDB` | Byte‑orientierte Textsuche | `FINDB("a",A2)` |
| `IF` | Bedingtes Ergebnis | `IF(A2>0,A2,0)` |
| `INDEX` | Referenzform | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | Vektorform | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | Vektorform | `MATCH(A2,B2:B5,0)` |
| `MAX` | Maximalwert | `MAX(B2:B5)` |
| `SUM` | Summieren | `SUM(B2:B5)` |
| `VLOOKUP` | Vertikaler Suchen | `VLOOKUP(A2,B2:D10,3,FALSE)` |

Die in der Tabelle gezeigten Einschränkungen sind wesentlich: `INDEX` ist in der Referenzform dokumentiert, während `LOOKUP` und `MATCH` in ihrer Vektorform dokumentiert sind. `DATE` verwendet das 1900‑Datumssystem. Funktionen, die hier nicht aufgeführt sind, sollten als nicht unterstützt vom Aspose.Slides‑Formelauswerter betrachtet werden, sofern sie nicht separat dokumentiert sind.

## **Neuberechnung und zwischengespeicherte Werte**

Tabellenkalkulations‑Dateien speichern häufig sowohl eine Formel als auch deren zuletzt berechneten Wert. Aspose.Slides kann daher beim Laden einer Präsentation einen zwischengespeicherten Wert über [ChartDataCell::getValue](https://reference.aspose.com/slides/de/php-java/aspose.slides/chartdatacell/#getValue) lesen, sofern die zugehörigen Diagrammdaten nicht geändert wurden.

Nachdem Sie Eingabezellen oder Formeln geändert haben, verlassen Sie sich nicht auf ein altes zwischengespeichertes Ergebnis. Rufen Sie [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/de/php-java/aspose.slides/chartdataworkbook/#calculateFormulas) auf, bevor Sie berechnete Werte lesen oder Diagrammdaten speichern, die davon abhängen.

Für Formeln außerhalb des unterstützten Teilbereichs kann Aspose.Slides die Formel möglicherweise nicht parsen oder ihre Abhängigkeiten nicht ermitteln. Wenn die Arbeitsmappe geändert wurde, ist der vorherige zwischengespeicherte Wert nicht mehr zuverlässig. In diesem Fall kann das Auslesen einer Zelle mit nicht unterstützten Daten die Ausnahme [CellUnsupportedDataException](https://reference.aspose.com/slides/de/php-java/aspose.slides/cellunsupporteddataexception/) auslösen.

Wenn Ihr Diagramm Excel‑Funktionen verwendet, die Aspose.Slides nicht auswertet, berechnen Sie diese Formeln mit einer Tabellenkalkulations‑Engine, die sie unterstützt, und schreiben Sie die Ergebniswerte zurück in die Diagramm‑Arbeitsmappe. Ersetzen Sie nicht unterstützte Formeln durch geschätzte Werte.

## **Umgang mit Formel‑Fehlern**

Es gibt zwei unterschiedliche Problemarten.

Eine Formel kann gültig sein, aber ein Tabellenkalkulations‑Fehlergebnis wie `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!` oder `#VALUE!` erzeugen. In diesem Fall ist das Fehler‑Token ein Zellergebnis und kann über [ChartDataCell::getValue](https://reference.aspose.com/slides/de/php-java/aspose.slides/chartdatacell/#getValue) zurückgegeben werden.

Eine Formel kann auch beim Parsen, bei Referenzen, Abhängigkeiten oder wegen nicht unterstützter Daten fehlschlagen. Aspose.Slides stellt dafür tabellenkalkulations‑spezifische Ausnahmen bereit: [CellInvalidFormulaException](https://reference.aspose.com/slides/de/php-java/aspose.slides/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/de/php-java/aspose.slides/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/de/php-java/aspose.slides/cellcircularreferenceexception/) und [CellUnsupportedDataException](https://reference.aspose.com/slides/de/php-java/aspose.slides/cellunsupporteddataexception/).

In PHP via Java werden Java‑Ausnahmen über `JavaException` sichtbar. Wenn Formeln aus Vorlagen oder Benutzereingaben stammen, behandeln Sie sie rund um die Neuberechnung und den Wertzugriff. Die im Stack‑Trace gemeldete Java‑Ausnahme identifiziert den konkreten Tabellenkalkulations‑Fehler:

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 500, 300);
    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $cell = $workbook->getCell(0, "A2");
    $cell->setFormula("SUM(B2:B5)");

    try {
        $workbook->calculateFormulas();
        echo java_values($cell->getValue()) . PHP_EOL;
    } catch (JavaException $ex) {
        $ex->printStackTrace();
    }
} finally {
    $presentation->dispose();
}
```

## **Praktische Einschränkungen**

Die Formelunterstützung in Diagramm‑Tabellenblättern ist für einen definierten Teilbereich von Tabellenkalkulations‑Berechnungen gedacht, nicht für vollständige Excel‑Kompatibilität. Beachten Sie diese Einschränkungen beim Entwerfen eines Reporting‑Workflows:

- Verwenden Sie nur die dokumentierten Konstanten, Operatoren, Referenzen und Funktionen, wenn Aspose.Slides Formeln neu berechnen soll.
- Berechnen Sie nach Änderungen an Zellen, von denen Formel­ergebnisse abhängen, neu.
- Betrachten Sie zwischengespeicherte Werte aus geladenen Präsentationen als Momentaufnahmen, nicht als Ersatz für eine Neuberechnung nach Bearbeitungen.
- Testen Sie Formeln aus bestehenden Vorlagen, bevor Sie sich auf deren berechnete Werte verlassen, insbesondere wenn sie Funktionen außerhalb der dokumentierten Liste verwenden.
- Für Formeln, die eine vollständige Tabellenkalkulations‑Rechenengine benötigen, berechnen Sie sie extern und aktualisieren anschließend das Diagramm‑Tabellenblatt mit den Ergebniswerten.

## **FAQ**

**Was ist der Unterschied zwischen [ChartDataCell::setFormula](https://reference.aspose.com/slides/de/php-java/aspose.slides/chartdatacell/#setFormula) und [ChartDataCell::setR1C1Formula](https://reference.aspose.com/slides/de/php-java/aspose.slides/chartdatacell/#setR1C1Formula)?**

[ChartDataCell::setFormula](https://reference.aspose.com/slides/de/php-java/aspose.slides/chartdatacell/#setFormula) speichert einen A1‑Stil‑Ausdruck wie `B2-C2`. [ChartDataCell::setR1C1Formula](https://reference.aspose.com/slides/de/php-java/aspose.slides/chartdatacell/#setR1C1Formula) speichert einen R1C1‑Stil‑Ausdruck wie `RC[-2]-RC[-1]`. Verwenden Sie die Notation, die am besten zu Ihrem Erstellungs‑ oder Kopier‑Szenario passt.

**Muss ich nach der Berechnung die Zelle selbst oder ihren Wert lesen?**

[ChartDataWorkbook::getCell](https://reference.aspose.com/slides/de/php-java/aspose.slides/chartdataworkbook/#getCell) liefert ein [ChartDataCell](https://reference.aspose.com/slides/de/php-java/aspose.slides/chartdatacell/). Um das berechnete Ergebnis zu erhalten, rufen Sie die Methode [ChartDataCell::getValue](https://reference.aspose.com/slides/de/php-java/aspose.slides/chartdatacell/#getValue) dieser Zelle nach der Neuberechnung auf.

**Wann sollte ich [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/de/php-java/aspose.slides/chartdataworkbook/#calculateFormulas) aufrufen?**

Rufen Sie [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/de/php-java/aspose.slides/chartdataworkbook/#calculateFormulas) nach Änderungen von Eingabewerten oder Formeln und bevor Sie von den berechneten Ergebnissen abhängen, auf. Dieser Aufruf aktualisiert die Werte der Formeln, die der integrierte Auswerter unterstützt.

**Unterstützt Aspose.Slides jede Excel‑Funktion?**

Nein. Der integrierte Auswerter unterstützt nur einen dokumentierten Teilbereich von Funktionen. Funktionen außerhalb dieses Teilbereichs sollten nicht als korrekt neu berechenbar angenommen werden. Wenn vollständige Excel‑Formel‑Kompatibilität erforderlich ist, führen Sie die Berechnung mit einer geeigneten Tabellenkalkulations‑Engine durch und schreiben Sie die endgültigen Werte in das Diagramm‑Tabellenblatt.

**Was passiert, wenn eine geladene Präsentation eine nicht unterstützte Formel enthält?**

Falls die Diagrammdaten nicht geändert wurden, kann die Arbeitsmappe noch einen zuvor berechneten zwischengespeicherten Wert enthalten. Nach einer Änderung der zugehörigen Daten ist dieser zwischengespeicherte Wert möglicherweise nicht mehr gültig. Der Zugriff auf eine Zelle, deren Formel nicht verarbeitet werden kann, kann die Ausnahme [CellUnsupportedDataException](https://reference.aspose.com/slides/de/php-java/aspose.slides/cellunsupporteddataexception/) auslösen.

**Sind Formel‑Fehlerwerte dasselbe wie PHP‑Ausnahmen?**

Nein. Ein Ergebnis wie `#DIV/0!` ist ein Tabellenkalkulations‑Wert, der durch eine gültige Berechnung entstanden ist. Fehler bei der Tabellenkalkulations‑Verarbeitung, etwa [CellInvalidFormulaException](https://reference.aspose.com/slides/de/php-java/aspose.slides/cellinvalidformulaexception/) oder [CellCircularReferenceException](https://reference.aspose.com/slides/de/php-java/aspose.slides/cellcircularreferenceexception/), sind Java‑Ausnahmen, die in PHP über `JavaException` sichtbar werden.

**Wird ein Diagramm automatisch aktualisiert, wenn sich eine Formel‑Zelle ändert?**

Eine Diagrammserie kann auf Arbeitsblatt‑Zellen verweisen. Berechnen Sie zuerst die Arbeitsmappe neu und speichern oder rendern Sie dann die Präsentation. Wenn die Diagrammdatenpunkte auf die berechneten Zellen zeigen, verwendet das Diagramm die aktualisierten Zellwerte; ein separater Diagramm‑Aktualisierungsmethode ist für diesen Ablauf nicht erforderlich.

**Können Diagramme ein externes Excel‑Arbeitsblatt verwenden?**

Ja, Diagrammdaten können über die Diagrammdaten‑API so konfiguriert werden, dass sie ein externes Arbeitsblatt nutzen. Der in diesem Artikel beschriebene Formel‑Berechnungs‑Workflow bezieht sich jedoch auf das Diagramm‑Daten‑Arbeitsblatt und den von Aspose.Slides ausgewerteten Formelteilsbereich. Gehen Sie nicht davon aus, dass [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/de/php-java/aspose.slides/chartdataworkbook/#calculateFormulas) eine vollständige Neuberechnung beliebiger Formeln in einer externen XLSX‑Datei liefert.

**Kann ich Formeln verwenden, die auf ein anderes Tabellenblatt oder Arbeitsbuch verweisen?**

Excel‑artige Referenzen können in Diagramm‑Arbeitsmappen vorkommen, doch die Formel‑Auswertung ist durch den unterstützten Parser und Funktionsumfang begrenzt. Wenn ein bereichsübergreifender oder externer Verweis erforderlich ist, prüfen Sie die jeweilige Formel mit Ihrer Ziel‑Aspose.Slides‑Version. Für Workflows, die eine breite Excel‑Referenz‑Kompatibilität benötigen, berechnen Sie die Arbeitsmappe extern und schreiben die aufgelösten Werte zurück in die Diagrammdaten.

**Müssen Formelfeld‑Zeichenketten mit `=` beginnen?**

Die Aspose.Slides‑API‑Beispiele weisen Ausdrücke wie `B2-C2` oder `SUM(B2:B5)` ohne führendes `=` zu. Die Verwendung dieser Form hält generierte Formeln konsistent zu den dokumentierten API‑Beispielen.
---
title: Diagramm‑Arbeitsblatt‑Formeln in Präsentationen in PHP anwenden
linktitle: Arbeitsblatt‑Formeln
type: docs
weight: 70
url: /de/php-java/chart-worksheet-formulas/
keywords:
- Diagramm‑Tabellenkalkulation
- Diagramm‑Arbeitsblatt
- Diagramm‑Formel
- Arbeitsblatt‑Formel
- Tabellenkalkulation‑Formel
- Diagramm‑Daten‑Arbeitsmappe
- Formel‑Berechnung
- bevorzugte Kultur
- kulturabhängige Formel
- DBCS
- logische Konstante
- numerische Konstante
- Zeichenketten‑Konstante
- Fehlerkonstante
- arithmetischer Operator
- Vergleichsoperator
- A1‑Stil
- R1C1‑Stil
- vordefinierte Funktion
- PowerPoint
- Präsentation
- PHP
- Aspose.Slides
description: "Excel‑ähnliche Formeln in Aspose.Slides für PHP via Java‑Diagramm‑Arbeitsblätter anwenden, Werte neu berechnen und die Ergebnisse in PowerPoint‑Diagrammen nutzen."
---
## **Überblick**

PowerPoint‑Diagramme speichern ihre Quelldaten in der Regel in einem eingebetteten Arbeitsblatt. In Aspose.Slides für PHP via Java können Sie über die Chart‑Daten‑Arbeitsmappe auf dieses Arbeitsblatt zugreifen, Eingabewerte schreiben, Formeln in Zellen zuweisen, unterstützte Formeln berechnen und die berechneten Zellen als Diagrammdaten verwenden.

Dieser Artikel erklärt den vollständigen Formel‑Workflow: ein Diagramm erstellen, das zugehörige Arbeitsblatt füllen, A1‑ oder R1C1‑Formeln zuweisen, sie neu berechnen, die berechneten Werte auslesen, diese Zellen einer Diagrammreihe zuordnen und die Präsentation speichern. Er beschreibt außerdem die unterstützte Formelsyntax, den integrierten Funktions‑Subset, zwischengespeicherte Werte, nicht unterstützte Formeln und tabellenspezifische Fehlermeldungen.

## **Diagramm‑Arbeitsblätter und Formeln**

Ein Diagramm‑Arbeitsblatt enthält die Kategorien, Reihen‑Namen und Werte, die von einem Diagramm verwendet werden. In PowerPoint können Sie das Arbeitsblatt inspizieren, indem Sie den Diagrammdaten‑Editor öffnen:

![PowerPoint diagram with its embedded worksheet open, showing category and series data](chart-worksheet-formulas_1.png)

In Aspose.Slides wird das Arbeitsblatt über die Klasse [ChartDataWorkbook](https://reference.aspose.com/slides/de/php-java/aspose.slides/chartdataworkbook/) bereitgestellt. Verwenden Sie [ChartDataCell::setFormula](https://reference.aspose.com/slides/de/php-java/aspose.slides/chartdatacell/#setFormula) für A1‑Formeln und [ChartDataCell::setR1C1Formula](https://reference.aspose.com/slides/de/php-java/aspose.slides/chartdatacell/#setR1C1Formula) für R1C1‑Formeln. Nach dem Ändern von Eingabezellen oder Formeln rufen Sie [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/de/php-java/aspose.slides/chartdataworkbook/#calculateFormulas) auf, um unterstützte Formeln neu zu berechnen und die entsprechenden Zellwerte zu aktualisieren.

Eine berechnete Zelle gibt ihr Ergebnis weiterhin über [ChartDataCell::getValue](https://reference.aspose.com/slides/de/php-java/aspose.slides/chartdatacell/#getValue) zurück. Dies ist wichtig, wenn Sie das Formel‑Ergebnis im Code inspizieren oder die Zelle als Diagrammdatenpunkt verwenden müssen.

## **Erstellen eines Diagramms und Berechnen von Arbeitsblatt‑Formeln**

Das folgende Beispiel demonstriert einen End‑zu‑End‑Workflow. Es erstellt ein gruppiertes Säulendiagramm, löscht die Beispieldaten, schreibt Quartals‑Umsatz‑ und Kostenwerte, berechnet den Gewinn mit Formeln, liest die Ergebnisse, verwendet die berechneten Zellen als Diagrammwerte und speichert die Präsentation.

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

Die Diagrammdatenpunkte verweisen auf `D2:D4`, sodass das Diagramm die berechneten Gewinnwerte nutzt. Es gibt keinen separaten Diagramm‑Aktualisierungsaufruf in diesem Workflow: Berechnen Sie zuerst die Arbeitsmappe, dann verwenden oder speichern Sie die Diagrammdaten, die auf die berechneten Zellen zeigen.

## **Verwenden von A1‑Formeln**

Die A1‑Notation identifiziert Spalten mit Buchstaben und Zeilen mit Zahlen. Weisen Sie A1‑Ausdrücke über [ChartDataCell::setFormula](https://reference.aspose.com/slides/de/php-java/aspose.slides/chartdatacell/#setFormula) zu.

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

Gängige A1‑Referenzformen sind:

| Referenz | Relativ | Absolut | Gemischt |
|---|---|---|---|
| Zelle | `A2` | `$A$2` | `A$2`, `$A2` |
| Zeile | `2:2` | `$2:$2` | — |
| Spalte | `A:A` | `$A:$A` | — |
| Bereich | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

Relative Referenzen können sich ändern, wenn eine Formel von einer Tabellenkalkulations‑Anwendung verschoben oder kopiert wird. Absolute Referenzen halten beide Koordinaten fest, gemischte Referenzen fixieren nur eine Zeile oder eine Spalte.

## **Verwenden von R1C1‑Formeln**

Die R1C1‑Notation identifiziert sowohl Zeilen als auch Spalten numerisch. Relative Referenzen verwenden Offsets in eckigen Klammern. Weisen Sie diese Syntax über [ChartDataCell::setR1C1Formula](https://reference.aspose.com/slides/de/php-java/aspose.slides/chartdatacell/#setR1C1Formula) zu.

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

Gängige R1C1‑Referenzformen sind:

| Referenz | Relativ | Absolut | Gemischt |
|---|---|---|---|
| Zelle | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| Zeile | `R[2]` | `R2` | — |
| Spalte | `C[3]` | `C3` | — |
| Bereich | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

Beispiel: In Zelle `D2` bedeutet `RC[-2]` die Zelle in derselben Zeile, zwei Spalten nach links (`B2`).

## **Formel‑Konstanten und Operatoren**

Der integrierte Formelauswerter unterstützt logische Werte, numerische Literale, Zeichenketten, Tabellen‑Fehlerwerte, arithmetische Operatoren und Vergleichsoperatoren.

### **Konstanten und Literale**

| Typ | Beispiele | Hinweis |
|---|---|---|
| Logisch | `TRUE`, `FALSE` | Kann direkt in logischen Ausdrücken wie `A2=TRUE` verwendet werden. |
| Numerisch | `1`, `0.5`, `.3`, `1E-2` | Dezimal‑ und wissenschaftliche Schreibweise werden unterstützt. |
| Zeichenkette | `"abc"`, `"2/3/2020 12:00"` | Text‑Literal wird innerhalb der Formel in doppelte Anführungszeichen gesetzt. |
| Fehlerwert | `#DIV/0!`, `#N/A`, `#REF!` | Eine gültige Formel kann anstelle eines normalen Ergebnisses einen Tabellen‑Fehlerwert ergeben. |

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
| `+` | Addition oder Vorzeichen‑plus | `2+3` |
| `-` | Subtraktion oder Negation | `2-3`, `-3` |
| `*` | Multiplikation | `2*3` |
| `/` | Division | `2/3` |
| `%` | Prozent | `30%` |
| `^` | Potenz | `2^3` |

Verwenden Sie Klammern, um die Auswertungsreihenfolge explizit zu machen, z. B. `(A2+B2)*C2`.

### **Vergleichsoperatoren**

Vergleichsausdrücke liefern logische Werte.

| Operator | Bedeutung | Beispiel |
|---|---|---|
| `=` | Gleich | `A2=3` |
| `<>` | Ungleich | `A2<>3` |
| `>` | Größer als | `A2>3` |
| `>=` | Größer‑gleich | `A2>=3` |
| `<` | Kleiner als | `A2<3` |
| `<=` | Kleiner‑gleich | `A2<=3` |

## **Unterstützte vordefinierte Funktionen**

Aspose.Slides enthält einen integrierten Formelauswerter für Diagramm‑Arbeitsblätter, ist jedoch kein vollständiger Excel‑Rechen‑Engine. Der dokumentierte Funktionsumfang ist auf die nachstehenden Funktionen beschränkt. Gehen Sie nicht davon aus, dass eine beliebige Excel‑Funktion von [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/de/php-java/aspose.slides/chartdataworkbook/#calculateFormulas) neu berechnet werden kann.

| Funktion | Zweck oder unterstützte Form | Beispiel |
|---|---|---|
| `ABS` | Absoluter Wert | `ABS(A2)` |
| `AVERAGE` | Arithmetisches Mittel | `AVERAGE(B2:B5)` |
| `CEILING` | Auf ein Vielfaches aufrunden | `CEILING(A2,5)` |
| `CHOOSE` | Wert nach Index auswählen | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | Textwerte zusammenfügen | `CONCAT(A2,B2)` |
| `CONCATENATE` | Textwerte zusammenfügen | `CONCATENATE(A2," ",B2)` |
| `DATE` | Datumwert nach 1900‑System erzeugen | `DATE(2026,8,19)` |
| `DAYS` | Anzahl Tage zwischen Daten | `DAYS(B2,A2)` |
| `FIND` | Text in anderem Text finden | `FIND("-",A2)` |
| `FINDB` | Byte‑orientierte Textsuche | `FINDB("a",A2)` |
| `IF` | Bedingtes Ergebnis | `IF(A2>0,A2,0)` |
| `INDEX` | Referenz‑Form | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | Vektor‑Form | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | Vektor‑Form | `MATCH(A2,B2:B5,0)` |
| `MAX` | Maximalwert | `MAX(B2:B5)` |
| `SUM` | Summe | `SUM(B2:B5)` |
| `VLOOKUP` | Vertikaler Suchen | `VLOOKUP(A2,B2:D10,3,FALSE)` |

Die in der Tabelle gezeigten Einschränkungen sind wesentlich: `INDEX` wird in Referenz‑Form dokumentiert, während `LOOKUP` und `MATCH` in ihren Vektor‑Formen dokumentiert sind. `DATE` verwendet das 1900‑Datumssystem. Funktionen, die hier nicht aufgeführt sind, sollten als nicht unterstützt durch den Aspose.Slides‑Formelauswerter betrachtet werden, sofern sie nicht separat dokumentiert sind.

## **Formeln mit bevorzugter Kultur berechnen**

Einige Arbeitsblatt‑Funktionen interpretieren Text nach kulturspezifischen Regeln. Dies ist besonders wichtig für Funktionen, die für Sprachen mit DBCS (double‑byte‑character‑set) vorgesehen sind. Um solche Formeln korrekt zu berechnen, erstellen Sie ein [LoadOptions](https://reference.aspose.com/slides/de/php-java/aspose.slides/loadoptions/), setzen die bevorzugte Kultur mit [SpreadsheetOptions::setPreferredCulture](https://reference.aspose.com/slides/de/php-java/aspose.slides/spreadsheetoptions/#setPreferredCulture), weisen die Tabellen‑Optionen über [LoadOptions::setSpreadsheetOptions](https://reference.aspose.com/slides/de/php-java/aspose.slides/loadoptions/#setSpreadsheetOptions) zu und laden anschließend die Präsentation.

Das folgende Beispiel wählt die japanische Kultur, öffnet eine Präsentation mit den konfigurierten Ladeoptionen und ruft [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/de/php-java/aspose.slides/chartdataworkbook/#calculateFormulas) für jedes Diagramm‑Arbeitsblatt auf:

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\SpreadsheetOptions;

$japaneseCulture = new Java("java.util.Locale", "ja", "JP");

$spreadsheetOptions = new SpreadsheetOptions();
$spreadsheetOptions->setPreferredCulture($japaneseCulture);

$loadOptions = new LoadOptions();
$loadOptions->setSpreadsheetOptions($spreadsheetOptions);

$chartClass = new JavaClass("com.aspose.slides.IChart");
$presentation = new Presentation("presentation.pptx", $loadOptions);
try {
    $slideCount = java_values($presentation->getSlides()->size());
    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $shapeCount = java_values($slide->getShapes()->size());
        for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
            $shape = $slide->getShapes()->get_Item($shapeIndex);
            if (java_instanceof($shape, $chartClass)) {
                $shape->getChartData()->getChartDataWorkbook()->calculateFormulas();
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

Die bevorzugte Kultur ist Teil der Präsentations‑Ladekonfiguration, daher muss sie vor dem Erstellen der [Presentation](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/)‑Instanz angegeben werden. Verwenden Sie die Kultur, die von den Arbeitsblatt‑Formeln erwartet wird; beispielsweise `ja-JP` für Formeln, die japanische DBCS‑Rechenregeln befolgen sollen.

## **Neuberechnung und zwischengespeicherte Werte**

Tabellen‑Dateien speichern häufig sowohl eine Formel als auch deren zuletzt berechneten Wert. Aspose.Slides kann daher beim Laden einer Präsentation einen zwischengespeicherten Wert über [ChartDataCell::getValue](https://reference.aspose.com/slides/de/php-java/aspose.slides/chartdatacell/#getValue) lesen, sofern die zugehörigen Diagrammdaten nicht geändert wurden.

Nach dem Ändern von Eingabezellen oder Formeln dürfen Sie sich nicht auf ein altes Zwischenspeicher‑Ergebnis verlassen. Rufen Sie vor dem Auslesen berechneter Werte oder dem Speichern von Diagrammdaten, die von ihnen abhängen, [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/de/php-java/aspose.slides/chartdataworkbook/#calculateFormulas) auf.

Für Formeln außerhalb des unterstützten Subsets kann Aspose.Slides die Formel nicht parsen oder deren Abhängigkeiten nicht ermitteln. Wurde die Arbeitsmappe modifiziert, ist der vorherige Zwischenspeicherwert nicht mehr zuverlässig. In dieser Situation kann das Auslesen einer Zelle mit nicht unterstützten Daten die Ausnahme [CellUnsupportedDataException](https://reference.aspose.com/slides/de/php-java/aspose.slides/cellunsupporteddataexception/) auslösen.

Falls Ihr Diagramm Excel‑Funktionen verwendet, die Aspose.Slides nicht auswertet, berechnen Sie diese Formeln mit einer Tabellen‑Engine, die sie unterstützt, und schreiben Sie die resultierenden Werte zurück in das Diagramm‑Arbeitsblatt. Ersetzen Sie nicht unterstützte Formeln durch geschätzte Werte.

## **Umgang mit Formel‑Fehlern**

Es gibt zwei unterschiedliche Arten von Problemen.

Eine Formel kann gültig sein, aber ein Tabellen‑Fehlerergebnis liefern, z. B. `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!` oder `#VALUE!`. In diesem Fall ist das Fehlertoken ein Zellergebnis und kann über [ChartDataCell::getValue](https://reference.aspose.com/slides/de/php-java/aspose.slides/chartdatacell/#getValue) zurückgegeben werden.

Eine Formel kann auch beim Parsen, bei Verweisen, Abhängigkeiten oder wegen nicht unterstützter Daten fehlschlagen. Aspose.Slides bietet dafür tabellenspezifische Ausnahmen: [CellInvalidFormulaException](https://reference.aspose.com/slides/de/php-java/aspose.slides/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/de/php-java/aspose.slides/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/de/php-java/aspose.slides/cellcircularreferenceexception/) und [CellUnsupportedDataException](https://reference.aspose.com/slides/de/php-java/aspose.slides/cellunsupporteddataexception/).

In PHP via Java werden Java‑Ausnahmen über `JavaException` sichtbar. Wenn Formeln aus Vorlagen oder Benutzereingaben stammen, fangen Sie sie beim Neu‑berechnen und beim Zugreifen auf Werte ab. Die in der Stapel­trace gemeldete Java‑Ausnahme identifiziert das konkrete Tabellen‑Problem:

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

Die Formelunterstützung in Diagramm‑Arbeitsblättern ist für einen definierten Subset von Tabellen‑Berechnungen gedacht, nicht für vollständige Excel‑Kompatibilität. Berücksichtigen Sie diese Einschränkungen beim Entwurf von Reporting‑Workflows:

- Verwenden Sie nur die dokumentierten Konstanten, Operatoren, Referenzen und Funktionen, wenn Aspose.Slides die Formeln neu berechnen soll.
- Berechnen Sie nach dem Ändern von Zellen, von denen Formel‑Ergebnisse abhängen, neu.
- Betrachten Sie zwischengespeicherte Werte aus geladenen Präsentationen als Schnappschüsse, nicht als Ersatz für eine Neu‑berechnung nach Änderungen.
- Testen Sie Formeln aus bestehenden Vorlagen, bevor Sie sich auf deren berechnete Werte verlassen, insbesondere wenn sie Funktionen außerhalb der dokumentierten Liste nutzen.
- Für Formeln, die einen vollständigen Tabellen‑Rechen‑Engine benötigen, führen Sie die Berechnung extern durch und aktualisieren anschließend das Diagramm‑Arbeitsblatt mit den resultierenden Werten.

## **FAQ**

**Was ist der Unterschied zwischen [ChartDataCell::setFormula](https://reference.aspose.com/slides/de/php-java/aspose.slides/chartdatacell/#setFormula) und [ChartDataCell::setR1C1Formula](https://reference.aspose.com/slides/de/php-java/aspose.slides/chartdatacell/#setR1C1Formula)?**

[ChartDataCell::setFormula](https://reference.aspose.com/slides/de/php-java/aspose.slides/chartdatacell/#setFormula) speichert einen A1‑Ausdruck wie `B2-C2`. [ChartDataCell::setR1C1Formula](https://reference.aspose.com/slides/de/php-java/aspose.slides/chartdatacell/#setR1C1Formula) speichert einen R1C1‑Ausdruck wie `RC[-2]-RC[-1]`. Verwenden Sie die Notation, die am besten zu Ihrer Formel‑Erzeugung oder -Kopie passt.

**Muss ich nach der Berechnung die Zelle selbst oder ihren Wert lesen?**

[ChartDataWorkbook::getCell](https://reference.aspose.com/slides/de/php-java/aspose.slides/chartdataworkbook/#getCell) gibt ein [ChartDataCell](https://reference.aspose.com/slides/de/php-java/aspose.slides/chartdatacell/) zurück. Um das berechnete Ergebnis zu erhalten, rufen Sie nach der Neu‑berechnung die Methode [ChartDataCell::getValue](https://reference.aspose.com/slides/de/php-java/aspose.slides/chartdatacell/#getValue) dieser Zelle auf.

**Wann soll ich [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/de/php-java/aspose.slides/chartdataworkbook/#calculateFormulas) aufrufen?**

Rufen Sie [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/de/php-java/aspose.slides/chartdataworkbook/#calculateFormulas) nach dem Ändern von Eingabewerten oder Formeln und bevor Sie von den berechneten Ergebnissen abhängen, auf. Dadurch werden die Werte der von dem integrierten Auswerter unterstützten Formeln aktualisiert.

**Unterstützt Aspose.Slides jede Excel‑Funktion?**

Nein. Der integrierte Auswerter unterstützt nur einen dokumentierten Subset von Funktionen. Funktionen außerhalb dieses Subsets sollten nicht als korrekt neu berechnet vorausgesetzt werden. Wenn volle Excel‑Formel‑Kompatibilität erforderlich ist, führen Sie die Berechnung mit einer geeigneten Tabellen‑Engine durch und schreiben Sie die Endwerte in das Diagramm‑Arbeitsblatt.

**Was passiert, wenn eine geladene Präsentation eine nicht unterstützte Formel enthält?**

Wenn die Diagrammdaten nicht geändert wurden, kann die Arbeitsmappe immer noch einen zuvor berechneten Zwischenspeicherwert enthalten. Nach einer Änderung der zugehörigen Daten ist dieser Zwischenspeicherwert möglicherweise nicht mehr gültig. Der Zugriff auf eine Zelle, deren Formel nicht verarbeitet werden kann, kann die Ausnahme [CellUnsupportedDataException](https://reference.aspose.com/slides/de/php-java/aspose.slides/cellunsupporteddataexception/) auslösen.

**Sind Formel‑Fehlerwerte gleichbedeutend mit PHP‑Ausnahmen?**

Nein. Ein Ergebnis wie `#DIV/0!` ist ein Tabellen‑Wert, der durch eine gültige Berechnung erzeugt wurde. Tabellen‑Verarbeitungs‑Fehler wie [CellInvalidFormulaException](https://reference.aspose.com/slides/de/php-java/aspose.slides/cellinvalidformulaexception/) oder [CellCircularReferenceException](https://reference.aspose.com/slides/de/php-java/aspose.slides/cellcircularreferenceexception/) sind Java‑Ausnahmen, die über `JavaException` nach PHP durchgereicht werden.

**Aktualisiert sich ein Diagramm automatisch, wenn sich eine Formezelle ändert?**

Eine Diagramm‑Reihe kann auf Arbeitsblatt‑Zellen verweisen. Berechnen Sie zuerst die Arbeitsmappe, dann speichern oder rendern Sie die Präsentation. Wenn die Diagrammdatenpunkte die berechneten Zellen referenzieren, verwendet das Diagramm die aktualisierten Zellwerte; ein separater Diagramm‑Aktualisierungs‑Aufruf ist für diesen Workflow nicht erforderlich.

**Können Diagramme ein externes Excel‑Arbeitsblatt verwenden?**

Ja, Diagrammdaten können so konfiguriert werden, dass sie ein externes Arbeitsblatt über die Diagrammdaten‑API nutzen. Der in diesem Artikel beschriebene Formel‑Berechnungs‑Workflow bezieht sich jedoch ausschließlich auf das Diagramm‑Arbeitsblatt und den von Aspose.Slides ausgewerteten Formel‑Subset. Gehen Sie nicht davon aus, dass [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/de/php-java/aspose.slides/chartdataworkbook/#calculateFormulas) eine vollständige Neu‑berechnung beliebiger Formeln in einer externen XLSX‑Datei durchführt.

**Kann ich Formeln verwenden, die auf ein anderes Arbeitsblatt oder Arbeitsbuch verweisen?**

Excel‑artige Verweise können in Diagramm‑Arbeitsblättern vorkommen, aber die Formelauswertung ist auf den unterstützten Parser und Funktionsumfang beschränkt. Wenn ein über Blatt‑grenzender oder externer Verweis essentiell ist, prüfen Sie die genaue Formel mit Ihrer Ziel‑Aspose.Slides‑Version. Für Workflows, die umfassende Excel‑Referenz‑Kompatibilität benötigen, berechnen Sie das Arbeitsblatt extern und schreiben die aufgelösten Werte zurück in die Diagrammdaten.

**Sollten Formel‑Zeichenketten mit `=` beginnen?**

Die Aspose.Slides‑API‑Beispiele weisen Ausdrücke wie `B2-C2` oder `SUM(B2:B5)` ohne führendes `=` zu. Diese Form bewahrt die Konsistenz mit den dokumentierten API‑Beispielen.
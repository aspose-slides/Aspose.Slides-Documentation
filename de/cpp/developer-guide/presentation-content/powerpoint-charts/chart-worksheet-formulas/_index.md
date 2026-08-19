---
title: Diagramm‑Arbeitsblatt‑Formeln in Präsentationen mit C++
linktitle: Arbeitsblatt‑Formeln
type: docs
weight: 70
url: /de/cpp/chart-worksheet-formulas/
keywords:
- Diagramm‑Tabellenkalkulation
- Diagramm‑Arbeitsblatt
- Diagramm‑Formel
- Arbeitsblatt‑Formel
- Tabellenkalkulations‑Formel
- Diagramm‑Daten‑Arbeitsbuch
- Formelberechnung
- logische Konstante
- numerische Konstante
- String‑Konstante
- Fehlerkonstante
- arithmetischer Operator
- Vergleichsoperator
- A1‑Stil
- R1C1‑Stil
- vordefinierte Funktion
- PowerPoint
- Präsentation
- C++
- Aspose.Slides
description: "Wenden Sie Excel‑ähnliche Formeln in Aspose.Slides für C++‑Diagramm‑Arbeitsblätter an, berechnen Sie Werte neu und nutzen Sie die Ergebnisse in PowerPoint‑Diagrammen."
---
## **Übersicht**

PowerPoint‑Diagramme speichern ihre Quelldaten normalerweise in einem eingebetteten Arbeitsblatt. Mit Aspose.Slides für C++ können Sie über das Diagramm‑Daten‑Arbeitsbuch auf dieses Arbeitsblatt zugreifen, Eingabewerte schreiben, Formeln Zellen zuweisen, unterstützte Formeln berechnen und die berechneten Zellen als Diagrammdaten verwenden.

Dieser Artikel erklärt den vollständigen Formel‑Arbeitsablauf: Erstellen eines Diagramms, Befüllen des Arbeitsblatts, Zuweisen von A1‑ oder R1C1‑Formeln, erneutes Berechnen, Auslesen der berechneten Werte, Verbinden dieser Zellen mit einer Diagrammreihe und Speichern der Präsentation. Außerdem werden die unterstützte Formelsyntax, die integrierte Funktionsuntermenge, zwischengespeicherte Werte, nicht unterstützte Formeln und tabellenspezifische Fehler beschrieben.

## **Diagramm‑Arbeitsblätter und Formeln**

Ein Diagramm‑Arbeitsblatt enthält die Kategorien, Reihen‑Namen und Werte, die von einem Diagramm verwendet werden. In PowerPoint können Sie das Arbeitsblatt inspizieren, indem Sie den Diagrammdaten‑Editor öffnen:

![PowerPoint chart with its embedded worksheet open, showing category and series data](chart-worksheet-formulas_1.png)

In Aspose.Slides wird das Arbeitsblatt über das Interface [IChartDataWorkbook](https://reference.aspose.com/slides/de/cpp/aspose.slides.charts/ichartdataworkbook/) bereitgestellt. Verwenden Sie [IChartDataCell::set_Formula](https://reference.aspose.com/slides/de/cpp/aspose.slides.charts/ichartdatacell/set_formula/) für A1‑Formeln und [IChartDataCell::set_R1C1Formula](https://reference.aspose.com/slides/de/cpp/aspose.slides.charts/ichartdatacell/set_r1c1formula/) für R1C1‑Formeln. Nachdem Sie Eingabezellen oder Formeln geändert haben, rufen Sie [IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/de/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/) auf, um unterstützte Formeln neu zu berechnen und die entsprechenden Zellenwerte zu aktualisieren.

Eine berechnete Zelle liefert ihr Ergebnis weiterhin über [IChartDataCell::get_Value](https://reference.aspose.com/slides/de/cpp/aspose.slides.charts/ichartdatacell/get_value/). Das ist wichtig, wenn Sie das Ergebnis einer Formel im Code prüfen oder die Zelle als Diagrammdatenpunkt verwenden müssen.

## **Erstellen eines Diagramms und Berechnen von Arbeitsblatt‑Formeln**

Das folgende Beispiel demonstriert einen End‑zu‑End‑Arbeitsablauf. Es erstellt ein gruppiertes Säulendiagramm, löscht die Beispieldaten, schreibt Quartals‑Umsatz‑ und Ausgabenwerte, berechnet den Gewinn mit Formeln, liest die Ergebnisse, verwendet die berechneten Zellen als Diagrammwerte und speichert die Präsentation.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IDataLabelCollection.h>
#include <DOM/Chart/IDataLabelFormat.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 350.0f);
auto chartData = chart->get_ChartData();
auto workbook = chartData->get_ChartDataWorkbook();
const int32_t worksheetIndex = 0;

chartData->get_Series()->Clear();
chartData->get_Categories()->Clear();
workbook->Clear(worksheetIndex);

auto category1 = workbook->GetCell(worksheetIndex, u"A2", ObjectExt::Box<String>(u"Q1"));
auto category2 = workbook->GetCell(worksheetIndex, u"A3", ObjectExt::Box<String>(u"Q2"));
auto category3 = workbook->GetCell(worksheetIndex, u"A4", ObjectExt::Box<String>(u"Q3"));

workbook->GetCell(worksheetIndex, u"B1", ObjectExt::Box<String>(u"Revenue"));
workbook->GetCell(worksheetIndex, u"C1", ObjectExt::Box<String>(u"Expenses"));
workbook->GetCell(worksheetIndex, u"D1", ObjectExt::Box<String>(u"Profit"));

workbook->GetCell(worksheetIndex, u"B2")->set_Value(ObjectExt::Box<double>(120.0));
workbook->GetCell(worksheetIndex, u"C2")->set_Value(ObjectExt::Box<double>(80.0));
workbook->GetCell(worksheetIndex, u"B3")->set_Value(ObjectExt::Box<double>(150.0));
workbook->GetCell(worksheetIndex, u"C3")->set_Value(ObjectExt::Box<double>(95.0));
workbook->GetCell(worksheetIndex, u"B4")->set_Value(ObjectExt::Box<double>(135.0));
workbook->GetCell(worksheetIndex, u"C4")->set_Value(ObjectExt::Box<double>(110.0));

auto profit1 = workbook->GetCell(worksheetIndex, u"D2");
auto profit2 = workbook->GetCell(worksheetIndex, u"D3");
auto profit3 = workbook->GetCell(worksheetIndex, u"D4");

profit1->set_Formula(u"B2-C2");
profit2->set_Formula(u"B3-C3");
profit3->set_Formula(u"B4-C4");

workbook->CalculateFormulas();

auto q1Profit = profit1->get_Value(); // 40
auto q2Profit = profit2->get_Value(); // 55
auto q3Profit = profit3->get_Value(); // 25

chartData->get_Categories()->Add(category1);
chartData->get_Categories()->Add(category2);
chartData->get_Categories()->Add(category3);

auto profitSeries = chartData->get_Series()->Add(workbook->GetCell(worksheetIndex, u"D1"), chart->get_Type());
profitSeries->get_DataPoints()->AddDataPointForBarSeries(profit1);
profitSeries->get_DataPoints()->AddDataPointForBarSeries(profit2);
profitSeries->get_DataPoints()->AddDataPointForBarSeries(profit3);
profitSeries->get_Labels()->get_DefaultDataLabelFormat()->set_ShowValue(true);

presentation->Save(u"chart-formulas.pptx", SaveFormat::Pptx);
```

Die Diagrammdatenpunkte verweisen auf `D2:D4`, sodass das Diagramm die berechneten Gewinnwerte nutzt. Es gibt keinen separaten Diagramm‑Aktualisierungsaufruf in diesem Ablauf: Zuerst das Arbeitsbuch neu berechnen, dann die Diagrammdaten verwenden oder speichern, die auf die berechneten Zellen zeigen.

## **Verwenden von A1‑Formeln**

Die A1‑Notation identifiziert Spalten mit Buchstaben und Zeilen mit Zahlen. Weisen Sie A1‑Ausdrücke über [IChartDataCell::set_Formula](https://reference.aspose.com/slides/de/cpp/aspose.slides.charts/ichartdatacell/set_formula/) zu.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 500.0f, 300.0f);
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();

workbook->GetCell(0, u"C3")->set_Value(ObjectExt::Box<int32_t>(10));
workbook->GetCell(0, u"F2")->set_Value(ObjectExt::Box<int32_t>(2));
workbook->GetCell(0, u"G2")->set_Value(ObjectExt::Box<int32_t>(3));
workbook->GetCell(0, u"H2")->set_Value(ObjectExt::Box<int32_t>(4));

auto cell = workbook->GetCell(0, u"A2");
cell->set_Formula(u"C3+SUM(F2:H2)");

workbook->CalculateFormulas();

auto value = cell->get_Value(); // 19
```

Übliche A1‑Referenzformen sind:

| Referenz | Relativ | Absolut | Gemischt |
|---|---|---|---|
| Zelle | `A2` | `$A$2` | `A$2`, `$A2` |
| Zeile | `2:2` | `$2:$2` | — |
| Spalte | `A:A` | `$A:$A` | — |
| Bereich | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

Relative Verweise können sich ändern, wenn eine Formel von einer Tabellenkalkulations‑Anwendung verschoben oder kopiert wird. Absolute Verweise fixieren beide Koordinaten, gemischte Verweise fixieren nur eine Zeile oder eine Spalte.

## **Verwenden von R1C1‑Formeln**

Die R1C1‑Notation identifiziert sowohl Zeilen als auch Spalten numerisch. Relative Verweise nutzen Offsets in eckigen Klammern. Weisen Sie diese Syntax über [IChartDataCell::set_R1C1Formula](https://reference.aspose.com/slides/de/cpp/aspose.slides.charts/ichartdatacell/set_r1c1formula/) zu.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 500.0f, 300.0f);
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();

workbook->GetCell(0, u"B2")->set_Value(ObjectExt::Box<int32_t>(12));
workbook->GetCell(0, u"C2")->set_Value(ObjectExt::Box<int32_t>(5));

auto cell = workbook->GetCell(0, u"D2");
cell->set_R1C1Formula(u"RC[-2]-RC[-1]");

workbook->CalculateFormulas();

auto value = cell->get_Value(); // 7
```

Übliche R1C1‑Referenzformen sind:

| Referenz | Relativ | Absolut | Gemischt |
|---|---|---|---|
| Zelle | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| Zeile | `R[2]` | `R2` | — |
| Spalte | `C[3]` | `C3` | — |
| Bereich | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

Beispiel: In Zelle `D2` bedeutet `RC[-2]` die Zelle in derselben Zeile, zwei Spalten nach links (`B2`).

## **Formelkonstanten und Operatoren**

Der integrierte Formelevaluator unterstützt logische Werte, numerische Literale, Zeichenketten, Tabellen‑Fehlerwerte, arithmetische Operatoren und Vergleichsoperatoren.

### **Konstanten und Literale**

| Typ | Beispiele | Hinweise |
|---|---|---|
| Logisch | `TRUE`, `FALSE` | Können direkt in logischen Ausdrücken wie `A2=TRUE` verwendet werden. |
| Numerisch | `1`, `0.5`, `.3`, `1E-2` | Dezimal‑ und wissenschaftliche Schreibweise werden unterstützt. |
| Zeichenkette | `"abc"`, `"2/3/2020 12:00"` | Text‑Literale werden innerhalb der Formel in doppelte Anführungszeichen gesetzt. |
| Fehlergebnis | `#DIV/0!`, `#N/A`, `#REF!` | Eine gültige Formel kann anstelle eines normalen Ergebnisses einen Tabellen‑Fehlerwert zurückgeben. |

Dieses Beispiel verwendet mehrere Konstantentypen:

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 500.0f, 300.0f);
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();

workbook->GetCell(0, u"A2")->set_Value(ObjectExt::Box<bool>(false));
workbook->GetCell(0, u"B2")->set_Formula(u"A2=TRUE");
workbook->GetCell(0, u"C2")->set_Formula(u"1+0.5");
workbook->GetCell(0, u"D2")->set_Formula(u".3*1E-2");
workbook->GetCell(0, u"E2")->set_Formula(u"\"abc\"");
workbook->GetCell(0, u"F2")->set_Formula(u"2/0");

workbook->CalculateFormulas();

auto logicalValue = workbook->GetCell(0, u"B2")->get_Value(); // Falsch
auto numericValue = workbook->GetCell(0, u"C2")->get_Value(); // 1.5
auto scientificValue = workbook->GetCell(0, u"D2")->get_Value(); // 0.003
auto stringValue = workbook->GetCell(0, u"E2")->get_Value(); // abc
auto errorValue = workbook->GetCell(0, u"F2")->get_Value(); // #DIV/0!
```

### **Arithmetische Operatoren**

| Operator | Bedeutung | Beispiel |
|---|---|---|
| `+` | Addition oder einäres Plus | `2+3` |
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

Aspose.Slides enthält einen integrierten Formelevaluator für Diagramm‑Arbeitsblätter, ist jedoch keine vollständige Excel‑Berechnungs‑Engine. Der dokumentierte Funktionsumfang ist auf die untenstehenden Funktionen beschränkt. Gehen Sie nicht davon aus, dass eine beliebige Excel‑Funktion von [IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/de/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/) neu berechnet werden kann.

| Funktion | Zweck oder unterstützte Form | Beispiel |
|---|---|---|
| `ABS` | Absolutwert | `ABS(A2)` |
| `AVERAGE` | Arithmetisches Mittel | `AVERAGE(B2:B5)` |
| `CEILING` | Auf ein Vielfaches aufrunden | `CEILING(A2,5)` |
| `CHOOSE` | Wert nach Index auswählen | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | Textwerte verketten | `CONCAT(A2,B2)` |
| `CONCATENATE` | Textwerte verketten | `CONCATENATE(A2," ",B2)` |
| `DATE` | Datum nach 1900‑System erzeugen | `DATE(2026,8,19)` |
| `DAYS` | Anzahl der Tage zwischen Daten | `DAYS(B2,A2)` |
| `FIND` | Text in anderem Text suchen | `FIND("-",A2)` |
| `FINDB` | Byte‑orientierte Textsuche | `FINDB("a",A2)` |
| `IF` | Bedingtes Ergebnis | `IF(A2>0,A2,0)` |
| `INDEX` | Referenzform | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | Vektorform | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | Vektorform | `MATCH(A2,B2:B5,0)` |
| `MAX` | Maximalwert | `MAX(B2:B5)` |
| `SUM` | Summe | `SUM(B2:B5)` |
| `VLOOKUP` | Vertikaler SVERWEIS | `VLOOKUP(A2,B2:D10,3,FALSE)` |

Die in der Tabelle gezeigten Einschränkungen sind wesentlich: `INDEX` ist in der Referenzform dokumentiert, während `LOOKUP` und `MATCH` in ihren Vektorformen angegeben sind. `DATE` verwendet das 1900‑Datumssystem. Funktionen, die hier nicht aufgeführt sind, sollten als nicht unterstützt durch den Aspose.Slides‑Formelevaluator betrachtet werden, sofern sie nicht separat dokumentiert sind.

## **Neuberechnung und zwischengespeicherte Werte**

Tabellendateien speichern häufig sowohl eine Formel als auch deren zuletzt berechneten Wert. Aspose.Slides kann daher beim Laden einer Präsentation einen zwischengespeicherten Wert aus [IChartDataCell::get_Value](https://reference.aspose.com/slides/de/cpp/aspose.slides.charts/ichartdatacell/get_value/) lesen, sofern die zugehörigen Diagrammdaten nicht geändert wurden.

Nachdem Sie Eingabezellen oder Formeln geändert haben, dürfen Sie sich nicht auf ein altes zwischengespeichertes Ergebnis verlassen. Rufen Sie vor dem Auslesen berechneter Werte oder dem Speichern von Diagrammdaten, die davon abhängen, [IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/de/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/) auf.

Für Formeln außerhalb des unterstützten Teilsets kann Aspose.Slides die Formel möglicherweise nicht parsen oder deren Abhängigkeiten ermitteln. Wenn das Arbeitsbuch verändert wurde, ist der vorherige zwischengespeicherte Wert nicht mehr zuverlässig. In diesem Fall kann das Auslesen einer Zelle mit nicht unterstützten Daten die Ausnahme [CellUnsupportedDataException](https://reference.aspose.com/slides/de/cpp/aspose.slides.spreadsheet/cellunsupporteddataexception/) auslösen.

Wenn Ihr Diagramm von Excel‑Funktionen abhängt, die Aspose.Slides nicht auswertet, berechnen Sie diese Formeln mit einer Tabellen‑Engine, die sie unterstützt, und schreiben Sie die Ergebniswerte zurück in das Diagramm‑Arbeitsbuch. Ersetzen Sie nicht unterstützte Formeln durch geschätzte Werte.

## **Umgang mit Formel‑Fehlern**

Es gibt zwei verschiedene Arten von Problemen.

Eine Formel kann gültig sein, aber ein Tabellen‑Fehlergebnis wie `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!` oder `#VALUE!` erzeugen. In diesem Fall ist das Fehlertoken ein Zellen‑Ergebnis und kann über [IChartDataCell::get_Value](https://reference.aspose.com/slides/de/cpp/aspose.slides.charts/ichartdatacell/get_value/) zurückgegeben werden.

Eine Formel kann zudem beim Parsen, bei Referenzen, Abhängigkeiten oder aufgrund nicht unterstützter Daten fehlschlagen. Aspose.Slides liefert dafür tabellenspezifische Ausnahmen: [CellInvalidFormulaException](https://reference.aspose.com/slides/de/cpp/aspose.slides.spreadsheet/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/de/cpp/aspose.slides.spreadsheet/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/de/cpp/aspose.slides.spreadsheet/cellcircularreferenceexception/) und [CellUnsupportedDataException](https://reference.aspose.com/slides/de/cpp/aspose.slides.spreadsheet/cellunsupporteddataexception/).

Wenn Formeln aus Vorlagen oder Benutzereingaben stammen, fangen Sie diese Ausnahmen beim Neuberechnen und beim Zugreifen auf Werte ab:

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Spreadsheet/CellCircularReferenceException.h>
#include <Spreadsheet/CellInvalidFormulaException.h>
#include <Spreadsheet/CellInvalidReferenceException.h>
#include <Spreadsheet/CellUnsupportedDataException.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Spreadsheet;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 500.0f, 300.0f);
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
auto cell = workbook->GetCell(0, u"A2");
cell->set_Formula(u"SUM(B2:B5)");

try
{
    workbook->CalculateFormulas();
    auto value = cell->get_Value();
}
catch (CellInvalidFormulaException&)
{
    // Behandle eine ungültige Formel.
}
catch (CellInvalidReferenceException&)
{
    // Behandle eine ungültige Zellreferenz.
}
catch (CellCircularReferenceException&)
{
    // Behandle eine zirkuläre Referenz.
}
catch (CellUnsupportedDataException&)
{
    // Behandle nicht unterstützte Tabellendaten.
}
```

## **Praktische Einschränkungen**

Die Formelunterstützung in Diagramm‑Arbeitsblättern ist für einen definierten Teilbereich von Tabellerechnungen gedacht, nicht für volle Excel‑Kompatibilität. Berücksichtigen Sie diese Einschränkungen beim Entwerfen eines Reporting‑Workflows:

- Verwenden Sie nur die dokumentierten Konstanten, Operatoren, Referenzen und Funktionen, wenn Aspose.Slides Formeln neu berechnen soll.
- Nach Änderungen von Zellen, von denen Formelergebnisse abhängen, neu berechnen.
- Betrachten Sie zwischengespeicherte Werte aus geladenen Präsentationen als Momentaufnahmen, nicht als Ersatz für eine Neuberechnung nach Änderungen.
- Testen Sie Formeln aus bestehenden Vorlagen, bevor Sie sich auf deren berechnete Werte verlassen, insbesondere wenn sie Funktionen außerhalb der dokumentierten Liste nutzen.
- Für Formeln, die eine vollständige Tabellen‑Berechnungs‑Engine erfordern, berechnen Sie sie extern und aktualisieren anschließend das Diagramm‑Arbeitsbuch mit den Ergebniswerten.

## **FAQ**

**Was ist der Unterschied zwischen `set_Formula` und `set_R1C1Formula`?**

[IChartDataCell::set_Formula](https://reference.aspose.com/slides/de/cpp/aspose.slides.charts/ichartdatacell/set_formula/) speichert einen A1‑Ausdruck wie `B2-C2`. [IChartDataCell::set_R1C1Formula](https://reference.aspose.com/slides/de/cpp/aspose.slides.charts/ichartdatacell/set_r1c1formula/) speichert einen R1C1‑Ausdruck wie `RC[-2]-RC[-1]`. Verwenden Sie die Notation, die am besten zu Ihrer Formel‑Erzeugung oder -Kopie passt.

**Muss ich nach der Berechnung die Zelle selbst oder ihren Wert lesen?**

[IChartDataWorkbook::GetCell](https://reference.aspose.com/slides/de/cpp/aspose.slides.charts/ichartdataworkbook/getcell/) gibt ein `IChartDataCell` zurück. Um das berechnete Ergebnis zu erhalten, lesen Sie anschließend den Wert dieser Zelle über [IChartDataCell::get_Value](https://reference.aspose.com/slides/de/cpp/aspose.slides.charts/ichartdatacell/get_value/).

**Wann sollte ich `CalculateFormulas` aufrufen?**

Rufen Sie [IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/de/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/) nach Änderungen von Eingabewerten oder Formeln und bevor Sie von den berechneten Ergebnissen abhängen, auf. Dies aktualisiert die Werte der Formeln, die vom integrierten Evaluator unterstützt werden.

**Unterstützt Aspose.Slides jede Excel‑Funktion?**

Nein. Der integrierte Evaluator unterstützt nur eine dokumentierte Teilmenge von Funktionen. Funktionen außerhalb dieser Teilmenge sollten nicht als korrekt neu berechnet angenommen werden. Wenn volle Excel‑Formel‑Kompatibilität erforderlich ist, führen Sie die Berechnung mit einer passenden Tabellen‑Engine durch und schreiben Sie die Endwerte in das Diagramm‑Arbeitsbuch.

**Was passiert, wenn eine geladene Präsentation eine nicht unterstützte Formel enthält?**

Wenn die Diagrammdaten nicht geändert wurden, kann das Arbeitsbuch noch einen zuvor berechneten zwischengespeicherten Wert enthalten. Nach einer Änderung der zugehörigen Daten ist dieser Wert möglicherweise nicht mehr gültig. Der Zugriff auf eine Zelle, deren Formel nicht verarbeitet werden kann, kann die Ausnahme [CellUnsupportedDataException](https://reference.aspose.com/slides/de/cpp/aspose.slides.spreadsheet/cellunsupporteddataexception/) auslösen.

**Sind Formel‑Fehlerwerte identisch mit C++‑Ausnahmen?**

Nein. Ein Ergebnis wie `#DIV/0!` ist ein Tabellenwert, der durch eine gültige Berechnung entsteht. Ausnahmen wie [CellInvalidFormulaException](https://reference.aspose.com/slides/de/cpp/aspose.slides.spreadsheet/cellinvalidformulaexception/) oder [CellCircularReferenceException](https://reference.aspose.com/slides/de/cpp/aspose.slides.spreadsheet/cellcircularreferenceexception/) zeigen an, dass die Formel nicht regulär verarbeitet werden kann.

**Wird ein Diagramm automatisch aktualisiert, wenn sich eine Formezelle ändert?**

Eine Diagrammreihe kann Arbeitsbuch‑Zellen referenzieren. Berechnen Sie zuerst das Arbeitsbuch neu und speichern oder rendern Sie anschließend die Präsentation. Wenn die Diagrammdatenpunkte die berechneten Zellen referenzieren, verwendet das Diagramm die aktualisierten Zellwerte; ein separater Diagramm‑Aktualisierungs‑Aufruf ist für diesen Ablauf nicht nötig.

**Können Diagramme ein externes Excel‑Arbeitsbuch verwenden?**

Ja, Diagrammdaten können so konfiguriert werden, dass sie ein externes Arbeitsbuch über die Diagrammdaten‑API nutzen. Der in diesem Artikel beschriebene Formel‑Berechnungs‑Workflow bezieht sich jedoch auf das Diagramm‑Arbeitsbuch und den von Aspose.Slides evaluierten Formel‑Teilbereich. Gehen Sie nicht davon aus, dass [IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/de/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/) eine vollständige Neuberechnung beliebiger Formeln in einer externen XLSX‑Datei durchführt.

**Kann ich Formeln verwenden, die ein anderes Arbeitsblatt oder Arbeitsbuch referenzieren?**

Excel‑artige Referenzen können in Diagramm‑Arbeitsbüchern vorkommen, doch die Formelauswertung ist durch den unterstützten Parser und Funktionsumfang begrenzt. Wenn eine Querverweis‑ oder externe Referenz zwingend erforderlich ist, prüfen Sie die exakte Formel mit Ihrer Ziel‑Aspose.Slides‑Version. Für Workflows, die breite Excel‑Referenz‑Kompatibilität benötigen, berechnen Sie das Arbeitsbuch extern und schreiben die aufgelösten Werte zurück in die Diagrammdaten.

**Müssen Formel‑Strings mit `=` beginnen?**

Die Aspose.Slides‑API‑Beispiele weisen Ausdrücke wie `B2-C2` oder `SUM(B2:B5)` ohne führendes `=` zu. Die Verwendung dieser Form hält generierte Formeln konsistent zu den dokumentierten API‑Beispielen.
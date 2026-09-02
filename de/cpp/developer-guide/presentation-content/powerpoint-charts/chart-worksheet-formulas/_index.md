---
title: Anwenden von Diagramm-Arbeitsblatt-Formeln in Präsentationen mit C++
linktitle: Arbeitsblatt-Formeln
type: docs
weight: 70
url: /de/cpp/chart-worksheet-formulas/
keywords:
- Diagramm-Tabellenkalkulation
- Diagramm-Arbeitsblatt
- Diagramm-Formel
- Arbeitsblatt-Formel
- Tabellenkalkulations-Formel
- Diagramm-Daten-Arbeitsmappe
- Formel-Berechnung
- bevorzugte Kultur
- kulturspezifische Formel
- DBCS
- logische Konstante
- numerische Konstante
- String-Konstante
- Fehlerkonstante
- arithmetischer Operator
- Vergleichsoperator
- A1-Stil
- R1C1-Stil
- vordefinierte Funktion
- PowerPoint
- Präsentation
- C++
- Aspose.Slides
description: "Wenden Sie Excel-artige Formeln in Aspose.Slides für C++-Diagramm-Arbeitsblätter an, berechnen Sie Werte neu und verwenden Sie die Ergebnisse in PowerPoint-Diagrammen."
---
## **Übersicht**

PowerPoint‑Diagramme speichern ihre Quelldaten normalerweise in einem eingebetteten Arbeitsblatt. In Aspose.Slides für C++ können Sie auf dieses Arbeitsblatt über die Diagrammdaten‑Arbeitsmappe zugreifen, Eingabewerte schreiben, Formeln Zellen zuweisen, unterstützte Formeln berechnen und die berechneten Zellen als Diagrammdaten verwenden.

Dieser Artikel erklärt den kompletten Formel‑Workflow: ein Diagramm erstellen, das Arbeitsblatt füllen, A1‑ oder R1C1‑Formeln zuweisen, sie neu berechnen, die berechneten Werte lesen, diese Zellen mit einer Diagrammreihe verbinden und die Präsentation speichern. Außerdem werden die unterstützte Formelsyntax, das eingebaute Funktions‑Subset, zwischengespeicherte Werte, nicht unterstützte Formeln und tabellenspezifische Fehler beschrieben.

## **Diagramm‑Arbeitsblätter und Formeln**

Ein Diagramm‑Arbeitsblatt enthält die Kategorien, Seriennamen und Werte, die von einem Diagramm verwendet werden. In PowerPoint können Sie das Arbeitsblatt inspizieren, indem Sie den Diagrammdaten‑Editor öffnen:

![PowerPoint‑Diagramm mit offenem eingebettetem Arbeitsblatt, das Kategorie‑ und Seriendaten zeigt](chart-worksheet-formulas_1.png)

In Aspose.Slides wird das Arbeitsblatt über die Schnittstelle [IChartDataWorkbook](https://reference.aspose.com/slides/de/cpp/aspose.slides.charts/ichartdataworkbook/) bereitgestellt. Verwenden Sie [IChartDataCell::set_Formula](https://reference.aspose.com/slides/de/cpp/aspose.slides.charts/ichartdatacell/set_formula/) für A1‑Formeln und [IChartDataCell::set_R1C1Formula](https://reference.aspose.com/slides/de/cpp/aspose.slides.charts/ichartdatacell/set_r1c1formula/) für R1C1‑Formeln. Nachdem Eingabezellen oder Formeln geändert wurden, rufen Sie [IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/de/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/) auf, um unterstützte Formeln neu zu berechnen und die entsprechenden Zellenwerte zu aktualisieren.

Eine berechnete Zelle stellt ihr Ergebnis weiterhin über [IChartDataCell::get_Value](https://reference.aspose.com/slides/de/cpp/aspose.slides.charts/ichartdatacell/get_value/) bereit. Das ist wichtig, wenn Sie ein Formelergebnis im Code inspizieren oder die Zelle als Diagrammdatenpunkt verwenden müssen.

## **Diagramm erstellen und Arbeitsblatt‑Formeln berechnen**

Das folgende Beispiel demonstriert einen End‑zu‑End‑Workflow. Es erstellt ein gruppiertes Säulendiagramm, löscht die Beispieldaten, schreibt Quartals‑Umsatz‑ und Aufwandwerte, berechnet den Gewinn mit Formeln, liest die Ergebnisse, verwendet die berechneten Zellen als Diagrammwerte und speichert die Präsentation.

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

Die Diagrammdatenpunkte verweisen auf `D2:D4`, sodass das Diagramm die berechneten Gewinnwerte verwendet. Es gibt keinen separaten Diagramm‑Aktualisierungsaufruf in diesem Workflow: Berechnen Sie zuerst die Arbeitsmappe neu und verwenden bzw. speichern Sie anschließend die Diagrammdaten, die auf die berechneten Zellen verweisen.

## **A1‑Formeln verwenden**

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

Häufige A1‑Referenzformen sind:

| Referenz | Relativ | Absolut | Gemischt |
|---|---|---|---|
| Zelle | `A2` | `$A$2` | `A$2`, `$A2` |
| Zeile | `2:2` | `$2:$2` | — |
| Spalte | `A:A` | `$A:$A` | — |
| Bereich | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

Relative Referenzen können sich ändern, wenn eine Formel von einer Tabellenkalkulations‑Anwendung verschoben oder kopiert wird. Absolute Referenzen halten beide Koordinaten fest, während gemischte Referenzen nur eine Zeile oder eine Spalte fixieren.

## **R1C1‑Formeln verwenden**

Die R1C1‑Notation identifiziert sowohl Zeilen als auch Spalten numerisch. Relative Referenzen verwenden Offsets in eckigen Klammern. Weisen Sie diese Syntax über [IChartDataCell::set_R1C1Formula](https://reference.aspose.com/slides/de/cpp/aspose.slides.charts/ichartdatacell/set_r1c1formula/) zu.

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

Häufige R1C1‑Referenzformen sind:

| Referenz | Relativ | Absolut | Gemischt |
|---|---|---|---|
| Zelle | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| Zeile | `R[2]` | `R2` | — |
| Spalte | `C[3]` | `C3` | — |
| Bereich | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

Beispiel: In Zelle `D2` bedeutet `RC[-2]` die Zelle in derselben Zeile, zwei Spalten nach links (`B2`).

## **Formelkonstanten und Operatoren**

Der integrierte Formelauswerter unterstützt logische Werte, numerische Literale, Zeichenfolgen, Fehlerwerte von Tabellenkalkulationen, arithmetische Operatoren und Vergleichsoperatoren.

### **Konstanten und Literale**

| Typ | Beispiele | Hinweise |
|---|---|---|
| Logisch | `TRUE`, `FALSE` | Können direkt in logischen Ausdrücken wie `A2=TRUE` verwendet werden. |
| Numerisch | `1`, `0.5`, `.3`, `1E-2` | Dezimal‑ und wissenschaftliche Notation werden unterstützt. |
| Zeichenfolge | `"abc"`, `"2/3/2020 12:00"` | Text‑Literal muss innerhalb der Formel in doppelte Anführungszeichen eingeschlossen werden. |
| Fehlerwert | `#DIV/0!`, `#N/A`, `#REF!` | Eine gültige Formel kann anstelle eines normalen Ergebnisses einen Tabellen‑Fehlerwert ergeben. |

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
| `+` | Addition oder Vorzeichenplus | `2+3` |
| `-` | Subtraktion oder Negation | `2-3`, `-3` |
| `*` | Multiplikation | `2*3` |
| `/` | Division | `2/3` |
| `%` | Prozent | `30%` |
| `^` | Potenzierung | `2^3` |

Klammern können verwendet werden, um die Auswertungsreihenfolge explizit zu machen, z. B. `(A2+B2)*C2`.

### **Vergleichsoperatoren**

Vergleichsausdrücke liefern logische Werte.

| Operator | Bedeutung | Beispiel |
|---|---|---|
| `=` | Gleich | `A2=3` |
| `<>` | Ungleich | `A2<>3` |
| `>` | Größer als | `A2>3` |
| `>=` | Größer‑ oder gleich | `A2>=3` |
| `<` | Kleiner als | `A2<3` |
| `<=` | Kleiner‑ oder gleich | `A2<=3` |

## **Unterstützte vordefinierte Funktionen**

Aspose.Slides enthält einen integrierten Formelauswerter für Diagramm‑Arbeitsblätter, ist jedoch keine vollständige Excel‑Berechnungsengine. Der dokumentierte Funktionsumfang ist auf die nachstehenden Funktionen beschränkt. Es darf nicht angenommen werden, dass eine beliebige Excel‑Funktion von [IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/de/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/) neu berechnet werden kann.

| Funktion | Zweck oder unterstützte Form | Beispiel |
|---|---|---|
| `ABS` | Absolutwert | `ABS(A2)` |
| `AVERAGE` | Arithmetisches Mittel | `AVERAGE(B2:B5)` |
| `CEILING` | Auf ein Vielfaches aufrunden | `CEILING(A2,5)` |
| `CHOOSE` | Wert nach Index auswählen | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | Textwerte verketten | `CONCAT(A2,B2)` |
| `CONCATENATE` | Textwerte verketten | `CONCATENATE(A2," ",B2)` |
| `DATE` | Datum mit 1900‑Datumsystem erzeugen | `DATE(2026,8,19)` |
| `DAYS` | Anzahl der Tage zwischen Daten | `DAYS(B2,A2)` |
| `FIND` | Text in einem anderen finden | `FIND("-",A2)` |
| `FINDB` | Byte‑orientierte Textsuche | `FINDB("a",A2)` |
| `IF` | Bedingtes Ergebnis | `IF(A2>0,A2,0)` |
| `INDEX` | Referenzform | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | Vektorform | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | Vektorform | `MATCH(A2,B2:B5,0)` |
| `MAX` | Maximalwert | `MAX(B2:B5)` |
| `SUM` | Summe | `SUM(B2:B5)` |
| `VLOOKUP` | Vertikaler SVERWEIS | `VLOOKUP(A2,B2:D10,3,FALSE)` |

Die in der Tabelle gezeigten Einschränkungen sind bedeutend: `INDEX` ist in Referenzform dokumentiert, während `LOOKUP` und `MATCH` in ihren Vektorformen dokumentiert sind. `DATE` verwendet das 1900‑Datumsystem. Nicht aufgeführte Funktionen sollten als nicht unterstützt vom Aspose.Slides‑Formelauswerter angesehen werden, sofern sie nicht separat dokumentiert sind.

## **Formeln mit bevorzugter Kultur berechnen**

Einige Arbeitsblatt‑Funktionen interpretieren Text nach kulturspezifischen Regeln. Das ist besonders wichtig für Funktionen, die für Sprachen mit Double‑Byte‑Character‑Sets (DBCS) gedacht sind. Um solche Formeln korrekt zu berechnen, erstellen Sie ein [LoadOptions](https://reference.aspose.com/slides/de/cpp/aspose.slides/loadoptions/), konfigurieren Sie [ISpreadsheetOptions::set_PreferredCulture](https://reference.aspose.com/slides/de/cpp/aspose.slides/ispreadsheetoptions/set_preferredculture/) über [LoadOptions::set_SpreadsheetOptions](https://reference.aspose.com/slides/de/cpp/aspose.slides/loadoptions/set_spreadsheetoptions/) und laden dann die Präsentation.

Im folgenden Beispiel wird die japanische Kultur ausgewählt, eine Präsentation mit den konfigurierten Ladeoptionen geöffnet und für jedes Diagramm‑Arbeitsblatt [IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/de/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/) aufgerufen:

```cpp
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/IChart.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <DOM/SpreadsheetOptions.h>
#include <system/globalization/culture_info.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;
using namespace System::Globalization;

auto japaneseCulture = CultureInfo::GetCultureInfo(u"ja-JP");

auto spreadsheetOptions = MakeObject<SpreadsheetOptions>();
spreadsheetOptions->set_PreferredCulture(japaneseCulture);

auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_SpreadsheetOptions(spreadsheetOptions);

auto presentation = MakeObject<Presentation>(u"presentation.pptx", loadOptions);

for (int32_t slideIndex = 0; slideIndex < presentation->get_Slides()->get_Count(); slideIndex++)
{
    auto slide = presentation->get_Slide(slideIndex);

    for (int32_t shapeIndex = 0; shapeIndex < slide->get_Shapes()->get_Count(); shapeIndex++)
    {
        auto shape = slide->get_Shape(shapeIndex);
        if (ObjectExt::Is<IChart>(shape))
        {
            auto chart = ExplicitCast<IChart>(shape);
            chart->get_ChartData()->get_ChartDataWorkbook()->CalculateFormulas();
        }
    }
}
```

Die bevorzugte Kultur ist Teil der Lade‑Konfiguration, daher muss sie vor dem Erzeugen der [Presentation](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/)‑Instanz angegeben werden. Verwenden Sie die Kultur, die von den Arbeitsblatt‑Formeln erwartet wird; z. B. `ja-JP` für Formeln, die japanische DBCS‑Berechnungsregeln befolgen sollen.

## **Neuberechnung und zwischengespeicherte Werte**

Tabellendateien speichern häufig sowohl die Formel als auch den zuletzt berechneten Wert. Aspose.Slides kann daher einen zwischengespeicherten Wert aus [IChartDataCell::get_Value](https://reference.aspose.com/slides/de/cpp/aspose.slides.charts/ichartdatacell/get_value/) lesen, wenn eine Präsentation geladen wird und die betreffenden Diagrammdaten nicht geändert wurden.

Nachdem Eingabezellen oder Formeln geändert wurden, dürfen Sie sich nicht auf ein altes zwischengespeichertes Ergebnis verlassen. Rufen Sie vor dem Lesen berechneter Werte oder dem Speichern von Diagrammdaten, die von ihnen abhängen, [IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/de/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/) auf.

Für Formeln außerhalb des unterstützten Subsets kann Aspose.Slides die Formel möglicherweise nicht parsen oder ihre Abhängigkeiten nicht ermitteln. Wurde die Arbeitsmappe geändert, kann der vorherige zwischengespeicherte Wert nicht mehr als zuverlässig betrachtet werden. In diesem Fall kann das Lesen des Werts einer Zelle mit nicht unterstützten Daten die Ausnahme [CellUnsupportedDataException](https://reference.aspose.com/slides/de/cpp/aspose.slides.spreadsheet/cellunsupporteddataexception/) auslösen.

Wenn Ihr Diagramm Excel‑Funktionen verwendet, die Aspose.Slides nicht auswertet, berechnen Sie diese Formeln mit einer Tabellen‑Engine, die sie unterstützt, und schreiben Sie die resultierenden Werte zurück ins Diagramm‑Arbeitsblatt. Ersetzen Sie nicht‑unterstützte Formeln nicht durch geschätzte Werte.

## **Formelfehler behandeln**

Es gibt zwei verschiedene Arten von Problemen zu unterscheiden.

Eine Formel kann gültig sein, aber ein Tabellen‑Fehlerergebnis wie `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!` oder `#VALUE!` erzeugen. In diesem Fall ist das Fehlertoken ein Zell‑Ergebnis und kann über [IChartDataCell::get_Value](https://reference.aspose.com/slides/de/cpp/aspose.slides.charts/ichartdatacell/get_value/) zurückgegeben werden.

Eine Formel kann zudem beim Parsen, bei Referenzen, Abhängigkeiten oder unterstützten Daten fehlschlagen. Aspose.Slides liefert dafür tabellenspezifische Ausnahmen: [CellInvalidFormulaException](https://reference.aspose.com/slides/de/cpp/aspose.slides.spreadsheet/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/de/cpp/aspose.slides.spreadsheet/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/de/cpp/aspose.slides.spreadsheet/cellcircularreferenceexception/) und [CellUnsupportedDataException](https://reference.aspose.com/slides/de/cpp/aspose.slides.spreadsheet/cellunsupporteddataexception/).

Wenn Formeln aus Vorlagen oder Benutzereingaben stammen, fangen Sie diese Ausnahmen beim Neuberechnen und beim Zugriff auf Werte ab:

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
    // Behandeln Sie eine ungültige Formel.
}
catch (CellInvalidReferenceException&)
{
    // Behandeln Sie eine ungültige Zellreferenz.
}
catch (CellCircularReferenceException&)
{
    // Behandeln Sie eine zirkuläre Referenz.
}
catch (CellUnsupportedDataException&)
{
    // Behandeln Sie nicht unterstützte Tabellendaten.
}
```

## **Praktische Einschränkungen**

Die Formelunterstützung in Diagramm‑Arbeitsblättern ist für einen definierten Teilbereich von Tabell‑Berechnungen gedacht, nicht für vollständige Excel‑Kompatibilität. Beachten Sie diese Einschränkungen beim Entwerfen eines Reporting‑Workflows:

- Verwenden Sie nur die dokumentierten Konstanten, Operatoren, Referenzen und Funktionen, wenn Aspose.Slides die Formeln neu berechnen soll.
- Berechnen Sie neu, nachdem Zellen geändert wurden, von denen Formel‑Ergebnisse abhängen.
- Betrachten Sie zwischengespeicherte Werte aus geladenen Präsentationen als Momentaufnahme, nicht als Ersatz für eine Neuberechnung nach Änderungen.
- Testen Sie Formeln aus bestehenden Vorlagen, bevor Sie sich auf ihre berechneten Werte verlassen, insbesondere wenn sie Funktionen außerhalb der dokumentierten Liste verwenden.
- Für Formeln, die eine vollständige Tabellen‑Berechnungsengine benötigen, führen Sie die Berechnung extern durch und aktualisieren anschließend das Diagramm‑Arbeitsblatt mit den resultierenden Werten.

## **FAQ**

**Was ist der Unterschied zwischen `set_Formula` und `set_R1C1Formula`?**

[IChartDataCell::set_Formula](https://reference.aspose.com/slides/de/cpp/aspose.slides.charts/ichartdatacell/set_formula/) speichert einen A1‑Ausdruck wie `B2-C2`. [IChartDataCell::set_R1C1Formula](https://reference.aspose.com/slides/de/cpp/aspose.slides.charts/ichartdatacell/set_r1c1formula/) speichert einen R1C1‑Ausdruck wie `RC[-2]-RC[-1]`. Verwenden Sie die Notation, die am besten zu Ihrer Erzeugungs‑ oder Kopierlogik passt.

**Muss ich nach der Berechnung die Zelle selbst oder ihren Wert lesen?**

[IChartDataWorkbook::GetCell](https://reference.aspose.com/slides/de/cpp/aspose.slides.charts/ichartdataworkbook/getcell/) liefert ein `IChartDataCell`. Um das berechnete Ergebnis zu erhalten, lesen Sie den Wert dieser Zelle über [IChartDataCell::get_Value](https://reference.aspose.com/slides/de/cpp/aspose.slides.charts/ichartdatacell/get_value/) nach der Neuberechnung.

**Wann soll ich `CalculateFormulas` aufrufen?**

Rufen Sie [IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/de/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/) auf, nachdem Eingabewerte oder Formeln geändert wurden und bevor Sie von den berechneten Ergebnissen abhängen. Dadurch werden die Werte der von dem integrierten Auswerter unterstützten Formeln aktualisiert.

**Unterstützt Aspose.Slides jede Excel‑Funktion?**

Nein. Der integrierte Auswerter unterstützt nur ein dokumentiertes Funktions‑Subset. Funktionen außerhalb dieses Subsets sollten nicht als korrekt neu berechenbar angesehen werden. Wenn vollständige Excel‑Formel‑Kompatibilität erforderlich ist, führen Sie die Berechnung mit einer geeigneten Tabellen‑Engine durch und schreiben Sie die endgültigen Werte in das Diagramm‑Arbeitsblatt.

**Was passiert, wenn eine geladene Präsentation eine nicht unterstützte Formel enthält?**

Falls die Diagrammdaten nicht geändert wurden, kann das Arbeitsblatt noch einen zuvor berechneten, zwischengespeicherten Wert enthalten. Nachdem die zugehörigen Daten geändert wurden, ist dieser zwischengespeicherte Wert möglicherweise nicht mehr gültig. Der Zugriff auf eine Zelle, deren Formel nicht verarbeitet werden kann, kann die Ausnahme [CellUnsupportedDataException](https://reference.aspose.com/slides/de/cpp/aspose.slides.spreadsheet/cellunsupporteddataexception/) auslösen.

**Sind Formelfehlerwerte das gleiche wie C++‑Ausnahmen?**

Nein. Ein Ergebnis wie `#DIV/0!` ist ein Tabellenwert, der durch eine gültige Berechnung entsteht. Ausnahmen wie [CellInvalidFormulaException](https://reference.aspose.com/slides/de/cpp/aspose.slides.spreadsheet/cellinvalidformulaexception/) oder [CellCircularReferenceException](https://reference.aspose.com/slides/de/cpp/aspose.slides.spreadsheet/cellcircularreferenceexception/) zeigen an, dass die Formel nicht normal verarbeitet werden kann.

**Wird ein Diagramm automatisch aktualisiert, wenn sich eine Formelzelle ändert?**

Eine Diagramm‑Serie kann Arbeitsblatt‑Zellen referenzieren. Berechnen Sie das Arbeitsblatt zuerst, speichern oder rendern Sie anschließend die Präsentation. Verweisen die Diagrammdatenpunkte auf die berechneten Zellen, verwendet das Diagramm die aktualisierten Zellwerte; ein separater Diagramm‑Aktualisierungs‑Aufruf ist für diesen Workflow nicht erforderlich.

**Können Diagramme ein externes Excel‑Arbeitsblatt verwenden?**

Ja, Diagrammdaten können so konfiguriert werden, dass sie ein externes Arbeitsblatt verwenden, über die Diagrammdaten‑API. Der in diesem Artikel beschriebene Formel‑Berechnungs‑Workflow bezieht sich jedoch ausschließlich auf das Diagramm‑Arbeitsblatt und das von Aspose.Slides ausgewertete Formelsubset. Es darf nicht angenommen werden, dass [IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/de/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/) eine vollständige Neuberechnung beliebiger Formeln in einer externen XLSX‑Datei liefert.

**Kann ich Formeln verwenden, die auf ein anderes Arbeitsblatt oder Arbeitsbuch verweisen?**

Excel‑artige Referenzen können in Diagramm‑Arbeitsblättern vorkommen, aber die Formelauswertung ist auf den unterstützten Parser und die Funktionsmenge beschränkt. Wenn ein Bezug über mehrere Blätter oder externe Dateien erforderlich ist, prüfen Sie die genaue Formel mit Ihrer Ziel‑Aspose.Slides‑Version. Für Workflows, die breite Excel‑Referenz‑Kompatibilität benötigen, berechnen Sie das Arbeitsblatt extern und schreiben die aufgelösten Werte zurück in die Diagrammdaten.

**Müssen Formelformeln mit `=` beginnen?**

Die Aspose.Slides‑API‑Beispiele weisen Ausdrücke wie `B2-C2` oder `SUM(B2:B5)` ohne führendes `=` zu. Die Verwendung dieser Form hält erzeugte Formeln konsistent zu den dokumentierten API‑Beispielen.
---
title: "Applicare le formule del foglio di lavoro del grafico nelle presentazioni con C++"
linktitle: "Formule del foglio di lavoro"
type: docs
weight: 70
url: /it/cpp/chart-worksheet-formulas/
keywords:
- "foglio di calcolo del grafico"
- "foglio di lavoro del grafico"
- "formula del grafico"
- "formula del foglio di lavoro"
- "formula del foglio di calcolo"
- "cartella di lavoro dei dati del grafico"
- "calcolo della formula"
- "cultura preferita"
- "formula specifica per cultura"
- "DBCS"
- "costante logica"
- "costante numerica"
- "costante stringa"
- "costante di errore"
- "operatore aritmetico"
- "operatore di confronto"
- "stile A1"
- "stile R1C1"
- "funzione predefinita"
- "PowerPoint"
- "presentazione"
- "C++"
- "Aspose.Slides"
description: "Applicare formule in stile Excel nei fogli di lavoro dei grafici di Aspose.Slides per C++, ricalcolare i valori e utilizzare i risultati nei grafici PowerPoint."
---
## **Panoramica**

I grafici di PowerPoint solitamente memorizzano i dati di origine in un foglio di lavoro incorporato. In Aspose.Slides per C++, è possibile accedere a quel foglio di lavoro tramite la cartella di lavoro dei dati del grafico, scrivere valori di input, assegnare formule alle celle, calcolare le formule supportate e utilizzare le celle calcolate come dati del grafico.

Questo articolo spiega l’intero flusso di lavoro delle formule: creare un grafico, popolare il suo foglio di lavoro, assegnare formule in stile A1 o R1C1, ricalcolarle, leggere i valori calcolati, collegare quelle celle a una serie del grafico e salvare la presentazione. Descrive inoltre la sintassi delle formule supportate, il sottoinsieme di funzioni integrate, i valori memorizzati nella cache, le formule non supportate e gli errori specifici del foglio di calcolo.

## **Fogli di lavoro dei grafici e formule**

Un foglio di lavoro di un grafico contiene le categorie, i nomi delle serie e i valori utilizzati da un grafico. In PowerPoint, è possibile ispezionare il foglio di lavoro aprendo l’editor dei dati del grafico:

![Grafico PowerPoint con il suo foglio di lavoro incorporato aperto, mostrando i dati di categorie e serie](chart-worksheet-formulas_1.png)

In Aspose.Slides, il foglio di lavoro è esposto tramite l’interfaccia [IChartDataWorkbook](https://reference.aspose.com/slides/it/cpp/aspose.slides.charts/ichartdataworkbook/). Utilizzare [IChartDataCell::set_Formula](https://reference.aspose.com/slides/it/cpp/aspose.slides.charts/ichartdatacell/set_formula/) per formule in stile A1 e [IChartDataCell::set_R1C1Formula](https://reference.aspose.com/slides/it/cpp/aspose.slides.charts/ichartdatacell/set_r1c1formula/) per formule in stile R1C1. Dopo aver modificato le celle di input o le formule, chiamare [IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/it/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/) per ricalcolare le formule supportate e aggiornare i valori delle celle corrispondenti.

Una cella calcolata espone ancora il suo risultato tramite [IChartDataCell::get_Value](https://reference.aspose.com/slides/it/cpp/aspose.slides.charts/ichartdatacell/get_value/). Questo è importante quando è necessario ispezionare il risultato di una formula nel codice o utilizzare la cella come punto dati del grafico.

## **Creare un grafico e calcolare le formule del foglio di lavoro**

Il seguente esempio dimostra un flusso di lavoro end‑to‑end. Crea un grafico a colonne raggruppate, cancella i dati di esempio, scrive i valori di fatturato e spese trimestrali, calcola il profitto con le formule, legge i risultati, utilizza le celle calcolate come valori del grafico e salva la presentazione.

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

I punti dati del grafico fanno riferimento a `D2:D4`, quindi il grafico utilizza i valori di profitto calcolati. Non è presente una chiamata separata per aggiornare il grafico in questo flusso di lavoro: ricalcolare prima la cartella di lavoro, quindi utilizzare o salvare i dati del grafico che puntano alle celle calcolate.

## **Utilizzare formule in stile A1**

La notazione A1 identifica le colonne con lettere e le righe con numeri. Assegnare espressioni in stile A1 tramite [IChartDataCell::set_Formula](https://reference.aspose.com/slides/it/cpp/aspose.slides.charts/ichartdatacell/set_formula/).

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

Le forme di riferimento A1 comuni sono:

| Riferimento | Relativo | Assoluto | Misto |
|---|---|---|---|
| Cella | `A2` | `$A$2` | `A$2`, `$A2` |
| Riga | `2:2` | `$2:$2` | — |
| Colonna | `A:A` | `$A:$A` | — |
| Intervallo | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

I riferimenti relativi possono cambiare quando una formula viene spostata o copiata da un’applicazione di foglio di calcolo. I riferimenti assoluti mantengono entrambe le coordinate fisse, mentre i riferimenti misti fissano solo una riga o una colonna.

## **Utilizzare formule in stile R1C1**

La notazione R1C1 identifica sia le righe sia le colonne numericamente. I riferimenti relativi utilizzano offset tra parentesi quadre. Assegnare questa sintassi tramite [IChartDataCell::set_R1C1Formula](https://reference.aspose.com/slides/it/cpp/aspose.slides.charts/ichartdatacell/set_r1c1formula/).

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

Le forme di riferimento R1C1 comuni sono:

| Riferimento | Relativo | Assoluto | Misto |
|---|---|---|---|
| Cella | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| Riga | `R[2]` | `R2` | — |
| Colonna | `C[3]` | `C3` | — |
| Intervallo | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

Ad esempio, nella cella `D2`, `RC[-2]` indica la cella nella stessa riga due colonne a sinistra (`B2`).

## **Costanti e operatori delle formule**

Il valutatore di formule integrato supporta valori logici, letterali numerici, stringhe, valori di errore del foglio di calcolo, operatori aritmetici e operatori di confronto.

### **Costanti e letterali**

| Tipo | Esempi | Note |
|---|---|---|
| Logico | `TRUE`, `FALSE` | Può essere usato direttamente in espressioni logiche come `A2=TRUE`. |
| Numerico | `1`, `0.5`, `.3`, `1E-2` | Sono supportate notazione comune e scientifica. |
| Stringa | `"abc"`, `"2/3/2020 12:00"` | I letterali di testo sono racchiusi tra virgolette doppie all’interno della formula. |
| Risultato di errore | `#DIV/0!`, `#N/A`, `#REF!` | Una formula valida può valutare a un valore di errore del foglio di calcolo invece di un risultato normale. |

Questo esempio utilizza diversi tipi di costanti:

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

auto logicalValue = workbook->GetCell(0, u"B2")->get_Value(); // Falso
auto numericValue = workbook->GetCell(0, u"C2")->get_Value(); // 1.5
auto scientificValue = workbook->GetCell(0, u"D2")->get_Value(); // 0.003
auto stringValue = workbook->GetCell(0, u"E2")->get_Value(); // abc
auto errorValue = workbook->GetCell(0, u"F2")->get_Value(); // #DIV/0!
```

### **Operatori aritmetici**

| Operatore | Significato | Esempio |
|---|---|---|
| `+` | Addizione o segno più unario | `2+3` |
| `-` | Sottrazione o negazione | `2-3`, `-3` |
| `*` | Moltiplicazione | `2*3` |
| `/` | Divisione | `2/3` |
| `%` | Percentuale | `30%` |
| `^` | Elevamento a potenza | `2^3` |

Usare le parentesi per rendere esplicito l’ordine di valutazione, ad esempio `(A2+B2)*C2`.

### **Operatori di confronto**

Le espressioni di confronto restituiscono valori logici.

| Operatore | Significato | Esempio |
|---|---|---|
| `=` | Uguale a | `A2=3` |
| `<>` | Diverso da | `A2<>3` |
| `>` | Maggiore di | `A2>3` |
| `>=` | Maggiore o uguale a | `A2>=3` |
| `<` | Minore di | `A2<3` |
| `<=` | Minore o uguale a | `A2<=3` |

## **Funzioni predefinite supportate**

Aspose.Slides include un valutatore di formule integrato per i fogli di lavoro dei grafici, ma non è un motore di calcolo completo di Excel. Il set di funzioni documentato è limitato alle funzioni elencate di seguito. Non presumere che una funzione Excel arbitraria possa essere ricalcolata da [IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/it/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/).

| Funzione | Scopo o forma supportata | Esempio |
|---|---|---|
| `ABS` | Valore assoluto | `ABS(A2)` |
| `AVERAGE` | Media aritmetica | `AVERAGE(B2:B5)` |
| `CEILING` | Arrotonda un numero per eccesso al multiplo più vicino | `CEILING(A2,5)` |
| `CHOOSE` | Seleziona un valore per indice | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | Unisce valori di testo | `CONCAT(A2,B2)` |
| `CONCATENATE` | Unisce valori di testo | `CONCATENATE(A2," ",B2)` |
| `DATE` | Crea un valore data usando il sistema data 1900 | `DATE(2026,8,19)` |
| `DAYS` | Restituisce il numero di giorni tra due date | `DAYS(B2,A2)` |
| `FIND` | Trova una stringa all’interno di un’altra | `FIND("-",A2)` |
| `FINDB` | Ricerca testo orientata ai byte | `FINDB("a",A2)` |
| `IF` | Risultato condizionale | `IF(A2>0,A2,0)` |
| `INDEX` | Forma di riferimento | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | Forma vettoriale | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | Forma vettoriale | `MATCH(A2,B2:B5,0)` |
| `MAX` | Valore massimo | `MAX(B2:B5)` |
| `SUM` | Somma valori | `SUM(B2:B5)` |
| `VLOOKUP` | Ricerca verticale | `VLOOKUP(A2,B2:D10,3,FALSE)` |

Le restrizioni mostrate nella tabella sono significative: `INDEX` è documentato nella forma di riferimento, mentre `LOOKUP` e `MATCH` sono documentati nelle loro forme vettoriali. `DATE` usa il sistema data 1900. Funzionalità e funzioni non elencate qui dovrebbero essere considerate non supportate dal valutatore di formule di Aspose.Slides, salvo diversa documentazione.

## **Calcolare le formule con una cultura preferita**

Alcune funzioni del workbook del grafico interpretano il testo secondo regole specifiche di cultura. Questo è particolarmente importante per le funzioni destinate a lingue che usano set di caratteri a doppio byte (DBCS). Per calcolare correttamente tali formule, creare [LoadOptions](https://reference.aspose.com/slides/it/cpp/aspose.slides/loadoptions/), configurare [ISpreadsheetOptions::set_PreferredCulture](https://reference.aspose.com/slides/it/cpp/aspose.slides/ispreadsheetoptions/set_preferredculture/) tramite [LoadOptions::set_SpreadsheetOptions](https://reference.aspose.com/slides/it/cpp/aspose.slides/loadoptions/set_spreadsheetoptions/), e poi caricare la presentazione.

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

La cultura preferita fa parte della configurazione di caricamento della presentazione, quindi specificarla prima di creare l’istanza di [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/). Utilizzare la cultura attesa dalle formule del workbook; ad esempio, usare `ja-JP` per formule che devono seguire le regole di calcolo DBCS giapponesi.

## **Ricalcolo e valori in cache**

I file di foglio di calcolo memorizzano comunemente sia una formula sia il suo ultimo valore calcolato. Aspose.Slides può quindi leggere un valore in cache da [IChartDataCell::get_Value](https://reference.aspose.com/slides/it/cpp/aspose.slides.charts/ichartdatacell/get_value/) quando una presentazione viene caricata e i dati del grafico pertinenti non sono stati modificati.

Dopo aver modificato le celle di input o le formule, non fare affidamento su un risultato in cache vecchio. Chiamare [IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/it/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/) prima di leggere i valori calcolati o di salvare i dati del grafico che dipendono da essi.

Per le formule al di fuori del sottoinsieme supportato, Aspose.Slides potrebbe non riuscire a analizzare la formula o a stabilirne le dipendenze. Se il workbook è stato modificato, il valore in cache precedente non può più essere considerato affidabile. In tale situazione, leggere il valore di una cella con dati non supportati può sollevare [CellUnsupportedDataException](https://reference.aspose.com/slides/it/cpp/aspose.slides.spreadsheet/cellunsupporteddataexception/).

Se il tuo grafico dipende da funzioni Excel che Aspose.Slides non valuta, calcola quelle formule con un motore di foglio di calcolo che le supporta e scrivi i valori risultanti nel workbook del grafico. Non sostituire le formule non supportate con valori indovinati.

## **Gestire gli errori di formula**

Ci sono due tipologie di problemi da distinguere.

Una formula può essere valida ma produrre un risultato di errore del foglio di calcolo, ad esempio `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!` o `#VALUE!`. In questo caso, il token di errore è un risultato di cella e può essere restituito tramite [IChartDataCell::get_Value](https://reference.aspose.com/slides/it/cpp/aspose.slides.charts/ichartdatacell/get_value/).

Una formula può anche fallire a livello di parsing, riferimento, dipendenza o dati supportati. Aspose.Slides fornisce eccezioni specifiche del foglio di calcolo per questi casi: [CellInvalidFormulaException](https://reference.aspose.com/slides/it/cpp/aspose.slides.spreadsheet/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/it/cpp/aspose.slides.spreadsheet/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/it/cpp/aspose.slides.spreadsheet/cellcircularreferenceexception/), e [CellUnsupportedDataException](https://reference.aspose.com/slides/it/cpp/aspose.slides.spreadsheet/cellunsupporteddataexception/).

Quando le formule provengono da modelli o da input dell’utente, gestire queste eccezioni attorno al ricalcolo e all’accesso ai valori:

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
    // Gestire una formula non valida.
}
catch (CellInvalidReferenceException&)
{
    // Gestire un riferimento di cella non valido.
}
catch (CellCircularReferenceException&)
{
    // Gestire un riferimento circolare.
}
catch (CellUnsupportedDataException&)
{
    // Gestire dati di foglio di calcolo non supportati.
}
```

## **Limitazioni pratiche**

Il supporto alle formule nei fogli di lavoro dei grafici è destinato a un sottoinsieme definito di calcoli di foglio di calcolo, non a una piena compatibilità con Excel. Tenere presente queste limitazioni durante la progettazione di un flusso di lavoro di reporting:

- Utilizzare solo le costanti, gli operatori, i riferimenti e le funzioni documentati quando è necessario che Aspose.Slides ricalcoli le formule.
- Ricalcolare dopo aver modificato le celle da cui dipendono i risultati delle formule.
- Considerare i valori in cache delle presentazioni caricate come istantanee, non come sostituti del ricalcolo dopo le modifiche.
- Testare le formule dei modelli esistenti prima di fare affidamento sui loro valori calcolati, soprattutto se utilizzano funzioni al di fuori dell’elenco documentato.
- Per le formule che richiedono un motore di calcolo completo del foglio di calcolo, calcolarle esternamente e poi aggiornare la cartella di lavoro del grafico con i valori risultanti.

## **FAQ**

**Qual è la differenza tra `set_Formula` e `set_R1C1Formula`?**

[IChartDataCell::set_Formula](https://reference.aspose.com/slides/it/cpp/aspose.slides.charts/ichartdatacell/set_formula/) memorizza un’espressione in stile A1 come `B2-C2`. [IChartDataCell::set_R1C1Formula](https://reference.aspose.com/slides/it/cpp/aspose.slides.charts/ichartdatacell/set_r1c1formula/) memorizza un’espressione in stile R1C1 come `RC[-2]-RC[-1]`. Utilizzare la notazione che meglio corrisponde al modo in cui si generano o copiano le formule.

**Devo leggere la cella stessa o il suo valore dopo il calcolo?**

[IChartDataWorkbook::GetCell](https://reference.aspose.com/slides/it/cpp/aspose.slides.charts/ichartdataworkbook/getcell/) restituisce un `IChartDataCell`. Per ottenere il risultato calcolato, leggere il valore di quella cella tramite [IChartDataCell::get_Value](https://reference.aspose.com/slides/it/cpp/aspose.slides.charts/ichartdatacell/get_value/) dopo il ricalcolo.

**Quando dovrei chiamare `CalculateFormulas`?**

Chiamare [IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/it/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/) dopo aver cambiato i valori di input o le formule e prima di dipendere dai risultati calcolati. Questo aggiorna i valori delle formule supportate dal valutatore integrato.

**Aspose.Slides supporta ogni funzione Excel?**

No. Il valutatore integrato supporta un sottoinsieme documentato di funzioni. Le funzioni al di fuori di quel sottoinsieme non dovrebbero essere considerate ricalcolabili correttamente. Se è necessaria una compatibilità completa delle formule Excel, eseguire il calcolo con un motore di foglio di calcolo appropriato e scrivere i valori finali nella cartella di lavoro del grafico.

**Cosa succede se una presentazione caricata contiene una formula non supportata?**

Se i dati del grafico non sono stati modificati, il workbook può ancora contenere un valore in cache calcolato in precedenza. Dopo che i dati correlati sono stati modificati, quel valore in cache potrebbe non essere più valido. L’accesso a una cella la cui formula non può essere gestita può sollevare [CellUnsupportedDataException](https://reference.aspose.com/slides/it/cpp/aspose.slides.spreadsheet/cellunsupporteddataexception/).

**I valori di errore di formula sono gli stessi delle eccezioni C++?**

No. Un risultato come `#DIV/0!` è un valore di foglio di calcolo prodotto da un calcolo valido. Le eccezioni come [CellInvalidFormulaException](https://reference.aspose.com/slides/it/cpp/aspose.slides.spreadsheet/cellinvalidformulaexception/) o [CellCircularReferenceException](https://reference.aspose.com/slides/it/cpp/aspose.slides.spreadsheet/cellcircularreferenceexception/) indicano che la formula non può essere processata normalmente.

**Un grafico si aggiorna automaticamente quando una cella di formula cambia?**

Una serie del grafico può fare riferimento a celle del workbook. Ricalcolare prima il workbook, quindi salvare o renderizzare la presentazione. Se i punti dati del grafico fanno riferimento alle celle calcolate, il grafico utilizza quei valori aggiornati; non è necessario un metodo separato di aggiornamento del grafico per questo flusso di lavoro.

**I grafici possono usare un workbook Excel esterno?**

Sì, i dati del grafico possono essere configurati per usare un workbook esterno tramite l’API dei dati del grafico. Tuttavia, il flusso di lavoro di calcolo delle formule descritto in questo articolo riguarda il workbook dei dati del grafico e il sottoinsieme di formule valutato da Aspose.Slides. Non presumere che [IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/it/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/) fornisca un ricalcolo completo di formule arbitrarie in un file XLSX esterno.

**Posso usare formule che fanno riferimento a un altro foglio o workbook?**

I riferimenti in stile Excel possono esistere nei workbook dei grafici, ma la valutazione delle formule è limitata dal parser e dal set di funzioni supportati. Se è essenziale un riferimento incrociato di foglio o esterno, verificare quella formula specifica con la versione di Aspose.Slides in uso. Per flussi di lavoro che richiedono una compatibilità ampia dei riferimenti Excel, calcolare il workbook esternamente e scrivere i valori risolti nei dati del grafico.

**Le stringhe di formula devono iniziare con `=`?**

Gli esempi API di Aspose.Slides assegnano espressioni come `B2-C2` o `SUM(B2:B5)` senza un `=` iniziale. Utilizzare questa forma mantiene le formule generate coerenti con gli esempi documentati dell’API.
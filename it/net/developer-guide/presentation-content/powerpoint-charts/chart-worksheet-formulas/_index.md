---
title: Applica formule dei fogli di lavoro dei grafici nelle presentazioni in .NET
linktitle: Formule del foglio di lavoro
type: docs
weight: 70
url: /it/net/chart-worksheet-formulas/
keywords:
- foglio di calcolo del grafico
- foglio di lavoro del grafico
- formula del grafico
- formula del foglio di lavoro
- formula di foglio di calcolo
- cartella dati del grafico
- calcolo della formula
- costante logica
- costante numerica
- costante stringa
- costante di errore
- operatore aritmetico
- operatore di confronto
- stile A1
- stile R1C1
- funzione predefinita
- PowerPoint
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Applica formule in stile Excel nei fogli di lavoro dei grafici Aspose.Slides per .NET, ricalcola i valori e utilizza i risultati nei grafici PowerPoint."
---
## **Panoramica**

I grafici di PowerPoint memorizzano solitamente i dati di origine in un foglio di lavoro incorporato. In Aspose.Slides per .NET, è possibile accedere a quel foglio di lavoro tramite la cartella di lavoro dei dati del grafico, scrivere valori di input, assegnare formule alle celle, calcolare le formule supportate e utilizzare le celle calcolate come dati del grafico.

Questo articolo spiega l’intero flusso di lavoro delle formule: creare un grafico, popolare il suo foglio di lavoro, assegnare formule in stile A1 o R1C1, ricalcolarle, leggere i valori calcolati, collegare quelle celle a una serie del grafico e salvare la presentazione. Descrive inoltre la sintassi delle formule supportate, il sottoinsieme di funzioni integrate, i valori memorizzati nella cache, le formule non supportate e gli errori specifici dei fogli di calcolo.

## **Fogli di lavoro dei grafici e formule**

Un foglio di lavoro di un grafico contiene le categorie, i nomi delle serie e i valori usati dal grafico. In PowerPoint è possibile ispezionare il foglio aprendo l’editor dei dati del grafico:

![Grafico PowerPoint con il foglio di lavoro incorporato aperto, che mostra i dati di categorie e serie](chart-worksheet-formulas_1.png)

In Aspose.Slides, il foglio è esposto tramite il [chart data workbook](https://reference.aspose.com/slides/it/net/aspose.slides.charts/ichartdataworkbook/). Utilizzare la proprietà [Formula](https://reference.aspose.com/slides/it/net/aspose.slides.charts/ichartdatacell/formula/) per le formule in stile A1 e la proprietà [R1C1Formula](https://reference.aspose.com/slides/it/net/aspose.slides.charts/ichartdatacell/r1c1formula/) per le formule in stile R1C1. Dopo aver modificato le celle di input o le formule, chiamare [CalculateFormulas](https://reference.aspose.com/slides/it/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/) per ricalcolare le formule supportate e aggiornare i relativi valori delle celle.

Una cella calcolata espone ancora il suo risultato tramite la proprietà [Value](https://reference.aspose.com/slides/it/net/aspose.slides.charts/ichartdatacell/value/). Questo è importante quando è necessario ispezionare il risultato di una formula nel codice o usare la cella come punto dati del grafico.

## **Creare un grafico e calcolare le formule del foglio di lavoro**

L’esempio seguente mostra un flusso di lavoro end‑to‑end. Crea un grafico a colonne raggruppate, cancella i dati di esempio, scrive i valori di fatturato e spese trimestrali, calcola il profitto con le formule, legge i risultati, usa le celle calcolate come valori del grafico e salva la presentazione.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 350);
var workbook = chart.ChartData.ChartDataWorkbook;
var worksheetIndex = 0;

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();
workbook.Clear(worksheetIndex);

var category1 = workbook.GetCell(worksheetIndex, "A2", "Q1");
var category2 = workbook.GetCell(worksheetIndex, "A3", "Q2");
var category3 = workbook.GetCell(worksheetIndex, "A4", "Q3");

workbook.GetCell(worksheetIndex, "B1", "Revenue");
workbook.GetCell(worksheetIndex, "C1", "Expenses");
workbook.GetCell(worksheetIndex, "D1", "Profit");

workbook.GetCell(worksheetIndex, "B2").Value = 120.0;
workbook.GetCell(worksheetIndex, "C2").Value = 80.0;
workbook.GetCell(worksheetIndex, "B3").Value = 150.0;
workbook.GetCell(worksheetIndex, "C3").Value = 95.0;
workbook.GetCell(worksheetIndex, "B4").Value = 135.0;
workbook.GetCell(worksheetIndex, "C4").Value = 110.0;

var profit1 = workbook.GetCell(worksheetIndex, "D2");
var profit2 = workbook.GetCell(worksheetIndex, "D3");
var profit3 = workbook.GetCell(worksheetIndex, "D4");

profit1.Formula = "B2-C2";
profit2.Formula = "B3-C3";
profit3.Formula = "B4-C4";

workbook.CalculateFormulas();

var q1Profit = Convert.ToDouble(profit1.Value); // 40
var q2Profit = Convert.ToDouble(profit2.Value); // 55
var q3Profit = Convert.ToDouble(profit3.Value); // 25

Console.WriteLine($"Q1 profit: {q1Profit}");
Console.WriteLine($"Q2 profit: {q2Profit}");
Console.WriteLine($"Q3 profit: {q3Profit}");

chart.ChartData.Categories.Add(category1);
chart.ChartData.Categories.Add(category2);
chart.ChartData.Categories.Add(category3);

var profitSeries = chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, "D1"), chart.Type);
profitSeries.DataPoints.AddDataPointForBarSeries(profit1);
profitSeries.DataPoints.AddDataPointForBarSeries(profit2);
profitSeries.DataPoints.AddDataPointForBarSeries(profit3);
profitSeries.Labels.DefaultDataLabelFormat.ShowValue = true;

presentation.Save("chart-formulas.pptx", SaveFormat.Pptx);
```

I punti dati del grafico fanno riferimento a `D2:D4`, quindi il grafico utilizza i valori di profitto calcolati. Non è necessaria una chiamata separata di aggiornamento del grafico in questo flusso: ricalcolare prima la cartella di lavoro, poi usare o salvare i dati del grafico che puntano alle celle calcolate.

## **Usare formule in stile A1**

La notazione A1 identifica le colonne con lettere e le righe con numeri. Assegnare espressioni in stile A1 tramite [IChartDataCell.Formula](https://reference.aspose.com/slides/it/net/aspose.slides.charts/ichartdatacell/formula/).

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 300);
var workbook = chart.ChartData.ChartDataWorkbook;

workbook.GetCell(0, "C3").Value = 10;
workbook.GetCell(0, "F2").Value = 2;
workbook.GetCell(0, "G2").Value = 3;
workbook.GetCell(0, "H2").Value = 4;

var cell = workbook.GetCell(0, "A2");
cell.Formula = "C3+SUM(F2:H2)";

workbook.CalculateFormulas();

var value = cell.Value; // 19
```

Le forme di riferimento A1 più comuni sono:

| Riferimento | Relativa | Assoluta | Mista |
|---|---|---|---|
| Cella | `A2` | `$A$2` | `A$2`, `$A2` |
| Riga | `2:2` | `$2:$2` | — |
| Colonna | `A:A` | `$A:$A` | — |
| Intervallo | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

I riferimenti relativi possono cambiare quando una formula viene spostata o copiata da un’applicazione di foglio di calcolo. I riferimenti assoluti mantengono fissi entrambi i coordinati, mentre quelli misti fissano solo una riga o una colonna.

## **Usare formule in stile R1C1**

La notazione R1C1 identifica sia righe sia colonne numericamente. I riferimenti relativi usano offset tra parentesi quadre. Assegnare questa sintassi tramite [IChartDataCell.R1C1Formula](https://reference.aspose.com/slides/it/net/aspose.slides.charts/ichartdatacell/r1c1formula/).

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 300);
var workbook = chart.ChartData.ChartDataWorkbook;

workbook.GetCell(0, "B2").Value = 12;
workbook.GetCell(0, "C2").Value = 5;

var cell = workbook.GetCell(0, "D2");
cell.R1C1Formula = "RC[-2]-RC[-1]";

workbook.CalculateFormulas();

var value = cell.Value; // 7
```

Le forme di riferimento R1C1 più comuni sono:

| Riferimento | Relativa | Assoluta | Mista |
|---|---|---|---|
| Cella | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| Riga | `R[2]` | `R2` | — |
| Colonna | `C[3]` | `C3` | — |
| Intervallo | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

Ad esempio, nella cella `D2`, `RC[-2]` indica la cella nella stessa riga due colonne a sinistra (`B2`).

## **Costanti e operatori delle formule**

Il valutatore di formule integrato supporta valori logici, letterali numerici, stringhe, valori di errore dei fogli di calcolo, operatori aritmetici e operatori di confronto.

### **Costanti e letterali**

| Tipo | Esempi | Note |
|---|---|---|
| Logico | `TRUE`, `FALSE` | Può essere usato direttamente in espressioni logiche come `A2=TRUE`. |
| Numerico | `1`, `0.5`, `.3`, `1E-2` | Sono supportate notazioni decimali e scientifiche. |
| Stringa | `"abc"`, `"2/3/2020 12:00"` | I letterali di testo sono racchiusi tra virgolette doppie all’interno della formula. |
| Risultato errore | `#DIV/0!`, `#N/A`, `#REF!` | Una formula valida può valutare a un valore di errore del foglio di calcolo anziché a un risultato normale. |

Questo esempio utilizza diversi tipi di costanti:

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 300);
var workbook = chart.ChartData.ChartDataWorkbook;

workbook.GetCell(0, "A2").Value = false;
workbook.GetCell(0, "B2").Formula = "A2=TRUE";
workbook.GetCell(0, "C2").Formula = "1+0.5";
workbook.GetCell(0, "D2").Formula = ".3*1E-2";
workbook.GetCell(0, "E2").Formula = "\"abc\"";
workbook.GetCell(0, "F2").Formula = "2/0";

workbook.CalculateFormulas();

var logicalValue = workbook.GetCell(0, "B2").Value; // Falso
var numericValue = workbook.GetCell(0, "C2").Value; // 1.5
var scientificValue = workbook.GetCell(0, "D2").Value; // 0.003
var stringValue = workbook.GetCell(0, "E2").Value; // abc
var errorValue = workbook.GetCell(0, "F2").Value; // #DIV/0!
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

Aspose.Slides include un valutatore di formule integrato per i fogli di lavoro dei grafici, ma non è un motore di calcolo completo di Excel. Il set di funzioni documentato è limitato alle funzioni elencate di seguito. Non presumere che una funzione arbitraria di Excel possa essere ricalcolata da [CalculateFormulas](https://reference.aspose.com/slides/it/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/).

| Funzione | Scopo o forma supportata | Esempio |
|---|---|---|
| `ABS` | Valore assoluto | `ABS(A2)` |
| `AVERAGE` | Media aritmetica | `AVERAGE(B2:B5)` |
| `CEILING` | Arrotonda un numero per eccesso a un multiplo | `CEILING(A2,5)` |
| `CHOOSE` | Seleziona un valore per indice | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | Unisce valori di testo | `CONCAT(A2,B2)` |
| `CONCATENATE` | Unisce valori di testo | `CONCATENATE(A2," ",B2)` |
| `DATE` | Crea un valore data usando il sistema di data 1900 | `DATE(2026,8,19)` |
| `DAYS` | Restituisce il numero di giorni tra due date | `DAYS(B2,A2)` |
| `FIND` | Trova un valore di testo all’interno di un altro | `FIND("-",A2)` |
| `FINDB` | Ricerca di testo orientata ai byte | `FINDB("a",A2)` |
| `IF` | Risultato condizionale | `IF(A2>0,A2,0)` |
| `INDEX` | Forma di riferimento | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | Forma vettoriale | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | Forma vettoriale | `MATCH(A2,B2:B5,0)` |
| `MAX` | Valore massimo | `MAX(B2:B5)` |
| `SUM` | Somma valori | `SUM(B2:B5)` |
| `VLOOKUP` | Ricerca verticale | `VLOOKUP(A2,B2:D10,3,FALSE)` |

Le restrizioni illustrate nella tabella sono significative: `INDEX` è documentato in forma di riferimento, mentre `LOOKUP` e `MATCH` sono documentati nelle loro forme vettoriali. `DATE` utilizza il sistema di data 1900. Le funzionalità e le funzioni non elencate qui dovrebbero essere considerate non supportate dal valutatore di formule di Aspose.Slides, salvo diversa documentazione.

## **Ricalcolo e valori nella cache**

I file di foglio di calcolo memorizzano comunemente sia una formula sia il suo ultimo valore calcolato. Aspose.Slides può quindi leggere un valore nella cache da [IChartDataCell.Value](https://reference.aspose.com/slides/it/net/aspose.slides.charts/ichartdatacell/value/) quando una presentazione viene caricata e i dati del grafico pertinenti non sono stati modificati.

Dopo aver modificato le celle di input o le formule, non fare affidamento su un risultato nella cache obsoleto. Chiamare [IChartDataWorkbook.CalculateFormulas](https://reference.aspose.com/slides/it/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/) prima di leggere i valori calcolati o di salvare i dati del grafico che dipendono da essi.

Per le formule al di fuori del sottoinsieme supportato, Aspose.Slides potrebbe non riuscire a parsare la formula o a determinarne le dipendenze. Se la cartella di lavoro è stata modificata, il valore memorizzato nella cache non può più essere considerato affidabile. In tal caso, leggere il valore di una cella con dati non supportati può generare [CellUnsupportedDataException](https://reference.aspose.com/slides/it/net/aspose.slides.spreadsheet/cellunsupporteddataexception/).

Se il tuo grafico dipende da funzioni Excel che Aspose.Slides non valuta, calcola quelle formule con un motore di foglio di calcolo che le supporti e scrivi i valori risultanti nel workbook del grafico. Non sostituire formule non supportate con valori indovinati.

## **Gestire gli errori delle formule**

Esistono due tipologie di problemi da distinguere.

Una formula può essere valida ma produrre un risultato di errore del foglio, ad esempio `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!` o `#VALUE!`. In questo caso il token di errore è il risultato della cella e può essere restituito tramite `Value`.

Una formula può anche fallire a livello di parsing, riferimento, dipendenza o dati supportati. Aspose.Slides fornisce eccezioni specifiche del foglio di calcolo per questi casi: [CellInvalidFormulaException](https://reference.aspose.com/slides/it/net/aspose.slides.spreadsheet/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/it/net/aspose.slides.spreadsheet/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/it/net/aspose.slides.spreadsheet/cellcircularreferenceexception/), e [CellUnsupportedDataException](https://reference.aspose.com/slides/it/net/aspose.slides.spreadsheet/cellunsupporteddataexception/).

Quando le formule provengono da modelli o da input utente, gestire queste eccezioni attorno al ricalcolo e all’accesso ai valori:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Spreadsheet;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 300);
var workbook = chart.ChartData.ChartDataWorkbook;
var cell = workbook.GetCell(0, "A2");
cell.Formula = "SUM(B2:B5)";

try
{
    workbook.CalculateFormulas();
    Console.WriteLine(cell.Value);
}
catch (CellInvalidFormulaException ex)
{
    Console.Error.WriteLine($"Invalid formula: {ex.Message}");
}
catch (CellInvalidReferenceException ex)
{
    Console.Error.WriteLine($"Invalid cell reference: {ex.Message}");
}
catch (CellCircularReferenceException ex)
{
    Console.Error.WriteLine($"Circular reference: {ex.Message}");
}
catch (CellUnsupportedDataException ex)
{
    Console.Error.WriteLine($"Unsupported spreadsheet data: {ex.Message}");
}
```

## **Limitazioni pratiche**

Il supporto alle formule nei fogli di lavoro dei grafici è destinato a un sottoinsieme definito di calcoli di foglio, non a una piena compatibilità con Excel. Tenere presenti queste restrizioni durante la progettazione di un flusso di lavoro di reporting:

- Utilizzare solo le costanti, gli operatori, i riferimenti e le funzioni documentate quando si desidera che Aspose.Slides ricalcoli le formule.
- Ricalcolare dopo aver modificato le celle da cui dipendono i risultati delle formule.
- Considerare i valori nella cache delle presentazioni caricate come istantanee, non come sostituti del ricalcolo dopo modifiche.
- Testare le formule dei modelli esistenti prima di fare affidamento sui loro valori calcolati, specialmente se utilizzano funzioni non elencate.
- Per formule che richiedono un motore di calcolo completo, calcolarle esternamente e poi aggiornare il workbook del grafico con i valori risultanti.

## **FAQ**

**Qual è la differenza tra `Formula` e `R1C1Formula`?**

[Formula](https://reference.aspose.com/slides/it/net/aspose.slides.charts/ichartdatacell/formula/) memorizza un’espressione in stile A1 come `B2-C2`. [R1C1Formula](https://reference.aspose.com/slides/it/net/aspose.slides.charts/ichartdatacell/r1c1formula/) memorizza un’espressione in stile R1C1 come `RC[-2]-RC[-1]`. Utilizzare la notazione che meglio corrisponde al modo in cui si generano o copiano le formule.

**Devo leggere la cella stessa o il suo valore dopo il calcolo?**

[IChartDataWorkbook.GetCell](https://reference.aspose.com/slides/it/net/aspose.slides.charts/ichartdataworkbook/getcell/) restituisce un `IChartDataCell`. Per ottenere il risultato calcolato, leggere la proprietà [Value](https://reference.aspose.com/slides/it/net/aspose.slides.charts/ichartdatacell/value/) di quella cella dopo il ricalcolo.

**Quando devo chiamare `CalculateFormulas`?**

Chiamare [CalculateFormulas](https://reference.aspose.com/slides/it/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/) dopo aver modificato valori di input o formule e prima di dipendere dai risultati calcolati. Questo aggiorna i valori delle formule supportate dal valutatore integrato.

**Aspose.Slides supporta tutte le funzioni di Excel?**

No. Il valutatore integrato supporta un sottoinsieme documentato di funzioni. Le funzioni fuori da quel sottoinsieme non devono essere assunte come correttamente ricalcolate. Se è richiesta una piena compatibilità delle formule Excel, eseguire il calcolo con un motore di foglio di calcolo appropriato e scrivere i valori finali nel workbook del grafico.

** Cosa succede se una presentazione caricata contiene una formula non supportata?**

Se i dati del grafico non sono stati modificati, il workbook può ancora contenere un valore nella cache precedentemente calcolato. Dopo che i dati correlati sono stati modificati, quel valore nella cache potrebbe non essere più valido. Accedere a una cella la cui formula non può essere gestita può generare [CellUnsupportedDataException](https://reference.aspose.com/slides/it/net/aspose.slides.spreadsheet/cellunsupporteddataexception/).

**I valori di errore delle formule sono gli stessi delle eccezioni .NET?**

No. Un risultato come `#DIV/0!` è un valore di foglio prodotto da un calcolo valido. Le eccezioni come [CellInvalidFormulaException](https://reference.aspose.com/slides/it/net/aspose.slides.spreadsheet/cellinvalidformulaexception/) o [CellCircularReferenceException](https://reference.aspose.com/slides/it/net/aspose.slides.spreadsheet/cellcircularreferenceexception/) indicano che la formula non può essere elaborata normalmente.

**Un grafico si aggiorna automaticamente quando cambia una cella formula?**

Una serie del grafico può fare riferimento a celle del workbook. Ricalcolare prima il workbook, poi salvare o renderizzare la presentazione. Se i punti dati del grafico fanno riferimento alle celle calcolate, il grafico utilizza quei valori aggiornati; non è necessario un metodo di aggiornamento separato per questo flusso.

**I grafici possono usare un workbook Excel esterno?**

Sì, i dati del grafico possono essere configurati per usare un workbook esterno tramite l’API dei dati del grafico. Tuttavia, il flusso di lavoro di calcolo delle formule descritto in questo articolo riguarda il workbook dei dati del grafico e il sottoinsieme di formule valutato da Aspose.Slides. Non presumere che [CalculateFormulas](https://reference.aspose.com/slides/it/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/) fornisca un ricalcolo completo di formule arbitrarie in un file XLSX esterno.

**Posso usare formule che fanno riferimento a un altro foglio o workbook?**

I riferimenti in stile Excel possono esistere nei workbook dei grafici, ma la valutazione delle formule è limitata dal parser e dal set di funzioni supportati. Se un riferimento cross‑sheet o esterno è essenziale, verificare la formula esatta con la versione di Aspose.Slides in uso. Per flussi che richiedono ampia compatibilità di riferimenti Excel, calcolare il workbook esternamente e scrivere i valori risolti nei dati del grafico.

**Le stringhe di formula devono iniziare con `=`?**

Gli esempi dell’API Aspose.Slides assegnano espressioni come `B2-C2` o `SUM(B2:B5)` senza un `=` iniziale. Usare questa forma mantiene le formule generate coerenti con gli esempi documentati dell’API.
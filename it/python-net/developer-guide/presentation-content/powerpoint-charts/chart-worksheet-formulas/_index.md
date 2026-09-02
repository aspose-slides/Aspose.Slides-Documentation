---
title: Applica formule del foglio di lavoro dei grafici nelle presentazioni con Python
linktitle: Formule del foglio di lavoro
type: docs
weight: 70
url: /it/python-net/chart-worksheet-formulas/
keywords:
- foglio di calcolo del grafico
- foglio di lavoro del grafico
- formula del grafico
- formula del foglio di lavoro
- formula del foglio di calcolo
- cartella di lavoro dei dati del grafico
- calcolo della formula
- cultura preferita
- formula specifica della cultura
- DBCS
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
- Python
- Aspose.Slides
description: "Applica formule in stile Excel nei fogli di lavoro dei grafici di Aspose.Slides per Python via .NET, ricalcola i valori e utilizza i risultati nei grafici PowerPoint."
---
## **Panoramica**

I grafici di PowerPoint di solito memorizzano i dati di origine in un foglio di lavoro incorporato. In Aspose.Slides for Python via .NET, è possibile accedere a quel foglio di lavoro tramite la cartella di lavoro dei dati del grafico, scrivere valori di input, assegnare formule alle celle, calcolare le formule supportate e utilizzare le celle calcolate come dati del grafico.

Questo articolo spiega l’intero flusso di lavoro delle formule: creare un grafico, popolare il suo foglio di lavoro, assegnare formule in stile A1 o R1C1, ricalcolarle, leggere i valori calcolati, collegare quelle celle a una serie del grafico e salvare la presentazione. Descrive inoltre la sintassi delle formule supportate, il sottoinsieme di funzioni integrate, i valori memorizzati nella cache, le formule non supportate e gli errori specifici dei fogli di calcolo.

## **Fogli di lavoro dei grafici e formule**

Un foglio di lavoro di un grafico contiene le categorie, i nomi delle serie e i valori usati dal grafico. In PowerPoint, è possibile ispezionare il foglio di lavoro aprendo l’editor dei dati del grafico:

![Grafico PowerPoint con il foglio di lavoro incorporato aperto, che mostra i dati di categoria e di serie](chart-worksheet-formulas_1.png)

In Aspose.Slides, il foglio di lavoro è esposto tramite il [cartella di lavoro dei dati del grafico](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/ichartdataworkbook/). Utilizzare la proprietà [formula](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/ichartdatacell/formula/) per le formule in stile A1 e la proprietà [r1c1_formula](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/ichartdatacell/r1c1_formula/) per le formule in stile R1C1. Dopo aver modificato le celle di input o le formule, chiamare [calculate_formulas](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/) per ricalcolare le formule supportate e aggiornare i valori corrispondenti delle celle.

Una cella calcolata espone ancora il risultato tramite la proprietà [value](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/ichartdatacell/value/). Questo è importante quando è necessario ispezionare il risultato di una formula nel codice o usare la cella come punto dati del grafico.

## **Creare un grafico e calcolare le formule del foglio di lavoro**

L’esempio seguente dimostra un flusso di lavoro end‑to‑end. Crea un grafico a colonne raggruppate, cancella i dati di esempio, scrive i valori di fatturato e spese trimestrali, calcola il profitto con le formule, legge i risultati, usa le celle calcolate come valori del grafico e salva la presentazione.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 350)
    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()
    workbook.clear(worksheet_index)

    category1 = workbook.get_cell(worksheet_index, "A2", "Q1")
    category2 = workbook.get_cell(worksheet_index, "A3", "Q2")
    category3 = workbook.get_cell(worksheet_index, "A4", "Q3")

    workbook.get_cell(worksheet_index, "B1", "Revenue")
    workbook.get_cell(worksheet_index, "C1", "Expenses")
    workbook.get_cell(worksheet_index, "D1", "Profit")

    workbook.get_cell(worksheet_index, "B2").value = 120.0
    workbook.get_cell(worksheet_index, "C2").value = 80.0
    workbook.get_cell(worksheet_index, "B3").value = 150.0
    workbook.get_cell(worksheet_index, "C3").value = 95.0
    workbook.get_cell(worksheet_index, "B4").value = 135.0
    workbook.get_cell(worksheet_index, "C4").value = 110.0

    profit1 = workbook.get_cell(worksheet_index, "D2")
    profit2 = workbook.get_cell(worksheet_index, "D3")
    profit3 = workbook.get_cell(worksheet_index, "D4")

    profit1.formula = "B2-C2"
    profit2.formula = "B3-C3"
    profit3.formula = "B4-C4"

    workbook.calculate_formulas()

    q1_profit = profit1.value  # 40
    q2_profit = profit2.value  # 55
    q3_profit = profit3.value  # 25

    print(f"Q1 profit: {q1_profit}")
    print(f"Q2 profit: {q2_profit}")
    print(f"Q3 profit: {q3_profit}")

    chart.chart_data.categories.add(category1)
    chart.chart_data.categories.add(category2)
    chart.chart_data.categories.add(category3)

    profit_series = chart.chart_data.series.add(workbook.get_cell(worksheet_index, "D1"), chart.type)
    profit_series.data_points.add_data_point_for_bar_series(profit1)
    profit_series.data_points.add_data_point_for_bar_series(profit2)
    profit_series.data_points.add_data_point_for_bar_series(profit3)
    profit_series.labels.default_data_label_format.show_value = True

    presentation.save("chart-formulas.pptx", slides.export.SaveFormat.PPTX)
```

I punti dati del grafico fanno riferimento a `D2:D4`, quindi il grafico utilizza i valori di profitto calcolati. In questo flusso di lavoro non è necessario un richiamo separato al refresh del grafico: ricalcolare prima la cartella di lavoro, quindi usare o salvare i dati del grafico che puntano alle celle calcolate.

## **Usare formule in stile A1**

La notazione A1 identifica le colonne con lettere e le righe con numeri. Assegnare espressioni in stile A1 tramite [IChartDataCell.formula](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/ichartdatacell/formula/).

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 300)
    workbook = chart.chart_data.chart_data_workbook

    workbook.get_cell(0, "C3").value = 10
    workbook.get_cell(0, "F2").value = 2
    workbook.get_cell(0, "G2").value = 3
    workbook.get_cell(0, "H2").value = 4

    cell = workbook.get_cell(0, "A2")
    cell.formula = "C3+SUM(F2:H2)"

    workbook.calculate_formulas()

    value = cell.value  # 19
```

Le forme di riferimento A1 più comuni sono:

| Riferimento | Relativo | Assoluto | Misto |
|---|---|---|---|
| Cella | `A2` | `$A$2` | `A$2`, `$A2` |
| Riga | `2:2` | `$2:$2` | — |
| Colonna | `A:A` | `$A:$A` | — |
| Intervallo | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

I riferimenti relativi possono cambiare quando una formula viene spostata o copiata da un’applicazione di foglio di calcolo. I riferimenti assoluti mantengono fissi entrambi i coordinati, mentre i riferimenti misti fissano solo una riga o una colonna.

## **Usare formule in stile R1C1**

La notazione R1C1 identifica sia le righe sia le colonne in modo numerico. I riferimenti relativi usano offset tra parentesi quadre. Assegnare questa sintassi tramite [IChartDataCell.r1c1_formula](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/ichartdatacell/r1c1_formula/).

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 300)
    workbook = chart.chart_data.chart_data_workbook

    workbook.get_cell(0, "B2").value = 12
    workbook.get_cell(0, "C2").value = 5

    cell = workbook.get_cell(0, "D2")
    cell.r1c1_formula = "RC[-2]-RC[-1]"

    workbook.calculate_formulas()

    value = cell.value  # 7
```

Le forme di riferimento R1C1 più comuni sono:

| Riferimento | Relativo | Assoluto | Misto |
|---|---|---|---|
| Cella | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| Riga | `R[2]` | `R2` | — |
| Colonna | `C[3]` | `C3` | — |
| Intervallo | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

Ad esempio, nella cella `D2`, `RC[-2]` indica la cella nella stessa riga due colonne a sinistra (`B2`).

## **Costanti e operatori delle formule**

Il valutatore di formule integrato supporta valori logici, litterali numerici, stringhe, valori di errore del foglio di calcolo, operatori aritmetici e operatori di confronto.

### **Costanti e litterali**

| Tipo | Esempi | Note |
|---|---|---|
| Logico | `TRUE`, `FALSE` | Può essere usato direttamente in espressioni logiche come `A2=TRUE`. |
| Numerico | `1`, `0.5`, `.3`, `1E-2` | Sono supportate notazioni decimali e scientifiche. |
| Stringa | `"abc"`, `"2/3/2020 12:00"` | I litterali testuali sono racchiusi tra doppi apici all’interno della formula. |
| Risultato di errore | `#DIV/0!`, `#N/A`, `#REF!` | Una formula valida può valutare a un valore di errore del foglio di calcolo anziché a un risultato normale. |

Questo esempio utilizza diversi tipi di costante:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 300)
    workbook = chart.chart_data.chart_data_workbook

    workbook.get_cell(0, "A2").value = False
    workbook.get_cell(0, "B2").formula = "A2=TRUE"
    workbook.get_cell(0, "C2").formula = "1+0.5"
    workbook.get_cell(0, "D2").formula = ".3*1E-2"
    workbook.get_cell(0, "E2").formula = "\"abc\""
    workbook.get_cell(0, "F2").formula = "2/0"

    workbook.calculate_formulas()

    logical_value = workbook.get_cell(0, "B2").value  # Falso
    numeric_value = workbook.get_cell(0, "C2").value  # 1.5
    scientific_value = workbook.get_cell(0, "D2").value  # 0.003
    string_value = workbook.get_cell(0, "E2").value  # abc
    error_value = workbook.get_cell(0, "F2").value  # #DIV/0!
```

### **Operatori aritmetici**

| Operatore | Significato | Esempio |
|---|---|---|
| `+` | Addizione o segno più unario | `2+3` |
| `-` | Sottrazione o negazione | `2-3`, `-3` |
| `*` | Moltiplicazione | `2*3` |
| `/` | Divisione | `2/3` |
| `%` | Percentuale | `30%` |
| `^` | Esponenziazione | `2^3` |

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

Aspose.Slides include un valutatore di formule integrato per i fogli di lavoro dei grafici, ma non è un motore di calcolo completo di Excel. Il set di funzioni documentato è limitato a quelle elencate di seguito. Non supporre che una funzione arbitraria di Excel possa essere ricalcolata da [calculate_formulas](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/).

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

Le restrizioni indicate nella tabella sono significative: `INDEX` è documentato nella forma di riferimento, mentre `LOOKUP` e `MATCH` sono documentati nelle loro forme vettoriali. `DATE` utilizza il sistema data 1900. Le funzionalità e le funzioni non elencate qui dovrebbero essere considerate non supportate dal valutatore di formule di Aspose.Slides, salvo diversa documentazione.

## **Calcolare le formule con una cultura preferita**

Alcune funzioni della cartella di lavoro interpretano il testo secondo regole specifiche della cultura. Questo è particolarmente importante per le funzioni destinate a lingue che usano set di caratteri a doppio byte (DBCS). Per calcolare correttamente tali formule, creare un [LoadOptions](https://reference.aspose.com/slides/it/python-net/aspose.slides/loadoptions/), impostare [SpreadsheetOptions.preferred_culture](https://reference.aspose.com/slides/it/python-net/aspose.slides/spreadsheetoptions/) tramite [LoadOptions.spreadsheet_options](https://reference.aspose.com/slides/it/python-net/aspose.slides/loadoptions/spreadsheet_options/), quindi caricare la presentazione.

L’esempio seguente seleziona la cultura giapponese, apre una presentazione con le opzioni di caricamento configurate e chiama [ChartDataWorkbook.calculate_formulas](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/) per ogni cartella di lavoro del grafico:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

load_options = slides.LoadOptions()
load_options.spreadsheet_options.preferred_culture = "ja-JP"

with slides.Presentation("presentation.pptx", load_options) as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if isinstance(shape, charts.Chart):
                shape.chart_data.chart_data_workbook.calculate_formulas()
```

La cultura preferita fa parte della configurazione di caricamento della presentazione, quindi va specificata prima di creare l’istanza di [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/). Utilizzare la cultura attesa dalle formule della cartella di lavoro; ad esempio, usare `ja-JP` per formule che devono seguire le regole di calcolo DBCS giapponesi.

## **Ricalcolo e valori memorizzati nella cache**

I file di foglio di calcolo memorizzano comunemente sia la formula sia il suo ultimo valore calcolato. Aspose.Slides può quindi leggere un valore memorizzato nella cache da [IChartDataCell.value](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/ichartdatacell/value/) quando una presentazione viene caricata e i dati del grafico pertinenti non sono stati modificati.

Dopo aver modificato le celle di input o le formule, non affidarsi a un risultato memorizzato nella cache obsoleto. Chiamare [ChartDataWorkbook.calculate_formulas](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/) prima di leggere i valori calcolati o di salvare i dati del grafico che dipendono da essi.

Per le formule al di fuori del sottoinsieme supportato, Aspose.Slides potrebbe non essere in grado di analizzare la formula o di stabilirne le dipendenze. Se la cartella di lavoro è stata modificata, il valore cache precedente non è più affidabile. In tal caso, la lettura del valore di una cella con dati non supportati può generare [CellUnsupportedDataException](https://reference.aspose.com/slides/it/python-net/aspose.slides.spreadsheet/cellunsupporteddataexception/).

Se il grafico dipende da funzioni di Excel che Aspose.Slides non valuta, calcolare quelle formule con un motore di foglio di calcolo che le supporti e scrivere i valori risultanti nel grafico. Non sostituire le formule non supportate con valori indovinati.

## **Gestire gli errori di formula**

Esistono due tipi di problemi da distinguere.

Una formula può essere valida ma produrre un risultato di errore del foglio di calcolo, ad esempio `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!` o `#VALUE!`. In questo caso, il token di errore è il risultato della cella e può essere restituito tramite `value`.

Una formula può anche fallire a livello di parsing, riferimento, dipendenza o dati supportati. Aspose.Slides fornisce eccezioni specifiche per questi casi: [CellInvalidFormulaException](https://reference.aspose.com/slides/it/python-net/aspose.slides.spreadsheet/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/it/python-net/aspose.slides.spreadsheet/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/it/python-net/aspose.slides.spreadsheet/cellcircularreferenceexception/), e [CellUnsupportedDataException](https://reference.aspose.com/slides/it/python-net/aspose.slides.spreadsheet/cellunsupporteddataexception/).

Quando le formule provengono da modelli o da input dell’utente, gestire queste eccezioni attorno al ricalcolo e all’accesso al valore:

```python
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.slides.spreadsheet as spreadsheet

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 300)
    workbook = chart.chart_data.chart_data_workbook
    cell = workbook.get_cell(0, "A2")
    cell.formula = "SUM(B2:B5)"

    try:
        workbook.calculate_formulas()
        print(cell.value)
    except spreadsheet.CellInvalidFormulaException as ex:
        print(f"Invalid formula: {ex}")
    except spreadsheet.CellInvalidReferenceException as ex:
        print(f"Invalid cell reference: {ex}")
    except spreadsheet.CellCircularReferenceException as ex:
        print(f"Circular reference: {ex}")
    except spreadsheet.CellUnsupportedDataException as ex:
        print(f"Unsupported spreadsheet data: {ex}")
```

## **Limitazioni pratiche**

Il supporto delle formule nei fogli di lavoro dei grafici è destinato a un sottoinsieme definito di calcoli di foglio di calcolo, non a una compatibilità completa con Excel. Tenere presenti queste restrizioni quando si progetta un flusso di lavoro di reporting:

- Utilizzare solo le costanti, gli operatori, i riferimenti e le funzioni documentate quando si desidera che Aspose.Slides ricalcoli le formule.
- Ricalcolare dopo aver modificato le celle da cui dipendono i risultati delle formule.
- Considerare i valori memorizzati nella cache delle presentazioni caricate come istantanee, non come sostituti del ricalcolo dopo modifiche.
- Testare le formule dei modelli esistenti prima di fare affidamento sui loro valori calcolati, soprattutto se usano funzioni al di fuori dell’elenco documentato.
- Per le formule che richiedono un motore di calcolo completo del foglio di calcolo, calcolarle esternamente e poi aggiornare il foglio di lavoro del grafico con i valori risultanti.

## **FAQ**

**Qual è la differenza tra `formula` e `r1c1_formula`?**

[formula](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/ichartdatacell/formula/) memorizza un’espressione in stile A1, ad esempio `B2-C2`. [r1c1_formula](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/ichartdatacell/r1c1_formula/) memorizza un’espressione in stile R1C1, ad esempio `RC[-2]-RC[-1]`. Utilizzare la notazione che meglio corrisponde al modo in cui si generano o copiano le formule.

**Devo leggere la cella stessa o il suo valore dopo il calcolo?**

[ChartDataWorkbook.get_cell](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/chartdataworkbook/get_cell/) restituisce un `IChartDataCell`. Per ottenere il risultato calcolato, leggere la proprietà [value](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/ichartdatacell/value/) di quella cella dopo il ricalcolo.

**Quando devo chiamare `calculate_formulas`?**

Chiamare [calculate_formulas](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/) dopo aver modificato valori di input o formule e prima di dipendere dai risultati calcolati. Questo aggiorna i valori delle formule supportate dal valutatore integrato.

**Aspose.Slides supporta tutte le funzioni di Excel?**

No. Il valutatore integrato supporta un sottoinsieme documentato di funzioni. Le funzioni al di fuori di quel sottoinsieme non devono essere considerate ricalcolabili correttamente. Se è necessaria la compatibilità completa con le formule di Excel, eseguire il calcolo con un motore di foglio di calcolo adeguato e scrivere i valori finali nella cartella di lavoro del grafico.

** Cosa succede se una presentazione caricata contiene una formula non supportata?**

Se i dati del grafico non sono stati modificati, la cartella di lavoro può ancora contenere un valore in cache calcolato in precedenza. Dopo che i dati correlati sono stati modificati, quel valore in cache potrebbe non essere più valido. L’accesso a una cella la cui formula non può essere gestita può generare [CellUnsupportedDataException](https://reference.aspose.com/slides/it/python-net/aspose.slides.spreadsheet/cellunsupporteddataexception/).

**I valori di errore delle formule sono gli stessi delle eccezioni Python?**

No. Un risultato come `#DIV/0!` è un valore di foglio di calcolo prodotto da un calcolo valido. Le eccezioni come [CellInvalidFormulaException](https://reference.aspose.com/slides/it/python-net/aspose.slides.spreadsheet/cellinvalidformulaexception/) o [CellCircularReferenceException](https://reference.aspose.com/slides/it/python-net/aspose.slides.spreadsheet/cellcircularreferenceexception/) indicano che la formula non può essere elaborata normalmente.

**Un grafico si aggiorna automaticamente quando una cella formula cambia?**

Una serie del grafico può fare riferimento a celle della cartella di lavoro. Ricalcolare prima la cartella di lavoro, quindi salvare o rendere la presentazione. Se i punti dati del grafico fanno riferimento alle celle calcolate, il grafico utilizza quei valori aggiornati; nessun metodo di refresh separato è richiesto per questo flusso di lavoro.

**I grafici possono usare una cartella di lavoro Excel esterna?**

Sì, i dati del grafico possono essere configurati per usare una cartella di lavoro esterna tramite l’API dei dati del grafico. Tuttavia, il flusso di lavoro di calcolo delle formule descritto in questo articolo riguarda la cartella di lavoro dei dati del grafico e il sottoinsieme di formule valutato da Aspose.Slides. Non presumere che [calculate_formulas](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/) fornisca un ricalcolo completo di formule arbitrary in un file XLSX esterno.

**Posso usare formule che fanno riferimento a un altro foglio o a un altro workbook?**

I riferimenti in stile Excel possono esistere nelle cartelle di lavoro dei grafici, ma la valutazione delle formule è limitata dal parser e dal set di funzioni supportate. Se è fondamentale un riferimento incrociato a foglio o a workbook esterno, verificare quella formula con la versione di Aspose.Slides in uso. Per i flussi di lavoro che richiedono ampia compatibilità dei riferimenti Excel, calcolare il workbook esternamente e scrivere i valori risolti nei dati del grafico.

**Le stringhe di formula devono iniziare con `=`?**

Gli esempi dell’API Aspose.Slides assegnano espressioni come `B2-C2` o `SUM(B2:B5)` senza il simbolo iniziale `=`. Usare questa forma mantiene le formule generate coerenti con gli esempi dell’API documentata.
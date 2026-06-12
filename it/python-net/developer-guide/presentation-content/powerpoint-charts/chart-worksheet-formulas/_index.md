---
title: Applica formule del foglio di lavoro del grafico nelle presentazioni con Python
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
- fonte dati
- costante logica
- costante numerica
- costante di stringa
- costante di errore
- costante aritmetica
- operatore di confronto
- stile A1
- stile R1C1
- funzione predefinita
- PowerPoint
- OpenDocument
- presentazione
- Python
- Aspose.Slides
description: "Applica formule in stile Excel in Aspose.Slides per Python tramite fogli di lavoro del grafico .NET e automatizza i report per file PPT, PPTX e ODP."
---
## **Panoramica**

Un foglio di lavoro del grafico è la sorgente dati dietro un grafico in una presentazione. Conserva i nomi delle categorie e delle serie insieme ai valori numerici visualizzati dal grafico. In Aspose.Slides, questo foglio di lavoro è disponibile tramite la cartella di lavoro dei dati del grafico, che consente di lavorare con i dati del grafico in modo programmatico.

Questo articolo spiega come utilizzare le formule nei fogli di lavoro dei dati del grafico in modo che i valori delle celle possano essere calcolati e aggiornati automaticamente invece di essere inseriti manualmente. Mostra come assegnare formule, utilizzare riferimenti in stile A1 e R1C1, ricalcolare le formule della cartella di lavoro e lavorare con le costanti, gli operatori, i riferimenti alle celle e le funzioni predefinite supportate per i fogli di lavoro dei grafici nelle presentazioni.

## **Informazioni sulla formula del foglio di calcolo del grafico nella presentazione**
**Foglio di calcolo del grafico** (o foglio di lavoro del grafico) in una presentazione è la sorgente dati del grafico. Il foglio di calcolo del grafico contiene i dati, che sono rappresentati nel grafico in modo grafico. Quando crei un grafico in PowerPoint, anche il foglio di lavoro associato a questo grafico viene creato automaticamente. Il foglio di lavoro del grafico viene creato per tutti i tipi di grafici: grafico a linee, a barre, a esplosione, a torta, ecc. Per visualizzare il foglio di calcolo del grafico in PowerPoint devi fare doppio clic sul grafico:

![todo:image_alt_text](chart-worksheet-formulas_1.png)



Il foglio di calcolo del grafico contiene i nomi degli elementi del grafico (Category Name: *Category1*, Serie Name) e una tabella con dati numerici appropriati a queste categorie e serie. Per impostazione predefinita, quando crei un nuovo grafico i dati del foglio di calcolo del grafico sono impostati con i dati predefiniti. Successivamente puoi modificare manualmente i dati del foglio di calcolo nel foglio di lavoro.

Di solito, il grafico rappresenta dati complessi (ad esempio analisi finanziarie, analisi scientifiche), con celle calcolate dai valori di altre celle o da altri dati dinamici. Calcolare manualmente il valore di una cella e codificarlo rigidamente nella cella rende difficile modificarlo in futuro. Se cambi il valore di una certa cella, tutte le celle dipendenti da essa dovranno essere aggiornate. Inoltre, i dati della tabella possono dipendere da dati di altre tabelle, creando uno schema di dati della presentazione complesso che deve essere aggiornato in modo semplice e flessibile.

**Formula del foglio di calcolo del grafico** in una presentazione è un'espressione per calcolare e aggiornare automaticamente i dati del foglio di calcolo del grafico. La formula definisce la logica di calcolo dei dati per una certa cella o un insieme di celle. Una formula è una formula matematica o logica, che utilizza: riferimenti a celle, funzioni matematiche, operatori logici, operatori aritmetici, funzioni di conversione, costanti di stringa, ecc. La definizione della formula è scritta in una cella, e questa cella non contiene un valore semplice. La formula calcola il valore e lo restituisce, quindi il valore viene assegnato alla cella. Le formule dei fogli di calcolo dei grafici nelle presentazioni sono in realtà le stesse delle formule di Excel, e vengono supportate le stesse funzioni, operatori e costanti predefinite per la loro implementazione.

In [**Aspose.Slides**](https://products.aspose.com/slides/it/python-net/) il foglio di calcolo del grafico è rappresentato con la proprietà [**Chart.ChartData.ChartDataWorkbook**](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/ichartdata/) del tipo [**IChartDataWorkbook**](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/ichartdataworkbook/). La formula del foglio di calcolo può essere assegnata e modificata con la proprietà [**formula**](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/ichartdatacell/). Le seguenti funzionalità sono supportate per le formule in Aspose.Slides:

- Costanti logiche
- Costanti numeriche
- Costanti di stringa
- Costanti di errore
- Operatori aritmetici
- Operatori di confronto
- Riferimenti alle celle in stile A1
- Riferimenti alle celle in stile R1C1
- Funzioni predefinite

In genere i fogli di calcolo memorizzano gli ultimi valori calcolati delle formule. Se, dopo il caricamento della presentazione, i dati del grafico non sono stati modificati, la proprietà **IChartDataCell.Value** restituisce quei valori durante la lettura. Ma, se i dati del foglio di calcolo sono stati modificati, durante la lettura la proprietà **ChartDataCell.Value** genera l'eccezione **CellUnsupportedDataException** per le formule non supportate. Questo avviene perché, quando le formule vengono analizzate correttamente, le dipendenze delle celle sono determinate e la correttezza degli ultimi valori è verificata. Se la formula non può essere analizzata, la correttezza del valore della cella non può essere garantita.

## **Aggiungere formula del foglio di calcolo del grafico alla presentazione**
Per prima cosa, aggiungi un grafico con alcuni dati di esempio alla prima diapositiva di una nuova presentazione con [add_chart](https://reference.aspose.com/slides/it/python-net/aspose.slides/ishapecollection/). Il foglio di lavoro del grafico è creato automaticamente e può essere accesso con la proprietà [**chart_data_workbook**](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/ichartdata/):

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 150, 150, 500, 300)
    workbook = chart.chart_data.chart_data_workbook
    # ...
```

Scriviamo alcuni valori nelle celle con la proprietà [**value**](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/ichartdatacell/) di tipo **Object**, il che significa che puoi impostare qualsiasi valore sulla proprietà:

```py
    workbook.get_cell(0, "F2").value = -2.5
    workbook.get_cell(0, "G3").value = 6.3
    workbook.get_cell(0, "H4").value = 3
```

Ora, per scrivere una formula nella cella, puoi utilizzare la proprietà [**formula**](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/ichartdatacell/):

```py
    workbook.get_cell(0, "B2").formula = "F2+G3+H4+1"
```

*Nota*: [**IChartDataCell.Formula**](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/ichartdatacell/) viene usata per impostare riferimenti a celle in stile A1.

Per impostare il riferimento di cella [r1c1_formula](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/ichartdatacell/) puoi usare la proprietà [**r1c1_formula**](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/ichartdatacell/):

```py
    workbook.get_cell(0, "C2").r1c1_formula = "R[1]C[4]/R[2]C[5]"
```

Quindi usa il metodo [**calculate_formulas**](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/chartdataworkbook/) per calcolare tutte le formule all'interno della cartella di lavoro e aggiornare i valori delle celle corrispondenti:

```py
    workbook.calculate_formulas()
    print(workbook.get_cell(0, "B2").value) # 7.8
    print(workbook.get_cell(0, "C2").value) # 2.1
```

## **Costanti logiche**
Puoi utilizzare costanti logiche come *FALSE* e *TRUE* nelle formule delle celle:

## **Costanti numeriche**
I numeri possono essere usati in notazioni comuni o scientifiche per creare formule del foglio di calcolo del grafico:

## **Costanti di stringa**
Una costante di stringa (o letterale) è un valore specifico che viene usato così com'è e non cambia. Le costanti di stringa possono essere: date, testi, numeri, ecc.:

## **Costanti di errore**
A volte non è possibile calcolare il risultato mediante la formula. In tal caso, nel posto del valore viene mostrato il codice di errore. Ogni tipo di errore ha un codice specifico:

- #DIV/0! - la formula tenta di dividere per zero.
- #GETTING_DATA - può comparire su una cella mentre il suo valore è ancora in calcolo.
- #N/A - informazioni mancanti o non disponibili. Alcune cause possono essere: le celle usate nella formula sono vuote, un carattere di spazio extra, errore di battitura, ecc.
- #NAME? - una certa cella o altri oggetti di formula non possono essere trovati per nome.
- #NULL! - può apparire quando c'è un errore nella formula, come:  (,) o un carattere di spazio usato al posto dei due punti (:).
- #NUM! - il numero nella formula può essere non valido, troppo lungo o troppo piccolo, ecc.
- #REF! - riferimento di cella non valido.
- #VALUE! - tipo di valore inatteso. Per esempio, un valore stringa impostato in una cella numerica.

## **Operatori aritmetici**
Puoi usare tutti gli operatori aritmetici nelle formule del foglio di lavoro del grafico:

|**Operatore**|**Significato**|**Esempio**|
| :- | :- | :- |
|+ (plus sign)|Addizione o segno più unario|2 + 3|
|- (minus sign)|Sottrazione o negazione|2 - 3<br>-3|
|* (asterisk)|Moltiplicazione|2 * 3|
|/ (forward slash)|Divisione|2 / 3|
|% (percent sign)|Percentuale|30%|
|^ (caret)|Elevamento a potenza|2 ^ 3|

*Nota*: Per modificare l'ordine di valutazione, racchiudi tra parentesi la parte della formula da calcolare per prima.

## **Operatori di confronto**
Puoi confrontare i valori delle celle con gli operatori di confronto. Quando due valori sono confrontati con questi operatori, il risultato è un valore logico *TRUE* o FALSE:

|**Operatore**|**Significato**|**Esempio**|
| :- | :- | :- |
|= (equal sign)|Uguale a|A2 = 3|
|<> (not equal sign)|Non uguale a|A2 <> 3|
|> (greater than sign)|Maggiore di|A2 > 3|
|>= (greater than or equal to sign)|Maggiore o uguale a|A2 >= 3|
|< (less than sign)|Minore di|A2 < 3|
|<= (less than or equal to sign)|Minore o uguale a|A2 <= 3|

## **Riferimenti alle celle in stile A1**
**I riferimenti alle celle in stile A1** sono usati per i fogli di lavoro, dove la colonna ha un identificatore alfabetico (ad es. "*A*") e la riga ha un identificatore numerico (ad es. "*1*"). I riferimenti in stile A1 possono essere usati nel seguente modo:

|**Riferimento cella**|**Esempio**|||
| :- | :- | :- | :- |
||Assoluto|Relativo|Misto|
|Cella|$A$2|A2|<p>A$2</p><p>$A2</p>|
|Riga|$2:$2|2:2|-|
|Colonna|$A:$A|A:A|-|
|Intervallo|$A$2:$C$4|A2:C4|<p>$A$2:C4</p><p>A$2:$C4</p>|

Ecco un esempio di come utilizzare un riferimento di cella in stile A1 nella formula:

## **Riferimenti alle celle in stile R1C1**
**I riferimenti alle celle in stile R1C1** sono usati per i fogli di lavoro, dove sia la riga sia la colonna hanno identificatori numerici. I riferimenti in stile R1C1 possono essere usati nel seguente modo:

|**Riferimento cella**|**Esempio**|||
| :- | :- | :- | :- |
||Assoluto|Relativo|Misto|
|Cella|R2C3|R[2]C[3]|R2C[3]<br>R[2]C3|
|Riga|R2|R[2]|-|
|Colonna|C3|C[3]|-|
|Intervallo|R2C3:R5C7|R[2]C[3]:R[5]C[7]|R2C3:R[5]C[7]<br>R[2]C3:R5C[7]|

Ecco un esempio di come utilizzare un riferimento di cella in stile R1C1 nella formula:

## **Funzioni predefinite**
Esistono funzioni predefinite che possono essere usate nelle formule per semplificarne l'implementazione. Queste funzioni racchiudono le operazioni più comunemente usate, come:

- ABS
- AVERAGE
- CEILING
- CHOOSE
- CONCAT
- CONCATENATE
- DATE (sistema date 1900)
- DAYS
- FIND
- FINDB
- IF
- INDEX (forma di riferimento)
- LOOKUP (forma vettoriale)
- MATCH (forma vettoriale)
- MAX
- SUM
- VLOOKUP

## **FAQ**

**I file Excel esterni sono supportati come sorgente dati per un grafico con formule?**

Sì. Aspose.Slides supporta cartelle di lavoro esterne come [sorgente dati del grafico](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/chartdatasourcetype/), permettendo di utilizzare formule da un file XLSX esterno alla presentazione.

**Le formule del grafico possono fare riferimento a fogli all'interno della stessa cartella di lavoro per nome foglio?**

Sì. Le formule seguono il modello di riferimento standard di Excel, quindi puoi fare riferimento ad altri fogli nella stessa cartella di lavoro o in una cartella di lavoro esterna. Per riferimenti esterni, includi il percorso e il nome della cartella di lavoro usando la sintassi di Excel.
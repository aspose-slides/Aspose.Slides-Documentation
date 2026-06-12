---
title: Applicare le formule dei fogli di lavoro dei grafici nelle presentazioni in .NET
linktitle: Formule del foglio di lavoro
type: docs
weight: 70
url: /it/net/chart-worksheet-formulas/
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
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Applicare formule in stile Excel in Aspose.Slides per i fogli di lavoro dei grafici .NET e automatizzare i report nei file PPT e PPTX."
---
## **Panoramica**

Un foglio di lavoro del grafico è la fonte dati dietro un grafico in una presentazione. Memorizza i nomi delle categorie e delle serie insieme ai valori numerici visualizzati dal grafico. In Aspose.Slides, questo foglio di lavoro è disponibile tramite la cartella di lavoro dei dati del grafico, che consente di lavorare con i dati del grafico in modo programmatico.

Questo articolo spiega come utilizzare le formule del foglio di lavoro nei dati del grafico in modo che i valori delle celle possano essere calcolati e aggiornati automaticamente anziché inseriti manualmente. Mostra come assegnare formule, utilizzare riferimenti in stile A1 e R1C1, ricalcolare le formule della cartella di lavoro e lavorare con le costanti, gli operatori, i riferimenti alle celle e le funzioni predefinite supportate per i fogli di lavoro dei grafici nelle presentazioni.

## **Informazioni sulle formule del foglio di calcolo dei grafici nelle presentazioni**
Il **foglio di calcolo del grafico** (o foglio di lavoro del grafico) in una presentazione è la fonte dati del grafico. Il foglio di calcolo del grafico contiene i dati, che sono rappresentati nel grafico in modo grafico. Quando si crea un grafico in PowerPoint, il foglio di lavoro associato a quel grafico viene creato automaticamente. Il foglio di lavoro del grafico è creato per tutti i tipi di grafici: grafico a linee, a barre, a irradiazione (sunburst), a torta, ecc. Per vedere il foglio di calcolo del grafico in PowerPoint è necessario fare doppio clic sul grafico:

![todo:image_alt_text](chart-worksheet-formulas_1.png)

Il foglio di calcolo del grafico contiene i nomi degli elementi del grafico (Nome categoria: *Category1*, Nome serie) e una tabella con dati numerici appropriati a queste categorie e serie. Per impostazione predefinita, quando si crea un nuovo grafico, i dati del foglio di calcolo del grafico sono impostati con i dati predefiniti. Successivamente è possibile modificare manualmente i dati del foglio di calcolo nel foglio di lavoro.

Di solito il grafico rappresenta dati complessi (ad es. analisi finanziarie, analisi scientifiche), con celle calcolate a partire dai valori di altre celle o da altri dati dinamici. Calcolare manualmente il valore di una cella e codificarlo direttamente nella cella rende difficile modificarlo in futuro. Se si modifica il valore di una certa cella, tutte le celle dipendenti da essa dovranno essere aggiornate. Inoltre, i dati della tabella possono dipendere da dati di altre tabelle, creando uno schema di dati della presentazione complesso che deve poter essere aggiornato in modo semplice e flessibile.

Una **formula del foglio di calcolo del grafico** nella presentazione è un'espressione per calcolare e aggiornare automaticamente i dati del foglio di calcolo del grafico. La formula del foglio di calcolo definisce la logica di calcolo dei dati per una certa cella o un insieme di celle. È una formula matematica o logica, che utilizza: riferimenti a celle, funzioni matematiche, operatori logici, operatori aritmetici, funzioni di conversione, costanti di stringa, ecc. La definizione della formula è scritta in una cella, e questa cella non contiene un valore semplice. La formula del foglio di calcolo calcola il valore e lo restituisce, quindi questo valore viene assegnato alla cella. Le formule del foglio di calcolo dei grafici nelle presentazioni sono in realtà le stesse delle formule di Excel, e sono supportate le stesse funzioni predefinite, operatori e costanti per la loro implementazione.

In [**Aspose.Slides**](https://products.aspose.com/slides/it/net/) il foglio di calcolo del grafico è rappresentato con la proprietà [**Chart.ChartData.ChartDataWorkbook**](https://reference.aspose.com/slides/it/net/aspose.slides.charts/ichartdata/properties/chartdataworkbook) del tipo [**IChartDataWorkbook**](https://reference.aspose.com/slides/it/net/aspose.slides.charts/ichartdataworkbook). La formula del foglio di calcolo può essere assegnata e modificata con la proprietà [**IChartDataCell.Formula**](https://reference.aspose.com/slides/it/net/aspose.slides.charts/ichartdatacell/properties/formula). Le seguenti funzionalità sono supportate per le formule in Aspose.Slides:

- Costanti logiche
- Costanti numeriche
- Costanti di stringa
- Costanti di errore
- Operatori aritmetici
- Operatori di confronto
- Riferimenti a celle in stile A1
- Riferimenti a celle in stile R1C1
- Funzioni predefinite

Tipicamente i fogli di calcolo memorizzano gli ultimi valori calcolati delle formule. Se, dopo il caricamento della presentazione, i dati del grafico non sono stati modificati, la proprietà **IChartDataCell.Value** restituisce tali valori durante la lettura. Ma, se i dati del foglio di calcolo sono stati modificati, durante la lettura la proprietà **ChartDataCell.Value** genera l'eccezione **CellUnsupportedDataException** per le formule non supportate. Ciò avviene perché, quando le formule sono analizzate con successo, le dipendenze delle celle vengono determinate e si verifica la correttezza degli ultimi valori. Se la formula non può essere analizzata, la correttezza del valore della cella non può essere garantita.

## **Aggiungere una formula del foglio di calcolo del grafico a una presentazione**
Per prima cosa, aggiungere un grafico con alcuni dati di esempio alla prima diapositiva di una nuova presentazione con [IShapeCollection.Shapes.AddChart](https://reference.aspose.com/slides/it/net/aspose.slides.ishapecollection/addchart/methods/1). Il foglio di lavoro del grafico viene creato automaticamente e può essere accessibile con la proprietà [**Chart.ChartData.ChartDataWorkbook**](https://reference.aspose.com/slides/it/net/aspose.slides.charts/ichartdata/properties/chartdataworkbook):

``` csharp

using (var presentation = new Presentation())

{
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 150, 150, 500, 300);
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    // ...
}
```

Scriviamo alcuni valori nelle celle con la proprietà [**IChartDataCell.Value**](https://reference.aspose.com/slides/it/net/aspose.slides.charts/ichartdatacell/properties/value) di tipo **Object**, il che significa che è possibile impostare qualsiasi valore nella proprietà:

``` csharp

workbook.GetCell(0, "F2").Value = -2.5;

workbook.GetCell(0, "G3").Value = 6.3;

workbook.GetCell(0, "H4").Value = 3;

```

Ora, per scrivere una formula nella cella, è possibile utilizzare la proprietà [**IChartDataCell.Formula**](https://reference.aspose.com/slides/it/net/aspose.slides.charts/ichartdatacell/properties/formula):

``` csharp
workbook.GetCell(0, "B2").Formula = "F2+G3+H4+1";
```

*Nota*: la proprietà [**IChartDataCell.Formula**](https://reference.aspose.com/slides/it/net/aspose.slides.charts/ichartdatacell/properties/formula) viene utilizzata per impostare riferimenti a celle in stile A1.

Per impostare il riferimento alla cella [R1C1Formula](https://reference.aspose.com/slides/it/net/aspose.slides.charts/ichartdatacell/properties/r1c1formula), è possibile usare la proprietà [**IChartDataCell.R1C1Formula**](https://reference.aspose.com/slides/it/net/aspose.slides.charts/ichartdatacell/properties/r1c1formula):

``` csharp
workbook.GetCell(0, "C2").R1C1Formula = "R[1]C[4]/R[2]C[5]";
```

Quindi utilizzare il metodo [**IChartDataWorkbook.CalculateFormulas**](https://reference.aspose.com/slides/it/net/aspose.slides.charts/chartdataworkbook/methods/calculateformulas) per calcolare tutte le formule all'interno della cartella di lavoro e aggiornare i valori corrispondenti delle celle:

``` csharp
workbook.CalculateFormulas();

object value1 = workbook.GetCell(0, "B2"); // 7.8

object value2 = workbook.GetCell(0, "C2"); // 2.1

```

## **Costanti logiche**
È possibile utilizzare costanti logiche come *FALSE* e *TRUE* nelle formule delle celle:

## **Costanti numeriche**
I numeri possono essere utilizzati in notazione comune o scientifica per creare una formula del foglio di calcolo del grafico:

## **Costanti di stringa**
Una costante di stringa (o letterale) è un valore specifico che viene usato così com'è e non cambia. Le costanti di stringa possono essere: date, testi, numeri, ecc.:

## **Costanti di errore**
A volte non è possibile calcolare il risultato della formula. In tal caso, nel punto della cella viene mostrato il codice di errore anziché il valore. Ogni tipo di errore ha un codice specifico:

- #DIV/0! – la formula tenta di dividere per zero.
- #GETTING_DATA – può essere mostrato su una cella mentre il suo valore è ancora in calcolo.
- #N/A – l'informazione è mancante o non disponibile. Alcune cause possono essere: le celle usate nella formula sono vuote, un carattere di spazio extra, un errore di ortografia, ecc.
- #NAME? – una certa cella o altri oggetti della formula non possono essere trovati col loro nome.
- #NULL! – può apparire quando c'è un errore nella formula, ad esempio: (,) o un carattere di spazio usato al posto dei due punti (:).
- #NUM! – il valore numerico nella formula può essere non valido, troppo lungo o troppo piccolo, ecc.
- #REF! – riferimento a cella non valido.
- #VALUE! – tipo di valore inatteso. Per esempio, un valore di stringa impostato in una cella numerica.

## **Operatori aritmetici**
È possibile utilizzare tutti gli operatori aritmetici nelle formule del foglio di lavoro del grafico:

|**Operatore**|**Significato**|**Esempio**|
| :- | :- | :- |
|+ (segno più)|Addizione o segno più unario|2 + 3|
|- (segno meno)|Sottrazione o negazione|2 - 3<br>-3|
|* (asterisco)|Moltiplicazione|2 * 3|
|/ (barra verticale)|Divisione|2 / 3|
|% (percentuale)|Percentuale|30%|
|^ (caret)|Esponenziazione|2 ^ 3|

*Nota*: per modificare l'ordine di valutazione, racchiudere tra parentesi la parte della formula da calcolare per prima.

## **Operatori di confronto**
È possibile confrontare i valori delle celle con gli operatori di confronto. Quando due valori sono confrontati utilizzando questi operatori, il risultato è un valore logico *TRUE* o *FALSE*:

|**Operatore**|**Significato**|**Esempio**|
| :- | :- | :- |
|= (uguale)|Uguale a|A2 = 3|
|<> (diverso)|Diverso da|A2 <> 3|
|> (maggiore)|Maggiore di|A2 > 3|
|>= (maggiore o uguale)|Maggiore o uguale a|A2 >= 3|
|< (minore)|Minore di|A2 < 3|
|<= (minore o uguale)|Minore o uguale a|A2 <= 3|

## **Riferimenti a celle in stile A1**
I **riferimenti a celle in stile A1** sono usati per i fogli di lavoro, dove la colonna ha un identificatore alfabetico (es. "*A*") e la riga ha un identificatore numerico (es. "*1*"). I riferimenti a celle in stile A1 possono essere usati nel modo seguente:

|**Riferimento cella**|**Esempio**| | |
| :- | :- | :- | :- |
| |Assoluto|Relativo|Misto|
|Cella|$A$2|A2|<p>A$2</p><p>$A2</p>|
|Riga|$2:$2|2:2|-|
|Colonna|$A:$A|A:A|-|
|Intervallo|$A$2:$C$4|A2:C4|<p>$A$2:C4</p><p>A$2:$C4</p>|

Ecco un esempio di utilizzo di un riferimento a cella in stile A1 nella formula:

## **Riferimenti a celle in stile R1C1**
I **riferimenti a celle in stile R1C1** sono usati per i fogli di lavoro, dove sia riga che colonna hanno un identificatore numerico. I riferimenti a celle in stile R1C1 possono essere usati nel modo seguente:

|**Riferimento cella**|**Esempio**| | |
| :- | :- | :- | :- |
| |Assoluto|Relativo|Misto|
|Cella|R2C3|R[2]C[3]|R2C[3]<br>R[2]C3|
|Riga|R2|R[2]|-|
|Colonna|C3|C[3]|-|
|Intervallo|R2C3:R5C7|R[2]C[3]:R[5]C[7]|R2C3:R[5]C[7]<br>R[2]C3:R5C[7]|

Ecco un esempio di utilizzo di un riferimento a cella in stile R1C1 nella formula:

## **Funzioni predefinite**
Esistono funzioni predefinite che possono essere usate nelle formule per semplificarne l'implementazione. Queste funzioni incapsulano le operazioni più comunemente usate, come:

- ABS
- AVERAGE
- CEILING
- CHOOSE
- CONCAT
- CONCATENATE
- DATE (sistema data 1900)
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

**I file Excel esterni sono supportati come fonte dati per un grafico con formule?**

Sì. Aspose.Slides supporta cartelle di lavoro esterne come [fonte dati del grafico](https://reference.aspose.com/slides/it/net/aspose.slides.charts/chartdatasourcetype/), consentendo di utilizzare formule da un file XLSX al di fuori della presentazione.

**Le formule del grafico possono fare riferimento a fogli all'interno della stessa cartella di lavoro per nome foglio?**

Sì. Le formule seguono il modello di riferimento standard di Excel, quindi è possibile riferirsi ad altri fogli nella stessa cartella di lavoro o in una cartella di lavoro esterna. Per i riferimenti esterni, includere il percorso e il nome della cartella di lavoro usando la sintassi di Excel.
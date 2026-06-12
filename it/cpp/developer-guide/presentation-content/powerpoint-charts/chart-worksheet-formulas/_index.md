---
title: Applica le formule del foglio di lavoro del grafico nelle presentazioni usando C++
linktitle: Formule del foglio di lavoro
type: docs
weight: 70
url: /it/cpp/chart-worksheet-formulas/
keywords:
- foglio di calcolo del grafico
- foglio di lavoro del grafico
- formula del grafico
- formula del foglio di lavoro
- formula del foglio di calcolo
- fonte dati
- costante logica
- costante numerica
- costante stringa
- costante di errore
- costante aritmetica
- operatore di confronto
- stile A1
- stile R1C1
- funzione predefinita
- PowerPoint
- presentazione
- C++
- Aspose.Slides
description: "Applica formule in stile Excel in Aspose.Slides per i fogli di lavoro dei grafici C++ e automatizza i report nei file PPT e PPTX."
---
## **Panoramica**

Un foglio di lavoro del grafico è la fonte di dati dietro un grafico in una presentazione. Memorizza i nomi delle categorie e delle serie insieme ai valori numerici visualizzati dal grafico. In Aspose.Slides, questo foglio è disponibile tramite il chart data workbook, che consente di lavorare con i dati del grafico in modo programmatico.

Questo articolo spiega come utilizzare le formule del foglio di lavoro nei dati del grafico in modo che i valori delle celle possano essere calcolati e aggiornati automaticamente anziché inseriti manualmente. Mostra come assegnare formule, utilizzare riferimenti sia in stile A1 che in stile R1C1, ricalcolare le formule del workbook e lavorare con le costanti, gli operatori, i riferimenti di cella e le funzioni predefinite supportate per i fogli di lavoro dei grafici nelle presentazioni.

## **Informazioni sulle formule del foglio di calcolo del grafico nelle presentazioni**
**Il foglio di calcolo del grafico** (o foglio di lavoro del grafico) in una presentazione è la fonte di dati del grafico. Il foglio di calcolo del grafico contiene i dati, che sono rappresentati nel grafico in modo grafico. Quando crei un grafico in PowerPoint, il foglio associato a questo grafico viene creato automaticamente. Il foglio di lavoro del grafico è creato per tutti i tipi di grafico: grafico a linee, a barre, sunburst, a torta, ecc. Per visualizzare il foglio di calcolo del grafico in PowerPoint devi fare doppio clic sul grafico:

![todo:image_alt_text](chart-worksheet-formulas_1.png)

Il foglio di calcolo del grafico contiene i nomi degli elementi del grafico (Nome categoria: *Category1*, Nome serie) e una tabella con dati numerici appropriati a queste categorie e serie. Per impostazione predefinita, quando crei un nuovo grafico, i dati del foglio di calcolo del grafico sono impostati con i dati predefiniti. Successivamente è possibile modificare manualmente i dati del foglio di lavoro.

Di solito, il grafico rappresenta dati complessi (ad es. analisi finanziarie, analisi scientifiche), con celle calcolate a partire dai valori di altre celle o da altri dati dinamici. Calcolare manualmente il valore di una cella e inserirlo in modo statico rende difficile modificarlo in futuro. Se cambi il valore di una certa cella, tutte le celle dipendenti da essa richiederanno un aggiornamento. Inoltre, i dati della tabella possono dipendere da quelli di altre tabelle, creando uno schema di dati della presentazione complesso che deve essere aggiornato in modo semplice e flessibile.

**Una formula del foglio di calcolo del grafico** in una presentazione è un’espressione per calcolare e aggiornare automaticamente i dati del foglio di calcolo del grafico. La formula definisce la logica di calcolo dei dati per una certa cella o un insieme di celle. La formula è una formula matematica o logica, che utilizza: riferimenti di cella, funzioni matematiche, operatori logici, operatori aritmetici, funzioni di conversione, costanti stringa, ecc. La definizione della formula è scritta in una cella, e questa cella non contiene un valore semplice. La formula calcola il valore e lo restituisce, quindi questo valore viene assegnato alla cella. Le formule del foglio di calcolo del grafico nelle presentazioni sono in realtà le stesse delle formule di Excel, e sono supportate le stesse funzioni predefinite, operatori e costanti per la loro implementazione.

In [**Aspose.Slides**](https://products.aspose.com/slides/it/cpp/) il foglio di calcolo del grafico è rappresentato con il metodo [**ChartData::get_ChartDataWorkbook()**](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.charts.chart_data#a32097093561723a10df0a57dc91acaea) del tipo [**IChartDataWorkbook**](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.charts.i_chart_data_workbook). La formula può essere assegnata e modificata con il metodo [**IChartDataCell::set_Formula()**](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.charts.i_chart_data_cell#a6806c6a40e025e6834c4c5f3af3cf692). Le seguenti funzionalità sono supportate per le formule in Aspose.Slides:

- Costanti logiche
- Costanti numeriche
- Costanti stringa
- Costanti di errore
- Operatori aritmetici
- Operatori di confronto
- Riferimenti di cella in stile A1
- Riferimenti di cella in stile R1C1
- Funzioni predefinite

Tipicamente, i fogli di lavoro memorizzano gli ultimi valori calcolati delle formule. Se dopo il caricamento della presentazione i dati del grafico non sono stati modificati, il metodo **IChartDataCell.get_Value()** restituisce quei valori durante la lettura. Tuttavia, se i dati del foglio di lavoro sono stati modificati, durante la lettura il metodo **ChartDataCell.get_Value()** genera l’eccezione **CellUnsupportedDataException** per le formule non supportate. Ciò avviene perché quando le formule vengono analizzate correttamente, le dipendenze delle celle vengono determinate e la correttezza degli ultimi valori viene verificata. Se la formula non può essere analizzata, la correttezza del valore della cella non può essere garantita.

## **Aggiungere una formula del foglio di calcolo del grafico a una presentazione**
Per prima cosa, aggiungi un grafico alla prima diapositiva di una nuova presentazione con [IShapeCollection::AddChart()](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.i_shape_collection#a2cd4d47fc5c536012ee15b3a69486374). Il foglio di lavoro del grafico viene creato automaticamente e può essere accesso con il metodo [**ChartData::get_ChartDataWorkbook()**](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.charts.chart_data#a32097093561723a10df0a57dc91acaea):

``` cpp
auto presentation = System::MakeObject<Presentation>();
    
auto chart = presentation->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::ClusteredColumn, 150.0f, 150.0f, 500.0f, 300.0f);
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();

// ...
```

Scriviamo alcuni valori nelle celle con il metodo [**IChartDataCell.set_Value()**](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.charts.i_chart_data_cell#ad85809f520195e09225abae9002635ec) del tipo **Object**, il che significa che puoi passare qualsiasi valore al metodo:

``` cpp
workbook->GetCell(0, u"F2")->set_Value(System::ObjectExt::Box<double>(-2.5));
workbook->GetCell(0, u"G3")->set_Value(System::ObjectExt::Box<double>(6.3));
workbook->GetCell(0, u"H4")->set_Value(System::ObjectExt::Box<int32_t>(3));
```

Ora, per scrivere una formula nella cella, puoi utilizzare il metodo [**IChartDataCell::set_Formula()**](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.charts.i_chart_data_cell#a6806c6a40e025e6834c4c5f3af3cf692):

*Nota*: il metodo [**IChartDataCell::set_Formula()**](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.charts.i_chart_data_cell#a6806c6a40e025e6834c4c5f3af3cf692) viene usato per impostare riferimenti di cella in stile A1.

Per impostare il riferimento di cella **R1C1Formula**, puoi utilizzare il metodo [**IChartDataCell::set_R1C1Formula()**](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.charts.i_chart_data_cell#a47f5825dd38d0dddb11ecc3a43d388c7):

``` cpp
auto value1 = cell1->get_Value(); // 7.8
auto value2 = cell2->get_Value(); // 2.1
```

## **Costanti logiche**
Puoi utilizzare costanti logiche come *FALSE* e *TRUE* nelle formule delle celle:

## **Costanti numeriche**
I numeri possono essere usati in notazione comune o scientifica per creare una formula del foglio di calcolo del grafico:

## **Costanti stringa**
Una costante stringa (o letterale) è un valore specifico che viene utilizzato così com’è e non cambia. Le costanti stringa possono essere: date, testi, numeri, ecc.:

## **Costanti di errore**
A volte non è possibile calcolare il risultato mediante la formula. In tal caso, nel posto del valore viene mostrato il codice di errore. Ogni tipo di errore ha un codice specifico:

- #DIV/0! - la formula tenta di dividere per zero.
- #GETTING_DATA - può apparire in una cella mentre il suo valore è ancora in calcolo.
- #N/A - l’informazione è mancante o non disponibile. Alcune cause possono essere: le celle usate nella formula sono vuote, un carattere di spazio extra, errori di battitura, ecc.
- #NAME? - una certa cella o altri oggetti della formula non possono essere trovati per nome.
- #NULL! - può comparire quando c’è un errore nella formula, ad esempio: (,) o un carattere di spazio usato al posto dei due punti (:).
- #NUM! - il valore numerico nella formula può essere non valido, troppo lungo o troppo piccolo, ecc.
- #REF! - riferimento di cella non valido.
- #VALUE! - tipo di valore inaspettato. Per esempio, valore stringa assegnato a una cella numerica.

## **Operatori aritmetici**
Puoi utilizzare tutti gli operatori aritmetici nelle formule del foglio di lavoro del grafico:

|**Operatore**|**Significato**|**Esempio**|
| :- | :- | :- |
|+ (segno più)|Addizione o segno più unario|2 + 3|
|- (segno meno)|Sottrazione o negazione|2 - 3<br>-3|
|* (asterisco)|Moltiplicazione|2 * 3|
|/ (barra obliqua)|Divisione|2 / 3|
|% (segno percentuale)|Percentuale|30%|
|^ (caret)|Elevamento a potenza|2 ^ 3|

*Nota*: per modificare l’ordine di valutazione, racchiudi tra parentesi la parte della formula da calcolare per prima.

## **Operatori di confronto**
Puoi confrontare i valori delle celle con gli operatori di confronto. Quando due valori sono confrontati con questi operatori, il risultato è un valore logico *TRUE* o *FALSE*:

|**Operatore**|**Significato**|**Esempio**|
| :- | :- | :- |
|= (segno uguale)|Uguale a|A2 = 3|
|<> (segno diverso)|Diverso da|A2 <> 3|
|> (segno maggiore)|Maggiore di|A2 > 3|
|>= (segno maggiore o uguale)|Maggiore o uguale a|A2 >= 3|
|< (segno minore)|Minore di|A2 < 3|
|<= (segno minore o uguale)|Minore o uguale a|A2 <= 3|

## **Riferimenti di cella in stile A1**
**I riferimenti di cella in stile A1** sono utilizzati per i fogli di lavoro, dove la colonna ha un identificatore alfabetico (ad es. "*A*") e la riga ha un identificatore numerico (ad es. "*1*"). I riferimenti in stile A1 possono essere usati nel modo seguente:

|**Riferimento di cella**|**Esempio**|||
| :- | :- | :- | :- |
||Assoluto|Relativo|Misto|
|Cella|$A$2|A2|<p>A$2</p><p>$A2</p>|
:Riga|$2:$2|2:2|-|
:Colonna|$A:$A|A:A|-|
:Intervallo|$A$2:$C$4|A2:C4|<p>$A$2:C4</p><p>A$2:$C4</p>|

Ecco un esempio di utilizzo di un riferimento di cella in stile A1 nella formula:

## **Riferimenti di cella in stile R1C1**
**I riferimenti di cella in stile R1C1** sono utilizzati per i fogli di lavoro, dove sia riga che colonna hanno identificatore numerico. I riferimenti in stile R1C1 possono essere usati nel modo seguente:

|**Riferimento di cella**|**Esempio**|||
| :- | :- | :- | :- |
||Assoluto|Relativo|Misto|
|Cella|R2C3|R[2]C[3]|R2C[3]<br>R[2]C3|
:Riga|R2|R[2]|-|
:Colonna|C3|C[3]|-|
:Intervallo|R2C3:R5C7|R[2]C[3]:R[5]C[7]|R2C3:R[5]C[7]<br>R[2]C3:R5C[7]|

Ecco un esempio di utilizzo di un riferimento di cella in stile R1C1 nella formula:

## **Funzioni predefinite**
Esistono funzioni predefinite che possono essere utilizzate nelle formule per semplificarne l’implementazione. Queste funzioni incapsulano le operazioni più comunemente usate, come:

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

**I file Excel esterni sono supportati come fonte di dati per un grafico con formule?**

Sì. Aspose.Slides supporta workbook esterni come [fonte dati del grafico](https://reference.aspose.com/slides/it/cpp/aspose.slides.charts/chartdatasourcetype/), consentendo di utilizzare formule da un file XLSX al di fuori della presentazione.

**Le formule del grafico possono fare riferimento a fogli all’interno dello stesso workbook per nome del foglio?**

Sì. Le formule seguono il modello di riferimento standard di Excel, quindi è possibile fare riferimento ad altri fogli nello stesso workbook o in un workbook esterno. Per i riferimenti esterni, includi il percorso e il nome del workbook usando la sintassi di Excel.
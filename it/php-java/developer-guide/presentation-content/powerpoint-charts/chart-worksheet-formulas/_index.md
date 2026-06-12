---
title: Applicare le formule del foglio di lavoro del grafico nelle presentazioni usando PHP
linktitle: Formule del foglio di lavoro
type: docs
weight: 70
url: /it/php-java/chart-worksheet-formulas/
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
- PHP
- Aspose.Slides
description: "Applica formule in stile Excel in Aspose.Slides per PHP tramite fogli di lavoro del grafico Java e automatizza i report nei file PPT e PPTX."
---
## **Panoramica**

Un foglio di lavoro del grafico è la fonte dei dati alla base di un grafico in una presentazione. Memorizza i nomi di categorie e serie insieme ai valori numerici visualizzati dal grafico. In Aspose.Slides, questo foglio è disponibile tramite il workbook dei dati del grafico, che consente di lavorare con i dati del grafico in modo programmatico.

Questo articolo spiega come utilizzare le formule nei fogli di lavoro dei grafici in modo che i valori delle celle possano essere calcolati e aggiornati automaticamente anziché inseriti manualmente. Mostra come assegnare formule, utilizzare riferimenti in stile A1 e R1C1, ricalcolare le formule del workbook e lavorare con le costanti, gli operatori, i riferimenti alle celle e le funzioni predefinite supportate per i fogli di lavoro dei grafici nelle presentazioni.

## **Informazioni sulle formule dei fogli di calcolo dei grafici nelle presentazioni**
**Foglio di calcolo del grafico** (o foglio di lavoro del grafico) in una presentazione è la fonte dei dati del grafico. Il foglio di calcolo contiene i dati, che vengono rappresentati graficamente nel grafico. Quando si crea un grafico in PowerPoint, il foglio associato a quel grafico viene creato automaticamente. Il foglio di lavoro del grafico viene creato per tutti i tipi di grafici: grafico a linee, a barre, a spirale, a torta, ecc. Per vedere il foglio di calcolo del grafico in PowerPoint è necessario fare doppio clic sul grafico:

![todo:image_alt_text](chart-worksheet-formulas_1.png)


Il foglio di calcolo contiene i nomi degli elementi del grafico (Nome categoria: *Category1*, Nome serie) e una tabella con dati numerici relativi a queste categorie e serie. Per impostazione predefinita, quando si crea un nuovo grafico, i dati del foglio di calcolo sono impostati con i dati predefiniti. È quindi possibile modificare i dati del foglio manualmente.

Di solito, il grafico rappresenta dati complessi (ad es. analisti finanziari, scientifici), con celle calcolate a partire dai valori di altre celle o da altri dati dinamici. Calcolare manualmente il valore di una cella e codificarlo nella cella rende difficile modificarlo in futuro. Se si modifica il valore di una determinata cella, tutte le celle dipendenti da essa dovranno essere aggiornate. Inoltre, i dati della tabella possono dipendere da dati di altre tabelle, creando uno schema di dati della presentazione complesso che deve essere aggiornato in modo semplice e flessibile.

**Formula del foglio di calcolo del grafico** in una presentazione è un’espressione per calcolare e aggiornare automaticamente i dati del foglio di calcolo del grafico. La formula definisce la logica di calcolo dei dati per una determinata cella o un insieme di celle. Una formula può essere una formula matematica o logica, che utilizza: riferimenti a celle, funzioni matematiche, operatori logici, operatori aritmetici, funzioni di conversione, costanti di stringa, ecc. La definizione della formula viene scritta in una cella, e quella cella non contiene un valore semplice. La formula calcola il valore e lo restituisce, quindi questo valore viene assegnato alla cella. Le formule dei fogli di calcolo dei grafici nelle presentazioni sono in realtà le stesse delle formule di Excel, e supportano le stesse funzioni predefinite, operatori e costanti per la loro implementazione.

In [**Aspose.Slides**](https://products.aspose.com/slides/it/php-java/) il foglio di calcolo è rappresentato dal metodo
[**ChartData::getChartDataWorkbook**](https://reference.aspose.com/slides/it/php-java/aspose.slides/chartdata/#getChartDataWorkbook) del tipo
[**ChartDataWorkbook**](https://reference.aspose.com/slides/it/php-java/aspose.slides/chartdataworkbook/).
Una formula può essere assegnata e modificata con 
[**ChartDataCell::setFormula**](https://reference.aspose.com/slides/it/php-java/aspose.slides/chartdatacell/#setFormula).
Le seguenti funzionalità sono supportate per le formule in Aspose.Slides:

- Costanti logiche
- Costanti numeriche
- Costanti di stringa
- Costanti di errore
- OperatorI aritmetici
- OperatorI di confronto
- Riferimenti a celle in stile A1
- Riferimenti a celle in stile R1C1
- Funzioni predefinite


Tipicamente, i fogli di calcolo memorizzano gli ultimi valori calcolati delle formule. Se, dopo il caricamento della presentazione, i dati del grafico non sono stati modificati, il metodo [**ChartDataCell::getValue**](https://reference.aspose.com/slides/it/php-java/aspose.slides/chartdatacell/#getValue) restituisce tali valori durante la lettura. Tuttavia, se i dati del foglio sono stati modificati, durante la lettura il valore genera l’eccezione [**CellUnsupportedDataException**](https://reference.aspose.com/slides/it/php-java/aspose.slides/CellUnsupportedDataException) per le formule non supportate. Questo accade perché, quando le formule vengono analizzate correttamente, vengono determinati i riferimenti delle celle e la correttezza degli ultimi valori. Se la formula non può essere analizzata, non è possibile garantire la correttezza del valore della cella.

## **Aggiungere una formula del foglio di calcolo del grafico a una presentazione**
Per prima cosa, aggiungere un grafico alla prima diapositiva di una nuova presentazione con 
[ShapeCollection::addChart](https://reference.aspose.com/slides/it/php-java/aspose.slides/shapecollection/#addChart).
Il foglio di lavoro del grafico viene creato automaticamente e può essere accesso con 
[**ChartData::getChartDataWorkbook**](https://reference.aspose.com/slides/it/php-java/aspose.slides/chartdata/#getChartDataWorkbook) method:



```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 150, 150, 500, 300);
    $workbook = $chart->getChartData()->getChartDataWorkbook();
    # ...
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Scriviamo alcuni valori nelle celle con il metodo [**ChartDataCell::setValue**](https://reference.aspose.com/slides/it/php-java/aspose.slides/chartdatacell/#setValue) del tipo **Object**, che consente di impostare qualsiasi valore:

```php
  $workbook->getCell(0, "F2")->setValue(-2.5);
  $workbook->getCell(0, "G3")->setValue(6.3);
  $workbook->getCell(0, "H4")->setValue(3);

```

Ora, per scrivere una formula nella cella, è possibile utilizzare il 
[**ChartDataCell::setFormula**](https://reference.aspose.com/slides/it/php-java/aspose.slides/chartdatacell/#setFormula) method.

*Nota*: [**ChartDataCell::setFormula**](https://reference.aspose.com/slides/it/php-java/aspose.slides/chartdatacell/#setFormula) viene usato per impostare riferimenti a celle in stile A1. 

Per impostare una formula in stile R1C1, è possibile usare il metodo [**ChartDataCell::setR1C1Formula**](https://reference.aspose.com/slides/it/php-java/aspose.slides/chartdatacell/#setR1C1Formula).

Quindi, se si tenta di leggere i valori dalle celle B2 e C2, questi verranno calcolati:

```php
  $value1 = $cell1->getValue();// 7.8

  $value2 = $cell2->getValue();// 2.1


```

## **Costanti logiche**
È possibile utilizzare costanti logiche come *FALSE* e *TRUE* nelle formule delle celle:

```php
  $workbook->getCell(0, "A2")->setValue(false);
  $cell = $workbook->getCell(0, "B2");
  $cell->setFormula("A2 = TRUE");
  $value = $cell->getValue();// il valore contiene il booleano "false"


```

## **Costanti numeriche**
I numeri possono essere usati in notazione comune o scientifica per creare una formula del foglio di calcolo del grafico:

```php
  $workbook->getCell(0, "A2")->setFormula("1 + 0.5");
  $workbook->getCell(0, "B2")->setFormula(".3 * 1E-2");

```

## **Costanti di stringa**
Una costante di stringa (o letterale) è un valore specifico usato così com’è e non cambia. Le costanti di stringa possono essere: date, testi, numeri, ecc.:

```php
  $workbook->getCell(0, "A2")->setFormula("\"abc\"");
  $workbook->getCell(0, "B2")->setFormula("\"2/3/2020 12:00\"");

```

## **Costanti di errore**
A volte non è possibile calcolare il risultato della formula. In tal caso, nel valore della cella viene mostrato il codice di errore anziché il valore. Ogni tipo di errore ha un codice specifico:

- #DIV/0! - la formula tenta di dividere per zero.
- #GETTING_DATA - può comparire in una cella mentre il suo valore è ancora in calcolo.
- #N/A - le informazioni sono mancanti o non disponibili. Alcune cause possono essere: le celle usate nella formula sono vuote, un carattere di spazio extra, errori di ortografia, ecc.
- #NAME? - un determinato oggetto cella o formula non può essere trovato per nome. 
- #NULL! - può apparire quando c’è un errore nella formula, ad esempio:  (,) o un carattere di spazio usato al posto dei due punti (:).
- #NUM! - il valore numerico nella formula può essere non valido, troppo lungo o troppo piccolo, ecc.
- #REF! - riferimento a cella non valido.
- #VALUE! - tipo di valore inatteso. Per esempio, valore di stringa impostato in una cella numerica.

```php
  $cell = $workbook->getCell(0, "A2");
  $cell->setFormula("2 / 0");
  $value = $cell->getValue();// il valore contiene la stringa "#DIV/0!"


```

## **Operatori aritmetici**
È possibile utilizzare tutti gli operatori aritmetici nelle formule del foglio di lavoro del grafico:

|**Operatore**|**Significato**|**Esempio**|
| :- | :- | :- |
|+ (segno più)|Addizione o più unario|2 + 3|
|- (segno meno)|Sottrazione o negazione|2 - 3<br>-3|
|* (asterisco)|Moltiplicazione|2 * 3|
|/ (barra obliqua)|Divisione|2 / 3|
|% (percentuale)|Percentuale|30%|
|^ (caret)|Esponenziazione|2 ^ 3|

*Nota*: Per modificare l’ordine di valutazione, racchiudere tra parentesi la parte della formula da calcolare per prima.

## **Operatori di confronto**
È possibile confrontare i valori delle celle con gli operatori di confronto. Quando due valori vengono confrontati con questi operatori, il risultato è un valore logico *TRUE* o *FALSE*:

|**Operatore**|**Significato**|**Significato**|
| :- | :- | :- |
|= (segno uguale)|Uguale a|A2 = 3|
|<> (segno diverso)|Diverso da|A2 <> 3|
|> (segno maggiore)|Maggiore di|A2 > 3|
|>= (segno maggiore o uguale)|Maggiore o uguale a|A2 >= 3|
|< (segno minore)|Minore di|A2 < 3|
|<= (segno minore o uguale)|Minore o uguale a|A2 <= 3|

## **Riferimenti a celle in stile A1**
**I riferimenti a celle in stile A1** vengono usati per i fogli di lavoro, dove la colonna ha un identificatore alfabetico (ad es. "*A*") e la riga ha un identificatore numerico (ad es. "*1*"). I riferimenti in stile A1 possono essere usati nel modo seguente:

|**Riferimento cella**|**Esempio**|||
| :- | :- | :- | :- |
||Assoluto|Relativo|Misto|
|Cella|$A$2|A2|<p>A$2</p><p>$A2</p>|
|Riga|$2:$2|2:2|-|
|Colonna|$A:$A|A:A|-|
|Intervallo|$A$2:$C$4|A2:C4|<p>$A$2:C4</p><p>A$2:$C4</p>|


Ecco un esempio di utilizzo di un riferimento a cella in stile A1 in una formula:

```php
  $workbook->getCell(0, "A2")->setFormula("C3 + SUM(F2:H5)");

```

## **Riferimenti a celle in stile R1C1**
**I riferimenti a celle in stile R1C1** vengono usati per i fogli di lavoro, dove sia riga che colonna hanno identificatori numerici. I riferimenti in stile R1C1 possono essere usati nel modo seguente:

|**Riferimento cella**|**Esempio**|||
| :- | :- | :- | :- |
||Assoluto|Relativo|Misto|
|Cella|R2C3|R[2]C[3]|R2C[3]<br>R[2]C3|
|Riga|R2|R[2]|-|
|Colonna|C3|C[3]|-|
|Intervallo|R2C3:R5C7|R[2]C[3]:R[5]C[7]|R2C3:R[5]C[7]<br>R[2]C3:R5C[7]|


Ecco un esempio di utilizzo di un riferimento a cella in stile A1 in una formula:

```php
  $workbook->getCell(0, "A2")->setR1C1Formula("R2C4 + SUM(R5C6:R7C9)");

```

## **Funzioni predefinite**
Esistono funzioni predefinite che possono essere usate nelle formule per semplificarne l’implementazione. Queste funzioni racchiudono le operazioni più comuni, come:

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

Sì. Aspose.Slides supporta cartelle di lavoro esterne come [fonte dati del grafico](https://reference.aspose.com/slides/it/php-java/aspose.slides/chartdatasourcetype/), consentendo l’uso di formule da un file XLSX al di fuori della presentazione.

**Le formule dei grafici possono fare riferimento a fogli all’interno della stessa cartella di lavoro per nome foglio?**

Sì. Le formule seguono il modello di riferimento standard di Excel, quindi è possibile fare riferimento ad altri fogli all’interno della stessa cartella di lavoro o a una cartella di lavoro esterna. Per i riferimenti esterni, includere percorso e nome della cartella usando la sintassi di Excel.
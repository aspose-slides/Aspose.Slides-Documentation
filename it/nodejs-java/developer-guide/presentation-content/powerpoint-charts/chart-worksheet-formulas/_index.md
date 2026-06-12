---
title: Applicare le formule del foglio di lavoro del grafico nelle presentazioni usando JavaScript
linktitle: Formule del foglio di lavoro
type: docs
weight: 70
url: /it/nodejs-java/chart-worksheet-formulas/
keywords:
- foglio di calcolo del grafico
- foglio di lavoro del grafico
- formula del grafico
- formula del foglio di lavoro
- formula del foglio di calcolo
- origine dati
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Applica formule in stile Excel in Aspose.Slides per Node.js tramite fogli di lavoro del grafico Java e automatizza i report nei file PPT e PPTX con JavaScript."
---
## **Panoramica**

Un foglio di lavoro del grafico è la fonte dati dietro un grafico in una presentazione. Memorizza i nomi delle categorie e delle serie insieme ai valori numerici visualizzati dal grafico. In Aspose.Slides, questo foglio di lavoro è disponibile tramite il workbook dei dati del grafico, che consente di lavorare con i dati del grafico in modo programmatico.

Questo articolo spiega come utilizzare le formule del foglio di lavoro nei dati del grafico in modo che i valori delle celle possano essere calcolati e aggiornati automaticamente anziché inseriti manualmente. Mostra come assegnare formule, utilizzare riferimenti in stile A1 e R1C1, ricalcolare le formule del workbook e lavorare con le costanti, gli operatori, i riferimenti alle celle e le funzioni predefinite supportate per i fogli di lavoro dei grafici nelle presentazioni.

## **Informazioni su Chart Spreadsheet Formula in Presentation**
**Chart spreadsheet** (o foglio di lavoro del grafico) in una presentazione è la fonte dati del grafico. Il chart spreadsheet contiene i dati, che sono rappresentati nel grafico in modo grafico. Quando crei un grafico in PowerPoint, il foglio di lavoro associato a questo grafico viene creato automaticamente. Il foglio di lavoro del grafico viene creato per tutti i tipi di grafici: grafico a linee, grafico a barre, grafico sunburst, grafico a torta, ecc. Per visualizzare il chart spreadsheet in PowerPoint devi fare doppio clic sul grafico:

![todo:image_alt_text](chart-worksheet-formulas_1.png)


Il chart spreadsheet contiene i nomi degli elementi del grafico (Category Name: *Category1*, Serie Name) e una tabella con dati numerici appropriati a queste categorie e serie. Per impostazione predefinita, quando crei un nuovo grafico – i dati del chart spreadsheet sono impostati con i dati predefiniti. Quindi puoi modificare manualmente i dati del foglio di lavoro.

Di solito, il grafico rappresenta dati complessi (ad es. analisi finanziarie, analisi scientifiche), con celle calcolate a partire dai valori di altre celle o da altri dati dinamici. Calcolare manualmente il valore di una cella e codificarlo direttamente nella cella rende difficile modificarlo in futuro. Se cambi il valore di una certa cella, tutte le celle dipendenti da essa dovranno essere aggiornate. Inoltre, i dati della tabella possono dipendere da dati di altre tabelle, creando uno schema di dati della presentazione complesso che deve essere aggiornato in modo semplice e flessibile.

**Chart spreadsheet formula** in una presentazione è un'espressione per calcolare e aggiornare automaticamente i dati del chart spreadsheet. La formula del foglio di lavoro definisce la logica di calcolo dei dati per una determinata cella o un insieme di celle. La formula del foglio di lavoro è una formula matematica o logica, che utilizza: riferimenti a celle, funzioni matematiche, operatori logici, operatori aritmetici, funzioni di conversione, costanti stringa, ecc. La definizione della formula è scritta in una cella, e questa cella non contiene un valore semplice. La formula del foglio di lavoro calcola il valore e lo restituisce, quindi questo valore viene assegnato alla cella. Le formule del chart spreadsheet nelle presentazioni sono in realtà le stesse delle formule di Excel, e sono supportate le stesse funzioni predefinite, operatori e costanti per la loro implementazione.

In [**Aspose.Slides**](https://products.aspose.com/slides/it/nodejs-java/) il chart spreadsheet è rappresentato con il metodo
[**Chart.getChartData.getChartDataWorkbook**](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/ChartData#getChartDataWorkbook--) del tipo
[**ChartDataWorkbook**](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/ChartDataWorkbook).
La formula del foglio di lavoro può essere assegnata e modificata con 
[**ChartDataCell.setFormula**](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/ChartDataCell#setFormula-java.lang.String-) .
La seguente funzionalità è supportata per le formule in Aspose.Slides:

- Costanti logiche
- Costanti numeriche
- Costanti stringa
- Costanti di errore
- Operatori aritmetici
- Operatori di confronto
- Riferimenti a celle in stile A1
- Riferimenti a celle in stile R1C1
- Funzioni predefinite


Tipicamente, i fogli di calcolo memorizzano gli ultimi valori calcolati delle formule. Se, dopo il caricamento della presentazione, i dati del grafico non sono stati modificati, il metodo [**ChartDataCell.getValue**](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/ChartDataCell#getValue--) restituisce tali valori durante la lettura. Tuttavia, se i dati del foglio di calcolo sono stati modificati, durante la lettura della proprietà **ChartDataCell.Value** viene generata l'eccezione [**CellUnsupportedDataException**](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/CellUnsupportedDataException) per le formule non supportate. Ciò avviene perché, quando le formule sono analizzate correttamente, le dipendenze delle celle vengono determinate e l'accuratezza degli ultimi valori viene verificata. Se la formula non può essere analizzata, l'accuratezza del valore della cella non può essere garantita.

## **Aggiungere Chart Spreadsheet Formula a Presentation**
Per prima cosa, aggiungi un grafico alla prima diapositiva di una nuova presentazione con 
[ShapeCollection.getShapes.addChart](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/ShapeCollection#addChart-int-float-float-float-float-).
Il foglio di lavoro del grafico viene creato automaticamente e può essere accessibile con 
[**Chart.getChartData.getChartDataWorkbook**](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/ChartData#getChartDataWorkbook--) :

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 150, 150, 500, 300);
    var workbook = chart.getChartData().getChartDataWorkbook();
    // ...
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Scriviamo alcuni valori nelle celle con la proprietà 
[**ChartDataCell.setValue**](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/ChartDataCell#setValue-java.lang.Object-) del tipo **Object**, il che significa che puoi impostare qualsiasi valore:

```javascript
workbook.getCell(0, "F2").setValue(-2.5);
workbook.getCell(0, "G3").setValue(6.3);
workbook.getCell(0, "H4").setValue(3);
```

Ora, per scrivere una formula nella cella, puoi usare il metodo 
[**ChartDataCell.setFormula**](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/ChartDataCell#setFormula-java.lang.String-) :

*Nota*: [**ChartDataCell.setFormula**](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/ChartDataCell#setFormula-java.lang.String-) viene usato per impostare riferimenti a celle in stile A1. 

Per impostare il riferimento alla cella [R1C1Formula](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/ChartDataCell#getR1C1Formula--) puoi usare il metodo [**ChartDataCell.setR1C1Formula**](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/ChartDataCell#setR1C1Formula-java.lang.String-) :

Quindi, se provi a leggere i valori dalle celle B2 e C2, verranno calcolati:

```javascript
var value1 = cell1.getValue();// 7.8
var value2 = cell2.getValue();// 2.1
```

## **Costanti Logiche**
Puoi usare costanti logiche come *FALSE* e *TRUE* nelle formule delle celle:

```javascript
workbook.getCell(0, "A2").setValue(false);
var cell = workbook.getCell(0, "B2");
cell.setFormula("A2 = TRUE");
var value = cell.getValue();// il valore contiene il booleano "false"
```

## **Costanti Numeriche**
I numeri possono essere usati in notazione comune o scientifica per creare formule del chart spreadsheet:

```javascript
workbook.getCell(0, "A2").setFormula("1 + 0.5");
workbook.getCell(0, "B2").setFormula(".3 * 1E-2");
```

## **Costanti Stringa**
Una costante stringa (o letterale) è un valore specifico usato così com'è e non cambia. Le costanti stringa possono essere: date, testi, numeri, ecc.:

```javascript
workbook.getCell(0, "A2").setFormula("\"abc\"");
workbook.getCell(0, "B2").setFormula("\"2/3/2020 12:00\"");
```

## **Costanti di Errore**
A volte non è possibile calcolare il risultato mediante la formula. In tal caso, nella cella viene mostrato il codice di errore anziché il valore. Ogni tipo di errore ha un codice specifico:

- #DIV/0! - la formula tenta di dividere per zero.
- #GETTING_DATA - può comparire su una cella mentre il suo valore è ancora in fase di calcolo.
- #N/A - informazione mancante o non disponibile. Alcune cause possono essere: le celle usate nella formula sono vuote, un carattere di spazio extra, errori di battitura, ecc.
- #NAME? - una certa cella o altri oggetti della formula non possono essere trovati per nome. 
- #NULL! - può apparire quando c'è un errore nella formula, ad esempio:  (,) o un carattere di spazio usato al posto dei due punti (:).
- #NUM! - il valore numerico nella formula può essere non valido, troppo lungo o troppo piccolo, ecc.
- #REF! - riferimento a cella non valido.
- #VALUE! - tipo di valore inaspettato. Per esempio, valore stringa impostato su una cella numerica.

```javascript
var cell = workbook.getCell(0, "A2");
cell.setFormula("2 / 0");
var value = cell.getValue();// il valore contiene la stringa "#DIV/0!"
```

## **Operatori Aritmetici**
Puoi usare tutti gli operatori aritmetici nelle formule del foglio di lavoro del grafico:

|**Operatore**|**Significato**|**Esempio**|
| :- | :- | :- |
|+ (segno più)|Addizione o segno più unario|2 + 3|
|- (segno meno)|Sottrazione o negazione|2 - 3<br>-3|
|* (asterisco)|Moltiplicazione|2 * 3|
|/ (barra obliqua)|Divisione|2 / 3|
|% (segno percentuale)|Percentuale|30%|
|^ (caret)|Elevamento a potenza|2 ^ 3|

*Nota*: Per modificare l'ordine di valutazione, racchiudi tra parentesi la parte della formula da calcolare per prima.

## **Operatori di Confronto**
Puoi confrontare i valori delle celle con gli operatori di confronto. Quando due valori sono confrontati usando questi operatori, il risultato è un valore logico *TRUE* o *FALSE*:

|**Operatore**|**Significato**|**Esempio**|
| :- | :- | :- |
|= (segno uguale)|Uguale a|A2 = 3|
|<> (segno diverso)|Diverso da|A2 <> 3|
|> (segno maggiore)|Maggiore di|A2 > 3|
|>= (segno maggiore o uguale)|Maggiore o uguale a|A2 >= 3|
|< (segno minore)|Minore di|A2 < 3|
|<= (segno minore o uguale)|Minore o uguale a|A2 <= 3|

## **Riferimenti a Celle in Stile A1**
**I riferimenti a celle in stile A1** sono usati per i fogli di lavoro, dove la colonna ha un identificatore letterale (ad es. "*A*") e la riga ha un identificatore numerico (ad es. "*1*"). I riferimenti a celle in stile A1 possono essere usati nel modo seguente:

|**Riferimento cella**|**Assoluto**|**Relativo**|**Misto**|
| :- | :- | :- | :- |
|Cella|$A$2|A2|<p>A$2</p><p>$A2</p>|
|Riga|$2:$2|2:2|-|
|Colonna|$A:$A|A:A|-|
|Intervallo|$A$2:$C$4|A2:C4|<p>$A$2:C4</p><p>A$2:$C4</p>|


Ecco un esempio di utilizzo del riferimento a cella in stile A1 in una formula:

```javascript
workbook.getCell(0, "A2").setFormula("C3 + SUM(F2:H5)");
```

## **Riferimenti a Celle in Stile R1C1**
**I riferimenti a celle in stile R1C1** sono usati per i fogli di lavoro, dove sia la riga sia la colonna hanno un identificatore numerico. I riferimenti a celle in stile R1C1 possono essere usati nel modo seguente:

|**Riferimento cella**|**Assoluto**|**Relativo**|**Misto**|
| :- | :- | :- | :- |
|Cella|R2C3|R[2]C[3]|R2C[3]<br>R[2]C3|
|Riga|R2|R[2]|-|
|Colonna|C3|C[3]|-|
|Intervallo|R2C3:R5C7|R[2]C[3]:R[5]C[7]|R2C3:R[5]C[7]<br>R[2]C3:R5C[7]|


Ecco un esempio di utilizzo del riferimento a cella in stile R1C1 in una formula:

```javascript
workbook.getCell(0, "A2").setR1C1Formula("R2C4 + SUM(R5C6:R7C9)");
```

## **Funzioni Predefinite**
Esistono funzioni predefinite che possono essere usate nelle formule per semplificarne l'implementazione. Queste funzioni incapsulano le operazioni più comunemente utilizzate, come:

- ABS
- AVERAGE
- CEILING
- CHOOSE
- CONCAT
- CONCATENATE
- DATE (sistema di data 1900)
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

Sì. Aspose.Slides supporta workbook esterni come [fonte dati del grafico](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/chartdatasourcetype/), consentendo di utilizzare formule da un file XLSX al di fuori della presentazione.

**Le formule del grafico possono fare riferimento a fogli all'interno dello stesso workbook tramite il nome del foglio?**

Sì. Le formule seguono il modello di riferimento standard di Excel, quindi puoi fare riferimento ad altri fogli all'interno dello stesso workbook o a un workbook esterno. Per i riferimenti esterni, includi il percorso e il nome del workbook usando la sintassi di Excel.
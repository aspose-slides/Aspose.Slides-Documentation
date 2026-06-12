---
title: Applicare le formule del foglio di lavoro del grafico nelle presentazioni su Android
linktitle: Formule del foglio di lavoro
type: docs
weight: 70
url: /it/androidjava/chart-worksheet-formulas/
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
- Android
- Java
- Aspose.Slides
description: "Applicare formule in stile Excel in Aspose.Slides per Android tramite fogli di lavoro del grafico Java e automatizzare i report nei file PPT e PPTX."
---
## **Panoramica**

Un foglio di lavoro del grafico è l'origine dati dietro un grafico in una presentazione. Memorizza i nomi di categoria e di serie insieme ai valori numerici visualizzati dal grafico. In Aspose.Slides, questo foglio di lavoro è disponibile tramite la cartella di lavoro dei dati del grafico, che consente di lavorare con i dati del grafico in modo programmatico.

Questo articolo spiega come utilizzare le formule del foglio di lavoro nei dati del grafico in modo che i valori delle celle possano essere calcolati e aggiornati automaticamente invece di essere inseriti manualmente. Mostra come assegnare formule, utilizzare riferimenti in stile A1 e R1C1, ricalcolare le formule della cartella di lavoro e lavorare con le costanti, gli operatori, i riferimenti alle celle e le funzioni predefinite supportate per i fogli di calcolo dei grafici nelle presentazioni.

## **Informazioni sulle formule del foglio di calcolo del grafico nelle presentazioni**
**Foglio di calcolo del grafico** (o foglio di lavoro del grafico) in una presentazione è l'origine dati del grafico. Il foglio di calcolo contiene dati, che sono rappresentati sul grafico in modo grafico. Quando si crea un grafico in PowerPoint, il foglio di lavoro associato a questo grafico viene creato automaticamente. Il foglio di lavoro del grafico è creato per tutti i tipi di grafici: grafico a linee, grafico a barre, grafico a raggi solari, grafico a torta, ecc. Per visualizzare il foglio di calcolo del grafico in PowerPoint è necessario fare doppio clic sul grafico:

![todo:image_alt_text](chart-worksheet-formulas_1.png)


Il foglio di calcolo del grafico contiene i nomi degli elementi del grafico (Nome categoria: *Category1*, Nome serie) e una tabella con dati numerici appropriati a queste categorie e serie. Per impostazione predefinita, quando si crea un nuovo grafico, i dati del foglio di calcolo del grafico sono impostati con i dati predefiniti. È quindi possibile modificare manualmente i dati del foglio di calcolo nella cartella di lavoro.

Di solito, il grafico rappresenta dati complessi (ad es. analisti finanziari, analisti scientifici), con celle calcolate dai valori di altre celle o da altri dati dinamici. Calcolare manualmente il valore di una cella e codificarlo direttamente nella cella rende difficile modificarlo in futuro. Se si modifica il valore di una determinata cella, tutte le celle dipendenti da essa dovranno essere aggiornate. Inoltre, i dati della tabella possono dipendere da dati di altre tabelle, creando uno schema di dati di presentazione complesso che deve essere aggiornato in modo semplice e flessibile.

**Formula del foglio di calcolo del grafico** in una presentazione è un'espressione per calcolare e aggiornare automaticamente i dati del foglio di calcolo del grafico. La formula del foglio di calcolo definisce la logica di calcolo dei dati per una certa cella o per un insieme di celle. La formula del foglio di calcolo è una formula matematica o logica, che utilizza: riferimenti a celle, funzioni matematiche, operatori logici, operatori aritmetici, funzioni di conversione, costanti stringa, ecc. La definizione della formula viene scritta in una cella, e questa cella non contiene un valore semplice. La formula del foglio di calcolo calcola il valore e lo restituisce, quindi questo valore viene assegnato alla cella. Le formule del foglio di calcolo del grafico nelle presentazioni sono effettivamente le stesse delle formule di Excel e supportano le stesse funzioni predefinite, operatori e costanti per la loro implementazione.

In [**Aspose.Slides**](https://products.aspose.com/slides/it/androidjava/) il foglio di calcolo del grafico è rappresentato con il metodo
[**Chart.getChartData.getChartDataWorkbook**](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IChartData#getChartDataWorkbook--) del tipo
[**IChartDataWorkbook**](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IChartDataWorkbook).
Una formula del foglio di calcolo può essere assegnata e modificata con 
[**IChartDataCell.setFormula**](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IChartDataCell#setFormula-java.lang.String-) .
Le seguenti funzionalità sono supportate per le formule in Aspose.Slides:

- Costanti logiche
- Costanti numeriche
- Costanti stringa
- Costanti di errore
- OperatorI aritmetici
- OperatorI di confronto
- Riferimenti a celle in stile A1
- Riferimenti a celle in stile R1C1
- Funzioni predefinite


Tipicamente, i fogli di calcolo memorizzano gli ultimi valori calcolati delle formule. Se, dopo il caricamento della presentazione, i dati del grafico non sono stati modificati, il metodo [**IChartDataCell.getValue**](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IChartDataCell#getValue--) restituisce tali valori durante la lettura. Tuttavia, se i dati del foglio di calcolo sono stati modificati, durante la lettura la proprietà **ChartDataCell.Value** genera l'eccezione [**CellUnsupportedDataException**](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/CellUnsupportedDataException) per le formule non supportate. Ciò avviene perché, quando le formule vengono analizzate correttamente, vengono determinate le dipendenze delle celle e la correttezza degli ultimi valori. Se la formula non può essere analizzata, la correttezza del valore della cella non può essere garantita.

## **Aggiungere una formula del foglio di calcolo del grafico a una presentazione**
Per prima cosa, aggiungere un grafico alla prima diapositiva di una nuova presentazione con 
[IShapeCollection.getShapes.addChart](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IShapeCollection#addChart-int-float-float-float-float-).
Il foglio di lavoro del grafico viene creato automaticamente e può essere raggiunto con 
[**Chart.getChartData.getChartDataWorkbook**](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IChartData#getChartDataWorkbook--) :

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 150, 150, 500, 300);

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    // ...
} finally {
    if (pres != null) pres.dispose();
}
```

Scriviamo alcuni valori nelle celle con la proprietà
[**IChartDataCell.setValue**](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IChartDataCell#setValue-java.lang.Object-) del tipo **Object**, il che significa che è possibile impostare qualsiasi valore:

```java
workbook.getCell(0, "F2").setValue(-2.5);

workbook.getCell(0, "G3").setValue(6.3);

workbook.getCell(0, "H4").setValue(3);
```

Ora, per scrivere una formula nella cella, è possibile utilizzare il metodo 
[**IChartDataCell.setFormula**](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IChartDataCell#setFormula-java.lang.String-) :

*Nota*: Il metodo [**IChartDataCell.setFormula**](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IChartDataCell#setFormula-java.lang.String-) viene usato per impostare riferimenti a celle in stile A1. 

Per impostare il riferimento di cella [R1C1Formula](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IChartDataCell#getR1C1Formula--), è possibile utilizzare il metodo [**IChartDataCell.setR1C1Formula**](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IChartDataCell#setR1C1Formula-java.lang.String-) :

Quindi, se si leggono i valori dalle celle B2 e C2, verranno calcolati:

```java
Object value1 = cell1.getValue(); // 7.8

Object value2 = cell2.getValue(); // 2.1
```

## **Costanti logiche**
È possibile utilizzare costanti logiche come *FALSE* e *TRUE* nelle formule delle celle:

```java
workbook.getCell(0, "A2").setValue(false);
IChartDataCell cell = workbook.getCell(0, "B2");
cell.setFormula("A2 = TRUE");
Object value = cell.getValue(); // il valore contiene il booleano "false"
```

## **Costanti numeriche**
I numeri possono essere usati in notazione comune o scientifica per creare una formula del foglio di calcolo del grafico:

```java
workbook.getCell(0, "A2").setFormula("1 + 0.5");
workbook.getCell(0, "B2").setFormula(".3 * 1E-2");
```

## **Costanti stringa**
Una costante stringa (o letterale) è un valore specifico che viene usato così com'è e non cambia. Le costanti stringa possono essere: date, testi, numeri, ecc.:

```java
workbook.getCell(0, "A2").setFormula("\"abc\"");
workbook.getCell(0, "B2").setFormula("\"2/3/2020 12:00\"");
```

## **Costanti di errore**
A volte non è possibile calcolare il risultato tramite la formula. In tal caso, nel posto del valore viene mostrato il codice di errore. Ogni tipo di errore ha un codice specifico:

- #DIV/0! - la formula tenta di dividere per zero.
- #GETTING_DATA - può essere visualizzata in una cella mentre il suo valore è ancora in calcolo.
- #N/A - informazioni mancanti o non disponibili. Alcune cause possono essere: le celle usate nella formula sono vuote, un carattere di spazio extra, errori di ortografia, ecc.
- #NAME? - una certa cella o altri oggetti di formula non possono essere trovati per nome. 
- #NULL! - può apparire quando c'è un errore nella formula, ad es.:  (,) o un carattere di spazio usato al posto dei due punti (:).
- #NUM! - il valore numerico nella formula può essere non valido, troppo lungo o troppo piccolo, ecc.
- #REF! - riferimento a cella non valido.
- #VALUE! - tipo di valore inatteso. Ad esempio, valore stringa impostato in una cella numerica.

```java
IChartDataCell cell = workbook.getCell(0, "A2");
cell.setFormula("2 / 0");
Object value = cell.getValue(); // il valore contiene la stringa "#DIV/0!"
```

## **Operatori aritmetici**
È possibile utilizzare tutti gli operatori aritmetici nelle formule del foglio di lavoro del grafico:

|**Operatore**|**Significato**|**Esempio**|
| :- | :- | :- |
|+ (segno più)|Addizione o più unario|2 + 3|
|- (segno meno)|Sottrazione o negazione|2 - 3<br>-3|
|* (asterisco)|Moltiplicazione|2 * 3|
|/ (barra obliqua)|Divisione|2 / 3|
|% (segno percentuale)|Percentuale|30%|
|^ (caret)|Elevamento a potenza|2 ^ 3|

*Nota*: Per modificare l'ordine di valutazione, racchiudere tra parentesi la parte della formula da calcolare per prima.

## **Operatori di confronto**
È possibile confrontare i valori delle celle con gli operatori di confronto. Quando due valori sono confrontati con questi operatori, il risultato è un valore logico *TRUE* o *FALSE*:

|**Operatore**|**Significato**|**Significato**|
| :- | :- | :- |
|= (segno uguale)|Uguale a|A2 = 3|
|<> (segno diverso)|Diverso da|A2 <> 3|
|> (segno maggiore)|Maggiore di|A2 > 3|
|>= (segno maggiore o uguale)|Maggiore o uguale a|A2 >= 3|
|< (segno minore)|Minore di|A2 < 3|
|<= (segno minore o uguale)|Minore o uguale a|A2 <= 3|

## **Riferimenti a celle in stile A1**
**I riferimenti a celle in stile A1** sono usati per i fogli di lavoro, dove la colonna ha un identificatore alfabetico (es. "*A*") e la riga un identificatore numerico (es. "*1*"). I riferimenti a celle in stile A1 possono essere usati nel modo seguente:

|**Riferimento cella**|**Esempio**|||
| :- | :- | :- | :- |
||Assoluto|Relativo|Misto|
|Cella|$A$2|A2|<p>A$2</p><p>$A2</p>|
|Riga|$2:$2|2:2|-|
|Colonna|$A:$A|A:A|-|
|Intervallo|$A$2:$C$4|A2:C4|<p>$A$2:C4</p><p>A$2:$C4</p>|


Ecco un esempio di utilizzo di un riferimento a cella in stile A1 in una formula:

```java
workbook.getCell(0, "A2").setFormula("C3 + SUM(F2:H5)");
```

## **Riferimenti a celle in stile R1C1**
**I riferimenti a celle in stile R1C1** sono usati per i fogli di lavoro, dove sia la riga sia la colonna hanno un identificatore numerico. I riferimenti a celle in stile R1C1 possono essere usati nel modo seguente:

|**Riferimento cella**|**Esempio**|||
| :- | :- | :- | :- |
||Assoluto|Relativo|Misto|
|Cella|R2C3|R[2]C[3]|R2C[3]<br>R[2]C3|
|Riga|R2|R[2]|-|
|Colonna|C3|C[3]|-|
|Intervallo|R2C3:R5C7|R[2]C[3]:R[5]C[7]|R2C3:R[5]C[7]<br>R[2]C3:R5C[7]|


Ecco un esempio di utilizzo di un riferimento a cella in stile R1C1 in una formula:

```java
workbook.getCell(0, "A2").setR1C1Formula("R2C4 + SUM(R5C6:R7C9)");
```

## **Funzioni predefinite**
Esistono funzioni predefinite che possono essere utilizzate nelle formule per semplificarne l'implementazione. Queste funzioni racchiudono le operazioni più comunemente usate, come:

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

**I file Excel esterni sono supportati come origine dati per un grafico con formule?**

Sì. Aspose.Slides supporta cartelle di lavoro esterne come [origine dati del grafico](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/chartdatasourcetype/), consentendo di utilizzare formule da un file XLSX esterno alla presentazione.

**Le formule del grafico possono fare riferimento a fogli all'interno della stessa cartella di lavoro per nome foglio?**

Sì. Le formule seguono il modello di riferimento standard di Excel, quindi è possibile fare riferimento ad altri fogli nella stessa cartella di lavoro o in una cartella di lavoro esterna. Per i riferimenti esterni, includere il percorso e il nome della cartella di lavoro utilizzando la sintassi di Excel.
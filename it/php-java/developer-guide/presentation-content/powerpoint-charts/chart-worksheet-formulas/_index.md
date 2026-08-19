---
title: Applica le formule del foglio di lavoro del grafico nelle presentazioni in PHP
linktitle: Formule del foglio di lavoro
type: docs
weight: 70
url: /it/php-java/chart-worksheet-formulas/
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
- PHP
- Aspose.Slides
description: "Applica formule in stile Excel nei fogli di lavoro dei grafici di Aspose.Slides per PHP tramite Java, ricalcola i valori e utilizza i risultati nei grafici PowerPoint."
---
## **Panoramica**

I grafici PowerPoint di solito memorizzano i dati di origine in un foglio di lavoro incorporato. In Aspose.Slides per PHP tramite Java, è possibile accedere a quel foglio di lavoro tramite la cartella di lavoro dei dati del grafico, scrivere valori di input, assegnare formule alle celle, calcolare le formule supportate e utilizzare le celle calcolate come dati del grafico.

Questo articolo spiega l’intero flusso di lavoro delle formule: creare un grafico, popolare il suo foglio di lavoro, assegnare formule in stile A1 o R1C1, ricalcolarle, leggere i valori calcolati, collegare quelle celle a una serie del grafico e salvare la presentazione. Descrive inoltre la sintassi delle formule supportate, il sottoinsieme di funzioni incorporate, i valori memorizzati, le formule non supportate e gli errori specifici dei fogli di calcolo.

## **Fogli di lavoro dei grafici e formule**

Un foglio di lavoro del grafico contiene le categorie, i nomi delle serie e i valori utilizzati da un grafico. In PowerPoint è possibile ispezionare il foglio di lavoro aprendo l’editor dei dati del grafico:

![Grafico PowerPoint con il foglio di lavoro incorporato aperto, che mostra categorie e dati delle serie](chart-worksheet-formulas_1.png)

In Aspose.Slides, il foglio di lavoro è esposto tramite la classe [ChartDataWorkbook](https://reference.aspose.com/slides/it/php-java/aspose.slides/chartdataworkbook/). Utilizzare [ChartDataCell::setFormula](https://reference.aspose.com/slides/it/php-java/aspose.slides/chartdatacell/#setFormula) per formule in stile A1 e [ChartDataCell::setR1C1Formula](https://reference.aspose.com/slides/it/php-java/aspose.slides/chartdatacell/#setR1C1Formula) per formule in stile R1C1. Dopo aver modificato le celle di input o le formule, chiamare [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/it/php-java/aspose.slides/chartdataworkbook/#calculateFormulas) per ricalcolare le formule supportate e aggiornare i valori corrispondenti delle celle.

Una cella calcolata espone ancora il proprio risultato tramite [ChartDataCell::getValue](https://reference.aspose.com/slides/it/php-java/aspose.slides/chartdatacell/#getValue). Questo è importante quando è necessario ispezionare il risultato di una formula nel codice o utilizzare la cella come punto dati del grafico.

## **Creare un grafico e calcolare le formule del foglio di lavoro**

L’esempio seguente dimostra un flusso di lavoro end‑to‑end. Crea un grafico a colonne raggruppate, cancella i dati di esempio, scrive i valori trimestrali di entrate e spese, calcola il profitto con le formule, legge i risultati, utilizza le celle calcolate come valori del grafico e salva la presentazione.

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 350);
    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $worksheetIndex = 0;

    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    $workbook->clear($worksheetIndex);

    $category1 = $workbook->getCell($worksheetIndex, "A2", "Q1");
    $category2 = $workbook->getCell($worksheetIndex, "A3", "Q2");
    $category3 = $workbook->getCell($worksheetIndex, "A4", "Q3");

    $workbook->getCell($worksheetIndex, "B1", "Revenue");
    $workbook->getCell($worksheetIndex, "C1", "Expenses");
    $workbook->getCell($worksheetIndex, "D1", "Profit");

    $workbook->getCell($worksheetIndex, "B2")->setValue(120.0);
    $workbook->getCell($worksheetIndex, "C2")->setValue(80.0);
    $workbook->getCell($worksheetIndex, "B3")->setValue(150.0);
    $workbook->getCell($worksheetIndex, "C3")->setValue(95.0);
    $workbook->getCell($worksheetIndex, "B4")->setValue(135.0);
    $workbook->getCell($worksheetIndex, "C4")->setValue(110.0);

    $profit1 = $workbook->getCell($worksheetIndex, "D2");
    $profit2 = $workbook->getCell($worksheetIndex, "D3");
    $profit3 = $workbook->getCell($worksheetIndex, "D4");

    $profit1->setFormula("B2-C2");
    $profit2->setFormula("B3-C3");
    $profit3->setFormula("B4-C4");

    $workbook->calculateFormulas();

    $q1Profit = java_values($profit1->getValue()); // 40
    $q2Profit = java_values($profit2->getValue()); // 55
    $q3Profit = java_values($profit3->getValue()); // 25

    echo "Q1 profit: " . $q1Profit . PHP_EOL;
    echo "Q2 profit: " . $q2Profit . PHP_EOL;
    echo "Q3 profit: " . $q3Profit . PHP_EOL;

    $chart->getChartData()->getCategories()->add($category1);
    $chart->getChartData()->getCategories()->add($category2);
    $chart->getChartData()->getCategories()->add($category3);

    $profitSeries = $chart->getChartData()->getSeries()->add($workbook->getCell($worksheetIndex, "D1"), $chart->getType());
    $profitSeries->getDataPoints()->addDataPointForBarSeries($profit1);
    $profitSeries->getDataPoints()->addDataPointForBarSeries($profit2);
    $profitSeries->getDataPoints()->addDataPointForBarSeries($profit3);
    $profitSeries->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);

    $presentation->save("chart-formulas.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

I punti dati del grafico fanno riferimento a `D2:D4`, quindi il grafico utilizza i valori di profitto calcolati. Non vi è alcuna chiamata separata di aggiornamento del grafico in questo flusso di lavoro: ricalcolare prima la cartella di lavoro, quindi utilizzare o salvare i dati del grafico che puntano alle celle calcolate.

## **Utilizzare formule in stile A1**

La notazione A1 identifica le colonne con lettere e le righe con numeri. Assegnare espressioni in stile A1 tramite [ChartDataCell::setFormula](https://reference.aspose.com/slides/it/php-java/aspose.slides/chartdatacell/#setFormula).

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 500, 300);
    $workbook = $chart->getChartData()->getChartDataWorkbook();

    $workbook->getCell(0, "C3")->setValue(10);
    $workbook->getCell(0, "F2")->setValue(2);
    $workbook->getCell(0, "G2")->setValue(3);
    $workbook->getCell(0, "H2")->setValue(4);

    $cell = $workbook->getCell(0, "A2");
    $cell->setFormula("C3+SUM(F2:H2)");

    $workbook->calculateFormulas();

    $value = java_values($cell->getValue()); // 19
} finally {
    $presentation->dispose();
}
```

Le forme di riferimento A1 più comuni sono:

| Riferimento | Relativa | Assoluta | Mista |
|---|---|---|---|
| Cella | `A2` | `$A$2` | `A$2`, `$A2` |
| Riga | `2:2` | `$2:$2` | — |
| Colonna | `A:A` | `$A:$A` | — |
| Intervallo | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

I riferimenti relativi possono cambiare quando una formula viene spostata o copiata da un’applicazione di foglio di calcolo. I riferimenti assoluti mantengono entrambe le coordinate fisse, mentre i riferimenti misti fissano solo una riga o una colonna.

## **Utilizzare formule in stile R1C1**

La notazione R1C1 identifica sia le righe che le colonne in modo numerico. I riferimenti relativi usano offset tra parentesi quadre. Assegnare questa sintassi tramite [ChartDataCell::setR1C1Formula](https://reference.aspose.com/slides/it/php-java/aspose.slides/chartdatacell/#setR1C1Formula).

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 500, 300);
    $workbook = $chart->getChartData()->getChartDataWorkbook();

    $workbook->getCell(0, "B2")->setValue(12);
    $workbook->getCell(0, "C2")->setValue(5);

    $cell = $workbook->getCell(0, "D2");
    $cell->setR1C1Formula("RC[-2]-RC[-1]");

    $workbook->calculateFormulas();

    $value = java_values($cell->getValue()); // 7
} finally {
    $presentation->dispose();
}
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

Il valutatore di formule incorporato supporta valori logici, letterali numerici, stringhe, valori di errore del foglio di calcolo, operatori aritmetici e operatori di confronto.

### **Costanti e letterali**

| Tipo | Esempi | Note |
|---|---|---|
| Logico | `TRUE`, `FALSE` | Può essere usato direttamente in espressioni logiche come `A2=TRUE`. |
| Numerico | `1`, `0.5`, `.3`, `1E-2` | Sono supportate notazioni decimali e scientifiche. |
| Stringa | `"abc"`, `"2/3/2020 12:00"` | I letterali di testo sono racchiusi tra virgolette doppie all’interno della formula. |
| Risultato di errore | `#DIV/0!`, `#N/A`, `#REF!` | Una formula valida può valutare a un valore di errore del foglio di calcolo anziché a un risultato normale. |

Questo esempio utilizza diversi tipi di costanti:

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 500, 300);
    $workbook = $chart->getChartData()->getChartDataWorkbook();

    $workbook->getCell(0, "A2")->setValue(false);
    $workbook->getCell(0, "B2")->setFormula("A2=TRUE");
    $workbook->getCell(0, "C2")->setFormula("1+0.5");
    $workbook->getCell(0, "D2")->setFormula(".3*1E-2");
    $workbook->getCell(0, "E2")->setFormula("\"abc\"");
    $workbook->getCell(0, "F2")->setFormula("2/0");

    $workbook->calculateFormulas();

    $logicalValue = java_values($workbook->getCell(0, "B2")->getValue()); // false
    $numericValue = java_values($workbook->getCell(0, "C2")->getValue()); // 1.5
    $scientificValue = java_values($workbook->getCell(0, "D2")->getValue()); // 0.003
    $stringValue = java_values($workbook->getCell(0, "E2")->getValue()); // abc
    $errorValue = java_values($workbook->getCell(0, "F2")->getValue()); // #DIV/0!
} finally {
    $presentation->dispose();
}
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

Utilizzare le parentesi per rendere esplicito l’ordine di valutazione, ad esempio `(A2+B2)*C2`.

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

Aspose.Slides include un valutatore di formule incorporato per i fogli di lavoro dei grafici, ma non è un motore di calcolo completo come Excel. Il set di funzioni documentato è limitato alle seguenti funzioni. Non presumere che una funzione Excel arbitraria possa essere ricalcolata da [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/it/php-java/aspose.slides/chartdataworkbook/#calculateFormulas).

| Funzione | Scopo o forma supportata | Esempio |
|---|---|---|
| `ABS` | Valore assoluto | `ABS(A2)` |
| `AVERAGE` | Media aritmetica | `AVERAGE(B2:B5)` |
| `CEILING` | Arrotonda un numero per eccesso a un multiplo | `CEILING(A2,5)` |
| `CHOOSE` | Seleziona un valore per indice | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | Unisce valori di testo | `CONCAT(A2,B2)` |
| `CONCATENATE` | Unisce valori di testo | `CONCATENATE(A2," ",B2)` |
| `DATE` | Crea un valore data usando il sistema data 1900 | `DATE(2026,8,19)` |
| `DAYS` | Restituisce il numero di giorni tra due date | `DAYS(B2,A2)` |
| `FIND` | Trova un valore di testo all’interno di un altro | `FIND("-",A2)` |
| `FINDB` | Ricerca testo orientata ai byte | `FINDB("a",A2)` |
| `IF` | Risultato condizionale | `IF(A2>0,A2,0)` |
| `INDEX` | Forma di riferimento | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | Forma vettoriale | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | Forma vettoriale | `MATCH(A2,B2:B5,0)` |
| `MAX` | Valore massimo | `MAX(B2:B5)` |
| `SUM` | Somma valori | `SUM(B2:B5)` |
| `VLOOKUP` | Ricerca verticale | `VLOOKUP(A2,B2:D10,3,FALSE)` |

Le limitazioni illustrate nella tabella sono significative: `INDEX` è documentato in forma di riferimento, mentre `LOOKUP` e `MATCH` sono documentati nelle loro forme vettoriali. `DATE` utilizza il sistema data 1900. Le funzionalità e le funzioni non elencate dovrebbero essere considerate non supportate dal valutatore di formule di Aspose.Slides, a meno che non siano documentate separatamente.

## **Ricalcolo e valori memorizzati**

I file di foglio di calcolo normalmente memorizzano sia la formula sia il suo ultimo valore calcolato. Aspose.Slides può quindi leggere un valore memorizzato da [ChartDataCell::getValue](https://reference.aspose.com/slides/it/php-java/aspose.slides/chartdatacell/#getValue) quando una presentazione viene caricata e i dati del grafico pertinenti non sono stati modificati.

Dopo aver cambiato le celle di input o le formule, non fare affidamento su un risultato memorizzato precedente. Chiamare [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/it/php-java/aspose.slides/chartdataworkbook/#calculateFormulas) prima di leggere i valori calcolati o di salvare i dati del grafico che dipendono da essi.

Per le formule al di fuori del sottoinsieme supportato, Aspose.Slides potrebbe non riuscire a analizzarle o a stabilirne le dipendenze. Se la cartella di lavoro è stata modificata, il valore memorizzato precedente non è più affidabile. In tal caso, la lettura del valore di una cella con dati non supportati può generare [CellUnsupportedDataException](https://reference.aspose.com/slides/it/php-java/aspose.slides/cellunsupporteddataexception/).

Se il tuo grafico dipende da funzioni Excel che Aspose.Slides non valuta, calcola quelle formule con un motore di foglio di calcolo che le supporta e scrivi i valori risultanti nel foglio di lavoro del grafico. Non sostituire formule non supportate con valori ipotetici.

## **Gestire gli errori di formula**

Esistono due tipologie di problemi da distinguere.

Una formula può essere valida ma produrre un risultato di errore del foglio di calcolo come `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!` o `#VALUE!`. In tal caso, il token di errore è un risultato di cella e può essere restituito tramite [ChartDataCell::getValue](https://reference.aspose.com/slides/it/php-java/aspose.slides/chartdatacell/#getValue).

Una formula può anche fallire a livello di analisi, riferimento, dipendenza o dati supportati. Aspose.Slides fornisce eccezioni specifiche per fogli di calcolo per questi casi: [CellInvalidFormulaException](https://reference.aspose.com/slides/it/php-java/aspose.slides/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/it/php-java/aspose.slides/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/it/php-java/aspose.slides/cellcircularreferenceexception/) e [CellUnsupportedDataException](https://reference.aspose.com/slides/it/php-java/aspose.slides/cellunsupporteddataexception/).

In PHP tramite Java, le eccezioni Java sono esposte tramite `JavaException`. Quando le formule provengono da modelli o input dell’utente, gestiscile attorno al ricalcolo e all’accesso ai valori. L’eccezione Java riportata nello stack trace identifica il problema specifico del foglio di calcolo:

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 500, 300);
    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $cell = $workbook->getCell(0, "A2");
    $cell->setFormula("SUM(B2:B5)");

    try {
        $workbook->calculateFormulas();
        echo java_values($cell->getValue()) . PHP_EOL;
    } catch (JavaException $ex) {
        $ex->printStackTrace();
    }
} finally {
    $presentation->dispose();
}
```

## **Limitazioni pratiche**

Il supporto delle formule nei fogli di lavoro dei grafici è destinato a un sottoinsieme definito di calcoli di foglio di calcolo, non a una compatibilità totale con Excel. Tenere presente queste restrizioni quando si progetta un flusso di lavoro di reporting:

- Utilizzare solo le costanti, gli operatori, i riferimenti e le funzioni documentate quando si richiede ad Aspose.Slides di ricalcolare le formule.
- Ricalcolare dopo aver modificato le celle da cui dipendono i risultati delle formule.
- Considerare i valori memorizzati delle presentazioni caricate come istantanee, non come sostituti del ricalcolo dopo le modifiche.
- Testare le formule dei modelli esistenti prima di fare affidamento sui loro valori calcolati, specialmente se usano funzioni non presenti nell’elenco documentato.
- Per le formule che richiedono un motore di calcolo completo, calcolarle esternamente e poi aggiornare il foglio di lavoro del grafico con i valori risultanti.

## **FAQ**

**Qual è la differenza tra [ChartDataCell::setFormula](https://reference.aspose.com/slides/it/php-java/aspose.slides/chartdatacell/#setFormula) e [ChartDataCell::setR1C1Formula](https://reference.aspose.com/slides/it/php-java/aspose.slides/chartdatacell/#setR1C1Formula)?**

[ChartDataCell::setFormula](https://reference.aspose.com/slides/it/php-java/aspose.slides/chartdatacell/#setFormula) memorizza un’espressione in stile A1 come `B2-C2`. [ChartDataCell::setR1C1Formula](https://reference.aspose.com/slides/it/php-java/aspose.slides/chartdatacell/#setR1C1Formula) memorizza un’espressione in stile R1C1 come `RC[-2]-RC[-1]`. Utilizzare la notazione che meglio corrisponde a come si generano o copiano le formule.

**Devo leggere la cella stessa o il suo valore dopo il ricalcolo?**

[ChartDataWorkbook::getCell](https://reference.aspose.com/slides/it/php-java/aspose.slides/chartdataworkbook/#getCell) restituisce un [ChartDataCell](https://reference.aspose.com/slides/it/php-java/aspose.slides/chartdatacell/). Per ottenere il risultato calcolato, chiamare il metodo [ChartDataCell::getValue](https://reference.aspose.com/slides/it/php-java/aspose.slides/chartdatacell/#getValue) di quella cella dopo il ricalcolo.

**Quando devo chiamare [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/it/php-java/aspose.slides/chartdataworkbook/#calculateFormulas)?**

Chiamare [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/it/php-java/aspose.slides/chartdataworkbook/#calculateFormulas) dopo aver modificato i valori di input o le formule e prima di dipendere dai risultati calcolati. Questo aggiorna i valori delle formule che il valutatore incorporato supporta.

**Aspose.Slides supporta tutte le funzioni di Excel?**

No. Il valutatore incorporato supporta un sottoinsieme documentato di funzioni. Le funzioni al di fuori di quel sottoinsieme non devono essere ritenute ricalcolabili correttamente. Se è necessaria la piena compatibilità delle formule Excel, eseguire il calcolo con un motore di foglio di calcolo appropriato e scrivere i valori finali nel foglio di lavoro del grafico.

** Cosa accade se una presentazione caricata contiene una formula non supportata?**

Se i dati del grafico non sono stati modificati, la cartella di lavoro può ancora contenere un valore memorizzato calcolato in precedenza. Dopo che i dati correlati sono stati modificati, quel valore memorizzato potrebbe non essere più valido. L’accesso a una cella la cui formula non può essere gestita può generare [CellUnsupportedDataException](https://reference.aspose.com/slides/it/php-java/aspose.slides/cellunsupporteddataexception/).

**I valori di errore di formula coincidono con le eccezioni PHP?**

No. Un risultato come `#DIV/0!` è un valore di foglio di calcolo prodotto da un calcolo valido. I fallimenti di elaborazione del foglio di calcolo, quali [CellInvalidFormulaException](https://reference.aspose.com/slides/it/php-java/aspose.slides/cellinvalidformulaexception/) o [CellCircularReferenceException](https://reference.aspose.com/slides/it/php-java/aspose.slides/cellcircularreferenceexception/), sono eccezioni Java esposte a PHP tramite `JavaException`.

**Un grafico si aggiorna automaticamente quando cambia una cella formula?**

Una serie del grafico può fare riferimento a celle della cartella di lavoro. Ricalcolare prima la cartella di lavoro, quindi salvare o renderizzare la presentazione. Se i punti dati del grafico fanno riferimento alle celle calcolate, il grafico utilizza quei valori aggiornati; non è necessario un metodo di aggiornamento separato per questo flusso di lavoro.

**I grafici possono utilizzare una cartella di lavoro Excel esterna?**

Sì, i dati del grafico possono essere configurati per usare una cartella di lavoro esterna tramite l’API dei dati del grafico. Tuttavia, il flusso di lavoro di calcolo delle formule descritto in questo articolo riguarda la cartella di lavoro dei dati del grafico e il sottoinsieme di formule valutato da Aspose.Slides. Non presumere che [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/it/php-java/aspose.slides/chartdataworkbook/#calculateFormulas) fornisca un ricalcolo completo di formule arbitrarie in un file XLSX esterno.

**Posso usare formule che fanno riferimento a un altro foglio o a un altro file?**

I riferimenti in stile Excel possono esistere nei fogli di lavoro dei grafici, ma la valutazione delle formule è limitata al parser e al set di funzioni supportati. Se un riferimento incrociato è essenziale, verificare quella formula esatta con la versione di Aspose.Slides in uso. Per flussi di lavoro che richiedono ampie compatibilità di riferimento Excel, calcolare il foglio di lavoro esternamente e scrivere i valori risolti nei dati del grafico.

**Le stringhe delle formule devono iniziare con `=`?**

Gli esempi dell’API Aspose.Slides assegnano espressioni come `B2-C2` o `SUM(B2:B5)` senza il `=` iniziale. Usare questa forma mantiene le formule generate coerenti con gli esempi documentati dell’API.
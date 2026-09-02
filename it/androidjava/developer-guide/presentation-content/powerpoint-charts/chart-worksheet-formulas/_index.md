---
title: Applica formule del foglio di lavoro del grafico nelle presentazioni su Android
linktitle: Formule del foglio di lavoro
type: docs
weight: 70
url: /it/androidjava/chart-worksheet-formulas/
keywords:
- grafico foglio di calcolo
- foglio di lavoro del grafico
- formula del grafico
- formula del foglio di lavoro
- formula del foglio di calcolo
- workbook dati del grafico
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
- Android
- Java
- Aspose.Slides
description: "Applica formule in stile Excel in Aspose.Slides per Android via Java sui fogli di lavoro dei grafici, ricalcola i valori e usa i risultati nei grafici PowerPoint."
---
## **Panoramica**

I grafici PowerPoint di solito memorizzano i dati di origine in un foglio di lavoro incorporato. In Aspose.Slides per Android tramite Java, è possibile accedere a quel foglio attraverso il workbook dei dati del grafico, scrivere valori di input, assegnare formule alle celle, calcolare le formule supportate e utilizzare le celle calcolate come dati del grafico.

Questo articolo spiega l’intero flusso di lavoro delle formule: creare un grafico, popolare il suo foglio di lavoro, assegnare formule in stile A1 o R1C1, ricalcolarle, leggere i valori calcolati, collegare quelle celle a una serie del grafico e salvare la presentazione. Descrive anche la sintassi delle formule supportate, il sottoinsieme di funzioni integrate, i valori memorizzati, le formule non supportate e gli errori specifici dei fogli di calcolo.

## **Fogli di lavoro dei grafici e formule**

Un foglio di lavoro di un grafico contiene le categorie, i nomi delle serie e i valori utilizzati dal grafico. In PowerPoint è possibile ispezionare il foglio aprendo l’editor dei dati del grafico:

![Grafico PowerPoint con il foglio di lavoro incorporato aperto, che mostra i dati delle categorie e delle serie](chart-worksheet-formulas_1.png)

In Aspose.Slides, il foglio è esposto tramite l’interfaccia [IChartDataWorkbook](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ichartdataworkbook/). Utilizzare [IChartDataCell.setFormula](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-) per formule in stile A1 e [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-) per formule in stile R1C1. Dopo aver modificato le celle di input o le formule, chiamare [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) per ricalcolare le formule supportate e aggiornare i valori corrispondenti delle celle.

Una cella calcolata espone comunque il suo risultato tramite [IChartDataCell.getValue](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ichartdatacell/#getValue--). Ciò è importante quando è necessario ispezionare il risultato di una formula nel codice o utilizzare la cella come punto dati del grafico.

## **Creare un grafico e calcolare le formule del foglio di lavoro**

L’esempio seguente dimostra un flusso di lavoro end‑to‑end. Crea un grafico a colonne raggruppate, cancella i dati di esempio, scrive i valori trimestrali di ricavi e spese, calcola il profitto con le formule, legge i risultati, usa le celle calcolate come valori del grafico e salva la presentazione.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 350);
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    int worksheetIndex = 0;

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    workbook.clear(worksheetIndex);

    IChartDataCell category1 = workbook.getCell(worksheetIndex, "A2", "Q1");
    IChartDataCell category2 = workbook.getCell(worksheetIndex, "A3", "Q2");
    IChartDataCell category3 = workbook.getCell(worksheetIndex, "A4", "Q3");

    workbook.getCell(worksheetIndex, "B1", "Revenue");
    workbook.getCell(worksheetIndex, "C1", "Expenses");
    workbook.getCell(worksheetIndex, "D1", "Profit");

    workbook.getCell(worksheetIndex, "B2").setValue(120.0);
    workbook.getCell(worksheetIndex, "C2").setValue(80.0);
    workbook.getCell(worksheetIndex, "B3").setValue(150.0);
    workbook.getCell(worksheetIndex, "C3").setValue(95.0);
    workbook.getCell(worksheetIndex, "B4").setValue(135.0);
    workbook.getCell(worksheetIndex, "C4").setValue(110.0);

    IChartDataCell profit1 = workbook.getCell(worksheetIndex, "D2");
    IChartDataCell profit2 = workbook.getCell(worksheetIndex, "D3");
    IChartDataCell profit3 = workbook.getCell(worksheetIndex, "D4");

    profit1.setFormula("B2-C2");
    profit2.setFormula("B3-C3");
    profit3.setFormula("B4-C4");

    workbook.calculateFormulas();

    double q1Profit = ((Number) profit1.getValue()).doubleValue(); // 40
    double q2Profit = ((Number) profit2.getValue()).doubleValue(); // 55
    double q3Profit = ((Number) profit3.getValue()).doubleValue(); // 25

    System.out.println("Q1 profit: " + q1Profit);
    System.out.println("Q2 profit: " + q2Profit);
    System.out.println("Q3 profit: " + q3Profit);

    chart.getChartData().getCategories().add(category1);
    chart.getChartData().getCategories().add(category2);
    chart.getChartData().getCategories().add(category3);

    IChartSeries profitSeries = chart.getChartData().getSeries().add(workbook.getCell(worksheetIndex, "D1"), chart.getType());
    profitSeries.getDataPoints().addDataPointForBarSeries(profit1);
    profitSeries.getDataPoints().addDataPointForBarSeries(profit2);
    profitSeries.getDataPoints().addDataPointForBarSeries(profit3);
    profitSeries.getLabels().getDefaultDataLabelFormat().setShowValue(true);

    presentation.save("chart-formulas.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

I punti dati del grafico fanno riferimento a `D2:D4`, quindi il grafico utilizza i valori di profitto calcolati. Non vi è alcuna chiamata separata di aggiornamento del grafico in questo flusso: ricalcolare prima il workbook, poi utilizzare o salvare i dati del grafico che puntano alle celle calcolate.

## **Usare formule in stile A1**

La notazione A1 identifica le colonne con lettere e le righe con numeri. Assegnare espressioni in stile A1 tramite [IChartDataCell.setFormula](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-).

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300);
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    workbook.getCell(0, "C3").setValue(10);
    workbook.getCell(0, "F2").setValue(2);
    workbook.getCell(0, "G2").setValue(3);
    workbook.getCell(0, "H2").setValue(4);

    IChartDataCell cell = workbook.getCell(0, "A2");
    cell.setFormula("C3+SUM(F2:H2)");

    workbook.calculateFormulas();

    Object value = cell.getValue(); // 19
} finally {
    presentation.dispose();
}
```

Le forme di riferimento A1 più comuni sono:

| Riferimento | Relativo | Assoluto | Misto |
|---|---|---|---|
| Cella | `A2` | `$A$2` | `A$2`, `$A2` |
| Riga | `2:2` | `$2:$2` | — |
| Colonna | `A:A` | `$A:$A` | — |
| Intervallo | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

I riferimenti relativi possono cambiare quando una formula viene spostata o copiata da un’applicazione di fogli di calcolo. I riferimenti assoluti mantengono entrambe le coordinate fisse, mentre i riferimenti misti fissano solo una riga o una colonna.

## **Usare formule in stile R1C1**

La notazione R1C1 identifica sia le righe sia le colonne in modo numerico. I riferimenti relativi usano offset tra parentesi quadre. Assegnare questa sintassi tramite [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-).

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300);
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    workbook.getCell(0, "B2").setValue(12);
    workbook.getCell(0, "C2").setValue(5);

    IChartDataCell cell = workbook.getCell(0, "D2");
    cell.setR1C1Formula("RC[-2]-RC[-1]");

    workbook.calculateFormulas();

    Object value = cell.getValue(); // 7
} finally {
    presentation.dispose();
}
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

L’evaluatore di formule integrato supporta valori logici, letterali numerici, stringhe, valori di errore dei fogli di calcolo, operatori aritmetici e operatori di confronto.

### **Costanti e letterali**

| Tipo | Esempi | Note |
|---|---|---|
| Logico | `TRUE`, `FALSE` | Può essere usato direttamente in espressioni logiche come `A2=TRUE`. |
| Numerico | `1`, `0.5`, `.3`, `1E-2` | Sono supportate notazioni comuni e scientifiche. |
| Stringa | `"abc"`, `"2/3/2020 12:00"` | I letterali di testo sono racchiusi tra virgolette doppie all’interno della formula. |
| Risultato di errore | `#DIV/0!`, `#N/A`, `#REF!` | Una formula valida può valutare a un valore di errore del foglio di calcolo anziché a un risultato normale. |

Questo esempio utilizza diversi tipi di costante:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300);
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    workbook.getCell(0, "A2").setValue(false);
    workbook.getCell(0, "B2").setFormula("A2=TRUE");
    workbook.getCell(0, "C2").setFormula("1+0.5");
    workbook.getCell(0, "D2").setFormula(".3*1E-2");
    workbook.getCell(0, "E2").setFormula("\"abc\"");
    workbook.getCell(0, "F2").setFormula("2/0");

    workbook.calculateFormulas();

    Object logicalValue = workbook.getCell(0, "B2").getValue(); // false
    Object numericValue = workbook.getCell(0, "C2").getValue(); // 1.5
    Object scientificValue = workbook.getCell(0, "D2").getValue(); // 0.003
    Object stringValue = workbook.getCell(0, "E2").getValue(); // abc
    Object errorValue = workbook.getCell(0, "F2").getValue(); // #DIV/0!
} finally {
    presentation.dispose();
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

Aspose.Slides include un valutatore di formule integrato per i fogli di lavoro dei grafici, ma non è un motore di calcolo Excel completo. Il set di funzioni documentato è limitato a quelle elencate di seguito. Non presumere che una funzione Excel arbitraria possa essere ricalcolata da [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ichartdataworkbook/#calculateFormulas--).

| Funzione | Scopo o forma supportata | Esempio |
|---|---|---|
| `ABS` | Valore assoluto | `ABS(A2)` |
| `AVERAGE` | Media aritmetica | `AVERAGE(B2:B5)` |
| `CEILING` | Arrotonda per eccesso a un multiplo | `CEILING(A2,5)` |
| `CHOOSE` | Seleziona un valore per indice | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | Unisce valori di testo | `CONCAT(A2,B2)` |
| `CONCATENATE` | Unisce valori di testo | `CONCATENATE(A2," ",B2)` |
| `DATE` | Crea un valore data usando il sistema 1900 | `DATE(2026,8,19)` |
| `DAYS` | Restituisce il numero di giorni tra due date | `DAYS(B2,A2)` |
| `FIND` | Trova una stringa di testo all’interno di un’altra | `FIND("-",A2)` |
| `FINDB` | Ricerca testo orientata ai byte | `FINDB("a",A2)` |
| `IF` | Risultato condizionale | `IF(A2>0,A2,0)` |
| `INDEX` | Forma di riferimento | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | Forma vettoriale | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | Forma vettoriale | `MATCH(A2,B2:B5,0)` |
| `MAX` | Valore massimo | `MAX(B2:B5)` |
| `SUM` | Somma valori | `SUM(B2:B5)` |
| `VLOOKUP` | Ricerca verticale | `VLOOKUP(A2,B2:D10,3,FALSE)` |

Le restrizioni illustrate nella tabella sono significative: `INDEX` è documentato in forma di riferimento, mentre `LOOKUP` e `MATCH` sono documentati nelle loro forme vettoriali. `DATE` usa il sistema data 1900. Funzioni e caratteristiche non elencate qui devono essere considerate non supportate dal valutatore di formule di Aspose.Slides, a meno che non siano documentate separatamente.

## **Calcolare le formule con una cultura preferita**

Alcune funzioni del workbook interpretano il testo secondo regole specifiche della cultura. Ciò è particolarmente importante per le funzioni destinate a lingue che usano set di caratteri a doppio byte (DBCS). Per calcolare correttamente queste formule, creare un [LoadOptions](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/loadoptions/), impostare la cultura preferita con [SpreadsheetOptions.setPreferredCulture](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/spreadsheetoptions/#setPreferredCulture-java.util.Locale-), assegnare le opzioni del foglio tramite [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/loadoptions/#setSpreadsheetOptions-com.aspose.slides.ISpreadsheetOptions-), quindi caricare la presentazione.

L’esempio seguente seleziona la cultura giapponese, apre una presentazione con le opzioni di caricamento configurate e chiama [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) per ogni workbook del grafico:

```java
import com.aspose.slides.*;
import java.util.Locale;

Locale japaneseCulture = Locale.forLanguageTag("ja-JP");

ISpreadsheetOptions spreadsheetOptions = new SpreadsheetOptions();
spreadsheetOptions.setPreferredCulture(japaneseCulture);

LoadOptions loadOptions = new LoadOptions();
loadOptions.setSpreadsheetOptions(spreadsheetOptions);

Presentation presentation = new Presentation("presentation.pptx", loadOptions);
try {
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IChart) {
                IChart chart = (IChart) shape;
                chart.getChartData().getChartDataWorkbook().calculateFormulas();
            }
        }
    }
} finally {
    presentation.dispose();
}
```

La cultura preferita fa parte della configurazione di caricamento della presentazione, quindi specificarla prima di creare l’istanza di [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/). Usare la cultura attesa dalle formule del workbook; ad esempio, usare `ja-JP` per formule che devono seguire le regole di calcolo DBCS giapponesi.

## **Ricalcolo e valori memorizzati**

I file di foglio di calcolo memorizzano comunemente sia la formula sia il suo ultimo valore calcolato. Aspose.Slides può quindi leggere un valore memorizzato da [IChartDataCell.getValue](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ichartdatacell/#getValue--) quando una presentazione è caricata e i dati del grafico non sono stati modificati.

Dopo aver cambiato le celle di input o le formule, non fare affidamento su un risultato memorizzato vecchio. Chiamare [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) prima di leggere i valori calcolati o salvare i dati del grafico che dipendono da essi.

Per le formule al di fuori del sottoinsieme supportato, Aspose.Slides potrebbe non essere in grado di analizzare la formula o di stabilire le sue dipendenze. Se il workbook è stato modificato, il valore memorizzato precedente non può più essere considerato affidabile. In tal caso, la lettura del valore di una cella con dati non supportati può sollevare [CellUnsupportedDataException](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/cellunsupporteddataexception/).

Se il tuo grafico dipende da funzioni Excel che Aspose.Slides non valuta, calcola quelle formule con un motore di foglio di calcolo che le supporta e scrivi i valori risultanti nel workbook del grafico. Non sostituire formule non supportate con valori indovinati.

## **Gestire gli errori di formula**

Esistono due tipologie di problemi da distinguere.

Una formula può essere valida ma produrre un risultato di errore del foglio di calcolo come `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!` o `#VALUE!`. In questo caso, il token di errore è un risultato della cella e può essere restituito tramite [IChartDataCell.getValue](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ichartdatacell/#getValue--).

Una formula può anche fallire durante l’analisi, il riferimento, la dipendenza o a livello di dati supportati. Aspose.Slides fornisce eccezioni specifiche dei fogli di calcolo per questi casi: [CellInvalidFormulaException](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/cellcircularreferenceexception/), e [CellUnsupportedDataException](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/cellunsupporteddataexception/).

Quando le formule provengono da modelli o input dell’utente, gestire queste eccezioni attorno al ricalcolo e all’accesso al valore:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300);
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    IChartDataCell cell = workbook.getCell(0, "A2");
    cell.setFormula("SUM(B2:B5)");

    try {
        workbook.calculateFormulas();
        System.out.println(cell.getValue());
    } catch (CellInvalidFormulaException ex) {
        System.err.println("Invalid formula: " + ex.getMessage());
    } catch (CellInvalidReferenceException ex) {
        System.err.println("Invalid cell reference: " + ex.getMessage());
    } catch (CellCircularReferenceException ex) {
        System.err.println("Circular reference: " + ex.getMessage());
    } catch (CellUnsupportedDataException ex) {
        System.err.println("Unsupported spreadsheet data: " + ex.getMessage());
    }
} finally {
    presentation.dispose();
}
```

## **Limitazioni pratiche**

Il supporto delle formule nei fogli di lavoro dei grafici è destinato a un sottoinsieme definito di calcoli di foglio di calcolo, non a una compatibilità completa con Excel. Tenere presenti queste restrizioni quando si progetta un flusso di lavoro di reporting:

- Utilizzare solo le costanti, gli operatori, i riferimenti e le funzioni documentati quando si desidera che Aspose.Slides ricalcoli le formule.
- Ricalcolare dopo aver modificato le celle da cui dipendono i risultati delle formule.
- Considerare i valori memorizzati delle presentazioni caricate come istantanee, non come sostituti del ricalcolo dopo modifiche.
- Testare le formule dei modelli esistenti prima di fare affidamento sui loro valori calcolati, soprattutto se usano funzioni non presenti nell’elenco documentato.
- Per le formule che richiedono un motore di calcolo completo, calcolarle esternamente e poi aggiornare il workbook del grafico con i valori risultanti.

## **FAQ**

**Qual è la differenza tra [IChartDataCell.setFormula](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-) e [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-)?**

[IChartDataCell.setFormula](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-) memorizza un’espressione in stile A1 come `B2-C2`. [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-) memorizza un’espressione in stile R1C1 come `RC[-2]-RC[-1]`. Usa la notazione che meglio corrisponde al modo in cui generi o copi le formule.

**Devo leggere la cella stessa o il suo valore dopo il calcolo?**

[IChartDataWorkbook.getCell](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ichartdataworkbook/#getCell-int-java.lang.String-) restituisce un [IChartDataCell](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ichartdatacell/). Per ottenere il risultato calcolato, chiamare il metodo [IChartDataCell.getValue](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ichartdatacell/#getValue--) della cella dopo il ricalcolo.

**Quando devo chiamare [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ichartdataworkbook/#calculateFormulas--)?**

Chiamare [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) dopo aver modificato i valori di input o le formule e prima di dipendere dai risultati calcolati. Questo aggiorna i valori delle formule supportate dal valutatore integrato.

**Aspose.Slides supporta tutte le funzioni Excel?**

No. Il valutatore integrato supporta un sottoinsieme documentato di funzioni. Le funzioni al di fuori di quel sottoinsieme non dovrebbero essere considerate ricalcolabili correttamente. Se è necessaria la piena compatibilità delle formule Excel, eseguire il calcolo con un motore di foglio di calcolo appropriato e scrivere i valori finali nel workbook del grafico.

** Cosa accade se una presentazione caricata contiene una formula non supportata?**

Se i dati del grafico non sono stati modificati, il workbook può ancora contenere un valore memorizzato calcolato in precedenza. Dopo che i dati correlati sono stati modificati, quel valore memorizzato potrebbe non essere più valido. L’accesso a una cella la cui formula non può essere gestita può sollevare [CellUnsupportedDataException](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/cellunsupporteddataexception/).

**I valori di errore delle formule sono gli stessi delle eccezioni Java?**

No. Un risultato come `#DIV/0!` è un valore del foglio di calcolo prodotto da una valutazione valida. Le eccezioni come [CellInvalidFormulaException](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/cellinvalidformulaexception/) o [CellCircularReferenceException](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/cellcircularreferenceexception/) indicano che la formula non può essere elaborata normalmente.

**Un grafico si aggiorna automaticamente quando cambia una cella di formula?**

Una serie del grafico può fare riferimento a celle del workbook. Ricalcolare prima il workbook, quindi salvare o renderizzare la presentazione. Se i punti dati del grafico fanno riferimento alle celle calcolate, il grafico utilizza quei valori aggiornati; non è necessario un metodo di aggiornamento separato per questo flusso.

**I grafici possono usare un workbook Excel esterno?**

Sì, i dati del grafico possono essere configurati per utilizzare un workbook esterno tramite l’API dei dati del grafico. Tuttavia, il flusso di lavoro di calcolo delle formule descritto in questo articolo riguarda il workbook dei dati del grafico e il sottoinsieme di formule valutato da Aspose.Slides. Non presumere che [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) fornisca un ricalcolo completo di formule arbitrarie in un file XLSX esterno.

**Posso usare formule che fanno riferimento a un altro foglio o workbook?**

I riferimenti in stile Excel possono esistere nei workbook dei grafici, ma la valutazione delle formule è limitata dal parser e dal set di funzioni supportati. Se è essenziale un riferimento incrociato di foglio o esterno, verificare quella formula specifica con la versione di Aspose.Slides in uso. Per flussi che richiedono ampia compatibilità dei riferimenti Excel, calcolare il workbook esternamente e scrivere i valori risolti nei dati del grafico.

**Le stringhe di formula devono iniziare con `=`?**

Gli esempi API di Aspose.Slides assegnano espressioni come `B2-C2` o `SUM(B2:B5)` senza un `=` iniziale. Usare questa forma mantiene le formule generate coerenti con gli esempi documentati dell’API.
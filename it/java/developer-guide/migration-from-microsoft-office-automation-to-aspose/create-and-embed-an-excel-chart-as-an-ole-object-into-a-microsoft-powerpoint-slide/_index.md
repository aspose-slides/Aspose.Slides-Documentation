---
title: Crea e incorpora grafici Excel come oggetti OLE utilizzando VSTO e Aspose.Slides per Java
linktitle: Crea e incorpora grafici Excel come oggetti OLE
type: docs
weight: 60
url: /it/java/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/
keywords:
- crea grafico
- incorpora grafico Excel
- oggetto OLE
- migrazione
- VSTO
- automazione Office
- PowerPoint
- presentazione
- Java
- Aspose.Slides
description: "Migra dall'automazione Microsoft Office ad Aspose.Slides per Java e incorpora grafici Excel come oggetti OLE nelle diapositive PowerPoint (PPT, PPTX) in Java."
---
{{% alert color="info" %}} 
I grafici sono rappresentazioni visive dei tuoi dati e sono ampiamente usati nelle diapositive di presentazione. Questo articolo ti mostrerà il codice per creare e incorporare un grafico Excel come oggetto OLE in una diapositiva PowerPoint in modo programmatico, utilizzando [VSTO](/slides/it/java/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/) e [Aspose.Slides for Java](/slides/it/java/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/).
{{% /alert %}} 
## **Creazione e incorporamento di un grafico Excel**
I due esempi di codice seguenti sono lunghi e dettagliati perché il compito che descrivono è complesso. Crei una cartella di lavoro Microsoft Excel, crei un grafico e poi crei la presentazione Microsoft PowerPoint in cui incorporerai il grafico. Gli oggetti OLE contengono collegamenti al documento originale, quindi un utente che fa doppio clic sul file incorporato avvierà il file e la sua applicazione.
### **Esempio VSTO**
Utilizzando VSTO, vengono eseguiti i seguenti passaggi:

1. Crea un'istanza dell'oggetto Microsoft Excel ApplicationClass.
1. Crea una nuova cartella di lavoro con un foglio.
1. Aggiungi un grafico al foglio.
1. Salva la cartella di lavoro.
1. Apri la cartella di lavoro Excel contenente il foglio di lavoro con i dati del grafico.
1. Ottieni la raccolta ChartObjects per il foglio.
1. Ottieni il grafico da copiare.
1. Crea una presentazione Microsoft PowerPoint.
1. Aggiungi una diapositiva vuota alla presentazione.
1. Copia il grafico dal foglio Excel negli appunti.
1. Incolla il grafico nella presentazione PowerPoint.
1. Posiziona il grafico sulla diapositiva.
1. Salva la presentazione.

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-CreateAndEmbedExcelChartAsOLEUsingVSTO.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-SetCellValue.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-CreateNewChartInExcel.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-UseCopyPaste.cs" >}}
### **Esempio Aspose.Slides per Java**
Utilizzando Aspose.Slides per .NET, vengono eseguiti i seguenti passaggi:

1. Crea una cartella di lavoro utilizzando Aspose.Cells per Java.
1. Crea un grafico Microsoft Excel.
1. Imposta le dimensioni OLE del grafico Excel.
1. Ottieni un'immagine del grafico.
1. Incorpora il grafico Excel come oggetto OLE all'interno della presentazione PPTX utilizzando Aspose.Slides per Java.
1. Sostituisci l'immagine dell'oggetto modificato con l'immagine ottenuta al passaggio 3 per gestire il problema dell'oggetto modificato.
1. Scrivi la presentazione di output su disco in formato PPTX.

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EmbedChartAsOLEObject-EmbedChartAsOLEObject.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EmbedChartAsOLEObject-AddExcelChartInPresentation.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EmbedChartAsOLEObject-AddExcelChartInWorkbook.java" >}}
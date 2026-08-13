---
title: Creare grafici usando VSTO e Aspose.Slides per Java
linktitle: Crea grafico
type: docs
weight: 70
url: /it/java/create-a-chart-in-a-microsoft-powerpoint-presentation/
keywords:
- creare grafico
- migrazione
- VSTO
- automazione Office
- PowerPoint
- presentazione
- Java
- Aspose.Slides
description: "Scopri come automatizzare la creazione di grafici PowerPoint in Java. Questa guida passo passo mostra perché Aspose.Slides per Java è un'alternativa più veloce e più potente a Microsoft.Office.Interop."
---
{{% alert color="info" %}} 

 I grafici sono rappresentazioni visive dei dati ampiamente utilizzati nelle presentazioni. Questo articolo mostra il codice per creare un grafico in Microsoft PowerPoint in modo programmatico utilizzando [VSTO](/slides/it/java/create-a-chart-in-a-microsoft-powerpoint-presentation/) e [Aspose.Slides for Java](/slides/it/java/create-a-chart-in-a-microsoft-powerpoint-presentation/).

{{% /alert %}} 
## **Creare un grafico**
Il codice di esempio di seguito descrive il processo di aggiunta di un semplice grafico a colonne raggruppate 3D usando VSTO. Crei un'istanza di presentazione, aggiungi un grafico predefinito. Quindi utilizzi un foglio di lavoro Microsoft Excel per accedere e modificare i dati del grafico insieme all'impostazione delle proprietà del grafico. Infine, salvi la presentazione.
### **Esempio VSTO**
Utilizzando VSTO, vengono eseguiti i seguenti passaggi:

1. Creare un'istanza di una presentazione Microsoft PowerPoint.
1. Aggiungere una diapositiva vuota alla presentazione.
1. Aggiungere un grafico **a colonne raggruppate 3D** e accedervi.
1. Creare una nuova istanza di Microsoft Excel Workbook e caricare i dati del grafico.
1. Accedere al foglio di dati del grafico utilizzando l'istanza Microsoft Excel Workbook instancefromworkbook.
1. Impostare l'intervallo del grafico nel foglio di lavoro e rimuovere le serie 2 e 3 dal grafico.
1. Modificare i dati delle categorie del grafico nel foglio di dati del grafico.
1. Modificare i dati della serie 1 del grafico nel foglio di dati del grafico.
1. Ora, accedere al titolo del grafico e impostare le proprietà del carattere correlate.
1. Accedere all'asse dei valori del grafico e impostare l'unità principale, le unità secondarie, il valore massimo e i valori minimi.
1. Accedere all'asse di profondità o di serie del grafico e rimuoverlo, poiché in questo esempio è utilizzata solo una serie.
1. Ora, impostare gli angoli di rotazione del grafico nelle direzioni X e Y.
1. Salvare la presentazione.
1. Chiudere le istanze di Microsoft Excel e PowerPoint.

**La presentazione di output, creata con VSTO** 

![todo:image_alt_text](create-a-chart-in-a-microsoft-powerpoint-presentation_1.png)



{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-VSTOChart-VSTOChart.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-VSTOChart-EnsurePowerPointIsRunning.cs" >}}
### **Esempio Aspose.Slides per Java**
Utilizzando Aspose.Slides per Java, vengono eseguiti i seguenti passaggi:

1. Creare un'istanza di una presentazione Microsoft PowerPoint.
1. Aggiungere una diapositiva vuota alla presentazione.
1. Aggiungere un grafico **a colonne raggruppate 3D** e accedervi.
1. Accedere al foglio di dati del grafico utilizzando una istanza Microsoft Excel Workbook instancefromworkbook.
1. Rimuovere le serie inutilizzate 2 e 3.
1. Accedere alle categorie del grafico e modificare le etichette.
1. Accedere alla serie 1 e modificare i valori della serie.
1. Ora, accedere al titolo del grafico e impostare le proprietà del carattere.
1. Accedere all'asse dei valori del grafico e impostare l'unità principale, le unità secondarie, il valore massimo e i valori minimi.
1. Ora, impostare gli angoli di rotazione del grafico nelle direzioni X e Y.
1. Salvare la presentazione in formato PPTX.

**La presentazione di output, creata con Aspose.Slides** 

![todo:image_alt_text](create-a-chart-in-a-microsoft-powerpoint-presentation_2.png)

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-CreateChart-CreateChart.java" >}}

## **FAQ**

### Posso creare altri tipi di grafici, come torta, linea o barre, con Aspose.Slides?

Sì. Aspose.Slides supporta un'ampia gamma di [tipi di grafico](/slides/it/java/create-chart/), inclusi grafici a torta, grafici a linee, grafici a barre, diagrammi a dispersione, grafici a bolle e altro. È possibile specificare il tipo di grafico desiderato utilizzando la classe [ChartType](https://reference.aspose.com/slides/it/java/com.aspose.slides/charttype/) quando si aggiunge un grafico.

### Posso applicare stili o temi personalizzati al grafico?

Sì. È possibile personalizzare completamente l'aspetto del grafico, inclusi colori, caratteri, riempimenti, contorni, linee di griglia e layout. Tuttavia, l'applicazione dei temi di Office esattamente come visualizzati in PowerPoint richiede di impostare manualmente gli stili individuali.

### Posso esportare il grafico come immagine separata dalla diapositiva?

Sì, Aspose.Slides consente di esportare qualsiasi forma—inclusi i grafici—come immagine separata (ad es., PNG, JPEG) utilizzando il metodo `getImage` sul [shape](https://reference.aspose.com/slides/it/java/com.aspose.slides/shape/).
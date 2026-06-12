---
title: Creare grafici usando VSTO e Aspose.Slides per Java
linktitle: Creare grafico
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
description: "Scopri come automatizzare la creazione di grafici PowerPoint in Java. Questa guida passo-passo mostra perché Aspose.Slides per Java è un'alternativa più veloce e potente a Microsoft.Office.Interop."
---
{{% alert color="primary" %}} 

I grafici sono rappresentazioni visuali dei dati ampiamente utilizzate nelle presentazioni. Questo articolo mostra il codice per creare un grafico in Microsoft PowerPoint in modo programmatico utilizzando [VSTO](/slides/it/java/create-a-chart-in-a-microsoft-powerpoint-presentation/) e [Aspose.Slides for Java](/slides/it/java/create-a-chart-in-a-microsoft-powerpoint-presentation/).

{{% /alert %}} 
## **Creare un grafico**
Gli esempi di codice di seguito descrivono il processo di aggiunta di un semplice grafico a colonne raggruppate 3D utilizzando VSTO. Crei un'istanza di una presentazione, aggiungi un grafico predefinito. Quindi utilizzi il workbook di Microsoft Excel per accedere e modificare i dati del grafico insieme all'impostazione delle proprietà del grafico. Infine, salvi la presentazione.
### **Esempio VSTO**
Utilizzando VSTO, vengono eseguiti i seguenti passaggi:

1. Crea un'istanza di una presentazione Microsoft PowerPoint.  
1. Aggiungi una diapositiva vuota alla presentazione.  
1. Aggiungi un grafico **3D clustered column** e accedi ad esso.  
1. Crea una nuova istanza di Microsoft Excel Workbook e carica i dati del grafico.  
1. Accedi al foglio di lavoro dei dati del grafico utilizzando l'istanza Microsoft Excel Workbook instancefromworkbook.  
1. Imposta l'intervallo del grafico nel foglio di lavoro e rimuovi le serie 2 e 3 dal grafico.  
1. Modifica i dati delle categorie del grafico nel foglio di lavoro dei dati del grafico.  
1. Modifica i dati della serie 1 del grafico nel foglio di lavoro dei dati del grafico.  
1. Ora, accedi al titolo del grafico e imposta le proprietà del carattere correlate.  
1. Accedi all'asse dei valori del grafico e imposta l'unità principale, le unità minori, il valore massimo e i valori minimi.  
1. Accedi all'asse di profondità (o di serie) del grafico e rimuovilo, poiché in questo esempio è utilizzata solo una serie.  
1. Ora, imposta gli angoli di rotazione del grafico nelle direzioni X e Y.  
1. Salva la presentazione.  
1. Chiudi le istanze di Microsoft Excel e PowerPoint.  

**La presentazione di output, creata con VSTO** 

![todo:image_alt_text](create-a-chart-in-a-microsoft-powerpoint-presentation_1.png)



{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-VSTOChart-VSTOChart.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-VSTOChart-EnsurePowerPointIsRunning.cs" >}}
### **Esempio Aspose.Slides for Java**
Utilizzando Aspose.Slides for Java, vengono eseguiti i seguenti passaggi:

1. Crea un'istanza di una presentazione Microsoft PowerPoint.  
1. Aggiungi una diapositiva vuota alla presentazione.  
1. Aggiungi un grafico **3D clustered column** e accedi ad esso.  
1. Accedi al foglio di lavoro dei dati del grafico utilizzando un'istanza Microsoft Excel Workbook instancefromworkbook.  
1. Rimuovi le serie inutilizzate 2 e 3.  
1. Accedi alle categorie del grafico e modifica le etichette.  
1. Accedi alla serie 1 e modifica i valori della serie.  
1. Ora, accedi al titolo del grafico e imposta le proprietà del carattere.  
1. Accedi all'asse dei valori del grafico e imposta l'unità principale, le unità minori, il valore massimo e i valori minimi.  
1. Ora, imposta gli angoli di rotazione del grafico nelle direzioni X e Y.  
1. Salva la presentazione in formato PPTX.  

**La presentazione di output, creata con Aspose.Slides** 

![todo:image_alt_text](create-a-chart-in-a-microsoft-powerpoint-presentation_2.png)

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-CreateChart-CreateChart.java" >}}

## **FAQ**

**Posso creare altri tipi di grafici come a torta, a linee o a barre con Aspose.Slides?**

Sì. Aspose.Slides supporta una vasta gamma di [tipi di grafico](/slides/it/java/create-chart/), inclusi grafici a torta, grafici a linee, grafici a barre, diagrammi a dispersione, grafici a bolle e molto altro. È possibile specificare il tipo di grafico desiderato utilizzando la classe [ChartType](https://reference.aspose.com/slides/it/java/com.aspose.slides/charttype/) quando si aggiunge un grafico.

**Posso applicare stili o temi personalizzati al grafico?**

Sì. È possibile personalizzare completamente l'aspetto del grafico, inclusi colori, caratteri, riempimenti, contorni, linee della griglia e layout. Tuttavia, l'applicazione dei temi di Office esattamente come visualizzati in PowerPoint richiede la configurazione manuale dei singoli stili.

**Posso esportare il grafico come immagine separata dalla diapositiva?**

Sì, Aspose.Slides consente di esportare qualsiasi forma — inclusi i grafici — come immagine separata (ad es., PNG, JPEG) utilizzando il metodo `getImage` sulla [shape](https://reference.aspose.com/slides/it/java/com.aspose.slides/shape/) del grafico.
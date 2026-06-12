---
title: Formattare il testo con VSTO e Aspose.Slides per Java
linktitle: Formattare il testo
type: docs
weight: 30
url: /it/java/format-text-using-vsto-and-aspose-slides-for-java/
keywords:
- formattare il testo
- migrazione
- VSTO
- automazione Office
- PowerPoint
- presentazione
- Java
- Aspose.Slides
description: "Migra dall'automazione di Microsoft Office ad Aspose.Slides per Java e formatta il testo nelle presentazioni PowerPoint (PPT, PPTX) con un controllo preciso."
---
{{% alert color="primary" %}} 

A volte, è necessario formattare il testo nelle diapositive programmaticamente. Questo articolo mostra come leggere una presentazione di esempio con del testo nella prima diapositiva utilizzando sia [VSTO](/slides/it/java/format-text-using-vsto-and-aspose-slides-for-java/) e [Aspose.Slides for Java](/slides/it/java/format-text-using-vsto-and-aspose-slides-for-java/). Il codice formatta il testo nella terza casella di testo della diapositiva in modo che assomigli al testo nell'ultima casella di testo.

{{% /alert %}} 
## **Formattazione del testo**
Sia i metodi VSTO che Aspose.Slides eseguono i seguenti passaggi:

1. Apri la presentazione di origine.
1. Accedi alla prima diapositiva.
1. Accedi alla terza casella di testo.
1. Modifica la formattazione del testo nella terza casella di testo.
1. Salva la presentazione su disco.

Gli screenshot seguenti mostrano la diapositiva di esempio prima e dopo l'esecuzione del codice VSTO e Aspose.Slides per Java.

**La presentazione di input** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-for-java_1.png)
### **Esempio di codice VSTO**
Il codice seguente mostra come riformattare il testo su una diapositiva utilizzando VSTO.

**Il testo riformattato con VSTO** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-for-java_2.png)

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-FormatTextUsingVSTO-FormatTextUsingVSTO.cs" >}}


### **Esempio di Aspose.Slides per Java**
Per formattare il testo con Aspose.Slides, aggiungi il font prima di formattare il testo.

**La presentazione di output creata con Aspose.Slides** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-for-java_3.png)

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Text-FormatText-FormatText.java" >}}
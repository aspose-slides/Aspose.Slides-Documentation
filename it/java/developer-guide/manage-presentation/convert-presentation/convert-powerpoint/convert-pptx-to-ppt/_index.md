---
title: Converti PPTX in PPT in Java
linktitle: PPTX in PPT
type: docs
weight: 21
url: /it/java/convert-pptx-to-ppt/
keywords:
- converti PowerPoint
- converti presentazione
- converti diapositiva
- converti PPTX
- PPTX in PPT
- salva PPTX come PPT
- esporta PPTX in PPT
- PowerPoint
- presentazione
- Java
- Aspose.Slides
description: "Converti facilmente PPTX in PPT con Aspose.Slides per Java—garantisce una compatibilità senza soluzione di continuità con i formati PowerPoint, preservando il layout e la qualità della tua presentazione."
---
## **Panoramica**

Questo articolo spiega come convertire una presentazione PowerPoint in formato PPTX in formato PPT utilizzando Java. L'argomento seguente è trattato.

- Convertire PPTX in PPT in Java

## **Convertire PPTX in PPT in Java**

Per il codice di esempio Java per convertire PPTX in PPT, consultare la sezione sottostante, ovvero [Convertire PPTX in PPT](#convert-pptx-to-ppt). Carica semplicemente il file PPTX e lo salva in formato PPT. Specificando formati di salvataggio diversi, è inoltre possibile salvare il file PPTX in molti altri formati come PDF, XPS, ODP, HTML ecc., come discusso in questi articoli.

- [Convertire PPTX in PDF in Java](/slides/it/java/convert-powerpoint-to-pdf/)
- [Convertire PPTX in XPS in Java](/slides/it/java/convert-powerpoint-to-xps/)
- [Convertire PPTX in HTML in Java](/slides/it/java/convert-powerpoint-to-html/)
- [Convertire PPTX in ODP in Java](/slides/it/java/save-presentation/)
- [Convertire PPTX in PNG in Java](/slides/it/java/convert-powerpoint-to-png/)

## **Convertire PPTX in PPT**
Per convertire un PPTX in PPT, basta passare il nome del file e il formato di salvataggio al metodo **Save** della classe [**Presentation**](https://reference.aspose.com/slides/it/java/com.aspose.slides/Presentation). Il campione di codice Java sottostante converte una Presentazione da PPTX a PPT usando le opzioni predefinite.

```java
// istanziare un oggetto Presentation che rappresenta un file PPTX
Presentation presentation = new Presentation("template.pptx");

// salva la presentazione come PPT
presentation.save("output.ppt", SaveFormat.Ppt);  
```

## **FAQ**

**Tutti gli effetti e le funzionalità di PPTX vengono mantenuti quando si salva nel formato legacy PPT (97–2003)?**

Non sempre. Il formato PPT manca di alcune capacità più recenti (ad esempio, certi effetti, oggetti e comportamenti), quindi le funzionalità possono essere semplificate o rasterizzate durante la conversione.

**Posso convertire solo le diapositive selezionate in PPT anziché l'intera presentazione?**

Il salvataggio diretto riguarda l'intera presentazione. Per convertire diapositive specifiche, creare una nuova presentazione contenente solo quelle diapositive e salvarla come PPT; in alternativa, utilizzare un servizio/API che supporti parametri di conversione per diapositiva.

**Le presentazioni protette da password sono supportate?**

Sì. È possibile rilevare se un file è protetto, aprirlo con una password e anche [configurare le impostazioni di protezione/cifratura](/slides/it/java/password-protected-presentation/) per il PPT salvato.
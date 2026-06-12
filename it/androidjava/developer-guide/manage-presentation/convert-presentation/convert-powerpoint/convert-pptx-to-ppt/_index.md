---
title: Converti PPTX in PPT su Android
linktitle: PPTX in PPT
type: docs
weight: 21
url: /it/androidjava/convert-pptx-to-ppt/
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
- Android
- Java
- Aspose.Slides
description: "Converti facilmente PPTX in PPT con Aspose.Slides per Android tramite Java—garantisci una compatibilità senza interruzioni con i formati PowerPoint mantenendo la disposizione e la qualità della tua presentazione."
---
## **Panoramica**

Questo articolo spiega come convertire una presentazione PowerPoint in formato PPTX in formato PPT utilizzando Java. È trattato il seguente argomento.

- Converti PPTX in PPT con Java

## **Converti PPTX in PPT su Android**

Per il codice di esempio Java per convertire PPTX in PPT, consultare la sezione seguente, ovvero [Converti PPTX in PPT](#convert-pptx-to-ppt). Carica semplicemente il file PPTX e lo salva in formato PPT. Specificando diversi formati di salvataggio, è inoltre possibile salvare il file PPTX in molti altri formati come PDF, XPS, ODP, HTML, ecc., come discusso in questi articoli. 

- [Converti PPTX in PDF su Android](/slides/it/androidjava/convert-powerpoint-to-pdf/)
- [Converti PPTX in XPS su Android](/slides/it/androidjava/convert-powerpoint-to-xps/)
- [Converti PPTX in HTML su Android](/slides/it/androidjava/convert-powerpoint-to-html/)
- [Converti PPTX in ODP su Android](/slides/it/androidjava/save-presentation/)
- [Converti PPTX in PNG su Android](/slides/it/androidjava/convert-powerpoint-to-png/)

## **Converti PPTX in PPT**
Per convertire un PPTX in PPT basta passare il nome del file e il formato di salvataggio al metodo **Save** della classe [**Presentation**](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/Presentation). Il codice di esempio Java qui sotto converte una Presentazione da PPTX a PPT utilizzando le opzioni predefinite.

```java
// istanzia un oggetto Presentation che rappresenta un file PPTX
Presentation presentation = new Presentation("template.pptx");

// salva la presentazione in formato PPT
presentation.save("output.ppt", SaveFormat.Ppt);  
```

## **FAQ**

**Tutti gli effetti e le funzionalità di PPTX vengono conservati quando si salva nel formato legacy PPT (97–2003)?**

Non sempre. Il formato PPT non supporta alcune delle funzionalità più recenti (ad es., alcuni effetti, oggetti e comportamenti), quindi le caratteristiche possono essere semplificate o rasterizzate durante la conversione.

**Posso convertire solo le diapositive selezionate in PPT invece dell'intera presentazione?**

Il salvataggio diretto riguarda l'intera presentazione. Per convertire diapositive specifiche, crea una nuova presentazione contenente solo quelle diapositive e salvala come PPT; in alternativa, utilizza un servizio/API che supporta parametri di conversione per diapositiva.

**Le presentazioni protette da password sono supportate?**

Sì. È possibile rilevare se un file è protetto, aprirlo con una password e anche [configurare le impostazioni di protezione/crittografia](/slides/it/androidjava/password-protected-presentation/) per il PPT salvato.
---
title: Converti PPTX in PPT in PHP
linktitle: PPTX in PPT
type: docs
weight: 21
url: /it/php-java/convert-pptx-to-ppt/
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
- PHP
- Aspose.Slides
description: "Converti facilmente PPTX in PPT con Aspose.Slides — garantisci una compatibilità fluida con i formati PowerPoint preservando la struttura e la qualità della tua presentazione."
---
## **Panoramica**

Questo articolo spiega come convertire una presentazione PowerPoint in formato PPTX in formato PPT usando PHP. È coperto il seguente argomento.

- Converti PPTX in PPT

## **Converti PPTX in PPT in PHP**

Per il codice di esempio Java per convertire PPTX in PPT, consultare la sezione seguente, ovvero [Converti PPTX in PPT](#convert-pptx-to-ppt). Carica semplicemente il file PPTX e lo salva in formato PPT. Specificando diversi formati di salvataggio, è possibile salvare il file PPTX in molti altri formati come PDF, XPS, ODP, HTML, ecc., come discusso in questi articoli. 

- [Converti PPTX in PDF in PHP](/slides/it/php-java/convert-powerpoint-to-pdf/)
- [Converti PPTX in XPS in PHP](/slides/it/php-java/convert-powerpoint-to-xps/)
- [Converti PPTX in HTML in PHP](/slides/it/php-java/convert-powerpoint-to-html/)
- [Converti PPTX in ODP in PHP](/slides/it/php-java/save-presentation/)
- [Converti PPTX in PNG in PHP](/slides/it/php-java/convert-powerpoint-to-png/)

## **Converti PPTX in PPT**
Per convertire un PPTX in PPT, basta passare il nome file e il formato di salvataggio al metodo **Save** della classe [**Presentation**](https://reference.aspose.com/slides/it/php-java/aspose.slides/Presentation). Il esempio di codice PHP seguente converte una Presentation da PPTX a PPT usando le opzioni predefinite.

```php
  # istanzia un oggetto Presentation che rappresenta un file PPTX
  $presentation = new Presentation("template.pptx");
  # salva la presentazione come PPT
  $presentation->save("output.ppt", SaveFormat::Ppt);
```

## **FAQ**

**Tutti gli effetti e le funzionalità PPTX sopravvivono quando si salva nel formato legacy PPT (97–2003)?**

Non sempre. Il formato PPT non supporta alcune capacità più recenti (ad esempio, certi effetti, oggetti e comportamenti), quindi le funzionalità possono essere semplificate o rasterizzate durante la conversione.

**Posso convertire solo le diapositive selezionate in PPT invece dell'intera presentazione?**

Il salvataggio diretto riguarda l'intera presentazione. Per convertire diapositive specifiche, creare una nuova presentazione contenente solo quelle diapositive e salvarla come PPT; in alternativa, utilizzare un servizio/API che supporta parametri di conversione per diapositiva.

**Le presentazioni protette da password sono supportate?**

Sì. È possibile rilevare se un file è protetto, aprirlo con una password e anche [configurare le impostazioni di protezione/cifratura](/slides/it/php-java/password-protected-presentation/) per il PPT salvato.
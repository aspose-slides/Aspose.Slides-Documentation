---
title: Converti PPTX in PPT in .NET
linktitle: PPTX in PPT
type: docs
weight: 21
url: /it/net/convert-pptx-to-ppt/
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
- .NET
- C#
- Aspose.Slides
description: "Converti facilmente PPTX in PPT con Aspose.Slides per .NET—garantisci una compatibilità senza problemi con i formati PowerPoint mantenendo la struttura e la qualità della tua presentazione."
---
## **Panoramica**

Questo articolo spiega come convertire una presentazione PowerPoint in formato PPTX in formato PPT usando C#. L'argomento seguente è trattato.

- Convertire PPTX in PPT in C#

## **Convertire PPTX in PPT in .NET**

Per il codice di esempio C# per convertire PPTX in PPT, si veda la sezione seguente, cioè [Convert PPTX to PPT](#convert-pptx-to-ppt). Carica semplicemente il file PPTX e lo salva in formato PPT. Specificando formati di salvataggio diversi, è possibile salvare il file PPTX anche in molti altri formati come PDF, XPS, ODP, HTML, ecc., come discusso in questi articoli. 

- [Converti PPTX in PDF in .NET](/slides/it/net/convert-powerpoint-to-pdf/)
- [Converti PPTX in XPS in .NET](/slides/it/net/convert-powerpoint-to-xps/)
- [Converti PPTX in HTML in .NET](/slides/it/net/convert-powerpoint-to-html/)
- [Converti PPTX in ODP in .NET](/slides/it/net/save-presentation/)
- [Converti PPTX in PNG in .NET](/slides/it/net/convert-powerpoint-to-png/)

## **Convertire PPTX in PPT**
Per convertire un PPTX in PPT basta passare il nome del file e il formato di salvataggio al metodo [**Save**](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/save/) della classe [**Presentation**](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/) . Il campione di codice C# qui sotto converte una Presentation da PPTX a PPT usando le opzioni predefinite.

```c#
// Istanzia un oggetto Presentation che rappresenta un file PPTX
Presentation pres = new Presentation("presentation.pptx");

// Salvataggio della presentazione PPTX in formato PPT
pres.Save("presentation.ppt", SaveFormat.Ppt);
```

## **FAQ**

**Tutti gli effetti e le funzionalità PPTX vengono preservati quando si salva nel formato legacy PPT (97–2003)?**

Non sempre. Il formato PPT non supporta alcune delle capacità più recenti (ad es., certi effetti, oggetti e comportamenti), quindi le funzionalità possono essere semplificate o rasterizzate durante la conversione.

**Posso convertire solo le diapositive selezionate in PPT invece dell'intera presentazione?**

Il salvataggio diretto riguarda l'intera presentazione. Per convertire diapositive specifiche, creare una nuova presentazione contenente solo quelle diapositive e salvarla come PPT; in alternativa, utilizzare un servizio/API che supporta parametri di conversione per diapositiva.

**Le presentazioni protette da password sono supportate?**

Sì. È possibile rilevare se un file è protetto, aprirlo con una password e anche [configure protection/encryption settings](/slides/it/net/password-protected-presentation/) per il PPT salvato.
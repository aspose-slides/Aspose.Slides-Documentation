---
title: Converti PPTX in PPT con C++
linktitle: PPTX in PPT
type: docs
weight: 21
url: /it/cpp/convert-pptx-to-ppt/
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
- C++
- Aspose.Slides
description: "Converti facilmente PPTX in PPT con Aspose.Slides per C++—garantisci una compatibilità senza soluzione di continuità con i formati PowerPoint mantenendo la disposizione e la qualità della tua presentazione."
---
## **Panoramica**

Questo articolo spiega come convertire una presentazione PowerPoint in formato PPTX in formato PPT utilizzando C++. L'argomento seguente è trattato.

- Converti PPTX in PPT in C++

## **Converti PPTX in PPT in C++**

Per il codice di esempio C++ per convertire PPTX in PPT, vedere la sezione seguente, ovvero [Converti PPTX in PPT](#convert-pptx-to-ppt). Carica semplicemente il file PPTX e lo salva in formato PPT. Specificando formati di salvataggio diversi, è possibile salvare il file PPTX anche in molti altri formati come PDF, XPS, ODP, HTML, ecc., come discusso in questi articoli. 

- [Converti PPTX in PDF in C++](/slides/it/cpp/convert-powerpoint-to-pdf/)
- [Converti PPTX in XPS in C++](/slides/it/cpp/convert-powerpoint-to-xps/)
- [Converti PPTX in HTML in C++](/slides/it/cpp/convert-powerpoint-to-html/)
- [Converti PPTX in ODP in C++](/slides/it/cpp/save-presentation/)
- [Converti PPTX in PNG in C++](/slides/it/cpp/convert-powerpoint-to-png/)

## **Converti PPTX in PPT**
Per convertire un PPTX in PPT basta passare il nome del file e il formato di salvataggio al metodo **Save** della classe [**Presentation**](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.presentation/). Il seguente esempio di codice C++ converte una Presentation da PPTX a PPT utilizzando le opzioni predefinite.

```cpp
// Carica il PPTX.
SharedPtr<Presentation> prs = MakeObject<Presentation>(u"sourceFile.pptx");

// Salva in formato PPT.
prs->Save(u"convertedFile.ppt", Aspose::Slides::Export::SaveFormat::Ppt);
```

## **FAQ**

**Tutti gli effetti e le funzionalità di PPTX sono mantenuti quando si salva nel formato legacy PPT (97–2003)?**

Non sempre. Il formato PPT non supporta alcune delle funzionalità più recenti (ad esempio, determinati effetti, oggetti e comportamenti), quindi le caratteristiche possono essere semplificate o rasterizzate durante la conversione.

**Posso convertire solo le diapositive selezionate in PPT invece dell'intera presentazione?**

Il salvataggio diretto riguarda l'intera presentazione. Per convertire diapositive specifiche, creare una nuova presentazione contenente solo quelle diapositive e salvarla come PPT; in alternativa, utilizzare un servizio/API che supporti parametri di conversione per diapositiva.

**Le presentazioni protette da password sono supportate?**

Sì. È possibile rilevare se un file è protetto, aprirlo con una password e anche [configurare le impostazioni di protezione/cifratura](/slides/it/cpp/password-protected-presentation/) per il PPT salvato.
---
title: Converti PPTX in PPT con Python
linktitle: PPTX in PPT
type: docs
weight: 21
url: /it/python-net/convert-pptx-to-ppt/
keywords:
- PPTX in PPT
- converti PPTX in PPT
- converti PowerPoint
- converti presentazione
- Python
- Aspose.Slides
description: "Converti facilmente PPTX in PPT con Aspose.Slides per Python via .NET—garantisce una compatibilità senza soluzione di continuità con i formati PowerPoint mantenendo il layout e la qualità della tua presentazione."
---
## **Panoramica**

Aspose.Slides for Python consente di convertire presentazioni PPTX moderne nel formato legacy PPT interamente tramite codice. Apri un PPTX ed esportalo come PPT mantenendo il contenuto e il layout della presentazione, rendendo il risultato compatibile con versioni precedenti di PowerPoint. Lo stesso flusso di lavoro può generare altri output, come PDF, XPS, ODP, HTML o immagini, così si integra perfettamente in script, pipeline CI e elaborazione batch.

## **Converti PPTX in PPT**

Per convertire un PPTX in PPT, basta passare il nome del file e il formato di salvataggio al metodo [save](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/save/) della classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/). L'esempio Python qui sotto converte una presentazione da PPTX a PPT usando le opzioni predefinite.

```py
import aspose.slides as slides

# Istanzia la classe Presentation che rappresenta un file PPTX.
presentation = slides.Presentation("presentation.pptx")

# Salva la presentazione come file PPT.
presentation.save("presentation.ppt", slides.export.SaveFormat.PPT)
```

## **FAQ**

**Tutti gli effetti e le funzionalità di PPTX vengono mantenuti quando si salva nel formato legacy PPT (97–2003)?**

Non sempre. Il formato PPT non supporta alcune funzionalità più recenti (ad esempio certi effetti, oggetti e comportamenti), quindi le funzionalità possono essere semplificate o rasterizzate durante la conversione.

**Posso convertire solo le diapositive selezionate in PPT anziché l'intera presentazione?**

Il salvataggio diretto riguarda l'intera presentazione. Per convertire diapositive specifiche, crea una nuova presentazione contenente solo quelle diapositive e salvala come PPT; in alternativa, usa un servizio/API che supporta parametri di conversione per diapositiva.

**Le presentazioni protette da password sono supportate?**

Sì. È possibile rilevare se un file è protetto, aprirlo con una password e anche [configure protection/encryption settings](/slides/it/python-net/password-protected-presentation/) per il PPT salvato.

**Vedi anche:**
- [Converti PPT e PPTX in PDF con Python | Opzioni avanzate](/slides/it/python-net/convert-powerpoint-to-pdf/)
- [Converti presentazioni PowerPoint in XPS con Python](/slides/it/python-net/convert-powerpoint-to-xps/)
- [Converti presentazioni PowerPoint in HTML con Python](/slides/it/python-net/convert-powerpoint-to-html/)
- [Converti diapositive PowerPoint in PNG con Python](/slides/it/python-net/convert-powerpoint-to-png/)
---
title: Converti presentazioni OpenDocument in Python
linktitle: Converti OpenDocument
type: docs
weight: 10
url: /it/python-net/convert-openoffice-odp/
keywords:
- converti OpenDocument
- converti ODP
- ODP in PDF
- ODP in PPT
- ODP in PPTX
- ODP in XPS
- ODP in HTML
- ODP in TIFF
- ODP in SWF
- OpenDocument
- presentazione
- Python
- Aspose.Slides
description: "Converti ODP OpenDocument in PDF, PPT, PPTX, XPS, HTML, TIFF o SWF in Python con Aspose.Slides: esempi di codice, alta fedeltà, conversione batch e personalizzazione."
---
## **Introduzione**

[**Aspose.Slides API**](https://products.aspose.com/slides/it/python-net/) consente di convertire presentazioni OpenDocument (ODP) in molti formati (HTML, PDF, TIFF, SWF, XPS, ecc.). L'API utilizzata per convertire i file ODP in altri formati di documento è la stessa utilizzata per le operazioni di conversione di PowerPoint (PPT e PPTX).

Ad esempio, se è necessario convertire una presentazione ODP in PDF, è possibile farlo come segue:

```py
import aspose.slides as slides

with slides.Presentation("pres.odp") as presentation:
    presentation.save("pres.pdf", slides.export.SaveFormat.PDF)
```

## **FAQ**

**Posso convertire ODP in PPTX senza installare LibreOffice o OpenOffice?**

Sì. Aspose.Slides è una libreria completamente autonoma che gestisce sia i formati PowerPoint sia OpenOffice senza richiedere applicazioni esterne.

**Aspose.Slides apre e salva file ODP/OTP protetti da password?**

Sì. Può [caricare presentazioni crittografate](/slides/it/python-net/password-protected-presentation/) quando si fornisce la password e può anche salvare presentazioni con impostazioni di crittografia e protezione.

**Posso estrarre i file multimediali incorporati (audio/video) da un ODP prima di convertirlo?**

Sì. Aspose.Slides consente di accedere ed estrarre [audio](/slides/it/python-net/audio-frame/) e [video](/slides/it/python-net/video-frame/) incorporati nelle presentazioni, utile per la pre‑conversione o per riutilizzo separato.

**Posso salvare l'ODP convertito come Strict Office Open XML?**

Sì. Quando si salva in PPTX è possibile abilitare Strict OOXML tramite le [opzioni di salvataggio](https://reference.aspose.com/slides/it/python-net/aspose.slides.export/pptxoptions/) per soddisfare requisiti di conformità più stringenti.
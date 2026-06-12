---
title: Converti le presentazioni OpenDocument in C++
linktitle: Converti OpenDocument
type: docs
weight: 10
url: /it/cpp/convert-openoffice-odp/
keywords:
- converti ODP
- ODP in immagine
- ODP in GIF
- ODP in HTML
- ODP in JPG
- ODP in MD
- ODP in PDF
- ODP in PNG
- ODP in PPT
- ODP in PPTX
- ODP in TIFF
- ODP in video
- ODP in Word
- ODP in XPS
- OpenDocument
- presentazione
- C++
- Aspose.Slides
description: "Aspose.Slides per C++ ti consente di convertire ODP in PDF, HTML e formati immagine con facilità. Potenzia le tue app C++ con una conversione di presentazioni rapida e accurata."
---
[**Aspose.Slides API**](https://products.aspose.com/slides/it/cpp/) consente di convertire le presentazioni OpenDocument (ODP) in molti formati (HTML, PDF, TIFF, SWF, XPS, ecc.). L'API utilizzata per convertire i file ODP in altri formati di documento è la stessa utilizzata per le operazioni di conversione di PowerPoint (PPT e PPTX).

Ad esempio, se hai bisogno di convertire una presentazione ODP in PDF, puoi farlo come segue:

```cpp
auto pres = MakeObject<Presentation>(u"pres.odp");
pres->Save(u"pres.pdf", SaveFormat::Pdf);
pres->Dispose();
```
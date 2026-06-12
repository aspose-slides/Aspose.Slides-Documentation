---
title: OpenDocument-presentaties converteren in Python
linktitle: OpenDocument converteren
type: docs
weight: 10
url: /nl/python-net/convert-openoffice-odp/
keywords:
- OpenDocument converteren
- ODP converteren
- ODP naar PDF
- ODP naar PPT
- ODP naar PPTX
- ODP naar XPS
- ODP naar HTML
- ODP naar TIFF
- ODP naar SWF
- OpenDocument
- presentatie
- Python
- Aspose.Slides
description: "Converteer OpenDocument ODP naar PDF, PPT, PPTX, XPS, HTML, TIFF of SWF in Python met Aspose.Slides: codevoorbeelden, hoge nauwkeurigheid, batchconversie en aanpassing."
---
## **Introductie**

[**Aspose.Slides API**](https://products.aspose.com/slides/nl/python-net/) stelt u in staat om OpenDocument (ODP) presentaties te converteren naar vele formaten (HTML, PDF, TIFF, SWF, XPS, enz.). De API die wordt gebruikt om ODP‑bestanden naar andere documentformaten te converteren is dezelfde als die voor PowerPoint (PPT en PPTX) converteerbewerkingen.

Bijvoorbeeld, als u een ODP‑presentatie naar PDF moet converteren, kunt u dat als volgt doen:

```py
import aspose.slides as slides

with slides.Presentation("pres.odp") as presentation:
    presentation.save("pres.pdf", slides.export.SaveFormat.PDF)
```

## **FAQ**

**Kan ik ODP naar PPTX converteren zonder LibreOffice of OpenOffice te installeren?**

Ja. Aspose.Slides is een volledig zelfstandige bibliotheek die zowel PowerPoint‑ als OpenOffice‑formaten ondersteunt zonder dat er externe applicaties nodig zijn.

**Kan Aspose.Slides ODP/OTP‑bestanden met wachtwoordbeveiliging openen en opslaan?**

Ja. Het kan versleutelde presentaties [laden](/slides/nl/python-net/password-protected-presentation/) wanneer u het wachtwoord opgeeft en kan tevens presentaties opslaan met encryptie‑ en beschermingsinstellingen.

**Kan ik ingesloten mediabestanden (audio/video) uit een ODP extraheren voordat ik deze converteer?**

Ja. Aspose.Slides stelt u in staat om ingebedde [audio](/slides/nl/python-net/audio-frame/) en [video](/slides/nl/python-net/video-frame/) uit presentaties te benaderen en te extraheren, wat nuttig is voor verwerking vóór de conversie of voor afzonderlijk hergebruik.

**Kan ik de geconverteerde ODP opslaan als Strict Office Open XML?**

Ja. Bij het opslaan naar PPTX kunt u Strict OOXML inschakelen via de [opslaanopties](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/pptxoptions/) om te voldoen aan strengere conformiteitseisen.
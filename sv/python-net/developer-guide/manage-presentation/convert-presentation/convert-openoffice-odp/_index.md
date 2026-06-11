---
title: Konvertera OpenDocument-presentationer i Python
linktitle: Konvertera OpenDocument
type: docs
weight: 10
url: /sv/python-net/convert-openoffice-odp/
keywords:
- konvertera OpenDocument
- konvertera ODP
- ODP till PDF
- ODP till PPT
- ODP till PPTX
- ODP till XPS
- ODP till HTML
- ODP till TIFF
- ODP till SWF
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Konvertera OpenDocument ODP till PDF, PPT, PPTX, XPS, HTML, TIFF eller SWF i Python med Aspose.Slides: kodexempel, hög kvalitet, batchkonvertering och anpassning."
---
## **Introduktion**

[**Aspose.Slides API**](https://products.aspose.com/slides/sv/python-net/) gör det möjligt att konvertera OpenDocument (ODP)-presentationer till många format (HTML, PDF, TIFF, SWF, XPS, etc.). API:et som används för att konvertera ODP‑filer till andra dokumentformat är samma som används för PowerPoint‑konverteringsoperationer (PPT och PPTX).

Till exempel, om du behöver konvertera en ODP-presentation till PDF, kan du göra det på följande sätt:

```py
import aspose.slides as slides

with slides.Presentation("pres.odp") as presentation:
    presentation.save("pres.pdf", slides.export.SaveFormat.PDF)
```

## **FAQ**

**Kan jag konvertera ODP till PPTX utan att installera LibreOffice eller OpenOffice?**

Ja. Aspose.Slides är ett helt fristående bibliotek som hanterar både PowerPoint- och OpenOffice-format utan att kräva några externa applikationer.

**Kan Aspose.Slides öppna och spara lösenordsskyddade ODP/OTP‑filer?**

Ja. Den kan [ladda krypterade presentationer](/slides/sv/python-net/password-protected-presentation/) när du anger lösenordet och kan även spara presentationer med kryptering och skyddsinställningar.

**Kan jag extrahera inbäddade mediafiler (audio/video) från en ODP innan konvertering?**

Ja. Aspose.Slides låter dig komma åt och extrahera inbäddad [audio](/slides/sv/python-net/audio-frame/) och [video](/slides/sv/python-net/video-frame/) från presentationer, vilket är användbart för förbehandlingsprocesser före konvertering eller separat återanvändning.

**Kan jag spara den konverterade ODP som Strict Office Open XML?**

Ja. När du sparar till PPTX kan du aktivera Strict OOXML via [save options](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/pptxoptions/) för att uppfylla strängare efterlevnadskrav.
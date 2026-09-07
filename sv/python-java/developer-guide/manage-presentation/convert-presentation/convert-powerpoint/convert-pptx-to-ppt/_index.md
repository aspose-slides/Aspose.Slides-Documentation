---
title: Konvertera PPTX till PPT i Python
linktitle: PPTX till PPT
type: docs
weight: 21
url: /sv/python-java/convert-pptx-to-ppt/
keywords:
- konvertera PowerPoint
- konvertera presentation
- konvertera bild
- konvertera PPTX
- PPTX till PPT
- spara PPTX som PPT
- exportera PPTX till PPT
- PowerPoint
- presentation
- Python
- Java
- Aspose.Slides
description: "Konvertera PPTX till det äldre PPT-formatet i Python med Aspose.Slides för Python via Java. Inkluderar ett kodexempel och anteckningar om kompatibilitet och skyddade filer."
---
## **Översikt**

Aspose.Slides for Python via Java låter dig konvertera en PPTX-presentation till det äldre PPT-formatet som användes av PowerPoint 97–2003 utan att Microsoft PowerPoint är installerat. Läs in PPTX-filen och spara den med PPT-utdataformatet, som visas nedan.

## **Konvertera PPTX till PPT**

Läs in källfilen med klassen [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/), anropa sedan [Presentation.save](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/#save) med utsökvägen och [SaveFormat.Ppt](https://reference.aspose.com/slides/sv/python-java/aspose.slides/saveformat/#Ppt).

Följande exempel startar den virtuella Java‑maskinen vid behov och konverterar `template.pptx` till `output.ppt` med standardalternativ. Byt ut sökvägarna mot dina egna filnamn. `finally`‑blocket frigör presentationsresurserna även om sparandet misslyckas.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Läs in PPTX-presentationen.
presentation = Presentation("template.pptx")
try:
    # Spara presentationen i PPT-format.
    presentation.save("output.ppt", SaveFormat.Ppt)
finally:
    presentation.dispose()
```

Argumentet [SaveFormat.Ppt](https://reference.aspose.com/slides/sv/python-java/aspose.slides/saveformat/#Ppt) väljer utdataformatet; att bara ändra filändelsen konverterar inte en presentation. Behåll den ursprungliga PPTX‑filen så att du kan återgå till den om en nyare funktion saknar motsvarighet i PPT.

## **Konvertera PPTX till andra format**

Aspose.Slides stöder även andra utdataformat. Se motsvarande artiklar för format‑specifika alternativ och exempel:

- [Convert PowerPoint to PDF in Python](/slides/sv/python-java/convert-powerpoint-to-pdf/)
- [Convert PowerPoint to XPS in Python](/slides/sv/python-java/convert-powerpoint-to-xps/)
- [Convert PowerPoint to HTML in Python](/slides/sv/python-java/convert-powerpoint-to-html/)
- [Save Presentations as ODP in Python](/slides/sv/python-java/save-presentation/)
- [Convert PowerPoint to PNG in Python](/slides/sv/python-java/convert-powerpoint-to-png/)

## **FAQ**

**Överlever alla PPTX‑effekter och -funktioner konverteringen till PPT?**

Inte alltid. det äldre PPT‑formatet stöder inte varje funktion som finns i PPTX. Vissa effekter, objekt eller beteenden kan förenklas eller visas annorlunda. Granska den konverterade presentationen i den avsedda visaren, särskilt om den innehåller nyare PowerPoint‑funktioner.

**Kan jag konvertera endast valda bilder till PPT?**

Att spara till PPT skriver hela presentationen. För att konvertera utvalda bilder, skapa en ny presentation, ta bort den initiala tomma bilden, klona de önskade bilderna till den och spara den som PPT. Se [Clone Slides in Python](/slides/sv/python-java/clone-slides/).

**Kan jag konvertera en lösenordsskyddad PPTX‑fil?**

Ja, om du anger rätt lösenord när du läser in källpresentationen. Du kan också konfigurera skydd för utdatafilen. Se [Password-Protected Presentations](/slides/sv/python-java/password-protected-presentation/).
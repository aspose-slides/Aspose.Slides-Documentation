---
title: Konvertera PowerPoint-presentationer till SWF Flash i Python
linktitle: PowerPoint till SWF Flash
type: docs
weight: 80
url: /sv/python-net/convert-powerpoint-to-swf-flash/
keywords:
- konvertera PowerPoint
- konvertera presentation
- konvertera bild
- PowerPoint till SWF
- presentation till SWF
- bild till SWF
- PPT till SWF
- PPTX till SWF
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Konvertera PowerPoint (PPT/PPTX) till SWF Flash i Python med Aspose.Slides. Steg för steg kodexempel, snabb kvalitetsoutput, ingen PowerPoint-automatisering."
---
## **Översikt**

Den här artikeln förklarar hur du konverterar PowerPoint‑presentationer till SWF med hjälp av Aspose.Slides. Den visar hur du sparar en presentation som en SWF‑fil med metoden [Presentation.save](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/save/) och hur du konfigurerar exporten med [SwfOptions](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/swfoptions/), inklusive visningsinställningar och layout för anteckningar eller kommentarer.

## **Konvertera presentationer till Flash**

Metoden [save](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/save/) som exponeras av klassen [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/) kan användas för att konvertera hela presentationen till ett SWF‑dokument. Du kan också inkludera kommentarer i den genererade SWF‑filen genom att använda klassen [SWFOptions](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/swfoptions/) och klassen [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/notescommentslayoutingoptions/). Följande exempel visar hur du konverterar en presentation till ett SWF‑dokument med de alternativ som tillhandahålls av SWFOptions‑klassen.

```py
import aspose.slides as slides

# Instansiera ett Presentation-objekt som representerar en presentationsfil
presentation = slides.Presentation("pres.pptx")

swfOptions = slides.export.SwfOptions()
swfOptions.viewer_included = False
swfOptions.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL

# Spara presentation och notssidor
presentation.save("SaveAsSwf_out.swf", slides.export.SaveFormat.SWF, swfOptions)
swfOptions.viewer_included = True
presentation.save("SaveNotes_out.swf", slides.export.SaveFormat.SWF, swfOptions)
```

## **Vanliga frågor**

**Kan jag inkludera dolda bilder i SWF?**

Ja. Aktivera alternativet [show_hidden_slides](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/swfoptions/show_hidden_slides/) i [SwfOptions](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/swfoptions/). Som standard exporteras inte dolda bilder.

**Hur kan jag kontrollera komprimeringen och den slutgiltiga SWF‑storleken?**

Använd flaggan [compressed](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/swfoptions/compressed/) (aktiverad som standard) och justera [jpeg_quality](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/swfoptions/jpeg_quality/) för att balansera filstorlek och bildkvalitet.

**Vad är 'viewer_included' för, och när bör jag inaktivera det?**

[viewer_included](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/swfoptions/viewer_included/) lägger till ett inbäddat spelar‑UI (navigationskontroller, paneler, sök). Inaktivera det om du planerar att använda din egen spelare eller behöver en minimal SWF‑ram utan UI.

**Vad händer om en källfont saknas på exportmaskinen?**

Aspose.Slides kommer att ersätta den font du anger via [default_regular_font](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/swfoptions/default_regular_font/) i [SwfOptions](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/swfoptions/) för att undvika ett oavsiktligt fallback.
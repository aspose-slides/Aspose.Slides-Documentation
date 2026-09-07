---
title: Konvertera PowerPoint-presentationer i handout-läge med Python
linktitle: Handout-läge
type: docs
weight: 150
url: /sv/python-java/convert-powerpoint-in-handout-mode/
keywords:
- konvertera PowerPoint
- konvertera presentation
- handout-läge
- handout
- PPT
- PPTX
- PowerPoint
- presentation
- Python
- Java
- Aspose.Slides
description: "Konvertera PowerPoint-presentationer till handouts i Python via Java. Ordna flera bilder per sida och exportera till PDF med Aspose.Slides."
---
## **Introduktion**

Aspose.Slides för Python via Java låter dig exportera presentationer i handout-läge, där flera bilder placeras på en enda sida. Detta är användbart för att skriva ut presentationsmaterial för konferenser, seminarier och liknande evenemang.

Konfigurera layouten via metoden [setSlidesLayoutOptions](https://reference.aspose.com/slides/sv/python-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions). Handout-layouter stöds av [PdfOptions](https://reference.aspose.com/slides/sv/python-java/aspose.slides/pdfoptions/), [RenderingOptions](https://reference.aspose.com/slides/sv/python-java/aspose.slides/renderingoptions/), [HtmlOptions](https://reference.aspose.com/slides/sv/python-java/aspose.slides/htmloptions/) och [TiffOptions](https://reference.aspose.com/slides/sv/python-java/aspose.slides/tiffoptions/). Använd ett [HandoutLayoutingOptions](https://reference.aspose.com/slides/sv/python-java/aspose.slides/handoutlayoutingoptions/)-objekt för att ange layout- och visningsinställningar.

## **Export i handout-läge**

För att exportera en presentation i handout-läge, skapa en [HandoutLayoutingOptions](https://reference.aspose.com/slides/sv/python-java/aspose.slides/handoutlayoutingoptions/)-instans och tilldela den till mål-exportalternativen med [setSlidesLayoutOptions](https://reference.aspose.com/slides/sv/python-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions).

Följande exempel läser in `sample.pptx` och exporterar den till PDF med fyra bilder per sida i horisontell ordning. Det inkluderar bildnummer och ramar runt bilderna samt exkluderar kommentarer.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HandoutLayoutingOptions, HandoutType, PdfOptions, Presentation, SaveFormat

# Ladda en presentation.
presentation = Presentation("sample.pptx")
try:
    # Konfigurera handout-layouten.
    slides_layout_options = HandoutLayoutingOptions()
    slides_layout_options.setHandout(HandoutType.Handouts4Horizontal)
    slides_layout_options.setPrintSlideNumbers(True)
    slides_layout_options.setPrintFrameSlide(True)
    slides_layout_options.setPrintComments(False)

    pdf_options = PdfOptions()
    pdf_options.setSlidesLayoutOptions(slides_layout_options)

    # Exportera presentationen till PDF med den valda layouten.
    presentation.save("output.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

{{% alert color="warning" title="Warning" %}}
Handout‑layoutinställningarna gäller för stödda utdataformat, såsom PDF, HTML, TIFF och renderade bilder. De omarrangerar inte bilderna i källpresentationen.
{{% /alert %}}

## **Vanliga frågor**

**Vad är det maximala antalet bildminiatyrer per sida i handout-läge?**

Aspose.Slides stödjer upp till nio miniatyrer per sida. Förinställningarna i [HandoutType](https://reference.aspose.com/slides/sv/python-java/aspose.slides/handouttype/) erbjuder en, två, tre, fyra, sex eller nio bilder per sida. Förinställningarna för fyra, sex och nio bilder ger horisontell och vertikal ordning.

**Kan jag definiera ett anpassat rutnät, till exempel fem eller åtta bilder per sida?**

Nej. Antalet och ordningen på miniatyrerna styrs av de fördefinierade värdena i [HandoutType](https://reference.aspose.com/slides/sv/python-java/aspose.slides/handouttype/). Godtyckliga rutnät stöds inte av dessa handout‑layoutinställningar.

**Kan jag inkludera dolda bilder i handout-utdata?**

Ja. Aktivera dolda bilder i exportinställningarna för målformatet. För PDF, anropa [PdfOptions.setShowHiddenSlides](https://reference.aspose.com/slides/sv/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides) med `True` innan du sparar presentationen.
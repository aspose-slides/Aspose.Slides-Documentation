---
title: Aspose.Slides för Python via .NET
second_title: Aspose.Slides för Python
type: docs
weight: 35
url: /sv/python-net/
is_root: true
keywords:
- Aspose.Slides för Python
- PowerPoint‑automatisering Python
- Python PPT‑bibliotek
- exportera PowerPoint till PDF Python
- exportera PowerPoint till SVG Python
- redigera PowerPoint i Python
- Python PowerPoint utan Microsoft Office
- hantera PPTX med Python
- bildförhandsgranskning Python
- Python lägger till ljud till bilder
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "Aspose.Slides för Python via .NET erbjuder ett omfattande funktionsset, inklusive hantering av text, former, tabeller och animationer, tillsättning av ljud och video till bilder, förhandsgranskning av bilder samt export till SVG, PDF och mer."
---
{{% alert color="info" %}}

**Välkommen till Aspose.Slides för Python via .NET**

![Aspose.Slides för Python via .NET produktlogo](aspose_slides-for-python.png)

Aspose.Slides för Python via .NET är ett robust klassbibliotek som låter dina applikationer läsa och skriva PowerPoint®‑presentationer utan att kräva Microsoft PowerPoint®.

Det är den första och enda komponenten som erbjuder fullständig PowerPoint®‑dokumenthantering för Python‑utvecklare.

Aspose.Slides för Python via .NET innehåller ett brett spektrum av funktioner såsom arbete med text, former, tabeller och animationer; lägga till ljud och video; förhandsgranska bilder; och exportera bilder till format som SVG, PDF och mer.

{{% /alert %}}

## Installera Aspose.Slides för Python via .NET

```bash
pip install aspose.slides
```

Paketet levereras med den .NET‑runtime som krävs, så det finns inget mer att installera och Microsoft PowerPoint behövs inte. Python 3.7 eller senare på Windows, Linux eller macOS.

## Skapa en PowerPoint‑presentation i Python

Detta exempel skapar en presentation, lägger till en form med text på den första bilden och sparar resultatet både som PPTX och PDF.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 600, 100)
    shape.text_frame.text = "Created with Aspose.Slides for Python via .NET"

    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
    presentation.save("presentation.pdf", slides.export.SaveFormat.PDF)
```

När den körs skrivs `presentation.pptx` (ca 34 KB) och `presentation.pdf` (ca 36 KB) till arbetskatalogen.

Utan en licens körs biblioteket i evalueringsläge, vilket lägger till en vattenstämpel och begränsar antalet bilder. Se [Licensing](/slides/sv/python-net/licensing/) för att tillämpa en.

## Resurser för Aspose.Slides for Python via .NET

Utforska dessa hjälpsamma resurser::

- [Aspose.Slides för Python via .NET online‑dokumentation](/slides/sv/python-net/)
- [Aspose.Slides för Python via .NET funktioner](/slides/sv/python-net/features-overview/)
- [Aspose.Slides för Python via .NET versionsanteckningar](https://releases.aspose.com/slides/sv/python-net/release-notes/)
- [Aspose.Slides för Python via .NET produktsida](https://products.aspose.com/slides/sv/python-net/)
- [Ladda ner Aspose.Slides för Python via .NET](https://releases.aspose.com/slides/sv/python-net/)
- [Installera Aspose.Slides för Python via .NET PyPi‑paket](https://pypi.org/project/aspose.slides/)
- [Aspose.Slides för Python via .NET API‑referensguide](https://reference.aspose.com/slides/sv/python-net/)
- [Aspose.Slides för Python via .NET gratis supportforum](https://forum.aspose.com/c/slides/sv/11)
- [Aspose.Slides för Python via .NET betald support‑helpdesk](https://helpdesk.aspose.com/)

## Vanliga frågor

### Vad är Aspose.Slides för Python via .NET?

Aspose.Slides för Python via .NET är ett kraftfullt Python‑bibliotek som låter dig skapa, redigera och konvertera PowerPoint‑presentationer (PPT, PPTX, ODP) programmässigt utan att Microsoft PowerPoint är installerat.

### Vilka presentationsfunktioner stödjer Aspose.Slides?

Biblioteket stöder hantering av text, former, tabeller, diagram, animationer, master‑bilder, ljud, video och mer. Det möjliggör även förhandsgranskning av bilder, rendering och export till format som PDF, SVG, HTML och bildfiler.

### Kan jag konvertera presentationer till andra format med Aspose.Slides?

Ja. Aspose.Slides möjliggör konvertering av PowerPoint‑filer till PDF, SVG, HTML, JPG, PNG, TIFF och andra format med hög noggrannhet och prestanda.

### Krävs Microsoft PowerPoint för att använda Aspose.Slides?

Nej. Aspose.Slides är ett fristående API och kräver varken Microsoft Office eller någon tredjepartsprogramvara.

### Vilka plattformar stöder Aspose.Slides för Python via .NET?

Det är plattformsoberoende och fungerar i Windows-, Linux- och macOS‑miljöer.

### Hur kommer jag igång med Aspose.Slides för Python?

Du kan installera det via PyPi och utforska [Utvecklarguide](/slides/sv/python-net/developer-guide/) för att komma igång med exempel, API‑referenser och handledningar.
---
title: Aspose.Slides för Python via .NET
second_title: Aspose.Slides för Python
type: docs
weight: 35
url: /sv/python-net/
is_root: true
keywords:
- Aspose.Slides för Python
- PowerPoint-automatisering Python
- Python PPT-bibliotek
- exportera PowerPoint till PDF Python
- exportera PowerPoint till SVG Python
- redigera PowerPoint i Python
- Python PowerPoint utan Microsoft Office
- hantera PPTX med Python
- förhandsgranska bildspel Python
- Python lägg till ljud till bildspel
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "Aspose.Slides för Python via .NET erbjuder en omfattande uppsättning funktioner, inklusive hantering av text, former, tabeller och animationer, samt att lägga till ljud och video till bildspel, förhandsgranska bildspel och exportera till SVG, PDF och mer."
---
{{% alert color="primary" %}}

**Välkommen till Aspose.Slides for Python via .NET**

![Aspose.Slides för Python via .NET Produktlogotyp](aspose_slides-for-python.png)

Aspose.Slides for Python via .NET är ett robust klassbibliotek som låter dina applikationer läsa och skriva PowerPoint®-presentationer utan att kräva Microsoft PowerPoint®.

Det är den första och enda komponenten som erbjuder fullständig PowerPoint®-dokumenthantering för Python‑utvecklare.

Aspose.Slides for Python via .NET inkluderar ett brett spektrum av funktioner som att arbeta med text, former, tabeller och animationer; lägga till ljud och video; förhandsgranska bilder; samt exportera bilder till format som SVG, PDF och fler.

{{% /alert %}}

## Installera Aspose.Slides för Python via .NET

```bash
pip install aspose.slides
```

Paketet levereras med den .NET‑runtime som behövs, så det finns inget annat att installera och Microsoft PowerPoint krävs inte. Python 3.7 eller senare på Windows, Linux eller macOS.

## Skapa en PowerPoint‑presentation i Python

Det här exemplet skapar en presentation, lägger till en form med text på den första bilden och sparar resultatet både som PPTX och PDF.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 600, 100)
    shape.text_frame.text = "Created with Aspose.Slides for Python via .NET"

    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
    presentation.save("presentation.pdf", slides.export.SaveFormat.PDF)
```

När den körs skrivs `presentation.pptx` (cirka 34 KB) och `presentation.pdf` (cirka 36 KB) till arbetskatalogen.

Utan licens körs biblioteket i evalueringsläge, vilket lägger till ett vattenmärke och begränsar antalet bilder. Se [Licensiering](/slides/sv/python-net/licensing/) för att lägga till en.

## Resurser för Aspose.Slides för Python via .NET

Utforska dessa hjälpsamma resurser:

- [Aspose.Slides för Python via .NET Online‑dokumentation](/slides/sv/python-net/)
- [Aspose.Slides för Python via .NET Funktioner](/slides/sv/python-net/features-overview/)
- [Aspose.Slides för Python via .NET Versionsanteckningar](https://releases.aspose.com/slides/sv/python-net/release-notes/)
- [Aspose.Slides för Python via .NET Produktsida](https://products.aspose.com/slides/sv/python-net/)
- [Ladda ner Aspose.Slides för Python via .NET](https://releases.aspose.com/slides/sv/python-net/)
- [Installera Aspose.Slides för Python via .NET PyPi‑paket](https://pypi.org/project/aspose.slides/)
- [Aspose.Slides för Python via .NET API‑referenshandbok](https://reference.aspose.com/slides/sv/python-net/)
- [Aspose.Slides för Python via .NET Gratis supportforum](https://forum.aspose.com/c/slides/sv/11)
- [Aspose.Slides för Python via .NET Betald supporthelpdesk](https://helpdesk.aspose.com/)

## Vanliga frågor

### Vad är Aspose.Slides för Python via .NET?

Aspose.Slides för Python via .NET är ett kraftfullt Python‑bibliotek som låter dig skapa, redigera och konvertera PowerPoint‑presentationer (PPT, PPTX, ODP) programatiskt utan att Microsoft PowerPoint är installerat.

### Vilka presentationsfunktioner stöder Aspose.Slides?

Biblioteket stöder hantering av text, former, tabeller, diagram, animationer, maste‑bilder, ljud, video med mera. Det möjliggör även förhandsgranskning av bilder, rendering, utskrift och export till format som PDF, SVG, HTML och bilder.

### Kan jag konvertera presentationer till andra format med Aspose.Slides?

Ja. Aspose.Slides möjliggör konvertering av PowerPoint‑filer till PDF, SVG, HTML, JPG, PNG, TIFF och andra format med hög noggrannhet och prestanda.

### Krävs Microsoft PowerPoint för att använda Aspose.Slides?

Nej. Aspose.Slides är ett fristående API och kräver varken Microsoft Office eller någon tredjepartsprogramvara.

### Vilka plattformar stöder Aspose.Slides för Python via .NET?

Det är plattformsoberoende och fungerar på Windows-, Linux- och macOS‑miljöer.

### Hur kommer jag igång med Aspose.Slides för Python?

Du kan installera det via PyPi och utforska [Utvecklarguiden](/slides/sv/python-net/developer-guide/) för att komma igång med exempel, API‑referenser och handledningar.
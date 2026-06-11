---
title: Hantera presentationstillgänglighet i Python
linktitle: Presentationstillgänglighet
type: docs
weight: 30
url: /sv/python-net/presentation-accessibility/
keywords:
- presentationstillgänglighet
- markera som dekorativ
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Upptäck hur Aspose.Slides för Python hjälper till att automatisera kontroller av presentationstillgänglighet i PPT-, PPTX- och ODP-filer—förbättra skärmläsarupplevelsen och öka efterlevnaden."
---
## **Introduktion**

Tillgänglighet för presentationer säkerställer att personer som använder hjälptekniker – såsom skärmläsare, punktskriftsdisplayar eller navigering enbart med tangentbord – kan förstå och navigera dina bildspel lika effektivt som synliga användare med mus. God praxis fokuserar på tydlig läsordning, meningsfull alternativ text för informativa visuella element, tillräcklig färgkontrast, läsbar typografi, beskrivande länktext och att undvika att förmedla betydelse enbart genom färg eller position. När tillgänglighet planeras från början blir resultatet en renare struktur, mer konsekventa visuella element och innehåll som når varje betraktare utan kringgående lösningar.

## **Markera som dekorativ**

Markera som dekorativ flaggar rent dekorativa visuella element så att skärmläsare hoppar över dem, vilket minskar brus och håller fokus på meningsfullt innehåll. Använd det på bakgrunder, dekorationer och avståndsobjekt – aldrig på diagram, ikoner eller bilder som förmedlar information. Aspose.Slides exponerar denna flagga för upptäckt och validering, vilket möjliggör automatiska tillgänglighetskontroller och rensning.

![Markera som dekorativ](mark_as_decorative.png)

Följande kodexempel visar hur man avgör om en form är markerad som dekorativ.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    print(f"Is shape decorative: {shape.is_decorative}")
```
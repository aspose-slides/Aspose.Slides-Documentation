---
title: Hantera presentationstillgänglighet i C++
linktitle: Presentationstillgänglighet
type: docs
weight: 30
url: /sv/cpp/presentation-accessibility/
keywords:
- presentationstillgänglighet
- markera som dekorativ
- PowerPoint
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "Upptäck hur Aspose.Slides för C++ hjälper till att automatisera kontroller av presentationstillgänglighet i PPT-, PPTX- och ODP-filer — förbättra skärmläsarupplevelsen och öka efterlevnaden."
---
## **Översikt**

Tillgänglighet för presentationer säkerställer att personer som använder hjälpmedel—såsom skärmläsare, brailledisplayer eller enbart tangentbordsnavigation—kan förstå och navigera dina bilder lika effektivt som synliga, musanvändande åhörare. Bra praxis fokuserar på tydlig läsordning, meningsfull alternativ text för informativa visuella element, tillräcklig färgkontrast, läsbar typografi, beskrivande länktext och att undvika att förmedla betydelse enbart genom färg eller position. När tillgänglighet planeras från början blir resultatet en renare struktur, mer konsekventa visuella element och innehåll som når alla tittare utan lösningar.

## **Markera som dekorativ**

Markera som dekorativ flaggar rent dekorativa visuella element så att skärmläsare hoppar över dem, vilket minskar brus och håller fokus på meningsfullt innehåll. Använd den på bakgrunder, utsmyckningar och avståndshållare—aldrig på diagram, ikoner eller bilder som förmedlar information. Aspose.Slides exponerar denna flagga för detektering och validering, vilket möjliggör automatiserade tillgänglighetskontroller och rensning.

![Markera som dekorativ](mark_as_decorative.png)

Följande kodexempel visar hur man avgör om en form är markerad som dekorativ.

```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto shape = presentation->get_Slide(0)->get_Shape(0);
Console::WriteLine(u"Is shape decorative: {0}", shape->get_IsDecorative());

presentation->Dispose();
```
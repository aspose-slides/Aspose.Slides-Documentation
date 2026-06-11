---
title: Hantera presentationstillgänglighet i .NET
linktitle: Presentationstillgänglighet
type: docs
weight: 30
url: /sv/net/presentation-accessibility/
keywords:
- presentationstillgänglighet
- markerad som dekorativ
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Automatisera kontroller av presentationstillgänglighet i PPT-, PPTX- och ODP-filer med Aspose.Slides för .NET – förbättra skärmläsarupplevelsen och öka efterlevnaden."
---
## **Introduktion**

Tillgänglighet för presentationer säkerställer att personer som använder hjälpmedel – såsom skärmläsare, punktskriftsdisplay eller enbart tangentbordsnavigering – kan förstå och navigera dina bildspel lika effektivt som seende, musanvändande publik. God praxis fokuserar på tydlig läsordning, meningsfull alternativtext för informativa bilder, tillräcklig färgkontrast, läsbar typografi, beskrivande länktext och att undvika att förmedla betydelse enbart genom färg eller position. När tillgänglighet planeras från början blir resultatet en renare struktur, mer enhetliga visuella element och innehåll som når alla tittare utan kringgående lösningar.

## **Markera som dekorativ**

Markera som dekorativ flaggar rent dekorativa visuella element så att skärmläsare hoppar över dem, vilket minskar brus och håller fokus på meningsfullt innehåll. Använd den på bakgrunder, utsmyckningar och avståndsobjekt – aldrig på diagram, ikoner eller bilder som förmedlar information. Aspose.Slides exponerar denna flagga för upptäckt och validering, vilket möjliggör automatiska tillgänglighetskontroller och rensning.

![Markera som dekorativ](mark_as_decorative.png)

```cs
using var presentation = new Presentation("sample.pptx");

var shape = presentation.Slides[0].Shapes[0];
Console.WriteLine($"Is shape decorative: {shape.IsDecorative}");
```
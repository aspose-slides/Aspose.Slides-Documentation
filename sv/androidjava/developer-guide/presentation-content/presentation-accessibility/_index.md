---
title: Hantera tillgänglighet för presentationer på Android
linktitle: Presentationstillgänglighet
type: docs
weight: 30
url: /sv/androidjava/presentation-accessibility/
keywords:
- presentationstillgänglighet
- markera som dekorativ
- PowerPoint
- OpenDocument
- presentation
- Android
- Java
- Aspose.Slides
description: "Upptäck hur Aspose.Slides för Android via Java hjälper till att automatisera kontroll av presentationsåtkomst i PPT-, PPTX- och ODP-filer—förbättra skärmläsarupplevelsen och öka efterlevnaden."
---
## **Översikt**

Tillgänglighet för presentationer säkerställer att personer som använder hjälpmedel—såsom skärmläsare, punktskriftsskärmar eller navigering enbart med tangentbord—kan förstå och navigera dina bildspel lika effektivt som synliga, musanvändande publik. Bra praxis fokuserar på tydlig läsordning, meningsfull alternativ text för informativa bilder, tillräcklig färgkontrast, läsbar typografi, beskrivande länktest och att undvika att förmedla betydelse enbart genom färg eller position. När tillgänglighet planeras från början blir resultatet en renare struktur, mer konsekventa visuella element och innehåll som når alla tittare utan omvägar.

## **Markera som dekorativ**

Markera som dekorativ flaggar rent dekorativa visuella element så att skärmläsare hoppar över dem, minskar störningar och behåller fokus på meningsfullt innehåll. Applicera den på bakgrunder, utsmyckningar och avståndsobjekt—aldrig på diagram, ikoner eller bilder som förmedlar information. Aspose.Slides exponerar denna flagga för detektering och validering, vilket möjliggör automatiska tillgänglighetskontroller och städning.

![Markera som dekorativ](mark_as_decorative.png)

Följande kodexempel visar hur man avgör om en form är markerad som dekorativ.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    System.out.println("Is shape decorative: " + shape.isDecorative());
} finally {
    presentation.dispose();
}
```
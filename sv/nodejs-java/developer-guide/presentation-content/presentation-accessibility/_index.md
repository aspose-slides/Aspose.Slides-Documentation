---
title: Hantera presentationstillgänglighet i JavaScript
linktitle: Presentationstillgänglighet
type: docs
weight: 30
url: /sv/nodejs-java/presentation-accessibility/
keywords:
- presentationstillgänglighet
- markera som dekorativ
- PowerPoint
- OpenDocument
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Automatisera kontroller av presentationstillgänglighet i PPT-, PPTX- och ODP-filer med Aspose.Slides för Node.js — förbättra skärmläsarupplevelsen och öka efterlevnaden."
---
## **Översikt**

Tillgänglighet för presentationer säkerställer att personer som använder hjälpmedel — såsom skärmläsare, punktskriftsskärmar eller navigering enbart med tangentbord — kan förstå och navigera dina bildspel lika effektivt som synliga, musanvändande åskådare. God praxis fokuserar på tydlig läsordning, meningsfull alternativ text för informativa visuella element, tillräcklig färgkontrast, läsbar typografi, beskrivande länktext samt att undvika att förmedla betydelse enbart genom färg eller position. När tillgänglighet planeras från början blir resultatet en renare struktur, mer konsekventa visuella element och innehåll som når alla tittare utan kringvägar.

## **Markera som dekorativ**

Flaggan Markera som dekorativ markerar rena ornamentala visuella element så att skärmläsare hoppar över dem, vilket minskar brus och håller fokus på meningsfullt innehåll. Använd den på bakgrunder, prydnader och avgränsare — aldrig på diagram, ikoner eller bilder som förmedlar information. Aspose.Slides exponerar denna flagga för detektering och validering, vilket möjliggör automatiska tillgänglighetskontroller och rensning.

![Markera som dekorativ](mark_as_decorative.png)

Följande kodexempel visar hur du avgör om en form är markerad som dekorativ.

```js
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    console.log("Is shape decorative:", shape.isDecorative());
} finally {
    presentation.dispose();
}
```
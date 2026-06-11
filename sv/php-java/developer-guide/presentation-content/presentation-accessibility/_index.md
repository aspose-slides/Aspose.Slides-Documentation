---
title: Hantera presentationstillgänglighet i PHP
linktitle: Presentationstillgänglighet
type: docs
weight: 30
url: /sv/php-java/presentation-accessibility/
keywords:
- presentationstillgänglighet
- markera som dekorativ
- PowerPoint
- OpenDocument
- presentation
- PHP
- Aspose.Slides
description: "Upptäck hur Aspose.Slides hjälper till att automatisera kontroller av presentationstillgänglighet i PPT-, PPTX- och ODP-filer—förbättra skärmläsarupplevelsen och öka efterlevnaden."
---
## **Översikt**

Tillgänglighet i presentationer säkerställer att personer som använder hjälpmedel—såsom skärmläsare, punktskriftsskärmar eller navigering enbart med tangentbord—kan förstå och navigera dina bildspel lika effektivt som seende, musanvändande publik. God praxis fokuserar på tydlig läsordning, meningsfull alternativ text för informativa visuella element, tillräcklig färgkontrast, läsbar typografi, beskrivande länktext och att undvika att förmedla betydelse enbart genom färg eller position. När tillgänglighet planeras från början blir resultatet en renare struktur, mer konsekventa visuella element och innehåll som når alla tittare utan kringvägar.

## **Markera som dekorativ**

Markera som dekorativ flaggar rent dekorativa visuella element så att skärmläsare hoppar över dem, vilket minskar brus och håller fokus på meningsfullt innehåll. Använd den på bakgrunder, utsmyckningar och avståndsmarkörer—aldrig på diagram, ikoner eller bilder som förmedlar information. Aspose.Slides exponerar denna flagga för detektering och validering, vilket möjliggör automatiserade tillgänglighetskontroller och rensning.

![Markera som dekorativ](mark_as_decorative.png)

Följande kodexempel visar hur man avgör om en form är markerad som dekorativ.

```php
$presentation = new Presentation("sample.pptx");
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    echo "Is shape decorative: " . ($shape->isDecorative() ? "true" : "false") . "\n";
} finally {
    $presentation->dispose();
}
```
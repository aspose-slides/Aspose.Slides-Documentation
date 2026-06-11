---
title: Rendera presentationer med fallback-typsnitt i PHP
linktitle: Rendera presentationer
type: docs
weight: 30
url: /sv/php-java/render-presentation-with-fallback-font/
keywords:
- fallback-typsnitt
- rendera PowerPoint
- rendera presentation
- rendera bild
- PowerPoint
- OpenDocument
- presentation
- PHP
- Aspose.Slides
description: "Rendera presentationer med fallback-typsnitt i Aspose.Slides för PHP via Java - behåll texten konsekvent i PPT, PPTX och ODP med steg-för-steg-kodexempel."
---
## **Översikt**

Aspose.Slides låter dig rendera presentationer med fallback‑typsnittsregler. Den här artikeln visar hur du skapar en samling med fallback‑typsnittsregler, modifierar reglerna genom att ta bort eller lägga till fallback‑typsnitt, och tilldelar samlingen till metoden `FontsManager::setFontFallBackRulesCollection`.

När samlingen med fallback‑typsnittsregler har tilldelats presentationens `FontsManager` tillämpas reglerna under operationer som sparande, rendering och konvertering av presentationen. Exemplet demonstrerar hur de konfigurerade reglerna används när en bildminiatyren renderas och sparas som en PNG‑bild.

## **Rendera en bild med fallback‑typsnittsregler**

Följande exempel innehåller dessa steg:

1. Vi [skapar samling med fallback-typsnittsregler](/slides/sv/php-java/create-fallback-fonts-collection/).
1. [Ta bort](https://reference.aspose.com/slides/sv/php-java/aspose.slides/FontFallBackRule#remove-java.lang.String-) en fallback‑typsnittsregel och [addFallBackFonts](https://reference.aspose.com/slides/sv/php-java/aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) till en annan regel.
1. Ställ in regelsamlingen på [getFontsManager](https://reference.aspose.com/slides/sv/php-java/aspose.slides/Presentation#getFontsManager--).[getFontFallBackRulesCollection](https://reference.aspose.com/slides/sv/php-java/aspose.slides/FontsManager#getFontFallBackRulesCollection--)‑metoden.
1. Med [Presentation.save](https://reference.aspose.com/slides/sv/php-java/aspose.slides/Presentation#save-java.lang.String-int-)‑metoden kan vi spara presentationen i samma format eller spara den i ett annat format. Efter att samlingen med fallback‑typsnittsregler har ställts in på [FontsManager](https://reference.aspose.com/slides/sv/php-java/aspose.slides/FontsManager) tillämpas dessa regler under alla operationer på presentationen: spara, rendera, konvertera osv.

```php
  # Skapa ny instans av en regelsamling
  $rulesList = new FontFallBackRulesCollection();
  # skapa ett antal regler
  $rulesList->add(new FontFallBackRule(0x400, 0x4ff, "Times New Roman"));
  foreach($rulesList as $fallBackRule) {
    # Försöker ta bort fallback-typsnittet "Tahoma" från laddade regler
    $fallBackRule->remove("Tahoma");
    # Och att uppdatera regler för angivet intervall
    if (java_values($fallBackRule->getRangeEndIndex()) >= 0x4000 && java_values($fallBackRule->getRangeStartIndex()) < 0x5000) {
      $fallBackRule->addFallBackFonts("Verdana");
    }
  }
  # Vi kan också ta bort befintliga regler från listan
  if (java_values($rulesList->size()) > 0) {
    $rulesList->remove($rulesList->get_Item(0));
  }
  $pres = new Presentation("input.pptx");
  try {
    # Tilldelar en förberedd regelsamling för användning
    $pres->getFontsManager()->setFontFallBackRulesCollection($rulesList);
    # Renderar miniatyrbild med den initialiserade regelsamlingen och sparar som JPEG
    $slideImage = $pres->getSlides()->get_Item(0)->getImage(1.0, 1.0);
    # Spara bilden till disk i JPEG-format
    try {
      $slideImage->save("Slide_0.jpg", ImageFormat::Jpeg);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="primary" %}} 
Läs mer om hur du [konverterar PPT och PPTX till JPG i PHP](/slides/sv/php-java/convert-powerpoint-to-jpg/).
{{% /alert %}}
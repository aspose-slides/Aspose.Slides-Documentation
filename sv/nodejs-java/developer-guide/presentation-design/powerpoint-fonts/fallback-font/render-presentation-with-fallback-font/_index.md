---
title: Rendera presentationer med reservteckensnitt i JavaScript
linktitle: Rendera presentationer
type: docs
weight: 30
url: /sv/nodejs-java/render-presentation-with-fallback-font/
keywords:
- reservteckensnitt
- rendera PowerPoint
- rendera presentation
- rendera bild
- PowerPoint
- OpenDocument
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Rendera presentationer med reservteckensnitt i Aspose.Slides för Node.js - håll texten enhetlig i PPT, PPTX och ODP med steg-för-steg JavaScript-kodexempel."
---
## **Översikt**

Aspose.Slides låter dig rendera presentationer med reservteckensnittsregler. Den här artikeln visar hur du skapar en samling med reservteckensnittsregler, ändrar reglerna genom att ta bort eller lägga till reservteckensnitt och tilldelar samlingen med metoden `FontsManager.setFontFallBackRulesCollection`.

När samlingen med reservteckensnittsregler har tilldelats presentationens `FontsManager` tillämpas reglerna under operationer såsom sparande, rendering och konvertering av presentationen. Exemplet visar hur man använder de konfigurerade reglerna när man renderar en bildminiatyr för en bild och sparar den som en PNG-bild.

## **Rendera en bild med reservteckensnittsregler**

1. Vi [skapar en samling med reservteckensnittsregler](/slides/sv/nodejs-java/create-fallback-fonts-collection/).
1. Tar [bort](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/FontFallBackRule#remove-java.lang.String-) en reservteckensnittsregel och [addFallBackFonts](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) till en annan regel.
1. Ställ in reglersamlingen på [getFontsManager](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Presentation#getFontsManager--).[getFontFallBackRulesCollection](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/FontsManager#getFontFallBackRulesCollection--) metod.
1. Med [Presentation.save](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Presentation#save-java.lang.String-int-) metod kan vi spara presentationen i samma format eller spara den i ett annat. När samlingen med reservteckensnittsregler har tilldelats [FontsManager](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/FontsManager) tillämpas dessa regler under alla operationer på presentationen: spara, rendera, konvertera osv.

```javascript
// Skapa en ny instans av en regelkollektion
var rulesList = new aspose.slides.FontFallBackRulesCollection();
// skapa ett antal regler
rulesList.add(new aspose.slides.FontFallBackRule(0x400, 0x4ff, "Times New Roman"));
for (let i = 0; i < rulesList.size(); i++) {
    let fallBackRule = rulesList.get_Item(0);
    // Försöker att ta bort reservteckensnittet "Tahoma" från laddade regler
    fallBackRule.remove("Tahoma");
    // Och uppdatera regler för angivet intervall
    if ((fallBackRule.getRangeEndIndex() >= 0x4000) && (fallBackRule.getRangeStartIndex() < 0x5000)) {
        fallBackRule.addFallBackFonts("Verdana");
    }
}
// Vi kan också ta bort eventuella befintliga regler från listan
if (rulesList.size() > 0) {
    rulesList.remove(rulesList.get_Item(0));
}
var pres = new aspose.slides.Presentation("input.pptx");
try {
    // Tilldelar en förberedd regellista för användning
    pres.getFontsManager().setFontFallBackRulesCollection(rulesList);
    // Renderar en miniatyr med den initierade regelkollektionen och sparar som JPEG
    var slideImage = pres.getSlides().get_Item(0).getImage(1.0, 1.0);
    // Spara bilden till disk i JPEG-format
    try {
        slideImage.save("Slide_0.jpg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert color="primary" %}} 
Läs mer om hur du [Konverterar PPT och PPTX till JPG i JavaScript](/slides/sv/nodejs-java/convert-powerpoint-to-jpg/).
{{% /alert %}}
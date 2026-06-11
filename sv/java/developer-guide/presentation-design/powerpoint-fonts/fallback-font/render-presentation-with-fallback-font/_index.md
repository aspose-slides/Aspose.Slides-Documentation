---
title: Rendera presentationer med fallback‑typsnitt i Java
linktitle: Rendera presentationer
type: docs
weight: 30
url: /sv/java/render-presentation-with-fallback-font/
keywords:
- fallback-typsnitt
- rendera PowerPoint
- rendera presentation
- rendera bildruta
- PowerPoint
- OpenDocument
- presentation
- Java
- Aspose.Slides
description: "Rendera presentationer med fallback‑typsnitt i Aspose.Slides för Java – behåll texten konsekvent i PPT, PPTX och ODP med steg‑för‑steg Java‑kodexempel."
---
## **Översikt**

Aspose.Slides låter dig rendera presentationer med hjälp av fallback‑typsnittregler. Denna artikel visar hur du skapar en samling av fallback‑typsnittregler, ändrar dess regler genom att ta bort eller lägga till fallback‑typsnitt och tilldelar samlingen med metoden `FontsManager.setFontFallBackRulesCollection`.

När samlingen av fallback‑typsnittregler har tilldelats presentationens `FontsManager` tillämpas reglerna under operationer som sparande, rendering och konvertering av presentationen. Exemplet visar hur de konfigurerade reglerna används vid rendering av en bild på en bildruta och sparas som en PNG‑bild.

## **Rendera en bildruta med fallback‑typsnittregler**

1. Vi [skapar en samling av fallback‑typsnittregler](/slides/sv/java/create-fallback-fonts-collection/).
2. [Ta bort](https://reference.aspose.com/slides/sv/java/com.aspose.slides/FontFallBackRule#remove-java.lang.String-) en fallback‑typsnittregel och [addFallBackFonts](https://reference.aspose.com/slides/sv/java/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) till en annan regel.
3. Ställ in regelns samling till [getFontsManager](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Presentation#getFontsManager--).[getFontFallBackRulesCollection](https://reference.aspose.com/slides/sv/java/com.aspose.slides/FontsManager#getFontFallBackRulesCollection--)‑metoden.
4. Med [Presentation.save](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Presentation#save-java.lang.String-int-)‑metoden kan vi spara presentationen i samma format eller i ett annat. Efter att samlingen av fallback‑typsnittregler har tilldelats [FontsManager](https://reference.aspose.com/slides/sv/java/com.aspose.slides/FontsManager) tillämpas dessa regler under alla operationer på presentationen: spara, rendera, konvertera osv.

```java
// Skapa en ny instans av en regelkollektion
IFontFallBackRulesCollection rulesList = new FontFallBackRulesCollection();

// create a number of rules
rulesList.add(new FontFallBackRule(0x400, 0x4FF, "Times New Roman"));

for (IFontFallBackRule fallBackRule : rulesList)
{
    // Försöker ta bort fallback-typsnittet "Tahoma" från de inlästa reglerna
    fallBackRule.remove("Tahoma");

    // Och uppdatera regler för det angivna intervallet
    if ((fallBackRule.getRangeEndIndex() >= 0x4000) && (fallBackRule.getRangeStartIndex() < 0x5000))
        fallBackRule.addFallBackFonts("Verdana");
}

// Vi kan också ta bort befintliga regler från listan
if (rulesList.size() > 0)
    rulesList.remove(rulesList.get_Item(0));

Presentation pres = new Presentation("input.pptx");
try {
    // Tilldelar en förberedd regelista för användning
    pres.getFontsManager().setFontFallBackRulesCollection(rulesList);

    // Renderar en miniatyr med den initierade regelkollektionen och sparar som JPEG
   IImage slideImage = pres.getSlides().get_Item(0).getImage(1f, 1f);

   // Spara bilden till disk i JPEG-format
   try {
         slideImage.save("Slide_0.jpg", ImageFormat.Jpeg);
   } finally {
        if (slideImage != null) slideImage.dispose();
   }
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="primary" %}} 
Läs mer om hur man [konverterar PPT och PPTX till JPG i Java](/slides/sv/java/convert-powerpoint-to-jpg/).
{{% /alert %}}
---
title: Rendera presentationer med reservteckensnitt i Java
linktitle: Rendera presentationer
type: docs
weight: 30
url: /sv/java/render-presentation-with-fallback-font/
keywords:
- reservteckensnitt
- rendera PowerPoint
- rendera presentation
- rendera bildruta
- PowerPoint
- OpenDocument
- presentation
- Java
- Aspose.Slides
description: "Rendera presentationer med reservteckensnitt i Aspose.Slides för Java – behåll texten konsekvent över PPT, PPTX och ODP med steg-för-steg Java-kodexempel."
---
## **Översikt**

Aspose.Slides låter dig rendera presentationer med reservteckensnittregler. Den här artikeln visar hur du skapar en samling av reservteckensnittregler, ändrar dess regler genom att ta bort eller lägga till reservteckensnitt, och tilldelar samlingen med metoden `FontsManager.setFontFallBackRulesCollection`.

När samlingen av reservteckensnittregler har tilldelats presentationens `FontsManager` tillämpas reglerna under operationer som att spara, rendera och konvertera presentationen. Exemplet demonstrerar hur de konfigurerade reglerna används när en bildminiatyr av en bildruta renderas och sparas som en JPEG-bild.

## **Rendera en bildruta med reservteckensnittregler**

Följande exempel innehåller dessa steg:

1. Vi [skapar samling av reservteckensnittregler](/slides/sv/java/create-fallback-fonts-collection/).
1. [Ta bort](https://reference.aspose.com/slides/sv/java/com.aspose.slides/FontFallBackRule#remove-java.lang.String-) en reservteckensnittregel och [addFallBackFonts](https://reference.aspose.com/slides/sv/java/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) till en annan regel.
1. Ställ in reglersamlingen till [getFontsManager](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Presentation#getFontsManager--).[getFontFallBackRulesCollection](https://reference.aspose.com/slides/sv/java/com.aspose.slides/FontsManager#getFontFallBackRulesCollection--)‑metoden.
1. Med [Presentation.save](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Presentation#save-java.lang.String-int-)‑metoden kan vi spara presentationen i samma format eller spara den i ett annat. Efter att samlingen av reservteckensnittregler har satts till [FontsManager](https://reference.aspose.com/slides/sv/java/com.aspose.slides/FontsManager) tillämpas dessa regler under alla operationer på presentationen: spara, rendera, konvertera osv.

```java
import com.aspose.slides.*;

// Skapa en ny instans av en samling regler
IFontFallBackRulesCollection rulesList = new FontFallBackRulesCollection();

// create a number of rules
rulesList.add(new FontFallBackRule(0x400, 0x4FF, "Times New Roman"));
rulesList.add(new FontFallBackRule(0x600, 0x6FF, "Tahoma, Arial"));

for (IFontFallBackRule fallBackRule : rulesList)
{
    // Försöker ta bort reservteckensnittet "Tahoma" från laddade regler
    fallBackRule.remove("Tahoma");

    // Och uppdatera regler för angivet intervall
    if ((fallBackRule.getRangeEndIndex() >= 0x400) && (fallBackRule.getRangeStartIndex() < 0x500))
        fallBackRule.addFallBackFonts("Verdana");
}

// Vi kan också ta bort befintliga regler från listan, men behålla minst en regel för rendering
if (rulesList.size() > 1)
    rulesList.remove(rulesList.get_Item(1));

Presentation pres = new Presentation("input.pptx");
try {
    // Tilldelar en förberedd regellista för användning
    pres.getFontsManager().setFontFallBackRulesCollection(rulesList);

    // Renderar miniatyr med den initierade regelsamlingen och sparar som JPEG
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

{{% alert color="info" %}} 
Läs mer om hur man [konverterar PPT och PPTX till JPG i Java](/slides/sv/java/convert-powerpoint-to-jpg/).
{{% /alert %}}
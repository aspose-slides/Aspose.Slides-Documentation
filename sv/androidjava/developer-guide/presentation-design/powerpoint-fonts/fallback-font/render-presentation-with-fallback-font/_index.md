---
title: Rendera presentationer med reservtypsnitt på Android
linktitle: Rendera presentationer
type: docs
weight: 30
url: /sv/androidjava/render-presentation-with-fallback-font/
keywords:
- reservtypsnitt
- rendera PowerPoint
- rendera presentation
- rendera bildruta
- PowerPoint
- OpenDocument
- presentation
- Android
- Java
- Aspose.Slides
description: "Rendera presentationer med reservtypsnitt i Aspose.Slides för Android – håll texten konsekvent i PPT, PPTX och ODP med steg‑för‑steg Java‑kodexempel."
---
## **Översikt**

Aspose.Slides låter dig rendera presentationer med hjälp av reservtypsnittregler. Den här artikeln visar hur du skapar en samling av reservtypsnittregler, ändrar dess regler genom att ta bort eller lägga till reservtypsnitt, och tilldelar samlingen med metoden `FontsManager.setFontFallBackRulesCollection`.

När samlingen av reservtypsnittregler har tilldelats presentationens `FontsManager` tillämpas reglerna under operationer som att spara, rendera och konvertera presentationen. Exemplet visar hur man använder de konfigurerade reglerna när man renderar en bild av en bildruta och sparar den som en JPEG‑bild.

## **Rendera en bildruta med reservtypsnittregler**

1. Vi [skapar en samling av reservtypsnittregler](/slides/sv/androidjava/create-fallback-fonts-collection/).
1. [Ta bort](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/FontFallBackRule#remove-java.lang.String-) en reservtypsnittregel och [addFallBackFonts](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) till en annan regel.
1. Ställ in regelsamlingen på [getFontsManager](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/Presentation#getFontsManager--).[getFontFallBackRulesCollection](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/FontsManager#getFontFallBackRulesCollection--)‑metoden.
1. Med [Presentation.save](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-)‑metoden kan vi spara presentationen i samma format, eller spara den i ett annat. När reservtypsnittreglerna har satts på [FontsManager](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/FontsManager), tillämpas dessa regler under alla operationer på presentationen: spara, rendera, konvertera etc.

```java
import com.aspose.slides.*;

// Skapa en ny instans av en regelssamling
IFontFallBackRulesCollection rulesList = new FontFallBackRulesCollection();

// Skapa ett antal regler
rulesList.add(new FontFallBackRule(0x400, 0x4FF, "Times New Roman"));
rulesList.add(new FontFallBackRule(0x600, 0x6FF, "Tahoma, Arial"));

for (IFontFallBackRule fallBackRule : rulesList)
{
    // Försöker ta bort reservtypsnittet "Tahoma" från laddade regler
    fallBackRule.remove("Tahoma");

    // Och uppdatera reglerna för angivet intervall
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

    // Renderar en miniatyrbild med den initierade regelssamlingen och sparar som JPEG
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
Läs mer om [Konvertera PPT och PPTX till JPG på Android](/slides/sv/androidjava/convert-powerpoint-to-jpg/).
{{% /alert %}}
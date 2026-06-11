---
title: Rendera presentationer med reservteckensnitt på Android
linktitle: Rendera presentationer
type: docs
weight: 30
url: /sv/androidjava/render-presentation-with-fallback-font/
keywords:
- reservteckensnitt
- rendera PowerPoint
- rendera presentation
- rendera bildruta
- PowerPoint
- OpenDocument
- presentation
- Android
- Java
- Aspose.Slides
description: "Rendera presentationer med reservteckensnitt i Aspose.Slides för Android – håll texten konsekvent i PPT, PPTX och ODP med steg-för-steg Java-kodexempel."
---
## **Översikt**

Aspose.Slides låter dig rendera presentationer med hjälp av reservteckensnittsregler. Den här artikeln visar hur du skapar en samling av reservteckensnittsregler, ändrar dess regler genom att ta bort eller lägga till reservteckensnitt, och tilldelar samlingen med metoden `FontsManager.setFontFallBackRulesCollection`.

När samlingen av reservteckensnittsregler har tilldelats presentationens `FontsManager` tillämpas reglerna under operationer som att spara, rendera och konvertera presentationen. Exemplet visar hur du använder de konfigurerade reglerna när du renderar en bild av en bildruta och sparar den som en PNG-bild.

## **Rendera en bildruta med reservteckensnittsregler**

1. Vi [skapar samling av reservteckensnittsregler](/slides/sv/androidjava/create-fallback-fonts-collection/).
1. [Ta bort](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/FontFallBackRule#remove-java.lang.String-) en reservteckensnittsregel och [addFallBackFonts](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) till en annan regel.
1. Ställ in regelsamlingen till [getFontsManager](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/Presentation#getFontsManager--).[getFontFallBackRulesCollection](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/FontsManager#getFontFallBackRulesCollection--) metod.
1. Med [Presentation.save](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-) metod kan vi spara presentationen i samma format, eller spara den i ett annat. Efter att samlingen av reservteckensnittsregler har ställts in på [FontsManager](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/FontsManager) tillämpas dessa regler under alla operationer på presentationen: spara, rendera, konvertera osv.

```java
// Skapa en ny instans av en regelkollektion
IFontFallBackRulesCollection rulesList = new FontFallBackRulesCollection();

// Skapa ett antal regler
rulesList.add(new FontFallBackRule(0x400, 0x4FF, "Times New Roman"));

for (IFontFallBackRule fallBackRule : rulesList)
{
    // Försöker ta bort reservteckensnittet "Tahoma" från inlästa regler
    fallBackRule.remove("Tahoma");

    // Och uppdatera regler för angivet intervall
    if ((fallBackRule.getRangeEndIndex() >= 0x4000) && (fallBackRule.getRangeStartIndex() < 0x5000))
        fallBackRule.addFallBackFonts("Verdana");
}

// Vi kan också ta bort befintliga regler från listan
if (rulesList.size() > 0)
    rulesList.remove(rulesList.get_Item(0));

Presentation pres = new Presentation("input.pptx");
try {
    // Tilldelar en förberedd regellista för användning
    pres.getFontsManager().setFontFallBackRulesCollection(rulesList);

    // Renderar en miniatyrbild med den initierade regelkollektionen och sparar som JPEG
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
Läs mer om [Convert PPT and PPTX to JPG on Android](/slides/sv/androidjava/convert-powerpoint-to-jpg/).
{{% /alert %}}
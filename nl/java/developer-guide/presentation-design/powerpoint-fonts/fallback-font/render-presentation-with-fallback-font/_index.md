---
title: Presentaties renderen met fallback-lettertypen in Java
linktitle: Presentaties renderen
type: docs
weight: 30
url: /nl/java/render-presentation-with-fallback-font/
keywords:
- fallback-lettertype
- PowerPoint renderen
- presentatie renderen
- dia renderen
- PowerPoint
- OpenDocument
- presentatie
- Java
- Aspose.Slides
description: "Render presentaties met fallback-lettertypen in Aspose.Slides voor Java – houd tekst consistent over PPT, PPTX en ODP met stapsgewijze Java-codevoorbeelden."
---
## **Overzicht**

Aspose.Slides stelt u in staat presentaties te renderen met behulp van fallback‑lettertype‑regels. Dit artikel laat zien hoe u een collectie fallback‑lettertype‑regels maakt, de regels wijzigt door fallback‑lettertypen te verwijderen of toe te voegen, en de collectie toewijst met de `FontsManager.setFontFallBackRulesCollection`‑methode.

Zodra de collectie fallback‑lettertype‑regels is toegewezen aan de `FontsManager` van de presentatie, worden de regels toegepast tijdens bewerkingen zoals opslaan, renderen en converteren van de presentatie. Het voorbeeld laat zien hoe de geconfigureerde regels te gebruiken bij het renderen van een dia‑miniatuur en het opslaan ervan als JPEG‑afbeelding.

## **Een dia renderen met fallback‑lettertype‑regels**

1. We [maken een collectie fallback‑lettertype‑regels](/slides/nl/java/create-fallback-fonts-collection/).
2. [Verwijder](https://reference.aspose.com/slides/nl/java/com.aspose.slides/FontFallBackRule#remove-java.lang.String-) een fallback‑lettertype‑regel en [addFallBackFonts](https://reference.aspose.com/slides/nl/java/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) aan een andere regel.
3. Stel de regels‑collectie in op [getFontsManager](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Presentation#getFontsManager--).[getFontFallBackRulesCollection](https://reference.aspose.com/slides/nl/java/com.aspose.slides/FontsManager#getFontFallBackRulesCollection--) methode.
4. Met de [Presentation.save](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Presentation#save-java.lang.String-int-) methode kunnen we de presentatie opslaan in hetzelfde formaat, of in een ander formaat. Nadat de collectie fallback‑lettertype‑regels is ingesteld op [FontsManager](https://reference.aspose.com/slides/nl/java/com.aspose.slides/FontsManager), worden deze regels toegepast tijdens alle bewerkingen op de presentatie: opslaan, renderen, converteren, enz.

```java
import com.aspose.slides.*;

// Maak een nieuw exemplaar van een regelsverzameling
IFontFallBackRulesCollection rulesList = new FontFallBackRulesCollection();

// create a number of rules
rulesList.add(new FontFallBackRule(0x400, 0x4FF, "Times New Roman"));
rulesList.add(new FontFallBackRule(0x600, 0x6FF, "Tahoma, Arial"));

for (IFontFallBackRule fallBackRule : rulesList)
{
    // Proberen om fallback-lettertype "Tahoma" te verwijderen uit geladen regels
    fallBackRule.remove("Tahoma");

    // En de regels bijwerken voor het opgegeven bereik
    if ((fallBackRule.getRangeEndIndex() >= 0x400) && (fallBackRule.getRangeStartIndex() < 0x500))
        fallBackRule.addFallBackFonts("Verdana");
}

// We kunnen ook bestaande regels uit de lijst verwijderen, mits er minstens één regel overblijft om mee te renderen
if (rulesList.size() > 1)
    rulesList.remove(rulesList.get_Item(1));

Presentation pres = new Presentation("input.pptx");
try {
    // De voorbereide regelslijst toewijzen voor gebruik
    pres.getFontsManager().setFontFallBackRulesCollection(rulesList);

    // Een miniatuur renderen met behulp van de geïnitialiseerde regelscollectie en opslaan als JPEG
   IImage slideImage = pres.getSlides().get_Item(0).getImage(1f, 1f);

   // De afbeelding opslaan op schijf in JPEG-formaat
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
Lees meer over hoe u [PPT en PPTX naar JPG converteren in Java](/slides/nl/java/convert-powerpoint-to-jpg/).
{{% /alert %}}
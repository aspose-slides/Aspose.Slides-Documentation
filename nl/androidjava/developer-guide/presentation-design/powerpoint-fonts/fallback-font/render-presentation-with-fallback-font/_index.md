---
title: Presentaties renderen met fallback-lettertypen op Android
linktitle: Presentaties renderen
type: docs
weight: 30
url: /nl/androidjava/render-presentation-with-fallback-font/
keywords:
- fallback-lettertype
- PowerPoint renderen
- presentatie renderen
- dia renderen
- PowerPoint
- OpenDocument
- presentatie
- Android
- Java
- Aspose.Slides
description: "Render presentaties met fallback-lettertypen in Aspose.Slides voor Android – houd de tekst consistent in PPT, PPTX en ODP met stapsgewijze Java-codevoorbeelden."
---
## **Overzicht**

Aspose.Slides stelt u in staat presentaties te renderen met behulp van fallback‑lettertype‑regels. Dit artikel laat zien hoe u een fallback‑lettertype‑regels‑collectie maakt, de regels wijzigt door fallback‑lettertypen te verwijderen of toe te voegen, en de collectie toewijst met de `FontsManager.setFontFallBackRulesCollection`‑methode.

Zodra de collectie met fallback‑lettertype‑regels is toegewezen aan de `FontsManager` van de presentatie, worden de regels toegepast tijdens bewerkingen zoals opslaan, renderen en converteren van de presentatie. Het voorbeeld laat zien hoe u de geconfigureerde regels gebruikt bij het renderen van een diapresentatie‑miniatuur en het opslaan ervan als PNG‑afbeelding.

## **Een dia renderen met fallback‑lettertype‑regels**

De volgende voorbeeld omvat deze stappen:

1. We [creëren fallback‑lettertype‑regels‑collectie](/slides/nl/androidjava/create-fallback-fonts-collection/).
2. [Verwijderen](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/FontFallBackRule#remove-java.lang.String-) een fallback‑lettertype‑regel en [addFallBackFonts](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) aan een andere regel.
3. Stel de regels‑collectie in via [getFontsManager](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation#getFontsManager--).[getFontFallBackRulesCollection](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/FontsManager#getFontFallBackRulesCollection--)‑methode.
4. Met de [Presentation.save](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-)‑methode kunnen we de presentatie opslaan in hetzelfde formaat, of in een ander formaat. Nadat de fallback‑lettertype‑regels‑collectie is ingesteld op [FontsManager](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/FontsManager), worden deze regels toegepast tijdens alle bewerkingen op de presentatie: opslaan, renderen, converteren, enz.

```java
// Maak een nieuwe instantie van een regels‑collectie
IFontFallBackRulesCollection rulesList = new FontFallBackRulesCollection();

// maak een aantal regels
rulesList.add(new FontFallBackRule(0x400, 0x4FF, "Times New Roman"));

for (IFontFallBackRule fallBackRule : rulesList)
{
    // Proberen fallback‑lettertype "Tahoma" te verwijderen uit de geladen regels
    fallBackRule.remove("Tahoma");

    // En de regels bijwerken voor het opgegeven bereik
    if ((fallBackRule.getRangeEndIndex() >= 0x4000) && (fallBackRule.getRangeStartIndex() < 0x5000))
        fallBackRule.addFallBackFonts("Verdana");
}

// We kunnen ook bestaande regels uit de lijst verwijderen
if (rulesList.size() > 0)
    rulesList.remove(rulesList.get_Item(0));

Presentation pres = new Presentation("input.pptx");
try {
    // Een voorbereide regels‑lijst toewijzen voor gebruik
    pres.getFontsManager().setFontFallBackRulesCollection(rulesList);

    // Miniatuur renderen met gebruik van de geïnitialiseerde regels‑collectie en opslaan als JPEG
   IImage slideImage = pres.getSlides().get_Item(0).getImage(1f, 1f);

   // De afbeelding opslaan op schijf in JPEG‑formaat
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
Lees meer over [Converteer PPT en PPTX naar JPG op Android](/slides/nl/androidjava/convert-powerpoint-to-jpg/).
{{% /alert %}}
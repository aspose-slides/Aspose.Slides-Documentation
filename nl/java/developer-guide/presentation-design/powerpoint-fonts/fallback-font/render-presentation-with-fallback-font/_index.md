---
title: Render Presentaties met Fallback-lettertypen in Java
linktitle: Render Presentaties
type: docs
weight: 30
url: /nl/java/render-presentation-with-fallback-font/
keywords:
- fallback-lettertype
- PowerPoint renderen
- presentatie renderen
- slide renderen
- PowerPoint
- OpenDocument
- presentatie
- Java
- Aspose.Slides
description: "Render presentaties met fallback-lettertypen in Aspose.Slides voor Java – houd de tekst consistent over PPT, PPTX en ODP met stapsgewijze Java-codevoorbeelden."
---
## **Overzicht**

Aspose.Slides stelt u in staat presentaties te renderen met behulp van fallback-lettertype-regels. Dit artikel laat zien hoe u een collectie van fallback-lettertype‑regels maakt, de regels wijzigt door fallback-lettertypen te verwijderen of toe te voegen, en de collectie toewijst met de `FontsManager.setFontFallBackRulesCollection`‑methode.

Zodra de collectie van fallback-lettertype‑regels is toegewezen aan de `FontsManager` van de presentatie, worden de regels toegepast tijdens bewerkingen zoals opslaan, renderen en converteren van de presentatie. Het voorbeeld laat zien hoe de geconfigureerde regels te gebruiken bij het renderen van een slide‑miniatuur en deze op te slaan als PNG‑afbeelding.

## **Render een slide met fallback-lettertype‑regels**

Het volgende voorbeeld omvat deze stappen:

1. We [maken een collectie van fallback-lettertype‑regels](/slides/nl/java/create-fallback-fonts-collection/).
1. [Verwijder](https://reference.aspose.com/slides/nl/java/com.aspose.slides/FontFallBackRule#remove-java.lang.String-) een fallback-lettertype‑regel en [addFallBackFonts](https://reference.aspose.com/slides/nl/java/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) aan een andere regel.
1. Stel de regels‑collectie in op [getFontsManager](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Presentation#getFontsManager--).[getFontFallBackRulesCollection](https://reference.aspose.com/slides/nl/java/com.aspose.slides/FontsManager#getFontFallBackRulesCollection--) methode.
1. Met de [Presentation.save](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Presentation#save-java.lang.String-int-) methode kunnen we de presentatie opslaan in hetzelfde formaat, of in een ander formaat. Nadat de collectie van fallback-lettertype‑regels is ingesteld op [FontsManager](https://reference.aspose.com/slides/nl/java/com.aspose.slides/FontsManager), worden deze regels toegepast tijdens alle bewerkingen op de presentatie: opslaan, renderen, converteren, enz.

```java
// Maak een nieuw exemplaar van een regelsverzameling
IFontFallBackRulesCollection rulesList = new FontFallBackRulesCollection();

// maak een aantal regels
rulesList.add(new FontFallBackRule(0x400, 0x4FF, "Times New Roman"));

for (IFontFallBackRule fallBackRule : rulesList)
{
    // Probeer fallback-lettertype "Tahoma" te verwijderen uit de geladen regels
    fallBackRule.remove("Tahoma");

    // En om de regels bij te werken voor het opgegeven bereik
    if ((fallBackRule.getRangeEndIndex() >= 0x4000) && (fallBackRule.getRangeStartIndex() < 0x5000))
        fallBackRule.addFallBackFonts("Verdana");
}

// We kunnen ook alle bestaande regels uit de lijst verwijderen
if (rulesList.size() > 0)
    rulesList.remove(rulesList.get_Item(0));

Presentation pres = new Presentation("input.pptx");
try {
    // De voorbereide regelslijst toewijzen voor gebruik
    pres.getFontsManager().setFontFallBackRulesCollection(rulesList);

    // Miniatuur renderen met de geïnitialiseerde regelsverzameling en opslaan als JPEG
   IImage slideImage = pres.getSlides().get_Item(0).getImage(1f, 1f);

   // Sla de afbeelding op schijf op in JPEG-formaat
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
Lees meer over hoe u [PPT en PPTX naar JPG converteert in Java](/slides/nl/java/convert-powerpoint-to-jpg/).
{{% /alert %}}
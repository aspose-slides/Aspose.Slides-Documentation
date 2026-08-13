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
description: "Render presentaties met fallback-lettertypen in Aspose.Slides voor Android – zorg voor consistente tekst in PPT, PPTX en ODP met stapsgewijze Java-codevoorbeelden."
---
## **Overzicht**

Aspose.Slides stelt u in staat presentaties weer te geven met behulp van fallback-lettertype‑regels. Dit artikel laat zien hoe u een fallback‑lettertype‑regelsverzameling maakt, de regels wijzigt door fallback‑lettertypen te verwijderen of toe te voegen, en de verzameling toewijst met de `FontsManager.setFontFallBackRulesCollection`‑methode.

Zodra de fallback‑lettertype‑regelsverzameling is toegewezen aan de `FontsManager` van de presentatie, worden de regels toegepast tijdens bewerkingen zoals opslaan, renderen en converteren van de presentatie. Het voorbeeld laat zien hoe u de geconfigureerde regels gebruikt bij het renderen van een dia‑thumbnail en het opslaan ervan als JPEG‑afbeelding.

## **Render een dia met fallback‑lettertype‑regels**

Het volgende voorbeeld omvat deze stappen:

1. We [maken fallback‑lettertype‑regelsverzameling](/slides/nl/androidjava/create-fallback-fonts-collection/).
2. [Verwijderen](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/FontFallBackRule#remove-java.lang.String-) van een fallback‑lettertype‑regel en [addFallBackFonts](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) aan een andere regel.
3. Stel de regelsverzameling in op [getFontsManager](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation#getFontsManager--).[getFontFallBackRulesCollection](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/FontsManager#getFontFallBackRulesCollection--) methode.
4. Met de [Presentation.save](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-) methode kunnen we de presentatie opslaan in hetzelfde formaat, of in een ander formaat. Nadat de fallback‑lettertype‑regelsverzameling is ingesteld op [FontsManager](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/FontsManager), worden deze regels toegepast tijdens alle bewerkingen op de presentatie: opslaan, renderen, converteren, enz.

```java
import com.aspose.slides.*;

// Maak een nieuw exemplaar van een regelsverzameling
IFontFallBackRulesCollection rulesList = new FontFallBackRulesCollection();

// create a number of rules
rulesList.add(new FontFallBackRule(0x400, 0x4FF, "Times New Roman"));
rulesList.add(new FontFallBackRule(0x600, 0x6FF, "Tahoma, Arial"));

for (IFontFallBackRule fallBackRule : rulesList)
{
    // Probeer fallback-lettertype "Tahoma" te verwijderen uit de geladen regels
    fallBackRule.remove("Tahoma");

    // En de regels bijwerken voor het opgegeven bereik
    if ((fallBackRule.getRangeEndIndex() >= 0x400) && (fallBackRule.getRangeStartIndex() < 0x500))
        fallBackRule.addFallBackFonts("Verdana");
}

// We kunnen ook bestaande regels uit de lijst verwijderen, waarbij we minstens één regel behouden om mee te renderen
if (rulesList.size() > 1)
    rulesList.remove(rulesList.get_Item(1));

Presentation pres = new Presentation("input.pptx");
try {
    // Een voorbereide regelslijst toewijzen voor gebruik
    pres.getFontsManager().setFontFallBackRulesCollection(rulesList);

    // Rendering van thumbnail met gebruik van de geïnitialiseerde regelsverzameling en opslaan als JPEG
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

{{% alert color="info" %}} 
Lees meer over [PPT en PPTX converteren naar JPG op Android](/slides/nl/androidjava/convert-powerpoint-to-jpg/).
{{% /alert %}}
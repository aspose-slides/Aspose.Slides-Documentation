---
title: Presentaties renderen met fallback-lettertypen in JavaScript
linktitle: Presentaties renderen
type: docs
weight: 30
url: /nl/nodejs-java/render-presentation-with-fallback-font/
keywords:
- fallback-lettertype
- PowerPoint renderen
- presentatie renderen
- dia renderen
- PowerPoint
- OpenDocument
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Render presentaties met fallback-lettertypen in Aspose.Slides voor Node.js – houd de tekst consistent tussen PPT, PPTX en ODP met stapsgewijze JavaScript-codevoorbeelden."
---
## **Overzicht**

Aspose.Slides stelt u in staat om presentaties te renderen met fallback‑lettertype‑regels. Dit artikel laat zien hoe u een collectie fallback‑lettertype‑regels maakt, de regels wijzigt door fallback‑lettertypes te verwijderen of toe te voegen, en de collectie toewijst met de `FontsManager.setFontFallBackRulesCollection`‑methode.

Zodra de collectie fallback‑lettertype‑regels is toegewezen aan de `FontsManager` van de presentatie, worden de regels toegepast tijdens bewerkingen zoals opslaan, renderen en converteren van de presentatie. Het voorbeeld laat zien hoe de geconfigureerde regels te gebruiken bij het renderen van een dia‑miniatuur en deze op te slaan als PNG‑afbeelding.

## **Een dia renderen met fallback‑lettertype‑regels**

De volgende voorbeeld bevat deze stappen:

1. We [maken een collectie fallback‑lettertype‑regels](/slides/nl/nodejs-java/create-fallback-fonts-collection/).
2. [Verwijder](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/FontFallBackRule#remove-java.lang.String-) een fallback‑lettertype‑regel en [addFallBackFonts](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) aan een andere regel.
3. Stel de regels‑collectie in via [getFontsManager](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation#getFontsManager--).[getFontFallBackRulesCollection](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/FontsManager#getFontFallBackRulesCollection--)‑methode.
4. Met de [Presentation.save](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation#save-java.lang.String-int-)-methode kunnen we de presentatie opslaan in hetzelfde formaat, of in een ander formaat. Nadat de collectie fallback‑lettertype‑regels is ingesteld op de [FontsManager](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/FontsManager), worden deze regels toegepast tijdens alle bewerkingen op de presentatie: opslaan, renderen, converteren, enz.

```javascript
// Maak een nieuw exemplaar van een regelscollectie
var rulesList = new aspose.slides.FontFallBackRulesCollection();
// maak een aantal regels
rulesList.add(new aspose.slides.FontFallBackRule(0x400, 0x4ff, "Times New Roman"));
for (let i = 0; i < rulesList.size(); i++) {
    let fallBackRule = rulesList.get_Item(0);
    // Poging om fallback-lettertype "Tahoma" te verwijderen uit geladen regels
    fallBackRule.remove("Tahoma");
    // En om regels bij te werken voor het opgegeven bereik
    if ((fallBackRule.getRangeEndIndex() >= 0x4000) && (fallBackRule.getRangeStartIndex() < 0x5000)) {
        fallBackRule.addFallBackFonts("Verdana");
    }
}
// We kunnen ook bestaande regels uit de lijst verwijderen
if (rulesList.size() > 0) {
    rulesList.remove(rulesList.get_Item(0));
}
var pres = new aspose.slides.Presentation("input.pptx");
try {
    // Een voorbereide regelslijst toewijzen voor gebruik
    pres.getFontsManager().setFontFallBackRulesCollection(rulesList);
    // Miniatuur renderen met de geïnitialiseerde regelscollectie en opslaan als JPEG
    var slideImage = pres.getSlides().get_Item(0).getImage(1.0, 1.0);
    // De afbeelding opslaan op schijf in JPEG-formaat
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
Lees meer over hoe u [PPT en PPTX naar JPG converteert in JavaScript](/slides/nl/nodejs-java/convert-powerpoint-to-jpg/).
{{% /alert %}}
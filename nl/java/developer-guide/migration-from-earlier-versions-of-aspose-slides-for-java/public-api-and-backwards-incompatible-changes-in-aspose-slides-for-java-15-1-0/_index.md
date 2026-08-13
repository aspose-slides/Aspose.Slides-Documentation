---
title: Openbare API en terugwerkende incompatibele wijzigingen in Aspose.Slides for Java 15.1.0
linktitle: Aspose.Slides for Java 15.1.0
type: docs
weight: 100
url: /nl/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-1-0/
keywords:
- migratie
- legacycode
- moderne code
- legacy-aanpak
- moderne aanpak
- PowerPoint
- OpenDocument
- presentatie
- Java
- Aspose.Slides
description: "Bekijk de openbare API‑updates en breaking changes in Aspose.Slides for Java om uw PowerPoint PPT, PPTX en ODP presentaties soepel te migreren."
---
{{% alert color="info" %}} 
Deze pagina lijst alle [toegevoegde](/slides/nl/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-1-0/) klassen, methoden, eigenschappen enz., alle nieuwe beperkingen en andere [wijzigingen](/slides/nl/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-1-0/) die geïntroduceerd zijn met de Aspose.Slides for Java 15.1.0 API.
{{% /alert %}} {{% alert color="info" %}} 
Er zijn bekende problemen met sommige afbeeldingsbullets en WordArt‑objecten die zullen worden opgelost in Aspose.Slides for Java 15.2.0.
{{% /alert %}} 
## **Wijzigingen in de openbare API**
### **Functionaliteit voor lettertypevervangingen toegevoegd**
De mogelijkheid om lettertypen globaal in de presentatie en tijdelijk voor weergave te vervangen, is toegevoegd.

Er is een nieuwe methode getFontsManager() van de Presentation‑klasse geïntroduceerd. De FontsManager‑klasse heeft de volgende leden:

**IFontSubstRuleCollection getFontSubstRuleList**()‑methode  
Dit is de verzameling IFontSubstRule‑instanties die worden gebruikt om lettertypen tijdens het renderen te vervangen. IFontSubstRule heeft de methoden getSourceFont() en getDestFont() die de IFontData‑interface implementeren en de methode getReplaceFontCondition() die het vervangingscriterium ("WhenInaccessible" of "Always") laat kiezen.

**IFontData[] getFonts()**‑methode kan worden gebruikt om alle lettertypen op te halen die in de huidige presentatie worden gebruikt.

**replaceFont(...)**‑methoden kunnen worden gebruikt om een lettertype blijvend in een presentatie te vervangen.

Het volgende voorbeeld toont hoe een lettertype in een presentatie te vervangen:
``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation("PresContainsArialFont.pptx");

IFontData sourceFont = new FontData("Arial");

IFontData destFont = new FontData("Times New Roman");

pres.getFontsManager().replaceFont(sourceFont, destFont);

pres.save("PresContainsTimesNoewRomanFont.pptx", SaveFormat.Pptx);

```

Een ander voorbeeld toont lettertypevervanging voor weergave wanneer het niet toegankelijk is:
``` java
import com.aspose.slides.*;

Presentation pres = new Presentation("PresContainsSomeRareFontFont.pptx");
try {
    IFontData sourceFont = new FontData("SomeRareFont");
    IFontData destFont = new FontData("Arial");

    IFontSubstRule fontSubstRule = new FontSubstRule(sourceFont, destFont, FontSubstCondition.WhenInaccessible);

    IFontSubstRuleCollection fontSubstRuleCollection = new FontSubstRuleCollection();
    fontSubstRuleCollection.add(fontSubstRule);

    pres.getFontsManager().setFontSubstRuleList(fontSubstRuleCollection);

    // Arial lettertype wordt gebruikt in plaats van SomeRareFont wanneer het niet toegankelijk is.
    IImage slideImage = pres.getSlides().get_Item(0).getImage(1, 1);
    slideImage.dispose();
} finally {
    if (pres != null) pres.dispose();
}
```
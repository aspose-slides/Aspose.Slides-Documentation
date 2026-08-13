---
title: Offentligt API och bakåt inkompatibla ändringar i Aspose.Slides för Java 15.1.0
linktitle: Aspose.Slides för Java 15.1.0
type: docs
weight: 100
url: /sv/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-1-0/
keywords:
- migrering
- gammal kod
- modern kod
- gammal metod
- modern metod
- PowerPoint
- OpenDocument
- presentation
- Java
- Aspose.Slides
description: "Granska offentliga API‑uppdateringar och brytande förändringar i Aspose.Slides för Java för att smidigt migrera dina PowerPoint PPT, PPTX och ODP‑presentationslösningar."
---
{{% alert color="info" %}} 

Denna sida listar alla [tillagda](/slides/sv/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-1-0/) klasser, metoder, egenskaper osv., eventuella nya begränsningar och andra [ändringar](/slides/sv/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-1-0/) som införts med Aspose.Slides for Java 15.1.0 API.

{{% /alert %}} {{% alert color="info" %}} 

Det finns kända problem med vissa bildpunkter och WordArt-objekt som kommer att åtgärdas i Aspose.Slides for Java 15.2.0.

{{% /alert %}} 
## **Ändringar i offentligt API**
### **Funktionalitet för teckensnittssubstitution har lagts till**
Möjligheten att ersätta teckensnitt globalt i hela presentationen och tillfälligt vid rendering har lagts till.

Ny metod getFontsManager() i Presentation-klassen har introducerats. FontsManager-klassen har följande medlemmar:

**IFontSubstRuleCollection getFontSubstRuleList**() method  
Detta är samlingen av IFontSubstRule‑instanser som används för att ersätta teckensnitt under rendering. IFontSubstRule har metoderna getSourceFont() och getDestFont() som implementerar IFontData‑gränssnittet samt metoden getReplaceFontCondition() som möjliggör att välja ersättningsvillkoret ("WhenInaccessible" eller "Always").

Metoden **IFontData[] getFonts()** kan användas för att hämta alla teckensnitt som används i den aktuella presentationen.

Metoderna **replaceFont(...)** kan användas för att permanent ersätta ett teckensnitt i en presentation.

Följande exempel visar hur man ersätter ett teckensnitt i en presentation:

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation("PresContainsArialFont.pptx");

IFontData sourceFont = new FontData("Arial");

IFontData destFont = new FontData("Times New Roman");

pres.getFontsManager().replaceFont(sourceFont, destFont);

pres.save("PresContainsTimesNoewRomanFont.pptx", SaveFormat.Pptx);

```

Ett annat exempel visar teckensnittssubstitution för rendering när det är otillgängligt:

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

    // Arial-teckensnittet kommer att användas istället för SomeRareFont när det är otillgängligt.
    IImage slideImage = pres.getSlides().get_Item(0).getImage(1, 1);
    slideImage.dispose();
} finally {
    if (pres != null) pres.dispose();
}
```
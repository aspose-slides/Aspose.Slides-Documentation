---
title: Publikt API och bakåtinkompatibla ändringar i Aspose.Slides för Java 15.1.0
linktitle: Aspose.Slides för Java 15.1.0
type: docs
weight: 100
url: /sv/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-1-0/
keywords:
- migration
- gammal kod
- modern kod
- gammal metod
- modern metod
- PowerPoint
- OpenDocument
- presentation
- Java
- Aspose.Slides
description: "Granska publika API-uppdateringar och brytande förändringar i Aspose.Slides för Java för att smidigt migrera dina PowerPoint PPT-, PPTX- och ODP‑presentationslösningar."
---
{{% alert color="primary" %}} 

Den här sidan listar alla [tillagda](/slides/sv/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-1-0/) klasser, metoder, egenskaper osv., eventuella nya restriktioner och andra [ändringar](/slides/sv/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-1-0/) som introducerats med Aspose.Slides för Java 15.1.0 API.

{{% /alert %}} {{% alert color="primary" %}} 

Det finns kända problem med vissa bildpunkter och WordArt-objekt som kommer att åtgärdas i Aspose.Slides för Java 15.2.0.

{{% /alert %}} 
## **Offentliga API-ändringar**
### **Funktionalitet för teckensnittssubstitution har lagts till**
Möjligheten att ersätta teckensnitt globalt i hela presentationen och tillfälligt för rendering har lagts till.

Ny metod getFontsManager() i Presentation‑klassen har introducerats. FontsManager‑klassen har följande medlemmar:

**IFontSubstRuleCollection getFontSubstRuleList**() metod

Detta är samlingen av IFontSubstRule‑instanser som används för att byta teckensnitt under rendering. IFontSubstRule har metoderna getSourceFont() och getDestFont() som implementerar IFontData‑gränssnittet samt metoden getReplaceFontCondition() som möjliggör att välja villkoret för ersättning ("WhenInaccessible" eller "Always").

**IFontData[] getFonts()** metod kan användas för att hämta alla teckensnitt som används i den aktuella presentationen.

**replaceFont(...)** metoder kan användas för att permanent ersätta ett teckensnitt i en presentation. 

Följande exempel visar hur man ersätter ett teckensnitt i en presentation:

``` java

 Presentation pres = new Presentation("PresContainsArialFont.pptx");

IFontData sourceFont = new FontData("Arial");

IFontData destFont = new FontData("Times New Roman");

pres.getFontsManager().replaceFont(sourceFont, destFont);

pres.save("PresContainsTimesNoewRomanFont.pptx", SaveFormat.Pptx);

```

Ett annat exempel visar teckensnittssubstitution för rendering när det är otillgängligt:

``` java



Presentation pres = new Presentation("PresContainsSomeRareFontFont.pptx");

IFontData sourceFont = new FontData("SomeRareFont");

IFontData destFont = new FontData("Arial");

IFontSubstRule fontSubstRule = new FontSubstRule(

sourceFont, destFont, FontSubstCondition.WhenInaccessible);

IFontSubstRuleCollection fontSubstRuleCollection = new FontSubstRuleCollection();

fontSubstRuleCollection.add(fontSubstRule);

pres.getFontsManager().setFontSubstRuleList(fontSubstRuleCollection);

// Arial-teckensnittet kommer att användas istället för SomeRareFont när det är otillgängligt

pres.getSlides().get_Item(0).getThumbnail(1, 1);
```
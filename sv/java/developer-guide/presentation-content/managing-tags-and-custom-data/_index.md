---
title: Hantera taggar och anpassad data i presentationer med Java
linktitle: Taggar och anpassad data
type: docs
weight: 300
url: /sv/java/managing-tags-and-custom-data/
keywords:
- dokumentegenskaper
- tagg
- anpassad data
- lägga till tagg
- parvärden
- PowerPoint
- presentation
- Java
- Aspose.Slides
description: "Lär dig hur du lägger till, läser, uppdaterar och tar bort taggar och anpassad data i Aspose.Slides för Java, med exempel för PowerPoint- och OpenDocument-presentationer."
---
## **Översikt**

Denna artikel förklarar hur Aspose.Slides fungerar med taggar och anpassad data i PowerPoint-presentationer. Den ger en kort översikt över hur data lagras i PPTX‑filer, påpekar att presentationsspecifik data kan finnas som taggar och anpassade XML‑delar, och beskriver taggar som nyckel‑värdesträngpar.

Den visar också hur man läser taggvärden och hur man lägger till taggar i en presentation, ett enskilt slide eller en shape. Dessutom täcker artikeln vanliga uppgifter för tagghantering, såsom att rensa alla taggar, ta bort en tagg efter namn och hämta listan med taggnamn.

## **Datalagring i presentationsfiler**

PPTX‑filer—objekt med filändelsen .pptx—lagras i PresentationML‑formatet, som är en del av Office Open XML‑specifikationen. Office Open XML‑formatet definierar strukturen för data som finns i presentationer. 

Med en *slide* som ett av elementen i presentationer innehåller en *slide part* innehållet i en enskild slide. En slide part får ha explicita relationer till många delar—såsom User Defined Tags—definierade av ISO/IEC 29500. 

Anpassad data (specifik för en presentation) eller användare kan finnas som taggar ([ITagCollection](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ITagCollection)) och CustomXmlParts ([ICustomXmlPartCollection](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ICustomXmlPartCollection)). 

{{% alert color="primary" %}} 
Taggar är i huvudsak sträng‑nyckel‑parvärden. 
{{% /alert %}} 

## **Hämta värden för taggar**

I slides motsvarar en tagg metoderna [IDocumentProperties.getKeywords()](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IDocumentProperties#getKeywords--) och [IDocumentProperties.setKeywords()](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IDocumentProperties#setKeywords-java.lang.String-). Detta exempel visar hur man hämtar ett taggvärde med Aspose.Slides för Java för [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Presentation):

```java
Presentation pres = new Presentation("pres.pptx");
try{
    String keywords = pres.getDocumentProperties().getKeywords();
} finally {
    if (pres != null) pres.dispose();
}
```

## **Lägg till taggar i presentationer**

Aspose.Slides låter dig lägga till taggar i presentationer. En tagg består vanligtvis av två delar:

- namnet på en anpassad egenskap - `MyTag` 
- värdet på den anpassade egenskapen - `My Tag Value`

Om du behöver klassificera vissa presentationer baserat på en specifik regel eller egenskap kan det vara fördelaktigt att lägga till taggar i dessa presentationer. Till exempel, om du vill kategorisera eller samla alla presentationer från nordamerikanska länder, kan du skapa en North American‑tagg och sedan tilldela de relevanta länderna (USA, Mexiko och Kanada) som värden. 

Detta exempel visar hur du lägger till en tagg i en [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Presentation) med Aspose.Slides för Java:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    ITagCollection tags = pres.getCustomData().getTags();
    pres.getCustomData().getTags().set_Item("MyTag", "My Tag Value");
} finally {
    if (pres != null) pres.dispose();
}
```

Taggar kan också sättas för [Slide](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ISlide):

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    slide.getCustomData().getTags().set_Item("tag", "value");
} finally {
    if (pres != null) pres.dispose();
}
```

Eller någon enskild [Shape](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IAutoShape):

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 50);
    shape.getTextFrame().setText("My text");
    shape.getCustomData().getTags().set_Item("tag", "value");
} finally {
    if (pres != null) pres.dispose();
}
```

### **Begränsningar**

Taggar som läggs till via den anpassade datatagssamlingen med `getCustomData().getTags()` lagras endast i PowerPoint‑filen. De **överförs inte** till PDF‑taggstrukturen när presentationen exporteras till PDF. Följaktligen kan en anpassad identifierare som har tilldelats som tagg inte hämtas från den taggade PDF‑filen.

**Workaround**: Du kan lagra en anpassad identifierare i objektets **Alt Text** (t.ex. `shape.setAlternativeText("MyId")`). Efter export till PDF kan Alt Text visas i PDF‑taggstrukturen.

## **Vanliga frågor**

**Kan jag ta bort alla taggar från en presentation, slide eller shape i en enda operation?**

Ja. [Tag collection](https://reference.aspose.com/slides/sv/java/com.aspose.slides/tagcollection/) stödjer en [clear](https://reference.aspose.com/slides/sv/java/com.aspose.slides/tagcollection/#clear--)‑operation som tar bort alla nyckel‑värde‑par på en gång.

**Hur tar jag bort en enskild tagg efter namn utan att iterera över hela samlingen?**

Använd [Remove(name)](https://reference.aspose.com/slides/sv/java/com.aspose.slides/tagcollection/#remove-java.lang.String-)‑operationen på [tag collection](https://reference.aspose.com/slides/sv/java/com.aspose.slides/tagcollection/) för att ta bort taggen efter dess nyckel.

**Hur kan jag hämta den kompletta listan av taggnamn för analys eller filtrering?**

Använd [getNamesOfTags](https://reference.aspose.com/slides/sv/java/com.aspose.slides/tagcollection/#getNamesOfTags--) på [tag collection](https://reference.aspose.com/slides/sv/java/com.aspose.slides/tagcollection/); den returnerar en array med alla taggnamn.
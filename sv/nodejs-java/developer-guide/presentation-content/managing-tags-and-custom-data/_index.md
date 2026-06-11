---
title: Hantera taggar och anpassade data i presentationer med JavaScript
linktitle: Taggar och anpassade data
type: docs
weight: 300
url: /sv/nodejs-java/managing-tags-and-custom-data/
keywords:
- dokumentegenskaper
- tagg
- anpassade data
- lägga till tagg
- parvärden
- PowerPoint
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Lär dig hur du lägger till, läser, uppdaterar och tar bort taggar och anpassade data i Aspose.Slides för Node.js, med exempel för PowerPoint- och OpenDocument-presentationer."
---
## **Översikt**

Denna artikel förklarar hur Aspose.Slides arbetar med taggar och anpassade data i PowerPoint‑presentationer. Den ger en kort översikt över hur data lagras i PPTX‑filer, noterar att presentationsspecifik data kan finnas som taggar och anpassade XML‑delar, och beskriver taggar som nyckel‑värde‑strängpar.

Den visar också hur man läser tagg‑värden och hur man lägger till taggar i en presentation, ett enskilt bildspel eller en form. Dessutom behandlar artikeln vanliga uppgifter för tagghantering såsom att rensa alla taggar, ta bort en tagg efter namn och hämta listan med taggnamn.

## **Datainlagring i presentationsfiler**

PPTX‑filer — objekt med filändelsen .pptx — lagras i PresentationML‑formatet, som är en del av Office Open XML‑specifikationen. Office Open XML‑formatet definierar strukturen för data som finns i presentationer. 

Med en *slide* som ett av elementen i presentationer innehåller en *slide part* innehållet i en enskild bild. En slide part får ha explicita relationer till många delar — t.ex. User Defined Tags — enligt ISO/IEC 29500. 

Anpassade data (specifika för en presentation) eller användare kan finnas som taggar ([TagCollection](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/TagCollection)) och CustomXmlParts ([CustomXmlPartCollection](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/CustomXmlPartCollection)).

{{% alert color="primary" %}} 

Taggar är i grund och botten sträng‑nyckel‑par‑värden. 

{{% /alert %}} 

## **Hämta värden för taggar**

I slides motsvarar en tagg metoderna [DocumentProperties.getKeywords()](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/DocumentProperties#getKeywords--) och [DocumentProperties.setKeywords()](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/DocumentProperties#setKeywords-java.lang.String-). Detta exempel visar hur du får ett taggvärde med Aspose.Slides för Node.js via Java för [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Presentation):

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var keywords = pres.getDocumentProperties().getKeywords();
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Lägga till taggar i presentationer**

Aspose.Slides låter dig lägga till taggar i presentationer. En tagg består vanligtvis av två delar: 

- namnet på en anpassad egenskap — `MyTag` 
- värdet på den anpassade egenskapen — `My Tag Value`

Om du behöver klassificera vissa presentationer enligt en specifik regel eller egenskap kan du ha nytta av att lägga till taggar i dessa presentationer. Till exempel, om du vill gruppera alla presentationer från nordamerikanska länder, kan du skapa en North American‑tagg och sedan tilldela de relevanta länderna (USA, Mexiko och Kanada) som värden. 

Detta exempel visar hur du lägger till en tagg i en [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Presentation) med Aspose.Slides för Node.js via Java:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var tags = pres.getCustomData().getTags();
    pres.getCustomData().getTags().set_Item("MyTag", "My Tag Value");
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Taggar kan också sättas för [Slide](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Slide):

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    slide.getCustomData().getTags().set_Item("tag", "value");
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Eller för någon enskild [Shape](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/AutoShape):

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 50);
    shape.getTextFrame().setText("My text");
    shape.getCustomData().getTags().set_Item("tag", "value");
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Begränsningar**

Taggar som läggs till via den anpassade datatagg‑samlingen med `getCustomData().getTags()` lagras endast i PowerPoint‑filen. De **överförs inte** till PDF‑taggstrukturen när presentationen exporteras till PDF. Följaktligen kan en anpassad identifierare som tilldelats som en tagg inte hämtas från den taggade PDF‑filen.

**Workaround**: Du kan lagra en anpassad identifierare i objektets **Alt Text** (t.ex. `shape.setAlternativeText("MyId")`). Efter export till PDF kan Alt Text visas i PDF‑taggstrukturen.

## **FAQ**

**Kan jag ta bort alla taggar från en presentation, ett bildspel eller en form i en enda operation?**

Ja. [Tag‑samlingen](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/tagcollection/) stöder en [clear](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/tagcollection/clear/)‑operation som raderar alla nyckel‑värde‑par på en gång.

**Hur tar jag bort en enskild tagg efter namn utan att iterera över hela samlingen?**

Använd [remove(name)](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/tagcollection/remove/)-operationen på [TagCollection](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/tagcollection/) för att ta bort taggen efter dess nyckel.

**Hur kan jag hämta den kompletta listan med taggnamn för analys eller filtrering?**

Använd [getNamesOfTags](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/tagcollection/getnamesoftags/) på [tag‑samlingen](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/tagcollection/); den returnerar en array med alla taggnamn.
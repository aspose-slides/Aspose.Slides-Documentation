---
title: Hantera taggar och anpassade data i presentationer i .NET
linktitle: Taggar och anpassade data
type: docs
weight: 300
url: /sv/net/managing-tags-and-custom-data/
keywords:
- dokumentegenskaper
- tagg
- anpassade data
- lägga till tagg
- parvärden
- PowerPoint
- presentation
- .NET
- C#
- Aspose.Slides
description: "Lär dig hur du lägger till, läser, uppdaterar och tar bort taggar och anpassade data i Aspose.Slides för .NET, med exempel för PowerPoint- och OpenDocument-presentationer."
---
## **Översikt**

Denna artikel förklarar hur Aspose.Slides arbetar med taggar och anpassade data i PowerPoint-presentationer. Den ger en kort översikt över hur data lagras i PPTX-filer, noterar att presentationsspecifik data kan finnas som taggar och anpassade XML-delar, och beskriver taggar som nyckel‑värde‑strängpar.

Den visar också hur man läser taggvärden och hur man lägger till taggar i en presentation, en enskild bild eller en form. Dessutom täcker artikeln vanliga tagghanteringsuppgifter såsom att rensa alla taggar, ta bort en tagg efter namn och hämta listan med taggnamn.

## **Lagring av data i presentationsfiler**

PPTX-filer — objekt med filändelsen .pptx — lagras i PresentationML-formatet, som är en del av Office Open XML-specifikationen. Office Open XML-formatet definierar strukturen för data som finns i presentationer. 

Med en *slide* som ett av elementen i presentationer innehåller en *slide part* innehållet i en enskild bild. En slide part får ha explicita relationer till många delar — såsom User Defined Tags — som definieras av ISO/IEC 29500. 

Anpassade data (specifika för en presentation) eller användare kan finnas som taggar ([ITagCollection](https://reference.aspose.com/slides/sv/net/aspose.slides/itagcollection)) och CustomXmlParts ([ICustomXmlPartCollection](https://reference.aspose.com/slides/sv/net/aspose.slides/icustomxmlpartcollection)). 

{{% alert color="primary" %}} 
Taggar är i grund och botten sträng‑nyckel‑parvärden. 
{{% /alert %}} 

## **Hämta värden för taggar**

I slides motsvarar en tagg egenskapen IDocumentProperties.Keywords. Denna exempelkod visar hur du hämtar ett taggvärde med Aspose.Slides för .NET för [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation):

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   string keywords = pres.DocumentProperties.Keywords;
}
```

## **Lägg till taggar i presentationer**

Aspose.Slides låter dig lägga till taggar i presentationer. En tagg består vanligtvis av två delar: 

- namnet på en anpassad egenskap – `MyTag` 
- värdet på den anpassade egenskapen – `My Tag Value`

Om du behöver klassificera vissa presentationer baserat på en specifik regel eller egenskap kan det vara fördelaktigt att lägga till taggar i dessa presentationer. Till exempel, om du vill gruppera alla presentationer från Nordamerikanska länder kan du skapa en Nordamerikansk tagg och sedan tilldela de relevanta länderna (USA, Mexiko och Kanada) som värden. 

Denna exempelkod visar hur du lägger till en tagg i en [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation) med Aspose.Slides för .NET:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   ITagCollection tags = pres.CustomData.Tags;
   pres.CustomData.Tags["MyTag"] = "My Tag Value";
}
```

Taggar kan också sättas för [Slide](https://reference.aspose.com/slides/sv/net/aspose.slides/slide):

```csharp
using(Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    slide.CustomData.Tags["tag"] = "value";
}
```

Eller någon enskild [Shape](https://reference.aspose.com/slides/sv/net/aspose.slides/shape):

```csharp
using(Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 50);
    shape.TextFrame.Text = "My text";
    shape.CustomData.Tags["tag"] = "value";
}
```

### **Begränsningar**

Taggar som läggs till via samlingen `CustomData.Tags` lagras endast i PowerPoint-filen. De **överförs inte** till PDF-tagstrukturen när presentationen exporteras till PDF. Följaktligen kan en anpassad identifierare som tilldelats som tagg inte hämtas från den taggade PDF-filen.

**Alternativ lösning**: Du kan lagra en anpassad identifierare i objektets **Alt Text** (t.ex. `shape.AlternativeText = \"MyId\"`). Efter export till PDF kan Alt Text visas i PDF-tagstrukturen.

## **FAQ**

**Kan jag ta bort alla taggar från en presentation, en bild eller en form i en enda operation?**

Ja. [tag collection](https://reference.aspose.com/slides/sv/net/aspose.slides/tagcollection/) stöder en [clear](https://reference.aspose.com/slides/sv/net/aspose.slides/tagcollection/clear/) operation som tar bort alla nyckel‑värde‑par på en gång.

**Hur tar jag bort en enskild tagg efter namn utan att iterera över hela samlingen?**

Använd [Remove(name)](https://reference.aspose.com/slides/sv/net/aspose.slides/tagcollection/remove/) operationen på [TagCollection](https://reference.aspose.com/slides/sv/net/aspose.slides/tagcollection/) för att ta bort taggen efter dess nyckel.

**Hur kan jag hämta den kompletta listan med taggnamn för analys eller filtrering?**

Använd [GetNamesOfTags](https://reference.aspose.com/slides/sv/net/aspose.slides/tagcollection/getnamesoftags/) på [tag collection](https://reference.aspose.com/slides/sv/net/aspose.slides/tagcollection/); den returnerar en array med alla taggnamn.
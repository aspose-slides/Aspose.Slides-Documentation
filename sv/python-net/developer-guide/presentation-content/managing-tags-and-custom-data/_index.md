---
title: Hantera taggar och anpassad data i presentationer med Python
linktitle: Taggar och anpassad data
type: docs
weight: 300
url: /sv/python-net/managing-tags-and-custom-data/
keywords:
- dokumentegenskaper
- tagg
- anpassad data
- lägga till tagg
- parvärden
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Lär dig hur du lägger till, läser, uppdaterar och tar bort taggar och anpassad data i Aspose.Slides för Python via .NET, med exempel för PowerPoint- och OpenDocument-presentationer."
---
## **Översikt**

Den här artikeln förklarar hur Aspose.Slides fungerar med taggar och anpassad data i PowerPoint-presentationer. Den ger en kort översikt över hur data lagras i PPTX-filer, noterar att presentationsspecifik data kan finnas som taggar och anpassade XML-delar, och beskriver taggar som nyckel‑värdesträngpar.

Den visar också hur man läser taggvärden och hur man lägger till taggar i en presentation, ett enskilt bild eller en form. Dessutom behandlar artikeln vanliga tagghanteringsuppgifter som att rensa alla taggar, ta bort en tagg efter namn och hämta listan över taggnamn.

## **Datalagring i presentationsfiler**

PPTX-filer — objekt med filändelsen .pptx — lagras i PresentationML-formatet, som är en del av Office Open XML-specifikationen. Office Open XML-formatet definierar strukturen för data som finns i presentationer.

Med en *slide* som ett av elementen i presentationer innehåller en *slide‑part* innehållet i en enskild bild. En slide‑part får ha explicita relationer till många delar — såsom Användardefinierade taggar — definierade av ISO/IEC 29500.

Anpassad data (specifik för en presentation) eller användare kan finnas som taggar ([ITagCollection](https://reference.aspose.com/slides/sv/python-net/aspose.slides/itagcollection/)) och CustomXmlParts ([ICustomXmlPartCollection](https://reference.aspose.com/slides/sv/python-net/aspose.slides/icustomxmlpartcollection/)).

{{% alert color="primary" %}} 
Taggar är i princip nyckel‑värde‑strängpar. 
{{% /alert %}} 

## **Hämta värdena för taggar**

I slides motsvarar en tagg egenskapen IDocumentProperties.Keywords. Detta exempel visar hur du hämtar ett taggvärde med Aspose.Slides för Python via .NET för [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/):

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    print(pres.document_properties.keywords)
```

## **Lägg till taggar i presentationer**

Aspose.Slides låter dig lägga till taggar i presentationer. En tagg består vanligtvis av två element:

- namnet på en anpassad egendom – `MyTag`
- värdet på den anpassade egendomen – `My Tag Value`

Om du behöver klassificera vissa presentationer baserat på en specifik regel eller egenskap kan det vara fördelaktigt att lägga till taggar i dessa presentationer. Till exempel, om du vill kategorisera eller samla alla presentationer från Nordamerikanska länder, kan du skapa en Nordamerikansk tagg och sedan tilldela de relevanta länderna (USA, Mexiko och Kanada) som värden.

Detta exempel visar hur du lägger till en tagg i en [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/) med Aspose.Slides för Python via .NET:

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
   tags = pres.custom_data.tags 
   tags.add("MyTag", "My Tag Value")
```

Taggar kan också sättas för [Slide](https://reference.aspose.com/slides/sv/python-net/aspose.slides/slide/):

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    slide = pres.slides[0]
    tags = slide.custom_data.tags
    tags.add("tag", "value")
```

Eller vilken enskild [Shape](https://reference.aspose.com/slides/sv/python-net/aspose.slides/shape/) som helst:

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    slide = pres.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 50)
    shape.text_frame.text = "My text"
    shape.custom_data.tags.add("tag", "value")
```

### **Begränsningar**

Taggar som läggs till via `custom_data.tags`‑samlingen lagras endast i PowerPoint-filen. De **överförs inte** till PDF‑taggstrukturen när presentationen exporteras till PDF. Följaktligen kan en anpassad identifierare som tilldelats som tagg inte hämtas från den taggade PDF‑filen.

**Workaround**: Du kan lagra en anpassad identifierare i objektets **Alt Text** (t.ex. `shape.alternative_text = "MyId"`). Efter export till PDF kan Alt Text visas i PDF‑taggstrukturen.

## **Vanliga frågor**

**Kan jag ta bort alla taggar från en presentation, bild eller form i en enda operation?**

Ja. [Tagg‑samlingen](https://reference.aspose.com/slides/sv/python-net/aspose.slides/tagcollection/) stöder en [clear](https://reference.aspose.com/slides/sv/python-net/aspose.slides/tagcollection/clear/)‑operation som tar bort alla nyckel‑värde‑par på en gång.

**Hur tar jag bort en enskild tagg efter dess namn utan att iterera över hela samlingen?**

Använd [remove(name)](https://reference.aspose.com/slides/sv/python-net/aspose.slides/tagcollection/remove/)‑operationen på [TagCollection](https://reference.aspose.com/slides/sv/python-net/aspose.slides/tagcollection/) för att ta bort taggen efter dess nyckel.

**Hur kan jag hämta den kompletta listan med taggnamn för analys eller filtrering?**

Använd [get_names_of_tags](https://reference.aspose.com/slides/sv/python-net/aspose.slides/tagcollection/get_names_of_tags/) på [tag‑samlingen](https://reference.aspose.com/slides/sv/python-net/aspose.slides/tagcollection/); den returnerar en array med alla taggnamn.
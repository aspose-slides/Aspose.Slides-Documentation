---
title: Hantera taggar och anpassade data i presentationer med C++
linktitle: Taggar och anpassade data
type: docs
weight: 300
url: /sv/cpp/managing-tags-and-custom-data/
keywords:
- dokumentegenskaper
- tagg
- anpassade data
- lägga till tagg
- parvärden
- PowerPoint
- presentation
- C++
- Aspose.Slides
description: "Lär dig hur du lägger till, läser, uppdaterar och tar bort taggar och anpassade data i Aspose.Slides för C++, med exempel för PowerPoint- och OpenDocument-presentationer."
---
## **Översikt**

Den här artikeln förklarar hur Aspose.Slides fungerar med taggar och anpassade data i PowerPoint-presentationer. Den ger en kort översikt av hur data lagras i PPTX-filer, noterar att presentation‑specifik data kan finnas som taggar och anpassade XML‑delar, och beskriver taggar som nyckel‑värde‑strängpar.

Den visar också hur man läser taggvärden och hur man lägger till taggar i en presentation, ett enskilt bildspel eller en form. Dessutom behandlar artikeln vanliga tagghanteringsuppgifter såsom att rensa alla taggar, ta bort en tagg efter namn och hämta listan med taggnamn.

## **Datlagring i presentationsfiler**

PPTX‑filer – objekt med filändelsen .pptx – lagras i PresentationML‑formatet, som är en del av Office Open XML‑specifikationen. Office Open XML‑formatet definierar strukturen för data som ingår i presentationer.

Med ett *slide* som ett av elementen i presentationer innehåller ett *slide part* innehållet i ett enskilt bildspel. Ett slide‑part får ha explicita relationer till många delar – till exempel User Defined Tags – definierade av ISO/IEC 29500.

Anpassade data (specifika för en presentation) eller användare kan finnas som taggar ([ITagCollection](https://reference.aspose.com/slides/sv/cpp/aspose.slides/itagcollection/)) och CustomXmlParts ([ICustomXmlPartCollection](https://reference.aspose.com/slides/sv/cpp/aspose.slides/icustomxmlpartcollection/)).

{{% alert color="primary" %}} 
Taggar är i princip sträng‑nyckel‑parvärden. 
{{% /alert %}} 

## **Hämta taggvärden**

I Slides motsvarar en tagg egenskapen IDocumentProperties.Keywords. Detta exempel visar hur du hämtar en taggs värde med Aspose.Slides för C++ för [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/):

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
System::String keywords = pres->get_DocumentProperties()->get_Keywords();
```

## **Lägg till taggar i presentationer**

Aspose.Slides låter dig lägga till taggar i presentationer. En tagg består vanligtvis av två element:

- namnet på en anpassad egenskap - `MyTag` 
- värdet på den anpassade egenskapen - `My Tag Value`

Om du behöver klassificera vissa presentationer baserat på en specifik regel eller egenskap kan du dra nytta av att lägga till taggar i dessa presentationer. Till exempel, om du vill gruppera alla presentationer från Nordamerika tillsammans, kan du skapa en Nordamerika‑tagg och sedan tilldela de relevanta länderna (USA, Mexiko och Kanada) som värden.

Detta exempel visar hur du lägger till en tagg i en [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/) med Aspose.Slides för C++:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

System::SharedPtr<ITagCollection> tags = pres->get_CustomData()->get_Tags();
pres->get_CustomData()->get_Tags()->idx_set(u"MyTag", u"My Tag Value");
```

Taggar kan också ställas in för [Slide](https://reference.aspose.com/slides/sv/cpp/aspose.slides/slide/):

``` cpp
auto pres = System::MakeObject<Presentation>();

auto slide = pres->get_Slides()->idx_get(0);
slide->get_CustomData()->get_Tags()->idx_set(u"tag", u"value");
```

Eller för en enskild [Shape](https://reference.aspose.com/slides/sv/cpp/aspose.slides/shape/):

``` cpp
auto pres = System::MakeObject<Presentation>();

auto slide = pres->get_Slides()->idx_get(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 50.0f);
shape->get_TextFrame()->set_Text(u"My text");
shape->get_CustomData()->get_Tags()->idx_set(u"tag", u"value");
```

### **Begränsningar**

Taggar som läggs till via den anpassade datatagg‑samlingen med `get_CustomData()->get_Tags()` lagras endast inom PowerPoint‑filen. De **överförs inte** till PDF‑tagg‑strukturen när presentationen exporteras till PDF. Följaktligen kan en anpassad identifierare som tilldelats som en tagg inte hämtas från den taggade PDF‑filen.

**Workaround**: Du kan lagra en anpassad identifierare i objektets **Alt Text** (t.ex. `shape->set_AlternativeText(u"MyId")`). Efter export till PDF kan Alt‑Texten visas i PDF‑tagg‑strukturen.

## **FAQ**

**Kan jag ta bort alla taggar från en presentation, ett bildspel eller en form i en enda operation?**

Ja. [tag collection](https://reference.aspose.com/slides/sv/cpp/aspose.slides/tagcollection/) stödjer en [clear](https://reference.aspose.com/slides/sv/cpp/aspose.slides/tagcollection/clear/) operation som tar bort alla nyckel‑värdepar på en gång.

**Hur tar jag bort en enskild tagg efter dess namn utan att iterera över hela samlingen?**

Använd [Remove(name)](https://reference.aspose.com/slides/sv/cpp/aspose.slides/tagcollection/remove/) operation på [TagCollection](https://reference.aspose.com/slides/sv/cpp/aspose.slides/tagcollection/) för att ta bort taggen efter dess nyckel.

**Hur kan jag hämta den kompletta listan med taggnamn för analys eller filtrering?**

Använd [GetNamesOfTags](https://reference.aspose.com/slides/sv/cpp/aspose.slides/tagcollection/getnamesoftags/) på [tag collection](https://reference.aspose.com/slides/sv/cpp/aspose.slides/tagcollection/); den returnerar en array med alla taggnamn.
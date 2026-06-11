---
title: Hantera taggar och anpassad data i presentationer med PHP
linktitle: Taggar och anpassad data
type: docs
weight: 300
url: /sv/php-java/managing-tags-and-custom-data/
keywords:
- dokumentegenskaper
- tagg
- anpassad data
- lägga till tagg
- parvärden
- PowerPoint
- presentation
- PHP
- Aspose.Slides
description: "Lär dig hur du lägger till, läser, uppdaterar och tar bort taggar & anpassad data i Aspose.Slides för PHP via Java, med exempel för PowerPoint- och OpenDocument-presentationer."
---
## **Översikt**

Den här artikeln förklarar hur Aspose.Slides arbetar med taggar och anpassad data i PowerPoint-presentationer. Den ger en kort översikt över hur data lagras i PPTX-filer, påpekar att presentation-specifik data kan finnas som taggar och anpassade XML-delar, samt beskriver taggar som nyckel-värde-strängpar.

Den visar också hur man läser taggvärden och hur man lägger till taggar i en presentation, ett enskilt bild eller en form. Dessutom behandlar artikeln vanliga tagghanteringsuppgifter såsom att rensa alla taggar, ta bort en tagg efter namn och hämta listan över taggnamn.

## **Data lagring i presentationsfiler**

PPTX-filer - objekt med filändelsen .pptx - lagras i PresentationML-formatet, som är en del av Office Open XML-specifikationen. Office Open XML-formatet definierar strukturen för data som finns i presentationer. 

Med en *bild* som är ett av elementen i presentationer, innehåller en *bilddel* innehållet i en enda bild. En bilddel får ha explicita relationer till många delar - såsom User Defined Tags - definierade av ISO/IEC 29500. 

Anpassad data (specifik för en presentation) eller användare kan finnas som taggar ([TagCollection](https://reference.aspose.com/slides/sv/php-java/aspose.slides/tagcollection/)) och CustomXmlParts ([CustomXmlPartCollection](https://reference.aspose.com/slides/sv/php-java/aspose.slides/customxmlpartcollection/)).

{{% alert color="primary" %}} 
Taggar är i huvudsak nyckel-sträng-parvärden. 
{{% /alert %}} 

## **Hämta värden för taggar**

I slides motsvarar en tagg metoderna [DocumentProperties::getKeywords()](https://reference.aspose.com/slides/sv/php-java/aspose.slides/documentproperties/#getKeywords) och [DocumentProperties::setKeywords()](https://reference.aspose.com/slides/sv/php-java/aspose.slides/documentproperties/#setKeywords). Detta exempel visar hur du hämtar ett taggvärde med Aspose.Slides för PHP via Java för [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/Presentation):

```php
  $pres = new Presentation("pres.pptx");
  try {
    $keywords = $pres->getDocumentProperties()->getKeywords();
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Lägg till taggar i presentationer**

Aspose.Slides låter dig lägga till taggar i presentationer. En tagg består vanligtvis av två element:
- namnet på en anpassad egenskap - `MyTag`
- värdet på den anpassade egenskapen - `My Tag Value`

Om du behöver klassificera vissa presentationer baserat på en specifik regel eller egenskap kan du ha nytta av att lägga till taggar i dessa presentationer. Till exempel, om du vill gruppera alla presentationer från Nordamerika tillsammans kan du skapa en Nordamerikansk tagg och sedan tilldela de relevanta länderna (USA, Mexiko och Kanada) som värden.

Detta exempel visar hur du lägger till en tagg i en [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/Presentation) med Aspose.Slides för PHP via Java:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $tags = $pres->getCustomData()->getTags();
    $pres->getCustomData()->getTags()->set_Item("MyTag", "My Tag Value");
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Taggar kan också sättas för [Slide](https://reference.aspose.com/slides/sv/php-java/aspose.slides/slide/):

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $slide->getCustomData()->getTags()->set_Item("tag", "value");
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Eller någon enskild [Shape](https://reference.aspose.com/slides/sv/php-java/aspose.slides/shape/):

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 100, 50);
    $shape->getTextFrame()->setText("My text");
    $shape->getCustomData()->getTags()->set_Item("tag", "value");
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Begränsningar**

Taggar som lagts till via den anpassade datatagg-samlingen med `getCustomData()->getTags()` sparas endast i PowerPoint-filen. De **överförs inte** till PDF-tagstrukturen när presentationen exporteras till PDF. Följaktligen kan en anpassad identifierare som tilldelats som tagg inte hämtas från den taggade PDF-filen.

**Workaround**: Du kan lagra en anpassad identifierare i objektets **Alt Text** (t.ex. `$shape->setAlternativeText("MyId")`). Efter export till PDF kan Alt Text visas i PDF-tagstrukturen.

## **FAQ**

**Kan jag ta bort alla taggar från en presentation, bild eller form i en operation?**

Ja. [tag collection](https://reference.aspose.com/slides/sv/php-java/aspose.slides/tagcollection/) stöder en [clear](https://reference.aspose.com/slides/sv/php-java/aspose.slides/tagcollection/clear/)‑operation som tar bort alla nyckel‑värde‑par på en gång.

**Hur tar jag bort en enskild tagg efter namn utan att iterera över hela samlingen?**

Använd [remove(name)](https://reference.aspose.com/slides/sv/php-java/aspose.slides/tagcollection/remove/)‑operationen på [tag collection](https://reference.aspose.com/slides/sv/php-java/aspose.slides/tagcollection/) för att ta bort taggen efter dess nyckel.

**Hur kan jag hämta den kompletta listan över taggnamn för analys eller filtrering?**

Använd [getNamesOfTags](https://reference.aspose.com/slides/sv/php-java/aspose.slides/tagcollection/getnamesoftags/) på [tag collection](https://reference.aspose.com/slides/sv/php-java/aspose.slides/tagcollection/); den returnerar en array med alla taggnamn.
---
title: Hantera presentationsegenskaper i PHP
linktitle: Presentationsegenskaper
type: docs
weight: 70
url: /sv/php-java/presentation-properties/
keywords:
- PowerPoint-egenskaper
- presentationsegenskaper
- dokumentegenskaper
- inbyggda egenskaper
- anpassade egenskaper
- avancerade egenskaper
- hantera egenskaper
- ändra egenskaper
- dokumentmetadata
- redigera metadata
- korrekturspråk
- standardspråk
- PowerPoint
- OpenDocument
- presentation
- PHP
- Aspose.Slides
description: "Behärska presentationsegenskaper i Aspose.Slides för PHP via Java och effektivisera sökning, varumärkesprofilering och arbetsflöde i dina PowerPoint- och OpenDocument-filer."
---
## **Introduktion**

Aspose.Slides stöder två typer av dokumentegenskaper: **Built-in** och **Custom**. Båda dessa egenskapstyper kan enkelt nås och hanteras med hjälp av Aspose.Slides API.

Aspose.Slides låter dig arbeta med presentationsdokumentegenskaper via klassen [DocumentProperties](https://reference.aspose.com/slides/sv/php-java/aspose.slides/documentproperties/) . En instans av denna klass returneras av metoden [Presentation::getDocumentProperties](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/#getDocumentProperties) . Följande exempel visar hur man läser, ändrar och hanterar dessa egenskaper.

{{% alert color="primary" %}} 
Observera att fälten **Application** och **Producer** inte kan ändras, eftersom dessa fält alltid kommer att visa "Aspose Ltd." och "Aspose.Slides for PHP via Java x.x.x".
{{% /alert %}} 

## **Hantera presentationsegenskaper**

Microsoft PowerPoint erbjuder en funktion för att lägga till vissa egenskaper i presentationsfilerna. Dessa dokumentegenskaper gör det möjligt att lagra viss användbar information tillsammans med dokumenten (presentationsfiler). Det finns två typer av dokumentegenskaper enligt följande

- Systemdefinierade (Built-in) egenskaper
- Användardefinierade (Custom) egenskaper

**Built-in** egenskaper innehåller allmän information om dokumentet, såsom dokumenttitel, författarens namn, dokumentstatistik osv. **Custom** egenskaper är de som definieras av användarna som **Name/Value**-par, där både namn och värde anges av användaren. Med Aspose.Slides för PHP via Java kan utvecklare komma åt och ändra värdena för både inbyggda och anpassade egenskaper.

## **Dokumentegenskaper i PowerPoint**

Microsoft PowerPoint 2007 möjliggör hantering av dokumentegenskaperna för presentationsfilerna. Allt du behöver göra är att klicka på Office‑ikonen och sedan på menyobjektet **Prepare | Properties | Advanced Properties** i Microsoft PowerPoint 2007, som visas nedan:

|**Välja Avancerade egenskaper**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |

När du har valt menyalternativet **Advanced Properties** visas en dialogruta som låter dig hantera dokumentegenskaperna för PowerPoint‑filen, som visas i figuren nedan:

|**Egendomsdialog**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |

I ovanstående **Properties Dialog** kan du se att det finns många flikar såsom **General**, **Summary**, **Statistics**, **Contents** och **Custom**. Alla dessa flikar låter dig konfigurera olika typer av information relaterad till PowerPoint‑filerna. Fliken **Custom** används för att hantera de anpassade egenskaperna för PowerPoint‑filerna.

Arbeta med dokumentegenskaper med Aspose.Slides för PHP via Java

Som vi tidigare har beskrivit stödjer Aspose.Slides för PHP via Java två typer av dokumentegenskaper, nämligen **Built-in** och **Custom**. Därför kan utvecklare komma åt båda typerna av egenskaper med hjälp av Aspose.Slides för PHP via Java API. Aspose.Slides för PHP via Java tillhandahåller klassen [DocumentProperties](https://reference.aspose.com/slides/sv/php-java/aspose.slides/documentproperties) som representerar dokumentegenskaperna kopplade till en presentationsfil via egenskapen **Presentation.DocumentProperties**.

Utvecklare kan använda egenskapen **DocumentProperties** som exponeras av objektet [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation) för att komma åt dokumentegenskaperna för presentationsfilerna enligt beskrivningen nedan:

## **Åtkomst till inbyggda egenskaper**

Dessa egenskaper som exponeras av objektet [DocumentProperties] inkluderar: **Creator** (Author), **Description**, **Keywords**, **Created** (Creation Date), **Modified** (Modification Date), **Printed** (Last Print Date), **LastModifiedBy**, **Keywords**, **SharedDoc** (Is shared between different producers?), **PresentationFormat**, **Subject** och **Title**.

```php
  # Instansiera Presentation-klassen som representerar presentationen
  $pres = new Presentation("Presentation.pptx");
  try {
    # Skapa en referens till IDocumentProperties-objektet som är associerat med Presentation
    $dp = $pres->getDocumentProperties();
    # Visa de inbyggda egenskaperna
    echo("Category : " . $dp->getCategory());
    echo("Current Status : " . $dp->getContentStatus());
    echo("Creation Date : " . $dp->getCreatedTime());
    echo("Author : " . $dp->getAuthor());
    echo("Description : " . $dp->getComments());
    echo("KeyWords : " . $dp->getKeywords());
    echo("Last Modified By : " . $dp->getLastSavedBy());
    echo("Supervisor : " . $dp->getManager());
    echo("Modified Date : " . $dp->getLastSavedTime());
    echo("Presentation Format : " . $dp->getPresentationFormat());
    echo("Last Print Date : " . $dp->getLastPrinted());
    echo("Is Shared between producers : " . $dp->getSharedDoc());
    echo("Subject : " . $dp->getSubject());
    echo("Title : " . $dp->getTitle());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Ändra inbyggda egenskaper**

Att ändra de inbyggda egenskaperna för presentationsfiler är lika enkelt som att komma åt dem. Du kan helt enkelt tilldela ett strängvärde till valfri egenskap så förändras egenskapens värde. I exemplet nedan har vi demonstrerat hur vi kan ändra de inbyggda dokumentegenskaperna för presentationsfilen med Aspose.Slides för PHP via Java.

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    # Skapa en referens till IDocumentProperties-objektet som är associerat med Presentation
    $dp = $pres->getDocumentProperties();
    # Ställ in de inbyggda egenskaperna
    $dp->setAuthor("Aspose.Slides for PHP via Java");
    $dp->setTitle("Modifying Presentation Properties");
    $dp->setSubject("Aspose Subject");
    $dp->setComments("Aspose Description");
    $dp->setManager("Aspose Manager");
    # Spara din presentation till en fil
    $pres->save("DocProps.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Detta exempel ändrar de inbyggda egenskaperna för presentationen som kan visas nedan:

|**Inbyggda dokumentegenskaper efter ändring**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **Lägg till anpassade dokumentegenskaper**

Aspose.Slides för PHP via Java tillåter också utvecklare att lägga till anpassade värden för presentationsdokumentegenskaper. Ett exempel ges nedan som visar hur man sätter de anpassade egenskaperna för en presentation.

```php
  $pres = new Presentation();
  try {
    # Hämtar dokumentegenskaper
    $dProps = $pres->getDocumentProperties();
    # Lägger till anpassade egenskaper
    $dProps->set_Item("New Custom", 12);
    $dProps->set_Item("My Name", "Mudassir");
    $dProps->set_Item("Custom", 124);
    # Hämtar egenskapsnamn på ett särskilt index
    $getPropertyName = $dProps->getCustomPropertyName(2);
    # Tar bort vald egenskap
    $dProps->removeCustomProperty($getPropertyName);
    # Sparar presentation
    $pres->save("CustomDemo.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

|**Anpassade dokumentegenskaper tillagda**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **Åtkomst till och ändra anpassade egenskaper**

Aspose.Slides för PHP via Java tillåter också utvecklare att komma åt värdena för anpassade egenskaper. Ett exempel ges nedan som visar hur du kan komma åt och ändra alla dessa anpassade egenskaper för en presentation.

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    # Skapa en referens till DocumentProperties-objektet som är associerat med Presentation
    $dp = $pres->getDocumentProperties();
    # Åtkomst till och ändra anpassade egenskaper
    for($i = 0; $i < java_values($dp->getCountOfCustomProperties()) ; $i++) {
      # Visa namn och värden för anpassade egenskaper
      echo("Custom Property Name : " . $dp->getCustomPropertyName($i));
      echo("Custom Property Value : " . $dp->get_Item($dp->getCustomPropertyName($i)));
      # Ändra värden för anpassade egenskaper
      $dp->set_Item($dp->getCustomPropertyName($i), "New Value " . $i + 1);
    }
    # Spara presentationen till en fil
    $pres->save("CustomDemoModified.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Detta exempel ändrar de anpassade egenskaperna för [PPTX ](https://docs.fileformat.com/presentation/pptx/)presentationen. Följande figurer visar presentationens anpassade egenskaper före och efter ändring:

|**Anpassade egenskaper före ändring**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**Anpassade egenskaper efter ändring**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **Avancerade dokumentegenskaper**

{{% alert color="primary" %}} 
Nya metoder [readDocumentProperties](https://reference.aspose.com/slides/sv/php-java/aspose.slides/PresentationInfo/#readDocumentProperties), [updateDocumentProperties](https://reference.aspose.com/slides/sv/php-java/aspose.slides/PresentationInfo/#updateDocumentProperties) och [writeBindedPresentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/PresentationInfo/#writeBindedPresentation) har lagts till i [PresentationInfo](https://reference.aspose.com/slides/sv/php-java/aspose.slides/PresentationInfo), logiken för egenskapsinställaren [DocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/sv/php-java/aspose.slides/documentproperties/#setLastSavedTime) har ändrats.
{{% /alert %}} 

De två nya metoderna [readDocumentProperties](https://reference.aspose.com/slides/sv/php-java/aspose.slides/PresentationInfo/#readDocumentProperties) och [updateDocumentProperties](https://reference.aspose.com/slides/sv/php-java/aspose.slides/PresentationInfo/#updateDocumentProperties) har lagts till i klassen [PresentationInfo](https://reference.aspose.com/slides/sv/php-java/aspose.slides/PresentationInfo). De ger snabb åtkomst till dokumentegenskaper och möjliggör att ändra och uppdatera egenskaper utan att ladda en hel presentation.

Det typiska scenariot att ladda egenskaperna, ändra ett värde och uppdatera dokumentet kan implementeras på följande sätt:

```php
  # läs informationen om presentationen
  $info = PresentationFactory->getInstance()->getPresentationInfo("presentation.pptx");
  # hämta de aktuella egenskaperna
  $props = $info->readDocumentProperties();
  # sätt de nya värdena för fälten Author och Title
  $props->setAuthor("New Author");
  $props->setTitle("New Title");
  # uppdatera presentationen med nya värden
  $info->updateDocumentProperties($props);
  $info->writeBindedPresentation("presentation.pptx");
```

Det finns ett annat sätt att använda egenskaper från en specifik presentation som mall för att uppdatera egenskaper i andra presentationer:

```php
  $info = PresentationFactory->getInstance()->getPresentationInfo("template.pptx");
  $template = $info->readDocumentProperties();
  $template->setAuthor("Template Author");
  $template->setTitle("Template Title");
  $template->setCategory("Template Category");
  $template->setKeywords("Keyword1, Keyword2, Keyword3");
  $template->setCompany("Our Company");
  $template->setComments("Created from template");
  $template->setContentType("Template Content");
  $template->setSubject("Template Subject");
  updateByTemplate("doc1.pptx", $template);
  updateByTemplate("doc2.odp", $template);
  updateByTemplate("doc3.ppt", $template);
```

```php

```

En ny mall kan skapas från grunden och sedan användas för att uppdatera flera presentationer:

```php
  $template = new DocumentProperties();
  $template->setAuthor("Template Author");
  $template->setTitle("Template Title");
  $template->setCategory("Template Category");
  $template->setKeywords("Keyword1, Keyword2, Keyword3");
  $template->setCompany("Our Company");
  $template->setComments("Created from template");
  $template->setContentType("Template Content");
  $template->setSubject("Template Subject");
  updateByTemplate("doc1.pptx", $template);
  updateByTemplate("doc2.odp", $template);
  updateByTemplate("doc3.ppt", $template);
```

## **Ange korrekturspråk**

Aspose.Slides tillhandahåller egenskapen LanguageId (exponerad av klassen PortionFormat) för att låta dig ange korrekturspråket för ett PowerPoint‑dokument. Korrekturspråket är det språk som stavning och grammatik i PowerPoint kontrolleras för.

Denna PHP‑kod visar hur du anger korrekturspråket för en PowerPoint: xxx Varför saknas LanguageId i Java‑klassen PortionFormat?

```php
  $pres = new Presentation($pptxFileName);
  try {
    $autoShape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->getPortions()->clear();
    $newPortion = new Portion();
    $font = new FontData("SimSun");
    $portionFormat = $newPortion->getPortionFormat();
    $portionFormat::setComplexScriptFont($font);
    $portionFormat::setEastAsianFont($font);
    $portionFormat::setLatinFont($font);
    $portionFormat::setLanguageId("zh-CN");// sätt id för ett korrekturspråk

    $newPortion->setText("1。");
    $paragraph->getPortions()->add($newPortion);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Ange standardspråk**

Denna PHP‑kod visar hur du anger standardspråket för en hel PowerPoint‑presentation:

```php
  $loadOptions = new LoadOptions();
  $loadOptions->setDefaultTextLanguage("en-US");
  $pres = new Presentation($loadOptions);
  try {
    # Lägger till en ny rektangelform med text
    $shp = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 50);
    $shp->getTextFrame()->setText("New Text");
    # Kontrollerar första portionsspråket
    echo($shp->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->getLanguageId());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Live‑exempel**

Prova [**Aspose.Slides Metadata**](https://products.aspose.app/slides/sv/metadata) online‑appen för att se hur du arbetar med dokumentegenskaper via Aspose.Slides API:

[![Visa & redigera PowerPoint‑metadata](slides-metadata.png)](https://products.aspose.app/slides/sv/metadata)

## **FAQ**

**Hur kan jag ta bort en inbyggd egenskap från en presentation?**

Inbyggda egenskaper är en integrerad del av presentationen och kan inte tas bort helt. Du kan dock ändra deras värden eller sätta dem till tomma om det tillåts av den specifika egenskapen.

**Vad händer om jag lägger till en anpassad egenskap som redan finns?**

Om du lägger till en anpassad egenskap som redan finns, kommer dess befintliga värde att skrivas över med det nya. Du behöver inte ta bort eller kontrollera egenskapen i förväg, eftersom Aspose.Slides automatiskt uppdaterar egenskapens värde.

**Kan jag komma åt presentationsegenskaper utan att ladda hela presentationen?**

Ja, du kan komma åt presentationsegenskaper utan att ladda hela presentationen genom att använda metoden `getPresentationInfo` från klassen [PresentationFactory](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentationfactory/). Använd sedan metoden `readDocumentProperties` som tillhandahålls av klassen [PresentationInfo](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentationinfo/) för att läsa egenskaperna effektivt, vilket sparar minne och förbättrar prestanda.
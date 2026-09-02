---
title: Hantera presentationsegenskaper i PHP
linktitle: Presentationsegenskaper
type: docs
weight: 70
url: /sv/php-java/presentation-properties/
keywords:
- PowerPoint-egenskaper
- presentations-egenskaper
- dokumentegenskaper
- inbyggda egenskaper
- anpassade egenskaper
- avancerade egenskaper
- hantera egenskaper
- modifiera egenskaper
- dokumentmetadata
- redigera metadata
- korrekturläsningsspråk
- standardspråk
- PowerPoint
- OpenDocument
- presentation
- PHP
- Aspose.Slides
description: "Behärska presentationsegenskaper i Aspose.Slides för PHP via Java och effektivisera sökning, varumärkesprofilering och arbetsflöde i dina PowerPoint- och OpenDocument-filer."
---
## **Introduktion**

Aspose.Slides stöder två typer av dokumentegenskaper: **Inbyggda** och **Anpassade**. Båda dessa egenskapstyper kan enkelt nås och hanteras med Aspose.Slides‑API‑et.

Aspose.Slides låter dig arbeta med presentationsdokumentegenskaper via klassen [DocumentProperties](https://reference.aspose.com/slides/sv/php-java/aspose.slides/documentproperties/) . En instans av denna klass returneras av metoden [Presentation::getDocumentProperties](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/#getDocumentProperties). Följande exempel visar hur man läser, ändrar och hanterar dessa egenskaper.

{{% alert color="info" title="Note" %}}
Observera att fälten **Application** och **AppVersion** inte kan ändras. Aspose.Slides skriver om dem vid varje sparning, så en sparad presentation alltid rapporterar "Aspose.Slides for PHP via Java" och versionen av biblioteket som skapade den. Eventuellt värde som skickas till `setNameOfApplication` kastas bort när presentationen skrivs.
{{% /alert %}} 

## **Hantera presentationsegenskaper**

Microsoft PowerPoint erbjuder en funktion för att lägga till vissa egenskaper i presentationsfilerna. Dessa dokumentegenskaper gör det möjligt att lagra användbar information tillsammans med dokumenten (presentationsfilerna). Det finns två typer av dokumentegenskaper:

- Systemdefinierade (Inbyggda) egenskaper  
- Användardefinierade (Anpassade) egenskaper  

**Inbyggda** egenskaper innehåller generell information om dokumentet, såsom dokumenttitel, författarens namn, dokumentstatistik med mera. **Anpassade** egenskaper är de som användarna definierar som **Namn/Värde**‑par, där både namn och värde bestäms av användaren. Med Aspose.Slides for PHP via Java kan utvecklare komma åt och ändra både inbyggda och anpassade egenskaper.

## **Dokumentegenskaper i PowerPoint**

Microsoft PowerPoint 2007 möjliggör hantering av dokumentegenskaper i presentationsfilerna. Allt du behöver göra är att klicka på Office‑ikonen och sedan **Prepare | Properties | Advanced Properties** i Microsoft PowerPoint 2007 som visas nedan:

|**Välja menyalternativet Advanced Properties**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |
När du har valt **Advanced Properties** visas en dialogruta som låter dig hantera dokumentegenskaperna i PowerPoint‑filen, enligt bilden nedan:

|**Egenskapsdialog**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |
I ovanstående **Egenskapsdialog** ser du flikar som **General**, **Summary**, **Statistics**, **Contents** och **Custom**. Alla dessa flikar låter dig konfigurera olika typer av information relaterad till PowerPoint‑filerna. Fliken **Custom** används för att hantera anpassade egenskaper i PowerPoint‑filerna.

### Arbeta med dokumentegenskaper med Aspose.Slides for PHP via Java

Som vi tidigare beskrivit stödjer Aspose.Slides for PHP via Java två typer av dokumentegenskaper: **Inbyggda** och **Anpassade**. Således kan utvecklare komma åt båda typerna med Aspose.Slides for PHP via Java‑API:t. Aspose.Slides for PHP via Java tillhandahåller klassen [DocumentProperties](https://reference.aspose.com/slides/sv/php-java/aspose.slides/documentproperties) som representerar dokumentegenskaperna som är associerade med en presentationsfil via egenskapen **Presentation.DocumentProperties**.

Utvecklare kan använda egenskapen **DocumentProperties** som exponeras av [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation)-objektet för att nå dokumentegenskaperna i presentationsfilerna enligt nedan:

## **Kom åt inbyggda egenskaper**

De egenskaper som exponeras av objektet [DocumentProperties](https://reference.aspose.com/slides/sv/php-java/aspose.slides/documentproperties) inkluderar: **Creator** (Author), **Description**, **Keywords**, **Created** (Creation Date), **Modified** (Modification Date), **Printed** (Last Print Date), **LastModifiedBy**, **SharedDoc** (Is shared between different producers?), **PresentationFormat**, **Subject** och **Title**.

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

Att ändra de inbyggda egenskaperna i presentationsfiler är lika enkelt som att komma åt dem. Du kan helt enkelt tilldela ett strängvärde till någon önskad egenskap så uppdateras värdet. I exemplet nedan demonstreras hur de inbyggda dokumentegenskaperna i presentationsfilen kan ändras med Aspose.Slides for PHP via Java.

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    # Skapa en referens till IDocumentProperties-objektet som är associerat med Presentation
    $dp = $pres->getDocumentProperties();
    # Ange de inbyggda egenskaperna
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

Detta exempel ändrar de inbyggda egenskaperna i presentationen som visas nedan:

|**Inbyggda dokumentegenskaper efter ändring**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **Lägg till anpassade dokumentegenskaper**

Aspose.Slides for PHP via Java låter också utvecklare lägga till anpassade värden för presentationsdokumentegenskaper. Exemplet nedan visar hur man sätter anpassade egenskaper för en presentation.

```php
  $pres = new Presentation();
  try {
    # Hämtar dokumentegenskaper
    $dProps = $pres->getDocumentProperties();
    # Lägger till anpassade egenskaper
    $dProps->set_Item("New Custom", 12);
    $dProps->set_Item("My Name", "Mudassir");
    $dProps->set_Item("Custom", 124);
    # Hämtar egenskapsnamn vid specifikt index
    $getPropertyName = $dProps->getCustomPropertyName(2);
    # Tar bort vald egenskap
    $dProps->removeCustomProperty($getPropertyName);
    # Sparar presentationen
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

## **Kom åt och ändra anpassade egenskaper**

Aspose.Slides for PHP via Java låter även utvecklare komma åt värdena för anpassade egenskaper. Exemplet nedan visar hur du kan komma åt och ändra alla dessa anpassade egenskaper för en presentation.

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
    # Spara din presentation till en fil
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

{{% alert color="info" title="Note" %}}
Nya metoder [readDocumentProperties](https://reference.aspose.com/slides/sv/php-java/aspose.slides/PresentationInfo/#readDocumentProperties), [updateDocumentProperties](https://reference.aspose.com/slides/sv/php-java/aspose.slides/PresentationInfo/#updateDocumentProperties) och [writeBindedPresentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/PresentationInfo/#writeBindedPresentation) har lagts till i [PresentationInfo](https://reference.aspose.com/slides/sv/php-java/aspose.slides/PresentationInfo); logiken för egenskapsinställaren [DocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/sv/php-java/aspose.slides/documentproperties/#setLastSavedTime) har ändrats.
{{% /alert %}} 

De två nya metoderna [readDocumentProperties](https://reference.aspose.com/slides/sv/php-java/aspose.slides/PresentationInfo/#readDocumentProperties) och [updateDocumentProperties](https://reference.aspose.com/slides/sv/php-java/aspose.slides/PresentationInfo/#updateDocumentProperties) har lagts till i klassen [PresentationInfo](https://reference.aspose.com/slides/sv/php-java/aspose.slides/PresentationInfo). De ger snabb åtkomst till dokumentegenskaper och möjliggör att ändra och uppdatera egenskaper utan att ladda en hel presentation.

Det typiska scenariot – ladda egenskaper, ändra ett värde och uppdatera dokumentet – kan implementeras på följande sätt:

```php
  # läs informationen om presentationen
  $info = PresentationFactory->getInstance()->getPresentationInfo("presentation.pptx");
  # hämta de aktuella egenskaperna
  $props = $info->readDocumentProperties();
  # ange de nya värdena för författare- och titel-fälten
  $props->setAuthor("New Author");
  $props->setTitle("New Title");
  # uppdatera presentationen med nya värden
  $info->updateDocumentProperties($props);
  $info->writeBindedPresentation("presentation.pptx");
```

Det finns ett annat sätt att använda egenskaper i en specifik presentation som mall för att uppdatera egenskaper i andra presentationer:

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

## **Ange rättstavningsspråk**

Aspose.Slides tillhandahåller egenskapen LanguageId (exponerad av klassen PortionFormat) för att låta dig ange rättstavningsspråket för ett PowerPoint‑dokument. Rättstavningsspråket är det språk som stavnings‑ och grammatikkontrollen i PowerPoint använder.

Denna PHP‑kod visar hur du anger rättstavningsspråket för en PowerPoint‑presentation: xxx Why is LanguageId missing from Java PortionFormat class?

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    $autoShape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->getPortions()->clear();
    $newPortion = new Portion();
    $font = new FontData("SimSun");
    $portionFormat = $newPortion->getPortionFormat();
    $portionFormat->setComplexScriptFont($font);
    $portionFormat->setEastAsianFont($font);
    $portionFormat->setLatinFont($font);
    $portionFormat->setLanguageId("zh-CN");// ange ID för ett korrekturläsningsspråk

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
    # Kontrollerar språk för den första delen
    echo($shp->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->getLanguageId());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Live‑exempel**

Prova **[Aspose.Slides Metadata](https://products.aspose.app/slides/sv/metadata)**‑online‑appen för att se hur du arbetar med dokumentegenskaper via Aspose.Slides‑API:t:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/sv/metadata)

## **FAQ**

**Hur kan jag ta bort en inbyggd egenskap från en presentation?**

Inbyggda egenskaper är en integrerad del av presentationen och kan inte tas bort helt. Du kan dock ändra deras värden eller, om egenskapen tillåter det, sätta dem till tomma.

**Vad händer om jag lägger till en anpassad egenskap som redan finns?**

Om du lägger till en anpassad egenskap som redan finns, kommer dess befintliga värde att skrivas över med det nya. Du behöver inte ta bort eller kontrollera egenskapen i förväg, eftersom Aspose.Slides automatiskt uppdaterar egenskapsvärdet.

**Kan jag komma åt presentationsegenskaper utan att ladda hela presentationen?**

Ja. Använd [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentationfactory/) och sedan [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentationinfo/#readDocumentProperties) för att läsa lagrad dokumentmetadata utan att skapa ett [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/)‑objekt. Se [Build a Lightweight Presentation Inventory](/slides/sv/php-java/examine-presentation/) för ett komplett rapporteringsexempel och format‑specifika begränsningar.
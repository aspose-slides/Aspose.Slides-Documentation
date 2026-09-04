---
title: Hantera presentationsegenskaper i PHP
linktitle: Presentationsegenskaper
type: docs
weight: 70
url: /sv/php-java/presentation-properties/
keywords:
- PowerPoint egenskaper
- presentations egenskaper
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
description: "Behärska presentationsegenskaper i Aspose.Slides för PHP via Java och effektivisera sökning, varumärkesprofilering och arbetsflöde i dina PowerPoint och OpenDocument filer."
---
## **Introduktion**

Aspose.Slides stöder två typer av dokumentegenskaper: **Inbyggda** och **Anpassade**. Båda dessa egenskapstyper kan enkelt nås och hanteras med Aspose.Slides API.

Aspose.Slides låter dig arbeta med presentationsdokumentegenskaper via klassen [DocumentProperties](https://reference.aspose.com/slides/sv/php-java/aspose.slides/documentproperties/) . En instans av denna klass returneras av metoden [Presentation::getDocumentProperties](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/#getDocumentProperties) . Följande exempel visar hur man läser, modifierar och hanterar dessa egenskaper.

{{% alert color="info" title="Note" %}}
Observera att fälten **Application** och **AppVersion** inte kan ändras. Aspose.Slides skriver om dem vid varje sparning, så en sparad presentation alltid rapporterar "Aspose.Slides for PHP via Java" och versionen av biblioteket som skapade den. Alla värden som passerats till `setNameOfApplication` förkastas när presentationen skrivs.
{{% /alert %}} 

## **Hantera presentationsegenskaper**

Microsoft PowerPoint erbjuder en funktion för att lägga till vissa egenskaper i presentationsfilerna. Dessa dokumentegenskaper möjliggör lagring av viss användbar information tillsammans med dokumenten (presentationsfiler). Det finns två slags dokumentegenskaper enligt följande

- Systemdefinierade (Inbyggda) egenskaper
- Användardefinierade (Anpassade) egenskaper

**Inbyggda** egenskaper innehåller allmän information om dokumentet såsom dokumenttitel, författarens namn, dokumentstatistik med mera. **Anpassade** egenskaper är de som definieras av användarna som **Namn/Värde**-par, där både namn och värde definieras av användaren. Med Aspose.Slides for PHP via Java kan utvecklare komma åt och ändra värdena för både inbyggda och anpassade egenskaper.

## **Dokumentegenskaper i PowerPoint**

Microsoft PowerPoint 2007 tillåter hantering av dokumentegenskaperna i presentationsfilerna. Allt du behöver göra är att klicka på Office‑ikonen och sedan på menyalternativet **Prepare | Properties | Advanced Properties** i Microsoft PowerPoint 2007 som visas nedan:

|**Välja menyalternativet Advanced Properties**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |
När du väljer menyalternativet **Advanced Properties** visas en dialogruta som låter dig hantera dokumentegenskaperna för PowerPoint‑filen som visas nedan i figuren:

|**Egenskapsdialog**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |
I dialogrutan **Properties Dialog** ovan kan du se att det finns många flikar såsom **General**, **Summary**, **Statistics**, **Contents** och **Custom**. Alla dessa flikar möjliggör konfiguration av olika typer av information relaterad till PowerPoint‑filerna. Fliken **Custom** används för att hantera anpassade egenskaper för PowerPoint‑filerna.

Arbeta med dokumentegenskaper med Aspose.Slides for PHP via Java

Som vi beskrev tidigare stödjer Aspose.Slides for PHP via Java två typer av dokumentegenskaper, nämligen **Inbyggda** och **Anpassade** egenskaper. Således kan utvecklare komma åt båda typerna av egenskaper med hjälp av Aspose.Slides for PHP via Java API. Aspose.Slides for PHP via Java tillhandahåller klassen [DocumentProperties](https://reference.aspose.com/slides/sv/php-java/aspose.slides/documentproperties) som representerar dokumentegenskaperna associerade med en presentationsfil via egenskapen **Presentation.DocumentProperties**.

Utvecklare kan använda egenskapen **DocumentProperties** som exponeras av objektet [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation) för att komma åt dokumentegenskaperna i presentationsfilerna enligt beskrivningen nedan:

## **Läs offentliga egenskaper från en krypterad presentation**

Ett öppningslösenord skyddar normalt både presentationsinnehåll och dokumentegenskaper. När en presentation krypteras genom att skicka `false` till [ProtectionManager::setEncryptDocumentProperties](https://reference.aspose.com/slides/sv/php-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) , förblir dess dokumentegenskaper offentliga. En applikation kan då skicka `true` till [LoadOptions::setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/sv/php-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) och läsa den offentliga metadata utan att ange öppningslösenordet.

Alternativet document-properties-only styr vad Aspose.Slides laddar; det dekrypterar ingenting. Om egenskaperna ingick i krypteringen misslyckas laddningen utan lösenord. Om presentationen inte är krypterad ignoreras alternativet och hela presentationen laddas.

Följande exempel verifierar laddningsläget via [ProtectionManager::isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/sv/php-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) och läser sedan inbyggda egenskaper via [Presentation::getDocumentProperties](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/#getDocumentProperties) :

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;

$loadOptions = new LoadOptions();
$loadOptions->setOnlyLoadDocumentProperties(true);

$presentation = new Presentation("public-properties-encrypted.pptx", $loadOptions);
try {
    if (java_values($presentation->getProtectionManager()->isOnlyDocumentPropertiesLoaded())) {
        $properties = $presentation->getDocumentProperties();

        echo("Author: " . $properties->getAuthor() . "\n");
        echo("Title: " . $properties->getTitle() . "\n");
        echo("Keywords: " . $properties->getKeywords() . "\n");
    } else {
        echo("The presentation was not loaded in document-properties-only mode.\n");
    }
} finally {
    $presentation->dispose();
}
```

I detta läge laddas inte bildinnehåll. Bilder, masterbilder, layouter, former, media och andra presentationsobjekt är inte tillgängliga. Applikationer bör alltid kontrollera [ProtectionManager::isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/sv/php-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) innan de utför en operation som kräver hela presentationsobjektmodellen.

{{% alert color="warning" title="Warning" %}}
Offentlig metadata kan avslöja författarnamn, titlar, ämnen, nyckelord, företagsinformation, kommentarer och anpassade värden. Kryptera känsliga egenskaper tillsammans med presentationen. Låt dem vara offentliga endast när indexering, klassificering, sökning eller dokumenthanteringssystem har ett specifikt krav på att komma åt dem utan lösenord.
{{% /alert %}}

## **Uppdatera egenskaper i en krypterad presentation**

För en krypterad PPTX‑file är en presentation som laddas i document‑properties‑only‑läge avsedd för att läsa offentlig metadata. Aspose.Slides kan inte spara ändrade egenskaper från det metadata‑endast‑objektet eftersom de offentliga egenskaperna måste förbli konsistenta med motsvarande data i den krypterade presentationen. Därför kräver uppdateringen rätt öppningslösenord och en fullständig laddning.

Följande exempel öppnar presentationen med [LoadOptions::setPassword](https://reference.aspose.com/slides/sv/php-java/aspose.slides/loadoptions/#setPassword), uppdaterar offentliga inbyggda egenskaper och sparar resultatet. Det använder sedan [PresentationInfo::isEncrypted](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentationinfo/#isEncrypted) för att verifiera att krypteringen bevaras och öppnar den offentliga metadata utan lösenord för att verifiera de nya värdena:

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\PresentationFactory;
use aspose\slides\SaveFormat;

$inputPath = "public-properties-encrypted.pptx";
$outputPath = "updated-public-properties-encrypted.pptx";

$loadOptions = new LoadOptions();
$loadOptions->setPassword("open_password");

$presentation = new Presentation($inputPath, $loadOptions);
try {
    $presentation->getDocumentProperties()->setTitle("Updated Product Roadmap");
    $presentation->getDocumentProperties()->setKeywords("roadmap, planning, indexed");
    $presentation->save($outputPath, SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}

$presentationInfo = PresentationFactory::getInstance()->getPresentationInfo($outputPath);
echo("The presentation is encrypted: " . (java_values($presentationInfo->isEncrypted()) ? "true" : "false") . "\n");

$metadataLoadOptions = new LoadOptions();
$metadataLoadOptions->setOnlyLoadDocumentProperties(true);

$metadataPresentation = new Presentation($outputPath, $metadataLoadOptions);
try {
    if (java_values($metadataPresentation->getProtectionManager()->isOnlyDocumentPropertiesLoaded())) {
        echo("Title: " . $metadataPresentation->getDocumentProperties()->getTitle() . "\n");
        echo("Keywords: " . $metadataPresentation->getDocumentProperties()->getKeywords() . "\n");
    } else {
        echo("The presentation was not loaded in document-properties-only mode.\n");
    }
} finally {
    $metadataPresentation->dispose();
}
```

Om en applikation inte har behörighet att dekryptera eller ladda presentationsinnehållet måste den behandla offentliga egenskaper i en krypterad PPTX‑fil som skrivskyddade.

## **Åtkomst till inbyggda egenskaper**

Dessa egenskaper som exponeras av objektet [DocumentProperties](https://reference.aspose.com/slides/sv/php-java/aspose.slides/documentproperties) inkluderar: **Creator** (Författare), **Description**, **Keywords**, **Created** (Skapat datum), **Modified** (Ändringsdatum), **Printed** (Senaste utskriftsdatum), **LastModifiedBy**, **Keywords**, **SharedDoc** (Delas mellan olika producenter?), **PresentationFormat**, **Subject** och **Title**

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

## **Modifiera inbyggda egenskaper**

Att modifiera de inbyggda egenskaperna för presentationsfiler är lika enkelt som att komma åt dem. Du kan helt enkelt tilldela ett strängvärde till någon önskad egenskap så ändras egenskapsvärdet. I exemplet nedan har vi demonstrerat hur vi kan modifiera de inbyggda dokumentegenskaperna för presentationsfilen med Aspose.Slides for PHP via Java.

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    # Skapa en referens till IDocumentProperties-objektet som är associerat med Presentation
    $dp = $pres->getDocumentProperties();
    # Sätt de inbyggda egenskaperna
    $dp->setAuthor("Aspose.Slides for PHP via Java");
    $dp->setTitle("Modifying Presentation Properties");
    $dp->setSubject("Aspose Subject");
    $dp->setComments("Aspose Description");
    $dp->setManager("Aspose Manager");
    # Spara presentationen till en fil
    $pres->save("DocProps.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Detta exempel modifierar de inbyggda egenskaperna för presentationen som kan ses nedan:

|**Inbyggda dokumentegenskaper efter modifiering**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **Lägg till anpassade dokumentegenskaper**

Aspose.Slides for PHP via Java låter också utvecklare lägga till anpassade värden för presentationsdokumentegenskaper. Ett exempel visas nedan som visar hur man sätter de anpassade egenskaperna för en presentation.

```php
  $pres = new Presentation();
  try {
    # Hämtar dokumentegenskaper
    $dProps = $pres->getDocumentProperties();
    # Lägger till anpassade egenskaper
    $dProps->set_Item("New Custom", 12);
    $dProps->set_Item("My Name", "Mudassir");
    $dProps->set_Item("Custom", 124);
    # Hämtar egenskapsnamn på specifikt index
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

## **Åtkomst till och modifiera anpassade egenskaper**

Aspose.Slides for PHP via Java låter också utvecklare komma åt värdena för anpassade egenskaper. Ett exempel visas nedan som visar hur du kan åtkomma och modifiera alla dessa anpassade egenskaper för en presentation.

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    # Skapa en referens till DocumentProperties-objektet som är associerat med Presentation
    $dp = $pres->getDocumentProperties();
    # Åtkomst och ändring av anpassade egenskaper
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

Detta exempel modifierar de anpassade egenskaperna för [PPTX ](https://docs.fileformat.com/presentation/pptx/)presentationen. Följande figurer visar presentationens anpassade egenskaper före och efter modifiering:

|**Anpassade egenskaper före modifiering**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**Anpassade egenskaper efter modifiering**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **Avancerade dokumentegenskaper**

{{% alert color="info" title="Note" %}}
Nya metoder [readDocumentProperties](https://reference.aspose.com/slides/sv/php-java/aspose.slides/PresentationInfo/#readDocumentProperties), [updateDocumentProperties](https://reference.aspose.com/slides/sv/php-java/aspose.slides/PresentationInfo/#updateDocumentProperties), och [writeBindedPresentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/PresentationInfo/#writeBindedPresentation) har lagts till i [PresentationInfo](https://reference.aspose.com/slides/sv/php-java/aspose.slides/PresentationInfo), logiken för egenskapsättaren [DocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/sv/php-java/aspose.slides/documentproperties/#setLastSavedTime) har ändrats.
{{% /alert %}} 

De två nya metoderna [readDocumentProperties](https://reference.aspose.com/slides/sv/php-java/aspose.slides/PresentationInfo/#readDocumentProperties) och [updateDocumentProperties](https://reference.aspose.com/slides/sv/php-java/aspose.slides/PresentationInfo/#updateDocumentProperties) har lagts till i klassen [PresentationInfo](https://reference.aspose.com/slides/sv/php-java/aspose.slides/PresentationInfo). De ger snabb åtkomst till dokumentegenskaper och möjliggör att ändra och uppdatera egenskaper utan att ladda en hel presentation.

Det typiska scenariot att ladda egenskaperna, ändra ett värde och uppdatera dokumentet kan implementeras på följande sätt:

```php
  # läsa informationen om presentationen
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

Det finns ett annat sätt att använda egenskaper från en viss presentation som mall för att uppdatera egenskaper i andra presentationer:

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

## **Ställ in korrekturläsningsspråk**

Aspose.Slides tillhandahåller egenskapen LanguageId (exponerad av klassen PortionFormat) för att låta dig ange korrekturläsningsspråket för ett PowerPoint‑dokument. Korrekturläsningsspråket är det språk för vilket stavning och grammatik i PowerPoint kontrolleras.

Denna PHP‑kod visar hur du ställer in korrekturläsningsspråket för ett PowerPoint: xxx Varför saknas LanguageId i Java‑klassen PortionFormat?

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
    $portionFormat->setLanguageId("zh-CN");// ange id för ett korrekturläsningsspråk

    $newPortion->setText("1。");
    $paragraph->getPortions()->add($newPortion);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Ställ in standardspråk**

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

Prova den [**Aspose.Slides Metadata**](https://products.aspose.app/slides/sv/metadata) online‑appen för att se hur du arbetar med dokumentegenskaper via Aspose.Slides API:

[![Visa & redigera PowerPoint‑metadata](slides-metadata.png)](https://products.aspose.app/slides/sv/metadata)

## **FAQ**

**Hur kan jag ta bort en inbyggd egenskap från en presentation?**

Inbyggda egenskaper är en integrerad del av presentationen och kan inte tas bort helt. Du kan dock ändra deras värden eller sätta dem till tomt om den specifika egenskapen tillåter det.

**Vad händer om jag lägger till en anpassad egenskap som redan finns?**

Om du lägger till en anpassad egenskap som redan finns, kommer dess befintliga värde att skrivas över med det nya. Du behöver inte ta bort eller kontrollera egenskapen i förväg, eftersom Aspose.Slides automatiskt uppdaterar egenskapens värde.

**Kan jag komma åt presentationsegenskaper utan att ladda hela presentationen?**

Ja. Använd [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentationfactory/) och sedan [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentationinfo/#readDocumentProperties) för att läsa lagrad dokumentmetadata utan att skapa en [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/)‑instans. Se [Build a Lightweight Presentation Inventory](/slides/sv/php-java/examine-presentation/) för ett komplett rapportexempel och format‑specifika begränsningar.

**Kan jag läsa offentliga egenskaper i en krypterad presentation utan dess öppningslösenord?**

Ja. Dokument‑egenskap‑kryptering måste ha inaktiverats innan presentationen krypterades, och presentationen måste laddas i document‑properties‑only‑läge.

**Kan jag uppdatera en krypterad PPTX‑fil i document‑properties‑only‑läge?**

Nej. Offentliga och krypterade egenskapsdata måste förbli konsistenta, så att uppdatera en krypterad PPTX‑fil kräver att hela presentationen laddas med rätt öppningslösenord.
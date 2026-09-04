---
title: Beheer presentatie‑eigenschappen in PHP
linktitle: Presentatie‑eigenschappen
type: docs
weight: 70
url: /nl/php-java/presentation-properties/
keywords:
- PowerPoint‑eigenschappen
- presentatie‑eigenschappen
- documenteigenschappen
- ingebouwde eigenschappen
- aangepaste eigenschappen
- geavanceerde eigenschappen
- eigenschappen beheren
- eigenschappen wijzigen
- documentmetadata
- metadata bewerken
- controletaal
- standaardtaal
- PowerPoint
- OpenDocument
- presentatie
- PHP
- Aspose.Slides
description: "Beheer de presentatie‑eigenschappen in Aspose.Slides for PHP via Java en stroomlijn zoeken, branding en workflow in uw PowerPoint‑ en OpenDocument‑bestanden."
---
## **Inleiding**

Aspose.Slides ondersteunt twee soorten documenteigenschappen: **Ingebouwd** en **Aangepast**. Beide soorten eigenschappen kunnen eenvoudig worden benaderd en beheerd via de Aspose.Slides‑API.

Aspose.Slides stelt u in staat om met presentatiedocumenteigenschappen te werken via de [DocumentProperties](https://reference.aspose.com/slides/nl/php-java/aspose.slides/documentproperties/)‑klasse. Een exemplaar van deze klasse wordt geretourneerd door de [Presentation::getDocumentProperties](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/#getDocumentProperties)‑methode. De volgende voorbeelden tonen hoe u deze eigenschappen kunt lezen, wijzigen en beheren.

{{% alert color="info" title="Note" %}}

Houd er rekening mee dat de velden **Application** en **AppVersion** niet kunnen worden gewijzigd. Aspose.Slides herschrijft ze bij elke opslag, zodat een opgeslagen presentatie altijd “Aspose.Slides for PHP via Java” en de versie van de bibliotheek die het heeft gegenereerd, rapporteert. Elke waarde die wordt doorgegeven aan `setNameOfApplication` wordt genegeerd wanneer de presentatie wordt weggeschreven.

{{% /alert %}} 

## **Eigenschappen van de presentatie beheren**

Microsoft PowerPoint biedt een functie om enkele eigenschappen aan presentatie‑bestanden toe te voegen. Deze documenteigenschappen stellen u in staat nuttige informatie op te slaan samen met de documenten (presentatie‑bestanden). Er zijn twee soorten documenteigenschappen:

- Systeem‑gedefinieerde (Ingebouwde) eigenschappen
- Door de gebruiker gedefinieerde (Aangepaste) eigenschappen

**Ingebouwde** eigenschappen bevatten algemene informatie over het document, zoals de titel, de naam van de auteur, statistieken enzovoort. **Aangepaste** eigenschappen zijn door de gebruiker gedefinieerde **Naam/Waarde**‑paren, waarbij zowel naam als waarde door de gebruiker worden opgegeven. Met Aspose.Slides for PHP via Java kunnen ontwikkelaars zowel ingebouwde als aangepaste eigenschappen lezen en wijzigen.

## **Documenteigenschappen in PowerPoint**

Microsoft PowerPoint 2007 maakt het beheren van documenteigenschappen van presentaties mogelijk. Alles wat u hoeft te doen is op het Office‑pictogram klikken en vervolgens **Prepare | Properties | Advanced Properties** selecteren, zoals hieronder wordt weergegeven:

|**Advanced Properties‑menu‑item selecteren**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |
Na het kiezen van **Advanced Properties** verschijnt een dialoogvenster waarmee u de documenteigenschappen van het PowerPoint‑bestand kunt beheren, zoals in de onderstaande figuur te zien is:

|**Eigenschappen‑dialoog**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |
In het bovenstaande **Eigenschappen‑dialoog** ziet u verschillende tabbladen, zoals **Algemeen**, **Samenvatting**, **Statistieken**, **Inhoud** en **Aangepast**. Al deze tabbladen maken het mogelijk verschillende soorten informatie over de PowerPoint‑bestanden te configureren. Het tabblad **Aangepast** wordt gebruikt om de aangepaste eigenschappen van de PowerPoint‑bestanden te beheren.

## **Werken met documenteigenschappen met Aspose.Slides for PHP via Java**

Zoals eerder beschreven ondersteunt Aspose.Slides for PHP via Java twee soorten documenteigenschappen: **Ingebouwde** en **Aangepaste**. Ontwikkelaars kunnen beide soorten eigenschappen benaderen via de Aspose.Slides for PHP via Java‑API. Aspose.Slides for PHP via Java biedt de [DocumentProperties](https://reference.aspose.com/slides/nl/php-java/aspose.slides/documentproperties)‑klasse die de documenteigenschappen van een presentatie‑bestand representeert via de **Presentation.DocumentProperties**‑eigenschap.

Ontwikkelaars kunnen de **DocumentProperties**‑eigenschap die wordt blootgesteld door het [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation)‑object gebruiken om de documenteigenschappen van presentaties te benaderen, zoals hieronder wordt beschreven:

## **Ingebouwde eigenschappen lezen van een versleutelde presentatie**

Een openings‑wachtwoord beschermt normaal zowel de inhoud van de presentatie als de documenteigenschappen. Wanneer een presentatie wordt versleuteld door `false` te gebruiken bij [ProtectionManager::setEncryptDocumentProperties](https://reference.aspose.com/slides/nl/php-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties), blijven de documenteigenschappen openbaar. Een toepassing kan vervolgens `true` doorgeven aan [LoadOptions::setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/nl/php-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) en de openbare metadata lezen zonder het openings‑wachtwoord op te geven.

De optie “document‑properties‑only” bepaalt wat Aspose.Slides laadt; er wordt niets gedecrypt. Als de eigenschappen wel deel uitmaken van de encryptie, mislukt het laden zonder wachtwoord. Als de presentatie niet versleuteld is, wordt de optie genegeerd en wordt de volledige presentatie geladen.

Het volgende voorbeeld controleert de laadmodus via [ProtectionManager::isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/nl/php-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) en leest vervolgens de ingebouwde eigenschappen via [Presentation::getDocumentProperties](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/#getDocumentProperties):

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

In deze modus worden de dia‑inhoud en gerelateerde objecten (dia’s, masters, lay‑outs, vormen, media, enz.) niet geladen. Toepassingen moeten altijd [ProtectionManager::isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/nl/php-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) controleren voordat ze een bewerking uitvoeren die het volledige objectmodel van de presentatie vereist.

{{% alert color="warning" title="Warning" %}}
Openbare metadata kunnen namen van auteurs, titels, onderwerpen, trefwoorden, bedrijfsinformatie, opmerkingen en aangepaste waarden blootleggen. Versleutel gevoelige eigenschappen samen met de presentatie. Laat ze alleen openbaar wanneer indexeer‑, classificatie‑, zoek‑ of document‑beheersystemen specifiek toegang zonder wachtwoord nodig hebben.
{{% /alert %}}

## **Eigenschappen bijwerken van een versleutelde presentatie**

Voor een versleuteld PPTX‑bestand is een presentatie die in “document‑properties‑only”‑modus is geladen, bedoeld om openbare metadata te lezen. Aspose.Slides kan gewijzigde eigenschappen van dat metadata‑enkel‑object niet opslaan, omdat de openbare eigenschappen consistent moeten blijven met de corresponderende gegevens in de versleutelde presentatie. Bijwerken vereist daarom het juiste openings‑wachtwoord en een volledige laadbewerking.

Het volgende voorbeeld opent de presentatie met [LoadOptions::setPassword](https://reference.aspose.com/slides/nl/php-java/aspose.slides/loadoptions/#setPassword), werkt openbare ingebouwde eigenschappen bij en slaat het resultaat op. Vervolgens wordt met [PresentationInfo::isEncrypted](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentationinfo/#isEncrypted) gecontroleerd of de encryptie behouden blijft en wordt de openbare metadata opnieuw geladen zonder wachtwoord om de nieuwe waarden te verifiëren:

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

Als een toepassing niet is toegestaan de presentatie‑inhoud te decrypten of te laden, moet zij de openbare eigenschappen van een versleuteld PPTX‑bestand als alleen‑lezen behandelen.

## **Ingebouwde eigenschappen benaderen**

De eigenschappen die door het [DocumentProperties](https://reference.aspose.com/slides/nl/php-java/aspose.slides/documentproperties)‑object worden blootgesteld, omvatten: **Creator** (Auteur), **Description**, **Keywords**, **Created** (Aanmaakdatum), **Modified** (Wijzigingsdatum), **Printed** (Datum van laatste afdruk), **LastModifiedBy**, **SharedDoc** (Wordt gedeeld tussen verschillende makers?), **PresentationFormat**, **Subject** en **Title**.

```php
  # Instantieer de Presentation-klasse die de presentatie representeert
  $pres = new Presentation("Presentation.pptx");
  try {
    # Maak een referentie naar het IDocumentProperties-object dat aan de Presentation is gekoppeld
    $dp = $pres->getDocumentProperties();
    # Toon de ingebouwde eigenschappen
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

## **Ingebouwde eigenschappen wijzigen**

Het wijzigen van de ingebouwde eigenschappen van presentaties is net zo eenvoudig als ze benaderen. U kunt eenvoudig een tekenreeks aan een gewenste eigenschap toewijzen en de eigenschapswaarde wordt aangepast. In het onderstaande voorbeeld laten we zien hoe we de ingebouwde documenteigenschappen van een presentatie kunnen wijzigen met Aspose.Slides for PHP via Java.

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    # Maak een referentie naar het IDocumentProperties-object dat aan de Presentation is gekoppeld
    $dp = $pres->getDocumentProperties();
    # Stel de ingebouwde eigenschappen in
    $dp->setAuthor("Aspose.Slides for PHP via Java");
    $dp->setTitle("Modifying Presentation Properties");
    $dp->setSubject("Aspose Subject");
    $dp->setComments("Aspose Description");
    $dp->setManager("Aspose Manager");
    # Sla uw presentatie op naar een bestand
    $pres->save("DocProps.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Dit voorbeeld wijzigt de ingebouwde eigenschappen van de presentatie, zoals hieronder te zien is:

|**Ingebouwde documenteigenschappen na wijziging**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **Aangepaste documenteigenschappen toevoegen**

Aspose.Slides for PHP via Java stelt ontwikkelaars ook in staat aangepaste waarden toe te voegen aan de documenteigenschappen van een presentatie. Het onderstaande voorbeeld toont hoe u aangepaste eigenschappen voor een presentatie kunt instellen.

```php
  $pres = new Presentation();
  try {
    # Documenteigenschappen ophalen
    $dProps = $pres->getDocumentProperties();
    # Aangepaste eigenschappen toevoegen
    $dProps->set_Item("New Custom", 12);
    $dProps->set_Item("My Name", "Mudassir");
    $dProps->set_Item("Custom", 124);
    # Eigenschapnaam ophalen op een specifieke index
    $getPropertyName = $dProps->getCustomPropertyName(2);
    # Geselecteerde eigenschap verwijderen
    $dProps->removeCustomProperty($getPropertyName);
    # Presentatie opslaan
    $pres->save("CustomDemo.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

|**Aangepaste documenteigenschappen toegevoegd**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **Aangepaste eigenschappen benaderen en wijzigen**

Aspose.Slides for PHP via Java maakt het ook mogelijk om de waarden van aangepaste eigenschappen te benaderen. Het onderstaande voorbeeld laat zien hoe u alle aangepaste eigenschappen van een presentatie kunt benaderen en wijzigen.

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    # Maak een referentie naar het DocumentProperties-object dat aan de Presentation is gekoppeld
    $dp = $pres->getDocumentProperties();
    # Toegang tot en wijzigen van aangepaste eigenschappen
    for($i = 0; $i < java_values($dp->getCountOfCustomProperties()) ; $i++) {
      # Namen en waarden van aangepaste eigenschappen weergeven
      echo("Custom Property Name : " . $dp->getCustomPropertyName($i));
      echo("Custom Property Value : " . $dp->get_Item($dp->getCustomPropertyName($i)));
      # Waarden van aangepaste eigenschappen wijzigen
      $dp->set_Item($dp->getCustomPropertyName($i), "New Value " . $i + 1);
    }
    # Sla uw presentatie op naar een bestand
    $pres->save("CustomDemoModified.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Dit voorbeeld wijzigt de aangepaste eigenschappen van de [PPTX](https://docs.fileformat.com/presentation/pptx/)‑presentatie. De volgende afbeeldingen tonen de aangepaste eigenschappen vóór en na wijziging:

|**Aangepaste eigenschappen vóór wijziging**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**Aangepaste eigenschappen na wijziging**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **Geavanceerde documenteigenschappen**

{{% alert color="info" title="Note" %}}

Nieuwe methoden [readDocumentProperties](https://reference.aspose.com/slides/nl/php-java/aspose.slides/PresentationInfo/#readDocumentProperties), [updateDocumentProperties](https://reference.aspose.com/slides/nl/php-java/aspose.slides/PresentationInfo/#updateDocumentProperties) en [writeBindedPresentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/PresentationInfo/#writeBindedPresentation) zijn toegevoegd aan [PresentationInfo](https://reference.aspose.com/slides/nl/php-java/aspose.slides/PresentationInfo); de logica van de setter voor de eigenschap [DocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/nl/php-java/aspose.slides/documentproperties/#setLastSavedTime) is gewijzigd.

{{% /alert %}} 

De twee nieuwe methoden [readDocumentProperties](https://reference.aspose.com/slides/nl/php-java/aspose.slides/PresentationInfo/#readDocumentProperties) en [updateDocumentProperties](https://reference.aspose.com/slides/nl/php-java/aspose.slides/PresentationInfo/#updateDocumentProperties) zijn toegevoegd aan de klasse [PresentationInfo](https://reference.aspose.com/slides/nl/php-java/aspose.slides/PresentationInfo). Ze bieden snelle toegang tot documenteigenschappen en maken het mogelijk om eigenschappen te wijzigen en bij te werken zonder de volledige presentatie te laden.

Het typische scenario – eigenschappen laden, een waarde wijzigen en het document bijwerken – kan op de volgende manier worden geïmplementeerd:

```php
  # lees de informatie van de presentatie
  $info = PresentationFactory->getInstance()->getPresentationInfo("presentation.pptx");
  # verkrijg de huidige eigenschappen
  $props = $info->readDocumentProperties();
  # stel de nieuwe waarden van de Auteur- en Titelvelden in
  $props->setAuthor("New Author");
  $props->setTitle("New Title");
  # werk de presentatie bij met nieuwe waarden
  $info->updateDocumentProperties($props);
  $info->writeBindedPresentation("presentation.pptx");
```

Er is een alternatieve manier om de eigenschappen van een specifieke presentatie als sjabloon te gebruiken om eigenschappen in andere presentaties bij te werken:

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

Een nieuw sjabloon kan vanaf nul worden gecreëerd en daarna worden gebruikt om meerdere presentaties bij te werken:

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

## **Controletaal instellen**

Aspose.Slides biedt de eigenschap LanguageId (benaderd via de klasse PortionFormat) waarmee u de controletaal voor een PowerPoint‑document kunt instellen. De controletaal is de taal waarvoor spelling en grammatica in PowerPoint worden gecontroleerd.

Deze PHP‑code laat zien hoe u de controletaal voor een PowerPoint‑document kunt instellen: xxx Waarom ontbreekt LanguageId in de Java‑klasse PortionFormat?

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
    $portionFormat->setLanguageId("zh-CN");// stel de ID van een controletaal in

    $newPortion->setText("1。");
    $paragraph->getPortions()->add($newPortion);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Standaardtaal instellen**

Deze PHP‑code laat zien hoe u de standaardtaal voor een volledige PowerPoint‑presentatie kunt instellen:

```php
  $loadOptions = new LoadOptions();
  $loadOptions->setDefaultTextLanguage("en-US");
  $pres = new Presentation($loadOptions);
  try {
    # Voeg een nieuw rechthoekvorm toe met tekst
    $shp = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 50);
    $shp->getTextFrame()->setText("New Text");
    # Controleert de taal van de eerste portion
    echo($shp->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->getLanguageId());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Live‑voorbeeld**

Probeer de online‑applicatie [**Aspose.Slides Metadata**](https://products.aspose.app/slides/nl/metadata) om te zien hoe u met documenteigenschappen werkt via de Aspose.Slides‑API:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/nl/metadata)

## **FAQ**

**Hoe kan ik een ingebouwde eigenschap uit een presentatie verwijderen?**

Ingebouwde eigenschappen maken een integraal onderdeel van de presentatie uit en kunnen niet volledig worden verwijderd. U kunt echter hun waarden wijzigen of, indien toegestaan door de specifieke eigenschap, ze leeg maken.

**Wat gebeurt er als ik een aangepaste eigenschap toevoeg die al bestaat?**

Als u een aangepaste eigenschap toevoegt die al bestaat, wordt de bestaande waarde overschreven door de nieuwe. U hoeft de eigenschap niet vooraf te verwijderen of te controleren; Aspose.Slides werkt de waarde automatisch bij.

**Kan ik presentatieweigenschappen benaderen zonder de volledige presentatie te laden?**

Ja. Gebruik [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentationfactory/) en daarna [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentationinfo/#readDocumentProperties) om de opgeslagen documentmetadata te lezen zonder een [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/)‑instantie te maken. Zie [Build a Lightweight Presentation Inventory](/slides/nl/php-java/examine-presentation/) voor een volledig voorbeeld en format‑specifieke beperkingen.

**Kan ik openbare eigenschappen van een versleutelde presentatie lezen zonder het openings‑wachtwoord?**

Ja. Versleuteling van documenteigenschappen moet zijn uitgeschakeld voordat de presentatie werd versleuteld, en de presentatie moet worden geladen in “document‑properties‑only”‑modus.

**Kan ik een versleuteld PPTX‑bestand bijwerken in “document‑properties‑only”‑modus?**

Nee. Publieke en versleutelde eigenschapsgegevens moeten consistent blijven, dus het bijwerken van een versleuteld PPTX‑bestand vereist het volledig laden van de presentatie met het juiste openings‑wachtwoord.
---
title: Beheer presentatie-eigenschappen in PHP
linktitle: Presentatie-eigenschappen
type: docs
weight: 70
url: /nl/php-java/presentation-properties/
keywords:
- PowerPoint-eigenschappen
- presentatie-eigenschappen
- document-eigenschappen
- ingebouwde eigenschappen
- aangepaste eigenschappen
- geavanceerde eigenschappen
- eigenschappen beheren
- eigenschappen wijzigen
- document-metadata
- metadata bewerken
- spellingscontrole-taal
- standaardtaal
- PowerPoint
- OpenDocument
- presentatie
- PHP
- Aspose.Slides
description: "Beheer presentaties-eigenschappen in Aspose.Slides for PHP via Java en stroomlijn zoeken, branding en workflow in uw PowerPoint- en OpenDocument-bestanden."
---
## **Inleiding**

Aspose.Slides ondersteunt twee typen documenteigenschappen: **Ingebouwd** en **Aangepast**. Beide typen eigenschappen kunnen eenvoudig worden benaderd en beheerd via de Aspose.Slides‑API.

Aspose.Slides stelt u in staat te werken met presentatiedocumenteigenschappen via de [DocumentProperties](https://reference.aspose.com/slides/nl/php-java/aspose.slides/documentproperties/)‑klasse. Een instantie van deze klasse wordt geretourneerd door de [Presentation::getDocumentProperties](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/#getDocumentProperties)‑methode. De volgende voorbeelden laten zien hoe u deze eigenschappen kunt lezen, wijzigen en beheren.

{{% alert color="info" title="Note" %}}

Please note that the **Application** and **AppVersion** fields cannot be modified. Aspose.Slides rewrites them on every save, so a saved presentation always reports "Aspose.Slides for PHP via Java" and the version of the library that produced it. Any value passed to `setNameOfApplication` is discarded when the presentation is written.

{{% /alert %}} 

## **Eigenschappen van de presentatie beheren**

Microsoft PowerPoint biedt een functie om enkele eigenschappen aan presentatie‑bestanden toe te voegen. Deze documenteigenschappen maken het mogelijk om nuttige informatie samen met de documenten (presentatie‑bestanden) op te slaan. Er zijn twee soorten documenteigenschappen:

- System Defined (Built-in) Properties
- User-Defined (Custom) Properties

**Ingebouwde** eigenschappen bevatten algemene informatie over het document, zoals de titel, de naam van de auteur, statistieken enzovoort. **Aangepaste** eigenschappen zijn door de gebruiker gedefinieerde **Naam/Waarde**‑paren, waarbij zowel naam als waarde door de gebruiker worden bepaald. Met Aspose.Slides for PHP via Java kunnen ontwikkelaars de waarden van zowel ingebouwde als aangepaste eigenschappen benaderen en wijzigen.

## **Documenteigenschappen in PowerPoint**

Microsoft PowerPoint 2007 maakt het mogelijk om de documenteigenschappen van presentatie‑bestanden te beheren. Alles wat u hoeft te doen is op het Office‑icoon klikken en vervolgens **Prepare | Properties | Advanced Properties** selecteren, zoals hieronder weergegeven:

|**Advanced Properties‑menu-item selecteren**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |
Na het selecteren van het **Advanced Properties**‑menu‑item verschijnt een dialoogvenster waarmee u de documenteigenschappen van het PowerPoint‑bestand kunt beheren, zoals in de onderstaande afbeelding:

|**Eigenschappen‑dialoog**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |
In het bovenstaande **Eigenschappen‑dialoog** ziet u verschillende tabbladen zoals **General**, **Summary**, **Statistics**, **Contents** en **Custom**. Al deze tabbladen stellen u in staat verschillende soorten informatie over de PowerPoint‑bestanden te configureren. Het **Custom**‑tabblad wordt gebruikt om de aangepaste eigenschappen van de PowerPoint‑bestanden te beheren.

## **Werken met documenteigenschappen via Aspose.Slides for PHP via Java**

Zoals eerder beschreven ondersteunt Aspose.Slides for PHP via Java twee soorten documenteigenschappen: **Ingebouwd** en **Aangepast**. Ontwikkelaars kunnen beide typen eigenschappen benaderen met behulp van de Aspose.Slides for PHP via Java‑API. Aspose.Slides for PHP via Java biedt de klasse [DocumentProperties](https://reference.aspose.com/slides/nl/php-java/aspose.slides/documentproperties) die de documenteigenschappen van een presentatie‑bestand vertegenwoordigt via de eigenschap **Presentation.DocumentProperties**.

Ontwikkelaars kunnen de eigenschap **DocumentProperties**, blootgesteld door het [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation)‑object, gebruiken om de documenteigenschappen van presentaties te benaderen, zoals hieronder beschreven:

## **Ingebouwde eigenschappen benaderen**

Deze eigenschappen die worden blootgesteld door het [DocumentProperties](https://reference.aspose.com/slides/nl/php-java/aspose.slides/documentproperties)‑object omvatten: **Creator** (Auteur), **Description**, **Keywords**, **Created** (Aanmaakdatum), **Modified** (Wijzigingsdatum), **Printed** (Datum van laatste afdruk), **LastModifiedBy**, **Keywords**, **SharedDoc** (Is het gedeeld tussen verschillende producenten?), **PresentationFormat**, **Subject** en **Title**.

```php
  # Maak een instantie van de Presentation-klasse die de presentatie vertegenwoordigt
  $pres = new Presentation("Presentation.pptx");
  try {
    # Maak een referentie naar het IDocumentProperties-object dat aan de presentatie gekoppeld is
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

Het wijzigen van de ingebouwde eigenschappen van presentaties is net zo eenvoudig als ze te benaderen. U kunt simpelweg een tekenreeks toewijzen aan een gewenste eigenschap en de eigenschapswaarde wordt aangepast. In het onderstaande voorbeeld laten we zien hoe we de ingebouwde documenteigenschappen van een presentatie‑bestand kunnen wijzigen met Aspose.Slides for PHP via Java.

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    # Maak een referentie naar het IDocumentProperties-object dat aan de presentatie is gekoppeld
    $dp = $pres->getDocumentProperties();
    # Stel de ingebouwde eigenschappen in
    $dp->setAuthor("Aspose.Slides for PHP via Java");
    $dp->setTitle("Modifying Presentation Properties");
    $dp->setSubject("Aspose Subject");
    $dp->setComments("Aspose Description");
    $dp->setManager("Aspose Manager");
    # Sla uw presentatie op in een bestand
    $pres->save("DocProps.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Dit voorbeeld wijzigt de ingebouwde eigenschappen van de presentatie, zoals hieronder weergegeven:

|**Ingebouwde documenteigenschappen na wijziging**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **Aangepaste documenteigenschappen toevoegen**

Aspose.Slides for PHP via Java stelt ontwikkelaars ook in staat om aangepaste waarden toe te voegen aan de documenteigenschappen van een presentatie. Het onderstaande voorbeeld toont hoe u aangepaste eigenschappen voor een presentatie kunt instellen.

```php
  $pres = new Presentation();
  try {
    # Documenteigenschappen ophalen
    $dProps = $pres->getDocumentProperties();
    # Aangepaste eigenschappen toevoegen
    $dProps->set_Item("New Custom", 12);
    $dProps->set_Item("My Name", "Mudassir");
    $dProps->set_Item("Custom", 124);
    # Eigenschapsnaam ophalen op een bepaalde index
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

Aspose.Slides for PHP via Java maakt het ook mogelijk om de waarden van aangepaste eigenschappen te benaderen. Het voorbeeld hieronder laat zien hoe u alle aangepaste eigenschappen van een presentatie kunt benaderen en wijzigen.

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    # Maak een referentie naar het DocumentProperties-object dat aan de presentatie is gekoppeld
    $dp = $pres->getDocumentProperties();
    # Toegang tot en wijziging van aangepaste eigenschappen
    for($i = 0; $i < java_values($dp->getCountOfCustomProperties()) ; $i++) {
      # Toon namen en waarden van aangepaste eigenschappen
      echo("Custom Property Name : " . $dp->getCustomPropertyName($i));
      echo("Custom Property Value : " . $dp->get_Item($dp->getCustomPropertyName($i)));
      # Wijzig waarden van aangepaste eigenschappen
      $dp->set_Item($dp->getCustomPropertyName($i), "New Value " . $i + 1);
    }
    # Sla uw presentatie op in een bestand
    $pres->save("CustomDemoModified.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Dit voorbeeld wijzigt de aangepaste eigenschappen van de [PPTX ](https://docs.fileformat.com/presentation/pptx/)presentatie. De volgende afbeeldingen tonen de aangepaste eigenschappen van de presentatie vóór en ná de wijziging:

|**Aangepaste eigenschappen vóór wijziging**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |


|**Aangepaste eigenschappen na wijziging**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **Geavanceerde documenteigenschappen**

{{% alert color="info" title="Note" %}}

New methods [readDocumentProperties](https://reference.aspose.com/slides/nl/php-java/aspose.slides/PresentationInfo/#readDocumentProperties), [updateDocumentProperties](https://reference.aspose.com/slides/nl/php-java/aspose.slides/PresentationInfo/#updateDocumentProperties), and [writeBindedPresentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/PresentationInfo/#writeBindedPresentation) have been added to [PresentationInfo](https://reference.aspose.com/slides/nl/php-java/aspose.slides/PresentationInfo), logic of the [DocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/nl/php-java/aspose.slides/documentproperties/#setLastSavedTime) property setter has been changed.

{{% /alert %}} 

De twee nieuwe methoden [readDocumentProperties](https://reference.aspose.com/slides/nl/php-java/aspose.slides/PresentationInfo/#readDocumentProperties) en [updateDocumentProperties](https://reference.aspose.com/slides/nl/php-java/aspose.slides/PresentationInfo/#updateDocumentProperties) zijn toegevoegd aan de klasse [PresentationInfo](https://reference.aspose.com/slides/nl/php-java/aspose.slides/PresentationInfo). Ze bieden snelle toegang tot documenteigenschappen en maken het mogelijk eigenschappen te wijzigen zonder de volledige presentatie te laden.

Het typische scenario – eigenschappen laden, een waarde wijzigen en het document bijwerken – kan op de volgende manier worden geïmplementeerd:

```php
  # lees de informatie van de presentatie
  $info = PresentationFactory->getInstance()->getPresentationInfo("presentation.pptx");
  # verkrijg de huidige eigenschappen
  $props = $info->readDocumentProperties();
  # stel de nieuwe waarden van de velden Auteur en Titel in
  $props->setAuthor("New Author");
  $props->setTitle("New Title");
  # werk de presentatie bij met nieuwe waarden
  $info->updateDocumentProperties($props);
  $info->writeBindedPresentation("presentation.pptx");
```

Een andere manier is om de eigenschappen van een specifieke presentatie als sjabloon te gebruiken om eigenschappen in andere presentaties bij te werken:

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

Een nieuw sjabloon kan vanaf nul worden aangemaakt en vervolgens worden gebruikt om meerdere presentaties bij te werken:

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

## **Spellingscontrole‑taal instellen**

Aspose.Slides biedt de eigenschap LanguageId (beschikbaar via de klasse PortionFormat) om de spellingscontrole‑taal voor een PowerPoint‑document in te stellen. De spellingscontrole‑taal is de taal waarvoor spelling en grammatica in PowerPoint worden gecontroleerd.

Deze PHP‑code laat zien hoe u de spellingscontrole‑taal voor een PowerPoint‑document instelt: xxx Why is LanguageId missing from Java PortionFormat class?

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
    $portionFormat->setLanguageId("zh-CN"); // stel het ID in van een spellingscontrole-taal

    $newPortion->setText("1。");
    $paragraph->getPortions()->add($newPortion);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Standaardtaal instellen**

Deze PHP‑code laat zien hoe u de standaardtaal voor een volledige PowerPoint‑presentatie instelt:

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

Probeer de online app [**Aspose.Slides Metadata**](https://products.aspose.app/slides/nl/metadata) om te zien hoe u met documenteigenschappen werkt via de Aspose.Slides‑API:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/nl/metadata)

## **FAQ**

**Hoe kan ik een ingebouwde eigenschap uit een presentatie verwijderen?**

Ingebouwde eigenschappen maken een integraal onderdeel van de presentatie uit en kunnen niet volledig worden verwijderd. U kunt echter hun waarden wijzigen of, indien toegestaan, leegmaken.

**Wat gebeurt er als ik een aangepaste eigenschap toevoeg die al bestaat?**

Als u een aangepaste eigenschap toevoegt die al bestaat, wordt de bestaande waarde overschreven door de nieuwe. Het is niet nodig de eigenschap vooraf te verwijderen of te controleren; Aspose.Slides werkt de waarde automatisch bij.

**Kan ik presentatie‑eigenschappen benaderen zonder de volledige presentatie te laden?**

Ja. Gebruik [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentationfactory/) en vervolgens [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentationinfo/#readDocumentProperties) om opgeslagen documentmetadata te lezen zonder een [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/)‑instance aan te maken. Zie [Build a Lightweight Presentation Inventory](/slides/nl/php-java/examine-presentation/) voor een volledig rapportage‑voorbeeld en format‑specifieke beperkingen.
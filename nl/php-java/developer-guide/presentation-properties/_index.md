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
- proefleestaal
- standaardtaal
- PowerPoint
- OpenDocument
- presentatie
- PHP
- Aspose.Slides
description: "Beheer presentatie-eigenschappen in Aspose.Slides for PHP via Java en vereenvoudig zoeken, branding en workflow in uw PowerPoint- en OpenDocument-bestanden."
---
## **Introductie**

Aspose.Slides ondersteunt twee soorten documenteigenschappen: **Built-in** en **Custom**. Beide soorten eigenschappen kunnen eenvoudig worden benaderd en beheerd met de Aspose.Slides API.

Aspose.Slides stelt u in staat om met presentatiedocumenteigenschappen te werken via de [DocumentProperties](https://reference.aspose.com/slides/nl/php-java/aspose.slides/documentproperties/) klasse. Een instantie van deze klasse wordt geretourneerd door de [Presentation::getDocumentProperties](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/#getDocumentProperties) methode. De volgende voorbeelden laten zien hoe u deze eigenschappen kunt lezen, wijzigen en beheren.

{{% alert color="primary" %}} 
Let op dat de velden **Application** en **Producer** niet kunnen worden aangepast, omdat deze velden altijd “Aspose Ltd.” en “Aspose.Slides for PHP via Java x.x.x” weergeven.
{{% /alert %}} 

## **Presentatie‑eigenschappen beheren**

Microsoft PowerPoint biedt een functie om enkele eigenschappen toe te voegen aan presentatiebestanden. Deze documenteigenschappen maken het mogelijk om nuttige informatie op te slaan samen met de documenten (presentatiebestanden). Er zijn twee soorten documenteigenschappen als volgt

- Systeemdefinieerde (Built-in) eigenschappen
- Gebruikersgedefinieerde (Custom) eigenschappen

**Built-in**‑eigenschappen bevatten algemene informatie over het document, zoals de documenttitel, de naam van de auteur, documentstatistieken enzovoort. **Custom**‑eigenschappen zijn die welke door de gebruikers zijn gedefinieerd als **Naam/Waarde**‑paren, waarbij zowel de naam als de waarde door de gebruiker worden opgegeven. Met Aspose.Slides for PHP via Java kunnen ontwikkelaars de waarden van zowel built-in‑ als custom‑eigenschappen benaderen en wijzigen.

## **Documenteigenschappen in PowerPoint**

Microsoft PowerPoint 2007 maakt het mogelijk de documenteigenschappen van presentaties te beheren. Het enige wat u moet doen is op het Office‑pictogram klikken en vervolgens het menu‑item **Prepare | Properties | Advanced Properties** van Microsoft PowerPoint 2007 selecteren, zoals hieronder weergegeven:

|**Selecteer Advanced Properties‑menu‑item**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |

Nadat u het menu‑item **Advanced Properties** hebt geselecteerd, verschijnt er een dialoogvenster waarmee u de documenteigenschappen van het PowerPoint‑bestand kunt beheren, zoals hieronder in de afbeelding:

|**Eigenschappen‑dialoog**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |

In de bovenstaande **Eigenschappen‑dialoog** ziet u dat er vele tabbladen zijn, zoals **General**, **Summary**, **Statistics**, **Contents** en **Custom**. Al deze tabbladen maken het mogelijk verschillende soorten informatie over de PowerPoint‑bestanden te configureren. Het tabblad **Custom** wordt gebruikt om de custom‑eigenschappen van de PowerPoint‑bestanden te beheren.

Werken met documenteigenschappen met Aspose.Slides for PHP via Java

Zoals eerder beschreven ondersteunt Aspose.Slides for PHP via Java twee soorten documenteigenschappen, namelijk **Built-in**‑ en **Custom**‑eigenschappen. Ontwikkelaars kunnen dus beide soorten eigenschappen benaderen via de Aspose.Slides for PHP via Java‑API. Aspose.Slides for PHP via Java biedt een klasse [DocumentProperties](https://reference.aspose.com/slides/nl/php-java/aspose.slides/documentproperties) die de documenteigenschappen van een presentatiebestand vertegenwoordigt via de eigenschap **Presentation.DocumentProperties**.

Ontwikkelaars kunnen de **DocumentProperties**‑eigenschap die wordt blootgesteld door het [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation)‑object gebruiken om de documenteigenschappen van presentaties te benaderen, zoals hieronder beschreven:

## **Built-in‑eigenschappen benaderen**

Deze eigenschappen, zoals blootgesteld door het [DocumentProperties](https://reference.aspose.com/slides/nl/php-java/aspose.slides/documentproperties)-object, omvatten: **Creator** (Auteur), **Description**, **Keywords**, **Created** (Aanmaakdatum), **Modified** (Wijzigingsdatum), **Printed** (Laatste afdrukdatum), **LastModifiedBy**, **Keywords**, **SharedDoc** (Is gedeeld tussen verschillende producenten?), **PresentationFormat**, **Subject** en **Title**

```php
  # Maak een instantie van de Presentation-klasse die de presentatie vertegenwoordigt
  $pres = new Presentation("Presentation.pptx");
  try {
    # Maak een verwijzing naar het IDocumentProperties-object dat aan de presentatie is gekoppeld
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

## **Built-in‑eigenschappen wijzigen**

Het wijzigen van de built-in‑eigenschappen van presentaties is even eenvoudig als ze te benaderen. U kunt simpelweg een tekenreeks aan een gewenste eigenschap toewijzen en de waarde van de eigenschap wordt aangepast. In het onderstaande voorbeeld tonen we hoe u de built-in‑documenteigenschappen van een presentatiedocument kunt wijzigen met Aspose.Slides for PHP via Java.

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    # Maak een verwijzing naar het IDocumentProperties-object dat aan de presentatie is gekoppeld
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

Dit voorbeeld wijzigt de built-in‑eigenschappen van de presentatie, zoals hieronder te zien is:

|**Built-in‑documenteigenschappen na wijziging**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **Aangepaste documenteigenschappen toevoegen**

Aspose.Slides for PHP via Java stelt ontwikkelaars ook in staat om aangepaste waarden toe te voegen aan de documenteigenschappen van een presentatie. Hieronder staat een voorbeeld dat laat zien hoe u custom‑eigenschappen voor een presentatie kunt instellen.

```php
  $pres = new Presentation();
  try {
    # Documenteigenschappen ophalen
    $dProps = $pres->getDocumentProperties();
    # Aangepaste eigenschappen toevoegen
    $dProps->set_Item("New Custom", 12);
    $dProps->set_Item("My Name", "Mudassir");
    $dProps->set_Item("Custom", 124);
    # Eigenschapsnaam ophalen op specifieke index
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

## **Custom‑eigenschappen benaderen en wijzigen**

Aspose.Slides for PHP via Java stelt ontwikkelaars ook in staat de waarden van custom‑eigenschappen te benaderen. Hieronder staat een voorbeeld dat laat zien hoe u alle custom‑eigenschappen van een presentatie kunt benaderen en wijzigen.

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    # Maak een verwijzing naar het DocumentProperties-object dat aan de presentatie is gekoppeld
    $dp = $pres->getDocumentProperties();
    # Toegang tot en wijzigen van custom-eigenschappen
    for($i = 0; $i < java_values($dp->getCountOfCustomProperties()) ; $i++) {
      # Toon namen en waarden van custom-eigenschappen
      echo("Custom Property Name : " . $dp->getCustomPropertyName($i));
      echo("Custom Property Value : " . $dp->get_Item($dp->getCustomPropertyName($i)));
      # Wijzig waarden van custom-eigenschappen
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

Dit voorbeeld wijzigt de custom‑eigenschappen van de [PPTX](https://docs.fileformat.com/presentation/pptx/)-presentatie. De volgende afbeeldingen tonen de custom‑eigenschappen van de presentatie vóór en na de wijziging:

|**Custom‑eigenschappen vóór wijziging**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**Custom‑eigenschappen na wijziging**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **Geavanceerde documenteigenschappen**

{{% alert color="primary" %}} 
Nieuwe methoden [readDocumentProperties](https://reference.aspose.com/slides/nl/php-java/aspose.slides/PresentationInfo/#readDocumentProperties), [updateDocumentProperties](https://reference.aspose.com/slides/nl/php-java/aspose.slides/PresentationInfo/#updateDocumentProperties) en [writeBindedPresentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/PresentationInfo/#writeBindedPresentation) zijn toegevoegd aan [PresentationInfo](https://reference.aspose.com/slides/nl/php-java/aspose.slides/PresentationInfo), de logica van de eigenschapsetter [DocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/nl/php-java/aspose.slides/documentproperties/#setLastSavedTime) is gewijzigd.
{{% /alert %}} 

De twee nieuwe methoden [readDocumentProperties](https://reference.aspose.com/slides/nl/php-java/aspose.slides/PresentationInfo/#readDocumentProperties) en [updateDocumentProperties](https://reference.aspose.com/slides/nl/php-java/aspose.slides/PresentationInfo/#updateDocumentProperties) zijn toegevoegd aan de klasse [PresentationInfo](https://reference.aspose.com/slides/nl/php-java/aspose.slides/PresentationInfo). Ze bieden snelle toegang tot documenteigenschappen en maken het mogelijk eigenschappen te wijzigen en bij te werken zonder een volledige presentatie te laden.

Het typische scenario waarbij de eigenschappen worden geladen, een waarde wordt gewijzigd en het document wordt bijgewerkt, kan op de volgende manier worden geïmplementeerd:

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

Er is een andere manier om de eigenschappen van een bepaalde presentatie als sjabloon te gebruiken om eigenschappen in andere presentaties bij te werken:

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

Er kan een nieuw sjabloon vanaf nul worden gemaakt en vervolgens worden gebruikt om meerdere presentaties bij te werken:

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

## **Proefleestaal instellen**

Aspose.Slides biedt de eigenschap LanguageId (beschikbaar via de klasse PortionFormat) om de proefleestaal voor een PowerPoint‑document in te stellen. De proefleestaal is de taal waarvoor spelling en grammatica in PowerPoint worden gecontroleerd.

Deze PHP‑code toont hoe u de proefleestaal voor een PowerPoint instelt: xxx Waarom ontbreekt LanguageId in de Java‑PortionFormat‑klasse?

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
    $portionFormat::setLanguageId("zh-CN");// stel de Id van een proefleestaal in

    $newPortion->setText("1。");
    $paragraph->getPortions()->add($newPortion);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Standaardtaal instellen**

Deze PHP‑code toont hoe u de standaardtaal voor een volledige PowerPoint‑presentatie instelt:

```php
  $loadOptions = new LoadOptions();
  $loadOptions->setDefaultTextLanguage("en-US");
  $pres = new Presentation($loadOptions);
  try {
    # Voeg een nieuw rechthoekig vorm toe met tekst
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

Probeer de online app [**Aspose.Slides Metadata**](https://products.aspose.app/slides/nl/metadata) om te zien hoe u met documenteigenschappen kunt werken via de Aspose.Slides‑API:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/nl/metadata)

## **FAQ**

**Hoe kan ik een built-in‑eigenschap uit een presentatie verwijderen?**

Built-in‑eigenschappen maken een integraal onderdeel van de presentatie uit en kunnen niet volledig worden verwijderd. U kunt echter de waarden wijzigen of, als de specifieke eigenschap dat toestaat, ze leeg maken.

**Wat gebeurt er als ik een custom‑eigenschap toevoeg die al bestaat?**

Als u een custom‑eigenschap toevoegt die al bestaat, wordt de bestaande waarde overschreven door de nieuwe. U hoeft de eigenschap niet vooraf te verwijderen of te controleren, aangezien Aspose.Slides de waarde automatisch bijwerkt.

**Kan ik presentatie‑eigenschappen benaderen zonder de presentatie volledig te laden?**

Ja, u kunt presentatie‑eigenschappen benaderen zonder de volledige presentatie te laden door de `getPresentationInfo`‑methode van de klasse [PresentationFactory](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentationfactory/) te gebruiken. Vervolgens kunt u de `readDocumentProperties`‑methode van de klasse [PresentationInfo](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentationinfo/) aanroepen om de eigenschappen efficiënt te lezen, waardoor geheugen wordt bespaard en de prestaties verbeteren.
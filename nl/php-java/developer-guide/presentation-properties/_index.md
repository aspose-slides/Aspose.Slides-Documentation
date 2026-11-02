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
- controletaal
- standaardtaal
- PowerPoint
- OpenDocument
- presentatie
- PHP
- Aspose.Slides
description: "Beheer presentatie-eigenschappen in Aspose.Slides voor PHP via Java en optimaliseer zoeken, branding en workflow in uw PowerPoint- en OpenDocument-bestanden."
---
## **Introductie**

Aspose.Slides voor PHP via Java ondersteunt **ingebouwde** en **aangepaste** documenteigenschappen. Gebruik deze eigenschappen om presentatiemetadata te lezen en bij te werken, zoals de auteur, titel en door de gebruiker gedefinieerde waarden.

Aspose.Slides stelt u in staat om met documenteigenschappen van presentaties te werken via de [DocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/) klasse. Een instantie van deze klasse wordt geretourneerd door [Presentation::getDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getdocumentproperties/). De volgende voorbeelden tonen hoe deze eigenschappen gelezen, gewijzigd en beheerd kunnen worden. Ze gaan ervan uit dat PHP/Java Bridge en de Aspose.Slides PHP-wrapper zijn geïnitialiseerd.

{{% alert color="info" title="Note" %}}
Aspose.Slides beheert de toepassings- en producentmetadata bij het opslaan van presentaties; deze velden identificeren de software die de output heeft gegenereerd.
{{% /alert %}}

## **Beheer presentatieweigenschappen**

Documenteigenschappen slaan beschrijvende informatie op naast de inhoud van de presentatie. Ze vallen in twee categorieën:

- **Ingebouwde eigenschappen** bevatten standaardmetadata, zoals de titel, auteur en documentstatistieken.
- **Aangepaste eigenschappen** slaan door de gebruiker gedefinieerde naam/waarde‑paren op.

Aspose.Slides voor PHP via Java biedt toegang tot beide categorieën. In PowerPoint kiest u **File → Info → Properties → Advanced Properties** om documentmetadata te inspecteren. Het dialoogvenster groepeert informatie in tabbladen zoals **Summary**, **Statistics**, **Contents** en **Custom**. Gebruik het tabblad **Custom** om door de gebruiker gedefinieerde eigenschappen te beheren.

## **Openbare eigenschappen lezen van een versleutelde presentatie**

Een openingswachtwoord beschermt normaal zowel de inhoud van de presentatie als de documenteigenschappen. Wanneer een presentatie wordt versleuteld nadat [ProtectionManager::setEncryptDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/protectionmanager/setencryptdocumentproperties/) is aangeroepen met `false`, blijven de documenteigenschappen publiek. Een toepassing kan dan [LoadOptions::setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/setonlyloaddocumentproperties/) aanroepen met `true` en de openbare metadata lezen zonder het openingswachtwoord te leveren.

[LoadOptions::setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/setonlyloaddocumentproperties/) bepaalt wat Aspose.Slides laadt; het ontsleutelt niets. Als de eigenschappen zijn inbegrepen in de versleuteling, mislukt het laden zonder wachtwoord. Als de presentatie niet is versleuteld, wordt de optie genegeerd en wordt de volledige presentatie geladen.

Het voorbeeld vereist een versleutelde presentatie waarvan de documenteigenschappen publiek zijn gelaten. Het controleert de laadmodus via [ProtectionManager::isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/php-java/aspose.slides/protectionmanager/isonlydocumentpropertiesloaded/) en leest vervolgens ingebouwde eigenschappen via [Presentation::getDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getdocumentproperties/):

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;

$loadOptions = new LoadOptions();
$loadOptions->setOnlyLoadDocumentProperties(true);

$presentation = new Presentation("public-properties-encrypted.pptx", $loadOptions);
try {
    if (java_values($presentation->getProtectionManager()->isOnlyDocumentPropertiesLoaded())) {
        $documentProperties = $presentation->getDocumentProperties();

        echo("Author: " . $documentProperties->getAuthor() . "\n");
        echo("Title: " . $documentProperties->getTitle() . "\n");
        echo("Keywords: " . $documentProperties->getKeywords() . "\n");
    } else {
        echo("The presentation was not loaded in document-properties-only mode." . "\n");
    }
} finally {
    $presentation->dispose();
}
```

In deze modus wordt de inhoud van de dia's niet geladen. Dia’s, masters, lay-outs, vormen, media en andere presentatie‑objecten zijn niet beschikbaar. Toepassingen moeten altijd [ProtectionManager::isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/php-java/aspose.slides/protectionmanager/isonlydocumentpropertiesloaded/) controleren voordat een bewerking wordt uitgevoerd die het volledige presentatie‑objectmodel vereist.

{{% alert color="warning" title="Warning" %}}
Openbare metadata kan namen van auteurs, titels, onderwerpen, trefwoorden, bedrijfsinformatie, opmerkingen en aangepaste waarden blootleggen. Versleutel gevoelige eigenschappen samen met de presentatie. Laat ze alleen openbaar wanneer indexerings‑, classificatie‑, zoek‑ of document‑beheersystemen een specifieke vereiste hebben om ze zonder wachtwoord te benaderen.
{{% /alert %}}

## **Eigenschappen van een versleutelde presentatie bijwerken**

Voor een versleuteld PPTX‑bestand is een presentatie die is geladen na het aanroepen van [LoadOptions::setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/setonlyloaddocumentproperties/) met `true` bedoeld voor het lezen van openbare metadata. Aspose.Slides kan geen gewijzigde eigenschappen van dat alleen‑metadata‑object opslaan, omdat de openbare eigenschappen consistent moeten blijven met de corresponderende gegevens in de versleutelde presentatie. Het bijwerken hiervan vereist daarom het juiste openingswachtwoord en een volledige load.

Het voorbeeld vereist een versleutelde PPTX‑presentatie met openbare documenteigenschappen en een bekend openingswachtwoord. Het opent de volledige presentatie met [LoadOptions::setPassword](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/setpassword/), werkt openbare ingebouwde eigenschappen bij en slaat het resultaat op. Vervolgens wordt met [PresentationInfo::isEncrypted](https://reference.aspose.com/slides/php-java/aspose.slides/presentationinfo/isencrypted/) gecontroleerd of de versleuteling behouden blijft en wordt de openbare metadata opnieuw geopend zonder wachtwoord om de nieuwe waarden te verifiëren:

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
    $documentProperties = $presentation->getDocumentProperties();
    $documentProperties->setTitle("Updated Product Roadmap");
    $documentProperties->setKeywords("roadmap, planning, indexed");
    
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
        echo("The presentation was not loaded in document-properties-only mode." . "\n");
    }
} finally {
    $metadataPresentation->dispose();
}
```

Als een toepassing niet toegestaan is om de presentatie‑inhoud te ontsleutelen of te laden, moet hij openbare eigenschappen van een versleuteld PPTX‑bestand als alleen‑lezen beschouwen.

## **Toegang tot ingebouwde eigenschappen**

De [DocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/) klasse stelt ingebouwde metadata bloot via getter‑methoden, waaronder [getAuthor](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/getauthor/), [getTitle](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/gettitle/) en [getCreatedTime](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/getcreatedtime/). Dit voorbeeld opent een bestaande presentatie en drukt de opgeslagen metadata af op de console. Waarden hangen af van de invoerpresentatie; sommige velden kunnen leeg zijn.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("AccessBuiltInProperties.pptx");
try {
    $documentProperties = $presentation->getDocumentProperties();

    echo("Category: " . $documentProperties->getCategory() . "\n");
    echo("Content status: " . $documentProperties->getContentStatus() . "\n");
    echo("Creation date: " . $documentProperties->getCreatedTime() . "\n");
    echo("Author: " . $documentProperties->getAuthor() . "\n");
    echo("Comments: " . $documentProperties->getComments() . "\n");
    echo("Keywords: " . $documentProperties->getKeywords() . "\n");
    echo("Last modified by: " . $documentProperties->getLastSavedBy() . "\n");
    echo("Manager: " . $documentProperties->getManager() . "\n");
    echo("Modified date: " . $documentProperties->getLastSavedTime() . "\n");
    echo("Presentation format: " . $documentProperties->getPresentationFormat() . "\n");
    echo("Last print date: " . $documentProperties->getLastPrinted() . "\n");
    echo("Is shared between producers: " . (java_values($documentProperties->getSharedDoc()) ? "true" : "false") . "\n");
    echo("Subject: " . $documentProperties->getSubject() . "\n");
    echo("Title: " . $documentProperties->getTitle() . "\n");
} finally {
    $presentation->dispose();
}
```

## **Ingebouwde eigenschappen wijzigen**

Om ingebouwde metadata bij te werken, gebruikt u de setter‑methoden op het object dat wordt geretourneerd door [Presentation::getDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getdocumentproperties/). Dit voorbeeld opent een bestaande presentatie, roept [setAuthor](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/setauthor/), [setTitle](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/settitle/), [setSubject](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/setsubject/), [setComments](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/setcomments/) en [setManager](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/setmanager/) aan, en slaat de bijgewerkte presentatie op met [Presentation::save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/save/). De opgeslagen PPTX bevat de nieuwe metadata.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("ModifyBuiltInProperties.pptx");
try {
    $documentProperties = $presentation->getDocumentProperties();

    $documentProperties->setAuthor("Aspose.Slides for PHP via Java");
    $documentProperties->setTitle("Manage PowerPoint Presentation Properties");
    $documentProperties->setSubject("Modify Built-in Properties");
    $documentProperties->setComments("Aspose description");
    $documentProperties->setManager("Aspose manager");

    $presentation->save("DocumentProperties_output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Beheer van de hyperlink‑basis**

[DocumentProperties::getHyperlinkBase](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/gethyperlinkbase/) retourneert de document‑niveau basis voor relatieve hyperlinks. Gebruik [DocumentProperties::setHyperlinkBase](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/sethyperlinkbase/) om deze te wijzigen of te verwijderen. Dit is nuttig bij het verplaatsen van een presentatie en de gekoppelde bestanden naar een andere locatie. Het staat los van de individuele hyperlink‑[Hyperlink::getExternalUrl](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/getexternalurl/): het wijzigen van de basis herschrijft de opgeslagen koppelingen niet en verandert geen absolute bestemmingen.

Het voorbeeld vereist een presentatie met zowel een relatieve koppeling, bijvoorbeeld `target.html`, als een absolute koppeling, bijvoorbeeld `https://example.org/absolute.html`. Het leest de bestaande basis, kent een nieuw basisadres toe, slaat de presentatie op en opent deze opnieuw om de waarde te controleren. Vervolgens wordt de basis gewist met een lege tekenreeks en wordt de lege waarde in een afzonderlijk opgeslagen bestand geverifieerd. Vervang het voorbeeld‑basisadres door de locatie van uw gekoppelde bestanden.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("hyperlinks.pptx");
try {
    echo("Original base: " . $presentation->getDocumentProperties()->getHyperlinkBase() . "\n");

    $newBase = "https://example.com/new/";
    $presentation->getDocumentProperties()->setHyperlinkBase($newBase);
    $presentation->save("hyperlinks-updated.pptx", SaveFormat::Pptx);

    $updatedPresentation = new Presentation("hyperlinks-updated.pptx");
    try {
        echo("Base preserved: " . ((string) $updatedPresentation->getDocumentProperties()->getHyperlinkBase() === $newBase ? "true" : "false") . "\n");

        $updatedPresentation->getDocumentProperties()->setHyperlinkBase("");
        $updatedPresentation->save("hyperlinks-cleared.pptx", SaveFormat::Pptx);

        $clearedPresentation = new Presentation("hyperlinks-cleared.pptx");
        try {
            echo("Base cleared: " . ((string) $clearedPresentation->getDocumentProperties()->getHyperlinkBase() === "" ? "true" : "false") . "\n");
        } finally {
            $clearedPresentation->dispose();
        }
    } finally {
        $updatedPresentation->dispose();
    }
} finally {
    $presentation->dispose();
}
```

De twee verificatie‑berichten moeten `true` afdrukken. Het wissen van de basis laat de individuele hyperlink‑adressen ongewijzigd.

Een relatieve koppeling naar `target.pptx` opende `old/target.pptx` toen de basis verwees naar de map `old`. Na het wijzigen van de basis naar de map `new`, het opslaan en opnieuw openen van de presentatie, opende dezelfde koppeling `new/target.pptx`. Een absolute koppeling bleef hetzelfde bestand openen. Test uw relatieve koppelingen in PowerPoint vóór en na het verplaatsen van de presentatie of het wijzigen van de basis.

## **Aangepaste presentatie‑eigenschappen toevoegen**

Aangepaste eigenschappen slaan metadata op waarvoor geen ingebouwd veld bestaat. De [DocumentProperties::set_Item](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/set_item/) methode laat u een waarde toewijzen op basis van de eigenschapsnaam. Dit voorbeeld maakt een presentatie, voegt twee tekstwaarden en een gehele versie‑waarde toe, en slaat de presentatie op met [Presentation::save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/save/). Het toewijzen van een waarde aan een bestaande naam vervangt de waarde van die eigenschap.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $documentProperties = $presentation->getDocumentProperties();

    $documentProperties->set_Item("Reviewed by", "John Smith");
    $documentProperties->set_Item("Confidentiality level", "Internal");
    $documentProperties->set_Item("Document version", 2);

    $presentation->save("CustomDocumentProperties_output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Aangepaste eigenschappen benaderen en wijzigen**

Dit voorbeeld opent een presentatie met aangepaste eigenschappen en gebruikt [getCountOfCustomProperties](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/getcountofcustomproperties/) om erover te itereren. [getCustomPropertyName](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/getcustompropertyname/) accepteert een nul‑gebaseerde index en retourneert de naam die wordt gebruikt door [DocumentProperties::set_Item](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/set_item/). Het voorbeeld drukt elke originele naam en waarde af, vervangt elke waarde door een genummerde tekenreeks ongeacht het oorspronkelijke type, en slaat de wijzigingen op. Als er geen aangepaste eigenschappen zijn, brengt de lus geen wijzigingen aan.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("AccessAndModifyProperties.pptx");
try {
    $documentProperties = $presentation->getDocumentProperties();

    for ($i = 0; $i < java_values($documentProperties->getCountOfCustomProperties()); $i++) {
        $propertyName = $documentProperties->getCustomPropertyName($i);
        $propertyValue = $documentProperties->get_Item($propertyName);

        echo("Custom property name: " . $propertyName . "\n");
        echo("Custom property value: " . $propertyValue . "\n");

        $documentProperties->set_Item($propertyName, "New Value " . ($i + 1));
    }

    $presentation->save("CustomProperties_output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Live‑voorbeeld**

Probeer de online app [**Bekijk en bewerk PowerPoint-metadata**](https://products.aspose.app/slides/metadata) om te zien hoe u met documenteigenschappen kunt werken via de Aspose.Slides‑API:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **FAQ**

**Hoe kan ik een ingebouwde eigenschap uit een presentatie verwijderen?**

Ingebouwde eigenschappen maken een integraal deel van de presentatie uit en kunnen niet volledig worden verwijderd. U kunt echter hun waarden wijzigen of, indien toegestaan door de specifieke eigenschap, ze leeg maken.

**Wat gebeurt er als ik een aangepaste eigenschap toevoeg die al bestaat?**

Als u een aangepaste eigenschap toevoegt die al bestaat, wordt de bestaande waarde overschreven met de nieuwe. Het is niet nodig de eigenschap vooraf te verwijderen of te controleren, want Aspose.Slides werkt de eigenschapswaarde automatisch bij.

**Kan ik presentatieweigenschappen benaderen zonder de volledige presentatie te laden?**

Ja. Gebruik [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/php-java/aspose.slides/presentationfactory/getpresentationinfo/) en vervolgens [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentationinfo/readdocumentproperties/) om opgeslagen documentmetadata te lezen zonder een [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)‑instantie te creëren. Zie [Bouw een lichtgewicht presentatielijst](/slides/nl/php-java/examine-presentation/) voor een volledig rapportage‑voorbeeld en format‑specifieke beperkingen.

**Kan ik openbare eigenschappen van een versleutelde presentatie lezen zonder het openingswachtwoord?**

Ja. De presentatie moet versleuteld zijn nadat [ProtectionManager::setEncryptDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/protectionmanager/setencryptdocumentproperties/) is aangeroepen met `false`, en moet worden geladen na het aanroepen van [LoadOptions::setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/setonlyloaddocumentproperties/) met `true`.

**Kan ik een versleuteld PPTX‑bestand bijwerken in alleen‑document‑eigenschappen‑modus?**

Nee. Publieke en versleutelde eigenschapsgegevens moeten consistent blijven, dus het bijwerken van een versleuteld PPTX‑bestand vereist het volledige laden van de presentatie met het juiste openingswachtwoord.
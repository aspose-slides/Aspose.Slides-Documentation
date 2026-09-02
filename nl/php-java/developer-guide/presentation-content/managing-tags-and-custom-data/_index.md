---
title: Beheer tags en aangepaste gegevens in presentaties met PHP
linktitle: Tags en aangepaste gegevens
type: docs
weight: 300
url: /nl/php-java/managing-tags-and-custom-data/
keywords:
- documenteigenschappen
- tag
- aangepaste gegevens
- aangepaste XML
- aangepast XML-onderdeel
- XML-metadata
- ItemId
- tag toevoegen
- waardeparen
- PowerPoint
- presentatie
- PHP
- Aspose.Slides
description: "Leer hoe u tags en aangepaste XML-gegevens in PowerPoint-presentaties kunt beheren met Aspose.Slides for PHP via Java, inclusief het toevoegen, lezen, bijwerken, auditen en verwijderen van aangepaste XML-onderdelen."
---
## **Overzicht**

Dit artikel legt uit hoe Aspose.Slides omgaat met tags en aangepaste gegevens in PowerPoint‑presentaties. Presentatie‑specifieke gegevens kunnen worden opgeslagen als tags of aangepaste XML‑onderdelen. Tags zijn eenvoudige sleutel‑waarde tekenreeksparen, terwijl aangepaste XML‑onderdelen gestructureerde metadata en toepassingsspecifieke XML‑payloads kunnen bevatten.

Aspose.Slides biedt API’s voor het toevoegen, lezen, bijwerken, auditen en verwijderen van aangepaste XML‑onderdelen op presentatieniveau, dia‑ en vormniveau. Aangepaste XML‑onderdelen zijn nuttig voor integraties die informatie opslaan zoals documenten‑beheer‑identifiers, workflow‑status, compliance‑metadata, sjabloon‑bindingsgegevens of andere gestructureerde toepassingsgegevens binnen een presentatie.

## **Gegevensopslag in presentatiebestanden**

PPTX‑bestanden — bestanden met de extensie `.pptx` — worden opgeslagen in het PresentationML‑formaat, dat deel uitmaakt van de Office Open XML‑specificatie. Office Open XML definieert de pakketstructuur en relaties die worden gebruikt om presentatiewaarde en gerelateerde gegevens op te slaan.

Een presentatie bevat meerdere onderdelen die via relaties met elkaar verbonden zijn. Een dia‑onderdeel bijvoorbeeld bevat de inhoud van één dia en kan expliciete relaties hebben met andere onderdelen zoals gedefinieerd in ISO/IEC 29500.

Aangepaste gegevens kunnen worden opgeslagen als tags ([TagCollection](https://reference.aspose.com/slides/nl/php-java/aspose.slides/tagcollection/)) of als aangepaste XML‑onderdelen ([CustomXmlPartCollection](https://reference.aspose.com/slides/nl/php-java/aspose.slides/customxmlpartcollection/)). Beide zijn beschikbaar via de [`CustomData`](https://reference.aspose.com/slides/nl/php-java/aspose.slides/customdata/)‑klasse.

{{% alert color="primary" %}}
Tags slaan eenvoudige tekenreeks‑sleutel‑waarde paren op. Aangepaste XML‑onderdelen slaan gestructureerde XML‑gegevens op en kunnen worden gekoppeld aan een presentatie, dia of vorm.
{{% /alert %}}

## **Werken met aangepaste XML‑onderdelen**

De methode [`CustomData::getCustomXmlParts()`](https://reference.aspose.com/slides/nl/php-java/aspose.slides/customdata/#getCustomXmlParts) retourneert de verzameling van aangepaste XML‑onderdelen die aan een bepaald presentatie‑object zijn gekoppeld. Bijvoorbeeld:

- `$presentation->getCustomData()->getCustomXmlParts()` bevat aangepaste XML‑onderdelen die bij de presentatie zelf horen.
- `$slide->getCustomData()->getCustomXmlParts()` bevat aangepaste XML‑onderdelen die bij een specifieke dia horen.
- `$shape->getCustomData()->getCustomXmlParts()` bevat aangepaste XML‑onderdelen die bij een specifieke vorm horen.

Gebruik [`Presentation::getAllCustomXmlParts()`](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/#getAllCustomXmlParts) wanneer u alle aangepaste XML‑onderdelen in de presentatie wilt inspecteren, ongeacht waar ze gekoppeld zijn.

### **Een aangepast XML‑onderdeel toevoegen aan een presentatie**

Gebruik [`CustomXmlPartCollection::add`](https://reference.aspose.com/slides/nl/php-java/aspose.slides/customxmlpartcollection/#add) om XML‑gegevens toe te voegen aan een collectie van aangepaste XML‑onderdelen. De XML moet geldig en niet‑leeg zijn.

Het volgende voorbeeld voegt gestructureerde metadata toe aan de presentatie‑niveau aangepaste gegevensverzameling:

```php
$customXmlContent =
    '<?xml version="1.0" encoding="UTF-8"?>' .
    '<metadata xmlns="urn:example:metadata">' .
        '<documentId>DOC-1001</documentId>' .
        '<workflowState>Draft</workflowState>' .
    '</metadata>';

$presentation = new Presentation();
try {
    $customXmlPart = $presentation->getCustomData()->getCustomXmlParts()->add($customXmlContent);

    // add wijst automatisch een identifier toe. Stel een specifieke UUID alleen in wanneer dat nodig is.
    $UUID = new JavaClass("java.util.UUID");
    $customXmlPart->setItemId($UUID->randomUUID());

    $presentation->save("presentation_with_custom_xml.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

De `add`‑methode kan ook XML accepteren als een byte‑array of invoerstroom, wat handig is wanneer XML‑inhoud al in binaire vorm beschikbaar is.

### **Een aangepast XML‑onderdeel toevoegen aan een dia of vorm**

Aangepaste XML‑gegevens kunnen worden gekoppeld aan een specifieke dia of vorm in plaats van aan de volledige presentatie. Dit is handig wanneer metadata slechts één object beschrijft, zoals een sjabloonsleutel, externe record‑identifier of bind‑informatie.

Het volgende voorbeeld voegt één aangepast XML‑onderdeel toe aan een dia en een ander aan een vorm:

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $slide->getCustomData()->getCustomXmlParts()->add(
        '<slideMetadata xmlns="urn:example:slides">' .
            '<templateKey>TitleSlide</templateKey>' .
        '</slideMetadata>'
    );

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 250, 80);

    $shape->getTextFrame()->setText("Customer data");
    $shape->getCustomData()->getCustomXmlParts()->add(
        '<shapeMetadata xmlns="urn:example:shapes">' .
            '<recordId>CRM-4281</recordId>' .
        '</shapeMetadata>'
    );

    $presentation->save("object_custom_xml.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Het niveau waarop een onderdeel wordt toegevoegd bepaalt in welke `getCustomData()->getCustomXmlParts()`‑verzameling van een object de relatie naar dat onderdeel wordt opgenomen. Gegevens op presentatieniveau zijn geschikt voor metadata die het hele document betreft, gegevens op dia‑niveau voor informatie die tot een bepaalde dia behoort, en gegevens op vorm‑niveau voor metadata die gekoppeld is aan een individuele vorm.

### **Alle aangepaste XML‑onderdelen opsommen en auditen**

Gebruik [`Presentation::getAllCustomXmlParts()`](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/#getAllCustomXmlParts) om alle aangepaste XML‑onderdelen uit een presentatie op te halen. Elk [`CustomXmlPart`](https://reference.aspose.com/slides/nl/php-java/aspose.slides/customxmlpart/) toont zijn identifier, XML‑inhoud en bijbehorende namespace‑schema’s.

Het volgende voorbeeld somt alle aangepaste XML‑onderdelen en hun namespace‑schema’s op:

```php
$presentation = new Presentation("presentation.pptx");
try {
    foreach ($presentation->getAllCustomXmlParts() as $customXmlPart) {
        echo "ItemId: " . $customXmlPart->getItemId() . PHP_EOL;
        echo "XML:" . PHP_EOL;
        echo $customXmlPart->getXmlAsString() . PHP_EOL;

        foreach ($customXmlPart->getNamespaceSchemas() as $namespaceSchema) {
            echo "Namespace schema: " . $namespaceSchema . PHP_EOL;
        }

        echo PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

[`CustomXmlPart::getNamespaceSchemas()`](https://reference.aspose.com/slides/nl/php-java/aspose.slides/customxmlpart/#getNamespaceSchemas) retourneert de XML‑schema’s die aan het aangepaste XML‑onderdeel zijn gekoppeld. Deze informatie kan nuttig zijn bij het auditen van presentaties die XML bevatten die door externe systemen is geproduceerd.

### **XML‑inhoud en ItemId lezen en bijwerken**

Gebruik [`CustomXmlPart::getXmlAsString()`](https://reference.aspose.com/slides/nl/php-java/aspose.slides/customxmlpart/#getXmlAsString) en [`setXmlAsString()`](https://reference.aspose.com/slides/nl/php-java/aspose.slides/customxmlpart/#setXmlAsString) om met XML te werken als een UTF‑8‑tekenreeks, of [`getXmlData()`](https://reference.aspose.com/slides/nl/php-java/aspose.slides/customxmlpart/#getXmlData) en [`setXmlData()`](https://reference.aspose.com/slides/nl/php-java/aspose.slides/customxmlpart/#setXmlData) om met de ruwe XML‑bytes te werken.

De methode [`CustomXmlPart::getItemId()`](https://reference.aspose.com/slides/nl/php-java/aspose.slides/customxmlpart/#getItemId) retourneert de UUID die het aangepaste XML‑onderdeel identificeert in het Office Open XML‑document. Gebruik [`setItemId()`](https://reference.aspose.com/slides/nl/php-java/aspose.slides/customxmlpart/#setItemId) wanneer een integratie een nieuwe identifier vereist.

Het volgende voorbeeld werkt de XML‑inhoud en de identifier bij:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $customXmlPart = $presentation->getAllCustomXmlParts()[0];

    // Lees de huidige XML als tekst.
    $currentXmlContent = $customXmlPart->getXmlAsString();
    echo $currentXmlContent . PHP_EOL;

    // Werk de XML bij als een UTF-8-tekenreeks.
    $customXmlPart->setXmlAsString(
        '<metadata xmlns="urn:example:metadata">' .
            '<documentId>DOC-1001</documentId>' .
            '<workflowState>Approved</workflowState>' .
        '</metadata>'
    );

    // getXmlData levert dezelfde XML‑inhoud als ruwe bytes.
    $customXmlData = $customXmlPart->getXmlData();

    // Vervang de identifier wanneer de integratie dat vereist.
    $UUID = new JavaClass("java.util.UUID");
    $customXmlPart->setItemId($UUID->randomUUID());

    $presentation->save("updated_custom_xml.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Bij het aanroepen van `setXmlAsString` of `setXmlData` moet geldige, niet‑leeg XML worden opgegeven. Gebruik de ene weergave of de andere afhankelijk van of de applicatie voornamelijk met tekenreeksen of met byte‑gegevens werkt.

### **Een aangepast XML‑onderdeel verwijderen**

Aspose.Slides biedt verschillende manieren om aangepaste XML‑gegevens te verwijderen:

- [`CustomXmlPart::remove`](https://reference.aspose.com/slides/nl/php-java/aspose.slides/customxmlpart/#remove) verwijdert het aangepaste XML‑onderdeel uit de presentatie.
- [`CustomXmlPartCollection::remove`](https://reference.aspose.com/slides/nl/php-java/aspose.slides/customxmlpartcollection/#remove) verwijdert een specifiek onderdeel uit een collectie van aangepaste XML‑onderdelen.
- [`CustomXmlPartCollection::removeAt`](https://reference.aspose.com/slides/nl/php-java/aspose.slides/customxmlpartcollection/#removeAt) verwijdert het onderdeel op een opgegeven index in de collectie.
- [`CustomXmlPartCollection::clear`](https://reference.aspose.com/slides/nl/php-java/aspose.slides/customxmlpartcollection/#clear) verwijdert alle onderdelen uit een specifieke collectie.

Het volgende voorbeeld verwijdert één presentatie‑niveau aangepast XML‑onderdeel via referentie:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $customXmlParts = $presentation->getCustomData()->getCustomXmlParts();

    if (java_values($customXmlParts->size()) > 0) {
        $customXmlPart = $customXmlParts->get_Item(0);
        $customXmlParts->remove($customXmlPart);
    }

    $presentation->save("custom_xml_removed.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Als u al een `CustomXmlPart` hebt en dat onderdeel uit de presentatie wilt verwijderen in plaats van een specifieke collectie, roep dan `$customXmlPart->remove()` aan.

U kunt ook een item verwijderen op basis van index:

```php
$presentation->getCustomData()->getCustomXmlParts()->removeAt(0);
```

### **Alle aangepaste XML‑onderdelen uit een collectie wissen**

Gebruik `clear` wanneer alle aangepaste XML‑onderdelen die aan een bepaald presentatiedeel zijn gekoppeld, verwijderd moeten worden.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $presentation->getSlides()->get_Item(0)->getCustomData()->getCustomXmlParts()->clear();

    $presentation->save("slide_custom_xml_cleared.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

`clear` beïnvloedt alleen de geselecteerde collectie. Het wissen van de collectie van een dia bijvoorbeeld, wist niet de presentatieniveau‑ of vormniveau‑collecties.

Om elk aangepast XML‑onderdeel in de presentatie te verwijderen, kunt u door `getAllCustomXmlParts()` itereren en elk onderdeel verwijderen:

```php
$presentation = new Presentation("presentation.pptx");
try {
    foreach ($presentation->getAllCustomXmlParts() as $customXmlPart) {
        $customXmlPart->remove();
    }

    $presentation->save("all_custom_xml_removed.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Gekoppelde of gedeelde aangepaste XML‑onderdelen afhandelen**

In een Office Open XML‑presentatie kan hetzelfde aangepaste XML‑onderdeel vanaf meer dan één presentatie‑object worden gerefereerd. Een bestaand bestand kan bijvoorbeeld relaties bevatten van meerdere dia’s of vormen naar hetzelfde onderliggende aangepaste XML‑onderdeel.

Een gedeeld onderdeel moet worden behandeld als één gegevensobject met meerdere referenties:

- Bijwerken met `setXmlAsString`, `setXmlData` of `setItemId` wijzigt het onderliggende aangepaste XML‑onderdeel, waardoor de wijziging geldt waar het onderdeel ook wordt gerefereerd.
- `getItemId()` kan worden gebruikt om hetzelfde aangepaste XML‑onderdeel te identificeren tijdens het auditen van object‑niveau collecties.
- Het verwijderen van een onderdeel uit een specifieke `getCustomXmlParts()`‑collectie verwijdert het alleen uit die collectie. Gebruik `CustomXmlPart::remove()` wanneer het onderdeel zelf uit de presentatie moet worden verwijderd.
- Controleer vóór het verwijderen of vervangen van een gedeeld onderdeel de object‑niveau collecties om te bepalen of andere dia’s of vormen nog naar het onderdeel verwijzen.

De `add`‑overloads maken een nieuw aangepast XML‑onderdeel aan op basis van XML‑inhoud; ze accepteren geen bestaand `CustomXmlPart`. Gedeelde relaties komen dus meestal voor bij het laden van presentaties die al dergelijke relaties bevatten.

Het volgende voorbeeld audit de presentatieniveau‑, dia‑ en vorm‑collecties op `ItemId` en meldt onderdelen die vanaf meer dan één plek worden gerefereerd:

```php
function registerCustomXmlParts($ownerName, $customXmlParts, &$referencesByItemId) {
    $partCount = java_values($customXmlParts->size());

    for ($i = 0; $i < $partCount; $i++) {
        $customXmlPart = $customXmlParts->get_Item($i);
        $itemId = java_values($customXmlPart->getItemId()->toString());

        if (!isset($referencesByItemId[$itemId])) {
            $referencesByItemId[$itemId] = [];
        }

        $referencesByItemId[$itemId][] = $ownerName;
    }
}

$presentation = new Presentation("presentation.pptx");
try {
    $referencesByItemId = [];

    registerCustomXmlParts(
        "Presentation",
        $presentation->getCustomData()->getCustomXmlParts(),
        $referencesByItemId
    );

    $slideCount = java_values($presentation->getSlides()->size());
    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        registerCustomXmlParts(
            "Slide " . ($slideIndex + 1),
            $slide->getCustomData()->getCustomXmlParts(),
            $referencesByItemId
        );

        $shapeCount = java_values($slide->getShapes()->size());
        for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
            $shape = $slide->getShapes()->get_Item($shapeIndex);
            registerCustomXmlParts(
                "Slide " . ($slideIndex + 1) . ", shape " . $shapeIndex,
                $shape->getCustomData()->getCustomXmlParts(),
                $referencesByItemId
            );
        }
    }

    foreach ($referencesByItemId as $itemId => $owners) {
        if (count($owners) > 1) {
            echo "Shared custom XML part: " . $itemId . PHP_EOL;

            foreach ($owners as $ownerName) {
                echo "  Referenced by: " . $ownerName . PHP_EOL;
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

Dit type audit is nuttig voordat u aangepaste XML‑gegevens in presentaties wijzigt of verwijdert die door externe systemen zijn aangemaakt, omdat hetzelfde metadata‑onderdeel deel kan uitmaken van meerdere relaties.

## **Waarden van tags ophalen**

In slides komt een tag overeen met de methode `DocumentProperties::getKeywords()`. Deze voorbeeldcode laat zien hoe u een tag‑waarde kunt ophalen met Aspose.Slides for PHP via Java voor [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/):

```php
$presentation = new Presentation("presentation.pptx");
try {
    $keywords = $presentation->getDocumentProperties()->getKeywords();
} finally {
    $presentation->dispose();
}
```

## **Tags toevoegen aan presentaties**

Aspose.Slides maakt het mogelijk tags toe te voegen aan presentaties. Een tag bestaat doorgaans uit twee elementen:

- de naam van een aangepaste eigenschap, bijvoorbeeld `MyTag`;
- de waarde van de aangepaste eigenschap, bijvoorbeeld `My Tag Value`.

Wanneer u presentaties wilt classificeren op basis van een specifieke regel of eigenschap, kunt u daarvoor tags toevoegen. Bijvoorbeeld, als u presentaties uit Noord‑Amerikaanse landen wilt categoriseren, kunt u een Noord‑Amerikaanse tag maken en het bijbehorende land als waarde toekennen.

Deze voorbeeldcode toont hoe u een tag toevoegt aan een [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/) met Aspose.Slides for PHP via Java:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $tags = $presentation->getCustomData()->getTags();
    $tags->set_Item("MyTag", "My Tag Value");
} finally {
    $presentation->dispose();
}
```

Tags kunnen ook worden ingesteld voor een [Slide](https://reference.aspose.com/slides/nl/php-java/aspose.slides/slide/):

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $slide->getCustomData()->getTags()->set_Item("tag", "value");
} finally {
    $presentation->dispose();
}
```

Of voor een individuele [Shape](https://reference.aspose.com/slides/nl/php-java/aspose.slides/autoshape/):

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 100, 50);
    $shape->getTextFrame()->setText("My text");
    $shape->getCustomData()->getTags()->set_Item("tag", "value");
} finally {
    $presentation->dispose();
}
```

### **Beperkingen**

Tags die via de `getCustomData()->getTags()`‑collectie worden toegevoegd, worden alleen in het PowerPoint‑bestand opgeslagen. Ze worden **niet** overgebracht naar de PDF‑tagstructuur wanneer de presentatie naar PDF wordt geëxporteerd. Daardoor kan een aangepaste identifier die als tag is toegewezen niet worden opgehaald uit de getagde PDF.

**Work‑around**: U kunt een aangepaste identifier opslaan in de **Alt‑tekst** van het object (bijvoorbeeld `$shape->setAlternativeText("MyId")`). Na export naar PDF kan de Alt‑tekst in de PDF‑tagstructuur verschijnen.

## **FAQ**

**Kan ik alle tags in één keer verwijderen uit een presentatie, dia of vorm?**

Ja. De [tag‑collectie](https://reference.aspose.com/slides/nl/php-java/aspose.slides/tagcollection/) ondersteunt een [clear](https://reference.aspose.com/slides/nl/php-java/aspose.slides/tagcollection/#clear)‑bewerking die alle sleutel‑waardeparen in één keer verwijdert.

**Hoe verwijder ik één tag op naam zonder de hele collectie te doorlopen?**

Gebruik [remove(name)](https://reference.aspose.com/slides/nl/php-java/aspose.slides/tagcollection/#remove) op de [tag‑collectie](https://reference.aspose.com/slides/nl/php-java/aspose.slides/tagcollection/) om de tag op zijn sleutel te verwijderen.

**Hoe kan ik de volledige lijst met tagnamen ophalen voor analyse of filtering?**

Gebruik [getNamesOfTags](https://reference.aspose.com/slides/nl/php-java/aspose.slides/tagcollection/#getNamesOfTags) op de [tag‑collectie](https://reference.aspose.com/slides/nl/php-java/aspose.slides/tagcollection/); dit geeft een array met alle tagnamen terug.

**Hoe vind ik alle aangepaste XML‑onderdelen, ongeacht waar ze zijn opgeslagen?**

Gebruik [`Presentation::getAllCustomXmlParts()`](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/#getAllCustomXmlParts) om alle aangepaste XML‑onderdelen in de presentatie op te halen.

**Moet ik `getXmlAsString`/`setXmlAsString` of `getXmlData`/`setXmlData` gebruiken om een aangepast XML‑onderdeel bij te werken?**

Gebruik `getXmlAsString` en `setXmlAsString` wanneer de applicatie werkt met UTF‑8 XML‑tekst. Gebruik `getXmlData` en `setXmlData` wanneer de XML al beschikbaar is als byte‑array of wanneer binaire verwerking handiger is. Beide representaties verwijzen naar dezelfde XML‑inhoud van het aangepaste XML‑onderdeel.
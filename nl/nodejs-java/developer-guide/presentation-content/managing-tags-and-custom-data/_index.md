---
title: Beheer tags en aangepaste gegevens in presentaties met JavaScript
linktitle: Tags en aangepaste gegevens
type: docs
weight: 300
url: /nl/nodejs-java/managing-tags-and-custom-data/
keywords:
- documenteigenschappen
- tag
- aangepaste gegevens
- aangepaste XML
- aangepast XML-onderdeel
- XML-metadata
- ItemId
- tag toevoegen
- paarwaarden
- PowerPoint
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Leer hoe u tags en aangepaste XML-gegevens in PowerPoint-presentaties beheert met Aspose.Slides voor Node.js via Java, inclusief het toevoegen, lezen, bijwerken, auditen en verwijderen van aangepaste XML-onderdelen."
---
## **Overzicht**

Dit artikel legt uit hoe Aspose.Slides werkt met tags en aangepaste gegevens in PowerPoint‑presentaties. Presentatiespecifieke gegevens kunnen worden opgeslagen als tags of aangepaste XML‑onderdelen. Tags zijn eenvoudige sleutel‑waarde tekenreeksparen, terwijl aangepaste XML‑onderdelen gestructureerde metadata en toepassingsspecifieke XML‑payloads kunnen opslaan.

Aspose.Slides biedt API’s voor het toevoegen, lezen, bijwerken, auditen en verwijderen van aangepaste XML‑onderdelen op presentatie‑, dia‑ en vorm‑niveau. Aangepaste XML‑onderdelen zijn nuttig voor integraties die informatie opslaan zoals document‑beheer‑identifiers, workflow‑status, compliance‑metadata, template‑binding‑gegevens of andere gestructureerde toepassingsgegevens binnen een presentatie.

## **Gegevensopslag in presentatiedocumenten**

PPTX‑bestanden—bestanden met de extensie `.pptx`—worden opgeslagen in het PresentationML‑formaat, dat deel uitmaakt van de Office Open XML‑specificatie. Office Open XML definieert de pakketstructuur en relaties die worden gebruikt om presentatie‑inhoud en gerelateerde gegevens op te slaan.

Een presentatie bevat meerdere onderdelen die met relaties verbonden zijn. Bijvoorbeeld, een dia‑onderdeel bevat de inhoud van één enkele dia en kan expliciete relaties hebben met andere onderdelen, gedefinieerd door ISO/IEC 29500.

Aangepaste gegevens kunnen worden opgeslagen als tags ([TagCollection](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/tagcollection/)) of als aangepaste XML‑onderdelen ([CustomXmlPartCollection](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/customxmlpartcollection/)). Beide zijn beschikbaar via de klasse [`CustomData`](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/customdata/).

{{% alert color="primary" %}}
Tags slaan eenvoudige tekenreeks sleutel‑waardeparen op. Aangepaste XML‑onderdelen slaan gestructureerde XML‑gegevens op en kunnen worden gekoppeld aan een presentatie, dia of vorm.
{{% /alert %}}

## **Werken met aangepaste XML‑onderdelen**

De methode `getCustomXmlParts()` van [`CustomData`](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/customdata/) retourneert de collectie van aangepaste XML‑onderdelen die gekoppeld zijn aan een specifiek presentatiesobject. Bijvoorbeeld:

- `presentation.getCustomData().getCustomXmlParts()` bevat de aangepaste XML‑onderdelen die bij de presentatie zelf horen.
- `slide.getCustomData().getCustomXmlParts()` bevat de aangepaste XML‑onderdelen die bij een specifieke dia horen.
- `shape.getCustomData().getCustomXmlParts()` bevat de aangepaste XML‑onderdelen die bij een specifieke vorm horen.

Gebruik [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/) wanneer u alle aangepaste XML‑onderdelen in de presentatie moet inspecteren, ongeacht waar ze gekoppeld zijn.

### **Een aangepast XML‑onderdeel toevoegen aan een presentatie**

Gebruik de `add`‑methode van [`CustomXmlPartCollection`](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/customxmlpartcollection/) om XML‑gegevens toe te voegen aan een collectie van aangepaste XML‑onderdelen. De XML moet geldig en niet‑leeg zijn.

Het volgende voorbeeld voegt gestructureerde metadata toe aan de aangepaste gegevenscollectie op presentatie‑niveau:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const customXmlContent =
    '<?xml version="1.0" encoding="UTF-8"?>' +
    '<metadata xmlns="urn:example:metadata">' +
        '<documentId>DOC-1001</documentId>' +
        '<workflowState>Draft</workflowState>' +
    '</metadata>';

const presentation = new aspose.slides.Presentation();
try {
    const customXmlPart = presentation.getCustomData().getCustomXmlParts().add(customXmlContent);

    // add wijst automatisch een identifier toe. Stel een specifieke UUID alleen in wanneer dat vereist is.
    const itemId = java.callStaticMethodSync("java.util.UUID", "randomUUID");
    customXmlPart.setItemId(itemId);

    presentation.save("presentation_with_custom_xml.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

De `add`‑methode kan ook XML als byte‑array accepteren, wat handig is wanneer de XML‑inhoud al in binaire vorm beschikbaar is.

### **Een aangepast XML‑onderdeel toevoegen aan een dia of vorm**

Aangepaste XML‑gegevens kunnen worden gekoppeld aan een specifieke dia of vorm in plaats van aan de volledige presentatie. Dit is handig wanneer metadata slechts één object beschrijft, zoals een sjabloonsleutel, een externe record‑identificator of bindingsinformatie.

Het volgende voorbeeld voegt één aangepast XML‑onderdeel toe aan een dia en een ander aan een vorm:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    slide.getCustomData().getCustomXmlParts().add(
        '<slideMetadata xmlns="urn:example:slides">' +
            '<templateKey>TitleSlide</templateKey>' +
        '</slideMetadata>');

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 250, 80);

    shape.getTextFrame().setText("Customer data");
    shape.getCustomData().getCustomXmlParts().add(
        '<shapeMetadata xmlns="urn:example:shapes">' +
            '<recordId>CRM-4281</recordId>' +
        '</shapeMetadata>');

    presentation.save("object_custom_xml.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Het niveau waarop een onderdeel wordt toegevoegd bepaalt welke object‑`getCustomData().getCustomXmlParts()`‑collectie de relatie naar dat onderdeel bevat. Gegevens op presentatieniveau zijn geschikt voor metadata die het hele document bestrijkt, gegevens op dia‑niveau voor informatie die bij een specifieke dia hoort, en gegevens op vorm‑niveau voor metadata die gekoppeld is aan een individuele vorm.

### **Alle aangepaste XML‑onderdelen opsommen en auditen**

Gebruik [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/) om alle aangepaste XML‑onderdelen uit een presentatie op te halen. Elk [`CustomXmlPart`](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/customxmlpart/) geeft zijn identifier, XML‑inhoud en gekoppelde namespace‑schema’s weer.

Het volgende voorbeeld somt alle aangepaste XML‑onderdelen en hun namespace‑schema’s op:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const customXmlParts = presentation.getAllCustomXmlParts();

    for (let partIndex = 0; partIndex < customXmlParts.length; partIndex++) {
        const customXmlPart = customXmlParts[partIndex];

        console.log("ItemId: " + customXmlPart.getItemId());
        console.log("XML:");
        console.log(customXmlPart.getXmlAsString());

        const namespaceSchemas = customXmlPart.getNamespaceSchemas();
        for (let schemaIndex = 0; schemaIndex < namespaceSchemas.length; schemaIndex++) {
            console.log("Namespace schema: " + namespaceSchemas[schemaIndex]);
        }

        console.log();
    }
} finally {
    presentation.dispose();
}
```

`CustomXmlPart.getNamespaceSchemas()` retourneert de XML‑schema’s die gekoppeld zijn aan het aangepaste XML‑onderdeel. Deze informatie kan nuttig zijn bij het auditen van presentaties die XML bevatten die is geproduceerd door externe systemen.

### **XML‑inhoud en ItemId lezen en bijwerken**

Gebruik `getXmlAsString()` en `setXmlAsString()` van [`CustomXmlPart`](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/customxmlpart/) om met XML als UTF‑8‑tekenreeks te werken, of `getXmlData()` en `setXmlData()` om met de ruwe XML‑bytes te werken.

De methode `getItemId()` retourneert de UUID die het aangepaste XML‑onderdeel identificeert in het Office Open XML‑document. Gebruik `setItemId()` wanneer een integratie een nieuwe identifier vereist.

Het volgende voorbeeld werkt de XML‑inhoud en de identifier bij:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const customXmlPart = presentation.getAllCustomXmlParts()[0];

    // Lees de huidige XML als tekst.
    const currentXmlContent = customXmlPart.getXmlAsString();
    console.log(currentXmlContent);

    // Werk de XML bij als een UTF-8 tekenreeks.
    customXmlPart.setXmlAsString(
        '<metadata xmlns="urn:example:metadata">' +
            '<documentId>DOC-1001</documentId>' +
            '<workflowState>Approved</workflowState>' +
        '</metadata>');

    // getXmlData levert dezelfde XML inhoud als ruwe bytes.
    const customXmlData = customXmlPart.getXmlData();
    console.log(Buffer.from(customXmlData).toString("utf8"));

    // Vervang de identifier wanneer dat vereist is door de integratie.
    const itemId = java.callStaticMethodSync("java.util.UUID", "randomUUID");
    customXmlPart.setItemId(itemId);

    presentation.save("updated_custom_xml.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Bij het aanroepen van `setXmlAsString` of `setXmlData` moet geldige, niet‑lege XML worden meegegeven. Gebruik de ene of de andere representatie afhankelijk van of de applicatie voornamelijk met tekenreeksen of met byte‑data werkt.

### **Een aangepast XML‑onderdeel verwijderen**

Aspose.Slides biedt verschillende manieren om aangepaste XML‑gegevens te verwijderen:

- [`CustomXmlPart.remove`](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/customxmlpart/) verwijdert het aangepaste XML‑onderdeel uit de presentatie.
- [`CustomXmlPartCollection.remove`](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/customxmlpartcollection/) verwijdert een specifiek onderdeel uit een collectie van aangepaste XML‑onderdelen.
- [`CustomXmlPartCollection.removeAt`](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/customxmlpartcollection/) verwijdert het onderdeel op een opgegeven index in de collectie.
- [`CustomXmlPartCollection.clear`](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/customxmlpartcollection/) verwijdert alle onderdelen uit een specifieke collectie.

Het volgende voorbeeld verwijdert één aangepast XML‑onderdeel op presentatieniveau via referentie:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const customXmlParts = presentation.getCustomData().getCustomXmlParts();

    if (customXmlParts.size() > 0) {
        const customXmlPart = customXmlParts.get_Item(0);
        customXmlParts.remove(customXmlPart);
    }

    presentation.save("custom_xml_removed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Als u al een `CustomXmlPart` heeft en dat onderdeel uit de presentatie wilt verwijderen in plaats van een specifieke collectie aan te spreken, roep dan `customXmlPart.remove()` aan.

U kunt ook een item op index verwijderen:

```javascript
presentation.getCustomData().getCustomXmlParts().removeAt(0);
```

### **Alle aangepaste XML‑onderdelen uit een collectie wissen**

Gebruik `clear` wanneer alle aangepaste XML‑onderdelen die gekoppeld zijn aan een specifiek presentatiesobject verwijderd moeten worden.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    presentation.getSlides().get_Item(0).getCustomData().getCustomXmlParts().clear();

    presentation.save("slide_custom_xml_cleared.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`clear` beïnvloedt alleen de geselecteerde collectie. Bijvoorbeeld, het wissen van de collectie van een dia wist niet de collecties op presentatie‑ of vorm‑niveau.

Om elk aangepast XML‑onderdeel in de presentatie te verwijderen, doorloop `getAllCustomXmlParts()` en verwijder elk onderdeel:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const customXmlParts = presentation.getAllCustomXmlParts();

    for (let partIndex = 0; partIndex < customXmlParts.length; partIndex++) {
        customXmlParts[partIndex].remove();
    }

    presentation.save("all_custom_xml_removed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Gelinkte of gedeelde aangepaste XML‑onderdelen behandelen**

In een Office Open XML‑presentatie kan hetzelfde aangepaste XML‑onderdeel door meer dan één presentatiesobject worden gerefereerd. Bijvoorbeeld, een bestaand bestand kan relaties bevatten van meerdere dia’s of vormen naar hetzelfde onderliggende aangepaste XML‑onderdeel.

Een gedeeld onderdeel moet worden behandeld als één gegevensobject met meerdere verwijzingen:

- Het bijwerken ervan met `setXmlAsString`, `setXmlData` of `setItemId` wijzigt het onderliggende aangepaste XML‑onderdeel, waardoor de wijziging overal waar dat onderdeel wordt gerefereerd van kracht is.
- `getItemId()` kan worden gebruikt om hetzelfde aangepaste XML‑onderdeel te identificeren tijdens het auditen van collecties op object‑niveau.
- Het verwijderen van een onderdeel uit een specifieke `getCustomXmlParts()`‑collectie verwijdert het uit die collectie. Gebruik `CustomXmlPart.remove()` wanneer het onderdeel zelf uit de presentatie moet worden verwijderd.
- Voordat u een gedeeld onderdeel verwijdert of vervangt, inspecteer de collecties op object‑niveau om te bepalen of andere dia’s of vormen het nog steeds refereren.

De `add`‑overloads maken een nieuw aangepast XML‑onderdeel aan vanuit XML‑inhoud; ze accepteren geen bestaand `CustomXmlPart`. Daarom komen gedeelde relaties meestal voor bij het laden van presentaties die deze al bevatten.

Het volgende voorbeeld auditeert collecties op presentatie‑, dia‑ en vorm‑niveau op basis van `ItemId` en rapporteert onderdelen die vanaf meer dan één plaats worden gerefereerd:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const referencesByItemId = new Map();

    const registerCustomXmlParts = (ownerName, customXmlParts) => {
        for (let partIndex = 0; partIndex < customXmlParts.size(); partIndex++) {
            const customXmlPart = customXmlParts.get_Item(partIndex);
            const itemId = customXmlPart.getItemId().toString();

            if (!referencesByItemId.has(itemId)) {
                referencesByItemId.set(itemId, []);
            }

            referencesByItemId.get(itemId).push(ownerName);
        }
    };

    registerCustomXmlParts("Presentation", presentation.getCustomData().getCustomXmlParts());

    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);

        registerCustomXmlParts("Slide " + (slideIndex + 1), slide.getCustomData().getCustomXmlParts());

        for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);

            registerCustomXmlParts("Slide " + (slideIndex + 1) + ", shape " + shapeIndex, shape.getCustomData().getCustomXmlParts());
        }
    }

    for (const [itemId, owners] of referencesByItemId) {
        if (owners.length > 1) {
            console.log("Shared custom XML part: " + itemId);

            for (const ownerName of owners) {
                console.log("  Referenced by: " + ownerName);
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Dit type audit is nuttig voordat u aangepaste XML‑gegevens wijzigt of verwijdert in presentaties die door externe systemen zijn aangemaakt, omdat hetzelfde metadata‑onderdeel kan deelnemen aan meer dan één relatie.

## **Waarden van tags ophalen**

In Slides correspondeert een tag met de methode `DocumentProperties.getKeywords()`. Deze voorbeeldcode laat zien hoe u een tag‑waarde kunt ophalen met Aspose.Slides voor Node.js via Java voor [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/):

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const keywords = presentation.getDocumentProperties().getKeywords();
} finally {
    presentation.dispose();
}
```

## **Tags toevoegen aan presentaties**

Aspose.Slides stelt u in staat om tags toe te voegen aan presentaties. Een tag bestaat doorgaans uit twee elementen:

- de naam van een aangepaste eigenschap, bijvoorbeeld `MyTag`;
- de waarde van de aangepaste eigenschap, bijvoorbeeld `My Tag Value`.

Als u presentaties wilt classificeren op basis van een specifieke regel of eigenschap, kunt u tags hiervoor toevoegen. Bijvoorbeeld, als u presentaties uit Noord‑Amerikaanse landen wilt categoriseren, kunt u een Noord‑Amerikaanse tag aanmaken en het betreffende land als waarde toewijzen.

Deze voorbeeldcode toont hoe u een tag toevoegt aan een [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/):

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const tags = presentation.getCustomData().getTags();
    tags.set_Item("MyTag", "My Tag Value");
} finally {
    presentation.dispose();
}
```

Tags kunnen ook worden ingesteld voor een [Slide](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/slide/):

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    slide.getCustomData().getTags().set_Item("tag", "value");
} finally {
    presentation.dispose();
}
```

Of voor een individuele [Shape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/autoshape/):

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 50);

    shape.getTextFrame().setText("My text");
    shape.getCustomData().getTags().set_Item("tag", "value");
} finally {
    presentation.dispose();
}
```

### **Beperkingen**

Tags die via de collectie `getCustomData().getTags()` worden toegevoegd, worden alleen in het PowerPoint‑bestand opgeslagen. Ze worden **niet** overgebracht naar de PDF‑tagstructuur wanneer de presentatie wordt geëxporteerd naar PDF. Daardoor kan een aangepaste identifier die als tag is toegewezen niet worden opgehaald uit de getagde PDF.

**Workaround**: U kunt een aangepaste identifier opslaan in de **Alt‑tekst** van het object (bijvoorbeeld `shape.setAlternativeText("MyId")`). Na export naar PDF kan de Alt‑tekst verschijnen in de PDF‑tagstructuur.

## **Veelgestelde vragen**

**Kan ik alle tags uit een presentatie, dia of vorm in één bewerking verwijderen?**

Ja. De [tag‑collectie](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/tagcollection/) ondersteunt een [clear](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/tagcollection/)‑bewerking die alle sleutel‑waardeparen in één keer verwijdert.

**Hoe kan ik een enkele tag op naam verwijderen zonder door de hele collectie te itereren?**

Gebruik `remove(name)` op de [tag‑collectie](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/tagcollection/) om de tag op sleutel te verwijderen.

**Hoe kan ik de volledige lijst van tagnamen ophalen voor analyse of filtering?**

Gebruik `getNamesOfTags()` op de [tag‑collectie](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/tagcollection/); dit retourneert een array met alle tagnamen.

**Hoe kan ik alle aangepaste XML‑onderdelen vinden, ongeacht waar ze zijn opgeslagen?**

Gebruik [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/) om alle aangepaste XML‑onderdelen in de presentatie op te halen.

**Moet ik `getXmlAsString`/`setXmlAsString` of `getXmlData`/`setXmlData` gebruiken om een aangepast XML‑onderdeel bij te werken?**

Gebruik `getXmlAsString` en `setXmlAsString` wanneer de applicatie werkt met UTF‑8‑XML‑tekst. Gebruik `getXmlData` en `setXmlData` wanneer de XML al beschikbaar is als byte‑array of wanneer binaire verwerking handiger is. Beide representaties verwijzen naar de XML‑inhoud van hetzelfde aangepaste XML‑onderdeel.
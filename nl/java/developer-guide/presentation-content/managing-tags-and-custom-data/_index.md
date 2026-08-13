---
title: Beheer tags en aangepaste data in presentaties met Java
linktitle: Tags en aangepaste data
type: docs
weight: 300
url: /nl/java/managing-tags-and-custom-data/
keywords:
- documenteigenschappen
- tag
- aangepaste gegevens
- aangepaste XML
- aangepast XML-onderdeel
- XML-metadata
- ItemId
- tag toevoegen
- waardenparen
- PowerPoint
- presentatie
- Java
- Aspose.Slides
description: "Leer hoe u tags en aangepaste XML-gegevens in PowerPoint-presentaties kunt beheren met Aspose.Slides voor Java, inclusief het toevoegen, lezen, bijwerken, auditen en verwijderen van aangepaste XML-onderdelen."
---
## **Overzicht**

Dit artikel legt uit hoe Aspose.Slides werkt met tags en aangepaste gegevens in PowerPoint‑presentaties. Presentatiespecifieke gegevens kunnen worden opgeslagen als tags of als aangepaste XML‑onderdelen. Tags zijn eenvoudige sleutel‑waarde‑tekenreeksparen, terwijl aangepaste XML‑onderdelen gestructureerde metadata en toepassingsspecifieke XML‑payloads kunnen opslaan.

## **Gegevensopslag in presentatiebestanden**

PPTX‑bestanden—bestanden met de extensie `.pptx`—worden opgeslagen in het PresentationML‑formaat, dat deel uitmaakt van de Office Open XML‑specificatie. Office Open XML definieert de pakketsstructuur en relaties die worden gebruikt om presentatiew inhoud en gerelateerde gegevens op te slaan.

Een presentatie bevat meerdere onderdelen die via relaties met elkaar verbonden zijn. Bijvoorbeeld bevat een slide‑onderdeel de inhoud van één dia en kan expliciete relaties hebben met andere onderdelen zoals gedefinieerd in ISO/IEC 29500.

Aangepaste gegevens kunnen worden opgeslagen als tags ([ITagCollection](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ITagCollection)) of als aangepaste XML‑onderdelen ([ICustomXmlPartCollection](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ICustomXmlPartCollection)). Beide zijn beschikbaar via de [`ICustomData`](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ICustomData/) interface.

{{% alert color="info" %}}
Tags slaan eenvoudige tekenreeks‑sleutel‑waarde‑paren op. Aangepaste XML‑onderdelen slaan gestructureerde XML‑gegevens op en kunnen aan een presentatie, dia of vorm worden gekoppeld.
{{% /alert %}}

## **Werken met aangepaste XML‑onderdelen**

De methode [`ICustomData.getCustomXmlParts()`](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ICustomData#getCustomXmlParts--) retourneert de collectie van aangepaste XML‑onderdelen die gekoppeld zijn aan een bepaald presentatie‑object. Bijvoorbeeld:

- `presentation.getCustomData().getCustomXmlParts()` bevat de aangepaste XML‑onderdelen die aan de presentatie zelf gekoppeld zijn.
- `slide.getCustomData().getCustomXmlParts()` bevat de aangepaste XML‑onderdelen die aan een specifieke dia gekoppeld zijn.
- `shape.getCustomData().getCustomXmlParts()` bevat de aangepaste XML‑onderdelen die aan een specifieke vorm gekoppeld zijn.

Gebruik [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Presentation#getAllCustomXmlParts--) wanneer je alle aangepaste XML‑onderdelen in de presentatie wilt inspecteren, ongeacht waar ze zijn gekoppeld.

### **Een aangepast XML‑onderdeel toevoegen aan een presentatie**

Gebruik [`ICustomXmlPartCollection.add`](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ICustomXmlPartCollection#add-java.lang.String-) om XML‑gegevens toe te voegen aan een collectie van aangepaste XML‑onderdelen. De XML moet geldig en niet‑leeg zijn.

Het volgende voorbeeld voegt gestructureerde metadata toe aan de presentatieniveau‑custom‑data‑collectie:

```java
import com.aspose.slides.*;
import java.util.UUID;

String customXmlContent =
    "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
    "<metadata xmlns=\"urn:example:metadata\">" +
        "<documentId>DOC-1001</documentId>" +
        "<workflowState>Draft</workflowState>" +
    "</metadata>";

Presentation presentation = new Presentation();
try {
    ICustomXmlPart customXmlPart = presentation.getCustomData().getCustomXmlParts().add(customXmlContent);

    // add wijst automatisch een identifier toe. Stel een specifieke UUID alleen in wanneer nodig.
    customXmlPart.setItemId(UUID.randomUUID());

    presentation.save("presentation_with_custom_xml.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

De `add`‑methode kan ook XML accepteren als byte‑array of input‑stream, wat handig is wanneer XML‑inhoud al beschikbaar is in binaire vorm.

### **Een aangepast XML‑onderdeel toevoegen aan een dia of vorm**

Aangepaste XML‑gegevens kunnen worden gekoppeld aan een specifieke dia of vorm in plaats van aan de volledige presentatie. Dit is nuttig wanneer metadata slechts één object beschrijft, zoals een sjabloonsleutel, externe record‑identificatie of bind‑informatie.

Het volgende voorbeeld voegt één aangepast XML‑onderdeel toe aan een dia en een ander aan een vorm:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    slide.getCustomData().getCustomXmlParts().add(
        "<slideMetadata xmlns=\"urn:example:slides\">" +
            "<templateKey>TitleSlide</templateKey>" +
        "</slideMetadata>");

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 250, 80);

    shape.getTextFrame().setText("Customer data");
    shape.getCustomData().getCustomXmlParts().add(
        "<shapeMetadata xmlns=\"urn:example:shapes\">" +
            "<recordId>CRM-4281</recordId>" +
        "</shapeMetadata>");

    presentation.save("object_custom_xml.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Het niveau waarop een onderdeel wordt toegevoegd bepaalt welke `getCustomData().getCustomXmlParts()`‑collectie van welk object de relatie naar dat onderdeel bevat. Presentatieniveau‑gegevens zijn geschikt voor document‑brede metadata, dia‑niveau‑gegevens voor informatie die bij een bepaalde dia hoort, en vorm‑niveau‑gegevens voor metadata die aan een individuele vorm zijn gekoppeld.

### **Alle aangepaste XML‑onderdelen opsommen en auditen**

Gebruik [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Presentation#getAllCustomXmlParts--) om alle aangepaste XML‑onderdelen uit een presentatie op te halen. Elk [`ICustomXmlPart`](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ICustomXmlPart/) geeft zijn identifier, XML‑inhoud en gekoppelde namespace‑schema’s weer.

Het volgende voorbeeld somt alle aangepaste XML‑onderdelen en hun namespace‑schema’s op:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    for (ICustomXmlPart customXmlPart : presentation.getAllCustomXmlParts()) {
        System.out.println("ItemId: " + customXmlPart.getItemId());
        System.out.println("XML:");
        System.out.println(customXmlPart.getXmlAsString());

        for (String namespaceSchema : customXmlPart.getNamespaceSchemas()) {
            System.out.println("Namespace schema: " + namespaceSchema);
        }

        System.out.println();
    }
} finally {
    presentation.dispose();
}
```

[`ICustomXmlPart.getNamespaceSchemas()`](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ICustomXmlPart#getNamespaceSchemas--) retourneert de XML‑schema’s die aan het aangepaste XML‑onderdeel gekoppeld zijn. Deze informatie kan nuttig zijn bij het auditen van presentaties die XML bevatten die door externe systemen is geproduceerd.

### **XML‑inhoud en ItemId lezen en bijwerken**

Gebruik [`ICustomXmlPart.getXmlAsString()`](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ICustomXmlPart#getXmlAsString--) en [`setXmlAsString()`](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ICustomXmlPart#setXmlAsString-java.lang.String-) om met XML te werken als een UTF‑8‑tekenreeks, of [`getXmlData()`](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ICustomXmlPart#getXmlData--) en [`setXmlData()`](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ICustomXmlPart#setXmlData-byte:A-) om met de ruwe XML‑bytes te werken.

De methode [`ICustomXmlPart.getItemId()`](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ICustomXmlPart#getItemId--) retourneert de UUID die het aangepaste XML‑onderdeel identificeert in het Office Open XML‑document. Gebruik [`setItemId()`](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ICustomXmlPart#setItemId-java.util.UUID-) wanneer een integratie een nieuwe identifier vereist.

Het volgende voorbeeld werkt de XML‑inhoud en de identifier bij:

```java
import com.aspose.slides.*;
import java.nio.charset.StandardCharsets;
import java.util.UUID;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ICustomXmlPart customXmlPart = presentation.getAllCustomXmlParts()[0];

    // Lees de huidige XML als tekst.
    String currentXmlContent = customXmlPart.getXmlAsString();
    System.out.println(currentXmlContent);

    // Werk de XML bij als een UTF-8-tekenreeks.
    customXmlPart.setXmlAsString(
        "<metadata xmlns=\"urn:example:metadata\">" +
            "<documentId>DOC-1001</documentId>" +
            "<workflowState>Approved</workflowState>" +
        "</metadata>");

    // getXmlData levert dezelfde XML-inhoud als ruwe bytes.
    byte[] customXmlData = customXmlPart.getXmlData();
    System.out.println(new String(customXmlData, StandardCharsets.UTF_8));

    // Vervang de identifier wanneer vereist door de integratie.
    customXmlPart.setItemId(UUID.randomUUID());

    presentation.save("updated_custom_xml.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Bij het aanroepen van `setXmlAsString` of `setXmlData` moet je geldige, niet‑lege XML leveren. Gebruik de ene of de andere representatie afhankelijk van of de applicatie voornamelijk met tekenreeksen of met byte‑data werkt.

### **Een aangepast XML‑onderdeel verwijderen**

Aspose.Slides biedt verschillende manieren om aangepaste XML‑gegevens te verwijderen:

- [`ICustomXmlPart.remove`](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ICustomXmlPart#remove--) verwijdert het aangepaste XML‑onderdeel uit de presentatie.
- [`ICustomXmlPartCollection.remove`](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ICustomXmlPartCollection#remove-com.aspose.slides.ICustomXmlPart-) verwijdert een specifiek onderdeel uit een collectie van aangepaste XML‑onderdelen.
- [`ICustomXmlPartCollection.removeAt`](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ICustomXmlPartCollection#removeAt-int--) verwijdert het onderdeel op een opgegeven collectie‑index.
- [`ICustomXmlPartCollection.clear`](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ICustomXmlPartCollection#clear--) verwijdert alle onderdelen uit een specifieke collectie.

Het volgende voorbeeld verwijdert één presentatieniveau‑custom‑XML‑onderdeel op referentie:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ICustomXmlPartCollection customXmlParts = presentation.getCustomData().getCustomXmlParts();

    if (customXmlParts.size() > 0) {
        ICustomXmlPart customXmlPart = customXmlParts.get_Item(0);
        customXmlParts.remove(customXmlPart);
    }

    presentation.save("custom_xml_removed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Als je al een `ICustomXmlPart` hebt en dat onderdeel uit de presentatie wilt verwijderen in plaats van een specifieke collectie aan te spreken, roep dan `customXmlPart.remove()` aan.

Je kunt ook een item op index verwijderen:

```java
presentation.getCustomData().getCustomXmlParts().removeAt(0);
```

### **Alle aangepaste XML‑onderdelen uit een collectie wissen**

Gebruik `clear` wanneer alle aangepaste XML‑onderdelen die aan een bepaald presentatieniveau‑object gekoppeld zijn, verwijderd moeten worden.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.getSlides().get_Item(0).getCustomData().getCustomXmlParts().clear();

    presentation.save("slide_custom_xml_cleared.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`clear` heeft alleen effect op de geselecteerde collectie. Het wissen van de collectie van een dia wist bijvoorbeeld niet de presentatieniveau‑ of vorm‑niveau‑collecties.

Om elk aangepast XML‑onderdeel in de presentatie te verwijderen, kun je door `getAllCustomXmlParts()` itereren en elk onderdeel verwijderen:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    for (ICustomXmlPart customXmlPart : presentation.getAllCustomXmlParts()) {
        customXmlPart.remove();
    }

    presentation.save("all_custom_xml_removed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Gekoppelde of gedeelde aangepaste XML‑onderdelen verwerken**

In een Office Open XML‑presentatie kan hetzelfde aangepaste XML‑onderdeel door meer dan één presentatie‑object worden gerefereerd. Bijvoorbeeld kan een bestaand bestand relaties bevatten van meerdere dia’s of vormen naar hetzelfde onderliggende aangepaste XML‑onderdeel.

Een gedeeld onderdeel moet worden behandeld als één data‑object met meerdere verwijzingen:

- Bijwerken met `setXmlAsString`, `setXmlData` of `setItemId` wijzigt het onderliggende aangepaste XML‑onderdeel, zodat de wijziging overal waar het onderdeel wordt gerefereerd van kracht is.
- `getItemId()` kan worden gebruikt om hetzelfde aangepaste XML‑onderdeel te identificeren tijdens het auditen van object‑niveau‑collecties.
- Het verwijderen van een onderdeel uit een specifieke `getCustomXmlParts()`‑collectie verwijdert het alleen uit die collectie. Gebruik `ICustomXmlPart.remove()` wanneer het onderdeel zelf uit de presentatie moet verdwijnen.
- Controleer vóór het verwijderen of vervangen van een gedeeld onderdeel de object‑niveau‑collecties om te bepalen of andere dia’s of vormen het nog refereren.

De `add`‑overloads maken een nieuw aangepast XML‑onderdeel aan vanuit XML‑inhoud; ze accepteren geen bestaand `ICustomXmlPart`. Daarom komen gedeelde relaties het vaakst voor bij het laden van presentaties die ze al bevatten.

Het volgende voorbeeld audit de presentatieniveau‑, dia‑ en vorm‑collecties op `ItemId` en rapporteert onderdelen die vanaf meer dan één plaats worden gerefereerd:

```java
import com.aspose.slides.*;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.UUID;
import java.util.function.BiConsumer;

Presentation presentation = new Presentation("presentation.pptx");
try {
    Map<UUID, List<String>> referencesByItemId = new HashMap<>();

    BiConsumer<String, ICustomXmlPartCollection> registerCustomXmlParts =
        (ownerName, customXmlParts) -> {
            for (int i = 0; i < customXmlParts.size(); i++) {
                ICustomXmlPart customXmlPart = customXmlParts.get_Item(i);
                UUID itemId = customXmlPart.getItemId();

                if (!referencesByItemId.containsKey(itemId)) {
                    referencesByItemId.put(itemId, new ArrayList<>());
                }

                referencesByItemId.get(itemId).add(ownerName);
            }
        };

    registerCustomXmlParts.accept("Presentation", presentation.getCustomData().getCustomXmlParts());

    for (int slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        ISlide slide = presentation.getSlides().get_Item(slideIndex);
        registerCustomXmlParts.accept("Slide " + (slideIndex + 1), slide.getCustomData().getCustomXmlParts());

        for (int shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            IShape shape = slide.getShapes().get_Item(shapeIndex);
            registerCustomXmlParts.accept("Slide " + (slideIndex + 1) + ", shape " + shapeIndex, shape.getCustomData().getCustomXmlParts());
        }
    }

    for (Map.Entry<UUID, List<String>> referenceEntry : referencesByItemId.entrySet()) {
        if (referenceEntry.getValue().size() > 1) {
            System.out.println("Shared custom XML part: " + referenceEntry.getKey());

            for (String ownerName : referenceEntry.getValue()) {
                System.out.println("  Referenced by: " + ownerName);
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Dit type audit is nuttig vóór het wijzigen of verwijderen van aangepaste XML‑gegevens in presentaties die door externe systemen zijn aangemaakt, omdat hetzelfde metadata‑onderdeel in meer dan één relatie kan deelnemen.

## **Waarden van tags ophalen**

In Slides correspondeert een tag aan de methode `IDocumentProperties.getKeywords()`. Deze voorbeeldcode laat zien hoe je een tagwaarde kunt ophalen met Aspose.Slides voor Java voor [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Presentation):

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    String keywords = presentation.getDocumentProperties().getKeywords();
} finally {
    presentation.dispose();
}
```

## **Tags toevoegen aan presentaties**

Aspose.Slides stelt je in staat tags aan presentaties toe te voegen. Een tag bestaat doorgaans uit twee onderdelen:

- de naam van een aangepaste eigenschap, bijvoorbeeld `MyTag`;
- de waarde van de aangepaste eigenschap, bijvoorbeeld `My Tag Value`.

Wanneer je presentaties wilt classificeren op basis van een specifieke regel of eigenschap, kun je tags hiervoor toevoegen. Bijvoorbeeld, als je presentaties uit Noord‑Amerikaanse landen wilt categoriseren, kun je een Noord‑Amerikaanse tag aanmaken en het relevante land als waarde toewijzen.

Deze voorbeeldcode laat zien hoe je een tag toevoegt aan een [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Presentation) met Aspose.Slides voor Java:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ITagCollection tags = presentation.getCustomData().getTags();
    tags.set_Item("MyTag", "My Tag Value");
} finally {
    presentation.dispose();
}
```

Tags kunnen ook worden ingesteld voor een [Slide](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ISlide):

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    slide.getCustomData().getTags().set_Item("tag", "value");
} finally {
    presentation.dispose();
}
```

Of voor een individuele [Shape](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IAutoShape):

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 50);
    shape.getTextFrame().setText("My text");
    shape.getCustomData().getTags().set_Item("tag", "value");
} finally {
    presentation.dispose();
}
```

### **Beperkingen**

Tags die via de `getCustomData().getTags()`‑collectie worden toegevoegd, worden alleen in het PowerPoint‑bestand opgeslagen. Ze worden **niet** overgebracht naar de PDF‑tagstructuur wanneer de presentatie wordt geëxporteerd naar PDF. Hierdoor kan een aangepaste identifier die als tag is toegewezen niet uit de getagde PDF worden opgehaald.

**Workaround**: Je kunt een aangepaste identifier opslaan in de **Alt‑tekst** van het object (bijvoorbeeld `shape.setAlternativeText("MyId")`). Na export naar PDF kan de Alt‑tekst in de PDF‑tagstructuur verschijnen.

## **FAQ**

**Kan ik alle tags uit een presentatie, dia of vorm in één bewerking verwijderen?**

Ja. De [tag‑collectie](https://reference.aspose.com/slides/nl/java/com.aspose.slides/tagcollection/) ondersteunt een [clear](https://reference.aspose.com/slides/nl/java/com.aspose.slides/tagcollection/#clear--)‑bewerking die alle sleutel‑waarde‑paren in één keer verwijdert.

**Hoe verwijder ik een enkele tag op naam zonder de hele collectie te doorlopen?**

Gebruik `remove(name)` op de [tag‑collectie](https://reference.aspose.com/slides/nl/java/com.aspose.slides/tagcollection/) om de tag op zijn sleutel te verwijderen.

**Hoe kan ik de volledige lijst met tag‑namen ophalen voor analyse of filteren?**

Gebruik `getNamesOfTags` op de [tag‑collectie](https://reference.aspose.com/slides/nl/java/com.aspose.slides/tagcollection/); deze retourneert een array met alle tag‑namen.

**Hoe kan ik alle aangepaste XML‑onderdelen vinden, ongeacht waar ze zijn opgeslagen?**

Gebruik [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Presentation#getAllCustomXmlParts--) om alle aangepaste XML‑onderdelen in de presentatie op te halen.

**Moet ik `getXmlAsString`/`setXmlAsString` of `getXmlData`/`setXmlData` gebruiken om een aangepast XML‑onderdeel bij te werken?**

Gebruik `getXmlAsString` en `setXmlAsString` wanneer de applicatie werkt met UTF‑8‑XML‑tekst. Gebruik `getXmlData` en `setXmlData` wanneer de XML al beschikbaar is als byte‑array of wanneer binaire verwerking handiger is. Beide representaties verwijzen naar dezelfde XML‑inhoud van het aangepaste XML‑onderdeel.
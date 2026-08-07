---
title: Beheer tags en aangepaste gegevens in presentaties met Java
linktitle: Tags en aangepaste gegevens
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
- waardeparen
- PowerPoint
- presentatie
- Java
- Aspose.Slides
description: "Leer hoe u tags en aangepaste XML-gegevens in PowerPoint-presentaties kunt beheren met Aspose.Slides voor Java, inclusief het toevoegen, lezen, bijwerken, auditen en verwijderen van aangepaste XML-onderdelen."
---
## **Overzicht**

Dit artikel legt uit hoe Aspose.Slides werkt met tags en aangepaste gegevens in PowerPoint‑presentaties. Presentatiespecifieke gegevens kunnen worden opgeslagen als tags of aangepaste XML‑onderdelen. Tags zijn eenvoudige sleutel‑waarde‑tekenreeksparen, terwijl aangepaste XML‑onderdelen gestructureerde metadata en toepassingsspecifieke XML‑payloads kunnen opslaan.

Aspose.Slides biedt API’s voor het toevoegen, lezen, bijwerken, auditen en verwijderen van aangepaste XML‑onderdelen op presentatie‑, dia‑ en vormniveau. Aangepaste XML‑onderdelen zijn handig voor integraties die informatie opslaan, zoals document‑beheer‑identifiers, workflow‑status, compliance‑metadata, template‑binding‑gegevens of andere gestructureerde toepassingsgegevens binnen een presentatie.

## **Gegevensopslag in presentatiebestanden**

PPTX‑bestanden — bestanden met de extensie `.pptx` — worden opgeslagen in het PresentationML‑formaat, dat deel uitmaakt van de Office Open XML‑specificatie. Office Open XML definieert de pakketstructuur en relaties die worden gebruikt om presentatiewaarde en gerelateerde gegevens op te slaan.

Een presentatie bevat meerdere onderdelen die via relaties met elkaar verbonden zijn. Bijvoorbeeld, een dia‑onderdeel bevat de inhoud van één enkele dia en kan expliciete relaties hebben met andere onderdelen die gedefinieerd zijn door ISO/IEC 29500.

Aangepaste gegevens kunnen worden opgeslagen als tags ([ITagCollection](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ITagCollection)) of aangepaste XML‑onderdelen ([ICustomXmlPartCollection](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ICustomXmlPartCollection)). Beide zijn beschikbaar via de [`ICustomData`](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ICustomData/) interface.

{{% alert color="primary" %}}
Tags slaan eenvoudige tekenreeks‑sleutel‑waardeparen op. Aangepaste XML‑onderdelen slaan gestructureerde XML‑gegevens op en kunnen worden gekoppeld aan een presentatie, dia of vorm.
{{% /alert %}}

## **Werken met aangepaste XML‑onderdelen**

De [`ICustomData.getCustomXmlParts()`](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ICustomData#getCustomXmlParts--) methode retourneert de collectie van aangepaste XML‑onderdelen die gekoppeld zijn aan een bepaald presentatie‑object. Bijvoorbeeld:

- `presentation.getCustomData().getCustomXmlParts()` bevat de aangepaste XML‑onderdelen die gekoppeld zijn aan de presentatie zelf.
- `slide.getCustomData().getCustomXmlParts()` bevat de aangepaste XML‑onderdelen die gekoppeld zijn aan een specifieke dia.
- `shape.getCustomData().getCustomXmlParts()` bevat de aangepaste XML‑onderdelen die gekoppeld zijn aan een specifieke vorm.

Gebruik [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Presentation#getAllCustomXmlParts--) wanneer u alle aangepaste XML‑onderdelen in de presentatie wilt inspecteren, ongeacht waar ze gekoppeld zijn.

### **Een aangepast XML‑onderdeel toevoegen aan een presentatie**

Gebruik [`ICustomXmlPartCollection.add`](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ICustomXmlPartCollection#add-java.lang.String-) om XML‑gegevens toe te voegen aan een collectie van aangepaste XML‑onderdelen. De XML moet geldig en niet‑leeg zijn.

Het volgende voorbeeld voegt gestructureerde metadata toe aan de aangepaste gegevens‑collectie op presentatieniveau:

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

    // add kent automatisch een identifier toe. Stel een specifieke UUID alleen in wanneer nodig.
    customXmlPart.setItemId(UUID.randomUUID());

    presentation.save("presentation_with_custom_xml.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

De `add`‑methode kan ook XML als byte‑array of invoerstroom accepteren, wat nuttig is wanneer XML‑inhoud reeds beschikbaar is in binaire vorm.

### **Een aangepast XML‑onderdeel toevoegen aan een dia of vorm**

Aangepaste XML‑gegevens kunnen worden gekoppeld aan een specifieke dia of vorm in plaats van aan de hele presentatie. Dit is handig wanneer metadata slechts één object beschrijft, bijvoorbeeld een template‑sleutel, externe record‑identifier of bind‑informatie.

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

Het niveau waarop een onderdeel wordt toegevoegd bepaalt in welke object's `getCustomData().getCustomXmlParts()`‑collectie de relatie naar dat onderdeel voorkomt. Gegevens op presentatieniveau zijn geschikt voor document‑brede metadata, gegevens op dia‑niveau voor informatie die bij een bepaalde dia hoort, en gegevens op vorm‑niveau voor metadata die aan een individuele vorm zijn gekoppeld.

### **Alle aangepaste XML‑onderdelen opsommen en auditen**

Gebruik [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Presentation#getAllCustomXmlParts--) om alle aangepaste XML‑onderdelen uit een presentatie op te halen. Elk [`ICustomXmlPart`](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ICustomXmlPart/) geeft zijn identifier, XML‑inhoud en gekoppelde namespace‑schemas weer.

Het volgende voorbeeld somt alle aangepaste XML‑onderdelen en hun namespace‑schemas op:

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

[`ICustomXmlPart.getNamespaceSchemas()`](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ICustomXmlPart#getNamespaceSchemas--) retourneert de XML‑schemas die aan het aangepaste XML‑onderdeel zijn gekoppeld. Deze informatie kan handig zijn bij het auditen van presentaties die XML bevatten die door externe systemen is geproduceerd.

### **XML‑inhoud en ItemId lezen en bijwerken**

Gebruik [`ICustomXmlPart.getXmlAsString()`](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ICustomXmlPart#getXmlAsString--) en [`setXmlAsString()`](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ICustomXmlPart#setXmlAsString-java.lang.String-) om met XML te werken als een UTF‑8‑tekenreeks, of [`getXmlData()`](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ICustomXmlPart#getXmlData--) en [`setXmlData()`](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ICustomXmlPart#setXmlData-byte:A-) om met de ruwe XML‑bytes te werken.

De [`ICustomXmlPart.getItemId()`](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ICustomXmlPart#getItemId--) methode geeft de UUID terug die het aangepaste XML‑onderdeel identificeert in het Office Open XML‑document. Gebruik [`setItemId()`](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ICustomXmlPart#setItemId-java.util.UUID-) wanneer een integratie een nieuwe identifier vereist.

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

    // Werk de XML bij als een UTF-8 string.
    customXmlPart.setXmlAsString(
        "<metadata xmlns=\"urn:example:metadata\">" +
            "<documentId>DOC-1001</documentId>" +
            "<workflowState>Approved</workflowState>" +
        "</metadata>");

    // getXmlData levert dezelfde XML inhoud als ruwe bytes.
    byte[] customXmlData = customXmlPart.getXmlData();
    System.out.println(new String(customXmlData, StandardCharsets.UTF_8));

    // Vervang de identifier wanneer de integratie dat vereist.
    customXmlPart.setItemId(UUID.randomUUID());

    presentation.save("updated_custom_xml.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Wanneer `setXmlAsString` of `setXmlData` wordt aangeroepen, dient geldige, niet‑leeg XML te worden opgegeven. Gebruik de ene representatie of de andere, afhankelijk van of de applicatie voornamelijk met tekenreeksen of met byte‑gegevens werkt.

### **Een aangepast XML‑onderdeel verwijderen**

Aspose.Slides biedt verschillende manieren om aangepaste XML‑gegevens te verwijderen:

- [`ICustomXmlPart.remove`](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ICustomXmlPart#remove--) verwijdert het aangepaste XML‑onderdeel uit de presentatie.
- [`ICustomXmlPartCollection.remove`](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ICustomXmlPartCollection#remove-com.aspose.slides.ICustomXmlPart-) verwijdert een specifiek onderdeel uit een collectie van aangepaste XML‑onderdelen.
- [`ICustomXmlPartCollection.removeAt`](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ICustomXmlPartCollection#removeAt-int--) verwijdert het onderdeel op een opgegeven collectie‑index.
- [`ICustomXmlPartCollection.clear`](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ICustomXmlPartCollection#clear--) verwijdert alle onderdelen uit een specifieke collectie.

Het volgende voorbeeld verwijdert één aangepast XML‑onderdeel op presentatieniveau via referentie:

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

Als u al een `ICustomXmlPart` heeft en dat onderdeel uit de presentatie wilt verwijderen in plaats van een specifieke collectie aan te spreken, roep dan `customXmlPart.remove()` aan.

U kunt ook een item via index verwijderen:

```java
presentation.getCustomData().getCustomXmlParts().removeAt(0);
```

### **Alle aangepaste XML‑onderdelen uit een collectie wissen**

Gebruik `clear` wanneer alle aangepaste XML‑onderdelen die gekoppeld zijn aan een specifiek presentatie‑object verwijderd moeten worden.

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

`clear` heeft alleen effect op de geselecteerde collectie. Bijvoorbeeld, het wissen van een dia‑collectie wist niet de collecties op presentatieniveau of vormniveau.

Om elk aangepast XML‑onderdeel in de presentatie te verwijderen, itereren door `getAllCustomXmlParts()` en elk onderdeel verwijderen:

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

### **Gelinkte of gedeelde aangepaste XML‑onderdelen afhandelen**

In een Office Open XML‑presentatie kan hetzelfde aangepaste XML‑onderdeel vanuit meer dan één presentatie‑object worden aangesproken. Bijvoorbeeld, een bestaand bestand kan relaties bevatten van meerdere dia’s of vormen naar hetzelfde onderliggende aangepaste XML‑onderdeel.

Een gedeeld onderdeel moet worden behandeld als één gegevensobject met meerdere verwijzingen:

- Bijwerken met `setXmlAsString`, `setXmlData` of `setItemId` wijzigt het onderliggende aangepaste XML‑onderdeel, zodat de wijziging overal geldt waar dat onderdeel wordt verwezen.
- `getItemId()` kan worden gebruikt om hetzelfde aangepaste XML‑onderdeel te identificeren tijdens het auditen van object‑niveau collecties.
- Het verwijderen van een onderdeel uit een specifieke `getCustomXmlParts()`‑collectie verwijdert het uit die collectie. Gebruik `ICustomXmlPart.remove()` wanneer het onderdeel zelf uit de presentatie moet worden verwijderd.
- Controleer vóór het verwijderen of vervangen van een gedeeld onderdeel de object‑niveau collecties om te bepalen of andere dia’s of vormen er nog naar verwijzen.

De `add`‑overloads maken een nieuw aangepast XML‑onderdeel aan vanuit XML‑inhoud; ze accepteren geen bestaand `ICustomXmlPart`. Daarom komen gedeelde relaties vooral voor bij het laden van presentaties die ze al bevatten.

Het volgende voorbeeld auditet collecties op presentatieniveau, dia‑niveau en vorm‑niveau op basis van `ItemId` en meldt onderdelen die vanuit meer dan één plaats worden aangeroepen:

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

In Slides correspondeert een tag met de `IDocumentProperties.getKeywords()`‑methode. Deze voorbeeldcode toont hoe een tag‑waarde te verkrijgen met Aspose.Slides voor Java voor [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Presentation):

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

Aspose.Slides stelt u in staat tags toe te voegen aan presentaties. Een tag bestaat doorgaans uit twee onderdelen:

- de naam van een aangepaste eigenschap, bijvoorbeeld `MyTag`;
- de waarde van de aangepaste eigenschap, bijvoorbeeld `My Tag Value`.

Wanneer u presentaties wilt classificeren op basis van een specifieke regel of eigenschap, kunt u hiervoor tags toevoegen. Bijvoorbeeld, als u presentaties uit Noord‑Amerikaanse landen wilt categoriseren, kunt u een Noord‑Amerikaanse tag maken en het betreffende land als waarde toewijzen.

Deze voorbeeldcode toont hoe een tag toe te voegen aan een [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Presentation) met Aspose.Slides voor Java:

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

Tags die via de `getCustomData().getTags()`‑collectie worden toegevoegd, worden alleen in het PowerPoint‑bestand opgeslagen. Ze worden **niet** overgedragen naar de PDF‑tag‑structuur wanneer de presentatie wordt geëxporteerd naar PDF. Daardoor kan een als tag toegewezen aangepaste identifier niet worden opgehaald uit de getagde PDF.

**Workaround**: U kunt een aangepaste identifier opslaan in de **Alt‑tekst** van het object (bijvoorbeeld `shape.setAlternativeText("MyId")`). Na exporteren naar PDF kan de Alt‑tekst in de PDF‑tag‑structuur verschijnen.

## **FAQ**

**Kan ik alle tags uit een presentatie, dia of vorm in één bewerking verwijderen?**

Ja. De [tag collection](https://reference.aspose.com/slides/nl/java/com.aspose.slides/tagcollection/) ondersteunt een [clear](https://reference.aspose.com/slides/nl/java/com.aspose.slides/tagcollection/#clear--) bewerking die alle sleutel‑waardeparen in één keer verwijdert.

**Hoe verwijder ik een enkele tag op naam zonder door de hele collectie te itereren?**

Gebruik [remove(name)](https://reference.aspose.com/slides/nl/java/com.aspose.slides/tagcollection/#remove-java.lang.String-) op de [tag collection](https://reference.aspose.com/slides/nl/java/com.aspose.slides/tagcollection/) om de tag op basis van zijn sleutel te verwijderen.

**Hoe kan ik de volledige lijst van tag‑namen ophalen voor analyse of filtering?**

Gebruik [getNamesOfTags](https://reference.aspose.com/slides/nl/java/com.aspose.slides/tagcollection/#getNamesOfTags--) op de [tag collection](https://reference.aspose.com/slides/nl/java/com.aspose.slides/tagcollection/); deze retourneert een array met alle tag‑namen.

**Hoe vind ik alle aangepaste XML‑onderdelen, ongeacht waar ze zijn opgeslagen?**

Gebruik [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Presentation#getAllCustomXmlParts--) om alle aangepaste XML‑onderdelen in de presentatie op te halen.

**Moet ik `getXmlAsString`/`setXmlAsString` of `getXmlData`/`setXmlData` gebruiken om een aangepast XML‑onderdeel bij te werken?**

Gebruik `getXmlAsString` en `setXmlAsString` wanneer de applicatie werkt met UTF‑8‑XML‑tekst. Gebruik `getXmlData` en `setXmlData` wanneer de XML al beschikbaar is als byte‑array of wanneer verwerking op binair niveau handiger is. Beide representaties verwijzen naar de XML‑inhoud van hetzelfde aangepaste XML‑onderdeel.
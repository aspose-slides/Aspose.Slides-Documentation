---
title: Tags en aangepaste gegevens beheren in presentaties op Android
linktitle: Tags en aangepaste gegevens
type: docs
weight: 300
url: /nl/androidjava/managing-tags-and-custom-data
keywords:
- documenteigenschappen
- tag
- aangepaste gegevens
- aangepaste XML
- aangepast XML‑onderdeel
- XML‑metadata
- ItemId
- tag toevoegen
- waardeparen
- PowerPoint
- presentatie
- Android
- Java
- Aspose.Slides
description: "Leer hoe u tags en aangepaste XML-gegevens in PowerPoint‑presentaties beheert met Aspose.Slides voor Android via Java, inclusief het toevoegen, lezen, bijwerken, auditen en verwijderen van aangepaste XML‑onderdelen."
---
## **Overzicht**

Dit artikel legt uit hoe Aspose.Slides werkt met tags en aangepaste gegevens in PowerPoint‑presentaties. Presentatiespecifieke gegevens kunnen worden opgeslagen als tags of als aangepaste XML‑onderdelen. Tags zijn eenvoudige sleutel‑waarde tekenreeksparen, terwijl aangepaste XML‑onderdelen gestructureerde metadata en toepassingsspecifieke XML‑payloads kunnen opslaan.

Aspose.Slides biedt API's voor het toevoegen, lezen, bijwerken, controleren en verwijderen van aangepaste XML‑onderdelen op presentatie‑, dia‑ en vormniveau. Aangepaste XML‑onderdelen zijn nuttig voor integraties die informatie opslaan zoals document‑beheerdersidentifiers, workflow‑status, compliance‑metadata, sjabloon‑bindende gegevens of andere gestructureerde toepassingsgegevens binnen een presentatie.

## **Gegevensopslag in presentatiebestanden**

PPTX‑bestanden – bestanden met de extensie `.pptx` – worden opgeslagen in het PresentationML‑formaat, dat deel uitmaakt van de Office Open XML‑specificatie. Office Open XML definieert de pakketstructuur en relaties die worden gebruikt om presentatiewe inhoud en gerelateerde gegevens op te slaan.

Een presentatie bevat meerdere onderdelen die via relaties met elkaar verbonden zijn. Bijvoorbeeld, een dia‑onderdeel bevat de inhoud van één enkele dia en kan expliciete relaties hebben met andere onderdelen zoals gedefinieerd in ISO/IEC 29500.

Aangepaste gegevens kunnen worden opgeslagen als tags ([ITagCollection](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ITagCollection)) of als aangepaste XML‑onderdelen ([ICustomXmlPartCollection](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ICustomXmlPartCollection)). Beide zijn beschikbaar via de interface [`ICustomData`](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ICustomData/).

{{% alert color="primary" %}}
Tags slaan eenvoudige sleutel‑waarde tekenreeksparen op. Aangepaste XML‑onderdelen slaan gestructureerde XML‑gegevens op en kunnen worden gekoppeld aan een presentatie, dia of vorm.
{{% /alert %}}

## **Werken met aangepaste XML‑onderdelen**

De methode [`ICustomData.getCustomXmlParts()`](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ICustomData#getCustomXmlParts--) retourneert de collectie van aangepaste XML‑onderdelen die gekoppeld zijn aan een specifiek presentatie‑object. Bijvoorbeeld:

- `presentation.getCustomData().getCustomXmlParts()` bevat de aangepaste XML‑onderdelen die bij de presentatie zelf horen.
- `slide.getCustomData().getCustomXmlParts()` bevat de aangepaste XML‑onderdelen die bij een specifieke dia horen.
- `shape.getCustomData().getCustomXmlParts()` bevat de aangepaste XML‑onderdelen die bij een specifieke vorm horen.

Gebruik [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation#getAllCustomXmlParts--) wanneer u alle aangepaste XML‑onderdelen in de presentatie wilt inspecteren, ongeacht waar ze zijn gekoppeld.

### **Voeg een aangepast XML‑onderdeel toe aan een presentatie**

Gebruik [`ICustomXmlPartCollection.add`](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ICustomXmlPartCollection#add-java.lang.String-) om XML‑gegevens toe te voegen aan een collectie van aangepaste XML‑onderdelen. De XML moet geldig en niet‑leeg zijn.

Het volgende voorbeeld voegt gestructureerde metadata toe aan de aangepaste gegevenscollectie op presentatieniveau:

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

    // add wijst automatisch een identifier toe. Stel alleen een specifieke UUID in wanneer dat nodig is.
    customXmlPart.setItemId(UUID.randomUUID());

    presentation.save("presentation_with_custom_xml.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

De `add`‑methode kan ook XML accepteren als een byte‑array of invoerstroom, wat handig is wanneer XML‑inhoud al beschikbaar is in binaire vorm.

### **Voeg een aangepast XML‑onderdeel toe aan een dia of vorm**

Aangepaste XML‑gegevens kunnen worden gekoppeld aan een specifieke dia of vorm in plaats van aan de volledige presentatie. Dit is nuttig wanneer metadata slechts één object beschrijft, zoals een sjabloonsleutel, een extern record‑identificatienummer of bindinformatie.

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

Het niveau waarop een onderdeel wordt toegevoegd bepaalt welke object‑`getCustomData().getCustomXmlParts()`‑collectie de relatie naar dat onderdeel bevat. Gegevens op presentatieniveau zijn geschikt voor metadata die het hele document beslaat, gegevens op dia‑niveau voor informatie die bij een specifieke dia hoort, en gegevens op vorm‑niveau voor metadata die aan een individuele vorm gekoppeld is.

### **Lijst en controleer alle aangepaste XML‑onderdelen**

Gebruik [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation#getAllCustomXmlParts--) om alle aangepaste XML‑onderdelen uit een presentatie op te halen. Elk [`ICustomXmlPart`](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ICustomXmlPart/) toont zijn identifier, XML‑inhoud en de bijbehorende naamruimschemas.

Het volgende voorbeeld geeft een lijst weer van alle aangepaste XML‑onderdelen en hun naamruimschemas:

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

De methode `ICustomXmlPart.getNamespaceSchemas()` retourneert de XML‑schemas die aan het aangepaste XML‑onderdeel zijn gekoppeld. Deze informatie kan nuttig zijn bij het controleren van presentaties die XML bevatten die door externe systemen is gegenereerd.

### **Lees en werk XML‑inhoud en ItemId bij**

Gebruik [`ICustomXmlPart.getXmlAsString()`](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ICustomXmlPart#getXmlAsString--) en [`setXmlAsString()`](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ICustomXmlPart#setXmlAsString-java.lang.String-) om met XML te werken als een UTF‑8‑string, of [`getXmlData()`](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ICustomXmlPart#getXmlData--) en [`setXmlData()`](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ICustomXmlPart#setXmlData-byte:A-) om met de ruwe XML‑bytes te werken.

De methode `ICustomXmlPart.getItemId()` retourneert de UUID die het aangepaste XML‑onderdeel in het Office Open XML‑document identificeert. Gebruik [`setItemId()`](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ICustomXmlPart#setItemId-java.util.UUID-) wanneer een integratie een nieuwe identifier nodig heeft.

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

    // Update de XML als een UTF-8‑tekenreeks.
    customXmlPart.setXmlAsString(
        "<metadata xmlns=\"urn:example:metadata\">" +
            "<documentId>DOC-1001</documentId>" +
            "<workflowState>Approved</workflowState>" +
        "</metadata>");

    // getXmlData levert dezelfde XML‑inhoud als ruwe bytes.
    byte[] customXmlData = customXmlPart.getXmlData();
    System.out.println(new String(customXmlData, StandardCharsets.UTF_8));

    // Vervang de identifier wanneer vereist door de integratie.
    customXmlPart.setItemId(UUID.randomUUID());

    presentation.save("updated_custom_xml.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Wanneer `setXmlAsString` of `setXmlData` wordt aangeroepen, moet geldige, niet‑lege XML worden opgegeven. Gebruik de ene of de andere representatie afhankelijk van of de applicatie voornamelijk met strings of met byte‑data werkt.

### **Verwijder een aangepast XML‑onderdeel**

Aspose.Slides biedt verschillende manieren om aangepaste XML‑gegevens te verwijderen:

- [`ICustomXmlPart.remove`](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ICustomXmlPart#remove--) verwijdert het aangepaste XML‑onderdeel uit de presentatie.
- [`ICustomXmlPartCollection.remove`](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ICustomXmlPartCollection#remove-com.aspose.slides.ICustomXmlPart-) verwijdert een specifiek onderdeel uit een collectie van aangepaste XML‑onderdelen.
- [`ICustomXmlPartCollection.removeAt`](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ICustomXmlPartCollection#removeAt-int-) verwijdert het onderdeel op een opgegeven index in de collectie.
- [`ICustomXmlPartCollection.clear`](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ICustomXmlPartCollection#clear--) verwijdert alle onderdelen uit een specifieke collectie.

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

U kunt ook een item verwijderen op basis van index:

```java
presentation.getCustomData().getCustomXmlParts().removeAt(0);
```

### **Verwijder alle aangepaste XML‑onderdelen uit een collectie**

Gebruik `clear` wanneer alle aangepaste XML‑onderdelen die aan een bepaald presentatie‑object zijn gekoppeld, verwijderd moeten worden.

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

`clear` heeft alleen invloed op de geselecteerde collectie. Bijvoorbeeld, het leegmaken van de collectie van een dia verwijdert niet de collecties op presentatieniveau of vormniveau.

Om elk aangepast XML‑onderdeel in de presentatie te verwijderen, doorloop `getAllCustomXmlParts()` en verwijder elk onderdeel:

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

### **Verwerk gekoppelde of gedeelde aangepaste XML‑onderdelen**

In een Office Open XML‑presentatie kan hetzelfde aangepaste XML‑onderdeel door meer dan één presentatie‑object worden gerefereerd. Bijvoorbeeld, een bestaand bestand kan relaties bevatten van meerdere dia's of vormen naar hetzelfde onderliggende aangepaste XML‑onderdeel.

Een gedeeld onderdeel moet worden behandeld als één gegevensobject met meerdere referenties:

- Het bijwerken met `setXmlAsString`, `setXmlData` of `setItemId` wijzigt het onderliggende aangepaste XML‑onderdeel, zodat de wijziging geldt waar het onderdeel ook wordt gerefereerd.
- `getItemId()` kan worden gebruikt om hetzelfde aangepaste XML‑onderdeel te identificeren tijdens het controleren van object‑level collecties.
- Het verwijderen van een onderdeel uit een specifieke `getCustomXmlParts()`‑collectie verwijdert het uit die collectie. Gebruik `ICustomXmlPart.remove()` wanneer het onderdeel zelf uit de presentatie moet worden verwijderd.
- Voordat een gedeeld onderdeel wordt verwijderd of vervangen, inspecteer de object‑level collecties om te bepalen of andere dia's of vormen er nog naar verwijzen.

De `add`‑overloads maken een nieuw aangepast XML‑onderdeel aan op basis van XML‑inhoud; ze accepteren geen bestaand `ICustomXmlPart`. Daarom komen gedeelde relaties het vaakst voor bij het laden van presentaties die ze al bevatten.

Het volgende voorbeeld controleert de collecties op presentatieniveau, dia‑niveau en vorm‑niveau op `ItemId` en meldt onderdelen die op meer dan één plaats worden gerefereerd:

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

Dit type controle is nuttig voordat u aangepaste XML‑gegevens wijzigt of verwijdert in presentaties die door externe systemen zijn aangemaakt, omdat hetzelfde metadata‑onderdeel in meer dan één relatie kan deelnemen.

## **Waarden van tags ophalen**

In Slides correspondeert een tag met de methode `IDocumentProperties.getKeywords()`. Deze voorbeeldcode toont hoe u een tag‑waarde kunt ophalen met Aspose.Slides voor Android via Java voor [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation):

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

Als u presentaties wilt classificeren op basis van een specifieke regel of eigenschap, kunt u tags toevoegen voor dat doel. Bijvoorbeeld, als u presentaties uit Noord‑Amerikaanse landen wilt categoriseren, kunt u een Noord‑Amerikaanse tag maken en het betreffende land als waarde toewijzen.

Deze voorbeeldcode toont hoe u een tag toevoegt aan een [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation) met Aspose.Slides voor Android via Java:

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

Tags kunnen ook worden ingesteld voor een [Slide](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ISlide):

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

Of voor een individuele [Shape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IAutoShape):

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

**Workaround**: U kunt een aangepaste identifier opslaan in de **Alt‑tekst** van het object (bijvoorbeeld `shape.setAlternativeText("MyId")`). Na het exporteren naar PDF kan de Alt‑tekst in de PDF‑tagstructuur verschijnen.

## **FAQ**

**Kan ik alle tags uit een presentatie, dia of vorm in één bewerking verwijderen?**

Ja. De [tag collection](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/tagcollection/) ondersteunt een [clear](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/tagcollection/#clear--)‑bewerking die alle sleutel‑waardeparen in één keer verwijdert.

**Hoe verwijder ik een enkele tag op basis van de naam zonder de hele collectie te doorlopen?**

Gebruik [remove(name)](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/tagcollection/#remove-java.lang.String-) op de [tag collection](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/tagcollection/) om de tag op basis van zijn sleutel te verwijderen.

**Hoe kan ik de volledige lijst met tag‑namen ophalen voor analyse of filteren?**

Gebruik [getNamesOfTags](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/tagcollection/#getNamesOfTags--) op de [tag collection](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/tagcollection/); het retourneert een array met alle tag‑namen.

**Hoe kan ik alle aangepaste XML‑onderdelen vinden, ongeacht waar ze opgeslagen zijn?**

Gebruik [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation#getAllCustomXmlParts--) om alle aangepaste XML‑onderdelen in de presentatie op te halen.

**Moet ik `getXmlAsString`/`setXmlAsString` of `getXmlData`/`setXmlData` gebruiken om een aangepast XML‑onderdeel bij te werken?**

Gebruik `getXmlAsString` en `setXmlAsString` wanneer de applicatie werkt met UTF‑8 XML‑tekst. Gebruik `getXmlData` en `setXmlData` wanneer de XML al beschikbaar is als byte‑array of wanneer binaire verwerking handiger is. Beide representaties verwijzen naar de XML‑inhoud van hetzelfde aangepaste XML‑onderdeel.
---
title: Hantera taggar och anpassad data i presentationer på Android
linktitle: Taggar och anpassad data
type: docs
weight: 300
url: /sv/androidjava/managing-tags-and-custom-data
keywords:
- dokumentegenskaper
- tagg
- anpassad data
- anpassad XML
- anpassad XML-del
- XML-metadata
- ItemId
- lägg till tagg
- parvärden
- PowerPoint
- presentation
- Android
- Java
- Aspose.Slides
description: "Lär dig hur du hanterar taggar och anpassad XML-data i PowerPoint-presentationer med Aspose.Slides för Android via Java, inklusive att lägga till, läsa, uppdatera, granska och ta bort anpassade XML-delar."
---
## **Översikt**

Den här artikeln förklarar hur Aspose.Slides arbetar med taggar och anpassad data i PowerPoint-presentationer. Presentationsspecifik data kan lagras som taggar eller anpassade XML-delar. Taggar är enkla nyckel-värde-strängpar, medan anpassade XML-delar kan lagra strukturerad metadata och applikationsspecifik XML-payload.

Aspose.Slides tillhandahåller API:er för att lägga till, läsa, uppdatera, granska och ta bort anpassade XML-delar på presentations-, bild- och formnivå. Anpassade XML-delar är användbara för integrationer som lagrar information såsom dokumenthanterings-identifikatorer, arbetsflödesstatus, efterlevnadsmetadata, mallbindningsdata eller annan strukturerad applikationsdata i en presentation.

## **Datalagring i presentationsfiler**

PPTX-filer — filer med filändelsen `.pptx` — lagras i PresentationML-formatet, som är en del av Office Open XML-specifikationen. Office Open XML definierar paketstrukturen och relationerna som används för att lagra presentationsinnehåll och relaterad data.

En presentation innehåller flera delar som är kopplade via relationer. Till exempel innehåller en bilddel innehållet i en enskild bild och kan ha explicita relationer till andra delar enligt ISO/IEC 29500.

Anpassad data kan lagras som taggar ([ITagCollection](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ITagCollection)) eller anpassade XML-delar ([ICustomXmlPartCollection](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ICustomXmlPartCollection)). Båda är tillgängliga via gränssnittet [`ICustomData`](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ICustomData/) .

{{% alert color="primary" %}}
Taggar lagrar enkla sträng-nyckel-värde-par. Anpassade XML-delar lagrar strukturerad XML-data och kan associeras med en presentation, bild eller form.
{{% /alert %}}

## **Arbeta med anpassade XML-delar**

[`ICustomData.getCustomXmlParts()`](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ICustomData#getCustomXmlParts--)‑metoden returnerar samlingen av anpassade XML-delar som är associerade med ett specifikt presentationsobjekt. Till exempel:

- `presentation.getCustomData().getCustomXmlParts()` innehåller anpassade XML-delar som är associerade med själva presentationen.
- `slide.getCustomData().getCustomXmlParts()` innehåller anpassade XML-delar som är associerade med en specifik bild.
- `shape.getCustomData().getCustomXmlParts()` innehåller anpassade XML-delar som är associerade med en specifik form.

Använd [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/Presentation#getAllCustomXmlParts--) när du behöver granska alla anpassade XML-delar i presentationen oavsett var de är associerade.

### **Lägg till en anpassad XML-del i en presentation**

Använd [`ICustomXmlPartCollection.add`](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ICustomXmlPartCollection#add-java.lang.String-) för att lägga till XML-data i en samling av anpassade XML-delar. XML‑en måste vara giltig och inte tom.

Följande exempel lägger till strukturerad metadata till den presentationsnivå‑anpassade datainsamlingen:

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

    // add tilldelar automatiskt ett identifierare. Ange ett specifikt UUID endast när det krävs.
    customXmlPart.setItemId(UUID.randomUUID());

    presentation.save("presentation_with_custom_xml.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`add`‑metoden kan också ta emot XML som en byte-array eller inmatningsström, vilket är användbart när XML-innehållet redan finns i binär form.

### **Lägg till en anpassad XML-del i en bild eller form**

Anpassad XML-data kan associeras med en specifik bild eller form istället för hela presentationen. Detta är användbart när metadata beskriver endast ett objekt, t.ex. en mallnyckel, extern post-identifikator eller bindningsinformation.

Följande exempel lägger till en anpassad XML-del till en bild och en annan till en form:

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

Den nivå där en del läggs till bestämmer vilken objekts `getCustomData().getCustomXmlParts()`‑samling som innehåller relationen till den delen. Data på presentationsnivå är lämplig för dokumentomfattande metadata, data på bildnivå för information som tillhör en specifik bild, och data på formnivå för metadata knuten till en enskild form.

### **Lista och granska alla anpassade XML-delar**

Använd [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/Presentation#getAllCustomXmlParts--) för att hämta alla anpassade XML-delar från en presentation. Varje [`ICustomXmlPart`](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ICustomXmlPart/) visar sitt identifierare, XML-innehåll och tillhörande namnrymdsscheman.

Följande exempel listar alla anpassade XML-delar och deras namnrymdsscheman:

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

[`ICustomXmlPart.getNamespaceSchemas()`](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ICustomXmlPart#getNamespaceSchemas--) returnerar XML-scheman som är associerade med den anpassade XML-delen. Denna information kan vara användbar vid granskning av presentationer som innehåller XML producerad av externa system.

### **Läsa och uppdatera XML-innehåll och ItemId**

Använd [`ICustomXmlPart.getXmlAsString()`](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ICustomXmlPart#getXmlAsString--) och [`setXmlAsString()`](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ICustomXmlPart#setXmlAsString-java.lang.String-) för att arbeta med XML som en UTF-8-sträng, eller [`getXmlData()`](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ICustomXmlPart#getXmlData--) och [`setXmlData()`](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ICustomXmlPart#setXmlData-byte:A-) för att arbeta med råa XML-bytes.

[`ICustomXmlPart.getItemId()`](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ICustomXmlPart#getItemId--)‑metoden returnerar UUID:t som identifierar den anpassade XML-delen i Office Open XML-dokumentet. Använd [`setItemId()`](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ICustomXmlPart#setItemId-java.util.UUID-) när en integration kräver ett nytt identifierare.

Följande exempel uppdaterar XML-innehållet och identifieraren:

```java
import com.aspose.slides.*;
import java.nio.charset.StandardCharsets;
import java.util.UUID;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ICustomXmlPart customXmlPart = presentation.getAllCustomXmlParts()[0];

    // Läs den aktuella XML:n som text.
    String currentXmlContent = customXmlPart.getXmlAsString();
    System.out.println(currentXmlContent);

    // Uppdatera XML:n som en UTF-8-sträng.
    customXmlPart.setXmlAsString(
        "<metadata xmlns=\"urn:example:metadata\">" +
            "<documentId>DOC-1001</documentId>" +
            "<workflowState>Approved</workflowState>" +
        "</metadata>");

    // getXmlData tillhandahåller samma XML-innehåll som råa byte.
    byte[] customXmlData = customXmlPart.getXmlData();
    System.out.println(new String(customXmlData, StandardCharsets.UTF_8));

    // Ersätt identifieraren när integrationen kräver det.
    customXmlPart.setItemId(UUID.randomUUID());

    presentation.save("updated_custom_xml.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

När du anropar `setXmlAsString` eller `setXmlData`, ange giltig, icke-tom XML. Använd den ena eller den andra representationen beroende på om applikationen primärt arbetar med strängar eller byte‑data.

### **Ta bort en anpassad XML-del**

Aspose.Slides tillhandahåller flera sätt att ta bort anpassad XML-data:

- [`ICustomXmlPart.remove`](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ICustomXmlPart#remove--) tar bort den anpassade XML-delen från presentationen.
- [`ICustomXmlPartCollection.remove`](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ICustomXmlPartCollection#remove-com.aspose.slides.ICustomXmlPart-) tar bort en specifik del från en samling av anpassade XML-delar.
- [`ICustomXmlPartCollection.removeAt`](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ICustomXmlPartCollection#removeAt-int-) tar bort delen på ett angivet samlingsindex.
- [`ICustomXmlPartCollection.clear`](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ICustomXmlPartCollection#clear--) tar bort alla delar från en specifik samling.

Följande exempel tar bort en presentationsnivå‑anpassad XML-del genom referens:

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

Om du redan har ett `ICustomXmlPart` och vill ta bort den delen från presentationen istället för att adressera en specifik samling, anropa `customXmlPart.remove()`.

Du kan också ta bort ett objekt via index:

```java
presentation.getCustomData().getCustomXmlParts().removeAt(0);
```

### **Rensa alla anpassade XML-delar från en samling**

Använd `clear` när alla anpassade XML-delar som är associerade med ett specifikt presentationsobjekt ska tas bort.

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

`clear` påverkar endast den valda samlingen. Till exempel rensar rensning av en bilds samling inte samlingarna på presentations- eller formnivå.

För att ta bort varje anpassad XML-del i presentationen, iterera genom `getAllCustomXmlParts()` och ta bort varje del:

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

### **Hantera länkade eller delade anpassade XML-delar**

I en Office Open XML-presentation kan samma anpassade XML-del refereras från mer än ett presentationsobjekt. Till exempel kan en befintlig fil innehålla relationer från flera bilder eller former till samma underliggande anpassade XML-del.

En delad del bör behandlas som ett datobjekt med flera referenser:

- Att uppdatera den med `setXmlAsString`, `setXmlData` eller `setItemId` ändrar den underliggande anpassade XML-delen, så ändringen gäller där delen refereras.
- `getItemId()` kan användas för att identifiera samma anpassade XML-del vid granskning av objektnivå-samlingar.
- Att ta bort en del från en specifik `getCustomXmlParts()`-samling tar bort den från den samlingen. Använd `ICustomXmlPart.remove()` när själva delen ska tas bort från presentationen.
- Innan en del tas bort eller ersätts, inspektera objektnivå-samlingarna för att avgöra om andra bilder eller former fortfarande refererar till den.

`add`-överladdningarna skapar en ny anpassad XML-del från XML-innehåll; de accepterar inte en befintlig `ICustomXmlPart`. Därför möts delade relationer mestadels när presentationer som redan innehåller dem läses in.

Följande exempel granskar samlingar på presentations-, bild- och formnivå via `ItemId` och rapporterar delar som refereras från mer än en plats:

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

Denna typ av granskning är användbar innan anpassad XML-data i presentationer skapade av externa system ändras eller tas bort, eftersom samma metadata-del kan delta i mer än en relation.

## **Hämta värden för taggar**

I Slides motsvarar en tagg metoden `IDocumentProperties.getKeywords()`. Detta exempel visar hur man hämtar ett taggvärde med Aspose.Slides för Android via Java för [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/Presentation):

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    String keywords = presentation.getDocumentProperties().getKeywords();
} finally {
    presentation.dispose();
}
```

## **Lägg till taggar i presentationer**

Aspose.Slides låter dig lägga till taggar i presentationer. En tagg består vanligtvis av två delar:

- namnet på en anpassad egenskap, till exempel `MyTag`;
- värdet på den anpassade egenskapen, till exempel `My Tag Value`.

Om du behöver klassificera presentationer baserat på en specifik regel eller egenskap kan du lägga till taggar för det ändamålet. Till exempel, om du vill kategorisera presentationer från Nordamerika, kan du skapa en Nordamerikansk tagg och tilldela det relevanta landet som dess värde.

Detta exempel visar hur man lägger till en tagg i en [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/Presentation) med Aspose.Slides för Android via Java:

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

Taggar kan också sättas för en [Slide](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ISlide):

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

Eller för en enskild [Shape](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IAutoShape):

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

### **Begränsningar**

Taggar som läggs till via `getCustomData().getTags()`-samlingen lagras endast i PowerPoint-filen. De **överförs inte** till PDF-tagstruktur när presentationen exporteras till PDF. Följaktligen kan en anpassad identifierare som tilldelats som tagg inte hämtas från den taggade PDF-filen.

**Workaround**: Du kan lagra en anpassad identifierare i objektets **Alt Text** (t.ex. `shape.setAlternativeText("MyId")`). Efter export till PDF kan Alt Text dyka upp i PDF-tagstruktur.

## **FAQ**

**Kan jag ta bort alla taggar från en presentation, bild eller form i en enda operation?**

Ja. [Taggsamlingen](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/tagcollection/) stöder en [clear](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/tagcollection/#clear--)‑operation som tar bort alla nyckel‑värde‑par på en gång.

**Hur tar jag bort en enskild tagg efter dess namn utan att iterera över hela samlingen?**

Använd [remove(name)](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/tagcollection/#remove-java.lang.String-) på [taggsamlingen](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/tagcollection/) för att ta bort taggen med dess nyckel.

**Hur kan jag hämta den kompletta listan med taggnamn för analys eller filtrering?**

Använd [getNamesOfTags](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/tagcollection/#getNamesOfTags--) på [taggsamlingen](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/tagcollection/); den returnerar en array med alla taggnamn.

**Hur kan jag hitta alla anpassade XML-delar oavsett var de är lagrade?**

Använd [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/Presentation#getAllCustomXmlParts--) för att hämta alla anpassade XML-delar i presentationen.

**Bör jag använda `getXmlAsString`/`setXmlAsString` eller `getXmlData`/`setXmlData` för att uppdatera en anpassad XML-del?**

Använd `getXmlAsString` och `setXmlAsString` när applikationen arbetar med UTF-8‑XML‑text. Använd `getXmlData` och `setXmlData` när XML redan finns som en byte-array eller när binär‑orienterad bearbetning är bekvämare. Båda representationerna refererar till XML‑innehållet i samma anpassade XML-del.
---
title: Hantera taggar och anpassad data i presentationer med JavaScript
linktitle: Taggar och anpassad data
type: docs
weight: 300
url: /sv/nodejs-java/managing-tags-and-custom-data/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Lär dig hur du hanterar taggar och anpassad XML-data i PowerPoint-presentationer med Aspose.Slides för Node.js via Java, inklusive att lägga till, läsa, uppdatera, granska och ta bort anpassade XML-delar."
---
## **Översikt**

Denna artikel förklarar hur Aspose.Slides arbetar med taggar och anpassad data i PowerPoint-presentationer. Presentationsspecifik data kan lagras som taggar eller anpassade XML‑delar. Taggar är enkla nyckel‑värde‑strängpar, medan anpassade XML‑delar kan lagra strukturerad metadata och applikationsspecifika XML‑payloads.

Aspose.Slides tillhandahåller API:er för att lägga till, läsa, uppdatera, granska och ta bort anpassade XML‑delar på presentations‑, bild‑ och objekt‑nivå. Anpassade XML‑delar är användbara för integrationer som lagrar information såsom dokumenthanteringsidentifierare, arbetsflödesstatus, efterlevnadsmetadata, mallbindningsdata eller annan strukturerad applikationsdata i en presentation.

## **Datainlagring i presentationsfiler**

PPTX‑filer – filer med filändelsen `.pptx` – lagras i PresentationML‑formatet, som är en del av Office Open XML‑specifikationen. Office Open XML definierar paketstrukturen och relationerna som används för att lagra presentationsinnehåll och relaterad data.

En presentation innehåller flera delar som är kopplade via relationer. Till exempel innehåller en bilddel innehållet i en enskild bild och kan ha explicita relationer till andra delar som definieras av ISO/IEC 29500.

Anpassad data kan lagras som taggar ([TagCollection](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/tagcollection/)) eller anpassade XML‑delar ([CustomXmlPartCollection](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/customxmlpartcollection/)). Båda är tillgängliga via klassen [`CustomData`](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/customdata/) .

{{% alert color="primary" %}}
Taggar lagrar enkla strängnyckel‑värdepar. Anpassade XML‑delar lagrar strukturerad XML‑data och kan associeras med en presentation, bild eller form.
{{% /alert %}}

## **Arbeta med anpassade XML‑delar**

`getCustomXmlParts()`‑metoden i [`CustomData`](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/customdata/) returnerar samlingen av anpassade XML‑delar som är kopplade till ett specifikt presentationsobjekt. Till exempel:

- `presentation.getCustomData().getCustomXmlParts()` innehåller anpassade XML‑delar som är kopplade till själva presentationen.
- `slide.getCustomData().getCustomXmlParts()` innehåller anpassade XML‑delar som är knutna till en specifik bild.
- `shape.getCustomData().getCustomXmlParts()` innehåller anpassade XML‑delar som är knutna till ett specifikt objekt.

Använd [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/) när du behöver granska alla anpassade XML‑delar i presentationen oavsett var de är kopplade.

### **Lägg till en anpassad XML‑del i en presentation**

Använd `add`‑metoden i [`CustomXmlPartCollection`](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/customxmlpartcollection/) för att lägga till XML‑data i en samling av anpassade XML‑delar. XML‑en måste vara giltig och icke‑tom.

Följande exempel lägger till strukturerad metadata i presentation‑nivåns samling av anpassad data:

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

    // add tilldelar en identifierare automatiskt. Ställ in ett specifikt UUID endast när det krävs.
    const itemId = java.callStaticMethodSync("java.util.UUID", "randomUUID");
    customXmlPart.setItemId(itemId);

    presentation.save("presentation_with_custom_xml.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`add`‑metoden kan också ta emot XML som en byte‑array, vilket är användbart när XML‑innehållet redan finns i binär form.

### **Lägg till en anpassad XML‑del i en bild eller form**

Anpassad XML‑data kan associeras med en specifik bild eller form istället för hela presentationen. Detta är användbart när metadata beskriver endast ett objekt, till exempel en mallnyckel, ett externt postidentifierare eller bindningsinformation.

Följande exempel lägger till en anpassad XML‑del i en bild och en annan i en form:

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

Den nivå där en del läggs till bestämmer vilken objekts `getCustomData().getCustomXmlParts()`‑samling som innehåller relationen till den delen. Data på presentationsnivå är lämplig för dokumentomfattande metadata, data på bildnivå för information som tillhör en specifik bild, och data på objekt‑nivå för metadata som är knutna till ett enskilt objekt.

### **Lista och granska alla anpassade XML‑delar**

Använd [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/) för att hämta alla anpassade XML‑delar från en presentation. Varje [`CustomXmlPart`](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/customxmlpart/) visar sin identifierare, XML‑innehåll och associerade namnrymdsscheman.

Följande exempel listar alla anpassade XML‑delar och deras namnrymdsscheman:

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

`CustomXmlPart.getNamespaceSchemas()` returnerar XML‑schemana som är associerade med den anpassade XML‑delen. Denna information kan vara användbar vid granskning av presentationer som innehåller XML producerad av externa system.

### **Läs och uppdatera XML‑innehåll och ItemId**

Använd `getXmlAsString()` och `setXmlAsString()` från [`CustomXmlPart`](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/customxmlpart/) för att arbeta med XML som en UTF‑8‑sträng, eller `getXmlData()` och `setXmlData()` för att arbeta med de råa XML‑bytena.

`getItemId()`‑metoden returnerar UUID‑et som identifierar den anpassade XML‑delen i Office Open XML‑dokumentet. Använd `setItemId()` när en integration kräver en ny identifierare.

Följande exempel uppdaterar XML‑innehållet och identifieraren:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const customXmlPart = presentation.getAllCustomXmlParts()[0];

    // Läs den aktuella XML:n som text.
    const currentXmlContent = customXmlPart.getXmlAsString();
    console.log(currentXmlContent);

    // Uppdatera XML:n som en UTF-8-sträng.
    customXmlPart.setXmlAsString(
        '<metadata xmlns="urn:example:metadata">' +
            '<documentId>DOC-1001</documentId>' +
            '<workflowState>Approved</workflowState>' +
        '</metadata>');

    // getXmlData tillhandahåller samma XML-innehåll som råa bytes.
    const customXmlData = customXmlPart.getXmlData();
    console.log(Buffer.from(customXmlData).toString("utf8"));

    // Ersätt identifieraren när integrationen kräver det.
    const itemId = java.callStaticMethodSync("java.util.UUID", "randomUUID");
    customXmlPart.setItemId(itemId);

    presentation.save("updated_custom_xml.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

När du anropar `setXmlAsString` eller `setXmlData`, ange giltig, icke‑tom XML. Använd den ena representationen eller den andra beroende på om applikationen främst arbetar med strängar eller byte‑data.

### **Ta bort en anpassad XML‑del**

Aspose.Slides tillhandahåller flera sätt att ta bort anpassad XML‑data:

- `CustomXmlPart.remove` tar bort den anpassade XML‑delen från presentationen.
- `CustomXmlPartCollection.remove` tar bort en specifik del från en samling av anpassade XML‑delar.
- `CustomXmlPartCollection.removeAt` tar bort delen på ett angivet index i samlingen.
- `CustomXmlPartCollection.clear` tar bort alla delar från en specifik samling.

Följande exempel tar bort en anpassad XML‑del på presentationsnivå via referens:

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

Om du redan har ett `CustomXmlPart` och vill ta bort den delen från presentationen snarare än att adressera en specifik samling, anropa `customXmlPart.remove()`.

Du kan också ta bort ett objekt via index:

```javascript
presentation.getCustomData().getCustomXmlParts().removeAt(0);
```

### **Rensa alla anpassade XML‑delar från en samling**

Använd `clear` när alla anpassade XML‑delar som är knutna till ett specifikt presentationsobjekt ska tas bort.

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

`clear` påverkar endast den valda samlingen. Till exempel rensar rensning av en bilds samling inte samlingarna på presentations‑ eller objekt‑nivå.

För att ta bort varje anpassad XML‑del i presentationen, iterera genom `getAllCustomXmlParts()` och ta bort varje del:

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

### **Hantera länkade eller delade anpassade XML‑delar**

I en Office Open XML‑presentation kan samma anpassade XML‑del refereras från fler än ett presentationsobjekt. Till exempel kan en befintlig fil innehålla relationer från flera bilder eller former till samma underliggande anpassade XML‑del.

En delad del bör behandlas som ett enda dataobjekt med flera referenser:

- Att uppdatera den med `setXmlAsString`, `setXmlData` eller `setItemId` ändrar den underliggande anpassade XML‑delen, så förändringen gäller där delen refereras.
- `getItemId()` kan användas för att identifiera samma anpassade XML‑del vid granskning av samlingar på objekt‑nivå.
- Att ta bort en del från en specifik `getCustomXmlParts()`‑samling tar bort den från den samlingen. Använd `CustomXmlPart.remove()` när själva delen ska tas bort från presentationen.
- Innan du raderar eller ersätter en delad del, granska samlingarna på objekt‑nivå för att avgöra om andra bilder eller former fortfarande refererar till den.

`add`‑överskotten skapar en ny anpassad XML‑del från XML‑innehåll; de accepterar inte en befintlig `CustomXmlPart`. Därför stöter man vanligen på delade relationer när man laddar presentationer som redan innehåller dem.

Följande exempel granskar samlingar på presentations‑, bild‑ och objekt‑nivå efter `ItemId` och rapporterar delar som refereras från mer än en plats:

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

Denna typ av granskning är användbar innan man modifierar eller tar bort anpassad XML‑data i presentationer skapade av externa system, eftersom samma metadata‑del kan delta i fler än en relation.

## **Hämta värden för taggar**

I slides motsvarar en tagg `DocumentProperties.getKeywords()`‑metoden. Detta exempel visar hur man hämtar ett taggvärde med Aspose.Slides för Node.js via Java för [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/):

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const keywords = presentation.getDocumentProperties().getKeywords();
} finally {
    presentation.dispose();
}
```

## **Lägg till taggar i presentationer**

Aspose.Slides gör det möjligt att lägga till taggar i presentationer. En tagg består vanligtvis av två element:

- namnet på en anpassad egenskap, till exempel `MyTag`;
- värdet på den anpassade egenskapen, till exempel `My Tag Value`.

Om du behöver klassificera presentationer baserat på en specifik regel eller egenskap kan du lägga till taggar för det ändamålet. Till exempel, om du vill kategorisera presentationer från Nordamerikanska länder, kan du skapa en Nordamerikansk tagg och tilldela det relevanta landet som dess värde.

Detta exempel visar hur man lägger till en tagg i en [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/) med Aspose.Slides för Node.js via Java:

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

Taggar kan också sättas för en [Slide](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/slide/):

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

Eller för en enskild [Shape](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/autoshape/):

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

### **Begränsningar**

Taggar som läggs till via `getCustomData().getTags()`‑samlingen lagras endast i PowerPoint‑filen. De **överförs inte** till PDF‑taggstrukturen när presentationen exporteras till PDF. Därför kan en anpassad identifierare som tilldelats som en tagg inte hämtas från den taggade PDF‑filen.

**Workaround**: Du kan lagra en anpassad identifierare i objektets **Alt‑text** (till exempel `shape.setAlternativeText("MyId")`). Efter export till PDF kan Alt‑texten dyka upp i PDF‑taggstrukturen.

## **Vanliga frågor**

**Kan jag ta bort alla taggar från en presentation, bild eller form i en operation?**

Ja. [Taggsamlingen](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/tagcollection/) stöder en [clear](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/tagcollection/)‑operation som tar bort alla nyckel‑värdepar på en gång.

**Hur tar jag bort en enskild tagg efter dess namn utan att iterera över hela samlingen?**

Använd `remove(name)` på [taggsamlingen](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/tagcollection/) för att ta bort taggen med dess nyckel.

**Hur kan jag hämta hela listan med taggnamn för analys eller filtrering?**

Använd `getNamesOfTags()` på [taggsamlingen](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/tagcollection/); den returnerar en array med alla taggnamn.

**Hur kan jag hitta alla anpassade XML‑delar oavsett var de lagras?**

Använd [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/) för att hämta alla anpassade XML‑delar i presentationen.

**Ska jag använda `getXmlAsString`/`setXmlAsString` eller `getXmlData`/`setXmlData` för att uppdatera en anpassad XML‑del?**

Använd `getXmlAsString` och `setXmlAsString` när applikationen arbetar med UTF‑8‑XML‑text. Använd `getXmlData` och `setXmlData` när XML redan finns som en byte‑array eller när binär bearbetning är mer bekväm. Båda representationerna refererar till XML‑innehållet i samma anpassade XML‑del.
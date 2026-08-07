---
title: "Hantera taggar och anpassade data i presentationer med PHP"
linktitle: "Taggar och anpassade data"
type: docs
weight: 300
url: /sv/php-java/managing-tags-and-custom-data/
keywords:
- dokumentegenskaper
- tagg
- anpassade data
- anpassad XML
- anpassad XML-del
- XML-metadata
- ItemId
- lägg till tagg
- parvärden
- PowerPoint
- presentation
- PHP
- Aspose.Slides
description: "Lär dig hur du hanterar taggar och anpassade XML‑data i PowerPoint‑presentationer med Aspose.Slides för PHP via Java, inklusive att lägga till, läsa, uppdatera, granska och ta bort anpassade XML‑delar."
---
## **Översikt**

Den här artikeln förklarar hur Aspose.Slides arbetar med taggar och anpassade data i PowerPoint‑presentationer. Presentationsspecifika data kan lagras som taggar eller anpassade XML‑delar. Taggar är enkla nyckel‑värde‑strängpar, medan anpassade XML‑delar kan lagra strukturerad metadata och applikationsspecifika XML‑payloads.

Aspose.Slides tillhandahåller API:er för att lägga till, läsa, uppdatera, granska och ta bort anpassade XML‑delar på presentations‑, bild‑ och formnivå. Anpassade XML‑delar är användbara för integrationer som lagrar information såsom dokumenthanterings‑identifierare, arbetsflödes‑status, efterlevnadsmetadata, mallbindningsdata eller annan strukturerad applikationsdata i en presentation.

## **Datlagring i presentationsfiler**

PPTX‑filer — filer med filändelsen `.pptx` — lagras i PresentationML‑formatet, som är en del av Office Open XML‑specifikationen. Office Open XML definierar paketstrukturen och relationerna som används för att lagra presentationsinnehåll och relaterad data.

En presentation innehåller flera delar som är kopplade med relationer. Till exempel innehåller en bilddel innehållet i en enskild bild och kan ha explicita relationer till andra delar enligt ISO/IEC 29500.

Anpassade data kan lagras som taggar ([TagCollection](https://reference.aspose.com/slides/sv/php-java/aspose.slides/tagcollection/)) eller anpassade XML‑delar ([CustomXmlPartCollection](https://reference.aspose.com/slides/sv/php-java/aspose.slides/customxmlpartcollection/)). Båda är tillgängliga via klassen [`CustomData`](https://reference.aspose.com/slides/sv/php-java/aspose.slides/customdata/).

{{% alert color="primary" %}}
Taggar lagrar enkla strängnyckel‑värde‑par. Anpassade XML‑delar lagrar strukturerad XML‑data och kan associeras med en presentation, bild eller form.
{{% /alert %}}

## **Arbeta med anpassade XML‑delar**

Metoden [`CustomData::getCustomXmlParts()`](https://reference.aspose.com/slides/sv/php-java/aspose.slides/customdata/#getCustomXmlParts) returnerar samlingen av anpassade XML‑delar som är kopplade till ett specifikt presentationsobjekt. Till exempel:

- `$presentation->getCustomData()->getCustomXmlParts()` innehåller anpassade XML‑delar som är kopplade till själva presentationen.
- `$slide->getCustomData()->getCustomXmlParts()` innehåller anpassade XML‑delar som är kopplade till en specifik bild.
- `$shape->getCustomData()->getCustomXmlParts()` innehåller anpassade XML‑delar som är kopplade till en specifik form.

Använd [`Presentation::getAllCustomXmlParts()`](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/#getAllCustomXmlParts) när du behöver inspektera alla anpassade XML‑delar i presentationen oavsett var de är kopplade.

### **Lägg till en anpassad XML‑del i en presentation**

Använd [`CustomXmlPartCollection::add`](https://reference.aspose.com/slides/sv/php-java/aspose.slides/customxmlpartcollection/#add) för att lägga till XML‑data i en samling av anpassade XML‑delar. XML‑innehållet måste vara giltigt och icke‑tomt.

Följande exempel lägger till strukturerad metadata i presentations‑nivåns anpassade datainsamling:

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

    // add tilldelar ett identifierare automatiskt. Ange ett specifikt UUID endast när det behövs.
    $UUID = new JavaClass("java.util.UUID");
    $customXmlPart->setItemId($UUID->randomUUID());

    $presentation->save("presentation_with_custom_xml.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

`add`‑metoden kan också ta emot XML som en byte‑array eller inmatningsström, vilket är praktiskt när XML‑innehållet redan finns i binär form.

### **Lägg till en anpassad XML‑del i en bild eller form**

Anpassad XML‑data kan associeras med en specifik bild eller form i stället för hela presentationen. Detta är användbart när metadata endast beskriver ett objekt, exempelvis en mallnyckel, ett externt post‑identifierare eller bindningsinformation.

Följande exempel lägger till en anpassad XML‑del i en bild och en annan i en form:

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

Den nivå där en del läggs till avgör i vilken objekts `getCustomData()->getCustomXmlParts()`‑samling relationen till den delen finns. Data på presentationsnivå är lämplig för dokument‑omfattande metadata, data på bildnivå för information som hör till en viss bild, och data på formnivå för metadata knuten till en enskild form.

### **Lista och granska alla anpassade XML‑delar**

Använd [`Presentation::getAllCustomXmlParts()`](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/#getAllCustomXmlParts) för att hämta alla anpassade XML‑delar från en presentation. Varje [`CustomXmlPart`](https://reference.aspose.com/slides/sv/php-java/aspose.slides/customxmlpart/) visar sitt identifierare, XML‑innehåll och associerade namnrymdsscheman.

Följande exempel listar alla anpassade XML‑delar och deras namnrymdsscheman:

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

[`CustomXmlPart::getNamespaceSchemas()`](https://reference.aspose.com/slides/sv/php-java/aspose.slides/customxmlpart/#getNamespaceSchemas) returnerar XML‑schemana som är associerade med den anpassade XML‑delen. Denna information kan vara användbar när man granskar presentationer som innehåller XML producerad av externa system.

### **Läs och uppdatera XML‑innehåll och ItemId**

Använd [`CustomXmlPart::getXmlAsString()`](https://reference.aspose.com/slides/sv/php-java/aspose.slides/customxmlpart/#getXmlAsString) och [`setXmlAsString()`](https://reference.aspose.com/slides/sv/php-java/aspose.slides/customxmlpart/#setXmlAsString) för att arbeta med XML som en UTF‑8‑sträng, eller [`getXmlData()`](https://reference.aspose.com/slides/sv/php-java/aspose.slides/customxmlpart/#getXmlData) och [`setXmlData()`](https://reference.aspose.com/slides/sv/php-java/aspose.slides/customxmlpart/#setXmlData) för att arbeta med de råa XML‑bytena.

Metoden [`CustomXmlPart::getItemId()`](https://reference.aspose.com/slides/sv/php-java/aspose.slides/customxmlpart/#getItemId) returnerar UUID‑n som identifierar den anpassade XML‑delen i Office Open XML‑dokumentet. Använd [`setItemId()`](https://reference.aspose.com/slides/sv/php-java/aspose.slides/customxmlpart/#setItemId) när en integration kräver ett nytt identifierare.

Följande exempel uppdaterar XML‑innehållet och identifieraren:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $customXmlPart = $presentation->getAllCustomXmlParts()[0];

    // Läs den aktuella XML som text.
    $currentXmlContent = $customXmlPart->getXmlAsString();
    echo $currentXmlContent . PHP_EOL;

    // Uppdatera XML som en UTF-8-sträng.
    $customXmlPart->setXmlAsString(
        '<metadata xmlns="urn:example:metadata">' .
            '<documentId>DOC-1001</documentId>' .
            '<workflowState>Approved</workflowState>' .
        '</metadata>'
    );

    // getXmlData tillhandahåller samma XML-innehåll som råa byte.
    $customXmlData = $customXmlPart->getXmlData();

    // Byt ut identifieraren när integrationen kräver det.
    $UUID = new JavaClass("java.util.UUID");
    $customXmlPart->setItemId($UUID->randomUUID());

    $presentation->save("updated_custom_xml.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

När du anropar `setXmlAsString` eller `setXmlData`, ange giltig, icke‑tom XML. Använd den ena representationen eller den andra beroende på om applikationen främst arbetar med strängar eller byte‑data.

### **Ta bort en anpassad XML‑del**

Aspose.Slides erbjuder flera sätt att ta bort anpassad XML‑data:

- [`CustomXmlPart::remove`](https://reference.aspose.com/slides/sv/php-java/aspose.slides/customxmlpart/#remove) tar bort den anpassade XML‑delen från presentationen.
- [`CustomXmlPartCollection::remove`](https://reference.aspose.com/slides/sv/php-java/aspose.slides/customxmlpartcollection/#remove) tar bort en specifik del från en samling av anpassade XML‑delar.
- [`CustomXmlPartCollection::removeAt`](https://reference.aspose.com/slides/sv/php-java/aspose.slides/customxmlpartcollection/#removeAt) tar bort delen på ett angivet samlingsindex.
- [`CustomXmlPartCollection::clear`](https://reference.aspose.com/slides/sv/php-java/aspose.slides/customxmlpartcollection/#clear) tar bort alla delar från en specifik samling.

Följande exempel tar bort en presentationsnivå‑XML‑del genom referens:

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

Om du redan har ett `CustomXmlPart` och vill ta bort den delen från presentationen i stället för att adressera en viss samling, anropa `$customXmlPart->remove()`.

Du kan också ta bort ett objekt efter index:

```php
$presentation->getCustomData()->getCustomXmlParts()->removeAt(0);
```

### **Rensa alla anpassade XML‑delar i en samling**

Använd `clear` när alla anpassade XML‑delar som är kopplade till ett specifikt presentationsobjekt ska tas bort.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $presentation->getSlides()->get_Item(0)->getCustomData()->getCustomXmlParts()->clear();

    $presentation->save("slide_custom_xml_cleared.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

`clear` påverkar endast den valda samlingen. Till exempel, att rensa en bilds samling rensar inte samlingarna på presentations‑ eller formnivå.

För att ta bort varje anpassad XML‑del i presentationen, iterera genom `getAllCustomXmlParts()` och ta bort varje del:

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

### **Hantera länkade eller delade anpassade XML‑delar**

I en Office Open XML‑presentation kan samma anpassade XML‑del refereras från mer än ett presentationsobjekt. Till exempel kan en befintlig fil innehålla relationer från flera bilder eller former till samma underliggande anpassade XML‑del.

En delad del bör behandlas som ett dataobjekt med flera referenser:

- Att uppdatera den med `setXmlAsString`, `setXmlData` eller `setItemId` ändrar den underliggande anpassade XML‑delen, så förändringen gäller överallt där delen refereras.
- `getItemId()` kan användas för att identifiera samma anpassade XML‑del vid granskning av objektnivå‑samlingar.
- Att ta bort en del från en specifik `getCustomXmlParts()`‑samling tar bort den från just den samlingen. Använd `CustomXmlPart::remove()` när själva delen ska tas bort från presentationen.
- Innan du raderar eller ersätter en delad del, inspektera objektnivå‑samlingarna för att avgöra om andra bilder eller former fortfarande refererar till den.

`add`‑överlagringarna skapar en ny anpassad XML‑del från XML‑innehåll; de accepterar inte en befintlig `CustomXmlPart`. Därför möts delade relationer oftast när presentationer som redan innehåller dem laddas.

Följande exempel granskar presentation‑, bild‑ och form‑samlingar efter `ItemId` och rapporterar delar som refereras från mer än en plats:

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

Denna typ av granskning är användbar innan du ändrar eller tar bort anpassade XML‑data i presentationer som skapats av externa system, eftersom samma metadatadel kan delta i mer än en relation.

## **Hämta taggvärden**

I Slides motsvarar en tagg metoden `DocumentProperties::getKeywords()`. Detta exempel visar hur man hämtar ett taggvärde med Aspose.Slides för PHP via Java för [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/):

```php
$presentation = new Presentation("presentation.pptx");
try {
    $keywords = $presentation->getDocumentProperties()->getKeywords();
} finally {
    $presentation->dispose();
}
```

## **Lägg till taggar i presentationer**

Aspose.Slides låter dig lägga till taggar i presentationer. En tagg består vanligtvis av två delar:

- namnet på en anpassad egenskap, till exempel `MyTag`;
- värdet på den anpassade egenskapen, till exempel `My Tag Value`.

Om du behöver klassificera presentationer enligt en viss regel eller egenskap kan du lägga till taggar för det ändamålet. Till exempel, om du vill kategorisera presentationer från Nordamerikanska länder kan du skapa en Nordamerikansk tagg och tilldela det relevanta landet som dess värde.

Detta exempel visar hur man lägger till en tagg i en [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/) med Aspose.Slides för PHP via Java:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $tags = $presentation->getCustomData()->getTags();
    $tags->set_Item("MyTag", "My Tag Value");
} finally {
    $presentation->dispose();
}
```

Taggar kan också sättas för en [Slide](https://reference.aspose.com/slides/sv/php-java/aspose.slides/slide/):

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $slide->getCustomData()->getTags()->set_Item("tag", "value");
} finally {
    $presentation->dispose();
}
```

Eller för en enskild [Shape](https://reference.aspose.com/slides/sv/php-java/aspose.slides/autoshape/):

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

### **Begränsningar**

Taggar som läggs till via samlingen `getCustomData()->getTags()` lagras endast i PowerPoint‑filen. De **överförs inte** till PDF‑taggstrukturen när presentationen exporteras till PDF. Följaktligen kan en anpassad identifierare som tilldelats som en tagg inte hämtas från den taggade PDF‑filen.

**Workaround**: Du kan lagra en anpassad identifierare i objektets **Alt‑Text** (t.ex. `$shape->setAlternativeText("MyId")`). Efter export till PDF kan Alt‑Texten dyka upp i PDF‑taggstrukturen.

## **FAQ**

**Kan jag ta bort alla taggar från en presentation, bild eller form i ett enda steg?**

Ja. [taggsamlingen](https://reference.aspose.com/slides/sv/php-java/aspose.slides/tagcollection/) stöder en [clear](https://reference.aspose.com/slides/sv/php-java/aspose.slides/tagcollection/#clear)‑operation som raderar alla nyckel‑värde‑par på en gång.

**Hur tar jag bort en enskild tagg efter namn utan att iterera över hela samlingen?**

Använd [remove(name)](https://reference.aspose.com/slides/sv/php-java/aspose.slides/tagcollection/#remove) på [taggsamlingen](https://reference.aspose.com/slides/sv/php-java/aspose.slides/tagcollection/) för att radera taggen efter dess nyckel.

**Hur kan jag hämta den kompletta listan över taggnamn för analys eller filtrering?**

Använd [getNamesOfTags](https://reference.aspose.com/slides/sv/php-java/aspose.slides/tagcollection/#getNamesOfTags) på [taggsamlingen](https://reference.aspose.com/slides/sv/php-java/aspose.slides/tagcollection/); den returnerar en array med alla taggnamn.

**Hur hittar jag alla anpassade XML‑delar oavsett var de lagras?**

Använd [`Presentation::getAllCustomXmlParts()`](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/#getAllCustomXmlParts) för att hämta alla anpassade XML‑delar i presentationen.

**Bör jag använda `getXmlAsString`/`setXmlAsString` eller `getXmlData`/`setXmlData` för att uppdatera en anpassad XML‑del?**

Använd `getXmlAsString` och `setXmlAsString` när applikationen arbetar med UTF‑8‑XML‑text. Använd `getXmlData` och `setXmlData` när XML redan finns som en byte‑array eller när binär bearbetning är mer praktisk. Båda representationerna hänvisar till XML‑innehållet i samma anpassade XML‑del.
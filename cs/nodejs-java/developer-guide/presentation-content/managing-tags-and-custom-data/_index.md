---
title: Správa tagů a vlastních dat v prezentacích pomocí JavaScriptu
linktitle: Tagy a vlastní data
type: docs
weight: 300
url: /cs/nodejs-java/managing-tags-and-custom-data/
keywords:
- vlastnosti dokumentu
- značka
- vlastní data
- vlastní XML
- vlastní XML část
- metadata XML
- ItemId
- přidat značku
- párové hodnoty
- PowerPoint
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Zjistěte, jak spravovat tagy a vlastní XML data v prezentacích PowerPoint pomocí Aspose.Slides pro Node.js přes Java, včetně přidávání, čtení, aktualizace, auditu a odstraňování vlastních XML částí."
---
## **Přehled**

Tento článek vysvětluje, jak Aspose.Slides pracuje s tagy a vlastními daty v prezentacích PowerPoint. Data specifická pro prezentaci lze uložit jako tagy nebo vlastní XML části. Tagy jsou jednoduché páry klíč‑hodnota jako řetězce, zatímco vlastní XML části mohou ukládat strukturovaná metadata a XML náklady specifické pro aplikaci.

Aspose.Slides poskytuje rozhraní API pro přidávání, čtení, aktualizaci, auditování a odstraňování vlastních XML částí na úrovni prezentace, snímku a tvaru. Vlastní XML části jsou užitečné pro integrace, které ukládají informace jako identifikátory správy dokumentů, stav pracovního toku, metadata souladnosti, data vazby šablon nebo jiná strukturovaná aplikační data uvnitř prezentace.

## **Ukládání dat v souborech prezentací**

Soubory PPTX — soubory s příponou `.pptx` — jsou uloženy ve formátu PresentationML, který je součástí specifikace Office Open XML. Office Open XML definuje strukturu balíčku a vztahy používané k uložení obsahu prezentace a souvisejících dat.

Prezentace obsahuje více částí propojených vztahy. Například část snímku obsahuje obsah jediného snímku a může mít explicitní vztahy k dalším částem definované dle ISO/IEC 29500.

Vlastní data lze uložit jako tagy ([TagCollection](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/tagcollection/)) nebo vlastní XML části ([CustomXmlPartCollection](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/customxmlpartcollection/)). Obě jsou dostupné přes třídu [`CustomData`](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/customdata/).

{{% alert color="primary" %}}
Tagy ukládají jednoduché řetězcové páry klíč‑hodnota. Vlastní XML části ukládají strukturovaná XML data a mohou být asociovány s prezentací, snímkem nebo tvarem.
{{% /alert %}}

## **Práce s vlastními XML částmi**

Metoda `getCustomXmlParts()` třídy [`CustomData`](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/customdata/) vrací kolekci vlastních XML částí spojených s konkrétním objektem prezentace. Například:

- `presentation.getCustomData().getCustomXmlParts()` obsahuje vlastní XML části spojené přímo s prezentací.
- `slide.getCustomData().getCustomXmlParts()` obsahuje vlastní XML části spojené s konkrétním snímkem.
- `shape.getCustomData().getCustomXmlParts()` obsahuje vlastní XML části spojené s konkrétním tvarem.

Použijte [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/), pokud potřebujete prozkoumat všechny vlastní XML části v prezentaci bez ohledu na to, kde jsou asociovány.

### **Přidání vlastní XML části do prezentace**

Použijte metodu `add` třídy [`CustomXmlPartCollection`](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/customxmlpartcollection/) k přidání XML dat do kolekce vlastních XML částí. XML musí být platné a nesmí být prázdné.

Následující příklad přidává strukturovaná metadata do kolekce vlastních dat na úrovni prezentace:

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

    // add přiřadí identifikátor automaticky. Nastavte konkrétní UUID pouze v případě potřeby.
    const itemId = java.callStaticMethodSync("java.util.UUID", "randomUUID");
    customXmlPart.setItemId(itemId);

    presentation.save("presentation_with_custom_xml.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Metoda `add` může také přijímat XML jako pole bajtů, což je užitečné, když je XML obsah již k dispozici v binární podobě.

### **Přidání vlastní XML části do snímku nebo tvaru**

Vlastní XML data mohou být asociována s konkrétním snímkem nebo tvarem namísto celé prezentace. To je užitečné, když metadata popisují jen jeden objekt, například klíč šablony, externí identifikátor záznamu nebo informace o vazbě.

Následující příklad přidává jednu vlastní XML část do snímku a další do tvaru:

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

Úroveň, na které je část přidána, určuje, která kolekce `getCustomData().getCustomXmlParts()` daného objektu obsahuje vztah k této části. Data na úrovni prezentace jsou vhodná pro metadata celého dokumentu, data na úrovni snímku pro informace patřící k určitému snímku a data na úrovni tvaru pro metadata svázaná s konkrétním tvarem.

### **Seznam a audit všech vlastních XML částí**

Použijte [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/) k získání všech vlastních XML částí z prezentace. Každý [`CustomXmlPart`](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/customxmlpart/) zpřístupňuje svůj identifikátor, XML obsah a související schémata jmenných prostor.

Následující příklad vypisuje všechny vlastní XML části a jejich schémata jmenných prostor:

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

`CustomXmlPart.getNamespaceSchemas()` vrací XML schémata spojená s vlastní XML částí. Tyto informace mohou být užitečné při auditu prezentací, které obsahují XML vytvořené externími systémy.

### **Čtení a aktualizace XML obsahu a ItemId**

Použijte `getXmlAsString()` a `setXmlAsString()` z [`CustomXmlPart`](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/customxmlpart/) k práci s XML jako řetězcem UTF‑8, nebo `getXmlData()` a `setXmlData()` k práci s nepracovanými bajty XML.

Metoda `getItemId()` vrací UUID, který identifikuje vlastní XML část v dokumentu Office Open XML. Použijte `setItemId()`, pokud integrace vyžaduje nový identifikátor.

Následující příklad aktualizuje obsah XML a identifikátor:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const customXmlPart = presentation.getAllCustomXmlParts()[0];

    // Přečtěte aktuální XML jako text.
    const currentXmlContent = customXmlPart.getXmlAsString();
    console.log(currentXmlContent);

    // Aktualizujte XML jako řetězec UTF-8.
    customXmlPart.setXmlAsString(
        '<metadata xmlns="urn:example:metadata">' +
            '<documentId>DOC-1001</documentId>' +
            '<workflowState>Approved</workflowState>' +
        '</metadata>');

    // getXmlData poskytuje stejný XML obsah jako surové bajty.
    const customXmlData = customXmlPart.getXmlData();
    console.log(Buffer.from(customXmlData).toString("utf8"));

    // Nahraďte identifikátor, pokud to vyžaduje integrace.
    const itemId = java.callStaticMethodSync("java.util.UUID", "randomUUID");
    customXmlPart.setItemId(itemId);

    presentation.save("updated_custom_xml.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Při volání `setXmlAsString` nebo `setXmlData` poskytněte platné, neprázdné XML. Použijte jedno z těchto reprezentací v závislosti na tom, zda aplikace pracuje převážně s řetězci nebo s bajtovými daty.

### **Odstranění vlastní XML části**

Aspose.Slides poskytuje několik způsobů, jak odstranit vlastní XML data:

- [`CustomXmlPart.remove`](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/customxmlpart/) odstraňuje vlastní XML část z prezentace.
- [`CustomXmlPartCollection.remove`](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/customxmlpartcollection/) odstraňuje konkrétní část z kolekce vlastních XML částí.
- [`CustomXmlPartCollection.removeAt`](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/customxmlpartcollection/) odstraňuje část na zadaném indexu kolekce.
- [`CustomXmlPartCollection.clear`](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/customxmlpartcollection/) odstraňuje všechny části z konkrétní kolekce.

Následující příklad odstraňuje jednu vlastní XML část na úrovni prezentace podle reference:

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

Pokud již máte `CustomXmlPart` a chcete tuto část odstranit z prezentace místo adresování konkrétní kolekce, zavolejte `customXmlPart.remove()`.

Můžete také odstranit položku podle indexu:

```javascript
presentation.getCustomData().getCustomXmlParts().removeAt(0);
```

### **Vymazání všech vlastních XML částí z kolekce**

Použijte `clear`, pokud mají být odebrány všechny vlastní XML části spojené s konkrétním objektem prezentace.

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

`clear` ovlivňuje pouze vybranou kolekci. Například vymazání kolekce snímku nevymaže kolekce na úrovni prezentace nebo tvaru.

Chcete‑li odstranit každou vlastní XML část v prezentaci, projděte `getAllCustomXmlParts()` a odstraňte každou část:

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

### **Zpracování propojených nebo sdílených vlastních XML částí**

V prezentaci Office Open XML může být stejná vlastní XML část odkazována z více než jednoho objektu prezentace. Například existující soubor může obsahovat vztahy z více snímků nebo tvarů k té samé podkladové vlastní XML části.

Sdílená část by měla být považována za jeden datový objekt s více odkazy:

- Aktualizace pomocí `setXmlAsString`, `setXmlData` nebo `setItemId` mění podkladovou vlastní XML část, takže změna se projeví kdekoliv je část odkazována.
- `getItemId()` lze použít k identifikaci stejné vlastní XML části při auditu kolekcí na úrovni objektu.
- Odstranění části z konkrétní kolekce `getCustomXmlParts()` ji odebere z této kolekce. Použijte `CustomXmlPart.remove()`, pokud má být část samotná odstraněna z prezentace.
- Před smazáním nebo nahrazením sdílené části zkontrolujte kolekce na úrovni objektu, abyste zjistili, zda ji stále odkazují jiné snímky či tvary.

Přetížení `add` vytváří novou vlastní XML část z XML obsahu; nepřijímají existující `CustomXmlPart`. Proto jsou sdílené vztahy nejčastěji zaznamenány při načítání prezentací, které je již obsahují.

Následující příklad provádí audit kolekcí na úrovni prezentace, snímku a tvaru podle `ItemId` a hlásí části odkazované z více než jednoho místa:

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

Tento typ auditu je užitečný před úpravou nebo smazáním vlastních XML dat v prezentacích vytvořených externími systémy, protože stejná metadata část může být součástí více než jednoho vztahu.

## **Získání hodnot tagů**

V Slides odpovídá tag metodě `DocumentProperties.getKeywords()`. Tento ukázkový kód ukazuje, jak získat hodnotu tagu pomocí Aspose.Slides pro Node.js přes Java pro [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/):

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const keywords = presentation.getDocumentProperties().getKeywords();
} finally {
    presentation.dispose();
}
```

## **Přidání tagů do prezentací**

Aspose.Slides vám umožňuje přidávat tagy do prezentací. Tag obvykle sestává ze dvou položek:
- název vlastní vlastnosti, například `MyTag`;
- hodnota vlastní vlastnosti, například `My Tag Value`.

Pokud potřebujete klasifikovat prezentace podle konkrétního pravidla nebo vlastnosti, můžete přidat tagy pro tento účel. Například pokud chcete kategorizovat prezentace ze zemí Severní Ameriky, můžete vytvořit tag Severní Amerika a přiřadit mu jako hodnotu příslušnou zemi.

Tento ukázkový kód ukazuje, jak přidat tag do [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/) pomocí Aspose.Slides pro Node.js přes Java:

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

Tagy mohou být také nastaveny pro [Slide](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/slide/):

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

Nebo pro jednotlivý [Shape](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/autoshape/):

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

### **Omezení**

Tagy přidané prostřednictvím kolekce `getCustomData().getTags()` jsou uloženy pouze v souboru PowerPoint. Při exportu prezentace do PDF **nejsou** převedeny do struktury tagů PDF. V důsledku toho nelze vlastní identifikátor přiřazený jako tag získat z označeného PDF.

**Obejití**: Můžete uložit vlastní identifikátor do **Alt Text** objektu (například `shape.setAlternativeText("MyId")`). Po exportu do PDF se Alt Text může objevit ve struktuře tagů PDF.

## **Často kladené otázky**

**Mohu odstranit všechny tagy z prezentace, snímku nebo tvaru najednou?**

Ano. [Kolekce tagů](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/tagcollection/) podporuje operaci [clear](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/tagcollection/), která najednou smaže všechny páry klíč‑hodnota.

**Jak mohu smazat jeden tag podle jeho názvu bez procházení celé kolekce?**

Použijte `remove(name)` na [kolekci tagů](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/tagcollection/) k smazání tagu podle jeho klíče.

**Jak mohu získat úplný seznam názvů tagů pro analytiku nebo filtrování?**

Použijte `getNamesOfTags()` na [kolekci tagů](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/tagcollection/); vrací pole všech názvů tagů.

**Jak mohu najít všechny vlastní XML části bez ohledu na to, kde jsou uloženy?**

Použijte [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/) k získání všech vlastních XML částí v prezentaci.

**Mám pro aktualizaci vlastní XML části použít `getXmlAsString`/`setXmlAsString` nebo `getXmlData`/`setXmlData`?**

Použijte `getXmlAsString` a `setXmlAsString`, když aplikace pracuje s XML textem v UTF‑8. Použijte `getXmlData` a `setXmlData`, když je XML již k dispozici jako pole bajtů nebo je upřednostněno binární zpracování. Obě reprezentace odkazují na XML obsah téže vlastní XML části.
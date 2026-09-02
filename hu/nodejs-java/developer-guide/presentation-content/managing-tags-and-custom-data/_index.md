---
title: Címkék és egyedi adatok kezelése prezentációkban JavaScript használatával
linktitle: Címkék és egyedi adatok
type: docs
weight: 300
url: /hu/nodejs-java/managing-tags-and-custom-data/
keywords:
- dokumentumtulajdonságok
- címke
- egyedi adat
- egyedi XML
- egyedi XML rész
- XML metaadat
- ItemId
- címke hozzáadása
- páros értékek
- PowerPoint
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Ismerje meg, hogyan kezelheti a címkéket és az egyedi XML adatokat PowerPoint prezentációkban az Aspose.Slides for Node.js via Java segítségével, beleértve a hozzáadást, olvasást, frissítést, auditálást és az egyedi XML részek eltávolítását."
---
## **Áttekintés**

Ez a cikk bemutatja, hogy az Aspose.Slides hogyan dolgozik címkékkel és egyedi adatokkal a PowerPoint előadásokban. Az előadáshoz kapcsolódó adatokat címkék vagy egyedi XML részek formájában lehet tárolni. A címkék egyszerű kulcs-érték karakterlánc párok, míg az egyedi XML részek strukturált metaadatokat és alkalmazás‑specifikus XML terhelést tárolhatnak.

Az Aspose.Slides API‑kat kínál egyedi XML részek hozzáadásához, olvasásához, frissítéséhez, auditálásához és eltávolításához az előadás, dia és alakzat szintjén. Az egyedi XML részek hasznosak olyan integrációk számára, amelyek információkat tárolnak, például dokumentumkezelési azonosítókat, munkafolyamat‑állapotot, megfelelőségi metaadatokat, sablon‑kapcsolási adatokat vagy más strukturált alkalmazási adatokat az előadásban.

## **Adattárolás az előadások fájljaiban**

A PPTX fájlok – a `.pptx` kiterjesztésű fájlok – a PresentationML formátumban tárolódnak, amely az Office Open XML specifikáció része. Az Office Open XML meghatározza a csomagszerkezetet és a kapcsolódásokat, amelyeket a prezentáció tartalmának és kapcsolódó adatainak tárolására használnak.

Egy prezentáció több, kapcsolatokkal összekapcsolt részt tartalmaz. Például egy diarész egyetlen dia tartalmát tartalmazza, és kifejezett kapcsolatokat rendelhet más részekhez, ahogy azt az ISO/IEC 29500 definiálja.

Egyedi adatokat tárolhat címkék ([TagCollection](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/tagcollection/)) vagy egyedi XML részek ([CustomXmlPartCollection](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/customxmlpartcollection/)) formájában. Mindkettő elérhető a [`CustomData`](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/customdata/) osztályon keresztül.

{{% alert color="primary" %}}
A címkék egyszerű karakterlánc kulcs‑érték párokat tárolnak. Az egyedi XML részek strukturált XML adatot tárolnak, és társíthatók egy prezentációhoz, diához vagy alakzathoz.
{{% /alert %}}

## **Egyedi XML részek kezelése**

A [`CustomData`](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/customdata/) `getCustomXmlParts()` metódusa visszaadja az adott prezentációs objektumhoz kapcsolt egyedi XML részek gyűjteményét. Például:

- `presentation.getCustomData().getCustomXmlParts()` tartalmazza a prezentációhoz közvetlenül kapcsolt egyedi XML részeket.
- `slide.getCustomData().getCustomXmlParts()` tartalmazza egy adott diahoz kapcsolt egyedi XML részeket.
- `shape.getCustomData().getCustomXmlParts()` tartalmazza egy adott alakzathoz kapcsolt egyedi XML részeket.

Használja a [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) metódust, ha az összes egyedi XML részt szeretné megtekinteni a prezentációban, függetlenül attól, hogy hol vannak társítva.

### **Egyedi XML rész hozzáadása egy prezentációhoz**

Használja a [`CustomXmlPartCollection`](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/customxmlpartcollection/) `add` metódusát az XML adatok hozzáadásához egy egyedi XML rész gyűjteményéhez. Az XML‑nek érvényesnek és nem üresnek kell lennie.

A következő példa strukturált metaadatokat ad hozzá a prezentáció szintű egyedi adatgyűjteményhez:

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

    // az add automatikusan egy azonosítót rendel. Egy konkrét UUID-t csak akkor állíts be, ha szükséges.
    const itemId = java.callStaticMethodSync("java.util.UUID", "randomUUID");
    customXmlPart.setItemId(itemId);

    presentation.save("presentation_with_custom_xml.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az `add` metódus XML‑t is elfogadhat bájt tömbként, ami hasznos, ha az XML tartalom már bináris formában elérhető.

### **Egyedi XML rész hozzáadása egy diára vagy alakzatra**

Egyedi XML adatokat egy adott diához vagy alakzathoz is lehet társítani a teljes prezentáció helyett. Ez akkor hasznos, ha a metaadat csak egy objektumot ír le, például egy sablon kulcsot, külső rekordazonosítót vagy kötési információt.

A következő példa egy egyedi XML részt ad egy diához és egy másikat egy alakzathoz:

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

Az a szint, amelyen a rész hozzá van adva, meghatározza, hogy melyik objektum `getCustomData().getCustomXmlParts()` gyűjteménye tartalmazza a részhez tartozó kapcsolatot. A prezentáció szintű adatok a dokumentum egészére kiterjedő metaadatokhoz megfelelőek, a dia szintű adatok egy adott dia információihoz, a alakzat szintű adatok pedig egy egyedi alakzathoz kapcsolódó metaadatokhoz.

### **Az összes egyedi XML rész listázása és auditálása**

Használja a [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) metódust az összes egyedi XML rész lekérdezéséhez a prezentációból. Minden [`CustomXmlPart`](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/customxmlpart/) felfedi az azonosítóját, XML tartalmát és a társított névtér sémákat.

A következő példa felsorolja az összes egyedi XML részt és azok névtér sémáit:

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

`CustomXmlPart.getNamespaceSchemas()` visszaadja az egyedi XML részhez kapcsolt XML sémákat. Ez az információ hasznos lehet akkor, amikor olyan prezentációkat auditálunk, amelyek külső rendszerek által előállított XML‑t tartalmaznak.

### **XML tartalom és ItemId olvasása és frissítése**

Használja a `getXmlAsString()` és `setXmlAsString()` metódusokat a [`CustomXmlPart`](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/customxmlpart/)‑ból az XML UTF‑8 szövegként való kezeléshez, vagy a `getXmlData()` és `setXmlData()` metódusokat a nyers XML bájtok kezeléséhez.

A `getItemId()` metódus visszaadja azt a UUID‑t, amely az egyedi XML részt az Office Open XML dokumentumban azonosítja. Használja a `setItemId()`‑t, ha egy integráció új azonosítót igényel.

A következő példa frissíti az XML tartalmat és az azonosítót:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const customXmlPart = presentation.getAllCustomXmlParts()[0];

    // Olvasd be az aktuális XML-t szövegként.
    const currentXmlContent = customXmlPart.getXmlAsString();
    console.log(currentXmlContent);

    // Frissítsd az XML-t UTF-8 karakterláncként.
    customXmlPart.setXmlAsString(
        '<metadata xmlns="urn:example:metadata">' +
            '<documentId>DOC-1001</documentId>' +
            '<workflowState>Approved</workflowState>' +
        '</metadata>');

    // A getXmlData ugyanazt az XML tartalmat adja nyers bájtokként.
    const customXmlData = customXmlPart.getXmlData();
    console.log(Buffer.from(customXmlData).toString("utf8"));

    // Cseréld ki az azonosítót, ha az integráció megköveteli.
    const itemId = java.callStaticMethodSync("java.util.UUID", "randomUUID");
    customXmlPart.setItemId(itemId);

    presentation.save("updated_custom_xml.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`setXmlAsString` vagy `setXmlData` hívásakor adjon meg érvényes, nem üres XML‑t. Használja az egyik vagy a másik ábrázolást attól függően, hogy az alkalmazás elsősorban szövegekkel vagy bájt adatokkal dolgozik.

### **Egyedi XML rész eltávolítása**

Az Aspose.Slides több módot kínál az egyedi XML adatok eltávolítására:

- [`CustomXmlPart.remove`](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/customxmlpart/) eltávolítja az egyedi XML részt a prezentációból.
- [`CustomXmlPartCollection.remove`](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/customxmlpartcollection/) eltávolít egy adott részt az egyedi XML rész gyűjteményből.
- [`CustomXmlPartCollection.removeAt`](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/customxmlpartcollection/) eltávolítja a részt egy megadott gyűjteményindexnél.
- [`CustomXmlPartCollection.clear`](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/customxmlpartcollection/) eltávolítja az összes részt egy adott gyűjteményből.

A következő példa referencia alapján eltávolít egy prezentáció szintű egyedi XML részt:

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

Ha már rendelkezik egy `CustomXmlPart`‑sal, és a prezentációból szeretné eltávolítani azt egy adott gyűjtemény helyett, hívja a `customXmlPart.remove()`‑t.

Elemet index szerint is eltávolíthat:

```javascript
presentation.getCustomData().getCustomXmlParts().removeAt(0);
```

### **Az összes egyedi XML rész törlése egy gyűjteményből**

Használja a `clear` metódust, ha egy adott prezentációs objektumhoz kapcsolt összes egyedi XML részt el kell távolítani.

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

A `clear` csak a kiválasztott gyűjteményre hat. Például egy dia gyűjteményének törlése nem törli a prezentáció szintű vagy alakzat szintű gyűjteményeket.

Az összes egyedi XML rész eltávolításához a prezentációban, iteráljon a `getAllCustomXmlParts()`‑en és távolítsa el minden részt:

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

### **Összekapcsolt vagy megosztott egyedi XML részek kezelése**

Egy Office Open XML prezentációban ugyanaz a egyedi XML rész több prezentációs objektumról is hivatkozható. Például egy meglévő fájl tartalmazhat kapcsolatokat több diáról vagy alakzatról ugyanahhoz az alapul szolgáló egyedi XML részhez.

Egy megosztott részt egy adatobjektumként kell kezelni több referenciával:

- Az `setXmlAsString`, `setXmlData` vagy `setItemId` használatával történő frissítés módosítja az alapul lévő egyedi XML részt, így a változás minden hivatkozásnál érvényesül.
- A `getItemId()` használható ugyanazon egyedi XML rész azonosítására objektumszintű gyűjtemények auditálásakor.
- Egy rész eltávolítása egy adott `getCustomXmlParts()` gyűjteményből eltávolítja azt a gyűjteményből. Használja a `CustomXmlPart.remove()`‑t, ha magát a részt el kell távolítani a prezentációból.
- A megosztott rész törlése vagy cseréje előtt ellenőrizze az objektumszintű gyűjteményeket, hogy megállapítsa, más diák vagy alakzatok még hivatkoznak‑e rá.

Az `add` túlterhelések új egyedi XML részt hoznak létre XML tartalomból; nem fogadják el a meglévő `CustomXmlPart`‑ot. Ezért a megosztott kapcsolatok leggyakrabban olyan prezentációk betöltésekor fordulnak elő, amelyek már tartalmazzák őket.

A következő példa auditálja a prezentáció‑, dia‑ és alakzat‑szintű gyűjteményeket `ItemId` alapján, és jelentéseket készít azokról a részekről, amelyek több helyről is hivatkozottak:

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

Ez a fajta audit hasznos, mielőtt módosítaná vagy törölné az egyedi XML adatokat külső rendszerek által létrehozott prezentációkban, mivel ugyanaz a metaadat rész több kapcsolaton is részt vehet.

## **Címkék értékeinek lekérése**

A diákban egy címke a `DocumentProperties.getKeywords()` metódusnak felel meg. Ez a mintakód bemutatja, hogyan lehet egy címke értékét lekérni az Aspose.Slides for Node.js via Java segítségével a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) esetén:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const keywords = presentation.getDocumentProperties().getKeywords();
} finally {
    presentation.dispose();
}
```

## **Címkék hozzáadása a prezentációkhoz**

Az Aspose.Slides lehetővé teszi címkék hozzáadását a prezentációkhoz. Egy címke általában két elemből áll:

- egy egyedi tulajdonság neve, például `MyTag`;
- az egyedi tulajdonság értéke, például `My Tag Value`.

Ha a prezentációkat egy konkrét szabály vagy tulajdonság alapján szeretné osztályozni, hozzáadhat címkéket erre a célra. Például, ha az észak‑amerikai országokból származó prezentációkat szeretné kategorizálni, létrehozhat egy „North American” címkét, és a megfelelő országot adhatja értékként.

Ez a mintakód bemutatja, hogyan adhat hozzá egy címkét egy [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) objektumhoz az Aspose.Slides for Node.js via Java használatával:

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

Címkéket lehet beállítani egy [Slide](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/slide/) esetén is:

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

Vagy egy egyéni [Shape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/autoshape/) esetén:

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

### **Korlátozások**

A `getCustomData().getTags()` gyűjteményen keresztül hozzáadott címkék csak a PowerPoint fájlban tárolódnak. **Nem** kerülnek át a PDF címke struktúrába, amikor a prezentációt PDF‑be exportálják. Ennek következtében egy címkeként hozzárendelt egyedi azonosítót nem lehet lekérni a címkézett PDF‑ből.

**Megoldás**: Egyedi azonosítót tárolhat az objektum **Alt Text**‑ében (például `shape.setAlternativeText("MyId")`). PDF‑be exportálás után az Alt Text megjelenhet a PDF címke struktúrájában.

## **GYIK**

**Eltávolíthatok minden címkét egy prezentációból, diából vagy alakzatból egyetlen műveletben?**

Igen. A [tag collection](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/tagcollection/) támogatja a [clear](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/tagcollection/) műveletet, amely egy időben törli az összes kulcs‑érték párt.

**Hogyan törölhetek egyetlen címkét a nevével anélkül, hogy végig iterálnék az egész gyűjteményen?**

Használja a `remove(name)` metódust a [tag collection](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/tagcollection/)‑n, hogy a kulcs alapján törölje a címkét.

**Hogyan szerezhetem meg a címkék nevének teljes listáját elemzés vagy szűrés céljából?**

Használja a `getNamesOfTags()` metódust a [tag collection](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/tagcollection/)‑on; ez egy tömböt ad vissza az összes címkenévvel.

**Hogyan találhatom meg az összes egyedi XML részt függetlenül attól, hogy hol tárolódnak?**

Használja a [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) metódust, hogy lekérje az összes egyedi XML részt a prezentációban.

**Használjam a `getXmlAsString`/`setXmlAsString` vagy a `getXmlData`/`setXmlData` metódusokat egy egyedi XML rész frissítéséhez?**

Használja a `getXmlAsString` és `setXmlAsString` metódusokat, ha az alkalmazás UTF‑8 XML szöveggel dolgozik. Használja a `getXmlData` és `setXmlData` metódusokat, ha az XML már bájt tömbként érhető el, vagy ha a bináris feldolgozás kényelmesebb. Mindkét ábrázolás ugyanannak az egyedi XML résznek az XML tartalmára vonatkozik.
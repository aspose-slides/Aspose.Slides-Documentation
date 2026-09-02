---
title: "Címkék és egyéni adatok kezelése prezentációkban PHP-vel"
linktitle: "Címkék és egyéni adatok"
type: docs
weight: 300
url: /hu/php-java/managing-tags-and-custom-data/
keywords:
- dokumentumtulajdonságok
- címke
- egyéni adat
- egyéni XML
- egyéni XML rész
- XML metaadat
- ItemId
- címke hozzáadása
- pár értékek
- PowerPoint
- prezentáció
- PHP
- Aspose.Slides
description: "Ismerje meg, hogyan kezelhetők a címkék és egyéni XML adatok PowerPoint-prezentációkban az Aspose.Slides for PHP via Java segítségével, beleértve a címkék hozzáadását, olvasását, frissítését, auditálását és az egyéni XML részek eltávolítását."
---
## **Áttekintés**

Ez a cikk azt magyarázza, hogyan működik az Aspose.Slides címkékkel és egyéni adatokkal a PowerPoint‑prezentációkban. A prezentációra vonatkozó adatokat címkék vagy egyéni XML részek formájában tárolhatja. A címkék egyszerű kulcs‑érték sztringpárok, míg az egyéni XML részek strukturált metaadatokat és alkalmazás‑specifikus XML terheket tárolhatnak.

Az Aspose.Slides API‑kat biztosít egyéni XML részek hozzáadásához, olvasásához, frissítéséhez, auditálásához és eltávolításához a prezentáció, dia és alakzat szintjén. Az egyéni XML részek hasznosak integrációk számára, amelyek információkat tárolnak, például dokumentumkezelési azonosítókat, munkafolyamat‑állapotot, megfelelőségi metaadatokat, sablon‑kötési adatokat vagy egyéb strukturált alkalmazásadatokat a prezentációban.

## **Adattárolás a prezentációs fájlokban**

A PPTX fájlok – a `.pptx` kiterjesztésű fájlok – a PresentationML formátumban tárolódnak, amely az Office Open XML specifikáció része. Az Office Open XML meghatározza a csomagstruktúrát és a kapcsolatokat, amelyek a prezentációtartalom és a kapcsolódó adatok tárolására szolgálnak.

Egy prezentáció több részből áll, amelyeket kapcsolatok kötnek össze. Például egy diarész tartalmaz egyetlen dia tartalmát, és explicite kapcsolatokkal rendelkezhet más részekhez, ahogy azt az ISO/IEC 29500 definiálja.

Az egyéni adat tárolható címkeként ([TagCollection](https://reference.aspose.com/slides/hu/php-java/aspose.slides/tagcollection/)) vagy egyéni XML részként ([CustomXmlPartCollection](https://reference.aspose.com/slides/hu/php-java/aspose.slides/customxmlpartcollection/)). Mindkettő elérhető a [`CustomData`](https://reference.aspose.com/slides/hu/php-java/aspose.slides/customdata/) osztályon keresztül.

{{% alert color="primary" %}}
A címkék egyszerű sztring kulcs‑érték párokat tárolnak. Az egyéni XML részek strukturált XML adatokat tárolnak, és társíthatók egy prezentációhoz, diához vagy alakzathoz.
{{% /alert %}}

## **Egyéni XML részek kezelése**

A [`CustomData::getCustomXmlParts()`](https://reference.aspose.com/slides/hu/php-java/aspose.slides/customdata/#getCustomXmlParts) metódus visszaadja az adott prezentációs objektumhoz társított egyéni XML részek gyűjteményét. Például:

- `$presentation->getCustomData()->getCustomXmlParts()` a prezentációhoz tartozó egyéni XML részeket tartalmazza.
- `$slide->getCustomData()->getCustomXmlParts()` egy adott diához társított egyéni XML részeket tartalmazza.
- `$shape->getCustomData()->getCustomXmlParts()` egy adott alakzathoz társított egyéni XML részeket tartalmazza.

Használja a [`Presentation::getAllCustomXmlParts()`](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/#getAllCustomXmlParts) metódust, amikor az összes egyéni XML részt szeretné megvizsgálni a prezentációban, függetlenül attól, hogy hol vannak társítva.

### **Egyéni XML rész hozzáadása a prezentációhoz**

Használja a [`CustomXmlPartCollection::add`](https://reference.aspose.com/slides/hu/php-java/aspose.slides/customxmlpartcollection/#add) metódust XML adat hozzáadásához egy egyéni XML részgyűjteményhez. Az XML-nek érvényesnek és nem üresnek kell lennie.

A következő példa strukturált metaadatokat ad hozzá a prezentáció‑szintű egyéni adatgyűjteményhez:
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

    // az add automatikusan hozzárendel egy azonosítót. Egy konkrét UUID-t csak szükség esetén állíts be.
    $UUID = new JavaClass("java.util.UUID");
    $customXmlPart->setItemId($UUID->randomUUID());

    $presentation->save("presentation_with_custom_xml.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Az `add` metódus XML‑t is elfogadhat bájt‑tömbként vagy bemeneti streamként, ami akkor hasznos, ha az XML‑tartalom már bináris formában áll rendelkezésre.

### **Egyéni XML rész hozzáadása diához vagy alakzathoz**

Az egyéni XML adat társítható egy adott diához vagy alakzathoz a teljes prezentáció helyett. Ez akkor hasznos, ha a metaadat csak egy objektumot ír le, például egy sablonkulcsot, egy külső rekord azonosítót vagy kötési információt.

A következő példa egy egyéni XML részt ad hozzá egy diához, és egy másikat egy alakzathoz:
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

Az a szint, amelyen egy részt hozzáadnak, meghatározza, hogy mely objektum `getCustomData()->getCustomXmlParts()` gyűjteménye tartalmazza a részhez tartozó kapcsolatot. A prezentáció‑szintű adat a dokumentum‑széles metaadatokhoz megfelelő, a dia‑szintű adat egy adott dia információihoz, a alakzat‑szintű adat pedig egyetlen alakzathoz kapcsolódó metaadatokhoz.

### **Az összes egyéni XML rész felsorolása és auditálása**

Használja a [`Presentation::getAllCustomXmlParts()`](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/#getAllCustomXmlParts) metódust az összes egyéni XML rész lekéréséhez egy prezentációból. Minden [`CustomXmlPart`](https://reference.aspose.com/slides/hu/php-java/aspose.slides/customxmlpart/) tartalmazza az azonosítóját, az XML tartalmat és a kapcsolódó névtér‑sémákat.

A következő példa felsorolja az összes egyéni XML részt és azok névtér‑sémáit:
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

A [`CustomXmlPart::getNamespaceSchemas()`](https://reference.aspose.com/slides/hu/php-java/aspose.slides/customxmlpart/#getNamespaceSchemas) visszaadja az egyéni XML részhez kapcsolódó XML sémákat. Ez az információ hasznos lehet olyan prezentációk auditálása során, amelyek külső rendszerek által generált XML‑t tartalmaznak.

### **XML tartalom és ItemId olvasása és frissítése**

Használja a [`CustomXmlPart::getXmlAsString()`](https://reference.aspose.com/slides/hu/php-java/aspose.slides/customxmlpart/#getXmlAsString) és a [`setXmlAsString()`](https://reference.aspose.com/slides/hu/php-java/aspose.slides/customxmlpart/#setXmlAsString) metódusokat XML UTF‑8 szövegként való kezeléséhez, vagy a [`getXmlData()`](https://reference.aspose.com/slides/hu/php-java/aspose.slides/customxmlpart/#getXmlData) és a [`setXmlData()`](https://reference.aspose.com/slides/hu/php-java/aspose.slides/customxmlpart/#setXmlData) metódusokat a nyers XML bájtokkal való munkahez.

A [`CustomXmlPart::getItemId()`](https://reference.aspose.com/slides/hu/php-java/aspose.slides/customxmlpart/#getItemId) metódus visszaadja azt a UUID‑t, amely az egyéni XML részt az Office Open XML dokumentumban azonosítja. Használja a [`setItemId()`](https://reference.aspose.com/slides/hu/php-java/aspose.slides/customxmlpart/#setItemId) metódust, ha egy integrációnak új azonosítóra van szüksége.

A következő példa frissíti az XML tartalmat és az azonosítót:
```php
$presentation = new Presentation("presentation.pptx");
try {
    $customXmlPart = $presentation->getAllCustomXmlParts()[0];

    // Olvasd be a jelenlegi XML-t szövegként.
    $currentXmlContent = $customXmlPart->getXmlAsString();
    echo $currentXmlContent . PHP_EOL;

    // Frissítsd az XML-t UTF-8 sztringként.
    $customXmlPart->setXmlAsString(
        '<metadata xmlns="urn:example:metadata">' .
            '<documentId>DOC-1001</documentId>' .
            '<workflowState>Approved</workflowState>' .
        '</metadata>'
    );

    // a getXmlData ugyanazt az XML tartalmat nyers bájtokként adja.
    $customXmlData = $customXmlPart->getXmlData();

    // Cseréld le az azonosítót, ha az integráció megköveteli.
    $UUID = new JavaClass("java.util.UUID");
    $customXmlPart->setItemId($UUID->randomUUID());

    $presentation->save("updated_custom_xml.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

`setXmlAsString` vagy `setXmlData` hívásakor adjon meg érvényes, nem üres XML‑t. Az egyik vagy a másik ábrázolást használja attól függően, hogy az alkalmazás főként sztringekkel vagy bájt‑adatokkal dolgozik.

### **Egyéni XML rész eltávolítása**

Az Aspose.Slides több módot biztosít egyéni XML adatok eltávolítására:

- [`CustomXmlPart::remove`](https://reference.aspose.com/slides/hu/php-java/aspose.slides/customxmlpart/#remove) eltávolítja az egyéni XML részt a prezentációból.
- [`CustomXmlPartCollection::remove`](https://reference.aspose.com/slides/hu/php-java/aspose.slides/customxmlpartcollection/#remove) egy adott részt távolít el egy egyéni XML részgyűjteményből.
- [`CustomXmlPartCollection::removeAt`](https://reference.aspose.com/slides/hu/php-java/aspose.slides/customxmlpartcollection/#removeAt) egy megadott indexű részt távolít el a gyűjteményből.
- [`CustomXmlPartCollection::clear`](https://reference.aspose.com/slides/hu/php-java/aspose.slides/customxmlpartcollection/#clear) az összes részt eltávolítja egy adott gyűjteményből.

A következő példa eltávolít egy prezentáció‑szintű egyéni XML részt hivatkozás alapján:
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

Ha már rendelkezik egy `CustomXmlPart` objektummal, és a prezentációból szeretné eltávolítani azt egy adott gyűjtemény helyett, hívja meg a `$customXmlPart->remove()` metódust.

Egy elemet index alapján is eltávolíthat:
```php
$presentation->getCustomData()->getCustomXmlParts()->removeAt(0);
```

### **Az összes egyéni XML rész törlése egy gyűjteményből**

Használja a `clear` metódust, ha egy adott prezentációs objektumhoz tartozó összes egyéni XML részt el szeretne távolítani.
```php
$presentation = new Presentation("presentation.pptx");
try {
    $presentation->getSlides()->get_Item(0)->getCustomData()->getCustomXmlParts()->clear();

    $presentation->save("slide_custom_xml_cleared.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

A `clear` csak a kiválasztott gyűjteményre hat. Például egy dia gyűjteményének törlése nem törli a prezentáció‑szintű vagy alakzat‑szintű gyűjteményeket.

A prezentáció minden egyéni XML részének eltávolításához iteráljon a `getAllCustomXmlParts()` gyűjteményen, és távolítsa el minden részt:
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

### **Kapcsolt vagy megosztott egyéni XML részek kezelése**

Office Open XML prezentációban ugyanaz a egyéni XML rész több prezentációs objektumtól is hivatkozhat. Például egy meglévő fájl tartalmazhat kapcsolatokat több diáról vagy alakzatról ugyanahhoz az alapszintű egyéni XML részhez.

Egy megosztott részt több hivatkozással rendelkező adatobjektumként kell kezelni:

- `setXmlAsString`, `setXmlData` vagy `setItemId` használatával történő frissítés megváltoztatja az alapszintű egyéni XML részt, így a módosítás minden hivatkozásnál érvényesül.
- `getItemId()` használható ugyanazon egyéni XML rész azonosítására az objektumszintű gyűjtemények auditálása során.
- Egy rész eltávolítása egy adott `getCustomXmlParts()` gyűjteményből csak azt a gyűjteményt érinti. Használja a `CustomXmlPart::remove()` metódust, ha magát a részt el szeretné távolítani a prezentációból.
- Megosztott rész törlése vagy cseréje előtt vizsgálja meg az objektumszintű gyűjteményeket, hogy kiderüljön, más diák vagy alakzatok még hivatkoznak‑e rá.

Az `add` túlterhelések új egyéni XML részt hoznak létre XML‑tartalomból; nem fogadják el egy meglévő `CustomXmlPart` objektumot. Így a megosztott kapcsolatok leggyakrabban akkor fordulnak elő, amikor olyan prezentációkat töltenek be, amelyek már tartalmazzák őket.

A következő példa auditálja a prezentáció‑, dia‑ és alakzat‑szintű gyűjteményeket `ItemId` szerint, és jelzi a több helyről is hivatkozott részeket:
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

Ez a fajta audit hasznos, mielőtt módosítana vagy törölne egyéni XML adatokat olyan prezentációkban, amelyeket külső rendszerek hoztak létre, mivel ugyanaz a metaadat‑rész több kapcsolatban is részt vehet.

## **Címkék értékeinek lekérése**

A diákon egy címke a `DocumentProperties::getKeywords()` metódusnak felel meg. Ez a mintakód bemutatja, hogyan lehet lekérni egy címke értékét az Aspose.Slides for PHP via Java segítségével a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) esetén:
```php
$presentation = new Presentation("presentation.pptx");
try {
    $keywords = $presentation->getDocumentProperties()->getKeywords();
} finally {
    $presentation->dispose();
}
```

## **Címkék hozzáadása a prezentációkhoz**

Az Aspose.Slides lehetővé teszi címkék hozzáadását a prezentációkhoz. Egy címke általában két elemből áll:

- a saját tulajdonság neve, például `MyTag`;
- a saját tulajdonság értéke, például `My Tag Value`.

Ha a prezentációkat egy adott szabály vagy tulajdonság alapján szeretné osztályozni, ehhez címkéket adhat hozzá. Például, ha az Észak‑Amerikai országokból származó prezentációkat szeretné kategorizálni, létrehozhat egy Észak‑Amerikai címkét, és a megfelelő országot adhatja meg értékként.

Ez a mintakód bemutatja, hogyan adjon hozzá egy címkét egy [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) objektumhoz az Aspose.Slides for PHP via Java használatával:
```php
$presentation = new Presentation("presentation.pptx");
try {
    $tags = $presentation->getCustomData()->getTags();
    $tags->set_Item("MyTag", "My Tag Value");
} finally {
    $presentation->dispose();
}
```

A címkéket egy [Slide](https://reference.aspose.com/slides/hu/php-java/aspose.slides/slide/) objektumra is beállíthatja:
```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $slide->getCustomData()->getTags()->set_Item("tag", "value");
} finally {
    $presentation->dispose();
}
```

Vagy egy egyedi [Shape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/autoshape/) objektumra:
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

### **Korlátozások**

A `getCustomData()->getTags()` gyűjteményen keresztül hozzáadott címkék csak a PowerPoint fájlban tárolódnak. **Nem** kerülnek át a PDF címke struktúrába, amikor a prezentáció PDF‑be exportálódik. Ennek következtében egy címkébe beágyazott egyéni azonosítót nem lehet leolvasni a címkézett PDF‑ből.

**Megoldás**: Egy egyéni azonosítót elhelyezhet az objektum **Alt Text**‑ében (például `$shape->setAlternativeText("MyId")`). PDF‑be exportálás után az Alt Text megjelenhet a PDF címke struktúrájában.

## **GYIK**

**Eltávolíthatok minden címkét egy prezentációból, diából vagy alakzatból egyetlen művelettel?**  
Igen. A [tag collection](https://reference.aspose.com/slides/hu/php-java/aspose.slides/tagcollection/) támogatja a [clear](https://reference.aspose.com/slides/hu/php-java/aspose.slides/tagcollection/#clear) műveletet, amely egyszerre törli az összes kulcs‑érték párt.

**Hogyan törölhetek egyetlen címkét a nevén anélkül, hogy végig iterálnék a teljes gyűjteményen?**  
Használja a [remove(name)](https://reference.aspose.com/slides/hu/php-java/aspose.slides/tagcollection/#remove) módszert a [tag collection](https://reference.aspose.com/slides/hu/php-java/aspose.slides/tagcollection/) objektumon a címke kulcs szerinti törléséhez.

**Hogyan szerezhetem meg a címkék teljes listáját elemzés vagy szűrés céljából?**  
Használja a [getNamesOfTags](https://reference.aspose.com/slides/hu/php-java/aspose.slides/tagcollection/#getNamesOfTags) metódust a [tag collection](https://reference.aspose.com/slides/hu/php-java/aspose.slides/tagcollection/) objektumon; ez egy tömböt ad vissza az összes címkenévvel.

**Hogyan találhatom meg az összes egyéni XML részt, függetlenül attól, hogy hol vannak tárolva?**  
Használja a [`Presentation::getAllCustomXmlParts()`](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/#getAllCustomXmlParts) metódust az összes egyéni XML rész lekéréséhez a prezentációban.

**A `getXmlAsString`/`setXmlAsString` vagy a `getXmlData`/`setXmlData` metódusok közül melyiket használjam egy egyéni XML rész frissítéséhez?**  
Használja a `getXmlAsString` és `setXmlAsString` metódusokat, ha az alkalmazás UTF‑8 XML szöveggel dolgozik. Használja a `getXmlData` és `setXmlData` metódusokat, ha az XML már bájt‑tömbként érhető el, vagy ha a bináris feldolgozás kényelmesebb. Mindkét ábrázolás az ugyanazon egyéni XML rész XML‑tartalmára vonatkozik.
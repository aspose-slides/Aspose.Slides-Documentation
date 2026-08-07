---
title: Címkék és egyéni adatok kezelése a prezentációkban Java-val
linktitle: Címkék és egyéni adatok
type: docs
weight: 300
url: /hu/java/managing-tags-and-custom-data/
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
- Java
- Aspose.Slides
description: "Ismerje meg, hogyan kezelheti a címkéket és az egyéni XML adatokat PowerPoint prezentációkban az Aspose.Slides for Java segítségével, beleértve a címkék hozzáadását, olvasását, frissítését, auditálását és az egyéni XML részek eltávolítását."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan működik az Aspose.Slides a címkékkel és egyéni adatokkal a PowerPoint‑prezentációkban. A prezentációspecifikus adatokat tárolhatjuk címkék vagy egyéni XML részek formájában. A címkék egyszerű kulcs‑érték karakterlánc párok, míg az egyéni XML részek strukturált metaadatokat és alkalmazás‑specifikus XML hasznosítható adatokat tárolhatnak.

Az Aspose.Slides API‑kat biztosít címkék és egyéni XML részek hozzáadásához, olvasásához, frissítéséhez, auditálásához és eltávolításához a prezentáció, dia és alakzat szintjén. Az egyéni XML részek hasznosak olyan integrációkhoz, amelyek olyan információkat tárolnak, mint a dokumentumkezelési azonosítók, munkafolyamat‑állapot, megfelelőségi metaadatok, sablon‑kötési adatok vagy más strukturált alkalmazás‑specifikus adatok a prezentációban.

{{% alert color="primary" %}}
A címkék egyszerű karakterlánc kulcs‑érték párokat tárolnak. Az egyéni XML részek strukturált XML adatokat tárolnak, és egy prezentációhoz, diahoz vagy alakzathoz társíthatók.
{{% /alert %}}

## **Adattárolás a prezentáció fájljaiban**

A `.pptx` kiterjesztésű PPTX fájlok a PresentationML formátumban vannak tárolva, amely az Office Open XML specifikáció része. Az Office Open XML meghatározza a csomag szerkezetét és a kapcsolatrendszert, amely a prezentáció tartalmát és a kapcsolódó adatokat tárolja.

Egy prezentáció több részből áll, amelyeket kapcsolatok kötnek össze. Például egy dia rész tartalmaz egyetlen dia tartalmát, és explicit kapcsolatokat tartalmazhat más részekhez, amelyeket az ISO/IEC 29500 definiál.

Az egyéni adatokat tárolhatjuk címkéként ([ITagCollection](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ITagCollection)) vagy egyéni XML részként ([ICustomXmlPartCollection](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ICustomXmlPartCollection)). Mindkettő elérhető a [`ICustomData`](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ICustomData/) felületen keresztül.

{{% alert color="primary" %}}
A címkék egyszerű string kulcs‑érték párokat tárolnak. Az egyéni XML részek strukturált XML adatokat tárolnak, és egy prezentációhoz, diahoz vagy alakzathoz kapcsolhatók.
{{% /alert %}}

## **Egyéni XML részek kezelése**

A [`ICustomData.getCustomXmlParts()`](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ICustomData#getCustomXmlParts--) metódus visszaadja az adott prezentációs objektumhoz kapcsolódó egyéni XML részek gyűjteményét. Például:

- `presentation.getCustomData().getCustomXmlParts()` tartalmazza a prezentációhoz kapcsolódó egyéni XML részeket.
- `slide.getCustomData().getCustomXmlParts()` tartalmazza egy adott diahoz kapcsolódó egyéni XML részeket.
- `shape.getCustomData().getCustomXmlParts()` tartalmazza egy adott alakzathoz kapcsolódó egyéni XML részeket.

Használd a [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation#getAllCustomXmlParts--) metódust, ha a prezentáció minden egyéni XML részét szeretnéd megvizsgálni, függetlenül attól, hogy hol vannak társítva.

### **Egyéni XML rész hozzáadása a prezentációhoz**

Használd a [`ICustomXmlPartCollection.add`](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ICustomXmlPartCollection#add-java.lang.String-) metódust XML adat hozzáadásához egy egyéni XML részgyűjteményhez. Az XML-nek érvényesnek és nem üresnek kell lennie.

Az alábbi példa strukturált metaadatot ad a prezentáció‑szintű egyéni adatgyűjteményhez:

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

    // Az add automatikusan hozzárendel egy azonosítót. Csak akkor állítson be konkrét UUID-t, ha szükséges.
    customXmlPart.setItemId(UUID.randomUUID());

    presentation.save("presentation_with_custom_xml.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

A `add` metódus XML‑t byte‑tömbként vagy bemeneti folyamként is elfogadhat, ami akkor hasznos, ha az XML‑t már bináris formában rendelkezésre áll.

### **Egyéni XML rész hozzáadása diához vagy alakzathoz**

Az egyéni XML adatot egy adott diahoz vagy alakzathoz is hozzárendelhetjük a teljes prezentáció helyett. Ez akkor hasznos, ha a metaadat csak egy objektumot leír, például egy sablon‑kulcsot, külső rekord‑azonosítót vagy kötési információt.

Az alábbi példa egy egyéni XML részt ad egy diához és egy másikat egy alakzathoz:

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

Az a szint, amelyen a rész hozzá van adva, határozza meg, melyik objektum `getCustomData().getCustomXmlParts()` gyűjteménye tartalmazza a részre mutató kapcsolatot. A prezentáció‑szintű adat a dokumentum‑szintű metaadatokhoz, a dia‑szintű adat egy adott dia információihoz, a alakzat‑szintű adat pedig egyedi alakzat metaadataihoz illik.

### **Minden egyéni XML rész listázása és auditálása**

Használd a [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation#getAllCustomXmlParts--) metódust az összes egyéni XML rész lekéréséhez egy prezentációból. Minden [`ICustomXmlPart`](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ICustomXmlPart/) kiadja az azonosítóját, az XML‑tartalmát és a hozzá tartozó névtér‑sémákat.

Az alábbi példa felsorolja az összes egyéni XML részt és azok névtér‑sémáit:

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

A [`ICustomXmlPart.getNamespaceSchemas()`](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ICustomXmlPart#getNamespaceSchemas--) visszaadja az egyéni XML részhez tartozó XML‑sémákat. Ez az információ hasznos lehet az olyan prezentációk auditálásakor, amelyek külső rendszerek által előállított XML‑t tartalmaznak.

### **XML tartalom és ItemId olvasása és frissítése**

Használd a [`ICustomXmlPart.getXmlAsString()`](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ICustomXmlPart#getXmlAsString--) és a [`setXmlAsString()`](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ICustomXmlPart#setXmlAsString-java.lang.String-) metódusokat XML UTF‑8 szövegként való kezeléséhez, vagy a [`getXmlData()`](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ICustomXmlPart#getXmlData--) és a [`setXmlData()`](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ICustomXmlPart#setXmlData-byte:A-) metódusokat a nyers XML‑bájtok kezeléséhez.

A [`ICustomXmlPart.getItemId()`](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ICustomXmlPart#getItemId--) metódus visszaadja azt a UUID‑t, amely az egyéni XML részt az Office Open XML dokumentumban azonosítja. Használd a [`setItemId()`](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ICustomXmlPart#setItemId-java.util.UUID-) metódust, ha egy integrációnak új azonosítót kell megadnia.

Az alábbi példa frissíti az XML tartalmat és az azonosítót:

```java
import com.aspose.slides.*;
import java.nio.charset.StandardCharsets;
import java.util.UUID;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ICustomXmlPart customXmlPart = presentation.getAllCustomXmlParts()[0];

    // Olvassa be a jelenlegi XML-t szövegként.
    String currentXmlContent = customXmlPart.getXmlAsString();
    System.out.println(currentXmlContent);

    // Frissítse az XML-t UTF-8 karakterláncként.
    customXmlPart.setXmlAsString(
        "<metadata xmlns=\"urn:example:metadata\">" +
            "<documentId>DOC-1001</documentId>" +
            "<workflowState>Approved</workflowState>" +
        "</metadata>");

    // A getXmlData ugyanazt az XML-t nyers bájtokként biztosítja.
    byte[] customXmlData = customXmlPart.getXmlData();
    System.out.println(new String(customXmlData, StandardCharsets.UTF_8));

    // Cserélje le az azonosítót, ha az integráció megköveteli.
    customXmlPart.setItemId(UUID.randomUUID());

    presentation.save("updated_custom_xml.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

A `setXmlAsString` vagy `setXmlData` hívásakor érvényes, nem üres XML‑t kell megadni. Válassz az egyik reprezentációk közül attól függően, hogy az alkalmazás főként szöveggel vagy bájt‑adatokkal dolgozik.

### **Egyéni XML rész eltávolítása**

Az Aspose.Slides több módot kínál az egyéni XML adat eltávolítására:

- [`ICustomXmlPart.remove`](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ICustomXmlPart#remove--) eltávolítja az egyéni XML részt a prezentációból.
- [`ICustomXmlPartCollection.remove`](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ICustomXmlPartCollection#remove-com.aspose.slides.ICustomXmlPart-) eltávolít egy konkrét részt az egyéni XML részgyűjteményből.
- [`ICustomXmlPartCollection.removeAt`](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ICustomXmlPartCollection#removeAt-int--) eltávolítja a megadott indexű részt a gyűjteményből.
- [`ICustomXmlPartCollection.clear`](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ICustomXmlPartCollection#clear--) eltávolít minden részt egy adott gyűjteményből.

Az alábbi példa egy prezentáció‑szintű egyéni XML részt távolít el hivatkozás alapján:

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

Ha már rendelkezel egy `ICustomXmlPart`‑bal, és azt szeretnéd eltávolítani a prezentációból, a `customXmlPart.remove()` hívást használd a gyűjtemény címezése helyett.

Index szerinti eltávolítás is lehetséges:

```java
presentation.getCustomData().getCustomXmlParts().removeAt(0);
```

### **Az összes egyéni XML rész törlése egy gyűjteményből**

Használd a `clear` metódust, ha egy adott prezentációs objektumhoz kapcsolódó összes egyéni XML részt el akarod távolítani.

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

A `clear` csak a kiválasztott gyűjteményre hat. Például egy dia gyűjteményének törlése nem érinti a prezentáció‑ vagy alakzat‑szintű gyűjteményeket.

Az összes egyéni XML rész eltávolításához a prezentációban iterálj a `getAllCustomXmlParts()` eredményén, és távolítsd el mindegyiket:

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

### **Kapcsolt vagy megosztott egyéni XML részek kezelése**

Egy Office Open XML prezentációban ugyanaz a egyéni XML rész több prezentációs objektumból is hivatkozható. Például egy meglévő fájl tartalmazhat kapcsolódásokat több diáról vagy alakzatról ugyanahhoz az alaprészhez.

A megosztott részt egy adatobjektumként kell kezelni több hivatkozással:

- A `setXmlAsString`, `setXmlData` vagy `setItemId` használata módosítja az alapul szolgáló egyéni XML részt, így a változás minden hivatkozásnál megjelenik.
- A `getItemId()` használható ugyanazon rész azonosítására az objektumszintű gyűjtemények auditálása során.
- Egy rész eltávolítása egy adott `getCustomXmlParts()` gyűjteményből csak azt a gyűjteményt érinti. Használd az `ICustomXmlPart.remove()` metódust, ha a részt magától kell eltávolítani a prezentációból.
- Megosztott rész törlése vagy cseréje előtt ellenőrizd az objektumszintű gyűjteményeket, hogy más diák vagy alakzatok továbbra is hivatkoznak‑e rá.

Az `add` túlterhelések új egyéni XML részt hoznak létre XML tartalomból; nem fogadják el egy meglévő `ICustomXmlPart`‑ot. Így a megosztott kapcsolatok leginkább olyan prezentációk betöltésekor fordulnak elő, amelyek már tartalmazzák őket.

Az alábbi példa auditálja a prezentáció‑, dia‑ és alakzat‑szintű gyűjteményeket `ItemId` alapján, és jelentést készít a több helyen hivatkozott részekről:

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

Ez a fajta auditálás hasznos a külső rendszerek által létrehozott prezentációk egyéni XML adatai módosítása vagy törlése előtt, mivel ugyanaz a metaadat‑rész több kapcsolatban is részt vehet.

## **Címkék értékeinek lekérdezése**

A diákban egy címke a `IDocumentProperties.getKeywords()` metódusnak felel meg. Az alábbi mintakód megmutatja, hogyan lehet egy címke értékét lekérni az Aspose.Slides for Java‑val a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation) esetén:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    String keywords = presentation.getDocumentProperties().getKeywords();
} finally {
    presentation.dispose();
}
```

## **Címkék hozzáadása a prezentációkhoz**

Az Aspose.Slides lehetővé teszi címkék hozzáadását a prezentációkhoz. Egy címke általában két elemből áll:

- egy egyéni tulajdonság neve, például `MyTag`;
- az egyéni tulajdonság értéke, például `My Tag Value`.

Ha például egy szabály vagy tulajdonság alapján szeretnél csoportosítani prezentációkat, akkor ehhez hozzáadhatsz címkéket. Például, ha az Észak‑Amerikai országokból származó prezentációkat szeretnéd kategorizálni, létrehozhatsz egy „NorthAmerica” címkét, és az adott országot állíthatod be értékként.

Az alábbi mintakód megmutatja, hogyan lehet egy címkét hozzáadni egy [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation) objektumhoz Aspose.Slides for Java használatával:

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

Címkéket egy [Slide](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ISlide) esetén is beállíthatunk:

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

Vagy egy egyedi [Shape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IAutoShape) esetén:

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

### **Korlátozások**

A `getCustomData().getTags()` gyűjteményen keresztül hozzáadott címkék csak a PowerPoint fájlban tárolódnak. **Nem** kerülnek átvitelre a PDF címke‑struktúrába, ha a prezentációt PDF‑be exportáljuk. Ennek következtében egy címkében tárolt egyéni azonosító nem olvasható ki a címkézett PDF‑ből.

**Megoldás**: Egyedi azonosítót tárolhatsz az objektum **Alt Text**‑ében (például `shape.setAlternativeText("MyId")`). PDF‑export után az Alt Text megjelenhet a PDF címke‑struktúrában.

## **GYIK**

**Eltávolíthatom az összes címkét egy prezentációból, diából vagy alakzatból egyetlen művelettel?**  
Igen. A [címkegyűjtemény](https://reference.aspose.com/slides/hu/java/com.aspose.slides/tagcollection/) támogatja a [clear](https://reference.aspose.com/slides/hu/java/com.aspose.slides/tagcollection/#clear--) műveletet, amely egyszerre törli az összes kulcs‑érték párt.

**Hogyan törölhetek egyetlen címkét a nevén anélkül, hogy végigjárnám az egész gyűjteményt?**  
Használd a [remove(name)](https://reference.aspose.com/slides/hu/java/com.aspose.slides/tagcollection/#remove-java.lang.String-) metódust a [címkegyűjteményen](https://reference.aspose.com/slides/hu/java/com.aspose.slides/tagcollection/) a címke kulcsa szerint történő törléshez.

**Hogyan tudom lekérni a címkeneveket teljes listában elemzés vagy szűrés céljából?**  
Használd a [getNamesOfTags](https://reference.aspose.com/slides/hu/java/com.aspose.slides/tagcollection/#getNamesOfTags--) metódust a [címkegyűjteményen](https://reference.aspose.com/slides/hu/java/com.aspose.slides/tagcollection/); ez egy tömböt ad vissza az összes címkenévvel.

**Hogyan találhatom meg az összes egyéni XML részt, függetlenül attól, hogy hol tárolódnak?**  
Használd a [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation#getAllCustomXmlParts--) metódust az összes egyéni XML rész lekéréséhez a prezentációban.

**Melyik módszert használjam a XML rész frissítéséhez: `getXmlAsString`/`setXmlAsString` vagy `getXmlData`/`setXmlData`?**  
Használd a `getXmlAsString` és `setXmlAsString` metódusokat, ha az alkalmazás UTF‑8 XML szöveggel dolgozik. Használd a `getXmlData` és `setXmlData` metódusokat, ha az XML már byte‑tömbként áll rendelkezésre, vagy a bináris feldolgozás kényelmesebb. Mindkét reprezentáció ugyanannak az egyéni XML résznek a tartalmára mutat.
---
title: Címkék és egyedi adatok kezelése prezentációkban Androidon
linktitle: Címkék és egyedi adatok
type: docs
weight: 300
url: /hu/androidjava/managing-tags-and-custom-data
keywords:
- dokumentum tulajdonságok
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
- Android
- Java
- Aspose.Slides
description: "Ismerje meg, hogyan kezelheti a címkéket és az egyedi XML adatokat PowerPoint prezentációkban az Aspose.Slides for Android Java segítségével, beleértve a címkék hozzáadását, olvasását, frissítését, auditálását és az egyedi XML részek eltávolítását."
---
## **Áttekintés**

Ez a cikk elmagyarázza, hogyan működik az Aspose.Slides a címkékkel és az egyedi adatokka­l a PowerPoint‑prezentációkban. A prezentáció specifikus adatokat címkék vagy egyedi XML‑részek formájában lehet tárolni. A címkék egyszerű kulcs‑érték karakterlánc párok, míg az egyedi XML‑részek strukturált metaadatokat és alkalmazásspecifikus XML‑payload‑okat tárolhatnak.

Az Aspose.Slides API‑kat biztosít az egyedi XML‑részek hozzáadásához, olvasásához, frissítéséhez, auditálásához és eltávolításához a prezentáció, dia és alakzat szintjén. Az egyedi XML‑részek hasznosak olyan integrációkban, ahol információk, például dokumentumkezelési azonosítók, munkafolyamat‑állapot, megfelelőségi metaadatok, sablon‑kötési adatok vagy egyéb strukturált alkalmazásadatok tárolására van szükség a prezentációban.

## **Adattárolás a prezentációfájlokban**

A PPTX fájlok – a `.pptx` kiterjesztésű fájlok – a PresentationML formátumban tárolódnak, amely az Office Open XML specifikáció része. Az Office Open XML meghatározza a csomagstruktúrát és a kapcsolatokat, amelyeket a prezentáció tartalmának és a kapcsolódó adatoknak a tárolására használnak.

Egy prezentáció több, kapcsolatokkal összekapcsolt részből áll. Például egy diarész tartalmaz egyetlen dia tartalmát, és kifejezett kapcsolatokat tartalmazhat más részekkel, amelyeket az ISO/IEC 29500 definiál.

Az egyedi adatokat tárolhatjuk címkék ( [ITagCollection](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ITagCollection) ) vagy egyedi XML‑részek ( [ICustomXmlPartCollection](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ICustomXmlPartCollection) ) formájában. Mindkettő elérhető a [`ICustomData`](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ICustomData/) interfészen keresztül.

{{% alert color="info" %}}
A címkék egyszerű karakterlánc kulcs‑érték párokat tárolnak. Az egyedi XML‑részek strukturált XML adatokat tárolnak, és társíthatók egy prezentációhoz, diához vagy alakzathoz.
{{% /alert %}}

## **Egyedi XML‑részek kezelése**

A [`ICustomData.getCustomXmlParts()`](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ICustomData#getCustomXmlParts--) metódus visszaadja a megadott prezentációobjektumhoz társított egyedi XML‑részek gyűjteményét. Például:

- `presentation.getCustomData().getCustomXmlParts()` tartalmazza a prezentációhoz közvetlenül társított egyedi XML‑részeket.
- `slide.getCustomData().getCustomXmlParts()` tartalmazza egy adott diához társított egyedi XML‑részeket.
- `shape.getCustomData().getCustomXmlParts()` tartalmazza egy adott alakzathoz társított egyedi XML‑részeket.

Használja a `Presentation.getAllCustomXmlParts()` metódust, ha a prezentációban szereplő összes egyedi XML‑részt meg szeretné vizsgálni, függetlenül attól, hogy hol vannak társítva.

### **Egyedi XML‑rész hozzáadása egy prezentációhoz**

Használja a [`ICustomXmlPartCollection.add`](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ICustomXmlPartCollection#add-java.lang.String-) metódust, hogy XML adatot adjon hozzá egy egyedi XML‑rész gyűjteményhez. Az XML-nek érvényesnek és nem üresnek kell lennie.

Az alábbi példa strukturált metaadatokat ad hozzá a prezentáció szintű egyedi adatgyűjteményhez:

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

    // a hozzáadás automatikusan hozzárendel egy azonosítót. Adjon meg konkrét UUID-t csak akkor, ha szükséges.
    customXmlPart.setItemId(UUID.randomUUID());

    presentation.save("presentation_with_custom_xml.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

A `add` metódus XML‑t is elfogadhat bájt‑tömbként vagy input stream‑ként, ami hasznos, ha az XML‑tartalom már bináris formában áll rendelkezésre.

### **Egyedi XML‑rész hozzáadása diához vagy alakzathoz**

Az egyedi XML adatot társíthatja egy konkrét diához vagy alakzathoz a teljes prezentáció helyett. Ez akkor hasznos, ha a metaadat csak egy objektumot ír le, például egy sablonkulcsot, külső rekordazonosítót vagy kötési információt.

Az alábbi példa egy egyedi XML‑részt ad egy diához, és egy másikat egy alakzathoz:

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

Az a szint, amelyen egy részt hozzáadnak, meghatározza, hogy melyik objektum `getCustomData().getCustomXmlParts()` gyűjteménye tartalmazza a részhez tartozó kapcsolatot. A prezentáció‑szintű adatok a dokumentum‑szintű metaadatokhoz alkalmasak, a dia‑szintű adatok egy adott diához tartozó információkhoz, a alakzat‑szintű adatok pedig egyetlen alakzathoz kapcsolódó metaadatokhoz.

### **Az összes egyedi XML‑rész listázása és auditálása**

Használja a `Presentation.getAllCustomXmlParts()` metódust, hogy lekérje a prezentáció összes egyedi XML‑részét. Minden [`ICustomXmlPart`](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ICustomXmlPart/) megjeleníti azonosítóját, XML‑tartalmát és a hozzá tartozó névtér‑sémákat.

Az alábbi példa listázza az összes egyedi XML‑részt és azok névtér‑sémáit:

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

`ICustomXmlPart.getNamespaceSchemas()` visszaadja az egyedi XML‑részhez társított XML‑sémákat. Ez az információ hasznos lehet a prezentációk auditálásakor, amelyek olyan XML‑t tartalmaznak, amelyet külső rendszerek állítottak elő.

### **XML‑tartalom és ItemId olvasása és frissítése**

Használja a [`ICustomXmlPart.getXmlAsString()`](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ICustomXmlPart#getXmlAsString--) és a [`setXmlAsString()`](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ICustomXmlPart#setXmlAsString-java.lang.String-) metódusokat az XML‑t UTF‑8 karakterláncként kezelni, vagy a [`getXmlData()`](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ICustomXmlPart#getXmlData--) és a [`setXmlData()`](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ICustomXmlPart#setXmlData-byte:A-) metódusokat a nyers XML‑bájtok kezeléséhez.

A [`ICustomXmlPart.getItemId()`](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ICustomXmlPart#getItemId--) metódus visszaadja azt az UUID‑t, amely az egyedi XML‑részt az Office Open XML dokumentumban azonosítja. Használja a [`setItemId()`](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ICustomXmlPart#setItemId-java.util.UUID-) metódust, ha egy integráció új azonosítót igényel.

Az alábbi példa frissíti az XML‑tartalmat és az azonosítót:

```java
import com.aspose.slides.*;
import java.nio.charset.StandardCharsets;
import java.util.UUID;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ICustomXmlPart customXmlPart = presentation.getAllCustomXmlParts()[0];

    // Olvassa be az aktuális XML-t szövegként.
    String currentXmlContent = customXmlPart.getXmlAsString();
    System.out.println(currentXmlContent);

    // Frissítse az XML-t UTF-8 karakterláncként.
    customXmlPart.setXmlAsString(
        "<metadata xmlns=\"urn:example:metadata\">" +
            "<documentId>DOC-1001</documentId>" +
            "<workflowState>Approved</workflowState>" +
        "</metadata>");

    // A getXmlData ugyanazt az XML-tartalmat nyers bájtokként biztosítja.
    byte[] customXmlData = customXmlPart.getXmlData();
    System.out.println(new String(customXmlData, StandardCharsets.UTF_8));

    // Cserélje le az azonosítót, ha az integráció megköveteli.
    customXmlPart.setItemId(UUID.randomUUID());

    presentation.save("updated_custom_xml.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

A `setXmlAsString` vagy `setXmlData` meghívásakor adjon meg érvényes, nem üres XML‑t. Az egyik vagy másik ábrázolást használja attól függően, hogy az alkalmazás elsősorban karakterláncokkal vagy bájt‑adatokkal dolgozik.

### **Egyedi XML‑rész eltávolítása**

- `ICustomXmlPart.remove` eltávolítja az egyedi XML‑részt a prezentációból.
- `ICustomXmlPartCollection.remove` eltávolít egy konkrét részt egy egyedi XML‑rész gyűjteményből.
- `ICustomXmlPartCollection.removeAt` eltávolítja a megadott indexű részt a gyűjteményből.
- `ICustomXmlPartCollection.clear` eltávolítja az összes részt egy adott gyűjteményből.

Az alábbi példa egy prezentáció‑szintű egyedi XML‑részt távolít el referencia alapján:

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

Ha már rendelkezik egy `ICustomXmlPart` objektummal, és a prezentációból szeretné eltávolítani, ahelyett, hogy egy konkrét gyűjteményt célozna meg, hívja a `customXmlPart.remove()` metódust.

Az elemet index alapján is eltávolíthatja:

```java
presentation.getCustomData().getCustomXmlParts().removeAt(0);
```

### **Az összes egyedi XML‑rész törlése egy gyűjteményből**

A `clear` metódust akkor használja, amikor egy adott prezentációobjektumhoz kapcsolódó összes egyedi XML‑részt el kell távolítani.

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

A `clear` csak a kiválasztott gyűjteményt érinti. Például egy dia gyűjteményének törlése nem törli a prezentáció‑szintű vagy alakzat‑szintű gyűjteményeket.

A prezentáció minden egyedi XML‑részének eltávolításához iteráljon a `getAllCustomXmlParts()` felett, és távolítsa el minden részt:

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

### **Összekapcsolt vagy megosztott egyedi XML‑részek kezelése**

Egy Office Open XML prezentációban ugyanaz a egyedi XML‑rész több prezentációobjektumból is hivatkozható. Például egy meglévő fájl tartalmazhat kapcsolatokat több diából vagy alakzatból ugyanahhoz az alapul szolgáló egyedi XML‑részhez.

Egy megosztott részt egy adatobjektumként kell kezelni több hivatkozással:

- `setXmlAsString`, `setXmlData` vagy `setItemId` használatával a frissítés az alapul szolgáló egyedi XML‑részt módosítja, így a változás minden hivatkozási helyen érvényes lesz.
- `getItemId()` használható ugyanazon egyedi XML‑rész azonosítására az objektumszintű gyűjtemények auditálása során.
- Egy rész eltávolítása egy adott `getCustomXmlParts()` gyűjteményből csak azt a gyűjteményt érinti. Használja az `ICustomXmlPart.remove()` metódust, ha magát a részt el kell távolítani a prezentációból.
- A megosztott rész törlése vagy cseréje előtt ellenőrizze az objektumszintű gyűjteményeket, hogy megállapítsa, más diák vagy alakzatok még hivatkoznak‑e rá.

A `add` túlterhelései új egyedi XML‑részt hoznak létre XML‑tartalomból; nem fogadnak el meglévő `ICustomXmlPart` példányt. Ezért a megosztott kapcsolatok leggyakrabban akkor merülnek fel, amikor már meglévő ilyen részeket tartalmazó prezentációkat töltünk be.

Az alábbi példa auditálja a prezentáció‑, dia‑ és alakzat‑szintű gyűjteményeket `ItemId` alapján, és jelenti azokat a részeket, amelyek több helyről is hivatkozottak:

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

Ez az auditálási típus hasznos, mielőtt módosítaná vagy törölné az egyedi XML‑adatokat külső rendszerek által létrehozott prezentációkban, mivel ugyanaz a metaadat‑rész több kapcsolatban is részt vehet.

## **Címkék értékeinek lekérdezése**

A diákban egy címke a `IDocumentProperties.getKeywords()` metódusnak felel meg. Ez a példakód bemutatja, hogyan lehet lekérni egy címke értékét az Aspose.Slides for Android Java verziójával a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation) esetén:

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

- a saját tulajdonság neve, például `MyTag`;
- a saját tulajdonság értéke, például `My Tag Value`.

Ha a prezentációkat egy adott szabály vagy tulajdonság alapján szeretné besorolni, hozzáadhat ehhez címkéket. Például, ha az Észak-Amerikai országokból származó prezentációkat szeretné kategorizálni, létrehozhat egy Észak-Amerikai címkét, és a megfelelő országot állíthatja be értékként.

Ez a példakód bemutatja, hogyan adhat hozzá egy címkét egy [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation) objektumhoz az Aspose.Slides for Android Java verziójával:

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

A címkéket egy [Slide](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ISlide) esetén is beállíthatja:

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

Vagy egy egyedi [Shape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IAutoShape) esetén:

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

A `getCustomData().getTags()` gyűjteményen keresztül hozzáadott címkéket csak a PowerPoint‑fájl tárolja. **Nem** kerülnek átvitelre a PDF‑címke struktúrába, amikor a prezentációt PDF‑be exportálják. Ennek következtében a címkeként hozzárendelt egyedi azonosítót nem lehet visszakeresni a címkézett PDF‑ből.

**Megoldás**: Egy egyedi azonosítót tárolhat az objektum **Alt Text** mezőjében (például `shape.setAlternativeText("MyId")`). PDF‑export után az Alt Text megjelenhet a PDF‑címke struktúrában.

## **GYIK**

**Eltávolíthatok minden címkét egy prezentációból, diához vagy alakzathoz egyetlen műveletben?**  
Igen. A [tag collection](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/tagcollection/) támogatja a [clear](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/tagcollection/#clear--) műveletet, amely egyben törli az összes kulcs‑érték párt.

**Hogyan törölhetek egyetlen címkét a nevével anélkül, hogy végigiterálnék a teljes gyűjteményen?**  
Használja a [remove(name)](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/tagcollection/#remove-java.lang.String-) metódust a [tag collection](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/tagcollection/) objektumon a címke kulcs szerinti törléséhez.

**Hogyan szerezhetem meg a címkék teljes neves listáját elemzéshez vagy szűréshez?**  
Használja a [getNamesOfTags](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/tagcollection/#getNamesOfTags--) metódust a [tag collection](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/tagcollection/) objektumon; ez egy tömböt ad vissza az összes címkenévvel.

**Hogyan találhatom meg az összes egyedi XML‑részt, függetlenül attól, hogy hol tárolódnak?**  
Használja a [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation#getAllCustomXmlParts--) metódust, hogy lekérje a prezentáció összes egyedi XML‑részét.

**Használnam a `getXmlAsString`/`setXmlAsString` vagy a `getXmlData`/`setXmlData` metódusokat egy egyedi XML‑rész frissítéséhez?**  
Használja a `getXmlAsString` és `setXmlAsString` metódusokat, ha az alkalmazás UTF‑8 XML‑szöveggel dolgozik. Használja a `getXmlData` és `setXmlData` metódusokat, ha az XML már bájt‑tömbként áll rendelkezésre, vagy ha a bináris feldolgozás kényelmesebb. Mindkét ábrázolás ugyanazon egyedi XML‑rész XML‑tartalmára vonatkozik.
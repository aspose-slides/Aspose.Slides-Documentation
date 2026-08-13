---
title: Címkék és egyéni adatok kezelése prezentációkban Java használatával
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
- XML metaadatok
- ItemId
- címke hozzáadása
- páros értékek
- PowerPoint
- prezentáció
- Java
- Aspose.Slides
description: "Ismerje meg, hogyan kezelhet címkéket és egyéni XML adatokat PowerPoint‑prezentációkban az Aspose.Slides for Java segítségével, beleértve a hozzáadást, olvasást, frissítést, auditálást és az egyéni XML részek eltávolítását."
---
## **Áttekintés**

Ez a cikk elmagyarázza, hogyan működik az Aspose.Slides a címkékkel és egyéni adatokkal PowerPoint‑prezentációkban. A prezentációra jellemző adatokat tárolhatjuk címkék vagy egyéni XML részek formájában. A címkék egyszerű kulcs‑érték karakterlánc párok, míg az egyéni XML részek strukturált metaadatokat és alkalmazás‑specifikus XML teherfájlokat tárolhatnak.

Az Aspose.Slides API‑kat biztosít az egyéni XML részek hozzáadásához, olvasásához, frissítéséhez, auditálásához és eltávolításához a prezentáció, dia és alakzat szinteken. Az egyéni XML részek hasznosak olyan integrációkhoz, amelyek információkat tárolnak, például dokumentum‑kezelő azonosítókat, munkafolyamat‑állapotot, megfelelőségi metaadatokat, sablon‑kötési adatokat vagy egyéb strukturált alkalmazásadatokat a prezentáción belül.

## **Prezentációs fájlok adattárolása**

PPTX fájlok — a `.pptx` kiterjesztésű fájlok — a PresentationML formátumban vannak tárolva, amely az Office Open XML specifikáció része. Az Office Open XML meghatározza a csomag szerkezetét és a kapcsolatrendszereket, amelyeket a prezentáció tartalmának és a kapcsolódó adatok tárolására használnak.

Egy prezentáció több, kapcsolatokkal összekapcsolt részből áll. Például egy dia rész tartalmazza egyetlen dia tartalmát, és kifejezett kapcsolatokat tartalmazhat más részekkel, amelyeket az ISO/IEC 29500 definiál.

Az egyéni adat tárolható címkék ([ITagCollection](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ITagCollection)) vagy egyéni XML részek ([ICustomXmlPartCollection](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ICustomXmlPartCollection)) formájában. Mindkettő elérhető a [`ICustomData`](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ICustomData/) interfészen keresztül.

{{% alert color="info" %}}
Címkék egyszerű karakterlánc kulcs‑érték párokat tárolnak. Az egyéni XML részek strukturált XML adatokat tárolnak, és kapcsolhatók egy prezentációhoz, diához vagy alakzathoz.
{{% /alert %}}

## **Egyéni XML részek kezelése**

A [`ICustomData.getCustomXmlParts()`](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ICustomData#getCustomXmlParts--) metódus visszaadja egy adott prezentációs objektumhoz társított egyéni XML részek gyűjteményét. Például:

- `presentation.getCustomData().getCustomXmlParts()` a prezentációhoz közvetlenül társított egyéni XML részeket tartalmaz.
- `slide.getCustomData().getCustomXmlParts()` egy adott diához társított egyéni XML részeket tartalmaz.
- `shape.getCustomData().getCustomXmlParts()` egy adott alakzathoz társított egyéni XML részeket tartalmaz.

Ekkor használja a [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation#getAllCustomXmlParts--) metódust, ha a prezentációban szereplő összes egyéni XML részt meg szeretné vizsgálni, függetlenül attól, hogy hol vannak társítva.

### **Egyéni XML rész hozzáadása a prezentációhoz**

A [`ICustomXmlPartCollection.add`](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ICustomXmlPartCollection#add-java.lang.String-) metódust használja XML adat hozzáadásához egy egyéni XML rész gyűjteményhez. Az XML-nek érvényesnek és nem üresnek kell lennie.

A következő példa strukturált metaadatot ad hozzá a prezentáció‑szintű egyéni adatgyűjteményhez:
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

    // az add automatikusan hozzárendel egy azonosítót. Egy adott UUID-t csak akkor állítson be, ha szükséges.
    customXmlPart.setItemId(UUID.randomUUID());

    presentation.save("presentation_with_custom_xml.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az `add` metódus XML‑t is elfogadhat bájt tömbként vagy bemeneti folyamként, ami hasznos, ha az XML tartalom már bináris formában elérhető.

### **Egyéni XML rész hozzáadása diához vagy alakzathoz**

Az egyéni XML adat társítható egy adott diához vagy alakzathoz a teljes prezentáció helyett. Ez akkor hasznos, ha a metaadat csak egy objektumot ír le, például egy sablon kulcsot, külső rekord azonosítót vagy kötési információt.

A következő példa egy egyéni XML részt ad hozzá egy diához, a másikat pedig egy alakzathoz:
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

A rész hozzáadásának szintje határozza meg, melyik objektum `getCustomData().getCustomXmlParts()` gyűjteménye tartalmazza a részhez vezető kapcsolatot. A prezentáció‑szintű adat a dokumentum‑szintű metaadatokhoz megfelelő, a dia‑szintű adat egy adott diához tartozó információkhoz, a alakzat‑szintű adat pedig egyedi alakzathoz kapcsolódó metaadatokhoz.

### **Az összes egyéni XML rész felsorolása és auditálása**

A [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation#getAllCustomXmlParts--) metódust használja az összes egyéni XML rész lekéréséhez a prezentációból. Minden [`ICustomXmlPart`](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ICustomXmlPart/) felfedi azonosítóját, XML‑tartalmát és a hozzá tartozó névtér‑sémákat.

A következő példa felsorolja az összes egyéni XML részt és azok névtér‑sémáit:
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

`ICustomXmlPart.getNamespaceSchemas()` visszaadja az egyéni XML részhez társított XML sémákat. Ez az információ hasznos lehet, amikor olyan prezentációkat auditálunk, amelyek XML‑t tartalmaznak külső rendszerek által előállítva.

### **XML tartalom és ItemId olvasása és frissítése**

A [`ICustomXmlPart.getXmlAsString()`](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ICustomXmlPart#getXmlAsString--) és a [`setXmlAsString()`](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ICustomXmlPart#setXmlAsString-java.lang.String-) metódusokkal XML‑et UTF‑8 szövegként kezelhet, vagy a [`getXmlData()`](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ICustomXmlPart#getXmlData--) és a [`setXmlData()`](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ICustomXmlPart#setXmlData-byte:A-) metódusokkal a nyers XML bájtokat.

A [`ICustomXmlPart.getItemId()`](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ICustomXmlPart#getItemId--) metódus visszaadja azt a UUID‑t, amely az egyéni XML részt az Office Open XML dokumentumban azonosítja. Használja a [`setItemId()`](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ICustomXmlPart#setItemId-java.util.UUID-) metódust, ha egy integrációnak új azonosító szükséges.

A következő példa frissíti az XML tartalmat és az azonosítót:
```java
import com.aspose.slides.*;
import java.nio.charset.StandardCharsets;
import java.util.UUID;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ICustomXmlPart customXmlPart = presentation.getAllCustomXmlParts()[0];

    // Olvassa el a jelenlegi XML-t szövegként.
    String currentXmlContent = customXmlPart.getXmlAsString();
    System.out.println(currentXmlContent);

    // Frissítse az XML-t UTF-8 karakterláncként.
    customXmlPart.setXmlAsString(
        "<metadata xmlns=\"urn:example:metadata\">" +
            "<documentId>DOC-1001</documentId>" +
            "<workflowState>Approved</workflowState>" +
        "</metadata>");

    // A getXmlData ugyanezt az XML-t nyers bájtokként biztosítja.
    byte[] customXmlData = customXmlPart.getXmlData();
    System.out.println(new String(customXmlData, StandardCharsets.UTF_8));

    // Cserélje le az azonosítót, ha az integráció megköveteli.
    customXmlPart.setItemId(UUID.randomUUID());

    presentation.save("updated_custom_xml.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

A `setXmlAsString` vagy `setXmlData` hívásakor adjon meg érvényes, nem üres XML‑t. Az egyik vagy másik ábrázolást használja attól függően, hogy az alkalmazás főként karakterláncokkal vagy bájt adatokkal dolgozik.

### **Egyéni XML rész eltávolítása**

Az Aspose.Slides több módot kínál az egyéni XML adatok eltávolítására:

- [`ICustomXmlPart.remove`](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ICustomXmlPart#remove--) eltávolítja az egyéni XML részt a prezentációból.
- [`ICustomXmlPartCollection.remove`](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ICustomXmlPartCollection#remove-com.aspose.slides.ICustomXmlPart-) egy adott részt eltávolít egy egyéni XML rész gyűjteményből.
- [`ICustomXmlPartCollection.removeAt`](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ICustomXmlPartCollection#removeAt-int--) a megadott indexű részt távolítja el a gyűjteményből.
- [`ICustomXmlPartCollection.clear`](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ICustomXmlPartCollection#clear--) az összes részt eltávolítja egy adott gyűjteményből.

A következő példa egy prezentáció‑szintű egyéni XML részt távolít el referenciával:
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

Ha már rendelkezik egy `ICustomXmlPart`‑al, és a prezentációból szeretné eltávolítani azt egy konkrét gyűjtemény megcímzése helyett, hívja a `customXmlPart.remove()`‑t.

Egy elemet index alapján is eltávolíthat:
```java
presentation.getCustomData().getCustomXmlParts().removeAt(0);
```

### **Az összes egyéni XML rész törlése egy gyűjteményből**

Használja a `clear`‑t, ha egy adott prezentációs objektumhoz kapcsolódó összes egyéni XML részt el kell távolítani.
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

A `clear` csak a kiválasztott gyűjteményre hat. Például egy dia gyűjteményének törlése nem törli a prezentáció‑szintű vagy alakzat‑szintű gyűjteményeket.

A prezentáció összes egyéni XML részének eltávolításához iteráljon a `getAllCustomXmlParts()`‑en és távolítson el minden részt:
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

### **Összekapcsolt vagy megosztott egyéni XML részek kezelése**

Az Office Open XML prezentációban ugyanaz a egyéni XML rész több prezentációs objektumból is hivatkozható lehet. Például egy meglévő fájl tartalmazhat kapcsolatokat több diától vagy alakzattól ugyanahhoz az alaprészhez.

Egy megosztott részt egy adatobjektumként kell kezelni több hivatkozással:

- `setXmlAsString`, `setXmlData` vagy `setItemId` használatával történő frissítés módosítja az alaprész egyéni XML részét, így a változás minden hivatkozásnál érvényes lesz.
- `getItemId()` használható ugyanannak az egyéni XML résznek az azonosítására objektumszintű gyűjtemények auditálása során.
- Egy rész eltávolítása egy adott `getCustomXmlParts()` gyűjteményből csak azt a gyűjteményt érinti. Használja a `ICustomXmlPart.remove()`‑t, ha maga a rész el kell távolítani a prezentációból.
- Törlés vagy cserélés előtt ellenőrizze az objektumszintű gyűjteményeket, hogy megállapítsa, más diák vagy alakzatok még hivatkoznak‑e rá.

Az `add` túlterhelései új egyéni XML részt hoznak létre XML tartalomból; meglévő `ICustomXmlPart`‑ot nem fogadnak el. Ezért a megosztott kapcsolatok leggyakrabban akkor fordulnak elő, amikor olyan prezentációkat töltenek be, amelyek már tartalmazzák őket.

A következő példa auditálja a prezentáció‑, dia‑ és alakzat‑szintű gyűjteményeket `ItemId` alapján, és jelentést készít a több helyről hivatkozott részekről:
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

Ez a fajta audit hasznos, mielőtt módosítaná vagy törölné az egyéni XML adatokat külső rendszerek által létrehozott prezentációkban, mivel ugyanaz a metaadat‑rész több kapcsolatban is részt vehet.

## **Címkék értékeinek lekérése**

A diáknál a címke a `IDocumentProperties.getKeywords()` metódusnak felel meg. Ez a mintakód bemutatja, hogyan lehet egy címke értékét lekérni az Aspose.Slides for Java segítségével egy [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation) esetén:
```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    String keywords = presentation.getDocumentProperties().getKeywords();
} finally {
    presentation.dispose();
}
```

## **Címkék hozzáadása prezentációkhoz**

Az Aspose.Slides lehetővé teszi címkék hozzáadását a prezentációkhoz. Egy címke általában két elemből áll:

- a saját tulajdonság neve, például `MyTag`;
- a saját tulajdonság értéke, például `My Tag Value`.

Ha egy konkrét szabály vagy tulajdonság alapján kell osztályozni a prezentációkat, hozzáadhat címkéket erre a célra. Például, ha az Észak‑Amerikai országok prezentációit szeretné kategorizálni, létrehozhat egy Észak‑Amerikai címkét, és a kapcsolódó országot értékként hozzárendelheti.

Ez a mintakód bemutatja, hogyan lehet egy címkét hozzáadni egy [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation) objektumhoz az Aspose.Slides for Java használatával:
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

A címkéket egy [Slide](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ISlide) esetén is beállíthatja:
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

A `getCustomData().getTags()` gyűjteményen keresztül hozzáadott címkék csak a PowerPoint‑fájlban tárolódnak. A **nem** kerülnek át a PDF címke‑szerkezetbe, amikor a prezentációt PDF‑be exportálják. Ennek következtében egy címkébe rendelt egyéni azonosítót nem lehet a címkézett PDF‑ből lekérni.

**Megoldás**: Egy egyéni azonosítót tárolhat az objektum **Alt Text**‑ében (például `shape.setAlternativeText("MyId")`). PDF‑be exportálás után az Alt Text megjelenhet a PDF címke‑szerkezetben.

## **GYIK**

**Eltávolíthatok az összes címkét egy prezentációból, diábol vagy alakzatból egyetlen művelettel?**  
Igen. A [tag collection](https://reference.aspose.com/slides/hu/java/com.aspose.slides/tagcollection/) támogatja a [clear](https://reference.aspose.com/slides/hu/java/com.aspose.slides/tagcollection/#clear--) műveletet, amely egyszerre törli az összes kulcs‑érték párt.

**Hogyan törölhetek egyetlen címkét a nevén anélkül, hogy végig iterálnék a teljes gyűjteményen?**  
Használja a [remove(name)](https://reference.aspose.com/slides/hu/java/com.aspose.slides/tagcollection/#remove-java.lang.String-) metódust a [tag collection](https://reference.aspose.com/slides/hu/java/com.aspose.slides/tagcollection/) esetén a címke kulcs szerinti törléséhez.

**Hogyan kaphatom meg a címkék nevének teljes listáját elemzéshez vagy szűréshez?**  
Használja a [getNamesOfTags](https://reference.aspose.com/slides/hu/java/com.aspose.slides/tagcollection/#getNamesOfTags--) metódust a [tag collection](https://reference.aspose.com/slides/hu/java/com.aspose.slides/tagcollection/) esetén; ez egy tömböt ad vissza az összes címkenévvel.

**Hogyan találhatom meg az összes egyéni XML részt, függetlenül attól, hogy hol vannak tárolva?**  
Használja a [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation#getAllCustomXmlParts--) metódust az összes egyéni XML rész lekéréséhez a prezentációban.

**Használjam-e a `getXmlAsString`/`setXmlAsString` vagy a `getXmlData`/`setXmlData` metódusokat egy egyéni XML rész frissítéséhez?**  
Használja a `getXmlAsString` és `setXmlAsString` metódusokat, ha az alkalmazás UTF‑8 XML szöveggel dolgozik. Használja a `getXmlData` és `setXmlData` metódusokat, ha az XML már bájt‑tömbként áll rendelkezésre, vagy ha a bináris feldolgozás kényelmesebb. Mindkét ábrázolás ugyanazon egyéni XML rész XML‑tartalmára vonatkozik.
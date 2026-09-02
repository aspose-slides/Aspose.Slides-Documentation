---
title: Címkék és egyéni adatok kezelése a bemutatókban Androidon
linktitle: Címkék és egyéni adatok
type: docs
weight: 300
url: /hu/androidjava/managing-tags-and-custom-data
keywords:
- dokumentumtulajdonságok
- címke
- egyéni adat
- egyéni XML
- egyéni XML rész
- XML metaadat
- ItemId
- címke hozzáadása
- páros értékek
- PowerPoint
- bemutató
- Android
- Java
- Aspose.Slides
description: "Ismerje meg, hogyan kezelhet címkéket és egyéni XML adatokat PowerPoint bemutatókban az Aspose.Slides for Android Java segítségével, beleértve a címkék hozzáadását, olvasását, frissítését, auditálását és az egyéni XML részek eltávolítását."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan működik az Aspose.Slides a címkékkel és egyéni adatokkal a PowerPoint bemutatókban. A bemutatóhoz specifikus adatokat címkékként vagy egyéni XML részeként tárolhatók. A címkék egyszerű kulcs-érték karakterlánc párok, míg az egyéni XML részek strukturált metaadatokat és alkalmazásspecifikus XML terheket tárolhatnak.

Az Aspose.Slides API-kat biztosít egyéni XML részek hozzáadásához, olvasásához, frissítéséhez, auditálásához és eltávolításához a bemutató, dia és alakzat szintjein. Az egyéni XML részek hasznosak olyan integrációkban, amelyek információkat tárolnak, például dokumentumkezelési azonosítókat, munkafolyamat állapotot, megfelelőségi metaadatokat, sablonkötési adatokat vagy más strukturált alkalmazásadatokat a bemutató belsejében.

## **Adattárolás a bemutató fájlokban**

A PPTX fájlok — a `.pptx` kiterjesztésű fájlok — a PresentationML formátumban tárolódnak, amely az Office Open XML specifikáció része. Az Office Open XML meghatározza a csomagszerkezetet és a kapcsolatokat, amelyeket a bemutató tartalmának és a kapcsolódó adatok tárolására használnak.

Egy bemutató több részből áll, amelyeket kapcsolatok kötnek össze. Például egy dia rész tartalmaz egyetlen dia tartalmát, és kifejezett kapcsolatokat tartalmazhat más részekkel, ahogyan azt az ISO/IEC 29500 definiálja.

Az egyéni adat tárolható címkéként ([ITagCollection](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ITagCollection)) vagy egyéni XML részként ([ICustomXmlPartCollection](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ICustomXmlPartCollection)). Mindkettő elérhető az [`ICustomData`](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ICustomData/) interfészen keresztül.

{{% alert color="primary" %}}
A címkék egyszerű karakterlánc kulcs-érték párokat tárolnak. Az egyéni XML részek strukturált XML adatot tárolnak, és kapcsolhatók egy bemutatóhoz, diához vagy alakzathoz.
{{% /alert %}}

## **Munkavégzés egyéni XML részekkel**

Az [`ICustomData.getCustomXmlParts()`] metódus visszaadja az adott bemutató objektumhoz kapcsolódó egyéni XML részek gyűjteményét. Például:

- `presentation.getCustomData().getCustomXmlParts()` a bemutatóhoz közvetlenül kapcsolódó egyéni XML részeket tartalmazza.
- `slide.getCustomData().getCustomXmlParts()` egy adott diához kapcsolódó egyéni XML részeket tartalmazza.
- `shape.getCustomData().getCustomXmlParts()` egy adott alakzathoz kapcsolódó egyéni XML részeket tartalmazza.

Használd a [`Presentation.getAllCustomXmlParts()`] metódust, ha a teljes bemutató összes egyéni XML részét szeretnéd megtekinteni, függetlenül attól, hogy hol vannak kapcsolva.

### **Egyéni XML rész hozzáadása a bemutatóhoz**

Használd az [`ICustomXmlPartCollection.add`](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ICustomXmlPartCollection#add-java.lang.String-) metódust XML adat hozzáadásához egy egyéni XML részgyűjteményhez. Az XML-nek érvényesnek és nem üresnek kell lennie.

A következő példa strukturált metaadatot ad a bemutató szintű egyéni adatgyűjteményhez:

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

    // add automatikusan hozzárendel egy azonosítót. Egy konkrét UUID-t csak akkor állíts be, ha szükséges.
    customXmlPart.setItemId(UUID.randomUUID());

    presentation.save("presentation_with_custom_xml.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az `add` metódus XML-t is elfogadhat bájt tömbként vagy bemeneti áramként, ami hasznos, ha az XML tartalom már bináris formában elérhető.

### **Egyéni XML rész hozzáadása diához vagy alakzathoz**

Az egyéni XML adat egy adott diához vagy alakzathoz is kapcsolható a teljes bemutató helyett. Ez hasznos, ha a metaadat csak egy objektumot ír le, például egy sablon kulcsot, külső rekordazonosítót vagy kötési információt.

A következő példa egy egyéni XML részt ad egy diához és egy másikat egy alakzathoz:

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

A rész hozzáadásának szintje meghatározza, melyik objektum `getCustomData().getCustomXmlParts()` gyűjteménye tartalmazza a részhez vezető kapcsolatot. Bemutató szintű adatok a teljes dokumentumra kiterjedő metaadatokhoz megfelelőek, dia szintű adatok egy adott diára vonatkozó információkhoz, és alakzat szintű adatok egyedi alakzathoz kapcsolódó metaadatokhoz.

### **Minden egyéni XML rész listázása és auditálása**

Használd a [`Presentation.getAllCustomXmlParts()`] metódust az összes egyéni XML rész lekéréséhez egy bemutatóból. Minden [`ICustomXmlPart`](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ICustomXmlPart/) exponálja az azonosítóját, XML tartalmát és a kapcsolódó névtér sémákat.

A következő példa kilistázza az összes egyéni XML részt és azok névtér sémáit:

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

Az [`ICustomXmlPart.getNamespaceSchemas()`](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ICustomXmlPart#getNamespaceSchemas--) visszaadja a egyéni XML részhez tartozó XML sémákat. Ez az információ hasznos lehet a prezentációk auditálásakor, amelyek külső rendszerek által előállított XML-t tartalmaznak.

### **XML tartalom és ItemId olvasása és frissítése**

Használd az [`ICustomXmlPart.getXmlAsString()`](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ICustomXmlPart#getXmlAsString--) és [`setXmlAsString()`](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ICustomXmlPart#setXmlAsString-java.lang.String-) metódusokat az XML UTF-8 szövegként történő kezeléséhez, vagy a [`getXmlData()`](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ICustomXmlPart#getXmlData--) és [`setXmlData()`](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ICustomXmlPart#setXmlData-byte:A-) metódusokat a nyers XML bájtok kezeléséhez.

Az [`ICustomXmlPart.getItemId()`](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ICustomXmlPart#getItemId--) metódus visszaadja a UUID-t, amely az egyéni XML részt az Office Open XML dokumentumban azonosítja. Használd a [`setItemId()`](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ICustomXmlPart#setItemId-java.util.UUID-) metódust, ha egy integrációnak új azonosítóra van szüksége.

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

    // A getXmlData ugyanazt az XML tartalmat biztosítja nyers bájtokként.
    byte[] customXmlData = customXmlPart.getXmlData();
    System.out.println(new String(customXmlData, StandardCharsets.UTF_8));

    // Cserélje le az azonosítót, ha az integráció megköveteli.
    customXmlPart.setItemId(UUID.randomUUID());

    presentation.save("updated_custom_xml.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`setXmlAsString` vagy `setXmlData` hívásakor adj meg érvényes, nem üres XML-t. Az egyik ábrázolást használd a másik helyett attól függően, hogy az alkalmazás főként szövegekkel vagy bájt adatokkal dolgozik.

### **Egyéni XML rész eltávolítása**

Az Aspose.Slides több módot biztosít az egyéni XML adat eltávolítására:

- [`ICustomXmlPart.remove`](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ICustomXmlPart#remove--) eltávolítja az egyéni XML részt a bemutatóból.
- [`ICustomXmlPartCollection.remove`](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ICustomXmlPartCollection#remove-com.aspose.slides.ICustomXmlPart-) egy adott részt távolít el egy egyéni XML részgyűjteményből.
- [`ICustomXmlPartCollection.removeAt`](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ICustomXmlPartCollection#removeAt-int-) a megadott gyűjtemény indexhez tartozó részt távolítja el.
- [`ICustomXmlPartCollection.clear`](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ICustomXmlPartCollection#clear--) egy adott gyűjtemény összes részét eltávolítja.

A következő példa eltávolít egy bemutató szintű egyéni XML részt referencia alapján:

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

Ha már rendelkezel egy `ICustomXmlPart` objektummal, és a bemutatóból szeretnéd eltávolítani azt egy adott gyűjtemény megcélzása nélkül, hívd a `customXmlPart.remove()` metódust.

Továbbá eltávolíthatsz egy elemet index alapján:

```java
presentation.getCustomData().getCustomXmlParts().removeAt(0);
```

### **Az összes egyéni XML rész törlése egy gyűjteményből**

`clear` használatával eltávolíthatók egy adott bemutató objektumhoz kapcsolódó összes egyéni XML rész.

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

`clear` csak a kiválasztott gyűjteményre hat. Például egy dia gyűjteményének törlése nem törli a bemutató szintű vagy alakzat szintű gyűjteményeket.

A bemutató minden egyéni XML részének eltávolításához iterálj a `getAllCustomXmlParts()` over, és távolítsd el minden részt:

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

Egy Office Open XML bemutatóban ugyanaz a egyéni XML rész több bemutató objektumból is hivatkozható. Például egy meglévő fájl tartalmazhat kapcsolódásokat több diától vagy alakzattól ugyanahhoz az alapul szolgáló egyéni XML részhez.

Egy megosztott részt úgy kell kezelni, mint egy adatobjektumot több hivatkozással:

- `setXmlAsString`, `setXmlData` vagy `setItemId` használatával a módosítás az alapul szolgáló egyéni XML részt változtatja meg, ezért a változás mindenhol érvényes, ahol a rész hivatkozott.
- `getItemId()` használható ugyanazon egyéni XML rész azonosítására az objektumszintű gyűjtemények auditálása során.
- Egy rész eltávolítása egy adott `getCustomXmlParts()` gyűjteményből csak azt a gyűjteményt érinti. Használd az `ICustomXmlPart.remove()` metódust, ha magát a részt el kell távolítani a bemutatóból.
- Megosztott rész törlése vagy cseréje előtt vizsgáld meg az objektumszintű gyűjteményeket, hogy kiderítsd, más diák vagy alakzatok még hivatkoznak-e rá.

Az `add` túlterhelések új egyéni XML részt hoznak létre XML tartalomból; nem fogadnak el meglévő `ICustomXmlPart` objektumot. Ezért a megosztott kapcsolatok leggyakrabban akkor találkozhatunk velük, amikor olyan bemutatókat töltünk be, amelyek már tartalmazzák őket.

A következő példa auditálja a bemutató, dia és alakzat szintű gyűjteményeket `ItemId` szerint, és jelentést készít a több helyről hivatkozott részekről:

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

Ezzel a fajta auditálással hasznos lehet módosítás vagy törlés előtt olyan bemutatók egyéni XML adataiban, amelyek külső rendszerek által lettek létrehozva, mivel ugyanaz a metaadat rész több kapcsolaton is részt vehet.

## **Címkék értékeinek lekérése**

A diákban egy címke a `IDocumentProperties.getKeywords()` metódusnak felel meg. Ez a minta kód bemutatja, hogyan lehet lekérni egy címke értékét az Aspose.Slides for Android Java verziójával egy [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation):

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    String keywords = presentation.getDocumentProperties().getKeywords();
} finally {
    presentation.dispose();
}
```

## **Címkék hozzáadása a bemutatókhoz**

Az Aspose.Slides lehetővé teszi címkék hozzáadását a bemutatókhoz. Egy címke általában két elemből áll:
- egy egyéni tulajdonság neve, például `MyTag`;
- a egyéni tulajdonság értéke, például `My Tag Value`.

Ha a bemutatókat egy adott szabály vagy tulajdonság alapján szeretnéd osztályozni, hozzáadhatsz címkéket ehhez a célhoz. Például, ha az Észak-Amerikai országokból származó bemutatókat szeretnéd kategorizálni, létrehozhatsz egy Észak-Amerikai címkét, és a releváns országot adhatod meg értékként.

Ez a minta kód bemutatja, hogyan lehet címkét hozzáadni egy [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation) objektumhoz az Aspose.Slides for Android Java használatával:

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

A címkék beállíthatók egy [Slide](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ISlide) objektumhoz is:

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

Vagy egy egyedi [Shape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IAutoShape) objektumhoz:

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

A `getCustomData().getTags()` gyűjteményen keresztül hozzáadott címkék csak a PowerPoint fájlban tárolódnak. **Nem** kerülnek át a PDF címke struktúrába, amikor a bemutatót PDF-be exportálják. Ennek következtében egy címkére rendelt egyéni azonosítót nem lehet visszanyerni a címkézett PDF-ből.

**Megoldás**: A egyéni azonosítót tárolhatod az objektum **Alt Text** mezőjében (például `shape.setAlternativeText("MyId")`). PDF-be exportálás után az Alt Text megjelenhet a PDF címke struktúrában.

## **GYIK**

**Eltávolíthatok minden címkét egy bemutatóból, diából vagy alakzatból egyetlen műveletben?**

Igen. A [tag collection](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/tagcollection/) támogatja a [clear](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/tagcollection/#clear--) műveletet, amely egyszerre törli az összes kulcs-érték párt.

**Hogyan törölhetek egyetlen címkét a nevén anélkül, hogy végig iterálnék az egész gyűjteményen?**

Használd a [remove(name)](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/tagcollection/#remove-java.lang.String-) metódust a [tag collection](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/tagcollection/) objektumon a címke kulcsa szerinti törléshez.

**Hogyan szerezhetem meg a címkék nevének teljes listáját elemzéshez vagy szűréshez?**

Használd a [getNamesOfTags](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/tagcollection/#getNamesOfTags--) metódust a [tag collection](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/tagcollection/) objektumon; ez egy tömböt ad vissza az összes címkenévvel.

**Hogyan találhatom meg az összes egyéni XML részt, függetlenül attól, hogy hol tárolódnak?**

Használd a [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation#getAllCustomXmlParts--) metódust az összes egyéni XML rész lekéréséhez a bemutatóban.

**Érdemes `getXmlAsString`/`setXmlAsString` vagy `getXmlData`/`setXmlData` metódusokat használni egy egyéni XML rész frissítéséhez?**

Használd a `getXmlAsString` és `setXmlAsString` metódusokat, ha az alkalmazás UTF-8 XML szöveggel dolgozik. Használd a `getXmlData` és `setXmlData` metódusokat, ha az XML már bájt tömbként elérhető, vagy ha a bináris feldolgozás kényelmesebb. Mindkét ábrázolás ugyanazon egyéni XML rész XML tartalmára vonatkozik.
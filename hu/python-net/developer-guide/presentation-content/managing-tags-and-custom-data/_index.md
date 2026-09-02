---
title: Címkék és egyéni adatok kezelése prezentációkban Python segítségével
linktitle: Címkék és egyéni adatok
type: docs
weight: 300
url: /hu/python-net/managing-tags-and-custom-data/
keywords:
- dokumentum tulajdonságok
- címke
- egyéni adat
- egyéni XML
- egyéni XML rész
- XML metaadat
- ElemAzonosító
- címke hozzáadása
- páros értékek
- PowerPoint
- prezentáció
- Python
- Aspose.Slides
description: "Ismerje meg, hogyan kezelheti a címkéket és az egyéni XML adatokat PowerPoint prezentációkban az Aspose.Slides for Python via .NET segítségével, beleértve a hozzáadást, olvasást, frissítést, auditálást és az egyéni XML részek eltávolítását."
---
## **Áttekintés**

Ez a cikk elmagyarázza, hogyan működik az Aspose.Slides a címkékkel és az egyedi adatokkal a PowerPoint‑prezentációkban. A prezentációra jellemző adatokat címkék vagy egyéni XML‑részekként tárolhatja. A címkék egyszerű kulcs‑érték karakterlánc párok, míg az egyéni XML‑részek strukturált metaadatokat és alkalmazás‑specifikus XML‑terhelt adatokat tárolhatnak.

Az Aspose.Slides API‑kat biztosít egyéni XML‑részek hozzáadásához, olvasásához, frissítéséhez, auditálásához és eltávolításához a prezentáció, dia és alakzat szintjén. Az egyéni XML‑részek hasznosak olyan integrációkhoz, amelyek információkat tárolnak, például dokumentum‑kezelő azonosítókat, munkafolyamat‑állapotot, megfelelőségi metaadatokat, sablon‑kötési adatokat vagy más strukturált alkalmazásadatokat a prezentációban.

## **Adattárolás a prezentációfájokban**

A `.pptx` kiterjesztésű PPTX fájlok a PresentationML formátumban vannak tárolva, amely az Office Open XML specifikáció része. Az Office Open XML meghatározza a csomagstruktúrát és a kapcsolatrendszert, amelyet a prezentáció tartalmának és kapcsolódó adatainak tárolására használnak.

Egy prezentáció több részből áll, amelyeket kapcsolatok kötnek össze. Például egy dia rész tartalmazza egyetlen dia tartalmát, és explicite kapcsolatokkal rendelkezhet más részekre, ahogy azt az ISO/IEC 29500 definiálja.

Az egyéni adatokat címkék ([TagCollection](https://reference.aspose.com/slides/hu/python-net/aspose.slides/tagcollection/)) vagy egyéni XML‑részek ([CustomXmlPartCollection](https://reference.aspose.com/slides/hu/python-net/aspose.slides/customxmlpartcollection/)) formájában tárolhatja. Mindkettő elérhető a [`CustomData`](https://reference.aspose.com/slides/hu/python-net/aspose.slides/customdata/) osztályon keresztül.

{{% alert color="primary" %}}
A címkék egyszerű karakterlánc kulcs‑érték párokat tárolnak. Az egyéni XML‑részek strukturált XML adatot tárolnak, és egy prezentációhoz, diához vagy alakzathoz kapcsolhatók.
{{% /alert %}}

## **Egyéni XML‑részek kezelése**

A [`CustomData.custom_xml_parts`](https://reference.aspose.com/slides/hu/python-net/aspose.slides/customdata/custom_xml_parts/) tulajdonság visszaadja az adott prezentációs objektumhoz kapcsolódó egyéni XML‑részek gyűjteményét. Például:

- `presentation.custom_data.custom_xml_parts` a prezentációhoz tartozó egyéni XML‑részeket tartalmazza.
- `slide.custom_data.custom_xml_parts` egy adott diához tartozó egyéni XML‑részeket tartalmazza.
- `shape.custom_data.custom_xml_parts` egy adott alakzathoz tartozó egyéni XML‑részeket tartalmazza.

Használja a [`Presentation.all_custom_xml_parts`](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/all_custom_xml_parts/) metódust, ha a teljes prezentációban, függetlenül attól, hogy hol vannak hozzárendelve, meg szeretné vizsgálni az összes egyéni XML‑részt.

### **Egyéni XML‑rész hozzáadása egy prezentációhoz**

Használja a [`CustomXmlPartCollection.add`](https://reference.aspose.com/slides/hu/python-net/aspose.slides/customxmlpartcollection/add/) metódust XML‑adat hozzáadásához egy egyéni XML‑részek gyűjteményéhez. Az XML-nek érvényesnek és nem üresnek kell lennie.

A következő példa strukturált metaadatot ad a prezentációs szintű egyéni adatgyűjteményhez:

```py
import uuid
import aspose.slides as slides

custom_xml_content = (
    '<?xml version="1.0" encoding="UTF-8"?>'
    '<metadata xmlns="urn:example:metadata">'
    '<documentId>DOC-1001</documentId>'
    '<workflowState>Draft</workflowState>'
    '</metadata>'
)

with slides.Presentation() as presentation:
    custom_xml_part = presentation.custom_data.custom_xml_parts.add(custom_xml_content)

    # a hozzáadás automatikusan kioszt egy azonosítót. Egy meghatározott GUID-ot csak akkor állítson be, ha szükséges.
    custom_xml_part.item_id = uuid.uuid4()

    presentation.save("presentation_with_custom_xml.pptx", slides.export.SaveFormat.PPTX)
```

Az `add` metódus XML‑t byte‑tömbként vagy stream‑ként is képes fogadni, ami akkor hasznos, ha az XML‑tartalom már bináris formában elérhető.

### **Egyéni XML‑rész hozzáadása egy diára vagy alakzatra**

Az egyéni XML‑adatot egy adott diához vagy alakzathoz is hozzárendelheti a teljes prezentáció helyett. Ez akkor hasznos, ha a metaadat csak egy objektumra vonatkozik, például egy sablon‑kulcsra, külső rekord‑azonosítóra vagy kötési információra.

A következő példa egy egyéni XML‑részt ad egy diához, egy másikat pedig egy alakzathoz:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    slide.custom_data.custom_xml_parts.add(
        '<slideMetadata xmlns="urn:example:slides">'
        '<templateKey>TitleSlide</templateKey>'
        '</slideMetadata>'
    )

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 250, 80)

    shape.text_frame.text = "Customer data"
    shape.custom_data.custom_xml_parts.add(
        '<shapeMetadata xmlns="urn:example:shapes">'
        '<recordId>CRM-4281</recordId>'
        '</shapeMetadata>'
    )

    presentation.save("object_custom_xml.pptx", slides.export.SaveFormat.PPTX)
```

Az a szint, amelyen a rész hozzáadásra kerül, meghatározza, hogy melyik objektum `custom_data.custom_xml_parts` gyűjteménye tartalmazza a részhez tartozó kapcsolatot. A prezentáció‑szintű adatok a dokumentum‑széles metaadatokra, a dia‑szintű adatok egy adott diához, a alakzat‑szintű adatok pedig egyedi alakzathoz kapcsolódnak.

### **Az összes egyéni XML‑rész listázása és auditálása**

Használja a [`Presentation.all_custom_xml_parts`](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/all_custom_xml_parts/) metódust az összes egyéni XML‑rész lekéréséhez a prezentációból. Minden [`CustomXmlPart`](https://reference.aspose.com/slides/hu/python-net/aspose.slides/customxmlpart/) exponálja az azonosítóját, az XML‑tartalmát és a kapcsolódó névtér‑sémákat.

A következő példa listázza az összes egyéni XML‑részt és azok névtér‑sémáit:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for custom_xml_part in presentation.all_custom_xml_parts:
        print("ItemId: " + str(custom_xml_part.item_id))
        print("XML:")
        print(custom_xml_part.xml_as_string)

        for namespace_schema in custom_xml_part.namespace_schemas:
            print("Namespace schema: " + namespace_schema)

        print()
```

A [`CustomXmlPart.namespace_schemas`](https://reference.aspose.com/slides/hu/python-net/aspose.slides/customxmlpart/namespace_schemas/) visszaadja az egyéni XML‑részhez tartozó XML‑sémákat. Ez az információ hasznos lehet a külső rendszerek által generált XML‑t tartalmazó prezentációk auditálásakor.

### **XML‑tartalom és ItemId olvasása és frissítése**

Használja a [`CustomXmlPart.xml_as_string`](https://reference.aspose.com/slides/hu/python-net/aspose.slides/customxmlpart/xml_as_string/) metódust XML‑kialakítás UTF‑8 szövegként való kezelésére, vagy a [`CustomXmlPart.xml_data`](https://reference.aspose.com/slides/hu/python-net/aspose.slides/customxmlpart/xml_data/) metódust a nyers XML‑byte‑ok kezelésére. Mindkét tulajdonság olvasható és módosítható.

A [`CustomXmlPart.item_id`](https://reference.aspose.com/slides/hu/python-net/aspose.slides/customxmlpart/item_id/) tulajdonság tartalmazza azt a GUID‑et, amely az egyéni XML‑részt az Office Open XML dokumentumban azonosítja. Ez új azonosítóra is cserélhető, ha egy integrációnak erre van szüksége.

A következő példa frissíti az XML‑tartalmat és az azonosítót:

```py
import uuid
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    custom_xml_part = presentation.all_custom_xml_parts[0]

    # Olvassa be a jelenlegi XML-t szövegként.
    current_xml_content = custom_xml_part.xml_as_string
    print(current_xml_content)

    # Frissítse az XML-t UTF-8 karakterláncként.
    custom_xml_part.xml_as_string = (
        '<metadata xmlns="urn:example:metadata">'
        '<documentId>DOC-1001</documentId>'
        '<workflowState>Approved</workflowState>'
        '</metadata>'
    )

    # az xml_data ugyanazt az XML-t tartalmazza nyers bájtokként.
    custom_xml_data = custom_xml_part.xml_data
    print(custom_xml_data.decode("utf-8"))

    # Cserélje le az azonosítót, ha az integráció megköveteli.
    custom_xml_part.item_id = uuid.uuid4()

    presentation.save("updated_custom_xml.pptx", slides.export.SaveFormat.PPTX)
```

Az `xml_as_string` vagy `xml_data` értékadásakor érvényes, nem üres XML‑t kell megadni. Az egyik vagy a másik ábrázolást válassza attól függően, hogy az alkalmazás főként szöveggel vagy bájtadatokkal dolgozik.

### **Egyéni XML‑rész eltávolítása**

Az Aspose.Slides több módot is biztosít az egyéni XML‑adatok eltávolítására:

- [`CustomXmlPart.remove`](https://reference.aspose.com/slides/hu/python-net/aspose.slides/customxmlpart/remove/) eltávolítja az egyéni XML‑részt a prezentációból.
- [`CustomXmlPartCollection.remove`](https://reference.aspose.com/slides/hu/python-net/aspose.slides/customxmlpartcollection/remove/) eltávolít egy konkrét részt egy egyéni XML‑rész gyűjteményből.
- [`CustomXmlPartCollection.remove_at`](https://reference.aspose.com/slides/hu/python-net/aspose.slides/customxmlpartcollection/remove_at/) eltávolítja a részt a megadott indexű gyűjteményből.
- [`CustomXmlPartCollection.clear`](https://reference.aspose.com/slides/hu/python-net/aspose.slides/customxmlpartcollection/clear/) eltávolítja az összes részt egy adott gyűjteményből.

A következő példa egy prezentáció‑szintű egyéni XML‑részt távolít el hivatkozás alapján:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    custom_xml_parts = presentation.custom_data.custom_xml_parts

    if len(custom_xml_parts) > 0:
        custom_xml_part = custom_xml_parts[0]
        custom_xml_parts.remove(custom_xml_part)

    presentation.save("custom_xml_removed.pptx", slides.export.SaveFormat.PPTX)
```

Ha már rendelkezik egy `CustomXmlPart` példánnyal, és azt szeretné eltávolítani a prezentációból egy adott gyűjtemény helyett, hívja a `custom_xml_part.remove()` metódust.

Elemet index alapján is eltávolíthat:

```py
presentation.custom_data.custom_xml_parts.remove_at(0)
```

### **Az összes egyéni XML‑rész törlése egy gyűjteményből**

Használja a `clear` metódust, amikor egy adott prezentációs objektumhoz kapcsolódó összes egyéni XML‑részt el szeretné távolítani.

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.slides[0].custom_data.custom_xml_parts.clear()

    presentation.save("slide_custom_xml_cleared.pptx", slides.export.SaveFormat.PPTX)
```

A `clear` csak a kiválasztott gyűjteményre hat. Például egy dia gyűjteményének törlése nem érinti a prezentáció‑szintű vagy alakzat‑szintű gyűjteményeket.

Az összes egyéni XML‑rész eltávolításához a prezentációban iteráljon a `all_custom_xml_parts` gyűjteményen, és távolítsa el minden részt:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for custom_xml_part in presentation.all_custom_xml_parts:
        custom_xml_part.remove()

    presentation.save("all_custom_xml_removed.pptx", slides.export.SaveFormat.PPTX)
```

### **Kapcsolt vagy megosztott egyéni XML‑részek kezelése**

Egy Office Open XML prezentációban ugyanaz a egyéni XML‑rész több prezentációs objektumtól is hivatkozható. Például egy meglévő fájl tartalmazhat kapcsolókat több diáról vagy alakzatról ugyanarra az alapszintű egyéni XML‑részre.

A megosztott részt egyetlen adatobjektumként kell kezelni több hivatkozással:

- A `xml_as_string`, `xml_data` vagy `item_id` frissítése módosítja az alapszintű egyéni XML‑részt, így a változás minden hivatkozásnál megjelenik.
- Az `item_id` használható ugyanazon egyéni XML‑rész azonosítására az objektumszintű gyűjtemények auditálása közben.
- Egy rész eltávolítása egy konkrét `custom_xml_parts` gyűjteményből csak azt a gyűjteményt érinti. Használja a `CustomXmlPart.remove()` metódust, ha a részt magától a prezentációból kell eltávolítani.
- Megosztott rész törlése vagy cseréje előtt ellenőrizze az objektumszintű gyűjteményeket, hogy más diák vagy alakzatok még hivatkoznak‑e rá.

Az `add` túlterhelések új egyéni XML‑részt hoznak létre XML‑tartalomból; nem fogadnak el meglévő `CustomXmlPart` példányt. Ezért a megosztott kapcsolatok leggyakrabban olyan prezentációk betöltésekor fordulnak elő, amelyek már tartalmazzák őket.

A következő példa auditálja a prezentáció‑, dia‑ és alakzat‑szintű gyűjteményeket `item_id` alapján, és feljegyzi a több helyről hivatkozott részeket:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    references_by_item_id = {}

    def register_custom_xml_parts(owner_name, custom_xml_parts):
        for custom_xml_part in custom_xml_parts:
            references_by_item_id.setdefault(custom_xml_part.item_id, []).append(owner_name)

    register_custom_xml_parts("Presentation", presentation.custom_data.custom_xml_parts)

    for slide_index, slide in enumerate(presentation.slides):
        register_custom_xml_parts(
            "Slide " + str(slide_index + 1),
            slide.custom_data.custom_xml_parts
        )

        for shape_index, shape in enumerate(slide.shapes):
            register_custom_xml_parts(
                "Slide " + str(slide_index + 1) + ", shape " + str(shape_index),
                shape.custom_data.custom_xml_parts
            )

    for item_id, owner_names in references_by_item_id.items():
        if len(owner_names) > 1:
            print("Shared custom XML part: " + str(item_id))

            for owner_name in owner_names:
                print("  Referenced by: " + owner_name)
```

Ez a fajta auditálás hasznos a külső rendszerek által létrehozott prezentációk egyéni XML‑adatai módosítása vagy törlése előtt, mivel ugyanaz a metaadat‑rész több kapcsolatban is részt vehet.

## **Címkék értékeinek lekérése**

A diákban egy címke a `DocumentProperties.keywords` tulajdonságnak felel meg. Ez a minta kód bemutatja, hogyan lehet egy címke értékét lekérni az Aspose.Slides for Python via .NET‑el a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) objektumhoz:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    keywords = presentation.document_properties.keywords
```

## **Címkék hozzáadása a prezentációkhoz**

Az Aspose.Slides lehetővé teszi címkék hozzáadását a prezentációkhoz. Egy címke általában két elemből áll:

- egy egyedi tulajdonság neve, például `MyTag`;
- az egyedi tulajdonság értéke, például `My Tag Value`.

Ha egy adott szabály vagy tulajdonság alapján szeretné osztályozni a prezentációkat, hozzáadhat címkéket erre a célra. Például, ha az Észak‑Amerikai országokból származó prezentációkat szeretné kategorizálni, létrehozhat egy „North American” címkét, és a megfelelő országot állíthatja be értékként.

Ez a minta kód bemutatja, hogyan lehet egy címkét hozzáadni egy [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) objektumhoz az Aspose.Slides for Python via .NET‑el:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    tags = presentation.custom_data.tags
    tags.add("MyTag", "My Tag Value")
```

A címkék beállíthatók egy [Slide](https://reference.aspose.com/slides/hu/python-net/aspose.slides/slide/) objektumra is:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    slide.custom_data.tags.add("tag", "value")
```

Vagy egy egyedi [Shape](https://reference.aspose.com/slides/hu/python-net/aspose.slides/shape/) objektumra:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 50)
    shape.text_frame.text = "My text"
    shape.custom_data.tags.add("tag", "value")
```

### **Korlátozások**

A `custom_data.tags` gyűjteményen keresztül hozzáadott címkék csak a PowerPoint fájlban tárolódnak. **Nem** kerülnek átvitelre a PDF címke‑struktúrába, amikor a prezentációt PDF‑be exportálják. Ennek következtében egy egyedi azonosító, amely címkeként van megadva, nem olvasható ki a címkével ellátott PDF‑ből.

**Megoldás**: Az egyedi azonosítót tárolhatja az objektum **Alt Text**‑ében (például `shape.alternative_text = "MyId"`). PDF‑export után az Alt Text megjelenhet a PDF címke‑struktúrában.

## **GYIK**

**Eltávolíthatom az összes címkét egy prezentációból, diából vagy alakzatból egyetlen művelettel?**

Igen. A [tag collection](https://reference.aspose.com/slides/hu/python-net/aspose.slides/tagcollection/) támogatja a [clear](https://reference.aspose.com/slides/hu/python-net/aspose.slides/tagcollection/clear/) műveletet, amely egy lépésben törli az összes kulcs‑érték párt.

**Hogyan töröljek egyetlen címkét a nevén anélkül, hogy végigiterálnék a teljes gyűjteményen?**

Használja a [remove(name)](https://reference.aspose.com/slides/hu/python-net/aspose.slides/tagcollection/remove/) metódust a [TagCollection](https://reference.aspose.com/slides/hu/python-net/aspose.slides/tagcollection/)‑on a címke kulcsa alapján történő törléshez.

**Hogyan tudom lekérni a címkék teljes nevének listáját elemzés vagy szűrés céljából?**

Használja a [get_names_of_tags](https://reference.aspose.com/slides/hu/python-net/aspose.slides/tagcollection/get_names_of_tags/) metódust a [tag collection](https://reference.aspose.com/slides/hu/python-net/aspose.slides/tagcollection/)‑on; ez egy tömböt ad vissza az összes címkenévről.

**Hogyan találhatom meg az összes egyéni XML‑részt, függetlenül attól, hogy hol vannak tárolva?**

Használja a [`Presentation.all_custom_xml_parts`](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/all_custom_xml_parts/) metódust az összes egyéni XML‑rész lekéréséhez a prezentációban.

**`xml_as_string` vagy `xml_data`‑t kellene használnom egy egyéni XML‑rész frissítéséhez?**

Használja az `xml_as_string`‑et, ha az alkalmazás UTF‑8 XML szöveggel dolgozik. Használja az `xml_data`‑t, ha az XML már byte‑tömbként áll rendelkezésre, vagy ha a bináris feldolgozás kényelmesebb. Mindkét tulajdonság ugyanazt a egyéni XML‑részt reprezentálja.
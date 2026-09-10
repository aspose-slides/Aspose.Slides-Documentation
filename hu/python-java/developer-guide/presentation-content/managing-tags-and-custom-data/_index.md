---
title: Címkék és egyedi adatok kezelése a prezentációkban Python segítségével
linktitle: Címkék és egyedi adatok
type: docs
weight: 300
url: /hu/python-java/managing-tags-and-custom-data/
keywords:
  - dokumentum tulajdonságok
  - címke
  - egyedi adat
  - egyedi XML
  - egyedi XML rész
  - XML metaadat
  - ItemId
  - címke hozzáadása
  - értékpárok
  - PowerPoint
  - prezentáció
  - Python
  - Aspose.Slides
description: "Ismerje meg, hogyan kezelhet címkéket és egyedi XML adatokat PowerPoint prezentációkban az Aspose.Slides for Python via Java segítségével, beleértve a hozzáadást, olvasást, frissítést, auditálást és az egyedi XML részek eltávolítását."
---
## **Áttekintés**

Ez a cikk elmagyarázza, hogyan működik az Aspose.Slides a címkékkel és az egyedi adatokkal a PowerPoint előadásokban. Az előadáshoz specifikus adatokat címkék vagy custom XML parts formájában lehet tárolni. A címkék egyszerű kulcs‑érték karakterlánc párok, míg a custom XML parts strukturált metaadatokat és alkalmazásspecifikus XML payload‑okat tárolhatnak.

Az Aspose.Slides API‑kat biztosít az custom XML parts hozzáadásához, olvasásához, frissítéséhez, auditálásához és eltávolításához a prezentáció, dia és alakzat szinteken. A custom XML parts hasznosak integrációkhoz, amelyek információkat tárolnak, például dokumentumkezelési azonosítókat, munkafolyamat állapotot, megfelelőségi metaadatokat, sablon‑kötési adatokat vagy más strukturált alkalmazásadatokat egy prezentációban.

## **Adattárolás a prezentációs fájlokban**

A PPTX fájlok — a `.pptx` kiterjesztésű fájlok — a PresentationML formátumban tárolódnak, amely az Office Open XML specifikáció része. Az Office Open XML definiálja a csomagstruktúrát és a kapcsolatrendszert, amelyet a prezentáció tartalmának és a kapcsolódó adatok tárolására használnak.

Egy prezentáció több részt tartalmaz, amelyeket kapcsolatok kötnek össze. Például egy diaréteg (slide part) tartalmazza egyetlen dia tartalmát, és kifejezett kapcsolatokkal rendelkezhet más részekhez, amelyeket az ISO/IEC 29500 definiál.

Az egyedi adat tárolható címkéként ([TagCollection](https://reference.aspose.com/slides/hu/python-java/aspose.slides/tagcollection/)) vagy custom XML részként ([CustomXmlPartCollection](https://reference.aspose.com/slides/hu/python-java/aspose.slides/customxmlpartcollection/)). Mindkettő elérhető a [CustomData](https://reference.aspose.com/slides/hu/python-java/aspose.slides/customdata/) osztályon keresztül.

{{% alert color="info" title="Megjegyzés" %}}
A címkék egyszerű karakterlánc kulcs‑érték párokat tárolnak. Az custom XML parts strukturált XML adatot tárolnak, és egy prezentációhoz, diához vagy alakzathoz társíthatók.
{{% /alert %}}

## **Egyedi XML részek kezelése**

A [CustomData.getCustomXmlParts](https://reference.aspose.com/slides/hu/python-java/aspose.slides/customdata/#getCustomXmlParts) metódus visszaadja az adott prezentációobjektumhoz társított custom XML parts gyűjteményét. Például:

- A prezentáció [CustomData.getCustomXmlParts](https://reference.aspose.com/slides/hu/python-java/aspose.slides/customdata/#getCustomXmlParts) gyűjteménye az önmagához tartozó custom XML parts‑t tartalmazza.
- A dia [CustomData.getCustomXmlParts](https://reference.aspose.com/slides/hu/python-java/aspose.slides/customdata/#getCustomXmlParts) gyűjteménye az adott diához társított custom XML parts‑t tartalmazza.
- Az alakzat [CustomData.getCustomXmlParts](https://reference.aspose.com/slides/hu/python-java/aspose.slides/customdata/#getCustomXmlParts) gyűjteménye az adott alakzathoz társított custom XML parts‑t tartalmazza.

Használja a [Presentation.getAllCustomXmlParts](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/#getAllCustomXmlParts) metódust, ha a prezentációban lévő összes custom XML part‑ot meg szeretné vizsgálni, függetlenül attól, hogy hol vannak társítva.

### **Egyedi XML rész hozzáadása a prezentációhoz**

Használja a [CustomXmlPartCollection.add](https://reference.aspose.com/slides/hu/python-java/aspose.slides/customxmlpartcollection/#add) metódust XML adatok hozzáadásához egy custom XML part gyűjteményhez. Az XML‑nek érvényesnek és nem üresnek kell lennie.

A következő példa strukturált metaadatokat ad a prezentáció‑szintű custom data gyűjteményhez:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat
from java.util import UUID

presentation = Presentation()
try:
    custom_xml_content = '<?xml version="1.0" encoding="UTF-8"?><metadata xmlns="urn:example:metadata"><documentId>DOC-1001</documentId><workflowState>Draft</workflowState></metadata>'
    custom_xml_part = presentation.getCustomData().getCustomXmlParts().add(custom_xml_content)

    # A add automatikusan hozzárendel egy azonosítót. Különleges UUID-t csak akkor állítson be, ha szükséges.
    item_id = UUID.randomUUID()
    custom_xml_part.setItemId(item_id)

    presentation.save("presentation_with_custom_xml.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Az [add](https://reference.aspose.com/slides/hu/python-java/aspose.slides/customxmlpartcollection/#add) metódus XML‑t is elfogadhat bájt tömbként vagy bemeneti áramként, ami akkor hasznos, ha az XML tartalom már bináris formában elérhető.

### **Egyedi XML rész hozzáadása diához vagy alakzathoz**

Az egyedi XML adat összekapcsolható egy adott diával vagy alakzattal a teljes prezentáció helyett. Ez akkor hasznos, ha a metaadat csak egy objektumot ír le, például egy sablon kulcsot, külső rekord azonosítót vagy kötési információt.

A következő példa egy egyedi XML részt ad egy diához és egy másikat egy alakzathoz:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    slide_xml_content = '<slideMetadata xmlns="urn:example:slides"><templateKey>TitleSlide</templateKey></slideMetadata>'
    slide.getCustomData().getCustomXmlParts().add(slide_xml_content)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 250, 80)
    shape.getTextFrame().setText("Customer data")
    shape_xml_content = '<shapeMetadata xmlns="urn:example:shapes"><recordId>CRM-4281</recordId></shapeMetadata>'
    shape.getCustomData().getCustomXmlParts().add(shape_xml_content)

    presentation.save("object_custom_xml.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Az a szint, amelyen a rész hozzá van adva, meghatározza, hogy melyik objektum [CustomData.getCustomXmlParts](https://reference.aspose.com/slides/hu/python-java/aspose.slides/customdata/#getCustomXmlParts) gyűjteménye tartalmazza a részhez tartozó kapcsolatot. A prezentáció‑szintű adat a dokumentum‑szintű metaadatokhoz alkalmas, a dia‑szintű adat egy adott diához tartozó információkhoz, és az alakzat‑szintű adat egyedi alakzathoz kötött metaadatokhoz.

### **Az összes egyedi XML rész listázása és auditálása**

Használja a [Presentation.getAllCustomXmlParts](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/#getAllCustomXmlParts) metódust az összes custom XML part lekéréséhez egy prezentációból. Minden [CustomXmlPart](https://reference.aspose.com/slides/hu/python-java/aspose.slides/customxmlpart/) megjeleníti az azonosítóját, az XML tartalmát és a kapcsolódó névtér sémákat.

A következő példa felsorolja az összes custom XML part‑ot és azok névtér sémáit:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    for custom_xml_part in presentation.getAllCustomXmlParts():
        print("ItemId:", custom_xml_part.getItemId())
        print("XML:")
        print(custom_xml_part.getXmlAsString())

        for namespace_schema in custom_xml_part.getNamespaceSchemas():
            print("Namespace schema:", namespace_schema)

        print()
finally:
    presentation.dispose()
```

A [CustomXmlPart.getNamespaceSchemas](https://reference.aspose.com/slides/hu/python-java/aspose.slides/customxmlpart/#getNamespaceSchemas) visszaadja az egyedi XML részhez kapcsolódó XML sémákat. Ez az információ hasznos lehet olyan prezentációk auditálásakor, amelyek külső rendszerek által előállított XML‑t tartalmaznak.

### **XML tartalom és ItemId olvasása és frissítése**

Használja a [CustomXmlPart.getXmlAsString](https://reference.aspose.com/slides/hu/python-java/aspose.slides/customxmlpart/#getXmlAsString) és [setXmlAsString](https://reference.aspose.com/slides/hu/python-java/aspose.slides/customxmlpart/#setXmlAsString) metódusokat XML UTF‑8 karakterláncként való kezeléséhez, vagy a [getXmlData](https://reference.aspose.com/slides/hu/python-java/aspose.slides/customxmlpart/#getXmlData) és [setXmlData](https://reference.aspose.com/slides/hu/python-java/aspose.slides/customxmlpart/#setXmlData) metódusokat a nyers XML bájtok kezeléséhez.

A [CustomXmlPart.getItemId](https://reference.aspose.com/slides/hu/python-java/aspose.slides/customxmlpart/#getItemId) metódus visszaadja azt az UUID‑t, amely az egyedi XML part‑ot az Office Open XML dokumentumban azonosítja. Használja a [setItemId](https://reference.aspose.com/slides/hu/python-java/aspose.slides/customxmlpart/#setItemId) metódust, ha egy integrációnak új azonosító szükséges.

A következő példa frissíti az XML tartalmat és az azonosítót:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat
from java.util import UUID

presentation = Presentation("presentation.pptx")
try:
    custom_xml_parts = presentation.getAllCustomXmlParts()
    if len(custom_xml_parts) > 0:
        custom_xml_part = custom_xml_parts[0]

        # Olvassa be a jelenlegi XML-t szövegként.
        current_xml_content = custom_xml_part.getXmlAsString()
        print(current_xml_content)

        # Frissítse az XML-t UTF-8 karakterláncként.
        custom_xml_content = '<metadata xmlns="urn:example:metadata"><documentId>DOC-1001</documentId><workflowState>Approved</workflowState></metadata>'
        custom_xml_part.setXmlAsString(custom_xml_content)

        # A getXmlData ugyanazt az XML tartalmat nyers bájtokként biztosítja.
        custom_xml_data = custom_xml_part.getXmlData()
        print(bytes(custom_xml_data).decode("utf-8"))

        # Cserélje ki az azonosítót, ha az integráció megköveteli.
        item_id = UUID.randomUUID()
        custom_xml_part.setItemId(item_id)

        presentation.save("updated_custom_xml.pptx", SaveFormat.Pptx)
    else:
        print("No custom XML parts found.")
finally:
    presentation.dispose()
```

A [setXmlAsString](https://reference.aspose.com/slides/hu/python-java/aspose.slides/customxmlpart/#setXmlAsString) vagy a [setXmlData](https://reference.aspose.com/slides/hu/python-java/aspose.slides/customxmlpart/#setXmlData) hívásakor adjon meg érvényes, nem üres XML‑t. Az egyik vagy a másik ábrázolást használja attól függően, hogy az alkalmazás elsődlegesen karakterláncokkal vagy bájt adatokkal dolgozik.

### **Egyedi XML rész eltávolítása**

Az Aspose.Slides több módot kínál az egyedi XML adatok eltávolítására:

- A [CustomXmlPart.remove](https://reference.aspose.com/slides/hu/python-java/aspose.slides/customxmlpart/#remove) eltávolítja az egyedi XML részt a prezentációból.
- A [CustomXmlPartCollection.remove](https://reference.aspose.com/slides/hu/python-java/aspose.slides/customxmlpartcollection/#remove) egy adott részt távolít el egy custom XML part gyűjteményből.
- A [CustomXmlPartCollection.removeAt](https://reference.aspose.com/slides/hu/python-java/aspose.slides/customxmlpartcollection/#removeAt) a megadott gyűjteményindexnél lévő részt távolítja el.
- A [CustomXmlPartCollection.clear](https://reference.aspose.com/slides/hu/python-java/aspose.slides/customxmlpartcollection/#clear) egy adott gyűjtemény összes részét eltávolítja.

A következő példa egy prezentáció‑szintű egyedi XML részt távolít el referencia alapján:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    custom_xml_parts = presentation.getCustomData().getCustomXmlParts()
    if custom_xml_parts.size() > 0:
        custom_xml_part = custom_xml_parts.get_Item(0)
        custom_xml_parts.remove(custom_xml_part)

    presentation.save("custom_xml_removed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Ha már rendelkezik egy [CustomXmlPart](https://reference.aspose.com/slides/hu/python-java/aspose.slides/customxmlpart/)‑al, és a prezentációból szeretné eltávolítani a részt, ahelyett, hogy egy adott gyűjteményt célozna meg, hívja a [CustomXmlPart.remove](https://reference.aspose.com/slides/hu/python-java/aspose.slides/customxmlpart/#remove) metódust.

Egy elemet index alapján is eltávolíthat:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    custom_xml_parts = presentation.getCustomData().getCustomXmlParts()
    if custom_xml_parts.size() > 0:
        custom_xml_parts.removeAt(0)
finally:
    presentation.dispose()
```

### **Az összes egyedi XML rész törlése egy gyűjteményből**

Használja a [clear](https://reference.aspose.com/slides/hu/python-java/aspose.slides/customxmlpartcollection/#clear) metódust, ha egy adott prezentációobjektumhoz kapcsolódó összes egyedi XML part‑ot el kell távolítani.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    presentation.getSlides().get_Item(0).getCustomData().getCustomXmlParts().clear()

    presentation.save("slide_custom_xml_cleared.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

A [clear](https://reference.aspose.com/slides/hu/python-java/aspose.slides/customxmlpartcollection/#clear) csak a kiválasztott gyűjteményre hat. Például egy dia gyűjteményének törlése nem törli a prezentáció‑szintű vagy az alakzat‑szintű gyűjteményeket.

A prezentációban lévő minden egyedi XML part eltávolításához iteráljon a [getAllCustomXmlParts](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/#getAllCustomXmlParts) segítségével, és távolítsa el minden részt:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    for custom_xml_part in presentation.getAllCustomXmlParts():
        custom_xml_part.remove()

    presentation.save("all_custom_xml_removed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Kapcsolt vagy megosztott egyedi XML részek kezelése**

Egy Office Open XML prezentációban ugyanaz a custom XML part több prezentációobjektumról is hivatkozható. Például egy létező fájl tartalmazhat kapcsolatokat több diából vagy alakzatból ugyanahhoz az alaprészhez.

A megosztott részt egy adatobjektumként kell kezelni több hivatkozással:

- A [setXmlAsString](https://reference.aspose.com/slides/hu/python-java/aspose.slides/customxmlpart/#setXmlAsString), [setXmlData](https://reference.aspose.com/slides/hu/python-java/aspose.slides/customxmlpart/#setXmlData) vagy [setItemId](https://reference.aspose.com/slides/hu/python-java/aspose.slides/customxmlpart/#setItemId) használatával történő frissítés megváltoztatja az alaprész egyedi XML részét, ezért a változás mindenhol érvényes, ahol a rész hivatkozva van.
- A [getItemId](https://reference.aspose.com/slides/hu/python-java/aspose.slides/customxmlpart/#getItemId) használható ugyanannak az egyedi XML résznek az azonosítására objektumszintű gyűjtemények auditálása közben.
- Egy rész eltávolítása egy adott [getCustomXmlParts](https://reference.aspose.com/slides/hu/python-java/aspose.slides/customdata/#getCustomXmlParts) gyűjteményből azt a gyűjteménytől eltávolítja. Használja a [CustomXmlPart.remove](https://reference.aspose.com/slides/hu/python-java/aspose.slides/customxmlpart/#remove) metódust, ha magát a részt kell eltávolítani a prezentációból.
- Megosztott rész törlése vagy cseréje előtt vizsgálja meg az objektumszintű gyűjteményeket, hogy megállapítsa, más diák vagy alakzatok még hivatkoznak‑e rá.

Az [add](https://reference.aspose.com/slides/hu/python-java/aspose.slides/customxmlpartcollection/#add) túlterhelései új egyedi XML részt hoznak létre XML tartalomból; egy meglévő [CustomXmlPart](https://reference.aspose.com/slides/hu/python-java/aspose.slides/customxmlpart/)‑ot nem fogadnak el. Ezért a megosztott kapcsolatok leggyakrabban olyan prezentációk betöltésekor merülnek fel, amelyek már tartalmazzák őket.

A következő példa auditálja a prezentáció‑, dia‑ és alakzat‑szintű gyűjteményeket `ItemId` alapján, és jelentést készít a több helyről hivatkozott részekről:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    references_by_item_id = {}

    def register_custom_xml_parts(owner_name, custom_xml_parts):
        for i in range(custom_xml_parts.size()):
            custom_xml_part = custom_xml_parts.get_Item(i)
            item_id = str(custom_xml_part.getItemId())
            references_by_item_id.setdefault(item_id, []).append(owner_name)

    register_custom_xml_parts("Presentation", presentation.getCustomData().getCustomXmlParts())

    for slide_index in range(presentation.getSlides().size()):
        slide = presentation.getSlides().get_Item(slide_index)
        register_custom_xml_parts(f"Slide {slide_index + 1}", slide.getCustomData().getCustomXmlParts())

        for shape_index in range(slide.getShapes().size()):
            shape = slide.getShapes().get_Item(shape_index)
            register_custom_xml_parts(f"Slide {slide_index + 1}, shape {shape_index}", shape.getCustomData().getCustomXmlParts())

    for item_id, owner_names in references_by_item_id.items():
        if len(owner_names) > 1:
            print("Shared custom XML part:", item_id)
            for owner_name in owner_names:
                print("  Referenced by:", owner_name)
finally:
    presentation.dispose()
```

Ez a fajta auditálás hasznos a külső rendszerek által létrehozott prezentációk egyedi XML adatainak módosítása vagy törlése előtt, mivel ugyanaz a metaadat rész több kapcsolatban is részt vehet.

## **Címkék értékeinek lekérése**

A diákban a címke a [DocumentProperties.getKeywords](https://reference.aspose.com/slides/hu/python-java/aspose.slides/documentproperties/#getKeywords) metódusnak felel meg. Ez a példakód bemutatja, hogyan lehet egy címke értékét lekérni az Aspose.Slides for Python via Java használatával a [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) esetén:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    keywords = presentation.getDocumentProperties().getKeywords()
finally:
    presentation.dispose()
```

## **Címkék hozzáadása a prezentációkhoz**

Az Aspose.Slides lehetővé teszi címkék hozzáadását a prezentációkhoz. Egy címke általában két elemből áll:

- egy egyedi tulajdonság neve, például `MyTag`;
- az egyedi tulajdonság értéke, például `My Tag Value`.

Ha a prezentációkat egy adott szabály vagy tulajdonság alapján szeretné osztályozni, hozzáadhat címkéket ebben a célban. Például ha az észak‑amerikai országokból származó prezentációkat szeretné kategorizálni, létrehozhat egy észak‑amerikai címkét, és hozzárendelheti a megfelelő országot értékként.

Ez a példakód bemutatja, hogyan lehet egy címkét hozzáadni egy [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) objektumhoz az Aspose.Slides for Python via Java használatával:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    tags = presentation.getCustomData().getTags()
    tags.set_Item("MyTag", "My Tag Value")
finally:
    presentation.dispose()
```

A címkéket egy [Slide](https://reference.aspose.com/slides/hu/python-java/aspose.slides/slide/) esetén is be lehet állítani:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    slide.getCustomData().getTags().set_Item("tag", "value")
finally:
    presentation.dispose()
```

Vagy egy egyedi [Shape](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shape/) esetén:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 50)
    shape.getTextFrame().setText("My text")
    shape.getCustomData().getTags().set_Item("tag", "value")
finally:
    presentation.dispose()
```

### **Korlátozások**

A [CustomData.getTags](https://reference.aspose.com/slides/hu/python-java/aspose.slides/customdata/#getTags) gyűjteményen keresztül hozzáadott címkék csak a PowerPoint fájlban tárolódnak. Ezek **nem** kerülnek át a PDF címke struktúrába, amikor a prezentáció PDF‑be exportálódik. Ennek következtében egy címkeként hozzárendelt egyedi azonosító nem kérhető le a címkézett PDF‑ből.

**Megoldás**: Egy egyedi azonosítót tárolhat az objektum **Alt Text**‑ében (például a [Shape.setAlternativeText](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shape/#setAlternativeText) metódussal, az `"MyId"` értékkel). PDF‑be exportálás után az Alt Text megjelenhet a PDF címke struktúrájában.

## **GYIK**

**Eltávolíthatok minden címkét egy prezentációból, diából vagy alakzatból egy műveletben?**

Igen. A [tag collection](https://reference.aspose.com/slides/hu/python-java/aspose.slides/tagcollection/) támogatja a [clear](https://reference.aspose.com/slides/hu/python-java/aspose.slides/tagcollection/#clear) műveletet, amely egy lépésben törli az összes kulcs‑érték párost.

**Hogyan törölhetek egyetlen címkét a nevével anélkül, hogy végig iterálnék az egész gyűjteményen?**

Használja a [remove](https://reference.aspose.com/slides/hu/python-java/aspose.slides/tagcollection/#remove) metódust a [tag collection](https://reference.aspose.com/slides/hu/python-java/aspose.slides/tagcollection/)‑on, hogy a kulcs alapján törölje a címkét.

**Hogyan kérhetem le a címkenevek teljes listáját elemzés vagy szűrés céljából?**

Használja a [getNamesOfTags](https://reference.aspose.com/slides/hu/python-java/aspose.slides/tagcollection/#getNamesOfTags) metódust a [tag collection](https://reference.aspose.com/slides/hu/python-java/aspose.slides/tagcollection/)‑on; ez egy tömböt ad vissza az összes címkenévvel.

**Hogyan találhatom meg az összes egyedi XML részt, függetlenül attól, hogy hol vannak tárolva?**

Használja a [Presentation.getAllCustomXmlParts](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/#getAllCustomXmlParts) metódust az összes egyedi XML part lekéréséhez a prezentációban.

**Használjam inkább a [getXmlAsString]/[setXmlAsString] vagy a [getXmlData]/[setXmlData] metódusokat egy egyedi XML rész frissítéséhez?**

Használja a [getXmlAsString](https://reference.aspose.com/slides/hu/python-java/aspose.slides/customxmlpart/#getXmlAsString) és [setXmlAsString](https://reference.aspose.com/slides/hu/python-java/aspose.slides/customxmlpart/#setXmlAsString) metódusokat, ha az alkalmazás UTF‑8 XML szöveggel dolgozik. Használja a [getXmlData](https://reference.aspose.com/slides/hu/python-java/aspose.slides/customxmlpart/#getXmlData) és [setXmlData](https://reference.aspose.com/slides/hu/python-java/aspose.slides/customxmlpart/#setXmlData) metódusokat, ha az XML már bájt tömbként elérhető, vagy a bináris feldolgozás kényelmesebb. Mindkét ábrázolás ugyanazon egyedi XML rész XML tartalmára mutat.
---
title: Címkék és egyéni adatok kezelése bemutatókban C++ használatával
linktitle: Címkék és egyéni adatok
type: docs
weight: 300
url: /hu/cpp/managing-tags-and-custom-data/
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
- C++
- Aspose.Slides
description: "Ismerje meg, hogyan kezelhet címkéket és egyéni XML adatokat PowerPoint bemutatókban az Aspose.Slides for C++ segítségével, beleértve a hozzáadást, olvasást, frissítést, auditálást és az egyéni XML részek eltávolítását."
---
## **Áttekintés**

Ez a cikk elmagyarázza, hogy az Aspose.Slides hogyan működik címkékkel és egyéni adatokkal a PowerPoint bemutatókban. A bemutató‑specifikus adatokat címkék vagy egyéni XML részek formájában lehet tárolni. A címkék egyszerű kulcs‑érték karakterlánc párok, míg az egyéni XML részek strukturált metaadatokat és alkalmazás‑specifikus XML terheket tárolhatnak.

Az Aspose.Slides API‑kat biztosít egyéni XML részek hozzáadásához, olvasásához, frissítéséhez, auditálásához és eltávolításához a bemutató, dia és alakzat szintjén. Az egyéni XML részek hasznosak olyan integrációkhoz, amelyek információkat tárolnak, például dokumentum‑kezelési azonosítókat, munkafolyamat‑állapotot, megfelelőségi metaadatokat, sablon‑kötési adatokat vagy más strukturált alkalmazásadatot a bemutatóban.

## **Adattárolás a bemutató fájlokban**

A PPTX fájlok – a `.pptx` kiterjesztésű fájlok – a PresentationML formátumban tárolódnak, amely az Office Open XML specifikáció része. Az Office Open XML meghatározza a csomagstruktúrát és a kapcsolatrendszert, amely a bemutató tartalmát és kapcsolódó adatokat tárolja.

Egy bemutató több részből áll, amelyek kapcsolatokkal vannak összekapcsolva. Például egy dia rész tartalmaz egyetlen dia tartalmát, és explicit kapcsolatokat tartalmazhat más részekkel, az ISO/IEC 29500 által definiálva.

Az egyéni adatokat tárolhatja címkék ([ITagCollection](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itagcollection/)) vagy egyéni XML részek ([ICustomXmlPartCollection](https://reference.aspose.com/slides/hu/cpp/aspose.slides/icustomxmlpartcollection/)) formájában. Mindkettő elérhető a [`ICustomData`](https://reference.aspose.com/slides/hu/cpp/aspose.slides/icustomdata/) interfészen keresztül.

{{% alert color="primary" %}}
A címkék egyszerű karakterlánc kulcs‑érték párokat tárolnak. Az egyéni XML részek strukturált XML adatot tárolnak, és egy bemutatóhoz, diához vagy alakzathoz kapcsolhatók.
{{% /alert %}}

## **Munkavégzés egyéni XML részekkel**

A [`ICustomData::get_CustomXmlParts`](https://reference.aspose.com/slides/hu/cpp/aspose.slides/icustomdata/get_customxmlparts/) metódus visszaadja az adott bemutató objektumhoz kapcsolódó egyéni XML részek gyűjteményét. Például:

- `presentation->get_CustomData()->get_CustomXmlParts()` a bemutatóhoz kapcsolódó egyéni XML részeket tartalmazza.
- `slide->get_CustomData()->get_CustomXmlParts()` egy adott diához kapcsolódó egyéni XML részeket tartalmazza.
- `shape->get_CustomData()->get_CustomXmlParts()` egy adott alakzathoz kapcsolódó egyéni XML részeket tartalmazza.

Használja a [`Presentation::get_AllCustomXmlParts`](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/get_allcustomxmlparts/) metódust, ha a bemutató összes egyéni XML részét szeretné megvizsgálni, függetlenül attól, hogy hol vannak kapcsolva.

### **Egyéni XML rész hozzáadása a bemutatóhoz**

Használja a [`ICustomXmlPartCollection::Add`](https://reference.aspose.com/slides/hu/cpp/aspose.slides/icustomxmlpartcollection/add/) metódust XML adat hozzáadásához egy egyéni XML rész gyűjteményhez. Az XML-nek érvényesnek és nem üresnek kell lennie.

A következő példa strukturált metaadatot ad a bemutató‑szintű egyéni adatok gyűjteményéhez:

```cpp
#include <DOM/ICustomData.h>
#include <DOM/ICustomXmlPart.h>
#include <DOM/ICustomXmlPartCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/guid.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

System::String customXmlContent =
    u"<?xml version=\"1.0\" encoding=\"UTF-8\"?>"
    u"<metadata xmlns=\"urn:example:metadata\">"
        u"<documentId>DOC-1001</documentId>"
        u"<workflowState>Draft</workflowState>"
    u"</metadata>";

auto presentation = System::MakeObject<Presentation>();
auto customXmlPart = presentation->get_CustomData()->get_CustomXmlParts()->Add(customXmlContent);

// Add automatikusan hozzárendel egy azonosítót. Egy konkrét GUID-ot csak akkor állítson be, ha szükséges.
customXmlPart->set_ItemId(System::Guid::NewGuid());

presentation->Save(u"presentation_with_custom_xml.pptx", SaveFormat::Pptx);
```

Az `Add` metódus elfogadhat XML‑t bájt tömbként vagy stream‑ként is, ami hasznos, ha az XML‑tartalom már bináris formában elérhető.

### **Egyéni XML rész hozzáadása diához vagy alakzathoz**

Az egyéni XML adatot egy adott diához vagy alakzathoz is lehet kapcsolni a teljes bemutató helyett. Ez akkor hasznos, ha a metaadat csak egy objektumra vonatkozik, például sablon‑kulcsra, külső rekord‑azonosítóra vagy kötési információra.

A következő példa egy egyéni XML részt ad egy diához és egy másikat egy alakzathoz:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/ICustomData.h>
#include <DOM/ICustomXmlPartCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slides()->idx_get(0);

slide->get_CustomData()->get_CustomXmlParts()->Add(
    u"<slideMetadata xmlns=\"urn:example:slides\">"
        u"<templateKey>TitleSlide</templateKey>"
    u"</slideMetadata>");

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 250.0f, 80.0f);

shape->get_TextFrame()->set_Text(u"Customer data");
shape->get_CustomData()->get_CustomXmlParts()->Add(
    u"<shapeMetadata xmlns=\"urn:example:shapes\">"
        u"<recordId>CRM-4281</recordId>"
    u"</shapeMetadata>");

presentation->Save(u"object_custom_xml.pptx", SaveFormat::Pptx);
```

Az a szint, amelyen a rész hozzá van adva, meghatározza, hogy melyik objektum `get_CustomData()->get_CustomXmlParts()` gyűjteménye tartalmazza a részre mutató kapcsolatot. A bemutató‑szintű adat a dokumentum‑szintű metaadatokhoz, a dia‑szintű adat egy adott dia információihoz, a alakzat‑szintű adat pedig egy egyedi alakzathoz kapcsolódó metaadatokhoz megfelelő.

### **Az összes egyéni XML rész listázása és auditálása**

Használja a [`Presentation::get_AllCustomXmlParts`](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/get_allcustomxmlparts/) metódust, hogy lekérje a bemutató összes egyéni XML részét. Minden [`ICustomXmlPart`](https://reference.aspose.com/slides/hu/cpp/aspose.slides/icustomxmlpart/) megmutatja azonosítóját, XML‑tartalmát és a kapcsolódó névtér‑sémákat.

A következő példa felsorolja az összes egyéni XML részt és azok névtér‑sémáit:

```cpp
#include <DOM/ICustomXmlPart.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

for (auto customXmlPart : presentation->get_AllCustomXmlParts())
{
    System::Console::WriteLine(System::String(u"ItemId: ") + customXmlPart->get_ItemId().ToString());
    System::Console::WriteLine(u"XML:");
    System::Console::WriteLine(customXmlPart->get_XmlAsString());

    for (auto namespaceSchema : customXmlPart->get_NamespaceSchemas())
    {
        System::Console::WriteLine(System::String(u"Namespace schema: ") + namespaceSchema);
    }

    System::Console::WriteLine();
}
```

[`ICustomXmlPart::get_NamespaceSchemas`](https://reference.aspose.com/slides/hu/cpp/aspose.slides/icustomxmlpart/get_namespaceschemas/) visszaadja az egyéni XML részhez tartozó XML‑sémákat. Ez az információ hasznos lehet a külső rendszerek által előállított XML‑t tartalmazó bemutatók auditálásakor.

### **XML tartalom és ItemId olvasása és frissítése**

Használja a [`ICustomXmlPart::get_XmlAsString`](https://reference.aspose.com/slides/hu/cpp/aspose.slides/icustomxmlpart/get_xmlasstring/) és `set_XmlAsString` metódusokat XML UTF‑8 szövegként történő kezeléséhez, vagy a [`ICustomXmlPart::get_XmlData`](https://reference.aspose.com/slides/hu/cpp/aspose.slides/icustomxmlpart/get_xmldata/) és `set_XmlData` metódusokat a nyers XML bájtok kezeléséhez. Mindkét reprezentáció olvasható és frissíthető.

A [`ICustomXmlPart::get_ItemId`](https://reference.aspose.com/slides/hu/cpp/aspose.slides/icustomxmlpart/get_itemid/) metódus visszaadja a GUID‑ot, amely az egyéni XML részt az Office Open XML dokumentumban azonosítja. Az azonosítót a `set_ItemId` segítségével is meg lehet változtatni, ha egy integrációnak új azonosító szükséges.

A következő példa frissíti az XML tartalmat és az azonosítót:

```cpp
#include <DOM/ICustomXmlPart.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/guid.h>
#include <system/text/encoding.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto customXmlPart = presentation->get_AllCustomXmlParts()->idx_get(0);

// Olvassa a jelenlegi XML‑t szövegként.
auto currentXmlContent = customXmlPart->get_XmlAsString();
System::Console::WriteLine(currentXmlContent);

// Frissítse az XML‑t UTF‑8 karakterláncként.
customXmlPart->set_XmlAsString(
    u"<metadata xmlns=\"urn:example:metadata\">"
        u"<documentId>DOC-1001</documentId>"
        u"<workflowState>Approved</workflowState>"
    u"</metadata>");

// Az XmlData ugyanazt az XML tartalmat nyers bájtokként biztosítja.
auto customXmlData = customXmlPart->get_XmlData();
System::Console::WriteLine(System::Text::Encoding::get_UTF8()->GetString(customXmlData));

// Cserélje le az azonosítót, ha az integráció megköveteli.
customXmlPart->set_ItemId(System::Guid::NewGuid());

presentation->Save(u"updated_custom_xml.pptx", SaveFormat::Pptx);
```

XML‑t `set_XmlAsString` vagy `set_XmlData` használatával csak érvényes, nem üres XML‑t adjon meg. Válassza az egyik reprezentációt a másik helyett attól függően, hogy az alkalmazás főként szöveggel vagy bájt adatokkal dolgozik.

### **Egyéni XML rész eltávolítása**

Az Aspose.Slides többféle módot kínál egyéni XML adatok eltávolítására:

- [`ICustomXmlPart::Remove`](https://reference.aspose.com/slides/hu/cpp/aspose.slides/icustomxmlpart/remove/) eltávolítja az egyéni XML részt a bemutatóból.
- [`ICustomXmlPartCollection::Remove`](https://reference.aspose.com/slides/hu/cpp/aspose.slides/icustomxmlpartcollection/remove/) eltávolít egy konkrét részt egy egyéni XML rész gyűjteményből.
- [`ICustomXmlPartCollection::RemoveAt`](https://reference.aspose.com/slides/hu/cpp/aspose.slides/icustomxmlpartcollection/removeat/) eltávolítja a részt a megadott gyűjtemény‑indexnél.
- [`ICustomXmlPartCollection::Clear`](https://reference.aspose.com/slides/hu/cpp/aspose.slides/icustomxmlpartcollection/clear/) eltávolítja az összes részt egy adott gyűjteményből.

A következő példa egy bemutató‑szintű egyéni XML részt távolít el hivatkozással:

```cpp
#include <DOM/ICustomData.h>
#include <DOM/ICustomXmlPartCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto customXmlParts = presentation->get_CustomData()->get_CustomXmlParts();

if (customXmlParts->get_Count() > 0)
{
    auto customXmlPart = customXmlParts->idx_get(0);
    customXmlParts->Remove(customXmlPart);
}

presentation->Save(u"custom_xml_removed.pptx", SaveFormat::Pptx);
```

Ha már rendelkezik egy `ICustomXmlPart` példánnyal, és azt szeretné eltávolítani a bemutatóból a konkrét gyűjtemény helyett, hívja a `customXmlPart->Remove()` metódust.

Eltávolíthat egy elemet index alapján is:

```cpp
presentation->get_CustomData()->get_CustomXmlParts()->RemoveAt(0);
```

### **Az összes egyéni XML rész törlése egy gyűjteményből**

Használja a `Clear` metódust, amikor egy adott bemutató objektumhoz kapcsolódó összes egyéni XML részt el kell távolítani.

```cpp
#include <DOM/ICustomData.h>
#include <DOM/ICustomXmlPartCollection.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
presentation->get_Slides()->idx_get(0)->get_CustomData()->get_CustomXmlParts()->Clear();

presentation->Save(u"slide_custom_xml_cleared.pptx", SaveFormat::Pptx);
```

A `Clear` csak a kiválasztott gyűjteményre hat. Például egy dia gyűjteményének törlése nem érinti a bemutató‑szintű vagy alakzat‑szintű gyűjteményeket.

Az összes egyéni XML rész eltávolításához a bemutatóban iteráljon a `get_AllCustomXmlParts()` eredményén, és távolítson el minden részt:

```cpp
#include <DOM/ICustomXmlPart.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

for (auto customXmlPart : presentation->get_AllCustomXmlParts())
{
    customXmlPart->Remove();
}

presentation->Save(u"all_custom_xml_removed.pptx", SaveFormat::Pptx);
```

### **Kapcsolt vagy megosztott egyéni XML részek kezelése**

Egy Office Open XML bemutatóban ugyanaz az egyéni XML rész több bemutatóobjektusból is hivatkozható. Például egy meglévő fájl tartalmazhat kapcsolódásokat több diára vagy alakzatra ugyanarra az alaprészre.

Egy megosztott részt úgy kell kezelni, mint egy adatobjektumot több hivatkozással:

- Frissítése `set_XmlAsString`, `set_XmlData` vagy `set_ItemId` használatával az alaprész módosul, így a változás minden hivatkozásnál megjelenik.
- `get_ItemId()` használható ugyanannak az egyéni XML résznek azonosítására objektumszintű gyűjtemények auditálása közben.
- Egy rész eltávolítása egy konkrét `get_CustomXmlParts()` gyűjteményből csak abból a gyűjteményből távolítja el. Használja az `ICustomXmlPart::Remove()` metódust, ha magát a részt szeretné eltávolítani a bemutatóból.
- Megosztott rész törlése vagy helyettesítése előtt ellenőrizze az objektumszintű gyűjteményeket, hogy más diák vagy alakzatok még hivatkoznak‑e rá.

Az `Add` túlterhelések új egyéni XML részt hoznak létre XML tartalommal; nem fogadnak el meglévő `ICustomXmlPart` példányt. Ezért a megosztott kapcsolatok leggyakrabban akkor merülnek fel, amikor már meglévő részeket tartalmazó bemutatókat tölt be.

A következő példa auditálja a bemutató‑, dia‑ és alakzat‑szintű gyűjteményeket `ItemId` alapján, és jelentést készít a több helyen hivatkozott részekről:

```cpp
#include <algorithm>
#include <vector>
#include <DOM/ICustomData.h>
#include <DOM/ICustomXmlPart.h>
#include <DOM/ICustomXmlPartCollection.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/guid.h>
#include <system/string.h>

using namespace Aspose::Slides;

struct CustomXmlReferenceEntry
{
    System::Guid itemId;
    std::vector<System::String> owners;
};

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
std::vector<CustomXmlReferenceEntry> referencesByItemId;

auto registerCustomXmlParts = [&referencesByItemId](
    const System::String& ownerName,
    const System::SharedPtr<ICustomXmlPartCollection>& customXmlParts)
{
    for (int32_t partIndex = 0; partIndex < customXmlParts->get_Count(); ++partIndex)
    {
        auto customXmlPart = customXmlParts->idx_get(partIndex);
        auto itemId = customXmlPart->get_ItemId();

        auto entry = std::find_if(
            referencesByItemId.begin(),
            referencesByItemId.end(),
            [&itemId](const CustomXmlReferenceEntry& referenceEntry)
            {
                return referenceEntry.itemId == itemId;
            });

        if (entry == referencesByItemId.end())
        {
            referencesByItemId.push_back({ itemId, { ownerName } });
        }
        else
        {
            entry->owners.push_back(ownerName);
        }
    }
};

registerCustomXmlParts(u"Presentation", presentation->get_CustomData()->get_CustomXmlParts());

for (int32_t slideIndex = 0; slideIndex < presentation->get_Slides()->get_Count(); ++slideIndex)
{
    auto slide = presentation->get_Slides()->idx_get(slideIndex);
    registerCustomXmlParts(
        System::String::Format(u"Slide {0}", slideIndex + 1),
        slide->get_CustomData()->get_CustomXmlParts());

    for (int32_t shapeIndex = 0; shapeIndex < slide->get_Shapes()->get_Count(); ++shapeIndex)
    {
        auto shape = slide->get_Shapes()->idx_get(shapeIndex);
        registerCustomXmlParts(
            System::String::Format(u"Slide {0}, shape {1}", slideIndex + 1, shapeIndex),
            shape->get_CustomData()->get_CustomXmlParts());
    }
}

for (const auto& referenceEntry : referencesByItemId)
{
    if (referenceEntry.owners.size() > 1)
    {
        System::Console::WriteLine(
            System::String(u"Shared custom XML part: ") + referenceEntry.itemId.ToString());

        for (const auto& ownerName : referenceEntry.owners)
        {
            System::Console::WriteLine(System::String(u"  Referenced by: ") + ownerName);
        }
    }
}
```

Ez a fajta auditálás hasznos, mielőtt módosítana vagy törölne egyéni XML adatot külső rendszerek által létrehozott bemutatókban, mivel ugyanaz a metaadat‑rész több kapcsolatra is vonatkozhat.

## **Címkék értékeinek lekérdezése**

A diákban egy címke a `IDocumentProperties::get_Keywords` tulajdonsággal egyezik. Ez a minta kód bemutatja, hogyan lehet egy címke értékét lekérni az Aspose.Slides for C++ segítségével egy [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) esetén:

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto keywords = presentation->get_DocumentProperties()->get_Keywords();
```

## **Címkék hozzáadása a bemutatókhoz**

Az Aspose.Slides lehetővé teszi címkék hozzáadását a bemutatókhoz. Egy címke általában két elemből áll:

- egy egyéni tulajdonság neve, például `MyTag`;
- az egyéni tulajdonság értéke, például `My Tag Value`.

Ha egy bizonyos szabály vagy tulajdonság alapján szeretne bemutatókat osztályozni, hozzáadhat ehhez címkéket. Például, ha az észak‑amerikai országokból származó bemutatókat szeretné kategorizálni, létrehozhat egy „NorthAmerican” címkét, és az adott országot adhatja meg értékként.

Ez a minta kód megmutatja, hogyan lehet egy címkét hozzáadni egy [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) objektumhoz az Aspose.Slides for C++ használatával:

```cpp
#include <DOM/ICustomData.h>
#include <DOM/ITagCollection.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto tags = presentation->get_CustomData()->get_Tags();
tags->idx_set(u"MyTag", u"My Tag Value");
```

Címkék beállíthatók egy [Slide](https://reference.aspose.com/slides/hu/cpp/aspose.slides/slide/) esetén is:

```cpp
#include <DOM/ICustomData.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITagCollection.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slides()->idx_get(0);
slide->get_CustomData()->get_Tags()->idx_set(u"tag", u"value");
```

Vagy egyetlen [Shape](https://reference.aspose.com/slides/hu/cpp/aspose.slides/shape/) esetén:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/ICustomData.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITagCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slides()->idx_get(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 50.0f);
shape->get_TextFrame()->set_Text(u"My text");
shape->get_CustomData()->get_Tags()->idx_set(u"tag", u"value");
```

### **Korlátozások**

A `get_CustomData()->get_Tags()` gyűjteményen keresztül hozzáadott címkék csak a PowerPoint fájlban tárolódnak. **Nem** kerülnek át a PDF címke‑szerkezetbe, amikor a bemutatót PDF‑be exportálják. Ennek következtében egy címkeként hozzárendelt egyéni azonosítót nem lehet visszanyerni a címkézett PDF‑ből.

**Megoldás**: Tárolhat egy egyéni azonosítót az objektum **Alt Text**‑ében (például `shape->set_AlternativeText(u"MyId")`). PDF‑export után az Alt Text megjelenhet a PDF címke‑szerkezetben.

## **GYIK**

**Eltávolíthatom-e az összes címkét egy bemutatóból, diá­ból vagy alakzatból egyetlen művelettel?**

Igen. A [tag collection](https://reference.aspose.com/slides/hu/cpp/aspose.slides/tagcollection/) támogatja a [Clear](https://reference.aspose.com/slides/hu/cpp/aspose.slides/tagcollection/clear/) műveletet, amely egyszerre törli az összes kulcs‑érték párot.

**Hogyan töröthetek egyetlen címkét a neve alapján anélkül, hogy végig kellene iterálni a teljes gyűjteményt?**

Használja a [Remove(name)](https://reference.aspose.com/slides/hu/cpp/aspose.slides/tagcollection/remove/) metódust a [TagCollection](https://reference.aspose.com/slides/hu/cpp/aspose.slides/tagcollection/) objektumon a címke kulcs szerinti törléséhez.

**Hogyan kaphatom meg a címkék teljes listáját elemzés vagy szűrés céljából?**

Használja a [GetNamesOfTags](https://reference.aspose.com/slides/hu/cpp/aspose.slides/tagcollection/getnamesoftags/) metódust a [tag collection](https://reference.aspose.com/slides/hu/cpp/aspose.slides/tagcollection/)‑on; ez egy tömböt ad vissza az összes címkenévvel.

**Hogyan találhatom meg az összes egyéni XML részt, függetlenül attól, hogy hol vannak tárolva?**

Használja a [`Presentation::get_AllCustomXmlParts`](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/get_allcustomxmlparts/) metódust az összes egyéni XML rész lekéréséhez a bemutatóban.

**Melyik módszert használjam a `get_XmlAsString`/`set_XmlAsString` vagy a `get_XmlData`/`set_XmlData` között egy egyéni XML rész frissítésekor?**

Használja a `get_XmlAsString` és `set_XmlAsString` metódusokat, ha az alkalmazás UTF‑8 XML szöveggel dolgozik. Használja a `get_XmlData` és `set_XmlData` metódusokat, ha az XML már bájt tömbként áll rendelkezésre, vagy a bináris feldolgozás kényelmesebb. Mindkét reprezentáció ugyanannak az egyéni XML résznek a tartalmára hivatkozik.
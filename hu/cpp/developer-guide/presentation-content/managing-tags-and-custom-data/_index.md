---
title: Címkék és egyéni adatok kezelése prezentációkban C++-bal
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
- pár értékek
- PowerPoint
- prezentáció
- C++
- Aspose.Slides
description: "Ismerje meg, hogyan kezelheti a címkéket és az egyéni XML adatokat PowerPoint prezentációkban az Aspose.Slides for C++ segítségével, beleértve a címkék hozzáadását, olvasását, frissítését, auditálását és az egyéni XML részek eltávolítását."
---
## **Áttekintés**

Ez a cikk elmagyarázza, hogy az Aspose.Slides hogyan működik címkékkel és egyéni adatával a PowerPoint‑prezentációkban. A prezentációra vonatkozó adatokat címkék vagy egyéni XML részek formájában lehet tárolni. A címkék egyszerű kulcs‑érték karakterlánc párok, míg az egyéni XML részek strukturált metaadatokat és alkalmazásspecifikus XML terheket tárolhatnak.

Az Aspose.Slides API‑kat biztosít egyéni XML részek hozzáadásához, olvasásához, frissítéséhez, auditálásához és eltávolításához a prezentáció, dia és alakzat szintjén. Az egyéni XML részek hasznosak olyan integrációkhoz, amelyek információkat tárolnak, például dokumentumkezelési azonosítókat, munkafolyamat‑állapotot, megfelelőségi metaadatokat, sablon‑kötési adatokat vagy egyéb strukturált alkalmazásadatokat a prezentációban.

## **Adattárolás a prezentációs fájlokban**

A PPTX fájlok—az `.pptx` kiterjesztésű fájlok—PresentationML formátumban tárolódnak, amely az Office Open XML specifikáció része. Az Office Open XML meghatározza a csomag szerkezetét és a kapcsolatrendszert, amely a prezentáció tartalmát és a kapcsolódó adatokat tárolja.

Egy prezentáció több, kapcsolatban álló részből áll. Például egy diárrész tartalmazza egyetlen dia tartalmát, és kifejezett kapcsolatokat is tartalmazhat más részekkel, ahogyan azt az ISO/IEC 29500 definiálja.

Az egyéni adat tárolható címkékként ([ITagCollection](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itagcollection/)) vagy egyéni XML részként ([ICustomXmlPartCollection](https://reference.aspose.com/slides/hu/cpp/aspose.slides/icustomxmlpartcollection/)). Mindkettő az [`ICustomData`](https://reference.aspose.com/slides/hu/cpp/aspose.slides/icustomdata/) interfészen keresztül érhető el.
{{% alert color="info" %}}
Tag‑ek egyszerű karakterlánc kulcs‑érték párokat tárolnak. Az egyéni XML részek strukturált XML adatot tárolnak, és egy prezentációhoz, diához vagy alakzathoz kapcsolhatók.
{{% /alert %}}
## **Munkavégzés egyéni XML részekkel**

A [`ICustomData::get_CustomXmlParts`](https://reference.aspose.com/slides/hu/cpp/aspose.slides/icustomdata/get_customxmlparts/) metódus visszaadja az adott prezentációs objektumhoz társított egyéni XML részek gyűjteményét. Például:

- `presentation->get_CustomData()->get_CustomXmlParts()` a prezentációhoz közvetlenül kapcsolt egyéni XML részeket tartalmazza.
- `slide->get_CustomData()->get_CustomXmlParts()` egy adott diához kapcsolt egyéni XML részeket tartalmazza.
- `shape->get_CustomData()->get_CustomXmlParts()` egy adott alakzathoz kapcsolt egyéni XML részeket tartalmazza.

Használd a [`Presentation::get_AllCustomXmlParts`](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/get_allcustomxmlparts/) metódust, ha a prezentáció összes egyéni XML részét szeretnéd megvizsgálni, függetlenül attól, hogy hol vannak kapcsolva.
### **Egyéni XML rész hozzáadása a prezentációhoz**

Használd a [`ICustomXmlPartCollection::Add`](https://reference.aspose.com/slides/hu/cpp/aspose.slides/icustomxmlpartcollection/add/) metódust XML adat hozzáadásához egy egyéni XML részgyűjteményhez. Az XML‑nek érvényesnek és nem üresnek kell lennie.

A következő példa strukturált metaadatokat ad hozzá a prezentáció szintű egyéni adatgyűjteményhez:
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

// Add automatikusan hozzárendel egy azonosítót. Csak akkor állítson be konkrét GUID-ot, ha szükséges.
customXmlPart->set_ItemId(System::Guid::NewGuid());

presentation->Save(u"presentation_with_custom_xml.pptx", SaveFormat::Pptx);
```

Az `Add` metódus XML‑t is elfogadhat bájt‑tömbként vagy adatfolyamként, ami hasznos, ha az XML‑tartalom már bináris formában elérhető.
### **Egyéni XML rész hozzáadása diára vagy alakzatra**

Az egyéni XML adatot egy adott diához vagy alakzathoz lehet társítani a teljes prezentáció helyett. Ez akkor hasznos, ha a metaadat csak egy objektumot ír le, például egy sablonkulcsot, külső rekordazonosítót vagy kötési információt.

A következő példa egy egyéni XML részt ad hozzá egy diához, és egy másikat egy alakzathoz:
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

Az a szint, amelyen a rész hozzá van adva, meghatározza, melyik objektum `get_CustomData()->get_CustomXmlParts()` gyűjteménye tartalmazza a részre mutató kapcsolatot. A prezentációszintű adat a dokumentum egészére kiterjedő metaadatokhoz megfelelő, a diásszintű adat egy adott diához tartozó információkhoz, a alakzatszintű adat pedig egy adott alakzathoz kapcsolódó metaadatokhoz.
### **Az összes egyéni XML rész listázása és auditálása**

Használd a [`Presentation::get_AllCustomXmlParts`](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/get_allcustomxmlparts/) metódust az összes egyéni XML rész lekéréséhez a prezentációból. Minden [`ICustomXmlPart`](https://reference.aspose.com/slides/hu/cpp/aspose.slides/icustomxmlpart/) megjeleníti az azonosítóját, XML‑tartalmát és a kapcsolódó névtér‑sémákat.

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

A [`ICustomXmlPart::get_NamespaceSchemas`](https://reference.aspose.com/slides/hu/cpp/aspose.slides/icustomxmlpart/get_namespaceschemas/) visszaadja az egyéni XML részhez kapcsolt XML sémákat. Ez az információ hasznos lehet olyan prezentációk auditálásakor, amelyek külső rendszerek által előállított XML‑t tartalmaznak.
### **XML tartalom és ItemId olvasása és frissítése**

Használd a [`ICustomXmlPart::get_XmlAsString`](https://reference.aspose.com/slides/hu/cpp/aspose.slides/icustomxmlpart/get_xmlasstring/) és a `set_XmlAsString` metódusokat az XML UTF‑8 karakterláncként történő kezeléséhez, vagy a [`ICustomXmlPart::get_XmlData`](https://reference.aspose.com/slides/hu/cpp/aspose.slides/icustomxmlpart/get_xmldata/) és a `set_XmlData` metódusokat a nyers XML bájtok kezeléséhez. Mindkét reprezentáció olvasható és frissíthető.

A [`ICustomXmlPart::get_ItemId`](https://reference.aspose.com/slides/hu/cpp/aspose.slides/icustomxmlpart/get_itemid/) metódus visszaadja azt a GUID‑et, amely az egyéni XML részt az Office Open XML dokumentumban azonosítja. Az azonosítót a `set_ItemId` metódussal is meg lehet változtatni, ha egy integrációnak új azonosító szükséges.

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

// Olvassa be a jelenlegi XML-t szövegként.
auto currentXmlContent = customXmlPart->get_XmlAsString();
System::Console::WriteLine(currentXmlContent);

// Frissítse az XML-t UTF-8 karakterláncként.
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

XML‑t `set_XmlAsString` vagy `set_XmlData` használatával való hozzárendeléskor érvényes, nem üres XML‑t adj meg. Az egyik vagy a másik reprezentációt használd attól függően, hogy az alkalmazás főként karakterláncokkal vagy bájt adatokkal dolgozik.
### **Egyéni XML rész eltávolítása**

Az Aspose.Slides több módot biztosít az egyéni XML adatok eltávolítására:

- `ICustomXmlPart::Remove` eltávolítja az egyéni XML részt a prezentációból.
- `ICustomXmlPartCollection::Remove` egy adott részt távolít el egy egyéni XML részgyűjteményből.
- `ICustomXmlPartCollection::RemoveAt` a megadott indexű elemet távolítja el a gyűjmtényből.
- `ICustomXmlPartCollection::Clear` az adott gyűjtemény összes elemét eltávolítja.

A következő példa egy prezentációszintű egyéni XML részt távolít el referenciával:
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

Ha már rendelkezel egy `ICustomXmlPart`‑el, és a prezentációból szeretnéd eltávolítani a részt ahelyett, hogy egy adott gyűjteményhez fordulnál, hívd a `customXmlPart->Remove()` metódust.

Egy elemet index szerint is eltávolíthatsz:
```cpp
presentation->get_CustomData()->get_CustomXmlParts()->RemoveAt(0);
```
### **Az összes egyéni XML rész törlése egy gyűjteményből**

A `Clear` metódust használd, ha egy adott prezentációs objektumhoz kapcsolt összes egyéni XML részt el kell távolítani.
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

A `Clear` csak a kiválasztott gyűjteményre hat. Például egy dia gyűjteményének törlése nem törli a prezentációszintű vagy alakzatszintű gyűjteményeket.

A prezentáció minden egyéni XML részének eltávolításához iterálj a `get_AllCustomXmlParts()` felett, és távolítsd el az egyes részeket:
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

Egy Office Open XML prezentációban ugyanaz a egyéni XML rész több prezentációs objektumból is hivatkozható. Például egy meglévő fájl tartalmazhat kapcsolatokat több diához vagy alakzathoz, amelyek ugyanarra az alapszintű egyéni XML részre mutatnak.

Egy megosztott résznek egy adatobjektumként kell kezelni, amelynek több hivatkozása van:

- `set_XmlAsString`, `set_XmlData` vagy `set_ItemId` használatával a frissítés az alapszintű egyéni XML részt módosítja, így a változás minden hivatkozásnál érvényesül.
- `get_ItemId()` használható ugyanannak az egyéni XML résznek az azonosítására objektumszintű gyűjtemények auditálása során.
- Egy rész eltávolítása egy adott `get_CustomXmlParts()` gyűjteményből csak azt a gyűjteményt érinti. Használd az `ICustomXmlPart::Remove()`‑t, ha magát a részt el kell távolítani a prezentációból.
- A megosztott rész törlése vagy cseréje előtt ellenőrizd az objektumszintű gyűjteményeket, hogy más diák vagy alakzatok még hivatkoznak‑e rá.

Az `Add` túlterhelések egy új egyéni XML részt hoznak létre XML tartalomból; nem fogadnak el meglévő `ICustomXmlPart`‑et. Ezért a megosztott kapcsolatok leggyakrabban akkor fordulnak elő, amikor olyan prezentációkat töltesz be, amelyek már tartalmazzák őket.

A következő példa auditálja a prezentáció‑, dia‑ és alakzatszintű gyűjteményeket `ItemId` alapján, és jelzi azokat a részeket, amelyek több helyről is hivatkozottak:
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

Ez a fajta auditálás hasznos, mielőtt módosítanád vagy törölnéd az egyéni XML adatokat külső rendszerek által létrehozott prezentációkban, mivel ugyanaz a metaadat rész több kapcsolatban is részt vehet.
## **Címkék értékének lekérése**

A diákban egy címke a `IDocumentProperties::get_Keywords` tulajdonságnak felel meg. Ez a mintakód bemutatja, hogyan lehet egy címke értékét lekérni az Aspose.Slides for C++‑ban a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) esetén:
```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto keywords = presentation->get_DocumentProperties()->get_Keywords();
```
## **Címkék hozzáadása a prezentációkhoz**

Az Aspose.Slides lehetővé teszi címkék hozzáadását a prezentációkhoz. Egy címke általában két elemből áll:

- az egyéni tulajdonság neve, például `MyTag`;
- az egyéni tulajdonság értéke, például `My Tag Value`.

Ha a prezentációkat egy adott szabály vagy tulajdonság alapján szeretnéd osztályozni, hozzáadhatsz ehhez címkéket. Például, ha az észak-amerikai országokból származó prezentációkat szeretnéd kategorizálni, létrehozhatsz egy „North American” címkét, és a megfelelő országot állíthatod be értékeként.

Ez a mintakód bemutatja, hogyan lehet egy címkét hozzáadni egy [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) objektumhoz az Aspose.Slides for C++ használatával:
```cpp
#include <DOM/ICustomData.h>
#include <DOM/ITagCollection.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto tags = presentation->get_CustomData()->get_Tags();
tags->idx_set(u"MyTag", u"My Tag Value");
```

A címkék beállíthatók egy [Slide](https://reference.aspose.com/slides/hu/cpp/aspose.slides/slide/) számára is:
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

Vagy egy egyedi [Shape](https://reference.aspose.com/slides/hu/cpp/aspose.slides/shape/) esetén:
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

A `get_CustomData()->get_Tags()` gyűjteményen keresztül hozzáadott címkék csak a PowerPoint fájlban tárolódnak. Amikor a prezentációt PDF‑be exportálják, ezek **nem** kerülnek át a PDF címkeszerkezetbe. Ennek következtében egy címkébe rendelt egyéni azonosítót nem lehet lekérni a címkézett PDF‑ből.

**Megoldás**: Egy egyéni azonosítót tárolhatsz az objektum **Alt Text**‑ében (például `shape->set_AlternativeText(u"MyId")`). PDF‑re exportálás után az Alt Text megjelenhet a PDF címkeszerkezetben.
## **GYIK**
**Eltávolíthatok egy prezentációból, diához vagy alakzathoz tartozó összes címkét egyetlen műveletben?**

Igen. A [tag collection](https://reference.aspose.com/slides/hu/cpp/aspose.slides/tagcollection/) támogatja a [Clear](https://reference.aspose.com/slides/hu/cpp/aspose.slides/tagcollection/clear/) műveletet, amely egyszerre törli az összes kulcs‑érték párt.

**Hogyan töröljek egyetlen címkét a nevén anélkül, hogy végig iterálnék az egész gyűjteményen?**

Használd a [Remove(name)](https://reference.aspose.com/slides/hu/cpp/aspose.slides/tagcollection/remove/) metódust a [TagCollection](https://reference.aspose.com/slides/hu/cpp/aspose.slides/tagcollection/)‑on, hogy a kulcs alapján töröld a címkét.

**Hogyan nyerhetem ki a címkenevek teljes listáját elemzéshez vagy szűréshez?**

Használd a [GetNamesOfTags](https://reference.aspose.com/slides/hu/cpp/aspose.slides/tagcollection/getnamesoftags/) metódust a [tag collection](https://reference.aspose.com/slides/hu/cpp/aspose.slides/tagcollection/)‑on; ez egy tömböt ad vissza az összes címkenévvel.

**Hogyan találhatók meg az összes egyéni XML rész, függetlenül attól, hogy hol vannak tárolva?**

Használd a [`Presentation::get_AllCustomXmlParts`](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/get_allcustomxmlparts/) metódust, hogy lekérd a prezentációban lévő összes egyéni XML részt.

**Az `get_XmlAsString`/`set_XmlAsString` vagy a `get_XmlData`/`set_XmlData` használatát ajánlott egy egyéni XML rész frissítéséhez?**

Használd a `get_XmlAsString` és a `set_XmlAsString` metódusokat, ha az alkalmazás UTF‑8 XML szöveggel dolgozik. Használd a `get_XmlData` és a `set_XmlData` metódusokat, ha az XML már elérhető bájt‑tömbként, vagy ha a bináris feldolgozás kényelmesebb. Mindkét reprezentáció ugyanannak az egyéni XML résznek a tartalmára vonatkozik.
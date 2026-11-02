---
title: Prezentációtulajdonságok kezelése C++-ban
linktitle: Prezentációtulajdonságok
type: docs
weight: 70
url: /hu/cpp/presentation-properties/
keywords:
- PowerPoint tulajdonságok
- prezentációtulajdonságok
- dokumentumtulajdonságok
- beépített tulajdonságok
- egyéni tulajdonságok
- haladó tulajdonságok
- tulajdonságok kezelése
- tulajdonságok módosítása
- dokumentum metaadata
- metaadatok szerkesztése
- helyesírási nyelv
- alapértelmezett nyelv
- PowerPoint
- OpenDocument
- prezentáció
- C++
- Aspose.Slides
description: "Kezelje a prezentációtulajdonságokat az Aspose.Slides for C++ segítségével, és egyszerűsítse a keresést, a márkázást és a munkafolyamatot PowerPoint és OpenDocument fájljaiban."
---
## **Bevezetés**

Az Aspose.Slides for C++ támogatja a **beépített** és **egyéni** dokumentum tulajdonságokat. Ezeket a tulajdonságokat a bemutató metaadatainak olvasására és frissítésére használhatja, például a szerző, a cím és a felhasználó által meghatározott értékek esetén.

Az Aspose.Slides lehetővé teszi, hogy a prezentáció dokumentum tulajdonságokkal dolgozzon az [IDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/) felületen keresztül. Ennek a felületnek egy példánya a [IPresentation::get_DocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentation/get_documentproperties/) hívásával érhető el. A következő példák bemutatják, hogyan olvashatók, módosíthatók és kezelhetők ezek a tulajdonságok.

{{% alert color="info" title="Note" %}}
Az Aspose.Slides kezeli az alkalmazás- és termelő metaadatokat a prezentációk mentésekor; ezek a mezők azonosítják a kimenetet létrehozó szoftvert.
{{% /alert %}}

## **Prezentációtulajdonságok kezelése**

Dokumentumtulajdonságok tárolják a leíró információkat a prezentáció tartalma mellett. Két kategóriába sorolhatók:

- **Beépített tulajdonságok** standard metaadatokat tartalmaznak, például a címet, a szerzőt és a dokumentum statisztikákat.
- **Egyéni tulajdonságok** felhasználó által definiált név/érték párokat tárolnak.

Az Aspose.Slides for C++ hozzáférést biztosít mindkét kategóriához. PowerPointban válassza a **File → Info → Properties → Advanced Properties** menüt a dokumentum metaadatainak megtekintéséhez. A párbeszédablak információkat csoportosít fülekbe, mint például **Summary**, **Statistics**, **Contents** és **Custom**. Használja a **Custom** fület a felhasználó által definiált tulajdonságok kezeléséhez.

## **Nyilvános tulajdonságok olvasása titkosított prezentációból**

A megnyitási jelszó általában védi a prezentáció tartalmát és a dokumentumtulajdonságokat is. Amikor egy prezentációt a [IProtectionManager::set_EncryptDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/iprotectionmanager/set_encryptdocumentproperties/) metódus `false` értékével titkosítják, a dokumentumtulajdonságai nyilvánosak maradnak. Egy alkalmazás ezután `true` értékkel adhatja át a [LoadOptions::set_OnlyLoadDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_onlyloaddocumentproperties/) metódusnak, és a nyilvános metaadatokat a megnyitási jelszó megadása nélkül olvashatja.

A [LoadOptions::set_OnlyLoadDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_onlyloaddocumentproperties/) szabályozza, hogy az Aspose.Slides mit tölt be; nem titkosít fel semmit. Ha a tulajdonságok a titkosítás részei voltak, a jelszó nélkül történő betöltés sikertelen. Ha a prezentáció nincs titkosítva, az opciót figyelmen kívül hagyja, és a teljes prezentáció betöltődik.

A példához egy titkosított prezentációra van szükség, amelynek a dokumentumtulajdonságai nyilvánosak maradtak. Ellenőrzi a betöltési módot a [IProtectionManager::get_IsOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/cpp/aspose.slides/iprotectionmanager/get_isonlydocumentpropertiesloaded/) metódussal, majd a beépített tulajdonságokat a [IPresentation::get_DocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentation/get_documentproperties/) segítségével olvassa:
```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <DOM/LoadOptions.h>
#include <DOM/IProtectionManager.h>

using namespace Aspose::Slides;

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_OnlyLoadDocumentProperties(true);

auto presentation = System::MakeObject<Presentation>(u"public-properties-encrypted.pptx", loadOptions);

if (presentation->get_ProtectionManager()->get_IsOnlyDocumentPropertiesLoaded())
{
    auto documentProperties = presentation->get_DocumentProperties();

    System::Console::WriteLine(u"Author: {0}", documentProperties->get_Author());
    System::Console::WriteLine(u"Title: {0}", documentProperties->get_Title());
    System::Console::WriteLine(u"Keywords: {0}", documentProperties->get_Keywords());
}
else
{
    System::Console::WriteLine(u"The presentation was not loaded in document-properties-only mode.");
}
```

Ebben a módban a diák tartalma nincs betöltve. Diák, mester- diák, elrendezések, alakzatok, média és egyéb prezentációs objektumok nem érhetők el. Az alkalmazásoknak mindig ellenőrizniük kell a [IProtectionManager::get_IsOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/cpp/aspose.slides/iprotectionmanager/get_isonlydocumentpropertiesloaded/) metódust, mielőtt olyan műveletet hajtanának végre, amely a teljes prezentációs objektummodellt igényli.

{{% alert color="warning" title="Security" %}}
A nyilvános metaadatok felfedhetik a szerzőneveket, címeket, tárgyakat, kulcsszavakat, céginformációkat, megjegyzéseket és egyéni értékeket. Titkosítsa az érzékeny tulajdonságokat a prezentációval együtt. Hagyja nyilvánosan csak akkor, ha indexelés, osztályozás, keresés vagy dokumentumkezelő rendszereknek konkrét követelménye van arra, hogy jelszó nélkül hozzáférjenek.
{{% /alert %}}

## **Titkosított prezentáció tulajdonságainak frissítése**

Titkosított PPTX fájl esetén a [LoadOptions::set_OnlyLoadDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_onlyloaddocumentproperties/) `true` paraméterrel betöltött prezentáció a nyilvános metaadatok olvasására szolgál. Az Aspose.Slides nem tudja menteni a módosított tulajdonságokat ebből a csak metaadatot tartalmazó objektumból, mivel a nyilvános tulajdonságoknak egyezniük kell a titkosított prezentációban lévő megfelelő adatokkaL. Ennek frissítéséhez a helyes megnyitási jelszó és a teljes betöltés szükséges.

A példához egy titkosított PPTX prezentációra van szükség, amelynek a dokumentumtulajdonságai nyilvánosak, és ismert a megnyitási jelszó. A teljes prezentációt a [LoadOptions::set_Password](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_password/) segítségével nyitja meg, frissíti a nyilvános beépített tulajdonságokat, és elmenti az eredményt. Ezután a [IPresentationInfo::get_IsEncrypted](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentationinfo/get_isencrypted/) segítségével ellenőrzi, hogy a titkosítás megmaradt-e, és jelszó nélkül újra megnyitja a nyilvános metaadatokat az új értékek ellenőrzéséhez:
```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <DOM/LoadOptions.h>
#include <DOM/IProtectionManager.h>
#include <DOM/PresentationFactory.h>
#include <DOM/IPresentationInfo.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

const System::String inputPath = u"public-properties-encrypted.pptx";
const System::String outputPath = u"updated-public-properties-encrypted.pptx";

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"open_password");

auto presentation = System::MakeObject<Presentation>(inputPath, loadOptions);

auto documentProperties = presentation->get_DocumentProperties();
documentProperties->set_Title(u"Updated Product Roadmap");
documentProperties->set_Keywords(u"roadmap, planning, indexed");

presentation->Save(outputPath, SaveFormat::Pptx);

auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(outputPath);
System::Console::WriteLine(u"The presentation is encrypted: {0}", presentationInfo->get_IsEncrypted());

auto metadataLoadOptions = System::MakeObject<LoadOptions>();
metadataLoadOptions->set_OnlyLoadDocumentProperties(true);

auto metadataPresentation = System::MakeObject<Presentation>(outputPath, metadataLoadOptions);

if (metadataPresentation->get_ProtectionManager()->get_IsOnlyDocumentPropertiesLoaded())
{
    System::Console::WriteLine(u"Title: {0}", metadataPresentation->get_DocumentProperties()->get_Title());
    System::Console::WriteLine(u"Keywords: {0}", metadataPresentation->get_DocumentProperties()->get_Keywords());
}
else
{
    System::Console::WriteLine(u"The presentation was not loaded in document-properties-only mode.");
}
```

Ha egy alkalmazás nem jogosult a prezentáció tartalmának visszafejtésére vagy betöltésére, akkor a titkosított PPTX fájl nyilvános tulajdonságait csak olvashatóként kell kezelnie.

## **Beépített tulajdonságok elérése**

Az [IDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/) felület beépített metaadatokat tesz elérhetővé típusos lekérdezőkkel, többek között a [get_Author](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/get_author/), a [get_Title](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/get_title/) és a [get_CreatedTime](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/get_createdtime/) metódusokkal. Ez a példa egy meglévő prezentációt nyit meg, és a tárolt metaadatokat kiírja a konzolra. Az értékek a bemeneti prezentációtól függenek; egyes mezők üresek lehetnek.
```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"AccessBuiltInProperties.pptx");

auto documentProperties = presentation->get_DocumentProperties();

System::Console::WriteLine(u"Category: {0}", documentProperties->get_Category());
System::Console::WriteLine(u"Content status: {0}", documentProperties->get_ContentStatus());
System::Console::WriteLine(u"Creation date: {0}", documentProperties->get_CreatedTime());
System::Console::WriteLine(u"Author: {0}", documentProperties->get_Author());
System::Console::WriteLine(u"Comments: {0}", documentProperties->get_Comments());
System::Console::WriteLine(u"Keywords: {0}", documentProperties->get_Keywords());
System::Console::WriteLine(u"Last modified by: {0}", documentProperties->get_LastSavedBy());
System::Console::WriteLine(u"Manager: {0}", documentProperties->get_Manager());
System::Console::WriteLine(u"Modified date: {0}", documentProperties->get_LastSavedTime());
System::Console::WriteLine(u"Presentation format: {0}", documentProperties->get_PresentationFormat());
System::Console::WriteLine(u"Last print date: {0}", documentProperties->get_LastPrinted());
System::Console::WriteLine(u"Is shared between producers: {0}", documentProperties->get_SharedDoc());
System::Console::WriteLine(u"Subject: {0}", documentProperties->get_Subject());
System::Console::WriteLine(u"Title: {0}", documentProperties->get_Title());
```

## **Beépített tulajdonságok módosítása**

A beépített metaadatok frissítéséhez használja a [IPresentation::get_DocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentation/get_documentproperties/) által visszaadott objektum beállítóit. Ez a példa egy meglévő prezentációt nyit meg, meghívja a [set_Author](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/set_author/), [set_Title](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/set_title/), [set_Subject](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/set_subject/), [set_Comments](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/set_comments/) és [set_Manager](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/set_manager/) metódusokat, majd a [Presentation::Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/) segítségével elmenti a módosított prezentációt. A mentett PPTX tartalmazza az új metaadatokat.
```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"ModifyBuiltInProperties.pptx");

auto documentProperties = presentation->get_DocumentProperties();

documentProperties->set_Author(u"Aspose.Slides for C++");
documentProperties->set_Title(u"Manage PowerPoint Presentation Properties");
documentProperties->set_Subject(u"Modify Built-in Properties");
documentProperties->set_Comments(u"Aspose description");
documentProperties->set_Manager(u"Aspose manager");

presentation->Save(u"DocumentProperties_output.pptx", SaveFormat::Pptx);
```

## **A hiperhivatkozás alapjának kezelése**

Az [IDocumentProperties::get_HyperlinkBase](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/get_hyperlinkbase/) beolvassa a relatív hiperhivatkozások dokumentumszintű alapját. Ez akkor hasznos, amikor egy prezentációt és a hozzá kapcsolt fájlokat egy másik helyre mozgatják. Ez különbözik egyedi hiperhivatkozás [IHyperlink::get_ExternalUrl](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/get_externalurl/) értékétől: az alap módosítása nem írja át a tárolt hivatkozási címeket, vagy nem változtatja meg a abszolút célpontokat.

A példához egy olyan prezentációra van szükség, amely tartalmaz egy relatív hivatkozást, például `target.html`, és egy abszolút hivatkozást, például `https://example.org/absolute.html`. A meglévő alapot beolvassa, egy új alapcímet állít be az [IDocumentProperties::set_HyperlinkBase](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/set_hyperlinkbase/) segítségével, majd elmenti és újra megnyitja a prezentációt az érték ellenőrzéséhez. Ezután a `u""` értékkel törli az alapot, és egy külön mentett fájlban ellenőrzi az üres értéket. Cserélje le a példában szereplő alapcímét a saját hivatkozott fájljainak helyére.
```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"hyperlinks.pptx");

System::Console::WriteLine(u"Original base: {0}", presentation->get_DocumentProperties()->get_HyperlinkBase());

const System::String newBase = u"https://example.com/new/";
presentation->get_DocumentProperties()->set_HyperlinkBase(newBase);
presentation->Save(u"hyperlinks-updated.pptx", SaveFormat::Pptx);

auto updatedPresentation = System::MakeObject<Presentation>(u"hyperlinks-updated.pptx");
System::Console::WriteLine(u"Base preserved: {0}", (updatedPresentation->get_DocumentProperties()->get_HyperlinkBase() == newBase));

updatedPresentation->get_DocumentProperties()->set_HyperlinkBase(u"");
updatedPresentation->Save(u"hyperlinks-cleared.pptx", SaveFormat::Pptx);

auto clearedPresentation = System::MakeObject<Presentation>(u"hyperlinks-cleared.pptx");
System::Console::WriteLine(u"Base cleared: {0}", (clearedPresentation->get_DocumentProperties()->get_HyperlinkBase() == u""));
```

A két ellenőrző üzenetnek `True` értéket kell kiírnia. Az alap törlése nem érinti az egyedi hiperhivatkozási címeket.

Egy relatív hivatkozás a `target.pptx` fájlra a `old/target.pptx`-t nyitotta meg, amikor az alap az `old` mappára mutatott. Az alap `new` mappára történő módosítása, a mentés és a prezentáció újranyitása után ugyanaz a hivatkozás a `new/target.pptx`-t nyitotta meg. Egy abszolút hivatkozás továbbra is ugyanazt a fájlt nyitotta meg. Tesztelje a relatív hivatkozásait a PowerPointban a prezentáció áthelyezése vagy az alap módosítása előtt és után.

## **Egyéni prezentációtulajdonságok hozzáadása**

Az egyéni tulajdonságok olyan metaadatokat tárolnak, amelyeknek nincs megfelelő beépített mezője. Az [IDocumentProperties::idx_set](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/idx_set/) lehetővé teszi érték hozzárendelését a tulajdonság nevével. Ez a példa egy prezentációt hoz létre, két szöveges értéket és egy egész verzióértéket ad hozzá, majd a [Presentation::Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/) segítségével elmenti a prezentációt. Egy már létező névhez érték hozzárendelése felülírja a tulajdonság értékét.
```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();

auto documentProperties = presentation->get_DocumentProperties();

documentProperties->idx_set(u"Reviewed by", System::ObjectExt::Box<System::String>(u"John Smith"));
documentProperties->idx_set(u"Confidentiality level", System::ObjectExt::Box<System::String>(u"Internal"));
documentProperties->idx_set(u"Document version", System::ObjectExt::Box(2));

presentation->Save(u"CustomDocumentProperties_output.pptx", SaveFormat::Pptx);
```

## **Egyéni tulajdonságok elérése és módosítása**

Ez a példa egy egyéni tulajdonságokat tartalmazó prezentációt nyit meg, és a [get_CountOfCustomProperties](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/get_countofcustomproperties/) segítségével iterál rajtuk. A [GetCustomPropertyName](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/getcustompropertyname/) nulla alapú indexet fogad, és visszaadja a [IDocumentProperties::idx_get](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/idx_get/) és [idx_set](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/idx_set/) által használt nevet. A példa kiírja minden eredeti nevet és értéket, minden értéket számozott karakterlánccal helyettesít az eredeti típusától függetlenül, és elmenti a változtatásokat. Ha nincsenek egyéni tulajdonságok, a ciklus nem végez módosítást.
```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"AccessAndModifyProperties.pptx");

auto documentProperties = presentation->get_DocumentProperties();

for (auto i = 0; i < documentProperties->get_CountOfCustomProperties(); i++)
{
    auto propertyName = documentProperties->GetCustomPropertyName(i);
    auto propertyValue = documentProperties->idx_get(propertyName);

    System::Console::WriteLine(u"Custom property name: {0}", propertyName);
    System::Console::WriteLine(u"Custom property value: {0}", propertyValue);

    documentProperties->idx_set(propertyName, System::ObjectExt::Box(System::String::Format(u"New Value {0}", i + 1)));
}

presentation->Save(u"CustomProperties_output.pptx", SaveFormat::Pptx);
```

## **Élő példa**

Próbálja ki a [**View & Edit PowerPoint Metadata**](https://products.aspose.app/slides/metadata) online alkalmazást, hogy lássa, hogyan dolgozhat a dokumentumtulajdonságokkal az Aspose.Slides API segítségével:
[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **GYIK**

**Hogyan távolíthatok el egy beépített tulajdonságot egy prezentációból?**

A beépített tulajdonságok a prezentáció szerves részei, és nem távolíthatók el teljesen. Azonban módosíthatja az értéküket, vagy üresre állíthatja őket, ha az adott tulajdonság ezt megengedi.

**Mi történik, ha olyan egyéni tulajdonságot adok hozzá, amely már létezik?**

Ha olyan egyéni tulajdonságot ad hozzá, amely már létezik, a meglévő érték felül lesz írva az újjal. Nem szükséges előzetesen eltávolítani vagy ellenőrizni a tulajdonságot, mivel az Aspose.Slides automatikusan frissíti a tulajdonság értékét.

**Hozzáférek a prezentáció tulajdonságaihoz anélkül, hogy teljesen betölteném a prezentációt?**

Igen. Használja a [PresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/cpp/aspose.slides/presentationfactory/getpresentationinfo/) metódust, majd a [IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/) metódust a tárolt dokumentum metaadatok olvasásához anélkül, hogy [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) példányt hozna létre. Tekintse meg a [Build a Lightweight Presentation Inventory](/slides/hu/cpp/examine-presentation/) oldalt egy teljes jelentési példáért és a formátumspecifikus korlátozásokért.

**Olvashatom a nyilvános tulajdonságokat egy titkosított prezentációból anélkül, hogy megadnám a megnyitási jelszavát?**

Igen. A prezentációt úgy kell titkosítani, hogy a [IProtectionManager::set_EncryptDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/iprotectionmanager/set_encryptdocumentproperties/) metódusnak `false` értéket adunk, és a [LoadOptions::set_OnlyLoadDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_onlyloaddocumentproperties/) metódusnak `true` értékét kell átadni a betöltéshez.

**Frissíthetek egy titkosított PPTX fájlt csak dokumentumtulajdonságok módjában?**

Nem. A nyilvános és a titkosított tulajdonságadatoknak konzisztensnek kell maradniuk, ezért egy titkosított PPTX fájl frissítéséhez a teljes prezentációt a megfelelő megnyitási jelszóval kell betölteni.
---
title: Prezentáció tulajdonságok kezelése C++-ban
linktitle: Prezentáció tulajdonságok
type: docs
weight: 70
url: /hu/cpp/presentation-properties/
keywords:
- PowerPoint tulajdonságok
- prezentáció tulajdonságok
- dokumentumtulajdonságok
- beépített tulajdonságok
- egyéni tulajdonságok
- haladó tulajdonságok
- tulajdonságok kezelése
- tulajdonságok módosítása
- dokumentum metaadatok
- metaadatok szerkesztése
- ellenőrzési nyelv
- alapértelmezett nyelv
- PowerPoint
- OpenDocument
- prezentáció
- C++
- Aspose.Slides
description: "Kezelje a prezentáció tulajdonságait az Aspose.Slides for C++ segítségével, és egyszerűsítse a keresést, a márkajelzést és a munkafolyamatot a PowerPoint és OpenDocument fájljaiban."
---
## **Bevezetés**

Az Aspose.Slides for C++ **beépített** és **egyéni** dokumentumtulajdonságokat támogat. Ezeket a tulajdonságokat a prezentáció metaadatainak, például a szerző, a cím és a felhasználó által definiált értékek olvasására és frissítésére használhatja.

Az Aspose.Slides lehetővé teszi, hogy a prezentáció dokumentumtulajdonságokkal a [IDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/) felületen keresztül dolgozzon. Az interfész egy példányát a [IPresentation::get_DocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentation/get_documentproperties/) metódus adja vissza. Az alábbi példák bemutatják, hogyan lehet ezeket a tulajdonságokat olvasni, módosítani és kezelni.

{{% alert color="info" title="Note" %}}
Az Aspose.Slides kezeli az alkalmazás és a gyártó metaadatait a prezentációk mentésekor; ezek a mezők azonosítják a kimenetet létrehozó szoftvert.
{{% /alert %}}

## **Prezentációtulajdonságok kezelése**

A dokumentumtulajdonságok leíró információkat tárolnak a prezentációtartalom mellett. Két kategóriába sorolhatók:

- **Beépített tulajdonságok** tartalmazzák a szabványos metaadatokat, például a címet, a szerzőt és a dokumentum statisztikákat.
- **Egyéni tulajdonságok** tárolják a felhasználó által meghatározott név/érték párokat.

Az Aspose.Slides for C++ mindkét kategóriához hozzáférést biztosít. PowerPointban válassza a **File → Info → Properties → Advanced Properties** lehetőséget a dokumentum metaadatok megtekintéséhez. A párbeszédpanel az információkat **Summary**, **Statistics**, **Contents** és **Custom** lapokra csoportosítja. Az **Custom** lap segítségével kezelheti a felhasználó által definiált tulajdonságokat.

## **Publikus tulajdonságok olvasása titkosított prezentációból**

Általában egy nyitó jelszó védi a prezentáció tartalmát és a dokumentumtulajdonságokat egyaránt. Ha egy prezentációt úgy titkosítanak, hogy a [IProtectionManager::set_EncryptDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/iprotectionmanager/set_encryptdocumentproperties/) metódusnak `false` értéket adnak át, akkor a dokumentumtulajdonságok nyilvánosak maradnak. Az alkalmazás ezután `true` értékkel hívhatja a [LoadOptions::set_OnlyLoadDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_onlyloaddocumentproperties/) metódust, és a nyitó jelszó megadása nélkül olvashatja a publikus metaadatokat.

[LoadOptions::set_OnlyLoadDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_onlyloaddocumentproperties/) vezérli, hogy az Aspose.Slides mit tölt be; nem fejti meg a titkosítást. Ha a tulajdonságok a titkosítással együtt kerültek be, jelszó nélkül a betöltés nem sikerül. Nem titkosított prezentáció esetén a beállítást figyelmen kívül hagyja, és a teljes prezentációt betölti.

A példa egy olyan titkosított prezentációt igényel, amelynek dokumentumtulajdonságai nyilvánosak maradtak. Ellenőrzi a betöltési módot a [IProtectionManager::get_IsOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/cpp/aspose.slides/iprotectionmanager/get_isonlydocumentpropertiesloaded/) segítségével, majd a [IPresentation::get_DocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentation/get_documentproperties/) segítségével beolvassa a beépített tulajdonságokat:

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

Ebben a módban a diák tartalma nem kerül betöltésre. Diák, mesteroldalak, elrendezések, alakzatok, média és egyéb prezentációs objektumok nem érhetők el. Az alkalmazásoknak mindig ellenőrizniük kell a [IProtectionManager::get_IsOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/cpp/aspose.slides/iprotectionmanager/get_isonlydocumentpropertiesloaded/) állapotát, mielőtt olyan műveletet végeznek, amely a teljes prezentációs objektummodellt igényli.

{{% alert color="warning" title="Security" %}}
A publikus metaadatok felfedhetik a szerző neveit, címeket, tárgyakat, kulcsszavakat, céginformációkat, megjegyzéseket és egyéni értékeket. Titkosítsa az érzékeny tulajdonságokat a prezentációval együtt. A publikus maradást csak akkor alkalmazza, ha indexelésnek, osztályozásnak, keresésnek vagy dokumentumkezelő rendszereknek kifejezett szükségük van a jelszó nélküli hozzáférésre.
{{% /alert %}}

## **Titkosított prezentáció tulajdonságainak frissítése**

Titkosított PPTX fájl esetén a [LoadOptions::set_OnlyLoadDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_onlyloaddocumentproperties/) `true` értékkel történő betöltése csak a publikus metaadatok olvasására szolgál. Az Aspose.Slides nem tudja menteni a módosított tulajdonságokat ebből a csak metaadat-objektumból, mert a publikus tulajdonságoknak összhangban kell lenniük a titkosított prezentációban tárolt adatokkal. Ennek frissítése ezért a helyes nyitó jelszót és a teljes betöltést igényli.

A példa egy olyan titkosított PPTX prezentációt igényel, amelynek dokumentumtulajdonságai nyilvánosak és ismert a nyitó jelszó. A teljes prezentációt a [LoadOptions::set_Password](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_password/) segítségével nyitja meg, frissíti a publikus beépített tulajdonságokat, és menti az eredményt. Ezután a [IPresentationInfo::get_IsEncrypted](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentationinfo/get_isencrypted/) segítségével ellenőrzi, hogy a titkosítás megmaradt, és a publikus metaadatot jelszó nélkül újra megnyitja az új értékek ellenőrzésére:

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

Ha egy alkalmazás nem rendelkezik jogosultsággal a prezentáció tartalmának visszafejtésére vagy betöltésére, a titkosított PPTX fájl publikus tulajdonságait csak olvasásra tekinthetőnek kell tekinteni.

## **Beépített tulajdonságok elérése**

Az [IDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/) felület a beépített metaadatokat típusos getterekkel teszi elérhetővé, beleértve a [get_Author](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/get_author/), [get_Title](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/get_title/) és [get_CreatedTime](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/get_createdtime/) metódusokat. Ez a példa egy meglévő prezentációt nyit meg, és a konzolra írja a tárolt metaadatokat. Az értékek a bemeneti prezentációtól függnek; egyes mezők üresek lehetnek.

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

### **Jelentés a revíziószámról és a szerkesztési időről**

Használja a [GetPresentationInfo](https://reference.aspose.com/slides/cpp/aspose.slides/presentationfactory/getpresentationinfo/) és a [ReadDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/) metódusokat az egyes fájlok [IDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/) beolvasásához anélkül, hogy a diák betöltésre kerülnének a szerkesztéshez. Ez a példa egy sort nyomtat ki PPTX fájlonként a `presentations` mappában. A szabványos `c` formátum tartalmazza a napok számát, amikor a rögzített szerkesztési idő eléri a 24 órát.

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/IPresentationInfo.h>
#include <DOM/PresentationFactory.h>
#include <system/console.h>
#include <system/io/directory.h>
#include <system/io/path.h>
#include <system/timespan.h>

using namespace Aspose::Slides;
using namespace System::IO;

System::Console::WriteLine(u"File | RevisionNumber | TotalEditingTime");
auto paths = Directory::GetFiles(u"presentations", u"*.pptx");
for (const auto& path : paths)
{
    auto info = PresentationFactory::get_Instance()->GetPresentationInfo(path);
    auto properties = info->ReadDocumentProperties();
    auto fileName = Path::GetFileName(path);
    auto editingTime = properties->get_TotalEditingTime().ToString(u"c");
    System::Console::WriteLine(u"{0} | {1} | {2}", fileName, properties->get_RevisionNumber(), editingTime);
}
```

Egy 1 nap, 2 óra és 5 perc rögzített szerkesztési idővel rendelkező prezentáció esetén a jelentés a következőképpen néz ki:

```text
File | RevisionNumber | TotalEditingTime
long.pptx | 17 | 1.02:05:00
```

[get_RevisionNumber](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/get_revisionnumber/) metaadatértéket olvas, amelyet az alkalmazások a [set_RevisionNumber](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/set_revisionnumber/) segítségével módosíthatnak. Ez az érték önmagában nem határozza meg, hányszor mentették a prezentációt, vagy hogyan néz ki a verziótörténet.

[get_TotalEditingTime](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/get_totaleditingtime/) visszaadja a fájlban rögzített szerkesztési időtartamot. A `00:00:00` érték azt jelenti, hogy a tárolt időtartam nulla. A prezentációt továbbra is szerkeszthették.

## **Beépített tulajdonságok módosítása**

A beépített metaadatok frissítéséhez használja a [IPresentation::get_DocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentation/get_documentproperties/) által visszaadott objektum setter‑eit. Ez a példa egy meglévő prezentációt nyit meg, meghívja a [set_Author](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/set_author/), [set_Title](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/set_title/), [set_Subject](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/set_subject/), [set_Comments](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/set_comments/) és [set_Manager](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/set_manager/) metódusokat, majd a [Presentation::Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/) segítségével menti a frissített prezentációt. A mentett PPTX tartalmazza az új metaadatokat.

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

[IDocumentProperties::get_HyperlinkBase](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/get_hyperlinkbase/) kiolvassa a dokumentumszintű alapot a relatív hiperhivatkozásokhoz. Ez akkor hasznos, amikor egy prezentációt és a hozzá kapcsolódó fájlokat más helyre mozgatjuk. Különálló az egyes hiperhivatkozások [IHyperlink::get_ExternalUrl](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/get_externalurl/) értékétől: az alap megváltoztatása nem írja felül a tárolt hivatkozási címeket, és nem módosítja az abszolút célpontokat.

A példa egy olyan prezentációt igényel, amely tartalmaz egy relatív linket, például `target.html`, és egy abszolút linket, például `https://example.org/absolute.html`. Kiolvassa a meglévő alapot, egy új alapcímet ad meg a [IDocumentProperties::set_HyperlinkBase](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/set_hyperlinkbase/) segítségével, majd menti és újra megnyitja a prezentációt az érték ellenőrzéséhez. Ezután a `u""` értékkel törli az alapot, és egy külön mentett fájlban ellenőrzi az üres értéket. Cserélje ki a példában szereplő alapcímet a saját linkfájljainak helyére.

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

A két ellenőrző üzenetnek `True`‑t kell kiírnia. Az alap törlése nem érinti az egyes hiperhivatkozás-címeket.

Egy relatív hivatkozás a `target.pptx` fájlra a `old/target.pptx`-t nyitotta meg, amikor az alap a `old` mappára mutatott. Az alap `new` mappára történő módosítása, a mentés és a prezentáció újra megnyitása után ugyanaz a hivatkozás a `new/target.pptx`-t nyitja meg. Az abszolút hivatkozás továbbra is ugyanazt a fájlt nyitja. Tesztelje a relatív hivatkozásokat PowerPointban a prezentáció áthelyezése vagy az alap módosítása előtt és után.

## **Egyéni prezentációtulajdonságok hozzáadása**

Az egyéni tulajdonságok olyan metaadatot tárolnak, amelyhez nincs megfelelő beépített mező. A [IDocumentProperties::idx_set](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/idx_set/) lehetővé teszi, hogy a tulajdonság nevét használva értéket rendeljünk hozzá. Ez a példa egy prezentációt hoz létre, két szöveges értéket és egy egész számú verzióértéket ad hozzá, majd a [Presentation::Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/) segítségével menti a prezentációt. Meglévő névhez érték hozzárendelése felülírja az adott tulajdonság értékét.

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

Ez a példa egy olyan prezentációt nyit meg, amely egyéni tulajdonságokat tartalmaz, és a [get_CountOfCustomProperties](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/get_countofcustomproperties/) segítségével végigiterál rajtuk. A [GetCustomPropertyName](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/getcustompropertyname/) nulla‑bázisú indexet fogad, és visszaadja a [IDocumentProperties::idx_get](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/idx_get/) és [idx_set](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/idx_set/) által használt nevet. A példa kiírja az eredeti nevet és értéket, minden értéket egy számozott karakterláncra cserél, függetlenül az eredeti típusától, majd menti a változásokat. Ha nincsenek egyéni tulajdonságok, a ciklus nem végzi el a módosítást.

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

Próbálja ki az online [**View & Edit PowerPoint Metadata**](https://products.aspose.app/slides/metadata) alkalmazást, hogy lássa, hogyan dolgozhat a dokumentumtulajdonságokkal az Aspose.Slides API segítségével:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **GYIK**

**Hogyan távolíthatok el egy beépített tulajdonságot egy prezentációból?**

A beépített tulajdonságok a prezentáció szerves részei, és nem távolíthatók el teljesen. Azonban megváltoztathatja az értéküket, vagy ha a konkrét tulajdonság megengedi, üresre állíthatja őket.

**Mi történik, ha egy már meglévő egyéni tulajdonságot adok hozzá?**

Ha egy már létező egyéni tulajdonságot ad hozzá, a meglévő érték felülíródik az újjal. Nem szükséges előre eltávolítani vagy ellenőrizni a tulajdonságot, mivel az Aspose.Slides automatikusan frissíti annak értékét.

**Elérhetem a prezentáció tulajdonságait a teljes prezentáció betöltése nélkül?**

Igen. Használja a [PresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/cpp/aspose.slides/presentationfactory/getpresentationinfo/) metódust, majd a [IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/) segítségével olvassa a tárolt dokumentum metaadatait anélkül, hogy [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) példányt hozna létre. Lásd a [Build a Lightweight Presentation Inventory](/slides/hu/cpp/examine-presentation/) példát a teljes jelentéshez és a formátumspecifikus korlátozásokhoz.

**Olvashatok publikus tulajdonságokat egy titkosított prezentációból a nyitó jelszó nélkül?**

Igen. A prezentációt úgy kell titkosítani, hogy a [IProtectionManager::set_EncryptDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/iprotectionmanager/set_encryptdocumentproperties/) `false` értéket kap, majd a [LoadOptions::set_OnlyLoadDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_onlyloaddocumentproperties/) `true` értékkel legyen betöltve.

**Frissíthetek egy titkosított PPTX fájlt csak dokumentumtulajdonságok módjában?**

Nem. A publikus és a titkosított tulajdonságok adatainak összhangban kell maradniuk, így egy titkosított PPTX fájl frissítése a helyes nyitó jelszóval történő teljes betöltést igényli.
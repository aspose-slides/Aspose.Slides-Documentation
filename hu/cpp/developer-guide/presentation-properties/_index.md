---
title: Prezentációs tulajdonságok kezelése C++-ban
linktitle: Prezentációs tulajdonságok
type: docs
weight: 70
url: /hu/cpp/presentation-properties/
keywords:
- PowerPoint tulajdonságok
- prezentációs tulajdonságok
- dokumentumtulajdonságok
- beépített tulajdonságok
- egyéni tulajdonságok
- haladó tulajdonságok
- tulajdonságok kezelése
- tulajdonságok módosítása
- dokumentum metaadatok
- metaadatok szerkesztése
- helyesírás-nyelv
- alapértelmezett nyelv
- PowerPoint
- OpenDocument
- prezentáció
- C++
- Aspose.Slides
description: "A prezentációs tulajdonságok teljes körű kezelése az Aspose.Slides for C++-ban, valamint a keresés, a márkázás és a munkafolyamat egyszerűsítése PowerPoint és OpenDocument fájljaiban."
---
## **Bevezetés**

Az Aspose.Slides két típusú dokumentumtulajdonságot támogat: **Beépített** és **Egyéni**. Mindkét tulajdonságtípus könnyen elérhető és kezelhető az Aspose.Slides API használatával.

Az Aspose.Slides lehetővé teszi, hogy a prezentáció dokumentumtulajdonságokkal a [IDocumentProperties](https://reference.aspose.com/slides/hu/cpp/aspose.slides/idocumentproperties/) interfészen keresztül dolgozzon. Ennek az interfésznek egy példánya a [IPresentation::get_DocumentProperties](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipresentation/get_documentproperties/) metódussal érhető el. A következő példák bemutatják, hogyan olvashatja, módosíthatja és kezelheti ezeket a tulajdonságokat.

{{% alert color="info" title="Megjegyzés" %}}
Felhívjuk a figyelmet, hogy a **Application** és **Producer** mezőknél nem állíthat be értékeket, mivel az Aspose Ltd. és az Aspose.Slides for C++ x.x.x jelenik meg ezekben a mezőkben.
{{% /alert %}} 

## **Kezelje a prezentáció tulajdonságait**

A Microsoft PowerPoint lehetővé teszi, hogy bizonyos tulajdonságokat adjon a prezentációs fájlokhoz. Ezek a dokumentumtulajdonságok hasznos információk tárolását teszik lehetővé a dokumentumokkal (presentációs fájlokkal) együtt. Kétféle dokumentumtulajdonság létezik:

- Rendszer által definiált (Beépített) tulajdonságok
- Felhasználó által definiált (Egyéni) tulajdonságok

**Beépített** tulajdonságok általános információkat tartalmaznak a dokumentumról, például a cím, a szerző neve, a statisztikák stb. **Egyéni** tulajdonságok a felhasználó által definiált **Név/Érték** párok, ahol mind a név, mind az érték a felhasználó által kerül megadásra. Az Aspose.Slides for C++ segítségével a fejlesztők hozzáférhetnek és módosíthatják a beépített és az egyéni tulajdonságok értékeit. A Microsoft PowerPoint 2007 lehetővé teszi a prezentációs fájlok dokumentumtulajdonságainak kezelését. Ehhez csak kattintson az Office ikonra, majd a **Prepare | Properties | Advanced Properties** menüpontra. A **Advanced Properties** menüpont kiválasztása után megjelenik egy párbeszédablak, ahol a PowerPoint fájl dokumentumtulajdonságait kezelheti. A **Properties Dialog** ablakban több lap található, például **General, Summary, Statistics, Contents and Custom**. Ezek a lapok különböző információk beállítását teszik lehetővé a PowerPoint fájlokhoz. Az **Custom** lap a PowerPoint fájlok egyéni tulajdonságainak kezelésére szolgál.

## **Nyilvános tulajdonságok olvasása titkosított prezentációból**

A megnyitási jelszó általában védi a prezentáció tartalmát és a dokumentumtulajdonságokat is. Ha a prezentációt a [IProtectionManager::set_EncryptDocumentProperties](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iprotectionmanager/set_encryptdocumentproperties/) metódusban a `false` értékkel hívják meg, a dokumentumtulajdonságok nyilvánosak maradnak. Ezután egy alkalmazás a [LoadOptions::set_OnlyLoadDocumentProperties](https://reference.aspose.com/slides/hu/cpp/aspose.slides/loadoptions/set_onlyloaddocumentproperties/) metódus `true` értékével olvashatja a nyilvános metaadatokat anélkül, hogy megadná a megnyitási jelszót.

`set_OnlyLoadDocumentProperties` szabályozza, hogy az Aspose.Slides mit tölt be; nem titkosít fel semmit. Ha a tulajdonságok a titkosításba beletartoznak, a jelszó nélküli betöltés sikertelen. Ha a prezentáció nincs titkosítva, a beállítás figyelmen kívül marad, és a teljes prezentáció betöltődik.

A következő példa a [IProtectionManager::get_IsOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iprotectionmanager/get_isonlydocumentpropertiesloaded/) metódus segítségével ellenőrzi a betöltési módot, majd a [IPresentation::get_DocumentProperties](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipresentation/get_documentproperties/) metódussal olvassa a beépített tulajdonságokat:

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/IProtectionManager.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_OnlyLoadDocumentProperties(true);

auto presentation = MakeObject<Presentation>(u"public-properties-encrypted.pptx", loadOptions);

if (presentation->get_ProtectionManager()->get_IsOnlyDocumentPropertiesLoaded())
{
    auto properties = presentation->get_DocumentProperties();

    Console::WriteLine(u"Author: " + properties->get_Author());
    Console::WriteLine(u"Title: " + properties->get_Title());
    Console::WriteLine(u"Keywords: " + properties->get_Keywords());
}
else
{
    Console::WriteLine(u"The presentation was not loaded in document-properties-only mode.");
}

presentation->Dispose();
```

Ebben a módban a diák tartalma nem töltődik be. Diák, mesterlapok, elrendezések, alakzatok, média és egyéb prezentációs objektumok nem állnak rendelkezésre. Az alkalmazásoknak mindig ellenőrizniük kell a `get_IsOnlyDocumentPropertiesLoaded` értékét, mielőtt olyan műveletet végeznek, amely a teljes prezentációs objektummodellt igényli.

{{% alert color="warning" title="Figyelmeztetés" %}}
A nyilvános metaadatok felfedhetik a szerző neveit, címeket, tárgyakat, kulcsszavakat, céges információkat, megjegyzéseket és egyéni értékeket. Titkosítsa az érzékeny tulajdonságokat a prezentációval együtt. Csak akkor hagyja nyilvánosan, ha indexeléshez, osztályozáshoz, kereséshez vagy dokumentumkezelő rendszerekhez specifikus igény van a jelszó nélküli hozzáférésre.
{{% /alert %}}

## **Titkosított prezentáció tulajdonságainak frissítése**

Titkosított PPTX fájl esetén a `set_OnlyLoadDocumentProperties(true)` hívása után betöltött prezentáció a nyilvános metaadatok olvasására szolgál. Az Aspose.Slides nem tudja menteni a módosított tulajdonságokat ebből a csak metaadatot tartalmazó objektumból, mivel a nyilvános tulajdonságoknak konzisztensnek kell maradniuk a titkosított prezentációban lévő adatokkal. A módosításhoz ezért a helyes megnyitási jelszó és egy teljes betöltés szükséges.

Az alábbi példában a [LoadOptions::set_Password](https://reference.aspose.com/slides/hu/cpp/aspose.slides/loadoptions/set_password/) metódussal nyitjuk meg a prezentációt, frissítjük a nyilvános beépített tulajdonságokat, majd elmentjük az eredményt. Ezután a [IPresentationInfo::get_IsEncrypted](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipresentationinfo/get_isencrypted/) metódussal ellenőrizzük, hogy a titkosítás megmaradt-e, és a nyilvános metaadatokat jelszó nélkül újra megnyitjuk az új értékek ellenőrzéséhez:

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/IPresentationInfo.h>
#include <DOM/IProtectionManager.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <DOM/PresentationFactory.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

const String inputPath = u"public-properties-encrypted.pptx";
const String outputPath = u"updated-public-properties-encrypted.pptx";

{
    auto loadOptions = MakeObject<LoadOptions>();
    loadOptions->set_Password(u"open_password");

    auto presentation = MakeObject<Presentation>(inputPath, loadOptions);
    presentation->get_DocumentProperties()->set_Title(u"Updated Product Roadmap");
    presentation->get_DocumentProperties()->set_Keywords(u"roadmap, planning, indexed");
    presentation->Save(outputPath, SaveFormat::Pptx);
    presentation->Dispose();
}

auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(outputPath);
Console::WriteLine(presentationInfo->get_IsEncrypted() ? u"The presentation is encrypted." : u"The presentation is not encrypted.");

auto metadataLoadOptions = MakeObject<LoadOptions>();
metadataLoadOptions->set_OnlyLoadDocumentProperties(true);

auto metadataPresentation = MakeObject<Presentation>(outputPath, metadataLoadOptions);

if (metadataPresentation->get_ProtectionManager()->get_IsOnlyDocumentPropertiesLoaded())
{
    Console::WriteLine(u"Title: " + metadataPresentation->get_DocumentProperties()->get_Title());
    Console::WriteLine(u"Keywords: " + metadataPresentation->get_DocumentProperties()->get_Keywords());
}
else
{
    Console::WriteLine(u"The presentation was not loaded in document-properties-only mode.");
}

metadataPresentation->Dispose();
```

Ha egy alkalmazás nem jogosult a prezentáció tartalmának dekódolására vagy betöltésére, a titkosított PPTX fájl nyilvános tulajdonságait csak olvashatóként kell kezelni.

## **Beépített tulajdonságok elérése**

Az **IDocumentProperties** objektum által kiexponált tulajdonságok közé tartozik: **Creator(Author)**, **Description**, **KeyWords**, **Created** (Creation Date), **Modified** (Modification Date), **Printed** (Last Print Date), **LastModifiedBy**, **Keywords**, **SharedDoc** (Is shared between different producers?), **PresentationFormat**, **Subject** és **Title**.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessBuiltinProperties-AccessBuiltinProperties.cpp" >}}

## **Beépített tulajdonságok módosítása**

A beépített tulajdonságok módosítása a prezentációs fájlokban olyan egyszerű, mint azok elérése. Egyszerűen hozzárendelhet egy karakterlánc értéket a kívánt tulajdonsághoz, és a tulajdonság értéke módosul. Az alábbi példában bemutatjuk, hogyan módosíthatja a prezentáció fájl beépített dokumentumtulajdonságait.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-UpdatePresentationProperties-UpdatePresentationProperties.cpp" >}}

## **Egyéni prezentációs tulajdonságok hozzáadása**

Az Aspose.Slides for C++ lehetővé teszi a fejlesztők számára, hogy egyéni értékeket adjanak a prezentáció dokumentumtulajdonságaihoz. Az alábbi példában látható, hogyan állíthatja be a egyéni tulajdonságokat egy prezentációhoz.

``` cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// A Presentation osztály példányosítása
auto presentation = System::MakeObject<Presentation>();

// Dokumentumtulajdonságok lekérése
auto documentProperties = presentation->get_DocumentProperties();

// Egyéni tulajdonságok hozzáadása
documentProperties->idx_set(u"New Custom", ObjectExt::Box<int32_t>(12));
documentProperties->idx_set(u"My Name", ObjectExt::Box<String>(u"Mudassir"));
documentProperties->idx_set(u"Custom", ObjectExt::Box<int32_t>(124));

// Tulajdonság nevének lekérése adott indexnél
String getPropertyName = documentProperties->GetCustomPropertyName(2);

// Kiválasztott tulajdonság eltávolítása
documentProperties->RemoveCustomProperty(getPropertyName);

// Prezentáció mentése
presentation->Save(u"CustomDocumentProperties_out.pptx", SaveFormat::Pptx);
```

## **Egyéni tulajdonságok elérése és módosítása**

Az Aspose.Slides for C++ lehetővé teszi a fejlesztők számára, hogy elérjék az egyéni tulajdonságok értékeit. Az alábbi példában látható, hogyan érheti el és módosíthatja egy prezentáció összes egyéni tulajdonságát.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessModifyingProperties-AccessModifyingProperties.cpp" >}}

## **Helyesírás-nyelv beállítása**

Az Aspose.Slides a [LanguageId](https://reference.aspose.com/slides/hu/cpp/aspose.slides/baseportionformat/set_languageid/) tulajdonságot (a [PortionFormat](https://reference.aspose.com/slides/hu/cpp/aspose.slides/portionformat/) osztály által kiexponálva) biztosítja, hogy beállíthassa a helyesírás-nyelvet egy PowerPoint dokumentumhoz. A helyesírás-nyelv az a nyelv, amelynek helyesírását és nyelvtanát a PowerPoint ellenőrzi.

Ez a C++ kód megmutatja, hogyan állíthatja be a helyesírás-nyelvet egy PowerPoint prezentációhoz:

```c++
#include <DOM/AutoShape.h>
#include <DOM/Fonts/FontData.h>
#include <DOM/IFontData.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
using namespace Aspose::Slides;

System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"sample.pptx");
System::SharedPtr<AutoShape> autoShape = System::ExplicitCast<AutoShape>(pres->get_Slide(0)->get_Shape(0));

System::SharedPtr<IParagraph> paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
System::SharedPtr<IPortionCollection> portions = paragraph->get_Portions();
portions->Clear();

System::SharedPtr<Portion> newPortion = System::MakeObject<Portion>();

System::SharedPtr<IFontData> font = System::MakeObject<FontData>(u"SimSun");
System::SharedPtr<IPortionFormat> portionFormat = newPortion->get_PortionFormat();
portionFormat->set_ComplexScriptFont(font);
portionFormat->set_EastAsianFont(font);
portionFormat->set_LatinFont(font);

portionFormat->set_LanguageId(u"zh-CN");
// állítsa be a helyesírás-nyelv azonosítóját

newPortion->set_Text(u"1。");
portions->Add(newPortion);
```

## **Alapértelmezett nyelv beállítása**

Ez a C++ kód megmutatja, hogyan állíthatja be az alapértelmezett nyelvet egy teljes PowerPoint prezentációhoz:

```c++
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/console.h>
using namespace Aspose::Slides;

System::SharedPtr<LoadOptions> loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_DefaultTextLanguage(u"en-US");

System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(loadOptions);

// Új téglalap alakzat szöveggel
System::SharedPtr<IAutoShape> shp = pres->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 150.0f, 50.0f);
System::SharedPtr<ITextFrame> textFrame = shp->get_TextFrame();
textFrame->set_Text(u"New Text");

// Ellenőrzi az első rész nyelvét
System::Console::WriteLine(textFrame->get_Paragraph(0)->get_Portion(0)->get_PortionFormat()->get_LanguageId());
```

## **Élő példa**

Próbálja ki a [**Aspose.Slides Metadata**](https://products.aspose.app/slides/hu/metadata) online alkalmazást, hogy lássa, hogyan dolgozhat a dokumentumtulajdonságokkal az Aspose.Slides API segítségével:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/hu/metadata)

## **GYIK**

**Hogyan távolíthatok el egy beépített tulajdonságot a prezentációból?**

A beépített tulajdonságok a prezentáció integrált részei, és nem távolíthatók el teljesen. Azonban megváltoztathatja az értéküket, vagy ha a konkrét tulajdonság ezt megengedi, üresre állíthatja őket.

**Mi történik, ha már létező egyéni tulajdonságot adok hozzá?**

Ha már létező egyéni tulajdonságot ad hozzá, a meglévő értéke felül lesz írva az újjal. Nem szükséges előzetesen eltávolítani vagy ellenőrizni a tulajdonságot, mivel az Aspose.Slides automatikusan frissíti a tulajdonság értékét.

**Hozzáférhetek a prezentáció tulajdonságaihoz anélkül, hogy teljesen betölteném a prezentációt?**

Igen. Használja a [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) metódust, majd a [IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/) metódust a dokumentum metaadatainak beolvasásához anélkül, hogy [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) példányt hozna létre. Tekintse meg a [Build a Lightweight Presentation Inventory](/slides/hu/cpp/examine-presentation/) oldalt a teljes jelentési példa és a formátumspecifikus korlátozások megtekintéséhez.

**Olvashatok nyilvános tulajdonságokat egy titkosított prezentációból anélkül, hogy a megnyitási jelszót ismerném?**

Igen. A prezentációnak úgy kell titkosítva lennie, hogy a `set_EncryptDocumentProperties` `false` értékkel lett meghívva, és a `set_OnlyLoadDocumentProperties` `true` értékkel kell betölteni.

**Frissíthetek egy titkosított PPTX fájlt csak dokumentumtulajdonságok módjában?**

Nem. A nyilvános és a titkosított tulajdonságadatoknak konzisztensnek kell maradniuk, ezért egy titkosított PPTX fájl frissítéséhez a teljes prezentációt a helyes megnyitási jelszóval kell betölteni.
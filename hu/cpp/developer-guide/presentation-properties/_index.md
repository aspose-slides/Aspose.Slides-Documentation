---
title: Prezentáció tulajdonságainak kezelése C++-ban
linktitle: Prezentáció tulajdonságai
type: docs
weight: 70
url: /hu/cpp/presentation-properties/
keywords:
- PowerPoint tulajdonságok
- prezentáció tulajdonságok
- dokumentum tulajdonságok
- beépített tulajdonságok
- egyéni tulajdonságok
- haladó tulajdonságok
- tulajdonságok kezelése
- tulajdonságok módosítása
- dokumentum metaadatok
- metaadatok szerkesztése
- ellenőrző nyelv
- alapértelmezett nyelv
- PowerPoint
- OpenDocument
- prezentáció
- C++
- Aspose.Slides
description: "Mesteri szinten kezeli a prezentációtulajdonságokat az Aspose.Slides for C++-ban, és egyszerűsíti a keresést, a márkázást és a munkafolyamatot a PowerPoint és OpenDocument fájljaiban."
---
## **Bevezetés**

Az Aspose.Slides két típusú dokumentumtulajdonságot támogat: **Beépített** és **Egyéni**. Mindkét tulajdonságtípust egyszerűen el lehet érni és kezelni az Aspose.Slides API-val.

Az Aspose.Slides lehetővé teszi, hogy a prezentáció dokumentumtulajdonságokkal a [IDocumentProperties](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.i_document_properties) interfészen keresztül dolgozzon. Ennek az interfésznek egy példányát a [Presentation::get_DocumentProperties](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/get_documentproperties/) metódus adja vissza. A következő példák bemutatják, hogyan lehet ezeket a tulajdonságokat olvasni, módosítani és kezelni.

{{% alert color="info" title="Megjegyzés" %}}
Kérjük, vegye figyelembe, hogy a **Application** és **Producer** mezőkben nem állíthat be értékeket, mivel az Aspose Ltd. és az Aspose.Slides for C++ x.x.x jelenik meg ezekben a mezőkben.
{{% /alert %}} 

## **A prezentáció tulajdonságainak kezelése**

A Microsoft PowerPoint lehetőséget biztosít, hogy néhány tulajdonságot hozzáadjon a prezentációfájlokhoz. Ezek a dokumentumtulajdonságok hasznos információk tárolását teszik lehetővé a dokumentumokkal (prezentációfájlokkal) együtt. Kétféle dokumentumtulajdonság létezik:

- Rendszer által definiált (Beépített) tulajdonságok
- Felhasználó által definiált (Egyéni) tulajdonságok

A **Beépített** tulajdonságok általános információkat tartalmaznak a dokumentumról, például a dokumentum címét, a szerző nevét, a dokumentum statisztikáit stb. A **Egyéni** tulajdonságok olyan párok, amelyeket a felhasználók **Név/Érték** párokként definiálnak, ahol a név és az érték is a felhasználó által kerül megadásra. Az Aspose.Slides for C++ használatával a fejlesztők hozzáférhetnek és módosíthatják a beépített és az egyéni tulajdonságok értékeit egyaránt. A Microsoft PowerPoint 2007 lehetővé teszi a prezentációfájlok dokumentumtulajdonságainak kezelését. Ehhez csak a Office ikonra kell kattintani, majd a **Prepare | Properties | Advanced Properties** menüpontot a Microsoft PowerPoint 2007-ben. A **Advanced Properties** menüpont kiválasztása után egy párbeszédablak jelenik meg, amely lehetővé teszi a PowerPoint fájl dokumentumtulajdonságainak kezelését. A **Properties Dialog** ablakban számos lap található, például **General**, **Summary**, **Statistics**, **Contents** és **Custom**. Ezek a lapok különféle információk konfigurálását teszik lehetővé a PowerPoint fájlokkal kapcsolatban. A **Custom** lapot az egyéni tulajdonságok kezelése céljából használják.

## **Beépített tulajdonságok elérése**

Az **IDocumentProperties** objektum által szolgáltatott ezek a tulajdonságok a következőket tartalmazzák: **Creator(Author)**, **Description**, **Keywords**, **Created** (Létrehozás dátuma), **Modified** (Módosítás dátuma), **Printed** (Utolsó nyomtatás dátuma), **LastModifiedBy**, **Keywords**, **SharedDoc** (Megosztott különböző készítők között?), **PresentationFormat**, **Subject** és **Title**

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessBuiltinProperties-AccessBuiltinProperties.cpp" >}}

## **Beépített tulajdonságok módosítása**

A prezentációfájlok beépített tulajdonságainak módosítása ugyanolyan egyszerű, mint azok elérése. Egyszerűen hozzárendelhet egy karakterlánc értéket bármely kívánt tulajdonsághoz, és a tulajdonság értéke módosul. Az alábbi példában bemutattuk, hogyan lehet a prezentációfájl beépített dokumentumtulajdonságait módosítani.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-UpdatePresentationProperties-UpdatePresentationProperties.cpp" >}}

## **Egyéni prezentációtulajdonságok hozzáadása**

Az Aspose.Slides for C++ szintén lehetővé teszi a fejlesztők számára, hogy egyéni értékeket adjanak a prezentáció dokumentumtulajdonságaihoz. Az alábbi példa bemutatja, hogyan állítható be egyéni tulajdonság egy prezentációhoz.

``` cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Példányosítsa a Presentation osztályt
auto presentation = System::MakeObject<Presentation>();

// Dokumentumtulajdonságok lekérése
auto documentProperties = presentation->get_DocumentProperties();

// Egyéni tulajdonságok hozzáadása
documentProperties->idx_set(u"New Custom", ObjectExt::Box<int32_t>(12));
documentProperties->idx_set(u"My Name", ObjectExt::Box<String>(u"Mudassir"));
documentProperties->idx_set(u"Custom", ObjectExt::Box<int32_t>(124));

// Tulajdonság neve lekérése adott indexen
String getPropertyName = documentProperties->GetCustomPropertyName(2);

// Kiválasztott tulajdonság eltávolítása
documentProperties->RemoveCustomProperty(getPropertyName);

// Prezentáció mentése
presentation->Save(u"CustomDocumentProperties_out.pptx", SaveFormat::Pptx);
```

## **Egyéni tulajdonságok elérése és módosítása**

Az Aspose.Slides for C++ továbbá lehetővé teszi a fejlesztők számára, hogy hozzáférjenek az egyéni tulajdonságok értékeihez. Az alábbi példa bemutatja, hogyan érhetők el és módosíthatók a prezentáció egyéni tulajdonságai.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessModifyingProperties-AccessModifyingProperties.cpp" >}}

## **Ellenőrző nyelv beállítása**

Az Aspose.Slides a [LanguageId](https://reference.aspose.com/slides/hu/cpp/aspose.slides/baseportionformat/set_languageid/) tulajdonságot (amelyet a [PortionFormat](https://reference.aspose.com/slides/hu/cpp/aspose.slides/portionformat/) osztály biztosít) kínálja, hogy beállíthassa a helyesírás-ellenőrzés nyelvét egy PowerPoint dokumentumhoz. A helyesírás-ellenőrzés nyelve az a nyelv, amelynek helyesírását és nyelvtanát a PowerPoint ellenőrzi.

Ez a C++ kód megmutatja, hogyan állítható be a helyesírás-ellenőrzés nyelve egy PowerPointhoz:

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
// állítsa be a helyesírási nyelv azonosítóját

newPortion->set_Text(u"1。");
portions->Add(newPortion);
```

## **Alapértelmezett nyelv beállítása**

Ez a C++ kód megmutatja, hogyan állítható be az alapértelmezett nyelv egy teljes PowerPoint prezentációhoz:

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

// Hozzáad egy új téglalap alakzatot szöveggel
System::SharedPtr<IAutoShape> shp = pres->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 150.0f, 50.0f);
System::SharedPtr<ITextFrame> textFrame = shp->get_TextFrame();
textFrame->set_Text(u"New Text");

// Ellenőrzi az első rész nyelvét
System::Console::WriteLine(textFrame->get_Paragraph(0)->get_Portion(0)->get_PortionFormat()->get_LanguageId());
```

## **Élő példa**

Próbálja ki az [**Aspose.Slides Metadata**](https://products.aspose.app/slides/hu/metadata) online alkalmazást, hogy lássa, hogyan dolgozhat a dokumentumtulajdonságokkal az Aspose.Slides API-n keresztül:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/hu/metadata)

## **GYIK**

**Hogyan távolíthatok el egy beépített tulajdonságot egy prezentációból?**

A beépített tulajdonságok a prezentáció szerves részei, ezért nem távolíthatók el teljesen. Azonban megváltoztathatja az értékeket, vagy ha az adott tulajdonság megengedi, üresre állíthatja őket.

**Mi történik, ha már létező egyéni tulajdonságot adok hozzá?**

Ha már létező egyéni tulajdonságot ad hozzá, annak meglévő értéke felül lesz írva az újjal. Nem kell előre eltávolítani vagy ellenőrizni a tulajdonságot, mivel az Aspose.Slides automatikusan frissíti a tulajdonság értékét.

**Elérhetem a prezentáció tulajdonságait anélkül, hogy teljesen betölteném a prezentációt?**

Igen. Használja a [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) és ezután az [IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/) metódusokat a tárolt dokumentummetaadatok olvasásához anélkül, hogy [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) példányt hozna létre. Lásd a [Build a Lightweight Presentation Inventory](/slides/hu/cpp/examine-presentation/) cikket a teljes jelentési példához és a formátum-specifikus korlátozásokhoz.
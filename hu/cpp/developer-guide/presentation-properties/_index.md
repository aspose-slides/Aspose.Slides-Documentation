---
title: Prezentáció tulajdonságainak kezelése C++-ban
linktitle: Prezentáció tulajdonságai
type: docs
weight: 70
url: /hu/cpp/presentation-properties/
keywords:
- PowerPoint tulajdonságok
- prezentáció tulajdonságok
- dokumentumtulajdonságok
- beépített tulajdonságok
- egyéni tulajdonságok
- speciális tulajdonságok
- tulajdonságok kezelése
- tulajdonságok módosítása
- dokumentum metaadatok
- metaadatok szerkesztése
- helyesírás-ellenőrzési nyelv
- alapértelmezett nyelv
- PowerPoint
- OpenDocument
- prezentáció
- C++
- Aspose.Slides
description: "Mesteri szintű prezentációtulajdonságok kezelése az Aspose.Slides for C++ segítségével, és a keresés, márkaépítés és munkafolyamat egyszerűsítése a PowerPoint és OpenDocument fájljaiban."
---
## **Bevezetés**

Az Aspose.Slides két típusú dokumentumtulajdonságot támogat: **Beépített** és **Egyéni**. Mindkét tulajdonságtípus könnyen elérhető és kezelhető az Aspose.Slides API segítségével.

Az Aspose.Slides lehetővé teszi, hogy a prezentáció dokumentumtulajdonságokkal a [IDocumentProperties](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.i_document_properties) felületen keresztül dolgozzon. Ennek a felületnek egy példányát a [Presentation::get_DocumentProperties](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/get_documentproperties/) metódus adja vissza. Az alábbi példák bemutatják, hogyan olvashatók, módosíthatók és kezelhetők ezek a tulajdonságok.

{{% alert color="info" %}} 

Kérjük, vegye figyelembe, hogy a **Application** és **Producer** mezőkhöz nem állítható be érték, mivel az Aspose Ltd. és az Aspose.Slides for C++ x.x.x jelenik meg ezekben a mezőkben.

{{% /alert %}} 

## **Prezentációtulajdonságok kezelése**

A Microsoft PowerPoint lehetőséget biztosít néhány tulajdonság hozzáadására a prezentációfájlokhoz. Ezek a dokumentumtulajdonságok hasznos információkat tárolnak a dokumentumok (prezentációfájlok) mellett. Kétféle dokumentumtulajdonság létezik:

- Rendszer által definiált (Beépített) tulajdonságok
- Felhasználó által definiált (Egyéni) tulajdonságok

A **Beépített** tulajdonságok általános információkat tartalmaznak a dokumentumról, például a dokumentum címét, a szerző nevét, statisztikákat stb. A **Egyéni** tulajdonságok olyan **Név/Érték** párok, amelyeket a felhasználó definiál. Az Aspose.Slides for C++ használatával a fejlesztők hozzáférhetnek és módosíthatják a beépített és egyéni tulajdonságok értékeit egyaránt. A Microsoft PowerPoint 2007 lehetővé teszi a prezentációfájlok dokumentumtulajdonságainak kezelését. Ehhez csak kattintson az Office ikonra, majd válassza a **Előkészítés | Tulajdonságok | Speciális tulajdonságok** menüpontot a Microsoft PowerPoint 2007‑ben. A **Speciális tulajdonságok** menüpont kiválasztása után egy párbeszédablak jelenik meg, amelyben kezelheti a PowerPoint‑fájl dokumentumtulajdonságait. A **Tulajdonságok párbeszédablakban** számos lap található, például **Általános**, **Összefoglaló**, **Statisztika**, **Tartalom** és **Egyéni**. Ezek a lapok különböző típusú információk konfigurálását teszik lehetővé a PowerPoint‑fájlokhoz. Az **Egyéni** fül az egyéni tulajdonságok kezelésére szolgál.

## **Beépített tulajdonságok elérése**

Ezek a **IDocumentProperties** objektum által biztosított tulajdonságok: **Creator(Author)**, **Description**, **KeyWords**, **Created** (Létrehozás dátuma), **Modified** (Módosítás dátuma), **Printed** (Legutóbbi nyomtatás dátuma), **LastModifiedBy**, **Keywords**, **SharedDoc** (Közös‑használat több termelő között?), **PresentationFormat**, **Subject** és **Title**.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessBuiltinProperties-AccessBuiltinProperties.cpp" >}}

## **Beépített tulajdonságok módosítása**

A prezentációfájlok beépített tulajdonságainak módosítása ugyanolyan egyszerű, mint azok elérése. Egyszerűen hozzárendelhet egy karakterlánc‑értéket a kívánt tulajdonsághoz, és a tulajdonság értéke módosul. Az alább bemutatott példában azt mutatjuk be, hogyan módosíthatók a prezentációfájl beépített dokumentumtulajdonságai.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-UpdatePresentationProperties-UpdatePresentationProperties.cpp" >}}

## **Egyéni prezentációs tulajdonságok hozzáadása**

Az Aspose.Slides for C++ lehetővé teszi a fejlesztők számára, hogy egyéni értékeket adjanak a prezentáció dokumentumtulajdonságaihoz is. Az alább látható példa bemutatja, hogyan állíthatók be egyéni tulajdonságok egy prezentációhoz.

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

// A dokumentumtulajdonságok lekérése
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

Az Aspose.Slides for C++ szintén lehetővé teszi a fejlesztők számára, hogy elérjék az egyéni tulajdonságok értékeit. Az alábbi példa bemutatja, hogyan lehet elérni és módosítani ezeket az egyéni tulajdonságokat egy prezentációban.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessModifyingProperties-AccessModifyingProperties.cpp" >}}

## **Helyesírás-ellenőrzési nyelv beállítása**

Az Aspose.Slides a [LanguageId](https://reference.aspose.com/slides/hu/cpp/aspose.slides.baseportionformat/set_languageid/) tulajdonságot (amely a [PortionFormat](https://reference.aspose.com/slides/hu/cpp/aspose.slides/portionformat/) osztályon keresztül érhető el) biztosítja, hogy beállíthassa a helyesírás-ellenőrzési nyelvet egy PowerPoint‑dokumentumhoz. A helyesírás-ellenőrzési nyelv az a nyelv, amelynek helyesírását és nyelvtanát a PowerPoint ellenőrzi.

Ez a C++ kód megmutatja, hogyan állítható be a helyesírás-ellenőrzési nyelv egy PowerPoint fájlhoz:

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
// állítsa be a helyesírás-ellenőrzési nyelv azonosítóját

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

// Új téglalap alakzat hozzáadása szöveggel
System::SharedPtr<IAutoShape> shp = pres->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 150.0f, 50.0f);
System::SharedPtr<ITextFrame> textFrame = shp->get_TextFrame();
textFrame->set_Text(u"New Text");

// Checks the first portion language
System::Console::WriteLine(textFrame->get_Paragraph(0)->get_Portion(0)->get_PortionFormat()->get_LanguageId());
```

## **Élő példa**

Próbálja ki az **Aspose.Slides Metadata** online alkalmazást, hogy lássa, hogyan dolgozhat dokumentumtulajdonságokkal az Aspose.Slides API‑n keresztül:

[![PowerPoint metaadatok megtekintése és szerkesztése](slides-metadata.png)](https://products.aspose.app/slides/hu/metadata)

## ***GYIK**

### Hogyan távolíthatok el egy beépített tulajdonságot egy prezentációból?

A beépített tulajdonságok a prezentáció szerves részei, ezért nem távolíthatók el teljesen. Azonban megváltoztathatja értékeiket, vagy ha az adott tulajdonság megengedi, üresre állíthatja őket.

### Mi történik, ha olyan egyéni tulajdonságot adok hozzá, amely már létezik?

Ha már létező egyéni tulajdonságot ad hozzá, a meglévő érték felülíródik az újjal. Nem szükséges előre eltávolítani vagy ellenőrizni a tulajdonságot, mivel az Aspose.Slides automatikusan frissíti annak értékét.

### Hozzáférhetek a prezentáció tulajdonságaihoz anélkül, hogy teljesen betölteném a prezentációt?

Igen, a prezentáció tulajdonságaihoz anélkül is hozzáférhet, hogy teljesen betöltené a prezentációt, ha a [PresentationFactory](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentationfactory/) osztály **GetPresentationInfo** metódusát használja. Ezután a [IPresentationInfo](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipresentationinfo/) interfész **ReadDocumentProperties** metódusával olvashatja a tulajdonságokat hatékonyan, memóriát takarítva meg és a teljesítményt javítva.
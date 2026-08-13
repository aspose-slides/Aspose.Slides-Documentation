---
title: Hatékonyan egyesítse a prezentációkat C++-ban
linktitle: Prezentációk egyesítése
type: docs
weight: 40
url: /hu/cpp/merge-presentation/
keywords:
- PowerPoint egyesítése
- prezentációk egyesítése
- diák egyesítése
- PPT egyesítése
- PPTX egyesítése
- ODP egyesítése
- PowerPoint kombinálása
- prezentációk kombinálása
- diák kombinálása
- PPT kombinálása
- PPTX kombinálása
- ODP kombinálása
- C++
- Aspose.Slides
description: "Könnyedén egyesítheti a PowerPoint (PPT, PPTX) és OpenDocument (ODP) prezentációkat az Aspose.Slides for C++ segítségével, egyszerűsítve a munkafolyamatát."
---
## **Áttekintés**

Az Aspose.Slides lehetővé teszi, hogy prezentációkat egyesítsen, úgy, hogy diák másolatait az egyik prezentációból a másikba klónozza. Ez a cikk bemutatja, hogyan egyesítheti a teljes prezentációkat vagy kiválasztott diákat, hogyan használhat slide master‑t vagy egy adott elrendezést az egyesítés során, hogyan kezelje a különböző diaméretekkel rendelkező prezentációkat, és hogyan adja hozzá az egyesített diákat egy prezentációszekcióhoz. Emellett gyakorlati megjegyzéseket tárgyal az egyesített tartalommal kapcsolatban, beleértve az előadói jegyzeteket, megjegyzéseket, jelszóval védett forrásfájlokat és a szálhasználatot.

## **Prezentáció Egyesítése**

Amikor egy prezentációt egy másikba egyesít, gyakorlatilag a diák kombinálását végzi egyetlen prezentációban, hogy egy fájlt kapjon.

{{% alert title="Info" color="info" %}}
A legtöbb prezentációs program (PowerPoint vagy OpenOffice) nem rendelkezik olyan funkcióval, amely lehetővé tenné a felhasználók számára, hogy ilyen módon kombinálják a prezentációkat. 
[**Aspose.Slides for C++**](https://products.aspose.com/slides/hu/cpp/), azonban lehetővé teszi, hogy prezentációkat különböző módon egyesítsen. Egyesítheti a prezentációkat az összes alakjukkal, stílusukkal, szöveggel, formázással, megjegyzésekkel, animációkkal stb., anélkül, hogy a minőség vagy az adatok veszteségétől kellene tartania. 
**Lásd még**
[Clone Slides](https://docs.aspose.com/slides/hu/cpp/clone-slides/)*.* 
{{% /alert %}}

### **Mit lehet egyesíteni**

Az Aspose.Slides segítségével egyesíthet 
* teljes prezentációkat. A prezentációk összes diája egy prezentációba kerül.
* meghatározott diákat. A kiválasztott diák egy prezentációba kerülnek.
* prezentációkat egy formátumban (PPT‑t PPT‑re, PPTX‑t PPTX‑re stb.) és különböző formátumokban (PPT‑t PPTX‑re, PPTX‑t ODP‑re stb.) egymás felé. 

{{% alert title="Megjegyzés" color="warning" %}} 
A prezentációkon kívül az Aspose.Slides lehetővé teszi más fájlok egyesítését:
* [Images](https://products.aspose.com/slides/hu/cpp/merger/image-to-image/), például [JPG to JPG](https://products.aspose.com/slides/hu/cpp/merger/jpg-to-jpg/) vagy [PNG to PNG](https://products.aspose.com/slides/hu/cpp/merger/png-to-png/)
* Dokumentumok, mint például [PDF to PDF](https://products.aspose.com/slides/hu/cpp/merger/pdf-to-pdf/) vagy [HTML to HTML](https://products.aspose.com/slides/hu/cpp/merger/html-to-html/)
* Két különböző fájl, például [image to PDF](https://products.aspose.com/slides/hu/cpp/merger/image-to-pdf/), [JPG to PDF](https://products.aspose.com/slides/hu/cpp/merger/jpg-to-pdf/) vagy [TIFF to PDF](https://products.aspose.com/slides/hu/cpp/merger/tiff-to-pdf/). 
{{% /alert %}}

### **Egyesítési beállítások**

Alkalmazhat olyan beállításokat, amelyek meghatározzák, hogy  
* minden diasablon egyedi stílust kapjon a kimeneti prezentációban  
* egy adott stílus legyen alkalmazva az összes diához a kimeneti prezentációban.  

A prezentációk egyesítéséhez az Aspose.Slides a [AddClone](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.i_slide_collection#a0c84ed19c8b1730eb8010613a1c229ee) metódusokat (az [ISlideCollection](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.i_slide_collection) felületből) biztosítja. A `AddClone` metódusok különböző megvalósításai határozzák meg az egyesítési folyamat paramétereit. Minden Presentation objektumnak van egy [Slides](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.presentation#a9981b38f5a01d9fa5482f05b0a75974c) gyűjteménye, így a diák egyesítéséhez a kívánt prezentációból hívhatja meg a `AddClone` metódust.  

A `AddClone` metódus egy `ISlide` objektumot ad vissza, ami a forrásdia klónja. A kimeneti prezentáció diái egyszerűen a forrásdiák másolatai, ezért a kapott diákon (például stílusok, formázási opciók vagy elrendezések alkalmazása) módosíthat, anélkül hogy a forrásprezentációk megváltoznának. 

## **Prezentációk egyesítése** 

Az Aspose.Slides a [**AddClone (ISlide)**](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.i_slide_collection#a0c84ed19c8b1730eb8010613a1c229ee) metódust biztosítja, amely lehetővé teszi a diák egyesítését úgy, hogy azok megtartják saját elrendezésüket és stílusukat (alapértelmezett paraméterek).  

Ez a C++ kód bemutatja, hogyan egyesíthet prezentációkat:

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide);
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

## **Prezentációk egyesítése diák masterrel** 

Az Aspose.Slides a [**AddClone (ISlide, IMasterSlide, bool)**](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.i_slide_collection#a6b040e6b30f52ab4644fafdbc650b640) metódust biztosítja, amely lehetővé teszi a diák egyesítését egy slide master prezentációs sablon alkalmazásával. Így szükség esetén megváltoztathatja a kimeneti prezentáció diáinak stílusát.  

Ez a C++ kód demonstrálja a leírt műveletet:

```cpp
#include <DOM/IMasterSlideCollection.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide, pres2->get_Masters()->idx_get(0), true);
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

{{% alert title="Megjegyzés" color="warning" %}} 
A slide master elrendezése automatikusan kerül meghatározásra. Ha nem állapítható meg megfelelő elrendezés, és a `allowCloneMissingLayout` logikai paraméter a `AddClone` metódusban igazra van állítva, akkor a forrásdia elrendezése használatos. Ellenkező esetben a [PptxEditException](https://reference.aspose.com/slides/hu/cpp/namespace/aspose.slides#addf0421015ca476c0664c4f8f451877d) lesz dobva. 
{{% /alert %}}

Ha azt szeretné, hogy a kimeneti prezentáció diái más elrendezést kapjanak, használja a [AddClone (ISlide, ILayoutSlide)](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.i_slide_collection#a0ed5909b2d92555159007046760ff2f1) metódust az egyesítés során. 

## **Kiválasztott diák egyesítése prezentációkból** 

Az egyesített diák több prezentációból való kiválasztása hasznos egyedi diakészletek létrehozásához. Az Aspose.Slides C++ lehetővé teszi, hogy csak a szükséges diákat válassza ki és importálja. Az API megőrzi az eredeti diák formázását, elrendezését és dizájnját.  

A következő C++ kód új prezentációt hoz létre, címdiákat ad hozzá két másik prezentációból, és elmenti az eredményt egy fájlba:

```cpp
#include <DOM/ILayoutSlide.h>
#include <DOM/IPresentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/SlideLayoutType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

SmartPtr<ISlide> GetTitleSlide(SmartPtr<IPresentation> presentation)
{
    for (auto&& slide : presentation->get_Slides())
    {
        if (slide->get_LayoutSlide()->get_LayoutType() == SlideLayoutType::Title)
        {
            return slide;
        }
    }
    return nullptr;
}
```
```cpp
#include <DOM/IPresentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// A fenti kódban deklarálva.
SmartPtr<ISlide> GetTitleSlide(SmartPtr<IPresentation> presentation);

auto presentation = MakeObject<Presentation>();
auto presentation1 = MakeObject<Presentation>(u"presentation1.pptx");
auto presentation2 = MakeObject<Presentation>(u"presentation2.pptx");

presentation->get_Slides()->RemoveAt(0);

auto slide1 = GetTitleSlide(presentation1);

if (slide1 != nullptr)
    presentation->get_Slides()->AddClone(slide1);

auto slide2 = GetTitleSlide(presentation2);

if (slide2 != nullptr)
    presentation->get_Slides()->AddClone(slide2);

presentation->Save(u"combined.pptx", SaveFormat::Pptx);

presentation2->Dispose();
presentation1->Dispose();
presentation->Dispose();
```

## **Prezentációk egyesítése diaképlettel** 

Ez a C++ kód megmutatja, hogyan kombinálhat diák különböző prezentációkból, miközben a kívánt diaképletet alkalmazza rájuk, hogy egyetlen kimeneti prezentációt kapjon:

```cpp
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide, pres2->get_LayoutSlides()->idx_get(0));
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

## **Prezentációk egyesítése különböző diaméretekkel** 

{{% alert title="Megjegyzés" color="warning" %}} 
Nem lehet különböző diaméretekkel rendelkező prezentációkat egyesíteni. 
{{% /alert %}} 

Két különböző diaméretekkel rendelkező prezentáció egyesítéséhez az egyik prezentáció méretét át kell méretezni, hogy megegyezzen a másikéval.  

Ez a mintakód bemutatja a leírt műveletet:

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres1Size = pres1->get_SlideSize()->get_Size();

auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
pres2->get_SlideSize()->SetSize(pres1Size.get_Width(), pres1Size.get_Height(), SlideSizeScaleType::EnsureFit);

for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide);
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

## **Diák egyesítése prezentációszekcióba** 

Ez a C++ kód megmutatja, hogyan egyesíthet egy adott diát egy szekcióba a prezentációban:

```cpp
#include <DOM/ISectionCollection.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (int32_t index = 0; index < pres2->get_Slides()->get_Count(); index++)
{
    auto slide = pres2->get_Slides()->idx_get(index);
    pres1->get_Slides()->AddClone(slide, pres1->get_Sections()->idx_get(0));
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

A dia a szekció végére kerül hozzáadva. 

{{% alert title="Tipp" color="info" %}} 
Az Aspose egy [INGYENES Collage webalkalmazást](https://products.aspose.app/slides/hu/collage) biztosít. Ezzel az online szolgáltatással [JPG to JPG](https://products.aspose.app/slides/hu/collage/jpg) vagy PNG‑t PNG‑re képeket egyesíthet, [fotórácsokat](https://products.aspose.app/slides/hu/collage/photo-grid) hozhat létre, és így tovább. 
{{% /alert %}}

## **FAQ**

### Megmaradnak-e az előadói jegyzetek az egyesítés során?

Igen. A diák klónozása során az Aspose.Slides az összes diaelem, köztük a jegyzetek, formázás és animációk átvitelét is biztosítja.

### Átkerülnek-e a megjegyzések és a szerzőik?

A megjegyzések, mint a dia tartalmának része, a diával együtt másolódnak. A megjegyzés szerzőjelölők megmaradnak a kapott prezentációban megjegyzésobjektumokként.

### Mi a teendő, ha a forrásprezentáció jelszóval védett?

A prezentációt [meg kell nyitni a jelszóval](/slides/hu/cpp/password-protected-presentation/) a [LoadOptions::set_Password](https://reference.aspose.com/slides/hu/cpp/aspose.slides/loadoptions/set_password/) használatával; betöltés után a diák biztonságosan klónozhatók egy nem védett célfájlba (vagy egy védett fájlba is).

### Mennyire szálbiztos az egyesítési művelet?

Ne használja ugyanazt a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) példányt [több szálból](/slides/hu/cpp/multithreading/). Az ajánlott szabály: „egy dokumentum — egy szál”; különböző fájlok párhuzamosan feldolgozhatók külön szálakon.
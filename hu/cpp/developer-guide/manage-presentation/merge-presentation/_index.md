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
description: "Az Aspose.Slides for C++ segítségével egyszerűen egyesítheti a PowerPoint (PPT, PPTX) és OpenDocument (ODP) prezentációkat, egyszerűsítve a munkafolyamatát."
---
## **Áttekintés**

Az Aspose.Slides lehetővé teszi a prezentációk egyesítését úgy, hogy diák másolatát egy prezentációból a másikba helyezi. Ez a cikk bemutatja, hogyan lehet egyesíteni teljes prezentációkat vagy kiválasztott diákat, hogyan lehet egy dia master‑t vagy egy meghatározott elrendezést használni az egyesítés során, hogyan kezelhetők a különböző dia méretű prezentációk, és hogyan adhatók az egyesített diák egy prezentáció szekciójához. Emellett gyakorlati megjegyzéseket is tartalmaz az egyesített tartalommal kapcsolatban, beleértve a jegyzeteket, megjegyzéseket, jelszóval védett forrásfájlokat és a szálhasználatot.

## **Prezentációk egyesítése**

Amikor egy prezentációt egy másikba egyesít, gyakorlatilag a diák egyetlen prezentációban kerülnek össze, így egyetlen fájlt kapunk.

{{% alert title="Info" color="info" %}}
A legtöbb prezentációs program (PowerPoint vagy OpenOffice) nem rendelkezik olyan funkcióval, amely lehetővé tenné a prezentációk ilyen módon történő egyesítését. 
[**Aspose.Slides for C++**](https://products.aspose.com/slides/hu/cpp/), azonban különböző módokon teszi lehetővé a prezentációk egyesítését. A prezentációk összes alakzatát, stílusát, szövegét, formázását, megjegyzését, animációját stb. egyesítheti minőség- vagy adatvesztés nélkül. 
**Lásd még**
[Dia másolása](https://docs.aspose.com/slides/hu/cpp/clone-slides/)*.*
{{% /alert %}}

### **Mi lehet egyesíteni**

Az Aspose.Slides segítségével egyesíthet:

* teljes prezentációkat. Az összes dia a prezentációkból egy prezentációba kerül
* meghatározott diákat. A kiválasztott diák egy prezentációba kerülnek
* prezentációkat egy formátumban (PPT‑t PPT‑be, PPTX‑t PPTX‑be stb.) és különböző formátumokban (PPT‑t PPTX‑be, PPTX‑t ODP‑be stb.) egymásba.

{{% alert title="Note" color="warning" %}} 
A prezentációkon kívül az Aspose.Slides más fájltípusok egyesítését is lehetővé teszi:

* [Képek](https://products.aspose.com/slides/hu/cpp/merger/image-to-image/), például [JPG to JPG](https://products.aspose.com/slides/hu/cpp/merger/jpg-to-jpg/) vagy [PNG to PNG](https://products.aspose.com/slides/hu/cpp/merger/png-to-png/)
* Dokumentumok, például [PDF to PDF](https://products.aspose.com/slides/hu/cpp/merger/pdf-to-pdf/) vagy [HTML to HTML](https://products.aspose.com/slides/hu/cpp/merger/html-to-html/)
* Két különböző fájl, például [image to PDF](https://products.aspose.com/slides/hu/cpp/merger/image-to-pdf/), [JPG to PDF](https://products.aspose.com/slides/hu/cpp/merger/jpg-to-pdf/) vagy [TIFF to PDF](https://products.aspose.com/slides/hu/cpp/merger/tiff-to-pdf/).
{{% /alert %}}

### **Egyesítési beállítások**

Alkalmazhat beállításokat, amelyek meghatározzák, hogy

* minden dia az eredmény‑prezentációban egyedi stílust kapjon
* egy meghatározott stílus legyen használva az összes dián az eredmény‑prezentációban.

Az prezentációk egyesítéséhez az Aspose.Slides a [AddClone](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.i_slide_collection#a0c84ed19c8b1730eb8010613a1c229ee) metódusokat (az [ISlideCollection](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.i_slide_collection) interfészből) biztosítja. Számos `AddClone` metódusmegvalósítás létezik, amelyek a prezentációk egyesítési folyamatának paramétereit határozzák meg. Minden Presentation objektumnak van egy [Slides](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.presentation#a9981b38f5a01d9fa5482f05b0a75974c) gyűjteménye, így a kívánt prezentációból hívhatja a `AddClone` metódust.

A `AddClone` metódus egy `ISlide` objektumot ad vissza, amely a forrásdia klónja. A kimeneti prezentáció diái egyszerűen a forrásdiák másolatai. Ezért a létrejött diákon (például stílusok, formázási opciók vagy elrendezések alkalmazása) változtatásokat végezhet anélkül, hogy a forrás‑prezentációk érintettek lennének.

## **Prezentációk egyesítése**

Az Aspose.Slides a [**AddClone (ISlide)**](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.i_slide_collection#a0c84ed19c8b1730eb8010613a1c229ee) metódust biztosítja, amely lehetővé teszi a diák egyesítését úgy, hogy a diák megtartják saját elrendezésüket és stílusukat (alapértelmezett paraméterek).

Ez a C++ kód bemutatja a prezentációk egyesítését:

```cpp
auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide);
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

## **Prezentációk egyesítése dia masterrel**

Az Aspose.Slides a [**AddClone (ISlide, IMasterSlide, bool)**](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.i_slide_collection#a6b040e6b30f52ab4644fafdbc650b640) metódust biztosítja, amely lehetővé teszi a diák egyesítését, miközben egy dia‑master sablont alkalmaz. Így szükség esetén a kimeneti prezentáció diáinak stílusát módosíthatja.

Ez a C++ kód bemutatja a leírt műveletet:

```cpp
auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide, pres2->get_Masters()->idx_get(0), true);
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

{{% alert title="Note" color="warning" %}} 
A dia‑elrendezés a dia‑masterhez automatikusan kerül meghatározásra. Ha nem határozható meg megfelelő elrendezés, és az `allowCloneMissingLayout` logikai paraméter értéke `true`, a forrásdia elrendezése lesz használva. Egyébként a [PptxEditException](https://reference.aspose.com/slides/hu/cpp/namespace/aspose.slides#addf0421015ca476c0664c4f8f451877d) lesz dobva. 
{{% /alert %}}

Ha azt szeretné, hogy a kimeneti prezentáció diái egy másik elrendezést kapjanak, használja a [AddClone (ISlide, ILayoutSlide)](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.i_slide_collection#a0ed5909b2d92555159007046760ff2f1) metódust az egyesítés során.

## **Specifikus diák egyesítése prezentációkból**

Több prezentációból származó specifikus diák egyesítése hasznos egyedi diakészletek létrehozásához. Az Aspose.Slides C++ lehetővé teszi, hogy csak a szükséges diákot válassza ki és importálja. Az API megőrzi az eredeti diák formázását, elrendezését és megjelenését.

Az alábbi C++ kód új prezentációt hoz létre, hozzáadja a címdiákat két másik prezentációból, és elmenti az eredményt egy fájlba:

```cpp
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

## **Prezentációk egyesítése dia elrendezéssel**

Ez a C++ kód bemutatja, hogyan lehet a diákot prezentációkból egyesíteni úgy, hogy az Ön által preferált dia‑elrendezést alkalmazza, és egyetlen kimeneti prezentációt kapjon:

```cpp
auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide, pres2->get_LayoutSlides()->idx_get(0));
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

## **Prezentációk egyesítése eltérő dia méretekkel**

{{% alert title="Note" color="warning" %}} 
Nem lehet különböző dia méretű prezentációkat egyesíteni. 
{{% /alert %}}

Két, különböző dia mérettel rendelkező prezentáció egyesítéséhez az egyik prezentáció méretét át kell méretezni, hogy megegyezzen a másikéval.

Ez a minta kód szemlélteti a leírt műveletet:

```cpp
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

## **Diák egyesítése prezentáció szekciójába**

Ez a C++ kód bemutatja, hogyan lehet egy specifikus diát egy szekcióba egyesíteni egy prezentációban:

```cpp
auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (int32_t index = 0; index < pres2->get_Slides()->get_Count(); index++)
{
    auto slide = pres2->get_Slides()->idx_get(index);
    pres1->get_Slides()->AddClone(slide, pres1->get_Sections()->idx_get(0));
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

A dia a szekció végén kerül hozzáadásra.

{{% alert title="Tip" color="primary" %}}
Az Aspose egy [INGYENES Collage webalkalmazást](https://products.aspose.app/slides/hu/collage) biztosít. Ezzel az online szolgáltatással [JPG to JPG](https://products.aspose.app/slides/hu/collage/jpg) vagy PNG‑t PNG‑re képeket egyesíthet, [fotórácsokat](https://products.aspose.app/slides/hu/collage/photo-grid) hozhat létre, és így tovább. 
{{% /alert %}}

## **GYIK**

**Megmaradnak a jegyzetek az egyesítés során?**  
Igen. A diák klónozása során az Aspose.Slides minden diaelemet átvisz, beleértve a jegyzeteket, formázást és animációkat.

**A megjegyzések és szerzőik átkerülnek?**  
A megjegyzések, mint a dia tartalmának részét képező elemek, a diával együtt másolódnak. A szerzői címkék megmaradnak a megjegyzésobjektumokként a létrehozott prezentációban.

**Mi van, ha a forrás‑prezentáció jelszóval védett?**  
Ahol a forrás‑prezentáció jelszóval védett, azt [jelszóval kell megnyitni](/slides/hu/cpp/password-protected-presentation/) a [LoadOptions::set_Password](https://reference.aspose.com/slides/hu/cpp/aspose.slides/loadoptions/set_password/) használatával; a betöltés után a diák biztonságosan klónozhatók egy nem védett célfájlba (vagy egy védett fájlba is).

**Mennyire szálbiztos az egyesítési művelet?**  
Ne használja ugyanazt a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) példányt [több szálból](/slides/hu/cpp/multithreading/). Az ajánlott szabály: „egy dokumentum – egy szál”; különböző fájlok párhuzamosan feldolgozhatók külön szálakon.
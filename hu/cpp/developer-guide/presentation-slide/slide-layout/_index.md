---
title: Diaelrendezések alkalmazása vagy módosítása C++-ban
linktitle: Diaelrendezés
type: docs
weight: 60
url: /hu/cpp/slide-layout/
keywords:
- diaelrendezés
- tartalomelrendezés
- helyőrző
- prezentáció tervezés
- dia tervezés
- nem használt elrendezés
- lábléc láthatóság
- címdiára
- cím és tartalom
- szakaszcím
- két tartalom
- összehasonlítás
- csak cím
- üres elrendezés
- tartalom felirattal
- kép felirattal
- cím és függőleges szöveg
- függőleges cím és szöveg
- PowerPoint
- OpenDocument
- prezentáció
- C++
- Aspose.Slides
description: "Diaelrendezések alkalmazása, létrehozása és módosítása az Aspose.Slides for C++-ban, helyőrzők hozzáadása, nem használt elrendezések eltávolítása és a lábléc láthatóságának vezérlése."
---
## **Áttekintés**

Egy diaelrendezés meghatározza a helyőrzők, például a címek, szöveg, képek, diagramok és táblázatok pozícióit és formázását. Egy elrendezés alkalmazása konzisztens felépítést biztosít a diák számára, miközben lehetővé teszi, hogy minden dia a saját tartalmát tartalmazza.

A leggyakoribb elrendezések a következők:

- **Címdiára**: Cím- és alpárcímhelyőrzőket tartalmaz.
- **Cím és Tartalom**: Címhelyőrzőt és egy általános célú tartalomhelyőrzőt tartalmaz.
- **Üres**: Nem tartalmaz tartalomhelyőrzőket, és akkor hasznos, ha minden alakzatot manuálisan helyezünk el.

## **Ismerje meg az elrendezés öröklődését**

Egy prezentációnak három kapcsolódó szintje van:

1. A [master slide](https://reference.aspose.com/slides/hu/cpp/aspose.slides/imasterslide/) meghatározza a témát, a megosztott formázást, háttérképeket és közös objektumokat.
2. Egy [layout slide](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ilayoutslide/) egy masterhez tartozik és egy adott helyőrzőelrendezést definiál.
3. Egy [normal slide](https://reference.aspose.com/slides/hu/cpp/aspose.slides/islide/) egy elrendezést használ, és tárolja a diára beírt tartalmat.

Egy normál dia örökli a témát és a formázást az elrendezéséből, az elrendezés pedig a masterből. A normál dián közvetlenül beállított érték felülírja az örökölt értéket az adott szinten. Amikor egy normál diát létrehoznak, a helyőrző alakzatok a kiválasztott elrendezésből generálódnak, míg a helyőrzőkbe beírt tartalom a normál dia része.

Adjunk hozzá kötelező helyőrzőket egy elrendezéshez, mielőtt diákat hoznánk létre belőle. Egy későbbi helyőrző hozzáadása az elrendezéshez nem ad automatikusan hozzá megfelelő helyőrző alakzatot a már létező normál diákhoz.

Ez a kapcsolat két fontos következménnyel jár:

- Az örökölt formázás vagy a meglévő helyőrzők geometriai módosítása frissítheti az összes rá függő diát. Mielőtt egy már használt elrendezést szerkesztenénk, ellenőrizzük a függő diákat, és tekintsük át a kapott prezentációt.
- Egy olyan elrendezést, amelyet még egy dia is használ, nem lehet eltávolítani. Először rendeljük át a függő diákat egy másik elrendezésre, vagy csak a nem használt elrendezéseket távolítsuk el.

További információkért a hierarchia felső szintjéről lásd a [Slide Master](/slides/hu/cpp/slide-master/) oldalt.

A örökölt logók vagy dekoratív master alakzatok egy dián vagy egy megosztott elrendezésen keresztül történő elrejtéséhez lásd a [Control the Visibility of Master Graphics](/slides/hu/cpp/slide-master/) oldalt. A példa két diát hasonlít össze, amelyek ugyanazt a mastert használják.

## **Válassz és alkalmazz diaképet**

Használj elrendezéstípusokat, ha a prezentáció a PowerPoint szabványos elrendezésdefinícióit követi. Az elrendezésneveket a felhasználó szerkesztheti és lokalizálhatja, ezért a néven alapuló kiválasztás kevésbé megbízható, hacsak nem irányítod a forrás sablont.

Az alábbi példa az **Cím és Tartalom** elrendezést keresi az első masterben. Ha ez az elrendezés nem érhető el, szándékosan az **Üres** elrendezésre lép vissza. A második null ellenőrzés szükséges, mert egy prezentáció csak egyéni elrendezéseket tartalmazhat. A kiválasztott elrendezést ezután a [ISlide::set_LayoutSlide](https://reference.aspose.com/slides/hu/cpp/aspose.slides/islide/set_layoutslide/) metódussal alkalmazzák az első normál diára.

```cpp
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterLayoutSlideCollection.h>
#include <DOM/IMasterSlide.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
#include <system/exceptions.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");

auto layoutSlides = presentation->get_Master(0)->get_LayoutSlides();
auto targetLayout = layoutSlides->GetByType(SlideLayoutType::TitleAndObject);

if (targetLayout == nullptr)
{
    targetLayout = layoutSlides->GetByType(SlideLayoutType::Blank);
}

if (targetLayout == nullptr)
{
    throw InvalidOperationException(u"The first master does not contain a suitable layout slide.");
}

presentation->get_Slide(0)->set_LayoutSlide(targetLayout);
presentation->Save(u"output-with-new-layout.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Egy dia elrendezésének módosítása nem távolítja el a közvetlenül a diára hozzáadott egyszerű alakzatokat. Azonban a helyőrző pozíciók, az örökölt formázás és a meglévő helyőrzők és az új elrendezés közötti megfelelés megváltozhat, ezért ellenőrizd a kimenetet, ha lényegesen eltérő elrendezések között váltasz.

## **Adj hozzá egy elrendezésdiát**

A kiválasztás és a létrehozás külön műveletek. Az előző példa egy meglévő elrendezést választ ki; nem hoz létre újat. Az elrendezés létrehozásához hívd meg a [IMasterLayoutSlideCollection::Add](https://reference.aspose.com/slides/hu/cpp/aspose.slides/imasterlayoutslidecollection/add/) metódust a cél master elrendezésgyűjteményén.

Az alábbi példa mindig egy új **Cím és Tartalom** elrendezést ad hozzá `Report Title and Content` néven, majd egy normál diát hoz létre belőle. Az elrendezés neveinek egyedieknek kell lenniük a gyűjteményen belül.

```cpp
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterLayoutSlideCollection.h>
#include <DOM/IMasterSlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");

auto masterSlide = presentation->get_Master(0);
auto reportLayout = masterSlide->get_LayoutSlides()->Add(SlideLayoutType::TitleAndObject, u"Report Title and Content");
presentation->get_Slides()->AddEmptySlide(reportLayout);

presentation->Save(u"output-with-report-layout.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Csak akkor adj hozzá elrendezést, ha a sablon valóban egy további újrahasználható struktúrát igényel. Ha már létezik megfelelő elrendezés, válaszd ki és használd újra ahelyett, hogy duplikáltat hoznál létre.

## **Helyőrzők hozzáadása egy elrendezésdiához**

Az [ILayoutSlide::get_PlaceholderManager](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ilayoutslide/get_placeholdermanager/) metódus egy [ILayoutPlaceholderManager](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ilayoutplaceholdermanager/) objektumot biztosít helyőrzőalakzatok elrendezéshez való hozzáadásához.

| PowerPoint helyőrző               | `ILayoutPlaceholderManager` Metódus |
| --------------------------------- | ----------------------------------- |
| ![Tartalom](content.png)          | [`AddContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ilayoutplaceholdermanager/addcontentplaceholder/) |
| ![Tartalom (Függőleges)](contentV.png) | [`AddVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ilayoutplaceholdermanager/addverticalcontentplaceholder/) |
| ![Szöveg](text.png)               | [`AddTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ilayoutplaceholdermanager/addtextplaceholder/) |
| ![Szöveg (Függőleges)](textV.png) | [`AddVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ilayoutplaceholdermanager/addverticaltextplaceholder/) |
| ![Kép](picture.png)               | [`AddPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ilayoutplaceholdermanager/addpictureplaceholder/) |
| ![Diagram](chart.png)             | [`AddChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ilayoutplaceholdermanager/addchartplaceholder/) |
| ![Táblázat](table.png)            | [`AddTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ilayoutplaceholdermanager/addtableplaceholder/) |
| ![SmartArt](smartart.png)         | [`AddSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ilayoutplaceholdermanager/addsmartartplaceholder/) |
| ![Média](media.png)               | [`AddMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ilayoutplaceholdermanager/addmediaplaceholder/) |
| ![Online kép](onlineImage.png)    | [`AddOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ilayoutplaceholdermanager/addonlineimageplaceholder/) |

Az alábbi példa ellenőrzi, hogy létezik-e a **Üres** elrendezés, négy helyőrzőt ad hozzá, majd létrehozza a módosított elrendezést használó normál diát. A sorrend szándékos: a helyőrzőket a normál dia létrehozása előtt adjuk hozzá, így az Aspose.Slides a megfelelő helyőrzőalakzatokat generálhatja a diához.

```cpp
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/ILayoutPlaceholderManager.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
#include <system/exceptions.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto blankLayout = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

if (blankLayout == nullptr)
{
    throw InvalidOperationException(u"The presentation does not contain a Blank layout slide.");
}

auto placeholderManager = blankLayout->get_PlaceholderManager();
placeholderManager->AddContentPlaceholder(20.0f, 20.0f, 310.0f, 270.0f);
placeholderManager->AddVerticalTextPlaceholder(350.0f, 20.0f, 350.0f, 270.0f);
placeholderManager->AddChartPlaceholder(20.0f, 310.0f, 310.0f, 180.0f);
placeholderManager->AddTablePlaceholder(350.0f, 310.0f, 350.0f, 180.0f);

presentation->get_Slides()->AddEmptySlide(blankLayout);
presentation->Save(u"output-with-placeholders.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Az eredmény:

![A helyőrzők az elrendezésdián](add_placeholders.png)

{{% alert color="warning" title="Figyelmeztetés" %}}
Az örökölt formázás vagy a meglévő elrendezéshelyőrzők geometriájának módosítása befolyásolhatja a függő diákat. Az újonnan hozzáadott elrendezéshelyőrző nem töltődik be a már létező normál diákba. Tesztelj elrendezésváltozásokat egy másolaton, és ellenőrizd minden függő diát.
{{% /alert %}}

## **Nem használt elrendezésdiák eltávolítása**

Használd a [Compress::RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/hu/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) metódust a nem hivatkozott elrendezések eltávolításához. A metódus érintetlenül hagyja az még használatban lévő elrendezéseket.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <LowCode/Compress.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::LowCode;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");

Compress::RemoveUnusedLayoutSlides(presentation);
presentation->Save(u"output-without-unused-layouts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Egy konkrét elrendezés eltávolításához először használd a [get_HasDependingSlides](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ilayoutslide/get_hasdependingslides/) vagy a [GetDependingSlides](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ilayoutslide/getdependingslides/) metódust. Mielőtt meghívnád az [ILayoutSlide::Remove](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ilayoutslide/remove/) metódust, rendeld át a függő diákat. Egy használt elrendezés eltávolítása [PptxEditException](https://reference.aspose.com/slides/hu/cpp/aspose.slides/pptxeditexception/) kivételt dob.

## **Lábléc láthatóságának vezérlése egy elrendezésdián**

Egy elrendezésnek saját lábléca, diaszáma és dátum-idő helyőrzői vannak. Használd az [ILayoutSlide::get_HeaderFooterManager](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ilayoutslide/get_headerfootermanager/) metódust ezeknek a helyőrzőknek a kezelésére egy elrendezésen belül. Ez akkor hasznos, ha például a tartalomelrendezések láblécet jelenítenek meg, de a címelrendezések nem.

Az alábbi példa biztonságosan kiválaszt egy elrendezést, és láthatóvá teszi a láblécelemeket:

```cpp
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/ILayoutSlideHeaderFooterManager.h>
#include <DOM/Presentation.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
#include <system/exceptions.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");

auto layoutSlide = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::TitleAndObject);

if (layoutSlide == nullptr)
{
    layoutSlide = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);
}

if (layoutSlide == nullptr)
{
    throw InvalidOperationException(u"The presentation does not contain a suitable layout slide.");
}

auto headerFooterManager = layoutSlide->get_HeaderFooterManager();
headerFooterManager->SetFooterVisibility(true);
headerFooterManager->SetSlideNumberVisibility(true);
headerFooterManager->SetDateTimeVisibility(true);
headerFooterManager->SetFooterText(u"Footer text");
headerFooterManager->SetDateTimeText(u"Date and time text");

presentation->Save(u"output-with-layout-footers.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Lábléc láthatóságának vezérlése egy masteren és annak alárendelt elrendezésein**

A konzisztens láblécbeállítások alkalmazásához egy masterhierarchiában használd az [IMasterSlide::get_HeaderFooterManager](https://reference.aspose.com/slides/hu/cpp/aspose.slides/imasterslide/get_headerfootermanager/) metódust. Az [IMasterSlideHeaderFooterManager](https://reference.aspose.com/slides/hu/cpp/aspose.slides/imasterslideheaderfootermanager/) terjesztési metódusai a masteren, annak függő elrendezésdiáin és normál diáin működnek; nem csak egyetlen normál diát céloznak.

```cpp
#include <DOM/IMasterSlide.h>
#include <DOM/IMasterSlideHeaderFooterManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");

auto headerFooterManager = presentation->get_Master(0)->get_HeaderFooterManager();
headerFooterManager->SetFooterAndChildFootersVisibility(true);
headerFooterManager->SetSlideNumberAndChildSlideNumbersVisibility(true);
headerFooterManager->SetDateTimeAndChildDateTimesVisibility(true);
headerFooterManager->SetFooterAndChildFootersText(u"Footer text");
headerFooterManager->SetDateTimeAndChildDateTimesText(u"Date and time text");

presentation->Save(u"output-with-master-footers.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **GYIK**

**Mi a különbség a master dia és az elrendezésdia között?**

A master dia meghatározza a prezentáció témáját és a megosztott formázást. Az elrendezésdia egy masterhez tartozik, és egy újrahasználható helyőrzőelrendezést definiál. A normál diák ezeket az elrendezéseket használják és a dia-specifikus tartalmat tárolják.

**Másolhatok elrendezésdiát egy prezentációból egy másikba?**

Igen. Adj egy másolatot a célgyűjteményhez a [IGlobalLayoutSlideCollection::AddClone](https://reference.aspose.com/slides/hu/cpp/aspose.slides/igloballayoutslidecollection/addclone/) metódussal. Prezentációk közötti másolás esetén ellenőrizd a betűtípusokat, témákat, képeket és egyéb forrásokat, amelyeket a forrás elrendezés használ.

**Mi történik, ha módosítok egy már használatban lévő elrendezést?**

A függő diák öröklik az elrendezés változásait, kivéve ha felülírják az érintett formázást vagy objektumokat helyileg. A helyőrző geometriája és az örökölt stílusok ezért egyszerre sok dián változhatnak. Használd a [GetDependingSlides](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ilayoutslide/getdependingslides/) metódust az érintett diák azonosításához, mielőtt az elrendezést szerkesztenéd.

**Mi történik, ha eltávolítok egy még használt elrendezést?**

Az Aspose.Slides [PptxEditException](https://reference.aspose.com/slides/hu/cpp/aspose.slides/pptxeditexception/) hibát dob. Előbb rendeld át a függő diákat, vagy használd a [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/hu/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) metódust, hogy csak a nem hivatkozott elrendezéseket távolítsd el.
---
title: Diakiosztások alkalmazása vagy módosítása C++-ban
linktitle: Diaelrendezés
type: docs
weight: 60
url: /hu/cpp/slide-layout/
keywords:
- diaelrendezés
- tartalomelrendezés
- helykitöltő
- bemutató tervezés
- dia tervezés
- használaton kívüli elrendezés
- lábléc láthatóság
- cím dia
- cím és tartalom
- szakaszfejléc
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
- bemutató
- C++
- Aspose.Slides
description: "Alkalmazza, hozza létre és módosítsa a diaképeket az Aspose.Slides for C++-ban, adjon hozzá helykitöltőket, távolítson el használaton kívüli elrendezéseket, és szabályozza a lábléc láthatóságát."
---
## **Áttekintés**

A diavetítő elrendezés meghatározza a tartalékhelyek (pl. címek, szöveg, képek, diagramok és táblázatok) pozícióit és formázását. Egy elrendezés alkalmazásával a diák egységes struktúrát kapnak, miközben minden diára a saját tartalom kerül.

A leggyakoribb elrendezések a következők:

- **Címdiavet**: A cím és az alcím helykitöltőket tartalmaz.
- **Cím és Tartalom**: Egy cím helykitöltőt és egy általános célú tartalom helykitöltőt tartalmaz.
- **Üres**: Nem tartalmaz tartalom helykitöltőket, és akkor hasznos, ha minden alakzatot kézzel helyezünk el.

## **Az elrendezés öröklődésének megértése**

Egy bemutatónak három kapcsolódó szintje van:

1. A [master slide](https://reference.aspose.com/slides/hu/cpp/aspose.slides/imasterslide/) meghatározza a témát, a megosztott formázást, a háttereket és a közös objektumokat.
2. A [layout slide](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ilayoutslide/) egy mesterhez tartozik, és egy adott tartalékhely elrendezést definiál.
3. Egy [normal slide](https://reference.aspose.com/slides/hu/cpp/aspose.slides/islide/) egy elrendezést használ, és tárolja az adott diára bevitt tartalmat.

Egy normál dia örökli a témát és a formázást az elrendezéséből, az elrendezés pedig a mesterből. Egy normál dián közvetlenül beállított érték felülírja az örökölt értéket azon a szinten. Amikor egy normál dia létrejön, a helykitöltő alakzatok a kiválasztott elrendezésből generálódnak, míg a helykitöltőkbe bevitt tartalom a normál diához tartozik.

Adjon hozzá szükséges helykitöltőket egy elrendezéshez, mielőtt diák készülnek belőle. Később egy másik helykitöltő hozzáadása egy elrendezéshez nem ad automatikusan megfelelő helykitöltő alakzatot a meglévő normál diákhoz.

Ennek a kapcsolatnak két fontos következménye van:

- Az örökölt formázás vagy a meglévő helykitöltő geometria módosítása egy elrendezésen minden, attól függő diát frissíthet. Egy már használatban lévő elrendezés szerkesztése előtt ellenőrizze a függő diákat, és vizsgálja meg a keletkezett bemutatót.
- Egy elrendezés, amelyet még egy dia használ, nem távolítható el. Előbb rendelje át a függő diákat egy másik elrendezésre, vagy csak a nem használt elrendezéseket távolítsa el.

További információért a hierarchia legfelső szintjéről lásd a [Slide Master](/slides/hu/cpp/slide-master/) oldalt.

## **Elrendezés kiválasztása és alkalmazása**

Használjon elrendezés típust, ha a bemutató a szabványos PowerPoint elrendezésdefiníciókat követi. Az elrendezésneveket a felhasználó szerkesztheti, és lokalizálhatja, ezért a névre alapozott kiválasztás kevésbé megbízható, hacsak nem irányítja a forrás sablont.

A következő példa a **Title and Content** elrendezést keresi az első masteren. Ha ez az elrendezés nem érhető el, szándékosan az **Blank** elrendezésre tér vissza. A második null ellenőrzés szükséges, mert egy bemutató csak egyedi elrendezéseket tartalmazhat. A kiválasztott elrendezés ezután a [ISlide::set_LayoutSlide](https://reference.aspose.com/slides/hu/cpp/aspose.slides/islide/set_layoutslide/) metódussal kerül alkalmazásra az első normál diára.

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

Egy dia elrendezésének módosítása nem távolítja el a diára közvetlenül hozzáadott szokásos alakzatokat. Azonban a helykitöltő pozíciók, az örökölt formázás és a meglévő helykitöltők és az új elrendezés közti megfelelés megváltozhat, ezért ellenőrizze a kimenetet, amikor lényegesen különböző elrendezések között vált.

## **Elrendezés dia hozzáadása**

A kiválasztás és a létrehozás külön műveletek. Az előző példa egy meglévő elrendezést választ ki; azt nem hozza létre. Egy elrendezés létrehozásához hívja meg a [IMasterLayoutSlideCollection::Add](https://reference.aspose.com/slides/hu/cpp/aspose.slides/imasterlayoutslidecollection/add/) metódust a cél mester elrendezésgyűjteményén.

A következő példa mindig hozzáad egy új **Title and Content** elrendezést `Report Title and Content` néven, majd egy rá épülő normál diát ad hozzá. Az elrendezésneveknek egyedieknek kell lenniük a gyűjteményen belül.

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

Csak akkor adjon hozzá elrendezést, ha a sablon valóban szükséges egy újrahasználható szerkezetet. Ha már létezik megfelelő elrendezés, válassza ki és használja újra azt, a duplikátum létrehozása helyett.

## **Helykitöltők hozzáadása egy elrendezés diához**

Az [ILayoutSlide::get_PlaceholderManager](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ilayoutslide/get_placeholdermanager/) metódus egy [ILayoutPlaceholderManager](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ilayoutplaceholdermanager/) objektumot biztosít az elrendezéshez helykitöltő alakzatok hozzáadásához.

| PowerPoint helykitöltő            | `ILayoutPlaceholderManager` metódus |
| ----------------------------------- | ----------------------------------- |
| ![Tartalom](content.png)            | [`AddContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ilayoutplaceholdermanager/addcontentplaceholder/) |
| ![Tartalom (Függőlegesen)](contentV.png) | [`AddVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ilayoutplaceholdermanager/addverticalcontentplaceholder/) |
| ![Szöveg](text.png)                 | [`AddTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ilayoutplaceholdermanager/addtextplaceholder/) |
| ![Szöveg (Függőleges)](textV.png)   | [`AddVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ilayoutplaceholdermanager/addverticaltextplaceholder/) |
| ![Kép](picture.png)                 | [`AddPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ilayoutplaceholdermanager/addpictureplaceholder/) |
| ![Diagram](chart.png)               | [`AddChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ilayoutplaceholdermanager/addchartplaceholder/) |
| ![Táblázat](table.png)              | [`AddTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ilayoutplaceholdermanager/addtableplaceholder/) |
| ![SmartArt](smartart.png)           | [`AddSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ilayoutplaceholdermanager/addsmartartplaceholder/) |
| ![Media](media.png)                 | [`AddMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ilayoutplaceholdermanager/addmediaplaceholder/) |
| ![Online kép](onlineImage.png)      | [`AddOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ilayoutplaceholdermanager/addonlineimageplaceholder/) |

A következő példa ellenőrzi, hogy a **Blank** elrendezés létezik, négy helykitöltőt ad hozzá, majd létrehoz egy normál diát, amely a módosított elrendezést használja. A sorrend szándékos: a helykitöltők a normál dia létrehozása előtt kerülnek hozzáadásra, így az Aspose.Slides képes a megfelelő helykitöltő alakzatokat generálni azon a dián.

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

![A helykitöltők az elrendezés dián](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
Az örökölt formázás vagy a meglévő elrendezési helykitöltők geometriájának módosítása befolyásolhatja a függő diákat. Egy újonnan hozzáadott elrendezési helykitöltő nem kerül visszatöltésre a meglévő normál diákba. Tesztelje az elrendezés változtatásait a bemutató egy másolatán, és ellenőrizze minden függő diát.
{{% /alert %}}

## **Használaton kívüli elrendezés diák eltávolítása**

Használja a [Compress::RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/hu/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) metódust a olyan elrendezések eltávolítására, amelyeket egyetlen normál dia sem hivatkozik. A metódus érintetlenül hagyja az még használatban lévő elrendezéseket.

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

Az egy konkrét elrendezés eltávolításához először használja annak a [get_HasDependingSlides](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ilayoutslide/get_hasdependingslides/) vagy [GetDependingSlides](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ilayoutslide/getdependingslides/) metódusát. Mielőtt meghívná az [ILayoutSlide::Remove](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ilayoutslide/remove/) metódust, rendelje át a függő diákat. Egy használt elrendezés eltávolításának kísérlete [PptxEditException] kivételt eredményez.

## **Lábléc láthatóságának vezérlése egy elrendezés dián**

Egy elrendezésnek saját lábléca, dia-számláló és dátum-idő helykitöltői vannak. Használja az [ILayoutSlide::get_HeaderFooterManager](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ilayoutslide/get_headerfootermanager/) metódust ezen helykitöltők egy elrendezésre való szabályozásához. Ez hasznos például, ha a tartalom elrendezéseknek láblécet kell megjeleníteniük, de a cím elrendezéseknek nem.

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

## **Lábléc láthatóságának vezérlése egy mesteren és annak gyermek elrendezésein**

A következetes lábléc beállítások mesterhierarchiában történő alkalmazásához használja az [IMasterSlide::get_HeaderFooterManager](https://reference.aspose.com/slides/hu/cpp/aspose.slides/imasterslide/get_headerfootermanager/) metódust. Az [IMasterSlideHeaderFooterManager](https://reference.aspose.com/slides/hu/cpp/aspose.slides/imasterslideheaderfootermanager/) terjesztési metódusai a mesteren, annak függő elrendezés diákon és normál diákon működnek; nem egyetlen normál diára céloznak.

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

**Mi a különbség egy Master Slide és egy Layout Slide között?**

Egy master slide meghatározza a bemutató témáját és a megosztott formázást. Egy layout slide egy mesterhez tartozik, és egy újrahasználható helykitöltő elrendezést definiál. A normál diák ezeket az elrendezéseket használják, és a diára specifikus tartalmat tárolják.

**Másolhatok egy Layout Slide-ot egyik bemutatóból a másikba?**

Igen. A [IGlobalLayoutSlideCollection::AddClone](https://reference.aspose.com/slides/hu/cpp/aspose.slides/igloballayoutslidecollection/addclone/) metódussal adjon hozzá egy másolatot a célgyűjteményhez. Bemutatók közötti másoláskor ellenőrizze a betűtípusokat, témákat, képeket és egyéb forrásokat, amelyeket a forrás elrendezés használ.

**Mi történik, ha módosítok egy már használatban lévő elrendezést?**

A függő diák öröklik az elrendezés változásait, hacsak nem felülírják a helyi formázást vagy objektumokat. Így a helykitöltő geometria és az örökölt stílus sok dián egyszerre megváltozhat. Használja a [GetDependingSlides](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ilayoutslide/getdependingslides/) metódust a érintett diák azonosításához az elrendezés szerkesztése előtt.

**Mi történik, ha eltávolítok egy még használatban lévő elrendezést?**

Aspose.Slides [PptxEditException] kivételt dob. Előbb rendelje át a függő diákat, vagy használja a [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/hu/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) metódust a nem hivatkozott elrendezések eltávolításához.
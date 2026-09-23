---
title: Prezentáció nézet tulajdonságainak lekérdezése és frissítése C++-ban
linktitle: Nézet tulajdonságok
type: docs
weight: 80
url: /hu/cpp/presentation-view-properties/
keywords:
- nézet tulajdonságok
- normál nézet
- vázlat tartalom
- vázlat ikonok
- függőleges osztó rögzítése
- egyszemélyes nézet
- sáv állapota
- dimenzió méret
- automatikus igazítás
- alapértelmezett nagyítás
- PowerPoint
- OpenDocument
- prezentáció
- C++
- Aspose.Slides
description: "Fedezze fel az Aspose.Slides for C++ nézet tulajdonságait, hogy testre szabja a PPT, PPTX és ODP diák formátumát — módosítsa az elrendezéseket, nagyítási szinteket és megjelenítési beállításokat."
---
## **Bevezetés**

A normál nézet három tartalmi régióból áll: maga a dia, egy oldalsó tartalmi régió és egy alsó tartalmi régió. A különböző tartalmi régiók elhelyezésével kapcsolatos tulajdonságok. Ez az információ lehetővé teszi az alkalmazás számára, hogy elmentse a nézet állapotát a fájlba, hogy a megnyitáskor a nézet ugyanabban az állapotban legyen, mint amikor a prezentációt legutóbb elmentették.

A [IViewProperties::get_NormalViewProperties](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iviewproperties/get_normalviewproperties/) metódus került hozzáadásra, hogy hozzáférést biztosítson a prezentáció normál nézet tulajdonságaihoz.

Az [INormalViewProperties](https://reference.aspose.com/slides/hu/cpp/aspose.slides/inormalviewproperties/), az [INormalViewRestoredProperties](https://reference.aspose.com/slides/hu/cpp/aspose.slides/inormalviewrestoredproperties/) interfészek és azok leszármazottai, valamint a [SplitterBarStateType](https://reference.aspose.com/slides/hu/cpp/aspose.slides/splitterbarstatetype/) felsoroló típus (enum) hozzá lett adva.

## **Az INormalViewProperties**

A normál nézet tulajdonságait képviseli.

A **ShowOutlineIcons** tulajdonság megadja, hogy az alkalmazás megjelenítse-e az ikonokat, ha a normál nézet mód bármelyik tartalmi régiójában vázlat tartalmat jelenít meg.

A **SnapVerticalSplitter** tulajdonság meghatározza, hogy a vertikális osztó a mellékes régió elég kicsi mérete esetén minimalizált állapotba csapódjon‑e.

A **PreferSingleView** tulajdonság azt jelzi, hogy a felhasználó inkább egy teljesablakos egyetlen tartalom régiót szeretne a három tartalmi régióból álló szabványos normál nézet helyett. Ha engedélyezett, az alkalmazás dönthet úgy, hogy az egyik tartalmi régiót az egész ablakban jeleníti meg.

A **VerticalBarState** és **HorizontalBarState** tulajdonságok megadják, hogy a vízszintes vagy függőleges osztó sáv milyen állapotban legyen látható. A vízszintes osztó sáv elválasztja a diát a dia alatti tartalmi régiótól, a függőleges osztó sáv a diát az oldalsó tartalmi régiótól. Lehetséges értékek: **SplitterBarStateType.Minimized**, **SplitterBarStateType.Maximized** és **SplitterBarStateType.Restored**.

A **RestoredLeft** és **RestoredTop** tulajdonságok a normál nézet felső vagy oldalsó diaterületének méretét határozzák meg, amikor a **VerticalBarState** illetve **HorizontalBarState** értéke **SplitterBarStateType.Restored**.

## **Az INormalViewProperties visszaállítása**

Meghatározza a diaterület (szélesség, ha a RestoredTop elem alá van rendelve, magasság, ha a RestoredLeft elem alá van rendelve) méretét a normál nézetben, amikor a régió változó visszaállított mérettel rendelkezik (nem minimalizált és nem maximalizált).

A **DimensionSize** tulajdonság a diaterület méretét adja meg (szélesség, ha a restoredTop alá tartozik, magasság, ha a restoredLeft alá tartozik).

Az **AutoAdjust** tulajdonság meghatározza, hogy az oldalsó tartalmi régió mérete kompenzálja‑e az új méretet az alkalmazásban lévő nézetet tartalmazó ablak átméretezésekor.

Az alábbi példában látható, hogyan érheti el a **ViewProperties.NormalViewProperties** tulajdonságait egy prezentáció számára.

``` cpp
#include <DOM/INormalViewProperties.h>
#include <DOM/INormalViewRestoredProperties.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <DOM/SplitterBarStateType.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"demo.pptx");
pres->get_ViewProperties()->get_NormalViewProperties()->set_HorizontalBarState(SplitterBarStateType::Restored);
pres->get_ViewProperties()->get_NormalViewProperties()->set_VerticalBarState(SplitterBarStateType::Maximized);

// A prezentáció nézet tulajdonságainak visszaállítása
pres->get_ViewProperties()->get_NormalViewProperties()->get_RestoredTop()->set_AutoAdjust(true);
pres->get_ViewProperties()->get_NormalViewProperties()->get_RestoredTop()->set_DimensionSize(80.0f);
pres->get_ViewProperties()->get_NormalViewProperties()->set_ShowOutlineIcons(true);

pres->Save(u"presentation_normal_view_state.pptx", SaveFormat::Pptx);
```

## **Az alapértelmezett nagyítási érték beállítása**

Az Aspose.Slides for C++ most már támogatja az alapértelmezett nagyítási érték beállítását a prezentációhoz, így a prezentáció megnyitásakor a nagyítás már be van állítva. Ez a [ViewProperties](https://reference.aspose.com/slides/hu/cpp/aspose.slides/viewproperties/) beállításával valósítható meg. A dia nézet tulajdonságai, valamint a [get_NotesViewProperties](https://reference.aspose.com/slides/hu/cpp/aspose.slides/viewproperties/get_notesviewproperties/) programozottan beállíthatók. Ebben a témában egy példán keresztül megmutatjuk, hogyan állítható be a prezentáció View Properties az Aspose.Slides‑ben.

A nézetbeállítások beállításához kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztályból
1. Állítsa be a prezentáció View **Properties**‑ét
1. Írja a prezentációt PPTX fájlként

Az alább megadott példában beállítottuk a nagyítási értéket a dia nézethez és a jegyzet nézethez is.

``` cpp
#include <DOM/ICommonSlideViewProperties.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"demo.pptx");

// A prezentáció nézet tulajdonságainak beállítása
presentation->get_ViewProperties()->get_SlideViewProperties()->set_Scale(100); // Nagyítási érték százalékban a dia nézethez
presentation->get_ViewProperties()->get_NotesViewProperties()->set_Scale(100); // Nagyítási érték százalékban a jegyzet nézethez 

presentation->Save(u"Zoom_out.pptx", SaveFormat::Pptx);
```

## **A rácstávolság beállítása**

Használja a [Presentation::get_ViewProperties](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/get_viewproperties/) metódust a prezentáció szintű nézetbeállítások eléréséhez. Az [IViewProperties::get_GridSpacing](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iviewproperties/get_gridspacing/) és [IViewProperties::set_GridSpacing](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iviewproperties/set_gridspacing/) metódusok olvassák vagy módosítják a mögöttes szerkesztő rács intervallumát. Ez a beállítás a teljes prezentációra vonatkozik, nem egyetlen diára. A rácstávolság pontban van megadva, ahol 72 pont egy hüvelyknek felel meg. Pozitív értéket használjon, ahogy az API dokumentációja előírja.

Az alábbi példa megnyit egy létező `demo.pptx` fájlt, kiírja a jelenlegi rácstávolságot, beállít egy negyed hüvelykes intervallumot, majd elmenti az eredményt.

```cpp
#include <system/console.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"demo.pptx");
auto gridSpacing = presentation->get_ViewProperties()->get_GridSpacing();
System::Console::WriteLine(u"Current grid spacing: {0} points", gridSpacing);

presentation->get_ViewProperties()->set_GridSpacing(18.0f);
presentation->Save(u"grid-spacing.pptx", SaveFormat::Pptx);
```

A rács különbözik a [drawing guides](/slides/hu/cpp/drawing-guides/)-tól. A rácstávolság szabályos intervallumot szabályoz, míg a rajzsegédletek egyenként pozícionált vízszintes vagy függőleges igazítóvonalak. A rajzsegédletek hozzáadása, mozgatása vagy törlése nem változtatja meg a rácstávolságot.

Mind a rács, mind a rajzsegédletek szerkesztési segédeszközök. Nem jelennek meg dia tartalomként PDF‑ben, képekben, SVG‑ben vagy diavetítésben. A rácstávolság tárolása nem garantálja, hogy egy szerkesztő megjeleníti a rácsot: annak láthatósága a megtekintő vagy szerkesztő saját beállításaitól is függ.

## **Megjegyzések megjelenítése vagy elrejtése prezentáció megnyitásakor**

Használja a [Presentation::get_ViewProperties](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/get_viewproperties/) metódust a prezentáció szintű nézetbeállítások eléréséhez. Használja az [IViewProperties::get_ShowComments](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iviewproperties/get_showcomments/) és [IViewProperties::set_ShowComments](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iviewproperties/set_showcomments/) metódusokat a megjegyzések megjelenítésének tárolásához, amikor a prezentáció megnyílik a PowerPointban vagy egy másik kompatibilis szerkesztőben.

Ez a beállítás csak a tárolt nézetpreferenciát szabályozza. Nem ad hozzá, nem távolít el, nem szerkeszt vagy old meg megjegyzéseket. A megjegyzések elrejtése megőrzi azok tartalmát, szerzőit, pozícióit, válaszait és állapotait. Tekintse meg a [Presentation Comments](/slides/hu/cpp/presentation-comments/) oldalt a megjegyzéseken végzett műveletekhez.

Az alábbi példa egy meglévő, `comments.pptx` nevű fájlt igényel, amely tartalmaz megjegyzéseket. Kiírja a jelenlegi láthatósági beállítást, kéri a megjegyzések elrejtését, és új PPTX‑et ment anélkül, hogy bármely megjegyzést eltávolítana. Emellett a [IViewProperties::set_LastView](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iviewproperties/set_lastview/) metódust a [ViewType::SlideView](https://reference.aspose.com/slides/hu/cpp/aspose.slides/viewtype/)‑val kombinálva konfigurálja a kezdeti szerkesztő nézetet a megjegyzés láthatóságával együtt.

```cpp
#include <system/console.h>
#include <DOM/IViewProperties.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <ViewType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"comments.pptx");
auto showComments = presentation->get_ViewProperties()->get_ShowComments();
System::Console::WriteLine(u"Current comment visibility: {0}", showComments);

presentation->get_ViewProperties()->set_ShowComments(NullableBool::False);
presentation->get_ViewProperties()->set_LastView(ViewType::SlideView);
presentation->Save(u"comments-hidden.pptx", SaveFormat::Pptx);
```

Ez a beállítás nem határozza meg, hogy a megjegyzések szerepelnek‑e a PDF, HTML, kép, jegyzet vagy előadás exportokban. A megfelelő export‑specifikus opciókat külön kell beállítani.

## **GYIK**

**Miért nem látszik a rács, miután újra megnyitottam a prezentációt?**

A fájl tárolja a rácstávolságot, de a szerkesztő dönt arról, hogy a rács megjelenik‑e. Ellenőrizze a szerkesztő rács láthatósági beállításait.

**A rajzsegédletek törlése megváltoztatja a rács távolságát?**

Nem. A rajzsegédletek és a rácstávolság független beállítások. A segédletek törlése nem változtatja meg a tárolt rácsintervallumot.

**Beállíthatok különböző nézetbeállításokat a prezentáció különböző szakaszaihoz?**

A [Nézetbeállítások](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/get_viewproperties/) a prezentáció szintjén vannak definiálva ([Normál nézet](https://reference.aspose.com/slides/hu/cpp/aspose.slides/viewproperties/get_normalviewproperties/)/[Dia nézet](https://reference.aspose.com/slides/hu/cpp/aspose.slides/viewproperties/get_slideviewproperties/)), nem szakaszonként, így egyetlen paramétercsoport alkalmazásra kerül a dokumentum egészére a megnyitáskor.

**Előre definiálhatok különböző nézetállapotokat különböző felhasználók számára?**

Nem. A beállítások a fájlban tárolódnak és megosztottak. A megjelenítő alkalmazások figyelembe vehetik a felhasználói preferenciákat, de a fájl maga csak egy nézettulajdonság‑készletet tartalmaz.

**Készíthetek sablont előre definiált nézettulajdonságokkal, hogy az új prezentációk ugyanúgy nyíljanak meg?**

Igen. Mivel a [nézettulajdonságok](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/get_viewproperties/) a prezentáció szintjén vannak tárolva, beágyazhatja őket egy sablonba, és onnan új dokumentumokat hozhat létre ugyanazzal a kezdeti nézetkonfigurációval.
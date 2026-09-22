---
title: Prezentáció nézet-tulajdonságainak lekérdezése és frissítése C++-ban
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
- egyes nézet
- sáv állapot
- dimenzió méret
- automatikus igazítás
- alapértelmezett nagyítás
- PowerPoint
- OpenDocument
- prezentáció
- C++
- Aspose.Slides
description: "Fedezze fel az Aspose.Slides for C++ nézet-tulajdonságait a PPT, PPTX és ODP diáknézetek testreszabásához - állítson be elrendezéseket, nagyítási szinteket és megjelenítési beállításokat."
---
## **Bevezetés**

A normál nézet három tartalmi területből áll: magából a diából, egy oldalsó tartalmi területből és egy alsó tartalmi területből. A különböző tartalmi területek pozicionálására vonatkozó tulajdonságok. Ez az információ lehetővé teszi az alkalmazás számára, hogy elmentse a nézet állapotát a fájlba, így újbóli megnyitáskor a nézet ugyanabban az állapotban lesz, mint amikor a bemutatót utoljára mentették.

A [IViewProperties::get_NormalViewProperties](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iviewproperties/get_normalviewproperties/) metódust hozzáadták, hogy hozzáférést biztosítson a bemutató normál nézetének tulajdonságaihoz.  

[INormalViewProperties](https://reference.aspose.com/slides/hu/cpp/aspose.slides/inormalviewproperties/), [INormalViewRestoredProperties](https://reference.aspose.com/slides/hu/cpp/aspose.slides/inormalviewrestoredproperties/) interfészek és azok leszármazottjai, a [SplitterBarStateType](https://reference.aspose.com/slides/hu/cpp/aspose.slides/splitterbarstatetype/) enum hozzáadva.

## **Az INormalViewProperties**

A normál nézet tulajdonságait képviseli.

A **ShowOutlineIcons** tulajdonság meghatározza, hogy az alkalmazás ikonokat jelenítsen-e, ha a vázlat tartalmat a normál nézet bármelyik tartalmi régiójában jeleníti meg.

A **SnapVerticalSplitter** tulajdonság meghatározza, hogy a függőleges osztó minimális állapotba ugrik-e, amikor az oldalsó régió elég kicsi.

A **PreferSingleView** tulajdonság azt jelzi, hogy a felhasználó a teljes ablakos egyetlen tartalmi régiót preferálja-e a három tartalmi régióval rendelkező standard normál nézet helyett. Ha engedélyezett, az alkalmazás egy tartalmi régiót az egész ablakban jeleníthet meg.

A **VerticalBarState** és a **HorizontalBarState** tulajdonságok megadják, hogy a vízszintes vagy függőleges elválasztó sáv milyen állapotban jelenjen meg. A vízszintes elválasztó sáv elválasztja a diát a diák alatti tartalmi régiótól, a függőleges elválasztó sáv elválasztja a diát az oldalsó tartalmi régiótól. Lehetséges értékek: **SplitterBarStateType.Minimized, SplitterBarStateType.Maximized** és **SplitterBarStateType.Restored**.

A **RestoredLeft** és a **RestoredTop** tulajdonságok megadják a normál nézet felső vagy oldalsó diaterületének méretét, amikor a **VerticalBarState** és a **HorizontalBarState** értékeként **SplitterBarStateType.Restored** van alkalmazva.

## **Az INormalViewProperties helyreállításáról**

Meghatározza a diaterület méretét (szélesség, ha a RestoredTop gyermekeként van, magasság, ha a RestoredLeft gyermekeként) a normál nézetben, amikor a terület változó helyreállított mérettel rendelkezik (sem minimalizált, sem maximalizált).

A **DimensionSize** tulajdonság megadja a diaterület méretét (szélesség, ha a restoredTop gyermekeként, magasság, ha a restoredLeft gyermekeként).

A **AutoAdjust** tulajdonság meghatározza, hogy a oldalsó tartalmi régió mérete kompenzálja-e az új méretet, amikor az alkalmazáson belüli nézetet tartalmazó ablakot átméretezik.

Az alább bemutatott példa megmutatja, hogyan lehet elérni a **ViewProperties.NormalViewProperties** tulajdonságait egy bemutatóhoz.

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

// A prezentáció nézet-tulajdonságainak helyreállítása
pres->get_ViewProperties()->get_NormalViewProperties()->get_RestoredTop()->set_AutoAdjust(true);
pres->get_ViewProperties()->get_NormalViewProperties()->get_RestoredTop()->set_DimensionSize(80.0f);
pres->get_ViewProperties()->get_NormalViewProperties()->set_ShowOutlineIcons(true);

pres->Save(u"presentation_normal_view_state.pptx", SaveFormat::Pptx);
```

## **Az alapértelmezett nagyítási érték beállítása**

Az Aspose.Slides for C++ most már támogatja az alapértelmezett nagyítási érték beállítását a bemutatóhoz, így a bemutató megnyitásakor a nagyítás már be van állítva. Ez a [ViewProperties](https://reference.aspose.com/slides/hu/cpp/aspose.slides/viewproperties/) beállításával érhető el egy bemutatóban. A dianézet tulajdonságai valamint a [get_NotesViewProperties](https://reference.aspose.com/slides/hu/cpp/aspose.slides/viewproperties/get_notesviewproperties/) programozottan beállíthatók. Ebben a témában egy példán keresztül láthatjuk, hogyan állítható be a bemutató View Properties az Aspose.Slides-ben.

A nézet tulajdonságainak beállításához kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztályból.
2. Állítsa be a Presentation nézetének [Properties](https://reference.aspose.com/slides/hu/cpp/aspose.slides/viewproperties/) tulajdonságait.
3. Írja ki a bemutatót PPTX fájlként.

Az alább bemutatott példában beállítottuk a nagyítási értéket a dianézethez és a jegyzet nézethez is.

``` cpp
#include <DOM/ICommonSlideViewProperties.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"demo.pptx");

// A prezentáció nézet-tulajdonságainak beállítása
presentation->get_ViewProperties()->get_SlideViewProperties()->set_Scale(100); // Nagyítási érték százalékban a dianézethez
presentation->get_ViewProperties()->get_NotesViewProperties()->set_Scale(100); // Nagyítási érték százalékban a jegyzetnézethez 

presentation->Save(u"Zoom_out.pptx", SaveFormat::Pptx);
```

## **A rácstávolság beállítása**

Használja a [Presentation::get_ViewProperties](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/get_viewproperties/) metódust a teljes bemutatóra vonatkozó nézetbeállítások eléréséhez. Az [IViewProperties::get_GridSpacing](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iviewproperties/get_gridspacing/) és az [IViewProperties::set_GridSpacing](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iviewproperties/set_gridspacing/) metódusok olvassák vagy módosítják az alapul szolgáló szerkesztői rács intervallumát. Ez a beállítás a teljes bemutatóra vonatkozik, nem egyetlen diára. A rácstávolság pontban van megadva, ahol 72 pont egy hüvelyknek felel meg. Használjon pozitív értéket, ahogy az API dokumentációja előírja.

Az alábbi példa megnyit egy meglévő `demo.pptx` fájlt, kiírja a jelenlegi rácstávolságot, egy negyed hüvelykes intervallumot állít be, majd elmenti az eredményt.

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

A rács különbözik a [drawing guides](/slides/hu/cpp/drawing-guides/) elemtől. A rácstávolság egy szabályos intervallumot szabályoz, míg a rajzolási segédvonalak egyenként elhelyezett vízszintes vagy függőleges igazítási vonalak. A segédvonalak hozzáadása, mozgatása vagy törlése nem változtatja meg a rácstávolságot.

A rács és a rajzolási segédvonalak egyaránt szerkesztési segédeszközök. Nem jelennek meg dia tartalomként PDF-ben, képekben, SVG-ben vagy a diavetítésben. A rácstávolság tárolása nem garantálja, hogy egy szerkesztő megjeleníti a rácsot: annak láthatósága a megjelenítő vagy szerkesztő beállításaitól is függ.

## **GYIK**

**Miért nem látható a rács, miután újra megnyitottam a bemutatót?**  
A fájl tárolja a rácstávolságot, de a szerkesztő szabályozza, hogy a rács megjelenik-e. Ellenőrizze a szerkesztő rács láthatósági beállításait.

**Megváltozik a rácstávolság a rajzolási segédvonalak törlésekor?**  
Nem. A rajzolási segédvonalak és a rácstávolság független beállítások. A segédvonalak törlése nem változtatja meg a tárolt rácsintervallumot.

**Beállíthatok különböző nézetbeállításokat a bemutató különböző szakaszaihoz?**  
A [Nézet beállítások](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/get_viewproperties/) a bemutató szintjén vannak definiálva (Normál nézet/Dianézet), nem szakaszonként, így egyetlen paraméterkészlet érvényes az egész dokumentumra a megnyitáskor.

**Előre definiálhatok különböző nézetállapotokat különböző felhasználók számára?**  
Nem. A beállítások a fájlban vannak tárolva és megosztottak. A megjelenítő alkalmazások tiszteletben tarthatják a felhasználói preferenciákat, de a fájl önmagában egyetlen nézettulajdonság‑készletet tartalmaz.

**Elkészíthetek sablont előre meghatározott nézettulajdonságokkal, hogy az új bemutatók ugyanúgy nyíljanak meg?**  
Igen. Mivel a [view properties](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/get_viewproperties/) a bemutató szintjén tárolódik, beágyazhatja őket egy sablonba, és új dokumentumokat hozhat létre belőle azonos kezdeti nézetkonfigurációval.
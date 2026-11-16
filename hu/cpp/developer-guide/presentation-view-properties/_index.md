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
- függőleges elválasztó befogása
- egyetlen nézet
- sáv állapot
- dimenzió méret
- automatikus igazítás
- alapértelmezett nagyítás
- PowerPoint
- OpenDocument
- prezentáció
- C++
- Aspose.Slides
description: "Az Aspose.Slides for C++ segítségével konfigurálhatja a normál nézet elrendezését, a dia és a jegyzetek nagyítását, a rácstávolságot, valamint a megjegyzések láthatóságát PowerPoint-prezentációkban."
---
## **Bevezetés**

A PowerPoint normál nézetében a dia egy oldalsó ablakkal jelenik meg, amely bélyegképeket vagy vázlatot tartalmaz, és alatta egy jegyzet ablakkal. Az Aspose.Slides for C++ a prezentáció mentett szerkesztési beállításait teszi elérhetővé a [Presentation::get_ViewProperties](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_viewproperties/). Ezek közé tartozik az ablaktábla elrendezése, a nagyítási szintek, a rácstávolság és a megjegyzések láthatósága.

## **Az INormalViewProperties-ról**

Használja a [get_NormalViewProperties](https://reference.aspose.com/slides/cpp/aspose.slides/iviewproperties/get_normalviewproperties/) a [INormalViewProperties](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/) felület eléréséhez. A [set_ShowOutlineIcons](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/set_showoutlineicons/) szabályozza, hogy ikonok jelenjenek-e meg a diacímek mellett a vázlatban. A [set_SnapVerticalSplitter](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/set_snapverticalsplitter/) lehetővé teszi, hogy az oldalsó ablaktábla a minimalizált állapotába csapódjon, amikor a felhasználó szűkíti. A [set_PreferSingleView](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/set_prefersingleview/) azt jelzi, hogy egy ablaktáblát szeretnénk megjeleníteni a teljes ablakban.

A [set_VerticalBarState](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/set_verticalbarstate/) a oldalsó ablaktábla és a dia közötti elválasztót szabályozza. A [set_HorizontalBarState](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/set_horizontalbarstate/) a jegyzetablak feletti elválasztót szabályozza. Mindkettő egy [SplitterBarStateType](https://reference.aspose.com/slides/cpp/aspose.slides/splitterbarstatetype/) értéket fogad el, amely lehet `Minimized`, `Maximized` vagy `Restored`.

## **Az INormalViewProperties helyreállításáról**

Amikor egy elválasztó helyreáll, a [get_RestoredLeft](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/get_restoredleft/) a side pane mentett méretét adja meg, és a [get_RestoredTop](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/get_restoredtop/) a felső diaterület mentett méretét adja meg. Mindkettő a [INormalViewRestoredProperties](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewrestoredproperties/) felületet teszi elérhetővé. Ennek a [set_DimensionSize](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewrestoredproperties/set_dimensionsize/) metódusa 0‑tól 100‑ig terjedő százalékot fogad, a [set_AutoAdjust](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewrestoredproperties/set_autoadjust/) pedig szabályozza, hogy a szerkesztő a méretet automatikusan állítsa‑e a ablak méretezésekor.

Ez a példa egy meglévő prezentációt frissít. Helyreállítja a vízszintes elválasztót, a [get_RestoredTop](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/get_restoredtop/) által biztosított felső diaterület méretét 80 %-ra állítja automatikus igazítással, és maximalizálja a függőleges elválasztót. Emellett engedélyezi a vázlatikonokat a [set_ShowOutlineIcons](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/set_showoutlineicons/) segítségével a vázlat nézethez.

```cpp
#include <DOM/INormalViewProperties.h>
#include <DOM/INormalViewRestoredProperties.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <DOM/SplitterBarStateType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"demo.pptx");

auto normalView = presentation->get_ViewProperties()->get_NormalViewProperties();
normalView->set_HorizontalBarState(SplitterBarStateType::Restored);
normalView->set_VerticalBarState(SplitterBarStateType::Maximized);
auto restoredTop = normalView->get_RestoredTop();
restoredTop->set_AutoAdjust(true);
restoredTop->set_DimensionSize(80.0f);
normalView->set_ShowOutlineIcons(true);

presentation->Save(u"presentation_normal_view_state.pptx", SaveFormat::Pptx);
```

## **Az alapértelmezett nagyítási érték beállítása**

A [get_SlideViewProperties](https://reference.aspose.com/slides/cpp/aspose.slides/iviewproperties/get_slideviewproperties/) és a [get_NotesViewProperties](https://reference.aspose.com/slides/cpp/aspose.slides/iviewproperties/get_notesviewproperties/) a szerkesztő számára független nagyítási beállításokat tárolnak. Ezek a beállítások nem befolyásolják a dia méreteit, a diavetítés lejátszását vagy a képexport felbontását.

Ez a példa megnyit egy meglévő prezentációt, és engedélyezi az automatikus méretezést a [set_VariableScale](https://reference.aspose.com/slides/cpp/aspose.slides/icommonslideviewproperties/set_variablescale/) segítségével, hogy a dia illeszkedjen a szerkesztőablakhoz. A jegyzetoldalra letiltja az automatikus méretezést, és a [set_Scale](https://reference.aspose.com/slides/cpp/aspose.slides/icommonslideviewproperties/set_scale/) 80 %-os rögzített nagyítást állít be.

```cpp
#include <DOM/ICommonSlideViewProperties.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"demo.pptx");

auto viewProperties = presentation->get_ViewProperties();
viewProperties->get_SlideViewProperties()->set_VariableScale(true);
auto notesView = viewProperties->get_NotesViewProperties();
notesView->set_VariableScale(false);
notesView->set_Scale(80);

presentation->Save(u"zoom.pptx", SaveFormat::Pptx);
```

## **A rácstávolság beállítása**

A [set_GridSpacing](https://reference.aspose.com/slides/cpp/aspose.slides/iviewproperties/set_gridspacing/) beállítja az szerkesztési rácsvonalak közti távolságot a teljes prezentációban. Pozitív értéket vár pontban, 1 hüvelyk = 72 pont. Ez a példa kiírja a jelenlegi távolságot egy meglévő prezentációban, és egy negyed hüvelykes raszt menti el a 18 pontos intervallum beállításával.

```cpp
#include <system/console.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"demo.pptx");

auto viewProperties = presentation->get_ViewProperties();
auto gridSpacing = viewProperties->get_GridSpacing();
System::Console::WriteLine(u"Current grid spacing: {0} points", gridSpacing);

viewProperties->set_GridSpacing(18.0f);

presentation->Save(u"grid-spacing.pptx", SaveFormat::Pptx);
```

A rács egy állandó intervallumban ismétlődik. A [Drawing guides](/slides/hu/cpp/drawing-guides/) egyedi vízszintes vagy függőleges pozíciókat jelölnek. Mindkettő szerkesztési segédeszköz, és csak azokat megjelenítő szerkesztőkben látható. A diavetítések és a PDF‑, kép‑ vagy SVG‑exportok kihagyják őket.

## **Megjegyzések megjelenítése vagy elrejtése prezentáció megnyitásakor**

A [set_ShowComments](https://reference.aspose.com/slides/cpp/aspose.slides/iviewproperties/set_showcomments/) egy beállítást tárol, amelyet a kompatibilis szerkesztők a prezentáció megnyitásakor alkalmaznak. Egy megjegyzésekkel rendelkező meglévő prezentáció esetén ez a példa kiírja a jelenlegi beállítást, és egy olyan másolatot ment, ahol a megjegyzések rejtve vannak. Emellett meghívja a [set_LastView](https://reference.aspose.com/slides/cpp/aspose.slides/iviewproperties/set_lastview/) metódust a [ViewType::SlideView](https://reference.aspose.com/slides/cpp/aspose.slides/viewtype/) értékkel, hogy a másolat dia nézetben nyíljon meg.

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

auto viewProperties = presentation->get_ViewProperties();
auto showComments = viewProperties->get_ShowComments();
System::Console::WriteLine(u"Current comment visibility: {0}", showComments);

viewProperties->set_ShowComments(NullableBool::False);
viewProperties->set_LastView(ViewType::SlideView);

presentation->Save(u"comments-hidden.pptx", SaveFormat::Pptx);
```

A megjegyzések elrejtése megőrzi azok szövegét, szerzőjét, pozícióját, válaszait és állapotát. A megjegyzések módosításához lásd a [Prezentációs megjegyzések](/slides/hu/cpp/presentation-comments/). Az export beállítások határozzák meg, hogy a megjegyzések megjelenjenek‑e PDF‑ben, HTML‑ben, képekben, jegyzetekben vagy szórólapokban.

## **GYIK**

**Miért van rejtve a rács, amikor újra megnyitom a prezentációt?**  
A prezentáció tárolja a rács intervallumát. A rács megtekintéséhez engedélyezze a rács láthatóságát a szerkesztőben.

**A rajzolósegédek törlése megváltoztatja a rácstávolságot?**  
Nem. Egy segéd hozzáadása, áthelyezése vagy törlése nem változtatja meg a rács intervallumát.

**Különböző szekciók a prezentációban különböző nézetbeállításokkal rendelkezhetnek?**  
Nem. A [Presentation::get_ViewProperties](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_viewproperties/) a teljes prezentációra vonatkozik.

**Menthetek különböző nézetbeállításokat különböző felhasználókhoz?**  
A fájl mindenki számára egyetlen nézetbeállítási halmazt tárol. Egy szerkesztő további helyi felhasználói preferenciákat is alkalmazhat.

**Menthetek nézetbeállításokat egy sablonba?**  
Igen. A sablonból létrehozott prezentációk öröklik a mentett nézetbeállításokat.
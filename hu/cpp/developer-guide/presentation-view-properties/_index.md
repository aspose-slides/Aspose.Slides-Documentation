---
title: Prezentáció Nézetpropikcióinak lekérése és frissítése C++-ban
linktitle: Nézetpropikciók
type: docs
weight: 80
url: /hu/cpp/presentation-view-properties/
keywords:
- nézetpropikciók
- normál nézet
- vázlat tartalom
- vázlat ikonok
- függőleges elválasztó rögzítése
- egyes nézet
- sáv állapota
- dimenzió mérete
- automatikus igazítás
- alapértelmezett nagyítás
- PowerPoint
- OpenDocument
- prezentáció
- C++
- Aspose.Slides
description: "Fedezze fel az Aspose.Slides for C++ nézetpropikcióit, hogy testreszabja a PPT, PPTX és ODP diák formátumait – állítsa be az elrendezéseket, a nagyítási szinteket és a megjelenítési beállításokat."
---
## **Bevezetés**

A normál nézet három tartalmi területből áll: a dia önmagából, egy oldalsó tartalmi területből és egy alsó tartalmi területből. A különböző tartalmi területek elhelyezésére vonatkozó tulajdonságok. Ez az információ lehetővé teszi az alkalmazás számára, hogy a nézetállapotot a fájlba mentse, így amikor újra megnyitják, a nézet ugyanabban az állapotban lesz, mint amikor a bemutató utoljára mentésre került.

A [IViewProperties::get_NormalViewProperties](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iviewproperties/get_normalviewproperties/) metódus hozzá lett adva, hogy hozzáférést biztosítson a prezentáció normál nézet tulajdonságaihoz. 

Az [INormalViewProperties](https://reference.aspose.com/slides/hu/cpp/aspose.slides/inormalviewproperties/), az [INormalViewRestoredProperties](https://reference.aspose.com/slides/hu/cpp/aspose.slides/inormalviewrestoredproperties/) interfészek és azok leszármazottai, valamint a [SplitterBarStateType](https://reference.aspose.com/slides/hu/cpp/aspose.slides/splitterbarstatetype/) felsorolt típus hozzá lettek adva.

## **Az INormalViewProperties leírása**

A normál nézet tulajdonságait reprezentálja.

A **ShowOutlineIcons** tulajdonság meghatározza, hogy az alkalmazás megjelenít-e ikonokat, ha vázlat tartalmat jelenít meg a normál nézet bármelyik tartalmi területén.

A **SnapVerticalSplitter** tulajdonság meghatározza, hogy a függőleges elválasztó minimalizált állapotba kattanjon-e, amikor az oldalsó terület elég kicsi.

A **PreferSingleView** tulajdonság meghatározza, hogy a felhasználó előnyben részesíti-e a teljesablakos egyetlen tartalmi területet a szokásos három tartalmi területből álló normál nézettel szemben. Ha engedélyezve van, az alkalmazás választhatja, hogy a teljes ablakot egy tartalmi terület kitöltésére használja.

A **VerticalBarState** és a **HorizontalBarState** tulajdonságok határozzák meg, hogy a vízszintes vagy függőleges elválasztó sáv milyen állapotban jelenjen meg. A vízszintes elválasztó sáv a dia és az alatta lévő tartalmi területet választja el, a függőleges elválasztó sáv a diát és az oldalsó tartalmi területet választja el. Lehetséges értékek: **SplitterBarStateType.Minimized**, **SplitterBarStateType.Maximized** és **SplitterBarStateType.Restored**.

A **RestoredLeft** és a **RestoredTop** tulajdonságok határozzák meg a normál nézet felső vagy oldalsó diaterület méretét, amikor a **VerticalBarState** és **HorizontalBarState** értéke **SplitterBarStateType.Restored**.

## **Az INormalViewProperties helyreállításáról**

Meghatározza a dia terület méretét (szélesség, ha a **RestoredTop** gyermekeként, magasság, ha a **RestoredLeft** gyermekeként) a normál nézetben, amikor a terület változó visszaállított méretű (sem minimalizált, sem maximalizált).

A **DimensionSize** tulajdonság a dia terület méretét adja meg (szélesség, ha a restoredTop gyermek, magasság, ha a restoredLeft gyermek).

Az **AutoAdjust** tulajdonság meghatározza, hogy az oldalsó tartalmi terület mérete kompenzálja-e az új méretet, amikor az alkalmazáson belül a nézetet tartalmazó ablak méretét változtatják.

Az alábbi példában látható, hogyan férhet hozzá egy prezentáció **ViewProperties.NormalViewProperties** tulajdonságaihoz.

```cpp
auto pres = System::MakeObject<Presentation>(u"demo.pptx");
pres->get_ViewProperties()->get_NormalViewProperties()->set_HorizontalBarState(SplitterBarStateType::Restored);
pres->get_ViewProperties()->get_NormalViewProperties()->set_VerticalBarState(SplitterBarStateType::Maximized);

// A prezentáció nézetpropikcióinak helyreállítása
pres->get_ViewProperties()->get_NormalViewProperties()->get_RestoredTop()->set_AutoAdjust(true);
pres->get_ViewProperties()->get_NormalViewProperties()->get_RestoredTop()->set_DimensionSize(80.0f);
pres->get_ViewProperties()->get_NormalViewProperties()->set_ShowOutlineIcons(true);

pres->Save(u"presentation_normal_view_state.pptx", SaveFormat::Pptx);
```

## **Az alapértelmezett nagyítási érték beállítása**

Az Aspose.Slides for C++ most már támogatja az alapértelmezett nagyítási érték beállítását a prezentációhoz, így amikor a prezentáció megnyílik, a nagyítás már be van állítva. Ez a [ViewProperties](https://reference.aspose.com/slides/hu/cpp/aspose.slides/viewproperties/) beállításával valósítható meg egy prezentáción. A dia nézet tulajdonságai illetve a [get_NotesViewProperties](https://reference.aspose.com/slides/hu/cpp/aspose.slides/viewproperties/get_notesviewproperties/) programozottan is beállíthatóak. Ebben a témában egy példán keresztül megmutatjuk, hogyan állítható be a prezentáció View Properties az Aspose.Slides segítségével.

A nézet tulajdonságok beállításához kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztályból  
1. Állítsa be a prezentáció View [Properties](https://reference.aspose.com/slides/hu/cpp/aspose.slides/viewproperties/) értékét  
1. Mentse a prezentációt PPTX fájlként  

Az alábbi példában a dia nézet és a jegyzet nézet nagyítási értékét is beállítottuk.

```cpp
auto presentation = System::MakeObject<Presentation>(u"demo.pptx");

// A prezentáció nézetpropikcióinak beállítása
presentation->get_ViewProperties()->get_SlideViewProperties()->set_Scale(100); // Nagyítási érték százalékban a dia nézethez
presentation->get_ViewProperties()->get_NotesViewProperties()->set_Scale(100); // Nagyítási érték százalékban a jegyzet nézethez

presentation->Save(u"Zoom_out.pptx", SaveFormat::Pptx);
```

## **Gyakran Ismételt Kérdések**

**Beállíthatok különböző nézetbeállításokat a prezentáció különböző szekcióihoz?**

A [View settings](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/get_viewproperties/) a prezentáció szintjén vannak definiálva ([Normal View](https://reference.aspose.com/slides/hu/cpp/aspose.slides/viewproperties/get_normalviewproperties/)/[Slide View](https://reference.aspose.com/slides/hu/cpp/aspose.slides/viewproperties/get_slideviewproperties/)), nem szekciónként, így egyetlen paramétercsoport érvényes a teljes dokumentumra, amikor megnyílik.

**Előre meghatározhatok különböző nézetállapotokat különböző felhasználók számára?**

Nem. A beállítások a fájlban tárolódnak és megosztottak. A megjelenítő alkalmazások figyelembe vehetik a felhasználói előnyben részesítéseket, de a fájl önmagában csak egy nézet tulajdonságkészletet tartalmaz.

**Létrehozhatok sablont előre definiált View Properties-vel, hogy az új prezentációk ugyanúgy nyíljanak meg?**

Igen. Mivel a [view properties](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/get_viewproperties/) a prezentáció szintjén vannak tárolva, beágyazhatja őket egy sablonba, és új dokumentumokat hozhat létre belőle ugyanazzal a kiinduló nézeti konfigurációval.
---
title: Prezentáció nézet tulajdonságainak lekérése és frissítése Pythonban
linktitle: Nézet tulajdonságok
type: docs
weight: 80
url: /hu/python-net/presentation-view-properties/
keywords:
- nézet tulajdonságok
- normál nézet
- vázlat tartalom
- vázlat ikonok
- függőleges elválasztó rögzítése
- egyszemélyes nézet
- sáv állapot
- dimenzió méret
- automatikus igazítás
- alapértelmezett nagyítás
- PowerPoint
- prezentáció
- Python
- Aspose.Slides
description: "Ismerje meg az Aspose.Slides for Python via .NET nézet tulajdonságait, hogy testreszabja a PPT, PPTX és ODP diák formátumait – állítsa be az elrendezéseket, nagyítási szinteket és megjelenítési beállításokat."
---
## **Bevezetés**

A normál nézet három tartalmi régióból áll: a diából, egy oldalsó tartalmi régióból és egy alsó tartalmi régióból. A különböző régiók elhelyezésével kapcsolatos tulajdonságok. Ezek az információk lehetővé teszik az alkalmazás számára, hogy a nézet állapotát a fájlba mentse, így újbóli megnyitáskor a nézet ugyanabban az állapotban lesz, mint amikor a prezentációt legutóbb mentették.

A [ViewProperties.normal_view_properties](https://reference.aspose.com/slides/hu/python-net/aspose.slides/viewproperties/normal_view_properties/) tulajdonság hozzáadva lett a prezentáció normál nézetének tulajdonságaihoz való hozzáféréshez.

A [NormalViewProperties](https://reference.aspose.com/slides/hu/python-net/aspose.slides/normalviewproperties/), [NormalViewRestoredProperties](https://reference.aspose.com/slides/hu/python-net/aspose.slides/normalviewrestoredproperties/) osztályok és azok leszármazottai, valamint a [SplitterBarStateType](https://reference.aspose.com/slides/hu/python-net/aspose.slides/splitterbarstatetype/) enumeráció került hozzáadásra.

## **Az INormalViewProperties leírása**

A normál nézet tulajdonságait reprezentálja.

A **ShowOutlineIcons** tulajdonság azt határozza meg, hogy az alkalmazás megjelenítse-e az ikonokat, ha vázlatot jelenít meg a normál nézet bármely tartalmi régiójában.

A **SnapVerticalSplitter** tulajdonság azt határozza meg, hogy a függőleges elválasztó mínimum méretű állapotba ugorjon-e, ha az oldalsó régió elég kicsi.

A **PreferSingleView** tulajdonság azt határozza meg, hogy a felhasználó a három tartalmi régióval rendelkező szabványos normál nézet helyett egy teljes ablakban megjelenő egyetlen tartalmi régiót részesíti-e előnyben. Ha engedélyezve van, az alkalmazás egy tartalmi régiót jeleníthet meg az egész ablakban.

A **VerticalBarState** és **HorizontalBarState** tulajdonságok határozzák meg, hogy a függőleges vagy vízszintes elválasztó sáv milyen állapotban jelenjen meg. A vízszintes elválasztó sáv a diától elválasztja az alatta lévő tartalmi régiót, a függőleges elválasztó sáv pedig a diától elválasztja az oldalsó tartalmi régiót. Lehetséges értékek: **SplitterBarStateType.Minimized**, **SplitterBarStateType.Maximized** és **SplitterBarStateType.Restored**.

A **RestoredLeft** és **RestoredTop** tulajdonságok határozzák meg a normál nézet felső vagy oldalsó diaterületének méretét, amikor a **VerticalBarState** illetve **HorizontalBarState** értéke **SplitterBarStateType.Restored**.

## **Az INormalViewProperties helyreállításáról**

A normál nézet diaterületének (szélesség, ha a **RestoredTop** gyermeke, magasság, ha a **RestoredLeft** gyermeke) méretét határozza meg, amikor a régió változó, helyreállított méretű (sem minimalizált, sem maximalizált) állapotban van.

A **DimensionSize** tulajdonság a diaterület méretét adja meg (szélesség, ha a **restoredTop** gyermeke, magasság, ha a **restoredLeft** gyermeke).

Az **AutoAdjust** tulajdonság azt határozza meg, hogy az oldalsó tartalmi régió mérete kompenzálja-e az alkalmazáson belül a nézetet tartalmazó ablak újraméretezését.

Az alábbi példa bemutatja, hogyan érhetők el a **ViewProperties.NormalViewProperties** tulajdonságai egy prezentációban.

```py
import aspose.slides as slides

with slides.Presentation("AccessSlides.pptx") as pres:
    pres.view_properties.normal_view_properties.horizontal_bar_state = slides.SplitterBarStateType.RESTORED
    pres.view_properties.normal_view_properties.vertical_bar_state = slides.SplitterBarStateType.MAXIMIZED

    # Állítsa vissza a prezentáció nézet tulajdonságait
    pres.view_properties.normal_view_properties.restored_top.auto_adjust = True
    pres.view_properties.normal_view_properties.restored_top.dimension_size = 80
    pres.view_properties.normal_view_properties.show_outline_icons = True

    pres.save("presentation_normal_view_state.pptx", slides.export.SaveFormat.PPTX)
```

## **Alapértelmezett nagyítási érték beállítása**

Az Aspose.Slides for Python via .NET most már támogatja az alapértelmezett nagyítási érték beállítását a prezentációhoz, így a prezentáció megnyitásakor a nagyítás már be van állítva. Ez a [view_properties](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/view_properties/) beállításával történhet a prezentációban. A Dia nézet tulajdonságok és a [notes_view_properties](https://reference.aspose.com/slides/hu/python-net/aspose.slides/viewproperties/notes_view_properties/) programozottan is beállíthatók. Ebben a témában példával mutatjuk be, hogyan állítható be a prezentáció nézet tulajdonságai az Aspose.Slides használatával.

A nézet tulajdonságok beállításához kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztályból
1. Állítsa be a prezentáció [view properties](https://reference.aspose.com/slides/hu/python-net/aspose.slides/viewproperties/) értékeit
1. Mentse a prezentációt PPTX fájlként

Az alább bemutatott példában a dianézet és a jegyzetnézet nagyítási értékét állítottuk be.

```py
import aspose.slides as slides

with slides.Presentation("AccessSlides.pptx") as presentation:
    # A prezentáció nézet tulajdonságainak beállítása
    presentation.view_properties.slide_view_properties.scale = 100 # Nagyítási érték százalékban a dianézethez
    presentation.view_properties.notes_view_properties.scale = 100 # Nagyítási érték százalékban a jegyzet nézethez

    presentation.save("Zoom_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Rácstávolság beállítása**

Használja a [Presentation.view_properties](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/view_properties/) elemet a prezentáció szintű nézetbeállítások eléréséhez. A [ViewProperties.grid_spacing](https://reference.aspose.com/slides/hu/python-net/aspose.slides/viewproperties/grid_spacing/) tulajdonság olvassa vagy módosítja a szerkesztési rács alapvető intervallumát. Ez a beállítás az egész prezentációra vonatkozik, nem egyetlen diára. A rácstávolság pontban van megadva, ahol 72 pont egy hüvelyknek felel meg. Pozitív értéket használjon, ahogy az API dokumentációja előírja.

Az alábbi példa megnyit egy meglévő `demo.pptx` fájlt, kiírja a jelenlegi rácstávolságot, egy negyed hüvelykes intervallumra állítja, majd elmenti az eredményt.

```py
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    grid_spacing = presentation.view_properties.grid_spacing
    print(f"Current grid spacing: {grid_spacing} points")

    presentation.view_properties.grid_spacing = 18.0
    presentation.save("grid-spacing.pptx", slides.export.SaveFormat.PPTX)
```

A rács különbözik a [drawing guides](/slides/hu/python-net/drawing-guides/) elemtől. A rács távolság egy szabályos intervallumot szabályoz, míg a rajzolási segédvonalak egyedileg elhelyezett vízszintes vagy függőleges igazítási vonalak. A segédvonalak hozzáadása, áthelyezése vagy törlése nem változtatja meg a rács távolságát.

Mind a rács, mind a rajzolási segédvonalak szerkesztési segédeszközök. Nem jelennek meg dia tartalomként PDF‑ben, képeken, SVG‑ben vagy diavetítésben. A rács távolságának tárolása nem garantálja, hogy a szerkesztő megjeleníti a rácsot: láthatósága a megjelenítő vagy szerkesztő beállításaitól is függ.

## **Gyakran feltett kérdések**

**Miért nem látható a rács a prezentáció újbóli megnyitása után?**

A fájl tárolja a rácstávolságot, de a szerkesztő határozza meg, hogy a rács megjelenik-e. Ellenőrizze a szerkesztő rács láthatósági beállításait.

**A rajzolási segédvonalak törlése megváltoztatja a rács távolságát?**

Nem. A rajzolási segédvonalak és a rács távolsága független beállítások. A segédvonalak törlése nem változtatja meg a tárolt rács intervallumot.

**Beállíthatok különböző nézetbeállításokat a prezentáció különböző szekcióihoz?**

A [View settings](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/view_properties/) a prezentáció szintjén vannak definiálva ([Normal View](https://reference.aspose.com/slides/hu/python-net/aspose.slides/viewproperties/normal_view_properties/)/[Slide View](https://reference.aspose.com/slides/hu/python-net/aspose.slides/viewproperties/slide_view_properties/)), nem szekciónként, így egyetlen paraméterkészlet érvényes az egész dokumentumra a megnyitáskor.

**Előre definiálhatok különböző nézetállapotokat különböző felhasználók számára?**

Nem. A beállítások a fájlban tárolódnak és megosztottak. A megjelenítő alkalmazások tiszteletben tarthatják a felhasználói preferenciákat, de a fájl csak egy nézettulajdonság‑készletet tartalmaz.

**Létrehozhatok egy sablont előre definiált nézettulajdonságokkal, hogy az új prezentációk ugyanúgy nyíljanak meg?**

Igen. Mivel a [view properties](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/view_properties/) a prezentáció szintjén vannak tárolva, beágyazhatja őket egy sablonba, és új dokumentumokat hozhat létre belőle ugyanazzal a kezdeti nézetkonfigurációval.
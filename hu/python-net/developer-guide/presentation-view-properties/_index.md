---
title: Prezentáció nézet tulajdonságainak lekérdezése és frissítése Pythonban
linktitle: Nézet tulajdonságok
type: docs
weight: 80
url: /hu/python-net/presentation-view-properties/
keywords:
- nézet tulajdonságok
- normál nézet
- vázlat tartalom
- vázlat ikonok
- függőleges osztó rögzítése
- egyetlen nézet
- sáv állapota
- dimenzió méret
- automatikus igazítás
- alapértelmezett nagyítás
- PowerPoint
- prezentáció
- Python
- Aspose.Slides
description: "Fedezze fel az Aspose.Slides for Python via .NET nézet tulajdonságait, hogy testreszabja a PPT, PPTX és ODP diák formátumait – állítsa be az elrendezéseket, nagyítási szinteket és megjelenítési beállításokat."
---
## **Bevezetés**

A normál nézet három tartalmi területből áll: maga a dia, egy oldalsó tartalmi terület és egy alsó tartalmi terület. A különböző tartalmi területek elhelyezésével kapcsolatos tulajdonságok. Ez az információ lehetővé teszi az alkalmazás számára, hogy a nézetállapotot a fájlba mentse, így újra megnyitáskor a nézet ugyanabban az állapotban lesz, mint amikor a bemutatót utoljára elmentették.

A [ViewProperties.normal_view_properties](https://reference.aspose.com/slides/hu/python-net/aspose.slides/viewproperties/normal_view_properties/) tulajdonságot hozzáadták, hogy hozzáférést biztosítson a prezentáció normál nézet tulajdonságaihoz.

A [NormalViewProperties](https://reference.aspose.com/slides/hu/python-net/aspose.slides/normalviewproperties/), [NormalViewRestoredProperties](https://reference.aspose.com/slides/hu/python-net/aspose.slides/normalviewrestoredproperties/) osztályok és azok leszármazottai, valamint a [SplitterBarStateType](https://reference.aspose.com/slides/hu/python-net/aspose.slides/splitterbarstatetype/) felsorolt típus (enum) hozzá lett adva.

## **Az INormalViewProperties‑ról**

A normál nézet tulajdonságait képviseli.

A **ShowOutlineIcons** tulajdonság azt határozza meg, hogy az alkalmazás ikonokat jelenítsen‑e, ha a kontúr tartalmat bármelyik tartalmi régióban a normál nézet módban jeleníti meg.

Az **SnapVerticalSplitter** tulajdonság meghatározza, hogy a függőleges osztó minimális állapotba ragadjon‑e, amikor az oldalsó régió elég kicsi.

Az **PreferSingleView** tulajdonság azt szabályozza, hogy a felhasználó teljesablakos egyetlen tartalmi régiót részesít‑e előnyben a három tartalmi régióval rendelkező szabványos normál nézettel szemben. Ha engedélyezve van, az alkalmazás egyik tartalmi régiót az egész ablakban megjelenítheti.

Az **VerticalBarState** és **HorizontalBarState** tulajdonságok határozzák meg, hogy a vízszintes vagy függőleges osztó sáv milyen állapotban legyen megjelenítve. Egy vízszintes osztó sáv elválasztja a diát a diát alatti tartalmi régiótól, a függőleges osztó sáv a diát az oldalsó tartalmi Régiótól. Lehetséges értékek: **SplitterBarStateType.Minimized**, **SplitterBarStateType.Maximized** és **SplitterBarStateType.Restored**.

Az **RestoredLeft** és **RestoredTop** tulajdonságok meghatározzák a normál nézet felső vagy oldalsó diaterületének méretét, amikor a **VerticalBarState** illetve **HorizontalBarState** értéke **SplitterBarStateType.Restored**.

## **Az INormalViewProperties helyreállításáról**

Meghatározza a diaterület (szélesség, ha a RestoredTop gyermekeként, magasság, ha a RestoredLeft gyermekeként) méretét a normál nézetben, amikor a terület változó helyreállított mérettel rendelkezik (sem minimalizált, sem maximalizált).

A **DimensionSize** tulajdonság megadja a diaterület méretét (szélesség, ha a restoredTop gyermek, magasság, ha a restoredLeft gyermek).

Az **AutoAdjust** tulajdonság azt határozza meg, hogy az oldalsó tartalmi régió mérete kompenzálja‑e az új méretet, amikor az alkalmazáson belül a nézetet tartalmazó ablakot átméretezik.

Az alábbi példában látható, hogyan érheti el egy prezentáció **ViewProperties.NormalViewProperties** tulajdonságait.

```py
import aspose.slides as slides

with slides.Presentation("AccessSlides.pptx") as pres:
    pres.view_properties.normal_view_properties.horizontal_bar_state = slides.SplitterBarStateType.RESTORED
    pres.view_properties.normal_view_properties.vertical_bar_state = slides.SplitterBarStateType.MAXIMIZED

    # A prezentáció nézet tulajdonságainak visszaállítása
    pres.view_properties.normal_view_properties.restored_top.auto_adjust = True
    pres.view_properties.normal_view_properties.restored_top.dimension_size = 80
    pres.view_properties.normal_view_properties.show_outline_icons = True

    pres.save("presentation_normal_view_state.pptx", slides.export.SaveFormat.PPTX)
```

## **Alapértelmezett nagyítási érték beállítása**

Az Aspose.Slides for Python via .NET most már támogatja a prezentáció alapértelmezett nagyítási értékének beállítását, így a prezentáció megnyitásakor a nagyítás már meg van határozva. Ez a [view_properties](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/view_properties/) beállításával tehető meg. A dianézet tulajdonságai valamint a [notes_view_properties](https://reference.aspose.com/slides/hu/python-net/aspose.slides/viewproperties/notes_view_properties/) programozottan beállíthatók. Ebben a témában egy példán keresztül megmutatjuk, hogyan állítható be a prezentáció Nézet Tulajdonságai az Aspose.Slides‑ben.

A nézet tulajdonságainak beállításához kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztályból
2. Állítsa be a prezentáció [view properties](https://reference.aspose.com/slides/hu/python-net/aspose.slides/viewproperties/) tulajdonságait
3. Írja a prezentációt PPTX fájlként

Az alábbi példában beállítottuk a nagyítási értéket a dianézethez és a jegyzetnézethez is.

```py
import aspose.slides as slides

with slides.Presentation("AccessSlides.pptx") as presentation:
    # A prezentáció nézet tulajdonságainak beállítása
    presentation.view_properties.slide_view_properties.scale = 100 # Nagyítási érték százalékban a dianézethez
    presentation.view_properties.notes_view_properties.scale = 100 # Nagyítási érték százalékban a jegyzet nézethez 

    presentation.save("Zoom_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Rácstávolság beállítása**

Használja a [Presentation.view_properties](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/view_properties/) tulajdonságot a prezentáció szintű nézetbeállítások eléréséhez. A [ViewProperties.grid_spacing](https://reference.aspose.com/slides/hu/python-net/aspose.slides/viewproperties/grid_spacing/) tulajdonság olvas vagy módosítja az alap szerkesztő rácsának intervallumát. Ez a beállítás az egész prezentációra vonatkozik, nem egy egyedi diára. A rács távolsága pontban van megadva, ahol 72 pont egy hüvelyknek felel meg. Pozitív értéket használjon, ahogy az API dokumentációja előírja.

Az alábbi példa megnyit egy meglévő `demo.pptx` fájlt, kiírja a jelenlegi rácstávolságot, egy negyed hüvelykes intervallumra állítja, majd elmenti az eredményt.

```py
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    grid_spacing = presentation.view_properties.grid_spacing
    print(f"Current grid spacing: {grid_spacing} points")

    presentation.view_properties.grid_spacing = 18.0
    presentation.save("grid-spacing.pptx", slides.export.SaveFormat.PPTX)
```

A rács különbözik a [drawing guides](/slides/hu/python-net/drawing-guides/) elemtől. A rácstávolság szabályoz egy szabályos intervallumot, míg a rajzvasak egyéni, vízszintes vagy függőleges igazító vonalak. A rajzvasak hozzáadása, mozgatása vagy törlése nem változtatja meg a rácstávolságot.

Mind a rács, mind a rajzvasak szerkesztési segédeszközök. Nem jelennek meg diá tartalomként PDF‑ben, képekben, SVG‑ben vagy diavetítésben. A rácstávolság tárolása nem garantálja, hogy egy szerkesztő megjeleníti a rácsot: annak láthatósága a megjelenítő vagy szerkesztő beállításaitól is függ.

## **Megjegyzések megjelenítése vagy elrejtése a prezentáció megnyitásakor**

Használja a [Presentation.view_properties](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/view_properties/) tulajdonságot a prezentáció szintű nézetbeállítások eléréséhez. Olvassa vagy módosítsa a [ViewProperties.show_comments](https://reference.aspose.com/slides/hu/python-net/aspose.slides/viewproperties/show_comments/) beállítást, hogy tárolja, a megjegyzéseket meg kell‑e jeleníteni, amikor a prezentáció megnyílik a PowerPointban vagy egy másik kompatibilis szerkesztőben.

Ez a beállítás csak a tárolt nézetpreferenciát szabályozza. Nem ad hozzá, nem távolít el, nem szerkeszt és nem old meg megjegyzéseket. A megjegyzések elrejtése megőrzi azok tartalmát, szerzőit, pozícióját, válaszait és állapotát. Lásd a [Presentation Comments](/slides/hu/python-net/presentation-comments/) szakaszt a megjegyzéseket módosító műveletekhez.

Az alábbi példa egy meglévő `comments.pptx` fájlt igényel, amely tartalmaz megjegyzéseket. Kiírja a jelenlegi láthatósági beállítást, kéri a megjegyzések elrejtését, majd új PPTX‑et ment anélkül, hogy bármilyen megjegyzést eltávolítana. Emellett a [ViewProperties.last_view](https://reference.aspose.com/slides/hu/python-net/aspose.slides/viewproperties/last_view/) beállítást a [ViewType.SLIDE_VIEW](https://reference.aspose.com/slides/hu/python-net/aspose.slides/viewtype/) értékre állítja, hogy a kezdeti szerkesztő nézetet a megjegyzés‑láthatósággal együtt konfigurálja.

```py
import aspose.slides as slides

with slides.Presentation("comments.pptx") as presentation:
    show_comments = presentation.view_properties.show_comments
    print(f"Current comment visibility: {show_comments}")

    presentation.view_properties.show_comments = slides.NullableBool.FALSE
    presentation.view_properties.last_view = slides.ViewType.SLIDE_VIEW
    presentation.save("comments-hidden.pptx", slides.export.SaveFormat.PPTX)
```

Ez a beállítás nem határozza meg, hogy a megjegyzések szerepelnek‑e PDF‑ben, HTML‑ben, képekben, jegyzetekben vagy kiadványok exportálásakor. A megfelelő export‑specifikus opciókat külön kell beállítani.

## **GYIK**

**Miért nem látható a rács, miután újra megnyitottam a prezentációt?**

A fájl tárolja a rácstávolságot, de a szerkesztő dönt a rács megjelenítéséről. Ellenőrizze a szerkesztő rács‑láthatósági beállításait.

**A rajzvasak törlése megváltoztatja a rácstávolságot?**

Nem. A rajzvasak és a rácstávolság független beállítások. A vasak törlése nem módosítja a tárolt rácsintervallumot.

**Beállíthatok különböző nézetbeállításokat a bemutató különböző szakaszaihoz?**

A [Nézetbeállítások](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/view_properties/) a prezentáció szintjén (Normál nézet / Dia nézet) vannak definiálva, nem szakaszonként, így egyetlen paraméterkészlet vonatkozik a teljes dokumentumra a megnyitáskor.

**Előre definiálhatok különböző nézetállapotokat különböző felhasználók számára?**

Nem. A beállítások a fájlban vannak tárolva, és minden felhasználó megosztja őket. A megjelenítő alkalmazások tiszteletben tarthatják a felhasználói preferenciákat, de a fájl egyetlen nézettulajdonság‑készletet tartalmaz.

**Készíthetek sablont előre meghatározott nézettulajdonságokkal, hogy az új prezentációk ugyanúgy nyíljanak meg?**

Igen. Mivel a [view properties](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/view_properties/) a prezentáció szintjén vannak tárolva, beágyazhatja őket egy sablonba, és az onnan létrehozott új dokumentumok ugyanazzal a kezdeti nézetkonfigurációval fognak megnyílni.
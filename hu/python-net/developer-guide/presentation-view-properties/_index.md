---
title: Prezentáció nézeti tulajdonságainak lekérése és frissítése Pythonban
linktitle: Nézeti tulajdonságok
type: docs
weight: 80
url: /hu/python-net/presentation-view-properties/
keywords: 
- nézeti tulajdonságok
- normál nézet
- vázlat tartalom
- vázlat ikonok
- függőleges elválasztó rögzítése
- egyetlen nézet
- osztó állapota
- dimenzió mérete
- automatikus beállítás
- alapértelmezett nagyítás
- PowerPoint
- OpenDocument
- prezentáció
- Python
- Aspose.Slides
description: "Használja az Aspose.Slides for Python via .NET-et a PowerPoint prezentációk normál nézetének elrendezésének, a dia és a jegyzetek nagyításának, a rács távolságának, valamint a megjegyzések láthatóságának beállításához."
---
## **Bevezetés**

A PowerPoint normál nézetében a dia a bélyegképek vagy vázlat oldalpanelja és a lent lévő jegyzetpanel között jelenik meg. Az Aspose.Slides for Python via .NET elérhetővé teszi a prezentáció mentett szerkesztési beállításait a [Presentation.view_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/view_properties/). Ezek közé tartozik a panelelrendezés, a nagyítási szintek, a rács távolság és a kommentek láthatósága.

## **A NormalViewProperties tulajdonságokról**

Használja a [normal_view_properties](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/normal_view_properties/) a [NormalViewProperties](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/) objektum eléréséhez. A [show_outline_icons](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/show_outline_icons/) szabályozza, hogy ikonok jelenjenek-e meg a diacímek mellett a vázlatban. A [snap_vertical_splitter](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/snap_vertical_splitter/) lehetővé teszi, hogy az oldalpanel a felhasználó szűkítésekor a minimalizált állapothoz illeszkedjen. A [prefer_single_view](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/prefer_single_view/) jelzi azt a preferenciát, hogy egy panelt jelenítsen meg a teljes ablakban.

A [vertical_bar_state](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/vertical_bar_state/) vezérli az elválasztót az oldalpanel és a dia között. A [horizontal_bar_state](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/horizontal_bar_state/) vezérli az elválasztót a jegyzetpanel felett. Mindkettő a [SplitterBarStateType](https://reference.aspose.com/slides/python-net/aspose.slides/splitterbarstatetype/) `MINIMIZED`, `MAXIMIZED` vagy `RESTORED` értéket fogadja el.

<!-- visual-explanation:presentation-view-properties:start -->
[![Egy elméleti szerkesztő elválasztja az oldalpanelt, a dia területet és az alsó régiót felcímkézett függőleges és vízszintes osztókkal.](visual-presentation-view-properties-40ae1765a743.svg)](visual-presentation-view-properties-40ae1765a743.svg)

*Normál nézetben a függőleges osztó vezérli az oldalpanel szélességét. A vízszintes osztó vezérli a jegyzetpanel feletti teret.*
<!-- visual-explanation:presentation-view-properties:end -->

## **A NormalViewProperties helyreállításáról**

Amikor egy elválasztót helyreállítanak, a [restored_left](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/restored_left/) adja meg az oldalpanel mentett méretét, a [restored_top](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/restored_top/) pedig a felső dia terület mentett méretét. Mindkettő a [NormalViewRestoredProperties](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewrestoredproperties/) objektumot fejezi ki. A [dimension_size](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewrestoredproperties/dimension_size/) tulajdonsága 0‑tól 100‑ig terjedő százalékot fogad, a [auto_adjust](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewrestoredproperties/auto_adjust/) pedig szabályozza, hogy a szerkesztő állítsa‑e be a méretet az ablak átméretezésekor.

Ez a példa egy meglévő prezentációt frissít. Visszaállítja a vízszintes elválasztót, a [restored_top](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/restored_top/) értékét 80 %-ra állítja automatikus beállítással, és maximalizálja a függőleges elválasztót. Emellett engedélyezi a [show_outline_icons](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/show_outline_icons/) opciót a vázlat nézethez.

```py
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    normal_view = presentation.view_properties.normal_view_properties
    normal_view.horizontal_bar_state = slides.SplitterBarStateType.RESTORED
    normal_view.vertical_bar_state = slides.SplitterBarStateType.MAXIMIZED
    normal_view.restored_top.auto_adjust = True
    normal_view.restored_top.dimension_size = 80
    normal_view.show_outline_icons = True

    presentation.save("presentation_normal_view_state.pptx", slides.export.SaveFormat.PPTX)
```

## **Az alapértelmezett nagyítási érték beállítása**

A [slide_view_properties](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/slide_view_properties/) és a [notes_view_properties](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/notes_view_properties/) független nagyítási beállításokat tárolnak a szerkesztő számára. Ezek a beállítások nem érintik a dia méreteit, a diavetítés lejátszását vagy a képek export felbontását.

Ez a példa egy meglévő prezentációt nyit meg, és engedélyezi a [variable_scale](https://reference.aspose.com/slides/python-net/aspose.slides/commonslideviewproperties/variable_scale/) opciót, hogy a dia a szerkesztőablakhoz igazodjon. A jegyzetoldalon letiltja az automatikus skálázást, és a [scale](https://reference.aspose.com/slides/python-net/aspose.slides/commonslideviewproperties/scale/) értékét fix 80 %-os nagyításra állítja.

```py
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    view_properties = presentation.view_properties
    view_properties.slide_view_properties.variable_scale = True
    view_properties.notes_view_properties.variable_scale = False
    view_properties.notes_view_properties.scale = 80

    presentation.save("zoom.pptx", slides.export.SaveFormat.PPTX)
```

## **Rácstávolság beállítása**

A [grid_spacing](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/grid_spacing/) állítja a szerkesztői rácsvonalak közötti távolságot a teljes prezentációban. Pozitív értéket vesz fel pontban, 72 pont egy hüvelyknek felel meg. Ez a példa egy meglévő prezentációban kiírja az aktuális távolságot, majd egy negyed hüvelykes rácsot ment 18 pont intervallummal.

```py
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    view_properties = presentation.view_properties
    print(f"Current grid spacing: {view_properties.grid_spacing} points")

    view_properties.grid_spacing = 18.0

    presentation.save("grid-spacing.pptx", slides.export.SaveFormat.PPTX)
```

A rács rögzített intervallummal ismétlődik. A [Rajzolási segédvonalak](/slides/hu/python-net/drawing-guides/) egyedi vízszintes vagy függőleges pozíciókat jelölnek. Mindkettő szerkesztői segédlet, és csak a megjelenítést támogató szerkesztőkben látható. Diavetítések és PDF, kép vagy SVG exportok nem tartalmazzák őket.

## **Megjegyzések megjelenítése vagy elrejtése prezentáció megnyitásakor**

A [show_comments](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/show_comments/) tárolja azt a preferenciát, amelyet a kompatibilis szerkesztők a prezentáció megnyitásakor használnak. Egy meglévő, megjegyzésekkel rendelkező prezentáció esetén ez a példa kiírja a jelenlegi beállítást, és egy megjegyzéseket rejtő másolatot ment. Emellett a [last_view](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/last_view/) értékét a [ViewType.SLIDE_VIEW](https://reference.aspose.com/slides/python-net/aspose.slides/viewtype/) típusra állítja, hogy a másolat dia nézetben nyíljon meg.

```py
import aspose.slides as slides

with slides.Presentation("comments.pptx") as presentation:
    view_properties = presentation.view_properties
    print(f"Current comment visibility: {view_properties.show_comments}")

    view_properties.show_comments = slides.NullableBool.FALSE
    view_properties.last_view = slides.ViewType.SLIDE_VIEW
    
    presentation.save("comments-hidden.pptx", slides.export.SaveFormat.PPTX)
```

A megjegyzések elrejtése megőrzi a szöveget, szerzőket, pozíciókat, válaszokat és állapotokat. A megjegyzések módosításához lásd a [Presentation Comments](/slides/hu/python-net/presentation-comments/). Az exporti beállítások határozzák meg, hogy a megjegyzések megjelennek-e PDF, HTML, képek, jegyzetek vagy szórólapok esetén.

## **GYIK**

**Miért rejtett a rács, amikor újra megnyitom a prezentációt?**

A prezentáció tárolja a rács intervallumát. A rács megtekintéséhez engedélyezze annak láthatóságát a szerkesztőben.

**Megtörli a rajzolási segédvonalak eltávolítása a rács távolságát?**

Nem. Egy segédvonal hozzáadása, mozgatása vagy törlése nem változtatja meg a rács intervallumát.

**Lehet, hogy a prezentáció különböző részeinek eltérő nézeti beállításai legyenek?**

Nem. A [Presentation.view_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/view_properties/) az egész prezentációra vonatkozik.

**Menthetek külön nézeti beállításokat különböző felhasználók számára?**

A fájl egyetlen nézeti tulajdonság‑készletet tárol mindenki számára. Egy szerkesztő továbbá alkalmazhatja a felhasználó helyi preferenciáit.

**Menthetek nézeti beállításokat sablonba?**

Igen. A sablonból létrehozott prezentációk öröklik a mentett nézeti beállításokat.
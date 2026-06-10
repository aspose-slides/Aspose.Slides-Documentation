---
title: Prezentációs nézet tulajdonságok lekérése és frissítése Pythonban
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
- egyes nézet
- sáv állapot
- dimenzió méret
- automatikus igazítás
- alapértelmezett nagyítás
- PowerPoint
- bemutató
- Python
- Aspose.Slides
description: "Fedezze fel az Aspose.Slides for Python via .NET nézet tulajdonságait, hogy testre szabja a PPT, PPTX és ODP diák formátumát – módosítsa az elrendezéseket, a nagyítási szinteket és a megjelenítési beállításokat."
---
## **Bevezetés**

A normál nézet három tartalmi területből áll: magából a diából, egy oldalsó tartalmi területből és egy alsó tartalmi területből. A különböző tartalmi területek elhelyezésével kapcsolatos tulajdonságok. Ez az információ lehetővé teszi, hogy az alkalmazás elmentse a nézet állapotát a fájlba, így amikor újra megnyílik, a nézet ugyanabban az állapotban van, mint amikor a bemutatót legutóbb elmentették.

A [ViewProperties.normal_view_properties](https://reference.aspose.com/slides/hu/python-net/aspose.slides/viewproperties/normal_view_properties/) tulajdonság hozzá lett adva, hogy hozzáférést biztosítson a bemutató normál nézet tulajdonságaihoz.  

Az [NormalViewProperties](https://reference.aspose.com/slides/hu/python-net/aspose.slides/normalviewproperties/), [NormalViewRestoredProperties](https://reference.aspose.com/slides/hu/python-net/aspose.slides/normalviewrestoredproperties/) osztályok és azok leszármazottai, valamint a [SplitterBarStateType](https://reference.aspose.com/slides/hu/python-net/aspose.slides/splitterbarstatetype/) enum hozzá lett adva.

## **Az INormalViewProperties leírása** 

A normál nézet tulajdonságait képviseli.

A **ShowOutlineIcons** tulajdonság meghatározza, hogy az alkalmazás ikonokat jelenítsen-e meg, ha a vázlat tartalmat bármelyik normál nézet tartalmi területben jeleníti meg.

A **SnapVerticalSplitter** tulajdonság meghatározza, hogy a függőleges elválasztó minimalizált állapotba lépjen-e, amikor az oldalsó terület elég kicsi.

A **PreferSingleView** tulajdonság azt adja meg, hogy a felhasználó előnyben részesíti-e a teljesablakos egyetlen tartalmi területet a három tartalmi területet tartalmazó szabványos normál nézettel szemben. Ha engedélyezve van, az alkalmazás egy tartalmi területet megjeleníthet az egész ablakban.

A **VerticalBarState** és a **HorizontalBarState** tulajdonságok határozzák meg, hogy a vízszintes vagy függőleges elválasztó sáv milyen állapotban legyen megjelenítve. A vízszintes elválasztó sáv a diát elválasztja a diát alatti tartalmi területtől, a függőleges elválasztó sáv pedig a diát az oldalsó tartalmi területtől. Lehetséges értékek: **SplitterBarStateType.Minimized, SplitterBarStateType.Maximized** és **SplitterBarStateType.Restored.**

A **RestoredLeft** és a **RestoredTop** tulajdonságok határozzák meg a normál nézet felső vagy oldalsó diaterületének méretét, amikor a **VerticalBarState** illetve a **HorizontalBarState** esetén a **SplitterBarStateType.Restored** érték van alkalmazva.

## **Az INormalViewProperties visszaállításának leírása**

Meghatározza a diaterület méretét (szélesség, ha a RestoredTop gyermekével van, magasság, ha a RestoredLeft gyermekével van) a normál nézetben, amikor a terület változó visszaállított mérettel rendelkezik (sem minimalizált, sem maximalizált).

A **DimensionSize** tulajdonság meghatározza a diaterület méretét (szélesség, ha a restoredTop gyermekével van, magasság, ha a restoredLeft gyermekével van).

A **AutoAdjust** tulajdonság azt határozza meg, hogy a oldalsó tartalmi terület mérete kompenzálja-e az új méretet, amikor az alkalmazáson belül a nézetet tartalmazó ablakot átméretezik.

Az alábbi példában megmutatjuk, hogyan férhet hozzá a **ViewProperties.NormalViewProperties** tulajdonságokhoz egy bemutatóban.

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as pres:
    pres.view_properties.normal_view_properties.horizontal_bar_state = slides.SplitterBarStateType.RESTORED
    pres.view_properties.normal_view_properties.vertical_bar_state = slides.SplitterBarStateType.MAXIMIZED

    # A bemutató nézet tulajdonságainak visszaállítása
    pres.view_properties.normal_view_properties.restored_top.auto_adjust = True
    pres.view_properties.normal_view_properties.restored_top.dimension_size = 80
    pres.view_properties.normal_view_properties.show_outline_icons = True

    pres.save("presentation_normal_view_state.pptx", slides.export.SaveFormat.PPTX)
```

## **Alapértelmezett nagyítási érték beállítása**

Az Aspose.Slides for Python via .NET most már támogatja az alapértelmezett nagyítási érték beállítását a bemutatóhoz, így a bemutató megnyitásakor a nagyítás már be van állítva. Ezt a bemutató [view_properties](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/view_properties/) beállításával lehet elérni. A Dianézet tulajdonságok és a [notes_view_properties](https://reference.aspose.com/slides/hu/python-net/aspose.slides/viewproperties/notes_view_properties/) is programozottan állíthatók. Ebben a témában egy példán keresztül megmutatjuk, hogyan állítható be a bemutató View Properties az Aspose.Slides-ben.

A nézet tulajdonságainak beállításához kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztályból
1. Állítsa be a bemutató [view properties](https://reference.aspose.com/slides/hu/python-net/aspose.slides/viewproperties/) értékét
1. Írja ki a bemutatót PPTX fájlként

Az alábbi példában beállítottuk a nagyítási értéket a dianézethez és a jegyzetek nézethez is.

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    # A bemutató nézet tulajdonságainak beállítása
    presentation.view_properties.slide_view_properties.scale = 100 # Dianézet nagyítási értéke százalékban
    presentation.view_properties.notes_view_properties.scale = 100 # Jegyzetek nézetének nagyítási értéke százalékban

    presentation.save("Zoom_out.pptx", slides.export.SaveFormat.PPTX)
```

## **GYIK**

**Beállíthatok különböző nézetbeállításokat a bemutató különböző szakaszaira?**  

A [Nézet beállítások](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/view_properties/) a bemutató szintjén vannak meghatározva ([Normál nézet](https://reference.aspose.com/slides/hu/python-net/aspose.slides/viewproperties/normal_view_properties/)/[Dia nézet](https://reference.aspose.com/slides/hu/python-net/aspose.slides/viewproperties/slide_view_properties/)), nem szekciónként, így egyetlen paraméterkészlet érvényes a teljes dokumentumra, amikor megnyílik.

**Előre meghatározhatok különböző nézetállapotokat különböző felhasználók számára?**  

Nem. A beállítások a fájlban vannak tárolva és meg vannak osztva. A megjelenítő alkalmazások figyelembe vehetik a felhasználói preferenciákat, de maga a fájl csak egy nézet tulajdonságkészletet tartalmaz.

**Készíthetek olyan sablont előre definiált nézet tulajdonságokkal, hogy az új bemutatók ugyanúgy nyíljanak meg?**  

Igen. Mivel a [view properties](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/view_properties/) a bemutató szintjén vannak tárolva, beágyazhatja őket egy sablonba, és új dokumentumokat hozhat létre belőle ugyanazzal a kezdeti nézetkonfigurációval.
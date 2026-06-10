---
title: Prezentáció nézet tulajdonságainak lekérdezése és frissítése .NET-ben
linktitle: Nézet tulajdonságok
type: docs
weight: 80
url: /hu/net/presentation-view-properties/
keywords:
- nézet tulajdonságok
- normál nézet
- vázlat tartalom
- vázlat ikonok
- függőleges elválasztó illesztése
- egy nézet
- csík állapot
- dimenzió méret
- automatikus igazítás
- alapértelmezett nagyítás
- PowerPoint
- OpenDocument
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Fedezze fel az Aspose.Slides for .NET nézet tulajdonságait a PPT, PPTX és ODP diák formátumainak testreszabásához – állítsa be az elrendezéseket, nagyítási szinteket és megjelenítési beállításokat."
---
## **Bevezetés**

A normál nézet három tartalmi területből áll: a diából, egy oldalsó tartalmi területből és egy alsó tartalmi területből. A különböző tartalmi területek elhelyezésével kapcsolatos tulajdonságok. Ez az információ lehetővé teszi az alkalmazás számára, hogy a nézetállapotot a fájlba mentse, így újranyitáskor a nézet ugyanabban az állapotban lesz, mint amikor a bemutató legutóbb el lett mentve.

A [IViewProperties.NormalViewProperties](https://reference.aspose.com/slides/hu/net/aspose.slides/iviewproperties/properties/normalviewproperties) tulajdonság lett hozzáadva, hogy hozzáférést biztosítson a bemutató normál nézetének tulajdonságaihoz.

A [INormalViewProperties](https://reference.aspose.com/slides/hu/net/aspose.slides/inormalviewproperties), a [INormalViewRestoredProperties](https://reference.aspose.com/slides/hu/net/aspose.slides/inormalviewrestoredproperties) interfészek és azok leszármazottai, valamint a [SplitterBarStateType](https://reference.aspose.com/slides/hu/net/aspose.slides/splitterbarstatetype) felsorolt típus (enum) hozzá lett adva.

## **Az INormalViewProperties-ról**

A normál nézet tulajdonságait képviseli.

**ShowOutlineIcons** tulajdonság meghatározza, hogy az alkalmazás ikont jelenítsen-e meg, ha vázlat tartalmat jelenít meg a normál nézet bármelyik tartalmi területén.

**SnapVerticalSplitter** tulajdonság meghatározza, hogy a függőleges elválasztó „ráilleszkedjen‑e” egy minimalizált állapotba, ha az oldalsó terület elegendően kicsi.

**PreferSingleView** tulajdonság meghatározza, hogy a felhasználó a teljes ablakot elfoglaló egyetlen tartalmi területet részesíti-e előnyben a három tartalmi területet tartalmazó szabványos normál nézettel szemben. Ha engedélyezve van, az alkalmazás választhatja, hogy egy tartalmi területet jelenít meg az egész ablakban.

A **VerticalBarState** és **HorizontalBarState** tulajdonságok határozzák meg a vízszintes vagy függőleges elválasztó csík megjelenítési állapotát. A vízszintes elválasztó csík elválasztja a diát a dia alatti tartalmi területtől, a függőleges elválasztó csík a diát az oldalsó tartalmi területtől. Lehetséges értékek: **SplitterBarStateType.Minimized**, **SplitterBarStateType.Maximized** és **SplitterBarStateType.Restored**.

A **RestoredLeft** és **RestoredTop** tulajdonságok a normál nézet felső vagy oldalsó diaterületének méretét határozzák meg, amikor a **VerticalBarState** és **HorizontalBarState** értéke **SplitterBarStateType.Restored**.

## **Az INormalViewProperties helyreállításáról**

Meghatározza a diaterület (szélesség, ha a RestoredTop gyermekeként, magasság, ha a RestoredLeft gyermekeként) méretét a normál nézetben, amikor a terület változó visszahelyezett mérettel rendelkezik (sem minimalizált, sem maximalizált).

**DimensionSize** tulajdonság határozza meg a diaterület (szélesség, ha a restoredTop gyermekeként, magasság, ha a restoredLeft gyermekeként) méretét.

**AutoAdjust** tulajdonság meghatározza, hogy az oldalsó tartalmi terület mérete kompenzálja‑e az új méretet, amikor az alkalmazáson belül a nézetet tartalmazó ablakot átméretezik.

Az alábbi példában látható, hogyan lehet elérni egy bemutató **ViewProperties.NormalViewProperties** tulajdonságait.

```c#
using (Presentation pres = new Presentation("demo.pptx"))
{
    pres.ViewProperties.NormalViewProperties.HorizontalBarState = SplitterBarStateType.Restored;
    pres.ViewProperties.NormalViewProperties.VerticalBarState = SplitterBarStateType.Maximized;

    // A bemutató nézet tulajdonságainak helyreállítása
    pres.ViewProperties.NormalViewProperties.RestoredTop.AutoAdjust = true;
    pres.ViewProperties.NormalViewProperties.RestoredTop.DimensionSize = 80;
    pres.ViewProperties.NormalViewProperties.ShowOutlineIcons = true;

    pres.Save("presentation_normal_view_state.pptx", SaveFormat.Pptx);
}
```

## **Alapértelmezett nagyítási érték beállítása**

Az Aspose.Slides for .NET most már támogatja a bemutató alapértelmezett nagyítási értékének beállítását, így a bemutató megnyitásakor a nagyítás már be van állítva. Ez a [ViewProperties](https://reference.aspose.com/slides/hu/net/aspose.slides/viewproperties) beállításával valósítható meg. A dia nézet tulajdonságok és a [NotesViewProperties](https://reference.aspose.com/slides/hu/net/aspose.slides/viewproperties/properties/notesviewproperties) is programozottan beállítható. Ebben a témában egy példán keresztül megmutatjuk, hogyan állítható be a bemutató nézet tulajdonsága az Aspose.Slides segítségével.

A nézet tulajdonságainak beállításához kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation) osztályból
1. Állítsa be a Bemutató nézet [Properties](https://reference.aspose.com/slides/hu/net/aspose.slides/viewproperties) tulajdonságait
1. Írja ki a bemutatót PPTX fájlként

Az alábbi példában beállítottuk a nagyítási értéket a dia nézethez, valamint a jegyzet nézethez.

```c#
using (Presentation presentation = new Presentation("demo.pptx"))
{
    // A bemutató nézet tulajdonságainak beállítása
    presentation.ViewProperties.SlideViewProperties.Scale = 100; // Nagyítás értéke százalékban a dia nézethez
    presentation.ViewProperties.NotesViewProperties.Scale = 100; // Nagyítás értéke százalékban a jegyzet nézethez 

    presentation.Save("Zoom_out.pptx", SaveFormat.Pptx);
}
```

## **GYIK**

**Beállíthatok különböző nézetbeállításokat a bemutató különböző szakaszaihoz?**

A [View settings](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/viewproperties/) a bemutató szintjén van definiálva ([Normal View](https://reference.aspose.com/slides/hu/net/aspose.slides/viewproperties/normalviewproperties/)/[Slide View](https://reference.aspose.com/slides/hu/net/aspose.slides/viewproperties/slideviewproperties/)), nem szakaszonként, ezért egyetlen paraméterkészlet érvényes a teljes dokumentumra a megnyitáskor.

**Előre definiálhatok különböző nézetállapotokat különböző felhasználók számára?**

Nem. A beállítások a fájlban tárolódnak, és megosztottak. A megjelenítő alkalmazások figyelembe vehetik a felhasználói beállításokat, de a fájl önmagában csak egy nézet tulajdonságkészletet tartalmaz.

**Elkészíthetek egy sablont előre definiált nézet tulajdonságokkal, hogy az új bemutatók ugyanúgy nyíljanak meg?**

Igen. Mivel a [view properties](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/viewproperties/) a bemutató szintjén tárolódnak, beágyazhatja őket egy sablonba, és új dokumentumokat hozhat létre belőle ugyanazzal a kezdeti nézetkonfigurációval.
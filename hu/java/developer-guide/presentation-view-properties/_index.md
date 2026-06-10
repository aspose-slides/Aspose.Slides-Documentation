---
title: Prezentációs nézet tulajdonságok lekérése és frissítése Java-ban
linktitle: Nézet tulajdonságok
type: docs
weight: 80
url: /hu/java/presentation-view-properties/
keywords:
  - nézet tulajdonságok
  - normál nézet
  - vázlat tartalom
  - vázlat ikonok
  - függőleges osztó rögzítése
  - egyetlen nézet
  - sáv állapot
  - dimenzió méret
  - automatikus igazítás
  - alapértelmezett nagyítás
  - PowerPoint
  - OpenDocument
  - prezentáció
  - Java
  - Aspose.Slides
description: "Ismerje meg az Aspose.Slides for Java nézet tulajdonságait, hogy testreszabhassa a PPT, PPTX és ODP formátumú diákot — módosítsa az elrendezéseket, a nagyítási szinteket és a megjelenítési beállításokat."
---
## **Bevezetés**

A normál nézet három tartalmi területből áll: maga a dia, egy oldalsó tartalmi terület, és egy alsó tartalmi terület. Tulajdonságok, amelyek a különböző tartalmi területek elhelyezkedésére vonatkoznak. Ez az információ lehetővé teszi az alkalmazás számára, hogy a nézeti állapotot a fájlba mentse, így a megnyitáskor a nézet ugyanabban az állapotban lesz, mint amikor a prezentációt utoljára mentették.

A [IViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IViewProperties#getNormalViewProperties--) metódus hozzá lett adva, hogy hozzáférést biztosítson a prezentáció normál nézet tulajdonságaihoz.

[INormalViewProperties], [INormalViewRestoredProperties] interfészek és azok leszármazottjai, valamint a [SplitterBarStateType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/SplitterBarStateType) enum hozzá lettek adva.

## **Az INormalViewProperties-ról**

A normál nézet tulajdonságait képviseli.

A [getShowOutlineIcons](https://reference.aspose.com/slides/hu/java/com.aspose.slides/INormalViewProperties#getShowOutlineIcons--) és a [setShowOutlineIcons](https://reference.aspose.com/slides/hu/java/com.aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean-) metódusok meghatározzák, hogy az alkalmazás mutasson-e ikonokat, ha a vázlat tartalmat jeleníti meg a normál nézet bármelyik tartalmi területén.

A [getSnapVerticalSplitter](https://reference.aspose.com/slides/hu/java/com.aspose.slides/INormalViewProperties#getSnapVerticalSplitter--) és a [setSnapVerticalSplitter](https://reference.aspose.com/slides/hu/java/com.aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean-) metódusok meghatározzák, hogy a függőleges osztó rács a kis méretű oldalsó terület esetén minimalizált állapotba illeszkedjen-e.

A [getPreferSingleView](https://reference.aspose.com/slides/hu/java/com.aspose.slides/INormalViewProperties#getPreferSingleView--) és a [setPreferSingleView](https://reference.aspose.com/slides/hu/java/com.aspose.slides/INormalViewProperties#setPreferSingleView-boolean-) tulajdonságok meghatározzák, hogy a felhasználó a három tartalmi területtel rendelkező standard normál nézet helyett teljesablakos, egyetlen tartalmi területtel szeretné-e látni a nézetet. Ha engedélyezve van, az alkalmazás megjelenítheti a tartalmi területek egyikét az egész ablakban.

A [getVerticalBarState](https://reference.aspose.com/slides/hu/java/com.aspose.slides/INormalViewProperties#getVerticalBarState--) és a [getHorizontalBarState](https://reference.aspose.com/slides/hu/java/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) metódusok meghatározzák, hogy a vízszintes vagy függőleges elosztó sáv milyen állapotban jelenjen meg. A vízszintes elosztó sáv elválasztja a diát a diától alul lévő tartalmi területtől, a függőleges elosztó sáv pedig a diát az oldalsó tartalmi területtől. Lehetséges értékek: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/hu/java/com.aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/hu/java/com.aspose.slides/SplitterBarStateType#Maximized) és [SplitterBarStateType.Restored](https://reference.aspose.com/slides/hu/java/com.aspose.slides/SplitterBarStateType#Restored).

A [getRestoredLeft](https://reference.aspose.com/slides/hu/java/com.aspose.slides/INormalViewProperties#getRestoredLeft--) és a [getRestoredTop](https://reference.aspose.com/slides/hu/java/com.aspose.slides/INormalViewProperties#getRestoredTop--) metódusok határozzák meg a felső vagy oldalsó diaterület méretét a normál nézetben, amikor a [SplitterBarStateType.Restored](https://reference.aspose.com/slides/hu/java/com.aspose.slides/SplitterBarStateType#Restored) érték van alkalmazva a [getVerticalBarState](https://reference.aspose.com/slides/hu/java/com.aspose.slides/INormalViewProperties#getVerticalBarState--) és a [getHorizontalBarState](https://reference.aspose.com/slides/hu/java/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) megfelelően.

## **Az INormalViewProperties visszaállítása**

Meghatározza a diaterület méretét (szélesség, ha a [getRestoredTop](https://reference.aspose.com/slides/hu/java/com.aspose.slides/INormalViewProperties#getRestoredTop--) gyermekeként, magasság, ha a [getRestoredLeft](https://reference.aspose.com/slides/hu/java/com.aspose.slides/INormalViewProperties#getRestoredLeft--) gyermekeként) a normál nézetben, amikor a terület változó visszaállított mérettel rendelkezik (sem minimalizált, sem maximalizált).

A [getDimensionSize](https://reference.aspose.com/slides/hu/java/com.aspose.slides/INormalViewRestoredProperties#getDimensionSize--) metódus meghatározza a diaterület méretét (szélesség, ha a restoredTop gyermekeként, magasság, ha a restoredLeft gyermekeként).

A [getAutoAdjust](https://reference.aspose.com/slides/hu/java/com.aspose.slides/INormalViewRestoredProperties#getAutoAdjust--) metódus meghatározza, hogy a side content terület mérete kompenzálja-e az új méretet, amikor az alkalmazáson belüli nézetet tartalmazó ablak méretét változtatják.

Az alábbi példa bemutatja, hogyan férhet hozzá a [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ViewProperties#getNormalViewProperties--) tulajdonságaihoz egy prezentáció esetén.

```java
Presentation pres = new Presentation();
try {
    pres.getViewProperties().getNormalViewProperties().setHorizontalBarState(SplitterBarStateType.Restored);
    pres.getViewProperties().getNormalViewProperties().setVerticalBarState(SplitterBarStateType.Maximized);
    
    // A prezentáció nézet tulajdonságainak visszaállítása
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setAutoAdjust(true);
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setDimensionSize(80);
    pres.getViewProperties().getNormalViewProperties().setShowOutlineIcons(true);

    pres.save("presentation_normal_view_state.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Alapértelmezett nagyítás beállítása**

{{% alert color="primary" %}} 
Az Aspose.Slides for Java most már támogatja a prezentáció alapértelmezett nagyítási értékének beállítását, így a prezentáció megnyitásakor a nagyítás már be van állítva. Ez a [ViewProperties](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ViewProperties) beállításával érhető el egy prezentációban. A [getSlideViewProperties](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ViewProperties#getSlideViewProperties--) és a [getNotesViewProperties](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ViewProperties#getNotesViewProperties--) programozottan is beállíthatók. Ebben a témában példával megmutatjuk, hogyan állítható be a [View Properties](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ViewProperties) a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation) esetén az Aspose.Slides-ben.
{{% /alert %}} 

A nézeti tulajdonságok beállításához kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a Presentation osztályból.
2. Állítsa be a [View Properties](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ViewProperties) a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation) számára.
3. Mentse a prezentációt PPTX fájlként. Az alább bemutatott példában beállítottuk a nagyítási értéket a dia nézeti és a jegyzet nézeti módhoz is.

```java
Presentation presentation = new Presentation();
try {
    // A prezentáció nézet tulajdonságainak beállítása
    presentation.getViewProperties().getSlideViewProperties().setScale(100); // Nagyítási érték százalékban a dia nézethez
    presentation.getViewProperties().getNotesViewProperties().setScale(100); // Nagyítási érték százalékban a jegyzet nézethez 

    presentation.save("Zoom_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Beállíthatok különböző nézeti beállításokat a prezentáció különböző szekcióihoz?**

A nézeti beállítások a prezentáció szintjén vannak definiálva (Normál nézet/Dia nézet), nem szekciónként, ezért egyetlen paraméterkészlet alkalmazandó a teljes dokumentumra a megnyitáskor.

**Előre meghatározhatok különböző nézeti állapotokat különböző felhasználók számára?**

Nem. A beállítások a fájlban tárolódnak és megosztottak. A megjelenítő alkalmazások figyelembe vehetik a felhasználói preferenciákat, de magában a fájl csak egyetlen nézeti tulajdonság‑készletet tartalmaz.

**Elkészíthetek egy sablont előre meghatározott nézeti tulajdonságokkal, hogy az új prezentációk ugyanúgy nyíljanak meg?**

Igen. Mivel a [view properties](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/#getViewProperties--) a prezentáció szintjén tárolódnak, beágyazhatók egy sablonba, és új dokumentumok létrehozhatók ebből ugyanazzal a kezdeti nézeti konfigurációval.
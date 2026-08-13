---
title: A bemutató nézet tulajdonságainak lekérése és frissítése Java-ban
linktitle: Nézet tulajdonságok
type: docs
weight: 80
url: /hu/java/presentation-view-properties/
keywords:
- nézet tulajdonságok
- normál nézet
- vázlat tartalom
- vázlat ikonok
- függőleges elválasztó rögzítése
- egyszerű nézet
- sáv állapot
- dimenzió méret
- automatikus igazítás
- alapértelmezett nagyítás
- PowerPoint
- OpenDocument
- bemutató
- Java
- Aspose.Slides
description: "Ismerje meg az Aspose.Slides for Java nézet tulajdonságait, amelyekkel testreszabhatja a PPT, PPTX és ODP diák formátumait - módosíthatja az elrendezéseket, a nagyítási szinteket és a megjelenítési beállításokat."
---
## **Bevezetés**

A normál nézet három tartalmi régióból áll: a diavetítés maga, egy oldalsó tartalmi régió és egy alsó tartalmi régió. A különböző tartalmi régiók elhelyezésével kapcsolatos tulajdonságok. Ezek az információk lehetővé teszik az alkalmazás számára, hogy a nézet állapotát a fájlba mentse, így a megnyitáskor a nézet ugyanabban az állapotban lesz, mint amikor a bemutatót utoljára elmentették.

Az [IViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IViewProperties#getNormalViewProperties--) metódust hozzáadták, hogy hozzáférést biztosítson a bemutató normál nézet tulajdonságaihoz.

Az [INormalViewProperties](https://reference.aspose.com/slides/hu/java/com.aspose.slides/INormalViewProperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/hu/java/com.aspose.slides/INormalViewRestoredProperties) interfészek és azok leszármazottai, valamint a [SplitterBarStateType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/SplitterBarStateType) felsorolású típus került hozzáadásra.

## **Az INormalViewProperties**

A normál nézet tulajdonságait képviseli.

A [getShowOutlineIcons](https://reference.aspose.com/slides/hu/java/com.aspose.slides/INormalViewProperties#getShowOutlineIcons--) és a [setShowOutlineIcons](https://reference.aspose.com/slides/hu/java/com.aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean-) metódusok meghatározzák, hogy az alkalmazás megjelenítse‑e az ikonokat, ha a vázlat tartalmat bármelyik tartalmi régióban a normál nézet módjában jeleníti meg.

A [getSnapVerticalSplitter](https://reference.aspose.com/slides/hu/java/com.aspose.slides/INormalViewProperties#getSnapVerticalSplitter--) és a [setSnapVerticalSplitter](https://reference.aspose.com/slides/hu/java/com.aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean-) metódusok meghatározzák, hogy a függőleges elválasztó sáv minimalizált állapotba „rázzon‑e”, amikor az oldalsó régió elég kicsi lesz.

A [getPreferSingleView](https://reference.aspose.com/slides/hu/java/com.aspose.slides/INormalViewProperties#getPreferSingleView--) és a [setPreferSingleView](https://reference.aspose.com/slides/hu/java/com.aspose.slides/INormalViewProperties#setPreferSingleView-boolean-) tulajdonság meghatározza, hogy a felhasználó egy teljes ablakos egyetlen tartalmi régiót részesít‑e előnyben a három tartalmi régióból álló szabványos normál nézettel szemben. Ha engedélyezve van, az alkalmazás egy tartalmi régiót jeleníthet meg az egész ablakban.

A [getVerticalBarState](https://reference.aspose.com/slides/hu/java/com.aspose.slides/INormalViewProperties#getVerticalBarState--) és a [getHorizontalBarState](https://reference.aspose.com/slides/hu/java/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) metódusok határozzák meg, hogy a vízszintes vagy függőleges elválasztó sáv milyen állapotban jelenjen meg. A vízszintes elválasztó sáv a diát elválasztja az alatta lévő tartalmi régiótól, a függőleges elválasztó sáv a diát az oldalra elhelyezkedő tartalmi régiótól. Lehetséges értékek: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/hu/java/com.aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/hu/java/com.aspose.slides/SplitterBarStateType#Maximized) és [SplitterBarStateType.Restored](https://reference.aspose.com/slides/hu/java/com.aspose.slides/SplitterBarStateType#Restored).

A [getRestoredLeft](https://reference.aspose.com/slides/hu/java/com.aspose.slides/INormalViewProperties#getRestoredLeft--) és a [getRestoredTop](https://reference.aspose.com/slides/hu/java/com.aspose.slides/INormalViewProperties#getRestoredTop--) metódusok határozzák meg a felső vagy oldalsó dia régió méretét a normál nézetben, amikor a [SplitterBarStateType.Restored](https://reference.aspose.com/slides/hu/java/com.aspose.slides/SplitterBarStateType#Restored) érték a [getVerticalBarState](https://reference.aspose.com/slides/hu/java/com.aspose.slides/INormalViewProperties#getVerticalBarState--) és a [getHorizontalBarState](https://reference.aspose.com/slides/hu/java/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) számára alkalmazásra kerül.

## **INormalViewProperties visszaállítása**

Meghatározza a dia régió (szélesség, ha a [getRestoredTop](https://reference.aspose.com/slides/hu/java/com.aspose.slides/INormalViewProperties#getRestoredTop--) gyermekéről van szó; magasság, ha a [getRestoredLeft](https://reference.aspose.com/slides/hu/java/com.aspose.slides/INormalViewProperties#getRestoredLeft--) gyermekéről van szó) méretét a normál nézetben, amikor a régió változó visszaállított mérettel (sem minimalizált, sem maximalizált) rendelkezik.

A [getDimensionSize](https://reference.aspose.com/slides/hu/java/com.aspose.slides/INormalViewRestoredProperties#getDimensionSize--) metódus meghatározza a dia régió méretét (szélesség, ha a restoredTop gyermekéről van szó; magasság, ha a restoredLeft gyermekéről van szó).

A [getAutoAdjust](https://reference.aspose.com/slides/hu/java/com.aspose.slides/INormalViewRestoredProperties#getAutoAdjust--) metódus meghatározza, hogy a oldalra elhelyezkedő tartalmi régió mérete kompenzálja‑e az új méretet, amikor az alkalmazáson belül a nézetet tartalmazó ablakot átméretezik.

Az alábbi példában látható, hogyan érhet meg a [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ViewProperties#getNormalViewProperties--) metódust egy bemutatóhoz.

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    pres.getViewProperties().getNormalViewProperties().setHorizontalBarState(SplitterBarStateType.Restored);
    pres.getViewProperties().getNormalViewProperties().setVerticalBarState(SplitterBarStateType.Maximized);
    
    // A bemutató nézet tulajdonságainak visszaállítása
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setAutoAdjust(true);
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setDimensionSize(80);
    pres.getViewProperties().getNormalViewProperties().setShowOutlineIcons(true);

    pres.save("presentation_normal_view_state.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Alapértelmezett nagyítási érték beállítása**

{{% alert color="info" %}} 

Az Aspose.Slides for Java most már támogatja az alapértelmezett nagyítási érték beállítását a bemutatóhoz, így a bemutató megnyitásakor a nagyítás már előre be van állítva. Ezt a [ViewProperties](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ViewProperties) beállításával lehet elérni. A [getSlideViewProperties](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ViewProperties#getSlideViewProperties--) és a [getNotesViewProperties](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ViewProperties#getNotesViewProperties--) programból is beállítható. Ebben a témában egy példán keresztül megmutatjuk, hogyan állítható be a [View Properties](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ViewProperties) a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation) számára az [Aspose.Slides](/slides/hu/) használatával.

{{% /alert %}} 

A nézet tulajdonságok beállításához kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation) osztályból.  
2. Állítsa be a [View Properties](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ViewProperties)‑t a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation) számára.  
3. Írja a bemutatót egy [PPTX](https://docs.fileformat.com/presentation/pptx/) fájlba.  
   Az alábbi példában a dianézet és a jegyzetek nézet nagyítási értékét is beállítottuk.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    // A bemutató nézet tulajdonságainak beállítása
    presentation.getViewProperties().getSlideViewProperties().setScale(100); // Nagyítás értéke százalékban a dianézethez
    presentation.getViewProperties().getNotesViewProperties().setScale(100); // Nagyítás értéke százalékban a jegyzet nézethez 

    presentation.save("Zoom_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **GYIK**

### Beállíthatok különböző nézetbeállításokat a bemutató különböző szakaszaihoz?

A [View settings](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/#getViewProperties--) a bemutató szintjén vannak definiálva ([Normal View](https://reference.aspose.com/slides/hu/java/com.aspose.slides/viewproperties/#getNormalViewProperties--)/[Slide View](https://reference.aspose.com/slides/hu/java/com.aspose.slides/viewproperties/#getSlideViewProperties--)), nem szakaszonként, így egyetlen paraméterszett alkalmazódik a teljes dokumentumra a megnyitáskor.

### Előre definiálhatok különböző nézetállapotokat különböző felhasználók számára?

Nem. A beállítások a fájlban tárolódnak, és megosztottak. A megjelenítő alkalmazások figyelembe vehetik a felhasználói preferenciákat, de a fájl csak egy nézet tulajdonságszettet tartalmaz.

### Készíthetek egy sablont előre definiált View Properties‑szel, hogy az új bemutatók ugyanúgy nyíljanak meg?

Igen. Mivel a [view properties](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/#getViewProperties--) a bemutató szintjén tárolódnak, beágyazhatók egy sablonba, és az onnan készült új dokumentumok ugyanazzal a kezdeti nézetkonfigurációval fognak megnyílni.
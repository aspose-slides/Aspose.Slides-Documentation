---
title: Prezentáció nézet tulajdonságainak lekérdezése és frissítése Androidon
linktitle: Nézet tulajdonságok
type: docs
weight: 80
url: /hu/androidjava/presentation-view-properties/
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
- OpenDocument
- bemutató
- Android
- Java
- Aspose.Slides
description: "Fedezze fel az Aspose.Slides for Android via Java nézet tulajdonságait a PPT, PPTX és ODP diák testreszabásához – állítsa be az elrendezéseket, a nagyítási szinteket és a megjelenítési beállításokat."
---
## **Bevezetés**

A normál nézet három tartalmi régióból áll: maga a dia, egy oldalsó tartalmi régió és egy alsó tartalmi régió. A különböző tartalmi régiók elhelyezésére vonatkozó tulajdonságok. Ez az információ lehetővé teszi az alkalmazás számára, hogy a nézetállapotot a fájlba mentse, így újra megnyitáskor a nézet ugyanabban az állapotban lesz, mint amikor a bemutató legutóbb el lett mentve.

A [IViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IViewProperties#getNormalViewProperties--) metódus lett hozzáadva, hogy hozzáférést biztosítson a bemutató normál nézet tulajdonságaihoz.

Az [INormalViewProperties](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/INormalViewProperties), az [INormalViewRestoredProperties](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/INormalViewRestoredProperties) interfészek és leszármazottjaik, valamint a [SplitterBarStateType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/SplitterBarStateType) felsoroló típus (enum) hozzá lett adva.

## **Az INormalViewProperties-ról**

A normál nézet tulajdonságait képviseli.

A [getShowOutlineIcons](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/INormalViewProperties#getShowOutlineIcons--) és a [setShowOutlineIcons](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean-) metódusok azt határozzák meg, hogy az alkalmazás ikonokat jelenítsen-e meg, ha a vázlat tartalmat bármelyik tartalmi régióban a normál nézet módban jeleníti meg.

A [getSnapVerticalSplitter](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/INormalViewProperties#getSnapVerticalSplitter--) és a [setSnapVerticalSplitter](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean-) metódusok azt határozzák meg, hogy a függőleges elválasztó a minimális állapotba álljon-e, amikor az oldalsó régió elég kicsi.

A [getPreferSingleView](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/INormalViewProperties#getPreferSingleView--) és a [setPreferSingleView](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/INormalViewProperties#setPreferSingleView-boolean-) tulajdonságok azt határozzák meg, hogy a felhasználó a három tartalmi régióval rendelkező szabványos normál nézet helyett egy teljes ablakot lefedő egyetlen tartalmi régiót részesíti-e előnyben. Ha engedélyezve van, az alkalmazás dönthet úgy, hogy a tartalmi régiók közül egyet az egész ablakban jeleníti meg.

A [getVerticalBarState](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/INormalViewProperties#getVerticalBarState--) és a [getHorizontalBarState](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) metódusok határozzák meg, hogy a vízszintes vagy függőleges elválasztó sáv milyen állapotban jelenjen meg. A vízszintes elválasztó sáv elválasztja a diát a dia alatti tartalmi régiótól, a függőleges elválasztó sáv elválasztja a diát az oldalsó tartalmi régiótól. Lehetséges értékek: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/SplitterBarStateType#Maximized) és [SplitterBarStateType.Restored](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/SplitterBarStateType#Restored).

A [getRestoredLeft](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/INormalViewProperties#getRestoredLeft--) és a [getRestoredTop](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/INormalViewProperties#getRestoredTop--) metódusok határozzák meg a normál nézet felső vagy oldalsó dia régiójának méretét, amikor a [SplitterBarStateType.Restored](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/SplitterBarStateType#Restored) érték alkalmazásra kerül a [getVerticalBarState](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/INormalViewProperties#getVerticalBarState--) és a [getHorizontalBarState](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) esetén.

## **Az INormalViewProperties helyreállításáról**

Meghatározza a dia régió méretét (szélesség, ha a [getRestoredTop](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/INormalViewProperties#getRestoredTop--) gyermekeként van, magasság, ha a [getRestoredLeft](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/INormalViewProperties#getRestoredLeft--) gyermekeként van) a normál nézetben, amikor a régió változó helyreállított mérettel rendelkezik (sem minimális, sem maximális állapotban).

A [getDimensionSize](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/INormalViewRestoredProperties#getDimensionSize--) metódus határozza meg a dia régió méretét (szélesség, ha a restoredTop gyermekeként van, magasság, ha a restoredLeft gyermekeként van).

A [getAutoAdjust](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/INormalViewRestoredProperties#getAutoAdjust--) metódus azt határozza meg, hogy az oldalsó tartalmi régió mérete kompenzálja-e az új méretet, amikor az alkalmazáson belül a nézetet tartalmazó ablak méretét változtatják.

Az alábbi példa bemutatja, hogyan lehet hozzáférni egy bemutató [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ViewProperties#getNormalViewProperties--) tulajdonságaihoz.

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    pres.getViewProperties().getNormalViewProperties().setHorizontalBarState(SplitterBarStateType.Restored);
    pres.getViewProperties().getNormalViewProperties().setVerticalBarState(SplitterBarStateType.Maximized);
    
    // Állítsa vissza a bemutató nézet tulajdonságait
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setAutoAdjust(true);
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setDimensionSize(80);
    pres.getViewProperties().getNormalViewProperties().setShowOutlineIcons(true);

    pres.save("presentation_normal_view_state.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Az alapértelmezett nagyítási érték beállítása**

{{% alert color="info" %}} 

Az Aspose.Slides for Android via Java most már támogatja az alapértelmezett nagyítási érték beállítását a bemutatóhoz, így amikor a bemutatót megnyitják, a nagyítás már be van állítva. Ez a [ViewProperties](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ViewProperties) egy bemutató beállításával történhet. A [getSlideViewProperties](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ViewProperties#getSlideViewProperties--) és a [getNotesViewProperties](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ViewProperties#getNotesViewProperties--) programozottan is beállítható. Ebben a témában példával megmutatjuk, hogyan állítható be a [View Properties](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ViewProperties) egy [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation) esetén a [Aspose.Slides](/slides/hu/) segítségével.

{{% /alert %}} 

A nézet tulajdonságainak beállításához kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation) osztályból.
1. Állítsa be a [View Properties](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ViewProperties) értékét a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation) számára.
1. Írja a bemutatót [PPTX](https://docs.fileformat.com/presentation/pptx/) fájlként.
   Az alább bemutatott példában a dia nézet és a jegyzet nézet nagyítási értékét állítottuk be.

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

A [View settings](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/#getViewProperties--) a bemutató szintjén vannak definiálva ([Normal View](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/viewproperties/#getNormalViewProperties--)/[Slide View](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/viewproperties/#getSlideViewProperties--)), nem szakaszonként, így egyetlen paraméterkészlet vonatkozik a teljes dokumentumra, amikor megnyílik.

### Előre definiálhatok különböző nézetállapotokat különböző felhasználók számára?

Nem. A beállítások a fájlban vannak tárolva és megosztottak. A megjelenítő alkalmazások figyelembe vehetik a felhasználói preferenciákat, de maga a fájl csak egyetlen nézet tulajdonságkészletet tartalmaz.

### Készíthetek sablont előre definiált nézet tulajdonságokkal, hogy az új bemutatók ugyanúgy nyíljanak meg?

Igen. Mivel a [view properties](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/#getViewProperties--) a bemutató szintjén vannak tárolva, beágyazhatja őket egy sablonba, és új dokumentumokat hozhat létre belőle ugyanazzal a kezdeti nézetkonfigurációval.
---
title: Előadás megjelenítési tulajdonságainak lekérése és frissítése Androidon
linktitle: Nézet tulajdonságok
type: docs
weight: 80
url: /hu/androidjava/presentation-view-properties/
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
- Android
- Java
- Aspose.Slides
description: "Fedezze fel az Aspose.Slides for Android via Java nézet tulajdonságait, hogy testre szabja a PPT, PPTX és ODP formátumú diákat – állítsa be az elrendezéseket, nagyítási szinteket és megjelenítési beállításokat."
---
## **Bevezetés**

A normál nézet három tartalmi régióból áll: a diából, egy oldalsó tartalomrégióból és egy alsó tartalomrégióból. Tulajdonságok határozzák meg a különböző tartalmi régiók elhelyezkedését. Ez az információ lehetővé teszi az alkalmazás számára, hogy a nézetállapotot a fájlba mentse, így újra megnyitáskor a nézet ugyanabban az állapotban lesz, mint amikor a prezentáció legutóbb mentésre került.

A [IViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IViewProperties#getNormalViewProperties--) metódus hozzáférést biztosít a prezentáció normál nézetének tulajdonságaihoz.  

Az [INormalViewProperties](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/INormalViewProperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/INormalViewRestoredProperties) interfészek és leszármazottaik, valamint a [SplitterBarStateType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/SplitterBarStateType) felsorolt típusa hozzá lett adva.

## **Az INormalViewProperties-ról**

A normál nézet tulajdonságait képviseli.

A [getShowOutlineIcons](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/INormalViewProperties#getShowOutlineIcons--) és a [setShowOutlineIcons](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean-) metódusok meghatározzák, hogy az alkalmazás ikonokat jelenítsen‑e, ha a vázlat tartalmat bármelyik tartalmi régióban jeleníti meg a normál nézet módban.

A [getSnapVerticalSplitter](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/INormalViewProperties#getSnapVerticalSplitter--) és a [setSnapVerticalSplitter](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean-) metódusok meghatározzák, hogy a függőleges osztó elcsúszik‑e egy minimalizált állapotba, ha az oldalsó régió elég kicsi.

A [getPreferSingleView](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/INormalViewProperties#getPreferSingleView--) és a [setPreferSingleView](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/INormalViewProperties#setPreferSingleView-boolean-) tulajdonságok meghatározzák, hogy a felhasználó egy teljesablakos, egyetlen tartalmi régiót részesít‑e előnyben a három tartalmi régióval rendelkező szabványos normál nézet helyett. Ha engedélyezve van, az alkalmazás dönthet úgy, hogy az egyik tartalmi régiót az egész ablakban jeleníti meg.

A [getVerticalBarState](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/INormalViewProperties#getVerticalBarState--) és a [getHorizontalBarState](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) metódusok megadják, hogy a vízszintes vagy függőleges osztó sáv milyen állapotban legyen látható. A vízszintes osztó sáv a diát elválasztja a diát alatti tartalmi régiótól, a függőleges osztó sáv a diát az oldalsó tartalmi régiótól. Lehetséges értékek: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/SplitterBarStateType#Maximized) és [SplitterBarStateType.Restored](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/SplitterBarStateType#Restored).

A [getRestoredLeft](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/INormalViewProperties#getRestoredLeft--) és a [getRestoredTop](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/INormalViewProperties#getRestoredTop--) metódusok határozzák meg a normál nézet felső vagy oldalsó diarégiójának méretét, amikor a [SplitterBarStateType.Restored](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/SplitterBarStateType#Restored) érték alkalmazásra kerül a [getVerticalBarState](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/INormalViewProperties#getVerticalBarState--) és a [getHorizontalBarState](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) metódusoknak megfelelően.

## **Az INormalViewProperties helyreállításáról**

Meghatározza a diarégió (szélesség, ha a [getRestoredTop](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/INormalViewProperties#getRestoredTop--) gyermekéről van szó, magasság, ha a [getRestoredLeft](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/INormalViewProperties#getRestoredLeft--) gyermekéről van szó) méretét a normál nézetben, amikor a régió változó helyreállított mérettel rendelkezik (se nem minimalizált, se nem maximalizált).

A [getDimensionSize](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/INormalViewRestoredProperties#getDimensionSize--) metódus megadja a diarégió méretét (szélesség, ha a restoredTop gyermekéről van szó, magasság, ha a restoredLeft gyermekéről van szó).

A [getAutoAdjust](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/INormalViewRestoredProperties#getAutoAdjust--) metódus azt határozza meg, hogy az oldalsó tartalmi régió mérete kompenzálja-e az új méretet az alkalmazásban a nézetet tartalmazó ablak átméretezésekor.

Az alább látható példa bemutatja, hogyan érheted el a [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ViewProperties#getNormalViewProperties--) tulajdonságait egy prezentációhoz.

```java
Presentation pres = new Presentation();
try {
    pres.getViewProperties().getNormalViewProperties().setHorizontalBarState(SplitterBarStateType.Restored);
    pres.getViewProperties().getNormalViewProperties().setVerticalBarState(SplitterBarStateType.Maximized);
    
    // A prezentáció nézet tulajdonságainak helyreállítása
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setAutoAdjust(true);
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setDimensionSize(80);
    pres.getViewProperties().getNormalViewProperties().setShowOutlineIcons(true);

    pres.save("presentation_normal_view_state.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Az alapértelmezett nagyítási érték beállítása**

{{% alert color="primary" %}} 

Az Aspose.Slides for Android via Java most már támogatja az alapértelmezett nagyítási érték beállítását a prezentációhoz, így amikor a prezentációt megnyitják, a nagyítás már be van állítva. Ez a [ViewProperties](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ViewProperties) beállításával végezhető el. A [getSlideViewProperties](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ViewProperties#getSlideViewProperties--) és a [getNotesViewProperties](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ViewProperties#getNotesViewProperties--) programozottan is beállítható. Ebben a témában egy példán keresztül megmutatjuk, hogyan állítható be a [View Properties](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ViewProperties) a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation) objektumnál az [Aspose.Slides](/slides/hu/) segítségével.

{{% /alert %}} 

A nézet tulajdonságainak beállításához kövesd az alábbi lépéseket:

1. Hozz létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation) osztályból.
1. Állítsd be a [View Properties](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ViewProperties) értékét a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation) esetén.
1. Írd ki a prezentációt [PPTX](https://docs.fileformat.com/presentation/pptx/) fájlként.  
   Az alább bemutatott példában a dianézet és a jegyzetnézet nagyítási értékét állítottuk be.

```java
Presentation presentation = new Presentation();
try {
    // A prezentáció nézet tulajdonságainak beállítása
    presentation.getViewProperties().getSlideViewProperties().setScale(100); // Nagyítás értéke százalékban a dianézethez
    presentation.getViewProperties().getNotesViewProperties().setScale(100); // Nagyítás értéke százalékban a jegyzetnézethez 

    presentation.save("Zoom_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **GYIK**

**Beállíthatok különböző nézetbeállításokat a prezentáció különböző szekcióihoz?**  

A [View settings](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/#getViewProperties--) a prezentáció szintjén vannak definiálva ([Normal View](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/viewproperties/#getNormalViewProperties--)/[Slide View](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/viewproperties/#getSlideViewProperties--)), nem szekciónként, így egyetlen paraméterkészlet alkalmazásra kerül az egész dokumentumra megnyitáskor.

**Előre meghatározhatok különböző nézetállapotokat különböző felhasználók számára?**  

Nem. A beállítások a fájlban tárolódnak, és megosztottak. A megjelenítő alkalmazások figyelembe vehetik a felhasználói preferenciákat, de a fájl maga csak egy nézettulajdonság-készletet tartalmaz.

**Létrehozhatok sablont előre definiált nézettulajdonságokkal, hogy az új prezentációk ugyanúgy nyíljanak meg?**  

Igen. Mivel a [view properties](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/#getViewProperties--) a prezentáció szintjén tárolódnak, beágyazhatod őket egy sablonba, és új dokumentumokat hozhatsz létre belőle ugyanazzal a kezdeti nézetkonfigurációval.
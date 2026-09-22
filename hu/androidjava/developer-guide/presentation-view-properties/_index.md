---
title: Prezentáció nézet tulajdonságainak lekérése és frissítése Androidon
linktitle: Nézet tulajdonságai
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
description: "Fedezze fel az Aspose.Slides for Android via Java nézet tulajdonságait a PPT, PPTX és ODP diák testreszabásához – állítsa be az elrendezéseket, a nagyítási szinteket és a megjelenítési beállításokat."
---
## **Bevezetés**

A normál nézet három tartalmi régióból áll: maga a dia, egy oldalsó tartalmi régió és egy alsó tartalmi régió. A különböző tartalmi régiók elhelyezését szabályozó tulajdonságok. Ez az információ lehetővé teszi az alkalmazás számára, hogy a nézet állapotát a fájlba mentse, így a megnyitáskor a nézet ugyanabban az állapotban lesz, mint amikor a prezentációt utoljára mentették.

Az[IViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IViewProperties#getNormalViewProperties--) metódust hozzáadtuk, hogy hozzáférést biztosítson a prezentáció normál nézetének tulajdonságaihoz.  

Az[INormalViewProperties](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/INormalViewProperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/INormalViewRestoredProperties) interfészek és azok leszármazottai, valamint a[SplitterBarStateType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/SplitterBarStateType) enum hozzá lett adva.

## **Az INormalViewProperties**

A normál nézet tulajdonságait jelenti.

A[getShowOutlineIcons](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/INormalViewProperties#getShowOutlineIcons--) és a[setShowOutlineIcons](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean-) metódusok meghatározzák, hogy az alkalmazás ikonokat jelenítsen-e, ha a vázlat tartalmat bármelyik tartalmi régióban a normál nézet módban jeleníti meg.

A[getSnapVerticalSplitter](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/INormalViewProperties#getSnapVerticalSplitter--) és a[setSnapVerticalSplitter](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean-) metódusok azt szabályozzák, hogy a függőleges osztó elvakarodjon‑e egy minimalizált állapotba, ha az oldalsó régió elég kicsi.

A[getPreferSingleView](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/INormalViewProperties#getPreferSingleView--) és a[setPreferSingleView](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/INormalViewProperties#setPreferSingleView-boolean-) tulajdonságok azt határozzák meg, hogy a felhasználó egy teljes ablakos egyetlen tartalmi régiót részesít‑e előnyben a három tartalmi régióval rendelkező normál nézettel szemben. Ha engedélyezve van, az alkalmazás egy tartalmi régiót jeleníthet meg az egész ablakban.

A[getVerticalBarState](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/INormalViewProperties#getVerticalBarState--) és a[getHorizontalBarState](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) metódusok azt határozzák meg, hogy a függőleges vagy vízszintes osztó sáv milyen állapotban jelenjen meg. A vízszintes osztó sáv elválasztja a diát az alatta lévő tartalmi régiótól, a függőleges osztó sáv az oldalsó tartalmi régiótól. Lehetséges értékek: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/SplitterBarStateType#Maximized) és [SplitterBarStateType.Restored](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/SplitterBarStateType#Restored).

A[getRestoredLeft](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/INormalViewProperties#getRestoredLeft--) és a[getRestoredTop](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/INormalViewProperties#getRestoredTop--) metódusok a normál nézet bal vagy felső diarégiójának méretét adják meg, amikor a[getVerticalBarState](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/INormalViewProperties#getVerticalBarState--) és a[getHorizontalBarState](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) értéke [SplitterBarStateType.Restored](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/SplitterBarStateType#Restored) állapotra van beállítva.

## **Az INormalViewProperties visszaállítása**

Meghatározza a diarégió (szélesség, ha a[getRestoredTop](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/INormalViewProperties#getRestoredTop--) gyermekéről van szó, magasság, ha a[getRestoredLeft](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/INormalViewProperties#getRestoredLeft--) gyermekéről van szó) méretét a normál nézetben, amikor a régió változó visszaállított mérettel rendelkezik (sem minimalizált, sem maximalizált).  

A[getDimensionSize](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/INormalViewRestoredProperties#getDimensionSize--) metódus a diarégió (szélesség, ha a restoredTop gyermekéről van szó, magasság, ha a restoredLeft gyermekéről van szó) méretét adja meg.  

A[getAutoAdjust](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/INormalViewRestoredProperties#getAutoAdjust--) metódus azt határozza meg, hogy a oldalsó tartalmi régió mérete kompenzálja‑e az új méretet, amikor az alkalmazás ablakát átméretezik.  

Az alábbi példa bemutatja, hogyan érheti el a[ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ViewProperties#getNormalViewProperties--) tulajdonságait egy prezentációhoz.

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    pres.getViewProperties().getNormalViewProperties().setHorizontalBarState(SplitterBarStateType.Restored);
    pres.getViewProperties().getNormalViewProperties().setVerticalBarState(SplitterBarStateType.Maximized);
    
    // Állítsa vissza a prezentáció nézet tulajdonságait
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

Az Aspose.Slides for Android via Java most már támogatja az alapértelmezett nagyítási érték beállítását a prezentációhoz, így a prezentáció megnyitásakor a nagyítás már előre be van állítva. Ez a [ViewProperties](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ViewProperties) beállításával érhető el. A[ViewProperties.getSlideViewProperties](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ViewProperties#getSlideViewProperties--) és a[ViewProperties.getNotesViewProperties](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ViewProperties#getNotesViewProperties--) programozottan is beállítható. Ebben a témában példával mutatjuk be, hogyan állítható be a[View Properties](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ViewProperties) egy[Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation) esetén az Aspose.Slides‑ben.

{{% /alert %}} 

A nézet tulajdonságok beállításához kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a[Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation) osztályból.  
1. Állítsa be a[View Properties](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ViewProperties) a[Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation) példányhoz.  
1. Írja a prezentációt[PPTX](https://docs.fileformat.com/presentation/pptx/) fájlként.  
   Az alábbi példában a dia nézet és a jegyzet nézet nagyítási értékét állítottuk be.

```java
import com.aspose.slides.*;

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

## **A rácstávolság beállítása**

Használja a[Presentation.getViewProperties](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/#getViewProperties--) metódust a prezentáció-szintű nézetbeállítások eléréséhez. Az[IViewProperties.getGridSpacing](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iviewproperties/#getGridSpacing--) és az[IViewProperties.setGridSpacing](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iviewproperties/#setGridSpacing-float-) metódusok az alapul szolgáló szerkesztői rács intervallumát olvassák vagy módosítják. Ez a beállítás az egész prezentációra vonatkozik, nem egyéni diára. A rácstávolság pontban van megadva, ahol 72 pont egy hüvelyknek felel meg. Pozitív értéket használjon, ahogy az API dokumentációja megköveteli.

Az alábbi példa megnyit egy meglévő `demo.pptx` fájlt, kiírja a jelenlegi rácstávolságot, egy negyed hüvelykes intervallumra állítja, majd elmenti az eredményt.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("demo.pptx");
try {
    float gridSpacing = presentation.getViewProperties().getGridSpacing();
    System.out.println("Current grid spacing: " + gridSpacing + " points");

    presentation.getViewProperties().setGridSpacing(18f);
    presentation.save("grid-spacing.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

A rács eltér a [drawing guides](/slides/hu/androidjava/drawing-guides/)‑től. A rácstávolság egy szabályos intervallumot szabályoz, míg a rajzolási segédvonalak egyenként elhelyezett vízszintes vagy függőleges igazítási vonalak. A rajzolási segédvonalak hozzáadása, áthelyezése vagy törlése nem változtatja meg a rácstávolságot.

Mind a rács, mind a rajzolási segédvonalak szerkesztői segédeszközök. Nem jelennek meg dia tartalomként PDF‑ben, képeken, SVG‑ben vagy diavetítésben. A rácstávolság tárolása nem garantálja, hogy egy szerkesztő megjeleníti a rácsot: annak láthatósága a néző vagy szerkesztő beállításaitól is függ.

## **FAQ**

**Miért nem látható a rács, amikor újra megnyitom a prezentációt?**  
A fájl tárolja a rácstávolságot, de a szerkesztő határozza meg, hogy a rács megjelenik‑e. Ellenőrizze a szerkesztő rács láthatósági beállításait.

**A rajzolási segédvonalak törlése megváltoztatja a rácstávolságot?**  
Nem. A rajzolási segédvonalak és a rácstávolság független beállítások. A segédvonalak törlése nem módosítja a tárolt rácsintervallumot.

**Beállíthatok különböző nézetbeállításokat a prezentáció különböző szekcióihoz?**  
A[View settings](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/#getViewProperties--) a prezentáció szintjén vannak definiálva ([Normal View](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/viewproperties/#getNormalViewProperties--)/[Slide View](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/viewproperties/#getSlideViewProperties--)), nem szekciónként, így egyetlen paraméterkészlet vonatkozik az egész dokumentumra megnyitáskor.

**Előre definiálhatok különböző nézetállapotokat különböző felhasználók számára?**  
Nem. A beállítások a fájlban tárolódnak és megosztottak. A megjelenítő alkalmazások tiszteletben tarthatják a felhasználói beállításokat, de maga a fájl csak egy nézet tulajdonságkészletet tartalmaz.

**Létrehozhatok sablont előre definiált nézet tulajdonságokkal, hogy az új prezentációk ugyanúgy nyíljanak meg?**  
Igen. Mivel a[view properties](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/#getViewProperties--) a prezentáció szintjén vannak tárolva, beágyazhatja őket egy sablonba, és új dokumentumok létrehozásakor ugyanazzal a kezdeti nézetkonfigurációval indulhat.
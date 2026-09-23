---
title: Prezentáció nézet tulajdonságainak lekérése és frissítése Java-ban
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
- egyedi nézet
- sáv állapot
- dimenzió méret
- automatikus igazítás
- alapértelmezett nagyítás
- PowerPoint
- OpenDocument
- prezentáció
- Java
- Aspose.Slides
description: "Fedezze fel az Aspose.Slides for Java nézet tulajdonságait a PPT, PPTX és ODP diák testreszabásához – állítsa be az elrendezéseket, a nagyítási szinteket és a megjelenítési beállításokat."
---
## **Bevezetés**

A normál nézet három tartalmi területből áll: a diából, egy oldalsó tartalmi területből és egy alsó tartalmi területből. A különböző tartalmi területek elhelyezésével kapcsolatos tulajdonságok. Ezek az információk lehetővé teszik az alkalmazás számára, hogy a nézet állapotát a fájlba mentse, így újra megnyitáskor a nézet ugyanabban az állapotban lesz, mint amikor a bemutatót legutóbb mentették.

A [IViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IViewProperties#getNormalViewProperties--) metódust hozzáadtuk, hogy hozzáférést biztosítson a bemutató normál nézetének tulajdonságaihoz.

Hozzáadtuk az [INormalViewProperties](https://reference.aspose.com/slides/hu/java/com.aspose.slides/INormalViewProperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/hu/java/com.aspose.slides/INormalViewRestoredProperties) interfészeket és azok leszármazottjait, valamint a [SplitterBarStateType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/SplitterBarStateType) felsoroló típust.

## **Az INormalViewProperties**

A normál nézet tulajdonságait képviseli.

A [getShowOutlineIcons](https://reference.aspose.com/slides/hu/java/com.aspose.slides/INormalViewProperties#getShowOutlineIcons--) és a [setShowOutlineIcons](https://reference.aspose.com/slides/hu/java/com.aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean-) metódusok meghatározzák, hogy az alkalmazás ikonokat jelenítsen-e meg, ha a normál nézet bármely tartalmi területén vázlatot jelenít meg.

A [getSnapVerticalSplitter](https://reference.aspose.com/slides/hu/java/com.aspose.slides/INormalViewProperties#getSnapVerticalSplitter--) és a [setSnapVerticalSplitter](https://reference.aspose.com/slides/hu/java/com.aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean-) metódusok meghatározzák, hogy a függőleges elválasztó a mellékleges terület elég kicsi leszésekor minimalizált állapotba ragadjon-e.

A [getPreferSingleView](https://reference.aspose.com/slides/hu/java/com.aspose.slides/INormalViewProperties#getPreferSingleView--) és a [setPreferSingleView](https://reference.aspose.com/slides/hu/java/com.aspose.slides/INormalViewProperties#setPreferSingleView-boolean-) tulajdonságok meghatározzák, hogy a felhasználó egy teljes ablakos, egyetlen tartalmi területet részesít-e előnyben a három tartalmi területet tartalmazó szabványos normál nézethez képest. Ha engedélyezve van, az alkalmazás egyik tartalmi területet is megjelenítheti az egész ablakban.

A [getVerticalBarState](https://reference.aspose.com/slides/hu/java/com.aspose.slides/INormalViewProperties#getVerticalBarState--) és a [getHorizontalBarState](https://reference.aspose.com/slides/hu/java/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) metódusok meghatározzák, hogy a vízszintes vagy függőleges elválasztó sáv milyen állapotban legyen megjelenítve. A vízszintes elválasztó sáv elválasztja a diát a diák alatti tartalmi területtől, a függőleges elválasztó sáv elválasztja a diát az oldalsó tartalmi területtől. Lehetséges értékek: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/hu/java/com.aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/hu/java/com.aspose.slides/SplitterBarStateType#Maximized) és [SplitterBarStateType.Restored](https://reference.aspose.com/slides/hu/java/com.aspose.slides/SplitterBarStateType#Restored).

A [getRestoredLeft](https://reference.aspose.com/slides/hu/java/com.aspose.slides/INormalViewProperties#getRestoredLeft--) és a [getRestoredTop](https://reference.aspose.com/slides/hu/java/com.aspose.slides/INormalViewProperties#getRestoredTop--) metódusok meghatározzák a normál nézet felső vagy oldalsó diaterületének méretét, amikor a [SplitterBarStateType.Restored](https://reference.aspose.com/slides/hu/java/com.aspose.slides/SplitterBarStateType#Restored) érték alkalmazásra kerül a [getVerticalBarState](https://reference.aspose.com/slides/hu/java/com.aspose.slides/INormalViewProperties#getVerticalBarState--) és a [getHorizontalBarState](https://reference.aspose.com/slides/hu/java/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) esetén.

## **Az INormalViewProperties helyreállítása**

Meghatározza a normál nézet diaterületének méretét (szélesség, ha a [getRestoredTop](https://reference.aspose.com/slides/hu/java/com.aspose.slides/INormalViewProperties#getRestoredTop--) gyermekéről van szó, magasság, ha a [getRestoredLeft](https://reference.aspose.com/slides/hu/java/com.aspose.slides/INormalViewProperties#getRestoredLeft--) gyermekéről van szó), amikor a terület változó helyreállított méretekkel rendelkezik (sem minimalizált, sem maximalizált).

A [getDimensionSize](https://reference.aspose.com/slides/hu/java/com.aspose.slides/INormalViewRestoredProperties#getDimensionSize--) metódus a diaterület méretét adja meg (szélesség a restoredTop esetén, magasság a restoredLeft esetén).

A [getAutoAdjust](https://reference.aspose.com/slides/hu/java/com.aspose.slides/INormalViewRestoredProperties#getAutoAdjust--) metódus meghatározza, hogy az oldalsó tartalmi terület mérete kompenzálja-e az új méretet a nézetet tartalmazó ablak átméretezésekor az alkalmazáson belül.

Az alább bemutatott példa azt mutatja, hogyan érheti el a [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ViewProperties#getNormalViewProperties--) tulajdonságait egy bemutató számára.

```java
import com.aspose.slides.*;

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

## **Az alapértelmezett nagyítási érték beállítása**

{{% alert color="info" %}} 

Az Aspose.Slides for Java most már támogatja a prezentáció alapértelmezett nagyítási értékének beállítását, így a bemutató megnyitásakor a nagyítás már be van állítva. Ez a [ViewProperties](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ViewProperties) beállításával érhető el egy prezentációban. A [getSlideViewProperties](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ViewProperties#getSlideViewProperties--) és a [getNotesViewProperties](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ViewProperties#getNotesViewProperties--) programozottan is beállítható. Ebben a témában egy példán keresztül megmutatjuk, hogyan állítható be a [View Properties](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ViewProperties) a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation) objektumban az Aspose.Slides használatával.

{{% /alert %}} 

A nézet tulajdonságok beállításához kövesse az alábbi lépéseket:

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation) osztálypéldányt.
1. Állítsa be a [View Properties](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ViewProperties) értékét a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation) számára.
1. Írja ki a prezentációt egy [PPTX](https://docs.fileformat.com/presentation/pptx/) fájlként. Az alább látható példában beállítottuk a nagyítási értéket a dia- és a jegyzetnézethez is.

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

## **A rács távolság beállítása**

Használja a [Presentation.getViewProperties](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/#getViewProperties--) metódust a prezentáció szintű nézeti beállítások eléréséhez. Az [IViewProperties.getGridSpacing](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iviewproperties/#getGridSpacing--) és az [IViewProperties.setGridSpacing](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iviewproperties/#setGridSpacing-float-) metódusok olvassák vagy módosítják az alaprendszer szerkesztő rácsának intervallumát. Ez a beállítás a teljes prezentációra vonatkozik, nem egyetlen diara. A rács távolságát pontban adjuk meg, ahol 72 pont egy hüvelyknek felel meg. Pozitív értéket használjon, ahogy azt az API dokumentációja előírja.

Az alábbi példa megnyit egy meglévő `demo.pptx` fájlt, kiírja a jelenlegi rács távolságát, egy negyed hüvelykes intervallumra állítja, majd elmenti az eredményt.

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

A rács különbözik a [drawing guides](/slides/hu/java/drawing-guides/) útmutatóktól. A rács távolsága egy szabályos intervallumot szabályoz, míg a rajzoló útmutatók egyenként elhelyezett vízszintes vagy függőleges igazítási vonalak. Útmutatók hozzáadása, mozgatása vagy törlése nem változtatja meg a rács távolságát.

Mind a rács, mind a rajzoló útmutatók szerkesztési segédeszközök. Nem jelennek meg dia tartalomként PDF‑ben, képekben, SVG‑ben vagy diavetítésben. A rács távolságának tárolása nem garantálja, hogy egy szerkesztő megjeleníti a rácsot: láthatósága a megjelenítő vagy szerkesztő beállításaitól is függ.

## **Megjegyzések megjelenítése vagy elrejtése bemutató megnyitásakor**

Használja a [Presentation.getViewProperties](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/#getViewProperties--) metódust a prezentáció szintű nézeti beállítások eléréséhez. A [IViewProperties.getShowComments](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iviewproperties/#getShowComments--) és a [IViewProperties.setShowComments](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iviewproperties/#setShowComments-byte-) segítségével olvashatja vagy módosíthatja a tárolt beállítást arról, hogy a megjegyzéseket meg kell‑e jeleníteni a PowerPoint vagy más kompatibilis szerkesztő megnyitásakor.

Ez a beállítás csak a tárolt nézeti előnyben részesítést szabályozza. Nem ad hozzá, nem távolít el, nem szerkeszt és nem old meg megjegyzéseket. A megjegyzések elrejtése megőrzi azok tartalmát, szerzőit, pozícióit, válaszait és állapotát. Lásd a [Presentation Comments](/slides/hu/java/presentation-comments/) oldalt a megjegyzéseken végzett műveletekért.

Az alábbi példához egy meglévő `comments.pptx` fájl szükséges, amely megjegyzéseket tartalmaz. Kiírja a jelenlegi láthatósági beállítást, elrejti a megjegyzéseket, és egy új PPTX‑et ment anélkül, hogy a megjegyzéseket eltávolítaná. Emellett a [IViewProperties.setLastView](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iviewproperties/#setLastView-int-) metódust a [ViewType.SlideView](https://reference.aspose.com/slides/hu/java/com.aspose.slides/viewtype/#SlideView) értékkel használja a kezdeti szerkesztő nézet és a megjegyzés‑láthatóság konfigurálásához.

```java
import com.aspose.slides.NullableBool;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ViewType;

Presentation presentation = new Presentation("comments.pptx");
try {
    byte showComments = presentation.getViewProperties().getShowComments();
    System.out.println("Current comment visibility: " + showComments);

    presentation.getViewProperties().setShowComments(NullableBool.False);
    presentation.getViewProperties().setLastView(ViewType.SlideView);
    presentation.save("comments-hidden.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Ez a beállítás nem határozza meg, hogy a megjegyzések szerepelnek‑e a PDF, HTML, kép, jegyzet vagy szórólap exportokban. A megfelelő export‑specifikus beállításokat külön kell konfigurálni.

## **GYIK**

**Miért nem látható a rács a bemutató újranyitása után?**

A fájl tárolja a rács távolságát, de a szerkesztő szabályozza, hogy a rács megjelenjen‑e. Ellenőrizze a szerkesztő rács láthatósági beállításait.

**A rajzoló útmutatók törlése megváltoztatja‑e a rács távolságát?**

Nem. A rajzoló útmutatók és a rács távolsága független beállítások. Az útmutatók törlése nem módosítja a tárolt rács intervallumát.

**Beállíthatok‑e különböző nézeti beállításokat a prezentáció különböző szekcióihoz?**

A [View settings](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/#getViewProperties--) a prezentáció szintjén (Normál nézet / Dia nézet) kerülnek definiálásra, nem szekciónként, így egyetlen paraméterkészlet vonatkozik a dokumentum egészére megnyitáskor.

**Előre definiálhatok‑e különböző nézeti állapotokat különböző felhasználók számára?**

Nem. A beállítások a fájlban vannak tárolva és megosztottak. A megjelenítő alkalmazások tiszteletben tarthatják a felhasználói preferenciákat, de a fájl önmagában csak egy nézet tulajdonságkészletet tartalmaz.

**Készíthetek‑e sablont előre definiált View Properties‑sal, hogy az új prezentációk ugyanúgy nyíljanak meg?**

Igen. Mivel a [view properties](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/#getViewProperties--) a prezentáció szintjén vannak tárolva, beágyazhatsz őket egy sablonba, és új dokumentumokat hozhatsz létre belőle ugyanazzal a kezdeti nézeti konfigurációval.
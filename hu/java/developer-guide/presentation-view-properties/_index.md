---
title: Prezentáció nézet tulajdonságainak lekérdezése és frissítése Java-ban
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
- egyszemélyes nézet
- sáv állapot
- dimenzió méret
- automatikus igazítás
- alapértelmezett nagyítás
- PowerPoint
- OpenDocument
- prezentáció
- Java
- Aspose.Slides
description: "Fedezze fel az Aspose.Slides for Java nézet tulajdonságait, hogy testre szabja a PPT, PPTX és ODP diák formátumait – állítsa be az elrendezéseket, nagyítási szinteket és megjelenítési beállításokat."
---
## **Bevezetés**

A normál nézet három tartalmi régióból áll: magából a diából, egy oldalsó tartalmi régióból és egy alsó tartalmi régióból. A különböző tartalmi régiók elhelyezkedését meghatározó tulajdonságok. Ez az információ lehetővé teszi az alkalmazás számára, hogy a nézet állapotát elmentse a fájlba, így a megnyitáskor a nézet ugyanabban az állapotban lesz, mint amikor a prezentációt legutóbb mentették.

A [IViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IViewProperties#getNormalViewProperties--) metódus került hozzáadásra, hogy hozzáférést biztosítson a prezentáció normál nézetének tulajdonságaihoz.  

Az [INormalViewProperties](https://reference.aspose.com/slides/hu/java/com.aspose.slides/INormalViewProperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/hu/java/com.aspose.slides/INormalViewRestoredProperties) interfészek és leszármazottaik, valamint a [SplitterBarStateType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/SplitterBarStateType) felsorolt típusa került hozzáadásra.

## **Az INormalViewProperties névjegye**

A normál nézet tulajdonságait képviseli.

A [getShowOutlineIcons](https://reference.aspose.com/slides/hu/java/com.aspose.slides/INormalViewProperties#getShowOutlineIcons--) és a [setShowOutlineIcons](https://reference.aspose.com/slides/hu/java/com.aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean-) metódusok határozzák meg, hogy az alkalmazás ikont jelenítsen‑e meg, ha vázlat tartalmat jelenít meg bármelyik tartalmi régióban a normál nézet módjában.

A [getSnapVerticalSplitter](https://reference.aspose.com/slides/hu/java/com.aspose.slides/INormalViewProperties#getSnapVerticalSplitter--) és a [setSnapVerticalSplitter](https://reference.aspose.com/slides/hu/java/com.aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean-) metódusok határozzák meg, hogy a függőleges osztó átváljon‑e minimalizált állapotba, ha az oldalsó régió elég kicsi.

A [getPreferSingleView](https://reference.aspose.com/slides/hu/java/com.aspose.slides/INormalViewProperties#getPreferSingleView--) és a [setPreferSingleView](https://reference.aspose.com/slides/hu/java/com.aspose.slides/INormalViewProperties#setPreferSingleView-boolean-) tulajdonságok határozzák meg, hogy a felhasználó egy teljes ablakos egyetlen tartalmi régiót részesít‑e előnyben a három tartalmi régióval rendelkező szokásos normál nézettel szemben. Ha engedélyezve van, az alkalmazás egy tartalmi régiót jeleníthet meg az egész ablakban.

A [getVerticalBarState](https://reference.aspose.com/slides/hu/java/com.aspose.slides/INormalViewProperties#getVerticalBarState--) és a [getHorizontalBarState](https://reference.aspose.com/slides/hu/java/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) metódusok határozzák meg, hogy a vízszintes vagy függőleges osztó sáv milyen állapotban legyen látható. A vízszintes osztó sáv elválasztja a diát a diák alatti tartalmi régiótól, a függőleges osztó sáv pedig a diát az oldalsó tartalmi régiótól. Lehetséges értékek: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/hu/java/com.aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/hu/java/com.aspose.slides/SplitterBarStateType#Maximized) és [SplitterBarStateType.Restored](https://reference.aspose.com/slides/hu/java/com.aspose.slides/SplitterBarStateType#Restored).

A [getRestoredLeft](https://reference.aspose.com/slides/hu/java/com.aspose.slides/INormalViewProperties#getRestoredLeft--) és a [getRestoredTop](https://reference.aspose.com/slides/hu/java/com.aspose.slides/INormalViewProperties#getRestoredTop--) metódusok határozzák meg a normál nézet felső vagy oldalsó diarégiójának méretét, amikor a [SplitterBarStateType.Restored](https://reference.aspose.com/slides/hu/java/com.aspose.slides/SplitterBarStateType#Restored) érték van alkalmazva a [getVerticalBarState](https://reference.aspose.com/slides/hu/java/com.aspose.slides/INormalViewProperties#getVerticalBarState--) és a [getHorizontalBarState](https://reference.aspose.com/slides/hu/java/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) metódusokra vonatkozóan.

## **Az INormalViewProperties visszaállítása**

A diarégió (szélesség, ha a [getRestoredTop](https://reference.aspose.com/slides/hu/java/com.aspose.slides/INormalViewProperties#getRestoredTop--) gyermekéről van szó, magasság, ha a [getRestoredLeft](https://reference.aspose.com/slides/hu/java/com.aspose.slides/INormalViewProperties#getRestoredLeft--) gyermekéről van szó) méretezését határozza meg a normál nézetben, amikor a régió változó visszaállított mérettel rendelkezik (sem minimalizált, sem maximalizált).

A [getDimensionSize](https://reference.aspose.com/slides/hu/java/com.aspose.slides/INormalViewRestoredProperties#getDimensionSize--) metódus meghatározza a diarégió méretét (szélesség, ha a restoredTop gyermekéről van szó, magasság, ha a restoredLeft gyermekéről van szó).

A [getAutoAdjust](https://reference.aspose.com/slides/hu/java/com.aspose.slides/INormalViewRestoredProperties#getAutoAdjust--) metódus meghatározza, hogy az oldalsó tartalmi régió mérete kompenzálja‑e az új méretet az ablak átméretezésekor, amely a nézetet tartalmazza az alkalmazásban.

Az alábbi példában látható, hogyan lehet elérni a [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ViewProperties#getNormalViewProperties--) tulajdonságait egy prezentációhoz.

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    pres.getViewProperties().getNormalViewProperties().setHorizontalBarState(SplitterBarStateType.Restored);
    pres.getViewProperties().getNormalViewProperties().setVerticalBarState(SplitterBarStateType.Maximized);
    
    // Visszaállítja a prezentáció nézet tulajdonságait
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

Az Aspose.Slides for Java most már támogatja az alapértelmezett nagyítási érték beállítását a prezentációk számára úgy, hogy a prezentáció megnyitásakor a nagyítás már be legyen állítva. Ez a [ViewProperties](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ViewProperties) beállításával történik. A [getSlideViewProperties](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ViewProperties#getSlideViewProperties--) és a [getNotesViewProperties](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ViewProperties#getNotesViewProperties--) programozottan is beállítható. Ebben a témában egy példán keresztül mutatjuk be, hogyan kell beállítani a [View Properties](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ViewProperties)-t egy [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation) esetében az Aspose.Slides‑ben.

{{% /alert %}} 

A nézet tulajdonságok beállításához kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation) osztályból.
1. Állítsa be a [View Properties](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ViewProperties)-t a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation)-hez.
1. Mentse a prezentációt egy [PPTX](https://docs.fileformat.com/presentation/pptx/) fájlba.  
   Az alább látható példában beállítottuk a nagyítási értéket a dianézethez és a jegyzetek nézetéhez.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    // A prezentáció nézet tulajdonságainak beállítása
    presentation.getViewProperties().getSlideViewProperties().setScale(100); // Nagyítási érték százalékban a dianézethez
    presentation.getViewProperties().getNotesViewProperties().setScale(100); // Nagyítási érték százalékban a jegyzetek nézetéhez

    presentation.save("Zoom_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Rács távolság beállítása**

Használja a [Presentation.getViewProperties](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/#getViewProperties--) metódust a prezentáció szintű nézetbeállítások eléréséhez. Az [IViewProperties.getGridSpacing](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iviewproperties/#getGridSpacing--) és az [IViewProperties.setGridSpacing](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iviewproperties/#setGridSpacing-float-) metódusok olvassák vagy módosítják az alaprendszer szerkesztő rácsának intervallumát. Ez a beállítás az egész prezentációra vonatkozik, nem egyetlen diára. A rács távolsága pontokban van megadva, ahol 72 pont egy hüvelyknek felel meg. Pozitív értéket használjon, ahogy az API dokumentáció előírja.

Az alábbi példa megnyit egy meglévő `demo.pptx` fájlt, kiírja a jelenlegi rács távolságát, beállít egy negyed hüvelykes intervallumot, majd elmenti az eredményt.

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

A rács különbözik a [drawing guides](/slides/hu/java/drawing-guides/) elemtől. A rács távolsága szabályos intervallumot szabályoz, míg a vezetővonalak egyedi, vízszintes vagy függőleges igazítású vonalak. A vezetővonalak hozzáadása, mozgatása vagy törlése nem változtatja meg a rács távolságát.

A rács és a vezetővonalak is szerkesztési segédeszközök. Nem jelennek meg dia tartalomként PDF‑ben, képeken, SVG‑ben vagy diavetítésben. A rács távolságának tárolása önmagában nem garantálja, hogy egy szerkesztő megjeleníti a rácsot: a láthatóság a megjelenítő vagy szerkesztő beállításaitól is függ.

## **GYIK**

**Miért nem látható a rács a prezentáció újramozgása után?**

A fájl tárolja a rács távolságát, de a szerkesztő szabályozza, hogy a rács megjelenjen‑e. Ellenőrizze a szerkesztő rács láthatósági beállításait.

**A vezetővonalak törlése megváltoztatja a rács távolságát?**

Nem. A vezetővonalak és a rács távolsága független beállítások. A vezetővonalak törlése nem módosítja a tárolt rács intervallumot.

**Beállíthatok különböző nézetbeállításokat a prezentáció különböző szakaszaira?**

A [View settings](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/#getViewProperties--) a prezentáció szintjén vannak definiálva ([Normal View](https://reference.aspose.com/slides/hu/java/com.aspose.slides/viewproperties/#getNormalViewProperties--)/[Slide View](https://reference.aspose.com/slides/hu/java/com.aspose.slides/viewproperties/#getSlideViewProperties--)), nem szakaszonként, ezért egyetlen paraméterkészlet vonatkozik a teljes dokumentumra a megnyitáskor.

**Előre definiálhatok különböző nézetállapotokat különböző felhasználók számára?**

Nem. A beállítások a fájlban vannak tárolva, és megosztottak. A megjelenítő alkalmazások figyelembe vehetik a felhasználói preferenciákat, de a fájl maga csak egy nézettulajdonság‑készletet tartalmaz.

**Készíthetek-e sablont előre definiált View Properties‑szel, hogy az új prezentációk ugyanúgy nyíljanak meg?**

Igen. Mivel a [view properties](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/#getViewProperties--) a prezentáció szintjén vannak tárolva, beágyazhatja őket egy sablonba, és új dokumentumokat hozhat létre belőle ugyanazzal a kezdeti nézetkonfigurációval.
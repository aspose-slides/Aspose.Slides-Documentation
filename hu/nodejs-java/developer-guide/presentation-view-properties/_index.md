---
title: Prezentáció Nézet Tulajdonságainak Lekérdezése és Frissítése JavaScript-ben
linktitle: Nézet Tulajdonságok
type: docs
weight: 80
url: /hu/nodejs-java/presentation-view-properties/
keywords: 
- nézet tulajdonságok
- normál nézet
- vázlat tartalom
- vázlat ikonok
- függőleges osztó rögzítése
- egyes nézet
- sáv állapot
- dimenzió méret
- automatikus igazítás
- alapértelmezett nagyítás
- PowerPoint
- OpenDocument
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Fedezze fel az Aspose.Slides for Node.js via Java nézet tulajdonságait, hogy testreszabja a PPT, PPTX és ODP diákat—állítsa be az elrendezéseket, nagyítási szinteket és megjelenítési beállításokat."
---
## **Bevezetés**

A normál nézet három tartalmi területből áll: a diából, egy oldalsó tartalmi területről és egy alsó tartalmi területről. Az egyes tartalmi területek elhelyezésével kapcsolatos tulajdonságok. Ez az információ lehetővé teszi az alkalmazás számára, hogy elmentse a nézet állapotát a fájlba, így újra megnyitáskor a nézet ugyanabban az állapotban lesz, mint amikor a prezentációt utoljára mentették.

A [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ViewProperties#getNormalViewProperties--) metódus hozzá lett adva, hogy hozzáférést biztosítson a prezentáció normál nézet tulajdonságaihoz.

A [NormalViewProperties](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/NormalViewProperties), [NormalViewRestoredProperties](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/NormalViewRestoredProperties) osztályok és azok leszármazottai, valamint a [SplitterBarStateType](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/SplitterBarStateType) felsoroló típus hozzá lettek adva.

## **A NormalViewProperties osztályról**

A normál nézet tulajdonságait képviseli.

A [getShowOutlineIcons](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/NormalViewProperties#getShowOutlineIcons--) és a [setShowOutlineIcons](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/NormalViewProperties#setShowOutlineIcons-boolean-) metódusok meghatározzák, hogy az alkalmazás ikonokat jelenítsen-e, ha vázlat tartalmat jelenít meg a normál nézet bármelyik tartalmi területén.

A [getSnapVerticalSplitter](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/NormalViewProperties#getSnapVerticalSplitter--) és a [setSnapVerticalSplitter](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/NormalViewProperties#setSnapVerticalSplitter-boolean-) metódusok meghatározzák, hogy a függőleges osztó elmozduljon-e egy minimalizált állapotba, ha az oldalsó régió elég kicsi.

A [getPreferSingleView](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/NormalViewProperties#getPreferSingleView--) és a [setPreferSingleView](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/NormalViewProperties#setPreferSingleView-boolean--) tulajdonságok meghatározzák, hogy a felhasználó előnyben részesíti-e egy teljes ablakos egyetlen tartalmi régió megjelenítését a szokásos három tartalmi régióval rendelkező normál nézettel szemben. Ha engedélyezve van, az alkalmazás egy tartalmi régiót megjeleníthet az egész ablakban.

A [getVerticalBarState](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/NormalViewProperties#getVerticalBarState--) és a [getHorizontalBarState](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/NormalViewProperties#getHorizontalBarState--) metódusok meghatározzák, hogy a vízszintes vagy függőleges osztó sáv milyen állapotban legyen látható. A vízszintes osztó a diától elválasztja az alatta lévő tartalmi régiót, a függőleges osztó a diától elválasztja az oldalsó tartalmi régiót. Lehetséges értékek: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/SplitterBarStateType#Maximized) és [SplitterBarStateType.Restored](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/SplitterBarStateType#Restored).

A [getRestoredLeft](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/NormalViewProperties#getRestoredLeft--) és a [getRestoredTop](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/NormalViewProperties#getRestoredTop--) metódusok határozzák meg a normál nézet felső vagy oldalsó diaterületének méretét, amikor a [SplitterBarStateType.Restored](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/SplitterBarStateType#Restored) érték alkalmazásra kerül a [getVerticalBarState](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/NormalViewProperties#getVerticalBarState--) és a [getHorizontalBarState](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/NormalViewProperties#getHorizontalBarState--) esetén.

## **A NormalViewProperties helyreállításáról**

Meghatározza a diaterület (szélesség, ha a [getRestoredTop](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/NormalViewProperties#getRestoredTop--) gyermeke, magasság, ha a [getRestoredLeft](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/NormalViewProperties#getRestoredLeft--) gyermeke) méretét a normál nézetben, amikor a régió változó helyreállított mérettel rendelkezik (sem minimalizált, sem maximalizált).

A [getDimensionSize](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/NormalViewRestoredProperties#getDimensionSize--) metódus megadja a diaterület méretét (szélesség, ha a restoredTop gyermeke, magasság, ha a restoredLeft gyermeke).

A [getAutoAdjust](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/NormalViewRestoredProperties#getAutoAdjust--) metódus meghatározza, hogy az oldalsó tartalmi régió mérete kompenzálja-e az új méretet az ablak átméretezésekor, amely a nézetet tartalmazza az alkalmazásban.

Az alábbi példa azt mutatja, hogyan lehet hozzáférni a [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ViewProperties#getNormalViewProperties--) tulajdonságokhoz egy prezentáció esetén.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    pres.getViewProperties().getNormalViewProperties().setHorizontalBarState(aspose.slides.SplitterBarStateType.Restored);
    pres.getViewProperties().getNormalViewProperties().setVerticalBarState(aspose.slides.SplitterBarStateType.Maximized);

    // A prezentáció nézet tulajdonságainak helyreállítása
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setAutoAdjust(true);
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setDimensionSize(80);
    pres.getViewProperties().getNormalViewProperties().setShowOutlineIcons(true);
    pres.save("presentation_normal_view_state.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```
## **Alapértelmezett nagyítási érték beállítása**

{{% alert color="info" %}} 

Az Aspose.Slides for Node.js via Java most már támogatja az alapértelmezett nagyítási érték beállítását a prezentációhoz, így a prezentáció megnyitásakor a nagyítás már be van állítva. Ez a [ViewProperties](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ViewProperties) beállításával érhető el. A [getSlideViewProperties](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ViewProperties#getSlideViewProperties--) valamint a [getNotesViewProperties](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ViewProperties#getNotesViewProperties--) programozottan is beállítható. Ebben a témában egy példán keresztül megmutatjuk, hogyan állítható a [View Properties](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ViewProperties) a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation) esetében az Aspose.Slides-ben.

{{% /alert %}} 

A nézet tulajdonságainak beállításához kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation) osztályból.
1. Állítsa be a [View Properties](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ViewProperties) értékét a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation) esetében.
1. Írja a prezentációt egy [PPTX](https://docs.fileformat.com/presentation/pptx/) fájlba.
   Az alábbi példában a dianézet és a jegyzetek nézet nagyítási értékét állítottuk be.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    // A prezentáció nézet tulajdonságainak beállítása
    presentation.getViewProperties().getSlideViewProperties().setScale(100); // Nagyítási érték százalékban a dianézethez
    presentation.getViewProperties().getNotesViewProperties().setScale(100); // Nagyítási érték százalékban a jegyzet nézethez
    presentation.save("Zoom_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```
## **A rács távolságának beállítása**

Használja a [Presentation.getViewProperties](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/#getViewProperties--) metódust a prezentáció‑szintű nézetbeállítások eléréséhez. A [ViewProperties.getGridSpacing](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/viewproperties/#getGridSpacing--) és a [ViewProperties.setGridSpacing](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/viewproperties/#setGridSpacing-float-) metódusok a háttérben lévő szerkesztői rács intervallumát olvassák vagy módosítják. Ez a beállítás a teljes prezentációra vonatkozik, nem egyetlen diára. A rács távolsága pontban van megadva, ahol 72 pont egy hüvelyknek felel meg. Pozitív értéket használjon, ahogy az API dokumentáció is előírja.

Az alábbi példa megnyit egy meglévő `demo.pptx` fájlt, kiírja a jelenlegi rács távolságát, beállít egy negyed hüvelykes intervallumot, majd elmenti az eredményt.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("demo.pptx");
try {
    var gridSpacing = presentation.getViewProperties().getGridSpacing();
    console.log("Current grid spacing: " + gridSpacing + " points");

    presentation.getViewProperties().setGridSpacing(18);
    presentation.save("grid-spacing.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

A rács különbözik a [drawing guides](/slides/hu/nodejs-java/drawing-guides/) elemtől. A rács távolsága szabályos intervallumot szabályoz, míg a rajzvezetők egyedi, vízszintes vagy függőleges igazítási vonalak. A rajzvezetők hozzáadása, mozgatása vagy törlése nem változtatja a rács távolságát.

A rács és a rajzvezetők egyaránt szerkesztési segédeszközök. Nem jelennek meg dia‑tartalomként PDF‑ben, képekben, SVG‑ben vagy diavetítésben. A rács távolságának tárolása nem garantálja, hogy egy szerkesztő megjeleníti a rácsot: láthatósága a megjelenítő vagy szerkesztő beállításaitól is függ.

## **Megjegyzések megjelenítése vagy elrejtése a prezentáció megnyitásakor**

Használja a [Presentation.getViewProperties](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/#getViewProperties--) metódust a prezentáció‑szintű nézetbeállítások eléréséhez. A [ViewProperties.getShowComments](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/viewproperties/#getShowComments--) és a [ViewProperties.setShowComments](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/viewproperties/#setShowComments-byte-) segítségével olvashatja vagy módosíthatja azt a tárolt beállítást, hogy a megjegyzések megjelenjenek‑e, amikor a prezentációt a PowerPoint vagy egy másik kompatibilis szerkesztő nyitja meg.

Ez a beállítás csak a tárolt nézet‑preferenciát szabályozza. Nem ad hozzá, nem távolít el, nem szerkeszt és nem old meg megjegyzéseket. A megjegyzések elrejtése megőrzi azok tartalmát, szerzőit, pozícióit, válaszait és állapotát. A megjegyzéseket módosító műveletekért tekintse meg a [Presentation Comments](/slides/hu/nodejs-java/presentation-comments/) oldalt.

Az alábbi példa egy létező `comments.pptx` fájlt igényel, amely megjegyzéseket tartalmaz. Kiírja a jelenlegi láthatósági beállítást, kéri a megjegyzések elrejtését, és új PPTX‑et ment anélkül, hogy bármely megjegyzést eltávolítana. Emellett a [ViewProperties.setLastView](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/viewproperties/#setLastView-int-) metódust a [ViewType.SlideView](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/viewtype/#SlideView) értékkel használja az elsődleges szerkesztői nézet beállításához a megjegyzés láthatóságával együtt.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new aspose.slides.Presentation("comments.pptx");
try {
    var showComments = presentation.getViewProperties().getShowComments();
    console.log("Current comment visibility: " + showComments);

    var hideComments = java.newByte(aspose.slides.NullableBool.False);
    presentation.getViewProperties().setShowComments(hideComments);
    presentation.getViewProperties().setLastView(aspose.slides.ViewType.SlideView);
    presentation.save("comments-hidden.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Ez a beállítás nem határozza meg, hogy a megjegyzések bekerülnek‑e a PDF, HTML, kép, jegyzet vagy szórólap exportba. A megfelelő export‑specifikus opciókat külön kell konfigurálni.

## **GYIK**

**Miért nem látható a rács a prezentáció újranyitása után?**  
A fájl tárolja a rács távolságát, de a szerkesztő dönti el, hogy a rács megjelenik‑e. Ellenőrizze a szerkesztő rács‑láthatósági beállításait.

**A rajzvezetők törlése megváltoztatja a rács távolságát?**  
Nem. A rajzvezetők és a rács távolsága független beállítások. A vezetők törlése nem változtatja a tárolt rács intervallumot.

**Beállíthatok különböző nézetbeállításokat a prezentáció különböző szakaszaihoz?**  
A [View settings](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/getviewproperties/) a prezentáció szintjén vannak definiálva ([Normal View](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/viewproperties/getnormalviewproperties/)/[Slide View](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/viewproperties/getslideviewproperties/)), nem szakaszonként, ezért egyetlen paraméterkészlet vonatkozik a teljes dokumentumra, amikor megnyílik.

**Előre definiálhatok különböző nézetállapotokat különböző felhasználók számára?**  
Nem. A beállítások a fájlban tárolódnak, és megosztottak. A megjelenítő alkalmazások tiszteletben tarthatják a felhasználói preferenciákat, de a fájl önmagában csak egy nézet‑tulajdonság‑készletet tartalmaz.

**Készíthetek sablont előre definiált Nézet tulajdonságokkal, hogy az új prezentációk ugyanígy nyíljanak meg?**  
Igen. Mivel a [view properties](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/getviewproperties/) a prezentáció szintjén vannak tárolva, beágyazhatja őket egy sablonba, és új dokumentumokat hozhat létre belőle ugyanazzal a kezdeti nézet‑konfigurációval.
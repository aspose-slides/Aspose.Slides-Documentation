---
title: Prezentáció nézet tulajdonságainak lekérése és frissítése JavaScript-ben
linktitle: Nézet tulajdonságok
type: docs
weight: 80
url: /hu/nodejs-java/presentation-view-properties/
keywords:
- nézet tulajdonságok
- normál nézet
- vázlat tartalom
- vázlat ikonok
- függőleges elválasztó snapelése
- egyes nézet
- sáv állapota
- dimenzió mérete
- automatikus beállítás
- alapértelmezett nagyítás
- PowerPoint
- OpenDocument
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Fedezze fel az Aspose.Slides for Node.js via Java nézet tulajdonságait a PPT, PPTX és ODP diák testreszabásához – állítsa be az elrendezéseket, a nagyítási szinteket és a megjelenítési beállításokat."
---
## **Bevezetés**

A normál nézet három tartalmi területből áll: a diából, egy oldalsó tartalomrégióból és egy alsó tartalomrégióból. A különböző tartalmi régiók elhelyezésével kapcsolatos tulajdonságok. Ez az információ lehetővé teszi az alkalmazás számára, hogy a nézetállapotot a fájlba mentse, így a megnyitáskor a nézet ugyanabban az állapotban lesz, mint amikor a prezentációt legutóbb mentették.

A [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ViewProperties#getNormalViewProperties--) metódus hozzá lett adva, amely hozzáférést biztosít a prezentáció normál nézetének tulajdonságaihoz.

Hozzá lettek adva a [NormalViewProperties](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/NormalViewProperties), a [NormalViewRestoredProperties](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/NormalViewRestoredProperties) osztályok és azok leszármazottai, valamint a [SplitterBarStateType](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/SplitterBarStateType) felsoroló típus.

## **A NormalViewProperties tulajdonságairól**

A normál nézet tulajdonságait képviseli.

A [getShowOutlineIcons](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/NormalViewProperties#getShowOutlineIcons--) és a [setShowOutlineIcons](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/NormalViewProperties#setShowOutlineIcons-boolean-) metódusok meghatározzák, hogy az alkalmazás ikonokat jelenítsen-e meg, ha vázlat tartalmat jelenít meg a normál nézet bármelyik tartalmi régiójában.

A [getSnapVerticalSplitter](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/NormalViewProperties#getSnapVerticalSplitter--) és a [setSnapVerticalSplitter](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/NormalViewProperties#setSnapVerticalSplitter-boolean--) metódusok meghatározzák, hogy a függőleges elválasztó sáv minimalizált állapotba snap-eljen, amikor az oldalsó régió elég kicsi.

A [getPreferSingleView](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/NormalViewProperties#getPreferSingleView--) és a [setPreferSingleView](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/NormalViewProperties#setPreferSingleView-boolean--) tulajdonságok meghatározzák, hogy a felhasználó a három tartalmi régióval rendelkező szabványos normál nézet helyett egy teljes ablakot elfoglaló egyetlen tartalmi régiót részesíti előnyben. Ha engedélyezett, az alkalmazás egy tartalmi régiót megjeleníthet az egész ablakban.

A [getVerticalBarState](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/NormalViewProperties#getVerticalBarState--) és a [getHorizontalBarState](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/NormalViewProperties#getHorizontalBarState--) metódusok megadják, hogy a vízszintes vagy függőleges elválasztó sáv milyen állapotban jelenjen meg. A vízszintes elválasztó sáv elválasztja a diát a dia alatti tartalmi régiótól, a függőleges elválasztó sáv elválasztja a diát az oldalsó tartalmi régiótól. Lehetséges értékek: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/SplitterBarStateType#Maximized) és [SplitterBarStateType.Restored](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/SplitterBarStateType#Restored).

A [getRestoredLeft](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/NormalViewProperties#getRestoredLeft--) és a [getRestoredTop](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/NormalViewProperties#getRestoredTop--) metódusok határozzák meg a normál nézet felső vagy oldalsó dia régiójának méretét, amikor a [SplitterBarStateType.Restored](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/SplitterBarStateType#Restored) érték van alkalmazva a [getVerticalBarState](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/NormalViewProperties#getVerticalBarState--) és a [getHorizontalBarState](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/NormalViewProperties#getHorizontalBarState--) metódusokra vonatkozóan.

## **A NormalViewProperties helyreállításáról**

Meghatározza a diapozíció területének méretét (szélesség, ha a [getRestoredTop](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/NormalViewProperties#getRestoredTop--) gyermekeként, magasság, ha a [getRestoredLeft](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/NormalViewProperties#getRestoredLeft--) gyermekeként) a normál nézetben, amikor a régió változó helyreállított mérettel rendelkezik (sem minimalizált, sem maximalizált).

A [getDimensionSize](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/NormalViewRestoredProperties#getDimensionSize--) metódus megadja a diapozíció területének méretét (szélesség, ha a restoredTop gyermekeként, magasság, ha a restoredLeft gyermekeként).

A [getAutoAdjust](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/NormalViewRestoredProperties#getAutoAdjust--) metódus meghatározza, hogy az oldalsó tartalmi régió mérete kompenzálja-e az új méretet az alkalmazáson belül a nézetet tartalmazó ablak átméretezésekor.

Az alábbi példa bemutatja, hogyan férhet hozzá a [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ViewProperties#getNormalViewProperties--) tulajdonságaihoz egy prezentáció esetén.

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

Az Aspose.Slides for Node.js via Java most már támogatja az alapértelmezett nagyítási érték beállítását a prezentációhoz, így amikor a prezentáció megnyílik, a nagyítás már be van állítva. Ez a [ViewProperties](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ViewProperties) beállításával érhető el egy prezentációban. A [getSlideViewProperties](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ViewProperties#getSlideViewProperties--) és a [getNotesViewProperties](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ViewProperties#getNotesViewProperties--) programozottan is beállítható. Ebben a témában egy példán keresztül megmutatjuk, hogyan állítható be a [View Properties](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ViewProperties) a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation) objektumban az Aspose.Slides segítségével.

{{% /alert %}} 

A nézet tulajdonságainak beállításához kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation) osztályból.  
2. Állítsa be a [View Properties](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ViewProperties) értékét a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation) számára.  
3. Írja a prezentációt [PPTX](https://docs.fileformat.com/presentation/pptx/) fájlként.  
   Az alábbi példában a dianézet és a jegyzetnézet nagyítási értékét is beállítottuk.

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

## **Rács távolság beállítása**

Használja a [Presentation.getViewProperties](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/#getViewProperties--) metódust a prezentációra vonatkozó nézetbeállítások eléréséhez. A [ViewProperties.getGridSpacing](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/viewproperties/#getGridSpacing--) és a [ViewProperties.setGridSpacing](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/viewproperties/#setGridSpacing-float-) metódusok beolvassák vagy módosítják a háttérben lévő szerkesztési rács intervallumát. Ez a beállítás az egész prezentációra vonatkozik, nem egyetlen diára. A rács távolságát pontban adják meg, ahol 72 pont egy hüvelyknek felel meg. Pozitív értéket használjon, ahogy az API dokumentációja előírja.

A következő példa megnyit egy létező `demo.pptx` fájlt, kiírja annak aktuális rács távolságát, egy negyed hüvelykes intervallumra állítja, majd elmenti az eredményt.

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

A rács eltér a [drawing guides](/slides/hu/nodejs-java/drawing-guides/) elemtől. A rács távolsága egy szabályos intervallumot szabályoz, míg a rajzolási segédvonalak egyenként elhelyezett vízszintes vagy függőleges igazító vonalak. A segédvonalak hozzáadása, mozgatása vagy törlése nem változtatja meg a rács távolságát.

A rács és a rajzolási segédvonalak is szerkesztési segédeszközök. Nem jelennek meg dia tartalomként PDF-ben, képekben, SVG-ben vagy diavetítésben. A rács távolságának tárolása nem garantálja, hogy egy szerkesztő megjeleníti a rácsot: annak láthatósága a megjelenítő vagy szerkesztő beállításaitól is függ.

## **GYIK**

**Miért nem látható a rács a prezentáció újbóli megnyitása után?**

A fájl tárolja a rács távolságát, de a szerkesztő szabályozza, hogy a rács megjelenik-e. Ellenőrizze a szerkesztő rács láthatósági beállításait.

**A rajzolási segédvonalak törlése megváltoztatja a rács távolságát?**

Nem. A rajzolási segédvonalak és a rács távolsága független beállítások. A segédvonalak törlése nem változtatja meg a tárolt rács intervallumot.

**Beállíthatok különböző nézetbeállításokat a prezentáció különböző szakaszaira?**

A [View settings](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/getviewproperties/) a prezentáció szintjén vannak definiálva ([Normal View](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/viewproperties/getnormalviewproperties/)/[Slide View](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/viewproperties/getslideviewproperties/)), nem szekciónként, így egyetlen paraméterkészlet vonatkozik a teljes dokumentumra a megnyitáskor.

**Előre definiálhatok különböző nézetállapotokat különböző felhasználók számára?**

Nem. A beállítások a fájlban vannak tárolva és megosztottak. A megjelenítő alkalmazások figyelembe vehetik a felhasználói preferenciákat, de a fájl csak egy nézet tulajdonságkészletet tartalmaz.

**Készíthetek sablont előre definiált View Properties értékekkel, hogy az új prezentációk ugyanúgy nyíljanak meg?**

Igen. Mivel a [view properties](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/getviewproperties/) a prezentáció szintjén vannak tárolva, beágyazhatja őket egy sablonba, és új dokumentumokat hozhat létre belőle ugyanazzal a kezdeti nézetkonfigurációval.
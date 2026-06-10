---
title: Prezentáció nézet tulajdonságainak lekérése és frissítése JavaScriptben
linktitle: Nézet tulajdonságok
type: docs
weight: 80
url: /hu/nodejs-java/presentation-view-properties/
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
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Ismerje meg az Aspose.Slides for Node.js via Java nézet tulajdonságait, hogy testreszabhassa a PPT, PPTX és ODP formátumú diákat - állítsa be az elrendezést, a nagyítási szintet és a megjelenítési beállításokat."
---
## **Bevezetés**

A normál nézet három tartalmi régióból áll: a diagról maga, egy oldalsó tartalmi régió és egy alsó tartalmi régió. A különböző tartalmi régiók elhelyezésével kapcsolatos tulajdonságok. Ezek az információk lehetővé teszik az alkalmazás számára, hogy a nézet állapotát a fájlba mentse, így újranyitáskor a nézet ugyanabban az állapotban lesz, mint amikor a prezentációt legutóbb elmentették.

A [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ViewProperties#getNormalViewProperties--) metódus hozzá lett adva, hogy hozzáférést biztosítson a prezentáció normál nézet tulajdonságaihoz.  

[NormalViewProperties](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/NormalViewProperties), [NormalViewRestoredProperties](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/NormalViewRestoredProperties) osztályok és azok leszármazottai, valamint a [SplitterBarStateType](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/SplitterBarStateType) enum hozzá lett adva.

## **NormalViewProperties tulajdonságairól**

A normál nézet tulajdonságait képviseli.

A [getShowOutlineIcons](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/NormalViewProperties#getShowOutlineIcons--) és a [setShowOutlineIcons](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/NormalViewProperties#setShowOutlineIcons-boolean-) metódusok meghatározzák, hogy az alkalmazás ikonokat jelenítsen-e, ha a normál nézet módjában a vázlat tartalmát bármelyik tartalmi régióban megjeleníti.

A [getSnapVerticalSplitter](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/NormalViewProperties#getSnapVerticalSplitter--) és a [setSnapVerticalSplitter](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/NormalViewProperties#setSnapVerticalSplitter-boolean-) metódusok meghatározzák, hogy a függőleges elválasztó sáv minimális állapotba csapódjon-e, amikor az oldalsó régió elég kicsi.

A [getPreferSingleView](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/NormalViewProperties#getPreferSingleView--) és a [setPreferSingleView](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/NormalViewProperties#setPreferSingleView-boolean-) tulajdonságok meghatározzák, hogy a felhasználó a három tartalmi régióból álló szabványos normál nézet helyett egy teljes ablakot elfoglaló egyetlen tartalmi régiót részesíti-e előnyben. Ha engedélyezve van, az alkalmazás kiválaszthatja, hogy a tartalmi régiók egyikét az egész ablakban jelenítse meg.

A [getVerticalBarState](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/NormalViewProperties#getVerticalBarState--) és a [getHorizontalBarState](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/NormalViewProperties#getHorizontalBarState--) metódusok megadják, hogy a vízszintes vagy függőleges elválasztó sáv milyen állapotban jelenjen meg. A vízszintes elválasztó sáv a diát elválasztja a dia alatti tartalmi régiótól, a függőleges elválasztó sáv a diát az oldalsó tartalmi régiótól választja el. Lehetséges értékek: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/SplitterBarStateType#Maximized) és [SplitterBarStateType.Restored](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/SplitterBarStateType#Restored).

A [getRestoredLeft](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/NormalViewProperties#getRestoredLeft--) és a [getRestoredTop](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/NormalViewProperties#getRestoredTop--) metódusok meghatározzák a normál nézet felső vagy oldalsó diarégió méretét, amikor a [SplitterBarStateType.Restored](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/SplitterBarStateType#Restored) értéket alkalmazzák a [getVerticalBarState](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/NormalViewProperties#getVerticalBarState--) és a [getHorizontalBarState](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/NormalViewProperties#getHorizontalBarState--) megfelelően.

## **NormalViewProperties helyreállításáról** 

Meghatározza a dia régió méretét (szélesség, ha a [getRestoredTop](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/NormalViewProperties#getRestoredTop--) gyermekeleme, magasság, ha a [getRestoredLeft](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/NormalViewProperties#getRestoredLeft--) gyermekeleme) a normál nézetben, amikor a régió változó helyreállított mérettel rendelkezik (sem minimális, sem maximális).  

A [getDimensionSize](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/NormalViewRestoredProperties#getDimensionSize--) metódus megadja a dia régió méretét (szélesség, ha a restoredTop gyermekeleme, magasság, ha a restoredLeft gyermekeleme).  

A [getAutoAdjust](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/NormalViewRestoredProperties#getAutoAdjust--) metódus meghatározza, hogy az oldalsó tartalmi régió mérete kompenzálja-e az új méretet a nézetet tartalmazó ablak átméretezésekor az alkalmazáson belül.  

Az alábbi példa azt mutatja, hogyan érheti el a [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ViewProperties#getNormalViewProperties--) tulajdonságait egy prezentációban.

```javascript

var pres = new aspose.slides.Presentation();
try {
    pres.getViewProperties().getNormalViewProperties().setHorizontalBarState(aspose.slides.SplitterBarStateType.Restored);
    pres.getViewProperties().getNormalViewProperties().setVerticalBarState(aspose.slides.SplitterBarStateType.Maximized);

    // Állítsa vissza a prezentáció nézeti tulajdonságait
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setAutoAdjust(true);
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setDimensionSize(80);
    pres.getViewProperties().getNormalViewProperties().setShowOutlineIcons(true);
    pres.save("presentation_normal_view_state.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Alapértelmezett nagyítási érték beállítása**

{{% alert color="primary" %}} 

Aspose.Slides for Node.js via Java most már támogatja az alapértelmezett nagyítási érték beállítását a prezentáción, így a prezentáció megnyitásakor a nagyítás már be van állítva. Ez a [ViewProperties](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ViewProperties) egy prezentációban beállításával valósítható meg. A [getSlideViewProperties](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ViewProperties#getSlideViewProperties--) és a [getNotesViewProperties](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ViewProperties#getNotesViewProperties--) programozottan is beállítható. Ebben a témában egy példával megmutatjuk, hogyan állítható be a [View Properties](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ViewProperties) a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation) számára a [Aspose.Slides](/slides/hu/).

{{% /alert %}} 

Az nézet tulajdonságainak beállításához kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation) osztályból.
2. Állítsa be a [View Properties](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ViewProperties) a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation) számára.
3. Mentse a prezentációt [PPTX](https://docs.fileformat.com/presentation/pptx/) fájlként. Az alábbi példában beállítottuk a nagyítási értéket a dia nézethez és a jegyzet nézethez is.

```javascript
var presentation = new aspose.slides.Presentation();
try {
    // A prezentáció nézet tulajdonságainak beállítása
    presentation.getViewProperties().getSlideViewProperties().setScale(100); // Zoom érték százalékban a dia nézethez
    presentation.getViewProperties().getNotesViewProperties().setScale(100); // Zoom érték százalékban a jegyzet nézethez
    presentation.save("Zoom_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **GYIK**

**Beállíthatok különböző nézetbeállításokat a prezentáció különböző szekcióihoz?**

A [View settings](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/getviewproperties/) a prezentáció szintjén vannak definiálva ([Normal View](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/viewproperties/getnormalviewproperties/)/[Slide View](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/viewproperties/getslideviewproperties/)), nem szekciónként, így egyetlen paramétercsoport érvényes a teljes dokumentumra a megnyitáskor.

**Előre definiálhatok különböző nézetállapotokat különböző felhasználók számára?**

Nem. A beállítások a fájlban tárolódnak, és közösek. A megjelenítő alkalmazások tiszteletben tarthatják a felhasználói preferenciákat, de magában a fájl csak egyetlen nézet‑tulajdonság‑készletet tartalmaz.

**Előkészíthetek egy sablont előre definiált View Properties‑szel, hogy az új prezentációk ugyanígy nyíljanak meg?**

Igen. Mivel a [view properties](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/getviewproperties/) a prezentáció szintjén vannak tárolva, beágyazhatók egy sablonba, és új dokumentumok létrehozhatók belőle azonos kezdeti nézet‑konfigurációval.
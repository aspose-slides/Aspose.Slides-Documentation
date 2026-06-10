---
title: Prezentáció nézet tulajdonságainak lekérése és frissítése PHP-ben
linktitle: Nézet tulajdonságok
type: docs
weight: 80
url: /hu/php-java/presentation-view-properties/
keywords:
- nézet tulajdonságok
- normál nézet
- vázlat tartalom
- vázlat ikonok
- függőleges osztó rögzítése
- egyszemélyes nézet
- sáv állapota
- dimenzió mérete
- automatikus igazítás
- alapértelmezett nagyítás
- PowerPoint
- OpenDocument
- prezentáció
- PHP
- Aspose.Slides
description: "Ismerje meg az Aspose.Slides for PHP via Java nézet tulajdonságait a PPT, PPTX és ODP diák testreszabásához - állítsa be az elrendezéseket, nagyítási szinteket és megjelenítési beállításokat."
---
## **Bevezetés**

A normál nézet három tartalmi régióból áll: maga a dia, egy oldalsó tartalomrégió és egy alsó tartalomrégió. A különböző tartalmi régiók elhelyezésével kapcsolatos tulajdonságok. Ezek az információk lehetővé teszik az alkalmazás számára, hogy a nézetállapotot a fájlba mentse, így a megnyitáskor a nézet ugyanabban az állapotban lesz, mint amikor a bemutatót utoljára mentették.

Az [ViewProperties::getNormalViewProperties](https://reference.aspose.com/slides/hu/php-java/aspose.slides/ViewProperties/#getNormalViewProperties) metódus hozzáadva lett, hogy hozzáférést biztosítson a bemutató normál nézetének tulajdonságaihoz. 

A [NormalViewProperties](https://reference.aspose.com/slides/hu/php-java/aspose.slides/NormalViewProperties), [NormalViewRestoredProperties](https://reference.aspose.com/slides/hu/php-java/aspose.slides/NormalViewRestoredProperties) osztályok és leszármazottaik, valamint a [SplitterBarStateType](https://reference.aspose.com/slides/hu/php-java/aspose.slides/SplitterBarStateType) felsorolt értéke hozzá lettek adva.

## **Az INormalViewProperties leírása**

A normál nézet tulajdonságait képviseli.

A [getShowOutlineIcons](https://reference.aspose.com/slides/hu/php-java/aspose.slides/NormalViewProperties/#getShowOutlineIcons) és a [setShowOutlineIcons](https://reference.aspose.com/slides/hu/php-java/aspose.slides/NormalViewProperties/#setShowOutlineIcons) metódusok azt határozzák meg, hogy az alkalmazás ikonokat jelenítsen-e, ha a vázlat tartalom megjelenik a normál nézet bármelyik tartalmi régiójában.

A [getSnapVerticalSplitter](https://reference.aspose.com/slides/hu/php-java/aspose.slides/NormalViewProperties/#getSnapVerticalSplitter) és a [setSnapVerticalSplitter](https://reference.aspose.com/slides/hu/php-java/aspose.slides/NormalViewProperties/#setSnapVerticalSplitter) metódusok azt határozzák meg, hogy a függőleges osztó elcsúszhat-e egy minimalizált állapotba, ha az oldalsó régió elegendő méretűen kicsi.

A [getPreferSingleView](https://reference.aspose.com/slides/hu/php-java/aspose.slides/NormalViewProperties/#getPreferSingleView) és a [setPreferSingleView](https://reference.aspose.com/slides/hu/php-java/aspose.slides/NormalViewProperties/#setPreferSingleView) tulajdonság azt jelzi, hogy a felhasználó a teljes ablakos egyetlen tartalmi régiót részesíti-e előnyben a három tartalmi régióból álló szabványos normál nézettel szemben. Ha engedélyezve van, az alkalmazás egy tartalmi régiót jeleníthet meg az egész ablakban.

A [getVerticalBarState](https://reference.aspose.com/slides/hu/php-java/aspose.slides/NormalViewProperties/#getVerticalBarState) és a [getHorizontalBarState](https://reference.aspose.com/slides/hu/php-java/aspose.slides/NormalViewProperties/#getHorizontalBarState) metódusok határozzák meg, hogy a vízszintes vagy függőleges osztó sáv milyen állapotban jelenjen meg. A vízszintes osztó sáv elválasztja a diát a dia alatti tartalmi régiótól, a függőleges osztó sáv a diát az oldalsó tartalmi régiótól. Lehetséges értékek: [SplitterBarStateType::Minimized](https://reference.aspose.com/slides/hu/php-java/aspose.slides/SplitterBarStateType/#Minimized), [SplitterBarStateType::Maximized](https://reference.aspose.com/slides/hu/php-java/aspose.slides/SplitterBarStateType/#Maximized) és [SplitterBarStateType::Restored](https://reference.aspose.com/slides/hu/php-java/aspose.slides/SplitterBarStateType/#Restored).

A [getRestoredLeft](https://reference.aspose.com/slides/hu/php-java/aspose.slides/NormalViewProperties/#getRestoredLeft) és a [getRestoredTop](https://reference.aspose.com/slides/hu/php-java/aspose.slides/NormalViewProperties#getRestoredTop) metódusok határozzák meg a normál nézet felső vagy oldalsó diaregiójának méretét, amikor a [SplitterBarStateType::Restored](https://reference.aspose.com/slides/hu/php-java/aspose.slides/SplitterBarStateType/#Restored) érték alkalmazásra kerül a [getVerticalBarState](https://reference.aspose.com/slides/hu/php-java/aspose.slides/NormalViewProperties/#getVerticalBarState) és a [getHorizontalBarState](https://reference.aspose.com/slides/hu/php-java/aspose.slides/NormalViewProperties/#getHorizontalBarState) megfelelően.

## **Az INormalViewProperties helyreállításáról**

Megadja a dia területének méretét (szélesség, ha a [getRestoredTop](https://reference.aspose.com/slides/hu/php-java/aspose.slides/NormalViewProperties/#getRestoredTop) gyermekeként van, magasság, ha a [getRestoredLeft](https://reference.aspose.com/slides/hu/php-java/aspose.slides/NormalViewProperties/#getRestoredLeft) gyermekeként van) a normál nézetben, amikor a régió változó helyreállított mérettel rendelkezik (sem minimalizált, sem maximalizált). 

A [getDimensionSize](https://reference.aspose.com/slides/hu/php-java/aspose.slides/NormalViewRestoredProperties/#getDimensionSize) metódus határozza meg a dia területének méretét (szélesség, ha a restoredTop szülője, magasság, ha a restoredLeft szülője).

A [getAutoAdjust](https://reference.aspose.com/slides/hu/php-java/aspose.slides/NormalViewRestoredProperties/#getAutoAdjust) metódus azt határozza meg, hogy az oldalsó tartalomrégió mérete kompenzálja-e az új méretet az ablak átméretezésekor, amely a nézetet tartalmazza az alkalmazáson belül.

Az alábbi példában látható, hogyan férhet hozzá a [ViewProperties::getNormalViewProperties](https://reference.aspose.com/slides/hu/php-java/aspose.slides/ViewProperties/#getNormalViewProperties) tulajdonságaihoz egy bemutató esetén.

```php
  $pres = new Presentation();
  try {
    $pres->getViewProperties()->getNormalViewProperties()->setHorizontalBarState(SplitterBarStateType::Restored);
    $pres->getViewProperties()->getNormalViewProperties()->setVerticalBarState(SplitterBarStateType::Maximized);

    # Visszaállítja a prezentáció nézet tulajdonságait
    $pres->getViewProperties()->getNormalViewProperties()->getRestoredTop()->setAutoAdjust(true);
    $pres->getViewProperties()->getNormalViewProperties()->getRestoredTop()->setDimensionSize(80);
    $pres->getViewProperties()->getNormalViewProperties()->setShowOutlineIcons(true);
    $pres->save("presentation_normal_view_state.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **Alapértelmezett nagyítási érték beállítása**
{{% alert color="primary" %}} 

Az Aspose.Slides for PHP via Java most már támogatja az alapértelmezett nagyítási érték beállítását a bemutatóhoz, így a bemutató megnyitásakor a nagyítás már be van állítva. Ez a [ViewProperties](https://reference.aspose.com/slides/hu/php-java/aspose.slides/ViewProperties) beállításával érhető el. A [getSlideViewProperties](https://reference.aspose.com/slides/hu/php-java/aspose.slides/ViewProperties/#getSlideViewProperties) és a [getNotesViewProperties](https://reference.aspose.com/slides/hu/php-java/aspose.slides/ViewProperties/#getNotesViewProperties) programatikusan beállítható. Ebben a témában egy példán keresztül megmutatjuk, hogyan kell beállítani a [View Properties](https://reference.aspose.com/slides/hu/php-java/aspose.slides/ViewProperties) a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation) objektumban az [Aspose.Slides](/slides/hu/) segítségével.

{{% /alert %}} 

A nézet tulajdonságainak beállításához kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation) osztályból.
1. Állítsa be a [View Properties](https://reference.aspose.com/slides/hu/php-java/aspose.slides/ViewProperties) értékét a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation) számára.
1. Írja ki a bemutatót egy [PPTX](https://docs.fileformat.com/presentation/pptx/) fájlként.
   Az alábbi példában a dia- és a jegyzetnézet nagyítási értékét állítottuk be.

```php
  $presentation = new Presentation();
  try {
    # A prezentáció nézet tulajdonságainak beállítása
    $presentation->getViewProperties()->getSlideViewProperties()->setScale(100); // Nagyítás értéke százalékban a dia nézethez
    $presentation->getViewProperties()->getNotesViewProperties()->setScale(100); // Nagyítás értéke százalékban a jegyzet nézethez

    $presentation->save("Zoom_out.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```

## **GYIK**

**Beállíthatok különböző nézetbeállításokat a bemutató különböző szekcióihoz?**

A [View settings](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/getviewproperties/) a bemutató szintjén vannak definiálva ([Normal View](https://reference.aspose.com/slides/hu/php-java/aspose.slides/viewproperties/getnormalviewproperties/)/[Slide View](https://reference.aspose.com/slides/hu/php-java/aspose.slides/viewproperties/getslideviewproperties/)), nem szekciónként, így egyetlen paraméterkészlet vonatkozik a teljes dokumentumra a megnyitáskor.

**Előre meghatározhatok különböző nézetállapotokat különböző felhasználóknak?**

Nem. A beállítások a fájlban tárolódnak és megosztottak. A megjelenítő alkalmazások tiszteletben tarthatják a felhasználói preferenciákat, de a fájl önmagában csak egy nézettulajdonság‑készletet tartalmaz.

**Készíthetek olyan sablont előre definiált View Properties‑szel, hogy az új bemutatók ugyanúgy nyíljanak meg?**

Igen. Mivel a [view properties](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/getviewproperties/) a bemutató szintjén vannak tárolva, beágyazhatja őket egy sablonba, és új dokumentumokat hozhat létre belőle ugyanazzal a kezdeti nézetkonfigurációval.

---
title: Prezentáció nézet tulajdonságainak lekérése és frissítése PHP-ben
linktitle: Nézet tulajdonságok
type: docs
weight: 80
url: /hu/php-java/presentation-view-properties/
keywords:
- nézet tulajdonságok
- normál nézet
- vázlat tartalom
- vázlat ikonok
- függőleges osztó rögzítése
- egyszemélyes nézet
- sáv állapota
- dimenzió mérete
- automatikus igazítás
- alapértelmezett nagyítás
- PowerPoint
- OpenDocument
- prezentáció
- PHP
- Aspose.Slides
description: "Ismerje meg az Aspose.Slides for PHP via Java nézet tulajdonságait a PPT, PPTX és ODP diák testreszabásához - állítsa be az elrendezéseket, nagyítási szinteket és megjelenítési beállításokat."
---
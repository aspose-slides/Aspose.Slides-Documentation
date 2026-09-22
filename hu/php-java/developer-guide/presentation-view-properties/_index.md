---
title: Prezentáció nézet tulajdonságainak lekérése és frissítése PHP-ban
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
- egyes nézet
- csík állapot
- dimenzió méret
- automatikus igazítás
- alapértelmezett nagyítás
- PowerPoint
- OpenDocument
- prezentáció
- PHP
- Aspose.Slides
description: "Fedezze fel az Aspose.Slides for PHP via Java nézet tulajdonságait a PPT, PPTX és ODP diák formátumainak testreszabásához – állítsa be az elrendezést, a nagyítási szinteket és a megjelenítési beállításokat."
---
## **Bevezetés**

A normál nézet három tartalmi régióból áll: maga a dia, egy oldalsó tartalmi régió és egy alsó tartalmi régió. A különböző tartalmi régiók elhelyezésével kapcsolatos tulajdonságok. Ezek az információk lehetővé teszik az alkalmazás számára, hogy mentse a nézet állapotát a fájlba, így újra megnyitáskor a nézet ugyanabban az állapotban van, mint amikor a prezentáció utoljára mentésre került.

A [ViewProperties::getNormalViewProperties](https://reference.aspose.com/slides/hu/php-java/aspose.slides/ViewProperties/#getNormalViewProperties) metódus hozzá lett adva, hogy hozzáférést biztosítson a prezentáció normál nézet tulajdonságaihoz.  

[NormalViewProperties](https://reference.aspose.com/slides/hu/php-java/aspose.slides/NormalViewProperties), [NormalViewRestoredProperties](https://reference.aspose.com/slides/hu/php-java/aspose.slides/NormalViewRestoredProperties) osztályok és azok leszármazottai, valamint a [SplitterBarStateType](https://reference.aspose.com/slides/hu/php-java/aspose.slides/SplitterBarStateType) enumeráció hozzá lett adva.

## **Az INormalViewProperties ismertetése**

A normál nézet tulajdonságait képviseli.

A [getShowOutlineIcons](https://reference.aspose.com/slides/hu/php-java/aspose.slides/NormalViewProperties/#getShowOutlineIcons) és a [setShowOutlineIcons](https://reference.aspose.com/slides/hu/php-java/aspose.slides/NormalViewProperties/#setShowOutlineIcons) metódusok meghatározzák, hogy az alkalmazás ikonokat jelenítsen-e, ha vázlat tartalmat jelenít meg a normál nézet bármelyik tartalmi régiójában.

A [getSnapVerticalSplitter](https://reference.aspose.com/slides/hu/php-java/aspose.slides/NormalViewProperties/#getSnapVerticalSplitter) és a [setSnapVerticalSplitter](https://reference.aspose.com/slides/hu/php-java/aspose.slides/NormalViewProperties/#setSnapVerticalSplitter) metódusok meghatározzák, hogy a függőleges osztó elcsúszhat-e minimalizált állapotba, amikor az oldalsó régió elég kicsi.

A [getPreferSingleView](https://reference.aspose.com/slides/hu/php-java/aspose.slides/NormalViewProperties/#getPreferSingleView) és [setPreferSingleView](https://reference.aspose.com/slides/hu/php-java/aspose.slides/NormalViewProperties/#setPreferSingleView) tulajdonságok meghatározzák, hogy a felhasználó inkább egy teljes ablakos egyetlen tartalmi régiót szeretne-e a három tartalmi régióból álló szabványos normál nézet helyett. Ha engedélyezve van, az alkalmazás dönthet úgy, hogy egy tartalmi régiót jelenít meg az egész ablakban.

A [getVerticalBarState](https://reference.aspose.com/slides/hu/php-java/aspose.slides/NormalViewProperties/#getVerticalBarState) és a [getHorizontalBarState](https://reference.aspose.com/slides/hu/php-java/aspose.slides/NormalViewProperties/#getHorizontalBarState) metódusok határozzák meg, hogy a vízszintes vagy függőleges osztócsík milyen állapotban legyen megjelenítve. A vízszintes osztócsík a diát elválasztja a dia alatti tartalmi régiótól, a függőleges osztócsík a diát az oldalsó tartalmi régiótól. Lehetséges értékek: [SplitterBarStateType::Minimized](https://reference.aspose.com/slides/hu/php-java/aspose.slides/SplitterBarStateType/#Minimized), [SplitterBarStateType::Maximized](https://reference.aspose.com/slides/hu/php-java/aspose.slides/SplitterBarStateType/#Maximized) és [SplitterBarStateType::Restored](https://reference.aspose.com/slides/hu/php-java/aspose.slides/SplitterBarStateType/#Restored).

A [getRestoredLeft](https://reference.aspose.com/slides/hu/php-java/aspose.slides/NormalViewProperties/#getRestoredLeft) és a [getRestoredTop](https://reference.aspose.com/slides/hu/php-java/aspose.slides/NormalViewProperties#getRestoredTop) metódusok meghatározzák a normál nézet felső vagy oldalsó diarégió méretét, amikor a [SplitterBarStateType::Restored](https://reference.aspose.com/slides/hu/php-java/aspose.slides/SplitterBarStateType/#Restored) érték alkalmazásra kerül a [getVerticalBarState](https://reference.aspose.com/slides/hu/php-java/aspose.slides/NormalViewProperties/#getVerticalBarState) és a [getHorizontalBarState](https://reference.aspose.com/slides/hu/php-java/aspose.slides/NormalViewProperties/#getHorizontalBarState) esetében.

## **Az INormalViewProperties helyreállítása**

Meghatározza a diarégió méretét (szélesség, ha a [getRestoredTop](https://reference.aspose.com/slides/hu/php-java/aspose.slides/NormalViewProperties/#getRestoredTop) gyermekeleme, magasság, ha a [getRestoredLeft](https://reference.aspose.com/slides/hu/php-java/aspose.slides/NormalViewProperties/#getRestoredLeft) gyermekeleme) a normál nézetben, amikor a régió változó visszaállított mérettel rendelkezik (sem minimalizált, sem maximalizált).

A [getDimensionSize](https://reference.aspose.com/slides/hu/php-java/aspose.slides/NormalViewRestoredProperties/#getDimensionSize) metódus meghatározza a diarégió méretét (szélesség, ha a restoredTop gyermekeleme, magasság, ha a restoredLeft gyermekeleme).

A [getAutoAdjust](https://reference.aspose.com/slides/hu/php-java/aspose.slides/NormalViewRestoredProperties/#getAutoAdjust) metódus meghatározza, hogy az oldalsó tartalmi régió mérete kompenzálja-e az új méretet, amikor a nézetet tartalmazó ablakot az alkalmazásban átméretezik.

Az alábbi példában látható, hogyan érheti el a [ViewProperties::getNormalViewProperties](https://reference.aspose.com/slides/hu/php-java/aspose.slides/ViewProperties/#getNormalViewProperties) tulajdonságait egy prezentációhoz.

```php
  $pres = new Presentation();
  try {
    $pres->getViewProperties()->getNormalViewProperties()->setHorizontalBarState(SplitterBarStateType::Restored);
    $pres->getViewProperties()->getNormalViewProperties()->setVerticalBarState(SplitterBarStateType::Maximized);

    # A prezentáció nézet tulajdonságainak visszaállítása
    $pres->getViewProperties()->getNormalViewProperties()->getRestoredTop()->setAutoAdjust(true);
    $pres->getViewProperties()->getNormalViewProperties()->getRestoredTop()->setDimensionSize(80);
    $pres->getViewProperties()->getNormalViewProperties()->setShowOutlineIcons(true);
    $pres->save("presentation_normal_view_state.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **Az alapértelmezett nagyítási érték beállítása**
{{% alert color="info" %}} 

Aspose.Slides for PHP via Java most már támogatja az alapértelmezett nagyítási érték beállítását egy prezentációhoz, így a prezentáció megnyitásakor a nagyítás már be van állítva. Ez a [ViewProperties](https://reference.aspose.com/slides/hu/php-java/aspose.slides/ViewProperties) beállításával érhető el egy prezentációban. A [getSlideViewProperties](https://reference.aspose.com/slides/hu/php-java/aspose.slides/ViewProperties/#getSlideViewProperties) és a [getNotesViewProperties](https://reference.aspose.com/slides/hu/php-java/aspose.slides/ViewProperties/#getNotesViewProperties) programozottan beállítható. Ebben a témában egy példán keresztül megmutatjuk, hogyan állítható be a [View Properties](https://reference.aspose.com/slides/hu/php-java/aspose.slides/ViewProperties) a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation) objektumban az Aspose.Slides használatával.

{{% /alert %}} 

A nézet tulajdonságok beállításához kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation) osztályból.
1. Állítsa be a [View Properties](https://reference.aspose.com/slides/hu/php-java/aspose.slides/ViewProperties) a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation) számára.
1. Mentse a prezentációt [PPTX ](https://docs.fileformat.com/presentation/pptx/) fájlként.  
   Az alább megadott példában beállítottuk a nagyítási értéket a dianézethez és a jegyzetnézethez is.

```php
  $presentation = new Presentation();
  try {
    # A prezentáció nézet tulajdonságainak beállítása
    $presentation->getViewProperties()->getSlideViewProperties()->setScale(100); // Nagyítási érték százalékban a dianézethez
    $presentation->getViewProperties()->getNotesViewProperties()->setScale(100); // Nagyítási érték százalékban a jegyzetnézethez

    $presentation->save("Zoom_out.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```

## **A rácstávolság beállítása**

Használja a [Presentation::getViewProperties](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/#getViewProperties) metódust a prezentáció szintű nézetbeállítások eléréséhez. A [ViewProperties::getGridSpacing](https://reference.aspose.com/slides/hu/php-java/aspose.slides/viewproperties/#getGridSpacing) és [ViewProperties::setGridSpacing](https://reference.aspose.com/slides/hu/php-java/aspose.slides/viewproperties/#setGridSpacing) metódusok olvassák vagy módosítják az alapul szolgáló szerkesztő rács intervallumát. Ez a beállítás az egész prezentációra vonatkozik, nem egyetlen diára. A rácstávolság pontban van megadva, ahol 72 pont egy hüvelyknek felel meg. Pozitív értéket használjon, ahogy az API dokumentációja előírja.

A következő példa megnyit egy létező `demo.pptx` fájlt, kiírja a jelenlegi rácstávolságot, beállít egy negyed hüvelykes intervallumot, és elmenti az eredményt.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("demo.pptx");
try {
    $gridSpacing = $presentation->getViewProperties()->getGridSpacing();
    echo "Current grid spacing: " . $gridSpacing . " points\n";

    $presentation->getViewProperties()->setGridSpacing(18.0);
    $presentation->save("grid-spacing.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

A rács különbözik a [drawing guides](/slides/hu/php-java/drawing-guides/) útmutatóktól. A rácstávolság egy szabályos intervallumot szabályoz, míg a rajzolási segédvonalak egyenkénti, vízszintes vagy függőleges igazítási vonalak. A segédvonalak hozzáadása, mozgatása vagy törlése nem változtatja meg a rácstávolságot.

A rács és a rajzolási segédvonalak is szerkesztési segédeszközök. Nem jelennek meg dia tartalomként PDF-ben, képekben, SVG-ben vagy diavetítésben. A rácstávolság tárolása nem garantálja, hogy egy szerkesztő megjeleníti a rácsot: annak láthatósága a megjelenítő vagy szerkesztő beállításaitól is függ.

## **FAQ**

**Miért nem látható a rács a prezentáció újranyitása után?**

A fájl tárolja a rácstávolságot, de a szerkesztő határozza meg, hogy a rács megjelenik-e. Ellenőrizze a szerkesztő rács láthatósági beállításait.

**A rajzolási segédvonalak törlése megváltoztatja a rácstávolságot?**

Nem. A rajzolási segédvonalak és a rácstávolság független beállítások. A segédvonalak törlése változatlanul hagyja a tárolt rácsintervallumot.

**Beállíthatok különböző nézetbeállításokat a prezentáció különböző szakaszaira?**

A [View settings](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/getviewproperties/) a prezentáció szintjén vannak definiálva ([Normal View](https://reference.aspose.com/slides/hu/php-java/aspose.slides/viewproperties/getnormalviewproperties/)/[Slide View](https://reference.aspose.com/slides/hu/php-java/aspose.slides/viewproperties/getslideviewproperties/)), nem szakaszonként, így egyetlen paraméterkészlet alkalmazásra kerül a teljes dokumentumra, amikor megnyílik.

**Előre definiálhatok különböző nézetállapotokat különböző felhasználók számára?**

Nem. A beállítások a fájlban vannak tárolva, és megosztottak. A megjelenítő alkalmazások tiszteletben tarthatják a felhasználói preferenciákat, de a fájl csak egy nézettulajdonság-készletet tartalmaz.

**Elkészíthetek egy sablont előre meghatározott View Properties-szal, hogy az új prezentációk ugyanúgy nyíljanak meg?**

Igen. Mivel a [view properties](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/getviewproperties/) a prezentáció szintjén vannak tárolva, beágyazhatók egy sablonba, és új dokumentumokat hozhat létre belőle ugyanazzal a kezdeti nézetkonfigurációval.
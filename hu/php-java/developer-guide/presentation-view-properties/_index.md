---
title: Prezentáció nézet tulajdonságainak lekérdezése és frissítése PHP-ben
linktitle: Nézet tulajdonságok
type: docs
weight: 80
url: /hu/php-java/presentation-view-properties/
keywords:
- nézet tulajdonságok
- normál nézet
- vázlat tartalom
- vázlat ikonok
- függőleges elválasztó rögzítése
- egyes nézet
- sáv állapot
- dimenzió méret
- automatikus igazítás
- alapértelmezett nagyítás
- PowerPoint
- OpenDocument
- prezentáció
- PHP
- Aspose.Slides
description: "Ismerje meg az Aspose.Slides for PHP via Java nézet tulajdonságait, hogy testreszabja a PPT, PPTX és ODP diák formátumait — állítsa be az elrendezéseket, nagyítási szinteket és megjelenítési beállításokat."
---
## **Bevezetés**

A normál nézet három tartalmi területből áll: a dia magából, egy oldalsó tartalmi területből és egy alsó tartalmi területből. A különböző tartalmi területek elhelyezésére vonatkozó tulajdonságok. Ez az információ lehetővé teszi az alkalmazás számára, hogy elmentse a nézet állapotát a fájlba, így újranyitáskor a nézet ugyanabban az állapotban lesz, mint amikor a bemutatót legutóbb mentették.

A [ViewProperties::getNormalViewProperties](https://reference.aspose.com/slides/hu/php-java/aspose.slides/ViewProperties/#getNormalViewProperties) metódus hozzá lett adva, hogy hozzáférést biztosítson a bemutató normál nézet tulajdonságaihoz.  

Hozzá lettek adva a [NormalViewProperties](https://reference.aspose.com/slides/hu/php-java/aspose.slides/NormalViewProperties), a [NormalViewRestoredProperties](https://reference.aspose.com/slides/hu/php-java/aspose.slides/NormalViewRestoredProperties) osztályok és azok leszármazottai, valamint a [SplitterBarStateType](https://reference.aspose.com/slides/hu/php-java/aspose.slides/SplitterBarStateType) enum.

## **Az INormalViewProperties leírása**

A normál nézet tulajdonságait képviseli.

A [getShowOutlineIcons](https://reference.aspose.com/slides/hu/php-java/aspose.slides/NormalViewProperties/#getShowOutlineIcons) és a [setShowOutlineIcons](https://reference.aspose.com/slides/hu/php-java/aspose.slides/NormalViewProperties/#setShowOutlineIcons) metódusok határozzák meg, hogy az alkalmazás ikonokat jelenítsen-e, ha vázlat tartalmat jelenít meg a normál nézet valamelyik tartalmi területén.

A [getSnapVerticalSplitter](https://reference.aspose.com/slides/hu/php-java/aspose.slides/NormalViewProperties/#getSnapVerticalSplitter) és a [setSnapVerticalSplitter](https://reference.aspose.com/slides/hu/php-java/aspose.slides/NormalViewProperties/#setSnapVerticalSplitter) metódusok határozzák meg, hogy a függőleges elválasztó panel minimalizált állapotba csapjon-e, amikor az oldalsó terület elég kicsi.

A [getPreferSingleView](https://reference.aspose.com/slides/hu/php-java/aspose.slides/NormalViewProperties/#getPreferSingleView) és a [setPreferSingleView](https://reference.aspose.com/slides/hu/php-java/aspose.slides/NormalViewProperties/#setPreferSingleView) tulajdonságok meghatározzák, hogy a felhasználó a három tartalmi területből álló standard normál nézet helyett teljes ablakos egyetlen tartalmi területet részesít-e előnyben. Ha engedélyezve van, az alkalmazás úgy dönthet, hogy az egyik tartalmi területet az egész ablakban jeleníti meg.

A [getVerticalBarState](https://reference.aspose.com/slides/hu/php-java/aspose.slides/NormalViewProperties/#getVerticalBarState) és a [getHorizontalBarState](https://reference.aspose.com/slides/hu/php-java/aspose.slides/NormalViewProperties/#getHorizontalBarState) metódusok határozzák meg, hogy a függőleges vagy vízszintes elválasztó sáv milyen állapotban jelenjen meg. A vízszintes elválasztó sáv elválasztja a diát a dia alatti tartalmi területtől, a függőleges elválasztó sáv a diát az oldalsó tartalmi területtől. Lehetséges értékek: [SplitterBarStateType::Minimized](https://reference.aspose.com/slides/hu/php-java/aspose.slides/SplitterBarStateType/#Minimized), [SplitterBarStateType::Maximized](https://reference.aspose.com/slides/hu/php-java/aspose.slides/SplitterBarStateType/#Maximized) és [SplitterBarStateType::Restored](https://reference.aspose.com/slides/hu/php-java/aspose.slides/SplitterBarStateType/#Restored).

A [getRestoredLeft](https://reference.aspose.com/slides/hu/php-java/aspose.slides/NormalViewProperties/#getRestoredLeft) és a [getRestoredTop](https://reference.aspose.com/slides/hu/php-java/aspose.slides/NormalViewProperties#getRestoredTop) metódusok határozzák meg a normál nézet felső vagy oldalsó diaterületének méretét, amikor a [SplitterBarStateType::Restored](https://reference.aspose.com/slides/hu/php-java/aspose.slides/SplitterBarStateType/#Restored) érték van alkalmazva a [getVerticalBarState](https://reference.aspose.com/slides/hu/php-java/aspose.slides/NormalViewProperties/#getVerticalBarState) és a [getHorizontalBarState](https://reference.aspose.com/slides/hu/php-java/aspose.slides/NormalViewProperties/#getHorizontalBarState) metódusokra.

## **Az INormalViewProperties visszaállításáról**

A diaterület (szélesség, ha a [getRestoredTop](https://reference.aspose.com/slides/hu/php-java/aspose.slides/NormalViewProperties/#getRestoredTop) gyermekeként, magasság, ha a [getRestoredLeft](https://reference.aspose.com/slides/hu/php-java/aspose.slides/NormalViewProperties/#getRestoredLeft) gyermekeként) méretét határozza meg a normál nézetben, amikor a terület változó visszaállított mérettel rendelkezik (sem minimalizált, sem maximalizált).

A [getDimensionSize](https://reference.aspose.com/slides/hu/php-java/aspose.slides/NormalViewRestoredProperties/#getDimensionSize) metódus meghatározza a diaterület méretét (szélesség, ha a restoredTop gyermekeként, magasság, ha a restoredLeft gyermekeként).

A [getAutoAdjust](https://reference.aspose.com/slides/hu/php-java/aspose.slides/NormalViewRestoredProperties/#getAutoAdjust) metódus meghatározza, hogy az oldalsó tartalmi terület mérete kompenzálja-e az új méretet, amikor a nézetet tartalmazó ablakot az alkalmazáson belül átméretezik.

Az alább bemutatott példa azt mutatja, hogyan lehet elérni egy bemutató [ViewProperties::getNormalViewProperties](https://reference.aspose.com/slides/hu/php-java/aspose.slides/ViewProperties/#getNormalViewProperties) tulajdonságait.

```php
  $pres = new Presentation();
  try {
    $pres->getViewProperties()->getNormalViewProperties()->setHorizontalBarState(SplitterBarStateType::Restored);
    $pres->getViewProperties()->getNormalViewProperties()->setVerticalBarState(SplitterBarStateType::Maximized);

    # A bemutató nézet tulajdonságainak visszaállítása
    $pres->getViewProperties()->getNormalViewProperties()->getRestoredTop()->setAutoAdjust(true);
    $pres->getViewProperties()->getNormalViewProperties()->getRestoredTop()->setDimensionSize(80);
    $pres->getViewProperties()->getNormalViewProperties()->setShowOutlineIcons(true);
    $pres->save("presentation_normal_view_state.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **Az alapértelmezett zoom érték beállítása**
{{% alert color="info" %}} 

Az Aspose.Slides for PHP via Java most már támogatja az alapértelmezett zoom érték beállítását a bemutatóhoz, így amikor a bemutatót megnyitják, a zoom már be van állítva. Ez a [ViewProperties](https://reference.aspose.com/slides/hu/php-java/aspose.slides/ViewProperties) beállításával történhet egy bemutatóban. A [getSlideViewProperties](https://reference.aspose.com/slides/hu/php-java/aspose.slides/ViewProperties/#getSlideViewProperties) és a [getNotesViewProperties](https://reference.aspose.com/slides/hu/php-java/aspose.slides/ViewProperties/#getNotesViewProperties) programozottan is beállítható. Ebben a témában példával megmutatjuk, hogyan lehet beállítani a [View Properties](https://reference.aspose.com/slides/hu/php-java/aspose.slides/ViewProperties) a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation) objektumban az Aspose.Slides-ben.

{{% /alert %}} 

Az nézet tulajdonságainak beállításához kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation) osztályból.
1. Állítsa be a [View Properties](https://reference.aspose.com/slides/hu/php-java/aspose.slides/ViewProperties) értékét a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation)‑nél.
1. Írja a bemutatót [PPTX ](https://docs.fileformat.com/presentation/pptx/) fájlként.  
   Az alább bemutatott példában beállítottuk a zoom értékét a diánézet és a jegyzetnézet számára is.

```php
  $presentation = new Presentation();
  try {
    # A bemutató nézet tulajdonságainak beállítása
    $presentation->getViewProperties()->getSlideViewProperties()->setScale(100); // Nagyítási érték százalékban a dianézethez
    $presentation->getViewProperties()->getNotesViewProperties()->setScale(100); // Nagyítási érték százalékban a jegyzetnézethez

    $presentation->save("Zoom_out.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```

## **Rács távolságának beállítása**

Használja a [Presentation::getViewProperties](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/#getViewProperties) metódust a bemutató szintű nézetbeállítások eléréséhez. A [ViewProperties::getGridSpacing](https://reference.aspose.com/slides/hu/php-java/aspose.slides/viewproperties/#getGridSpacing) és a [ViewProperties::setGridSpacing](https://reference.aspose.com/slides/hu/php-java/aspose.slides/viewproperties/#setGridSpacing) metódusok olvassák vagy módosítják a háttérben lévő szerkesztő rács intervallumát. Ez a beállítás az egész bemutatóra vonatkozik, nem egyetlen diára. A rács távolságát pontban adják meg, ahol 72 pont egy hüvelyknek felel meg. Pozitív értéket használjon, ahogy az API dokumentációja megköveteli.

A következő példa megnyit egy meglévő `demo.pptx` fájlt, kiírja a jelenlegi rács távolságát, egy negyed hüvelykes intervallumra állítja, majd elmenti az eredményt.

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

A rács különbözik a [drawing guides](/slides/hu/php-java/drawing-guides/) útmutatóktól. A rács távolság szabályos intervallumot szabályoz, míg a rajzoló segédvonalak egyenként elhelyezett vízszintes vagy függőleges igazítólínek. A segédvonalak hozzáadása, mozgatása vagy törlése nem változtatja meg a rács távolságát.

A rács és a rajzoló segédvonalak egyaránt szerkesztősegédek. Nem jelennek meg diatartalomként PDF-ben, képekben, SVG-ben vagy diavetítésben. A rács távolságának tárolása nem garancia arra, hogy egy szerkesztő megjeleníti a rácsot: a láthatóság a megjelenítő vagy szerkesztő beállításaitól is függ.

## **Megjegyzések megjelenítése vagy elrejtése a bemutató megnyitásakor**

Használja a [Presentation::getViewProperties](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/getviewproperties/) metódust a bemutató szintű nézetbeállítások eléréséhez. Használja a [ViewProperties::getShowComments](https://reference.aspose.com/slides/hu/php-java/aspose.slides/viewproperties/getshowcomments/) és a [ViewProperties::setShowComments](https://reference.aspose.com/slides/hu/php-java/aspose.slides/viewproperties/setshowcomments/) metódusokat a tárolt beállítás kiolvasásához vagy módosításához, hogy a megjegyzések megjelenjenek-e, amikor a bemutató megnyílik a PowerPointban vagy egy másik kompatibilis szerkesztőben.

Ez a beállítás csak a tárolt nézeti preferenciát szabályozza. Nem ad hozzá, nem távolít el, nem szerkeszt és nem old meg megjegyzéseket. A megjegyzések elrejtése megőrzi azok tartalmát, szerzőit, pozícióit, válaszait és állapotát. Tekintse meg a [Presentation Comments](/slides/hu/php-java/presentation-comments/) oldalt a megjegyzéseken végzett műveletekhez.

A következő példa egy meglévő `comments.pptx` fájlt igényel, amely megjegyzéseket tartalmaz. Kiírja a jelenlegi láthatósági beállítást, kéri a megjegyzések elrejtését, és egy új PPTX-et ment anélkül, hogy bármely megjegyzést eltávolítaná. Emellett a [ViewProperties::setLastView](https://reference.aspose.com/slides/hu/php-java/aspose.slides/viewproperties/setlastview/) metódust a [ViewType::SlideView](https://reference.aspose.com/slides/hu/php-java/aspose.slides/viewtype/#SlideView) értékkel használja a kezdeti szerkesztő nézet beállításához a megjegyzés láthatóságával együtt.

```php
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ViewType;

$presentation = new Presentation("comments.pptx");
try {
    $showComments = $presentation->getViewProperties()->getShowComments();
    echo "Current comment visibility: " . java_values($showComments) . PHP_EOL;

    $presentation->getViewProperties()->setShowComments(NullableBool::False);
    $presentation->getViewProperties()->setLastView(ViewType::SlideView);
    $presentation->save("comments-hidden.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Ez a beállítás nem határozza meg, hogy a megjegyzések szerepelnek-e a PDF, HTML, kép, jegyzet vagy szórólap exportokban. A megfelelő export-specifikus beállításokat külön kell konfigurálni.

## **FAQ**

**Miért nem látható a rács a bemutató újbóli megnyitása után?**

A fájl tárolja a rács távolságát, de a szerkesztő szabályozza, hogy a rács megjelenik-e. Ellenőrizze a szerkesztő rács láthatósági beállításait.

**A rajzoló segédvonalak törlése megváltoztatja-e a rács távolságát?**

Nem. A rajzoló segédvonalak és a rács távolsága különálló beállítások. A segédvonalak törlése nem változtatja meg a tárolt rács intervallumot.

**Beállíthatok-e különböző nézetbeállításokat a bemutató egyes szekcióihoz?**

A [View settings](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/getviewproperties/) a bemutató szintjén vannak definiálva ([Normal View](https://reference.aspose.com/slides/hu/php-java/aspose.slides/viewproperties/getnormalviewproperties/)/[Slide View](https://reference.aspose.com/slides/hu/php-java/aspose.slides/viewproperties/getslideviewproperties/)), nem szekciónként, így az egyetlen paraméterkészlet a teljes dokumentumra vonatkozik, amikor megnyílik.

**Előre definiálhatok különböző nézetállapotokat különböző felhasználók számára?**

Nem. A beállítások a fájlban vannak tárolva és megosztottak. A megjelenítő alkalmazások figyelembe vehetik a felhasználói preferenciákat, de a fájl önmagában csak egy nézet tulajdonságkészletet tartalmaz.

**Készíthetek sablont előre definiált View Properties-vel, hogy az új bemutatók ugyanúgy nyíljanak meg?**

Igen. Mivel a [view properties](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/getviewproperties/) a bemutató szintjén vannak tárolva, beágyazhatja őket egy sablonba, és új dokumentumokat hozhat létre belőle azonos kezdeti nézet konfigurációval.
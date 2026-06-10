---
title: Prezentációk létrehozása PHP-ben
linktitle: Prezentáció létrehozása
type: docs
weight: 10
url: /hu/php-java/create-presentation/
keywords:
- prezentáció létrehozása
- új prezentáció
- PPT létrehozása
- új PPT
- PPTX létrehozása
- új PPTX
- ODP létrehozása
- új ODP
- PowerPoint
- OpenDocument
- prezentáció
- PHP
- Aspose.Slides
description: "Prezentációk létrehozása az Aspose.Slides for PHP via Java segítségével — PPT, PPTX és ODP fájlok előállítása és programozott mentése megbízható eredményekért."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan hozhat létre egy prezentációt az Aspose.Slides használatával, hogyan adhat egyszerű tartalmat egy diára, és hogyan mentheti az eredményt fájlba. Emellett megmutatja, hogyan hozhat létre és menthet egy új prezentációt, hogyan nyithat meg egy meglévő prezentációt egy támogatott formátumban, és hogyan mentheti azt egy másik formátumba. Továbbá a cikk egy rövid GYIK-et tartalmaz, amely a formátumokra, sablonokra, diaméretekre, egységekre, memóriahasználatra, szálkezelésre, licencelésre, digitális aláírásokra és a VBA támogatásra vonatkozó gyakori kérdéseket fedi le.

## **Prezentáció létrehozása**

Hogy egyszerű, egyenes vonalat adjunk a prezentáció kiválasztott diájához, kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a Presentation osztályból.
2. Szerezze be egy dia hivatkozását az Index használatával.
3. Adjon hozzá egy Line típusú AutoShape-et a Shapes objektum által biztosított addAutoShape metódussal.
4. Írja ki a módosított prezentációt PPTX fájlként.

A lent bemutatott példában egy vonalat adtunk hozzá a prezentáció első diájához.

```php
  # Hozzon létre egy Presentation objektumot, amely egy prezentációs fájlt képvisel
  $pres = new Presentation();
  try {
    # Szerezze meg az első diát
    $slide = $pres->getSlides()->get_Item(0);
    # Adjon hozzá egy vonal típusú autoshape-et
    $slide->getShapes()->addAutoShape(ShapeType::Line, 50, 150, 300, 0);
    $pres->save("NewPresentation_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **GYIK**

**Milyen formátumokba menthetem az új prezentációt?**

Menthet a [PPTX, PPT és ODP](/slides/hu/php-java/save-presentation/) formátumokba, és exportálhat [PDF](/slides/hu/php-java/convert-powerpoint-to-pdf/), [XPS](/slides/hu/php-java/convert-powerpoint-to-xps/), [HTML](/slides/hu/php-java/convert-powerpoint-to-html/), [SVG](/slides/hu/php-java/convert-powerpoint-to-png/) és [képek](/slides/hu/php-java/convert-powerpoint-to-png/) formátumokba, többek között.

**Kezdhetek sablonnal (POTX/POTM), és menthetem normál PPTX‑ként?**

Igen. Töltse be a sablont, és mentse a kívánt formátumba; a POTX/POTM/PPTM és hasonló formátumok [támogatottak](/slides/hu/php-java/supported-file-formats/).

**Hogyan szabályozhatom a dia méretét/méretarányát a prezentáció létrehozásakor?**

Állítsa be a [dia méretét](/slides/hu/php-java/slide-size/) (beleértve a 4:3 és 16:9 előre beállított vagy egyedi méreteket), és válassza ki, hogyan méreteződjön a tartalom.

**Milyen egységekben vannak megadva a méretek és koordináták?**

Pontban: 1 hüvelyk 72 egységnek felel meg.

**Hogyan kezeljem a nagyon nagy prezentációkat (sok médiafájllal) a memóriahasználat csökkentése érdekében?**

Használjon [BLOB kezelési stratégiákat](/slides/hu/php-java/manage-blob/), korlátozza a memóriahasználatot átmeneti fájlok használatával, és részesítse előnyben a fájlalapú munkafolyamatokat a tisztán memóriában futó adatfolyamok helyett.

**Létrehozhatok/menthetek prezentációkat párhuzamosan?**

Nem működtethet ugyanazon a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) példányon [több szálból](/slides/hu/php-java/multithreading/). Indítson külön, elszigetelt példányokat szálanként vagy folyamatanként.

**Hogyan távolíthatom el a próba vízjelet és a korlátozásokat?**

[Alkalmazzon licencet](/slides/hu/php-java/licensing/) egyszer a folyamaton belül. A licenc XML-nek változatlanul kell maradnia, és a licenc beállítást szinkronizálni kell, ha több szál vesz részt.

**Alá tudom-e digitálisan aláírni a létrehozott PPTX‑t?**

Igen. A [digitális aláírások](/slides/hu/php-java/digital-signature-in-powerpoint/) (létrehozása és ellenőrzése) támogatottak a prezentációkhoz.

**A makrók (VBA) támogatottak a létrehozott prezentációkban?**

Igen. [Létrehozhat/szerkeszthet VBA projekteket](/slides/hu/php-java/presentation-via-vba/) és menthet makróval ellátott fájlokat, mint a PPTM/PPSM.
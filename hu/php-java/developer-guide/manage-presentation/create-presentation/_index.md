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

Ez a cikk bemutatja, hogyan hozhat létre egy bemutatót az Aspose.Slides-ban, adhat hozzá egy szövegdobozt az első diára, és mentheti az eredményt fájlként. Emellett megmutatja, hogyan hozhat létre és menthet egy üres bemutatót, valamint hogyan nyithat meg egy meglévő, támogatott formátumú bemutatót és mentheti egy másik formátumba. A végén egy rövid GYIK lefedi a formátumokkal, sablonokkal, dia méretekkel, mértékegységekkel, memóriahasználattal, szálkezeléssel, licenceléssel, digitális aláírásokkal és VBA támogatással kapcsolatos gyakori kérdéseket.

Mielőtt elkezdené, telepítse az Aspose.Slides for PHP via Java csomagot a Composerrel, és indítsa el a PHP/Java Bridge-et az Apache Tomcat-ban. A teljes beállításhoz tekintse meg a [Installation](/slides/hu/php-java/installation/) oldalt. Az alábbi példák feltételezik, hogy a Tomcat a `localhost:8080` címen fut, és a Composer `vendor` mappája a szkript mellé van.

## **PowerPoint bemutató létrehozása**

A bemutató létrehozásához és egy szövegdoboz elhelyezéséhez az első diapont, kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) osztályból. Egy új bemutató már egy üres diát tartalmaz.
2. Szerezze meg ezt a diát a [Presentation::getSlides](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getslides/) által visszaadott gyűjteményből, indexével, 0.
3. Adjon hozzá egy téglalapot a [ShapeCollection::addAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addautoshape/) metódussal, és állítsa be a szövegét a [TextFrame::setText](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/settext/) segítségével.
4. Mentse a bemutatót PPTX fájlként a [Presentation::save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/save/) metódussal.

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once(__DIR__ . "/vendor/aspose/slides/hu/lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 400, 100);
    $shape->getTextFrame()->setText("Hello, Aspose.Slides!");
    $presentation->save(__DIR__ . "/hello.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

A két `require_once` sor betölti a PHP/Java Bridge klienst a Tomcatból és az Aspose.Slides osztályokat a Composer csomagból. A téglalap bal felső sarka 50 ponttal van a bal szegélytől és 50 ponttal a dia felső szegélyétől, a téglalap szélessége 400 pont, magassága pedig 100 pont. A mentett fájl egy diát tartalmaz a téglalappal és annak szövegével. Licenc nélkül az Aspose.Slides minden mentett diára értékelési vízjelet helyez; lásd a [Licensing](/slides/hu/php-java/licensing/) oldalt.

{{% alert color="info" title="Note" %}}
Az Aspose.Slides a Tomcaton belül olvas és ír fájlokat, nem a PHP folyamatban, ezért egy relatív útvonal, például `"hello.pptx"` a Tomcat munkakönyvtárához van relatívan feloldva. Az ezen az oldalon lévő példák abszolút útvonalakat építenek a `__DIR__` használatával, így a fájlok a szkript mellől vannak beolvasva és elmentve.
{{% /alert %}}

## **Bemutató létrehozása és mentése**

Üres bemutató létrehozásához és mentéséhez hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) osztályból, és mentse bármely a [SaveFormat](https://reference.aspose.com/slides/php-java/aspose.slides/saveformat/) felsorolásban szereplő formátumban. Az eredmény egy bemutató egy üres diával.

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once(__DIR__ . "/vendor/aspose/slides/hu/lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $presentation->save(__DIR__ . "/OutputPresentation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Bemutató megnyitása és mentése**

A bemutató egy formátumból egy másikba konvertálásához nyissa meg a [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) konstruktorának az útvonal átadásával, majd mentse a célformátumban. Az Aspose.Slides a bemeneti formátumot, például PPT, PPTX vagy ODP, a fájlból veszi észre.

Az alábbi példa egy *Sample.odp* nevű OpenDocument bemutatót vár a szkript mellől, és PPTX formátumban menti.

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once(__DIR__ . "/vendor/aspose/slides/hu/lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation(__DIR__ . "/Sample.odp");
try {
    $presentation->save(__DIR__ . "/OutputPresentation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **GYIK**

### Milyen formátumokba menthetek egy új bemutatót?

Menthet [PPTX, PPT és ODP](/slides/hu/php-java/save-presentation/) formátumokba, valamint exportálhat [PDF](/slides/hu/php-java/convert-powerpoint-to-pdf/), [XPS](/slides/hu/php-java/convert-powerpoint-to-xps/), [HTML](/slides/hu/php-java/convert-powerpoint-to-html/), [SVG](/slides/hu/php-java/render-a-slide-as-an-svg-image/) és [képek](/slides/hu/php-java/convert-powerpoint-to-png/) formátumokba, többek között.

### Kezdhetek sablonból (POTX/POTM), és menthetem szabványos PPTX-ként?

Igen. Töltse be a sablont, és mentse a kívánt formátumban; a POTX/POTM/PPTM és hasonló formátumok [támogatott](/slides/hu/php-java/supported-file-formats/).

### Hogyan szabályozhatom a dia méretét/méretarányát a bemutató létrehozásakor?

Állítsa be a [slide size](/slides/hu/php-java/slide-size/) (beleértve az olyan előre beállítottakat, mint 4:3 és 16:9, vagy egyedi méreteket) és válassza ki, hogyan méreteződjön a tartalom.

### Milyen egységekben mérik a méreteket és a koordinátákat?

Pontokban: 1 hüvelyk = 72 egység.

### Hogyan kezeljem a nagyon nagy bemutatókat (számos médiafájllal) a memóriahasználat csökkentése érdekében?

Használjon [BLOB management strategies](/slides/hu/php-java/manage-blob/) stratégiákat, korlátozza a memóriában tárolt adatot ideiglenes fájlok használatával, és részesítse előnyben a fájl-alapú munkafolyamatokat a kizárólag memóriában lévő adatfolyamok helyett.

### Készíthetek/menthetek bemutatókat párhuzamosan?

Nem működtethet ugyanazon a [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) példányon [több szál](/slides/hu/php-java/multithreading/) esetén. Indítson külön, elszigetelt példányokat szálanként vagy folyamatokként.

### Hogyan távolíthatom el a próbavízjelet és a korlátozásokat?

[Apply a license](/slides/hu/php-java/licensing/) egyszer a folyamatban. A licenc XML-nek változatlanul kell maradnia, és a licenc beállítást szinkronizálni kell, ha több szál is részt vesz.

### Digitálisan aláírhatom a létrehozott PPTX-et?

Igen. A [Digital signatures](/slides/hu/php-java/digital-signature-in-powerpoint/) (hozzáadás és ellenőrzés) támogatott a bemutatókhoz.

### Támogatottak a makrók (VBA) a létrehozott bemutatókban?

Igen. [create/edit VBA projects](/slides/hu/php-java/presentation-via-vba/) és macro-engedélyezett fájlok, például PPTM/PPSM mentése lehetséges.
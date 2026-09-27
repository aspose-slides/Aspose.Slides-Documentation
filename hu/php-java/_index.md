---
title: Aspose.Slides PHP-hez Java-n keresztül
second_title: Aspose.Slides PHP-hez
type: docs
weight: 45
url: /hu/php-java/
keywords:
- dokumentáció
- prezentációfeldolgozás
- prezentációkonverzió
- PowerPoint
- OpenDocument
- PHP
- Aspose.Slides
description: "Kezdje itt: telepítse az Aspose.Slides for PHP via Java-t, hozza létre az első prezentációt, és találja meg a gyakori feladatok útmutatóit, az API-referenciát és a támogatást."
is_root: true
---
<img src="aspose_slides-for-php-via-java.png" alt="Aspose.Slides PHP-hez Java-n keresztül" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Az Aspose.Slides for PHP via Java egy osztálykönyvtár PowerPoint és OpenDocument prezentációk létrehozásához, olvasásához, szerkesztéséhez és átalakításához PHP alkalmazásokban, a Microsoft PowerPoint vagy Office Automation nélkül.

Betölti és menti a PPT, PPTX, PPS, POT és ODP formátumokat, beleértve a makrókkal rendelkező és sablonváltozatokat, valamint exportál PDF, XPS, HTML, SVG, TIFF, Markdown és képek formátumokba.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Kezdő lépések</b></p>
<hr>
<p>ELKEZDÉS</p>
<ul>
<li><a href="/slides/hu/php-java/installation/">Telepítés</a></li>
<li><a href="/slides/hu/php-java/create-presentation/">Első prezentáció létrehozása</a></li>
<li><a href="/slides/hu/php-java/getting-started/">Útmutató a kezdéshez</a></li>
</ul>
<p>ÉRTÉKELÉS</p>
<ul>
<li><a href="/slides/hu/php-java/supported-file-formats/">Támogatott fájlformátumok</a></li>
<li><a href="/slides/hu/php-java/evaluate-aspose-slides/">Próba korlátok</a></li>
<li><a href="/slides/hu/php-java/licensing/">Licencelés</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Készítés Slides segítségével</b></p>
<hr>
<p>ÁLTALÁNOS FELADATOK</p>
<ul>
<li><a href="/slides/hu/php-java/open-presentation/">Prezentáció megnyitása</a></li>
<li><a href="/slides/hu/php-java/save-presentation/">Prezentáció mentése</a></li>
<li><a href="/slides/hu/php-java/convert-powerpoint-to-pdf/">PDF-re konvertálás</a></li>
<li><a href="/slides/hu/php-java/convert-slide/">Dia képek generálása</a></li>
<li><a href="/slides/hu/php-java/manage-text/">Szöveg és alakzatok szerkesztése</a></li>
</ul>
<p>SLIDES MUNKAFOLYAMOK</p>
<ul>
<li><a href="/slides/hu/php-java/powerpoint-charts/">Diagramok</a></li>
<li><a href="/slides/hu/php-java/powerpoint-animation/">Animációk</a></li>
<li><a href="/slides/hu/php-java/manage-media-files/">Hang és videó</a></li>
<li><a href="/slides/hu/php-java/presentation-design/">Dia tervezés</a></li>
<li><a href="/slides/hu/php-java/merge-presentation/">Prezentációk egyesítése</a></li>
</ul>
<p>PÉLDÁK</p>
<ul>
<li><a href="/slides/hu/php-java/examples/">Példák diaelemek szerint</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Referencia &amp; Támogatás</b></p>
<hr>
<p>REFERENCIA</p>
<ul>
<li><a href="https://reference.aspose.com/slides/php-java/">API referencia</a></li>
<li><a href="https://releases.aspose.com/slides/php-java/release-notes/">Kiadási jegyzetek</a></li>
<li><a href="/slides/hu/php-java/known-issues/">Ismert problémák</a></li>
<li><a href="https://releases.aspose.com/slides/php-java/">Letöltés</a></li>
</ul>
<p>TÁMOGATÁS</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">Ingyenes támogatási fórum</a></li>
<li><a href="https://helpdesk.aspose.com/">Fizetős támogatási helpdesk</a></li>
</ul>
</div>
</div>

------

## **Az első prezentációja**

Az Aspose.Slides for PHP via Java a Java környezetben fut az Apache Tomcat alatt, és a PHP szkriptek a PHP/Java Bridge-en keresztül érik el. [Telepítés](/slides/hu/php-java/installation/) telepíti a PHP 8.3 vagy annál régebbi verziót, a Java-t, a Tomcat-ot és a hídot, majd a Packagist csomagot telepíti egy projektmappába:

```bash
composer require aspose/slides
```

Ezután másolja a csomag JAR fájlját a bridge-be, és indítsa újra a Tomcat-ot, ahogyan a [Telepítés Linuxon](/slides/hu/php-java/installation/#install-on-linux) lépés 4-ben vagy a [Telepítés Windows-on](/slides/hu/php-java/installation/#install-on-windows) lépés 6-ban le van írva. A Tomcat futása közben mentse el ezt a szkriptet *hello.php*-ként a projektmappába, és futtassa `php hello.php`-t:

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

A szkript a *hello.pptx*-t a saját helyén menti, egy szövegdobozos diárral. Licenc nélkül a mentett fájl egy értékelő vízjelet tartalmaz – lásd a [Licencelés](/slides/hu/php-java/licensing/). További módok a prezentáció létrehozásához és feltöltéséhez a [Prezentációk létrehozása](/slides/hu/php-java/create-presentation/).
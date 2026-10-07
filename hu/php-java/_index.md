---
title: Aspose.Slides PHP-hez Java-on keresztül
second_title: Aspose.Slides PHP-hez
type: docs
weight: 45
url: /hu/php-java/
keywords:
- dokumentáció
- prezentáció feldolgozás
- prezentáció konvertálás
- PowerPoint
- OpenDocument
- PHP
- Aspose.Slides
description: "Kezdje itt: telepítse az Aspose.Slides for PHP via Java-t, hozza létre az első prezentációt, és találja meg a gyakori feladatok útmutatóit, az API referenciát és a támogatást."
is_root: true
---
<img src="aspose_slides-for-php-via-java.png" alt="Aspose.Slides for PHP via Java" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Az Aspose.Slides for PHP via Java egy osztálykönyvtár PowerPoint és OpenDocument prezentációk létrehozásához, olvasásához, szerkesztéséhez és átalakításához PHP alkalmazásokban, a Microsoft PowerPoint vagy az Office automatizáció nélkül.

Betölti és elmenti a PPT, PPTX, PPS, POT és ODP formátumokat, beleértve a makróval ellátott és sablon változatokat is, valamint exportál PDF, XPS, HTML, SVG, TIFF, Markdown és képek formátumba.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Első lépések</b></p>
<hr>
<p>ELKEZDÉS</p>
<ul>
<li><a href="/slides/hu/php-java/installation/">Telepítés</a></li>
<li><a href="/slides/hu/php-java/create-presentation/">Az első prezentáció létrehozása</a></li>
<li><a href="/slides/hu/php-java/getting-started/">Első lépések útmutató</a></li>
</ul>
<p>ÉRTÉKELÉS</p>
<ul>
<li><a href="/slides/hu/php-java/supported-file-formats/">Támogatott fájlformátumok</a></li>
<li><a href="/slides/hu/php-java/evaluate-aspose-slides/">Próba korlátozások</a></li>
<li><a href="/slides/hu/php-java/licensing/">Licencelés</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Készítés a Slides-szel</b></p>
<hr>
<p>ÁLTALÁNOS FELADATOK</p>
<ul>
<li><a href="/slides/hu/php-java/open-presentation/">Prezentáció megnyitása</a></li>
<li><a href="/slides/hu/php-java/save-presentation/">Prezentáció mentése</a></li>
<li><a href="/slides/hu/php-java/convert-powerpoint-to-pdf/">PDF-be konvertálás</a></li>
<li><a href="/slides/hu/php-java/convert-slide/">Diaok renderelése képként</a></li>
<li><a href="/slides/hu/php-java/manage-text/">Szöveg és alakzatok szerkesztése</a></li>
</ul>
<p>SLIDES MUNKAÁRAMOK</p>
<ul>
<li><a href="/slides/hu/php-java/powerpoint-charts/">Diagramok</a></li>
<li><a href="/slides/hu/php-java/powerpoint-animation/">Animációk</a></li>
<li><a href="/slides/hu/php-java/manage-media-files/">Hang és videó</a></li>
<li><a href="/slides/hu/php-java/presentation-design/">Dia tervezés</a></li>
<li><a href="/slides/hu/php-java/merge-presentation/">Prezentációk egyesítése</a></li>
</ul>
<p>PELDÁK</p>
<ul>
<li><a href="/slides/hu/php-java/examples/">Példák diaelemek szerint</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Referencia és támogatás</b></p>
<hr>
<p>REFERENCIA</p>
<ul>
<li><a href="https://reference.aspose.com/slides/php-java/">API referencia</a></li>
<li><a href="https://releases.aspose.com/slides/php-java/release-notes/">Kiadási megjegyzések</a></li>
<li><a href="/slides/hu/php-java/known-issues/">Ismert problémák</a></li>
<li><a href="https://products.aspose.com/slides/php-java/">Termékoldal</a></li>
<li><a href="https://releases.aspose.com/slides/php-java/">Letöltés</a></li>
</ul>
<p>TÁMOGATÁS</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">Ingyenes támogatói fórum</a></li>
<li><a href="https://helpdesk.aspose.com/">Fizetett támogatási helpdesk</a></li>
</ul>
</div>
</div>

------

## **Az első prezentációd**

Az Aspose.Slides for PHP via Java a Java környezetben fut az Apache Tomcaton belül, és a PHP szkriptjeid a PHP/Java Bridge-en keresztül érhetik el. [Telepítés](/slides/hu/php-java/installation/) beállítja a PHP 8.3 vagy korábbi verziót, a Javát, a Tomcatot és a Bridge-et, majd telepíti a csomagot a Packagist‑ról egy projekt mappába:

```bash
composer require aspose/slides
```

Ezután másold a csomag JAR fájlját a Bridge-be, és indítsd újra a Tomcatot, ahogyan azt a [Linuxra való telepítés](/slides/hu/php-java/installation/#install-on-linux) 4. lépésként vagy a [Windowsra való telepítés](/slides/hu/php-java/installation/#install-on-windows) 6. lépésében leírtuk. A Tomcat futtatásával mentsd el ezt a szkriptet *hello.php* néven a projekt mappájában, és futtasd a `php hello.php` parancsot:

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once(__DIR__ . "/vendor/aspose/slides/lib/aspose.slides.php");

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

A szkript elmenti a *hello.pptx* fájlt mellé, egy diát tartalmazva, amely szövegdobozt tartalmaz. Licenc nélkül a mentett fájl értékelési vízjelet tartalmaz – lásd a [Licencelés](/slides/hu/php-java/licensing/) oldalt. További módok a prezentáció létrehozására és kitöltésére a [Prezentációk létrehozása](/slides/hu/php-java/create-presentation/) alatt találhatók.
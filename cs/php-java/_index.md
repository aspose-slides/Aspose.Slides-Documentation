---
title: Aspose.Slides pro PHP přes Java
second_title: Aspose.Slides pro PHP
type: docs
weight: 45
url: /cs/php-java/
keywords:
- dokumentace
- zpracování prezentací
- konverze prezentací
- PowerPoint
- OpenDocument
- PHP
- Aspose.Slides
description: "Začněte zde: nainstalujte Aspose.Slides pro PHP přes Java, vytvořte první prezentaci a najděte průvodce pro běžné úkoly, referenční API a podporu."
is_root: true
---
<img src="aspose_slides-for-php-via-java.png" alt="Aspose.Slides for PHP via Java" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for PHP via Java je knihovna tříd pro vytváření, čtení, úpravu a konverzi prezentací PowerPoint a OpenDocument v aplikacích PHP, bez Microsoft PowerPoint nebo Office Automation.

Načítá a ukládá soubory PPT, PPTX, PPS, POT a ODP, včetně variant s makry a šablon, a exportuje do PDF, XPS, HTML, SVG, TIFF, Markdown a obrázků.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Začínáme</b></p>
<hr>
<p>ZAČÁTEK</p>
<ul>
<li><a href="/slides/cs/php-java/installation/">Instalace</a></li>
<li><a href="/slides/cs/php-java/create-presentation/">Vytvořte svou první prezentaci</a></li>
<li><a href="/slides/cs/php-java/getting-started/">Průvodce pro začátečníky</a></li>
</ul>
<p>EVALUACE</p>
<ul>
<li><a href="/slides/cs/php-java/supported-file-formats/">Podporované formáty souborů</a></li>
<li><a href="/slides/cs/php-java/evaluate-aspose-slides/">Omezení zkušební verze</a></li>
<li><a href="/slides/cs/php-java/licensing/">Licence</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Vytvořte pomocí Slides</b></p>
<hr>
<p>OBECNÉ ÚKOLY</p>
<ul>
<li><a href="/slides/cs/php-java/open-presentation/">Otevřít prezentaci</a></li>
<li><a href="/slides/cs/php-java/save-presentation/">Uložit prezentaci</a></li>
<li><a href="/slides/cs/php-java/convert-powerpoint-to-pdf/">Převést do PDF</a></li>
<li><a href="/slides/cs/php-java/convert-slide/">Vykreslit snímky jako obrázky</a></li>
<li><a href="/slides/cs/php-java/manage-text/">Upravit text a tvary</a></li>
</ul>
<p>PRACOVNÍ PROCESY SLIDES</p>
<ul>
<li><a href="/slides/cs/php-java/powerpoint-charts/">Grafy</a></li>
<li><a href="/slides/cs/php-java/powerpoint-animation/">Animace</a></li>
<li><a href="/slides/cs/php-java/manage-media-files/">Audio a video</a></li>
<li><a href="/slides/cs/php-java/presentation-design/">Návrh snímků</a></li>
<li><a href="/slides/cs/php-java/merge-presentation/">Sloučit prezentace</a></li>
</ul>
<p>PŘÍKLADY</p>
<ul>
<li><a href="/slides/cs/php-java/examples/">Příklady podle prvku snímku</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Reference a podpora</b></p>
<hr>
<p>REFERENCE</p>
<ul>
<li><a href="https://reference.aspose.com/slides/cs/php-java/">Reference API</a></li>
<li><a href="https://releases.aspose.com/slides/cs/php-java/release-notes/">Poznámky k vydání</a></li>
<li><a href="/slides/cs/php-java/known-issues/">Známé problémy</a></li>
<li><a href="https://releases.aspose.com/slides/cs/php-java/">Stáhnout</a></li>
</ul>
<p>PODPOŘA</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/cs/11">Bezplatné fórum podpory</a></li>
<li><a href="https://helpdesk.aspose.com/">Placená podpora helpdesk</a></li>
</ul>
</div>
</div>

------

## **Vaše první prezentace**

Aspose.Slides for PHP via Java běží na Javě uvnitř Apache Tomcat a vaše PHP skripty k němu přistupují prostřednictvím PHP/Java Bridge. [Instalace](/slides/cs/php-java/installation/) připraví PHP 8.3 nebo starší, Javu, Tomcat a most, a poté nainstaluje balíček z Packagist do složky projektu:

```bash
composer require aspose/slides
```

Poté zkopírujte JAR soubor balíčku do mostu a restartujte Tomcat, jako v kroku 4 [Instalace na Linuxu](/slides/cs/php-java/installation/#install-on-linux) nebo kroku 6 [Instalace na Windows](/slides/cs/php-java/installation/#install-on-windows). S běžícím Tomcatem uložte tento skript jako *hello.php* do složky projektu a spusťte `php hello.php`:

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once(__DIR__ . "/vendor/aspose/slides/cs/lib/aspose.slides.php");

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

Script uloží *hello.pptx* vedle sebe, s jedním snímkem obsahujícím textové pole. Bez licence má uložený soubor vodoznak evaluace — viz [Licence](/slides/cs/php-java/licensing/). Pro další způsoby tvorby a vyplnění prezentace viz [Vytvoření prezentací](/slides/cs/php-java/create-presentation/).
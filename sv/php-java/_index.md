---
title: Aspose.Slides för PHP via Java
second_title: Aspose.Slides för PHP
type: docs
weight: 45
url: /sv/php-java/
keywords:
- dokumentation
- presentationbearbetning
- presentationkonvertering
- PowerPoint
- OpenDocument
- PHP
- Aspose.Slides
description: "Börja här: installera Aspose.Slides för PHP via Java, skapa en första presentation och hitta guiderna för vanliga uppgifter, API-referensen och supporten."
is_root: true
---
<img src="aspose_slides-for-php-via-java.png" alt="Aspose.Slides för PHP via Java" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides för PHP via Java är ett klassbibliotek för att skapa, läsa, redigera och konvertera PowerPoint- och OpenDocument-presentationer i PHP‑applikationer, utan Microsoft PowerPoint eller Office‑automation.

Det laddar och sparar PPT, PPTX, PPS, POT och ODP, inklusive makro‑aktiverade och mallvarianter, och exporterar till PDF, XPS, HTML, SVG, TIFF, Markdown och bilder.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Kom igång</b></p>
<hr>
<p>KOM IGÅNG</p>
<ul>
<li><a href="/slides/sv/php-java/installation/">Installation</a></li>
<li><a href="/slides/sv/php-java/create-presentation/">Skapa din första presentation</a></li>
<li><a href="/slides/sv/php-java/getting-started/">Kom igång guide</a></li>
</ul>
<p>UTVÄRDERA</p>
<ul>
<li><a href="/slides/sv/php-java/supported-file-formats/">Filformat som stöds</a></li>
<li><a href="/slides/sv/php-java/evaluate-aspose-slides/">Begränsningar i provversionen</a></li>
<li><a href="/slides/sv/php-java/licensing/">Licensiering</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Bygg med Slides</b></p>
<hr>
<p>ALLMÄNNA UPPGIFTER</p>
<ul>
<li><a href="/slides/sv/php-java/open-presentation/">Öppna en presentation</a></li>
<li><a href="/slides/sv/php-java/save-presentation/">Spara en presentation</a></li>
<li><a href="/slides/sv/php-java/convert-powerpoint-to-pdf/">Konvertera till PDF</a></li>
<li><a href="/slides/sv/php-java/convert-slide/">Rendera bildspel som bilder</a></li>
<li><a href="/slides/sv/php-java/manage-text/">Redigera text och former</a></li>
</ul>
<p>SLIDES‑FLÖDEN</p>
<ul>
<li><a href="/slides/sv/php-java/powerpoint-charts/">Diagram</a></li>
<li><a href="/slides/sv/php-java/powerpoint-animation/">Animationer</a></li>
<li><a href="/slides/sv/php-java/manage-media-files/">Audio och video</a></li>
<li><a href="/slides/sv/php-java/presentation-design/">Slide‑design</a></li>
<li><a href="/slides/sv/php-java/merge-presentation/">Slå ihop presentationer</a></li>
</ul>
<p>EXEMPEL</p>
<ul>
<li><a href="/slides/sv/php-java/examples/">Exempel efter bild‑element</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Referens &amp; Support</b></p>
<hr>
<p>REFERENS</p>
<ul>
<li><a href="https://reference.aspose.com/slides/php-java/">API‑referens</a></li>
<li><a href="https://releases.aspose.com/slides/php-java/release-notes/">Versionsanteckningar</a></li>
<li><a href="/slides/sv/php-java/known-issues/">Kända problem</a></li>
<li><a href="https://products.aspose.com/slides/php-java/">Produktsida</a></li>
<li><a href="https://releases.aspose.com/slides/php-java/">Ladda ner</a></li>
</ul>
<p>SUPPORT</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">Gratis supportforum</a></li>
<li><a href="https://helpdesk.aspose.com/">Betald support‑helpdesk</a></li>
</ul>
</div>
</div>

------

## **Din första presentation**

Aspose.Slides för PHP via Java körs på Java inuti Apache Tomcat, och dina PHP‑skript når den via PHP/Java Bridge. [Installation](/slides/sv/php-java/installation/) installerar PHP 8.3 eller tidigare, Java, Tomcat och bryggan, och installerar sedan paketet från Packagist i en projektmapp:

```bash
composer require aspose/slides
```

Kopiera sedan paketets JAR‑fil till bryggan och starta om Tomcat, som i steg 4 i [Install on Linux](/slides/sv/php-java/installation/#install-on-linux) eller steg 6 i [Install on Windows](/slides/sv/php-java/installation/#install-on-windows). När Tomcat körs, spara detta skript som *hello.php* i projektmappen och kör `php hello.php`:

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

Scriptet sparar *hello.pptx* bredvid sig själv, med en bild som innehåller en textruta. Utan licens innehåller den sparade filen ett utvärderings‑vattenstämpel — se [Licensing](/slides/sv/php-java/licensing/). För fler sätt att skapa och fylla en presentation, se [Create Presentations](/slides/sv/php-java/create-presentation/).
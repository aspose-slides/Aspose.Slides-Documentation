---
title: Aspose.Slides voor PHP via Java
second_title: Aspose.Slides voor PHP
type: docs
weight: 45
url: /nl/php-java/
keywords:
- documentatie
- presentatieverwerking
- presentatieconversie
- PowerPoint
- OpenDocument
- PHP
- Aspose.Slides
description: "Begin hier: installeer Aspose.Slides voor PHP via Java, maak een eerste presentatie en vind de handleidingen voor veelvoorkomende taken, de API‑referentie en ondersteuning."
is_root: true
---
<img src="aspose_slides-for-php-via-java.png" alt="Aspose.Slides voor PHP via Java" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for PHP via Java is een klassebibliotheek voor het maken, lezen, bewerken en converteren van PowerPoint‑ en OpenDocument‑presentaties in PHP‑toepassingen, zonder Microsoft PowerPoint of Office‑automatisering.

Het laadt en slaat PPT, PPTX, PPS, POT en ODP op, inclusief macro‑ingeschakelde en sjabloonvarianten, en exporteert naar PDF, XPS, HTML, SVG, TIFF, Markdown en afbeeldingen.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Aan de slag</b></p>
<hr>
<p>Eerste stappen</p>
<ul>
<li><a href="/slides/nl/php-java/installation/">Installatie</a></li>
<li><a href="/slides/nl/php-java/create-presentation/">Creëer uw eerste presentatie</a></li>
<li><a href="/slides/nl/php-java/getting-started/">Gids voor het beginnen</a></li>
</ul>
<p>EVALUEREN</p>
<ul>
<li><a href="/slides/nl/php-java/supported-file-formats/">Ondersteunde bestandsformaten</a></li>
<li><a href="/slides/nl/php-java/evaluate-aspose-slides/">Beperking van de proefversie</a></li>
<li><a href="/slides/nl/php-java/licensing/">Licenties</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Bouw met Slides</b></p>
<hr>
<p>ALGEMENE TAKEN</p>
<ul>
<li><a href="/slides/nl/php-java/open-presentation/">Open een presentatie</a></li>
<li><a href="/slides/nl/php-java/save-presentation/">Sla een presentatie op</a></li>
<li><a href="/slides/nl/php-java/convert-powerpoint-to-pdf/">Converteer naar PDF</a></li>
<li><a href="/slides/nl/php-java/convert-slide/">Render dia's als afbeeldingen</a></li>
<li><a href="/slides/nl/php-java/manage-text/">Bewerk tekst en vormen</a></li>
</ul>
<p>SLIDES‑WERKSTROMEN</p>
<ul>
<li><a href="/slides/nl/php-java/powerpoint-charts/">Grafieken</a></li>
<li><a href="/slides/nl/php-java/powerpoint-animation/">Animaties</a></li>
<li><a href="/slides/nl/php-java/manage-media-files/">Audio en video</a></li>
<li><a href="/slides/nl/php-java/presentation-design/">Dia‑ontwerp</a></li>
<li><a href="/slides/nl/php-java/merge-presentation/">Samenvoegen van presentaties</a></li>
</ul>
<p>VOORBEELDEN</p>
<ul>
<li><a href="/slides/nl/php-java/examples/">Voorbeelden per dia‑element</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Referentie &amp; Ondersteuning</b></p>
<hr>
<p>REFERENTIE</p>
<ul>
<li><a href="https://reference.aspose.com/slides/nl/php-java/">API‑referentie</a></li>
<li><a href="https://releases.aspose.com/slides/nl/php-java/release-notes/">Release‑opmerkingen</a></li>
<li><a href="/slides/nl/php-java/known-issues/">Bekende problemen</a></li>
<li><a href="https://releases.aspose.com/slides/nl/php-java/">Download</a></li>
</ul>
<p>ONDERSTEUNING</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/nl/11">Gratis ondersteuningsforum</a></li>
<li><a href="https://helpdesk.aspose.com/">Betaalde ondersteunings‑helpdesk</a></li>
</ul>
</div>
</div>

------

## **Uw eerste presentatie**

Aspose.Slides for PHP via Java draait op Java binnen Apache Tomcat, en uw PHP‑scripts bereiken het via de PHP/Java Bridge. [Installatie](/slides/nl/php-java/installation/) bereidt PHP 8.3 of eerder, Java, Tomcat en de bridge voor, en installeert vervolgens het pakket van Packagist in een projectmap:

```bash
composer require aspose/slides
```

Kopieer vervolgens het JAR‑bestand van het pakket naar de bridge en herstart Tomcat, zoals in stap 4 van [Installeren op Linux](/slides/nl/php-java/installation/#install-on-linux) of stap 6 van [Installeren op Windows](/slides/nl/php-java/installation/#install-on-windows). Met Tomcat draaiend, sla dit script op als *hello.php* in de projectmap en voer `php hello.php` uit:

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once(__DIR__ . "/vendor/aspose/slides/nl/lib/aspose.slides.php");

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

Het script slaat *hello.pptx* op naast zichzelf, met één dia met een tekstvak. Zonder licentie bevat het opgeslagen bestand een evaluatiewatermerk — zie [Licenties](/slides/nl/php-java/licensing/). Voor meer manieren om een presentatie te maken en te vullen, zie [Presentaties maken](/slides/nl/php-java/create-presentation/).
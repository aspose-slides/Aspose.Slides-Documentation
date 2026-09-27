---
title: Aspose.Slides für PHP via Java
second_title: Aspose.Slides für PHP
type: docs
weight: 45
url: /de/php-java/
keywords:
- Dokumentation
- Präsentationsverarbeitung
- Präsentationskonvertierung
- PowerPoint
- OpenDocument
- PHP
- Aspose.Slides
description: "Beginnen Sie hier: Installieren Sie Aspose.Slides für PHP via Java, erstellen Sie Ihre erste Präsentation und finden Sie die Anleitungen für gängige Aufgaben, die API-Referenz und den Support."
is_root: true
---
<img src="aspose_slides-for-php-via-java.png" alt="Aspose.Slides for PHP via Java" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for PHP via Java ist eine Klassenbibliothek zum Erstellen, Lesen, Bearbeiten und Konvertieren von PowerPoint- und OpenDocument-Präsentationen in PHP-Anwendungen, ohne Microsoft PowerPoint oder Office‑Automation.

Sie lädt und speichert PPT, PPTX, PPS, POT und ODP, einschließlich makroaktivierter und Vorlagen‑Varianten, und exportiert nach PDF, XPS, HTML, SVG, TIFF, Markdown und Bildern.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Erste Schritte</b></p>
<hr>
<p>ERSTE SCHRITTE</p>
<ul>
<li><a href="/slides/de/php-java/installation/">Installation</a></li>
<li><a href="/slides/de/php-java/create-presentation/">Erstellen Sie Ihre erste Präsentation</a></li>
<li><a href="/slides/de/php-java/getting-started/">Leitfaden für die ersten Schritte</a></li>
</ul>
<p>BEWERTEN</p>
<ul>
<li><a href="/slides/de/php-java/supported-file-formats/">Unterstützte Dateiformate</a></li>
<li><a href="/slides/de/php-java/evaluate-aspose-slides/">Einschränkungen der Testversion</a></li>
<li><a href="/slides/de/php-java/licensing/">Lizenzierung</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Mit Slides bauen</b></p>
<hr>
<p>ALLGEMEINE AUFGABEN</p>
<ul>
<li><a href="/slides/de/php-java/open-presentation/">Eine Präsentation öffnen</a></li>
<li><a href="/slides/de/php-java/save-presentation/">Eine Präsentation speichern</a></li>
<li><a href="/slides/de/php-java/convert-powerpoint-to-pdf/">In PDF konvertieren</a></li>
<li><a href="/slides/de/php-java/convert-slide/">Folien als Bilder rendern</a></li>
<li><a href="/slides/de/php-java/manage-text/">Text und Formen bearbeiten</a></li>
</ul>
<p>SLIDES-ARBEITSABLÄUFE</p>
<ul>
<li><a href="/slides/de/php-java/powerpoint-charts/">Diagramme</a></li>
<li><a href="/slides/de/php-java/powerpoint-animation/">Animationen</a></li>
<li><a href="/slides/de/php-java/manage-media-files/">Audio und Video</a></li>
<li><a href="/slides/de/php-java/presentation-design/">Foliengestaltung</a></li>
<li><a href="/slides/de/php-java/merge-presentation/">Präsentationen zusammenführen</a></li>
</ul>
<p>BEISPIELE</p>
<ul>
<li><a href="/slides/de/php-java/examples/">Beispiele nach Folienelement</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Referenz &amp; Support</b></p>
<hr>
<p>REFERENZ</p>
<ul>
<li><a href="https://reference.aspose.com/slides/php-java/">API-Referenz</a></li>
<li><a href="https://releases.aspose.com/slides/php-java/release-notes/">Versionshinweise</a></li>
<li><a href="/slides/de/php-java/known-issues/">Bekannte Probleme</a></li>
<li><a href="https://releases.aspose.com/slides/php-java/">Download</a></li>
</ul>
<p>SUPPORT</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">Kostenloses Support-Forum</a></li>
<li><a href="https://helpdesk.aspose.com/">Kostenpflichtiger Support-Helpdesk</a></li>
</ul>
</div>
</div>

------

## **Ihre erste Präsentation**

Aspose.Slides for PHP via Java läuft auf Java innerhalb von Apache Tomcat, und Ihre PHP‑Skripte greifen über die PHP/Java‑Bridge darauf zu. [Installation](/slides/de/php-java/installation/) richtet PHP 8.3 oder früher, Java, Tomcat und die Bridge ein und installiert anschließend das Paket von Packagist in einem Projektordner:

```bash
composer require aspose/slides
```

Kopieren Sie dann die JAR‑Datei des Pakets in die Bridge und starten Tomcat neu, wie in Schritt 4 von [Install on Linux](/slides/de/php-java/installation/#install-on-linux) oder Schritt 6 von [Install on Windows](/slides/de/php-java/installation/#install-on-windows) beschrieben. Sobald Tomcat läuft, speichern Sie dieses Skript als *hello.php* im Projektordner und führen `php hello.php` aus:

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once(__DIR__ . "/vendor/aspose/slides/de/lib/aspose.slides.php");

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

Das Skript speichert *hello.pptx* neben sich, mit einer Folie, die ein Textfeld enthält. Ohne Lizenz enthält die gespeicherte Datei ein Evaluierungs‑Wasserzeichen — siehe [Licensing](/slides/de/php-java/licensing/). Weitere Methoden zum Erstellen und Befüllen einer Präsentation finden Sie unter [Create Presentations](/slides/de/php-java/create-presentation/).
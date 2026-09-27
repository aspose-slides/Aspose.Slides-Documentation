---
title: Aspose.Slides pour PHP via Java
second_title: Aspose.Slides pour PHP
type: docs
weight: 45
url: /fr/php-java/
keywords:
- documentation
- traitement de présentation
- conversion de présentation
- PowerPoint
- OpenDocument
- PHP
- Aspose.Slides
description: "Commencez ici : installez Aspose.Slides for PHP via Java, créez une première présentation, et trouvez les guides pour les tâches courantes, la référence API et le support."
is_root: true
---
<img src="aspose_slides-for-php-via-java.png" alt="Aspose.Slides pour PHP via Java" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for PHP via Java est une bibliothèque de classes permettant de créer, lire, modifier et convertir des présentations PowerPoint et OpenDocument dans des applications PHP, sans Microsoft PowerPoint ni automatisation Office.

Elle charge et enregistre les formats PPT, PPTX, PPS, POT et ODP, y compris les variantes avec macros et les modèles, et exporte vers PDF, XPS, HTML, SVG, TIFF, Markdown et images.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Commencer</b></p>
<hr>
<p>COMMENCER</p>
<ul>
<li><a href="/slides/fr/php-java/installation/">Installation</a></li>
<li><a href="/slides/fr/php-java/create-presentation/">Créez votre première présentation</a></li>
<li><a href="/slides/fr/php-java/getting-started/">Guide de démarrage</a></li>
</ul>
<p>ÉVALUER</p>
<ul>
<li><a href="/slides/fr/php-java/supported-file-formats/">Formats de fichiers pris en charge</a></li>
<li><a href="/slides/fr/php-java/evaluate-aspose-slides/">Limitations de l'évaluation</a></li>
<li><a href="/slides/fr/php-java/licensing/">Licence</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Construire avec Slides</b></p>
<hr>
<p>TÂCHES COURANTES</p>
<ul>
<li><a href="/slides/fr/php-java/open-presentation/">Ouvrir une présentation</a></li>
<li><a href="/slides/fr/php-java/save-presentation/">Enregistrer une présentation</a></li>
<li><a href="/slides/fr/php-java/convert-powerpoint-to-pdf/">Convertir en PDF</a></li>
<li><a href="/slides/fr/php-java/convert-slide/">Rendu des diapositives en images</a></li>
<li><a href="/slides/fr/php-java/manage-text/">Modifier le texte et les formes</a></li>
</ul>
<p>FLUX DE TRAVAIL SLIDES</p>
<ul>
<li><a href="/slides/fr/php-java/powerpoint-charts/">Graphiques</a></li>
<li><a href="/slides/fr/php-java/powerpoint-animation/">Animations</a></li>
<li><a href="/slides/fr/php-java/manage-media-files/">Audio et vidéo</a></li>
<li><a href="/slides/fr/php-java/presentation-design/">Conception de diapositives</a></li>
<li><a href="/slides/fr/php-java/merge-presentation/">Fusionner les présentations</a></li>
</ul>
<p>EXEMPLES</p>
<ul>
<li><a href="/slides/fr/php-java/examples/">Exemples par élément de diapositive</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Référence &amp; Support</b></p>
<hr>
<p>RÉFÉRENCE</p>
<ul>
<li><a href="https://reference.aspose.com/slides/php-java/">Référence API</a></li>
<li><a href="https://releases.aspose.com/slides/php-java/release-notes/">Notes de version</a></li>
<li><a href="/slides/fr/php-java/known-issues/">Problèmes connus</a></li>
<li><a href="https://releases.aspose.com/slides/php-java/">Télécharger</a></li>
</ul>
<p>SUPPORT</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">Forum d'assistance gratuit</a></li>
<li><a href="https://helpdesk.aspose.com/">Service d'assistance payant</a></li>
</ul>
</div>
</div>

------

## **Votre première présentation**

Aspose.Slides for PHP via Java fonctionne sur Java à l'intérieur d'Apache Tomcat, et vos scripts PHP y accèdent via PHP/Java Bridge. [Installation](/slides/fr/php-java/installation/) configure PHP 8.3 ou antérieur, Java, Tomcat et le pont, puis installe le paquet depuis Packagist dans un dossier de projet :

```bash
composer require aspose/slides
```

Ensuite, copiez le fichier JAR du paquet dans le bridge et redémarrez Tomcat, comme indiqué à l'étape 4 de [Install on Linux](/slides/fr/php-java/installation/#install-on-linux) ou à l'étape 6 de [Install on Windows](/slides/fr/php-java/installation/#install-on-windows). Avec Tomcat en cours d'exécution, enregistrez ce script sous *hello.php* dans le dossier du projet et exécutez `php hello.php` :

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once(__DIR__ . "/vendor/aspose/slides/fr/lib/aspose.slides.php");

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

Le script enregistre *hello.pptx* à côté de lui, avec une diapositive contenant une zone de texte. Sans licence, le fichier enregistré comporte un filigrane d'évaluation — voir [Licensing](/slides/fr/php-java/licensing/). Pour d'autres méthodes de création et de remplissage d'une présentation, consultez [Create Presentations](/slides/fr/php-java/create-presentation/).
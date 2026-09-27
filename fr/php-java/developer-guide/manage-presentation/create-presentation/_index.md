---
title: Créer des présentations en PHP
linktitle: Créer une présentation
type: docs
weight: 10
url: /fr/php-java/create-presentation/
keywords:
- créer une présentation
- nouvelle présentation
- créer PPT
- nouveau PPT
- créer PPTX
- nouveau PPTX
- créer ODP
- nouveau ODP
- PowerPoint
- OpenDocument
- présentation
- PHP
- Aspose.Slides
description: "Créer des présentations avec Aspose.Slides pour PHP via Java — produire des fichiers PPT, PPTX et ODP et les enregistrer de manière programmatique pour des résultats fiables."
---
## **Vue d'ensemble**

Cet article montre comment créer une présentation dans Aspose.Slides, ajouter une zone de texte à sa première diapositive et enregistrer le résultat dans un fichier. Il montre également comment créer et enregistrer une présentation vide, ainsi que comment ouvrir une présentation existante dans un format pris en charge et l'enregistrer dans un autre format. Une courte FAQ à la fin couvre les questions courantes concernant les formats, les modèles, la taille des diapositives, les unités, l'utilisation de la mémoire, le multithreading, la licence, les signatures numériques et la prise en charge de VBA.

Avant de commencer, installez Aspose.Slides pour PHP via Java avec Composer et lancez PHP/Java Bridge dans Apache Tomcat. Consultez [Installation](/slides/fr/php-java/installation/) pour la configuration complète. Les exemples ci-dessous supposent que Tomcat fonctionne sur `localhost:8080` et que le dossier `vendor` de Composer se trouve à côté du script.

## **Créer une présentation PowerPoint**

Pour créer une présentation et placer une zone de texte sur sa première diapositive, suivez ces étapes :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/). Une nouvelle présentation contient déjà une diapositive vide.
2. Récupérez cette diapositive dans la collection renvoyée par [Presentation::getSlides](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/getslides/), en utilisant son indice 0.
3. Ajoutez un rectangle avec la méthode [ShapeCollection::addAutoShape](https://reference.aspose.com/slides/fr/php-java/aspose.slides/shapecollection/addautoshape/) et définissez son texte avec [TextFrame::setText](https://reference.aspose.com/slides/fr/php-java/aspose.slides/textframe/settext/).
4. Enregistrez la présentation en tant que fichier PPTX avec la méthode [Presentation::save](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/save/).

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

Les deux lignes `require_once` chargent le client PHP/Java Bridge depuis Tomcat et les classes Aspose.Slides depuis le package Composer. Le coin supérieur gauche du rectangle se trouve à 50 points du bord gauche et à 50 points du bord supérieur de la diapositive, et le rectangle mesure 400 points de largeur sur 100 points de hauteur. Le fichier enregistré contient une diapositive avec ce rectangle et son texte. Sans licence, Aspose.Slides ajoute également un filigrane d'évaluation à chaque diapositive enregistrée ; voir [Licensing](/slides/fr/php-java/licensing/).

{{% alert color="info" title="Note" %}}
Aspose.Slides lit et écrit les fichiers à l'intérieur de Tomcat, pas dans votre processus PHP, ainsi un chemin relatif tel que `"hello.pptx"` est résolu par rapport au répertoire de travail de Tomcat. Les exemples de cette page construisent des chemins absolus avec `__DIR__`, de sorte que les fichiers sont lus et enregistrés à côté du script.
{{% /alert %}}

## **Créer et enregistrer une présentation**

Pour créer une présentation vide et l'enregistrer, créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/) et enregistrez‑la dans n'importe quel format de l'énumération [SaveFormat](https://reference.aspose.com/slides/fr/php-java/aspose.slides/saveformat/). Le résultat est une présentation avec une diapositive vide.

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once(__DIR__ . "/vendor/aspose/slides/fr/lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $presentation->save(__DIR__ . "/OutputPresentation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Ouvrir et enregistrer une présentation**

Pour convertir une présentation d'un format à un autre, ouvrez‑la en passant son chemin au constructeur [Presentation](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/), puis enregistrez‑la dans le format cible. Aspose.Slides détecte le format d'entrée, tel que PPT, PPTX ou ODP, à partir du fichier lui‑même.

L'exemple ci‑dessous suppose une présentation OpenDocument nommée *Sample.odp* à côté du script et l'enregistre au format PPTX.

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once(__DIR__ . "/vendor/aspose/slides/fr/lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation(__DIR__ . "/Sample.odp");
try {
    $presentation->save(__DIR__ . "/OutputPresentation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

### Quels formats puis‑je enregistrer pour une nouvelle présentation ?

Vous pouvez enregistrer au format [PPTX, PPT et ODP](/slides/fr/php-java/save-presentation/), et exporter en [PDF](/slides/fr/php-java/convert-powerpoint-to-pdf/), [XPS](/slides/fr/php-java/convert-powerpoint-to-xps/), [HTML](/slides/fr/php-java/convert-powerpoint-to-html/), [SVG](/slides/fr/php-java/render-a-slide-as-an-svg-image/) et [images](/slides/fr/php-java/convert-powerpoint-to-png/), entre autres.

### Puis‑je partir d'un modèle (POTX/POTM) et enregistrer en PPTX standard ?

Oui. Chargez le modèle et enregistrez‑le dans le format souhaité ; les formats POTX/POTM/PPTM et similaires [sont pris en charge](/slides/fr/php-java/supported-file-formats/).

### Comment contrôler la taille/le rapport d'aspect des diapositives lors de la création d'une présentation ?

Définissez la [taille de la diapositive](/slides/fr/php-java/slide-size/) (y compris les préréglages comme 4:3 et 16:9 ou des dimensions personnalisées) et choisissez comment le contenu doit être mis à l'échelle.

### Dans quelles unités les tailles et coordonnées sont‑elles mesurées ?

En points : 1 pouce correspond à 72 unités.

### Comment gérer des présentations très volumineuses (avec de nombreux médias) pour réduire l'utilisation de la mémoire ?

Utilisez les [stratégies de gestion des BLOB](/slides/fr/php-java/manage-blob/), limitez le stockage en mémoire en exploitant des fichiers temporaires, et privilégiez les flux de travail basés sur fichiers plutôt que les flux purement en mémoire.

### Puis‑je créer/enregistrer des présentations en parallèle ?

Vous ne pouvez pas manipuler la même instance [Presentation](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/) depuis [plusieurs threads](/slides/fr/php-java/multithreading/). Exécutez des instances séparées et isolées par thread ou processus.

### Comment supprimer le filigrane d'essai et les limitations ?

[Appliquez une licence](/slides/fr/php-java/licensing/) une fois par processus. Le XML de licence doit rester inchangé, et la configuration de la licence doit être synchronisée si plusieurs threads sont impliqués.

### Puis‑je signer numériquement le PPTX que je crée ?

Oui. Les [signatures numériques](/slides/fr/php-java/digital-signature-in-powerpoint/) (ajout et vérification) sont prises en charge pour les présentations.

### Les macros (VBA) sont‑elles prises en charge dans les présentations créées ?

Oui. Vous pouvez [créer/modifier des projets VBA](/slides/fr/php-java/presentation-via-vba/) et enregistrer des fichiers avec macros tels que PPTM/PPSM.
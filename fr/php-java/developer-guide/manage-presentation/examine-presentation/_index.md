---
title: Récupérer et mettre à jour les informations de présentation en PHP
linktitle: Informations sur la présentation
type: docs
weight: 30
url: /fr/php-java/examine-presentation/
keywords:
- format de présentation
- propriétés de présentation
- propriétés du document
- obtenir des propriétés
- lire les propriétés
- modifier les propriétés
- modifier les propriétés
- mettre à jour les propriétés
- examiner PPTX
- examiner PPT
- examiner ODP
- PowerPoint
- OpenDocument
- présentation
- PHP
- Aspose.Slides
description: "Explorez les diapositives, la structure et les métadonnées des présentations PowerPoint et OpenDocument à l'aide d'Aspose.Slides pour PHP pour obtenir des informations plus rapides et des audits de contenu plus intelligents."
---
## **Aperçu**

Aspose.Slides peut identifier le format d’une présentation et lire ses métadonnées de document sans créer un modèle d’objet de présentation complet. Ceci est utile lorsque vous devez classer des fichiers, créer un inventaire ou inspecter des propriétés avant de décider de charger et de traiter le contenu de la présentation.

Cet article montre l’inspection légère via [PresentationFactory](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentationfactory/) et [PresentationInfo](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentationinfo/), ainsi que des mises à jour ciblées via [DocumentProperties](https://reference.aspose.com/slides/fr/php-java/aspose.slides/documentproperties/).

## **Vérifier le format d’une présentation**

Utilisez [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentationfactory/) pour inspecter un fichier sans créer une instance de [Presentation](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/). La méthode [PresentationInfo::getLoadFormat](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentationinfo/#getLoadFormat) indique le format détecté, tel que PPTX, PPT ou ODP.

```php
use aspose\slides\LoadFormat;
use aspose\slides\PresentationFactory;

$fileNames = ["pres.pptx", "pres.ppt", "pres.odp"];

foreach ($fileNames as $fileName) {
    $presentationInfo = PresentationFactory::getInstance()->getPresentationInfo($fileName);
    $loadFormat = java_values($presentationInfo->getLoadFormat());
    $formatName = "Other (" . $loadFormat . ")";

    if ($loadFormat === LoadFormat::Pptx) {
        $formatName = "PPTX";
    } elseif ($loadFormat === LoadFormat::Ppt) {
        $formatName = "PPT";
    } elseif ($loadFormat === LoadFormat::Odp) {
        $formatName = "ODP";
    }

    echo $fileName . ": " . $formatName . PHP_EOL;
}
```

## **Construire un inventaire de présentations léger**

Lorsque vous traitez de nombreux fichiers de présentation, vous pouvez avoir besoin d’un inventaire compact pour la validation, l’indexation ou un système de gestion de documents. Dans ce scénario, utilisez [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentationfactory/) pour obtenir un objet [PresentationInfo](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentationinfo/), puis appelez [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentationinfo/#readDocumentProperties) pour lire les métadonnées du document. Cette approche ne crée pas d’instance de [Presentation](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/) et ne nécessite pas de parcourir le modèle complet de la présentation.

Les propriétés étendues exposées par [DocumentProperties](https://reference.aspose.com/slides/fr/php-java/aspose.slides/documentproperties/) fournissent les valeurs d’inventaire suivantes :

| Méthode | Valeur d'inventaire |
| --- | --- |
| [getSlides](https://reference.aspose.com/slides/fr/php-java/aspose.slides/documentproperties/#getSlides) | Nombre total de diapositives. |
| [getHiddenSlides](https://reference.aspose.com/slides/fr/php-java/aspose.slides/documentproperties/#getHiddenSlides) | Nombre de diapositives masquées. |
| [getNotes](https://reference.aspose.com/slides/fr/php-java/aspose.slides/documentproperties/#getNotes) | Nombre de diapositives contenant des notes. |
| [getParagraphs](https://reference.aspose.com/slides/fr/php-java/aspose.slides/documentproperties/#getParagraphs) | Nombre total de paragraphes, lorsqu’ils sont disponibles. |
| [getWords](https://reference.aspose.com/slides/fr/php-java/aspose.slides/documentproperties/#getWords) | Nombre total de mots. |
| [getMultimediaClips](https://reference.aspose.com/slides/fr/php-java/aspose.slides/documentproperties/#getMultimediaClips) | Nombre total de clips audio et vidéo. |

L’exemple suivant lit ces valeurs sans créer d’objet [Presentation](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/) et imprime un inventaire compact. Il combine également [DocumentProperties::getHeadingPairs](https://reference.aspose.com/slides/fr/php-java/aspose.slides/documentproperties/#getHeadingPairs) avec [DocumentProperties::getTitlesOfParts](https://reference.aspose.com/slides/fr/php-java/aspose.slides/documentproperties/#getTitlesOfParts) pour afficher les groupes de contenu tels que les polices, les thèmes et les titres de diapositives.

```php
use aspose\slides\LoadFormat;
use aspose\slides\PresentationFactory;

$filePath = "sample.pptx";
$presentationInfo = PresentationFactory::getInstance()->getPresentationInfo($filePath);
$documentProperties = $presentationInfo->readDocumentProperties();

$loadFormat = java_values($presentationInfo->getLoadFormat());
$formatName = "Other (" . $loadFormat . ")";

if ($loadFormat === LoadFormat::Pptx) {
    $formatName = "PPTX";
} elseif ($loadFormat === LoadFormat::Ppt) {
    $formatName = "PPT";
} elseif ($loadFormat === LoadFormat::Odp) {
    $formatName = "ODP";
}

echo "File: " . basename($filePath) . PHP_EOL;
echo "Format: " . $formatName . PHP_EOL;
echo "Title: " . java_values($documentProperties->getTitle()) . PHP_EOL;
echo "Author: " . java_values($documentProperties->getAuthor()) . PHP_EOL;
echo "Statistics:" . PHP_EOL;
echo "  Slides: " . java_values($documentProperties->getSlides()) . PHP_EOL;
echo "  Hidden slides: " . java_values($documentProperties->getHiddenSlides()) . PHP_EOL;
echo "  Slides with notes: " . java_values($documentProperties->getNotes()) . PHP_EOL;
echo "  Paragraphs: " . java_values($documentProperties->getParagraphs()) . PHP_EOL;
echo "  Words: " . java_values($documentProperties->getWords()) . PHP_EOL;
echo "  Multimedia clips: " . java_values($documentProperties->getMultimediaClips()) . PHP_EOL;

$headingPairs = $documentProperties->getHeadingPairs();
$titlesOfParts = $documentProperties->getTitlesOfParts();

if (java_is_null($headingPairs) || java_is_null($titlesOfParts)) {
    echo "Content groups: not available" . PHP_EOL;
} else {
    $headingPairs = java_values($headingPairs);
    $titlesOfParts = java_values($titlesOfParts);
    $partIndex = 0;

    if (count($headingPairs) === 0 || count($titlesOfParts) === 0) {
        echo "Content groups: not available" . PHP_EOL;
    } else {
        echo "Content groups:" . PHP_EOL;

        foreach ($headingPairs as $headingPair) {
            $partCount = java_values($headingPair->getCount());
            echo "  " . java_values($headingPair->getName()) . " (" . $partCount . ")" . PHP_EOL;

            for ($partOffset = 0; $partOffset < $partCount && $partIndex < count($titlesOfParts); $partOffset++) {
                echo "    - " . $titlesOfParts[$partIndex] . PHP_EOL;
                $partIndex++;
            }
        }

        if ($partIndex < count($titlesOfParts)) {
            echo "  Other parts:" . PHP_EOL;

            while ($partIndex < count($titlesOfParts)) {
                echo "    - " . $titlesOfParts[$partIndex] . PHP_EOL;
                $partIndex++;
            }
        }
    }
}
```

Chaque [HeadingPair](https://reference.aspose.com/slides/fr/php-java/aspose.slides/headingpair/) fournit un nom de groupe et le nombre d’éléments dans ce groupe. [DocumentProperties::getTitlesOfParts](https://reference.aspose.com/slides/fr/php-java/aspose.slides/documentproperties/#getTitlesOfParts) renvoie un tableau plat et ordonné, il faut donc consommer le nombre de titres consécutifs spécifié par chaque paire d’en-tête.

### **Métadonnées stockées et limitations de format**

Les propriétés d’inventaire renvoyées par [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentationinfo/#readDocumentProperties) reflètent les métadonnées disponibles dans le document source. Aspose.Slides ne charge pas et ne parcourt pas le modèle d’objet de la présentation pour recalculer ces valeurs lors de cet appel. Les propriétés manquantes sont représentées par des valeurs par défaut, et les valeurs stockées peuvent être obsolètes si l’application ayant enregistré le fichier en dernier n’a pas mis à jour ses propriétés de document.

- **PPTX :** Le format fournit des propriétés de document étendues pour le nombre de diapositives, de notes, de diapositives masquées, de paragraphes, de mots et de contenus multimédias, ainsi que pour les paires d’en‑têtes et les titres de parties. Leur disponibilité dépend des propriétés écrites par le producteur du document.
- **PPT :** Le format binaire peut stocker des propriétés de résumé de document correspondantes. Si une propriété est absente ou n’a pas été actualisée par le producteur du document, Aspose.Slides renvoie sa valeur stockée ou la valeur par défaut au lieu de la calculer à partir des diapositives.
- **ODP :** Les métadonnées OpenDocument fournissent des statistiques générales du document, telles que le nombre de pages, de paragraphes et de mots, mais ces valeurs ne correspondent pas à toutes les propriétés étendues spécifiques à PowerPoint. Les métadonnées de diapositives masquées, de notes, de contenus multimédias, de paires d’en‑têtes et de titres de parties peuvent être indisponibles, et les propriétés d’inventaire peuvent renvoyer des valeurs par défaut. Ne considérez pas une valeur zéro ou un tableau vide comme une preuve définitive que le contenu correspondant est absent.

Utilisez l’approche de métadonnées légères pour les inventaires et les vérifications préliminaires. Chargez la présentation et inspectez son modèle d’objet en mémoire lorsque le résultat doit refléter les modifications en cours ou lorsque vous devez vérifier le contenu réel de la présentation.

## **Mettre à jour les propriétés de la présentation**

Les propriétés renvoyées par [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentationinfo/#readDocumentProperties) peuvent également être modifiées sans créer d’instance de [Presentation](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/). Appliquez les changements avec [PresentationInfo::updateDocumentProperties](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentationinfo/#updateDocumentProperties), puis écrivez la présentation liée avec [PresentationInfo::writeBindedPresentation](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentationinfo/#writeBindedPresentation).

L’image suivante montre les propriétés de document d’origine.

![Original document properties of the PowerPoint presentation](input_properties.png)

L’exemple suivant modifie le titre et la date de dernière sauvegarde et écrit le résultat dans un nouveau fichier :

```php
use aspose\slides\PresentationFactory;

$sourceFile = "sample.pptx";
$outputFile = "sample_with_updated_properties.pptx";
$presentationInfo = PresentationFactory::getInstance()->getPresentationInfo($sourceFile);
$documentProperties = $presentationInfo->readDocumentProperties();

$documentProperties->setTitle("Quarterly sales report");
$documentProperties->setLastSavedTime(new Java("java.util.Date"));

$presentationInfo->updateDocumentProperties($documentProperties);
$outputStream = new Java("java.io.FileOutputStream", $outputFile);
try {
    $presentationInfo->writeBindedPresentation($outputStream);
} finally {
    $outputStream->close();
}
```

L’image suivante montre les propriétés de document mises à jour.

![Changed document properties of the PowerPoint presentation](output_properties.png)

## **Liens utiles**

Pour des contrôles de sécurité associés et des paramètres de protection, consultez les articles suivants :

- [Password-Protect Presentations](/slides/fr/php-java/password-protected-presentation/)
- [Write-Protect Presentations](/slides/fr/php-java/write-protected-presentation/)

## **FAQ**

**Comment vérifier si les polices sont intégrées et lesquelles ?**

Chargez la présentation et utilisez [Presentation::getFontsManager](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/#getFontsManager). Appelez [FontsManager::getEmbeddedFonts](https://reference.aspose.com/slides/fr/php-java/aspose.slides/fontsmanager/#getEmbeddedFonts) pour obtenir les polices intégrées et [FontsManager::getFonts](https://reference.aspose.com/slides/fr/php-java/aspose.slides/fontsmanager/#getFonts) pour obtenir les polices utilisées par la présentation. Comparez les deux résultats pour identifier les polices nécessaires à l’affichage mais non intégrées.

**Comment savoir rapidement si le fichier contient des diapositives masquées et combien ?**

Lorsque les métadonnées du document stockées sont suffisantes, lisez [DocumentProperties::getHiddenSlides](https://reference.aspose.com/slides/fr/php-java/aspose.slides/documentproperties/#getHiddenSlides) via [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentationfactory/) et [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentationinfo/#readDocumentProperties). Cela convient pour un inventaire léger. Si la présentation a été modifiée en mémoire, les métadonnées stockées peuvent être manquantes ou obsolètes, ou si vous devez vérifier les valeurs en direct, parcourez [Presentation::getSlides](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/#getSlides) et inspectez chaque méthode [Slide::getHidden](https://reference.aspose.com/slides/fr/php-java/aspose.slides/slide/#getHidden) de la diapositive.

**Puis‑je détecter si une taille et une orientation de diapositive personnalisées sont utilisées, et si elles diffèrent des valeurs par défaut ?**

Oui. Chargez la présentation et appelez [Presentation::getSlideSize](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/#getSlideSize). Utilisez [SlideSize::getType](https://reference.aspose.com/slides/fr/php-java/aspose.slides/slidesize/#getType), [SlideSize::getSize](https://reference.aspose.com/slides/fr/php-java/aspose.slides/slidesize/#getSize) et [SlideSize::getOrientation](https://reference.aspose.com/slides/fr/php-java/aspose.slides/slidesize/#getOrientation) pour comparer les paramètres actuels aux valeurs prédéfinies attendues.

**Existe‑t‑il un moyen rapide de voir si les graphiques font référence à des sources de données externes ?**

Oui. Localisez chaque [Chart](https://reference.aspose.com/slides/fr/php-java/aspose.slides/chart/) et appelez [ChartData::getDataSourceType](https://reference.aspose.com/slides/fr/php-java/aspose.slides/chartdata/#getDataSourceType). Pour un classeur externe, appelez [ChartData::getExternalWorkbookPath](https://reference.aspose.com/slides/fr/php-java/aspose.slides/chartdata/#getExternalWorkbookPath). Le type de source de données et le chemin identifient une référence externe, mais la vérification de la disponibilité de la cible nécessite une vérification de ressources distincte.

**Comment évaluer les diapositives « lourdes » qui peuvent ralentir le rendu ou l’export PDF ?**

Il n’existe pas de propriété unique de complexité. Parcourez [Presentation::getSlides](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/#getSlides) et la collection [BaseSlide::getShapes](https://reference.aspose.com/slides/fr/php-java/aspose.slides/baseslide/#getShapes) de chaque diapositive. Utilisez le nombre de formes et la présence d’images volumineuses, d’effets, d’animations ou de contenus multimédias comme indicateurs de filtrage, et mesurez un rendu ou une exportation représentatif avant de considérer une diapositive comme un goulet d’étranglement de performance.
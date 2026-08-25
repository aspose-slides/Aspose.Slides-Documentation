---
title: Convertir PPT en PPTX en PHP
linktitle: PPT en PPTX
type: docs
weight: 20
url: /fr/php-java/convert-ppt-to-pptx/
keywords:
- convertir PowerPoint
- convertir présentation
- convertir diapositive
- convertir PPT
- PPT en PPTX
- enregistrer PPT en PPTX
- exporter PPT en PPTX
- PowerPoint
- présentation
- PHP
- Aspose.Slides
description: "Convertir les fichiers PPT hérités en PPTX en PHP avec Aspose.Slides. Inclut des exemples PHP pour la conversion d’un seul fichier et par lots, la gestion des erreurs et des notes de fidélité."
---
## **Vue d'ensemble**

PPT est le format binaire hérité de PowerPoint, tandis que PPTX est le format Open XML plus récent. Aspose.Slides for PHP via Java peut charger un fichier PPT et l’enregistrer en PPTX sans Microsoft PowerPoint. Cet article montre comment convertir un fichier ou un répertoire de fichiers et explique quoi vérifier après la conversion.

## **Convertir un fichier PPT en PPTX**

Chargez le fichier source avec la classe [Presentation](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/), puis appelez [Presentation::save](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/#save) avec [SaveFormat::Pptx](https://reference.aspose.com/slides/fr/php-java/aspose.slides/saveformat/#Pptx). Le bloc `finally` libère la présentation et ses ressources.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

// Charger la présentation PPT héritée.
$presentation = new Presentation("presentation.ppt");
try {
    // Enregistrer la présentation au format PPTX.
    $presentation->save("presentation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

L'extension du fichier ne détermine pas le format de sortie à elle seule ; c’est l’argument [SaveFormat::Pptx](https://reference.aspose.com/slides/fr/php-java/aspose.slides/saveformat/#Pptx) qui le fait. Gardez les chemins d’entrée et de sortie différents si vous devez conserver le fichier PPT original.

## **Convertir plusieurs fichiers PPT**

L'exemple suivant convertit chaque fichier `.ppt` d'un répertoire. Chaque fichier est traité indépendamment, de sorte qu'une conversion échouée n'arrête pas le reste du lot.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$inputDirectory = "input";
$outputDirectory = "output";
if (!is_dir($outputDirectory) && !mkdir($outputDirectory, 0777, true)) {
    throw new RuntimeException("Cannot create the output directory: " . $outputDirectory);
}

$inputFiles = [];
foreach (new DirectoryIterator($inputDirectory) as $fileInfo) {
    if ($fileInfo->isFile() && strtolower($fileInfo->getExtension()) === "ppt") {
        $inputFiles[] = $fileInfo->getPathname();
    }
}

foreach ($inputFiles as $inputPath) {
    $outputFileName = pathinfo($inputPath, PATHINFO_FILENAME) . ".pptx";
    $outputPath = $outputDirectory . DIRECTORY_SEPARATOR . $outputFileName;
    $presentation = null;

    try {
        $presentation = new Presentation($inputPath);
        $presentation->save($outputPath, SaveFormat::Pptx);
        echo "Converted: " . $inputPath . PHP_EOL;
    } catch (Throwable $exception) {
        fwrite(STDERR, "Failed: " . $inputPath . " (" . $exception->getMessage() . ")" . PHP_EOL);
    } finally {
        if ($presentation !== null) {
            $presentation->dispose();
        }
    }
}
```

Pour les charges de travail en production, consignez l'exception complète, décidez si un fichier de sortie existant peut être écrasé, et enregistrez les noms des fichiers ayant échoué dans une file d'attente de réessai ou de révision. Les fichiers corrompus, les fichiers protégés par mot de passe ouverts sans le mot de passe requis, les chemins inaccessibles et le contenu non pris en charge peuvent tous entraîner un échec de conversion. Consultez [Password-Protected Presentations](/slides/fr/php-java/password-protected-presentation/) pour charger des fichiers chiffrés.

## **Fidélité et fonctionnalités héritées**

La conversion préserve généralement les diapositives, les maîtres, les mises en page, le texte, les formes, les images, les tableaux et les graphiques. Cependant, PPT et PPTX ne représentent pas chaque fonctionnalité de la même manière exacte. Une fonctionnalité héritée qui n’a pas d’équivalent PPTX, ou qui n’est pas prise en charge par la bibliothèque, peut être normalisée, omise ou affichée différemment.

Vérifiez le fichier converti lorsqu’il contient des animations, des transitions, des objets OLE incorporés ou liés, des contrôles ActiveX, des médias intégrés, des polices rares ou des macros VBA. Un fichier PPTX standard n’est pas un format activé pour les macros, il faut donc utiliser un flux de travail approprié pour les macros lorsque VBA doit rester disponible. Vérifiez également que les polices requises et les ressources externes sont présentes dans l’environnement où la présentation convertie sera ouverte ou rendue.

Pour les documents importants, rouvrez le PPTX généré par programme et examinez le nombre de diapositives et le contenu clés, puis comparez son apparence et son comportement en diaporama dans le visualiseur prévu. Ne considérez pas qu’un appel réussi à [Presentation::save](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/#save) prouve que chaque fonctionnalité héritée possède une représentation PPTX exacte.

## **Quand utiliser PPTX**

Utilisez PPTX lorsque la présentation sera éditée avec les versions actuelles de PowerPoint, échangée avec des systèmes qui travaillent avec des packages Open XML, ou stockée dans un format plus facile à inspecter et récupérer que le PPT binaire hérité. Conservez le PPT original comme copie d’archivage ou de restauration jusqu’à ce que la présentation convertie ait passé vos contrôles de fidélité.

Si vous avez besoin de PDF, HTML, images, XPS ou d’un autre type de sortie à la place, utilisez les conseils spécifiques au format dans [Convert Presentations to Multiple Formats](/slides/fr/php-java/convert-presentation/) plutôt que de supposer que toutes les cibles conservent les fonctionnalités PowerPoint modifiables.

## **Convertisseur en ligne**

Pour un fichier occasionnel ou une comparaison rapide, vous pouvez utiliser le [convertisseur PPT vers PPTX en ligne](https://products.aspose.app/slides/fr/conversion/ppt-to-pptx). Pour des conversions répétables, un traitement par lots ou une gestion d’erreurs au niveau de l’application, utilisez l’API PHP.

## **Articles liés**

- [PPT vs PPTX](/slides/fr/php-java/ppt-vs-pptx/)
- [Enregistrer des présentations en PHP](/slides/fr/php-java/save-presentation/)
- [Formats de fichiers pris en charge](/slides/fr/php-java/supported-file-formats/)
- [Ouvrir des présentations en PHP](/slides/fr/php-java/open-presentation/)

## **FAQ**

**Puis-je convertir PPT en PPTX sans Microsoft PowerPoint installé ?**

Oui. Aspose.Slides for PHP via Java charge et enregistre les fichiers de présentation sans nécessiter Microsoft PowerPoint.

**La conversion PPT vers PPTX préservera-t-elle tout le contenu exactement ?**

Elle préserve le contenu de présentation commun, mais la fidélité exacte n’est pas garantie pour chaque fonctionnalité héritée ou non prise en charge. Examinez le fichier généré lorsqu’il contient des macros, des objets OLE ou ActiveX, des médias, des animations spécialisées ou des polices rares.

**Puis-je convertir un fichier PPT protégé par mot de passe ?**

Oui, si vous fournissez le mot de passe correct lors du chargement du fichier. Un mot de passe manquant ou incorrect entraîne l’échec de l’opération de chargement.

**Dois-je supprimer le fichier PPT après la conversion ?**

Conservez l’original jusqu’à ce que vous ayez vérifié le PPTX dans les visualiseurs et flux de travail qui vous importent. Cela fournit une copie de restauration si une fonctionnalité héritée se convertit différemment.
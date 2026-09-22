---
title: Enregistrer des présentations en PHP
linktitle: Enregistrer une présentation
type: docs
weight: 80
url: /fr/php-java/save-presentation/
keywords:
- enregistrer PowerPoint
- enregistrer OpenDocument
- enregistrer présentation
- enregistrer diapositive
- enregistrer PPT
- enregistrer PPTX
- enregistrer ODP
- présentation vers fichier
- présentation vers flux
- type de vue prédéfini
- format Office Open XML strict
- mode Zip64
- actualisation de la vignette
- progression d’enregistrement
- PHP
- Aspose.Slides
description: "Enregistrez des présentations PowerPoint et OpenDocument dans des fichiers ou des flux en PHP avec Aspose.Slides, et configurez la sortie PPTX ainsi que le reporting de progression."
---
## **Aperçu**

Après avoir créé une présentation ou [ouvrir une existante](/slides/fr/php-java/open-presentation/), utilisez la méthode [Presentation::save](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/#save) pour écrire le résultat. Aspose.Slides for PHP via Java peut enregistrer une présentation dans un fichier ou un flux aux formats PowerPoint, OpenDocument, PDF et d’autres formats. Les sections suivantes couvrent les opérations d’enregistrement standard et les options disponibles pour la sortie PPTX.

## **Enregistrer les présentations dans des fichiers**

Pour enregistrer une présentation dans un fichier, transmettez le chemin de sortie et une valeur [SaveFormat](https://reference.aspose.com/slides/fr/php-java/aspose.slides/saveformat/) à la méthode [Presentation::save](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/#save). La valeur du format détermine le type de fichier créé par Aspose.Slides.

L’exemple suivant crée une présentation et l’enregistre au format PPTX :

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    // Ajouter ou modifier le contenu de la présentation ici.

    $presentation->save("Output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Enregistrer les présentations dans leur format d'origine**

Pour les exemples de détection de fichiers et de flux, le comportement des présentations nouvellement créées et la distinction entre les formats source et de sortie, consultez [Déterminer le format d'origine de la présentation](/slides/fr/php-java/detect-presentation-source-format/).

Dans une application de traitement par lots, le format d'entrée peut ne pas être connu à l’avance. Après avoir chargé un fichier, lisez son format d'origine avec la méthode [Presentation::getSourceFormat](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/#getSourceFormat). Transmettez la valeur [SourceFormat](https://reference.aspose.com/slides/fr/php-java/aspose.slides/sourceformat/) obtenue à [SlideUtil::toSaveFormat](https://reference.aspose.com/slides/fr/php-java/aspose.slides/slideutil/#toSaveFormat) pour obtenir la valeur correspondante de [SaveFormat](https://reference.aspose.com/slides/fr/php-java/aspose.slides/saveformat/), puis utilisez [Presentation::save](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/#save) pour écrire la présentation modifiée.

L’exemple complet suivant traite chaque fichier d’un répertoire d’entrée, met à jour son titre et l’enregistre dans un répertoire de sortie au même format que celui dans lequel il a été chargé :

```php
use aspose\slides\Presentation;
use aspose\slides\SlideUtil;

$inputDirectory = __DIR__ . DIRECTORY_SEPARATOR . "Input";
$outputDirectory = __DIR__ . DIRECTORY_SEPARATOR . "Output";

if (!is_dir($outputDirectory) && !mkdir($outputDirectory, 0777, true)) {
    echo("Cannot create the output directory." . PHP_EOL);
}

$inputFiles = is_dir($inputDirectory) ? scandir($inputDirectory) : false;
if ($inputFiles !== false && is_dir($outputDirectory)) {
    foreach ($inputFiles as $fileName) {
        $inputPath = $inputDirectory . DIRECTORY_SEPARATOR . $fileName;
        if (!is_file($inputPath)) {
            continue;
        }

        $presentation = null;
        $presentationLoaded = false;
        try {
            $presentation = new Presentation($inputPath);
            $presentationLoaded = true;
            $saveFormat = SlideUtil::toSaveFormat($presentation->getSourceFormat());
            $presentation->getDocumentProperties()->setTitle("Processed by the batch application");

            $outputPath = $outputDirectory . DIRECTORY_SEPARATOR . $fileName;
            $presentation->save($outputPath, $saveFormat);
        } catch (\Throwable $exception) {
            echo("Cannot process '" . $inputPath . "': " . $exception->getMessage() . PHP_EOL);
        } finally {
            if ($presentationLoaded) {
                $presentation->dispose();
            }
        }
    }
}
```

[SlideUtil::toSaveFormat](https://reference.aspose.com/slides/fr/php-java/aspose.slides/slideutil/#toSaveFormat) associe PPT, PPTX, ODP, PPTM, PPSX, PPSM, POTX, POTM, PPS, POT, OTP, FODP et PowerPoint XML à leurs formats d’enregistrement de présentation correspondants. Il ne mappe que les formats source de présentation ; il n’est pas destiné à sélectionner des formats d’exportation tels que PDF, HTML, TIFF ou des images. Le passage d’une valeur [SourceFormat](https://reference.aspose.com/slides/fr/php-java/aspose.slides/sourceformat/) non prise en charge ou invalide entraîne une [IllegalArgumentException](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/lang/IllegalArgumentException.html).

Les fichiers PPT, PPS et POT hérités utilisent le même conteneur binaire. Lorsqu’une telle présentation est chargée à partir d’un flux sans extension de fichier, un fichier PPS ou POT peut donc être identifié comme PPT. Si la conservation de ces sous‑types hérités est requise, conservez séparément le nom de fichier original ou les métadonnées de format et utilisez‑les lors du choix du nom de fichier et du format de sortie.

## **Enregistrer les présentations dans des flux**

Pour écrire une présentation sans dépendre d’un chemin de fichier final, transmettez un flux en écriture et une valeur [SaveFormat](https://reference.aspose.com/slides/fr/php-java/aspose.slides/saveformat/) à la méthode [Presentation::save](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/#save). Cette approche est utile lorsque la sortie doit être renvoyée depuis un service Web, stockée dans une base de données ou traitée en mémoire.

L’exemple suivant enregistre une nouvelle présentation dans un flux de fichier :

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $outputStream = new Java("java.io.FileOutputStream", "Output.pptx");
    try {
        $presentation->save($outputStream, SaveFormat::Pptx);
    } finally {
        $outputStream->close();
    }
} finally {
    $presentation->dispose();
}
```

## **Enregistrer les présentations avec un type de vue prédéfini**

Vous pouvez spécifier la vue dans laquelle PowerPoint ouvre initialement une présentation enregistrée. Utilisez la méthode [ViewProperties::setLastView](https://reference.aspose.com/slides/fr/php-java/aspose.slides/viewproperties/#setLastView) avec une valeur [ViewType](https://reference.aspose.com/slides/fr/php-java/aspose.slides/viewtype/) avant d’enregistrer.

L’exemple suivant configure la vue Maître des diapositives comme vue initiale :

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ViewType;

$presentation = new Presentation();
try {
    $presentation->getViewProperties()->setLastView(ViewType::SlideMasterView);
    $presentation->save("SlideMasterView.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Enregistrer les présentations au format Office Open XML strict**

Pour créer un fichier PPTX conforme au profil Strict d’Office Open XML, créez une instance [PptxOptions](https://reference.aspose.com/slides/fr/php-java/aspose.slides/pptxoptions/) et utilisez sa méthode [PptxOptions::setConformance](https://reference.aspose.com/slides/fr/php-java/aspose.slides/pptxoptions/#setConformance) avec la valeur [Conformance::Iso29500_2008_Strict](https://reference.aspose.com/slides/fr/php-java/aspose.slides/conformance/#Iso29500-2008-Strict). Transmettez ensuite les options à la méthode [Presentation::save](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/#save).

```php
use aspose\slides\Conformance;
use aspose\slides\PptxOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$options = new PptxOptions();
$options->setConformance(Conformance::Iso29500_2008_Strict);

$presentation = new Presentation();
try {
    $presentation->save("StrictOfficeOpenXml.pptx", SaveFormat::Pptx, $options);
} finally {
    $presentation->dispose();
}
```

## **Enregistrer les présentations au format Office Open XML en mode Zip64**

Une archive ZIP standard limite la taille compressée et non compressée de chaque entrée, la taille totale de l’archive et le nombre d’entrées. Comme un fichier PPTX est une archive ZIP, une présentation très volumineuse peut dépasser ces limites. Les extensions ZIP64 augmentent les limites de taille et de nombre d’entrées applicables.

Utilisez la méthode [PptxOptions::setZip64Mode](https://reference.aspose.com/slides/fr/php-java/aspose.slides/pptxoptions/#setZip64Mode) pour contrôler si Aspose.Slides écrit les extensions ZIP64 :

- [IfNecessary](https://reference.aspose.com/slides/fr/php-java/aspose.slides/zip64mode/#IfNecessary) utilise ZIP64 uniquement lorsque la présentation dépasse les limites ZIP standard. C’est le mode par défaut.
- [Never](https://reference.aspose.com/slides/fr/php-java/aspose.slides/zip64mode/#Never) désactive les extensions ZIP64.
- [Always](https://reference.aspose.com/slides/fr/php-java/aspose.slides/zip64mode/#Always) écrit toujours les extensions ZIP64.

L’exemple suivant active toujours les extensions ZIP64 pour la présentation de sortie :

```php
use aspose\slides\PptxOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\Zip64Mode;

$presentation = new Presentation("Sample.pptx");
try {
    $options = new PptxOptions();
    $options->setZip64Mode(Zip64Mode::Always);

    $presentation->save("OutputZip64.pptx", SaveFormat::Pptx, $options);
} finally {
    $presentation->dispose();
}
```

{{% alert color="warning" title="Warning" %}}
Si [Zip64Mode::Never](https://reference.aspose.com/slides/fr/php-java/aspose.slides/zip64mode/#Never) est utilisé et que la présentation ne peut pas tenir dans les limites ZIP standard, l’opération d’enregistrement lève une [PptxException](https://reference.aspose.com/slides/fr/php-java/aspose.slides/pptxexception/).
{{% /alert %}}

## **Enregistrer les présentations au format Office Open XML avec des niveaux de compression**

Pour la sortie PPTX, vous pouvez équilibrer la vitesse d’enregistrement et la taille du fichier en utilisant la méthode [PptxOptions::setCompressionLevel](https://reference.aspose.com/slides/fr/php-java/aspose.slides/pptxoptions/#setCompressionLevel). La classe [CompressionLevel](https://reference.aspose.com/slides/fr/php-java/aspose.slides/compressionlevel/) propose ces valeurs :

- [None] stocke les données sans compression.
- [Level1] offre la compression la plus rapide et la sortie compressée la plus volumineuse.
- [Level2] à [Level5] privilégient progressivement une sortie plus petite au détriment de la vitesse d’enregistrement.
- [Level6] équilibre la vitesse d’enregistrement et la taille du fichier. C’est le niveau par défaut.
- [Level7] et [Level8] favorisent davantage une sortie plus petite au détriment de la vitesse d’enregistrement.
- [Level9] offre la compression la plus forte et nécessite le plus de temps de traitement.

L’exemple suivant enregistre une présentation sans compression :

```php
use aspose\slides\CompressionLevel;
use aspose\slides\PptxOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("Sample.pptx");
try {
    $options = new PptxOptions();
    $options->setCompressionLevel(CompressionLevel::None);

    $presentation->save("OutputNoCompression.pptx", SaveFormat::Pptx, $options);
} finally {
    $presentation->dispose();
}
```

L’exemple suivant utilise le niveau de compression maximal :

```php
use aspose\slides\CompressionLevel;
use aspose\slides\PptxOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("Sample.pptx");
try {
    $options = new PptxOptions();
    $options->setCompressionLevel(CompressionLevel::Level9);

    $presentation->save("OutputMaximumCompression.pptx", SaveFormat::Pptx, $options);
} finally {
    $presentation->dispose();
}
```

## **Enregistrer les présentations sans actualiser la vignette**

Lorsqu’une présentation est enregistrée au format PPTX, la méthode [PptxOptions::setRefreshThumbnail](https://reference.aspose.com/slides/fr/php-java/aspose.slides/pptxoptions/#setRefreshThumbnail) contrôle sa vignette documentaire :

- `true` régénère la vignette pendant l’opération d’enregistrement. C’est la valeur par défaut.
- `false` conserve la vignette existante. Si la présentation n’a pas de vignette, Aspose.Slides n’en génère pas.

L’exemple suivant enregistre une présentation sans actualiser sa vignette :

```php
use aspose\slides\PptxOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("Sample.pptx");
try {
    $options = new PptxOptions();
    $options->setRefreshThumbnail(false);

    $presentation->save("Output.pptx", SaveFormat::Pptx, $options);
} finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Note" %}}
Désactiver l’actualisation de la vignette peut réduire le temps nécessaire pour enregistrer un fichier PPTX.
{{% /alert %}}

## **Enregistrer les mises à jour de progression en pourcentage**

Pour suivre une opération d’enregistrement, fournissez un proxy Java implémentant l’interface [IProgressCallback](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iprogresscallback/) et transmettez le proxy à la méthode [SaveOptions::setProgressCallback](https://reference.aspose.com/slides/fr/php-java/aspose.slides/saveoptions/#setProgressCallback). Aspose.Slides appelle alors la méthode [IProgressCallback::reporting](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iprogresscallback/#reporting-double-) avec les valeurs de progression pendant l’exportation.

L’exemple suivant rapporte la progression d’une exportation PDF dans la console :

```php
use aspose\slides\PdfOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

class ExportProgressHandler {
    function reporting($progressValue) {
        $progress = java("java.lang.Double")->valueOf($progressValue)->intValue();
        echo($progress . "% of the file has been converted." . PHP_EOL);
    }
}

$progressHandler = java_closure(new ExportProgressHandler(), null, java("com.aspose.slides.IProgressCallback"));

$options = new PdfOptions();
$options->setProgressCallback($progressHandler);

$presentation = new Presentation("Sample.pptx");
try {
    $presentation->save("Output.pdf", SaveFormat::Pdf, $options);
} finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Note" %}}
Aspose propose un séparateur PowerPoint gratuit créé avec l’API Aspose.Slides. Il enregistre les diapositives sélectionnées d’une présentation en tant que fichiers PPT ou PPTX distincts.
{{% /alert %}}

## **FAQ**

**Aspose.Slides prend‑t‑il en charge l’enregistrement incrémental ou « fast save » ?**

Non. Chaque opération d’enregistrement écrit un fichier de sortie complet plutôt que de mettre à jour uniquement les parties modifiées.

**Plusieurs threads peuvent‑ils enregistrer la même instance Presentation ?**

Non. Une instance [Presentation](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/) [n’est pas thread‑safe](/slides/fr/php-java/multithreading/). Accédez et enregistrez chaque instance à partir d’un seul thread à la fois.

**Que se passe‑t‑il avec les hyperliens et les fichiers liés externement lorsque j’enregistre une présentation ?**

[Hyperlinks](/slides/fr/php-java/manage-hyperlinks/) restent dans la présentation. Aspose.Slides ne copie pas les fichiers liés externement, de sorte que la présentation enregistrée doit toujours pouvoir accéder à leurs emplacements.

**Puis‑je enregistrer les métadonnées du document telles que l’auteur, le titre, l’entreprise et la date de création ?**

Oui. Définissez les [propriétés du document](/slides/fr/php-java/presentation-properties/) appropriées avant l’enregistrement, et Aspose.Slides les écrit dans le fichier de sortie.
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
- format Strict Office Open XML
- mode Zip64
- rafraîchissement de la vignette
- progression de l'enregistrement
- PHP
- Aspose.Slides
description: "Découvrez comment enregistrer des présentations avec Aspose.Slides pour PHP via Java — exportez vers PowerPoint ou OpenDocument tout en conservant les mises en page, les polices et les effets."
---

## **Vue d'ensemble**

[Ouvrir des présentations en PHP](/slides/fr/php-java/open-presentation/) décrit comment utiliser la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) pour ouvrir une présentation. Cet article explique comment créer et enregistrer des présentations. La classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) contient le contenu d’une présentation. Que vous créiez une présentation à partir de zéro ou que vous modifiiez une présentation existante, vous voudrez l’enregistrer une fois terminé. Avec Aspose.Slides pour PHP, vous pouvez enregistrer dans un **file** ou un **stream**. Cet article explique les différentes manières d’enregistrer une présentation.

## **Enregistrer les présentations dans des fichiers**

Enregistrez une présentation dans un fichier en appelant la méthode `save` de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/). Passez le nom du fichier et le format d’enregistrement à la méthode. L’exemple suivant montre comment enregistrer une présentation avec Aspose.Slides.
```php
// Instancier la classe Presentation qui représente un fichier de présentation.
$presentation = new Presentation();
try {
    // Effectuer du travail ici...

    // Enregistrer la présentation dans un fichier.
    $presentation->save("Output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```


## **Enregistrer les présentations dans des flux**

Vous pouvez enregistrer une présentation dans un flux en transmettant un flux de sortie à la méthode `save` de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/). Une présentation peut être écrite dans de nombreux types de flux. Dans l’exemple ci‑dessous, nous créons une nouvelle présentation et l’enregistrons dans un flux de fichier.
```php
// Instancier la classe Presentation qui représente un fichier de présentation.
$presentation = new Presentation();
try {
    $fileStream = new Java("java.io.FileOutputStream", "Output.pptx");
    try {
        // Enregistrer la présentation dans le flux.
        $presentation->save($fileStream, SaveFormat::Pptx);
    } finally {
        $fileStream->close();
    }
} finally {
    $presentation->dispose();
}
```


## **Enregistrer les présentations avec un type de vue prédéfini**

Aspose.Slides vous permet de définir la vue initiale que PowerPoint utilise lorsque la présentation générée s’ouvre via la classe [ViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/viewproperties/). Utilisez la méthode [setLastView](https://reference.aspose.com/slides/php-java/aspose.slides/viewproperties/#setLastView) avec une valeur de l’énumération [ViewType](https://reference.aspose.com/slides/php-java/aspose.slides/viewtype/).
```php
$presentation = new Presentation();
try {
    $presentation->getViewProperties()->setLastView(ViewType::SlideMasterView);
    $presentation->save("SlideMasterView.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```


## **Enregistrer les présentations au format Strict Office Open XML**

Aspose.Slides vous permet d’enregistrer une présentation au format Strict Office Open XML. Utilisez la classe [PptxOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pptxoptions/) et définissez sa propriété `conformance` lors de l’enregistrement. Si vous définissez [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/php-java/aspose.slides/conformance/#Iso29500_2008_Strict), le fichier de sortie est enregistré au format Strict Office Open XML.

L’exemple ci‑dessous crée une présentation et l’enregistre au format Strict Office Open XML.
```php
$options = new PptxOptions();
$options->setConformance(Conformance::Iso29500_2008_Strict);

// Instancier la classe Presentation qui représente un fichier de présentation.
$presentation = new Presentation();
try {
    // Enregistrer la présentation au format Strict Office Open XML.
    $presentation->save("StrictOfficeOpenXml.pptx", SaveFormat::Pptx, $options);
} finally {
    $presentation->dispose();
}
```


## **Enregistrer les présentations au format Office Open XML en mode Zip64**

Un fichier Office Open XML est une archive ZIP qui impose des limites de 4 Go (2^32 octets) sur la taille non compressée de tout fichier, la taille compressée de tout fichier et la taille totale de l’archive, ainsi qu’une limite de 65 535 (2^16‑1) fichiers. Les extensions de format ZIP64 élèvent ces limites à 2^64.

La méthode [PptxOptions.setZip64Mode](https://reference.aspose.com/slides/php-java/aspose.slides/pptxoptions/#setZip64Mode) vous permet de choisir quand utiliser les extensions de format ZIP64 lors de l’enregistrement d’un fichier Office Open XML.

Cette méthode peut être utilisée avec les modes suivants :

- [IfNecessary](https://reference.aspose.com/slides/php-java/aspose.slides/zip64mode/#IfNecessary) utilise les extensions ZIP64 uniquement si la présentation dépasse les limites ci‑dessus. C’est le mode par défaut.
- [Never](https://reference.aspose.com/slides/php-java/aspose.slides/zip64mode/#Never) n’utilise jamais les extensions ZIP64.
- [Always](https://reference.aspose.com/slides/php-java/aspose.slides/zip64mode/#Always) utilise toujours les extensions ZIP64.

Le code suivant montre comment enregistrer une présentation en PPTX avec les extensions ZIP64 activées :
```php
$pptxOptions = new PptxOptions();
$pptxOptions->setZip64Mode(Zip64Mode::Always);

$presentation = new Presentation("Sample.pptx");
try {
    $presentation->save("OutputZip64.pptx", SaveFormat::Pptx, $pptxOptions);
} finally {
    $presentation->dispose();
}
```


{{% alert title="NOTE" color="warning" %}}
Lorsque vous enregistrez avec [Zip64Mode.Never](https://reference.aspose.com/slides/php-java/aspose.slides/zip64mode/#Never), une [PptxException](https://reference.aspose.com/slides/php-java/aspose.slides/pptxexception/) est levée si la présentation ne peut pas être enregistrée au format ZIP32.
{{% /alert %}}

## **Enregistrer les présentations sans actualiser la vignette**

La méthode [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/php-java/aspose.slides/pptxoptions/#setRefreshThumbnail) contrôle la génération de la vignette lors de l’enregistrement d’une présentation au format PPTX :

- Si elle est définie sur `true`, la vignette est actualisée pendant l’enregistrement. C’est la valeur par défaut.
- Si elle est définie sur `false`, la vignette actuelle est conservée. Si la présentation n’a pas de vignette, aucune n’est générée.

Dans le code ci‑dessous, la présentation est enregistrée au format PPTX sans actualiser sa vignette.
```php
$pptxOptions = new PptxOptions();
$pptxOptions->setRefreshThumbnail(false);

$presentation = new Presentation("Sample.pptx");
try {
    $presentation->save("Output.pptx", SaveFormat::Pptx, $pptxOptions);
}
finally {
    $presentation->dispose();
}
```


{{% alert title="Info" color="info" %}}
Cette option permet de réduire le temps nécessaire à l’enregistrement d’une présentation au format PPTX.
{{% /alert %}}

## **Mettre à jour le progrès d’enregistrement en pourcentage**

Le reporting de progression d’enregistrement est configuré via la méthode [setProgressCallback](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/#setProgressCallback) sur [SaveOptions](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/) et ses sous‑classes. Fournissez un proxy Java qui implémente l’interface [IProgressCallback](https://reference.aspose.com/slides/java/com.aspose.slides/iprogresscallback/) ; pendant l’exportation, le rappel reçoit des mises à jour périodiques en pourcentage.

Les extraits de code suivants montrent comment utiliser `IProgressCallback`.
```php
class ExportProgressHandler {
    function reporting($progressValue) {
        // Utilisez la valeur du pourcentage de progression ici.
        $progress = java("java.lang.Double")->valueOf($progressValue)->intValue();
        echo($progress . "% of the file has been converted.");
    }
}

$progressHandler = java_closure(new ExportProgressHandler(), null, java("com.aspose.slides.IProgressCallback"));

$saveOptions = new PdfOptions();
$saveOptions->setProgressCallback($progressHandler);

$presentation = new Presentation("Sample.pptx");
try {
    $presentation->save("Output.pdf", SaveFormat::Pdf, $saveOptions);
} finally {
    $presentation->dispose();
}
```


{{% alert title="Info" color="info" %}}
Aspose a développé une [application gratuite PowerPoint Splitter](https://products.aspose.app/slides/splitter) utilisant sa propre API. L’application vous permet de diviser une présentation en plusieurs fichiers en enregistrant les diapositives sélectionnées comme nouveaux fichiers PPTX ou PPT.
{{% /alert %}}

## **FAQ**

**« Fast save » (enregistrement incrémentiel) est‑il pris en charge afin que seules les modifications soient écrites ?**

Non. L’enregistrement crée le fichier cible complet à chaque fois ; l’enregistrement incrémentiel « fast save » n’est pas pris en charge.

**L’enregistrement du même objet Presentation depuis plusieurs threads est‑il sûr ?**

Non. Une instance de [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) **n’est pas thread‑safe** ; enregistrez‑la depuis un seul thread.

**Que se passe‑t‑il avec les hyperliens et les fichiers liés externement lors de l’enregistrement ?**

Les [hyperliens](/slides/fr/php-java/manage-hyperlinks/) sont conservés. Les fichiers liés externes (par ex. : vidéos via des chemins relatifs) ne sont pas copiés automatiquement ; assurez‑vous que les chemins référencés restent accessibles.

**Puis‑je définir/enregistrer les métadonnées du document (Auteur, Titre, Société, Date) ?**

Oui. Les [propriétés du document](/slides/fr/php-java/presentation-properties/) standard sont prises en charge et seront écrites dans le fichier lors de l’enregistrement.
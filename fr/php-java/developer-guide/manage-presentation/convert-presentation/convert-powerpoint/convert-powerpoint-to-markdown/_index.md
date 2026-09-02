---
title: Convertir les présentations PowerPoint en Markdown avec PHP
linktitle: PowerPoint en Markdown
type: docs
weight: 140
url: /fr/php-java/convert-powerpoint-to-markdown/
keywords:
- convertir PowerPoint
- convertir présentation
- convertir diapositive
- convertir PPT
- convertir PPTX
- PowerPoint en MD
- présentation en MD
- diapositive en MD
- PPT en MD
- PPTX en MD
- enregistrer PowerPoint au format Markdown
- enregistrer la présentation au format Markdown
- enregistrer la diapositive au format Markdown
- enregistrer PPT en MD
- enregistrer PPTX en MD
- exporter PPT en MD
- exporter PPTX en MD
- exportation d'images Markdown
- liens d'images CDN
- PowerPoint
- présentation
- Markdown
- PHP
- Aspose.Slides
description: "Convertir les présentations PPT et PPTX en Markdown avec PHP et contrôler où les images bitmap, métafichiers et SVG exportées sont enregistrées et référencées."
---
## **Vue d'ensemble**

Aspose.Slides for PHP via Java peut convertir des présentations PPT et PPTX en Markdown pour la documentation, les sites statiques, la migration de contenu et les workflows de contrôle de version. Vous pouvez choisir une variante de Markdown, contrôler la façon dont le contenu des diapositives est rendu, et décider où les images exportées sont stockées et comment le Markdown généré les référence.

Par défaut, l'exportation Markdown utilise une sortie texte uniquement. Pour exporter le contenu visuel, définissez le type d'exportation avec la méthode [MarkdownSaveOptions::setExportType](https://reference.aspose.com/slides/fr/php-java/aspose.slides/markdownsaveoptions/) sur la valeur `Sequential` ou `Visual` de l'énumération [MarkdownExportType](https://reference.aspose.com/slides/fr/php-java/aspose.slides/markdownexporttype/). `Sequential` rend les éléments de diapositive séparément et dans l'ordre, tandis que `Visual` maintient les éléments groupés ensemble afin de préserver leur relation visuelle. La valeur `TextOnly` n’émet pas de ressources image, de sorte que les rappels d’enregistrement d’image ne sont pas appelés dans ce mode.

## **Convertir une présentation en Markdown**

Chargez le fichier source avec la classe [Presentation](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/), puis appelez la méthode [Presentation::save](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/) avec la valeur `Md` de l'énumération [SaveFormat](https://reference.aspose.com/slides/fr/php-java/aspose.slides/saveformat/).

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$inputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.pptx";
$outputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.md";
$presentation = new Presentation($inputPath);
try {
    $presentation->save($outputPath, SaveFormat::Md);
} finally {
    $presentation->dispose();
}
```

## **Sélectionner une variante Markdown**

La méthode [MarkdownSaveOptions::setFlavor](https://reference.aspose.com/slides/fr/php-java/aspose.slides/markdownsaveoptions/) contrôle la spécification Markdown utilisée pour la sortie. L'énumération [Flavor](https://reference.aspose.com/slides/fr/php-java/aspose.slides/flavor/) comprend CommonMark, GitHub Flavored Markdown et d'autres variantes prises en charge.

L'exemple suivant exporte une présentation au format CommonMark :

```php
use aspose\slides\Flavor;
use aspose\slides\MarkdownSaveOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$inputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.pptx";
$outputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.md";
$presentation = new Presentation($inputPath);
try {
    $options = new MarkdownSaveOptions();
    $options->setFlavor(Flavor::CommonMark);

    $presentation->save($outputPath, SaveFormat::Md, $options);
} finally {
    $presentation->dispose();
}
```

## **Exporter les images en utilisant le comportement d'enregistrement local par défaut**

La classe [MarkdownSaveOptions](https://reference.aspose.com/slides/fr/php-java/aspose.slides/markdownsaveoptions/) fournit deux méthodes pour configurer les images enregistrées localement :

- [setBasePath](https://reference.aspose.com/slides/fr/php-java/aspose.slides/markdownsaveoptions/) spécifie le répertoire de base pour le document Markdown et ses ressources.
- [setImagesSaveFolderName](https://reference.aspose.com/slides/fr/php-java/aspose.slides/markdownsaveoptions/) spécifie le sous‑répertoire des images. Sa valeur par défaut est `Images`.

L'exemple suivant rend le contenu visuel, écrit les images dans `output/assets` et crée des références d'images relatives dans le document Markdown :

```php
use aspose\slides\MarkdownExportType;
use aspose\slides\MarkdownSaveOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$inputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.pptx";
$outputDirectory = __DIR__ . DIRECTORY_SEPARATOR . "output";
if (!is_dir($outputDirectory)) {
    mkdir($outputDirectory, 0777, true);
}

$presentation = new Presentation($inputPath);
try {
    $options = new MarkdownSaveOptions();
    $options->setExportType(MarkdownExportType::Visual);
    $options->setBasePath($outputDirectory);
    $options->setImagesSaveFolderName("assets");

    $markdownPath = $outputDirectory . DIRECTORY_SEPARATOR . "presentation.md";
    $presentation->save($markdownPath, SaveFormat::Md, $options);
} finally {
    $presentation->dispose();
}
```

Ce comportement sert également de solution de secours lorsqu'un gestionnaire d'enregistrement d'image personnalisé renvoie `false`.

## **Personnaliser l'enregistrement d'images et les liens Markdown**

Utilisez la méthode [MarkdownSaveOptions::setImageSaving](https://reference.aspose.com/slides/fr/php-java/aspose.slides/markdownsaveoptions/) pour enregistrer un rappel pour les ressources bitmap et métafichiers non‑SVG émises lors de l'exportation Markdown. Son rappel `MarkdownImageSavingHandler` reçoit l'objet [IImage](https://reference.aspose.com/slides/fr/php-java/aspose.slides/iimage/), sa valeur [ImageFormat](https://reference.aspose.com/slides/fr/php-java/aspose.slides/imageformat/) et le lien Markdown généré sous forme de tableau Java à un élément. Enregistrez ou téléversez l'image avec le format fourni, et remplacez `$link[0]` par la référence qui doit apparaître dans la sortie Markdown.

Les ressources émises au format SVG sont traitées séparément. Enregistrez un rappel avec la méthode [MarkdownSaveOptions::setSvgImageSaving](https://reference.aspose.com/slides/fr/php-java/aspose.slides/markdownsaveoptions/). Son rappel `MarkdownSvgImageSavingHandler` reçoit un objet [ISvgImage](https://reference.aspose.com/slides/fr/php-java/aspose.slides/isvgimage/) et le tableau Java à un élément `$link`. Un SVG n’a pas d’argument `ImageFormat `; écrivez ou téléversez ses données XML à partir de la méthode [ISvgImage::getSvgData](https://reference.aspose.com/slides/fr/php-java/aspose.slides/isvgimage/) à la place. Selon le mode d'exportation et le groupement visuel, un SVG dans la présentation source peut être rasterisé ou combiné avec d’autres contenus ; la ressource non‑SVG résultante est alors transmise au rappel d’enregistrement d’image. Enregistrez les deux rappels lorsque chaque ressource visuelle exportée nécessite un traitement personnalisé.

En PHP via Java, implémentez chaque rappel dans une classe PHP et utilisez `java_closure` pour exposer cet objet comme l'interface Java correspondante.

{{% alert color="info" title="Note" %}}
Initialisez le pont PHP/Java avec `JAVA_PREFER_VALUES` activé avant de charger `Java.inc`. La méthode [Presentation::save](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/) renvoie `void`, et le mode de flux par défaut du pont ne peut pas appeler un rappel PHP pendant cet appel mis en file d’attente. L'exemple complet ci‑dessous inclut l'initialisation requise.
{{% /alert %}}

La valeur de retour du gestionnaire détermine qui traite l'image :

- Retournez `true` après que le gestionnaire a enregistré, téléversé, transformé ou autrement traité l'image et attribué une valeur valide à `$link[0]`. Aspose.Slides écrit cette valeur dans le document Markdown et n'effectue pas son enregistrement local par défaut.
- Retournez `false` pour laisser Aspose.Slides enregistrer l'image localement et générer son lien selon les valeurs définies par [MarkdownSaveOptions::setBasePath](https://reference.aspose.com/slides/fr/php-java/aspose.slides/markdownsaveoptions/) et [MarkdownSaveOptions::setImagesSaveFolderName](https://reference.aspose.com/slides/fr/php-java/aspose.slides/markdownsaveoptions/).

{{% alert color="warning" title="Important" %}}
Un gestionnaire qui renvoie `true` prend la responsabilité de l'image. S'il renvoie `true` sans attribuer un lien valide et non vide, l'exportation échoue avec une `InvalidOperationException`.
{{% /alert %}}

### **Enregistrer les images dans un répertoire d'origine CDN et utiliser des URL externes**

L'exemple suivant considère `cdn-origin/presentations/quarterly-report` comme un répertoire d'origine CDN monté ou synchronisé. Chaque gestionnaire extrait le nom de fichier généré, enregistre l'image dans ce répertoire personnalisé et remplace la référence locale générée par une URL CDN publique. L'exemple lui‑même n'effectue aucun téléversement réseau ; l'URL ne devient valide qu'après que le répertoire a été monté comme origine CDN ou que ses fichiers ont été publiés sur le CDN. Pour le stockage d'objets, remplacez l'écriture sur le système de fichiers par l'opération de téléversement du SDK de stockage et attribuez `$link[0]` uniquement après la réussite du téléversement.

```php
use aspose\slides\MarkdownExportType;
use aspose\slides\MarkdownSaveOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

define("JAVA_PREFER_VALUES", 1);
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once("lib/aspose.slides.php");

function getFileNameFromLink($generatedLink)
{
    $urlCompatibleLink = str_replace("\\", "/", java_values($generatedLink));
    return basename($urlCompatibleLink);
}

function buildPublicUrl($publicBaseUrl, $fileName)
{
    return rtrim($publicBaseUrl, "/") . "/" . rawurlencode($fileName);
}

class CustomImageSavingHandler
{
    private $storageDirectory;
    private $publicBaseUrl;

    function __construct($storageDirectory, $publicBaseUrl)
    {
        $this->storageDirectory = $storageDirectory;
        $this->publicBaseUrl = $publicBaseUrl;
    }

    function invoke($image, $format, $link)
    {
        if (java_values($image->getWidth()) < 128 || java_values($image->getHeight()) < 128) {
            return false;
        }

        $fileName = getFileNameFromLink($link[0]);
        $storagePath = $this->storageDirectory . DIRECTORY_SEPARATOR . $fileName;
        $image->save($storagePath, $format);
        $link[0] = buildPublicUrl($this->publicBaseUrl, $fileName);
        return true;
    }
}

class CustomSvgImageSavingHandler
{
    private $storageDirectory;
    private $publicBaseUrl;

    function __construct($storageDirectory, $publicBaseUrl)
    {
        $this->storageDirectory = $storageDirectory;
        $this->publicBaseUrl = $publicBaseUrl;
    }

    function invoke($svgImage, $link)
    {
        $fileName = getFileNameFromLink($link[0]);
        $storagePath = $this->storageDirectory . DIRECTORY_SEPARATOR . $fileName;
        $outputStream = null;
        try {
            $outputStream = new Java("java.io.FileOutputStream", $storagePath);
            $outputStream->write($svgImage->getSvgData());
        } catch (Throwable $exception) {
            fwrite(STDERR, "Could not save the SVG image: " . $exception->getMessage() . PHP_EOL);
            return false;
        } finally {
            if ($outputStream !== null) {
                $outputStream->close();
            }
        }

        $link[0] = buildPublicUrl($this->publicBaseUrl, $fileName);
        return true;
    }
}

$inputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.pptx";
$outputDirectory = __DIR__ . DIRECTORY_SEPARATOR . "output";
$publicBaseUrl = "https://cdn.example.com/presentations/quarterly-report";
$storageDirectory = __DIR__ . DIRECTORY_SEPARATOR . "cdn-origin" . DIRECTORY_SEPARATOR . "presentations" . DIRECTORY_SEPARATOR . "quarterly-report";
if (!is_dir($outputDirectory)) {
    mkdir($outputDirectory, 0777, true);
}
if (!is_dir($storageDirectory)) {
    mkdir($storageDirectory, 0777, true);
}

$presentation = new Presentation($inputPath);
try {
    $options = new MarkdownSaveOptions();
    $options->setExportType(MarkdownExportType::Visual);
    $options->setBasePath($outputDirectory);
    $options->setImagesSaveFolderName("fallback-images");

    $imageSavingHandler = java_closure(new CustomImageSavingHandler($storageDirectory, $publicBaseUrl), null, java('com.aspose.slides.MarkdownSaveOptions$MarkdownImageSavingHandler'));
    $svgImageSavingHandler = java_closure(new CustomSvgImageSavingHandler($storageDirectory, $publicBaseUrl), null, java('com.aspose.slides.MarkdownSaveOptions$MarkdownSvgImageSavingHandler'));
    $options->setImageSaving($imageSavingHandler);
    $options->setSvgImageSaving($svgImageSavingHandler);

    $markdownPath = $outputDirectory . DIRECTORY_SEPARATOR . "presentation.md";
    $presentation->save($markdownPath, SaveFormat::Md, $options);
} finally {
    $presentation->dispose();
}
```

Le gestionnaire bitmap renvoie délibérément `false` pour les images de moins de 128 × 128 pixels, ainsi Aspose.Slides enregistre ces images dans `output/fallback-images` en utilisant le comportement par défaut. Les ressources bitmap et métafichier plus grandes, ainsi que les ressources SVG, sont traitées par le code personnalisé. Par exemple, une référence locale générée telle que `fallback-images/image1.png` devient `https://cdn.example.com/presentations/quarterly-report/image1.png`. Les gestionnaires utilisent les chemins du système d'exploitation uniquement lors de l'écriture des fichiers ; les liens écrits dans le Markdown utilisent des barres obliques (`/`) et des noms de fichiers encodés en URL. Appliquez la même règle lors de la création de liens relatifs : utilisez `/`, pas le séparateur de répertoires propre à la plateforme.

## **FAQ**

**Un seul gestionnaire peut‑il traiter à la fois les images raster et les images SVG ?**

Non. Utilisez [MarkdownSaveOptions::setImageSaving](https://reference.aspose.com/slides/fr/php-java/aspose.slides/markdownsaveoptions/) pour les ressources bitmap et métafichier émises et [MarkdownSaveOptions::setSvgImageSaving](https://reference.aspose.com/slides/fr/php-java/aspose.slides/markdownsaveoptions/) pour les ressources émises au format SVG. Le premier fournit un objet [IImage](https://reference.aspose.com/slides/fr/php-java/aspose.slides/iimage/) et une valeur [ImageFormat](https://reference.aspose.com/slides/fr/php-java/aspose.slides/imageformat/); le second fournit un objet [ISvgImage](https://reference.aspose.com/slides/fr/php-java/aspose.slides/isvgimage/) dont les données SVG peuvent être lues avec [ISvgImage::getSvgData](https://reference.aspose.com/slides/fr/php-java/aspose.slides/isvgimage/). Un SVG source rasterisé pendant l'exportation est traité par le rappel d’enregistrement d’image à la place.

**Que se passe‑t‑il lorsqu'un gestionnaire d'enregistrement d'image renvoie `false` ?**

Aspose.Slides utilise son comportement d'enregistrement local par défaut. L'emplacement de l'image et la référence générée sont contrôlés par les valeurs définies avec [MarkdownSaveOptions::setBasePath](https://reference.aspose.com/slides/fr/php-java/aspose.slides/markdownsaveoptions/) et [MarkdownSaveOptions::setImagesSaveFolderName](https://reference.aspose.com/slides/fr/php-java/aspose.slides/markdownsaveoptions/).

**Un gestionnaire peut‑il fournir une URL sans enregistrer l'image localement ?**

Oui. Le gestionnaire peut téléverser l'image vers un stockage d'objets ou la transmettre à un autre service, attribuer l'URL résultante à `$link[0]` et renvoyer `true`. Le gestionnaire doit effectuer lui‑même le traitement ; retourner `true` empêche l'enregistrement local par défaut.

**Pourquoi l'exportation Markdown lève‑t‑elle une `InvalidOperationException` provenant d'un gestionnaire ?**

Cette exception se produit lorsque le gestionnaire renvoie `true` mais ne fournit pas de lien valide. Attribuez le chemin relatif ou l'URL externe qui doit être écrit dans le Markdown avant de renvoyer `true`.

**Quel séparateur de chemin les liens d'image doivent‑ils utiliser ?**

Utilisez des barres obliques (`/`) dans les liens Markdown et les URL. Utilisez `DIRECTORY_SEPARATOR` uniquement pour les chemins du système de fichiers, puis construisez ou normalisez la référence Markdown séparément.

**Les hyperliens sont‑ils conservés lors de l'exportation Markdown ?**

Oui. Le texte des [hyperliens](/slides/fr/php-java/manage-hyperlinks/) est conservé sous forme de liens Markdown standard. Les [transitions](/slides/fr/php-java/slide-transition/) et les [animations](/slides/fr/php-java/powerpoint-animation/) des diapositives ne sont pas convertis.

**Les présentations peuvent‑elles être converties en Markdown en parallèle ?**

Vous pouvez traiter différents fichiers de présentation en parallèle, mais ne partagez pas la même instance [Presentation](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/) entre les threads. Suivez les [consignes de multithreading](/slides/fr/php-java/multithreading/) et utilisez une instance distincte pour chaque fichier.
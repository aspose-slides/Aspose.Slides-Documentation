---
title: Déterminer le format de présentation d'origine en PHP
linktitle: Format source
type: docs
weight: 35
url: /fr/php-java/detect-presentation-source-format/
keywords:
- format source
- détecter le format de présentation
- PowerPoint
- OpenDocument
- présentation
- PPT
- PPTX
- PHP
- Aspose.Slides
description: "Lisez le format d'origine d'une présentation chargée en PHP avec Aspose.Slides pour PHP via Java, comparez les API de détection et gérez les fichiers, les flux et les formats hérités."
---
## **Vue d'ensemble**

Après avoir chargé une présentation, appelez la méthode [Presentation::getSourceFormat](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/#getSourceFormat) pour déterminer son format d'origine. Utilisez‑la lorsque le traitement ultérieur dépend du format à partir duquel l'instance actuelle a été chargée.

Le format source est distinct du [SaveFormat](https://reference.aspose.com/slides/fr/php-java/aspose.slides/saveformat/) sélectionné pour un fichier de sortie. Enregistrer dans un autre format ne modifie pas le format source de l'instance existante.

## **Lire le format source d'un fichier**

Cet exemple nécessite un fichier `sample.pptx` existant. Il charge le fichier et sélectionne une stratégie de traitement d'application en utilisant [Presentation::getSourceFormat](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/#getSourceFormat), plutôt que le nom de fichier. Modifiez le chemin d'entrée pour tester d'autres formats. L’exemple affiche la stratégie sélectionnée ; remplacez les messages par votre logique d’application.

```php
use aspose\slides\Presentation;
use aspose\slides\SourceFormat;

$presentation = new Presentation("sample.pptx");
try {
    switch (java_values($presentation->getSourceFormat())) {
        case SourceFormat::Ppt:
        case SourceFormat::Pps:
        case SourceFormat::Pot:
            echo "Use the legacy PowerPoint processing policy." . PHP_EOL;
            break;
        case SourceFormat::Pptx:
            echo "Use the standard PPTX processing policy." . PHP_EOL;
            break;
        default:
            echo "Use the general policy for source format " . java_values($presentation->getSourceFormat()) . "." . PHP_EOL;
            break;
    }
} finally {
    $presentation->dispose();
}
```

## **Reconnaître les valeurs prises en charge**

La classe [SourceFormat](https://reference.aspose.com/slides/fr/php-java/aspose.slides/sourceformat/) définit des constantes entières qui distinguent les formats de présentation suivants. Les extensions ci‑dessous sont des extensions conventionnelles, pas une reconstitution du nom de fichier d’origine.

| Valeur SourceFormat | Extension | Format |
| --- | --- | --- |
| `Ppt` | `.ppt` | Présentation PowerPoint 97–2003 |
| `Pptx` | `.pptx` | Présentation Office Open XML |
| `Pptm` | `.pptm` | Présentation Office Open XML avec macros |
| `Pps` | `.pps` | Diaporama PowerPoint 97–2003 |
| `Ppsx` | `.ppsx` | Diaporama Office Open XML |
| `Ppsm` | `.ppsm` | Diaporama Office Open XML avec macros |
| `Pot` | `.pot` | Modèle PowerPoint 97–2003 |
| `Potx` | `.potx` | Modèle Office Open XML |
| `Potm` | `.potm` | Modèle Office Open XML avec macros |
| `Odp` | `.odp` | Présentation OpenDocument |
| `Otp` | `.otp` | Modèle de présentation OpenDocument |
| `Fodp` | `.fodp` | Présentation ODF XML plat |
| `Xml` | `.xml` | Présentation PowerPoint XML |

## **Lire le format source d'un flux**

Cet exemple nécessite un fichier `sample.pps` existant. Lire ses octets dans un flux mémoire simule une entrée reçue sans nom de fichier, comme une valeur de base de données ou un tableau d’octets téléchargé. Le constructeur [Presentation](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/) ne reçoit que le flux.

```php
use aspose\slides\Presentation;

$inputFile = new Java("java.io.File", "sample.pps");
$bytes = java("java.nio.file.Files")->readAllBytes($inputFile->toPath());
$stream = new Java("java.io.ByteArrayInputStream", $bytes);
try {
    $presentation = new Presentation($stream);
    try {
        echo "Source format: " . java_values($presentation->getSourceFormat()) . PHP_EOL;
    } finally {
        $presentation->dispose();
    }
} finally {
    $stream->close();
}
```

PPT, PPS et POT utilisent le même format binaire sous‑jacent. Lors du chargement par chemin de fichier, l’extension peut aider à distinguer un diaporama ou un modèle. Sans nom de fichier, le contenu hérité PPS ou POT peut être signalé comme `SourceFormat::Ppt` ; l’exemple PPS ci‑dessus affiche la valeur entière de `SourceFormat::Ppt`.

Si votre application doit préserver cette distinction, conservez le nom de fichier d’origine ou les métadonnées de sous‑type séparément. Une extension constitue un indice utile pour ces sous‑types hérités, mais ne doit pas être le seul critère d’identification d’un contenu de présentation arbitraire.

## **Comparer la détection avant et après le chargement**

Utilisez [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentationfactory/#getPresentationInfo) et [PresentationInfo::getLoadFormat](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentationinfo/#getLoadFormat) lorsque vous devez inspecter un fichier avant de charger son modèle d’objet complet. Utilisez [Presentation::getSourceFormat](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/#getSourceFormat) lorsque l’instance existe déjà.

Cet exemple nécessite `sample.pptx` et affiche les valeurs entières de `LoadFormat::Pptx` et `SourceFormat::Pptx`, respectivement. En production, choisissez l’API appropriée à votre étape de traitement ; une présentation déjà chargée n’a pas besoin d’une seconde inspection uniquement pour obtenir son format source.

```php
use aspose\slides\Presentation;
use aspose\slides\PresentationFactory;

$path = "sample.pptx";
$information = PresentationFactory::getInstance()->getPresentationInfo($path);
echo "Before loading: " . java_values($information->getLoadFormat()) . PHP_EOL;

$presentation = new Presentation($path);
try {
    echo "After loading: " . java_values($presentation->getSourceFormat()) . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

Les résultats utilisent des constantes de classes différentes : [LoadFormat](https://reference.aspose.com/slides/fr/php-java/aspose.slides/loadformat/) et [SourceFormat](https://reference.aspose.com/slides/fr/php-java/aspose.slides/sourceformat/). Ne comparez pas leurs valeurs numériques et ne supposez pas que chaque format donne les mêmes résultats de détection. Le XML PowerPoint peut être signalé comme `LoadFormat::Unknown` avant le chargement et comme `SourceFormat::Xml` après le chargement.

## **Conserver séparément les formats source et de sortie**

Cet exemple nécessite `sample.pptx` et écrit `converted.odp`. Il affiche la valeur entière de `SourceFormat::Pptx` avant et après l’enregistrement de l’instance d’origine. Seule la nouvelle instance chargée à partir de la sortie ODP signale `Odp`.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    echo "Before saving: " . java_values($presentation->getSourceFormat()) . PHP_EOL;

    $presentation->save("converted.odp", SaveFormat::Odp);
    echo "After saving: " . java_values($presentation->getSourceFormat()) . PHP_EOL;

    $reopened = new Presentation("converted.odp");
    try {
        echo "Reopened output: " . java_values($reopened->getSourceFormat()) . PHP_EOL;
    } finally {
        $reopened->dispose();
    }
} finally {
    $presentation->dispose();
}
```

Une présentation créée à partir de zéro avec `new Presentation()` signale `SourceFormat::Pptx`. Elle n’a pas de fichier d’entrée : il s’agit de la valeur par défaut pour une instance nouvellement créée, et non la preuve qu’un fichier PPTX a été chargé. Suivez séparément si votre application a créé ou chargé l’instance si cette distinction a de l’importance.

## **Mapper un format source à une extension**

L’exemple suivant nécessite `sample.pptx`. Il associe chaque valeur actuellement prise en charge de [SourceFormat](https://reference.aspose.com/slides/fr/php-java/aspose.slides/sourceformat/) à une extension conventionnelle, sans analyser le nom de fichier d’entrée. Le recours à la valeur de secours évite d’attribuer silencieusement une extension à une valeur non reconnue.

```php
use aspose\slides\Presentation;
use aspose\slides\SourceFormat;

$presentation = new Presentation("sample.pptx");
try {
    $extension = null;
    switch (java_values($presentation->getSourceFormat())) {
        case SourceFormat::Ppt:
            $extension = ".ppt";
            break;
        case SourceFormat::Pptx:
            $extension = ".pptx";
            break;
        case SourceFormat::Pptm:
            $extension = ".pptm";
            break;
        case SourceFormat::Pps:
            $extension = ".pps";
            break;
        case SourceFormat::Ppsx:
            $extension = ".ppsx";
            break;
        case SourceFormat::Ppsm:
            $extension = ".ppsm";
            break;
        case SourceFormat::Pot:
            $extension = ".pot";
            break;
        case SourceFormat::Potx:
            $extension = ".potx";
            break;
        case SourceFormat::Potm:
            $extension = ".potm";
            break;
        case SourceFormat::Odp:
            $extension = ".odp";
            break;
        case SourceFormat::Otp:
            $extension = ".otp";
            break;
        case SourceFormat::Fodp:
            $extension = ".fodp";
            break;
        case SourceFormat::Xml:
            $extension = ".xml";
            break;
        default:
            $extension = null;
            break;
    }

    echo ($extension !== null ? $extension : "No extension mapping is available.") . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

Ce mappage ne convertit pas un fichier ni ne récupère un sous‑type hérité PPS/POT perdu lors du chargement d’un flux. Pour la sauvegarde réelle, sélectionnez explicitement un [SaveFormat](https://reference.aspose.com/slides/fr/php-java/aspose.slides/saveformat/) ou utilisez la conversion présentée dans [Save Presentations in Their Original Format](/slides/fr/php-java/save-presentation/#save-presentations-in-their-original-format).

## **Vérifier les formats en enregistrant et en rouvrant**

Cet exemple autonome crée une présentation et écrit trois fichiers dans le répertoire de travail, écrasant les fichiers portant les mêmes noms. Il rouvre chaque sortie à la fois par chemin et via un flux mémoire. Pour PPTX et ODP, les deux voies signalent le format enregistré. Pour PPS, le chargement par chemin signale `Pps`, tandis que le chargement des mêmes octets sans nom de fichier signale `Ppt`.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $formats = [SaveFormat::Pptx, SaveFormat::Odp, SaveFormat::Pps];
    $extensions = ["pptx", "odp", "pps"];

    foreach ($formats as $index => $format) {
        $path = "roundtrip." . $extensions[$index];
        $presentation->save($path, $format);

        $fromFile = new Presentation($path);
        try {
            $inputFile = new Java("java.io.File", $path);
            $bytes = java("java.nio.file.Files")->readAllBytes($inputFile->toPath());
            $stream = new Java("java.io.ByteArrayInputStream", $bytes);
            try {
                $fromStream = new Presentation($stream);
                try {
                    echo $extensions[$index] . ": file=" . java_values($fromFile->getSourceFormat()) . ", stream=" . java_values($fromStream->getSourceFormat()) . PHP_EOL;
                } finally {
                    $fromStream->dispose();
                }
            } finally {
                $stream->close();
            }
        } finally {
            $fromFile->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```

Le tableau suivant résume l’identification du format source pour les présentations dont les extensions correspondent. Les noms désignent des constantes ; les exemples PHP affichent leurs valeurs entières :

| Format enregistré | SourceFormat à partir d’un chemin de fichier | SourceFormat à partir d’un flux sans nom |
| --- | --- | --- |
| PPT | `Ppt` | `Ppt` |
| PPTX, PPTM | `Pptx`, `Pptm` respectivement | Même que le chemin de fichier |
| PPS | `Pps` | `Ppt` |
| PPSX, PPSM | `Ppsx`, `Ppsm` respectivement | Même que le chemin de fichier |
| POT | `Pot` | `Ppt` |
| POTX, POTM | `Potx`, `Potm` respectivement | Même que le chemin de fichier |
| ODP, OTP | `Odp`, `Otp` respectivement | Même que le chemin de fichier |
| FODP | `Fodp` | `Fodp` |
| PowerPoint XML | `Xml` | `Xml` |

Le contenu PPS/POT est identifié comme `Ppt` pour les flux sans nom. Le tableau décrit l’identification du format, pas la préservation de chaque fonctionnalité de présentation lors de la conversion.

## **FAQ**

**Enregistrer au format ODP modifie‑t‑il le format source d’une présentation chargée depuis PPTX ?**

Non. L’instance existante signale toujours `Pptx`. Une instance chargée depuis le fichier ODP enregistré signale `Odp`.

**Un flux peut‑il toujours distinguer une présentation héritée, un diaporama et un modèle ?**

Non. PPT, PPS et POT partagent le même format binaire. Conservez le nom de fichier ou les métadonnées de sous‑type séparément lorsque cette distinction est requise.

**Quelle API devrais‑je utiliser si la présentation est déjà chargée ?**

Lisez [Presentation::getSourceFormat](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/#getSourceFormat). Utilisez [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentationfactory/#getPresentationInfo) pour l’inspection avant le chargement.
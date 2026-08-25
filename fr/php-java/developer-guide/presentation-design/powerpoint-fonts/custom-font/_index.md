---
title: Personnaliser les polices PowerPoint en PHP
linktitle: Police personnalisée
type: docs
weight: 20
url: /fr/php-java/custom-font/
keywords:
- police
- police personnalisée
- police externe
- charger police
- gérer les polices
- dossier de polices
- PowerPoint
- OpenDocument
- présentation
- PHP
- Aspose.Slides
description: "Personnalisez les polices dans les diapositives PowerPoint avec Aspose.Slides pour PHP via Java afin de garder vos présentations nettes et cohérentes sur tout appareil."
---
## **Vue d’ensemble**

Aspose.Slides vous permet d'utiliser des polices personnalisées dans les présentations sans les installer sur le système d'exploitation. Vous pouvez charger des polices depuis des dossiers personnalisés, fournir des polices pour une présentation spécifique via des sources de polices au niveau du document, ou charger des polices externes directement à partir de données binaires.

Les polices chargées sont utilisées lorsqu'une présentation est rendue ou exportée, par exemple vers PDF, des images et d'autres formats pris en charge. Cela permet de conserver une sortie de présentation cohérente entre différents environnements. L'article explique également comment inspecter les dossiers de polices utilisés par Aspose.Slides et comment vider le cache des polices après avoir travaillé avec des polices externes.

L'enregistrement de polices personnalisées pour le rendu est distinct de l'intégration de polices dans un fichier PPTX. Si une police doit être stockée à l'intérieur de la présentation, utilisez explicitement les fonctionnalités d'intégration de polices.

Un thème de présentation peut référencer différentes familles de polices pour des systèmes d'écriture individuels. Ces mappages stockent les noms de polices mais n'installent ni ne chargent les fichiers de polices. Consultez [Script-Specific Theme Fonts](/slides/fr/php-java/script-specific-font-mappings/) pour gérer les mappages, et utilisez les options de chargement ci-dessous pour rendre les polices référencées disponibles pour un rendu cohérent.

{{% alert color="info" title="Note" %}}
Aspose Slides vous permet de charger ces polices en utilisant la méthode [loadExternalFonts](https://reference.aspose.com/slides/fr/php-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) :

* Polices TrueType (.ttf) et TrueType Collection (.ttc). Voir [TrueType](https://en.wikipedia.org/wiki/TrueType).
* Polices OpenType (.otf). Voir [OpenType](https://en.wikipedia.org/wiki/OpenType).
{{% /alert %}}

## **Charger des polices personnalisées**

Aspose.Slides vous permet de charger les polices utilisées dans une présentation sans les installer sur le système. Cela affecte la sortie d'exportation — comme PDF, images et autres formats pris en charge — de sorte que les documents résultants restent cohérents entre les environnements. Les polices sont chargées à partir de répertoires personnalisés.

1. Spécifiez un ou plusieurs dossiers contenant les fichiers de polices.
2. Appelez la méthode statique [FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/fr/php-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) pour charger les polices depuis ces dossiers.
3. Chargez et rendez/exportez la présentation.
4. Appelez [FontsLoader::clearCache](https://reference.aspose.com/slides/fr/php-java/aspose.slides/fontsloader/#clearCache--) pour vider le cache des polices.

```php
// Définir les dossiers contenant des fichiers de polices personnalisées.
$externalFontFolder1 = __DIR__ . "/external-fonts-1";
$externalFontFolder2 = __DIR__ . "/external-fonts-2";
$fontFolders = array($externalFontFolder1, $externalFontFolder2);

// Charger les polices personnalisées depuis les dossiers spécifiés.
FontsLoader::loadExternalFonts($fontFolders);

$presentation = null;
try {
    $presentationPath = __DIR__ . "/sample.pptx";
    $presentation = new Presentation($presentationPath);
    
    // Rendre/exporter la présentation (par ex. en PDF, images ou autres formats) en utilisant les polices chargées.
    $outputPath = __DIR__ . "/output.pdf";
    $presentation->save($outputPath, SaveFormat::Pdf);
} finally {
    if ($presentation != null) $presentation->dispose();

    // Vider le cache des polices après la fin du travail.
    FontsLoader::clearCache();
}
```

{{% alert color="info" title="Note" %}}
[FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/fr/php-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) ajoute des dossiers supplémentaires aux chemins de recherche des polices, mais ne modifie pas l'ordre d'initialisation des polices.  
Les polices sont initialisées dans cet ordre :

1. Le chemin de police par défaut du système d'exploitation.  
2. Les chemins chargés via [FontsLoader](https://reference.aspose.com/slides/fr/php-java/aspose.slides/fontsloader/).
{{%/alert %}}

## **Obtenir les dossiers de polices personnalisées**
Aspose.Slides fournit la méthode [getFontFolders](https://reference.aspose.com/slides/fr/php-java/aspose.slides/fontsloader/#getFontFolders--) qui vous permet de trouver les dossiers de polices. Cette méthode renvoie les dossiers ajoutés via la méthode `LoadExternalFonts` ainsi que les dossiers de polices du système.

Ce code PHP vous montre comment utiliser [getFontFolders](https://reference.aspose.com/slides/fr/php-java/aspose.slides/fontsloader/#getFontFolders--):

```php
# Cette ligne affiche les dossiers où les fichiers de police sont recherchés.
# Ce sont des dossiers ajoutés via la méthode LoadExternalFonts et les dossiers de polices du système.
$fontFolders = FontsLoader::getFontFolders();
```

## **Spécifier les polices personnalisées utilisées avec une présentation**
Aspose.Slides fournit la méthode [LoadOptions.setDocumentLevelFontSources](https://reference.aspose.com/slides/fr/java/com.aspose.slides/loadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) qui vous permet de spécifier les polices externes qui seront utilisées avec la présentation.

Ce code PHP vous montre comment utiliser [LoadOptions.setDocumentLevelFontSources](https://reference.aspose.com/slides/fr/java/com.aspose.slides/loadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-):

```php
$javaArray = new JavaClass("java.lang.reflect.Array");
$javaByteType = (new JavaClass("java.lang.Byte"))->TYPE;

$customFontsDirectory = __DIR__ . "/customfonts/";
$customFont1Path = $customFontsDirectory . "CustomFont1.ttf";
$customFontFile1 = new Java("java.io.File", $customFont1Path);
$customFontFile1Length = $customFontFile1->length();
$memoryFont1 = $javaArray->newInstance($javaByteType, $customFontFile1Length);
$dataInputStream1 = null;
try {
    $fileInputStream1 = new Java("java.io.FileInputStream", $customFontFile1);
    $dataInputStream1 = new Java("java.io.DataInputStream", $fileInputStream1);
    $dataInputStream1->readFully($memoryFont1);
} finally {
    if (!java_is_null($dataInputStream1)) $dataInputStream1->close();
}

$customFont2Path = $customFontsDirectory . "CustomFont2.ttf";
$customFontFile2 = new Java("java.io.File", $customFont2Path);
$customFontFile2Length = $customFontFile2->length();
$memoryFont2 = $javaArray->newInstance($javaByteType, $customFontFile2Length);
$dataInputStream2 = null;
try {
    $fileInputStream2 = new Java("java.io.FileInputStream", $customFontFile2);
    $dataInputStream2 = new Java("java.io.DataInputStream", $fileInputStream2);
    $dataInputStream2->readFully($memoryFont2);
} finally {
    if (!java_is_null($dataInputStream2)) $dataInputStream2->close();
}

$loadOptions = new LoadOptions();
$assetFontsFolder = __DIR__ . "/assets/fonts";
$globalFontsFolder = __DIR__ . "/global/fonts";
$loadOptions->getDocumentLevelFontSources()->setFontFolders(array($assetFontsFolder, $globalFontsFolder));
$loadOptions->getDocumentLevelFontSources()->setMemoryFonts(array($memoryFont1, $memoryFont2 ));

$presentationPath = __DIR__ . "/MyPresentation.pptx";
$presentation = new Presentation($presentationPath, $loadOptions);
try {
    # Travailler avec la présentation
    # CustomFont1, CustomFont2, ainsi que les polices des dossiers assets\fonts & global\fonts et leurs sous‑dossiers sont disponibles pour la présentation
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **Gérer les polices de manière externe**

Aspose.Slides fournit la méthode [loadExternalFont](https://reference.aspose.com/slides/fr/php-java/aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) qui vous permet de charger des polices externes à partir de données binaires.

Ce code PHP montre le processus de chargement d'une police à partir d'un tableau d'octets :

```php
$javaArray = new JavaClass("java.lang.reflect.Array");
$javaByteType = (new JavaClass("java.lang.Byte"))->TYPE;
$fontDirectory = __DIR__ . "/";

$dataInputStream = null;
try {
    $fontPath = $fontDirectory . "ARIALN.TTF";
    $fileInputStream = new Java("java.io.FileInputStream", $fontPath);
    $dataInputStream = new Java("java.io.DataInputStream", $fileInputStream);
    $fontBytes = $javaArray->newInstance($javaByteType, $dataInputStream->available());
    $dataInputStream->readFully($fontBytes);
} finally {
    if (!java_is_null($dataInputStream)) $dataInputStream->close();
}
FontsLoader::loadExternalFont($fontBytes);

$dataInputStream = null;
try {
    $fontPath = $fontDirectory . "ARIALNBI.TTF";
    $fileInputStream = new Java("java.io.FileInputStream", $fontPath);
    $dataInputStream = new Java("java.io.DataInputStream", $fileInputStream);
    $fontBytes = $javaArray->newInstance($javaByteType, $dataInputStream->available());
    $dataInputStream->readFully($fontBytes);
} finally {
    if (!java_is_null($dataInputStream)) $dataInputStream->close();
}
FontsLoader::loadExternalFont($fontBytes);

$dataInputStream = null;
try {
    $fontPath = $fontDirectory . "ARIALNI.TTF";
    $fileInputStream = new Java("java.io.FileInputStream", $fontPath);
    $dataInputStream = new Java("java.io.DataInputStream", $fileInputStream);
    $fontBytes = $javaArray->newInstance($javaByteType, $dataInputStream->available());
    $dataInputStream->readFully($fontBytes);
} finally {
    if (!java_is_null($dataInputStream)) $dataInputStream->close();
}
FontsLoader::loadExternalFont($fontBytes);

try {
    $presentation = new Presentation();
    try {
        # police externe chargée pendant la durée de vie de la présentation
    } finally {
        if (!java_is_null($presentation)) {
            $presentation->dispose();
        }
    }
} finally {
    FontsLoader->clearCache();
}
```

## **FAQ**

### Les polices personnalisées affectent-elles l'exportation vers tous les formats (PDF, PNG, SVG, HTML) ?

Oui. Les polices connectées sont utilisées par le moteur de rendu pour tous les formats d'exportation.

### Les polices personnalisées sont-elles automatiquement intégrées dans le PPTX résultant ?

Non. Enregistrer une police pour le rendu n'est pas équivalent à l'intégrer dans un PPTX. Si vous avez besoin que la police soit contenue dans le fichier de présentation, vous devez utiliser les [fonctionnalités d'intégration](/slides/fr/php-java/embedded-font/).

### Puis-je contrôler le comportement de substitution lorsqu'une police personnalisée manque certains glyphes ?

Oui. Configurez la [substitution de polices](/slides/fr/php-java/font-substitution/), les [règles de remplacement](/slides/fr/php-java/font-replacement/) et les [ensembles de secours](/slides/fr/php-java/fallback-font/) pour définir exactement quelle police est utilisée lorsqu'un glyphe demandé est absent.

### Puis-je utiliser des polices dans des conteneurs Linux/Docker sans les installer système‑wide ?

Oui. Pointez vers vos propres dossiers de polices ou chargez des polices à partir de tableaux d'octets. Cela élimine toute dépendance aux répertoires de polices du système dans l'image du conteneur.

### Qu'en est-il de la licence —puis-je intégrer n'importe quelle police personnalisée sans restrictions ?

Vous êtes responsable du respect des licences des polices. Les conditions varient ; certaines licences interdisent l'intégration ou l'utilisation commerciale. Examinez toujours le contrat de licence (EULA) de la police avant de distribuer les résultats.
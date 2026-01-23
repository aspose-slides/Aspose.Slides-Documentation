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
description: "Personnalisez les polices dans les diapositives PowerPoint avec Aspose.Slides pour PHP via Java afin de garder vos présentations nettes et cohérentes sur tous les appareils."
---

{{% alert color="primary" %}} 

Aspose Slides vous permet de charger ces polices en utilisant la méthode [loadExternalFonts](https://reference.aspose.com/slides/php-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) :

* Polices TrueType (.ttf) et collections TrueType (.ttc). Voir [TrueType](https://en.wikipedia.org/wiki/TrueType).

* Polices OpenType (.otf). Voir [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Charger des polices personnalisées**

Aspose.Slides vous permet de charger les polices utilisées dans une présentation sans les installer sur le système. Cela influence la sortie d’exportation – comme PDF, images et autres formats pris en charge – de sorte que les documents résultants soient cohérents quel que soit l’environnement. Les polices sont chargées à partir de répertoires personnalisés.

1. Spécifiez un ou plusieurs dossiers contenant les fichiers de polices.  
2. Appelez la méthode statique [FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/php-java/aspose.slides/fontsloader/loadexternalfonts/) pour charger les polices depuis ces dossiers.  
3. Chargez et rendez/exportez la présentation.  
4. Appelez [FontsLoader::clearCache](https://reference.aspose.com/slides/php-java/aspose.slides/fontsloader/clearcache/) pour vider le cache des polices.

L’exemple de code suivant montre le processus de chargement des polices :
```php
// Définir les dossiers contenant des fichiers de polices personnalisées.
$fontFolders = array($externalFontFolder1, $externalFontFolder2);

// Charger les polices personnalisées à partir des dossiers spécifiés.
FontsLoader::loadExternalFonts($fontFolders);

$presentation = null;
try {
    $presentation = new Presentation("sample.pptx");
    
    // Rendu/exportation de la présentation (p. ex. en PDF, images ou autres formats) en utilisant les polices chargées.
    $presentation->save("output.pdf", SaveFormat::Pdf);
} finally {
    if ($presentation != null) $presentation->dispose();

    // Vider le cache des polices après la fin du travail.
    FontsLoader::clearCache();
}
```


{{% alert color="info" title="Note" %}}

[FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/php-java/aspose.slides/fontsloader/loadexternalfonts/) ajoute des dossiers supplémentaires aux chemins de recherche des polices, mais ne modifie pas l’ordre d’initialisation des polices.  
Les polices sont initialisées dans cet ordre :

1. Le chemin de polices par défaut du système d’exploitation.  
2. Les chemins chargés via [FontsLoader](https://reference.aspose.com/slides/php-java/aspose.slides/fontsloader/).

{{%/alert %}}

## **Obtenir les dossiers de polices personnalisées**
Aspose.Slides fournit la méthode [getFontFolders](https://reference.aspose.com/slides/php-java/aspose.slides/fontsloader/#getFontFolders--) qui vous permet de retrouver les dossiers de polices. Cette méthode renvoie les dossiers ajoutés via la méthode `LoadExternalFonts` ainsi que les dossiers de polices du système.

Ce code PHP montre comment utiliser [getFontFolders](https://reference.aspose.com/slides/php-java/aspose.slides/fontsloader/#getFontFolders--) :
```php
  # Cette ligne affiche les dossiers où les fichiers de police sont recherchés.
  # Ce sont des dossiers ajoutés via la méthode LoadExternalFonts et les dossiers de polices du système.
  $fontFolders = FontsLoader->getFontFolders();

```


## **Spécifier les polices personnalisées utilisées avec une présentation**
Aspose.Slides fournit la méthode [setDocumentLevelFontSources](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/#setDocumentLevelFontSources) qui vous permet de spécifier les polices externes à utiliser avec la présentation.

Ce code PHP montre comment utiliser la méthode [setDocumentLevelFontSources](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/#setDocumentLevelFontSources) :
```php
  $Array = new JavaClass("java.lang.reflect.Array");
  $Byte = new JavaClass("java.lang.Byte");
  $file1 = new Java("java.io.File", "customfonts/CustomFont1.ttf");
  $memoryFont1 = $Array->newInstance($Byte, $Array->getLength($file1));
  try {
      $dis1 = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", $file1));
      $dis1->readFully($memoryFont1);
  } finally {
      if (!java_is_null($dis1)) $dis1->close();
  }
  $file2 = new Java("java.io.File", "customfonts/CustomFont2.ttf");
  $memoryFont2 = $Array->newInstance($Byte, $Array->getLength($file2));
  try {
        $dis2 = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", $file2));
        $dis2->readFully($memoryFont2);
  } finally {
        if (!java_is_null($dis2)) $dis2->close();
  }
  $loadOptions = new LoadOptions();
  $loadOptions->getDocumentLevelFontSources()->setFontFolders(array("assets/fonts", "global/fonts" ));
  $loadOptions->getDocumentLevelFontSources()->setMemoryFonts(array($memoryFont1, $memoryFont2 ));
  $pres = new Presentation("MyPresentation.pptx", $loadOptions);
  try {
    # Travailler avec la présentation
    # CustomFont1, CustomFont2, et les polices des dossiers assets\fonts & global\fonts ainsi que leurs sous-dossiers sont disponibles pour la présentation
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Gérer les polices externement**

Aspose.Slides fournit la méthode [loadExternalFont](https://reference.aspose.com/slides/php-java/aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) qui vous permet de charger des polices externes à partir de données binaires.

Ce code PHP démontre le processus de chargement d’une police à partir d’un tableau d’octets :
```php
$Array = new JavaClass("java.lang.reflect.Array");
$Byte = (new JavaClass("java.lang.Byte"))->TYPE;
try {
    $dis = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", "ARIALN.TTF"));
    $bytes = $Array->newInstance($Byte, $dis->available());
    $dis->readFully($bytes);
} finally {
    if (!java_is_null($dis)) $dis->close();
}
  FontsLoader->loadExternalFont($bytes);

try {
    $dis = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", "ARIALNBI.TTF"));
    $bytes = $Array->newInstance($Byte, $dis->available());
    $dis->readFully($bytes);
} finally {
    if (!java_is_null($dis)) $dis->close();
}
  FontsLoader->loadExternalFont($bytes);

try {
    $dis = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", "ARIALNI.TTF"));
    $bytes = $Array->newInstance($Byte, $dis->available());
    $dis->readFully($bytes);
} finally {
    if (!java_is_null($dis)) $dis->close();
}
  FontsLoader->loadExternalFont($bytes);

  try {
    $pres = new Presentation("");
    try {
      # police externe chargée pendant la durée de vie de la présentation
    } finally {
    }
  } finally {
    FontsLoader->clearCache();
  }
```


## **FAQ**

**Les polices personnalisées affectent-elles l’exportation vers tous les formats (PDF, PNG, SVG, HTML) ?**

Oui. Les polices connectées sont utilisées par le moteur de rendu pour tous les formats d’exportation.

**Les polices personnalisées sont-elles automatiquement incorporées dans le PPTX résultant ?**

Non. Enregistrer une police pour le rendu n’est pas équivalent à l’incorporer dans un PPTX. Si vous devez inclure la police dans le fichier de présentation, utilisez les fonctionnalités explicites d’[intégration](/slides/fr/php-java/embedded-font/).

**Puis‑je contrôler le comportement de substitution lorsqu’une police personnalisée ne possède pas certains glyphes ?**

Oui. Configurez la [substitution de police](/slides/fr/php-java/font-substitution/), les [règles de remplacement](/slides/fr/php-java/font-replacement/) et les [ensembles de secours](/slides/fr/php-java/fallback-font/) pour définir exactement quelle police sera utilisée lorsqu’un glyphe demandé est absent.

**Puis‑je utiliser des polices sous Linux/Docker sans les installer globalement ?**

Oui. Pointez vers vos propres dossiers de polices ou chargez les polices à partir de tableaux d’octets. Cela supprime toute dépendance aux répertoires de polices du système dans l’image du conteneur.

**Qu’en est‑il de la licence — puis‑je incorporer n’importe quelle police personnalisée sans restriction ?**

Vous êtes responsable de la conformité aux licences des polices. Les conditions varient ; certaines licences interdisent l’intégration ou l’utilisation commerciale. Consultez toujours le contrat de licence (EULA) de la police avant de diffuser les résultats.
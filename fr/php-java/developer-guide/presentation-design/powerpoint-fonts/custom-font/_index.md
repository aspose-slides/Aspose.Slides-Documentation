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
description: "Personnalisez les polices dans les diapositives PowerPoint avec Aspose.Slides pour PHP via Java afin de garder vos présentations nettes et cohérentes sur n'importe quel appareil."
---

{{% alert color="primary" %}} 

Aspose Slides vous permet de charger ces polices à l'aide de la méthode [loadExternalFonts](https://reference.aspose.com/slides/php-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) :

* Polices TrueType (.ttf) et TrueType Collection (.ttc). Voir [TrueType](https://en.wikipedia.org/wiki/TrueType).

* Polices OpenType (.otf). Voir [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Charger des polices personnalisées**

Aspose.Slides vous permet de charger des polices qui sont rendues dans les présentations sans avoir à les installer. Les polices sont chargées depuis un répertoire personnalisé. 

1. Créez une instance de la classe [FontsLoader](https://reference.aspose.com/slides/php-java/aspose.slides/fontsloader/) et appelez la méthode [loadExternalFonts](https://reference.aspose.com/slides/php-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---).
2. Chargez la présentation qui sera rendue.
3. [Clear the cache](https://reference.aspose.com/slides/php-java/aspose.slides/FontsLoader#clearCache--) dans la classe [FontsLoader](https://reference.aspose.com/slides/php-java/aspose.slides/FontsLoader).

Ce code PHP montre le processus de chargement des polices :
```php
  # Dossiers où chercher les polices
  $folders = array($externalFontsDir );
  # Charge les polices du répertoire de polices personnalisées
  FontsLoader->loadExternalFonts($folders);
  # Effectuer certaines opérations et rendre la présentation/les diapositives
  $pres = new Presentation("DefaultFonts.pptx");
  try {
    $pres->save("NewFonts_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
    # Efface le cache des polices
    FontsLoader->clearCache();
  }
```


## **Obtenir les dossiers de polices personnalisées**
Aspose.Slides fournit la méthode [getFontFolders](https://reference.aspose.com/slides/php-java/aspose.slides/fontsloader/#getFontFolders--) pour vous permettre de trouver les dossiers de polices. Cette méthode renvoie les dossiers ajoutés via la méthode `LoadExternalFonts` ainsi que les dossiers de polices système.

Ce code PHP montre comment utiliser [getFontFolders](https://reference.aspose.com/slides/php-java/aspose.slides/fontsloader/#getFontFolders--) :
```php
  # Cette ligne affiche les dossiers où les fichiers de polices sont recherchés.
  # Ce sont les dossiers ajoutés via la méthode LoadExternalFonts et les dossiers de polices système.
  $fontFolders = FontsLoader->getFontFolders();
```


## **Spécifier les polices personnalisées utilisées avec une présentation**
Aspose.Slides fournit la propriété [setDocumentLevelFontSources](https://reference.aspose.com/slides/php-java/aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) pour vous permettre de spécifier les polices externes qui seront utilisées avec la présentation.

Ce code PHP montre comment utiliser la propriété [setDocumentLevelFontSources](https://reference.aspose.com/slides/php-java/aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) :
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
    # CustomFont1, CustomFont2 et les polices provenant des dossiers assets\fonts & global\fonts ainsi que leurs sous‑dossiers sont disponibles pour la présentation
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Gérer les polices de manière externe**

Aspose.Slides fournit la méthode [loadExternalFont](https://reference.aspose.com/slides/php-java/aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) pour vous permettre de charger des polices externes à partir de données binaires.

Ce code PHP montre le processus de chargement d’une police à partir d’un tableau d’octets :
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

**Les polices personnalisées affectent-elles l'exportation vers tous les formats (PDF, PNG, SVG, HTML) ?**

Oui. Les polices connectées sont utilisées par le moteur de rendu pour tous les formats d'exportation.

**Les polices personnalisées sont-elles automatiquement intégrées dans le PPTX résultant ?**

Non. Enregistrer une police pour le rendu n'est pas équivalent à l'intégrer dans un PPTX. Si vous avez besoin que la police soit incluse dans le fichier de présentation, vous devez utiliser les fonctionnalités d'intégration explicites.

**Puis‑je contrôler le comportement de secours lorsqu'une police personnalisée ne possède pas certains glyphes ?**

Oui. Configurez la substitution de polices, les règles de remplacement et les jeux de secours pour définir exactement quelle police sera utilisée lorsqu'un glyphe demandé est absent.

**Puis‑je utiliser des polices dans des conteneurs Linux/Docker sans les installer globalement ?**

Oui. Pointez vers vos propres dossiers de polices ou chargez des polices à partir de tableaux d'octets. Cela supprime toute dépendance aux répertoires de polices système dans l'image du conteneur.

**Qu'en est‑il de la licence — puis‑je intégrer n'importe quelle police personnalisée sans restrictions ?**

Vous êtes responsable de la conformité aux licences des polices. Les conditions varient ; certaines licences interdisent l'intégration ou l'utilisation commerciale. Vérifiez toujours le CLUF de la police avant de distribuer les résultats.

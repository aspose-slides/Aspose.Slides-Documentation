---
title: Police Personnalisée PowerPoint
linktitle: Police Personnalisée
type: docs
weight: 20
url: /fr/php-java/custom-font/
keywords: "Polices, polices personnalisées, présentation PowerPoint, Java, Aspose.Slides pour PHP via Java"
description: "Polices personnalisées PowerPoint"
---

{{% alert color="primary" %}} 

Aspose Slides vous permet de charger ces polices en utilisant la méthode [loadExternalFonts](https://reference.aspose.com/slides/php-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) :

* Polices TrueType (.ttf) et TrueType Collection (.ttc). Voir [TrueType](https://fr.wikipedia.org/wiki/TrueType).

* Polices OpenType (.otf). Voir [OpenType](https://fr.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Charger des Polices Personnalisées**

Aspose.Slides vous permet de charger des polices qui sont rendues dans des présentations sans avoir besoin d'installer ces polices. Les polices sont chargées à partir d'un répertoire personnalisé. 

1. Créez une instance de la classe [FontsLoader](https://reference.aspose.com/slides/php-java/aspose.slides/fontsloader/) et appelez la méthode [loadExternalFonts](https://reference.aspose.com/slides/php-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---).
2. Chargez la présentation qui sera rendue.
3. [Effacez le cache](https://reference.aspose.com/slides/php-java/aspose.slides/FontsLoader#clearCache--) dans la classe [FontsLoader](https://reference.aspose.com/slides/php-java/aspose.slides/FontsLoader).

Ce code PHP démontre le processus de chargement des polices :

```php
  # Dossiers pour rechercher les polices
  $folders = array($externalFontsDir );
  # Charge les polices du répertoire de polices personnalisé
  FontsLoader->loadExternalFonts($folders);
  # Fait un travail et effectue le rendu de la présentation/des diapositives
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

## **Obtenez le Dossier de Polices Personnalisées**
Aspose.Slides fournit la méthode [getFontFolders](https://reference.aspose.com/slides/php-java/aspose.slides/fontsloader/#getFontFolders--) pour vous permettre de trouver des dossiers de polices. Cette méthode retourne les dossiers ajoutés via la méthode `LoadExternalFonts` et les dossiers de polices du système.

Ce code PHP vous montre comment utiliser [getFontFolders](https://reference.aspose.com/slides/php-java/aspose.slides/fontsloader/#getFontFolders--):

```php
  # Cette ligne affiche les dossiers où les fichiers de police sont recherchés.
  # Ce sont les dossiers ajoutés via la méthode LoadExternalFonts et les dossiers de polices système.
  $fontFolders = FontsLoader->getFontFolders();

```

## **Spécifiez les Polices Personnalisées Utilisées avec la Présentation**
Aspose.Slides fournit la propriété [setDocumentLevelFontSources](https://reference.aspose.com/slides/php-java/aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) pour vous permettre de spécifier des polices externes qui seront utilisées avec la présentation.

Ce code PHP vous montre comment utiliser la propriété [setDocumentLevelFontSources](https://reference.aspose.com/slides/php-java/aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) :

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
    # Travaillez avec la présentation
    # CustomFont1, CustomFont2, et les polices des dossiers assets\fonts & global\fonts et leurs sous-dossiers sont disponibles pour la présentation
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Gérer les Polices Externément**

Aspose.Slides fournit la méthode [loadExternalFont](https://reference.aspose.com/slides/php-java/aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) pour vous permettre de charger des polices externes à partir de données binaires.

Ce code PHP démontre le processus de chargement de polices à partir d'un tableau d'octets :

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
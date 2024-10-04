---
title: Fuente Personalizada de PowerPoint
linktitle: Fuente Personalizada
type: docs
weight: 20
url: /php-java/custom-font/
keywords: "Fuentes, fuentes personalizadas, presentación de PowerPoint, Java, Aspose.Slides para PHP vía Java"
description: "Fuentes personalizadas de PowerPoint"
---

{{% alert color="primary" %}} 

Aspose Slides permite cargar estas fuentes utilizando el método [loadExternalFonts](https://reference.aspose.com/slides/php-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---):

* Fuentes TrueType (.ttf) y TrueType Collection (.ttc). Ver [TrueType](https://en.wikipedia.org/wiki/TrueType).

* Fuentes OpenType (.otf). Ver [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Cargar Fuentes Personalizadas**

Aspose.Slides permite cargar fuentes que se representan en presentaciones sin necesidad de instalar esas fuentes. Las fuentes se cargan desde un directorio personalizado. 

1. Crea una instancia de la clase [FontsLoader](https://reference.aspose.com/slides/php-java/aspose.slides/fontsloader/) y llama al método [loadExternalFonts](https://reference.aspose.com/slides/php-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---).
2. Carga la presentación que se va a renderizar.
3. [Limpia la caché](https://reference.aspose.com/slides/php-java/aspose.slides/FontsLoader#clearCache--) en la clase [FontsLoader](https://reference.aspose.com/slides/php-java/aspose.slides/FontsLoader).

Este código PHP demuestra el proceso de carga de fuentes:

```php
  # Carpetas para buscar fuentes
  $folders = array($externalFontsDir );
  # Carga las fuentes del directorio de fuentes personalizadas
  FontsLoader->loadExternalFonts($folders);
  # Realiza algún trabajo y realiza la renderización de la presentación/diapositiva
  $pres = new Presentation("DefaultFonts.pptx");
  try {
    $pres->save("NewFonts_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
    # Limpia la caché de fuentes
    FontsLoader->clearCache();
  }
```

## **Obtener la Carpeta de Fuentes Personalizadas**
Aspose.Slides proporciona el método [getFontFolders](https://reference.aspose.com/slides/php-java/aspose.slides/fontsloader/#getFontFolders--) que te permite encontrar carpetas de fuentes. Este método devuelve carpetas añadidas a través del método `LoadExternalFonts` y carpetas de fuentes del sistema.

Este código PHP te muestra cómo usar [getFontFolders](https://reference.aspose.com/slides/php-java/aspose.slides/fontsloader/#getFontFolders--):

```php
  # Esta línea muestra las carpetas donde se buscan los archivos de fuente.
  # Esas son carpetas añadidas a través del método LoadExternalFonts y carpetas de fuentes del sistema.
  $fontFolders = FontsLoader->getFontFolders();

```

## **Especificar Fuentes Personalizadas Usadas Con la Presentación**
Aspose.Slides proporciona la propiedad [setDocumentLevelFontSources](https://reference.aspose.com/slides/php-java/aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) que te permite especificar fuentes externas que se usarán con la presentación.

Este código PHP te muestra cómo usar la propiedad [setDocumentLevelFontSources](https://reference.aspose.com/slides/php-java/aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-):

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
    # Trabaja con la presentación
    # CustomFont1, CustomFont2, y fuentes de las carpetas assets\fonts y global\fonts y sus subcarpetas están disponibles para la presentación
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Gestionar Fuentes Externamente**

Aspose.Slides proporciona el método [loadExternalFont](https://reference.aspose.com/slides/php-java/aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) que te permite cargar fuentes externas desde datos binarios.

Este código PHP demuestra el proceso de carga de fuentes con un array de bytes:

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
      # fuente externa cargada durante la vida de la presentación
    } finally {
    }
  } finally {
    FontsLoader->clearCache();
  }
```
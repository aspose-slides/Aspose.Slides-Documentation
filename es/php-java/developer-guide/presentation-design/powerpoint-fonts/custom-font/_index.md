---
title: Personalizar fuentes de PowerPoint en PHP
linktitle: Fuente personalizada
type: docs
weight: 20
url: /es/php-java/custom-font/
keywords:
- fuente
- fuente personalizada
- fuente externa
- cargar fuente
- gestionar fuentes
- carpeta de fuentes
- PowerPoint
- OpenDocument
- presentación
- PHP
- Aspose.Slides
description: "Personaliza las fuentes en diapositivas de PowerPoint con Aspose.Slides para PHP mediante Java para que tus presentaciones se vean nítidas y coherentes en cualquier dispositivo."
---

{{% alert color="primary" %}} 

Aspose Slides le permite cargar estas fuentes mediante el método [loadExternalFonts](https://reference.aspose.com/slides/php-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---):

* Fuentes TrueType (.ttf) y TrueType Collection (.ttc). Véase [TrueType](https://en.wikipedia.org/wiki/TrueType).

* Fuentes OpenType (.otf). Véase [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Cargar fuentes personalizadas**

Aspose.Slides le permite cargar fuentes que se renderizan en presentaciones sin necesidad de instalarlas. Las fuentes se cargan desde un directorio personalizado. 

1. Crear una instancia de la clase [FontsLoader](https://reference.aspose.com/slides/php-java/aspose.slides/fontsloader/) y llamar al método [loadExternalFonts](https://reference.aspose.com/slides/php-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---).
2. Cargar la presentación que se va a renderizar.
3. [Borrar la caché](https://reference.aspose.com/slides/php-java/aspose.slides/FontsLoader#clearCache--) en la clase [FontsLoader](https://reference.aspose.com/slides/php-java/aspose.slides/FontsLoader).

Este código PHP muestra el proceso de carga de fuentes:
```php
  # Carpetas donde buscar fuentes
  $folders = array($externalFontsDir );
  # Carga las fuentes del directorio de fuentes personalizado
  FontsLoader->loadExternalFonts($folders);
  # Realiza trabajo y renderiza la presentación/diapositiva
  $pres = new Presentation("DefaultFonts.pptx");
  try {
    $pres->save("NewFonts_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
    # Borra la caché de fuentes
    FontsLoader->clearCache();
  }
```


## **Obtener carpetas de fuentes personalizadas**

Aspose.Slides proporciona el método [getFontFolders](https://reference.aspose.com/slides/php-java/aspose.slides/fontsloader/#getFontFolders--) para permitirle encontrar carpetas de fuentes. Este método devuelve las carpetas añadidas mediante el método `LoadExternalFonts` y las carpetas de fuentes del sistema.

Este código PHP muestra cómo usar [getFontFolders](https://reference.aspose.com/slides/php-java/aspose.slides/fontsloader/#getFontFolders--):
```php
  # Esta línea muestra las carpetas donde se buscan los archivos de fuentes.
  # Estas son carpetas añadidas mediante el método LoadExternalFonts y carpetas de fuentes del sistema.
  $fontFolders = FontsLoader->getFontFolders();

```


## **Especificar fuentes personalizadas usadas con una presentación**

Aspose.Slides proporciona la propiedad [setDocumentLevelFontSources](https://reference.aspose.com/slides/php-java/aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) para permitirle especificar fuentes externas que se usarán con la presentación.

Este código PHP muestra cómo usar la propiedad [setDocumentLevelFontSources](https://reference.aspose.com/slides/php-java/aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-):
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
    # Trabajar con la presentación
    # CustomFont1, CustomFont2 y fuentes de las carpetas assets\fonts & global\fonts y sus subcarpetas están disponibles para la presentación
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Gestionar fuentes externamente**

Aspose.Slides proporciona el método [loadExternalFont](https://reference.aspose.com/slides/php-java/aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) para permitirle cargar fuentes externas a partir de datos binarios.

Este código PHP muestra el proceso de carga de fuentes desde un array de bytes:
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
      # fuente externa cargada durante la duración de la presentación
    } finally {
    }
  } finally {
    FontsLoader->clearCache();
  }
```


## **Preguntas frecuentes**

**¿Afectan las fuentes personalizadas a la exportación a todos los formatos (PDF, PNG, SVG, HTML)?**

Sí. Las fuentes conectadas son utilizadas por el motor de renderizado en todos los formatos de exportación.

**¿Se incrustan automáticamente las fuentes personalizadas en el PPTX resultante?**

No. Registrar una fuente para renderizar no es lo mismo que incrustarla en un PPTX. Si necesita que la fuente esté incluida dentro del archivo de presentación, debe utilizar las [funciones de incrustación](/slides/es/php-java/embedded-font/).

**¿Puedo controlar el comportamiento de reserva cuando una fuente personalizada carece de ciertos glifos?**

Sí. Configure la [sustitución de fuentes](/slides/es/php-java/font-substitution/), las [reglas de reemplazo](/slides/es/php-java/font-replacement/) y los [conjuntos de reserva](/slides/es/php-java/fallback-font/) para definir exactamente qué fuente se utiliza cuando el glifo solicitado falta.

**¿Puedo usar fuentes en contenedores Linux/Docker sin instalarlas a nivel del sistema?**

Sí. Apunte a sus propias carpetas de fuentes o cargue fuentes desde arrays de bytes. Esto elimina cualquier dependencia de los directorios de fuentes del sistema en la imagen del contenedor.

**¿Qué pasa con la licencia—puedo incrustar cualquier fuente personalizada sin restricciones?**

Usted es responsable del cumplimiento de la licencia de la fuente. Los términos varían; algunas licencias prohiben la incrustación o el uso comercial. Siempre revise el EULA de la fuente antes de distribuir los resultados.
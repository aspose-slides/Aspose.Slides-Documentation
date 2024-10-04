---
title: Fuente Embebida - API de Java para PowerPoint
linktitle: Fuente Embebida
type: docs
weight: 40
url: /php-java/embedded-font/
keywords: "Fuentes, fuentes embebidas, agregar fuentes, presentación de PowerPoint, Java, Aspose.Slides para PHP a través de Java"
description: "Usa fuentes embebidas en la presentación de PowerPoint"

---

**Las fuentes embebidas en PowerPoint** son útiles cuando deseas que tu presentación aparezca correctamente al abrirse en cualquier sistema o dispositivo. Si utilizaste una fuente de terceros o no estándar porque fuiste creativo con tu trabajo, entonces tienes aún más razones para embebar tu fuente. De lo contrario (sin fuentes embebidas), los textos o números en tus diapositivas, el diseño, el estilo, etc. pueden cambiar o convertirse en rectángulos confusos.

La clase [FontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/FontsManager), la clase [FontData](https://reference.aspose.com/slides/php-java/aspose.slides/fontdata/), la clase [Compress](https://reference.aspose.com/slides/php-java/aspose.slides/compress/) y sus interfaces contienen la mayoría de las propiedades y métodos que necesitas para trabajar con fuentes embebidas en presentaciones de PowerPoint.

## **Obtener o Eliminar Fuentes Embebidas de la Presentación**

Aspose.Slides proporciona el método [getEmbeddedFonts](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/#getEmbeddedFonts--) (expuesto por la clase [FontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/FontsManager)) para permitirte obtener (o averiguar) las fuentes embebidas en una presentación. Para eliminar fuentes, se utiliza el método [removeEmbeddedFont](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/#removeEmbeddedFont-com.aspose.slides.IFontData-) (expuesto por la misma clase).

Este código PHP te muestra cómo obtener y eliminar fuentes embebidas de una presentación:

```php
  # Instancia un objeto Presentation que representa un archivo de presentación
  $pres = new Presentation("EmbeddedFonts.pptx");
  try {
    # Renderiza una diapositiva que contiene un marco de texto que usa "FunSized" embebido
    $slideImage = $pres->getSlides()->get_Item(0)->getImage(new Java("java.awt.Dimension", 960, 720));
    # Guarda la imagen en el disco en formato JPEG
    try {
      $slideImage->save("picture1_out.jpg", ImageFormat::Jpeg);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
    $fontsManager = $pres->getFontsManager();
    # Obtiene todas las fuentes embebidas
    $embeddedFonts = $fontsManager->getEmbeddedFonts();
    # Encuentra la fuente "Calibri"
    $calibriEmbeddedFont = null;
    $Array = new java_class("java.lang.reflect.Array");
    for($i = 0; $i < java_values($Array->getLength($embeddedFonts)) ; $i++) {
      echo("" . $embeddedFonts[$i]->getFontName());
      if ("Calibri"->equals($embeddedFonts[$i]->getFontName())) {
        $calibriEmbeddedFont = $embeddedFonts[$i];
        break;
      }
    }
    # Elimina la fuente "Calibri"
    $fontsManager->removeEmbeddedFont($calibriEmbeddedFont);
    # Renderiza la presentación; la fuente "Calibri" es reemplazada por una existente
    $slideImage = $pres->getSlides()->get_Item(0)->getImage(new Java("java.awt.Dimension", 960, 720));
    # Guarda la imagen en el disco en formato JPEG
    try {
      $slideImage->save("picture2_out.jpg", ImageFormat::Jpeg);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
    # Guarda la presentación sin la fuente "Calibri" embebida en el disco
    $pres->save("WithoutManageEmbeddedFonts_out.ppt", SaveFormat::Ppt);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Agregar Fuentes Embebidas a la Presentación**

Usando el enum [EmbedFontCharacters](https://reference.aspose.com/slides/php-java/aspose.slides/embedfontcharacters/) y dos sobrecargas del método [addEmbeddedFont](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/#addEmbeddedFont-com.aspose.slides.IFontData-int-), puedes seleccionar tu regla preferida (de embebido) para embebir las fuentes en una presentación. Este código PHP te muestra cómo embebir y agregar fuentes a una presentación:

```php
  # Carga la presentación
  $pres = new Presentation("Fonts.pptx");
  try {
    $allFonts = $pres->getFontsManager()->getFonts();
    $embeddedFonts = $pres->getFontsManager()->getEmbeddedFonts();
    $Array = new java_class("java.lang.reflect.Array");
    foreach($allFonts as $font) {
      $embeddedFontsContainsFont = false;
      for($i = 0; $i < java_values($Array->getLength($embeddedFonts)) ; $i++) {
        if ($embeddedFonts[$i]->equals($font)) {
          $embeddedFontsContainsFont = true;
          break;
        }
      }
      if (!$embeddedFontsContainsFont) {
        $pres->getFontsManager()->addEmbeddedFont($font, EmbedFontCharacters->All);
        $embeddedFonts = $pres->getFontsManager()->getEmbeddedFonts();
      }
    }
    # Guarda la presentación en el disco
    $pres->save("AddEmbeddedFont_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Comprimir Fuentes Embebidas**

Para permitirte comprimir las fuentes embebidas en una presentación y reducir su tamaño de archivo, Aspose.Slides proporciona el método [compressEmbeddedFonts](https://reference.aspose.com/slides/php-java/aspose.slides/compress/#compressEmbeddedFonts-com.aspose.slides.Presentation-) (expuesto por la clase [Compress](https://reference.aspose.com/slides/php-java/aspose.slides/compress/)).

Este código PHP te muestra cómo comprimir fuentes de PowerPoint embebidas:

```php
  $pres = new Presentation("pres.pptx");
  try {
    Compress->compressEmbeddedFonts($pres);
    $pres->save("pres-out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
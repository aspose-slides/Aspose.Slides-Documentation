---
title: Incorporar fuentes en presentaciones usando PHP
linktitle: Incrustación de fuente
type: docs
weight: 40
url: /es/php-java/embedded-font/
keywords:
- añadir fuente
- incrustar fuente
- incrustación de fuente
- obtener fuente incrustada
- añadir fuente incrustada
- eliminar fuente incrustada
- comprimir fuente incrustada
- PowerPoint
- OpenDocument
- presentación
- PHP
- Aspose.Slides
description: "Incruste fuentes TrueType en presentaciones PowerPoint y OpenDocument con Aspose.Slides para PHP a través de Java, garantizando una renderización precisa en todas las plataformas."
---

**Fuentes incrustadas en PowerPoint** son útiles cuando quieres que tu presentación se vea correctamente al abrirse en cualquier sistema o dispositivo. Si utilizaste una fuente de terceros o no estándar porque fuiste creativo con tu trabajo, entonces tienes aún más razones para incrustar tu fuente. De lo contrario (sin fuentes incrustadas), los textos o números en tus diapositivas, el diseño, el estilo, etc., pueden cambiar o convertirse en rectángulos confusos. 

La clase [FontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/FontsManager), la clase [FontData](https://reference.aspose.com/slides/php-java/aspose.slides/fontdata/), la clase [Compress](https://reference.aspose.com/slides/php-java/aspose.slides/compress/) y sus interfaces contienen la mayor parte de las propiedades y métodos que necesitas para trabajar con fuentes incrustadas en presentaciones de PowerPoint.

## **Obtener y eliminar fuentes incrustadas**

Aspose.Slides ofrece el método [getEmbeddedFonts](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/#getEmbeddedFonts--) (expuesto por la clase [FontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/FontsManager)) para permitirte obtener (o averiguar) las fuentes incrustadas en una presentación. Para eliminar fuentes, se usa el método [removeEmbeddedFont](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/#removeEmbeddedFont-com.aspose.slides.IFontData-) (expuesto por la misma clase).

Este código PHP muestra cómo obtener y eliminar fuentes incrustadas de una presentación:
```php
  # Instancia un objeto Presentation que representa un archivo de presentación
  $pres = new Presentation("EmbeddedFonts.pptx");
  try {
    # Renderiza una diapositiva que contiene un marco de texto que usa la fuente incrustada "FunSized"
    $slideImage = $pres->getSlides()->get_Item(0)->getImage(new Java("java.awt.Dimension", 960, 720));
    # Guarda la imagen en disco en formato JPEG
    try {
      $slideImage->save("picture1_out.jpg", ImageFormat::Jpeg);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
    $fontsManager = $pres->getFontsManager();
    # Obtiene todas las fuentes incrustadas
    $embeddedFonts = $fontsManager->getEmbeddedFonts();
    # Busca la fuente "Calibri"
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
    # Renderiza la presentación; la fuente "Calibri" se sustituye por una existente
    $slideImage = $pres->getSlides()->get_Item(0)->getImage(new Java("java.awt.Dimension", 960, 720));
    # Guarda la imagen en disco en formato JPEG
    try {
      $slideImage->save("picture2_out.jpg", ImageFormat::Jpeg);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
    # Guarda la presentación sin la fuente "Calibri" incrustada en disco
    $pres->save("WithoutManageEmbeddedFonts_out.ppt", SaveFormat::Ppt);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Agregar fuentes incrustadas**

Usando el enumerado [EmbedFontCharacters](https://reference.aspose.com/slides/php-java/aspose.slides/embedfontcharacters/) y dos sobrecargas del método [addEmbeddedFont](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/#addEmbeddedFont-com.aspose.slides.IFontData-int-) puedes seleccionar la regla (de incrustación) que prefieras para incrustar las fuentes en una presentación. Este código PHP muestra cómo incrustar y añadir fuentes a una presentación:
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
    # Guarda la presentación en disco
    $pres->save("AddEmbeddedFont_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Comprimir fuentes incrustadas**

Para permitirte comprimir las fuentes incrustadas en una presentación y reducir su tamaño de archivo, Aspose.Slides ofrece el método [compressEmbeddedFonts](https://reference.aspose.com/slides/php-java/aspose.slides/compress/#compressEmbeddedFonts-com.aspose.slides.Presentation-) (expuesto por la clase [Compress](https://reference.aspose.com/slides/php-java/aspose.slides/compress/)).

Este código PHP muestra cómo comprimir fuentes incrustadas de PowerPoint:
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


## **Preguntas frecuentes**

**¿Cómo puedo saber si una fuente específica en la presentación seguirá siendo sustituida durante la renderización a pesar de estar incrustada?**

Revisa la [información de sustitución](/slides/es/php-java/font-substitution/) en el gestor de fuentes y las [reglas de sustitución/reemplazo](/slides/es/php-java/fallback-font/): si la fuente no está disponible o está restringida, se utilizará una fuente de reemplazo.

**¿Vale la pena incrustar fuentes del "sistema" como Arial/Calibri?**

Normalmente no, ya que casi siempre están disponibles. Pero para una portabilidad total en entornos "delgados" (Docker, un servidor Linux sin fuentes preinstaladas), incrustar fuentes del sistema puede eliminar el riesgo de sustituciones inesperadas.
---
title: Especificar fuentes predeterminadas de la presentación en PHP
linktitle: Fuente predeterminada
type: docs
weight: 30
url: /es/php-java/default-font/
keywords:
- fuente predeterminada
- fuente regular
- fuente normal
- fuente asiática
- exportación PDF
- exportación XPS
- exportación de imágenes
- PowerPoint
- OpenDocument
- presentación
- PHP
- Aspose.Slides
description: "Establecer fuentes predeterminadas en Aspose.Slides para PHP mediante Java para garantizar una conversión adecuada de PowerPoint (PPT, PPTX) y OpenDocument (ODP) a PDF, XPS e imágenes."
---

## **Usar fuentes predeterminadas para renderizar una presentación**
Aspose.Slides le permite establecer la fuente predeterminada para renderizar la presentación a PDF, XPS o miniaturas. Este artículo muestra cómo definir DefaultRegularFont y DefaultAsianFont para usarlas como fuentes predeterminadas. Siga los pasos a continuación para cargar fuentes desde directorios externos mediante Aspose.Slides para PHP a través de la API Java:

1. Crear una instancia de [LoadOptions](https://reference.aspose.com/slides/php-java/aspose.slides/LoadOptions).
1. [Set the DefaultRegularFont](https://reference.aspose.com/slides/php-java/aspose.slides/LoadOptions#setDefaultRegularFont-java.lang.String-) a la fuente deseada. En el siguiente ejemplo, he usado Wingdings.
1. [Set the DefaultAsianFont](https://reference.aspose.com/slides/php-java/aspose.slides/LoadOptions#setDefaultAsianFont-java.lang.String-) a la fuente deseada. He usado Wingdings en el ejemplo siguiente.
1. Cargar la presentación usando Presentation y configurando las opciones de carga.
1. Ahora, generar la miniatura de la diapositiva, PDF y XPS para verificar los resultados.

La implementación anterior se muestra a continuación.
```php
  # Utilice opciones de carga para definir las fuentes predeterminadas regular y asiáticas
  $loadOptions = new LoadOptions(LoadFormat::Auto);
  $loadOptions->setDefaultRegularFont("Wingdings");
  $loadOptions->setDefaultAsianFont("Wingdings");
  # Cargar la presentación
  $pres = new Presentation("DefaultFonts.pptx", $loadOptions);
  try {
    # Generar miniatura de diapositiva
    $slideImage = $pres->getSlides()->get_Item(0)->getImage(1, 1);
    try {
      # guardar la imagen en el disco.
      $slideImage->save("output.png", ImageFormat::Png);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
    # Generar PDF
    $pres->save("output_out.pdf", SaveFormat::Pdf);
    # Generar XPS
    $pres->save("output_out.xps", SaveFormat::Xps);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**¿Qué afecta exactamente DefaultRegularFont y DefaultAsianFont—solo la exportación o también miniaturas, PDF, XPS, HTML y SVG?**

Participan en la canalización de renderizado para todas las salidas admitidas. Esto incluye miniaturas de diapositivas, [PDF](/slides/es/php-java/convert-powerpoint-to-pdf/), [XPS](/slides/es/php-java/convert-powerpoint-to-xps/), [imágenes raster](/slides/es/php-java/convert-powerpoint-to-png/), [HTML](/slides/es/php-java/convert-powerpoint-to-html/), y [SVG](/slides/es/php-java/render-a-slide-as-an-svg-image/), porque Aspose.Slides utiliza la misma lógica de disposición y resolución de glifos en estos destinos.

**¿Se aplican las fuentes predeterminadas al leer y guardar un PPTX sin realizar ningún renderizado?**

No. Las fuentes predeterminadas solo importan cuando el texto debe medirse y dibujarse. Un simple abrir‑guardar de una presentación no cambia los fragmentos de fuente almacenados ni la estructura del archivo. Las fuentes predeterminadas entran en juego durante operaciones que renderizan o reorganizan el texto.

**Si añado mis propias carpetas de fuentes o suministro fuentes desde memoria, ¿se tendrán en cuenta al elegir las fuentes predeterminadas?**

Sí. Las [fuentes personalizadas](/slides/es/php-java/custom-font/) amplían el catálogo de familias y glifos disponibles que el motor puede usar. Las fuentes predeterminadas y cualquier [regla de reserva](/slides/es/php-java/fallback-font/) se resolverán contra esas fuentes primero, proporcionando una cobertura más fiable en servidores y contenedores.

**¿Afectarán las fuentes predeterminadas a las métricas del texto (kerning, avances) y, por tanto, a los saltos de línea y al ajuste?**

Sí. Cambiar la fuente modifica las métricas de los glifos y puede alterar los saltos de línea, el ajuste y la paginación durante el renderizado. Para mantener la estabilidad del diseño, [incorpore las fuentes originales](/slides/es/php-java/embedded-font/) o seleccione familias predeterminadas y de reserva compatibles métricamente.

**¿Tiene sentido establecer fuentes predeterminadas si todas las fuentes usadas en la presentación están incrustadas?**

A menudo no es necesario, porque las [fuentes incrustadas](/slides/es/php-java/embedded-font/) ya garantizan una apariencia coherente. Las fuentes predeterminadas siguen siendo útiles como respaldo para caracteres no cubiertos por el subconjunto incrustado o cuando un archivo combina texto incrustado y no incrustado.
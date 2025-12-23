---
title: Crear presentaciones en PHP
linktitle: Crear presentación
type: docs
weight: 10
url: /es/php-java/create-presentation/
keywords:
- crear presentación
- nueva presentación
- crear PPT
- nuevo PPT
- crear PPTX
- nuevo PPTX
- crear ODP
- nuevo ODP
- PowerPoint
- OpenDocument
- presentación
- PHP
- Aspose.Slides
description: "Crea presentaciones con Aspose.Slides para PHP a través de Java — produce archivos PPT, PPTX y ODP y guárdalos programáticamente para obtener resultados fiables."
---

## **Crear una presentación**

Para agregar una línea simple y sencilla a una diapositiva seleccionada de la presentación, siga los pasos a continuación:

1. Crea una instancia de la clase Presentation.
1. Obtenga la referencia de una diapositiva mediante su índice.
1. Agregue un AutoShape de tipo Línea usando el método addAutoShape expuesto por el objeto Shapes.
1. Guarde la presentación modificada como un archivo PPTX.

En el ejemplo que se muestra a continuación, hemos agregado una línea a la primera diapositiva de la presentación.
```php
  # Instanciar un objeto Presentation que representa un archivo de presentación
  $pres = new Presentation();
  try {
    # Obtener la primera diapositiva
    $slide = $pres->getSlides()->get_Item(0);
    # Agregar un autoshape de tipo línea
    $slide->getShapes()->addAutoShape(ShapeType::Line, 50, 150, 300, 0);
    $pres->save("NewPresentation_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Preguntas frecuentes**

**¿En qué formatos puedo guardar una nueva presentación?**

Puede guardar en [PPTX, PPT y ODP](/slides/es/php-java/save-presentation/), y exportar a [PDF](/slides/es/php-java/convert-powerpoint-to-pdf/), [XPS](/slides/es/php-java/convert-powerpoint-to-xps/), [HTML](/slides/es/php-java/convert-powerpoint-to-html/), [SVG](/slides/es/php-java/convert-powerpoint-to-png/), y [imágenes](/slides/es/php-java/convert-powerpoint-to-png/), entre otros.

**¿Puedo iniciar a partir de una plantilla (POTX/POTM) y guardar como un PPTX normal?**

Sí. Cargue la plantilla y guarde en el formato deseado; los formatos POTX/POTM/PPTM y similares [son compatibles](/slides/es/php-java/supported-file-formats/).

**¿Cómo controlo el tamaño o la relación de aspecto de la diapositiva al crear una presentación?**

Configure el [tamaño de diapositiva](/slides/es/php-java/slide-size/) (incluyendo preajustes como 4:3 y 16:9 o dimensiones personalizadas) y elija cómo debe escalar el contenido.

**¿En qué unidades se miden los tamaños y las coordenadas?**

En puntos: 1 pulgada equivale a 72 unidades.

**¿Cómo manejo presentaciones muy grandes (con muchos archivos multimedia) para reducir el uso de memoria?**

Utilice [estrategias de gestión de BLOB](/slides/es/php-java/manage-blob/), limite el almacenamiento en memoria aprovechando archivos temporales y prefiera flujos de trabajo basados en archivos en lugar de transmisiones puramente en memoria.

**¿Puedo crear/guardar presentaciones en paralelo?**

No puede operar sobre la misma instancia de [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) desde [múltiples hilos](/slides/es/php-java/multithreading/). Ejecute instancias separadas e aisladas por hilo o proceso.

**¿Cómo elimino la marca de agua de prueba y las limitaciones?**

[Aplique una licencia](/slides/es/php-java/licensing/) una vez por proceso. El XML de licencia debe permanecer sin modificar, y la configuración de la licencia debe sincronizarse si participan varios hilos.

**¿Puedo firmar digitalmente el PPTX que creo?**

Sí. Las [firmas digitales](/slides/es/php-java/digital-signature-in-powerpoint/) (añadir y verificar) son compatibles con las presentaciones.

**¿Se admiten macros (VBA) en presentaciones creadas?**

Sí. Puede [crear/editar proyectos VBA](/slides/es/php-java/presentation-via-vba/) y guardar archivos con macros como PPTM/PPSM.
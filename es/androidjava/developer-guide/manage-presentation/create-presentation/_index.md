---
title: Crear presentaciones en Android
linktitle: Crear presentación
type: docs
weight: 10
url: /es/androidjava/create-presentation/
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
- Android
- Java
- Aspose.Slides
description: "Cree presentaciones en Java con Aspose.Slides para Android: produzca archivos PPT, PPTX y ODP, benefíciese del soporte OpenDocument y guárdelos programáticamente para obtener resultados fiables."
---

## **Crear una presentación de PowerPoint**
Para agregar una línea simple a una diapositiva seleccionada de la presentación, siga los pasos a continuación:

1. Crear una instancia de la clase Presentation.
1. Obtener la referencia de una diapositiva usando su Index.
1. Agregar una AutoShape de tipo Línea usando el método addAutoShape expuesto por el objeto Shapes.
1. Guardar la presentación modificada como un archivo PPTX.

En el ejemplo a continuación, hemos agregado una línea a la primera diapositiva de la presentación.
```java
// Instanciar un objeto Presentation que representa un archivo de presentación
Presentation pres = new Presentation();
try {
    // Obtener la primera diapositiva
    ISlide slide = pres.getSlides().get_Item(0);

    // Añadir una autoshape de tipo línea
    slide.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);
    pres.save("NewPresentation_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**¿En qué formatos puedo guardar una nueva presentación?**

Puede guardar en [PPTX, PPT, and ODP](/slides/es/androidjava/save-presentation/), y exportar a [PDF](/slides/es/androidjava/convert-powerpoint-to-pdf/), [XPS](/slides/es/androidjava/convert-powerpoint-to-xps/), [HTML](/slides/es/androidjava/convert-powerpoint-to-html/), [SVG](/slides/es/androidjava/convert-powerpoint-to-png/), y [images](/slides/es/androidjava/convert-powerpoint-to-png/), entre otros.

**¿Puedo comenzar a partir de una plantilla (POTX/POTM) y guardar como un PPTX normal?**

Sí. Cargue la plantilla y guarde en el formato deseado; los formatos POTX/POTM/PPTM y similares [are supported](/slides/es/androidjava/supported-file-formats/).

**¿Cómo puedo controlar el tamaño/rela­ción de aspecto de la diapositiva al crear una presentación?**

Establezca el [slide size](/slides/es/androidjava/slide-size/) (incluidos los preajustes como 4:3 y 16:9 o dimensiones personalizadas) y elija cómo debe escalarse el contenido.

**¿En qué unidades se miden los tamaños y coordenadas?**

En puntos: 1 pulgada equivale a 72 unidades.

**¿Cómo manejo presentaciones muy grandes (con muchos archivos multimedia) para reducir el uso de memoria?**

Utilice [BLOB management strategies](/slides/es/androidjava/manage-blob/), limite el almacenamiento en memoria aprovechando archivos temporales y prefiera flujos basados en archivos en lugar de flujos puramente en memoria.

**¿Puedo crear/guardar presentaciones en paralelo?**

No puede operar sobre la misma [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) instancia desde [multiple threads](/slides/es/androidjava/multithreading/). Ejecute instancias separadas e aisladas por hilo o proceso.

**¿Cómo elimino la marca de agua de prueba y las limitaciones?**

[Apply a license](/slides/es/androidjava/licensing/) una vez por proceso. El XML de la licencia debe permanecer sin modificar, y la configuración de la licencia debe sincronizarse si varios hilos están involucrados.

**¿Puedo firmar digitalmente el PPTX que creo?**

Sí. Las [Digital signatures](/slides/es/androidjava/digital-signature-in-powerpoint/) (agregar y verificar) son compatibles con las presentaciones.

**¿Se admiten macros (VBA) en presentaciones creadas?**

Sí. Puede [create/edit VBA projects](/slides/es/androidjava/presentation-via-vba/) y guardar archivos con macros habilitadas como PPTM/PPSM.
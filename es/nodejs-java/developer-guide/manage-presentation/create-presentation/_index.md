---
title: Crear presentación de PowerPoint en JavaScript
linktitle: Crear presentación
type: docs
weight: 10
url: /es/nodejs-java/create-presentation/
keywords: crear ppt java, crear presentación ppt, crear pptx java
description: Aprenda a crear presentaciones de PowerPoint, p. ej., PPT, PPTX usando JavaScript desde cero.
---

## **Crear presentación de PowerPoint**

Para agregar una línea simple y sencilla a una diapositiva seleccionada de la presentación, siga los pasos a continuación:

1. Cree una instancia de la clase Presentation.
1. Obtenga la referencia de una diapositiva usando su índice.
1. Agregue un AutoShape de tipo Línea usando el método addAutoShape expuesto por el objeto Shapes.
1. Guarde la presentación modificada como un archivo PPTX.

En el ejemplo a continuación, hemos agregado una línea a la primera diapositiva de la presentación.
```javascript
// Instanciar un objeto Presentation que representa un archivo de presentación
var pres = new aspose.slides.Presentation();
try {
    // Obtener la primera diapositiva
    var slide = pres.getSlides().get_Item(0);
    // Agregar una autoshape de tipo línea
    slide.getShapes().addAutoShape(aspose.slides.ShapeType.Line, 50, 150, 300, 0);
    pres.save("NewPresentation_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Preguntas frecuentes**

**¿En qué formatos puedo guardar una nueva presentación?**

Puede guardar en [PPTX, PPT y ODP](/slides/es/nodejs-java/save-presentation/), y exportar a [PDF](/slides/es/nodejs-java/convert-powerpoint-to-pdf/), [XPS](/slides/es/nodejs-java/convert-powerpoint-to-xps/), [HTML](/slides/es/nodejs-java/convert-powerpoint-to-html/), [SVG](/slides/es/nodejs-java/convert-powerpoint-to-png/), y [imágenes](/slides/es/nodejs-java/convert-powerpoint-to-png/), entre otros.

**¿Puedo iniciar desde una plantilla (POTX/POTM) y guardarla como un PPTX normal?**

Sí. Cargue la plantilla y guárdela en el formato deseado; los formatos POTX/POTM/PPTM y similares [son compatibles](/slides/es/nodejs-java/supported-file-formats/).

**¿Cómo controlo el tamaño/relación de aspecto de la diapositiva al crear una presentación?**

Establezca el [tamaño de diapositiva](/slides/es/nodejs-java/slide-size/) (incluyendo ajustes predefinidos como 4:3 y 16:9 o dimensiones personalizadas) y elija cómo debe escalar el contenido.

**¿En qué unidades se miden los tamaños y coordenadas?**

En puntos: 1 pulgada equivale a 72 unidades.

**¿Cómo manejo presentaciones muy grandes (con muchos archivos multimedia) para reducir el uso de memoria?**

Utilice [estrategias de gestión de BLOB](/slides/es/nodejs-java/manage-blob/), limite el almacenamiento en memoria mediante archivos temporales y prefiera flujos de trabajo basados en archivos en lugar de flujos puramente en memoria.

**¿Puedo crear/guardar presentaciones en paralelo?**

No se puede operar sobre la misma instancia de [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) desde [múltiples hilos](/slides/es/nodejs-java/multithreading/). Ejecute instancias separadas y aisladas por hilo o proceso.

**¿Cómo elimino la marca de agua de prueba y las limitaciones?**

[Aplique una licencia](/slides/es/nodejs-java/licensing/) una vez por proceso. El XML de la licencia debe permanecer sin modificar, y la configuración de la licencia debe sincronizarse si participan varios hilos.

**¿Puedo firmar digitalmente el PPTX que creo?**

Sí. Las [firmas digitales](/slides/es/nodejs-java/digital-signature-in-powerpoint/) (agregar y verificar) son compatibles con las presentaciones.

**¿Se admiten macros (VBA) en las presentaciones creadas?**

Sí. Puede [crear/editar proyectos VBA](/slides/es/nodejs-java/presentation-via-vba/) y guardar archivos con macros habilitadas como PPTM/PPSM.
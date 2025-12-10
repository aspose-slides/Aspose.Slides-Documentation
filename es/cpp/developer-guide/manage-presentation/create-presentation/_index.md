---
title: Crear presentaciones en C++
linktitle: Crear presentación
type: docs
weight: 10
url: /es/cpp/create-presentation/
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
- C++
- Aspose.Slides
description: "Crea presentaciones en C++ con Aspose.Slides—produce archivos PPT, PPTX y ODP, aprovecha el soporte OpenDocument y guárdalos programáticamente para obtener resultados fiables."
---

## **Crear una presentación de PowerPoint**
Para agregar una línea simple y plana a una diapositiva seleccionada de la presentación, siga los pasos a continuación:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
1. Obtenga la referencia de una diapositiva mediante su índice.
1. Agregue un AutoShape de tipo Línea usando el método AddAutoShape expuesto por el objeto Shapes.
1. Guarde la presentación modificada como un archivo PPTX.

En el ejemplo que se muestra a continuación, hemos añadido una línea a la primera diapositiva de la presentación.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CreateNewPresentation-CreateNewPresentation.cpp" >}}

## **Preguntas frecuentes**

**¿En qué formatos puedo guardar una nueva presentación?**

Puede guardar en [PPTX, PPT y ODP](/slides/es/cpp/save-presentation/), y exportar a [PDF](/slides/es/cpp/convert-powerpoint-to-pdf/), [XPS](/slides/es/cpp/convert-powerpoint-to-xps/), [HTML](/slides/es/cpp/convert-powerpoint-to-html/), [SVG](/slides/es/cpp/convert-powerpoint-to-png/), y [imágenes](/slides/es/cpp/convert-powerpoint-to-png/), entre otros.

**¿Puedo comenzar desde una plantilla (POTX/POTM) y guardarla como un PPTX normal?**

Sí. Cargue la plantilla y guárdela en el formato deseado; los formatos POTX/POTM/PPTM y similares [son compatibles](/slides/es/cpp/supported-file-formats/).

**¿Cómo controlo el tamaño de la diapositiva/rela­ción de aspecto al crear una presentación?**

Establezca el [tamaño de la diapositiva](/slides/es/cpp/slide-size/) (incluyendo preajustes como 4:3 y 16:9 o dimensiones personalizadas) y elija cómo debe escalar el contenido.

**¿En qué unidades se miden los tamaños y coordenadas?**

En puntos: 1 pulgada equivale a 72 unidades.

**¿Cómo manejo presentaciones muy grandes (con muchos archivos multimedia) para reducir el uso de memoria?**

Utilice [estrategias de gestión de BLOB](/slides/es/cpp/manage-blob/), limite el almacenamiento en memoria aprovechando archivos temporales y prefiera flujos basados en archivos en lugar de flujos puramente en memoria.

**¿Puedo crear/guardar presentaciones en paralelo?**

No puede operar sobre la misma instancia de [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) desde [múltiples hilos](/slides/es/cpp/multithreading/). Ejecute instancias separadas e aisladas por hilo o proceso.

**¿Cómo elimino la marca de agua de prueba y las limitaciones?**

[Aplique una licencia](/slides/es/cpp/licensing/) una vez por proceso. El XML de licencia debe permanecer sin modificar, y la configuración de la licencia debe sincronizarse si varios hilos están involucrados.

**¿Puedo firmar digitalmente el PPTX que creo?**

Sí. Las [firmas digitales](/slides/es/cpp/digital-signature-in-powerpoint/) (agregar y verificar) son compatibles con presentaciones.

**¿Se admiten macros (VBA) en presentaciones creadas?**

Sí. Puede [crear/editar proyectos VBA](/slides/es/cpp/presentation-via-vba/) y guardar archivos con macros habilitadas como PPTM/PPSM.
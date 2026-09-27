---
title: Crear presentaciones en JavaScript
linktitle: Crear presentación
type: docs
weight: 10
url: /es/nodejs-java/create-presentation/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Crea presentaciones con Aspose.Slides—produce archivos PPT, PPTX y ODP, aprovecha la compatibilidad con OpenDocument y guárdalas programáticamente para obtener resultados fiables."
---
## **Visión general**

Este artículo muestra cómo crear una presentación en Aspose.Slides, añadir un cuadro de texto a su primera diapositiva y guardar el resultado como un archivo.

Antes de comenzar, instala el paquete `aspose.slides.via.java` desde npm, junto con el JDK, Python y las herramientas de compilación de C++ que necesita. Consulta [Instalación](/slides/es/nodejs-java/installation/).

## **Crear una presentación de PowerPoint**

Para crear una presentación y colocar un cuadro de texto en su primera diapositiva, sigue estos pasos:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/). Una nueva presentación ya contiene una diapositiva vacía.
1. Obtén esa diapositiva de la [colección de diapositivas](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/getslides/) por su índice, 0.
1. Añade un rectángulo con el método [addAutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addautoshape/) y establece su texto con [setText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/settext/).
1. Guarda la presentación como archivo PPTX con el método [save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/save/).
1. Libera la presentación con el método [dispose](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/dispose/) y finaliza el proceso.

```javascript
const asposeSlides = require("aspose.slides.via.java");

const presentation = new asposeSlides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 50, 50, 400, 100);
    shape.getTextFrame().setText("Hello, Aspose.Slides!");
    presentation.save("hello.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

// Aspose.Slides se ejecuta en una máquina virtual Java que mantiene Node.js en ejecución, por lo que se debe finalizar el proceso explícitamente.
process.exit(0);
```

La esquina superior izquierda del rectángulo está a 50 puntos del borde izquierdo y 50 puntos del borde superior de la diapositiva, y el rectángulo tiene 400 puntos de ancho y 100 puntos de alto. Guarda el código como *hello.js* en la carpeta de tu proyecto y ejecuta `node hello.js`: guardará *hello.pptx*, con una diapositiva que contiene ese rectángulo y su texto, en la carpeta actual.

Aspose.Slides se ejecuta en una máquina virtual Java que el paquete `java` inicia dentro del proceso Node.js. Esa máquina virtual impide que Node.js finalice por sí mismo después de que el script termina, por lo que el ejemplo concluye con `process.exit(0)`.

Sin una licencia, Aspose.Slides también añade una marca de agua de evaluación a cada diapositiva que guarda; consulta [Licencias](/slides/es/nodejs-java/licensing/).

## **Preguntas frecuentes**

### ¿A qué formatos puedo guardar una nueva presentación?

Puedes guardar en [PPTX, PPT y ODP](/slides/es/nodejs-java/save-presentation/), y exportar a [PDF](/slides/es/nodejs-java/convert-powerpoint-to-pdf/), [XPS](/slides/es/nodejs-java/convert-powerpoint-to-xps/), [HTML](/slides/es/nodejs-java/convert-powerpoint-to-html/), [SVG](/slides/es/nodejs-java/render-a-slide-as-an-svg-image/) e [imágenes](/slides/es/nodejs-java/convert-powerpoint-to-png/), entre otros.

### ¿Puedo iniciar a partir de una plantilla (POTX/POTM) y guardar como PPTX normal?

Sí. Carga la plantilla y guárdala en el formato deseado; los formatos POTX/POTM/PPTM y similares [son compatibles](/slides/es/nodejs-java/supported-file-formats/).

### ¿Cómo controlo el tamaño/relação de aspecto de la diapositiva al crear una presentación?

Define el [tamaño de la diapositiva](/slides/es/nodejs-java/slide-size/) (incluyendo ajustes preestablecidos como 4:3 y 16:9 o dimensiones personalizadas) y elige cómo debe escalar el contenido.

### ¿En qué unidades se miden los tamaños y coordenadas?

En puntos: 1 pulgada equivale a 72 unidades.

### ¿Cómo manejo presentaciones muy grandes (con muchos archivos multimedia) para reducir el consumo de memoria?

Utiliza [estrategias de gestión de BLOB](/slides/es/nodejs-java/manage-blob/), limita el almacenamiento en memoria mediante archivos temporales y prefiere flujos basados en archivos sobre flujos puramente en memoria.

### ¿Puedo crear/guardar presentaciones en paralelo?

No puedes operar sobre la misma instancia de [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) desde [múltiples hilos](/slides/es/nodejs-java/multithreading/). Ejecuta instancias separadas e aisladas por hilo o proceso.

### ¿Cómo elimino la marca de agua de prueba y sus limitaciones?

[Aplica una licencia](/slides/es/nodejs-java/licensing/) una vez por proceso. El XML de la licencia debe permanecer sin modificar, y la configuración de la licencia debe sincronizarse si participan varios hilos.

### ¿Puedo firmar digitalmente el PPTX que creo?

Sí. Las [firmas digitales](/slides/es/nodejs-java/digital-signature-in-powerpoint/) (añadir y verificar) son compatibles con las presentaciones.

### ¿Se admiten macros (VBA) en las presentaciones creadas?

Sí. Puedes [crear/editar proyectos VBA](/slides/es/nodejs-java/presentation-via-vba/) y guardar archivos con macros habilitadas como PPTM/PPSM.
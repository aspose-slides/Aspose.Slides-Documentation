---
title: Operaciones de presentación de bajo código en JavaScript
linktitle: API de bajo código
type: docs
weight: 50
url: /es/nodejs-java/low-code-presentation-operations/
keywords:
- API de presentación de bajo código
- convertir presentación
- combinar presentaciones
- recorrer diapositivas
- recorrer formas
- recorrer texto
- recopilar formas
- comprimir presentación
- eliminar diapositivas maestras no usadas
- eliminar diapositivas de diseño no usadas
- comprimir fuentes incrustadas
- PowerPoint
- OpenDocument
- presentación
- Node.js
- JavaScript
- Aspose.Slides
description: "Utiliza la API de bajo código de Aspose.Slides en JavaScript para convertir y combinar presentaciones, recorrer el contenido, recopilar formas y reducir el tamaño de la presentación."
---
## **Descripción general**

El espacio de nombres `aspose.slides` proporciona clases auxiliares estáticas para operaciones comunes con presentaciones. Estas ayudas envuelven flujos de trabajo frecuentemente usados del modelo de objetos en métodos concretos, de modo que puedes convertir o combinar archivos, procesar elementos de la presentación, recopilar formas y eliminar contenido no utilizado con menos código.

Los auxiliares de bajo código son más útiles cuando la operación se aplica a todo el archivo o presentación y el flujo de trabajo predeterminado coincide con tus requisitos. Usa el modelo de objetos completo de [Aspose.Slides](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/) cuando necesites un control más detallado sobre diapositivas individuales, maestros, diseños, formas, configuraciones de exportación o relaciones entre elementos de la presentación.

La tabla siguiente resume los auxiliares disponibles:

| Ayudante | Para qué se utiliza |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/convert/) | Convertir una presentación a otro formato con una llamada directa de archivo a archivo. |
| [Merger](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/merger/) | Combinar archivos de presentación completos del mismo formato. |
| [ForEach](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/foreach/) | Ejecutar una acción para cada diapositiva, forma, párrafo o porción de texto. |
| [Collect](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/collect/) | Obtener formas de toda la presentación para procesarlas o analizarlas repetidamente. |
| [Compress](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/compress/) | Eliminar maestros y diseños no usados y reducir los datos de fuentes incrustadas. |

## **Convertir una presentación**

Utiliza [Convert.autoByExtension](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/convert/#autoByExtension) cuando la extensión del archivo de salida sea suficiente para seleccionar el formato de exportación. El método abre la presentación de origen, determina el formato requerido a partir de la ruta de salida y escribe el resultado.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

aspose.slides.Convert.autoByExtension("input.pptx", "output.pdf");
```

La clase [Convert](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/convert/) también ofrece métodos dedicados para salida en PDF, SVG, JPEG, PNG y TIFF. Usa el modelo de objetos completo cuando necesites inspeccionar o modificar la presentación antes de exportarla o configurar una opción de exportación que no esté expuesta por el asistente seleccionado. Consulta [Convert Presentation](/nodejs-java/convert-presentation/) para flujos de trabajo y opciones específicas de formato.

## **Combinar presentaciones**

Utiliza [Merger.process](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/merger/#process) para combinar archivos de presentación completos con una sola llamada. Las presentaciones de entrada deben tener el mismo formato de archivo.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const inputFiles = ["first.pptx", "second.pptx"];
aspose.slides.Merger.process(inputFiles, "merged.pptx");
```

El asistente es apropiado cuando todas las diapositivas deben añadirse a un único resultado sin seleccionarlas o remapearlas individualmente. Usa el modelo de objetos completo cuando necesites combinar diapositivas seleccionadas, aplicar un maestro o diseño de destino, preservar secciones explícitamente o conciliar diferentes tamaños de diapositiva. Consulta [Merge Presentations](/nodejs-java/merge-presentation/) para esos escenarios.

## **Recorrer elementos de la presentación**

La clase [ForEach](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/foreach/) invoca una devolución de llamada para cada tipo solicitado de elemento de presentación. Evita bucles anidados de colecciones y resulta cómoda para inspecciones o cambios de formato a nivel de toda la presentación. En Node.js, crea implementaciones de las interfaces de devolución de llamada con `java.newProxy`.

El siguiente ejemplo usa [ForEach.slide](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/foreach/#slide), [ForEach.shape](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/foreach/#shape), [ForEach.paragraph](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/foreach/#paragraph) y [ForEach.portion](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/foreach/#portion) para inspeccionar los elementos correspondientes:

```javascript
const java = require("java");
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slideCallback = java.newProxy("com.aspose.slides.ForEach$ForEachSlideCallback", {
        invoke: function (slide, index) {
            console.log(`Slide ${index}: ${slide.getShapes().size()} shapes`);
        }
    });
    aspose.slides.ForEach.slide(presentation, slideCallback);

    const shapeCallback = java.newProxy("com.aspose.slides.ForEach$ForEachShapeCallback", {
        invoke: function (shape, slide, index) {
            console.log(`Shape ${index} on ${slide.getClass().getSimpleName()}: ${shape.getName()}`);
        }
    });
    aspose.slides.ForEach.shape(presentation, shapeCallback);

    const paragraphCallback = java.newProxy("com.aspose.slides.ForEach$ForEachParagraphCallback", {
        invoke: function (paragraph, slide, index) {
            console.log(`Paragraph ${index} on ${slide.getClass().getSimpleName()}: ${paragraph.getText()}`);
        }
    });
    aspose.slides.ForEach.paragraph(presentation, paragraphCallback);

    const portionCallback = java.newProxy("com.aspose.slides.ForEach$ForEachPortionCallback", {
        invoke: function (portion, paragraph, slide, index) {
            console.log(`Portion ${index} on ${slide.getClass().getSimpleName()}: ${portion.getText()}`);
        }
    });
    aspose.slides.ForEach.portion(presentation, portionCallback);
} finally {
    presentation.dispose();
}
```

De forma predeterminada, el recorrido de formas y texto a nivel de presentación incluye diapositivas normales, de maestro y de diseño. Las sobrecargas con un parámetro `includeNotes` también pueden procesar diapositivas de notas. Usa bucles de colección directos cuando el orden de recorrido, la salida anticipada, el filtrado antes de la invocación de la devolución de llamada o el control detallado padre‑hijo sean importantes.

## **Recopilar formas**

Utiliza [Collect.shapes](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/collect/#shapes) cuando necesites una colección de todas las formas de una presentación en lugar de una devolución de llamada para cada forma. Esto es útil cuando el mismo conjunto será filtrado, contado o procesado más de una vez.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const shapes = aspose.slides.Collect.shapes(presentation);
    const iterator = shapes.iterator();

    while (iterator.hasNext()) {
        const shape = iterator.next();
        console.log(`${shape.getName()}: ${shape.getClass().getSimpleName()}`);
    }
} finally {
    presentation.dispose();
}
```

Usa [ForEach.shape](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/foreach/#shape) en su lugar cuando cada forma pueda manejarse inmediatamente y no necesites retener el resultado recopilado.

## **Comprimir contenido de la presentación**

La clase [Compress](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/compress/) puede eliminar elementos estructurales no usados y reducir los datos de fuentes incrustadas:

- [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/compress/#removeUnusedLayoutSlides) elimina diapositivas de diseño que ninguna diapositiva normal referencia.
- [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/compress/#removeUnusedMasterSlides) elimina diapositivas maestras que ya no se usan.
- [Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/compress/#compressEmbeddedFonts) elimina caracteres no usados de las fuentes incrustadas.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    aspose.slides.Compress.removeUnusedLayoutSlides(presentation);
    aspose.slides.Compress.removeUnusedMasterSlides(presentation);
    aspose.slides.Compress.compressEmbeddedFonts(presentation);

    presentation.save("compressed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Elimina primero los diseños no usados antes que los maestros, de modo que un maestro que quede sin referencias tras la limpieza de diseños también pueda eliminarse. Guarda la presentación optimizada en un nuevo archivo si puedes necesitar más tarde los maestros, diseños o los datos completos de fuentes incrustadas originales. Para más detalle, consulta [Slide Master](/nodejs-java/slide-master/) y [Embedded Font](/nodejs-java/embedded-font/).

## **Preguntas frecuentes**

**¿Cuándo debo usar la API de bajo código en lugar del modelo de objetos completo?**

Usa los auxiliares de bajo código cuando una operación estándar se aplica a un archivo o presentación completa y no requiere control detallado sobre elementos individuales. Usa el modelo de objetos completo cuando necesites seleccionar diapositivas específicas, controlar relaciones de maestros y diseños, inspeccionar el estado intermedio o configurar un comportamiento que el asistente no expone.

**¿Puede Merger combinar presentaciones en diferentes formatos de archivo?**

No. [Merger.process](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/merger/#process) requiere que las presentaciones de entrada tengan el mismo formato. Convierte primero los archivos de entrada a un formato común, por ejemplo con [Convert.autoByExtension](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/convert/#autoByExtension), y luego combina los archivos convertidos.

**¿Processa ForEach diapositivas de maestro, diseño y notas?**

[ForEach.slide](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/foreach/#slide) recorre las diapositivas normales de la presentación. Las operaciones a nivel de presentación de [ForEach.shape](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/foreach/#shape), [ForEach.paragraph](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/foreach/#paragraph) y [ForEach.portion](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/foreach/#portion) incluyen por defecto diapositivas normales, de maestro y de diseño. Usa sus sobrecargas con `includeNotes` establecido a `true` para incluir diapositivas de notas.

**¿Cuál es la diferencia entre ForEach.shape y Collect.shapes?**

Usa [ForEach.shape](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/foreach/#shape) para procesar cada forma inmediatamente mediante una devolución de llamada. Usa [Collect.shapes](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/collect/#shapes) cuando necesites un resultado iterable que pueda retenerse, filtrarse, contarse o recorrerse varias veces.

**¿Compress siempre reduce el tamaño del archivo de la presentación?**

No necesariamente. El resultado depende de si la presentación contiene diseños no usados, maestros no usados o fuentes incrustadas con caracteres no usados. Si ninguno de esos elementos está presente, las operaciones correspondientes de [Compress](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/compress/) pueden no reducir el tamaño del archivo.

**¿Los cambios realizados por ForEach o Compress se guardan automáticamente?**

No. Estos auxiliares operan sobre el objeto [Presentation](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation/) cargado en memoria. Después de modificar elementos en una devolución de llamada de [ForEach](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/foreach/) o ejecutar [Compress](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/compress/), llama a [Presentation.save](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation/#save) para escribir el resultado.

## **Artículos relacionados**

- [Convert Presentation](/nodejs-java/convert-presentation/)
- [Merge Presentations](/nodejs-java/merge-presentation/)
- [Slide Master](/nodejs-java/slide-master/)
- [Manage Text Box](/nodejs-java/manage-textbox/)
- [Embedded Font](/nodejs-java/embedded-font/)
---
title: Operaciones de presentación de bajo código en Android
linktitle: API de bajo código
type: docs
weight: 50
url: /es/androidjava/low-code-presentation-operations/
keywords:
- API de presentación de bajo código
- convertir presentación
- combinar presentaciones
- recorrer diapositivas
- recorrer formas
- recorrer texto
- recopilar formas
- comprimir presentación
- eliminar diapositivas maestro no usadas
- eliminar diapositivas de diseño no usadas
- comprimir fuentes incrustadas
- PowerPoint
- OpenDocument
- presentación
- Android
- Java
- Aspose.Slides
description: "Utiliza la API de bajo código de Aspose.Slides en Android para convertir y combinar presentaciones, recorrer el contenido, recopilar formas y reducir el tamaño de la presentación."
---
## **Resumen**

El paquete [com.aspose.slides](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/) proporciona clases auxiliares estáticas para operaciones comunes con presentaciones. Estos auxiliares envuelven flujos de trabajo del modelo de objetos que se usan con frecuencia en métodos concretos, de modo que puedes convertir o combinar archivos, procesar elementos de la presentación, recopilar formas y eliminar contenido no usado con menos código.

Los auxiliares de bajo código son más útiles cuando la operación se aplica a todo un archivo o presentación y el flujo de trabajo predeterminado satisface tus requisitos. Usa el modelo de objetos completo de [Aspose.Slides](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/) cuando necesites un control detallado sobre diapositivas individuales, maestros, diseños, formas, opciones de exportación o relaciones entre los elementos de la presentación.

La tabla siguiente resume los auxiliares disponibles:

| Ayudante | Uso |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/convert/) | Convertir una presentación a otro formato con una llamada directa de archivo a archivo. |
| [Merger](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/merger/) | Combinar archivos de presentación completos del mismo formato. |
| [ForEach](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/foreach/) | Ejecutar una acción para cada diapositiva, forma, párrafo o fragmento de texto. |
| [Collect](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/collect/) | Obtener formas de toda la presentación para procesarlas o analizarlas repetidamente. |
| [Compress](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/compress/) | Eliminar maestros y diseños no usados y reducir los datos de fuentes incrustadas. |

## **Convertir una presentación**

Usa [Convert.autoByExtension](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/convert/#autoByExtension-java.lang.String-java.lang.String-) cuando la extensión del archivo de salida es suficiente para seleccionar el formato de exportación. El método abre la presentación de origen, determina el formato necesario a partir de la ruta de salida y escribe el resultado.

```java
import com.aspose.slides.Convert;

Convert.autoByExtension("input.pptx", "output.pdf");
```

La clase [Convert](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/convert/) también ofrece métodos específicos para salida PDF, SVG, JPEG, PNG y TIFF. Utiliza el modelo de objetos completo cuando necesites inspeccionar o modificar la presentación antes de la exportación o configurar una opción de exportación que no esté expuesta por el asistente seleccionado. Consulta [Convert Presentation](/slides/es/androidjava/convert-presentation/) para flujos de trabajo y opciones específicas de cada formato.

## **Combinar presentaciones**

Usa [Merger.process](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/merger/#process-java.lang.String:A-java.lang.String-) para combinar archivos de presentación completos con una sola llamada. Las presentaciones de entrada deben tener el mismo formato de archivo.

```java
import com.aspose.slides.Merger;

String[] inputFiles = { "part-1.pptx", "part-2.pptx" };
Merger.process(inputFiles, "merged.pptx");
```

El asistente es apropiado cuando todas las diapositivas deben añadirse a un único resultado sin seleccionarlas o remapearlas individualmente. Utiliza el modelo de objetos completo cuando necesites combinar diapositivas seleccionadas, aplicar un maestro o diseño de destino, preservar secciones explícitamente o conciliar diferentes tamaños de diapositiva. Consulta [Merge Presentations](/slides/es/androidjava/merge-presentation/) para esos escenarios.

## **Recorrer elementos de la presentación**

La clase [ForEach](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/foreach/) invoca una devolución de llamada para cada tipo solicitado de elemento de la presentación. Evita bucles anidados de colecciones y resulta práctica para inspecciones o cambios de formato a nivel de toda la presentación.

El siguiente ejemplo usa [ForEach.slide](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/foreach/#slide-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachSlideCallback-), [ForEach.shape](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-), [ForEach.paragraph](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/foreach/#paragraph-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachParagraphCallback-), y [ForEach.portion](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/foreach/#portion-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachPortionCallback-) para inspeccionar los elementos correspondientes:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    ForEach.slide(presentation, (slide, index) -> {
        System.out.println(String.format("Slide %d: %d shapes", index, slide.getShapes().size()));
    });

    ForEach.shape(presentation, (shape, slide, index) -> {
        System.out.println(String.format("Shape %d on %s: %s", index, slide.getClass().getSimpleName(), shape.getName()));
    });

    ForEach.paragraph(presentation, (paragraph, slide, index) -> {
        System.out.println(String.format("Paragraph %d on %s: %s", index, slide.getClass().getSimpleName(), paragraph.getText()));
    });

    ForEach.portion(presentation, (portion, paragraph, slide, index) -> {
        System.out.println(String.format("Portion %d on %s: %s", index, slide.getClass().getSimpleName(), portion.getText()));
    });
} finally {
    presentation.dispose();
}
```

De forma predeterminada, el recorrido de formas y texto a nivel de presentación incluye diapositivas normales, maestras y de diseño. Las sobrecargas con un parámetro `includeNotes` también pueden procesar diapositivas de notas. Usa bucles de colección directos cuando el orden de recorrido, la salida temprana, el filtrado antes de invocar la devolución de llamada o el control detallado de padres e hijos sea importante.

## **Recopilar formas**

Usa [Collect.shapes](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/collect/#shapes-com.aspose.slides.Presentation-) cuando necesites una colección de todas las formas de una presentación en lugar de una devolución de llamada para cada forma. Esto es útil cuando el mismo conjunto será filtrado, contado o procesado más de una vez.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    Iterable<Shape> shapes = Collect.shapes(presentation);

    for (Shape shape : shapes) {
        System.out.println(String.format("%s: %s", shape.getName(), shape.getClass().getSimpleName()));
    }
} finally {
    presentation.dispose();
}
```

Utiliza [ForEach.shape](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-) en su lugar cuando cada forma pueda manejarse inmediatamente y no necesites conservar el resultado recopilado.

## **Comprimir contenido de la presentación**

La clase [Compress](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/compress/) puede eliminar elementos estructurales no usados y reducir los datos de fuentes incrustadas:

- [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) elimina diapositivas de diseño que no son referenciadas por ninguna diapositiva normal.
- [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) elimina maestros que ya no se utilizan.
- [Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/compress/#compressEmbeddedFonts-com.aspose.slides.Presentation-) elimina caracteres no usados de las fuentes incrustadas.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    Compress.removeUnusedLayoutSlides(presentation);
    Compress.removeUnusedMasterSlides(presentation);
    Compress.compressEmbeddedFonts(presentation);

    presentation.save("compressed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Elimina los diseños no usados antes que los maestros no usados, de modo que un maestro que quede sin referencias tras la limpieza de diseños también pueda eliminarse. Guarda la presentación optimizada en un archivo nuevo si puedes necesitar más tarde los maestros, diseños o los datos completos de fuentes incrustadas originales. Para más detalles, consulta [Slide Master](/slides/es/androidjava/slide-master/) y [Embedded Font](/slides/es/androidjava/embedded-font/).

## **Preguntas frecuentes**

**¿Cuándo debo usar la API de bajo código en lugar del modelo de objetos completo?**

Utiliza los auxiliares de bajo código cuando una operación estándar se aplica a un archivo o presentación completa y no requiere un control detallado sobre elementos individuales. Usa el modelo de objetos completo cuando necesites seleccionar diapositivas específicas, controlar relaciones entre maestros y diseños, inspeccionar el estado intermedio o configurar un comportamiento que el asistente no exponga.

**¿Puede Merger combinar presentaciones en diferentes formatos de archivo?**

No. [Merger.process](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/merger/#process-java.lang.String:A-java.lang.String-) requiere que las presentaciones de entrada tengan el mismo formato. Convierte los archivos de entrada a un formato común primero, por ejemplo con [Convert.autoByExtension](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/convert/#autoByExtension-java.lang.String-java.lang.String-), y luego combina los archivos convertidos.

**¿ForEach procesa diapositivas maestras, de diseño y de notas?**

[ForEach.slide](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/foreach/#slide-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachSlideCallback-) recorre las diapositivas normales de la presentación. Las operaciones a nivel de presentación de [ForEach.shape](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-), [ForEach.paragraph](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/foreach/#paragraph-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachParagraphCallback-), y [ForEach.portion](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/foreach/#portion-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachPortionCallback-) incluyen por defecto diapositivas normales, maestras y de diseño. Usa sus sobrecargas con `includeNotes` establecido en `true` para incluir también diapositivas de notas.

**¿Cuál es la diferencia entre ForEach.shape y Collect.shapes?**

Utiliza [ForEach.shape](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-) para procesar cada forma inmediatamente mediante una devolución de llamada. Utiliza [Collect.shapes](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/collect/#shapes-com.aspose.slides.Presentation-) cuando necesites un resultado iterable que pueda conservarse, filtrarse, contarse o recorrerse varias veces.

**¿Compress siempre reduce el tamaño del archivo de la presentación?**

No necesariamente. El resultado depende de si la presentación contiene diseños no usados, maestros no usados o fuentes incrustadas con caracteres no utilizados. Si ninguno de esos elementos está presente, las operaciones correspondientes de [Compress](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/compress/) pueden no disminuir el tamaño del archivo.

**¿Los cambios realizados por ForEach o Compress se guardan automáticamente?**

No. Estos auxiliares operan sobre el objeto [Presentation](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/presentation/) cargado en memoria. Después de modificar elementos en una devolución de llamada de [ForEach](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/foreach/) o ejecutar [Compress](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/compress/), llama a [Presentation.save](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) para escribir el resultado.

## **Artículos relacionados**

- [Convert Presentation](/slides/es/androidjava/convert-presentation/)
- [Merge Presentations](/slides/es/androidjava/merge-presentation/)
- [Slide Master](/slides/es/androidjava/slide-master/)
- [Manage Text Box](/slides/es/androidjava/manage-textbox/)
- [Embedded Font](/slides/es/androidjava/embedded-font/)
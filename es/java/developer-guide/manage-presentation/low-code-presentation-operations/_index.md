---
title: Operaciones de presentación de bajo código en Java
linktitle: API de bajo código
type: docs
weight: 50
url: /es/java/low-code-presentation-operations/
keywords:
  - API de presentación de bajo código
  - convertir presentación
  - combinar presentaciones
  - recorrer diapositivas
  - recorrer formas
  - recorrer texto
  - recopilar formas
  - comprimir presentación
  - eliminar diapositivas maestras no utilizadas
  - eliminar diapositivas de diseño no utilizadas
  - comprimir fuentes incrustadas
  - PowerPoint
  - OpenDocument
  - presentación
  - Java
  - Aspose.Slides
description: "Utiliza la API de bajo código de Aspose.Slides en Java para convertir y combinar presentaciones, recorrer el contenido, recopilar formas y reducir el tamaño de la presentación."
---
## **Visión general**

El paquete [com.aspose.slides](https://reference.aspose.com/slides/es/java/com.aspose.slides/) proporciona clases auxiliares estáticas para operaciones comunes de presentaciones. Estas ayudas envuelven flujos de trabajo típicos del modelo de objetos en métodos focalizados, de modo que puedes convertir o combinar archivos, procesar elementos de la presentación, recopilar formas y eliminar contenido no utilizado con menos código.

Los ayudantes de bajo código son más útiles cuando la operación se aplica a todo el archivo o presentación y el flujo de trabajo predeterminado coincide con tus requisitos. Utiliza el modelo de objetos completo de [Aspose.Slides](https://reference.aspose.com/slides/es/java/com.aspose.slides/) cuando necesites un control detallado sobre diapositivas individuales, maestros, diseños, formas, opciones de exportación o relaciones entre los elementos de la presentación.

La tabla siguiente resume los ayudantes disponibles:

| Asistente | Uso |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/es/java/com.aspose.slides/convert/) | Convertir una presentación a otro formato mediante una llamada directa de archivo a archivo. |
| [Merger](https://reference.aspose.com/slides/es/java/com.aspose.slides/merger/) | Combinar archivos de presentación completos del mismo formato. |
| [ForEach](https://reference.aspose.com/slides/es/java/com.aspose.slides/foreach/) | Ejecutar una acción para cada diapositiva, forma, párrafo o fragmento de texto. |
| [Collect](https://reference.aspose.com/slides/es/java/com.aspose.slides/collect/) | Recuperar las formas de toda la presentación para procesarlas o analizarlas repetidamente. |
| [Compress](https://reference.aspose.com/slides/es/java/com.aspose.slides/compress/) | Eliminar maestros y diseños no utilizados y reducir los datos de fuentes incrustadas. |

## **Convertir una presentación**

Utiliza [Convert.autoByExtension](https://reference.aspose.com/slides/es/java/com.aspose.slides/convert/#autoByExtension-java.lang.String-java.lang.String-) cuando la extensión del archivo de salida es suficiente para seleccionar el formato de exportación. El método abre la presentación de origen, determina el formato requerido a partir de la ruta de salida y escribe el resultado.

```java
import com.aspose.slides.Convert;

Convert.autoByExtension("input.pptx", "output.pdf");
```

La clase [Convert](https://reference.aspose.com/slides/es/java/com.aspose.slides/convert/) también ofrece métodos dedicados para salida en PDF, SVG, JPEG, PNG y TIFF. Utiliza el modelo de objetos completo cuando necesites inspeccionar o modificar la presentación antes de la exportación o configurar una opción de exportación que no esté expuesta por el ayudante seleccionado. Consulta [Convert Presentation](/slides/es/java/convert-presentation/) para flujos de trabajo y opciones específicas de formato.

## **Combinar presentaciones**

Utiliza [Merger.process](https://reference.aspose.com/slides/es/java/com.aspose.slides/merger/#process-java.lang.String:A-java.lang.String-) para combinar archivos de presentación completos con una sola llamada. Las presentaciones de entrada deben tener el mismo formato de archivo.

```java
import com.aspose.slides.Merger;

String[] inputFiles = { "part-1.pptx", "part-2.pptx" };
Merger.process(inputFiles, "merged.pptx");
```

El ayudante es adecuado cuando todas las diapositivas deben agregarse a un único resultado sin seleccionarlas o remape ellas individualmente. Utiliza el modelo de objetos completo cuando necesites combinar diapositivas seleccionadas, aplicar un maestro o diseño de destino, preservar secciones explícitamente o reconciliar diferentes tamaños de diapositiva. Consulta [Merge Presentations](/slides/es/java/merge-presentation/) para esos escenarios.

## **Recorrer elementos de la presentación**

La clase [ForEach](https://reference.aspose.com/slides/es/java/com.aspose.slides/foreach/) invoca una devolución de llamada para cada tipo solicitado de elemento de presentación. Evita bucles anidados de colecciones y resulta cómoda para inspecciones o cambios de formato a nivel de toda la presentación.

El siguiente ejemplo utiliza [ForEach.slide](https://reference.aspose.com/slides/es/java/com.aspose.slides/foreach/#slide-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachSlideCallback-), [ForEach.shape](https://reference.aspose.com/slides/es/java/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-), [ForEach.paragraph](https://reference.aspose.com/slides/es/java/com.aspose.slides/foreach/#paragraph-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachParagraphCallback-), y [ForEach.portion](https://reference.aspose.com/slides/es/java/com.aspose.slides/foreach/#portion-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachPortionCallback-) para inspeccionar los elementos correspondientes:

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

Por defecto, el recorrido de formas y texto a nivel de presentación incluye diapositivas normales, de maestro y de diseño. Las sobrecargas con un parámetro `includeNotes` también pueden procesar diapositivas de notas. Utiliza bucles de colección directos cuando el orden de recorrido, la salida anticipada, el filtrado previo a la invocación de la devolución de llamada o el control detallado padre‑hijo son importantes.

## **Recopilar formas**

Utiliza [Collect.shapes](https://reference.aspose.com/slides/es/java/com.aspose.slides/collect/#shapes-com.aspose.slides.Presentation-) cuando necesites una colección de todas las formas de una presentación en lugar de una devolución de llamada para cada forma. Resulta útil cuando el mismo conjunto será filtrado, contado o procesado más de una vez.

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

Usa [ForEach.shape](https://reference.aspose.com/slides/es/java/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-) en su lugar cuando cada forma pueda manejarse inmediatamente y no necesites conservar el resultado recopilado.

## **Comprimir contenido de la presentación**

La clase [Compress](https://reference.aspose.com/slides/es/java/com.aspose.slides/compress/) puede eliminar elementos estructurales no utilizados y reducir los datos de fuentes incrustadas:

- [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/es/java/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) elimina las diapositivas de diseño que no son referenciadas por ninguna diapositiva normal.
- [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/es/java/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) elimina los maestros que ya no se utilizan.
- [Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/es/java/com.aspose.slides/compress/#compressEmbeddedFonts-com.aspose.slides.Presentation-) elimina los caracteres no usados de las fuentes incrustadas.

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

Elimina primero los diseños no utilizados antes que los maestros no utilizados, de modo que un maestro que quede sin referencias tras la limpieza de diseños también pueda eliminarse. Guarda la presentación optimizada en un archivo nuevo si puedes necesitar más tarde los maestros, diseños o los datos completos de fuentes incrustadas. Para más detalle, consulta [Slide Master](/slides/es/java/slide-master/) y [Embedded Font](/slides/es/java/embedded-font/).

## **Preguntas frecuentes**

**¿Cuándo debo usar la API de bajo código en lugar del modelo de objetos completo?**

Usa los ayudantes de bajo código cuando una operación estándar se aplica a un archivo o presentación completa y no requiere un control detallado sobre elementos individuales. Utiliza el modelo de objetos completo cuando necesites seleccionar diapositivas específicas, controlar las relaciones entre maestros y diseños, inspeccionar el estado intermedio o configurar un comportamiento que el ayudante no expone.

**¿Puede Merger combinar presentaciones en diferentes formatos de archivo?**

No. [Merger.process](https://reference.aspose.com/slides/es/java/com.aspose.slides/merger/#process-java.lang.String:A-java.lang.String-) requiere que las presentaciones de entrada estén en el mismo formato. Convierte primero los archivos de entrada a un formato común, por ejemplo con [Convert.autoByExtension](https://reference.aspose.com/slides/es/java/com.aspose.slides/convert/#autoByExtension-java.lang.String-java.lang.String-), y luego combina los archivos convertidos.

**¿ForEach procesa diapositivas de maestro, diseño y notas?**

[ForEach.slide](https://reference.aspose.com/slides/es/java/com.aspose.slides/foreach/#slide-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachSlideCallback-) recorre las diapositivas normales de la presentación. Las operaciones [ForEach.shape](https://reference.aspose.com/slides/es/java/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-), [ForEach.paragraph](https://reference.aspose.com/slides/es/java/com.aspose.slides/foreach/#paragraph-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachParagraphCallback-) y [ForEach.portion](https://reference.aspose.com/slides/es/java/com.aspose.slides/foreach/#portion-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachPortionCallback-) incluyen por defecto diapositivas normales, de maestro y de diseño. Utiliza sus sobrecargas con `includeNotes` establecido a `true` para incluir diapositivas de notas.

**¿Cuál es la diferencia entre ForEach.shape y Collect.shapes?**

Usa [ForEach.shape](https://reference.aspose.com/slides/es/java/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-) para procesar cada forma inmediatamente mediante una devolución de llamada. Usa [Collect.shapes](https://reference.aspose.com/slides/es/java/com.aspose.slides/collect/#shapes-com.aspose.slides.Presentation-) cuando necesites un resultado iterable que pueda conservarse, filtrarse, contarse o recorrerse varias veces.

**¿Compress siempre reduce el tamaño del archivo de la presentación?**

No necesariamente. El resultado depende de si la presentación contiene diseños no utilizados, maestros no utilizados o fuentes incrustadas con caracteres no usados. Si ninguno de esos elementos está presente, las operaciones correspondientes de [Compress](https://reference.aspose.com/slides/es/java/com.aspose.slides/compress/) pueden no reducir el tamaño del archivo.

**¿Los cambios realizados por ForEach o Compress se guardan automáticamente?**

No. Estos ayudantes operan sobre el objeto [Presentation](https://reference.aspose.com/slides/es/java/com.aspose.slides/presentation/) cargado en memoria. Después de modificar elementos en una devolución de llamada de [ForEach](https://reference.aspose.com/slides/es/java/com.aspose.slides/foreach/) o ejecutar [Compress](https://reference.aspose.com/slides/es/java/com.aspose.slides/compress/), llama a [Presentation.save](https://reference.aspose.com/slides/es/java/com.aspose.slides/presentation/#save-java.lang.String-int-) para escribir el resultado.

## **Artículos relacionados**

- [Convert Presentation](/slides/es/java/convert-presentation/)
- [Merge Presentations](/slides/es/java/merge-presentation/)
- [Slide Master](/slides/es/java/slide-master/)
- [Manage Text Box](/slides/es/java/manage-textbox/)
- [Embedded Font](/slides/es/java/embedded-font/)
---
title: Fusionar presentaciones de forma eficiente en Java
linktitle: Fusionar presentaciones
type: docs
weight: 40
url: /es/java/merge-presentation/
keywords:
- fusionar PowerPoint
- fusionar presentaciones
- fusionar diapositivas
- fusionar PPT
- fusionar PPTX
- fusionar ODP
- combinar PowerPoint
- combinar presentaciones
- combinar diapositivas
- combinar PPT
- combinar PPTX
- combinar ODP
- Java
- Aspose.Slides
description: "Aprenda a fusionar presentaciones PowerPoint y OpenDocument en Java clonando diapositivas, controlando maestros y diseños, redimensionando el contenido de las diapositivas, preservando secciones y gestionando archivos protegidos o de gran tamaño."
---
## **Resumen**

Aspose.Slides for Java combina presentaciones clonando diapositivas de una [Presentation](https://reference.aspose.com/slides/es/java/com.aspose.slides/presentation/) a otra. La operación principal es [ISlideCollection.addClone](https://reference.aspose.com/slides/es/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-), que puede preservar el formato de la diapositiva origen o adjuntar la diapositiva clonada a un maestro o diseño en la presentación de destino.

Este artículo cubre los flujos de trabajo de combinación más habituales:

- combinar todas las diapositivas conservando su formato original;
- combinar diapositivas seleccionadas;
- aplicar un maestro de la presentación de destino;
- aplicar un diseño específico de la presentación de destino;
- normalizar distintos tamaños de diapositiva antes de combinar;
- añadir diapositivas clonadas a una sección;
- combinar varias presentaciones en un flujo de trabajo de extremo a extremo;
- gestionar maestros, recursos, notas, comentarios, medios, fuentes, contraseñas, archivos grandes y consideraciones de multihilo.

## **Cómo afecta la clonación de diapositivas a maestros y diseños**

Una diapositiva hereda gran parte de su apariencia de su diseño y maestro. Por esa razón, la sobrecarga de clonación que elija determina cómo se integra la diapositiva combinada en la presentación de destino.

Utilice [ISlideCollection.addClone](https://reference.aspose.com/slides/es/java/com.aspose.slides/islidecollection/) de una de estas formas:

- `addClone(sourceSlide)` — preserva el diseño y el formato de la diapositiva origen. Cuando sea necesario, el maestro origen puede clonarse automáticamente en la presentación de destino. Aspose.Slides rastrea los maestros clonados automáticamente para que las diapositivas repetidas que usan el mismo maestro origen no provoquen una clonación múltiple de ese maestro.
- `addClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — adjunta la diapositiva clonada a un [IMasterSlide](https://reference.aspose.com/slides/es/java/com.aspose.slides/imasterslide/) de destino específico. Aspose.Slides busca un diseño coincidente bajo ese maestro por tipo o nombre de diseño.
- `addClone(sourceSlide, destinationLayout)` — adjunta la diapositiva clonada directamente a un [ILayoutSlide](https://reference.aspose.com/slides/es/java/com.aspose.slides/ilayoutslide/) de destino específico.

El maestro o diseño pasado a una sobrecarga `addClone` debe pertenecer a la **presentación de destino**, no a la presentación origen.

## **Combinar presentaciones completas y preservar el formato origen**

La combinación más simple copia cada diapositiva de la presentación origen a la de destino. Esta es la opción adecuada cuando las diapositivas importadas deben conservar su tema, maestro y relaciones de diseño originales.

```java
import com.aspose.slides.*;

Presentation destination = new Presentation("destination.pptx");
Presentation source = new Presentation("source.pptx");
try {
    for (ISlide slide : source.getSlides()) {
        destination.getSlides().addClone(slide);
    }

    destination.save("merged.pptx", SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

La presentación resultante puede contener varios maestros cuando el origen y el destino utilizan diseños diferentes. Esto es normal cuando se preserva intencionalmente el formato origen.

## **Combinar diapositivas seleccionadas**

No es necesario clonar todas las diapositivas. El siguiente ejemplo importa solo los índices de diapositivas seleccionados de la presentación origen.

```java
import com.aspose.slides.*;

Presentation destination = new Presentation("destination.pptx");
Presentation source = new Presentation("source.pptx");
try {
    int[] slideIndexes = { 0, 2, 4 };

    for (int index : slideIndexes) {
        destination.getSlides().addClone(source.getSlides().get_Item(index));
    }

    destination.save("merged-selected-slides.pptx", SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

Valide los índices de diapositiva antes de clonarlos cuando provengan de entrada de usuario o de configuración externa.

## **Combinar diapositivas usando un maestro de destino**

Utilice la sobrecarga [addClone(ISlide, IMasterSlide, boolean)](https://reference.aspose.com/slides/es/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) cuando las diapositivas importadas deban seguir un maestro que ya pertenece a la presentación de destino.

```java
import com.aspose.slides.*;

Presentation destination = new Presentation("destination.pptx");
Presentation source = new Presentation("source.pptx");
try {
    IMasterSlide destinationMaster = destination.getMasters().get_Item(0);

    for (ISlide slide : source.getSlides()) {
        destination.getSlides().addClone(slide, destinationMaster, true);
    }

    destination.save("merged-with-destination-master.pptx", SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

Aspose.Slides selecciona un diseño apropiado bajo el maestro especificado coincidiendo con el tipo o nombre del diseño origen. Si no existe un diseño adecuado y `allowCloneMissingLayout` es `true`, el diseño origen se clona para que la diapositiva pueda añadirse. Si es `false`, se lanza una [PptxEditException](https://reference.aspose.com/slides/es/java/com.aspose.slides/pptxeditexception/).

Utilice `false` cuando quiera que la combinación falle en lugar de introducir un diseño adicional en el maestro de destino.

## **Combinar diapositivas usando un diseño de destino específico**

Utilice la sobrecarga [addClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/es/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-) cuando sepa exactamente qué diseño de destino deben usar las diapositivas importadas.

```java
import com.aspose.slides.*;

Presentation destination = new Presentation("destination.pptx");
Presentation source = new Presentation("source.pptx");
try {
    ILayoutSlide destinationLayout = destination.getLayoutSlides().get_Item(0);

    for (ISlide slide : source.getSlides()) {
        destination.getSlides().addClone(slide, destinationLayout);
    }

    destination.save("merged-with-destination-layout.pptx", SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

Aplicar un diseño de destino cambia la relación de diseño heredada; no rediseña el contenido de la diapositiva origen. Si los diseños origen y destino tienen estructuras de marcadores de posición diferentes, inspeccione el resultado para confirmar que el formato heredado y el comportamiento de los marcadores son apropiados.

## **Combinar presentaciones con diferentes tamaños de diapositiva**

Las presentaciones con dimensiones de diapositiva distintas pueden combinarse, pero clonar una diapositiva en una presentación con otro tamaño de diapositiva no rediseña automáticamente su contenido para el nuevo lienzo. Las formas pueden aparecer desplazadas, escaladas inesperadamente o fuera del área visible de la diapositiva.

Un enfoque práctico es redimensionar la presentación origen antes de clonar. El método [SlideSize.setSize](https://reference.aspose.com/slides/es/java/com.aspose.slides/slidesize/#setSize-float-float-int-) puede escalar el contenido existente mientras cambia las dimensiones de la diapositiva. [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/es/java/com.aspose.slides/slidesizescaletype/) escala el contenido para que encaje en el tamaño solicitado.

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation destination = new Presentation("destination.pptx");
Presentation source = new Presentation("source.pptx");
try {
    Dimension2D sourceSize = source.getSlideSize().getSize();
    Dimension2D destinationSize = destination.getSlideSize().getSize();

    if (sourceSize.getWidth() != destinationSize.getWidth() || 
        sourceSize.getHeight() != destinationSize.getHeight()) {
        source.getSlideSize().setSize(
            (float) destinationSize.getWidth(), 
            (float) destinationSize.getHeight(), 
            SlideSizeScaleType.EnsureFit);
    }

    for (ISlide slide : source.getSlides()) {
        destination.getSlides().addClone(slide);
    }

    destination.save("merged-same-slide-size.pptx", SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

Redimensionar modifica el objeto de la presentación origen en memoria. Si necesita que la presentación origen original permanezca sin cambios para otras operaciones, abra una instancia separada para la combinación.

## **Combinar diapositivas en una sección de la presentación**

El bucle básico de clonación de diapositivas no recrea la jerarquía de secciones de la presentación origen. Si las secciones son relevantes en la salida, cree o seleccione secciones en la presentación de destino y clone diapositivas en ellas explícitamente con [addClone(ISlide, ISection)](https://reference.aspose.com/slides/es/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-).

```java
import com.aspose.slides.*;

Presentation destination = new Presentation("destination.pptx");
Presentation source = new Presentation("source.pptx");
try {
    ISection importedSection = destination.getSections().appendEmptySection("Imported slides");

    for (ISlide slide : source.getSlides()) {
        destination.getSlides().addClone(slide, importedSection);
    }

    destination.save("merged-with-section.pptx", SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

Las diapositivas clonadas se añaden al final de la sección de destino especificada. Para preservar varias secciones origen, recree esas secciones en el destino y asocie cada diapositiva origen a la sección de destino correspondiente.

## **Combinar varias presentaciones de forma segura**

El siguiente ejemplo de extremo a extremo usa la primera presentación como destino, normaliza el tamaño de diapositiva de cada origen adicional, mantiene cada origen abierto solo mientras se copia y guarda el archivo final una sola vez.

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

String[] inputFiles = { "part1.pptx", "part2.pptx", "part3.pptx" };

Presentation merged = new Presentation(inputFiles[0]);
try {
    Dimension2D mergedSize = merged.getSlideSize().getSize();

    for (int fileIndex = 1; fileIndex < inputFiles.length; fileIndex++) {
        Presentation source = new Presentation(inputFiles[fileIndex]);
        try {
            Dimension2D sourceSize = source.getSlideSize().getSize();

            if (sourceSize.getWidth() != mergedSize.getWidth() || 
                sourceSize.getHeight() != mergedSize.getHeight()) {
                source.getSlideSize().setSize(
                    (float) mergedSize.getWidth(), 
                    (float) mergedSize.getHeight(), 
                    SlideSizeScaleType.EnsureFit);
            }

            for (ISlide slide : source.getSlides()) {
                merged.getSlides().addClone(slide);
            }
        } finally {
            source.dispose();
        }
    }

    merged.save("merged.pptx", SaveFormat.Pptx);
} finally {
    merged.dispose();
}
```

Este es un punto de partida útil para preservar el formato origen de las diapositivas importadas. Si su salida debe usar un solo tema de destino, reemplace la llamada simple `addClone(slide)` por la sobrecarga de maestro o diseño de destino apropiada mostrada antes.

## **Consideraciones prácticas**

### **Maestros, diseños y fidelidad del formato**

La clonación predeterminada de diapositivas puede traer automáticamente un maestro origen necesario a la presentación de destino. Aspose.Slides mantiene un registro interno de los maestros clonados automáticamente para evitar clonarlos repetidamente. Los maestros clonados manualmente no se registran, así que evite preclonar maestros a menos que necesite un control explícito de la estructura del maestro.

No asuma que dos maestros o diseños con el mismo nombre son visualmente equivalentes. Si una plantilla corporativa debe controlar la apariencia final, elija explícitamente un maestro o diseño de destino y verifique el resultado después de combinar.

### **Notas y comentarios**

Las notas del ponente y los comentarios de la diapositiva están asociados al contenido de la diapositiva y se copian cuando una diapositiva se clona. Aspose.Slides también expone APIs dedicadas para [presentation notes](https://docs.aspose.com/slides/es/java/presentation-notes/) y [presentation comments](https://docs.aspose.com/slides/es/java/presentation-comments/).

Si el formato de la página de notas es importante, verifique la presentación combinada porque los maestros de notas son objetos a nivel de presentación y pueden diferir entre los archivos origen. Para flujos de revisión, también verifique los autores de los comentarios y los hilos de comentarios después de combinar archivos de diferentes autores o plantillas.

### **Imágenes, audio, vídeo, objetos OLE y enlaces externos**

Las diapositivas pueden referenciar recursos a nivel de presentación como imágenes, audio incrustado, vídeo incrustado y datos OLE. Clone la diapositiva completa en lugar de copiar solo sus formas visibles para que Aspose.Slides mantenga las relaciones de la diapositiva con sus recursos.

Los recursos incrustados y los enlazados deben tratarse de forma distinta. Un audio, vídeo, objeto OLE o hipervínculo enlazado sigue dependiendo de su destino externo; clonar una diapositiva no convierte un enlace externo en contenido incrustado. Pruebe las rutas y URLs de los recursos enlazados en el entorno donde se abrirá la presentación combinada.

Aspose.Slides rastrea explícitamente los maestros clonados automáticamente, pero esto no debe considerarse una garantía general de que los recursos binarios idénticos de presentaciones origen no relacionadas se deduplicarán siempre. Si el tamaño del archivo de salida es importante, inspeccione el paquete combinado y mida el resultado en lugar de confiar en una deduplicación implícita.

### **Fuentes incrustadas y disponibilidad de fuentes**

Las fuentes se gestionan a nivel de presentación. Si la tipografía debe permanecer coherente entre equipos, no asuma que clonar diapositivas por sí solo garantiza que todas las fuentes necesarias estén disponibles en el entorno de destino. Puede inspeccionar las fuentes incrustadas con [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/es/java/com.aspose.slides/fontsmanager/#getEmbeddedFonts--) y gestionar la incrustación explícitamente como se describe en [Embed Fonts in Presentations](https://docs.aspose.com/slides/es/java/embedded-font/).

También verifique que tenga permiso para incrustar las fuentes usadas por los archivos origen. Las licencias de fuentes pueden restringir la incrustación.

### **Presentaciones protegidas con contraseña**

Una fuente protegida con contraseña debe abrirse correctamente antes de que sus diapositivas puedan clonarse. Proporcione la contraseña a través de [LoadOptions.setPassword](https://reference.aspose.com/slides/es/java/com.aspose.slides/loadoptions/#setPassword-java.lang.String-).

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("YOUR_PASSWORD");

Presentation source = new Presentation("protected.pptx", loadOptions);
try {
    // Trabaje con la presentación descifrada.
} finally {
    source.dispose();
}
```

Abrir una fuente cifrada no aplica automáticamente la misma protección a la presentación de destino. Configure la protección de salida por separado cuando sea necesario.

### **Presentaciones grandes y uso de memoria**

Las presentaciones grandes que contienen imágenes de alta resolución, audio, vídeo u otros objetos binarios grandes pueden consumir mucha memoria. [LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/es/java/com.aspose.slides/loadoptions/#getBlobManagementOptions--) ofrece controles para la gestión de BLOB y el uso de archivos temporales. Consulte [Manage Presentation BLOBs](https://docs.aspose.com/slides/es/java/manage-blob/) para estrategias con archivos grandes.

Para archivos grandes, prefiera cargar desde rutas de archivo cuando sea posible, libere cada presentación origen tan pronto como se haya combinado y evite guardar resultados intermedios repetidamente a menos que el flujo requiera puntos de control.

### **Seguridad en hilos**

No cargue, modifique, guarde o clone la misma [Presentation](https://reference.aspose.com/slides/es/java/com.aspose.slides/presentation/) simultáneamente desde varios hilos. Mantenga cada instancia de presentación confinada a una operación de combinación. Si paraleliza trabajos independientes, use instancias de presentación independientes y siga la [guía de multihilo de Aspose.Slides](https://docs.aspose.com/slides/es/java/multithreading/).

## **Preguntas frecuentes**

**¿Cómo mantengo el diseño original de cada presentación origen?**

Use [`addClone(sourceSlide)`](https://reference.aspose.com/slides/es/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-) sin proporcionar un maestro o diseño de destino. Aspose.Slides puede clonar automáticamente el maestro origen cuando lo requiera la diapositiva importada.

**¿Cómo hago que las diapositivas importadas usen el tema del destino?**

Use la sobrecarga que acepta un maestro de destino. Pase un maestro de la presentación de destino, no del origen. Aspose.Slides intentará asignar cada diapositiva origen a un diseño apropiado bajo ese maestro.

**¿Cuándo debo usar un diseño de destino específico en lugar de un maestro de destino?**

Use un diseño específico cuando cada diapositiva importada deba usar un diseño conocido. Use un maestro cuando desee que Aspose.Slides seleccione entre los diseños de ese maestro según el tipo o nombre del diseño origen.

**¿Se pueden combinar presentaciones con diferentes tamaños de diapositiva?**

Sí, pero el contenido de la diapositiva no se rediseña automáticamente para las dimensiones de destino. Redimensione primero la presentación origen cuando necesite una colocación predecible, por ejemplo con [SlideSize.setSize](https://reference.aspose.com/slides/es/java/com.aspose.slides/slidesize/#setSize-float-float-int-) y [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/es/java/com.aspose.slides/slidesizescaletype/).

**¿Puedo combinar presentaciones PPT, PPTX y ODP en un solo archivo?**

Sí. Cargue cada presentación origen, clone las diapositivas necesarias en una presentación de destino y guarde el destino en un formato de salida compatible. Como los formatos de presentación no soportan exactamente el mismo conjunto de funciones, verifique el contenido complejo después de combinaciones entre formatos. Consulte [Supported File Formats](https://docs.aspose.com/slides/es/java/supported-file-formats/).

**¿Se conservan automáticamente las secciones del origen?**

No con un bucle básico que solo clona diapositivas. Recree las secciones necesarias en el destino y use la sobrecarga de sección de [addClone](https://reference.aspose.com/slides/es/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-) cuando la estructura de secciones deba preservarse.

**¿Se conservan las notas del ponente y los comentarios?**

Se copian con la diapositiva clonada. Para flujos que dependan del estilo del maestro de notas, de los autores de los comentarios o de los datos de revisión en hilos, verifique el resultado combinado porque esos escenarios implican estructuras a nivel de presentación además del contenido de la diapositiva.

**¿Qué ocurre con audio, vídeo, objetos OLE y hipervínculos?**

El contenido incrustado se lleva como parte de las relaciones de recursos de la diapositiva clonada. Los enlaces externos permanecen externos, por lo que sus archivos o URLs de destino deben seguir estando disponibles después de la combinación.

**¿Están garantizadas las fuentes incrustadas de cada origen en la presentación combinada?**

No confíe solo en la clonación de diapositivas para la implementación de fuentes. Inspeccione las fuentes incrustadas del destino y gestione explícitamente la incrustación de fuentes o la disponibilidad de fuentes externas cuando la tipografía sea importante.

**¿Cómo combino un archivo protegido con contraseña?**

Ábralo con el [LoadOptions.setPassword](https://reference.aspose.com/slides/es/java/com.aspose.slides/loadoptions/#setPassword-java.lang.String-) correcto y luego clone sus diapositivas normalmente. La protección de salida se configura por separado.

**¿Cómo debo manejar presentaciones muy grandes?**

Use la gestión de BLOB cuando los objetos binarios grandes dominen el consumo de memoria, prefiera la carga por ruta de archivo para archivos muy grandes, libere prontamente las presentaciones origen y guarde el resultado final solo cuando sea necesario.

**¿Puedo combinar diapositivas desde varios hilos?**

No use una misma instancia de [Presentation](https://reference.aspose.com/slides/es/java/com.aspose.slides/presentation/) concurrentemente desde varios hilos. Mantenga cada operación de combinación aislada en sus propias instancias de presentación.
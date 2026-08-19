---
title: Fusionar presentaciones de forma eficiente en Android
linktitle: Fusionar presentaciones
type: docs
weight: 40
url: /es/androidjava/merge-presentation/
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
- Android
- Java
- Aspose.Slides
description: "Aprenda a fusionar presentaciones PowerPoint y OpenDocument en Android clonando diapositivas, controlando maestras y diseños, redimensionando el contenido de las diapositivas, conservando secciones y gestionando archivos protegidos o de gran tamaño."
---
## **Visión general**

Aspose.Slides for Android a través de Java combina presentaciones clonando diapositivas de una [Presentation](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/presentation/) en otra. La operación principal es [ISlideCollection.addClone](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-), que puede conservar el formato de la diapositiva de origen o adjuntar la diapositiva clonada a una maestra o a un diseño en la presentación de destino.

Este artículo cubre los flujos de trabajo de combinación más habituales:

- combinar todas las diapositivas conservando su formato de origen;
- combinar diapositivas seleccionadas;
- aplicar una maestra de la presentación de destino;
- aplicar un diseño específico de la presentación de destino;
- normalizar diferentes tamaños de diapositiva antes de combinar;
- añadir diapositivas clonadas a una sección;
- combinar varias presentaciones en un flujo de trabajo de extremo a extremo;
- gestionar maestros, recursos, notas, comentarios, medios, fuentes, contraseñas, archivos grandes y cuestiones de multihilo.

## **Cómo la clonación de diapositivas afecta a los maestros y diseños**

Una diapositiva hereda gran parte de su apariencia de su diseño y maestra. Por esa razón, la sobrecarga de clonación que elija determina cómo se integra la diapositiva combinada en la presentación de destino.

Utilice [ISlideCollection.addClone](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/islidecollection/) de una de estas maneras:

- `addClone(sourceSlide)` — conserva el diseño y formato de la diapositiva de origen. Cuando sea necesario, la maestra de origen puede clonarse automáticamente en la presentación de destino. Aspose.Slides registra las maestras clonadas automáticamente para que diapositivas repetidas que usan la misma maestra de origen no provoquen una clonación múltiple de esa maestra.
- `addClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — adjunta la diapositiva clonada a una [IMasterSlide](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/imasterslide/) de destino específica. Aspose.Slides busca un diseño coincidente bajo esa maestra por tipo o nombre de diseño.
- `addClone(sourceSlide, destinationLayout)` — adjunta la diapositiva clonada directamente a una [ILayoutSlide](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ilayoutslide/) de destino específica.

La maestra o el diseño pasados a una sobrecarga de `addClone` deben pertenecer a la **presentación de destino**, no a la de origen.

## **Combinar presentaciones completas y conservar el formato de origen**

La combinación más simple copia cada diapositiva de la presentación de origen a la de destino. Esta es la opción adecuada cuando las diapositivas importadas deben mantener su tema, maestra y relaciones de diseño originales.

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

La presentación resultante puede contener varias maestras cuando el origen y el destino utilizan diseños diferentes. Esto es normal cuando se preserva intencionalmente el formato de origen.

## **Combinar diapositivas seleccionadas**

No es necesario clonar todas las diapositivas. El siguiente ejemplo importa sólo los índices de diapositivas seleccionados de la presentación de origen.

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

Valide los índices de diapositiva antes de clonarlos cuando provengan de entrada de usuario o de una configuración externa.

## **Combinar diapositivas usando una maestra de destino**

Utilice la sobrecarga [addClone(ISlide, IMasterSlide, boolean)](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) cuando las diapositivas importadas deban seguir una maestra que ya pertenece a la presentación de destino.

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

Aspose.Slides selecciona un diseño apropiado bajo la maestra especificada coincidiendo con el tipo o nombre del diseño de origen. Si no existe un diseño adecuado y `allowCloneMissingLayout` es `true`, el diseño de origen se clona para que la diapositiva pueda añadirse. Si es `false`, se lanza una [PptxEditException](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/pptxeditexception/).

Utilice `false` cuando desee que la combinación falle en lugar de introducir un diseño adicional en la maestra de destino.

## **Combinar diapositivas usando un diseño específico de destino**

Utilice la sobrecarga [addClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-) cuando sepa exactamente qué diseño de destino deben usar las diapositivas importadas.

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

Aplicar un diseño de destino cambia la relación de diseño heredada; no rediseña el contenido de la diapositiva de origen. Si los diseños de origen y destino tienen estructuras de marcadores de posición distintas, inspeccione el resultado para confirmar que el formato heredado y el comportamiento de los marcadores son apropiados.

## **Combinar presentaciones con diferentes tamaños de diapositiva**

Las presentaciones con dimensiones de diapositiva distintas pueden combinarse, pero clonar una diapositiva en una presentación con otro tamaño no rediseña automáticamente su contenido para el nuevo lienzo. Las formas pueden aparecer desplazadas, escaladas inesperadamente o fuera del área visible de la diapositiva.

Un enfoque práctico es redimensionar la presentación de origen antes de clonar. El método [SlideSize.setSize](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/slidesize/#setSize-float-float-int-) puede escalar el contenido existente mientras cambia las dimensiones de la diapositiva. [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/slidesizescaletype/) escala el contenido para que quepa dentro del tamaño solicitado.

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation destination = new Presentation("destination.pptx");
Presentation source = new Presentation("source.pptx");
try {
    SizeF sourceSize = source.getSlideSize().getSize();
    SizeF destinationSize = destination.getSlideSize().getSize();

    if (sourceSize.getWidth() != destinationSize.getWidth() || 
        sourceSize.getHeight() != destinationSize.getHeight()) {
        source.getSlideSize().setSize(
            destinationSize.getWidth(), 
            destinationSize.getHeight(), 
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

Redimensionar modifica el objeto de la presentación de origen en memoria. Si necesita que la presentación de origen permanezca sin cambios para otras operaciones, abra una instancia separada para la combinación.

## **Combinar diapositivas en una sección de presentación**

El bucle básico de clonación de diapositivas no recrea la jerarquía de secciones de la presentación de origen. Si las secciones son importantes en la salida, cree o seleccione secciones en la presentación de destino y clone las diapositivas en ellas explícitamente con [addClone(ISlide, ISection)](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-).

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

Las diapositivas clonadas se añaden al final de la sección de destino especificada. Para conservar varias secciones de origen, recree esas secciones en el destino y asocie cada diapositiva de origen con la sección correspondiente del destino.

## **Combinar varias presentaciones de forma segura**

El siguiente ejemplo de extremo a extremo usa la primera presentación como destino, normaliza el tamaño de diapositiva de cada origen adicional, mantiene cada origen abierto solo mientras se copia y guarda el archivo final una sola vez.

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

String[] inputFiles = { "part1.pptx", "part2.pptx", "part3.pptx" };

Presentation merged = new Presentation(inputFiles[0]);
try {
    SizeF mergedSize = merged.getSlideSize().getSize();

    for (int fileIndex = 1; fileIndex < inputFiles.length; fileIndex++) {
        Presentation source = new Presentation(inputFiles[fileIndex]);
        try {
            SizeF sourceSize = source.getSlideSize().getSize();

            if (sourceSize.getWidth() != mergedSize.getWidth() || 
                sourceSize.getHeight() != mergedSize.getHeight()) {
                source.getSlideSize().setSize(
                    mergedSize.getWidth(), 
                    mergedSize.getHeight(), 
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

Esta es una base útil para conservar el formato de origen de las diapositivas importadas. Si su salida debe usar un único tema de destino, reemplace la llamada simple `addClone(slide)` por la sobrecarga de maestra o diseño de destino adecuada mostrada anteriormente.

## **Consideraciones prácticas**

### **Maestros, diseños y fidelidad del formato**

La clonación predeterminada de diapositivas puede traer automáticamente una maestra de origen requerida a la presentación de destino. Aspose.Slides mantiene un registro interno de las maestras clonadas automáticamente para evitar clonarlas repetidamente. Las maestras clonadas manualmente no se registran, por lo que debe evitar preclonar maestras a menos que necesite un control explícito sobre la estructura de la maestra.

No asuma que dos maestras o diseños con el mismo nombre son visualmente equivalentes. Si una plantilla corporativa debe controlar la apariencia final, elija explícitamente una maestra o un diseño de destino y verifique el resultado tras la combinación.

### **Notas y comentarios**

Las notas del presentador y los comentarios de diapositiva están asociados al contenido de la diapositiva y se copian cuando se clona una diapositiva. Aspose.Slides también expone API dedicadas para [presentation notes](https://docs.aspose.com/slides/es/androidjava/presentation-notes/) y [presentation comments](https://docs.aspose.com/slides/es/androidjava/presentation-comments/).

Si el formato de la página de notas es importante, verifique la presentación combinada porque las maestras de notas son objetos a nivel de presentación y pueden diferir entre los archivos de origen. Para flujos de revisión, también verifique los autores de los comentarios y los hilos de comentarios después de combinar archivos de diferentes autores o plantillas.

### **Imágenes, audio, vídeo, objetos OLE y enlaces externos**

Las diapositivas pueden referenciar recursos a nivel de presentación, como imágenes, audio incrustado, vídeo incrustado y datos OLE. Clone la propia diapositiva en lugar de copiar sólo sus formas visibles para que Aspose.Slides pueda mantener las relaciones de la diapositiva con sus recursos.

Los recursos incrustados y los vinculados deben tratarse de forma diferente. Un audio, vídeo, objeto OLE o hipervínculo vinculado sigue dependiendo de su objetivo externo; clonar una diapositiva no convierte un vínculo externo en contenido incrustado. Pruebe las rutas y URLs de los recursos vinculados en el entorno donde se abrirá la presentación combinada.

Aspose.Slides rastrea explícitamente las maestras clonadas automáticamente, pero esto no debe considerarse una garantía de que recursos binarios idénticos de presentaciones fuente no relacionadas siempre se deduplicarán. Si el tamaño del archivo de salida es importante, inspeccione el paquete combinado y mida el resultado en lugar de confiar en la deduplicación implícita.

### **Fuentes incrustadas y disponibilidad de fuentes**

Las fuentes se gestionan a nivel de presentación. Si la tipografía debe permanecer coherente entre máquinas, no asuma que clonar diapositivas por sí solo garantiza que cada fuente requerida esté disponible en el entorno de destino. Puede inspeccionar las fuentes incrustadas con [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/fontsmanager/#getEmbeddedFonts--) y gestionar la incrustación explícitamente como se describe en [Embed Fonts in Presentations](https://docs.aspose.com/slides/es/androidjava/embedded-font/).

También verifique que tiene permiso para incrustar las fuentes utilizadas por los archivos de origen. Las licencias de fuentes pueden restringir la incrustación.

### **Presentaciones protegidas con contraseña**

Un origen protegido con contraseña debe abrirse correctamente antes de que sus diapositivas puedan clonarse. Proporcione la contraseña mediante [LoadOptions.setPassword](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/loadoptions/#setPassword-java.lang.String-).

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("YOUR_PASSWORD");

Presentation source = new Presentation("protected.pptx", loadOptions);
try {
    // Trabajar con la presentación desencriptada.
} finally {
    source.dispose();
}
```

Abrir un origen cifrado no aplica automáticamente la misma protección a la presentación de destino. Configure la protección de salida por separado cuando sea necesario.

### **Presentaciones grandes y uso de memoria**

Las presentaciones grandes que contienen imágenes de alta resolución, audio, vídeo u otros objetos binarios voluminosos pueden consumir memoria significativa. [LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/loadoptions/#getBlobManagementOptions--) ofrece controles para la gestión de BLOB y el uso de archivos temporales. Consulte [Manage Presentation BLOBs](https://docs.aspose.com/slides/es/androidjava/manage-blob/) para estrategias con archivos grandes.

Para archivos grandes, prefiera cargar desde rutas de archivo cuando sea posible, libere cada presentación de origen tan pronto como se haya combinado y evite guardar resultados intermedios repetidamente a menos que el flujo de trabajo requiera puntos de control.

### **Seguridad en subprocesos**

No cargue, modifique, guarde ni clone la misma [Presentation](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/presentation/) concurrentemente desde varios hilos. Mantenga cada instancia de presentación confinada a una operación de combinación. Si paraleliza trabajos independientes, use instancias de presentación independientes y siga la [guía de multihilo de Aspose.Slides](https://docs.aspose.com/slides/es/androidjava/multithreading/).

## **Preguntas frecuentes**

**¿Cómo puedo mantener el diseño original de cada presentación fuente?**

Utilice `addClone(sourceSlide)` sin proporcionar una maestra ni un diseño de destino. Aspose.Slides puede clonar automáticamente la maestra de origen cuando la diapositiva importada la necesite.

**¿Cómo hago que las diapositivas importadas usen el tema de destino?**

Utilice la sobrecarga que acepta una maestra de destino. Pase una maestra de la presentación de destino, no de la de origen. Aspose.Slides intentará mapear cada diapositiva de origen a un diseño apropiado bajo esa maestra.

**¿Cuándo debo usar un diseño específico de destino en lugar de una maestra de destino?**

Use un diseño específico cuando cada diapositiva importada deba emplear un diseño conocido. Use una maestra cuando desee que Aspose.Slides seleccione entre los diseños de esa maestra según el tipo o nombre del diseño de origen.

**¿Se pueden combinar presentaciones con diferentes tamaños de diapositiva?**

Sí, pero el contenido de la diapositiva no se rediseña automáticamente para las dimensiones de destino. Redimensione primero la presentación de origen cuando necesite una colocación predecible, por ejemplo con [SlideSize.setSize](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/slidesize/#setSize-float-float-int-) y [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/slidesizescaletype/).

**¿Puedo combinar presentaciones PPT, PPTX y ODP en un solo archivo?**

Sí. Cargue cada presentación de origen, clone las diapositivas necesarias en un destino y guarde el destino en un formato de salida compatible. Dado que los formatos de presentación no admiten exactamente el mismo conjunto de funcionalidades, verifique el contenido complejo después de combinaciones entre formatos. Consulte [Supported File Formats](https://docs.aspose.com/slides/es/androidjava/supported-file-formats/).

**¿Se conservan automáticamente las secciones de origen?**

No con un bucle básico que sólo clona diapositivas. Recree las secciones necesarias en el destino y utilice la sobrecarga de sección de [addClone](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-) cuando la estructura de secciones deba preservarse.

**¿Se conservan las notas del presentador y los comentarios?**

Se copian con la diapositiva clonada. Para flujos que dependen del estilo de la maestra de notas, de los autores de los comentarios o de datos de revisión en hilos, verifique el resultado combinado porque esos escenarios implican estructuras a nivel de presentación además del contenido de las diapositivas.

**¿Qué ocurre con audio, vídeo, objetos OLE y enlaces hipertexto?**

El contenido incrustado se transporta como parte de las relaciones de recursos de la diapositiva clonada. Los enlaces externos permanecen externos, por lo que sus archivos o URLs de destino deben seguir estando disponibles después de la combinación.

**¿Se garantiza que las fuentes incrustadas de cada origen estén disponibles en la presentación combinada?**

No confíe sólo en la clonación de diapositivas para la distribución de fuentes. Inspeccione las fuentes incrustadas en el destino y gestione explícitamente la incrustación de fuentes o la disponibilidad de fuentes externas cuando la tipografía sea importante.

**¿Cómo puedo combinar un archivo protegido con contraseña?**

Ábralo con la contraseña correcta mediante [LoadOptions.setPassword](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/loadoptions/#setPassword-java.lang.String-), luego clone sus diapositivas de forma habitual. La protección de salida se configura por separado.

**¿Cómo debo manejar presentaciones muy grandes?**

Utilice la gestión de BLOB cuando los objetos binarios grandes dominen el uso de memoria, prefiera la carga desde rutas de archivo para archivos muy grandes, libere rápidamente las presentaciones de origen y guarde el resultado final sólo cuando sea necesario.

**¿Puedo combinar diapositivas desde varios hilos?**

No utilice una única instancia de [Presentation](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/presentation/) concurrentemente desde varios hilos. Mantenga cada operación de combinación aislada en sus propias instancias de presentación.
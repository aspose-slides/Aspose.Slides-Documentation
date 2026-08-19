---
title: Fusionar presentaciones de forma eficiente en JavaScript
linktitle: Fusionar presentaciones
type: docs
weight: 40
url: /es/nodejs-java/merge-presentation/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Aprenda cómo fusionar presentaciones PowerPoint y OpenDocument en JavaScript clonando diapositivas, controlando maestros y diseños, redimensionando el contenido de las diapositivas, preservando secciones y gestionando archivos protegidos o de gran tamaño."
---
## **Visión general**

Aspose.Slides for Node.js a través de Java combina presentaciones clonando diapositivas de una [Presentation](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation/) a otra. La operación principal es [SlideCollection.addClone](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-), que puede preservar el formato de la diapositiva de origen o adjuntar la diapositiva clonada a un maestro o diseño en la presentación de destino.

Este artículo cubre los flujos de trabajo de combinación más habituales:

- combinar todas las diapositivas conservando su formato original;
- combinar diapositivas seleccionadas;
- aplicar un maestro de la presentación de destino;
- aplicar un diseño específico de la presentación de destino;
- normalizar tamaños de diapositiva diferentes antes de combinar;
- añadir diapositivas clonadas a una sección;
- combinar varias presentaciones en un flujo de trabajo de extremo a extremo;
- gestionar maestros, recursos, notas, comentarios, medios, fuentes, contraseñas, archivos grandes y cuestiones de multihilo.

## **Cómo afecta la clonación de diapositivas a maestros y diseños**

Una diapositiva hereda gran parte de su apariencia de su diseño y maestro. Por esa razón, la sobrecarga de clonación que elija determina cómo se integra la diapositiva combinada en la presentación de destino.

Utilice [SlideCollection.addClone](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/slidecollection/) de una de estas formas:

- `addClone(sourceSlide)` — conserva el diseño y formato de la diapositiva de origen. Cuando sea necesario, el maestro de origen puede clonarse automáticamente en la presentación de destino. Aspose.Slides rastrea los maestros clonados automáticamente para que las diapositivas repetidas que usan el mismo maestro de origen no produzcan una clonación múltiple de ese maestro.
- `addClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — adjunta la diapositiva clonada a un [MasterSlide](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/masterslide/) de destino específico. Aspose.Slides busca un diseño coincidente bajo ese maestro por tipo o nombre de diseño.
- `addClone(sourceSlide, destinationLayout)` — adjunta la diapositiva clonada directamente a un [LayoutSlide](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/layoutslide/) de destino específico.

El maestro o diseño pasado a una sobrecarga `addClone` debe pertenecer a la **presentación de destino**, no a la de origen.

## **Combinar presentaciones completas y conservar el formato de origen**

La combinación más sencilla copia cada diapositiva de la presentación de origen a la de destino. Esta es la opción adecuada cuando las diapositivas importadas deben mantener su tema, maestro y relaciones de diseño originales.

```javascript
const aspose = require("aspose.slides.via.java");

const destination = new aspose.slides.Presentation("destination.pptx");
const source = new aspose.slides.Presentation("source.pptx");
try {
    for (let i = 0; i < source.getSlides().size(); i++) {
        destination.getSlides().addClone(source.getSlides().get_Item(i));
    }

    destination.save("merged.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

La presentación resultante puede contener varios maestros cuando la fuente y el destino usan diseños diferentes. Esto es esperado cuando se preserva intencionalmente el formato de origen.

## **Combinar diapositivas seleccionadas**

No es necesario clonar todas las diapositivas. El siguiente ejemplo importa sólo los índices de diapositiva seleccionados de la presentación de origen.

```javascript
const aspose = require("aspose.slides.via.java");

const destination = new aspose.slides.Presentation("destination.pptx");
const source = new aspose.slides.Presentation("source.pptx");
try {
    const slideIndexes = [0, 2, 4];

    for (const index of slideIndexes) {
        destination.getSlides().addClone(source.getSlides().get_Item(index));
    }

    destination.save("merged-selected-slides.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

Valide los índices de diapositiva antes de clonarlos cuando provengan de entrada de usuario o de una configuración externa.

## **Combinar diapositivas usando un maestro de destino**

Utilice la sobrecarga [addClone(Slide, MasterSlide, boolean)](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-aspose.slides.IMasterSlide-boolean-) cuando las diapositivas importadas deben seguir un maestro que ya pertenece a la presentación de destino.

```javascript
const aspose = require("aspose.slides.via.java");

const destination = new aspose.slides.Presentation("destination.pptx");
const source = new aspose.slides.Presentation("source.pptx");
try {
    const destinationMaster = destination.getMasters().get_Item(0);

    for (let i = 0; i < source.getSlides().size(); i++) {
        destination.getSlides().addClone(source.getSlides().get_Item(i), destinationMaster, true);
    }

    destination.save("merged-with-destination-master.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

Aspose.Slides selecciona un diseño apropiado bajo el maestro especificado al coincidir con el tipo o nombre del diseño de origen. Si no existe un diseño adecuado y `allowCloneMissingLayout` es `true`, el diseño de origen se clona para que la diapositiva pueda añadirse. Si es `false`, se lanza una [PptxEditException](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/pptxeditexception/).

Utilice `false` cuando desee que la combinación falle en lugar de introducir un diseño adicional en el maestro de destino.

## **Combinar diapositivas usando un diseño de destino específico**

Utilice la sobrecarga [addClone(Slide, LayoutSlide)](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-aspose.slides.ILayoutSlide-) cuando sepa exactamente qué diseño de destino deben usar las diapositivas importadas.

```javascript
const aspose = require("aspose.slides.via.java");

const destination = new aspose.slides.Presentation("destination.pptx");
const source = new aspose.slides.Presentation("source.pptx");
try {
    const destinationLayout = destination.getLayoutSlides().get_Item(0);

    for (let i = 0; i < source.getSlides().size(); i++) {
        destination.getSlides().addClone(source.getSlides().get_Item(i), destinationLayout);
    }

    destination.save("merged-with-destination-layout.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

Aplicar un diseño de destino cambia la relación de diseño heredada; no rediseña el contenido de la diapositiva de origen. Si los diseños de origen y destino tienen estructuras de marcadores de posición diferentes, inspeccione el resultado para confirmar que el formato heredado y el comportamiento de los marcadores son apropiados.

## **Combinar presentaciones con diferentes tamaños de diapositiva**

Las presentaciones con dimensiones de diapositiva distintas pueden combinarse, pero clonar una diapositiva en una presentación con otro tamaño de diapositiva no rediseña automáticamente su contenido para el nuevo lienzo. Las formas pueden aparecer desplazadas, escaladas inesperadamente o fuera del área visible de la diapositiva.

Un enfoque práctico es cambiar el tamaño de la presentación de origen antes de clonarla. El método [SlideSize.setSize](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/slidesize/#setSize-float-float-int-) puede escalar el contenido existente mientras cambia las dimensiones de la diapositiva. [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/slidesizescaletype/) escala el contenido para que quepa dentro del tamaño solicitado.

```javascript
const aspose = require("aspose.slides.via.java");

const destination = new aspose.slides.Presentation("destination.pptx");
const source = new aspose.slides.Presentation("source.pptx");
try {
    const sourceSize = source.getSlideSize().getSize();
    const destinationSize = destination.getSlideSize().getSize();
    const sizesDiffer = sourceSize.getWidth() !== destinationSize.getWidth() || 
                        sourceSize.getHeight() !== destinationSize.getHeight();

    if (sizesDiffer) {
        source.getSlideSize().setSize(
            destinationSize.getWidth(), 
            destinationSize.getHeight(), 
            aspose.slides.SlideSizeScaleType.EnsureFit);
    }

    for (let i = 0; i < source.getSlides().size(); i++) {
        destination.getSlides().addClone(source.getSlides().get_Item(i));
    }

    destination.save("merged-same-slide-size.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

Cambiar el tamaño modifica el objeto de presentación de origen en memoria. Si necesita que la presentación de origen original permanezca sin cambios para otras operaciones, abra una instancia separada para la combinación.

## **Combinar diapositivas en una sección de presentación**

El bucle básico de clonación de diapositivas no recrea la jerarquía de secciones de la presentación de origen. Si las secciones son importantes en la salida, cree o seleccione secciones en la presentación de destino y clone las diapositivas en ellas explícitamente con [addClone(Slide, Section)](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-aspose.slides.ISection-).

```javascript
const aspose = require("aspose.slides.via.java");

const destination = new aspose.slides.Presentation("destination.pptx");
const source = new aspose.slides.Presentation("source.pptx");
try {
    const importedSection = destination.getSections().appendEmptySection("Imported slides");

    for (let i = 0; i < source.getSlides().size(); i++) {
        destination.getSlides().addClone(source.getSlides().get_Item(i), importedSection);
    }

    destination.save("merged-with-section.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

Las diapositivas clonadas se añaden al final de la sección de destino especificada. Para preservar varias secciones de origen, recree esas secciones en el destino y asocie cada diapositiva de origen a la sección de destino correspondiente.

## **Combinar varias presentaciones de forma segura**

El siguiente ejemplo de extremo a extremo usa la primera presentación como destino, normaliza el tamaño de diapositiva de cada fuente adicional, mantiene cada fuente abierta sólo mientras se copia y guarda el archivo final una sola vez.

```javascript
const aspose = require("aspose.slides.via.java");

const inputFiles = ["part1.pptx", "part2.pptx", "part3.pptx"];

const merged = new aspose.slides.Presentation(inputFiles[0]);
try {
    const mergedSize = merged.getSlideSize().getSize();

    for (let fileIndex = 1; fileIndex < inputFiles.length; fileIndex++) {
        const source = new aspose.slides.Presentation(inputFiles[fileIndex]);
        try {
            const sourceSize = source.getSlideSize().getSize();
            const sizesDiffer = sourceSize.getWidth() !== mergedSize.getWidth() || 
                                sourceSize.getHeight() !== mergedSize.getHeight();

            if (sizesDiffer) {
                source.getSlideSize().setSize(
                    mergedSize.getWidth(), 
                    mergedSize.getHeight(), 
                    aspose.slides.SlideSizeScaleType.EnsureFit);
            }

            for (let slideIndex = 0; slideIndex < source.getSlides().size(); slideIndex++) {
                merged.getSlides().addClone(source.getSlides().get_Item(slideIndex));
            }
        } finally {
            source.dispose();
        }
    }

    merged.save("merged.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    merged.dispose();
}
```

Esta es una base útil para conservar el formato de origen de las diapositivas importadas. Si su salida debe usar un único tema de destino, reemplace la llamada simple `addClone(sourceSlide)` por la sobrecarga de maestro o diseño de destino adecuada mostrada anteriormente.

## **Consideraciones prácticas**

### **Maestros, diseños y fidelidad de formato**

La clonación de diapositivas predeterminada puede traer automáticamente un maestro de origen necesario a la presentación de destino. Aspose.Slides mantiene un registro interno de los maestros clonados automáticamente para evitar clonarlos repetidamente. Los maestros clonados manualmente no se registran, por lo que debe evitar preclonar maestros a menos que necesite un control explícito sobre la estructura del maestro.

No asuma que dos maestros o diseños con el mismo nombre son visualmente equivalentes. Si una plantilla corporativa debe controlar la apariencia final, elija explícitamente un maestro o diseño de destino y verifique el resultado después de la combinación.

### **Notas y comentarios**

Las notas del presentador y los comentarios de diapositiva están asociados al contenido de la diapositiva y se copian cuando una diapositiva se clona. Aspose.Slides también expone APIs dedicadas para [presentation notes](https://docs.aspose.com/slides/es/nodejs-java/presentation-notes/) y [presentation comments](https://docs.aspose.com/slides/es/nodejs-java/presentation-comments/).

Si el formato de la página de notas es importante, verifique la presentación combinada porque los maestros de notas son objetos a nivel de presentación y pueden diferir entre los archivos de origen. Para flujos de revisión, también verifique los autores de los comentarios y los comentarios encadenados después de combinar archivos de diferentes autores o plantillas.

### **Imágenes, audio, vídeo, objetos OLE y enlaces externos**

Las diapositivas pueden referenciar recursos a nivel de presentación como imágenes, audio incrustado, vídeo incrustado y datos OLE. Clone la diapositiva completa en lugar de copiar solo sus formas visibles para que Aspose.Slides mantenga las relaciones de la diapositiva con sus recursos.

Los recursos incrustados y los vinculados deben tratarse de forma diferente. Un audio, vídeo, objeto OLE o hipervínculo vinculado sigue dependiendo de su destino externo; clonar una diapositiva no convierte un enlace externo en contenido incrustado. Pruebe las rutas y URL de los recursos vinculados en el entorno donde se abrirá la presentación combinada.

Aspose.Slides rastrea explícitamente los maestros clonados automáticamente, pero no debe considerarse una garantía general de que recursos binarios idénticos de presentaciones de origen no relacionadas siempre se deduplicarán. Si el tamaño del archivo de salida es importante, inspeccione el paquete combinado y mida el resultado en lugar de confiar en la deduplicación implícita.

### **Fuentes incrustadas y disponibilidad de fuentes**

Las fuentes se gestionan a nivel de presentación. Si la tipografía debe mantenerse consistente entre equipos, no asuma que clonar diapositivas garantiza que cada fuente necesaria esté disponible en el entorno de destino. Puede inspeccionar las fuentes incrustadas con [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/fontsmanager/#getEmbeddedFonts--) y gestionar la incrustación explícitamente como se describe en [Embed Fonts in Presentations](https://docs.aspose.com/slides/es/nodejs-java/embedded-font/).

Asimismo, verifique que tenga permiso para incrustar las fuentes utilizadas por los archivos de origen. Las licencias de fuentes pueden restringir la incrustación.

### **Presentaciones protegidas con contraseña**

Una fuente protegida con contraseña debe abrirse correctamente antes de que sus diapositivas puedan clonarse. Suministre la contraseña mediante [LoadOptions.setPassword](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/loadoptions/#setPassword-String-).

```javascript
const aspose = require("aspose.slides.via.java");

const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setPassword("YOUR_PASSWORD");

const source = new aspose.slides.Presentation("protected.pptx", loadOptions);
try {
    // Trabajar con la presentación descifrada.
} finally {
    source.dispose();
}
```

Abrir una fuente cifrada no aplica automáticamente la misma protección a la presentación de destino. Configure la protección de salida por separado cuando sea necesario.

### **Presentaciones grandes y uso de memoria**

Las presentaciones grandes que contienen imágenes de alta resolución, audio, vídeo u otros objetos binarios voluminosos pueden consumir memoria significativa. [LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/loadoptions/#getBlobManagementOptions--) ofrece controles para la gestión de BLOB y el uso de archivos temporales. Consulte [Manage Presentation BLOBs](https://docs.aspose.com/slides/es/nodejs-java/manage-blob/) para estrategias con archivos grandes.

Para archivos grandes, prefiera cargar desde rutas de archivo cuando sea posible, libere cada presentación fuente tan pronto como haya sido combinada y evite guardar repetidamente resultados intermedios a menos que el flujo requiera puntos de control.

### **Seguridad en hilos**

No cargue, guarde o clone una instancia de [Presentation](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation/) en varios hilos. Estas operaciones no son compatibles con uso multihilo. Si necesita paralelizar trabajos de combinación independientes, utilice varios procesos de un solo hilo, cada uno con sus propias instancias de presentación, y siga la [guía de multihilo de Aspose.Slides](https://docs.aspose.com/slides/es/nodejs-java/multithreading/).

## **FAQ**

**¿Cómo mantengo el diseño original de cada presentación de origen?**

Utilice [`addClone(sourceSlide)`](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-) sin proporcionar un maestro o diseño de destino. Aspose.Slides puede clonar automáticamente el maestro de origen cuando la diapositiva importada lo requiera.

**¿Cómo hago que las diapositivas importadas usen el tema de destino?**

Utilice la sobrecarga que acepta un maestro de destino. Pase un maestro de la presentación de destino, no del origen. Aspose.Slides intentará mapear cada diapositiva de origen a un diseño apropiado bajo ese maestro.

**¿Cuándo debo usar un diseño de destino específico en lugar de un maestro de destino?**

Use un diseño específico cuando cada diapositiva importada deba usar un diseño conocido. Use un maestro cuando quiera que Aspose.Slides seleccione entre los diseños de ese maestro según el tipo o nombre del diseño de origen.

**¿Se pueden combinar presentaciones con tamaños de diapositiva diferentes?**

Sí, pero el contenido de la diapositiva no se rediseña automáticamente para las dimensiones de destino. Redimensione la presentación de origen primero cuando necesite una colocación predecible, por ejemplo con [SlideSize.setSize](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/slidesize/#setSize-float-float-int-) y [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/slidesizescaletype/).

**¿Puedo combinar archivos PPT, PPTX y ODP en un único archivo?**

Sí. Cargue cada presentación fuente, clone las diapositivas requeridas en una presentación de destino y guarde el destino en un formato de salida compatible. Como los formatos de presentación no admiten exactamente el mismo conjunto de funciones, verifique el contenido complejo después de combinaciones entre formatos. Consulte [Supported File Formats](https://docs.aspose.com/slides/es/nodejs-java/supported-file-formats/).

**¿Se conservan automáticamente las secciones de origen?**

No, no lo hace un bucle básico que solo clona diapositivas. Recree las secciones necesarias en el destino y use la sobrecarga de sección de [addClone](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-aspose.slides.ISection-) cuando la estructura de secciones deba preservarse.

**¿Se conservan las notas del orador y los comentarios?**

Se copian con la diapositiva clonada. Para flujos que dependen del estilo del notes‑master, de los autores de los comentarios o de datos de revisión en cadena, verifique el resultado combinado porque esos escenarios implican también estructuras a nivel de presentación.

**¿Qué ocurre con audio, vídeo, objetos OLE y hipervínculos?**

El contenido incrustado se transporta como parte de las relaciones de recursos de la diapositiva clonada. Los enlaces externos permanecen externos, por lo que sus archivos o URL de destino deben seguir estando disponibles después de la combinación.

**¿Están garantizadas las fuentes incrustadas de cada origen en la presentación combinada?**

No confíe sólo en la clonación de diapositivas para el despliegue de fuentes. Inspeccione las fuentes incrustadas del destino y gestione explícitamente la incrustación de fuentes o su disponibilidad externa cuando la tipografía sea importante.

**¿Cómo combino un archivo protegido con contraseña?**

Ábralo con el [LoadOptions.setPassword](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/loadoptions/#setPassword-String-) correcto y luego clone sus diapositivas normalmente. La protección de salida se configura por separado.

**¿Cómo debo manejar presentaciones muy grandes?**

Utilice la gestión de BLOB cuando los objetos binarios grandes dominen el uso de memoria, prefiera la carga desde rutas de archivo para archivos muy grandes, libere pronto las presentaciones fuente y guarde el resultado final sólo cuando sea necesario.

**¿Puedo combinar diapositivas desde varios hilos?**

No cargue, guarde ni clone instancias de presentación en varios hilos. Para trabajos de combinación paralelos, use procesos separados de un solo hilo e instancias de presentación independientes.
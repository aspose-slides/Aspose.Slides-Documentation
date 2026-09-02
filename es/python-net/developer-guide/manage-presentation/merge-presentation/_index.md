---
title: Fusionar presentaciones eficientemente con Python
linktitle: Fusionar presentaciones
type: docs
weight: 40
url: /es/python-net/merge-presentation/
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
- Python
- Aspose.Slides
description: "Aprenda a fusionar presentaciones PowerPoint y OpenDocument en Python clonando diapositivas, controlando masters y diseños, redimensionando el contenido de las diapositivas, preservando secciones y gestionando archivos protegidos o de gran tamaño."
---
## **Resumen**

Aspose.Slides for Python a través de .NET combina presentaciones clonando diapositivas de una [Presentation](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/) a otra. La operación principal es [SlideCollection.add_clone](https://reference.aspose.com/slides/es/python-net/aspose.slides/slidecollection/add_clone/), que puede preservar el formato de la diapositiva de origen o adjuntar la diapositiva clonada a un master o diseño en la presentación de destino.

- combinar todas las diapositivas mientras se preserva su formato original;
- combinar diapositivas seleccionadas;
- aplicar un master de la presentación de destino;
- aplicar un diseño específico de la presentación de destino;
- normalizar diferentes tamaños de diapositiva antes de combinar;
- añadir diapositivas clonadas a una sección;
- combinar varias presentaciones en un flujo de trabajo completo;
- gestionar masters, recursos, notas, comentarios, medios, fuentes, contraseñas, archivos grandes y cuestiones de multihilo.

## **Cómo afecta la clonación de diapositivas a los masters y diseños**

Una diapositiva hereda gran parte de su apariencia de su diseño y master. Por esa razón, la sobrecarga de clonación que elija determina cómo se integra la diapositiva combinada en la presentación de destino.

Utilice [SlideCollection.add_clone](https://reference.aspose.com/slides/es/python-net/aspose.slides/slidecollection/add_clone/) de una de estas maneras:

- `add_clone(source_slide)` — preservar el diseño y formato de la diapositiva de origen. Cuando sea necesario, el master de origen puede clonarse automáticamente en la presentación de destino. Aspose.Slides rastrea los masters clonados automáticamente para que las diapositivas repetidas que usan el mismo master de origen no causen que ese master se clone repetidamente.
- `add_clone(source_slide, destination_master, allow_clone_missing_layout)` — adjuntar la diapositiva clonada a un [IMasterSlide](https://reference.aspose.com/slides/es/python-net/aspose.slides/imasterslide/) de destino específico. Aspose.Slides busca un diseño coincidente bajo ese master por tipo o nombre de diseño.
- `add_clone(source_slide, destination_layout)` — adjuntar la diapositiva clonada directamente a un [ILayoutSlide](https://reference.aspose.com/slides/es/python-net/aspose.slides/ilayoutslide/) de destino específico.

El master o diseño pasado a una sobrecarga `add_clone` debe pertenecer a la presentación **destino**, no a la presentación origen.

## **Combinar presentaciones completas y preservar el formato de origen**

La combinación más sencilla copia cada diapositiva de la presentación de origen a la presentación de destino. Esta es la opción adecuada cuando las diapositivas importadas deben mantener su tema original, master y relaciones de diseño.

```python
import aspose.slides as slides

with slides.Presentation("destination.pptx") as destination:
    with slides.Presentation("source.pptx") as source:
        for slide in source.slides:
            destination.slides.add_clone(slide)

        destination.save("merged.pptx", slides.export.SaveFormat.PPTX)
```

La presentación resultante puede contener múltiples masters cuando el origen y el destino utilizan diseños diferentes. Esto es esperable cuando se preserva intencionalmente el formato de origen.

## **Combinar diapositivas seleccionadas**

No es necesario clonar todas las diapositivas. El siguiente ejemplo importa solo los índices de diapositivas seleccionados de la presentación de origen.

```python
import aspose.slides as slides

with slides.Presentation("destination.pptx") as destination:
    with slides.Presentation("source.pptx") as source:
        slide_indexes = [0, 2, 4]

        for index in slide_indexes:
            destination.slides.add_clone(source.slides[index])

        destination.save("merged-selected-slides.pptx", slides.export.SaveFormat.PPTX)
```

Valide los índices de diapositivas antes de clonarlos cuando provengan de la entrada del usuario o de una configuración externa.

## **Combinar diapositivas usando un master de destino**

Utilice la sobrecarga [add_clone(source_slide, destination_master, allow_clone_missing_layout)](https://reference.aspose.com/slides/es/python-net/aspose.slides/slidecollection/add_clone/) cuando las diapositivas importadas deben seguir un master que ya pertenece a la presentación de destino.

```python
import aspose.slides as slides

with slides.Presentation("destination.pptx") as destination:
    with slides.Presentation("source.pptx") as source:
        destination_master = destination.masters[0]

        for slide in source.slides:
            destination.slides.add_clone(slide, destination_master, True)

        destination.save("merged-with-destination-master.pptx", slides.export.SaveFormat.PPTX)
```

Aspose.Slides selecciona un diseño apropiado bajo el master especificado coincidiendo con el tipo o nombre del diseño de origen. Si no existe un diseño adecuado y `allow_clone_missing_layout` es `True`, el diseño de origen se clona para que la diapositiva pueda añadirse. Si es `False`, se lanza una [PptxEditException](https://reference.aspose.com/slides/es/python-net/aspose.slides/pptxeditexception/).

Utilice `False` cuando desee que la combinación falle en lugar de introducir un diseño adicional en el master de destino.

## **Combinar diapositivas usando un diseño de destino específico**

Utilice la sobrecarga [add_clone(source_slide, destination_layout)](https://reference.aspose.com/slides/es/python-net/aspose.slides/slidecollection/add_clone/) cuando sepa exactamente qué diseño de destino deben usar las diapositivas importadas.

```python
import aspose.slides as slides

with slides.Presentation("destination.pptx") as destination:
    with slides.Presentation("source.pptx") as source:
        destination_layout = destination.layout_slides[0]

        for slide in source.slides:
            destination.slides.add_clone(slide, destination_layout)

        destination.save("merged-with-destination-layout.pptx", slides.export.SaveFormat.PPTX)
```

Aplicar un diseño de destino cambia la relación de diseño heredada; no rediseña el contenido de la diapositiva de origen. Si los diseños de origen y destino tienen estructuras de marcadores de posición diferentes, inspeccione el resultado para confirmar que el formato heredado y el comportamiento de los marcadores son adecuados.

## **Combinar presentaciones con diferentes tamaños de diapositiva**

Las presentaciones con diferentes dimensiones de diapositiva pueden combinarse, pero clonar una diapositiva en una presentación con otro tamaño de diapositiva no rediseña automáticamente su contenido para el nuevo lienzo. Por lo tanto, las formas pueden aparecer desplazadas, escaladas inesperadamente o fuera del área visible de la diapositiva.

Un enfoque práctico es cambiar el tamaño de la presentación origen antes de clonar. El método [SlideSize.set_size](https://reference.aspose.com/slides/es/python-net/aspose.slides/slidesize/set_size/) puede escalar el contenido existente mientras cambia las dimensiones de la diapositiva. [SlideSizeScaleType.ENSURE_FIT](https://reference.aspose.com/slides/es/python-net/aspose.slides/slidesizescaletype/) escala el contenido para que encaje dentro del tamaño solicitado.

```python
import aspose.slides as slides

with slides.Presentation("destination.pptx") as destination:
    with slides.Presentation("source.pptx") as source:
        if (
            source.slide_size.size.width != destination.slide_size.size.width
            or source.slide_size.size.height != destination.slide_size.size.height
        ):
            source.slide_size.set_size(
                destination.slide_size.size.width,
                destination.slide_size.size.height,
                slides.SlideSizeScaleType.ENSURE_FIT)

        for slide in source.slides:
            destination.slides.add_clone(slide)

        destination.save("merged-same-slide-size.pptx", slides.export.SaveFormat.PPTX)
```

Cambiar el tamaño modifica el objeto de la presentación origen en memoria. Si necesita que la presentación origen original permanezca sin cambios para otras operaciones, abra una instancia separada para la combinación.

## **Combinar diapositivas en una sección de la presentación**

El bucle básico de clonación de diapositivas no recrea la jerarquía de secciones de la presentación origen. Si las secciones son importantes en el resultado, cree o seleccione secciones en la presentación destino y clone las diapositivas en ellas explícitamente con [SlideCollection.add_clone](https://reference.aspose.com/slides/es/python-net/aspose.slides/slidecollection/add_clone/).

```python
import aspose.slides as slides

with slides.Presentation("destination.pptx") as destination:
    with slides.Presentation("source.pptx") as source:
        imported_section = destination.sections.append_empty_section("Imported slides")

        for slide in source.slides:
            destination.slides.add_clone(slide, imported_section)

        destination.save("merged-with-section.pptx", slides.export.SaveFormat.PPTX)
```

Las diapositivas clonadas se añaden al final de la sección de destino especificada. Para preservar varias secciones origen, recree esas secciones en el destino con [SectionCollection.append_empty_section](https://reference.aspose.com/slides/es/python-net/aspose.slides/sectioncollection/append_empty_section/) y asocie cada diapositiva origen con la sección de destino correspondiente.

## **Combinar varias presentaciones de forma segura**

El siguiente ejemplo completo utiliza la primera presentación como destino, normaliza el tamaño de diapositiva de cada origen adicional, mantiene cada origen abierto solo mientras se copia y guarda el archivo final una sola vez.

```python
import aspose.slides as slides

input_files = ["part1.pptx", "part2.pptx", "part3.pptx"]

with slides.Presentation(input_files[0]) as merged:
    for file_index in range(1, len(input_files)):
        with slides.Presentation(input_files[file_index]) as source:
            if (
                source.slide_size.size.width != merged.slide_size.size.width
                or source.slide_size.size.height != merged.slide_size.size.height
            ):
                source.slide_size.set_size(
                    merged.slide_size.size.width,
                    merged.slide_size.size.height,
                    slides.SlideSizeScaleType.ENSURE_FIT)

            for slide in source.slides:
                merged.slides.add_clone(slide)

    merged.save("merged.pptx", slides.export.SaveFormat.PPTX)
```

Esto constituye una base útil para preservar el formato de origen de las diapositivas importadas. Si su salida debe usar un solo tema de destino, reemplace la llamada simple `add_clone(slide)` por la sobrecarga de master o diseño de destino adecuada mostrada anteriormente.

## **Consideraciones prácticas**

### **Masters, diseños y fidelidad del formato**

La clonación predeterminada de diapositivas puede traer automáticamente un master de origen necesario a la presentación de destino. Aspose.Slides mantiene un registro interno de los masters clonados automáticamente para evitar clonar el mismo master repetidamente. Los masters clonados manualmente no son rastreados por ese registro, por lo que evite pre‑clonar masters a menos que necesite un control explícito sobre la estructura del master.

No asuma que dos masters o diseños con el mismo nombre son visualmente equivalentes. Si una plantilla corporativa debe controlar la apariencia final, elija explícitamente un master o diseño de destino y verifique el resultado después de combinar.

### **Notas y comentarios**

Las notas del orador y los comentarios de la diapositiva están asociados al contenido de la diapositiva y se copian cuando una diapositiva se clona. Aspose.Slides también expone API dedicadas para [presentation notes](https://docs.aspose.com/slides/es/python-net/presentation-notes/) y [presentation comments](https://docs.aspose.com/slides/es/python-net/presentation-comments/).

Si el formato de la página de notas es importante, verifique la presentación combinada porque los masters de notas son objetos a nivel de presentación y pueden diferir entre los archivos origen. Para flujos de revisión, también verifique los autores de los comentarios y los comentarios en hilos después de combinar archivos de diferentes autores o plantillas.

### **Imágenes, audio, video, objetos OLE y enlaces externos**

Las diapositivas pueden hacer referencia a recursos a nivel de presentación como imágenes, audio incrustado, video incrustado y datos OLE. Clone la propia diapositiva en lugar de copiar solo sus formas visibles para que Aspose.Slides pueda mantener las relaciones de la diapositiva con sus recursos.

Los recursos incrustados y enlazados deben tratarse de forma diferente. Un audio, video, objeto OLE o hipervínculo enlazado permanece dependiente de su objetivo externo; clonar una diapositiva no convierte un enlace externo en contenido incrustado. Pruebe las rutas y URL de recursos enlazados en el entorno donde se abrirá la presentación combinada.

Aspose.Slides rastrea explícitamente los masters clonados automáticamente, pero esto no debe considerarse una garantía general de que los recursos binarios idénticos de presentaciones origen no relacionadas siempre se deduplicarán. Si el tamaño del archivo de salida es importante, inspeccione el paquete combinado y mida el resultado en lugar de confiar en la deduplicación implícita.

### **Fuentes incrustadas y disponibilidad de fuentes**

Las fuentes se gestionan a nivel de presentación. Si la tipografía debe permanecer consistente entre máquinas, no asuma que clonar diapositivas por sí solo garantiza que todas las fuentes requeridas estén disponibles en el entorno de destino. Puede inspeccionar las fuentes incrustadas con [FontsManager.get_embedded_fonts](https://reference.aspose.com/slides/es/python-net/aspose.slides/fontsmanager/get_embedded_fonts/) y gestionar la incrustación explícitamente como se describe en [Embed Fonts in Presentations](https://docs.aspose.com/slides/es/python-net/embedded-font/).

También verifique que tenga permiso para incrustar las fuentes usadas por los archivos origen. Las licencias de fuentes pueden restringir la incrustación.

### **Presentaciones protegidas con contraseña**

Un origen protegido con contraseña debe abrirse correctamente antes de que sus diapositivas puedan clonarse. Proporcione la contraseña mediante [LoadOptions.password](https://reference.aspose.com/slides/es/python-net/aspose.slides/loadoptions/password/).

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "YOUR_PASSWORD"

with slides.Presentation("protected.pptx", load_options) as source:
    print(len(source.slides))
```

Abrir un origen cifrado no aplica automáticamente la misma protección a la presentación de destino. Configure la protección de salida por separado cuando sea necesario.

### **Presentaciones grandes y uso de memoria**

Las presentaciones grandes que contienen imágenes de alta resolución, audio, video u otros objetos binarios grandes pueden consumir una memoria significativa. [LoadOptions.blob_management_options](https://reference.aspose.com/slides/es/python-net/aspose.slides/loadoptions/blob_management_options/) ofrece controles para el manejo de BLOBs y el uso de archivos temporales. Consulte [Manage Presentation BLOBs](https://docs.aspose.com/slides/es/python-net/manage-blob/) para estrategias con archivos grandes.

Para archivos grandes, prefiera cargar desde rutas de archivo cuando sea posible, cierre cada presentación origen tan pronto como se haya combinado y evite guardar repetidamente resultados intermedios a menos que el flujo de trabajo requiera puntos de control. Usar `with slides.Presentation(...)` garantiza que los recursos de la presentación se liberen al salir del contexto.

### **Seguridad en hilos**

No cargue, guarde o clone una instancia de [Presentation](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/) simultáneamente desde varios hilos. Mantenga cada operación de combinación en un solo hilo. Si paraleliza trabajos de combinación independientes, use procesos separados de un solo hilo e instancias de presentación independientes como se describe en la [Aspose.Slides multithreading guidance](https://docs.aspose.com/slides/es/python-net/multithreading/).

## **Preguntas frecuentes**

**¿Cómo mantengo el diseño original de cada presentación origen?**

Utilice [`add_clone(source_slide)`](https://reference.aspose.com/slides/es/python-net/aspose.slides/slidecollection/add_clone/) sin proporcionar un master o diseño de destino. Aspose.Slides puede clonar automáticamente el master de origen cuando la diapositiva importada lo requiere.

**¿Cómo hago que las diapositivas importadas usen el tema de destino?**

Utilice la sobrecarga que acepta un master de destino. Pase un master de la presentación de destino, no del origen. Aspose.Slides intentará asignar cada diapositiva origen a un diseño apropiado bajo ese master.

**¿Cuándo debo usar un diseño de destino específico en lugar de un master de destino?**

Utilice un diseño específico cuando cada diapositiva importada deba usar un diseño conocido. Use un master cuando quiera que Aspose.Slides seleccione entre los diseños de ese master según el tipo o nombre del diseño de origen.

**¿Se pueden combinar presentaciones con diferentes tamaños de diapositiva?**

Sí, pero el contenido de la diapositiva no se rediseña automáticamente para las dimensiones de destino. Redimensione la presentación origen primero cuando necesite una colocación predecible, por ejemplo con [SlideSize.set_size](https://reference.aspose.com/slides/es/python-net/aspose.slides/slidesize/set_size/) y [SlideSizeScaleType.ENSURE_FIT](https://reference.aspose.com/slides/es/python-net/aspose.slides/slidesizescaletype/).

**¿Puedo combinar presentaciones PPT, PPTX y ODP en un solo archivo?**

Sí. Cargue cada presentación origen, clone las diapositivas necesarias en un destino y guarde el destino en un formato de salida compatible. Dado que los formatos de presentación no admiten exactamente el mismo conjunto de características, verifique el contenido complejo después de combinar entre formatos. Consulte [Supported File Formats](https://docs.aspose.com/slides/es/python-net/supported-file-formats/).

**¿Se conservan automáticamente las secciones de origen?**

No, con un bucle básico que solo clona diapositivas. Recree las secciones requeridas en el destino y use la sobrecarga de sección de [add_clone](https://reference.aspose.com/slides/es/python-net/aspose.slides/slidecollection/add_clone/) cuando la estructura de secciones debe preservarse.

**¿Se conservan las notas del orador y los comentarios?**

Se copian con la diapositiva clonada. Para flujos de trabajo que dependen del estilo del master de notas, de los autores de los comentarios o de datos de revisión en hilos, verifique el resultado combinado porque esos escenarios involucran estructuras a nivel de presentación así como contenido a nivel de diapositiva.

**¿Qué ocurre con el audio, video, objetos OLE y hipervínculos?**

El contenido incrustado se lleva como parte de las relaciones de recursos de la diapositiva clonada. Los enlaces externos permanecen externos, por lo que sus archivos o URL de destino deben seguir estando disponibles tras la combinación.

**¿Se garantiza que las fuentes incrustadas de cada origen estén disponibles en la presentación combinada?**

No confíe solo en la clonación de diapositivas para la distribución de fuentes. Inspeccione las fuentes incrustadas del destino y gestione explícitamente la incrustación de fuentes o la disponibilidad de fuentes externas cuando la tipografía sea importante.

**¿Cómo combinó un archivo protegido con contraseña?**

Ábralo con la [LoadOptions.password](https://reference.aspose.com/slides/es/python-net/aspose.slides/loadoptions/password/) correcta, luego clone sus diapositivas normalmente. La protección de salida se configura por separado.

**¿Cómo debo manejar presentaciones muy grandes?**

Utilice la gestión de BLOBs cuando los objetos binarios grandes dominen el uso de memoria, prefiera la carga desde rutas de archivo para archivos muy grandes, cierre rápidamente las presentaciones origen y guarde el resultado final solo cuando sea necesario.

**¿Puedo combinar diapositivas desde varios hilos?**

No cargue, guarde o clone instancias de [Presentation](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/) en varios hilos. Mantenga cada operación de combinación en un solo hilo; utilice procesos independientes de un solo hilo si necesita paralelizar trabajos de combinación separados.
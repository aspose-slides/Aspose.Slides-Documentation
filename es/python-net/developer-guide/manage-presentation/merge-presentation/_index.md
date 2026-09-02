---
title: Fusionar presentaciones de forma eficiente con Python
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
description: "Aprenda cómo fusionar presentaciones PowerPoint y OpenDocument en Python clonando diapositivas, controlando maestras y diseños, redimensionando el contenido de las diapositivas, preservando secciones y manejando archivos protegidos o grandes."
---
## **Visión general**

Aspose.Slides for Python a través de .NET combina presentaciones clonando diapositivas de una [Presentation](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/) a otra. La operación principal es [SlideCollection.add_clone](https://reference.aspose.com/slides/es/python-net/aspose.slides/slidecollection/add_clone/), que puede conservar el formato de la diapositiva origen o enlazar la diapositiva clonada a una diapositiva maestra o de diseño en la presentación de destino.

Este artículo cubre los flujos de trabajo de combinación más habituales:

- combinar todas las diapositivas conservando su formato original;  
- combinar diapositivas seleccionadas;  
- aplicar una maestra de la presentación de destino;  
- aplicar un diseño específico de la presentación de destino;  
- normalizar diferentes tamaños de diapositiva antes de combinar;  
- añadir diapositivas clonadas a una sección;  
- combinar varias presentaciones en un flujo de trabajo integral;  
- gestionar maestras, recursos, notas, comentarios, medios, fuentes, contraseñas, archivos grandes y problemas de multihilo.

## **Cómo afecta la clonación de diapositivas a maestras y diseños**

Una diapositiva hereda gran parte de su apariencia de su diseño y maestra. Por esa razón, la sobrecarga de clonación que elija determina cómo se integra la diapositiva combinada en la presentación de destino.

Utilice [SlideCollection.add_clone](https://reference.aspose.com/slides/es/python-net/aspose.slides/slidecollection/add_clone/) de una de estas formas:

- `add_clone(source_slide)` — conserva el diseño y formato de la diapositiva origen. Cuando sea necesario, la maestra origen puede clonarse automáticamente en la presentación de destino. Aspose.Slides rastrea las maestras clonadas automáticamente para que diapositivas repetidas que usan la misma maestra origen no provoquen una clonación repetida de esa maestra.  
- `add_clone(source_slide, destination_master, allow_clone_missing_layout)` — enlaza la diapositiva clonada a una [IMasterSlide](https://reference.aspose.com/slides/es/python-net/aspose.slides/imasterslide/) de destino específica. Aspose.Slides busca un diseño coincidente bajo esa maestra por tipo o nombre de diseño.  
- `add_clone(source_slide, destination_layout)` — enlaza la diapositiva clonada directamente a una [ILayoutSlide](https://reference.aspose.com/slides/es/python-net/aspose.slides/ilayoutslide/) de destino específica.

La maestra o el diseño pasados a una sobrecarga `add_clone` deben pertenecer a la **presentación de destino**, no a la presentación de origen.

## **Combinar presentaciones completas y conservar el formato origen**

La combinación más sencilla copia cada diapositiva de la presentación origen a la presentación de destino. Esta es la opción adecuada cuando las diapositivas importadas deben conservar su tema, maestra y relaciones de diseño originales.

```python
import aspose.slides as slides

with slides.Presentation("destination.pptx") as destination:
    with slides.Presentation("source.pptx") as source:
        for slide in source.slides:
            destination.slides.add_clone(slide)

        destination.save("merged.pptx", slides.export.SaveFormat.PPTX)
```

La presentación resultante puede contener varias maestras cuando el origen y el destino usan diseños diferentes. Esto es normal cuando se decide preservar intencionadamente el formato origen.

## **Combinar diapositivas seleccionadas**

No es necesario clonar todas las diapositivas. El siguiente ejemplo importa sólo los índices de diapositiva seleccionados de la presentación origen.

```python
import aspose.slides as slides

with slides.Presentation("destination.pptx") as destination:
    with slides.Presentation("source.pptx") as source:
        slide_indexes = [0, 2, 4]

        for index in slide_indexes:
            destination.slides.add_clone(source.slides[index])

        destination.save("merged-selected-slides.pptx", slides.export.SaveFormat.PPTX)
```

Valide los índices de diapositiva antes de clonarlos cuando provengan de la entrada del usuario o de una configuración externa.

## **Combinar diapositivas usando una maestra de destino**

Utilice la sobrecarga [add_clone(source_slide, destination_master, allow_clone_missing_layout)](https://reference.aspose.com/slides/es/python-net/aspose.slides/slidecollection/add_clone/) cuando las diapositivas importadas deban seguir una maestra que ya pertenece a la presentación de destino.

```python
import aspose.slides as slides

with slides.Presentation("destination.pptx") as destination:
    with slides.Presentation("source.pptx") as source:
        destination_master = destination.masters[0]

        for slide in source.slides:
            destination.slides.add_clone(slide, destination_master, True)

        destination.save("merged-with-destination-master.pptx", slides.export.SaveFormat.PPTX)
```

Aspose.Slides selecciona un diseño apropiado bajo la maestra especificada coincidiendo con el tipo o el nombre del diseño origen. Si no existe un diseño adecuado y `allow_clone_missing_layout` es `True`, el diseño origen se clona para que la diapositiva pueda añadirse. Si es `False`, se lanza una [PptxEditException](https://reference.aspose.com/slides/es/python-net/aspose.slides/pptxeditexception/).

Use `False` cuando desee que la combinación falle en lugar de introducir un diseño adicional en la maestra de destino.

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

Aplicar un diseño de destino cambia la relación de diseño heredada; no rediseña el contenido de la diapositiva origen. Si los diseños origen y destino tienen estructuras de marcadores de posición diferentes, inspeccione el resultado para confirmar que el formato heredado y el comportamiento de los marcadores son adecuados.

## **Combinar presentaciones con tamaños de diapositiva diferentes**

Las presentaciones con dimensiones de diapositiva distintas pueden combinarse, pero clonar una diapositiva en una presentación con otro tamaño de diapositiva no rediseña automáticamente su contenido para el nuevo lienzo. Las formas pueden aparecer desplazadas, escaladas inesperadamente o fuera del área visible de la diapositiva.

Un enfoque práctico es cambiar el tamaño de la presentación origen antes de clonar. El método [SlideSize.set_size](https://reference.aspose.com/slides/es/python-net/aspose.slides/slidesize/set_size/) puede escalar el contenido existente mientras se modifican las dimensiones de la diapositiva. [SlideSizeScaleType.ENSURE_FIT](https://reference.aspose.com/slides/es/python-net/aspose.slides/slidesizescaletype/) escala el contenido para que se ajuste al tamaño solicitado.

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

Redimensionar modifica el objeto de presentación origen en memoria. Si necesita que la presentación origen original permanezca sin cambios para otras operaciones, abra una instancia separada para la combinación.

## **Combinar diapositivas en una sección de presentación**

El bucle básico de clonación de diapositivas no recrea la jerarquía de secciones de la presentación origen. Si las secciones son relevantes en la salida, cree o seleccione secciones en la presentación de destino y clone las diapositivas en ellas explícitamente con [SlideCollection.add_clone](https://reference.aspose.com/slides/es/python-net/aspose.slides/slidecollection/add_clone/).

```python
import aspose.slides as slides

with slides.Presentation("destination.pptx") as destination:
    with slides.Presentation("source.pptx") as source:
        imported_section = destination.sections.append_empty_section("Imported slides")

        for slide in source.slides:
            destination.slides.add_clone(slide, imported_section)

        destination.save("merged-with-section.pptx", slides.export.SaveFormat.PPTX)
```

Las diapositivas clonadas se añaden al final de la sección de destino especificada. Para conservar varias secciones de origen, recorra [Presentation.sections](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/sections/), obtenga las diapositivas actuales de cada sección de origen con [Section.get_slides_list_of_section](https://reference.aspose.com/slides/es/python-net/aspose.slides/section/get_slides_list_of_section/), recree las secciones en el destino y clone cada diapositiva devuelta en su sección de destino correspondiente. Consulte [Manage Slide Sections](/slides/es/python-net/slide-section/) para un ejemplo completo de enumeración de secciones, incluidas secciones vacías y cambios estructurales.

## **Combinar varias presentaciones de forma segura**

El siguiente ejemplo integral usa la primera presentación como destino, normaliza el tamaño de diapositiva de cada origen adicional, mantiene cada origen abierto solo mientras se copia y guarda el archivo final una sola vez.

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

Este es un punto de partida útil para conservar el formato origen de las diapositivas importadas. Si su salida debe usar un único tema de destino, sustituya la llamada simple `add_clone(slide)` por la sobrecarga de maestra o diseño de destino adecuada mostrada anteriormente.

## **Consideraciones prácticas**

### **Maestras, diseños y fidelidad del formato**

La clonación predeterminada de diapositivas puede traer automáticamente una maestra origen requerida a la presentación de destino. Aspose.Slides mantiene un registro interno de maestras clonadas automáticamente para evitar clonar la misma maestra repetidamente. Las maestras clonadas manualmente no se registran en ese registro, por lo que debe evitar preclonar maestras a menos que necesite control explícito sobre la estructura de maestras.

No asuma que dos maestras o diseños con el mismo nombre sean visualmente equivalentes. Si una plantilla corporativa debe controlar la apariencia final, elija explícitamente una maestra o diseño de destino y verifique el resultado después de la combinación.

### **Notas y comentarios**

Las notas del orador y los comentarios de diapositiva están asociados al contenido de la diapositiva y se copian cuando una diapositiva se clona. Aspose.Slides también expone API dedicadas para [presentation notes](/slides/es/python-net/presentation-notes/) y [presentation comments](/slides/es/python-net/presentation-comments/).

Si el formato de la página de notas es importante, verifique la presentación combinada porque las maestras de notas son objetos a nivel de presentación y pueden diferir entre archivos origen. Para flujos de revisión, también verifique los autores de los comentarios y los hilos de comentarios después de combinar archivos de distintos autores o plantillas.

### **Imágenes, audio, vídeo, objetos OLE y enlaces externos**

Las diapositivas pueden referenciar recursos a nivel de presentación como imágenes, audio incrustado, vídeo incrustado y datos OLE. Clone la diapositiva completa en lugar de copiar solo sus formas visibles para que Aspose.Slides mantenga las relaciones de la diapositiva con sus recursos.

Los recursos incrustados y los vinculados deben tratarse de forma diferente. Un audio, vídeo, objeto OLE o hipervínculo vinculado sigue dependiendo de su destino externo; clonar una diapositiva no convierte un enlace externo en contenido incrustado. Pruebe las rutas y URL de los recursos vinculados en el entorno donde se abrirá la presentación combinada.

Aspose.Slides rastrea explícitamente las maestras clonadas automáticamente, pero no debe considerarse una garantía general de que recursos binarios idénticos de presentaciones origen no relacionadas se deduplicarán siempre. Si el tamaño del archivo de salida es importante, inspeccione el paquete combinado y mida el resultado en lugar de confiar en la deduplicación implícita.

### **Fuentes incrustadas y disponibilidad de fuentes**

Las fuentes se gestionan a nivel de presentación. Si la tipografía debe permanecer coherente entre máquinas, no asuma que clonar sólo diapositivas garantice que cada fuente requerida esté disponible en el entorno de destino. Puede inspeccionar las fuentes incrustadas con [FontsManager.get_embedded_fonts](https://reference.aspose.com/slides/es/python-net/aspose.slides/fontsmanager/get_embedded_fonts/) y gestionar la incrustación explícitamente como se describe en [Embed Fonts in Presentations](/slides/es/python-net/embedded-font/).

También verifique que tenga permiso para incrustar las fuentes usadas por los archivos origen. Las licencias de fuentes pueden restringir la incrustación.

### **Presentaciones protegidas con contraseña**

Una fuente protegida con contraseña debe abrirse correctamente antes de que sus diapositivas puedan clonarse. Proporcione la contraseña a través de [LoadOptions.password](https://reference.aspose.com/slides/es/python-net/aspose.slides/loadoptions/password/).

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "YOUR_PASSWORD"

with slides.Presentation("protected.pptx", load_options) as source:
    print(len(source.slides))
```

Abrir una fuente cifrada no aplica automáticamente la misma protección a la presentación de destino. Configure la protección de salida por separado cuando sea necesario.

### **Presentaciones grandes y uso de memoria**

Las presentaciones grandes que contienen imágenes de alta resolución, audio, vídeo u otros objetos binarios voluminosos pueden consumir mucha memoria. [LoadOptions.blob_management_options](https://reference.aspose.com/slides/es/python-net/aspose.slides/loadoptions/blob_management_options/) ofrece controles para la gestión de BLOB y el uso de archivos temporales. Consulte [Manage Presentation BLOBs](/slides/es/python-net/manage-blob/) para estrategias con archivos grandes.

Para archivos grandes, prefiera cargar desde rutas de archivo cuando sea posible, cierre cada presentación origen tan pronto como haya sido combinada y evite guardar resultados intermedios repetidamente a menos que el flujo requiera puntos de control. Usar `with slides.Presentation(...)` asegura que los recursos de la presentación se liberen al salir del contexto.

### **Seguridad en hilos**

No cargue, guarde ni clone una instancia de [Presentation](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/) concurrentemente desde varios hilos. Mantenga cada operación de combinación en un solo hilo. Si paraleliza trabajos de combinación independientes, use procesos independientes de un solo hilo e instancias de presentación independientes como se describe en la [guía de multihilo de Aspose.Slides](/slides/es/python-net/multithreading/).

## **Preguntas frecuentes**

**¿Cómo mantengo el diseño original de cada presentación origen?**

Utilice [add_clone](https://reference.aspose.com/slides/es/python-net/aspose.slides/slidecollection/add_clone/) sin proporcionar una maestra o diseño de destino. Aspose.Slides puede clonar automáticamente la maestra origen cuando la necesita la diapositiva importada.

**¿Cómo hago que las diapositivas importadas usen el tema de destino?**

Use la sobrecarga que acepta una maestra de destino. Pase una maestra de la presentación de destino, no de la origen. Aspose.Slides intentará asignar cada diapositiva origen a un diseño apropiado bajo esa maestra.

**¿Cuándo debo usar un diseño de destino específico en vez de una maestra de destino?**

Use un diseño específico cuando todas las diapositivas importadas deban usar un único diseño conocido. Use una maestra cuando quiera que Aspose.Slides seleccione entre los diseños de esa maestra según el tipo o nombre del diseño origen.

**¿Se pueden combinar presentaciones con tamaños de diapositiva diferentes?**

Sí, pero el contenido de la diapositiva no se rediseña automáticamente para las dimensiones de destino. Cambie el tamaño de la presentación origen primero cuando necesite una colocación predecible, por ejemplo con [SlideSize.set_size](https://reference.aspose.com/slides/es/python-net/aspose.slides/slidesize/set_size/) y [SlideSizeScaleType.ENSURE_FIT](https://reference.aspose.com/slides/es/python-net/aspose.slides/slidesizescaletype/).

**¿Puedo combinar presentaciones PPT, PPTX y ODP en un solo archivo?**

Sí. Cargue cada presentación origen, clone las diapositivas necesarias en una única presentación de destino y guarde el destino en un formato de salida compatible. Como los formatos de presentación no soportan exactamente el mismo conjunto de funciones, verifique el contenido complejo después de combinaciones entre formatos. Consulte [Supported File Formats](/slides/es/python-net/supported-file-formats/).

**¿Se conservan automáticamente las secciones del origen?**

No, con un bucle básico que sólo clona diapositivas. Recree las secciones necesarias en el destino y use la sobrecarga de sección de [add_clone](https://reference.aspose.com/slides/es/python-net/aspose.slides/slidecollection/add_clone/) cuando la estructura de secciones deba preservarse.

**¿Se conservan las notas del orador y los comentarios?**

Se copian con la diapositiva clonada. Para flujos que dependen del estilo del maestro de notas, de los autores de comentarios o de datos de revisión en hilos, verifique el resultado combinado porque esos escenarios también implican estructuras a nivel de presentación además del contenido de la diapositiva.

**¿Qué ocurre con audio, vídeo, objetos OLE y hipervínculos?**

El contenido incrustado se lleva como parte de las relaciones de recursos de la diapositiva clonada. Los enlaces externos siguen siendo externos, por lo que sus archivos o URL de destino deben seguir estando disponibles después de la combinación.

**¿Se garantiza que las fuentes incrustadas de cada origen estén disponibles en la presentación combinada?**

No confíe sólo en la clonación de diapositivas para la distribución de fuentes. Inspeccione las fuentes incrustadas del destino y gestione la incrustación de fuentes o la disponibilidad de fuentes externas explícitamente cuando la tipografía sea importante.

**¿Cómo combino un archivo protegido con contraseña?**

Ábralo con la [LoadOptions.password](https://reference.aspose.com/slides/es/python-net/aspose.slides/loadoptions/password/) correcta y luego clone sus diapositivas normalmente. La protección de salida se configura por separado.

**¿Cómo debo manejar presentaciones muy grandes?**

Use la gestión de BLOB cuando los objetos binarios grandes dominen el uso de memoria, prefiera la carga desde rutas de archivo para archivos muy grandes, cierre las presentaciones origen con prontitud y guarde el resultado final sólo cuando sea necesario.

**¿Puedo combinar diapositivas desde varios hilos?**

No cargue, guarde ni clone instancias de [Presentation](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/) en varios hilos. Mantenga cada operación de combinación en un solo hilo; use procesos independientes de un solo hilo si necesita paralelizar trabajos de combinación separados.
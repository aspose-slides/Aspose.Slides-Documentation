---
title: Operaciones de presentación low‑code en Python
linktitle: API low‑code
type: docs
weight: 50
url: /es/python-net/low-code-presentation-operations/
keywords:
- API de presentación low‑code
- convertir presentación
- combinar presentaciones
- recopilar formas
- comprimir presentación
- eliminar diapositivas maestras no usadas
- eliminar diapositivas de diseño no usadas
- comprimir fuentes incrustadas
- PowerPoint
- OpenDocument
- presentación
- Python
- Aspose.Slides
description: "Utilice la API low‑code de Aspose.Slides en Python para convertir y combinar presentaciones, recopilar formas y reducir el tamaño de la presentación."
---
## **Visión general**

El módulo [aspose.slides.lowcode](https://reference.aspose.com/slides/es/python-net/aspose.slides.lowcode/) proporciona clases auxiliares para operaciones habituales con presentaciones. Estas auxiliares envuelven flujos de trabajo del modelo de objetos frecuentemente usados en métodos específicos, para que pueda convertir o combinar archivos, recopilar formas y eliminar contenido no utilizado con menos código.

Los auxiliares low‑code son más útiles cuando la operación se aplica a un archivo o presentación completa y el flujo de trabajo predeterminado se ajusta a sus requisitos. Utilice el modelo de objetos completo de [Aspose.Slides object model](https://reference.aspose.com/slides/es/python-net/aspose.slides/) cuando necesite un control detallado sobre diapositivas individuales, maestros, diseños, formas, configuraciones de exportación o relaciones entre los elementos de la presentación.

La tabla siguiente resume los auxiliares disponibles:

| Auxiliar | Para qué se usa |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/es/python-net/aspose.slides.lowcode/convert/) | Convertir una presentación a otro formato con una llamada directa archivo‑a‑archivo. |
| [Merger](https://reference.aspose.com/slides/es/python-net/aspose.slides.lowcode/merger/) | Combinar archivos de presentación completos del mismo formato. |
| [Collect](https://reference.aspose.com/slides/es/python-net/aspose.slides.lowcode/collect/) | Obtener las formas de la presentación completa para procesamiento o análisis repetido. |
| [Compress](https://reference.aspose.com/slides/es/python-net/aspose.slides.lowcode/compress/) | Eliminar maestros y diseños no utilizados y reducir los datos de fuentes incrustadas. |

## **Convertir una presentación**

Utilice [Convert.auto_by_extension](https://reference.aspose.com/slides/es/python-net/aspose.slides.lowcode/convert/auto_by_extension/) cuando la extensión del archivo de salida sea suficiente para seleccionar el formato de exportación. El método abre la presentación de origen, determina el formato requerido a partir de la ruta de salida y escribe el resultado.

```python
import aspose.slides as slides

slides.lowcode.Convert.auto_by_extension("input.pptx", "output.pdf")
```

La clase [Convert](https://reference.aspose.com/slides/es/python-net/aspose.slides.lowcode/convert/) también ofrece métodos dedicados para salida en PDF, SVG, JPEG, PNG y TIFF. Utilice el modelo de objetos completo cuando necesite inspeccionar o modificar la presentación antes de la exportación o configurar una opción de exportación que no esté expuesta por el auxiliar seleccionado. Consulte [Convert Presentation](/slides/es/python-net/convert-presentation/) para flujos de trabajo y opciones específicas de cada formato.

## **Combinar presentaciones**

Utilice [Merger.process](https://reference.aspose.com/slides/es/python-net/aspose.slides.lowcode/merger/process/) para combinar archivos de presentación completos en una única llamada. Las presentaciones de entrada deben tener el mismo formato de archivo.

```python
import aspose.slides as slides

input_files = ["part-1.pptx", "part-2.pptx"]
slides.lowcode.Merger.process(input_files, "merged.pptx")
```

El auxiliar es apropiado cuando todas las diapositivas deben añadirse a un único resultado sin seleccionarlas o remapeándolas individualmente. Utilice el modelo de objetos completo cuando necesite combinar diapositivas seleccionadas, aplicar un maestro o diseño de destino, preservar secciones de forma explícita o reconciliar diferentes tamaños de diapositiva. Consulte [Merge Presentations](/slides/es/python-net/merge-presentation/) para esos escenarios.

## **Recopilar formas**

Utilice [Collect.shapes](https://reference.aspose.com/slides/es/python-net/aspose.slides.lowcode/collect/shapes/) cuando necesite una colección de todas las formas de una presentación. Esto es útil cuando el mismo conjunto será filtrado, contado o procesado más de una vez.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    shapes = slides.lowcode.Collect.shapes(presentation)

    for shape in shapes:
        print(f"{shape.name}: {type(shape).__name__}")
```

Utilice bucles de colección directos cuando el orden de recorrido, la salida anticipada, el filtrado previo al procesamiento o el control detallado de la jerarquía padre‑hijo sea importante.

## **Comprimir el contenido de la presentación**

La clase [Compress](https://reference.aspose.com/slides/es/python-net/aspose.slides.lowcode/compress/) puede eliminar elementos estructurales no utilizados y reducir los datos de fuentes incrustadas:

- [Compress.remove_unused_layout_slides](https://reference.aspose.com/slides/es/python-net/aspose.slides.lowcode/compress/remove_unused_layout_slides/) elimina diapositivas de diseño que no son referenciadas por ninguna diapositiva normal.
- [Compress.remove_unused_master_slides](https://reference.aspose.com/slides/es/python-net/aspose.slides.lowcode/compress/remove_unused_master_slides/) elimina diapositivas maestras que ya no se utilizan.
- [Compress.compress_embedded_fonts](https://reference.aspose.com/slides/es/python-net/aspose.slides.lowcode/compress/compress_embedded_fonts/) elimina caracteres no utilizados de las fuentes incrustadas.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slides.lowcode.Compress.remove_unused_layout_slides(presentation)
    slides.lowcode.Compress.remove_unused_master_slides(presentation)
    slides.lowcode.Compress.compress_embedded_fonts(presentation)

    presentation.save("compressed.pptx", slides.export.SaveFormat.PPTX)
```

Elimine los diseños no utilizados antes que los maestros no utilizados, de modo que un maestro que quede sin referencias tras la limpieza de diseños también pueda eliminarse. Guarde la presentación optimizada en un archivo nuevo si más tarde necesita los maestros, diseños originales o los datos completos de fuentes incrustadas. Para más detalles, consulte [Slide Master](/slides/es/python-net/slide-master/) y [Embedded Font](/slides/es/python-net/embedded-font/).

## **Preguntas frecuentes**

**¿Cuándo debo usar la API low‑code en lugar del modelo de objetos completo?**

Utilice los auxiliares low‑code cuando una operación estándar se aplique a un archivo o presentación completa y no requiera un control detallado sobre los elementos individuales. Utilice el modelo de objetos completo cuando necesite seleccionar diapositivas específicas, controlar las relaciones entre maestros y diseños, inspeccionar el estado intermedio o configurar un comportamiento que el auxiliar no expone.

**¿Puede Merger combinar presentaciones en diferentes formatos de archivo?**

No. [Merger.process](https://reference.aspose.com/slides/es/python-net/aspose.slides.lowcode/merger/process/) requiere que las presentaciones de entrada tengan el mismo formato. Convierta primero los archivos de entrada a un formato común, por ejemplo con [Convert.auto_by_extension](https://reference.aspose.com/slides/es/python-net/aspose.slides.lowcode/convert/auto_by_extension/), y luego combine los archivos convertidos.

**¿Qué incluye Collect.shapes?**

[Collect.shapes](https://reference.aspose.com/slides/es/python-net/aspose.slides.lowcode/collect/shapes/) recupera las formas de la presentación para que puedan retenerse, filtrarse, contarse o recorrerse varias veces. Utilice bucles de colección directos cuando necesite un control preciso sobre qué tipos de diapositiva o objetos anidados se visitan.

**¿Compress siempre reduce el tamaño del archivo de la presentación?**

No necesariamente. El resultado depende de si la presentación contiene diseños no utilizados, maestros no utilizados o fuentes incrustadas con caracteres sin usar. Si ninguno de estos está presente, las operaciones correspondientes de [Compress](https://reference.aspose.com/slides/es/python-net/aspose.slides.lowcode/compress/) pueden no reducir el tamaño del archivo.

**¿Los cambios realizados por Compress se guardan automáticamente?**

No. Estos auxiliares operan sobre el objeto [Presentation](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/) cargado en memoria. Después de ejecutar [Compress](https://reference.aspose.com/slides/es/python-net/aspose.slides.lowcode/compress/), llame a [Presentation.save](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/save/) para escribir el resultado.

## **Artículos relacionados**

- [Convert Presentation](/slides/es/python-net/convert-presentation/)
- [Merge Presentations](/slides/es/python-net/merge-presentation/)
- [Slide Master](/slides/es/python-net/slide-master/)
- [Manage Text Box](/slides/es/python-net/manage-textbox/)
- [Embedded Font](/slides/es/python-net/embedded-font/)
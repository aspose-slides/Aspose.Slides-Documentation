---
title: Operaciones de presentación de bajo código en Python
linktitle: API de bajo código
type: docs
weight: 50
url: /es/python-net/low-code-presentation-operations/
keywords:
- API de presentación de bajo código
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
description: "Utiliza la API de bajo código de Aspose.Slides en Python para convertir y combinar presentaciones, recopilar formas y reducir el tamaño de la presentación."
---
## **Visión general**

El módulo [aspose.slides.lowcode](https://reference.aspose.com/slides/es/python-net/aspose.slides.lowcode/) proporciona clases auxiliares para operaciones comunes con presentaciones. Estas utilidades envuelven flujos de trabajo frecuentemente usados del modelo de objetos en métodos concretos, de modo que puedes convertir o combinar archivos, recopilar formas y eliminar contenido no utilizado con menos código.

Los asistentes de bajo código son más útiles cuando la operación se aplica a todo el archivo o presentación y el flujo de trabajo predeterminado coincide con tus requisitos. Usa el modelo de objetos completo de [Aspose.Slides](https://reference.aspose.com/slides/es/python-net/aspose.slides/) cuando necesites control granular sobre diapositivas individuales, maestros, diseños, formas, configuraciones de exportación o relaciones entre elementos de la presentación.

La tabla siguiente resume los asistentes disponibles:

| Asistente | Uso |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/es/python-net/aspose.slides.lowcode/convert/) | Convertir una presentación a otro formato mediante una llamada directa de archivo a archivo. |
| [Merger](https://reference.aspose.com/slides/es/python-net/aspose.slides.lowcode/merger/) | Combinar archivos de presentación completos del mismo formato. |
| [Collect](https://reference.aspose.com/slides/es/python-net/aspose.slides.lowcode/collect/) | Recuperar formas de toda la presentación para procesamiento o análisis repetido. |
| [Compress](https://reference.aspose.com/slides/es/python-net/aspose.slides.lowcode/compress/) | Eliminar maestros y diseños no usados y reducir los datos de fuentes incrustadas. |

## **Convertir una presentación**

Utiliza [Convert.auto_by_extension](https://reference.aspose.com/slides/es/python-net/aspose.slides.lowcode/convert/auto_by_extension/) cuando la extensión del archivo de salida basta para seleccionar el formato de exportación. El método abre la presentación de origen, determina el formato requerido a partir de la ruta de salida y escribe el resultado.

```python
import aspose.slides as slides

slides.lowcode.Convert.auto_by_extension("input.pptx", "output.pdf")
```

La clase [Convert](https://reference.aspose.com/slides/es/python-net/aspose.slides.lowcode/convert/) también ofrece métodos dedicados para salida en PDF, SVG, JPEG, PNG y TIFF. Usa el modelo de objetos completo cuando necesites inspeccionar o modificar la presentación antes de la exportación o configurar una opción de exportación que no esté expuesta por el asistente seleccionado. Consulta [Convert Presentation](/python-net/convert-presentation/) para flujos de trabajo y opciones específicos de cada formato.

## **Combinar presentaciones**

Utiliza [Merger.process](https://reference.aspose.com/slides/es/python-net/aspose.slides.lowcode/merger/process/) para combinar archivos de presentación completos con una única llamada. Las presentaciones de entrada deben tener el mismo formato de archivo.

```python
import aspose.slides as slides

input_files = ["part-1.pptx", "part-2.pptx"]
slides.lowcode.Merger.process(input_files, "merged.pptx")
```

El asistente es apropiado cuando todas las diapositivas deben agregarse a un único resultado sin seleccionarlas o reasignarlas individualmente. Usa el modelo de objetos completo cuando necesites combinar diapositivas seleccionadas, aplicar un maestro o diseño de destino, preservar secciones explícitamente o reconciliar diferentes tamaños de diapositiva. Consulta [Merge Presentations](/python-net/merge-presentation/) para esos escenarios.

## **Recopilar formas**

Utiliza [Collect.shapes](https://reference.aspose.com/slides/es/python-net/aspose.slides.lowcode/collect/shapes/) cuando necesites una colección de todas las formas de una presentación. Esto es útil cuando el mismo conjunto será filtrado, contado o procesado más de una vez.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    shapes = slides.lowcode.Collect.shapes(presentation)

    for shape in shapes:
        print(f"{shape.name}: {type(shape).__name__}")
```

Emplea bucles de colección directos cuando el orden de recorrido, la salida anticipada, el filtrado antes del procesamiento o el control detallado padre‑hijo sean importantes.

## **Comprimir contenido de la presentación**

La clase [Compress](https://reference.aspose.com/slides/es/python-net/aspose.slides.lowcode/compress/) puede eliminar elementos estructurales no utilizados y reducir los datos de fuentes incrustadas:

- [Compress.remove_unused_layout_slides](https://reference.aspose.com/slides/es/python-net/aspose.slides.lowcode/compress/remove_unused_layout_slides/) elimina las diapositivas de diseño que ninguna diapositiva normal referencia.
- [Compress.remove_unused_master_slides](https://reference.aspose.com/slides/es/python-net/aspose.slides.lowcode/compress/remove_unused_master_slides/) elimina los maestros que ya no se usan.
- [Compress.compress_embedded_fonts](https://reference.aspose.com/slides/es/python-net/aspose.slides.lowcode/compress/compress_embedded_fonts/) elimina los caracteres no utilizados de las fuentes incrustadas.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slides.lowcode.Compress.remove_unused_layout_slides(presentation)
    slides.lowcode.Compress.remove_unused_master_slides(presentation)
    slides.lowcode.Compress.compress_embedded_fonts(presentation)

    presentation.save("compressed.pptx", slides.export.SaveFormat.PPTX)
```

Elimina primero los diseños no usados antes que los maestros no usados, de modo que un maestro que quede sin referencias tras la limpieza de diseños también pueda eliminarse. Guarda la presentación optimizada en un archivo nuevo si es posible que necesites más tarde los maestros, diseños o datos completos de fuentes incrustadas originales. Para más detalle, consulta [Slide Master](/python-net/slide-master/) y [Embedded Font](/python-net/embedded-font/).

## **Preguntas frecuentes**

**¿Cuándo debo usar la API de bajo código en lugar del modelo de objetos completo?**

Utiliza los asistentes de bajo código cuando una operación estándar se aplica a un archivo o presentación completa y no requiere control detallado sobre elementos individuales. Usa el modelo de objetos completo cuando necesites seleccionar diapositivas específicas, controlar relaciones entre maestros y diseños, inspeccionar el estado intermedio o configurar comportamientos que el asistente no expone.

**¿Puede Merger combinar presentaciones en diferentes formatos de archivo?**

No. [Merger.process](https://reference.aspose.com/slides/es/python-net/aspose.slides.lowcode/merger/process/) requiere que las presentaciones de entrada tengan el mismo formato. Convierte primero los archivos de entrada a un formato común, por ejemplo con [Convert.auto_by_extension](https://reference.aspose.com/slides/es/python-net/aspose.slides.lowcode/convert/auto_by_extension/), y luego combina los archivos convertidos.

**¿Qué incluye Collect.shapes?**

[Collect.shapes](https://reference.aspose.com/slides/es/python-net/aspose.slides.lowcode/collect/shapes/) recupera las formas de la presentación para que puedan mantenerse, filtrarse, contarse o recorrerse múltiples veces. Utiliza bucles de colección directos cuando necesites un control preciso sobre qué tipos de diapositivas u objetos anidados se visitan.

**¿Compress siempre reduce el tamaño del archivo de la presentación?**

No necesariamente. El resultado depende de si la presentación contiene diseños no usados, maestros no usados o fuentes incrustadas con caracteres no utilizados. Si ninguno de esos elementos está presente, las operaciones correspondientes de [Compress](https://reference.aspose.com/slides/es/python-net/aspose.slides.lowcode/compress/) pueden no reducir el tamaño del archivo.

**¿Los cambios realizados por Compress se guardan automáticamente?**

No. Estos asistentes operan sobre el objeto [Presentation](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/) cargado en memoria. Después de ejecutar [Compress](https://reference.aspose.com/slides/es/python-net/aspose.slides.lowcode/compress/), llama a [Presentation.save](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/save/) para escribir el resultado.

## **Artículos relacionados**

- [Convert Presentation](/python-net/convert-presentation/)
- [Merge Presentations](/python-net/merge-presentation/)
- [Slide Master](/python-net/slide-master/)
- [Manage Text Box](/python-net/manage-textbox/)
- [Embedded Font](/python-net/embedded-font/)
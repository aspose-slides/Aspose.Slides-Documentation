---
title: Operaciones de presentación de bajo código en Python vía Java
linktitle: API de bajo código
type: docs
weight: 50
url: /es/python-java/low-code-presentation-operations/
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
- Python
- Java
- Aspose.Slides
description: "Utiliza la API de bajo código de Aspose.Slides en Python vía Java para convertir y combinar presentaciones, recorrer su contenido, recopilar formas y reducir el tamaño de la presentación."
---
## **Descripción general**

La API [Aspose.Slides for Python via Java](https://reference.aspose.com/slides/es/python-java/aspose.slides/) proporciona clases auxiliares estáticas para operaciones comunes de presentaciones. Estas ayudas envuelven flujos de trabajo del modelo de objetos usados frecuentemente en métodos concretos, de modo que puedes convertir o combinar archivos, procesar elementos de la presentación, recopilar formas y eliminar contenido no utilizado con menos código.

Los ayudantes de bajo código son más útiles cuando la operación se aplica a todo un archivo o presentación y el flujo de trabajo predeterminado se ajusta a tus requisitos. Utiliza el modelo de objetos completo de [Aspose.Slides](https://reference.aspose.com/slides/es/python-java/aspose.slides/) cuando necesites un control fino sobre diapositivas individuales, maestros, diseños, formas, configuraciones de exportación o relaciones entre los elementos de la presentación.

La tabla siguiente resume los ayudantes disponibles:

| Ayuda | Uso |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/es/python-java/aspose.slides/convert/) | Convertir una presentación a otro formato mediante una llamada directa de archivo a archivo. |
| [Merger](https://reference.aspose.com/slides/es/python-java/aspose.slides/merger/) | Combinar archivos de presentación completos del mismo formato. |
| [ForEach](https://reference.aspose.com/slides/es/python-java/aspose.slides/foreach/) | Ejecutar una acción para cada diapositiva, forma, párrafo o porción de texto. |
| [Collect](https://reference.aspose.com/slides/es/python-java/aspose.slides/collect/) | Obtener formas de toda la presentación para procesamiento o análisis repetido. |
| [Compress](https://reference.aspose.com/slides/es/python-java/aspose.slides/compress/) | Eliminar maestros y diseños no utilizados y reducir los datos de fuentes incrustadas. |

## **Convertir una presentación**

Utiliza [Convert.autoByExtension](https://reference.aspose.com/slides/es/python-java/aspose.slides/convert/#autoByExtension) cuando la extensión del archivo de salida es suficiente para seleccionar el formato de exportación. El método abre la presentación fuente, determina el formato necesario a partir de la ruta de salida y escribe el resultado.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Convert

Convert.autoByExtension("input.pptx", "output.pdf")
```

La clase [Convert](https://reference.aspose.com/slides/es/python-java/aspose.slides/convert/) también proporciona métodos dedicados para salida PDF, SVG, JPEG, PNG y TIFF. Usa el modelo de objetos completo cuando necesites inspeccionar o modificar la presentación antes de exportar o configurar una opción de exportación que no esté expuesta por el ayudante seleccionado. Consulta [Convert Presentation](/slides/es/python-java/convert-presentation/) para flujos de trabajo y opciones específicas por formato.

## **Combinar presentaciones**

Utiliza [Merger.process](https://reference.aspose.com/slides/es/python-java/aspose.slides/merger/#process) para combinar archivos de presentación completos con una sola llamada. Las presentaciones de entrada deben tener el mismo formato de archivo.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Merger

input_files = jpype.JArray(jpype.JString)(["part-1.pptx", "part-2.pptx"])
Merger.process(input_files, "merged.pptx")
```

El ayudante es apropiado cuando todas las diapositivas deben agregarse a un único resultado sin seleccionarlas o remapearlas individualmente. Usa el modelo de objetos completo cuando necesites combinar diapositivas seleccionadas, aplicar un maestro o diseño de destino, preservar secciones explícitamente o conciliar diferentes tamaños de diapositiva. Consulta [Merge Presentations](/slides/es/python-java/merge-presentation/) para esos escenarios.

## **Iterar a través de los elementos de la presentación**

La clase [ForEach](https://reference.aspose.com/slides/es/python-java/aspose.slides/foreach/) invoca una devolución de llamada para cada tipo solicitado de elemento de la presentación. Evita bucles de colección anidados y resulta cómoda para inspecciones o cambios de formato a nivel de toda la presentación.

El siguiente ejemplo utiliza [ForEach.slide](https://reference.aspose.com/slides/es/python-java/aspose.slides/foreach/#slide), [ForEach.shape](https://reference.aspose.com/slides/es/python-java/aspose.slides/foreach/#shape), [ForEach.paragraph](https://reference.aspose.com/slides/es/python-java/aspose.slides/foreach/#paragraph) y [ForEach.portion](https://reference.aspose.com/slides/es/python-java/aspose.slides/foreach/#portion) para inspeccionar los elementos correspondientes:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ForEach, Presentation

def print_slide(slide, index):
    print(f"Slide {index}: {slide.getShapes().size()} shapes")

def print_shape(shape, slide, index):
    print(f"Shape {index} on {slide.getClass().getSimpleName()}: {shape.getName()}")

def print_paragraph(paragraph, slide, index):
    print(f"Paragraph {index} on {slide.getClass().getSimpleName()}: {paragraph.getText()}")

def print_portion(portion, paragraph, slide, index):
    print(f"Portion {index} on {slide.getClass().getSimpleName()}: {portion.getText()}")

presentation = Presentation("input.pptx")
try:
    ForEach.slide(presentation, print_slide)
    ForEach.shape(presentation, print_shape)
    ForEach.paragraph(presentation, print_paragraph)
    ForEach.portion(presentation, print_portion)
finally:
    presentation.dispose()
```

De forma predeterminada, la recorrida de formas y texto a nivel de presentación incluye diapositivas normales, maestras y de diseño. Las sobrecargas con un parámetro `includeNotes` también pueden procesar diapositivas de notas. Usa bucles de colección directos cuando el orden de recorrida, la salida anticipada, el filtrado antes de la llamada de retorno o el control detallado padre‑hijo sean importantes.

## **Recopilar formas**

Utiliza [Collect.shapes](https://reference.aspose.com/slides/es/python-java/aspose.slides/collect/#shapes) cuando necesites una colección de todas las formas de una presentación en lugar de una devolución de llamada para cada forma. Es útil cuando el mismo conjunto será filtrado, contado o procesado más de una vez.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Collect, Presentation

presentation = Presentation("input.pptx")
try:
    shapes = Collect.shapes(presentation)

    for shape in shapes:
        print(f"{shape.getName()}: {shape.getClass().getSimpleName()}")
finally:
    presentation.dispose()
```

Utiliza [ForEach.shape](https://reference.aspose.com/slides/es/python-java/aspose.slides/foreach/#shape) en su lugar cuando cada forma pueda manejarse inmediatamente y no necesites retener el resultado recopilado.

## **Comprimir contenido de la presentación**

La clase [Compress](https://reference.aspose.com/slides/es/python-java/aspose.slides/compress/) puede eliminar elementos estructurales no usados y reducir los datos de fuentes incrustadas:

- [removeUnusedLayoutSlides](https://reference.aspose.com/slides/es/python-java/aspose.slides/compress/#removeUnusedLayoutSlides) elimina diapositivas de diseño que no son referenciadas por ninguna diapositiva normal.
- [removeUnusedMasterSlides](https://reference.aspose.com/slides/es/python-java/aspose.slides/compress/#removeUnusedMasterSlides) elimina diapositivas maestras que ya no se utilizan.
- [compressEmbeddedFonts](https://reference.aspose.com/slides/es/python-java/aspose.slides/compress/#compressEmbeddedFonts) elimina caracteres no usados de las fuentes incrustadas.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Compress, Presentation, SaveFormat

presentation = Presentation("input.pptx")
try:
    Compress.removeUnusedLayoutSlides(presentation)
    Compress.removeUnusedMasterSlides(presentation)
    Compress.compressEmbeddedFonts(presentation)

    presentation.save("compressed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Elimina primero los diseños no usados antes que los maestros no usados, de modo que un maestro que quede sin referencias tras la limpieza de diseños también pueda eliminarse. Guarda la presentación optimizada en un nuevo archivo si puedes necesitar más tarde los maestros, diseños o los datos completos de fuentes incrustadas originales. Para más detalle, consulta [Slide Master](/slides/es/python-java/slide-master/) y [Embedded Font](/slides/es/python-java/embedded-font/).

## **Preguntas frecuentes**

**¿Cuándo debería usar la API de bajo código en lugar del modelo de objetos completo?**

Utiliza los ayudantes de bajo código cuando una operación estándar se aplique a un archivo o presentación completa y no requiera un control detallado sobre los elementos individuales. Emplea el modelo de objetos completo cuando necesites seleccionar diapositivas específicas, controlar relaciones de maestros y diseños, inspeccionar el estado intermedio o configurar un comportamiento que el ayudante no exponga.

**¿Puede Merger combinar presentaciones en diferentes formatos de archivo?**

No. [Merger.process](https://reference.aspose.com/slides/es/python-java/aspose.slides/merger/#process) exige que las presentaciones de entrada tengan el mismo formato. Convierte primero los archivos de entrada a un formato común, por ejemplo con [Convert.autoByExtension](https://reference.aspose.com/slides/es/python-java/aspose.slides/convert/#autoByExtension), y luego combina los archivos convertidos.

**¿Procesa ForEach diapositivas maestras, de diseño y de notas?**

[ForEach.slide](https://reference.aspose.com/slides/es/python-java/aspose.slides/foreach/#slide) recorre las diapositivas normales de la presentación. Las operaciones a nivel de presentación de [ForEach.shape](https://reference.aspose.com/slides/es/python-java/aspose.slides/foreach/#shape), [ForEach.paragraph](https://reference.aspose.com/slides/es/python-java/aspose.slides/foreach/#paragraph) y [ForEach.portion](https://reference.aspose.com/slides/es/python-java/aspose.slides/foreach/#portion) incluyen por defecto diapositivas normales, maestras y de diseño. Usa sus sobrecargas con `includeNotes` establecido en `True` para incluir también diapositivas de notas.

**¿Cuál es la diferencia entre ForEach.shape y Collect.shapes?**

Utiliza [ForEach.shape](https://reference.aspose.com/slides/es/python-java/aspose.slides/foreach/#shape) para procesar cada forma inmediatamente mediante una devolución de llamada. Utiliza [Collect.shapes](https://reference.aspose.com/slides/es/python-java/aspose.slides/collect/#shapes) cuando necesites un resultado iterable que pueda retenerse, filtrarse, contarse o recorrerse varias veces.

**¿Compress siempre reduce el tamaño del archivo de la presentación?**

No necesariamente. El resultado depende de si la presentación contiene diseños no usados, maestros no usados o fuentes incrustadas con caracteres no utilizados. Si ninguno de esos elementos está presente, las operaciones correspondientes de [Compress](https://reference.aspose.com/slides/es/python-java/aspose.slides/compress/) pueden no reducir el tamaño del archivo.

**¿Los cambios realizados por ForEach o Compress se guardan automáticamente?**

No. Estos ayudantes operan sobre el objeto [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/) cargado en memoria. Después de modificar elementos en una devolución de llamada de [ForEach](https://reference.aspose.com/slides/es/python-java/aspose.slides/foreach/) o ejecutar [Compress](https://reference.aspose.com/slides/es/python-java/aspose.slides/compress/), llama a [Presentation.save](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/#save) para escribir el resultado.

## **Artículos relacionados**

- [Convert Presentation](/slides/es/python-java/convert-presentation/)
- [Merge Presentations](/slides/es/python-java/merge-presentation/)
- [Slide Master](/slides/es/python-java/slide-master/)
- [Manage Text Box](/slides/es/python-java/manage-textbox/)
- [Embedded Font](/slides/es/python-java/embedded-font/)
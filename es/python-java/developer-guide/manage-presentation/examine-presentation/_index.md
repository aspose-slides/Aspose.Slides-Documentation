---
title: Recuperar y actualizar la información de la presentación en Python vía Java
linktitle: Información de la presentación
type: docs
weight: 30
url: /es/python-java/examine-presentation/
keywords:
- formato de presentación
- propiedades de la presentación
- propiedades del documento
- obtener propiedades
- leer propiedades
- cambiar propiedades
- modificar propiedades
- actualizar propiedades
- examinar PPTX
- examinar PPT
- examinar ODP
- PowerPoint
- OpenDocument
- presentación
- Python
- Java
- Aspose.Slides
description: "Explore diapositivas, estructura y metadatos en presentaciones PowerPoint y OpenDocument usando Python vía Java para obtener información más rápida y auditorías de contenido más inteligentes."
---
## **Visión general**

Aspose.Slides puede identificar el formato de una presentación y leer sus metadatos de documento sin crear un modelo de objetos de presentación completo. Esto es útil cuando necesita clasificar archivos, crear un inventario o inspeccionar propiedades antes de decidir si cargar y procesar el contenido de la presentación.

Los ejemplos requieren Aspose.Slides for Python via Java y un tiempo de ejecución Java compatible. Cada ejemplo inicia la JVM si no se está ejecutando. Proporcione archivos de presentación existentes en las rutas usadas en los ejemplos.

Este artículo muestra la inspección ligera a través de [PresentationFactory](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentationfactory/) y [PresentationInfo](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentationinfo/), así como actualizaciones dirigidas mediante [DocumentProperties](https://reference.aspose.com/slides/es/python-java/aspose.slides/documentproperties/).

## **Comprobar el formato de una presentación**

Utilice [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentationfactory/#getPresentationInfo) para inspeccionar un archivo sin crear una instancia de [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/). El método [PresentationInfo.getLoadFormat](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentationinfo/#getLoadFormat) informa el formato detectado, como PPTX, PPT u ODP.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadFormat, PresentationFactory

file_names = ["pres.pptx", "pres.ppt", "pres.odp"]

for file_name in file_names:
    presentation_info = PresentationFactory.getInstance().getPresentationInfo(file_name)
    load_format = presentation_info.getLoadFormat()
    format_name = f"Other ({load_format})"

    if load_format == LoadFormat.Pptx:
        format_name = "PPTX"
    elif load_format == LoadFormat.Ppt:
        format_name = "PPT"
    elif load_format == LoadFormat.Odp:
        format_name = "ODP"

    print(f"{file_name}: {format_name}")
```

## **Crear un inventario de presentaciones ligero**

Cuando procesa muchos archivos de presentación, puede necesitar un inventario compacto para validación, indexación o un sistema de gestión documental. En este escenario, utilice [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentationfactory/#getPresentationInfo) para obtener un objeto [PresentationInfo](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentationinfo/) y, a continuación, llame a [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentationinfo/#readDocumentProperties) para leer los metadatos del documento. Este enfoque no crea una instancia de [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/) ni requiere que recorra el modelo de objetos completo de la presentación.

Las propiedades extendidas expuestas por [DocumentProperties](https://reference.aspose.com/slides/es/python-java/aspose.slides/documentproperties/) proporcionan los siguientes valores de inventario:

| Método | Valor del inventario |
| --- | --- |
| [getSlides](https://reference.aspose.com/slides/es/python-java/aspose.slides/documentproperties/#getSlides) | Número total de diapositivas. |
| [getHiddenSlides](https://reference.aspose.com/slides/es/python-java/aspose.slides/documentproperties/#getHiddenSlides) | Número de diapositivas ocultas. |
| [getNotes](https://reference.aspose.com/slides/es/python-java/aspose.slides/documentproperties/#getNotes) | Número de diapositivas que contienen notas. |
| [getParagraphs](https://reference.aspose.com/slides/es/python-java/aspose.slides/documentproperties/#getParagraphs) | Número total de párrafos, cuando esté disponible. |
| [getWords](https://reference.aspose.com/slides/es/python-java/aspose.slides/documentproperties/#getWords) | Número total de palabras. |
| [getMultimediaClips](https://reference.aspose.com/slides/es/python-java/aspose.slides/documentproperties/#getMultimediaClips) | Número total de clips de audio y vídeo. |

El siguiente ejemplo lee estos valores sin crear un objeto [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/) y muestra un inventario compacto. También combina [getHeadingPairs](https://reference.aspose.com/slides/es/python-java/aspose.slides/documentproperties/#getHeadingPairs) con [getTitlesOfParts](https://reference.aspose.com/slides/es/python-java/aspose.slides/documentproperties/#getTitlesOfParts) para mostrar grupos de contenido como fuentes, temas y títulos de diapositivas.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import LoadFormat, PresentationFactory

file_path = "sample.pptx"
presentation_info = PresentationFactory.getInstance().getPresentationInfo(file_path)
document_properties = presentation_info.readDocumentProperties()

load_format = presentation_info.getLoadFormat()
format_name = f"Other ({load_format})"

if load_format == LoadFormat.Pptx:
    format_name = "PPTX"
elif load_format == LoadFormat.Ppt:
    format_name = "PPT"
elif load_format == LoadFormat.Odp:
    format_name = "ODP"

print(f"File: {Path(file_path).name}")
print(f"Format: {format_name}")
print(f"Title: {document_properties.getTitle()}")
print(f"Author: {document_properties.getAuthor()}")
print("Statistics:")
print(f"  Slides: {document_properties.getSlides()}")
print(f"  Hidden slides: {document_properties.getHiddenSlides()}")
print(f"  Slides with notes: {document_properties.getNotes()}")
print(f"  Paragraphs: {document_properties.getParagraphs()}")
print(f"  Words: {document_properties.getWords()}")
print(f"  Multimedia clips: {document_properties.getMultimediaClips()}")

heading_pairs = document_properties.getHeadingPairs()
titles_of_parts = document_properties.getTitlesOfParts()
heading_pairs = heading_pairs if heading_pairs is not None else []
titles_of_parts = titles_of_parts if titles_of_parts is not None else []
part_index = 0

if len(heading_pairs) == 0 or len(titles_of_parts) == 0:
    print("Content groups: not available")
else:
    print("Content groups:")

    for heading_pair in heading_pairs:
        print(f"  {heading_pair.getName()} ({heading_pair.getCount()})")

        for part_offset in range(heading_pair.getCount()):
            if part_index >= len(titles_of_parts):
                break
            print(f"    - {titles_of_parts[part_index]}")
            part_index += 1

    if part_index < len(titles_of_parts):
        print("  Other parts:")

        while part_index < len(titles_of_parts):
            print(f"    - {titles_of_parts[part_index]}")
            part_index += 1
```

Cada [HeadingPair](https://reference.aspose.com/slides/es/python-java/aspose.slides/headingpair/) proporciona un nombre de grupo y el número de elementos en ese grupo. [DocumentProperties.getTitlesOfParts](https://reference.aspose.com/slides/es/python-java/aspose.slides/documentproperties/#getTitlesOfParts) devuelve una matriz plana y ordenada, por lo que se deben consumir el número de títulos consecutivos especificados por cada pareja de encabezado.

### **Metadatos almacenados y limitaciones de formato**

Las propiedades de inventario devueltas por [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentationinfo/#readDocumentProperties) reflejan los metadatos disponibles en el documento fuente. Aspose.Slides no carga ni recorre el modelo de objetos de la presentación para recalcular estos valores para esta llamada. Las propiedades ausentes se representan con valores predeterminados, y los valores almacenados pueden estar obsoletos si la aplicación que guardó por última vez el archivo no actualizó sus propiedades de documento.

- **PPTX:** El formato proporciona propiedades de documento extendidas para recuentos de diapositivas, notas, diapositivas ocultas, párrafos, palabras y multimedia, así como parejas de encabezados y títulos de partes. La disponibilidad depende de qué propiedades fueron escritas por el productor del documento.
- **PPT:** El formato binario puede almacenar propiedades de resumen del documento correspondientes. Si una propiedad está ausente o no fue actualizada por el productor del documento, Aspose.Slides devuelve su valor almacenado o predeterminado en lugar de calcularlo a partir de las diapositivas.
- **ODP:** Los metadatos de OpenDocument proporcionan estadísticas generales del documento, como recuentos de páginas, párrafos y palabras, pero estos valores no se corresponden con todas las propiedades extendidas específicas de PowerPoint. Es posible que los metadatos de diapositivas ocultas, notas, multimedia, parejas de encabezados y títulos de partes no estén disponibles, y que las propiedades de inventario devuelvan valores predeterminados. No trate un valor cero o una matriz vacía como prueba absoluta de que el contenido correspondiente está ausente.

Utilice el enfoque de metadatos ligeros para inventarios y comprobaciones preliminares. Cargue la presentación e inspeccione su modelo de objetos en vivo cuando el resultado deba reflejar cambios en memoria o cuando necesite verificar el contenido real de la presentación.

## **Actualizar propiedades de la presentación**

Las propiedades devueltas por [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentationinfo/#readDocumentProperties) también pueden modificarse sin crear una instancia de [Presentation]. Aplique los cambios con [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentationinfo/#updateDocumentProperties) y luego escriba la presentación vinculada con [PresentationInfo.writeBindedPresentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentationinfo/#writeBindedPresentation).

La siguiente imagen muestra las propiedades del documento original.

![Propiedades originales del documento de la presentación PowerPoint](input_properties.png)

El siguiente ejemplo cambia el título y la hora de última guardado y escribe el resultado en un nuevo archivo:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PresentationFactory
from java.io import FileOutputStream
from java.util import Date

source_file = "sample.pptx"
output_file = "sample_with_updated_properties.pptx"
presentation_info = PresentationFactory.getInstance().getPresentationInfo(source_file)
document_properties = presentation_info.readDocumentProperties()

document_properties.setTitle("Quarterly sales report")
last_saved_time = Date()
document_properties.setLastSavedTime(last_saved_time)

presentation_info.updateDocumentProperties(document_properties)
output_stream = FileOutputStream(output_file)
try:
    presentation_info.writeBindedPresentation(output_stream)
finally:
    output_stream.close()
```

La siguiente imagen muestra las propiedades del documento modificadas de la presentación PowerPoint.

![Propiedades del documento modificadas de la presentación PowerPoint](output_properties.png)

## **Enlaces útiles**

Para comprobaciones de seguridad relacionadas y configuraciones de protección, consulte los siguientes artículos:

- [Presentaciones protegidas con contraseña](/slides/es/python-java/password-protected-presentation/)
- [Presentaciones protegidas contra escritura](/slides/es/python-java/write-protected-presentation/)

## **Preguntas frecuentes**

**¿Cómo puedo comprobar si las fuentes están incrustadas y cuáles son?**

Cargue la presentación y use [Presentation.getFontsManager](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/#getFontsManager). Llame a [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/es/python-java/aspose.slides/fontsmanager/#getEmbeddedFonts) para obtener las fuentes incrustadas y a [FontsManager.getFonts](https://reference.aspose.com/slides/es/python-java/aspose.slides/fontsmanager/#getFonts) para obtener las fuentes utilizadas por la presentación. Compare los dos resultados para encontrar fuentes que son necesarias para el renderizado pero que no están incrustadas.

**¿Cómo puedo saber rápidamente si el archivo tiene diapositivas ocultas y cuántas?**

Cuando los metadatos del documento almacenados son suficientes, lea [DocumentProperties.getHiddenSlides](https://reference.aspose.com/slides/es/python-java/aspose.slides/documentproperties/#getHiddenSlides) a través de [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentationfactory/#getPresentationInfo) y [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentationinfo/#readDocumentProperties). Esto es adecuado para un inventario ligero. Si la presentación se ha modificado en memoria, los metadatos almacenados pueden estar ausentes o desactualizados, o necesita verificar valores en vivo, itere a través de [Presentation.getSlides](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/#getSlides) e inspeccione el método [Slide.getHidden](https://reference.aspose.com/slides/es/python-java/aspose.slides/slide/#getHidden) de cada diapositiva en su lugar.

**¿Puedo detectar si se utiliza un tamaño y orientación de diapositiva personalizados, y si difieren de los valores predeterminados?**

Sí. Cargue la presentación y llame a [Presentation.getSlideSize](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/#getSlideSize). Use [SlideSize.getType](https://reference.aspose.com/slides/es/python-java/aspose.slides/slidesize/#getType), [SlideSize.getSize](https://reference.aspose.com/slides/es/python-java/aspose.slides/slidesize/#getSize) y [SlideSize.getOrientation](https://reference.aspose.com/slides/es/python-java/aspose.slides/slidesize/#getOrientation) para comparar la configuración actual con el preset y dimensiones esperados.

**¿Existe una forma rápida de ver si los gráficos referencian fuentes de datos externas?**

Sí. Ubique cada [Chart](https://reference.aspose.com/slides/es/python-java/aspose.slides/chart/) y llame a [ChartData.getDataSourceType](https://reference.aspose.com/slides/es/python-java/aspose.slides/chartdata/#getDataSourceType). Para un libro de trabajo externo, llame a [ChartData.getExternalWorkbookPath](https://reference.aspose.com/slides/es/python-java/aspose.slides/chartdata/#getExternalWorkbookPath). El tipo de fuente de datos y la ruta identifican una referencia externa, pero verificar si el objetivo está disponible requiere una comprobación de recursos separada.

**¿Cómo puedo evaluar las diapositivas 'pesadas' que pueden ralentizar el renderizado o la exportación a PDF?**

No existe una única propiedad de complejidad. Recorra [Presentation.getSlides](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/#getSlides) y la colección [BaseSlide.getShapes](https://reference.aspose.com/slides/es/python-java/aspose.slides/baseslide/#getShapes) de cada diapositiva. Use recuentos de formas y la presencia de imágenes grandes, efectos, animaciones o multimedia como señales de inspección, y mida un renderizado o exportación representativa antes de considerar una diapositiva como un cuello de botella de rendimiento confirmado.
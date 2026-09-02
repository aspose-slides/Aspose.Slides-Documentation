---
title: Recuperar y actualizar la información de la presentación en Python
linktitle: Información de la presentación
type: docs
weight: 30
url: /es/python-net/examine-presentation/
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
- Aspose.Slides
description: "Explore diapositivas, estructura y metadatos en presentaciones PowerPoint y OpenDocument usando Python para obtener información más rápida y auditorías de contenido más inteligentes."
---
## **Descripción general**

Aspose.Slides puede identificar el formato de una presentación y leer sus metadatos del documento sin crear un modelo de objeto de presentación completo. Esto es útil cuando necesita clasificar archivos, crear un inventario o inspeccionar propiedades antes de decidir si cargar y procesar el contenido de la presentación.

Este artículo muestra inspección ligera mediante [PresentationFactory](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentationfactory/) y [PresentationInfo](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentationinfo/), así como actualizaciones específicas mediante [DocumentProperties](https://reference.aspose.com/slides/es/python-net/aspose.slides/documentproperties/).

## **Comprobar el formato de una presentación**

Utilice [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentationfactory/get_presentation_info/) para inspeccionar un archivo sin crear una instancia de [Presentation](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/). La propiedad [PresentationInfo.load_format](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentationinfo/load_format/) informa del formato detectado, como PPTX, PPT o ODP.

```python
import aspose.slides as slides

file_names = ["pres.pptx", "pres.ppt", "pres.odp"]

for file_name in file_names:
    presentation_info = slides.PresentationFactory.instance.get_presentation_info(file_name)
    print(f"{file_name}: {presentation_info.load_format}")
```

## **Crear un inventario de presentaciones ligero**

Cuando procesa muchos archivos de presentación, puede necesitar un inventario compacto para validación, indexación o un sistema de gestión documental. En este caso, utilice [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentationfactory/get_presentation_info/) para obtener un objeto [PresentationInfo](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentationinfo/) y, a continuación, llame a [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentationinfo/read_document_properties/) para leer los metadatos del documento. Este método no crea una instancia de [Presentation](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/) ni requiere que recorra todo el modelo de objeto de la presentación.

Las propiedades extendidas expuestas por [DocumentProperties](https://reference.aspose.com/slides/es/python-net/aspose.slides/documentproperties/) proporcionan los siguientes valores de inventario:

| Propiedad | Valor de inventario |
| --- | --- |
| [slides](https://reference.aspose.com/slides/es/python-net/aspose.slides/documentproperties/slides/es/) | Número total de diapositivas. |
| [hidden_slides](https://reference.aspose.com/slides/es/python-net/aspose.slides/documentproperties/hidden_slides/) | Número de diapositivas ocultas. |
| [notes](https://reference.aspose.com/slides/es/python-net/aspose.slides/documentproperties/notes/) | Número de diapositivas que contienen notas. |
| [paragraphs](https://reference.aspose.com/slides/es/python-net/aspose.slides/documentproperties/paragraphs/) | Número total de párrafos, cuando estén disponibles. |
| [words](https://reference.aspose.com/slides/es/python-net/aspose.slides/documentproperties/words/) | Número total de palabras. |
| [multimedia_clips](https://reference.aspose.com/slides/es/python-net/aspose.slides/documentproperties/multimedia_clips/) | Número total de clips de audio y vídeo. |

El siguiente ejemplo lee estos valores sin crear un objeto [Presentation](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/) e imprime un inventario compacto. También combina [heading_pairs](https://reference.aspose.com/slides/es/python-net/aspose.slides/documentproperties/heading_pairs/) con [titles_of_parts](https://reference.aspose.com/slides/es/python-net/aspose.slides/documentproperties/titles_of_parts/) para mostrar grupos de contenido como fuentes, temas y títulos de diapositivas.

```python
import os
import aspose.slides as slides

file_path = "sample.pptx"
presentation_info = slides.PresentationFactory.instance.get_presentation_info(file_path)
document_properties = presentation_info.read_document_properties()

print(f"File: {os.path.basename(file_path)}")
print(f"Format: {presentation_info.load_format}")
print(f"Title: {document_properties.title}")
print(f"Author: {document_properties.author}")
print("Statistics:")
print(f"  Slides: {document_properties.slides}")
print(f"  Hidden slides: {document_properties.hidden_slides}")
print(f"  Slides with notes: {document_properties.notes}")
print(f"  Paragraphs: {document_properties.paragraphs}")
print(f"  Words: {document_properties.words}")
print(f"  Multimedia clips: {document_properties.multimedia_clips}")

heading_pairs = document_properties.heading_pairs or []
titles_of_parts = document_properties.titles_of_parts or []
part_index = 0

if not heading_pairs or not titles_of_parts:
    print("Content groups: not available")
else:
    print("Content groups:")

    for heading_pair in heading_pairs:
        print(f"  {heading_pair.name} ({heading_pair.count})")

        for _ in range(heading_pair.count):
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

Cada [HeadingPair](https://reference.aspose.com/slides/es/python-net/aspose.slides/headingpair/) suministra un nombre de grupo y el número de elementos en ese grupo. [DocumentProperties.titles_of_parts](https://reference.aspose.com/slides/es/python-net/aspose.slides/documentproperties/titles_of_parts/) es una colección plana y ordenada, por lo que se consumen el número de títulos consecutivos especificado por cada pareja de encabezado.

### **Metadatos almacenados y limitaciones de formato**

Las propiedades de inventario devueltas por [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentationinfo/read_document_properties/) reflejan los metadatos disponibles en el documento original. Aspose.Slides no carga ni recorre el modelo de objeto de la presentación para recalcular estos valores en esta llamada. Las propiedades ausentes se representan con valores predeterminados, y los valores almacenados pueden estar desactualizados si la aplicación que guardó por última vez el archivo no actualizó sus propiedades de documento.

- **PPTX:** El formato proporciona propiedades de documento extendidas para recuentos de diapositivas, notas, diapositivas ocultas, párrafos, palabras y contenido multimedia, así como parejas de encabezados y títulos de partes. La disponibilidad depende de qué propiedades fueron escritas por el creador del documento.
- **PPT:** El formato binario puede almacenar propiedades de resumen de documento correspondientes. Si una propiedad está ausente o no fue actualizada por el creador del documento, Aspose.Slides devuelve su valor almacenado o predeterminado en lugar de calcularlo a partir de las diapositivas.
- **ODP:** Los metadatos de OpenDocument proporcionan estadísticas generales del documento, como recuentos de páginas, párrafos y palabras, pero estos valores no se corresponden con todas las propiedades extendidas específicas de PowerPoint. Los metadatos de diapositivas ocultas, notas, contenido multimedia, parejas de encabezados y títulos de partes pueden no estar disponibles, y las propiedades de inventario pueden devolver valores predeterminados. No trate un valor cero o una colección vacía como prueba autoritativa de que el contenido correspondiente está ausente.

Utilice el enfoque de metadatos ligeros para inventarios y comprobaciones preliminares. Cargue la presentación e inspeccione su modelo de objeto en tiempo real cuando el resultado deba reflejar cambios en memoria o cuando necesite verificar el contenido real de la presentación.

## **Actualizar propiedades de la presentación**

Las propiedades devueltas por [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentationinfo/read_document_properties/) también pueden modificarse sin crear una instancia de [Presentation](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/). Aplique los cambios con [PresentationInfo.update_document_properties](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentationinfo/update_document_properties/) y, a continuación, escriba la presentación enlazada con [PresentationInfo.write_binded_presentation](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentationinfo/write_binded_presentation/).

La siguiente imagen muestra las propiedades del documento original.

![Propiedades del documento original de la presentación PowerPoint](input_properties.png)

El siguiente ejemplo cambia el título y la hora de la última guardada y escribe el resultado en un archivo nuevo:

```python
import datetime
import aspose.slides as slides

source_file = "sample.pptx"
output_file = "sample_with_updated_properties.pptx"
presentation_info = slides.PresentationFactory.instance.get_presentation_info(source_file)
document_properties = presentation_info.read_document_properties()

document_properties.title = "Quarterly sales report"
document_properties.last_saved_time = datetime.datetime.now(datetime.timezone.utc)

presentation_info.update_document_properties(document_properties)

with open(output_file, "wb") as output_stream:
    presentation_info.write_binded_presentation(output_stream)
```

La siguiente imagen muestra las propiedades del documento modificadas.

![Propiedades del documento modificadas de la presentación PowerPoint](output_properties.png)

## **Enlaces útiles**

- [Proteger presentaciones con contraseña](/slides/es/python-net/password-protected-presentation/)
- [Proteger presentaciones contra escritura](/slides/es/python-net/write-protected-presentation/)

## **Preguntas frecuentes**

**¿Cómo puedo comprobar si las fuentes están incrustadas y cuáles son?**

Cargue la presentación y utilice [Presentation.fonts_manager](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/fonts_manager/). Llame a [FontsManager.get_embedded_fonts](https://reference.aspose.com/slides/es/python-net/aspose.slides/fontsmanager/get_embedded_fonts/) para obtener las fuentes incrustadas y a [FontsManager.get_fonts](https://reference.aspose.com/slides/es/python-net/aspose.slides/fontsmanager/get_fonts/) para obtener las fuentes utilizadas por la presentación. Compare los dos resultados para encontrar fuentes que se requieren para la renderización pero que no están incrustadas.

**¿Cómo puedo saber rápidamente si el archivo tiene diapositivas ocultas y cuántas?**

Cuando los metadatos almacenados del documento son suficientes, lea [DocumentProperties.hidden_slides](https://reference.aspose.com/slides/es/python-net/aspose.slides/documentproperties/hidden_slides/) a través de [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentationfactory/get_presentation_info/) y [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentationinfo/read_document_properties/). Esto es adecuado para un inventario ligero. Si la presentación ha sido modificada en memoria, los metadatos almacenados pueden estar ausentes o desactualizados, o necesita verificar valores en tiempo real; recorra [Presentation.slides](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/slides/es/) e inspeccione la propiedad [Slide.hidden](https://reference.aspose.com/slides/es/python-net/aspose.slides/slide/hidden/) de cada diapositiva.

**¿Puedo detectar si se usa un tamaño y orientación de diapositiva personalizados, y si difieren de los valores predeterminados?**

Sí. Cargue la presentación y lea [Presentation.slide_size](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/slide_size/). Inspeccione [SlideSize.type](https://reference.aspose.com/slides/es/python-net/aspose.slides/slidesize/type/), [SlideSize.size](https://reference.aspose.com/slides/es/python-net/aspose.slides/slidesize/size/) y [SlideSize.orientation](https://reference.aspose.com/slides/es/python-net/aspose.slides/slidesize/orientation/) para comparar la configuración actual con el preset y dimensiones esperados.

**¿Hay una forma rápida de ver si los gráficos hacen referencia a fuentes de datos externas?**

Sí. Localice cada [Chart](https://reference.aspose.com/slides/es/python-net/aspose.slides.charts/chart/) e inspeccione [ChartData.data_source_type](https://reference.aspose.com/slides/es/python-net/aspose.slides.charts/chartdata/data_source_type/). Para un libro de trabajo externo, lea [ChartData.external_workbook_path](https://reference.aspose.com/slides/es/python-net/aspose.slides.charts/chartdata/external_workbook_path/). El tipo de fuente de datos y la ruta identifican una referencia externa, pero comprobar si el objetivo está disponible requiere una verificación de recursos adicional.

**¿Cómo puedo evaluar las diapositivas 'pesadas' que pueden ralentizar la renderización o la exportación a PDF?**

No existe una única propiedad de complejidad. Recorra [Presentation.slides](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/slides/es/) y la colección [BaseSlide.shapes](https://reference.aspose.com/slides/es/python-net/aspose.slides/baseslide/shapes/) de cada diapositiva. Utilice el recuento de formas y la presencia de imágenes grandes, efectos, animaciones o contenido multimedia como señales de filtrado, y mida una renderización o exportación representativa antes de considerar una diapositiva como un cuello de botella confirmado de rendimiento.
---
title: Gestionar etiquetas y datos personalizados en presentaciones con Python
linktitle: Etiquetas y datos personalizados
type: docs
weight: 300
url: /es/python-net/managing-tags-and-custom-data/
keywords:
- propiedades de documento
- etiqueta
- datos personalizados
- XML personalizado
- parte XML personalizada
- metadatos XML
- ItemId
- agregar etiqueta
- pares de valores
- PowerPoint
- presentación
- Python
- Aspose.Slides
description: "Aprenda a gestionar etiquetas y datos XML personalizados en presentaciones de PowerPoint con Aspose.Slides para Python a través de .NET, incluyendo la adición, lectura, actualización, auditoría y eliminación de partes XML personalizadas."
---
## **Descripción general**

Este artículo explica cómo funciona Aspose.Slides con etiquetas y datos personalizados en presentaciones de PowerPoint. Los datos específicos de una presentación pueden almacenarse como etiquetas o como partes XML personalizadas. Las etiquetas son pares simples de cadena clave‑valor, mientras que las partes XML personalizadas pueden almacenar metadatos estructurados y cargas XML específicas de la aplicación.

Aspose.Slides proporciona API para agregar, leer, actualizar, auditar y eliminar partes XML personalizadas a nivel de presentación, diapositiva y forma. Las partes XML personalizadas son útiles para integraciones que almacenan información como identificadores de gestión de documentos, estado de flujo de trabajo, metadatos de cumplimiento, datos de vinculación de plantillas u otros datos estructurados de la aplicación dentro de una presentación.

## **Almacenamiento de datos en archivos de presentación**

Los archivos PPTX —archivos con la extensión `.pptx`— se almacenan en el formato PresentationML, que forma parte de la especificación Office Open XML. Office Open XML define la estructura de paquetes y relaciones usadas para almacenar el contenido de la presentación y los datos relacionados.

Una presentación contiene varias partes conectadas mediante relaciones. Por ejemplo, una parte de diapositiva contiene el contenido de una sola diapositiva y puede tener relaciones explícitas con otras partes definidas por ISO/IEC 29500.

Los datos personalizados pueden almacenarse como etiquetas ([TagCollection](https://reference.aspose.com/slides/es/python-net/aspose.slides/tagcollection/)) o como partes XML personalizadas ([CustomXmlPartCollection](https://reference.aspose.com/slides/es/python-net/aspose.slides/customxmlpartcollection/)). Ambas están disponibles a través de la clase [`CustomData`](https://reference.aspose.com/slides/es/python-net/aspose.slides/customdata/).

{{% alert color="primary" %}}
Las etiquetas almacenan pares simples de cadena clave‑valor. Las partes XML personalizadas almacenan datos XML estructurados y pueden asociarse a una presentación, diapositiva o forma.
{{% /alert %}}

## **Trabajar con partes XML personalizadas**

La propiedad [`CustomData.custom_xml_parts`](https://reference.aspose.com/slides/es/python-net/aspose.slides/customdata/custom_xml_parts/) devuelve la colección de partes XML personalizadas asociadas a un objeto de presentación concreto. Por ejemplo:

- `presentation.custom_data.custom_xml_parts` contiene las partes XML personalizadas asociadas a la propia presentación.
- `slide.custom_data.custom_xml_parts` contiene las partes XML personalizadas asociadas a una diapositiva específica.
- `shape.custom_data.custom_xml_parts` contiene las partes XML personalizadas asociadas a una forma específica.

Utilice [`Presentation.all_custom_xml_parts`](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/all_custom_xml_parts/) cuando necesite inspeccionar todas las partes XML personalizadas de la presentación, independientemente de dónde estén asociadas.

### **Agregar una parte XML personalizada a una presentación**

Use [`CustomXmlPartCollection.add`](https://reference.aspose.com/slides/es/python-net/aspose.slides/customxmlpartcollection/add/) para añadir datos XML a una colección de partes XML personalizadas. El XML debe ser válido y no vacío.

El siguiente ejemplo agrega metadatos estructurados a la colección de datos personalizados a nivel de presentación:

```py
import uuid
import aspose.slides as slides

custom_xml_content = (
    '<?xml version="1.0" encoding="UTF-8"?>'
    '<metadata xmlns="urn:example:metadata">'
    '<documentId>DOC-1001</documentId>'
    '<workflowState>Draft</workflowState>'
    '</metadata>'
)

with slides.Presentation() as presentation:
    custom_xml_part = presentation.custom_data.custom_xml_parts.add(custom_xml_content)

    # add asigna un identificador automáticamente. Establezca un GUID específico solo cuando sea necesario.
    custom_xml_part.item_id = uuid.uuid4()

    presentation.save("presentation_with_custom_xml.pptx", slides.export.SaveFormat.PPTX)
```

El método `add` también puede aceptar XML como una matriz de bytes o flujo, lo que resulta útil cuando el contenido XML ya está disponible en forma binaria.

### **Agregar una parte XML personalizada a una diapositiva o forma**

Los datos XML personalizados pueden asociarse a una diapositiva o forma concreta en lugar de a toda la presentación. Esto es útil cuando los metadatos describen solo un objeto, como una clave de plantilla, un identificador de registro externo o información de vinculación.

El siguiente ejemplo agrega una parte XML personalizada a una diapositiva y otra a una forma:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    slide.custom_data.custom_xml_parts.add(
        '<slideMetadata xmlns="urn:example:slides">'
        '<templateKey>TitleSlide</templateKey>'
        '</slideMetadata>'
    )

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 250, 80)

    shape.text_frame.text = "Customer data"
    shape.custom_data.custom_xml_parts.add(
        '<shapeMetadata xmlns="urn:example:shapes">'
        '<recordId>CRM-4281</recordId>'
        '</shapeMetadata>'
    )

    presentation.save("object_custom_xml.pptx", slides.export.SaveFormat.PPTX)
```

El nivel en el que se agrega una parte determina cuál colección `custom_data.custom_xml_parts` del objeto contiene la relación con esa parte. Los datos a nivel de presentación son apropiados para metadatos de todo el documento, los datos a nivel de diapositiva para información que pertenece a una diapositiva concreta y los datos a nivel de forma para metadatos vinculados a una forma individual.

### **Enumerar y auditar todas las partes XML personalizadas**

Utilice [`Presentation.all_custom_xml_parts`](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/all_custom_xml_parts/) para obtener todas las partes XML personalizadas de una presentación. Cada [`CustomXmlPart`](https://reference.aspose.com/slides/es/python-net/aspose.slides/customxmlpart/) expone su identificador, contenido XML y los esquemas de espacio de nombres asociados.

El siguiente ejemplo enumera todas las partes XML personalizadas y sus esquemas de espacio de nombres:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for custom_xml_part in presentation.all_custom_xml_parts:
        print("ItemId: " + str(custom_xml_part.item_id))
        print("XML:")
        print(custom_xml_part.xml_as_string)

        for namespace_schema in custom_xml_part.namespace_schemas:
            print("Namespace schema: " + namespace_schema)

        print()
```

[`CustomXmlPart.namespace_schemas`](https://reference.aspose.com/slides/es/python-net/aspose.slides/customxmlpart/namespace_schemas/) devuelve los esquemas XML asociados a la parte XML personalizada. Esta información puede ser útil al auditar presentaciones que contienen XML generado por sistemas externos.

### **Leer y actualizar el contenido XML y ItemId**

Use [`CustomXmlPart.xml_as_string`](https://reference.aspose.com/slides/es/python-net/aspose.slides/customxmlpart/xml_as_string/) para trabajar con XML como cadena UTF‑8, o [`CustomXmlPart.xml_data`](https://reference.aspose.com/slides/es/python-net/aspose.slides/customxmlpart/xml_data/) para trabajar con los bytes XML sin procesar. Ambas propiedades pueden leerse y actualizarse.

La propiedad [`CustomXmlPart.item_id`](https://reference.aspose.com/slides/es/python-net/aspose.slides/customxmlpart/item_id/) contiene el GUID que identifica la parte XML personalizada en el documento Office Open XML. También puede modificarse cuando una integración requiere un nuevo identificador.

El siguiente ejemplo actualiza el contenido XML y el identificador:

```py
import uuid
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    custom_xml_part = presentation.all_custom_xml_parts[0]

    # Leer el XML actual como texto.
    current_xml_content = custom_xml_part.xml_as_string
    print(current_xml_content)

    # Actualizar el XML como una cadena UTF-8.
    custom_xml_part.xml_as_string = (
        '<metadata xmlns="urn:example:metadata">'
        '<documentId>DOC-1001</documentId>'
        '<workflowState>Approved</workflowState>'
        '</metadata>'
    )

    # xml_data proporciona el mismo contenido XML como bytes sin procesar.
    custom_xml_data = custom_xml_part.xml_data
    print(custom_xml_data.decode("utf-8"))

    # Reemplazar el identificador cuando lo requiera la integración.
    custom_xml_part.item_id = uuid.uuid4()

    presentation.save("updated_custom_xml.pptx", slides.export.SaveFormat.PPTX)
```

Al asignar `xml_as_string` o `xml_data`, proporcione XML válido y no vacío. Utilice una representación u otra según si la aplicación trabaja principalmente con cadenas o con datos binarios.

### **Eliminar una parte XML personalizada**

Aspose.Slides ofrece varias formas de eliminar datos XML personalizados:

- [`CustomXmlPart.remove`](https://reference.aspose.com/slides/es/python-net/aspose.slides/customxmlpart/remove/) elimina la parte XML personalizada de la presentación.
- [`CustomXmlPartCollection.remove`](https://reference.aspose.com/slides/es/python-net/aspose.slides/customxmlpartcollection/remove/) elimina una parte concreta de una colección de partes XML personalizadas.
- [`CustomXmlPartCollection.remove_at`](https://reference.aspose.com/slides/es/python-net/aspose.slides/customxmlpartcollection/remove_at/) elimina la parte en un índice de colección especificado.
- [`CustomXmlPartCollection.clear`](https://reference.aspose.com/slides/es/python-net/aspose.slides/customxmlpartcollection/clear/) elimina todas las partes de una colección concreta.

El siguiente ejemplo elimina una parte XML personalizada a nivel de presentación mediante referencia:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    custom_xml_parts = presentation.custom_data.custom_xml_parts

    if len(custom_xml_parts) > 0:
        custom_xml_part = custom_xml_parts[0]
        custom_xml_parts.remove(custom_xml_part)

    presentation.save("custom_xml_removed.pptx", slides.export.SaveFormat.PPTX)
```

Si ya dispone de un `CustomXmlPart` y desea eliminar esa parte de la presentación en lugar de dirigirse a una colección concreta, llame a `custom_xml_part.remove()`.

También puede eliminar un elemento por índice:

```py
presentation.custom_data.custom_xml_parts.remove_at(0)
```

### **Borrar todas las partes XML personalizadas de una colección**

Use `clear` cuando todas las partes XML personalizadas asociadas a un objeto de presentación concreto deban eliminarse.

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.slides[0].custom_data.custom_xml_parts.clear()

    presentation.save("slide_custom_xml_cleared.pptx", slides.export.SaveFormat.PPTX)
```

`clear` afecta solo a la colección seleccionada. Por ejemplo, limpiar la colección de una diapositiva no vacía las colecciones a nivel de presentación o de forma.

Para eliminar cada parte XML personalizada de la presentación, recorra `all_custom_xml_parts` y elimine cada parte:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for custom_xml_part in presentation.all_custom_xml_parts:
        custom_xml_part.remove()

    presentation.save("all_custom_xml_removed.pptx", slides.export.SaveFormat.PPTX)
```

### **Gestionar partes XML personalizadas vinculadas o compartidas**

En una presentación Office Open XML, la misma parte XML personalizada puede estar referenciada por más de un objeto de la presentación. Por ejemplo, un archivo existente puede contener relaciones desde varias diapositivas o formas a la misma parte XML subyacente.

Una parte compartida debe tratarse como un único objeto de datos con múltiples referencias:

- Actualizar su `xml_as_string`, `xml_data` o `item_id` modifica la parte XML subyacente, de modo que el cambio se aplica dondequiera que esa parte sea referenciada.
- `item_id` puede usarse para identificar la misma parte XML personalizada al auditar colecciones a nivel de objeto.
- Eliminar una parte de una colección `custom_xml_parts` concreta la elimina de esa colección. Use `CustomXmlPart.remove()` cuando la propia parte deba eliminarse de la presentación.
- Antes de eliminar o reemplazar una parte compartida, inspeccione las colecciones a nivel de objeto para determinar si otras diapositivas o formas siguen referenciándola.

Las sobrecargas de `add` crean una nueva parte XML personalizada a partir del contenido XML; no aceptan un `CustomXmlPart` existente. Por lo tanto, las relaciones compartidas se encuentran más frecuentemente al cargar presentaciones que ya las contienen.

El siguiente ejemplo audita colecciones a nivel de presentación, diapositiva y forma mediante `item_id` y muestra las partes referenciadas desde más de un lugar:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    references_by_item_id = {}

    def register_custom_xml_parts(owner_name, custom_xml_parts):
        for custom_xml_part in custom_xml_parts:
            references_by_item_id.setdefault(custom_xml_part.item_id, []).append(owner_name)

    register_custom_xml_parts("Presentation", presentation.custom_data.custom_xml_parts)

    for slide_index, slide in enumerate(presentation.slides):
        register_custom_xml_parts(
            "Slide " + str(slide_index + 1),
            slide.custom_data.custom_xml_parts
        )

        for shape_index, shape in enumerate(slide.shapes):
            register_custom_xml_parts(
                "Slide " + str(slide_index + 1) + ", shape " + str(shape_index),
                shape.custom_data.custom_xml_parts
            )

    for item_id, owner_names in references_by_item_id.items():
        if len(owner_names) > 1:
            print("Shared custom XML part: " + str(item_id))

            for owner_name in owner_names:
                print("  Referenced by: " + owner_name)
```

Este tipo de auditoría es útil antes de modificar o eliminar datos XML personalizados en presentaciones creadas por sistemas externos, ya que la misma parte de metadatos puede participar en más de una relación.

## **Obtener valores de etiquetas**

En Slides, una etiqueta corresponde a la propiedad `DocumentProperties.keywords`. Este fragmento de código muestra cómo obtener el valor de una etiqueta con Aspose.Slides para Python a través de .NET para [Presentation](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/):

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    keywords = presentation.document_properties.keywords
```

## **Agregar etiquetas a presentaciones**

Aspose.Slides permite agregar etiquetas a presentaciones. Una etiqueta suele constar de dos elementos:

- el nombre de una propiedad personalizada, por ejemplo, `MyTag`;
- el valor de la propiedad personalizada, por ejemplo, `My Tag Value`.

Si necesita clasificar presentaciones en función de una regla o propiedad específica, puede agregar etiquetas con ese fin. Por ejemplo, si desea categorizar presentaciones de países de América del Norte, puede crear una etiqueta norteamericana y asignar el país correspondiente como su valor.

Este fragmento de código muestra cómo agregar una etiqueta a una [Presentation](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/) usando Aspose.Slides para Python a través de .NET:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    tags = presentation.custom_data.tags
    tags.add("MyTag", "My Tag Value")
```

Las etiquetas también pueden establecerse para una [Slide](https://reference.aspose.com/slides/es/python-net/aspose.slides/slide/):

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    slide.custom_data.tags.add("tag", "value")
```

O para una [Shape](https://reference.aspose.com/slides/es/python-net/aspose.slides/shape/):

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 50)
    shape.text_frame.text = "My text"
    shape.custom_data.tags.add("tag", "value")
```

### **Limitaciones**

Las etiquetas añadidas mediante la colección `custom_data.tags` se guardan solo en el archivo PowerPoint. No se **transfieren** a la estructura de etiquetas PDF cuando la presentación se exporta a PDF. En consecuencia, un identificador personalizado asignado como etiqueta no puede recuperarse del PDF etiquetado.

**Solución alternativa**: puede almacenar un identificador personalizado en el **Texto alternativo** del objeto (por ejemplo, `shape.alternative_text = "MyId"`). Tras la exportación a PDF, el Texto alternativo puede aparecer en la estructura de etiquetas del PDF.

## **FAQ**

**¿Puedo eliminar todas las etiquetas de una presentación, diapositiva o forma en una única operación?**

Sí. La [colección de etiquetas](https://reference.aspose.com/slides/es/python-net/aspose.slides/tagcollection/) admite una operación [clear](https://reference.aspose.com/slides/es/python-net/aspose.slides/tagcollection/clear/) que elimina todos los pares clave‑valor a la vez.

**¿Cómo elimino una única etiqueta por su nombre sin iterar sobre toda la colección?**

Utilice [remove(name)](https://reference.aspose.com/slides/es/python-net/aspose.slides/tagcollection/remove/) en la [TagCollection](https://reference.aspose.com/slides/es/python-net/aspose.slides/tagcollection/) para eliminar la etiqueta por su clave.

**¿Cómo puedo obtener la lista completa de nombres de etiquetas para análisis o filtrado?**

Use [get_names_of_tags](https://reference.aspose.com/slides/es/python-net/aspose.slides/tagcollection/get_names_of_tags/) en la [colección de etiquetas](https://reference.aspose.com/slides/es/python-net/aspose.slides/tagcollection/); devuelve un array con todos los nombres de etiquetas.

**¿Cómo puedo encontrar todas las partes XML personalizadas sin importar dónde estén almacenadas?**

Use [`Presentation.all_custom_xml_parts`](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/all_custom_xml_parts/) para obtener todas las partes XML personalizadas en la presentación.

**¿Debo usar `xml_as_string` o `xml_data` para actualizar una parte XML personalizada?**

Use `xml_as_string` cuando la aplicación trabaje con texto XML UTF‑8. Use `xml_data` cuando el XML ya esté disponible como matriz de bytes o cuando el procesamiento orientado a binarios resulte más cómodo. Ambas propiedades representan el contenido XML de la misma parte XML personalizada.
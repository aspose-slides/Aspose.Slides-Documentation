---
title: Gestionar etiquetas y datos personalizados en presentaciones usando Python
linktitle: Etiquetas y datos personalizados
type: docs
weight: 300
url: /es/python-java/managing-tags-and-custom-data/
keywords:
- propiedades del documento
- etiqueta
- datos personalizados
- XML personalizado
- parte XML personalizada
- metadatos XML
- ItemId
- añadir etiqueta
- pares de valores
- PowerPoint
- presentación
- Python
- Aspose.Slides
description: "Aprenda a gestionar etiquetas y datos XML personalizados en presentaciones de PowerPoint con Aspose.Slides para Python a través de Java, incluyendo la adición, lectura, actualización, auditoría y eliminación de partes XML personalizadas."
---
## **Visión general**

Este artículo explica cómo Aspose.Slides trabaja con etiquetas y datos personalizados en presentaciones de PowerPoint. Los datos específicos de una presentación pueden almacenarse como etiquetas o como partes XML personalizadas. Las etiquetas son pares simples de cadena clave‑valor, mientras que las partes XML personalizadas pueden almacenar metadatos estructurados y cargas útiles XML específicas de la aplicación.

Aspose.Slides proporciona API para añadir, leer, actualizar, auditar y eliminar partes XML personalizadas a nivel de presentación, diapositiva y forma. Las partes XML personalizadas son útiles para integraciones que almacenan información como identificadores de gestión documental, estado del flujo de trabajo, metadatos de cumplimiento, datos de vinculación de plantillas u otros datos estructurados de la aplicación dentro de una presentación.

## **Almacenamiento de datos en archivos de presentación**

Los archivos PPTX —archivos con la extensión `.pptx`— se almacenan en el formato PresentationML, que forma parte de la especificación Office Open XML. Office Open XML define la estructura del paquete y las relaciones utilizadas para almacenar el contenido de la presentación y los datos relacionados.

Una presentación contiene varias partes conectadas mediante relaciones. Por ejemplo, una parte de diapositiva contiene el contenido de una única diapositiva y puede tener relaciones explícitas con otras partes definidas por ISO/IEC 29500.

Los datos personalizados pueden almacenarse como etiquetas ([TagCollection](https://reference.aspose.com/slides/es/python-java/aspose.slides/tagcollection/)) o como partes XML personalizadas ([CustomXmlPartCollection](https://reference.aspose.com/slides/es/python-java/aspose.slides/customxmlpartcollection/)). Ambas están disponibles a través de la clase [CustomData](https://reference.aspose.com/slides/es/python-java/aspose.slides/customdata/).

{{% alert color="info" title="Note" %}}
Las etiquetas almacenan pares simples de cadena clave‑valor. Las partes XML personalizadas almacenan datos XML estructurados y pueden asociarse a una presentación, diapositiva o forma.
{{% /alert %}}

## **Trabajar con partes XML personalizadas**

El método [CustomData.getCustomXmlParts](https://reference.aspose.com/slides/es/python-java/aspose.slides/customdata/#getCustomXmlParts) devuelve la colección de partes XML personalizadas asociadas a un objeto de presentación concreto. Por ejemplo:

- La colección [CustomData.getCustomXmlParts](https://reference.aspose.com/slides/es/python-java/aspose.slides/customdata/#getCustomXmlParts) de la presentación contiene partes XML personalizadas asociadas a la propia presentación.
- La colección [CustomData.getCustomXmlParts](https://reference.aspose.com/slides/es/python-java/aspose.slides/customdata/#getCustomXmlParts) de la diapositiva contiene partes XML personalizadas asociadas a una diapositiva concreta.
- La colección [CustomData.getCustomXmlParts](https://reference.aspose.com/slides/es/python-java/aspose.slides/customdata/#getCustomXmlParts) de la forma contiene partes XML personalizadas asociadas a una forma concreta.

Utilice [Presentation.getAllCustomXmlParts](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/#getAllCustomXmlParts) cuando necesite inspeccionar todas las partes XML personalizadas de la presentación, independientemente de dónde estén asociadas.

### **Añadir una parte XML personalizada a una presentación**

Utilice [CustomXmlPartCollection.add](https://reference.aspose.com/slides/es/python-java/aspose.slides/customxmlpartcollection/#add) para añadir datos XML a una colección de partes XML personalizadas. El XML debe ser válido y no estar vacío.

El siguiente ejemplo añade metadatos estructurados a la colección de datos personalizados a nivel de presentación:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat
from java.util import UUID

presentation = Presentation()
try:
    custom_xml_content = '<?xml version="1.0" encoding="UTF-8"?><metadata xmlns="urn:example:metadata"><documentId>DOC-1001</documentId><workflowState>Draft</workflowState></metadata>'
    custom_xml_part = presentation.getCustomData().getCustomXmlParts().add(custom_xml_content)

    # add asigna un identificador automáticamente. Establezca un UUID específico solo cuando sea necesario.
    item_id = UUID.randomUUID()
    custom_xml_part.setItemId(item_id)

    presentation.save("presentation_with_custom_xml.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

El método [add](https://reference.aspose.com/slides/es/python-java/aspose.slides/customxmlpartcollection/#add) también puede aceptar XML como array de bytes o flujo de entrada, lo que es útil cuando el contenido XML ya está disponible en forma binaria.

### **Añadir una parte XML personalizada a una diapositiva o forma**

Los datos XML personalizados pueden asociarse a una diapositiva o forma concreta en lugar de a toda la presentación. Esto resulta útil cuando los metadatos describen solo un objeto, como una clave de plantilla, un identificador de registro externo o información de vinculación.

El siguiente ejemplo añade una parte XML personalizada a una diapositiva y otra a una forma:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    slide_xml_content = '<slideMetadata xmlns="urn:example:slides"><templateKey>TitleSlide</templateKey></slideMetadata>'
    slide.getCustomData().getCustomXmlParts().add(slide_xml_content)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 250, 80)
    shape.getTextFrame().setText("Customer data")
    shape_xml_content = '<shapeMetadata xmlns="urn:example:shapes"><recordId>CRM-4281</recordId></shapeMetadata>'
    shape.getCustomData().getCustomXmlParts().add(shape_xml_content)

    presentation.save("object_custom_xml.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

El nivel en el que se añade una parte determina a qué colección [CustomData.getCustomXmlParts](https://reference.aspose.com/slides/es/python-java/aspose.slides/customdata/#getCustomXmlParts) pertenece la relación. Los datos a nivel de presentación son apropiados para metadatos de todo el documento, los datos a nivel de diapositiva para información que pertenece a una diapositiva concreta y los datos a nivel de forma para metadatos vinculados a una forma individual.

### **Enumerar y auditar todas las partes XML personalizadas**

Utilice [Presentation.getAllCustomXmlParts](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/#getAllCustomXmlParts) para recuperar todas las partes XML personalizadas de una presentación. Cada [CustomXmlPart](https://reference.aspose.com/slides/es/python-java/aspose.slides/customxmlpart/) expone su identificador, el contenido XML y los esquemas de espacio de nombres asociados.

El siguiente ejemplo enumera todas las partes XML personalizadas y sus esquemas de espacio de nombres:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    for custom_xml_part in presentation.getAllCustomXmlParts():
        print("ItemId:", custom_xml_part.getItemId())
        print("XML:")
        print(custom_xml_part.getXmlAsString())

        for namespace_schema in custom_xml_part.getNamespaceSchemas():
            print("Namespace schema:", namespace_schema)

        print()
finally:
    presentation.dispose()
```

[CustomXmlPart.getNamespaceSchemas](https://reference.aspose.com/slides/es/python-java/aspose.slides/customxmlpart/#getNamespaceSchemas) devuelve los esquemas XML asociados a la parte XML personalizada. Esta información puede ser útil al auditar presentaciones que contengan XML generado por sistemas externos.

### **Leer y actualizar el contenido XML y el ItemId**

Utilice [CustomXmlPart.getXmlAsString](https://reference.aspose.com/slides/es/python-java/aspose.slides/customxmlpart/#getXmlAsString) y [setXmlAsString](https://reference.aspose.com/slides/es/python-java/aspose.slides/customxmlpart/#setXmlAsString) para trabajar con XML como cadena UTF‑8, o [getXmlData](https://reference.aspose.com/slides/es/python-java/aspose.slides/customxmlpart/#getXmlData) y [setXmlData](https://reference.aspose.com/slides/es/python-java/aspose.slides/customxmlpart/#setXmlData) para trabajar con los bytes XML sin procesar.

El método [CustomXmlPart.getItemId](https://reference.aspose.com/slides/es/python-java/aspose.slides/customxmlpart/#getItemId) devuelve el UUID que identifica la parte XML personalizada en el documento Office Open XML. Utilice [setItemId](https://reference.aspose.com/slides/es/python-java/aspose.slides/customxmlpart/#setItemId) cuando una integración requiera un nuevo identificador.

El siguiente ejemplo actualiza el contenido XML y el identificador:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat
from java.util import UUID

presentation = Presentation("presentation.pptx")
try:
    custom_xml_parts = presentation.getAllCustomXmlParts()
    if len(custom_xml_parts) > 0:
        custom_xml_part = custom_xml_parts[0]

        # Leer el XML actual como texto.
        current_xml_content = custom_xml_part.getXmlAsString()
        print(current_xml_content)

        # Actualizar el XML como cadena UTF-8.
        custom_xml_content = '<metadata xmlns="urn:example:metadata"><documentId>DOC-1001</documentId><workflowState>Approved</workflowState></metadata>'
        custom_xml_part.setXmlAsString(custom_xml_content)

        # getXmlData proporciona el mismo contenido XML como bytes sin procesar.
        custom_xml_data = custom_xml_part.getXmlData()
        print(bytes(custom_xml_data).decode("utf-8"))

        # Reemplazar el identificador cuando lo requiera la integración.
        item_id = UUID.randomUUID()
        custom_xml_part.setItemId(item_id)

        presentation.save("updated_custom_xml.pptx", SaveFormat.Pptx)
    else:
        print("No custom XML parts found.")
finally:
    presentation.dispose()
```

Al llamar a [setXmlAsString](https://reference.aspose.com/slides/es/python-java/aspose.slides/customxmlpart/#setXmlAsString) o [setXmlData](https://reference.aspose.com/slides/es/python-java/aspose.slides/customxmlpart/#setXmlData), proporcione XML válido y no vacío. Use una representación u otra según si la aplicación trabaja principalmente con cadenas o con datos binarios.

### **Eliminar una parte XML personalizada**

Aspose.Slides ofrece varias formas de eliminar datos XML personalizados:

- [CustomXmlPart.remove](https://reference.aspose.com/slides/es/python-java/aspose.slides/customxmlpart/#remove) elimina la parte XML personalizada de la presentación.
- [CustomXmlPartCollection.remove](https://reference.aspose.com/slides/es/python-java/aspose.slides/customxmlpartcollection/#remove) elimina una parte específica de una colección de partes XML personalizadas.
- [CustomXmlPartCollection.removeAt](https://reference.aspose.com/slides/es/python-java/aspose.slides/customxmlpartcollection/#removeAt) elimina la parte en un índice de colección especificado.
- [CustomXmlPartCollection.clear](https://reference.aspose.com/slides/es/python-java/aspose.slides/customxmlpartcollection/#clear) elimina todas las partes de una colección concreta.

El siguiente ejemplo elimina una parte XML personalizada a nivel de presentación mediante referencia:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    custom_xml_parts = presentation.getCustomData().getCustomXmlParts()
    if custom_xml_parts.size() > 0:
        custom_xml_part = custom_xml_parts.get_Item(0)
        custom_xml_parts.remove(custom_xml_part)

    presentation.save("custom_xml_removed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Si ya dispone de un [CustomXmlPart](https://reference.aspose.com/slides/es/python-java/aspose.slides/customxmlpart/) y desea eliminar esa parte de la presentación en lugar de dirigirse a una colección concreta, llame a [CustomXmlPart.remove](https://reference.aspose.com/slides/es/python-java/aspose.slides/customxmlpart/#remove).

También puede eliminar un elemento por índice:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    custom_xml_parts = presentation.getCustomData().getCustomXmlParts()
    if custom_xml_parts.size() > 0:
        custom_xml_parts.removeAt(0)
finally:
    presentation.dispose()
```

### **Borrar todas las partes XML personalizadas de una colección**

Utilice [clear](https://reference.aspose.com/slides/es/python-java/aspose.slides/customxmlpartcollection/#clear) cuando todas las partes XML personalizadas asociadas a un objeto de presentación concreto deban eliminarse.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    presentation.getSlides().get_Item(0).getCustomData().getCustomXmlParts().clear()

    presentation.save("slide_custom_xml_cleared.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

[clear](https://reference.aspose.com/slides/es/python-java/aspose.slides/customxmlpartcollection/#clear) afecta solo a la colección seleccionada. Por ejemplo, vaciar la colección de una diapositiva no borra las colecciones a nivel de presentación o de forma.

Para eliminar cada parte XML personalizada de la presentación, recorra [getAllCustomXmlParts](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/#getAllCustomXmlParts) y elimine cada una:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    for custom_xml_part in presentation.getAllCustomXmlParts():
        custom_xml_part.remove()

    presentation.save("all_custom_xml_removed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Gestionar partes XML personalizadas enlazadas o compartidas**

En una presentación Office Open XML, la misma parte XML personalizada puede estar referenciada por más de un objeto de presentación. Por ejemplo, un archivo existente puede contener relaciones de varias diapositivas o formas con la misma parte XML subyacente.

Una parte compartida debe tratarse como un único objeto de datos con varias referencias:

- Actualizarla con [setXmlAsString](https://reference.aspose.com/slides/es/python-java/aspose.slides/customxmlpart/#setXmlAsString), [setXmlData](https://reference.aspose.com/slides/es/python-java/aspose.slides/customxmlpart/#setXmlData) o [setItemId](https://reference.aspose.com/slides/es/python-java/aspose.slides/customxmlpart/#setItemId) modifica la parte XML subyacente, por lo que el cambio se aplica donde sea que esa parte esté referenciada.
- [getItemId](https://reference.aspose.com/slides/es/python-java/aspose.slides/customxmlpart/#getItemId) puede usarse para identificar la misma parte XML personalizada al auditar colecciones a nivel de objeto.
- Eliminar una parte de una colección específica [getCustomXmlParts](https://reference.aspose.com/slides/es/python-java/aspose.slides/customdata/#getCustomXmlParts) la elimina solo de esa colección. Use [CustomXmlPart.remove](https://reference.aspose.com/slides/es/python-java/aspose.slides/customxmlpart/#remove) cuando la propia parte deba eliminarse de la presentación.
- Antes de borrar o reemplazar una parte compartida, inspeccione las colecciones a nivel de objeto para determinar si otras diapositivas o formas aún la referencian.

Las sobrecargas de [add](https://reference.aspose.com/slides/es/python-java/aspose.slides/customxmlpartcollection/#add) crean una nueva parte XML personalizada a partir del contenido XML; no aceptan un [CustomXmlPart](https://reference.aspose.com/slides/es/python-java/aspose.slides/customxmlpart/) existente. Por ello, las relaciones compartidas se encuentran con mayor frecuencia al cargar presentaciones que ya las contienen.

El siguiente ejemplo audita colecciones a nivel de presentación, diapositiva y forma por `ItemId` y muestra las partes referenciadas desde más de un lugar:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    references_by_item_id = {}

    def register_custom_xml_parts(owner_name, custom_xml_parts):
        for i in range(custom_xml_parts.size()):
            custom_xml_part = custom_xml_parts.get_Item(i)
            item_id = str(custom_xml_part.getItemId())
            references_by_item_id.setdefault(item_id, []).append(owner_name)

    register_custom_xml_parts("Presentation", presentation.getCustomData().getCustomXmlParts())

    for slide_index in range(presentation.getSlides().size()):
        slide = presentation.getSlides().get_Item(slide_index)
        register_custom_xml_parts(f"Slide {slide_index + 1}", slide.getCustomData().getCustomXmlParts())

        for shape_index in range(slide.getShapes().size()):
            shape = slide.getShapes().get_Item(shape_index)
            register_custom_xml_parts(f"Slide {slide_index + 1}, shape {shape_index}", shape.getCustomData().getCustomXmlParts())

    for item_id, owner_names in references_by_item_id.items():
        if len(owner_names) > 1:
            print("Shared custom XML part:", item_id)
            for owner_name in owner_names:
                print("  Referenced by:", owner_name)
finally:
    presentation.dispose()
```

Este tipo de auditoría es útil antes de modificar o eliminar datos XML personalizados en presentaciones creadas por sistemas externos, ya que la misma parte de metadatos puede participar en más de una relación.

## **Obtener valores de etiquetas**

En Slides, una etiqueta corresponde al método [DocumentProperties.getKeywords](https://reference.aspose.com/slides/es/python-java/aspose.slides/documentproperties/#getKeywords). Este fragmento de código muestra cómo obtener el valor de una etiqueta con Aspose.Slides para Python a través de Java para [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    keywords = presentation.getDocumentProperties().getKeywords()
finally:
    presentation.dispose()
```

## **Añadir etiquetas a presentaciones**

Aspose.Slides permite añadir etiquetas a presentaciones. Una etiqueta suele constar de dos elementos:

- el nombre de una propiedad personalizada, por ejemplo, `MyTag`;
- el valor de la propiedad personalizada, por ejemplo, `My Tag Value`.

Si necesita clasificar presentaciones según una regla o propiedad concreta, puede añadir etiquetas con ese fin. Por ejemplo, si desea categorizar presentaciones de países de Norteamérica, puede crear una etiqueta “NorthAmerican” y asignar el país correspondiente como su valor.

Este fragmento de código muestra cómo añadir una etiqueta a una [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/) usando Aspose.Slides para Python a través de Java:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    tags = presentation.getCustomData().getTags()
    tags.set_Item("MyTag", "My Tag Value")
finally:
    presentation.dispose()
```

También pueden establecerse etiquetas para una [Slide](https://reference.aspose.com/slides/es/python-java/aspose.slides/slide/):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    slide.getCustomData().getTags().set_Item("tag", "value")
finally:
    presentation.dispose()
```

O para una [Shape](https://reference.aspose.com/slides/es/python-java/aspose.slides/shape/) individual:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 50)
    shape.getTextFrame().setText("My text")
    shape.getCustomData().getTags().set_Item("tag", "value")
finally:
    presentation.dispose()
```

### **Limitaciones**

Las etiquetas añadidas mediante la colección [CustomData.getTags](https://reference.aspose.com/slides/es/python-java/aspose.slides/customdata/#getTags) se almacenan solo en el archivo de PowerPoint. **No** se transfieren a la estructura de etiquetas PDF cuando la presentación se exporta a PDF. En consecuencia, un identificador personalizado asignado como etiqueta no puede recuperarse del PDF etiquetado.

**Solución alternativa**: Puede almacenar un identificador personalizado en el **Texto alternativo** del objeto (por ejemplo, [Shape.setAlternativeText](https://reference.aspose.com/slides/es/python-java/aspose.slides/shape/#setAlternativeText) con el valor `"MyId"`). Tras la exportación a PDF, el Texto alternativo puede aparecer en la estructura de etiquetas del PDF.

## **Preguntas frecuentes**

**¿Puedo eliminar todas las etiquetas de una presentación, diapositiva o forma en una sola operación?**

Sí. La [tag collection](https://reference.aspose.com/slides/es/python-java/aspose.slides/tagcollection/) admite una operación [clear](https://reference.aspose.com/slides/es/python-java/aspose.slides/tagcollection/#clear) que borra todos los pares clave‑valor a la vez.

**¿Cómo elimino una única etiqueta por su nombre sin iterar sobre toda la colección?**

Utilice [remove](https://reference.aspose.com/slides/es/python-java/aspose.slides/tagcollection/#remove) en la [tag collection](https://reference.aspose.com/slides/es/python-java/aspose.slides/tagcollection/) para borrar la etiqueta por su clave.

**¿Cómo puedo obtener la lista completa de nombres de etiquetas para análisis o filtrado?**

Utilice [getNamesOfTags](https://reference.aspose.com/slides/es/python-java/aspose.slides/tagcollection/#getNamesOfTags) en la [tag collection](https://reference.aspose.com/slides/es/python-java/aspose.slides/tagcollection/); devuelve una matriz con todos los nombres de etiquetas.

**¿Cómo puedo encontrar todas las partes XML personalizadas sin importar dónde estén almacenadas?**

Use [Presentation.getAllCustomXmlParts](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/#getAllCustomXmlParts) para obtener todas las partes XML personalizadas de la presentación.

**¿Debo usar [getXmlAsString](https://reference.aspose.com/slides/es/python-java/aspose.slides/customxmlpart/#getXmlAsString)/[setXmlAsString](https://reference.aspose.com/slides/es/python-java/aspose.slides/customxmlpart/#setXmlAsString) o [getXmlData](https://reference.aspose.com/slides/es/python-java/aspose.slides/customxmlpart/#getXmlData)/[setXmlData](https://reference.aspose.com/slides/es/python-java/aspose.slides/customxmlpart/#setXmlData) para actualizar una parte XML personalizada?**

Use [getXmlAsString](https://reference.aspose.com/slides/es/python-java/aspose.slides/customxmlpart/#getXmlAsString) y [setXmlAsString](https://reference.aspose.com/slides/es/python-java/aspose.slides/customxmlpart/#setXmlAsString) cuando la aplicación trabaje con texto XML UTF‑8. Use [getXmlData](https://reference.aspose.com/slides/es/python-java/aspose.slides/customxmlpart/#getXmlData) y [setXmlData](https://reference.aspose.com/slides/es/python-java/aspose.slides/customxmlpart/#setXmlData) cuando el XML ya esté disponible como array de bytes o cuando el procesamiento binario resulte más conveniente. Ambas representaciones se refieren al contenido XML de la misma parte XML personalizada.
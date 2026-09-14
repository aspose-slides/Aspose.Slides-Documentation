---
title: Gestionar propiedades de la presentación en Python
linktitle: Propiedades de la presentación
type: docs
weight: 70
url: /es/python-java/presentation-properties/
keywords:
- propiedades de PowerPoint
- propiedades de la presentación
- propiedades del documento
- propiedades integradas
- propiedades personalizadas
- propiedades avanzadas
- gestionar propiedades
- modificar propiedades
- metadatos del documento
- editar metadatos
- idioma de corrección
- idioma predeterminado
- PowerPoint
- OpenDocument
- presentación
- Python
- Aspose.Slides
description: "Domina las propiedades de la presentación en Aspose.Slides for Python via Java y optimiza la búsqueda, la marca y el flujo de trabajo en tus archivos PowerPoint y OpenDocument."
---
## **Introducción**

Aspose.Slides admite dos tipos de propiedades de documento: **Integradas** y **Personalizadas**. Ambos tipos de propiedades se pueden acceder y gestionar fácilmente mediante la API de Aspose.Slides.

Aspose.Slides le permite trabajar con las propiedades de los documentos de presentación a través de la clase [DocumentProperties](https://reference.aspose.com/slides/es/python-java/aspose.slides/documentproperties/). Una instancia de esta clase se devuelve mediante [Presentation.getDocumentProperties](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/#getDocumentProperties). Los ejemplos siguientes muestran cómo leer, modificar y gestionar estas propiedades.

{{% alert color="info" title="Note" %}}
Tenga en cuenta que los campos **Application** y **AppVersion** no pueden modificarse. Aspose.Slides los vuelve a escribir en cada guardado, de modo que una presentación guardada siempre indica "Aspose.Slides for Java" y la versión de la biblioteca que la generó. Cualquier valor pasado a [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/es/python-java/aspose.slides/documentproperties/#setNameOfApplication) se descarta cuando la presentación se escribe.
{{% /alert %}}

## **Propiedades del documento en PowerPoint**

Microsoft PowerPoint 2007 le permite gestionar las propiedades del documento de los archivos de presentación. Haga clic en el icono de Office y seleccione **Prepare | Properties | Advanced Properties**, como se muestra a continuación:

|**Seleccionar el elemento del menú Propiedades avanzadas**|
| :- |
|![PowerPoint document properties](https://i.imgur.com/ZrmuCD6.jpg)|

Después de seleccionar **Advanced Properties**, aparece un cuadro de diálogo donde puede gestionar las propiedades del documento del archivo PowerPoint:

|**Cuadro de diálogo Propiedades**|
| :- |
|![PowerPoint document properties](https://i.imgur.com/LibmdQd.jpg)|

El **Cuadro de diálogo Propiedades** contiene pestañas como **General**, **Summary**, **Statistics**, **Contents** y **Custom**. Estas pestañas le permiten configurar diferentes tipos de información sobre los archivos PowerPoint. Utilice la pestaña **Custom** para gestionar propiedades personalizadas.

## **Trabajar con propiedades de documento usando Aspose.Slides for Python via Java**

Como se describió anteriormente, Aspose.Slides for Python via Java admite tanto propiedades **Integradas** como **Personalizadas**. La clase [DocumentProperties](https://reference.aspose.com/slides/es/python-java/aspose.slides/documentproperties/) representa las propiedades del documento asociadas a un archivo de presentación.

Utilice [Presentation.getDocumentProperties](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/#getDocumentProperties) para acceder a estas propiedades como se describe a continuación.

## **Leer propiedades públicas de una presentación cifrada**

Una contraseña de apertura normalmente protege tanto el contenido de la presentación como las propiedades del documento. Cuando una presentación se cifra pasando `false` a [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/es/python-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties), sus propiedades del documento permanecen públicas. Entonces una aplicación puede pasar `true` a [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/es/python-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) y leer los metadatos públicos sin proporcionar la contraseña de apertura.

La opción *only‑load‑document‑properties* controla lo que Aspose.Slides carga; no descifra nada. Si las propiedades estaban incluidas en el cifrado, cargar‑las sin la contraseña falla. Si la presentación no está cifrada, la opción se ignora y se carga la presentación completa.

El siguiente ejemplo verifica el modo de carga mediante [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/es/python-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) y a continuación lee las propiedades integradas mediante [Presentation.getDocumentProperties](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/#getDocumentProperties):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, LoadOptions

load_options = LoadOptions()
load_options.setOnlyLoadDocumentProperties(True)

presentation = Presentation("public-properties-encrypted.pptx", load_options)
try:
    if presentation.getProtectionManager().isOnlyDocumentPropertiesLoaded():
        properties = presentation.getDocumentProperties()

        print("Author: ", properties.getAuthor())
        print("Title: ", properties.getTitle())
        print("Keywords: ", properties.getKeywords())
    else:
        print("The presentation was not loaded in document-properties-only mode.")

finally:
    presentation.dispose()
```

En este modo, el contenido de las diapositivas no se carga. Diapositivas, maestros, diseños, formas, medios y otros objetos de la presentación no están disponibles. Las aplicaciones deben comprobar siempre [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/es/python-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) antes de realizar una operación que requiera el modelo de objetos completo de la presentación.

{{% alert color="warning" title="Warning" %}}
Los metadatos públicos pueden exponer nombres de autores, títulos, temas, palabras clave, información de la empresa, comentarios y valores personalizados. Cifre las propiedades sensibles junto con la presentación. Déjelas públicas solo cuando los sistemas de indexación, clasificación, búsqueda o gestión documental tengan un requisito específico para acceder a ellas sin contraseña.
{{% /alert %}}

## **Actualizar propiedades de una presentación cifrada**

Para un archivo PPTX cifrado, una presentación cargada en modo *only‑document‑properties* está destinada a leer metadatos públicos. Aspose.Slides no puede guardar los cambios de propiedades de ese objeto solo de metadatos porque las propiedades públicas deben seguir siendo coherentes con los datos correspondientes dentro de la presentación cifrada. Por lo tanto, actualizarlas requiere la contraseña de apertura correcta y una carga completa.

El siguiente ejemplo abre la presentación con [LoadOptions.setPassword](https://reference.aspose.com/slides/es/python-java/aspose.slides/loadoptions/#setPassword), actualiza las propiedades integradas públicas y guarda el resultado. A continuación, utiliza [PresentationInfo.isEncrypted](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentationinfo/#isEncrypted) para comprobar que el cifrado se conserva y vuelve a abrir los metadatos públicos sin contraseña para verificar los nuevos valores:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, LoadOptions, PresentationFactory, SaveFormat

input_path = "public-properties-encrypted.pptx"
output_path = "updated-public-properties-encrypted.pptx"

load_options = LoadOptions()
load_options.setPassword("open_password")

presentation = Presentation(input_path, load_options)
try:
    presentation.getDocumentProperties().setTitle("Updated Product Roadmap")
    presentation.getDocumentProperties().setKeywords("roadmap, planning, indexed")
    presentation.save(output_path, SaveFormat.Pptx)
finally:
    presentation.dispose()

presentation_info = PresentationFactory.getInstance().getPresentationInfo(output_path)
print("The presentation is encrypted: ", presentation_info.isEncrypted())

metadata_load_options = LoadOptions()
metadata_load_options.setOnlyLoadDocumentProperties(True)

metadata_presentation = Presentation(output_path, metadata_load_options)
try:
    if metadata_presentation.getProtectionManager().isOnlyDocumentPropertiesLoaded():
        print("Title: ", metadata_presentation.getDocumentProperties().getTitle())
        print("Keywords: ", metadata_presentation.getDocumentProperties().getKeywords())
    else:
        print("The presentation was not loaded in document-properties-only mode.")

finally:
    metadata_presentation.dispose()
```

Si una aplicación no está autorizada a descifrar o cargar el contenido de la presentación, debe tratar las propiedades públicas de un archivo PPTX cifrado como de solo lectura.

## **Acceder a propiedades integradas**

Las propiedades integradas que expone [DocumentProperties](https://reference.aspose.com/slides/es/python-java/aspose.slides/documentproperties/) incluyen: **Creator** (Autor), **Description**, **Created** (Fecha de creación), **Modified** (Fecha de modificación), **Printed** (Fecha del último impresión), **LastModifiedBy**, **Keywords**, **SharedDoc** (¿Compartido entre distintos productores?), **PresentationFormat**, **Subject** y **Title**.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, DocumentProperties

# Instanciar la clase Presentation que representa la presentación
presentation = Presentation("Presentation.pptx")
try:
    # Crear una referencia al objeto DocumentProperties asociado a la presentación
    properties = presentation.getDocumentProperties()

    # Mostrar las propiedades integradas
    print("Category : ", properties.getCategory())
    print("Current Status : ", properties.getContentStatus())
    print("Creation Date : ", properties.getCreatedTime())
    print("Author : ", properties.getAuthor())
    print("Description : ", properties.getComments())
    print("KeyWords : ", properties.getKeywords())
    print("Last Modified By : ", properties.getLastSavedBy())
    print("Supervisor : ", properties.getManager())
    print("Modified Date : ", properties.getLastSavedTime())
    print("Presentation Format : ", properties.getPresentationFormat())
    print("Last Print Date : ", properties.getLastPrinted())
    print("Is Shared between producers : ", properties.getSharedDoc())
    print("Subject : ", properties.getSubject())
    print("Title : ", properties.getTitle())
finally:
    presentation.dispose()
```

## **Modificar propiedades integradas**

Modificar propiedades integradas es tan sencillo como acceder a ellas. Utilice el *setter* correspondiente para asignar un nuevo valor. El siguiente ejemplo modifica las propiedades de documento integradas mediante Aspose.Slides for Python via Java.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, DocumentProperties

presentation = Presentation("Presentation.pptx")
try:
    # Crear una referencia al objeto DocumentProperties asociado a la presentación
    properties = presentation.getDocumentProperties()

    # Establecer las propiedades integradas
    properties.setAuthor("Aspose.Slides for Python via Java")
    properties.setTitle("Modifying Presentation Properties")
    properties.setSubject("Aspose Subject")
    properties.setComments("Aspose Description")
    properties.setManager("Aspose Manager")

    # Guardar la presentación en un archivo
    presentation.save("DocProps.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Este ejemplo modifica las propiedades integradas de la presentación, como se muestra a continuación:

|**Propiedades de documento integradas después de la modificación**|
| :- |
|![PowerPoint document properties](https://i.imgur.com/zz1N9de.jpg)|

## **Añadir propiedades de documento personalizadas**

Aspose.Slides for Python via Java también permite a los desarrolladores añadir propiedades de documento personalizadas a las presentaciones. El ejemplo siguiente añade tres propiedades personalizadas, después busca el nombre almacenado en el índice 2 y elimina esa propiedad, de modo que la presentación guardada conserva dos de ellas. Las propiedades personalizadas se indexan en orden alfabético, no en el orden en que se añadieron.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    # Obtener propiedades del documento
    properties = presentation.getDocumentProperties()

    # Añadir propiedades personalizadas
    properties.set_Item("New Custom", jpype.JInt(12))
    properties.set_Item("My Name", "Mudassir")
    properties.set_Item("Custom", jpype.JInt(124))

    # Obtener el nombre de la propiedad en un índice concreto
    property_name = properties.getCustomPropertyName(2)

    # Eliminar la propiedad seleccionada
    properties.removeCustomProperty(property_name)

    # Guardar la presentación
    presentation.save("CustomDemo.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

|**Propiedades de documento personalizadas añadidas**|
| :- |
|![PowerPoint document properties](https://i.imgur.com/HdKcxI9.png)|

## **Acceder y modificar propiedades personalizadas**

Aspose.Slides for Python via Java también permite a los desarrolladores acceder a los valores de las propiedades personalizadas. El siguiente ejemplo muestra cómo acceder y modificar todas las propiedades personalizadas en una presentación.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, DocumentProperties

presentation = Presentation("Presentation.pptx")
try:
    # Crear una referencia al objeto DocumentProperties asociado a la presentación
    properties = presentation.getDocumentProperties()

    # Acceder y modificar propiedades personalizadas
    for i in range(properties.getCountOfCustomProperties()):
        property_name = properties.getCustomPropertyName(i)
        # Mostrar nombres y valores de las propiedades personalizadas
        print("Custom Property Name : ", property_name)
        print("Custom Property Value : ", properties.get_Item(property_name))

        # Modificar valores de las propiedades personalizadas
        properties.set_Item(property_name, f"New Value {i + 1}")

    # Guardar la presentación en un archivo
    presentation.save("CustomDemoModified.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Este ejemplo modifica las propiedades personalizadas de la presentación [PPTX](https://docs.fileformat.com/presentation/pptx/). Las figuras siguientes muestran las propiedades personalizadas de la presentación antes y después de la modificación:

|**Propiedades personalizadas antes de la modificación**|
| :- |
|![PowerPoint document properties](https://i.imgur.com/Ze7YHvi.jpg)|

|**Propiedades personalizadas después de la modificación**|
| :- |
|![PowerPoint document properties](https://i.imgur.com/Tofu0CL.jpg)|

## **Propiedades de documento avanzadas**

{{% alert color="info" title="Note" %}}
Se han añadido los nuevos métodos [readDocumentProperties](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentationinfo/#readDocumentProperties), [updateDocumentProperties](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentationinfo/#updateDocumentProperties) y [writeBindedPresentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentationinfo/#writeBindedPresentation) a la clase [PresentationInfo](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentationinfo/), y el comportamiento del método [DocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/es/python-java/aspose.slides/documentproperties/#setLastSavedTime) ha cambiado.
{{% /alert %}}

Los dos nuevos métodos [readDocumentProperties](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentationinfo/#readDocumentProperties) y [updateDocumentProperties](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentationinfo/#updateDocumentProperties) se han añadido a la clase [PresentationInfo](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentationinfo/). Proporcionan acceso rápido a las propiedades del documento y le permiten cambiar y actualizar dichas propiedades sin cargar toda la presentación.

El flujo de trabajo típico de cargar propiedades, cambiar sus valores y actualizar el documento puede implementarse de la siguiente forma:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PresentationFactory

# Leer la información de la presentación
presentation_info = PresentationFactory.getInstance().getPresentationInfo("presentation.pptx")

# Obtener las propiedades actuales
properties = presentation_info.readDocumentProperties()

# Establecer los nuevos valores de los campos Author y Title
properties.setAuthor("New Author")
properties.setTitle("New Title")

# Actualizar la presentación con los nuevos valores
presentation_info.updateDocumentProperties(properties)
presentation_info.writeBindedPresentation("presentation.pptx")
```

Existe otra manera de usar las propiedades de una presentación concreta como plantilla para actualizar propiedades en otras presentaciones:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PresentationFactory

presentation_info = PresentationFactory.getInstance().getPresentationInfo("template.pptx")
template = presentation_info.readDocumentProperties()

template.setAuthor("Template Author")
template.setTitle("Template Title")
template.setCategory("Template Category")
template.setKeywords("Keyword1, Keyword2, Keyword3")
template.setCompany("Our Company")
template.setComments("Created from template")
template.setContentType("Template Content")
template.setSubject("Template Subject")

for path in ["doc1.pptx", "doc2.odp", "doc3.ppt"]:
    presentation_to_update = PresentationFactory.getInstance().getPresentationInfo(path)
    presentation_to_update.updateDocumentProperties(template)
    presentation_to_update.writeBindedPresentation(path)
```

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PresentationFactory

def update_by_template(path, template):
    presentation_to_update = PresentationFactory.getInstance().getPresentationInfo(path)
    presentation_to_update.updateDocumentProperties(template)
    presentation_to_update.writeBindedPresentation(path)
```

Se puede crear una nueva plantilla desde cero y luego usarla para actualizar varias presentaciones:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PresentationFactory, DocumentProperties

template = DocumentProperties()

template.setAuthor("Template Author")
template.setTitle("Template Title")
template.setCategory("Template Category")
template.setKeywords("Keyword1, Keyword2, Keyword3")
template.setCompany("Our Company")
template.setComments("Created from template")
template.setContentType("Template Content")
template.setSubject("Template Subject")

for path in ["doc1.pptx", "doc2.odp", "doc3.ppt"]:
    presentation_to_update = PresentationFactory.getInstance().getPresentationInfo(path)
    presentation_to_update.updateDocumentProperties(template)
    presentation_to_update.writeBindedPresentation(path)
```

## **Establecer el idioma de corrección**

Aspose.Slides proporciona el método [PortionFormat.setLanguageId](https://reference.aspose.com/slides/es/python-java/aspose.slides/portionformat/#setLanguageId) para permitirle establecer el idioma de corrección de pruebas para un documento PowerPoint. El idioma de corrección es el idioma para el que se revisan la ortografía y la gramática en la presentación.

Este código Python le muestra cómo establecer el idioma de corrección para un PowerPoint:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Portion, FontData

pptx_file_name = "presentation.pptx"

presentation = Presentation(pptx_file_name)
try:
    auto_shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)

    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)
    paragraph.getPortions().clear()

    new_portion = Portion()

    font = FontData("SimSun")
    portion_format = new_portion.getPortionFormat()
    portion_format.setComplexScriptFont(font)
    portion_format.setEastAsianFont(font)
    portion_format.setLatinFont(font)

    portion_format.setLanguageId("zh-CN") # establecer el Id del idioma de corrección

    new_portion.setText("1。")
    paragraph.getPortions().add(new_portion)
finally:
    presentation.dispose()
```

## **Establecer el idioma predeterminado**

Este código Python le muestra cómo establecer el idioma predeterminado para una presentación PowerPoint completa:

```python
import jpide
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, LoadOptions, ShapeType

load_options = LoadOptions()
load_options.setDefaultTextLanguage("en-US")

presentation = Presentation(load_options)
try:
    # Añade una forma rectangular con texto
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50)
    shape.getTextFrame().setText("New Text")

    # Comprueba el idioma de la primera porción
    print(shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getLanguageId())
finally:
    presentation.dispose()
```

## **Ejemplo en línea**

Pruebe la aplicación en línea [**Aspose.Slides Metadata**](https://products.aspose.app/slides/es/metadata) para ver cómo trabajar con propiedades de documento a través de la API de Aspose.Slides:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/es/metadata)

## **Preguntas frecuentes**

**¿Cómo puedo eliminar una propiedad integrada de una presentación?**

Las propiedades integradas forman parte integral de la presentación y no pueden eliminarse por completo. Sin embargo, puede cambiar sus valores o establecerlas como vacías si la propiedad lo permite.

**¿Qué ocurre si añado una propiedad personalizada que ya existe?**

Si añade una propiedad personalizada que ya existe, su valor actual será sobrescrito con el nuevo. No es necesario eliminar o comprobar la propiedad previamente, ya que Aspose.Slides actualiza automáticamente el valor de la propiedad.

**¿Puedo acceder a las propiedades de la presentación sin cargarla completamente?**

Sí. Utilice [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentationfactory/#getPresentationInfo) y a continuación [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentationinfo/#readDocumentProperties) para leer los metadatos del documento almacenados sin crear una instancia de [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/). Consulte [Build a Lightweight Presentation Inventory](/slides/es/python-java/examine-presentation/) para obtener un ejemplo completo de informe y limitaciones específicas del formato.

**¿Puedo leer propiedades públicas de una presentación cifrada sin su contraseña de apertura?**

Sí. El cifrado de propiedades del documento debe haberse desactivado antes de que la presentación se cifrara, y la presentación debe cargarse en modo *only‑document‑properties*.

**¿Puedo actualizar un archivo PPTX cifrado en modo *only‑document‑properties*?**

No. Los datos de propiedades públicas y cifradas deben permanecer coherentes, por lo que actualizar un archivo PPTX cifrado requiere cargar la presentación completa con la contraseña de apertura correcta.
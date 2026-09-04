---
title: Gestionar propiedades de la presentación con Python
linktitle: Propiedades de la presentación
type: docs
weight: 70
url: /es/python-net/presentation-properties/
keywords:
- Propiedades de PowerPoint
- Propiedades de la presentación
- Propiedades del documento
- Propiedades integradas
- Propiedades personalizadas
- Propiedades avanzadas
- Gestionar propiedades
- Modificar propiedades
- Metadatos del documento
- Editar metadatos
- Idioma de revisión
- Idioma predeterminado
- PowerPoint
- OpenDocument
- Presentación
- Python
- Aspose.Slides
description: "Domina las propiedades de presentación en Aspose.Slides for Python via .NET y optimiza la búsqueda, la marca y el flujo de trabajo en tus archivos PowerPoint."
---
## **Introducción**

Aspose.Slides admite dos tipos de propiedades de documento: **Integradas** y **Personalizadas**. Ambos tipos de propiedades pueden accederse y gestionarse fácilmente mediante la API de Aspose.Slides.

Aspose.Slides le permite trabajar con las propiedades de documento de la presentación mediante la clase [DocumentProperties](https://reference.aspose.com/slides/es/python-net/aspose.slides/documentproperties/) . Una instancia de esta clase se devuelve a través de la propiedad [Presentation.document_properties](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/document_properties/) . Los siguientes ejemplos muestran cómo leer, modificar y gestionar estas propiedades.

{{% alert color="info" title="Note" %}}
Tenga en cuenta que no puede establecer valores en los campos **Application** y **Producer**, ya que Aspose Ltd. y Aspose.Slides for Python via .NET x.x.x se mostrará en estos campos.
{{% /alert %}} 

## **Gestionar propiedades de la presentación**

Microsoft PowerPoint proporciona una característica para añadir algunas propiedades a los archivos de presentación. Estas propiedades de documento permiten almacenar información útil junto con los documentos (archivos de presentación). Existen dos tipos de propiedades de documento de la siguiente manera

- Propiedades definidas por el sistema (Integradas)
- Propiedades definidas por el usuario (Personalizadas)

Las propiedades **Integradas** contienen información general sobre el documento, como el título del documento, el nombre del autor, estadísticas del documento, etc. Las propiedades **Personalizadas** son aquellas definidas por los usuarios como pares **Nombre/Valor**, donde tanto el nombre como el valor son definidos por el usuario. Con Aspose.Slides for Python via .NET, los desarrolladores pueden acceder y modificar los valores de las propiedades integradas así como de las propiedades personalizadas. Microsoft PowerPoint 2007 permite gestionar las propiedades de documento de los archivos de presentación. Todo lo que debe hacer es hacer clic en el icono de Office y luego en el elemento del menú **Prepare | Properties | Advanced Properties** de Microsoft PowerPoint 2007. Después de seleccionar el elemento del menú **Advanced Properties**, aparecerá un cuadro de diálogo que permite gestionar las propiedades de documento del archivo PowerPoint. En el **Properties Dialog**, puede ver que hay varias pestañas como **General, Summary, Statistics, Contents and Custom**. Todas estas pestañas permiten configurar diferentes tipos de información relacionada con los archivos PowerPoint. La pestaña **Custom** se utiliza para gestionar las propiedades personalizadas de los archivos PowerPoint.

## **Leer propiedades públicas de una presentación cifrada**

Una contraseña de apertura normalmente protege tanto el contenido de la presentación como las propiedades del documento. Cuando una presentación se cifra con [ProtectionManager.encrypt_document_properties](https://reference.aspose.com/slides/es/python-net/aspose.slides/protectionmanager/encrypt_document_properties/) configurado en `False`, sus propiedades de documento permanecen públicas. Entonces una aplicación puede establecer [LoadOptions.only_load_document_properties](https://reference.aspose.com/slides/es/python-net/aspose.slides/loadoptions/only_load_document_properties/) en `True` y leer los metadatos públicos sin proporcionar la contraseña de apertura.

`only_load_document_properties` controla lo que Aspose.Slides carga; no descifra nada. Si las propiedades estaban incluidas en el cifrado, cargarlas sin la contraseña falla. Si la presentación no está cifrada, la opción se ignora y se carga la presentación completa.

El siguiente ejemplo verifica el modo de carga mediante [ProtectionManager.is_only_document_properties_loaded](https://reference.aspose.com/slides/es/python-net/aspose.slides/protectionmanager/is_only_document_properties_loaded/) y luego lee las propiedades integradas a través de [Presentation.document_properties](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/document_properties/) :

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.only_load_document_properties = True

with slides.Presentation("public-properties-encrypted.pptx", load_options) as presentation:
    if presentation.protection_manager.is_only_document_properties_loaded:
        properties = presentation.document_properties

        print("Author: " + properties.author)
        print("Title: " + properties.title)
        print("Keywords: " + properties.keywords)
    else:
        print("The presentation was not loaded in document-properties-only mode.")
```

En este modo, el contenido de las diapositivas no se carga. Las diapositivas, maestros, diseños, formas, medios y otros objetos de la presentación no están disponibles. Las aplicaciones deben comprobar siempre `is_only_document_properties_loaded` antes de realizar una operación que requiera el modelo de objetos completo de la presentación.

{{% alert color="warning" title="Security" %}}
Los metadatos públicos pueden revelar nombres de autores, títulos, asuntos, palabras clave, información de la empresa, comentarios y valores personalizados. Encripte las propiedades sensibles junto con la presentación. Déjelas públicas solo cuando los sistemas de indexación, clasificación, búsqueda o gestión de documentos tengan un requisito específico para acceder a ellas sin contraseña.
{{% /alert %}}

## **Actualizar propiedades de una presentación cifrada**

Para un archivo PPTX cifrado, una presentación cargada con `only_load_document_properties` está destinada a leer los metadatos públicos. Aspose.Slides no puede guardar las propiedades modificadas de ese objeto de solo metadatos porque las propiedades públicas deben permanecer consistentes con los datos correspondientes dentro de la presentación cifrada. Por lo tanto, actualizarlas requiere la contraseña de apertura correcta y una carga completa.

El siguiente ejemplo abre la presentación con [LoadOptions.password](https://reference.aspose.com/slides/es/python-net/aspose.slides/loadoptions/password/), actualiza las propiedades públicas integradas y guarda el resultado. Luego utiliza [PresentationInfo.is_encrypted](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentationinfo/is_encrypted/) para verificar que el cifrado se mantiene y vuelve a abrir los metadatos públicos sin una contraseña para comprobar los nuevos valores:

```python
import aspose.slides as slides

input_path = "public-properties-encrypted.pptx"
output_path = "updated-public-properties-encrypted.pptx"

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation(input_path, load_options) as presentation:
    presentation.document_properties.title = "Updated Product Roadmap"
    presentation.document_properties.keywords = "roadmap, planning, indexed"
    presentation.save(output_path, slides.export.SaveFormat.PPTX)

presentation_info = slides.PresentationFactory.instance.get_presentation_info(output_path)
print("The presentation is encrypted: " + str(presentation_info.is_encrypted))

metadata_load_options = slides.LoadOptions()
metadata_load_options.only_load_document_properties = True

with slides.Presentation(output_path, metadata_load_options) as metadata_presentation:
    if metadata_presentation.protection_manager.is_only_document_properties_loaded:
        print("Title: " + metadata_presentation.document_properties.title)
        print("Keywords: " + metadata_presentation.document_properties.keywords)
    else:
        print("The presentation was not loaded in document-properties-only mode.")
```

Si una aplicación no tiene permiso para descifrar o cargar el contenido de la presentación, debe tratar las propiedades públicas de un archivo PPTX cifrado como solo lectura.

## **Acceder a propiedades integradas**
Estas propiedades, tal como las expone el objeto **IDocumentProperties**, incluyen: **Creator(Author)**, **Description**, **Keywords**, **Created** (Fecha de creación), **Modified** (Fecha de modificación), **Printed** (Fecha del último imprimado), **LastModifiedBy**, **Keywords**, **SharedDoc** (¿Se comparte entre diferentes productores?), **PresentationFormat**, **Subject** y **Title**
```py
import aspose.slides as slides

# Instanciar la clase Presentation que representa la presentación
with slides.Presentation("AccessBuiltin Properties.pptx") as pres:
    # Crear una referencia al objeto asociado con Presentation
    documentProperties = pres.document_properties

    # Mostrar las propiedades integradas
    print("category : " + documentProperties.category)
    print("Current Status : " + documentProperties.content_status)
    print("Creation Date : " + str(documentProperties.created_time))
    print("Author : " + documentProperties.author)
    print("Description : " + documentProperties.comments)
    print("KeyWords : " + documentProperties.keywords)
    print("Last Modified By : " + documentProperties.last_saved_by)
    print("Supervisor : " + documentProperties.manager)
    print("Modified Date : " + str(documentProperties.last_saved_time))
    print("Presentation Format : " + documentProperties.presentation_format)
    print("Last Print Date : " + str(documentProperties.last_printed))
    print("Is Shared between producers : " + str(documentProperties.shared_doc))
    print("Subject : " + documentProperties.subject)
    print("Title : " + documentProperties.title)
```

## **Modificar propiedades integradas**

La modificación de las propiedades integradas de los archivos de presentación es tan sencilla como acceder a ellas. Simplemente puede asignar un valor de cadena a cualquier propiedad deseada y el valor de la propiedad se modificará. En el ejemplo que se muestra a continuación, hemos demostrado cómo podemos modificar las propiedades de documento integradas del archivo de presentación.

```py
import aspose.slides as slides

# Instanciar la clase Presentation que representa la Presentación
with slides.Presentation("ModifyBuiltinProperties.pptx") as presentation:
    # Crear una referencia al objeto asociado con Presentation
    documentProperties = presentation.document_properties

    # Establecer las propiedades integradas
    documentProperties.author = "Aspose.Slides for .NET"
    documentProperties.title = "Modifying Presentation Properties"
    documentProperties.subject = "Aspose Subject"
    documentProperties.comments = "Aspose Description"
    documentProperties.manager = "Aspose Manager"

    # Guardar la presentación en un archivo
    presentation.save("DocumentProperties_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Añadir propiedades personalizadas a la presentación**

Aspose.Slides for Python via .NET también permite a los desarrolladores añadir valores personalizados a las propiedades del documento de la presentación. A continuación se muestra un ejemplo que indica cómo establecer las propiedades personalizadas para una presentación.

```py
import aspose.slides as slides

# Instanciar la clase Presentation
with slides.Presentation() as presentation:
    # Obtener propiedades del documento
    documentProperties = presentation.document_properties

    # Añadir propiedades personalizadas
    documentProperties.set_custom_property_value("New Custom", 12)
    documentProperties.set_custom_property_value("My Nam", "Mudassir")
    documentProperties.set_custom_property_value("Custom", 124)

    # Obtener el nombre de la propiedad en un índice específico
    getPropertyName = documentProperties.get_custom_property_name(2)

    # Eliminar la propiedad seleccionada
    documentProperties.remove_custom_property(getPropertyName)

    # Guardar la presentación
    presentation.save("CustomDocumentProperties_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Acceder y modificar propiedades personalizadas**

Aspose.Slides for Python via .NET también permite a los desarrolladores acceder a los valores de las propiedades personalizadas. A continuación se muestra un ejemplo que indica cómo puede acceder y modificar todas estas propiedades personalizadas para una presentación.

```py
import aspose.slides as slides

# Instanciar la clase Presentation que representa el PPTX
with slides.Presentation("AccessModifyingProperties.pptx") as presentation:
    # Crear una referencia al objeto document_properties asociado con Presentation
    documentProperties = presentation.document_properties

    # Acceder y modificar propiedades personalizadas
    for i in range(documentProperties.count_of_custom_properties):
        property_name = documentProperties.get_custom_property_name(i)

        # Mostrar nombres y valores de las propiedades personalizadas
        property_value = [""]
        documentProperties.get_custom_property_value(property_name, property_value)
        print("Custom Property Name : " + property_name)
        print("Custom Property Value : " + property_value[0])

        # Modificar valores de las propiedades personalizadas
        documentProperties.set_custom_property_value(property_name, "New Value " + str(i + 1))
    # Guardar la presentación en un archivo
    presentation.save("CustomDemoModified_out.pptx", slides.export.SaveFormat.PPTX)
```

`get_custom_property_value` devuelve el valor a través de la lista de un elemento que se pasa como segundo argumento, y el valor almacenado se convierte al tipo del elemento ya presente en esa lista. El ejemplo anterior usa `[""]`, por lo que lee propiedades de tipo cadena; para leer una propiedad almacenada como número, pase un marcador numérico como `[0]`; de lo contrario, la llamada genera una `InvalidCastException`.

## **Establecer idioma de revisión**

Aspose.Slides proporciona la propiedad `Language_Id` (expuesta por la clase [PortionFormat](https://reference.aspose.com/slides/es/python-net/aspose.slides/portionformat/)) para permitirle establecer el idioma de revisión de un documento PowerPoint. El idioma de revisión es el idioma para el que se comprueban la ortografía y la gramática en PowerPoint.

Este código Python muestra cómo establecer el idioma de revisión para un PowerPoint:

```python
import aspose.slides as slides

with slides.Presentation("SetProofingLanguage.pptx") as pres:
    auto_shape = pres.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]
    paragraph.portions.clear()

    new_portion = slides.Portion()
    font = slides.FontData("SimSun")
    portion_format = new_portion.portion_format
    portion_format.complex_script_font = font
    portion_format.east_asian_font = font
    portion_format.latin_font = font

    # establecer el Id de un idioma de revisión
    portion_format.language_id = "zh-CN"
    new_portion.text = "1。"

    paragraph.portions.add(new_portion)
```

## **Establecer idioma predeterminado**

Este código Python muestra cómo establecer el idioma predeterminado para una presentación completa de PowerPoint:

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.default_text_language = "en_US"

with slides.Presentation(load_options) as pres:
    shp = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 150)
    text_frame = shp.text_frame
    text_frame.text = "New Text"

    print(text_frame.paragraphs[0].portions[0].portion_format.language_id)
```

## **Ejemplo en vivo**

Pruebe la aplicación en línea [**Aspose.Slides Metadata**](https://products.aspose.app/slides/es/metadata) para ver cómo trabajar con las propiedades de documento mediante la API de Aspose.Slides:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/es/metadata)

## **Preguntas frecuentes**

**¿Cómo puedo eliminar una propiedad integrada de una presentación?**

Las propiedades integradas son una parte integral de la presentación y no pueden eliminarse por completo. Sin embargo, puede cambiar sus valores o establecerlas como vacías si la propiedad específica lo permite.

**¿Qué ocurre si añado una propiedad personalizada que ya existe?**

Si añade una propiedad personalizada que ya existe, su valor actual se sobrescribirá con el nuevo. No es necesario eliminar o comprobar la propiedad previamente, ya que Aspose.Slides actualiza automáticamente el valor de la propiedad.

**¿Puedo acceder a las propiedades de la presentación sin cargar completamente la presentación?**

Sí. Use [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentationfactory/get_presentation_info/) y luego [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentationinfo/read_document_properties/) para leer los metadatos del documento almacenados sin crear una instancia de [Presentation](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/) . Consulte [Build a Lightweight Presentation Inventory](/slides/es/python-net/examine-presentation/) para obtener un ejemplo completo de informe y limitaciones específicas de formato.

**¿Puedo leer las propiedades públicas de una presentación cifrada sin su contraseña de apertura?**

Sí. La presentación debe haberse cifrado con `encrypt_document_properties` configurado en `False`, y debe cargarse con `only_load_document_properties` configurado en `True`.

**¿Puedo actualizar un archivo PPTX cifrado en modo solo propiedades de documento?**

No. Los datos de propiedades públicas y cifradas deben permanecer consistentes, por lo que actualizar un archivo PPTX cifrado requiere cargar la presentación completa con la contraseña de apertura correcta.
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
- presentación
- Python
- Aspose.Slides
description: "Domine las propiedades de la presentación en Aspose.Slides para Python vía .NET y optimice la búsqueda, la marca y el flujo de trabajo en sus archivos PowerPoint."
---
## **Introducción**

Aspose.Slides admite dos tipos de propiedades de documento: **Integradas** y **Personalizadas**. Ambos tipos de propiedades pueden accederse y gestionarse fácilmente mediante la API de Aspose.Slides.

Aspose.Slides permite trabajar con las propiedades de documento de la presentación a través de la clase [DocumentProperties](https://reference.aspose.com/slides/es/python-net/aspose.slides/documentproperties/) . Una instancia de esta clase se devuelve mediante la propiedad [Presentation.document_properties](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/document_properties/) . Los ejemplos siguientes muestran cómo leer, modificar y gestionar estas propiedades.

{{% alert color="info" title="Note" %}}
Tenga en cuenta que no puede establecer valores en los campos **Application** y **Producer**, porque Aspose Ltd. y Aspose.Slides for Python via .NET x.x.x se mostrarán en dichos campos.
{{% /alert %}} 

## **Gestionar propiedades de la presentación**

Microsoft PowerPoint ofrece una función para añadir algunas propiedades a los archivos de presentación. Estas propiedades de documento permiten almacenar información útil junto con los documentos (archivos de presentación). Existen dos tipos de propiedades de documento, como se indica a continuación:

- Propiedades definidas por el sistema (Integradas)
- Propiedades definidas por el usuario (Personalizadas)

Las **Integradas** contienen información general del documento, como el título, el nombre del autor, estadísticas del documento, etc. Las **Personalizadas** son aquellas que los usuarios definen como pares **Name/Value**, donde tanto el nombre como el valor son definidos por el usuario. Con Aspose.Slides for Python via .NET, los desarrolladores pueden acceder y modificar los valores de las propiedades integradas así como de las personalizadas. Microsoft PowerPoint 2007 permite gestionar las propiedades de documento de los archivos de presentación. Todo lo que tiene que hacer es hacer clic en el icono de Office y, a continuación, en el elemento de menú **Prepare | Properties | Advanced Properties** de Microsoft PowerPoint 2007. Después de seleccionar el elemento de menú **Advanced Properties**, aparecerá un cuadro de diálogo que permite gestionar las propiedades de documento del archivo PowerPoint. En el **Properties Dialog**, puede ver que hay varias pestañas como **General, Summary, Statistics, Contents and Custom**. Todas estas pestañas permiten configurar diferentes tipos de información relacionada con los archivos PowerPoint. La pestaña **Custom** se utiliza para gestionar las propiedades personalizadas de los archivos PowerPoint.

## **Acceder a propiedades integradas**

Estas propiedades, tal como las expone el objeto **IDocumentProperties**, incluyen: **Creator(Author)**, **Description**, **Keywords**, **Created** (Fecha de creación), **Modified** (Fecha de modificación), **Printed** (Fecha del último impresión), **LastModifiedBy**, **Keywords**, **SharedDoc** (¿Se comparte entre diferentes productores?), **PresentationFormat**, **Subject** y **Title**.

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

Modificar las propiedades integradas de los archivos de presentación es tan sencillo como acceder a ellas. Simplemente puede asignar un valor de cadena a cualquier propiedad deseada y el valor de la propiedad se modificará. En el ejemplo que se muestra a continuación, hemos demostrado cómo podemos modificar las propiedades de documento integradas del archivo de presentación.

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

## **Agregar propiedades personalizadas a la presentación**

Aspose.Slides for Python via .NET también permite a los desarrolladores agregar valores personalizados a las propiedades de documento de la presentación. A continuación se muestra un ejemplo que indica cómo establecer las propiedades personalizadas para una presentación.

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

    # Obtener el nombre de la propiedad en un índice concreto
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

`get_custom_property_value` devuelve el valor mediante la lista de un elemento que se pasa como segundo argumento, y el valor almacenado se convierte al tipo del elemento ya presente en esa lista. El ejemplo anterior usa `[""]`, por lo que lee propiedades de cadena; para leer una propiedad almacenada como número, pase un marcador numérico como `[0]`; de lo contrario la llamada genera una `InvalidCastException`.

## **Establecer idioma de revisión**

Aspose.Slides proporciona la propiedad `Language_Id` (expuesta por la clase [PortionFormat](https://reference.aspose.com/slides/es/python-net/aspose.slides/portionformat/)) para permitirle establecer el idioma de revisión para un documento PowerPoint. El idioma de revisión es el idioma para el que se comprueban la ortografía y la gramática en PowerPoint.

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

Este código Python muestra cómo establecer el idioma predeterminado para una presentación PowerPoint completa:

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

[![Ver y editar metadatos de PowerPoint](slides-metadata.png)](https://products.aspose.app/slides/es/metadata)

## **Preguntas frecuentes**

**¿Cómo puedo eliminar una propiedad integrada de una presentación?**

Las propiedades integradas son una parte integral de la presentación y no pueden eliminarse por completo. Sin embargo, puede cambiar sus valores o dejarlos vacíos si la propiedad específica lo permite.

**¿Qué ocurre si añado una propiedad personalizada que ya existe?**

Si añade una propiedad personalizada que ya existe, su valor actual se sobrescribirá con el nuevo. No es necesario eliminar o comprobar la propiedad previamente, ya que Aspose.Slides actualiza automáticamente el valor de la propiedad.

**¿Puedo acceder a las propiedades de la presentación sin cargarla completamente?**

Sí. Utilice [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentationfactory/get_presentation_info/) y luego [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentationinfo/read_document_properties/) para leer los metadatos del documento almacenados sin crear una instancia de [Presentation](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/). Consulte [Build a Lightweight Presentation Inventory](/slides/es/python-net/examine-presentation/) para obtener un ejemplo completo de informe y limitaciones específicas del formato.
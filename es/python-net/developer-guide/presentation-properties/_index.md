---
title: Propiedades de Presentación
type: docs
weight: 70
url: /python-net/presentation-properties/
keywords: "propiedades de PowerPoint, presentación de PowerPoint, Python, Aspose.Slides para Python a través de .NET"
description: "Propiedades de presentación de PowerPoint en Python"
---


## **Ejemplo en Vivo**
Prueba [**Aspose.Slides Metadata**](https://products.aspose.app/slides/metadata) la aplicación en línea para ver cómo trabajar con propiedades de documentos a través de la API de Aspose.Slides:

[](https://products.aspose.app/slides/metadata)

[![todo:image_alt_text](slides-metadata.png)](https://products.aspose.app/slides/metadata)


## **Acerca de las Propiedades de Presentación**
Como hemos descrito anteriormente, Aspose.Slides para Python a través de .NET admite dos tipos de propiedades de documentos, que son propiedades **Integradas** y **Personalizadas**. Por lo tanto, los desarrolladores pueden acceder a ambos tipos de propiedades utilizando la API de Aspose.Slides para Python a través de .NET. Aspose.Slides para Python a través de .NET proporciona una clase [IDocumentProperties](https://reference.aspose.com/slides/python-net/aspose.slides/idocumentproperties/) que representa las propiedades del documento asociadas con un archivo de presentación a través de la propiedad [Presentation.document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/). Los desarrolladores pueden usar la propiedad [IDocumentProperties](https://reference.aspose.com/slides/python-net/aspose.slides/idocumentproperties/) expuesta por el objeto **Presentation** para acceder a las propiedades del documento de los archivos de presentación, como se describe a continuación:



{{% alert color="primary" %}} 

Tenga en cuenta que no puede establecer valores en los campos **Aplicación** y **Productor**, porque Aspose Ltd. y Aspose.Slides para Python a través de .NET x.x.x se mostrarán en estos campos.

{{% /alert %}} 


## **Gestionar Propiedades de Presentación**
Microsoft PowerPoint proporciona una función para agregar algunas propiedades a los archivos de presentación. Estas propiedades de documentos permiten almacenar información útil junto con los documentos (archivos de presentación). Hay dos tipos de propiedades de documentos como sigue

- Propiedades Definidas por el Sistema (Integradas)
- Propiedades Definidas por el Usuario (Personalizadas)

Las propiedades **Integradas** contienen información general sobre el documento, como el título del documento, el nombre del autor, las estadísticas del documento, etc. Las propiedades **Personalizadas** son aquellas que son definidas por los usuarios como pares **Nombre/Valor**, donde tanto el nombre como el valor son definidos por el usuario. Usando Aspose.Slides para Python a través de .NET, los desarrolladores pueden acceder y modificar los valores de las propiedades integradas así como de las propiedades personalizadas. Microsoft PowerPoint 2007 permite gestionar las propiedades de documentos de los archivos de presentación. Todo lo que tiene que hacer es hacer clic en el ícono de Office y luego en el menú **Preparar | Propiedades | Propiedades Avanzadas** de Microsoft PowerPoint 2007. Después de seleccionar el elemento del menú **Propiedades Avanzadas**, aparecerá un diálogo que le permitirá gestionar las propiedades de documentos del archivo de PowerPoint. En el **Diálogo de Propiedades**, puede ver que hay muchas pestañas como **General, Resumen, Estadísticas, Contenidos y Personalizado**. Todas estas pestañas permiten configurar diferentes tipos de información relacionada con los archivos de PowerPoint. La pestaña **Personalizado** se utiliza para gestionar las propiedades personalizadas de los archivos de PowerPoint.
## **Acceder a Propiedades Integradas**
Estas propiedades, tal como las expone el objeto **IDocumentProperties**, incluyen: **Creador (Autor)**, **Descripción**, **Palabras Clave**, **Creado** (Fecha de Creación), **Modificado** (Fecha de Modificación), **Impreso** (Última Fecha de Impresión), **ÚltimoModificadoPor**, **Palabras Clave**, **SharedDoc** (¿Está compartido entre diferentes productores?), **FormatoDePresentación**, **Asunto** y **Título**
```py
import aspose.slides as slides

# Instanciar la clase Presentación que representa la presentación
with slides.Presentation(path + "AccessBuiltin Properties.pptx") as pres:
    # Crear una referencia al objeto asociado con Presentación
    documentProperties = pres.document_properties

    # Mostrar las propiedades integradas
    print("categoría : " + documentProperties.category)
    print("Estado Actual : " + documentProperties.content_status)
    print("Fecha de Creación : " + str(documentProperties.created_time))
    print("Autor : " + documentProperties.author)
    print("Descripción : " + documentProperties.comments)
    print("Palabras Clave : " + documentProperties.keywords)
    print("Último Modificado Por : " + documentProperties.last_saved_by)
    print("Supervisor : " + documentProperties.manager)
    print("Fecha de Modificación : " + str(documentProperties.last_saved_time))
    print("Formato de Presentación : " + documentProperties.presentation_format)
    print("Última Fecha de Impresión : " + str(documentProperties.last_printed))
    print("¿Está Compartido entre productores? : " + str(documentProperties.shared_doc))
    print("Asunto : " + documentProperties.subject)
    print("Título : " + documentProperties.title)
```
## **Modificar Propiedades Integradas**
Modificar las propiedades integradas de los archivos de presentación es tan fácil como acceder a ellas. Simplemente puede asignar un valor de cadena a cualquier propiedad deseada y el valor de la propiedad se modificará. En el ejemplo que se da a continuación, hemos demostrado cómo podemos modificar las propiedades del documento integradas del archivo de presentación.

```py
import aspose.slides as slides

# Instanciar la clase Presentación que representa la Presentación
with slides.Presentation(path + "ModifyBuiltinProperties.pptx") as presentation:
    # Crear una referencia al objeto asociado con Presentación
    documentProperties = presentation.document_properties

    # Establecer las propiedades integradas
    documentProperties.author = "Aspose.Slides para .NET"
    documentProperties.title = "Modificando Propiedades de Presentación"
    documentProperties.subject = "Asunto de Aspose"
    documentProperties.comments = "Descripción de Aspose"
    documentProperties.manager = "Gerente de Aspose"

    # guardar su presentación en un archivo
    presentation.save("DocumentProperties_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Agregar Propiedades Personalizadas de Presentación**
Aspose.Slides para Python a través de .NET también permite a los desarrolladores agregar los valores personalizados para las propiedades de documentos de presentación. Se da un ejemplo a continuación que muestra cómo establecer las propiedades personalizadas para una presentación.

```py
import aspose.slides as slides

# Instanciar la clase Presentación
with slides.Presentation() as presentation:
    # Obtener Propiedades del Documento
    documentProperties = presentation.document_properties

    # Agregar propiedades personalizadas
    documentProperties.set_custom_property_value("Nueva Personalizada", 12)
    documentProperties.set_custom_property_value("Mi Nombre", "Mudassir")
    documentProperties.set_custom_property_value("Personalizada", 124)

    # Obtener el nombre de la propiedad en un índice particular
    getPropertyName = documentProperties.get_custom_property_name(2)

    # Eliminar la propiedad seleccionada
    documentProperties.remove_custom_property(getPropertyName)

    # Guardar presentación
    presentation.save("CustomDocumentProperties_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Acceder y Modificar Propiedades Personalizadas**
Aspose.Slides para Python a través de .NET también permite a los desarrolladores acceder a los valores de las propiedades personalizadas. A continuación se da un ejemplo que muestra cómo puede acceder y modificar todas estas propiedades personalizadas para una presentación.

```py
import aspose.slides as slides

# Instanciar la clase Presentación que representa el PPTX
with slides.Presentation(path + "AccessModifyingProperties.pptx") as presentation:
    # Crear una referencia al objeto document_properties asociado con Presentación
    documentProperties = presentation.document_properties

    # Acceder y modificar las propiedades personalizadas
    for i in range(documentProperties.count_of_custom_properties):
        # Mostrar nombres y valores de propiedades personalizadas
        print("Nombre de Propiedad Personalizada : " + documentProperties.get_custom_property_name(i))
        print("Valor de Propiedad Personalizada : " + documentProperties.get_custom_property_value[documentProperties.get_custom_property_name(i)])

        # Modificar valores de propiedades personalizadas
        documentProperties.set_custom_property_value(documentProperties.get_custom_property_name(i), "Nuevo Valor " + str(i + 1))
    # guardar su presentación en un archivo
    presentation.save("CustomDemoModified_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Verificar si la Presentación ha sido Modificada o Creada**
Aspose.Slides para Python a través de .NET proporciona una función para verificar si una presentación ha sido modificada o creada. A continuación se presenta un ejemplo que muestra cómo verificar si la presentación ha sido creada o modificada.

```py
import aspose.slides as slides

info =slides.PresentationFactory.instance.get_presentation_info(path + "AccessModifyingProperties.pptx")
props = info.read_document_properties()

print(props.name_of_application)
print(props.app_version)
```

## **Establecer el Idioma de Revisión**

Aspose.Slides proporciona la propiedad `Language_Id` (expuesta por la clase [PortionFormat](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/)) para permitirte establecer el idioma de revisión para un documento de PowerPoint. El idioma de revisión es el idioma en el que se revisan las ortografías y la gramática en el PowerPoint.

Este código de Python te muestra cómo establecer el idioma de revisión para un PowerPoint:

```python
import aspose.slides as slides

with slides.Presentation(path + "SetProofingLanguage.pptx") as pres:
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

## **Establecer Idioma Predeterminado**

Este código de Python te muestra cómo establecer el idioma predeterminado para una presentación de PowerPoint completa:

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.default_text_language = "en_US"

with slides.Presentation(load_options) as pres:
    shp = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 150)
    text_frame = shp.text_frame
    text_frame.text = "Nuevo Texto"

    print(text_frame.paragraphs[0].portions[0].portion_format.language_id)
```
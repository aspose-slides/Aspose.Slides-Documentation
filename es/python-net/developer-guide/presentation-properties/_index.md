---
title: Administrar propiedades de la presentación con Python
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
- Administrar propiedades
- Modificar propiedades
- Metadatos del documento
- Editar metadatos
- Idioma de corrección
- Idioma predeterminado
- PowerPoint
- OpenDocument
- presentación
- Python
- Aspose.Slides
description: "Domina las propiedades de la presentación en Aspose.Slides para Python a través de .NET y optimiza la búsqueda, la marca y el flujo de trabajo en tus archivos PowerPoint."
---

## **Acerca de las propiedades de la presentación**

Como hemos descrito anteriormente, Aspose.Slides for Python via .NET admite dos tipos de propiedades de documento, que son **Integradas** y **Personalizadas**. Por lo tanto, los desarrolladores pueden acceder a ambos tipos de propiedades mediante la API de Aspose.Slides for Python via .NET. Aspose.Slides for Python via .NET proporciona la clase [IDocumentProperties](https://reference.aspose.com/slides/python-net/aspose.slides/idocumentproperties/) que representa las propiedades del documento asociadas a un archivo de presentación a través de la propiedad [Presentation.document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/). Los desarrolladores pueden usar la propiedad [IDocumentProperties](https://reference.aspose.com/slides/python-net/aspose.slides/idocumentproperties/) expuesta por el objeto **Presentation** para acceder a las propiedades del documento de los archivos de presentación como se describe a continuación:

{{% alert color="primary"%}}Tenga en cuenta que no puede establecer valores en los campos **Application** y **Producer**, porque Aspose Ltd. y Aspose.Slides for Python via .NET x.x.x se mostrarán en esos campos.{{% /alert %}}

## **Administrar propiedades de la presentación**

Microsoft PowerPoint ofrece una función para añadir algunas propiedades a los archivos de presentación. Estas propiedades del documento permiten almacenar información útil junto con los documentos (archivos de presentación). Hay dos tipos de propiedades del documento:

- Propiedades definidas por el sistema (Integradas)
- Propiedades definidas por el usuario (Personalizadas)

Las **propiedades integradas** contienen información general sobre el documento, como el título del documento, el nombre del autor, estadísticas del documento, etc. Las **propiedades personalizadas** son aquellas definidas por los usuarios como pares **Nombre/Valor**, donde tanto el nombre como el valor son definidos por el usuario. Con Aspose.Slides for Python via .NET, los desarrolladores pueden acceder y modificar los valores de las propiedades integradas así como de las propiedades personalizadas. Microsoft PowerPoint 2007 permite gestionar las propiedades del documento de los archivos de presentación. Todo lo que tiene que hacer es hacer clic en el icono de Office y luego en **Preparar | Propiedades | Propiedades avanzadas** en Microsoft PowerPoint 2007. Después de seleccionar **Propiedades avanzadas**, aparecerá un diálogo que le permitirá gestionar las propiedades del documento del archivo PowerPoint. En el **Diálogo de propiedades**, verá muchas pestañas como **General, Resumen, Estadísticas, Contenido y Personalizado**. Todas estas pestañas permiten configurar diferentes tipos de información relacionada con los archivos PowerPoint. La pestaña **Personalizado** se usa para gestionar las propiedades personalizadas de los archivos PowerPoint.

## **Acceder a propiedades integradas**
Estas propiedades expuestas por el objeto **IDocumentProperties** incluyen: **Creator (Autor)**, **Description (Descripción)**, **Keywords (Palabras clave)**, **Created** (Fecha de creación), **Modified** (Fecha de modificación), **Printed** (Fecha de última impresión), **LastModifiedBy** (Último modificado por), **SharedDoc** (¿Compartido entre diferentes productores?), **PresentationFormat** (Formato de presentación), **Subject** (Asunto) y **Title** (Título).

```py
import aspose.slides as slides

# Instanciar la clase Presentation que representa la presentación
with slides.Presentation(path + "AccessBuiltin Properties.pptx") as pres:
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

Modificar las propiedades integradas de los archivos de presentación es tan fácil como acceder a ellas. Simplemente asigne un valor de cadena a la propiedad deseada y el valor de la propiedad se modificará. En el ejemplo a continuación, demostramos cómo modificar las propiedades integradas del documento de la presentación.

```py
import aspose.slides as slides

# Instanciar la clase Presentation que representa la Presentación
with slides.Presentation(path + "ModifyBuiltinProperties.pptx") as presentation:
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

Aspose.Slides for Python via .NET también permite a los desarrolladores añadir valores personalizados para las propiedades del documento de la presentación. El siguiente ejemplo muestra cómo establecer propiedades personalizadas para una presentación.

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

Aspose.Slides for Python via .NET también permite a los desarrolladores acceder a los valores de las propiedades personalizadas. El siguiente ejemplo muestra cómo puede acceder y modificar todas estas propiedades personalizadas para una presentación.

```py
import aspose.slides as slides

# Instanciar la clase Presentation que representa el PPTX
with slides.Presentation(path + "AccessModifyingProperties.pptx") as presentation:
    # Crear una referencia al objeto document_properties asociado con la Presentación
    documentProperties = presentation.document_properties

    # Acceder y modificar propiedades personalizadas
    for i in range(documentProperties.count_of_custom_properties):
        # Mostrar nombres y valores de las propiedades personalizadas
        print("Custom Property Name : " + documentProperties.get_custom_property_name(i))
        print("Custom Property Value : " + documentProperties.get_custom_property_value[documentProperties.get_custom_property_name(i)])

        # Modificar valores de las propiedades personalizadas
        documentProperties.set_custom_property_value(documentProperties.get_custom_property_name(i), "New Value " + str(i + 1))
    # Guardar la presentación en un archivo
    presentation.save("CustomDemoModified_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Establecer idioma de corrección**

Aspose.Slides proporciona la propiedad `Language_Id` (expuesta por la clase [PortionFormat](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/)) para permitirle establecer el idioma de corrección para un documento PowerPoint. El idioma de corrección es el idioma para el cual se revisan la ortografía y la gramática en PowerPoint.

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

    # set the Id of a proofing language
    portion_format.language_id = "zh-CN"
    new_portion.text = "1。"

    paragraph.portions.add(new_portion)
```

## **Establecer idioma predeterminado**

Este código Python muestra cómo establecer el idioma predeterminado para toda una presentación PowerPoint:

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

Pruebe la aplicación en línea [**Metadatos de Aspose.Slides**](https://products.aspose.app/slides/metadata) para ver cómo trabajar con propiedades de documento mediante la API de Aspose.Slides:

[![Ver y editar metadatos de PowerPoint](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **Preguntas frecuentes**

**¿Cómo puedo eliminar una propiedad integrada de una presentación?**

Las propiedades integradas forman parte integral de la presentación y no pueden eliminarse por completo. Sin embargo, puede cambiar sus valores o establecerlas en vacío si la propiedad específica lo permite.

**¿Qué ocurre si añado una propiedad personalizada que ya existe?**

Si añade una propiedad personalizada que ya existe, su valor actual será sobrescrito con el nuevo. No es necesario eliminar o comprobar la propiedad de antemano, ya que Aspose.Slides actualiza automáticamente el valor de la propiedad.

**¿Puedo acceder a las propiedades de la presentación sin cargarla completamente?**

Sí, puede acceder a las propiedades de la presentación sin cargarla completamente utilizando el método [get_presentation_info](https://reference.aspose.com/slides/python-net/aspose.slides/presentationfactory/get_presentation_info/) de la clase [PresentationFactory](https://reference.aspose.com/slides/python-net/aspose.slides/presentationfactory/). Luego, emplee el método [read_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentationinfo/read_document_properties/) de la clase [PresentationInfo](https://reference.aspose.com/slides/python-net/aspose.slides/presentationinfo/) para leer las propiedades de manera eficiente, ahorrando memoria y mejorando el rendimiento.
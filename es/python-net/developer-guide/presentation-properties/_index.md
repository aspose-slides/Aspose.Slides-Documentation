---
title: Gestionar propiedades de la presentación con Python
linktitle: Propiedades de la presentación
type: docs
weight: 70
url: /es/python-net/presentation-properties/
keywords:
- propiedades de PowerPoint
- propiedades de la presentación
- propiedades del documento
- propiedades incorporadas
- propiedades personalizadas
- propiedades avanzadas
- gestionar propiedades
- modificar propiedades
- metadatos del documento
- editar metadatos
- idioma de revisión
- idioma predeterminado
- PowerPoint
- OpenDocument
- presentación
- Python
- Aspose.Slides
description: "Domine las propiedades de la presentación en Aspose.Slides for Python via .NET y optimice la búsqueda, la marca y el flujo de trabajo en sus archivos de PowerPoint."
---
## **Introducción**

Aspose.Slides for Python via .NET admite **propiedades incorporadas** y **propiedades personalizadas** de documento. Utilice estas propiedades para leer y actualizar los metadatos de la presentación, como el autor, el título y los valores definidos por el usuario.

Aspose.Slides le permite trabajar con las propiedades de documento de la presentación a través de la clase [DocumentProperties](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/). Se devuelve una instancia de esta clase mediante [Presentation.document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/document_properties/). Los siguientes ejemplos muestran cómo leer, modificar y gestionar estas propiedades.

{{% alert color="info" title="Note" %}}
Aspose.Slides gestiona los metadatos de la aplicación y del productor al guardar presentaciones; estos campos identifican el software que creó el resultado.
{{% /alert %}}

## **Gestionar propiedades de la presentación**

Las propiedades de documento almacenan información descriptiva junto al contenido de la presentación. Se dividen en dos categorías:

- **Propiedades incorporadas** contienen metadatos estándar, como el título, el autor y las estadísticas del documento.
- **Propiedades personalizadas** almacenan pares nombre/valor definidos por el usuario.

Aspose.Slides for Python via .NET proporciona acceso a ambas categorías. En PowerPoint, seleccione **Archivo → Información → Propiedades → Propiedades avanzadas** para inspeccionar los metadatos del documento. El cuadro de diálogo agrupa la información en pestañas como **Resumen**, **Estadísticas**, **Contenido** y **Personalizado**. Utilice la pestaña **Personalizado** para gestionar las propiedades definidas por el usuario.

## **Leer propiedades públicas de una presentación cifrada**

Una contraseña de apertura normalmente protege tanto el contenido de la presentación como las propiedades del documento. Cuando una presentación está cifrada con [ProtectionManager.encrypt_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/encrypt_document_properties/) establecido en `False`, sus propiedades de documento permanecen públicas. Entonces una aplicación puede establecer [LoadOptions.only_load_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/only_load_document_properties/) en `True` y leer los metadatos públicos sin proporcionar la contraseña de apertura.

[LoadOptions.only_load_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/only_load_document_properties/) controla lo que Aspose.Slides carga; no descifra nada. Si las propiedades se incluyeron en el cifrado, cargarlas sin la contraseña falla. Si la presentación no está cifrada, la opción se ignora y se carga la presentación completa.

El ejemplo requiere una presentación cifrada cuyas propiedades de documento se dejaron públicas. Verifica el modo de carga mediante [ProtectionManager.is_only_document_properties_loaded](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/is_only_document_properties_loaded/) y luego lee las propiedades incorporadas a través de [Presentation.document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/document_properties/):

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.only_load_document_properties = True

with slides.Presentation("public-properties-encrypted.pptx", load_options) as presentation:
    if presentation.protection_manager.is_only_document_properties_loaded:
        document_properties = presentation.document_properties

        print("Author: " + document_properties.author)
        print("Title: " + document_properties.title)
        print("Keywords: " + document_properties.keywords)
    else:
        print("The presentation was not loaded in document-properties-only mode.")
```

En este modo, el contenido de las diapositivas no se carga. Diapositivas, patrones, diseños, formas, medios y otros objetos de la presentación no están disponibles. Las aplicaciones deben comprobar siempre [ProtectionManager.is_only_document_properties_loaded](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/is_only_document_properties_loaded/) antes de realizar una operación que requiera el modelo de objetos completo de la presentación.

{{% alert color="warning" title="Security" %}}
Los metadatos públicos pueden revelar nombres de autores, títulos, asuntos, palabras clave, información de la empresa, comentarios y valores personalizados. Cifre las propiedades sensibles junto con la presentación. Déjelas públicas solo cuando los sistemas de indexación, clasificación, búsqueda o gestión documental tengan un requisito específico para acceder a ellas sin contraseña.
{{% /alert %}}

## **Actualizar propiedades de una presentación cifrada**

Para un archivo PPTX cifrado, una presentación cargada con [LoadOptions.only_load_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/only_load_document_properties/) está destinada a leer los metadatos públicos. Aspose.Slides no puede guardar las propiedades modificadas de ese objeto solo de metadatos porque las propiedades públicas deben mantenerse coherentes con los datos correspondientes dentro de la presentación cifrada. Por lo tanto, actualizarlas requiere la contraseña de apertura correcta y una carga completa.

El ejemplo requiere una presentación PPTX cifrada con propiedades de documento públicas y una contraseña de apertura conocida. Abre la presentación completa con [LoadOptions.password](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/password/), actualiza las propiedades incorporadas públicas y guarda el resultado. Luego utiliza [PresentationInfo.is_encrypted](https://reference.aspose.com/slides/python-net/aspose.slides/presentationinfo/is_encrypted/) para verificar que el cifrado se mantiene y vuelve a abrir los metadatos públicos sin contraseña para comprobar los nuevos valores:

```python
import aspose.slides as slides

input_path = "public-properties-encrypted.pptx"
output_path = "updated-public-properties-encrypted.pptx"

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation(input_path, load_options) as presentation:
    document_properties = presentation.document_properties
    document_properties.title = "Updated Product Roadmap"
    document_properties.keywords = "roadmap, planning, indexed"
    
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

## **Acceder a propiedades incorporadas**

La clase [DocumentProperties](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/) expone los metadatos incorporados a través de propiedades tipadas, incluyendo [DocumentProperties.author](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/author/), [DocumentProperties.title](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/title/), y [DocumentProperties.created_time](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/created_time/). Este ejemplo abre una presentación existente e imprime sus metadatos almacenados en la consola. Los valores dependen de la presentación de entrada; algunos campos pueden estar vacíos.

```python
import aspose.slides as slides

with slides.Presentation("AccessBuiltInProperties.pptx") as presentation:
    document_properties = presentation.document_properties

    print("Category:", document_properties.category)
    print("Content status:", document_properties.content_status)
    print("Creation date:", document_properties.created_time)
    print("Author:", document_properties.author)
    print("Comments:", document_properties.comments)
    print("Keywords:", document_properties.keywords)
    print("Last modified by:", document_properties.last_saved_by)
    print("Manager:", document_properties.manager)
    print("Modified date:", document_properties.last_saved_time)
    print("Presentation format:", document_properties.presentation_format)
    print("Last print date:", document_properties.last_printed)
    print("Is shared between producers:", document_properties.shared_doc)
    print("Subject:", document_properties.subject)
    print("Title:", document_properties.title)
```

## **Modificar propiedades incorporadas**

Para actualizar los metadatos incorporados, asigne valores a las propiedades modificables expuestas por [Presentation.document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/document_properties/). Este ejemplo abre una presentación existente, establece [DocumentProperties.author](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/author/), [DocumentProperties.title](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/title/), [DocumentProperties.subject](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/subject/), [DocumentProperties.comments](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/comments/), y [DocumentProperties.manager](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/manager/), luego guarda la presentación actualizada con [Presentation.save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/). El PPTX guardado contiene los nuevos metadatos.

```python
import aspose.slides as slides

with slides.Presentation("ModifyBuiltInProperties.pptx") as presentation:
    document_properties = presentation.document_properties

    document_properties.author = "Aspose.Slides for Python via .NET"
    document_properties.title = "Manage PowerPoint Presentation Properties"
    document_properties.subject = "Modify Built-in Properties"
    document_properties.comments = "Aspose description"
    document_properties.manager = "Aspose manager"

    presentation.save("DocumentProperties_output.pptx", slides.export.SaveFormat.PPTX)
```

## **Gestionar la base de hipervínculos**

[DocumentProperties.hyperlink_base](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/hyperlink_base/) almacena la base a nivel de documento para hipervínculos relativos. Es útil al mover una presentación y sus archivos vinculados a otra ubicación. Es independiente del [Hyperlink.external_url](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/external_url/) de un hipervínculo individual: cambiar la base no reescribe las direcciones de enlace almacenadas ni modifica los destinos absolutos.

El ejemplo requiere una presentación que contenga tanto un enlace relativo, como `target.html`, como un enlace absoluto a un archivo o sitio web. Lee la base existente, asigna una nueva dirección base y guarda y vuelve a abrir la presentación para comprobar el valor. Luego elimina la base con `""` y verifica el valor vacío en un archivo guardado por separado. Reemplace la dirección base del ejemplo con la ubicación de sus archivos vinculados.

```python
import aspose.slides as slides

with slides.Presentation("hyperlinks.pptx") as presentation:
    print("Original base:", presentation.document_properties.hyperlink_base)

    new_base = "https://example.com/new/"
    presentation.document_properties.hyperlink_base = new_base
    presentation.save("hyperlinks-updated.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("hyperlinks-updated.pptx") as updated_presentation:
    print("Base preserved:", updated_presentation.document_properties.hyperlink_base == new_base)

    updated_presentation.document_properties.hyperlink_base = ""
    updated_presentation.save("hyperlinks-cleared.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("hyperlinks-cleared.pptx") as cleared_presentation:
    print("Base cleared:", cleared_presentation.document_properties.hyperlink_base == "")
```

Los dos mensajes de verificación deberían imprimir `True`. Eliminar la base deja intactas las direcciones de los hipervínculos individuales.

Un enlace relativo a `target.pptx` abrió `old/target.pptx` cuando la base apuntaba a la carpeta `old`. Después de cambiar la base a la carpeta `new`, guardar y volver a abrir la presentación, el mismo enlace abrió `new/target.pptx`. Un enlace absoluto siguió abriendo el mismo archivo. Pruebe sus enlaces relativos en PowerPoint antes y después de mover la presentación o cambiar su base.

## **Agregar propiedades personalizadas a la presentación**

Las propiedades personalizadas almacenan metadatos que no tienen un campo incorporado correspondiente. El método [DocumentProperties.set_custom_property_value](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/set_custom_property_value/) le permite asignar un valor mediante el nombre de la propiedad. Este ejemplo crea una presentación, añade dos valores de texto y un valor entero de versión, y guarda la presentación con [Presentation.save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/). Asignar un valor a un nombre existente reemplaza el valor de esa propiedad.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    document_properties = presentation.document_properties

    document_properties.set_custom_property_value("Reviewed by", "John Smith")
    document_properties.set_custom_property_value("Confidentiality level", "Internal")
    document_properties.set_custom_property_value("Document version", 2)

    presentation.save("CustomDocumentProperties_output.pptx", slides.export.SaveFormat.PPTX)
```

## **Acceder y modificar propiedades personalizadas**

Este ejemplo abre una presentación que contiene propiedades personalizadas y usa [DocumentProperties.count_of_custom_properties](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/count_of_custom_properties/) para iterar sobre ellas. [DocumentProperties.get_custom_property_name](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/get_custom_property_name/) acepta un índice basado en cero y devuelve el nombre utilizado por [DocumentProperties.set_custom_property_value](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/set_custom_property_value/). El ejemplo requiere una presentación cuyas propiedades personalizadas sean todas strings. Imprime cada nombre y valor original, sustituye cada valor por una cadena numerada y guarda los cambios. Si no hay propiedades personalizadas, el bucle no realiza cambios.

```python
import aspose.slides as slides

with slides.Presentation("AccessAndModifyProperties.pptx") as presentation:
    document_properties = presentation.document_properties

    for i in range(document_properties.count_of_custom_properties):
        property_name = document_properties.get_custom_property_name(i)
        property_value = [""]
        document_properties.get_custom_property_value(property_name, property_value)

        print("Custom property name:", property_name)
        print("Custom property value:", property_value[0])

        document_properties.set_custom_property_value(property_name, "New Value " + str(i + 1))

    presentation.save("CustomProperties_output.pptx", slides.export.SaveFormat.PPTX)
```

[DocumentProperties.get_custom_property_value](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/get_custom_property_value/) devuelve el valor mediante la lista de un solo elemento pasada como segundo argumento. El marcador de posición debe coincidir con el tipo de la propiedad almacenada: use `[""]` para una cadena o `[0]` para un entero. Un tipo no coincidente genera una `InvalidCastException`; elija el marcador de posición de acuerdo con el esquema de sus propiedades personalizadas.

## **Ejemplo en vivo**

Pruebe la aplicación en línea [**Ver y editar metadatos de PowerPoint**](https://products.aspose.app/slides/metadata) para ver cómo trabajar con las propiedades de documento usando la API de Aspose.Slides:

[![Ver y editar metadatos de PowerPoint](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **Preguntas frecuentes**

**¿Cómo puedo eliminar una propiedad incorporada de una presentación?**

Las propiedades incorporadas son una parte integral de la presentación y no pueden eliminarse por completo. Sin embargo, puede cambiar sus valores o establecerlas vacías si la propiedad específica lo permite.

**¿Qué ocurre si añado una propiedad personalizada que ya existe?**

Si añade una propiedad personalizada que ya existe, su valor actual será sobrescrito por el nuevo. No es necesario eliminar o comprobar la propiedad de antemano, ya que Aspose.Slides actualiza automáticamente el valor de la propiedad.

**¿Puedo acceder a las propiedades de la presentación sin cargarla completamente?**

Sí. Utilice [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/python-net/aspose.slides/presentationfactory/get_presentation_info/) y luego [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentationinfo/read_document_properties/) para leer los metadatos de documento almacenados sin crear una instancia de [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/). Consulte [Crear un inventario ligero de presentaciones](/slides/es/python-net/examine-presentation/) para un ejemplo completo de informe y limitaciones específicas de formato.

**¿Puedo leer las propiedades públicas de una presentación cifrada sin su contraseña de apertura?**

Sí. La presentación debe haber sido cifrada con [ProtectionManager.encrypt_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/encrypt_document_properties/) establecido en `False`, y debe cargarse con [LoadOptions.only_load_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/only_load_document_properties/) establecido en `True`.

**¿Puedo actualizar un archivo PPTX cifrado en modo solo propiedades de documento?**

No. Los datos de propiedades públicas y cifradas deben permanecer consistentes, por lo que actualizar un archivo PPTX cifrado requiere cargar la presentación completa con la contraseña de apertura correcta.
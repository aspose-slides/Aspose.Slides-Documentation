---
title: Gestionar propiedades de la presentación en Python
linktitle: Propiedades de la presentación
type: docs
weight: 70
url: /es/python-java/presentation-properties/
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
- Idioma de corrección
- Idioma predeterminado
- PowerPoint
- OpenDocument
- Presentación
- Python
- Aspose.Slides
description: "Domine las propiedades de la presentación en Aspose.Slides for Python via Java y optimice la búsqueda, la marca y el flujo de trabajo en sus archivos PowerPoint y OpenDocument."
---
## **Introducción**

Aspose.Slides for Python via Java admite **propiedades integradas** y **personalizadas** del documento. Utilice estas propiedades para leer y actualizar los metadatos de la presentación, como el autor, el título y los valores definidos por el usuario.

Aspose.Slides le permite trabajar con las propiedades del documento de la presentación mediante la clase [DocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/). Una instancia de esta clase se devuelve mediante [Presentation.getDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getDocumentProperties). Los siguientes ejemplos muestran cómo leer, modificar y gestionar estas propiedades.

{{% alert color="info" title="Note" %}}
Aspose.Slides gestiona los metadatos de aplicación y productor al guardar presentaciones; estos campos identifican el software que creó el resultado.
{{% /alert %}}

## **Gestionar propiedades de la presentación**

Las propiedades del documento almacenan información descriptiva junto al contenido de la presentación. Se dividen en dos categorías:

- **Propiedades integradas** contienen metadatos estándar, como el título, el autor y las estadísticas del documento.
- **Propiedades personalizadas** almacenan pares nombre/valor definidos por el usuario.

Aspose.Slides for Python via Java proporciona acceso a ambas categorías. En PowerPoint, seleccione **Archivo → Información → Propiedades → Propiedades avanzadas** para inspeccionar los metadatos del documento. El cuadro de diálogo agrupa la información en pestañas como **Resumen**, **Estadísticas**, **Contenido** y **Personalizado**. Utilice la pestaña **Personalizado** para gestionar las propiedades definidas por el usuario.

## **Leer propiedades públicas de una presentación cifrada**

Normalmente una contraseña de apertura protege tanto el contenido de la presentación como las propiedades del documento. Cuando una presentación se cifra después de llamar a [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) con `False`, sus propiedades del documento permanecen públicas. Entonces una aplicación puede llamar a [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) con `True` y leer los metadatos públicos sin proporcionar la contraseña de apertura.

[LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) controla lo que Aspose.Slides carga; no descifra nada. Si las propiedades estaban incluidas en el cifrado, cargarlas sin la contraseña falla. Si la presentación no está cifrada, la opción se ignora y se carga la presentación completa.

El ejemplo requiere una presentación cifrada cuyas propiedades del documento se dejaron públicas. Verifica el modo de carga mediante [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/python-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) y luego lee las propiedades integradas a través de [Presentation.getDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getDocumentProperties):

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

En este modo, el contenido de las diapositivas no se carga. Las diapositivas, los maestros, los diseños, las formas, los medios y otros objetos de la presentación no están disponibles. Las aplicaciones deben siempre comprobar [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/python-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) antes de ejecutar una operación que requiera el modelo de objetos completo de la presentación.

{{% alert color="warning" title="Warning" %}}
Los metadatos públicos pueden revelar nombres de autores, títulos, asuntos, palabras clave, información de la empresa, comentarios y valores personalizados. Encripte las propiedades sensibles junto con la presentación. Déjelas públicas solo cuando los sistemas de indexado, clasificación, búsqueda o gestión documental tengan un requisito específico para acceder a ellas sin contraseña.
{{% /alert %}}

## **Actualizar propiedades de una presentación cifrada**

Para un archivo PPTX cifrado, una presentación cargada después de llamar a [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) con `True` está destinada a leer los metadatos públicos. Aspose.Slides no puede guardar las propiedades modificadas de ese objeto solo de metadatos porque las propiedades públicas deben permanecer coherentes con los datos correspondientes dentro de la presentación cifrada. Por lo tanto, actualizarlas requiere la contraseña de apertura correcta y una carga completa.

El ejemplo requiere una presentación PPTX cifrada con propiedades del documento públicas y una contraseña de apertura conocida. Abre la presentación completa con [LoadOptions.setPassword](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setPassword), actualiza las propiedades integradas públicas y guarda el resultado. A continuación utiliza [PresentationInfo.isEncrypted](https://reference.aspose.com/slides/python-java/aspose.slides/presentationinfo/#isEncrypted) para verificar que el cifrado se conserva y vuelve a abrir los metadatos públicos sin contraseña para comprobar los nuevos valores:

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

Si una aplicación no tiene permiso para descifrar o cargar el contenido de la presentación, debe tratar las propiedades públicas de un archivo PPTX cifrado como de solo lectura.

## **Acceder a propiedades integradas**

La clase [DocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/) expone los metadatos integrados mediante métodos getter, incluidos [getAuthor](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getAuthor), [getTitle](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getTitle) y [getCreatedTime](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getCreatedTime). Este ejemplo abre una presentación existente e imprime sus metadatos almacenados en la consola. Los valores dependen de la presentación de entrada; algunos campos pueden estar vacíos.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("AccessBuiltInProperties.pptx")
try:
    document_properties = presentation.getDocumentProperties()

    print("Category:", document_properties.getCategory())
    print("Content status:", document_properties.getContentStatus())
    print("Creation date:", document_properties.getCreatedTime())
    print("Author:", document_properties.getAuthor())
    print("Comments:", document_properties.getComments())
    print("Keywords:", document_properties.getKeywords())
    print("Last modified by:", document_properties.getLastSavedBy())
    print("Manager:", document_properties.getManager())
    print("Modified date:", document_properties.getLastSavedTime())
    print("Presentation format:", document_properties.getPresentationFormat())
    print("Last print date:", document_properties.getLastPrinted())
    print("Is shared between producers:", document_properties.getSharedDoc())
    print("Subject:", document_properties.getSubject())
    print("Title:", document_properties.getTitle())
finally:
    presentation.dispose()
```

## **Modificar propiedades integradas**

Para actualizar los metadatos integrados, utilice los métodos setter del objeto devuelto por [Presentation.getDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getDocumentProperties). Este ejemplo abre una presentación existente, llama a [setAuthor](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#setAuthor), [setTitle](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#setTitle), [setSubject](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#setSubject), [setComments](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#setComments) y [setManager](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#setManager), y luego guarda la presentación actualizada con [Presentation.save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save). El PPTX guardado contiene los nuevos metadatos.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("ModifyBuiltInProperties.pptx")
try:
    document_properties = presentation.getDocumentProperties()

    document_properties.setAuthor("Aspose.Slides for Python via Java")
    document_properties.setTitle("Manage PowerPoint Presentation Properties")
    document_properties.setSubject("Modify Built-in Properties")
    document_properties.setComments("Aspose description")
    document_properties.setManager("Aspose manager")

    presentation.save("DocumentProperties_output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Gestionar la base de hipervínculo**

[DocumentProperties.getHyperlinkBase](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getHyperlinkBase) devuelve la base a nivel de documento para hipervínculos relativos. Utilice [DocumentProperties.setHyperlinkBase](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#setHyperlinkBase) para cambiarla o borrarla. Esto es útil al mover una presentación y sus archivos vinculados a otra ubicación. Es independiente del [Hyperlink.getExternalUrl](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#getExternalUrl) de un hipervínculo individual: cambiar la base no reescribe las direcciones almacenadas ni modifica los destinos absolutos.

El ejemplo requiere una presentación que contenga tanto un enlace relativo, como `target.html`, y un enlace absoluto, como `https://example.org/absolute.html`. Lee la base existente, asigna una nueva dirección base y guarda y vuelve a abrir la presentación para comprobar el valor. Luego borra la base con una cadena vacía y verifica el valor vacío en un archivo guardado por separado. Reemplace la dirección base de ejemplo con la ubicación de sus archivos vinculados.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("hyperlinks.pptx")
try:
    print("Original base:", presentation.getDocumentProperties().getHyperlinkBase())

    new_base = "https://example.com/new/"
    presentation.getDocumentProperties().setHyperlinkBase(new_base)
    presentation.save("hyperlinks-updated.pptx", SaveFormat.Pptx)

    updated_presentation = Presentation("hyperlinks-updated.pptx")
    try:
        print("Base preserved:", new_base == updated_presentation.getDocumentProperties().getHyperlinkBase())

        updated_presentation.getDocumentProperties().setHyperlinkBase("")
        updated_presentation.save("hyperlinks-cleared.pptx", SaveFormat.Pptx)

        cleared_presentation = Presentation("hyperlinks-cleared.pptx")
        try:
            print("Base cleared:", "" == cleared_presentation.getDocumentProperties().getHyperlinkBase())
        finally:
            cleared_presentation.dispose()
    finally:
        updated_presentation.dispose()
finally:
    presentation.dispose()
```

Los dos mensajes de verificación deberían imprimir `True`. Borrar la base deja intactas las direcciones de los hipervínculos individuales.

Un enlace relativo a `target.pptx` abrió `old/target.pptx` cuando la base apuntaba a la carpeta `old`. Después de cambiar la base a la carpeta `new`, guardar y volver a abrir la presentación, el mismo enlace abrió `new/target.pptx`. Un enlace absoluto siguió abriendo el mismo archivo. Pruebe sus enlaces relativos en PowerPoint antes y después de mover la presentación o cambiar su base.

## **Añadir propiedades personalizadas a la presentación**

Las propiedades personalizadas almacenan metadatos que no tienen un campo integrado correspondiente. El método [DocumentProperties.set_Item](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#set_Item) le permite asignar un valor mediante el nombre de la propiedad. Este ejemplo crea una presentación, añade dos valores de texto y un valor entero de versión (usando `jpype.JInt` para pasar un entero Java), y guarda la presentación con [Presentation.save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save). Asignar un valor a un nombre existente reemplaza el valor de esa propiedad.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    document_properties = presentation.getDocumentProperties()

    document_properties.set_Item("Reviewed by", "John Smith")
    document_properties.set_Item("Confidentiality level", "Internal")
    document_properties.set_Item("Document version", jpype.JInt(2))

    presentation.save("CustomDocumentProperties_output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Acceder y modificar propiedades personalizadas**

Este ejemplo abre una presentación que contiene propiedades personalizadas y utiliza [getCountOfCustomProperties](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getCountOfCustomProperties) para iterar sobre ellas. [getCustomPropertyName](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getCustomPropertyName) acepta un índice basado en cero y devuelve el nombre usado por [DocumentProperties.set_Item](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#set_Item). El ejemplo imprime cada nombre y valor original, reemplaza cada valor con una cadena numerada sin importar su tipo original, y guarda los cambios. Si no existen propiedades personalizadas, el bucle no realiza cambios.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("AccessAndModifyProperties.pptx")
try:
    document_properties = presentation.getDocumentProperties()

    for i in range(document_properties.getCountOfCustomProperties()):
        property_name = document_properties.getCustomPropertyName(i)
        property_value = document_properties.get_Item(property_name)

        print("Custom property name:", property_name)
        print("Custom property value:", property_value)

        document_properties.set_Item(property_name, f"New Value {i + 1}")

    presentation.save("CustomProperties_output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Ejemplo en vivo**

Pruebe la aplicación en línea [**Ver y editar metadatos de PowerPoint**](https://products.aspose.app/slides/metadata) para ver cómo trabajar con las propiedades del documento mediante la API de Aspose.Slides:

[![Ver y editar metadatos de PowerPoint](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **FAQ**

**¿Cómo puedo eliminar una propiedad integrada de una presentación?**

Las propiedades integradas son una parte integral de la presentación y no pueden eliminarse por completo. Sin embargo, puede cambiar sus valores o establecerlas en vacío si la propiedad específica lo permite.

**¿Qué ocurre si añado una propiedad personalizada que ya existe?**

Si añade una propiedad personalizada que ya existe, su valor actual se sobrescribirá con el nuevo. No es necesario eliminar o comprobar la propiedad previamente, ya que Aspose.Slides actualiza automáticamente el valor de la propiedad.

**¿Puedo acceder a las propiedades de la presentación sin cargarla completamente?**

Sí. Utilice [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/python-java/aspose.slides/presentationfactory/#getPresentationInfo) y luego [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentationinfo/#readDocumentProperties) para leer los metadatos almacenados del documento sin crear una instancia de [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/). Consulte [Crear un inventario ligero de presentaciones](/slides/es/python-java/examine-presentation/) para un ejemplo completo de informe y limitaciones específicas del formato.

**¿Puedo leer propiedades públicas de una presentación cifrada sin su contraseña de apertura?**

Sí. La presentación debe haber sido cifrada después de llamar a [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) con `False`, y debe cargarse después de llamar a [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) con `True`.

**¿Puedo actualizar un archivo PPTX cifrado en modo solo de propiedades de documento?**

No. Los datos de propiedades públicas y cifradas deben permanecer coherentes, por lo que actualizar un archivo PPTX cifrado requiere cargar la presentación completa con la contraseña de apertura correcta.
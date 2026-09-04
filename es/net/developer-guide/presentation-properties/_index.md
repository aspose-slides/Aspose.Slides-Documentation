---
title: Gestionar propiedades de la presentación en .NET
linktitle: Propiedades de la presentación
type: docs
weight: 70
url: /es/net/presentation-properties/
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
- presentación
- .NET
- C#
- Aspose.Slides
description: "Domine las propiedades de la presentación en Aspose.Slides para .NET y optimice la búsqueda, la marca y el flujo de trabajo en sus archivos PowerPoint y OpenDocument."
---
## **Introducción**

Aspose.Slides for .NET admite dos tipos de propiedades de documento: **Integradas** y **Personalizadas**. Ambos tipos de propiedades pueden accederse y gestionarse fácilmente mediante la API de Aspose.Slides for .NET.

Aspose.Slides permite trabajar con las propiedades del documento de una presentación a través de la interfaz [IDocumentProperties](https://reference.aspose.com/slides/es/net/aspose.slides/idocumentproperties/). Una instancia de esta interfaz se devuelve mediante [IPresentation.DocumentProperties](https://reference.aspose.com/slides/es/net/aspose.slides/ipresentation/documentproperties/). Los ejemplos siguientes muestran cómo leer, modificar y gestionar estas propiedades.

{{% alert color="info" title="Nota" %}}
Tenga en cuenta que los campos **Application** y **Producer** no pueden modificarse, ya que siempre mostrarán "Aspose Ltd." y "Aspose.Slides for .NET x.x.x".
{{% /alert %}} 

## **Gestionar propiedades de la presentación**

Microsoft PowerPoint proporciona una función para añadir propiedades a los archivos de presentación. Estas propiedades de documento permiten almacenar información útil junto con los archivos. Existen dos tipos de propiedades de documento:

- Propiedades definidas por el sistema (integradas)
- Propiedades definidas por el usuario (personalizadas)

Las propiedades **integradas** contienen información general sobre el documento, como el título del documento, el nombre del autor, estadísticas del documento y más.

Las propiedades **personalizadas** son definidas por los usuarios como pares **Nombre/Valor**, donde tanto el nombre como el valor son especificados por el usuario.

Con Aspose.Slides for .NET, los desarrolladores pueden acceder y modificar tanto las propiedades integradas como las personalizadas.

Microsoft PowerPoint permite a los usuarios gestionar las propiedades del documento haciendo clic en el ícono de Office y luego seleccionando **Archivo → Información → Propiedades**. Después de elegir **Propiedades avanzadas**, aparece un cuadro de diálogo donde puede gestionar todas las propiedades del documento del archivo de presentación.

En el cuadro de diálogo **Propiedades**, hay varias pestañas, como **General**, **Resumen**, **Estadísticas**, **Contenido** y **Personalizado**. Cada pestaña ofrece opciones para configurar tipos específicos de información relacionada con el archivo de PowerPoint. La pestaña **Personalizado** se utiliza para gestionar propiedades definidas por el usuario.

## **Leer propiedades públicas de una presentación cifrada**

Una contraseña de apertura normalmente protege tanto el contenido de la presentación como las propiedades del documento. Cuando una presentación está cifrada con [IProtectionManager.EncryptDocumentProperties](https://reference.aspose.com/slides/es/net/aspose.slides/iprotectionmanager/encryptdocumentproperties/) establecido en `false`, sus propiedades de documento permanecen públicas. Una aplicación puede entonces establecer [LoadOptions.OnlyLoadDocumentProperties](https://reference.aspose.com/slides/es/net/aspose.slides/loadoptions/onlyloaddocumentproperties/) en `true` y leer los metadatos públicos sin proporcionar la contraseña de apertura.

`OnlyLoadDocumentProperties` controla lo que Aspose.Slides carga; no descifra nada. Si las propiedades estaban incluidas en el cifrado, cargarlas sin la contraseña falla. Si la presentación no está cifrada, la opción se ignora y se carga la presentación completa.

El siguiente ejemplo verifica el modo de carga mediante [IProtectionManager.IsOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/es/net/aspose.slides/iprotectionmanager/isonlydocumentpropertiesloaded/) y luego lee las propiedades integradas mediante [IPresentation.DocumentProperties](https://reference.aspose.com/slides/es/net/aspose.slides/ipresentation/documentproperties/):

```csharp
using System;
using Aspose.Slides;

var loadOptions = new LoadOptions { OnlyLoadDocumentProperties = true };
using var presentation = new Presentation("public-properties-encrypted.pptx", loadOptions);

if (presentation.ProtectionManager.IsOnlyDocumentPropertiesLoaded)
{
    var properties = presentation.DocumentProperties;

    Console.WriteLine("Author: " + properties.Author);
    Console.WriteLine("Title: " + properties.Title);
    Console.WriteLine("Keywords: " + properties.Keywords);
}
else
{
    Console.WriteLine("The presentation was not loaded in document-properties-only mode.");
}
```

En este modo, el contenido de las diapositivas no se carga. Diapositivas, maestros, diseños, formas, medios y otros objetos de la presentación no están disponibles. Las aplicaciones deberían siempre comprobar `IsOnlyDocumentPropertiesLoaded` antes de realizar una operación que requiera el modelo de objetos completo de la presentación.

{{% alert color="warning" title="Seguridad" %}}
Los metadatos públicos pueden exponer nombres de autores, títulos, asuntos, palabras clave, información de la empresa, comentarios y valores personalizados. Cifre las propiedades sensibles junto con la presentación. Déjelas públicas solo cuando los sistemas de indexación, clasificación, búsqueda o gestión documental tengan un requisito específico para acceder a ellas sin una contraseña.
{{% /alert %}}

## **Actualizar propiedades de una presentación cifrada**

Para un archivo PPTX cifrado, una presentación cargada con `OnlyLoadDocumentProperties` está pensada para leer metadatos públicos. Aspose.Slides no puede guardar propiedades modificadas de ese objeto solo de metadatos porque las propiedades públicas deben mantenerse consistentes con los datos correspondientes dentro de la presentación cifrada. Por tanto, actualizarlas requiere la contraseña de apertura correcta y una carga completa.

El siguiente ejemplo abre la presentación con [LoadOptions.Password](https://reference.aspose.com/slides/es/net/aspose.slides/loadoptions/password/), actualiza las propiedades integradas públicas y guarda el resultado. Luego utiliza [IPresentationInfo.IsEncrypted](https://reference.aspose.com/slides/es/net/aspose.slides/ipresentationinfo/isencrypted/) para verificar que el cifrado se conserva y vuelve a abrir los metadatos públicos sin contraseña para comprobar los nuevos valores:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

const string inputPath = "public-properties-encrypted.pptx";
const string outputPath = "updated-public-properties-encrypted.pptx";

{
    var loadOptions = new LoadOptions { Password = "open_password" };
    using var presentation = new Presentation(inputPath, loadOptions);

    presentation.DocumentProperties.Title = "Updated Product Roadmap";
    presentation.DocumentProperties.Keywords = "roadmap, planning, indexed";
    presentation.Save(outputPath, SaveFormat.Pptx);
}

var presentationInfo = PresentationFactory.Instance.GetPresentationInfo(outputPath);
Console.WriteLine("The presentation is encrypted: " + presentationInfo.IsEncrypted);

var metadataLoadOptions = new LoadOptions { OnlyLoadDocumentProperties = true };
using var metadataPresentation = new Presentation(outputPath, metadataLoadOptions);

if (metadataPresentation.ProtectionManager.IsOnlyDocumentPropertiesLoaded)
{
    Console.WriteLine("Title: " + metadataPresentation.DocumentProperties.Title);
    Console.WriteLine("Keywords: " + metadataPresentation.DocumentProperties.Keywords);
}
else
{
    Console.WriteLine("The presentation was not loaded in document-properties-only mode.");
}
```

Si una aplicación no tiene permiso para descifrar o cargar el contenido de la presentación, debe tratar las propiedades públicas de un archivo PPTX cifrado como de solo lectura.

## **Acceder a propiedades integradas**

Estas propiedades, tal como las expone la interfaz [IDocumentProperties](https://reference.aspose.com/slides/es/net/aspose.slides/idocumentproperties/), incluyen: **Creator** (Autor), **Description**, **Keywords**, **Created** (Fecha de creación), **Modified** (Fecha de modificación), **Printed** (Fecha del último imprimado), **LastModifiedBy**, **SharedDoc** (indica si el documento se comparte entre diferentes productores), **PresentationFormat**, **Subject**, **Title**, y más.

```cs
using Aspose.Slides;

// Instanciar la clase Presentation que representa un archivo de presentación.
using Presentation presentation = new Presentation("AccessBuiltInProperties.pptx");

// Obtener una referencia al objeto de tipo IDocumentProperties asociado a la presentación.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// Mostrar las propiedades integradas.
Console.WriteLine("Category : " + documentProperties.Category);
Console.WriteLine("Content status : " + documentProperties.ContentStatus);
Console.WriteLine("Creation date : " + documentProperties.CreatedTime);
Console.WriteLine("Author : " + documentProperties.Author);
Console.WriteLine("Comments : " + documentProperties.Comments);
Console.WriteLine("Key words : " + documentProperties.Keywords);
Console.WriteLine("Last modified by : " + documentProperties.LastSavedBy);
Console.WriteLine("Manager : " + documentProperties.Manager);
Console.WriteLine("Modified date : " + documentProperties.LastSavedTime);
Console.WriteLine("Presentation format : " + documentProperties.PresentationFormat);
Console.WriteLine("Last print date : " + documentProperties.LastPrinted);
Console.WriteLine("Is shared between producers : " + documentProperties.SharedDoc);
Console.WriteLine("Subject : " + documentProperties.Subject);
Console.WriteLine("Title : " + documentProperties.Title);
```

## **Modificar propiedades integradas**

Modificar las propiedades integradas de los archivos de presentación es tan sencillo como acceder a ellas. Simplemente puede asignar un valor de cadena a cualquier propiedad deseada, y el valor de la propiedad se actualizará. En el ejemplo a continuación, demostramos cómo modificar las propiedades de documento integradas de un archivo de presentación.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Instanciar la clase Presentation que representa un archivo de presentación.
using Presentation presentation = new Presentation("ModifyBuiltInProperties.pptx");

// Obtener una referencia al objeto de tipo IDocumentProperties asociado a la presentación.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// Establecer las propiedades integradas.
documentProperties.Author = "Aspose.Slides for .NET";
documentProperties.Title = "Manage PowerPoint Presentation Properties";
documentProperties.Subject = "Modify Built-in Properties";
documentProperties.Comments = "Aspose description";
documentProperties.Manager = "Aspose manager";

// Guardar la presentación en un archivo.
presentation.Save("DocumentProperties_output.pptx", SaveFormat.Pptx);
```

## **Agregar propiedades personalizadas a la presentación**

Las propiedades personalizadas de la presentación permiten a los desarrolladores almacenar metadatos adicionales o información específica dentro de un archivo de presentación. Aspose.Slides facilita la creación y gestión de estas propiedades personalizadas mediante programación. Los ejemplos siguientes demuestran cómo agregar propiedades personalizadas a sus presentaciones.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Instanciar la clase Presentation.
using Presentation presentation = new Presentation();

// Obtener una referencia al objeto de tipo IDocumentProperties asociado a la presentación.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// Agregar propiedades personalizadas.
documentProperties["Reviewed by"] = "John Smith";
documentProperties["Confidentiality level"] = "Internal";
documentProperties["Document version"] = 2;

// Guardar la presentación en un archivo.
presentation.Save("CustomDocumentProperties_output.pptx", SaveFormat.Pptx);
```

## **Acceder y modificar propiedades personalizadas**

Aspose.Slides también permite a los desarrolladores acceder a propiedades personalizadas existentes y modificar sus valores con facilidad. Esta funcionalidad ayuda a mantener metadatos precisos y soporta actualizaciones dinámicas basadas en la entrada del usuario o la lógica de negocio. Los ejemplos a continuación ilustran cómo obtener y actualizar valores de propiedades personalizadas dentro de una presentación.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Instanciar la clase Presentation que representa un archivo PPTX.
using Presentation presentation = new Presentation("AccessAndModifyProperties.pptx");

// Obtener una referencia al objeto de tipo IDocumentProperties asociado a la presentación.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// Acceder y modificar las propiedades personalizadas.
for (int i = 0; i < documentProperties.CountOfCustomProperties; i++)
{
    string propertyName = documentProperties.GetCustomPropertyName(i);
    object propertyValue = documentProperties[propertyName];

    // Mostrar el nombre y el valor de la propiedad personalizada.
    Console.WriteLine("Custom property name : " + propertyName);
    Console.WriteLine("Custom property value : " + propertyValue);

    // Modificar el valor de la propiedad personalizada.
    documentProperties[propertyName] = "New Value " + (i + 1);
}

// Guardar la presentación en un archivo.
presentation.Save("CustomProperties_output.pptx", SaveFormat.Pptx);
```

## **Ejemplo en vivo**

Pruebe la aplicación en línea [**Ver y editar metadatos de PowerPoint**](https://products.aspose.app/slides/es/metadata) para ver cómo trabajar con las propiedades del documento usando la API de Aspose.Slides:

[![Ver y editar metadatos de PowerPoint](slides-metadata.png)](https://products.aspose.app/slides/es/metadata)

## **Preguntas frecuentes**

**¿Cómo puedo eliminar una propiedad integrada de una presentación?**

Las propiedades integradas forman parte esencial de la presentación y no pueden eliminarse por completo. Sin embargo, puede cambiar sus valores o establecerlas en vacío si la propiedad específica lo permite.

**¿Qué ocurre si añado una propiedad personalizada que ya existe?**

Si añade una propiedad personalizada que ya existe, su valor actual será sobrescrito con el nuevo valor. No es necesario eliminarla ni comprobarla previamente, ya que Aspose.Slides actualiza automáticamente el valor de la propiedad.

**¿Puedo acceder a las propiedades de la presentación sin cargarla completamente?**

Sí. Use [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/es/net/aspose.slides/presentationfactory/getpresentationinfo/) y luego [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/es/net/aspose.slides/ipresentationinfo/readdocumentproperties/) para leer los metadatos del documento almacenados sin crear una instancia de [Presentation](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/). Consulte [Build a Lightweight Presentation Inventory](/slides/es/net/examine-presentation/) para un ejemplo completo de informe y limitaciones específicas por formato.

**¿Puedo leer propiedades públicas de una presentación cifrada sin su contraseña de apertura?**

Sí. La presentación debe haber sido cifrada con `EncryptDocumentProperties` establecido en `false`, y debe cargarse con `OnlyLoadDocumentProperties` establecido en `true`.

**¿Puedo actualizar un archivo PPTX cifrado en modo solo propiedades de documento?**

No. Los datos de propiedades públicas y cifradas deben permanecer consistentes, por lo que actualizar un archivo PPTX cifrado requiere cargar la presentación completa con la contraseña de apertura correcta.
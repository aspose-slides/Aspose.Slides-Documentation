---
title: Administrar propiedades de presentaciones PowerPoint en C#
linktitle: Propiedades de la presentación
type: docs
weight: 70
url: /es/net/presentation-properties/
keywords:
- propiedades de PowerPoint
- propiedades de la presentación
- propiedades del documento
- propiedades integradas
- propiedades personalizadas
- propiedades avanzadas
- acceder a propiedades
- modificar propiedades
- gestionar propiedades
- metadatos del documento
- editar metadatos
- idioma de revisión
- PowerPoint
- presentación
- C#
- Csharp
- Aspose.Slides for .NET
description: "Aprenda cómo administrar, leer y editar fácilmente las propiedades de documentos PowerPoint usando Aspose.Slides for .NET en C#. ¡Mejore la productividad y automatice su flujo de trabajo!"
---

## **Visión general**

Aspose.Slides para .NET admite dos tipos de propiedades de documento: **Integradas** y **Personalizadas**. Ambos tipos de propiedades pueden accederse y administrarse fácilmente mediante la API de Aspose.Slides para .NET.

Para manejar las propiedades del documento, Aspose.Slides proporciona la interfaz [IDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/) accesible a través de la propiedad [Presentation.DocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/presentation/documentproperties/). Los desarrolladores pueden aprovechar la interfaz [IDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/) del objeto `Presentation` para leer, modificar y administrar sin problemas las propiedades de la presentación, como se muestra en los ejemplos a continuación.

{{% alert color="primary" %}} 
Por favor, tenga en cuenta que los campos **Application** y **Producer** no pueden modificarse, ya que siempre mostrarán "Aspose Ltd." y "Aspose.Slides for .NET x.x.x".
{{% /alert %}} 

## **Administrar propiedades de la presentación**

Microsoft PowerPoint ofrece una función para agregar propiedades a los archivos de presentación. Estas propiedades de documento permiten almacenar información útil junto con los archivos. Existen dos tipos de propiedades de documento:

- Propiedades definidas por el sistema (integradas)
- Propiedades definidas por el usuario (personalizadas)

**Integradas** las propiedades contienen información general sobre el documento, como el título del documento, el nombre del autor, estadísticas del documento y más.

**Personalizadas** las propiedades son definidas por los usuarios como pares **Nombre/Valor**, donde tanto el nombre como el valor son especificados por el usuario.

Usando Aspose.Slides para .NET, los desarrolladores pueden acceder y modificar tanto las propiedades integradas como las personalizadas.

Microsoft PowerPoint permite a los usuarios administrar las propiedades del documento haciendo clic en el ícono de Office y luego seleccionando **Archivo → Información → Propiedades**. Después de elegir **Propiedades avanzadas**, aparece un cuadro de diálogo donde puede administrar todas las propiedades del documento del archivo de presentación.

En el cuadro de diálogo **Propiedades**, hay varias pestañas, como **General**, **Resumen**, **Estadísticas**, **Contenido** y **Personalizado**.  
Cada pestaña brinda opciones para configurar tipos específicos de información relacionada con el archivo PowerPoint. La pestaña **Personalizado** se utiliza para administrar propiedades definidas por el usuario.

## **Acceder a propiedades integradas**

Estas propiedades, según lo expone la interfaz [IDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/), incluyen: **Creator** (Autor), **Description**, **Keywords**, **Created** (Fecha de creación), **Modified** (Fecha de modificación), **Printed** (Fecha de la última impresión), **LastModifiedBy**, **SharedDoc** (indica si el documento se comparte entre diferentes productores), **PresentationFormat**, **Subject**, **Title**, y más.
```cs
// Instanciar la clase Presentation que representa un archivo de presentación.
using Presentation presentation = new Presentation("AccessBuiltInProperties.pptx");

// Get a reference to the object of type IDocumentProperties associated with the presentation.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// Display the Built-in properties.
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

Modificar las propiedades integradas de los archivos de presentación es tan fácil como acceder a ellas. Simplemente puede asignar un valor de cadena a cualquier propiedad deseada y el valor de la propiedad se actualizará. En el ejemplo a continuación, demostramos cómo modificar las propiedades integradas de un archivo de presentación.
```cs
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

Las propiedades personalizadas de la presentación permiten a los desarrolladores almacenar metadatos adicionales o información específica dentro de un archivo de presentación. Aspose.Slides facilita la creación y gestión de estas propiedades personalizadas mediante programación. Los siguientes ejemplos demuestran cómo agregar propiedades personalizadas a sus presentaciones.
```cs
// Instanciar la clase Presentation.
using Presentation presentation = new Presentation();

// Get a reference to the object of type IDocumentProperties associated with the presentation.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// Add custom properties.
documentProperties["Reviewed by"] = "John Smith";
documentProperties["Confidentiality level"] = "Internal";
documentProperties["Document version"] = 2;

// Save the presentation to a file.
presentation.Save("CustomDocumentProperties_output.pptx", SaveFormat.Pptx);
```


## **Acceder y modificar propiedades personalizadas**

Aspose.Slides también permite a los desarrolladores acceder a propiedades personalizadas existentes y modificar sus valores fácilmente. Esta funcionalidad ayuda a mantener metadatos precisos y admite actualizaciones dinámicas basadas en la entrada del usuario o la lógica empresarial. Los ejemplos a continuación ilustran cómo obtener y actualizar los valores de propiedades personalizadas dentro de una presentación.
```cs
// Instanciar la clase Presentation que representa un archivo PPTX.
using Presentation presentation = new Presentation("AccessAndModifyProperties.pptx");

// Get a reference to the object of type IDocumentProperties associated with the presentation.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// Access and modify the custom properties.
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

// Save the presentation to a file.
presentation.Save("CustomProperties_output.pptx", SaveFormat.Pptx);
```


## **Ejemplo en vivo**

Pruebe la aplicación en línea [**View & Edit PowerPoint Metadata**](https://products.aspose.app/slides/metadata) para ver cómo trabajar con las propiedades del documento usando la API de Aspose.Slides:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## ***FAQ**

**¿Cómo puedo eliminar una propiedad integrada de una presentación?**

Las propiedades integradas son una parte integral de la presentación y no pueden eliminarse por completo. Sin embargo, puede cambiar sus valores o establecerlas en vacío si la propiedad específica lo permite.

**¿Qué ocurre si añado una propiedad personalizada que ya existe?**

Si agrega una propiedad personalizada que ya existe, su valor actual será sobrescrito con el nuevo. No es necesario eliminar o verificar la propiedad antes, ya que Aspose.Slides actualiza automáticamente el valor de la propiedad.

**¿Puedo acceder a las propiedades de la presentación sin cargar completamente la presentación?**

Sí, puede acceder a las propiedades de la presentación sin cargarla completamente usando el método `GetPresentationInfo` de la clase [PresentationFactory](https://reference.aspose.com/slides/net/aspose.slides/presentationfactory/). Luego, utilice el método `ReadDocumentProperties` proporcionado por la interfaz [IPresentationInfo](https://reference.aspose.com/slides/net/aspose.slides/ipresentationinfo/) para leer las propiedades de manera eficiente, ahorrando memoria y mejorando el rendimiento.
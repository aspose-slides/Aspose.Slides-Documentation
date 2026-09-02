---
title: Administrar propiedades de presentación en .NET
linktitle: Propiedades de la presentación
type: docs
weight: 70
url: /es/net/presentation-properties/
keywords:
- Propiedades de PowerPoint
- Propiedades de presentación
- Propiedades de documento
- Propiedades integradas
- Propiedades personalizadas
- Propiedades avanzadas
- Gestionar propiedades
- Modificar propiedades
- Metadatos de documento
- Editar metadatos
- Idioma de corrección
- Idioma predeterminado
- PowerPoint
- OpenDocument
- presentación
- .NET
- C#
- Aspose.Slides
description: "Domine las propiedades de presentación en Aspose.Slides for .NET y agilice la búsqueda, la marca y el flujo de trabajo en sus archivos PowerPoint y OpenDocument."
---
## **Introducción**

Aspose.Slides for .NET admite dos tipos de propiedades de documento: **Integradas** y **Personalizadas**. Ambos tipos de propiedades pueden accederse y gestionarse fácilmente mediante la API de Aspose.Slides for .NET.

Aspose.Slides le permite trabajar con las propiedades de documento de una presentación a través de la interfaz [IDocumentProperties](https://reference.aspose.com/slides/es/net/aspose.slides/idocumentproperties/) . Una instancia de esta interfaz se devuelve mediante la propiedad [Presentation.DocumentProperties](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/documentproperties/) . Los siguientes ejemplos muestran cómo leer, modificar y gestionar estas propiedades.

{{% alert color="info" title="Note" %}}
Tenga en cuenta que los campos **Application** y **Producer** no pueden modificarse, ya que siempre mostrarán "Aspose Ltd." y "Aspose.Slides for .NET x.x.x".
{{% /alert %}} 

## **Gestionar propiedades de la presentación**

Microsoft PowerPoint ofrece una función para añadir propiedades a los archivos de presentación. Estas propiedades de documento permiten almacenar información útil junto con los archivos. Existen dos tipos de propiedades de documento:

- Propiedades del sistema (integradas)
- Propiedades definidas por el usuario (personalizadas)

Las propiedades **integradas** contienen información general sobre el documento, como el título del documento, el nombre del autor, estadísticas del documento, entre otras.

Las propiedades **personalizadas** se definen por los usuarios como pares **Nombre/Valor**, donde tanto el nombre como el valor son especificados por el usuario.

Con Aspose.Slides for .NET, los desarrolladores pueden acceder y modificar tanto las propiedades integradas como las personalizadas.

Microsoft PowerPoint permite a los usuarios gestionar las propiedades del documento haciendo clic en el ícono de Office y luego seleccionando **File → Info → Properties**. Después de elegir **Advanced Properties**, aparece un cuadro de diálogo donde puede gestionar todas las propiedades del documento del archivo de presentación.

En el cuadro de diálogo **Properties**, hay varias pestañas, como **General**, **Summary**, **Statistics**, **Contents** y **Custom**. Cada pestaña proporciona opciones para configurar tipos específicos de información relacionados con el archivo PowerPoint. La pestaña **Custom** se utiliza para gestionar propiedades definidas por el usuario.

## **Acceder a propiedades integradas**

Estas propiedades, tal como las expone la interfaz [IDocumentProperties](https://reference.aspose.com/slides/es/net/aspose.slides/idocumentproperties/) , incluyen: **Creator** (Autor), **Description**, **Keywords**, **Created** (Fecha de creación), **Modified** (Fecha de modificación), **Printed** (Fecha de última impresión), **LastModifiedBy**, **SharedDoc** (indica si el documento se comparte entre diferentes productores), **PresentationFormat**, **Subject**, **Title**, y más.

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

Modificar las propiedades integradas de los archivos de presentación es tan sencillo como acceder a ellas. Simplemente asigne un valor de cadena a cualquier propiedad deseada, y el valor de la propiedad se actualizará. En el ejemplo a continuación, demostramos cómo modificar las propiedades de documento integradas de un archivo de presentación.

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

## **Añadir propiedades personalizadas a la presentación**

Las propiedades personalizadas de la presentación permiten a los desarrolladores almacenar metadatos adicionales o información específica dentro de un archivo de presentación. Aspose.Slides facilita la creación y gestión de estas propiedades personalizadas mediante programación. Los siguientes ejemplos demuestran cómo añadir propiedades personalizadas a sus presentaciones.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Instanciar la clase Presentation.
using Presentation presentation = new Presentation();

// Obtener una referencia al objeto de tipo IDocumentProperties asociado a la presentación.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// Añadir propiedades personalizadas.
documentProperties["Reviewed by"] = "John Smith";
documentProperties["Confidentiality level"] = "Internal";
documentProperties["Document version"] = 2;

// Guardar la presentación en un archivo.
presentation.Save("CustomDocumentProperties_output.pptx", SaveFormat.Pptx);
```

## **Acceder y modificar propiedades personalizadas**

Aspose.Slides también permite a los desarrolladores acceder a propiedades personalizadas existentes y modificar sus valores fácilmente. Esta funcionalidad ayuda a mantener metadatos precisos y soporta actualizaciones dinámicas basadas en la entrada del usuario o la lógica de negocio. Los ejemplos a continuación ilustran cómo recuperar y actualizar los valores de propiedades personalizadas dentro de una presentación.

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

Pruebe la aplicación en línea [**View & Edit PowerPoint Metadata**](https://products.aspose.app/slides/es/metadata) para ver cómo trabajar con las propiedades del documento mediante la API de Aspose.Slides:

[![Ver y editar metadatos de PowerPoint](slides-metadata.png)](https://products.aspose.app/slides/es/metadata)

## **Preguntas frecuentes**

**¿Cómo puedo eliminar una propiedad integrada de una presentación?**

Las propiedades integradas son una parte integral de la presentación y no pueden eliminarse por completo. Sin embargo, puede cambiar sus valores o establecerlas como vacías si la propiedad específica lo permite.

**¿Qué ocurre si añado una propiedad personalizada que ya existe?**

Si añade una propiedad personalizada que ya existe, su valor existente se sobrescribirá con el nuevo. No es necesario eliminar o comprobar la propiedad previamente, ya que Aspose.Slides actualiza automáticamente el valor de la propiedad.

**¿Puedo acceder a las propiedades de la presentación sin cargarla completamente?**

Sí. Utilice [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/es/net/aspose.slides/presentationfactory/getpresentationinfo/) y luego [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/es/net/aspose.slides/ipresentationinfo/readdocumentproperties/) para leer los metadatos del documento almacenados sin crear una instancia de [Presentation](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/). Consulte [Crear un inventario ligero de presentaciones](/slides/es/net/examine-presentation/) para ver un ejemplo completo de reporte y limitaciones específicas de formato.
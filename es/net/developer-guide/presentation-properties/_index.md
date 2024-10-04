---
title: Propiedades de la Presentación - Acceder o Modificar Propiedades de Presentación PowerPoint en C#
linktitle: Propiedades de la Presentación
type: docs
weight: 70
url: /es/net/presentation-properties/
keywords: "cómo eliminar el último modificado por en powerpoint, propiedades de PowerPoint, presentación de PowerPoint, C#, Csharp, Aspose.Slides para .NET"
description: "Propiedades de presentación PowerPoint en C# o .NET"
---


## **Ejemplo en Vivo**
Prueba la aplicación en línea [**Aspose.Slides Metadata**](https://products.aspose.app/slides/metadata) para ver cómo trabajar con las propiedades del documento a través de la API de Aspose.Slides:

[](https://products.aspose.app/slides/metadata)

[![todo:image_alt_text](slides-metadata.png)](https://products.aspose.app/slides/metadata)


## **Acerca de las Propiedades de la Presentación**
Como se describió anteriormente, Aspose.Slides para .NET admite dos tipos de propiedades de documento, que son propiedades **Integradas** y **Personalizadas**. Así, los desarrolladores pueden acceder a ambos tipos de propiedades mediante el uso de la API de Aspose.Slides para .NET. Aspose.Slides para .NET proporciona una clase [IDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties) que representa las propiedades del documento asociadas a un archivo de presentación a través de la propiedad [Presentation.DocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/documentproperties/properties/index). Los desarrolladores pueden usar la propiedad [IDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties) expuesta por el objeto **Presentation** para acceder a las propiedades del documento de los archivos de presentación como se describe a continuación:



{{% alert color="primary" %}} 

Tenga en cuenta que no puede establecer valores en los campos **Application** y **Producer**, porque Aspose Ltd. y Aspose.Slides para .NET x.x.x se mostrarán en estos campos.

{{% /alert %}} 


## **Gestionar Propiedades de la Presentación**
Microsoft PowerPoint proporciona una función para agregar algunas propiedades a los archivos de presentación. Estas propiedades de documento permiten almacenar información útil junto con los documentos (archivos de presentación). Hay dos tipos de propiedades de documento como se sigue

- Propiedades Definidas por el Sistema (Integradas)
- Propiedades Definidas por el Usuario (Personalizadas)

Las propiedades **Integradas** contienen información general sobre el documento como el título del documento, el nombre del autor, estadísticas del documento y así sucesivamente. Las propiedades **Personalizadas** son aquellas que son definidas por los usuarios como pares **Nombre/Valor**, donde tanto el nombre como el valor son definidos por el usuario. Usando Aspose.Slides para .NET, los desarrolladores pueden acceder y modificar los valores de las propiedades integradas así como de las propiedades personalizadas. Microsoft PowerPoint 2007 permite gestionar las propiedades del documento de los archivos de presentación. Todo lo que tienes que hacer es hacer clic en el ícono de Office y luego en el elemento del menú **Preparar | Propiedades | Propiedades Avanzadas** del Microsoft PowerPoint 2007. Después de seleccionar el elemento del menú **Propiedades Avanzadas**, aparecerá un diálogo que te permitirá gestionar las propiedades del documento del archivo de PowerPoint. En el **Diálogo de Propiedades**, puedes ver que hay muchas pestañas como **General, Resumen, Estadísticas, Contenidos y Personalizado**. Todas estas pestañas permiten configurar diferentes tipos de información relacionada con los archivos de PowerPoint. La pestaña **Personalizado** se utiliza para gestionar las propiedades personalizadas de los archivos de PowerPoint.
## **Acceder a Propiedades Integradas**
Estas propiedades expuestas por el objeto **IDocumentProperties** incluyen: **Creador (Autor)**, **Descripción**, **Palabras clave**, **Creado** (Fecha de Creación), **Modificado** (Fecha de Modificación), **Impreso** (Última Fecha de Impresión), **ÚltimoModificadoPor**, **Palabras clave**, **SharedDoc** (¿Está compartido entre diferentes productores?), **PresentationFormat**, **Asunto** y **Título**

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Presentations-Properties-AccessBuiltinProperties-AccessBuiltinProperties.cs" >}}
## **Modificar Propiedades Integradas**
Modificar las propiedades integradas de los archivos de presentación es tan fácil como acceder a ellas. Simplemente puedes asignar un valor de cadena a cualquier propiedad deseada y el valor de la propiedad se modificará. En el ejemplo dado a continuación, hemos demostrado cómo podemos modificar las propiedades del documento integradas del archivo de presentación.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Presentations-Properties-ModifyBuiltinProperties-ModifyBuiltinProperties.cs" >}}

## **Agregar Propiedades Personalizadas a la Presentación**
Aspose.Slides para .NET también permite a los desarrolladores agregar los valores personalizados para las propiedades del Documento de presentación. A continuación se muestra un ejemplo que muestra cómo establecer las propiedades personalizadas para una presentación.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Presentations-Properties-AddCustomDocumentProperties-AddCustomDocumentProperties.cs" >}}

## **Acceder y Modificar Propiedades Personalizadas**
Aspose.Slides para .NET también permite a los desarrolladores acceder a los valores de las propiedades personalizadas. A continuación se muestra un ejemplo que muestra cómo puedes acceder y modificar todas estas propiedades personalizadas para una presentación.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Presentations-Properties-AccessModifyingProperties-AccessModifyingProperties.cs" >}}

## **Comprobar si la Presentación ha sido Modificada o Creada**
Aspose.Slides para .NET proporciona una facilidad para comprobar si una presentación ha sido modificada o creada. A continuación se muestra un ejemplo que muestra cómo comprobar si la presentación ha sido creada o modificada.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Presentations-Properties-CheckPresentationCreatedorModifed-CheckPresentationCreatedorModifed.cs" >}}

Establecer el Idioma Predeterminado

## **Establecer el Idioma de Prueba**

Aspose.Slides proporciona la propiedad [LanguageId](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/languageid/) (expuesta por la clase [PortionFormat](https://reference.aspose.com/slides/net/aspose.slides/portionformat/)) para permitirte establecer el idioma de prueba para un documento de PowerPoint. El idioma de prueba es el idioma para el cual se verifican la ortografía y la gramática en PowerPoint.

Este código C# te muestra cómo establecer el idioma de prueba para un PowerPoint:

```c#
using (Presentation pres = new Presentation(pptxFileName))
{
    AutoShape autoShape = (AutoShape)pres.Slides[0].Shapes[0];

    IParagraph paragraph = autoShape.TextFrame.Paragraphs[0];
    paragraph.Portions.Clear();

    Portion newPortion = new Portion();

    IFontData font = new FontData("SimSun");
    IPortionFormat portionFormat = newPortion.PortionFormat;
    portionFormat.ComplexScriptFont = font;
    portionFormat.EastAsianFont = font;
    portionFormat.LatinFont = font;

    portionFormat.LanguageId = "zh-CN"; // establece el Id de un idioma de prueba
    
    newPortion.Text = "1。";
    paragraph.Portions.Add(newPortion);
}
```

## **Establecer el Idioma Predeterminado**

Este código C# te muestra cómo establecer el idioma predeterminado para toda una presentación de PowerPoint: 

```c#
LoadOptions loadOptions = new LoadOptions();
loadOptions.DefaultTextLanguage = "en-US";
using (Presentation pres = new Presentation(loadOptions))
{
    // Agrega una nueva forma rectangular con texto
    IAutoShape shp = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shp.TextFrame.Text = "Nuevo Texto";
    
    // Verifica el idioma de la primera porción
    Console.WriteLine(shp.TextFrame.Paragraphs[0].Portions[0].PortionFormat.LanguageId);
}
```
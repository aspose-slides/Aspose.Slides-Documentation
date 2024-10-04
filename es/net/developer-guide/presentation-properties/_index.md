---
title: Propiedades de Presentación - Acceder o Modificar Propiedades de Presentación de PowerPoint en C#
linktitle: Propiedades de Presentación
type: docs
weight: 70
url: /net/presentation-properties/
keywords: "cómo eliminar último modificado por en powerpoint, propiedades de PowerPoint, presentación de PowerPoint, C#, Csharp, Aspose.Slides para .NET"
description: "Propiedades de presentación de PowerPoint en C# o .NET"
---

## **Ejemplo en Vivo**
Prueba la aplicación online [**Aspose.Slides Metadata**](https://products.aspose.app/slides/metadata) para ver cómo trabajar con las propiedades del documento a través de la API de Aspose.Slides:

[](https://products.aspose.app/slides/metadata)

[![todo:texto_alt_imagen](slides-metadata.png)](https://products.aspose.app/slides/metadata)


## **Acerca de las Propiedades de Presentación**
Como hemos descrito anteriormente, Aspose.Slides para .NET admite dos tipos de propiedades de documento, que son propiedades **Integradas** y **Personalizadas**. Por lo tanto, los desarrolladores pueden acceder a ambos tipos de propiedades utilizando la API de Aspose.Slides para .NET. Aspose.Slides para .NET proporciona una clase [IDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties) que representa las propiedades del documento asociadas con un archivo de presentación a través de la propiedad [Presentation.DocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/documentproperties/properties/index). Los desarrolladores pueden usar la propiedad [IDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties) expuesta por el objeto **Presentation** para acceder a las propiedades del documento de los archivos de presentación como se describe a continuación:



{{% alert color="primary" %}} 

Tenga en cuenta que no puede establecer valores contra los campos **Application** y **Producer**, porque Aspose Ltd. y Aspose.Slides para .NET x.x.x se mostrarán contra estos campos.

{{% /alert %}} 


## **Gestionar Propiedades de Presentación**
Microsoft PowerPoint proporciona una función para agregar algunas propiedades a los archivos de presentación. Estas propiedades de documento permiten almacenar información útil junto con los documentos (archivos de presentación). Hay dos tipos de propiedades de documento como sigue

- Propiedades Definidas por el Sistema (Integradas)
- Propiedades Definidas por el Usuario (Personalizadas)

Las propiedades **Integradas** contienen información general sobre el documento como el título del documento, el nombre del autor, estadísticas del documento, etc. Las propiedades **Personalizadas** son aquellas que son definidas por los usuarios como pares **Nombre/Valor**, donde tanto el nombre como el valor son definidos por el usuario. Utilizando Aspose.Slides para .NET, los desarrolladores pueden acceder y modificar los valores de las propiedades integradas así como las propiedades personalizadas. Microsoft PowerPoint 2007 permite gestionar las propiedades del documento de los archivos de presentación. Todo lo que tiene que hacer es hacer clic en el ícono de Office y luego seleccionar el elemento del menú **Preparar | Propiedades | Propiedades Avanzadas** de Microsoft PowerPoint 2007. Después de seleccionar el elemento del menú **Propiedades Avanzadas**, aparecerá un cuadro de diálogo que le permitirá gestionar las propiedades del documento del archivo de PowerPoint. En el **Cuadro de Diálogo de Propiedades**, puede ver que hay muchas pestañas como **General, Resumen, Estadísticas, Contenidos y Personalizadas**. Todas estas pestañas permiten configurar diferentes tipos de información relacionada con los archivos de PowerPoint. La pestaña **Personalizada** se utiliza para gestionar las propiedades personalizadas de los archivos de PowerPoint.
## **Acceder a Propiedades Integradas**
Estas propiedades expuestas por el objeto **IDocumentProperties** incluyen: **Creador (Autor)**, **Descripción**, **Palabras clave**, **Creado** (Fecha de Creación), **Modificado** (Fecha de Modificación), **Impreso** (Última Fecha de Impresión), **ÚltimoModificadoPor**, **Palabras clave**, **SharedDoc** (¿Está compartido entre diferentes productores?), **PresentaciónFormato**, **Asunto** y **Título**

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Presentations-Properties-AccessBuiltinProperties-AccessBuiltinProperties.cs" >}}
## **Modificar Propiedades Integradas**
Modificar las propiedades integradas de los archivos de presentación es tan fácil como acceder a ellas. Simplemente puede asignar un valor de cadena a cualquier propiedad deseada y el valor de la propiedad se modificará. En el ejemplo que se presenta a continuación, hemos demostrado cómo podemos modificar las propiedades de documento integradas del archivo de presentación.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Presentations-Properties-ModifyBuiltinProperties-ModifyBuiltinProperties.cs" >}}

## **Agregar Propiedades Personalizadas de Presentación**
Aspose.Slides para .NET también permite a los desarrolladores agregar valores personalizados para las propiedades del Documento de presentación. A continuación se muestra un ejemplo que muestra cómo establecer las propiedades personalizadas para una presentación.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Presentations-Properties-AddCustomDocumentProperties-AddCustomDocumentProperties.cs" >}}

## **Acceder y Modificar Propiedades Personalizadas**
Aspose.Slides para .NET también permite a los desarrolladores acceder a los valores de las propiedades personalizadas. A continuación se muestra un ejemplo que muestra cómo puede acceder y modificar todas estas propiedades personalizadas para una presentación.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Presentations-Properties-AccessModifyingProperties-AccessModifyingProperties.cs" >}}

## **Verificar si la Presentación ha Sido Modificada o Creada**
Aspose.Slides para .NET proporciona una facilidad para verificar si una presentación ha sido modificada o creada. A continuación se muestra un ejemplo que muestra cómo verificar si la presentación ha sido creada o modificada.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Presentations-Properties-CheckPresentationCreatedorModifed-CheckPresentationCreatedorModifed.cs" >}}

Establecer Idioma Predeterminado

## **Establecer Idioma de Corrección**

Aspose.Slides proporciona la propiedad [LanguageId](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/languageid/) (expuesta por la clase [PortionFormat](https://reference.aspose.com/slides/net/aspose.slides/portionformat/)) para permitirle establecer el idioma de corrección para un documento de PowerPoint. El idioma de corrección es el idioma para el cual se verifican las ortografías y la gramática en PowerPoint.

Este código C# le muestra cómo establecer el idioma de corrección para un PowerPoint:

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

    portionFormat.LanguageId = "zh-CN"; // establecer el Id de un idioma de corrección
    
    newPortion.Text = "1。";
    paragraph.Portions.Add(newPortion);
}
```

## **Establecer Idioma Predeterminado**

Este código C# le muestra cómo establecer el idioma predeterminado para una presentación de PowerPoint completa: 

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
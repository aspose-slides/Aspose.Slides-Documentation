---
title: Gestionando Etiquetas y Datos Personalizados
type: docs
weight: 300
url: /es/net/managing-tags-and-custom-data
keywords: "Etiquetas, Datos personalizados, Valor para etiquetas, Agregar etiquetas, Presentación de PowerPoint, C#, Csharp, Aspose.Slides para .NET"
description: "Agregue etiquetas y datos personalizados a presentaciones de PowerPoint en C# o .NET"
---

## Almacenamiento de Datos en Archivos de Presentación

Los archivos PPTX—elementos con la extensión .pptx—se almacenan en el formato PresentationML, que es parte de la especificación Office Open XML. El formato Office Open XML define la estructura para los datos contenidos en las presentaciones.

Con una *diapositiva* siendo uno de los elementos en las presentaciones, una *parte de diapositiva* contiene el contenido de una sola diapositiva. Se permite que una parte de diapositiva tenga relaciones explícitas con muchas partes—como Etiquetas Definidas por el Usuario—definidas por ISO/IEC 29500.

Los datos personalizados (específicos de una presentación) o del usuario pueden existir como etiquetas ([ITagCollection](https://reference.aspose.com/slides/net/aspose.slides/itagcollection)) y CustomXmlParts ([ICustomXmlPartCollection](https://reference.aspose.com/slides/net/aspose.slides/icustomxmlpartcollection)).

{{% alert color="primary" %}} 

Las etiquetas son esencialmente pares de valores de clave de cadena. 

{{% /alert %}} 

## Obteniendo los Valores para Etiquetas

En las diapositivas, una etiqueta corresponde a la propiedad IDocumentProperties.Keywords. Este código de muestra te muestra cómo obtener el valor de una etiqueta con Aspose.Slides para .NET para [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation):

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   string keywords = pres.DocumentProperties.Keywords;
}
```

## Agregando Etiquetas a Presentaciones

Aspose.Slides te permite agregar etiquetas a presentaciones. Una etiqueta típicamente consiste en dos elementos:

- el nombre de una propiedad personalizada - `MyTag` 
- el valor de la propiedad personalizada - `My Tag Value`

Si necesitas clasificar algunas presentaciones basándote en una regla o propiedad específica, entonces puedes beneficiarte de agregar etiquetas a esas presentaciones. Por ejemplo, si deseas categorizar o agrupar todas las presentaciones de países de América del Norte, puedes crear una etiqueta de América del Norte y luego asignar los países relevantes (EE. UU., México y Canadá) como los valores.

Este código de muestra te muestra cómo agregar una etiqueta a una [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) usando Aspose.Slides para .NET:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   ITagCollection tags = pres.CustomData.Tags;
   pres.CustomData.Tags["MyTag"] = "My Tag Value";
}
```

Las etiquetas también se pueden establecer para [Slide](https://reference.aspose.com/slides/net/aspose.slides/slide):

```csharp
using(Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    slide.CustomData.Tags["tag"] = "value";
}
```

O para cualquier [Shape](https://reference.aspose.com/slides/net/aspose.slides/shape) individual:

```csharp
using(Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 50);
    shape.TextFrame.Text = "My text";
    shape.CustomData.Tags["tag"] = "value";
}
```
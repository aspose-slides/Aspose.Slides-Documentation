---
title: Administrar etiquetas y datos personalizados
type: docs
weight: 300
url: /es/net/managing-tags-and-custom-data
keywords: "Etiquetas, Datos personalizados, Valor de las etiquetas, Añadir etiquetas, Presentación de PowerPoint, C#, Csharp, Aspose.Slides para .NET"
description: "Añadir etiquetas y datos personalizados a presentaciones de PowerPoint en C# o .NET"
---

## **Almacenamiento de datos en archivos de presentación**

Los archivos PPTX—elementos con la extensión .pptx—se almacenan en el formato PresentationML, que es parte de la especificación Office Open XML. El formato Office Open XML define la estructura de los datos contenidos en las presentaciones. 

Con una *diapositiva* siendo uno de los elementos en las presentaciones, una *parte de diapositiva* contiene el contenido de una única diapositiva. A una parte de diapositiva se le permite tener relaciones explícitas con muchas partes—como etiquetas definidas por el usuario—definidas por ISO/IEC 29500. 

Los datos personalizados (específicos de una presentación) o del usuario pueden existir como etiquetas ([ITagCollection](https://reference.aspose.com/slides/net/aspose.slides/itagcollection)) y CustomXmlParts ([ICustomXmlPartCollection](https://reference.aspose.com/slides/net/aspose.slides/icustomxmlpartcollection)). 

{{% alert color="primary" %}} 
Las etiquetas son esencialmente pares de cadena‑clave. 
{{% /alert %}} 

## **Obtener los valores de las etiquetas**

En las diapositivas, una etiqueta corresponde a la propiedad IDocumentProperties.Keywords. Este fragmento de código muestra cómo obtener el valor de una etiqueta con Aspose.Slides para .NET para [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation):
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   string keywords = pres.DocumentProperties.Keywords;
}
```


## **Agregar etiquetas a presentaciones**

Aspose.Slides le permite agregar etiquetas a presentaciones. Una etiqueta normalmente consta de dos elementos: 

- el nombre de una propiedad personalizada - `MyTag` 
- el valor de la propiedad personalizada - `My Tag Value`

Si necesita clasificar algunas presentaciones basándose en una regla o propiedad específica, puede beneficiarse de agregar etiquetas a esas presentaciones. Por ejemplo, si desea agrupar o categorizar todas las presentaciones de países de América del Norte, puede crear una etiqueta “North American” y luego asignar los países relevantes (EE. UU., México y Canadá) como valores. 

Este fragmento de código muestra cómo agregar una etiqueta a una [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) usando Aspose.Slides para .NET:
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   ITagCollection tags = pres.CustomData.Tags;
   pres.CustomData.Tags["MyTag"] = "My Tag Value";
}
```


Las etiquetas también pueden establecerse para [Slide](https://reference.aspose.com/slides/net/aspose.slides/slide):
```csharp
using(Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    slide.CustomData.Tags["tag"] = "value";
}
```


O cualquier [Shape](https://reference.aspose.com/slides/net/aspose.slides/shape) individual:
```csharp
using(Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 50);
    shape.TextFrame.Text = "My text";
    shape.CustomData.Tags["tag"] = "value";
}
```


## **Preguntas frecuentes**

**¿Puedo eliminar todas las etiquetas de una presentación, diapositiva o forma en una sola operación?**

Sí. La [tag collection](https://reference.aspose.com/slides/net/aspose.slides/tagcollection/) admite una operación [clear](https://reference.aspose.com/slides/net/aspose.slides/tagcollection/clear/) que elimina todos los pares de clave‑valor a la vez.

**¿Cómo elimino una sola etiqueta por su nombre sin iterar sobre toda la colección?**

Utilice la operación [Remove(name)](https://reference.aspose.com/slides/net/aspose.slides/tagcollection/remove/) en la [TagCollection](https://reference.aspose.com/slides/net/aspose.slides/tagcollection/) para borrar la etiqueta por su clave.

**¿Cómo puedo obtener la lista completa de nombres de etiquetas para análisis o filtrado?**

Utilice [GetNamesOfTags](https://reference.aspose.com/slides/net/aspose.slides/tagcollection/getnamesoftags/) en la [tag collection](https://reference.aspose.com/slides/net/aspose.slides/tagcollection/); devuelve una matriz con todos los nombres de etiquetas.
---
title: Administrar etiquetas y datos personalizados en presentaciones en .NET
linktitle: Etiquetas y datos personalizados
type: docs
weight: 300
url: /es/net/managing-tags-and-custom-data/
keywords:
- propiedades del documento
- etiqueta
- datos personalizados
- añadir etiqueta
- pares de valores
- PowerPoint
- presentación
- .NET
- C#
- Aspose.Slides
description: "Aprenda cómo añadir, leer, actualizar y eliminar etiquetas y datos personalizados en Aspose.Slides para .NET, con ejemplos para presentaciones PowerPoint y OpenDocument."
---
## **Visión general**

Este artículo explica cómo Aspose.Slides trabaja con etiquetas y datos personalizados en presentaciones de PowerPoint. Describe brevemente cómo se almacenan los datos en archivos PPTX, indica que los datos específicos de la presentación pueden existir como etiquetas y partes XML personalizadas, y define las etiquetas como pares de cadena clave‑valor.

También muestra cómo leer los valores de las etiquetas y cómo añadir etiquetas a una presentación, a una diapositiva individual o a una forma. Además, el artículo cubre tareas comunes de gestión de etiquetas, como borrar todas las etiquetas, eliminar una etiqueta por nombre y recuperar la lista de nombres de etiquetas.

## **Almacenamiento de datos en archivos de presentación**

Los archivos PPTX—elementos con la extensión .pptx—se almacenan en el formato PresentationML, que forma parte de la especificación Office Open XML. El formato Office Open XML define la estructura de los datos contenidos en las presentaciones. 

Siendo una *diapositiva* uno de los elementos de las presentaciones, una *parte de diapositiva* contiene el contenido de una única diapositiva. A una parte de diapositiva se le permite tener relaciones explícitas con muchas partes—como las Etiquetas definidas por el usuario—definidas por ISO/IEC 29500. 

Los datos personalizados (específicos de una presentación) o del usuario pueden existir como etiquetas ([ITagCollection](https://reference.aspose.com/slides/es/net/aspose.slides/itagcollection)) y CustomXmlParts ([ICustomXmlPartCollection](https://reference.aspose.com/slides/es/net/aspose.slides/icustomxmlpartcollection)). 

{{% alert color="primary" %}} 
Las etiquetas son esencialmente pares de cadena‑clave. 
{{% /alert %}} 

## **Obtener valores de etiquetas**

En las diapositivas, una etiqueta corresponde a la propiedad IDocumentProperties.Keywords. Este fragmento de código muestra cómo obtener el valor de una etiqueta con Aspose.Slides para .NET para [Presentation](https://reference.aspose.com/slides/es/net/aspose.slides/presentation):

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   string keywords = pres.DocumentProperties.Keywords;
}
```

## **Añadir etiquetas a presentaciones**

Aspose.Slides le permite añadir etiquetas a presentaciones. Una etiqueta suele constar de dos elementos:

- el nombre de una propiedad personalizada - `MyTag`
- el valor de la propiedad personalizada - `My Tag Value`

Si necesita clasificar algunas presentaciones basándose en una regla o propiedad específica, puede beneficiarse de añadir etiquetas a esas presentaciones. Por ejemplo, si desea categorizar o agrupar todas las presentaciones de países de América del Norte, puede crear una etiqueta América del Norte y luego asignar los países relevantes (EE. UU., México y Canadá) como valores. 

Este fragmento de código muestra cómo añadir una etiqueta a una [Presentation](https://reference.aspose.com/slides/es/net/aspose.slides/presentation) usando Aspose.Slides para .NET:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   ITagCollection tags = pres.CustomData.Tags;
   pres.CustomData.Tags["MyTag"] = "My Tag Value";
}
```

Las etiquetas también pueden establecerse para [Slide](https://reference.aspose.com/slides/es/net/aspose.slides/slide):

```csharp
using(Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    slide.CustomData.Tags["tag"] = "value";
}
```

O cualquier [Shape](https://reference.aspose.com/slides/es/net/aspose.slides/shape) individual:

```csharp
using(Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 50);
    shape.TextFrame.Text = "My text";
    shape.CustomData.Tags["tag"] = "value";
}
```

### **Limitaciones**

Las etiquetas añadidas a través de la colección `CustomData.Tags` se almacenan únicamente dentro del archivo PowerPoint. **No** se transfieren a la estructura de etiquetas PDF cuando la presentación se exporta a PDF. En consecuencia, un identificador personalizado asignado como etiqueta no puede recuperarse del PDF etiquetado.

**Solución alternativa**: Puede almacenar un identificador personalizado en el **Texto alternativo** del objeto (p. ej., `shape.AlternativeText = \"MyId\"`). Después de exportar a PDF, el Texto alternativo puede aparecer en la estructura de etiquetas PDF.

## **Preguntas frecuentes**

**¿Puedo eliminar todas las etiquetas de una presentación, diapositiva o forma en una sola operación?**

Sí. La [colección de etiquetas](https://reference.aspose.com/slides/es/net/aspose.slides/tagcollection/) admite una operación [clear](https://reference.aspose.com/slides/es/net/aspose.slides/tagcollection/clear/) que elimina todos los pares clave‑valor de una vez.

**¿Cómo elimino una única etiqueta por su nombre sin iterar sobre toda la colección?**

Utilice la operación [Remove(name)](https://reference.aspose.com/slides/es/net/aspose.slides/tagcollection/remove/) en [TagCollection](https://reference.aspose.com/slides/es/net/aspose.slides/tagcollection/) para eliminar la etiqueta por su clave.

**¿Cómo puedo obtener la lista completa de nombres de etiquetas para análisis o filtrado?**

Utilice [GetNamesOfTags](https://reference.aspose.com/slides/es/net/aspose.slides/tagcollection/getnamesoftags/) en la [colección de etiquetas](https://reference.aspose.com/slides/es/net/aspose.slides/tagcollection/); devuelve una matriz con todos los nombres de etiquetas.
---
title: Rectángulo
type: docs
weight: 80
url: /net/rectangle/
keywords: "Crear rectángulo, forma de PowerPoint, presentación de PowerPoint, C#, Csharp, Aspose.Slides para .NET"
description: "Crear rectángulo en presentación de PowerPoint en C# o .NET"
---


## **Crear Rectángulo Simple**
Al igual que los temas anteriores, este también trata sobre agregar una forma y esta vez la forma de la que hablaremos es el Rectángulo. En este tema, hemos descrito cómo los desarrolladores pueden agregar rectángulos simples o formateados a sus diapositivas utilizando Aspose.Slides para .NET. Para agregar un rectángulo simple a una diapositiva seleccionada de la presentación, siga los pasos a continuación:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Obtenga la referencia de una diapositiva utilizando su índice.
1. Agregue una IAutoShape de tipo Rectángulo usando el método AddAutoShape expuesto por el objeto IShapes.
1. Escriba la presentación modificada como un archivo PPTX.

En el ejemplo dado a continuación, hemos agregado un rectángulo simple a la primera diapositiva de la presentación.

```c#
// Instanciar la clase Prseetation que representa el PPTX
using (Presentation pres = new Presentation())
{

    // Obtener la primera diapositiva
    ISlide sld = pres.Slides[0];

    // Agregar autoshape de tipo rectángulo
    sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);

    // Escribir el archivo PPTX en el disco
    pres.Save("RectShp1_out.pptx", SaveFormat.Pptx);
}
```


## **Crear Rectángulo Formateado**
Para agregar un rectángulo formateado a una diapositiva, siga los pasos a continuación:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Obtenga la referencia de una diapositiva utilizando su índice.
1. Agregue una IAutoShape de tipo Rectángulo usando el método AddAutoShape expuesto por el objeto IShapes.
1. Establezca el tipo de relleno del Rectángulo como Sólido.
1. Establezca el color del Rectángulo utilizando la propiedad SolidFillColor.Color expuesta por el objeto FillFormat asociado con el objeto IShape.
1. Establezca el color de las líneas del Rectángulo.
1. Establezca el ancho de las líneas del Rectángulo.
1. Escriba la presentación modificada como un archivo PPTX.
   Los pasos anteriores se implementan en el ejemplo dado a continuación.

```c#
// Instanciar la clase Prseetation que representa el PPTX
using (Presentation pres = new Presentation())
{

    // Obtener la primera diapositiva
    ISlide sld = pres.Slides[0];

    // Agregar autoshape de tipo rectángulo
    IShape shp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);

    // Aplicar algún formato a la forma del rectángulo
    shp.FillFormat.FillType = FillType.Solid;
    shp.FillFormat.SolidFillColor.Color = Color.Chocolate;

    // Aplicar algún formato a la línea del rectángulo
    shp.LineFormat.FillFormat.FillType = FillType.Solid;
    shp.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
    shp.LineFormat.Width = 5;

    // Escribir el archivo PPTX en el disco
    pres.Save("RectShp2_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```
---
title: Elipse
type: docs
weight: 30
url: /net/ellipse/
keywords: "Elipse, forma de PowerPoint, presentación de PowerPoint, C#, Csharp, Aspose.Slides para .NET"
description: "Crear elipse en presentación de PowerPoint en C# o .NET"
---


## **Crear Elipse**
En este tema, presentaremos a los desarrolladores cómo agregar formas de elipse a sus diapositivas utilizando Aspose.Slides para .NET. Aspose.Slides para .NET proporciona un conjunto más fácil de APIs para dibujar diferentes tipos de formas con solo unas pocas líneas de código. Para agregar una elipse simple a una diapositiva seleccionada de la presentación, siga los pasos a continuación:

1. Cree una instancia de la clase [Presentation ](https://reference.aspose.com/slides/net/aspose.slides/presentation)
1. Obtenga la referencia de una diapositiva utilizando su índice
1. Agregue una AutoShape de tipo Elipse utilizando el método AddAutoShape expuesto por el objeto IShapes
1. Escriba la presentación modificada como un archivo PPTX

En el ejemplo dado a continuación, hemos agregado una elipse a la primera diapositiva.

```c#
// Instanciar la clase Prseetation que representa el PPTX
using (Presentation pres = new Presentation())
{

    // Obtener la primera diapositiva
    ISlide sld = pres.Slides[0];

    // Agregar autoshape de tipo elipse
    sld.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 150, 150, 50);

    //Escribir el archivo PPTX en disco
    pres.Save("EllipseShp1_out.pptx", SaveFormat.Pptx);
}
```



## **Crear Elipse Formateada**
Para agregar una elipse mejor formateada a una diapositiva, siga los pasos a continuación:

1. Cree una instancia de la clase [Presentation ](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Obtenga la referencia de una diapositiva utilizando su índice.
1. Agregue una AutoShape de tipo Elipse utilizando el método AddAutoShape expuesto por el objeto IShapes.
1. Establezca el tipo de relleno de la elipse a sólido.
1. Establezca el color de la elipse utilizando la propiedad SolidFillColor.Color expuesta por el objeto FillFormat asociado con el objeto IShape.
1. Establezca el color de las líneas de la elipse.
1. Establezca el ancho de las líneas de la elipse.
1. Escriba la presentación modificada como un archivo PPTX.

En el ejemplo dado a continuación, hemos agregado una elipse formateada a la primera diapositiva de la presentación.

```c#
// Instanciar la clase Prseetation que representa el PPTX
using (Presentation pres = new Presentation())
{

    // Obtener la primera diapositiva
    ISlide sld = pres.Slides[0];

    // Agregar autoshape de tipo elipse
    IShape shp = sld.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 150, 150, 50);

    // Aplicar algún formato a la forma de elipse
    shp.FillFormat.FillType = FillType.Solid;
    shp.FillFormat.SolidFillColor.Color = Color.Chocolate;

    // Aplicar algún formato a la línea de la Elipse
    shp.LineFormat.FillFormat.FillType = FillType.Solid;
    shp.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
    shp.LineFormat.Width = 5;

    //Escribir el archivo PPTX en disco
    pres.Save("EllipseShp2_out.pptx", SaveFormat.Pptx);
}
```
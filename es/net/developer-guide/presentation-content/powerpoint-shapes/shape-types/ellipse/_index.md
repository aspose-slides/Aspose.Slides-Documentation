---
title: Elipse
type: docs
weight: 30
url: /es/net/ellipse/
keywords: "Elipse, forma de PowerPoint, presentación de PowerPoint, C#, Csharp, Aspose.Slides for .NET"
description: "Crear elipse en una presentación de PowerPoint en C# o .NET"
---

## **Crear elipse**
En este tema, presentaremos a los desarrolladores cómo agregar formas de elipse a sus diapositivas usando Aspose.Slides for .NET. Aspose.Slides for .NET ofrece un conjunto de API más sencillo para dibujar diferentes tipos de formas con solo unas pocas líneas de código. Para agregar una elipse simple a una diapositiva seleccionada de la presentación, siga los pasos a continuación:

1. Cree una instancia de la [Presentation ](https://reference.aspose.com/slides/net/aspose.slides/presentation)class
1. Obtenga la referencia de una diapositiva utilizando su índice
1. Agregue un AutoShape de tipo Elipse usando el método AddAutoShape expuesto por el objeto IShapes
1. Guarde la presentación modificada como un archivo PPTX

En el ejemplo siguiente, hemos agregado una elipse a la primera diapositiva.
```c#
 // Instanciar la clase Presentation que representa el PPTX
 using (Presentation pres = new Presentation())
 {
 
     // Obtener la primera diapositiva
     ISlide sld = pres.Slides[0];
 
     // Añadir una forma automática de tipo elipse
     sld.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 150, 150, 50);
 
     // Guardar el archivo PPTX en disco
     pres.Save("EllipseShp1_out.pptx", SaveFormat.Pptx);
 }
```




## **Crear elipse formateada**
Para agregar una elipse mejor formateada a una diapositiva, siga los pasos a continuación:

1. Cree una instancia de la [Presentation ](https://reference.aspose.com/slides/net/aspose.slides/presentation)class.
1. Obtenga la referencia de una diapositiva utilizando su índice.
1. Agregue un AutoShape de tipo Elipse usando el método AddAutoShape expuesto por el objeto IShapes.
1. Establezca el tipo de relleno de la elipse en sólido.
1. Establezca el color de la elipse usando la propiedad SolidFillColor.Color expuesta por el objeto FillFormat asociado al objeto IShape.
1. Establezca el color de las líneas de la elipse.
1. Establezca el ancho de las líneas de la elipse.
1. Guarde la presentación modificada como un archivo PPTX.

En el ejemplo siguiente, hemos agregado una elipse formateada a la primera diapositiva de la presentación.
```c#
// Instanciar la clase Presentation que representa el PPTX
using (Presentation pres = new Presentation())
{

    // Obtener la primera diapositiva
    ISlide sld = pres.Slides[0];

    // Añadir una forma automática de tipo elipse
    IShape shp = sld.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 150, 150, 50);

    // Aplicar algo de formato a la forma elipse
    shp.FillFormat.FillType = FillType.Solid;
    shp.FillFormat.SolidFillColor.Color = Color.Chocolate;

    // Aplicar algo de formato a la línea de la elipse
    shp.LineFormat.FillFormat.FillType = FillType.Solid;
    shp.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
    shp.LineFormat.Width = 5;

    //Escribir el archivo PPTX en disco
    pres.Save("EllipseShp2_out.pptx", SaveFormat.Pptx);
}
```


## **Preguntas frecuentes**

**¿Cómo establezco la posición y el tamaño exactos de una elipse respecto a las unidades de la diapositiva?**

Las coordenadas y los tamaños suelen especificarse **en puntos**. Para obtener resultados predecibles, base sus cálculos en el tamaño de la diapositiva y convierta los milímetros o pulgadas necesarios a puntos antes de asignar los valores.

**¿Cómo puedo colocar una elipse encima o debajo de otros objetos (controlar el orden de apilamiento)?**

Ajuste el orden de dibujo del objeto llevándolo al frente o enviándolo al fondo. Esto permite que la elipse se superponga a otros objetos o revele los que están debajo.

**¿Cómo animo la aparición o el énfasis de una elipse?**

[Aplicar](/slides/es/net/shape-animation/) efectos de entrada, énfasis o salida a la forma, y configure disparadores y temporización para orquestar cuándo y cómo se reproduce la animación.
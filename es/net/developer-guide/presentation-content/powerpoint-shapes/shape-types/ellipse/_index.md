---
title: Agregar elipses a presentaciones en .NET
linktitle: Elipse
type: docs
weight: 30
url: /es/net/ellipse/
keywords:
- elipse
- forma
- agregar elipse
- crear elipse
- dibujar elipse
- elipse formateada
- PowerPoint
- presentación
- .NET
- C#
- Aspose.Slides
description: "Aprenda a crear, formatear y manipular formas de elipse en Aspose.Slides para .NET en presentaciones PPT y PPTX, con ejemplos de código en C# incluidos."
---

## **Crear elipse**
En este tema, introduciremos a los desarrolladores cómo añadir formas elípticas a sus diapositivas usando Aspose.Slides for .NET. Aspose.Slides for .NET proporciona un conjunto de API más sencillo para dibujar diferentes tipos de formas con solo unas pocas líneas de código. Para añadir una elipse simple a una diapositiva seleccionada de la presentación, siga los pasos a continuación:

1. Crear una instancia de la clase [Presentation ](https://reference.aspose.com/slides/net/aspose.slides/presentation)
1. Obtener la referencia de una diapositiva usando su Index
1. Añadir un AutoShape de tipo Ellipse usando el método AddAutoShape expuesto por el objeto IShapes
1. Guardar la presentación modificada como un archivo PPTX

En el ejemplo que se muestra a continuación, hemos añadido una elipse a la primera diapositiva.
```c#
// Instanciar la clase Presentation que representa el PPTX
using (Presentation pres = new Presentation())
{
    // Obtener la primera diapositiva
    ISlide sld = pres.Slides[0];

    // Añadir autoshape de tipo elipse
    sld.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 150, 150, 50);

    // Escribir el archivo PPTX en disco
    pres.Save("EllipseShp1_out.pptx", SaveFormat.Pptx);
}
```




## **Crear elipse formateada**
Para añadir una elipse mejor formateada a una diapositiva, siga los pasos a continuación:

1. Crear una instancia de la clase [Presentation ](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Obtener la referencia de una diapositiva usando su Index.
1. Añadir un AutoShape de tipo Ellipse usando el método AddAutoShape expuesto por el objeto IShapes.
1. Establecer el tipo de relleno de la elipse a Solid.
1. Establecer el Color de la elipse usando la propiedad SolidFillColor.Color expuesta por el objeto FillFormat asociado al objeto IShape.
1. Establecer el Color de las líneas de la elipse.
1. Establecer el Ancho de las líneas de la elipse.
1. Guardar la presentación modificada como un archivo PPTX.

En el ejemplo que se muestra a continuación, hemos añadido una elipse formateada a la primera diapositiva de la presentación.
```c#
// Instanciar la clase Presentation que representa el PPTX
using (Presentation pres = new Presentation())
{

    // Obtener la primera diapositiva
    ISlide sld = pres.Slides[0];

    // Añadir autoshape de tipo elipse
    IShape shp = sld.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 150, 150, 50);

    // Aplicar algo de formato a la forma elipse
    shp.FillFormat.FillType = FillType.Solid;
    shp.FillFormat.SolidFillColor.Color = Color.Chocolate;

    // Aplicar algo de formato a la línea de la elipse
    shp.LineFormat.FillFormat.FillType = FillType.Solid;
    shp.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
    shp.LineFormat.Width = 5;

    //Write el archivo PPTX en disco
    pres.Save("EllipseShp2_out.pptx", SaveFormat.Pptx);
}
```


## **Preguntas frecuentes**

**¿Cómo establezco la posición exacta y el tamaño de una elipse respecto a las unidades de la diapositiva?**

Las coordenadas y los tamaños se especifican típicamente **en puntos**. Para obtener resultados predecibles, base sus cálculos en el tamaño de la diapositiva y convierta los milímetros o pulgadas requeridos a puntos antes de asignar los valores.

**¿Cómo puedo colocar una elipse por encima o por debajo de otros objetos (controlar el orden de apilamiento)?**

Ajuste el orden de dibujo del objeto llevándolo al frente o enviándolo al fondo. Esto permite que la elipse se superponga a otros objetos o revele los que están debajo de ella.

**¿Cómo animo la aparición o el énfasis de una elipse?**

[Apply](/slides/es/net/shape-animation/) efectos de entrada, énfasis o salida a la forma, y configure los disparadores y la temporización para orquestar cuándo y cómo se reproduce la animación.
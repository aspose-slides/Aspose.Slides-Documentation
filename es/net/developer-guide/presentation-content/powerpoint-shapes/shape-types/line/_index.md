---
title: Línea
type: docs
weight: 50
url: /es/net/Line/
keywords: "Línea, forma de PowerPoint, presentación de PowerPoint, C#, Csharp, Aspose.Slides para .NET"
description: "Agregar línea en presentación de PowerPoint en C# o .NET"
---

Aspose.Slides para .NET admite agregar diferentes tipos de formas a las diapositivas. En este tema, comenzaremos a trabajar con formas agregando líneas a las diapositivas. Usando Aspose.Slides para .NET, los desarrolladores no solo pueden crear líneas simples, sino que también se pueden dibujar algunas líneas elaboradas en las diapositivas.
## **Crear Línea Simple**
Para agregar una línea simple a una diapositiva seleccionada de la presentación, siga los pasos a continuación:

- Cree una instancia de la clase [Presentation ](https://reference.aspose.com/slides/net/aspose.slides/presentation).
- Obtenga la referencia de una diapositiva utilizando su índice.
- Agregue una AutoShape de tipo Línea utilizando el método [AddAutoShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/methods/addautoshape/index) expuesto por el objeto Shapes.
- Guarde la presentación modificada como un archivo PPTX.

En el ejemplo dado a continuación, hemos agregado una línea a la primera diapositiva de la presentación.

```c#
// Instanciar la clase PresentationEx que representa el archivo PPTX
using (Presentation pres = new Presentation())
{
    // Obtener la primera diapositiva
    ISlide sld = pres.Slides[0];

    // Agregar una autoshape de tipo línea
    sld.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);

    //Guardar el PPTX en Disco
    pres.Save("LineShape1_out.pptx", SaveFormat.Pptx);
}
```


## **Crear Línea en Forma de Flecha**
Aspose.Slides para .NET también permite a los desarrolladores configurar algunas propiedades de la línea para que se vea más atractiva. Intentemos configurar algunas propiedades de una línea para que se vea como una flecha. Siga los pasos a continuación para hacerlo:

- Cree una instancia de la clase [Presentation ](https://reference.aspose.com/slides/net/aspose.slides/presentation)[](http://www.aspose.com/api/net/slides/aspose.slides/)[](http://www.aspose.com/api/net/slides/aspose.slides/).
- Obtenga la referencia de una diapositiva utilizando su índice.
- Agregue una AutoShape de tipo Línea utilizando el método AddAutoShape expuesto por el objeto Shapes.
- Establezca el estilo de línea en uno de los estilos ofrecidos por Aspose.Slides para .NET.
- Establezca el ancho de la línea.
- Establezca el [Estilo de Guión](https://reference.aspose.com/slides/net/aspose.slides/linedashstyle) de la línea en uno de los estilos ofrecidos por Aspose.Slides para .NET.
- Establezca el [Estilo de Cabeza de Flecha](https://reference.aspose.com/slides/net/aspose.slides/linearrowheadstyle) y la longitud del punto de inicio de la línea.
- Establezca el Estilo de Cabeza de Flecha y la longitud del punto final de la línea.
- Guarde la presentación modificada como un archivo PPTX.

```c#
// Instanciar la clase PresentationEx que representa el archivo PPTX
using (Presentation pres = new Presentation())
{

    // Obtener la primera diapositiva
    ISlide sld = pres.Slides[0];

    // Agregar una autoshape de tipo línea
    IAutoShape shp = sld.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);

    // Aplicar algún formato a la línea
    shp.LineFormat.Style = LineStyle.ThickBetweenThin;
    shp.LineFormat.Width = 10;

    shp.LineFormat.DashStyle = LineDashStyle.DashDot;

    shp.LineFormat.BeginArrowheadLength = LineArrowheadLength.Short;
    shp.LineFormat.BeginArrowheadStyle = LineArrowheadStyle.Oval;

    shp.LineFormat.EndArrowheadLength = LineArrowheadLength.Long;
    shp.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;

    shp.LineFormat.FillFormat.FillType = FillType.Solid;
    shp.LineFormat.FillFormat.SolidFillColor.Color = Color.Maroon;

    //Guardar el PPTX en Disco
    pres.Save("LineShape2_out.pptx", SaveFormat.Pptx);
}
```
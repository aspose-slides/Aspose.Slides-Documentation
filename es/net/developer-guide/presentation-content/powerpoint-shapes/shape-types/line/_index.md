---
title: Línea
type: docs
weight: 50
url: /es/net/Line/
keywords: "Línea, forma de PowerPoint, presentación de PowerPoint, C#, Csharp, Aspose.Slides for .NET"
description: "Agregar línea en una presentación de PowerPoint en C# o .NET"
---

Aspose.Slides for .NET admite la incorporación de diferentes tipos de formas a las diapositivas. En este tema, comenzaremos a trabajar con formas añadiendo líneas a las diapositivas. Con Aspose.Slides for .NET, los desarrolladores pueden no solo crear líneas simples, sino también dibujar líneas más elaboradas en las diapositivas.
## **Crear línea simple**
Para añadir una línea simple a una diapositiva seleccionada de la presentación, siga los pasos a continuación:

- Crea una instancia de la clase [Presentation ](https://reference.aspose.com/slides/net/aspose.slides/presentation)class.
- Obtenga la referencia de una diapositiva usando su índice.
- Añada un AutoShape de tipo Line usando el método [AddAutoShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/methods/addautoshape/index) expuesto por el objeto Shapes.
- Guarde la presentación modificada como un archivo PPTX.

En el ejemplo que se muestra a continuación, hemos añadido una línea a la primera diapositiva de la presentación.
```c#
// Instanciar la clase PresentationEx que representa el archivo PPTX
using (Presentation pres = new Presentation())
{
    // Obtener la primera diapositiva
    ISlide sld = pres.Slides[0];

    // Añadir un autoshape de tipo línea
    sld.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);

    // Escribir el PPTX en disco
    pres.Save("LineShape1_out.pptx", SaveFormat.Pptx);
}
```


## **Crear línea con forma de flecha**
- Crea una instancia de la clase [Presentation ](https://reference.aspose.com/slides/net/aspose.slides/presentation)class[](http://www.aspose.com/api/net/slides/aspose.slides/)[](http://www.aspose.com/api/net/slides/aspose.slides/).
- Obtenga la referencia de una diapositiva usando su índice.
- Añada un AutoShape de tipo Line usando el método AddAutoShape expuesto por el objeto Shapes.
- Establezca el estilo de línea a uno de los estilos ofrecidos por Aspose.Slides for .NET.
- Establezca el ancho de la línea.
- Establezca el [Dash Style](https://reference.aspose.com/slides/net/aspose.slides/linedashstyle) de la línea a uno de los estilos ofrecidos por Aspose.Slides for .NET.
- Establezca el [Arrow Head Style](https://reference.aspose.com/slides/net/aspose.slides/linearrowheadstyle) y la longitud del punto de inicio de la línea.
- Establezca el estilo de punta de flecha y la longitud del punto final de la línea.
- Guarde la presentación modificada como un archivo PPTX.
```c#
// Instanciar la clase PresentationEx que representa el archivo PPTX
using (Presentation pres = new Presentation())
{

    // Obtener la primera diapositiva
    ISlide sld = pres.Slides[0];

    // Añadir un autoshape de tipo línea
    IAutoShape shp = sld.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);

    // Aplicar algo de formato a la línea
    shp.LineFormat.Style = LineStyle.ThickBetweenThin;
    shp.LineFormat.Width = 10;

    shp.LineFormat.DashStyle = LineDashStyle.DashDot;

    shp.LineFormat.BeginArrowheadLength = LineArrowheadLength.Short;
    shp.LineFormat.BeginArrowheadStyle = LineArrowheadStyle.Oval;

    shp.LineFormat.EndArrowheadLength = LineArrowheadLength.Long;
    shp.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;

    shp.LineFormat.FillFormat.FillType = FillType.Solid;
    shp.LineFormat.FillFormat.SolidFillColor.Color = Color.Maroon;

    // Escribir el PPTX en disco
    pres.Save("LineShape2_out.pptx", SaveFormat.Pptx);
}
```


## **Preguntas frecuentes**

**¿Puedo convertir una línea regular en un conector para que se "ajuste" a las formas?**

No. Una línea regular (un [AutoShape](https://reference.aspose.com/slides/net/aspose.slides/autoshape/) de tipo [Line](https://reference.aspose.com/slides/net/aspose.slides/shapetype/)) no se convierte automáticamente en un conector. Para que se ajuste a las formas, utilice el tipo [Connector](https://reference.aspose.com/slides/net/aspose.slides/connector/) dedicado y las [APIs correspondientes](/slides/es/net/connector/) para conexiones.

**¿Qué debo hacer si las propiedades de una línea se heredan del tema y es difícil determinar los valores finales?**

[Lea las propiedades efectivas](/slides/es/net/shape-effective-properties/) a través de las clases [ILineFormatEffectiveData](https://reference.aspose.com/slides/net/aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/net/aspose.slides/ilinefillformateffectivedata/)—estas ya tienen en cuenta la herencia y los estilos del tema.

**¿Puedo bloquear una línea contra la edición (movimiento, redimensionado)?**

Sí. Las formas proporcionan [objetos de bloqueo](https://reference.aspose.com/slides/net/aspose.slides/autoshape/autoshapelock/) que le permiten [denegar operaciones de edición](/slides/es/net/applying-protection-to-presentation/).
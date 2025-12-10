---
title: Agregar formas de línea a presentaciones en .NET
linktitle: Línea
type: docs
weight: 50
url: /es/net/Line/
keywords:
- línea
- crear línea
- agregar línea
- línea simple
- configurar línea
- personalizar línea
- estilo de guión
- punta de flecha
- PowerPoint
- presentación
- .NET
- C#
- Aspose.Slides
description: "Aprenda a manipular el formato de líneas en presentaciones de PowerPoint con Aspose.Slides para .NET. Descubra propiedades, métodos y ejemplos."
---

Aspose.Slides for .NET permite añadir diferentes tipos de formas a las diapositivas. En este tema, empezaremos a trabajar con formas añadiendo líneas a las diapositivas. Con Aspose.Slides for .NET, los desarrolladores pueden crear no solo líneas simples, sino también líneas elegantes en las diapositivas.  

## **Crear una línea simple**
Para añadir una línea simple a una diapositiva seleccionada de la presentación, siga los pasos a continuación:

- Crear una instancia de la clase [Presentación](https://reference.aspose.com/slides/net/aspose.slides/presentation).
- Obtener la referencia de una diapositiva usando su índice.
- Añadir un AutoShape de tipo Línea mediante el método [AddAutoShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/methods/addautoshape/index) expuesto por el objeto Shapes.
- Guardar la presentación modificada como archivo PPTX.

En el ejemplo que se muestra a continuación, se ha añadido una línea a la primera diapositiva de la presentación.  
```c#
 // Instanciar la clase PresentationEx que representa el archivo PPTX
using (Presentation pres = new Presentation())
{
    // Obtener la primera diapositiva
    ISlide sld = pres.Slides[0];

    // Agregar un autoshape de tipo línea
    sld.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);

    // Guardar el PPTX en disco
    pres.Save("LineShape1_out.pptx", SaveFormat.Pptx);
}
```


## **Crear una línea con forma de flecha**
Aspose.Slides for .NET también permite a los desarrolladores configurar algunas propiedades de la línea para que tenga un aspecto más atractivo. Vamos a configurar algunas propiedades de la línea para que parezca una flecha. Siga los pasos a continuación:

- Crear una instancia de la clase [Presentación](https://reference.aspose.com/slides/net/aspose.slides/presentation).
- Obtener la referencia de una diapositiva usando su índice.
- Añadir un AutoShape de tipo Línea mediante el método AddAutoShape expuesto por el objeto Shapes.
- Establecer el estilo de línea a uno de los estilos ofrecidos por Aspose.Slides for .NET.
- Establecer el ancho de la línea.
- Establecer el [Estilo de guión](https://reference.aspose.com/slides/net/aspose.slides/linedashstyle) de la línea a uno de los estilos ofrecidos por Aspose.Slides for .NET.
- Establecer el [Estilo de punta de flecha](https://reference.aspose.com/slides/net/aspose.slides/linearrowheadstyle) y la longitud del punto inicial de la línea.
- Establecer el estilo de punta de flecha y la longitud del punto final de la línea.
- Guardar la presentación modificada como archivo PPTX.  
```c#
 // Instanciar la clase PresentationEx que representa el archivo PPTX
using (Presentation pres = new Presentation())
{

    // Obtener la primera diapositiva
    ISlide sld = pres.Slides[0];

    // Añadir un autoshape de tipo línea
    IAutoShape shp = sld.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);

    // Aplicar formato a la línea
    shp.LineFormat.Style = LineStyle.ThickBetweenThin;
    shp.LineFormat.Width = 10;

    shp.LineFormat.DashStyle = LineDashStyle.DashDot;

    shp.LineFormat.BeginArrowheadLength = LineArrowheadLength.Short;
    shp.LineFormat.BeginArrowheadStyle = LineArrowheadStyle.Oval;

    shp.LineFormat.EndArrowheadLength = LineArrowheadLength.Long;
    shp.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;

    shp.LineFormat.FillFormat.FillType = FillType.Solid;
    shp.LineFormat.FillFormat.SolidFillColor.Color = Color.Maroon;

    //Guardar el PPTX en disco
    pres.Save("LineShape2_out.pptx", SaveFormat.Pptx);
}
```


## **FAQ**

**¿Puedo convertir una línea normal en un conector para que “se ajuste” a las formas?**

No. Una línea normal (un [AutoShape](https://reference.aspose.com/slides/net/aspose.slides/autoshape/) de tipo [Línea](https://reference.aspose.com/slides/net/aspose.slides/shapetype/)) no se convierte automáticamente en un conector. Para que se ajuste a las formas, use el tipo [Connector](https://reference.aspose.com/slides/net/aspose.slides/connector/) dedicado y las [APIs correspondientes](/slides/es/net/connector/) para conexiones.

**¿Qué debo hacer si las propiedades de una línea se heredan del tema y es difícil determinar los valores finales?**

[Lea las propiedades efectivas](/slides/es/net/shape-effective-properties/) a través de las interfaces [ILineFormatEffectiveData](https://reference.aspose.com/slides/net/aspose.slides/ilineformateffectivedata/) y [ILineFillFormatEffectiveData](https://reference.aspose.com/slides/net/aspose.slides/ilinefillformateffectivedata/); estas ya tienen en cuenta la herencia y los estilos del tema.

**¿Puedo bloquear una línea contra la edición (movimiento, cambio de tamaño)?**

Sí. Las formas proporcionan [objetos de bloqueo](https://reference.aspose.com/slides/net/aspose.slides/autoshape/autoshapelock/) que le permiten [restringir operaciones de edición](/slides/es/net/applying-protection-to-presentation/).
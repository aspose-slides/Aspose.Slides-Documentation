---
title: Añadir formas de línea a presentaciones en .NET
linktitle: Línea
type: docs
weight: 50
url: /es/net/line/
keywords:
- línea
- crear línea
- añadir línea
- línea simple
- configurar línea
- personalizar línea
- estilo de guiones
- punta de flecha
- PowerPoint
- presentación
- .NET
- C#
- Aspose.Slides
description: "Aprenda a manipular el formato de líneas en presentaciones de PowerPoint con Aspose.Slides para .NET. Descubra propiedades, métodos y ejemplos."
---
## **Descripción general**

Aspose.Slides le permite añadir formas de línea a diapositivas de PowerPoint mediante programación. Este artículo muestra cómo crear una línea simple y cómo personalizar una línea para que aparezca como una flecha.

Aprenderá cómo añadir una forma de línea a una diapositiva, ajustar su apariencia visual y guardar la presentación actualizada. Los ejemplos se centran en ajustes prácticos de formato de línea como estilo, ancho, patrón de guiones, opciones de punta de flecha y color de relleno.

## **Crear una línea simple**
Para añadir una línea simple a una diapositiva seleccionada de la presentación, siga los pasos a continuación:

- Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/net/aspose.slides/presentation).
- Obtenga la referencia de una diapositiva mediante su índice.
- Añada un AutoShape de tipo Línea utilizando el método [AddAutoShape](https://reference.aspose.com/slides/es/net/aspose.slides/ishapecollection/methods/addautoshape/index) expuesto por el objeto Shapes.
- Guarde la presentación modificada como un archivo PPTX.

En el ejemplo que se muestra a continuación, hemos añadido una línea a la primera diapositiva de la presentación.

```c#
// Instanciar la clase PresentationEx que representa el archivo PPTX
using (Presentation pres = new Presentation())
{
    // Obtener la primera diapositiva
    ISlide sld = pres.Slides[0];

    // Añadir un AutoShape de tipo línea
    sld.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);

    //Escribir el PPTX en disco
    pres.Save("LineShape1_out.pptx", SaveFormat.Pptx);
}
```

## **Crear una línea con forma de flecha**
Aspose.Slides para .NET también permite a los desarrolladores configurar algunas propiedades de la línea para que sea más atractiva. Intentemos configurar algunas propiedades de una línea para que parezca una flecha. Siga los pasos a continuación para hacerlo:

- Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/net/aspose.slides/presentation)class[](http://www.aspose.com/api/net/slides/es/aspose.slides/)[](http://www.aspose.com/api/net/slides/es/aspose.slides/).
- Obtenga la referencia de una diapositiva mediante su índice.
- Añada un AutoShape de tipo Línea utilizando el método AddAutoShape expuesto por el objeto Shapes.
- Establezca el estilo de línea a uno de los estilos ofrecidos por Aspose.Slides para .NET.
- Establezca el ancho de la línea.
- Establezca el [Dash Style](https://reference.aspose.com/slides/es/net/aspose.slides/linedashstyle) de la línea a uno de los estilos ofrecidos por Aspose.Slides para .NET.
- Establezca el [Arrow Head Style](https://reference.aspose.com/slides/es/net/aspose.slides/linearrowheadstyle) y la longitud del punto de inicio de la línea.
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

**¿Puedo convertir una línea normal en un conector para que se "ajuste" a las formas?**

No. Una línea normal (un [AutoShape](https://reference.aspose.com/slides/es/net/aspose.slides/autoshape/) de tipo [Line](https://reference.aspose.com/slides/es/net/aspose.slides/shapetype/)) no se convierte automáticamente en un conector. Para que se ajuste a las formas, utilice el tipo [Connector](https://reference.aspose.com/slides/es/net/aspose.slides/connector/) dedicado y las [APIs correspondientes](/slides/es/net/connector/) para conexiones.

**¿Qué debo hacer si las propiedades de una línea se heredan del tema y es difícil determinar los valores finales?**

[Lea las propiedades efectivas](/slides/es/net/shape-effective-properties/) a través de las interfaces [ILineFormatEffectiveData](https://reference.aspose.com/slides/es/net/aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/es/net/aspose.slides/ilinefillformateffectivedata/) —estas ya tienen en cuenta la herencia y los estilos del tema.

**¿Puedo bloquear una línea contra la edición (mover, cambiar tamaño)?**

Sí. Las formas proporcionan [objetos de bloqueo](https://reference.aspose.com/slides/es/net/aspose.slides/autoshape/autoshapelock/) que le permiten [denegar operaciones de edición](/slides/es/net/applying-protection-to-presentation/).
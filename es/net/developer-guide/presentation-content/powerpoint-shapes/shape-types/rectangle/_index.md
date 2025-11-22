---
title: Rectángulo
type: docs
weight: 80
url: /es/net/rectangle/
keywords: "Crear rectángulo, forma de PowerPoint, presentación de PowerPoint, C#, Csharp, Aspose.Slides for .NET"
description: "Crear rectángulo en una presentación de PowerPoint en C# o .NET"
---

## **Crear rectángulo simple**
Al igual que en los temas anteriores, este también trata sobre agregar una forma y en esta ocasión la forma que discutiremos es Rectangle. En este tema hemos descrito cómo los desarrolladores pueden añadir rectángulos simples o con formato a sus diapositivas usando Aspose.Slides for .NET. Para agregar un rectángulo simple a una diapositiva seleccionada de la presentación, siga los pasos a continuación:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Obtener la referencia de una diapositiva utilizando su Index.
3. Añadir un IAutoShape de tipo Rectangle mediante el método AddAutoShape expuesto por el objeto IShapes.
4. Guardar la presentación modificada como un archivo PPTX.

En el ejemplo que se muestra a continuación, hemos añadido un rectángulo simple a la primera diapositiva de la presentación.
```c#
// Instanciar la clase Presentation que representa el PPTX
using (Presentation pres = new Presentation())
{
    // Obtener la primera diapositiva
    ISlide sld = pres.Slides[0];

    // Añadir una forma automática de tipo rectángulo
    sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);

    //Guardar el archivo PPTX en disco
    pres.Save("RectShp1_out.pptx", SaveFormat.Pptx);
}
```


## **Crear rectángulo con formato**
Para añadir un rectángulo con formato a una diapositiva, siga los pasos a continuación:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Obtener la referencia de una diapositiva utilizando su Index.
3. Añadir un IAutoShape de tipo Rectangle mediante el método AddAutoShape expuesto por el objeto IShapes.
4. Establecer el tipo de relleno del Rectangle a Solid.
5. Establecer el color del Rectangle usando la propiedad SolidFillColor.Color expuesta por el objeto FillFormat asociado al objeto IShape.
6. Establecer el color de las líneas del Rectangle.
7. Establecer el ancho de las líneas del Rectangle.
8. Guardar la presentación modificada como archivo PPTX.
   Los pasos anteriores están implementados en el ejemplo que se muestra a continuación.
```c#
// Instanciar la clase Presentation que representa el PPTX
using (Presentation pres = new Presentation())
{

    // Obtener la primera diapositiva
    ISlide sld = pres.Slides[0];

    // Añadir una forma automática de tipo rectángulo
    IShape shp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);

    // Aplicar formato a la forma de rectángulo
    shp.FillFormat.FillType = FillType.Solid;
    shp.FillFormat.SolidFillColor.Color = Color.Chocolate;

    // Aplicar formato a la línea del rectángulo
    shp.LineFormat.FillFormat.FillType = FillType.Solid;
    shp.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
    shp.LineFormat.Width = 5;

    //Guardar el archivo PPTX en disco
    pres.Save("RectShp2_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```


## **Preguntas frecuentes**

**¿Cómo añado un rectángulo con esquinas redondeadas?**

Use el [shape type](https://reference.aspose.com/slides/net/aspose.slides/shapetype/) de esquinas redondeadas y ajuste el radio de la esquina en las propiedades de la forma; el redondeo también puede aplicarse por esquina mediante ajustes de geometría.

**¿Cómo lleno un rectángulo con una imagen (textura)?**

Seleccione el [fill type](https://reference.aspose.com/slides/net/aspose.slides/filltype/) de imagen, proporcione la fuente de la imagen y configure los [modos de estiramiento/azulejo](https://reference.aspose.com/slides/net/aspose.slides/picturefillmode/).

**¿Puede un rectángulo tener sombra y resplandor?**

Sí. Las [sombras externas/internas, resplandor y bordes suaves](/slides/es/net/shape-effect/) están disponibles con parámetros ajustables.

**¿Puedo convertir un rectángulo en un botón con un hipervínculo?**

Sí. [Asigne un hipervínculo](/slides/es/net/manage-hyperlinks/) al clic de la forma (ir a una diapositiva, archivo, dirección web o correo electrónico).

**¿Cómo puedo proteger un rectángulo contra movimientos y cambios?**

[Use bloqueos de forma](/slides/es/net/applying-protection-to-presentation/): puede prohibir mover, redimensionar, seleccionar o editar texto para mantener el diseño.

**¿Puedo convertir un rectángulo a una imagen raster o SVG?**

Sí. Puede [renderizar la forma](http://reference.aspose.com/slides/net/aspose.slides/shape/getimage/) a una imagen con un tamaño/escala especificados o [exportarla como SVG](https://reference.aspose.com/slides/net/aspose.slides/shape/writeassvg/) para uso vectorial.

**¿Cómo obtengo rápidamente las propiedades reales (efectivas) de un rectángulo considerando el tema y la herencia?**

[Use las propiedades efectivas de la forma](/slides/es/net/shape-effective-properties/): la API devuelve valores calculados que tienen en cuenta los estilos del tema, el diseño y la configuración local, simplificando el análisis de formato.
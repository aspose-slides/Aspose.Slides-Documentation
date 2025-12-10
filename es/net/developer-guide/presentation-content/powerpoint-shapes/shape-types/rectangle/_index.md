---
title: Agregar rectángulos a presentaciones en .NET
linktitle: Rectángulo
type: docs
weight: 80
url: /es/net/rectangle/
keywords:
- agregar rectángulo
- crear rectángulo
- forma de rectángulo
- rectángulo simple
- rectángulo con formato
- PowerPoint
- presentación
- .NET
- C#
- Aspose.Slides
description: "Mejore sus presentaciones de PowerPoint agregando rectángulos con Aspose.Slides para .NET: diseñe y modifique formas programáticamente con facilidad."
---

## **Crear un Rectángulo Simple**
Al igual que en los temas anteriores, este también trata sobre agregar una forma y esta vez la forma de la que hablaremos es Rectangle. En este tema, describimos cómo los desarrolladores pueden agregar rectángulos simples o con formato a sus diapositivas usando Aspose.Slides for .NET. Para agregar un rectángulo simple a una diapositiva seleccionada de la presentación, siga los pasos a continuación:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Obtenga la referencia de una diapositiva usando su índice.
3. Agregue un IAutoShape de tipo Rectangle usando el método AddAutoShape expuesto por el objeto IShapes.
4. Guarde la presentación modificada como un archivo PPTX.

En el ejemplo a continuación, hemos agregado un rectángulo simple a la primera diapositiva de la presentación.
```c#
 // Instanciar la clase Presentation que representa el PPTX
 using (Presentation pres = new Presentation())
 {
 
     // Obtener la primera diapositiva
     ISlide sld = pres.Slides[0];
 
     // Agregar una autoshape de tipo rectángulo
     sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);
 
     //Escriba el archivo PPTX en el disco
     pres.Save("RectShp1_out.pptx", SaveFormat.Pptx);
 }
```



## **Crear un Rectángulo con Formato**
Para agregar un rectángulo con formato a una diapositiva, siga los pasos a continuación:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Obtenga la referencia de una diapositiva usando su índice.
3. Agregue un IAutoShape de tipo Rectangle usando el método AddAutoShape expuesto por el objeto IShapes.
4. Establezca el tipo de relleno del rectángulo a sólido.
5. Establezca el color del rectángulo usando la propiedad SolidFillColor.Color expuesta por el objeto FillFormat asociado al objeto IShape.
6. Establezca el color de las líneas del rectángulo.
7. Establezca el ancho de las líneas del rectángulo.
8. Guarde la presentación modificada como un archivo PPTX.

Los pasos anteriores se implementan en el ejemplo a continuación.
```c#
 // Instanciar la clase Presentation que representa el PPTX
 using (Presentation pres = new Presentation())
 {
 
     // Obtener la primera diapositiva
     ISlide sld = pres.Slides[0];
 
     // Agregar una autoshape de tipo rectángulo
     IShape shp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);
 
     // Aplicar algo de formato a la forma del rectángulo
     shp.FillFormat.FillType = FillType.Solid;
     shp.FillFormat.SolidFillColor.Color = Color.Chocolate;
 
     // Aplicar algo de formato a la línea del rectángulo
     shp.LineFormat.FillFormat.FillType = FillType.Solid;
     shp.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
     shp.LineFormat.Width = 5;
 
     //Write el archivo PPTX en el disco
     pres.Save("RectShp2_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
 }
```


## **Preguntas frecuentes**

**¿Cómo agrego un rectángulo con esquinas redondeadas?**

Utilice el [tipo de forma]https://reference.aspose.com/slides/net/aspose.slides/shapetype/ de esquina redondeada y ajuste el radio de la esquina en las propiedades de la forma; el redondeado también puede aplicarse por esquina mediante ajustes geométricos.

**¿Cómo relleno un rectángulo con una imagen (textura)?**

Seleccione el [tipo de relleno]https://reference.aspose.com/slides/net/aspose.slides/filltype/ de imagen, proporcione la fuente de la imagen y configure los [modos de estiramiento/azulejo]https://reference.aspose.com/slides/net/aspose.slides/picturefillmode/.

**¿Puede un rectángulo tener sombra y resplandor?**

Sí. [Sombra exterior/interior, resplandor y bordes suaves](/slides/es/net/shape-effect/) están disponibles con parámetros ajustables.

**¿Puedo convertir un rectángulo en un botón con un hipervínculo?**

Sí. [Asignar un hipervínculo](/slides/es/net/manage-hyperlinks/) al hacer clic en la forma (ir a una diapositiva, archivo, dirección web o correo electrónico).

**¿Cómo puedo proteger un rectángulo de moverlo y cambiarlo?**

[Usar bloqueos de forma](/slides/es/net/applying-protection-to-presentation/): puede prohibir mover, redimensionar, seleccionar o editar texto para preservar el diseño.

**¿Puedo convertir un rectángulo a una imagen raster o SVG?**

Sí. Puede [renderizar la forma](http://reference.aspose.com/slides/net/aspose.slides/shape/getimage/) a una imagen con un tamaño/escala especificados o [exportarla como SVG](https://reference.aspose.com/slides/net/aspose.slides/shape/writeassvg/) para uso vectorial.

**¿Cómo obtengo rápidamente las propiedades reales (efectivas) de un rectángulo considerando el tema y la herencia?**

[Utilizar las propiedades efectivas de la forma](/slides/es/net/shape-effective-properties/): la API devuelve valores calculados que tienen en cuenta los estilos del tema, el diseño y la configuración local, simplificando el análisis de formato.
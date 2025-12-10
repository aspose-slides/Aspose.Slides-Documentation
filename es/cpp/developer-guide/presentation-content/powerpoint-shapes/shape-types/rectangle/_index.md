---
title: Agregar rectángulos a presentaciones en C++
linktitle: Rectángulo
type: docs
weight: 80
url: /es/cpp/rectangle/
keywords:
- agregar rectángulo
- crear rectángulo
- forma de rectángulo
- rectángulo simple
- rectángulo con formato
- PowerPoint
- presentación
- C++
- Aspose.Slides
description: "Impulse sus presentaciones de PowerPoint agregando rectángulos con Aspose.Slides para C++ — diseñe y modifique formas fácilmente de forma programática."
---

## **Crear un Rectángulo Simple**
Al igual que en los temas anteriores, este también trata sobre agregar una forma y esta vez la forma de la que hablaremos es Rectangle. En este tema hemos descrito cómo los desarrolladores pueden agregar rectángulos simples o con formato a sus diapositivas usando Aspose.Slides para C++. Para agregar un rectángulo simple a una diapositiva seleccionada de la presentación, siga los pasos a continuación:

1. Cree una instancia de[Presentation class](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. Obtenga la referencia de una diapositiva usando su Index.
1. Agregue un IAutoShape de tipo Rectangle usando el método AddAutoShape expuesto por el objeto IShapes.
1. Guarde la presentación modificada como un archivo PPTX.

En el ejemplo que se muestra a continuación, hemos agregado un rectángulo simple a la primera diapositiva de la presentación.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SimpleRectangle-SimpleRectangle.cpp" >}}

## **Crear un Rectángulo con Formato**
Para agregar un rectángulo con formato a una diapositiva, siga los pasos a continuación:

1. Cree una instancia de[Presentation class](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. Obtenga la referencia de una diapositiva usando su Index.
1. Agregue un IAutoShape de tipo Rectangle usando el método AddAutoShape expuesto por el objeto IShapes.
1. Establezca el Fill Type del Rectangle a Solid.
1. Establezca el Color del Rectangle usando la propiedad SolidFillColor.Color expuesta por el objeto FillFormat asociado al objeto IShape.
1. Establezca el Color de las líneas del Rectangle.
1. Establezca el Ancho de las líneas del Rectangle.
1. Guarde la presentación modificada como archivo PPTX.
   Los pasos anteriores se implementan en el ejemplo que se muestra a continuación.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-FormattedRectangle-FormattedRectangle.cpp" >}}

## **FAQ**

**¿Cómo agrego un rectángulo con esquinas redondeadas?**

Utilice el[tipo de forma] (https://reference.aspose.com/slides/cpp/aspose.slides/shapetype/) de esquina redondeada y ajuste el radio de la esquina en las propiedades de la forma; el redondeo también puede aplicarse por esquina mediante ajustes de geometría.

**¿Cómo lleno un rectángulo con una imagen (textura)?**

Seleccione el[tipo de relleno] (https://reference.aspose.com/slides/cpp/aspose.slides/filltype/), proporcione la fuente de la imagen y configure los[modos de estiramiento/azulejo] (https://reference.aspose.com/slides/cpp/aspose.slides/picturefillmode/).

**¿Puede un rectángulo tener sombra y resplandor?**

Sí. [Sombra externa/interna, resplandor y bordes suaves](/slides/es/cpp/shape-effect/) están disponibles con parámetros ajustables.

**¿Puedo convertir un rectángulo en un botón con hipervínculo?**

Sí. [Asigne un hipervínculo](/slides/es/cpp/manage-hyperlinks/) al hacer clic en la forma (ir a una diapositiva, archivo, dirección web o correo electrónico).

**¿Cómo puedo proteger un rectángulo contra movimientos y cambios?**

[Utilice bloqueos de forma](/slides/es/cpp/applying-protection-to-presentation/): puede prohibir el movimiento, el cambio de tamaño, la selección o la edición de texto para preservar el diseño.

**¿Puedo convertir un rectángulo a una imagen raster o SVG?**

Sí. Puede [renderizar la forma](http://reference.aspose.com/slides/cpp/aspose.slides/shape/getimage/) a una imagen con un tamaño/escala especificados o [exportarla como SVG](https://reference.aspose.com/slides/cpp/aspose.slides/shape/writeassvg/) para uso vectorial.

**¿Cómo obtengo rápidamente las propiedades reales (efectivas) de un rectángulo considerando el tema y la herencia?**

[Utilice las propiedades efectivas de la forma](/slides/es/cpp/shape-effective-properties/): la API devuelve valores calculados que consideran los estilos del tema, el diseño y la configuración local, simplificando el análisis de formato.
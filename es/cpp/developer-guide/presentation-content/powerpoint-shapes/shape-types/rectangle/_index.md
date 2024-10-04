---
title: Rectángulo
type: docs
weight: 80
url: /cpp/rectangle/
---

## **Crear Rectángulo Simple**
Al igual que los temas anteriores, este también trata sobre agregar una forma y esta vez la forma que discutiremos es el Rectángulo. En este tema, hemos descrito cómo los desarrolladores pueden agregar rectángulos simples o formateados a sus diapositivas utilizando Aspose.Slides para C++. Para agregar un rectángulo simple a una diapositiva seleccionada de la presentación, por favor siga los pasos a continuación:

1. Cree una instancia de la [clase Presentation](http://www.aspose.com/api/net/slides/aspose.slides/).
1. Obtenga la referencia de una diapositiva utilizando su índice.
1. Agregue una IAutoShape de tipo Rectángulo utilizando el método AddAutoShape expuesto por el objeto IShapes.
1. Escriba la presentación modificada como un archivo PPTX.

En el ejemplo dado a continuación, hemos añadido un rectángulo simple a la primera diapositiva de la presentación.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SimpleRectangle-SimpleRectangle.cpp" >}}

## **Crear Rectángulo Formateado**
Para agregar un rectángulo formateado a una diapositiva, por favor siga los pasos a continuación:

1. Cree una instancia de la [clase Presentation](http://www.aspose.com/api/net/slides/aspose.slides/).
1. Obtenga la referencia de una diapositiva utilizando su índice.
1. Agregue una IAutoShape de tipo Rectángulo utilizando el método AddAutoShape expuesto por el objeto IShapes.
1. Establezca el tipo de relleno del Rectángulo a Sólido.
1. Establezca el color del Rectángulo utilizando la propiedad SolidFillColor.Color expuesta por el objeto FillFormat asociado con el objeto IShape.
1. Establezca el color de las líneas del Rectángulo.
1. Establezca el ancho de las líneas del Rectángulo.
1. Escriba la presentación modificada como archivo PPTX.
   Los pasos anteriores se implementan en el ejemplo dado a continuación.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-FormattedRectangle-FormattedRectangle.cpp" >}}
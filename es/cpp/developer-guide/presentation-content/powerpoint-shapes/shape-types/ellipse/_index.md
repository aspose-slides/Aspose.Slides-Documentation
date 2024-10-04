---
title: Elipse
type: docs
weight: 30
url: /es/cpp/ellipse/
---


## **Crear Elipse**
En este tema, presentaremos a los desarrolladores cómo añadir formas de elipse a sus diapositivas utilizando Aspose.Slides para C++. Aspose.Slides para C++ proporciona un conjunto más sencillo de APIs para dibujar diferentes tipos de formas con solo unas pocas líneas de código. Para agregar una elipse simple a una diapositiva seleccionada de la presentación, siga los pasos a continuación:

1. Cree una instancia de [Presentation class](http://www.aspose.com/api/net/slides/aspose.slides/)
1. Obtenga la referencia de una diapositiva utilizando su índice
1. Añada una AutoShape de tipo Elipse utilizando el método AddAutoShape expuesto por el objeto IShapes
1. Escriba la presentación modificada como un archivo PPTX

En el ejemplo dado a continuación, hemos añadido una elipse a la primera diapositiva.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SimpleEllipse-SimpleEllipse.cpp" >}}


## **Crear Elipse Formateada**
Para añadir una elipse mejor formateada a una diapositiva, siga los pasos a continuación:

1. Cree una instancia de [Presentation class](http://www.aspose.com/api/net/slides/aspose.slides/).
1. Obtenga la referencia de una diapositiva utilizando su índice.
1. Añada una AutoShape de tipo Elipse utilizando el método AddAutoShape expuesto por el objeto IShapes.
1. Establezca el tipo de relleno de la elipse a Sólido.
1. Establezca el color de la elipse utilizando la propiedad SolidFillColor.Color expuesta por el objeto FillFormat asociado con el objeto IShape.
1. Establezca el color de las líneas de la elipse.
1. Establezca el ancho de las líneas de la elipse.
1. Escriba la presentación modificada como un archivo PPTX.

En el ejemplo dado a continuación, hemos añadido una elipse formateada a la primera diapositiva de la presentación.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-FormattedEllipse-FormattedEllipse.cpp" >}}
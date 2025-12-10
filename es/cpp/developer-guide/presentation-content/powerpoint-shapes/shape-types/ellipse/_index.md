---
title: Agregar elipses a presentaciones en C++
linktitle: Elipse
type: docs
weight: 30
url: /es/cpp/ellipse/
keywords:
- elipse
- forma
- agregar elipse
- crear elipse
- dibujar elipse
- elipse formateada
- PowerPoint
- presentación
- C++
- Aspose.Slides
description: "Aprenda a crear, formatear y manipular formas de elipse en Aspose.Slides para C++ en presentaciones PPT y PPTX — se incluyen ejemplos de código en C++."
---

## **Crear una elipse**
En este tema, presentaremos a los desarrolladores cómo agregar formas de elipse a sus diapositivas usando Aspose.Slides para C++. Aspose.Slides para C++ ofrece un conjunto de API más sencillo para dibujar diferentes tipos de formas con solo unas pocas líneas de código. Para agregar una elipse simple a una diapositiva seleccionada de la presentación, siga los pasos a continuación:

1. Cree una instancia de [Presentation class](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)
2. Obtenga la referencia de una diapositiva usando su índice
3. Agregue un AutoShape de tipo Elipse usando el método AddAutoShape expuesto por el objeto IShapes
4. Escriba la presentación modificada como un archivo PPTX

En el ejemplo a continuación, hemos agregado una elipse a la primera diapositiva.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SimpleEllipse-SimpleEllipse.cpp" >}}

## **Crear una elipse formateada**
Para agregar una elipse mejor formateada a una diapositiva, siga los pasos a continuación:

1. Cree una instancia de [Presentation class](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Obtenga la referencia de una diapositiva usando su índice.
3. Agregue un AutoShape de tipo Elipse usando el método AddAutoShape expuesto por el objeto IShapes.
4. Establezca el Tipo de Relleno de la Elipse a Solid.
5. Establezca el Color de la Elipse usando la propiedad SolidFillColor.Color expuesta por el objeto FillFormat asociado al objeto IShape.
6. Establezca el Color de las líneas de la Elipse.
7. Establezca el Ancho de las líneas de la Elipse.
8. Escriba la presentación modificada como un archivo PPTX.

En el ejemplo a continuación, hemos agregado una elipse con formato a la primera diapositiva de la presentación.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-FormattedEllipse-FormattedEllipse.cpp" >}}

## **FAQ**

**¿Cómo establezco la posición exacta y el tamaño de una elipse respecto a las unidades de la diapositiva?**

Las coordenadas y los tamaños suelen especificarse **en puntos**. Para obtener resultados predecibles, base sus cálculos en el tamaño de la diapositiva y convierta los milímetros o pulgadas requeridos a puntos antes de asignar los valores.

**¿Cómo puedo colocar una elipse encima o debajo de otros objetos (controlar el orden de apilamiento)?**

Ajuste el orden de dibujo del objeto llevándolo al frente o enviándolo al fondo. Esto permite que la elipse se superponga a otros objetos o revele los que están debajo de ella.

**¿Cómo animo la aparición o énfasis de una elipse?**

[Apply](/slides/es/cpp/shape-animation/) efectos de entrada, énfasis o salida a la forma, y configure disparadores y temporizaciones para orquestar cuándo y cómo se reproduce la animación.
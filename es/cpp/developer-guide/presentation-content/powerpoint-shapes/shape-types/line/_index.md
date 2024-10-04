---
title: Línea
type: docs
weight: 50
url: /cpp/Line/
---

## **Crear Línea Simple**
Para agregar una línea simple a una diapositiva seleccionada de la presentación, siga los pasos a continuación:

- Cree una instancia de la [clase Presentation](http://www.aspose.com/api/net/slides/aspose.slides/).
- Obtenga la referencia de una diapositiva utilizando su índice.
- Agregue un AutoShape de tipo Línea usando el método [AddAutoShape](http://www.aspose.com/api/net/slides/aspose.slides/ishapecollection/methods/addautoshape/index) expuesto por el objeto Shapes.
- Escriba la presentación modificada como un archivo PPTX.

En el ejemplo que se muestra a continuación, hemos agregado una línea a la primera diapositiva de la presentación.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddPlainLineToSlide-AddPlainLineToSlide.cpp" >}}


## **Crear Línea en Forma de Flecha**
Aspose.Slides para C++ también permite a los desarrolladores configurar algunas propiedades de la línea para que se vea más atractiva. Intentemos configurar algunas propiedades de una línea para que se vea como una flecha. Siga los pasos a continuación para hacerlo:

- Cree una instancia de la [clase Presentation](http://www.aspose.com/api/net/slides/aspose.slides/).
- Obtenga la referencia de una diapositiva utilizando su índice.
- Agregue un AutoShape de tipo Línea usando el método AddAutoShape expuesto por el objeto Shapes.
- Establezca el estilo de la línea en uno de los estilos ofrecidos por Aspose.Slides para C++.
- Establezca el ancho de la línea.
- Establezca el [estilo de Dash](http://www.aspose.com/api/net/slides/aspose.slides/linedashstyle) de la línea en uno de los estilos ofrecidos por Aspose.Slides para C++.
- Establezca el [estilo de Cabeza de Flecha](http://www.aspose.com/api/net/slides/aspose.slides/lineformat) y la longitud del punto de inicio de la línea.
- Establezca el estilo de Cabeza de Flecha y la longitud del punto final de la línea.
- Escriba la presentación modificada como un archivo PPTX.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddArrowShapedLineToSlide-AddArrowShapedLineToSlide.cpp" >}}
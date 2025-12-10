---
title: Gestionar superíndice y subíndice en presentaciones usando C++
linktitle: Superíndice y subíndice
type: docs
weight: 80
url: /es/cpp/superscript-and-subscript/
keywords:
- superíndice
- subíndice
- agregar superíndice
- agregar subíndice
- PowerPoint
- OpenDocument
- presentación
- C++
- Aspose.Slides
description: "Domina el superíndice y subíndice en Aspose.Slides para C++ y eleva tus presentaciones con un formato de texto profesional para lograr el máximo impacto."
---

## **Administrar texto en superíndice y subíndice**
Puede agregar texto en superíndice o subíndice dentro de cualquier porción de párrafo. Para agregar texto en superíndice o subíndice en un marco de texto de Aspose.Slides se debe usar la propiedad **Escapement** de la clase PortionFormat.

Esta propiedad devuelve o establece el texto en superíndice o subíndice (valor de -100 % (subíndice) a 100 % (superíndice)). Por ejemplo :

- Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
- Obtenga la referencia de una diapositiva usando su índice.
- Agregue un IAutoShape de tipo Rectángulo a la diapositiva.
- Acceda al ITextFrame asociado con el IAutoShape.
- Borre los párrafos existentes
- Cree un nuevo objeto de párrafo para contener texto en superíndice y agréguelo a la colección IParagraphs del ITextFrame.
- Cree un nuevo objeto Portion
- Establezca la propiedad Escapement para la porción entre 0 y 100 para agregar superíndice. (0 significa sin superíndice)
- Establezca algún texto para la Portion y luego añádalo a la colección de porciones del párrafo.
- Cree un nuevo objeto de párrafo para contener texto en subíndice y agréguelo a la colección IParagraphs del ITextFrame.
- Cree un nuevo objeto Portion
- Establezca la propiedad Escapement para la porción entre 0 y -100 para agregar subíndice. (0 significa sin subíndice)
- Establezca algún texto para la Portion y luego añádalo a la colección de porciones del párrafo.
- Guarde la presentación como un archivo PPTX.

La implementación de los pasos anteriores se muestra a continuación.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-AddingSuperscriptAndSubscriptTextInTextFrame-AddingSuperscriptAndSubscriptTextInTextFrame.cpp" >}}

## **Preguntas frecuentes**

**¿Se conservará el superíndice y subíndice al exportar a PDF u otros formatos?**

Sí, Aspose.Slides conserva correctamente el formato de superíndice y subíndice al exportar presentaciones a PDF, PPT/PPTX, imágenes y otros formatos compatibles. El formato especializado permanece intacto en todos los archivos de salida.

**¿Se puede combinar el superíndice y subíndice con otros estilos de formato como negrita o cursiva?**

Sí, Aspose.Slides permite mezclar varios estilos de texto dentro de una sola porción de texto. Puede habilitar negrita, cursiva, subrayado y aplicar simultáneamente superíndice o subíndice configurando las propiedades correspondientes en [PortionFormat](https://reference.aspose.com/slides/cpp/aspose.slides/portionformat/).

**¿Funciona el formato de superíndice y subíndice para texto dentro de tablas, gráficos o SmartArt?**

Sí, Aspose.Slides admite formato dentro de la mayoría de los objetos, incluidas tablas y elementos de gráficos. Al trabajar con SmartArt, debe acceder a los elementos apropiados (como [SmartArtNode](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/smartartnode/)) y sus contenedores de texto, y luego configurar las propiedades de [PortionFormat](https://reference.aspose.com/slides/cpp/aspose.slides/portionformat/) de manera similar.
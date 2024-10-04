---
title: Superíndice y Subíndice
type: docs
weight: 80
url: /cpp/superscript-and-subscript/
---

## **Gestionar Texto de Superíndice y Subíndice**
Puedes agregar texto de superíndice y subíndice dentro de cualquier parte del párrafo. Para agregar texto de superíndice o subíndice en el marco de texto de Aspose.Slides, uno debe usar las propiedades de **Escapement** de la clase PortionFormat.

Esta propiedad devuelve o establece el texto de superíndice o subíndice (valor de -100% (subíndice) a 100% (superíndice). Por ejemplo:

- Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
- Obtén la referencia de una diapositiva utilizando su índice.
- Agrega una IAutoShape de tipo Rectángulo a la diapositiva.
- Accede al ITextFrame asociado con la IAutoShape.
- Limpia los párrafos existentes.
- Crea un nuevo objeto de párrafo para contener texto de superíndice y agrégalo a la colección de IParagraphs del ITextFrame.
- Crea un nuevo objeto de porción.
- Establece la propiedad de Escapement para la porción entre 0 y 100 para agregar superíndice. (0 significa sin superíndice)
- Establece un texto para la Porción y luego agrégalo a la colección de porciones del párrafo.
- Crea un nuevo objeto de párrafo para contener texto de subíndice y agrégalo a la colección de IParagraphs del ITextFrame.
- Crea un nuevo objeto de porción.
- Establece la propiedad de Escapement para la porción entre 0 y -100 para agregar subíndice. (0 significa sin subíndice)
- Establece un texto para la Porción y luego agrégalo a la colección de porciones del párrafo.
- Guarda la presentación como un archivo PPTX.

La implementación de los pasos anteriores se da a continuación.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-AddingSuperscriptAndSubscriptTextInTextFrame-AddingSuperscriptAndSubscriptTextInTextFrame.cpp" >}}
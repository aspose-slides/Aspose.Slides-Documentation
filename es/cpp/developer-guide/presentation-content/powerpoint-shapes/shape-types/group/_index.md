---
title: Grupo
type: docs
weight: 40
url: /cpp/group/
---


## **Agregar Forma de Grupo**
Aspose.Slides admite trabajar con formas de grupo en las diapositivas. Esta característica ayuda a los desarrolladores a crear presentaciones más ricas. Aspose.Slides para C++ admite agregar o acceder a formas de grupo. Es posible agregar formas a una forma de grupo agregada para poblarla o acceder a cualquier propiedad de la forma de grupo. Para agregar una forma de grupo a una diapositiva usando Aspose.Slides para C++:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Obtenga la referencia de una diapositiva utilizando su índice.
1. Agregue una forma de grupo a la diapositiva.
1. Agregue las formas a la forma de grupo agregada.
1. Guarde la presentación modificada como un archivo PPTX.

El ejemplo a continuación agrega una forma de grupo a una diapositiva.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CreateGroupShape-CreateGroupShape.cpp" >}}


## **Acceder a la Propiedad AltText**
Este tema muestra pasos simples, completos con ejemplos de código, para añadir una forma de grupo y acceder a la propiedad AltText de las formas de grupo en las diapositivas. Para acceder al AltText de una forma de grupo en una diapositiva mediante Aspose.Slides para C++:

1. Instancie la clase `Presentation` que representa un archivo PPTX.
1. Obtenga la referencia de una diapositiva utilizando su índice.
1. Acceda a la colección de formas de las diapositivas.
1. Acceda a la forma de grupo.
1. Acceda a la propiedad AltText.

El ejemplo a continuación accede al texto alternativo de la forma de grupo.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessingAltTextinGroupshapes-AccessingAltTextinGroupshapes.cpp" >}}
---
title: Formas de presentación en grupo en C++
linktitle: Grupo de formas
type: docs
weight: 40
url: /es/cpp/group/
keywords:
- forma de grupo
- grupo de formas
- añadir grupo
- texto alternativo
- PowerPoint
- presentación
- C++
- Aspose.Slides
description: "Aprenda a agrupar y desagrupar formas en presentaciones de PowerPoint usando Aspose.Slides para C++ — guía rápida, paso a paso, con código C++ gratuito."
---

## **Agregar una forma de grupo**
Aspose.Slides admite trabajar con formas de grupo en diapositivas. Esta función ayuda a los desarrolladores a crear presentaciones más ricas. Aspose.Slides for C++ admite agregar o acceder a formas de grupo. Es posible agregar formas a una forma de grupo añadida para poblarla o acceder a cualquier propiedad de la forma de grupo. Para agregar una forma de grupo a una diapositiva usando Aspose.Slides for C++:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. Obtenga la referencia de una diapositiva usando su índice.
1. Agregue una forma de grupo a la diapositiva.
1. Agregue las formas a la forma de grupo añadida.
1. Guarde la presentación modificada como un archivo PPTX.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CreateGroupShape-CreateGroupShape.cpp" >}}

## **Acceder a la propiedad AltText**
Este tema muestra pasos simples, acompañados de ejemplos de código, para agregar una forma de grupo y acceder a la propiedad AltText de las formas de grupo en diapositivas. Para acceder al AltText de una forma de grupo en una diapositiva usando Aspose.Slides for C++:

1. Instancie la clase `Presentation` que representa un archivo PPTX.
1. Obtenga la referencia de una diapositiva usando su índice.
1. Acceda a la colección de formas de las diapositivas.
1. Acceda a la forma de grupo.
1. Acceda a la propiedad AltText.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessingAltTextinGroupshapes-AccessingAltTextinGroupshapes.cpp" >}}

## **FAQ**

**¿Se admite la agrupación anidada (un grupo dentro de otro grupo)?**

Sí. [GroupShape](https://reference.aspose.com/slides/cpp/aspose.slides/groupshape/) tiene un método [get_ParentGroup](https://reference.aspose.com/slides/cpp/aspose.slides/shape/get_parentgroup/) que indica directamente la compatibilidad con la jerarquía (un grupo puede ser hijo de otro grupo).

**¿Cómo controlo el orden Z del grupo respecto a otros objetos en la diapositiva?**

Utilice la [GroupShape](https://reference.aspose.com/slides/cpp/aspose.slides/groupshape/) y su [Z-Order position](https://reference.aspose.com/slides/cpp/aspose.slides/shape/get_zorderposition/) para inspeccionar su posición en la pila de visualización.

**¿Puedo impedir mover/editar/desagrupar?**

Sí. La sección de bloqueo del grupo se expone mediante [get_GroupShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/groupshape/get_groupshapelock/), lo que le permite restringir operaciones sobre el objeto.
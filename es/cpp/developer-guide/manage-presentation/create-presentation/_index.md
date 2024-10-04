---
title: Crear Presentación - API de PowerPoint en C++
linktitle: Crear Presentación
type: docs
weight: 10
url: /cpp/create-presentation/
description: Para crear una Presentación de PowerPoint en la API de C++, por favor sigue los pasos mencionados en este artículo. El código agrega una línea a la primera diapositiva de la presentación.
---

## **Crear Presentación de PowerPoint**
Para agregar una línea sencilla a una diapositiva seleccionada de la presentación, por favor sigue los pasos a continuación:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
1. Obtén la referencia de una diapositiva utilizando su índice.
1. Agrega un AutoShape de tipo Línea utilizando el método AddAutoShape expuesto por el objeto Shapes.
1. Escribe la presentación modificada como un archivo PPTX.

En el ejemplo dado a continuación, hemos agregado una línea a la primera diapositiva de la presentación.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CreateNewPresentation-CreateNewPresentation.cpp" >}}
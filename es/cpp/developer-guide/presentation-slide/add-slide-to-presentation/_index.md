---
title: "Agregar diapositivas a presentaciones en C++"
linktitle: "Agregar diapositiva"
type: docs
weight: 10
url: /es/cpp/add-slide-to-presentation/
keywords:
- "agregar diapositiva"
- "crear diapositiva"
- "diapositiva vacía"
- PowerPoint
- OpenDocument
- presentación
- C++
- Aspose.Slides
description: "Agregue fácilmente diapositivas a sus presentaciones de PowerPoint y OpenDocument con Aspose.Slides para C++ — inserción de diapositivas fluida y eficiente en segundos."
---

## **Agregar una diapositiva a una presentación**
Antes de hablar sobre cómo agregar diapositivas a los archivos de presentación, discutamos algunos datos sobre las diapositivas. Cada archivo de presentación de PowerPoint contiene una diapositiva Maestra / Diseño y otras diapositivas Normales. Esto significa que un archivo de presentación contiene al menos una diapositiva o más. Es importante saber que los archivos de presentación sin diapositivas no son compatibles con Aspose.Slides for C++. Cada diapositiva tiene un Id único y todas las diapositivas Normales se organizan en un orden especificado por un índice basado en cero. Aspose.Slides for C++ permite a los desarrolladores agregar diapositivas vacías a su presentación. Para agregar una diapositiva vacía en la presentación, siga los pasos a continuación:

- Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
- Instancie la clase [ISlideCollection](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/) estableciendo una referencia a la propiedad Slides (colección de objetos Slide de contenido) expuesta por el objeto Presentation.
- Agregue una diapositiva vacía a la presentación al final de la colección de diapositivas de contenido llamando a los métodos AddEmptySlide expuestos por el objeto ISlideCollection.
- Realice alguna acción con la diapositiva vacía recién añadida.
- Finalmente, guarde el archivo de presentación utilizando el objeto [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddSlides-AddSlides.cpp" >}}

## **Preguntas frecuentes**

**¿Puedo insertar una nueva diapositiva en una posición específica, no solo al final?**

Sí. La biblioteca admite colecciones de diapositivas y operaciones de [insert](https://reference.aspose.com/slides/cpp/aspose.slides/slidecollection/insertemptyslide/)/[clone](https://reference.aspose.com/slides/cpp/aspose.slides/slidecollection/insertclone/) , por lo que puede agregar una diapositiva en el índice requerido en lugar de solo al final.

**¿Se conservan los temas/estilos al agregar una diapositiva basada en un diseño?**

Sí. Un diseño hereda el formato de su maestro, y la nueva diapositiva hereda del diseño seleccionado y su maestro asociado.

**¿Qué diapositiva está presente en una nueva presentación "vacía" antes de agregar diapositivas?**

Una presentación recién creada ya contiene una diapositiva en blanco con índice cero. Esto es importante a considerar al calcular los índices de inserción.

**¿Cómo elijo el diseño "correcto" para una nueva diapositiva si el maestro tiene muchas opciones?**

Generalmente elija el [LayoutSlide](https://reference.aspose.com/slides/cpp/aspose.slides/layoutslide/) que coincida con la estructura requerida ([Title and Content, Two Content, etc.](https://reference.aspose.com/slides/cpp/aspose.slides/slidelayouttype/)). Si falta ese diseño, puede [agregarlo al maestro](/slides/es/cpp/slide-layout/) y luego usarlo.
---
title: Agregar diapositivas a presentaciones en .NET
linktitle: Agregar diapositiva
type: docs
weight: 10
url: /es/net/add-slide-to-presentation/
keywords:
- agregar diapositiva
- crear diapositiva
- diapositiva vacía
- PowerPoint
- OpenDocument
- presentación
- .NET
- C#
- Aspose.Slides
description: "Agregue diapositivas fácilmente a sus presentaciones PowerPoint y OpenDocument usando Aspose.Slides para .NET—inserción de diapositivas sin problemas y eficiente en segundos."
---

## **Agregar una diapositiva a una presentación**
Antes de hablar sobre agregar diapositivas a los archivos de presentación, discutamos algunos datos sobre las diapositivas. Cada archivo de presentación de PowerPoint contiene una diapositiva Master / Layout y otras diapositivas Normal. Esto significa que un archivo de presentación contiene al menos una o más diapositivas. Es importante saber que los archivos de presentación sin diapositivas no son compatibles con Aspose.Slides for .NET. Cada diapositiva tiene un Id único y todas las diapositivas Normal se organizan en un orden especificado por el índice basado en cero. Aspose.Slides for .NET permite a los desarrolladores agregar diapositivas vacías a su presentación. Para agregar una diapositiva vacía en la presentación, siga los pasos a continuación:

- Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
- Instancie la clase [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) estableciendo una referencia a la propiedad Slides (colección de objetos Slide de contenido) expuesta por el objeto Presentation.
- Agregue una diapositiva vacía a la presentación al final de la colección de diapositivas de contenido llamando a los métodos AddEmptySlide expuestos por el objeto ISlideCollection.
- Realice algunas operaciones con la diapositiva vacía recién añadida.
- Finalmente, escriba el archivo de presentación usando el objeto [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Slides-AddSlides-AddSlides.cs" >}}

## **Preguntas frecuentes**

**¿Puedo insertar una nueva diapositiva en una posición específica, no solo al final?**

Sí. La biblioteca soporta colecciones de diapositivas y operaciones de [insert](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/insertemptyslide/)/[clone](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/insertclone/), por lo que puede agregar una diapositiva en el índice requerido en lugar de solo al final.

**¿Se conservan los temas/estilos al agregar una diapositiva basada en un diseño?**

Sí. Un diseño hereda el formato de su master, y la nueva diapositiva hereda del diseño seleccionado y su master asociado.

**¿Qué diapositiva está presente en una nueva presentación "vacía" antes de agregar diapositivas?**

Una presentación recién creada ya contiene una diapositiva en blanco con índice cero. Esto es importante tener en cuenta al calcular los índices de inserción.

**¿Cómo elijo el diseño "correcto" para una nueva diapositiva si el master tiene muchas opciones?**

Generalmente elija el [LayoutSlide](https://reference.aspose.com/slides/net/aspose.slides/layoutslide/) que coincida con la estructura requerida ([Title and Content, Two Content, etc.](https://reference.aspose.com/slides/net/aspose.slides/slidelayouttype/)). Si falta dicho diseño, puede [agregarlo al master](/slides/es/net/slide-layout/) y luego usarlo.
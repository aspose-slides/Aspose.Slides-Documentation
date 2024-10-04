---
title: Agregar diapositiva a la presentación
type: docs
weight: 10
url: /net/add-slide-to-presentation/
keywords: "Agregar diapositiva a la presentación, C#, Csharp, .NET, Aspose.Slides"
description: "Agregar diapositiva a la presentación en C# o .NET"
---

## **Agregar diapositiva a la presentación**
Antes de hablar sobre cómo agregar diapositivas a los archivos de presentación, discutamos algunos hechos sobre las diapositivas. Cada archivo de presentación de PowerPoint contiene diapositivas de Maestro / Diseño y otras diapositivas Normales. Esto significa que un archivo de presentación contiene al menos una o más diapositivas. Es importante saber que los archivos de presentación sin diapositivas no son compatibles con Aspose.Slides para .NET. Cada diapositiva tiene un Id único y todas las Diapositivas Normales están organizadas en un orden especificado por el índice basado en cero. Aspose.Slides para .NET permite a los desarrolladores agregar diapositivas vacías a su presentación. Para agregar una diapositiva vacía a la presentación, siga los pasos a continuación:

- Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
- Instancie la clase [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) estableciendo una referencia a la propiedad Slides (colección de objetos Slide de contenido) expuesta por el objeto Presentation.
- Agregue una diapositiva vacía a la presentación al final de la colección de diapositivas de contenido llamando a los métodos AddEmptySlide expuestos por el objeto ISlideCollection.
- Realice alguna operación con la nueva diapositiva vacía agregada.
- Finalmente, escriba el archivo de presentación utilizando el objeto [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Slides-AddSlides-AddSlides.cs" >}}
---
title: Agregar diapositiva a la presentación
type: docs
weight: 10
url: /es/cpp/add-slide-to-presentation/
---

## **Agregar diapositiva a la presentación**
Antes de hablar sobre cómo agregar diapositivas a los archivos de presentación, discutamos algunos hechos sobre las diapositivas. Cada archivo de presentación de PowerPoint contiene diapositivas Master / Layout y otras diapositivas Normales. Esto significa que un archivo de presentación contiene al menos una o más diapositivas. Es importante saber que los archivos de presentación sin diapositivas no son compatibles con Aspose.Slides para C++. Cada diapositiva tiene un Id único y todas las diapositivas Normales están organizadas en un orden especificado por el índice basado en cero. Aspose.Slides para C++ permite a los desarrolladores agregar diapositivas vacías a su presentación. Para agregar una diapositiva vacía a la presentación, siga los pasos a continuación:

- Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
- Instancie la clase [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) estableciendo una referencia a la propiedad Slides (colección de objetos de diapositiva de contenido) expuesta por el objeto Presentation.
- Agregue una diapositiva vacía a la presentación al final de la colección de diapositivas de contenido llamando a los métodos AddEmptySlide expuestos por el objeto ISlideCollection.
- Realice algunas operaciones con la nueva diapositiva vacía agregada.
- Finalmente, escriba el archivo de presentación utilizando el objeto [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddSlides-AddSlides.cpp" >}}
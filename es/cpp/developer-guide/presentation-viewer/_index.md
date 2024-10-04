---
title: Visor de Presentaciones
type: docs
weight: 50
url: /cpp/presentation-viewer/
keywords: 
- ver presentación de PowerPoint
- ver ppt
- ver PPTX
- C++
- Aspose.Slides para C++
description: "Ver presentación de PowerPoint en C++"
---

## **Generar Imagen SVG desde Diapositiva**
Aspose.Slides para C++ se utiliza para crear archivos de presentación, completos con diapositivas. Estas diapositivas pueden ser visualizadas abriendo las presentaciones con Microsoft PowerPoint. Pero a veces, los desarrolladores también pueden necesitar ver diapositivas como imágenes SVG en su visor de imágenes favorito. En tales casos, Aspose.Slides para C++ permite exportar una diapositiva individual a una imagen SVG. Este artículo describe cómo usar esta función. Para generar una imagen SVG desde cualquier diapositiva deseada con Aspose.Slides.Pptx para C++, siga los siguientes pasos:

- Cree una instancia de la [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) clase.
- Obtenga la referencia de la diapositiva deseada utilizando su ID o índice.
- Obtenga la imagen SVG en un flujo de memoria.
- Guarde el flujo de memoria en un archivo.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CreateSlidesSVGImage-CreateSlidesSVGImage.cpp" >}}
## **Generar SVG con IDs de Forma Personalizados**
Ahora Aspose.Slides para C++ se puede utilizar para generar SVG desde una diapositiva con ID de forma personalizados. Estas diapositivas pueden ser visualizadas abriendo presentaciones con Microsoft PowerPoint. Pero a veces, los desarrolladores también pueden necesitar ver diapositivas como imágenes SVG en su visor de imágenes favorito. En tales casos, Aspose.Slides para C++ permite exportar una diapositiva individual a una imagen SVG. Para ese propósito, se ha añadido la propiedad ID a ISvgShape para soportar IDs personalizados de formas en el SVG generado. Para implementar esta característica, se ha introducido un CustomSvgShapeFormattingController que puede usar para establecer el ID de la forma.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-GeneratingSVGWithCustomShapeIDS-GeneratingSVGWithCustomShapeIDS.cpp" >}}

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CustomSvgShapeFormattingController-CustomSvgShapeFormattingController.cpp" >}}


## **Crear Imagen en Miniatura de Diapositiva**
Aspose.Slides para C++ se utiliza para crear archivos de presentación que contienen diapositivas. Estas diapositivas pueden ser visualizadas abriendo archivos de presentación con Microsoft PowerPoint. Pero a veces, los desarrolladores pueden necesitar ver diapositivas como imágenes utilizando su visor de imágenes favorito. En tales casos, Aspose.Slides para C++ le ayuda a generar imágenes en miniatura de las diapositivas. Para generar la miniatura de cualquier diapositiva deseada usando Aspose.Slides para C++:

1. Cree una instancia de la [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) clase.
1. Obtenga la referencia de cualquier diapositiva deseada utilizando su ID o índice.
1. Obtenga la imagen en miniatura de la diapositiva referenciada a una escala especificada.
1. Guarde la imagen en miniatura en cualquier formato de imagen deseado.

```cpp
// Instanciar la clase Presentation
auto presentation = MakeObject<Presentation>(u"ThumbnailFromSlide.pptx");

// Acceder a la primera diapositiva
auto slide = presentation->get_Slide(0);

// Crear una imagen a escala completa
auto image = slide->GetImage(1, 1);
image->Save(u"Thumbnail_out.jpg", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **Crear Miniatura con Dimensiones Definidas por el Usuario**
1. Cree una instancia de la [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) clase.
1. Obtenga la referencia de cualquier diapositiva deseada utilizando su ID o índice.
1. Obtenga la imagen en miniatura de la diapositiva referenciada a una escala especificada.
1. Guarde la imagen en miniatura en cualquier formato de imagen deseado.

```cpp
// Instanciar la clase Presentation
auto presentation = MakeObject<Presentation>(u"ThumbnailWithUserDefinedDimensions.pptx");

// Acceder a la primera diapositiva
auto slide = presentation->get_Slide(0);

// Dimensión definida por el usuario
auto desiredX = 1200;
auto desiredY = 800;

auto slideSize = presentation->get_SlideSize()->get_Size();

// Obtener el valor escalado de X e Y
auto scaleX = (float)(1.0 / slideSize.get_Width()) * desiredX;
auto scaleY = (float)(1.0 / slideSize.get_Height()) * desiredY;

// Crear una imagen a escala personalizada
auto image = slide->GetImage(scaleX, scaleY);
image->Save(u"Thumbnail2_out.jpg", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **Crear Miniatura desde Diapositiva en Vista de Diapositivas de Notas**
Para generar la miniatura de cualquier diapositiva deseada en Vista de Diapositivas de Notas usando Aspose.Slides para C++:

1. Cree una instancia de la [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) clase.
1. Obtenga la referencia de cualquier diapositiva deseada utilizando su ID o índice.
1. Obtenga la imagen en miniatura de la diapositiva referenciada a una escala especificada en vista de Diapositivas de Notas.
1. Guarde la imagen en miniatura en cualquier formato de imagen deseado.

El fragmento de código a continuación produce una miniatura de la primera diapositiva de una presentación en Vista de Diapositivas de Notas.

```cpp
// Instanciar la clase Presentation
auto presentation = MakeObject<Presentation>(u"ThumbnailFromSlideInNotes.pptx");

// Acceder a la primera diapositiva
auto slide = presentation->get_Slide(0);

// Dimensión definida por el usuario
auto desiredX = 1200;
auto desiredY = 800;

auto slideSize = presentation->get_SlideSize()->get_Size();

// Obtener el valor escalado de X e Y
auto scaleX = (float)(1.0 / slideSize.get_Width()) * desiredX;
auto scaleY = (float)(1.0 / slideSize.get_Height()) * desiredY;

// Crear una imagen a escala completa
auto image = slide->GetImage(scaleX, scaleY);
image->Save(u"Notes_tnail_out.jpg", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```
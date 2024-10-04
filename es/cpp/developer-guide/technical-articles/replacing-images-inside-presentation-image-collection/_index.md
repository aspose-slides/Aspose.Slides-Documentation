---
title: Reemplazando Imágenes dentro de la Colección de Imágenes de la Presentación
type: docs
weight: 90
url: /cpp/replacing-images-inside-presentation-image-collection/
---

{{% alert color="primary" %}} 

Aspose.Slides para C++ le permite reemplazar las imágenes añadidas en las formas de las diapositivas. En este artículo, aprenderá cómo reemplazar la imagen añadida en la colección de imágenes de la presentación a través de diferentes enfoques.

{{% /alert %}} 
## **Reemplazando la Imagen dentro de una Colección de Imágenes de Presentación**
Aspose.Slides para C++ proporciona un método de API simple que le permite reemplazar la imagen dentro de una colección de imágenes de la presentación de esta manera:

1. Cargue el archivo de presentación con una imagen dentro utilizando la clase [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
1. Cargue una imagen desde un archivo en un arreglo de bytes.
1. Utilice uno de estos enfoques:
   - Primer enfoque: Reemplace la imagen objetivo con la nueva imagen en el arreglo de bytes.
   - Segundo enfoque: Cargue la imagen en un objeto [Image](https://reference.aspose.com/slides/cpp/class/system.drawing.image) y reemplace la imagen objetivo con la imagen cargada.
   - Tercer enfoque: Reemplace la imagen con la imagen ya añadida en la colección de imágenes de la presentación.
1. Escriba la presentación modificada como un archivo PPTX.

Este código de muestra le muestra cómo reemplazar la imagen en una colección de imágenes de la presentación:

``` cpp
// Instanciar la presentación
SharedPtr<Presentation> presentation = MakeObject<Presentation>(u"presentation.pptx");

// El primer enfoque
ArrayPtr<uint8_t> data = ReadAllBytes(u"image0.jpeg");
SharedPtr<IPPImage> oldImage = presentation->get_Images()->idx_get(0);
oldImage->ReplaceImage(data);

// El segundo enfoque
SharedPtr<IImage> newImage = Images::FromFile(u"image1.png");
oldImage = presentation->get_Images()->idx_get(1);
oldImage->ReplaceImage(newImage);
newImage->Dispose();

// El tercer enfoque
oldImage = presentation->get_Images()->idx_get(2);
oldImage->ReplaceImage(presentation->get_Images()->idx_get(3));

// Guardar la presentación
presentation->Save(u"c:\\Presentations\\TestSmart.pptx", SaveFormat::Pptx);
```
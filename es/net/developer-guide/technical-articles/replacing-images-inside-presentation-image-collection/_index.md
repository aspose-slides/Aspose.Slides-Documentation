---
title: Reemplazar Imágenes dentro de la Colección de Imágenes de la Presentación
type: docs
weight: 110
url: /es/net/replacing-images-inside-presentation-image-collection/
---

{{% alert color="primary" %}} 

Aspose.Slides para .NET hace posible reemplazar las imágenes añadidas en las formas de las diapositivas. Este artículo explica cómo reemplazar la imagen añadida en la colección de imágenes de presentación utilizando diferentes enfoques.

{{% /alert %}} 
## **Reemplazando Imagen dentro de la Colección de Imágenes de la Presentación**
Aspose.Slides para .NET proporciona métodos API simples para reemplazar las imágenes dentro de la colección de imágenes de presentación. Por favor, siga los pasos a continuación:

1. Cargue el archivo de presentación con una imagen dentro utilizando la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Cargue una imagen desde un archivo en un arreglo de bytes.
1. Reemplace la imagen objetivo con la nueva imagen en el arreglo de bytes.
1. En el segundo enfoque, cargue la imagen en un objeto Image y reemplace la imagen objetivo con la imagen cargada.
1. En el tercer enfoque, reemplace la imagen con una imagen ya añadida en la colección de imágenes de la presentación.
1. Escriba la presentación modificada como un archivo PPTX.

```c#
//Instanciar la presentación
using Presentation presentation = new Presentation("presentation.pptx");

//la primera forma
byte[] data = File.ReadAllBytes("image0.jpeg");
IPPImage oldImage = presentation.Images[0];
oldImage.ReplaceImage(data);

//la segunda forma
using IImage newImage = Images.FromFile("image1.png");
oldImage = presentation.Images[1];
oldImage.ReplaceImage(newImage);

//la tercera forma
oldImage = presentation.Images[2];
oldImage.ReplaceImage(presentation.Images[3]);

//Guardar la presentación
presentation.Save("c:\\Presentations\\TestSmart.pptx", SaveFormat.Pptx);
```
---
title: Reemplazo de Imágenes dentro de la Colección de Imágenes de Presentación
type: docs
weight: 80
url: /es/java/replacing-images-inside-presentation-image-collection/
---

{{% alert color="primary" %}} 

Aspose.Slides para Java permite reemplazar imágenes en las formas de las diapositivas. Este artículo explica cómo reemplazar una imagen añadida a la colección de imágenes de presentación utilizando diferentes enfoques.

{{% /alert %}} 
## **Reemplazo de Imagen dentro de la Colección de Imágenes de Presentación**
Aspose.Slides para Java proporciona métodos de API simples para reemplazar las imágenes dentro de la colección de imágenes de presentación. Por favor, siga los pasos a continuación:

1. Cargue el archivo de presentación con la imagen dentro utilizando la clase Presentation.
1. Cargue una imagen desde un archivo en un arreglo de bytes.
1. Reemplace la imagen objetivo con la nueva imagen en el arreglo de bytes.
1. En el segundo enfoque, cargue la imagen en un objeto Image y reemplace la imagen objetivo con la imagen cargada.
1. En el tercer enfoque, reemplace la imagen con una imagen ya añadida en la colección de imágenes de presentación.
1. Escriba la presentación modificada como un archivo PPTX.

```java
//Instanciar la presentación
Presentation presentation = new Presentation("presentation.pptx");

//la primera forma
byte[] data = Files.readAllBytes(Paths.get("image0.jpeg"));
IPPImage oldImage = presentation.getImages().get_Item(0);
oldImage.replaceImage(data);

//la segunda forma
IImage newImage = Images.fromFile("image1.png");
oldImage = presentation.getImages().get_Item(1);
oldImage.replaceImage(newImage);
newImage.dispose();

//la tercera forma
oldImage = presentation.getImages().get_Item(2);
oldImage.replaceImage(presentation.getImages().get_Item(3));

//Guardar la presentación
presentation.save("c:\\Presentations\\TestSmart.pptx", SaveFormat.Pptx);
presentation.dispose();
```
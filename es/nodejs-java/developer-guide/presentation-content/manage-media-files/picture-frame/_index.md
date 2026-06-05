---
title: Gestionar marcos de imagen en presentaciones usando JavaScript
linktitle: Marco de Imagen
type: docs
weight: 10
url: /es/nodejs-java/picture-frame/
keywords:
- marco de imagen
- añadir marco de imagen
- crear marco de imagen
- añadir imagen
- crear imagen
- extraer imagen
- imagen raster
- imagen vectorial
- recortar imagen
- zona recortada
- propiedad StretchOff
- formato de marco de imagen
- propiedades del marco de imagen
- escala relativa
- efecto de imagen
- proporción de aspecto
- transparencia de imagen
- PowerPoint
- OpenDocument
- presentación
- Node.js
- JavaScript
- Aspose.Slides
description: "Añade marcos de imagen a presentaciones PowerPoint y OpenDocument con Aspose.Slides para Node.js a través de Java. Optimiza tu flujo de trabajo y mejora el diseño de las diapositivas."
---
## **Introducción**

Un marco de imagen es una forma que contiene una imagen; es como una foto dentro de un marco.

Puedes añadir una imagen a una diapositiva a través de un marco de imagen. De este modo, puedes dar formato a la imagen formateando el marco de imagen.

{{% alert  title="Tip" color="primary" %}} 

Aspose ofrece conversores gratuitos—[JPEG a PowerPoint](https://products.aspose.app/slides/es/import/jpg-to-ppt) y [PNG a PowerPoint](https://products.aspose.app/slides/es/import/png-to-ppt)—que permiten crear presentaciones rápidamente a partir de imágenes. 

{{% /alert %}} 

## **Crear Marco de Imagen**

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/Presentation).
2. Obtenga una referencia a una diapositiva mediante su índice. 
3. Cree un objeto `PPImage` añadiendo una imagen a la [ImagesCollection](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/ImageCollection) asociada al objeto de presentación que se utilizará para rellenar la forma.
4. Especifique el ancho y la altura de la imagen.
5. Cree un [PictureFrame](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/PictureFrame) basado en el ancho y la altura de la imagen mediante el método `addPictureFrame` expuesto por el objeto de forma asociado a la diapositiva referenciada.
6. Añada un marco de imagen (que contiene la foto) a la diapositiva.
7. Guarde la presentación modificada como un archivo PPTX.

Este código JavaScript muestra cómo crear un marco de imagen:

```javascript
// Instancia la clase Presentation que representa un archivo PPTX
var pres = new aspose.slides.Presentation();
try {
    // Obtiene la primera diapositiva
    var sld = pres.getSlides().get_Item(0);
    // Instancia la clase Image
    var imgx = pres.getImages().addImage(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "asp1.jpg")));
    // Añade un marco de imagen con la altura y anchura equivalentes de la foto
    sld.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    // Escribe el archivo PPTX en disco
    pres.save("RectPicFrame.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Los marcos de imagen le permiten crear rápidamente diapositivas de presentación a partir de imágenes. Cuando combina el marco de imagen con las opciones de guardado de Aspose.Slides, puede manipular operaciones de entrada/salida para convertir imágenes de un formato a otro.

## **Crear Marco de Imagen con Escala Relativa**

Al modificar la escala relativa de una imagen, puede crear un marco de imagen más complejo. 

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/Presentation).

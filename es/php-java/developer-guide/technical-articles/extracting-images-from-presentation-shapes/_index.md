---
title: Extraer imágenes de formas en presentaciones
linktitle: Imagen de forma
type: docs
weight: 100
url: /es/php-java/extracting-images-from-presentation-shapes/
keywords:
- extraer imagen
- recuperar imagen
- fondo de diapositiva
- fondo de forma
- PowerPoint
- OpenDocument
- presentación
- PHP
- Aspose.Slides
description: "Extraiga imágenes de formas en presentaciones PowerPoint y OpenDocument con Aspose.Slides para PHP mediante Java — solución rápida y fácil de codificar."
---

## **Extraer imágenes de formas**

{{% alert color="primary" %}} 

Las imágenes a menudo se añaden a formas y también se usan con frecuencia como fondos de diapositivas. Los objetos de imagen se añaden mediante [IImageCollection](https://reference.aspose.com/slides/php-java/aspose.slides/iimagecollection/), que es una colección de objetos [IPPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ippimage/).

Este artículo explica cómo puede extraer las imágenes añadidas a presentaciones. 

{{% /alert %}} 

Para extraer una imagen de una presentación, debe localizar la imagen primero recorriendo cada diapositiva y luego cada forma. Una vez que la imagen se encuentra o identifica, puede extraerla y guardarla como un nuevo archivo. 
```php

```


## **FAQ**

**¿Puedo extraer la imagen original sin recortar, sin efectos ni transformaciones de forma?**

Sí. Cuando accede a la imagen de una forma, obtiene el objeto de imagen de la [colección de imágenes](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getimages/) de la presentación, lo que significa los píxeles originales sin recorte ni efectos de estilo. El flujo de trabajo recorre la colección de imágenes de la presentación y los objetos [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/), que almacenan los datos sin procesar.

**¿Existe el riesgo de duplicar archivos idénticos al guardar muchas imágenes a la vez?**

Sí, si guarda todo indiscriminadamente. La [colección de imágenes](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getimages/) de una presentación puede contener datos binarios idénticos referenciados por distintas formas o diapositivas. Para evitar duplicados, compare hashes, tamaños o contenidos de los datos extraídos antes de escribir.

**¿Cómo puedo determinar qué formas están vinculadas a una imagen específica de la colección de la presentación?**

Aspose.Slides no almacena enlaces inversos de [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/) a formas. Construya un mapeo manualmente durante la recorrida: siempre que encuentre una referencia a un [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/), registre qué formas lo utilizan.

**¿Puedo extraer imágenes incrustadas dentro de objetos OLE, como documentos adjuntos?**

No directamente, porque un objeto OLE es un contenedor. Necesita extraer el paquete OLE mismo y luego analizar su contenido con herramientas separadas. Las formas de imagen de la presentación funcionan mediante [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/); OLE es un tipo de objeto diferente.
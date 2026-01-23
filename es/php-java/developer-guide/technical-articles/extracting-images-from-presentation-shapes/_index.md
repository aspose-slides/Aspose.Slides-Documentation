---
title: Extraer imágenes de formas de presentación
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
description: "Extraiga imágenes de las formas en presentaciones PowerPoint y OpenDocument con Aspose.Slides para PHP a través de Java — solución rápida y fácil de usar."
---

## **Extraer imágenes de formas**

{{% alert color="primary" %}} 

Las imágenes se añaden a menudo a las formas y también se utilizan frecuentemente como fondos de diapositivas. Los objetos de imagen se añaden mediante [ImageCollection](https://reference.aspose.com/slides/php-java/aspose.slides/imagecollection/), que es una colección de objetos [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/).

Este artículo explica cómo puede extraer las imágenes añadidas a presentaciones. 

{{% /alert %}} 

Para extraer una imagen de una presentación, debe localizarla primero recorriendo cada diapositiva y, a su vez, cada forma. Una vez que la imagen se encuentre o identifique, puede extraerla y guardarla como un archivo nuevo. 
```php

```


## **FAQ**

**¿Puedo extraer la imagen original sin recortes, efectos o transformaciones de forma?**

Sí. Cuando accede a la imagen de una forma, obtiene el objeto de imagen de la [image collection](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getimages/) de la presentación, lo que significa los píxeles originales sin recortes ni efectos de estilo. El flujo de trabajo recorre la colección de imágenes de la presentación y los objetos [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/), que almacenan los datos en bruto.

**¿Existe el riesgo de duplicar archivos idénticos al guardar muchas imágenes a la vez?**

Sí, si guarda todo indiscriminadamente. La [image collection](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getimages/) de una presentación puede contener datos binarios idénticos referenciados por distintas formas o diapositivas. Para evitar duplicados, compare hashes, tamaños o contenidos de los datos extraídos antes de escribirlos.

**¿Cómo puedo determinar qué formas están enlazadas a una imagen concreta de la colección de la presentación?**

Aspose.Slides no almacena enlaces inversos de [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/) a las formas. Construya un mapa manualmente durante el recorrido: siempre que encuentre una referencia a un [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/), registre qué formas lo utilizan.

**¿Puedo extraer imágenes incrustadas dentro de objetos OLE, como documentos adjuntos?**

No directamente, porque un objeto OLE es un contenedor. Necesita extraer el paquete OLE en sí y luego analizar su contenido con herramientas separadas. Las formas de imagen de la presentación funcionan a través de [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/); OLE es un tipo de objeto diferente.
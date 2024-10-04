---
title: Marco de Imagen
type: docs
weight: 10
url: /php-java/picture-frame/
keywords: "Agregar marco de imagen, crear marco de imagen, agregar imagen, crear imagen, extraer imagen, propiedad StretchOff, formateo de marco de imagen, propiedades del marco de imagen, presentación de PowerPoint, Java, Aspose.Slides para PHP a través de Java"
description: "Agregar marco de imagen a la presentación de PowerPoint"

---

Un marco de imagen es una forma que contiene una imagen; es como una imagen en un marco.

Puedes agregar una imagen a una diapositiva a través de un marco de imagen. De esta manera, puedes formatear la imagen al formatear el marco de imagen.

{{% alert  title="Consejo" color="primary" %}} 

Aspose proporciona conversores gratuitos—[JPEG a PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) y [PNG a PowerPoint](https://products.aspose.app/slides/import/png-to-ppt)—que permiten a las personas crear presentaciones rápidamente a partir de imágenes.

{{% /alert %}} 

## **Crear Marco de Imagen**

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Obtén la referencia de una diapositiva a través de su índice.
3. Crea un objeto [IPPImage]() añadiendo una imagen a la [IImagescollection](https://reference.aspose.com/slides/php-java/aspose.slides/IImageCollection) asociada con el objeto de presentación que se usará para llenar la forma.
4. Especifica el ancho y alto de la imagen.
5. Crea un [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/PictureFrame) basado en el ancho y alto de la imagen a través del método `AddPictureFrame` expuesto por el objeto de forma asociado con la diapositiva referenciada.
6. Agrega un marco de imagen (que contiene la imagen) a la diapositiva.
7. Escribe la presentación modificada como un archivo PPTX.

Este código PHP muestra cómo crear un marco de imagen:

```php
  # Instancia la clase Presentation que representa un archivo PPTX
  $pres = new Presentation();
  try {
    # Obtiene la primera diapositiva
    $sld = $pres->getSlides()->get_Item(0);
    # Instancia la clase Image
    $imgx = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "asp1.jpg")));
    # Agrega un marco de imagen con la altura y ancho equivalentes de la imagen
    $sld->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 150, $imgx->getWidth(), $imgx->getHeight(), $imgx);
    # Escribe el archivo PPTX en disco
    $pres->save("RectPicFrame.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="warning" %}} 

Los marcos de imagen te permiten crear rápidamente diapositivas de presentación basadas en imágenes. Cuando combinas el marco de imagen con las opciones de guardado de Aspose.Slides, puedes manipular las operaciones de entrada/salida para convertir imágenes de un formato a otro. Puedes querer ver estas páginas: convertir [imagen a JPG](https://products.aspose.com/slides/php-java/conversion/image-to-jpg/); convertir [JPG a imagen](https://products.aspose.com/slides/php-java/conversion/jpg-to-image/); convertir [JPG a PNG](https://products.aspose.com/slides/php-java/conversion/jpg-to-png/), convertir [PNG a JPG](https://products.aspose.com/slides/php-java/conversion/png-to-jpg/); convertir [PNG a SVG](https://products.aspose.com/slides/php-java/conversion/png-to-svg/), convertir [SVG a PNG](https://products.aspose.com/slides/php-java/conversion/svg-to-png/).

{{% /alert %}}

## **Crear Marco de Imagen con Escala Relativa**

Al alterar la escala relativa de una imagen, puedes crear un marco de imagen más complicado.

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Obtén la referencia de una diapositiva a través de su índice.
3. Agrega una imagen a la colección de imágenes de la presentación.
4. Crea un [IPPImage](https://reference.aspose.com/slides/php-java/aspose.slides/IPPImage) añadiendo una imagen a la [IImagescollection](https://reference.aspose.com/slides/php-java/aspose.slides/IImageCollection) asociada con el objeto de presentación que se usará para llenar la forma.
5. Especifica el ancho y alto relativos de la imagen en el marco de imagen.
6. Escribe la presentación modificada como un archivo PPTX.

Este código PHP muestra cómo crear un marco de imagen con escala relativa:

```php
  # Instancia la clase Presentation que representa el PPTX
  $pres = new Presentation();
  try {
    # Obtiene la primera diapositiva
    $sld = $pres->getSlides()->get_Item(0);
    # Instancia la clase Image
    $imgx = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "asp1.jpg")));
    # Agrega un marco de imagen con altura y ancho equivalentes de la imagen
    $pf = $sld->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 150, $imgx->getWidth(), $imgx->getHeight(), $imgx);
    # Estableciendo la escala relativa de ancho y alto
    $pf->setRelativeScaleHeight(0.8);
    $pf->setRelativeScaleWidth(1.35);
    # Escribe el archivo PPTX en disco
    $pres->save("RectPicFrame.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Extraer Imagen de un Marco de Imagen**

Puedes extraer imágenes de objetos [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/PictureFrame) y guardarlas en formatos PNG, JPG y otros. El siguiente ejemplo de código demuestra cómo extraer una imagen del documento "sample.pptx" y guardarla en formato PNG.

```php
  $presentation = new Presentation("sample.pptx");
  try {
    $firstSlide = $presentation->getSlides()->get_Item(0);
    $firstShape = $firstSlide->getShapes()->get_Item(0);
    if (java_instanceof($firstShape, new JavaClass("com.aspose.slides.PictureFrame"))) {
      $pictureFrame = $firstShape;
      try {
        $slideImage = $pictureFrame->getPictureFormat()->getPicture()->getImage()->getImage();
        $slideImage->save("slide_1_shape_1.png", ImageFormat::Png);
      } finally {
        if (!java_is_null($slideImage)) {
          $slideImage->dispose();
        }
      }
    }
  } catch (JavaException $e) {
  } finally {
    $presentation->dispose();
  }
```

## **Obtener Transparencia de la Imagen**

Aspose.Slides permite obtener la transparencia de una imagen. Este código PHP demuestra la operación:

```php
  $presentation = new Presentation($folderPath . "Test.pptx");
  $pictureFrame = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
  $imageTransform = $pictureFrame->getPictureFormat()->getPicture()->getImageTransform();
  foreach($imageTransform as $effect) {
    if (java_instanceof($effect, new JavaClass("com.aspose.slides.AlphaModulateFixed"))) {
      $alphaModulateFixed = $effect;
      $transparencyValue = 100 - $alphaModulateFixed->getAmount();
      echo("Transparencia de la imagen: " . $transparencyValue);
    }
  }
```

## **Formateo del Marco de Imagen**

Aspose.Slides ofrece muchas opciones de formateo que pueden aplicarse a un marco de imagen. Usando esas opciones, puedes alterar un marco de imagen para que coincida con requisitos específicos.

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Obtén la referencia de una diapositiva a través de su índice.
3. Crea un [IPPImage](https://reference.aspose.com/slides/php-java/aspose.slides/IPPImage) añadiendo una imagen a la [IImagescollection](https://reference.aspose.com/slides/php-java/aspose.slides/IImageCollection) asociada con el objeto de presentación que se usará para llenar la forma.
4. Especifica el ancho y alto de la imagen.
5. Crea un `PictureFrame` basado en el ancho y alto de la imagen a través del método [AddPictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) expuesto por el objeto [IShapes](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection) asociado con la diapositiva referenciada.
6. Agrega el marco de imagen (que contiene la imagen) a la diapositiva.
7. Establece el color de línea del marco de imagen.
8. Establece el ancho de línea del marco de imagen.
9. Rota el marco de imagen dándole un valor positivo o negativo.
   * Un valor positivo rota la imagen en el sentido de las agujas del reloj.
   * Un valor negativo rota la imagen en sentido antihorario.
10. Agrega el marco de imagen (que contiene la imagen) a la diapositiva.
11. Escribe la presentación modificada como un archivo PPTX.

Este código PHP demuestra el proceso de formateo del marco de imagen:

```php
  # Instancia la clase Presentation que representa el PPTX
  $pres = new Presentation();
  try {
    # Obtiene la primera diapositiva
    $sld = $pres->getSlides()->get_Item(0);
    # Instancia la clase Image
    $imgx = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "asp1.jpg")));
    # Agrega un marco de imagen con altura y ancho equivalentes de la imagen
    $pf = $sld->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 150, $imgx->getWidth(), $imgx->getHeight(), $imgx);
    # Aplica algún formato a PictureFrameEx
    $pf->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $pf->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $pf->getLineFormat()->setWidth(20);
    $pf->setRotation(45);
    # Escribe el archivo PPTX en disco
    $pres->save("RectPicFrame.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="Consejo" color="primary" %}}

Aspose recientemente desarrolló un [creador de collages gratuito](https://products.aspose.app/slides/collage). Si alguna vez necesitas [fusionar imágenes JPG/JPEG](https://products.aspose.app/slides/collage/jpg) o PNG, [crear cuadrículas a partir de fotos](https://products.aspose.app/slides/collage/photo-grid), puedes usar este servicio. 

{{% /alert %}}

## **Agregar Imagen como Enlace**

Para evitar tamaños grandes de presentación, puedes agregar imágenes (o videos) a través de enlaces en lugar de incrustar los archivos directamente en las presentaciones. Este código PHP muestra cómo agregar una imagen y un video en un marcador de posición:

```php
  $presentation = new Presentation("input.pptx");
  try {
    $shapesToRemove = new Java("java.util.ArrayList");
    $shapesCount = $presentation->getSlides()->get_Item(0)->getShapes()->size();
    for($i = 0; $i < java_values($shapesCount) ; $i++) {
      $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item($i);
      if (java_is_null($autoShape->getPlaceholder())) {
        continue;
      }
      switch ($autoShape->getPlaceholder()->getType()) {
        case PlaceholderType::Picture :
          $pictureFrame = $presentation->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, $autoShape->getX(), $autoShape->getY(), $autoShape->getWidth(), $autoShape->getHeight(), null);
          $pictureFrame->getPictureFormat()->getPicture()->setLinkPathLong("https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg");
          $shapesToRemove->add($autoShape);
          break;
        case PlaceholderType::Media :
          $videoFrame = $presentation->getSlides()->get_Item(0)->getShapes()->addVideoFrame($autoShape->getX(), $autoShape->getY(), $autoShape->getWidth(), $autoShape->getHeight(), "");
          $videoFrame->getPictureFormat()->getPicture()->setLinkPathLong("https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg");
          $videoFrame->setLinkPathLong("https://youtu.be/t_1LYZ102RA");
          $shapesToRemove->add($autoShape);
          break;
      }
    }
    foreach($shapesToRemove as $shape) {
      $presentation->getSlides()->get_Item(0)->getShapes()->remove($shape);
    }
    $presentation->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Recortar Imagen**

Este código PHP muestra cómo recortar una imagen existente en una diapositiva:

```php
  $pres = new Presentation();
  # Crea un nuevo objeto de imagen
  try {
    $picture;
    $image = Images->fromFile($imagePath);
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # Agrega un PictureFrame a una Diapositiva
    $picFrame = $pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 100, 100, 420, 250, $picture);
    # Recorta la imagen (valores de porcentaje)
    $picFrame->getPictureFormat()->setCropLeft(23.6);
    $picFrame->getPictureFormat()->setCropRight(21.5);
    $picFrame->getPictureFormat()->setCropTop(3);
    $picFrame->getPictureFormat()->setCropBottom(31);
    # Guarda el resultado
    $pres->save($outPptxFile, SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## Eliminar Áreas Recortadas de la Imagen

Si deseas eliminar las áreas recortadas de una imagen contenida en un marco, puedes usar el método [deletePictureCroppedAreas()](https://reference.aspose.com/slides/php-java/aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) que devuelve la imagen recortada o la imagen original si el recorte no es necesario.

Este código PHP demuestra la operación:

```php
  $presentation = new Presentation("PictureFrameCrop.pptx");
  try {
    $slide = $presentation->getSlides()->get_Item(0);
    # Obtiene el PictureFrame de la primera diapositiva
    $picFrame = $slide->getShapes()->get_Item(0);
    # Elimina áreas recortadas de la imagen del PictureFrame y devuelve la imagen recortada
    $croppedImage = $picFrame->getPictureFormat()->deletePictureCroppedAreas();
    # Guarda el resultado
    $presentation->save("PictureFrameDeleteCroppedAreas.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

{{% alert title="NOTA" color="warning" %}} 

El método [deletePictureCroppedAreas()](https://reference.aspose.com/slides/php-java/aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) agrega la imagen recortada a la colección de imágenes de la presentación. Si la imagen solo se usa en el [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/) procesado, esta configuración puede reducir el tamaño de la presentación. De lo contrario, el número de imágenes en la presentación resultante aumentará.

Este método convierte archivos metafiles WMF/EMF a imagen raster PNG en la operación de recorte. 

{{% /alert %}}

## **Bloquear Proporción de Aspecto**

Si deseas que una forma que contiene una imagen mantenga su proporción de aspecto incluso después de cambiar las dimensiones de la imagen, puedes usar el método [setAspectRatioLocked](https://reference.aspose.com/slides/php-java/aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) para establecer la configuración de *Bloquear Proporción de Aspecto*.

Este código PHP muestra cómo bloquear la proporción de aspecto de una forma:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $layout = $pres->getLayoutSlides()->getByType(SlideLayoutType::Custom);
    $emptySlide = $pres->getSlides()->addEmptySlide($layout);
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    $pictureFrame = $emptySlide->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 150, $presImage->getWidth(), $presImage->getHeight(), $picture);
    # Establece la forma para mantener la proporción al redimensionar
    $pictureFrame->getPictureFrameLock()->setAspectRatioLocked(true);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="NOTA" color="warning" %}} 

Esta configuración de *Bloquear Proporción de Aspecto* solo preserva la proporción de aspecto de la forma y no de la imagen que contiene.

{{% /alert %}}

## **Usar Propiedad StretchOff**

Usando las propiedades [StretchOffsetLeft](https://reference.aspose.com/slides/php-java/aspose.slides/IPictureFillFormat#setStretchOffsetLeft-float-), [StretchOffsetTop](https://reference.aspose.com/slides/php-java/aspose.slides/IPictureFillFormat#setStretchOffsetTop--), [StretchOffsetRight](https://reference.aspose.com/slides/php-java/aspose.slides/IPictureFillFormat#setStretchOffsetRight--) y [StretchOffsetBottom](https://reference.aspose.com/slides/php-java/aspose.slides/IPictureFillFormat#setStretchOffsetBottom-float-) de la interfaz [IPictureFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/IPictureFillFormat) y de la clase [PictureFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/IPictureFillFormat), puedes especificar un rectángulo de llenado.

Cuando se especifica que se estire una imagen, un rectángulo fuente se escala para ajustarse al rectángulo de llenado especificado. Cada borde del rectángulo de llenado se define por un desplazamiento porcentual del borde correspondiente de la caja delimitadora de la forma. Un porcentaje positivo especifica un interior, mientras que un porcentaje negativo especifica un exterior.

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentatio).
2. Obtén la referencia de una diapositiva a través de su índice.
3. Agrega una figura rectangular `AutoShape`. 
4. Crea una imagen.
5. Establece el tipo de llenado de la forma.
6. Establece el modo de llenado de imagen de la forma.
7. Agrega una imagen establecida para llenar la forma.
8. Especifica los desplazamientos de la imagen desde el borde correspondiente de la caja delimitadora de la forma.
9. Escribe la presentación modificada como un archivo PPTX.

Este código PHP demuestra un proceso en el que se usa la propiedad StretchOff:

```php
  # Instancia la clase Presentation que representa un archivo PPTX
  $pres = new Presentation();
  try {
    # Obtiene la primera diapositiva
    $slide = $pres->getSlides()->get_Item(0);
    # Instancia la clase ImageEx
    $picture;
    $image = Images->fromFile("aspose-logo.jpg");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # Agrega una AutoShape configurada como Rectángulo
    $aShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 300);
    # Establece el tipo de llenado de la forma
    $aShape->getFillFormat()->setFillType(FillType::Picture);
    # Establece el modo de llenado de imagen de la forma
    $aShape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode->Stretch);
    # Establece la imagen para llenar la forma
    $aShape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);
    # Especifica los desplazamientos de la imagen desde el borde correspondiente de la caja delimitadora de la forma
    $aShape->getFillFormat()->getPictureFillFormat()->setStretchOffsetLeft(25);
    $aShape->getFillFormat()->getPictureFillFormat()->setStretchOffsetRight(25);
    $aShape->getFillFormat()->getPictureFillFormat()->setStretchOffsetTop(-20);
    $aShape->getFillFormat()->getPictureFillFormat()->setStretchOffsetBottom(-10);
    # Escribe el archivo PPTX en disco
    $pres->save("StretchOffsetLeftForPictureFrame_out.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
---
title: Gestionar marcos de imagen en presentaciones con PHP
linktitle: Marco de imagen
type: docs
weight: 10
url: /es/php-java/picture-frame/
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
- área recortada
- propiedad StretchOff
- formateo de marco de imagen
- propiedades de marco de imagen
- escala relativa
- efecto de imagen
- relación de aspecto
- transparencia de imagen
- PowerPoint
- OpenDocument
- presentación
- PHP
- Aspose.Slides
description: "Añade marcos de imagen a presentaciones PowerPoint y OpenDocument con Aspose.Slides para PHP mediante Java. Optimiza tu flujo de trabajo y mejora el diseño de las diapositivas."
---

Un marco de imagen es una forma que contiene una imagen—es como una foto en un marco. 

Puedes añadir una imagen a una diapositiva mediante un marco de imagen. De este modo, puedes dar formato a la imagen formateando el marco de imagen.

{{% alert  title="Tip" color="primary" %}} 

Aspose ofrece conversores gratuitos—[JPEG to PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) y [PNG to PowerPoint](https://products.aspose.app/slides/import/png-to-ppt)—que permiten crear presentaciones rápidamente a partir de imágenes. 

{{% /alert %}} 

## **Crear un Marco de Imagen**

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Obtén una referencia a una diapositiva mediante su índice. 
3. Crea un objeto [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/) añadiendo una imagen a la [Imagescollection](https://reference.aspose.com/slides/php-java/aspose.slides/imagecollection/) asociada al objeto de presentación que se utilizará para rellenar la forma.
4. Especifica el ancho y la altura de la imagen.
5. Crea un [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/) basado en el ancho y la altura de la imagen mediante el método `addPictureFrame` expuesto por el objeto shape asociado a la diapositiva referenciada.
6. Añade un marco de imagen (que contiene la foto) a la diapositiva.
7. Guarda la presentación modificada como un archivo PPTX.

Este código PHP te muestra cómo crear un marco de imagen:
```php
  # Instancia la clase Presentation que representa un archivo PPTX
  $pres = new Presentation();
  try {
    # Obtiene la primera diapositiva
    $sld = $pres->getSlides()->get_Item(0);
    # Instancia la clase Image
    $imgx = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "asp1.jpg")));
    # Añade un marco de imagen con la altura y anchura equivalentes de la imagen
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

Los marcos de imagen te permiten crear rápidamente diapositivas de presentación basadas en imágenes. Cuando combinas el marco de imagen con las opciones de guardado de Aspose.Slides, puedes manipular operaciones de entrada/salida para convertir imágenes de un formato a otro. Es posible que quieras consultar estas páginas: convertir [imagen a JPG](https://products.aspose.com/slides/php-java/conversion/image-to-jpg/); convertir [JPG a imagen](https://products.aspose.com/slides/php-java/conversion/jpg-to-image/); convertir [JPG a PNG](https://products.aspose.com/slides/php-java/conversion/jpg-to-png/), convertir [PNG a JPG](https://products.aspose.com/slides/php-java/conversion/png-to-jpg/); convertir [PNG a SVG](https://products.aspose.com/slides/php-java/conversion/png-to-svg/), convertir [SVG a PNG](https://products.aspose.com/slides/php-java/conversion/svg-to-png/).

{{% /alert %}}

## **Crear un Marco de Imagen con Escala Relativa**

Al alterar la escala relativa de una imagen, puedes crear un marco de imagen más complejo. 

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Obtén una referencia a una diapositiva mediante su índice. 
3. Añade una imagen a la colección de imágenes de la presentación.
4. Crea un objeto [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/) añadiendo una imagen a la [Imagescollection](https://reference.aspose.com/slides/php-java/aspose.slides/imagecollection/) asociada al objeto de presentación que se utilizará para rellenar la forma.
5. Especifica el ancho y la altura relativos de la imagen en el marco de imagen.
6. Guarda la presentación modificada como un archivo PPTX.

Este código PHP te muestra cómo crear un marco de imagen con escala relativa:
```php
  # Instancia la clase Presentation que representa el PPTX
  $pres = new Presentation();
  try {
    # Obtiene la primera diapositiva
    $sld = $pres->getSlides()->get_Item(0);
    # Instancia la clase Image
    $imgx = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "asp1.jpg")));
    # Añade un marco de imagen con la altura y anchura equivalentes de la imagen
    $pf = $sld->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 150, $imgx->getWidth(), $imgx->getHeight(), $imgx);
    # Estableciendo escala relativa de anchura y altura
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


## **Extraer Imágenes Raster de Marcos de Imagen**

Puedes extraer imágenes raster de objetos [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/) y guardarlas en PNG, JPG y otros formatos. El ejemplo de código a continuación muestra cómo extraer una imagen del documento “sample.pptx” y guardarla en formato PNG.
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


## **Extraer Imágenes SVG de Marcos de Imagen**

Cuando una presentación contiene gráficos SVG colocados dentro de formas [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/), Aspose.Slides for PHP via Java te permite recuperar las imágenes vectoriales originales con plena fidelidad. Al recorrer la colección de formas de la diapositiva, puedes identificar cada [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/), comprobar si el [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/) subyacente contiene contenido SVG y, a continuación, guardar esa imagen en disco o en un flujo en su formato SVG nativo.

El siguiente ejemplo de código muestra cómo extraer una imagen SVG de un marco de imagen:
```php
$presentation = new Presentation("sample.pptx");

try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    if (java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
        $svgImage = $shape->getPictureFormat()->getPicture()->getImage()->getSvgImage();

        if ($svgImage !== null) {
            file_put_contents("output.svg", $svgImage->getSvgData());
        }
    }
} finally {
    $presentation->dispose();
}
```


## **Obtener la Transparencia de una Imagen**

Aspose.Slides te permite obtener el efecto de transparencia aplicado a una imagen. Este código PHP demuestra la operación:
```php
  $presentation = new Presentation("Test.pptx");
  $pictureFrame = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
  $imageTransform = $pictureFrame->getPictureFormat()->getPicture()->getImageTransform();
  foreach($imageTransform as $effect) {
    if (java_instanceof($effect, new JavaClass("com.aspose.slides.AlphaModulateFixed"))) {
      $alphaModulateFixed = $effect;
      $transparencyValue = 100 - $alphaModulateFixed->getAmount();
      echo("Picture transparency: " . $transparencyValue);
    }
  }
```


## **Formato de Marcos de Imagen**

Aspose.Slides proporciona numerosas opciones de formato que pueden aplicarse a un marco de imagen. Con esas opciones, puedes modificar un marco de imagen para que cumpla requisitos específicos.

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Obtén una referencia a una diapositiva mediante su índice. 
3. Crea un objeto [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/) añadiendo una imagen a la [Imagescollection](https://reference.aspose.com/slides/php-java/aspose.slides/imagecollection/) asociada al objeto de presentación que se utilizará para rellenar la forma.
4. Especifica el ancho y la altura de la imagen.
5. Crea un `PictureFrame` basado en el ancho y la altura de la imagen mediante el método [addPictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addpictureframe/) expuesto por el objeto [ShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/) asociado a la diapositiva referenciada.
6. Añade el marco de imagen (que contiene la foto) a la diapositiva.
7. Establece el color de línea del marco de imagen.
8. Establece el ancho de línea del marco de imagen.
9. Gira el marco de imagen proporcionándole un valor positivo o negativo.
   * Un valor positivo gira la imagen en sentido horario. 
   * Un valor negativo gira la imagen en sentido antihorario.
10. Añade el marco de imagen (que contiene la foto) a la diapositiva.
11. Guarda la presentación modificada como un archivo PPTX.

Este código PHP demuestra el proceso de formato de marcos de imagen:
```php
  # Instancia la clase Presentation que representa el PPTX
  $pres = new Presentation();
  try {
    # Obtiene la primera diapositiva
    $sld = $pres->getSlides()->get_Item(0);
    # Instancia la clase Image
    $imgx = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "asp1.jpg")));
    # Añade un marco de imagen con la altura y anchura equivalentes de la imagen
    $pf = $sld->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 150, $imgx->getWidth(), $imgx->getHeight(), $imgx);
    # Aplica algo de formato a PictureFrameEx
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


{{% alert title="Tip" color="primary" %}}

Aspose ha desarrollado recientemente un [fabricante de collages gratuito](https://products.aspose.app/slides/collage). Si alguna vez necesitas [fusionar imágenes JPG/JPEG](https://products.aspose.app/slides/collage/jpg) o PNG, [crear cuadrículas a partir de fotos](https://products.aspose.app/slides/collage/photo-grid), puedes usar este servicio. 

{{% /alert %}}

## **Añadir una Imagen como Enlace**

Para evitar tamaños de presentación grandes, puedes añadir imágenes (o videos) mediante enlaces en lugar de incrustar los archivos directamente en las presentaciones. Este código PHP muestra cómo añadir una imagen y un video en un marcador de posición:
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


## **Recortar Imágenes**

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
    # Añade un PictureFrame a una diapositiva
    $picFrame = $pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 100, 100, 420, 250, $picture);
    # Recorta la imagen (valores en porcentaje)
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


## **Eliminar Áreas Recortadas de una Imagen**

Si deseas eliminar las áreas recortadas de una imagen contenida en un marco, puedes usar el método [deletePictureCroppedAreas()](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas). Este método devuelve la imagen recortada o la imagen original si el recorte no es necesario.

Este código PHP demuestra la operación:
```php
  $presentation = new Presentation("PictureFrameCrop.pptx");
  try {
    $slide = $presentation->getSlides()->get_Item(0);
    # Obtiene el PictureFrame de la primera diapositiva
    $picFrame = $slide->getShapes()->get_Item(0);
    # Elimina las áreas recortadas de la imagen del PictureFrame y devuelve la imagen recortada
    $croppedImage = $picFrame->getPictureFormat()->deletePictureCroppedAreas();
    # Guarda el resultado
    $presentation->save("PictureFrameDeleteCroppedAreas.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```


{{% alert title="NOTE" color="warning" %}} 

El método [deletePictureCroppedAreas()](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) añade la imagen recortada a la colección de imágenes de la presentación. Si la imagen se usa solo en el [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/) procesado, esta configuración puede reducir el tamaño de la presentación. En caso contrario, el número de imágenes en la presentación resultante aumentará.

Este método convierte archivos metafile WMF/EMF a imágenes PNG raster en la operación de recorte. 

{{% /alert %}}

## **Bloquear Relación de Aspecto**

Si deseas que una forma que contiene una imagen mantenga su relación de aspecto incluso después de cambiar las dimensiones de la imagen, puedes usar el método [setAspectRatioLocked](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframelock/setaspectratiolocked/) para establecer la configuración *Lock Aspect Ratio*.

Este código PHP muestra cómo bloquear la relación de aspecto de una forma:
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
    # establece la forma para que preserve la relación de aspecto al redimensionar
    $pictureFrame->getPictureFrameLock()->setAspectRatioLocked(true);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


{{% alert title="NOTE" color="warning" %}} 

Esta configuración *Lock Aspect Ratio* conserva solo la relación de aspecto de la forma y no la de la imagen que contiene.

{{% /alert %}}

## **Usar la Propiedad StretchOff**

Con los métodos [setStretchOffsetLeft](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/setstretchoffsetleft/), [setStretchOffsetTop](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/setstretchoffsettop/), [setStretchOffsetRight](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/setstretchoffsetright/) y [setStretchOffsetBottom](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/setstretchoffsetbottom/) de la clase [PictureFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/), puedes especificar un rectángulo de relleno.

Cuando se especifica el estiramiento para una imagen, un rectángulo fuente se escala para ajustarse al rectángulo de relleno especificado. Cada borde del rectángulo de relleno se define mediante un desplazamiento porcentual desde el borde correspondiente del cuadro delimitador de la forma. Un porcentaje positivo indica una inserción, mientras que un porcentaje negativo indica una expansión.

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Obtén una referencia a una diapositiva mediante su índice.
3. Añade un rectángulo `AutoShape`. 
4. Crea una imagen.
5. Establece el tipo de relleno de la forma.
6. Establece el modo de relleno de imagen de la forma.
7. Añade una imagen establecida para rellenar la forma.
8. Especifica los desplazamientos de la imagen desde el borde correspondiente del cuadro delimitador de la forma
9. Guarda la presentación modificada como un archivo PPTX.

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
    # Añade una AutoShape establecida como Rectángulo
    $aShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 300);
    # Define el tipo de relleno de la forma
    $aShape->getFillFormat()->setFillType(FillType::Picture);
    # Define el modo de relleno de imagen de la forma
    $aShape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode->Stretch);
    # Asigna la imagen para rellenar la forma
    $aShape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);
    # Especifica los desplazamientos de la imagen desde el borde correspondiente del cuadro delimitador de la forma
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


## **Preguntas frecuentes**

**¿Cómo puedo averiguar qué formatos de imagen son compatibles con PictureFrame?**

Aspose.Slides admite tanto imágenes raster (PNG, JPEG, BMP, GIF, etc.) como imágenes vectoriales (por ejemplo, SVG) a través del objeto de imagen que se asigna a un [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/). La lista de formatos compatibles generalmente se superpone con las capacidades del motor de conversión de diapositivas e imágenes.

**¿Cómo afectará la incorporación de decenas de imágenes grandes al tamaño y rendimiento del PPTX?**

Incrustar imágenes grandes incrementa el tamaño del archivo y el uso de memoria; enlazar imágenes ayuda a mantener reducido el tamaño de la presentación pero requiere que los archivos externos permanezcan accesibles. Aspose.Slides ofrece la posibilidad de añadir imágenes mediante enlace para reducir el tamaño del archivo.

**¿Cómo puedo bloquear un objeto de imagen para evitar moverlo o redimensionarlo accidentalmente?**

Utiliza los [bloqueos de forma](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/getpictureframelock/) para un [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/) (por ejemplo, desactivar el movimiento o el cambio de tamaño). El mecanismo de bloqueo se describe para formas en un [artículo de protección](/slides/es/php-java/applying-protection-to-presentation/) separado y es compatible con varios tipos de forma, incluido [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/).

**¿Se conserva la fidelidad vectorial SVG al exportar una presentación a PDF/imágenes?**

Aspose.Slides permite extraer un SVG de un [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/) como el vector original. Al [exportar a PDF](/slides/es/php-java/convert-powerpoint-to-pdf/) o a [formatos raster](/slides/es/php-java/convert-powerpoint-to-png/), el resultado puede rasterizarse según la configuración de exportación; el hecho de que el SVG original se almacene como vector se confirma mediante el comportamiento de extracción.
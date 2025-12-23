---
title: Optimizar la gestión de imágenes en presentaciones usando PHP
linktitle: Gestionar imágenes
type: docs
weight: 10
url: /es/php-java/image/
keywords:
- agregar imagen
- agregar foto
- agregar bitmap
- reemplazar imagen
- reemplazar foto
- desde la web
- fondo
- agregar PNG
- agregar JPG
- agregar SVG
- agregar EMF
- agregar WMF
- agregar TIFF
- PowerPoint
- OpenDocument
- presentación
- EMF
- SVG
- PHP
- Aspose.Slides
description: "Optimiza la gestión de imágenes en PowerPoint y OpenDocument con Aspose.Slides para PHP a través de Java, mejorando el rendimiento y automatizando tu flujo de trabajo."
---

## **Imágenes en diapositivas de presentación**

Las imágenes hacen que las presentaciones sean más atractivas e interesantes. En Microsoft PowerPoint, puedes insertar imágenes desde un archivo, Internet u otras ubicaciones en las diapositivas. De manera similar, Aspose.Slides te permite añadir imágenes a las diapositivas de tus presentaciones mediante diferentes procedimientos. 

{{% alert  title="Tip" color="primary" %}} 

Aspose ofrece convertidores gratuitos—[JPEG to PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) y [PNG to PowerPoint](https://products.aspose.app/slides/import/png-to-ppt)—que permiten crear presentaciones rápidamente a partir de imágenes. 

{{% /alert %}} 

{{% alert title="Info" color="info" %}}

Si deseas agregar una imagen como objeto de marco—especialmente si planeas usar opciones de formato estándar para cambiar su tamaño, agregar efectos, etc.—consulta [Picture Frame](https://docs.aspose.com/slides/php-java/picture-frame/). 

{{% /alert %}} 

{{% alert title="Note" color="warning" %}}

Puedes manipular operaciones de entrada/salida que involucren imágenes y presentaciones de PowerPoint para convertir una imagen de un formato a otro. Consulta estas páginas: convertir [image to JPG](https://products.aspose.com/slides/php-java/conversion/image-to-jpg/); convertir [JPG to image](https://products.aspose.com/slides/php-java/conversion/jpg-to-image/); convertir [JPG to PNG](https://products.aspose.com/slides/php-java/conversion/jpg-to-png/), convertir [PNG to JPG](https://products.aspose.com/slides/php-java/conversion/png-to-jpg/); convertir [PNG to SVG](https://products.aspose.com/slides/php-java/conversion/png-to-svg/), convertir [SVG to PNG](https://products.aspose.com/slides/php-java/conversion/svg-to-png/). 

{{% /alert %}}

Aspose.Slides admite operaciones con imágenes en estos formatos populares: JPEG, PNG, GIF y otros. 

## **Agregar imágenes almacenadas localmente a las diapositivas**

Puedes agregar una o varias imágenes de tu computadora a una diapositiva de una presentación. Este fragmento de código muestra cómo agregar una imagen a una diapositiva:
```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $picture);
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Agregar imágenes desde la web a las diapositivas**

Si la imagen que deseas agregar a una diapositiva no está disponible en tu computadora, puedes añadirla directamente desde la web. 

Este fragmento de código muestra cómo agregar una imagen desde la web a una diapositiva:
```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $imageUrl = new URL("[REPLACE WITH URL]");
    $connection = $imageUrl->openConnection();
    $inputStream = $connection->getInputStream();
    $outputStream = new Java("java.io.ByteArrayOutputStream");
    $Array = new java_class("java.lang.reflect.Array");
    $Byte = new JavaClass("java.lang.Byte");
    try {
      $buffer = $Array->newInstance($Byte, 1024);
      $read;
      while ($read = $inputStream->read($buffer, 0, $Array->getLength($buffer)) != -1) {
        $outputStream->write($buffer, 0, $read);
      } 
      $outputStream->flush();
      $image = $pres->getImages()->addImage($outputStream->toByteArray());
      $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $image);
    } finally {
      if (!java_is_null($inputStream)) {
        $inputStream->close();
      }
      $outputStream->close();
    }
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Agregar imágenes a los maestros de diapositivas**

Un maestro de diapositivas es la diapositiva superior que almacena y controla información (tema, diseño, etc.) de todas las diapositivas bajo él. Por lo tanto, cuando agregas una imagen a un maestro de diapositivas, esa imagen aparece en cada diapositiva bajo ese maestro. 

Este fragmento de código Java muestra cómo agregar una imagen a un maestro de diapositivas:
```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $masterSlide = $slide->getLayoutSlide()->getMasterSlide();
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    $masterSlide->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $picture);
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Agregar imágenes como fondos de diapositiva**

Puedes decidir usar una foto como fondo de una diapositiva específica o de varias diapositivas. En ese caso, debes consultar *[Setting Images as Backgrounds for Slides](https://docs.aspose.com/slides/php-java/presentation-background/#setting-images-as-background-for-slides)*. 

## **Agregar SVG a presentaciones**

Puedes añadir o insertar cualquier imagen en una presentación usando el método [addPictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) que pertenece a la interfaz [IShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection). 

Para crear un objeto de imagen basado en una imagen SVG, puedes hacerlo de la siguiente manera:

1. Crear un objeto SvgImage para insertarlo en ImageShapeCollection.  
2. Crear un objeto PPImage a partir de ISvgImage.  
3. Crear un objeto PictureFrame usando la interfaz IPPImage.  

Este fragmento de código muestra cómo implementar los pasos anteriores para agregar una imagen SVG a una presentación:
```php
  # Instanciar la clase Presentation que representa el archivo PPTX
  $pres = new Presentation();
  try {
$Array = new JavaClass("java.lang.reflect.Array");
$Byte = (new JavaClass("java.lang.Byte"))->TYPE;
try {
    $dis = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", "image.svg"));
    $bytes = $Array->newInstance($Byte, $dis->available());
    $dis->readFully($bytes);
} finally {
    if (!java_is_null($dis)) $dis->close();
}
    $svgContent = new String($bytes);

    $svgImage = new SvgImage($svgContent);
    $ppImage = $pres->getImages()->addImage($svgImage);
    $pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 0, 0, $ppImage->getWidth(), $ppImage->getHeight(), $ppImage);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Convertir SVG a un conjunto de formas**

La conversión de SVG a un conjunto de formas de Aspose.Slides es similar a la funcionalidad de PowerPoint utilizada para trabajar con imágenes SVG:

![PowerPoint Popup Menu](img_01_01.png)

La funcionalidad la proporciona una de las sobrecargas del método [addGroupShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addGroupShape-com.aspose.slides.ISvgImage-float-float-float-float-) de la interfaz [IShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection) que recibe un objeto [ISvgImage](https://reference.aspose.com/slides/php-java/aspose.slides/ISvgImage) como primer argumento. 

Este fragmento de código muestra cómo usar el método descrito para convertir un archivo SVG a un conjunto de formas:
```php
  # Crear nueva presentación
  $presentation = new Presentation();
  try {
    # Leer el contenido del archivo SVG
$Array = new JavaClass("java.lang.reflect.Array");
$Byte = (new JavaClass("java.lang.Byte"))->TYPE;
try {
    $dis = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", "image.svg"));
    $bytes = $Array->newInstance($Byte, $dis->available());
    $dis->readFully($bytes);
} finally {
    if (!java_is_null($dis)) $dis->close();
}
    $svgContent = $bytes;

    # Crear objeto SvgImage
    $svgImage = new SvgImage($svgContent);
    # Obtener el tamaño de la diapositiva
    $slideSize = $presentation->getSlideSize()->getSize();
    # Convertir la imagen SVG a un grupo de formas escalándola al tamaño de la diapositiva
    $presentation->getSlides()->get_Item(0)->getShapes()->addGroupShape($svgImage, 0.0, 0.0, $slideSize->getWidth(), $slideSize->getHeight());
    # Guardar la presentación en formato PPTX
    $presentation->save("output.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```


## **Agregar imágenes como EMF a las diapositivas**

Aspose.Slides for PHP vía Java te permite generar imágenes EMF a partir de hojas de Excel y agregar las imágenes como EMF en diapositivas con Aspose.Cells.  

Este fragmento de código muestra cómo realizar la tarea descrita:
```php
  $book = new Workbook("chart.xlsx");
  $sheet = $book->getWorksheets()->get(0);
  $options = new ImageOrPrintOptions();
  $options->setHorizontalResolution(200);
  $options->setVerticalResolution(200);
  $options->setImageType(ImageType::EMF);
  # Guardar el libro de trabajo en el flujo
  $sr = new SheetRender($sheet, $options);
  $pres = new Presentation();
  try {
    $pres->getSlides()->removeAt(0);
    $EmfSheetName = "";
    for($j = 0; $j < java_values($sr->getPageCount()) ; $j++) {
      $EmfSheetName = "test" . $sheet->getName() . " Page" . $j + 1 . ".out.emf";
      $sr->toImage($j, $EmfSheetName);
      $picture;
      $image = Images->fromFile($EmfSheetName);
      try {
        $picture = $pres->getImages()->addImage($image);
      } finally {
        if (!java_is_null($image)) {
          $image->dispose();
        }
      }
      $slide = $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->getByType(SlideLayoutType::Blank));
      $m = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 0, 0, $pres->getSlideSize()->getSize()->getWidth(), $pres->getSlideSize()->getSize()->getHeight(), $picture);
    }
    $pres->save("output.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Reemplazar imágenes en la colección de imágenes**

Aspose.Slides te permite reemplazar imágenes almacenadas en la colección de imágenes de una presentación (incluidas las usadas por formas de diapositivas). Esta sección muestra varios enfoques para actualizar imágenes en la colección. La API proporciona métodos sencillos para reemplazar una imagen usando datos byte sin procesar, una instancia de [IImage](https://reference.aspose.com/slides/php-java/aspose.slides/iimage/) o otra imagen que ya exista en la colección. 

Sigue los pasos a continuación:

1. Carga el archivo de presentación que contiene imágenes usando la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).  
2. Carga una nueva imagen desde un archivo a un arreglo de bytes.  
3. Reemplaza la imagen objetivo con la nueva imagen usando el arreglo de bytes.  
4. En el segundo enfoque, carga la imagen en un objeto [IImage](https://reference.aspose.com/slides/php-java/aspose.slides/iimage/) y reemplaza la imagen objetivo con ese objeto.  
5. En el tercer enfoque, reemplaza la imagen objetivo con una imagen que ya exista en la colección de imágenes de la presentación.  
6. Guarda la presentación modificada como un archivo PPTX.  
```php
// Instanciar la clase Presentation que representa un archivo de presentación.
$presentation = new Presentation("sample.pptx");
try {
    // La primera forma.
    $imagePath = (new Java("java.io.File", "image0.jpeg"))->toPath();
    $imageData = (new Java("java.nio.file.Files"))->readAllBytes($imagePath);
    $oldImage = $presentation->getImages()->get_Item(0);
    $oldImage->replaceImage($imageData);

    // La segunda forma.
    $newImage = Images::fromFile("image1.png");
    $oldImage = $presentation->getImages()->get_Item(1);
    $oldImage->replaceImage($newImage);
    $newImage->dispose();
    
    // La tercera forma.
    $oldImage = $presentation->getImages()->get_Item(2);
    $oldImage->replaceImage($presentation->getImages()->get_Item(3));
    
    // Guardar la presentación en un archivo.
    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```


{{% alert title="Info" color="info" %}}

Usando el convertidor GRATUITO Aspose [Text to GIF](https://products.aspose.app/slides/text-to-gif), puedes animar textos fácilmente, crear GIFs a partir de textos, etc. 

{{% /alert %}}

## **Preguntas frecuentes**

**¿Se mantiene la resolución original de la imagen después de insertarla?**

Sí. Los píxeles originales se conservan, pero la apariencia final depende de cómo se escale la [picture](/slides/es/php-java/picture-frame/) en la diapositiva y de cualquier compresión aplicada al guardar.

**¿Cuál es la mejor manera de reemplazar el mismo logotipo en docenas de diapositivas a la vez?**

Coloca el logotipo en la diapositiva maestra o en un diseño y reemplázalo en la colección de imágenes de la presentación; las actualizaciones se propagarán a todos los elementos que usan ese recurso.

**¿Se puede convertir un SVG insertado en formas editables?**

Sí. Puedes convertir un SVG en un grupo de formas, después de lo cual cada parte se vuelve editable con las propiedades estándar de forma.

**¿Cómo puedo establecer una imagen como fondo de varias diapositivas a la vez?**

[Assign the image as the background](/slides/es/php-java/presentation-background/) en la diapositiva maestra o en el diseño correspondiente; cualquier diapositiva que use esa maestra/diseño heredará el fondo.

**¿Cómo evito que la presentación “infle” de tamaño debido a muchas imágenes?**

Reutiliza un solo recurso de imagen en lugar de duplicados, elige resoluciones razonables, aplica compresión al guardar y mantiene los gráficos repetidos en la maestra cuando sea apropiado.
---
title: Optimizar la gestión de imágenes en presentaciones con PHP
linktitle: Gestionar imágenes
type: docs
weight: 10
url: /es/php-java/image/
keywords:
- añadir imagen
- añadir foto
- añadir mapa de bits
- reemplazar imagen
- reemplazar foto
- desde web
- fondo
- añadir PNG
- añadir JPG
- añadir SVG
- añadir EMF
- añadir WMF
- añadir TIFF
- PowerPoint
- OpenDocument
- presentación
- EMF
- SVG
- PHP
- Aspose.Slides
description: "Simplifique la gestión de imágenes en PowerPoint y OpenDocument con Aspose.Slides para PHP a través de Java, optimizando el rendimiento y automatizando su flujo de trabajo."
---

## **Imágenes en diapositivas de presentación**

Las imágenes hacen que las presentaciones sean más atractivas e interesantes. En Microsoft PowerPoint, puedes insertar imágenes desde un archivo, Internet u otras ubicaciones en las diapositivas. De forma similar, Aspose.Slides permite añadir imágenes a las diapositivas de tus presentaciones mediante diferentes procedimientos. 

{{% alert  title="Tip" color="primary" %}} 

Aspose ofrece convertidores gratuitos—[JPEG to PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) y [PNG to PowerPoint](https://products.aspose.app/slides/import/png-to-ppt)—que permiten crear presentaciones rápidamente a partir de imágenes. 

{{% /alert %}} 

{{% alert title="Info" color="info" %}}

Si deseas añadir una imagen como objeto de marco—especialmente si planeas usar opciones de formato estándar para cambiar su tamaño, añadir efectos, etc.—consulta [Picture Frame](/slides/es/php-java/picture-frame/). 

{{% /alert %}} 

{{% alert title="Note" color="warning" %}}

Puedes manipular operaciones de entrada/salida que involucren imágenes y presentaciones de PowerPoint para convertir una imagen de un formato a otro. Ver estas páginas: convertir [image to JPG](https://products.aspose.com/slides/php-java/conversion/image-to-jpg/); convertir [JPG to image](https://products.aspose.com/slides/php-java/conversion/jpg-to-image/); convertir [JPG to PNG](https://products.aspose.com/slides/php-java/conversion/jpg-to-png/), convertir [PNG to JPG](https://products.aspose.com/slides/php-java/conversion/png-to-jpg/); convertir [PNG to SVG](https://products.aspose.com/slides/php-java/conversion/png-to-svg/), convertir [SVG to PNG](https://products.aspose.com/slides/php-java/conversion/svg-to-png/). 

{{% /alert %}}

Aspose.Slides admite operaciones con imágenes en estos formatos populares: JPEG, PNG, GIF y otros. 

## **Añadir imágenes almacenadas localmente a las diapositivas**

Puedes añadir una o varias imágenes de tu ordenador a una diapositiva de una presentación. Este fragmento de código muestra cómo añadir una imagen a una diapositiva:
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


## **Añadir imágenes de la Web a las diapositivas**

Si la imagen que deseas añadir a una diapositiva no está disponible en tu ordenador, puedes añadirla directamente desde la web. 

Este fragmento de código muestra cómo añadir una imagen de la web a una diapositiva:
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


## **Añadir imágenes a los maestros de diapositivas**

Un maestro de diapositivas es la diapositiva superior que almacena y controla información (tema, diseño, etc.) sobre todas las diapositivas bajo él. Por lo tanto, cuando añades una imagen a un maestro de diapositivas, esa imagen aparece en cada diapositiva bajo ese maestro. 

Este fragmento de código Java muestra cómo añadir una imagen a un maestro de diapositivas:
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


## **Añadir imágenes como fondos de diapositiva**

Puedes decidir usar una foto como fondo de una diapositiva específica o de varias diapositivas. En ese caso, debes consultar cómo [Set an Image as a Slide Background](/slides/es/php-java/presentation-background/#set-an-image-as-a-slide-background). 

## **Añadir SVG a presentaciones**
Puedes añadir o insertar cualquier imagen en una presentación utilizando el método [addPictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addpictureframe/) que pertenece a la clase [ShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/). 

Para crear un objeto de imagen basado en una imagen SVG, puedes hacerlo de esta forma:

1. Crear un objeto SvgImage para insertarlo en ImageShapeCollection  
2. Crear un objeto PPImage a partir de ISvgImage  
3. Crear un objeto PictureFrame usando la clase PPImage  

Este fragmento de código muestra cómo implementar los pasos anteriores para añadir una imagen SVG a una presentación:
```php
  # Instanciar la clase Presentation que representa un archivo PPTX
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

La funcionalidad se proporciona mediante una de las sobrecargas del método [addGroupShape](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addgroupshape/) de la clase [ShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/) que acepta un objeto [SvgImage](https://reference.aspose.com/slides/php-java/aspose.slides/svgimage/) como primer argumento.

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
    # Convertir la imagen SVG en un grupo de formas escalándola al tamaño de la diapositiva
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


## **Añadir imágenes como EMF a las diapositivas**
Aspose.Slides for PHP via Java permite generar imágenes EMF a partir de hojas de Excel y añadir las imágenes como EMF en diapositivas con Aspose.Cells.  

Este fragmento de código muestra cómo realizar la tarea descrita:
```php
  $book = new Workbook("chart.xlsx");
  $sheet = $book->getWorksheets()->get(0);
  $options = new ImageOrPrintOptions();
  $options->setHorizontalResolution(200);
  $options->setVerticalResolution(200);
  $options->setImageType(ImageType::EMF);
  # Guardar el libro de trabajo en flujo
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

Aspose.Slides permite reemplazar imágenes almacenadas en la colección de imágenes de una presentación (incluidas las usadas por formas de diapositivas). Esta sección muestra varios enfoques para actualizar imágenes en la colección. La API ofrece métodos sencillos para reemplazar una imagen usando datos de bytes crudos, una instancia de [IImage](https://reference.aspose.com/slides/php-java/aspose.slides/iimage/) o otra imagen que ya exista en la colección. 

Sigue los pasos a continuación:

1. Cargar el archivo de presentación que contiene imágenes mediante la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).  
2. Cargar una nueva imagen desde un archivo en una matriz de bytes.  
3. Reemplazar la imagen objetivo con la nueva imagen usando la matriz de bytes.  
4. En el segundo enfoque, cargar la imagen en un objeto [IImage](https://reference.aspose.com/slides/php-java/aspose.slides/iimage/) y reemplazar la imagen objetivo con ese objeto.  
5. En el tercer enfoque, reemplazar la imagen objetivo con una imagen que ya exista en la colección de imágenes de la presentación.  
6. Guardar la presentación modificada como archivo PPTX.  
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

Usando el conversor GRATUITO Aspose [Text to GIF](https://products.aspose.app/slides/text-to-gif), puedes animar textos fácilmente, crear GIFs a partir de textos, etc. 

{{% /alert %}}

## **FAQ**

**¿Se conserva la resolución original de la imagen tras la inserción?**

Sí. Los píxeles de origen se preservan, pero el aspecto final depende de cómo se escale la [picture](/slides/es/php-java/picture-frame/) en la diapositiva y de cualquier compresión aplicada al guardar.

**¿Cuál es la mejor manera de reemplazar el mismo logotipo en docenas de diapositivas a la vez?**

Coloca el logotipo en la diapositiva maestra o en un diseño y reemplázalo en la colección de imágenes de la presentación; las actualizaciones se propagarán a todos los elementos que usen ese recurso.

**¿Puede un SVG insertado convertirse en formas editables?**

Sí. Puedes convertir un SVG en un grupo de formas, después de lo cual cada parte se vuelve editable con las propiedades estándar de formas.

**¿Cómo puedo establecer una imagen como fondo de varias diapositivas a la vez?**

[Assign the image as the background](/slides/es/php-java/presentation-background/) en la diapositiva maestra o en el diseño correspondiente; cualquier diapositiva que use esa maestra/diseño heredará el fondo.

**¿Cómo evito que la presentación "infle" de tamaño por muchas imágenes?**

Reutiliza un único recurso de imagen en lugar de duplicados, elige resoluciones razonables, aplica compresión al guardar y mantiene los gráficos repetidos en la maestra cuando sea apropiado.
---
title: Imagen
type: docs
weight: 10
url: /php-java/image/
description: Trabaja con imágenes en diapositivas en presentaciones de PowerPoint usando PHP. Agrega imágenes desde el disco o desde la web en diapositivas de PowerPoint usando PHP. Agrega imágenes a los maestros de diapositivas o como fondo de diapositivas usando PHP. Agrega SVG a la presentación de PowerPoint usando PHP. Convierte SVG a formas en PowerPoint usando PHP. Agrega imágenes como EMF en diapositivas usando PHP.
---

## **Imágenes en Diapositivas en Presentaciones**

Las imágenes hacen que las presentaciones sean más atractivas e interesantes. En Microsoft PowerPoint, puedes insertar imágenes de un archivo, la internet o de otras ubicaciones en las diapositivas. De manera similar, Aspose.Slides te permite agregar imágenes a las diapositivas en tus presentaciones a través de diferentes procedimientos.

{{% alert title="Consejo" color="primary" %}} 

Aspose proporciona convertidores gratuitos—[JPEG a PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) y [PNG a PowerPoint](https://products.aspose.app/slides/import/png-to-ppt)—que permiten a las personas crear presentaciones rápidamente a partir de imágenes.

{{% /alert %}} 

{{% alert title="Información" color="info" %}}

Si deseas agregar una imagen como un objeto marco—especialmente si planeas usar opciones de formato estándar para cambiar su tamaño, agregar efectos, y así sucesivamente—consulta [Marco de Imagen](https://docs.aspose.com/slides/php-java/picture-frame/).

{{% /alert %}} 

{{% alert title="Nota" color="warning" %}}

Puedes manipular operaciones de entrada/salida que involucren imágenes y presentaciones de PowerPoint para convertir una imagen de un formato a otro. Consulta estas páginas: convertir [imagen a JPG](https://products.aspose.com/slides/php-java/conversion/image-to-jpg/); convertir [JPG a imagen](https://products.aspose.com/slides/php-java/conversion/jpg-to-image/); convertir [JPG a PNG](https://products.aspose.com/slides/php-java/conversion/jpg-to-png/), convertir [PNG a JPG](https://products.aspose.com/slides/php-java/conversion/png-to-jpg/); convertir [PNG a SVG](https://products.aspose.com/slides/php-java/conversion/png-to-svg/), convertir [SVG a PNG](https://products.aspose.com/slides/php-java/conversion/svg-to-png/).

{{% /alert %}}

Aspose.Slides admite operaciones con imágenes en estos formatos populares: JPEG, PNG, GIF, y otros.

## **Agregando Imágenes Almacenadas Localmente a Diapositivas**

Puedes agregar una o varias imágenes en tu computadora a una diapositiva en una presentación. Este código de muestra te muestra cómo agregar una imagen a una diapositiva:

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

## **Agregando Imágenes Desde la Web a Diapositivas**

Si la imagen que deseas agregar a una diapositiva no está disponible en tu computadora, puedes agregar la imagen directamente desde la web. 

Este código de muestra te muestra cómo agregar una imagen de la web a una diapositiva:

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

## **Agregando Imágenes a Maestros de Diapositivas**

Un maestro de diapositivas es la diapositiva superior que almacena y controla información (tema, diseño, etc.) sobre todas las diapositivas debajo de ella. Por lo tanto, cuando agregas una imagen a un maestro de diapositivas, esa imagen aparece en cada diapositiva bajo ese maestro de diapositivas. 

Este código de muestra en Java te muestra cómo agregar una imagen a un maestro de diapositivas:

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

## **Agregando Imágenes como Fondo de Diapositivas**

Puedes decidir usar una imagen como fondo para una diapositiva específica o varias diapositivas. En ese caso, debes consultar *[Estableciendo Imágenes como Fondos para Diapositivas](https://docs.aspose.com/slides/php-java/presentation-background/#setting-images-as-background-for-slides)*.

## **Agregando SVG a Presentaciones**
Puedes agregar o insertar cualquier imagen en una presentación utilizando el método [addPictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) que pertenece a la interfaz [IShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection).

Para crear un objeto de imagen basado en una imagen SVG, puedes hacerlo de la siguiente manera:

1. Crea un objeto SvgImage para insertarlo en ImageShapeCollection
2. Crea un objeto PPImage desde ISvgImage
3. Crea un objeto PictureFrame usando la interfaz IPPImage

Este código de muestra te muestra cómo implementar los pasos anteriores para agregar una imagen SVG en una presentación:
```php
  # Instanciar la clase Presentación que representa el archivo PPTX
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

## **Convirtiendo SVG a un Conjunto de Formas**
La conversión de SVG a un conjunto de formas de Aspose.Slides es similar a la funcionalidad de PowerPoint utilizada para trabajar con imágenes SVG:

![Menú Emergente de PowerPoint](img_01_01.png)

La funcionalidad es proporcionada por uno de los sobrecargos del método [addGroupShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addGroupShape-com.aspose.slides.ISvgImage-float-float-float-float-) de la interfaz [IShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection) que toma un objeto [ISvgImage](https://reference.aspose.com/slides/php-java/aspose.slides/ISvgImage) como primer argumento.

Este código de muestra te muestra cómo utilizar el método descrito para convertir un archivo SVG a un conjunto de formas:

```php
  # Crear nueva presentación
  $presentation = new Presentation();
  try {
    # Leer contenido del archivo SVG
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
    # Obtener tamaño de la diapositiva
    $slideSize = $presentation->getSlideSize()->getSize();
    # Convertir imagen SVG a grupo de formas escalándola al tamaño de la diapositiva
    $presentation->getSlides()->get_Item(0)->getShapes()->addGroupShape($svgImage, 0.0, 0.0, $slideSize->getWidth(), $slideSize->getHeight());
    # Guardar presentación en formato PPTX
    $presentation->save("output.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Agregando Imágenes como EMF en Diapositivas**
Aspose.Slides para PHP a través de Java te permite generar imágenes EMF desde hojas de Excel y agregar las imágenes como EMF en diapositivas con Aspose.Cells.

Este código de muestra te muestra cómo realizar la tarea descrita:

```php
  $book = new Workbook("chart.xlsx");
  $sheet = $book->getWorksheets()->get(0);
  $options = new ImageOrPrintOptions();
  $options->setHorizontalResolution(200);
  $options->setVerticalResolution(200);
  $options->setImageType(ImageType::EMF);
  # Guardar el libro de trabajo en un flujo
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

{{% alert title="Información" color="info" %}}

Usando el convertidor gratuito de Aspose [Texto a GIF](https://products.aspose.app/slides/text-to-gif), puedes animar fácilmente textos, crear GIFs a partir de textos, etc. 

{{% /alert %}}
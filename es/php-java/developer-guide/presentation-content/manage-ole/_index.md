---
title: Administrar OLE
type: docs
weight: 40
url: /php-java/manage-ole/
keywords:
- agregar OLE
- incrustar OLE
- agregar un objeto
- incrustar un objeto
- incrustar un archivo
- objeto vinculado
- Vinculación y Embebido de Objetos
- objeto OLE
- PowerPoint 
- presentación
- PHP
- Java
- Aspose.Slides para PHP a través de Java
description: Agregar objetos OLE a presentaciones de PowerPoint en PHP
---

{{% alert color="primary" %}} 

OLE  (Vinculación y Embebido de Objetos) es una tecnología de Microsoft que permite que los datos y objetos creados en una aplicación sean colocados en otra aplicación a través de la vinculación o la incrustación. 

{{% /alert %}} 

Considera un gráfico creado en MS Excel. El gráfico se coloca dentro de una diapositiva de PowerPoint. Ese gráfico de Excel se considera un objeto OLE. 

- Un objeto OLE puede aparecer como un ícono. En este caso, al hacer doble clic en el ícono, el gráfico se abre en su aplicación asociada (Excel), o se te solicita que selecciones una aplicación para abrir o editar el objeto. 
- Un objeto OLE puede mostrar contenidos reales, por ejemplo, los contenidos de un gráfico. En este caso, el gráfico se activa en PowerPoint, se carga la interfaz del gráfico y puedes modificar los datos del gráfico dentro de la aplicación PowerPoint.

[Aspose.Slides para PHP a través de Java](https://products.aspose.com/slides/php-java/) te permite insertar Objetos OLE en diapositivas como Marcos de Objetos OLE ([OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/OleObjectFrame)).

## **Agregar Marcos de Objetos OLE a las Diapositivas**
Suponiendo que ya creaste un gráfico en Microsoft Excel y deseas incrustar ese gráfico en una diapositiva como un Marco de Objeto OLE utilizando Aspose.Slides para PHP a través de Java, puedes hacerlo de esta manera:

1. Crea una instancia de la [Presentación](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) clase.
1. Obtén la referencia de la diapositiva utilizando su índice.
1. Abre el archivo de Excel que contiene el objeto gráfico de Excel y guárdalo en `MemoryStream`.
1. Agrega el [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/OleObjectFrame) a la diapositiva que contiene el array de bytes y otra información sobre el objeto OLE.
1. Escribe la presentación modificada como un archivo PPTX.

En el ejemplo a continuación, agregamos un gráfico de un archivo de Excel a una diapositiva como un Marco de Objeto OLE utilizando Aspose.Slides para PHP a través de Java.
**Nota** que el constructor [IOleEmbeddedDataInfo](https://reference.aspose.com/slides/php-java/aspose.slides/IOleEmbeddedDataInfo) toma una extensión de objeto embebido como segundo parámetro. Esta extensión permite que PowerPoint interprete correctamente el tipo de archivo y elija la aplicación adecuada para abrir este objeto OLE.

```php
  # Instancia la clase Prseetation que representa el archivo PPTX
  $pres = new Presentation();
  try {
    # Accede a la primera diapositiva
    $sld = $pres->getSlides()->get_Item(0);
    # Carga un archivo de Excel al flujo
    $fs = new Java("java.io.FileInputStream", "book1.xlsx");
    $Array = new java_class("java.lang.reflect.Array");
    $Byte = new JavaClass("java.lang.Byte");
    $mstream = new Java("java.io.ByteArrayOutputStream");
    $buf = $Array->newInstance($Byte, 4096);
    while (true) {
      $bytesRead = $fs->read($buf, 0, $Array->getLength($buf));
      if ($bytesRead <= 0) {
        break;
      }
      $mstream->write($buf, 0, $bytesRead);
    } 
    $fs->close();
    # Crea un objeto de datos para incrustar
    $dataInfo = new OleEmbeddedDataInfo($mstream->toByteArray(), "xlsx");
    $mstream->close();
    # Agrega una forma de Marco de Objeto Ole
    $oleObjectFrame = $sld->getShapes()->addOleObjectFrame(0, 0, $pres->getSlideSize()->getSize()->getWidth(), $pres->getSlideSize()->getSize()->getHeight(), $dataInfo);
    # Escribe el archivo PPTX en disco
    $pres->save("OleEmbed_out.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Acceder a Marcos de Objetos OLE**
Si un objeto OLE ya está incrustado en una diapositiva, puedes encontrar o acceder fácilmente a ese objeto de esta manera:

1. Crea una instancia de la [Presentación](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) clase.
1. Obtén la referencia de la diapositiva utilizando su índice.
1. Accede a la forma del Marco de Objeto OLE.

   En nuestro ejemplo, usamos el PPTX creado anteriormente, que tiene solo una forma en la primera diapositiva. Luego *convertimos* ese objeto como un [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/OleObjectFrame). Este fue el Marco de Objeto OLE deseado para ser accedido.
1. Una vez que se accede al Marco de Objeto OLE, puedes realizar cualquier operación sobre él.

En el ejemplo a continuación, se accede a un Marco de Objeto OLE (un objeto gráfico de Excel incrustado en una diapositiva) y luego se escriben sus datos de archivo en un archivo de Excel.

```php
  # Carga el PPTX en un objeto Presentación
  $pres = new Presentation("AccessingOLEObjectFrame.pptx");
  try {
    # Accede a la primera diapositiva
    $sld = $pres->getSlides()->get_Item(0);
    # Convierte la forma a OleObjectFrame
    $oleObjectFrame = $sld->getShapes()->get_Item(0);
    # Lee el OLE Object y lo escribe en disco
    if (!java_is_null($oleObjectFrame)) {
      # Obtiene los datos del archivo embebido
      $data = $oleObjectFrame->getEmbeddedData()->getEmbeddedFileData();
      # Obtiene la extensión del archivo embebido
      $fileExtention = $oleObjectFrame->getEmbeddedData()->getEmbeddedFileExtension();
      # Crea una ruta para guardar el archivo extraído
      $extractedPath = "excelFromOLE_out" . $fileExtention;
      # Guarda los datos extraídos
      $fstr = new Java("java.io.FileOutputStream", $extractedPath);
      $Array = new java_class("java.lang.reflect.Array");
      try {
        $fstr->write($data, 0, $Array->getLength($data));
      } finally {
        $fstr->close();
      }
    }
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Cambiar los Datos del Objeto OLE**

Si un objeto OLE ya está incrustado en una diapositiva, puedes acceder fácilmente a ese objeto y modificar sus datos de esta manera:

1. Abre la presentación deseada con el objeto OLE incrustado creando una instancia de la [Presentación](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) clase.
1. Obtén la referencia de la diapositiva a través de su índice. 
1. Accede a la forma del Marco de Objeto OLE.

   En nuestro ejemplo, usamos el PPTX creado anteriormente que tiene solo una forma en la primera diapositiva. Luego *convertimos* ese objeto como un [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/OleObjectFrame). Este fue el Marco de Objeto OLE deseado para ser accedido.
1. Una vez que se accede al Marco de Objeto OLE, puedes realizar cualquier operación sobre él.
1. Crea el objeto Workbook y accede a los Datos OLE.
1. Accede a la Hoja de Cálculo deseada y modifica los datos.
1. Guarda el Workbook actualizado en flujos.
1. Cambia los datos del objeto OLE a partir de datos de flujo.

En el ejemplo a continuación, se accede a un Marco de Objeto OLE (un objeto gráfico de Excel incrustado en una diapositiva) y luego sus datos de archivo se modifican para cambiar los datos del gráfico:

```php
  $pres = new Presentation("ChangeOLEObjectData.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $ole = null;
    # Recorre todas las formas en busca del marco Ole
    foreach($slide->getShapes() as $shape) {
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.OleObjectFrame"))) {
        $ole = $shape;
      }
    }
    if (!java_is_null($ole)) {
      $msln = new ByteArrayInputStream($ole->getEmbeddedData()->getEmbeddedFileData());
      try {
        # Lee los datos del objeto en el Workbook
        $Wb = new Workbook($msln);
        $msout = new Java("java.io.ByteArrayOutputStream");
        try {
          # Modifica los datos del workbook
          $Wb->getWorksheets()->get(0)->getCells()->get(0, 4)->putValue("E");
          $Wb->getWorksheets()->get(0)->getCells()->get(1, 4)->putValue(12);
          $Wb->getWorksheets()->get(0)->getCells()->get(2, 4)->putValue(14);
          $Wb->getWorksheets()->get(0)->getCells()->get(3, 4)->putValue(15);
          $so1 = new OoxmlSaveOptions(SaveFormat::XLSX);
          $Wb->save($msout, $so1);
          # Cambia los datos del objeto Ole frame
          $newData = new OleEmbeddedDataInfo($msout->toByteArray(), $ole->getEmbeddedData()->getEmbeddedFileExtension());
          $ole->setEmbeddedData($newData);
        } finally {
          if (!java_is_null($msout)) {
            $msout->close();
          }
        }
      } finally {
        if (!java_is_null($msln)) {
          $msln->close();
        }
      }
    }
    $pres->save("OleEdit_out.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## Incrustar Otros Tipos de Archivos en Diapositivas

Además de gráficos de Excel, Aspose.Slides para PHP a través de Java te permite incrustar otros tipos de archivos en diapositivas. Por ejemplo, puedes insertar archivos HTML, PDF y ZIP como objetos en una diapositiva. Cuando un usuario hace doble clic en el objeto insertado, el objeto se lanza automáticamente en el programa relevante, o el usuario es dirigido a seleccionar un programa apropiado para abrir el objeto.

Este código PHP te muestra cómo incrustar HTML y ZIP en una diapositiva:

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $Array = new JavaClass("java.lang.reflect.Array");
    $Byte = (new JavaClass("java.lang.Byte"))->TYPE;
    try {
        $dis = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", "embedOle.html"));
        $bytes = $Array->newInstance($Byte, $dis->available());
        $dis->readFully($bytes);
    } finally {
        if (!java_is_null($dis)) $dis->close();
    }
    $htmlBytes = $bytes;

    $dataInfoHtml = new OleEmbeddedDataInfo($htmlBytes, "html");
    $oleFrameHtml = $slide->getShapes()->addOleObjectFrame(150, 120, 50, 50, $dataInfoHtml);
    $oleFrameHtml->setObjectIcon(true);
    try {
        $dis = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", "embedOle.zip"));
        $bytes = $Array->newInstance($Byte, $dis->available());
        $dis->readFully($bytes);
    } finally {
        if (!java_is_null($dis)) $dis->close();
    }
    $zipBytes = $bytes;

    $dataInfoZip = new OleEmbeddedDataInfo($zipBytes, "zip");
    $oleFrameZip = $slide->getShapes()->addOleObjectFrame(150, 220, 50, 50, $dataInfoZip);
    $oleFrameZip->setObjectIcon(true);
    $pres->save("embeddedOle.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## Establecer Tipos de Archivo para Objetos Incrustados

Al trabajar en presentaciones, es posible que necesites reemplazar objetos OLE antiguos por nuevos. O quizás necesites reemplazar un objeto OLE no admitido por uno admitido. 

Aspose.Slides para PHP a través de Java te permite establecer el tipo de archivo para un objeto incrustado. De esta manera, puedes cambiar los datos del marco OLE o su extensión.

Este Java te muestra cómo establecer el tipo de archivo para un objeto OLE incrustado:

```php
  $pres = new Presentation("embeddedOle.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $oleObjectFrame = $slide->getShapes()->get_Item(0);
    echo("La extensión de los datos embebidos actuales es: " . $oleObjectFrame->getEmbeddedData()->getEmbeddedFileExtension());
    $Array = new JavaClass("java.lang.reflect.Array");
    $Byte = (new JavaClass("java.lang.Byte"))->TYPE;
    try {
        $dis = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", "embedOle.zip"));
        $bytes = $Array->newInstance($Byte, $dis->available());
        $dis->readFully($bytes);
    } finally {
        if (!java_is_null($dis)) $dis->close();
    }
    $oleObjectFrame->setEmbeddedData(new OleEmbeddedDataInfo($bytes, "zip"));

    $pres->save("embeddedChanged.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## Establecer Imágenes de Icono y Títulos para Objetos Incrustados

Después de incrustar un objeto OLE, se añade automáticamente una vista previa que consiste en una imagen de ícono y un título. La vista previa es lo que los usuarios ven antes de acceder o abrir el objeto OLE. 

Si deseas usar una imagen y un texto específicos como elementos en la vista previa, puedes establecer la imagen del ícono y el título utilizando Aspose.Slides para PHP a través de Java.

Este código PHP te muestra cómo establecer la imagen del ícono y el título para un objeto incrustado:

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $oleObjectFrame = $slide->getShapes()->get_Item(0);
    $oleImage;
    $image = Images->fromFile("image.png");
    try {
      $oleImage = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    $oleObjectFrame->setSubstitutePictureTitle("Mi título");
    $oleObjectFrame->getSubstitutePictureFormat()->getPicture()->setImage($oleImage);
    $oleObjectFrame->setObjectIcon(false);
    $pres->save("embeddedOle-newImage.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Prevenir que un Marco de Objeto OLE se Redimensione y Reposicione**

Después de agregar un objeto OLE vinculado a una diapositiva de presentación, al abrir la presentación en PowerPoint, es posible que veas un mensaje pidiéndote que actualices los enlaces. Hacer clic en el botón "Actualizar Enlaces" puede cambiar el tamaño y la posición del marco de objeto OLE porque PowerPoint actualiza los datos del objeto OLE vinculado y refresca la vista previa del objeto. Para evitar que PowerPoint te solicite actualizar los datos del objeto, establece el método `setUpdateAutomatic` de la clase [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/) a `false`:

```php
$oleObjectFrame->setUpdateAutomatic(false);
```

## Extrayendo Archivos Incrustados

Aspose.Slides para PHP a través de Java te permite extraer archivos incrustados en diapositivas como objetos OLE de esta manera:

1. Crea una instancia de la [Presentación](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) clase que contiene el objeto OLE que deseas extraer.
2. Recorre todas las formas en la presentación y accede a la forma [OLEObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe).
3. Accede a los datos del archivo incrustado desde el Marco de Objeto OLE y escribe en disco. 

Este código PHP te muestra cómo extraer un archivo incrustado en una diapositiva como un objeto OLE:

```php
  $pres = new Presentation("embeddedOle.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    for($index = 0; $index < java_values($slide->getShapes()->size()) ; $index++) {
      $shape = $slide->getShapes()->get_Item($index);
      $oleFrame = $shape;
      if (!java_is_null($oleFrame)) {
        $data = $oleFrame->getEmbeddedData()->getEmbeddedFileData();
        $extension = $oleFrame->getEmbeddedData()->getEmbeddedFileExtension();
        # Guarda los datos extraídos
        $fstr = new Java("java.io.FileOutputStream", "oleFrame" . $index . $extension);
        $Array = new java_class("java.lang.reflect.Array");
        try {
          $fstr->write($data, 0, $Array->getLength($data));
        } finally {
          $fstr->close();
        }
      }
    }
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
---
title: Administrar OLE
type: docs
weight: 40
url: /es/php-java/manage-ole/
---

{{% alert color="primary" %}} 

OLE (Vinculación y Embebido de Objetos) es una tecnología de Microsoft que permite que los datos y objetos creados en una aplicación se coloquen en otra aplicación a través de enlaces o embebidos.

{{% /alert %}} 

Considere un gráfico creado en MS Excel. El gráfico se coloca dentro de una diapositiva de PowerPoint. Ese gráfico de Excel se considera un objeto OLE.

- Un objeto OLE puede aparecer como un ícono. En este caso, cuando hace doble clic en el ícono, el gráfico se abre en su aplicación asociada (Excel), o se le pide que seleccione una aplicación para abrir o editar el objeto.
- Un objeto OLE puede mostrar contenido real, por ejemplo, el contenido de un gráfico. En este caso, el gráfico se activa en PowerPoint, la interfaz del gráfico se carga y puede modificar los datos del gráfico dentro de la aplicación PowerPoint.

[Aspose.Slides para PHP a través de Java](https://products.aspose.com/slides/php-java/) le permite insertar objetos OLE en diapositivas como marcos de objeto OLE ([OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/OleObjectFrame)).

## **Agregar Marcos de Objetos OLE a Diapositivas**
Suponiendo que ya creó un gráfico en Microsoft Excel y desea embebeder ese gráfico en una diapositiva como un marco de objeto OLE utilizando Aspose.Slides para PHP a través de Java, puede hacerlo de esta manera:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Obtenga la referencia de la diapositiva utilizando su índice.
1. Abra el archivo de Excel que contiene el objeto gráfico de Excel y guárdelo en `MemoryStream`.
1. Agregue el [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/OleObjectFrame) a la diapositiva que contiene el array de bytes y otra información sobre el objeto OLE.
1. Escriba la presentación modificada como un archivo PPTX.

En el ejemplo a continuación, agregamos un gráfico de un archivo de Excel a una diapositiva como un marco de objeto OLE utilizando Aspose.Slides para PHP a través de Java.
**Nota** que el constructor [IOleEmbeddedDataInfo](https://reference.aspose.com/slides/php-java/aspose.slides/IOleEmbeddedDataInfo) toma una extensión de objeto embebible como segundo parámetro. Esta extensión permite que PowerPoint interprete correctamente el tipo de archivo y elija la aplicación adecuada para abrir este objeto OLE.

```php
  # Instancia la clase Presentación que representa el archivo PPTX
  $pres = new Presentation();
  try {
    # Accede a la primera diapositiva
    $sld = $pres->getSlides()->get_Item(0);
    # Carga un archivo de excel en el flujo
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
    # Crea un objeto de datos para embebeder
    $dataInfo = new OleEmbeddedDataInfo($mstream->toByteArray(), "xlsx");
    $mstream->close();
    # Agrega una forma de marco de objeto Ole
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

## **Accediendo a Marcos de Objetos OLE**
Si un objeto OLE ya está embebido en una diapositiva, puede encontrar o acceder a ese objeto fácilmente de esta manera:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Obtenga la referencia de la diapositiva utilizando su índice.
1. Acceda a la forma del marco de objeto OLE.

   En nuestro ejemplo, utilizamos el PPTX creado anteriormente, que tiene solo una forma en la primera diapositiva. Luego *convirtimos* ese objeto a un [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/OleObjectFrame). Este fue el marco de objeto OLE deseado al que se accedió.
1. Una vez que se accede al marco de objeto OLE, puede realizar cualquier operación sobre él.

En el ejemplo a continuación, se accede a un marco de objeto OLE (un objeto de gráfico de Excel embebido en una diapositiva) y luego sus datos de archivo se escriben en un archivo de Excel.

```php
  # Carga el PPTX a un objeto Presentación
  $pres = new Presentation("AccessingOLEObjectFrame.pptx");
  try {
    # Accede a la primera diapositiva
    $sld = $pres->getSlides()->get_Item(0);
    # Convierte la forma a OleObjectFrame
    $oleObjectFrame = $sld->getShapes()->get_Item(0);
    # Lee el objeto OLE y lo escribe en disco
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

## **Cambiando Datos de Objetos OLE**

Si un objeto OLE ya está embebido en una diapositiva, puede acceder fácilmente a ese objeto y modificar sus datos de esta manera:

1. Abra la presentación deseada con el objeto OLE embebido creando una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Obtenga la referencia de la diapositiva a través de su índice. 
1. Acceda a la forma del marco de objeto OLE.

   En nuestro ejemplo, utilizamos el PPTX creado anteriormente que tiene solo una forma en la primera diapositiva. Luego *convertimos* ese objeto a un [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/OleObjectFrame). Este fue el marco de objeto OLE deseado al que se accedió.
1. Una vez que se accede al marco de objeto OLE, puede realizar cualquier operación sobre él.
1. Cree el objeto Workbook y acceda a los datos OLE.
1. Acceda a la hoja de cálculo deseada y modifique los datos.
1. Guarde el Workbook actualizado en flujos.
1. Cambie los datos del objeto OLE a partir de datos de flujo.

En el ejemplo a continuación, se accede a un marco de objeto OLE (un objeto de gráfico de Excel embebido en una diapositiva) y luego se modifican sus datos de archivo para cambiar los datos del gráfico:

```php
  $pres = new Presentation("ChangeOLEObjectData.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $ole = null;
    # Recorre todas las formas para el marco Ole
    foreach($slide->getShapes() as $shape) {
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.OleObjectFrame"))) {
        $ole = $shape;
      }
    }
    if (!java_is_null($ole)) {
      $msln = new ByteArrayInputStream($ole->getEmbeddedData()->getEmbeddedFileData());
      try {
        # Lee los datos del objeto en Workbook
        $Wb = new Workbook($msln);
        $msout = new Java("java.io.ByteArrayOutputStream");
        try {
          # Modifica los datos del libro de trabajo
          $Wb->getWorksheets()->get(0)->getCells()->get(0, 4)->putValue("E");
          $Wb->getWorksheets()->get(0)->getCells()->get(1, 4)->putValue(12);
          $Wb->getWorksheets()->get(0)->getCells()->get(2, 4)->putValue(14);
          $Wb->getWorksheets()->get(0)->getCells()->get(3, 4)->putValue(15);
          $so1 = new OoxmlSaveOptions(SaveFormat::XLSX);
          $Wb->save($msout, $so1);
          # Cambia los datos del objeto Ole en el marco
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

## Integrando Otros Tipos de Archivos en Diapositivas

Además de gráficos de Excel, Aspose.Slides para PHP a través de Java le permite integrar otros tipos de archivos en diapositivas. Por ejemplo, puede insertar archivos HTML, PDF y ZIP como objetos en una diapositiva. Cuando un usuario hace doble clic en el objeto insertado, este se lanza automáticamente en el programa relevante, o se dirige al usuario a seleccionar un programa apropiado para abrir el objeto.

Este código PHP le muestra cómo integrar HTML y ZIP en una diapositiva:

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

## Estableciendo Tipos de Archivos para Objetos Embebidos

Al trabajar en presentaciones, es posible que necesite reemplazar objetos OLE antiguos por nuevos. O puede que necesite reemplazar un objeto OLE no compatible por uno compatible.

Aspose.Slides para PHP a través de Java le permite establecer el tipo de archivo para un objeto embebido. De esta manera, puede cambiar los datos del marco OLE o su extensión.

Este Java le muestra cómo establecer el tipo de archivo para un objeto OLE embebido:

```php
  $pres = new Presentation("embeddedOle.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $oleObjectFrame = $slide->getShapes()->get_Item(0);
    echo("La extensión de datos embebidos actual es: " . $oleObjectFrame->getEmbeddedData()->getEmbeddedFileExtension());
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

## Estableciendo Imágenes de Ícono y Títulos para Objetos Embebidos

Después de embebeder un objeto OLE, una vista previa que consiste en una imagen de ícono y un título se agrega automáticamente. La vista previa es lo que los usuarios ven antes de acceder o abrir el objeto OLE.

Si desea utilizar una imagen y texto específicos como elementos en la vista previa, puede establecer la imagen de ícono y el título utilizando Aspose.Slides para PHP a través de Java.

Este código PHP le muestra cómo establecer la imagen de ícono y el título para un objeto embebido:

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

## Extrayendo Archivos Embebidos

Aspose.Slides para PHP a través de Java le permite extraer los archivos embebidos en diapositivas como objetos OLE de la siguiente manera:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) que contenga el objeto OLE que pretende extraer.
2. Recorra todas las formas en la presentación y acceda a la forma [OLEObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe).
3. Acceda a los datos del archivo embebido del marco de objeto OLE y escríbalo en disco.

Este código PHP le muestra cómo extraer un archivo embebido en una diapositiva como un objeto OLE:

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
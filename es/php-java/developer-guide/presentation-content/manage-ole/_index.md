---
title: Gestionar OLE en presentaciones usando PHP
linktitle: Gestionar OLE
type: docs
weight: 40
url: /es/php-java/manage-ole/
keywords:
- objeto OLE
- Vinculación e inserción de objetos
- agregar OLE
- incrustar OLE
- agregar objeto
- incrustar objeto
- agregar archivo
- incrustar archivo
- objeto vinculado
- archivo vinculado
- cambiar OLE
- icono OLE
- título OLE
- extraer OLE
- extraer objeto
- extraer archivo
- PowerPoint
- presentación
- PHP
- Aspose.Slides
description: "Optimice la gestión de objetos OLE en archivos PowerPoint y OpenDocument con Aspose.Slides para PHP via Java. Incruste, actualice y exporte contenido OLE sin problemas."
---
## **Introducción**

{{% alert color="info" title="Note" %}}
OLE (Object Linking & Embedding) es una tecnología de Microsoft que permite que datos y objetos creados en una aplicación sean colocados en otra aplicación mediante enlace o incrustación. 
{{% /alert %}} 

Considere un gráfico creado en MS Excel. El gráfico se coloca luego dentro de una diapositiva de PowerPoint. Ese gráfico de Excel se considera un objeto OLE. 

- Un objeto OLE puede aparecer como un icono. En este caso, al hacer doble clic en el icono, el gráfico se abre en su aplicación asociada (Excel), o se le solicita seleccionar una aplicación para abrir o editar el objeto.  
- Un objeto OLE puede mostrar su contenido real, como el contenido de un gráfico. En este caso, el gráfico se activa en PowerPoint, se carga la interfaz del gráfico y puede modificar los datos del gráfico dentro de PowerPoint.  

[Aspose.Slides for PHP via Java](https://products.aspose.com/slides/php-java/) permite insertar OLE Objects en diapositivas como marcos de objetos OLE ([OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/)).

## **Agregar marcos de objetos OLE a diapositivas**

Suponiendo que ya ha creado un gráfico en Microsoft Excel y desea incrustarlo en una diapositiva como un marco de objeto OLE mediante Aspose.Slides for PHP via Java, puede hacerlo de esta manera:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).  
1. Obtenga la referencia de una diapositiva mediante su índice.  
1. Lea el archivo de Excel como una matriz de bytes.  
1. Añada el [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/) a la diapositiva que contiene la matriz de bytes y otra información sobre el objeto OLE.  
1. Guarde la presentación modificada como un archivo PPTX.  

En el ejemplo siguiente, añadimos un gráfico de un archivo Excel a una diapositiva como un marco de objeto OLE usando Aspose.Slides for PHP via Java.  
**Nota** que el constructor [OleEmbeddedDataInfo](https://reference.aspose.com/slides/php-java/aspose.slides/oleembeddeddatainfo/) recibe una extensión de objeto incrustable como segundo parámetro. Esta extensión permite a PowerPoint interpretar correctamente el tipo de archivo y elegir la aplicación adecuada para abrir este objeto OLE.

```php
$presentation = new Presentation();
$slideSize = $presentation->getSlideSize()->getSize();
$slide = $presentation->getSlides()->get_Item(0);

// Prepare data for the OLE object.
$fileData = file_get_contents("book.xlsx");
$dataInfo = new OleEmbeddedDataInfo($fileData, "xlsx");

// Add the OLE object frame to the slide.
$slide->getShapes()->addOleObjectFrame(0, 0, $slideSize->getWidth(), $slideSize->getHeight(), $dataInfo);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

### **Agregar marcos de objetos OLE vinculados**

Aspose.Slides for PHP via Java permite agregar un [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/) sin incrustar datos, sino sólo con un enlace al archivo.

Este código PHP le muestra cómo añadir un [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/) con un archivo Excel vinculado a una diapositiva:

```php
$presentation = new Presentation();
$slide = $presentation->getSlides()->get_Item(0);

// Añadir un marco de objeto OLE con un archivo Excel vinculado.
$slide->getShapes()->addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **Acceder a marcos de objetos OLE**

Si un objeto OLE ya está incrustado en una diapositiva, puede encontrarlo o acceder a él fácilmente de esta manera:

1. Cargue una presentación con el objeto OLE incrustado creando una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).  
2. Obtenga la referencia de la diapositiva utilizando su índice.  
3. Acceda a la forma [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/). En nuestro ejemplo, usamos el PPTX creado previamente que tiene sólo una forma en la primera diapositiva.  
4. Una vez que se accede al marco del objeto OLE, puede realizar cualquier operación sobre él.  

En el ejemplo siguiente, se accede a un marco de objeto OLE (un objeto de gráfico de Excel incrustado en una diapositiva) y a sus datos de archivo.

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$shape = $slide->getShapes()->get_Item(0);

if (java_instanceof($shape, new JavaClass("com.aspose.slides.OleObjectFrame"))) {
    $oleFrame = $shape;
    
    // Obtener los datos del archivo incrustado.
    // Obtener la extensión del archivo incrustado.
    // ...
}
```

### **Acceder a las propiedades del marco de objeto OLE vinculado**

Aspose.Slides le permite acceder a las propiedades de los marcos de objetos OLE vinculados.

Este código PHP le muestra cómo comprobar si un objeto OLE está vinculado y luego obtener la ruta al archivo vinculado:

```php
$presentation = new Presentation("sample.ppt");
$slide = $presentation->getSlides()->get_Item(0);
$shape = $slide->getShapes()->get_Item(0);

if (java_instanceof($shape, new JavaClass("com.aspose.slides.OleObjectFrame"))) {
    $oleFrame = $shape;

    // Comprobar si el objeto OLE está vinculado.
    if (java_values($oleFrame->isObjectLink()) != 0) {
        // Imprimir la ruta completa del archivo vinculado.
        echo "OLE object frame is linked to: " . $oleFrame->getLinkPathLong() . PHP_EOL;

        // Imprimir la ruta relativa del archivo vinculado si está presente.
        // Sólo las presentaciones PPT pueden contener la ruta relativa.
        $relativePath = java_values($oleFrame->getLinkPathRelative());
        if (!is_null($relativePath) && $relativePath !== "") {
            echo "OLE object frame relative path: " . $oleFrame->getLinkPathRelative() . PHP_EOL;
        }
    }
}

$presentation->dispose();
```

## **Cambiar los datos del objeto OLE**

{{% alert color="info" title="Note" %}}
En esta sección, el ejemplo de código a continuación utiliza [Aspose.Cells for PHP via Java](https://docs.aspose.com/cells/php-java/).
{{% /alert %}}

Si un objeto OLE ya está incrustado en una diapositiva, puede acceder fácilmente a ese objeto y modificar sus datos de esta manera:

1. Cargue una presentación con el objeto OLE incrustado creando una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).  
2. Obtenga la referencia de la diapositiva mediante su índice.  
3. Acceda a la forma [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/). En nuestro ejemplo, usamos el PPTX creado previamente que tiene una forma en la primera diapositiva.  
4. Una vez que se accede al marco del objeto OLE, puede realizar cualquier operación sobre él.  
5. Cree un objeto `Workbook` y acceda a los datos OLE.  
6. Acceda al `Worksheet` deseado y modifique los datos.  
7. Guarde el `Workbook` actualizado en un flujo.  
8. Cambie los datos del objeto OLE a partir del flujo.  

En el ejemplo siguiente, se accede a un marco de objeto OLE (un objeto de gráfico de Excel incrustado en una diapositiva) y se modifican sus datos de archivo para actualizar los datos del gráfico.

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$shape = $slide->getShapes()->get_Item(0);

if (java_instanceof($shape, new JavaClass("com.aspose.slides.OleObjectFrame"))) {
    $oleFrame = $shape;

    $oleStream = new Java("java.io.ByteArrayInputStream", $oleFrame->getEmbeddedData()->getEmbeddedFileData());

    // Leer los datos del objeto OLE como un objeto Workbook.
    $workbook = new Workbook($oleStream);

    $newOleStream = new Java("java.io.ByteArrayOutputStream");

    // Modificar los datos del libro de trabajo.
    $workbook->getWorksheets()->get(0)->getCells()->get(0, 4)->putValue("E");
    $workbook->getWorksheets()->get(0)->getCells()->get(1, 4)->putValue(12);
    $workbook->getWorksheets()->get(0)->getCells()->get(2, 4)->putValue(14);
    $workbook->getWorksheets()->get(0)->getCells()->get(3, 4)->putValue(15);

    $fileOptions = new OoxmlSaveOptions(SaveFormat::XLSX);
    $workbook->save($newOleStream, $fileOptions);

    // Cambiar los datos del objeto del marco OLE.
    $newData = new OleEmbeddedDataInfo($newOleStream->toByteArray(), $oleFrame->getEmbeddedData()->getEmbeddedFileExtension());
    $oleFrame->setEmbeddedData($newData);

    $newOleStream->close();
    $oleStream->close();
}

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **Incrustar otros tipos de archivo en diapositivas**

Además de los gráficos de Excel, Aspose.Slides for PHP via Java le permite incrustar otros tipos de archivos en diapositivas. Por ejemplo, puede insertar archivos HTML, PDF y ZIP como objetos. Cuando un usuario hace doble clic en el objeto insertado, se abre automáticamente en el programa correspondiente, o se le solicita seleccionar un programa adecuado para abrirlo.

Este código PHP le muestra cómo incrustar HTML y ZIP en una diapositiva:

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);

$htmlData = file_get_contents("sample.html");
$htmlDataInfo = new OleEmbeddedDataInfo($htmlData, "html");
$htmlOleFrame = $slide->getShapes()->addOleObjectFrame(150, 120, 50, 50, $htmlDataInfo);
$htmlOleFrame->setObjectIcon(true);

$zipData = file_get_contents("sample.zip");
$zipDataInfo = new OleEmbeddedDataInfo($zipData, "zip");
$zipOleFrame = $slide->getShapes()->addOleObjectFrame(150, 220, 50, 50, $zipDataInfo);
$zipOleFrame->setObjectIcon(true);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **Establecer tipos de archivo para objetos incrustados**

Al trabajar con presentaciones, puede necesitar reemplazar objetos OLE antiguos por otros nuevos o sustituir un objeto OLE no compatible por uno compatible. Aspose.Slides for PHP via Java le permite establecer el tipo de archivo para un objeto incrustado, lo que permite actualizar los datos del marco OLE o su extensión.

Este código PHP le muestra cómo establecer el tipo de archivo para un objeto OLE incrustado a `zip`:

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$oleFrame = $slide->getShapes()->get_Item(0);

$fileExtension = $oleFrame->getEmbeddedData()->getEmbeddedFileExtension();
$fileData = $oleFrame->getEmbeddedData()->getEmbeddedFileData();

echo "Current embedded file extension is: " . $fileExtension . PHP_EOL;

// Change the file type to ZIP.
$oleFrame->setEmbeddedData(new OleEmbeddedDataInfo($fileData, "zip"));

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **Establecer imágenes de icono y títulos para objetos incrustados**

Después de incrustar un objeto OLE, se añade automáticamente una vista previa compuesta por una imagen de icono. Esta vista previa es lo que los usuarios ven antes de acceder o abrir el objeto OLE. Si desea usar una imagen y texto específicos como elementos en la vista previa, puede establecer la imagen del icono y el título mediante Aspose.Slides for PHP via Java.

Este código PHP le muestra cómo establecer la imagen del icono y el título para un objeto incrustado:

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$oleFrame = $slide->getShapes()->get_Item(0);

// Añadir una imagen a los recursos de la presentación.
$imageData = file_get_contents("image.png");
$oleImage = $presentation->getImages()->addImage($imageData);
$oleFrame->setSubstitutePictureTitle("My title");
$oleFrame->getSubstitutePictureFormat()->getPicture()->setImage($oleImage);
$oleFrame->setObjectIcon(true);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **Prevenir que un marco de objeto OLE sea redimensionado y reposicionado**

Después de añadir un objeto OLE vinculado a una diapositiva de presentación, al abrir la presentación en PowerPoint, puede aparecer un mensaje pidiéndole actualizar los enlaces. Al hacer clic en el botón "Update Links" (Actualizar enlaces) puede cambiar el tamaño y la posición del marco del objeto OLE porque PowerPoint actualiza los datos del objeto OLE vinculado y refresca la vista previa del objeto. Para evitar que PowerPoint solicite actualizar los datos del objeto, llame al método [setUpdateAutomatic](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/#setUpdateAutomatic) de la clase [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/) con `false`:

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$oleFrame = $slide->getShapes()->get_Item(0);

$oleFrame->setUpdateAutomatic(false);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **Extraer archivos incrustados**

Aspose.Slides for PHP via Java le permite extraer los archivos incrustados en diapositivas como objetos OLE de la siguiente manera:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) que contenga los objetos OLE que desea extraer.  
2. Recorra todas las formas de la presentación y acceda a las formas [OLEObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/).  
3. Acceda a los datos de los archivos incrustados de los marcos de objetos OLE y escríbalos en el disco.  

Este código PHP le muestra cómo extraer archivos incrustados en una diapositiva como objetos OLE:

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);

$shapeCount = java_values($slide->getShapes()->size());
for ($index = 0; $index < $shapeCount; $index++) {
    $shape = $slide->getShapes()->get_Item($index);

    if (java_instanceof($shape, new JavaClass("com.aspose.slides.OleObjectFrame"))) {
        $oleFrame = $shape;

        $fileData = $oleFrame->getEmbeddedData()->getEmbeddedFileData();
        $fileExtension = $oleFrame->getEmbeddedData()->getEmbeddedFileExtension();

        $filePath = "OLE_object_" . $index . $fileExtension;
        file_put_contents($filePath, $fileData);
    }
}

$presentation->dispose();
```

## **FAQ**

**¿Se renderizará el contenido OLE al exportar diapositivas a PDF/imágenes?**

Lo que es visible en la diapositiva es lo que se renderiza: el icono/imagen de sustitución (vista previa). El contenido OLE "en vivo" no se ejecuta durante la renderización. Si es necesario, establezca su propia imagen de vista previa para garantizar la apariencia esperada en el PDF exportado.  
Para preservar también el archivo incrustado como adjunto PDF, llame a [setIncludeOleData](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/#setIncludeOleData) con `true`. Esta opción está desactivada por defecto. Para un ejemplo e instrucciones sobre cómo comprobar el adjunto, consulte [Preservar archivos OLE incrustados como adjuntos PDF](/slides/es/php-java/convert-powerpoint-to-pdf/#preserve-embedded-ole-files-as-pdf-attachments).

**¿Cómo puedo bloquear un objeto OLE en una diapositiva para que los usuarios no puedan moverlo/editarlo en PowerPoint?**

Bloquee la forma: Aspose.Slides proporciona bloqueos a nivel de forma. No se trata de cifrado, pero evita eficazmente ediciones y movimientos accidentales.

**¿Se preservarán las rutas relativas para objetos OLE vinculados en el formato PPTX?**

En PPTX, la información de "ruta relativa" no está disponible, sólo la ruta completa. Las rutas relativas se encuentran en el formato PPT anterior. Para portabilidad, es preferible usar rutas absolutas fiables/URIs accesibles o la incrustación.
---
title: Gestionar OLE en presentaciones usando PHP
linktitle: Gestionar OLE
type: docs
weight: 40
url: /es/php-java/manage-ole/
keywords:
- Objeto OLE
- Vinculación e incrustación de objetos
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
description: "Optimice la gestión de objetos OLE en PowerPoint y archivos OpenDocument con Aspose.Slides para PHP vía Java. Incruste, actualice y exporte contenido OLE sin problemas."
---

{{% alert color="primary" %}} 

OLE (Object Linking & Embedding) es una tecnología de Microsoft que permite que datos y objetos creados en una aplicación se inserten en otra aplicación mediante enlaces o incrustaciones. 

{{% /alert %}} 

Considere un gráfico creado en MS Excel. El gráfico se coloca luego dentro de una diapositiva de PowerPoint. Ese gráfico de Excel se considera un objeto OLE. 

- Un objeto OLE puede aparecer como un icono. En este caso, al hacer doble clic en el icono, el gráfico se abre en su aplicación asociada (Excel), o se le solicita al usuario que seleccione una aplicación para abrir o editar el objeto. 
- Un objeto OLE puede mostrar su contenido real, como el contenido de un gráfico. En este caso, el gráfico se activa en PowerPoint, se carga la interfaz del gráfico y puede modificar los datos del gráfico dentro de PowerPoint.

[Aspose.Slides for PHP via Java](https://products.aspose.com/slides/php-java/) permite insertar objetos OLE en diapositivas como marcos de objetos OLE ([OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/)). 

## **Agregar marcos de objetos OLE a diapositivas**

Suponiendo que ya haya creado un gráfico en Microsoft Excel y quiera incrustarlo en una diapositiva como un marco de objeto OLE usando Aspose.Slides for PHP via Java, puede hacerlo de esta manera:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/). 
1. Obtener la referencia de una diapositiva mediante su índice. 
1. Leer el archivo Excel como una matriz de bytes. 
1. Agregar el [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/) a la diapositiva que contiene la matriz de bytes y otra información sobre el objeto OLE. 
1. Guardar la presentación modificada como un archivo PPTX. 

En el ejemplo siguiente, agregamos un gráfico de un archivo Excel a una diapositiva como un marco de objeto OLE usando Aspose.Slides for PHP via Java.  
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

Aspose.Slides for PHP via Java permite agregar un [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/) sin incrustar datos, solo con un vínculo al archivo. 

Este código PHP muestra cómo agregar un [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/) con un archivo Excel vinculado a una diapositiva: 
```php
$presentation = new Presentation();
$slide = $presentation->getSlides()->get_Item(0);

// Agregar un marco de objeto OLE con un archivo Excel vinculado.
$slide->getShapes()->addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```


## **Acceder a marcos de objetos OLE**

Si un objeto OLE ya está incrustado en una diapositiva, puede encontrarlo o acceder a él fácilmente de esta forma:

1. Cargar una presentación con el objeto OLE incrustado creando una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/). 
2. Obtener la referencia de la diapositiva mediante su índice. 
3. Acceder a la forma [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/). En nuestro ejemplo, usamos la PPTX creada previamente que tiene solo una forma en la primera diapositiva. 
4. Una vez accedido al marco del objeto OLE, puede realizar cualquier operación sobre él. 

En el ejemplo siguiente, se accede a un marco de objeto OLE (un objeto gráfico de Excel incrustado en una diapositiva) y a sus datos de archivo. 
```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$shape = $slide->getShapes()->get_Item(0);

if (java_instanceof($shape, new JavaClass("com.aspose.slides.OleObjectFrame"))) {
    $oleFrame = $shape;
    
    // Obtener los datos del archivo incrustado.
    $fileData = $oleFrame->getEmbeddedData()->getEmbeddedFileData();

    // Obtener la extensión del archivo incrustado.
    $fileExtension = $oleFrame->getEmbeddedData()->getEmbeddedFileExtension();

    // ...
}
```


### **Acceder a propiedades de marcos de objetos OLE vinculados**

Aspose.Slides permite acceder a las propiedades de los marcos de objetos OLE vinculados. 

Este código PHP muestra cómo comprobar si un objeto OLE está vinculado y luego obtener la ruta del archivo vinculado: 
```php
$presentation = new Presentation("sample.ppt");
$slide = $presentation->getSlides()->get_Item(0);
$shape = $slide->getShapes()->get_Item(0);

if (java_instanceof($shape, new JavaClass("com.aspose.slides.OleObjectFrame"))) {
    $oleFrame = $shape;

    // Verificar si el objeto OLE está vinculado.
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


## **Cambiar datos de objetos OLE**

{{% alert color="primary" %}} 

En esta sección, el ejemplo de código a continuación usa [Aspose.Cells for PHP via Java](/cells/php-java/). 

{{% /alert %}} 

Si un objeto OLE ya está incrustado en una diapositiva, puede acceder a ese objeto y modificar sus datos de esta manera:

1. Cargar una presentación con el objeto OLE incrustado creando una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/). 
2. Obtener la referencia de la diapositiva mediante su índice. 
3. Acceder a la forma [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/). En nuestro ejemplo, usamos la PPTX creada previamente que tiene una forma en la primera diapositiva. 
4. Una vez accedido al marco del objeto OLE, puede realizar cualquier operación sobre él. 
5. Crear un objeto `Workbook` y acceder a los datos OLE. 
6. Acceder a la `Worksheet` deseada y modificar los datos. 
7. Guardar el `Workbook` actualizado en un flujo. 
8. Cambiar los datos del objeto OLE desde el flujo. 

En el ejemplo siguiente, se accede a un marco de objeto OLE (un objeto gráfico de Excel incrustado en una diapositiva) y se modifican sus datos de archivo para actualizar los datos del gráfico. 
```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$shape = $slide->getShapes()->get_Item(0);

if (java_instanceof($shape, new JavaClass("com.aspose.slides.OleObjectFrame"))) {
    $oleFrame = $shape;

    $oleStream = new ByteArrayInputStream($oleFrame->getEmbeddedData()->getEmbeddedFileData());

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

Además de los gráficos de Excel, Aspose.Slides for PHP via Java permite incrustar otros tipos de archivos en diapositivas. Por ejemplo, puede insertar archivos HTML, PDF y ZIP como objetos. Cuando el usuario hace doble clic en el objeto insertado, se abre automáticamente en el programa correspondiente, o se le solicita al usuario que seleccione un programa adecuado para abrirlo. 

Este código PHP muestra cómo incrustar HTML y ZIP en una diapositiva: 
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

Al trabajar con presentaciones, puede necesitar reemplazar objetos OLE antiguos por nuevos o sustituir un objeto OLE no compatible por uno compatible. Aspose.Slides for PHP via Java permite establecer el tipo de archivo para un objeto incrustado, lo que le permite actualizar los datos del marco OLE o su extensión. 

Este código PHP muestra cómo establecer el tipo de archivo para un objeto OLE incrustado a `zip`: 
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


## **Establecer imágenes de ícono y títulos para objetos incrustados**

Después de incrustar un objeto OLE, se agrega automáticamente una vista previa que consiste en una imagen de ícono. Esta vista previa es lo que los usuarios ven antes de acceder o abrir el objeto OLE. Si desea usar una imagen y un texto específicos como elementos de la vista previa, puede establecer la imagen del ícono y el título mediante Aspose.Slides for PHP via Java. 

Este código PHP muestra cómo establecer la imagen del ícono y el título para un objeto incrustado: 
```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$oleFrame = $slide->getShapes()->get_Item(0);

// Agregar una imagen a los recursos de la presentación.
$imageData = file_get_contents("image.png");
$oleImage = $presentation->getImages()->addImage($imageData);

// Establecer un título y la imagen para la vista previa OLE.
$oleFrame->setSubstitutePictureTitle("My title");
$oleFrame->getSubstitutePictureFormat()->getPicture()->setImage($oleImage);
$oleFrame->setObjectIcon(true);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```


## **Impedir que un marco de objeto OLE sea redimensionado y reposicionado**

Después de agregar un objeto OLE vinculado a una diapositiva de presentación, al abrir la presentación en PowerPoint puede aparecer un mensaje que le pide actualizar los vínculos. Al hacer clic en el botón “Update Links” (Actualizar vínculos) el tamaño y la posición del marco del objeto OLE pueden cambiar porque PowerPoint actualiza los datos del objeto OLE vinculado y refresca la vista previa del objeto. Para evitar que PowerPoint solicite la actualización de los datos del objeto, establezca el método `setUpdateAutomatic` de la clase [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/) en `false`: 
```php
$oleFrame->setUpdateAutomatic(false);
```


## **Extraer archivos incrustados**

Aspose.Slides for PHP via Java permite extraer los archivos incrustados en diapositivas como objetos OLE de la siguiente manera:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) que contenga los objetos OLE que desea extraer. 
2. Recorrer todas las formas de la presentación y acceder a las formas [OLEObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/). 
3. Acceder a los datos de los archivos incrustados desde los marcos de objetos OLE y escribirlos en disco. 

Este código PHP muestra cómo extraer archivos incrustados en una diapositiva como objetos OLE: 
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


## **Preguntas frecuentes**

**¿Se renderizará el contenido OLE al exportar diapositivas a PDF/imagenes?**  

Lo que es visible en la diapositiva se renderiza: el ícono/imagen de sustituto (vista previa). El contenido OLE “en vivo” no se ejecuta durante el renderizado. Si es necesario, establezca su propia imagen de vista previa para asegurar la apariencia esperada en el PDF exportado.  

**¿Cómo puedo bloquear un objeto OLE en una diapositiva para que los usuarios no lo muevan/editen en PowerPoint?**  

Bloquee la forma: Aspose.Slides proporciona [bloqueos a nivel de forma](/slides/es/php-java/applying-protection-to-presentation/). No es un cifrado, pero impide eficazmente ediciones y movimientos accidentales.  

**¿Por qué un objeto Excel vinculado “salta” o cambia de tamaño al abrir la presentación?**  

PowerPoint puede refrescar la vista previa del OLE vinculado. Para una apariencia estable, siga las prácticas de la [Solución de trabajo para el redimensionamiento de hojas de cálculo](/slides/es/php-java/working-solution-for-worksheet-resizing/): ajuste el marco al rango o escale el rango a un marco fijo y establezca una imagen de sustitución adecuada.  

**¿Se conservarán las rutas relativas de los objetos OLE vinculados en el formato PPTX?**  

En PPTX la información de “ruta relativa” no está disponible; solo se guarda la ruta completa. Las rutas relativas existen en el formato PPT anterior. Para portabilidad, prefiera rutas absolutas confiables/URIs accesibles o incrustar los archivos.
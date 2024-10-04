---
title: Guardar Presentación
type: docs
weight: 80
url: /es/php-java/guardar-presentacion/
---

## **Descripción general**
{{% alert color="primary" %}} 

[Abriendo Presentación](/slides/es/php-java/open-presentation/) describió cómo usar la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) para abrir una presentación. Este artículo explica cómo crear y guardar presentaciones.

{{% /alert %}} 

La clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) contiene el contenido de una presentación. Ya sea que estés creando una presentación desde cero o modificando una existente, al terminar, querrás guardar la presentación. Con Aspose.Slides para PHP a través de Java, se puede guardar como un **archivo** o **flujo**. Este artículo explica cómo guardar una presentación de diferentes maneras:

## **Guardar Presentación en Archivo**
Guarda una presentación en un archivo llamando al método [**Save**](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#save-java.lang.String-int-) de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation). Simplemente pasa el nombre del archivo y [**SaveFormat**](https://reference.aspose.com/slides/php-java/aspose.slides/SaveFormat) al método [**Save**](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#save-java.lang.String-int-).

Los ejemplos que siguen muestran cómo guardar una presentación con Aspose.Slides para PHP a través de Java.

```php
  # Instanciar un objeto Presentation que representa un archivo PPT
  $pres = new Presentation();
  try {
    # ...haz algún trabajo aquí...
    # Guarda tu presentación en un archivo
    $pres->save("demoPass.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Guardar Presentación en Flujo**
Es posible guardar una presentación en un flujo pasando un flujo de salida al método [**Save**](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#save-java.io.OutputStream-int-) de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation). Existen muchos tipos de flujos en los que se puede guardar una presentación. En el ejemplo siguiente hemos creado un nuevo archivo de Presentación, agregamos texto en una forma y guardamos la presentación en el flujo.

```php
  # Instanciar un objeto Presentation que representa un archivo PPT
  $pres = new Presentation();
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 200, 200);
    # Agregar texto a la forma
    $shape->getTextFrame()->setText("Esta demostración muestra cómo crear un archivo PowerPoint y guardarlo en Flujo.");
    $os = new Java("java.io.FileOutputStream", "Save_As_Stream_out.pptx");
    $pres->save($os, SaveFormat::Pptx);
    $os->close();
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Guardar Presentación con Tipo de Vista Predefinido**
Aspose.Slides para PHP a través de Java proporciona una facilidad para establecer el tipo de vista para la presentación generada cuando se abre en PowerPoint a través de la clase [ViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/ViewProperties). La propiedad [**setLastView**](https://reference.aspose.com/slides/php-java/aspose.slides/ViewProperties#setLastView-int-) se utiliza para establecer el tipo de vista utilizando el enumerador [**ViewType**](https://reference.aspose.com/slides/php-java/aspose.slides/ViewType).

```php
  # Abriendo el archivo de presentación
  $pres = new Presentation();
  try {
    # Estableciendo el tipo de vista
    $pres->getViewProperties()->setLastView(ViewType::SlideMasterView);
    # Guardando presentación
    $pres->save("newDemo.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Guardar Presentaciones en Formato XML Abierto de Office Estricto**
Aspose.Slides permite guardar la presentación en formato XML Abierto de Office Estricto. Para ese propósito, proporciona la clase [**PptxOptions**](https://reference.aspose.com/slides/php-java/aspose.slides/pptxoptions) donde puedes establecer la propiedad de Conformidad al guardar el archivo de presentación. Si estableces su valor como [**Conformance.Iso29500_2008_Strict**](https://reference.aspose.com/slides/php-java/aspose.slides/Conformance#Iso29500_2008_Strict), entonces el archivo de presentación de salida se guardará en formato Open XML Estricto.

El siguiente código de ejemplo crea una presentación y la guarda en formato XML Abierto de Office Estricto. Al llamar al método [**Save**](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) para la presentación, se pasa el objeto [**PptxOptions**](https://reference.aspose.com/slides/php-java/aspose.slides/pptxoptions) con la propiedad de Conformidad establecida como [**Conformance.Iso29500_2008_Strict**](https://reference.aspose.com/slides/php-java/aspose.slides/Conformance#Iso29500_2008_Strict).

```php
  # Instanciar un objeto Presentation que representa un archivo PPT
  $pres = new Presentation();
  try {
    # Obtener la primera diapositiva
    $slide = $pres->getSlides()->get_Item(0);
    # Agregar una forma automática de tipo línea
    $slide->getShapes()->addAutoShape(ShapeType::Line, 50, 150, 300, 0);
    # Establecer opciones de guardado en formato XML Abierto de Office Estricto
    $options = new PptxOptions();
    $options->setConformance(Conformance->Iso29500_2008_Strict);
    # Guarda tu presentación en un archivo
    $pres->save("demoPass.pptx", SaveFormat::Pptx, $options);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Guardar Presentaciones en formato XML Abierto de Office en modo Zip64**
Un archivo de XML Abierto de Office es un archivo ZIP que tiene un límite de 4 GB (2^32 bytes) en el tamaño no comprimido de un archivo, el tamaño comprimido de un archivo y el tamaño total del archivo, así como un límite de 65,535 (2^16-1) archivos en el archivo. Las extensiones del formato ZIP64 aumentan los límites a 2^64.

La nueva propiedad [**IPptxOptions.Zip64Mode**](https://reference.aspose.com/slides/php-java/aspose.slides/zip64mode/) te permite elegir cuándo usar extensiones de formato ZIP64 para el archivo XML Abierto de Office guardado.

Esta propiedad proporciona los siguientes modos:

- [Zip64Mode.IfNecessary](https://reference.aspose.com/slides/php-java/aspose.slides/zip64mode/#IfNecessary) significa que las extensiones de formato ZIP64 solo se usarán si la presentación supera las limitaciones anteriores. Este es el modo predeterminado.
- [Zip64Mode.Never](https://reference.aspose.com/slides/php-java/aspose.slides/zip64mode/#Never) significa que no se usarán extensiones de formato ZIP64.
- [Zip64Mode.Always](https://reference.aspose.com/slides/php-java/aspose.slides/zip64mode/#Always) significa que siempre se usarán extensiones de formato ZIP64.

El siguiente código demuestra cómo guardar la presentación en formato PPTX con extensiones de formato ZIP64:

```php
  $pres = new Presentation("Sample.pptx");
  try {
    $pptxOptions = new PptxOptions();
    $pptxOptions->setZip64Mode(Zip64Mode::Always);
    
    $pres->save("Sample-zip64.pptx", SaveFormat::Pptx, $pptxOptions);
  } finally {
    $pres->dispose();
  }
```

{{% alert title="NOTA" color="warning" %}}

Guardar en el modo Zip64Mode.Never lanzará una [PptxException](https://reference.aspose.com/slides/php-java/aspose.slides/pptxexception/) si la presentación no puede guardarse en formato ZIP32.

{{% /alert %}}

## **Guardar Actualizaciones de Progreso en Porcentaje**
Se ha añadido una nueva interfaz [**IProgressCallback**](https://reference.aspose.com/slides/php-java/aspose.slides/IProgressCallback) a la interfaz [**ISaveOptions**](https://reference.aspose.com/slides/php-java/aspose.slides/ISaveOptions) y a la clase abstracta [**SaveOptions**](https://reference.aspose.com/slides/php-java/aspose.slides/SaveOptions). La interfaz [**IProgressCallback**](https://reference.aspose.com/slides/php-java/aspose.slides/IProgressCallback) representa un objeto de callback para guardar actualizaciones de progreso en porcentaje.  

Los siguientes fragmentos de código muestran cómo usar la interfaz [IProgressCallback](https://reference.aspose.com/slides/php-java/aspose.slides/IProgressCallback):

```php
  class ExportProgressHandler {
    function reporting($progressValue) {
      # Usa el valor de porcentaje de progreso aquí
      $progress = java("java.lang.Double")->valueOf($progressValue)->intValue();
      echo($progress . "% archivo convertido");
    }
  }

  # Abriendo el archivo de presentación
  $pres = new Presentation("ConvertToPDF.pptx");
  try {
    $saveOptions = new PdfOptions();
    $progressHandler = java_closure(new ExportProgressHandler(), null, java("com.aspose.slides.IProgressCallback"));
    $saveOptions->setProgressCallback($progressHandler);
    $pres->save("ConvertToPDF.pdf", SaveFormat::Pdf, $saveOptions);
  } finally {
    $pres->dispose();
  }
```

{{% alert title="Información" color="info" %}}

Usando su propia API, Aspose desarrolló una [aplicación gratuita de PowerPoint Splitter](https://products.aspose.app/slides/splitter) que permite a los usuarios dividir sus presentaciones en múltiples archivos. Esencialmente, la aplicación guarda diapositivas seleccionadas de una presentación dada como nuevos archivos de PowerPoint (PPTX o PPT). 

{{% /alert %}}
---
title: Gestionar libros de trabajo de gráficos en presentaciones usando PHP
linktitle: Libro de trabajo de gráfico
type: docs
weight: 70
url: /es/php-java/chart-workbook/
keywords:
- libro de trabajo de gráfico
- datos del gráfico
- celda de libro de trabajo
- etiqueta de datos
- hoja de cálculo
- origen de datos
- libro de trabajo externo
- datos externos
- caché de gráfico
- recuperación de libro de trabajo
- PowerPoint
- presentación
- PHP
- Aspose.Slides
description: "Descubra Aspose.Slides para PHP mediante Java: gestione sin esfuerzo los libros de trabajo de gráficos en formatos PowerPoint y OpenDocument para optimizar los datos de su presentación."
---
## **Visión general**

Este artículo explica cómo trabajar con libros de trabajo de gráficos en Aspose.Slides. Muestra cómo leer y escribir datos de gráficos mediante flujos de libros de trabajo, usar celdas del libro de trabajo como etiquetas de datos de gráfico, acceder a colecciones de hojas de cálculo y especificar el tipo de origen de datos para los valores del gráfico.

También cubre el trabajo con libros de trabajo externos como fuentes de datos de gráficos. Los ejemplos demuestran cómo crear y asignar un libro de trabajo externo, obtener la ruta de un libro de trabajo externo vinculado a un gráfico y editar los datos del gráfico cuando el libro de trabajo está disponible.

## **Leer y escribir datos de gráfico desde un libro de trabajo**
Aspose.Slides proporciona los métodos [readWorkbookStream](https://reference.aspose.com/slides/es/php-java/aspose.slides/chartdata/#readWorkbookStream) y [writeWorkbookStream](https://reference.aspose.com/slides/es/php-java/aspose.slides/chartdata/#writeWorkbookStream) que le permiten leer y escribir libros de trabajo de datos de gráficos (que contienen datos de gráficos editados con Aspose.Cells). **Note** que los datos del gráfico deben estar organizados de la misma manera o deben tener una estructura similar a la fuente.

Este código PHP demuestra una operación de ejemplo:

```php
  $pres = new Presentation("chart.pptx");
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $data = $chart->getChartData();
    $stream = $data->readWorkbookStream();
    $data->getSeries()->clear();
    $data->getCategories()->clear();
    $data->writeWorkbookStream($stream);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Establecer una celda de WorkBook como etiqueta de datos de gráfico**

1. Crear una instancia de la clase [Presentation](https://apireference.aspose.com/slides/es/php-java/aspose.slides/presentation).
2. Obtener la referencia de una diapositiva mediante su índice.
3. Añadir un gráfico de burbujas con algunos datos.
4. Acceder a la serie del gráfico.
5. Establecer la celda del libro de trabajo como una etiqueta de datos.
6. Guardar la presentación.

Este código PHP le muestra cómo establecer una celda de libro de trabajo como etiqueta de datos de gráfico:

```php
  $lbl0 = "Label 0 cell value";
  $lbl1 = "Label 1 cell value";
  $lbl2 = "Label 2 cell value";
  # Instancia una clase de presentación que representa un archivo de presentación
  $pres = new Presentation("chart2.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::Bubble, 50, 50, 600, 400, true);
    $series = $chart->getChartData()->getSeries();
    $dataLabelCollection = $series->get_Item(0)->getLabels();
    $dataLabelCollection->getDefaultDataLabelFormat()->setShowLabelValueFromCell(true);
    $wb = $chart->getChartData()->getChartDataWorkbook();
    $dataLabelCollection->get_Item(0)->setValueFromCell($wb->getCell(0, "A10", $lbl0));
    $dataLabelCollection->get_Item(1)->setValueFromCell($wb->getCell(0, "A11", $lbl1));
    $dataLabelCollection->get_Item(2)->setValueFromCell($wb->getCell(0, "A12", $lbl2));
    $pres->save("resultchart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Gestionar hojas de cálculo**

Este código PHP demuestra una operación donde se utiliza el método [ChartDataWorkbook::getWorksheets](https://reference.aspose.com/slides/es/php-java/aspose.slides/chartdataworkbook/#getWorksheets) para acceder a una colección de hojas de cálculo:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Pie, 50, 50, 400, 500);
    $wb = $chart->getChartData()->getChartDataWorkbook();
    for($i = 0; $i < java_values($wb->getWorksheets()->size()) ; $i++) {
      echo($wb->getWorksheets()->get_Item($i)->getName());
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Especificar el tipo de origen de datos**

Este código PHP le muestra cómo especificar un tipo para un origen de datos:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Column3D, 50, 50, 600, 400, true);
    $val = $chart->getChartData()->getSeries()->get_Item(0)->getName();
    $val->setDataSourceType(DataSourceType::StringLiterals);
    $val->setData("LiteralString");
    $val = $chart->getChartData()->getSeries()->get_Item(1)->getName();
    $val->setData($chart->getChartData()->getChartDataWorkbook()->getCell(0, "B1", "NewCell"));
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Detectar formatos de libros de trabajo incrustados no compatibles**

Aspose.Slides no admite el formato de libro de trabajo binario de Excel (.xlsb) que puede incrustarse en algunos gráficos. Puede usar el método `getEmbeddedWorkbookType` en [ChartData](https://reference.aspose.com/slides/es/php-java/aspose.slides/chartdata/) junto con la enumeración [WorkbookType](https://reference.aspose.com/slides/es/php-java/aspose.slides/workbooktype/) para detectar formatos no compatibles y omitir esos gráficos.

```php
$presentation = new Presentation("sample.pptx");
try {
  $slide = $presentation->getSlides()->get_Item(0);
  $shapes = $slide->getShapes();

  for ($shapeIndex = 0; $shapeIndex < java_values($shapes->size()); $shapeIndex++) {
    $shape = $shapes->get_Item($shapeIndex);

    if (!java_instanceof($shape, new JavaClass("com.aspose.slides.IChart"))) {
      continue;
    }

    $chart = $shape;
    $chartData = $chart->getChartData();

    if (java_values($chartData->getDataSourceType()) == ChartDataSourceType::InternalWorkbook &&
        java_values($chartData->getEmbeddedWorkbookType()) == WorkbookType::WorkbookBinaryMacro) {
      # El libro de trabajo incrustado está en formato .xlsb, que no es compatible.
      continue;
    }

    # Lea o modifique aquí los datos del libro de trabajo del gráfico.
  }
} finally {
  $presentation->dispose();
}
```

## **Libro de trabajo externo**

Aspose.Slides admite libros de trabajo externos como fuente de datos para gráficos.

### **Crear un libro de trabajo externo**

Usando los métodos **`readWorkbookStream`** y **`setExternalWorkbook`**, puede crear un libro de trabajo externo desde cero o convertir un libro de trabajo interno en externo.

Este código PHP demuestra el proceso de creación del libro de trabajo externo:

```php
  $pres = new Presentation();
  $Array = new java_class("java.lang.reflect.Array");
  try {
    $workbookPath = "externalWorkbook1.xlsx";
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Pie, 50, 50, 400, 600);
    $fileStream = new Java("java.io.FileOutputStream", $workbookPath);
    $Array = new java_class("java.lang.reflect.Array");
    try {
      $workbookData = $chart->getChartData()->readWorkbookStream();
      $fileStream->write($workbookData, 0, $Array->getLength($workbookData));
    } finally {
      if (!java_is_null($fileStream)) {
        $fileStream->close();
      }
    }
    $chart->getChartData()->setExternalWorkbook($workbookPath);
    $pres->save("externalWorkbook.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Establecer un libro de trabajo externo**

Usando el método **`setExternalWorkbook`**, puede asignar un libro de trabajo externo a un gráfico como su fuente de datos. Este método también puede usarse para actualizar la ruta al libro de trabajo externo (si este se ha trasladado).

Aunque no puede editar los datos en libros de trabajo almacenados en ubicaciones remotas o recursos, puede seguir utilizándolos como fuente de datos externa. Si se proporciona una ruta relativa para un libro de trabajo externo, se convierte automáticamente en una ruta completa.

Este código PHP le muestra cómo establecer un libro de trabajo externo:

```php
  # Crea una instancia de la clase Presentation
  $pres = new Presentation("chart.pptx");
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Pie, 50, 50, 400, 600, false);
    $chartData = $chart->getChartData();
    $chartData->setExternalWorkbook("externalWorkbook.xlsx");
    $chartData->getSeries()->add($chartData->getChartDataWorkbook()->getCell(0, "B1"), ChartType::Pie);
    $chartData->getSeries()->get_Item(0)->getDataPoints()->addDataPointForPieSeries($chartData->getChartDataWorkbook()->getCell(0, "B2"));
    $chartData->getSeries()->get_Item(0)->getDataPoints()->addDataPointForPieSeries($chartData->getChartDataWorkbook()->getCell(0, "B3"));
    $chartData->getSeries()->get_Item(0)->getDataPoints()->addDataPointForPieSeries($chartData->getChartDataWorkbook()->getCell(0, "B4"));
    $chartData->getCategories()->add($chartData->getChartDataWorkbook()->getCell(0, "A2"));
    $chartData->getCategories()->add($chartData->getChartDataWorkbook()->getCell(0, "A3"));
    $chartData->getCategories()->add($chartData->getChartDataWorkbook()->getCell(0, "A4"));
    $pres->save("Presentation_with_externalWorkbook.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

El parámetro `ChartData` (bajo el método `setExternalWorkbook`) se usa para especificar si se cargará o no un libro de trabajo Excel.

* Cuando el valor de `ChartData` se establece en `false`, solo se actualiza la ruta del libro de trabajo; los datos del gráfico no se cargarán ni actualizarán desde el libro de trabajo de destino. Puede usar esta configuración cuando el libro de trabajo de destino no exista o no esté disponible.  
* Cuando el valor de `ChartData` se establece en `true`, los datos del gráfico se actualizan desde el libro de trabajo de destino.

```php
  # Crea una instancia de la clase Presentation
  $pres = new Presentation("chart.pptx");
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Pie, 50, 50, 400, 600, true);
    $chartData = $chart->getChartData();
    $chartData->setExternalWorkbook("http://path/doesnt/exists", false);
    $pres->save("Presentation_with_externalWorkbookWithUpdateChartData.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Obtener la ruta del libro de trabajo de origen de datos externo de un gráfico**

1. Crear una instancia de la clase [Presentation](https://apireference.aspose.com/slides/es/php-java/aspose.slides/presentation).
2. Obtener la referencia de una diapositiva mediante su índice.
3. Crear un objeto para la forma de gráfico.
4. Crear un objeto para el tipo de origen (`ChartDataSourceType`) que representa la fuente de datos del gráfico.
5. Especificar la condición pertinente basándose en que el tipo de origen sea el mismo que el tipo de origen de datos del libro de trabajo externo.

Este código PHP demuestra la operación:

```php
  # Crea una instancia de la clase Presentation
  $pres = new Presentation("chart.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(1);
    $chart = $slide->getShapes()->get_Item(0);
    $sourceType = $chart->getChartData()->getDataSourceType();
    if ($sourceType == ChartDataSourceType::ExternalWorkbook) {
      $path = $chart->getChartData()->getExternalWorkbookPath();
    }
    # Guarda la presentación
    $pres->save("result.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Editar datos del gráfico**

Puede editar los datos en libros de trabajo externos de la misma manera que realiza cambios en el contenido de libros de trabajo internos. Cuando un libro de trabajo externo no puede cargarse, se lanza una excepción.

Este código PHP es una implementación del proceso descrito:

```php
  # Crea una instancia de la clase Presentation
  $pres = new Presentation("chart.pptx");
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $chartData = $chart->getChartData();
    $chartData->getSeries()->get_Item(0)->getDataPoints()->get_Item(0)->getValue()->getAsCell()->setValue(100);
    $pres->save("presentation_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Recuperar un libro de trabajo de la caché del gráfico**

Si un gráfico usa un libro de trabajo externo que falta o no está disponible, Aspose.Slides puede reconstruir el libro de trabajo del gráfico a partir de los datos almacenados en caché en la presentación. Cree [LoadOptions](https://reference.aspose.com/slides/es/php-java/aspose.slides/loadoptions/), configúrelo con [SpreadsheetOptions](https://reference.aspose.com/slides/es/php-java/aspose.slides/spreadsheetoptions/), y llame a [SpreadsheetOptions::setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/es/php-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache) con `true` antes de abrir la presentación.

El siguiente ejemplo PHP abre una presentación cuyo gráfico hace referencia a un libro de trabajo externo no disponible y accede a los datos recuperados a través de [Chart::getChartData](https://reference.aspose.com/slides/es/php-java/aspose.slides/chart/#getChartData) y [ChartData::getChartDataWorkbook](https://reference.aspose.com/slides/es/php-java/aspose.slides/chartdata/#getChartDataWorkbook):

```php
$spreadsheetOptions = new SpreadsheetOptions();
$spreadsheetOptions->setRecoverWorkbookFromChartCache(true);

$loadOptions = new LoadOptions();
$loadOptions->setSpreadsheetOptions($spreadsheetOptions);

$presentation = new Presentation("presentation.pptx", $loadOptions);
try {
    $chart = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $recoveredWorkbook = $chart->getChartData()->getChartDataWorkbook();

    # Lee o modifica aquí los datos del libro de trabajo recuperado.
} finally {
    $presentation->dispose();
}
```

Si el libro de trabajo externo no está disponible y la recuperación está desactivada, Aspose.Slides lanza una excepción. Habilite la recuperación solo cuando usar los datos del gráfico en caché sea una alternativa aceptable, porque la caché puede no contener los cambios realizados en el libro de trabajo externo después de la última actualización de la presentación.

## **Preguntas frecuentes**

**¿Puedo determinar si un gráfico específico está vinculado a un libro de trabajo externo o incrustado?**

Sí. Un gráfico tiene un [tipo de origen de datos](https://reference.aspose.com/slides/es/php-java/aspose.slides/chartdata/getdatasourcetype/) y una [ruta a un libro de trabajo externo](https://reference.aspose.com/slides/es/php-java/aspose.slides/chartdata/getexternalworkbookpath/); si la fuente es un libro de trabajo externo, puede leer la ruta completa para asegurarse de que se está utilizando un archivo externo.

**¿Se admiten rutas relativas a libros de trabajo externos y cómo se almacenan?**

Sí. Si especifica una ruta relativa, se convierte automáticamente en una ruta absoluta. Esto es conveniente para la portabilidad del proyecto; sin embargo, tenga en cuenta que la presentación almacenará la ruta absoluta en el archivo PPTX.

**¿Puedo usar libros de trabajo ubicados en recursos o comparticiones de red?**

Sí, esos libros de trabajo pueden usarse como fuente de datos externa. No obstante, la edición directa de libros de trabajo remotos desde Aspose.Slides no está soportada; solo pueden usarse como fuente.

**¿Sobrescribe Aspose.Slides el XLSX externo al guardar la presentación?**

No. La presentación almacena un [enlace al archivo externo](https://reference.aspose.com/slides/es/php-java/aspose.slides/chartdata/getexternalworkbookpath/) y lo usa para leer los datos. El archivo externo no se modifica al guardar la presentación.

**¿Qué debo hacer si el archivo externo está protegido con contraseña?**

Aspose.Slides no acepta una contraseña al crear el enlace. Un enfoque común es eliminar la protección con antelación o preparar una copia descifrada (por ejemplo, usando [Aspose.Cells](/cells/php-java/)) y enlazar a esa copia.

**¿Pueden varios gráficos referenciar el mismo libro de trabajo externo?**

Sí. Cada gráfico almacena su propio enlace. Si todos apuntan al mismo archivo, la actualización de ese archivo se reflejará en cada gráfico la próxima vez que se carguen los datos.
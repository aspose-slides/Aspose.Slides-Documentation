---
title: Gestionar libros de trabajo de gráficos en presentaciones con PHP
linktitle: Libro de trabajo de gráfico
type: docs
weight: 70
url: /es/php-java/chart-workbook/
keywords:
- libro de trabajo de gráfico
- datos de gráfico
- celda de libro de trabajo
- etiqueta de datos
- hoja de cálculo
- origen de datos
- libro de trabajo externo
- datos externos
- PowerPoint
- presentación
- PHP
- Aspose.Slides
description: "Descubra Aspose.Slides para PHP a través de Java: gestione sin esfuerzo los libros de trabajo de gráficos en formatos PowerPoint y OpenDocument para optimizar los datos de sus presentaciones."
---
## **Visión general**

Este artículo explica cómo trabajar con libros de trabajo de gráficos en Aspose.Slides. Muestra cómo leer y escribir datos de gráficos mediante flujos de libro de trabajo, usar celdas de libro de trabajo como etiquetas de datos del gráfico, acceder a colecciones de hojas de cálculo y especificar el tipo de origen de datos para los valores del gráfico.

También cubre el trabajo con libros de trabajo externos como fuentes de datos de gráficos. Los ejemplos demuestran cómo crear y asignar un libro de trabajo externo, obtener la ruta de un libro de trabajo externo vinculado a un gráfico y editar los datos del gráfico cuando el libro de trabajo está disponible.

## **Leer y escribir datos de gráfico desde un libro de trabajo**
Aspose.Slides proporciona los métodos [readWorkbookStream](https://reference.aspose.com/slides/es/php-java/aspose.slides/chartdata/#readWorkbookStream) y [writeWorkbookStream](https://reference.aspose.com/slides/es/php-java/aspose.slides/chartdata/#writeWorkbookStream) que le permiten leer y escribir libros de trabajo de datos de gráficos (que contienen datos de gráficos editados con Aspose.Cells). **Nota** que los datos del gráfico deben estar organizados de la misma manera o poseer una estructura similar a la fuente.

Este código PHP muestra una operación de ejemplo:

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

## **Establecer una celda de Workbook como etiqueta de datos del gráfico**

1. Cree una instancia de la clase [Presentation](https://apireference.aspose.com/slides/es/php-java/aspose.slides/presentation).  
1. Obtenga la referencia de una diapositiva mediante su índice.  
1. Añada un gráfico de burbujas con algunos datos.  
1. Acceda a la serie del gráfico.  
1. Establezca la celda del workbook como etiqueta de datos.  
1. Guarde la presentación.

Este código PHP le muestra cómo establecer una celda de workbook como etiqueta de datos del gráfico:

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

## **Administrar hojas de cálculo**

Este código PHP demuestra una operación donde se usa el método [ChartDataWorkbook::getWorksheets](https://reference.aspose.com/slides/es/php-java/aspose.slides/chartdataworkbook/#getWorksheets) para acceder a una colección de hojas de cálculo:

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

## **Detectar formatos de workbook incrustado no compatibles**

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

    # Lea o modifique los datos del libro de trabajo del gráfico aquí.
  }
} finally {
  $presentation->dispose();
}
```

## **Workbook externo**

Aspose.Slides admite workbooks externos como origen de datos para gráficos.

### **Crear un workbook externo**

Usando los métodos **`readWorkbookStream`** y **`setExternalWorkbook`**, puede crear un workbook externo desde cero o convertir un workbook interno en externo.

Este código PHP muestra el proceso de creación de un workbook externo:

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

### **Establecer un workbook externo**

Mediante el método **`setExternalWorkbook`**, puede asignar un workbook externo a un gráfico como su origen de datos. Este método también puede usarse para actualizar la ruta al workbook externo (si este se ha movido).

Aunque no puede editar los datos en workbooks almacenados en ubicaciones remotas o recursos, aún puede utilizarlos como fuente de datos externa. Si se proporciona una ruta relativa para un workbook externo, se convierte automáticamente en una ruta completa.

Este código PHP le muestra cómo establecer un workbook externo:

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

El parámetro `ChartData` (bajo el método `setExternalWorkbook`) se usa para especificar si se cargará o no un workbook de Excel.

* Cuando el valor de `ChartData` es `false`, solo se actualiza la ruta del workbook; los datos del gráfico no se cargarán ni se actualizarán desde el workbook de destino. Use esta configuración cuando el workbook de destino no exista o no esté disponible.  
* Cuando el valor de `ChartData` es `true`, los datos del gráfico se actualizan desde el workbook de destino.

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

### **Obtener la ruta del workbook externo de origen de datos de un gráfico**

1. Cree una instancia de la clase [Presentation](https://apireference.aspose.com/slides/es/php-java/aspose.slides/presentation).  
1. Obtenga la referencia de una diapositiva mediante su índice.  
1. Cree un objeto para la forma del gráfico.  
1. Cree un objeto para el tipo de origen (`ChartDataSourceType`) que representa el origen de datos del gráfico.  
1. Especifique la condición correspondiente basándose en que el tipo de origen sea el mismo que el tipo de origen de workbook externo.

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

Puede editar los datos en workbooks externos de la misma forma que modifica el contenido de workbooks internos. Cuando un workbook externo no puede cargarse, se lanza una excepción.

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

## **Preguntas frecuentes**

**¿Puedo determinar si un gráfico concreto está vinculado a un workbook externo o incrustado?**

Sí. Un gráfico tiene un [tipo de origen de datos](https://reference.aspose.com/slides/es/php-java/aspose.slides/chartdata/getdatasourcetype/) y una [ruta a un workbook externo](https://reference.aspose.com/slides/es/php-java/aspose.slides/chartdata/getexternalworkbookpath/); si el origen es un workbook externo, puede leer la ruta completa para confirmar que se está utilizando un archivo externo.

**¿Se admiten rutas relativas a workbooks externos y cómo se almacenan?**

Sí. Si especifica una ruta relativa, se convierte automáticamente en una ruta absoluta. Esto es útil para la portabilidad del proyecto; sin embargo, tenga en cuenta que la presentación almacenará la ruta absoluta en el archivo PPTX.

**¿Puedo usar workbooks ubicados en recursos o comparticiones de red?**

Sí, dichos workbooks pueden usarse como fuente de datos externa. No obstante, la edición directa de workbooks remotos desde Aspose.Slides no está soportada; solo pueden usarse como origen.

**¿Aspose.Slides sobrescribe el XLSX externo al guardar la presentación?**

No. La presentación almacena un [enlace al archivo externo](https://reference.aspose.com/slides/es/php-java/aspose.slides/chartdata/getexternalworkbookpath/) y lo utiliza para leer los datos. El archivo externo no se modifica al guardar la presentación.

**¿Qué debo hacer si el archivo externo está protegido con contraseña?**

Aspose.Slides no acepta una contraseña al crear el enlace. Un enfoque habitual es eliminar la protección de antemano o preparar una copia desencriptada (por ejemplo, usando [Aspose.Cells](/cells/php-java/)) y enlazar a esa copia.

**¿Pueden varios gráficos referenciar el mismo workbook externo?**

Sí. Cada gráfico almacena su propio enlace. Si todos apuntan al mismo archivo, la actualización de ese archivo se reflejará en cada gráfico la próxima vez que se carguen los datos.
---
title: Liberación de Gráficos
type: docs
weight: 70
url: /php-java/chart-workbook/
keywords: "Libro de gráficos, datos de gráficos, presentación de PowerPoint, Java, Aspose.Slides para PHP a través de Java"
description: "Libro de gráficos en presentación de PowerPoint"
---

## **Establecer Datos de Gráfico desde el Libro**
Aspose.Slides proporciona los métodos [ReadWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/IChartData#readWorkbookStream--) y [WriteWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/IChartData#writeWorkbookStream-byte:A-) que te permiten leer y escribir libros de datos de gráficos (que contienen datos de gráficos editados con Aspose.Cells). **Nota** que los datos del gráfico deben estar organizados de la misma manera o deben tener una estructura similar a la fuente.

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

## **Establecer Celda del Libro de Trabajo como DataLabel de Gráfico**

1. Crea una instancia de la clase [Presentation](https://apireference.aspose.com/slides/php-java/aspose.slides/presentation).
1. Obtén una referencia de la diapositiva a través de su índice.
1. Agrega un gráfico de burbujas con algunos datos.
1. Accede a la serie de gráficos.
1. Establece la celda del libro de trabajo como una etiqueta de datos.
1. Guarda la presentación.

Este código PHP te muestra cómo establecer una celda del libro de trabajo como una etiqueta de datos del gráfico:

```php
  $lbl0 = "Valor de celda Etiqueta 0";
  $lbl1 = "Valor de celda Etiqueta 1";
  $lbl2 = "Valor de celda Etiqueta 2";
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

## **Administrar Hojas de Cálculo**

Este código PHP demuestra una operación donde se utiliza el método [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/php-java/aspose.slides/IChartDataWorkbook#getWorksheets--) para acceder a una colección de hojas de cálculo:

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

## **Especificar Tipo de Fuente de Datos**

Este código PHP te muestra cómo especificar un tipo para una fuente de datos:

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

## **Libro de Trabajo Externo**

{{% alert color="primary" %}} 
En [Aspose.Slides 19.4](https://docs.aspose.com/slides/php-java/aspose-slides-for-java-19-4-release-notes/), implementamos soporte para libros de trabajo externos como fuente de datos para gráficos.
{{% /alert %}} 

### **Crear Libro de Trabajo Externo**

Usando los métodos **`readWorkbookStream`** y **`setExternalWorkbook`**, puedes crear un libro de trabajo externo desde cero o hacer que un libro de trabajo interno sea externo.

Este código PHP demuestra el proceso de creación de un libro de trabajo externo:

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

### **Establecer Libro de Trabajo Externo**

Usando el método **`setExternalWorkbook`**, puedes asignar un libro de trabajo externo a un gráfico como su fuente de datos. Este método también se puede utilizar para actualizar una ruta al libro de trabajo externo (si este ha sido movido).

Si bien no puedes editar los datos en libros de trabajo almacenados en ubicaciones o recursos remotos, aún puedes usar tales libros de trabajo como una fuente de datos externa. Si se proporciona la ruta relativa para un libro de trabajo externo, se convierte automáticamente en una ruta completa.

Este código PHP te muestra cómo establecer un libro de trabajo externo:

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

El parámetro `ChartData` (bajo el método `setExternalWorkbook`) se utiliza para especificar si se cargará un libro de trabajo de Excel o no.

* Cuando el valor de `ChartData` se establece en `false`, solo se actualiza la ruta del libro de trabajo; los datos del gráfico no se cargarán ni se actualizarán desde el libro de trabajo de destino. Es posible que desees usar esta configuración cuando se presente una situación en la que el libro de trabajo de destino no existe o no está disponible. 
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

### **Obtener Ruta del Libro de Trabajo de Fuente de Datos Externa del Gráfico**

1. Crea una instancia de la [Presentation](https://apireference.aspose.com/slides/php-java/aspose.slides/presentation) clase.
1. Obtén una referencia de la diapositiva a través de su índice.
1. Crea un objeto para la forma del gráfico.
1. Crea un objeto para el tipo de fuente (`ChartDataSourceType`) que representa la fuente de datos del gráfico.
1. Especifica la condición relevante según el tipo de fuente, siendo el mismo que el tipo de fuente de datos del libro de trabajo externo.

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

### **Editar Datos del Gráfico**

Puedes editar los datos en libros de trabajo externos de la misma manera que haces cambios en el contenido de libros de trabajo internos. Cuando un libro de trabajo externo no se puede cargar, se lanza una excepción.

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
---
title: 프레젠테이션에서 PHP를 사용해 차트 워크북 관리
linktitle: 차트 워크북
type: docs
weight: 70
url: /ko/php-java/chart-workbook/
keywords:
- 차트 워크북
- 차트 데이터
- 워크북 셀
- 데이터 레이블
- 워크시트
- 데이터 소스
- 외부 워크북
- 외부 데이터
- 차트 캐시
- 워크북 복구
- PowerPoint
- 프레젠테이션
- PHP
- Aspose.Slides
description: "Java를 통해 PHP용 Aspose.Slides를 발견하고, PowerPoint 및 OpenDocument 형식에서 차트 워크북을 손쉽게 관리하여 프레젠테이션 데이터를 효율화하세요."
---
## **Overview**

이 문서에서는 Aspose.Slides에서 차트 워크북을 사용하는 방법을 설명합니다. 워크북 스트림을 통해 차트 데이터를 읽고 쓰는 방법, 워크북 셀을 차트 데이터 레이블로 사용하는 방법, 워크시트 컬렉션에 접근하는 방법, 차트 값에 대한 데이터 소스 유형을 지정하는 방법을 보여줍니다.

또한 외부 워크북을 차트 데이터 소스로 사용하는 방법도 다룹니다. 예제에서는 외부 워크북을 생성하고 할당하는 방법, 차트에 연결된 외부 워크북의 경로를 가져오는 방법, 워크북이 사용할 수 있을 때 차트 데이터를 편집하는 방법을 시연합니다.

## **Read and Write Chart Data from a Workbook**
Aspose.Slides는 [readWorkbookStream](https://reference.aspose.com/slides/ko/php-java/aspose.slides/chartdata/#readWorkbookStream) 및 [writeWorkbookStream](https://reference.aspose.com/slides/ko/php-java/aspose.slides/chartdata/#writeWorkbookStream) 메서드를 제공하여 워크북 스트림을 통해 차트 데이터를 읽고 쓸 수 있습니다(차트 데이터는 Aspose.Cells로 편집된 워크북에 포함됨). **Note** 차트 데이터는 동일한 방식으로 조직되어 있거나 원본과 유사한 구조를 가져야 합니다.

이 PHP 코드 예제는 작업 샘플을 보여줍니다:

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

### **Validate Chart Layout After Workbook Modification**

임베디드 워크북을 수정된 워크북으로 교체하면 차트는 원래의 시리즈와 카테고리 컬렉션을 유지합니다. 이 불일치로 인해 [Chart::validateChartLayout](https://reference.aspose.com/slides/ko/php-java/aspose.slides/chart/validatechartlayout/)이 인덱스 범위 초과 오류를 발생시킬 수 있습니다. 업데이트된 워크북을 차트에 다시 쓰기 전에 기존 시리즈와 카테고리를 삭제하십시오.

```php
// 워크북 스트림을 수정한 후 (예: Aspose.Cells 사용)
$updatedWorkbook = $chartData->readWorkbookStream();

// 기존 데이터 참조를 삭제합니다.
$chartData->getSeries()->clear();
$chartData->getCategories()->clear();

$chartData->writeWorkbookStream($updatedWorkbook);

$chart->validateChartLayout();
```

컬렉션을 삭제하면 차트 데이터 구조가 새 워크북과 일치하게 되며, `validateChartLayout`이 오류 없이 완료됩니다.

## **Set a WorkBook Cell as a Chart Data Label**

1. [Presentation](https://apireference.aspose.com/slides/ko/php-java/aspose.slides/presentation) 클래스의 인스턴스를 생성합니다.  
2. 인덱스를 사용해 슬라이드 참조를 가져옵니다.  
3. 데이터가 포함된 버블 차트를 추가합니다.  
4. 차트 시리즈에 접근합니다.  
5. 워크북 셀을 데이터 레이블로 설정합니다.  
6. 프레젠테이션을 저장합니다.

이 PHP 코드는 워크북 셀을 차트 데이터 레이블로 설정하는 방법을 보여줍니다:

```php
  $lbl0 = "Label 0 cell value";
  $lbl1 = "Label 1 cell value";
  $lbl2 = "Label 2 cell value";
  # 프레젠테이션 파일을 나타내는 프레젠테이션 클래스를 인스턴스화합니다
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

## **Manage Worksheets**

다음 PHP 코드는 [ChartDataWorkbook::getWorksheets](https://reference.aspose.com/slides/ko/php-java/aspose.slides/chartdataworkbook/#getWorksheets) 메서드를 사용해 워크시트 컬렉션에 접근하는 작업을 시연합니다:

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

## **Specify the Data Source Type**

다음 PHP 코드는 데이터 소스 유형을 지정하는 방법을 보여줍니다:

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

## **Detect Unsupported Embedded Workbook Formats**

Aspose.Slides는 일부 차트에 임베드될 수 있는 Excel 이진 워크북(.xlsb) 형식을 지원하지 않습니다. [ChartData](https://reference.aspose.com/slides/ko/php-java/aspose.slides/chartdata/)의 `getEmbeddedWorkbookType` 메서드와 [WorkbookType](https://reference.aspose.com/slides/ko/php-java/aspose.slides/workbooktype/) 열거형을 함께 사용하여 지원되지 않는 형식을 감지하고 해당 차트를 건너뛸 수 있습니다.

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
      # 임베디드 워크북이 .xlsb 형식이며, 지원되지 않습니다.
      continue;
    }

    # 여기에서 차트 워크북 데이터를 읽거나 수정합니다.
  }
} finally {
  $presentation->dispose();
}
```

## **External Workbook**

Aspose.Slides는 외부 워크북을 차트 데이터 소스로 지원합니다.

### **Create an External Workbook**

**`readWorkbookStream`** 및 **`setExternalWorkbook`** 메서드를 사용하면 새 외부 워크북을 만들거나 내부 워크북을 외부 워크북으로 전환할 수 있습니다.

이 PHP 코드는 외부 워크북 생성 과정을 보여줍니다:

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

### **Set an External Workbook**

**`setExternalWorkbook`** 메서드를 사용하면 차트에 외부 워크북을 데이터 소스로 할당할 수 있습니다. 이 메서드는 외부 워크북이 이동된 경우 경로를 업데이트하는 데에도 사용할 수 있습니다.

원격 위치나 리소스에 저장된 워크북의 데이터를 직접 편집할 수는 없지만, 이러한 워크북을 외부 데이터 소스로 사용할 수 있습니다. 상대 경로가 제공되면 자동으로 전체 경로로 변환됩니다.

이 PHP 코드는 외부 워크북을 설정하는 방법을 보여줍니다:

```php
  # Presentation 클래스의 인스턴스를 생성합니다
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

`setExternalWorkbook` 메서드의 `ChartData` 매개변수는 Excel 워크북을 로드할지 여부를 지정하는 데 사용됩니다.

* `ChartData` 값을 `false` 로 설정하면 워크북 경로만 업데이트되고 차트 데이터는 대상 워크북에서 로드되거나 업데이트되지 않습니다. 대상 워크북이 존재하지 않거나 사용할 수 없는 경우에 이 설정을 사용합니다.  
* `ChartData` 값을 `true` 로 설정하면 차트 데이터가 대상 워크북에서 업데이트됩니다.

```php
  # Presentation 클래스의 인스턴스를 생성합니다
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

### **Get the External Data Source Workbook Path of a Chart**

1. [Presentation](https://apireference.aspose.com/slides/ko/php-java/aspose.slides/presentation) 클래스의 인스턴스를 생성합니다.  
2. 인덱스를 사용해 슬라이드 참조를 가져옵니다.  
3. 차트 도형 객체를 생성합니다.  
4. 차트 데이터 소스를 나타내는 `ChartDataSourceType` 객체를 생성합니다.  
5. 외부 워크북 데이터 소스 유형과 동일한 소스 유형인지 확인하는 조건을 지정합니다.

이 PHP 코드는 해당 작업을 시연합니다:

```php
  # Presentation 클래스의 인스턴스를 생성합니다
  $pres = new Presentation("chart.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(1);
    $chart = $slide->getShapes()->get_Item(0);
    $sourceType = $chart->getChartData()->getDataSourceType();
    if ($sourceType == ChartDataSourceType::ExternalWorkbook) {
      $path = $chart->getChartData()->getExternalWorkbookPath();
    }
    # 프레젠테이션을 저장합니다
    $pres->save("result.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Edit Chart Data**

외부 워크북의 데이터를 내부 워크북을 편집하는 방식과 동일하게 수정할 수 있습니다. 외부 워크북을 로드할 수 없을 경우 예외가 발생합니다.

다음 PHP 코드는 이 과정을 구현한 예시입니다:

```php
  # Presentation 클래스의 인스턴스를 생성합니다
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

### **Recover a Workbook from the Chart Cache**

차트가 존재하지 않거나 사용할 수 없는 외부 워크북을 사용하고 있는 경우, Aspose.Slides는 프레젠테이션에 캐시된 데이터를 기반으로 차트 워크북을 복구할 수 있습니다. [LoadOptions](https://reference.aspose.com/slides/ko/php-java/aspose.slides/loadoptions/)를 생성하고 [SpreadsheetOptions](https://reference.aspose.com/slides/ko/php-java/aspose.slides/spreadsheetoptions/)를 구성한 뒤, 프레젠테이션을 열기 전에 `SpreadsheetOptions::setRecoverWorkbookFromChartCache`를 `true` 로 설정합니다.

다음 PHP 예제는 사용할 수 없는 외부 워크북을 참조하는 차트를 포함한 프레젠테이션을 열고, 복구된 데이터를 [Chart::getChartData](https://reference.aspose.com/slides/ko/php-java/aspose.slides/chart/#getChartData)와 [ChartData::getChartDataWorkbook](https://reference.aspose.com/slides/ko/php-java/aspose.slides/chartdata/#getChartDataWorkbook)로 접근하는 과정을 보여줍니다:

```php
$spreadsheetOptions = new SpreadsheetOptions();
$spreadsheetOptions->setRecoverWorkbookFromChartCache(true);

$loadOptions = new LoadOptions();
$loadOptions->setSpreadsheetOptions($spreadsheetOptions);

$presentation = new Presentation("presentation.pptx", $loadOptions);
try {
    $chart = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $recoveredWorkbook = $chart->getChartData()->getChartDataWorkbook();

    # 여기에서 복구된 워크북 데이터를 읽거나 수정합니다.
} finally {
    $presentation->dispose();
}
```

외부 워크북을 사용할 수 없고 복구가 비활성화된 경우 Aspose.Slides는 예외를 발생시킵니다. 캐시된 차트 데이터를 사용하는 것이 허용 가능한 대체 방안일 때만 복구를 활성화하십시오. 캐시에는 프레젠테이션이 마지막으로 업데이트된 이후 외부 워크북에 적용된 변경 사항이 포함되지 않을 수 있습니다.

## **FAQ**

**Can I determine whether a specific chart is linked to an external or an embedded workbook?**

예. 차트에는 [data source type](https://reference.aspose.com/slides/ko/php-java/aspose.slides/chartdata/getdatasourcetype/)과 [external workbook 경로](https://reference.aspose.com/slides/ko/php-java/aspose.slides/chartdata/getexternalworkbookpath/)가 있습니다. 소스가 외부 워크북인 경우 전체 경로를 읽어 외부 파일이 사용되고 있는지 확인할 수 있습니다.

**Are relative paths to external workbooks supported, and how are they stored?**

예. 상대 경로를 지정하면 자동으로 절대 경로로 변환됩니다. 이는 프로젝트 이식성을 높여 주지만, 프레젠테이션 파일(PPTX)에는 절대 경로가 저장된다는 점에 유의하십시오.

**Can I use workbooks located on network resources/shares?**

예, 이러한 워크북을 외부 데이터 소스로 사용할 수 있습니다. 그러나 Aspose.Slides에서는 원격 워크북을 직접 편집하는 것은 지원되지 않으며, 소스로만 사용할 수 있습니다.

**Does Aspose.Slides overwrite the external XLSX when saving the presentation?**

아니요. 프레젠테이션은 [external file에 대한 링크](https://reference.aspose.com/slides/ko/php-java/aspose.slides/chartdata/getexternalworkbookpath/)만 저장하고, 저장 시 외부 파일 자체는 수정되지 않습니다.

**What should I do if the external file is password-protected?**

Aspose.Slides는 연결 시 비밀번호를 받지 않습니다. 일반적인 해결 방법은 사전에 보호를 해제하거나, [Aspose.Cells](/cells/php-java/) 등을 사용해 복호화된 복사본을 만든 뒤 해당 복사본에 연결하는 것입니다.

**Can multiple charts reference the same external workbook?**

예. 각 차트는 자체 링크를 저장합니다. 모든 차트가 동일한 파일을 가리키면, 해당 파일을 업데이트했을 때 다음 데이터 로드 시 각 차트에 반영됩니다.
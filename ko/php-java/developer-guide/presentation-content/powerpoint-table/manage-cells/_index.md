---
title: PHP를 사용하여 프레젠테이션에서 표 셀 관리
linktitle: 셀 관리
type: docs
weight: 30
url: /ko/php-java/manage-cells/
keywords:
- 표 셀
- 셀 병합
- 테두리 제거
- 셀 분할
- 셀 내 이미지
- 배경 색
- PowerPoint
- 프레젠테이션
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP를 사용하여 PowerPoint의 표 셀을 손쉽게 관리하세요. 셀에 빠르게 접근, 수정 및 스타일링을 마스터하여 원활한 슬라이드 자동화를 구현합니다."
---
## **개요**

Aspose.Slides를 사용하면 PowerPoint 프레젠테이션에서 표 셀에 액세스하고 수정할 수 있습니다. 이 문서에서는 병합된 표 셀을 식별하는 방법, 셀 테두리를 제거하는 방법, 셀을 병합하거나 분할한 후 셀 번호 매기기를 관리하는 방법, 셀 배경 색을 변경하는 방법 및 표 셀 안에 이미지를 추가하는 방법을 설명합니다. 예제에서는 프레젠테이션을 생성하거나 열고, 슬라이드에서 표를 가져오고, 셀 속성을 통해 셀 서식을 업데이트하고, 수정된 프레젠테이션을 PPTX 파일로 저장하는 방법을 보여줍니다.

## **병합된 표 셀 식별**
1. [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/Presentation) 클래스의 인스턴스를 생성합니다.  
2. 첫 번째 슬라이드에서 표를 가져옵니다.  
3. 표의 행과 열을 반복하여 병합된 셀을 찾습니다.  
4. 병합된 셀이 발견되면 메시지를 출력합니다.

다음 PHP 코드는 프레젠테이션에서 병합된 표 셀을 식별하는 방법을 보여줍니다:

```php
  $pres = new Presentation("SomePresentationWithTable.pptx");
  try {
    $table = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0); // Slide#0.Shape#0이 표라고 가정

    for($i = 0; $i < java_values($table->getRows()->size()) ; $i++) {
      for($j = 0; $j < java_values($table->getColumns()->size()) ; $j++) {
        $currentCell = $table->getRows()->get_Item($i)->get_Item($j);
        if ($currentCell->isMergedCell()) {
          echo(sprintf("Cell %d;%d is a part of merged cell with RowSpan=%d and ColSpan=%d starting from Cell %d;%d.", $i, $j, $currentCell->getRowSpan(), $currentCell->getColSpan(), $currentCell->getFirstRowIndex(), $currentCell->getFirstColumnIndex()));
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **표 셀 테두리 제거**
1. [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/Presentation) 클래스의 인스턴스를 생성합니다.  
2. 인덱스를 사용하여 슬라이드 참조를 가져옵니다.  
3. 너비를 지정한 열 배열을 정의합니다.  
4. 높이를 지정한 행 배열을 정의합니다.  
5. [addTable](https://reference.aspose.com/slides/ko/php-java/aspose.slides/shapecollection/#addTable) 메서드를 사용하여 슬라이드에 표를 추가합니다.  
6. 각 셀을 반복하여 위, 아래, 오른쪽 및 왼쪽 테두리를 제거합니다.  
7. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

다음 PHP 코드는 표 셀의 테두리를 제거하는 방법을 보여줍니다:

```php
  # PPTX 파일을 나타내는 Presentation 클래스를 인스턴스화합니다
  $pres = new Presentation();
  try {
    # 첫 번째 슬라이드에 접근합니다
    $sld = $pres->getSlides()->get_Item(0);
    # 너비가 지정된 열과 높이가 지정된 행을 정의합니다
    $dblCols = array(50, 50, 50, 50 );
    $dblRows = array(50, 30, 30, 30, 30 );
    # 슬라이드에 표 모양을 추가합니다
    $tbl = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    # 각 셀에 대한 테두리 형식을 설정합니다
    foreach($tbl->getRows() as $row) {
      foreach($row as $cell) {
        $cell->getCellFormat()->getBorderTop()->getFillFormat()->setFillType(FillType::NoFill);
        $cell->getCellFormat()->getBorderBottom()->getFillFormat()->setFillType(FillType::NoFill);
        $cell->getCellFormat()->getBorderLeft()->getFillFormat()->setFillType(FillType::NoFill);
        $cell->getCellFormat()->getBorderRight()->getFillFormat()->setFillType(FillType::NoFill);
      }
    }
    # PPTX 파일을 디스크에 저장합니다
    $pres->save("table_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **병합된 셀의 번호 매기기**
두 쌍의 셀 (1, 1) x (2, 1) 및 (1, 2) x (2, 2)를 병합하면 결과 표에 번호가 매겨집니다. 다음 PHP 코드는 이 과정을 보여줍니다:

```php
  # PPTX 파일을 나타내는 Presentation 클래스를 인스턴스화합니다
  $pres = new Presentation();
  try {
    # 첫 번째 슬라이드에 접근합니다
    $sld = $pres->getSlides()->get_Item(0);
    # 너비가 지정된 열과 높이가 지정된 행을 정의합니다
    $dblCols = array(70, 70, 70, 70 );
    $dblRows = array(70, 70, 70, 70 );
    # 슬라이드에 표 모양을 추가합니다
    $tbl = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    # 각 셀에 대한 테두리 형식을 설정합니다
    foreach($tbl->getRows() as $row) {
      foreach($row as $cell) {
        $cell->getCellFormat()->getBorderTop()->getFillFormat()->setFillType(FillType::Solid);
        $cell->getCellFormat()->getBorderTop()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cell->getCellFormat()->getBorderTop()->setWidth(5);
        $cell->getCellFormat()->getBorderBottom()->getFillFormat()->setFillType(FillType::Solid);
        $cell->getCellFormat()->getBorderBottom()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cell->getCellFormat()->getBorderBottom()->setWidth(5);
        $cell->getCellFormat()->getBorderLeft()->getFillFormat()->setFillType(FillType::Solid);
        $cell->getCellFormat()->getBorderLeft()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cell->getCellFormat()->getBorderLeft()->setWidth(5);
        $cell->getCellFormat()->getBorderRight()->getFillFormat()->setFillType(FillType::Solid);
        $cell->getCellFormat()->getBorderRight()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cell->getCellFormat()->getBorderRight()->setWidth(5);
      }
    }
    # 셀 (1, 1) x (2, 1)을 병합합니다
    $tbl->mergeCells($tbl->get_Item(1, 1), $tbl->get_Item(2, 1), false);
    # 셀 (1, 2) x (2, 2)을 병합합니다
    $tbl->mergeCells($tbl->get_Item(1, 2), $tbl->get_Item(2, 2), false);
    $pres->save("MergeCells_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

그런 다음 (1, 1)과 (1, 2)를 병합하여 셀을 추가로 병합합니다. 결과는 중앙에 큰 병합 셀이 있는 표입니다:

```php
  # PPTX 파일을 나타내는 Presentation 클래스를 인스턴스화합니다
  $pres = new Presentation();
  try {
    # 첫 번째 슬라이드에 접근합니다
    $sld = $pres->getSlides()->get_Item(0);
    # 너비가 지정된 열과 높이가 지정된 행을 정의합니다
    $dblCols = array(70, 70, 70, 70 );
    $dblRows = array(70, 70, 70, 70 );
    # 슬라이드에 표 모양을 추가합니다
    $tbl = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    # 각 셀에 대한 테두리 형식을 설정합니다
    foreach($tbl->getRows() as $row) {
      foreach($row as $cell) {
        $cell->getCellFormat()->getBorderTop()->getFillFormat()->setFillType(FillType::Solid);
        $cell->getCellFormat()->getBorderTop()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cell->getCellFormat()->getBorderTop()->setWidth(5);
        $cell->getCellFormat()->getBorderBottom()->getFillFormat()->setFillType(FillType::Solid);
        $cell->getCellFormat()->getBorderBottom()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cell->getCellFormat()->getBorderBottom()->setWidth(5);
        $cell->getCellFormat()->getBorderLeft()->getFillFormat()->setFillType(FillType::Solid);
        $cell->getCellFormat()->getBorderLeft()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cell->getCellFormat()->getBorderLeft()->setWidth(5);
        $cell->getCellFormat()->getBorderRight()->getFillFormat()->setFillType(FillType::Solid);
        $cell->getCellFormat()->getBorderRight()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cell->getCellFormat()->getBorderRight()->setWidth(5);
      }
    }
    # 셀 (1, 1) x (2, 1)을 병합합니다
    $tbl->mergeCells($tbl->get_Item(1, 1), $tbl->get_Item(2, 1), false);
    # 셀 (1, 2) x (2, 2)을 병합합니다
    $tbl->mergeCells($tbl->get_Item(1, 2), $tbl->get_Item(2, 2), false);
    # 셀 (1, 1) x (1, 2)을 병합합니다
    $tbl->mergeCells($tbl->get_Item(1, 1), $tbl->get_Item(1, 2), true);
    # PPTX 파일을 디스크에 저장합니다
    $pres->save("MergeCells_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **분할된 셀의 번호 매기기**
이전 예제에서는 표 셀을 병합해도 다른 셀의 번호 매기기 체계는 변경되지 않았습니다.

이번에는 병합된 셀이 없는 일반 표를 사용한 다음 셀 (1,1)을 분할하여 특수한 표를 만듭니다. 이 표의 번호 매기기가 이상하게 보일 수 있으니 주의하십시오. 그러나 이것이 Microsoft PowerPoint가 표 셀에 번호를 매기는 방식이며 Aspose.Slides도 동일하게 동작합니다.

다음 PHP 코드는 설명한 과정을 보여줍니다:

```php
  # PPTX 파일을 나타내는 Presentation 클래스를 인스턴스화합니다
  $pres = new Presentation();
  try {
    # 첫 번째 슬라이드에 접근합니다
    $sld = $pres->getSlides()->get_Item(0);
    # 너비가 지정된 열과 높이가 지정된 행을 정의합니다
    $dblCols = array(70, 70, 70, 70 );
    $dblRows = array(70, 70, 70, 70 );
    # 슬라이드에 표 모양을 추가합니다
    $tbl = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    # 각 셀에 대한 테두리 형식을 설정합니다
    foreach($tbl->getRows() as $row) {
      foreach($row as $cell) {
        $cell->getCellFormat()->getBorderTop()->getFillFormat()->setFillType(FillType::Solid);
        $cell->getCellFormat()->getBorderTop()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cell->getCellFormat()->getBorderTop()->setWidth(5);
        $cell->getCellFormat()->getBorderBottom()->getFillFormat()->setFillType(FillType::Solid);
        $cell->getCellFormat()->getBorderBottom()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cell->getCellFormat()->getBorderBottom()->setWidth(5);
        $cell->getCellFormat()->getBorderLeft()->getFillFormat()->setFillType(FillType::Solid);
        $cell->getCellFormat()->getBorderLeft()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cell->getCellFormat()->getBorderLeft()->setWidth(5);
        $cell->getCellFormat()->getBorderRight()->getFillFormat()->setFillType(FillType::Solid);
        $cell->getCellFormat()->getBorderRight()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cell->getCellFormat()->getBorderRight()->setWidth(5);
      }
    }
    # 셀 (1, 1) x (2, 1)을 병합합니다
    $tbl->mergeCells($tbl->get_Item(1, 1), $tbl->get_Item(2, 1), false);
    # 셀 (1, 2) x (2, 2)을 병합합니다
    $tbl->mergeCells($tbl->get_Item(1, 2), $tbl->get_Item(2, 2), false);
    # 셀 (1, 1)을 분할합니다
    $tbl->get_Item(1, 1)->splitByWidth($tbl->get_Item(2, 1)->getWidth() / 2);
    # PPTX 파일을 디스크에 저장합니다
    $pres->save("SplitCells_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **표 셀 배경 색 변경**

다음 PHP 코드는 표 셀의 배경 색을 변경하는 방법을 보여줍니다:

```php
  $presentation = new Presentation();
  try {
    $slide = $presentation->getSlides()->get_Item(0);
    $dblCols = array(150, 150, 150, 150 );
    $dblRows = array(50, 50, 50, 50, 50 );
    # 새 표를 생성합니다
    $table = $slide->getShapes()->addTable(50, 50, $dblCols, $dblRows);
    # 셀의 배경 색을 설정합니다
    $cell = $table->get_Item(2, 3);
    $cell->getCellFormat()->getFillFormat()->setFillType(FillType::Solid);
    $cell->getCellFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $presentation->save("cell_background_color.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **표 셀 안에 이미지 추가**
1. [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/Presentation) 클래스의 인스턴스를 생성합니다.  
2. 인덱스를 사용하여 슬라이드 참조를 가져옵니다.  
3. 너비를 지정한 열 배열을 정의합니다.  
4. 높이를 지정한 행 배열을 정의합니다.  
5. [AddTable](https://reference.aspose.com/slides/ko/php-java/aspose.slides/shapecollection/#addTable) 메서드를 사용하여 슬라이드에 표를 추가합니다.  
6. `Images` 객체를 생성하여 이미지 파일을 보관합니다.  
7. `IImage` 이미지를 `IPPImage` 객체에 추가합니다.  
8. 표 셀의 `FillFormat`을 `Picture`로 설정합니다.  
9. 이미지를 표의 첫 번째 셀에 추가합니다.  
10. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

다음 PHP 코드는 표를 만들 때 표 셀 안에 이미지를 배치하는 방법을 보여줍니다:

```php
  # PPTX 파일을 나타내는 Presentation 클래스를 인스턴스화합니다
  $pres = new Presentation();
  try {
    # 첫 번째 슬라이드에 접근합니다
    $islide = $pres->getSlides()->get_Item(0);
    # 너비가 지정된 열과 높이가 지정된 행을 정의합니다
    $dblCols = array(150, 150, 150, 150 );
    $dblRows = array(100, 100, 100, 100, 90 );
    # 슬라이드에 표 모양을 추가합니다
    $tbl = $islide->getShapes()->addTable(50, 50, $dblCols, $dblRows);
    # 이미지 파일을 사용하여 IPPImage 객체를 생성합니다
    $picture;
    $image = Images->fromFile("image.jpg");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # 이미지를 첫 번째 표 셀에 추가합니다
    $cellFormat = $tbl->get_Item(0, 0)->getCellFormat();
    $cellFormat::getFillFormat()->setFillType(FillType::Picture);
    $cellFormat::getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode->Stretch);
    $cellFormat::getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);
    # PPTX 파일을 디스크에 저장합니다
    $pres->save("Image_In_TableCell_out.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**단일 셀의 각 면에 대해 서로 다른 선 두께와 스타일을 설정할 수 있나요?**

예. [top](https://reference.aspose.com/slides/ko/php-java/aspose.slides/cellformat/getbordertop/)/[bottom](https://reference.aspose.com/slides/ko/php-java/aspose.slides/cellformat/getborderbottom/)/[left](https://reference.aspose.com/slides/ko/php-java/aspose.slides/cellformat/getborderleft/)/[right](https://reference.aspose.com/slides/ko/php-java/aspose.slides/cellformat/getborderright/) 테두리는 각각 별도의 속성을 가지고 있어 각 면의 두께와 스타일을 다르게 지정할 수 있습니다. 이는 문서에서 보여준 셀별 면 테두리 제어와 논리적으로 일치합니다.

**셀 배경에 그림을 설정한 후 열/행 크기를 변경하면 이미지에 어떤 일이 발생하나요?**

동작은 [fill mode](https://reference.aspose.com/slides/ko/php-java/aspose.slides/picturefillmode/)(stretch/​tile)에 따라 달라집니다. 스트레칭을 사용하면 이미지가 새로운 셀에 맞게 조정되고, 타일링을 사용하면 타일이 다시 계산됩니다. 기사에서는 셀 내 이미지 표시 모드에 대해 언급하고 있습니다.

**셀의 모든 콘텐츠에 하이퍼링크를 지정할 수 있나요?**

[Hyperlinks](/slides/ko/php-java/manage-hyperlinks/)는 셀의 텍스트 프레임 내부 텍스트(부분) 수준이나 전체 표/모양 수준에서 설정됩니다. 실제로는 해당 링크를 텍스트의 일부에 지정하거나 셀의 전체 텍스트에 지정합니다.

**단일 셀 내에서 서로 다른 글꼴을 설정할 수 있나요?**

예. 셀의 텍스트 프레임은 [portions](https://reference.aspose.com/slides/ko/php-java/aspose.slides/portion/)(run)별로 독립적인 서식을 지원하므로 글꼴 패밀리, 스타일, 크기 및 색을 각각 지정할 수 있습니다.
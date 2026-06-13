---
title: PHP에서 프레젠테이션 표 관리
linktitle: 표 관리
type: docs
weight: 10
url: /ko/php-java/manage-table/
keywords:
- 표 추가
- 표 만들기
- 표 접근
- 가로세로 비율
- 텍스트 정렬
- 텍스트 서식
- 표 스타일
- PowerPoint
- 프레젠테이션
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP를 Java와 함께 사용하여 PowerPoint 슬라이드에서 표를 만들고 편집합니다. 표 작업 흐름을 간소화하는 간단한 코드 예제를 확인하세요."
---
## **소개**

PowerPoint의 표는 정보를 효율적으로 표시하고 전달하는 방법입니다. 행과 열로 구성된 셀 그리드에 들어 있는 정보는 직관적이며 이해하기 쉽습니다.

Aspose.Slides는 [Table](https://reference.aspose.com/slides/ko/php-java/aspose.slides/Table) 클래스, [Cell](https://reference.aspose.com/slides/ko/php-java/aspose.slides/cell/) 클래스 및 기타 유형을 제공하여 다양한 프레젠테이션에서 표를 생성, 업데이트 및 관리할 수 있습니다.

## **새 표 만들기**

1. [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/Presentation) 클래스의 인스턴스를 생성합니다.  
2. 인덱스를 통해 슬라이드 참조를 가져옵니다.  
3. `columnWidth` 배열을 정의합니다.  
4. `rowHeight` 배열을 정의합니다.  
5. [addTable](https://reference.aspose.com/slides/ko/php-java/aspose.slides/shapecollection/addtable/) 메서드를 사용하여 슬라이드에 [Table](https://reference.aspose.com/slides/ko/php-java/aspose.slides/table/) 객체를 추가합니다.  
6. 각 [Cell](https://reference.aspose.com/slides/ko/php-java/aspose.slides/cell/)을 반복하면서 위, 아래, 오른쪽, 왼쪽 테두리 서식을 적용합니다.  
7. 표 첫 번째 행의 앞 두 셀을 병합합니다.  
8. [Cell](https://reference.aspose.com/slides/ko/php-java/aspose.slides/cell/)의 [TextFrame](https://reference.aspose.com/slides/ko/php-java/aspose.slides/textframe/)에 접근합니다.  
9. [TextFrame](https://reference.aspose.com/slides/ko/php-java/aspose.slides/textframe/)에 텍스트를 추가합니다.  
10. 수정된 프레젠테이션을 저장합니다.

이 PHP 코드는 프레젠테이션에 표를 만드는 방법을 보여줍니다:

```php
  # PPTX 파일을 나타내는 Presentation 클래스를 인스턴스화합니다
  $pres = new Presentation();
  try {
    # 첫 번째 슬라이드에 접근합니다
    $sld = $pres->getSlides()->get_Item(0);
    # 열 너비와 행 높이를 정의합니다
    $dblCols = array(50, 50, 50 );
    $dblRows = array(50, 30, 30, 30, 30 );
    # 슬라이드에 표 도형을 추가합니다
    $tbl = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    # 각 셀에 대해 테두리 서식을 설정합니다
    for($row = 0; $row < java_values($tbl->getRows()->size()) ; $row++) {
      for($cell = 0; $cell < java_values($tbl->getRows()->get_Item($row)->size()) ; $cell++) {
        $cellFormat = $tbl->getRows()->get_Item($row)->get_Item($cell)->getCellFormat();
        $cellFormat::getBorderTop()->getFillFormat()->setFillType(FillType::Solid);
        $cellFormat::getBorderTop()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cellFormat::getBorderTop()->setWidth(5);
        $cellFormat::getBorderBottom()->getFillFormat()->setFillType(FillType::Solid);
        $cellFormat::getBorderBottom()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cellFormat::getBorderBottom()->setWidth(5);
        $cellFormat::getBorderLeft()->getFillFormat()->setFillType(FillType::Solid);
        $cellFormat::getBorderLeft()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cellFormat::getBorderLeft()->setWidth(5);
        $cellFormat::getBorderRight()->getFillFormat()->setFillType(FillType::Solid);
        $cellFormat::getBorderRight()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cellFormat::getBorderRight()->setWidth(5);
      }
    }
    # 1행의 1번째와 2번째 셀을 병합합니다
    $tbl->mergeCells($tbl->getRows()->get_Item(0)->get_Item(0), $tbl->getRows()->get_Item(1)->get_Item(1), false);
    # 병합된 셀에 텍스트를 추가합니다
    $tbl->getRows()->get_Item(0)->get_Item(0)->getTextFrame()->setText("Merged Cells");
    # 프레젠테이션을 디스크에 저장합니다
    $pres->save("table.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **표의 기본 번호 매기기**

표에서는 셀 번호 매기기가 간단하며 0부터 시작합니다. 표의 첫 번째 셀은 (0,0) (열 0, 행 0)으로 인덱싱됩니다.

예를 들어 4열 4행인 표의 셀 번호는 다음과 같습니다:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

이 PHP 코드는 표의 셀 번호를 지정하는 방법을 보여줍니다:

```php
  # Presentation 클래스를 인스턴스화하여 PPTX 파일을 나타냅니다
  $pres = new Presentation();
  try {
    # 첫 번째 슬라이드에 접근합니다
    $sld = $pres->getSlides()->get_Item(0);
    # 열 너비와 행 높이를 정의합니다
    $dblCols = array(70, 70, 70, 70 );
    $dblRows = array(70, 70, 70, 70 );
    # 슬라이드에 표 도형을 추가합니다
    $tbl = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    # 각 셀에 대한 테두리 서식을 설정합니다
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
    # 프레젠테이션을 디스크에 저장합니다
    $pres->save("StandardTables_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **기존 표에 접근하기**

1. [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/Presentation) 클래스의 인스턴스를 생성합니다.  

2. 인덱스를 통해 표가 포함된 슬라이드에 대한 참조를 가져옵니다.  

3. [Table](https://reference.aspose.com/slides/ko/php-java/aspose.slides/Table) 객체를 생성하고 null로 설정합니다.  

4. 모든 [Shape](https://reference.aspose.com/slides/ko/php-java/aspose.slides/shape/) 객체를 반복하여 표를 찾을 때까지 탐색합니다.  

   슬라이드에 단일 표만 포함되어 있다고 의심되는 경우 해당 슬라이드가 포함한 모든 도형을 확인하면 됩니다. 도형이 표로 식별되면 이를 [Table](https://reference.aspose.com/slides/ko/php-java/aspose.slides/Table) 객체로 형변환할 수 있습니다. 하지만 슬라이드에 여러 표가 포함된 경우 [setAlternativeText(String value)](https://reference.aspose.com/slides/ko/php-java/aspose.slides/shape/setalternativetext/)을 사용해 필요한 표를 검색하는 것이 좋습니다.  

5. [Table](https://reference.aspose.com/slides/ko/php-java/aspose.slides/Table) 객체를 사용해 표 작업을 수행합니다. 아래 예에서는 표에 새 행을 추가했습니다.  

6. 수정된 프레젠테이션을 저장합니다.  

이 PHP 코드는 기존 표에 접근하고 작업하는 방법을 보여줍니다:

```php
  # PPTX 파일을 나타내는 Presentation 클래스를 인스턴스화합니다
  $pres = new Presentation("UpdateExistingTable.pptx");
  try {
    # 첫 번째 슬라이드에 접근합니다
    $sld = $pres->getSlides()->get_Item(0);
    # null TableEx를 초기화합니다
    $tbl = null;
    # 도형을 반복하며 찾은 표에 대한 참조를 설정합니다
    foreach($sld->getShapes() as $shp) {
      if (java_instanceof($shp, new JavaClass("com.aspose.slides.Table"))) {
        $tbl = $shp;
        # 두 번째 행의 첫 번째 열에 텍스트를 설정합니다
        $tbl->get_Item(0, 1)->getTextFrame()->setText("New");
      }
    }
    # 수정된 프레젠테이션을 디스크에 저장합니다
    $pres->save("table1_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **표 안의 텍스트 정렬**

1. [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/Presentation) 클래스의 인스턴스를 생성합니다.  
2. 인덱스를 통해 슬라이드 참조를 가져옵니다.  
3. 슬라이드에 [Table](https://reference.aspose.com/slides/ko/php-java/aspose.slides/Table) 객체를 추가합니다.  
4. 표에서 [TextFrame](https://reference.aspose.com/slides/ko/php-java/aspose.slides/textframe/) 객체에 접근합니다.  
5. [Paragraph](https://reference.aspose.com/slides/ko/php-java/aspose.slides/paragraph/)에 접근합니다.  
6. 텍스트를 수직으로 정렬합니다.  
7. 수정된 프레젠테이션을 저장합니다.  

이 PHP 코드는 표 안의 텍스트를 정렬하는 방법을 보여줍니다:

```php
  # Presentation 클래스의 인스턴스를 생성합니다
  $pres = new Presentation();
  try {
    # 첫 번째 슬라이드를 가져옵니다
    $slide = $pres->getSlides()->get_Item(0);
    # 열 너비와 행 높이를 정의합니다
    $dblCols = array(120, 120, 120, 120 );
    $dblRows = array(100, 100, 100, 100 );
    # 슬라이드에 표 도형을 추가합니다
    $tbl = $slide->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    $tbl->get_Item(1, 0)->getTextFrame()->setText("10");
    $tbl->get_Item(2, 0)->getTextFrame()->setText("20");
    $tbl->get_Item(3, 0)->getTextFrame()->setText("30");
    # 텍스트 프레임에 접근합니다
    $txtFrame = $tbl->get_Item(0, 0)->getTextFrame();
    # 텍스트 프레임용 Paragraph 객체를 생성합니다
    $paragraph = $txtFrame->getParagraphs()->get_Item(0);
    # Paragraph용 Portion 객체를 생성합니다
    $portion = $paragraph->getPortions()->get_Item(0);
    $portion->setText("Text here");
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # 텍스트를 수직으로 정렬합니다
    $cell = $tbl->get_Item(0, 0);
    $cell->setTextAnchorType(TextAnchorType::Center);
    $cell->setTextVerticalType(TextVerticalType::Vertical270);
    # 프레젠테이션을 디스크에 저장합니다
    $pres->save("Vertical_Align_Text_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **표 수준에서 텍스트 서식 설정**

1. [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/Presentation) 클래스의 인스턴스를 생성합니다.  
2. 인덱스를 통해 슬라이드 참조를 가져옵니다.  
3. 슬라이드에서 [Table](https://reference.aspose.com/slides/ko/php-java/aspose.slides/Table) 객체에 접근합니다.  
4. 텍스트에 대해 [setFontHeight(float value)](https://reference.aspose.com/slides/ko/php-java/aspose.slides/baseportionformat/#setFontHeight)를 설정합니다.  
5. [setAlignment(int value)](https://reference.aspose.com/slides/ko/php-java/aspose.slides/paragraphformat/setalignment/) 및 [setMarginRight(float value)](https://reference.aspose.com/slides/ko/php-java/aspose.slides/paragraphformat/setmarginright/)을 설정합니다.  
6. [setTextVerticalType(byte value)](https://reference.aspose.com/slides/ko/php-java/aspose.slides/textframeformat/settextverticaltype/)을 설정합니다.  
7. 수정된 프레젠테이션을 저장합니다.  

이 PHP 코드는 표의 텍스트에 원하는 서식 옵션을 적용하는 방법을 보여줍니다:

```php
  # Presentation 클래스의 인스턴스를 생성합니다
  $pres = new Presentation("simpletable.pptx");
  try {
    # 첫 번째 슬라이드의 첫 번째 도형이 표라고 가정합니다
    $someTable = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    # 표 셀의 글꼴 높이를 설정합니다
    $portionFormat = new PortionFormat();
    $portionFormat::setFontHeight(25);
    $someTable->setTextFormat($portionFormat);
    # 표 셀의 텍스트 정렬과 오른쪽 여백을 한 번에 설정합니다
    $paragraphFormat = new ParagraphFormat();
    $paragraphFormat::setAlignment(TextAlignment->Right);
    $paragraphFormat::setMarginRight(20);
    $someTable->setTextFormat($paragraphFormat);
    # 표 셀의 텍스트 수직 유형을 설정합니다
    $textFrameFormat = new TextFrameFormat();
    $textFrameFormat::setTextVerticalType(TextVerticalType::Vertical);
    $someTable->setTextFormat($textFrameFormat);
    $pres->save("result.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **표 스타일 속성 가져오기**

Aspose.Slides를 사용하면 표의 스타일 속성을 가져와 다른 표나 다른 위치에 재사용할 수 있습니다. 이 PHP 코드는 표 프리셋 스타일에서 스타일 속성을 가져오는 방법을 보여줍니다:

```php
  $pres = new Presentation();
  try {
    $table = $pres->getSlides()->get_Item(0)->getShapes()->addTable(10, 10, array(100, 150 ), array(5, 5, 5 ));
    $table->setStylePreset(TableStylePreset->DarkStyle1);// 기본 스타일 프리셋 테마를 변경합니다

    $pres->save("table.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **표의 가로세로 비율 잠그기**

기하학적 도형의 가로세로 비율은 서로 다른 차원에서 크기의 비율을 의미합니다. Aspose.Slides는 [setAspectRatioLocked](https://reference.aspose.com/slides/ko/php-java/aspose.slides/graphicalobjectlock/setaspectratiolocked/) 메서드를 제공하여 표 및 기타 도형에 대한 가로세로 비율 잠금 설정을 할 수 있게 합니다.

이 PHP 코드는 표의 가로세로 비율을 잠그는 방법을 보여줍니다:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $table = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    echo("Lock aspect ratio set: " . $table->getGraphicalObjectLock()->getAspectRatioLocked());
    $table->getGraphicalObjectLock()->setAspectRatioLocked(!$table->getGraphicalObjectLock()->getAspectRatioLocked());// invert

    echo("Lock aspect ratio set: " . $table->getGraphicalObjectLock()->getAspectRatioLocked());
    $pres->save("pres-out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**전체 표와 셀 텍스트에 대해 오른쪽에서 왼쪽(RTL) 읽기 방향을 활성화할 수 있나요?**

예. 표는 [setRightToLeft](https://reference.aspose.com/slides/ko/php-java/aspose.slides/table/setrighttoleft/) 메서드를 제공하고, 단락은 [ParagraphFormat::setRightToLeft](https://reference.aspose.com/slides/ko/php-java/aspose.slides/paragraphformat/setrighttoleft/) 메서드를 제공합니다. 두 메서드를 모두 사용하면 셀 내부의 올바른 RTL 순서와 렌더링을 보장합니다.

**최종 파일에서 사용자가 표를 이동하거나 크기를 조정하지 못하도록 방지하려면 어떻게 해야 하나요?**

도형 잠금 기능을 사용하여 이동, 크기 조정, 선택 등을 비활성화할 수 있습니다. 이 잠금은 표에도 적용됩니다.

**셀 내부에 이미지를 배경으로 삽입할 수 있나요?**

예. 셀에 [picture fill](https://reference.aspose.com/slides/ko/php-java/aspose.slides/picturefillformat/)을 설정하면 선택한 모드(스트레치 또는 타일)에 따라 이미지가 셀 영역을 덮습니다.
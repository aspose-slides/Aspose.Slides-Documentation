---
title: JavaScript를 사용하여 PowerPoint 표의 행 및 열 관리
linktitle: 행 및 열
type: docs
weight: 20
url: /ko/nodejs-java/manage-rows-and-columns/
keywords:
- 표 행
- 표 열
- 첫 번째 행
- 표 헤더
- 행 복제
- 열 복제
- 행 복사
- 열 복사
- 행 제거
- 열 제거
- 행 텍스트 서식
- 열 텍스트 서식
- 표 스타일
- PowerPoint
- 프레젠테이션
- Node.js
- JavaScript
- Aspose.Slides
description: "JavaScript와 Node.js용 Aspose.Slides를 이용해 PowerPoint에서 표의 행과 열을 관리하고, Java를 통해 프레젠테이션 편집 및 데이터 업데이트를 빠르게 수행합니다."
---
## **소개**

PowerPoint 프레젠테이션에서 표의 행과 열을 관리할 수 있도록 Aspose.Slides는 [Table](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/table/) 클래스와 기타 유형을 제공합니다.

## **첫 번째 행을 헤더로 설정**

1. [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation/) 클래스의 인스턴스를 생성하고 프레젠테이션을 로드합니다.
2. 인덱스를 통해 슬라이드 참조를 가져옵니다.
3. [Table](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Table) 객체를 생성하고 null로 설정합니다.
4. 모든 [Shape](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/shape/) 객체를 반복하여 해당 표를 찾습니다.
5. 표의 첫 번째 행을 헤더로 설정합니다.

다음 JavaScript 코드는 표의 첫 번째 행을 헤더로 설정하는 방법을 보여줍니다:

```javascript
// 프레젠테이션 클래스를 인스턴스화합니다
var pres = new aspose.slides.Presentation("table.pptx");
try {
    // 첫 번째 슬라이드에 접근합니다
    var sld = pres.getSlides().get_Item(0);
    // null TableEx를 초기화합니다
    var tbl = null;
    // 셰이프들을 반복하면서 표에 대한 참조를 설정합니다
    for (let i = 0; i < sld.getShapes().size(); i++) {
        let shp = sld.getShapes().get_Item(i);
        if (java.instanceOf(shp, "com.aspose.slides.ITable")) {
            tbl = shp;
            // 표의 첫 번째 행을 헤더로 설정합니다
            tbl.setFirstRow(true);
        }
    }
    // 프레젠테이션을 디스크에 저장합니다
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **표 행 또는 열 복제**

1. [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation/) 클래스의 인스턴스를 생성하고 프레젠테이션을 로드합니다,
2. 인덱스를 통해 슬라이드 참조를 가져옵니다.
3. `columnWidth` 배열을 정의합니다.
4. `rowHeight` 배열을 정의합니다.
5. [addTable](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/shapecollection/#addTable-float-float-double---double---) 메서드를 사용하여 슬라이드에 [Table] 객체를 추가합니다.
6. 표 행을 복제합니다.
7. 표 열을 복제합니다.
8. 수정된 프레젠테이션을 저장합니다.

다음 JavaScript 코드는 PowerPoint 표의 행 또는 열을 복제하는 방법을 보여줍니다:

```javascript
// 프레젠테이션 클래스를 인스턴스화합니다
var pres = new aspose.slides.Presentation("Test.pptx");
try {
    // 첫 번째 슬라이드에 접근합니다
    var sld = pres.getSlides().get_Item(0);
    // 열 너비와 행 높이를 정의합니다
    var dblCols = java.newArray("double", [50, 50, 50]);
    var dblRows = java.newArray("double", [50, 30, 30, 30, 30]);
    // 슬라이드에 표 셰이프를 추가합니다
    var table = sld.getShapes().addTable(100, 50, dblCols, dblRows);
    // 1행 1셀에 텍스트를 추가합니다
    table.get_Item(0, 0).getTextFrame().setText("Row 1 Cell 1");
    // 1행 2셀에 텍스트를 추가합니다
    table.get_Item(1, 0).getTextFrame().setText("Row 1 Cell 2");
    // 표 끝에 1행을 복제합니다
    table.getRows().addClone(table.getRows().get_Item(0), false);
    // 2행 1셀에 텍스트를 추가합니다
    table.get_Item(0, 1).getTextFrame().setText("Row 2 Cell 1");
    // 2행 2셀에 텍스트를 추가합니다
    table.get_Item(1, 1).getTextFrame().setText("Row 2 Cell 2");
    // 표의 4번째 행으로 2행을 복제합니다
    table.getRows().insertClone(3, table.getRows().get_Item(1), false);
    // 마지막에 첫 번째 열을 복제합니다
    table.getColumns().addClone(table.getColumns().get_Item(0), false);
    // 4번째 열 인덱스에 두 번째 열을 복제합니다
    table.getColumns().insertClone(3, table.getColumns().get_Item(1), false);
    // 프레젠테이션을 디스크에 저장합니다
    pres.save("table_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **표에서 행 또는 열 제거**

1. [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation/) 클래스의 인스턴스를 생성하고 프레젠테이션을 로드합니다,
2. 인덱스를 통해 슬라이드 참조를 가져옵니다.
3. `columnWidth` 배열을 정의합니다.
4. `rowHeight` 배열을 정의합니다.
5. [addTable](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/shapecollection/#addTable-float-float-double---double---) 메서드를 사용하여 슬라이드에 [Table] 객체를 추가합니다.
6. 표 행을 제거합니다.
7. 표 열을 제거합니다.
8. 수정된 프레젠테이션을 저장합니다.

다음 JavaScript 코드는 표에서 행이나 열을 제거하는 방법을 보여줍니다:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var colWidth = java.newArray("double", [100, 50, 30]);
    var rowHeight = java.newArray("double", [30, 50, 30]);
    var table = slide.getShapes().addTable(100, 100, colWidth, rowHeight);
    table.getRows().removeAt(1, false);
    table.getColumns().removeAt(1, false);
    pres.save("TestTable_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **표 행 수준에서 텍스트 서식 지정**

1. [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation/) 클래스의 인스턴스를 생성하고 프레젠테이션을 로드합니다,
2. 인덱스를 통해 슬라이드 참조를 가져옵니다.
3. 슬라이드에서 해당 [Table] 객체에 접근합니다.
4. 첫 번째 행 셀의 [setFontHeight(float value)](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/baseportionformat/#setFontHeight-float-)을 설정합니다.
5. 첫 번째 행 셀의 [setAlignment(int value)](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) 및 [setMarginRight(float value)](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/paragraphformat/#setMarginRight-float-)을 설정합니다.
6. 두 번째 행 셀의 [setTextVerticalType(byte value)](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-)를 설정합니다.
7. 수정된 프레젠테이션을 저장합니다.

다음 JavaScript 코드는 이 작업을 보여줍니다.

```javascript
// Presentation 클래스의 인스턴스를 생성합니다
var pres = new aspose.slides.Presentation();
try {
    // 첫 번째 슬라이드의 첫 번째 셰이프가 표라고 가정합니다
    var someTable = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    // 첫 번째 행 셀의 글꼴 높이를 설정합니다
    var portionFormat = new aspose.slides.PortionFormat();
    portionFormat.setFontHeight(25);
    someTable.getRows().get_Item(0).setTextFormat(portionFormat);
    // 첫 번째 행 셀의 텍스트 정렬 및 오른쪽 여백을 설정합니다
    var paragraphFormat = new aspose.slides.ParagraphFormat();
    paragraphFormat.setAlignment(aspose.slides.TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    someTable.getRows().get_Item(0).setTextFormat(paragraphFormat);
    // 두 번째 행 셀의 텍스트 수직 유형을 설정합니다
    var textFrameFormat = new aspose.slides.TextFrameFormat();
    textFrameFormat.setTextVerticalType(aspose.slides.TextVerticalType.Vertical);
    someTable.getRows().get_Item(1).setTextFormat(textFrameFormat);
    // 프레젠테이션을 디스크에 저장합니다
    pres.save("result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **표 열 수준에서 텍스트 서식 지정**

1. [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation/) 클래스의 인스턴스를 생성하고 프레젠테이션을 로드합니다,
2. 인덱스를 통해 슬라이드 참조를 가져옵니다.
3. 슬라이드에서 해당 [Table] 객체에 접근합니다.
4. 첫 번째 열 셀의 [setFontHeight(float value)](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/baseportionformat/#setFontHeight-float-)을 설정합니다.
5. 첫 번째 열 셀의 [setAlignment(int value)](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) 및 [setMarginRight(float value)](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/paragraphformat/#setMarginRight-float-)을 설정합니다.
6. 두 번째 열 셀의 [setTextVerticalType(byte value)](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-)를 설정합니다.
7. 수정된 프레젠테이션을 저장합니다.

다음 JavaScript 코드는 이 작업을 보여줍니다:

```javascript
// Presentation 클래스의 인스턴스를 생성합니다
var pres = new aspose.slides.Presentation();
try {
    // 첫 번째 슬라이드의 첫 번째 셰이프가 표라고 가정합니다
    var someTable = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    // 첫 번째 열 셀의 글꼴 높이를 설정합니다
    var portionFormat = new aspose.slides.PortionFormat();
    portionFormat.setFontHeight(25);
    someTable.getColumns().get_Item(0).setTextFormat(portionFormat);
    // 첫 번째 열 셀의 텍스트 정렬 및 오른쪽 여백을 한 번에 설정합니다
    var paragraphFormat = new aspose.slides.ParagraphFormat();
    paragraphFormat.setAlignment(aspose.slides.TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    someTable.getColumns().get_Item(0).setTextFormat(paragraphFormat);
    // 두 번째 열 셀의 텍스트 수직 유형을 설정합니다
    var textFrameFormat = new aspose.slides.TextFrameFormat();
    textFrameFormat.setTextVerticalType(aspose.slides.TextVerticalType.Vertical);
    someTable.getColumns().get_Item(1).setTextFormat(textFrameFormat);
    pres.save("result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **표 스타일 속성 가져오기**

Aspose.Slides는 표의 스타일 속성을 검색할 수 있게 하며, 해당 세부 정보를 다른 표에 적용하거나 다른 곳에서 사용할 수 있습니다. 다음 JavaScript 코드는 표 사전 정의 스타일에서 스타일 속성을 가져오는 방법을 보여줍니다:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var table = pres.getSlides().get_Item(0).getShapes().addTable(10, 10, java.newArray("double", [100, 150]), java.newArray("double", [5, 5, 5]));
    table.setStylePreset(aspose.slides.TableStylePreset.DarkStyle1);// 기본 스타일 프리셋 테마를 변경합니다
    pres.save("table.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**이미 생성된 표에 PowerPoint 테마/스타일을 적용할 수 있나요?**

예. 표는 슬라이드/레이아웃/마스터 테마를 상속받으며, 해당 테마 위에 채우기, 테두리 및 텍스트 색을 언제든지 재정의할 수 있습니다.

**Excel처럼 표 행을 정렬할 수 있나요?**

아니요, Aspose.Slides 표에는 내장된 정렬이나 필터 기능이 없습니다. 먼저 메모리에서 데이터를 정렬한 다음, 그 순서대로 표 행을 다시 채워야 합니다.

**특정 셀에 사용자 지정 색상을 유지하면서 밴드(줄무늬) 열을 적용할 수 있나요?**

예. 밴드 열을 활성화한 뒤, 특정 셀에 로컬 서식을 적용하면 됩니다. 셀 수준 서식이 표 스타일보다 우선합니다.
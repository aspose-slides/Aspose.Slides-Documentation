---
title: Android에서 프레젠테이션의 표 셀 관리
linktitle: 셀 관리
type: docs
weight: 30
url: /ko/androidjava/manage-cells/
keywords:
- 표 셀
- 셀 병합
- 테두리 제거
- 셀 분할
- 셀 내 이미지
- 배경 색상
- PowerPoint
- 프레젠테이션
- Android
- Java
- Aspose.Slides
description: "Java를 사용한 Aspose.Slides for Android으로 PowerPoint에서 표 셀을 손쉽게 관리합니다. 셀에 접근·수정·스타일링을 빠르게 마스터하여 원활한 슬라이드 자동화를 실현하세요."
---
## **개요**

Aspose.Slides를 사용하면 PowerPoint 프레젠테이션에서 표 셀에 액세스하고 수정할 수 있습니다. 이 문서에서는 병합된 표 셀을 식별하는 방법, 셀 테두리를 제거하는 방법, 셀을 병합하거나 분할한 후 셀 번호 매기기를 처리하는 방법, 셀 배경색을 변경하는 방법, 그리고 표 셀 안에 이미지를 추가하는 방법을 설명합니다. 예제에서는 프레젠테이션을 만들거나 열고, 슬라이드에서 표를 가져오고, 셀 속성을 통해 셀 서식을 업데이트한 다음, 수정된 프레젠테이션을 PPTX 파일로 저장하는 과정을 보여줍니다.

## **병합된 테이블 셀 식별**
1. [Presentation](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/Presentation) 클래스의 인스턴스를 생성합니다.  
2. 첫 번째 슬라이드에서 테이블을 가져옵니다.  
3. 테이블의 행과 열을 반복하면서 병합된 셀을 찾습니다.  
4. 병합된 셀이 발견되면 메시지를 출력합니다.

This Java code shows you how to identify merged table cells in a presentation:

```java
Presentation pres = new Presentation("SomePresentationWithTable.pptx");
try {
    ITable table = (ITable)pres.getSlides().get_Item(0).getShapes().get_Item(0); // Slide#0.Shape#0이 표라고 가정합니다
    for (int i = 0; i < table.getRows().size(); i++)
    {
        for (int j = 0; j < table.getColumns().size(); j++)
        {
            ICell currentCell = table.getRows().get_Item(i).get_Item(j);
            if (currentCell.isMergedCell())
            {
                System.out.println(String.format("Cell %d;%d is a part of merged cell with RowSpan=%d and ColSpan=%d starting from Cell %d;%d.",
                        i, j, currentCell.getRowSpan(), currentCell.getColSpan(), currentCell.getFirstRowIndex(), currentCell.getFirstColumnIndex()));
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **표 셀 테두리 제거**
1. [Presentation](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/Presentation) 클래스의 인스턴스를 생성합니다.  
2. 인덱스를 통해 슬라이드의 참조를 가져옵니다.  
3. 너비가 지정된 열 배열을 정의합니다.  
4. 높이가 지정된 행 배열을 정의합니다.  
5. [addTable](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/IShapeCollection#addTable-float-float-double:A-double:A-) 메서드를 사용해 슬라이드에 표를 추가합니다.  
6. 각 셀을 순회하면서 위, 아래, 오른쪽, 왼쪽 테두리를 제거합니다.  
7. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

This Java code shows you how to remove the borders from table cells:

```java
// PPTX 파일을 나타내는 Presentation 클래스를 인스턴스화합니다
Presentation pres = new Presentation();
try {
    // 첫 번째 슬라이드에 접근합니다
    Slide sld = (Slide)pres.getSlides().get_Item(0);

    // 너비가 지정된 열과 높이가 지정된 행을 정의합니다
    double[] dblCols = { 50, 50, 50, 50 };
    double[] dblRows = { 50, 30, 30, 30, 30 };

    // 슬라이드에 표 형상을 추가합니다
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // 각 셀에 대한 테두리 형식을 설정합니다
    for (IRow row : tbl.getRows())
    {
        for (ICell cell : row)
        {
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.NoFill);
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.NoFill);
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.NoFill);
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.NoFill);
        }
    }

    // PPTX를 디스크에 저장합니다
    pres.save("table_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **병합된 셀의 번호 매기기**
2쌍의 셀 (1, 1) × (2, 1) 과 (1, 2) × (2, 2)를 병합하면 결과 표에 번호가 매겨집니다. 이 Java 코드는 해당 과정을 보여줍니다:

```java
// PPTX 파일을 나타내는 Presentation 클래스를 인스턴스화합니다
Presentation pres = new Presentation();
try {
    // 첫 번째 슬라이드에 접근합니다
    ISlide sld = pres.getSlides().get_Item(0);

    // 너비가 지정된 열과 높이가 지정된 행을 정의합니다
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // 슬라이드에 표 형상을 추가합니다
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // 각 셀에 대한 테두리 형식을 설정합니다
    for (IRow row : tbl.getRows())
    {
        for (ICell cell : row)
        {
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderTop().setWidth(5);

            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderBottom().setWidth(5);

            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderLeft().setWidth(5);

            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderRight().setWidth(5);
        }
    }

    // (1, 1) x (2, 1) 셀을 병합합니다
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(2, 1), false);

    // (1, 2) x (2, 2) 셀을 병합합니다
    tbl.mergeCells(tbl.get_Item(1, 2), tbl.get_Item(2, 2), false);

    pres.save("MergeCells_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

그 후 (1, 1)과 (1, 2)를 다시 병합합니다. 결과는 가운데에 큰 병합 셀이 있는 표가 됩니다:

```java
// PPTX 파일을 나타내는 Presentation 클래스를 인스턴스화합니다
Presentation pres = new Presentation();
try {
    // 첫 번째 슬라이드에 접근합니다
    ISlide sld = pres.getSlides().get_Item(0);

    // 너비가 지정된 열과 높이가 지정된 행을 정의합니다
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // 슬라이드에 표 형상을 추가합니다
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // 각 셀에 대한 테두리 형식을 설정합니다
    for (IRow row : tbl.getRows())
    {
        for (ICell cell : row)
        {
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderTop().setWidth(5);

            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderBottom().setWidth(5);

            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderLeft().setWidth(5);

            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderRight().setWidth(5);
        }
    }

    // (1, 1) x (2, 1) 셀을 병합합니다
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(2, 1), false);

    // (1, 2) x (2, 2) 셀을 병합합니다
    tbl.mergeCells(tbl.get_Item(1, 2), tbl.get_Item(2, 2), false);

    // (1, 1) x (1, 2) 셀을 병합합니다
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(1, 2), true);
    
	// PPTX 파일을 디스크에 저장합니다
    pres.save("MergeCells_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **분할된 셀의 번호 매기기**
이전 예제에서는 표 셀을 병합했을 때 다른 셀의 번호 매기기 체계가 변경되지 않았습니다.

이번에는 병합된 셀이 없는 일반 표를 사용한 다음 셀 (1,1)을 분할하여 특수한 표를 만들었습니다. 이 표의 번호 매기기가 이상하게 보일 수 있으니 주의하십시오. 그러나 이것이 Microsoft PowerPoint가 표 셀에 번호를 매기는 방식이며 Aspose.Slides도 동일하게 동작합니다.

This Java code demonstrates the process we described:

```java
// PPTX 파일을 나타내는 Presentation 클래스를 인스턴스화합니다
Presentation pres = new Presentation();
try {
    // 첫 번째 슬라이드에 접근합니다
    ISlide sld = pres.getSlides().get_Item(0);

    // 너비가 지정된 열과 높이가 지정된 행을 정의합니다
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // 슬라이드에 표 형상을 추가합니다
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // 각 셀에 대한 테두리 형식을 설정합니다
    for (IRow row : tbl.getRows())
    {
        for (ICell cell : row)
        {
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderTop().setWidth(5);

            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderBottom().setWidth(5);

            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderLeft().setWidth(5);

            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderRight().setWidth(5);
        }
    }

    // (1, 1) x (2, 1) 셀을 병합합니다
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(2, 1), false);

    // (1, 2) x (2, 2) 셀을 병합합니다
    tbl.mergeCells(tbl.get_Item(1, 2), tbl.get_Item(2, 2), false);

    // (1, 1) 셀을 분할합니다
    tbl.get_Item(1, 1).splitByWidth(tbl.get_Item(2, 1).getWidth() / 2);

    //PPTX 파일을 디스크에 저장합니다
    pres.save("SplitCells_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **표 셀 배경색 변경**

This Java code shows you how to change a table cell's background color:

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] dblCols = { 150, 150, 150, 150 };
    double[] dblRows = { 50, 50, 50, 50, 50 };

    // 새로운 표를 생성합니다
    ITable table = slide.getShapes().addTable(50, 50, dblCols, dblRows);

    // 셀의 배경색을 설정합니다
    ICell cell = table.get_Item(2, 3);
    cell.getCellFormat().getFillFormat().setFillType(FillType.Solid);
    cell.getCellFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);

    presentation.save("cell_background_color.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **표 셀 안에 이미지 추가**
1. [Presentation](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/Presentation) 클래스의 인스턴스를 생성합니다.  
2. 인덱스를 통해 슬라이드의 참조를 가져옵니다.  
3. 너비가 지정된 열 배열을 정의합니다.  
4. 높이가 지정된 행 배열을 정의합니다.  
5. [AddTable](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/IShapeCollection#addTable-float-float-double:A-double:A-) 메서드를 사용해 슬라이드에 표를 추가합니다.  
6. 이미지 파일을 보관할 `Images` 객체를 생성합니다.  
7. `IImage` 이미지를 `IPPImage` 객체에 추가합니다.  
8. 표 셀의 `FillFormat`을 `Picture`로 설정합니다.  
9. 이미지를 표의 첫 번째 셀에 추가합니다.  
10. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

This Java code shows you how to place an image inside a table cell when creating a table:

```java
// PPTX 파일을 나타내는 Presentation 클래스를 인스턴스화합니다
Presentation pres = new Presentation();
try {
    // 첫 번째 슬라이드에 접근합니다
    ISlide islide = pres.getSlides().get_Item(0);

    // 너비가 지정된 열과 높이가 지정된 행을 정의합니다
    double[] dblCols = {150, 150, 150, 150};
    double[] dblRows = {100, 100, 100, 100, 90};

    // 슬라이드에 표 형상을 추가합니다
    ITable tbl = islide.getShapes().addTable(50, 50, dblCols, dblRows);

    // 이미지 파일을 사용해 IPPImage 객체를 생성합니다
    IPPImage picture;
    IImage image = Images.fromFile("image.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // 이미지를 첫 번째 표 셀에 추가합니다
    ICellFormat cellFormat = tbl.get_Item(0, 0).getCellFormat();
    cellFormat.getFillFormat().setFillType(FillType.Picture);
    cellFormat.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
    cellFormat.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // PPTX 파일을 디스크에 저장합니다
    pres.save("Image_In_TableCell_out.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**단일 셀의 각 면에 대해 서로 다른 선 두께와 스타일을 설정할 수 있나요?**

네. [top](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/cellformat/#getBorderTop--)/[bottom](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/cellformat/#getBorderBottom--)/[left](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/cellformat/#getBorderLeft--)/[right](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/cellformat/#getBorderRight--) 테두리는 각각 별도의 속성을 가지고 있으므로 각 면의 두께와 스타일을 다르게 지정할 수 있습니다. 이는 문서에서 셀에 대한 면별 테두리 제어가 가능한 논리를 따릅니다.

**셀 배경에 그림을 설정한 후 열/행 크기를 변경하면 이미지가 어떻게 되나요?**

동작은 [fill mode](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/picturefillmode/) (stretch/tile)에 따라 달라집니다. Stretch 모드에서는 이미지가 새 셀 크기에 맞게 조정되고, Tile 모드에서는 타일이 다시 계산됩니다. 문서에는 셀 내 이미지 표시 모드에 대해 언급하고 있습니다.

**셀 전체 내용에 하이퍼링크를 지정할 수 있나요?**

[Hyperlinks](/slides/ko/androidjava/manage-hyperlinks/) 은 셀 텍스트 프레임 내 텍스트(구간) 수준 또는 전체 표/도형 수준에서 설정됩니다. 실제로는 구간에 링크를 지정하거나 셀 안의 전체 텍스트에 링크를 지정합니다.

**단일 셀 내에서 서로 다른 글꼴을 사용할 수 있나요?**

네. 셀의 텍스트 프레임은 [portions](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/portion/) (런)별로 독립적인 서식을 지원하므로 글꼴 종류, 스타일, 크기 및 색상을 개별적으로 설정할 수 있습니다.
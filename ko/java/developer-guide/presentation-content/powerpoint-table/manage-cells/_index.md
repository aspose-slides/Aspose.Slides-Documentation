---
title: Java를 사용하여 프레젠테이션에서 표 셀 관리
linktitle: 셀 관리
type: docs
weight: 30
url: /ko/java/manage-cells/
keywords:
- 표 셀
- 셀 병합
- 테두리 제거
- 셀 분할
- 셀 안의 이미지
- 배경 색상
- PowerPoint
- 프레젠테이션
- Java
- Aspose.Slides
description: "Java에서 PowerPoint 표 셀을 관리합니다: 병합된 셀을 식별하고, 테두리를 제거하며, 셀을 분할하고, Aspose.Slides for Java를 사용해 배경 색상 및 이미지를 설정합니다."
---
## **개요**

Aspose.Slides를 사용하면 PowerPoint 프레젠테이션의 표 셀에 접근하고 수정할 수 있습니다. 이 문서에서는 병합된 표 셀을 식별하는 방법, 셀 테두리를 제거하는 방법, 셀 병합 또는 분할 후 셀 번호 매기기를 관리하는 방법, 셀 배경색을 변경하는 방법, 표 셀 안에 이미지를 추가하는 방법을 설명합니다. 예제에서는 프레젠테이션을 생성하거나 열고, 슬라이드에서 표를 가져와 셀 속성을 통해 셀 서식을 업데이트하고, 수정된 프레젠테이션을 PPTX 파일로 저장하는 과정을 보여줍니다.

Aspose.Slides는 0부터 시작하는 인덱스를 사용하여 `(column, row)` 순서대로 표 셀에 접근합니다.

## **병합된 표 셀 식별**

예제는 기존 프레젠테이션을 열고 첫 번째 슬라이드의 첫 번째 도형을 표로서 접근합니다. 슬라이드와 도형이 존재하고 해당 도형이 표라는 전제하에 동작합니다. 그런 다음 모든 행과 열을 순회하면서 [isMergedCell](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#isMergedCell--)을 사용해 병합된 영역의 셀을 식별합니다. 일치하는 셀마다 `row;column` 순서로 셀 좌표와 [getRowSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getRowSpan--), [getColSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getColSpan--), 그리고 영역의 시작 좌표인 [getFirstRowIndex](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getFirstRowIndex--), [getFirstColumnIndex](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getFirstColumnIndex--)를 출력합니다.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation_with_table.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ITable table = (ITable) slide.getShapes().get_Item(0);

    int rowCount = table.getRows().size();
    for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
    {
        int columnCount = table.getColumns().size();
        for (int columnIndex = 0; columnIndex < columnCount; columnIndex++)
        {
            ICell cell = table.get_Item(columnIndex, rowIndex);
            if (cell.isMergedCell())
            {
                System.out.printf("Cell %d;%d belongs to a merged region with RowSpan=%d and ColSpan=%d starting at %d;%d.%n", rowIndex, columnIndex, cell.getRowSpan(), cell.getColSpan(), cell.getFirstRowIndex(), cell.getFirstColumnIndex());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **표 셀 테두리 제거**

[Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/)을 생성하고 [addTable](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---)을 사용해 첫 번째 슬라이드에 표를 추가합니다. 열 너비, 행 높이 및 표 위치는 포인트 단위로 지정됩니다. 예제에서는 모든 네 개의 셀 테두리를 [FillType.NoFill](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/)으로 설정하여 보이지 않게 합니다.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 50, 50, 50, 50 };
    double[] rowHeights = { 50, 30, 30, 30, 30 };
    ITable table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    for (IRow row : table.getRows())
        for (ICell cell : row)
        {
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.NoFill);
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.NoFill);
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.NoFill);
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.NoFill);
        }

    presentation.save("table.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **표 셀 병합**

[mergeCells](https://reference.aspose.com/slides/java/com.aspose.slides/itable/#mergeCells-com.aspose.slides.ICell-com.aspose.slides.ICell-boolean-)을 사용하여 표 셀의 직사각형 영역을 하나의 셀로 결합합니다. 영역의 왼쪽 위와 오른쪽 아래 셀을 지정합니다. 마지막 인자는 병합이 지정된 범위 밖의 셀을 포함할 수 있는지를 제어하며, `false`는 병합을 해당 범위 내에만 유지합니다.

예제에서는 열과 행이 70포인트인 4×4 표를 만든 다음 `(1, 1)`부터 `(2, 2)`까지의 네 개 중앙 셀을 병합합니다. 결과 셀은 두 열과 두 행을 차지하지만 표의 기본 그리드는 여전히 네 열과 네 행을 유지합니다. 병합된 셀의 내용이나 서식에 접근하려면 왼쪽 위 위치인 `table.get_Item(1, 1)`을 사용합니다. 병합 영역의 다른 위치는 여전히 표 그리드의 일부이므로 범위 밖 셀의 인덱스는 변경되지 않습니다.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 70, 70, 70, 70 };
    double[] rowHeights = { 70, 70, 70, 70 };
    ITable table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    table.mergeCells(table.get_Item(1, 1), table.get_Item(2, 2), false);

    presentation.save("merged_cells.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **표 셀 분할**

앞 예제에서 셀을 병합하면 표 그리드가 유지됩니다. 셀을 분할하면 새로운 그리드 열이 생기고 오른쪽 셀들의 열 인덱스가 변경될 수 있습니다. Aspose.Slides는 PowerPoint의 표 그리드 모델을 따릅니다.

예제에서는 열과 행이 70포인트인 4×4 표를 만든 후 셀 `(1, 1)`에 대해 [splitByWidth](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#splitByWidth-double-)을 호출합니다. 셀 너비 70포인트의 절반을 전달하여 두 개의 동일한 너비 셀을 생성합니다.

분할 후 두 부분은 각각 `table.get_Item(1, 1)`과 `table.get_Item(2, 1)`으로 접근합니다. 이제 표 그리드에는 다섯 개의 열이 있으며, 원래 2열과 3열에 있던 셀은 각각 3열과 4열로 이동합니다. 행 인덱스는 변하지 않으며, 분할 후 셀에 접근할 때는 업데이트된 열 인덱스를 사용해야 합니다.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 70, 70, 70, 70 };
    double[] rowHeights = { 70, 70, 70, 70 };
    ITable table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    table.get_Item(1, 1).splitByWidth(table.get_Item(1, 1).getWidth() / 2);

    presentation.save("split_cells.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **행 또는 열 스팬으로 병합된 셀 분할**

데이터 채우기를 위해 병합된 템플릿 셀을 준비하려면 기존 행 경계에 따라 분할하는 [splitByRowSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#splitByRowSpan-int-)을, 열 경계에 따라 분할하는 [splitByColSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#splitByColSpan-int-)을 사용합니다.

`index` 인자는 분할된 상단 부분의 행 수 또는 왼쪽 부분의 열 수를 나타내며, 병합 영역에 상대적입니다:

- 행 분할: `0 < index <` [getRowSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getRowSpan--).
- 열 분할: `0 < index <` [getColSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getColSpan--).

예제는 첫 번째 슬라이드의 첫 번째 도형이 표이며, `(1, 2)`와 `(1, 3)`이 수직으로 병합되어 있다고 가정합니다. 아래쪽 위치에서 시작하여 [getFirstColumnIndex](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getFirstColumnIndex--)와 [getFirstRowIndex](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getFirstRowIndex--)을 사용해 시작점을 찾고 두 스팬을 확인합니다. `splitByRowSpan(1)`은 제품 이름을 위해 2행과 3행을 분리합니다. 가로 두 열 병합의 경우에는 `splitByColSpan(1)`을 사용합니다.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("table_template.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ITable table = (ITable) slide.getShapes().get_Item(0);

    ICell selectedCell = table.get_Item(1, 3);
    int firstColumnIndex = selectedCell.getFirstColumnIndex();
    int firstRowIndex = selectedCell.getFirstRowIndex();
    ICell mergedCell = table.get_Item(firstColumnIndex, firstRowIndex);

    if (mergedCell.isMergedCell() && mergedCell.getRowSpan() == 2 && mergedCell.getColSpan() == 1)
    {
        mergedCell.splitByRowSpan(1);

        // 분할 후 표에서 결과 셀을 가져옵니다.
        ICell upperCell = table.get_Item(firstColumnIndex, firstRowIndex);
        ICell lowerCell = table.get_Item(firstColumnIndex, firstRowIndex + 1);
        System.out.println("Upper cell merged: " + upperCell.isMergedCell());
        System.out.println("Lower cell merged: " + lowerCell.isMergedCell());

        upperCell.getTextFrame().setText("Product A");
        lowerCell.getTextFrame().setText("Product B");

        presentation.save("split_template.pptx", SaveFormat.Pptx);
    }
    else
    {
        System.out.println("Select a merged region spanning exactly two rows and one column.");
    }
} finally {
    presentation.dispose();
}
```

표 그리드와 주변 셀 인덱스는 변경되지 않습니다. 결과 셀을 좌표로 가져오면 두 셀 모두 스팬이 1이며 [isMergedCell](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#isMergedCell--)은 `false`를 반환합니다. 한 번 분할 후에도 더 큰 영역은 일부가 병합된 상태로 남을 수 있습니다.

원본 텍스트와 서식은 상위(또는 왼쪽) 셀에 그대로 남고, 새 셀은 비어 있지만 채우기, 테두리, 여백 등 셀 서식을 상속합니다. 분할 후 셀에 데이터를 채우고 필요한 텍스트 서식을 명시적으로 설정하십시오.

저장된 프레젠테이션에는 템플릿의 셀 서식이 유지된 채 별개의 "Product A" 및 "Product B" 셀이 포함됩니다. 자세한 내용은 [Cell API Reference](https://reference.aspose.com/slides/java/com.aspose.slides/cell/)를 참조하십시오.

## **표 셀 배경색 변경**

예제에서는 열이 150포인트, 행이 50포인트인 표를 생성합니다. [setFillType](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#setFillType-byte-)을 사용해 단색 채우기를 선택하고, [getSolidFillColor](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#getSolidFillColor--)이 반환하는 색을 빨간색으로 설정하여 셀 `(2, 3)`(세 번째 열, 네 번째 행)에 적용합니다.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 150, 150, 150, 150 };
    double[] rowHeights = { 50, 50, 50, 50, 50 };
    ITable table = slide.getShapes().addTable(50, 50, columnWidths, rowHeights);

    ICell cell = table.get_Item(2, 3);
    cell.getCellFormat().getFillFormat().setFillType(FillType.Solid);
    cell.getCellFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);

    presentation.save("cell_background_color.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **표 셀 안에 이미지 추가**

예제를 실행하기 전에 입력 이미지를 작업 디렉터리에 배치합니다. 이미지를 [Images.fromFile](https://reference.aspose.com/slides/java/com.aspose.slides/images/#fromFile-java.lang.String-)으로 로드하고 [addImage](https://reference.aspose.com/slides/java/com.aspose.slides/iimagecollection/#addImage-com.aspose.slides.IImage-)을 사용해 프레젠테이션의 이미지 컬렉션에 추가합니다. 그런 다음 이미지를 표의 첫 번째 셀인 `(0, 0)`의 그림 채우기로 할당합니다.

[PictureFillMode.Stretch](https://reference.aspose.com/slides/java/com.aspose.slides/picturefillmode/)은 이미지를 셀에 맞게 스트레치하여 비율이 변경될 수 있습니다. 열 너비와 행 높이는 포인트 단위입니다. 로드된 이미지는 프레젠테이션에 추가된 후 `finally` 블록에서 해제됩니다.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    
    double[] columnWidths = { 150, 150, 150, 150 };
    double[] rowHeights = { 100, 100, 100, 100, 90 };
    ITable table = slide.getShapes().addTable(50, 50, columnWidths, rowHeights);

    IPPImage ppImage;
    IImage image = Images.fromFile("aspose_logo.jpg");
    try {
        ppImage = presentation.getImages().addImage(image);
    } finally {
        image.dispose();
    }

    table.get_Item(0, 0).getCellFormat().getFillFormat().setFillType(FillType.Picture);
    table.get_Item(0, 0).getCellFormat().getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
    table.get_Item(0, 0).getCellFormat().getFillFormat().getPictureFillFormat().getPicture().setImage(ppImage);

    presentation.save("table_cell_with_image.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**단일 셀의 각 면에 대해 서로 다른 선 두께와 스타일을 설정할 수 있나요?**

예. [top](https://reference.aspose.com/slides/java/com.aspose.slides/cellformat/#getBorderTop--), [bottom](https://reference.aspose.com/slides/java/com.aspose.slides/cellformat/#getBorderBottom--), [left](https://reference.aspose.com/slides/java/com.aspose.slides/cellformat/#getBorderLeft--), [right](https://reference.aspose.com/slides/java/com.aspose.slides/cellformat/#getBorderRight--) 테두리는 각각 별도 속성을 가지고 있어 각 면의 두께와 스타일을 다르게 지정할 수 있습니다.

**셀의 배경으로 그림을 설정한 후 열/행 크기를 변경하면 이미지가 어떻게 되나요?**

동작은 [fill mode](https://reference.aspose.com/slides/java/com.aspose.slides/picturefillmode/)에 따라 다릅니다. 스트레치 모드에서는 이미지가 새 셀 크기에 맞게 조정되고, 타일 모드에서는 타일이 다시 계산됩니다.

**셀의 전체 내용에 하이퍼링크를 지정할 수 있나요?**

[Hyperlinks](/slides/ko/java/manage-hyperlinks/)은 셀 텍스트 프레임 내 텍스트(구간) 수준이나 전체 표/도형 수준에서 설정됩니다. 실제로는 구간에 하이퍼링크를 지정하거나 셀의 모든 텍스트에 할당합니다.

**단일 셀 안에서 서로 다른 글꼴을 설정할 수 있나요?**

예. 셀의 텍스트 프레임은 [portions](https://reference.aspose.com/slides/java/com.aspose.slides/portion/) (런)별로 독립적인 서식(글꼴 종류, 스타일, 크기, 색상)을 지원합니다.
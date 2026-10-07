---
title: Android에서 프레젠테이션의 테이블 셀 관리
linktitle: 셀 관리
type: docs
weight: 30
url: /ko/androidjava/manage-cells/
keywords:
- 테이블 셀
- 셀 병합
- 테두리 제거
- 셀 분할
- 셀 내 이미지
- 배경 색
- PowerPoint
- 프레젠테이션
- Android
- Java
- Aspose.Slides
description: "Android에서 PowerPoint 테이블 셀을 관리합니다: 병합된 셀 식별, 테두리 제거, 셀 분할, 그리고 Aspose.Slides for Android를 Java로 사용하여 배경 색 및 이미지를 설정합니다."
---
## **개요**

Aspose.Slides를 사용하면 PowerPoint 프레젠테이션에서 테이블 셀에 액세스하고 수정할 수 있습니다. 이 문서에서는 병합된 테이블 셀을 식별하는 방법, 셀 테두리를 제거하는 방법, 셀을 병합하거나 분할한 후 셀 번호를 처리하는 방법, 셀의 배경 색을 변경하는 방법, 그리고 테이블 셀 내부에 이미지를 추가하는 방법을 설명합니다. 예제에서는 프레젠테이션을 생성하거나 열고, 슬라이드에서 테이블을 가져오며, 셀 속성을 통해 셀 서식을 업데이트하고, 수정된 프레젠테이션을 PPTX 파일로 저장하는 방법을 보여 줍니다.

Aspose.Slides는 테이블 셀에 접근할 때 `(column, row)` 순서의 0부터 시작하는 인덱스를 사용합니다.

## **병합된 테이블 셀 식별**

예제는 기존 프레젠테이션을 열고 첫 번째 슬라이드의 첫 번째 도형을 테이블로 접근합니다. 슬라이드와 도형이 존재하며 해당 도형이 테이블이라고 가정합니다. 그 다음 모든 행과 열을 순회하면서 [isMergedCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#isMergedCell--) 메서드를 사용해 병합된 영역의 셀을 식별합니다. 일치하는 각각의 경우, `row;column` 순서로 셀 좌표와 [getRowSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getRowSpan--), [getColSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getColSpan--), 그리고 영역 시작 좌표인 [getFirstRowIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getFirstRowIndex--) 및 [getFirstColumnIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getFirstColumnIndex--)를 출력합니다.

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

## **테이블 셀 테두리 제거**

우선 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/)을 생성하고 [addTable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---) 메서드를 사용해 첫 번째 슬라이드에 테이블을 추가합니다. 열 너비, 행 높이 및 테이블 위치는 포인트 단위로 지정됩니다. 예제에서는 네 개의 셀 테두리를 모두 [FillType.NoFill](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/)으로 설정하여 보이지 않게 합니다.

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

## **테이블 셀 병합**

[mergeCells](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/#mergeCells-com.aspose.slides.ICell-com.aspose.slides.ICell-boolean-) 메서드를 사용해 직사각형 영역의 테이블 셀을 하나의 셀로 결합합니다. 범위의 좌측 상단 셀과 우측 하단 셀을 지정합니다. 마지막 인자는 병합이 지정된 범위 외의 셀을 포함할지 여부를 제어하며, `false`는 범위 내에서만 병합하도록 합니다.

예제에서는 70포인트 열과 행을 가진 4×4 테이블을 만든 뒤 `(1, 1)`부터 `(2, 2)`까지 네 개의 중앙 셀을 병합합니다. 결과 셀은 두 열과 두 행을 차지하지만, 테이블의 기본 그리드는 여전히 네 열과 네 행을 유지합니다. 병합된 셀의 내용이나 서식에 접근하려면 이 예제에서는 `table.get_Item(1, 1)`을 사용합니다. 병합 범위 외에 있는 셀 위치는 변경되지 않습니다.

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

## **테이블 셀 분할**

이전 예제에서 셀을 병합하면 테이블 그리드가 유지됩니다. 셀을 분할하면 새 그리드 열이 추가될 수 있으며, 오른쪽에 있는 셀들의 열 인덱스가 변경될 수 있습니다. Aspose.Slides는 PowerPoint의 테이블 그리드 모델을 따릅니다.

이 예제는 70포인트 열과 행을 가진 4×4 테이블을 만든 뒤 셀 `(1, 1)`에 대해 [splitByWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#splitByWidth-double-) 메서드를 호출합니다. 셀의 70포인트 너비 절반을 전달하여 두 개의 동일한 너비 셀을 만들도록 합니다.

분할 후 두 절반은 각각 `table.get_Item(1, 1)` 및 `table.get_Item(2, 1)`으로 접근합니다. 테이블 그리드는 이제 다섯 열을 갖게 되며, 원래 2열과 3열에 있던 셀은 각각 3열과 4열로 이동합니다. 행 인덱스는 그대로 유지됩니다. 분할 후 셀에 접근할 때는 업데이트된 열 인덱스를 사용하세요.

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

### **행 또는 열 Span으로 병합된 셀 분할**

데이터를 채우기 위해 병합된 템플릿 셀을 준비하려면 기존 행 경계에 따라 분할하는 [splitByRowSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#splitByRowSpan-int-)를 사용하거나, 열 경계에 따라 분할하는 [splitByColSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#splitByColSpan-int-)를 사용합니다.

`index` 매개변수는 분할된 영역의 상단 부분에 있는 행 또는 왼쪽 부분에 있는 열의 개수를 나타내며, 병합된 영역을 기준으로 상대적인 값입니다:

- 행 분할: `0 < index <` [getRowSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getRowSpan--).
- 열 분할: `0 < index <` [getColSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getColSpan--).

예제에서는 프레젠테이션의 첫 번째 슬라이드 첫 번째 도형이 테이블이며 `(1, 2)`와 `(1, 3)`이 수직으로 병합되어 있다고 가정합니다. 하단 위치에서 시작하여 [getFirstColumnIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getFirstColumnIndex--)와 [getFirstRowIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getFirstRowIndex--)를 사용해 기준을 찾고 두 스팬을 확인합니다. `splitByRowSpan(1)`은 제품 이름을 위한 행 2와 3을 분리합니다. 가로 두 열 병합의 경우 대신 `splitByColSpan(1)`을 사용합니다.

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

        // 분할 후 테이블에서 결과 셀을 가져옵니다.
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

테이블 그리드와 주변 셀 인덱스는 변경되지 않습니다. 좌표를 통해 결과 셀을 가져오면 여기서는 두 셀 모두 스팬이 1이며 [isMergedCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#isMergedCell--)은 `false`를 반환합니다. 하나의 분할 후에도 더 큰 영역이 부분적으로 병합된 상태로 남을 수 있습니다.

원본 텍스트와 서식은 상단(또는 좌측) 셀에 남고, 새 셀은 비어 있지만 채우기, 테두리, 여백 등 셀 서식을 상속합니다. 분할 후 셀에 데이터를 채우고 필요한 텍스트 서식을 명시적으로 설정하세요.

저장된 프레젠테이션에는 템플릿 셀 서식이 유지된 상태에서 별도의 "Product A"와 "Product B" 셀을 확인할 수 있습니다. 자세한 내용은 [Cell API Reference](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cell/)를 참조하세요.

## **테이블 셀 배경 색 변경**

이 예제에서는 150포인트 열과 50포인트 행을 가진 테이블을 생성합니다. [setFillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#setFillType-byte-) 메서드를 사용해 단색 채우기를 선택하고, [getSolidFillColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#getSolidFillColor--)이 반환하는 색을 빨간색으로 지정하여 `(2, 3)` 셀(세 번째 열, 네 번째 행)의 배경을 설정합니다.

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

## **테이블 셀 내부에 이미지 추가**

예제를 실행하기 전에 입력 이미지를 작업 디렉터리에 배치하세요. 이미지는 [Images.fromFile](https://reference.aspose.com/slides/androidjava/com.aspose.slides/images/#fromFile-java.lang.String-) 로 로드한 뒤 [addImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagecollection/#addImage-com.aspose.slides.IImage-) 로 프레젠테이션의 이미지 컬렉션에 추가합니다. 그런 다음 이미지를 테이블 첫 번째 셀인 `(0, 0)`의 그림 채우기로 할당합니다.

[PictureFillMode.Stretch](https://reference.aspose.com/slides/androidjava/com.aspose.slides/picturefillmode/) 은 이미지를 셀 전체에 맞게 늘려서 채우므로 가로세로 비율이 변경될 수 있습니다. 열 너비와 행 높이는 포인트 단위입니다. 로드된 이미지는 프레젠테이션에 추가된 후 `finally` 블록에서 해제됩니다.

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

**단일 셀의 각 면에 대해 서로 다른 선 두께와 스타일을 설정할 수 있습니까?**

네. [top](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cellformat/#getBorderTop--)/[bottom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cellformat/#getBorderBottom--)/[left](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cellformat/#getBorderLeft--)/[right](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cellformat/#getBorderRight--) 테두리는 각각 별도의 속성을 가지고 있어 각 면의 두께와 스타일을 다르게 지정할 수 있습니다.

**셀 배경에 그림을 지정한 뒤 열/행 크기를 변경하면 이미지가 어떻게 됩니까?**

동작은 [fill mode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/picturefillmode/) (stretch/tile)에 따라 달라집니다. stretch인 경우 이미지가 새로운 셀 크기에 맞게 조정되고, tile인 경우 타일이 다시 계산됩니다.

**셀 전체 내용에 하이퍼링크를 지정할 수 있습니까?**

[Hyperlinks](/slides/ko/androidjava/manage-hyperlinks/) 은 셀의 텍스트 프레임 내부 텍스트(포션) 수준이나 전체 테이블/도형 수준에서 설정됩니다. 실제로는 셀 내의 특정 포션이나 전체 텍스트에 링크를 할당합니다.

**단일 셀 내에서 서로 다른 글꼴을 설정할 수 있습니까?**

네. 셀의 텍스트 프레임은 [portions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/portion/) (런) 를 지원하며, 각 포션은 글꼴 패밀리, 스타일, 크기 및 색상 등 독립적인 서식을 가질 수 있습니다.
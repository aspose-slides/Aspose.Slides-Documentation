---
title: PPTX에서 차트 크기 조정에 대한 실용적인 해결책
type: docs
weight: 40
url: /ko/java/working-solution-for-chart-resizing-in-pptx/
keywords:
- 차트 크기 조정
- Excel 차트
- OLE 개체
- 차트 임베드
- PowerPoint
- 프레젠테이션
- Java
- Aspose.Slides
description: "Aspose.Slides for Java를 사용하여 임베드된 Excel OLE 개체와 함께 PPTX에서 발생하는 예상치 못한 차트 크기 변화를 수정합니다. 차트와 OLE 프레임 크기를 일관되게 유지하기 위해 고정 차트 차원을 설정합니다."
---
## **배경**

Excel 차트를 Aspose 구성 요소를 사용하여 PowerPoint 프레젠테이션에 OLE 개체로 삽입하면 첫 번째 활성화 후 크기가 변경될 수 있습니다. 이로 인해 차트가 활성화 전후에 눈에 띄게 달라 보일 수 있습니다. 이 문서는 크기 조정이 발생하는 이유를 설명하고 고정 차트 차원을 OLE 프레임에 맞춰 지정함으로써 이를 방지하는 방법을 보여줍니다.

In [프레젠테이션에 OLE 개체로 Excel 차트를 생성하고 삽입하기](/slides/ko/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/), 우리는 Aspose.Cells for Java를 사용하여 Excel 차트를 만들고 Aspose.Slides for Java를 사용하여 PowerPoint 프레젠테이션에 삽입하는 방법을 설명했습니다. [객체 미리 보기 문제](/slides/ko/java/object-preview-issue-when-adding-oleobjectframe/)를 해결하기 위해 차트 이미지를 차트의 OLE 개체 프레임에 할당했습니다. 출력 프레젠테이션에서 차트 이미지를 표시하는 OLE 개체 프레임을 두 번 클릭하면 Excel 차트가 활성화됩니다. 사용자는 삽입된 Excel 통합 문서를 편집한 다음 활성화된 통합 문서 밖을 클릭하여 슬라이드로 돌아갈 수 있습니다. 사용자가 슬라이드로 돌아올 때 OLE 개체 프레임의 크기가 변하며, 크기 조정 비율은 OLE 개체 프레임과 삽입된 Excel 통합 문서의 원래 크기에 따라 달라집니다.

## **크기 조정 원인**

삽입된 Excel 통합 문서는 자체 창 크기를 가지고 있으며, Excel은 개체가 처음 활성화될 때 이 창 크기를 유지하려고 시도합니다. 슬라이드의 OLE 프레임은 별도로 정의된 크기를 갖습니다. Excel 통합 문서가 활성화되면 Excel과 PowerPoint는 임베딩 과정의 일환으로 개체의 비율을 유지하기 위해 크기를 협상합니다. 따라서 통합 문서 창과 OLE 프레임 사이의 차이가 개체를 크기 조정하게 만들 수 있습니다.

## **작동 솔루션**

차트 크기를 슬라이드의 OLE 프레임에 맞추고 차트 차원을 통합 문서 창과 독립적으로 유지합니다. 이 솔루션은 새 프레젠테이션이나 기존 템플릿 모두에 적용됩니다.

예제는 Aspose.Cells for Java 및 Aspose.Slides for Java가 필요합니다. 활성 차트 시트에 간단한 컬럼 차트를 만들고 통합 문서를 XLS 형식으로 임베드합니다. 차트 미리 보기 이미지는 지정하지 않으며, 차트는 PowerPoint에서 OLE 개체가 활성화될 때 표시됩니다.

예제는 왼쪽 가장자리에서 0.5인치, 위쪽에서 1인치 떨어진 위치에 9.5 × 4인치 OLE 프레임을 배치한 새 프레젠테이션을 생성합니다. 슬라이드 좌표와 크기는 포인트(인치당 72포인트) 단위입니다. 기존 프레젠테이션에 적용하려면 [템플릿 사용](#use-a-template)을 참조하세요.

```java
import com.aspose.cells.Chart;
import com.aspose.cells.ChartType;
import com.aspose.cells.FileFormatType;
import com.aspose.cells.PrintSizeType;
import com.aspose.cells.SheetType;
import com.aspose.cells.Workbook;
import com.aspose.cells.Worksheet;
import com.aspose.slides.ISlide;
import com.aspose.slides.OleEmbeddedDataInfo;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.ByteArrayOutputStream;

Workbook workbook = new Workbook();
try {
    Worksheet dataSheet = workbook.getWorksheets().get(0);
    dataSheet.setName("Data");
    dataSheet.getCells().get("A1").putValue(10);
    dataSheet.getCells().get("A2").putValue(20);

    int chartSheetIndex = workbook.getWorksheets().add(SheetType.CHART);
    Worksheet chartSheet = workbook.getWorksheets().get(chartSheetIndex);
    int chartIndex = chartSheet.getCharts().add(ChartType.COLUMN, 0, 0, 20, 10);
    Chart chart = chartSheet.getCharts().get(chartIndex);
    chart.getNSeries().add("Data!A1:A2", true);
    workbook.getWorksheets().setActiveSheetIndex(chartSheetIndex);

    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // 슬라이드 좌표와 크기는 포인트 단위입니다 (인치당 72포인트).
        float width = 684f; // 9.5인치.
        float height = 288f; // 4인치.

        chart.setSizeWithWindow(false);
        // 포인트를 차트 픽셀로 변환합니다 (인치당 96픽셀 사용).
        chart.getChartObject().setWidth((int)(width / 72f * 96f));
        chart.getChartObject().setHeight((int)(height / 72f * 96f));
        chart.setPrintSize(PrintSizeType.CUSTOM);

        ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
        workbook.save(workbookStream, FileFormatType.EXCEL_97_TO_2003);
        OleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(workbookStream.toByteArray(), "xls");
        slide.getShapes().addOleObjectFrame(36, 72, width, height, dataInfo);

        presentation.save("chart-fixed-size.pptx", SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
} finally {
    workbook.dispose();
}
```

## **고정 차트 크기 설정**

[setSizeWithWindow](https://reference.aspose.com/cells/java/com.aspose.cells/chart/#setSizeWithWindow-boolean-)을 false 로 설정하여 차트 차원이 통합 문서 창과 독립적이도록 합니다. [getChartObject](https://reference.aspose.com/cells/java/com.aspose.cells/chart/#getChartObject--)의 차원은 [setWidth](https://reference.aspose.com/cells/java/com.aspose.cells/shape/#setWidth-int-)와 [setHeight](https://reference.aspose.com/cells/java/com.aspose.cells/shape/#setHeight-int-)를 사용해 설정하고, 96픽셀/인치를 기준으로 포인트를 픽셀로 변환합니다: 684 × 288 포인트 프레임은 912 × 384 픽셀 차트에 해당합니다. [setPrintSize](https://reference.aspose.com/cells/java/com.aspose.cells/chart/#setPrintSize-int-)을 [PrintSizeType](https://reference.aspose.com/cells/java/com.aspose.cells/printsizetype/)의 CUSTOM 값으로 설정합니다. 예제는 [addOleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addOleObjectFrame-float-float-float-float-com.aspose.slides.IOleEmbeddedDataInfo-)을 사용해 통합 문서를 임베드하고, 9.5 × 4인치 OLE 프레임을 가진 프레젠테이션을 저장합니다.

## **템플릿 사용**

기존 프레젠테이션에서도 동일한 크기 논리를 적용합니다. 예제를 수정하려면:

1. 빈 프레젠테이션을 생성하는 대신 템플릿 프레젠테이션을 로드합니다.
2. 첫 번째 슬라이드에 최소 세 개의 도형이 있는지 확인한 뒤, 인덱스 2에 있는 도형을 자리표시자로 사용합니다.
3. 고정값 684와 288 대신 해당 도형에서 프레임 너비와 높이를 가져옵니다. 크기 계산은 그대로 유지합니다.
4. 고정 좌표 36과 72 대신 자리표시자 위치에 OLE 프레임을 추가합니다.
5. 프레젠테이션을 저장하기 전에 자리표시자를 제거합니다.

## **FAQ**

**PowerPoint에서 Excel 차트를 활성화한 후 크기가 변경되는 이유는 무엇인가요?**  
Excel이 처음 활성화될 때 원래 창 크기를 복원하려고 시도하고, PowerPoint의 OLE 개체 프레임은 자체 차원을 갖기 때문에 두 프로그램이 비율을 유지하려고 협상하면서 크기 조정이 발생합니다.

**차트와 OLE 프레임 크기를 일관되게 유지하려면 어떻게 해야 하나요?**  
OLE 프레임에 맞는 고정 차트 차원을 설정하고, 워크북을 임베드하기 전에 사용자 지정 차트 인쇄 크기를 사용합니다. 위 예제에서 필요한 설정과 단위 변환을 확인할 수 있습니다.

**워크북 창 크기만 맞추면 충분한가요?**  
워크북 창 크기만 맞추어도 OLE 프레임이 활성화 후 크기가 변하는 것을 안정적으로 방지할 수 없습니다. 예제와 같이 고정 차트 차원을 사용해야 합니다.

**이 솔루션은 템플릿 기반 프레젠테이션과 새 프레젠테이션 모두에 적용되나요?**  
예. 템플릿의 경우 자리표시자 차원과 위치를 사용하고, 새 프레젠테이션의 경우 프레임 차원과 위치를 직접 지정합니다.

**다른 스프레드시트 프로그램으로 만든 차트에도 이 예제를 사용할 수 있나요?**  
예제는 Aspose.Cells로 만든 Excel 통합 문서를 사용합니다. 다른 스프레드시트 프로그램의 활성화 동작은 보여주지 않습니다.

## **관련 섹션**

- [프레젠테이션에 OLE 개체로 Excel 차트를 생성하고 삽입하기](/slides/ko/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)
---
title: "PPTX에서 차트 크기 조정을 위한 작업 솔루션"
type: docs
weight: 40
url: /ko/androidjava/working-solution-for-chart-resizing-in-pptx/
keywords:
- 차트 크기 조정
- Excel 차트
- OLE 개체
- 차트 삽입
- PowerPoint
- 프레젠테이션
- Android
- Java
- Aspose.Slides
description: "Java를 통해 Android용 Aspose.Slides와 함께 삽입된 Excel OLE 개체를 사용할 때 PPTX에서 발생하는 예상치 못한 차트 크기 변화를 해결합니다. 차트와 OLE 프레임 크기를 일관되게 유지하려면 차트 차원을 고정하십시오."
---
## **개요**

Aspose 구성 요소를 사용하여 PowerPoint 프레젠테이션에 OLE 개체로 삽입된 Excel 차트는 첫 번째 활성화 후 크기가 변할 수 있습니다. 이는 차트가 활성화 전후의 모양 차이가 눈에 띄게 나타날 수 있습니다. 이 문서에서는 크기 변경이 발생하는 이유를 설명하고 고정된 차트 차원을 OLE 프레임에 맞추어 크기 변경을 방지하는 방법을 보여줍니다.

[프레젠테이션에 OLE 개체로 Excel 차트 만들기 및 삽입](/slides/ko/androidjava/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)에서 우리는 Java를 통해 Aspose.Cells for Android로 Excel 차트를 생성하고 Java를 통해 Aspose.Slides for Android를 사용하여 PowerPoint 프레젠테이션에 삽입하는 방법을 설명했습니다. [객체 미리 보기 문제](/slides/ko/androidjava/object-preview-issue-when-adding-oleobjectframe/)를 해결하기 위해 차트 이미지를 차트의 OLE 개체 프레임에 할당했습니다. 결과 프레젠테이션에서 차트 이미지를 표시하는 OLE 개체 프레임을 두 번 클릭하면 Excel 차트가 활성화됩니다. 사용자는 삽입된 Excel 워크북을 편집한 후 활성화된 워크북 외부를 클릭하여 슬라이드로 돌아올 수 있습니다. 사용자가 슬라이드로 돌아올 때 OLE 개체 프레임의 크기가 변경되며, 크기 조정 비율은 OLE 개체 프레임과 삽입된 Excel 워크북의 원래 크기에 따라 달라집니다.

## **크기 변경 원인**

삽입된 Excel 워크북은 자체 창 크기를 가지고 있으며, Excel은 개체가 처음 활성화될 때 이 창 크기를 유지하려고 합니다. 슬라이드에 있는 OLE 프레임은 별도로 정의된 크기를 가집니다. Excel 워크북이 활성화되면 Excel과 PowerPoint가 개체의 크기를 협상하여 임베딩 과정의 일부로 비율을 유지합니다. 따라서 워크북 창과 OLE 프레임 간의 차이가 개체 크기 조정을 일으킬 수 있습니다.

## **작동 솔루션**

차트 크기를 슬라이드의 OLE 프레임에 맞추고 차트 차원을 워크북 창과 독립적으로 유지합니다. 이 솔루션은 새 프레젠테이션이나 기존 템플릿 모두에 적용됩니다.

예제는 Java를 통해 Aspose.Cells for Android와 Aspose.Slides for Android가 필요합니다. 활성 차트 시트에 간단한 세로 막대 차트를 만들고 워크북을 XLS 형식으로 삽입합니다. Android 활동에서 `FixedChartSize.createPresentation(getFilesDir())`를 호출하여 출력을 애플리케이션 내부 파일 디렉터리에 저장합니다. OLE 활성화에는 데스크톱 PowerPoint와 호환되는 Excel 설치가 필요합니다. 차트 미리 보기 이미지가 할당되지 않으며, PowerPoint에서 OLE 개체가 활성화될 때 차트가 표시됩니다.

예제는 왼쪽 가장자리에서 0.5인치, 위쪽에서 1인치 떨어진 위치에 9.5 × 4인치 OLE 프레임을 배치하여 새 프레젠테이션을 생성합니다. 슬라이드 좌표와 차원은 포인트 단위(인치당 72포인트)입니다. 기존 프레젠테이션의 경우 [템플릿 사용](#use-a-template)을 참조하십시오.

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
import java.io.File;

public class FixedChartSize {
    public static void createPresentation(File filesDirectory) {
        try {
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

                    // 슬라이드 좌표와 크기는 포인트 단위이며 (인치당 72포인트)입니다.
                    float width = 684f; // 9.5인치.
                    float height = 288f; // 4인치.

                    chart.setSizeWithWindow(false);
                    // 포인트를 인치당 96픽셀로 변환하여 차트 픽셀로 바꿉니다.
                    chart.getChartObject().setWidth((int)(width / 72f * 96f));
                    chart.getChartObject().setHeight((int)(height / 72f * 96f));
                    chart.setPrintSize(PrintSizeType.CUSTOM);

                    ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
                    workbook.save(workbookStream, FileFormatType.EXCEL_97_TO_2003);
                    OleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(workbookStream.toByteArray(), "xls");
                    slide.getShapes().addOleObjectFrame(36, 72, width, height, dataInfo);

                    File outputFile = new File(filesDirectory, "chart-fixed-size.pptx");
                    presentation.save(outputFile.getAbsolutePath(), SaveFormat.Pptx);
                } finally {
                    presentation.dispose();
                }
            } finally {
                workbook.dispose();
            }
        } catch (Exception exception) {
            System.err.println("Unable to create the presentation: " + exception.getMessage());
        }
    }
}
```
## **고정 차트 크기 설정**

[setSizeWithWindow](https://reference.aspose.com/cells/java/com.aspose.cells/chart/#setSizeWithWindow-boolean-)를 false로 설정하여 차트 차원이 워크북 창과 독립적이도록 합니다. [getChartObject](https://reference.aspose.com/cells/java/com.aspose.cells/chart/#getChartObject--) 차원은 [setWidth](https://reference.aspose.com/cells/java/com.aspose.cells/shape/#setWidth-int-)와 [setHeight](https://reference.aspose.com/cells/java/com.aspose.cells/shape/#setHeight-int-)를 사용하여 설정하고, 인치당 96픽셀을 사용해 포인트를 픽셀로 변환합니다: 684 × 288포인트 프레임은 912 × 384픽셀 차트에 해당합니다. [setPrintSize](https://reference.aspose.com/cells/java/com.aspose.cells/chart/#setPrintSize-int-)를 [PrintSizeType](https://reference.aspose.com/cells/java/com.aspose.cells/printsizetype/)의 CUSTOM 값으로 설정합니다. 예제는 [addOleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addOleObjectFrame-float-float-float-float-com.aspose.slides.IOleEmbeddedDataInfo-)을 사용해 워크북을 삽입하고 9.5 × 4인치 OLE 프레임을 가진 프레젠테이션을 저장합니다.

## **템플릿 사용**

기존 프레젠테이션에서도 크기 조정 로직은 동일합니다. 예제를 적용하려면:

1. 빈 프레젠테이션을 만드는 대신 템플릿 프레젠테이션을 로드합니다.
2. 첫 번째 슬라이드에 최소 세 개의 도형이 포함되어 있는지 확인한 다음, 인덱스 2에 있는 도형을 자리표시자로 사용합니다.
3. 고정값 684와 288을 사용하는 대신 해당 도형에서 프레임 너비와 높이를 가져옵니다. 크기 계산은 그대로 유지합니다.
4. 고정 좌표 36과 72 대신 자리표시자 위치에 OLE 프레임을 추가합니다.
5. 프레젠테이션을 저장하기 전에 자리표시자를 제거합니다.

## **FAQ**

**왜 삽입된 Excel 차트가 PowerPoint에서 활성화한 후 크기가 변하나요?**

Excel이 처음 활성화될 때 원래 창 크기를 복원하려고 하는 반면, PowerPoint의 OLE 개체 프레임은 자체 크기를 가지고 있기 때문입니다. PowerPoint와 Excel이 비율을 유지하려고 크기를 협상하면서 크기 조정이 발생할 수 있습니다.

**차트와 OLE 프레임 크기를 일관되게 유지하려면 어떻게 해야 하나요?**

차트 차원을 고정하고 OLE 프레임에 맞추며, 워크북을 삽입하기 전에 사용자 정의 차트 인쇄 크기를 사용합니다. 위 예제에 필요한 설정과 단위 변환이 보여져 있습니다.

**워크북 창 크기를 맞추는 것만으로 충분한가요?**

워크북 창 크기만 맞추는 것으로는 활성화 후 OLE 프레임이 크기가 변하는 것을 신뢰성 있게 방지할 수 없습니다. 예제에 나온 고정 차트 차원을 사용하십시오.

**이 솔루션은 템플릿 기반 프레젠테이션과 새 프레젠테이션 모두에 적용되나요?**

예. 템플릿의 경우 자리표시자 차원과 위치를 사용하고, 새 프레젠테이션에서는 프레임 차원과 위치를 직접 지정합니다.

**다른 스프레드시트 프로그램으로 만든 차트에도 이 예제를 사용할 수 있나요?**

예제는 Aspose.Cells로 만든 Excel 워크북을 사용합니다. 다른 스프레드시트 프로그램에 대한 활성화 동작은 보여주지 않습니다.

## **관련 섹션**

- [프레젠테이션에 OLE 개체로 Excel 차트 만들기 및 삽입](/slides/ko/androidjava/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)
---
title: PPTX에서 차트 크기 조정에 대한 작업 솔루션
type: docs
weight: 40
url: /ko/java/working-solution-for-chart-resizing-in-pptx/
keywords:
- 차트 크기 조정
- Excel 차트
- OLE 객체
- 차트 삽입
- PowerPoint
- OpenDocument
- 프레젠테이션
- Java
- Aspose.Slides
description: "Aspose.Slides for Java를 사용하여 삽입된 Excel OLE 객체로 PPTX에서 발생하는 예기치 않은 차트 크기 조정을 수정합니다. 크기를 일관되게 유지하기 위한 두 가지 방법과 코드를 배웁니다."
---
## **배경**

Excel 차트가 OLE 객체로 PowerPoint 프레젠테이션에 Aspose 구성 요소를 통해 삽입될 때, 첫 번째 활성화 후 지정되지 않은 비율로 크기가 조정되는 현상이 관찰되었습니다. 이 동작은 차트가 활성화되기 전과 후의 프레젠테이션 사이에 눈에 띄는 시각적 차이를 발생시킵니다. Aspose 팀은 문제를 자세히 조사했으며 해결책을 찾았습니다. 이 문서에서는 문제의 원인과 해당 해결 방법을 설명합니다.

[이전 문서](/slides/ko/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)에서는 Aspose.Cells for Java를 사용하여 Excel 차트를 만들고 Aspose.Slides for Java를 사용해 PowerPoint 프레젠테이션에 삽입하는 방법을 설명했습니다. [객체 미리보기 문제](/slides/ko/java/object-preview-issue-when-adding-oleobjectframe/)를 해결하기 위해 차트 이미지를 차트의 OLE 객체 프레임에 할당했습니다. 출력 프레젠테이션에서 차트 이미지를 표시하는 OLE 객체 프레임을 두 번 클릭하면 Excel 차트가 활성화됩니다. 최종 사용자는 기본 Excel 워크북에서 원하는 변경을 수행한 뒤 활성화된 워크북 외부를 클릭하여 해당 슬라이드로 돌아갈 수 있습니다. 사용자가 슬라이드로 돌아갈 때 OLE 객체 프레임의 크기가 변경되며, 크기 조정 비율은 OLE 객체 프레임과 삽입된 Excel 워크북의 원래 크기에 따라 달라집니다.

## **크기 조정 원인**

Excel 워크북은 자체 창 크기를 가지고 있어 첫 번째 활성화 시 원래 크기를 유지하려고 합니다. 반면 OLE 객체 프레임은 자체 크기를 가지고 있습니다. Microsoft에 따르면 Excel 워크북이 활성화될 때 Excel과 PowerPoint가 크기를 협상하고 삽입 과정의 일환으로 올바른 비율을 유지합니다. Excel 창 크기와 OLE 객체 프레임의 크기 또는 위치 차이에 따라 크기 조정이 발생합니다.

## **해결 방법**

Java용 Aspose.Slides를 사용하여 PowerPoint 프레젠테이션을 만들 때 두 가지 시나리오가 가능합니다.

**시나리오 1:** 기존 템플릿을 기반으로 프레젠테이션을 생성합니다.

**시나리오 2:** 처음부터 프레젠테이션을 생성합니다.

여기서 제공하는 해결책은 두 시나리오 모두에 적용됩니다. 모든 해결 접근 방식의 기본 전제는 **삽입된 OLE 객체의 창 크기가 PowerPoint 슬라이드의 OLE 객체 프레임 크기와 일치해야 한다**는 것입니다. 이제 두 가지 접근 방식에 대해 설명하겠습니다.

## **첫 번째 접근 방식**

이 접근 방식에서는 삽입된 Excel 워크북의 창 크기를 PowerPoint 슬라이드의 OLE 객체 프레임 크기에 맞추는 방법을 배웁니다.

**시나리오 1**

템플릿을 정의했고 이를 기반으로 프레젠테이션을 만들고자 한다고 가정합니다. 템플릿의 인덱스 2에 OLE 프레임을 배치하려는 도형이 있다고 가정합니다. 이 경우 OLE 객체 프레임의 크기는 미리 정의되어 있으며—템플릿의 인덱스 2 도형 크기와 동일합니다. 해야 할 일은 워크북의 창 크기를 해당 도형 크기와 동일하게 설정하는 것입니다. 다음 코드 스니펫이 그 역할을 합니다:

```java
import com.aspose.slides.*;
import java.io.ByteArrayOutputStream;

// 워크북의 창 너비를 인치 단위로 설정합니다 (PowerPoint가 인치당 72포인트를 사용하므로 72로 나눕니다).
workbook.getSettings().setWindowWidthInch(slide.getShapes().get_Item(2).getWidth() / 72f);
 
// 워크북의 창 높이를 인치 단위로 설정합니다.
workbook.getSettings().setWindowHeightInch(slide.getShapes().get_Item(2).getHeight() / 72f);
 
// 워크북을 메모리 스트림에 저장합니다.
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);
 
// 삽입된 Excel 데이터로 OLE 객체 프레임을 생성합니다.
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(workbookStream.toByteArray(), "xls");
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(
    slide.getShapes().get_Item(2).getX(),
    slide.getShapes().get_Item (2).getY(),
    slide.getShapes().get_Item (2).getWidth(),
    slide.getShapes().get_Item (2).getHeight(),
    dataInfo);
```

**시나리오 2**

처음부터 프레젠테이션을 만들고 삽입된 Excel 워크북이 포함된 임의 크기의 OLE 객체 프레임을 포함하려고 한다고 가정합니다. 다음 코드 스니펫에서는 슬라이드의 x = 0.5인치, y = 1인치 위치에 높이 4인치, 너비 9.5인치인 OLE 객체 프레임을 생성합니다. 그런 다음 Excel 워크북 창을 동일한 크기—높이 4인치, 너비 9.5인치—로 설정합니다.

```java
import com.aspose.slides.*;
import java.io.ByteArrayOutputStream;

// 원하는 높이.
int desiredHeight = 288; // 4 인치 (4 * 72)
 
// 원하는 너비.
int desiredWidth = 684; // 9.5 인치 (9.5 * 72)
 
// 창을 사용하여 차트 크기를 정의합니다.
chart.setSizeWithWindow(true);
 
// 워크북의 창 너비를 인치 단위로 설정합니다 (PowerPoint가 인치당 72포인트를 사용하므로 72로 나눕니다).
workbook.getSettings().setWindowWidthInch(desiredWidth / 72f);
 
// 워크북의 창 높이를 인치 단위로 설정합니다.
workbook.getSettings().setWindowHeightInch(desiredHeight / 72f);
 
// 워크북을 메모리 스트림에 저장합니다.
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);
 
// 삽입된 Excel 데이터로 OLE 객체 프레임을 생성합니다.
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(workbookStream.toByteArray(), "xls");
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(
    36,  // x = 0.5 인치 (0.5 * 72)
    72,  // y = 1 인치 (1 * 72)
    desiredWidth,
    desiredHeight,
    dataInfo);
```

## **두 번째 접근 방식**

이 접근 방식에서는 삽입된 Excel 워크북의 차트 크기를 PowerPoint 슬라이드의 OLE 객체 프레임 크기에 맞추는 방법을 배웁니다. 차트 크기가 미리 알려져 있고 이후에 변경되지 않을 경우에 유용합니다.

**시나리오 1**

템플릿을 정의했고 이를 기반으로 프레젠테이션을 만들고자 한다고 가정합니다. 템플릿의 인덱스 2에 OLE 프레임을 배치하려는 도형이 있다고 가정합니다. 이 경우 OLE 프레임 크기는 미리 정의되어 있으며—템플릿의 인덱스 2 도형 크기와 동일합니다. 해야 할 일은 워크북 내 차트 크기를 해당 도형 크기와 동일하게 설정하는 것입니다. 다음 코드 스니펫이 그 역할을 합니다:

```java
import com.aspose.slides.*;
import java.io.ByteArrayOutputStream;

// 창 없이 차트 크기를 정의합니다.
chart.setSizeWithWindow(false);
 
// 차트 너비를 픽셀 단위로 설정합니다 (Excel이 인치당 96픽셀을 사용하므로 96을 곱합니다).
chart.getChartObject().setWidth((int)((slide.getShapes().get_Item(2).getWidth() / 72f) * 96f));
 
// 차트 높이를 픽셀 단위로 설정합니다.
chart.getChartObject().setHeight((int)((slide.getShapes().get_Item(2).getHeight() / 72f) * 96f));
 
// 차트 인쇄 크기를 정의합니다.
chart.setPrintSize(com.aspose.cells.PrintSizeType.CUSTOM);
 
// 워크북을 메모리 스트림에 저장합니다.
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);
 
// 삽입된 Excel 데이터로 OLE 객체 프레임을 생성합니다.
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(workbookStream.toByteArray(), "xls");
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(
    slide.getShapes().get_Item(2).getX(),
    slide.getShapes().get_Item (2).getY(),
    slide.getShapes().get_Item (2).getWidth(),
    slide.getShapes().get_Item (2).getHeight(),
    dataInfo);
```

**시나리오 2**:

처음부터 프레젠테이션을 만들고 삽입된 Excel 워크북이 포함된 임의 크기의 OLE 객체 프레임을 포함하려고 한다고 가정합니다. 다음 코드 스니펫에서는 슬라이드의 x = 0.5인치, y = 1인치 위치에 높이 4인치, 너비 9.5인치인 OLE 객체 프레임을 생성합니다. 또한 차트 크기를 동일한 차원—높이 4인치, 너비 9.5인치—으로 설정합니다.

```java
import com.aspose.slides.*;
import java.io.ByteArrayOutputStream;

// 원하는 높이.
int desiredHeight = 288; // 4 인치 (4 * 72)
 
// 원하는 너비.
int desiredWidth = 684; // 9.5 인치 (9.5 * 72)
 
// 창 없이 차트 크기를 정의합니다.
chart.setSizeWithWindow(false);
 
// 차트 너비를 픽셀 단위로 설정합니다 (인치를 얻기 위해 72로 나누고, Excel이 인치당 96픽셀을 사용하므로 96을 곱합니다).
chart.getChartObject().setWidth((int)((desiredWidth / 72f) * 96f));
 
// 차트 높이를 픽셀 단위로 설정합니다.
chart.getChartObject().setHeight((int)((desiredHeight / 72f) * 96f));
 
// 워크북을 메모리 스트림에 저장합니다.
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);
 
// 삽입된 Excel 데이터로 OLE 객체 프레임을 생성합니다.
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(workbookStream.toByteArray(), "xls");
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(
    36,  // x = 0.5 인치 (0.5 * 72)
    72,  // y = 1 인치 (1 * 72)
    desiredWidth,
    desiredHeight,
    dataInfo);
```

## **결론**

차트 크기 조정 문제를 해결하는 두 가지 접근 방식이 있습니다. 선택은 요구 사항 및 사용 사례에 따라 다릅니다. 두 접근 방식 모두 템플릿 기반이든 처음부터 만든 것이든 동일하게 작동합니다. 또한 이 해결책에서는 OLE 객체 프레임 크기에 제한이 없습니다.

## **FAQ**

### PowerPoint에서 활성화된 후 내 삽입된 Excel 차트가 크기가 바뀌는 이유는 무엇인가요?

Excel이 첫 활성화 시 원래 창 크기를 복원하려고 시도하고, PowerPoint의 OLE 객체 프레임은 자체적인 치수를 갖고 있기 때문에 발생합니다. PowerPoint와 Excel이 크기를 협상하면서 가로세로 비율을 유지하려고 하면 크기 조정이 일어날 수 있습니다.

### 이 크기 조정 문제를 완전히 방지할 수 있나요?

예. Excel 워크북 창 크기 또는 차트 크기를 OLE 객체 프레임 크기에 맞추어 삽입하기 전에 설정하면 차트 크기를 일관되게 유지할 수 있습니다.

### 워크북 창 크기를 맞출지 차트 크기를 맞출지 어느 쪽을 선택해야 하나요?

워크북의 가로세로 비율을 유지하고 나중에 크기 조정이 필요할 수 있다면 **접근 방식 1(창 크기)**을 사용하세요. 차트 크기가 고정되고 삽입 후 변경되지 않을 경우 **접근 방식 2(차트 크기)**를 사용하세요.

### 이 방법은 템플릿 기반 프레젠테이션과 새 프레젠테이션 모두에서 작동하나요?

예. 두 접근 방식 모두 템플릿을 사용한 프레젠테이션이든 처음부터 만든 프레젠테이션이든 동일하게 작동합니다.

### OLE 객체 프레임 크기에 제한이 있나요?

없습니다. 워크북이나 차트 크기에 맞게 적절히 스케일링되는 한 OLE 프레임을 원하는 크기로 설정할 수 있습니다.

### 다른 스프레드시트 프로그램으로 만든 차트에도 이 방법을 적용할 수 있나요?

예제는 Aspose.Cells로 만든 Excel 차트를 대상으로 하지만, 유사한 크기 지정 옵션을 지원하는 OLE 호환 스프레드시트 프로그램에도 동일한 원리를 적용할 수 있습니다.

## **관련 섹션**

- [Create Excel Charts and Embed Them as OLE Objects in Presentations](/slides/ko/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)
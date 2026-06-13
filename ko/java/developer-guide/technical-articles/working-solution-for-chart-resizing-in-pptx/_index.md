---
title: PPTX에서 차트 크기 조정에 대한 작동 솔루션
type: docs
weight: 40
url: /ko/java/working-solution-for-chart-resizing-in-pptx/
keywords:
- 차트 크기 조정
- Excel 차트
- OLE 개체
- 차트 삽입
- PowerPoint
- OpenDocument
- 프레젠테이션
- Java
- Aspose.Slides
description: "Aspose.Slides for Java를 사용하여 삽입된 Excel OLE 개체와 함께 PPTX에서 발생하는 예상치 못한 차트 크기 조정을 해결합니다. 두 가지 방법과 코드를 배워 크기를 일관되게 유지하십시오."
---
## **배경**

Aspose 구성 요소를 통해 PowerPoint 프레젠테이션에 OLE 개체로 삽입된 Excel 차트가 처음 활성화된 후 지정되지 않은 비율로 크기가 조정되는 현상이 관찰되었습니다. 이 동작으로 인해 차트의 활성화 전후 상태 사이에 눈에 띄는 시각적 차이가 발생합니다. Aspose 팀은 문제를 상세히 조사했으며 해결책을 찾았습니다. 이 문서는 문제의 원인과 해당 해결 방법을 설명합니다.

[이전 문서](/slides/ko/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)에서는 Aspose.Cells for Java를 사용하여 Excel 차트를 만들고 Aspose.Slides for Java를 사용해 PowerPoint 프레젠테이션에 삽입하는 방법을 설명했습니다. [객체 미리보기 문제](/slides/ko/java/object-preview-issue-when-adding-oleobjectframe/)를 해결하기 위해 차트 이미지를 차트의 OLE 개체 프레임에 할당했습니다. 출력 프레젠테이션에서 차트 이미지를 표시하는 OLE 개체 프레임을 두 번 클릭하면 Excel 차트가 활성화됩니다. 최종 사용자는 기본 Excel 워크북에서 원하는 변경을 수행한 뒤 활성화된 워크북 외부를 클릭하여 해당 슬라이드로 돌아갈 수 있습니다. 사용자가 슬라이드로 돌아갈 때 OLE 개체 프레임의 크기가 변경되며, 크기 조정 비율은 OLE 개체 프레임과 삽입된 Excel 워크북의 원래 크기에 따라 달라집니다.

## **크기 조정 원인**

Excel 워크북은 자체 창 크기를 가지고 있어 첫 번째 활성화 시 원래 크기를 유지하려고 합니다. 반면 OLE 개체 프레임은 자체 크기를 갖습니다. Microsoft에 따르면 Excel 워크북이 활성화될 때 Excel과 PowerPoint가 크기를 협상하여 임베딩 과정의 일환으로 올바른 비율을 유지합니다. Excel 창 크기와 OLE 개체 프레임의 크기 또는 위치 차이에 따라 크기 조정이 발생합니다.

## **작동 솔루션**

Aspose.Slides for Java를 사용하여 PowerPoint 프레젠테이션을 만드는 두 가지 가능한 시나리오가 있습니다.

**Scenario 1:** 기존 템플릿을 기반으로 프레젠테이션을 생성합니다.

**Scenario 2:** 처음부터 프레젠테이션을 생성합니다.

여기서 제공하는 해결책은 두 시나리오 모두에 적용됩니다. 모든 해결 접근 방식의 기본은 동일합니다: **삽입된 OLE 개체의 창 크기가 PowerPoint 슬라이드의 OLE 개체 프레임과 일치해야 합니다**. 이제 이 해결책에 대한 두 가지 접근 방식을 논의하겠습니다.

## **첫 번째 접근법**

이 접근법에서는 삽입된 Excel 워크북의 창 크기를 PowerPoint 슬라이드의 OLE 개체 프레임 크기와 일치하도록 설정하는 방법을 배웁니다.

**Scenario 1**

템플릿을 정의하고 이를 기반으로 프레젠테이션을 만들고자 한다고 가정해 보겠습니다. 템플릿의 인덱스 2에 OLE 프레임으로 삽입할 Excel 워크북을 배치하려는 도형이 있습니다. 이 경우 OLE 개체 프레임의 크기는 미리 정의되어 있으며, 템플릿의 인덱스 2 도형 크기와 일치합니다. 우리가 해야 할 일은 워크북의 창 크기를 해당 도형 크기와 동일하게 설정하는 것입니다. 다음 코드 스니펫이 그 목적을 수행합니다:

```java
// 워크북의 창 너비를 인치 단위로 설정합니다 (PowerPoint가 인치당 576 픽셀을 사용하므로 576으로 나눕니다).
workbook.getSettings().setWindowWidthInch(slide.getShapes().get_Item(2).getWidth() / 72f);
 
// 워크북의 창 높이를 인치 단위로 설정합니다.
workbook.getSettings().setWindowHeightInch(slide.getShapes().get_Item(2).getHeight() / 72f);
 
// 워크북을 메모리 스트림에 저장합니다.
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);
 
// 삽입된 Excel 데이터와 함께 OLE 개체 프레임을 생성합니다.
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(
    slide.getShapes().get_Item(2).getX(),
    slide.getShapes().get_Item (2).getY(),
    slide.getShapes().get_Item (2).getWidth(),
    slide.getShapes().get_Item (2).getHeight(),
    "Excel.Sheet.8",
    workbookStream.toByteArray());
```

**Scenario 2**

처음부터 프레젠테이션을 만들고 임의 크기의 OLE 개체 프레임에 삽입된 Excel 워크북을 포함하고자 한다고 가정해 보겠습니다. 아래 코드 스니펫에서는 슬라이드의 x = 0.5인치, y = 1인치 위치에 높이 4인치, 너비 9.5인치인 OLE 개체 프레임을 생성합니다. 그런 다음 Excel 워크북 창을 동일한 크기—높이 4인치, 너비 9.5인치—로 설정합니다.

```java
// 원하는 높이.
int desiredHeight = 288; // 4인치 (4 * 72)
 
// 원하는 너비.
int desiredWidth = 684; // 9.5인치 (9.5 * 72)
 
// 윈도우와 함께 차트 크기를 정의합니다.
chart.setSizeWithWindow(true);
 
// 워크북의 창 너비를 인치 단위로 설정합니다 (PowerPoint가 인치당 576픽셀을 사용하므로 576으로 나눕니다).
workbook.getSettings().setWindowWidthInch(desiredHeight / 72f);
 
// 워크북의 창 높이를 인치 단위로 설정합니다.
workbook.getSettings().setWindowHeightInch(desiredWidth / 72f);
 
// 워크북을 메모리 스트림에 저장합니다.
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);
 
// 삽입된 Excel 데이터와 함께 OLE 개체 프레임을 생성합니다.
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(
    288,
    576,
    desiredWidth,
    desiredHeight,
    "Excel.Sheet.8",
    workbookStream.toByteArray());
```

## **두 번째 접근법**

이 접근법에서는 삽입된 Excel 워크북 내 차트의 크기를 PowerPoint 슬라이드의 OLE 개체 프레임 크기와 일치하도록 설정하는 방법을 배웁니다. 차트 크기가 사전에 알려져 있고 이후에 변경되지 않을 때 유용합니다.

**Scenario 1**

템플릿을 정의하고 이를 기반으로 프레젠테이션을 만들고자 한다고 가정해 보겠습니다. 템플릿의 인덱스 2에 OLE 프레임으로 삽입할 Excel 워크북을 배치하려는 도형이 있습니다. 이 경우 OLE 프레임 크기는 미리 정의되어 있으며, 템플릿의 인덱스 2 도형 크기와 일치합니다. 우리가 해야 할 일은 워크북 내 차트 크기를 해당 도형 크기와 동일하게 설정하는 것입니다. 다음 코드 스니펫이 그 목적을 수행합니다:

```java
// 윈도우 없이 차트 크기를 정의합니다.
chart.setSizeWithWindow(false);
 
// 차트 너비를 픽셀 단위로 설정합니다 (Excel이 인치당 96픽셀을 사용하므로 96을 곱합니다).
chart.getChartObject().setWidth((int)((slide.getShapes().get_Item(2).getWidth() / 72f) * 96f));
 
// 차트 높이를 픽셀 단위로 설정합니다.
chart.getChartObject().setHeight((int)((slide.getShapes().get_Item(2).getHeight() / 72f) * 96f));
 
// 차트 인쇄 크기를 정의합니다.
chart.setPrintSize(PrintSizeType.CUSTOM);
 
// 워크북을 메모리 스트림에 저장합니다.
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);
 
// 삽입된 Excel 데이터와 함께 OLE 개체 프레임을 생성합니다.
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(
    slide.getShapes().get_Item(2).getX(),
    slide.getShapes().get_Item (2).getY(),
    slide.getShapes().get_Item (2).getWidth(),
    slide.getShapes().get_Item (2).getHeight(),
    "Excel.Sheet.8",
    workbookStream.toByteArray());
```

**Scenario 2**:

처음부터 프레젠테이션을 만들고 임의 크기의 OLE 개체 프레임에 삽입된 Excel 워크북을 포함하고자 한다고 가정해 보겠습니다. 아래 코드 스니펫에서는 슬라이드의 x = 0.5인치, y = 1인치 위치에 높이 4인치, 너비 9.5인치인 OLE 개체 프레임을 생성합니다. 또한 차트 크기를 동일한 치수인 높이 4인치, 너비 9.5인치로 설정합니다.

```java
// 원하는 높이.
int desiredHeight = 288; // 4인치 (4 * 72)
 
// 원하는 너비.
int desiredWidth = 684; // 9.5인치 (9.5 * 72)
 
// 윈도우 없이 차트 크기를 정의합니다.
chart.setSizeWithWindow(false);
 
// 차트 너비를 픽셀 단위로 설정합니다 (Excel이 인치당 96픽셀을 사용하므로 96을 곱합니다).
chart.getChartObject().setWidth((int)((slide.getShapes().get_Item(2).getWidth() / 576f) * 96f));
 
// 차트 높이를 픽셀 단위로 설정합니다.
chart.getChartObject().setHeight((int)((slide.getShapes().get_Item(2).getHeight() / 576f) * 96f));
 
// 워크북을 메모리 스트림에 저장합니다.
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);
 
// 삽입된 Excel 데이터와 함께 OLE 개체 프레임을 생성합니다.
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(
    288,
    576,
    desiredWidth,
    desiredHeight,
    "Excel.Sheet.8",
    workbookStream.toByteArray());
```

## **결론**

차트 크기 조정 문제를 해결하는 두 가지 접근법이 있습니다. 접근법 선택은 요구 사항과 사용 사례에 따라 달라집니다. 두 접근법 모두 템플릿 기반 프레젠테이션이든 처음부터 만든 프레젠테이션이든 동일하게 작동합니다. 또한 이 솔루션에서는 OLE 개체 프레임 크기에 제한이 없습니다.

## **FAQ**

**PowerPoint에서 활성화된 후 삽입된 Excel 차트가 크기가 변하는 이유는 무엇인가요?**

Excel이 처음 활성화될 때 원래 창 크기를 복원하려고 하며, PowerPoint의 OLE 개체 프레임은 자체 차원을 가지고 있기 때문입니다. PowerPoint와 Excel이 크기를 협상하여 종횡비를 유지하면서 크기 조정이 발생할 수 있습니다.

**이 크기 조정 문제를 완전히 방지할 수 있나요?**

예. 삽입하기 전에 Excel 워크북 창 크기 또는 차트 크기를 OLE 개체 프레임 크기와 일치시키면 차트 크기를 일관되게 유지할 수 있습니다.

**워크북 창 크기를 맞추는 접근법과 차트 크기를 맞추는 접근법 중 어느 것을 선택해야 하나요?**

**접근법 1 (창 크기)**를 사용하면 워크북의 종횡비를 유지하고 필요에 따라 이후에 크기 조정이 가능할 수 있습니다.  
**접근법 2 (차트 크기)**를 사용하면 차트 치수가 고정되어 삽입 후 변경되지 않을 경우에 적합합니다.

**이 방법들은 템플릿 기반 프레젠테이션과 새 프레젠테이션 모두에 적용되나요?**

예. 두 접근법 모두 템플릿을 사용한 프레젠테이션과 처음부터 만든 프레젠테이션에 동일하게 적용됩니다.

**OLE 개체 프레임 크기에 제한이 있나요?**

아니요. 워크북이나 차트 크기에 맞게 적절히 스케일링되는 한 OLE 프레임을 원하는 크기로 설정할 수 있습니다.

**다른 스프레드시트 프로그램으로 만든 차트에도 이 방법을 사용할 수 있나요?**

예제는 Aspose.Cells로 만든 Excel 차트를 기준으로 하지만, 유사한 크기 조정 옵션을 지원하는 OLE 호환 스프레드시트 프로그램에도 동일한 원리가 적용됩니다.

## **관련 섹션**

- [Create Excel Charts and Embed Them as OLE Objects in Presentations](/slides/ko/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)
- [Update OLE Objects Automatically Using a PowerPoint Add-In](/slides/ko/java/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)
---
title: PPTX에서 차트 크기 조정을 위한 작업 솔루션
type: docs
weight: 60
url: /ko/net/working-solution-for-chart-resizing-in-pptx/
keywords:
- 차트 크기 조정
- Excel 차트
- OLE 개체
- 차트 삽입
- PowerPoint
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET을 사용하여 삽입된 Excel OLE 개체와 함께 PPTX에서 발생하는 예기치 않은 차트 크기 조정을 수정합니다. 코드를 포함한 두 가지 방법을 배우고 크기를 일관되게 유지하세요."
---
## **배경**

Aspose 구성 요소를 통해 PowerPoint 프레젠테이션에 OLE 개체로 삽입된 Excel 차트가 처음 활성화된 후 지정되지 않은 비율로 크기가 조정되는 것이 관찰되었습니다. 이 동작으로 인해 차트가 활성화되기 전과 후의 프레젠테이션 사이에 눈에 띄는 시각적 차이가 발생합니다. Aspose 팀은 이 문제를 자세히 조사하고 해결책을 찾았습니다. 이 문서에서는 문제의 원인과 해당 해결 방법을 설명합니다.

이전 기사[이전 기사](/slides/ko/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)에서는 Aspose.Cells for .NET을 사용하여 Excel 차트를 생성하고 Aspose.Slides for .NET을 사용해 PowerPoint 프레젠테이션에 삽입하는 방법을 설명했습니다. 개체 미리보기 문제[개체 미리보기 문제](/slides/ko/net/object-preview-issue-when-adding-oleobjectframe/)를 해결하기 위해 차트 이미지를 차트의 OLE 개체 프레임에 할당했습니다. 출력 프레젠테이션에서 차트 이미지를 표시하는 OLE 개체 프레임을 두 번 클릭하면 Excel 차트가 활성화됩니다. 최종 사용자는 기본 Excel 워크북에서 원하는 변경을 수행한 후 활성화된 워크북 외부를 클릭하여 해당 슬라이드로 돌아갈 수 있습니다. 사용자가 슬라이드로 돌아오면 OLE 개체 프레임의 크기가 변경되며, 크기 조정 비율은 OLE 개체 프레임과 삽입된 Excel 워크북의 원래 크기에 따라 달라집니다.

## **크기 조정 원인**

Excel 워크북은 자체 창 크기를 가지고 있기 때문에 처음 활성화될 때 원래 크기를 유지하려고 합니다. 하지만 OLE 개체 프레임은 자체 크기를 가지고 있습니다. Microsoft에 따르면 Excel 워크북이 활성화될 때 Excel과 PowerPoint가 크기를 협상하여 삽입 과정의 일환으로 올바른 비율을 유지합니다. Excel 창 크기와 OLE 개체 프레임의 크기 또는 위치 차이에 따라 크기 조정이 발생합니다.

## **작동 솔루션**

Aspose.Slides for .NET을 사용하여 PowerPoint 프레젠테이션을 만들 때 두 가지 가능한 시나리오가 있습니다.

**Scenario 1:** Create a presentation based on an existing template.
**Scenario 2:** Create a presentation from scratch.

여기서 제공하는 해결책은 두 시나리오 모두에 적용됩니다. 모든 해결 접근 방식의 기본은 동일합니다: **삽입된 OLE 개체의 창 크기가 PowerPoint 슬라이드의 OLE 개체 프레임과 일치해야 합니다**. 이제 이 해결책의 두 가지 접근 방식을 논의하겠습니다.

## **첫 번째 접근 방식**

이 접근 방식에서는 삽입된 Excel 워크북의 창 크기를 설정하여 PowerPoint 슬라이드의 OLE 개체 프레임 크기와 일치하도록 하는 방법을 배웁니다.

**Scenario 1**

템플릿을 정의하고 이를 기반으로 프레젠테이션을 만들고 싶다고 가정해 보겠습니다. 템플릿의 인덱스 2에 OLE 프레임을 배치하여 삽입된 Excel 워크북을 포함하려는 도형이 있다고 가정합니다. 이 시나리오에서는 OLE 개체 프레임의 크기가 미리 정의되어 있으며—템플릿의 인덱스 2 도형 크기와 동일합니다. 해야 할 일은 워크북의 창 크기를 해당 도형 크기와 동일하게 설정하는 것입니다. 아래 코드 스니펫이 이를 수행합니다:

```cs
// 차트 크기를 창과 함께 정의합니다. 
chart.SizeWithWindow = true;

// 워크북의 창 너비를 인치 단위로 설정합니다 (PowerPoint가 인치당 72픽셀을 사용하므로 72로 나눕니다).
workbook.Worksheets.WindowWidthInch = slide.Shapes[2].Width / 72f;

// 워크북의 창 높이를 인치 단위로 설정합니다.
workbook.Worksheets.WindowHeightInch = slide.Shapes[2].Height / 72f;

// 워크북을 메모리 스트림에 저장합니다.
MemoryStream workbookStream = workbook.SaveToStream();

// 삽입된 Excel 데이터를 사용하여 OLE 개체 프레임을 생성합니다.
Aspose.Slides.OleObjectFrame oleFrame = slide.Shapes.AddOleObjectFrame(
    slide.Shapes[2].X,
    slide.Shapes[2].Y,
    slide.Shapes[2].Width,
    slide.Shapes[2].Height,
	"Excel.Sheet.8",
	workbookStream.ToArray());
```

**Scenario 2**

새 프레젠테이션을 처음부터 만들고 어떤 크기의 OLE 개체 프레임에 삽입된 Excel 워크북을 포함하고 싶다고 가정해 보겠습니다. 아래 코드 스니펫에서는 슬라이드의 x = 0.5인치, y = 1인치 위치에 높이 4인치, 너비 9.5인치인 OLE 개체 프레임을 생성합니다. 그런 다음 Excel 워크북 창을 동일한 크기인 높이 4인치, 너비 9.5인치로 설정합니다.

```cs
// 원하는 높이.
int desiredHeight = 288; // 4 인치 (4 * 72)

// 원하는 너비.
int desiredWidth = 684;//9.5 인치 (9.5 * 72)

// 창과 함께 차트 크기를 정의합니다.
chart.SizeWithWindow = true;

// 워크북의 창 너비를 인치 단위로 설정합니다.
workbook.Worksheets.WindowWidthInch = desiredWidth / 72f;

// 워크북의 창 높이를 인치 단위로 설정합니다.
workbook.Worksheets.WindowHeightInch = desiredHeight / 72f;

// 워크북을 메모리 스트림에 저장합니다.
MemoryStream workbookStream = workbook.SaveToStream();

// 삽입된 Excel 데이터를 사용하여 OLE 개체 프레임을 생성합니다.
Aspose.Slides.OleObjectFrame oleFrame = slide.Shapes.AddOleObjectFrame(
    36,
    72,
    desiredWidth,
    desiredHeight,
	"Excel.Sheet.8",
	workbookStream.ToArray());
```

## **두 번째 접근 방식**

이 접근 방식에서는 삽입된 Excel 워크북에 있는 차트의 크기를 PowerPoint 슬라이드의 OLE 개체 프레임 크기와 일치하도록 설정하는 방법을 배웁니다. 차트 크기가 미리 알려져 있고 이후 변경되지 않을 경우에 유용합니다.

**Scenario 1**

템플릿을 정의하고 이를 기반으로 프레젠테이션을 만들고 싶다고 가정해 보겠습니다. 템플릿의 인덱스 2에 OLE 프레임을 배치하여 삽입된 Excel 워크북을 포함하려고 합니다. 이 시나리오에서는 OLE 프레임 크기가 미리 정의되어 있으며—템플릿의 인덱스 2 도형 크기와 동일합니다. 해야 할 일은 워크북 내 차트 크기를 해당 도형 크기와 동일하게 설정하는 것입니다. 아래 코드 스니펫이 이를 수행합니다:

```cs
// 창 없이 차트 크기를 정의합니다. 
chart.SizeWithWindow = false;

// 차트 너비를 픽셀 단위로 설정합니다 (Excel이 인치당 96픽셀을 사용하므로 96을 곱합니다).    
chart.ChartObject.Width = (int)((slide.Shapes[2].Width / 72f) * 96f);

// 차트 높이를 픽셀 단위로 설정합니다.
chart.ChartObject.Height = (int)((slide.Shapes[2].Height / 72f) * 96f);

// 차트 인쇄 크기를 정의합니다.
chart.PrintSize = PrintSizeType.Custom;

// 워크북을 메모리 스트림에 저장합니다.
MemoryStream workbookStream = workbook.SaveToStream();

// 삽입된 Excel 데이터를 사용하여 OLE 개체 프레임을 생성합니다.
Aspose.Slides.OleObjectFrame oleFrame = slide.Shapes.AddOleObjectFrame(
    slide.Shapes[2].X,
    slide.Shapes[2].Y,
    slide.Shapes[2].Width,
    slide.Shapes[2].Height,
	"Excel.Sheet.8",
	workbookStream.ToArray());
```

**Scenario 2**

새 프레젠테이션을 처음부터 만들고 어떤 크기의 OLE 개체 프레임에 삽입된 Excel 워크북을 포함하고 싶다고 가정해 보겠습니다. 아래 코드 스니펫에서는 슬라이드의 x = 0.5인치, y = 1인치 위치에 높이 4인치, 너비 9.5인치인 OLE 개체 프레임을 생성합니다. 또한 해당 차트 크기를 같은 차원인 높이 4인치, 너비 9.5인치로 설정합니다.

```cs
 // 원하는 높이.
int desiredHeight = 288; // 4인치 (4 * 576)

// 원하는 너비.
int desiredWidth = 684; // 9.5인치 (9.5 * 576)

// 창 없이 차트 크기를 정의합니다. 
chart.SizeWithWindow = false;

// 픽셀 단위로 차트 너비를 설정합니다.   
chart.ChartObject.Width = (int)((desiredWidth / 72f) * 96f);

// 픽셀 단위로 차트 높이를 설정합니다.    
chart.ChartObject.Height = (int)((desiredHeight / 72f) * 96f);

// 워크북을 메모리 스트림에 저장합니다.
MemoryStream workbookStream = workbook.SaveToStream();

// 삽입된 Excel 데이터를 사용하여 OLE 개체 프레임을 생성합니다.
Aspose.Slides.OleObjectFrame oleFrame = slide.Shapes.AddOleObjectFrame(
    36,
    72,
    desiredWidth,
    desiredHeight,
	"Excel.Sheet.8",
	workbookStream.ToArray());
```

## **결론**

차트 크기 조정 문제를 해결하는 데는 두 가지 접근 방식이 있습니다. 접근 방식 선택은 요구 사항 및 사용 사례에 따라 달라집니다. 두 접근 방식 모두 프레젠테이션을 템플릿에서 만들든 처음부터 만들든 동일하게 작동합니다. 또한 이 솔루션에서는 OLE 개체 프레임 크기에 제한이 없습니다.

## **FAQ**

**왜 내 삽입된 Excel 차트가 PowerPoint에서 활성화된 후 크기가 변합니까?**  
이는 Excel이 처음 활성화될 때 원래 창 크기를 복원하려고 시도하고, PowerPoint의 OLE 개체 프레임은 자체적인 차원을 가지고 있기 때문입니다. PowerPoint와 Excel이 크기를 협상하여 비율을 유지하므로 크기 조정이 발생할 수 있습니다.

**이 크기 조정 문제를 완전히 방지할 수 있나요?**  
예. 삽입하기 전에 Excel 워크북 창 크기 또는 차트 크기를 OLE 개체 프레임 크기와 일치시키면 차트 크기를 일관되게 유지할 수 있습니다.

**어떤 접근 방식을 선택해야 하나요, 워크북 창 크기 설정인가 차트 크기 설정인가?**  
**접근 방식 1 (창 크기)**을 사용하세요. 워크북의 종횡비를 유지하고 추후에 크기 조정이 가능하도록 하려면 이 방법을 선택합니다.  
**접근 방식 2 (차트 크기)**를 사용하세요. 차트 크기가 고정되어 삽입 후 변경되지 않을 경우 이 방법이 적합합니다.

**이 방법들은 템플릿 기반 프레젠테이션과 새 프레젠테이션 모두에 적용됩니까?**  
예. 두 접근 방식 모두 템플릿에서 만든 프레젠테이션과 처음부터 만든 프레젠테이션에 동일하게 적용됩니다.

**OLE 개체 프레임의 크기에 제한이 있나요?**  
아니요. 워크북 또는 차트 크기에 맞게 적절히 스케일링할 수 있는 한 OLE 프레임을 원하는 크기로 설정할 수 있습니다.

**다른 스프레드시트 프로그램에서 만든 차트에도 이 방법을 사용할 수 있나요?**  
예제는 Aspose.Cells로 만든 Excel 차트를 대상으로 하지만, 유사한 크기 지정 옵션을 지원하는 다른 OLE 호환 스프레드시트 프로그램에도 동일한 원리가 적용됩니다.

## **관련 섹션**

- [Excel 차트를 만들고 OLE 개체로 프레젠테이션에 삽입하기](/slides/ko/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)
- [PowerPoint 추가 기능을 사용하여 OLE 개체 자동 업데이트](/slides/ko/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)
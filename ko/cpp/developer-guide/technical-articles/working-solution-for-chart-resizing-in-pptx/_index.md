---
title: PPTX에서 차트 크기 조정을 위한 실용적인 해결책
type: docs
weight: 60
url: /ko/cpp/working-solution-for-chart-resizing-in-pptx/
keywords:
- 차트 크기 조정
- Excel 차트
- OLE 개체
- 차트 삽입
- PowerPoint
- OpenDocument
- 프레젠테이션
- C++
- Aspose.Slides
description: "Aspose.Slides for C++와 함께 삽입된 Excel OLE 개체를 사용할 때 PPTX에서 발생하는 예기치 않은 차트 크기 조정을 해결합니다. 코드를 포함한 두 가지 방법을 배우고 크기를 일관되게 유지하세요."
---
## **배경**

Excel 차트가 Aspose 구성 요소를 통해 PowerPoint 프레젠테이션에 OLE 개체로 삽입된 후 첫 번째 활성화 시 지정되지 않은 비율로 크기가 조정되는 것이 관찰되었습니다. 이 동작으로 차트의 활성화 전후 상태 사이에 눈에 띄는 시각적 차이가 발생합니다. Aspose 팀은 문제를 자세히 조사했고 해결책을 찾았습니다. 이 문서에서는 문제의 원인과 해당 해결 방법을 설명합니다.

[이전 문서](/slides/ko/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)에서 Aspose.Cells for C++를 사용하여 Excel 차트를 만들고 Aspose.Slides for C++를 사용해 PowerPoint 프레젠테이션에 삽입하는 방법을 설명했습니다. [개체 미리보기 문제](/slides/ko/cpp/object-preview-issue-when-adding-oleobjectframe/)를 해결하기 위해 차트 이미지를 차트의 OLE 개체 프레임에 할당했습니다. 결과 프레젠테이션에서 차트 이미지를 표시하는 OLE 개체 프레임을 두 번 클릭하면 Excel 차트가 활성화됩니다. 최종 사용자는 기본 Excel 워크북에서 원하는 변경을 수행한 후 활성화된 워크북 밖을 클릭하여 해당 슬라이드로 돌아갈 수 있습니다. 사용자가 슬라이드로 돌아갈 때 OLE 개체 프레임의 크기가 변경되며, 크기 조정 비율은 OLE 개체 프레임과 삽입된 Excel 워크북의 원래 크기에 따라 달라집니다.

## **크기 조정 원인**

Excel 워크북은 자체 창 크기가 있어 첫 번째 활성화 시 원래 크기를 유지하려고 합니다. 그러나 OLE 개체 프레임은 자체 크기를 가지고 있습니다. Microsoft에 따르면 Excel 워크북이 활성화될 때 Excel과 PowerPoint가 크기를 협상하여 임베딩 과정의 일환으로 올바른 비율을 유지합니다. Excel 창 크기와 OLE 개체 프레임의 크기 또는 위치 차이에 따라 크기 조정이 발생합니다.

## **실제 해결책**

Aspose.Slides for C++를 사용하여 PowerPoint 프레젠테이션을 만들 때 두 가지 가능한 시나리오가 있습니다.

**시나리오 1:** 기존 템플릿을 기반으로 프레젠테이션을 생성합니다.

**시나리오 2:** 처음부터 프레젠테이션을 생성합니다.

여기서 제공하는 솔루션은 두 시나리오 모두에 적용됩니다. 모든 해결 방법의 기본은 동일합니다: **삽입된 OLE 개체의 창 크기는 PowerPoint 슬라이드의 OLE 개체 프레임과 일치해야 합니다**. 이제 이 솔루션의 두 접근 방법을 논의하겠습니다.

## **첫 번째 접근법**

이 접근법에서는 삽입된 Excel 워크북의 창 크기를 설정하여 PowerPoint 슬라이드의 OLE 개체 프레임 크기와 일치하도록 하는 방법을 배웁니다.

**시나리오 1** 

템플릿이 정의되어 있고 이를 기반으로 프레젠테이션을 만들고 싶다고 가정해 보겠습니다. 템플릿의 인덱스 2에 OLE 프레임(삽입된 Excel 워크북 포함)을 배치하려는 도형이 있다고 가정합니다. 이 시나리오에서는 OLE 개체 프레임의 크기가 미리 정의되어 있으며—템플릿의 인덱스 2 도형 크기와 일치합니다. 우리가 해야 할 일은 워크북의 창 크기를 해당 도형 크기와 동일하게 설정하는 것입니다. 다음 코드 조각이 그 목적을 수행합니다:

```cpp
System::SharedPtr<System::IO::MemoryStream> ToSlidesMemoryStream(intrusive_ptr<Aspose::Cells::Systems::IO::MemoryStream> inputStream)
{
    auto outputBuffer = System::MakeArray<uint8_t>(inputStream->GetLength(), inputStream->GetBuffer()->ArrayPoint());
    auto outputStream = System::MakeObject<System::IO::MemoryStream>(outputBuffer);

    return outputStream;
}
```

```cpp
// 차트 크기를 창으로 정의합니다. 
chart->SetSizeWithWindow(true);

auto shape = slide->get_Shape(2);

// 워크북의 창 너비를 인치 단위로 설정합니다 (PowerPoint가 인치당 72픽셀을 사용하므로 72로 나눔).
workbook->GetISettings()->SetWindowWidthInch(shape->get_Width() / 72.f);

// 워크북의 창 높이를 인치 단위로 설정합니다.
workbook->GetISettings()->SetWindowHeightInch(shape->get_Height() / 72.f);

// 워크북을 메모리 스트림에 저장합니다.
System::SharedPtr<System::IO::MemoryStream> workbookStream = ToSlidesMemoryStream3(workbook->SaveToStream());

System::SharedPtr<IOleEmbeddedDataInfo> dataInfo = System::MakeObject<OleEmbeddedDataInfo>(workbookStream->ToArray(), u"xls");

// 삽입된 Excel 데이터로 OLE 개체 프레임을 생성합니다.
System::SharedPtr<IOleObjectFrame> oleFrame = slide->get_Shapes()->AddOleObjectFrame(
    shape->get_X(), 
    shape->get_Y(), 
    shape->get_Width(), 
    shape->get_Height(),
    dataInfo);
```

**시나리오 2** 

처음부터 프레젠테이션을 만들고 삽입된 Excel 워크북이 포함된 임의 크기의 OLE 개체 프레임을 포함하고 싶다고 가정해 보겠습니다. 다음 코드 조각에서는 슬라이드의 x = 0.5인치, y = 1인치 위치에 높이 4인치, 너비 9.5인치인 OLE 개체 프레임을 생성합니다. 그런 다음 Excel 워크북 창을 동일한 크기(높이 4인치, 너비 9.5인치)로 설정합니다.

```cpp
// 원하는 높이.
int32_t desiredHeight = 288; // 4인치 (4 * 72)

// 원하는 너비.
int32_t desiredWidth = 684; // 9.5인치 (9.5 * 72)

// 차트 크기를 창으로 정의합니다.
chart->SetSizeWithWindow(true);

// 워크북 창 너비를 인치 단위로 설정합니다.
workbook->GetISettings()->SetWindowWidthInch(desiredWidth / 72.f);

// 워크북 창 높이를 인치 단위로 설정합니다.
workbook->GetISettings()->SetWindowHeightInch(desiredHeight / 72.f);

// 워크북을 메모리 스트림에 저장합니다.
System::SharedPtr<System::IO::MemoryStream> workbookStream = ToSlidesMemoryStream(workbook->SaveToStream());

System::SharedPtr<IOleEmbeddedDataInfo> dataInfo = System::MakeObject<OleEmbeddedDataInfo>(workbookStream->ToArray(), u"xls");

// 삽입된 Excel 데이터로 OLE 개체 프레임을 생성합니다.
System::SharedPtr<IOleObjectFrame> oleFrame = slide->get_Shapes()->AddOleObjectFrame(
    36.0f,
    72.0f, 
    desiredWidth, 
    desiredHeight,
    dataInfo);
```

## **두 번째 접근법**

이 접근법에서는 삽입된 Excel 워크북 내 차트의 크기를 PowerPoint 슬라이드의 OLE 개체 프레임 크기와 일치하도록 설정하는 방법을 배웁니다. 이 방법은 차트 크기가 미리 알려져 있고 이후에 변경되지 않을 때 유용합니다.

**시나리오 1** 

템플릿이 정의되어 있고 이를 기반으로 프레젠테이션을 만들고 싶다고 가정해 보겠습니다. 템플릿의 인덱스 2에 삽입된 Excel 워크북이 포함된 OLE 프레임을 배치하려는 도형이 있다고 가정합니다. 이 시나리오에서는 OLE 프레임 크기가 미리 정의되어 있으며—템플릿의 인덱스 2 도형 크기와 일치합니다. 우리가 해야 할 일은 워크북 내 차트 크기를 해당 도형 크기와 동일하게 설정하는 것입니다. 다음 코드 조각이 그 목적을 수행합니다:

```cpp
// 창 없이 차트 크기를 정의합니다. 
chart->SetSizeWithWindow(false);

auto shape = slide->get_Shape(2);

// 차트 너비를 픽셀 단위로 설정합니다 (Excel은 인치당 96픽셀을 사용하므로 96을 곱합니다).    
chart->GetIChartObject()->SetWidth((int32_t)(shape->get_Width() / 72.f * 96.f));

// 차트 높이를 픽셀 단위로 설정합니다.
chart->GetIChartObject()->SetHeight((int32_t)(shape->get_Height() / 72.f) * 96.f);

// 차트 인쇄 크기를 정의합니다.
chart->SetPrintSize(Aspose::Cells::PrintSizeType::PrintSizeType_Custom);

// 워크북을 메모리 스트림에 저장합니다.
System::SharedPtr<System::IO::MemoryStream> workbookStream = ToSlidesMemoryStream(workbook->SaveToStream());

System::SharedPtr<IOleEmbeddedDataInfo> dataInfo = System::MakeObject<OleEmbeddedDataInfo>(workbookStream->ToArray(), u"xls");

// 삽입된 Excel 데이터로 OLE 개체 프레임을 생성합니다.
System::SharedPtr<IOleObjectFrame> oleFrame = slide->get_Shapes()->AddOleObjectFrame(
    shape->get_X(), 
    shape->get_Y(), 
    shape->get_Width(),
    shape->get_Height(),
    dataInfo);
```

**시나리오 2** 

처음부터 프레젠테이션을 만들고 임의 크기의 OLE 개체 프레임에 삽입된 Excel 워크북을 포함하고 싶다고 가정해 보겠습니다. 다음 코드 조각에서는 슬라이드의 x = 0.5인치, y = 1인치 위치에 높이 4인치, 너비 9.5인치인 OLE 개체 프레임을 생성합니다. 또한 해당 차트 크기를 같은 차원(높이 4인치, 너비 9.5인치)으로 설정합니다.

```cpp
// 원하는 높이.
int32_t desiredHeight = 288; // 4인치 (4 * 576)

// 원하는 너비.
int32_t desiredWidth = 684; // 9.5인치 (9.5 * 576)

// 창 없이 차트 크기를 정의합니다. 
chart->SetSizeWithWindow(false);

// 차트 너비를 픽셀 단위로 설정합니다.    
chart->GetIChartObject()->SetWidth((int32_t)((desiredWidth / 72.f) * 96.f));

// 차트 높이를 픽셀 단위로 설정합니다.
chart->GetIChartObject()->SetHeight((int32_t)((desiredHeight / 72.f) * 96.f));

// 워크북을 메모리 스트림에 저장합니다.
System::SharedPtr<System::IO::MemoryStream> workbookStream = ToSlidesMemoryStream(workbook->SaveToStream());

System::SharedPtr<IOleEmbeddedDataInfo> dataInfo = System::MakeObject<OleEmbeddedDataInfo>(workbookStream->ToArray(), u"xls");

// 삽입된 Excel 데이터로 OLE 개체 프레임을 생성합니다.
System::SharedPtr<IOleObjectFrame> oleFrame = slide->get_Shapes()->AddOleObjectFrame(
    36.0f, 
    72.0f, 
    desiredWidth, 
    desiredHeight,
    dataInfo);
```

## **결론**

차트 크기 조정 문제를 해결하는 데는 두 가지 접근 방식이 있습니다. 접근 방식을 선택하는 것은 요구 사항 및 사용 사례에 따라 달라집니다. 두 접근법 모두 프레젠테이션이 템플릿에서 만들든 처음부터 만들든 동일하게 작동합니다. 또한 이 솔루션에서는 OLE 개체 프레임 크기에 제한이 없습니다.

## **FAQ**

**왜 내 삽입된 Excel 차트가 PowerPoint에서 활성화된 후 크기가 변경되나요?**

이는 Excel이 첫 번째 활성화 시 원래 창 크기를 복원하려고 시도하고, PowerPoint의 OLE 개체 프레임은 자체적인 치수를 가지고 있기 때문입니다. PowerPoint와 Excel이 비율을 유지하도록 크기를 협상하면서 크기 조정이 발생할 수 있습니다.

**이 크기 조정 문제를 완전히 방지할 수 있나요?**

예. 삽입하기 전에 Excel 워크북 창 크기 또는 차트 크기를 OLE 개체 프레임 크기와 일치시키면 차트 크기를 일관되게 유지할 수 있습니다.

**워크북 창 크기를 설정하는 접근법과 차트 크기를 설정하는 접근법 중 어느 것을 선택해야 하나요?**

**Approach 1 (창 크기)**을 사용하면 워크북의 종횡비를 유지하고 필요시 나중에 크기 조정을 허용할 수 있습니다. 차트 크기가 고정되어 삽입 후 변경되지 않을 경우 **Approach 2 (차트 크기)**를 사용하십시오.

**이 방법들은 템플릿 기반 프레젠테이션과 새 프레젠테이션 모두에 적용될까요?**

예. 두 접근법 모두 템플릿에서 만든 프레젠테이션과 처음부터 만든 프레젠테이션 모두에 동일하게 적용됩니다.

**OLE 개체 프레임 크기에 제한이 있나요?**

아니요. OLE 프레임을 워크북이나 차트 크기에 맞게 적절히 스케일링하기만 하면 원하는 어떤 크기로든 설정할 수 있습니다.

**다른 스프레드시트 프로그램에서 만든 차트에도 이 방법을 사용할 수 있나요?**

예제는 Aspose.Cells로 만든 Excel 차트를 대상으로 하지만, 유사한 크기 조정 옵션을 지원하는 OLE 호환 스프레드시트 프로그램에도 동일한 원리가 적용됩니다.

## **Related Sections**

- [프레젠테이션에 Excel 차트를 생성하고 OLE 개체로 삽입하기](/slides/ko/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)
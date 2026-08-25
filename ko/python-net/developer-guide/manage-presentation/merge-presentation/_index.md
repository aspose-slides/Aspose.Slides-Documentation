---
title: Python을 사용한 효율적인 프레젠테이션 병합
linktitle: 프레젠테이션 병합
type: docs
weight: 40
url: /ko/python-net/merge-presentation/
keywords:
- PowerPoint 병합
- 프레젠테이션 병합
- 슬라이드 병합
- PPT 병합
- PPTX 병합
- ODP 병합
- PowerPoint 결합
- 프레젠테이션 결합
- 슬라이드 결합
- PPT 결합
- PPTX 결합
- ODP 결합
- Python
- Aspose.Slides
description: "Python에서 슬라이드를 복제하고, 마스터와 레이아웃을 제어하며, 슬라이드 콘텐츠 크기를 조정하고, 섹션을 보존하며, 보호된 파일이나 대용량 파일을 처리함으로써 PowerPoint 및 OpenDocument 프레젠테이션을 병합하는 방법을 배우세요."
---
## **개요**

Aspose.Slides for Python via .NET는 한 [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/)의 슬라이드를 복제하여 다른 프레젠테이션에 병합합니다. 주요 작업은 [SlideCollection.add_clone](https://reference.aspose.com/slides/ko/python-net/aspose.slides/slidecollection/add_clone/)이며, 소스 슬라이드의 서식을 보존하거나 복제된 슬라이드를 대상 프레젠테이션의 마스터 또는 레이아웃에 연결할 수 있습니다.

이 문서는 가장 일반적인 병합 워크플로우를 다룹니다:

- 모든 슬라이드를 소스 서식을 유지하면서 병합;
- 선택된 슬라이드만 병합;
- 대상 프레젠테이션의 마스터를 적용;
- 대상 프레젠테이션의 특정 레이아웃을 적용;
- 병합 전에 서로 다른 슬라이드 크기를 정규화;
- 복제된 슬라이드를 섹션에 추가;
- 여러 프레젠테이션을 하나의 엔드‑투‑엔드 워크플로우에서 병합;
- 마스터, 리소스, 노트, 코멘트, 미디어, 글꼴, 암호, 대용량 파일 및 멀티스레딩 문제 처리.

## **슬라이드 복제가 마스터와 레이아웃에 미치는 영향**

슬라이드는 레이아웃과 마스터로부터 대부분의 모양을 상속받습니다. 따라서 선택하는 복제 오버로드에 따라 병합된 슬라이드가 대상 프레젠테이션에 어떻게 통합되는지가 결정됩니다.

다음 중 하나의 방법으로 [SlideCollection.add_clone](https://reference.aspose.com/slides/ko/python-net/aspose.slides/slidecollection/add_clone/)을 사용하십시오:

- `add_clone(source_slide)` — 소스 슬라이드의 레이아웃과 서식을 보존합니다. 필요한 경우 소스 마스터가 자동으로 대상 프레젠테이션에 복제될 수 있습니다. Aspose.Slides는 자동 복제된 마스터를 추적하여 동일한 소스 마스터를 사용하는 반복 슬라이드가 마스터를 반복 복제하지 않도록 합니다.
- `add_clone(source_slide, destination_master, allow_clone_missing_layout)` — 복제된 슬라이드를 특정 대상 [IMasterSlide](https://reference.aspose.com/slides/ko/python-net/aspose.slides/imasterslide/)에 연결합니다. Aspose.Slides는 레이아웃 유형이나 이름을 기준으로 해당 마스터 아래에 일치하는 레이아웃을 찾습니다.
- `add_clone(source_slide, destination_layout)` — 복제된 슬라이드를 특정 대상 [ILayoutSlide](https://reference.aspose.com/slides/ko/python-net/aspose.slides/ilayoutslide/)에 직접 연결합니다.

`add_clone` 오버로드에 전달되는 마스터 또는 레이아웃은 **대상** 프레젠테이션에 속해야 하며, 소스 프레젠테이션에 속해서는 안 됩니다.

## **전체 프레젠테이션 병합 및 소스 서식 보존**

가장 간단한 병합은 소스 프레젠테이션의 모든 슬라이드를 대상 프레젠테이션에 복사하는 것입니다. 가져온 슬라이드가 원래 테마, 마스터 및 레이아웃 관계를 유지해야 할 때 적합합니다.

```python
import aspose.slides as slides

with slides.Presentation("destination.pptx") as destination:
    with slides.Presentation("source.pptx") as source:
        for slide in source.slides:
            destination.slides.add_clone(slide)

        destination.save("merged.pptx", slides.export.SaveFormat.PPTX)
```

소스와 대상이 서로 다른 디자인을 사용할 경우 결과 프레젠테이션에 여러 마스터가 포함될 수 있습니다. 이는 소스 서식을 의도적으로 보존할 때 예상되는 동작입니다.

## **선택된 슬라이드 병합**

모든 슬라이드를 복제할 필요는 없습니다. 다음 예제는 소스 프레젠테이션에서 선택된 슬라이드 인덱스만 가져옵니다.

```python
import aspose.slides as slides

with slides.Presentation("destination.pptx") as destination:
    with slides.Presentation("source.pptx") as source:
        slide_indexes = [0, 2, 4]

        for index in slide_indexes:
            destination.slides.add_clone(source.slides[index])

        destination.save("merged-selected-slides.pptx", slides.export.SaveFormat.PPTX)
```

사용자 입력이나 외부 구성에서 슬라이드 인덱스를 받아오는 경우 복제하기 전에 인덱스를 검증하십시오.

## **대상 마스터를 사용한 슬라이드 병합**

가져온 슬라이드가 이미 대상 프레젠테이션에 존재하는 마스터를 따라야 할 경우 [add_clone(source_slide, destination_master, allow_clone_missing_layout)](https://reference.aspose.com/slides/ko/python-net/aspose.slides/slidecollection/add_clone/) 오버로드를 사용하십시오.

```python
import aspose.slides as slides

with slides.Presentation("destination.pptx") as destination:
    with slides.Presentation("source.pptx") as source:
        destination_master = destination.masters[0]

        for slide in source.slides:
            destination.slides.add_clone(slide, destination_master, True)

        destination.save("merged-with-destination-master.pptx", slides.export.SaveFormat.PPTX)
```

Aspose.Slides는 소스 레이아웃의 유형 또는 이름과 일치하는 적절한 레이아웃을 지정된 마스터 아래에서 선택합니다. 적합한 레이아웃이 없고 `allow_clone_missing_layout`이 `True`이면 소스 레이아웃이 복제되어 슬라이드를 추가할 수 있게 됩니다. `False`인 경우 [PptxEditException](https://reference.aspose.com/slides/ko/python-net/aspose.slides/pptxeditexception/)이 발생합니다.

추가 레이아웃을 대상 마스터에 도입하고 싶지 않다면 `False`를 사용하여 병합이 실패하도록 하십시오.

## **특정 대상 레이아웃을 사용한 슬라이드 병합**

가져온 슬라이드가 정확히 어떤 대상 레이아웃을 사용해야 하는지 알고 있는 경우 [add_clone(source_slide, destination_layout)](https://reference.aspose.com/slides/ko/python-net/aspose.slides/slidecollection/add_clone/) 오버로드를 사용하십시오.

```python
import aspose.slides as slides

with slides.Presentation("destination.pptx") as destination:
    with slides.Presentation("source.pptx") as source:
        destination_layout = destination.layout_slides[0]

        for slide in source.slides:
            destination.slides.add_clone(slide, destination_layout)

        destination.save("merged-with-destination-layout.pptx", slides.export.SaveFormat.PPTX)
```

대상 레이아웃을 적용하면 상속된 레이아웃 관계가 변경되며, 소스 슬라이드 내용 자체가 재설계되는 것은 아닙니다. 소스와 대상 레이아웃의 자리 표시자 구조가 다르면 결과를 검사하여 상속된 서식과 자리 표시자 동작이 적절한지 확인하십시오.

## **다른 슬라이드 크기를 가진 프레젠테이션 병합**

슬라이드 크기가 서로 다른 프레젠테이션도 병합할 수 있지만, 다른 슬라이드 크기를 가진 프레젠테이션에 슬라이드를 복제해도 콘텐츠가 자동으로 새로운 캔버스에 맞게 재설계되지 않습니다. 따라서 모양이 이동되거나, 비정상적으로 스케일되거나, 보이는 슬라이드 영역 밖으로 벗어날 수 있습니다.

실용적인 방법은 복제하기 전에 소스 프레젠테이션의 크기를 조정하는 것입니다. [SlideSize.set_size](https://reference.aspose.com/slides/ko/python-net/aspose.slides/slidesize/set_size/) 메서드를 사용하면 슬라이드 차원을 변경하면서 기존 콘텐츠를 스케일할 수 있습니다. [SlideSizeScaleType.ENSURE_FIT](https://reference.aspose.com/slides/ko/python-net/aspose.slides/slidesizescaletype/)은 콘텐츠를 요청된 크기에 맞게 조정합니다.

```python
import aspose.slides as slides

with slides.Presentation("destination.pptx") as destination:
    with slides.Presentation("source.pptx") as source:
        if (
            source.slide_size.size.width != destination.slide_size.size.width
            or source.slide_size.size.height != destination.slide_size.size.height
        ):
            source.slide_size.set_size(
                destination.slide_size.size.width,
                destination.slide_size.size.height,
                slides.SlideSizeScaleType.ENSURE_FIT)

        for slide in source.slides:
            destination.slides.add_clone(slide)

        destination.save("merged-same-slide-size.pptx", slides.export.SaveFormat.PPTX)
```

크기 조정은 메모리상의 소스 프레젠테이션 객체를 변경합니다. 다른 작업을 위해 원본 소스 프레젠테이션을 변경하지 않아야 한다면 병합을 위해 별도의 인스턴스를 열어 사용하십시오.

## **프레젠테이션 섹션에 슬라이드 병합**

기본 슬라이드 복제 루프는 소스 프레젠테이션의 섹션 계층 구조를 재현하지 않습니다. 출력에 섹션이 중요하다면 대상 프레젠테이션에 섹션을 만들거나 선택하고, [SlideCollection.add_clone](https://reference.aspose.com/slides/ko/python-net/aspose.slides/slidecollection/add_clone/)을 사용해 슬라이드를 명시적으로 해당 섹션에 복제하십시오.

```python
import aspose.slides as slides

with slides.Presentation("destination.pptx") as destination:
    with slides.Presentation("source.pptx") as source:
        imported_section = destination.sections.append_empty_section("Imported slides")

        for slide in source.slides:
            destination.slides.add_clone(slide, imported_section)

        destination.save("merged-with-section.pptx", slides.export.SaveFormat.PPTX)
```

복제된 슬라이드는 지정된 대상 섹션에 추가됩니다. 여러 소스 섹션을 보존하려면 [Presentation.sections](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/sections/)를 열거하고, 각 소스 섹션의 현재 슬라이드를 [Section.get_slides_list_of_section](https://reference.aspose.com/slides/ko/python-net/aspose.slides/section/get_slides_list_of_section/)로 가져온 뒤, 대상에 동일한 섹션을 재생성하고 반환된 각 슬라이드를 해당 대상 섹션에 복제하십시오. 전체 섹션 열거 예제는 [Manage Slide Sections](/slides/ko/python-net/slide-section/)에서 확인할 수 있으며, 빈 섹션 및 구조 변경을 포함합니다.

## **여러 프레젠테이션 안전하게 병합**

다음 엔드‑투‑엔드 예제는 첫 번째 프레젠테이션을 대상으로 사용하고, 각 추가 소스의 슬라이드 크기를 정규화하며, 각 소스를 복제 중에만 열고, 최종 파일을 한 번만 저장합니다.

```python
import aspose.slides as slides

input_files = ["part1.pptx", "part2.pptx", "part3.pptx"]

with slides.Presentation(input_files[0]) as merged:
    for file_index in range(1, len(input_files)):
        with slides.Presentation(input_files[file_index]) as source:
            if (
                source.slide_size.size.width != merged.slide_size.size.width
                or source.slide_size.size.height != merged.slide_size.size.height
            ):
                source.slide_size.set_size(
                    merged.slide_size.size.width,
                    merged.slide_size.size.height,
                    slides.SlideSizeScaleType.ENSURE_FIT)

            for slide in source.slides:
                merged.slides.add_clone(slide)

    merged.save("merged.pptx", slides.export.SaveFormat.PPTX)
```

이 방법은 가져온 슬라이드의 소스 서식을 보존하기 위한 유용한 기본선입니다. 출력에 단일 대상 테마를 사용해야 하는 경우 앞에서 소개한 대상 마스터 또는 대상 레이아웃 오버로드로 `add_clone(slide)` 호출을 교체하십시오.

## **실용적인 고려 사항**

### **마스터, 레이아웃 및 서식 정확도**

기본 슬라이드 복제는 필요한 경우 소스 마스터를 자동으로 대상 프레젠테이션에 가져올 수 있습니다. Aspose.Slides는 자동 복제된 마스터를 내부 레지스트리에 저장해 동일 마스터를 반복 복제하는 것을 방지합니다. 수동으로 복제한 마스터는 해당 레지스트리에 포함되지 않으므로, 마스터 구조에 대한 명시적 제어가 필요하지 않는 한 사전 복제를 피하십시오.

같은 이름을 가진 두 마스터 또는 레이아웃이 시각적으로 동일하다고 가정하지 마십시오. 기업 템플릿이 최종 모양을 제어해야 한다면 명시적으로 대상 마스터 또는 레이아웃을 선택하고 병합 후 결과를 검증하십시오.

### **노트 및 코멘트**

스피커 노트와 슬라이드 코멘트는 슬라이드 내용에 연결되어 있으며, 슬라이드 복제 시 함께 복사됩니다. Aspose.Slides는 또한 전용 API를 제공하며, 자세한 내용은 [presentation notes](/slides/ko/python-net/presentation-notes/)와 [presentation comments](/slides/ko/python-net/presentation-comments/)를 참조하십시오.

노트 페이지 서식이 중요하다면 병합된 프레젠테이션을 검증하십시오. 노트 마스터는 프레젠테이션 수준 객체이며 소스 파일마다 다를 수 있습니다. 리뷰 워크플로우에서는 다양한 작성자나 템플릿에서 결합된 파일의 코멘트 작성자와 스레드 코멘트를 검증하는 것이 좋습니다.

### **이미지, 오디오, 비디오, OLE 오브젝트 및 외부 링크**

슬라이드는 이미지, 삽입된 오디오·비디오, OLE 데이터와 같은 프레젠테이션 수준 리소스를 참조할 수 있습니다. 슬라이드 자체를 복제하여 Aspose.Slides가 해당 리소스와의 관계를 유지하도록 하십시오.

삽입된 리소스와 링크된 리소스를 구분해서 처리해야 합니다. 링크된 오디오·비디오·OLE 오브젝트·하이퍼링크는 외부 대상에 의존하므로, 슬라이드 복제만으로 외부 링크가 삽입된 콘텐츠로 전환되지 않습니다. 병합된 프레젠테이션이 열릴 환경에서 링크된 리소스 경로와 URL을 테스트하십시오.

Aspose.Slides는 자동 복제된 마스터를 추적하지만, 이는 서로 다른 소스 프레젠테이션에서 동일한 이진 리소스가 항상 중복 제거된다는 일반적인 보장을 의미하지는 않습니다. 출력 파일 크기가 중요한 경우 암묵적인 중복 제거에 의존하기보다는 병합된 패키지를 검사하고 결과를 측정하십시오.

### **임베디드 글꼴 및 글꼴 가용성**

글꼴은 프레젠테이션 수준에서 관리됩니다. 타이포그래피가 여러 컴퓨터에서 일관되어야 한다면 슬라이드 복제만으로 모든 필요한 글꼴이 대상 환경에 존재한다고 가정하지 마십시오. [FontsManager.get_embedded_fonts](https://reference.aspose.com/slides/ko/python-net/aspose.slides/fontsmanager/get_embedded_fonts/)을 사용해 임베디드 글꼴을 검사하고, [Embed Fonts in Presentations](/slides/ko/python-net/embedded-font/)에 설명된 대로 명시적으로 관리하십시오.

또한 소스 파일에서 사용된 글꼴을 임베드할 권한이 있는지 확인하십시오. 글꼴 라이선스가 임베드를 제한할 수 있습니다.

### **암호로 보호된 프레젠테이션**

암호로 보호된 소스는 슬라이드를 복제하기 전에 성공적으로 열어야 합니다. 비밀번호는 [LoadOptions.password](https://reference.aspose.com/slides/ko/python-net/aspose.slides/loadoptions/password/)를 통해 전달하십시오.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "YOUR_PASSWORD"

with slides.Presentation("protected.pptx", load_options) as source:
    print(len(source.slides))
```

암호화된 소스를 연다고 해서 동일한 보호가 자동으로 대상 프레젠테이션에 적용되는 것은 아닙니다. 필요한 경우 출력 보호를 별도로 구성하십시오.

### **대용량 프레젠테이션 및 메모리 사용**

고해상도 이미지, 오디오, 비디오 또는 기타 대용량 바이너리 객체를 포함한 대용량 프레젠테이션은 상당한 메모리를 소비할 수 있습니다. [LoadOptions.blob_management_options](https://reference.aspose.com/slides/ko/python-net/aspose.slides/loadoptions/blob_management_options/)은 BLOB 처리와 임시 파일 사용을 제어합니다. 대용량 파일 전략은 [Manage Presentation BLOBs](/slides/ko/python-net/manage-blob/)을 참조하십시오.

대용량 파일의 경우 가능한 경우 파일 경로에서 로드하고, 각 소스 프레젠테이션을 병합 후 즉시 닫으며, 워크플로우에 체크포인트가 필요하지 않은 한 중간 결과를 반복 저장하지 마십시오. `with slides.Presentation(...)` 구문을 사용하면 컨텍스트 종료 시 프레젠테이션 리소스가 해제됩니다.

### **스레드 안전성**

[Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 인스턴스를 여러 스레드에서 동시에 로드, 저장 또는 복제하지 마십시오. 각 병합 작업은 단일 스레드에서 수행해야 합니다. 독립적인 병합 작업을 병렬화해야 하는 경우 별도의 단일 스레드 프로세스와 독립적인 프레젠테이션 인스턴스를 사용하십시오. 자세한 내용은 [Aspose.Slides 멀티스레딩 가이드](/slides/ko/python-net/multithreading/)를 참조하십시오.

## **FAQ**

**각 소스 프레젠테이션의 원래 디자인을 유지하려면 어떻게 해야 하나요?**

대상 마스터나 레이아웃을 지정하지 않고 [add_clone](https://reference.aspose.com/slides/ko/python-net/aspose.slides/slidecollection/add_clone/)을 사용하십시오. Aspose.Slides는 가져온 슬라이드에 필요할 경우 자동으로 소스 마스터를 복제합니다.

**가져온 슬라이드가 대상 테마를 사용하도록 하려면 어떻게 해야 하나요?**

대상 마스터를 받아들이는 오버로드를 사용하십시오. 소스가 아닌 대상 프레젠테이션의 마스터를 전달하면 Aspose.Slides가 해당 마스터 아래에서 적절한 레이아웃을 매핑하려 시도합니다.

**대상 마스터 대신 특정 대상 레이아웃을 사용해야 할 때는 언제인가요?**

모든 가져온 슬라이드가 하나의 알려진 레이아웃을 사용해야 할 때는 특정 레이아웃을 사용하십시오. 소스 레이아웃 유형이나 이름에 따라 마스터의 여러 레이아웃 중 하나를 선택하도록 하려면 마스터를 사용하십시오.

**서로 다른 슬라이드 크기를 가진 프레젠테이션을 병합할 수 있나요?**

가능하지만 슬라이드 콘텐츠가 대상 차원에 맞게 자동으로 재설계되지는 않습니다. 예측 가능한 배치를 원한다면 [SlideSize.set_size](https://reference.aspose.com/slides/ko/python-net/aspose.slides/slidesize/set_size/)와 [SlideSizeScaleType.ENSURE_FIT](https://reference.aspose.com/slides/ko/python-net/aspose.slides/slidesizescaletype/)을 사용해 소스 프레젠테이션을 먼저 크기 조정하십시오.

**PPT, PPTX 및 ODP 프레젠테이션을 하나의 파일로 병합할 수 있나요?**

예. 각 소스 프레젠테이션을 로드하고, 필요한 슬라이드를 하나의 대상에 복제한 뒤, 지원되는 출력 형식으로 저장하십시오. 프레젠테이션 형식마다 지원하는 기능 집합이 정확히 동일하지 않으므로 교차 형식 병합 후 복잡한 콘텐츠를 검증해야 합니다. 자세한 내용은 [Supported File Formats](/slides/ko/python-net/supported-file-formats/)를 참조하십시오.

**소스 섹션이 자동으로 보존되나요?**

슬라이드만 복제하는 기본 루프에서는 섹션이 자동으로 보존되지 않습니다. 섹션 구조가 필요하면 대상에 섹션을 재생성하고, 섹션 오버로드가 있는 [add_clone](https://reference.aspose.com/slides/ko/python-net/aspose.slides/slidecollection/add_clone/)을 사용하십시오.

**스피커 노트와 코멘트가 보존되나요?**

복제된 슬라이드와 함께 복사됩니다. 노트 마스터 스타일링, 코멘트 작성자 또는 스레드된 리뷰 데이터를 의존하는 워크플로우에서는 병합 결과를 검증하십시오. 이러한 시나리오는 슬라이드 수준 콘텐츠뿐 아니라 프레젠테이션 수준 구조도 포함합니다.

**오디오, 비디오, OLE 오브젝트 및 하이퍼링크는 어떻게 처리되나요?**

삽입된 콘텐츠는 복제된 슬라이드의 리소스 관계에 포함됩니다. 외부 링크는 외부에 남아 있으므로 병합 후에도 해당 파일이나 URL이 여전히 접근 가능해야 합니다.

**모든 소스의 임베디드 글꼴이 병합된 프레젠테이션에 보장되나요?**

슬라이드 복제만으로 글꼴 배포를 보장하지 마십시오. 대상에 임베디드된 글꼴을 검사하고, 타이포그래피가 중요한 경우 글꼴 임베딩 또는 외부 글꼴 가용성을 명시적으로 관리하십시오.

**암호로 보호된 파일을 어떻게 병합하나요?**

올바른 [LoadOptions.password](https://reference.aspose.com/slides/ko/python-net/aspose.slides/loadoptions/password/)로 파일을 연 후 일반적으로 슬라이드를 복제하십시오. 출력 보호는 별도로 구성합니다.

**대용량 프레젠테이션을 어떻게 처리해야 하나요?**

대용량 바이너리 객체가 메모리 사용량을 차지할 때는 BLOB 관리 옵션을 사용하고, 가능한 경우 파일 경로 로드를 선호하며, 소스 프레젠테이션을 즉시 닫고, 최종 결과만 필요할 때 저장하십시오.

**여러 스레드에서 슬라이드를 병합할 수 있나요?**

[Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 인스턴스를 여러 스레드에서 로드, 저장 또는 복제하지 마십시오. 각 병합 작업은 단일 스레드로 유지하고, 별도의 병합 작업을 병렬화하려면 독립적인 단일 스레드 프로세스와 프레젠테이션 인스턴스를 사용하십시오.
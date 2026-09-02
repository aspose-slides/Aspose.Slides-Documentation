---
title: 효율적으로 파이썬으로 프레젠테이션 병합하기
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
description: "Python에서 슬라이드를 복제하고, 마스터와 레이아웃을 제어하며, 슬라이드 콘텐츠 크기를 조정하고, 섹션을 보존하며, 보호된 파일이나 대용량 파일을 처리함으로써 PowerPoint 및 OpenDocument 프레젠테이션을 병합하는 방법을 배웁니다."
---
## **개요**

Aspose.Slides for Python via .NET는 하나의 [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/)에서 슬라이드를 복제하여 다른 프레젠테이션에 병합합니다. 주요 작업은 [SlideCollection.add_clone](https://reference.aspose.com/slides/ko/python-net/aspose.slides/slidecollection/add_clone/)이며, 원본 슬라이드의 서식을 유지하거나 복제된 슬라이드를 대상 프레젠테이션의 마스터 또는 레이아웃에 연결할 수 있습니다.

이 문서에서는 가장 일반적인 병합 워크플로우를 다룹니다.

- 원본 서식을 유지하면서 모든 슬라이드 병합
- 선택된 슬라이드만 병합
- 대상 프레젠테이션의 마스터 적용
- 대상 프레젠테이션의 특정 레이아웃 적용
- 병합 전에 서로 다른 슬라이드 크기 정상화
- 섹션에 복제된 슬라이드 추가
- 하나의 엔드‑투‑엔드 워크플로우에서 여러 프레젠테이션 병합
- 마스터, 리소스, 메모, 댓글, 미디어, 폰트, 비밀번호, 대용량 파일, 멀티스레딩 등 고려 사항 처리

## **슬라이드 복제가 마스터와 레이아웃에 미치는 영향**

슬라이드는 레이아웃과 마스터에서 많은 외형을 상속받습니다. 따라서 선택한 복제 오버로드에 따라 병합된 슬라이드가 대상 프레젠테이션에 어떻게 통합되는지가 결정됩니다.

다음 중 하나의 방법으로 [SlideCollection.add_clone](https://reference.aspose.com/slides/ko/python-net/aspose.slides/slidecollection/add_clone/)을 사용하십시오.

- `add_clone(source_slide)` — 원본 슬라이드의 레이아웃과 서식을 유지합니다. 필요한 경우 원본 마스터가 자동으로 대상 프레젠테이션에 복제됩니다. Aspose.Slides는 자동 복제된 마스터를 추적하여 동일한 원본 마스터를 사용하는 반복 슬라이드가 마스터를 반복 복제하지 않도록 합니다.
- `add_clone(source_slide, destination_master, allow_clone_missing_layout)` — 복제된 슬라이드를 특정 대상 [IMasterSlide](https://reference.aspose.com/slides/ko/python-net/aspose.slides/imasterslide/)에 연결합니다. Aspose.Slides는 해당 마스터 아래에서 레이아웃 유형 또는 이름으로 일치하는 레이아웃을 찾습니다.
- `add_clone(source_slide, destination_layout)` — 복제된 슬라이드를 직접 특정 대상 [ILayoutSlide](https://reference.aspose.com/slides/ko/python-net/aspose.slides/ilayoutslide/)에 연결합니다.

`add_clone` 오버로드에 전달되는 마스터 또는 레이아웃은 **대상** 프레젠테이션에 속해야 하며, 원본 프레젠테이션에 속해서는 안 됩니다.

## **전체 프레젠테이션 병합 및 원본 서식 유지**

가장 간단한 병합 방식은 원본 프레젠테이션의 모든 슬라이드를 대상 프레젠테이션에 복사하는 것입니다. 이는 가져온 슬라이드가 원래 테마, 마스터 및 레이아웃 관계를 유지해야 할 때 적합합니다.

```python
import aspose.slides as slides

with slides.Presentation("destination.pptx") as destination:
    with slides.Presentation("source.pptx") as source:
        for slide in source.slides:
            destination.slides.add_clone(slide)

        destination.save("merged.pptx", slides.export.SaveFormat.PPTX)
```

소스와 대상이 서로 다른 디자인을 사용할 경우 결과 프레젠테이션에 여러 마스터가 포함될 수 있습니다. 이는 원본 서식을 의도적으로 유지할 때 예상되는 동작입니다.

## **선택된 슬라이드 병합**

모든 슬라이드를 복제할 필요는 없습니다. 다음 예제는 원본 프레젠테이션에서 선택된 슬라이드 인덱스만 가져옵니다.

```python
import aspose.slides as slides

with slides.Presentation("destination.pptx") as destination:
    with slides.Presentation("source.pptx") as source:
        slide_indexes = [0, 2, 4]

        for index in slide_indexes:
            destination.slides.add_clone(source.slides[index])

        destination.save("merged-selected-slides.pptx", slides.export.SaveFormat.PPTX)
```

사용자 입력이나 외부 설정에서 슬라이드 인덱스를 받아올 경우 복제 전에 인덱스를 반드시 검증하십시오.

## **대상 마스터 사용 병합**

가져온 슬라이드가 이미 대상 프레젠테이션에 존재하는 마스터를 따라야 하는 경우 [add_clone(source_slide, destination_master, allow_clone_missing_layout)](https://reference.aspose.com/slides/ko/python-net/aspose.slides/slidecollection/add_clone/) 오버로드를 사용하십시오.

```python
import aspose.slides as slides

with slides.Presentation("destination.pptx") as destination:
    with slides.Presentation("source.pptx") as source:
        destination_master = destination.masters[0]

        for slide in source.slides:
            destination.slides.add_clone(slide, destination_master, True)

        destination.save("merged-with-destination-master.pptx", slides.export.SaveFormat.PPTX)
```

Aspose.Slides는 지정된 마스터 아래에서 소스 레이아웃의 유형이나 이름과 일치하는 적절한 레이아웃을 선택합니다. 적합한 레이아웃이 없고 `allow_clone_missing_layout`이 `True`이면 소스 레이아웃이 복제되어 슬라이드를 추가할 수 있게 됩니다. `False`인 경우 [PptxEditException](https://reference.aspose.com/slides/ko/python-net/aspose.slides/pptxeditexception/)이 발생합니다.

추가 레이아웃을 대상 마스터에 도입하고 싶지 않을 경우 `False`를 사용하여 병합이 실패하도록 하십시오.

## **특정 대상 레이아웃 사용 병합**

가져온 슬라이드가 정확히 어떤 대상 레이아웃을 사용해야 하는지 알고 있다면 [add_clone(source_slide, destination_layout)](https://reference.aspose.com/slides/ko/python-net/aspose.slides/slidecollection/add_clone/) 오버로드를 사용하십시오.

```python
import aspose.slides as slides

with slides.Presentation("destination.pptx") as destination:
    with slides.Presentation("source.pptx") as source:
        destination_layout = destination.layout_slides[0]

        for slide in source.slides:
            destination.slides.add_clone(slide, destination_layout)

        destination.save("merged-with-destination-layout.pptx", slides.export.SaveFormat.PPTX)
```

대상 레이아웃을 적용하면 상속된 레이아웃 관계만 변경되며, 소스 슬라이드 내용 자체가 재디자인되는 것은 아닙니다. 소스와 대상 레이아웃이 서로 다른 자리표시자 구조를 가지고 있다면 결과를 검사하여 상속된 서식 및 자리표시자 동작이 적절한지 확인하십시오.

## **다른 슬라이드 크기를 가진 프레젠테이션 병합**

슬라이드 크기가 다른 프레젠테이션도 병합할 수 있지만, 다른 슬라이드 크기를 가진 프레젠테이션에 슬라이드를 복제한다고 해서 내용이 자동으로 새로운 캔버스에 맞게 재디자인되지는 않습니다. 따라서 도형이 이동되거나, 비정상적으로 확대/축소되거나, 보이는 슬라이드 영역 밖에 위치할 수 있습니다.

실용적인 방법은 복제하기 전에 원본 프레젠테이션의 크기를 조정하는 것입니다. [SlideSize.set_size](https://reference.aspose.com/slides/ko/python-net/aspose.slides/slidesize/set_size/) 메서드는 슬라이드 크기를 변경하면서 기존 콘텐츠를 스케일링할 수 있습니다. [SlideSizeScaleType.ENSURE_FIT](https://reference.aspose.com/slides/ko/python-net/aspose.slides/slidesizescaletype/)은 지정된 크기에 맞게 콘텐츠를 자동으로 맞춥니다.

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

크기 조정은 메모리 상의 원본 프레젠테이션 객체를 변경합니다. 다른 작업을 위해 원본 프레젠테이션을 그대로 유지해야 한다면 별도의 인스턴스를 열어 병합을 수행하십시오.

## **프레젠테이션 섹션에 슬라이드 병합**

기본 슬라이드 복제 루프는 원본 프레젠테이션의 섹션 계층 구조를 재생성하지 않습니다. 출력에 섹션이 중요하다면 대상 프레젠테이션에서 섹션을 만들거나 선택한 뒤, [SlideCollection.add_clone](https://reference.aspose.com/slides/ko/python-net/aspose.slides/slidecollection/add_clone/)을 사용해 명시적으로 해당 섹션에 슬라이드를 복제하십시오.

```python
import aspose.slides as slides

with slides.Presentation("destination.pptx") as destination:
    with slides.Presentation("source.pptx") as source:
        imported_section = destination.sections.append_empty_section("Imported slides")

        for slide in source.slides:
            destination.slides.add_clone(slide, imported_section)

        destination.save("merged-with-section.pptx", slides.export.SaveFormat.PPTX)
```

복제된 슬라이드는 지정된 대상 섹션에 추가됩니다. 여러 원본 섹션을 보존하려면 [SectionCollection.append_empty_section](https://reference.aspose.com/slides/ko/python-net/aspose.slides/sectioncollection/append_empty_section/)으로 대상에 동일한 섹션을 만들고 각 원본 슬라이드를 해당 섹션에 매핑하십시오.

## **여러 프레젠테이션 안전하게 병합**

다음 엔드‑투‑엔드 예제는 첫 번째 프레젠테이션을 대상으 로 사용하고, 추가 소스마다 슬라이드 크기를 정상화하며, 각 소스를 복사하는 동안만 열고, 마지막에 한 번만 파일을 저장합니다.

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

이는 가져온 슬라이드의 원본 서식을 유지하기 위한 유용한 베이스라인입니다. 출력에 단일 대상 테마를 사용해야 한다면 앞서 소개한 대상‑마스터 또는 대상‑레이아웃 오버로드를 사용하도록 `add_clone(slide)` 호출을 교체하십시오.

## **실용적인 고려 사항**

### **마스터, 레이아웃 및 서식 충실도**

기본 슬라이드 복제는 필요한 원본 마스터를 자동으로 대상 프레젠테이션에 가져올 수 있습니다. Aspose.Slides는 자동 복제된 마스터를 내부 레지스트리에 기록해 동일 마스터를 반복 복제하는 것을 방지합니다. 수동으로 복제된 마스터는 해당 레지스트리에 기록되지 않으므로, 특별히 마스터 구조를 제어해야 할 경우가 아니라면 사전 복제는 피하십시오.

같은 이름을 가진 두 마스터 또는 레이아웃이 시각적으로 동일하다고 가정하지 마십시오. 기업 템플릿이 최종 모습을 제어해야 한다면 대상 마스터 또는 레이아웃을 명시적으로 선택하고 병합 후 결과를 검증하십시오.

### **메모 및 댓글**

슬라이드 메모와 댓글은 슬라이드 콘텐츠와 연결되어 있으며, 슬라이드가 복제될 때 함께 복사됩니다. Aspose.Slides는 또한 [presentation notes](https://docs.aspose.com/slides/ko/python-net/presentation-notes/)와 [presentation comments](https://docs.aspose.com/slides/ko/python-net/presentation-comments/)를 위한 전용 API를 제공합니다.

메모 페이지 서식이 중요하다면, 메모 마스터가 프레젠테이션 수준 객체이므로 파일마다 다를 수 있음을 염두에 두고 병합된 프레젠테이션을 검증하십시오. 리뷰 워크플로우에서는 서로 다른 저자나 템플릿에서 결합한 파일의 댓글 작성자와 스레드 구조도 확인해야 합니다.

### **이미지, 오디오, 비디오, OLE 객체 및 외부 링크**

슬라이드는 이미지, 삽입 오디오, 삽입 비디오, OLE 데이터와 같은 프레젠테이션 수준 리소스를 참조할 수 있습니다. 슬라이드 자체를 복제하십시오. 표시되는 도형만 복사하면 Aspose.Slides가 해당 리소스와의 관계를 유지하지 못합니다.

삽입된 리소스와 연결된 리소스는 다르게 취급해야 합니다. 연결된 오디오, 비디오, OLE 객체 또는 하이퍼링크는 외부 대상에 의존하므로 슬라이드를 복제한다고 외부 링크가 삽입 콘텐츠로 변환되지 않습니다. 병합된 프레젠테이션이 열릴 환경에서 연결된 리소스 경로와 URL을 테스트하십시오.

자동 복제된 마스터를 추적한다 하더라도, 서로 다른 소스 프레젠테이션에서 동일한 바이너리 리소스가 항상 중복 제거된다는 일반적인 보장은 아닙니다. 출력 파일 크기가 중요하다면 병합된 패키지를 직접 검사하고 결과를 측정하십시오.

### **임베디드 폰트 및 폰트 가용성**

폰트는 프레젠테이션 수준에서 관리됩니다. 타이포그래피가 머신 간에 일관되어야 한다면, 슬라이드 복제만으로 모든 필요한 폰트가 대상 환경에 존재한다고 가정하지 마십시오. [FontsManager.get_embedded_fonts](https://reference.aspose.com/slides/ko/python-net/aspose.slides/fontsmanager/get_embedded_fonts/)으로 임베디드 폰트를 확인하고, [Embed Fonts in Presentations](https://docs.aspose.com/slides/ko/python-net/embedded-font/)에 설명된 대로 명시적으로 임베드하십시오.

또한 소스 파일에서 사용된 폰트를 임베드할 권한이 있는지 확인하십시오. 폰트 라이선스가 임베드를 제한할 수 있습니다.

### **비밀번호로 보호된 프레젠테이션**

비밀번호로 보호된 소스는 슬라이드를 복제하기 전에 반드시 정상적으로 열어야 합니다. 비밀번호는 [LoadOptions.password](https://reference.aspose.com/slides/ko/python-net/aspose.slides/loadoptions/password/)를 통해 전달하십시오.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "YOUR_PASSWORD"

with slides.Presentation("protected.pptx", load_options) as source:
    print(len(source.slides))
```

암호화된 소스를 열었다고 해서 동일한 보호가 자동으로 대상 프레젠테이션에 적용되는 것은 아닙니다. 필요 시 출력 보호를 별도로 설정하십시오.

### **대용량 프레젠테이션 및 메모리 사용**

고해상도 이미지, 오디오, 비디오 또는 기타 대용량 바이너리 객체를 포함한 대용량 프레젠테이션은 상당한 메모리를 소모할 수 있습니다. [LoadOptions.blob_management_options](https://reference.aspose.com/slides/ko/python-net/aspose.slides/loadoptions/blob_management_options/)은 BLOB 처리 및 임시 파일 사용을 제어합니다. 대용량 파일 전략은 [Manage Presentation BLOBs](https://docs.aspose.com/slides/ko/python-net/manage-blob/)를 참고하십시오.

대용량 파일의 경우 가능한 한 파일 경로에서 로드하고, 각 소스 프레젠테이션을 병합이 끝난 즉시 닫으며, 워크플로우에 체크포인트가 필요하지 않은 한 중간 결과를 반복 저장하지 마십시오. `with slides.Presentation(...)` 구문을 사용하면 컨텍스트 종료 시 프레젠테이션 리소스가 자동으로 해제됩니다.

### **스레드 안전성**

[Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 인스턴스를 여러 스레드에서 동시에 로드, 저장 또는 복제하지 마십시오. 각 병합 작업은 단일 스레드에서 수행해야 합니다. 독립적인 병합 작업을 병렬화해야 할 경우, 별도의 단일 스레드 프로세스와 독립적인 프레젠테이션 인스턴스를 사용하십시오. 자세한 내용은 [Aspose.Slides 멀티스레딩 가이드](https://docs.aspose.com/slides/ko/python-net/multithreading/)를 참고하십시오.

## **FAQ**

**각 소스 프레젠테이션의 원본 디자인을 유지하려면 어떻게 해야 하나요?**

대상 마스터나 레이아웃을 지정하지 않고 [`add_clone(source_slide)`](https://reference.aspose.com/slides/ko/python-net/aspose.slides/slidecollection/add_clone/)를 사용하십시오. Aspose.Slides는 가져온 슬라이드에 필요할 경우 원본 마스터를 자동으로 복제합니다.

**가져온 슬라이드가 대상 테마를 사용하도록 하려면 어떻게 해야 하나요?**

대상 마스터를 받는 오버로드를 사용하십시오. 원본이 아닌 대상 프레젠테이션의 마스터를 전달하면 Aspose.Slides가 각 소스 슬라이드를 해당 마스터 아래의 적절한 레이아웃에 매핑하려 시도합니다.

**언제 특정 대상 레이아웃을 사용하고, 언제 대상 마스터를 사용해야 하나요?**

모든 가져온 슬라이드가 동일한 알려진 레이아웃을 사용해야 할 경우 특정 레이아웃을 사용하십시오. 슬라이드마다 소스 레이아웃 유형이나 이름에 따라 마스터의 여러 레이아웃 중 하나를 선택하도록 하려면 마스터를 사용하십시오.

**다른 슬라이드 크기를 가진 프레젠테이션을 병합할 수 있나요?**

가능하지만 슬라이드 내용이 자동으로 대상 크기에 맞게 재디자인되지는 않습니다. 예측 가능한 배치를 원한다면 [SlideSize.set_size](https://reference.aspose.com/slides/ko/python-net/aspose.slides/slidesize/set_size/)와 [SlideSizeScaleType.ENSURE_FIT](https://reference.aspose.com/slides/ko/python-net/aspose.slides/slidesizescaletype/)를 사용해 먼저 소스 프레젠테이션을 리사이즈하십시오.

**PPT, PPTX 및 ODP 프레젠테이션을 하나의 파일로 병합할 수 있나요?**

네. 각 소스 프레젠테이션을 로드하고, 필요한 슬라이드를 하나의 대상에 복제한 뒤, 지원되는 출력 포맷으로 저장하면 됩니다. 프레젠테이션 포맷마다 지원 기능이 정확히 동일하지 않을 수 있으므로, 크로스 포맷 병합 후에는 복잡한 콘텐츠를 반드시 검증하십시오. 자세한 내용은 [Supported File Formats](https://docs.aspose.com/slides/ko/python-net/supported-file-formats/)를 참조하십시오.

**소스 섹션이 자동으로 보존되나요?**

슬라이드만 복제하는 기본 루프에서는 섹션이 자동으로 보존되지 않습니다. 섹션 구조가 필요하면 대상에 해당 섹션을 재생성하고, 섹션 오버로드를 사용해 `add_clone`을 호출하십시오.

**스피커 메모와 댓글이 보존되나요?**

복제된 슬라이드와 함께 복사됩니다. 메모 마스터 스타일링, 댓글 작성자 및 스레드 리뷰 데이터에 의존하는 워크플로우에서는 병합 결과를 반드시 검증하십시오. 이러한 시나리오는 프레젠테이션 수준 구조와 슬라이드 수준 콘텐츠 모두에 영향을 미칩니다.

**오디오, 비디오, OLE 객체 및 하이퍼링크는 어떻게 처리되나요?**

삽입된 콘텐츠는 복제된 슬라이드의 리소스 관계에 포함됩니다. 외부 링크는 외부에 남아 있으므로, 병합 후에도 해당 파일이나 URL이 여전히 접근 가능해야 합니다.

**모든 소스의 임베디드 폰트가 병합된 프레젠테이션에 보장되나요?**

슬라이드 복제만으로 폰트 배포를 보장하지 마십시오. 대상 프레젠테이션의 임베디드 폰트를 확인하고, 타이포그래피가 중요한 경우 폰트 임베드 또는 외부 폰트 가용성을 명시적으로 관리하십시오.

**비밀번호가 걸린 파일을 어떻게 병합하나요?**

올바른 [LoadOptions.password](https://reference.aspose.com/slides/ko/python-net/aspose.slides/loadoptions/password/)로 파일을 연 후 일반적으로 슬라이드를 복제하면 됩니다. 출력 보호는 별도로 설정하십시오.

**매우 큰 프레젠테이션을 어떻게 처리해야 하나요?**

BLOB 관리 옵션을 사용해 대용량 바이너리 객체의 메모리 사용을 제어하고, 가능한 경우 파일 경로 로드를 선호하며, 소스 프레젠테이션을 즉시 닫고, 최종 결과를 필요할 때만 저장하십시오.

**여러 스레드에서 슬라이드를 병합할 수 있나요?**

[Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 인스턴스를 여러 스레드에서 동시에 로드, 저장 또는 복제하지 마십시오. 각 병합 작업은 단일 스레드에서 수행하고, 별도의 병합 작업을 병렬화해야 한다면 독립적인 단일 스레드 프로세스와 프레젠테이션 인스턴스를 사용하십시오.
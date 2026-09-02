---
title: Python에서 로우코드 프레젠테이션 작업
linktitle: 로우코드 API
type: docs
weight: 50
url: /ko/python-net/low-code-presentation-operations/
keywords:
- 로우코드 프레젠테이션 API
- 프레젠테이션 변환
- 프레젠테이션 병합
- 도형 수집
- 프레젠테이션 압축
- 사용되지 않는 마스터 슬라이드 제거
- 사용되지 않는 레이아웃 슬라이드 제거
- 내장 폰트 압축
- PowerPoint
- OpenDocument
- 프레젠테이션
- Python
- Aspose.Slides
description: "Python에서 Aspose.Slides 로우코드 API를 사용하여 프레젠테이션을 변환·병합하고, 도형을 수집하며, 프레젠테이션 크기를 줄입니다."
---
## **개요**

[aspose.slides.lowcode](https://reference.aspose.com/slides/ko/python-net/aspose.slides.lowcode/) 모듈은 일반적인 프레젠테이션 작업을 위한 도우미 클래스를 제공합니다. 이러한 도우미는 자주 사용되는 객체 모델 워크플로를 집중된 메서드로 래핑하므로, 코드를 적게 사용하여 파일을 변환하거나 병합하고, 도형을 수집하며, 사용되지 않는 콘텐츠를 제거할 수 있습니다.

Low-code 도우미는 작업이 전체 파일이나 프레젠테이션에 적용되고 기본 워크플로가 요구 사항에 맞을 때 가장 유용합니다. 개별 슬라이드, 마스터, 레이아웃, 도형, 내보내기 설정 또는 프레젠테이션 요소 간 관계에 대해 세밀한 제어가 필요한 경우 전체 [Aspose.Slides 객체 모델](https://reference.aspose.com/slides/ko/python-net/aspose.slides/)을 사용하십시오.

다음 표는 사용 가능한 도우미를 요약한 것입니다:

| 도우미 | 사용 목적 |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/ko/python-net/aspose.slides.lowcode/convert/) | 파일 간 직접 호출로 프레젠테이션을 다른 형식으로 변환합니다. |
| [Merger](https://reference.aspose.com/slides/ko/python-net/aspose.slides.lowcode/merger/) | 같은 형식의 전체 프레젠테이션 파일을 결합합니다. |
| [Collect](https://reference.aspose.com/slides/ko/python-net/aspose.slides.lowcode/collect/) | 전체 프레젠테이션에서 도형을 가져와 반복 처리나 분석에 사용합니다. |
| [Compress](https://reference.aspose.com/slides/ko/python-net/aspose.slides.lowcode/compress/) | 사용되지 않는 마스터와 레이아웃을 제거하고 포함된 폰트 데이터를 축소합니다. |

## **프레젠테이션 변환**

출력 파일 확장자만으로 내보내기 형식을 선택할 수 있는 경우 [Convert.auto_by_extension](https://reference.aspose.com/slides/ko/python-net/aspose.slides.lowcode/convert/auto_by_extension/)을 사용하십시오. 이 메서드는 원본 프레젠테이션을 열고, 출력 경로에서 필요한 형식을 판단한 다음 결과를 기록합니다.

```python
import aspose.slides as slides

slides.lowcode.Convert.auto_by_extension("input.pptx", "output.pdf")
```

[Convert](https://reference.aspose.com/slides/ko/python-net/aspose.slides.lowcode/convert/) 클래스는 PDF, SVG, JPEG, PNG, TIFF 출력 전용 메서드도 제공합니다. 내보내기 전 프레젠테이션을 검사·수정하거나 선택된 도우미가 노출하지 않는 내보내기 옵션을 구성해야 하는 경우 전체 객체 모델을 사용하십시오. 형식별 워크플로와 옵션은 [Convert Presentation](/slides/ko/python-net/convert-presentation/)를 참고하십시오.

## **프레젠테이션 병합**

전체 프레젠테이션 파일을 한 번에 결합하려면 [Merger.process](https://reference.aspose.com/slides/ko/python-net/aspose.slides.lowcode/merger/process/)를 사용하십시오. 입력 프레젠테이션은 동일한 파일 형식이어야 합니다.

```python
import aspose.slides as slides

input_files = ["part-1.pptx", "part-2.pptx"]
slides.lowcode.Merger.process(input_files, "merged.pptx")
```

이 도우미는 모든 슬라이드를 선택하거나 개별 매핑 없이 하나의 결과에 추가해야 할 때 적합합니다. 선택된 슬라이드만 병합하거나 대상 마스터·레이아웃을 적용하고, 섹션을 명시적으로 보존하거나 서로 다른 슬라이드 크기를 조정해야 하는 경우 전체 객체 모델을 사용하십시오. 해당 시나리오는 [Merge Presentations](/slides/ko/python-net/merge-presentation/)를 참고하십시오.

## **도형 수집**

프레젠테이션 내 모든 도형을 한 번에 수집해야 할 때는 [Collect.shapes](https://reference.aspose.com/slides/ko/python-net/aspose.slides.lowcode/collect/shapes/)를 사용하십시오. 동일한 도형 집합을 여러 번 필터링·계산·처리하려는 경우에 유용합니다.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    shapes = slides.lowcode.Collect.shapes(presentation)

    for shape in shapes:
        print(f"{shape.name}: {type(shape).__name__}")
```

遍历 순서, 조기 종료, 처리 전 필터링 또는 상세한 부모‑자식 제어가 필요할 경우 직접 컬렉션 루프를 사용하는 것이 좋습니다.

## **프레젠테이션 콘텐츠 압축**

[Compress](https://reference.aspose.com/slides/ko/python-net/aspose.slides.lowcode/compress/) 클래스는 사용되지 않는 구조 요소를 제거하고 포함된 폰트 데이터를 축소할 수 있습니다:

- [Compress.remove_unused_layout_slides](https://reference.aspose.com/slides/ko/python-net/aspose.slides.lowcode/compress/remove_unused_layout_slides/) — 일반 슬라이드가 참조하지 않는 레이아웃 슬라이드를 제거합니다.
- [Compress.remove_unused_master_slides](https://reference.aspose.com/slides/ko/python-net/aspose.slides.lowcode/compress/remove_unused_master_slides/) — 더 이상 사용되지 않는 마스터 슬라이드를 제거합니다.
- [Compress.compress_embedded_fonts](https://reference.aspose.com/slides/ko/python-net/aspose.slides.lowcode/compress/compress_embedded_fonts/) — 포함된 폰트에서 사용되지 않는 문자를 제거합니다.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slides.lowcode.Compress.remove_unused_layout_slides(presentation)
    slides.lowcode.Compress.remove_unused_master_slides(presentation)
    slides.lowcode.Compress.compress_embedded_fonts(presentation)

    presentation.save("compressed.pptx", slides.export.SaveFormat.PPTX)
```

레이아웃을 먼저 제거하고 그 다음에 마스터를 제거하십시오. 레이아웃 정리 후에 참조가 사라진 마스터도 함께 삭제할 수 있습니다. 원본 마스터, 레이아웃 또는 전체 포함 폰트 데이터가 나중에 필요할 수 있으므로 최적화된 프레젠테이션을 새 파일에 저장하십시오. 자세한 내용은 [Slide Master](/slides/ko/python-net/slide-master/)와 [Embedded Font](/slides/ko/python-net/embedded-font/)를 참고하십시오.

## **FAQ**

**Low-code API를 전체 객체 모델 대신 언제 사용해야 하나요?**

표준 작업이 전체 파일이나 프레젠테이션에 적용되고 개별 요소에 대한 세부 제어가 필요하지 않을 때 Low-code 도우미를 사용합니다. 특정 슬라이드를 선택하거나 마스터·레이아웃 관계를 제어하고, 중간 상태를 검사하거나 도우미가 노출하지 않는 동작을 구성해야 할 경우 전체 객체 모델을 사용하십시오.

**Merger가 서로 다른 파일 형식의 프레젠테이션을 결합할 수 있나요?**

아니오. [Merger.process](https://reference.aspose.com/slides/ko/python-net/aspose.slides.lowcode/merger/process/)는 입력 프레젠테이션이 동일한 형식이어야 합니다. 먼저 [Convert.auto_by_extension](https://reference.aspose.com/slides/ko/python-net/aspose.slides.lowcode/convert/auto_by_extension/) 등으로 파일을 동일한 형식으로 변환한 뒤 병합하십시오.

**Collect.shapes에는 무엇이 포함되나요?**

[Collect.shapes](https://reference.aspose.com/slides/ko/python-net/aspose.slides.lowcode/collect/shapes/)는 프레젠테이션에서 도형을 가져와 유지·필터링·계산·다중 순회를 할 수 있게 합니다. 슬라이드 유형이나 중첩 객체를 정확히 제어해야 할 경우 직접 컬렉션 루프를 사용하십시오.

**Compress는 항상 프레젠테이션 파일을 작게 만들까요?**

반드시 그렇지는 않습니다. 결과는 프레젠테이션에 사용되지 않는 레이아웃·마스터·사용되지 않은 문자(포함된 폰트)가 존재하느냐에 따라 달라집니다. 해당 요소가 없으면 [Compress](https://reference.aspose.com/slides/ko/python-net/aspose.slides.lowcode/compress/) 작업이 파일 크기를 줄이지 않을 수 있습니다.

**Compress가 수행한 변경 사항은 자동으로 저장되나요?**

아니오. 이 도우미들은 메모리 내에서 로드된 [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 객체에만 영향을 줍니다. [Compress](https://reference.aspose.com/slides/ko/python-net/aspose.slides.lowcode/compress/)를 실행한 후에는 [Presentation.save](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/save/)를 호출하여 결과를 파일에 기록해야 합니다.

## **관련 문서**

- [Convert Presentation](/slides/ko/python-net/convert-presentation/)
- [Merge Presentations](/slides/ko/python-net/merge-presentation/)
- [Slide Master](/slides/ko/python-net/slide-master/)
- [Manage Text Box](/slides/ko/python-net/manage-textbox/)
- [Embedded Font](/slides/ko/python-net/embedded-font/)
---
title: 파이썬에서 로우코드 프레젠테이션 작업
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
- 포함된 글꼴 압축
- PowerPoint
- OpenDocument
- 프레젠테이션
- Python
- Aspose.Slides
description: "파이썬에서 Aspose.Slides 로우코드 API를 사용하여 프레젠테이션을 변환 및 병합하고, 도형을 수집하며, 프레젠테이션 크기를 줄입니다."
---
## **개요**

[aspose.slides.lowcode](https://reference.aspose.com/slides/ko/python-net/aspose.slides.lowcode/) 모듈은 일반 프레젠테이션 작업을 위한 도우미 클래스를 제공합니다. 이러한 도우미는 자주 사용되는 객체 모델 워크플로를 집중된 메서드로 감싸며, 파일을 변환하거나 병합하고, 도형을 수집하며, 사용되지 않는 콘텐츠를 더 적은 코드로 제거할 수 있게 합니다.

Low-code 도우미는 작업이 전체 파일 또는 프레젠테이션에 적용되고 기본 워크플로가 요구 사항에 맞을 때 가장 유용합니다. 개별 슬라이드, 마스터, 레이아웃, 도형, 내보내기 설정 또는 프레젠테이션 요소 간 관계에 대해 세밀한 제어가 필요할 경우 전체 [Aspose.Slides object model](https://reference.aspose.com/slides/ko/python-net/aspose.slides/)을 사용하십시오.

다음 표는 사용 가능한 도우미를 요약합니다:

| 도우미 | 용도 |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/ko/python-net/aspose.slides.lowcode/convert/) | 파일 간 직접 호출로 프레젠테이션을 다른 형식으로 변환합니다. |
| [Merger](https://reference.aspose.com/slides/ko/python-net/aspose.slides.lowcode/merger/) | 동일한 형식의 전체 프레젠테이션 파일을 결합합니다. |
| [Collect](https://reference.aspose.com/slides/ko/python-net/aspose.slides.lowcode/collect/) | 전체 프레젠테이션에서 도형을 가져와 반복 처리 또는 분석에 사용합니다. |
| [Compress](https://reference.aspose.com/slides/ko/python-net/aspose.slides.lowcode/compress/) | 사용되지 않는 마스터와 레이아웃을 제거하고 포함된 글꼴 데이터를 줄입니다. |

## **프레젠테이션 변환**

[Convert.auto_by_extension](https://reference.aspose.com/slides/ko/python-net/aspose.slides.lowcode/convert/auto_by_extension/) 를 사용하면 출력 파일 확장자만으로 내보내기 형식을 자동 선택할 수 있습니다. 이 메서드는 원본 프레젠테이션을 열고, 출력 경로에서 필요한 형식을 결정한 뒤 결과를 기록합니다.

```python
import aspose.slides as slides

slides.lowcode.Convert.auto_by_extension("input.pptx", "output.pdf")
```

[Convert](https://reference.aspose.com/slides/ko/python-net/aspose.slides.lowcode/convert/) 클래스는 PDF, SVG, JPEG, PNG, TIFF 출력 전용 메서드도 제공합니다. 내보내기 전에 프레젠테이션을 검사하거나 수정해야 하거나, 선택된 도우미에서 제공하지 않는 내보내기 옵션을 구성해야 할 경우 전체 객체 모델을 사용하십시오. 형식별 워크플로와 옵션은 [Convert Presentation](/python-net/convert-presentation/) 를 참조하십시오.

## **프레젠테이션 병합**

[Merger.process](https://reference.aspose.com/slides/ko/python-net/aspose.slides.lowcode/merger/process/) 를 사용하면 한 번의 호출로 전체 프레젠테이션 파일을 결합할 수 있습니다. 입력 프레젠테이션은 동일한 파일 형식이어야 합니다.

```python
import aspose.slides as slides

input_files = ["part-1.pptx", "part-2.pptx"]
slides.lowcode.Merger.process(input_files, "merged.pptx")
```

이 도우미는 모든 슬라이드를 개별 선택이나 매핑 없이 하나의 결과에 추가해야 할 때 적합합니다. 선택된 슬라이드만 병합하거나 대상 마스터나 레이아웃을 적용하고, 섹션을 명시적으로 보존하거나 서로 다른 슬라이드 크기를 조정해야 할 경우 전체 객체 모델을 사용하십시오. 이러한 시나리오는 [Merge Presentations](/python-net/merge-presentation/) 를 참고하십시오.

## **도형 수집**

[Collect.shapes](https://reference.aspose.com/slides/ko/python-net/aspose.slides.lowcode/collect/shapes/) 를 사용하면 프레젠테이션의 모든 도형을 컬렉션으로 얻을 수 있습니다. 동일한 도형 집합을 여러 번 필터링, 카운트 또는 처리해야 할 때 유용합니다.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    shapes = slides.lowcode.Collect.shapes(presentation)

    for shape in shapes:
        print(f"{shape.name}: {type(shape).__name__}")
```

순회 순서, 조기 종료, 처리 전 필터링, 부모-자식 관계에 대한 세밀한 제어가 중요한 경우 직접 컬렉션 루프를 사용하십시오.

## **프레젠테이션 콘텐츠 압축**

[Compress](https://reference.aspose.com/slides/ko/python-net/aspose.slides.lowcode/compress/) 클래스는 사용되지 않는 구조 요소를 제거하고 포함된 글꼴 데이터를 줄일 수 있습니다:

- [Compress.remove_unused_layout_slides](https://reference.aspose.com/slides/ko/python-net/aspose.slides.lowcode/compress/remove_unused_layout_slides/) 은 일반 슬라이드가 참조하지 않는 레이아웃 슬라이드를 제거합니다.
- [Compress.remove_unused_master_slides](https://reference.aspose.com/slides/ko/python-net/aspose.slides.lowcode/compress/remove_unused_master_slides/) 은 더 이상 사용되지 않는 마스터 슬라이드를 제거합니다.
- [Compress.compress_embedded_fonts](https://reference.aspose.com/slides/ko/python-net/aspose.slides.lowcode/compress/compress_embedded_fonts/) 은 포함된 글꼴에서 사용되지 않는 문자를 제거합니다.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slides.lowcode.Compress.remove_unused_layout_slides(presentation)
    slides.lowcode.Compress.remove_unused_master_slides(presentation)
    slides.lowcode.Compress.compress_embedded_fonts(presentation)

    presentation.save("compressed.pptx", slides.export.SaveFormat.PPTX)
```

사용되지 않는 레이아웃을 먼저 제거하고 그 다음 사용되지 않는 마스터를 제거하십시오. 레이아웃 정리 후에 참조되지 않게 된 마스터도 제거할 수 있습니다. 원본 마스터, 레이아웃 또는 전체 포함 글꼴 데이터를 나중에 필요할 수 있는 경우 최적화된 프레젠테이션을 새 파일에 저장하십시오. 자세한 내용은 [Slide Master](/python-net/slide-master/) 및 [Embedded Font](/python-net/embedded-font/) 를 참조하십시오.

## **FAQ**

**Low-code API를 전체 객체 모델 대신 언제 사용해야 하나요?**

표준 작업이 전체 파일 또는 프레젠테이션에 적용되고 개별 요소에 대한 세밀한 제어가 필요하지 않을 때 Low-code 도우미를 사용하십시오. 특정 슬라이드를 선택하거나 마스터 및 레이아웃 관계를 제어하고, 중간 상태를 검사하거나 도우미가 제공하지 않는 동작을 구성해야 할 경우 전체 객체 모델을 사용하십시오.

**Merger가 서로 다른 파일 형식의 프레젠테이션을 결합할 수 있나요?**

아니요. [Merger.process](https://reference.aspose.com/slides/ko/python-net/aspose.slides.lowcode/merger/process/) 은 입력 프레젠테이션이 동일한 형식이어야 합니다. 예를 들어 [Convert.auto_by_extension](https://reference.aspose.com/slides/ko/python-net/aspose.slides.lowcode/convert/auto_by_extension/) 로 입력 파일을 공통 형식으로 변환한 다음 변환된 파일을 병합하십시오.

**Collect.shapes에는 무엇이 포함되나요?**

[Collect.shapes](https://reference.aspose.com/slides/ko/python-net/aspose.slides.lowcode/collect/shapes/) 은 프레젠테이션에서 도형을 가져와 보관, 필터링, 카운트 또는 여러 번 순회할 수 있게 합니다. 슬라이드 유형이나 중첩 객체를 정확히 제어해야 할 경우 직접 컬렉션 루프를 사용하십시오.

**Compress는 항상 프레젠테이션 파일을 더 작게 만들나요?**

반드시 그렇지는 않습니다. 결과는 프레젠테이션에 사용되지 않는 레이아웃, 사용되지 않는 마스터 또는 사용되지 않는 문자를 포함한 글꼴이 있는지에 따라 달라집니다. 이러한 요소가 없으면 해당 [Compress](https://reference.aspose.com/slides/ko/python-net/aspose.slides.lowcode/compress/) 작업이 파일 크기를 줄이지 않을 수 있습니다.

**Compress가 수행한 변경 사항은 자동으로 저장되나요?**

아니요. 이 도우미는 메모리상의 [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 객체에 적용됩니다. [Compress](https://reference.aspose.com/slides/ko/python-net/aspose.slides.lowcode/compress/) 를 실행한 후에는 [Presentation.save](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/save/) 를 호출하여 결과를 저장하십시오.

## **관련 기사**

- [Convert Presentation](/python-net/convert-presentation/)
- [Merge Presentations](/python-net/merge-presentation/)
- [Slide Master](/python-net/slide-master/)
- [Manage Text Box](/python-net/manage-textbox/)
- [Embedded Font](/python-net/embedded-font/)
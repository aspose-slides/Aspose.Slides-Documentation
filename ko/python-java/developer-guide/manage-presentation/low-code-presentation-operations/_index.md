---
title: "Python via Java에서 저코드 프레젠테이션 작업"
linktitle: "저코드 API"
type: docs
weight: 50
url: /ko/python-java/low-code-presentation-operations/
keywords:
- 저코드 프레젠테이션 API
- 프레젠테이션 변환
- 프레젠테이션 병합
- 슬라이드 순회
- 도형 순회
- 텍스트 순회
- 도형 수집
- 프레젠테이션 압축
- 사용되지 않는 마스터 슬라이드 제거
- 사용되지 않는 레이아웃 슬라이드 제거
- 포함된 글꼴 압축
- PowerPoint
- OpenDocument
- 프레젠테이션
- Python
- Java
- Aspose.Slides
description: "Python via Java에서 Aspose.Slides 저코드 API를 사용하여 프레젠테이션을 변환 및 병합하고, 콘텐츠를 순회하며, 도형을 수집하고, 프레젠테이션 크기를 줄입니다."
---
## **개요**

[Aspose.Slides for Python via Java](https://reference.aspose.com/slides/ko/python-java/aspose.slides/) API는 일반적인 프레젠테이션 작업을 위한 정적 헬퍼 클래스를 제공합니다. 이러한 헬퍼는 자주 사용되는 객체 모델 워크플로를 집중된 메서드로 감싸므로, 파일을 변환하거나 병합하고, 프레젠테이션 요소를 처리하고, 도형을 수집하며, 사용되지 않는 콘텐츠를 더 적은 코드로 제거할 수 있습니다.

전체 파일이나 프레젠테이션에 적용되는 작업이며 기본 워크플로가 요구 사항에 맞는 경우에 로우코드 헬퍼가 가장 유용합니다. 개별 슬라이드, 마스터, 레이아웃, 도형, 내보내기 설정 또는 프레젠테이션 요소 간 관계에 대해 세밀한 제어가 필요할 때는 전체 [Aspose.Slides 객체 모델](https://reference.aspose.com/slides/ko/python-java/aspose.slides/)을 사용하십시오.

다음 표는 사용 가능한 헬퍼를 요약합니다:

| 헬퍼 | 사용 용도 |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/ko/python-java/aspose.slides/convert/) | 파일 간 직접 호출로 프레젠테이션을 다른 형식으로 변환합니다. |
| [Merger](https://reference.aspose.com/slides/ko/python-java/aspose.slides/merger/) | 동일한 형식의 전체 프레젠테이션 파일을 결합합니다. |
| [ForEach](https://reference.aspose.com/slides/ko/python-java/aspose.slides/foreach/) | 각 슬라이드, 도형, 단락 또는 텍스트 부분에 대해 작업을 실행합니다. |
| [Collect](https://reference.aspose.com/slides/ko/python-java/aspose.slides/collect/) | 전체 프레젠테이션에서 도형을 검색하여 반복 처리하거나 분석합니다. |
| [Compress](https://reference.aspose.com/slides/ko/python-java/aspose.slides/compress/) | 사용되지 않는 마스터와 레이아웃을 제거하고 포함된 글꼴 데이터를 축소합니다. |

## **프레젠테이션 변환**

출력 파일 확장자가 내보내기 형식을 선택하기에 충분한 경우 [Convert.autoByExtension](https://reference.aspose.com/slides/ko/python-java/aspose.slides/convert/#autoByExtension)을 사용하십시오. 이 메서드는 원본 프레젠테이션을 열고, 출력 경로에서 필요한 형식을 결정한 뒤, 결과를 기록합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Convert

Convert.autoByExtension("input.pptx", "output.pdf")
```

[Convert](https://reference.aspose.com/slides/ko/python-java/aspose.slides/convert/) 클래스는 PDF, SVG, JPEG, PNG 및 TIFF 출력 전용 메서드도 제공합니다. 내보내기 전에 프레젠테이션을 검사하거나 수정해야 하거나 선택된 헬퍼에서 노출되지 않은 내보내기 옵션을 구성해야 하는 경우 전체 객체 모델을 사용하십시오. 형식별 워크플로와 옵션에 대해서는 [Convert Presentation](/slides/ko/python-java/convert-presentation/)을 참고하십시오.

## **프레젠테이션 병합**

[Merger.process](https://reference.aspose.com/slides/ko/python-java/aspose.slides/merger/#process)를 사용하면 한 번의 호출로 전체 프레젠테이션 파일을 결합할 수 있습니다. 입력 프레젠테이션은 동일한 파일 형식이어야 합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Merger

input_files = jpype.JArray(jpype.JString)(["part-1.pptx", "part-2.pptx"])
Merger.process(input_files, "merged.pptx")
```

모든 슬라이드를 하나의 결과에 순차적으로 추가하고 개별적으로 선택하거나 다시 매핑할 필요가 없는 경우에 이 헬퍼가 적합합니다. 선택된 슬라이드만 병합하거나 대상 마스터/레이아웃을 적용하고, 섹션을 명시적으로 보존하거나 서로 다른 슬라이드 크기를 조정해야 하는 경우에는 전체 객체 모델을 사용하십시오. 이러한 시나리오에 대해서는 [Merge Presentations](/slides/ko/python-java/merge-presentation/)을 참고하십시오.

## **프레젠테이션 요소 반복 처리**

[ForEach](https://reference.aspose.com/slides/ko/python-java/aspose.slides/foreach/) 클래스는 요청된 유형의 프레젠테이션 요소마다 콜백을 호출합니다. 중첩된 컬렉션 루프를 피하고 프레젠테이션 전체에 대한 검토 또는 서식 변경에 편리합니다.

다음 예제는 [ForEach.slide](https://reference.aspose.com/slides/ko/python-java/aspose.slides/foreach/#slide), [ForEach.shape](https://reference.aspose.com/slides/ko/python-java/aspose.slides/foreach/#shape), [ForEach.paragraph](https://reference.aspose.com/slides/ko/python-java/aspose.slides/foreach/#paragraph), [ForEach.portion](https://reference.aspose.com/slides/ko/python-java/aspose.slides/foreach/#portion)을 사용하여 해당 요소들을 검사합니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ForEach, Presentation

def print_slide(slide, index):
    print(f"Slide {index}: {slide.getShapes().size()} shapes")

def print_shape(shape, slide, index):
    print(f"Shape {index} on {slide.getClass().getSimpleName()}: {shape.getName()}")

def print_paragraph(paragraph, slide, index):
    print(f"Paragraph {index} on {slide.getClass().getSimpleName()}: {paragraph.getText()}")

def print_portion(portion, paragraph, slide, index):
    print(f"Portion {index} on {slide.getClass().getSimpleName()}: {portion.getText()}")

presentation = Presentation("input.pptx")
try:
    ForEach.slide(presentation, print_slide)
    ForEach.shape(presentation, print_shape)
    ForEach.paragraph(presentation, print_paragraph)
    ForEach.portion(presentation, print_portion)
finally:
    presentation.dispose()
```

기본적으로 프레젠테이션 전체 도형 및 텍스트 순회에는 일반 슬라이드, 마스터 슬라이드, 레이아웃 슬라이드가 포함됩니다. `includeNotes` 매개변수가 있는 오버로드를 사용하면 노트 슬라이드도 처리할 수 있습니다. 순회 순서, 조기 종료, 콜백 호출 전 필터링 또는 상세한 부모‑자식 제어가 중요한 경우에는 직접 컬렉션 루프를 사용하십시오.

## **도형 수집**

각 도형에 대해 콜백을 실행하는 대신 프레젠테이션의 모든 도형 컬렉션이 필요할 때는 [Collect.shapes](https://reference.aspose.com/slides/ko/python-java/aspose.slides/collect/#shapes)를 사용하십시오. 동일한 집합을 여러 번 필터링하거나, 카운트하거나, 처리해야 할 때 유용합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Collect, Presentation

presentation = Presentation("input.pptx")
try:
    shapes = Collect.shapes(presentation)

    for shape in shapes:
        print(f"{shape.getName()}: {shape.getClass().getSimpleName()}")
finally:
    presentation.dispose()
```

각 도형을 즉시 처리할 수 있고 수집된 결과를 유지할 필요가 없을 경우에는 대신 [ForEach.shape](https://reference.aspose.com/slides/ko/python-java/aspose.slides/foreach/#shape)를 사용하십시오.

## **프레젠테이션 콘텐츠 압축**

[Compress](https://reference.aspose.com/slides/ko/python-java/aspose.slides/compress/) 클래스는 사용되지 않는 구조 요소를 제거하고 포함된 글꼴 데이터를 축소할 수 있습니다:

- [removeUnusedLayoutSlides](https://reference.aspose.com/slides/ko/python-java/aspose.slides/compress/#removeUnusedLayoutSlides) 은 일반 슬라이드가 참조하지 않는 레이아웃 슬라이드를 제거합니다.
- [removeUnusedMasterSlides](https://reference.aspose.com/slides/ko/python-java/aspose.slides/compress/#removeUnusedMasterSlides) 은 더 이상 사용되지 않는 마스터 슬라이드를 제거합니다.
- [compressEmbeddedFonts](https://reference.aspose.com/slides/ko/python-java/aspose.slides/compress/#compressEmbeddedFonts) 은 포함된 글꼴에서 사용되지 않는 문자를 제거합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Compress, Presentation, SaveFormat

presentation = Presentation("input.pptx")
try:
    Compress.removeUnusedLayoutSlides(presentation)
    Compress.removeUnusedMasterSlides(presentation)
    Compress.compressEmbeddedFonts(presentation)

    presentation.save("compressed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

사용되지 않는 레이아웃을 먼저 제거하고, 그 다음 사용되지 않는 마스터를 제거하십시오. 레이아웃 정리 후에 참조가 사라진 마스터도 함께 삭제됩니다. 원본 마스터, 레이아웃 또는 전체 포함 글꼴 데이터가 나중에 필요할 수 있는 경우 최적화된 프레젠테이션을 새 파일에 저장하십시오. 자세한 내용은 [Slide Master](/slides/ko/python-java/slide-master/)와 [Embedded Font](/slides/ko/python-java/embedded-font/)를 참고하십시오.

## **FAQ**

**언제 전체 객체 모델 대신 로우코드 API를 사용해야 하나요?**

프레젠테이션 전체에 적용되는 표준 작업이며 개별 요소에 대한 상세 제어가 필요하지 않을 때 로우코드 헬퍼를 사용하십시오. 특정 슬라이드를 선택하거나 마스터·레이아웃 관계를 제어하고, 중간 상태를 검사하거나 헬퍼가 노출하지 않는 동작을 구성해야 할 경우 전체 객체 모델을 사용하십시오.

**Merger가 서로 다른 파일 형식의 프레젠테이션을 결합할 수 있나요?**

아니요. [Merger.process](https://reference.aspose.com/slides/ko/python-java/aspose.slides/merger/#process) 는 입력 프레젠테이션이 동일한 형식이어야 합니다. 먼저 [Convert.autoByExtension](https://reference.aspose.com/slides/ko/python-java/aspose.slides/convert/#autoByExtension) 등을 사용해 공통 형식으로 변환한 후 파일을 병합하십시오.

**ForEach는 마스터, 레이아웃 및 노트 슬라이드를 처리하나요?**

[ForEach.slide](https://reference.aspose.com/slides/ko/python-java/aspose.slides/foreach/#slide) 은 일반 프레젠테이션 슬라이드만 순회합니다. 프레젠테이션 전체에 대한 [ForEach.shape](https://reference.aspose.com/slides/ko/python-java/aspose.slides/foreach/#shape), [ForEach.paragraph](https://reference.aspose.com/slides/ko/python-java/aspose.slides/foreach/#paragraph), [ForEach.portion](https://reference.aspose.com/slides/ko/python-java/aspose.slides/foreach/#portion) 작업은 기본적으로 일반, 마스터, 레이아웃 슬라이드를 포함합니다. `includeNotes` 를 `True` 로 설정한 오버로드를 사용하면 노트 슬라이드도 포함됩니다.

**ForEach.shape와 Collect.shapes의 차이는 무엇인가요?**

각 도형을 콜백을 통해 즉시 처리하려면 [ForEach.shape](https://reference.aspose.com/slides/ko/python-java/aspose.slides/foreach/#shape)를 사용하십시오. 도형 컬렉션을 유지하고 싶거나, 필터링·카운트·다중 순회가 필요할 경우에는 [Collect.shapes](https://reference.aspose.com/slides/ko/python-java/aspose.slides/collect/#shapes)를 사용하십시오.

**Compress가 항상 프레젠테이션 파일을 작게 만들나요?**

반드시 그렇지는 않습니다. 프레젠테이션에 사용되지 않는 레이아웃·마스터·글꼴이 없으면 해당 [Compress](https://reference.aspose.com/slides/ko/python-java/aspose.slides/compress/) 작업이 파일 크기를 줄이지 않을 수 있습니다.

**ForEach 또는 Compress가 수행한 변경 사항이 자동으로 저장되나요?**

아니요. 이러한 헬퍼는 메모리상의 [Presentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/) 객체에만 영향을 미칩니다. [ForEach](https://reference.aspose.com/slides/ko/python-java/aspose.slides/foreach/) 콜백이나 [Compress](https://reference.aspose.com/slides/ko/python-java/aspose.slides/compress/) 실행 후에는 [Presentation.save](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/#save)를 호출해 결과를 저장해야 합니다.

## **관련 문서**

- [Convert Presentation](/slides/ko/python-java/convert-presentation/)
- [Merge Presentations](/slides/ko/python-java/merge-presentation/)
- [Slide Master](/slides/ko/python-java/slide-master/)
- [Manage Text Box](/slides/ko/python-java/manage-textbox/)
- [Embedded Font](/slides/ko/python-java/embedded-font/)
---
title: Python을 통한 Java에서 프레젠테이션 정보 검색 및 업데이트
linktitle: 프레젠테이션 정보
type: docs
weight: 30
url: /ko/python-java/examine-presentation/
keywords:
- 프레젠테이션 형식
- 프레젠테이션 속성
- 문서 속성
- 속성 가져오기
- 속성 읽기
- 속성 변경
- 속성 수정
- 속성 업데이트
- PPTX 검사
- PPT 검사
- ODP 검사
- 파워포인트
- 오픈문서
- 프레젠테이션
- 파이썬
- 자바
- Aspose.Slides
description: "Python을 이용한 Java로 PowerPoint 및 OpenDocument 프레젠테이션의 슬라이드, 구조, 메타데이터를 탐색하여 빠른 인사이트와 스마트한 콘텐츠 감사를 수행합니다."
---
## **개요**

Aspose.Slides는 프레젠테이션의 형식을 식별하고 전체 프레젠테이션 개체 모델을 생성하지 않고도 문서 메타데이터를 읽을 수 있습니다. 파일을 분류하거나 인벤토리를 구축하거나 프레젠테이션 내용을 로드하고 처리할지 결정하기 전에 속성을 검사해야 할 때 유용합니다.

예제들을 실행하려면 Python용 Aspose.Slides for Java와 호환되는 Java 런타임이 필요합니다. 각 예제는 JVM이 실행 중이 아니면 시작합니다. 예제에 사용된 경로에 기존 프레젠테이션 파일을 제공하십시오.

이 문서에서는 [PresentationFactory](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentationfactory/)와 [PresentationInfo](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentationinfo/)를 통한 가벼운 검사를 보여주며, [DocumentProperties](https://reference.aspose.com/slides/ko/python-java/aspose.slides/documentproperties/)를 통한 대상 업데이트도 설명합니다.

## **프레젠테이션 형식 확인**

[PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentationfactory/#getPresentationInfo)를 사용하여 [Presentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/) 인스턴스를 만들지 않고 파일을 검사합니다. [PresentationInfo.getLoadFormat](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentationinfo/#getLoadFormat) 메서드는 PPTX, PPT 또는 ODP와 같은 감지된 형식을 보고합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadFormat, PresentationFactory

file_names = ["pres.pptx", "pres.ppt", "pres.odp"]

for file_name in file_names:
    presentation_info = PresentationFactory.getInstance().getPresentationInfo(file_name)
    load_format = presentation_info.getLoadFormat()
    format_name = f"Other ({load_format})"

    if load_format == LoadFormat.Pptx:
        format_name = "PPTX"
    elif load_format == LoadFormat.Ppt:
        format_name = "PPT"
    elif load_format == LoadFormat.Odp:
        format_name = "ODP"

    print(f"{file_name}: {format_name}")
```

## **가벼운 프레젠테이션 인벤토리 구축**

많은 프레젠테이션 파일을 처리할 때 검증, 인덱싱 또는 문서 관리 시스템을 위한 압축된 인벤토리가 필요할 수 있습니다. 이 경우 [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentationfactory/#getPresentationInfo)를 사용하여 [PresentationInfo](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentationinfo/) 객체를 얻고, [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentationinfo/#readDocumentProperties)를 호출하여 문서 메타데이터를 읽습니다. 이 방법은 [Presentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/) 인스턴스를 생성하거나 전체 프레젠테이션 개체 모델을 탐색할 필요가 없습니다.

[DocumentProperties](https://reference.aspose.com/slides/ko/python-java/aspose.slides/documentproperties/)에서 제공하는 확장 속성은 다음과 같은 인벤토리 값을 제공합니다:

| 메서드 | 인벤토리 값 |
| --- | --- |
| [getSlides](https://reference.aspose.com/slides/ko/python-java/aspose.slides/documentproperties/#getSlides) | 슬라이드 총 수. |
| [getHiddenSlides](https://reference.aspose.com/slides/ko/python-java/aspose.slides/documentproperties/#getHiddenSlides) | 숨긴 슬라이드 수. |
| [getNotes](https://reference.aspose.com/slides/ko/python-java/aspose.slides/documentproperties/#getNotes) | 노트가 포함된 슬라이드 수. |
| [getParagraphs](https://reference.aspose.com/slides/ko/python-java/aspose.slides/documentproperties/#getParagraphs) | 가능한 경우 전체 단락 수. |
| [getWords](https://reference.aspose.com/slides/ko/python-java/aspose.slides/documentproperties/#getWords) | 전체 단어 수. |
| [getMultimediaClips](https://reference.aspose.com/slides/ko/python-java/aspose.slides/documentproperties/#getMultimediaClips) | 오디오 및 비디오 클립 총 수. |

다음 예제는 [Presentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/) 객체를 만들지 않고 이러한 값을 읽어 압축된 인벤토리를 출력합니다. 또한 [getHeadingPairs](https://reference.aspose.com/slides/ko/python-java/aspose.slides/documentproperties/#getHeadingPairs)와 [getTitlesOfParts](https://reference.aspose.com/slides/ko/python-java/aspose.slides/documentproperties/#getTitlesOfParts)를 결합하여 폰트, 테마 및 슬라이드 제목과 같은 콘텐츠 그룹을 표시합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import LoadFormat, PresentationFactory

file_path = "sample.pptx"
presentation_info = PresentationFactory.getInstance().getPresentationInfo(file_path)
document_properties = presentation_info.readDocumentProperties()

load_format = presentation_info.getLoadFormat()
format_name = f"Other ({load_format})"

if load_format == LoadFormat.Pptx:
    format_name = "PPTX"
elif load_format == LoadFormat.Ppt:
    format_name = "PPT"
elif load_format == LoadFormat.Odp:
    format_name = "ODP"

print(f"File: {Path(file_path).name}")
print(f"Format: {format_name}")
print(f"Title: {document_properties.getTitle()}")
print(f"Author: {document_properties.getAuthor()}")
print("Statistics:")
print(f"  Slides: {document_properties.getSlides()}")
print(f"  Hidden slides: {document_properties.getHiddenSlides()}")
print(f"  Slides with notes: {document_properties.getNotes()}")
print(f"  Paragraphs: {document_properties.getParagraphs()}")
print(f"  Words: {document_properties.getWords()}")
print(f"  Multimedia clips: {document_properties.getMultimediaClips()}")

heading_pairs = document_properties.getHeadingPairs()
titles_of_parts = document_properties.getTitlesOfParts()
heading_pairs = heading_pairs if heading_pairs is not None else []
titles_of_parts = titles_of_parts if titles_of_parts is not None else []
part_index = 0

if len(heading_pairs) == 0 or len(titles_of_parts) == 0:
    print("Content groups: not available")
else:
    print("Content groups:")

    for heading_pair in heading_pairs:
        print(f"  {heading_pair.getName()} ({heading_pair.getCount()})")

        for part_offset in range(heading_pair.getCount()):
            if part_index >= len(titles_of_parts):
                break
            print(f"    - {titles_of_parts[part_index]}")
            part_index += 1

    if part_index < len(titles_of_parts):
        print("  Other parts:")

        while part_index < len(titles_of_parts):
            print(f"    - {titles_of_parts[part_index]}")
            part_index += 1
```

각 [HeadingPair](https://reference.aspose.com/slides/ko/python-java/aspose.slides/headingpair/)은 그룹 이름과 해당 그룹의 항목 수를 제공합니다. [DocumentProperties.getTitlesOfParts](https://reference.aspose.com/slides/ko/python-java/aspose.slides/documentproperties/#getTitlesOfParts)는 평면이며 순서가 지정된 배열을 반환하므로 각 heading pair가 지정한 연속 제목 수만큼 사용합니다.

### **저장된 메타데이터 및 형식 제한**

[PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentationinfo/#readDocumentProperties)에서 반환된 인벤토리 속성은 소스 문서에 존재하는 메타데이터를 반영합니다. Aspose.Slides는 이 호출을 위해 프레젠테이션 개체 모델을 로드하고 탐색하지 않으며, 누락된 속성은 기본값으로 표시되고 마지막 저장 시 문서 속성을 업데이트하지 않은 경우 저장된 값이 오래될 수 있습니다.

- **PPTX:** 슬라이드, 노트, 숨긴 슬라이드, 단락, 단어 및 멀티미디어 개수와 heading pair 및 part title에 대한 확장 문서 속성을 제공합니다. 이용 가능 여부는 문서 작성자가 어떤 속성을 기록했는지에 따라 다릅니다.
- **PPT:** 이진 형식은 해당 문서 요약 속성을 저장할 수 있습니다. 속성이 없거나 문서 작성자가 새로 고치지 않은 경우 Aspose.Slides는 슬라이드에서 계산하지 않고 저장된 값 또는 기본값을 반환합니다.
- **ODP:** OpenDocument 메타데이터는 페이지, 단락 및 단어 수와 같은 일반적인 문서 통계를 제공하지만 이러한 값이 모든 PowerPoint 전용 확장 속성과 매핑되지 않을 수 있습니다. 숨긴 슬라이드, 노트 슬라이드, 멀티미디어, heading‑pair 및 part‑title 메타데이터는 없을 수 있으며, 인벤토리 속성은 기본값을 반환할 수 있습니다. 0값이나 빈 배열을 해당 콘텐츠가 없다는 절대적인 증거로 간주하지 마십시오.

인벤토리 및 사전 검사를 위해 가벼운 메타데이터 방식을 사용하십시오. 메모리 내 변경 사항을 반영하거나 실제 프레젠테이션 콘텐츠를 확인해야 할 때는 프레젠테이션을 로드하고 실시간 개체 모델을 검사하십시오.

## **프레젠테이션 속성 업데이트**

[PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentationinfo/#readDocumentProperties)에서 반환된 속성은 [Presentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/) 인스턴스를 만들지 않고도 변경할 수 있습니다. 변경 사항은 [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentationinfo/#updateDocumentProperties)로 적용한 다음, [PresentationInfo.writeBindedPresentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentationinfo/#writeBindedPresentation)으로 바인딩된 프레젠테이션을 저장합니다.

원본 문서 속성을 보여주는 이미지입니다.

![PowerPoint 프레젠테이션의 원본 문서 속성](input_properties.png)

다음 예제는 제목과 마지막 저장 시간을 변경하고 결과를 새 파일에 씁니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PresentationFactory
from java.io import FileOutputStream
from java.util import Date

source_file = "sample.pptx"
output_file = "sample_with_updated_properties.pptx"
presentation_info = PresentationFactory.getInstance().getPresentationInfo(source_file)
document_properties = presentation_info.readDocumentProperties()

document_properties.setTitle("Quarterly sales report")
last_saved_time = Date()
document_properties.setLastSavedTime(last_saved_time)

presentation_info.updateDocumentProperties(document_properties)
output_stream = FileOutputStream(output_file)
try:
    presentation_info.writeBindedPresentation(output_stream)
finally:
    output_stream.close()
```

변경된 문서 속성을 보여주는 이미지입니다.

![PowerPoint 프레젠테이션의 변경된 문서 속성](output_properties.png)

## **유용한 링크**

관련 보안 검사 및 보호 설정에 대한 문서는 다음을 참고하십시오:

- [프레젠테이션 암호 보호](/slides/ko/python-java/password-protected-presentation/)
- [프레젠테이션 쓰기 보호](/slides/ko/python-java/write-protected-presentation/)

## **FAQ**

**폰트가 임베드되어 있는지 및 어떤 폰트인지 어떻게 확인할 수 있나요?**

프레젠테이션을 로드하고 [Presentation.getFontsManager](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/#getFontsManager)를 사용하십시오. [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/ko/python-java/aspose.slides/fontsmanager/#getEmbeddedFonts)를 호출하면 임베드된 폰트를, [FontsManager.getFonts](https://reference.aspose.com/slides/ko/python-java/aspose.slides/fontsmanager/#getFonts)를 호출하면 프레젠테이션에서 사용되는 폰트를 얻을 수 있습니다. 두 결과를 비교하여 렌더링에 필요하지만 임베드되지 않은 폰트를 찾으십시오.

**파일에 숨긴 슬라이드가 있는지와 그 개수를 빠르게 확인하려면 어떻게 해야 하나요?**

저장된 문서 메타데이터만으로 충분하면 [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentationfactory/#getPresentationInfo)와 [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentationinfo/#readDocumentProperties)를 통해 [DocumentProperties.getHiddenSlides](https://reference.aspose.com/slides/ko/python-java/aspose.slides/documentproperties/#getHiddenSlides)를 읽습니다. 이는 가벼운 인벤토리에 적합합니다. 프레젠테이션이 메모리에서 수정됐거나 실시간 값을 확인해야 하면 [Presentation.getSlides](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/#getSlides)를 순회하고 각 슬라이드의 [Slide.getHidden](https://reference.aspose.com/slides/ko/python-java/aspose.slides/slide/#getHidden) 메서드를 검사하십시오.

**사용자 정의 슬라이드 크기와 방향이 사용되는지 및 기본값과 다른지 감지할 수 있나요?**

예. 프레젠테이션을 로드하고 [Presentation.getSlideSize](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/#getSlideSize)를 호출하십시오. [SlideSize.getType](https://reference.aspose.com/slides/ko/python-java/aspose.slides/slidesize/#getType), [SlideSize.getSize](https://reference.aspose.com/slides/ko/python-java/aspose.slides/slidesize/#getSize) 및 [SlideSize.getOrientation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/slidesize/#getOrientation)를 사용하여 현재 설정을 예상 프리셋 및 차원과 비교하십시오.

**차트가 외부 데이터 소스를 참조하는지 빠르게 확인하는 방법이 있나요?**

예. 각 [Chart](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chart/)를 찾아 [ChartData.getDataSourceType](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chartdata/#getDataSourceType)를 호출하십시오. 외부 워크북인 경우 [ChartData.getExternalWorkbookPath](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chartdata/#getExternalWorkbookPath)를 호출합니다. 데이터 소스 유형과 경로가 외부 참조를 나타내지만, 대상이 실제로 사용 가능한지는 별도의 리소스 확인이 필요합니다.

**렌더링이나 PDF 내보내기를 느리게 만들 수 있는 '무거운' 슬라이드를 어떻게 평가할 수 있나요?**

단일 복잡도 속성은 없습니다. [Presentation.getSlides](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/#getSlides)를 순회하고 각 슬라이드의 [BaseSlide.getShapes](https://reference.aspose.com/slides/ko/python-java/aspose.slides/baseslide/#getShapes) 컬렉션을 검사하십시오. 도형 개수와 대용량 이미지, 효과, 애니메이션 또는 멀티미디어 존재 여부를 스크리닝 신호로 활용하고, 대표적인 렌더링 또는 내보내기 시간을 측정한 뒤 슬라이드를 성능 병목으로 확정하십시오.
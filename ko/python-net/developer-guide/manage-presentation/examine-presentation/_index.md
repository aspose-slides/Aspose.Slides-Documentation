---
title: "Python에서 프레젠테이션 정보 검색 및 업데이트"
linktitle: "프레젠테이션 정보"
type: docs
weight: 30
url: /ko/python-net/examine-presentation/
keywords:
  - "프레젠테이션 형식"
  - "프레젠테이션 속성"
  - "문서 속성"
  - "속성 가져오기"
  - "속성 읽기"
  - "속성 변경"
  - "속성 수정"
  - "속성 업데이트"
  - "PPTX 검사"
  - "PPT 검사"
  - "ODP 검사"
  - "PowerPoint"
  - "OpenDocument"
  - "프레젠테이션"
  - "Python"
  - "Aspose.Slides"
description: "Python을 사용하여 PowerPoint 및 OpenDocument 프레젠테이션의 슬라이드, 구조 및 메타데이터를 탐색하고 빠른 인사이트와 보다 스마트한 콘텐츠 감사를 수행합니다."
---
## **개요**

Aspose.Slides는 프레젠테이션의 형식을 식별하고 전체 프레젠테이션 객체 모델을 만들지 않고도 문서 메타데이터를 읽을 수 있습니다. 이는 파일을 분류하거나 인벤토리를 구축하거나 프레젠테이션 내용을 로드하고 처리할지 결정하기 전에 속성을 검사해야 할 때 유용합니다.

이 문서는 [PresentationFactory](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentationfactory/)와 [PresentationInfo](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentationinfo/)를 통한 경량 검사를 보여주며, [DocumentProperties](https://reference.aspose.com/slides/ko/python-net/aspose.slides/documentproperties/)를 사용한 대상 업데이트도 설명합니다.

## **프레젠테이션 형식 확인**

[PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentationfactory/get_presentation_info/)를 사용하여 [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 인스턴스를 만들지 않고 파일을 검사합니다. [PresentationInfo.load_format](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentationinfo/load_format/) 속성은 PPTX, PPT 또는 ODP와 같은 감지된 형식을 보고합니다.

```python
import aspose.slides as slides

file_names = ["pres.pptx", "pres.ppt", "pres.odp"]

for file_name in file_names:
    presentation_info = slides.PresentationFactory.instance.get_presentation_info(file_name)
    print(f"{file_name}: {presentation_info.load_format}")
```

## **경량 프레젠테이션 인벤토리 구축**

많은 프레젠테이션 파일을 처리할 때 검증, 인덱싱 또는 문서 관리 시스템을 위한 압축 인벤토리가 필요할 수 있습니다. 이 경우 [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentationfactory/get_presentation_info/)를 사용하여 [PresentationInfo](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentationinfo/) 객체를 얻은 다음 [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentationinfo/read_document_properties/)를 호출하여 문서 메타데이터를 읽습니다. 이 접근 방식은 [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 인스턴스를 만들지 않으며 전체 프레젠테이션 객체 모델을 탐색할 필요도 없습니다.

[DocumentProperties](https://reference.aspose.com/slides/ko/python-net/aspose.slides/documentproperties/)가 제공하는 확장 속성은 다음 인벤토리 값을 포함합니다:

| 속성 | 인벤토리 값 |
| --- | --- |
| [slides](https://reference.aspose.com/slides/ko/python-net/aspose.slides/documentproperties/slides/ko/) | 전체 슬라이드 수. |
| [hidden_slides](https://reference.aspose.com/slides/ko/python-net/aspose.slides/documentproperties/hidden_slides/) | 숨김 슬라이드 수. |
| [notes](https://reference.aspose.com/slides/ko/python-net/aspose.slides/documentproperties/notes/) | 노트가 포함된 슬라이드 수. |
| [paragraphs](https://reference.aspose.com/slides/ko/python-net/aspose.slides/documentproperties/paragraphs/) | 가능한 경우 전체 단락 수. |
| [words](https://reference.aspose.com/slides/ko/python-net/aspose.slides/documentproperties/words/) | 전체 단어 수. |
| [multimedia_clips](https://reference.aspose.com/slides/ko/python-net/aspose.slides/documentproperties/multimedia_clips/) | 오디오 및 비디오 클립 총 수. |

다음 예제는 [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 객체를 생성하지 않고 이러한 값을 읽어 압축 인벤토리를 출력합니다. 또한 [heading_pairs](https://reference.aspose.com/slides/ko/python-net/aspose.slides/documentproperties/heading_pairs/)와 [titles_of_parts](https://reference.aspose.com/slides/ko/python-net/aspose.slides/documentproperties/titles_of_parts/)를 결합하여 글꼴, 테마, 슬라이드 제목과 같은 내용 그룹을 표시합니다.

```python
import os
import aspose.slides as slides

file_path = "sample.pptx"
presentation_info = slides.PresentationFactory.instance.get_presentation_info(file_path)
document_properties = presentation_info.read_document_properties()

print(f"File: {os.path.basename(file_path)}")
print(f"Format: {presentation_info.load_format}")
print(f"Title: {document_properties.title}")
print(f"Author: {document_properties.author}")
print("Statistics:")
print(f"  Slides: {document_properties.slides}")
print(f"  Hidden slides: {document_properties.hidden_slides}")
print(f"  Slides with notes: {document_properties.notes}")
print(f"  Paragraphs: {document_properties.paragraphs}")
print(f"  Words: {document_properties.words}")
print(f"  Multimedia clips: {document_properties.multimedia_clips}")

heading_pairs = document_properties.heading_pairs or []
titles_of_parts = document_properties.titles_of_parts or []
part_index = 0

if not heading_pairs or not titles_of_parts:
    print("Content groups: not available")
else:
    print("Content groups:")

    for heading_pair in heading_pairs:
        print(f"  {heading_pair.name} ({heading_pair.count})")

        for _ in range(heading_pair.count):
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

각 [HeadingPair](https://reference.aspose.com/slides/ko/python-net/aspose.slides/headingpair/)은 그룹 이름과 해당 그룹의 항목 수를 제공합니다. [DocumentProperties.titles_of_parts](https://reference.aspose.com/slides/ko/python-net/aspose.slides/documentproperties/titles_of_parts/)는 평면이며 순서가 지정된 컬렉션이므로 각 heading pair가 지정한 연속된 제목 수만큼 사용합니다.

### **저장된 메타데이터 및 형식 제한**

[PresentationInfo.read_document_properties](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentationinfo/read_document_properties/)가 반환하는 인벤토리 속성은 소스 문서에 존재하는 메타데이터를 반영합니다. Aspose.Slides는 이 호출을 위해 프레젠테이션 객체 모델을 로드하고 탐색하여 값을 재계산하지 않습니다. 누락된 속성은 기본값으로 표시되며, 마지막 저장 시 문서 속성을 업데이트하지 않은 경우 저장된 값이 오래될 수 있습니다.

- **PPTX:** 형식은 슬라이드, 노트, 숨김 슬라이드, 단락, 단어 및 멀티미디어 수와 heading pair 및 part title에 대한 확장 문서 속성을 제공합니다. 가용성은 문서 작성자가 어떤 속성을 기록했는지에 따라 달라집니다.
- **PPT:** 바이너리 형식은 해당 문서 요약 속성을 저장할 수 있습니다. 속성이 없거나 문서 작성자가 새로 고치지 않은 경우 Aspose.Slides는 슬라이드에서 계산하지 않고 저장된 값 또는 기본값을 반환합니다.
- **ODP:** OpenDocument 메타데이터는 페이지, 단락 및 단어 수와 같은 일반 문서 통계를 제공하지만 이러한 값이 PowerPoint 고유 확장 속성과 일치하지 않을 수 있습니다. 숨김 슬라이드, 노트 슬라이드, 멀티미디어, heading‑pair 및 part‑title 메타데이터가 없을 수 있으며, 인벤토리 속성은 기본값을 반환할 수 있습니다. 0 값이나 빈 컬렉션을 해당 콘텐츠가 없다는 권위 있는 증거로 취급하지 마십시오.

인벤토리 및 사전 검사를 위해 경량 메타데이터 접근 방식을 사용하십시오. 결과가 메모리 내 변경을 반영해야 하거나 실제 프레젠테이션 내용을 확인해야 할 때는 프레젠테이션을 로드하고 실시간 객체 모델을 검사하십시오.

## **프레젠테이션 속성 업데이트**

[PresentationInfo.read_document_properties](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentationinfo/read_document_properties/)가 반환하는 속성은 [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 인스턴스를 만들지 않고도 변경할 수 있습니다. 변경 사항은 [PresentationInfo.update_document_properties](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentationinfo/update_document_properties/)로 적용한 다음 [PresentationInfo.write_binded_presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentationinfo/write_binded_presentation/)를 사용하여 바인드된 프레젠테이션을 저장합니다.

원본 문서 속성을 보여주는 이미지입니다.

![PowerPoint 프레젠테이션의 원본 문서 속성](input_properties.png)

다음 예제는 제목과 마지막 저장 시간을 변경하고 결과를 새 파일에 기록합니다:

```python
import datetime
import aspose.slides as slides

source_file = "sample.pptx"
output_file = "sample_with_updated_properties.pptx"
presentation_info = slides.PresentationFactory.instance.get_presentation_info(source_file)
document_properties = presentation_info.read_document_properties()

document_properties.title = "Quarterly sales report"
document_properties.last_saved_time = datetime.datetime.now(datetime.timezone.utc)

presentation_info.update_document_properties(document_properties)

with open(output_file, "wb") as output_stream:
    presentation_info.write_binded_presentation(output_stream)
```

변경된 문서 속성을 보여주는 이미지입니다.

![PowerPoint 프레젠테이션의 변경된 문서 속성](output_properties.png)

## **유용한 링크**

관련 보안 검사 및 보호 설정에 대해서는 다음 문서를 참조하십시오:

- [프레젠테이션 암호 보호](/slides/ko/python-net/password-protected-presentation/)
- [프레젠테이션 쓰기 방지](/slides/ko/python-net/write-protected-presentation/)

## **FAQ**

**폰트가 포함되어 있는지 및 포함된 폰트는 무엇인지 어떻게 확인할 수 있나요?**

프레젠테이션을 로드하고 [Presentation.fonts_manager](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/fonts_manager/)를 사용합니다. [FontsManager.get_embedded_fonts](https://reference.aspose.com/slides/ko/python-net/aspose.slides/fontsmanager/get_embedded_fonts/)를 호출하여 포함된 폰트를 가져오고, [FontsManager.get_fonts](https://reference.aspose.com/slides/ko/python-net/aspose.slides/fontsmanager/get_fonts/)를 호출하여 프레젠테이션이 사용하는 폰트를 가져옵니다. 두 결과를 비교하여 렌더링에 필요하지만 포함되지 않은 폰트를 찾습니다.

**파일에 숨김 슬라이드가 있는지 그리고 개수가 얼마나 되는지 빠르게 확인하려면 어떻게 해야 하나요?**

저장된 문서 메타데이터가 충분할 때는 [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentationfactory/get_presentation_info/)와 [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentationinfo/read_document_properties/)를 통해 [DocumentProperties.hidden_slides](https://reference.aspose.com/slides/ko/python-net/aspose.slides/documentproperties/hidden_slides/)를 읽습니다. 이는 경량 인벤토리에 적합합니다. 프레젠테이션이 메모리에서 수정된 경우 저장된 메타데이터가 없거나 오래될 수 있으므로, 실시간 값을 확인하려면 [Presentation.slides](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/slides/ko/)를 순회하고 각 슬라이드의 [Slide.hidden](https://reference.aspose.com/slides/ko/python-net/aspose.slides/slide/hidden/) 속성을 검사하십시오.

**사용자 지정 슬라이드 크기와 방향이 적용되어 있는지, 기본값과 다른지 어떻게 감지할 수 있나요?**

예, 프레젠테이션을 로드하고 [Presentation.slide_size](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/slide_size/)를 읽습니다. [SlideSize.type](https://reference.aspose.com/slides/ko/python-net/aspose.slides/slidesize/type/), [SlideSize.size](https://reference.aspose.com/slides/ko/python-net/aspose.slides/slidesize/size/), [SlideSize.orientation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/slidesize/orientation/)을 검사하여 현재 설정을 예상 프리셋 및 치수와 비교합니다.

**차트가 외부 데이터 소스를 참조하고 있는지 빠르게 확인하는 방법이 있나요?**

예. 각 [Chart](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/chart/)를 찾아 [ChartData.data_source_type](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/chartdata/data_source_type/)을 확인합니다. 외부 워크북인 경우 [ChartData.external_workbook_path](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/chartdata/external_workbook_path/)를 읽습니다. 데이터 소스 유형과 경로가 외부 참조를 나타내지만 대상이 실제로 사용 가능한지는 별도의 리소스 확인이 필요합니다.

**렌더링이나 PDF 내보내기를 느리게 할 수 있는 '무거운' 슬라이드를 어떻게 평가할 수 있나요?**

단일 복잡도 속성은 없습니다. [Presentation.slides](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/slides/ko/)와 각 슬라이드의 [BaseSlide.shapes](https://reference.aspose.com/slides/ko/python-net/aspose.slides/baseslide/shapes/) 컬렉션을 순회하십시오. 도형 수와 큰 이미지, 효과, 애니메이션 또는 멀티미디어 존재 여부를 신호로 사용하고, 대표적인 렌더링 또는 내보내기 시간을 측정한 후에 슬라이드를 성능 병목으로 확정하십시오.
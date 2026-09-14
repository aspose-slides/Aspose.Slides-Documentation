---
title: Python을 통해 Java에서 슬라이드 레이아웃 적용 또는 변경
linktitle: 슬라이드 레이아웃
type: docs
weight: 60
url: /ko/python-java/slide-layout/
keywords:
- 슬라이드 레이아웃
- 콘텐츠 레이아웃
- 자리표시자
- 프레젠테이션 디자인
- 슬라이드 디자인
- 사용되지 않은 레이아웃
- 바닥글 표시
- 제목 슬라이드
- 제목 및 내용
- 섹션 헤더
- 두 개의 내용
- 비교
- 제목만
- 빈 레이아웃
- 캡션이 있는 내용
- 캡션이 있는 그림
- 제목 및 수직 텍스트
- 수직 제목 및 텍스트
- PowerPoint
- OpenDocument
- 프레젠테이션
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java에서 슬라이드 레이아웃을 적용·생성·수정하고, 자리표시자를 추가하고, 사용되지 않은 레이아웃을 제거하며, 바닥글 표시를 제어합니다."
---
## **개요**

슬라이드 레이아웃은 제목, 텍스트, 그림, 차트 및 표와 같은 자리표시자의 위치와 서식을 정의합니다. 레이아웃을 적용하면 슬라이드가 일관된 구조를 갖게 되면서도 각 슬라이드마다 자체 콘텐츠를 포함할 수 있습니다.

가장 일반적인 레이아웃은 다음과 같습니다:

- **제목 슬라이드**: 제목 및 부제 자리표시자를 포함합니다.
- **제목 및 내용**: 제목 자리표시자와 일반용 내용 자리표시자를 포함합니다.
- **빈 슬라이드**: 내용 자리표시자가 없으며 모든 도형을 수동으로 배치할 때 유용합니다.

## **레이아웃 상속 이해**

프레젠테이션에는 세 가지 관련 수준이 있습니다:

1. A [master slide](https://reference.aspose.com/slides/ko/python-java/aspose.slides/masterslide/)은 테마, 공유 서식, 배경 및 공통 개체를 정의합니다.
1. A [layout slide](https://reference.aspose.com/slides/ko/python-java/aspose.slides/layoutslide/)는 마스터에 속하며 특정 자리표시자 배치를 정의합니다.
1. A [normal slide](https://reference.aspose.com/slides/ko/python-java/aspose.slides/slide/)는 하나의 레이아웃을 사용하고 해당 슬라이드에 입력된 콘텐츠를 저장합니다.

일반 슬라이드는 레이아웃으로부터 테마와 서식을 상속받으며, 레이아웃은 마스터로부터 상속받습니다. 일반 슬라이드에 직접 설정된 값은 해당 수준에서 상속된 값을 재정의합니다. 일반 슬라이드가 생성될 때 선택된 레이아웃에서 자리표시자 도형이 생성되며, 해당 자리표시자에 입력된 콘텐츠는 일반 슬라이드에 속합니다.

슬라이드를 만들기 전에 레이아웃에 필요한 자리표시자를 추가하십시오. 나중에 레이아웃에 다른 자리표시자를 추가해도 기존 일반 슬라이드에 자동으로 해당 자리표시자 도형이 추가되지는 않습니다.

이 관계에는 두 가지 중요한 결과가 있습니다:

- 레이아웃에서 상속된 서식이나 기존 자리표시자 기하학을 변경하면 해당 레이아웃에 의존하는 모든 슬라이드가 업데이트될 수 있습니다. 이미 사용 중인 레이아웃을 편집하기 전에 종속 슬라이드를 검사하고 결과 프레젠테이션을 검토하십시오.
- 슬라이드가 아직 사용 중인 레이아웃은 삭제할 수 없습니다. 먼저 해당 슬라이드를 다른 레이아웃으로 재할당하거나 사용되지 않는 레이아웃만 삭제하십시오.

이 계층 구조의 최상위에 대한 자세한 내용은 [Slide Master](/slides/ko/python-java/slide-master/)를 참조하십시오.

## **슬라이드 레이아웃 선택 및 적용**

프레젠테이션이 표준 PowerPoint 레이아웃 정의를 따르는 경우 레이아웃 유형을 사용하십시오. 레이아웃 이름은 사용자 편집이 가능하고 현지화될 수 있으므로, 소스 템플릿을 제어하지 않는 한 이름 기반 선택은 신뢰성이 낮습니다.

다음 예제는 첫 번째 마스터에서 **Title and Content**를 찾습니다. 해당 레이아웃이 없으면 의도적으로 **Blank**로 복구합니다. `None`에 대한 두 번째 확인은 프레젠테이션에 사용자 지정 레이아웃만 포함될 수 있기 때문에 필요합니다. 선택된 레이아웃은 [Slide.setLayoutSlide](https://reference.aspose.com/slides/ko/python-java/aspose.slides/slide/#setLayoutSlide) 메서드를 통해 첫 번째 일반 슬라이드에 적용됩니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideLayoutType

presentation = Presentation("input.pptx")
try:
    layout_slides = presentation.getMasters().get_Item(0).getLayoutSlides()
    target_layout = layout_slides.getByType(SlideLayoutType.TitleAndObject)

    if target_layout is None:
        target_layout = layout_slides.getByType(SlideLayoutType.Blank)

    if target_layout is None:
        print("The first master does not contain a suitable layout slide.")
    else:
        presentation.getSlides().get_Item(0).setLayoutSlide(target_layout)
        presentation.save("output-with-new-layout.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

슬라이드 레이아웃을 변경해도 슬라이드에 직접 추가된 일반 도형은 제거되지 않습니다. 그러나 자리표시자 위치, 상속된 서식 및 기존 자리표시자와 새로운 레이아웃 간의 대응 관계가 변경될 수 있으므로, 크게 다른 레이아웃 간 전환 시 출력물을 반드시 확인하십시오.

## **레이아웃 슬라이드 추가**

선택과 생성은 별개의 작업입니다. 앞 예제는 기존 레이아웃을 선택했으며 생성하지는 않았습니다. 레이아웃을 만들려면 대상 마스터의 레이아웃 컬렉션에서 [MasterLayoutSlideCollection.add](https://reference.aspose.com/slides/ko/python-java/aspose.slides/masterlayoutslidecollection/#add) 메서드를 호출하십시오.

다음 예제는 항상 새로운 **Title and Content** 레이아웃을 `Report Title and Content`라는 이름으로 추가한 뒤, 이를 기반으로 일반 슬라이드를 추가합니다. 레이아웃 이름은 컬렉션 내에서 고유해야 합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideLayoutType

presentation = Presentation("input.pptx")
try:
    master_slide = presentation.getMasters().get_Item(0)
    report_layout = master_slide.getLayoutSlides().add(SlideLayoutType.TitleAndObject, "Report Title and Content")
    presentation.getSlides().addEmptySlide(report_layout)

    presentation.save("output-with-report-layout.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

템플릿에 실제로 추가 재사용 구조가 필요할 때만 레이아웃을 추가하십시오. 적절한 레이아웃이 이미 존재한다면 중복 생성 대신 선택하여 재사용하십시오.

## **레이아웃 슬라이드에 자리표시자 추가**

[LayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/ko/python-java/aspose.slides/layoutslide/#getPlaceholderManager) 메서드는 레이아웃에 자리표시자 도형을 추가하기 위한 [LayoutPlaceholderManager](https://reference.aspose.com/slides/ko/python-java/aspose.slides/layoutplaceholdermanager/)를 제공합니다.

| PowerPoint 자리표시자               | [LayoutPlaceholderManager](https://reference.aspose.com/slides/ko/python-java/aspose.slides/layoutplaceholdermanager/) 메서드 |
| ----------------------------------- | ---------------------------------- |
| ![Content](content.png)             | [addContentPlaceholder](https://reference.aspose.com/slides/ko/python-java/aspose.slides/layoutplaceholdermanager/#addContentPlaceholder) |
| ![Content (Vertical)](contentV.png) | [addVerticalContentPlaceholder](https://reference.aspose.com/slides/ko/python-java/aspose.slides/layoutplaceholdermanager/#addVerticalContentPlaceholder) |
| ![Text](text.png)                   | [addTextPlaceholder](https://reference.aspose.com/slides/ko/python-java/aspose.slides/layoutplaceholdermanager/#addTextPlaceholder) |
| ![Text (Vertical)](textV.png)       | [addVerticalTextPlaceholder](https://reference.aspose.com/slides/ko/python-java/aspose.slides/layoutplaceholdermanager/#addVerticalTextPlaceholder) |
| ![Picture](picture.png)             | [addPicturePlaceholder](https://reference.aspose.com/slides/ko/python-java/aspose.slides/layoutplaceholdermanager/#addPicturePlaceholder) |
| ![Chart](chart.png)                 | [addChartPlaceholder](https://reference.aspose.com/slides/ko/python-java/aspose.slides/layoutplaceholdermanager/#addChartPlaceholder) |
| ![Table](table.png)                 | [addTablePlaceholder](https://reference.aspose.com/slides/ko/python-java/aspose.slides/layoutplaceholdermanager/#addTablePlaceholder) |
| ![SmartArt](smartart.png)           | [addSmartArtPlaceholder](https://reference.aspose.com/slides/ko/python-java/aspose.slides/layoutplaceholdermanager/#addSmartArtPlaceholder) |
| ![Media](media.png)                 | [addMediaPlaceholder](https://reference.aspose.com/slides/ko/python-java/aspose.slides/layoutplaceholdermanager/#addMediaPlaceholder) |
| ![Online Image](onlineImage.png)    | [addOnlineImagePlaceholder](https://reference.aspose.com/slides/ko/python-java/aspose.slides/layoutplaceholdermanager/#addOnlineImagePlaceholder) |

다음 예제는 **Blank** 레이아웃이 존재하는지 확인하고, 네 개의 자리표시자를 추가한 후 해당 레이아웃을 사용하는 일반 슬라이드를 생성합니다. 순서는 의도적인데, 자리표시자를 일반 슬라이드가 생성되기 전에 추가해야 Aspose.Slides가 해당 슬라이드에 대응하는 자리표시자 도형을 생성할 수 있기 때문입니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideLayoutType

presentation = Presentation()
try:
    blank_layout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank)

    if blank_layout is None:
        print("The presentation does not contain a Blank layout slide.")
    else:
        placeholder_manager = blank_layout.getPlaceholderManager()
        placeholder_manager.addContentPlaceholder(20, 20, 310, 270)
        placeholder_manager.addVerticalTextPlaceholder(350, 20, 350, 270)
        placeholder_manager.addChartPlaceholder(20, 310, 310, 180)
        placeholder_manager.addTablePlaceholder(350, 310, 350, 180)

        presentation.getSlides().addEmptySlide(blank_layout)
        presentation.save("output-with-placeholders.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

결과:

![The placeholders on the layout slide](add_placeholders.png)

{{% alert color="warning" title="경고" %}}
상속된 서식이나 기존 레이아웃 자리표시자의 기하학을 변경하면 종속 슬라이드에 영향을 줄 수 있습니다. 새로 추가된 레이아웃 자리표시자는 기존 일반 슬라이드에 자동으로 반영되지 않습니다. 레이아웃 변경을 프레젠테이션 복사본에서 테스트하고 모든 종속 슬라이드를 검토하십시오.
{{% /alert %}}

## **사용되지 않는 레이아웃 슬라이드 제거**

[Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/ko/python-java/aspose.slides/compress/#removeUnusedLayoutSlides) 메서드를 사용하여 어떤 일반 슬라이드에서도 참조하지 않는 레이아웃을 제거하십시오. 이 메서드는 아직 사용 중인 레이아웃은 그대로 둡니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Compress, Presentation, SaveFormat

presentation = Presentation("input.pptx")
try:
    Compress.removeUnusedLayoutSlides(presentation)
    presentation.save("output-without-unused-layouts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

특정 레이아웃 하나를 제거하려면 먼저 해당 레이아웃의 [hasDependingSlides](https://reference.aspose.com/slides/ko/python-java/aspose.slides/layoutslide/#hasDependingSlides) 또는 [getDependingSlides](https://reference.aspose.com/slides/ko/python-java/aspose.slides/layoutslide/#getDependingSlides) 메서드를 사용하십시오. [LayoutSlide.remove](https://reference.aspose.com/slides/ko/python-java/aspose.slides/layoutslide/#remove) 호출 전에 종속 슬라이드를 다른 레이아웃으로 재할당하십시오. 사용 중인 레이아웃을 제거하려고 하면 [PptxEditException](https://reference.aspose.com/slides/ko/python-java/aspose.slides/pptxeditexception/)이 발생합니다.

## **레이아웃 슬라이드에서 바닥글 표시 제어**

레이아웃에는 자체 바닥글, 슬라이드 번호 및 날짜/시간 자리표시자가 있습니다. 해당 레이아웃에 대해 이러한 자리표시자를 제어하려면 [LayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/ko/python-java/aspose.slides/layoutslide/#getHeaderFooterManager) 메서드를 사용하십시오. 예를 들어 내용 레이아웃은 바닥글을 표시하고 제목 레이아웃은 표시하지 않아야 할 때 유용합니다.

다음 예제는 레이아웃을 안전하게 선택하고 바닥글 요소를 표시하도록 설정합니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideLayoutType

presentation = Presentation("input.pptx")
try:
    layout_slide = presentation.getLayoutSlides().getByType(SlideLayoutType.TitleAndObject)

    if layout_slide is None:
        layout_slide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank)

    if layout_slide is None:
        print("The presentation does not contain a suitable layout slide.")
    else:
        header_footer_manager = layout_slide.getHeaderFooterManager()
        header_footer_manager.setFooterVisibility(True)
        header_footer_manager.setSlideNumberVisibility(True)
        header_footer_manager.setDateTimeVisibility(True)
        header_footer_manager.setFooterText("Footer text")
        header_footer_manager.setDateTimeText("Date and time text")

        presentation.save("output-with-layout-footers.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **마스터와 자식 레이아웃에서 바닥글 표시 제어**

마스터 계층 전체에 일관된 바닥글 설정을 적용하려면 [MasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/ko/python-java/aspose.slides/masterslide/#getHeaderFooterManager) 메서드를 사용하십시오. [MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/ko/python-java/aspose.slides/masterslideheaderfootermanager/)의 전파 메서드는 마스터와 해당 종속 레이아웃 슬라이드 및 일반 슬라이드에 적용되며, 단일 일반 슬라이드만 대상으로 하지 않습니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("input.pptx")
try:
    header_footer_manager = presentation.getMasters().get_Item(0).getHeaderFooterManager()
    header_footer_manager.setFooterAndChildFootersVisibility(True)
    header_footer_manager.setSlideNumberAndChildSlideNumbersVisibility(True)
    header_footer_manager.setDateTimeAndChildDateTimesVisibility(True)
    header_footer_manager.setFooterAndChildFootersText("Footer text")
    header_footer_manager.setDateTimeAndChildDateTimesText("Date and time text")

    presentation.save("output-with-master-footers.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**마스터 슬라이드와 레이아웃 슬라이드의 차이점은 무엇인가요?**

마스터 슬라이드는 프레젠테이션의 테마와 공유 서식을 정의합니다. 레이아웃 슬라이드는 마스터에 속하며 하나의 재사용 가능한 자리표시자 배치를 정의합니다. 일반 슬라이드는 이러한 레이아웃을 사용하고 슬라이드별 콘텐츠를 저장합니다.

**한 프레젠테이션에서 다른 프레젠테이션으로 레이아웃 슬라이드를 복사할 수 있나요?**

예. [addClone](https://reference.aspose.com/slides/ko/python-java/aspose.slides/globallayoutslidecollection/#addClone) 메서드를 사용하여 대상 컬렉션에 복사본을 추가합니다. 프레젠테이션 간 복사 시 원본 레이아웃이 사용하는 글꼴, 테마, 이미지 및 기타 리소스도 확인하십시오.

**이미 사용 중인 레이아웃을 수정하면 어떻게 되나요?**

종속 슬라이드는 레이아웃 변경을 상속받으며, 해당 슬라이드가 로컬에서 서식이나 개체를 재정의하지 않은 경우 적용됩니다. 자리표시자 기하학 및 상속된 스타일이 많은 슬라이드에 동시에 변경될 수 있습니다. 레이아웃 편집 전에 [getDependingSlides](https://reference.aspose.com/slides/ko/python-java/aspose.slides/layoutslide/#getDependingSlides)로 영향을 받는 슬라이드를 확인하십시오.

**사용 중인 레이아웃을 제거하면 어떻게 되나요?**

Aspose.Slides는 [PptxEditException](https://reference.aspose.com/slides/ko/python-java/aspose.slides/pptxeditexception/)을 발생시킵니다. 먼저 종속 슬라이드를 재할당하거나 [removeUnusedLayoutSlides](https://reference.aspose.com/slides/ko/python-java/aspose.slides/compress/#removeUnusedLayoutSlides)로 참조되지 않는 레이아웃만 제거하십시오.
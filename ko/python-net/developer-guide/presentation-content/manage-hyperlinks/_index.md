---
title: Python에서 프레젠테이션 하이퍼링크 관리
linktitle: 하이퍼링크 관리
type: docs
weight: 20
url: /ko/python-net/manage-hyperlinks/
keywords:
- URL 추가
- 하이퍼링크 추가
- 하이퍼링크 생성
- 하이퍼링크 서식 지정
- 하이퍼링크 제거
- 하이퍼링크 업데이트
- 텍스트 하이퍼링크
- 슬라이드 하이퍼링크
- 도형 하이퍼링크
- 이미지 하이퍼링크
- 비디오 하이퍼링크
- 가변 하이퍼링크
- PowerPoint
- OpenDocument
- 프레젠테이션
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET를 사용하여 Python 예제로 PowerPoint 및 OpenDocument 프레젠테이션에서 하이퍼링크를 추가, 서식 지정, 업데이트 및 제거합니다."
---
## **소개**

하이퍼링크는 프레젠테이션 내용과 웹사이트 또는 프레젠테이션 내 위치를 연결합니다. PowerPoint에서 하이퍼링크는 일반적으로 두 가지 용도로 사용됩니다:

* 텍스트, 도형 또는 미디어 프레임에서 웹사이트를 엽니다.
* 목차와 같이 다른 슬라이드로 이동합니다.

Aspose.Slides for Python via .NET을 사용하면 이러한 링크를 추가하고, 모양 및 사운드를 제어하며, 속성을 업데이트하고, 제거할 수 있습니다. 아래 예제에서는 개별 요소에 대한 하이퍼링크 작업과 프레젠테이션, 슬라이드, 텍스트 프레임 수준에서 하이퍼링크에 액세스하는 방법을 보여줍니다.

{{% alert color="info" title="Note" %}}
프레젠테이션을 [무료 온라인 Aspose PowerPoint 편집기](https://products.aspose.app/slides/ko/editor)로 편집할 수도 있습니다.
{{% /alert %}}

## **URL 하이퍼링크 추가**

텍스트, 도형 또는 미디어 프레임에 웹사이트 URL을 할당할 수 있습니다. 하이퍼링크를 할당하는 요소에 따라 클릭 영역이 결정됩니다: 텍스트 부분은 선택된 텍스트에 링크를 걸고, 도형이나 프레임은 슬라이드 객체에 링크를 겁니다.

### **텍스트에 URL 하이퍼링크 추가**

텍스트를 웹사이트에 연결하려면 아래와 같이 텍스트 부분의 [hyperlink_click](https://reference.aspose.com/slides/ko/python-net/aspose.slides/portionformat/hyperlink_click/) 속성에 [Hyperlink](https://reference.aspose.com/slides/ko/python-net/aspose.slides/hyperlink/)을 할당합니다. 해당 텍스트 부분만 클릭 가능해집니다.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    text_shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50, False)
    text_shape.add_text_frame("Aspose: File Format APIs")
    portion_format = text_shape.text_frame.paragraphs[0].portions[0].portion_format
    portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    portion_format.hyperlink_click.tooltip = "Explore Aspose file format APIs"
    portion_format.font_height = 32
    presentation.save("presentation-out.pptx", slides.export.SaveFormat.PPTX)
```

### **도형 및 미디어 프레임에 URL 하이퍼링크 추가**

도형이나 프레임을 클릭 가능하게 만들려면 해당 [hyperlink_click](https://reference.aspose.com/slides/ko/python-net/aspose.slides/shape/hyperlink_click/) 속성을 설정합니다. 하이퍼링크는 텍스트 부분이 아닌 객체 자체에 속합니다.

같은 접근 방식이 그림, 오디오 및 비디오 프레임에도 적용됩니다: 프레임에 하이퍼링크를 할당하고 필요에 따라 링크의 [tooltip](https://reference.aspose.com/slides/ko/python-net/aspose.slides/hyperlink/tooltip/)을 설정합니다.

다음 예제는 사각형을 클릭 가능하게 만듭니다:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50)
    shape.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    shape.hyperlink_click.tooltip = "Explore Aspose file format APIs"
    presentation.save("presentation-out.pptx", slides.export.SaveFormat.PPTX)
```

## **하이퍼링크를 사용하여 목차 만들기**

내부 하이퍼링크를 사용하면 독자가 목차에서 특정 슬라이드로 이동할 수 있습니다. 다음 예제는 [set_internal_hyperlink_click](https://reference.aspose.com/slides/ko/python-net/aspose.slides/hyperlinkmanager/set_internal_hyperlink_click/)을 사용하여 첫 번째 슬라이드의 “Page 2” 텍스트를 두 번째 슬라이드에 연결합니다.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    first_slide = presentation.slides[0]
    second_slide = presentation.slides.add_empty_slide(first_slide.layout_slide)
    table_of_contents = first_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 300, 100)
    table_of_contents.fill_format.fill_type = slides.FillType.NO_FILL
    table_of_contents.line_format.fill_format.fill_type = slides.FillType.NO_FILL
    table_of_contents.text_frame.paragraphs.clear()
    paragraph = slides.Paragraph()
    paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    paragraph.text = "Title of slide 2 .......... "
    link_portion = slides.Portion()
    link_portion.text = "Page 2"
    link_portion.portion_format.hyperlink_manager.set_internal_hyperlink_click(second_slide)
    paragraph.portions.add(link_portion)
    table_of_contents.text_frame.paragraphs.add(paragraph)
    presentation.save("link_to_slide.pptx", slides.export.SaveFormat.PPTX)
```

## **하이퍼링크 서식 지정**

### **색상**

[Hyperlink](https://reference.aspose.com/slides/ko/python-net/aspose.slides/hyperlink/)의 [color_source](https://reference.aspose.com/slides/ko/python-net/aspose.slides/hyperlink/color_source/) 속성은 하이퍼링크가 프레젠테이션의 하이퍼링크 색상을 사용할지 텍스트 부분의 서식을 사용할지 결정합니다. 사용자 지정 텍스트 색상을 적용하려면 [HyperlinkColorSource.PORTION_FORMAT](https://reference.aspose.com/slides/ko/python-net/aspose.slides/hyperlinkcolorsource/)을 선택하고 부분의 채우기 색을 설정합니다. 이 기능은 PowerPoint 2019에서 도입되었으며 이전 버전에서는 적용되지 않습니다.

다음 예제는 같은 슬라이드에 두 개의 텍스트 하이퍼링크를 추가합니다. 첫 번째는 빨간색 텍스트 채우기를 사용하고, 두 번째는 기본 하이퍼링크 색상을 유지합니다.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    colored_shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 450, 50, False)
    colored_shape.add_text_frame("This hyperlink uses a custom color.")
    colored_portion_format = colored_shape.text_frame.paragraphs[0].portions[0].portion_format
    colored_portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    colored_portion_format.hyperlink_click.color_source = slides.HyperlinkColorSource.PORTION_FORMAT
    colored_portion_format.fill_format.fill_type = slides.FillType.SOLID
    colored_portion_format.fill_format.solid_fill_color.color = draw.Color.red
    default_shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 450, 50, False)
    default_shape.add_text_frame("This hyperlink uses the default color.")
    default_shape.text_frame.paragraphs[0].portions[0].portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    presentation.save("presentation-out-hyperlink.pptx", slides.export.SaveFormat.PPTX)
```

### **소리**

하이퍼링크는 활성화될 때 사운드를 재생하거나 이미 재생 중인 사운드를 중지할 수 있습니다. 다음 속성을 사용하여 이러한 동작을 구성합니다:

- [Hyperlink.sound](https://reference.aspose.com/slides/ko/python-net/aspose.slides/hyperlink/sound/) 은 하이퍼링크와 연결된 오디오를 지정합니다.
- [Hyperlink.stop_sound_on_click](https://reference.aspose.com/slides/ko/python-net/aspose.slides/hyperlink/stop_sound_on_click/) 은 하이퍼링크를 활성화할 때 이전 사운드를 중지할지 여부를 제어합니다.

#### **하이퍼링크 사운드 추가**

다음 예제는 `sampleaudio.wav`를 로드하고 첫 번째 슬라이드의 버튼에 연결합니다. 버튼을 클릭하면 사운드가 재생되고 다음 슬라이드로 이동합니다. 같은 슬라이드의 두 번째 도형은 클릭 시 이전 사운드를 중지하지만 탐색 동작은 수행하지 않습니다.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    with open("sampleaudio.wav", "rb") as audio_file:
        audio_data = audio_file.read()
    hyperlink_sound = presentation.audios.add_audio(audio_data)
    first_slide = presentation.slides[0]
    play_button = first_slide.shapes.add_auto_shape(slides.ShapeType.SOUND_BUTTON, 100, 100, 100, 50)
    play_button.hyperlink_click = slides.Hyperlink.next_slide
    if not play_button.hyperlink_click.stop_sound_on_click and play_button.hyperlink_click.sound is None:
        play_button.hyperlink_click.sound = hyperlink_sound

    second_slide = presentation.slides.add_empty_slide(first_slide.layout_slide)
    stop_button = second_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 100, 50)
    stop_button.hyperlink_click = slides.Hyperlink.no_action
    stop_button.hyperlink_click.stop_sound_on_click = True
    presentation.save("hyperlink-sound.pptx", slides.export.SaveFormat.PPTX)
```

#### **하이퍼링크 사운드 추출**

다음 예제는 위에서 만든 프레젠테이션을 열고 첫 번째 도형의 하이퍼링크 오디오를 [sound](https://reference.aspose.com/slides/ko/python-net/aspose.slides/hyperlink/sound/) 및 [binary_data](https://reference.aspose.com/slides/ko/python-net/aspose.slides/audio/binary_data/)를 통해 메모리로 읽어옵니다.

```python
import aspose.slides as slides

with slides.Presentation("hyperlink-sound.pptx") as presentation:
    if len(presentation.slides) > 0 and len(presentation.slides[0].shapes) > 0:
        hyperlink = presentation.slides[0].shapes[0].hyperlink_click
        sound = hyperlink.sound if hyperlink is not None else None
        if sound is not None:
            audio_data = sound.binary_data
            print(f"Extracted {len(audio_data)} bytes of hyperlink audio.")
        else:
            print("The first shape has no hyperlink sound.")
    else:
        print("The presentation has no first slide or shape to inspect.")
```

### **툴팁 및 상호 작용 설정**

텍스트나 도형에 하이퍼링크를 할당한 후 다음 [Hyperlink](https://reference.aspose.com/slides/ko/python-net/aspose.slides/hyperlink/) 속성을 업데이트할 수 있습니다:

- [tooltip](https://reference.aspose.com/slides/ko/python-net/aspose.slides/hyperlink/tooltip/) 은 사용자가 링크에 대한 힌트로 표시할 수 있는 텍스트를 설정합니다.
- [target_frame](https://reference.aspose.com/slides/ko/python-net/aspose.slides/hyperlink/target_frame/) 은 해당되는 경우 부모 HTML 프레임셋 내의 대상 프레임을 지정합니다.
- [history](https://reference.aspose.com/slides/ko/python-net/aspose.slides/hyperlink/history/) 은 링크를 활성화했을 때 그 목적지를 본 하이퍼링크 목록에 추가할지 여부를 제어합니다.
- [highlight_click](https://reference.aspose.com/slides/ko/python-net/aspose.slides/hyperlink/highlight_click/) 은 클릭 시 하이퍼링크가 강조 표시될지 여부를 제어합니다.

## **프레젠테이션에서 하이퍼링크 제거**

변경하기 전에 텍스트 부분 링크를 포함한 모든 하이퍼링크 컨테이너를 수집하려면 [get_any_hyperlinks](https://reference.aspose.com/slides/ko/python-net/aspose.slides/hyperlinkqueries/get_any_hyperlinks/)을 사용합니다. 다음 예제는 첫 번째 슬라이드에서 두 종류의 활성화를 모두 제거합니다. 하나만 제거하려면 [remove_hyperlink_click](https://reference.aspose.com/slides/ko/python-net/aspose.slides/hyperlinkmanager/remove_hyperlink_click/) 또는 [remove_hyperlink_mouse_over](https://reference.aspose.com/slides/ko/python-net/aspose.slides/hyperlinkmanager/remove_hyperlink_mouse_over/)만 호출합니다; 클릭 동작을 제거해도 마우스 오버 동작은 남습니다.

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    if len(presentation.slides) > 0:
        containers = list(presentation.slides[0].hyperlink_queries.get_any_hyperlinks())
        for container in containers:
            container.hyperlink_manager.remove_hyperlink_click()
            container.hyperlink_manager.remove_hyperlink_mouse_over()
        presentation.save("pres-removed-hyperlinks.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("The presentation has no slides to process.")
```

무조건 제거하려면 [remove_all_hyperlinks](https://reference.aspose.com/slides/ko/python-net/aspose.slides/hyperlinkqueries/remove_all_hyperlinks/)이 선택된 범위에서 두 활성화 유형을 한 번에 제거합니다. 마스터, 레이아웃 및 노트에 대한 선택적 정리와 커버리지는 [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks)를 참조하세요.

## **전체 하이퍼링크 인벤토리 구축**

프레젠테이션을 배포하기 전에 인터랙티브 동작과 웹 링크를 모두 인벤토리화합니다. [get_any_hyperlinks](https://reference.aspose.com/slides/ko/python-net/aspose.slides/hyperlinkqueries/get_any_hyperlinks/)은 URL 문자열의 평면 목록이 아니라 [IHyperlinkContainer](https://reference.aspose.com/slides/ko/python-net/aspose.slides/ihyperlinkcontainer/) 객체를 반환합니다. 각 컨테이너에서 [hyperlink_click](https://reference.aspose.com/slides/ko/python-net/aspose.slides/ihyperlinkcontainer/hyperlink_click/)와 [hyperlink_mouse_over](https://reference.aspose.com/slides/ko/python-net/aspose.slides/ihyperlinkcontainer/hyperlink_mouse_over/)를 모두 검사하세요. 두 속성은 독립적이며, 같은 컨테이너가 두 동작을 모두 가질 수 있으므로 전체 보고서에는 컨테이너당 최대 두 행이 필요합니다.

도형 수준 하이퍼링크만 스캔하면 텍스트 부분에 붙어 있는 링크를 놓칠 수 있습니다. 대신 적절한 범위를 쿼리하고 반환된 컨테이너를 보관하여 이후에 동작을 업데이트하거나 제거할 수 있도록 하세요.

### **프레젠테이션, 슬라이드 및 텍스트 프레임 범위 쿼리**

[HyperlinkQueries](https://reference.aspose.com/slides/ko/python-net/aspose.slides/hyperlinkqueries/) 클래스는 [Presentation.hyperlink_queries](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/hyperlink_queries/), [BaseSlide.hyperlink_queries](https://reference.aspose.com/slides/ko/python-net/aspose.slides/baseslide/hyperlink_queries/) 및 [TextFrame.hyperlink_queries](https://reference.aspose.com/slides/ko/python-net/aspose.slides/textframe/hyperlink_queries/)를 통해 사용할 수 있습니다. 각 범위는 동일한 쿼리를 지원합니다:

- [get_hyperlink_clicks](https://reference.aspose.com/slides/ko/python-net/aspose.slides/hyperlinkqueries/get_hyperlink_clicks/) 은 클릭 작업이 있는 컨테이너를 반환합니다.
- [get_hyperlink_mouse_overs](https://reference.aspose.com/slides/ko/python-net/aspose.slides/hyperlinkqueries/get_hyperlink_mouse_overs/) 은 마우스 오버 작업이 있는 컨테이너를 반환합니다.
- [get_any_hyperlinks](https://reference.aspose.com/slides/ko/python-net/aspose.slides/hyperlinkqueries/get_any_hyperlinks/) 은 하나이든 두 개이든 작업이 있는 컨테이너를 반환합니다.

다음 예제는 외부 클릭 링크, 파일 마우스 오버 링크, 내부 슬라이드 탐색, 텍스트 마우스 오버 링크 및 매크로 동작을 포함하는 `hyperlink-audit-input.pptx`를 생성합니다. 이 예제는 이러한 동작을 실행하지 않습니다. 동일한 세 쿼리는 모든 범위에서 동작하며, 반환된 값은 컨테이너 수를 나타내며 작업 총합이 아닙니다. 텍스트 프레임 범위는 포함된 도형 자체의 링크를 제외합니다.

```python
import aspose.slides as slides


def print_counts(scope, queries):
    click_containers = queries.get_hyperlink_clicks()
    mouse_over_containers = queries.get_hyperlink_mouse_overs()
    all_containers = queries.get_any_hyperlinks()
    print(f"{scope}: click={len(click_containers)}, mouse-over={len(mouse_over_containers)}, any={len(all_containers)}")


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    destination = presentation.slides.add_empty_slide(slide.layout_slide)
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 60)
    shape.text_frame.text = "Click the text to go to slide 2"
    shape.hyperlink_manager.set_external_hyperlink_click("https://example.com/")
    shape.hyperlink_click.tooltip = "Public website"
    shape.hyperlink_manager.set_external_hyperlink_mouse_over("file:///C:/private/report.xlsx")

    portion_format = shape.text_frame.paragraphs[0].portions[0].portion_format
    portion_format.hyperlink_manager.set_internal_hyperlink_click(destination)
    portion_format.hyperlink_manager.set_external_hyperlink_mouse_over("https://example.com/help")
    macro_button = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 120, 200, 60)
    macro_button.hyperlink_manager.set_macro_hyperlink_click("ReviewPresentation")

    print_counts("Presentation", presentation.hyperlink_queries)
    print_counts("Slide 1", slide.hyperlink_queries)
    print_counts("Text frame", shape.text_frame.hyperlink_queries)
    presentation.save("hyperlink-audit-input.pptx", slides.export.SaveFormat.PPTX)
```

이 예제에서는 프레젠테이션 및 슬라이드 쿼리가 각각 클릭 컨테이너 3개, 마우스 오버 컨테이너 2개, 어느 동작이든 포함하는 컨테이너 3개를 보고합니다. 텍스트 프레임 쿼리는 각 카테고리당 하나의 컨테이너를 보고합니다.

### **동작 및 목적지 분류**

[Hyperlink.action_type](https://reference.aspose.com/slides/ko/python-net/aspose.slides/hyperlink/action_type/)을 사용하여 목적지를 해석하기 전에 동작을 해석합니다. [HyperlinkActionType](https://reference.aspose.com/slides/ko/python-net/aspose.slides/hyperlinkactiontype/) 값은 웹 탐색을 넘어서는 범위를 포함합니다:

| Values | 감사 시 의미 |
| --- | --- |
| `HYPERLINK` | 외부 하이퍼링크; URL 및 스킴을 검사합니다. |
| `JUMP_SPECIFIC_SLIDE` | 특정 슬라이드로 내부 이동. |
| `JUMP_FIRST_SLIDE`, `JUMP_PREVIOUS_SLIDE`, `JUMP_NEXT_SLIDE`, `JUMP_LAST_SLIDE`, `JUMP_LAST_VIEWED_SLIDE` | 내장된 슬라이드쇼 탐색으로, 슬라이드쇼 컨텍스트에서 해결됩니다. |
| `JUMP_END_SHOW`, `START_CUSTOM_SLIDE_SHOW` | 현재 쇼를 종료하거나 사용자 정의 쇼를 시작합니다. |
| `START_MACRO` | 매크로 실행. |
| `START_PROGRAM` | 프로그램 실행. |
| `OPEN_FILE`, `OPEN_PRESENTATION` | 파일 또는 다른 프레젠테이션을 엽니다; 웹 URL과 별도로 검토합니다. |
| `START_STOP_MEDIA` | 미디어 재생을 시작하거나 중지합니다. |
| `NO_ACTION`, `UNKNOWN` | 탐색 동작 없음, 또는 검토가 필요한 인식되지 않은 동작. |

외부 목적지는 [external_url](https://reference.aspose.com/slides/ko/python-net/aspose.slides/hyperlink/external_url/)에서, 특정 내부 목적지는 [target_slide](https://reference.aspose.com/slides/ko/python-net/aspose.slides/hyperlink/target_slide/)에서 읽어옵니다. 내부 동작 및 내장 명령에는 외부 URL이 없을 수 있으며, 빈 URL이 해당 컨테이너에 동작이 없다는 의미는 아닙니다. 정규화된 URL과 다를 경우 [external_url_original](https://reference.aspose.com/slides/ko/python-net/aspose.slides/hyperlink/external_url_original/)을 보존하고, 사용 가능한 경우 [tooltip](https://reference.aspose.com/slides/ko/python-net/aspose.slides/hyperlink/tooltip/)을 포함합니다.

### **하이퍼링크 보고, 정리 및 검증**

다음 Python 예제는 기존 프레젠테이션을 읽고(`위에서 만든 파일 사용`), `hyperlink-audit.json`을 쓰고, 정책을 적용한 뒤 `hyperlink-sanitized.pptx`를 저장하고 다시 열어 두 활성화 유형을 다시 확인합니다. 변경 전에 컨테이너를 수집하고 중복 처리를 피하기 위해 각 슬라이드 범위를 한 번만 쿼리합니다. 프레젠테이션 쿼리는 일반 슬라이드를 다루며, 패키지 전체 인벤토리를 위해서는 예제가 일반 슬라이드, 마스터, 레이아웃, 노트 및 존재하는 경우 노트와 핸드아웃 마스터를 쿼리합니다.

보고서는 가능한 경우 1 기반 슬라이드 인덱스와 [slide_id](https://reference.aspose.com/slides/ko/python-net/aspose.slides/baseslide/slide_id/)를 기록합니다. 수집기는 반환된 각 컨테이너와 함께 소유 슬라이드 및 범위를 보관합니다. 마스터, 레이아웃 및 노트는 일반 슬라이드 인덱스가 없으며 범위로 식별됩니다. 도형 컨테이너와 텍스트 부분 서식 컨테이너는 별도로 라벨링되며, 다른 컨테이너 유형은 런타임 형식 이름을 유지합니다. 각 컨테이너에는 보고서 로컬 ID가 부여되어 두 동작을 연관시킬 수 있습니다.

이 고의적인 제한 정책은 절대 HTTPS URL과 유효한 내부 슬라이드 대상만 허용합니다. 매크로, 프로그램, 파일 동작, 기타 슬라이드쇼 동작, 알 수 없는 동작 및 기타 URL 스킴은 거부합니다. 이러한 거부는 정책 결정이며 Aspose.Slides 안전성 판단이 아닙니다. HTTPS만으로는 신뢰를 보장할 수 없으므로 애플리케이션에 호스트 허용 목록 및 기타 검사를 추가하십시오. 원본 및 정규화된 외부 URL 모두가 검사됩니다. 예제는 링크를 따라가거나 동작을 실행하지 않고 메타데이터만 감사합니다.

복구를 위해 컨테이너의 [hyperlink_manager](https://reference.aspose.com/slides/ko/python-net/aspose.slides/ihyperlinkcontainer/hyperlink_manager/)는 [set_external_hyperlink_click](https://reference.aspose.com/slides/ko/python-net/aspose.slides/hyperlinkmanager/set_external_hyperlink_click/), [remove_hyperlink_click](https://reference.aspose.com/slides/ko/python-net/aspose.slides/hyperlinkmanager/remove_hyperlink_click/) 및 [remove_hyperlink_mouse_over](https://reference.aspose.com/slides/ko/python-net/aspose.slides/hyperlinkmanager/remove_hyperlink_mouse_over/)를 지원합니다. 여기서는 금지된 외부 클릭 링크를 고정된 HTTPS 랜딩 페이지로 교체하고, 다른 금지된 클릭과 금지된 마우스 오버 동작은 독립적으로 제거합니다. `replace_external_clicks`를 `False`로 설정하면 모든 정책 위반을 제거합니다. 배포 전에 애플리케이션이 소유한 교체 페이지를 선택하세요.

보고서의 내보내기 플래그는 보수적인 PDF 검토 정책을 사용합니다: 마우스 오버 동작과 외부 링크가 아니거나 특정 슬라이드 점프가 아닌 모든 동작을 잠재적으로 지원되지 않을 수 있다고 표시합니다. 이는 테스트가 아니라 검토 힌트이며, 플래그가 없는 링크가 내보내기에서 살아남을 것이라는 보장은 아닙니다. 지원되는 [PDF](/slides/ko/python-net/convert-powerpoint-to-pdf/) 및 [HTML](/slides/ko/python-net/convert-powerpoint-to-html/) 내보내기는 동작, 옵션 및 뷰어에 따라 하이퍼링크를 보존할 수 있습니다. 래스터 [이미지](/slides/ko/python-net/convert-powerpoint-to-png/)와 [비디오](/slides/ko/python-net/convert-powerpoint-to-video/)는 인터랙티브 하이퍼링크를 보존할 수 없으므로 해당 출력을 감사할 때는 모든 동작에 플래그를 지정하세요.

```python
import json
import sys
from urllib.parse import urlsplit
import aspose.slides as slides


def is_https(value):
    if not value or any(character.isspace() for character in value):
        return False
    try:
        uri = urlsplit(value)
        return uri.scheme.lower() == "https" and bool(uri.hostname)
    except ValueError:
        return False


def policy_violation(link):
    if link is None:
        return None
    if link.action_type == slides.HyperlinkActionType.JUMP_SPECIFIC_SLIDE:
        return "Missing target slide" if link.target_slide is None else None
    if link.action_type != slides.HyperlinkActionType.HYPERLINK:
        return "Action is not allowed"
    if not is_https(link.external_url):
        return "Normalized URL is not absolute HTTPS"
    original = link.external_url_original
    if original and not is_https(original):
        return "Original URL is not absolute HTTPS"
    return None


def slide_index(presentation, slide):
    if slide is not None:
        for index, candidate in enumerate(presentation.slides, start=1):
            if candidate.slide_id == slide.slide_id:
                return index
    return None


def collect_containers(presentation):
    # 각 슬라이드 범위를 한 번씩 쿼리하고, 각 컨테이너에 소유자를 보존합니다.
    scopes = [("Slide", slide) for slide in presentation.slides]
    scopes.extend(("Master", master) for master in presentation.masters)
    scopes.extend(("Layout", layout) for layout in presentation.layout_slides)
    scopes.extend(("Notes", slide.notes_slide_manager.notes_slide) for slide in presentation.slides)
    scopes.append(("Notes master", presentation.master_notes_slide_manager.master_notes_slide))
    scopes.append(("Handout master", presentation.master_handout_slide_manager.master_handout_slide))
    found = []
    for scope, owner in scopes:
        if owner is not None:
            containers = list(owner.hyperlink_queries.get_any_hyperlinks())
            found.extend((container, scope, owner) for container in containers)
    return found


def add_row(rows, presentation, link, activation, container, container_id, scope, owner):
    if link is None:
        return
    target_slide = link.target_slide
    violation = policy_violation(link)
    if isinstance(container, slides.Shape):
        owner_type = "Shape"
    elif isinstance(container, slides.PortionFormat):
        owner_type = "Text portion"
    else:
        owner_type = type(container).__name__
    ordinary_action = link.action_type in (slides.HyperlinkActionType.HYPERLINK, slides.HyperlinkActionType.JUMP_SPECIFIC_SLIDE)
    original_url = link.external_url_original if link.external_url_original != link.external_url else None
    rows.append({
        "container_id": container_id,
        "slide_index": slide_index(presentation, owner) if scope == "Slide" else None,
        "slide_id": owner.slide_id,
        "scope": scope,
        "owner_type": owner_type,
        "activation": activation,
        "action_type": link.action_type.name,
        "external_url": link.external_url,
        "target_slide_index": slide_index(presentation, target_slide),
        "target_slide_id": target_slide.slide_id if target_slide is not None else None,
        "tooltip": link.tooltip,
        "original_external_url": original_url,
        "potentially_unsafe": violation is not None,
        "policy_violation": violation,
        "target_export": "PDF",
        "potentially_unsupported_by_export": activation == "mouse-over" or not ordinary_action,
    })


replace_external_clicks = True
replacement_url = "https://example.com/blocked-link"

with slides.Presentation("hyperlink-audit-input.pptx") as presentation:
    containers = collect_containers(presentation)
    rows = []
    for container_id, (container, scope, owner) in enumerate(containers, start=1):
        add_row(rows, presentation, container.hyperlink_click, "click", container, container_id, scope, owner)
        add_row(rows, presentation, container.hyperlink_mouse_over, "mouse-over", container, container_id, scope, owner)

    with open("hyperlink-audit.json", "w", encoding="utf-8") as report_file:
        json.dump(rows, report_file, indent=2)

    for container, scope, owner in containers:
        click = container.hyperlink_click
        if policy_violation(click) is not None:
            if replace_external_clicks and click.action_type == slides.HyperlinkActionType.HYPERLINK:
                container.hyperlink_manager.set_external_hyperlink_click(replacement_url)
            else:
                container.hyperlink_manager.remove_hyperlink_click()
        if policy_violation(container.hyperlink_mouse_over) is not None:
            container.hyperlink_manager.remove_hyperlink_mouse_over()

    presentation.save("hyperlink-sanitized.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("hyperlink-sanitized.pptx") as reopened:
    remaining_containers = collect_containers(reopened)
    violations = 0
    for container, scope, owner in remaining_containers:
        if policy_violation(container.hyperlink_click) is not None:
            violations += 1
        if policy_violation(container.hyperlink_mouse_over) is not None:
            violations += 1
    print(f"Audit rows: {len(rows)}; prohibited actions after reopening: {violations}")
    if violations != 0:
        print("Verification failed: do not distribute the saved presentation.")
        sys.exit(1)
```

위에서 만든 입력으로 보고서에는 다섯 개의 동작 행이 포함됩니다. 파일 마우스 오버 링크와 매크로 클릭은 제거되고, HTTPS 링크와 내부 슬라이드 탐색은 유지됩니다. 검증은 금지된 동작을 0개로 출력합니다. 금지된 외부 클릭 URL을 포함한 입력은 교체 분기를 실행합니다. 허용된 클릭과 금지된 마우스 오버가 있는 컨테이너는 클릭 동작을 유지합니다.

이 선택적 정리는 [remove_all_hyperlinks](https://reference.aspose.com/slides/ko/python-net/aspose.slides/hyperlinkqueries/remove_all_hyperlinks/)와 다릅니다. 후자는 정책과 무관하게 선택된 범위 전체에서 두 활성화 유형을 모두 제거합니다. 여기서의 검증은 하이퍼링크 동작만 확인하며, 내장된 VBA 프로젝트, OLE 객체 또는 기타 활성 콘텐츠는 제거하지 않고, 내보낸 PDF나 HTML 파일을 검증하지도 않습니다.

## **FAQ**

**섹션 또는 해당 섹션의 첫 번째 슬라이드에 어떻게 링크합니까?**

PowerPoint에서 섹션은 슬라이드를 그룹화하지만, 내부 하이퍼링크는 개별 슬라이드를 대상으로 합니다. 섹션으로 이동하려면 해당 섹션의 첫 번째 슬라이드에 링크하십시오.

**마스터 슬라이드 요소에 하이퍼링크를 첨부하면 모든 슬라이드에서 작동하도록 할 수 있나요?**

예. 마스터 슬라이드 및 레이아웃 요소는 하이퍼링크를 지원합니다. 이러한 요소에 대한 링크는 해당 마스터 또는 레이아웃을 사용하는 슬라이드 쇼 중에 사용할 수 있습니다.

**PDF, HTML, 이미지 또는 비디오로 내보낼 때 하이퍼링크가 유지됩니까?**

지원되는 PDF 및 HTML 내보내기는 하이퍼링크를 보존할 수 있지만, 래스터 이미지와 비디오는 보존할 수 없습니다. 자세한 내용은 [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks)에서 내보내기 고려 사항을 참조하세요.
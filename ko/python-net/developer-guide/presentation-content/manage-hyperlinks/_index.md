---
title: Python을 사용한 프레젠테이션 하이퍼링크 관리
linktitle: 하이퍼링크 관리
type: docs
weight: 20
url: /ko/python-net/manage-hyperlinks/
keywords:
- URL 추가
- 하이퍼링크 추가
- 하이퍼링크 만들기
- 하이퍼링크 서식 지정
- 하이퍼링크 제거
- 하이퍼링크 업데이트
- 텍스트 하이퍼링크
- 슬라이드 하이퍼링크
- 도형 하이퍼링크
- 이미지 하이퍼링크
- 동영상 하이퍼링크
- 가변 하이퍼링크
- PowerPoint
- OpenDocument
- 프레젠테이션
- Python
description: "Aspose.Slides for Python via .NET를 사용하여 PowerPoint 및 OpenDocument 프레젠테이션의 하이퍼링크를 손쉽게 관리하고, 몇 분만에 상호작용과 작업 흐름을 향상시킵니다."
---
## **소개**

하이퍼링크는 외부 리소스, 객체 또는 데이터 항목, 혹은 파일 내의 특정 위치를 참조하는 것입니다. PowerPoint 프레젠테이션에서 일반적인 하이퍼링크 유형은 다음과 같습니다:

* 텍스트, 도형 또는 미디어에 삽입된 웹사이트 링크
* 슬라이드에 대한 링크

Aspose.Slides for Python via .NET은 프레젠테이션에서 다양한 하이퍼링크 관련 작업을 지원합니다.

## **URL 하이퍼링크 추가**

이 섹션에서는 Aspose.Slides를 사용할 때 슬라이드 요소에 URL 하이퍼링크를 추가하는 방법을 설명합니다. 텍스트, 도형 및 그림에 링크 주소를 할당하여 프레젠테이션 중 원활한 탐색을 보장합니다.

### **텍스트에 URL 하이퍼링크 추가**

다음 코드 예제는 텍스트에 웹사이트 하이퍼링크를 추가하는 방법을 보여줍니다:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50, False)
    shape.add_text_frame("Aspose: File Format APIs")
    
    text_portion = shape.text_frame.paragraphs[0].portions[0]

    text_portion.portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    text_portion.portion_format.hyperlink_click.tooltip = "More than 70% of Fortune 100 companies trust Aspose APIs."

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

### **도형 또는 프레임에 URL 하이퍼링크 추가**

다음 코드 예제는 도형에 웹사이트 하이퍼링크를 추가하는 방법을 보여줍니다:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50)

    shape.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    shape.hyperlink_click.tooltip = "More than 70% of Fortune 100 companies trust Aspose APIs."

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

### **미디어에 URL 하이퍼링크 추가**

Aspose.Slides를 사용하면 이미지, 오디오 및 비디오 파일에 하이퍼링크를 추가할 수 있습니다.

다음 코드 예제는 **이미지**에 하이퍼링크를 추가하는 방법을 보여줍니다:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # 프레젠테이션에 이미지를 추가합니다.
    with open("image.jpeg", "rb") as image_stream:
        image_data = image_stream.read()
        image = presentation.images.add_image(image_data)

    # 이전에 추가한 이미지를 사용하여 슬라이드 1에 그림 프레임을 만듭니다.
    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, image)

    picture_frame.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    picture_frame.hyperlink_click.tooltip = "More than 70% of Fortune 100 companies trust Aspose APIs."

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

다음 코드 예제는 **오디오 파일**에 하이퍼링크를 추가하는 방법을 보여줍니다:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("audio.mp3", "rb") as audio_stream:
        audio_data = audio_stream.read()
        audio = presentation.audios.add_audio(audio_data)
        
    audio_frame = slide.shapes.add_audio_frame_embedded(10, 10, 100, 100, audio)

    audio_frame.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    audio_frame.hyperlink_click.tooltip = "More than 70% of Fortune 100 companies trust Aspose APIs."

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

다음 코드 예제는 **비디오**에 하이퍼링크를 추가하는 방법을 보여줍니다:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("video.avi", "rb") as video_stream:
        video_data = video_stream.read()
        video = presentation.videos.add_video(video_data)
        
    video_frame = slide.shapes.add_video_frame(10, 10, 100, 100, video)

    video_frame.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    video_frame.hyperlink_click.tooltip = "More than 70% of Fortune 100 companies trust Aspose APIs."

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="Tip" color="primary" %}}
다음 문서를 확인하시기 바랍니다 [Manage OLE in Presentations Using Python](/slides/ko/python-net/manage-ole/).
{{% /alert %}}

## **하이퍼링크를 사용하여 목차 만들기**

하이퍼링크를 사용하면 객체나 위치를 참조할 수 있으므로, 이를 활용하여 목차를 만들 수 있습니다.

아래 샘플 코드는 하이퍼링크가 포함된 목차를 만드는 방법을 보여줍니다:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    first_slide = presentation.slides[0]
    second_slide = presentation.slides.add_empty_slide(first_slide.layout_slide)

    content_table = first_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 300, 100)
    content_table.fill_format.fill_type = slides.FillType.NO_FILL
    content_table.line_format.fill_format.fill_type = slides.FillType.NO_FILL
    content_table.text_frame.paragraphs.clear()

    paragraph = slides.Paragraph()
    paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    paragraph.text = "Title of slide 2 .......... "

    link_text_portion = slides.Portion()
    link_text_portion.text = "Page 2"
    link_text_portion.portion_format.hyperlink_manager.set_internal_hyperlink_click(second_slide)

    paragraph.portions.add(link_text_portion)
    content_table.text_frame.paragraphs.add(paragraph)

    presentation.save("link_to_slide.pptx", slides.export.SaveFormat.PPTX)
```

## **하이퍼링크 서식 지정**

이 섹션에서는 Aspose.Slides에서 하이퍼링크의 모양을 서식 지정하는 방법을 보여줍니다. 텍스트, 도형 및 그림 전체에 일관된 하이퍼링크 서식을 유지하기 위해 색상 및 기타 스타일 옵션을 제어하는 방법을 배웁니다.

### **하이퍼링크 색상**

[Hyperlink](https://reference.aspose.com/slides/ko/python-net/aspose.slides/hyperlink/) 클래스의 [color_source](https://reference.aspose.com/slides/ko/python-net/aspose.slides/hyperlink/color_source/) 속성을 사용하면 하이퍼링크 색상을 설정하고 색상 정보를 읽을 수 있습니다. 이 기능은 PowerPoint 2019에서 도입되었으며, 이 속성을 통해 변경된 내용은 이전 버전의 PowerPoint에는 적용되지 않습니다.

다음 샘플은 동일 슬라이드에 서로 다른 색상의 하이퍼링크를 추가하는 방법을 보여줍니다:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50, False)
    shape1.add_text_frame("This is a sample of a colored hyperlink.")

    text_portion1 = shape1.text_frame.paragraphs[0].portions[0]
    text_portion1.portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    text_portion1.portion_format.hyperlink_click.color_source = slides.HyperlinkColorSource.PORTION_FORMAT
    text_portion1.portion_format.fill_format.fill_type = slides.FillType.SOLID
    text_portion1.portion_format.fill_format.solid_fill_color.color = draw.Color.red

    shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 450, 50, False)
    shape2.add_text_frame("This is a sample of a regular hyperlink.")

    text_portion2 = shape2.text_frame.paragraphs[0].portions[0]
    text_portion2.portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")

    presentation.save("hyperlinks.pptx", slides.export.SaveFormat.PPTX)
```

## **프레젠테이션에서 하이퍼링크 제거**

이 섹션에서는 Aspose.Slides를 사용하여 프레젠테이션에서 하이퍼링크를 제거하는 방법을 설명합니다. 텍스트, 도형 및 그림에서 링크 대상을 삭제하면서 원본 콘텐츠와 서식은 유지하는 방법을 배웁니다.

### **텍스트에서 하이퍼링크 제거**

다음 샘플 코드는 프레젠테이션 슬라이드의 텍스트에서 하이퍼링크를 제거하는 방법을 보여줍니다:

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if type(shape) is slides.AutoShape:
            for paragraph in shape.text_frame.paragraphs:
                for text_portion in paragraph.portions:
                    text_portion.portion_format.hyperlink_manager.remove_hyperlink_click()

    presentation.save("removed_hyperlinks.pptx", slides.export.SaveFormat.PPTX)
```

### **도형 또는 프레임에서 하이퍼링크 제거**

다음 샘플 코드는 프레젠테이션 슬라이드의 도형에서 하이퍼링크를 제거하는 방법을 보여줍니다:

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
   slide = presentation.slides[0]

   for shape in slide.shapes:
       shape.hyperlink_manager.remove_hyperlink_click()

   presentation.save("removed_hyperlinks.pptx", slides.export.SaveFormat.PPTX)
```

## **가변 하이퍼링크**

[Hyperlink](https://reference.aspose.com/slides/ko/python-net/aspose.slides/hyperlink/) 클래스는 가변입니다. 이 클래스를 사용하면 다음 속성 값을 변경할 수 있습니다:

- [target_frame](https://reference.aspose.com/slides/ko/python-net/aspose.slides/hyperlink/target_frame/)
- [tooltip](https://reference.aspose.com/slides/ko/python-net/aspose.slides/hyperlink/tooltip/)
- [history](https://reference.aspose.com/slides/ko/python-net/aspose.slides/hyperlink/history/)
- [highlight_click](https://reference.aspose.com/slides/ko/python-net/aspose.slides/hyperlink/highlight_click/)
- [stop_sound_on_click](https://reference.aspose.com/slides/ko/python-net/aspose.slides/hyperlink/stop_sound_on_click/)

다음 코드 스니펫은 슬라이드에 하이퍼링크를 추가한 다음 툴팁을 편집하는 방법을 보여줍니다:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50, False)
    shape.add_text_frame("Aspose: File Format APIs")

    text_portion = shape.text_frame.paragraphs[0].portions[0]
    text_portion.portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    text_portion.portion_format.hyperlink_click.tooltip = "More than 70% of Fortune 100 companies trust Aspose APIs."

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **IHyperlinkQueries에서 지원되는 속성**

프레젠테이션, 슬라이드 또는 하이퍼링크가 포함된 텍스트에서 [HyperlinkQueries](https://reference.aspose.com/slides/ko/python-net/aspose.slides/hyperlinkqueries/)에 접근할 수 있습니다.

- [Presentation.hyperlink_queries](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/hyperlink_queries/)
- [BaseSlide.hyperlink_queries](https://reference.aspose.com/slides/ko/python-net/aspose.slides/baseslide/hyperlink_queries/)
- [TextFrame.hyperlink_queries](https://reference.aspose.com/slides/ko/python-net/aspose.slides/textframe/hyperlink_queries/)

[HyperlinkQueries](https://reference.aspose.com/slides/ko/python-net/aspose.slides/hyperlinkqueries/) 클래스는 다음 메서드를 지원합니다:

- [get_hyperlink_clicks()](https://reference.aspose.com/slides/ko/python-net/aspose.slides/hyperlinkqueries/get_hyperlink_clicks/)
- [get_hyperlink_mouse_overs()](https://reference.aspose.com/slides/ko/python-net/aspose.slides/hyperlinkqueries/get_hyperlink_mouse_overs/)
- [get_any_hyperlinks()](https://reference.aspose.com/slides/ko/python-net/aspose.slides/hyperlinkqueries/get_any_hyperlinks/)
- [remove_all_hyperlinks()](https://reference.aspose.com/slides/ko/python-net/aspose.slides/hyperlinkqueries/remove_all_hyperlinks/)

{{% alert color="primary" %}}
Aspose의 간단하고 무료인 온라인 [PowerPoint editor](https://products.aspose.app/slides/ko/editor)를 확인해 보세요.
{{% /alert %}}

## **FAQ**

**슬라이드뿐만 아니라 “섹션”이나 섹션의 첫 번째 슬라이드로 내부 탐색을 만들려면 어떻게 해야 하나요?**

PowerPoint에서 섹션은 슬라이드 그룹이며, 탐색은 기술적으로 특정 슬라이드를 대상으로 합니다. “섹션으로 이동”하려면 일반적으로 해당 섹션의 첫 번째 슬라이드에 링크합니다.

**마스터 슬라이드 요소에 하이퍼링크를 연결하면 모든 슬라이드에서 작동합니까?**

네. 마스터 슬라이드 및 레이아웃 요소는 하이퍼링크를 지원합니다. 이러한 링크는 자식 슬라이드에 표시되며 슬라이드쇼 중 클릭할 수 있습니다.

**PDF, HTML, 이미지 또는 비디오로 내보낼 때 하이퍼링크가 유지됩니까?**

[PDF](/slides/ko/python-net/convert-powerpoint-to-pdf/)와 [HTML](/slides/ko/python-net/convert-powerpoint-to-html/)에서는 일반적으로 링크가 유지됩니다. [이미지](/slides/ko/python-net/convert-powerpoint-to-png/)와 [비디오](/slides/ko/python-net/convert-powerpoint-to-video/)로 내보낼 경우, 래스터 프레임/비디오 형식은 하이퍼링크를 지원하지 않으므로 클릭 가능성이 유지되지 않습니다.
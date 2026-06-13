---
title: Python에서 PowerPoint 프레젠테이션을 HTML로 변환
linktitle: PowerPoint에서 HTML로
type: docs
weight: 30
url: /ko/python-net/convert-powerpoint-to-html/
keywords:
- PowerPoint 변환
- 프레젠테이션 변환
- 슬라이드 변환
- PPT 변환
- PPTX 변환
- PowerPoint에서 HTML로
- 프레젠테이션을 HTML로
- 슬라이드를 HTML로
- PPT를 HTML로
- PPTX를 HTML로
- PowerPoint를 HTML로 저장
- 프레젠테이션을 HTML로 저장
- 슬라이드를 HTML로 저장
- PPT를 HTML로 저장
- PPTX를 HTML로 저장
- PPT를 HTML로 내보내기
- PPTX를 HTML로 내보내기
- Python
- Aspose.Slides
description: "Python에서 PowerPoint 프레젠테이션을 HTML로 변환합니다. Aspose.Slides를 사용하여 PPT 및 PPTX 파일, 선택된 슬라이드, 노트, 글꼴, 이미지, SVG 및 미디어를 내보냅니다."
---
## **개요**

Aspose.Slides for Python via .NET는 Microsoft PowerPoint 없이 PowerPoint 프레젠테이션을 HTML로 저장할 수 있습니다. 기본 변환은 단일 [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 로드와 [SaveFormat](https://reference.aspose.com/slides/ko/python-net/aspose.slides.export/saveformat/) 을 사용한 `save` 호출만으로 이루어집니다. 내보낸 레이아웃, 글꼴, 이미지, 노트, 주석, SVG 출력 또는 연결된 리소스를 제어해야 할 경우 [HtmlOptions](https://reference.aspose.com/slides/ko/python-net/aspose.slides.export/htmloptions/)을 사용하세요.

이 가이드는 실제 HTML 내보내기 시나리오에 중점을 둡니다:

- 전체 프레젠테이션 또는 선택된 슬라이드 내보내기
- 고정 레이아웃, 반응형 또는 SVG 기반 HTML 생성
- 발표자 노트와 주석 포함
- 이미지 품질 및 잘린 이미지 데이터 제어
- 글꼴을 포함하거나 글꼴 파일을 별도로 저장
- 외부 리소스 및 미디어 파일을 기록하고 참조하는 방법 선택

기본적으로 HTML 내보내기는 대부분의 리소스가 포함된 자체 포함 HTML 문서를 생성합니다. 이는 파일 하나로 공유하기 편리하지만 출력 크기가 커질 수 있습니다. 웹 게시를 위해서는 외부 리소스 사용, 이미지 DPI 낮추기, 대상 환경에 신뢰할 수 있게 제공되지 않는 글꼴만 포함하는 것을 고려하세요.

## **프레젠테이션을 HTML로 변환**

프레젠테이션을 HTML로 내보내려면 [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/)을 로드하고 [SaveFormat](https://reference.aspose.com/slides/ko/python-net/aspose.slides.export/saveformat/)을 사용해 저장합니다.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.html", slides.export.SaveFormat.HTML)
```

이 예제는 하나의 HTML 파일을 작성합니다. `with` 문은 내보낸 후 프레젠테이션 객체를 해제하고 파일 핸들과 렌더링 리소스를 해제합니다.

## **HtmlOptions 사용**

[HtmlOptions](https://reference.aspose.com/slides/ko/python-net/aspose.slides.export/htmloptions/)는 HTML 내보내기의 주요 구성 클래스입니다. 일반 설정은 다음과 같습니다:

- `slides_layout_options`: 노트, 주석, 유인물 또는 기타 레이아웃 정보를 추가합니다.
- `html_formatter`: HTML 문서 구조를 변경하거나 포맷팅을 컨트롤러에 위임합니다.
- `slide_image_format`: 슬라이드가 표현되는 방식을 변경합니다(예: SVG).
- `pictures_compression`: 이미지 DPI와 출력 크기를 제어합니다.
- `delete_pictures_cropped_areas`: 잘린 이미지 데이터를 유지하거나 제거합니다.
- `svg_responsive_layout`: 내보낸 SVG 콘텐츠가 컨테이너에 맞게 조정되도록 합니다.
- `show_hidden_slides`: 필요 시 숨겨진 슬라이드를 포함합니다.

아래 섹션에서는 가장 일반적인 옵션을 별도로 보여주므로 작업 흐름에 필요한 옵션만 결합해 사용할 수 있습니다.

## **선택된 슬라이드를 HTML로 변환**

슬라이드 번호를 받는 `save` 오버로드는 1부터 시작하는 슬라이드 위치를 사용합니다. 아래 루프는 각 슬라이드를 별도의 HTML 파일로 저장합니다.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide_count = len(presentation.slides)

    for slide_index in range(slide_count):
        slide_number = slide_index + 1
        slide_numbers = [slide_number]
        html_file_name = "slide-{}.html".format(slide_number)

        presentation.save(html_file_name, slide_numbers, slides.export.SaveFormat.HTML)
```

웹사이트나 애플리케이션이 슬라이드당 하나의 HTML 페이지가 필요할 때 이 패턴을 사용하세요. 모든 슬라이드가 동일한 레이아웃이어야 한다면 하나의 [HtmlOptions](https://reference.aspose.com/slides/ko/python-net/aspose.slides.export/htmloptions/) 인스턴스를 생성하고 각 `save` 호출에 전달합니다.

## **반응형 HTML 만들기**

[ResponsiveHtmlController](https://reference.aspose.com/slides/ko/python-net/aspose.slides.export/responsivehtmlcontroller/)은 [HtmlFormatter](https://reference.aspose.com/slides/ko/python-net/aspose.slides.export/htmlformatter/)를 통해 반응형 HTML 출력을 제공합니다. 내보낸 페이지가 브라우저 너비에 더 잘 맞도록 해야 할 경우 사용하세요.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    controller = slides.export.ResponsiveHtmlController()
    formatter = slides.export.HtmlFormatter.create_custom_formatter(controller)

    html_options = slides.export.HtmlOptions()
    html_options.html_formatter = formatter

    presentation.save("presentation-responsive.html", slides.export.SaveFormat.HTML, html_options)
```

SVG 기반 반응형 레이아웃을 위해서는 [HtmlOptions](https://reference.aspose.com/slides/ko/python-net/aspose.slides.export/htmloptions/)에서 `svg_responsive_layout`을 설정합니다. 이는 슬라이드 내용이 확장 가능한 SVG 마크업으로 내보내질 때 유용합니다.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    html_options = slides.export.HtmlOptions()
    html_options.svg_responsive_layout = True

    presentation.save("presentation-svg-responsive.html", slides.export.SaveFormat.HTML, html_options)
```

## **발표자 노트와 주석 포함**

`html_options.slides_layout_options`를 통해 [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ko/python-net/aspose.slides.export/notescommentslayoutingoptions/)를 사용하면 발표자 노트나 주석을 포함할 수 있습니다. 노트와 주석은 기본적으로 숨겨져 있으며 위치를 선택해야 표시됩니다.

소스 프레젠테이션에 발표자 노트가 포함된 경우:

![Slide with speaker notes in PowerPoint](slide_with_notes.png)

다음 코드는 슬라이드 아래에 발표자 노트를 포함하여 슬라이드 콘텐츠를 내보냅니다.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    layout_options = slides.export.NotesCommentsLayoutingOptions()
    layout_options.notes_position = slides.export.NotesPositions.BOTTOM_FULL

    html_options = slides.export.HtmlOptions()
    html_options.slides_layout_options = layout_options

    presentation.save("presentation-with-notes.html", slides.export.SaveFormat.HTML, html_options)
```

내보낸 HTML에는 노트 영역이 포함됩니다:

![HTML output with the slide and speaker notes](HTML_with_notes.png)

주석을 내보내려면 `comments_position`을 설정하세요(예: `CommentsPositions.RIGHT` 또는 `CommentsPositions.BOTTOM`). 주석만 필요하면 `notes_position`을 생략합니다. 노트와 주석을 모두 원하면 두 속성을 모두 설정합니다.

## **이미지 품질 및 잘린 영역 제어**

HTML 내보내기는 슬라이드 이미지를 압축하여 출력 크기를 줄일 수 있습니다. 더 높은 이미지 품질이 필요하면 [PicturesCompression](https://reference.aspose.com/slides/ko/python-net/aspose.slides.export/picturescompression/) 중 하나를 `pictures_compression`에 설정하세요.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    html_options = slides.export.HtmlOptions()
    html_options.pictures_compression = slides.export.PicturesCompression.DPI150

    presentation.save("presentation-dpi-150.html", slides.export.SaveFormat.HTML, html_options)
```

기본적으로 이미지의 잘린 영역은 내보낸 결과에서 제거될 수 있습니다. 사용자가 숨겨진 이미지 부분을 복구하거나 검사해야 할 경우에만 잘린 데이터를 유지하세요. 유지하면 HTML 크기가 증가합니다.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    html_options = slides.export.HtmlOptions()
    html_options.delete_pictures_cropped_areas = False

    presentation.save("presentation-with-cropped-areas.html", slides.export.SaveFormat.HTML, html_options)
```

## **CSS 추가**

간단한 스타일링을 위해 CSS 문자열을 [HtmlFormatter](https://reference.aspose.com/slides/ko/python-net/aspose.slides.export/htmlformatter/)에 전달합니다. 이렇게 하면 Aspose.Slides가 슬라이드 콘텐츠를 렌더링하는 동안 주변 HTML 문서를 변경할 수 있습니다.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    css_rules = "body { margin: 0; background: #f7f7f7; } .slide { margin: 24px auto; }"
    formatter = slides.export.HtmlFormatter.create_document_formatter(css_rules, True)

    html_options = slides.export.HtmlOptions()
    html_options.html_formatter = formatter

    presentation.save("presentation-styled.html", slides.export.SaveFormat.HTML, html_options)
```

맞춤 문서 헤더, 연결된 CSS 파일, 또는 슬라이드와 도형 주변에 맞춤 마크업이 필요하면 커스텀 포맷팅 컨트롤러를 만들고 `create_custom_formatter`와 함께 [HtmlFormatter](https://reference.aspose.com/slides/ko/python-net/aspose.slides.export/htmlformatter/)에 전달합니다.

## **글꼴 포함**

대상 환경에 프레젠테이션 글꼴이 설치되지 않을 수 있는 경우 [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/ko/python-net/aspose.slides.export/embedallfontshtmlcontroller/)를 사용해 HTML에 글꼴을 포함합니다. 포함하면 시각적 정확도가 향상되지만 출력 크기가 증가합니다.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    font_names_to_exclude = ["Arial"]
    font_controller = slides.export.EmbedAllFontsHtmlController(font_names_to_exclude)
    formatter = slides.export.HtmlFormatter.create_custom_formatter(font_controller)

    html_options = slides.export.HtmlOptions()
    html_options.html_formatter = formatter

    presentation.save("presentation-embedded-fonts.html", slides.export.SaveFormat.HTML, html_options)
```

대상 브라우저나 시스템에 이미 글꼴이 제공된다고 확신할 때만 글꼴을 제외하세요. 브랜드 글꼴이나 흔하지 않은 글꼴은 보통 포함하는 것이 안전합니다.

## **글꼴 파일을 외부에 두고 링크하기**

HTML 파일 크기를 줄이려면 글꼴 데이터를 별도의 WOFF 파일에 쓰고 HTML에 `@font-face` 규칙을 추가할 수 있습니다. 이를 위해서는 내보내기 중 글꼴 데이터를 어떻게 기록할지 커스터마이즈하는 컨트롤러가 필요합니다. Python via .NET에서는 작은 .NET 헬퍼 어셈블리를 구현하고 Python에서 로드한 뒤 `create_custom_formatter`와 함께 [HtmlFormatter](https://reference.aspose.com/slides/ko/python-net/aspose.slides.export/htmlformatter/)에 전달합니다.

글꼴을 외부화할 때는 두 경로를 명확히 지정해야 합니다:

- 생성된 WOFF 파일이 기록되는 파일 시스템 출력 디렉터리
- HTML 문서에 표시되고 브라우저가 글꼴 파일을 로드할 URL 경로

배포 경로가 최종 확정될 때까지 HTML 파일과 생성된 글꼴 파일을 함께 보관하세요. 파일을 다른 위치에 배포하면 URL 접두사가 배포된 URL 경로와 일치하도록 조정합니다.

## **리소스를 외부에 저장**

자체 포함 HTML은 이동이 쉽지만 Base64로 인코딩된 리소스가 파일을 크게 만들 수 있습니다. 애플리케이션에서 외부 이미지, 글꼴, 오디오, 비디오 파일이 필요하면 커스텀 링크/임베드 컨트롤러를 만들고 [HtmlOptions](https://reference.aspose.com/slides/ko/python-net/aspose.slides.export/htmloptions/) 생성자에 전달합니다.

리소스를 외부화할 때는 두 경로를 명확히 지정해야 합니다:

- 애플리케이션이 생성된 이미지, 글꼴, 오디오 또는 비디오를 기록하는 파일 시스템 출력 경로
- 브라우저가 HTML 문서에서 해당 파일을 로드하기 위해 사용하는 URL 경로

전체 이미지 링크에 대한 논의는 [Export Presentations to HTML with Externally Linked Images](/slides/ko/python-net/exporting-presentations-to-html-with-externally-linked-images/)를 참고하세요.

## **미디어 파일 내보내기**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/ko/python-net/aspose.slides.export/videoplayerhtmlcontroller/)는 비디오와 오디오 파일을 내보내고 브라우저에서 재생할 수 있는 HTML을 작성합니다. 생성자는 다음을 받습니다:

- `path`: 생성된 미디어 파일이 기록될 디렉터리
- `file_name`: 생성 중인 HTML 파일 이름
- `base_uri`: HTML 링크에서 미디어 파일을 가리키는 절대 URI 접두사

HTML 파일이 `html-output/presentation.html`이고 미디어 파일이 `html-output/media`에 저장된다면, `path`는 디스크상의 미디어 디렉터리를 가리키고 `base_uri`는 브라우저 관점에서 동일한 디렉터리를 가리켜야 합니다. 로컬 미리보기에서는 미디어 디렉터리에서 `file:///` URI를 만들 수 있습니다. 배포된 애플리케이션에서는 공개된 미디어 디렉터리의 절대 URL을 사용하세요.

```python
import os
from pathlib import Path

import aspose.slides as slides

output_directory = os.path.join(os.getcwd(), "html-output")
media_directory = os.path.join(output_directory, "media")
os.makedirs(output_directory, exist_ok=True)
os.makedirs(media_directory, exist_ok=True)

html_file_name = "presentation.html"
media_base_uri = Path(media_directory).as_uri() + "/"

with slides.Presentation() as presentation:
    with open("intro.mp4", "rb") as video_stream:
        video = presentation.videos.add_video(
            video_stream,
            slides.LoadingStreamBehavior.READ_STREAM_AND_RELEASE)

    slide = presentation.slides[0]
    slide.shapes.add_video_frame(20, 20, 480, 270, video)

    controller = slides.export.VideoPlayerHtmlController(
        media_directory,
        html_file_name,
        media_base_uri)

    formatter = slides.export.HtmlFormatter.create_custom_formatter(controller)
    svg_options = slides.export.SVGOptions(controller)
    slide_image_format = slides.export.SlideImageFormat.svg(svg_options)

    html_options = slides.export.HtmlOptions(controller)
    html_options.html_formatter = formatter
    html_options.slide_image_format = slide_image_format

    html_file_path = os.path.join(output_directory, html_file_name)
    presentation.save(html_file_path, slides.export.SaveFormat.HTML, html_options)
```

특히 서버 애플리케이션에서는 내보내기 작업당 고유한 출력 디렉터리를 사용하세요. 공유 출력 경로는 서로 다른 변환 작업의 파일이 서로 덮어쓰는 원인이 될 수 있습니다.

## **성능 및 리소스 관리**

HTML 변환은 렌더링 작업이므로 처리 시간과 메모리 사용량은 슬라이드 수, 이미지 해상도, 글꼴, 효과, 차트 및 포함된 미디어에 따라 달라집니다. 높은 `pictures_compression` DPI 값, 포함된 글꼴, SVG 출력 및 유지된 잘린 이미지 영역은 품질을 높이지만 일반적으로 출력 크기를 증가시킵니다.

배치 변환 시:

- 모든 [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 인스턴스를 즉시 해제합니다.
- 작업마다 별도 출력 디렉터리를 사용합니다.
- 품질이 필요하지 않은 경우 일반 글꼴을 포함하지 않습니다.
- HTML이 미리보기나 썸네일용이면 이미지 DPI를 낮춥니다.
- 배포 경로가 확정될 때까지 원본 프레젠테이션, 생성된 HTML 및 외부 리소스를 함께 보관합니다.

## **FAQ**

**HTML 출력에서 하이퍼링크가 유지되나요?**

네. 프레젠테이션 하이퍼링크는 HTML로 내보내지며 대상 URL이 유효하면 클릭할 수 있습니다.

**프레젠테이션을 병렬로 HTML로 변환할 수 있나요?**

가능하지만 하나의 [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 인스턴스를 여러 스레드가 공유하면 안 됩니다. 서로 다른 파일을 별도의 프레젠테이션 인스턴스, 별도 스트림 및 별도 출력 디렉터리로 처리하세요. 자세한 내용은 [multithreading guidance](/slides/ko/python-net/multithreading/)를 참고하세요.

**Presentation 객체는 스레드 안전한가요?**

아니오. 단일 [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 인스턴스는 하나의 스레드에서만 로드, 수정, 저장 및 해제해야 합니다. 병렬 작업을 위해서는 스레드당 독립적인 인스턴스를 생성하거나 프로세스를 분리하세요.

**생성된 HTML 파일이 큰 이유는 무엇인가요?**

기본 내보내기는 리소스를 HTML에 직접 포함합니다. 포함된 글꼴, 고 DPI 이미지, 미디어, SVG 콘텐츠 및 유지된 잘린 이미지 영역이 크기를 증가시킵니다. 외부 리소스를 사용하고, 일반 글꼴 포함을 제외하며, `pictures_compression` 값을 낮추면 작은 출력이 최대 품질보다 중요할 때 도움이 됩니다.

**PowerPoint에서 24 pt와 같은 글꼴 크기가 HTML에서는 17.999819 pt로 표시되는 이유는?**

PowerPoint와 HTML은 서로 다른 DPI 모델을 사용하기 때문입니다. PowerPoint는 72 DPI 기반의 전형적인 포인트를 사용하고, HTML 레이아웃은 96 DPI 기반의 CSS 픽셀을 사용합니다. Aspose.Slides가 프레젠테이션을 HTML로 내보낼 때 글꼴 크기가 두 시스템 간에 변환되며, 이 과정에서 작은 반올림 차이가 발생할 수 있습니다.

이 값들은 실제 시각적 글꼴 크기 변화가 아니라 PowerPoint와 HTML 간 텍스트 측정값을 변환하면서 발생하는 수학적 부작용일 뿐입니다.

**미디어 내보내기용 base_uri는 어떻게 선택해야 하나요?**

브라우저 관점에서의 경로를 `base_uri`로 선택하고 절대 URI로 전달하세요. 로컬 미리보기에서는 `Path(media_directory).as_uri() + "/"`와 같이 출력 디렉터리에서 파생시킬 수 있습니다. 배포 시에는 공개된 미디어 디렉터리의 절대 URL을 사용합니다. 파일 시스템 `path`와 브라우저 `base_uri`는 동일한 문자열일 필요는 없지만 동일한 리소스 위치를 가리켜야 합니다.

**숨겨진 슬라이드를 포함할 수 있나요?**

네. 숨겨진 슬라이드를 내보내야 할 경우 [HtmlOptions](https://reference.aspose.com/slides/ko/python-net/aspose.slides.export/htmloptions/)에서 `show_hidden_slides = True`로 설정하세요.
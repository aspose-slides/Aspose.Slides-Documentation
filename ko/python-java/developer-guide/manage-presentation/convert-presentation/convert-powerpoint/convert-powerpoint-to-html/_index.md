---
title: Python via Java를 사용하여 PowerPoint 프레젠테이션을 HTML로 변환
linktitle: PowerPoint를 HTML로 변환
type: docs
weight: 30
url: /ko/python-java/convert-powerpoint-to-html/
keywords:
- PowerPoint 변환
- 프레젠테이션 변환
- 슬라이드 변환
- PPT 변환
- PPTX 변환
- PowerPoint를 HTML로 변환
- 프레젠테이션을 HTML로 변환
- 슬라이드를 HTML로 변환
- PPT를 HTML로 변환
- PPTX를 HTML로 변환
- PowerPoint를 HTML로 저장
- 프레젠테이션을 HTML로 저장
- 슬라이드를 HTML로 저장
- PPT를 HTML로 저장
- PPTX를 HTML로 저장
- PPT를 HTML로 내보내기
- PPTX를 HTML로 내보내기
- 파이썬
- 자바
- Aspose.Slides
description: "Python via Java를 사용하여 PowerPoint 프레젠테이션을 HTML로 변환합니다. Aspose.Slides를 사용하면 PPT 및 PPTX 파일, 선택된 슬라이드, 노트, 글꼴, 이미지, SVG 및 미디어를 내보낼 수 있습니다."
---
## **개요**

Aspose.Slides for Python via Java은 Microsoft PowerPoint 없이 PowerPoint 프레젠테이션을 HTML로 저장할 수 있습니다. 기본 변환은 단일 [Presentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/) 로드와 [save](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/#save) 호출에 [SaveFormat](https://reference.aspose.com/slides/ko/python-java/aspose.slides/saveformat/)을 사용하는 것입니다. 내보낸 레이아웃, 글꼴, 이미지, 노트, 댓글, SVG 출력 또는 연결된 리소스를 제어해야 할 때는 [HtmlOptions](https://reference.aspose.com/slides/ko/python-java/aspose.slides/htmloptions/)을 사용하십시오.

이 가이드는 실용적인 HTML 내보내기 시나리오에 중점을 둡니다:

- 전체 프레젠테이션 또는 선택된 슬라이드를 내보냅니다.
- 고정 레이아웃, 반응형 또는 SVG 기반 HTML을 생성합니다.
- 발표자 노트와 댓글을 포함합니다.
- 이미지 품질과 잘린 이미지 데이터를 제어합니다.
- 글꼴을 임베드하거나 글꼴 파일을 별도로 저장합니다.
- 외부 리소스와 미디어 파일이 작성되고 참조되는 방식을 선택합니다.

기본적으로 HTML 내보내기는 대부분의 리소스가 포함된 자체 포함 HTML 문서를 생성합니다. 이는 하나의 파일을 공유하기에 편리하지만 출력 크기가 커질 수 있습니다. 웹 게시를 위해서는 외부 리소스를 사용하고, 이미지 DPI를 낮추며, 대상 환경에서 신뢰할 수 없게 제공되는 글꼴만 임베드하는 것을 고려하십시오.

## **프레젠테이션을 HTML로 변환**

프레젠테이션을 HTML로 내보내려면 [Presentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/)을 사용해 로드하고 [SaveFormat.Html](https://reference.aspose.com/slides/ko/python-java/aspose.slides/saveformat/#Html)으로 저장합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation.html", SaveFormat.Html)
finally:
    presentation.dispose()
```

각 예제는 현재 작업 디렉터리에서 `presentation.pptx`를 로드합니다. 실행하기 전에 Aspose.Slides for Python via Java와 호환되는 Java 런타임을 설치하십시오. JVM은 Python 프로세스당 한 번 시작됩니다.

이 예제는 하나의 HTML 파일을 작성합니다. 프레젠테이션 객체는 `finally` 블록에서 해제되어 내보낸 후 파일 핸들과 렌더링 리소스를 해제합니다.

## **HTML 내보내기 구성**

[HtmlOptions](https://reference.aspose.com/slides/ko/python-java/aspose.slides/htmloptions/)은 HTML 내보내기를 위한 주요 구성 클래스입니다. 일반적인 설정에는 다음이 포함됩니다:

- [setSlidesLayoutOptions](https://reference.aspose.com/slides/ko/python-java/aspose.slides/htmloptions/#setSlidesLayoutOptions): 노트, 댓글, 유인물 또는 기타 레이아웃 정보를 추가합니다.
- [setHtmlFormatter](https://reference.aspose.com/slides/ko/python-java/aspose.slides/htmloptions/#setHtmlFormatter): HTML 문서 구조를 변경하거나 포맷팅을 컨트롤러에 위임합니다.
- [setSlideImageFormat](https://reference.aspose.com/slides/ko/python-java/aspose.slides/htmloptions/#setSlideImageFormat): 슬라이드가 표현되는 방식을 변경합니다(예: SVG).
- [setPicturesCompression](https://reference.aspose.com/slides/ko/python-java/aspose.slides/htmloptions/#setPicturesCompression): 이미지 DPI와 출력 크기를 제어합니다.
- [setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/ko/python-java/aspose.slides/htmloptions/#setDeletePicturesCroppedAreas): 잘린 이미지 데이터를 유지하거나 제거합니다.
- [setSvgResponsiveLayout](https://reference.aspose.com/slides/ko/python-java/aspose.slides/htmloptions/#setSvgResponsiveLayout): 내보낸 SVG 콘텐츠가 컨테이너에 맞게 조정됩니다.
- [setShowHiddenSlides](https://reference.aspose.com/slides/ko/python-java/aspose.slides/htmloptions/#setShowHiddenSlides): 필요에 따라 숨겨진 슬라이드를 포함합니다.

다음 섹션에서는 가장 일반적인 옵션을 별도로 보여주어 워크플로에 필요한 옵션만 조합할 수 있도록 합니다.

## **선택된 슬라이드를 HTML로 변환**

[Presentation.save](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/#save)에서 슬라이드 번호를 받아들이는 오버로드는 1 기반 슬라이드 위치를 사용합니다. 아래 루프는 각 슬라이드를 별개의 HTML 파일로 저장합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    slide_count = presentation.getSlides().size()
    for slide_index in range(slide_count):
        slide_number = slide_index + 1
        slide_numbers = jpype.JArray(jpype.JInt)([slide_number])
        html_file_name = f"slide-{slide_number}.html"
        presentation.save(html_file_name, slide_numbers, SaveFormat.Html)
finally:
    presentation.dispose()
```

웹사이트나 애플리케이션이 슬라이드당 하나의 HTML 페이지가 필요할 때 이 패턴을 사용하십시오. 각 슬라이드가 동일한 레이아웃을 가져야 한다면 하나의 [HtmlOptions](https://reference.aspose.com/slides/ko/python-java/aspose.slides/htmloptions/) 인스턴스를 생성하고 각 [Presentation.save](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/#save) 호출에 전달합니다.

## **반응형 HTML 만들기**

[ResponsiveHtmlController](https://reference.aspose.com/slides/ko/python-java/aspose.slides/responsivehtmlcontroller/)은 [HtmlFormatter](https://reference.aspose.com/slides/ko/python-java/aspose.slides/htmlformatter/)를 통해 반응형 HTML 출력을 제공합니다. 내보낸 페이지가 브라우저 너비에 더 잘 맞도록 해야 할 때 사용하십시오.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HtmlFormatter, HtmlOptions, Presentation, ResponsiveHtmlController, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    controller = ResponsiveHtmlController()
    formatter = HtmlFormatter.createCustomFormatter(controller)

    html_options = HtmlOptions()
    html_options.setHtmlFormatter(formatter)

    presentation.save("presentation-responsive.html", SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

SVG 기반 반응형 레이아웃의 경우 `True`와 함께 [HtmlOptions.setSvgResponsiveLayout](https://reference.aspose.com/slides/ko/python-java/aspose.slides/htmloptions/#setSvgResponsiveLayout)를 호출합니다. 슬라이드 콘텐츠가 확장 가능한 SVG 마크업으로 내보내질 때 유용합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HtmlOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    html_options = HtmlOptions()
    html_options.setSvgResponsiveLayout(True)

    presentation.save("presentation-svg-responsive.html", SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

## **발표자 노트 및 댓글 포함**

[HtmlOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/ko/python-java/aspose.slides/htmloptions/#setSlidesLayoutOptions)를 통해 [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ko/python-java/aspose.slides/notescommentslayoutingoptions/)를 사용하여 발표자 노트나 댓글을 포함합니다. 위치를 지정하지 않으면 노트와 댓글은 기본적으로 숨겨져 있습니다.

예를 들어 원본 프레젠테이션에 발표자 노트가 포함되어 있다고 가정합니다:

![PowerPoint에서 발표자 노트가 있는 슬라이드](slide_with_notes.png)

다음 코드는 슬라이드 콘텐츠를 슬라이드 아래에 발표자 노트를 포함하여 내보냅니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HtmlOptions, NotesCommentsLayoutingOptions, NotesPositions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    layout_options = NotesCommentsLayoutingOptions()
    layout_options.setNotesPosition(NotesPositions.BottomFull)

    html_options = HtmlOptions()
    html_options.setSlidesLayoutOptions(layout_options)

    presentation.save("presentation-with-notes.html", SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

내보낸 HTML에는 노트 영역이 포함됩니다:

![슬라이드와 발표자 노트가 포함된 HTML 출력](HTML_with_notes.png)

댓글을 내보내려면 [NotesCommentsLayoutingOptions.setCommentsPosition](https://reference.aspose.com/slides/ko/python-java/aspose.slides/notescommentslayoutingoptions/#setCommentsPosition)을 호출하고, 예를 들어 [CommentsPositions.Right](https://reference.aspose.com/slides/ko/python-java/aspose.slides/commentspositions/#Right) 또는 [CommentsPositions.Bottom](https://reference.aspose.com/slides/ko/python-java/aspose.slides/commentspositions/#Bottom)을 사용합니다. 댓글만 필요하면 [NotesCommentsLayoutingOptions.setNotesPosition](https://reference.aspose.com/slides/ko/python-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition)을 생략하십시오. 노트와 댓글을 모두 필요로 하면 두 메서드를 모두 호출합니다.

## **이미지 품질 및 잘린 영역 제어**

HTML 내보내기는 슬라이드 이미지를 압축하여 출력 크기를 줄일 수 있습니다. 더 높은 이미지 품질이 필요할 때는 [PicturesCompression](https://reference.aspose.com/slides/ko/python-java/aspose.slides/picturescompression/)에서 값을 가져와 [HtmlOptions.setPicturesCompression](https://reference.aspose.com/slides/ko/python-java/aspose.slides/htmloptions/#setPicturesCompression)에 전달하십시오.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HtmlOptions, PicturesCompression, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    html_options = HtmlOptions()
    html_options.setPicturesCompression(PicturesCompression.Dpi150)

    presentation.save("presentation-dpi-150.html", SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

기본적으로 이미지의 잘린 영역은 내보낸 결과에서 제거될 수 있습니다. 사용자가 숨겨진 이미지 부분을 복구하거나 검사해야 할 경우에만 잘린 데이터를 유지하십시오. 이를 유지하면 HTML 크기가 증가할 수 있습니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HtmlOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    html_options = HtmlOptions()
    html_options.setDeletePicturesCroppedAreas(False)

    presentation.save("presentation-with-cropped-areas.html", SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

## **CSS 추가**

간단한 스타일링을 위해 CSS 문자열을 [HtmlFormatter.createDocumentFormatter](https://reference.aspose.com/slides/ko/python-java/aspose.slides/htmlformatter/#createDocumentFormatter)에 전달합니다. 이렇게 하면 Aspose.Slides가 슬라이드 콘텐츠를 계속 렌더링하는 동안 주변 HTML 문서가 변경됩니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HtmlFormatter, HtmlOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    css_rules = "body { margin: 0; background: #f7f7f7; } .slide { margin: 24px auto; }"
    formatter = HtmlFormatter.createDocumentFormatter(css_rules, True)

    html_options = HtmlOptions()
    html_options.setHtmlFormatter(formatter)

    presentation.save("presentation-styled.html", SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

맞춤 문서 헤더, 연결된 CSS 파일, 또는 슬라이드와 도형 주변의 맞춤 마크업이 필요하면 JPype 인터페이스 프록시를 통해 사용자 정의 포맷팅 컨트롤러를 사용하고 이를 [HtmlFormatter](https://reference.aspose.com/slides/ko/python-java/aspose.slides/htmlformatter/)에 [HtmlFormatter.createCustomFormatter](https://reference.aspose.com/slides/ko/python-java/aspose.slides/htmlformatter/#createCustomFormatter)와 함께 전달하십시오.

## **글꼴 임베드**

대상 환경에 프레젠테이션 글꼴이 설치되지 않을 수 있는 경우 [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/ko/python-java/aspose.slides/embedallfontshtmlcontroller/)를 사용해 HTML에 글꼴을 임베드하십시오. 임베드는 시각적 충실도를 높이지만 출력 크기가 증가합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EmbedAllFontsHtmlController, HtmlFormatter, HtmlOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    font_names_to_exclude = jpype.JArray(jpype.JString)(["Arial"])
    font_controller = EmbedAllFontsHtmlController(font_names_to_exclude)
    formatter = HtmlFormatter.createCustomFormatter(font_controller)

    html_options = HtmlOptions()
    html_options.setHtmlFormatter(formatter)

    presentation.save("presentation-embedded-fonts.html", SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

대상 브라우저나 시스템이 이미 해당 글꼴을 제공한다고 확신할 때만 글꼴을 제외하십시오. 브랜드 글꼴이나 일반적이지 않은 글꼴은 대개 임베드하는 것이 더 안전합니다.

## **리소스를 외부에 저장**

자체 포함 HTML은 이동이 쉽지만, 임베드된 Base64 리소스로 인해 파일이 커질 수 있습니다. 애플리케이션에서 외부 이미지 파일이 필요하면 JPype 인터페이스 프록시를 통해 리소스 연결 컨트롤러를 구현하고 이를 [HtmlOptions](https://reference.aspose.com/slides/ko/python-java/aspose.slides/htmloptions/) 생성자에 전달하십시오.

리소스를 외부화할 때는 두 경로를 신중히 선택하십시오:

- 파일 시스템 출력 경로: 애플리케이션이 생성된 이미지, 글꼴, 오디오 또는 비디오를 쓰는 위치.
- URL 경로: 브라우저가 HTML 문서에서 해당 파일을 로드하는 데 사용하는 경로.

## **미디어 파일 내보내기**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/ko/python-java/aspose.slides/videoplayerhtmlcontroller/)는 비디오 및 오디오 파일을 내보내고 브라우저에서 재생할 수 있는 HTML을 작성합니다. 생성자는 다음을 받습니다:

- `path`: 생성된 미디어 파일이 기록될 디렉터리.
- `fileName`: 생성 중인 HTML 파일 이름.
- `baseUri`: HTML 링크에서 미디어 파일에 사용되는 절대 URI 접두사.

다음 예제는 `presentation.pptx`에 이미 포함된 미디어를 내보냅니다. 생성된 HTML은 파일 이름만으로 미디어 파일을 참조하며 HTML 문서에 대해 상대 경로이므로 `path`는 HTML 파일도 받는 디렉터리여야 합니다. `baseUri`는 절대 URI여야 합니다: 로컬 미리보기를 위해서는 출력 디렉터리에서 `file:///` URI를 만들고, 배포된 애플리케이션의 경우 게시된 디렉터리의 절대 URL을 사용하십시오.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HtmlFormatter, HtmlOptions, Presentation, SVGOptions, SaveFormat, SlideImageFormat, VideoPlayerHtmlController

from pathlib import Path

output_directory = Path("html-output").resolve()
output_directory.mkdir(parents=True, exist_ok=True)
html_file_name = "presentation.html"
media_base_uri = output_directory.as_uri() + "/"

presentation = Presentation("presentation.pptx")
try:
    controller = VideoPlayerHtmlController(str(output_directory), html_file_name, media_base_uri)
    formatter = HtmlFormatter.createCustomFormatter(controller)
    svg_options = SVGOptions(controller)
    slide_image_format = SlideImageFormat.svg(svg_options)

    html_options = HtmlOptions(controller)
    html_options.setHtmlFormatter(formatter)
    html_options.setSlideImageFormat(slide_image_format)

    html_file_path = output_directory / html_file_name
    presentation.save(str(html_file_path), SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

특히 서버 애플리케이션에서는 각 내보내기 작업마다 고유한 출력 디렉터리를 사용하십시오. 공유 출력 경로는 서로 다른 변환의 파일이 서로 덮어쓰일 수 있습니다.

## **성능 및 리소스 관리**

HTML 변환은 렌더링 작업이므로 처리 시간 및 메모리 사용량은 슬라이드 수, 이미지 해상도, 글꼴, 효과, 차트 및 임베드된 미디어에 따라 달라집니다. [HtmlOptions.setPicturesCompression](https://reference.aspose.com/slides/ko/python-java/aspose.slides/htmloptions/#setPicturesCompression)에 전달되는 높은 이미지 DPI 값, 임베드된 글꼴, SVG 출력 및 유지된 잘린 이미지 영역은 충실도를 향상시킬 수 있지만 일반적으로 출력 크기를 증가시킵니다.

대량 변환을 위해서는:

- 각 [Presentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/) 인스턴스를 신속히 해제하십시오.
- 각 작업마다 별도의 출력 디렉터리를 사용하십시오.
- 충실도가 필요하지 않다면 일반 글꼴을 임베드하지 마세요.
- HTML이 미리보기 또는 썸네일용인 경우 이미지 DPI를 낮추십시오.
- 배포 경로가 확정될 때까지 원본 프레젠테이션, 생성된 HTML 및 외부 리소스를 함께 보관하십시오.

## **FAQ**

**HTML 출력에서 하이퍼링크가 보존되나요?**

예. 프레젠테이션 하이퍼링크가 HTML로 내보내어지고 대상 URL이 유효하면 클릭할 수 있습니다.

**프레젠테이션을 병렬로 HTML로 변환할 수 있나요?**

예, 하지만 하나의 [Presentation] 인스턴스를 스레드 간에 공유하지 마십시오. 서로 다른 파일을 별도의 프레젠테이션 인스턴스, 별도의 스트림 및 별도의 출력 디렉터리로 처리하십시오. 자세한 내용은 [멀티스레딩 가이드](/slides/ko/python-java/multithreading/)를 참조하십시오.

**프레젠테이션 객체가 스레드 안전한가요?**

아니오. 단일 [Presentation] 인스턴스는 하나의 스레드에서 로드, 수정, 저장 및 해제되어야 합니다. 병렬 작업을 위해서는 스레드 또는 프로세스당 독립적인 인스턴스를 생성하십시오.

**생성된 HTML 파일이 큰 이유는 무엇인가요?**

기본 내보내기는 리소스를 HTML에 직접 임베드할 수 있습니다. 임베드된 글꼴, 고 DPI 이미지, 미디어, SVG 콘텐츠 및 유지된 잘린 이미지 영역도 크기를 증가시킵니다. 외부 리소스를 사용하고, 일반 글꼴은 임베드하지 않으며, 최대 충실도보다 출력 크기가 더 중요할 경우 [HtmlOptions.setPicturesCompression](https://reference.aspose.com/slides/ko/python-java/aspose.slides/htmloptions/#setPicturesCompression)에 낮은 DPI 값을 전달하십시오.

**HTML의 font-size 값이 PowerPoint 값과 다른 이유는 무엇인가요?**

내보낸 페이지는 SVG 좌표계와 스케일 변환을 사용할 수 있습니다. 순수 CSS 또는 SVG font-size 값만으로는 최종 표시 크기를 설명하지 못합니다. 의도한 확대 수준에서 렌더링된 슬라이드를 비교하고, 텍스트가 다르게 보이면 글꼴이 제공되는지 확인하십시오.

**미디어 내보내기용 baseUri는 어떻게 선택해야 하나요?**

`baseUri`는 브라우저 관점에서 선택하고 절대 URI로 전달하십시오. 로컬 미리보기를 위해서는 `output_directory.as_uri() + "/"`와 같이 출력 디렉터리에서 파생시킬 수 있습니다. 배포 시에는 게시된 디렉터리의 절대 URL을 사용하십시오. 파일 시스템 `path`와 브라우저 `baseUri`는 동일한 문자열일 필요는 없지만 동일한 위치를 가리켜야 하며, 그 위치는 미디어 링크가 해당 디렉터리를 기준으로 상대 경로로 작성되므로 생성된 HTML 파일이 들어있는 디렉터리여야 합니다.

**숨겨진 슬라이드를 포함할 수 있나요?**

예. 숨겨진 슬라이드를 내보내야 할 경우 `True`와 함께 [HtmlOptions.setShowHiddenSlides](https://reference.aspose.com/slides/ko/python-java/aspose.slides/htmloptions/#setShowHiddenSlides)를 호출하십시오.
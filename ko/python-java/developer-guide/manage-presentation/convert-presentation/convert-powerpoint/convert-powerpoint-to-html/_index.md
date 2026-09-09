---
title: Python via Java를 사용하여 PowerPoint 프레젠테이션을 HTML로 변환
linktitle: PowerPoint를 HTML로
type: docs
weight: 30
url: /ko/python-java/convert-powerpoint-to-html/
keywords:
- PowerPoint 변환
- 프레젠테이션 변환
- 슬라이드 변환
- PPT 변환
- PPTX 변환
- PowerPoint를 HTML로
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
- Java
- Aspose.Slides
description: "Python via Java를 사용하여 PowerPoint 프레젠테이션을 HTML로 변환합니다. Aspose.Slides를 이용해 PPT 및 PPTX 파일, 선택 슬라이드, 노트, 글꼴, 이미지, SVG 및 미디어를 내보낼 수 있습니다."
---
## **Overview**

Aspose.Slides for Python via Java은 Microsoft PowerPoint 없이 PowerPoint 프레젠테이션을 HTML로 저장할 수 있습니다. 기본 변환은 단일 [Presentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/) 로드와 [save](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/#save) 호출에 [SaveFormat](https://reference.aspose.com/slides/ko/python-java/aspose.slides/saveformat/)을 사용하는 것입니다. 내보낸 레이아웃, 글꼴, 이미지, 노트, 주석, SVG 출력 또는 연결된 리소스를 제어해야 할 경우 [HtmlOptions](https://reference.aspose.com/slides/ko/python-java/aspose.slides/htmloptions/)를 사용하십시오.

이 가이드는 실용적인 HTML 내보내기 시나리오에 초점을 맞춥니다:

- 전체 프레젠테이션 또는 선택한 슬라이드를 내보냅니다.
- 고정 레이아웃, 반응형, 또는 SVG 기반 HTML을 생성합니다.
- 발표자 노트와 주석을 포함합니다.
- 이미지 품질 및 잘라낸 이미지 데이터를 제어합니다.
- 글꼴을 임베드하거나 글꼴 파일을 별도로 저장합니다.
- 외부 리소스 및 미디어 파일이 작성되고 참조되는 방식을 선택합니다.

기본적으로 HTML 내보내기는 대부분의 리소스가 포함된 자체 포함 HTML 문서를 생성합니다. 하나의 파일을 공유하기에 편리하지만 출력 크기가 커질 수 있습니다. 웹 게시를 위해서는 외부 리소스 사용, 이미지 DPI 낮추기, 대상 환경에 신뢰할 수 있게 제공되지 않는 글꼴만 임베드하는 것을 고려하십시오.

## **Convert a Presentation to HTML**

프레젠테이션을 HTML로 내보내려면 [Presentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/)으로 로드하고 [SaveFormat.Html](https://reference.aspose.com/slides/ko/python-java/aspose.slides/saveformat/#Html)으로 저장합니다.

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

이 예제는 하나의 HTML 파일을 작성합니다. 프레젠테이션 객체는 `finally` 블록에서 해제되어 내보내기 후 파일 핸들과 렌더링 리소스를 해제합니다.

## **Configure HTML Export**

[HtmlOptions](https://reference.aspose.com/slides/ko/python-java/aspose.slides/htmloptions/)는 HTML 내보내기의 주요 구성 클래스입니다. 일반적인 설정은 다음과 같습니다:

- [setSlidesLayoutOptions](https://reference.aspose.com/slides/ko/python-java/aspose.slides/htmloptions/#setSlidesLayoutOptions): 노트, 주석, 유인물 또는 기타 레이아웃 정보를 추가합니다.
- [setHtmlFormatter](https://reference.aspose.com/slides/ko/python-java/aspose.slides/htmloptions/#setHtmlFormatter): HTML 문서 구조를 변경하거나 포맷팅을 컨트롤러에 위임합니다.
- [setSlideImageFormat](https://reference.aspose.com/slides/ko/python-java/aspose.slides/htmloptions/#setSlideImageFormat): 슬라이드가 SVG와 같이 표시되는 방식을 변경합니다.
- [setPicturesCompression](https://reference.aspose.com/slides/ko/python-java/aspose.slides/htmloptions/#setPicturesCompression): 이미지 DPI 및 출력 크기를 제어합니다.
- [setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/ko/python-java/aspose.slides/htmloptions/#setDeletePicturesCroppedAreas): 잘라낸 이미지 데이터를 유지하거나 제거합니다.
- [setSvgResponsiveLayout](https://reference.aspose.com/slides/ko/python-java/aspose.slides/htmloptions/#setSvgResponsiveLayout): 내보낸 SVG 콘텐츠가 컨테이너에 맞게 조정되도록 합니다.
- [setShowHiddenSlides](https://reference.aspose.com/slides/ko/python-java/aspose.slides/htmloptions/#setShowHiddenSlides): 필요에 따라 숨겨진 슬라이드를 포함합니다.

다음 섹션에서는 가장 일반적인 옵션을 개별적으로 보여 주어 워크플로에 필요한 옵션만 조합할 수 있도록 합니다.

## **Convert Selected Slides to HTML**

슬라이드 번호를 받아들이는 [Presentation.save](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/#save) 오버로드는 1부터 시작하는 슬라이드 위치를 사용합니다. 아래 루프는 각 슬라이드를 별도의 HTML 파일로 저장합니다.

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

웹사이트나 애플리케이션에서 슬라이드당 하나의 HTML 페이지가 필요할 때 이 패턴을 사용하십시오. 각 슬라이드에 동일한 레이아웃이 필요하면 하나의 [HtmlOptions](https://reference.aspose.com/slides/ko/python-java/aspose.slides/htmloptions/) 인스턴스를 만들고 모든 [Presentation.save](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/#save) 호출에 전달하십시오.

## **Create Responsive HTML**

[ResponsiveHtmlController](https://reference.aspose.com/slides/ko/python-java/aspose.slides/responsivehtmlcontroller/)는 [HtmlFormatter](https://reference.aspose.com/slides/ko/python-java/aspose.slides/htmlformatter/)를 통해 반응형 HTML 출력을 제공합니다. 내보낸 페이지가 브라우저 너비에 더 잘 맞도록 하려면 이를 사용하십시오.

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

SVG 기반 반응형 레이아웃을 위해서는 `True`와 함께 [HtmlOptions.setSvgResponsiveLayout](https://reference.aspose.com/slides/ko/python-java/aspose.slides/htmloptions/#setSvgResponsiveLayout)를 호출하십시오. 슬라이드 내용이 확장 가능한 SVG 마크업으로 내보내질 때 유용합니다.

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

## **Include Speaker Notes and Comments**

[NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ko/python-java/aspose.slides/notescommentslayoutingoptions/)을 [HtmlOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/ko/python-java/aspose.slides/htmloptions/#setSlidesLayoutOptions)를 통해 사용하면 발표자 노트나 주석을 포함할 수 있습니다. 기본적으로 노트와 주석은 숨겨져 있으며 위치를 지정해야 표시됩니다.

소스 프레젠테이션에 발표자 노트가 포함되어 있다고 가정합니다:

![PowerPoint에서 발표자 노트가 있는 슬라이드](slide_with_notes.png)

다음 코드는 슬라이드 아래에 발표자 노트를 포함하여 슬라이드 내용을 내보냅니다.

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

주석을 내보내려면 [NotesCommentsLayoutingOptions.setCommentsPosition](https://reference.aspose.com/slides/ko/python-java/aspose.slides/notescommentslayoutingoptions/#setCommentsPosition)를 호출하고 예를 들어 [CommentsPositions.Right](https://reference.aspose.com/slides/ko/python-java/aspose.slides/commentspositions/#Right) 또는 [CommentsPositions.Bottom](https://reference.aspose.com/slides/ko/python-java/aspose.slides/commentspositions/#Bottom)과 함께 사용하십시오. 주석만 필요하면 [NotesCommentsLayoutingOptions.setNotesPosition](https://reference.aspose.com/slides/ko/python-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition)를 생략하십시오. 노트와 주석을 모두 원한다면 두 메서드를 모두 호출하십시오.

## **Control Image Quality and Cropped Areas**

HTML 내보내기는 슬라이드 이미지를 압축하여 출력 크기를 줄일 수 있습니다. 더 높은 이미지 품질이 필요할 때는 [PicturesCompression](https://reference.aspose.com/slides/ko/python-java/aspose.slides/picturescompression/)에서 값을 선택하여 [HtmlOptions.setPicturesCompression](https://reference.aspose.com/slides/ko/python-java/aspose.slides/htmloptions/#setPicturesCompression)에 전달하십시오.

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

기본적으로 이미지의 잘라낸 영역은 내보낸 결과에서 제거될 수 있습니다. 사용자가 숨겨진 이미지 부분을 복구하거나 검토해야 하는 경우에만 잘라낸 데이터를 유지하십시오. 유지하면 HTML 크기가 증가할 수 있습니다.

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

## **Add CSS**

간단한 스타일링을 위해서는 [HtmlFormatter.createDocumentFormatter](https://reference.aspose.com/slides/ko/python-java/aspose.slides/htmlformatter/#createDocumentFormatter)에 CSS 문자열을 전달하십시오. 이렇게 하면 Aspose.Slides가 슬라이드 내용을 계속 렌더링하는 동안 주변 HTML 문서를 변경할 수 있습니다.

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

맞춤형 문서 헤더, 연결된 CSS 파일, 또는 슬라이드와 도형 주위에 맞춤 마크업을 적용하려면 JPype 인터페이스 프록시를 통해 사용자 정의 포맷팅 컨트롤러를 구현하고 이를 [HtmlFormatter](https://reference.aspose.com/slides/ko/python-java/aspose.slides/htmlformatter/)에 [HtmlFormatter.createCustomFormatter](https://reference.aspose.com/slides/ko/python-java/aspose.slides/htmlformatter/#createCustomFormatter)와 함께 전달하십시오.

## **Embed Fonts**

대상 환경에 프레젠테이션에 사용된 글꼴이 설치되지 않을 수 있는 경우 [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/ko/python-java/aspose.slides/embedallfontshtmlcontroller/)를 사용하여 HTML에 글꼴을 임베드하십시오. 임베드는 시각적 충실도를 높이지만 출력 크기를 늘립니다.

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

대상 브라우저나 시스템에 이미 글꼴이 제공된다고 확신할 때만 글꼴을 제외하십시오. 브랜드 글꼴이나 덜 흔한 글꼴의 경우 임베드하는 것이 일반적으로 더 안전합니다.

## **Save Resources Externally**

자체 포함 HTML은 이동이 쉽지만 Base64로 임베드된 리소스 때문에 파일이 크게 될 수 있습니다. 애플리케이션에서 외부 이미지 파일이 필요하면 JPype 인터페이스 프록시를 통해 리소스 연결 컨트롤러를 구현하고 이를 [HtmlOptions](https://reference.aspose.com/slides/ko/python-java/aspose.slides/htmloptions/) 생성자에 전달하십시오.

리소스를 외부화할 때는 두 경로를 명확히 선택하십시오:

- 파일 시스템 출력 경로: 애플리케이션이 생성된 이미지, 글꼴, 오디오 또는 비디오를 기록하는 위치.
- URL 경로: 브라우저가 HTML 문서에서 해당 파일을 로드할 때 사용하는 경로.

## **Export Media Files**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/ko/python-java/aspose.slides/videoplayerhtmlcontroller/)는 비디오 및 오디오 파일을 내보내고 브라우저에서 재생할 수 있는 HTML을 작성합니다. 생성자는 다음 매개변수를 받습니다:

- `path`: 생성된 미디어 파일이 기록될 디렉터리.
- `fileName`: 생성 중인 HTML 파일 이름.
- `baseUri`: HTML 내 미디어 파일 링크에 사용되는 절대 URI 접두사.

다음 예제는 `presentation.pptx`에 이미 포함된 미디어를 내보냅니다. 생성된 HTML은 파일 이름만으로 미디어 파일을 참조하며, 이는 HTML 문서에 상대적인 경로이므로 `path`는 HTML 파일이 함께 저장되는 디렉터리여야 합니다. `baseUri`는 절대 URI여야 합니다. 로컬 미리보기용으로는 출력 디렉터리에서 `file:///` URI를 만들고, 배포용으로는 공개 디렉터리의 절대 URL을 사용하십시오.

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

서버 애플리케이션에서는 특히 변환 작업마다 고유한 출력 디렉터리를 사용하십시오. 공유 출력 경로를 사용하면 서로 다른 변환 작업의 파일이 서로 덮어쓰기될 수 있습니다.

## **Performance and Resource Management**

HTML 변환은 렌더링 작업이므로 처리 시간과 메모리 사용량은 슬라이드 수, 이미지 해상도, 글꼴, 효과, 차트 및 임베드된 미디어에 따라 달라집니다. [HtmlOptions.setPicturesCompression](https://reference.aspose.com/slides/ko/python-java/aspose.slides/htmloptions/#setPicturesCompression)에 전달하는 높은 DPI 값, 임베드된 글꼴, SVG 출력 및 유지된 잘라낸 이미지 영역은 충실도를 높이지만 일반적으로 출력 크기를 증가시킵니다.

배치 변환 시:

- 모든 [Presentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/) 인스턴스를 즉시 해제하십시오.
- 작업마다 별도의 출력 디렉터리를 사용하십시오.
- 충실도가 필요하지 않은 경우 일반 글꼴의 임베드를 피하십시오.
- HTML이 미리보기 또는 썸네일 용이라면 이미지 DPI를 낮추십시오.
- 배포 경로가 최종 결정될 때까지 원본 프레젠테이션, 생성된 HTML 및 외부 리소스를 함께 보관하십시오.

## **FAQ**

**하이퍼링크가 HTML 출력에서도 유지되나요?**

네. 프레젠테이션의 하이퍼링크가 HTML로 내보내지며 대상 URL이 유효하면 클릭할 수 있습니다.

**프레젠테이션을 병렬로 HTML로 변환할 수 있나요?**

네, 하지만 하나의 [Presentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/) 인스턴스를 스레드 간에 공유하지 마십시오. 파일마다 별개의 프레젠테이션 인스턴스, 별개의 스트림 및 별개의 출력 디렉터리를 사용하여 처리하십시오. 자세한 내용은 [multithreading guidance](/slides/ko/python-java/multithreading/)를 참조하십시오.

**프레젠테이션 객체가 스레드 안전한가요?**

아니요. 단일 [Presentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/) 인스턴스는 하나의 스레드에서 로드, 수정, 저장 및 해제되어야 합니다. 병렬 작업을 수행하려면 스레드당 독립적인 인스턴스를 생성하거나 별도의 프로세스를 사용하십시오.

**생성된 HTML 파일이 왜 큰가요?**

기본 내보내기는 리소스를 HTML에 직접 임베드할 수 있습니다. 임베드된 글꼴, 고 DPI 이미지, 미디어, SVG 콘텐츠 및 유지된 잘라낸 이미지 영역이 크기를 늘립니다. 외부 리소스를 사용하고, 일반 글꼴을 임베드에서 제외하고, 더 작은 출력이 최대 충실도보다 중요한 경우 [HtmlOptions.setPicturesCompression](https://reference.aspose.com/slides/ko/python-java/aspose.slides/htmloptions/#setPicturesCompression)에 낮은 DPI 값을 전달하십시오.

**HTML에서 font-size 값이 PowerPoint 값과 다른 이유는?**

내보낸 페이지는 SVG 좌표계와 스케일 변환을 사용할 수 있습니다. 순수 CSS 또는 SVG font-size 값만으로는 최종 표시 크기를 설명하지 못합니다. 의도한 줌 레벨에서 렌더링된 슬라이드를 비교하고, 텍스트가 다르게 보일 경우 글꼴 가용성을 확인하십시오.

**미디어 내보내기를 위한 baseUri는 어떻게 선택해야 하나요?**

브라우저 관점에서 `baseUri`를 선택하고 절대 URI로 전달하십시오. 로컬 미리보기의 경우 `output_directory.as_uri() + "/"`와 같이 출력 디렉터리에서 파생시킬 수 있습니다. 배포 시에는 공개 디렉터리의 절대 URL을 사용하십시오. 파일 시스템 `path`와 브라우저 `baseUri`가 동일한 문자열일 필요는 없지만 동일한 위치를 가리켜야 하며, 그 위치는 생성된 HTML 파일이 들어 있는 디렉터리여야 합니다. 미디어 링크가 해당 파일을 기준으로 상대 경로로 작성되기 때문입니다.

**숨겨진 슬라이드를 포함할 수 있나요?**

네. 숨겨진 슬라이드를 내보내야 할 경우 `True`와 함께 [HtmlOptions.setShowHiddenSlides](https://reference.aspose.com/slides/ko/python-java/aspose.slides/htmloptions/#setShowHiddenSlides)를 호출하십시오.
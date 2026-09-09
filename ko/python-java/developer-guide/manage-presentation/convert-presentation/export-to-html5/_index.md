---
title: Python via Java에서 프레젠테이션을 HTML5로 변환
linktitle: 프레젠테이션을 HTML5로
type: docs
weight: 40
url: /ko/python-java/export-to-html5/
keywords:
- PowerPoint를 HTML5로
- OpenDocument를 HTML5로
- 프레젠테이션을 HTML5로
- 슬라이드를 HTML5로
- PPT를 HTML5로
- PPTX를 HTML5로
- ODP를 HTML5로
- PPT를 HTML5로 저장
- PPTX를 HTML5로 저장
- ODP를 HTML5로 저장
- PPT를 HTML5로 내보내기
- PPTX를 HTML5로 내보내기
- ODP를 HTML5로 내보내기
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java를 사용하여 PowerPoint 및 OpenDocument 프레젠테이션을 반응형 HTML5로 내보냅니다. 서식, 애니메이션 및 인터랙티브 요소를 보존합니다."
---
## **개요**

이 문서는 Aspose.Slides를 사용하여 PowerPoint 프레젠테이션을 HTML5로 변환하는 방법을 설명합니다. 추가 웹 확장 없이 기본 HTML5 내보내기와 도형 애니메이션 및 슬라이드 전환을 제어하는 옵션을 다룹니다. 또한 표준 PowerPoint‑to‑HTML 내보내기 과정을 보여주고, 슬라이드 뷰 모드에서 HTML5 출력을 생성하는 방법과 레이아웃을 구성하여 내보낸 문서에 주석을 포함하는 방법을 시연합니다.

예제는 Aspose.Slides for Python via Java와 호환되는 Java 런타임이 필요합니다. `pres.pptx`(주석 예제의 경우 `sample.pptx`)를 현재 작업 디렉터리에 배치하십시오. 각 예제는 JVM이 이미 실행 중이 아닌 경우에만 JVM을 시작합니다.

## **PowerPoint를 HTML5로 내보내기**

[Presentation.save](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/#save)와 [SaveFormat.Html5](https://reference.aspose.com/slides/ko/python-java/aspose.slides/saveformat/#Html5)를 사용하여 추가 웹 확장 없이 프레젠테이션을 내보냅니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    presentation.save("pres.html", SaveFormat.Html5)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}} 
HTML5 내보내기 도구는 브라우저에서 보기 위한 HTML 콘텐츠를 생성합니다. 
{{% /alert %}}

[Html5Options](https://reference.aspose.com/slides/ko/python-java/aspose.slides/html5options/)를 사용하여 내보내기를 구성합니다. [setAnimateShapes](https://reference.aspose.com/slides/ko/python-java/aspose.slides/html5options/#setAnimateShapes)와 [setAnimateTransitions](https://reference.aspose.com/slides/ko/python-java/aspose.slides/html5options/#setAnimateTransitions)를 `False` 로 호출하면 도형 애니메이션과 슬라이드 전환을 비활성화할 수 있습니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Html5Options, Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    html5_options = Html5Options()
    html5_options.setAnimateShapes(False)
    html5_options.setAnimateTransitions(False)

    presentation.save("pres5.html", SaveFormat.Html5, html5_options)
finally:
    presentation.dispose()
```

## **PowerPoint를 HTML로 내보내기**

표준 HTML 내보내기에는 [SaveFormat.Html](https://reference.aspose.com/slides/ko/python-java/aspose.slides/saveformat/#Html)를 사용합니다. 자세한 옵션은 [Convert PowerPoint to HTML](/slides/ko/python-java/convert-powerpoint-to-html/)를 참고하십시오:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    presentation.save("pres.html", SaveFormat.Html)
finally:
    presentation.dispose()
```

이 경우 프레젠테이션 내용이 SVG를 통해 다음과 같이 렌더링됩니다:

```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> THE SLIDE CONTENT GOES HERE </g>
     </svg>
</div>
</body>
```

{{% alert title="Warning" color="warning" %}} 
표준 HTML 내보내기는 SVG를 통해 슬라이드 내용을 렌더링하며 HTML5 도형 애니메이션 및 슬라이드 전환 옵션을 제공하지 않습니다. 
{{% /alert %}}

## **PowerPoint를 HTML5 슬라이드 뷰로 내보내기**

**Aspose.Slides**를 사용하면 프레젠테이션을 HTML5 문서로 변환하면서 슬라이드를 슬라이드 뷰 모드로 표시할 수 있습니다. 이렇게 하면 브라우저에서 생성된 HTML5 파일을 열 때 웹 페이지에서 슬라이드 뷰 모드로 프레젠테이션이 표시됩니다. 

다음 Python 코드는 PowerPoint를 HTML5 슬라이드 뷰로 내보내는 과정을 보여 줍니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Html5Options, Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    html5_options = Html5Options()
    html5_options.setAnimateShapes(True)
    html5_options.setAnimateTransitions(True)

    presentation.save("HTML5-slide-view.html", SaveFormat.Html5, html5_options)
finally:
    presentation.dispose()
```

## **주석이 포함된 HTML5 문서로 프레젠테이션 변환**

PowerPoint의 주석은 사용자가 슬라이드에 메모나 피드백을 남길 수 있는 도구이며, 특히 여러 사람이 협업 프로젝트에서 주요 내용은 변경하지 않고 특정 슬라이드 요소에 제안이나 의견을 추가할 때 유용합니다. 각 주석에는 작성자 이름이 표시되어 누가 남겼는지 쉽게 추적할 수 있습니다.

예를 들어 "sample.pptx" 파일에 저장된 다음 PowerPoint 프레젠테이션이 있다고 가정합니다.

![프레젠테이션 슬라이드의 두 개 주석](two_comments_pptx.png)

PowerPoint 프레젠테이션을 HTML5 문서로 변환할 때 프레젠테이션에 포함된 주석을 출력 문서에 포함시킬지 여부를 쉽게 지정할 수 있습니다. 이를 위해 [Html5Options](https://reference.aspose.com/slides/ko/python-java/aspose.slides/html5options/) 클래스의 [setSlidesLayoutOptions](https://reference.aspose.com/slides/ko/python-java/aspose.slides/html5options/#setSlidesLayoutOptions) 메서드에 주석 표시 매개변수를 전달합니다.

[NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ko/python-java/aspose.slides/notescommentslayoutingoptions/)와 [setCommentsPosition](https://reference.aspose.com/slides/ko/python-java/aspose.slides/notescommentslayoutingoptions/#setCommentsPosition)를 사용하고, 위치는 [CommentsPositions.Right](https://reference.aspose.com/slides/ko/python-java/aspose.slides/commentspositions/#Right)으로 설정합니다. 다음 코드 예제는 슬라이드 오른쪽에 주석이 표시되는 HTML5 문서로 프레젠테이션을 변환합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CommentsPositions, NotesCommentsLayoutingOptions, Html5Options, Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    layout_options = NotesCommentsLayoutingOptions()
    layout_options.setCommentsPosition(CommentsPositions.Right)

    html5_options = Html5Options()
    html5_options.setSlidesLayoutOptions(layout_options)

    presentation.save("output.html", SaveFormat.Html5, html5_options)
finally:
    presentation.dispose()
```

아래 이미지에 "output.html" 문서가 표시됩니다.

![출력 HTML5 문서에 표시된 주석](two_comments_html5.png)

## **FAQ**

**HTML5에서 객체 애니메이션 및 슬라이드 전환이 재생되는지를 제어할 수 있나요?**

예, HTML5는 [shape animations](https://reference.aspose.com/slides/ko/python-java/aspose.slides/html5options/#setAnimateShapes)과 [slide transitions](https://reference.aspose.com/slides/ko/python-java/aspose.slides/html5options/#setAnimateTransitions)를 각각 활성화하거나 비활성화할 수 있는 별도 옵션을 제공합니다.

**주석을 내보낼 수 있나요? 슬라이드와 relative하게 어디에 배치할 수 있나요?**

예, 주석은 HTML5에 추가할 수 있으며 [layout settings](https://reference.aspose.com/slides/ko/python-java/aspose.slides/html5options/#setSlidesLayoutOptions)을 통해 (예: 슬라이드 오른쪽) 위치를 지정할 수 있습니다.

**보안 또는 CSP 이유로 JavaScript를 호출하는 링크를 건너뛸 수 있나요?**

예, 저장 시 JavaScript 호출이 포함된 하이퍼링크를 건너뛸 수 있는 [setting](https://reference.aspose.com/slides/ko/python-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks)이 있습니다. 이 설정은 해당 하이퍼링크를 제거하지만, 생성된 모든 HTML5 스크립트가 사이트의 콘텐츠 보안 정책을 만족한다는 것을 보장하지는 않습니다.
---
title: .NET에서 프레젠테이션을 HTML5로 변환
linktitle: 프레젠테이션을 HTML5로
type: docs
weight: 40
url: /ko/net/export-to-html5/
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
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET를 사용하여 PowerPoint 및 OpenDocument 프레젠테이션을 반응형 HTML5로 내보냅니다. 형식, 애니메이션 및 인터랙티브 기능을 보존합니다."
---
## **개요**

이 문서에서는 Aspose.Slides for .NET을 사용하여 PowerPoint 프레젠테이션을 HTML5로 변환하는 방법을 설명합니다. 기본 내보내기, 도형 애니메이션 및 슬라이드 전환 제어, 주석 레이아웃을 다루며, HTML5 출력과 표준 HTML 내보내기의 SVG 기반 출력을 비교합니다.

## **PowerPoint를 HTML5로 내보내기**

다음 예제는 작업 디렉터리에서 프레젠테이션을 로드하고 HTML5 형식으로 저장합니다. 기본 내보내기 설정을 사용하며, 다음 예제에서는 애니메이션 재생을 명시적으로 제어하는 방법을 보여줍니다. 입력 경로를 실제 프레젠테이션 경로로 바꾸세요.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("pres.pptx");
presentation.Save("pres.html", SaveFormat.Html5);
```

{{% alert color="info" title="Note" %}}
HTML 문서 외에도 내보내기는 슬라이드 스타일링, 애니메이션, 효과 및 탐색을 위한 CSS 및 JavaScript 파일을 생성합니다. 출력물을 이동하거나 게시할 때 HTML 문서와 함께 이러한 파일을 보관하십시오. 생성된 페이지는 공개 CDN에서 jQuery와 Anime.js를 로드하는데, 이들이 없으면 슬라이드 탐색 및 애니메이션이 실행되지 않습니다.
{{% /alert %}}

Shape 애니메이션이나 슬라이드 전환을 재생하지 않으려면 [AnimateShapes](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animateshapes/) 및 [AnimateTransitions](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animatetransitions/)을 [Html5Options](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/)에서 `false`로 설정합니다. 이러한 설정은 독립적이므로 하나만 활성화하고 다른 하나를 비활성화할 수 있습니다. 아래 예제는 생성된 페이지에서 두 종류의 애니메이션이 모두 비활성화된 상태로 프레젠테이션을 내보냅니다.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

var html5Options = new Html5Options
{
    AnimateShapes = false,
    AnimateTransitions = false
};

using var presentation = new Presentation("pres.pptx");
presentation.Save("pres5.html", SaveFormat.Html5, html5Options);
```

## **PowerPoint를 HTML로 내보내기**

표준 HTML 내보내기는 다른 렌더링 방식을 사용합니다: 슬라이드 내용이 HTML 페이지 내부의 SVG로 표시됩니다. 다음 예제는 이 렌더링 방식을 사용하여 프레젠테이션을 HTML 문서로 변환합니다.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("pres.pptx");
presentation.Save("pres.html", SaveFormat.Html);
```

아래 단순화된 마크업은 생성된 페이지의 구조를 보여줍니다. SVG 요소는 렌더링된 슬라이드 내용을 포함하며, 자리표시자 텍스트는 실제 출력이 아니라 예시를 위한 것입니다.

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
SVG 기반 내보내기는 PowerPoint 도형을 개별 HTML 요소로 노출하지 않습니다. 이 문서에서 설명하는 도형 애니메이션 및 슬라이드 전환 옵션이 필요하면 HTML5 내보내기를 사용하십시오.
{{% /alert %}}

## **PowerPoint를 HTML5 슬라이드 보기로 내보내기**

HTML5 내보내기는 브라우저에서 프레젠테이션 슬라이드를 보고 탐색할 수 있는 페이지를 생성합니다. 아래 예제는 [AnimateShapes](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animateshapes/)와 [AnimateTransitions](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animatetransitions/)를 모두 활성화하여 내보낸 슬라이드 보기가 원본 프레젠테이션의 효과를 재생하도록 합니다.

이미 도형 애니메이션 및 슬라이드 전환이 포함된 프레젠테이션을 사용하면 이러한 설정의 효과를 확인할 수 있습니다. 이 설정을 활성화해도 슬라이드에 해당 효과가 없으면 새로운 효과가 추가되지 않습니다. 내보낸 후 지원 파일이 함께 있는 브라우저에서 생성된 HTML5 문서를 엽니다.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

var html5Options = new Html5Options
{
    AnimateShapes = true,
    AnimateTransitions = true
};

using var presentation = new Presentation("pres.pptx");
presentation.Save("HTML5-slide-view.html", SaveFormat.Html5, html5Options);
```

## **프레젠테이션을 주석이 포함된 HTML5 문서로 변환하기**

기존 슬라이드 주석을 HTML5 출력에 포함시켜 독자가 슬라이드 내용과 함께 피드백을 볼 수 있습니다. 이 섹션의 예제는 아래와 같이 주석이 포함된 소스 프레젠테이션을 가정합니다. 주석을 내보내지만 새 주석은 생성하지 않습니다.

![프레젠테이션 슬라이드의 두 개 주석](two_comments_pptx.png)

[NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/notescommentslayoutingoptions/) 개체를 [Html5Options](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/)의 [SlidesLayoutOptions](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/slideslayoutoptions/) 속성에 할당합니다. [CommentsPosition](https://reference.aspose.com/slides/net/aspose.slides.export/notescommentslayoutingoptions/commentsposition/)을 [CommentsPositions](https://reference.aspose.com/slides/net/aspose.slides.export/commentspositions/) 열거형의 `Right`로 설정하면 각 슬라이드 오른쪽에 주석이 배치됩니다.

아래 예제는 이 주석 레이아웃을 적용하여 프레젠테이션을 HTML5로 내보냅니다. 주석이 없는 프레젠테이션은 표시할 주석 텍스트가 없습니다.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

var layoutOptions = new NotesCommentsLayoutingOptions
{
    CommentsPosition = CommentsPositions.Right
};

var html5Options = new Html5Options
{
    SlidesLayoutOptions = layoutOptions
};

using var presentation = new Presentation("sample.pptx");
presentation.Save("output.html", SaveFormat.Html5, html5Options);
```

![출력된 HTML5 문서에 있는 주석들](two_comments_html5.png)

## **내보내기 중 JavaScript 하이퍼링크 제외하기**

`hyperlinks.pptx`에 `javascript:alert('Hello')` 대상과 일반 `https://example.com/` 링크가 포함된 텍스트가 있다고 가정합니다. 내보내기 중 JavaScript 하이퍼링크를 제외하려면 [SaveOptions.SkipJavaScriptLinks](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/skipjavascriptlinks/)을 `true`로 설정합니다. 기본값은 `false`이며, 옵션을 활성화하지 않으면 이러한 링크가 필터링되지 않습니다.

다음 예제는 작업 디렉터리에서 프레젠테이션을 로드하고 [Html5Options](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/)을 사용하여 내보냅니다.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

var html5Options = new Html5Options { SkipJavaScriptLinks = true };

using var presentation = new Presentation("hyperlinks.pptx");
presentation.Save("filtered-html5.html", SaveFormat.Html5, html5Options);
```

내보낸 파일은 JavaScript 하이퍼링크를 제외하면서 텍스트와 일반 HTTPS 링크는 그대로 유지합니다. 원본 프레젠테이션은 변경되지 않습니다.

이 옵션은 JavaScript 하이퍼링크만 필터링하며, 모든 스크립트나 기타 활성 콘텐츠를 제거하지 않고 CSP 준수를 보장하지도 않습니다. 예를 들어 HTML5 출력에는 슬라이드 탐색 및 애니메이션을 위한 스크립트가 여전히 포함됩니다.

## **FAQ**

**HTML5에서 객체 애니메이션 및 슬라이드 전환이 재생되는지를 제어할 수 있나요?**

예, HTML5 내보내기는 [도형 애니메이션](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animateshapes/)과 [슬라이드 전환](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animatetransitions/)을 각각 활성화하거나 비활성화할 수 있는 별도 옵션을 제공합니다.

**주석이 지원되나요? 슬라이드와 상대적으로 어디에 배치할 수 있나요?**

예, 기존 주석을 HTML5 출력에 포함시킬 수 있으며, 예를 들어 슬라이드 오른쪽에 배치하는 등 [레이아웃 설정](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/slideslayoutoptions/)을 통해 위치를 지정할 수 있습니다.

**보안 또는 CSP 이유로 JavaScript를 호출하는 링크를 건너뛸 수 있나요?**

예, [SkipJavaScriptLinks](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/skipjavascriptlinks/) 설정을 사용하면 저장 시 JavaScript 호출이 포함된 하이퍼링크를 건너뛸 수 있습니다. 기본값은 `false`입니다. 간단한 HTML, HTML5 및 PDF 내보내기 예제와 필터 범위는 [내보내기 중 JavaScript 하이퍼링크 제외하기](/slides/ko/net/export-to-html5/#exclude-javascript-hyperlinks-during-export)를 참고하십시오. 이 설정은 HTML5 뷰어에서 네비게이션 및 애니메이션에 사용되는 JavaScript를 제거하지는 않습니다.
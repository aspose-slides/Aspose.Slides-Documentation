---
title: Java에서 프레젠테이션을 HTML5로 변환
linktitle: 프레젠테이션을 HTML5로
type: docs
weight: 40
url: /ko/java/export-to-html5/
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
- Java
- Aspose.Slides
description: "Aspose.Slides for Java를 사용하여 PowerPoint 및 OpenDocument 프레젠테이션을 반응형 HTML5로 내보냅니다. 서식, 애니메이션 및 인터랙티브 기능을 보존합니다."
---
## **개요**

이 문서는 Aspose.Slides for Java를 사용하여 PowerPoint 프레젠테이션을 HTML5로 변환하는 방법을 설명합니다. 기본 내보내기, 도형 애니메이션 및 슬라이드 전환 제어, 댓글 레이아웃을 다룹니다. 또한 표준 HTML 내보내기의 SVG 기반 출력과 HTML5 출력 을 비교합니다.

## **PowerPoint를 HTML5로 내보내기**

다음 예제는 작업 디렉터리에서 프레젠테이션을 로드하고 HTML5 형식으로 저장합니다. 기본 내보내기 설정을 사용합니다; 다음 예제는 애니메이션 재생을 명시적으로 제어하는 방법을 보여줍니다. 입력 경로를 프레젠테이션 경로로 교체하십시오.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.save("pres.html", SaveFormat.Html5);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
HTML 문서 외에도 내보내기는 슬라이드 스타일링, 애니메이션, 효과 및 탐색을 위한 지원 CSS 및 JavaScript 파일을 작성합니다. 출력물을 이동하거나 게시할 때 이러한 파일을 HTML 문서와 함께 보관하십시오. 생성된 페이지는 또한 공용 CDN에서 jQuery와 Anime.js를 로드합니다; 이들이 없으면 슬라이드 탐색 및 애니메이션이 작동하지 않습니다.
{{% /alert %}}

도형 애니메이션이나 슬라이드 전환을 재생하지 않고 내보내려면 [setAnimateShapes](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/#setAnimateShapes-boolean-) 및 [setAnimateTransitions](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/#setAnimateTransitions-boolean-) 에 `false` 값을 전달하고, 이를 [Html5Options](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/) 에 지정합니다. 이러한 설정은 독립적이므로 하나를 활성화하고 다른 하나를 비활성화할 수 있습니다. 예제에서는 생성된 페이지에서 두 종류의 애니메이션이 모두 비활성화된 상태로 프레젠테이션을 내보냅니다.

```java
import com.aspose.slides.*;

Html5Options html5Options = new Html5Options();
html5Options.setAnimateShapes(false);
html5Options.setAnimateTransitions(false);

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.save("pres5.html", SaveFormat.Html5, html5Options);
} finally {
    presentation.dispose();
}
```

## **PowerPoint를 HTML로 내보내기**

표준 HTML 내보내기는 다른 렌더링 방식을 사용합니다: 슬라이드 콘텐츠가 HTML 페이지 내부의 SVG로 표현됩니다. 다음 예제는 이 렌더링 방식을 사용하여 프레젠테이션을 HTML 문서로 변환합니다.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.save("pres.html", SaveFormat.Html);
} finally {
    presentation.dispose();
}
```

아래의 간략화된 마크업은 생성된 페이지의 구조를 보여줍니다. SVG 요소는 렌더링된 슬라이드 콘텐츠를 포함하며, 자리표시자 텍스트는 해당 콘텐츠를 나타내는 것이며 실제 내보내기 출력은 아닙니다.

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
SVG 기반 내보내기는 PowerPoint 도형을 개별 HTML 요소로 노출하지 않습니다. 이 문서에서 시연된 도형 애니메이션 및 슬라이드 전환 옵션이 필요할 경우 HTML5 내보내기를 사용하십시오.
{{% /alert %}}

## **PowerPoint를 HTML5 슬라이드 보기로 내보내기**

HTML5 내보내기는 브라우저에서 프레젠테이션 슬라이드를 보고 탐색할 수 있는 페이지를 생성합니다. 이 예제는 [setAnimateShapes](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/#setAnimateShapes-boolean-) 및 [setAnimateTransitions](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/#setAnimateTransitions-boolean-) 를 모두 활성화하여, 내보낸 슬라이드 보기가 원본 프레젠테이션의 효과를 재생할 수 있게 합니다.

이미 도형 애니메이션과 슬라이드 전환이 포함된 프레젠테이션을 사용하여 이러한 설정의 효과를 확인하십시오. 이를 활성화해도 효과가 없는 슬라이드에 새로운 효과가 추가되지 않습니다. 내보낸 후, 지원 파일이 있는 상태에서 브라우저에서 생성된 HTML5 문서를 열어 보십시오.

```java
import com.aspose.slides.*;

Html5Options html5Options = new Html5Options();
html5Options.setAnimateShapes(true);
html5Options.setAnimateTransitions(true);

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.save("HTML5-slide-view.html", SaveFormat.Html5, html5Options);
} finally {
    presentation.dispose();
}
```

## **프레젠테이션을 댓글이 포함된 HTML5 문서로 변환**

기존 슬라이드 댓글을 HTML5 출력에 포함시켜 독자가 슬라이드 콘텐츠와 함께 피드백을 확인할 수 있습니다. 이 섹션의 예제는 아래와 같이 소스 프레젠테이션에 댓글이 포함되어 있기를 기대합니다. 댓글을 내보내며, 새로운 댓글을 생성하지는 않습니다.

![프레젠테이션 슬라이드의 두 개 댓글](two_comments_pptx.png)

[NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/java/com.aspose.slides/notescommentslayoutingoptions/) 객체를 [Html5Options](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/) 의 [setSlidesLayoutOptions](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) 메서드에 전달합니다. [CommentsPositions](https://reference.aspose.com/slides/java/com.aspose.slides/commentspositions/) 열거형에서 `Right` 를 선택하도록 [setCommentsPosition](https://reference.aspose.com/slides/java/com.aspose.slides/notescommentslayoutingoptions/#setCommentsPosition-int-) 을 사용하여 각 슬라이드 오른쪽에 댓글이 배치되도록 합니다.

```java
import com.aspose.slides.*;

NotesCommentsLayoutingOptions layoutOptions = new NotesCommentsLayoutingOptions();
layoutOptions.setCommentsPosition(CommentsPositions.Right);

Html5Options html5Options = new Html5Options();
html5Options.setSlidesLayoutOptions(layoutOptions);

Presentation presentation = new Presentation("sample.pptx");
try {
    presentation.save("output.html", SaveFormat.Html5, html5Options);
} finally {
    presentation.dispose();
}
```

다음 예제는 이 댓글 레이아웃을 적용하여 프레젠테이션을 HTML5로 내보냅니다. 댓글이 없는 프레젠테이션은 표시할 댓글 텍스트가 없습니다.

![출력 HTML5 문서의 댓글](two_comments_html5.png)

## **내보내기 중 JavaScript 하이퍼링크 제외**

`hyperlinks.pptx`에 `javascript:alert('Hello')` 대상과 일반 `https://example.com/` 링크가 포함된 텍스트가 있다고 가정합니다. 내보내기 중 JavaScript 하이퍼링크를 제외하려면 [SaveOptions.setSkipJavaScriptLinks](https://reference.aspose.com/slides/java/com.aspose.slides/saveoptions/#setSkipJavaScriptLinks-boolean-) 에 `true` 를 전달하십시오. 기본값은 `false` 이므로 옵션을 활성화하지 않으면 이러한 링크는 필터링되지 않습니다.

다음 예제는 작업 디렉터리에서 프레젠테이션을 로드하고 [Html5Options](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/) 을 사용하여 내보냅니다:

```java
import com.aspose.slides.*;

Html5Options html5Options = new Html5Options();
html5Options.setSkipJavaScriptLinks(true);

Presentation presentation = new Presentation("hyperlinks.pptx");
try {
    presentation.save("filtered-html5.html", SaveFormat.Html5, html5Options);
} finally {
    presentation.dispose();
}
```

내보낸 파일은 JavaScript 하이퍼링크를 제외하고 텍스트와 일반 HTTPS 링크는 유지합니다. 원본 프레젠테이션은 변경되지 않습니다.

이 옵션은 JavaScript 하이퍼링크만 필터링하며, 모든 스크립트나 기타 활성 콘텐츠를 제거하지 않으며, CSP 준수를 보장하지도 않습니다. 예를 들어, HTML5 출력에는 여전히 슬라이드 탐색 및 애니메이션을 위한 스크립트가 포함됩니다.

## **FAQ**

**HTML5에서 객체 애니메이션 및 슬라이드 전환이 재생될지를 제어할 수 있나요?**

예, HTML5 내보내기는 [shape animations](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/#setAnimateShapes-boolean-) 및 [slide transitions](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/#setAnimateTransitions-boolean-) 을 개별적으로 사용하거나 사용 중지할 수 있는 옵션을 제공합니다.

**댓글이 지원되며, 슬라이드에 대해 어디에 배치할 수 있나요?**

예, 기존 댓글을 HTML5 출력에 포함시킬 수 있으며, 메모와 댓글에 대한 [layout settings](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) 을 통해 (예: 슬라이드 오른쪽에) 위치시킬 수 있습니다.

**보안이나 CSP 이유로 JavaScript를 호출하는 링크를 건너뛸 수 있나요?**

예, [setSkipJavaScriptLinks](https://reference.aspose.com/slides/java/com.aspose.slides/saveoptions/#setSkipJavaScriptLinks-boolean-) 설정을 사용하면 저장 시 JavaScript 호출이 포함된 하이퍼링크를 건너뛸 수 있습니다. 기본값은 `false` 입니다. HTML5 내보내기 예제와 필터 범위는 [내보내기 중 JavaScript 하이퍼링크 제외](/slides/ko/java/export-to-html5/#exclude-javascript-hyperlinks-during-export) 를 참고하십시오. 이 설정은 HTML5 뷰어가 탐색 및 애니메이션에 사용하는 JavaScript를 제거하지 않습니다.
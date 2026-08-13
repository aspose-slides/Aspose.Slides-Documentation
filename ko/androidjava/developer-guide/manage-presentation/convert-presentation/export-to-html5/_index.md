---
title: Android에서 프레젠테이션을 HTML5로 변환
linktitle: 프레젠테이션을 HTML5로
type: docs
weight: 40
url: /ko/androidjava/export-to-html5/
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
- Android
- Java
- Aspose.Slides
description: "Java를 사용하여 Android용 Aspose.Slides로 PowerPoint 및 OpenDocument 프레젠테이션을 반응형 HTML5로 내보냅니다. 서식, 애니메이션 및 상호작용을 유지합니다."
---
## **Overview**

이 문서는 Aspose.Slides를 사용하여 PowerPoint 프레젠테이션을 HTML5로 변환하는 방법을 설명합니다. 웹 확장이나 추가 종속성이 없는 기본 HTML5 내보내기와 형태 애니메이션 및 슬라이드 전환을 제어하는 옵션을 다룹니다. 또한 표준 PowerPoint‑to‑HTML 내보내기 프로세스를 보여주고, 슬라이드 보기 모드에서 HTML5 출력을 생성하는 방법과 레이아웃을 구성하여 내보낸 문서에 주석을 포함하는 방법을 시연합니다.

## **Export PowerPoint to HTML5**

다음 Java 코드는 웹 확장 및 종속성이 없이 프레젠테이션을 HTML5로 내보내는 방법을 보여줍니다:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.html", SaveFormat.Html5);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="info" %}} 
이 경우 깨끗한 HTML을 얻을 수 있습니다. 
{{% /alert %}}

이러한 방식으로 형태 애니메이션 및 슬라이드 전환에 대한 설정을 지정할 수 있습니다:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    Html5Options html5Options = new Html5Options();
    html5Options.setAnimateShapes(false);
    html5Options.setAnimateTransitions(false);
    
    pres.save("pres5.html", SaveFormat.Html5, html5Options);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Export PowerPoint to HTML**

다음 Java 코드는 표준 PowerPoint를 HTML로 변환하는 과정을 보여줍니다:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.html", SaveFormat.Html);
} finally {
    if (pres != null) pres.dispose();
}
```

이 경우 프레젠테이션 내용이 SVG를 통해 다음과 같은 형태로 렌더링됩니다:

```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> THE SLIDE CONTENT GOES HERE </g>
     </svg>
</div>
</body>
```

{{% alert title="Note" color="warning" %}} 
이 방법으로 PowerPoint를 HTML로 내보내면 SVG 렌더링으로 인해 스타일을 적용하거나 특정 요소를 애니메이션화할 수 없습니다. 
{{% /alert %}}

## **Export PowerPoint to HTML5 Slide View**

**Aspose.Slides**를 사용하면 슬라이드가 슬라이드 보기 모드로 표시되는 HTML5 문서로 PowerPoint 프레젠테이션을 변환할 수 있습니다. 이렇게 변환된 HTML5 파일을 브라우저에서 열면 웹 페이지에서 슬라이드 보기 모드로 프레젠테이션을 확인할 수 있습니다.

다음 Java 코드는 PowerPoint를 HTML5 슬라이드 보기로 내보내는 과정을 시연합니다:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    Html5Options html5Options = new Html5Options();
    html5Options.setAnimateShapes(true);
    html5Options.setAnimateTransitions(true);

    pres.save("HTML5-slide-view.html", SaveFormat.Html5, html5Options);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Convert a Presentation to an HTML5 Document with Comments**

PowerPoint의 주석은 사용자가 프레젠테이션 슬라이드에 메모나 피드백을 남길 수 있는 도구입니다. 여러 사용자가 주요 내용을 변경하지 않고 특정 슬라이드 요소에 제안이나 의견을 추가할 수 있어 협업 프로젝트에 특히 유용합니다. 각 주석에는 작성자 이름이 표시되어 누가 의견을 남겼는지 쉽게 추적할 수 있습니다.

예를 들어, "sample.pptx" 파일에 저장된 다음 PowerPoint 프레젠테이션이 있다고 가정해 보겠습니다.

![두 개의 주석이 있는 프레젠테이션 슬라이드](two_comments_pptx.png)

PowerPoint 프레젠테이션을 HTML5 문서로 변환할 때, 출력 문서에 프레젠테이션의 주석을 포함할지 여부를 쉽게 지정할 수 있습니다. 이를 위해서는 [Html5Options](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/html5options/) 클래스의 `setSlidesLayoutOptions` 메서드에 주석 표시 매개변수를 전달해야 합니다.

다음 코드 예제는 슬라이드 오른쪽에 주석이 표시되는 HTML5 문서로 프레젠테이션을 변환합니다.
```java
import com.aspose.slides.*;

NotesCommentsLayoutingOptions layoutingOptions = new NotesCommentsLayoutingOptions();
layoutingOptions.setCommentsPosition(CommentsPositions.Right);

Html5Options html5Options = new Html5Options();
html5Options.setSlidesLayoutOptions(layoutingOptions);

Presentation presentation = new Presentation("sample.pptx");
presentation.save("output.html", SaveFormat.Html5, html5Options);
presentation.dispose();
```

아래 이미지에 출력된 HTML5 문서의 주석이 표시됩니다.

![출력 HTML5 문서의 주석](two_comments_html5.png)

## **FAQ**

### Can I control whether object animations and slide transitions will play in HTML5?

예, HTML5에서는 [shape animations](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/html5options/#setAnimateShapes-boolean-) 및 [slide transitions](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/html5options/#setAnimateTransitions-boolean-)을 각각 활성화하거나 비활성화 할 수 있는 옵션을 제공합니다.

### Is the output of comments supported, and where can they be placed relative to the slide?

예, HTML5에서 주석을 추가할 수 있으며, 주석 및 노트를 위한 [layout settings](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/html5options/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-)를 통해 (예: 슬라이드 오른쪽) 위치를 지정할 수 있습니다.

### Can I skip links that invoke JavaScript for security or CSP reasons?

예, 저장 시 JavaScript 호출이 포함된 하이퍼링크를 건너뛸 수 있는 [setting](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/saveoptions/#setSkipJavaScriptLinks-boolean-)이 있습니다. 이는 엄격한 보안 정책을 준수하는 데 도움이 됩니다.
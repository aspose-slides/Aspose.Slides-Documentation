---
title: JavaScript를 사용하여 프레젠테이션을 HTML5로 변환
linktitle: 프레젠테이션을 HTML5로
type: docs
weight: 40
url: /ko/nodejs-java/export-to-html5/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js를 사용하여 PowerPoint 및 OpenDocument 프레젠테이션을 반응형 HTML5로 내보냅니다. 서식, 애니메이션 및 인터랙티브 요소를 보존합니다."
---
## **개요**

이 문서에서는 Aspose.Slides를 사용하여 PowerPoint 프레젠테이션을 HTML5로 변환하는 방법을 설명합니다. 웹 확장이나 추가 종속성이 없는 기본 HTML5 내보내기와 형태 애니메이션 및 슬라이드 전환을 제어하는 옵션을 다룹니다. 또한 표준 PowerPoint‑to‑HTML 내보내기 과정, 슬라이드 보기 모드에서 HTML5 출력을 생성하는 방법, 레이아웃을 구성하여 내보낸 문서에 주석을 포함시키는 방법을 보여줍니다.

## **PowerPoint를 HTML5로 내보내기**

다음 JavaScript 코드는 웹 확장 및 종속성이 없는 상태에서 프레젠테이션을 HTML5로 내보내는 방법을 보여줍니다:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    pres.save("pres.html", aspose.slides.SaveFormat.Html5);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert color="primary" %}} 
이 경우 깔끔한 HTML을 얻을 수 있습니다. 
{{% /alert %}}

다음과 같이 형태 애니메이션 및 슬라이드 전환에 대한 설정을 지정할 수 있습니다:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var html5Options = new aspose.slides.Html5Options();
    html5Options.setAnimateShapes(false);
    html5Options.setAnimateTransitions(false);
    pres.save("pres5.html", aspose.slides.SaveFormat.Html5, html5Options);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **PowerPoint를 HTML로 내보내기**

다음 JavaScript는 표준 PowerPoint‑to‑HTML 프로세스를 보여줍니다:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    pres.save("pres.html", aspose.slides.SaveFormat.Html);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

이 경우 프레젠테이션 내용이 다음과 같은 형태로 SVG를 통해 렌더링됩니다:

```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> THE SLIDE CONTENT GOES HERE </g>
     </svg>
</div>
</body>
```

{{% alert title="참고" color="warning" %}} 
이 방법으로 PowerPoint를 HTML로 내보내면 SVG 렌더링 때문에 스타일을 적용하거나 특정 요소를 애니메이션화할 수 없습니다. 
{{% /alert %}}

## **PowerPoint를 HTML5 슬라이드 보기로 내보내기**

**Aspose.Slides**를 사용하면 슬라이드가 슬라이드 보기 모드로 표시되는 HTML5 문서로 PowerPoint 프레젠테이션을 변환할 수 있습니다. 이렇게 하면 브라우저에서 결과 HTML5 파일을 열었을 때 웹 페이지에서 슬라이드 보기 모드로 프레젠테이션을 볼 수 있습니다.

다음 JavaScript 코드는 PowerPoint를 HTML5 슬라이드 보기로 내보내는 과정을 보여줍니다:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var html5Options = new aspose.slides.Html5Options();
    html5Options.setAnimateShapes(true);
    html5Options.setAnimateTransitions(true);
    pres.save("HTML5-slide-view.html", aspose.slides.SaveFormat.Html5, html5Options);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **주석이 포함된 HTML5 문서로 프레젠테이션 변환**

PowerPoint의 주석은 사용자가 슬라이드에 메모나 피드백을 남길 수 있는 도구입니다. 특히 여러 사람이 특정 슬라이드 요소에 대한 제안이나 의견을 추가할 수 있는 협업 프로젝트에서 유용합니다. 각 주석에는 작성자 이름이 표시되어 누가 남겼는지 쉽게 확인할 수 있습니다.

예를 들어 "sample.pptx" 파일에 저장된 PowerPoint 프레젠테이션이 있다고 가정해 보겠습니다.

![프레젠테이션 슬라이드에 있는 두 개의 주석](two_comments_pptx.png)

PowerPoint 프레젠테이션을 HTML5 문서로 변환할 때, 출력 문서에 프레젠테이션의 주석을 포함할지 여부를 쉽게 지정할 수 있습니다. 이를 위해서는 [Html5Options](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/html5options/) 클래스의 `notes_comments_layouting` 속성에 주석 표시 매개변수를 지정하면 됩니다.

다음 코드 예제는 주석이 슬라이드 오른쪽에 표시되는 형태로 프레젠테이션을 HTML5 문서로 변환합니다.
```javascript
let html5Options = new aspose.slides.Html5Options();
html5Options.getNotesCommentsLayouting().setCommentsPosition(aspose.slides.CommentsPositions.Right);

let presentation = new aspose.slides.Presentation("sample.pptx");
presentation.save("output.html", aspose.slides.SaveFormat.Html5, html5Options);
presentation.dispose();
```

아래 이미지에 "output.html" 문서가 표시됩니다.

![출력 HTML5 문서에 표시된 주석](two_comments_html5.png)

## **FAQ**

**HTML5에서 객체 애니메이션 및 슬라이드 전환을 재생할지 여부를 제어할 수 있나요?**

네, HTML5에서는 [shape animations](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/html5options/setanimateshapes/)과 [slide transitions](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/html5options/setanimatetransitions/)을 개별적으로 활성화하거나 비활성화할 수 있는 옵션을 제공합니다.

**주석 출력이 지원되며, 슬라이드와 상대적인 위치를 어디에 지정할 수 있나요?**

네, HTML5에서 주석을 추가할 수 있으며, 메모와 주석에 대한 [layout settings](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/html5options/#setNotesCommentsLayouting)으로 슬라이드 오른쪽 등 원하는 위치에 배치할 수 있습니다.

**보안 또는 CSP 이유로 JavaScript를 호출하는 링크를 건너뛸 수 있나요?**

네, 저장 시 JavaScript 호출이 포함된 하이퍼링크를 건너뛰게 하는 [setting](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks)이 있습니다. 이를 통해 엄격한 보안 정책을 준수할 수 있습니다.
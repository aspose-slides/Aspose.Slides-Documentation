---
title: Node.js에서 PowerPoint 프레젠테이션을 HTML로 변환
linktitle: PowerPoint를 HTML로
type: docs
weight: 30
url: /ko/nodejs-java/convert-powerpoint-to-html/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Node.js에서 PowerPoint 프레젠테이션을 HTML로 변환합니다. Aspose.Slides for Node.js via Java를 사용하여 PPT 및 PPTX 파일, 선택된 슬라이드, 노트, 폰트, 이미지, SVG 및 미디어를 내보낼 수 있습니다."
---
## **개요**

Aspose.Slides for Node.js via Java는 Microsoft PowerPoint 없이 PowerPoint 프레젠테이션을 HTML로 저장할 수 있습니다. 기본 변환은 단일[Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation/) 로드와 [SaveFormat](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/saveformat/) 의 `save` 호출로 이루어집니다. 내보낸 레이아웃, 폰트, 이미지, 노트, 댓글, SVG 출력 또는 연결된 리소스를 제어해야 할 경우[HtmlOptions](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/htmloptions/)를 사용합니다.

이 가이드는 실용적인 HTML 내보내기 시나리오에 중점을 둡니다:

- 전체 프레젠테이션 또는 선택한 슬라이드를 내보냅니다.
- 고정 레이아웃, 반응형 또는 SVG 기반 HTML을 생성합니다.
- 발표자 노트와 댓글을 포함합니다.
- 이미지 품질 및 잘린 이미지 데이터를 제어합니다.
- 폰트를 임베드하거나 폰트 파일을 별도로 저장합니다.
- 외부 리소스와 미디어 파일이 작성되고 참조되는 방식을 선택합니다.

기본적으로 HTML 내보내기는 대부분의 리소스가 포함된 단일 HTML 문서를 생성합니다. 이는 하나의 파일을 공유하기에 편리하지만 출력 크기가 증가할 수 있습니다. 웹 게시용으로는 외부 리소스를 사용하고 이미지 DPI를 낮추며 대상 환경에 신뢰할 수 있게 제공되지 않는 폰트만 임베드하는 것을 고려하십시오.

## **프레젠테이션을 HTML로 변환**

프레젠테이션을 HTML로 내보내려면[Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation/)으로 로드하고[SaveFormat.Html](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/saveformat/)으로 저장합니다.

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    presentation.save("presentation.html", aspose.slides.SaveFormat.Html);
} finally {
    presentation.dispose();
}
```

이 예제는 하나의 HTML 파일을 작성합니다. 프레젠테이션 객체는 `finally` 블록에서 해제되어 내보낸 후 파일 핸들과 렌더링 리소스를 해제합니다.

## **HtmlOptions 사용**

[HtmlOptions](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/htmloptions/)은 HTML 내보내기의 주요 구성 클래스입니다. 일반 설정은 다음과 같습니다:

- `SlidesLayoutOptions`: 노트, 댓글, 유인물 또는 기타 레이아웃 정보를 추가합니다.
- `HtmlFormatter`: HTML 문서 구조를 변경하거나 포맷팅을 컨트롤러에 위임합니다.
- `SlideImageFormat`: 슬라이드가 표현되는 방식을 변경합니다(예: SVG).
- `PicturesCompression`: 이미지 DPI와 출력 크기를 제어합니다.
- `DeletePicturesCroppedAreas`: 잘린 이미지 데이터를 유지하거나 제거합니다.
- `SvgResponsiveLayout`: 내보낸 SVG 콘텐츠가 컨테이너에 맞게 조정되도록 합니다.
- `ShowHiddenSlides`: 필요 시 숨겨진 슬라이드를 포함합니다.

다음 섹션에서는 가장 일반적인 옵션을 별도로 보여 주어 워크플로에 필요한 옵션만 결합할 수 있도록 합니다.

## **선택된 슬라이드를 HTML로 변환**

슬라이드 번호를 받는 `Presentation.save` 오버로드는 1부터 시작하는 슬라이드 위치를 사용합니다. 아래 루프는 각 슬라이드를 별도의 HTML 파일로 저장합니다.

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let slideCount = presentation.getSlides().size();

    for (let slideIndex = 0; slideIndex < slideCount; slideIndex++) {
        let slideNumber = slideIndex + 1;
        let slideNumbers = java.newArray("int", [slideNumber]);
        let htmlFileName = "slide-" + slideNumber + ".html";

        presentation.save(htmlFileName, slideNumbers, aspose.slides.SaveFormat.Html);
    }
} finally {
    presentation.dispose();
}
```

웹 사이트나 애플리케이션에서 슬라이드당 하나의 HTML 페이지가 필요할 때 이 패턴을 사용하십시오. 각 슬라이드가 동일한 레이아웃이어야 하면 하나의[HtmlOptions](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/htmloptions/) 인스턴스를 생성하고 각 `save` 호출에 전달합니다.

## **반응형 HTML 만들기**

[ResponsiveHtmlController](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/responsivehtmlcontroller/)은[HtmlFormatter](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/htmlformatter/)를 통해 반응형 HTML 출력을 제공합니다. 내보낸 페이지가 브라우저 너비에 더 잘 맞도록 조정해야 할 때 사용하십시오.

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let controller = new aspose.slides.ResponsiveHtmlController();
    let formatter = aspose.slides.HtmlFormatter.createCustomFormatter(controller);

    let htmlOptions = new aspose.slides.HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    presentation.save("presentation-responsive.html", aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

SVG 기반 반응형 레이아웃의 경우[HtmlOptions](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/htmloptions/)에 `SvgResponsiveLayout`을 설정합니다. 슬라이드 내용이 확장 가능한 SVG 마크업으로 내보내질 때 유용합니다.

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let htmlOptions = new aspose.slides.HtmlOptions();
    htmlOptions.setSvgResponsiveLayout(true);

    presentation.save("presentation-svg-responsive.html", aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

## **발표자 노트와 댓글 포함**

`HtmlOptions.setSlidesLayoutOptions`를 통해[NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/notescommentslayoutingoptions/)를 사용하여 발표자 노트나 댓글을 포함합니다. 노트와 댓글은 기본적으로 숨겨져 있으며 위치를 지정해야 표시됩니다.

소스 프레젠테이션에 발표자 노트가 포함되어 있다고 가정합니다:

![PowerPoint에서 발표자 노트가 있는 슬라이드](slide_with_notes.png)

다음 코드는 슬라이드 아래에 발표자 노트를 추가하여 슬라이드 내용을 내보냅니다.

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let layoutOptions = new aspose.slides.NotesCommentsLayoutingOptions();
    layoutOptions.setNotesPosition(aspose.slides.NotesPositions.BottomFull);

    let htmlOptions = new aspose.slides.HtmlOptions();
    htmlOptions.setSlidesLayoutOptions(layoutOptions);

    presentation.save("presentation-with-notes.html", aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

내보낸 HTML에 노트 영역이 포함됩니다:

![슬라이드와 발표자 노트가 포함된 HTML 출력](HTML_with_notes.png)

댓글을 내보내려면 `CommentsPosition`을 설정합니다(예: `CommentsPositions.Right` 또는 `CommentsPositions.Bottom`). 댓글만 필요하면 `NotesPosition`을 생략합니다. 노트와 댓글을 모두 필요하면 두 속성을 모두 설정합니다.

## **이미지 품질 및 잘린 영역 제어**

HTML 내보내기는 슬라이드 이미지를 압축하여 출력 크기를 줄일 수 있습니다. 높은 이미지 품질이 필요할 때는[PicturesCompression](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/picturescompression/) 값으로 `PicturesCompression`을 설정하십시오.

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let htmlOptions = new aspose.slides.HtmlOptions();
    htmlOptions.setPicturesCompression(aspose.slides.PicturesCompression.Dpi150);

    presentation.save("presentation-dpi-150.html", aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

기본적으로 이미지의 잘린 영역은 내보낸 출력에서 제거될 수 있습니다. 사용자가 숨겨진 이미지 부분을 복구하거나 검사해야 할 경우에만 잘린 데이터를 유지하십시오. 유지하면 HTML 크기가 증가할 수 있습니다.

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let htmlOptions = new aspose.slides.HtmlOptions();
    htmlOptions.setDeletePicturesCroppedAreas(false);

    presentation.save("presentation-with-cropped-areas.html", aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

## **CSS 추가**

간단한 스타일링을 위해 CSS 문자열을 `HtmlFormatter.createDocumentFormatter`에 전달합니다. 이렇게 하면 Aspose.Slides가 슬라이드 콘텐츠를 계속 렌더링하는 동안 주변 HTML 문서를 변경할 수 있습니다.

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let cssRules = "body { margin: 0; background: #f7f7f7; } .slide { margin: 24px auto; }";
    let formatter = aspose.slides.HtmlFormatter.createDocumentFormatter(cssRules, true);

    let htmlOptions = new aspose.slides.HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    presentation.save("presentation-styled.html", aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

사용자 지정 문서 헤더, 연결된 CSS 파일 또는 슬라이드와 도형 주변에 사용자 지정 마크업이 필요하면 포맷팅 컨트롤러와 함께 [HtmlFormatter](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/htmlformatter/)를 사용합니다.

## **폰트 임베드**

대상 환경에 프레젠테이션 폰트가 설치되지 않을 수 있는 경우[EmbedAllFontsHtmlController](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/embedallfontshtmlcontroller/)를 사용해 HTML에 폰트를 임베드합니다. 임베드는 시각적 일관성을 높이지만 출력 크기가 증가합니다.

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let fontNamesToExclude = java.newArray("java.lang.String", ["Arial"]);
    let fontController = new aspose.slides.EmbedAllFontsHtmlController(fontNamesToExclude);
    let formatter = aspose.slides.HtmlFormatter.createCustomFormatter(fontController);

    let htmlOptions = new aspose.slides.HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    presentation.save("presentation-embedded-fonts.html", aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

대상 브라우저나 시스템이 이미 폰트를 제공한다고 확신되는 경우에만 폰트를 제외하십시오. 브랜드 폰트 또는 덜 일반적인 폰트의 경우 임베드가 보통 더 안전합니다.

## **폰트 파일을 임베드 대신 링크하기**

HTML 파일 크기를 줄이려면 폰트 데이터를 별도의 WOFF 파일에 쓰고 HTML에 `@font-face` 규칙을 추가할 수 있습니다. Node.js via Java에서는 일반적으로 [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/embedallfontshtmlcontroller/)를 확장하는 작은 Java 헬퍼 클래스를 만들어 폰트 바이트를 출력 디렉터리에 쓰고 생성된 HTML에 `@font-face` 규칙을 삽입합니다. 해당 헬퍼를 컴파일하고 Node.js 모듈 클래스패스에 추가한 뒤 JavaScript에서 `java.newInstanceSync`로 인스턴스화합니다.

이러한 헬퍼를 만들 때는 두 경로를 명시적으로 선택해야 합니다:

- 파일 시스템 출력 경로: 생성된 폰트 파일이 기록되는 위치.
- URL 경로: 브라우저가 HTML 문서에서 해당 폰트 파일을 로드할 때 사용하는 경로.

## **리소스를 외부에 저장**

단일 HTML은 이동이 쉽지만 Base64로 임베드된 리소스는 파일을 크게 만들 수 있습니다. 애플리케이션에 외부 이미지, 폰트, 오디오 또는 비디오 파일이 필요하면 리소스를 선택한 디렉터리에 쓰고 브라우저에서 볼 수 있는 URL을 생성하는 내보내기 컨트롤러를 사용하십시오. 파일 시스템 경로와 URL 경로를 배포 레이아웃에 맞게 정렬해 두십시오.

## **미디어 파일 내보내기**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/videoplayerhtmlcontroller/)은 비디오와 오디오 파일을 내보내고 브라우저에서 재생할 수 있는 HTML을 작성합니다. 생성자는 다음을 받습니다:

- `path`: 생성된 미디어 파일이 기록될 디렉터리.
- `fileName`: 생성 중인 HTML 파일 이름.
- `baseUri`: HTML에서 미디어 파일에 대한 링크에 사용되는 절대 URI 접두사.

HTML 파일이 `html-output/presentation.html`이고 미디어 파일이 `html-output/media`에 저장되는 경우, `path`는 디스크상의 미디어 디렉터리를 가리키고, `baseUri`는 브라우저 관점에서 동일한 디렉터리를 가리켜야 합니다. 로컬 미리보기를 위해서는 미디어 디렉터리에서 `file:///` URI를 만들 수 있습니다. 배포된 애플리케이션에서는 게시된 미디어 디렉터리의 절대 URL을 사용하십시오.

```javascript
let fs = require("fs");
let path = require("path");

let outputDirectory = path.join(process.cwd(), "html-output");
let mediaDirectory = path.join(outputDirectory, "media");
fs.mkdirSync(mediaDirectory, { recursive: true });

let htmlFileName = "presentation.html";
let mediaBaseUri = "file:///" + mediaDirectory.replace(/\\/g, "/") + "/";

let presentation = new aspose.slides.Presentation();
try {
    let videoFilePath = path.join(process.cwd(), "intro.mp4");
    let videoBytes = Array.from(fs.readFileSync(videoFilePath));
    let videoData = java.newArray("byte", videoBytes);

    let video = presentation.getVideos().addVideo(videoData);
    let slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addVideoFrame(20, 20, 480, 270, video);

    let controller = new aspose.slides.VideoPlayerHtmlController(mediaDirectory, htmlFileName, mediaBaseUri);
    let formatter = aspose.slides.HtmlFormatter.createCustomFormatter(controller);
    let svgOptions = new aspose.slides.SVGOptions(controller);
    let slideImageFormat = aspose.slides.SlideImageFormat.svg(svgOptions);

    let htmlOptions = new aspose.slides.HtmlOptions(controller);
    htmlOptions.setHtmlFormatter(formatter);
    htmlOptions.setSlideImageFormat(slideImageFormat);

    let htmlFilePath = path.join(outputDirectory, htmlFileName);
    presentation.save(htmlFilePath, aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

특히 서버 애플리케이션에서는 작업당 고유한 출력 디렉터리를 사용하십시오. 공유 출력 경로는 서로 다른 변환의 파일이 덮어쓰여지는 원인이 될 수 있습니다.

## **성능 및 리소스 관리**

HTML 변환은 렌더링 작업이므로 처리 시간과 메모리 사용량은 슬라이드 수, 이미지 해상도, 폰트, 효과, 차트 및 임베드된 미디어에 따라 달라집니다. 높은 `PicturesCompression` DPI 값, 임베드된 폰트, SVG 출력 및 유지된 잘린 이미지 영역은 충실도를 높이지만 일반적으로 출력 크기를 증가시킵니다.

배치 변환을 위해:

- 모든 [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation/) 인스턴스를 즉시 해제하십시오.
- 작업별로 별도의 출력 디렉터리를 사용하십시오.
- 충실도가 필요하지 않은 경우 일반 폰트 임베드를 피하십시오.
- HTML이 미리보기 또는 썸네일용인 경우 이미지 DPI를 낮추십시오.
- 배포 경로가 최종 확정될 때까지 원본 프레젠테이션, 생성된 HTML 및 외부 리소스를 함께 보관하십시오.

## **FAQ**

**HTML 출력에서 하이퍼링크가 보존되나요?**

예. 프레젠테이션 하이퍼링크는 HTML로 내보내지며 대상 URL이 유효하면 클릭이 가능합니다.

**프레젠테이션을 HTML로 병렬 변환할 수 있나요?**

예, 하지만 하나의 [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation/) 인스턴스를 워커 간에 공유하지 마십시오. 다른 파일을 별개의 프레젠테이션 인스턴스, 별도 스트림 및 별도 출력 디렉터리로 처리하십시오. 자세한 내용은 [멀티스레딩 가이드](/slides/ko/nodejs-java/multithreading/)를 참조하십시오.

**Presentation 객체는 스레드 안전한가요?**

아니요. 단일 [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation/) 인스턴스는 하나의 워커에서 로드, 수정, 저장 및 해제되어야 합니다. 병렬 작업을 위해서는 워커당 독립적인 인스턴스를 생성하거나 프로세스를 분리하십시오.

**생성된 HTML 파일이 큰 이유는 무엇인가요?**

기본 내보내기는 리소스를 HTML에 직접 임베드합니다. 임베드된 폰트, 고 DPI 이미지, 미디어, SVG 콘텐츠 및 유지된 잘린 이미지 영역도 크기를 증가시킵니다. 외부 리소스를 사용하고, 일반 폰트를 임베드에서 제외하며, 작은 출력이 최대 충실도보다 중요할 경우 `PicturesCompression`을 낮추십시오.

**PowerPoint에서 24pt와 같은 글꼴 크기가 HTML에서는 17.999819pt로 표시되는 이유는 무엇인가요?**

PowerPoint와 HTML은 다른 DPI 모델을 사용하기 때문입니다. PowerPoint는 72 DPI 기반의 타이포그래픽 포인트로 텍스트 크기를 저장하고, HTML 레이아웃은 96 DPI 기반의 CSS 픽셀을 사용합니다. Aspose.Slides가 프레젠테이션을 HTML로 내보낼 때 글꼴 크기가 이러한 시스템 간에 변환되면서 작은 반올림 차이가 발생할 수 있습니다.

이 값은 실제 시각적 글꼴 크기 변화를 나타내는 것이 아니라 PowerPoint와 HTML 간 텍스트 메트릭을 변환하면서 발생하는 수학적 부수 효과에 불과합니다.

**미디어 내보내기에서 baseUri를 어떻게 선택해야 하나요?**

브라우저 관점에서의 경로를 `baseUri`로 선택하고 절대 URI로 전달하십시오. 로컬 미리보기를 위해서는 출력 디렉터리에서 `file:///` URI를 파생시킬 수 있습니다. 배포 시에는 게시된 미디어 디렉터리의 절대 URL을 사용하십시오. 파일 시스템 `path`와 브라우저 `baseUri`는 문자열이 동일할 필요는 없지만 동일한 리소스 위치를 가리켜야 합니다.

**숨겨진 슬라이드를 포함할 수 있나요?**

예. 숨겨진 슬라이드를 내보내야 할 경우 [HtmlOptions](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/htmloptions/)에서 `ShowHiddenSlides`를 `true`로 설정하십시오.
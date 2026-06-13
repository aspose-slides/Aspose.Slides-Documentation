---
title: Java에서 PowerPoint 프레젠테이션을 HTML로 변환
linktitle: PowerPoint를 HTML로
type: docs
weight: 30
url: /ko/java/convert-powerpoint-to-html/
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
  - Java
  - Aspose.Slides
description: "Java에서 PowerPoint 프레젠테이션을 HTML로 변환합니다. Aspose.Slides를 사용하여 PPT 및 PPTX 파일, 선택된 슬라이드, 노트, 글꼴, 이미지, SVG 및 미디어를 내보냅니다."
---
## **개요**

Aspose.Slides for Java는 Microsoft PowerPoint 없이 PowerPoint 프레젠테이션을 HTML로 저장할 수 있습니다. 기본 변환은 단일 [Presentation](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentation/) 로드와 [SaveFormat](https://reference.aspose.com/slides/ko/java/com.aspose.slides/saveformat/)과 함께 `save` 호출입니다. 내보낸 레이아웃, 글꼴, 이미지, 노트, 주석, SVG 출력 또는 연결된 리소스를 제어해야 할 때 [HtmlOptions](https://reference.aspose.com/slides/ko/java/com.aspose.slides/htmloptions/)를 사용합니다.

이 가이드는 실용적인 HTML 내보내기 시나리오에 중점을 둡니다:

- 전체 프레젠테이션 또는 선택된 슬라이드를 내보냅니다.
- 고정 레이아웃, 반응형 또는 SVG 기반 HTML을 생성합니다.
- 발표자 노트와 주석을 포함합니다.
- 이미지 품질 및 잘라낸 이미지 데이터를 제어합니다.
- 글꼴을 삽입하거나 글꼴 파일을 별도로 저장합니다.
- 외부 리소스와 미디어 파일이 작성되고 참조되는 방식을 선택합니다.

기본적으로 HTML 내보내기는 대부분의 리소스가 포함된 자체 포함 HTML 문서를 생성합니다. 하나의 파일을 공유하기에 편리하지만 출력 크기가 증가할 수 있습니다. 웹 게시의 경우 외부 리소스를 사용하고 이미지 DPI를 낮추며 대상 환경에서 신뢰할 수 없게 제공되는 글꼴만 삽입하는 것을 고려하십시오.

## **프레젠테이션을 HTML로 변환**

프레젠테이션을 HTML로 내보내려면 [Presentation](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentation/)으로 로드하고 [SaveFormat.Html](https://reference.aspose.com/slides/ko/java/com.aspose.slides/saveformat/)으로 저장합니다.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.save("presentation.html", SaveFormat.Html);
} finally {
    presentation.dispose();
}
```

이 예제는 하나의 HTML 파일을 작성합니다. 프레젠테이션 객체는 `finally` 블록에서 해제되어 내보낸 후 파일 핸들과 렌더링 리소스를 해제합니다.

## **HtmlOptions 사용**

[HtmlOptions](https://reference.aspose.com/slides/ko/java/com.aspose.slides/htmloptions/)은 HTML 내보내기의 주요 구성 클래스입니다. 일반 설정은 다음과 같습니다:

- `SlidesLayoutOptions`: 노트, 주석, 유인물 또는 기타 레이아웃 정보를 추가합니다.
- `HtmlFormatter`: HTML 문서 구조를 변경하거나 포맷팅을 컨트롤러에 위임합니다.
- `SlideImageFormat`: 슬라이드 표현 방식을 변경합니다(예: SVG).
- `PicturesCompression`: 이미지 DPI 및 출력 크기를 제어합니다.
- `DeletePicturesCroppedAreas`: 잘라낸 이미지 데이터를 유지하거나 제거합니다.
- `SvgResponsiveLayout`: 내보낸 SVG 콘텐츠가 컨테이너에 맞게 조정됩니다.
- `ShowHiddenSlides`: 필요할 경우 숨겨진 슬라이드를 포함합니다.

다음 섹션에서는 가장 일반적인 옵션을 별도로 보여주어 워크플로에 필요한 옵션만 결합할 수 있습니다.

## **선택된 슬라이드를 HTML로 변환**

`Presentation.save` 오버로드는 슬라이드 번호를 받아 1 기반 슬라이드 위치를 사용합니다. 아래 루프는 각 슬라이드를 별도의 HTML 파일로 저장합니다.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    int slideCount = presentation.getSlides().size();

    for (int slideIndex = 0; slideIndex < slideCount; slideIndex++) {
        int slideNumber = slideIndex + 1;
        int[] slideNumbers = { slideNumber };
        String htmlFileName = "slide-" + slideNumber + ".html";

        presentation.save(htmlFileName, slideNumbers, SaveFormat.Html);
    }
} finally {
    presentation.dispose();
}
```

웹사이트나 애플리케이션에서 슬라이드당 하나의 HTML 페이지가 필요할 때 이 패턴을 사용하십시오. 각 슬라이드가 동일한 레이아웃이어야 하면 하나의 [HtmlOptions](https://reference.aspose.com/slides/ko/java/com.aspose.slides/htmloptions/) 인스턴스를 생성하고 각 `save` 호출에 전달합니다.

## **반응형 HTML 만들기**

[ResponsiveHtmlController](https://reference.aspose.com/slides/ko/java/com.aspose.slides/responsivehtmlcontroller/)은 [HtmlFormatter](https://reference.aspose.com/slides/ko/java/com.aspose.slides/htmlformatter/)를 통해 반응형 HTML 출력을 제공합니다. 내보낸 페이지가 브라우저 너비에 더 잘 맞춰야 할 때 사용합니다.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    ResponsiveHtmlController controller = new ResponsiveHtmlController();
    HtmlFormatter formatter = HtmlFormatter.createCustomFormatter(controller);

    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    presentation.save("presentation-responsive.html", SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

SVG 기반 반응형 레이아웃의 경우 [HtmlOptions](https://reference.aspose.com/slides/ko/java/com.aspose.slides/htmloptions/)에 `SvgResponsiveLayout`을 설정합니다. 슬라이드 콘텐츠가 확장 가능한 SVG 마크업으로 내보내질 때 유용합니다.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setSvgResponsiveLayout(true);

    presentation.save("presentation-svg-responsive.html", SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

## **발표자 노트 및 주석 포함**

`HtmlOptions.setSlidesLayoutOptions`를 통해 [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ko/java/com.aspose.slides/notescommentslayoutingoptions/)를 사용하여 발표자 노트 또는 주석을 포함합니다. 노트와 주석은 기본적으로 숨겨져 있으며 위치를 지정하지 않으면 표시되지 않습니다.

소스 프레젠테이션에 발표자 노트가 포함되어 있다고 가정합니다:

![Slide with speaker notes in PowerPoint](slide_with_notes.png)

다음 코드는 슬라이드 콘텐츠를 슬라이드 아래에 발표자 노트와 함께 내보냅니다.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    NotesCommentsLayoutingOptions layoutOptions = new NotesCommentsLayoutingOptions();
    layoutOptions.setNotesPosition(NotesPositions.BottomFull);

    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setSlidesLayoutOptions(layoutOptions);

    presentation.save("presentation-with-notes.html", SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

![HTML output with the slide and speaker notes](HTML_with_notes.png)

주석을 내보내려면 `CommentsPosition`을 설정하고 예를 들어 `CommentsPositions.Right` 또는 `CommentsPositions.Bottom`을 사용합니다. 주석만 필요하면 `NotesPosition`을 생략하십시오. 노트와 주석을 모두 필요하면 두 속성을 모두 설정합니다.

## **이미지 품질 및 잘라낸 영역 제어**

HTML 내보내기는 슬라이드 이미지를 압축하여 출력 크기를 줄일 수 있습니다. 높은 이미지 품질이 필요할 때 [PicturesCompression](https://reference.aspose.com/slides/ko/java/com.aspose.slides/picturescompression/)에서 값을 선택하여 `PicturesCompression`을 설정합니다.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setPicturesCompression(PicturesCompression.Dpi150);

    presentation.save("presentation-dpi-150.html", SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

기본적으로 이미지의 잘라낸 영역은 내보낸 결과에서 제거될 수 있습니다. 사용자가 숨겨진 이미지 부분을 복구하거나 검사해야 할 경우에만 잘라낸 데이터를 유지하십시오. 유지하면 HTML 크기가 증가할 수 있습니다.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setDeletePicturesCroppedAreas(false);

    presentation.save("presentation-with-cropped-areas.html", SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

## **CSS 추가**

간단한 스타일링을 위해 CSS 문자열을 `HtmlFormatter.createDocumentFormatter`에 전달합니다. 이렇게 하면 Aspose.Slides가 슬라이드 콘텐츠를 렌더링하는 동안 주변 HTML 문서를 변경합니다.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    String cssRules = "body { margin: 0; background: #f7f7f7; } .slide { margin: 24px auto; }";
    HtmlFormatter formatter = HtmlFormatter.createDocumentFormatter(cssRules, true);

    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    presentation.save("presentation-styled.html", SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

맞춤 문서 헤더, 연결된 CSS 파일, 또는 슬라이드와 도형 주변의 맞춤 마크업이 필요하면 [IHtmlFormattingController](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ihtmlformattingcontroller/)를 구현하고 `createCustomFormatter`와 함께 [HtmlFormatter](https://reference.aspose.com/slides/ko/java/com.aspose.slides/htmlformatter/)에 전달합니다.

## **글꼴 삽입**

대상 환경에 프레젠테이션 글꼴이 설치되지 않을 수 있는 경우 [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/ko/java/com.aspose.slides/embedallfontshtmlcontroller/)를 사용하여 HTML에 글꼴을 삽입합니다. 삽입은 시각적 정확성을 향상시키지만 출력 크기를 증가시킵니다.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    String[] fontNamesToExclude = { "Arial" };
    EmbedAllFontsHtmlController fontController = new EmbedAllFontsHtmlController(fontNamesToExclude);
    HtmlFormatter formatter = HtmlFormatter.createCustomFormatter(fontController);

    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    presentation.save("presentation-embedded-fonts.html", SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

대상 브라우저나 시스템에 이미 글꼴이 제공된다고 확신할 때만 글꼴을 제외하십시오. 브랜드 글꼴이나 덜 일반적인 글꼴의 경우 삽입이 보통 더 안전합니다.

## **글꼴 파일을 삽입하는 대신 링크하기**

HTML 파일 크기를 줄이려면 글꼴 데이터를 별도의 WOFF 파일에 쓰고 HTML에 `@font-face` 규칙을 추가할 수 있습니다. 아래 도우미는 [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/ko/java/com.aspose.slides/embedallfontshtmlcontroller/)를 확장하고 `writeFont`를 오버라이드합니다.

```java
class LinkedFontsHtmlController extends EmbedAllFontsHtmlController {
    private final java.nio.file.Path fontOutputDirectory;
    private final String fontUrlPrefix;

    LinkedFontsHtmlController(
            java.nio.file.Path fontOutputDirectory,
            String fontUrlPrefix) throws java.io.IOException {
        super(new String[0]);
        this.fontOutputDirectory = fontOutputDirectory;
        this.fontUrlPrefix = fontUrlPrefix.endsWith("/") ? fontUrlPrefix : fontUrlPrefix + "/";

        java.nio.file.Files.createDirectories(fontOutputDirectory);
    }

    @Override
    public void writeFont(
            IHtmlGenerator generator,
            IFontData originalFont,
            IFontData substitutedFont,
            String fontStyle,
            String fontWeight,
            byte[] fontData) {
        try {
            IFontData font = substitutedFont == null ? originalFont : substitutedFont;
            String safeFontName = makeSafeFileName(font.getFontName());
            String safeFontStyle = fontStyle == null || fontStyle.trim().isEmpty() ? "normal" : fontStyle;
            String safeFontWeight = fontWeight == null || fontWeight.trim().isEmpty() ? "normal" : fontWeight;
            String fontFileName = safeFontName + "-" + safeFontStyle + "-" + safeFontWeight + ".woff";
            java.nio.file.Path fontFilePath = fontOutputDirectory.resolve(fontFileName);

            java.nio.file.Files.write(fontFilePath, fontData);

            String encodedFontFileName = java.net.URLEncoder.encode(fontFileName, "UTF-8");
            String fontUrl = fontUrlPrefix + encodedFontFileName.replace("+", "%20");
            String escapedBackslashes = font.getFontName().replace("\\", "\\\\");
            String fontFamily = escapedBackslashes.replace("'", "\\'");

            generator.addHtml("<style>");
            generator.addHtml("@font-face {");
            generator.addHtml("font-family: '" + fontFamily + "';");
            generator.addHtml("font-style: " + safeFontStyle + ";");
            generator.addHtml("font-weight: " + safeFontWeight + ";");
            generator.addHtml("src: url('" + fontUrl + "') format('woff');");
            generator.addHtml("}");
            generator.addHtml("</style>");
        } catch (java.io.IOException exception) {
            throw new RuntimeException("Unable to write an exported font.", exception);
        }
    }

    private String makeSafeFileName(String fileName) {
        String invalidCharacters = "\\/:*?\"<>|";
        char[] safeCharacters = fileName.toCharArray();

        for (int characterIndex = 0; characterIndex < safeCharacters.length; characterIndex++) {
            if (invalidCharacters.indexOf(safeCharacters[characterIndex]) >= 0) {
                safeCharacters[characterIndex] = '_';
            }
        }

        return new String(safeCharacters);
    }
}

java.nio.file.Path outputDirectory = java.nio.file.Paths.get(System.getProperty("user.dir"), "html-output");
java.nio.file.Path fontsDirectory = outputDirectory.resolve("fonts");
java.nio.file.Files.createDirectories(outputDirectory);

Presentation presentation = new Presentation("presentation.pptx");
try {
    LinkedFontsHtmlController fontController = new LinkedFontsHtmlController(fontsDirectory, "fonts");
    HtmlFormatter formatter = HtmlFormatter.createCustomFormatter(fontController);

    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    java.nio.file.Path htmlFilePath = outputDirectory.resolve("presentation.html");
    presentation.save(htmlFilePath.toString(), SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

이 예제에서는 글꼴 파일이 `html-output/fonts`에 저장되고 HTML은 `fonts/BrandFont-normal-400.woff`와 같은 URL로 참조합니다. HTML 파일과 글꼴이 다른 위치에 배포되는 경우 배포된 URL 경로와 일치하도록 `fontUrlPrefix`를 선택하십시오.

## **리소스를 외부에 저장**

자체 포함 HTML은 이동이 쉽지만, 삽입된 Base64 리소스로 파일이 커질 수 있습니다. 애플리케이션에서 외부 이미지 파일이 필요하면 [ILinkEmbedController](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ilinkembedcontroller/)를 구현하고 이를 [HtmlOptions](https://reference.aspose.com/slides/ko/java/com.aspose.slides/htmloptions/) 생성자에 전달합니다.

리소스를 외부화할 때는 두 경로를 신중히 선택하십시오:

- 파일 시스템 출력 경로로, 애플리케이션이 생성된 이미지, 글꼴, 오디오 또는 비디오를 기록합니다.
- URL 경로로, 브라우저가 HTML 문서에서 해당 파일을 로드할 때 사용하는 경로입니다.

## **미디어 파일 내보내기**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/ko/java/com.aspose.slides/videoplayerhtmlcontroller/)은 비디오 및 오디오 파일을 내보내고 브라우저에서 재생할 수 있는 HTML을 작성합니다. 생성자는 다음을 받습니다:

- `path`: 생성된 미디어 파일이 기록될 디렉터리.
- `fileName`: 생성 중인 HTML 파일 이름.
- `baseUri`: 미디어 파일에 대한 HTML 링크에 사용되는 절대 URI 접두사.

`html-output/presentation.html`이 HTML 파일이고 미디어 파일이 `html-output/media`에 저장되는 경우, `path`는 디스크상의 미디어 디렉터리를 가리키고 `baseUri`는 브라우저 관점에서 동일한 디렉터리를 가리켜야 합니다. 로컬 미리보기에서는 미디어 디렉터리에서 `file:///` URI를 만들 수 있습니다. 배포된 애플리케이션에서는 게시된 미디어 디렉터리의 절대 URL을 사용하십시오.

```java
java.nio.file.Path outputDirectory = java.nio.file.Paths.get(System.getProperty("user.dir"), "html-output");
java.nio.file.Path mediaDirectory = outputDirectory.resolve("media");
java.nio.file.Files.createDirectories(outputDirectory);
java.nio.file.Files.createDirectories(mediaDirectory);

String htmlFileName = "presentation.html";
String mediaBaseUri = mediaDirectory.toUri().toString();

Presentation presentation = new Presentation();
try {
    java.nio.file.Path videoFilePath = java.nio.file.Paths.get("intro.mp4");
    byte[] videoData = java.nio.file.Files.readAllBytes(videoFilePath);

    IVideo video = presentation.getVideos().addVideo(videoData);
    ISlide slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addVideoFrame(20, 20, 480, 270, video);

    String mediaDirectoryPath = mediaDirectory.toString();
    VideoPlayerHtmlController controller = new VideoPlayerHtmlController(mediaDirectoryPath, htmlFileName, mediaBaseUri);
    HtmlFormatter formatter = HtmlFormatter.createCustomFormatter(controller);
    SVGOptions svgOptions = new SVGOptions(controller);
    SlideImageFormat slideImageFormat = SlideImageFormat.svg(svgOptions);

    HtmlOptions htmlOptions = new HtmlOptions(controller);
    htmlOptions.setHtmlFormatter(formatter);
    htmlOptions.setSlideImageFormat(slideImageFormat);

    java.nio.file.Path htmlFilePath = outputDirectory.resolve(htmlFileName);
    presentation.save(htmlFilePath.toString(), SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

특히 서버 애플리케이션에서는 내보내기 작업당 고유한 출력 디렉터리를 사용하십시오. 공유 출력 경로는 서로 다른 변환의 파일이 겹쳐서 덮어쓰는 원인이 될 수 있습니다.

## **성능 및 리소스 관리**

HTML 변환은 렌더링 작업이므로 처리 시간과 메모리 사용량은 슬라이드 수, 이미지 해상도, 글꼴, 효과, 차트 및 삽입된 미디어에 따라 달라집니다. 높은 `PicturesCompression` DPI 값, 삽입된 글꼴, SVG 출력 및 유지된 잘라낸 이미지 영역은 정확성을 향상시키지만 일반적으로 출력 크기를 증가시킵니다.

배치 변환을 위해서는:

- 각 [Presentation](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentation/) 인스턴스를 즉시 해제합니다.
- 별도의 작업마다 별도의 출력 디렉터리를 사용합니다.
- 정확성이 필요하지 않은 한 일반 글꼴 삽입을 피합니다.
- HTML이 미리 보기 또는 썸네일용이면 이미지 DPI를 낮춥니다.
- 배포 경로가 최종 결정될 때까지 소스 프레젠테이션, 생성된 HTML 및 외부 리소스를 함께 보관합니다.

## **FAQ**

**HTML 출력에서 하이퍼링크가 유지됩니까?**

예. 프레젠테이션 하이퍼링크가 HTML로 내보내지며 대상 URL이 유효하면 클릭 가능하게 유지됩니다.

**프레젠테이션을 병렬로 HTML로 변환할 수 있나요?**

예, 하지만 하나의 [Presentation](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentation/) 인스턴스를 스레드 간에 공유하지 마세요. 별개의 프레젠테이션 인스턴스, 별개의 스트림 및 별개의 출력 디렉터리를 사용하여 서로 다른 파일을 처리합니다. 자세한 내용은 [multithreading guidance](/slides/ko/java/multithreading/)를 참조하십시오.

**Presentation 객체는 스레드 안전합니까?**

아니요. 단일 [Presentation](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentation/) 인스턴스는 하나의 스레드에서 로드, 수정, 저장 및 해제해야 합니다. 병렬 작업을 위해서는 스레드당 또는 프로세스당 독립 인스턴스를 생성하십시오.

**생성된 HTML 파일이 큰 이유는 무엇인가요?**

기본 내보내기는 리소스를 HTML에 직접 삽입할 수 있습니다. 삽입된 글꼴, 고 DPI 이미지, 미디어, SVG 콘텐츠 및 유지된 잘라낸 이미지 영역도 크기를 증가시킵니다. 출력 크기가 최대 정확성보다 중요하면 외부 리소스를 사용하고, 일반 글꼴 삽입을 제외하며, `PicturesCompression`을 낮추십시오.

**PowerPoint에서 24pt와 같은 글꼴 크기가 HTML에서는 17.999819pt로 표시되는 이유는 무엇인가요?**

이는 PowerPoint와 HTML이 서로 다른 DPI 모델을 사용하기 때문에 발생할 수 있습니다. PowerPoint는 72 DPI를 기준으로 타이포그래피 포인트로 텍스트 크기를 저장하고, HTML 레이아웃은 96 DPI 모델의 CSS 픽셀을 기반으로 합니다. Aspose.Slides가 프레젠테이션을 HTML로 내보낼 때 글꼴 크기가 시스템 간에 변환되며, 변환 과정에서 작은 반올림 차이가 발생할 수 있습니다.

이 값들은 실제 시각적 글꼴 크기의 변화를 나타내는 것이 아니라 PowerPoint와 HTML 간의 텍스트 메트릭 변환에 따른 수학적 부작용일 뿐입니다.

**미디어 내보내기에 baseUri를 어떻게 선택해야 하나요?**

`baseUri`는 브라우저 관점에서 선택하고 절대 URI로 전달하십시오. 로컬 미리보기의 경우 `mediaDirectory.toUri().toString()`을 사용해 출력 디렉터리에서 파생할 수 있습니다. 배포 시에는 게시된 미디어 디렉터리의 절대 URL을 사용하십시오. 파일 시스템 `path`와 브라우저 `baseUri`는 동일한 문자열일 필요는 없지만 동일한 리소스 위치를 가리켜야 합니다.

**숨겨진 슬라이드를 포함할 수 있나요?**

예. 숨겨진 슬라이드를 내보내야 할 경우 [HtmlOptions](https://reference.aspose.com/slides/ko/java/com.aspose.slides/htmloptions/)에서 `ShowHiddenSlides`를 `true`로 설정하십시오.
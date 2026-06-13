---
title: Android에서 PowerPoint 프레젠테이션을 HTML로 변환
linktitle: PowerPoint를 HTML로
type: docs
weight: 30
url: /ko/androidjava/convert-powerpoint-to-html/
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
- Android
- Java
- Aspose.Slides
description: "Android에서 PowerPoint 프레젠테이션을 HTML로 변환합니다. Aspose.Slides for Android via Java를 사용하여 PPT 및 PPTX 파일, 선택 슬라이드, 노트, 글꼴, 이미지, SVG 및 미디어를 내보냅니다."
---
## **개요**

Aspose.Slides for Android via Java는 Microsoft PowerPoint 없이도 PowerPoint 프레젠테이션을 HTML로 저장할 수 있습니다. 기본 변환은 단일 [Presentation](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/presentation/) 로드와 [SaveFormat](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/saveformat/) 을 사용한 `save` 호출로 이루어집니다. 내보낸 레이아웃, 글꼴, 이미지, 노트, 주석, SVG 출력 또는 연결된 리소스를 제어해야 할 경우 [HtmlOptions](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/htmloptions/) 를 사용하십시오.

이 가이드는 실용적인 HTML 내보내기 시나리오에 중점을 둡니다:

- 전체 프레젠테이션 또는 선택된 슬라이드 내보내기
- 고정 레이아웃, 반응형 또는 SVG 기반 HTML 생성
- 발표자 노트 및 주석 포함
- 이미지 품질 및 잘라낸 이미지 데이터 제어
- 글꼴을 임베드하거나 별도로 저장
- 외부 리소스 및 미디어 파일을 기록하고 참조하는 방법 선택

기본적으로 HTML 내보내기는 대부분의 리소스를 임베드한 독립형 HTML 문서를 생성합니다. 하나의 파일을 공유하기에 편리하지만 출력 크기가 커질 수 있습니다. 웹 게시의 경우 외부 리소스를 사용하고 이미지 DPI를 낮추며 대상 환경에 신뢰할 수 있게 제공되는 글꼴만 임베드하는 것을 고려하십시오.

## **프레젠테이션을 HTML로 변환**

프레젠테이션을 HTML로 내보내려면 [Presentation](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/presentation/) 로 로드하고 [SaveFormat.Html](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/saveformat/) 으로 저장하십시오.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.save("presentation.html", SaveFormat.Html);
} finally {
    presentation.dispose();
}
```

이 예제는 하나의 HTML 파일을 작성합니다. 프레젠테이션 객체는 `finally` 블록에서 해제되어 내보내기 후 파일 핸들과 렌더링 리소스를 해제합니다.

## **HtmlOptions 사용**

[HtmlOptions](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/htmloptions/) 은 HTML 내보내기의 주요 구성 클래스입니다. 일반 설정은 다음과 같습니다:

- `SlidesLayoutOptions`: 노트, 주석, 유인물 또는 기타 레이아웃 정보를 추가
- `HtmlFormatter`: HTML 문서 구조를 변경하거나 포맷팅을 컨트롤러에 위임
- `SlideImageFormat`: 슬라이드 표시 방식을 변경, 예를 들어 SVG
- `PicturesCompression`: 이미지 DPI 및 출력 크기 제어
- `DeletePicturesCroppedAreas`: 잘라낸 이미지 데이터를 유지하거나 제거
- `SvgResponsiveLayout`: 내보낸 SVG 콘텐츠가 컨테이너에 맞게 조정되도록 함
- `ShowHiddenSlides`: 필요 시 숨겨진 슬라이드 포함

아래 섹션에서는 가장 일반적인 옵션을 개별적으로 보여주므로 워크플로에 필요한 옵션만 조합하여 사용할 수 있습니다.

## **선택된 슬라이드를 HTML로 변환**

슬라이드 번호를 받는 `Presentation.save` 오버로드는 1 기반 슬라이드 위치를 사용합니다. 아래 루프는 각 슬라이드를 별도의 HTML 파일로 저장합니다.

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

웹 사이트나 애플리케이션에서 슬라이드당 하나의 HTML 페이지가 필요한 경우 이 패턴을 사용하십시오. 모든 슬라이드에 동일한 레이아웃을 적용하려면 하나의 [HtmlOptions](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/htmloptions/) 인스턴스를 생성하고 각 `save` 호출에 전달하십시오.

## **반응형 HTML 만들기**

[ResponsiveHtmlController](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/responsivehtmlcontroller/) 은 [HtmlFormatter](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/htmlformatter/) 를 통해 반응형 HTML 출력을 제공합니다. 내보낸 페이지가 브라우저 너비에 더 잘 적응해야 할 때 사용하십시오.

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

SVG 기반 반응형 레이아웃의 경우 [HtmlOptions](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/htmloptions/) 에 `SvgResponsiveLayout` 을 설정하십시오. 슬라이드 내용이 확장 가능한 SVG 마크업으로 내보내질 때 유용합니다.

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

`HtmlOptions.SlidesLayoutOptions` 를 통해 [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/notescommentslayoutingoptions/) 을 사용하여 발표자 노트나 주석을 포함할 수 있습니다. 노트와 주석은 기본적으로 숨겨져 있으며 위치를 선택해야 표시됩니다.

예를 들어 소스 프레젠테이션에 발표자 노트가 포함되어 있다고 가정합니다:

![PowerPoint에서 발표자 노트가 있는 슬라이드](slide_with_notes.png)

다음 코드는 슬라이드 아래에 발표자 노트를 포함하여 슬라이드 내용을 내보냅니다.

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

내보낸 HTML에는 노트 영역이 포함됩니다:

![슬라이드와 발표자 노트가 포함된 HTML 출력](HTML_with_notes.png)

주석을 내보내려면 `CommentsPosition` 을 설정하십시오. 예를 들어 `CommentsPositions.Right` 혹은 `CommentsPositions.Bottom` 로 지정합니다. 주석만 필요하면 `NotesPosition` 을 생략하고, 노트와 주석을 모두 필요로 하면 두 속성을 모두 설정하십시오.

## **이미지 품질 및 잘라낸 영역 제어**

HTML 내보내기는 슬라이드 이미지를 압축하여 출력 크기를 줄일 수 있습니다. 더 높은 이미지 품질이 필요하면 [PicturesCompression](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/picturescompression/) 중 하나의 값을 `PicturesCompression` 에 설정하십시오.

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

기본적으로 잘라낸 이미지 영역은 내보낸 출력에서 제거될 수 있습니다. 사용자가 숨겨진 이미지 부분을 복구하거나 검토해야 할 경우에만 잘라낸 데이터를 유지하십시오. 유지하면 HTML 크기가 증가할 수 있습니다.

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

간단한 스타일링을 위해 `HtmlFormatter.createDocumentFormatter` 에 CSS 문자열을 전달하십시오. 이렇게 하면 Aspose.Slides가 슬라이드 콘텐츠를 렌더링하는 동안 주변 HTML 문서를 변경할 수 있습니다.

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

맞춤형 문서 헤더, 연결된 CSS 파일, 또는 슬라이드와 도형 주변에 맞춤 마크업이 필요하면 [IHtmlFormattingController](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ihtmlformattingcontroller/) 를 구현하고 `createCustomFormatter` 로 [HtmlFormatter](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/htmlformatter/) 에 전달하십시오.

## **글꼴 임베드**

대상 환경에 프레젠테이션 글꼴이 설치되지 않을 수 있는 경우 [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/embedallfontshtmlcontroller/) 로 HTML에 글꼴을 임베드하십시오. 임베드는 시각적 충실도를 향상시키지만 출력 크기를 증가시킵니다.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    String[] fontNamesToExclude = { "Arial", "Calibri" };
    EmbedAllFontsHtmlController fontController = new EmbedAllFontsHtmlController(fontNamesToExclude);
    HtmlFormatter formatter = HtmlFormatter.createCustomFormatter(fontController);

    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    presentation.save("presentation-embedded-fonts.html", SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

대상 브라우저나 시스템에 이미 글꼴이 제공된다고 확신되는 경우에만 글꼴을 제외하십시오. 브랜드 글꼴이나 흔하지 않은 글꼴의 경우 임베드하는 것이 일반적으로 더 안전합니다.

## **글꼴 파일을 별도로 링크하기**

HTML 파일 크기를 줄이려면 글꼴 데이터를 별도의 WOFF 파일에 저장하고 HTML에 `@font-face` 규칙을 추가할 수 있습니다. 아래 도우미는 [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/embedallfontshtmlcontroller/) 를 확장하고 `writeFont` 를 재정의합니다.

```java
class LinkedFontsHtmlController extends EmbedAllFontsHtmlController {
    private final String fontOutputDirectory;
    private final String fontUrlPrefix;

    LinkedFontsHtmlController(
            String fontOutputDirectory,
            String fontUrlPrefix) throws java.io.IOException {
        super(new String[0]);
        this.fontOutputDirectory = fontOutputDirectory;
        this.fontUrlPrefix = fontUrlPrefix.endsWith("/") ? fontUrlPrefix : fontUrlPrefix + "/";
        
        File dirs = new File(fontOutputDirectory);
        dirs.mkdirs();
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
            String fontFilePath = fontOutputDirectory + "/" + fontFileName;

            FileOutputStream fos = new FileOutputStream(fontFilePath);
            fos.write(fontData);
            fos.close();

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

String outputDirectory = System.getProperty("user.dir") + "/html-output";
String fontsDirectory = outputDirectory + "/fonts";
File dir = new File("path/to/folder");
dir.mkdir();

Presentation presentation = new Presentation("presentation.pptx");
try {
    LinkedFontsHtmlController fontController = new LinkedFontsHtmlController(fontsDirectory, "fonts");
    HtmlFormatter formatter = HtmlFormatter.createCustomFormatter(fontController);

    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    String htmlFilePath = outputDirectory + "/presentation.html";
    presentation.save(htmlFilePath.toString(), SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

이 예제에서는 글꼴 파일이 `html-output/fonts` 에 저장되고 HTML은 `fonts/BrandFont-normal-400.woff` 와 같은 URL로 참조합니다. HTML 파일과 글꼴을 다른 위치에 배포할 경우 배포된 URL 경로와 일치하도록 `fontUrlPrefix` 를 선택하십시오.

## **리소스를 외부에 저장**

독립형 HTML은 이동이 쉽지만 임베드된 Base64 리소스로 파일이 커질 수 있습니다. 애플리케이션에서 외부 이미지 파일이 필요하다면 [ILinkEmbedController](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ilinkembedcontroller/) 를 구현하고 [HtmlOptions](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/htmloptions/) 생성자에 전달하십시오.

리소스를 외부화할 때는 두 경로를 신중하게 선택하십시오:

- 파일 시스템 출력 경로: 애플리케이션이 생성된 이미지, 글꼴, 오디오 또는 비디오를 기록하는 위치
- URL 경로: 브라우저가 HTML 문서에서 해당 파일을 로드할 때 사용하는 경로

## **미디어 파일 내보내기**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/videoplayerhtmlcontroller/) 는 비디오와 오디오 파일을 내보내고 브라우저에서 재생할 수 있는 HTML을 작성합니다. 생성자는 다음을 받습니다:

- `path`: 생성된 미디어 파일이 기록될 디렉터리
- `fileName`: 생성 중인 HTML 파일 이름
- `baseUri`: 미디어 파일에 대한 HTML 링크에 사용되는 절대 URI 접두사

HTML 파일이 `html-output/presentation.html` 이고 미디어 파일이 `html-output/media` 에 저장된 경우, `path` 는 디스크상의 미디어 디렉터리를 가리키고 `baseUri` 는 브라우저 관점에서 동일 디렉터리를 가리켜야 합니다. 로컬 미리보기에서는 미디어 디렉터리에서 `file:///` URI를 만들 수 있고, 배포된 애플리케이션에서는 공개된 미디어 디렉터리의 절대 URL을 사용하십시오.

```java
String outputDirectory = System.getProperty("user.dir") + "/html-output";
String mediaDirectory = outputDirectory + "/media";
File outDir = new File(outputDirectory);
outDir.mkdir();
File mediaDir = new File(mediaDirectory);
mediaDir.mkdir();

String htmlFileName = "presentation.html";
String mediaBaseUri = mediaDirectory;

Presentation presentation = new Presentation();
try {
    byte[] videoData = ...;// intro.mp4

    IVideo video = presentation.getVideos().addVideo(videoData);
    ISlide slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addVideoFrame(20, 20, 480, 270, video);

    String mediaDirectoryPath = mediaDirectory;
    VideoPlayerHtmlController controller = new VideoPlayerHtmlController(mediaDirectoryPath, htmlFileName, mediaBaseUri);
    HtmlFormatter formatter = HtmlFormatter.createCustomFormatter(controller);
    SVGOptions svgOptions = new SVGOptions(controller);
    SlideImageFormat slideImageFormat = SlideImageFormat.svg(svgOptions);

    HtmlOptions htmlOptions = new HtmlOptions(controller);
    htmlOptions.setHtmlFormatter(formatter);
    htmlOptions.setSlideImageFormat(slideImageFormat);

    String htmlFilePath = outputDirectory + "/" + htmlFileName;
    presentation.save(htmlFilePath.toString(), SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

특히 서버 애플리케이션에서는 작업당 고유한 출력 디렉터리를 사용하십시오. 공유 출력 경로를 사용하면 서로 다른 변환 작업의 파일이 덮어써질 수 있습니다.

## **성능 및 리소스 관리**

HTML 변환은 렌더링 작업이므로 처리 시간과 메모리 사용량은 슬라이드 수, 이미지 해상도, 글꼴, 효과, 차트, 임베드된 미디어 등에 따라 달라집니다. 높은 `PicturesCompression` DPI 값, 임베드된 글꼴, SVG 출력, 잘라낸 이미지 영역 보존은 충실도를 향상시키지만 일반적으로 출력 크기를 늘립니다.

배치 변환 시:

- 각 [Presentation](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/presentation/) 인스턴스를 즉시 해제
- 작업별 별도 출력 디렉터리 사용
- 충실도가 필요하지 않은 경우 일반 글꼴 임베드 방지
- 프리뷰나 썸네일용 HTML인 경우 이미지 DPI 낮추기
- 배포 경로가 확정될 때까지 원본 프레젠테이션, 생성된 HTML 및 외부 리소스를 함께 보관

## **FAQ**

**HTML 출력에서 하이퍼링크가 유지되나요?**

예. 프레젠테이션 하이퍼링크는 HTML로 내보내지며 대상 URL이 유효하면 클릭할 수 있습니다.

**프레젠테이션을 병렬로 HTML로 변환할 수 있나요?**

예, 그러나 하나의 [Presentation](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/presentation/) 인스턴스를 여러 스레드에서 공유하지 마십시오. 파일마다 별도의 프레젠테이션 인스턴스, 별도 스트림, 별도 출력 디렉터리를 사용하십시오. 자세한 내용은 [multithreading guidance](/slides/ko/androidjava/multithreading/) 를 참고하십시오.

**Presentation 객체는 스레드 안전한가요?**

아니오. 단일 [Presentation](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/presentation/) 인스턴스는 하나의 스레드에서 로드, 수정, 저장 및 해제되어야 합니다. 병렬 작업이 필요하면 스레드당 독립 인스턴스를 생성하십시오.

**생성된 HTML 파일이 왜 큰가요?**

기본 내보내기는 리소스를 HTML에 직접 임베드합니다. 임베드된 글꼴, 고 DPI 이미지, 미디어, SVG 콘텐츠 및 잘라낸 이미지 영역 보존은 파일 크기를 증가시킵니다. 외부 리소스를 사용하고, 일반 글꼴은 임베드하지 않으며, `PicturesCompression` 을 낮추어 크기를 줄이십시오.

**PowerPoint에서 24 pt 글꼴 크기가 HTML에서는 17.999819 pt로 표시되는 이유는?**

PowerPoint와 HTML은 서로 다른 DPI 모델을 사용하기 때문입니다. PowerPoint는 72 DPI 기반의 전통적인 포인트를 사용하고, HTML 레이아웃은 96 DPI 기반의 CSS 픽셀을 사용합니다. Aspose.Slides가 프레젠테이션을 HTML로 내보낼 때 폰트 크기가 두 시스템 간에 변환되며, 이 과정에서 작은 반올림 차이가 발생할 수 있습니다.

이 값은 실제 시각적 폰트 크기 변화가 아니라 PowerPoint와 HTML 간 텍스트 메트릭 변환 시 발생하는 수학적 부작용에 불과합니다.

**미디어 내보내기용 baseUri는 어떻게 선택해야 하나요?**

브라우저 관점에서의 경로를 `baseUri` 로 선택하고 절대 URI 형태로 전달하십시오. 로컬 미리보기에서는 출력 디렉터리에서 `mediaDirectory.toUri().toString()` 로 만들 수 있습니다. 배포 시에는 공개된 미디어 디렉터리의 절대 URL을 사용하십시오. 파일 시스템 `path` 와 브라우저 `baseUri` 가 동일한 문자열일 필요는 없지만 동일한 리소스 위치를 가리켜야 합니다.

**숨겨진 슬라이드를 포함할 수 있나요?**

예. 숨겨진 슬라이드를 내보내야 할 경우 [HtmlOptions](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/htmloptions/) 에 `ShowHiddenSlides` 를 `true` 로 설정하십시오.
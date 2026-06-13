---
title: .NET에서 PowerPoint 프레젠테이션을 HTML로 변환
linktitle: PowerPoint를 HTML로
type: docs
weight: 30
url: /ko/net/convert-powerpoint-to-html/
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
- .NET
- C#
- Aspose.Slides
description: ".NET에서 PowerPoint 프레젠테이션을 HTML로 변환합니다. Aspose.Slides를 사용하여 PPT 및 PPTX 파일, 선택한 슬라이드, 노트, 글꼴, 이미지, SVG 및 미디어를 내보낼 수 있습니다."
---
## **개요**

Aspose.Slides for .NET은 Microsoft PowerPoint 없이 PowerPoint 프레젠테이션을 HTML로 저장할 수 있습니다. 기본 변환은 단일 [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/) 로드와 [Save](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/save/) 호출에 [SaveFormat](https://reference.aspose.com/slides/ko/net/aspose.slides.export/saveformat/)을 사용하는 것입니다. 내보낸 레이아웃, 글꼴, 이미지, 노트, 댓글, SVG 출력 또는 연결된 리소스를 제어해야 할 경우 [HtmlOptions](https://reference.aspose.com/slides/ko/net/aspose.slides.export/htmloptions/)를 사용하십시오.

이 가이드는 실용적인 HTML 내보내기 시나리오에 중점을 둡니다:

- 전체 프레젠테이션 또는 선택한 슬라이드를 내보냅니다.
- 고정 레이아웃, 반응형 또는 SVG 기반 HTML을 생성합니다.
- 발표자 노트와 댓글을 포함합니다.
- 이미지 품질 및 잘린 이미지 데이터를 제어합니다.
- 글꼴을 포함하거나 글꼴 파일을 별도로 저장합니다.
- 외부 리소스 및 미디어 파일이 작성되고 참조되는 방식을 선택합니다.

기본적으로 HTML 내보내기는 대부분의 리소스가 포함된 자체 포함 HTML 문서를 생성합니다. 이는 하나의 파일을 공유하기에 편리하지만 출력 크기가 증가할 수 있습니다. 웹 게시의 경우 외부 리소스 사용, 이미지 DPI 낮추기, 대상 환경에 신뢰할 수 있게 제공되지 않는 글꼴만 포함하는 것을 고려하십시오.

## **프레젠테이션을 HTML로 변환**

프레젠테이션을 HTML로 내보내려면 [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/)으로 로드하고 [SaveFormat.Html](https://reference.aspose.com/slides/ko/net/aspose.slides.export/saveformat/)으로 저장합니다.

```csharp
using var presentation = new Presentation("presentation.pptx");

presentation.Save("presentation.html", SaveFormat.Html);
```

이 예제는 하나의 HTML 파일을 작성합니다. `using` 선언에 의해 프레젠테이션 객체가 해제되어 내보낸 뒤 파일 핸들 및 렌더링 리소스가 해제됩니다.

## **HtmlOptions 사용**

[HtmlOptions](https://reference.aspose.com/slides/ko/net/aspose.slides.export/htmloptions/)는 HTML 내보내기의 주요 구성 클래스입니다. 일반적인 설정은 다음과 같습니다:

- `SlidesLayoutOptions`: 슬라이드 노트, 댓글, 유인물 또는 기타 레이아웃 정보를 추가합니다.
- `HtmlFormatter`: HTML 문서 구조를 변경하거나 포맷팅을 컨트롤러에 위임합니다.
- `SlideImageFormat`: 슬라이드가 표현되는 방식을 변경합니다(예: SVG).
- `PicturesCompression`: 이미지 DPI와 출력 크기를 제어합니다.
- `DeletePicturesCroppedAreas`: 잘린 이미지 데이터를 유지하거나 제거합니다.
- `SvgResponsiveLayout`: 내보낸 SVG 내용이 컨테이너에 맞게 적응하도록 합니다.
- `ShowHiddenSlides`: 필요할 경우 숨겨진 슬라이드를 포함합니다.

다음 섹션에서는 가장 일반적인 옵션을 별도로 보여 주어 워크플로에 필요한 옵션만 결합할 수 있도록 합니다.

## **선택한 슬라이드를 HTML로 변환**

슬라이드 번호를 받는 [Presentation.Save](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/save/) 오버로드는 1 기반 슬라이드 위치를 사용합니다. 아래 루프는 각 슬라이드를 별도의 HTML 파일로 저장합니다.

```csharp
using var presentation = new Presentation("presentation.pptx");

var slideCount = presentation.Slides.Count;

for (var slideIndex = 0; slideIndex < slideCount; slideIndex++)
{
    var slideNumber = slideIndex + 1;
    var slideNumbers = new[] { slideNumber };
    var htmlFileName = $"slide-{slideNumber}.html";

    presentation.Save(htmlFileName, slideNumbers, SaveFormat.Html);
}
```

웹사이트나 애플리케이션에서 슬라이드당 하나의 HTML 페이지가 필요할 때 이 패턴을 사용하십시오. 각 슬라이드가 동일한 레이아웃이어야 하면 하나의 [HtmlOptions](https://reference.aspose.com/slides/ko/net/aspose.slides.export/htmloptions/) 인스턴스를 만들고 각 `Save` 호출에 전달하십시오.

## **반응형 HTML 만들기**

[ResponsiveHtmlController](https://reference.aspose.com/slides/ko/net/aspose.slides.export/responsivehtmlcontroller/)는 [HtmlFormatter](https://reference.aspose.com/slides/ko/net/aspose.slides.export/htmlformatter/)를 통해 반응형 HTML 출력을 제공합니다. 브라우저 너비에 더 잘 적응해야 하는 경우 이를 사용하십시오.

```csharp
using var presentation = new Presentation("presentation.pptx");

var controller = new ResponsiveHtmlController();
var formatter = HtmlFormatter.CreateCustomFormatter(controller);

var htmlOptions = new HtmlOptions
{
    HtmlFormatter = formatter
};

presentation.Save("presentation-responsive.html", SaveFormat.Html, htmlOptions);
```

SVG 기반 반응형 레이아웃을 위해서는 [HtmlOptions](https://reference.aspose.com/slides/ko/net/aspose.slides.export/htmloptions/)에 `SvgResponsiveLayout`을 설정하십시오. 슬라이드 내용이 확장 가능한 SVG 마크업으로 내보내질 때 유용합니다.

```csharp
using var presentation = new Presentation("presentation.pptx");

var htmlOptions = new HtmlOptions
{
    SvgResponsiveLayout = true
};

presentation.Save("presentation-svg-responsive.html", SaveFormat.Html, htmlOptions);
```

## **발표자 노트와 댓글 포함**

`HtmlOptions.SlidesLayoutOptions`를 통해 [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ko/net/aspose.slides.export/notescommentslayoutingoptions/)를 사용하여 발표자 노트 또는 댓글을 포함할 수 있습니다. 기본적으로 노트와 댓글은 숨겨져 있으며 위치를 선택해야 표시됩니다.

소스 프레젠테이션에 발표자 노트가 포함되어 있다고 가정합니다:

![Slide with speaker notes in PowerPoint](slide_with_notes.png)

다음 코드는 슬라이드 아래에 발표자 노트를 포함하여 슬라이드 내용을 내보냅니다.

```csharp
using var presentation = new Presentation("presentation.pptx");

var layoutOptions = new NotesCommentsLayoutingOptions
{
    NotesPosition = NotesPositions.BottomFull
};

var htmlOptions = new HtmlOptions
{
    SlidesLayoutOptions = layoutOptions
};

presentation.Save("presentation-with-notes.html", SaveFormat.Html, htmlOptions);
```

내보낸 HTML에는 노트 영역이 포함됩니다:

![HTML output with the slide and speaker notes](HTML_with_notes.png)

댓글을 내보내려면 `CommentsPosition`을 예를 들어 `CommentsPositions.Right` 또는 `CommentsPositions.Bottom`으로 설정하십시오. 댓글만 필요하면 `NotesPosition`을 생략합니다. 노트와 댓글을 모두 원하면 두 속성을 모두 설정합니다.

## **이미지 품질 및 잘린 영역 제어**

HTML 내보내기는 슬라이드 이미지를 압축하여 출력 크기를 줄일 수 있습니다. 높은 이미지 품질이 필요하면 [PicturesCompression](https://reference.aspose.com/slides/ko/net/aspose.slides.export/picturescompression/)에서 값을 선택하고 `PicturesCompression`을 설정하십시오.

```csharp
using var presentation = new Presentation("presentation.pptx");

var htmlOptions = new HtmlOptions
{
    PicturesCompression = PicturesCompression.Dpi150
};

presentation.Save("presentation-dpi-150.html", SaveFormat.Html, htmlOptions);
```

기본적으로 이미지의 잘린 영역은 내보낸 출력에서 제거될 수 있습니다. 사용자가 숨겨진 이미지 부분을 복구하거나 검사해야 할 경우에만 잘린 데이터를 유지하십시오. 유지하면 HTML 크기가 증가할 수 있습니다.

```csharp
using var presentation = new Presentation("presentation.pptx");

var htmlOptions = new HtmlOptions
{
    DeletePicturesCroppedAreas = false
};

presentation.Save("presentation-with-cropped-areas.html", SaveFormat.Html, htmlOptions);
```

## **CSS 추가**

간단한 스타일링을 위해 CSS 문자열을 [HtmlFormatter.CreateDocumentFormatter](https://reference.aspose.com/slides/ko/net/aspose.slides.export/htmlformatter/createdocumentformatter/)에 전달하십시오. 이는 Aspose.Slides가 슬라이드 내용을 계속 렌더링하는 동안 주변 HTML 문서를 변경합니다.

```csharp
using var presentation = new Presentation("presentation.pptx");

var cssRules = "body { margin: 0; background: #f7f7f7; } .slide { margin: 24px auto; }";
var formatter = HtmlFormatter.CreateDocumentFormatter(cssRules, true);

var htmlOptions = new HtmlOptions
{
    HtmlFormatter = formatter
};

presentation.Save("presentation-styled.html", SaveFormat.Html, htmlOptions);
```

맞춤 문서 헤더, 연결된 CSS 파일, 슬라이드와 도형 주위의 맞춤 마크업이 필요하면 [IHtmlFormattingController](https://reference.aspose.com/slides/ko/net/aspose.slides.export/ihtmlformattingcontroller/)를 구현하고 `CreateCustomFormatter`와 함께 [HtmlFormatter](https://reference.aspose.com/slides/ko/net/aspose.slides.export/htmlformatter/)에 전달하십시오.

## **글꼴 포함**

대상 환경에 프레젠테이션 글꼴이 설치되지 않을 수 있는 경우 [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/ko/net/aspose.slides.export/embedallfontshtmlcontroller/)를 사용하여 HTML에 글꼴을 포함하십시오. 포함은 시각적 충실도를 높이지만 출력 크기를 증가시킵니다.

```csharp
using var presentation = new Presentation("presentation.pptx");

string[] fontNamesToExclude = { "Arial", "Calibri" };
var fontController = new EmbedAllFontsHtmlController(fontNamesToExclude);
var formatter = HtmlFormatter.CreateCustomFormatter(fontController);

var htmlOptions = new HtmlOptions
{
    HtmlFormatter = formatter
};

presentation.Save("presentation-embedded-fonts.html", SaveFormat.Html, htmlOptions);
```

대상 브라우저나 시스템이 이미 글꼴을 제공한다는 확신이 있을 때만 글꼴을 제외하십시오. 브랜드 글꼴이나 흔하지 않은 글꼴은 일반적으로 포함하는 것이 안전합니다.

## **글꼴 파일을 포함하는 대신 링크하기**

HTML 파일 크기를 줄이기 위해 글꼴 데이터를 별도의 WOFF 파일에 기록하고 HTML에 `@font-face` 규칙을 추가할 수 있습니다. 아래 도우미는 [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/ko/net/aspose.slides.export/embedallfontshtmlcontroller/)를 확장하고 `WriteFont`를 재정의합니다.

```cs
using var presentation = new Presentation("presentation.pptx");

var outputDirectory = Path.Combine(Environment.CurrentDirectory, "html-output");
var fontsDirectory = Path.Combine(outputDirectory, "fonts");
Directory.CreateDirectory(outputDirectory);

var fontController = new LinkedFontsHtmlController(fontsDirectory, "fonts");
var formatter = HtmlFormatter.CreateCustomFormatter(fontController);

var htmlOptions = new HtmlOptions
{
    HtmlFormatter = formatter
};

var htmlFilePath = Path.Combine(outputDirectory, "presentation.html");
presentation.Save(htmlFilePath, SaveFormat.Html, htmlOptions);
```

```cs
public sealed class LinkedFontsHtmlController : EmbedAllFontsHtmlController
{
    private readonly string _fontOutputDirectory;
    private readonly string _fontUrlPrefix;

    public LinkedFontsHtmlController(
        string fontOutputDirectory,
        string fontUrlPrefix)
        : base(Array.Empty<string>())
    {
        _fontOutputDirectory = fontOutputDirectory;
        _fontUrlPrefix = fontUrlPrefix.TrimEnd('/') + "/";

        Directory.CreateDirectory(_fontOutputDirectory);
    }

    public override void WriteFont(
        IHtmlGenerator generator,
        IFontData originalFont,
        IFontData substitutedFont,
        string fontStyle,
        string fontWeight,
        byte[] fontData)
    {
        var font = substitutedFont ?? originalFont;
        var safeFontName = MakeSafeFileName(font.FontName);
        var safeFontStyle = string.IsNullOrWhiteSpace(fontStyle) ? "normal" : fontStyle;
        var safeFontWeight = string.IsNullOrWhiteSpace(fontWeight) ? "normal" : fontWeight;
        var fontFileName = $"{safeFontName}-{safeFontStyle}-{safeFontWeight}.woff";
        var fontFilePath = Path.Combine(_fontOutputDirectory, fontFileName);

        File.WriteAllBytes(fontFilePath, fontData);

        var fontUrl = _fontUrlPrefix + Uri.EscapeDataString(fontFileName);
        var fontFamily = font.FontName.Replace("\\", "\\\\").Replace("'", "\\'");

        generator.AddHtml("<style>");
        generator.AddHtml("@font-face {");
        generator.AddHtml($"font-family: '{fontFamily}';");
        generator.AddHtml($"font-style: {safeFontStyle};");
        generator.AddHtml($"font-weight: {safeFontWeight};");
        generator.AddHtml($"src: url('{fontUrl}') format('woff');");
        generator.AddHtml("}");
        generator.AddHtml("</style>");
    }

    private static string MakeSafeFileName(string fileName)
    {
        var invalidCharacters = Path.GetInvalidFileNameChars();
        var safeCharacters = fileName.ToCharArray();

        for (var characterIndex = 0; characterIndex < safeCharacters.Length; characterIndex++)
        {
            if (Array.IndexOf(invalidCharacters, safeCharacters[characterIndex]) >= 0)
            {
                safeCharacters[characterIndex] = '_';
            }
        }

        return new string(safeCharacters);
    }
}
```

이 예제에서는 글꼴 파일이 `html-output/fonts`에 저장되고 HTML은 `fonts/BrandFont-normal-400.woff`와 같은 URL로 참조합니다. HTML 파일과 글꼴이 다른 위치에 배포될 경우 배포된 URL 경로와 일치하도록 `fontUrlPrefix`를 선택하십시오.

## **리소스를 외부에 저장**

자체 포함 HTML은 이동이 쉽지만, Base64로 포함된 리소스는 파일을 크게 만들 수 있습니다. 애플리케이션에서 외부 이미지 파일이 필요하면 [ILinkEmbedController](https://reference.aspose.com/slides/ko/net/aspose.slides.export/ilinkembedcontroller/)를 구현하고 이를 [HtmlOptions](https://reference.aspose.com/slides/ko/net/aspose.slides.export/htmloptions/htmloptions/) 생성자에 전달하십시오.

리소스를 외부화할 때는 두 경로를 신중하게 선택하십시오:

- 파일 시스템 출력 경로: 애플리케이션이 생성된 이미지, 글꼴, 오디오 또는 비디오를 기록하는 디렉터리.
- URL 경로: 브라우저가 HTML 문서에서 해당 파일들을 로드하기 위해 사용하는 경로.

전체 이미지 연결 구현 예시는 [Export Presentations to HTML with Externally Linked Images](/slides/ko/net/exporting-presentations-to-html-with-externally-linked-images/)를 참조하십시오.

## **미디어 파일 내보내기**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/ko/net/aspose.slides.export/videoplayerhtmlcontroller/)는 비디오와 오디오 파일을 내보내고 브라우저에서 재생할 수 있는 HTML을 작성합니다. 생성자는 다음을 받습니다:

- `path`: 생성된 미디어 파일이 기록될 디렉터리.
- `fileName`: 생성 중인 HTML 파일 이름.
- `baseUri`: 미디어 파일에 대한 HTML 링크에 사용할 절대 URI 접두사.

HTML 파일이 `html-output/presentation.html`이고 미디어 파일이 `html-output/media`에 저장되는 경우, `path`는 디스크상의 미디어 디렉터리를 가리켜야 하고, `baseUri`는 브라우저 관점에서 동일한 디렉터리를 가리켜야 합니다. 로컬 미리 보기를 위해서는 미디어 디렉터리에서 `file:///` URI를 만들 수 있습니다. 배포된 애플리케이션에서는 게시된 미디어 디렉터리의 절대 URL을 사용하십시오.

```csharp
var outputDirectory = Path.Combine(Environment.CurrentDirectory, "html-output");
var mediaDirectory = Path.Combine(outputDirectory, "media");
Directory.CreateDirectory(outputDirectory);
Directory.CreateDirectory(mediaDirectory);

var htmlFileName = "presentation.html";
var mediaBaseUri = new Uri(mediaDirectory + Path.DirectorySeparatorChar).AbsoluteUri;

using var presentation = new Presentation();
using var videoStream = new FileStream("intro.mp4", FileMode.Open, FileAccess.Read);

var video = presentation.Videos.AddVideo(videoStream, LoadingStreamBehavior.ReadStreamAndRelease);
var slide = presentation.Slides[0];
slide.Shapes.AddVideoFrame(20, 20, 480, 270, video);

var controller = new VideoPlayerHtmlController(mediaDirectory, htmlFileName, mediaBaseUri);
var formatter = HtmlFormatter.CreateCustomFormatter(controller);
var svgOptions = new SVGOptions(controller);
var slideImageFormat = SlideImageFormat.Svg(svgOptions);

var htmlOptions = new HtmlOptions(controller)
{
    HtmlFormatter = formatter,
    SlideImageFormat = slideImageFormat
};

var htmlFilePath = Path.Combine(outputDirectory, htmlFileName);
presentation.Save(htmlFilePath, SaveFormat.Html, htmlOptions);
```

내보내기 작업당 고유한 출력 디렉터리를 사용하십시오, 특히 서버 애플리케이션에서는 더욱 그렇습니다. 공유된 출력 경로는 서로 다른 변환 작업의 파일이 겹쳐서 덮어쓰일 위험이 있습니다.

## **성능 및 리소스 관리**

HTML 변환은 렌더링 작업이므로 처리 시간과 메모리 사용량은 슬라이드 수, 이미지 해상도, 글꼴, 효과, 차트 및 포함된 미디어에 따라 달라집니다. 높은 `PicturesCompression` DPI 값, 포함된 글꼴, SVG 출력 및 유지된 잘린 이미지 영역은 충실도를 높일 수 있지만 일반적으로 출력 크기를 증가시킵니다.

배치 변환 시:

- 모든 [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/) 인스턴스를 즉시 해제하십시오.
- 작업마다 별도의 출력 디렉터리를 사용하십시오.
- 충실도가 필요하지 않다면 일반 글꼴을 포함하지 마십시오.
- HTML이 미리 보기나 썸네일용이라면 이미지 DPI를 낮추십시오.
- 배포 경로가 최종 확정될 때까지 원본 프레젠테이션, 생성된 HTML 및 외부 리소스를 함께 보관하십시오.

## **FAQ**

**HTML 출력에서 하이퍼링크가 보존됩니까?**

예. 프레젠테이션 하이퍼링크는 HTML로 내보내지며 대상 URL이 유효한 경우 클릭 가능하게 유지됩니다.

**프레젠테이션을 HTML로 병렬 변환할 수 있습니까?**

예, 하지만 하나의 [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/) 인스턴스를 스레드 간에 공유하지 마십시오. 파일마다 별도의 프레젠테이션 인스턴스, 별도의 스트림 및 별도의 출력 디렉터리를 사용하여 처리하십시오. 자세한 내용은 [multithreading guidance](/slides/ko/net/multithreading/)를 참조하십시오.

**Presentation 객체는 스레드 안전합니까?**

아니요. 단일 [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/) 인스턴스는 하나의 스레드에서만 로드, 수정, 저장 및 해제되어야 합니다. 병렬 작업을 수행하려면 스레드당 독립적인 인스턴스를 생성하거나 프로세스를 분리하십시오.

**생성된 HTML 파일이 큰 이유는 무엇입니까?**

기본 내보내기는 리소스를 직접 HTML에 포함합니다. 포함된 글꼴, 고 DPI 이미지, 미디어, SVG 콘텐츠 및 유지된 잘린 이미지 영역이 크기를 증가시킵니다. 외부 리소스를 사용하고, 일반 글꼴 포함을 제외하며, `PicturesCompression`을 낮추면 파일 크기를 줄일 수 있습니다.

**PowerPoint에서 24 pt와 같은 글꼴 크기가 HTML에서는 17.999819 pt로 표시되는 이유는?**

PowerPoint와 HTML은 서로 다른 DPI 모델을 사용하기 때문입니다. PowerPoint는 72 DPI 기반의 타이포그래픽 포인트로 텍스트 크기를 저장하고, HTML 레이아웃은 96 DPI 기반의 CSS 픽셀을 사용합니다. Aspose.Slides가 프레젠테이션을 HTML로 내보낼 때 두 시스템 간 변환 과정에서 작은 반올림 차이가 발생할 수 있습니다.

이 값은 실제 시각적 글꼴 크기 변화가 있음을 의미하지 않으며, 단지 변환 과정에서 발생한 수학적 부작용일 뿐입니다.

**미디어 내보내기를 위한 baseUri를 어떻게 선택해야 합니까?**

브라우저 관점에서의 절대 URI를 선택하고 이를 절대 URI 문자열로 전달하십시오. 로컬 미리 보기의 경우 `new Uri(mediaDirectory + Path.DirectorySeparatorChar).AbsoluteUri`와 같이 출력 디렉터리에서 파생시킬 수 있습니다. 배포 시에는 게시된 미디어 디렉터리의 절대 URL을 사용하십시오. 파일 시스템 `path`와 브라우저 `baseUri`는 반드시 동일한 문자열일 필요는 없지만 동일한 리소스 위치를 가리켜야 합니다.

**숨겨진 슬라이드를 포함할 수 있습니까?**

예. 숨겨진 슬라이드를 내보내야 할 경우 [HtmlOptions](https://reference.aspose.com/slides/ko/net/aspose.slides.export/htmloptions/)에서 `ShowHiddenSlides = true` 로 설정하십시오.
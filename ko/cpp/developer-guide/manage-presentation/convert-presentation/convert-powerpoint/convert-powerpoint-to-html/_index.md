---
title: C++에서 PowerPoint 프레젠테이션을 HTML로 변환
linktitle: PowerPoint를 HTML로
type: docs
weight: 30
url: /ko/cpp/convert-powerpoint-to-html/
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
- C++
- Aspose.Slides
description: "C++에서 PowerPoint 프레젠테이션을 HTML로 변환합니다. Aspose.Slides를 사용하여 PPT 및 PPTX 파일, 선택한 슬라이드, 노트, 글꼴, 이미지, SVG 및 미디어를 내보낼 수 있습니다."
---
## **개요**

Aspose.Slides for C++는 Microsoft PowerPoint 없이 PowerPoint 프레젠테이션을 HTML로 저장할 수 있습니다. 기본 변환은 단일 [Presentation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/) 로드와 [SaveFormat](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/saveformat/)으로 `Save` 호출을 수행합니다. 내보낸 레이아웃, 글꼴, 이미지, 노트, 댓글, SVG 출력 또는 연결된 리소스를 제어해야 할 경우 [HtmlOptions](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/htmloptions/)를 사용하십시오.

이 가이드는 실용적인 HTML 내보내기 시나리오에 초점을 맞춥니다:

- 전체 프레젠테이션 또는 선택된 슬라이드 내보내기.
- 고정 레이아웃, 반응형 또는 SVG 기반 HTML 생성.
- 발표자 노트와 댓글 포함.
- 이미지 품질 및 잘린 이미지 데이터 제어.
- 글꼴을 임베드하거나 글꼴 파일을 별도로 저장.
- 외부 리소스 및 미디어 파일이 작성되고 참조되는 방식을 선택.

기본적으로 HTML 내보내기는 대부분의 리소스가 임베드된 자체 포함 HTML 문서를 생성합니다. 하나의 파일을 공유하기에 편리하지만 출력 크기가 커질 수 있습니다. 웹 게시의 경우 외부 리소스 사용, 이미지 DPI 낮추기, 대상 환경에 신뢰할 수 없는 글꼴만 임베드하는 방안을 고려하십시오.

## **프레젠테이션을 HTML로 변환**

프레젠테이션을 HTML로 내보내려면 [Presentation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/)으로 로드하고 `SaveFormat::Html`으로 저장합니다.

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

presentation->Save(u"presentation.html", SaveFormat::Html);

presentation->Dispose();
```

이 예제는 하나의 HTML 파일을 작성합니다. `Dispose` 호출은 내보낸 후 파일 핸들과 렌더링 리소스를 해제합니다.

## **HtmlOptions 사용**

[HtmlOptions](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/htmloptions/)는 HTML 내보내기의 주요 구성 클래스입니다. 일반 설정은 다음과 같습니다:

- `SlidesLayoutOptions`: 노트, 댓글, 유인물 또는 기타 레이아웃 정보를 추가합니다.
- `HtmlFormatter`: HTML 문서 구조를 변경하거나 포맷팅을 컨트롤러에 위임합니다.
- `SlideImageFormat`: 슬라이드 표현 방식을 변경합니다(예: SVG).
- `PicturesCompression`: 이미지 DPI와 출력 크기를 제어합니다.
- `DeletePicturesCroppedAreas`: 잘린 이미지 데이터를 유지하거나 제거합니다.
- `SvgResponsiveLayout`: 내보낸 SVG 콘텐츠가 컨테이너에 맞게 조정되도록 합니다.
- `ShowHiddenSlides`: 필요한 경우 숨겨진 슬라이드를 포함합니다.

다음 섹션에서는 가장 일반적인 옵션을 별도로 보여 주어 워크플로에 필요한 옵션만 조합할 수 있습니다.

## **선택된 슬라이드를 HTML로 변환**

슬라이드 번호를 받는 `Presentation::Save` 오버로드는 1 기반 슬라이드 위치를 사용합니다. 아래 루프는 각 슬라이드를 별도의 HTML 파일에 저장합니다.

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto slideCount = presentation->get_Slides()->get_Count();

for (int slideIndex = 0; slideIndex < slideCount; slideIndex++)
{
    auto slideNumber = slideIndex + 1;
    auto slideNumbers = System::MakeArray<int>({ slideNumber });
    auto htmlFileName = System::String::Format(u"slide-{0}.html", slideNumber);

    presentation->Save(htmlFileName, slideNumbers, SaveFormat::Html);
}

presentation->Dispose();
```

웹사이트나 애플리케이션에서 슬라이드당 하나의 HTML 페이지가 필요한 경우 이 패턴을 사용하십시오. 각 슬라이드가 동일한 레이아웃이어야 하면 하나의 [HtmlOptions](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/htmloptions/) 인스턴스를 만들고 각 `Save` 호출에 전달하십시오.

## **반응형 HTML 만들기**

[ResponsiveHtmlController](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/responsivehtmlcontroller/)는 [HtmlFormatter](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/htmlformatter/)를 통해 반응형 HTML 출력을 제공합니다. 브라우저 너비에 더 잘 적응하도록 내보낸 페이지를 조정해야 할 때 사용하십시오.

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto controller = System::MakeObject<ResponsiveHtmlController>();
auto formatter = HtmlFormatter::CreateCustomFormatter(controller);

auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_HtmlFormatter(formatter);

presentation->Save(u"presentation-responsive.html", SaveFormat::Html, htmlOptions);

presentation->Dispose();
```

SVG 기반 반응형 레이아웃을 위해서는 [HtmlOptions](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/htmloptions/)에 `SvgResponsiveLayout`을 설정하십시오. 슬라이드 내용이 확장 가능한 SVG 마크업으로 내보내질 때 유용합니다.

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_SvgResponsiveLayout(true);

presentation->Save(u"presentation-svg-responsive.html", SaveFormat::Html, htmlOptions);

presentation->Dispose();
```

## **발표자 노트와 댓글 포함**

`HtmlOptions.SlidesLayoutOptions`을 통해 [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/notescommentslayoutingoptions/)를 사용하여 발표자 노트 또는 댓글을 포함할 수 있습니다. 기본적으로 노트와 댓글은 숨겨져 있으며 위치를 선택해야 표시됩니다.

소스 프레젠테이션에 발표자 노트가 포함되어 있다고 가정해 보십시오:

![PowerPoint의 발표자 메모가 있는 슬라이드](slide_with_notes.png)

다음 코드는 슬라이드 아래에 발표자 노트를 추가하여 슬라이드 내용을 내보냅니다.

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto layoutOptions = System::MakeObject<NotesCommentsLayoutingOptions>();
layoutOptions->set_NotesPosition(NotesPositions::BottomFull);

auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_SlidesLayoutOptions(layoutOptions);

presentation->Save(u"presentation-with-notes.html", SaveFormat::Html, htmlOptions);

presentation->Dispose();
```

내보낸 HTML에는 노트 영역이 포함됩니다:

![슬라이드와 발표자 메모가 포함된 HTML 출력](HTML_with_notes.png)

댓글을 내보내려면 `CommentsPosition`을 예를 들어 `CommentsPositions::Right` 또는 `CommentsPositions::Bottom`으로 설정하십시오. 댓글만 필요하면 `NotesPosition`을 생략하십시오. 노트와 댓글을 모두 원하면 두 속성을 모두 설정하십시오.

## **이미지 품질 및 잘린 영역 제어**

HTML 내보내기는 슬라이드 이미지를 압축하여 출력 크기를 줄일 수 있습니다. 더 높은 이미지 품질이 필요하면 [PicturesCompression](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/picturescompression/)에서 적절한 값을 설정하십시오.

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_PicturesCompression(PicturesCompression::Dpi150);

presentation->Save(u"presentation-dpi-150.html", SaveFormat::Html, htmlOptions);

presentation->Dispose();
```

기본적으로 잘린 이미지 영역은 내보낸 결과에서 제거될 수 있습니다. 사용자가 숨겨진 이미지 부분을 복구하거나 검사해야 할 경우에만 잘린 데이터를 유지하십시오. 유지하면 HTML 크기가 증가할 수 있습니다.

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_DeletePicturesCroppedAreas(false);

presentation->Save(u"presentation-with-cropped-areas.html", SaveFormat::Html, htmlOptions);

presentation->Dispose();
```

## **CSS 추가**

간단한 스타일링을 위해 `HtmlFormatter::CreateDocumentFormatter`에 CSS 문자열을 전달하십시오. 이는 Aspose.Slides가 슬라이드 콘텐츠를 렌더링하는 동안 주변 HTML 문서를 변경합니다.

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto cssRules = u"body { margin: 0; background: #f7f7f7; } .slide { margin: 24px auto; }";
auto formatter = HtmlFormatter::CreateDocumentFormatter(cssRules, true);

auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_HtmlFormatter(formatter);

presentation->Save(u"presentation-styled.html", SaveFormat::Html, htmlOptions);

presentation->Dispose();
```

맞춤형 문서 헤더, 연결된 CSS 파일, 또는 슬라이드와 도형 주변에 맞춤 마크업을 적용하려면 [IHtmlFormattingController](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/ihtmlformattingcontroller/)를 구현하고 `CreateCustomFormatter`와 함께 [HtmlFormatter](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/htmlformatter/)에 전달하십시오.

## **글꼴 임베드**

대상 환경에 프레젠테이션 글꼴이 설치되어 있지 않을 수 있는 경우 [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/embedallfontshtmlcontroller/)를 사용하여 HTML에 글꼴을 임베드하십시오. 임베드는 시각적 충실도를 높이지만 출력 크기가 커집니다.

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto fontNamesToExclude = System::MakeArray<System::String>({ u"Arial" });
auto fontController = System::MakeObject<EmbedAllFontsHtmlController>(fontNamesToExclude);
auto formatter = HtmlFormatter::CreateCustomFormatter(fontController);

auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_HtmlFormatter(formatter);

presentation->Save(u"presentation-embedded-fonts.html", SaveFormat::Html, htmlOptions);

presentation->Dispose();
```

대상 브라우저나 시스템에 이미 글꼴이 제공된다고 확신하는 경우에만 글꼴을 제외하십시오. 브랜드 글꼴이나 덜 일반적인 글꼴은 임베드하는 것이 일반적으로 안전합니다.

## **임베드 대신 글꼴 파일 연결**

HTML 파일 크기를 줄이려면 글꼴 데이터를 별도의 WOFF 파일에 쓰고 HTML에 `@font-face` 규칙을 추가할 수 있습니다. 아래 도우미는 [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/embedallfontshtmlcontroller/)를 확장하고 `WriteFont`를 재정의합니다.

```cpp
class LinkedFontsHtmlController : public EmbedAllFontsHtmlController
{
public:
    LinkedFontsHtmlController(
        System::String fontOutputDirectory,
        System::String fontUrlPrefix)
        : EmbedAllFontsHtmlController(System::MakeArray<System::String>(0)),
          m_fontOutputDirectory(fontOutputDirectory),
          m_fontUrlPrefix(fontUrlPrefix.TrimEnd(u'/') + u"/")
    {
        System::IO::Directory::CreateDirectory_(m_fontOutputDirectory);
    }

    void WriteFont(
        System::SharedPtr<IHtmlGenerator> generator,
        System::SharedPtr<IFontData> originalFont,
        System::SharedPtr<IFontData> substitutedFont,
        System::String fontStyle,
        System::String fontWeight,
        System::ArrayPtr<uint8_t> fontData) override
    {
        auto font = substitutedFont == nullptr ? originalFont : substitutedFont;
        auto safeFontName = MakeSafeFileName(font->get_FontName());
        auto safeFontStyle = System::String::IsNullOrWhiteSpace(fontStyle) ? u"normal" : fontStyle;
        auto safeFontWeight = System::String::IsNullOrWhiteSpace(fontWeight) ? u"normal" : fontWeight;
        auto fontFileName = System::String::Format(u"{0}-{1}-{2}.woff", safeFontName, safeFontStyle, safeFontWeight);
        auto fontFilePath = System::IO::Path::Combine(m_fontOutputDirectory, fontFileName);

        System::IO::File::WriteAllBytes(fontFilePath, fontData);

        auto fontUrl = m_fontUrlPrefix + System::Uri::EscapeDataString(fontFileName);
        auto fontFamily = font->get_FontName().Replace(u"\\", u"\\\\").Replace(u"'", u"\\'");

        generator->AddHtml(u"<style>");
        generator->AddHtml(u"@font-face {");
        generator->AddHtml(System::String::Format(u"font-family: '{0}';", fontFamily));
        generator->AddHtml(System::String::Format(u"font-style: {0};", safeFontStyle));
        generator->AddHtml(System::String::Format(u"font-weight: {0};", safeFontWeight));
        generator->AddHtml(System::String::Format(u"src: url('{0}') format('woff');", fontUrl));
        generator->AddHtml(u"}");
        generator->AddHtml(u"</style>");
    }

private:
    System::String m_fontOutputDirectory;
    System::String m_fontUrlPrefix;

    System::String MakeSafeFileName(System::String fileName)
    {
        auto invalidCharacters = System::IO::Path::GetInvalidFileNameChars();
        auto safeCharacters = fileName.ToCharArray();

        for (int characterIndex = 0; characterIndex < safeCharacters->get_Length(); characterIndex++)
        {
            if (System::Array<int16_t>::IndexOf(invalidCharacters, safeCharacters[characterIndex]) >= 0)
            {
                safeCharacters[characterIndex] = u'_';
            }
        }

        return System::String(safeCharacters);
    }
};

auto outputDirectory = System::IO::Path::Combine(System::Environment::get_CurrentDirectory(), u"html-output");
auto fontsDirectory = System::IO::Path::Combine(outputDirectory, u"fonts");
System::IO::Directory::CreateDirectory_(outputDirectory);

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto fontController = System::MakeObject<LinkedFontsHtmlController>(fontsDirectory, u"fonts");
auto formatter = HtmlFormatter::CreateCustomFormatter(fontController);

auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_HtmlFormatter(formatter);

auto htmlFilePath = System::IO::Path::Combine(outputDirectory, u"presentation.html");
presentation->Save(htmlFilePath, SaveFormat::Html, htmlOptions);

presentation->Dispose();
```

이 예제에서는 글꼴 파일이 `html-output/fonts`에 저장되고 HTML은 `fonts/BrandFont-normal-400.woff`와 같은 URL을 참조합니다. HTML 파일과 글꼴을 다른 위치에 배포하는 경우 배포된 URL 경로와 일치하도록 `fontUrlPrefix`를 지정하십시오.

## **리소스 외부 저장**

자체 포함 HTML은 이동이 쉽지만 Base64 임베드 리소스로 인해 파일이 커질 수 있습니다. 애플리케이션에서 외부 이미지 파일이 필요하면 [ILinkEmbedController](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/ilinkembedcontroller/)를 구현하고 [HtmlOptions](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/htmloptions/) 생성자에 전달하십시오.

리소스를 외부화할 때는 두 경로를 명확히 선택하십시오:

- 파일 시스템 출력 경로: 애플리케이션이 생성된 이미지, 글꼴, 오디오 또는 비디오를 기록하는 위치.
- URL 경로: 브라우저가 HTML 문서에서 해당 파일을 로드하기 위해 사용하는 경로.

## **미디어 파일 내보내기**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/videoplayerhtmlcontroller/)는 비디오 및 오디오 파일을 내보내고 브라우저에서 재생할 수 있는 HTML을 작성합니다. 생성자는 다음을 받습니다:

- `path`: 생성된 미디어 파일이 기록될 디렉터리.
- `fileName`: 생성 중인 HTML 파일 이름.
- `baseUri`: HTML 링크에서 미디어 파일에 사용되는 절대 URI 접두사.

HTML 파일이 `html-output/presentation.html`이고 미디어 파일이 `html-output/media`에 저장되는 경우, `path`는 디스크상의 미디어 디렉터리를 가리키고 `baseUri`는 브라우저 관점에서 동일 디렉터리를 가리켜야 합니다. 로컬 미리보기를 위해서는 미디어 디렉터리에서 `file:///` URI를 만들 수 있습니다. 배포된 애플리케이션에서는 공개된 미디어 디렉터리의 절대 URL을 사용하십시오.

```cpp
auto outputDirectory = System::IO::Path::Combine(System::Environment::get_CurrentDirectory(), u"html-output");
auto mediaDirectory = System::IO::Path::Combine(outputDirectory, u"media");
System::IO::Directory::CreateDirectory_(outputDirectory);
System::IO::Directory::CreateDirectory_(mediaDirectory);

auto htmlFileName = u"presentation.html";
auto mediaBaseUri = System::MakeObject<System::Uri>(mediaDirectory + System::IO::Path::DirectorySeparatorChar)->get_AbsoluteUri();

auto presentation = System::MakeObject<Presentation>();
auto videoStream = System::MakeObject<System::IO::FileStream>(u"intro.mp4", System::IO::FileMode::Open, System::IO::FileAccess::Read);

auto video = presentation->get_Videos()->AddVideo(videoStream, LoadingStreamBehavior::ReadStreamAndRelease);
auto slide = presentation->get_Slide(0);
slide->get_Shapes()->AddVideoFrame(20.0f, 20.0f, 480.0f, 270.0f, video);

auto controller = System::MakeObject<VideoPlayerHtmlController>(mediaDirectory, htmlFileName, mediaBaseUri);
auto formatter = HtmlFormatter::CreateCustomFormatter(controller);
auto svgOptions = System::MakeObject<SVGOptions>(controller);
auto slideImageFormat = SlideImageFormat::Svg(svgOptions);

auto htmlOptions = System::MakeObject<HtmlOptions>(controller);
htmlOptions->set_HtmlFormatter(formatter);
htmlOptions->set_SlideImageFormat(slideImageFormat);

auto htmlFilePath = System::IO::Path::Combine(outputDirectory, htmlFileName);
presentation->Save(htmlFilePath, SaveFormat::Html, htmlOptions);

videoStream->Dispose();
presentation->Dispose();
```

내보내기 작업당 고유한 출력 디렉터리를 사용하십시오. 서버 애플리케이션에서는 공유 출력 경로가 서로 다른 변환의 파일을 덮어쓰는 원인이 될 수 있습니다.

## **성능 및 리소스 관리**

HTML 변환은 렌더링 작업이므로 처리 시간과 메모리 사용량은 슬라이드 수, 이미지 해상도, 글꼴, 효과, 차트 및 임베드된 미디어에 따라 달라집니다. 높은 `PicturesCompression` DPI 값, 임베드된 글꼴, SVG 출력 및 유지된 잘린 이미지 영역은 충실도를 높이지만 일반적으로 출력 크기를 증가시킵니다.

배치 변환 시:

- 각 [Presentation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/) 인스턴스를 즉시 `Dispose`하십시오.
- 작업별로 별도 출력 디렉터리를 사용하십시오.
- 충실도가 필요하지 않은 경우 일반 글꼴을 임베드하지 마십시오.
- 미리보기나 썸네일용 HTML이라면 이미지 DPI를 낮추십시오.
- 배포 경로가 확정될 때까지 원본 프레젠테이션, 생성된 HTML 및 외부 리소스를 함께 보관하십시오.

## **FAQ**

**하이퍼링크가 HTML 출력에 보존되나요?**

예. 프레젠테이션 하이퍼링크는 HTML로 내보내지며 대상 URL이 유효한 경우 클릭할 수 있습니다.

**프레젠테이션을 HTML로 병렬 변환할 수 있나요?**

예, 하지만 하나의 [Presentation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/) 인스턴스를 스레드 간에 공유하지 마십시오. 파일마다 별도 프레젠테이션 인스턴스, 별도 스트림 및 별도 출력 디렉터리를 사용하십시오. 자세한 내용은 [멀티스레딩 가이드](/slides/ko/cpp/multithreading/)를 참조하십시오.

**Presentation 객체는 스레드 안전한가요?**

아니요. 단일 [Presentation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/) 인스턴스는 하나의 스레드에서 로드, 수정, 저장 및 해제되어야 합니다. 병렬 작업이 필요하면 스레드당 독립 인스턴스를 만들거나 프로세스를 분리하십시오.

**생성된 HTML 파일이 큰 이유는 무엇인가요?**

기본 내보내기는 리소스를 HTML에 직접 임베드합니다. 임베드된 글꼴, 고 DPI 이미지, 미디어, SVG 콘텐츠 및 유지된 잘린 이미지 영역이 크기를 증가시킵니다. 외부 리소스를 사용하고, 일반 글꼴은 임베드하지 않으며, `PicturesCompression`을 낮게 설정하면 출력 크기를 줄일 수 있습니다.

**PowerPoint에서 24pt와 같은 글꼴 크기가 HTML에서는 17.999819pt로 표시되는 이유는?**

PowerPoint와 HTML은 서로 다른 DPI 모델을 사용하기 때문입니다. PowerPoint는 72 DPI 기반의 타이포그래픽 포인트를 사용하고, HTML 레이아웃은 96 DPI 기반의 CSS 픽셀을 사용합니다. Aspose.Slides가 프레젠테이션을 HTML로 내보낼 때 글꼴 크기가 두 시스템 간에 변환되며, 이 과정에서 작은 반올림 차이가 발생할 수 있습니다.

이 값은 실제 시각적 글꼴 크기 변화가 아니라 PowerPoint와 HTML 간 텍스트 메트릭 변환의 수학적 부작용에 불과합니다.

**미디어 내보내기용 baseUri는 어떻게 선택해야 하나요?**

브라우저 관점에서의 경로를 `baseUri`로 선택하고 절대 URI로 전달하십시오. 로컬 미리보기의 경우 출력 디렉터리에서 `System::MakeObject<System::Uri>(mediaDirectory + System::IO::Path::DirectorySeparatorChar)->get_AbsoluteUri()`를 사용해 만들 수 있습니다. 배포 시에는 게시된 미디어 디렉터리의 절대 URL을 사용하십시오. 파일 시스템 `path`와 브라우저 `baseUri`는 같은 문자열일 필요는 없지만 동일한 리소스 위치를 가리켜야 합니다.

**숨겨진 슬라이드를 포함할 수 있나요?**

예. 숨겨진 슬라이드를 내보내야 할 경우 [HtmlOptions](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/htmloptions/)에서 `ShowHiddenSlides`를 `true`로 설정하십시오.
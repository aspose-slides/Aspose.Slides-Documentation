---
title: C++를 사용한 프레젠테이션에 글꼴 삽입
linktitle: 글꼴 삽입
type: docs
weight: 40
url: /ko/cpp/embedded-font/
keywords:
- 글꼴 추가
- 글꼴 삽입
- 글꼴 삽입
- 내장된 글꼴 가져오기
- 내장된 글꼴 추가
- 내장된 글꼴 제거
- 내장된 글꼴 압축
- PowerPoint
- OpenDocument
- 프레젠테이션
- C++
- Aspose.Slides
description: "Aspose.Slides for C++를 사용하여 PowerPoint 및 OpenDocument 프레젠테이션에 TrueType 글꼴을 삽입하면 모든 플랫폼에서 정확한 렌더링을 보장합니다."
---
## **소개**

**PowerPoint에서 내장된 글꼴**은 프레젠테이션이 어떤 시스템이나 장치에서 열리더라도 의도한 모양을 유지하도록 도와줍니다. 이는 브랜드나 창의적 목적을 위해 사용자 정의, 서드파티 또는 비표준 글꼴을 사용할 때 특히 중요합니다. 내장된 글꼴이 없으면 텍스트가 대체되고 레이아웃이 깨지며 문자가 읽을 수 없는 기호나 사각형으로 표시되어 전체 디자인이 손상될 수 있습니다.

Aspose.Slides for C++는 내장 글꼴을 프로그래밍 방식으로 관리할 수 있는 강력한 API 세트를 제공합니다. [FontsManager](https://reference.aspose.com/slides/ko/cpp/aspose.slides/fontsmanager/)와 [FontData](https://reference.aspose.com/slides/ko/cpp/aspose.slides/fontdata/) 클래스를 사용하여 프레젠테이션 파일에 포함된 내장 글꼴을 검사, 추가 또는 제거할 수 있습니다. 또한 [Compress](https://reference.aspose.com/slides/ko/cpp/aspose.slides.lowcode/compress/) 클래스를 사용하면 품질이나 모양에 영향을 주지 않으면서 글꼴 데이터를 압축하여 파일 크기를 최적화할 수 있습니다.

이 도구들을 사용하면 글꼴 내장을 완전하게 제어하여 플랫폼 간 일관된 타이포그래피를 유지하면서 필요 시 파일 크기를 줄일 수 있습니다.

## **프레젠테이션에서 내장 글꼴 가져오기**

Aspose.Slides for C++는 [FontsManager](https://reference.aspose.com/slides/ko/cpp/aspose.slides/fontsmanager/) 클래스를 통해 `GetEmbeddedFonts` 메서드를 제공하며, 이를 사용하면 PowerPoint 프레젠테이션에 내장된 글꼴 목록을 가져올 수 있습니다. 이는 글꼴 사용 현황을 감사하거나, 브랜드 가이드라인 준수를 확인하거나, 파일을 공유하기 전에 필요한 모든 글꼴이 올바르게 포함되어 있는지 검증하는 데 유용합니다.

다음 C++ 코드는 프레젠테이션 파일에서 내장 글꼴을 가져오는 방법을 보여줍니다:

```cpp
// 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
auto presentation = MakeObject<Presentation>(u"embedded_fonts.pptx");

// 모든 내장 글꼴을 가져옵니다.
auto embeddedFonts = presentation->get_FontsManager()->GetEmbeddedFonts();

// 내장 글꼴의 이름을 출력합니다.
for (auto&& fontData : embeddedFonts)
{
    Console::WriteLine(fontData->get_FontName());
}

presentation->Dispose();
```

## **프레젠테이션에 내장 글꼴 추가**

Aspose.Slides for C++는 [AddEmbeddedFont](https://reference.aspose.com/slides/ko/cpp/aspose.slides/fontsmanager/addembeddedfont/) 메서드를 통해 PowerPoint 프레젠테이션에 글꼴을 내장할 수 있으며, 두 개의 오버로드를 제공하여 유연하게 사용할 수 있습니다. [EmbedFontCharacters](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/embedfontcharacters/) 열거형을 사용하여 글꼴의 어떤 부분을 내장할지 제어할 수 있습니다—예를 들어 사용된 문자만 내장하거나 전체 글꼴 세트를 내장하도록 선택할 수 있습니다. 이 기능은 프레젠테이션을 공유하거나 배포하기 위해 준비할 때 특히 유용하며, 사용자 정의 또는 비표준 글꼴이 해당 글꼴이 설치되지 않은 시스템에서도 올바르게 표시되도록 합니다.

다음 C++ 코드는 프레젠테이션에서 사용된 모든 글꼴을 확인하고 아직 내장되지 않은 글꼴을 내장합니다.

```cpp
// 프레젠테이션 파일을 로드합니다.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto usedFonts = presentation->get_FontsManager()->GetFonts();
auto embeddedFonts = presentation->get_FontsManager()->GetEmbeddedFonts();

for (auto&& fontData : usedFonts)
{
    std::function<bool(SharedPtr<IFontData> data)> comparer = [&fontData](SharedPtr<IFontData> data) -> bool
        {
            return data == fontData;
        };

    // 글꼴이 이미 내장되어 있는지 확인합니다.
    bool isEmbeddedFont = Array<SharedPtr<IFontData>>::Exists(embeddedFonts, comparer);
    if (!isEmbeddedFont)
    {
        // 프레젠테이션에 글꼴을 내장합니다.
        presentation->get_FontsManager()->AddEmbeddedFont(fontData, EmbedFontCharacters::All);
    }

}

// 프레젠테이션을 디스크에 저장합니다.
presentation->Save(u"embedded_fonts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **프레젠테이션에서 내장 글꼴 제거**

Aspose.Slides for C++는 [FontsManager](https://reference.aspose.com/slides/ko/cpp/aspose.slides/fontsmanager/) 클래스를 통해 `RemoveEmbeddedFont` 메서드를 제공하며, 이를 사용하면 PowerPoint 프레젠테이션에 내장된 특정 글꼴을 제거할 수 있습니다. 이는 특히 사용되지 않거나 필요 없는 내장 글꼴을 제거하여 전체 파일 크기를 줄이는 데 도움이 됩니다. 사용되지 않는 글꼴을 제거하면 성능이 향상되고 프레젠테이션에 필수 리소스만 포함되도록 할 수 있습니다.

다음 C++ 코드는 프레젠테이션에서 내장 글꼴을 제거하는 방법을 보여줍니다:

```cpp
auto fontName = u"Calibri";

// 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
auto presentation = MakeObject<Presentation>(u"embedded_fonts.pptx");

// 모든 내장 글꼴을 가져옵니다.
auto embeddedFonts = presentation->get_FontsManager()->GetEmbeddedFonts();

for (auto&& fontData : embeddedFonts)
{
    if (fontData->get_FontName().Equals(fontName))
    {
        // 내장된 글꼴을 제거합니다.
        presentation->get_FontsManager()->RemoveEmbeddedFont(fontData);

        break;
    }
}

presentation->Save(u"removed_font.ppt", SaveFormat::Ppt);
presentation->Dispose();
```

## **내장 글꼴 압축**

Aspose.Slides for C++는 [Compress](https://reference.aspose.com/slides/ko/cpp/aspose.slides.lowcode/compress/) 클래스를 통해 `CompressEmbeddedFonts` 메서드를 제공하며, 이를 사용하면 내장 글꼴 데이터를 최적화하여 프레젠테이션의 전체 파일 크기를 줄일 수 있습니다. 이는 프레젠테이션에 크거나 여러 개의 글꼴이 포함되어 있을 때 파일을 가볍게 유지하면서도 내용의 시각적 충실도를 손상시키지 않으려는 경우에 특히 유용합니다.

다음 C++ 코드는 PowerPoint 프레젠테이션에서 내장 글꼴을 압축하는 방법을 보여줍니다:

```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");

Compress::CompressEmbeddedFonts(presentation);

presentation->Save(u"compressed_fonts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **FAQ**

**내장했음에도 불구하고 프레젠테이션의 특정 글꼴이 렌더링 시 여전히 대체되는지 어떻게 확인할 수 있나요?**  
[대체 정보](/slides/ko/cpp/font-substitution/)와 [대체/대체 규칙](/slides/ko/cpp/fallback-font/)을 확인하십시오—글꼴이 사용 불가능하거나 제한된 경우 대체 글꼴이 사용됩니다.

**Arial/Calibri와 같은 "시스템" 글꼴을 내장하는 것이 가치가 있나요?**  
보통은 필요 없습니다—대부분의 시스템에 이미 설치되어 있습니다. 하지만 "가벼운" 환경(예: Docker, 사전 설치된 글꼴이 없는 Linux 서버)에서 완전한 이식성을 위해 시스템 글꼴을 내장하면 예상치 못한 대체 위험을 없앨 수 있습니다.
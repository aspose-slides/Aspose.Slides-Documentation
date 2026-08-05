---
title: C++를 사용하여 프레젠테이션에 글꼴 포함하기
linktitle: 글꼴 포함
type: docs
weight: 40
url: /ko/cpp/embedded-font/
keywords:
- 글꼴 추가
- 글꼴 포함
- 글꼴 포함하기
- 포함된 글꼴 가져오기
- 포함된 글꼴 추가
- 포함된 글꼴 제거
- 포함된 글꼴 압축
- PowerPoint
- OpenDocument
- 프레젠테이션
- C++
- Aspose.Slides
description: "Aspose.Slides for C++를 사용하여 PowerPoint 및 OpenDocument 프레젠테이션에 TrueType 글꼴을 포함시켜 모든 플랫폼에서 정확한 렌더링을 보장합니다."
---
## **소개**

**PowerPoint에 포함된 글꼴**은 프레젠테이션을 어떤 시스템이나 장치에서 열어도 의도한 모양을 유지하도록 도와줍니다. 이는 브랜드나 창의적인 목적을 위해 사용자 정의, 타사 또는 비표준 글꼴을 사용할 때 특히 중요합니다. 포함된 글꼴이 없으면 텍스트가 대체되고, 레이아웃이 깨지며, 문자가 읽을 수 없는 기호나 사각형으로 표시되어 전체 디자인이 손상될 수 있습니다.

Aspose.Slides for C++는 포함된 글꼴을 프로그래밍 방식으로 관리할 수 있는 강력한 API 세트를 제공합니다. [FontsManager](https://reference.aspose.com/slides/ko/cpp/aspose.slides/fontsmanager/)와 [FontData](https://reference.aspose.com/slides/ko/cpp/aspose.slides/fontdata/) 클래스를 사용하여 프레젠테이션 파일에 포함된 글꼴을 검사, 추가 또는 제거할 수 있습니다. 또한 [Compress](https://reference.aspose.com/slides/ko/cpp/aspose.slides.lowcode/compress/) 클래스를 사용하면 품질이나 모양에 영향을 주지 않으면서 글꼴 데이터를 압축하여 파일 크기를 최적화할 수 있습니다.

이 도구들을 통해 글꼴 포함을 완벽히 제어함으로써 플랫폼 간 일관된 타이포그래피를 유지하고 필요에 따라 파일 크기를 줄일 수 있습니다.

## **프레젠테이션에서 포함된 글꼴 가져오기**

Aspose.Slides for C++는 [FontsManager](https://reference.aspose.com/slides/ko/cpp/aspose.slides/fontsmanager/) 클래스를 통해 `GetEmbeddedFonts` 메서드를 제공하며, 이를 사용하면 PowerPoint 프레젠테이션에 포함된 글꼴 목록을 가져올 수 있습니다. 이는 글꼴 사용 현황을 감사하거나, 브랜드 가이드라인 준수를 확인하거나, 파일을 공유하기 전에 모든 필요한 글꼴이 올바르게 포함되었는지 검증할 때 유용합니다.

다음 C++ 코드 예제는 프레젠테이션 파일에서 포함된 글꼴을 가져오는 방법을 보여줍니다:

```cpp
// 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
auto presentation = MakeObject<Presentation>(u"embedded_fonts.pptx");

// Get all embedded fonts.
auto embeddedFonts = presentation->get_FontsManager()->GetEmbeddedFonts();

// Print names of the embedded fonts.
for (auto&& fontData : embeddedFonts)
{
    Console::WriteLine(fontData->get_FontName());
}

presentation->Dispose();
```

## **프레젠테이션에 포함된 글꼴 추가하기**

Aspose.Slides for C++는 [AddEmbeddedFont](https://reference.aspose.com/slides/ko/cpp/aspose.slides/fontsmanager/addembeddedfont/) 메서드를 사용하여 PowerPoint 프레젠테이션에 글꼴을 포함시킬 수 있으며, 이 메서드는 유연한 사용을 위해 두 개의 오버로드를 제공합니다. [EmbedFontCharacters](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/embedfontcharacters/) 열거형을 사용하여 포함할 글꼴 문자 수를 제어할 수 있습니다—예를 들어 사용된 문자만 포함하거나 전체 글꼴 세트를 포함하도록 선택할 수 있습니다. 이 기능은 프레젠테이션을 공유하거나 배포하기 전에 맞춤형 또는 비표준 글꼴이 모든 시스템에서 올바르게 표시되도록 보장하는 데 특히 유용합니다.

다음 C++ 코드는 프레젠테이션에서 사용된 모든 글꼴을 검사하고, 아직 포함되지 않은 글꼴을 포함시키는 예제입니다:

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

    // 글꼴이 이미 포함되어 있는지 확인합니다.
    bool isEmbeddedFont = Array<SharedPtr<IFontData>>::Exists(embeddedFonts, comparer);
    if (!isEmbeddedFont)
    {
        // 프레젠테이션에 글꼴을 포함시킵니다.
        presentation->get_FontsManager()->AddEmbeddedFont(fontData, EmbedFontCharacters::All);
    }

}

// 프레젠테이션을 디스크에 저장합니다.
presentation->Save(u"embedded_fonts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **프레젠테이션에서 포함된 글꼴 제거하기**

Aspose.Slides for C++는 [FontsManager](https://reference.aspose.com/slides/ko/cpp/aspose.slides/fontsmanager/) 클래스를 통해 `RemoveEmbeddedFont` 메서드를 제공하며, 이를 사용하면 PowerPoint 프레젠테이션에 포함된 특정 글꼴을 제거할 수 있습니다. 이는 포함된 글꼴이 더 이상 사용되지 않거나 필요하지 않을 때 전체 파일 크기를 줄이는 데 도움이 됩니다. 사용되지 않는 글꼴을 제거하면 성능이 향상되고 프레젠테이션에 필수 리소스만 포함되도록 할 수 있습니다.

다음 C++ 코드는 프레젠테이션에서 포함된 글꼴을 제거하는 방법을 보여줍니다:

```cpp
auto fontName = u"Calibri";

// 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
auto presentation = MakeObject<Presentation>(u"embedded_fonts.pptx");

// 모든 포함된 글꼴을 가져옵니다.
auto embeddedFonts = presentation->get_FontsManager()->GetEmbeddedFonts();

for (auto&& fontData : embeddedFonts)
{
    if (fontData->get_FontName().Equals(fontName))
    {
        // 포함된 글꼴을 제거합니다.
        presentation->get_FontsManager()->RemoveEmbeddedFont(fontData);

        break;
    }
}

presentation->Save(u"removed_font.ppt", SaveFormat::Ppt);
presentation->Dispose();
```

## **포함된 글꼴 압축하기**

Aspose.Slides for C++는 [Compress](https://reference.aspose.com/slides/ko/cpp/aspose.slides.lowcode/compress/) 클래스를 통해 `CompressEmbeddedFonts` 메서드를 제공하며, 이를 사용하면 포함된 글꼴 데이터를 최적화하여 프레젠테이션의 전체 파일 크기를 줄일 수 있습니다. 프레젠테이션에 크기가 큰 글꼴이나 여러 글꼴이 포함되어 있을 때 파일을 가볍게 유지하면서도 시각적 품질을 손상시키지 않도록 공유, 저장 또는 온라인 사용에 적합하게 만들 수 있습니다.

다음 C++ 코드는 PowerPoint 프레젠테이션에서 포함된 글꼴을 압축하는 방법을 보여줍니다:

```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");

Compress::CompressEmbeddedFonts(presentation);

presentation->Save(u"compressed_fonts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **FAQ**

**포함했음에도 불구하고 렌더링 시 특정 글꼴이 여전히 대체되는지 어떻게 확인할 수 있나요?**

글꼴 관리자에서 [substitution information](/slides/ko/cpp/font-substitution/)와 [fallback/substitution rules](/slides/ko/cpp/fallback-font/)를 확인하세요. 글꼴이 사용할 수 없거나 제한된 경우 대체 글꼴이 사용됩니다.

**Arial/Calibri와 같은 “시스템” 글꼴을 포함시키는 것이 가치가 있나요?**

대부분의 경우에는 필요하지 않습니다—이 글꼴들은 거의 항상 제공됩니다. 그러나 “슬림” 환경(예: Docker, 사전 설치된 글꼴이 없는 Linux 서버)에서 완전한 이식성을 위해 시스템 글꼴을 포함시키면 예상치 못한 대체 위험을 없앨 수 있습니다.
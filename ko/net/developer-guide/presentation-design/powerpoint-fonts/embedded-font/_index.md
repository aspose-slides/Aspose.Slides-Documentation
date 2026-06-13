---
title: .NET에서 프레젠테이션에 글꼴 포함
linktitle: 글꼴 포함
type: docs
weight: 40
url: /ko/net/embedded-font/
keywords:
- 글꼴 추가
- 글꼴 포함
- 글꼴 삽입
- 임베드된 글꼴 가져오기
- 임베드된 글꼴 추가
- 임베드된 글꼴 제거
- 임베드된 글꼴 압축
- PowerPoint
- OpenDocument
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET를 사용하여 PowerPoint 및 OpenDocument 프레젠테이션에 TrueType 글꼴을 포함시켜 모든 플랫폼에서 정확한 렌더링을 보장합니다."
---
## **소개**

**PowerPoint에 글꼴 포함**은 프레젠테이션이 다양한 시스템에서도 의도된 모양을 유지하도록 보장합니다. 독창적인 글꼴을 사용하든 표준 글꼴을 사용하든, 글꼴을 포함하면 텍스트와 레이아웃이 깨지는 것을 방지합니다.

작업에 창의성을 더하기 위해 서드파티 또는 비표준 글꼴을 사용했다면, 글꼴을 포함해야 할 이유가 더욱 많아집니다. 반대로(글꼴을 포함하지 않은 경우) 슬라이드의 텍스트나 숫자, 레이아웃, 스타일 등이 변경되거나 이해하기 어려운 사각형으로 나타날 수 있습니다.

임베드된 글꼴을 관리하려면 [FontsManager](https://reference.aspose.com/slides/ko/net/aspose.slides/fontsmanager/), [FontData](https://reference.aspose.com/slides/ko/net/aspose.slides/fontdata/), 및 [Compress](https://reference.aspose.com/slides/ko/net/aspose.slides.lowcode/compress/) 클래스를 활용하십시오.

## **임베드된 글꼴 가져오기 및 제거**

프레젠테이션에서 임베드된 글꼴을 손쉽게 가져오거나 제거하려면 [GetEmbeddedFonts](https://reference.aspose.com/slides/ko/net/aspose.slides/fontsmanager/getembeddedfonts) 및 [RemoveEmbeddedFont](https://reference.aspose.com/slides/ko/net/aspose.slides/fontsmanager/removeembeddedfont) 메서드를 사용하십시오.

다음 C# 코드에서는 프레젠테이션에서 임베드된 글꼴을 가져오고 제거하는 방법을 보여줍니다:

```c#
using (Presentation presentation = new Presentation("EmbeddedFonts.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // 임베드된 "FunSized"를 사용하는 텍스트 프레임이 포함된 슬라이드를 렌더링합니다
    using (IImage image = slide.GetImage(new Size(960, 720)))
    {
        image.Save("picture1_out.png", ImageFormat.Png);
    }

    IFontsManager fontsManager = presentation.FontsManager;

    IFontData[] embeddedFonts = fontsManager.GetEmbeddedFonts();

    // "Calibri" 글꼴을 찾습니다
    IFontData funSizedEmbeddedFont = Array.Find(embeddedFonts, delegate (IFontData data)
    {
        return data.FontName == "Calibri";
    });

    // "Calibri" 글꼴을 제거합니다
    fontsManager.RemoveEmbeddedFont(funSizedEmbeddedFont);

    // 프레젠테이션을 렌더링합니다; "Calibri" 글꼴이 기존 글꼴로 대체됩니다
    using (IImage image = slide.GetImage(new Size(960, 720)))
    {
        image.Save("picture2_out.png", ImageFormat.Png);
    }

    // 임베드된 "Calibri" 글꼴 없이 프레젠테이션을 디스크에 저장합니다
    presentation.Save("WithoutManageEmbeddedFonts_out.ppt", SaveFormat.Ppt);
}
```

## **임베드된 글꼴 추가**

[EmbedFontCharacters](https://reference.aspose.com/slides/ko/net/aspose.slides.export/embedfontcharacters/) 열거형과 [AddEmbeddedFont](https://reference.aspose.com/slides/ko/net/aspose.slides/fontsmanager/addembeddedfont/) 메서드의 두 오버로드를 사용하여 프레젠테이션에 글꼴을 포함할 선호하는 규칙을 선택할 수 있습니다. 다음 C# 코드에서는 프레젠테이션에 글꼴을 포함하고 추가하는 방법을 보여줍니다:

```c#
// 프레젠테이션을 로드합니다
Presentation presentation = new Presentation("Fonts.pptx");

IFontData[] allFonts = presentation.FontsManager.GetFonts();
IFontData[] embeddedFonts = presentation.FontsManager.GetEmbeddedFonts();
foreach (IFontData font in allFonts)
{
    if (!embeddedFonts.Contains(font))
    {
        presentation.FontsManager.AddEmbeddedFont(font, EmbedFontCharacters.All);
    }
}

// 프레젠테이션을 디스크에 저장합니다
presentation.Save("AddEmbeddedFont_out.pptx", SaveFormat.Pptx);
```

## **임베드된 글꼴 압축**

[CompressEmbeddedFonts](https://reference.aspose.com/slides/ko/net/aspose.slides.lowcode/compress/compressembeddedfonts/)을 사용하여 임베드된 글꼴을 압축함으로써 파일 크기를 최적화하십시오.

압축 예제 코드는 다음과 같습니다:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    Aspose.Slides.LowCode.Compress.CompressEmbeddedFonts(pres);
    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**프레젠테이션의 특정 글꼴이 임베드했음에도 불구하고 렌더링 시 여전히 대체되는지 어떻게 확인할 수 있나요?**

글꼴 관리자의 [substitution information](/slides/ko/net/font-substitution/)와 [fallback/substitution rules](/slides/ko/net/fallback-font/)를 확인하십시오. 글꼴이 없거나 제한된 경우 대체 글꼴이 사용됩니다.

**Arial/Calibri와 같은 "시스템" 글꼴을 포함할 가치가 있나요?**

보통은 필요 없습니다—대부분의 시스템에 이미 존재하기 때문입니다. 그러나 "얇은" 환경(예: Docker, 사전 설치된 글꼴이 없는 Linux 서버)에서 완전한 이식성을 위해 시스템 글꼴을 포함하면 예상치 못한 대체 위험을 없앨 수 있습니다.
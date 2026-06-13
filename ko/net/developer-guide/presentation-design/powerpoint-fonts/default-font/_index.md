---
title: .NET에서 기본 프레젠테이션 글꼴 지정
linktitle: 기본 글꼴
type: docs
weight: 30
url: /ko/net/default-font/
keywords:
- 기본 글꼴
- 일반 글꼴
- 보통 글꼴
- 아시아 글꼴
- PDF 내보내기
- XPS 내보내기
- 이미지 내보내기
- PowerPoint
- OpenDocument
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: ".NET용 Aspose.Slides에서 기본 글꼴을 설정하여 PowerPoint(PPT, PPTX) 및 OpenDocument(ODP)를 PDF, XPS 및 이미지로 올바르게 변환하도록 합니다."
---
## **개요**

Aspose.Slides에서는 프레젠테이션이 렌더링될 때 사용할 기본 글꼴을 지정할 수 있습니다. 이는 슬라이드 썸네일을 생성하거나 프레젠테이션을 PDF, XPS와 같은 형식으로 내보낼 때 유용합니다. 기본 글꼴은 프레젠테이션을 로드하기 전에 `LoadOptions`를 통해 구성합니다.

`DefaultRegularFont` 속성은 일반 텍스트의 기본 글꼴을 정의하고, `DefaultAsianFont`는 아시아어 텍스트의 기본 글꼴을 정의합니다. 이러한 옵션을 설정한 후에 프레젠테이션을 로드하고 지정된 글꼴로 렌더링할 수 있습니다.

## **프레젠테이션 렌더링을 위한 기본 폰트 사용**
Aspose.Slides를 사용하면 PDF, XPS 또는 썸네일에 대한 프레젠테이션 렌더링 기본 글꼴을 설정할 수 있습니다. 이 문서에서는 DefaultRegularFont과 DefaultAsianFont을 기본 글꼴로 정의하는 방법을 보여줍니다. Aspose.Slides for .NET API를 사용하여 외부 디렉터리에서 글꼴을 로드하는 단계는 다음과 같습니다:

1. LoadOptions의 인스턴스를 생성합니다.
2. DefaultRegularFont를 원하는 글꼴로 설정합니다. 다음 예제에서는 Wingdings을 사용했습니다.
3. DefaultAsianFont를 원하는 글꼴로 설정합니다. 아래 샘플에서도 Wingdings을 사용했습니다.
4. Presentation을 사용하고 로드 옵션을 설정하여 프레젠테이션을 로드합니다.
5. 이제 슬라이드 썸네일, PDF 및 XPS를 생성하여 결과를 확인합니다.

위 구현은 아래와 같습니다.

```c#
// 로드 옵션을 사용하여 기본 일반 글꼴 및 아시아어 글꼴을 지정합니다.
LoadOptions loadOptions = new LoadOptions(LoadFormat.Auto);
loadOptions.DefaultRegularFont = "Wingdings";
loadOptions.DefaultAsianFont = "Wingdings";

using (Presentation pptx = new Presentation("DefaultFonts.pptx", loadOptions))
{
    using (IImage image = pptx.Slides[0].GetImage(1, 1))
    {
        image.Save("DefaultFonts_out.png", ImageFormat.Png);
    }

    pptx.Save("DefaultFonts_out.pdf", SaveFormat.Pdf);
    pptx.Save("DefaultFonts_out.xps", SaveFormat.Xps);
}
```

## **FAQ**

**DefaultRegularFont와 DefaultAsianFont은 정확히 무엇에 영향을 미칩니까—내보내기만 해당인가요, 아니면 썸네일, PDF, XPS, HTML, SVG에도 적용되나요?**

이들은 지원되는 모든 출력 형식의 렌더링 파이프라인에 참여합니다. 여기에는 슬라이드 썸네일, [PDF](/slides/ko/net/convert-powerpoint-to-pdf/), [XPS](/slides/ko/net/convert-powerpoint-to-xps/), [래스터 이미지](/slides/ko/net/convert-powerpoint-to-png/), [HTML](/slides/ko/net/convert-powerpoint-to-html/), 그리고 [SVG](/slides/ko/net/render-a-slide-as-an-svg-image/)가 포함되며, Aspose.Slides는 이러한 대상에서 동일한 레이아웃 및 글리프 해석 로직을 사용합니다.

**단순히 PPTX를 열고 저장만 할 경우에도 기본 폰트가 적용되나요?**

아니요. 기본 폰트는 텍스트를 측정하고 그려야 할 때만 의미가 있습니다. 프레젠테이션을 그대로 열고 저장하는 경우 저장된 글꼴 실행이나 파일 구조가 변경되지 않으며, 기본 폰트는 렌더링이나 텍스트 재배치 작업이 수행될 때만 적용됩니다.

**내가 직접 만든 글꼴 폴더를 추가하거나 메모리에서 글꼴을 제공하면 기본 폰트를 선택할 때 고려되나요?**

예. [사용자 지정 글꼴 소스](/slides/ko/net/custom-font/)는 엔진이 사용할 수 있는 글꼴 패밀리와 글리프를 확장합니다. 기본 폰트와 모든 [대체 규칙](/slides/ko/net/fallback-font/)은 먼저 이러한 소스를 기준으로 해결되므로 서버나 컨테이너 환경에서 보다 신뢰할 수 있는 커버리지를 제공합니다.

**기본 폰트가 텍스트 메트릭(커닝, 어드밴스) 및 따라서 줄 바꿈과 래핑에 영향을 미치나요?**

예. 글꼴을 변경하면 글리프 메트릭이 바뀌어 렌더링 중 줄 바꿈, 래핑 및 페이지 나누기가 달라질 수 있습니다. 레이아웃 안정성을 위해 [원본 글꼴을 포함](/slides/ko/net/embedded-font/)하거나 메트릭적으로 호환되는 기본 및 대체 패밀리를 선택하십시오.

**프레젠테이션에 사용된 모든 글꼴이 포함되어 있다면 기본 폰트를 설정할 필요가 있나요?**

대부분의 경우 필요하지 않을 수 있습니다. [포함된 글꼴](/slides/ko/net/embedded-font/)이 이미 일관된 표시를 보장하기 때문입니다. 그러나 포함된 서브셋에 포함되지 않은 문자나 파일에 포함된 텍스트와 포함되지 않은 텍스트가 혼합된 경우를 대비해 기본 폰트는 안전망 역할을 합니다.
---
title: C++에서 기본 프레젠테이션 글꼴 지정
linktitle: 기본 글꼴
type: docs
weight: 30
url: /ko/cpp/default-font/
keywords:
- 기본 글꼴
- 일반 글꼴
- 보통 글꼴
- 아시아 글꼴
- PDF 내보내기
- XPS 내보내기
- 이미지 내보내기
- 파워포인트
- 오픈문서
- 프레젠테이션
- C++
- Aspose.Slides
description: "Aspose.Slides for C++에서 기본 글꼴을 설정하여 PowerPoint(PPT, PPTX) 및 OpenDocument(ODP)를 PDF, XPS 및 이미지로 올바르게 변환하도록 합니다."
---
## **개요**

Aspose.Slides는 프레젠테이션이 렌더링될 때 사용되는 기본 글꼴을 지정할 수 있게 합니다. 이는 슬라이드 썸네일을 생성하거나 프레젠테이션을 PDF 및 XPS와 같은 형식으로 내보낼 때 유용합니다. 기본 글꼴은 프레젠테이션이 로드되기 전에 `LoadOptions`를 통해 구성됩니다.

`set_DefaultRegularFont` 메서드는 일반 텍스트에 대한 기본 글꼴을 정의하고, `set_DefaultAsianFont`는 아시아 텍스트에 대한 기본 글꼴을 정의합니다. 이러한 옵션을 설정한 후에는 지정된 글꼴을 사용하여 프레젠테이션을 로드하고 렌더링할 수 있습니다.

## **프레젠테이션 렌더링을 위한 기본 글꼴 사용**
Aspose.Slides를 사용하면 PDF, XPS 또는 썸네일로 프레젠테이션을 렌더링할 때 기본 글꼴을 설정할 수 있습니다. 이 문서에서는 기본 글꼴로 사용할 DefaultRegular Font와 DefaultAsian Font를 정의하는 방법을 보여줍니다. Aspose.Slides for C++ API를 사용하여 외부 디렉터리에서 글꼴을 로드하는 단계는 다음과 같습니다:

1. LoadOptions의 인스턴스를 생성합니다.
1. DefaultRegularFont를 원하는 글꼴로 설정합니다. 다음 예에서는 Wingdings를 사용했습니다.
1. DefaultAsianFont를 원하는 글꼴로 설정합니다. 아래 샘플에서도 Wingdings를 사용했습니다.
1. Presentation을 사용하여 프레젠테이션을 로드하고 로드 옵션을 설정합니다.
1. 이제 슬라이드 썸네일, PDF 및 XPS를 생성하여 결과를 확인합니다.

위의 구현 예시는 아래에 나와 있습니다.

```cpp
// 로드 옵션을 사용하여 기본 일반 및 아시아 글꼴을 지정합니다
auto loadOptions = MakeObject<LoadOptions>(LoadFormat::Auto);
loadOptions->set_DefaultRegularFont(u"Wingdings");
loadOptions->set_DefaultAsianFont(u"Wingdings");

auto pptx = MakeObject<Presentation>(u"DefaultFonts.pptx", loadOptions);

auto image = pptx->get_Slide(0)->GetImage(1, 1);
image->Save(u"DefaultFonts_out.png", ImageFormat::Png);
image->Dispose();

pptx->Save(u"DefaultFonts_out.pdf", SaveFormat::Pdf);
pptx->Save(u"DefaultFonts_out.xps", SaveFormat::Xps);

pptx->Dispose();
```

## **자주 묻는 질문**

**DefaultRegularFont와 DefaultAsianFont는 정확히 무엇에 영향을 미칩니까—내보내기만, 아니면 썸네일, PDF, XPS, HTML 및 SVG에도 영향을 줍니까?**

그들은 모든 지원되는 출력에 대한 렌더링 파이프라인에 참여합니다. 여기에는 슬라이드 썸네일, [PDF](/slides/ko/cpp/convert-powerpoint-to-pdf/), [XPS](/slides/ko/cpp/convert-powerpoint-to-xps/), [래스터 이미지](/slides/ko/cpp/convert-powerpoint-to-png/), [HTML](/slides/ko/cpp/convert-powerpoint-to-html/), 및 [SVG](/slides/ko/cpp/render-a-slide-as-an-svg-image/)가 포함되며, Aspose.Slides는 이러한 대상에서 동일한 레이아웃 및 글리프 해결 로직을 사용하기 때문입니다.

**단순히 PPTX를 읽고 저장하는 경우(렌더링 없이) 기본 글꼴이 적용됩니까?**

아니요. 텍스트를 측정하고 그려야 할 때 기본 글꼴이 중요합니다. 프레젠테이션을 단순히 열고 저장하는 경우 저장된 글꼴 실행이나 파일 구조가 변경되지 않습니다. 기본 글꼴은 텍스트를 렌더링하거나 재배치하는 작업에서 적용됩니다.

**내가 직접 글꼴 폴더를 추가하거나 메모리에서 글꼴을 제공하면 기본 글꼴 선택 시 고려됩니까?**

예. [Custom font sources](/slides/ko/cpp/custom-font/)는 엔진이 사용할 수 있는 글꼴 패밀리와 글리프 카탈로그를 확장합니다. 기본 글꼴 및 모든 [fallback rules](/slides/ko/cpp/fallback-font/)는 먼저 이러한 소스를 기준으로 해결되므로 서버와 컨테이너에서 보다 안정적인 커버리지를 제공합니다.

**기본 글꼴이 텍스트 메트릭(커닝, 어드밴스) 및 따라서 줄 바꿈과 래핑에 영향을 줍니까?**

예. 글꼴을 변경하면 글리프 메트릭이 바뀌어 렌더링 중 줄 바꿈, 래핑 및 페이지 매김이 달라질 수 있습니다. 레이아웃 안정성을 위해 [embed the original fonts](/slides/ko/cpp/embedded-font/)를 사용하거나 메트릭적으로 호환되는 기본 및 대체 패밀리를 선택하십시오.

**프레젠테이션에 사용된 모든 글꼴이 임베드된 경우 기본 글꼴을 설정할 이유가 있습니까?**

대부분 경우 필요하지 않습니다. [embedded fonts](/slides/ko/cpp/embedded-font/)가 이미 일관된 표시를 보장하기 때문입니다. 그러나 기본 글꼴은 임베드된 서브셋에 포함되지 않은 문자나 파일이 임베드된 텍스트와 임베드되지 않은 텍스트를 혼합할 때 안전망 역할을 합니다.
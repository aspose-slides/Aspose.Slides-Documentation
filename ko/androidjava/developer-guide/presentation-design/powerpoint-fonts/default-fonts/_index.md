---
title: Android에서 기본 프레젠테이션 글꼴 지정
linktitle: 기본 글꼴
type: docs
weight: 30
url: /ko/androidjava/default-font/
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
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android에서 Java를 사용해 기본 글꼴을 설정하여 PowerPoint(PPT, PPTX) 및 OpenDocument(ODP)를 PDF, XPS 및 이미지로 올바르게 변환하도록 합니다."
---
## **개요**

Aspose.Slides에서는 프레젠테이션이 렌더링될 때 사용되는 기본 글꼴을 지정할 수 있습니다. 이는 슬라이드 썸네일을 생성하거나 프레젠테이션을 PDF 및 XPS와 같은 형식으로 내보낼 때 유용합니다. 기본 글꼴은 프레젠테이션을 로드하기 전에 `LoadOptions`를 통해 구성됩니다.

`setDefaultRegularFont` 메서드는 일반 텍스트의 기본 글꼴을 정의하고, `setDefaultAsianFont`는 아시아 텍스트의 기본 글꼴을 정의합니다. 이러한 옵션을 설정한 후에는 지정된 글꼴을 사용하여 프레젠테이션을 로드하고 렌더링할 수 있습니다.

## **프레젠테이션 렌더링을 위한 기본 글꼴 사용**
Aspose.Slides를 사용하면 프레젠테이션을 PDF, XPS 또는 썸네일로 렌더링할 때 기본 글꼴을 설정할 수 있습니다. 이 문서에서는 기본 글꼴로 사용할 DefaultRegular Font와 DefaultAsian Font를 정의하는 방법을 보여줍니다. 아래 단계에 따라 Aspose.Slides for Android를 Java API를 통해 사용하여 외부 디렉터리에서 글꼴을 로드하십시오:

1. [LoadOptions](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/LoadOptions)의 인스턴스를 생성합니다.
2. [Set the DefaultRegularFont](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/LoadOptions#setDefaultRegularFont-java.lang.String-)을 원하는 글꼴로 설정합니다. 다음 예제에서는 Wingdings를 사용했습니다.
3. [Set the DefaultAsianFont](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/LoadOptions#setDefaultAsianFont-java.lang.String-)을 원하는 글꼴로 설정합니다. 다음 샘플에서도 Wingdings를 사용했습니다.
4. Presentation을 사용하고 로드 옵션을 설정하여 프레젠테이션을 로드합니다.
5. 이제 슬라이드 썸네일, PDF 및 XPS를 생성하여 결과를 확인합니다.

위 구현은 아래에 제공됩니다.

```java
// 로드 옵션을 사용하여 기본 일반 및 아시아 글꼴을 정의합니다
LoadOptions loadOptions = new LoadOptions(LoadFormat.Auto);
loadOptions.setDefaultRegularFont("Wingdings");
loadOptions.setDefaultAsianFont("Wingdings");

// 프레젠테이션을 로드합니다
Presentation pres = new Presentation("DefaultFonts.pptx", loadOptions);
try {
    // 슬라이드 썸네일 생성
    IImage slideImage = pres.getSlides().get_Item(0).getImage(1, 1);
    try {
         // 이미지를 디스크에 저장합니다.
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }

    // PDF 생성
    pres.save("output_out.pdf", SaveFormat.Pdf);

    // XPS 생성
    pres.save("output_out.xps", SaveFormat.Xps);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**DefaultRegularFont와 DefaultAsianFont가 정확히 무엇에 영향을 미칩니까—내보내기만, 아니면 썸네일, PDF, XPS, HTML 및 SVG에도 영향을 줍니까?**

이들은 모든 지원되는 출력에 대한 렌더링 파이프라인에 참여합니다. 여기에는 슬라이드 썸네일, [PDF](/slides/ko/androidjava/convert-powerpoint-to-pdf/), [XPS](/slides/ko/androidjava/convert-powerpoint-to-xps/), [래스터 이미지](/slides/ko/androidjava/convert-powerpoint-to-png/), [HTML](/slides/ko/androidjava/convert-powerpoint-to-html/), 그리고 [SVG](/slides/ko/androidjava/render-a-slide-as-an-svg-image/)가 포함됩니다. 이는 Aspose.Slides가 이러한 대상에서 동일한 레이아웃 및 글리프 해석 로직을 사용하기 때문입니다.

**단순히 PPTX를 읽고 저장할 때(렌더링 없이) 기본 글꼴이 적용됩니까?**

아니요. 기본 글꼴은 텍스트를 측정하고 그려야 할 때만 영향을 미칩니다. 프레젠테이션을 그대로 열고 저장하는 경우 저장된 글꼴 실행이나 파일 구조가 변경되지 않습니다. 기본 글꼴은 텍스트를 렌더링하거나 재배치하는 작업에서 적용됩니다.

**내가 직접 만든 글꼴 폴더를 추가하거나 메모리에서 글꼴을 제공하면 기본 글꼴을 선택할 때 고려됩니까?**

예. [Custom font sources](/slides/ko/androidjava/custom-font/)는 엔진이 사용할 수 있는 글꼴 패밀리와 글리프 카탈로그를 확장합니다. 기본 글꼴 및 모든 [fallback rules](/slides/ko/androidjava/fallback-font/)는 먼저 이러한 소스를 참조하여 서버 및 컨테이너에서 보다 신뢰할 수 있는 커버리지를 제공합니다.

**기본 글꼴이 텍스트 메트릭(커닝, 전진값)에 영향을 주어 줄 바꿈 및 래핑에 영향을 미칩니까?**

예. 글꼴을 변경하면 글리프 메트릭이 바뀌어 렌더링 중에 줄 바꿈, 래핑 및 페이지 매김이 변할 수 있습니다. 레이아웃 안정성을 위해서는 [embed the original fonts](/slides/ko/androidjava/embedded-font/)를 사용하거나 메트릭적으로 호환되는 기본 및 대체 패밀리를 선택하십시오.

**프레젠테이션에 사용된 모든 글꼴이 임베드되어 있다면 기본 글꼴을 설정할 필요가 있습니까?**

대부분의 경우 필요하지 않습니다. [embedded fonts](/slides/ko/androidjava/embedded-font/)가 이미 일관된 표시를 보장하기 때문입니다. 그러나 기본 글꼴은 임베드된 서브셋에 포함되지 않은 문자나 파일에 임베드된 텍스트와 임베드되지 않은 텍스트가 혼합된 경우 안전망 역할을 합니다.
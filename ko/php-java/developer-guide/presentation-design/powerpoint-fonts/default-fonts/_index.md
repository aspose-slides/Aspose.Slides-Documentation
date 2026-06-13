---
title: PHP에서 기본 프레젠테이션 폰트 지정
linktitle: 기본 폰트
type: docs
weight: 30
url: /ko/php-java/default-font/
keywords:
- 기본 폰트
- 일반 폰트
- 표준 폰트
- 아시아 폰트
- PDF 내보내기
- XPS 내보내기
- 이미지 내보내기
- PowerPoint
- OpenDocument
- 프레젠테이션
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java에서 기본 폰트를 설정하여 PowerPoint(PPT, PPTX) 및 OpenDocument(ODP)를 PDF, XPS 및 이미지로 올바르게 변환하도록 합니다."
---
## **개요**

Aspose.Slides는 프레젠테이션이 렌더링될 때 사용되는 기본 폰트를 지정할 수 있게 해줍니다. 이는 슬라이드 썸네일을 생성하거나 프레젠테이션을 PDF·XPS와 같은 형식으로 내보낼 때 유용합니다. 기본 폰트는 프레젠테이션을 로드하기 전에 `LoadOptions`를 통해 구성됩니다.

`setDefaultRegularFont` 메서드는 일반 텍스트의 기본 폰트를 정의하고, `setDefaultAsianFont` 메서드는 아시아 텍스트의 기본 폰트를 정의합니다. 이러한 옵션을 설정한 후에 프레젠테이션을 로드하고 지정된 폰트로 렌더링할 수 있습니다.

## **프레젠테이션 렌더링을 위한 기본 폰트 사용**
Aspose.Slides를 사용하면 PDF, XPS 또는 썸네일로 프레젠테이션을 변환할 때 기본 폰트를 설정할 수 있습니다. 이 문서에서는 DefaultRegularFont와 DefaultAsianFont를 기본 폰트로 정의하는 방법을 보여줍니다. 다음 단계를 따라 Aspose.Slides for PHP via Java API를 사용해 외부 디렉터리에서 폰트를 로드하세요.

1. [LoadOptions](https://reference.aspose.com/slides/ko/php-java/aspose.slides/LoadOptions)의 인스턴스를 생성합니다.
2. [Set the DefaultRegularFont](https://reference.aspose.com/slides/ko/php-java/aspose.slides/LoadOptions#setDefaultRegularFont-java.lang.String-)을 원하는 폰트로 설정합니다. 아래 예시에서는 Wingdings을 사용했습니다.
3. [Set the DefaultAsianFont](https://reference.aspose.com/slides/ko/php-java/aspose.slides/LoadOptions#setDefaultAsianFont-java.lang.String-)을 원하는 폰트로 설정합니다. 아래 샘플에서도 Wingdings을 사용했습니다.
4. Presentation을 사용해 프레젠테이션을 로드하고 로드 옵션을 적용합니다.
5. 이제 슬라이드 썸네일, PDF 및 XPS를 생성하여 결과를 확인합니다.

위 구현 예시는 아래에 나와 있습니다.

```php
  # 기본 로드 옵션을 사용하여 기본 일반 및 아시아 폰트를 정의합니다
  $loadOptions = new LoadOptions(LoadFormat::Auto);
  $loadOptions->setDefaultRegularFont("Wingdings");
  $loadOptions->setDefaultAsianFont("Wingdings");
  # 프레젠테이션을 로드합니다
  $pres = new Presentation("DefaultFonts.pptx", $loadOptions);
  try {
    # 슬라이드 썸네일을 생성합니다
    $slideImage = $pres->getSlides()->get_Item(0)->getImage(1, 1);
    try {
      # 이미지를 디스크에 저장합니다.
      $slideImage->save("output.png", ImageFormat::Png);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
    # PDF를 생성합니다
    $pres->save("output_out.pdf", SaveFormat::Pdf);
    # XPS를 생성합니다
    $pres->save("output_out.xps", SaveFormat::Xps);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**DefaultRegularFont와 DefaultAsianFont는 정확히 무엇에 영향을 미칩니까—내보내기만 대상인가요, 아니면 썸네일, PDF, XPS, HTML, SVG도 포함되나요?**

이들은 지원되는 모든 출력 형식의 렌더링 파이프라인에 참여합니다. 여기에는 슬라이드 썸네일, [PDF](/slides/ko/php-java/convert-powerpoint-to-pdf/), [XPS](/slides/ko/php-java/convert-powerpoint-to-xps/), [래스터 이미지](/slides/ko/php-java/convert-powerpoint-to-png/), [HTML](/slides/ko/php-java/convert-powerpoint-to-html/), 그리고 [SVG](/slides/ko/php-java/render-a-slide-as-an-svg-image/)가 포함되며, Aspose.Slides는 이러한 대상에서 동일한 레이아웃 및 글리프 해석 로직을 사용합니다.

**렌더링 없이 PPTX를 단순히 읽고 저장하는 경우에도 기본 폰트가 적용되나요?**

아니요. 기본 폰트는 텍스트를 측정하고 그려야 할 때만 의미가 있습니다. 프레젠테이션을 그대로 열고 저장하는 경우 저장된 폰트 실행이나 파일 구조가 변경되지 않으므로 기본 폰트가 적용되지 않습니다. 기본 폰트는 렌더링이나 텍스트 재배치와 같은 작업에서 작동합니다.

**내가 직접 폰트 폴더를 추가하거나 메모리에서 폰트를 공급하면 기본 폰트를 선택할 때 고려되나요?**

네. [Custom font sources](/slides/ko/php-java/custom-font/)를 사용하면 엔진이 사용할 수 있는 폰트 패밀리와 글리프 카탈로그가 확장됩니다. 기본 폰트와 모든 [fallback rules](/slides/ko/php-java/fallback-font/)는 먼저 이러한 소스를 참조하므로 서버나 컨테이너 환경에서 보다 안정적인 커버리지를 제공합니다.

**기본 폰트가 텍스트 메트릭(커닝, 어드밴스)에도 영향을 미쳐 줄바꿈과 래핑에 변화를 일으키나요?**

네. 폰트를 변경하면 글리프 메트릭이 바뀌어 렌더링 중 줄바꿈, 래핑 및 페이지 구성이 달라질 수 있습니다. 레이아웃 안정성을 위해서는 [embed the original fonts](/slides/ko/php-java/embedded-font/)을 사용하거나 메트릭적으로 호환되는 기본 및 대체 폰트 패밀리를 선택하세요.

**프레젠테이션에 사용된 모든 폰트가 이미 임베드되어 있다면 기본 폰트를 설정할 필요가 있나요?**

대부분 경우 필요하지 않습니다. [Embedded fonts](/slides/ko/php-java/embedded-font/)가 이미 일관된 표시를 보장하기 때문입니다. 하지만 임베드되지 않은 문자나 파일에 임베드와 비임베드 텍스트가 혼합된 경우를 대비해 기본 폰트는 여전히 안전망 역할을 합니다.
---
title: "차이점 이해하기: PPT와 PPTX"
linktitle: "PPT와 PPTX"
type: docs
weight: 10
url: /ko/php-java/ppt-vs-pptx/
keywords:
- PPT와 PPTX
- PPT 또는 PPTX
- 레거시 형식
- 현대 형식
- 바이너리 형식
- 현대 표준
- PowerPoint
- 프레젠테이션
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java를 사용하여 PowerPoint의 PPT와 PPTX를 비교하고, 형식 차이점, 장점, 호환성 및 변환 팁을 살펴봅니다."
---
## **개요**

이 문서에서는 PPT와 PPTX 형식의 차이점을 설명합니다. PPT는 PowerPoint 97–2003에서 사용된 레거시 이진 형식으로 설명하고, PPTX는 보다 유연성을 제공하고 프레젠테이션 기능 확장에 더 적합한 최신 Office Open XML 기반 형식으로 소개됩니다. 또한 이 문서는 호환성 고려 사항을 포함한 두 형식 간 변환의 주요 사항을 개요하고 Aspose.Slides를 사용하여 이러한 변환을 수행하는 방법을 보여줍니다. 일반적으로 가능한 경우 PPTX를 사용하는 것이 권장됩니다.

## **PPT란?**
[**PPT**](https://docs.fileformat.com/presentation/ppt/)은 바이너리 파일 형식이며, 특별한 도구 없이는 내용을 볼 수 없습니다. 최초 PowerPoint 97-2003 버전은 PPT 파일 형식을 사용했지만, 확장성이 제한적입니다.

## **PPTX란?**
[**PPTX**](https://docs.fileformat.com/presentation/pptx/)은 Office Open XML(ISO 29500:2008-2016, ECMA-376) 표준을 기반으로 하는 새로운 프레젠테이션 파일 형식입니다. PPTX는 XML 및 미디어 파일들의 압축된 집합입니다. PPTX 형식은 쉽게 확장할 수 있습니다. 예를 들어, 새로운 차트 유형이나 도형 유형을 지원하도록 추가하는 것이 매 새로운 PowerPoint 버전마다 PPTX 형식을 변경하지 않아도 쉽게 할 수 있습니다. PPTX 형식은 PowerPoint 2007부터 사용됩니다.

## **PPT와 PPTX**
PPTX가 훨씬 더 광범위한 기능을 제공함에도 불구하고, PPT는 여전히 많이 사용됩니다. PPT를 PPTX로, 그리고 그 반대로 변환할 필요성이 크게 요구됩니다.

하지만 기존 PPT와 새로운 PPTX 형식 간 변환은 다른 Microsoft Office 형식 중 가장 복잡한 과제입니다. PPT 형식의 사양은 공개되어 있지만 작업하기가 어렵습니다. PowerPoint는 PPT 파일에 특수 파트(MetroBlob)를 생성하여 PPTX에서 지원하지만 PPT 형식에서는 지원되지 않아 오래된 PowerPoint 버전에서 표시되지 않는 정보를 저장할 수 있습니다. 이러한 정보는 최신 PowerPoint 버전에서 PPT 파일을 열거나 PPTX 형식으로 변환할 때 복원될 수 있습니다.

Aspose.Slides는 모든 프레젠테이션 형식을 다룰 수 있는 공통 API를 제공합니다. 이를 통해 PPT를 PPTX로, PPTX를 PPT로 아주 간단하게 변환할 수 있습니다. Aspose.Slides는 PPT를 PPTX로 변환하는 것을 완벽히 지원하며, 일부 제한 사항이 있지만 PPTX를 PPT로 변환하는 것도 지원합니다. 가능한 경우 PPTX 형식을 사용할 것을 권장합니다.

{{% alert color="primary" %}} 
온라인 [**Aspose.Slides Conversion app**](https://products.aspose.app/slides/ko/conversion/)을 사용하여 PPT를 PPTX로, PPTX를 PPT로 변환하는 품질을 확인하십시오.
{{% /alert %}} 

```php
  # PPT 파일을 나타내는 Presentation 객체를 인스턴스화합니다
  $pres = new Presentation("PPTtoPPTX.ppt");
  try {
    # PPT 프레젠테이션을 PPTX 형식으로 저장합니다
    $pres->save("PPTtoPPTX_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="primary" %}} 
자세히 읽기 [**프레젠테이션 PPT를 PPTX로 변환하는 방법**.](/slides/ko/php-java/convert-ppt-to-pptx/)
{{% /alert %}} 

## **FAQ**

**오류 없이 열리는 경우에도 기존 PPT 프레젠테이션을 유지할 필요가 있나요?**

프레젠테이션이 안정적으로 열리고 협업이나 최신 기능이 필요하지 않다면 PPT 형태로 유지해도 됩니다. 그러나 향후 호환성과 확장성을 위해서는 [convert to PPTX](/slides/ko/php-java/convert-ppt-to-pptx/)하는 것이 좋습니다. 이 형식은 개방형 OOXML 표준을 기반으로 하며 최신 도구에서 보다 쉽게 지원됩니다.

**먼저 PPTX로 변환해야 할 중요한 파일은 어떻게 결정하나요?**

먼저 변환해야 할 프레젠테이션은 다음과 같습니다: 여러 사람이 편집한 경우; 복잡한 [charts](/slides/ko/php-java/create-chart/)/[shapes](/slides/ko/php-java/shape-manipulations/)를 포함한 경우; 외부 커뮤니케이션에 사용되는 경우; 또는 [opened](/slides/ko/php-java/open-presentation/) 시 경고가 발생하는 경우.

**PPT를 PPTX로 및 다시 PPT로 변환할 때 비밀번호 보호가 유지되나요?**

비밀번호가 있는 경우, 올바른 변환과 사용 중인 도구가 암호화 지원을 제공할 때만 유지됩니다. 보다 신뢰할 수 있는 방법은 [remove protection](/slides/ko/php-java/password-protected-presentation/), [convert](/slides/ko/php-java/convert-ppt-to-pptx/)한 뒤 보안 정책에 따라 보호를 다시 적용하는 것입니다.

**PPTX를 PPT로 다시 변환할 때 일부 효과가 사라지거나 단순화되는 이유는 무엇인가요?**

PPT는 일부 최신 객체/속성을 지원하지 않기 때문입니다. PowerPoint와 도구는 이러한 정보를 특수 블록에 "trace" 형태로 저장하여 나중에 복원할 수 있게 하지만, 오래된 PowerPoint 버전에서는 이를 렌더링하지 못합니다.
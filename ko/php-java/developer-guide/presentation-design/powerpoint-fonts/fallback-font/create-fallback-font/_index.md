---
title: PHP에서 프레젠테이션용 대체 글꼴 지정
linktitle: 대체 글꼴
type: docs
weight: 10
url: /ko/php-java/create-fallback-font/
keywords:
- 대체 글꼴
- 대체 규칙
- 글꼴 적용
- 글꼴 교체
- 유니코드 범위
- 누락된 글리프
- 올바른 글리프
- PowerPoint
- OpenDocument
- 프레젠테이션
- PHP
- Aspose.Slides
description: "Java를 통해 PHP용 Aspose.Slides를 마스터하고 PPT, PPTX 및 ODP 파일에 대체 글꼴을 설정하여 모든 장치와 OS에서 일관된 텍스트 표시를 보장합니다."
---
## **개요**

Aspose.Slides를 사용하면 프레젠테이션 렌더링 및 내보내기 작업에 대한 대체 글꼴을 지정할 수 있습니다. 기본 글꼴에 특정 문자에 대한 글리프가 포함되지 않은 경우 대체 글꼴이 사용됩니다.

대체 동작은 대체 규칙을 통해 구성됩니다. 각 규칙은 필요한 글리프를 포함할 수 있는 하나 이상의 글꼴과 유니코드 범위를 연결합니다. 다양한 문자 범위에 대한 규칙을 정의하고, 기존 규칙에서 대체 글꼴을 추가하거나 제거하며, 여러 규칙을 대체 글꼴 규칙 컬렉션에 정리할 수 있습니다.

대체 규칙은 런타임 렌더링 설정이며, 프레젠테이션 파일 자체를 변경하지 않으며 PPTX 파일 내에 저장되지 않습니다.

## **대체 규칙**

Aspose.Slides는 대체 글꼴을 적용하기 위한 규칙을 지정하는 [FontFallBackRule](https://reference.aspose.com/slides/ko/php-java/aspose.slides/FontFallBackRule) 클래스를 지원합니다. [FontFallBackRule](https://reference.aspose.com/slides/ko/php-java/aspose.slides/FontFallBackRule) 클래스는 누락된 글리프를 검색하는 데 사용되는 지정된 유니코드 범위와 적절한 글리프를 포함할 수 있는 글꼴 목록 간의 연결을 나타냅니다:

```php
  $startUnicodeIndex = 0xb80;
  $endUnicodeIndex = 0xbff;
  $firstRule = new FontFallBackRule($startUnicodeIndex, $endUnicodeIndex, "Vijaya");
  $secondRule = new FontFallBackRule(0x3040, 0x309f, "MS Mincho, MS Gothic");
  # 다양한 방법을 사용하여 글꼴 목록을 추가할 수 있습니다:
  $fontNames = array("Segoe UI Emoji, Segoe UI Symbol", "Arial" );
  $thirdRule = new FontFallBackRule(0x1f300, 0x1f64f, $fontNames);
```

기존 [FontFallBackRule](https://reference.aspose.com/slides/ko/php-java/aspose.slides/FontFallBackRule) 객체에 대체 글꼴을 [remove](https://reference.aspose.com/slides/ko/php-java/aspose.slides/fontfallbackrule/remove/) 하거나 [addFallBackFonts](https://reference.aspose.com/slides/ko/php-java/aspose.slides/fontfallbackrule/addfallbackfonts/) 를 추가할 수도 있습니다.

[FontFallBackRulesCollection](https://reference.aspose.com/slides/ko/php-java/aspose.slides/FontFallBackRulesCollection)은 여러 유니코드 범위에 대한 대체 글꼴 교체 규칙을 지정해야 할 때 [FontFallBackRule](https://reference.aspose.com/slides/ko/php-java/aspose.slides/FontFallBackRule) 객체 목록을 구성하는 데 사용할 수 있습니다.

{{% alert color="primary" title="See also" %}} 
- [대체 글꼴 컬렉션 만들기](/slides/ko/php-java/create-fallback-fonts-collection/)
{{% /alert %}}

## **FAQ**

**대체 글꼴, 글꼴 대체 및 글꼴 포함의 차이점은 무엇입니까?**

대체 글꼴은 기본 글꼴에 없는 문자에만 사용됩니다. [Font substitution](/slides/ko/php-java/font-substitution/)은 지정된 전체 글꼴을 다른 글꼴로 교체합니다. [Font embedding](/slides/ko/php-java/embedded-font/)은 글꼴을 출력 파일에 포함시켜 수신자가 의도한 대로 텍스트를 볼 수 있도록 합니다.

**대체 글꼴은 PDF, PNG 또는 SVG와 같은 내보내기 시에도 적용되나요, 아니면 화면 렌더링에만 적용되나요?**

예. 대체는 문자를 그려야 하지만 원본 글꼴에 존재하지 않는 경우 모든 [rendering and export operations](/slides/ko/php-java/convert-presentation/)에 영향을 줍니다.

**대체 설정을 구성하면 프레젠테이션 파일 자체가 변경되고, 설정이 향후 열기에도 유지됩니까?**

아니요. 대체 규칙은 코드 내 런타임 렌더링 설정이며, .pptx 내부에 저장되지 않아 PowerPoint에 표시되지 않습니다.

**운영 체제(Windows/Linux/macOS)와 글꼴 디렉터리 설정이 대체 선택에 영향을 줍니까?**

예. 엔진은 사용 가능한 시스템 폴더와 제공한 [additional paths](/slides/ko/php-java/custom-font/)에서 글꼴을 찾습니다. 글꼴이 실제로 존재하지 않으면 해당 글꼴을 참조하는 규칙은 적용될 수 없습니다.

**대체가 WordArt, SmartArt 및 차트에도 적용됩니까?**

예. 이러한 개체에 텍스트가 포함될 때 동일한 글리프 대체 메커니즘이 적용되어 누락된 문자를 렌더링합니다.
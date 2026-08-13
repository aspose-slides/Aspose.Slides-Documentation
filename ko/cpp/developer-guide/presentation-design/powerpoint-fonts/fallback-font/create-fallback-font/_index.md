---
title: C++ 프레젠테이션용 대체 폰트 지정
linktitle: 대체 폰트
type: docs
weight: 10
url: /ko/cpp/create-fallback-font/
keywords:
- 대체 폰트
- 대체 규칙
- 폰트 적용
- 폰트 교체
- Unicode 범위
- 누락된 글리프
- 올바른 글리프
- PowerPoint
- OpenDocument
- 프레젠테이션
- C++
- Aspose.Slides
description: "C++용 Aspose.Slides를 마스터하여 PPT, PPTX 및 ODP 파일에 대체 폰트를 설정하고, 모든 장치와 OS에서 일관된 텍스트 표시를 보장합니다."
---
## **개요**

Aspose.Slides에서는 프레젠테이션 렌더링 및 내보내기 작업에 대한 대체 폰트를 지정할 수 있습니다. 대체 폰트는 기본 폰트에 특정 문자에 대한 글리프가 없을 때 사용됩니다.

대체 동작은 대체 규칙을 통해 구성됩니다. 각 규칙은 Unicode 범위와 해당 범위에 필요한 글리프를 포함할 수 있는 하나 이상의 폰트를 연결합니다. 다양한 문자 범위에 대한 규칙을 정의하고, 기존 규칙에서 대체 폰트를 추가하거나 제거하며, 여러 규칙을 대체 폰트 규칙 컬렉션에 정리할 수 있습니다.

대체 규칙은 런타임 렌더링 설정이며, 프레젠테이션 파일 자체를 수정하지 않고 PPTX 파일에 저장되지 않습니다.

## **대체 규칙**

Aspose.Slides는 대체 폰트를 적용하기 위한 규칙을 지정하는 [IFontFallBackRule](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ifontfallbackrule/) 인터페이스와 [FontFallBackRule](https://reference.aspose.com/slides/ko/cpp/aspose.slides/fontfallbackrule/) 클래스를 지원합니다. [FontFallBackRule](https://reference.aspose.com/slides/ko/cpp/aspose.slides/fontfallbackrule/) 클래스는 누락된 글리프를 검색하는 데 사용되는 지정된 Unicode 범위와 해당 범위에 적절한 글리프를 포함할 수 있는 폰트 목록 간의 연결을 나타냅니다:

``` cpp
#include <DOM/Fonts/FontFallBackRule.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace System;

uint32_t startUnicodeIndex = 0x0B80;
uint32_t endUnicodeIndex = 0x0BFF;

auto firstRule = MakeObject<FontFallBackRule>(startUnicodeIndex, endUnicodeIndex, u"Vijaya");
auto secondRule = MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x3040), static_cast<uint32_t>(0x309F), u"MS Mincho, MS Gothic");

// Using multiple ways you can add fonts list:
auto fontNames = MakeArray<String>({ u"Segoe UI Emoji, Segoe UI Symbol", u"Arial" });

auto thirdRule = MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x1F300), static_cast<uint32_t>(0x1F64F), fontNames);
```

기존 [FontFallBackRule](https://reference.aspose.com/slides/ko/cpp/aspose.slides/fontfallbackrule/) 객체에 대체 폰트를 [Remove()](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ifontfallbackrule/remove/) 하거나 [AddFallBackFonts()](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ifontfallbackrule/addfallbackfonts/) 로 추가할 수도 있습니다.

여러 Unicode 범위에 대한 대체 폰트 교체 규칙을 지정해야 할 경우, [FontFallBackRulesCollection](https://reference.aspose.com/slides/ko/cpp/aspose.slides/fontfallbackrulescollection/)을 사용하여 [FontFallBackRule](https://reference.aspose.com/slides/ko/cpp/aspose.slides/fontfallbackrule/) 객체 목록을 정리할 수 있습니다.

{{% alert color="info" title="또 보기" %}} 
- [대체 폰트 컬렉션 만들기](/slides/ko/cpp/create-fallback-fonts-collection/)
{{% /alert %}}

## **FAQ**

### 대체 폰트, 폰트 대체 및 폰트 포함의 차이점은 무엇인가요?

대체 폰트는 기본 폰트에 없는 문자에만 사용됩니다. [Font substitution](/slides/ko/cpp/font-substitution/)은 지정된 전체 폰트를 다른 폰트로 교체합니다. [Font embedding](/slides/ko/cpp/embedded-font/)은 폰트를 출력 파일에 포함시켜 수신자가 의도된 대로 텍스트를 볼 수 있게 합니다.

### PDF, PNG, SVG 등으로 내보낼 때 대체 폰트가 적용되나요, 아니면 화면 렌더링에만 적용되나요?

예. 대체 폰트는 소스 폰트에 문자가 없지만 그려야 하는 모든 [렌더링 및 내보내기 작업](/slides/ko/cpp/convert-presentation/)에 영향을 줍니다.

### 대체 폰트를 구성하면 프레젠테이션 파일 자체가 변경되고, 설정이 이후 열기에도 지속되나요?

아니요. 대체 규칙은 코드 내 런타임 렌더링 설정이며, .pptx 파일에 저장되지 않아 PowerPoint에 나타나지 않습니다.

### 운영 체제(Windows/Linux/macOS)와 폰트 디렉터리 설정이 대체 폰트 선택에 영향을 주나요?

예. 엔진은 사용 가능한 시스템 폴더와 사용자가 제공한 [추가 경로](/slides/ko/cpp/custom-font/)에서 폰트를 찾습니다. 폰트가 실제로 존재하지 않으면 해당 폰트를 참조하는 규칙은 적용될 수 없습니다.

### WordArt, SmartArt, 차트에서도 대체 폰트가 적용되나요?

예. 이러한 객체에 텍스트가 포함된 경우 동일한 글리프 교체 메커니즘이 작동하여 누락된 문자를 렌더링합니다.
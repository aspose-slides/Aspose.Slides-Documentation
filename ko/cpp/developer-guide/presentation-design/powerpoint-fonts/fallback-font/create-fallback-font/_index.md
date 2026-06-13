---
title: C++에서 프레젠테이션용 대체 글꼴 지정
linktitle: 대체 글꼴
type: docs
weight: 10
url: /ko/cpp/create-fallback-font/
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
- C++
- Aspose.Slides
description: "C++용 Aspose.Slides를 마스터하여 PPT, PPTX 및 ODP 파일에 대체 글꼴을 설정하고 모든 장치나 OS에서 일관된 텍스트 표시를 보장합니다."
---
## **개요**

Aspose.Slides를 사용하면 프레젠테이션 렌더링 및 내보내기 작업에 대한 대체 글꼴을 지정할 수 있습니다. 대체 글꼴은 기본 글꼴에 특정 문자에 대한 글리프가 없을 때 사용됩니다.

대체 동작은 대체 규칙을 통해 구성됩니다. 각 규칙은 필요한 글리프를 포함할 수 있는 하나 이상의 글꼴과 유니코드 범위를 연결합니다. 서로 다른 문자 범위에 대한 규칙을 정의하고, 기존 규칙에서 대체 글꼴을 추가하거나 제거하며, 여러 규칙을 대체 글꼴 규칙 컬렉션에 정리할 수 있습니다.

대체 규칙은 런타임 렌더링 설정이며, 프레젠테이션 파일 자체를 수정하지 않고 PPTX 파일에 저장되지 않습니다.

## **대체 글꼴 규칙**

Aspose.Slides는 대체 글꼴을 적용하기 위한 규칙을 지정하는 [IFontFallBackRule](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ifontfallbackrule/) 인터페이스와 [FontFallBackRule](https://reference.aspose.com/slides/ko/cpp/aspose.slides/fontfallbackrule/) 클래스를 지원합니다. [FontFallBackRule](https://reference.aspose.com/slides/ko/cpp/aspose.slides/fontfallbackrule/) 클래스는 누락된 글리프를 검색하는 데 사용되는 지정된 유니코드 범위와 해당 글리프를 포함할 수 있는 글꼴 목록 사이의 연관을 나타냅니다:

``` cpp
uint32_t startUnicodeIndex = 0x0B80;
uint32_t endUnicodeIndex = 0x0BFF;

auto firstRule = MakeObject<FontFallBackRule>(startUnicodeIndex, endUnicodeIndex, u"Vijaya");
auto secondRule = MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x3040), static_cast<uint32_t>(0x309F), u"MS Mincho, MS Gothic");

// 여러 방법을 사용하여 글꼴 목록을 추가할 수 있습니다:
auto fontNames = MakeArray<String>({ u"Segoe UI Emoji, Segoe UI Symbol", u"Arial" });

auto thirdRule = MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x1F300), static_cast<uint32_t>(0x1F64F), fontNames);
```

기존 [FontFallBackRule](https://reference.aspose.com/slides/ko/cpp/aspose.slides/fontfallbackrule/) 객체에 대체 글꼴을 [Remove()](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ifontfallbackrule/remove/) 하거나 [AddFallBackFonts()](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ifontfallbackrule/addfallbackfonts/) 추가하는 것도 가능합니다.

[FontFallBackRulesCollection](https://reference.aspose.com/slides/ko/cpp/aspose.slides/fontfallbackrulescollection/)은 여러 유니코드 범위에 대한 대체 글꼴 교체 규칙을 지정해야 할 때 [FontFallBackRule](https://reference.aspose.com/slides/ko/cpp/aspose.slides/fontfallbackrule/) 객체 목록을 정리하는 데 사용할 수 있습니다.

{{% alert color="primary" title="See also" %}} 
- [대체 글꼴 컬렉션 만들기](/slides/ko/cpp/create-fallback-fonts-collection/)
{{% /alert %}}

## **자주 묻는 질문**

**대체 글꼴, 글꼴 대체 및 글꼴 포함의 차이점은 무엇입니까?**

대체 글꼴은 기본 글꼴에 없는 문자에만 사용됩니다. [Font substitution](/slides/ko/cpp/font-substitution/)은 지정된 전체 글꼴을 다른 글꼴로 교체합니다. [Font embedding](/slides/ko/cpp/embedded-font/)은 글꼴을 출력 파일에 포함시켜 수신자가 텍스트를 의도대로 볼 수 있도록 합니다.

**PDF, PNG 또는 SVG와 같은 내보내기 시에도 대체 글꼴이 적용되나요, 아니면 화면 렌더링에만 적용되나요?**

예. 대체는 문자가 소스 글꼴에 없지만 그려져야 하는 모든 [rendering and export operations](/slides/ko/cpp/convert-presentation/)에 영향을 줍니다.

**대체 설정을 구성하면 프레젠테이션 파일 자체가 변경되며, 이 설정이 이후 열 때에도 유지되나요?**

아니요. 대체 규칙은 코드에서 실행 시 적용되는 렌더링 설정이며, .pptx 파일에 저장되지 않아 PowerPoint에 나타나지 않습니다.

**운영 체제(Windows/Linux/macOS)와 글꼴 디렉터리 설정이 대체 글꼴 선택에 영향을 줍니까?**

예. 엔진은 사용 가능한 시스템 폴더와 제공한 [additional paths](/slides/ko/cpp/custom-font/)에서 글꼴을 검색합니다. 글꼴이 실제로 존재하지 않으면 해당 글꼴을 참조하는 규칙은 적용되지 않습니다.

**WordArt, SmartArt 및 차트에서도 대체가 적용되나요?**

예. 이러한 객체에 텍스트가 포함된 경우 동일한 글리프 대체 메커니즘이 적용되어 누락된 문자를 렌더링합니다.
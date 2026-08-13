---
title: .NET에서 프레젠테이션용 대체 폰트 지정
linktitle: 대체 폰트
type: docs
weight: 10
url: /ko/net/create-fallback-font/
keywords:
- 대체 폰트
- 대체 규칙
- 폰트 적용
- 폰트 교체
- Unicode 범위
- 누락된 글리프
- 적절한 글리프
- PowerPoint
- OpenDocument
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET을 사용하여 PPT, PPTX 및 ODP 파일에서 대체 폰트를 설정하고, 모든 장치나 OS에서 일관된 텍스트 표시를 보장합니다."
---
## **개요**

Aspose.Slides를 사용하면 프레젠테이션 렌더링 및 내보내기 작업에 대한 대체 폰트를 지정할 수 있습니다. 기본 폰트에 특정 문자에 대한 글리프가 없을 때 대체 폰트가 사용됩니다.

대체 동작은 대체 규칙을 통해 구성됩니다. 각 규칙은 지정된 Unicode 범위와 해당 글리프를 포함할 수 있는 하나 이상의 폰트를 연결합니다. 서로 다른 문자 범위에 대한 규칙을 정의하고, 기존 규칙에서 대체 폰트를 추가하거나 제거하며, 여러 규칙을 대체 폰트 규칙 컬렉션에 정리할 수 있습니다.

대체 규칙은 런타임 렌더링 설정이며, 프레젠테이션 파일 자체를 수정하지 않으며 PPTX 파일에 저장되지 않습니다.

## **대체 규칙**

Aspose.Slides는 [IFontFallBackRule](https://reference.aspose.com/slides/ko/net/aspose.slides/iFontFallBackRule) 인터페이스와 [FontFallBackRule](https://reference.aspose.com/slides/ko/net/aspose.slides/FontFallBackRule) 클래스를 지원하여 대체 폰트를 적용할 규칙을 지정합니다. [FontFallBackRule](https://reference.aspose.com/slides/ko/net/aspose.slides/FontFallBackRule) 클래스는 누락된 글리프를 검색하기 위해 사용되는 지정된 Unicode 범위와 적절한 글리프를 포함할 수 있는 폰트 목록 간의 연관을 나타냅니다:

```c#
using Aspose.Slides;

uint startUnicodeIndex = 0x0B80;
uint endUnicodeIndex = 0x0BFF;

IFontFallBackRule firstRule = new FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya");
IFontFallBackRule secondRule = new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic");


//다양한 방법을 사용하여 폰트 목록을 추가할 수 있습니다:
string[] fontNames = new string[] { "Segoe UI Emoji, Segoe UI Symbol", "Arial" };

IFontFallBackRule thirdRule = new FontFallBackRule(0x1F300, 0x1F64F, fontNames);
```

또한 기존 [FontFallBackRule](https://reference.aspose.com/slides/ko/net/aspose.slides/FontFallBackRule) 객체에 대체 폰트를 [Remove()](https://reference.aspose.com/slides/ko/net/aspose.slides/ifontfallbackrule/methods/remove) 하거나 [AddFallBackFonts()](https://reference.aspose.com/slides/ko/net/aspose.slides/fontfallbackrule/methods/addfallbackfonts) 로 추가할 수도 있습니다.

[FontFallBackRulesCollection](https://reference.aspose.com/slides/ko/net/aspose.slides/fontfallbackrulescollection)[ ](https://reference.aspose.com/slides/ko/net/aspose.slides/fontfallbackrulescollection)은 여러 Unicode 범위에 대한 대체 폰트 교체 규칙을 지정해야 할 때 [FontFallBackRule](https://reference.aspose.com/slides/ko/net/aspose.slides/FontFallBackRule) 객체 목록을 정리하는 데 사용할 수 있습니다.

{{% alert color="info" title="See also" %}} 
- [대체 폰트 컬렉션 만들기](/slides/ko/net/create-fallback-fonts-collection/)
{{% /alert %}}

## **FAQ**

### 기본 폰트, 폰트 대체 및 폰트 포함 사이의 차이점은 무엇인가요?

대체 폰트는 기본 폰트에 문자가 없을 때만 사용됩니다. [폰트 대체](/slides/ko/net/font-substitution/)는 지정된 전체 폰트를 다른 폰트로 교체합니다. [폰트 포함](/slides/ko/net/embedded-font/)은 폰트를 출력 파일에 패키징하여 수신자가 의도한 대로 텍스트를 볼 수 있게 합니다.

### 대체 폰트는 PDF, PNG, SVG와 같은 내보내기에서 적용되나요, 아니면 화면에만 적용되나요?

예. 대체는 문자 그리기가 필요하지만 원본 폰트에 없을 때 발생하는 모든 [렌더링 및 내보내기 작업](/slides/ko/net/convert-presentation/)에 영향을 미칩니다.

### 대체 설정이 프레젠테이션 파일 자체를 변경하고, 이후 열기에서도 설정이 유지되나요?

아니오. 대체 규칙은 코드 내 런타임 렌더링 설정이며 .pptx 파일에 저장되지 않으며 PowerPoint에서도 보이지 않습니다.

### 운영 체제(Windows/Linux/macOS)와 폰트 디렉터리 집합이 대체 선택에 영향을 주나요?

예. 엔진은 사용 가능한 시스템 폴더와 사용자가 제공한 [추가 경로](/slides/ko/net/custom-font/)에서 폰트를 검색합니다. 폰트가 실제로 존재하지 않으면 해당 폰트를 참조하는 규칙은 적용될 수 없습니다.

### 대체가 WordArt, SmartArt 및 차트에서도 작동하나요?

예. 이러한 개체에 텍스트가 포함될 때 동일한 글리프 대체 메커니즘이 적용되어 누락된 문자를 렌더링합니다.
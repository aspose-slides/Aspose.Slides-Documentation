---
title: .NET에서 프레젠테이션용 대체 글꼴 지정
linktitle: 대체 글꼴
type: docs
weight: 10
url: /ko/net/create-fallback-font/
keywords:
- 대체 글꼴
- 대체 규칙
- 글꼴 적용
- 글꼴 교체
- 유니코드 범위
- 누락된 글리프
- 적절한 글리프
- PowerPoint
- OpenDocument
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: ".NET용 Aspose.Slides를 마스터하여 PPT, PPTX 및 ODP 파일에 대체 글꼴을 설정하고, 모든 장치와 OS에서 일관된 텍스트 표시를 보장합니다."
---
## **개요**

Aspose.Slides는 프레젠테이션 렌더링 및 내보내기 작업에 대해 대체 글꼴을 지정할 수 있게 합니다. 대체 글꼴은 기본 글꼴에 특정 문자의 글리프가 없을 때 사용됩니다.

대체 동작은 대체 규칙을 통해 구성됩니다. 각 규칙은 유니코드 범위와 해당 글리프를 포함할 수 있는 하나 이상의 글꼴을 연결합니다. 다양한 문자 범위에 대한 규칙을 정의하고, 기존 규칙에 대체 글꼴을 추가하거나 제거하며, 여러 규칙을 대체 글꼴 규칙 컬렉션에 정리할 수 있습니다.

대체 규칙은 런타임 렌더링 설정이며, 프레젠테이션 파일 자체를 수정하지 않으며 PPTX 파일 안에 저장되지 않습니다.

## **대체 규칙**

Aspose.Slides는 [IFontFallBackRule](https://reference.aspose.com/slides/ko/net/aspose.slides/iFontFallBackRule) 인터페이스와 [FontFallBackRule](https://reference.aspose.com/slides/ko/net/aspose.slides/FontFallBackRule) 클래스를 지원하여 대체 글꼴을 적용할 규칙을 지정합니다. [FontFallBackRule](https://reference.aspose.com/slides/ko/net/aspose.slides/FontFallBackRule) 클래스는 누락된 글리프를 검색하기 위해 사용되는 지정된 유니코드 범위와 적절한 글리프를 포함할 수 있는 글꼴 목록 사이의 연결을 나타냅니다:

```c#
uint startUnicodeIndex = 0x0B80;
uint endUnicodeIndex = 0x0BFF;

IFontFallBackRule firstRule = new FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya");
IFontFallBackRule secondRule = new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic");


//여러 방법을 사용하여 글꼴 목록을 추가할 수 있습니다:
string[] fontNames = new string[] { "Segoe UI Emoji, Segoe UI Symbol", "Arial" };

IFontFallBackRule thirdRule = new FontFallBackRule(0x1F300, 0x1F64F, fontNames);
```



기존 [FontFallBackRule](https://reference.aspose.com/slides/ko/net/aspose.slides/FontFallBackRule) 객체에 대체 글꼴을 [Remove()](https://reference.aspose.com/slides/ko/net/aspose.slides/ifontfallbackrule/methods/remove) 하거나 [AddFallBackFonts()](https://reference.aspose.com/slides/ko/net/aspose.slides/fontfallbackrule/methods/addfallbackfonts) 로 추가할 수도 있습니다.

[FontFallBackRulesCollection](https://reference.aspose.com/slides/ko/net/aspose.slides/fontfallbackrulescollection)[ ](https://reference.aspose.com/slides/ko/net/aspose.slides/fontfallbackrulescollection)은 여러 유니코드 범위에 대한 대체 글꼴 교체 규칙을 지정해야 할 때 [FontFallBackRule](https://reference.aspose.com/slides/ko/net/aspose.slides/FontFallBackRule) 객체 목록을 정리하는 데 사용할 수 있습니다.

{{% alert color="primary" title="또 보기" %}} 
- [대체 글꼴 컬렉션 만들기](/slides/ko/net/create-fallback-fonts-collection/)
{{% /alert %}}

## **FAQ**

**대체 글꼴, 글꼴 대체 및 글꼴 포함의 차이점은 무엇인가요?**

대체 글꼴은 기본 글꼴에 없는 문자에만 사용됩니다. [글꼴 대체](/slides/ko/net/font-substitution/)는 지정된 전체 글꼴을 다른 글꼴로 교체합니다. [글꼴 포함](/slides/ko/net/embedded-font/)은 출력 파일 안에 글꼴을 패키징하여 수신자가 의도한 대로 텍스트를 볼 수 있게 합니다.

**대체 글꼴이 PDF, PNG 또는 SVG와 같은 내보내기 시에도 적용되나요, 아니면 화면 렌더링에만 적용되나요?**

예. 대체는 문자 그리기가 필요하지만 원본 글꼴에 없을 때 모든 [렌더링 및 내보내기 작업](/slides/ko/net/convert-presentation/)에 영향을 미칩니다.

**대체 설정이 프레젠테이션 파일 자체를 변경하며, 이후 열 때 설정이 지속되나요?**

아니요. 대체 규칙은 코드 내 런타임 렌더링 설정이며 .pptx 안에 저장되지 않아 PowerPoint에 나타나지 않습니다.

**운영 체제(Windows/Linux/macOS)와 글꼴 디렉터리 집합이 대체 선택에 영향을 미치나요?**

예. 엔진은 사용 가능한 시스템 폴더와 제공한 [추가 경로](/slides/ko/net/custom-font/)에서 글꼴을 검색합니다. 글꼴이 실제로 존재하지 않으면 해당 규칙은 적용될 수 없습니다.

**대체가 WordArt, SmartArt 및 차트에도 적용되나요?**

예. 이러한 개체에 텍스트가 포함된 경우 동일한 글리프 대체 메커니즘이 적용되어 누락된 문자를 렌더링합니다.
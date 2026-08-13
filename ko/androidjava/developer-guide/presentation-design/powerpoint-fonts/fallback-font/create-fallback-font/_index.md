---
title: Android에서 프레젠테이션용 대체 글꼴 지정
linktitle: 대체 글꼴
type: docs
weight: 10
url: /ko/androidjava/create-fallback-font/
keywords:
- 대체 글꼴
- 대체 규칙
- 글꼴 적용
- 글꼴 교체
- Unicode 범위
- 누락된 글리프
- 올바른 글리프
- PowerPoint
- OpenDocument
- 프레젠테이션
- Android
- Java
- Aspose.Slides
description: "Android용 Aspose.Slides를 Java로 마스터하여 PPT, PPTX 및 ODP 파일에 대체 글꼴을 설정하고, 모든 장치나 OS에서 일관된 텍스트 표시를 보장합니다."
---
## **개요**

Aspose.Slides를 사용하면 프레젠테이션 렌더링 및 내보내기 작업에 대한 대체 글꼴을 지정할 수 있습니다. 기본 글꼴에 특정 문자에 대한 글리프가 포함되어 있지 않을 때 대체 글꼴이 사용됩니다.

대체 동작은 대체 규칙을 통해 구성됩니다. 각 규칙은 Unicode 범위를 하나 이상의 글꼴에 연결하며, 해당 글꼴에 필요한 글리프가 포함될 수 있습니다. 다양한 문자 범위에 대한 규칙을 정의하고, 기존 규칙에서 대체 글꼴을 추가하거나 제거하며, 여러 규칙을 대체 글꼴 규칙 컬렉션에 조직할 수 있습니다.

대체 규칙은 런타임 렌더링 설정이며, 프레젠테이션 파일 자체를 수정하지 않고 PPTX 파일에 저장되지 않습니다.

## **대체 규칙**

Aspose.Slides는 [IFontFallBackRule](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/IFontFallBackRule) 인터페이스와 [FontFallBackRule](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/FontFallBackRule) 클래스를 지원하여 대체 글꼴을 적용할 규칙을 지정합니다. [FontFallBackRule](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/FontFallBackRule) 클래스는 누락된 글리프를 검색하는 데 사용되는 지정된 Unicode 범위와 적절한 글리프를 포함할 수 있는 글꼴 목록 간의 연관성을 나타냅니다:

```java
import com.aspose.slides.*;

long startUnicodeIndex = 0x0B80;
long endUnicodeIndex = 0x0BFF;

IFontFallBackRule firstRule = new FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya");
IFontFallBackRule secondRule = new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic");

//다양한 방법으로 글꼴 목록을 추가할 수 있습니다:
String[] fontNames = new String[] { "Segoe UI Emoji, Segoe UI Symbol", "Arial" };

IFontFallBackRule thirdRule = new FontFallBackRule(0x1F300, 0x1F64F, fontNames);
```

또한 기존 [FontFallBackRule](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/FontFallBackRule) 객체에 대체 글꼴을 [remove](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/FontFallBackRule#remove-java.lang.String-)하거나 [addFallBackFonts](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-)를 추가할 수 있습니다.

[FontFallBackRulesCollection](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/FontFallBackRulesCollection)는 여러 Unicode 범위에 대한 대체 글꼴 교체 규칙을 지정해야 할 때 [FontFallBackRule](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/FontFallBackRule) 객체 목록을 조직하는 데 사용할 수 있습니다.

{{% alert color="info" title="참고" %}} 
- [Create Fallback Fonts Collection](/slides/ko/androidjava/create-fallback-fonts-collection/)
{{% /alert %}}

## **FAQ**

### 대체 글꼴, 글꼴 교체 및 글꼴 포함 간의 차이는 무엇입니까?

대체 글꼴은 기본 글꼴에 없는 문자에만 사용됩니다. [Font substitution](/slides/ko/androidjava/font-substitution/)은 지정된 전체 글꼴을 다른 글꼴로 교체하고, [Font embedding](/slides/ko/androidjava/embedded-font/)은 글꼴을 출력 파일에 패키징하여 수신자가 의도한 대로 텍스트를 볼 수 있게 합니다.

### PDF, PNG 또는 SVG와 같은 내보내기 시에도 대체 글꼴이 적용되나요, 아니면 화면 렌더링에만 적용되나요?

예. 대체 글꼴은 문자를 그려야 하지만 원본 글꼴에 없을 때 모든 [rendering and export operations](/slides/ko/androidjava/convert-presentation/)에 영향을 줍니다.

### 대체 글꼴을 구성하면 프레젠테이션 파일 자체가 변경되며, 이후 열 때 설정이 유지되나요?

아니요. 대체 규칙은 코드에서 사용되는 런타임 렌더링 설정이며 .pptx 내부에 저장되지 않으므로 PowerPoint에서는 나타나지 않습니다.

### 운영 체제(Windows/Linux/macOS)와 글꼴 디렉터리 설정이 대체 글꼴 선택에 영향을 줍니까?

예. 엔진은 시스템 폴더와 사용자가 제공한 [additional paths](/slides/ko/androidjava/custom-font/)에서 글꼴을 검색합니다. 글꼴이 실제로 존재하지 않으면 해당 규칙은 적용될 수 없습니다.

### WordArt, SmartArt 및 차트에서도 대체 글꼴이 작동합니까?

예. 이러한 객체에 텍스트가 포함된 경우 동일한 글리프 대체 메커니즘이 적용되어 누락된 문자를 렌더링합니다.
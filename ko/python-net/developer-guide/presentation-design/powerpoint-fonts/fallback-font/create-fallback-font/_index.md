---
title: Python에서 프레젠테이션용 대체 폰트 지정
linktitle: 대체 폰트
type: docs
weight: 10
url: /ko/python-net/create-fallback-font/
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
- Python
- Aspose.Slides
description: ".NET을 통해 Python용 Aspose.Slides를 마스터하고 PPT, PPTX 및 ODP 파일에 대체 폰트를 설정하여 모든 장치나 OS에서 일관된 텍스트 표시를 보장합니다."
---
## **Overview**

Aspose.Slides는 프레젠테이션 렌더링 및 내보내기 작업에 대해 대체 폰트를 지정할 수 있게 합니다. 대체 폰트는 기본 폰트에 특정 문자에 대한 글리프가 없을 때 사용됩니다.

대체 동작은 대체 규칙을 통해 구성됩니다. 각 규칙은 필요한 글리프를 포함할 수 있는 하나 이상의 폰트와 Unicode 범위를 연결합니다. 다양한 문자 범위에 대한 규칙을 정의하고, 기존 규칙에서 대체 폰트를 추가하거나 제거하며, 여러 규칙을 대체 폰트 규칙 컬렉션에 정리할 수 있습니다.

대체 규칙은 런타임 렌더링 설정이며, 프레젠테이션 파일 자체를 수정하지 않으며 PPTX 파일에 저장되지 않습니다.

## **Specify Fallback Fonts**

Aspose.Slides는 대체 폰트를 적용하기 위한 규칙을 지정하는 [FontFallBackRule](https://reference.aspose.com/slides/ko/python-net/aspose.slides/FontFallBackRule/) 클래스를 지원합니다. [FontFallBackRule](https://reference.aspose.com/slides/ko/python-net/aspose.slides/FontFallBackRule/) 클래스는 누락된 글리프를 검색하기 위해 사용되는 지정된 Unicode 범위와 적절한 글리프를 포함할 수 있는 폰트 목록 간의 연결을 나타냅니다:

```py
startUnicodeIndex = 0x0B80
endUnicodeIndex = 0x0BFF

firstRule = slides.FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya")
secondRule = slides.FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic")

#여러 가지 방법으로 글꼴 목록을 추가할 수 있습니다:
fontNames =  ["Segoe UI Emoji, Segoe UI Symbol", "Arial" ]

thirdRule = slides.FontFallBackRule(0x1F300, 0x1F64F, fontNames)
```



기존 [FontFallBackRule](https://reference.aspose.com/slides/ko/python-net/aspose.slides/FontFallBackRule/) 객체에 대체 폰트를 [remove](https://reference.aspose.com/slides/ko/python-net/aspose.slides/fontfallbackrule/remove/)하거나 [add_fall_back_fonts](https://reference.aspose.com/slides/ko/python-net/aspose.slides/fontfallbackrule/add_fall_back_fonts/)을 추가할 수도 있습니다.

[FontFallBackRulesCollection](https://reference.aspose.com/slides/ko/python-net/aspose.slides/fontfallbackrulescollection/) 은 여러 Unicode 범위에 대한 대체 폰트 교체 규칙을 지정해야 할 때 [FontFallBackRule](https://reference.aspose.com/slides/ko/python-net/aspose.slides/FontFallBackRule/) 객체 목록을 정리하는 데 사용할 수 있습니다.

{{% alert color="primary" title="See also" %}} 
- [Create Fallback Fonts Collection](/slides/ko/python-net/create-fallback-fonts-collection/)
{{% /alert %}}

## **FAQ**

**What is the difference between a fallback font, font substitution, and font embedding?**

대체 폰트는 기본 폰트에 없는 문자에만 사용됩니다. [Font substitution](/slides/ko/python-net/font-substitution/) 은 지정된 전체 폰트를 다른 폰트로 교체하고, [Font embedding](/slides/ko/python-net/embedded-font/) 은 폰트를 출력 파일에 포함시켜 수신자가 의도한 대로 텍스트를 볼 수 있게 합니다.

**Are fallback fonts applied during exports like PDF, PNG, or SVG, or only on-screen rendering?**

예. 대체 폰트는 문자 그리기가 필요하지만 원본 폰트에 없을 때 모든 [rendering and export operations](/slides/ko/python-net/convert-presentation/)에 영향을 줍니다.

**Does configuring fallback change the presentation file itself, and will the setting persist for future openings?**

아니요. 대체 규칙은 코드 내 런타임 렌더링 설정이며 .pptx 내부에 저장되지 않아 PowerPoint에 나타나지 않습니다.

**Does the operating system (Windows/Linux/macOS) and the set of font directories affect fallback selection?**

예. 엔진은 사용 가능한 시스템 폴더와 제공한 [additional paths](/slides/ko/python-net/custom-font/)에서 폰트를 검색합니다. 폰트가 실제로 존재하지 않으면 해당 규칙은 적용될 수 없습니다.

**Does fallback work for WordArt, SmartArt, and charts?**

예. 이러한 개체에 텍스트가 포함된 경우 동일한 글리프 교체 메커니즘이 적용되어 누락된 문자를 렌더링합니다.
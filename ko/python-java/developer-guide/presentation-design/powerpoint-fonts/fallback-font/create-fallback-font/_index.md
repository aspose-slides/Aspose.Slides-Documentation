---
title: Python via Java 로 프레젠테이션에 대체 폰트 지정
linktitle: 대체 폰트
type: docs
weight: 10
url: /ko/python-java/create-fallback-font/
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
- Java
- Aspose.Slides
description: "Python via Java 용 Aspose.Slides를 마스터하여 PPT, PPTX 및 ODP 파일에 대체 폰트를 설정하고, 모든 장치와 OS에서 일관된 텍스트 표시를 보장합니다."
---
## **개요**

Aspose.Slides는 프레젠테이션 렌더링 및 내보내기 작업에 대해 대체 폰트를 지정할 수 있도록 합니다. 대체 폰트는 기본 폰트에 특정 문자에 대한 글리프가 없을 때 사용됩니다.

대체 동작은 대체 규칙을 통해 구성됩니다. 각 규칙은 필요한 글리프를 포함할 수 있는 하나 이상의 폰트와 Unicode 범위를 연결합니다. 다양한 문자 범위에 대한 규칙을 정의하고, 기존 규칙에서 대체 폰트를 추가하거나 제거하며, 여러 규칙을 대체 폰트 규칙 컬렉션에 정리할 수 있습니다.

대체 규칙은 런타임 렌더링 설정이며, 프레젠테이션 파일 자체를 수정하지 않으며 PPTX 파일 내부에 저장되지 않습니다.

## **대체 규칙**

Aspose.Slides는 대체 폰트를 적용하기 위한 규칙을 지정하는 [FontFallBackRule](https://reference.aspose.com/slides/ko/python-java/aspose.slides/fontfallbackrule/) 클래스를 제공합니다. 이 클래스는 누락된 글리프를 검색하기 위해 사용되는 Unicode 범위와 필요한 글리프를 포함할 수 있는 폰트 목록 간의 연결을 나타냅니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontFallBackRule

start_unicode_index = 0x0B80
end_unicode_index = 0x0BFF

first_rule = FontFallBackRule(start_unicode_index, end_unicode_index, "Vijaya")
second_rule = FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic")

# 폰트 목록을 지정하는 여러 방법을 사용합니다.
font_names = jpype.JArray(jpype.JString)(["Segoe UI Emoji, Segoe UI Symbol", "Arial"])

third_rule = FontFallBackRule(0x1F300, 0x1F64F, font_names)
```

기존 [FontFallBackRule](https://reference.aspose.com/slides/ko/python-java/aspose.slides/fontfallbackrule/) 객체에서 [remove](https://reference.aspose.com/slides/ko/python-java/aspose.slides/fontfallbackrule/#remove) を 사용하여 대체 폰트를 제거하거나 [addFallBackFonts](https://reference.aspose.com/slides/ko/python-java/aspose.slides/fontfallbackrule/#addFallBackFonts) 를 사용하여 대체 폰트를 추가할 수도 있습니다.

여러 Unicode 범위에 대한 대체 폰트 교체 규칙을 지정해야 할 때, [FontFallBackRulesCollection](https://reference.aspose.com/slides/ko/python-java/aspose.slides/fontfallbackrulescollection/) 은 [FontFallBackRule](https://reference.aspose.com/slides/ko/python-java/aspose.slides/fontfallbackrule/) 객체 목록을 정리할 수 있습니다.

{{% alert color="info" title="또 보기" %}} 
- [대체 폰트 컬렉션 만들기](/slides/ko/python-java/create-fallback-fonts-collection/)
{{% /alert %}}

## **FAQ**

**대체 폰트, 폰트 대체, 폰트 포함의 차이는 무엇인가요?**

대체 폰트는 기본 폰트에 없는 문자에 대해서만 사용됩니다. [Font substitution](/slides/ko/python-java/font-substitution/) 은 지정된 전체 폰트를 다른 폰트로 교체합니다. [Font embedding](/slides/ko/python-java/embedded-font/) 은 폰트를 출력 파일에 포함시켜 수신자가 의도한 대로 텍스트를 볼 수 있도록 합니다.

**대체 폰트가 PDF, PNG 또는 SVG와 같은 내보내기 시에도 적용되나요, 아니면 화면에 표시될 때만 적용되나요?**

예. 대체 폰트는 문자를 그려야 하지만 원본 폰트에 없을 때 발생하는 모든 [렌더링 및 내보내기 작업](/slides/ko/python-java/convert-presentation/) 에 영향을 줍니다.

**대체 폰트를 구성해도 프레젠테이션 파일 자체가 변경되고, 설정이 이후에도 유지되나요?**

아니오. 대체 규칙은 코드 내 런타임 렌더링 설정이며, .pptx 내부에 저장되지 않아 PowerPoint에 표시되지 않습니다.

**운영 체제(Windows/Linux/macOS) 및 폰트 디렉터리 설정이 대체 폰트 선택에 영향을 미치나요?**

예. 엔진은 사용 가능한 시스템 폴더와 제공한 [추가 경로](/slides/ko/python-java/custom-font/) 에서 폰트를 검색합니다. 폰트가 실제로 존재하지 않으면 해당 폰트를 참조하는 규칙은 적용될 수 없습니다.

**대체 폰트가 WordArt, SmartArt 및 차트에도 적용되나요?**

예. 이러한 객체에 텍스트가 포함된 경우, 동일한 글리프 대체 메커니즘이 누락된 문자를 렌더링하는 데 적용됩니다.
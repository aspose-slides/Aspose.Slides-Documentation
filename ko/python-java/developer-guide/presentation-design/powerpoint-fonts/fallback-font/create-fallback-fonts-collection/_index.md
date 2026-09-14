---
title: Python을 사용하여 Java에서 대체 글꼴 컬렉션 구성
linktitle: 대체 글꼴 컬렉션
type: docs
weight: 20
url: /ko/python-java/create-fallback-fonts-collection/
keywords:
- 대체 글꼴
- 대체 규칙
- 글꼴 컬렉션
- 글꼴 구성
- 글꼴 설정
- PowerPoint
- OpenDocument
- 프레젠테이션
- Python
- Java
- Aspose.Slides
description: "Python을 위한 Aspose.Slides에서 Java를 통해 대체 글꼴 컬렉션을 설정하여 PowerPoint 및 OpenDocument 프레젠테이션의 텍스트를 일관되고 선명하게 유지합니다."
---
## **개요**

Aspose.Slides를 사용하면 프레젠테이션에 대한 대체 글꼴 규칙 컬렉션을 구성할 수 있습니다. 각 대체 규칙은 [FontFallBackRule](https://reference.aspose.com/slides/ko/python-java/aspose.slides/fontfallbackrule/) 클래스로 표현되며 [FontFallBackRulesCollection](https://reference.aspose.com/slides/ko/python-java/aspose.slides/fontfallbackrulescollection/)에 추가할 수 있습니다.

컬렉션을 만든 후에는 프레젠테이션의 [FontsManager](https://reference.aspose.com/slides/ko/python-java/aspose.slides/fontsmanager/) 의 [setFontFallBackRulesCollection](https://reference.aspose.com/slides/ko/python-java/aspose.slides/fontsmanager/#setFontFallBackRulesCollection) 메서드를 사용하여 할당할 수 있습니다. [FontsManager](https://reference.aspose.com/slides/ko/python-java/aspose.slides/fontsmanager/)는 프레젠테이션 전반에 걸쳐 글꼴을 제어하며, 각 [Presentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/) 인스턴스는 자체 [FontsManager](https://reference.aspose.com/slides/ko/python-java/aspose.slides/fontsmanager/)를 가지고 있습니다.

대체 글꼴 컬렉션으로 [FontsManager](https://reference.aspose.com/slides/ko/python-java/aspose.slides/fontsmanager/)가 초기화되면, 지정된 대체 글꼴이 프레젠테이션 렌더링 중에 적용됩니다.

## **대체 규칙 적용**

[FontFallBackRule](https://reference.aspose.com/slides/ko/python-java/aspose.slides/fontfallbackrule/) 클래스의 인스턴스를 [FontFallBackRulesCollection](https://reference.aspose.com/slides/ko/python-java/aspose.slides/fontfallbackrulescollection/) 으로 구성할 수 있습니다. 컬렉션에서 규칙을 추가하거나 제거할 수 있습니다.

이 컬렉션은 프레젠테이션 전체의 글꼴을 제어하는 [FontsManager](https://reference.aspose.com/slides/ko/python-java/aspose.slides/fontsmanager/) 클래스의 [setFontFallBackRulesCollection](https://reference.aspose.com/slides/ko/python-java/aspose.slides/fontsmanager/#setFontFallBackRulesCollection) 메서드를 사용하여 할당할 수 있습니다.

각 [Presentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/) 은 자체 [FontsManager](https://reference.aspose.com/slides/ko/python-java/aspose.slides/fontsmanager/) 인스턴스를 반환하는 [getFontsManager](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/#getFontsManager) 메서드를 갖습니다.

다음 예제는 대체 글꼴 규칙 컬렉션을 생성하고 프레젠테이션의 [FontsManager](https://reference.aspose.com/slides/ko/python-java/aspose.slides/fontsmanager/) 에 할당하는 방법을 보여줍니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontFallBackRule, FontFallBackRulesCollection, Presentation

presentation = Presentation()
try:
    fallback_rules = FontFallBackRulesCollection()

    tamil_rule = FontFallBackRule(0x0B80, 0x0BFF, "Vijaya")
    fallback_rules.add(tamil_rule)
    hiragana_rule = FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic")
    fallback_rules.add(hiragana_rule)

    presentation.getFontsManager().setFontFallBackRulesCollection(fallback_rules)
finally:
    presentation.dispose()
```

[FontsManager](https://reference.aspose.com/slides/ko/python-java/aspose.slides/fontsmanager/)가 대체 글꼴 컬렉션으로 초기화된 후, 대체 글꼴이 프레젠테이션 렌더링 중에 적용됩니다.

{{% alert color="info" title="Note" %}}
대체 글꼴로 프레젠테이션을 렌더링하는 방법에 대해 자세히 알아보려면 [대체 글꼴로 프레젠테이션 렌더링](/slides/ko/python-java/render-presentation-with-fallback-font/)을 클릭하세요.
{{% /alert %}}

## **자주 묻는 질문**

**내 대체 규칙이 PPTX 파일에 포함되어 저장 후 PowerPoint에서 보이게 되나요?**

아니요. 대체 규칙은 런타임 렌더링 설정이며 PPTX에 직렬화되지 않으며 PowerPoint UI에 표시되지 않습니다.

**대체 규칙이 SmartArt, WordArt, 차트 및 표 내부의 텍스트에도 적용되나요?**

네. 이러한 개체의 모든 텍스트에 동일한 글리프 교체 메커니즘이 사용됩니다.

**Aspose가 라이브러리와 함께 글꼴을 배포하나요?**

아니요. 글꼴은 사용자가 직접 추가하고 사용하며, 이는 사용자 책임하에 이루어집니다.

**누락된 글꼴에 대한 교체/대체와 누락된 글리프에 대한 대체를 함께 사용할 수 있나요?**

네. 이것들은 동일한 글꼴 해상 파이프라인의 독립적인 단계입니다: 먼저 엔진이 글꼴 가용성을 해결하고([replacement](/slides/ko/python-java/font-replacement/)/[substitution](/slides/ko/python-java/font-substitution/)), 그 다음 대체가 사용 가능한 글꼴의 누락된 글리프를 채웁니다.
---
title: Python에서 폰트 폴백 컬렉션 구성
linktitle: 폰트 폴백 컬렉션
type: docs
weight: 20
url: /ko/python-net/create-fallback-fonts-collection/
keywords:
- 대체 폰트
- 대체 규칙
- 폰트 컬렉션
- 폰트 구성
- 폰트 설정
- PowerPoint
- OpenDocument
- 프레젠테이션
- Python
- Aspose.Slides
description: "Aspose.Slides for Python (.NET)에서 폰트 폴백 컬렉션을 설정하여 PowerPoint 및 OpenDocument 프레젠테이션의 텍스트를 일관되고 선명하게 유지합니다."
---
## **Overview**

Aspose.Slides를 사용하면 프레젠테이션에 대한 폰트 폴백 규칙 컬렉션을 구성할 수 있습니다. 각 폴백 규칙은 `FontFallBackRule` 클래스로 표현되며 `FontFallBackRulesCollection`에 추가할 수 있습니다.

컬렉션을 만든 후에는 프레젠테이션의 `fonts_manager`에 있는 `font_fall_back_rules_collection` 속성에 할당할 수 있습니다. `fonts_manager`는 프레젠테이션 전체의 폰트를 제어하며, 각 `Presentation` 인스턴스는 자체 `FontsManager`를 가집니다.

`FontsManager`가 폰트 폴백 컬렉션으로 초기화되면, 지정된 폰트 폴백이 프레젠테이션 렌더링 중에 적용됩니다.

## **Apply Fallback Rules**

[FontFallBackRule](https://reference.aspose.com/slides/ko/python-net/aspose.slides/FontFallBackRule/) 클래스의 인스턴스를 [FontFallBackRulesCollection](https://reference.aspose.com/slides/ko/python-net/aspose.slides/fontfallbackrulescollection/)에 구성할 수 있습니다. 컬렉션에서 규칙을 추가하거나 제거할 수 있습니다.

그런 다음 이 컬렉션을 [font_fall_back_rules_collection](https://reference.aspose.com/slides/ko/python-net/aspose.slides/fontsmanager/font_fall_back_rules_collection/) 속성에 할당하여 [FontsManager](https://reference.aspose.com/slides/ko/python-net/aspose.slides/fontsmanager/) 클래스에 적용합니다. FontsManager는 프레젠테이션 전체의 폰트를 제어합니다.

각 [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/)에는 자체 FontsManager 인스턴스를 가지고 있는 [fonts_manager](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/fonts_manager/) 속성이 있습니다.

다음은 특정 프레젠테이션의 FontsManager에 폰트 폴백 규칙 컬렉션을 생성하고 할당하는 예시입니다.  

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
	userRulesList = slides.FontFallBackRulesCollection()

	userRulesList.add(slides.FontFallBackRule(0x0B80, 0x0BFF, "Vijaya"))
	userRulesList.add(slides.FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic"))

	presentation.fonts_manager.font_fall_back_rules_collection = userRulesList
```

FontsManager가 폰트 폴백 컬렉션으로 초기화된 후, 폰트 폴백은 프레젠테이션 렌더링 중에 적용됩니다.

{{% alert color="primary" %}} 
더 알아보기: [Render Presentation with Fallback Font](/slides/ko/python-net/render-presentation-with-fallback-font/).
{{% /alert %}}

## **FAQ**

**Will my fallback rules be embedded into the PPTX file and visible in PowerPoint after saving?**

아니요. 폰트 폴백 규칙은 런타임 렌더링 설정이며 PPTX 파일에 직렬화되지 않으므로 PowerPoint UI에 표시되지 않습니다.

**Does fallback apply to text inside SmartArt, WordArt, charts, and tables?**

예. 동일한 글리프 대체 메커니즘이 이러한 객체의 모든 텍스트에 적용됩니다.

**Does Aspose distribute any fonts with the library?**

아니요. 폰트는 사용자가 직접 추가·사용해야 하며, 이에 대한 책임은 사용자에게 있습니다.

**Can replacement/substitution for missing fonts and fallback for missing glyphs be used together?**

예. 두 기능은 같은 폰트 해석 파이프라인의 독립적인 단계입니다. 먼저 엔진이 폰트 가용성을 해결하고([replacement](/slides/ko/python-net/font-replacement/)/[substitution](/slides/ko/python-net/font-substitution/)), 그 다음 폰트 폴백이 사용 가능한 폰트에서 누락된 글리프를 보완합니다.
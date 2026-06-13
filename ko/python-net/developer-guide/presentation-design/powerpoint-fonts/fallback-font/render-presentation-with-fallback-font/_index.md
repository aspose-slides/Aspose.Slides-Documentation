---
title: Python에서 대체 글꼴을 사용하여 프레젠테이션 렌더링
linktitle: 프레젠테이션 렌더링
type: docs
weight: 30
url: /ko/python-net/render-presentation-with-fallback-font/
keywords:
- 대체 글꼴
- PowerPoint 렌더링
- 프레젠테이션 렌더링
- 슬라이드 렌더링
- PowerPoint
- 프레젠테이션
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET에서 대체 글꼴을 사용하여 프레젠테이션을 렌더링합니다 – PPT, PPTX 및 ODP 전반에 걸쳐 텍스트를 일관되게 유지하고 단계별 코드 샘플을 제공합니다."
---
## **개요**

Aspose.Slides는 대체 글꼴 규칙을 사용하여 프레젠테이션을 렌더링할 수 있도록 합니다. 이 문서에서는 대체 글꼴 규칙 컬렉션을 생성하고, 대체 글꼴을 제거하거나 추가하여 규칙을 수정하고, 해당 컬렉션을 `FontsManager.font_fall_back_rules_collection` 속성에 할당하는 방법을 보여줍니다.

대체 글꼴 규칙 컬렉션이 프레젠테이션의 `fonts_manager`에 할당되면 저장, 렌더링 및 프레젠테이션 변환과 같은 작업 중에 규칙이 적용됩니다. 이 예제는 슬라이드 썸네일을 렌더링하고 PNG 이미지로 저장할 때 구성된 규칙을 사용하는 방법을 보여줍니다.

## **대체 글꼴 규칙을 사용하여 슬라이드 렌더링**

다음 예제는 다음 단계로 구성됩니다:

1. 우리는 [대체 글꼴 규칙 컬렉션 만들기](/slides/ko/python-net/create-fallback-fonts-collection/) .
1. [제거](https://reference.aspose.com/slides/ko/python-net/aspose.slides/fontfallbackrule/remove/) 대체 글꼴 규칙 및 [add_fall_back_fonts](https://reference.aspose.com/slides/ko/python-net/aspose.slides/fontfallbackrule/add_fall_back_fonts/)을 다른 규칙에 추가합니다.
1. 규칙 컬렉션을 [FontsManager.font_fall_back_rules_collection](https://reference.aspose.com/slides/ko/python-net/aspose.slides/fontsmanager/font_fall_back_rules_collection/) 속성에 설정합니다.
1. [Presentation.save()](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 메서드를 사용하면 프레젠테이션을 동일한 형식으로 저장하거나 다른 형식으로 저장할 수 있습니다. 대체 글꼴 규칙 컬렉션이 FontsManager에 설정된 후에는 저장, 렌더링, 변환 등 프레젠테이션에 대한 모든 작업 시 규칙이 적용됩니다.

```py
import aspose.slides as slides

# 규칙 컬렉션의 새 인스턴스 생성
rulesList = slides.FontFallBackRulesCollection()

# 여러 규칙 생성
rulesList.add(slides.FontFallBackRule(0x400, 0x4FF, "Times New Roman"))

for fallBackRule in rulesList:
	# 로드된 규칙에서 대체 글꼴 "Tahoma" 제거 시도
	fallBackRule.remove("Tahoma")

	# 지정된 범위에 대한 규칙 업데이트
	if fallBackRule.range_end_index >= 0x4000 and fallBackRule.range_start_index < 0x5000:
		fallBackRule.add_fall_back_fonts("Verdana")

# 또한 목록에서 기존 규칙을 제거할 수 있음
if len(rulesList) > 0:
	rulesList.remove(rulesList[0])

with slides.Presentation(path + "input.pptx") as pres:
	# 사용을 위해 준비된 규칙 목록 할당
	pres.fonts_manager.font_fall_back_rules_collection = rulesList

	# 초기화된 규칙 컬렉션을 사용하여 썸네일을 렌더링하고 PNG로 저장
	with pres.slides[0].get_image(1, 1) as img:
		img.save("Slide_0.png", slides.ImageFormat.PNG)
```

{{% alert color="primary" %}} 
Python에서 [PowerPoint 슬라이드를 PNG로 변환](/slides/ko/python-net/convert-powerpoint-to-png/) 방법에 대해 자세히 알아보세요.
{{% /alert %}}
---
title: Python을 통해 Java에서 대체 폰트로 프레젠테이션 렌더링
linktitle: 프레젠테이션 렌더링
type: docs
weight: 30
url: /ko/python-java/render-presentation-with-fallback-font/
keywords:
- 대체 폰트
- PowerPoint 렌더링
- 프레젠테이션 렌더링
- 슬라이드 렌더링
- PowerPoint
- OpenDocument
- 프레젠테이션
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java에서 대체 폰트를 사용해 프레젠테이션을 렌더링합니다 – PPT, PPTX 및 ODP에서 텍스트 일관성을 유지하기 위해 단계별 Python 코드 예제가 제공됩니다."
---
## **개요**

Aspose.Slides는 대체 폰트 규칙을 사용하여 프레젠테이션을 렌더링할 수 있게 해줍니다. 이 문서에서는 대체 폰트 규칙 컬렉션을 생성하고, 대체 폰트를 제거하거나 추가하여 규칙을 수정한 다음, [FontsManager.setFontFallBackRulesCollection](https://reference.aspose.com/slides/ko/python-java/aspose.slides/fontsmanager/#setFontFallBackRulesCollection) 메서드를 사용하여 컬렉션을 할당하는 방법을 보여줍니다.

대체 폰트 규칙 컬렉션이 프레젠테이션의 [FontsManager](https://reference.aspose.com/slides/ko/python-java/aspose.slides/fontsmanager/)에 할당되면, 저장, 렌더링 및 변환과 같은 작업 중에 규칙이 적용됩니다. 이 예제는 슬라이드 썸네일을 렌더링하고 JPEG 이미지로 저장할 때 구성된 규칙을 사용하는 방법을 보여줍니다.

## **대체 폰트 규칙을 사용하여 슬라이드 렌더링**

다음 예제에는 다음 단계가 포함됩니다:

1. [대체 폰트 규칙 컬렉션 생성](/slides/ko/python-java/create-fallback-fonts-collection/).
2. [제거](https://reference.aspose.com/slides/ko/python-java/aspose.slides/fontfallbackrule/#remove) 규칙에서 대체 폰트를 삭제하고 [대체 폰트 추가](https://reference.aspose.com/slides/ko/python-java/aspose.slides/fontfallbackrule/#addFallBackFonts) 다른 규칙에 대체 폰트를 추가합니다.
3. [getFontsManager](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/#getFontsManager)에서 반환된 폰트 매니저에 [setFontFallBackRulesCollection](https://reference.aspose.com/slides/ko/python-java/aspose.slides/fontsmanager/#setFontFallBackRulesCollection) 을 사용하여 규칙 컬렉션을 할당합니다.
4. [Presentation.save](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/#save) 메서드를 사용하여 프레젠테이션을 동일한 형식이나 다른 형식으로 저장합니다. 대체 폰트 규칙 컬렉션이 [FontsManager](https://reference.aspose.com/slides/ko/python-java/aspose.slides/fontsmanager/)에 할당된 후, 이러한 규칙은 프레젠테이션에 대한 저장, 렌더링, 변환 등 작업 중에 적용됩니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontFallBackRule, FontFallBackRulesCollection, ImageFormat, Presentation

# 새 규칙 컬렉션을 생성합니다.
fallback_rules = FontFallBackRulesCollection()

# 여러 규칙을 생성합니다.
cyrillic_rule = FontFallBackRule(0x400, 0x4FF, "Times New Roman")
fallback_rules.add(cyrillic_rule)
arabic_rule = FontFallBackRule(0x600, 0x6FF, "Tahoma, Arial")
fallback_rules.add(arabic_rule)

for fallback_rule in fallback_rules:
    # 규칙에서 대체 폰트 "Tahoma"를 제거해 봅니다.
    fallback_rule.remove("Tahoma")

    # 지정된 범위에 대해 규칙을 업데이트합니다.
    if fallback_rule.getRangeEndIndex() >= 0x400 and fallback_rule.getRangeStartIndex() < 0x500:
        fallback_rule.addFallBackFonts("Verdana")

# 렌더링을 위해 최소 하나의 규칙을 남겨두고 기존 규칙을 제거합니다.
if fallback_rules.size() > 1:
    rule_to_remove = fallback_rules.get_Item(1)
    fallback_rules.remove(rule_to_remove)

presentation = Presentation("input.pptx")
try:
    # 준비된 규칙 컬렉션을 할당합니다.
    presentation.getFontsManager().setFontFallBackRulesCollection(fallback_rules)

    # 구성된 규칙 컬렉션을 사용해 썸네일을 렌더링합니다.
    slide_image = presentation.getSlides().get_Item(0).getImage(1.0, 1.0)
    try:
        # 이미지를 JPEG 형식으로 디스크에 저장합니다.
        slide_image.save("Slide_0.jpg", ImageFormat.Jpeg)
    finally:
        slide_image.dispose()
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
Python을 통해 Java에서 PPT 및 PPTX를 JPG로 변환하는 방법에 대해 자세히 알아보세요. [Python을 통해 Java에서 PPT 및 PPTX를 JPG로 변환](/slides/ko/python-java/convert-powerpoint-to-jpg/).
{{% /alert %}}
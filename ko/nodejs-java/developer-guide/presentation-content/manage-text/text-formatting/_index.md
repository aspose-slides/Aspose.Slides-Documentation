---
title: JavaScript에서 프레젠테이션 텍스트 서식 지정
linktitle: 텍스트 서식 지정
type: docs
weight: 50
url: /ko/nodejs-java/text-formatting/
keywords:
- 텍스트 강조
- 정규식
- 단락 정렬
- 텍스트 스타일
- 텍스트 배경
- 텍스트 투명도
- 문자 간격
- 글꼴 속성
- 글꼴 패밀리
- 텍스트 회전
- 회전 각도
- 텍스트 프레임
- 줄 간격
- 자동 맞춤 속성
- 텍스트 프레임 앵커
- 텍스트 탭 설정
- 기본 언어
- PowerPoint
- OpenDocument
- 프레젠테이션
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java를 사용하여 PowerPoint 및 OpenDocument 프레젠테이션에서 텍스트를 서식 및 스타일링합니다. 글꼴, 색상, 정렬 등을 사용자 지정합니다."
---
## **개요**

이 문서에서는 Aspose.Slides for Node.js via Java를 사용하여 PowerPoint 및 OpenDocument 프레젠테이션에서 텍스트를 서식 지정하는 방법을 보여줍니다. 강조 표시, 배경 색상, 투명도, 문자 간격, 글꼴 속성, 회전, 단락 간격, 자동 맞춤 동작, 텍스트 앵커링, 탭 정지 및 언어 설정을 다룹니다.

아래 예제에서는 첫 번째 슬라이드에 단일 텍스트 상자가 포함된 "sample.pptx" 파일을 사용합니다.

![샘플 텍스트](sample_text.png)

## **텍스트 강조 표시**

특정 샘플과 일치하는 텍스트를 강조 표시해야 할 때는 [TextFrame.highlightText](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/textframe/#highlightText-java.lang.String-java.awt.Color-) 메서드를 사용합니다. 이 메서드는 일치하는 텍스트 조각에 강조 색을 적용하며, [TextSearchOptions](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/textsearchoptions/)와 함께 사용해 예를 들어 전체 단어만 일치하도록 검색 방식을 제어할 수 있습니다.

다음 코드는 문자 **"try"** 의 모든 발생을 강조 표시한 다음 전체 단어 **"to"** 만 강조 표시합니다.

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const textFrame = shape.getTextFrame();

    // 도형 내에서 "try" 단어를 강조합니다.
    textFrame.highlightText("try", java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));

    const searchOptions = new aspose.slides.TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);

    // 도형 내에서 "to" 단어를 강조합니다.
    textFrame.highlightText("to", java.getStaticFieldValue("java.awt.Color", "MAGENTA"), searchOptions, null);

    presentation.save("highlighted_text.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

결과:

![강조된 텍스트](highlighted_text.png)

## **정규식으로 텍스트 강조 표시**

[TextFrame.highlightRegex](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/textframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-aspose.slides.IFindResultCallback-) 메서드는 정규식으로 찾은 텍스트 일치를 강조 표시합니다. Node.js via Java에서는 이 API가 [TextFrame](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/textframe/)에서 노출됩니다.

다음 코드는 **일곱 글자 이상**을 포함하는 모든 단어를 강조 표시합니다.

```javascript
const Pattern = java.import("java.util.regex.Pattern");
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const regex = Pattern.compile("\\b[^\\s]{7,}\\b");

    // 7개 이상 문자로 구성된 모든 단어를 강조합니다.
    shape.getTextFrame().highlightRegex(regex, java.getStaticFieldValue("java.awt.Color", "YELLOW"), null);

    presentation.save("highlighted_text_using_regex.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

결과:

![정규식을 사용한 강조된 텍스트](highlighted_text_using_regex.png)

## **텍스트 배경 색상 설정**

단락의 기본 강조 색상을 설정하려면 [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/paragraphformat/#getDefaultPortionFormat--)을 사용하고, 개별 텍스트 구간에 대해서는 [PortionFormat.getHighlightColor](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/portionformat/#getHighlightColor--)을 사용합니다.

다음 코드는 **전체 단락**에 대한 배경 색상을 설정하는 방법을 보여 줍니다.

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // 전체 단락에 대한 강조 색상을 설정합니다.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getHighlightColor().setColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));

    presentation.save("gray_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

결과:

![회색 단락](gray_paragraph.png)

다음 코드는 **굵은 글꼴을 가진 텍스트 구간**에 대한 배경 색상을 설정하는 방법을 보여 줍니다.

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const portions = paragraph.getPortions();
    const portionCount = portions.getCount();

    for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
        const portion = portions.get_Item(portionIndex);
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // 텍스트 구간에 대한 강조 색상을 설정합니다.
            portion.getPortionFormat().getHighlightColor().setColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));
        }
    }

    presentation.save("gray_text_portions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

결과:

![회색 텍스트 구간](gray_text_portions.png)

## **텍스트 단락 정렬**

[ParagraphFormat.setAlignment](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/paragraphformat/#setAlignment-byte-)을 사용하여 텍스트 프레임 내 단락 정렬을 설정합니다. 값은 가운데, 왼쪽, 오른쪽, 양쪽 맞춤 등으로 지정할 수 있습니다.

다음 코드는 단락을 **가운데** 정렬하는 방법을 보여 줍니다.

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // 단락의 정렬을 가운데로 설정합니다.
    paragraph.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.Center);

    presentation.save("aligned_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

결과:

![정렬된 단락](aligned_paragraph.png)

## **텍스트 투명도 설정**

텍스트 투명도는 [PortionFormat.getFillFormat](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/portionformat/#getFillFormat--)에 할당된 색상의 알파 구성 요소를 통해 제어됩니다. 아래 예제에서 `alpha = 50`은 0-255 범위의 ARGB 알파 채널 값이며, 투명도 백분율이 아닙니다.

다음 코드는 **전체 단락**에 투명도를 적용하는 방법을 보여 줍니다.

```javascript
const alpha = 50;
const transparentBlack = java.newInstanceSync("java.awt.Color", 0, 0, 0, alpha);
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const fillFormat = paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat();

    // 텍스트의 채우기 색상을 투명 색으로 설정합니다.
    fillFormat.setFillType(java.newByte(aspose.slides.FillType.Solid));
    fillFormat.getSolidFillColor().setColor(transparentBlack);

    presentation.save("transparent_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

결과:

![투명한 단락](transparent_paragraph.png)

다음 코드는 **굵은 글꼴을 가진 텍스트 구간**에 투명도를 적용하는 방법을 보여 줍니다.

```javascript
const alpha = 50;
const transparentBlack = java.newInstanceSync("java.awt.Color", 0, 0, 0, alpha);
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const portions = paragraph.getPortions();
    const portionCount = portions.getCount();

    for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
        const portion = portions.get_Item(portionIndex);
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            const fillFormat = portion.getPortionFormat().getFillFormat();

            // 텍스트 구간의 투명도를 설정합니다.
            fillFormat.setFillType(java.newByte(aspose.slides.FillType.Solid));
            fillFormat.getSolidFillColor().setColor(transparentBlack);
        }
    }

    presentation.save("transparent_text_portions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

결과:

![투명한 텍스트 구간](transparent_text_portions.png)

## **텍스트 문자 간격 설정**

[BasePortionFormat.setSpacing](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/baseportionformat/#setSpacing-float-)을 사용하여 텍스트 상자 내 문자 간격을 확대하거나 축소할 수 있습니다.

다음 JavaScript 코드는 **전체 단락**의 문자 간격을 확대하는 방법을 보여 줍니다.

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // 참고: 문자 간격을 압축하려면 음수 값을 사용합니다.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3); // 문자 간격을 확장합니다.

    presentation.save("character_spacing_in_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

결과:

![단락의 문자 간격](character_spacing_in_paragraph.png)

다음 코드는 **굵은 글꼴을 가진 텍스트 구간**의 문자 간격을 확대하는 방법을 보여 줍니다.

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const portions = paragraph.getPortions();
    const portionCount = portions.getCount();

    for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
        const portion = portions.get_Item(portionIndex);
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // 참고: 문자 간격을 압축하려면 음수 값을 사용합니다.
            portion.getPortionFormat().setSpacing(3); // 문자 간격을 확장합니다.
        }
    }

    presentation.save("character_spacing_in_text_portions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

결과:

![텍스트 구간의 문자 간격](character_spacing_in_text_portions.png)

### **특정 글꼴에 대한 커닝 비활성화**

일부 경우 Aspose.Slides에서 렌더링된 텍스트가 PowerPoint에서 표시되는 텍스트보다 약간 더 촘촘하게 보일 수 있습니다. 이는 PowerPoint가 해당 글꼴에 대한 유효한 커닝 정보가 있더라도 커닝 데이터를 무시할 수 있기 때문입니다.

이러한 경우 렌더링 출력을 PowerPoint와 가깝게 만들려면 영향을 받는 글꼴을 사용하는 텍스트 구간에 대해 커닝을 비활성화할 수 있습니다. [BasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/baseportionformat/#setKerningMinimalSize-float-)을 실제 글꼴 크기보다 훨씬 크게 설정하십시오.

```javascript
const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const paragraphs = autoShape.getTextFrame().getParagraphs();
    const paragraphCount = paragraphs.getCount();
    const targetFont = "Roboto";

    for (let paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++) {
        const portions = paragraphs.get_Item(paragraphIndex).getPortions();
        const portionCount = portions.getCount();

        for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
            const portion = portions.get_Item(portionIndex);
            const portionFormat = portion.getPortionFormat();
            const latinFont = portionFormat.getLatinFont();
            const eastAsianFont = portionFormat.getEastAsianFont();
            const complexScriptFont = portionFormat.getComplexScriptFont();

            if ((latinFont !== null && latinFont.getFontName() === targetFont) ||
                (eastAsianFont !== null && eastAsianFont.getFontName() === targetFont) ||
                (complexScriptFont !== null && complexScriptFont.getFontName() === targetFont)) {
                portionFormat.setKerningMinimalSize(100);
            }
        }
    }

    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

이 설정은 일치하는 텍스트 구간에 커닝이 적용되지 않도록 하여 해당 PowerPoint 전용 동작에 영향을 받는 글꼴에 대해 Aspose.Slides 렌더링을 PowerPoint의 시각적 출력과 맞추는 데 도움이 됩니다.

## **텍스트 글꼴 속성 관리**

글꼴 속성은 [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/paragraphformat/#getDefaultPortionFormat--)을 통해 단락 수준에서 설정하거나 [PortionFormat](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/portionformat/)을 통해 개별 구간에서 설정할 수 있습니다.

다음 코드는 전체 단락에 대해 글꼴 및 텍스트 스타일을 설정합니다: 글꼴 크기, 굵게, 기울임꼴, 점선 밑줄 및 Times New Roman 글꼴을 모든 구간에 적용합니다.

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const defaultPortionFormat = paragraph.getParagraphFormat().getDefaultPortionFormat();

    // 단락에 대한 글꼴 속성을 설정합니다.
    defaultPortionFormat.setFontHeight(12);
    defaultPortionFormat.setFontBold(java.newByte(aspose.slides.NullableBool.True));
    defaultPortionFormat.setFontItalic(java.newByte(aspose.slides.NullableBool.True));
    defaultPortionFormat.setFontUnderline(java.newByte(aspose.slides.TextUnderlineType.Dotted));
    defaultPortionFormat.setLatinFont(new aspose.slides.FontData("Times New Roman"));

    presentation.save("font_properties_for_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

결과:

![단락의 글꼴 속성](font_properties_for_paragraph.png)

다음 코드는 **굵은 글꼴을 가진 텍스트 구간**에 유사한 속성을 적용합니다.

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const portions = paragraph.getPortions();
    const portionCount = portions.getCount();

    for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
        const portion = portions.get_Item(portionIndex);
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            const portionFormat = portion.getPortionFormat();

            // 텍스트 구간에 대한 글꼴 속성을 설정합니다.
            portionFormat.setFontHeight(13);
            portionFormat.setFontItalic(java.newByte(aspose.slides.NullableBool.True));
            portionFormat.setFontUnderline(java.newByte(aspose.slides.TextUnderlineType.Dotted));
            portionFormat.setLatinFont(new aspose.slides.FontData("Times New Roman"));
        }
    }

    presentation.save("font_properties_for_text_portions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

결과:

![텍스트 구간의 글꼴 속성](font_properties_for_text_portions.png)

## **텍스트 회전 설정**

[TextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-)을 사용하여 도형 내 사전 정의된 텍스트 방향을 설정합니다.

다음 코드는 도형 내 텍스트 방향을 `Vertical270`으로 설정하여 텍스트를 **시계 반대 방향으로 90도** 회전시킵니다.

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setTextVerticalType(java.newByte(aspose.slides.TextVerticalType.Vertical270));

    presentation.save("text_rotation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

결과:

![텍스트 회전](text_rotation.png)

## **텍스트 프레임에 대한 사용자 정의 회전 설정**

[TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/textframeformat/#setRotationAngle-float-)을 사용하여 [TextFrame](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/textframe/)에 대한 사용자 정의 회전 각도를 설정합니다.

다음 코드는 도형 내에서 텍스트 프레임을 시계 방향으로 3도 회전시킵니다.

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setRotationAngle(3);

    presentation.save("custom_text_rotation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

결과:

![사용자 정의 텍스트 회전](custom_text_rotation.png)

## **단락의 줄 간격 설정**

Aspose.Slides는 [ParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/paragraphformat/#setSpaceAfter-float-), [ParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/paragraphformat/#setSpaceBefore-float-), 그리고 [ParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/paragraphformat/#setSpaceWithin-float-)을 제공하여 단락 간격을 제어합니다. 사용 방법은 다음과 같습니다:

* 양수 값을 사용하면 줄 높이의 백분율로 줄 간격을 지정합니다.
* 음수 값을 사용하면 포인트 단위로 줄 간격을 지정합니다.

다음 코드는 단락 내 줄 간격을 지정하는 방법을 보여 줍니다.

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    paragraph.getParagraphFormat().setSpaceWithin(200);

    presentation.save("line_spacing.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

결과:

![단락 내 줄 간격](line_spacing.png)

## **텍스트 프레임 자동 맞춤 유형 설정**

[TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/textframeformat/#setAutofitType-byte-)은 텍스트가 컨테이너 경계를 초과했을 때 텍스트가 어떻게 동작할지 결정합니다. 텍스트가 축소, 넘침, 또는 도형을 자동으로 크기 조정하도록 제어하는 데 사용합니다.

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.Shape));

    presentation.save("autofit_type.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **텍스트 프레임 앵커 설정**

[TextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/textframeformat/#setAnchoringType-byte-)은 텍스트가 도형 내부에서 수직으로 어떻게 배치되는지를 정의합니다(예: 위, 중간, 아래).

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setAnchoringType(java.newByte(aspose.slides.TextAnchorType.Bottom));

    presentation.save("text_anchor.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **텍스트 탭 설정**

[ParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/paragraphformat/#setDefaultTabSize-float-)와 [ParagraphFormat.getTabs](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/paragraphformat/#getTabs--)을 사용하여 단락 내 탭 정지를 구성합니다.

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    paragraph.getParagraphFormat().setDefaultTabSize(100);
    paragraph.getParagraphFormat().getTabs().add(30, java.newByte(aspose.slides.TabAlignment.Left));

    presentation.save("paragraph_tabs.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

결과:

![단락 탭](paragraph_tabs.png)

## **맞춤 언어 설정**

Aspose.Slides는 [PortionFormat.setLanguageId](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/baseportionformat/#setLanguageId-java.lang.String-)를 제공하며, 이를 통해 텍스트 구간의 맞춤 언어를 설정할 수 있습니다. 맞춤 언어는 PowerPoint에서 맞춤법 및 문법 검사를 수행할 때 사용되는 언어를 결정합니다.

다음 코드는 텍스트 구간의 맞춤 언어를 설정하는 방법을 보여 줍니다.

```javascript
const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    const font = new aspose.slides.FontData("SimSun");
    const textPortion = new aspose.slides.Portion();
    textPortion.getPortionFormat().setComplexScriptFont(font);
    textPortion.getPortionFormat().setEastAsianFont(font);
    textPortion.getPortionFormat().setLatinFont(font);

    // 맞춤법 검사 언어의 Id를 설정합니다.
    textPortion.getPortionFormat().setLanguageId("zh-CN");

    textPortion.setText("1.");
    paragraph.getPortions().add(textPortion);

    presentation.save("proofing_language.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **기본 언어 설정**

[LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-)을 사용하여 프레젠테이션을 로드하거나 생성할 때 생성되는 텍스트의 기본 언어를 정의합니다.

```javascript
const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

const presentation = new aspose.slides.Presentation(loadOptions);
try {
    const slide = presentation.getSlides().get_Item(0);

    // 텍스트가 포함된 새로운 사각형 도형을 추가합니다.
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 150, 50);
    shape.getTextFrame().setText("Sample text");

    // 첫 번째 구간의 언어를 확인합니다.
    const portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    console.log(portion.getPortionFormat().getLanguageId());
} finally {
    presentation.dispose();
}
```

## **기본 텍스트 스타일 설정**

프레젠테이션 수준에서 기본 텍스트 서식을 적용하려면 [Presentation.getDefaultTextStyle](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation/#getDefaultTextStyle--)을 사용합니다.

다음 코드는 새 프레젠테이션의 모든 슬라이드에 대해 14pt 크기의 굵은 기본 글꼴을 설정하는 방법을 보여 줍니다.

```javascript
const presentation = new aspose.slides.Presentation();
try {
    // 최상위 수준 단락 형식을 가져옵니다.
    const paragraphFormat = presentation.getDefaultTextStyle().getLevel(0);

    if (paragraphFormat !== null) {
        paragraphFormat.getDefaultPortionFormat().setFontHeight(14);
        paragraphFormat.getDefaultPortionFormat().setFontBold(java.newByte(aspose.slides.NullableBool.True));
    }

    presentation.save("default_text_style.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **All-Caps 효과가 적용된 텍스트 추출**

PowerPoint에서 **All Caps** 글꼴 효과를 적용하면 원래 소문자로 입력했더라도 슬라이드에 대문자로 표시됩니다. Aspose.Slides로 해당 텍스트 구간을 가져오면 라이브러리는 입력된 그대로의 텍스트를 반환합니다. 표시된 텍스트와 일치시키려면 [TextCapType](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/textcaptype/)을 확인하고 값이 `All`일 경우 반환된 문자열을 대문자로 변환합니다.

sample2.pptx 파일의 첫 번째 슬라이드에 다음과 같은 텍스트 상자가 있다고 가정합니다.

![All Caps 효과](all_caps_effect.png)

다음 코드는 **All Caps** 효과가 적용된 텍스트를 추출하는 방법을 보여 줍니다.

```javascript
const presentation = new aspose.slides.Presentation("sample2.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const textPortion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);

    console.log("Original text: " + textPortion.getText());

    const textFormat = textPortion.getPortionFormat().getEffective();
    if (textFormat.getTextCapType() === aspose.slides.TextCapType.All) {
        const text = textPortion.getText().toUpperCase();
        console.log("All-Caps effect: " + text);
    }
} finally {
    presentation.dispose();
}
```

출력:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **FAQ**

**슬라이드의 표에서 텍스트를 어떻게 수정합니까?**

슬라이드의 표에서 텍스트를 수정하려면 [Table](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/table/)을 사용합니다. 셀을 순회하면서 각 셀을 [Cell.getTextFrame](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/cell/#getTextFrame--)을 통해 업데이트하고, 단락 서식은 [Paragraph.getParagraphFormat](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/paragraph/#getParagraphFormat--)을 통해 지정합니다.

**PowerPoint 슬라이드의 텍스트에 그라데이션 색을 어떻게 적용합니까?**

그라데이션 색을 텍스트에 적용하려면 [PortionFormat.getFillFormat](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/portionformat/#getFillFormat--)을 사용합니다. [FillFormat.setFillType](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/fillformat/#setFillType-byte-)을 [FillType.Gradient](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/filltype/)으로 설정하고 그라데이션 정지점, 방향 및 투명도를 구성합니다.
---
title: JavaScript에서 프레젠테이션 텍스트 형식 지정
linktitle: 텍스트 서식 지정
type: docs
weight: 50
url: /ko/nodejs-java/text-formatting/
keywords:
- 문단 정렬
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
- 텍스트 프레임 고정점
- 텍스트 탭 설정
- 기본 언어
- PowerPoint
- OpenDocument
- 프레젠테이션
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java를 사용하여 PowerPoint 및 OpenDocument 프레젠테이션에서 텍스트를 형식화하고 스타일을 지정합니다. 글꼴, 색상, 정렬 등을 사용자 정의할 수 있습니다."
---
## **개요**

이 문서는 Aspose.Slides for Node.js via Java를 사용하여 PowerPoint 및 OpenDocument 프레젠테이션에서 텍스트를 서식 지정하는 방법을 보여줍니다. 배경 색, 투명도, 문자 간격, 글꼴 속성, 회전, 문단 간격, 자동 맞춤 동작, 텍스트 고정, 탭 정지 및 언어 설정을 포함합니다.

특별히 명시되지 않는 한, 예제는 [sample.pptx](sample.pptx)을 사용합니다. 첫 번째 슬라이드의 첫 번째 도형은 텍스트 상자이며, 첫 번째 문단에 아래에 표시된 텍스트가 포함됩니다. 슬라이드와 도형 인덱스는 0부터 시작합니다. 굵은 부분을 선택하는 예제는 상속된 굵은 서식을 포함한 유효 서식을 사용합니다:

![샘플 텍스트](sample_text.png)

리터럴 텍스트 또는 정규식 일치를 찾아 강조 표시하려면 [Search and Replace Text](/slides/ko/nodejs-java/search-and-replace-text/)를 참조하십시오.

## **텍스트 배경 색 설정**

문단에 대한 기본 강조 색을 설정하려면 [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#getDefaultPortionFormat)를 사용하고, 개별 텍스트 부분에 대해서는 [BasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#getHighlightColor)를 사용합니다.

다음 예제는 첫 번째 문단의 기본 강조 색을 밝은 회색으로 설정합니다. 개별 부분에 대한 명시적 강조 색은 이 기본값보다 우선합니다:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // 전체 문단에 대한 강조 색을 설정합니다.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getHighlightColor().setColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));

    presentation.save("gray_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

결과:

![회색 문단](gray_paragraph.png)

다음 코드 예제는 **굵은 글꼴이 적용된 텍스트 부분**에 대한 배경 색을 설정하는 방법을 보여줍니다:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const portions = paragraph.getPortions();
    const portionCount = portions.getCount();

    for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
        const portion = portions.get_Item(portionIndex);
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // 텍스트 부분에 대한 강조 색을 설정합니다.
            portion.getPortionFormat().getHighlightColor().setColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));
        }
    }

    presentation.save("gray_text_portions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

결과:

![회색 텍스트 부분](gray_text_portions.png)

## **텍스트 문단 정렬**

텍스트 프레임 내 문단 정렬을 설정하려면 [ParagraphFormat.setAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setAlignment)를 사용합니다. 값은 가운데, 왼쪽 정렬, 오른쪽 정렬, 양쪽 맞춤 등일 수 있습니다.

다음 코드 예제는 문단을 **가운데**에 정렬하는 방법을 보여줍니다:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // 문단의 정렬을 가운데로 설정합니다.
    paragraph.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.Center);

    presentation.save("aligned_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

결과:

![정렬된 문단](aligned_paragraph.png)

## **줄 내 글꼴 정렬**

다른 글꼴 크기의 텍스트 부분을 한 줄 내에서 수직 정렬하려면 [ParagraphFormat.setFontAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setFontAlignment)를 사용합니다. 이 설정은 전체 문단에 적용되며 각 줄 내에서 정렬을 제어합니다.

다음 독립형 예제는 한 슬라이드에 네 개의 라벨이 있는 텍스트 상자를 생성합니다. 각 문단은 18, 36, 54포인트의 동일한 텍스트를 포함하며, 각각 다른 글꼴 정렬을 사용합니다. Arial을 사용하고, 자동 맞춤 및 줄바꿈을 비활성화했으며, 텍스트 프레임을 한 줄에 충분히 크게 유지합니다.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const alignments = [aspose.slides.FontAlignment.Baseline, aspose.slides.FontAlignment.Top, aspose.slides.FontAlignment.Center, aspose.slides.FontAlignment.Bottom];
    const alignmentNames = ["Baseline", "Top", "Center", "Bottom"];
    const fontSizes = [18, 36, 54];

    for (let i = 0; i < alignments.length; i++) {
        const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 30, 20 + i * 130, 660, 120);
        shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

        const textFrame = shape.getTextFrame();
        textFrame.getTextFrameFormat().setAnchoringType(java.newByte(aspose.slides.TextAnchorType.Top));
        textFrame.getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.None));
        textFrame.getTextFrameFormat().setWrapText(java.newByte(aspose.slides.NullableBool.False));

        const label = textFrame.getParagraphs().get_Item(0);
        label.setText(alignmentNames[i]);
        label.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.Left);
        label.getParagraphFormat().getDefaultPortionFormat().setFontHeight(14);
        label.getParagraphFormat().getDefaultPortionFormat().setLatinFont(new aspose.slides.FontData("Arial"));
        label.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        label.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));

        const paragraph = new aspose.slides.Paragraph();
        paragraph.getParagraphFormat().setFontAlignment(alignments[i]);
        paragraph.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.Left);
        paragraph.getParagraphFormat().getDefaultPortionFormat().setLatinFont(new aspose.slides.FontData("Arial"));
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));

        for (const fontSize of fontSizes) {
            const portion = new aspose.slides.Portion("Ag ");
            portion.getPortionFormat().setFontHeight(fontSize);
            paragraph.getPortions().add(portion);
        }

        textFrame.getParagraphs().add(paragraph);
    }

    presentation.save("font_alignment.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

결과:

![Baseline, Top, Center, Bottom 글꼴 정렬 비교](font_alignment.png)

글꼴 정렬은 글꼴 메트릭을 사용하므로 개별 문자 가장자리가 정확히 일치하지 않을 수 있습니다. 예제에는 대문자와 하강자를 모두 포함하여 기준선과 바닥 정렬의 차이를 보여줍니다. 글꼴 가용성 및 대체, 사용된 문자, 글꼴 크기 차이가 결과에 영향을 미칩니다. 프레임 크기, 여백, 줄 간격, 줄바꿈 및 자동 맞춤도 레이아웃에 영향을 주므로 모드를 비교할 때는 동일한 글꼴 및 레이아웃 설정을 사용하십시오.

이 설정은 수평 문단 정렬을 제어하는 [ParagraphFormat.setAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setAlignment) 및 텍스트 블록을 도형 내에서 수직으로 위치시키는 [TextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setAnchoringType)와 다릅니다. [BasePortionFormat.setEscapement](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setEscapement)를 통한 위첨자 및 아래첨자 서식은 개별 부분을 기준선에 대해 이동시키며, 문단 줄의 글꼴 정렬을 설정하지 않습니다.

## **텍스트 투명도 설정**

텍스트 투명도는 [BasePortionFormat.getFillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#getFillFormat)에 할당된 색상의 알파 구성 요소를 통해 제어됩니다. 아래 예제에서 `alpha = 50`은 0–255 범위의 ARGB 알파 채널 값이며, 투명도 백분율이 아닙니다.

다음 코드 예제는 **전체 문단**에 투명도를 적용하는 방법을 보여줍니다:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const alpha = 50;
const transparentBlack = java.newInstanceSync("java.awt.Color", 0, 0, 0, alpha);
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
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

![투명한 문단](transparent_paragraph.png)

다음 코드 예제는 **굵은 글꼴이 적용된 텍스트 부분**에 투명도를 적용하는 방법을 보여줍니다:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const alpha = 50;
const transparentBlack = java.newInstanceSync("java.awt.Color", 0, 0, 0, alpha);
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const portions = paragraph.getPortions();
    const portionCount = portions.getCount();

    for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
        const portion = portions.get_Item(portionIndex);
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            const fillFormat = portion.getPortionFormat().getFillFormat();

            // 텍스트 부분의 투명도를 설정합니다.
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

![투명한 텍스트 부분](transparent_text_portions.png)

## **텍스트 문자 간격 설정**

텍스트 상자 내 문자 사이 간격을 확대하거나 축소하려면 [BasePortionFormat.setSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setSpacing)를 사용합니다. 예제에서는 3포인트 간격을 추가합니다; 음수 값은 텍스트를 압축합니다.

다음 JavaScript 코드는 **전체 문단**의 문자 간격을 확대하는 방법을 보여줍니다:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // 참고: 문자 간격을 압축하려면 음수 값을 사용하세요.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3); // 문자 간격을 확대합니다.

    presentation.save("character_spacing_in_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

결과:

![문단 내 문자 간격](character_spacing_in_paragraph.png)

다음 코드 예제는 **굵은 글꼴이 적용된 텍스트 부분**의 문자 간격을 확대하는 방법을 보여줍니다:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const portions = paragraph.getPortions();
    const portionCount = portions.getCount();

    for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
        const portion = portions.get_Item(portionIndex);
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // 참고: 문자 간격을 압축하려면 음수 값을 사용하세요.
            portion.getPortionFormat().setSpacing(3); // 문자 간격을 확대합니다.
        }
    }

    presentation.save("character_spacing_in_text_portions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

결과:

![텍스트 부분 내 문자 간격](character_spacing_in_text_portions.png)

### **특정 글꼴에 대한 커닝 비활성화**

일부 경우 Aspose.Slides로 렌더링된 텍스트가 PowerPoint에서 표시되는 텍스트보다 약간 더 조밀하게 보일 수 있습니다. 이는 PowerPoint가 특정 글꼴에 대해 커닝 데이터를 무시할 수 있기 때문이며, 글꼴에 유효한 커닝 정보가 포함되어 있고 PowerPoint 설정에서 커닝이 활성화되어 있어도 발생합니다.

이러한 경우 PowerPoint와 더 가깝게 렌더링하려면 영향을 받는 글꼴을 사용하는 텍스트 부분에 대해 커닝을 비활성화할 수 있습니다. [BasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setKerningMinimalSize)를 실제 글꼴 크기보다 큰 값으로 설정하십시오. 이 예제는 첫 번째 슬라이드의 첫 번째 도형이 텍스트 상자인 "presentation.pptx"를 필요로 합니다. 상속된 글꼴을 포함한 유효 글꼴 이름을 확인하고 Roboto를 사용하는 부분에 대해 100포인트 임계값을 설정합니다. 이 설정은 100포인트 미만의 크기를 가진 해당 부분에 대해 커닝을 비활성화합니다:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraphs = autoShape.getTextFrame().getParagraphs();
    const paragraphCount = paragraphs.getCount();
    const targetFont = "Roboto";

    for (let paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++) {
        const portions = paragraphs.get_Item(paragraphIndex).getPortions();
        const portionCount = portions.getCount();

        for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
            const portion = portions.get_Item(portionIndex);
            const portionFormat = portion.getPortionFormat().getEffective();
            const latinFont = portionFormat.getLatinFont();
            const eastAsianFont = portionFormat.getEastAsianFont();
            const complexScriptFont = portionFormat.getComplexScriptFont();

            if ((latinFont !== null && latinFont.getFontName() === targetFont) ||
                (eastAsianFont !== null && eastAsianFont.getFontName() === targetFont) ||
                (complexScriptFont !== null && complexScriptFont.getFontName() === targetFont)) {
                portion.getPortionFormat().setKerningMinimalSize(100);
            }
        }
    }

    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

임계값 이하의 일치하는 텍스트에 대해 이 설정은 커닝을 방지하고, PowerPoint 특유의 동작으로 영향을 받는 글꼴에 대해 Aspose.Slides 렌더링을 PowerPoint 시각 출력에 맞추는 데 도움이 될 수 있습니다.

## **텍스트 글꼴 속성 관리**

글꼴 속성은 [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#getDefaultPortionFormat)를 통해 문단 수준에서 설정하거나, [PortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portionformat/)을 통해 개별 부분에 설정할 수 있습니다.

다음 예제는 첫 번째 문단의 기본 글꼴을 12포인트 Times New Roman, 굵게, 기울임꼴, 점선 밑줄 형식으로 설정합니다. 개별 부분에 대한 명시적 서식은 이러한 기본값보다 우선합니다.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const defaultPortionFormat = paragraph.getParagraphFormat().getDefaultPortionFormat();

    // 문단에 대한 글꼴 속성을 설정합니다.
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

![문단의 글꼴 속성](font_properties_for_paragraph.png)

다음 예제는 굵게 적용된 유효 서식을 가진 부분에 대해 13포인트 Times New Roman, 기울임꼴 및 점선 밑줄을 적용합니다:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const portions = paragraph.getPortions();
    const portionCount = portions.getCount();

    for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
        const portion = portions.get_Item(portionIndex);
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            const portionFormat = portion.getPortionFormat();

            // 텍스트 부분에 대한 글꼴 속성을 설정합니다.
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

![텍스트 부분의 글꼴 속성](font_properties_for_text_portions.png)

## **텍스트 높이 정규화 제어**

템플릿 타이포그래피를 재현하거나 문자 높이 차이를 조사할 때는 [BasePortionFormat.setNormaliseHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setNormaliseHeight)를 사용합니다. PowerPoint에서 정규화를 활성화하면 개별 문자가 수직으로 늘어나거나 압축되어 텍스트 부분 내에서 균일한 보이는 높이를 갖게 됩니다. 이는 서로 다른 글꼴 간에 동일한 텍스트 높이를 보장하지는 않습니다.

정규화를 명시적으로 활성화하거나 비활성화하려면 [NullableBool.True 또는 False](https://reference.aspose.com/slides/nodejs-java/aspose.slides/nullablebool/)를 설정합니다. `NullableBool.NotDefined`는 로컬 설정을 지정하지 않아 부분이 문단의 [getDefaultPortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) 등에서 값을 상속하도록 합니다. 이는 `False`와 같은 의미가 아닙니다. 해결된 부울 값을 얻으려면 [PortionFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portionformat/#getEffective)와 [IBasePortionFormatEffectiveData.getNormaliseHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformateffectivedata/#getNormaliseHeight--)를 사용하십시오.

다음 자체 포함 예제는 **Arial**이 설치되어 있어야 합니다. 54포인트 크기의 동일한 대문자, 소문자, 하강자 및 억양 문자를 포함하는 두 개의 텍스트 블록을 생성합니다. 두 문단 모두 기본적으로 정규화를 활성화합니다. 위쪽 부분은 명시적으로 비활성화하고, 아래쪽 부분은 상속받습니다. 프레임 크기, 여백 및 문단 간격은 동일하고, 줄바꿈 및 자동 맞춤은 비활성화하여 비교를 일관되게 유지합니다. 예제는 `False: false`와 `NotDefined: true`를 출력한 후 "text_height_normalization.pptx"로 저장합니다.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const settings = [aspose.slides.NullableBool.False, aspose.slides.NullableBool.NotDefined];
    const settingNames = ["False", "NotDefined"];

    for (let i = 0; i < settings.length; i++) {
        const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 30, 60 + i * 200, 660, 150);
        shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

        const textFrame = shape.getTextFrame();
        textFrame.setText("Hxgjpq ÅÉ 0123");
        textFrame.getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.None));
        textFrame.getTextFrameFormat().setWrapText(java.newByte(aspose.slides.NullableBool.False));
        textFrame.getTextFrameFormat().setAnchoringType(java.newByte(aspose.slides.TextAnchorType.Top));
        textFrame.getTextFrameFormat().setMarginTop(0);
        textFrame.getTextFrameFormat().setMarginLeft(0);

        const paragraph = textFrame.getParagraphs().get_Item(0);
        paragraph.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.Left);
        paragraph.getParagraphFormat().setSpaceBefore(0);
        paragraph.getParagraphFormat().setSpaceAfter(0);
        paragraph.getParagraphFormat().setSpaceWithin(100);
        paragraph.getParagraphFormat().getDefaultPortionFormat().setNormaliseHeight(java.newByte(aspose.slides.NullableBool.True));

        const portion = paragraph.getPortions().get_Item(0);
        const font = new aspose.slides.FontData("Arial");
        portion.getPortionFormat().setLatinFont(font);
        portion.getPortionFormat().setFontHeight(54);
        portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        const textColor = java.getStaticFieldValue("java.awt.Color", "BLACK");
        portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(textColor);
        portion.getPortionFormat().setNormaliseHeight(java.newByte(settings[i]));

        console.log(settingNames[i] + ": " + portion.getPortionFormat().getEffective().getNormaliseHeight());
    }

    presentation.save("text_height_normalization.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

아래 비교 이미지는 저장된 프레젠테이션에서 내보낸 것입니다. 위 행은 정규화가 비활성화된(`False`) 상태이고, 아래 행은 상속된 설정(`NotDefined` → `True`)이 활성화된 상태입니다. 이 모양을 재현하려면 Arial이 설치되어 있어야 합니다.

![Arial 54포인트 텍스트, 위쪽은 정규화 비활성화, 아래쪽은 상속된 정규화 활성화](text_height_normalization.png)

정규화는 할당된 [getFontHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#getFontHeight) 값을 변경하지 않고 문자 높이만 변경합니다. 문단 [setSpaceWithin](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setSpaceWithin)은 줄 간격을 제어하고, 텍스트 프레임 [setAutofitType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setAutofitType)은 텍스트나 컨테이너가 맞추는 방식을 제어합니다. 이 설정들은 서로 다른 목적을 가지며 전체 레이아웃에 독립적으로 영향을 줄 수 있습니다. 문단 서식 및 상속에 대한 자세한 내용은 [Manage Paragraph](/slides/ko/nodejs-java/manage-paragraph/)를 참조하십시오.

## **취소선 적용 및 제거**

텍스트 부분에 [BasePortionFormat.setStrikethroughType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setStrikethroughType)를 사용하면 원본 텍스트를 삭제하지 않고 수정, 취소된 용어 또는 이전 가격을 표시할 수 있습니다. [TextStrikethroughType.Single 또는 Double](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textstrikethroughtype/)을 설정하면 텍스트에 한 줄 또는 두 줄이 그어집니다.

취소선을 제거하려면 [TextStrikethroughType.None](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textstrikethroughtype/#None)을 전달하십시오. 이렇게 하면 주변 서식이 취소선을 지정하더라도 효과가 명시적으로 비활성화됩니다. 반면에 [TextStrikethroughType.NotDefined](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textstrikethroughtype/#NotDefined)는 로컬 설정을 정의하지 않아 문단 등에서 서식을 상속받게 합니다. 이는 취소선이 반드시 제거된다는 보장은 아닙니다. 최종 서식을 읽으려면 [PortionFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portionformat/#getEffective)를 사용하십시오.

다음 자체 포함 예제는 세 개의 가격 비교를 만듭니다. 각 문단은 라벨, 이전 가격, 현재 가격에 대한 개별 부분을 가지고 있어 이전 가격에만 취소선이 적용됩니다. 첫 번째 행은 취소선을 적용한 후 제거하고, 다른 행은 각각 단일 및 이중 취소선을 유지합니다. 이 설정을 변경하면 텍스트와 다른 서식(예: 굵은 이전 가격)을 유지할 수 있습니다.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 620, 220);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getTextFrame().getParagraphs().clear();

    const labels = ["None: ", "Single: ", "Double: "];

    for (const label of labels) {
        const paragraph = new aspose.slides.Paragraph();
        paragraph.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.Left);
        paragraph.getParagraphFormat().setSpaceAfter(20);

        const format = paragraph.getParagraphFormat().getDefaultPortionFormat();
        format.setFontHeight(28);
        const font = new aspose.slides.FontData("Arial");
        format.setLatinFont(font);
        format.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        const textColor = java.getStaticFieldValue("java.awt.Color", "BLACK");
        format.getFillFormat().getSolidFillColor().setColor(textColor);

        const labelPortion = new aspose.slides.Portion(label);
        paragraph.getPortions().add(labelPortion);

        const previousPrice = new aspose.slides.Portion("$100");
        previousPrice.getPortionFormat().setFontBold(java.newByte(aspose.slides.NullableBool.True));
        paragraph.getPortions().add(previousPrice);
        const currentPrice = new aspose.slides.Portion(" → $80");
        paragraph.getPortions().add(currentPrice);

        shape.getTextFrame().getParagraphs().add(paragraph);
    }

    const paragraphs = shape.getTextFrame().getParagraphs();

    // 취소선을 적용하고, 첫 번째 이전 가격에서 명시적으로 제거합니다.
    paragraphs.get_Item(0).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(java.newByte(aspose.slides.TextStrikethroughType.Single));
    paragraphs.get_Item(0).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(java.newByte(aspose.slides.TextStrikethroughType.None));

    paragraphs.get_Item(1).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(java.newByte(aspose.slides.TextStrikethroughType.Single));
    paragraphs.get_Item(2).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(java.newByte(aspose.slides.TextStrikethroughType.Double));

    presentation.save("strikethrough.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

결과(위에서 아래 순서): 취소선 없음, 단일 취소선, 이중 취소선.

![취소선이 없는 이전 가격, 단일 취소선이 있는 이전 가격, 이중 취소선이 있는 이전 가격](strikethrough.png)

## **텍스트 회전 설정**

[TextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType)를 사용하여 도형 내 미리 정의된 텍스트 방향을 설정합니다.

다음 코드 예제는 텍스트 방향을 [TextVerticalType.Vertical270](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textverticaltype/)으로 설정합니다. 이는 텍스트를 **시계 반대 방향으로 90도** 회전합니다:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    autoShape.getTextFrame().getTextFrameFormat().setTextVerticalType(java.newByte(aspose.slides.TextVerticalType.Vertical270));

    presentation.save("text_rotation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

결과:

![텍스트 회전](text_rotation.png)

## **텍스트 프레임에 대한 사용자 정의 회전 설정**

[TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setRotationAngle)를 사용하여 [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/)에 대한 사용자 정의 회전 각도를 설정합니다.

다음 코드 예제는 도형 내 텍스트 프레임을 시계 방향으로 3도 회전합니다:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    autoShape.getTextFrame().getTextFrameFormat().setRotationAngle(3);

    presentation.save("custom_text_rotation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

결과:

![사용자 정의 텍스트 회전](custom_text_rotation.png)

## **문단 줄 간격 설정**

Aspose.Slides는 [ParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setSpaceAfter), [ParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setSpaceBefore) 및 [ParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setSpaceWithin)를 제공하여 문단 간격을 제어합니다. 사용 방법은 다음과 같습니다:

* 양수 값을 사용하면 줄 높이의 백분율로 줄 간격을 지정합니다.
* 음수 값을 사용하면 포인트 단위로 줄 간격을 지정합니다.

다음 예제는 첫 번째 문단의 내부 간격을 줄 높이의 200%(두 배)로 설정합니다:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);

    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getParagraphFormat().setSpaceWithin(200);

    presentation.save("line_spacing.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

결과:

![문단 내부의 줄 간격](line_spacing.png)

## **줄 바꿈 제어**

문단 줄 바꿈 규칙은 좁은 텍스트 블록 및 라틴어와 동아시아어가 혼합된 프레젠테이션에서 유용합니다. 다음 메서드들은 [ParagraphFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/)에 속하므로 전체 문단에 적용됩니다:

- [setLatinLineBreak](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setLatinLineBreak) 은 라틴어 줄 바꿈 규칙을 제어합니다. 혼합 텍스트에서 이를 변경하면 인접한 동아시아어 텍스트 및 구두점의 줄 바꿈 위치도 변경될 수 있습니다.
- [setEastAsianLineBreak](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setEastAsianLineBreak) 은 동아시아어 줄 바꿈 규칙을 제어하며, 줄 시작 및 끝에 허용되지 않는 문자에 대한 제한을 포함합니다.

이 규칙들은 [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setWrapText)를 대체하지 않으며, 자동 줄 바꿈을 활성화합니다. 줄 바꿈이 발생할 때 레이아웃에 영향을 주지만, 줄 바꿈 문자를 삽입하지는 않습니다. 명시적 줄 바꿈은 가용 너비와 무관하게 문단 내에 새 줄을 강제로 삽입합니다.

다음 자체 포함 예제는 중국어와 라틴어 텍스트가 포함된 좁은 텍스트 블록을 생성합니다. 두 줄 바꿈 옵션을 모두 명시적으로 설정하고 "line_breaking.pptx"로 저장합니다. 규칙 중 하나를 실험하려면 다른 설정은 그대로 두고 해당 값을 변경하십시오. 예제는 24포인트 Arial 및 SimSun을 사용하고, 프레임 너비를 160포인트, 텍스트 프레임 수평 여백을 0으로 설정합니다. [TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setAutofitType)을 [TextAutofitType.None](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textautofittype/)으로 호출하여 텍스트 크기와 프레임 크기를 고정합니다.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 160, 300);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    const textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setWrapText(java.newByte(aspose.slides.NullableBool.True));
    textFrame.getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.None));
    textFrame.getTextFrameFormat().setMarginLeft(0);
    textFrame.getTextFrameFormat().setMarginRight(0);

    const paragraph = textFrame.getParagraphs().get_Item(0);
    paragraph.setText("中文排版测试，PowerPoint 中文演示。");

    const format = paragraph.getParagraphFormat();
    format.setAlignment(aspose.slides.TextAlignment.Left);
    format.getDefaultPortionFormat().setFontHeight(24);
    const latinFont = new aspose.slides.FontData("Arial");
    format.getDefaultPortionFormat().setLatinFont(latinFont);
    const eastAsianFont = new aspose.slides.FontData("SimSun");
    format.getDefaultPortionFormat().setEastAsianFont(eastAsianFont);
    format.getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const textColor = java.getStaticFieldValue("java.awt.Color", "BLACK");
    format.getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(textColor);
    format.setLatinLineBreak(java.newByte(aspose.slides.NullableBool.False));
    format.setEastAsianLineBreak(java.newByte(aspose.slides.NullableBool.True));

    presentation.save("line_breaking.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **매달린 구두점 제어**

[ParagraphFormat.setHangingPunctuation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setHangingPunctuation)는 해당 구두점이 텍스트 라인의 오른쪽 가장자리를 넘어 확장되도록 허용하며, 다음 줄을 차지하지 않게 합니다. 이는 전체 문단에 적용되며 매달린 들여쓰기와는 다릅니다.

다음 자체 포함 예제는 100포인트 너비 텍스트 프레임에서 매달린 구두점을 활성화하고 "hanging_punctuation.pptx"로 저장합니다. 24포인트 Arial과 수평 여백 0을 사용하면 마지막 마침표가 "sentence" 뒤에 남아 오른쪽 텍스트 가장자리 밖으로 뻗습니다. 속성을 [NullableBool.False](https://reference.aspose.com/slides/nodejs-java/aspose.slides/nullablebool/)로 설정하면 비교할 수 있습니다: 이 설정에서는 마침표가 별도의 줄에 위치합니다. 줄 바꿈은 활성화하고 자동 맞춤은 비활성화하여 가용 너비를 고정합니다.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 100, 200);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    const textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setWrapText(java.newByte(aspose.slides.NullableBool.True));
    textFrame.getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.None));
    textFrame.getTextFrameFormat().setMarginLeft(0);
    textFrame.getTextFrameFormat().setMarginRight(0);

    const paragraph = textFrame.getParagraphs().get_Item(0);
    paragraph.setText("Simple text, next sentence.");

    const format = paragraph.getParagraphFormat();
    format.setAlignment(aspose.slides.TextAlignment.Left);
    format.getDefaultPortionFormat().setFontHeight(24);
    const latinFont = new aspose.slides.FontData("Arial");
    format.getDefaultPortionFormat().setLatinFont(latinFont);
    format.getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const textColor = java.getStaticFieldValue("java.awt.Color", "BLACK");
    format.getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(textColor);
    format.setHangingPunctuation(java.newByte(aspose.slides.NullableBool.True));

    presentation.save("hanging_punctuation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

모든 구두점이 매달릴 수 있는 것은 아닙니다. 위에서 설명한 [글꼴 및 레이아웃 조건](#control-line-breaking)도 이 비교에 적용됩니다: 글꼴, 가용 너비, 여백 또는 자동 맞춤 설정을 변경하면 가시적인 차이가 사라질 수 있습니다.

## **텍스트 프레임 자동 맞춤 유형 설정**

[TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setAutofitType)는 텍스트가 컨테이너 경계를 초과할 때 동작 방식을 결정합니다. 텍스트가 축소, 넘침 또는 도형이 자동으로 크기를 조정하도록 제어할 수 있습니다. 다음 예제는 텍스트에 맞추도록 도형을 크기 조정하도록 구성하고 결과를 "autofit_type.pptx"로 저장합니다.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    autoShape.getTextFrame().getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.Shape));

    presentation.save("autofit_type.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

자동 줄 바꿈 후 라인 수를 세고 텍스트 또는 도형 너비가 결과에 어떻게 영향을 미치는지 보려면 [Count Rendered Lines](/slides/ko/nodejs-java/manage-paragraph/)를 참조하십시오. 라인 수만으로 텍스트가 컨테이너를 초과하는지 여부를 판단할 수 없습니다.

## **텍스트 프레임 고정점 설정**

[TextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setAnchoringType)는 텍스트가 도형 내부에서 수직으로 어떻게 배치되는지를 정의합니다(예: 위, 중간, 아래). 다음 예제는 첫 번째 도형의 텍스트를 아래쪽에 고정하고 결과를 "text_anchor.pptx"로 저장합니다.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    autoShape.getTextFrame().getTextFrameFormat().setAnchoringType(java.newByte(aspose.slides.TextAnchorType.Bottom));

    presentation.save("text_anchor.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **텍스트 탭 설정**

[ParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setDefaultTabSize)와 [ParagraphFormat.getTabs](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#getTabs)를 사용하여 문단의 탭 정지를 구성합니다. 다음 예제는 기본 탭 간격을 100포인트로 설정하고 30포인트에 왼쪽 정렬 탭 정지를 추가합니다. 이러한 설정은 탭 문자를 포함하는 텍스트에 영향을 미칩니다.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);

    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getParagraphFormat().setDefaultTabSize(100);
    paragraph.getParagraphFormat().getTabs().add(30, java.newByte(aspose.slides.TabAlignment.Left));

    presentation.save("paragraph_tabs.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

결과:

![문단 탭](paragraph_tabs.png)

## **교정 언어 설정**

Aspose.Slides는 [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setLanguageId)를 제공하여 텍스트 부분의 교정 언어를 설정할 수 있습니다. 교정 언어는 PowerPoint에서 맞춤법 및 문법 검사를 수행할 때 사용되는 언어를 결정합니다.

다음 예제는 첫 번째 슬라이드의 첫 번째 도형이 텍스트 상자인 "presentation.pptx"와 최소 하나의 문단이 필요합니다. 첫 번째 문단의 내용을 "1。"로 교체하고, 글꼴을 SimSun으로 설정하고, 교정 언어를 Simplified Chinese(`zh-CN`)로 지정합니다. 결과는 "proofing_language.pptx"로 저장됩니다:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);

    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    const font = new aspose.slides.FontData("SimSun");
    const textPortion = new aspose.slides.Portion();
    textPortion.getPortionFormat().setComplexScriptFont(font);
    textPortion.getPortionFormat().setEastAsianFont(font);
    textPortion.getPortionFormat().setLatinFont(font);

    // 교정 언어의 Id를 설정합니다.
    textPortion.getPortionFormat().setLanguageId("zh-CN");

    textPortion.setText("1。");
    paragraph.getPortions().add(textPortion);

    presentation.save("proofing_language.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **언어 메타데이터 복사**

템플릿에서 다국어 텍스트를 복사할 때는 [BasePortionFormat.getLanguageId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#getLanguageId)와 [BasePortionFormat.getAlternativeLanguageId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#getAlternativeLanguageId)를 모두 보존하십시오. 다음 자체 포함 예제는 소스 부분에 미국 영어를 기본 언어로, 프랑스어를 대체 언어로 설정하고, 텍스트와 식별자를 새 프레젠테이션의 부분에 복사합니다.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const source = new aspose.slides.Portion("Hello! Bonjour!");
source.getPortionFormat().setLanguageId("en-US");
source.getPortionFormat().setAlternativeLanguageId("fr-FR");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 80);
    const paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    const destination = new aspose.slides.Portion();
    destination.setText(source.getText());
    destination.getPortionFormat().setLanguageId(source.getPortionFormat().getLanguageId());
    // 소스에 대체 언어가 없으면 null이 대상값을 지웁니다.
    destination.getPortionFormat().setAlternativeLanguageId(source.getPortionFormat().getAlternativeLanguageId());
    paragraph.getPortions().add(destination);

    presentation.save("copied_language_metadata.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

대체 언어 없이 소스를 사용하려면 `"fr-FR"` 할당을 생략하십시오. 이 경우 대체 식별자는 `null`이며, 복사 문장은 대상에 이전에 대체 언어가 할당되어 있더라도 기본값을 도입하지 않고 그 부재를 그대로 유지합니다.

이 식별자들은 언어 메타데이터를 저장합니다. 이를 보존한다고 해서 PowerPoint가 맞춤법 또는 문법 검사에 사용할 사전을 지정하는 것은 아닙니다.

## **기본 언어 설정**

[LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/#setDefaultTextLanguage)를 사용하여 프레젠테이션을 로드하거나 생성할 때 만든 텍스트의 기본 언어를 정의합니다. 다음 예제는 기본 텍스트 언어를 미국 영어로 설정하고 텍스트 상자를 추가한 뒤 첫 번째 텍스트 부분에 대해 `en-US`를 출력합니다.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

const presentation = new aspose.slides.Presentation(loadOptions);
try {
    const slide = presentation.getSlides().get_Item(0);

    // 텍스트가 있는 새 사각형 도형을 추가합니다.
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 150, 50);
    shape.getTextFrame().setText("Sample text");

    // 첫 번째 부분의 언어를 확인합니다.
    const portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    console.log(portion.getPortionFormat().getLanguageId());
} finally {
    presentation.dispose();
}
```

## **기본 텍스트 스타일 설정**

프레젠테이션 수준에서 기본 텍스트 서식을 적용하려면 [Presentation.getDefaultTextStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getDefaultTextStyle)를 사용합니다.

다음 예제는 새 프레젠테이션의 최상위 문단에 대해 14포인트 굵은 글꼴을 기본값으로 설정하고 "default_text_style.pptx"로 저장합니다. 보다 구체적인 서식이 없으면 텍스트는 이러한 기본값을 상속받을 수 있습니다.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    // 최상위 수준 문단 형식을 가져옵니다.
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

PowerPoint에서 **All Caps** 글꼴 효과를 적용하면 슬라이드에 텍스트가 대문자로 표시되지만, 실제 입력된 문자열은 그대로 유지됩니다. Aspose.Slides로 해당 텍스트 부분을 검색하면 입력된 그대로 반환됩니다. 표시된 텍스트와 일치시키려면 [TextCapType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textcaptype/)을 확인하고 값이 `All`인 경우 반환된 문자열을 대문자로 변환하십시오.

이 예제는 첫 번째 슬라이드의 첫 번째 도형이 텍스트 상자인 "sample2.pptx"를 필요로 합니다. 첫 번째 문단의 첫 번째 부분에 All Caps 효과가 적용된 "Hello, Aspose!"가 포함되어 있습니다(아래 이미지 참조).

![All Caps 효과](all_caps_effect.png)

다음 코드 예제는 **All Caps** 효과가 적용된 텍스트를 추출하는 방법을 보여줍니다:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("sample2.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    
    const autoShape = slide.getShapes().get_Item(0);
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

슬라이드의 표에서 텍스트를 수정하려면 [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/)을 사용하십시오. 셀을 반복하면서 [Cell.getTextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#getTextFrame)으로 각 셀을 업데이트하고, [Paragraph.getParagraphFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/#getParagraphFormat)으로 문단 서식을 업데이트하십시오.

**PowerPoint 슬라이드의 텍스트에 그라디언트 색을 어떻게 적용합니까?**

텍스트에 그라디언트 색을 적용하려면 [BasePortionFormat.getFillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#getFillFormat)를 사용하십시오. [FillFormat.setFillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/#setFillType)을 [FillType.Gradient](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/)으로 설정하고, 그라디언트 스톱, 방향 및 투명도를 구성하십시오.
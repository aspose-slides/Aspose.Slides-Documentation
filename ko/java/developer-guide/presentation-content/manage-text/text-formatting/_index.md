---
title: Java에서 프레젠테이션 텍스트 서식 지정
linktitle: 텍스트 서식 지정
type: docs
weight: 50
url: /ko/java/text-formatting/
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
- 행 간격
- 자동 맞춤 속성
- 텍스트 프레임 고정점
- 텍스트 탭 설정
- 기본 언어
- PowerPoint
- OpenDocument
- 프레젠테이션
- Java
- Aspose.Slides
description: "Aspose.Slides for Java를 사용하여 PowerPoint 및 OpenDocument 프레젠테이션의 텍스트를 서식 지정하고 스타일을 적용합니다. 글꼴, 색상, 정렬 등을 사용자 정의합니다."
---
## **개요**

이 문서에서는 Aspose.Slides for Java를 사용하여 PowerPoint 및 OpenDocument 프레젠테이션에서 텍스트를 서식 지정하는 방법을 보여줍니다. 강조 표시, 배경 색, 투명도, 문자 간격, 글꼴 속성, 회전, 단락 간격, 자동 맞춤 동작, 텍스트 고정, 탭 정지 및 언어 설정을 다룹니다.

아래 예제에서는 첫 번째 슬라이드에 단일 텍스트 상자가 포함된 "sample.pptx" 파일을 사용합니다.

![Sample text](sample_text.png)

## **텍스트 강조 표시**

텍스트 프레임에서 특정 샘플과 일치하는 텍스트를 강조 표시해야 할 때는 [ITextFrame.highlightText](https://reference.aspose.com/slides/ko/java/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.awt.Color-) 메서드를 사용합니다. 이 메서드는 일치하는 텍스트 조각에 강조 색을 적용하며, [TextSearchOptions](https://reference.aspose.com/slides/ko/java/com.aspose.slides/textsearchoptions/)와 함께 사용하여 예를 들어 전체 단어만 일치시키는 등 검색 방식을 제어할 수 있습니다.

아래 코드 예제는 **"try"** 문자를 모두 강조 표시한 다음 **"to"** 전체 단어만 강조 표시합니다.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    // 첫 번째 슬라이드에서 첫 번째 도형을 가져옵니다.
    IAutoShape shape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // 도형에서 "try" 단어를 강조 표시합니다.
    shape.getTextFrame().highlightText("try", Color.LIGHT_GRAY);

    TextSearchOptions searchOptions = new TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);

    // 도형에서 "to" 단어를 강조 표시합니다.
    shape.getTextFrame().highlightText("to", Color.MAGENTA, searchOptions, null);

    presentation.save("highlighted_text.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

결과:

![The highlighted text](highlighted_text.png)

## **정규식으로 텍스트 강조 표시**

[ITextFrame.highlightRegex](https://reference.aspose.com/slides/ko/java/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) 메서드는 정규식으로 찾은 텍스트 일치를 강조 표시합니다. Java에서는 이 API가 [ITextFrame](https://reference.aspose.com/slides/ko/java/com.aspose.slides/itextframe/)에 노출됩니다.

아래 코드 예제는 **일곱 글자 이상**인 모든 단어를 강조 표시합니다.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape shape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    java.util.regex.Pattern regex = java.util.regex.Pattern.compile("\\b[^\\s]{7,}\\b");

    // 7자 이상인 모든 단어를 강조 표시합니다.
    shape.getTextFrame().highlightRegex(regex, Color.YELLOW, null);

    presentation.save("highlighted_text_using_regex.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

결과:

![The highlighted text using the regular expression](highlighted_text_using_regex.png)

## **텍스트 배경 색 설정**

단락의 기본 강조 색을 설정하려면 [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--)을 사용하고, 개별 텍스트 부분에 대해서는 [IBasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ibaseportionformat/#getHighlightColor--)을 사용합니다.

다음 코드 예제는 **전체 단락**의 배경 색을 설정하는 방법을 보여줍니다.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // 전체 단락에 대한 강조 색을 설정합니다.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getHighlightColor().setColor(Color.LIGHT_GRAY);

    presentation.save("gray_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

결과:

![The gray paragraph](gray_paragraph.png)

아래 코드 예제는 **굵은 글꼴을 가진 텍스트 부분**의 배경 색을 설정하는 방법을 보여줍니다.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // 텍스트 부분에 대한 강조 색을 설정합니다.
            portion.getPortionFormat().getHighlightColor().setColor(Color.LIGHT_GRAY);
        }
    }

    presentation.save("gray_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

결과:

![The gray text portions](gray_text_portions.png)

## **텍스트 단락 정렬**

[IParagraphFormat.setAlignment](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iparagraphformat/#setAlignment-int-)을 사용하여 텍스트 프레임 내 단락 정렬을 설정합니다. 값은 가운데, 왼쪽 정렬, 오른쪽 정렬, 양쪽 맞춤 등으로 지정할 수 있습니다.

다음 코드 예제는 단락을 **가운데** 정렬하는 방법을 보여줍니다.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // 단락의 정렬을 가운데로 설정합니다.
    paragraph.getParagraphFormat().setAlignment(TextAlignment.Center);

    presentation.save("aligned_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

결과:

![The aligned paragraph](aligned_paragraph.png)

## **텍스트 투명도 설정**

텍스트 투명도는 [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ibaseportionformat/#getFillFormat--)에 할당된 색상의 알파 구성 요소를 통해 제어됩니다. 아래 예제에서 `alpha = 50`은 0-255 스케일의 ARGB 알파 채널 값이며, 투명도 비율이 아닙니다.

아래 코드 예제는 **전체 단락**에 투명도를 적용하는 방법을 보여줍니다.

```java
int alpha = 50;

Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // 텍스트의 채우기 색상을 투명 색으로 설정합니다.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(new Color(0, 0, 0, alpha));

    presentation.save("transparent_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

결과:

![The transparent paragraph](transparent_paragraph.png)

다음 코드 예제는 **굵은 글꼴을 가진 텍스트 부분**에 투명도를 적용하는 방법을 보여줍니다.

```java
int alpha = 50;

Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // 텍스트 부분의 투명도를 설정합니다.
            portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
            portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(new Color(0, 0, 0, alpha));
        }
    }

    presentation.save("transparent_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

결과:

![The transparent text portions](transparent_text_portions.png)

## **텍스트 문자 간격 설정**

[IBasePortionFormat.setSpacing](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ibaseportionformat/#setSpacing-float-)을 사용하여 텍스트 상자 내부 문자 간격을 확장하거나 축소합니다.

다음 Java 코드는 **전체 단락**의 문자 간격을 확장하는 방법을 보여줍니다.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // 참고: 문자 간격을 압축하려면 음수 값을 사용합니다.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3); // 문자 간격을 확장합니다.

    presentation.save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

결과:

![The character spacing in the paragraph](character_spacing_in_paragraph.png)

아래 코드 예제는 **굵은 글꼴을 가진 텍스트 부분**의 문자 간격을 확장하는 방법을 보여줍니다.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // 참고: 문자 간격을 압축하려면 음수 값을 사용합니다.
            portion.getPortionFormat().setSpacing(3); // 문자 간격을 확장합니다.
        }
    }

    presentation.save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

결과:

![The character spacing in the text portions](character_spacing_in_text_portions.png)

### **특정 글꼴에 대한 커닝 비활성화**

경우에 따라 Aspose.Slides가 렌더링한 텍스트가 PowerPoint에서 표시되는 동일한 텍스트보다 약간 더 촘촘해 보일 수 있습니다. 이는 PowerPoint가 특정 글꼴에 대한 커닝 데이터를 무시할 수 있기 때문이며, 글꼴에 유효한 커닝 정보가 포함되어 있고 PowerPoint 설정에서 커닝이 활성화되어 있어도 발생합니다.

이러한 경우 렌더링된 출력을 PowerPoint와 가깝게 만들려면 영향을 받는 글꼴을 사용하는 텍스트 부분에 대해 커닝을 비활성화할 수 있습니다. 실제 글꼴 크기보다 훨씬 큰 값으로 [IBasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ibaseportionformat/#setKerningMinimalSize-float-)을 설정합니다.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    String targetFont = "Roboto";

    for (IParagraph paragraph : autoShape.getTextFrame().getParagraphs()) {
        for (IPortion portion : paragraph.getPortions()) {
            IPortionFormat portionFormat = portion.getPortionFormat();

            if ((portionFormat.getLatinFont() != null &&
                 portionFormat.getLatinFont().getFontName().equals(targetFont)) ||
                (portionFormat.getEastAsianFont() != null &&
                 portionFormat.getEastAsianFont().getFontName().equals(targetFont)) ||
                (portionFormat.getComplexScriptFont() != null &&
                 portionFormat.getComplexScriptFont().getFontName().equals(targetFont))) {
                portionFormat.setKerningMinimalSize(100);
            }
        }
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

이 설정은 일치하는 텍스트 부분에 커닝 적용을 방지하며, 해당 PowerPoint 전용 동작으로 인해 영향을 받는 글꼴에 대해 Aspose.Slides 렌더링을 PowerPoint 시각 출력에 맞출 수 있습니다.

## **텍스트 글꼴 속성 관리**

글꼴 속성은 [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--)을 통해 단락 수준에서 설정하거나, [IPortionFormat](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iportionformat/)을 통해 개별 부분에서 설정할 수 있습니다.

다음 코드는 전체 단락에 대한 글꼴 및 텍스트 스타일을 설정합니다. 여기서는 글꼴 크기, 굵게, 기울임꼴, 점선 밑줄 및 Times New Roman 글꼴을 모든 부분에 적용합니다.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // 단락에 대한 글꼴 속성을 설정합니다.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(12);
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontBold(NullableBool.True);
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontItalic(NullableBool.True);
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontUnderline(TextUnderlineType.Dotted);
    paragraph.getParagraphFormat().getDefaultPortionFormat().setLatinFont(new FontData("Times New Roman"));

    presentation.save("font_properties_for_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

결과:

![The font properties for the paragraph](font_properties_for_paragraph.png)

아래 코드 예제는 **굵은 글꼴을 가진 텍스트 부분**에 유사한 속성을 적용합니다.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // 텍스트 부분에 대한 글꼴 속성을 설정합니다.
            portion.getPortionFormat().setFontHeight(13);
            portion.getPortionFormat().setFontItalic(NullableBool.True);
            portion.getPortionFormat().setFontUnderline(TextUnderlineType.Dotted);
            portion.getPortionFormat().setLatinFont(new FontData("Times New Roman"));
        }
    }

    presentation.save("font_properties_for_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

결과:

![The font properties for text portions](font_properties_for_text_portions.png)

## **텍스트 회전 설정**

[ITextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/ko/java/com.aspose.slides/itextframeformat/#setTextVerticalType-byte-)을 사용하여 도형 내 텍스트의 미리 정의된 방향을 설정합니다.

다음 코드 예제는 텍스트 방향을 `Vertical270`으로 설정하여 텍스트를 **시계 반대 방향으로 90도** 회전시킵니다.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setTextVerticalType(TextVerticalType.Vertical270);

    presentation.save("text_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

결과:

![The text rotation](text_rotation.png)

## **텍스트 프레임에 사용자 정의 회전 적용**

[ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/ko/java/com.aspose.slides/itextframeformat/#setRotationAngle-float-)을 사용하여 [ITextFrame](https://reference.aspose.com/slides/ko/java/com.aspose.slides/itextframe/)에 대한 사용자 정의 회전 각도를 설정합니다.

아래 코드 예제는 도형 내 텍스트 프레임을 시계 방향으로 3도 회전시킵니다.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setRotationAngle(3);

    presentation.save("custom_text_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

결과:

![The custom text rotation](custom_text_rotation.png)

## **단락의 행 간격 설정**

Aspose.Slides는 [IParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iparagraphformat/#setSpaceAfter-float-), [IParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iparagraphformat/#setSpaceBefore-float-), 그리고 [IParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iparagraphformat/#setSpaceWithin-float-)을 제공하여 단락 간격을 제어합니다. 이 속성은 다음과 같이 사용됩니다.

* 양수 값을 사용하면 행 간격을 행 높이의 백분율로 지정합니다.
* 음수 값을 사용하면 행 간격을 포인트로 지정합니다.

다음 코드 예제는 단락 내 행 간격을 지정하는 방법을 보여줍니다.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    paragraph.getParagraphFormat().setSpaceWithin(200);

    presentation.save("line_spacing.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

결과:

![The line spacing within the paragraph](line_spacing.png)

## **텍스트 프레임 자동 맞춤 유형 설정**

[ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/ko/java/com.aspose.slides/itextframeformat/#setAutofitType-byte-)은 텍스트가 컨테이너 경계를 초과할 때 텍스트가 어떻게 동작할지를 결정합니다. 이를 사용하여 텍스트가 축소, 넘침, 또는 도형을 자동으로 크기 조정하도록 제어할 수 있습니다.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setAutofitType(TextAutofitType.Shape);

    presentation.save("autofit_type.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **텍스트 프레임 고정점 설정**

[ITextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/ko/java/com.aspose.slides/itextframeformat/#setAnchoringType-byte-)은 텍스트가 도형 내부에서 수직으로 어떻게 배치될지를 정의합니다. 예를 들어 위쪽, 중간, 아래쪽 등에 배치할 수 있습니다.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setAnchoringType(TextAnchorType.Bottom);

    presentation.save("text_anchor.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **텍스트 탭 설정**

[IParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iparagraphformat/#setDefaultTabSize-float-)와 [IParagraphFormat.getTabs](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iparagraphformat/#getTabs--)을 사용하여 단락의 탭 정지를 구성합니다.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    paragraph.getParagraphFormat().setDefaultTabSize(100);
    paragraph.getParagraphFormat().getTabs().add(30, TabAlignment.Left);

    presentation.save("paragraph_tabs.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

결과:

![The paragraph tabs](paragraph_tabs.png)

## **교정 언어 설정**

Aspose.Slides는 [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-)을 제공하며, 이를 통해 텍스트 부분의 교정 언어를 설정할 수 있습니다. 교정 언어는 PowerPoint에서 맞춤법 및 문법 검사를 수행할 때 사용되는 언어를 결정합니다.

다음 코드 예제는 텍스트 부분의 교정 언어를 설정하는 방법을 보여줍니다.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    FontData font = new FontData("SimSun");

    Portion textPortion = new Portion();
    textPortion.getPortionFormat().setComplexScriptFont(font);
    textPortion.getPortionFormat().setEastAsianFont(font);
    textPortion.getPortionFormat().setLatinFont(font);

    // 교정 언어의 Id를 설정합니다.
    textPortion.getPortionFormat().setLanguageId("zh-CN");

    textPortion.setText("1.");
    paragraph.getPortions().add(textPortion);

    presentation.save("proofing_language.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **기본 언어 설정**

[LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/ko/java/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-)을 사용하여 프레젠테이션을 로드하거나 만들 때 생성되는 텍스트의 기본 언어를 정의합니다.

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

Presentation presentation = new Presentation(loadOptions);
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // 텍스트가 있는 새 사각형 도형을 추가합니다.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 50);
    shape.getTextFrame().setText("Sample text");

    // 첫 번째 부분의 언어를 확인합니다.
    IPortion portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    System.out.println(portion.getPortionFormat().getLanguageId());
} finally {
    presentation.dispose();
}
```

## **기본 텍스트 스타일 설정**

프레젠테이션 수준에서 기본 텍스트 서식을 적용하려면 [IPresentation.getDefaultTextStyle](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ipresentation/#getDefaultTextStyle--)을 사용합니다.

다음 코드 예제는 새로운 프레젠테이션의 모든 슬라이드에서 기본 굵은 글꼴을 14pt 크기로 설정하는 방법을 보여줍니다.

```java
Presentation presentation = new Presentation();
try {
    // 최상위 수준 단락 서식을 가져옵니다.
    IParagraphFormat paragraphFormat = presentation.getDefaultTextStyle().getLevel(0);

    if (paragraphFormat != null) {
        paragraphFormat.getDefaultPortionFormat().setFontHeight(14);
        paragraphFormat.getDefaultPortionFormat().setFontBold(NullableBool.True);
    }

    presentation.save("default_text_style.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **All-Caps 효과가 적용된 텍스트 추출**

PowerPoint에서 **All Caps** 글꼴 효과를 적용하면 슬라이드에 표시될 때 텍스트가 대문자로 보이지만, 실제로는 소문자로 입력됩니다. Aspose.Slides로 해당 텍스트 부분을 가져오면 라이브러리는 입력된 그대로의 텍스트를 반환합니다. 표시된 텍스트와 일치시키려면 [TextCapType](https://reference.aspose.com/slides/ko/java/com.aspose.slides/textcaptype/)을 확인하고 값이 `All`인 경우 반환된 문자열을 대문자로 변환합니다.

예를 들어 sample2.pptx 파일의 첫 번째 슬라이드에 다음과 같은 텍스트 상자가 있다고 가정합니다.

![The All Caps effect](all_caps_effect.png)

아래 코드 예제는 **All Caps** 효과가 적용된 텍스트를 추출하는 방법을 보여줍니다.

```java
Presentation presentation = new Presentation("sample2.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IPortion textPortion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);

    System.out.println("Original text: " + textPortion.getText());

    IPortionFormatEffectiveData textFormat = textPortion.getPortionFormat().getEffective();
    if (textFormat.getTextCapType() == TextCapType.All) {
        String text = textPortion.getText().toUpperCase();
        System.out.println("All-Caps effect: " + text);
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

**슬라이드의 표에서 텍스트를 수정하려면 어떻게 해야 하나요?**

표의 텍스트를 수정하려면 [ITable](https://reference.aspose.com/slides/ko/java/com.aspose.slides/itable/)를 사용합니다. 셀을 순회하면서 각 셀을 [ICell.getTextFrame](https://reference.aspose.com/slides/ko/java/com.aspose.slides/icell/#getTextFrame--)을 통해 업데이트하고, [IParagraph.getParagraphFormat](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iparagraph/#getParagraphFormat--)을 통해 단락 서식을 변경합니다.

**PowerPoint 슬라이드의 텍스트에 그라디언트 색을 적용하려면 어떻게 해야 하나요?**

그라디언트 색을 적용하려면 [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ibaseportionformat/#getFillFormat--)을 사용합니다. [IFillFormat.setFillType](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ifillformat/#setFillType-byte-)을 [FillType.Gradient](https://reference.aspose.com/slides/ko/java/com.aspose.slides/filltype/)으로 설정하고, 그라디언트 스톱, 방향 및 투명도를 구성합니다.
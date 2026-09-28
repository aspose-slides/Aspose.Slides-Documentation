---
title: Java에서 프레젠테이션 텍스트 서식 지정
linktitle: 텍스트 서식 지정
type: docs
weight: 50
url: /ko/java/text-formatting/
keywords:
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
- 텍스트 프레임 고정점
- 텍스트 탭 지정
- 기본 언어
- PowerPoint
- OpenDocument
- 프레젠테이션
- Java
- Aspose.Slides
description: "Aspose.Slides for Java를 사용하여 PowerPoint 및 OpenDocument 프레젠테이션에서 텍스트를 형식화하고 스타일을 지정합니다. 글꼴, 색상, 정렬 등을 맞춤 설정할 수 있습니다."
---
## **개요**

이 문서는 Aspose.Slides for Java를 사용하여 PowerPoint 및 OpenDocument 프레젠테이션에서 텍스트를 서식 지정하는 방법을 보여줍니다. 배경 색, 투명도, 문자 간격, 글꼴 속성, 회전, 단락 간격, 자동 맞춤 동작, 텍스트 고정, 탭 정지 및 언어 설정을 다룹니다.

특히 명시되지 않는 한 예제는 [sample.pptx](sample.pptx)를 사용합니다. 첫 번째 슬라이드의 첫 번째 도형은 텍스트 상자이며, 첫 번째 단락에 아래에 표시된 텍스트가 포함되어 있습니다. 슬라이드와 도형 인덱스는 0부터 시작합니다. 굵게 표시된 부분을 선택하는 예제는 상속된 굵은 서식을 포함한 실제 서식을 사용합니다:

![샘플 텍스트](sample_text.png)

문자 그대로의 텍스트 또는 정규식 일치를 찾고 강조하려면 [텍스트 검색 및 바꾸기](/slides/ko/java/search-and-replace-text/)를 참조하십시오.

## **텍스트 배경 색 설정**

단락에 대한 기본 강조 색을 설정하려면 [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--)을 사용하고, 개별 텍스트 부분에 대한 강조 색을 설정하려면 [IBasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ibaseportionformat/#getHighlightColor--)을 사용합니다.

다음 예제는 첫 번째 단락에 기본 강조 색으로 연한 회색을 설정합니다. 개별 부분에 대한 명시적 강조 색은 이 기본보다 우선합니다:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // 전체 단락에 대한 강조 색을 설정합니다.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getHighlightColor().setColor(Color.LIGHT_GRAY);

    presentation.save("gray_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

결과:

![회색 단락](gray_paragraph.png)

아래 코드 예제는 **굵은 글꼴**을 가진 **텍스트 부분**에 대한 배경 색을 설정하는 방법을 보여줍니다:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
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

![회색 텍스트 부분](gray_text_portions.png)

## **텍스트 단락 정렬**

텍스트 프레임 내 단락 정렬을 지정하려면 [IParagraphFormat.setAlignment](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iparagraphformat/#setAlignment-int-)를 사용합니다. 값은 중앙, 왼쪽 정렬, 오른쪽 정렬, 양쪽 맞춤 등일 수 있습니다.

다음 코드 예제는 단락을 **중앙**에 정렬하는 방법을 보여줍니다:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // 단락의 정렬을 가운데로 설정합니다.
    paragraph.getParagraphFormat().setAlignment(TextAlignment.Center);

    presentation.save("aligned_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

결과:

![정렬된 단락](aligned_paragraph.png)

## **텍스트 투명도 설정**

텍스트 투명도는 [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ibaseportionformat/#getFillFormat--)에 지정된 색상의 알파 구성 요소를 통해 제어됩니다. 아래 예제에서 `alpha = 50`은 0‑255 스케일의 ARGB 알파 채널 값이며, 투명도 백분율이 아닙니다.

다음 코드 예제는 **전체 단락**에 투명도를 적용하는 방법을 보여줍니다:

```java
import com.aspose.slides.*;
import java.awt.Color;

int alpha = 50;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // 텍스트의 채우기 색을 투명 색으로 설정합니다.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(new Color(0, 0, 0, alpha));

    presentation.save("transparent_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

결과:

![투명 단락](transparent_paragraph.png)

다음 코드 예제는 **굵은 글꼴**을 가진 **텍스트 부분**에 투명도를 적용하는 방법을 보여줍니다:

```java
import com.aspose.slides.*;
import java.awt.Color;

int alpha = 50;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
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

![투명 텍스트 부분](transparent_text_portions.png)

## **텍스트 문자 간격 설정**

텍스트 상자에서 문자 간격을 확대하거나 축소하려면 [IBasePortionFormat.setSpacing](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ibaseportionformat/#setSpacing-float-)를 사용합니다. 예제에서는 3포인트 간격을 추가하고, 음수 값은 텍스트를 축소합니다.

다음 Java 코드에서는 **전체 단락**의 문자 간격을 확대하는 방법을 보여줍니다:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // 참고: 문자 간격을 압축하려면 음수 값을 사용합니다.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3); // 문자 간격을 늘립니다.

    presentation.save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

결과:

![단락의 문자 간격](character_spacing_in_paragraph.png)

다음 코드 예제는 **굵은 글꼴**을 가진 **텍스트 부분**의 문자 간격을 확대하는 방법을 보여줍니다:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // 참고: 문자 간격을 압축하려면 음수 값을 사용합니다.
            portion.getPortionFormat().setSpacing(3); // 문자 간격을 늘립니다.
        }
    }

    presentation.save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

결과:

![텍스트 부분의 문자 간격](character_spacing_in_text_portions.png)

### **특정 글꼴에 대한 커닝 사용 안 함**

일부 경우 Aspose.Slides가 렌더링한 텍스트가 PowerPoint에서 표시되는 텍스트보다 약간 더 촘촘하게 보일 수 있습니다. 이는 PowerPoint가 특정 글꼴에 대해 커닝 데이터를 무시하기 때문일 수 있습니다.

이러한 경우 텍스트 부분에 대해 커닝을 비활성화하여 PowerPoint와 더 가깝게 만들 수 있습니다. [IBasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ibaseportionformat/#setKerningMinimalSize-float-)를 실제 글꼴 크기보다 큰 값으로 설정합니다. 이 예제는 첫 번째 슬라이드의 첫 번째 도형이 텍스트 상자인 "presentation.pptx"가 필요합니다. 효과적인 글꼴 이름(상속된 글꼴 포함)을 확인하고 Roboto를 사용하는 부분에 대해 100포인트 임계값을 설정합니다. 이는 100포인트 미만의 글꼴 크기를 가진 해당 부분의 커닝을 비활성화합니다:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    String targetFont = "Roboto";

    for (IParagraph paragraph : autoShape.getTextFrame().getParagraphs()) {
        for (IPortion portion : paragraph.getPortions()) {
            IPortionFormatEffectiveData portionFormat = portion.getPortionFormat().getEffective();

            if ((portionFormat.getLatinFont() != null &&
                 portionFormat.getLatinFont().getFontName().equals(targetFont)) ||
                (portionFormat.getEastAsianFont() != null &&
                 portionFormat.getEastAsianFont().getFontName().equals(targetFont)) ||
                (portionFormat.getComplexScriptFont() != null &&
                 portionFormat.getComplexScriptFont().getFontName().equals(targetFont))) {
                portion.getPortionFormat().setKerningMinimalSize(100);
            }
        }
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

임계값 이하의 일치 텍스트에 대해 이 설정은 커닝을 방지하고, PowerPoint 특정 동작에 영향을 받는 글꼴에 대해 Aspose.Slides 렌더링을 PowerPoint 시각적 출력과 맞추는 데 도움이 될 수 있습니다.

## **텍스트 글꼴 속성 관리**

글꼴 속성은 [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--)을 통해 단락 수준에서 설정하거나, [IPortionFormat](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iportionformat/)을 통해 개별 부분에서 설정할 수 있습니다.

다음 예제는 첫 번째 단락의 기본 글꼴을 12포인트 Times New Roman으로 설정하고 굵게, 이탤릭, 점선 밑줄 서식을 적용합니다. 개별 부분에 대한 명시적 서식은 이러한 기본값보다 우선합니다:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
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

![단락의 글꼴 속성](font_properties_for_paragraph.png)

다음 예제는 효과적인 서식이 굵게인 부분에 대해 13포인트 Times New Roman, 이탤릭 서식 및 점선 밑줄을 적용합니다:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
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

![텍스트 부분의 글꼴 속성](font_properties_for_text_portions.png)

## **텍스트 회전 설정**

[ ITextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/ko/java/com.aspose.slides/itextframeformat/#setTextVerticalType-byte-)을 사용하여 도형 내 미리 정의된 텍스트 방향을 설정합니다.

다음 코드 예제는 텍스트 방향을 [TextVerticalType.Vertical270](https://reference.aspose.com/slides/ko/java/com.aspose.slides/textverticaltype/)으로 설정하여 텍스트를 **시계 반대 방향으로 90도** 회전시킵니다:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    autoShape.getTextFrame().getTextFrameFormat().setTextVerticalType(TextVerticalType.Vertical270);

    presentation.save("text_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

결과:

![텍스트 회전](text_rotation.png)

## **텍스트 프레임의 사용자 지정 회전 설정**

[ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/ko/java/com.aspose.slides/itextframeformat/#setRotationAngle-float-)을 사용하여 [ITextFrame](https://reference.aspose.com/slides/ko/java/com.aspose.slides/itextframe/)에 대한 사용자 지정 회전 각도를 설정합니다.

다음 코드 예제는 도형 내 텍스트 프레임을 시계 방향으로 3도 회전시킵니다:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    autoShape.getTextFrame().getTextFrameFormat().setRotationAngle(3);

    presentation.save("custom_text_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

결과:

![사용자 지정 텍스트 회전](custom_text_rotation.png)

## **단락의 줄 간격 설정**

Aspose.Slides는 [IParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iparagraphformat/#setSpaceAfter-float-), [IParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iparagraphformat/#setSpaceBefore-float-), 및 [IParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iparagraphformat/#setSpaceWithin-float-)를 제공하여 단락 간격을 제어합니다. 이들 속성은 다음과 같이 사용됩니다:

* 양수 값을 사용하면 줄 높이의 백분율로 줄 간격을 지정합니다.
* 음수 값을 사용하면 포인트 단위로 줄 간격을 지정합니다.

다음 예제는 첫 번째 단락의 내부 간격을 줄 높이의 200%(두 배 간격)로 설정합니다:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);

    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getParagraphFormat().setSpaceWithin(200);

    presentation.save("line_spacing.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

결과:

![단락 내의 줄 간격](line_spacing.png)

## **줄 바꿈 제어**

단락 줄 바꿈 규칙은 좁은 텍스트 블록 및 라틴어와 동아시아 텍스트가 혼합된 프레젠테이션에서 유용합니다. 다음 메서드는 [IParagraphFormat](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iparagraphformat/)에 속하므로 전체 단락에 적용됩니다:

- [setLatinLineBreak](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iparagraphformat/#setLatinLineBreak-byte-)은 라틴어 줄 바꿈 규칙을 제어합니다. 혼합 텍스트에서 이를 변경하면 인접한 동아시아 텍스트와 구두점의 줄 바꿈 위치도 바뀔 수 있습니다.
- [setEastAsianLineBreak](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iparagraphformat/#setEastAsianLineBreak-byte-)은 동아시아 줄 바꿈 규칙을 제어하며, 줄 시작 및 끝에 허용되는 문자에 대한 제한을 포함합니다.

이 규칙은 텍스트 프레임 내 자동 줄 바꿈을 활성화하는 [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/ko/java/com.aspose.slides/itextframeformat/#setWrapText-byte-)을 대체하지 않으며, 줄 바꿈이 발생할 때 레이아웃에 영향을 미칩니다; 줄 바꿈 문자를 삽입하지는 않습니다. 명시적인 줄 바꿈은 가용 너비와 무관하게 단락 내에 새로운 줄을 강제합니다.

다음 독립형 예제는 중국어와 라틴어 텍스트가 포함된 좁은 텍스트 블록을 생성하고 두 줄 바꿈 옵션을 명시적으로 설정한 뒤 "line_breaking.pptx"로 저장합니다. 각각의 규칙을 실험하려면 다른 설정은 유지한 채 해당 값을 변경하십시오. 예제는 24포인트 Arial 및 SimSun을 사용하고 프레임 너비 160포인트, 가로 텍스트 프레임 여백 0을 사용합니다. [ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/ko/java/com.aspose.slides/itextframeformat/#setAutofitType-byte-)은 [TextAutofitType.None](https://reference.aspose.com/slides/ko/java/com.aspose.slides/textautofittype/)으로 호출되어 텍스트 크기와 프레임 크기가 고정됩니다:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 160, 300);
    shape.getFillFormat().setFillType(FillType.NoFill);

    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setWrapText(NullableBool.True);
    textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.None);
    textFrame.getTextFrameFormat().setMarginLeft(0);
    textFrame.getTextFrameFormat().setMarginRight(0);

    IParagraph paragraph = textFrame.getParagraphs().get_Item(0);
    paragraph.setText("中文排版测试，PowerPoint 中文演示。");

    IParagraphFormat format = paragraph.getParagraphFormat();
    format.setAlignment(TextAlignment.Left);
    format.getDefaultPortionFormat().setFontHeight(24);
    FontData latinFont = new FontData("Arial");
    format.getDefaultPortionFormat().setLatinFont(latinFont);
    FontData eastAsianFont = new FontData("SimSun");
    format.getDefaultPortionFormat().setEastAsianFont(eastAsianFont);
    format.getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    format.getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    format.setLatinLineBreak(NullableBool.False);
    format.setEastAsianLineBreak(NullableBool.True);

    presentation.save("line_breaking.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **걸림 구두점 제어**

[IParagraphFormat.setHangingPunctuation](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iparagraphformat/#setHangingPunctuation-byte-)을 사용하면 해당 구두점을 텍스트 라인의 오른쪽 가장자리를 넘어 연장시킬 수 있으며, 다음 줄을 차지하지 않습니다. 전체 단락에 적용되며, 걸림 들여쓰기와는 다릅니다.

다음 독립형 예제는 100포인트 너비 텍스트 프레임에서 걸림 구두점을 활성화하고 "hanging_punctuation.pptx"로 저장합니다. 24포인트 Arial과 가로 텍스트 프레임 여백 0을 사용하면 마지막 마침표가 "sentence" 뒤에 남아 오른쪽 텍스트 가장자를 넘어갑니다. 속성을 [NullableBool.False](https://reference.aspose.com/slides/ko/java/com.aspose.slides/nullablebool/)로 설정하면 비교할 수 있습니다: 이 설정에서는 마침표가 별도 줄에 배치됩니다. 줄 바꿈이 활성화되고 자동 맞춤이 비활성화되어 가용 너비가 고정됩니다:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 100, 200);
    shape.getFillFormat().setFillType(FillType.NoFill);

    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setWrapText(NullableBool.True);
    textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.None);
    textFrame.getTextFrameFormat().setMarginLeft(0);
    textFrame.getTextFrameFormat().setMarginRight(0);

    IParagraph paragraph = textFrame.getParagraphs().get_Item(0);
    paragraph.setText("Simple text, next sentence.");

    IParagraphFormat format = paragraph.getParagraphFormat();
    format.setAlignment(TextAlignment.Left);
    format.getDefaultPortionFormat().setFontHeight(24);
    FontData latinFont = new FontData("Arial");
    format.getDefaultPortionFormat().setLatinFont(latinFont);
    format.getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    format.getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    format.setHangingPunctuation(NullableBool.True);

    presentation.save("hanging_punctuation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

모든 구두점이 걸릴 수 있는 것은 아닙니다. 보이는 결과는 글꼴 가용성 및 레이아웃에 따라 달라집니다: 글꼴, 가용 너비, 여백 또는 자동 맞춤 설정을 변경하면 보이는 차이가 사라질 수 있습니다.

## **텍스트 프레임 자동 맞춤 유형 설정**

[ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/ko/java/com.aspose.slides/itextframeformat/#setAutofitType-byte-)은 텍스트가 컨테이너 경계를 초과할 때 텍스트가 어떻게 동작할지 결정합니다. 텍스트를 축소, 넘침, 또는 도형을 자동으로 크기 변경하도록 제어할 수 있습니다. 다음 예제는 텍스트에 맞게 도형을 자동으로 크기 조정하도록 구성하고 결과를 "autofit_type.pptx"로 저장합니다:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    autoShape.getTextFrame().getTextFrameFormat().setAutofitType(TextAutofitType.Shape);

    presentation.save("autofit_type.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

자동 줄 바꿈 후 라인 수를 세고 텍스트 또는 도형 너비가 결과에 어떻게 영향을 미치는지 확인하려면 [렌더링된 라인 수 세기](/slides/ko/java/manage-paragraph/)를 참조하십시오. 라인 수만으로는 텍스트가 컨테이너를 넘쳤는지 여부를 판단할 수 없습니다.

## **텍스트 프레임 고정점 설정**

[ITextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/ko/java/com.aspose.slides/itextframeformat/#setAnchoringType-byte-)은 텍스트를 도형 내부에서 위쪽, 가운데 또는 아래쪽 등 수직으로 배치하는 방식을 정의합니다. 다음 예제는 텍스트를 첫 번째 도형의 아래쪽에 고정하고 결과를 "text_anchor.pptx"로 저장합니다:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    autoShape.getTextFrame().getTextFrameFormat().setAnchoringType(TextAnchorType.Bottom);

    presentation.save("text_anchor.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **텍스트 탭 설정**

[IParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iparagraphformat/#setDefaultTabSize-float-)와 [IParagraphFormat.getTabs](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iparagraphformat/#getTabs--)를 사용하여 단락의 탭 정지를 구성합니다. 다음 예제는 기본 탭 간격을 100포인트로 설정하고 30포인트에 왼쪽 정렬 탭 정지를 추가합니다. 이 설정은 탭 문자를 포함하는 텍스트에 영향을 줍니다:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getParagraphFormat().setDefaultTabSize(100);
    paragraph.getParagraphFormat().getTabs().add(30, TabAlignment.Left);

    presentation.save("paragraph_tabs.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

결과:

![단락 탭](paragraph_tabs.png)

## **교정 언어 설정**

Aspose.Slides는 [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-)를 제공하여 텍스트 부분의 교정 언어를 설정할 수 있습니다. 교정 언어는 PowerPoint에서 맞춤법 및 문법 검사를 수행할 때 사용되는 언어를 결정합니다.

다음 예제는 첫 번째 슬라이드의 첫 번째 도형이 텍스트 상자인 "presentation.pptx"와 최소 하나의 단락이 필요합니다. 첫 번째 단락 내용을 "1。"으로 교체하고, 글꼴을 SimSun으로 설정한 뒤 교정 언어를 Simplified Chinese(`zh-CN`)로 지정합니다. 결과는 "proofing_language.pptx"로 저장됩니다:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);

    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    FontData font = new FontData("SimSun");

    Portion textPortion = new Portion();
    textPortion.getPortionFormat().setComplexScriptFont(font);
    textPortion.getPortionFormat().setEastAsianFont(font);
    textPortion.getPortionFormat().setLatinFont(font);

    // 교정 언어의 Id를 설정합니다.
    textPortion.getPortionFormat().setLanguageId("zh-CN");

    textPortion.setText("1。");
    paragraph.getPortions().add(textPortion);

    presentation.save("proofing_language.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **기본 언어 설정**

[LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/ko/java/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-)을 사용하여 프레젠테이션을 로드하거나 만들 때 생성되는 텍스트의 기본 언어를 정의합니다. 다음 예제는 기본 텍스트 언어를 미국 영어로 설정한 프레젠테이션을 만들고, 텍스트 상자를 추가한 뒤 첫 번째 텍스트 부분에 대해 `en-US`를 출력합니다:

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

Presentation presentation = new Presentation(loadOptions);
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // 새 사각형 도형을 텍스트와 함께 추가합니다.
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

프레젠테이션 수준에서 기본 텍스트 서식을 적용하려면 [IPresentation.getDefaultTextStyle](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ipresentation/#getDefaultTextStyle--)를 사용합니다.

다음 예제는 새 프레젠테이션의 최상위 단락에 대해 14포인트 굵은 글꼴을 기본값으로 설정하고 "default_text_style.pptx"로 저장합니다. 텍스트는 보다 구체적인 서식이 없을 경우 이러한 기본값을 상속받습니다:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    // 상위 수준 단락 서식을 가져옵니다.
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

## **전체 대문자 효과와 함께 텍스트 추출**

PowerPoint에서 **All Caps** 글꼴 효과를 적용하면 슬라이드에 표시되는 텍스트는 대문자로 보이지만, 원본 텍스트는 소문자로 입력됩니다. Aspose.Slides로 해당 텍스트 부분을 가져오면 라이브러리는 입력된 그대로 반환합니다. 표시된 텍스트와 일치시키려면 [TextCapType](https://reference.aspose.com/slides/ko/java/com.aspose.slides/textcaptype/)을 확인하고 값이 `All`인 경우 반환된 문자열을 대문자로 변환합니다.

이 예제는 첫 번째 슬라이드의 첫 번째 도형이 텍스트 상자인 "sample2.pptx"가 필요합니다. 첫 번째 단락의 첫 번째 부분에 "Hello, Aspose!"가 All Caps 효과와 함께 포함되어 있습니다:

![전체 대문자 효과](all_caps_effect.png)

다음 코드 예제는 **All Caps** 효과가 적용된 텍스트를 추출하는 방법을 보여줍니다:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample2.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
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

**슬라이드의 표에서 텍스트를 어떻게 수정하나요?**

슬라이드의 표에서 텍스트를 수정하려면 [ITable](https://reference.aspose.com/slides/ko/java/com.aspose.slides/itable/)를 사용합니다. 셀을 순회하면서 [ICell.getTextFrame](https://reference.aspose.com/slides/ko/java/com.aspose.slides/icell/#getTextFrame--)을 통해 각 셀을 업데이트하고, [IParagraph.getParagraphFormat](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iparagraph/#getParagraphFormat--)을 통해 단락 서식을 업데이트합니다.

**PowerPoint 슬라이드의 텍스트에 그라데이션 색상을 적용하려면 어떻게 하나요?**

그라데이션 색상을 적용하려면 [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ibaseportionformat/#getFillFormat--)를 사용합니다. [IFillFormat.setFillType](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ifillformat/#setFillType-byte-)을 [FillType.Gradient](https://reference.aspose.com/slides/ko/java/com.aspose.slides/filltype/)으로 설정하고, 그라데이션 정지, 방향 및 투명도를 구성합니다.
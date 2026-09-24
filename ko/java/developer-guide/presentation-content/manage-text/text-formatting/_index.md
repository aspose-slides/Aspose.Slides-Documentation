---
title: "Java에서 프레젠테이션 텍스트 서식 지정"
linktitle: "텍스트 서식 지정"
type: docs
weight: 50
url: /ko/java/text-formatting/
keywords:
- "단락 정렬"
- "텍스트 스타일"
- "텍스트 배경"
- "텍스트 투명도"
- "문자 간격"
- "글꼴 속성"
- "글꼴 패밀리"
- "텍스트 회전"
- "회전 각도"
- "텍스트 프레임"
- "줄 간격"
- "자동 맞춤 속성"
- "텍스트 프레임 고정점"
- "텍스트 탭"
- "기본 언어"
- "PowerPoint"
- "OpenDocument"
- "프레젠테이션"
- "Java"
- "Aspose.Slides"
description: "Aspose.Slides for Java를 사용하여 PowerPoint 및 OpenDocument 프레젠테이션의 텍스트를 포맷하고 스타일을 지정합니다. 글꼴, 색상, 정렬 등을 사용자 정의합니다."
---
## **개요**

이 문서에서는 Aspose.Slides for Java를 사용하여 PowerPoint 및 OpenDocument 프레젠테이션에서 텍스트를 서식 지정하는 방법을 보여줍니다. 배경색, 투명도, 문자 간격, 글꼴 속성, 회전, 단락 간격, 자동 맞춤 동작, 텍스트 고정, 탭 정지 및 언어 설정을 포함합니다.

아래 예제에서는 첫 번째 슬라이드에 단일 텍스트 상자가 포함된 "sample.pptx" 파일을 사용합니다. 텍스트는 다음과 같습니다:

![샘플 텍스트](sample_text.png)

리터럴 텍스트 또는 정규식 일치를 찾고 강조하려면 [텍스트 검색 및 바꾸기](/slides/ko/java/search-and-replace-text/)를 참조하세요.

## **텍스트 배경 색 설정**

문단의 기본 강조 색을 설정하려면 [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--)을 사용하고, 개별 텍스트 부분에 대해서는 [IBasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ibaseportionformat/#getHighlightColor--)을 사용합니다.

다음 코드 예제는 **전체 문단**에 대한 배경 색을 설정하는 방법을 보여줍니다:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // 전체 문단에 대한 강조 색을 설정합니다.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getHighlightColor().setColor(Color.LIGHT_GRAY);

    presentation.save("gray_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

결과:

![회색 문단](gray_paragraph.png)

다음 코드 예제는 **굵은 글꼴이 적용된 텍스트 부분**에 대한 배경 색을 설정하는 방법을 보여줍니다:

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

텍스트 프레임 내에서 단락 정렬을 설정하려면 [IParagraphFormat.setAlignment](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iparagraphformat/#setAlignment-int-)을 사용합니다. 값은 가운데, 왼쪽 정렬, 오른쪽 정렬, 양쪽 정렬 등일 수 있습니다.

다음 코드 예제는 **가운데**에 단락을 정렬하는 방법을 보여줍니다:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // 문단의 정렬을 가운데로 설정합니다.
    paragraph.getParagraphFormat().setAlignment(TextAlignment.Center);

    presentation.save("aligned_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

결과:

![정렬된 문단](aligned_paragraph.png)

## **텍스트 투명도 설정**

텍스트 투명도는 [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ibaseportionformat/#getFillFormat--)에 할당된 색상의 알파 구성 요소를 통해 제어됩니다. 아래 예제에서 `alpha = 50`은 0–255 스케일의 ARGB 알파 채널 값이며, 투명도 비율이 아닙니다.

다음 코드 예제는 **전체 문단**에 투명도를 적용하는 방법을 보여줍니다:

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

![투명한 문단](transparent_paragraph.png)

다음 코드 예제는 **굵은 글꼴이 적용된 텍스트 부분**에 투명도를 적용하는 방법을 보여줍니다:

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

![투명한 텍스트 부분](transparent_text_portions.png)

## **텍스트 문자 간격 설정**

텍스트 상자에서 문자 간격을 확대하거나 축소하려면 [IBasePortionFormat.setSpacing](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ibaseportionformat/#setSpacing-float-)을 사용합니다.

다음 Java 코드는 **전체 문단**에서 문자 간격을 확대하는 방법을 보여줍니다:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // 참고: 문자 간격을 압축하려면 음수를 사용합니다.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3); // 문자 간격을 확장합니다.

    presentation.save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

결과:

![문단의 문자 간격](character_spacing_in_paragraph.png)

다음 코드 예제는 **굵은 글꼴이 적용된 텍스트 부분**에서 문자 간격을 확대하는 방법을 보여줍니다:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // 참고: 문자 간격을 압축하려면 음수를 사용합니다.
            portion.getPortionFormat().setSpacing(3); // 문자 간격을 확장합니다.
        }
    }

    presentation.save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

결과:

![텍스트 부분의 문자 간격](character_spacing_in_text_portions.png)

### **특정 글꼴에 대한 커닝 비활성화**

일부 경우 Aspose.Slides가 렌더링한 텍스트가 PowerPoint에서 표시되는 동일한 텍스트보다 약간 더 조여 보일 수 있습니다. 이는 PowerPoint가 해당 글꼴에 대한 커닝 데이터를 무시할 수 있기 때문이며, 글꼴에 유효한 커닝 정보가 포함되어 있고 PowerPoint 설정에서 커닝이 활성화되어 있어도 발생합니다.

이러한 경우 렌더링된 출력이 PowerPoint와 더 가깝게 만들려면 영향을 받는 글꼴을 사용하는 텍스트 부분에 대해 커닝을 비활성화할 수 있습니다. [IBasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ibaseportionformat/#setKerningMinimalSize-float-)을 실제 글꼴 크기보다 훨씬 크게 설정하십시오:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
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

이 설정은 일치하는 텍스트 부분에 커닝이 적용되는 것을 방지하고, PowerPoint 고유 동작에 의해 영향을 받는 글꼴에 대한 Aspose.Slides 렌더링을 PowerPoint의 시각적 출력과 맞추는 데 도움이 될 수 있습니다.

## **텍스트 글꼴 속성 관리**

글꼴 속성은 [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--)을 통해 문단 수준에서 설정하거나, [IPortionFormat](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iportionformat/)을 통해 개별 부분에서 설정할 수 있습니다.

다음 코드는 전체 문단에 대해 글꼴 및 텍스트 스타일을 설정합니다. 여기서는 글꼴 크기, 굵게, 기울임꼴, 점선 밑줄 및 Times New Roman 글꼴을 문단의 모든 부분에 적용합니다.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // 문단의 글꼴 속성을 설정합니다.
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

![문단의 글꼴 속성](font_properties_for_paragraph.png)

다음 코드 예제는 **굵은 글꼴이 적용된 텍스트 부분**에 유사한 속성을 적용합니다:

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

텍스트의 미리 정의된 방향을 도형 내에 설정하려면 [ITextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/ko/java/com.aspose.slides/itextframeformat/#setTextVerticalType-byte-)을 사용합니다.

다음 코드 예제는 텍스트 방향을 `Vertical270`으로 설정하는데, 이는 텍스트를 **시계 반대 방향으로 90도** 회전시킵니다:

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

## **텍스트 프레임 사용자 정의 회전 설정**

[ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/ko/java/com.aspose.slides/itextframeformat/#setRotationAngle-float-)을 사용하여 [ITextFrame](https://reference.aspose.com/slides/ko/java/com.aspose.slides/itextframe/)의 사용자 정의 회전 각도를 설정합니다.

다음 코드 예제는 도형 내에서 텍스트 프레임을 시계 방향으로 3도 회전시킵니다:

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

![사용자 정의 텍스트 회전](custom_text_rotation.png)

## **문단의 줄 간격 설정**

Aspose.Slides는 [IParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iparagraphformat/#setSpaceAfter-float-), [IParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iparagraphformat/#setSpaceBefore-float-) 및 [IParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iparagraphformat/#setSpaceWithin-float-)을 제공하여 단락 간격을 제어합니다. 이러한 속성은 다음과 같이 사용됩니다:

* 양의 값을 사용하여 줄 간격을 줄 높이의 백분율로 지정합니다.
* 음의 값을 사용하여 줄 간격을 포인트 단위로 지정합니다.

다음 코드 예제는 단락 내 줄 간격을 지정하는 방법을 보여줍니다:

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

![문단 내 줄 간격](line_spacing.png)

## **텍스트 프레임 자동 맞춤 유형 설정**

[ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/ko/java/com.aspose.slides/itextframeformat/#setAutofitType-byte-)은 텍스트가 컨테이너 경계를 초과할 때 텍스트가 어떻게 동작하는지를 결정합니다. 텍스트가 축소, 넘침, 또는 도형을 자동으로 크기 조정하도록 제어할 수 있습니다.

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

자동 줄 바꿈 후 줄 수를 세고 텍스트 또는 도형 너비가 결과를 어떻게 변경하는지 확인하려면 [렌더링된 줄 수 세기](/slides/ko/java/manage-paragraph/)를 참조하세요. 줄 수만으로는 텍스트가 컨테이너를 넘치는지 여부를 나타내지 않습니다.

## **텍스트 프레임 고정점 설정**

[ITextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/ko/java/com.aspose.slides/itextframeformat/#setAnchoringType-byte-)은 텍스트가 도형 내부에서 수직으로 어떻게 배치되는지를 정의합니다. 예를 들어 상단, 중간 또는 하단에 배치할 수 있습니다.

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

[IParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iparagraphformat/#setDefaultTabSize-float-) 및 [IParagraphFormat.getTabs](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iparagraphformat/#getTabs--)을 사용하여 단락의 탭 정지를 구성합니다.

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

![문단 탭](paragraph_tabs.png)

## **교정 언어 설정**

Aspose.Slides는 [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-)을 제공하여 텍스트 부분에 대한 교정 언어를 설정할 수 있습니다. 교정 언어는 PowerPoint에서 맞춤법 및 문법 검사에 사용되는 언어를 결정합니다.

다음 코드 예제는 텍스트 부분에 교정 언어를 설정하는 방법을 보여줍니다:

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

[LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/ko/java/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-)을 사용하여 프레젠테이션을 로드하거나 생성하는 동안 생성된 텍스트의 기본 언어를 정의합니다.

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

Presentation presentation = new Presentation(loadOptions);
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // 텍스트가 포함된 새 사각형 도형을 추가합니다.
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

다음 코드 예제는 새 프레젠테이션의 모든 슬라이드에서 14pt 크기의 기본 굵은 글꼴을 설정하는 방법을 보여줍니다.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    // 상위 수준 단락 형식을 가져옵니다.
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

## **전체 대문자 효과로 텍스트 추출**

PowerPoint에서 **전체 대문자** 글꼴 효과를 적용하면 원래 소문자로 입력된 경우에도 슬라이드에서 텍스트가 대문자로 표시됩니다. Aspose.Slides로 이러한 텍스트 부분을 검색하면 라이브러리는 입력된 그대로의 텍스트를 반환합니다. 표시된 텍스트와 일치하도록 하려면 [TextCapType](https://reference.aspose.com/slides/ko/java/com.aspose.slides/textcaptype/)을 확인하고 값이 `All`인 경우 반환 문자열을 대문자로 변환합니다.

예를 들어 sample2.pptx 파일의 첫 번째 슬라이드에 다음과 같은 텍스트 상자가 있다고 가정해 보겠습니다.

![전체 대문자 효과](all_caps_effect.png)

다음 코드 예제는 **전체 대문자** 효과가 적용된 텍스트를 추출하는 방법을 보여줍니다:

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

**슬라이드의 표에서 텍스트를 수정하려면 어떻게 합니까?**

슬라이드의 표에서 텍스트를 수정하려면 [ITable](https://reference.aspose.com/slides/ko/java/com.aspose.slides/itable/)을 사용하십시오. 셀을 반복하면서 [ICell.getTextFrame](https://reference.aspose.com/slides/ko/java/com.aspose.slides/icell/#getTextFrame--)을 통해 각 셀을 업데이트하고, [IParagraph.getParagraphFormat](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iparagraph/#getParagraphFormat--)을 통해 단락 서식을 업데이트합니다.

**PowerPoint 슬라이드에서 텍스트에 그라디언트 색을 적용하려면 어떻게 합니까?**

텍스트에 그라디언트 색을 적용하려면 [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ibaseportionformat/#getFillFormat--)을 사용하십시오. [IFillFormat.setFillType](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ifillformat/#setFillType-byte-)을 [FillType.Gradient](https://reference.aspose.com/slides/ko/java/com.aspose.slides/filltype/)으로 설정하고, 그라디언트 정지점, 방향 및 투명도를 구성합니다.
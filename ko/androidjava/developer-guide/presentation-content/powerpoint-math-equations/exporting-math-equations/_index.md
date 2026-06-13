---
title: Android에서 프레젠테이션의 수학 방정식 내보내기
linktitle: 방정식 내보내기
type: docs
weight: 30
url: /ko/androidjava/exporting-math-equations/
keywords:
- 수학 방정식 내보내기
- MathML
- LaTeX
- PowerPoint
- 프레젠테이션
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java를 사용하여 PowerPoint에서 MathML로 수학 방정식을 원활하게 내보내고, 형식을 보존하며 호환성을 향상시킵니다."
---
## **소개**

Aspose.Slides for Android via Java를 사용하면 프레젠테이션에서 수학 방정식을 내보낼 수 있습니다. 예를 들어, 특정 프레젠테이션의 슬라이드에 있는 수학 방정식을 추출하여 다른 프로그램이나 플랫폼에서 사용할 수 있습니다.

{{% alert color="primary" %}} 
수학 방정식을 MathML 형식으로 내보낼 수 있습니다. MathML은 웹 및 다양한 애플리케이션에서 볼 수 있는 수학 방정식 및 유사한 콘텐츠를 위한 널리 쓰이는 형식이자 표준입니다. 
{{% /alert %}}

## **프레젠테이션에서 수학 방정식 내보내기**

사용자는 LaTeX와 같은 일부 방정식 형식의 코드를 쉽게 작성할 수 있지만, MathML 코드는 앱에 의해 자동으로 생성되도록 설계되었기 때문에 작성하기 어렵습니다. MathML 코드는 XML 형태이므로 프로그램이 쉽게 읽고 구문 분석할 수 있으며, 이러한 이유로 많은 분야에서 출력 및 인쇄 형식으로 널리 사용됩니다. 

다음 샘플 코드는 프레젠테이션에서 수학 방정식을 MathML로 내보내는 방법을 보여줍니다:

```java
Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addMathShape(0, 0, 500, 50);
    IMathParagraph mathParagraph = ((MathPortion)autoShape.getTextFrame().getParagraphs().get_Item(0).
            getPortions().get_Item(0)).getMathParagraph();

    mathParagraph.add(new MathematicalText("a").
            setSuperscript("2").
            join("+").
            join(new MathematicalText("b").setSuperscript("2")).
            join("=").
            join(new MathematicalText("c").setSuperscript("2")));

    FileOutputStream stream = new FileOutputStream("mathml.xml");
    mathParagraph.writeAsMathMl(stream);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**MathML로 정확히 무엇이 내보내지나요—문단 전체인가 개별 수식 블록인가?**

MathML로 내보낼 때 전체 수학 문단([MathParagraph](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/mathparagraph/))이나 개별 블록([MathBlock](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/mathblock/)) 중 하나를 선택할 수 있습니다. 두 유형 모두 MathML로 내보내는 메서드를 제공합니다.

**슬라이드의 객체가 일반 텍스트나 이미지가 아니라 수학 수식임을 어떻게 판단하나요?**

수식은 [MathPortion](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/mathportion/)에 존재하며 [MathParagraph](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/mathparagraph/)를 가지고 있습니다. [MathParagraph](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/mathparagraph/)가 없는 이미지나 일반 텍스트는 내보낼 수 있는 수식이 아닙니다.

**프레젠테이션에서 MathML은 어디서 제공되나요—PowerPoint 전용인가요, 아니면 표준인가요?**

내보내기는 표준 MathML(XML)을 대상으로 합니다. Aspose는 프레젠테이션용 MathML(표준의 프레젠테이션 하위 집합)을 사용하며, 이는 애플리케이션 및 웹 전반에 널리 사용됩니다.

**표, SmartArt, 그룹 등 내부의 수식을 내보내는 것이 지원되나요?**

예, 해당 객체에 [MathParagraph](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/mathparagraph/)가 포함된 텍스트 부분이 있으면(즉, 실제 PowerPoint 수식) 내보낼 수 있습니다. 수식이 이미지로 삽입된 경우에는 내보낼 수 없습니다.

**MathML로 내보낼 때 원본 프레젠테이션이 변경되나요?**

아니요. MathML을 기록하는 것은 수식 내용을 직렬화하는 것이며, 프레젠테이션 파일을 변경하지 않습니다.
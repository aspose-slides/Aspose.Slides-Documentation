---
title: Java에서 PowerPoint 프레젠테이션에 수학 방정식 추가
linktitle: PowerPoint 수학 방정식
type: docs
weight: 80
url: /ko/java/powerpoint-math-equations/
keywords:
- 수학 방정식
- 수학 기호
- 수학 공식
- 수학 텍스트
- 수학 방정식 추가
- 수학 기호 추가
- 수학 공식 추가
- 수학 텍스트 추가
- PowerPoint
- 프레젠테이션
- Java
- Aspose.Slides
description: "Aspose.Slides for Java를 사용하여 PowerPoint PPT 및 PPTX에서 수학 방정식을 삽입하고 편집하며, OMML 지원, 서식 제어 및 명확한 Java 코드 예제를 제공합니다."
---
## **개요**

PowerPoint는 방정식을 Office Math Markup Language (OMML) 형식으로 저장합니다. Aspose.Slides for Java를 사용하면 프로그래밍 방식으로 동일한 종류의 수학 콘텐츠를 만들 수 있습니다: 분수, 근호, 함수, 극한, N-ary 연산자, 행렬, 배열 및 서식이 지정된 수학 블록.

PowerPoint에서 사용자는 일반적으로 **Insert>Equation**을 통해 방정식을 추가합니다:

![PowerPoint 삽입 탭에서 방정식 명령이 선택된 모습](powerpoint-math-equations_1.png)

결과는 슬라이드에 편집 가능한 수학 텍스트가 표시됩니다:

![편집 가능한 수학 방정식이 포함된 PowerPoint 슬라이드](powerpoint-math-equations_2.png)

Aspose.Slides는 다음 세 가지 주요 객체를 통해 해당 수학 텍스트를 구성합니다:

- [addMathShape](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ishapecollection/#addMathShape-float-float-float-float-)으로 만든 수학 도형은 방정식을 포함하는 도형입니다.
- [MathPortion](https://reference.aspose.com/slides/ko/java/com.aspose.slides/mathportion/)은 도형 텍스트 프레임 내부에 수학 콘텐츠를 저장합니다.
- [MathParagraph](https://reference.aspose.com/slides/ko/java/com.aspose.slides/mathparagraph/)은 하나 이상의 [MathBlock](https://reference.aspose.com/slides/ko/java/com.aspose.slides/mathblock/) 객체를 포함합니다.

아래 대부분의 예제는 [MathematicalText](https://reference.aspose.com/slides/ko/java/com.aspose.slides/mathematicaltext/)와 [IMathElement](https://reference.aspose.com/slides/ko/java/com.aspose.slides/imathelement/)의 fluent 메서드를 사용하여 코드를 간결하고 읽기 쉽게 유지합니다.

MathML 내보내기 시나리오는 [Export Math Equations from Presentations in Java](/slides/ko/java/exporting-math-equations/)를 참조하십시오.

## **방정식 만들기**

다음 예제는 수학 도형을 만들고 피타고라스 정리를 추가합니다:

![c² = a² + b² 방정식](powerpoint-math-equations_3.png)

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 120);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathBlock equation = new MathematicalText("c")
            .setSuperscript("2")
            .join("=")
            .join(new MathematicalText("a").setSuperscript("2"))
            .join("+")
            .join(new MathematicalText("b").setSuperscript("2"));

    mathParagraph.add(equation);

    presentation.save("pythagorean-theorem.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert color="primary" %}}
`addMathShape`는 이미 수학 단락이 포함된 도형을 생성합니다. 첫 번째 `MathPortion`에 접근하고, 그 `MathParagraph`를 가져와 수학 블록이나 수학 요소를 추가하십시오.
{{% /alert %}}

## **분수 추가**

`divide`를 사용하여 분수를 만듭니다. [MathFractionTypes](https://reference.aspose.com/slides/ko/java/com.aspose.slides/mathfractiontypes/)를 통해 분수 스타일을 선택할 수 있습니다.

![x 로 나누어진 한 분수를 보여주는 기울어진 수학 분수](powerpoint-math-equations_4.png)

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathFraction fraction = new MathematicalText("1")
            .divide("x", MathFractionTypes.Skewed);

    mathParagraph.add(new MathBlock(fraction));

    presentation.save("fraction.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

중첩 분수의 경우 `MathFractionTypes.Bar`를 사용하십시오:

```java
IMathFraction stackedFraction = new MathematicalText("x + 1").divide("y - 1", MathFractionTypes.Bar);
```

## **근호 추가**

`square root`, `cube root` 등 다른 근을 만들려면 `radical`을 사용합니다. 현재 요소가 밑이 되고 인수가 차수가 됩니다.

![x가 근호 기호 아래에 있는 n제곱근 표현식](powerpoint-math-equations_5.png)

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathRadical radical = new MathematicalText("x")
            .radical("n");

    mathParagraph.add(new MathBlock(radical));

    presentation.save("radical.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **함수 및 극한 추가**

`asArgumentOfFunction` 또는 `function`을 사용하여 `sin(x)`, `log(x)`와 같은 함수 또는 사용자 정의 함수 이름을 지정합니다. 극한의 경우 [MathLimit](https://reference.aspose.com/slides/ko/java/com.aspose.slides/mathlimit/)에 `lim`을 넣거나 `setLowerLimit`을 사용하십시오.

![x가 무한대로 접근할 때의 극한](powerpoint-math-equations_8.png)

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathFunction limit = new MathematicalText("lim")
            .setLowerLimit("x\u2192\u221E")
            .function("x");

    mathParagraph.add(new MathBlock(limit));

    presentation.save("functions-and-limits.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

사용자 정의 함수 이름을 사용하려면 현재 요소를 함수 이름으로 설정합니다:

```java
IMathFunction customFunction = new MathematicalText("f").function("x + 1");
```

## **N-ary 연산자 및 적분 추가**

합계, 합집합, 교집합 및 기타 큰 연산자는 `nary`를 사용합니다. 적분은 `integral`을 사용합니다. 두 메서드 모두 하한과 상한을 설정할 수 있습니다.

![하한과 상한이 있는 합계 표시](powerpoint-math-equations_7.png)

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 120);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathBlock summationBase = new MathematicalText("x")
            .setSuperscript("k")
            .join(new MathematicalText("a").setSuperscript("n-k"));

    IMathNaryOperator summation = summationBase.nary(MathNaryOperatorTypes.Summation, "k=0", "n");

    mathParagraph.add(new MathBlock(summation));

    presentation.save("nary-operators.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

N-ary 연산자는 선택적 한계가 있는 큰 연산자를 의미합니다. `+`, `-`, `=`와 같은 단순 연산자는 일반적으로 `MathematicalText`로 추가하고 표현식에 연결합니다.

적분의 경우 `integral`을 사용하십시오:

```java
IMathBlock integralBase = new MathematicalText("x").join(new MathematicalText("dx").toBox());
IMathNaryOperator integral = integralBase.integral(MathIntegralTypes.Simple, "0", "1");
```

## **행렬 추가**

행과 열을 지정하려면 [MathMatrix](https://reference.aspose.com/slides/ko/java/com.aspose.slides/mathmatrix/)를 사용합니다. 행렬은 기본적으로 괄호가 포함되지 않으므로 필요할 때는 괄호, 대괄호 또는 중괄호로 감싸야 합니다.

![한 셀이 비어 있는 두 행의 수학 행렬](powerpoint-math-equations_10.png)

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 120);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    MathMatrix matrix = new MathMatrix(2, 3);
    matrix.set_Item(0, 0, new MathematicalText("1"));
    matrix.set_Item(0, 1, new MathematicalText("x"));
    matrix.set_Item(1, 0, new MathematicalText("x"));
    matrix.set_Item(1, 1, new MathematicalText("2"));
    matrix.set_Item(1, 2, new MathematicalText("y"));

    mathParagraph.add(new MathBlock(matrix));

    presentation.save("matrix.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **방정식 배열 추가**

정렬된 방정식이나 수직으로 쌓인 표현식이 필요할 때 `toMathArray`를 사용합니다.

![x 위에 y가 있는 수직 수학 배열](powerpoint-math-equations_11.png)

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 140);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathArray equationArray = new MathematicalText("x")
            .join("y")
            .toMathArray();

    mathParagraph.add(new MathBlock(equationArray));

    presentation.save("equation-array.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **삼각함수 추가**

인수가 현재 요소이고 함수 이름이 알려진 경우 `asArgumentOfFunction`을 사용합니다.

![2x에 적용된 코사인 함수](powerpoint-math-equations_6.png)

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathFunction cosine = new MathematicalText("2x")
            .asArgumentOfFunction(MathFunctionsOfOneArgument.Cos);

    mathParagraph.add(new MathBlock(cosine));

    presentation.save("trigonometric-function.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **아래첨자 및 위첨자 추가**

인덱스와 거듭 제곱을 위해 아래첨자와 위첨자 도우미를 사용합니다. 인덱스가 기준 요소의 왼쪽에 표시되어야 할 때는 `setSubSuperscriptOnTheLeft`를 사용합니다.

![왼쪽에 아래첨자 1과 위첨자 n이 있는 대문자 Y](powerpoint-math-equations_9.png)

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathLeftSubSuperscriptElement scripts = new MathematicalText("Y")
            .setSubSuperscriptOnTheLeft("1", "n");

    mathParagraph.add(new MathBlock(scripts));

    presentation.save("subscript-superscript.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **구분자 추가**

표현식을 구분자 안에 넣으려면 `enclose`를 사용합니다. 여러 요소를 포함하는 구분자 표현식의 경우 구분자 문자를 설정할 수도 있습니다.

![수직 막대로 구분된 x, y, z가 포함된 구분자 표현식](powerpoint-math-equations_13.png)

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathDelimiter delimiter = new MathematicalText("x")
            .join("y")
            .join("z")
            .enclose('<', '>');
    delimiter.setSeparatorCharacter('|');

    mathParagraph.add(new MathBlock(delimiter));

    presentation.save("delimiters.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **테두리 상자 추가**

방정식 자체를 테두리로 감싸려면 `toBorderBox`를 사용합니다.

![b² + c²와 같은 제곱이 표시된 상자 안의 방정식](powerpoint-math-equations_12.png)

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathBorderBox boxedEquation = new MathematicalText("a")
            .setSuperscript("2")
            .join("=")
            .join(new MathematicalText("b").setSuperscript("2"))
            .join("+")
            .join(new MathematicalText("c").setSuperscript("2"))
            .toBorderBox();

    mathParagraph.add(new MathBlock(boxedEquation));

    presentation.save("border-box.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **항목 그룹화**

표현식 위 또는 아래에 그룹화 문자를 배치하려면 `group`을 사용합니다. 그룹화된 항목에 레이블을 달려면 제한을 추가하십시오.

![아래에 "any text" 레이블이 있는 x + y 표현식 그룹화](powerpoint-math-equations_15.png)

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 120);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathLimit grouped = new MathematicalText("x + y")
            .group('\u23DF', MathTopBotPositions.Bottom, MathTopBotPositions.Top)
            .setLowerLimit("any text");

    mathParagraph.add(new MathBlock(grouped));

    presentation.save("grouped-terms.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **수학 요소 서식 지정**

공식을 명확히 할 때만 서식 도우미를 사용하십시오. 예를 들어 `overbar`는 수학 요소 위에 선을 그립니다.

![위에 바가 있는 ABC 수학 표현식](powerpoint-math-equations_14.png)

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathBar overbar = new MathematicalText("ABC").overbar();

    mathParagraph.add(new MathBlock(overbar));

    presentation.save("overbar.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **빠른 참조**

| 작업 | 주요 API |
| --- | --- |
| 수학 텍스트 만들기 | [MathematicalText](https://reference.aspose.com/slides/ko/java/com.aspose.slides/mathematicaltext/) |
| 요소 결합 | [IMathElement.join](https://reference.aspose.com/slides/ko/java/com.aspose.slides/imathelement/#join-com.aspose.slides.IMathElement-) |
| 분수 만들기 | [IMathElement.divide](https://reference.aspose.com/slides/ko/java/com.aspose.slides/imathelement/#divide-com.aspose.slides.IMathElement-) |
| 위첨자·아래첨자 추가 | [setSuperscript](https://reference.aspose.com/slides/ko/java/com.aspose.slides/imathelement/#setSuperscript-com.aspose.slides.IMathElement-),[setSubscript](https://reference.aspose.com/slides/ko/java/com.aspose.slides/imathelement/#setSubscript-com.aspose.slides.IMathElement-) |
| 함수 추가 | [function](https://reference.aspose.com/slides/ko/java/com.aspose.slides/imathelement/#function-com.aspose.slides.IMathElement-),[asArgumentOfFunction](https://reference.aspose.com/slides/ko/java/com.aspose.slides/imathelement/#asArgumentOfFunction-com.aspose.slides.IMathElement-) |
| 근호 추가 | [IMathElement.radical](https://reference.aspose.com/slides/ko/java/com.aspose.slides/imathelement/#radical-com.aspose.slides.IMathElement-) |
| 극한 추가 | [setLowerLimit](https://reference.aspose.com/slides/ko/java/com.aspose.slides/imathelement/#setLowerLimit-com.aspose.slides.IMathElement-),[setUpperLimit](https://reference.aspose.com/slides/ko/java/com.aspose.slides/imathelement/#setUpperLimit-com.aspose.slides.IMathElement-) |
| 왼쪽 첨자 추가 | [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/ko/java/com.aspose.slides/imathelement/#setSubSuperscriptOnTheLeft-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-) |
| 합계·적분 추가 | [nary](https://reference.aspose.com/slides/ko/java/com.aspose.slides/imathelement/#nary-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-),[integral](https://reference.aspose.com/slides/ko/java/com.aspose.slides/imathelement/#integral-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-) |
| 행렬 추가 | [MathMatrix](https://reference.aspose.com/slides/ko/java/com.aspose.slides/mathmatrix/) |
| 방정식 배열 추가 | [toMathArray](https://reference.aspose.com/slides/ko/java/com.aspose.slides/imathelement/#toMathArray--) |
| 구분자 추가 | [enclose](https://reference.aspose.com/slides/ko/java/com.aspose.slides/imathelement/#enclose-char-char-) |
| 바·테두리 상자 추가 | [overbar](https://reference.aspose.com/slides/ko/java/com.aspose.slides/imathelement/#overbar--),[toBorderBox](https://reference.aspose.com/slides/ko/java/com.aspose.slides/imathelement/#toBorderBox--) |
| 항목 그룹화 | [group](https://reference.aspose.com/slides/ko/java/com.aspose.slides/imathelement/#group-char-int-int-) |

## **FAQ**

**기존 PowerPoint 방정식을 편집할 수 있나요?**

예. 프레젠테이션을 열고 `MathPortion`이 포함된 도형을 찾아 `MathParagraph`를 가져온 다음 해당 단락의 수학 블록을 업데이트합니다.

**방정식이 편집 가능한 PowerPoint 수학으로 저장되나요?**

예. PPTX로 저장하면 Aspose.Slides가 방정식을 편집 가능한 Office 수학 콘텐츠로 기록합니다.

**방정식을 LaTeX로 내보낼 수 있나요?**

예. 방정식의 [IMathParagraph](https://reference.aspose.com/slides/ko/java/com.aspose.slides/imathparagraph/)를 해당 [IMathPortion](https://reference.aspose.com/slides/ko/java/com.aspose.slides/imathportion/)에서 가져와 [IMathParagraph.toLatex](https://reference.aspose.com/slides/ko/java/com.aspose.slides/imathparagraph/#toLatex--)를 호출하면 직접 내보낼 수 있습니다. 전체 예제는 [Export Math Equations from Presentations in Java](/slides/ko/java/exporting-math-equations/#export-math-equations-to-latex) 를 확인하십시오.
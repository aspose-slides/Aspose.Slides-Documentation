---
title: JavaScript를 사용하여 PowerPoint 프레젠테이션에 수학 방정식 추가
linktitle: PowerPoint 수학 방정식
type: docs
weight: 80
url: /ko/nodejs-java/powerpoint-math-equations/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Node.js via Java용 Aspose.Slides를 사용하여 PowerPoint PPT 및 PPTX에 수학 방정식을 삽입하고 편집합니다. OMML 지원, 서식 제어 및 명확한 JavaScript 코드 샘플을 제공합니다."
---
## **개요**

PowerPoint는 수식을 Office Math Markup Language(OMML) 형식으로 저장합니다. Aspose.Slides for Node.js via Java를 사용하면 프로그래밍 방식으로 동일한 유형의 수학 콘텐츠(분수, 근, 함수, 극한, N-ary 연산자, 행렬, 배열 및 서식이 지정된 수식 블록)를 만들 수 있습니다.

PowerPoint에서 사용자는 일반적으로 **삽입 > 수식**을 통해 수식을 추가합니다.

![PowerPoint 삽입 탭에서 수식 명령이 선택된 화면](powerpoint-math-equations_1.png)

그 결과 슬라이드에 편집 가능한 수식 텍스트가 표시됩니다.

![편집 가능한 수식이 포함된 PowerPoint 슬라이드](powerpoint-math-equations_2.png)

Aspose.Slides는 다음 세 가지 주요 객체를 통해 해당 수식 텍스트를 구성합니다.

- [addMathShape](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/shapecollection/#addMathShape)으로 만든 수학 도형은 수식을 포함하는 도형입니다.
- [MathPortion](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/mathportion/)은 도형 텍스트 프레임 안에 수학 콘텐츠를 저장합니다.
- [MathParagraph](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/mathparagraph/)은 하나 이상의 [MathBlock](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/mathblock/) 객체를 포함합니다.

아래 대부분의 예제는 [MathematicalText](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/mathematicaltext/)와 [MathElementBase](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/mathelementbase/)의 유창한 메서드를 사용하여 코드를 짧고 읽기 쉽게 유지합니다.

MathML 내보내기 시나리오에 대해서는 [Export Math Equations from Presentations in Node.js via Java](/slides/ko/nodejs-java/exporting-math-equations/)를 참고하십시오.

## **수식 만들기**

이 예제는 수학 도형을 만들고 피타고라스 정리를 추가합니다.

![c² = a² + b² 수식 이미지](powerpoint-math-equations_3.png)

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 120);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let equation = new aspose.slides.MathematicalText("c")
            .setSuperscript("2")
            .join("=")
            .join(new aspose.slides.MathematicalText("a").setSuperscript("2"))
            .join("+")
            .join(new aspose.slides.MathematicalText("b").setSuperscript("2"));

    mathParagraph.add(equation);

    presentation.save("pythagorean-theorem.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert color="primary" %}}
`addMathShape`은 이미 수학 단락을 포함하는 도형을 생성합니다. 첫 번째 `MathPortion`에 접근하고, 해당 `MathParagraph`를 가져와 수학 블록 또는 수학 요소를 추가하십시오.
{{% /alert %}}

## **분수 추가**

[`divide`](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/mathelementbase/)를 사용하여 분수를 만들 수 있습니다. [MathFractionTypes](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/mathfractiontypes/)로 분수 스타일을 선택하십시오.

![x 로 나누어진 1을 나타내는 기울어진 분수 이미지](powerpoint-math-equations_4.png)

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let fraction = new aspose.slides.MathematicalText("1")
            .divide("x", aspose.slides.MathFractionTypes.Skewed);

    mathParagraph.add(new aspose.slides.MathBlock(fraction));

    presentation.save("fraction.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

쌓인 형태의 분수를 만들려면 `MathFractionTypes.Bar`를 사용하십시오.

```javascript
let stackedFraction = new aspose.slides.MathematicalText("x + 1").divide("y - 1", aspose.slides.MathFractionTypes.Bar);
```

## **근 추가**

[`radical`](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/mathelementbase/)을 사용하여 제곱근, 세제곱근 또는 기타 근을 만들 수 있습니다. 현재 요소가 밑이 되고 인수가 차수가 됩니다.

![근호 아래에 x가 있는 n제곱근 표현식 이미지](powerpoint-math-equations_5.png)

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let radical = new aspose.slides.MathematicalText("x")
            .radical("n");

    mathParagraph.add(new aspose.slides.MathBlock(radical));

    presentation.save("radical.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **함수 및 극한 추가**

함수(`sin(x)`, `log(x)` 등) 또는 사용자 정의 함수 이름을 위해 [`asArgumentOfFunction`](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/mathelementbase/) 또는 [`function`](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/mathelementbase/)을 사용하십시오. 극한을 표현하려면 [MathLimit](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/mathlimit/)에 `lim`을 넣거나 [`setLowerLimit`](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/mathelementbase/)를 사용하십시오.

![x가 무한대로 접근할 때의 극한 이미지](powerpoint-math-equations_8.png)

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let limit = new aspose.slides.MathematicalText("lim")
            .setLowerLimit("x\u2192\u221E")
            .function("x");

    mathParagraph.add(new aspose.slides.MathBlock(limit));

    presentation.save("functions-and-limits.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

사용자 정의 함수 이름을 지정하려면 현재 요소를 함수 이름으로 설정하십시오.

```javascript
let customFunction = new aspose.slides.MathematicalText("f").function("x + 1");
```

## **N-ary 연산자 및 적분 추가**

합계, 합집합, 교집합 및 기타 큰 연산자를 위해 [`nary`](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/mathelementbase/)를 사용하십시오. 적분은 [`integral`](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/mathelementbase/)를 사용합니다. 두 메서드 모두 하한 및 상한을 설정할 수 있습니다.

![하한과 상한이 있는 합계 이미지](powerpoint-math-equations_7.png)

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 120);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let summationBase = new aspose.slides.MathematicalText("x")
            .setSuperscript("k")
            .join(new aspose.slides.MathematicalText("a").setSuperscript("n-k"));

    let summation = summationBase.nary(aspose.slides.MathNaryOperatorTypes.Summation, "k=0", "n");

    mathParagraph.add(new aspose.slides.MathBlock(summation));

    presentation.save("nary-operators.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

N-ary 연산자는 선택적 한계가 있는 큰 연산자를 위한 것입니다. `+`, `-`, `=`와 같은 단순 연산자는 일반적으로 `MathematicalText`로 추가하고 식에 결합합니다.

적분을 추가하려면 `integral`을 사용하십시오.

```javascript
let integralBase = new aspose.slides.MathematicalText("x").join(new aspose.slides.MathematicalText("dx").toBox());
let integral = integralBase.integral(aspose.slides.MathIntegralTypes.Simple, "0", "1");
```

## **행렬 추가**

행과 열을 정의하려면 [MathMatrix](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/mathmatrix/)를 사용하십시오. 행렬은 기본적으로 괄호를 포함하지 않으므로 필요에 따라 괄호, 대괄호 또는 중괄호로 감싸야 합니다.

![한 셀이 비어 있는 두 행으로 구성된 수학 행렬 이미지](powerpoint-math-equations_10.png)

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 120);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let matrix = new aspose.slides.MathMatrix(2, 3);
    matrix.set_Item(0, 0, new aspose.slides.MathematicalText("1"));
    matrix.set_Item(0, 1, new aspose.slides.MathematicalText("x"));
    matrix.set_Item(1, 0, new aspose.slides.MathematicalText("x"));
    matrix.set_Item(1, 1, new aspose.slides.MathematicalText("2"));
    matrix.set_Item(1, 2, new aspose.slides.MathematicalText("y"));

    mathParagraph.add(new aspose.slides.MathBlock(matrix));

    presentation.save("matrix.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **수식 배열 추가**

정렬된 수식이나 세로로 쌓인 표현식이 필요할 때는 [`toMathArray`](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/mathelementbase/)를 사용하십시오.

![x 위에 y가 있는 세로 수식 배열 이미지](powerpoint-math-equations_11.png)

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 140);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let equationArray = new aspose.slides.MathematicalText("x")
            .join("y")
            .toMathArray();

    mathParagraph.add(new aspose.slides.MathBlock(equationArray));

    presentation.save("equation-array.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **삼각 함수 추가**

인수가 현재 요소이고 함수 이름이 알려져 있을 때는 [`asArgumentOfFunction`](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/mathelementbase/)를 사용하십시오.

![cos 함수가 2x에 적용된 삼각 함수 이미지](powerpoint-math-equations_6.png)

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let cosine = new aspose.slides.MathematicalText("2x")
            .asArgumentOfFunction(aspose.slides.MathFunctionsOfOneArgument.Cos);

    mathParagraph.add(new aspose.slides.MathBlock(cosine));

    presentation.save("trigonometric-function.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **첨자 및 위첨자 추가**

인덱스와 지수를 위해 첨자 및 위첨자 도우미를 사용하십시오. 인덱스가 기본 요소의 왼쪽에 표시되어야 할 경우 [`setSubSuperscriptOnTheLeft`](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/mathelementbase/)를 사용하십시오.

![왼쪽에 첨자 1과 위첨자 n이 있는 대문자 Y 이미지](powerpoint-math-equations_9.png)

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let scripts = new aspose.slides.MathematicalText("Y")
            .setSubSuperscriptOnTheLeft("1", "n");

    mathParagraph.add(new aspose.slides.MathBlock(scripts));

    presentation.save("subscript-superscript.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **구분 기호 추가**

표현식을 구분 기호 안에 넣으려면 [`enclose`](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/mathelementbase/)를 사용하십시오. 여러 요소를 포함하는 구분 기호 표현식에는 구분자를 설정할 수도 있습니다.

![수직 막대로 구분된 x, y, z가 포함된 구분 기호 표현식 이미지](powerpoint-math-equations_13.png)

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let delimiter = new aspose.slides.MathematicalText("x")
            .join("y")
            .join("z")
            .enclose(java.newChar('<'), java.newChar('>'));
    delimiter.setSeparatorCharacter(java.newChar('|'));

    mathParagraph.add(new aspose.slides.MathBlock(delimiter));

    presentation.save("delimiters.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **테두리 상자 추가**

수식 자체를 테두리로 감싸려면 [`toBorderBox`](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/mathelementbase/)를 사용하십시오.

![a² = b² + c² 라는 상자 안에 있는 수식 이미지](powerpoint-math-equations_12.png)

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let boxedEquation = new aspose.slides.MathematicalText("a")
            .setSuperscript("2")
            .join("=")
            .join(new aspose.slides.MathematicalText("b").setSuperscript("2"))
            .join("+")
            .join(new aspose.slides.MathematicalText("c").setSuperscript("2"))
            .toBorderBox();

    mathParagraph.add(new aspose.slides.MathBlock(boxedEquation));

    presentation.save("border-box.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **항 그룹화**

표현식 위 또는 아래에 그룹화 기호를 배치하려면 [`group`](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/mathelementbase/)를 사용하십시오. 그룹화된 항에 라벨을 붙이려면 제한을 추가하십시오.

![아래에 임의의 텍스트 라벨이 있는 x + y 표현식 이미지](powerpoint-math-equations_15.png)

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 120);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let grouped = new aspose.slides.MathematicalText("x + y")
            .group(java.newChar('\u23DF'), aspose.slides.MathTopBotPositions.Bottom, aspose.slides.MathTopBotPositions.Top)
            .setLowerLimit("any text");

    mathParagraph.add(new aspose.slides.MathBlock(grouped));

    presentation.save("grouped-terms.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **수학 요소 서식 지정**

수식의 가독성을 높이는 경우에만 서식 지정 도우미를 사용하십시오. 예를 들어 [`overbar`](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/mathelementbase/)는 수학 요소 위에 바를 표시합니다.

![overbar가 적용된 ABC 수식 이미지](powerpoint-math-equations_14.png)

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let overbar = new aspose.slides.MathematicalText("ABC").overbar();

    mathParagraph.add(new aspose.slides.MathBlock(overbar));

    presentation.save("overbar.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **빠른 참조**

| 작업 | 주요 API |
| --- | --- |
| 수학 텍스트 만들기 | [MathematicalText](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/mathematicaltext/) |
| 요소 결합 | [join](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/mathelementbase/) |
| 분수 만들기 | [divide](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/mathelementbase/) |
| 위첨자·첨자 추가 | [setSuperscript](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/mathelementbase/), [setSubscript](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/mathelementbase/) |
| 함수 추가 | [function](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/mathelementbase/), [asArgumentOfFunction](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/mathelementbase/) |
| 근 추가 | [radical](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/mathelementbase/) |
| 극한 추가 | [setLowerLimit](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/mathelementbase/), [setUpperLimit](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/mathelementbase/) |
| 왼쪽 스크립트 추가 | [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/mathelementbase/) |
| 합계·적분 추가 | [nary](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/mathelementbase/), [integral](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/mathelementbase/) |
| 행렬 추가 | [MathMatrix](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/mathmatrix/) |
| 수식 배열 추가 | [toMathArray](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/mathelementbase/) |
| 구분 기호 추가 | [enclose](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/mathelementbase/) |
| 바·테두리 추가 | [overbar](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/mathelementbase/), [toBorderBox](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/mathelementbase/) |
| 항 그룹화 | [group](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/mathelementbase/) |

## **FAQ**

**기존 PowerPoint 수식을 편집할 수 있나요?**

예. 프레젠테이션을 열고 `MathPortion`을 포함하는 도형을 찾은 다음 해당 `MathParagraph`를 가져와 그 단락의 수학 블록을 업데이트하면 됩니다.

**수식이 편집 가능한 PowerPoint 수식으로 저장되나요?**

예. PPTX로 저장하면 Aspose.Slides가 수식을 편집 가능한 Office 수식 콘텐츠로 기록합니다.

**수식을 LaTeX로 내보낼 수 있나요?**

Aspose.Slides는 수식을 MathML로 내보냅니다. LaTeX가 필요하면 먼저 MathML로 내보낸 뒤, 대상 LaTeX 방언을 지원하는 도구를 사용해 MathML을 변환하십시오.
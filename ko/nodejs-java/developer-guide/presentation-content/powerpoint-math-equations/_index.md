---
title: "JavaScript를 사용하여 PowerPoint 프레젠테이션에 수식 추가"
linktitle: "PowerPoint 수식"
type: docs
weight: 80
url: /ko/nodejs-java/powerpoint-math-equations/
keywords:
- 수식
- 수학 기호
- 수학 공식
- 수학 텍스트
- 수식 추가
- 기호 추가
- 공식 추가
- 텍스트 추가
- PowerPoint
- 프레젠테이션
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java를 사용하여 PowerPoint PPT 및 PPTX에 수식을 삽입하고 편집할 수 있으며, OMML 지원, 서식 제어 및 명확한 JavaScript 코드 샘플을 제공합니다."
---
## **개요**

PowerPoint은 방정식을 Office Math Markup Language(OMML)로 저장합니다. Aspose.Slides for Node.js via Java를 사용하면 동일한 유형의 수학 콘텐츠를 프로그래밍 방식으로 만들 수 있습니다: 분수, 근호, 함수, 극한, N-ary 연산자, 행렬, 배열 및 서식이 지정된 수식 블록.

PowerPoint에서 사용자는 일반적으로 **Insert > Equation**을 통해 방정식을 추가합니다:

![PowerPoint 삽입 탭에 방정식 명령이 선택된 상태](powerpoint-math-equations_1.png)

그 결과 슬라이드에 편집 가능한 수식 텍스트가 표시됩니다:

![편집 가능한 수식 방정식이 포함된 PowerPoint 슬라이드](powerpoint-math-equations_2.png)

Aspose.Slides는 다음 세 가지 주요 객체를 통해 해당 수식 텍스트를 구성합니다:

- [addMathShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addMathShape)으로 만든 수식 도형은 방정식을 포함하는 도형입니다.
- [MathPortion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/)은 도형 텍스트 프레임 내부에 수식 내용을 저장합니다.
- [MathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathparagraph/)은 하나 이상의 [MathBlock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathblock/) 객체를 포함합니다.

아래 대부분 예제는 [MathematicalText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathematicaltext/)과 [MathElementBase](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/)의 fluent 메서드를 사용하여 코드를 짧고 읽기 쉽게 유지합니다.

MathML 내보내기 시나리오에 대해서는 [Export Math Equations from Presentations in Node.js via Java](/slides/ko/nodejs-java/exporting-math-equations/)를 참조하십시오.

## **방정식 만들기**

이 예제는 [addMathShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addMathShape)으로 수식 도형을 만든 뒤 피타고라스 정리를 추가합니다:

![c² = a² + b² 방정식 이미지](powerpoint-math-equations_3.png)

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

{{% alert color="info" title="Note" %}}
[addMathShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addMathShape)는 이미 수식 단락을 포함하고 있는 도형을 생성합니다. 첫 번째 [MathPortion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/)에 접근하고 [getMathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/#getMathParagraph)를 호출한 뒤 수식 블록이나 수식 요소를 추가하십시오.
{{% /alert %}}

### **수식 블록 결합**

방정식의 일부가 독립된 [MathBlock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathblock/) 객체로 구성된 경우, [joinBlock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathblock/#joinBlock)를 사용해 결합합니다. 아래 예제는 왼쪽 블록에 `c² =`를, 오른쪽 블록에 `a² + b²`를 구축합니다. [setSuperscript](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#setSuperscript)는 세 개의 거듭제곱을 모두 편집 가능한 수학 상위 첨자로 만듭니다.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addMathShape(20, 20, 600, 100);
    const mathPortion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    const mathParagraph = mathPortion.getMathParagraph();

    const leftBlock = new slides.MathBlock();
    leftBlock.add(new slides.MathematicalText("c").setSuperscript("2"));
    leftBlock.add(new slides.MathematicalText("="));

    const rightBlock = new slides.MathBlock();
    rightBlock.add(new slides.MathematicalText("a").setSuperscript("2"));
    rightBlock.add(new slides.MathematicalText("+"));
    rightBlock.add(new slides.MathematicalText("b").setSuperscript("2"));

    const combinedBlock = leftBlock.joinBlock(rightBlock);
    mathParagraph.add(combinedBlock);

    presentation.save("equation.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[joinBlock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathblock/#joinBlock)는 이제 두 부분을 순서대로 포함하는 `leftBlock` 자체를 반환하고 `rightBlock`은 비게 됩니다. 결합된 블록은 [MathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathparagraph/)에 한 번만 추가합니다. `equation.pptx`를 다시 열면 단락에 `c² = a² + b²`를 나타내는 하나의 블록이 포함되며, 세 개의 거듭제곱은 모두 수학 상위 첨자로 보존됩니다.

[add](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathblock/#add)를 `leftBlock.add(rightBlock)`처럼 호출하면 블록을 직접 중첩하려고 시도하게 되며 `InvalidOperationException`이 발생합니다.

## **분수 추가**

[divide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#divide)를 사용해 분수를 만듭니다. [MathFractionTypes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathfractiontypes/)를 통해 분수 스타일을 선택할 수 있습니다.

![x로 나누는 한 쪽이 기울어진 수학 분수 이미지](powerpoint-math-equations_4.png)

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

쌓인 분수의 경우, [MathFractionTypes.Bar](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathfractiontypes/#Bar)를 사용합니다:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let stackedFraction = new aspose.slides.MathematicalText("x + 1").divide("y - 1", aspose.slides.MathFractionTypes.Bar);
```

## **근호 추가**

[radical](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#radical)를 사용해 제곱근, 세제곱근 또는 기타 근호를 생성합니다. 현재 요소가 밑이 되고 인수가 차수가 됩니다.

![x가 근호 기호 아래에 있는 n제곱근 표현식 이미지](powerpoint-math-equations_5.png)

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

### **제곱근 차수 표시/숨기기**

제곱근은 명시적인 2를 표시하거나 전통적인 √x 표기법을 사용할 수 있습니다. [MathRadical](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathradical/)의 [setHideDegree](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathradical/#setHideDegree) 메서드가 형태를 제어합니다. 두 형태 모두 차수 2와 피제곱근 x를 편집 가능한 방정식에 보존합니다.

![왼쪽에 차수가 보이고 오른쪽에 숨겨진 동일한 제곱근 이미지](square-root-degree.png)

예제는 동일한 제곱근을 두 번 저장합니다. `visible-degree.pptx`에서는 2가 보이고, `hidden-degree.pptx`에서는 숨겨집니다.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let radical = new aspose.slides.MathematicalText("x").radical("2");
    
    let shape = slide.getShapes().addMathShape(20, 20, 200, 100);
    let portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.getMathParagraph().add(new aspose.slides.MathBlock(radical));

    radical.setHideDegree(false);
    presentation.save("visible-degree.pptx", aspose.slides.SaveFormat.Pptx);

    radical.setHideDegree(true);
    presentation.save("hidden-degree.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **함수 및 극한 추가**

[asArgumentOfFunction](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#asArgumentOfFunction) 또는 [function](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#function)를 사용해 `sin(x)`, `log(x)`와 같은 함수 또는 사용자 정의 함수명을 삽입합니다. 극한을 추가하려면 `lim`을 [MathLimit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathlimit/)에 넣거나 [setLowerLimit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#setLowerLimit)를 사용합니다.

![무한대로 접근하는 x의 극한 이미지](powerpoint-math-equations_8.png)

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

사용자 정의 함수명인 경우 현재 요소를 함수명으로 만든 뒤 인수와 함께 [function](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#function)를 호출합니다:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let customFunction = new aspose.slides.MathematicalText("f").function("x + 1");
```

## **N-ary 연산자 및 적분 추가**

[nary](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#nary)를 사용해 합계, 합집합, 교집합 및 기타 대형 연산자를 만들 수 있습니다. [integral](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#integral)를 사용해 적분을 추가합니다. 두 메서드 모두 하한과 상한을 설정할 수 있습니다.

![하한과 상한이 있는 합계 이미지](powerpoint-math-equations_7.png)

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

N-ary 연산자는 선택적 한계가 있는 대형 연산자에 사용됩니다. `+`, `-`, `=`와 같은 단순 연산자는 보통 [MathematicalText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathematicaltext/)으로 추가하고 표현식에 결합합니다.

적분의 경우, [integral](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#integral)를 사용합니다:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let integralBase = new aspose.slides.MathematicalText("x").join(new aspose.slides.MathematicalText("dx").toBox());
let integral = integralBase.integral(aspose.slides.MathIntegralTypes.Simple, "0", "1");
```

## **행렬 추가**

[MathMatrix](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathmatrix/)를 사용해 행과 열을 정의합니다. 행렬은 기본적으로 괄호를 포함하지 않으므로 필요에 따라 괄호, 대괄호 또는 중괄호로 둘러싸야 합니다.

![한 셀 비어 있는 두 행 수학 행렬 이미지](powerpoint-math-equations_10.png)

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

### **기존 행렬 편집**

예를 들어 `matrix.pptx`에 계수 행렬이 저장되어 있다고 가정합니다. 다음 연습에서는 첫 번째 방정식을 유지하고 두 번째를 두 개의 새 방정식으로 교체하며 변수 집합을 수정합니다. 기존 행렬을 [MathMatrix](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathmatrix/)를 통해 열어 아직 적용 가능한 계수를 유지합니다.

![첫 번째 행에 1, x, 빈 셀, 두 번째 행에 x, 2, y가 있는 원본 두 행 계수 행렬 이미지](matrix-before-edit.png)

행 및 열 인덱스는 0부터 시작하며 각 호출 시점의 행렬 상태를 기준으로 합니다. 인덱스 1 앞에 행을 삽입하면 원래 두 번째 행이 인덱스 2로 이동합니다. 인덱스 2 뒤에 삽입하면 행이 추가됩니다. 행 2를 삭제하면 원래 두 번째 방정식이 제거되고 추가된 행이 한 위치 위로 이동합니다. 열도 동일하게 이동합니다.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("matrix.pptx");
try {
    const shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    const matrix = portion.getMathParagraph().get_Item(0).get_Item(0);

    matrix.insertRowBefore(1);
    matrix.insertRowAfter(2);
    matrix.deleteRow(2);

    matrix.insertColumnBefore(1);
    matrix.insertColumnAfter(3);
    matrix.deleteColumn(3);

    // 새 셀은 처음에 null입니다. 먼저 0이 아닌 계수를 설정하십시오.
    matrix.set_Item(1, 0, new slides.MathematicalText("12"));
    matrix.set_Item(1, 1, new slides.MathematicalText("1"));
    matrix.set_Item(2, 2, new slides.MathematicalText("10"));
    matrix.set_Item(2, 3, new slides.MathematicalText("1"));
    for (let row = 0; row < matrix.getRowCount(); row++) {
        for (let column = 0; column < matrix.getColumnCount(); column++) {
            if (matrix.get_Item(row, column) == null) {
                matrix.set_Item(row, column, new slides.MathematicalText("0"));
            }
        }
    }

    matrix.setColumnAlignment(0, slides.MathHorizontalAlignment.Left);
    matrix.setColumnsAlignment(1, 3, slides.MathHorizontalAlignment.Right);

    presentation.save("updated-matrix.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[setColumnAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathmatrix/#setColumnAlignment)는 첫 번째 열을 왼쪽 정렬합니다. [setColumnsAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathmatrix/#setColumnsAlignment)는 인덱스 1부터 시작하는 연속된 세 열을 오른쪽 정렬합니다. `updated-matrix.pptx`에서는 행렬에 세 개의 방정식과 네 개의 변수가 있습니다. 원래 첫 행의 계수 `1`과 `x`가 이제 첫 번째와 세 번째 열에 나타납니다.

![업데이트된 세 행 행렬 이미지(행 내용: 1,0,x,0; 12,1,0,0; 0,0,10,1)](matrix-after-edit.png)

## **방정식 배열 추가**

[toMathArray](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#toMathArray)를 사용해 정렬된 방정식이나 수직 스택 표현식을 만들 수 있습니다.

![x 위에 y가 있는 수직 수식 배열 이미지](powerpoint-math-equations_11.png)

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

### **주변 요소와 배열 정렬**

[setBaseJustification](https://reference.aspose.com/slides/nodejs-java/aspose.slides/matharray/#setBaseJustification)는 배열이 옆에 있는 수학 요소와 수직으로 어떻게 정렬되는지를 제어합니다. 아래 예제는 첫 번째 행, 배열 중앙, 마지막 행과 정렬을 비교합니다.

다음 예제는 세 개의 동일한 배열을 만들며, 각각은 세 행과 주변 요소 `A=` 및 `=B`를 포함합니다. 모든 수식 텍스트는 Cambria Math 24포인트를 사용합니다. 배열 정렬만 다르게 설정됩니다.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

function createText(value) {
    const text = new slides.MathematicalText(value);
    text.getFormat().setFontHeight(24);
    text.getFormat().setLatinFont(new slides.FontData("Cambria Math"));
    return text;
}

const presentation = new slides.Presentation();
try {
    presentation.getSlideSize().setSize(780, 200, slides.SlideSizeScaleType.DoNotScale);
    const slide = presentation.getSlides().get_Item(0);

    const alignments = [slides.MathVerticalAlignment.Top, slides.MathVerticalAlignment.Center, slides.MathVerticalAlignment.Bottom];
    const alignmentNames = ["Top", "Center", "Bottom"];

    for (let i = 0; i < alignments.length; i++) {
        const label = slide.getShapes().addAutoShape(slides.ShapeType.Rectangle, 20 + i * 260, 10, 240, 30);
        label.getFillFormat().setFillType(java.newByte(slides.FillType.NoFill));
        label.getLineFormat().getFillFormat().setFillType(java.newByte(slides.FillType.NoFill));
        label.getTextFrame().setText(alignmentNames[i]);
        const labelFormat = label.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
        labelFormat.setFontHeight(16);
        labelFormat.getFillFormat().setFillType(java.newByte(slides.FillType.Solid));
        labelFormat.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));

        const mathShape = slide.getShapes().addMathShape(20 + i * 260, 60, 240, 130);
        mathShape.getTextFrame().getTextFrameFormat().setAnchoringType(java.newByte(slides.TextAnchorType.Top));
        const mathParagraph = mathShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph();
        mathParagraph.setJustification(slides.MathJustification.LeftJustified);

        const rows = [createText("x+y=3"), createText("x-y=1"), createText("x=2")];
        const equationArray = new slides.MathArray(rows[0]);
        equationArray.getArguments().add(rows[1]);
        equationArray.getArguments().add(rows[2]);
        equationArray.setBaseJustification(alignments[i]);
        const leftText = createText("A=");
        const rightText = createText("=B");
        const equation = new slides.MathBlock(leftText).join(equationArray).join(rightText);
        mathParagraph.add(equation);
    }

    presentation.save("equation-array-alignment.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

아래 비교는 PowerPoint에서 저장된 프레젠테이션을 보여 줍니다. 각 배열 옆에 있는 `A=`와 `=B` 위치를 확인하십시오.

![PowerPoint에서 상단, 중앙, 하단 정렬된 방정식 배열 이미지(주변 요소 동일)](equation-array-alignment.png)

### **행 간격 구성**

[setRowSpacingRule](https://reference.aspose.com/slides/nodejs-java/aspose.slides/matharray/#setRowSpacingRule)는 배열 내 행 간격 규칙을 선택합니다. [setRowSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/matharray/#setRowSpacing)는 명시적 간격 규칙에 대한 숫자 값을 제공하며 사전 설정 규칙에는 무시됩니다.

정확한 간격은 포인트 단위로 측정됩니다. 비례 간격은 반행 단위로 측정되며, 예제의 값 `3`은 1.5줄을 의미합니다. 명시적 값을 지정할 때는 두 속성을 모두 설정해야 하며, 숫자 값만 변경해도 간격 규칙이 선택되지 않습니다.

아래 예제는 동일한 방정식, 정렬 및 글꼴 설정을 가진 다섯 개의 프레젠테이션을 저장합니다. 처음 세 개는 사전 설정을 사용하고, 마지막 두 개는 명시적 값을 사용합니다.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

function createText(value) {
    const text = new slides.MathematicalText(value);
    text.getFormat().setFontHeight(24);
    text.getFormat().setLatinFont(new slides.FontData("Cambria Math"));
    return text;
}

const rules = [slides.MathRowSpacingRule.SingleLineGap, slides.MathRowSpacingRule.OneAndAHalfLineGap, slides.MathRowSpacingRule.TwoLineGap, slides.MathRowSpacingRule.Exactly, slides.MathRowSpacingRule.Multiple];
const spacingValues = [0, 0, 0, 20, 3];
const ruleNames = ["SingleLineGap", "OneAndAHalfLineGap", "TwoLineGap", "Exactly", "Multiple"];

for (let i = 0; i < rules.length; i++) {
    const fileName = "equation-array-" + ruleNames[i] + ".pptx";
    const presentation = new slides.Presentation();
    try {
        const mathShape = presentation.getSlides().get_Item(0).getShapes().addMathShape(20, 20, 600, 300);
        const paragraph = mathShape.getTextFrame().getParagraphs().get_Item(0);
        paragraph.getParagraphFormat().setSpaceBefore(0);
        paragraph.getParagraphFormat().setSpaceAfter(0);
        const mathParagraph = paragraph.getPortions().get_Item(0).getMathParagraph();
        mathParagraph.setJustification(slides.MathJustification.LeftJustified);

        const rows = [createText("x+y=3"), createText("x-y=1"), createText("x=2")];
        const equationArray = new slides.MathArray(rows[0]);
        equationArray.getArguments().add(rows[1]);
        equationArray.getArguments().add(rows[2]);
        equationArray.setBaseJustification(slides.MathVerticalAlignment.Center);
        equationArray.setRowSpacingRule(rules[i]);
        equationArray.setRowSpacing(java.newLong(spacingValues[i]));
        const leftText = createText("A=");
        const rightText = createText("=B");
        const equation = new slides.MathBlock(leftText).join(equationArray).join(rightText);
        mathParagraph.add(equation);

        presentation.save(fileName, slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

배열 행 간격은 단락 간격과 별개입니다. [setSpaceBefore](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setSpaceBefore)와 [setSpaceAfter](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setSpaceAfter)는 배열이 포함된 단락 주위에 공간을 추가하며, 배열 행 사이에 공간을 추가하지는 않습니다. 마찬가지로 [MathParagraph.setJustification](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathparagraph/#setJustification)은 전체 수식 단락을 수평으로 배치하며, 배열의 수직 정렬 설정을 대체하지 않습니다.

## **삼각 함수 추가**

인수가 현재 요소이고 함수 이름이 알려진 경우 [asArgumentOfFunction](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#asArgumentOfFunction)를 사용합니다.

![2x에 적용된 cos 삼각 함수 이미지](powerpoint-math-equations_6.png)

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

인덱스와 거듭제곱을 위해 첨자와 위첨자 도우미를 사용합니다. 인덱스가 기반 요소의 왼쪽에 표시되어야 하는 경우 [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#setSubSuperscriptOnTheLeft)를 사용합니다.

![왼쪽에 첨자 1과 위첨자 n이 있는 대문자 Y 이미지](powerpoint-math-equations_9.png)

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

### **우측 첨자 및 위첨자 정렬**

두 스크립트가 같은 기반에 속할 때는 [MathRightSubSuperscriptElement](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathrightsubsuperscriptelement/)를 사용합니다. 해당 요소의 [setAlignScripts](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathrightsubsuperscriptelement/#setAlignScripts) 메서드는 수평 위치를 제어합니다: 기본값 `false`는 기반의 윤곽을 따르게 하고, `true`는 스크립트를 서로 수평으로 맞춥니다.

이 예제는 동일한 편집 가능한 표현식을 나란히 두 개 배치합니다. 두 경우 모두 수학 이탤릭 f(U+1D453), 아래 첨자 1, 위첨자 2, Cambria Math 72포인트를 사용합니다. 기울어진 기반 때문에 차이가 PowerPoint에서 명확히 보입니다. 예제를 실행하기 전에 Cambria Math를 설치하십시오.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    presentation.getSlideSize().setSize(900, 250, slides.SlideSizeScaleType.DoNotScale);
    const slide = presentation.getSlides().get_Item(0);

    const format = new slides.PortionFormat();
    format.setFontHeight(72);
    const font = new slides.FontData("Cambria Math");
    format.setLatinFont(font);

    for (let i = 0; i < 2; i++) {
        const left = 40 + i * 440;
        const shape = slide.getShapes().addMathShape(left, 75, 380, 150);

        const baseText = new slides.MathematicalText("\uD835\uDC53", format);
        const subscript = new slides.MathematicalText("1", format);
        const superscript = new slides.MathematicalText("2", format);
        const scripts = new slides.MathRightSubSuperscriptElement(baseText, subscript, superscript);
        scripts.setAlignScripts(i === 1);

        const portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
        portion.getPortionFormat().setFontHeight(format.getFontHeight());
        portion.getPortionFormat().setLatinFont(format.getLatinFont());
        const block = new slides.MathBlock(scripts);
        portion.getMathParagraph().add(block);
    }

    presentation.save("aligned-scripts.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![좌측은 setAlignScripts가 false, 우측은 true인 두 편집 가능한 표현식 이미지](aligned-scripts.png)

좌측에서는 아래 첨자가 위 첨자보다 더 왼쪽에서 시작해 기반의 윤곽을 따릅니다. 우측에서는 두 스크립트가 서로 수평으로 정렬됩니다.

## **구분 기호 추가**

[enclose](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#enclose)를 사용해 표현식을 구분 기호 안에 넣을 수 있습니다. 여러 요소를 포함하는 구분 기호 표현식의 경우 구분 문자도 설정할 수 있습니다.

![x, y, z가 수직 막대로 구분된 구분 기호 표현식 이미지](powerpoint-math-equations_13.png)

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

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

### **구분 기호 크기 및 정렬**

[setGrowToMatchOperandHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathdelimiter/#setGrowToMatchOperandHeight)에 `true`를 전달하면 큰 피연산자 주위에 괄호가 커집니다. `false`를 전달하면 정상 크기를 유지합니다. [setDelimiterShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathdelimiter/#setDelimiterShape)와 함께 [MathDelimiterShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathdelimitershape/) 값 중 하나를 사용합니다. `Centered`는 괄호를 수식 축 중앙에 맞추고, `Match`는 내용에 맞게 정렬합니다. 두 설정 모두 구분 기호에만 영향을 주며 표현식 자체는 변경되지 않습니다.

예제는 `x`의 지수에 분수를 넣어 표현식이 기준선 위쪽으로 더 크게 확장되도록 합니다. 네 개의 방정식 모두 동일한 괄호와 글꼴 설정을 사용합니다.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    for (let row = 0; row < 2; row++) {
        for (let column = 0; column < 2; column++) {
            const fraction = new slides.MathematicalText("a + b").divide("c + d");
            const power = new slides.MathematicalText("x").setSuperscript(fraction);
            const delimiter = power.enclose(java.newChar('('), java.newChar(')'));
            delimiter.setGrowToMatchOperandHeight(row === 0);
            delimiter.setDelimiterShape(column === 0 ? slides.MathDelimiterShape.Centered : slides.MathDelimiterShape.Match);

            const mathShape = slide.getShapes().addMathShape(20 + 330 * column, 20 + 120 * row, 300, 100);
            const portion = mathShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
            portion.getPortionFormat().setFontHeight(32);
            const equation = new slides.MathematicalText("y = ").join(delimiter);
            portion.getMathParagraph().add(equation);
        }
    }
    presentation.save("delimiter-sizing.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

PowerPoint에서 행을 비교하면 성장 효과를 확인할 수 있습니다. 상단 행에서는 괄호가 지수를 둘러싸며 두 형태가 동일하게 보입니다. 하단 행에서는 성장이 꺼져 있습니다. 왼쪽의 작은 괄호(`Centered`)는 등호에 맞추고, 오른쪽의 괄호(`Match`)는 표현식 위에 더 높게 위치합니다.

![괄호 성장 활성/비활성 및 Centered/Match 비교 이미지](delimiter-sizing.png)

## **테두리 박스 추가**

분수에 [toBorderBox](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#toBorderBox)를 호출하면 전체 표현식을 둘러싼 테두리 상자를 만들 수 있습니다. 반환된 [MathBorderBox](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/)는 기본적으로 네 면이 모두 표시됩니다. [setHideTop](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setHideTop), [setHideBottom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setHideBottom), [setHideLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setHideLeft), [setHideRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setHideRight)를 사용해 개별 면을 제거할 수 있습니다.

예제는 같은 분수를 한 슬라이드에 여섯 번 배치합니다. 취소 표시를 위해 네 면을 모두 숨기고, 상승 대각선(↗)은 [setStrikethroughBottomLeftToTopRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setStrikethroughBottomLeftToTopRight)를, 하강 대각선(↘)은 [setStrikethroughTopLeftToBottomRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setStrikethroughTopLeftToBottomRight)를 `true`로 설정합니다. 또한 [setStrikethroughHorizontal](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setStrikethroughHorizontal)이나 [setStrikethroughVertical](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setStrikethroughVertical)를 사용해 보이거나 숨긴 면과 조합할 수 있습니다.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    presentation.getSlideSize().setSize(540, 220, slides.SlideSizeScaleType.DoNotScale);
    const slide = presentation.getSlides().get_Item(0);

    function addFraction(x, y, hideBorder) {
        const fraction = new slides.MathematicalText("x+1").divide("y+2");
        const box = fraction.toBorderBox();
        box.setHideTop(hideBorder);
        box.setHideBottom(hideBorder);
        box.setHideLeft(hideBorder);
        box.setHideRight(hideBorder);

        const shape = slide.getShapes().addMathShape(x, y, 160, 90);
        const portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
        portion.getPortionFormat().setFontHeight(28);
        const block = new slides.MathBlock(box);
        portion.getMathParagraph().add(block);
        return box;
    }

    addFraction(10, 10, false);

    const partial = addFraction(190, 10, false);
    partial.setHideTop(true);
    partial.setHideRight(true);

    addFraction(370, 10, true).setStrikethroughBottomLeftToTopRight(true);
    addFraction(10, 120, true).setStrikethroughTopLeftToBottomRight(true);
    addFraction(190, 120, true).setStrikethroughHorizontal(true);
    addFraction(370, 120, false).setStrikethroughVertical(true);

    presentation.save("border-box.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![위쪽 행: 전체 테두리, 아래/왼쪽 면, 상승 대각선; 아래쪽 행: 하강 대각선, 수평 스트라이크, 수직 스트라이크와 전체 테두리인 6개의 편집 가능한 분수 이미지](border-box-fractions.png)

이 분수에서 수평 스트라이크는 분수선과 겹칩니다. 수직 스트라이크는 분자와 분모 모두를 가로지르며 주변 테두리는 계속 표시됩니다. 이러한 선은 전체 표현식을 장식합니다. 일반 텍스트의 취소선은 텍스트 실행에만 적용됩니다. 프레젠테이션을 PowerPoint에서 다시 열면 분자와 분모를 독립적으로 편집할 수 있습니다.

## **Phantom 요소로 가시성 및 레이아웃 제어**

[MathPhantom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathphantom/)으로 표현식을 감싸면 가시성과 방정식에 기여하는 공간을 독립적으로 제어할 수 있습니다. [MathPhantom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathphantom/) 메서드는 다음을 제어합니다:

| Method | Effect |
| --- | --- |
| [setShow](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathphantom/#setShow) | `false`를 전달하면 표현식을 숨깁니다. 차원은 레이아웃에 계속 기여하지만, 아래 메서드에서 `true`로 설정하면 차원이 무시됩니다. |
| [setZeroWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathphantom/#setZeroWidth) | 표현식의 가로 너비를 0으로 취급해 인접 요소가 더 가깝게 이동하도록 합니다. |
| [setZeroAsc](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathphantom/#setZeroAsc) | 기준선 위의 높이(상승)를 0으로 취급해 위쪽 여백을 줄일 수 있습니다. |
| [setZeroDesc](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathphantom/#setZeroDesc) | 기준선 아래의 깊이(하강)를 0으로 취급해 분수선 등 아래쪽 요소와의 간격을 줄입니다. |

기준선은 일반 수학 문자들이 위치하는 기준선입니다. 내용을 숨겨도 차원은 남으며, 차원을 0으로 처리해도 표현식 자체가 삭제되지는 않습니다. [getBase](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathphantom/#getBase)를 통해 기본 표현식에 접근할 수 있습니다. [setShow](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathphantom/#setShow)를 `true`로 설정하면 다시 표시되며 차원 설정은 그대로 유지됩니다.

예제는 다섯 개의 나란히 배치된 변형을 생성합니다: 보이는 분수, 공간을 유지하는 숨김 분수, 그리고 각각 하나의 차원을 0으로 처리한 세 가지 숨김 분수. 모든 변형은 동일한 주변 표현식과 Cambria Math 24포인트를 사용합니다. 모든 방정식 도형은 같은 상단 위치에 놓이며 회색 가이드가 표시됩니다. 외부 분수의 분자에 phantom을 배치하면 수직 레이아웃 변화를 쉽게 확인할 수 있습니다.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

function createText(value) {
    const text = new slides.MathematicalText(value);
    text.getFormat().setFontHeight(24);
    text.getFormat().setLatinFont(new slides.FontData("Cambria Math"));
    return text;
}

const presentation = new slides.Presentation();
try {
    presentation.getSlideSize().setSize(1000, 180, slides.SlideSizeScaleType.DoNotScale);
    const slide = presentation.getSlides().get_Item(0);

    const labels = [ "Visible", "Hidden: reserves space", "Hidden: ZeroWidth", "Hidden: ZeroAsc", "Hidden: ZeroDesc" ];

    const guide = slide.getShapes().addAutoShape(slides.ShapeType.Line, 10, 60, 980, 0);
    guide.getLineFormat().getFillFormat().setFillType(java.newByte(slides.FillType.Solid));
    guide.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));

    for (let i = 0; i < labels.length; i++) {
        const left = 10 + i * 200;

        const label = slide.getShapes().addAutoShape(slides.ShapeType.Rectangle, left, 10, 190, 30);
        label.getFillFormat().setFillType(java.newByte(slides.FillType.NoFill));
        label.getLineFormat().getFillFormat().setFillType(java.newByte(slides.FillType.NoFill));
        label.getTextFrame().setText(labels[i]);

        const labelFormat = label.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
        labelFormat.setFontHeight(14);
        labelFormat.getFillFormat().setFillType(java.newByte(slides.FillType.Solid));
        labelFormat.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));

        const fractionNumerator = createText("a+b");
        const fractionDenominator = createText("c+d");
        const fraction = new slides.MathFraction(fractionNumerator, fractionDenominator);
        const phantom = new slides.MathPhantom(fraction);
        phantom.setShow(i === 0);
        phantom.setZeroWidth(i === 2);
        phantom.setZeroAsc(i === 3);
        phantom.setZeroDesc(i === 4);

        const leftText = createText("x+");
        const rightText = createText("+y");
        const numerator = new slides.MathBlock(leftText).join(phantom).join(rightText);
        const denominator = createText("z");
        const equation = new slides.MathFraction(numerator, denominator);

        const shape = slide.getShapes().addMathShape(left, 60, 190, 100);
        shape.getTextFrame().getTextFrameFormat().setAnchoringType(java.newByte(slides.TextAnchorType.Top));

        const mathPortion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
        const mathParagraph = mathPortion.getMathParagraph();
        mathParagraph.add(new slides.MathBlock(equation));
    }

    presentation.save("math-phantom.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![보이는 분수, 공간을 유지하는 숨김 분수, ZeroWidth, ZeroAsc, ZeroDesc가 적용된 숨김 분수 비교 이미지](math-phantom.png)

## **용어 그룹화**

[group](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#group)을 사용해 표현식 위나 아래에 그룹화 기호를 배치합니다. 그룹화된 항목에 레이블을 추가하려면 제한을 설정하십시오.

![아래에 "any text" 레이블이 있는 x + y 표현식 이미지](powerpoint-math-equations_15.png)

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

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

## **수식 요소 서식 지정**

수식을 명확히 할 때만 서식 도우미를 사용하십시오. 예를 들어, [overbar](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#overbar)는 수식 요소 위에 막대를 추가합니다.

![overbar가 적용된 ABC 수식 이미지](powerpoint-math-equations_14.png)

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

### **기존 방정식에서 텍스트 서식 지정**

기존 방정식 전체에 텍스트 서식을 적용하려면 각 수식 블록의 요소 트리를 순회합니다. [MathElementBase.getChildren](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#getChildren)는 즉시 자식만 반환하므로, 분수, 스크립트, 근호 및 기타 중첩 구조 내부의 텍스트에 도달하려면 재귀적으로 호출해야 합니다. 시작 요소가 [MathematicalText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathematicaltext/)인 경우를 포함하려면 현재 요소와 그 자식도 확인하십시오.

이 예제는 `input.pptx`에 `z = xᵢ / ∛y`와 같은 방정식이 포함되어 있다고 가정합니다. 여기서 분수는 분자에 첨자를, 분모에 근호를 포함합니다. 블록의 최상위 요소만 처리하면 분수 내부 텍스트를 놓치게 됩니다. 예제는 슬라이드 텍스트 프레임에서 수학 portion을 찾고, [MathPortion.getMathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/#getMathParagraph)으로 블록에 접근한 뒤, 각 텍스트 요소의 [getFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathematicaltext/#getFormat) 메서드와 [setFontHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setFontHeight)를 사용해 글꼴 크기를 28포인트로 설정합니다.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

function formatMathText(element) {
    if (java.instanceOf(element, "com.aspose.slides.MathematicalText")) {
        element.getFormat().setFontHeight(28);
    }

    let children = element.getChildren();
    for (let i = 0; i < children.length; i++) {
        formatMathText(children[i]);
    }
}

let presentation = new aspose.slides.Presentation("input.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        let slide = presentation.getSlides().get_Item(i);
        for (let j = 0; j < slide.getShapes().size(); j++) {
            let shape = slide.getShapes().get_Item(j);
            if (!java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                continue;
            }

            let textFrame = shape.getTextFrame();
            if (textFrame == null) {
                continue;
            }

            for (let k = 0; k < textFrame.getParagraphs().getCount(); k++) {
                let paragraph = textFrame.getParagraphs().get_Item(k);
                for (let l = 0; l < paragraph.getPortions().getCount(); l++) {
                    let portion = paragraph.getPortions().get_Item(l);
                    if (java.instanceOf(portion, "com.aspose.slides.IMathPortion")) {
                        let mathParagraph = portion.getMathParagraph();
                        for (let m = 0; m < mathParagraph.getCount(); m++) {
                            formatMathText(mathParagraph.get_Item(m));
                        }
                    }
                }
            }
        }
    }

    presentation.save("formatted-equations.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

저장된 프레젠테이션은 처리된 각 방정식의 모든 수준에서 텍스트 서식이 업데이트된 상태를 유지하면서 텍스트 내용과 수학 구조를 보존합니다.

## **빠른 참조**

| Task | Main API |
| --- | --- |
| 수식 텍스트 만들기 | [MathematicalText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathematicaltext/) |
| 요소 결합 | [join](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| 분수 만들기 | [divide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| 위첨자 또는 아래첨자 추가 | [setSuperscript](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/), [setSubscript](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| 함수 추가 | [function](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/), [asArgumentOfFunction](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| 근호 추가 | [radical](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| 극한 추가 | [setLowerLimit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/), [setUpperLimit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| 왼쪽 스크립트 추가 | [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| 합계 및 적분 추가 | [nary](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/), [integral](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| 행렬 추가 | [MathMatrix](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathmatrix/) |
| 방정식 배열 추가 | [toMathArray](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| 구분 기호 추가 | [enclose](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| 막대 및 테두리 추가 | [overbar](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/), [toBorderBox](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| 용어 그룹화 | [group](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |

## **FAQ**

**기존 PowerPoint 방정식을 편집할 수 있나요?**

예. 프레젠테이션을 열고 [MathPortion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/)을 포함하는 도형을 찾은 뒤 [getMathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/#getMathParagraph)를 호출하고 해당 단락의 수식 블록을 업데이트하면 됩니다.

**방정식이 편집 가능한 PowerPoint 수식으로 저장되나요?**

예. PPTX로 저장하면 Aspose.Slides가 방정식을 편집 가능한 Office 수식 콘텐츠로 기록합니다.

**방정식을 LaTeX로 내보낼 수 있나요?**

예. 방정식의 [MathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathparagraph/)를 해당 [MathPortion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/)에서 가져와 [MathParagraph.toLatex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathparagraph/#toLatex)를 호출하면 직접 내보낼 수 있습니다. 전체 예제는 [Export Math Equations from Presentations in Node.js via Java](/slides/ko/nodejs-java/exporting-math-equations/#export-math-equations-to-latex)를 확인하십시오.
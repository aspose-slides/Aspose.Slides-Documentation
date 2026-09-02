---
title: Python에서 PowerPoint 프레젠테이션에 수학 방정식 추가
linktitle: PowerPoint 수학 방정식
type: docs
weight: 80
url: /ko/python-net/powerpoint-math-equations/
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
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET를 사용하여 PowerPoint PPT 및 PPTX에 수학 방정식을 삽입하고 편집합니다. OMML 지원, 서식 제어 및 명확한 Python 코드 샘플을 제공합니다."
---
## **개요**

PowerPoint는 방정식을 Office Math Markup Language(OMML)로 저장합니다. Aspose.Slides for Python via .NET를 사용하면 프로그래밍 방식으로 동일한 유형의 수학 콘텐츠를 만들 수 있습니다: 분수, 근호, 함수, 극한, N-ary 연산자, 행렬, 배열, 그리고 형식이 지정된 수학 블록.

PowerPoint에서 사용자는 일반적으로 **삽입 > 방정식**을 통해 수식을 추가합니다:

![PowerPoint Insert 탭에 방정식 명령이 선택된 상태](powerpoint-math-equations_1.png)

결과는 슬라이드에 수정 가능한 수학 텍스트가 됩니다:

![수정 가능한 수식이 포함된 PowerPoint 슬라이드](powerpoint-math-equations_2.png)

Aspose.Slides는 세 가지 주요 객체를 통해 해당 수학 텍스트를 구성합니다:

- 수식을 포함하는 도형인 수학 도형은 [add_math_shape](https://reference.aspose.com/slides/ko/python-net/aspose.slides/shapecollection/add_math_shape/)를 사용해 생성됩니다.
- [MathPortion](https://reference.aspose.com/slides/ko/python-net/aspose.slides.mathtext/mathportion/)은 도형 텍스트 프레임 내부에 수학 콘텐츠를 저장합니다.
- [MathParagraph](https://reference.aspose.com/slides/ko/python-net/aspose.slides.mathtext/mathparagraph/)은 하나 이상의 [MathBlock](https://reference.aspose.com/slides/ko/python-net/aspose.slides.mathtext/mathblock/) 객체를 포함합니다.

아래 대부분의 예제는 [MathematicalText](https://reference.aspose.com/slides/ko/python-net/aspose.slides.mathtext/mathematicaltext/)와 [IMathElement](https://reference.aspose.com/slides/ko/python-net/aspose.slides.mathtext/imathelement/)의 유창한 메서드를 사용하여 코드를 간결하고 읽기 쉽게 유지합니다.

MathML 내보내기 시나리오에 대해서는 [Export Math Equations from Presentations in Python via .NET](/slides/ko/python-net/exporting-math-equations/)를 참조하십시오.

## **수식 만들기**

이 예제는 수학 도형을 생성하고 피타고라스 정리를 추가합니다:

![c 제곱이 a 제곱 더하기 b 제곱과 같은 방정식](powerpoint-math-equations_3.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 120)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    equation = (
        math.MathematicalText("c")
        .set_superscript("2")
        .join("=")
        .join(math.MathematicalText("a").set_superscript("2"))
        .join("+")
        .join(math.MathematicalText("b").set_superscript("2"))
    )

    math_paragraph.add(equation)

    presentation.save("pythagorean-theorem.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="primary" %}}
`add_math_shape`은 이미 수학 단락을 포함하는 도형을 생성합니다. 첫 번째 `MathPortion`에 접근하고, 해당 `MathParagraph`를 가져와 수학 블록이나 수학 요소를 추가합니다.
{{% /alert %}}

## **분수 추가**

[`divide`](https://reference.aspose.com/slides/ko/python-net/aspose.slides.mathtext/imathelement/divide/)를 사용해 분수를 만들 수 있습니다. [MathFractionTypes](https://reference.aspose.com/slides/ko/python-net/aspose.slides.mathtext/mathfractiontypes/)로 분수 스타일을 선택하십시오.

![1을 x로 나눈 비스듬한 수학 분수](powerpoint-math-equations_4.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 100)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    fraction = math.MathematicalText("1").divide("x", math.MathFractionTypes.SKEWED)

    math_paragraph.add(math.MathBlock(fraction))

    presentation.save("fraction.pptx", slides.export.SaveFormat.PPTX)
```

중첩된 분수의 경우 `MathFractionTypes.BAR`를 사용하십시오:

```py
stacked_fraction = math.MathematicalText("x + 1").divide("y - 1", math.MathFractionTypes.BAR)
```

## **근호 추가**

[`radical`](https://reference.aspose.com/slides/ko/python-net/aspose.slides.mathtext/imathelement/radical/)을 사용해 제곱근, 세제곱근 또는 기타 근호를 만들 수 있습니다. 현재 요소가 밑이 되고, 인수가 차수가 됩니다.

![근호 기호 아래에 x가 있는 n번째 근호 표현식](powerpoint-math-equations_5.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 100)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    radical = math.MathematicalText("x").radical("n")

    math_paragraph.add(math.MathBlock(radical))

    presentation.save("radical.pptx", slides.export.SaveFormat.PPTX)
```

## **함수 및 극한 추가**

[`as_argument_of_function`](https://reference.aspose.com/slides/ko/python-net/aspose.slides.mathtext/imathelement/as_argument_of_function/) 또는 [`function`](https://reference.aspose.com/slides/ko/python-net/aspose.slides.mathtext/imathelement/function/)를 사용해 `sin(x)`, `log(x)`와 같은 함수 또는 사용자 정의 함수 이름을 만들 수 있습니다. 극한의 경우 [MathLimit](https://reference.aspose.com/slides/ko/python-net/aspose.slides.mathtext/mathlimit/)에 `lim`을 넣거나 [`set_lower_limit`](https://reference.aspose.com/slides/ko/python-net/aspose.slides.mathtext/imathelement/set_lower_limit/)을 사용하십시오.

![x가 무한대로 갈 때의 극한](powerpoint-math-equations_8.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 100)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    limit = (
        math.MathematicalText("lim")
        .set_lower_limit("x\u2192\u221E")
        .function("x")
    )

    math_paragraph.add(math.MathBlock(limit))

    presentation.save("functions-and-limits.pptx", slides.export.SaveFormat.PPTX)
```

사용자 정의 함수 이름의 경우 현재 요소를 함수 이름으로 만드십시오:

```py
custom_function = math.MathematicalText("f").function("x + 1")
```

## **N-ary 연산자 및 적분 추가**

[`nary`](https://reference.aspose.com/slides/ko/python-net/aspose.slides.mathtext/imathelement/nary/)를 사용해 합계, 합집합, 교집합 및 기타 큰 연산자를 만들 수 있습니다. [`integral`](https://reference.aspose.com/slides/ko/python-net/aspose.slides.mathtext/imathelement/integral/)를 사용해 적분을 만들 수 있으며, 두 메서드 모두 아래 및 위 한계를 설정할 수 있습니다.

![아래와 위 한계가 있는 합계](powerpoint-math-equations_7.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 120)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    summation_base = (
        math.MathematicalText("x")
        .set_superscript("k")
        .join(math.MathematicalText("a").set_superscript("n-k"))
    )

    summation = summation_base.nary(math.MathNaryOperatorTypes.SUMMATION, "k=0", "n")

    math_paragraph.add(math.MathBlock(summation))

    presentation.save("nary-operators.pptx", slides.export.SaveFormat.PPTX)
```

N-ary 연산자는 선택적 한계가 있는 큰 연산자에 사용됩니다. `+`, `-`, `=`와 같은 단순 연산자는 일반적으로 `MathematicalText`로 추가하고 식에 결합합니다.

적분의 경우 `integral`을 사용하십시오:

```py
integral_base = math.MathematicalText("x").join(math.MathematicalText("dx").to_box())
integral = integral_base.integral(math.MathIntegralTypes.SIMPLE, "0", "1")
```

## **행렬 추가**

[MathMatrix](https://reference.aspose.com/slides/ko/python-net/aspose.slides.mathtext/mathmatrix/)를 사용해 행과 열을 정의합니다. 행렬은 기본적으로 괄호가 포함되지 않으므로 필요에 따라 괄호, 대괄호 또는 중괄호로 둘러싸십시오.

![한 셀이 비어 있는 두 행의 수학 행렬](powerpoint-math-equations_10.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 120)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    matrix = math.MathMatrix(2, 3)
    matrix[0, 0] = math.MathematicalText("1")
    matrix[0, 1] = math.MathematicalText("x")
    matrix[1, 0] = math.MathematicalText("x")
    matrix[1, 1] = math.MathematicalText("2")
    matrix[1, 2] = math.MathematicalText("y")

    math_paragraph.add(math.MathBlock(matrix))

    presentation.save("matrix.pptx", slides.export.SaveFormat.PPTX)
```

## **방정식 배열 추가**

정렬된 방정식이나 수식의 수직 스택이 필요한 경우 [`to_math_array`](https://reference.aspose.com/slides/ko/python-net/aspose.slides.mathtext/imathelement/to_math_array/)를 사용하십시오.

![x가 y 위에 있는 수직 수학 배열](powerpoint-math-equations_11.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 140)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    equation_array = (
        math.MathematicalText("x")
        .join("y")
        .to_math_array()
    )

    math_paragraph.add(math.MathBlock(equation_array))

    presentation.save("equation-array.pptx", slides.export.SaveFormat.PPTX)
```

## **삼각 함수 추가**

인수가 현재 요소이고 함수 이름이 알려져 있는 경우 [`as_argument_of_function`](https://reference.aspose.com/slides/ko/python-net/aspose.slides.mathtext/imathelement/as_argument_of_function/)를 사용하십시오.

![2x에 적용된 삼각 함수 cos](powerpoint-math-equations_6.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 100)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    cosine = math.MathematicalText("2x").as_argument_of_function(
        math.MathFunctionsOfOneArgument.COS
    )

    math_paragraph.add(math.MathBlock(cosine))

    presentation.save("trigonometric-function.pptx", slides.export.SaveFormat.PPTX)
```

## **첨자 및 위첨자 추가**

인덱스와 거듭제곱을 위해 첨자와 위첨자 도우미를 사용하십시오. 인덱스가 기준의 왼쪽에 나타나야 하는 경우 [`set_sub_superscript_on_the_left`](https://reference.aspose.com/slides/ko/python-net/aspose.slides.mathtext/imathelement/set_sub_superscript_on_the_left/)를 사용하십시오.

![왼쪽에 첨자 1과 위첨자 n이 있는 대문자 Y](powerpoint-math-equations_9.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 100)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    scripts = math.MathematicalText("Y").set_sub_superscript_on_the_left("1", "n")

    math_paragraph.add(math.MathBlock(scripts))

    presentation.save("subscript-superscript.pptx", slides.export.SaveFormat.PPTX)
```

## **구분자 추가**

표현식을 구분자 안에 넣으려면 [`enclose`](https://reference.aspose.com/slides/ko/python-net/aspose.slides.mathtext/imathelement/enclose/)를 사용하십시오. 여러 요소가 포함된 구분자 표현식의 경우 구분 문자도 설정할 수 있습니다.

![세로 막대로 구분된 x, y, z가 포함된 구분자 표현식](powerpoint-math-equations_13.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 100)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    delimiter = (
        math.MathematicalText("x")
        .join("y")
        .join("z")
        .enclose("<", ">")
    )
    delimiter.separator_character = "|"

    math_paragraph.add(math.MathBlock(delimiter))

    presentation.save("delimiters.pptx", slides.export.SaveFormat.PPTX)
```

## **테두리 상자 추가**

수식 자체를 테두리로 둘러야 하는 경우 [`to_border_box`](https://reference.aspose.com/slides/ko/python-net/aspose.slides.mathtext/imathelement/to_border_box/)를 사용하십시오.

![a² = b² + c² 를 보여주는 상자 안의 방정식](powerpoint-math-equations_12.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 100)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    boxed_equation = (
        math.MathematicalText("a")
        .set_superscript("2")
        .join("=")
        .join(math.MathematicalText("b").set_superscript("2"))
        .join("+")
        .join(math.MathematicalText("c").set_superscript("2"))
        .to_border_box()
    )

    math_paragraph.add(math.MathBlock(boxed_equation))

    presentation.save("border-box.pptx", slides.export.SaveFormat.PPTX)
```

## **항 그룹화**

표현식 위 또는 아래에 그룹화 문자를 배치하려면 [`group`](https://reference.aspose.com/slides/ko/python-net/aspose.slides.mathtext/imathelement/group/)를 사용하십시오. 그룹화된 항에 레이블을 달려면 한계를 추가하십시오.

![x + y 가 아래에 텍스트 레이블과 함께 그룹화된 표현식](powerpoint-math-equations_15.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 120)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    grouped = (
        math.MathematicalText("x + y")
        .group(chr(0x23DF), math.MathTopBotPositions.BOTTOM, math.MathTopBotPositions.TOP)
        .set_lower_limit("any text")
    )

    math_paragraph.add(math.MathBlock(grouped))

    presentation.save("grouped-terms.pptx", slides.export.SaveFormat.PPTX)
```

## **수학 요소 형식 지정**

공식을 명확히 하는 경우에만 형식 지정 도우미를 사용하십시오. 예를 들어 [`overbar`](https://reference.aspose.com/slides/ko/python-net/aspose.slides.mathtext/imathelement/overbar/)는 수학 요소 위에 막대를 추가합니다.

![ABC 위에 overbar가 있는 수학 표현식](powerpoint-math-equations_14.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 100)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    overbar = math.MathematicalText("ABC").overbar()

    math_paragraph.add(math.MathBlock(overbar))

    presentation.save("overbar.pptx", slides.export.SaveFormat.PPTX)
```

## **빠른 참고**

| 작업 | 주요 API |
| --- | --- |
| 수학 텍스트 만들기 | [MathematicalText](https://reference.aspose.com/slides/ko/python-net/aspose.slides.mathtext/mathematicaltext/) |
| 요소 결합 | [IMathElement.join](https://reference.aspose.com/slides/ko/python-net/aspose.slides.mathtext/imathelement/join/) |
| 분수 만들기 | [IMathElement.divide](https://reference.aspose.com/slides/ko/python-net/aspose.slides.mathtext/imathelement/divide/) |
| 위첨자 또는 아래첨자 추가 | [set_superscript](https://reference.aspose.com/slides/ko/python-net/aspose.slides.mathtext/imathelement/set_superscript/), [set_subscript](https://reference.aspose.com/slides/ko/python-net/aspose.slides.mathtext/imathelement/set_subscript/) |
| 함수 추가 | [function](https://reference.aspose.com/slides/ko/python-net/aspose.slides.mathtext/imathelement/function/), [as_argument_of_function](https://reference.aspose.com/slides/ko/python-net/aspose.slides.mathtext/imathelement/as_argument_of_function/) |
| 근호 추가 | [radical](https://reference.aspose.com/slides/ko/python-net/aspose.slides.mathtext/imathelement/radical/) |
| 극한 추가 | [set_lower_limit](https://reference.aspose.com/slides/ko/python-net/aspose.slides.mathtext/imathelement/set_lower_limit/), [set_upper_limit](https://reference.aspose.com/slides/ko/python-net/aspose.slides.mathtext/imathelement/set_upper_limit/) |
| 왼쪽 첨자 추가 | [set_sub_superscript_on_the_left](https://reference.aspose.com/slides/ko/python-net/aspose.slides.mathtext/imathelement/set_sub_superscript_on_the_left/) |
| 합계 및 적분 추가 | [nary](https://reference.aspose.com/slides/ko/python-net/aspose.slides.mathtext/imathelement/nary/), [integral](https://reference.aspose.com/slides/ko/python-net/aspose.slides.mathtext/imathelement/integral/) |
| 행렬 추가 | [MathMatrix](https://reference.aspose.com/slides/ko/python-net/aspose.slides.mathtext/mathmatrix/) |
| 방정식 배열 추가 | [to_math_array](https://reference.aspose.com/slides/ko/python-net/aspose.slides.mathtext/imathelement/to_math_array/) |
| 구분자 추가 | [enclose](https://reference.aspose.com/slides/ko/python-net/aspose.slides.mathtext/imathelement/enclose/) |
| 바 및 테두리 추가 | [overbar](https://reference.aspose.com/slides/ko/python-net/aspose.slides.mathtext/imathelement/overbar/), [to_border_box](https://reference.aspose.com/slides/ko/python-net/aspose.slides.mathtext/imathelement/to_border_box/) |
| 항 그룹화 | [group](https://reference.aspose.com/slides/ko/python-net/aspose.slides.mathtext/imathelement/group/) |

## **자주 묻는 질문**

**기존 PowerPoint 방정식을 편집할 수 있나요?**

예. 프레젠테이션을 열고 `MathPortion`을 포함하는 도형을 찾은 다음 해당 `MathParagraph`를 가져와 해당 단락의 수학 블록을 업데이트하면 됩니다.

**방정식이 편집 가능한 PowerPoint 수학으로 저장되나요?**

예. PPTX로 저장하면 Aspose.Slides는 방정식을 편집 가능한 Office 수학 콘텐츠로 기록합니다.

**방정식을 LaTeX로 내보낼 수 있나요?**

예. 방정식의 [MathParagraph](https://reference.aspose.com/slides/ko/python-net/aspose.slides.mathtext/mathparagraph/)를 해당 [MathPortion](https://reference.aspose.com/slides/ko/python-net/aspose.slides.mathtext/mathportion/)에서 가져온 다음 [MathParagraph.to_latex](https://reference.aspose.com/slides/ko/python-net/aspose.slides.mathtext/mathparagraph/to_latex/)를 호출하면 직접 내보낼 수 있습니다. 전체 예제는 [Export Math Equations from Presentations in Python via .NET](/slides/ko/python-net/exporting-math-equations/#export-math-equations-to-latex)를 참조하십시오.
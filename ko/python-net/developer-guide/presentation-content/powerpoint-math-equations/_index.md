---
title: Python을 사용하여 PowerPoint 프레젠테이션에 수학 방정식 추가
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
description: "Aspose.Slides for Python via .NET를 사용하여 PowerPoint PPT 및 PPTX에 수학 방정식을 삽입하고 편집하며, OMML 지원, 서식 제어 및 명확한 Python 코드 샘플을 제공합니다."
---
## **개요**

PowerPoint는 방정식을 Office Math Markup Language(OMML)로 저장합니다. Aspose.Slides for Python via .NET를 사용하면 프로그래밍 방식으로 동일한 유형의 수학 콘텐츠를 만들 수 있습니다: 분수, 근호, 함수, 극한, N-ary 연산자, 행렬, 배열 및 형식이 지정된 수학 블록.

PowerPoint에서 사용자는 일반적으로 **삽입 > 수식**에서 수식을 추가합니다:

![PowerPoint 삽입 탭에서 수식 명령이 선택된 상태](powerpoint-math-equations_1.png)

그 결과는 슬라이드에 편집 가능한 수학 텍스트가 됩니다:

![편집 가능한 수학 방정식이 포함된 PowerPoint 슬라이드](powerpoint-math-equations_2.png)

Aspose.Slides는 세 가지 주요 객체를 통해 해당 수학 텍스트를 구축합니다:

- 수학 도형은 [add_math_shape](https://reference.aspose.com/slides/ko/python-net/aspose.slides/shapecollection/add_math_shape/)으로 생성되며, 방정식을 포함하는 도형입니다.
- [MathPortion](https://reference.aspose.com/slides/ko/python-net/aspose.slides.mathtext/mathportion/)은 도형 텍스트 프레임 내부에 수학 콘텐츠를 저장합니다.
- [MathParagraph](https://reference.aspose.com/slides/ko/python-net/aspose.slides.mathtext/mathparagraph/)은 하나 이상의 [MathBlock](https://reference.aspose.com/slides/ko/python-net/aspose.slides.mathtext/mathblock/) 객체를 포함합니다.

아래 대부분의 예제는 코드를 간결하고 읽기 쉽게 유지하기 위해 [MathematicalText](https://reference.aspose.com/slides/ko/python-net/aspose.slides.mathtext/mathematicaltext/)와 [IMathElement](https://reference.aspose.com/slides/ko/python-net/aspose.slides.mathtext/imathelement/)의 유창한 메서드를 사용합니다.

MathML 내보내기 시나리오에 대해서는 [Python via .NET를 사용한 프레젠테이션에서 수학 방정식 내보내기](/slides/ko/python-net/exporting-math-equations/)를 참조하세요.

## **방정식 만들기**

이 예제는 수학 도형을 생성하고 피타고라스 정리를 추가합니다:

![c² = a² + b² 방정식](powerpoint-math-equations_3.png)

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
`add_math_shape`는 이미 수학 단락을 포함하는 도형을 생성합니다. 첫 번째 `MathPortion`에 접근하고, 해당 `MathParagraph`를 가져와 수학 블록이나 수학 요소를 추가합니다.
{{% /alert %}}

## **분수 추가**

[`divide`](https://reference.aspose.com/slides/ko/python-net/aspose.slides.mathtext/imathelement/divide/)를 사용하여 분수를 생성합니다. [MathFractionTypes](https://reference.aspose.com/slides/ko/python-net/aspose.slides.mathtext/mathfractiontypes/)를 사용하여 분수 스타일을 선택할 수 있습니다.

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

쌓인 분수를 위해서는 `MathFractionTypes.BAR`를 사용합니다:

```py
stacked_fraction = math.MathematicalText("x + 1").divide("y - 1", math.MathFractionTypes.BAR)
```

## **근호 추가**

[`radical`](https://reference.aspose.com/slides/ko/python-net/aspose.slides.mathtext/imathelement/radical/)를 사용하여 제곱근, 세제곱근 또는 기타 근을 생성합니다. 현재 요소가 밑이 되고, 인수가 차수가 됩니다.

![x가 근호 기호 아래에 있는 n번째 근 표현식](powerpoint-math-equations_5.png)

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

[`as_argument_of_function`](https://reference.aspose.com/slides/ko/python-net/aspose.slides.mathtext/imathelement/as_argument_of_function/) 또는 [`function`](https://reference.aspose.com/slides/ko/python-net/aspose.slides.mathtext/imathelement/function/)를 사용하여 `sin(x)`, `log(x)`와 같은 함수 또는 사용자 정의 함수명을 지정합니다. 극한의 경우, `lim`을 [MathLimit](https://reference.aspose.com/slides/ko/python-net/aspose.slides.mathtext/mathlimit/)에 넣거나 [`set_lower_limit`](https://reference.aspose.com/slides/ko/python-net/aspose.slides.mathtext/imathelement/set_lower_limit/)를 사용합니다.

![x가 무한대로 접근할 때의 극한](powerpoint-math-equations_8.png)

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

사용자 정의 함수 이름의 경우, 함수 이름을 현재 요소로 만듭니다:

```py
custom_function = math.MathematicalText("f").function("x + 1")
```

## **N-ary 연산자 및 적분 추가**

[`nary`](https://reference.aspose.com/slides/ko/python-net/aspose.slides.mathtext/imathelement/nary/)를 사용하여 합계, 합집합, 교집합 및 기타 대형 연산자를 구현합니다. `[`integral`](https://reference.aspose.com/slides/ko/python-net/aspose.slides.mathtext/imathelement/integral/)`를 사용하여 적분을 구현합니다. 두 메서드 모두 하한 및 상한을 설정할 수 있습니다.

![하한과 상한이 있는 합계](powerpoint-math-equations_7.png)

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

N-ary 연산자는 선택적 한계가 있는 대형 연산자를 위해 사용됩니다. `+`, `-`, `=`와 같은 간단한 연산자는 일반적으로 `MathematicalText`로 추가되고 식에 연결됩니다.

적분을 위해서는 `integral`을 사용합니다:

```py
integral_base = math.MathematicalText("x").join(math.MathematicalText("dx").to_box())
integral = integral_base.integral(math.MathIntegralTypes.SIMPLE, "0", "1")
```

## **행렬 추가**

행과 열을 위해 [MathMatrix](https://reference.aspose.com/slides/ko/python-net/aspose.slides.mathtext/mathmatrix/)를 사용합니다. 행렬은 기본적으로 괄호를 포함하지 않으므로, 괄호, 대괄호 또는 중괄호가 필요할 경우 행렬을 감싸세요.

![한 개의 빈 셀을 포함한 두 행 수학 행렬](powerpoint-math-equations_10.png)

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

정렬된 방정식이나 수식의 수직 스택이 필요할 때는 [`to_math_array`](https://reference.aspose.com/slides/ko/python-net/aspose.slides.mathtext/imathelement/to_math_array/)를 사용합니다.

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

인수가 현재 요소이고 함수 이름이 알려진 경우, `[`as_argument_of_function`](https://reference.aspose.com/slides/ko/python-net/aspose.slides.mathtext/imathelement/as_argument_of_function/)`를 사용합니다.

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

인덱스와 지수를 위해 첨자 및 위첨자 도우미를 사용합니다. 인덱스가 기본 요소의 왼쪽에 나타나야 할 경우 `[`set_sub_superscript_on_the_left`](https://reference.aspose.com/slides/ko/python-net/aspose.slides.mathtext/imathelement/set_sub_superscript_on_the_left/)`를 사용합니다.

![왼쪽 첨자 1 및 위첨자 n을 가진 대문자 Y](powerpoint-math-equations_9.png)

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

[`enclose`](https://reference.aspose.com/slides/ko/python-net/aspose.slides.mathtext/imathelement/enclose/)를 사용하여 식을 구분자 안에 넣습니다. 여러 요소를 포함하는 구분자 식의 경우 구분 문자도 설정할 수 있습니다.

![x, y, z가 수직 막대로 구분된 구분자 식](powerpoint-math-equations_13.png)

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

식 자체를 테두리로 둘러야 할 경우 `[`to_border_box`](https://reference.aspose.com/slides/ko/python-net/aspose.slides.mathtext/imathelement/to_border_box/)`를 사용합니다.

![a² = b² + c²를 보여주는 상자 안의 방정식](powerpoint-math-equations_12.png)

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

[`group`](https://reference.aspose.com/slides/ko/python-net/aspose.slides.mathtext/imathelement/group/)를 사용하여 식 위나 아래에 그룹화 문자를 배치합니다. 그룹화된 항에 레이블을 지정하려면 한계를 추가합니다.

![x와 y를 더한 식이 아래에 'any text' 레이블과 함께 그룹화된 모습](powerpoint-math-equations_15.png)

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

## **수학 요소 서식 지정**

공식을 명확히 할 경우에만 서식 도우미를 사용합니다. 예를 들어, `[`overbar`](https://reference.aspose.com/slides/ko/python-net/aspose.slides.mathtext/imathelement/overbar/)`는 수학 요소 위에 바를 놓습니다.

![위에 바가 있는 수학식 ABC](powerpoint-math-equations_14.png)

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

## **빠른 참조**

| 작업 | 주요 API |
| --- | --- |
| 수학 텍스트 만들기 | [MathematicalText](https://reference.aspose.com/slides/ko/python-net/aspose.slides.mathtext/mathematicaltext/) |
| 요소 결합 | [IMathElement.join](https://reference.aspose.com/slides/ko/python-net/aspose.slides.mathtext/imathelement/join/) |
| 분수 만들기 | [IMathElement.divide](https://reference.aspose.com/slides/ko/python-net/aspose.slides.mathtext/imathelement/divide/) |
| 위첨자 또는 아래첨자 추가 | [set_superscript](https://reference.aspose.com/slides/ko/python-net/aspose.slides.mathtext/imathelement/set_superscript/), [set_subscript](https://reference.aspose.com/slides/ko/python-net/aspose.slides.mathtext/imathelement/set_subscript/) |
| 함수 추가 | [function](https://reference.aspose.com/slides/ko/python-net/aspose.slides.mathtext/imathelement/function/), [as_argument_of_function](https://reference.aspose.com/slides/ko/python-net/aspose.slides.mathtext/imathelement/as_argument_of_function/) |
| 근호 추가 | [radical](https://reference.aspose.com/slides/ko/python-net/aspose.slides.mathtext/imathelement/radical/) |
| 극한 추가 | [set_lower_limit](https://reference.aspose.com/slides/ko/python-net/aspose.slides.mathtext/imathelement/set_lower_limit/), [set_upper_limit](https://reference.aspose.com/slides/ko/python-net/aspose.slides.mathtext/imathelement/set_upper_limit/) |
| 왼쪽 스크립트 추가 | [set_sub_superscript_on_the_left](https://reference.aspose.com/slides/ko/python-net/aspose.slides.mathtext/imathelement/set_sub_superscript_on_the_left/) |
| 합계 및 적분 추가 | [nary](https://reference.aspose.com/slides/ko/python-net/aspose.slides.mathtext/imathelement/nary/), [integral](https://reference.aspose.com/slides/ko/python-net/aspose.slides.mathtext/imathelement/integral/) |
| 행렬 추가 | [MathMatrix](https://reference.aspose.com/slides/ko/python-net/aspose.slides.mathtext/mathmatrix/) |
| 방정식 배열 추가 | [to_math_array](https://reference.aspose.com/slides/ko/python-net/aspose.slides.mathtext/imathelement/to_math_array/) |
| 구분자 추가 | [enclose](https://reference.aspose.com/slides/ko/python-net/aspose.slides.mathtext/imathelement/enclose/) |
| 바와 테두리 추가 | [overbar](https://reference.aspose.com/slides/ko/python-net/aspose.slides.mathtext/imathelement/overbar/), [to_border_box](https://reference.aspose.com/slides/ko/python-net/aspose.slides.mathtext/imathelement/to_border_box/) |
| 항 그룹화 | [group](https://reference.aspose.com/slides/ko/python-net/aspose.slides.mathtext/imathelement/group/) |

## **FAQ**

**기존 PowerPoint 방정식을 편집할 수 있나요?**

예. 프레젠테이션을 열고 `MathPortion`을 포함하는 도형을 찾은 다음, 해당 `MathParagraph`를 가져와 그 단락의 수학 블록을 업데이트합니다.

**방정식이 편집 가능한 PowerPoint 수학으로 저장되나요?**

예. PPTX로 저장하면 Aspose.Slides가 방정식을 편집 가능한 Office 수학 콘텐츠로 기록합니다.

**방정식을 LaTeX로 내보낼 수 있나요?**

Aspose.Slides는 수학 방정식을 MathML로 내보냅니다. LaTeX가 필요한 경우 먼저 MathML로 내보낸 다음, 대상 LaTeX 방언을 지원하는 도구로 MathML을 변환하세요.
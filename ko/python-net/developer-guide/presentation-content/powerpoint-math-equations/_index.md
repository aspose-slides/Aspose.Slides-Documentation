---
title: Python에서 PowerPoint 프레젠테이션에 수식 추가
linktitle: PowerPoint 수식
type: docs
weight: 80
url: /ko/python-net/powerpoint-math-equations/
keywords:
- 수식
- 수학 기호
- 수학 공식
- 수학 텍스트
- 수식 추가
- 수학 기호 추가
- 수학 공식 추가
- 수학 텍스트 추가
- PowerPoint
- 프레젠테이션
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET를 사용하여 PowerPoint PPT 및 PPTX에 수식을 삽입하고 편집할 수 있으며, OMML 지원, 서식 제어 및 명확한 Python 코드 예제를 제공합니다."
---
## **개요**

PowerPoint은 수식을 Office Math Markup Language(OMML)로 저장합니다. Aspose.Slides for Python via .NET를 사용하면 프로그래밍 방식으로 동일한 종류의 수학 콘텐츠를 만들 수 있습니다: 분수, 근호, 함수, 제한, N-ary 연산자, 행렬, 배열 및 서식이 적용된 수학 블록.

PowerPoint에서 사용자는 일반적으로 **삽입 > 수식**을 통해 수식을 추가합니다:

![PowerPoint 삽입 탭에서 수식 명령이 선택된 모습](powerpoint-math-equations_1.png)

결과는 슬라이드에 편집 가능한 수학 텍스트가 표시됩니다:

![편집 가능한 수학 방정식을 포함한 PowerPoint 슬라이드](powerpoint-math-equations_2.png)

Aspose.Slides는 세 가지 주요 객체를 통해 해당 수학 텍스트를 구성합니다:

- 수식을 포함하는 도형인 **수학 도형**은 [add_math_shape](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_math_shape/)으로 생성합니다.
- [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/)은 도형 텍스트 프레임 내에 수학 콘텐츠를 저장합니다.
- [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/)은 하나 이상의 [MathBlock](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/) 객체를 포함합니다.

아래 대부분의 예제는 [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/)와 [IMathElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)의 유창한 메서드를 사용하여 코드를 간결하고 읽기 쉽게 유지합니다.

MathML 내보내기 시나리오에 대해서는 [Python을 통한 .NET에서 프레젠테이션의 수식 내보내기](/slides/ko/python-net/exporting-math-equations/)를 참조하십시오.

## **수식 만들기**

이 예제는 [add_math_shape](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_math_shape/)을 사용하여 수학 도형을 만들고 피타고라스 정리를 추가합니다:

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

{{% alert color="info" title="참고" %}}
[add_math_shape](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_math_shape/)은 이미 수학 단락을 포함하고 있는 도형을 생성합니다. 첫 번째 [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/)에 접근하고, 해당 [math_paragraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/math_paragraph/)을 가져온 다음, 수학 블록 또는 수학 요소를 추가합니다.
{{% /alert %}}

## **분수 추가**

[divide](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/divide/)을 사용하여 분수를 만들 수 있습니다. [MathFractionTypes](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfractiontypes/)로 분수 스타일을 선택할 수 있습니다.

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

누적 분수를 만들려면 [MathFractionTypes.BAR](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfractiontypes/)를 사용합니다:

```py
import aspose.slides.mathtext as math

stacked_fraction = math.MathematicalText("x + 1").divide("y - 1", math.MathFractionTypes.BAR)
```

## **근호 추가**

[radical](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/radical/)을 사용하여 제곱근, 세제곱근 또는 기타 루트를 만들 수 있습니다. 현재 요소가 밑이 되고, 인수가 차수가 됩니다.

![x가 근호 기호 아래에 있는 n제곱근 표현](powerpoint-math-equations_5.png)

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

## **함수 및 제한 추가**

[as_argument_of_function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/as_argument_of_function/) 또는 [function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/function/)을 사용하여 `sin(x)`, `log(x)`와 같은 함수 또는 사용자 정의 함수명을 만들 수 있습니다. 제한을 지정하려면 `lim`을 [MathLimit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathlimit/)에 넣거나 [set_lower_limit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_lower_limit/)를 사용합니다.

![x가 무한대로 접근할 때의 lim](powerpoint-math-equations_8.png)

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

사용자 정의 함수명을 위해서는 현재 요소를 함수명으로 만든 뒤, 해당 인수와 함께 [function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/function/)을 호출합니다:

```py
import aspose.slides.mathtext as math

custom_function = math.MathematicalText("f").function("x + 1")
```

## **N-ary 연산자 및 적분 추가**

[nary](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/nary/)를 사용하여 합계, 합집합, 교집합 및 기타 대형 연산자를 만들 수 있습니다. 적분은 [integral](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/integral/)을 사용합니다. 두 메서드 모두 하한 및 상한을 설정할 수 있습니다.

![하한 및 상한이 있는 합계](powerpoint-math-equations_7.png)

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

N-ary 연산자는 선택적 제한이 가능한 대형 연산자에 사용됩니다. `+`, `-`, `=`와 같은 단순 연산자는 일반적으로 [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/)를 사용해 표현에 결합합니다.

적분을 위해서는 [integral](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/integral/)을 사용합니다:

```py
import aspose.slides.mathtext as math

integral_base = math.MathematicalText("x").join(math.MathematicalText("dx").to_box())
integral = integral_base.integral(math.MathIntegralTypes.SIMPLE, "0", "1")
```

## **행렬 추가**

[MathMatrix](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathmatrix/)를 사용하여 행과 열을 정의합니다. 행렬은 기본적으로 괄호를 포함하지 않으므로, 괄호, 대괄호 또는 중괄호가 필요할 경우 행렬을 둘러싸야 합니다.

![한 개의 빈 셀을 가진 두 행 수학 행렬](powerpoint-math-equations_10.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 120)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    matrix = math.MathMatrix(2, 3)

    # 행렬은 자체 괄호가 없으므로 괄호로 둘러싸세요.
    math_paragraph.add(math.MathBlock(matrix.enclose("(", ")")))

    presentation.save("matrix.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="warning" title="경고" %}}
`MathMatrix`는 행과 열 그리드를 만들고, 그 사이 간격을 설정하며, 열을 정렬합니다. 그러나 Aspose.Slides for Python via .NET에서는 개별 행렬 셀에 대한 접근자를 제공하지 않습니다. 코드에서 만든 행렬은 빈 셀을 유지합니다; 기존 프레젠테이션에서 가져온 행렬의 셀은 `get_children`으로 읽을 수 있습니다. 코드를 통해 행을 채워야 할 경우 수식 배열을 사용하십시오.
{{% /alert %}}

## **수식 배열 추가**

정렬된 수식이나 수식의 수직 스택이 필요할 때는 [to_math_array](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/to_math_array/)를 사용합니다.

![x가 y 위에 있는 수직 수식 배열](powerpoint-math-equations_11.png)

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

### **배열을 주변 요소와 정렬**

[IMathArray.base_justification](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imatharray/base_justification/)은 배열을 옆의 수학 요소와 비교하여 수직 정렬을 제어합니다. 아래 예제는 첫 번째 행, 배열 중앙, 마지막 행과의 정렬을 비교합니다.

다음 예제는 세 개의 동일한 배열을 생성하며, 각 배열은 세 행과 인접 요소 `A=` 및 `=B`를 가집니다. 모든 수학 텍스트는 Cambria Math 24포인트를 사용합니다. 배열 정렬만 달라집니다.

```py
import aspose.slides as slides
import aspose.slides.mathtext as math


def create_text(value):
    text = math.MathematicalText(value)
    text.format.font_height = 24
    text.format.latin_font = slides.FontData("Cambria Math")
    return text


with slides.Presentation() as presentation:
    presentation.slide_size.set_size(780, 200, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]
    alignments = [math.MathVerticalAlignment.TOP, math.MathVerticalAlignment.CENTER, math.MathVerticalAlignment.BOTTOM]
    labels = ["Top", "Center", "Bottom"]

    for i, alignment in enumerate(alignments):
        label = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20 + i * 260, 10, 240, 30)
        label.fill_format.fill_type = slides.FillType.NO_FILL
        label.line_format.fill_format.fill_type = slides.FillType.NO_FILL
        label.text_frame.text = labels[i]
        label_format = label.text_frame.paragraphs[0].portions[0].portion_format
        label_format.font_height = 16
        label_format.fill_format.fill_type = slides.FillType.SOLID
        label_format.fill_format.solid_fill_color.color = slides.Color.black

        math_shape = slide.shapes.add_math_shape(20 + i * 260, 60, 240, 130)
        math_shape.text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.TOP
        math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph
        math_paragraph.justification = math.MathJustification.LEFT_JUSTIFIED

        rows = [create_text("x+y=3"), create_text("x-y=1"), create_text("x=2")]
        equation_array = math.MathArray(rows)
        equation_array.base_justification = alignment
        left_text = create_text("A=")
        right_text = create_text("=B")
        equation = math.MathBlock(left_text).join(equation_array).join(right_text)
        math_paragraph.add(equation)

    presentation.save("equation-array-alignment.pptx", slides.export.SaveFormat.PPTX)
```

다음 비교는 PowerPoint에서 저장된 프레젠테이션을 보여줍니다. 각 배열 옆에 있는 `A=`와 `=B`의 위치를 확인하십시오.

![PowerPoint에서 상단, 중앙, 하단 정렬 및 동일한 인접 요소가 있는 수식 배열](equation-array-alignment.png)

### **행 간격 구성**

[row_spacing_rule](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imatharray/row_spacing_rule/)은 배열 내 행의 간격 규칙을 선택합니다. [row_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imatharray/row_spacing/)은 명시적 간격 규칙에 대한 숫자 값을 제공하며, 프리셋 규칙에 의해 무시됩니다.

정확한 간격은 포인트 단위로 측정됩니다. 비례 간격은 반줄 단위로 측정되며, 예시의 값 `3`은 1.5줄을 의미합니다. 명시적 값을 지정할 때는 두 속성을 모두 설정해야 하며, 숫자 값만 변경해도 간격 규칙이 선택되지 않습니다.

아래 예제는 동일한 수식, 정렬 및 글꼴 설정을 가진 프레젠테이션을 다섯 개 저장합니다. 처음 세 개는 프리셋을 사용하고, 마지막 두 개는 명시적 값을 보여줍니다.

```py
import aspose.slides as slides
import aspose.slides.mathtext as math


def create_text(value):
    text = math.MathematicalText(value)
    text.format.font_height = 24
    text.format.latin_font = slides.FontData("Cambria Math")
    return text


settings = [
    (math.MathRowSpacingRule.SINGLE_LINE_GAP, 0),
    (math.MathRowSpacingRule.ONE_AND_A_HALF_LINE_GAP, 0),
    (math.MathRowSpacingRule.TWO_LINE_GAP, 0),
    (math.MathRowSpacingRule.EXACTLY, 20),
    (math.MathRowSpacingRule.MULTIPLE, 3)
]

for rule, spacing in settings:
    file_name = f"equation-array-{rule.name}.pptx"
    with slides.Presentation() as presentation:
        math_shape = presentation.slides[0].shapes.add_math_shape(20, 20, 600, 300)
        paragraph = math_shape.text_frame.paragraphs[0]
        paragraph.paragraph_format.space_before = 0
        paragraph.paragraph_format.space_after = 0
        math_paragraph = paragraph.portions[0].math_paragraph
        math_paragraph.justification = math.MathJustification.LEFT_JUSTIFIED

        rows = [create_text("x+y=3"), create_text("x-y=1"), create_text("x=2")]
        equation_array = math.MathArray(rows)
        equation_array.base_justification = math.MathVerticalAlignment.CENTER
        equation_array.row_spacing_rule = rule
        equation_array.row_spacing = spacing
        left_text = create_text("A=")
        right_text = create_text("=B")
        equation = math.MathBlock(left_text).join(equation_array).join(right_text)
        math_paragraph.add(equation)

        presentation.save(file_name, slides.export.SaveFormat.PPTX)
```

배열 행 간격은 단락 간격과 별개입니다. [space_before](https://reference.aspose.com/slides/python-net/aspose.slides/iparagraphformat/space_before/)와 [space_after](https://reference.aspose.com/slides/python-net/aspose.slides/iparagraphformat/space_after/)는 포함된 단락 주위에 공간을 추가하며, 배열 행 사이에는 적용되지 않습니다. 마찬가지로 [IMathParagraph.justification](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathparagraph/justification/)은 전체 수학 단락을 수평으로 배치하며, 배열의 수직 정렬 설정을 대체하지 않습니다.

## **삼각 함수 추가**

인수가 현재 요소이고 함수 이름이 알려진 경우 [as_argument_of_function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/as_argument_of_function/)을 사용합니다.

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

인덱스와 지수를 위해 첨자 및 위첨자 도우미를 사용합니다. 인덱스가 기반의 왼쪽에 표시되어야 할 경우 [set_sub_superscript_on_the_left](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_sub_superscript_on_the_left/)을 사용하십시오.

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

[enclose](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/enclose/)를 사용하여 구분자 안에 식을 넣습니다. 여러 요소를 포함하는 구분자 식에 대해 구분자를 설정할 수도 있습니다.

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

### **구분자 크기 및 정렬**

[grow_to_match_operand_height](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathdelimiter/grow_to_match_operand_height/)를 `True`로 설정하면 큰 피연산자 주위에 괄호가 확대되고, `False`로 설정하면 일반 크기를 유지합니다. [delimiter_shape](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathdelimiter/delimiter_shape/)은 두 가지 [MathDelimiterShape](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathdelimitershape/) 값 중 하나를 취합니다. `CENTERED`는 등호 기호의 중간을 통과하는 수학 축에 괄호를 중앙에 배치하고, `MATCH`는 포함된 내용에 맞춰 정렬합니다. 두 설정은 구분자에만 영향을 미치며, 내부 식은 동일하게 유지됩니다.

예제는 `x`의 지수에 분수를 배치하여 식이 기준선 위쪽으로 더 많이 확장되도록 합니다. 네 개의 방정식 모두 동일한 괄호와 글꼴 설정을 사용합니다.

```python
import aspose.slides as slides
import aspose.slides.mathtext as math


def add_expression(slide, left, top, grow, shape):
    fraction = math.MathematicalText("a + b").divide("c + d")
    power = math.MathematicalText("x").set_superscript(fraction)
    delimiter = power.enclose("(", ")")
    delimiter.grow_to_match_operand_height = grow
    delimiter.delimiter_shape = shape

    math_shape = slide.shapes.add_math_shape(left, top, 300, 100)
    portion = math_shape.text_frame.paragraphs[0].portions[0]
    portion.portion_format.font_height = 32
    equation = math.MathematicalText("y = ").join(delimiter)
    portion.math_paragraph.add(equation)


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    add_expression(slide, 20, 20, True, math.MathDelimiterShape.CENTERED)
    add_expression(slide, 350, 20, True, math.MathDelimiterShape.MATCH)
    add_expression(slide, 20, 140, False, math.MathDelimiterShape.CENTERED)
    add_expression(slide, 350, 140, False, math.MathDelimiterShape.MATCH)

    presentation.save("delimiter-sizing.pptx", slides.export.SaveFormat.PPTX)
```

PowerPoint에서 행을 비교하면 확장 효과를 확인할 수 있습니다. 상단 행에서는 괄호가 지수를 둘러싸도록 확대되어 두 형태가 동일하게 보입니다. 하단 행에서는 확대가 비활성화됩니다. 왼쪽의 작은 괄호(`CENTERED`)는 등호에 맞춰 정렬되고, 오른쪽의 괄호(`MATCH`)는 식 주위에 더 높게 배치됩니다.

![PowerPoint에서 구분자 확대가 위에서는 활성화되고 아래에서는 비활성화된 네 개의 방정식, 왼쪽은 Centered, 오른쪽은 Match](delimiter-sizing.png)

## **테두리 상자 추가**

분수에 [to_border_box](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/to_border_box/)을 호출하면 전체 식을 테두리로 감쌀 수 있습니다. 반환된 [IMathBorderBox](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/)은 기본적으로 네 면을 모두 표시합니다. 개별 면을 제거하려면 [hide_top](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/hide_top/), [hide_bottom](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/hide_bottom/), [hide_left](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/hide_left/), [hide_right](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/hide_right/)를 사용하십시오.

예제는 하나의 슬라이드에 동일한 분수를 여섯 개 배치합니다. 취소를 표시하려면 모든 면을 숨기고, 상승 대각선(↗)을 위해 [strikethrough_bottom_left_to_top_right](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/strikethrough_bottom_left_to_top_right/)을, 하강 대각선(↘)을 위해 [strikethrough_top_left_to_bottom_right](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/strikethrough_top_left_to_bottom_right/)을 설정합니다. 또한 [strikethrough_horizontal](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/strikethrough_horizontal/) 또는 [strikethrough_vertical](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/strikethrough_vertical/)을 사용하여 보이는 면의 조합을 지정할 수 있습니다.

```py
import aspose.slides as slides
import aspose.slides.mathtext as math


def add_fraction(slide, x, y, hide_border=False):
    fraction = math.MathematicalText("x+1").divide("y+2")
    box = fraction.to_border_box()
    box.hide_top = box.hide_bottom = box.hide_left = box.hide_right = hide_border

    shape = slide.shapes.add_math_shape(x, y, 160, 90)
    portion = shape.text_frame.paragraphs[0].portions[0]
    portion.portion_format.font_height = 28
    portion.math_paragraph.add(math.MathBlock(box))
    return box


with slides.Presentation() as presentation:
    presentation.slide_size.set_size(540, 220, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]

    add_fraction(slide, 10, 10)

    partial = add_fraction(slide, 190, 10)
    partial.hide_top = True
    partial.hide_right = True

    add_fraction(slide, 370, 10, hide_border=True).strikethrough_bottom_left_to_top_right = True
    add_fraction(slide, 10, 120, hide_border=True).strikethrough_top_left_to_bottom_right = True
    add_fraction(slide, 190, 120, hide_border=True).strikethrough_horizontal = True
    add_fraction(slide, 370, 120).strikethrough_vertical = True

    presentation.save("border-box.pptx", slides.export.SaveFormat.PPTX)
```

![PowerPoint에서 편집 가능한 여섯 개의 분수. 상단 행: 전체 테두리, 아래와 왼쪽 면, 상승 대각선. 하단 행: 하강 대각선, 수평 스트라이크, 전체 테두리와 함께한 수직 스트라이크](border-box-fractions.png)

이 분수에서는 수평 스트라이크가 분수선을 겹칩니다. 수직 스트라이크는 분자와 분모를 모두 가로지르며 주변 테두리는 보입니다. 이러한 선은 전체 식을 장식합니다. 일반 텍스트 취소선은 텍스트 실행의 문자에 적용됩니다. PowerPoint에서 프레젠테이션을 다시 열어도 분자와 분모를 독립적으로 편집할 수 있습니다.

## **용어 그룹화**

[group](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/group/)을 사용하여 식 위 또는 아래에 그룹화 기호를 배치합니다. 그룹화된 항목에 레이블을 달려면 제한을 추가하십시오.

![표시가 아래에 있는 x + y 식을 그룹화](powerpoint-math-equations_15.png)

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

수식이 명확해지는 경우에만 서식 도우미를 사용하십시오. 예를 들어, [overbar](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/overbar/)은 수학 요소 위에 바를 그립니다.

![위에 바가 있는 수학 식 ABC](powerpoint-math-equations_14.png)

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

### **기존 방정식의 텍스트 서식 지정**

기존 방정식 전체의 텍스트에 서식을 지정하려면 각 수학 블록의 요소 트리를 순회합니다. [IMathElement.get_children](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/get_children/)은 직접 자식만 반환하므로, 분수, 스크립트, 근호 및 기타 중첩 구조 내부의 텍스트에 도달하려면 재귀적으로 호출해야 합니다. 현재 요소와 그 자식들을 확인하여 시작 요소가 [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/)인 경우에도 포함하십시오.

이 예제는 `input.pptx`에 `z = xᵢ / ∛y`와 같은 방정식이 포함되어 있다고 가정합니다. 여기서 분수는 분자에 첨자, 분모에 근호를 포함합니다. 블록의 최상위 요소만 처리하면 분수 내부 텍스트를 놓치게 됩니다. 예제는 슬라이드 텍스트 프레임에서 수학 부분을 찾아 [MathPortion.math_paragraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/math_paragraph/)을 통해 블록에 접근하고, 각 텍스트 요소의 [format](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/format/) 속성을 사용하여 [font_height](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/font_height/)을 28포인트로 설정합니다.

```py
import aspose.slides as slides
import aspose.slides.mathtext as math


def format_math_text(element):
    if isinstance(element, math.MathematicalText):
        element.format.font_height = 28

    for child in element.get_children():
        format_math_text(child)


with slides.Presentation("input.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if not isinstance(shape, slides.AutoShape) or shape.text_frame is None:
                continue

            for paragraph in shape.text_frame.paragraphs:
                for portion in paragraph.portions:
                    if isinstance(portion, math.MathPortion):
                        for block in portion.math_paragraph:
                            format_math_text(block)

    presentation.save("formatted-equations.pptx", slides.export.SaveFormat.PPTX)
```

저장된 프레젠테이션은 처리된 각 방정식의 모든 수준에서 업데이트된 텍스트 서식을 포함하며, 텍스트 내용과 수학 구조는 그대로 유지됩니다.

## **빠른 참조**

| 작업 | 주요 API |
| --- | --- |
| 수학 텍스트 만들기 | [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/) |
| 요소 결합 | [IMathElement.join](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/join/) |
| 분수 만들기 | [IMathElement.divide](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/divide/) |
| 위첨자 또는 첨자 추가 | [set_superscript](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_superscript/), [set_subscript](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_subscript/) |
| 함수 추가 | [function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/function/), [as_argument_of_function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/as_argument_of_function/) |
| 근호 추가 | [radical](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/radical/) |
| 제한 추가 | [set_lower_limit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_lower_limit/), [set_upper_limit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_upper_limit/) |
| 왼쪽 스크립트 추가 | [set_sub_superscript_on_the_left](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_sub_superscript_on_the_left/) |
| 합계 및 적분 추가 | [nary](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/nary/), [integral](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/integral/) |
| 행렬 추가 | [MathMatrix](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathmatrix/) |
| 수식 배열 추가 | [to_math_array](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/to_math_array/) |
| 구분자 추가 | [enclose](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/enclose/) |
| 바와 테두리 추가 | [overbar](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/overbar/), [to_border_box](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/to_border_box/) |
| 용어 그룹화 | [group](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/group/) |

## **자주 묻는 질문**

**기존 PowerPoint 수식을 편집할 수 있나요?**

예. 프레젠테이션을 열고, [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/)을 포함하는 도형을 찾아 해당 [math_paragraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/math_paragraph/)을 얻은 다음, 그 단락의 수학 블록을 업데이트합니다.

**수식이 편집 가능한 PowerPoint 수학으로 저장되나요?**

예. PPTX로 저장하면 Aspose.Slides는 방정식을 편집 가능한 Office 수학 콘텐츠로 기록합니다.

**수식을 LaTeX로 내보낼 수 있나요?**

예. 해당 [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/)에서 방정식의 [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/)을 가져와 [MathParagraph.to_latex](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/to_latex/)를 호출하면 직접 내보낼 수 있습니다. 전체 예제는 [Python을 통한 .NET에서 프레젠테이션의 수식 내보내기](/slides/ko/python-net/exporting-math-equations/#export-math-equations-to-latex)를 참고하십시오.
---
title: .NET에서 PowerPoint 프레젠테이션에 수학 방정식 추가
linktitle: PowerPoint 수학 방정식
type: docs
weight: 80
url: /ko/net/powerpoint-math-equations/
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
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET을 사용하여 PowerPoint PPT 및 PPTX에 수학 방정식을 삽입하고 편집합니다. OMML 지원, 서식 제어 및 명확한 C# 코드 샘플을 제공합니다."
---
## **개요**

PowerPoint는 방정식을 Office Math Markup Language(OMML)로 저장합니다. Aspose.Slides for .NET을 사용하면 프로그램matically 동일한 종류의 수학 콘텐츠(분수, 근, 함수, 극한, N-ary 연산자, 행렬, 배열 및 형식화된 수학 블록)를 만들 수 있습니다.

PowerPoint에서 사용자는 일반적으로 **Insert > Equation**을 통해 방정식을 추가합니다:

![PowerPoint 삽입 탭에서 방정식 명령이 선택된 상태](powerpoint-math-equations_1.png)

그 결과 슬라이드에 편집 가능한 수학 텍스트가 표시됩니다:

![편집 가능한 수학 방정식을 포함한 PowerPoint 슬라이드](powerpoint-math-equations_2.png)

Aspose.Slides는 이 수학 텍스트를 세 개의 주요 객체를 통해 구성합니다:

- [AddMathShape](https://reference.aspose.com/slides/ko/net/aspose.slides/ishapecollection/addmathshape/)으로 생성된 수학 도형은 방정식을 담고 있는 도형입니다.
- [MathPortion](https://reference.aspose.com/slides/ko/net/aspose.slides.mathtext/mathportion/)은 도형 텍스트 프레임 내에 수학 콘텐츠를 저장합니다.
- [MathParagraph](https://reference.aspose.com/slides/ko/net/aspose.slides.mathtext/mathparagraph/)은 하나 이상의 [MathBlock](https://reference.aspose.com/slides/ko/net/aspose.slides.mathtext/mathblock/) 객체를 포함합니다.

아래 대부분의 예제는 [MathematicalText](https://reference.aspose.com/slides/ko/net/aspose.slides.mathtext/mathematicaltext/)와 [IMathElement](https://reference.aspose.com/slides/ko/net/aspose.slides.mathtext/imathelement/)의 유창한 메서드를 사용하여 코드를 간결하고 읽기 쉽게 유지합니다.

MathML 내보내기 시나리오에 대해서는 [Export Math Equations from Presentations in .NET](/slides/ko/net/exporting-math-equations/)를 참조하세요.

## **수식 만들기**

이 예제는 수학 도형을 만들고 피타고라스 정리를 추가합니다:

![c² = a² + b² 방정식](powerpoint-math-equations_3.png)

```csharp
using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 120);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var equation = new MathematicalText("c")
    .SetSuperscript("2")
    .Join("=")
    .Join(new MathematicalText("a").SetSuperscript("2"))
    .Join("+")
    .Join(new MathematicalText("b").SetSuperscript("2"));

mathParagraph.Add(equation);

presentation.Save("pythagorean-theorem.pptx", SaveFormat.Pptx);
```

{{% alert color="primary" %}}
`AddMathShape`는 이미 수학 단락을 포함하는 도형을 생성합니다. 첫 번째 `MathPortion`에 접근하고, 해당 `MathParagraph`를 가져온 다음, 수학 블록이나 수학 요소를 추가합니다.
{{% /alert %}}

## **분수 추가**

`Divide`를 사용하여 분수를 생성합니다. [MathFractionTypes](https://reference.aspose.com/slides/ko/net/aspose.slides.mathtext/mathfractiontypes/)로 분수 스타일을 선택할 수 있습니다.

![하나를 x로 나눈 비스듬한 수학 분수](powerpoint-math-equations_4.png)

```csharp
using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 100);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var fraction = new MathematicalText("1")
    .Divide("x", MathFractionTypes.Skewed);

mathParagraph.Add(new MathBlock(fraction));

presentation.Save("fraction.pptx", SaveFormat.Pptx);
```

중첩 분수를 만들려면 `MathFractionTypes.Bar`를 사용합니다:

```csharp
var stackedFraction = new MathematicalText("x + 1").Divide("y - 1", MathFractionTypes.Bar);
```

## **근 추가**

`Radical`을 사용하여 제곱근, 세제곱근 또는 기타 근을 생성합니다. 현재 요소가 밑이 되고 인수가 차수가 됩니다.

![x가 근호 기호 아래에 있는 n번째 근 표현식](powerpoint-math-equations_5.png)

```csharp
using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 100);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var radical = new MathematicalText("x")
    .Radical("n");

mathParagraph.Add(new MathBlock(radical));

presentation.Save("radical.pptx", SaveFormat.Pptx);
```

## **함수와 극한 추가**

`AsArgumentOfFunction` 또는 `Function`을 사용하여 `sin(x)`, `log(x)`와 같은 함수 또는 사용자 정의 함수 이름을 지정합니다. 극한의 경우 [MathLimit](https://reference.aspose.com/slides/ko/net/aspose.slides.mathtext/mathlimit/)에 `lim`을 넣거나 `SetLowerLimit`을 사용합니다.

![x가 무한대로 접근할 때의 극한](powerpoint-math-equations_8.png)

```csharp
using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 100);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var limit = new MathematicalText("lim")
    .SetLowerLimit("x→∞")
    .Function("x");

mathParagraph.Add(new MathBlock(limit));

presentation.Save("functions-and-limits.pptx", SaveFormat.Pptx);
```

사용자 정의 함수 이름을 지정하려면 현재 요소를 함수 이름으로 만듭니다:

```csharp
var customFunction = new MathematicalText("f").Function("x + 1");
```

## **N-ary 연산자와 적분 추가**

`Nary`를 사용하여 합계, 합집합, 교집합 및 기타 대형 연산자를 추가합니다. `Integral`을 사용하여 적분을 추가합니다. 두 메서드 모두 하한과 상한을 설정할 수 있습니다.

![하한과 상한이 있는 합계](powerpoint-math-equations_7.png)

```csharp
using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 120);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var summationBase = new MathematicalText("x")
    .SetSuperscript("k")
    .Join(new MathematicalText("a").SetSuperscript("n-k"));

var summation = summationBase.Nary(MathNaryOperatorTypes.Summation, "k=0", "n");

mathParagraph.Add(new MathBlock(summation));

presentation.Save("nary-operators.pptx", SaveFormat.Pptx);
```

N-ary 연산자는 선택적 한계가 있는 대형 연산자를 위한 것입니다. `+`, `-`, `=`와 같은 단순 연산자는 일반적으로 `MathematicalText`로 추가하고 식에 결합합니다.

적분을 추가하려면 `Integral`을 사용합니다:

```csharp
var integralBase = new MathematicalText("x").Join(new MathematicalText("dx").ToBox());
var integral = integralBase.Integral(MathIntegralTypes.Simple, "0", "1");
```

## **행렬 추가**

행과 열을 정의하려면 [MathMatrix](https://reference.aspose.com/slides/ko/net/aspose.slides.mathtext/mathmatrix/)를 사용합니다. 행렬은 기본적으로 괄호를 포함하지 않으므로 필요에 따라 괄호, 대괄호 또는 중괄호로 감싸야 합니다.

![한 셀 비어 있는 두 행 행렬](powerpoint-math-equations_10.png)

```csharp
using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 120);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var matrix = new MathMatrix(2, 3);
matrix[0, 0] = new MathematicalText("1");
matrix[0, 1] = new MathematicalText("x");
matrix[1, 0] = new MathematicalText("x");
matrix[1, 1] = new MathematicalText("2");
matrix[1, 2] = new MathematicalText("y");

mathParagraph.Add(new MathBlock(matrix));

presentation.Save("matrix.pptx", SaveFormat.Pptx);
```

## **방정식 배열 추가**

정렬된 방정식이나 수직으로 쌓인 표현식이 필요할 때 `ToMathArray`를 사용합니다.

![x가 위에, y가 아래에 있는 수직 배열](powerpoint-math-equations_11.png)

```csharp
using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 140);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var equationArray = new MathematicalText("x")
    .Join("y")
    .ToMathArray();

mathParagraph.Add(new MathBlock(equationArray));

presentation.Save("equation-array.pptx", SaveFormat.Pptx);
```

## **삼각 함수 추가**

인수가 현재 요소이고 함수 이름이 알려진 경우 `AsArgumentOfFunction`을 사용합니다.

![2x에 적용된 삼각 함수 cos](powerpoint-math-equations_6.png)

```csharp
using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 100);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var cosine = new MathematicalText("2x")
    .AsArgumentOfFunction(MathFunctionsOfOneArgument.Cos);

mathParagraph.Add(new MathBlock(cosine));

presentation.Save("trigonometric-function.pptx", SaveFormat.Pptx);
```

## **첨자와 위첨자 추가**

인덱스와 거듭 제곱을 위해 첨자와 위첨자 도우미를 사용합니다. 인덱스를 기반 요소의 왼쪽에 표시해야 할 경우 `SetSubSuperscriptOnTheLeft`를 사용합니다.

![왼쪽에 첨자 1과 위첨자 n이 있는 대문자 Y](powerpoint-math-equations_9.png)

```csharp
using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 100);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var scripts = new MathematicalText("Y")
    .SetSubSuperscriptOnTheLeft("1", "n");

mathParagraph.Add(new MathBlock(scripts));

presentation.Save("subscript-superscript.pptx", SaveFormat.Pptx);
```

## **구분자 추가**

`Enclose`를 사용하여 표현식을 구분자 안에 넣습니다. 여러 요소를 포함하는 구분자 표현식에 대해 구분 문자도 설정할 수 있습니다.

![x, y, z가 수직 막대로 구분된 구분자 표현식](powerpoint-math-equations_13.png)

```csharp
using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 100);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var delimiter = new MathematicalText("x")
    .Join("y")
    .Join("z")
    .Enclose('<', '>');
delimiter.SeparatorCharacter = '|';

mathParagraph.Add(new MathBlock(delimiter));

presentation.Save("delimiters.pptx", SaveFormat.Pptx);
```

## **테두리 상자 추가**

방정식 자체를 테두리로 감싸려면 `ToBorderBox`를 사용합니다.

![a² = b² + c²를 보여주는 상자 안의 방정식](powerpoint-math-equations_12.png)

```csharp
using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 100);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var boxedEquation = new MathematicalText("a")
    .SetSuperscript("2")
    .Join("=")
    .Join(new MathematicalText("b").SetSuperscript("2"))
    .Join("+")
    .Join(new MathematicalText("c").SetSuperscript("2"))
    .ToBorderBox();

mathParagraph.Add(new MathBlock(boxedEquation));

presentation.Save("border-box.pptx", SaveFormat.Pptx);
```

## **항 그룹화**

`Group`을 사용하여 표현식 위 또는 아래에 그룹화 문자를 배치합니다. 그룹화된 항에 레이블을 지정하려면 한계를 추가합니다.

![x + y가 그룹화되고 아래에 'any text' 레이블이 있는 표현식](powerpoint-math-equations_15.png)

```csharp
using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 120);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var grouped = new MathematicalText("x + y")
    .Group('\u23DF', MathTopBotPositions.Bottom, MathTopBotPositions.Top)
    .SetLowerLimit("any text");

mathParagraph.Add(new MathBlock(grouped));

presentation.Save("grouped-terms.pptx", SaveFormat.Pptx);
```

## **수학 요소 서식 지정**

수식의 가독성을 높이는 경우에만 서식 도우미를 사용합니다. 예를 들어 `Overbar`는 수학 요소 위에 바를 추가합니다.

![위에 바가 있는 수학 표현식 ABC](powerpoint-math-equations_14.png)

```csharp
using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 100);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var overbar = new MathematicalText("ABC").Overbar();

mathParagraph.Add(new MathBlock(overbar));

presentation.Save("overbar.pptx", SaveFormat.Pptx);
```

## **빠른 참조**

| 작업 | 주요 API |
| --- | --- |
| 수학 텍스트 만들기 | [MathematicalText](https://reference.aspose.com/slides/ko/net/aspose.slides.mathtext/mathematicaltext/) |
| 요소 결합 | [IMathElement.Join](https://reference.aspose.com/slides/ko/net/aspose.slides.mathtext/imathelement/join/) |
| 분수 만들기 | [IMathElement.Divide](https://reference.aspose.com/slides/ko/net/aspose.slides.mathtext/imathelement/divide/) |
| 위첨자 또는 아래첨자 추가 | [SetSuperscript](https://reference.aspose.com/slides/ko/net/aspose.slides.mathtext/imathelement/setsuperscript/), [SetSubscript](https://reference.aspose.com/slides/ko/net/aspose.slides.mathtext/imathelement/setsubscript/) |
| 함수 추가 | [Function](https://reference.aspose.com/slides/ko/net/aspose.slides.mathtext/imathelement/function/), [AsArgumentOfFunction](https://reference.aspose.com/slides/ko/net/aspose.slides.mathtext/imathelement/asargumentoffunction/) |
| 근 추가 | [IMathElement.Radical](https://reference.aspose.com/slides/ko/net/aspose.slides.mathtext/imathelement/radical/) |
| 극한 추가 | [SetLowerLimit](https://reference.aspose.com/slides/ko/net/aspose.slides.mathtext/imathelement/setlowerlimit/), [SetUpperLimit](https://reference.aspose.com/slides/ko/net/aspose.slides.mathtext/imathelement/setupperlimit/) |
| 왼쪽 첨자/위첨자 추가 | [SetSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/ko/net/aspose.slides.mathtext/imathelement/setsubsuperscriptontheleft/) |
| 합계와 적분 추가 | [Nary](https://reference.aspose.com/slides/ko/net/aspose.slides.mathtext/imathelement/nary/), [Integral](https://reference.aspose.com/slides/ko/net/aspose.slides.mathtext/imathelement/integral/) |
| 행렬 추가 | [MathMatrix](https://reference.aspose.com/slides/ko/net/aspose.slides.mathtext/mathmatrix/) |
| 방정식 배열 추가 | [ToMathArray](https://reference.aspose.com/slides/ko/net/aspose.slides.mathtext/imathelement/tomatharray/) |
| 구분자 추가 | [Enclose](https://reference.aspose.com/slides/ko/net/aspose.slides.mathtext/imathelement/enclose/) |
| 바와 테두리 추가 | [Overbar](https://reference.aspose.com/slides/ko/net/aspose.slides.mathtext/imathelement/overbar/), [ToBorderBox](https://reference.aspose.com/slides/ko/net/aspose.slides.mathtext/imathelement/toborderbox/) |
| 항 그룹화 | [Group](https://reference.aspose.com/slides/ko/net/aspose.slides.mathtext/imathelement/group/) |

## **FAQ**

**기존 PowerPoint 방정식을 편집할 수 있나요?**

예. 프레젠테이션을 열고 `MathPortion`을 포함하는 도형을 찾은 다음 해당 `MathParagraph`를 가져와 그 단락의 수학 블록을 업데이트합니다.

**방정식이 편집 가능한 PowerPoint 수학으로 저장되나요?**

예. PPTX로 저장할 때 Aspose.Slides는 방정식을 편집 가능한 Office 수학 콘텐츠로 기록합니다.

**방정식을 LaTeX로 내보낼 수 있나요?**

예. 방정식의 [IMathParagraph](https://reference.aspose.com/slides/ko/net/aspose.slides.mathtext/imathparagraph/)를 해당 [MathPortion](https://reference.aspose.com/slides/ko/net/aspose.slides.mathtext/mathportion/)에서 가져와 [IMathParagraph.ToLatex](https://reference.aspose.com/slides/ko/net/aspose.slides.mathtext/imathparagraph/tolatex/)를 호출하면 직접 내보낼 수 있습니다. 전체 예제는 [Export Math Equations from Presentations in .NET](/slides/ko/net/exporting-math-equations/#export-math-equations-to-latex)를 참조하세요.
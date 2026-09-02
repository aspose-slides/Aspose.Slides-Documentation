---
title: PHP에서 PowerPoint 프레젠테이션에 수식 추가
linktitle: PowerPoint 수식
type: docs
weight: 80
url: /ko/php-java/powerpoint-math-equations/
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
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java를 사용하여 PowerPoint PPT 및 PPTX에 수식(OMML)을 삽입하고 편집할 수 있으며, 서식 제어와 명확한 PHP 코드 예제를 지원합니다."
---
## **개요**

PowerPoint은 수식을 Office Math Markup Language(OMML) 형식으로 저장합니다. Aspose.Slides for PHP via Java를 사용하면 분수, 근호, 함수, 극한, N진 연산자, 행렬, 배열 및 서식이 지정된 수식 블록과 같은 수학 콘텐츠를 프로그래밍 방식으로 생성할 수 있습니다.

PowerPoint에서 사용자는 일반적으로 **삽입 > 수식**을 통해 수식을 추가합니다:

![PowerPoint Insert tab with the Equation command selected](powerpoint-math-equations_1.png)

그 결과 슬라이드에 편집 가능한 수식 텍스트가 표시됩니다:

![A PowerPoint slide containing an editable math equation](powerpoint-math-equations_2.png)

Aspose.Slides는 세 가지 주요 객체를 통해 해당 수식 텍스트를 구성합니다:

- 수식을 포함하는 도형을 만들 때 사용하는 [addMathShape](https://reference.aspose.com/slides/ko/php-java/aspose.slides/shapecollection/#addMathShape)입니다.
- 도형 텍스트 프레임 안에 수식 콘텐츠를 저장하는 [MathPortion](https://reference.aspose.com/slides/ko/php-java/aspose.slides/mathportion/)입니다.
- 하나 이상의 [MathBlock](https://reference.aspose.com/slides/ko/php-java/aspose.slides/mathblock/) 객체를 포함하는 [MathParagraph](https://reference.aspose.com/slides/ko/php-java/aspose.slides/mathparagraph/)입니다.

아래 대부분의 예제는 코드를 간결하고 가독성 있게 유지하기 위해 [MathematicalText](https://reference.aspose.com/slides/ko/php-java/aspose.slides/mathematicaltext/)와 [MathElementBase](https://reference.aspose.com/slides/ko/php-java/aspose.slides/mathelementbase/)의 플루언트 메서드를 사용합니다.

MathML 내보내기 시나리오에 대해서는 [Export Math Equations from Presentations in PHP via Java](/slides/ko/php-java/exporting-math-equations/)를 참조하십시오.

## **방정식 만들기**

이 예제는 수학 도형을 만들고 피타고라스 정리를 추가합니다:

![The equation c squared equals a squared plus b squared](powerpoint-math-equations_3.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 120);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $equation = (new MathematicalText("c"))
        - >setSuperscript("2")
        - >join("=")
        - >join((new MathematicalText("a"))->setSuperscript("2"))
        - >join("+")
        - >join((new MathematicalText("b"))->setSuperscript("2"));

    $mathParagraph->add($equation);

    $presentation->save("pythagorean-theorem.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

{{% alert color="primary" %}}
`addMathShape`은 이미 수학 단락을 포함하고 있는 도형을 생성합니다. 첫 번째 `MathPortion`에 접근하고, 해당 `MathParagraph`를 가져온 뒤 수학 블록이나 수학 요소를 추가합니다.
{{% /alert %}}

## **분수 추가**

[`divide`](https://reference.aspose.com/slides/ko/php-java/aspose.slides/mathelementbase/)를 사용하여 분수를 만들 수 있습니다. [MathFractionTypes](https://reference.aspose.com/slides/ko/php-java/aspose.slides/mathfractiontypes/)를 사용해 분수 스타일을 선택하세요.

![A skewed math fraction showing one divided by x](powerpoint-math-equations_4.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 100);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $fraction = (new MathematicalText("1"))
        - >divide("x", MathFractionTypes::Skewed);

    $mathParagraph->add(new MathBlock($fraction));

    $presentation->save("fraction.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

중첩된 분수를 만들려면 `MathFractionTypes::Bar`를 사용합니다:

```php
$stackedFraction = (new MathematicalText("x + 1"))->divide("y - 1", MathFractionTypes::Bar);
```

## **근호 추가**

[`radical`](https://reference.aspose.com/slides/ko/php-java/aspose.slides/mathelementbase/)를 사용하여 제곱근, 세제곱근 또는 기타 근호를 만들 수 있습니다. 현재 요소가 밑이 되고, 인수가 차수가 됩니다.

![An n-th root radical expression with x under the radical sign](powerpoint-math-equations_5.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 100);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $radical = (new MathematicalText("x"))
        - >radical("n");

    $mathParagraph->add(new MathBlock($radical));

    $presentation->save("radical.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **함수와 극한 추가**

함수(`sin(x)`, `log(x)` 등) 또는 사용자 정의 함수 이름을 사용할 때는 [`asArgumentOfFunction`](https://reference.aspose.com/slides/ko/php-java/aspose.slides/mathelementbase/)나 [`function`](https://reference.aspose.com/slides/ko/php-java/aspose.slides/mathelementbase/)를 사용합니다. 극한을 지정하려면 `lim`을 [MathLimit](https://reference.aspose.com/slides/ko/php-java/aspose.slides/mathlimit/)에 넣거나 [`setLowerLimit`](https://reference.aspose.com/slides/ko/php-java/aspose.slides/mathelementbase/)를 사용합니다.

![The limit of x as x approaches infinity](powerpoint-math-equations_8.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 100);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $limit = (new MathematicalText("lim"))
        - >setLowerLimit("x\u{2192}\u{221E}")
        - >function("x");

    $mathParagraph->add(new MathBlock($limit));

    $presentation->save("functions-and-limits.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

사용자 정의 함수 이름을 지정하려면 함수 이름을 현재 요소로 만들면 됩니다:

```php
$customFunction = (new MathematicalText("f"))->function("x + 1");
```

## **N진 연산자와 적분 추가**

합계, 합집합, 교집합 및 기타 대형 연산자를 위해서는 [`nary`](https://reference.aspose.com/slides/ko/php-java/aspose.slides/mathelementbase/)를 사용합니다. 적분은 [`integral`](https://reference.aspose.com/slides/ko/php-java/aspose.slides/mathelementbase/)를 사용합니다. 두 메서드 모두 아래·위 제한을 설정할 수 있습니다.

![A summation with lower and upper limits](powerpoint-math-equations_7.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 120);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $summationBase = (new MathematicalText("x"))
        - >setSuperscript("k")
        - >join((new MathematicalText("a"))->setSuperscript("n-k"));

    $summation = $summationBase->nary(MathNaryOperatorTypes::Summation, "k=0", "n");

    $mathParagraph->add(new MathBlock($summation));

    $presentation->save("nary-operators.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

N진 연산자는 선택적 제한이 있는 대형 연산자를 의미합니다. `+`, `-`, `=`와 같은 단순 연산자는 보통 `MathematicalText`로 추가한 뒤 식에 결합합니다.

적분을 삽입하려면 `integral`을 사용합니다:

```php
$integralBase = (new MathematicalText("x"))->join((new MathematicalText("dx"))->toBox());
$integral = $integralBase->integral(MathIntegralTypes::Simple, "0", "1");
```

## **행렬 추가**

행과 열을 정의하려면 [MathMatrix](https://reference.aspose.com/slides/ko/php-java/aspose.slides/mathmatrix/)를 사용합니다. 기본적으로 행렬에는 괄호가 포함되지 않으므로, 필요에 따라 괄호, 대괄호 또는 중괄호로 감싸야 합니다.

![A two-row math matrix with one empty cell](powerpoint-math-equations_10.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 120);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $matrix = new MathMatrix(2, 3);
    $matrix->set_Item(0, 0, new MathematicalText("1"));
    $matrix->set_Item(0, 1, new MathematicalText("x"));
    $matrix->set_Item(1, 0, new MathematicalText("x"));
    $matrix->set_Item(1, 1, new MathematicalText("2"));
    $matrix->set_Item(1, 2, new MathematicalText("y"));

    $mathParagraph->add(new MathBlock($matrix));

    $presentation->save("matrix.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **수식 배열 추가**

정렬된 방정식이나 수직으로 쌓인 식이 필요할 때는 [`toMathArray`](https://reference.aspose.com/slides/ko/php-java/aspose.slides/mathelementbase/)를 사용합니다.

![A vertical math array with x above y](powerpoint-math-equations_11.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 140);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $equationArray = (new MathematicalText("x"))
        - >join("y")
        - >toMathArray();

    $mathParagraph->add(new MathBlock($equationArray));

    $presentation->save("equation-array.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **삼각함수 추가**

인수가 현재 요소이고 함수 이름이 알려진 경우에는 [`asArgumentOfFunction`](https://reference.aspose.com/slides/ko/php-java/aspose.slides/mathelementbase/)를 사용합니다.

![The trigonometric function cos applied to 2x](powerpoint-math-equations_6.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 100);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $cosine = (new MathematicalText("2x"))
        - >asArgumentOfFunction(MathFunctionsOfOneArgument::Cos);

    $mathParagraph->add(new MathBlock($cosine));

    $presentation->save("trigonometric-function.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **아래첨자와 위첨자 추가**

인덱스와 지수를 위해 아래첨자·위첨자 도우미를 사용합니다. 인덱스가 기준 요소의 왼쪽에 나타나야 하는 경우에는 [`setSubSuperscriptOnTheLeft`](https://reference.aspose.com/slides/ko/php-java/aspose.slides/mathelementbase/)를 사용합니다.

![A capital Y with left-side subscript 1 and superscript n](powerpoint-math-equations_9.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 100);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $scripts = (new MathematicalText("Y"))
        - >setSubSuperscriptOnTheLeft("1", "n");

    $mathParagraph->add(new MathBlock($scripts));

    $presentation->save("subscript-superscript.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **구분자 추가**

표현식을 구분자 안에 넣으려면 [`enclose`](https://reference.aspose.com/slides/ko/php-java/aspose.slides/mathelementbase/)를 사용합니다. 여러 요소를 포함하는 구분자 표현식에 대해서는 구분 문자도 설정할 수 있습니다.

![A delimiter expression containing x, y, and z separated by vertical bars](powerpoint-math-equations_13.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 100);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $delimiter = (new MathematicalText("x"))
        - >join("y")
        - >join("z")
        - >enclose(new Java("java.lang.Character", "<"), new Java("java.lang.Character", ">"));
    $delimiter->setSeparatorCharacter(new Java("java.lang.Character", "|"));

    $mathParagraph->add(new MathBlock($delimiter));

    $presentation->save("delimiters.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **테두리 상자 추가**

수식 자체를 테두리로 감싸려면 [`toBorderBox`](https://reference.aspose.com/slides/ko/php-java/aspose.slides/mathelementbase/)를 사용합니다.

![A boxed equation showing a squared equals b squared plus c squared](powerpoint-math-equations_12.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 100);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $boxedEquation = (new MathematicalText("a"))
        - >setSuperscript("2")
        - >join("=")
        - >join((new MathematicalText("b"))->setSuperscript("2"))
        - >join("+")
        - >join((new MathematicalText("c"))->setSuperscript("2"))
        - >toBorderBox();

    $mathParagraph->add(new MathBlock($boxedEquation));

    $presentation->save("border-box.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **용어 그룹화**

그룹화 문자를 식 위나 아래에 배치하려면 [`group`](https://reference.aspose.com/slides/ko/php-java/aspose.slides/mathelementbase/)를 사용합니다. 그룹화된 항목에 라벨을 달기 위해 제한을 추가할 수 있습니다.

![The expression x plus y grouped with the label any text below it](powerpoint-math-equations_15.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 120);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $grouped = (new MathematicalText("x + y"))
        - >group(new Java("java.lang.Character", "\u{23DF}"), MathTopBotPositions::Bottom, MathTopBotPositions::Top)
        - >setLowerLimit("any text");

    $mathParagraph->add(new MathBlock($grouped));

    $presentation->save("grouped-terms.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **수학 요소 서식 지정**

수식이 명확해지는 경우에만 서식 도우미를 사용합니다. 예를 들어 [`overbar`](https://reference.aspose.com/slides/ko/php-java/aspose.slides/mathelementbase/)는 수학 요소 위에 막대를 추가합니다.

![A math expression ABC with an overbar](powerpoint-math-equations_14.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 100);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $overbar = (new MathematicalText("ABC"))->overbar();

    $mathParagraph->add(new MathBlock($overbar));

    $presentation->save("overbar.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **빠른 참조**

| 작업 | 주요 API |
| --- | --- |
| 수학 텍스트 만들기 | [MathematicalText](https://reference.aspose.com/slides/ko/php-java/aspose.slides/mathematicaltext/) |
| 요소 결합 | [join](https://reference.aspose.com/slides/ko/php-java/aspose.slides/mathelementbase/) |
| 분수 만들기 | [divide](https://reference.aspose.com/slides/ko/php-java/aspose.slides/mathelementbase/) |
| 위첨자 또는 아래첨자 추가 | [setSuperscript](https://reference.aspose.com/slides/ko/php-java/aspose.slides/mathelementbase/),[setSubscript](https://reference.aspose.com/slides/ko/php-java/aspose.slides/mathelementbase/) |
| 함수 추가 | [function](https://reference.aspose.com/slides/ko/php-java/aspose.slides/mathelementbase/),[asArgumentOfFunction](https://reference.aspose.com/slides/ko/php-java/aspose.slides/mathelementbase/) |
| 근호 추가 | [radical](https://reference.aspose.com/slides/ko/php-java/aspose.slides/mathelementbase/) |
| 극한 추가 | [setLowerLimit](https://reference.aspose.com/slides/ko/php-java/aspose.slides/mathelementbase/),[setUpperLimit](https://reference.aspose.com/slides/ko/php-java/aspose.slides/mathelementbase/) |
| 왼쪽 스크립트 추가 | [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/ko/php-java/aspose.slides/mathelementbase/) |
| 합계와 적분 추가 | [nary](https://reference.aspose.com/slides/ko/php-java/aspose.slides/mathelementbase/),[integral](https://reference.aspose.com/slides/ko/php-java/aspose.slides/mathelementbase/) |
| 행렬 추가 | [MathMatrix](https://reference.aspose.com/slides/ko/php-java/aspose.slides/mathmatrix/) |
| 수식 배열 추가 | [toMathArray](https://reference.aspose.com/slides/ko/php-java/aspose.slides/mathelementbase/) |
| 구분자 추가 | [enclose](https://reference.aspose.com/slides/ko/php-java/aspose.slides/mathelementbase/) |
| 바와 테두리 추가 | [overbar](https://reference.aspose.com/slides/ko/php-java/aspose.slides/mathelementbase/),[toBorderBox](https://reference.aspose.com/slides/ko/php-java/aspose.slides/mathelementbase/) |
| 용어 그룹화 | [group](https://reference.aspose.com/slides/ko/php-java/aspose.slides/mathelementbase/) |

## **FAQ**

**기존 PowerPoint 수식을 편집할 수 있나요?**

예. 프레젠테이션을 열고 `MathPortion`을 포함하는 도형을 찾은 뒤 해당 도형의 `MathParagraph`를 얻어 해당 단락의 수학 블록을 업데이트하면 됩니다.

**수식이 편집 가능한 PowerPoint 수학으로 저장되나요?**

예. PPTX로 저장하면 Aspose.Slides는 수식을 편집 가능한 Office 수학 콘텐츠로 기록합니다.

**수식을 LaTeX로 내보낼 수 있나요?**

예. 해당 수식의 [MathParagraph](https://reference.aspose.com/slides/ko/php-java/aspose.slides/mathparagraph/)를 그 수식의 [MathPortion](https://reference.aspose.com/slides/ko/php-java/aspose.slides/mathportion/)에서 가져와 [MathParagraph::toLatex](https://reference.aspose.com/slides/ko/php-java/aspose.slides/mathparagraph/#toLatex)를 호출하면 직접 내보낼 수 있습니다. 전체 예제는 [Export Math Equations from Presentations in PHP via Java](/slides/ko/php-java/exporting-math-equations/#export-math-equations-to-latex)를 참고하십시오.
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
description: "Aspose.Slides for PHP via Java를 사용하여 PowerPoint PPT 및 PPTX에서 수학 방정식을 삽입하고 편집하며, OMML 지원, 서식 제어 및 명확한 PHP 코드 샘플을 제공합니다."
---
## **개요**

PowerPoint는 수식을 Office Math Markup Language(OMML) 형식으로 저장합니다. Aspose.Slides for PHP via Java를 사용하면 프로그래밍 방식으로 동일한 유형의 수학 콘텐츠를 만들 수 있습니다: 분수, 근호, 함수, 극한, N-ary 연산자, 행렬, 배열 및 서식이 지정된 수학 블록.

PowerPoint에서 사용자는 일반적으로 **삽입 > 수식**에서 수식을 추가합니다:

![PowerPoint 삽입 탭에서 수식 명령이 선택된 모습](powerpoint-math-equations_1.png)

그 결과 슬라이드에 편집 가능한 수식 텍스트가 표시됩니다:

![편집 가능한 수식이 포함된 PowerPoint 슬라이드](powerpoint-math-equations_2.png)

Aspose.Slides는 세 가지 주요 객체를 통해 해당 수식 텍스트를 구성합니다:

- 수식 모양은 [addMathShape](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addMathShape)으로 생성되며, 수식을 포함하는 도형입니다.
- [MathPortion](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/)은 도형 텍스트 프레임 내부에 수식 콘텐츠를 저장합니다.
- [MathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathparagraph/)은 하나 이상의 [MathBlock](https://reference.aspose.com/slides/php-java/aspose.slides/mathblock/) 객체를 포함합니다.

아래 대부분의 예제는 코드를 간결하고 읽기 쉽도록 [MathematicalText](https://reference.aspose.com/slides/php-java/aspose.slides/mathematicaltext/)와 [MathElementBase](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/)의 유창한 메서드를 사용합니다.

MathML 내보내기 시나리오에 대해서는 [Export Math Equations from Presentations in PHP via Java](/slides/ko/php-java/exporting-math-equations/)를 참조하십시오.

## **수식 만들기**

이 예제는 [addMathShape](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addMathShape)을 사용하여 수식 모양을 만들고 피타고라스 정리를 추가합니다:

![c 제곱이 a 제곱 플러스 b 제곱과 같은 방정식](powerpoint-math-equations_3.png)

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

{{% alert color="info" title="Note" %}}
[addMathShape](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addMathShape)은 이미 수식 단락을 포함하는 도형을 생성합니다. 첫 번째 [MathPortion](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/)에 접근하고, [getMathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/#getMathParagraph)를 호출한 뒤, 수식 블록이나 수식 요소를 추가합니다.
{{% /alert %}}

## **분수 추가**

[divide](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#divide)을 사용하여 분수를 만듭니다. [MathFractionTypes](https://reference.aspose.com/slides/php-java/aspose.slides/mathfractiontypes/)로 분수 스타일을 선택할 수 있습니다.

![x 로 나누어진 한 항을 보여주는 기울어진 분수](powerpoint-math-equations_4.png)

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

스토크된 분수를 위해서는 [MathFractionTypes::Bar](https://reference.aspose.com/slides/php-java/aspose.slides/mathfractiontypes/#Bar)을 사용합니다:

```php
$stackedFraction = (new MathematicalText("x + 1"))->divide("y - 1", MathFractionTypes::Bar);
```

## **근호 추가**

[radical](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#radical)을 사용하여 제곱근, 세제곱근 또는 기타 루트를 생성합니다. 현재 요소가 밑이 되고, 인수가 차수가 됩니다.

![근호 안에 x가 있는 n 제곱근 표현식](powerpoint-math-equations_5.png)

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

## **함수 및 극한 추가**

[asArgumentOfFunction](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#asArgumentOfFunction) 또는 [function](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#function)을 사용하여 `sin(x)`, `log(x)`와 같은 함수 또는 사용자 정의 함수 이름을 지정합니다. 극한의 경우, `lim`을 [MathLimit](https://reference.aspose.com/slides/php-java/aspose.slides/mathlimit/)에 넣거나 [setLowerLimit](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#setLowerLimit)를 사용합니다.

![x가 무한대로 접근할 때의 극한](powerpoint-math-equations_8.png)

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

사용자 정의 함수 이름의 경우, 함수 이름을 현재 요소로 만들고 해당 인수와 함께 [function](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#function)을 호출합니다:

```php
$customFunction = (new MathematicalText("f"))->function("x + 1");
```

## **N-ary 연산자 및 적분 추가**

합계, 합집합, 교집합 및 기타 큰 연산자에는 [nary](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#nary)를 사용합니다. 적분에는 [integral](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#integral)를 사용합니다. 두 메서드 모두 하한 및 상한을 설정할 수 있습니다.

![하한 및 상한이 있는 합계 연산](powerpoint-math-equations_7.png)

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

N-ary 연산자는 옵션 한계가 있는 큰 연산자를 위한 것입니다. `+`, `-`, `=`와 같은 단순 연산자는 일반적으로 [MathematicalText](https://reference.aspose.com/slides/php-java/aspose.slides/mathematicaltext/)로 추가되어 표현식에 결합됩니다.

적분의 경우, [integral](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#integral)을 사용합니다:

```php
$integralBase = (new MathematicalText("x"))->join((new MathematicalText("dx"))->toBox());
$integral = $integralBase->integral(MathIntegralTypes::Simple, "0", "1");
```

## **행렬 추가**

[MathMatrix](https://reference.aspose.com/slides/php-java/aspose.slides/mathmatrix/)을 사용하여 행과 열을 정의합니다. 행렬은 기본적으로 괄호가 포함되지 않으므로 괄호, 대괄호 또는 중괄호가 필요할 경우 행렬을 둘러싸야 합니다.

![한 개의 빈 셀을 포함한 두 행 수학 행렬](powerpoint-math-equations_10.png)

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

정렬된 수식이나 수식들을 수직으로 쌓아야 할 경우 [toMathArray](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#toMathArray)를 사용합니다.

![x가 y 위에 있는 수직 수식 배열](powerpoint-math-equations_11.png)

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

## **삼각 함수 추가**

인수가 현재 요소이고 함수 이름이 알려진 경우 [asArgumentOfFunction](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#asArgumentOfFunction)를 사용합니다.

![2x에 적용된 삼각 함수 cos](powerpoint-math-equations_6.png)

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

## **첨자 및 위첨자 추가**

첨자와 위첨자 도우미를 사용하여 인덱스와 거듭 제곱을 지정합니다. 인덱스를 기준 요소의 왼쪽에 표시해야 할 경우 [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#setSubSuperscriptOnTheLeft)를 사용합니다.

![왼쪽에 첨자 1과 위첨자 n이 있는 대문자 Y](powerpoint-math-equations_9.png)

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

[enclose](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#enclose)를 사용하여 표현식을 구분자 안에 넣습니다. 여러 요소가 포함된 구분자 표현식의 경우 구분 문자도 설정할 수 있습니다.

![x, y, z를 수직 막대로 구분한 구분자 표현식](powerpoint-math-equations_13.png)

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

### **구분자 크기 및 정렬**

`true`를 [setGrowToMatchOperandHeight](https://reference.aspose.com/slides/php-java/aspose.slides/mathdelimiter/#setGrowToMatchOperandHeight)에 전달하면 큰 피연산자를 둘러싸도록 괄호가 늘어납니다. `false`를 전달하면 정상 크기를 유지합니다. 두 가지 [MathDelimiterShape](https://reference.aspose.com/slides/php-java/aspose.slides/mathdelimitershape/) 값 중 하나와 함께 [setDelimiterShape](https://reference.aspose.com/slides/php-java/aspose.slides/mathdelimiter/#setDelimiterShape)을 사용합니다. `Centered`는 괄호를 등식 기호 가운데를 통과하는 수학 축에 중앙에 배치하고, `Match`는 포함된 내용에 맞춰 정렬합니다. 두 설정은 구분자에만 영향을 미치며, 내부 표현식은 변경되지 않습니다.

예제에서는 `x`의 지수에 분수를 배치하여 표현식이 기준선 위쪽으로 더 많이 확장되도록 합니다. 네 개의 수식 모두 동일한 괄호와 글꼴 설정을 사용합니다.

```php
use aspose\slides\MathDelimiterShape;
use aspose\slides\MathematicalText;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $opening = new Java("java.lang.Character", "(");
    $closing = new Java("java.lang.Character", ")");
    for ($row = 0; $row < 2; $row++) {
        for ($column = 0; $column < 2; $column++) {
            $fraction = (new MathematicalText("a + b"))->divide("c + d");
            $power = (new MathematicalText("x"))->setSuperscript($fraction);
            $delimiter = $power->enclose($opening, $closing);
            $delimiter->setGrowToMatchOperandHeight($row === 0);
            $delimiter->setDelimiterShape($column === 0 ? MathDelimiterShape::Centered : MathDelimiterShape::Match);

            $mathShape = $slide->getShapes()->addMathShape(20 + 330 * $column, 20 + 120 * $row, 300, 100);
            $portion = $mathShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
            $portion->getPortionFormat()->setFontHeight(32);
            $equation = (new MathematicalText("y = "))->join($delimiter);
            $portion->getMathParagraph()->add($equation);
        }
    }
    $presentation->save("delimiter-sizing.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

PowerPoint에서 행을 비교하면 성장 효과를 확인할 수 있습니다. 상단 행에서는 괄호가 지수를 둘러싸도록 성장하여 두 도형 모두 동일하게 보입니다. 하단 행에서는 성장이 비활성화됩니다. 왼쪽의 작은 괄호(`Centered`)는 등호와 정렬되고, 오른쪽의 괄호(`Match`)는 표현식 위쪽에 더 높게 배치됩니다.

![PowerPoint에서 구분자 성장이 위쪽에 활성화되고 아래쪽에 비활성화된 네 개 수식, 왼쪽은 Centered, 오른쪽은 Match](delimiter-sizing.png)

## **테두리 상자 추가**

분수에 [toBorderBox](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#toBorderBox)를 호출하면 전체 표현식을 둘러싼 테두리를 만들 수 있습니다. 반환된 [MathBorderBox](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/)는 기본적으로 네 면을 모두 표시합니다. [setHideTop](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setHideTop), [setHideBottom](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setHideBottom), [setHideLeft](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setHideLeft), [setHideRight](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setHideRight)를 사용하여 개별 면을 제거합니다.

예제에서는 동일한 분수를 한 슬라이드에 여섯 번 복제합니다. 취소 표시를 위해 네 면을 모두 숨기고 [setStrikethroughBottomLeftToTopRight](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setStrikethroughBottomLeftToTopRight)에 `true`를 전달하면 상승 대각선(↗)이, [setStrikethroughTopLeftToBottomRight](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setStrikethroughTopLeftToBottomRight)에 `true`를 전달하면 하강 대각선(↘)이 표시됩니다. 또한 [setStrikethroughHorizontal](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setStrikethroughHorizontal)이나 [setStrikethroughVertical](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setStrikethroughVertical)를 사용하여 보이는 면 조합에 따라 적용할 수 있습니다.

```php
use aspose\slides\MathBlock;
use aspose\slides\MathematicalText;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideSizeScaleType;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(540, 220, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);

    $addFraction = function ($x, $y, $hideBorder) use ($slide) {
        $fraction = (new MathematicalText("x+1"))->divide("y+2");
        $box = $fraction->toBorderBox();
        $box->setHideTop($hideBorder);
        $box->setHideBottom($hideBorder);
        $box->setHideLeft($hideBorder);
        $box->setHideRight($hideBorder);

        $shape = $slide->getShapes()->addMathShape($x, $y, 160, 90);
        $portion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
        $portion->getPortionFormat()->setFontHeight(28);
        $mathBlock = new MathBlock($box);
        $portion->getMathParagraph()->add($mathBlock);
        return $box;
    };

    $addFraction(10, 10, false);

    $partial = $addFraction(190, 10, false);
    $partial->setHideTop(true);
    $partial->setHideRight(true);

    $addFraction(370, 10, true)->setStrikethroughBottomLeftToTopRight(true);
    $addFraction(10, 120, true)->setStrikethroughTopLeftToBottomRight(true);
    $addFraction(190, 120, true)->setStrikethroughHorizontal(true);
    $addFraction(370, 120, false)->setStrikethroughVertical(true);

    $presentation->save("border-box.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![PowerPoint에서 편집 가능한 여섯 개의 분수. 상단 행: 전체 테두리, 하단 및 좌측 면, 상승 대각선. 하단 행: 하강 대각선, 수평 횡줄, 수직 횡줄 및 전체 테두리.](border-box-fractions.png)

이 분수에서는 수평 횡줄이 분수선과 겹칩니다. 수직 횡줄은 분자와 분모를 모두 가로지르면서 주변 테두리는 보입니다. 이러한 선은 전체 표현식을 장식합니다. 일반 텍스트의 취소선은 텍스트 실행의 문자에 적용됩니다. PowerPoint에서 프레젠테이션을 다시 열어도 분자와 분모를 독립적으로 편집할 수 있습니다.

## **항목 그룹화**

[group](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#group)을 사용하여 표현식 위나 아래에 그룹화 문자를 배치합니다. 그룹화된 항목에 라벨을 달려면 한계를 추가합니다.

![x와 y가 그룹화되고 아래에 'any text' 라벨이 있는 표현식](powerpoint-math-equations_15.png)

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

## **수식 요소 서식 지정**

수식이 명확해지는 경우에만 서식 도우미를 사용합니다. 예를 들어, [overbar](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#overbar)는 수식 요소 위에 바를 놓습니다.

![위에 바가 있는 수식 표현식 ABC](powerpoint-math-equations_14.png)

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

### **기존 수식의 텍스트 서식 지정**

기존 수식 전체의 텍스트 서식을 지정하려면 각 수식 블록의 요소 트리를 순회합니다. [MathElementBase::getChildren](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#getChildren)는 직접적인 자식만 반환하므로, 분수, 첨자/위첨자, 근호 및 기타 중첩 구조 내부의 텍스트에 도달하려면 재귀적으로 호출합니다. 현재 요소와 그 자식들을 확인하여 시작 요소가 [MathematicalText](https://reference.aspose.com/slides/php-java/aspose.slides/mathematicaltext/)인 경우에도 포함합니다.

이 예제는 `input.pptx`에 `z = xᵢ / ∛y`와 같은 수식이 포함되어 있다고 가정합니다. 이 수식은 분자에 첨자가, 분모에 근호가 있는 분수를 포함합니다. 블록의 최상위 요소만 처리하면 분수 내부 텍스트를 놓치게 됩니다. 예제는 슬라이드 텍스트 프레임에서 수학 부분을 찾아 [MathPortion::getMathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/#getMathParagraph)를 통해 블록에 접근하고, 각 텍스트 요소의 [getFormat](https://reference.aspose.com/slides/php-java/aspose.slides/mathematicaltext/#getFormat) 메서드를 사용하여 [setFontHeight](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight)를 호출해 글꼴 크기를 28포인트로 설정합니다.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

function formatMathText($element, $mathematicalTextClass) {
    if (java_instanceof($element, $mathematicalTextClass)) {
        $element->getFormat()->setFontHeight(28);
    }

    foreach ($element->getChildren() as $child) {
        formatMathText($child, $mathematicalTextClass);
    }
}

$mathematicalTextClass = new JavaClass("com.aspose.slides.MathematicalText");
$autoShapeClass = new JavaClass("com.aspose.slides.IAutoShape");
$mathPortionClass = new JavaClass("com.aspose.slides.IMathPortion");

$presentation = new Presentation("input.pptx");
try {
    for ($slideIndex = 0; $slideIndex < java_values($presentation->getSlides()->size()); $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        for ($shapeIndex = 0; $shapeIndex < java_values($slide->getShapes()->size()); $shapeIndex++) {
            $shape = $slide->getShapes()->get_Item($shapeIndex);
            if (!java_instanceof($shape, $autoShapeClass)) {
                continue;
            }

            $textFrame = $shape->getTextFrame();
            if (java_is_null($textFrame)) {
                continue;
            }

            for ($paragraphIndex = 0; $paragraphIndex < java_values($textFrame->getParagraphs()->getCount()); $paragraphIndex++) {
                $paragraph = $textFrame->getParagraphs()->get_Item($paragraphIndex);
                for ($portionIndex = 0; $portionIndex < java_values($paragraph->getPortions()->getCount()); $portionIndex++) {
                    $portion = $paragraph->getPortions()->get_Item($portionIndex);
                    if (java_instanceof($portion, $mathPortionClass)) {
                        for ($blockIndex = 0; $blockIndex < java_values($portion->getMathParagraph()->getCount()); $blockIndex++) {
                            $block = $portion->getMathParagraph()->get_Item($blockIndex);
                            formatMathText($block, $mathematicalTextClass);
                        }
                    }
                }
            }
        }
    }

    $presentation->save("formatted-equations.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

저장된 프레젠테이션은 처리된 각 수식의 모든 수준에서 업데이트된 텍스트 서식을 포함하며, 텍스트 내용과 수학 구조는 그대로 유지됩니다.

## **빠른 참고**

| 작업 | 주요 API |
| --- | --- |
| 수식 텍스트 만들기 | [MathematicalText](https://reference.aspose.com/slides/php-java/aspose.slides/mathematicaltext/) |
| 요소 결합 | [join](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| 분수 만들기 | [divide](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| 위첨자 또는 아래첨자 추가 | [setSuperscript](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/), [setSubscript](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| 함수 추가 | [function](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/), [asArgumentOfFunction](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| 근호 추가 | [radical](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| 극한 추가 | [setLowerLimit](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/), [setUpperLimit](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| 좌측 첨자/위첨자 추가 | [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| 합계 및 적분 추가 | [nary](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/), [integral](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| 행렬 추가 | [MathMatrix](https://reference.aspose.com/slides/php-java/aspose.slides/mathmatrix/) |
| 수식 배열 추가 | [toMathArray](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| 구분자 추가 | [enclose](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| 바와 테두리 추가 | [overbar](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/), [toBorderBox](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| 항목 그룹화 | [group](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |

## **FAQ**

**기존 PowerPoint 수식을 편집할 수 있나요?**

예. 프레젠테이션을 열고, [MathPortion](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/)을 포함하는 도형을 찾은 다음, [getMathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/#getMathParagraph)를 호출하고 해당 단락의 수식 블록을 업데이트합니다.

**수식이 편집 가능한 PowerPoint 수학으로 저장되나요?**

예. PPTX로 저장하면 Aspose.Slides가 수식을 편집 가능한 Office 수학 콘텐츠로 기록합니다.

**수식을 LaTeX로 내보낼 수 있나요?**

예. [MathPortion](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/)에서 수식의 [MathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathparagraph/)을 가져와 [MathParagraph::toLatex](https://reference.aspose.com/slides/php-java/aspose.slides/mathparagraph/#toLatex)를 호출하면 직접 내보낼 수 있습니다. 완전한 예제는 [Export Math Equations from Presentations in PHP via Java](/slides/ko/php-java/exporting-math-equations/#export-math-equations-to-latex)를 참조하십시오.
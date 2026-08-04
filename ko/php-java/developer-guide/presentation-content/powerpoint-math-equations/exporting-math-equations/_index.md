---
title: 프레젠테이션에서 PHP로 수식 내보내기
linktitle: 수식 내보내기
type: docs
weight: 30
url: /ko/php-java/exporting-math-equations/
keywords:
- 수식 내보내기
- LaTeX로 수식 내보내기
- PowerPoint를 LaTeX로
- MathML
- LaTeX
- PowerPoint
- 프레젠테이션
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java를 사용하여 PowerPoint 프레젠테이션에서 수식 방정식을 직접 LaTeX 또는 MathML로 내보냅니다."
---
## **Introduction**

Aspose.Slides for PHP via Java은 프레젠테이션에서 수식 방정식을 내보낼 수 있게 해줍니다. 예를 들어, 특정 프레젠테이션의 슬라이드에 있는 수학 방정식을 추출하여 다른 프로그램이나 플랫폼에서 사용할 수 있습니다.

{{% alert color="primary" %}} 

수식을 LaTeX 또는 웹 및 다양한 응용 프로그램에서 사용되는 인기 있는 수학 콘텐츠 표준인 MathML로 직접 내보낼 수 있습니다.

{{% /alert %}}

## **LaTeX로 수식 방정식 내보내기**

Aspose.Slides는 PowerPoint 수식 방정식을 직접 LaTeX로 변환할 수 있으며, 중간 MathML 파일이나 외부 변환기가 필요하지 않습니다. 수식 방정식은 텍스트 프레임에 [MathPortion](https://reference.aspose.com/slides/ko/php-java/aspose.slides/mathportion/) 형태로 저장됩니다. [MathPortion::getMathParagraph](https://reference.aspose.com/slides/ko/php-java/aspose.slides/mathportion/#getMathParagraph)을 사용하여 [MathParagraph](https://reference.aspose.com/slides/ko/php-java/aspose.slides/mathparagraph/)를 가져온 다음, [MathParagraph::toLatex](https://reference.aspose.com/slides/ko/php-java/aspose.slides/mathparagraph/#toLatex)를 호출합니다. 이 메서드는 문자열을 반환하며, 이를 저장하거나, 표시하거나, 다른 애플리케이션에 보내거나, 추가로 처리할 수 있습니다.

다음 예제는 모든 슬라이드의 모든 텍스트 프레임을 검사하여 모든 수식 부분을 찾고, 각 방정식을 별도의 `.tex` 파일에 기록합니다:

```php
$presentation = new Presentation("equations.pptx");
$arrayClass = new JavaClass("java.lang.reflect.Array");
$mathPortionClass = new JavaClass("com.aspose.slides.MathPortion");

try {
    $slideCount = java_values($presentation->getSlides()->size());
    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $slideNumber = $slideIndex + 1;
        $equationNumber = 1;
        $textFrames = SlideUtil::getAllTextBoxes($slide);
        $textFrameCount = java_values($arrayClass->getLength($textFrames));

        for ($textFrameIndex = 0; $textFrameIndex < $textFrameCount; $textFrameIndex++) {
            $textFrame = $textFrames[$textFrameIndex];
            $paragraphCount = java_values($textFrame->getParagraphs()->getCount());
            for ($paragraphIndex = 0; $paragraphIndex < $paragraphCount; $paragraphIndex++) {
                $paragraph = $textFrame->getParagraphs()->get_Item($paragraphIndex);
                $portionCount = java_values($paragraph->getPortions()->getCount());
                for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
                    $portion = $paragraph->getPortions()->get_Item($portionIndex);
                    if (!java_instanceof($portion, $mathPortionClass)) {
                        continue;
                    }

                    $mathParagraph = $portion->getMathParagraph();
                    $latexFileName = "slide_" . $slideNumber . "_equation_" . $equationNumber . ".tex";

                    $latexText = java_values($mathParagraph->toLatex());
                    file_put_contents($latexFileName, $latexText);
                    $equationNumber++;
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

[SlideUtil::getAllTextBoxes](https://reference.aspose.com/slides/ko/php-java/aspose.slides/slideutil/#getAllTextBoxes)은 슬라이드에서 찾은 모든 텍스트 프레임을 반환합니다. [MathPortion](https://reference.aspose.com/slides/ko/php-java/aspose.slides/mathportion/) 유형 검사는 일반 텍스트와 이미지와 구분되는 실제 편집 가능한 수식을 분리합니다.

LaTeX 엔진 및 문서 템플릿은 모두 동일한 명령, 패키지 또는 유니코드 문자를 지원하지 않습니다. 반환된 문자열을 애플리케이션에서 사용하는 LaTeX 엔진으로 테스트하십시오. 해당 환경에서 기호나 Office Math 요소에 적절한 표현이 없을 경우, 반환된 문자열에서 프로젝트 고유 명령으로 교체하거나 방정식을 건너뛰고 문제를 기록하여 검토하십시오.

## **MathML로 수식 방정식 저장**

LaTeX와 같은 일부 방정식 형식의 코드는 사람이 쉽게 작성할 수 있지만, MathML의 코드는 자동으로 애플리케이션에 의해 생성되도록 설계되었기 때문에 작성하기 어렵습니다. MathML은 코드가 XML 형태이므로 프로그램이 쉽게 읽고 구문 분석할 수 있어, 많은 분야에서 출력 및 인쇄 형식으로 널리 사용됩니다.

다음 샘플 코드는 프레젠테이션에서 MathML로 수식 방정식을 내보내는 방법을 보여줍니다:

```php
  $pres = new Presentation();
  try {
    $autoShape = $pres->getSlides()->get_Item(0)->getShapes()->addMathShape(0, 0, 500, 50);
    $mathParagraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();
    $mathParagraph->add(new MathematicalText("a")->setSuperscript("2")->join("+")->join(new MathematicalText("b")->setSuperscript("2"))->join("=")->join(new MathematicalText("c")->setSuperscript("2")));
    $stream = new Java("java.io.FileOutputStream", "mathml.xml");
    $mathParagraph->writeAsMathMl($stream);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**MathML로 정확히 무엇이 내보내지나요—전체 단락인가 개별 수식 블록인가?**

전체 수식 단락([MathParagraph](https://reference.aspose.com/slides/ko/php-java/aspose.slides/mathparagraph/))이든 개별 블록([MathBlock](https://reference.aspose.com/slides/ko/php-java/aspose.slides/mathblock/))이든 MathML로 내보낼 수 있습니다. 두 유형 모두 MathML로 기록하는 메서드를 제공합니다.

**슬라이드의 객체가 일반 텍스트나 이미지가 아니라 수식임을 어떻게 판단할 수 있나요?**

수식은 [MathPortion](https://reference.aspose.com/slides/ko/php-java/aspose.slides/mathportion/)에 존재하며 [MathParagraph](https://reference.aspose.com/slides/ko/php-java/aspose.slides/mathparagraph/)를 가지고 있습니다. [MathParagraph](https://reference.aspose.com/slides/ko/php-java/aspose.slides/mathparagraph/)가 없는 이미지와 일반 텍스트 부분은 내보낼 수 있는 수식이 아닙니다.

**프레젠테이션의 MathML은 어디서 온 것인가요—PowerPoint 전용인가요, 아니면 표준인가요?**

내보내기는 표준 MathML(XML)을 대상으로 합니다. Aspose는 프레젠테이션 MathML—표준의 프레젠테이션 하위 집합—을 사용하며, 이는 다양한 애플리케이션과 웹에서 널리 사용됩니다.

**표, SmartArt, 그룹 등 내부의 수식을 내보내는 것이 지원되나요?**

예, 해당 객체에 [MathParagraph](https://reference.aspose.com/slides/ko/php-java/aspose.slides/mathparagraph/)가 포함된 텍스트 부분(즉, 실제 PowerPoint 수식)이 있으면 내보내집니다. 수식이 이미지로 삽입된 경우는 내보내지 않습니다.

**MathML로 내보내면 원본 프레젠테이션이 수정되나요?**

아니요. MathML을 기록하는 것은 수식 내용을 직렬화하는 것이며, 프레젠테이션 파일을 수정하지 않습니다.
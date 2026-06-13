---
title: PHP에서 프레젠테이션의 수학 방정식 내보내기
linktitle: 방정식 내보내기
type: docs
weight: 30
url: /ko/php-java/exporting-math-equations/
keywords:
- 수학 방정식 내보내기
- MathML
- LaTeX
- PowerPoint
- 프레젠테이션
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java를 사용하여 PowerPoint에서 MathML로 수학 방정식을 원활하게 내보내고, 서식을 유지하며 호환성을 향상시킵니다."
---
## **소개**

Aspose.Slides for PHP via Java를 사용하면 프레젠테이션에서 수학 방정식을 내보낼 수 있습니다. 예를 들어, 특정 프레젠테이션의 슬라이드에 있는 수학 방정식을 추출하여 다른 프로그램이나 플랫폼에서 사용할 수 있습니다.

{{% alert color="primary" %}} 
수학 방정식을 MathML로 내보낼 수 있습니다. MathML은 웹 및 다양한 애플리케이션에서 볼 수 있는 수학 방정식 및 유사 콘텐츠를 위한 널리 사용되는 형식 및 표준입니다.
{{% /alert %}}

## **수학 방정식을 MathML로 저장**

사용자는 LaTeX와 같은 일부 방정식 형식에 대한 코드를 쉽게 작성할 수 있지만, MathML 코드는 앱에 의해 자동으로 생성되도록 설계되어 작성하기 어렵습니다. 프로그램은 MathML이 XML 형식이므로 쉽게 읽고 구문 분석할 수 있어, MathML은 많은 분야에서 출력 및 인쇄 형식으로 일반적으로 사용됩니다.

다음 샘플 코드는 프레젠테이션에서 수학 방정식을 MathML로 내보내는 방법을 보여줍니다:
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

## **자주 묻는 질문**

**MathML로 정확히 무엇이 내보내어지나요—문단 전체인가요 아니면 개별 수식 블록인가요?**

MathML로 전체 수학 문단([MathParagraph](https://reference.aspose.com/slides/ko/php-java/aspose.slides/mathparagraph/)) 또는 개별 블록([MathBlock](https://reference.aspose.com/slides/ko/php-java/aspose.slides/mathblock/)) 중 하나를 내보낼 수 있습니다. 두 타입 모두 MathML로 기록하는 메서드를 제공합니다.

**슬라이드에서 객체가 일반 텍스트나 이미지가 아니라 수학 수식인지 어떻게 알 수 있나요?**

수식은 [MathPortion](https://reference.aspose.com/slides/ko/php-java/aspose.slides/mathportion/)에 존재하며 [MathParagraph](https://reference.aspose.com/slides/ko/php-java/aspose.slides/mathparagraph/)를 가집니다. [MathParagraph](https://reference.aspose.com/slides/ko/php-java/aspose.slides/mathparagraph/)가 없는 이미지 및 일반 텍스트 부분은 내보낼 수 있는 수식이 아닙니다.

**프레젠테이션에서 MathML은 어디서 오는 건가요—PowerPoint 전용인가요 아니면 표준인가요?**

내보내기는 표준 MathML(XML)을 대상으로 합니다. Aspose는 표준의 프레젠테이션 하위 집합인 Presentation MathML을 사용하며, 이는 애플리케이션 및 웹 전반에서 널리 사용됩니다.

**테이블, SmartArt, 그룹 등 내부의 수식 내보내기가 지원되나요?**

예, 해당 객체에 [MathParagraph](https://reference.aspose.com/slides/ko/php-java/aspose.slides/mathparagraph/)가 포함된 텍스트 부분이 있으면(즉, 실제 PowerPoint 수식) 내보내집니다. 수식이 이미지로 삽입된 경우는 내보내지 않습니다.

**MathML로 내보내면 원본 프레젠테이션이 변경되나요?**

아니요. MathML을 쓰는 것은 수식 내용의 직렬화이며, 프레젠테이션 파일을 변경하지 않습니다.
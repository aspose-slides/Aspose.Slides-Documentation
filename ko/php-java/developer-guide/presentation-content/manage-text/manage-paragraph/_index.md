---
title: PHP에서 PowerPoint 텍스트 단락 관리
linktitle: 단락 관리
type: docs
weight: 40
url: /ko/php-java/manage-paragraph/
aliases:
  - /php-java/paragraph/
  - /php-java/portion/
keywords:
- 텍스트 추가
- 단락 추가
- 텍스트 관리
- 단락 관리
- 글머리표 관리
- 단락 들여쓰기
- 걸이 들여쓰기
- 단락 글머리표
- 번호 매기기 목록
- 글머리표 목록
- 단락 속성
- HTML 가져오기
- 텍스트를 HTML로
- 단락을 HTML로
- 단락을 이미지로
- 텍스트를 이미지로
- 단락 내보내기
- PowerPoint
- 프레젠테이션
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java를 사용하여 단락, 구절, 글머리표, 번호 매기기 목록, 들여쓰기, HTML 콘텐츠 및 단락 이미지를 생성하고 서식 지정하는 방법을 배웁니다."
---
## **개요**

Aspose.Slides for PHP via Java는 텍스트를 텍스트 프레임, 단락 및 구절의 계층 구조로 나타냅니다:

* [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/)은 도형 안의 텍스트 컨테이너를 나타내며 단락 컬렉션에 접근할 수 있게 합니다.
* [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/)은 텍스트 프레임 안의 하나의 단락을 나타내며 구절 및 단락 수준 형식에 접근할 수 있게 합니다.
* [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/portion/)은 단락 내의 텍스트 실행을 나타냅니다. 각 구절은 자체 텍스트와 문자 수준 형식을 가질 수 있습니다.

따라서 단락은 여러 구절을 사용하여 서로 다른 글꼴, 색상, 크기 및 기타 형식을 가진 텍스트를 포함할 수 있습니다.

## **단락 만들기 및 서식 지정**

도형의 텍스트 프레임에서 단락을 만들고 구절을 사용하여 개별 텍스트 실행을 서식 지정합니다. 이 섹션에서는 각 단락에 여러 구절을 결합하고 서로 다른 색상, 글꼴 크기 및 스타일을 적용하는 방법을 보여줍니다.

### **여러 구절이 있는 단락 만들기**

다음 PHP 예제는 [Paragraph::getPortions](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getPortions)에서 반환된 컬렉션에 세 개의 텍스트 실행을 포함하는 세 개의 단락을 생성합니다. 기본 단락과 빈 구절을 재사용한 뒤 나머지 단락과 구절을 추가합니다. 서식은 [Portion::getPortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/portion/#getPortionFormat)를 통해 적용됩니다: 각 단락의 첫 번째 구절은 빨간색, 굵게, 15포인트; 두 번째는 파란색, 기울임꼴, 18포인트. 세 번째 구절은 기본 서식을 유지합니다:

```php
use aspose\slides\FillType;
use aspose\slides\NullableBool;
use aspose\slides\Paragraph;
use aspose\slides\Portion;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 300, 150);
    $textFrame = $shape->getTextFrame();

    $firstParagraph = $textFrame->getParagraphs()->get_Item(0);
    $firstParagraph->getPortions()->add(new Portion());
    $firstParagraph->getPortions()->add(new Portion());

    $secondParagraph = new Paragraph();
    $secondParagraph->getPortions()->add(new Portion());
    $secondParagraph->getPortions()->add(new Portion());
    $secondParagraph->getPortions()->add(new Portion());
    $textFrame->getParagraphs()->add($secondParagraph);

    $thirdParagraph = new Paragraph();
    $thirdParagraph->getPortions()->add(new Portion());
    $thirdParagraph->getPortions()->add(new Portion());
    $thirdParagraph->getPortions()->add(new Portion());
    $textFrame->getParagraphs()->add($thirdParagraph);

    $paragraphCount = java_values($textFrame->getParagraphs()->getCount());
    for ($paragraphIndex = 0; $paragraphIndex < $paragraphCount; $paragraphIndex++) {
        $paragraph = $textFrame->getParagraphs()->get_Item($paragraphIndex);
        $portionCount = java_values($paragraph->getPortions()->getCount());
        for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
            $portion = $paragraph->getPortions()->get_Item($portionIndex);
            $portion->setText("Portion " . ($paragraphIndex + 1) . "." . ($portionIndex + 1));

            if ($portionIndex == 0) {
                $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
                $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
                $portion->getPortionFormat()->setFontBold(NullableBool::True);
                $portion->getPortionFormat()->setFontHeight(15);
            } else if ($portionIndex == 1) {
                $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
                $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
                $portion->getPortionFormat()->setFontItalic(NullableBool::True);
                $portion->getPortionFormat()->setFontHeight(18);
            }
        }
    }

    $presentation->save("paragraphs_with_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **글머리표 및 번호 매기기 목록 만들기**

단락 텍스트를 기호, 숫자 또는 사용자 지정 이미지가 있는 목록으로 구성합니다. 이 섹션의 예제는 글머리표 서식, 다중 수준 목록 및 사용자 지정 시작 번호를 다룹니다.

### **글머리표 또는 번호 매기기 목록 만들기**

글머리표와 번호 매기기는 관련 항목을 더 쉽게 스캔할 수 있게 합니다. Aspose.Slides에서 목록 설정은 [BulletFormat](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/)을 통해 정의됩니다.

이 PHP 예제는 동일한 텍스트 프레임에 기호 글머리표와 번호 매기기 항목을 추가합니다. [BulletFormat::setType](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setType)는 글머리표 유형을 선택하고, [BulletFormat::setChar](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setChar)는 기호를 제공하며, [BulletFormat::setNumberedBulletStyle](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setNumberedBulletStyle)는 번호 매기기 스타일을 선택합니다. 두 항목 모두 검은색 글머리표에 높이 100%와 단락 들여쓰기 25포인트를 사용합니다:

```php
use aspose\slides\BulletType;
use aspose\slides\ColorType;
use aspose\slides\NullableBool;
use aspose\slides\NumberedBulletStyle;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    $textFrame = $shape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $symbolParagraph = new Paragraph();
    $symbolParagraph->setText("Welcome to Aspose.Slides");
    $symbolParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $symbolParagraph->getParagraphFormat()->getBullet()->setChar("•");
    $symbolParagraph->getParagraphFormat()->setIndent(25);
    $symbolParagraph->getParagraphFormat()->getBullet()->getColor()->setColorType(ColorType::RGB);
    $symbolParagraph->getParagraphFormat()->getBullet()->getColor()->setColor(java("java.awt.Color")->BLACK);
    $symbolParagraph->getParagraphFormat()->getBullet()->setBulletHardColor(NullableBool::True);
    $symbolParagraph->getParagraphFormat()->getBullet()->setHeight(100);
    $textFrame->getParagraphs()->add($symbolParagraph);

    $numberedParagraph = new Paragraph();
    $numberedParagraph->setText("This is a numbered item");
    $numberedParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $numberedParagraph->getParagraphFormat()->getBullet()->setNumberedBulletStyle(NumberedBulletStyle::BulletCircleNumWDBlackPlain);
    $numberedParagraph->getParagraphFormat()->setIndent(25);
    $numberedParagraph->getParagraphFormat()->getBullet()->getColor()->setColorType(ColorType::RGB);
    $numberedParagraph->getParagraphFormat()->getBullet()->getColor()->setColor(java("java.awt.Color")->BLACK);
    $numberedParagraph->getParagraphFormat()->getBullet()->setBulletHardColor(NullableBool::True);
    $numberedParagraph->getParagraphFormat()->getBullet()->setHeight(100);
    $textFrame->getParagraphs()->add($numberedParagraph);

    $presentation->save("bulleted_and_numbered_list.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **그림 글머리표 사용**

그림 글머리표를 사용하면 기호나 번호 대신 사용자 지정 이미지를 사용할 수 있습니다.

이 PHP 예제는 프레젠테이션의 이미지 컬렉션에 [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/)를 추가하고 이를 단락 글머리표로 사용합니다. [BulletFormat::setType](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setType)를 호출해 그림 글머리표를 사용하도록 하고, [BulletFormat::getPicture](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#getPicture)를 통해 이미지를 할당합니다. [BulletFormat::setHeight](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setHeight)는 글머리표를 단락 텍스트에 상대적으로 크기 지정하기 위해 100%로 설정합니다:

```php
use aspose\slides\BulletType;
use aspose\slides\Images;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $bulletImage = Images::fromFile("bullets.png");
    try {
        $presentationImage = $presentation->getImages()->addImage($bulletImage);
    } finally {
        $bulletImage->dispose();
    }

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    $textFrame = $shape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $paragraph = new Paragraph();
    $paragraph->setText("Welcome to Aspose.Slides");
    $paragraph->getParagraphFormat()->getBullet()->setType(BulletType::Picture);
    $paragraph->getParagraphFormat()->getBullet()->getPicture()->setImage($presentationImage);
    $paragraph->getParagraphFormat()->getBullet()->setHeight(100);
    $textFrame->getParagraphs()->add($paragraph);

    $presentation->save("picture_bullet.pptx", SaveFormat::Pptx);
    $presentation->save("picture_bullet.ppt", SaveFormat::Ppt);
} finally {
    $presentation->dispose();
}
```

### **다중 수준 목록 만들기**

[ParagraphFormat::setDepth](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setDepth)를 설정해 목록의 서로 다른 수준에 단락을 배치합니다. 최상위 수준은 깊이 `0`입니다.

이 PHP 예제는 네 개의 단락에 0부터 3까지의 [ParagraphFormat::setDepth](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setDepth) 값을 할당해 하나의 텍스트 프레임 내에 계층 구조를 만듭니다. 각 단락은 기호 글머리표를 사용하며, [BulletFormat::setChar](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setChar)는 원형 글머리표와 하이픈을 번갈아 사용해 인접 수준을 구분합니다:

```php
use aspose\slides\BulletType;
use aspose\slides\FillType;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    $textFrame = $shape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $firstParagraph = new Paragraph();
    $firstParagraph->setText("Content");
    $firstParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $firstParagraph->getParagraphFormat()->getBullet()->setChar("•");
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $firstParagraph->getParagraphFormat()->setDepth(0);

    $secondParagraph = new Paragraph();
    $secondParagraph->setText("Second level");
    $secondParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $secondParagraph->getParagraphFormat()->getBullet()->setChar('-');
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $secondParagraph->getParagraphFormat()->setDepth(1);

    $thirdParagraph = new Paragraph();
    $thirdParagraph->setText("Third level");
    $thirdParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $thirdParagraph->getParagraphFormat()->getBullet()->setChar("•");
    $thirdParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $thirdParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $thirdParagraph->getParagraphFormat()->setDepth(2);

    $fourthParagraph = new Paragraph();
    $fourthParagraph->setText("Fourth level");
    $fourthParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $fourthParagraph->getParagraphFormat()->getBullet()->setChar('-');
    $fourthParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $fourthParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $fourthParagraph->getParagraphFormat()->setDepth(3);

    $textFrame->getParagraphs()->add($firstParagraph);
    $textFrame->getParagraphs()->add($secondParagraph);
    $textFrame->getParagraphs()->add($thirdParagraph);
    $textFrame->getParagraphs()->add($fourthParagraph);

    $presentation->save("multilevel_list.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **사용자 지정 값으로 번호 매기기 시작**

[BulletFormat::setNumberedBulletStartWith](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setNumberedBulletStartWith)를 사용해 번호 매기기 단락에 표시될 초기 번호를 설정합니다.

이 PHP 예제는 세 개의 단락에 번호 매기기를 사용하도록 [BulletFormat::setType](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setType)를 설정하고, [BulletFormat::setNumberlyBulletStartWith](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setNumberedBulletStartWith) 값을 각각 2, 3, 7로 지정합니다. 시작 값은 각 단락마다 별도로 구성되어 표시 번호가 건너뛰게 됩니다:

```php
use aspose\slides\BulletType;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    $textFrame = $shape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $firstParagraph = new Paragraph();
    $firstParagraph->setText("Start at 2");
    $firstParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $firstParagraph->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(2);
    $textFrame->getParagraphs()->add($firstParagraph);

    $secondParagraph = new Paragraph();
    $secondParagraph->setText("Start at 3");
    $secondParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $secondParagraph->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(3);
    $textFrame->getParagraphs()->add($secondParagraph);

    $thirdParagraph = new Paragraph();
    $thirdParagraph->setText("Start at 7");
    $thirdParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $thirdParagraph->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(7);
    $textFrame->getParagraphs()->add($thirdParagraph);

    $presentation->save("custom_numbered_list.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **단락 레이아웃 및 끝 속성 제어**

단락 여백과 들여쓰기를 조정해 첫 번째 줄과 줄 바꿈된 줄의 위치를 제어합니다. 또한 표시 텍스트 구절과 별도로 단락 끝 표시의 서식을 지정할 수 있습니다.

### **첫 줄 들여쓰기 설정**

[ParagraphFormat::setIndent](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setIndent) 메서드를 사용해 단락의 첫 줄 들여쓰기를 제어합니다. 이 설정은 단락 왼쪽 여백에 대해 첫 번째 줄만 이동합니다. 양수 값은 첫 줄을 오른쪽으로 이동시키고, 나머지 줄은 단락 본문에 맞춰 정렬됩니다.

전체 단락을 이동하려면 [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setMarginLeft)를 사용합니다. 첫 줄만 이동하려면 [ParagraphFormat::setIndent](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setIndent)를 사용합니다.

다음 예제는 세 개의 단락에 동일한 [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setMarginLeft) 20포인트와 [ParagraphFormat::setIndent](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setIndent) 값을 각각 0, 20, 40포인트로 적용합니다. 첫 번째 줄은 점점 큰 오프셋에서 시작하고, 줄 바꿈된 줄은 동일한 왼쪽 여백을 유지합니다:

```php
use aspose\slides\FillType;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TextAutofitType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 420, 220);
    $shape->getFillFormat()->setFillType(FillType::NoFill);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);

    $textFrame = $shape->getTextFrame();
    $textFrame->getTextFrameFormat()->setAutofitType(TextAutofitType::Shape);
    $textFrame->getParagraphs()->clear();

    $firstParagraph = new Paragraph();
    $firstParagraph->setText("No first-line indent. Wrapped lines start at the same position as the first line.");
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $firstParagraph->getParagraphFormat()->setMarginLeft(20.0);
    $firstParagraph->getParagraphFormat()->setIndent(0.0);

    $secondParagraph = new Paragraph();
    $secondParagraph->setText("First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.");
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $secondParagraph->getParagraphFormat()->setMarginLeft(20.0);
    $secondParagraph->getParagraphFormat()->setIndent(20.0);

    $thirdParagraph = new Paragraph();
    $thirdParagraph->setText("First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.");
    $thirdParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $thirdParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $thirdParagraph->getParagraphFormat()->setMarginLeft(20.0);
    $thirdParagraph->getParagraphFormat()->setIndent(40.0);

    $textFrame->getParagraphs()->add($firstParagraph);
    $textFrame->getParagraphs()->add($secondParagraph);
    $textFrame->getParagraphs()->add($thirdParagraph);

    $presentation->save("paragraph_indent.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

결과:

![The first-line indent of the paragraphs](first_line_indent.png)

### **걸이 들여쓰기 설정**

걸이 들여쓰기는 첫 번째 줄이 나머지 줄보다 왼쪽에 시작되는 단락 레이아웃입니다. Aspose.Slides에서는 [ParagraphFormat::setIndent](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setIndent) 속성을 사용해 이 효과를 만들 수 있습니다. `Indent`를 음수 값으로 설정하면 첫 번째 줄을 단락 본문에 비해 왼쪽으로 이동합니다.

실제로는 [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setMarginLeft)가 단락 본문의 왼쪽 위치를 정의하고, [ParagraphFormat::setIndent](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setIndent)가 그 여백에 대한 첫 번째 줄의 위치를 정의합니다. 걸이 들여쓰기를 만들려면 양의 `MarginLeft` 값과 음의 `Indent` 값을 설정합니다.

이 서식은 참고 문헌, 인용, 용어 사전 항목 및 줄 바꿈된 줄이 첫 번째 줄의 첫 문자 아래가 아니라 단락 본문 아래에 정렬되어야 하는 다른 단락에 유용합니다.

다음 PHP 예제는 [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setMarginLeft) 값을 각각 40과 60포인트로, [ParagraphFormat::setIndent](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setIndent) 값을 -20과 -30포인트로 지정합니다. 각 단락에서 첫 번째 줄은 줄 바꿈된 줄보다 왼쪽에 시작되며, 두 번째 단락은 더 깊은 걸이 들여쓰기를 가집니다:

```php
use aspose\slides\FillType;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TextAutofitType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 420, 220);
    $shape->getFillFormat()->setFillType(FillType::NoFill);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);

    $textFrame = $shape->getTextFrame();
    $textFrame->getTextFrameFormat()->setAutofitType(TextAutofitType::Shape);
    $textFrame->getParagraphs()->clear();

    $firstParagraph = new Paragraph();
    $firstParagraph->setText("A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.");
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $firstParagraph->getParagraphFormat()->setMarginLeft(40.0);
    $firstParagraph->getParagraphFormat()->setIndent(-20.0);

    $secondParagraph = new Paragraph();
    $secondParagraph->setText("This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.");
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $secondParagraph->getParagraphFormat()->setMarginLeft(60.0);
    $secondParagraph->getParagraphFormat()->setIndent(-30.0);

    $textFrame->getParagraphs()->add($firstParagraph);
    $textFrame->getParagraphs()->add($secondParagraph);

    $presentation->save("hanging_indent.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

결과:

![The hanging indent of the paragraphs](hanging_indent.png)

### **단락 끝 실행 속성 설정**

[Paragraph::setEndParagraphPortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#setEndParagraphPortionFormat) 메서드는 단락 끝 표시의 서식을 제어합니다. 다음 예제는 [PortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/portionformat/)을 만들고, [BasePortionFormat::setFontHeight](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight)를 48포인트, [BasePortionFormat::setLatinFont](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setLatinFont)를 Times New Roman으로 설정합니다. 이 서식을 두 번째 단락의 끝 표시에 할당하고, 표시 텍스트 구절은 그대로 둡니다:

```php
use aspose\slides\FontData;
use aspose\slides\Paragraph;
use aspose\slides\Portion;
use aspose\slides\PortionFormat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation("Test.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 200, 250);
    $textFrame = $shape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $firstParagraph = new Paragraph();
    $firstParagraph->getPortions()->add(new Portion("Sample text"));

    $secondParagraph = new Paragraph();
    $secondParagraph->getPortions()->add(new Portion("Sample text 2"));

    $endParagraphFormat = new PortionFormat();
    $endParagraphFormat->setFontHeight(48);
    $endParagraphFormat->setLatinFont(new FontData("Times New Roman"));
    $secondParagraph->setEndParagraphPortionFormat($endParagraphFormat);

    $textFrame->getParagraphs()->add($firstParagraph);
    $textFrame->getParagraphs()->add($secondParagraph);

    $presentation->save("end_paragraph_format.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **렌더링된 줄 수 세기**

줄 끝에서 자동 줄 바꿈 및 구두점에 영향을 주는 단락 규칙은 [Control Line Breaking](/slides/ko/php-java/text-formatting/#control-line-breaking) 및 [Control Hanging Punctuation](/slides/ko/php-java/text-formatting/#control-hanging-punctuation)를 참조하십시오.

[Paragraph::getLinesCount](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getLinesCount)를 사용해 텍스트 레이아웃 후 단락이 차지하는 줄 수를 셉니다. 이는 프레젠테이션 템플릿에서 텍스트 길이와 레이아웃을 확인할 때 유용합니다.

단락은 [TextFrame::getParagraphs](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/#getParagraphs)에서 하나의 항목이며, 여러 렌더링된 줄을 차지할 수 있습니다. 단락 내에 명시적인 줄 바꿈을 삽입하면 새로운 줄이 강제로 생성되지만 새로운 단락은 만들지 않습니다. 자동 줄 바꿈은 텍스트에 명시적인 줄 바꿈 문자를 삽입하지 않고 가용 너비에 따라 줄을 생성합니다. 따라서 단락 수나 줄 바꿈 문자 수를 세는 것만으로는 렌더링된 줄 수를 알 수 없습니다.

다음 예제는 텍스트 도형을 만들고, 줄 수를 계산한 뒤 도형을 좁히고, 텍스트를 짧은 문자열로 교체합니다. 예제는 [TextFrameFormat::setWrapText](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setWrapText)으로 줄 바꿈을 활성화하고, [TextFrameFormat::setAutofitType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setAutofitType)으로 자동 맞춤을 비활성화해 도형 너비가 텍스트를 자동으로 축소하거나 도형 크기를 자동으로 조정하지 않도록 합니다. 각 측정은 [Paragraph::getLinesCount](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getLinesCount)를 사용합니다. 도형 치수는 포인트 단위입니다. 마지막으로 예제는 또 다른 단락을 추가하고 텍스트 프레임 전체의 줄 수를 합산합니다:

```php
use aspose\slides\NullableBool;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;
use aspose\slides\TextAutofitType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 400, 200);
    $textFrame = $shape->getTextFrame();
    $textFrame->getTextFrameFormat()->setWrapText(NullableBool::True);
    $textFrame->getTextFrameFormat()->setAutofitType(TextAutofitType::None);

    $paragraph = $textFrame->getParagraphs()->get_Item(0);
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(20);
    $paragraph->setText("This text demonstrates how automatic wrapping changes the number of rendered lines.");
    echo "Original width: " . java_values($paragraph->getLinesCount()) . PHP_EOL;

    $shape->setWidth(150);
    echo "Narrower shape: " . java_values($paragraph->getLinesCount()) . PHP_EOL;

    $paragraph->setText("Short text.");
    echo "Shorter text: " . java_values($paragraph->getLinesCount()) . PHP_EOL;

    $secondParagraph = new Paragraph();
    $secondParagraph->setText("Another paragraph.");
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(20);
    $textFrame->getParagraphs()->add($secondParagraph);

    $totalLineCount = 0;
    for ($i = 0; $i < java_values($textFrame->getParagraphs()->getCount()); $i++) {
        $currentParagraph = $textFrame->getParagraphs()->get_Item($i);
        $totalLineCount += java_values($currentParagraph->getLinesCount());
    }
    echo "Total lines in the text frame: " . $totalLineCount . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

이 텍스트와 치수로 도형을 좁히면 줄 수가 증가하고, 짧은 문자열로 교체하면 줄 수가 감소합니다. 정확한 줄 수는 사용 가능한 글꼴 및 대체, 글꼴 크기, 여백, 들여쓰기, 줄 바꿈 및 자동 맞춤 설정에 따라 달라질 수 있습니다. 템플릿을 확인할 때 대상 환경에 맞는 글꼴 및 레이아웃 설정을 사용하십시오.

줄 수만으로 텍스트가 컨테이너를 초과하는지 판단할 수 없습니다. 사용 가능한 높이, 줄 높이, 단락 및 줄 간격, 자동 맞춤 동작도 영향을 미칩니다; 줄 바꿈이 비활성화된 경우 단일 줄도 가용 너비를 초과할 수 있습니다.

## **단락 내용 가져오기 및 내보내기**

HTML을 사용해 텍스트를 프레젠테이션에 가져오거나 기존 단락을 외부에서 사용할 수 있도록 내보낼 수 있습니다. 이 섹션에서는 표 셀 내 단락을 포함해 개별 단락을 이미지로 렌더링하는 방법도 보여줍니다.

### **HTML 텍스트를 단락으로 가져오기**

[ParagraphCollection::addFromHtml](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphcollection/#addFromHtml)를 사용해 HTML 마크업을 텍스트 프레임의 단락 및 구절로 변환합니다.

이 PHP 예제는 파일에서 HTML을 읽고 마크업을 [ParagraphCollection::addFromHtml](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphcollection/#addFromHtml)에 전달합니다. 텍스트 프레임의 기본 단락을 지워 프레임에 가져온 내용만 포함되도록 합니다. 사각형 도형은 슬라이드 각 면에 10포인트 여백을 남깁니다:

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeWidth = java_values($presentation->getSlideSize()->getSize()->getWidth()) - 20;
    $shapeHeight = java_values($presentation->getSlideSize()->getSize()->getHeight()) - 20;
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, $shapeWidth, $shapeHeight);
    $shape->getFillFormat()->setFillType(FillType::NoFill);
    $shape->getTextFrame()->getParagraphs()->clear();

    $html = file_get_contents("file.html");
    if ($html !== false) {
        $shape->getTextFrame()->getParagraphs()->addFromHtml($html);
        $presentation->save("html_text.pptx", SaveFormat::Pptx);
    } else {
        echo "The HTML file could not be read.";
    }
} finally {
    $presentation->dispose();
}
```

### **단락 텍스트를 HTML로 내보내기**

[ParagraphCollection::exportToHtml](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphcollection/#exportToHtml)을 사용해 선택된 단락 범위를 HTML로 내보냅니다. 웹 사이트에 프레젠테이션 텍스트를 재사용할 때 프레젠테이션의 글꼴, 크기 또는 텍스트 상자 스타일을 유지하지 않고 로컬 강조만 보존하고 싶을 수 있습니다. [TextToHtmlConversionOptions::setTextInheritanceLimit](https://reference.aspose.com/slides/php-java/aspose.slides/texttohtmlconversionoptions/#setTextInheritanceLimit)를 설정해 내보내기가 형식 상속을 얼마나 따라갈지 제어합니다.

[샘플 프레젠테이션](text-inheritance.pptx)을 다운로드하고 애플리케이션 작업 디렉터리에 두십시오. 첫 번째 슬라이드에는 텍스트 "Inherited text; explicit red 18pt"가 있는 하나의 텍스트 도형이 포함됩니다. 입력은 의도적으로 여러 서식 수준을 사용합니다:

- 프레젠테이션의 기본 텍스트 스타일은 Calibri와 28pt 크기를 제공합니다.
- 텍스트 프레임의 첫 번째 수준 텍스트 스타일은 파란색 텍스트와 기울임꼴을 제공합니다.
- 단락은 굵은 텍스트를 명시적으로 설정합니다.
- 두 번째 구절 "explicit red 18pt"는 빨간색 텍스트와 18pt 크기를 명시적으로 설정합니다.

다음 완전한 예제는 동일한 단락을 세 번 내보냅니다. [TextToHtmlConversionOptions](https://reference.aspose.com/slides/php-java/aspose.slides/texttohtmlconversionoptions/)을 내보내기 메서드에 전달하고 각 결과를 별도의 UTF-8 HTML 파일로 기록합니다:

```php
use aspose\slides\Presentation;
use aspose\slides\TextInheritanceLimit;
use aspose\slides\TextToHtmlConversionOptions;

$presentation = new Presentation("text-inheritance.pptx");
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
        $textFrame = $shape->getTextFrame();
        if (!java_is_null($textFrame)) {
            $paragraphs = $textFrame->getParagraphs();

            $modes = array(TextInheritanceLimit::All, TextInheritanceLimit::TextBox, TextInheritanceLimit::ParagraphOnly);
            $fileNames = array("All.html", "TextBox.html", "ParagraphOnly.html");

            for ($i = 0; $i < count($modes); $i++) {
                $options = new TextToHtmlConversionOptions();
                $options->setTextInheritanceLimit($modes[$i]);

                $html = $paragraphs->exportToHtml(0, $paragraphs->getCount(), $options);
                if (file_put_contents($fileNames[$i], java_values($html)) === false) {
                    echo "The HTML file could not be written." . PHP_EOL;
                }
            }
        } else {
            echo "The first shape does not contain a text frame.";
        }
    } else {
        echo "The first shape is not a text shape.";
    }
} finally {
    $presentation->dispose();
}
```

생성된 HTML에는 첫 번째 구절인 "Inherited text; "에 대한 다음 CSS가 포함됩니다. 표에는 관련 선언만 나열하고 다른 생성 속성은 명확성을 위해 생략했습니다.

| 출력 | 첫 번째 구절에 대한 관련 CSS | 표시 |
| --- | --- | --- |
| `All.html` | `font-family:'Calibri'; font-size:28pt; color:#0000ff; font-style:italic; font-weight:bold` | Calibri가 사용 가능할 경우 28pt, 파란색, 굵게, 기울임꼴 텍스트 |
| `TextBox.html` | `color:#0000ff; font-style:italic; font-weight:bold` | 파란색, 굵게, 기울임꼴 텍스트; 글꼴 패밀리와 크기는 페이지 또는 브라우저가 제공 |
| `ParagraphOnly.html` | `font-weight:bold` | 굵게 텍스트; 글꼴 패밀리, 크기, 색상 및 기울임꼴은 페이지 또는 브라우저가 제공 |

두 번째 구절은 세 출력 모두에서 `color:#ff0000`, `font-size:18pt`, `font-weight:bold`를 유지합니다. 또한 `All`과 `TextBox`에서는 기울임꼴을 유지하지만 `ParagraphOnly`에서는 기울임꼴이 없습니다. 상속 제한은 단락이나 구절에 명시적으로 할당된 서식을 제거하지 않습니다.

같은 브라우저에서 파일을 열어 비교하십시오. 제한된 두 모드에서는 누락된 CSS 속성이 대상 페이지의 스타일이나 브라우저 기본값에 의해 해결되므로 최종 표시가 HTML이 사용되는 위치에 따라 달라집니다.

### **단락을 이미지로 렌더링**

[Paragraph::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getImage)는 개별 단락을 직접 렌더링하고 [IImage](https://reference.aspose.com/slides/php-java/aspose.slides/iimage/)를 반환합니다. 결과를 [IImage::save](https://reference.aspose.com/slides/php-java/aspose.slides/iimage/#save)를 사용해 파일이나 스트림에 저장합니다. 포함된 도형을 렌더링하거나 비트맵을 수동으로 자를 필요가 없습니다.

[Paragraph::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getImage)는 단락을 상위 컬렉션에서 찾을 수 없거나 유효한 렌더링 경계가 없거나 렌더링할 수 없는 경우 `null`을 반환할 수 있습니다. 저장하기 전에 결과를 확인하고 사용 후 반환된 이미지를 해제하십시오.

#### **기본 배율로 단락 렌더링**

예제는 첫 번째 도형이 세 개의 단락을 포함한 텍스트 상자를 가진 슬라이드가 있는 프레젠테이션을 사용합니다.

![The text box with three paragraphs](paragraph_to_image_input.png)

다음 예제는 인덱스 1인 두 번째 단락을 선택하고 배율 매개변수 없이 [Paragraph::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getImage)를 호출합니다. 도형에 필요한 단락이 포함되어 있는지, 렌더링이 이미지로 반환되는지를 확인한 뒤 [IImage::save](https://reference.aspose.com/slides/php-java/aspose.slides/iimage/#save)으로 PNG 형식으로 저장합니다. `finally` 블록은 사용 후 이미지를 해제합니다.

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$presentation = new Presentation("sample.pptx");
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
        $textFrame = $shape->getTextFrame();
        if (!java_is_null($textFrame) && java_values($textFrame->getParagraphs()->getCount()) > 1) {
            $paragraph = $textFrame->getParagraphs()->get_Item(1);
            $paragraphImage = $paragraph->getImage();

            if (!java_is_null($paragraphImage)) {
                try {
                    $paragraphImage->save("paragraph.png", ImageFormat::Png);
                } finally {
                    $paragraphImage->dispose();
                }
            } else {
                echo "The paragraph could not be rendered.";
            }
        } else {
            echo "The expected paragraph was not found.";
        }
    } else {
        echo "The first shape is not a text shape.";
    }
} finally {
    $presentation->dispose();
}
```

결과:

![The paragraph image](paragraph_to_image_output.png)

#### **테이블 셀에서 배율을 적용해 단락 렌더링**

`$scaleX`와 `$scaleY` 매개변수를 허용하는 [Paragraph::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getImage) 오버로드를 사용해 가로 및 세로 배율을 설정합니다. 다음 예제는 표를 만든 뒤 첫 번째 셀의 단락을 기본 너비와 높이의 두 배로 렌더링하고 PNG 이미지로 저장합니다.

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$scaleX = 2;
$scaleY = 2;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    
    $table = $slide->getShapes()->addTable(50, 50, array(300), array(80));
    $paragraph = $table->get_Item(0, 0)->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->setText("Text in a table cell");

    $paragraphImage = $paragraph->getImage($scaleX, $scaleY);
    if (!java_is_null($paragraphImage)) {
        try {
            $paragraphImage->save("table_paragraph.png", ImageFormat::Png);
        } finally {
            $paragraphImage->dispose();
        }
    } else {
        echo "The paragraph could not be rendered.";
    }
} finally {
    $presentation->dispose();
}
```

배율이 `1`이면 해당 축이 기본 픽셀 크기를 유지합니다. 예를 들어 두 배(`2`)를 지정하면 이미지의 너비와 높이가 약 두 배가 되어 픽셀 수가 네 배가 됩니다. 큰 배율은 확대 또는 고해상도 출력 시 텍스트를 더 선명하게 만들지만 메모리 사용량과 파일 크기도 증가합니다. `1`보다 작은 배율은 세부 정보가 적은 작은 이미지를 생성합니다. 가로·세로 배율을 동일하게 설정하면 단락의 가로·세로 비율이 유지됩니다; 서로 다른 배율은 출력을 각각 늘립니다.

전체 도형을 렌더링하려면 [Shape::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getImage)를 사용해 도형의 채우기, 테두리 또는 기타 시각적 컨텍스트를 포함할 수 있습니다. 단락 전용 이미지는 [Paragraph::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getImage)를 사용하십시오.

## **FAQ**

**텍스트 프레임 내부에서 줄 바꿈을 완전히 비활성화할 수 있나요?**

예. [TextFrameFormat::setWrapText](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setWrapText)를 설정해 줄 바꿈을 비활성화하면 줄이 텍스트 프레임 가장자리를 넘어 끊기지 않습니다.

**특정 단락의 정확한 슬라이드 내 경계는 어떻게 얻나요?**

[Paragraph::getRect](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getRect)를 사용해 단락의 경계 사각형을 가져옵니다. [Portion::getRect](https://reference.aspose.com/slides/php-java/aspose.slides/portion/#getRect)는 개별 구절의 경계를 제공합니다.

**단락 정렬(왼쪽, 오른쪽, 가운데 또는 양쪽 맞춤)은 어디에서 제어되나요?**

[ParagraphFormat::setAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setAlignment)은 단락 수준 설정이며 개별 구절 서식과 무관하게 전체 단락에 적용됩니다.

각 줄에서 서로 다른 글꼴 크기의 구절을 수직 정렬하려면 [Align Fonts Within a Line](/slides/ko/php-java/text-formatting/#align-fonts-within-a-line)를 참조하십시오.

**단락의 일부에 교정 언어를 설정할 수 있나요?**

예. [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setLanguageId)를 개별 구절에 설정하면 하나의 단락에 여러 언어 텍스트를 포함할 수 있습니다.
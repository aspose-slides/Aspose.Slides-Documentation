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
- 글머리 기호 관리
- 단락 들여쓰기
- 행걸이 들여쓰기
- 단락 글머리 기호
- 번호 매기기 목록
- 글머리 기호 목록
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
description: "Aspose.Slides for PHP via Java를 사용하여 단락, 포션, 글머리 기호, 번호 매기기 목록, 들여쓰기, HTML 콘텐츠 및 단락 이미지를 만들고 서식 지정하는 방법을 배웁니다."
---
## **개요**

Aspose.Slides for PHP via Java는 텍스트를 텍스트 프레임, 단락 및 포션의 계층 구조로 나타냅니다:

* [TextFrame](https://reference.aspose.com/slides/ko/php-java/aspose.slides/textframe/) 도형 내의 텍스트 컨테이너를 나타내며 단락 컬렉션에 대한 액세스를 제공합니다.
* [Paragraph](https://reference.aspose.com/slides/ko/php-java/aspose.slides/paragraph/) 텍스트 프레임 내의 하나의 단락을 나타내며 포션 및 단락 수준 서식에 대한 액세스를 제공합니다.
* [Portion](https://reference.aspose.com/slides/ko/php-java/aspose.slides/portion/) 단락 내의 텍스트 실행을 나타냅니다. 각 포션은 자체 텍스트 및 문자 수준 서식을 가질 수 있습니다.

따라서 단락은 여러 포션을 사용하여 서로 다른 글꼴, 색상, 크기 및 기타 서식을 가진 텍스트를 포함할 수 있습니다.

## **단락 만들기 및 서식 지정**

### **여러 포션을 사용하여 단락 만들기**

다음 단계는 세 개의 단락을 가진 텍스트 프레임을 만들며, 각 단락은 세 개의 포션을 포함합니다:

1. [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
2. 인덱스를 통해 해당 슬라이드에 접근합니다.
3. 슬라이드에 직사각형 [AutoShape](https://reference.aspose.com/slides/ko/php-java/aspose.slides/autoshape/)을 추가합니다.
4. 모양의 [TextFrame](https://reference.aspose.com/slides/ko/php-java/aspose.slides/textframe/)에 접근합니다.
5. 기본 단락을 사용하고 텍스트 프레임에 두 개의 추가 [Paragraph](https://reference.aspose.com/slides/ko/php-java/aspose.slides/paragraph/) 객체를 추가합니다.
6. 각 단락이 세 개의 포션을 포함하도록 충분한 [Portion](https://reference.aspose.com/slides/ko/php-java/aspose.slides/portion/) 객체를 추가합니다. 기본 단락에는 이미 빈 포션이 하나 포함되어 있습니다.
7. 각 포션의 텍스트를 설정합니다.
8. [Portion::getPortionFormat](https://reference.aspose.com/slides/ko/php-java/aspose.slides/portion/#getPortionFormat--)을 통해 문자 수준 서식을 적용합니다.
9. 수정된 프레젠테이션을 저장합니다.

이 PHP 예제는 위 단계를 구현합니다:

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

## **글머리 기호 및 번호 매기기 목록 만들기**

### **글머리 기호 또는 번호 매기기 목록 만들기**

글머리 기호와 번호 매기기는 관련 항목을 더 쉽게 스캔할 수 있게 합니다. Aspose.Slides에서는 목록 설정을 [BulletFormat](https://reference.aspose.com/slides/ko/php-java/aspose.slides/bulletformat/)을 통해 정의합니다.

1. [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
2. 인덱스를 통해 해당 슬라이드에 접근합니다.
3. 선택한 슬라이드에 [AutoShape](https://reference.aspose.com/slides/ko/php-java/aspose.slides/autoshape/)을 추가합니다.
4. 모양의 [TextFrame](https://reference.aspose.com/slides/ko/php-java/aspose.slides/textframe/)에 접근합니다.
5. 텍스트 프레임에서 기본 단락을 제거합니다.
6. 기호 글머리 기호용 [Paragraph](https://reference.aspose.com/slides/ko/php-java/aspose.slides/paragraph/)을 생성합니다.
7. [BulletFormat::setType](https://reference.aspose.com/slides/ko/php-java/aspose.slides/bulletformat/#setType-int-)을 [BulletType::Symbol](https://reference.aspose.com/slides/ko/php-java/aspose.slides/bullettype/)으로 설정하고 글머리 문자을 지정합니다.
8. 단락 텍스트, 들여쓰기, 글머리 색상 및 글머리 높이를 설정합니다.
9. 단락을 텍스트 프레임에 추가합니다.
10. 두 번째 단락을 생성하고 [BulletFormat::setType](https://reference.aspose.com/slides/ko/php-java/aspose.slides/bulletformat/#setType-int-)을 [BulletType::Numbered](https://reference.aspose.com/slides/ko/php-java/aspose.slides/bullettype/)으로 설정합니다.
11. 번호 매기기 글머리 스타일을 구성하고 단락을 텍스트 프레임에 추가합니다.
12. 프레젠테이션을 저장합니다.

이 PHP 예제는 기호 글머리와 번호 매기기 글머리를 생성합니다:

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

### **그림 글머리 사용**

그림 글머리를 사용하면 기호나 번호 대신 사용자 정의 이미지를 사용할 수 있습니다.

1. [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
2. 인덱스를 통해 해당 슬라이드에 접근합니다.
3. [AutoShape](https://reference.aspose.com/slides/ko/php-java/aspose.slides/autoshape/)을 추가하고 해당 [TextFrame](https://reference.aspose.com/slides/ko/php-java/aspose.slides/textframe/)에 접근합니다.
4. 텍스트 프레임에서 기본 단락을 제거합니다.
5. 글머리 이미지를 로드하고 이를 [PPImage](https://reference.aspose.com/slides/ko/php-java/aspose.slides/ppimage/)으로 프레젠테이션의 이미지 컬렉션에 추가합니다.
6. [Paragraph](https://reference.aspose.com/slides/ko/php-java/aspose.slides/paragraph/)을 생성하고 텍스트를 설정합니다.
7. [BulletFormat::setType](https://reference.aspose.com/slides/ko/php-java/aspose.slides/bulletformat/#setType-int-)을 [BulletType::Picture](https://reference.aspose.com/slides/ko/php-java/aspose.slides/bullettype/)으로 설정합니다.
8. [BulletFormat::getPicture](https://reference.aspose.com/slides/ko/php-java/aspose.slides/bulletformat/#getPicture--)을 통해 이미지를 지정하고 글머리 높이를 설정합니다.
9. 단락을 텍스트 프레임에 추가합니다.
10. 수정된 프레젠테이션을 저장합니다.

이 PHP 예제는 그림 글머리를 생성합니다:

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

### **다단계 목록 만들기**

[ParagraphFormat::setDepth](https://reference.aspose.com/slides/ko/php-java/aspose.slides/paragraphformat/#setDepth-short-)을 설정하여 단락을 목록의 서로 다른 수준에 배치합니다. 최상위 수준의 깊이는 `0`입니다.

1. [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/)을 만들고 슬라이드에 접근합니다.
2. [AutoShape](https://reference.aspose.com/slides/ko/php-java/aspose.slides/autoshape/)을 추가하고 해당 텍스트 프레임에서 기본 단락을 제거합니다.
3. 네 개의 단락을 만들고 글머리 기호를 구성합니다.
4. 각 단락의 [ParagraphFormat::setDepth](https://reference.aspose.com/slides/ko/php-java/aspose.slides/paragraphformat/#setDepth-short-) 값을 `0`, `1`, `2`, `3`으로 설정합니다.
5. 단락을 텍스트 프레임에 추가하고 프레젠테이션을 저장합니다.

이 PHP 예제는 네 수준의 글머리 목록을 생성합니다:

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

### **사용자 지정 값으로 번호 매기기 목록 시작**

[BulletFormat::setNumberedBulletStartWith](https://reference.aspose.com/slides/ko/php-java/aspose.slides/bulletformat/#setNumberedBulletStartWith-short-)을 사용하여 번호 매기기 단락에 표시할 초기 번호를 설정합니다.

1. [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/)을 만들고 슬라이드에 [AutoShape](https://reference.aspose.com/slides/ko/php-java/aspose.slides/autoshape/)을 추가합니다.
2. 모양의 텍스트 프레임에서 기본 단락을 제거합니다.
3. 세 개의 번호 매기기 단락을 생성합니다.
4. 해당 단락마다 [BulletFormat::setNumberedBulletStartWith](https://reference.aspose.com/slides/ko/php-java/aspose.slides/bulletformat/#setNumberedBulletStartWith-short-)을 `2`, `3`, `7`로 설정합니다.
5. 단락을 텍스트 프레임에 추가하고 프레젠테이션을 저장합니다.

이 PHP 예제는 각 단락에 사용자 지정 시작 번호를 할당합니다:

```php
use aspose\slides\BulletType;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
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

## **단락 레이아웃 및 종료 속성 제어**

### **첫 줄 들여쓰기 설정**

[ParagraphFormat::setIndent](https://reference.aspose.com/slides/ko/php-java/aspose.slides/paragraphformat/#setIndent-float-)을 사용하여 단락의 첫 줄 들여쓰기를 제어합니다. 이 메서드는 단락의 왼쪽 여백에 대해 첫 번째 줄만 이동시킵니다. 양수 값은 첫 줄을 오른쪽으로 이동시키고, 나머지 줄은 단락 본문에 맞춰 정렬됩니다.

전체 단락을 이동해야 할 경우에는 [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/ko/php-java/aspose.slides/paragraphformat/#setMarginLeft-float-)를 사용하고, 첫 줄만 이동하려면 [ParagraphFormat::setIndent](https://reference.aspose.com/slides/ko/php-java/aspose.slides/paragraphformat/#setIndent-float-)를 사용합니다.

아래 예제는 여러 단락을 생성하고 서로 다른 [ParagraphFormat::setIndent](https://reference.aspose.com/slides/ko/php-java/aspose.slides/paragraphformat/#setIndent-float-) 값을 적용하여 첫 줄 들여쓰기가 단락 레이아웃에 미치는 영향을 보여줍니다.

1. [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
2. 대상 슬라이드에 접근합니다.
3. 슬라이드에 직사각형 [AutoShape](https://reference.aspose.com/slides/ko/php-java/aspose.slides/autoshape/)을 추가합니다.
4. 모양의 [TextFrame](https://reference.aspose.com/slides/ko/php-java/aspose.slides/textframe/)에 접근하고 기본 단락을 제거합니다.
5. 여러 단락을 생성하고 각각에 서로 다른 [ParagraphFormat::setIndent](https://reference.aspose.com/slides/ko/php-java/aspose.slides/paragraphformat/#setIndent-float-) 값을 설정합니다.
6. 단락을 텍스트 프레임에 추가합니다.
7. 수정된 프레젠테이션을 저장합니다.

이 PHP 코드는 단락 들여쓰기를 설정하는 방법을 보여줍니다:

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

![단락의 첫 줄 들여쓰기](first_line_indent.png)

### **행걸이 들여쓰기 설정**

행걸이 들여쓰기는 첫 줄이 나머지 줄보다 왼쪽에 시작되는 단락 레이아웃입니다. Aspose.Slides에서는 [ParagraphFormat::setIndent](https://reference.aspose.com/slides/ko/php-java/aspose.slides/paragraphformat/#setIndent-float-)에 음수 값을 전달하여 첫 줄을 단락 본문에 대해 왼쪽으로 이동시킵니다.

실제로는 [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/ko/php-java/aspose.slides/paragraphformat/#setMarginLeft-float-)가 단락 본문의 왼쪽 위치를 정의하고, [ParagraphFormat::setIndent](https://reference.aspose.com/slides/ko/php-java/aspose.slides/paragraphformat/#setIndent-float-)가 해당 여백에 대한 첫 줄 위치를 정의합니다. 행걸이 들여쓰기를 만들려면 `setMarginLeft`에 양수 값을, `setIndent`에 음수 값을 전달합니다.

이 서식은 참고문헌, 인용, 용어 사전 항목 및 줄이 단락 본문 아래에 정렬되어야 하는 다른 단락에 유용합니다.

1. [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
2. 대상 슬라이드에 접근합니다.
3. 슬라이드에 직사각형 [AutoShape](https://reference.aspose.com/slides/ko/php-java/aspose.slides/autoshape/)을 추가합니다.
4. 모양의 [TextFrame](https://reference.aspose.com/slides/ko/php-java/aspose.slides/textframe/)에 접근하고 기본 단락을 제거합니다.
5. 각 단락에 대해 [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/ko/php-java/aspose.slides/paragraphformat/#setMarginLeft-float-)에 양수 값을 전달합니다.
6. 행걸이 들여쓰기 효과를 만들기 위해 [ParagraphFormat::setIndent](https://reference.aspose.com/slides/ko/php-java/aspose.slides/paragraphformat/#setIndent-float-)에 음수 값을 전달합니다.
7. 단락을 텍스트 프레임에 추가합니다.
8. 수정된 프레젠테이션을 저장합니다.

이 PHP 코드는 단락에 대한 행걸이 들여쓰기를 설정하는 방법을 보여줍니다:

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

![단락의 행걸이 들여쓰기](hanging_indent.png)

### **단락 종료 구역 속성 설정**

[Paragraph::setEndParagraphPortionFormat](https://reference.aspose.com/slides/ko/php-java/aspose.slides/paragraph/#setEndParagraphPortionFormat-com.aspose.slides.PortionFormat-)은 단락 종료 표시의 서식을 제어합니다. 다음 PHP 예제는 두 번째 단락의 종료 표시에 글꼴 크기와 라틴 글꼴을 할당합니다:

1. [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/)을 로드하고 슬라이드에 접근합니다.
2. [AutoShape](https://reference.aspose.com/slides/ko/php-java/aspose.slides/autoshape/)을 추가하고 기본 단락을 제거합니다.
3. 두 개의 단락을 만들고 텍스트 포션을 추가합니다.
4. 두 번째 단락의 종료 표시용 [PortionFormat](https://reference.aspose.com/slides/ko/php-java/aspose.slides/portionformat/)을 생성합니다.
5. [BasePortionFormat::setFontHeight](https://reference.aspose.com/slides/ko/php-java/aspose.slides/baseportionformat/#setFontHeight-float-)과 [BasePortionFormat::setLatinFont](https://reference.aspose.com/slides/ko/php-java/aspose.slides/baseportionformat/#setLatinFont-com.aspose.slides.IFontData-)을 설정합니다.
6. [Paragraph::setEndParagraphPortionFormat](https://reference.aspose.com/slides/ko/php-java/aspose.slides/paragraph/#setEndParagraphPortionFormat-com.aspose.slides.PortionFormat-)으로 서식을 할당하고 프레젠테이션을 저장합니다.

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

## **단락 내용 가져오기 및 내보내기**

### **HTML 텍스트를 단락에 가져오기**

[ParagraphCollection::addFromHtml](https://reference.aspose.com/slides/ko/php-java/aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-)을 사용하여 HTML 마크업을 텍스트 프레임의 단락 및 포션으로 변환합니다.

1. [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
2. 슬라이드에 접근하고 [AutoShape](https://reference.aspose.com/slides/ko/php-java/aspose.slides/autoshape/)를 추가합니다.
3. 모양의 [TextFrame](https://reference.aspose.com/slides/ko/php-java/aspose.slides/textframe/)에 접근하고 기본 단락을 제거합니다.
4. 원본 HTML 파일을 읽습니다.
5. HTML 문자열을 [ParagraphCollection::addFromHtml](https://reference.aspose.com/slides/ko/php-java/aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-)에 전달합니다.
6. 수정된 프레젠테이션을 저장합니다.

이 PHP 예제는 HTML을 텍스트 프레임으로 가져옵니다:

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

[ParagraphCollection::exportToHtml](https://reference.aspose.com/slides/ko/php-java/aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-)을 사용하여 선택된 단락 범위를 HTML로 내보냅니다.

1. [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/) 인스턴스를 생성하고 원하는 프레젠테이션을 로드합니다.
2. 슬라이드에 접근하고 텍스트가 포함된 [AutoShape](https://reference.aspose.com/slides/ko/php-java/aspose.slides/autoshape/)를 찾습니다.
3. 모양의 [TextFrame](https://reference.aspose.com/slides/ko/php-java/aspose.slides/textframe/)에 접근합니다.
4. 시작 단락 인덱스와 내보낼 단락 수를 지정하여 [ParagraphCollection::exportToHtml](https://reference.aspose.com/slides/ko/php-java/aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-)을 호출합니다.
5. 반환된 HTML 문자열을 파일에 씁니다.

이 PHP 예제는 첫 번째 텍스트 모양의 모든 단락을 내보냅니다:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("ExportingHTMLText.pptx");
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
        $textFrame = $shape->getTextFrame();
        if (!java_is_null($textFrame)) {
            $paragraphs = $textFrame->getParagraphs();
            $html = $paragraphs->exportToHtml(0, $paragraphs->getCount(), null);
            if (file_put_contents("paragraphs.html", $html) === false) {
                echo "The HTML file could not be written.";
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

### **단락을 이미지로 렌더링**

[Paragraph::getImage](https://reference.aspose.com/slides/ko/php-java/aspose.slides/paragraph/#getImage--)은 개별 단락을 직접 렌더링하고 [IImage](https://reference.aspose.com/slides/ko/php-java/aspose.slides/iimage/)를 반환합니다. 반환된 이미지를 [IImage::save](https://reference.aspose.com/slides/ko/php-java/aspose.slides/iimage/#save-java.lang.String-int-)을 사용하여 파일이나 스트림에 저장할 수 있습니다. 포함된 모양을 렌더링하거나 비트맵을 수동으로 자를 필요가 없습니다.

[Paragraph::getImage](https://reference.aspose.com/slides/ko/php-java/aspose.slides/paragraph/#getImage--)은 단락을 부모 컬렉션에서 찾을 수 없거나 유효한 렌더링 경계가 없거나 렌더링할 수 없는 경우 `null`을 반환할 수 있습니다. 저장하기 전에 결과를 확인하고 사용 후 반환된 이미지를 해제하세요.

#### **기본 배율로 단락 렌더링**

sample.pptx라는 파일에 슬라이드가 하나 있고, 첫 번째 모양이 세 개의 단락을 포함한 텍스트 상자라고 가정합니다.

![세 개의 단락이 있는 텍스트 상자](paragraph_to_image_input.png)

다음 PHP 예제는 기본 배율로 일반 텍스트 모양의 두 번째 단락을 렌더링하고 PNG 형식으로 저장합니다. `finally` 블록은 이미지가 올바르게 해제되도록 보장합니다.

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

![단락 이미지](paragraph_to_image_output.png)

#### **표 셀에서 스케일링으로 단락 렌더링**

`$scaleX`와 `$scaleY` 매개변수를 받는 [Paragraph::getImage](https://reference.aspose.com/slides/ko/php-java/aspose.slides/paragraph/#getImage-float-float-) 오버로드를 사용하여 가로 및 세로 스케일 팩터를 설정합니다. 아래 PHP 예제는 표를 만들고 첫 번째 셀의 단락을 기본 너비와 높이의 두 배로 렌더링한 뒤 PNG 이미지로 저장합니다.

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

스케일 팩터 `1`은 해당 축을 기본 픽셀 크기로 유지합니다. 예를 들어, 두 팩터 모두 `2`이면 이미지의 너비와 높이가 기본 차원의 약 두 배가 되어 픽셀 수는 네 배가 됩니다. 큰 팩터는 확대하거나 고해상도 출력 시 텍스트를 더 선명하게 만들지만 메모리 사용량과 파일 크기도 증가합니다. `1`보다 작은 팩터는 자세히 보이지 않는 작은 이미지를 생성합니다. 비율을 유지하려면 가로와 세로 팩터를 동일하게 사용하고, 서로 다르게 설정하면 출력이 개별적으로 늘어납니다.

[Shape::getImage](https://reference.aspose.com/slides/ko/php-java/aspose.slides/shape/#getImage--)를 사용하여 전체 모양을 렌더링하는 것이 모양의 채우기, 테두리 또는 기타 시각적 컨텍스트가 포함되어야 할 때 여전히 유용합니다. 단락 전용 이미지의 경우 [Paragraph::getImage](https://reference.aspose.com/slides/ko/php-java/aspose.slides/paragraph/#getImage--)를 사용하세요.

## **FAQ**

**텍스트 프레임 내부에서 줄 바꿈을 완전히 비활성화할 수 있나요?**

예. [TextFrameFormat::setWrapText](https://reference.aspose.com/slides/ko/php-java/aspose.slides/textframeformat/#setWrapText-byte-)을 설정하면 텍스트 프레임 가장자리에서 줄이 끊기지 않도록 줄 바꿈이 비활성화됩니다.

**특정 단락의 슬라이드 상 정확한 경계 값을 어떻게 얻을 수 있나요?**

[Paragraph::getRect](https://reference.aspose.com/slides/ko/php-java/aspose.slides/paragraph/#getRect--)을 사용하여 단락의 경계 사각형을 가져옵니다. [Portion::getRect](https://reference.aspose.com/slides/ko/php-java/aspose.slides/portion/#getRect--)은 개별 포션의 경계를 제공합니다.

**단락 정렬(왼쪽, 오른쪽, 가운데 또는 양쪽 맞춤)은 어디에서 제어하나요?**

[ParagraphFormat::setAlignment](https://reference.aspose.com/slides/ko/php-java/aspose.slides/paragraphformat/#setAlignment-int-)은 단락 수준 설정이며 개별 포션 서식과 무관하게 전체 단락에 적용됩니다.

**단락의 일부에 교정 언어를 설정할 수 있나요?**

예. 개별 포션에 대해 [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/ko/php-java/aspose.slides/baseportionformat/#setLanguageId-java.lang.String-)을 설정하면 하나의 단락에 여러 언어의 텍스트를 포함할 수 있습니다.
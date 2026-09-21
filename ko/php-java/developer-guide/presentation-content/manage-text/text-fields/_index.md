---
title: PHP에서 PowerPoint 프레젠테이션의 텍스트 필드 관리
linktitle: 텍스트 필드
type: docs
weight: 52
url: /ko/php-java/text-fields/
keywords:
- 텍스트 필드
- 자동 텍스트
- 슬라이드 번호
- 날짜 및 시간
- 헤더
- 푸터
- 텍스트 부분
- PowerPoint
- PPT
- PPTX
- PHP
- Aspose.Slides
description: "Java를 통해 PHP용 Aspose.Slides로 PowerPoint 프레젠테이션의 텍스트 필드를 생성, 검사, 수정 및 제거합니다. 서식을 보존하고 저장된 PPTX 및 PPT 파일을 확인합니다."
---
## **개요**

텍스트 단락은 여러 부분으로 구성됩니다. 일반적인 [Portion](https://reference.aspose.com/slides/ko/php-java/aspose.slides/portion/)은 리터럴 텍스트를 포함하고; 필드 부분은 또한 [Field](https://reference.aspose.com/slides/ko/php-java/aspose.slides/field/)를 가지고 있으며, 그 유형은 슬라이드 번호나 날짜와 같은 자동 업데이트 값임을 나타냅니다. 두 부분이 동일한 문자를 표시할 수 있지만, 필드를 포함하는 것은 하나뿐입니다.

[Portion::getField](https://reference.aspose.com/slides/ko/php-java/aspose.slides/portion/#getField)를 사용하여 구분할 수 있습니다: 일반 텍스트인 경우 `null`입니다. [Portion::addField](https://reference.aspose.com/slides/ko/php-java/aspose.slides/portion/#addField)는 기존 부분을 필드로 변환합니다. 라벨과 동적 값을 별도의 부분에 보관하여 값 변환 시 라벨이 함께 교체되지 않도록 하세요.

이 가이드는 텍스트 내부 필드, 해당 서식 및 PPTX와 PPT 저장에 대해 다룹니다. 텍스트 프레임 및 단락에 대해서는 [Manage Text](/slides/ko/php-java/manage-text/)를 참조하십시오.

## **슬라이드 번호 필드 만들기**

다음 전체 예제는 리터럴 `Slide ` 라벨 뒤에 자동 업데이트되는 번호가 포함된 텍스트 상자를 생성합니다. 필드를 추가하기 전에 번호의 크기, 두께 및 색상을 설정하고, 저장된 프레젠테이션을 다시 열어 필드 유형, 텍스트 및 서식을 확인합니다. 입력 파일은 필요하지 않습니다.

```php
use aspose\slides\FieldType;
use aspose\slides\FillType;
use aspose\slides\NullableBool;
use aspose\slides\Portion;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 40, 240, 50);
    $shape->addTextFrame("Slide ");
    $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);

    $numberPortion = new Portion();
    $numberColor = new Java("java.awt.Color", 0, 0, 139);
    $numberPortion->getPortionFormat()->setFontHeight(24);
    $numberPortion->getPortionFormat()->setFontBold(NullableBool::True);
    $numberPortion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $numberPortion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor($numberColor);
    $paragraph->getPortions()->add($numberPortion);
    $numberPortion->addField(FieldType::getSlideNumber());

    $presentation->save("slide_number.pptx", SaveFormat::Pptx);

    $reopened = new Presentation("slide_number.pptx");
    try {
        $savedShape = $reopened->getSlides()->get_Item(0)->getShapes()->get_Item(0);
        $savedNumber = $savedShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(1);
        $savedField = $savedNumber->getField();
        $hasNumberField = !java_is_null($savedField) && java_values(FieldType::getSlideNumber()->getInternalString()) === java_values($savedField->getType()->getInternalString());
        $format = $savedNumber->getPortionFormat();
        $formattingPreserved = java_values($format->getFontHeight()) == 24 && java_values($format->getFontBold()) == NullableBool::True;
        $formattingPreserved = $formattingPreserved && java_values($format->getFillFormat()->getSolidFillColor()->getColor()->getRGB()) == java_values($numberColor->getRGB());

        echo "Text: " . $savedShape->getTextFrame()->getText() . PHP_EOL;
        echo "Slide number field: " . ($hasNumberField ? "true" : "false") . PHP_EOL;
        echo "Formatting preserved: " . ($formattingPreserved ? "true" : "false") . PHP_EOL;
    } finally {
        $reopened->dispose();
    }
} finally {
    $presentation->dispose();
}
```

새 프레젠테이션은 슬라이드 번호 1로 시작하므로 텍스트는 `Slide 1`이며 두 검사 모두 `true`를 출력합니다. 번호는 다시 열어도 필드 상태를 유지하며, 리터럴 `1`이 아닙니다. 검증에 사용된 인덱스는 이 예제에서 생성된 도형 및 부분을 가리킵니다.

## **필드 유형 선택**

[FieldType](https://reference.aspose.com/slides/ko/php-java/aspose.slides/fieldtype/)은 미리 정의된 값을 얻기 위한 다음 메서드를 제공합니다. 적절한 값을 [addField](https://reference.aspose.com/slides/ko/php-java/aspose.slides/portion/#addField)에 전달하십시오.

| 메서드 | 목적 |
|---|---|
| [getSlideNumber](https://reference.aspose.com/slides/ko/php-java/aspose.slides/fieldtype/#getSlideNumber) | 현재 슬라이드 번호. |
| [getDateTime](https://reference.aspose.com/slides/ko/php-java/aspose.slides/fieldtype/#getDateTime) | 렌더링 애플리케이션의 기본 형식으로 표시되는 날짜/시간. |
| [getDateTime1](https://reference.aspose.com/slides/ko/php-java/aspose.slides/fieldtype/#getDateTime1)–[getDateTime9](https://reference.aspose.com/slides/ko/php-java/aspose.slides/fieldtype/#getDateTime9) | 미리 정의된 날짜 또는 결합된 날짜/시간 형식. |
| [getDateTime10](https://reference.aspose.com/slides/ko/php-java/aspose.slides/fieldtype/#getDateTime10)–[getDateTime13](https://reference.aspose.com/slides/ko/php-java/aspose.slides/fieldtype/#getDateTime13) | 미리 정의된 시간 형식으로, 초와 12시간 시계 옵션을 포함합니다. |
| [getHeader](https://reference.aspose.com/slides/ko/php-java/aspose.slides/fieldtype/#getHeader) | 헤더 필드; 아래의 자리표시자 및 형식 제한을 참고하세요. |
| [getFooter](https://reference.aspose.com/slides/ko/php-java/aspose.slides/fieldtype/#getFooter) | 푸터 필드. |

예를 들어, [getDateTime3](https://reference.aspose.com/slides/ko/php-java/aspose.slides/fieldtype/#getDateTime3)는 영어로 일, 전체 월 이름 및 연도를 나타냅니다. 이는 임의의 PHP 날짜 형식 문자열이 아니라 미리 정의된 필드 형식입니다. [setLanguageId](https://reference.aspose.com/slides/ko/php-java/aspose.slides/baseportionformat/#setLanguageId)로 설정한 언어와 프레젠테이션을 처리하는 애플리케이션이 표시 결과에 영향을 줄 수 있습니다.

## **내부 문자열에서 필드 만들기**

[addField](https://reference.aspose.com/slides/ko/php-java/aspose.slides/portion/#addField)의 문자열 오버로드는 내부 필드 식별자를 허용합니다. 미리 정의된 값이 없는 다른 애플리케이션이 제공한 식별자를 보존해야 할 때 사용하십시오. 식별자를 사용해 [FieldType](https://reference.aspose.com/slides/ko/php-java/aspose.slides/fieldtype/#FieldType)을 구성할 수도 있습니다. [FieldType::getInternalString](https://reference.aspose.com/slides/ko/php-java/aspose.slides/fieldtype/#getInternalString)은 해당 식별자를 검사용으로 노출합니다.

이 예제는 애플리케이션 전용 `custom-report-id` 필드를 대체 텍스트 `Report-042`와 함께 저장합니다. 식별자는 계산을 등록하지 않으며, Aspose.Slides는 알 수 없는 유형에 대한 보고서 ID를 생성하지 않습니다. 이 식별자를 이해하는 애플리케이션이 의미를 제공하고 값을 업데이트해야 합니다.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 40, 300, 50);
    $shape->addTextFrame("Report-042");
    $portion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->addField("custom-report-id");

    $presentation->save("custom_field.pptx", SaveFormat::Pptx);

    $reopened = new Presentation("custom_field.pptx");
    try {
        $savedShape = $reopened->getSlides()->get_Item(0)->getShapes()->get_Item(0);
        $savedPortion = $savedShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
        $savedField = $savedPortion->getField();
        $typeName = java_is_null($savedField) ? "ordinary text" : java_values($savedField->getType()->getInternalString());
        echo "Type: " . $typeName . PHP_EOL;
        echo "Text: " . $savedPortion->getText() . PHP_EOL;
    } finally {
        $reopened->dispose();
    }
} finally {
    $presentation->dispose();
}
```

이 PPTX 라운드 트립 후 유형은 `custom-report-id`이고 텍스트는 `Report-042`입니다. `Y-m-d`와 같은 문자열을 전달하면 필드 유형 이름이 지정될 뿐, 사용자 정의 날짜 형식을 구성하지는 못합니다. 임의 형식의 고정 날짜가 필요하면 일반 텍스트를 사용하십시오.

## **날짜/시간 필드 검사, 수정, 제거**

[Field::setType](https://reference.aspose.com/slides/ko/php-java/aspose.slides/field/#setType)을 사용해 기존 필드를 변경하십시오. 필드 유형에 접근하기 전에 필드가 존재하는지 확인하세요. 자동 업데이트를 중지하려면 [Portion::removeField](https://reference.aspose.com/slides/ko/php-java/aspose.slides/portion/#removeField)를 호출하십시오. 이렇게 하면 필드 연관이 제거되면서 해당 부분과 현재 텍스트는 유지됩니다. 특정 고정값이 필요하면 필드 제거 후 해당 텍스트를 할당하세요.

날짜/시간 필드 처리와 관련된 API 설정은 [Presentation::setCurrentDateTime](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/#setCurrentDateTime)를 참조하십시오. 아래 예제는 필드를 일반 텍스트로 변환할 때 명시적인 승인 날짜를 사용합니다.

[sample.pptx](sample.pptx)를 다운로드하여 JavaBridge 작업 디렉터리에 배치하거나 프레젠테이션 생성자에 절대 경로를 전달하십시오. 여기에는 `UpdatedAt`와 `ApprovedDate`라는 두 개의 명명된 텍스트 도형이 있으며, 각각 날짜/시간 필드와 일반 텍스트 라벨을 포함합니다. 다음 예제는 일반 슬라이드의 최상위 텍스트 도형을 순회합니다. 날짜/시간 필드를 길게 표시되는 날짜 형식으로 변경하고 이탤릭체로 만들면서 다른 서식은 보존합니다. `ApprovedDate`의 필드만 고정 텍스트가 됩니다.

샘플은 내장된 내부 식별자 `datetime` 및 `datetime1`‑`datetime13`을 인식합니다. 그룹, 표, 노트, 레이아웃 및 마스터는 자체 텍스트 컨테이너를 순회해야 하며 이 예제 범위에 포함되지 않습니다.

```php
use aspose\slides\FieldType;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $approvalDate = new DateTimeImmutable("2030-04-05");
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");

    for ($slideIndex = 0; $slideIndex < java_values($presentation->getSlides()->size()); $slideIndex++) {

        $slide = $presentation->getSlides()->get_Item($slideIndex);
        for ($shapeIndex = 0; $shapeIndex < java_values($slide->getShapes()->size()); $shapeIndex++) {
            $shape = $slide->getShapes()->get_Item($shapeIndex);
            if (!java_instanceof($shape, $autoShapeClass)) {
                continue;
            }
            $textShape = $shape;
            if (java_is_null($textShape->getTextFrame())) {
                continue;
            }

            for ($paragraphIndex = 0; $paragraphIndex < java_values($textShape->getTextFrame()->getParagraphs()->getCount()); $paragraphIndex++) {

                $paragraph = $textShape->getTextFrame()->getParagraphs()->get_Item($paragraphIndex);
                for ($portionIndex = 0; $portionIndex < java_values($paragraph->getPortions()->getCount()); $portionIndex++) {
                    $portion = $paragraph->getPortions()->get_Item($portionIndex);
                    $field = $portion->getField();
                    if (java_is_null($field)) {
                        continue;
                    }

                    $typeName = java_values($field->getType()->getInternalString());
                    $isDateTime = $typeName != null && preg_match("/\Adatetime([1-9]|1[0-3])?\z/", $typeName) === 1;
                    if (!$isDateTime) {
                        continue;
                    }

                    $field->setType(FieldType::getDateTime3());
                    $portion->getPortionFormat()->setLanguageId("en-US");
                    $portion->getPortionFormat()->setFontItalic(NullableBool::True);

                    if (java_values($textShape->getName()) === "ApprovedDate") {
                        $portion->removeField();
                        $fixedDate = $approvalDate->format("d F Y");
                        $portion->setText($fixedDate);
                    }
                }
            }
        }
    }

    $presentation->save("updated_dates.pptx", SaveFormat::Pptx);

    $reopened = new Presentation("updated_dates.pptx");
    try {
        for ($shapeIndex = 0; $shapeIndex < java_values($reopened->getSlides()->get_Item(0)->getShapes()->size()); $shapeIndex++) {
            $shape = $reopened->getSlides()->get_Item(0)->getShapes()->get_Item($shapeIndex);
            if (!java_instanceof($shape, $autoShapeClass)) {
                continue;
            }
            $textShape = $shape;
            if (java_is_null($textShape->getTextFrame())) {
                continue;
            }
            if (java_values($textShape->getName()) !== "UpdatedAt" && java_values($textShape->getName()) !== "ApprovedDate") {
                continue;
            }

            $portion = $textShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
            $field = $portion->getField();
            $typeName = java_is_null($field) ? "ordinary text" : java_values($field->getType()->getInternalString());
            echo $textShape->getName() . ": " . $typeName . "; " . $portion->getText() . PHP_EOL;
            echo "Italic: " . $portion->getPortionFormat()->getFontItalic() . PHP_EOL;
        }
    } finally {
        $reopened->dispose();
    }
} finally {
    $presentation->dispose();
}
```

다시 열면 `UpdatedAt`은 유형 `datetime3`을 가지며 동적 상태를 유지합니다. `ApprovedDate`에는 필드가 없으며 `05 April 2030` 텍스트가 들어 있습니다. 두 날짜 부분 모두 이탤릭이며 원래 글꼴 크기, 굵게 설정 및 색상은 그대로 유지됩니다. 일반 텍스트 라벨은 변하지 않습니다. 검증은 제공된 샘플에서 두 알려진 도형의 첫 번째 부분을 읽습니다.

## **텍스트 서식 보존**

필드를 추가하거나 유형을 변경하거나 제거할 때 기존 부분을 활용하십시오. 이러한 작업은 해당 부분의 서식을 유지합니다. 예제에서 색상이나 이탤릭에 대해 수행하듯이 필요한 속성만 변경하려면 [Portion::getPortionFormat](https://reference.aspose.com/slides/ko/php-java/aspose.slides/portion/#getPortionFormat)를 사용하십시오.

하나의 필드만 업데이트하려고 전체 텍스트 프레임을 다시 구축하는 것을 피하세요. 이렇게 하면 원래 부분 경계와 개별 서식이 손실될 수 있습니다. 단락, 레이아웃 또는 테마에서 상속된 서식과 명시적으로 설정된 서식을 구분하십시오. 보다 넓은 서식 옵션은 [Text Formatting](/slides/ko/php-java/text-formatting/)를 참조하십시오.

## **필드 및 머리글/바닥글 자리표시자**

필드는 텍스트 부분의 일부입니다. 자리표시자는 푸터나 슬라이드 번호와 같은 프레젠테이션 역할을 가진 도형입니다. 일반 텍스트 상자에 필드를 추가해도 해당 도형이 자리표시자로 변하지는 않습니다.

머리글/바닥글 관리자는 슬라이드, 레이아웃 및 마스터에서 자리표시자 텍스트와 가시성을 제어하며, 종속 슬라이드로 전파됩니다. 사용자 지정 텍스트 상자에 번호 필드가 있으면 슬라이드 번호 자리표시자를 사용하지 않더라도 유용할 수 있습니다. 반대로 자리표시자 가시성을 변경해도 관련 없는 텍스트 상자의 필드는 제거되지 않습니다.

미리 정의된 머리글 및 바닥글 유형은 해당 자리표시자를 만들거나 내용을 제공하지 않습니다. 특히 일반 PowerPoint 슬라이드에는 머리글 자리표시자가 없으며, 머리글은 노트 페이지와 유인물에만 존재합니다. 임의 도형에 있는 머리글 또는 바닥글 필드가 자동으로 자리표시자 관리자를 통해 구성된 텍스트를 얻는다고 가정하지 마세요. 해당 워크플로는 [Presentation Headers and Footers](/slides/ko/php-java/presentation-header-and-footer/)를 참조하십시오.

## **PPTX 및 PPT 제한 사항**

저장 및 다시 연 후 필드 유형과 결과 텍스트를 모두 확인하십시오. 식별자를 보존한다고 해서 애플리케이션이 값을 계산하거나 표시할 수 있다는 증명이 되지는 않습니다.

| 형식 | 필드 동작 및 제한 |
|---|---|
| PPTX | 필드 텍스트와 함께 내부 필드 식별자를 저장합니다. 라운드‑트립 검사에서 위에서 사용한 미리 정의된 유형과 사용자 지정 식별자가 저장·재열림을 모두 버텼습니다. 알 수 없는 사용자 지정 유형은 대체 텍스트를 유지했지만 자동 계산 로직은 획득하지 못했습니다. 다른 애플리케이션은 지원되지 않는 식별자를 다르게 처리할 수 있습니다. |
| PPT | 레거시 필드 표현을 사용하며 호환성이 더 제한됩니다. 라운드‑트립 검사에서 슬라이드 번호와 미리 정의된 날짜/시간 필드는 저장·재열림을 버텼습니다. 일반 슬라이드 텍스트 상자에 있는 사용자 지정 필드는 식별자는 유지되지만 텍스트가 `*` 로 표시되었습니다; 동일 맥락의 헤더 필드도 `*` 를 출력했습니다. 사용자 지정 필드나 지원되지 않는 필드 컨텍스트가 보이는 텍스트를 유지한다는 가정에 의존하지 마세요. |

휴대용 고정 출력이 필요하면 지원되지 않는 필드를 일반 텍스트로 변환하고 저장 전에 원하는 값을 명시적으로 할당하십시오. 이렇게 하면 선택한 텍스트는 보존되지만 자동 업데이트는 의도적으로 중단됩니다. 워크플로에 자체 필드 재계산이 포함된 경우 대상 애플리케이션도 테스트하십시오.

## **FAQ**

**표시된 숫자나 날짜가 필드인지 어떻게 알 수 있나요?**  
[Portion::getField](https://reference.aspose.com/slides/ko/php-java/aspose.slides/portion/#getField)를 검사하십시오. null이 아닌 값이 필드를 식별합니다; 표시된 텍스트만으로는 판단할 수 없습니다.

**필드를 제거하면 텍스트나 서식도 함께 제거되나요?**  
아니요. [removeField](https://reference.aspose.com/slides/ko/php-java/aspose.slides/portion/#removeField)는 기존 부분을 일반 텍스트로 변환합니다. 특정 고정 날짜나 대체 값을 원한다면 필드 제거 후 명시적으로 값을 할당하십시오.

**내부 문자열로 새로운 날짜 형식이나 수식을 정의할 수 있나요?**  
아니요. 이는 필드 유형을 식별할 뿐이며, 알 수 없는 식별자는 평가 로직이나 PHP 날짜 형식 패턴을 제공하지 않습니다. 지원되는 미리 정의된 유형을 사용하거나 값을 직접 일반 텍스트로 서식 지정하십시오.

**프레젠테이션을 저장한 후 다시 확인해야 하는 이유는 무엇인가요?**  
필드 식별자, 계산된 텍스트 및 서식은 각각 별도로 검증해야 합니다. 형식 변환 과정에서 필드 식별자는 유지되더라도 눈에 보이는 결과가 달라질 수 있습니다.
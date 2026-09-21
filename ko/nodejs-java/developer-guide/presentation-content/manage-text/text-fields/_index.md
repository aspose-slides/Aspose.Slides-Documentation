---
title: JavaScript에서 PowerPoint 프레젠테이션의 텍스트 필드 관리
linktitle: 텍스트 필드
type: docs
weight: 52
url: /ko/nodejs-java/text-fields/
keywords:
- 텍스트 필드
- 자동 텍스트
- 슬라이드 번호
- 날짜 및 시간
- 머리글
- 바닥글
- 텍스트 부분
- PowerPoint
- PPT
- PPTX
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js를 사용하여 Java로 PowerPoint 프레젠테이션에서 텍스트 필드를 생성, 검사, 수정 및 제거합니다. 서식을 유지하고 저장된 PPTX 및 PPT 파일을 확인합니다."
---
## **개요**

텍스트 단락은 여러 부분(Porsion)으로 구성됩니다. 일반적인 [Portion](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/portion/)은 리터럴 텍스트를 포함하고; 필드 부분은 또한 [Field](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/field/)를 가지고 있으며, 그 유형은 슬라이드 번호나 날짜와 같은 자동 업데이트 값임을 식별합니다. 두 부분이 동일한 문자를 표시할 수 있지만, 필드가 포함된 부분은 하나뿐입니다.

이를 구분하려면 [Portion.getField](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/portion/#getField)를 사용하십시오: 일반 텍스트의 경우 `null`입니다. [Portion.addField](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/portion/#addField)은 기존 부분을 필드로 변환합니다. 값 변환 시 라벨이 함께 교체되지 않도록 라벨과 동적 값을 별개의 부분에 유지하십시오.

이 가이드는 텍스트 내부의 필드, 필드 서식 및 PPTX와 PPT 저장에 대해 다룹니다. 텍스트 프레임 및 단락에 대해서는 [Manage Text](/slides/ko/nodejs-java/manage-text/)를 참조하십시오.

## **슬라이드 번호 필드 만들기**

다음 전체 예제는 리터럴 `Slide ` 라벨 뒤에 자동 업데이트되는 번호가 포함된 텍스트 상자를 생성합니다. 필드를 추가하기 전에 번호의 크기, 굵기 및 색을 설정하고, 저장된 프레젠테이션을 다시 열어 필드 유형, 텍스트 및 서식을 확인합니다. 입력 파일은 필요하지 않습니다.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 40, 40, 240, 50);
    shape.addTextFrame("Slide ");
    const paragraph = shape.getTextFrame().getParagraphs().get_Item(0);

    const numberPortion = new aspose.slides.Portion();
    const numberColor = java.newInstanceSync("java.awt.Color", 0, 0, 139);
    numberPortion.getPortionFormat().setFontHeight(24);
    numberPortion.getPortionFormat().setFontBold(java.newByte(aspose.slides.NullableBool.True));
    numberPortion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    numberPortion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(numberColor);
    paragraph.getPortions().add(numberPortion);
    numberPortion.addField(aspose.slides.FieldType.getSlideNumber());

    presentation.save("slide_number.pptx", aspose.slides.SaveFormat.Pptx);

    const reopened = new aspose.slides.Presentation("slide_number.pptx");
    try {
        const savedShape = reopened.getSlides().get_Item(0).getShapes().get_Item(0);
        const savedNumber = savedShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(1);
        const savedField = savedNumber.getField();
        const hasNumberField = savedField != null && aspose.slides.FieldType.getSlideNumber().getInternalString() === savedField.getType().getInternalString();
        const format = savedNumber.getPortionFormat();
        let formattingPreserved = format.getFontHeight() == 24 && format.getFontBold() == aspose.slides.NullableBool.True;
        formattingPreserved = formattingPreserved && format.getFillFormat().getSolidFillColor().getColor().getRGB() == numberColor.getRGB();

        console.log("Text: " + savedShape.getTextFrame().getText());
        console.log("Slide number field: " + hasNumberField);
        console.log("Formatting preserved: " + formattingPreserved);
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

새 프레젠테이션은 슬라이드 번호 1부터 시작하므로 텍스트는 `Slide 1`이며, 두 검사는 모두 `true`를 출력합니다. 다시 열었을 때 번호는 필드로 남아있으며, 리터럴 `1`이 아닙니다. 검증에 사용된 인덱스는 이 예제에서 생성된 도형과 부분을 가리킵니다.

## **필드 유형 선택**

[FieldType](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/fieldtype/)은 미리 정의된 값을 얻기 위한 다음 메서드를 제공합니다. 적절한 값을 [addField](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/portion/#addField)에 전달하십시오.

| 메서드 | 목적 |
|---|---|
| [getSlideNumber](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/fieldtype/#getSlideNumber) | 현재 슬라이드 번호. |
| [getDateTime](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/fieldtype/#getDateTime) | 렌더링 애플리케이션의 기본 형식으로 날짜/시간. |
| [getDateTime1](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/fieldtype/#getDateTime1)–[getDateTime9](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/fieldtype/#getDateTime9) | 미리 정의된 날짜 또는 결합된 날짜/시간 형식. |
| [getDateTime10](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/fieldtype/#getDateTime10)–[getDateTime13](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/fieldtype/#getDateTime13) | 초와 12시간 시계 옵션을 포함한 미리 정의된 시간 형식. |
| [getHeader](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/fieldtype/#getHeader) | 머리글 필드; 아래의 자리 표시자와 형식 제한을 참조하십시오. |
| [getFooter](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/fieldtype/#getFooter) | 바닥글 필드. |

예를 들어, [getDateTime3](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/fieldtype/#getDateTime3)은 영어로 일, 전체 월 이름 및 연도를 나타냅니다. 이는 임의의 날짜 형식 문자열이 아니라 미리 정의된 필드 형식입니다. [setLanguageId](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/baseportionformat/#setLanguageId)로 설정한 언어와 프레젠테이션을 처리하는 애플리케이션에 따라 표시 결과가 달라질 수 있습니다.

## **내부 문자열에서 필드 생성**

[addField](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/portion/#addField)의 문자열 오버로드는 내부 필드 식별자를 허용합니다. 미리 정의된 값이 없는 다른 애플리케이션에서 제공한 식별자를 보존해야 할 때 사용하십시오. 또한 식별자를 사용해 [FieldType](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/fieldtype/)을 만들 수 있습니다. [FieldType.getInternalString](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/fieldtype/#getInternalString)은 해당 식별자를 검사를 위해 노출합니다.

이 예제는 애플리케이션 고유 `custom-report-id` 필드를 `Report-042` 대체 텍스트와 함께 저장합니다. 해당 식별자는 계산을 등록하지 않으며: Aspose.Slides는 알 수 없는 유형에 대한 보고서 ID를 생성하지 않습니다. 이 식별자를 이해하는 애플리케이션이 의미를 제공하고 값을 업데이트해야 합니다.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 40, 40, 300, 50);
    shape.addTextFrame("Report-042");
    const portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.addField("custom-report-id");

    presentation.save("custom_field.pptx", aspose.slides.SaveFormat.Pptx);

    const reopened = new aspose.slides.Presentation("custom_field.pptx");
    try {
        const savedShape = reopened.getSlides().get_Item(0).getShapes().get_Item(0);
        const savedPortion = savedShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
        const savedField = savedPortion.getField();
        const typeName = savedField == null ? "ordinary text" : savedField.getType().getInternalString();
        console.log("Type: " + typeName);
        console.log("Text: " + savedPortion.getText());
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

PPTX 라운드 트립 후, 유형은 `custom-report-id`이고 텍스트는 `Report-042`입니다. `yyyy-MM-dd`와 같은 문자열을 전달하면 필드 유형의 이름이 지정될 뿐, 사용자 정의 날짜 형식을 설정하지는 않습니다. 임의 형식의 고정 날짜가 필요하면 일반 텍스트를 사용하십시오.

## **날짜/시간 필드 검사, 수정 및 제거**

기존 필드는 [Field.setType](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/field/#setType)를 통해 변경합니다. 유형에 접근하기 전에 필드가 존재하는지 확인하십시오. 자동 업데이트를 중지하려면 [Portion.removeField](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/portion/#removeField)를 호출하십시오. 이렇게 하면 필드 연결은 제거되지만 부분 및 현재 텍스트는 유지됩니다. 특정 고정 값이 필요하면 필드를 제거한 뒤 해당 텍스트를 할당하십시오.

날짜/시간 필드 처리를 위한 API 설정은 [Presentation.setCurrentDateTime](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation/#setCurrentDateTime)를 참조하십시오. 아래 예제는 필드를 일반 텍스트로 변환할 때 명시적인 승인 날짜를 사용합니다.

[sample.pptx](sample.pptx)를 다운로드하여 작업 디렉터리에 배치하십시오. 여기에는 `UpdatedAt` 및 `ApprovedDate`라는 두 개의 명명된 텍스트 도형이 들어 있으며, 각각 날짜/시간 필드와 일반 텍스트 라벨을 포함합니다. 다음 예제는 일반 슬라이드의 최상위 텍스트 도형을 순회합니다. 날짜/시간 필드를 긴 날짜 형식으로 변경하고 이탤릭체로 만들면서 다른 서식은 유지합니다. `ApprovedDate`의 필드만 고정 텍스트가 됩니다.

승인 날짜는 2030년 4월 5일이며, JavaScript 월 인덱스는 0부터 시작하므로 4월은 `3`입니다. 날짜를 로컬 시간대와 무관하게 유지하기 위해 구성 및 서식 모두 UTC를 사용합니다.

샘플은 내장된 내부 식별자 `datetime` 및 `datetime1`~`datetime13`을 인식합니다. 그룹, 표, 노트, 레이아웃 및 마스터는 자체 텍스트 컨테이너를 순회해야 하므로 이 예제의 범위에 포함되지 않습니다.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const approvalDate = new Date(Date.UTC(2030, 3, 5));
    const dateFormat = new Intl.DateTimeFormat("en-GB", { day: "2-digit", month: "long", year: "numeric", timeZone: "UTC" });

    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);
            if (!java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                continue;
            }
            if (shape.getTextFrame() == null) {
                continue;
            }

            for (let paragraphIndex = 0; paragraphIndex < shape.getTextFrame().getParagraphs().getCount(); paragraphIndex++) {
                const paragraph = shape.getTextFrame().getParagraphs().get_Item(paragraphIndex);
                for (let portionIndex = 0; portionIndex < paragraph.getPortions().getCount(); portionIndex++) {
                    const portion = paragraph.getPortions().get_Item(portionIndex);
                    const field = portion.getField();
                    if (field == null) {
                        continue;
                    }

                    const typeName = field.getType().getInternalString();
                    const isDateTime = typeName != null && /^datetime([1-9]|1[0-3])?$/.test(typeName);
                    if (!isDateTime) {
                        continue;
                    }

                    field.setType(aspose.slides.FieldType.getDateTime3());
                    portion.getPortionFormat().setLanguageId("en-US");
                    portion.getPortionFormat().setFontItalic(java.newByte(aspose.slides.NullableBool.True));

                    if (shape.getName() === "ApprovedDate") {
                        portion.removeField();
                        const fixedDate = dateFormat.format(approvalDate);
                        portion.setText(fixedDate);
                    }
                }
            }
        }
    }

    presentation.save("updated_dates.pptx", aspose.slides.SaveFormat.Pptx);

    const reopened = new aspose.slides.Presentation("updated_dates.pptx");
    try {
        for (let shapeIndex = 0; shapeIndex < reopened.getSlides().get_Item(0).getShapes().size(); shapeIndex++) {
            const shape = reopened.getSlides().get_Item(0).getShapes().get_Item(shapeIndex);
            if (!java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                continue;
            }
            if (shape.getTextFrame() == null) {
                continue;
            }
            if (shape.getName() !== "UpdatedAt" && shape.getName() !== "ApprovedDate") {
                continue;
            }

            const portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
            const field = portion.getField();
            const typeName = field == null ? "ordinary text" : field.getType().getInternalString();
            console.log(shape.getName() + ": " + typeName + "; " + portion.getText());
            console.log("Italic: " + portion.getPortionFormat().getFontItalic());
        }
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

다시 열었을 때, `UpdatedAt`은 유형 `datetime3`을 가지며 동적으로 유지됩니다. `ApprovedDate`는 필드가 없고 `05 April 2030` 텍스트를 포함합니다. 두 날짜 부분 모두 이탤릭이며, 원래의 글꼴 크기, 굵기 설정 및 색상은 그대로 유지됩니다. 일반 텍스트 라벨은 변경되지 않습니다. 검증은 제공된 샘플의 두 알려진 도형의 첫 번째 부분을 읽습니다.

## **텍스트 서식 유지**

필드를 추가하거나 유형을 변경하거나 제거할 때 기존 부분을 활용하십시오. 이러한 작업은 해당 부분의 서식을 유지합니다. 예제에서 색상이나 이탤릭에 대해 수행한 것처럼, 필요한 속성만 변경하려면 [Portion.getPortionFormat](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/portion/#getPortionFormat)를 사용하십시오.

하나의 필드만 업데이트하기 위해 전체 텍스트 프레임을 재구성하는 것을 피하십시오: 이렇게 하면 원래 부분 경계와 개별 서식을 잃을 수 있습니다. 또한 단락, 레이아웃 또는 테마에서 상속된 서식과 명시적으로 설정된 서식을 구분하십시오. 보다 광범위한 서식 옵션은 [Text Formatting](/slides/ko/nodejs-java/text-formatting/)을 참조하십시오.

## **필드와 머리글/바닥글 자리 표시자**

필드는 텍스트 부분의 일부입니다. 자리 표시자는 바닥글이나 슬라이드 번호와 같은 프레젠테이션 역할을 가진 도형입니다. 일반 텍스트 상자에 필드를 추가해도 해당 도형이 자리 표시자로 변환되지 않습니다.

머리글/바닥글 관리자는 슬라이드, 레이아웃 및 마스터에서 자리 표시자 텍스트와 가시성을 제어하며, 종속 슬라이드에 전파됩니다. 따라서 슬라이드 번호 자리 표시자를 사용하지 않더라도 사용자 정의 텍스트 상자에 번호 필드를 넣는 것이 유용할 수 있습니다. 반대로, 자리 표시자 가시성을 변경해도 관련 없는 텍스트 상자에서 필드는 제거되지 않습니다.

미리 정의된 머리글 및 바닥글 유형은 해당 자리 표시자를 생성하거나 내용을 제공하지 않습니다. 특히 일반 PowerPoint 슬라이드에는 머리글 자리 표시자가 없으며, 머리글은 노트 페이지와 유인물에 속합니다. 임의의 도형에 있는 머리글이나 바닥글 필드가 자리 표시자 관리자에 의해 구성된 텍스트를 자동으로 가져온다고 가정하지 마십시오. 해당 워크플로우에 대해서는 [Presentation Headers and Footers](/slides/ko/nodejs-java/presentation-header-and-footer/)를 참조하십시오.

## **PPTX 및 PPT 제한 사항**

저장 및 다시 연 후 필드 유형과 결과 텍스트를 모두 확인하십시오. 식별자를 보존한다고 해서 애플리케이션이 값을 계산하거나 표시할 수 있다는 것을 증명하지는 않습니다.

| 포맷 | 필드 동작 및 제한 사항 |
|---|---|
| PPTX | 내부 필드 식별자를 필드 텍스트와 함께 저장합니다. 라운드 트립 검사에서 위에서 사용한 미리 정의된 유형 및 사용자 정의 식별자가 저장 및 재개방 후에도 유지되었습니다. 알 수 없는 사용자 정의 유형은 대체 텍스트를 유지했으며 자동 계산 로직을 얻게 되지는 않았습니다. 다른 애플리케이션은 지원되지 않는 식별자를 다르게 처리할 수 있습니다. |
| PPT | 레거시 필드 표현을 사용하며 호환성이 더 제한적입니다. 라운드 트립 검사에서 슬라이드 번호와 미리 정의된 날짜/시간 필드는 저장 및 재개방 후에도 유지되었습니다. 일반 슬라이드 텍스트 상자의 사용자 정의 필드는 식별자는 유지되지만 텍스트가 `*`로 열렸으며, 동일 컨텍스트의 머리글 필드도 `*`를 생성했습니다. 사용자 정의 필드나 지원되지 않는 필드 컨텍스트가 표시 텍스트를 유지한다고 신뢰하지 마십시오. |

휴대용 고정 출력을 위해서는 지원되지 않는 필드를 일반 텍스트로 변환하고 저장하기 전에 원하는 값을 명시적으로 할당하십시오. 이렇게 하면 선택한 텍스트는 유지되지만 자동 업데이트는 의도적으로 중단됩니다. 워크플로우에 대상 애플리케이션의 자체 필드 재계산이 포함되는 경우에도 해당 애플리케이션을 테스트하십시오.

## **FAQ**

**표시된 번호나 날짜가 필드인지 어떻게 확인합니까?**

[Portion.getField](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/portion/#getField)를 검사하십시오. null이 아닌 값은 필드임을 식별하며, 표시된 텍스트만으로는 판단할 수 없습니다.

**필드를 제거하면 텍스트나 서식도 함께 제거되나요?**

아니요. [removeField](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/portion/#removeField)은 기존 부분을 일반 텍스트로 변환합니다. 특정 고정 날짜나 대체 값이 필요하면 이후에 명시적인 값을 할당하십시오.

**내부 문자열로 새로운 날짜 형식이나 수식을 정의할 수 있나요?**

아니요. 이는 필드 유형을 식별할 뿐입니다. 알 수 없는 식별자는 평가기나 날짜 형식 패턴을 제공하지 않습니다. 지원되는 미리 정의된 유형을 사용하거나 값을 일반 텍스트로 직접 서식 지정하십시오.

**프레젠테이션을 저장한 후 다시 확인해야 하는 이유는 무엇인가요?**

필드 식별자, 계산된 텍스트 및 서식은 각각 별도로 검증해야 합니다. 형식 변환은 필드 식별자가 여전히 존재해도 표시 결과를 변경할 수 있습니다.
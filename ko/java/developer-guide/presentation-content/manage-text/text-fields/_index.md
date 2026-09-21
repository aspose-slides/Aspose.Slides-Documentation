---
title: Java에서 PowerPoint 프레젠테이션의 텍스트 필드 관리
linktitle: 텍스트 필드
type: docs
weight: 52
url: /ko/java/text-fields/
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
- Java
- Aspose.Slides
description: "Aspose.Slides for Java를 사용하여 PowerPoint 프레젠테이션에서 텍스트 필드를 생성, 검사, 수정 및 제거합니다. 서식을 보존하고 저장된 PPTX 및 PPT 파일을 검증합니다."
---
## **개요**

텍스트 단락은 여러 부분으로 구성됩니다. 일반적인 [IPortion](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iportion/)은 리터럴 텍스트를 포함하고, 필드 부분은 자동으로 업데이트되는 값(예: 슬라이드 번호 또는 날짜)을 식별하는 유형을 갖는 [IField](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ifield/)를 추가로 가집니다. 두 부분이 동일한 문자를 표시할 수 있지만 하나만 필드를 포함합니다.

[IPortion.getField](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iportion/#getField--)을 사용하여 구분합니다: 일반 텍스트인 경우 `null`입니다. [IPortion.addField](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iportion/#addField-com.aspose.slides.IFieldType-)는 기존 부분을 필드로 변환합니다. 라벨과 동적 값을 별도 부분에 보관하면 값을 변환할 때 라벨까지 교체되지 않습니다.

이 가이드는 텍스트 내부 필드, 해당 서식 및 PPTX와 PPT에서 저장하는 방법을 다룹니다. 텍스트 프레임 및 단락에 대해서는 [텍스트 관리](/slides/ko/java/manage-text/)를 참조하십시오.

## **슬라이드 번호 필드 만들기**

다음 완전한 예제는 리터럴 `Slide ` 라벨 뒤에 자동 업데이트되는 번호가 포함된 텍스트 상자를 생성합니다. 필드를 추가하기 전에 번호의 크기, 굵기 및 색상을 설정하고, 저장된 프레젠테이션을 다시 열어 필드 유형, 텍스트 및 서식을 확인합니다. 입력 파일은 필요하지 않습니다.

```java
import java.awt.Color;
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 240, 50);
    shape.addTextFrame("Slide ");
    IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);

    Portion numberPortion = new Portion();
    Color numberColor = new Color(0, 0, 139);
    numberPortion.getPortionFormat().setFontHeight(24);
    numberPortion.getPortionFormat().setFontBold(NullableBool.True);
    numberPortion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    numberPortion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(numberColor);
    paragraph.getPortions().add(numberPortion);
    numberPortion.addField(FieldType.getSlideNumber());

    presentation.save("slide_number.pptx", SaveFormat.Pptx);

    Presentation reopened = new Presentation("slide_number.pptx");
    try {
        IAutoShape savedShape = (IAutoShape) reopened.getSlides().get_Item(0).getShapes().get_Item(0);
        IPortion savedNumber = savedShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(1);
        IField savedField = savedNumber.getField();
        boolean hasNumberField = savedField != null && FieldType.getSlideNumber().getInternalString().equals(savedField.getType().getInternalString());
        IPortionFormat format = savedNumber.getPortionFormat();
        boolean formattingPreserved = format.getFontHeight() == 24 && format.getFontBold() == NullableBool.True;
        formattingPreserved &= format.getFillFormat().getSolidFillColor().getColor().getRGB() == numberColor.getRGB();

        System.out.println("Text: " + savedShape.getTextFrame().getText());
        System.out.println("Slide number field: " + hasNumberField);
        System.out.println("Formatting preserved: " + formattingPreserved);
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

새 프레젠테이션은 슬라이드 번호 1부터 시작하므로 텍스트는 `Slide 1`이며 두 검사는 모두 `true`를 출력합니다. 번호는 다시 열어도 필드로 남아 있으며 리터럴 `1`이 아닙니다. 검증에 사용된 형변환 및 인덱스는 이 예제에서 만든 도형과 부분을 가리킵니다.

## **필드 유형 선택**

[FieldType](https://reference.aspose.com/slides/ko/java/com.aspose.slides/fieldtype/)은 [IFieldType](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ifieldtype/)을 구현하며 미리 정의된 값을 얻기 위한 다음 메서드를 제공합니다. 적절한 값을 [addField](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iportion/#addField-com.aspose.slides.IFieldType-)에 전달하십시오.

| 메서드 | 목적 |
|---|---|
| [getSlideNumber](https://reference.aspose.com/slides/ko/java/com.aspose.slides/fieldtype/#getSlideNumber--) | 현재 슬라이드 번호 |
| [getDateTime](https://reference.aspose.com/slides/ko/java/com.aspose.slides/fieldtype/#getDateTime--) | 렌더링 애플리케이션의 기본 형식으로 표시되는 날짜/시간 |
| [getDateTime1](https://reference.aspose.com/slides/ko/java/com.aspose.slides/fieldtype/#getDateTime1--)–[getDateTime9](https://reference.aspose.com/slides/ko/java/com.aspose.slides/fieldtype/#getDateTime9--) | 미리 정의된 날짜 또는 결합된 날짜/시간 형식 |
| [getDateTime10](https://reference.aspose.com/slides/ko/java/com.aspose.slides/fieldtype/#getDateTime10--)–[getDateTime13](https://reference.aspose.com/slides/ko/java/com.aspose.slides/fieldtype/#getDateTime13--) | 초와 12시간 시계를 포함하는 미리 정의된 시간 형식 |
| [getHeader](https://reference.aspose.com/slides/ko/java/com.aspose.slides/fieldtype/#getHeader--) | 헤더 필드(아래 자리 표시자 및 형식 제한 참조) |
| [getFooter](https://reference.aspose.com/slides/ko/java/com.aspose.slides/fieldtype/#getFooter--) | 바닥글 필드 |

예를 들어, [getDateTime3](https://reference.aspose.com/slides/ko/java/com.aspose.slides/fieldtype/#getDateTime3--)은 영어로 일, 전체 월 이름, 연도를 나타냅니다. 이는 임의의 Java 날짜 형식 문자열이 아닌 미리 정의된 필드 형식입니다. [setLanguageId](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-)로 설정한 언어와 프레젠테이션을 처리하는 애플리케이션에 따라 표시 결과가 달라질 수 있습니다.

## **내부 문자열에서 필드 만들기**

[addField](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iportion/#addField-java.lang.String-)의 문자열 오버로드는 내부 필드 식별자를 받아들입니다. 다른 애플리케이션이 제공한 식별자를 보존하면서 미리 정의된 값이 없는 경우에 사용하십시오. 또한 식별자를 사용하여 [FieldType](https://reference.aspose.com/slides/ko/java/com.aspose.slides/fieldtype/#FieldType-java.lang.String-)을 생성할 수 있습니다. [IFieldType.getInternalString](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ifieldtype/#getInternalString--)은 해당 식별자를 검토용으로 노출합니다.

이 예제는 `custom-report-id` 필드를 애플리케이션 전용으로 저장하고 대체 텍스트 `Report-042`를 지정합니다. 식별자는 계산을 등록하지 않으며, Aspose.Slides는 알 수 없는 유형에 대해 보고서 ID를 생성하지 않습니다. 이 식별자를 이해하는 애플리케이션이 의미를 제공하고 값을 업데이트해야 합니다.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    IAutoShape shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 300, 50);
    shape.addTextFrame("Report-042");
    IPortion portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.addField("custom-report-id");

    presentation.save("custom_field.pptx", SaveFormat.Pptx);

    Presentation reopened = new Presentation("custom_field.pptx");
    try {
        IAutoShape savedShape = (IAutoShape) reopened.getSlides().get_Item(0).getShapes().get_Item(0);
        IPortion savedPortion = savedShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
        IField savedField = savedPortion.getField();
        String typeName = savedField == null ? "ordinary text" : savedField.getType().getInternalString();
        System.out.println("Type: " + typeName);
        System.out.println("Text: " + savedPortion.getText());
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

이 PPTX 라운드 트립 후, 유형은 `custom-report-id`이고 텍스트는 `Report-042`입니다. `yyyy-MM-dd`와 같은 문자열을 전달하면 필드 유형이 지정되지만 사용자 지정 날짜 형식이 구성되지는 않습니다. 임의 형식의 고정 날짜가 필요하면 일반 텍스트를 사용하십시오.

## **날짜/시간 필드 검사, 수정 및 제거**

[IField.setType](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ifield/#setType-com.aspose.slides.IFieldType-)을 통해 기존 필드를 변경합니다. 필드가 존재하는지 확인한 뒤 유형에 접근하십시오. 자동 업데이트를 중지하려면 [IPortion.removeField](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iportion/#removeField--)를 호출합니다. 이 메서드는 현재 텍스트는 유지하면서 필드 연관성을 제거합니다. 특정 고정 값을 원한다면 필드를 제거한 뒤 해당 텍스트를 할당하십시오.

날짜/시간 필드 처리와 관련된 API 설정은 [Presentation.setCurrentDateTime](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentation/#setCurrentDateTime-java.util.Date-)를 참조하십시오. 아래 예제는 필드를 일반 텍스트로 변환할 때 명시적인 승인 날짜를 사용합니다.

[ sample.pptx ](sample.pptx) 파일을 다운로드하고 작업 디렉터리에 배치하십시오. 이 파일에는 두 개의 명명된 텍스트 도형 `UpdatedAt`와 `ApprovedDate`가 각각 날짜/시간 필드와 일반 텍스트 라벨을 포함합니다. 아래 예제는 일반 슬라이드에서 최상위 텍스트 도형을 순회합니다. 날짜/시간 필드를 긴 날짜 형식으로 변경하고 이탤릭체로 만들면서 다른 서식은 유지합니다. `ApprovedDate`에 있는 필드만 고정 텍스트가 됩니다.

샘플은 내부 식별자 `datetime` 및 `datetime1`부터 `datetime13`까지를 인식합니다. 그룹, 표, 노트, 레이아웃 및 마스터는 자체 텍스트 컨테이너를 순회해야 하며 이 예제 범위에 포함되지 않습니다.

```java
import java.time.LocalDate;
import java.time.format.DateTimeFormatter;
import java.util.Locale;
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    LocalDate approvalDate = LocalDate.of(2030, 4, 5);
    DateTimeFormatter dateFormat = DateTimeFormatter.ofPattern("dd MMMM yyyy", Locale.US);

    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (!(shape instanceof IAutoShape)) {
                continue;
            }
            IAutoShape textShape = (IAutoShape) shape;
            if (textShape.getTextFrame() == null) {
                continue;
            }

            for (IParagraph paragraph : textShape.getTextFrame().getParagraphs()) {
                for (IPortion portion : paragraph.getPortions()) {
                    IField field = portion.getField();
                    if (field == null) {
                        continue;
                    }

                    String typeName = field.getType().getInternalString();
                    boolean isDateTime = typeName != null && typeName.matches("datetime([1-9]|1[0-3])?");
                    if (!isDateTime) {
                        continue;
                    }

                    field.setType(FieldType.getDateTime3());
                    portion.getPortionFormat().setLanguageId("en-US");
                    portion.getPortionFormat().setFontItalic(NullableBool.True);

                    if ("ApprovedDate".equals(textShape.getName())) {
                        portion.removeField();
                        String fixedDate = approvalDate.format(dateFormat);
                        portion.setText(fixedDate);
                    }
                }
            }
        }
    }

    presentation.save("updated_dates.pptx", SaveFormat.Pptx);

    Presentation reopened = new Presentation("updated_dates.pptx");
    try {
        for (IShape shape : reopened.getSlides().get_Item(0).getShapes()) {
            if (!(shape instanceof IAutoShape)) {
                continue;
            }
            IAutoShape textShape = (IAutoShape) shape;
            if (textShape.getTextFrame() == null) {
                continue;
            }
            if (!"UpdatedAt".equals(textShape.getName()) && !"ApprovedDate".equals(textShape.getName())) {
                continue;
            }

            IPortion portion = textShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
            IField field = portion.getField();
            String typeName = field == null ? "ordinary text" : field.getType().getInternalString();
            System.out.println(textShape.getName() + ": " + typeName + "; " + portion.getText());
            System.out.println("Italic: " + portion.getPortionFormat().getFontItalic());
        }
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

다시 열면 `UpdatedAt`는 유형 `datetime3`을 가지고 동적으로 유지됩니다. `ApprovedDate`는 필드가 없으며 `05 April 2030`을 포함합니다. 두 날짜 부분 모두 이탤릭체이며 원래 글꼴 크기, 굵게 설정 및 색상은 그대로 유지됩니다. 일반 텍스트 라벨은 변경되지 않습니다. 검증은 제공된 샘플에서 두 알려진 도형의 첫 번째 부분을 읽습니다.

## **텍스트 서식 유지**

필드를 추가하거나 유형을 변경하거나 제거할 때 기존 부분을 사용하십시오. 이러한 작업은 해당 부분의 서식을 유지합니다. 색상 또는 이탤릭과 같이 필요한 속성만 변경하려면 [IPortion.getPortionFormat](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iportion/#getPortionFormat--)를 사용하십시오.

하나의 필드만 업데이트하기 위해 전체 텍스트 프레임을 재구성하지 마십시오. 그렇게 하면 원래 부분 경계와 개별 서식이 손실될 수 있습니다. 또한 단락, 레이아웃 또는 테마에서 상속된 서식과 명시적으로 설정된 서식을 구분하십시오. 보다 폭넓은 서식 옵션은 [텍스트 서식](/slides/ko/java/text-formatting/)을 참고하십시오.

## **필드와 머리글/바닥글 자리 표시자**

필드는 텍스트 부분의 일부입니다. 자리 표시자는 머리글이나 바닥글과 같이 프레젠테이션 역할을 갖는 도형입니다. 일반 텍스트 상자에 필드를 추가해도 그 도형이 자리 표시자로 변환되지 않습니다.

머리글/바닥글 관리자는 슬라이드, 레이아웃 및 마스터에서 자리 표시자 텍스트와 가시성을 제어하며 종속 슬라이드로 전파됩니다. 사용자 지정 텍스트 상자에 숫자 필드를 넣으면 슬라이드 번호 자리 표시자를 사용하지 않을 때도 유용합니다. 반대로 자리 표시자 가시성을 변경해도 무관한 텍스트 상자의 필드가 제거되지는 않습니다.

미리 정의된 머리글 및 바닥글 유형은 해당 자리 표시자를 만들거나 내용을 제공하지 않습니다. 특히 일반 PowerPoint 슬라이드에는 머리글 자리 표시자가 없으며, 머리글은 노트 페이지와 유인물에만 존재합니다. 임의 도형에 있는 머리글 또는 바닥글 필드가 자동으로 자리 표시자 관리자를 통해 설정된 텍스트를 얻는다고 가정하지 마십시오. 해당 워크플로는 [프레젠테이션 머리글 및 바닥글](/slides/ko/java/presentation-header-and-footer/)을 참조하십시오.

## **PPTX 및 PPT 제한 사항**

저장 및 재열기 후 필드 유형과 결과 텍스트를 모두 확인하십시오. 식별자를 보존한다고 해서 애플리케이션이 값을 계산하거나 표시할 수 있다는 보장은 없습니다.

| 포맷 | 필드 동작 및 제한 사항 |
|---|---|
| PPTX | 내부 필드 식별자를 필드 텍스트와 함께 저장합니다. 라운드 트립 검사에서 위에서 사용한 미리 정의된 유형과 사용자 지정 식별자가 저장 및 재열기 후에도 유지되었습니다. 알 수 없는 사용자 지정 유형은 대체 텍스트를 유지했으며 자동 계산 로직을 얻지 못했습니다. 다른 애플리케이션은 지원되지 않는 식별자를 다르게 처리할 수 있습니다. |
| PPT | 레거시 필드 표현을 사용하며 호환성이 더 제한됩니다. 라운드 트립 검사에서 슬라이드 번호와 미리 정의된 날짜/시간 필드는 저장 및 재열기 후에도 유지되었습니다. 일반 슬라이드 텍스트 상자에 있는 사용자 지정 필드는 식별자는 유지되지만 텍스트가 `*`로 표시되었습니다. 동일한 컨텍스트의 헤더 필드도 `*`를 출력했습니다. 사용자 지정 필드나 지원되지 않는 필드 컨텍스트가 표시 텍스트를 유지한다고 가정하지 마십시오. |

이동식이고 고정된 출력을 위해서는 지원되지 않는 필드를 일반 텍스트로 변환하고 저장 전에 원하는 값을 명시적으로 할당하십시오. 이렇게 하면 선택한 텍스트가 보존되지만 자동 업데이트는 의도적으로 중지됩니다. 필드 재계산이 워크플로의 일부인 경우 대상 애플리케이션에서도 테스트하십시오.

## **FAQ**

**표시된 번호나 날짜가 필드인지 어떻게 확인합니까?**

[IPortion.getField](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iportion/#getField--)를 검사하십시오. null이 아닌 값이 필드를 식별합니다; 표시된 텍스트만으로는 판단할 수 없습니다.

**필드를 제거하면 텍스트나 서식도 제거됩니까?**

아니요. [removeField](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iportion/#removeField--)은 기존 부분을 일반 텍스트로 변환합니다. 특정 고정 날짜나 대체 값을 원한다면 이후에 명시적인 값을 할당하십시오.

**내부 문자열이 새로운 날짜 형식이나 수식을 정의할 수 있습니까?**

아니요. 이는 필드 유형을 식별할 뿐이며, 알 수 없는 식별자는 평가기나 Java 날짜 형식 패턴을 제공하지 않습니다. 지원되는 미리 정의된 유형을 사용하거나 값을 직접 일반 텍스트로 포맷하십시오.

**프레젠테이션을 저장한 후 다시 확인해야 하는 이유는?**

필드 식별자, 계산된 텍스트 및 서식은 별개로 검증해야 합니다. 형식 변환은 필드 식별자는 남아 있어도 보이는 결과를 바꿀 수 있습니다.
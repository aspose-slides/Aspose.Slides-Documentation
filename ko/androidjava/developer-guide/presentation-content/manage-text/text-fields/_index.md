---
title: Android에서 PowerPoint 프레젠테이션의 텍스트 필드 관리
linktitle: 텍스트 필드
type: docs
weight: 52
url: /ko/androidjava/text-fields/
keywords:
- 텍스트 필드
- 자동 텍스트
- 슬라이드 번호
- 날짜 및 시간
- 헤더
- 푸터
- 텍스트 파션
- PowerPoint
- PPT
- PPTX
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android를 사용하여 Java로 PowerPoint 프레젠테이션의 텍스트 필드를 만들고, 검사하고, 수정하고, 제거합니다. 형식을 보존하고 저장된 PPTX 및 PPT 파일을 확인합니다."
---
## **개요**

텍스트 단락은 여러 portion으로 구성됩니다. 일반적인 [IPortion](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iportion/)에는 실제 텍스트가 포함됩니다; 필드 portion에는 자동으로 업데이트되는 값(예: 슬라이드 번호 또는 날짜)을 식별하는 유형을 가진 [IField](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ifield/)가 추가로 포함됩니다. 두 개의 portion이 동일한 문자를 표시할 수 있지만, 필드를 포함하는 것은 하나뿐입니다.

이들을 구분하려면 [IPortion.getField](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iportion/#getField--)를 사용하세요: 일반 텍스트에서는 `null`을 반환합니다. [IPortion.addField](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iportion/#addField-com.aspose.slides.IFieldType-) 은 기존 portion을 필드로 변환합니다. 값과 레이블을 별개의 portion에 보관하면 값을 변환해도 레이블이 교체되지 않습니다.

이 가이드는 텍스트 내부의 필드, 해당 형식 지정 및 PPTX와 PPT로 저장하는 방법을 다룹니다. 텍스트 프레임과 단락에 대해서는 [Manage Text](/slides/ko/androidjava/manage-text/)를 참고하십시오.

## **슬라이드 번호 필드 만들기**

다음 완전한 예제는 `Slide ` 레이블(리터럴) 뒤에 자동으로 업데이트되는 번호가 붙은 텍스트 상자를 만듭니다. 필드를 추가하기 전에 번호의 크기, 굵기 및 색상을 설정하고, 저장된 프레젠테이션을 다시 열어 필드 유형, 텍스트 및 형식을 확인합니다. 입력 파일이 필요하지 않습니다.

```java
import android.graphics.Color;
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 240, 50);
    shape.addTextFrame("Slide ");
    IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);

    Portion numberPortion = new Portion();
    int numberColor = Color.rgb(0, 0, 139);
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
        formattingPreserved &= format.getFillFormat().getSolidFillColor().getColor() == numberColor;

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

새 프레젠테이션은 슬라이드 번호 1부터 시작하므로 텍스트는 `Slide 1`이며, 두 검사는 모두 `true`를 출력합니다. 재열기 후에도 번호는 필드로 유지되며 리터럴 `1`이 아닙니다. 검증에 사용된 형변환과 인덱스는 이 예제에서 만든 도형 및 portion을 가리킵니다.

## **필드 유형 선택**

[FieldType](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/fieldtype/)은 [IFieldType](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ifieldtype/)을 구현하고 미리 정의된 값을 얻기 위한 다음 메서드를 제공합니다. 적절한 값을 [addField](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iportion/#addField-com.aspose.slides.IFieldType-)에 전달하세요.

| Method | 목적 |
|---|---|
| [getSlideNumber](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/fieldtype/#getSlideNumber--) | 현재 슬라이드 번호. |
| [getDateTime](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/fieldtype/#getDateTime--) | 렌더링 응용 프로그램의 기본 형식으로 표시되는 날짜/시간. |
| [getDateTime1](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/fieldtype/#getDateTime1--)–[getDateTime9](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/fieldtype/#getDateTime9--) | 미리 정의된 날짜 또는 결합된 날짜/시간 형식. |
| [getDateTime10](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/fieldtype/#getDateTime10--)–[getDateTime13](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/fieldtype/#getDateTime13--) | 초와 12시간 시계를 포함한 미리 정의된 시간 형식. |
| [getHeader](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/fieldtype/#getHeader--) | 헤더 필드; 아래의 플레이스홀더 및 형식 제한을 참조하십시오. |
| [getFooter](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/fieldtype/#getFooter--) | 푸터 필드. |

예를 들어, [getDateTime3](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/fieldtype/#getDateTime3--) 은 영문으로 일, 전체 월 이름 및 연도를 나타냅니다. 이는 임의의 Java 날짜 형식 문자열이 아닌 미리 정의된 필드 형식입니다. [setLanguageId](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) 로 설정된 언어와 프레젠테이션을 처리하는 응용 프로그램이 표시 결과에 영향을 줄 수 있습니다.

## **내부 문자열로 필드 만들기**

[addField](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iportion/#addField-java.lang.String-) 의 문자열 오버로드는 내부 필드 식별자를 받아들입니다. 다른 응용 프로그램이 제공하고 미리 정의된 값이 없는 식별자를 보존해야 할 때 사용합니다. 식별자를 사용해 [FieldType](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/fieldtype/#FieldType-java.lang.String-) 를 만들 수도 있습니다. [IFieldType.getInternalString](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ifieldtype/#getInternalString--) 은 해당 식별자를 검사용으로 노출합니다.

이 예제는 `custom-report-id` 라는 애플리케이션 전용 필드를 백업 텍스트 `Report-042` 와 함께 저장합니다. 식별자는 계산을 등록하지 않으며: Aspose.Slides 는 알 수 없는 유형에 대해 보고서 ID를 생성하지 않습니다. 이 식별자를 이해하는 애플리케이션이 의미를 제공하고 값을 업데이트해야 합니다.

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

이 PPTX 라운드 트립 후, 유형은 `custom-report-id` 이고 텍스트는 `Report-042` 입니다. `yyyy-MM-dd` 와 같은 문자열을 전달하면 필드 유형이 지정되지만, 사용자 정의 날짜 형식을 구성하지는 않습니다. 임의 형식의 고정 날짜가 필요하면 일반 텍스트를 사용하십시오.

## **날짜/시간 필드 검사, 수정 및 제거**

기존 필드는 [IField.setType](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ifield/#setType-com.aspose.slides.IFieldType-) 를 통해 변경할 수 있습니다. 필드가 존재하는지 확인한 후 유형에 접근하세요. 자동 업데이트를 중지하려면 [IPortion.removeField](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iportion/#removeField--) 를 호출합니다. 이는 필드 연결을 제거하면서 현재 텍스트를 유지합니다. 특정 고정값이 필요하면 필드를 제거한 뒤 해당 텍스트를 할당하십시오.

날짜/시간 필드 처리와 관련된 API 설정은 [Presentation.setCurrentDateTime](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/presentation/#setCurrentDateTime-java.util.Date-) 를 참조하십시오. 아래 예제는 필드를 일반 텍스트로 변환할 때 명시적인 승인 날짜를 사용합니다.

작업 디렉터리에 [sample.pptx](sample.pptx)를 다운로드하고 배치하십시오. 여기에는 `UpdatedAt` 와 `ApprovedDate` 라는 두 개의 명명된 텍스트 도형이 각각 날짜/시간 필드와 일반 텍스트 레이블을 포함하고 있습니다. 다음 예제는 일반 슬라이드의 최상위 텍스트 도형을 순회하면서 날짜/시간 필드를 긴 날짜 형식으로 바꾸고 이탤릭체로 만들며 다른 서식은 그대로 유지합니다. `ApprovedDate` 에 있는 필드만 고정 텍스트가 됩니다.

샘플은 내부 식별자 `datetime` 과 `datetime1` ~ `datetime13` 을 인식합니다. 그룹, 표, 노트, 레이아웃 및 마스터는 자체 텍스트 컨테이너를 순회해야 하므로 이 예제 범위에 포함되지 않습니다.

```java
import java.util.Calendar;
import java.text.SimpleDateFormat;
import java.util.Locale;
import java.util.Date;
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    Calendar approvalDate = Calendar.getInstance();
    approvalDate.clear();
    approvalDate.set(2030, Calendar.APRIL, 5);
    SimpleDateFormat dateFormat = new SimpleDateFormat("dd MMMM yyyy", Locale.US);

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
                        Date dateValue = approvalDate.getTime();
                        String fixedDate = dateFormat.format(dateValue);
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

재열기 후, `UpdatedAt` 은 유형 `datetime3` 을 가지고 여전히 동적이며, `ApprovedDate` 은 필드가 없고 `05 April 2030` 을 포함합니다. 두 날짜 portion 모두 이탤릭체이며 원래 글꼴 크기, 굵기 및 색상은 그대로 유지됩니다. 일반 텍스트 레이블은 변경되지 않습니다. 검증은 제공된 샘플의 두 알려진 도형의 첫 번째 portion을 읽습니다.

## **텍스트 서식 보존**

필드를 추가하거나 유형을 변경하거나 제거할 때 기존 portion을 사용하십시오. 이러한 작업은 해당 portion의 서식을 유지합니다. 색상이나 이탤릭체와 같이 필요한 속성만 변경하려면 [IPortion.getPortionFormat](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iportion/#getPortionFormat--) 를 사용하십시오.

전체 텍스트 프레임을 재구성해 하나의 필드만 업데이트하려 하지 마십시오. 이렇게 하면 원래 portion 경계와 개별 서식이 손실될 수 있습니다. 또한 단락, 레이아웃 또는 테마에서 상속된 서식과 명시적으로 설정된 서식을 구분하십시오. 보다 포괄적인 서식 옵션은 [Text Formatting](/slides/ko/androidjava/text-formatting/) 을 참고하십시오.

## **필드와 헤더/푸터 플레이스홀더**

필드는 텍스트 portion의 일부입니다. 플레이스홀더는 푸터나 슬라이드 번호와 같은 프레젠테이션 역할을 가진 도형입니다. 일반 텍스트 상자에 필드를 추가해도 해당 도형이 플레이스홀더로 바뀌지는 않습니다.

헤더/푸터 관리자는 슬라이드, 레이아웃 및 마스터의 플레이스홀더 텍스트와 가시성을 제어하며, 종속 슬라이드에 전파합니다. 사용자 정의 텍스트 상자에 있는 번호 필드는 슬라이드 번호 플레이스홀더를 사용하지 않을 때도 유용할 수 있습니다. 반대로 플레이스홀더 가시성을 변경해도 무관한 텍스트 상자의 필드는 제거되지 않습니다.

미리 정의된 헤더와 푸터 유형은 해당 플레이스홀더를 만들거나 내용을 공급하지 않습니다. 특히 일반 PowerPoint 슬라이드에는 헤더 플레이스홀더가 없으며, 헤더는 노트 페이지와 유인물에 속합니다. 임의 도형에 있는 헤더 또는 푸터 필드가 자동으로 플레이스홀더 관리자를 통해 구성된 텍스트를 얻는다고 가정하지 마십시오. 해당 워크플로에 대해서는 [Presentation Headers and Footers](/slides/ko/androidjava/presentation-header-and-footer/) 를 참고하십시오.

## **PPTX 및 PPT 제한**

저장 후 재열기한 뒤 필드 유형과 결과 텍스트를 모두 확인하십시오. 식별자를 보존한다고 해서 애플리케이션이 값을 계산하거나 표시할 수 있다는 것을 증명하지는 않습니다.

| Format | 필드 동작 및 제한 |
|---|---|
| PPTX | 내부 필드 식별자를 필드 텍스트와 함께 저장합니다. 라운드 트립 검사에서 미리 정의된 유형과 위에서 사용한 사용자 정의 식별자가 저장 및 재열기 후에도 유지되었습니다. 알 수 없는 사용자 정의 유형은 백업 텍스트를 유지했으며 자동 계산 논리는 적용되지 않았습니다. 다른 애플리케이션은 지원되지 않는 식별자를 다르게 처리할 수 있습니다. |
| PPT | 레거시 필드 표현을 사용하며 호환성이 더 제한적입니다. 라운드 트립 검사에서 슬라이드 번호와 미리 정의된 날짜/시간 필드는 저장 및 재열기 후에도 유지되었습니다. 일반 슬라이드 텍스트 상자에 있는 사용자 정의 필드는 식별자는 유지되지만 텍스트가 `*` 로 표시되었습니다; 같은 맥락의 헤더 필드도 `*` 를 출력했습니다. 사용자 정의 필드나 지원되지 않는 필드 컨텍스트가 표시 텍스트를 유지한다는 가정은 하지 마십시오. |

휴대 가능한 고정 출력을 위해서는 지원되지 않는 필드를 일반 텍스트로 변환하고 저장하기 전에 원하는 값을 명시적으로 할당하십시오. 이렇게 하면 선택한 텍스트는 보존되지만 자동 업데이트는 의도적으로 중지됩니다. 워크플로에 자체 필드 재계산이 포함된 경우 대상 애플리케이션도 테스트하십시오.

## **FAQ**

**표시된 번호나 날짜가 필드인지 어떻게 확인합니까?**  
[IPortion.getField](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iportion/#getField--) 를 확인하십시오. null이 아닌 값은 필드를 나타내며, 표시된 텍스트만으로는 판단할 수 없습니다.

**필드를 제거하면 텍스트나 서식도 함께 제거됩니까?**  
아니요. [removeField](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iportion/#removeField--) 은 기존 portion을 일반 텍스트로 변환합니다. 특정 고정 날짜나 백업 값을 원한다면 제거 후 명시적으로 값을 할당하십시오.

**내부 문자열이 새로운 날짜 형식이나 수식을 정의할 수 있습니까?**  
아니요. 이는 필드 유형을 식별할 뿐이며, 알 수 없는 식별자는 평가 로직이나 Java 날짜 형식 패턴을 제공하지 않습니다. 지원되는 미리 정의된 유형을 사용하거나 값을 직접 일반 텍스트로 포맷하십시오.

**저장 후 프레젠테이션을 다시 확인해야 하는 이유는 무엇입니까?**  
필드 식별자, 계산된 텍스트 및 서식은 별도로 검증해야 합니다. 형식 변환은 필드 식별자가 여전히 존재하더라도 보이는 결과를 바꿀 수 있습니다.
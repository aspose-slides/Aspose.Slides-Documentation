---
title: Python을 통해 Java에서 PowerPoint 프레젠테이션의 텍스트 필드 관리
linktitle: 텍스트 필드
type: docs
weight: 52
url: /ko/python-java/text-fields/
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
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java를 사용하여 PowerPoint 프레젠테이션에서 텍스트 필드를 만들고, 검사하고, 수정하고, 제거합니다. 서식을 보존하고 저장된 PPTX 및 PPT 파일을 검증합니다."
---
## **개요**

텍스트 단락은 여러 부분으로 구성됩니다. 일반적인 [Portion](https://reference.aspose.com/slides/ko/python-java/aspose.slides/portion/)은 리터럴 텍스트를 포함합니다; 필드 부분은 또한 [Field](https://reference.aspose.com/slides/ko/python-java/aspose.slides/field/)를 가지고 있으며, 그 유형은 슬라이드 번호나 날짜와 같은 자동 업데이트 값임을 나타냅니다. 두 부분이 동일한 문자를 표시할 수 있지만, 필드를 포함하는 것은 하나뿐입니다.

이들을 구분하려면 [Portion.getField](https://reference.aspose.com/slides/ko/python-java/aspose.slides/portion/#getField)를 사용하세요: 일반 텍스트인 경우 `None`을 반환합니다. [Portion.addField](https://reference.aspose.com/slides/ko/python-java/aspose.slides/portion/#addField)은 기존 부분을 필드로 변환합니다. 값을 변환할 때 레이블도 함께 교체되지 않도록 레이블과 동적 값을 별개의 부분에 유지하세요.

이 가이드는 텍스트 내부의 필드, 해당 서식 지정 및 PPTX와 PPT에 저장하는 방법을 다룹니다. 텍스트 프레임 및 단락에 대해서는 [Manage Text](/slides/ko/python-java/manage-text/)를 참조하세요.

## **슬라이드 번호 필드 만들기**

다음 완전한 예제는 리터럴 `Slide ` 레이블 뒤에 자동 업데이트되는 번호가 포함된 텍스트 상자를 생성합니다. 필드를 추가하기 전에 번호의 크기, 굵기 및 색상을 설정한 뒤 저장된 프레젠테이션을 다시 열어 필드 유형, 텍스트 및 서식을 확인합니다. 입력 파일이 필요하지 않습니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Portion, ShapeType, NullableBool, FillType, FieldType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 240, 50)
    shape.addTextFrame("Slide ")
    paragraph = shape.getTextFrame().getParagraphs().get_Item(0)

    number_portion = Portion()
    number_color = Color(0, 0, 139)
    number_portion.getPortionFormat().setFontHeight(24)
    number_portion.getPortionFormat().setFontBold(NullableBool.True_)
    number_portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    number_portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(number_color)
    paragraph.getPortions().add(number_portion)
    number_portion.addField(FieldType.getSlideNumber())

    presentation.save("slide_number.pptx", SaveFormat.Pptx)

    reopened = Presentation("slide_number.pptx")
    try:
        saved_shape = reopened.getSlides().get_Item(0).getShapes().get_Item(0)
        saved_number = saved_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(1)
        saved_field = saved_number.getField()
        has_number_field = saved_field is not None and saved_field.getType().getInternalString() == FieldType.getSlideNumber().getInternalString()
        portion_format = saved_number.getPortionFormat()
        formatting_preserved = portion_format.getFontHeight() == 24 and portion_format.getFontBold() == NullableBool.True_
        formatting_preserved = formatting_preserved and portion_format.getFillFormat().getSolidFillColor().getColor().getRGB() == number_color.getRGB()

        print(f"Text: {saved_shape.getTextFrame().getText()}")
        print(f"Slide number field: {has_number_field}")
        print(f"Formatting preserved: {formatting_preserved}")
    finally:
        reopened.dispose()
finally:
    presentation.dispose()
```

새 프레젠테이션은 슬라이드 번호 1부터 시작하므로 텍스트는 `Slide 1`이며 두 검사는 모두 `True`를 출력합니다. 번호는 다시 열어도 필드 상태를 유지하며, 리터럴 `1`이 아닙니다. 검증에 사용된 인덱스는 이 예제에서 만든 도형 및 부분을 가리킵니다.

## **필드 유형 선택**

[FieldType](https://reference.aspose.com/slides/ko/python-java/aspose.slides/fieldtype/)은 미리 정의된 값을 가져오기 위한 다음 메서드를 제공합니다. 적절한 값을 [addField](https://reference.aspose.com/slides/ko/python-java/aspose.slides/portion/#addField)에 전달하세요.

| 메서드 | 목적 |
|---|---|
| [getSlideNumber](https://reference.aspose.com/slides/ko/python-java/aspose.slides/fieldtype/#getSlideNumber) | 현재 슬라이드 번호. |
| [getDateTime](https://reference.aspose.com/slides/ko/python-java/aspose.slides/fieldtype/#getDateTime) | 렌더링 애플리케이션의 기본 형식으로 표시되는 날짜/시간. |
| [getDateTime1](https://reference.aspose.com/slides/ko/python-java/aspose.slides/fieldtype/#getDateTime1)–[getDateTime9](https://reference.aspose.com/slides/ko/python-java/aspose.slides/fieldtype/#getDateTime9) | 미리 정의된 날짜 혹은 결합된 날짜/시간 형식. |
| [getDateTime10](https://reference.aspose.com/slides/ko/python-java/aspose.slides/fieldtype/#getDateTime10)–[getDateTime13](https://reference.aspose.com/slides/ko/python-java/aspose.slides/fieldtype/#getDateTime13) | 초와 12시간 시계 옵션을 포함한 미리 정의된 시간 형식. |
| [getHeader](https://reference.aspose.com/slides/ko/python-java/aspose.slides/fieldtype/#getHeader) | 헤더 필드; 아래의 자리 표시자 및 형식 제한을 참조하세요. |
| [getFooter](https://reference.aspose.com/slides/ko/python-java/aspose.slides/fieldtype/#getFooter) | 푸터 필드. |

예를 들어, [getDateTime3](https://reference.aspose.com/slides/ko/python-java/aspose.slides/fieldtype/#getDateTime3)는 영어로 요일, 전체 월 이름 및 연도를 나타냅니다. 이는 임의의 Python 날짜 형식 문자열이 아니라 미리 정의된 필드 형식입니다. [setLanguageId](https://reference.aspose.com/slides/ko/python-java/aspose.slides/baseportionformat/#setLanguageId)로 설정한 언어와 프레젠테이션을 처리하는 애플리케이션에 따라 표시 결과가 달라질 수 있습니다.

## **내부 문자열에서 필드 만들기**

[addField](https://reference.aspose.com/slides/ko/python-java/aspose.slides/portion/#addField)의 문자열 오버로드는 내부 필드 식별자를 받아들입니다. 미리 정의된 값이 없는 다른 애플리케이션에서 제공한 식별자를 보존해야 할 때 사용합니다. 해당 식별자를 사용해 [FieldType](https://reference.aspose.com/slides/ko/python-java/aspose.slides/fieldtype/#FieldType)을 구성할 수도 있습니다. [FieldType.getInternalString](https://reference.aspose.com/slides/ko/python-java/aspose.slides/fieldtype/#getInternalString)은 그 식별자를 검사용으로 노출합니다.

이 예제는 애플리케이션 전용 `custom-report-id` 필드와 대체 텍스트 `Report-042`를 저장합니다. 해당 식별자는 계산을 등록하지 않으며, Aspose.Slides는 알 수 없는 유형에 대해 보고서 ID를 생성하지 않습니다. 이 식별자를 이해하는 애플리케이션이 의미를 제공하고 값을 업데이트해야 합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, SaveFormat

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 300, 50)
    shape.addTextFrame("Report-042")
    portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.addField("custom-report-id")

    presentation.save("custom_field.pptx", SaveFormat.Pptx)

    reopened = Presentation("custom_field.pptx")
    try:
        saved_shape = reopened.getSlides().get_Item(0).getShapes().get_Item(0)
        saved_portion = saved_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
        saved_field = saved_portion.getField()
        type_name = "ordinary text" if saved_field is None else saved_field.getType().getInternalString()
        print(f"Type: {type_name}")
        print(f"Text: {saved_portion.getText()}")
    finally:
        reopened.dispose()
finally:
    presentation.dispose()
```

이 PPTX 라운드 트립 후, 유형은 `custom-report-id`이고 텍스트는 `Report-042`입니다. `yyyy-MM-dd`와 같은 문자열을 전달하면 필드 유형이 지정되지만, 사용자 정의 날짜 형식을 구성하지는 않습니다. 임의 형식의 고정 날짜가 필요하면 일반 텍스트를 사용하세요.

## **날짜/시간 필드 검사, 수정 및 제거**

[Field.setType](https://reference.aspose.com/slides/ko/python-java/aspose.slides/field/#setType)으로 기존 필드를 변경합니다. 유형에 접근하기 전에 필드가 존재하는지 확인하세요. 자동 업데이트를 중지하려면 [Portion.removeField](https://reference.aspose.com/slides/ko/python-java/aspose.slides/portion/#removeField)를 호출합니다. 이렇게 하면 필드 연관이 제거되면서 해당 부분과 현재 텍스트는 유지됩니다. 특정 고정값이 필요하면 필드를 제거한 뒤 텍스트를 할당하세요.

날짜/시간 필드 처리를 위한 API 설정은 [Presentation.setCurrentDateTime](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/#setCurrentDateTime)를 참고하세요. 아래 예제는 필드를 일반 텍스트로 변환할 때 명시적 승인 날짜를 사용합니다.

[sample.pptx](sample.pptx)를 다운로드하여 작업 디렉터리에 배치하세요. 여기에는 `UpdatedAt`와 `ApprovedDate`라는 두 개의 명명된 텍스트 도형이 포함되어 있으며 각각 날짜/시간 필드와 일반 텍스트 레이블을 가지고 있습니다. 다음 예제는 일반 슬라이드의 최상위 텍스트 도형을 순회합니다. 날짜/시간 필드를 긴 날짜 형식으로 변경하고 이탤릭체로 만들며 다른 서식은 보존합니다. `ApprovedDate`에 있는 필드만 고정 텍스트가 됩니다.

샘플은 내장된 내부 식별자 `datetime` 및 `datetime1`~`datetime13`을 인식합니다. 그룹, 표, 메모, 레이아웃 및 마스터는 자체 텍스트 컨테이너를 순회해야 하며 이 예제 범위에 포함되지 않습니다.

```python
import re
from datetime import date

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, AutoShape, FieldType, NullableBool, SaveFormat

presentation = Presentation("sample.pptx")
try:
    approval_date = date(2030, 4, 5)
    # 시스템 로케일과 무관하게 영어 월 이름을 사용합니다.
    month_names = ("January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December")
    fixed_date = f"{approval_date.day:02d} {month_names[approval_date.month - 1]} {approval_date.year}"

    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if not isinstance(shape, AutoShape):
                continue
            if shape.getTextFrame() is None:
                continue

            for paragraph in shape.getTextFrame().getParagraphs():
                for portion in paragraph.getPortions():
                    field = portion.getField()
                    if field is None:
                        continue

                    type_name = field.getType().getInternalString()
                    is_date_time = type_name is not None and re.fullmatch(r"datetime([1-9]|1[0-3])?", str(type_name)) is not None
                    if not is_date_time:
                        continue

                    field.setType(FieldType.getDateTime3())
                    portion.getPortionFormat().setLanguageId("en-US")
                    portion.getPortionFormat().setFontItalic(NullableBool.True_)

                    if shape.getName() == "ApprovedDate":
                        portion.removeField()
                        portion.setText(fixed_date)

    presentation.save("updated_dates.pptx", SaveFormat.Pptx)

    reopened = Presentation("updated_dates.pptx")
    try:
        for shape in reopened.getSlides().get_Item(0).getShapes():
            if not isinstance(shape, AutoShape):
                continue
            if shape.getTextFrame() is None:
                continue
            if shape.getName() not in ("UpdatedAt", "ApprovedDate"):
                continue

            portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
            field = portion.getField()
            type_name = "ordinary text" if field is None else field.getType().getInternalString()
            print(f"{shape.getName()}: {type_name}; {portion.getText()}")
            print(f"Italic: {portion.getPortionFormat().getFontItalic()}")
    finally:
        reopened.dispose()
finally:
    presentation.dispose()
```

다시 열었을 때 `UpdatedAt`은 유형 `datetime3`을 가지고 동적 상태를 유지합니다. `ApprovedDate`는 필드가 없으며 `05 April 2030` 텍스트를 포함합니다. 두 날짜 부분 모두 이탤릭체이며 원래 글꼴 크기, 굵게 설정 및 색상은 그대로 유지됩니다. 일반 텍스트 레이블은 변경되지 않습니다. 검증은 제공된 샘플에서 두 알려진 도형의 첫 번째 부분을 읽습니다.

## **텍스트 서식 보존**

필드를 추가하거나 유형을 변경하거나 제거할 때 기존 부분을 그대로 사용하세요. 이러한 작업은 해당 부분의 서식을 유지합니다. 예제에서 색상이나 이탤릭을 위해 수행한 것처럼 필요한 속성만 변경하려면 [Portion.getPortionFormat](https://reference.aspose.com/slides/ko/python-java/aspose.slides/portion/#getPortionFormat)를 사용하십시오.

하나의 필드만 업데이트하기 위해 전체 텍스트 프레임을 재구성하는 것을 피하세요. 이렇게 하면 원래 부분 경계와 개별 서식이 손실될 수 있습니다. 또한 단락, 레이아웃 또는 테마에서 상속된 서식과 명시적으로 설정된 서식을 구분하십시오. 더 넓은 서식 옵션은 [Text Formatting](/slides/ko/python-java/text-formatting/)을 참고하세요.

## **필드 및 머리글/바닥글 자리 표시자**

필드는 텍스트 부분의 일부입니다. 자리 표시자는 푸터나 슬라이드 번호와 같이 프레젠테이션 역할을 가진 도형입니다. 일반 텍스트 상자에 필드를 추가해도 해당 도형이 자리 표시자로 변환되지 않습니다.

머리글/바닥글 관리자는 슬라이드, 레이아웃 및 마스터에서 자리 표시자 텍스트와 가시성을 제어하며 종속 슬라이드로 전파됩니다. 사용자 정의 텍스트 상자에 번호 필드를 넣으면 슬라이드 번호 자리 표시자를 사용하지 않을 때도 유용할 수 있습니다. 반대로 자리 표시자 가시성을 변경해도 무관한 텍스트 상자에 있는 필드는 제거되지 않습니다.

미리 정의된 머리글 및 바닥글 유형은 해당 자리 표시자를 만들거나 내용을 제공하지 않습니다. 특히 일반 PowerPoint 슬라이드에는 머리글 자리 표시자가 없으며, 머리글은 노트 페이지와 유인물에 속합니다. 임의 도형에 있는 머리글이나 바닥글 필드가 자리 표시자 관리자를 통해 구성된 텍스트를 자동으로 얻는다고 가정하지 마세요. 해당 워크플로는 [Presentation Headers and Footers](/slides/ko/python-java/presentation-header-and-footer/)를 참조하십시오.

## **PPTX 및 PPT 제한**

저장 및 재열기 후 필드 유형과 결과 텍스트를 모두 확인하세요. 식별자를 보존해도 애플리케이션이 값을 계산하거나 표시할 수 있다는 증명이 되지는 않습니다.

| 형식 | 필드 동작 및 제한 |
|---|---|
| PPTX | 내부 필드 식별자를 필드 텍스트와 함께 저장합니다. 라운드트립 검사에서 미리 정의된 유형과 위에서 사용한 사용자 정의 식별자는 저장 및 재열기 후에도 유지되었습니다. 알 수 없는 사용자 정의 유형은 대체 텍스트를 유지했으며 자동 계산 로직은 추가되지 않았습니다. 다른 애플리케이션은 지원되지 않는 식별자를 다르게 처리할 수 있습니다. |
| PPT | 레거시 필드 표현을 사용하며 호환성이 더 제한적입니다. 라운드트립 검사에서 슬라이드 번호와 미리 정의된 날짜/시간 필드는 저장 및 재열기 후에도 유지되었습니다. 일반 슬라이드 텍스트 상자에 있는 사용자 정의 필드는 식별자는 유지되지만 텍스트는 `*`가 되었습니다. 같은 맥락의 헤더 필드도 `*`를 출력했습니다. 사용자 정의 필드나 지원되지 않는 필드 컨텍스트가 표시 텍스트를 유지한다는 보장은 없습니다. |

휴대성과 고정 출력을 위해 지원되지 않는 필드는 일반 텍스트로 변환하고 저장 전에 원하는 값을 명시적으로 지정하십시오. 이렇게 하면 선택한 텍스트는 보존되지만 자동 업데이트는 의도적으로 중지됩니다. 워크플로에 자체 필드 재계산이 포함된 경우 대상 애플리케이션도 테스트하세요.

## **FAQ**

**표시된 숫자나 날짜가 필드인지 어떻게 확인할 수 있나요?**  
[Portion.getField](https://reference.aspose.com/slides/ko/python-java/aspose.slides/portion/#getField)를 검사하세요. `None`이 아닌 값이 반환되면 필드이며, 표시된 텍스트만으로는 판단할 수 없습니다.

**필드를 제거하면 텍스트나 서식도 함께 제거되나요?**  
아니요. [removeField](https://reference.aspose.com/slides/ko/python-java/aspose.slides/portion/#removeField)는 기존 부분을 일반 텍스트로 변환합니다. 특정 고정 날짜나 대체 값을 원한다면 필드 제거 후 텍스트를 명시적으로 할당하십시오.

**내부 문자열로 새 날짜 형식이나 수식을 정의할 수 있나요?**  
아니요. 내부 문자열은 필드 유형을 식별할 뿐이며, 알 수 없는 식별자는 평가 로직이나 Python 날짜 형식 패턴을 제공하지 않습니다. 지원되는 미리 정의된 유형을 사용하거나 값을 일반 텍스트로 직접 서식 지정하십시오.

**저장한 뒤 프레젠테이션을 다시 확인해야 하는 이유는?**  
필드 식별자, 계산된 텍스트 및 서식은 별개의 요소이며 각각 검증이 필요합니다. 형식 변환 과정에서 식별자는 남아 있어도 표시 결과가 달라질 수 있습니다.
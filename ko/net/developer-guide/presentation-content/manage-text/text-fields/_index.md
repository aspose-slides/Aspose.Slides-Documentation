---
title: PowerPoint 프레젠테이션에서 .NET 텍스트 필드 관리
linktitle: 텍스트 필드
type: docs
weight: 52
url: /ko/net/text-fields/
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
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET을 사용하여 PowerPoint 프레젠테이션에서 텍스트 필드를 생성, 검사, 수정 및 제거합니다. 서식을 보존하고 저장된 PPTX 및 PPT 파일을 확인합니다."
---
## **개요**

텍스트 단락은 여러 부분으로 구성됩니다. 일반적인 [IPortion](https://reference.aspose.com/slides/ko/net/aspose.slides/iportion/)은 리터럴 텍스트를 포함하고; 필드 부분은 자동으로 업데이트되는 값(예: 슬라이드 번호 또는 날짜)을 식별하는 유형을 가진 [IField](https://reference.aspose.com/slides/ko/net/aspose.slides/ifield/)도 포함합니다. 두 부분이 동일한 문자를 표시할 수 있지만 필드를 포함하는 것은 하나만 가능합니다.

[IPortion.Field](https://reference.aspose.com/slides/ko/net/aspose.slides/iportion/field/)를 사용해 구분하십시오: 일반 텍스트인 경우 `null`입니다. [IPortion.AddField](https://reference.aspose.com/slides/ko/net/aspose.slides/iportion/addfield/)은 기존 부분을 필드로 변환합니다. 라벨과 동적 값을 별개의 부분에 보관하면 값 변환 시 라벨이 같이 바뀌는 일을 방지할 수 있습니다.

이 가이드는 텍스트 내부 필드, 해당 서식 및 PPTX와 PPT에 저장하는 방법을 다룹니다. 텍스트 프레임 및 단락에 대해서는 [Manage Text](/slides/ko/net/manage-text/)를 참조하십시오.

## **슬라이드 번호 필드 만들기**

다음 완전한 예제는 리터럴 `Slide ` 라벨 뒤에 자동 업데이트 번호가 들어 있는 텍스트 상자를 생성합니다. 번호의 크기, 두께 및 색상을 필드를 추가하기 전에 설정하고, 저장된 프레젠테이션을 다시 열어 필드 유형, 텍스트 및 서식을 확인합니다. 입력 파일이 필요하지 않습니다.

```cs
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 240, 50);
shape.AddTextFrame("Slide ");
var paragraph = shape.TextFrame.Paragraphs[0];

var numberPortion = new Portion();
numberPortion.PortionFormat.FontHeight = 24;
numberPortion.PortionFormat.FontBold = NullableBool.True;
numberPortion.PortionFormat.FillFormat.FillType = FillType.Solid;
numberPortion.PortionFormat.FillFormat.SolidFillColor.Color = Color.DarkBlue;
paragraph.Portions.Add(numberPortion);
numberPortion.AddField(FieldType.SlideNumber);

presentation.Save("slide_number.pptx", SaveFormat.Pptx);

using var reopened = new Presentation("slide_number.pptx");
var savedShape = (IAutoShape)reopened.Slides[0].Shapes[0];
var savedNumber = savedShape.TextFrame.Paragraphs[0].Portions[1];
var hasNumberField = savedNumber.Field?.Type.InternalString == FieldType.SlideNumber.InternalString;
var format = savedNumber.PortionFormat;
var formattingPreserved = format.FontHeight == 24 && format.FontBold == NullableBool.True;
formattingPreserved &= format.FillFormat.SolidFillColor.Color.ToArgb() == Color.DarkBlue.ToArgb();

Console.WriteLine($"Text: {savedShape.TextFrame.Text}");
Console.WriteLine($"Slide number field: {hasNumberField}");
Console.WriteLine($"Formatting preserved: {formattingPreserved}");
```

새 프레젠테이션은 슬라이드 번호가 1부터 시작하므로 텍스트는 `Slide 1`이며, 두 검증 모두 `True`를 출력합니다. 번호는 다시 열어도 필드 상태를 유지하며 리터럴 `1`이 되지 않습니다. 검증에서 사용된 캐스트와 인덱스는 이 예제에서 만든 도형 및 부분을 가리킵니다.

## **필드 유형 선택**

[FieldType](https://reference.aspose.com/slides/ko/net/aspose.slides/fieldtype/)은 [IFieldType](https://reference.aspose.com/slides/ko/net/aspose.slides/ifieldtype/)을 구현하며 다음과 같은 미리 정의된 값을 제공합니다. 적절한 값을 [AddField](https://reference.aspose.com/slides/ko/net/aspose.slides/iportion/addfield/)에 전달하십시오.

| 값 | 목적 |
|---|---|
| [SlideNumber](https://reference.aspose.com/slides/ko/net/aspose.slides/fieldtype/slidenumber/) | 현재 슬라이드 번호 |
| [DateTime](https://reference.aspose.com/slides/ko/net/aspose.slides/fieldtype/datetime/) | 렌더링 애플리케이션의 기본 형식으로 표시되는 날짜/시간 |
| [DateTime1](https://reference.aspose.com/slides/ko/net/aspose.slides/fieldtype/datetime1/)–[DateTime9](https://reference.aspose.com/slides/ko/net/aspose.slides/fieldtype/datetime9/) | 미리 정의된 날짜 또는 결합된 날짜/시간 형식 |
| [DateTime10](https://reference.aspose.com/slides/ko/net/aspose.slides/fieldtype/datetime10/)–[DateTime13](https://reference.aspose.com/slides/ko/net/aspose.slides/fieldtype/datetime13/) | 초와 12시간 시계 옵션을 포함한 미리 정의된 시간 형식 |
| [Header](https://reference.aspose.com/slides/ko/net/aspose.slides/fieldtype/header/) | 헤더 필드(아래의 자리표시자 및 형식 제한 참고) |
| [Footer](https://reference.aspose.com/slides/ko/net/aspose.slides/fieldtype/footer/) | 푸터 필드 |

예를 들어, [DateTime3](https://reference.aspose.com/slides/ko/net/aspose.slides/fieldtype/datetime3/)은 영어로 요일, 전체 월 이름, 연도를 나타냅니다. 이는 임의의 .NET 날짜 형식 문자열이 아니라 미리 정의된 필드 형식입니다. 부분의 [LanguageId](https://reference.aspose.com/slides/ko/net/aspose.slides/ibaseportionformat/languageid/)와 프레젠테이션을 처리하는 애플리케이션에 따라 표시 결과가 달라질 수 있습니다.

## **내부 문자열로 필드 만들기**

[AddField](https://reference.aspose.com/slides/ko/net/aspose.slides/iportion/addfield/)의 문자열 오버로드는 내부 필드 식별자를 받아들입니다. 다른 애플리케이션이 제공한 식별자를 그대로 보존해야 할 때 사용하십시오. 식별자를 사용해 [FieldType](https://reference.aspose.com/slides/ko/net/aspose.slides/fieldtype/fieldtype/)을 직접 구성할 수도 있습니다. [IFieldType.InternalString](https://reference.aspose.com/slides/ko/net/aspose.slides/ifieldtype/internalstring/)은 해당 식별자를 검사용으로 노출합니다.

이 예제는 `custom-report-id`라는 애플리케이션 전용 필드를 기본 텍스트 `Report-042`와 함께 저장합니다. 이 식별자는 계산을 등록하지 않으며, Aspose.Slides는 알 수 없는 유형의 보고서 ID를 생성하지 않습니다. 이 식별자를 이해하는 애플리케이션이 의미와 값을 제공해야 합니다.

```cs
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 300, 50);
shape.AddTextFrame("Report-042");
var portion = shape.TextFrame.Paragraphs[0].Portions[0];
portion.AddField("custom-report-id");

presentation.Save("custom_field.pptx", SaveFormat.Pptx);

using var reopened = new Presentation("custom_field.pptx");
var savedShape = (IAutoShape)reopened.Slides[0].Shapes[0];
var savedPortion = savedShape.TextFrame.Paragraphs[0].Portions[0];
Console.WriteLine($"Type: {savedPortion.Field?.Type.InternalString}");
Console.WriteLine($"Text: {savedPortion.Text}");
```

이 PPTX 라운드 트립 후, 유형은 `custom-report-id`이고 텍스트는 `Report-042`입니다. `yyyy-MM-dd`와 같은 문자열을 전달하면 필드 유형이 지정될 뿐, 사용자 정의 날짜 형식이 설정되지 않습니다. 임의 형식의 고정 날짜가 필요하면 일반 텍스트를 사용하십시오.

## **날짜/시간 필드 검사, 수정 및 제거**

[IField.Type](https://reference.aspose.com/slides/ko/net/aspose.slides/ifield/type/)을 통해 기존 필드를 읽고 변경할 수 있습니다. 필드에 접근하기 전에 존재 여부를 확인하십시오. 자동 업데이트를 중지하려면 [IPortion.RemoveField](https://reference.aspose.com/slides/ko/net/aspose.slides/iportion/removefield/)를 호출합니다. 이렇게 하면 부분은 유지되고 현재 텍스트는 남으며 필드 연결만 제거됩니다. 특정 고정값이 필요하면 필드를 제거한 후 해당 텍스트를 할당하십시오.

날짜/시간 필드 처리와 관련된 API 설정은 [Presentation.CurrentDateTime](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/currentdatetime/)를 참고하십시오. 아래 예제는 필드를 일반 텍스트로 변환할 때 명시적인 승인 날짜를 사용합니다.

[sample.pptx](sample.pptx)를 다운로드하고 작업 디렉터리에 놓으십시오. 이 파일에는 `UpdatedAt`와 `ApprovedDate`라는 두 개의 명명된 텍스트 도형이 있으며, 각각 날짜/시간 필드와 일반 텍스트 라벨을 포함합니다. 다음 예제는 일반 슬라이드의 최상위 텍스트 도형을 순회하면서 날짜/시간 필드를 긴 날짜 형식으로 바꾸고 이탤릭체로 만들며 나머지 서식은 유지합니다. `ApprovedDate`에 있는 필드만 고정 텍스트가 됩니다.

내장된 내부 식별자 `datetime` 및 `datetime1`~`datetime13`을 인식합니다. 그룹, 표, 노트, 레이아웃 및 마스터는 자체 텍스트 컨테이너를 순회해야 하며 본 예제의 범위에 포함되지 않습니다.

```cs
using System;
using System.Globalization;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var approvalDate = new DateTime(2030, 4, 5);
var culture = CultureInfo.GetCultureInfo("en-US");

foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
    {
        if (shape is not IAutoShape textShape || textShape.TextFrame == null)
            continue;

        foreach (var paragraph in textShape.TextFrame.Paragraphs)
        {
            foreach (var portion in paragraph.Portions)
            {
                var field = portion.Field;
                if (field == null)
                    continue;

                var typeName = field.Type.InternalString;
                var isDateTime = typeName == "datetime";
                if (typeName.StartsWith("datetime", StringComparison.Ordinal))
                {
                    var hasFormatNumber = int.TryParse(typeName.Substring(8), out var formatNumber);
                    isDateTime |= hasFormatNumber && formatNumber >= 1 && formatNumber <= 13;
                }
                if (!isDateTime)
                    continue;

                field.Type = FieldType.DateTime3;
                portion.PortionFormat.LanguageId = "en-US";
                portion.PortionFormat.FontItalic = NullableBool.True;

                if (textShape.Name == "ApprovedDate")
                {
                    portion.RemoveField();
                    portion.Text = approvalDate.ToString("dd MMMM yyyy", culture);
                }
            }
        }
    }
}

presentation.Save("updated_dates.pptx", SaveFormat.Pptx);

using var reopened = new Presentation("updated_dates.pptx");
foreach (var shape in reopened.Slides[0].Shapes)
{
    if (shape is not IAutoShape textShape || textShape.TextFrame == null)
        continue;
    if (textShape.Name != "UpdatedAt" && textShape.Name != "ApprovedDate")
        continue;

    var portion = textShape.TextFrame.Paragraphs[0].Portions[0];
    var typeName = portion.Field?.Type.InternalString ?? "ordinary text";
    Console.WriteLine($"{textShape.Name}: {typeName}; {portion.Text}");
    Console.WriteLine($"Italic: {portion.PortionFormat.FontItalic}");
}
```

다시 열면 `UpdatedAt`은 `datetime3` 유형이며 동적 상태를 유지합니다. `ApprovedDate`는 필드가 없으며 `05 April 2030` 텍스트를 포함합니다. 두 날짜 부분 모두 이탤릭체이며 원래 폰트 크기, 굵게 설정 및 색상은 그대로 유지됩니다. 일반 텍스트 라벨은 변경되지 않습니다. 검증은 제공된 샘플에서 알려진 두 도형의 첫 번째 부분을 읽습니다.

## **텍스트 서식 보존**

필드를 추가, 유형을 변경 또는 제거할 때 기존 부분을 사용하십시오. 이러한 작업은 해당 부분의 서식을 보존합니다. 색상이나 이탤릭과 같이 필요한 속성만 변경하려면 [IPortion.PortionFormat](https://reference.aspose.com/slides/ko/net/aspose.slides/iportion/portionformat/)을 사용하십시오.

필드 하나만 업데이트하기 위해 전체 텍스트 프레임을 재구성하지 마십시오. 이렇게 하면 원래 부분 경계와 개별 서식이 손실될 수 있습니다. 또한 단락, 레이아웃 또는 테마에서 상속된 서식과 명시적으로 설정된 서식을 구분하십시오. 보다 폭넓은 서식 옵션은 [Text Formatting](/slides/ko/net/text-formatting/)을 참고하십시오.

## **필드와 헤더/푸터 자리표시자**

필드는 텍스트 부분의 일부입니다. 자리표시자는 푸터나 슬라이드 번호와 같은 프레젠테이션 역할을 가진 도형입니다. 일반 텍스트 상자에 필드를 추가해도 해당 도형이 자리표시자로 변환되지 않습니다.

헤더/푸터 관리자는 슬라이드, 레이아웃 및 마스터에서 자리표시자 텍스트와 가시성을 제어하며, 종속 슬라이드로 전파합니다. 사용자 지정 텍스트 상자에 번호 필드를 넣으면 슬라이드 번호 자리표시자를 사용하지 않을 때도 유용할 수 있습니다. 반대로 자리표시자 가시성을 변경해도 무관한 텍스트 상자에 있는 필드는 제거되지 않습니다.

미리 정의된 헤더 및 푸터 유형은 해당 자리표시자를 생성하거나 내용을 제공하지 않습니다. 특히 일반 PowerPoint 슬라이드에는 헤더 자리표시자가 없으며, 헤더는 노트 페이지와 배포물에 속합니다. 임의 도형에 헤더 또는 푸터 필드를 넣는다고 해서 자동으로 자리표시자 관리자를 통해 설정된 텍스트가 적용된다고 가정하지 마십시오. 해당 워크플로는 [Presentation Headers and Footers](/slides/ko/net/presentation-header-and-footer/)를 참고하십시오.

## **PPTX 및 PPT 제한 사항**

저장 후 다시 열어 필드 유형과 결과 텍스트를 모두 확인하십시오. 식별자를 보존한다고 해서 애플리케이션이 값을 계산하거나 표시할 수 있다는 보장은 없습니다.

| 형식 | 필드 동작 및 제한 사항 |
|---|---|
| PPTX | 내부 필드 식별자를 텍스트와 함께 저장합니다. 라운드 트립 검사에서 미리 정의된 유형과 위에서 사용한 사용자 정의 식별자가 모두 저장·재열림을 견뎌냈습니다. 알 수 없는 사용자 정의 유형은 기본 텍스트를 유지했으며 자동 계산 로직은 적용되지 않았습니다. 다른 애플리케이션은 지원되지 않는 식별자를 다르게 처리할 수 있습니다. |
| PPT | 레거시 필드 표현을 사용하며 호환성이 더 제한적입니다. 라운드 트립 검사에서 슬라이드 번호와 미리 정의된 날짜/시간 필드는 저장·재열림을 견뎌냈습니다. 일반 슬라이드 텍스트 상자에 있는 사용자 정의 필드는 식별자는 보존되지만 텍스트가 `*`로 표시되었습니다; 동일한 상황의 헤더 필드도 `*`를 출력했습니다. 사용자 정의 필드나 지원되지 않는 필드 컨텍스트가 표시 텍스트를 유지한다는 보장은 하지 마십시오. |

이동식 고정 출력이 필요하면 지원되지 않는 필드를 일반 텍스트로 변환하고 원하는 값을 명시적으로 할당한 후 저장하십시오. 이렇게 하면 선택한 텍스트는 보존되지만 자동 업데이트는 의도적으로 중단됩니다. 워크플로에 필드 재계산이 포함된 경우 대상 애플리케이션에서도 테스트하십시오.

## **FAQ**

**표시된 숫자나 날짜가 필드인지 어떻게 알 수 있나요?**

[IPortion.Field](https://reference.aspose.com/slides/ko/net/aspose.slides/iportion/field/)를 확인하십시오. 값이 null이 아니면 필드이며, 표시된 텍스트만으로는 판단할 수 없습니다.

**필드를 제거하면 텍스트나 서식도 같이 사라지나요?**

아니요. [RemoveField](https://reference.aspose.com/slides/ko/net/aspose.slides/iportion/removefield/)는 기존 부분을 일반 텍스트로 변환합니다. 특정 고정 날짜나 대체값이 필요하면 이후에 명시적인 값을 할당하십시오.

**내부 문자열이 새로운 날짜 형식이나 수식을 정의할 수 있나요?**

아니요. 내부 문자열은 필드 유형을 식별할 뿐이며, 알 수 없는 식별자는 평가 로직이나 .NET 날짜 형식 패턴을 제공하지 않습니다. 지원되는 미리 정의된 유형을 사용하거나 값을 직접 일반 텍스트로 서식 지정하십시오.

**저장 후 프레젠테이션을 다시 확인해야 하는 이유는?**

필드 식별자, 계산된 텍스트 및 서식은 서로 독립적인 요소이며 각각을 검증해야 합니다. 형식 변환 과정에서 식별자는 남아 있어도 표시 결과가 달라질 수 있습니다.
---
title: C++로 PowerPoint 프레젠테이션의 텍스트 필드 관리
linktitle: 텍스트 필드
type: docs
weight: 52
url: /ko/cpp/text-fields/
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
- C++
- Aspose.Slides
description: "Aspose.Slides for C++를 사용하여 PowerPoint 프레젠테이션에서 텍스트 필드를 만들고, 검사하고, 수정하고, 제거합니다. 서식을 보존하고 저장된 PPTX 및 PPT 파일을 확인합니다."
---
## **개요**

텍스트 단락은 여러 부분으로 구성됩니다. 일반적인 [IPortion](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iportion/)은 리터럴 텍스트를 포함하고; 필드 부분은 또한 [IField](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ifield/)를 가지고 있으며, 그 유형은 슬라이드 번호나 날짜와 같이 자동으로 업데이트되는 값을 식별합니다. 두 부분이 동일한 문자를 표시할 수 있지만 필드를 포함하는 부분은 하나뿐입니다.

[IPortion::get_Field](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iportion/get_field/)을 사용하여 구분합니다: 일반 텍스트인 경우 `nullptr`를 반환합니다. [IPortion::AddField](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iportion/addfield/)은 기존 부분을 필드로 변환합니다. 라벨과 동적 값을 별개의 부분에 보관하여 값을 변환하더라도 라벨이 교체되지 않도록 합니다.

이 가이드는 텍스트 내부의 필드, 해당 서식 및 PPTX와 PPT에 저장하는 방법을 다룹니다. 텍스트 프레임 및 단락에 대해서는 [Manage Text](/slides/ko/cpp/manage-text/)를 참조하세요.

## **슬라이드 번호 필드 만들기**

다음 예제는 리터럴 `Slide ` 라벨 뒤에 자동으로 업데이트되는 번호가 포함된 텍스트 상자를 생성합니다. 필드를 추가하기 전에 번호의 크기, 굵기 및 색상을 설정한 다음 저장된 프레젠테이션을 다시 열어 필드 유형, 텍스트 및 서식을 확인합니다. 입력 파일은 필요하지 않습니다.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/ShapeType.h>
#include <DOM/ITextFrame.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortionCollection.h>
#include <DOM/Portion.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IColorFormat.h>
#include <DOM/FillType.h>
#include <DOM/NullableBool.h>
#include <DOM/IField.h>
#include <DOM/IFieldType.h>
#include <DOM/FieldType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40, 40, 240, 50);
shape->AddTextFrame(u"Slide ");
auto paragraph = shape->get_TextFrame()->get_Paragraph(0);

auto numberPortion = System::MakeObject<Portion>();
numberPortion->get_PortionFormat()->set_FontHeight(24);
numberPortion->get_PortionFormat()->set_FontBold(NullableBool::True);
numberPortion->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
numberPortion->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_DarkBlue());
paragraph->get_Portions()->Add(numberPortion);
numberPortion->AddField(FieldType::get_SlideNumber());

presentation->Save(u"slide_number.pptx", SaveFormat::Pptx);
presentation->Dispose();

auto reopened = System::MakeObject<Presentation>(u"slide_number.pptx");
auto savedShape = System::ExplicitCast<IAutoShape>(reopened->get_Slide(0)->get_Shape(0));
auto savedNumber = savedShape->get_TextFrame()->get_Paragraph(0)->get_Portion(1);
auto field = savedNumber->get_Field();
auto hasNumberField = field != nullptr && field->get_Type()->get_InternalString() == FieldType::get_SlideNumber()->get_InternalString();
auto format = savedNumber->get_PortionFormat();
auto formattingPreserved = format->get_FontHeight() == 24 && format->get_FontBold() == NullableBool::True;
formattingPreserved &= format->get_FillFormat()->get_SolidFillColor()->get_Color().ToArgb() == System::Drawing::Color::get_DarkBlue().ToArgb();

System::Console::WriteLine(u"Text: {0}", savedShape->get_TextFrame()->get_Text());
System::Console::WriteLine(u"Slide number field: {0}", hasNumberField);
System::Console::WriteLine(u"Formatting preserved: {0}", formattingPreserved);
reopened->Dispose();
```

새 프레젠테이션은 슬라이드 번호 1부터 시작하므로 예상 텍스트는 `Slide 1`이며 두 검사 모두 `True`를 출력해야 합니다. 번호는 다시 열어도 필드 상태를 유지하며, 리터럴 `1`이 아닙니다. 검증에 사용된 캐스트와 인덱스는 이 예제에서 만든 도형 및 부분을 가리킵니다.

## **필드 유형 선택**

[FieldType](https://reference.aspose.com/slides/ko/cpp/aspose.slides/fieldtype/)은 [IFieldType](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ifieldtype/)을 구현하며 다음과 같은 미리 정의된 값을 제공합니다. 적절한 값을 [AddField](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iportion/addfield/)에 전달하십시오.

| 액세서 | 목적 |
|---|---|
| [get_SlideNumber](https://reference.aspose.com/slides/ko/cpp/aspose.slides/fieldtype/get_slidenumber/) | 현재 슬라이드 번호. |
| [get_DateTime](https://reference.aspose.com/slides/ko/cpp/aspose.slides/fieldtype/get_datetime/) | 렌더링 애플리케이션의 기본 형식에 따른 날짜/시간. |
| [get_DateTime1](https://reference.aspose.com/slides/ko/cpp/aspose.slides/fieldtype/get_datetime1/)–[get_DateTime9](https://reference.aspose.com/slides/ko/cpp/aspose.slides/fieldtype/get_datetime9/) | 미리 정의된 날짜 또는 결합된 날짜/시간 형식. |
| [get_DateTime10](https://reference.aspose.com/slides/ko/cpp/aspose.slides/fieldtype/get_datetime10/)–[get_DateTime13](https://reference.aspose.com/slides/ko/cpp/aspose.slides/fieldtype/get_datetime13/) | 초와 12시간 시계를 포함한 미리 정의된 시간 형식. |
| [get_Header](https://reference.aspose.com/slides/ko/cpp/aspose.slides/fieldtype/get_header/) | 헤더 필드; 아래의 자리표시자 및 형식 제한을 참조하세요. |
| [get_Footer](https://reference.aspose.com/slides/ko/cpp/aspose.slides/fieldtype/get_footer/) | 푸터 필드. |

예를 들어, [get_DateTime3](https://reference.aspose.com/slides/ko/cpp/aspose.slides/fieldtype/get_datetime3/)은 영어로 요일, 전체 월 이름 및 연도를 제공하는 형식입니다. 이것은 임의의 날짜 형식 문자열이 아니라 미리 정의된 필드 형식입니다. [IBasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ibaseportionformat/set_languageid/)로 설정한 부분의 언어와 프레젠테이션을 처리하는 애플리케이션에 따라 표시 결과가 달라질 수 있습니다.

## **내부 문자열에서 필드 만들기**

[AddField](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iportion/addfield/)의 문자열 오버로드는 내부 필드 식별자를 허용합니다. 미리 정의된 값이 없는 다른 애플리케이션이 제공한 식별자를 보존해야 할 때 사용합니다. 식별자를 사용해 [FieldType](https://reference.aspose.com/slides/ko/cpp/aspose.slides/fieldtype/fieldtype/)을 만들 수도 있습니다. [IFieldType::get_InternalString](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ifieldtype/get_internalstring/)은 해당 식별자를 검사용으로 노출합니다.

이 예제는 애플리케이션 고유의 `custom-report-id` 필드를 대체 텍스트 `Report-042`와 함께 저장합니다. 입력 파일은 필요하지 않습니다. 식별자는 계산을 등록하지 않으며, Aspose.Slides는 알 수 없는 유형에 대해 보고서 ID를 생성하지 않습니다. 이 식별자를 이해하는 애플리케이션이 의미를 제공하고 값을 업데이트해야 합니다.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/ShapeType.h>
#include <DOM/ITextFrame.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IField.h>
#include <DOM/IFieldType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto shape = presentation->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40, 40, 300, 50);
shape->AddTextFrame(u"Report-042");
auto portion = shape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
portion->AddField(u"custom-report-id");
presentation->Save(u"custom_field.pptx", SaveFormat::Pptx);
presentation->Dispose();

auto reopened = System::MakeObject<Presentation>(u"custom_field.pptx");
auto savedShape = System::ExplicitCast<IAutoShape>(reopened->get_Slide(0)->get_Shape(0));
auto savedPortion = savedShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
auto field = savedPortion->get_Field();
auto typeName = field != nullptr ? field->get_Type()->get_InternalString() : u"ordinary text";
System::Console::WriteLine(u"Type: {0}", typeName);
System::Console::WriteLine(u"Text: {0}", savedPortion->get_Text());
reopened->Dispose();
```

이 PPTX 라운드 트립 후 기대되는 유형은 `custom-report-id`이고 기대되는 텍스트는 `Report-042`입니다. `yyyy-MM-dd`와 같은 문자열을 전달하면 필드 유형이 지정될 뿐이며, 사용자 정의 날짜 형식을 구성하지는 않습니다. 임의 형식의 고정 날짜가 필요하면 일반 텍스트를 사용하십시오.

## **날짜/시간 필드 검사, 수정 및 제거**

[IField::get_Type](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ifield/get_type/)으로 기존 필드 유형을 읽고 [IField::set_Type](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ifield/set_type/)으로 변경합니다. 유형에 접근하기 전에 필드가 존재하는지 확인하십시오. 자동 업데이트를 중지하려면 [IPortion::RemoveField](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iportion/removefield/)를 호출합니다. 이는 필드 연관을 제거하면서 부분과 현재 텍스트는 유지합니다. 특정 고정값이 필요하면 필드를 제거한 후 해당 텍스트를 할당하십시오.

날짜/시간 필드 처리와 관련된 API 설정은 [Presentation::set_CurrentDateTime](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/set_currentdatetime/)를 참조하십시오. 아래 예제는 필드를 일반 텍스트로 변환할 때 명시적인 승인 날짜를 사용합니다.

[sample.pptx](sample.pptx)를 다운로드하고 작업 디렉터리에 배치하십시오. 여기에는 `UpdatedAt`와 `ApprovedDate`라는 두 개의 명명된 텍스트 도형이 포함되어 있으며, 각각 날짜/시간 필드와 일반 텍스트 라벨을 가지고 있습니다. 다음 예제는 일반 슬라이드의 최상위 텍스트 도형을 순회합니다. 날짜/시간 필드를 장문 날짜 형식으로 변경하고 이탤릭체로 만들면서 다른 서식은 유지합니다. `ApprovedDate`에 있는 필드만 고정 텍스트가 됩니다.

샘플은 내장된 내부 식별자 `datetime` 및 `datetime1`부터 `datetime13`까지를 인식합니다. 그룹, 표, 노트, 레이아웃 및 마스터는 자체 텍스트 컨테이너를 순회해야 하며 이 예제의 범위에 포함되지 않습니다.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/ITextFrame.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/NullableBool.h>
#include <DOM/IField.h>
#include <DOM/IFieldType.h>
#include <DOM/FieldType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/date_time.h>
#include <system/globalization/culture_info.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto approvalDate = System::DateTime(2030, 4, 5);
auto culture = System::Globalization::CultureInfo::GetCultureInfo(u"en-US");

for (auto slide : presentation->get_Slides())
{
    for (auto shape : slide->get_Shapes())
    {
        auto textShape = System::DynamicCast<IAutoShape>(shape);
        if (textShape == nullptr || textShape->get_TextFrame() == nullptr)
            continue;

        for (auto paragraph : textShape->get_TextFrame()->get_Paragraphs())
        {
            for (auto portion : paragraph->get_Portions())
            {
                auto field = portion->get_Field();
                if (field == nullptr)
                    continue;

                auto typeName = field->get_Type()->get_InternalString();
                auto isDateTime = typeName == u"datetime";
                for (auto formatNumber = 1; formatNumber <= 13; ++formatNumber)
                {
                    auto identifier = System::String::Format(u"datetime{0}", formatNumber);
                    isDateTime |= typeName == identifier;
                }
                if (!isDateTime)
                    continue;

                field->set_Type(FieldType::get_DateTime3());
                portion->get_PortionFormat()->set_LanguageId(u"en-US");
                portion->get_PortionFormat()->set_FontItalic(NullableBool::True);

                if (textShape->get_Name() == u"ApprovedDate")
                {
                    portion->RemoveField();
                    auto fixedDate = approvalDate.ToString(u"dd MMMM yyyy", culture);
                    portion->set_Text(fixedDate);
                }
            }
        }
    }
}

presentation->Save(u"updated_dates.pptx", SaveFormat::Pptx);
presentation->Dispose();

auto reopened = System::MakeObject<Presentation>(u"updated_dates.pptx");
for (auto shape : reopened->get_Slide(0)->get_Shapes())
{
    auto textShape = System::DynamicCast<IAutoShape>(shape);
    if (textShape == nullptr || textShape->get_TextFrame() == nullptr)
        continue;
    if (textShape->get_Name() != u"UpdatedAt" && textShape->get_Name() != u"ApprovedDate")
        continue;

    auto portion = textShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
    auto field = portion->get_Field();
    auto typeName = field != nullptr ? field->get_Type()->get_InternalString() : u"ordinary text";
    System::Console::WriteLine(u"{0}: {1}; {2}", textShape->get_Name(), typeName, portion->get_Text());
    auto isItalic = portion->get_PortionFormat()->get_FontItalic() == NullableBool::True;
    System::Console::WriteLine(u"Italic: {0}", isItalic);
}
reopened->Dispose();
```

다시 열면 `UpdatedAt`은 유형 `datetime3`을 가지고 동적 상태를 유지해야 합니다. `ApprovedDate`는 필드가 없으며 `05 April 2030` 텍스트를 포함해야 합니다. 두 날짜 부분 모두 이탤릭이며 원래 글꼴 크기, 굵게 설정 및 색상은 그대로 유지됩니다. 일반 텍스트 라벨은 변경되지 않습니다. 검증은 제공된 샘플에서 두 알려진 도형의 첫 번째 부분을 읽습니다.

## **텍스트 서식 유지**

필드를 추가하거나 유형을 변경하거나 제거할 때 기존 부분을 사용합니다. 이러한 작업은 해당 부분의 서식을 유지합니다. 색상이나 이탤릭과 같이 필요한 속성만 변경하려면 [IPortion::get_PortionFormat](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iportion/get_portionformat/)을 사용하십시오.

하나의 필드만 업데이트하기 위해 전체 텍스트 프레임을 다시 구축하지 마세요. 이렇게 하면 원래 부분 경계와 개별 서식이 손실될 수 있습니다. 단락, 레이아웃 또는 테마에서 상속된 서식과 명시적으로 설정된 서식을 구분하십시오. 보다 폭넓은 서식 옵션은 [Text Formatting](/slides/ko/cpp/text-formatting/)을 참조하십시오.

## **필드와 머리글/바닥글 자리표시자**

필드는 텍스트 부분의 일부입니다. 자리표시자는 푸터나 슬라이드 번호와 같이 프레젠테이션 역할을 가진 도형입니다. 일반 텍스트 상자에 필드를 추가해도 해당 도형이 자리표시자로 변환되지 않습니다.

헤더/푸터 관리자는 슬라이드, 레이아웃 및 마스터에서 자리표시자 텍스트와 가시성을 제어하며, 종속 슬라이드로 전파됩니다. 슬라이드 번호 자리표시자를 사용하지 않더라도 사용자 정의 텍스트 상자의 번호 필드는 유용할 수 있습니다. 반대로, 자리표시자 가시성을 변경해도 무관한 텍스트 상자에 있는 필드는 제거되지 않습니다.

미리 정의된 헤더와 푸터 유형은 해당 자리표시자를 만들거나 내용을 제공하지 않습니다. 특히 일반 PowerPoint 슬라이드에는 헤더 자리표시자가 없으며, 헤더는 노트 페이지와 유인물에 속합니다. 임의 도형에 있는 헤더나 푸터 필드가 자리표시자 관리자를 통해 구성된 텍스트를 자동으로 얻는다고 가정하지 마세요. 해당 워크플로는 [Presentation Headers and Footers](/slides/ko/cpp/presentation-header-and-footer/)를 참조하십시오.

## **PPTX 및 PPT 제한 사항**

저장하고 다시 연 후 필드 유형과 결과 텍스트를 모두 확인하십시오. 식별자를 보존한다고 해서 애플리케이션이 값을 계산하거나 표시할 수 있다는 증명이 되지는 않습니다.

| 형식 | 필드 동작 및 제한 사항 |
|---|---|
| PPTX | 필드 텍스트와 함께 내부 필드 식별자를 저장합니다. 위 예제를 사용해 저장·재열 후 미리 정의된 유형 및 사용자 정의 식별자를 확인하십시오. 알 수 없는 사용자 정의 유형은 자동 계산 로직을 획득하지 않습니다. 다른 애플리케이션은 지원되지 않는 식별자를 다르게 처리할 수 있습니다. |
| PPT | 오래된 필드 표현을 사용하며 호환성이 더 제한적입니다. 슬라이드 번호와 미리 정의된 날짜/시간 필드는 오래된 형태로 저장됩니다. 일반 슬라이드 텍스트 상자에서 지원되지 않는 사용자 정의 필드나 헤더 필드는 텍스트가 `*`로 표시될 수 있습니다. 사용자 정의 필드나 지원되지 않는 필드 컨텍스트가 가시 텍스트를 유지한다는 가정은 하지 마세요. |

휴대 가능한 고정 출력을 위해 지원되지 않는 필드를 일반 텍스트로 변환하고 저장 전에 원하는 값을 명시적으로 할당하십시오. 이렇게 하면 선택된 텍스트는 보존되지만 자동 업데이트는 의도적으로 중단됩니다. 워크플로에 자체 필드 재계산이 포함된 경우 대상 애플리케이션도 테스트하십시오.

## **FAQ**

**표시된 번호나 날짜가 필드인지 어떻게 알 수 있나요?**

[IPortion::get_Field](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iportion/get_field/)를 검사하십시오. null이 아닌 값이 필드를 식별하며, 표시된 텍스트만으로는 판단할 수 없습니다.

**필드를 제거하면 텍스트나 서식도 제거되나요?**

아니요. [RemoveField](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iportion/removefield/)은 기존 부분을 일반 텍스트로 변환합니다. 필요하다면 이후에 명시적인 값을 할당하여 고정된 날짜나 대체값을 지정하십시오.

**내부 문자열이 새로운 날짜 형식이나 수식을 정의할 수 있나요?**

아니요. 이는 필드 유형을 식별할 뿐이며, 알 수 없는 식별자는 평가기나 날짜 형식 패턴을 제공하지 않습니다. 지원되는 미리 정의된 유형을 사용하거나 값을 일반 텍스트로 직접 서식 지정하십시오.

**프레젠테이션을 저장한 후 다시 확인해야 하는 이유는?**

필드 식별자, 계산된 텍스트 및 서식은 별개의 요소이므로 각각을 검증해야 합니다. 형식 변환은 필드 식별자는 그대로 유지돼도 가시 결과를 바꿀 수 있습니다.
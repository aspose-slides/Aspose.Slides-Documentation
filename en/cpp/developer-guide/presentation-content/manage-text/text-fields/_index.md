---
title: Manage Text Fields in PowerPoint Presentations in C++
linktitle: Text Fields
type: docs
weight: 52
url: /cpp/text-fields/
keywords:
- text field
- automatic text
- slide number
- date and time
- header
- footer
- text portion
- PowerPoint
- PPT
- PPTX
- C++
- Aspose.Slides
description: "Create, inspect, modify, and remove text fields in PowerPoint presentations with Aspose.Slides for C++. Preserve formatting and check saved PPTX and PPT files."
---

## **Overview**

A text paragraph consists of portions. An ordinary [IPortion](https://reference.aspose.com/slides/cpp/aspose.slides/iportion/) contains literal text; a field portion also has an [IField](https://reference.aspose.com/slides/cpp/aspose.slides/ifield/) whose type identifies an automatically updated value, such as a slide number or date. Two portions can display the same characters while only one contains a field.

Use [IPortion::get_Field](https://reference.aspose.com/slides/cpp/aspose.slides/iportion/get_field/) to distinguish them: it returns `nullptr` for ordinary text. [IPortion::AddField](https://reference.aspose.com/slides/cpp/aspose.slides/iportion/addfield/) converts an existing portion into a field. Keep a label and its dynamic value in separate portions so that converting the value does not also replace the label.

This guide covers fields inside text, their formatting, and saving them in PPTX and PPT. For text frames and paragraphs, see [Manage Text](/slides/cpp/manage-text/).

## **Create a Slide Number Field**

The following example creates a text box containing a literal `Slide ` label followed by an automatically updated number. It sets the number's size, weight, and color before adding the field, then reopens the saved presentation and checks the field type, text, and formatting. No input file is required.

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

The new presentation starts with slide number 1, so the expected text is `Slide 1`, and both checks should print `True`. The number remains a field after reopening; it is not a literal `1`. The cast and indices in the verification refer to the shape and portions created by this example.

## **Choose a Field Type**

[FieldType](https://reference.aspose.com/slides/cpp/aspose.slides/fieldtype/) implements [IFieldType](https://reference.aspose.com/slides/cpp/aspose.slides/ifieldtype/) and provides the following predefined values. Pass the appropriate value to [AddField](https://reference.aspose.com/slides/cpp/aspose.slides/iportion/addfield/).

| Accessor | Purpose |
|---|---|
| [get_SlideNumber](https://reference.aspose.com/slides/cpp/aspose.slides/fieldtype/get_slidenumber/) | The current slide number. |
| [get_DateTime](https://reference.aspose.com/slides/cpp/aspose.slides/fieldtype/get_datetime/) | Date/time in the rendering application's default format. |
| [get_DateTime1](https://reference.aspose.com/slides/cpp/aspose.slides/fieldtype/get_datetime1/)–[get_DateTime9](https://reference.aspose.com/slides/cpp/aspose.slides/fieldtype/get_datetime9/) | Predefined date or combined date/time formats. |
| [get_DateTime10](https://reference.aspose.com/slides/cpp/aspose.slides/fieldtype/get_datetime10/)–[get_DateTime13](https://reference.aspose.com/slides/cpp/aspose.slides/fieldtype/get_datetime13/) | Predefined time formats, with options for seconds and a 12-hour clock. |
| [get_Header](https://reference.aspose.com/slides/cpp/aspose.slides/fieldtype/get_header/) | A header field; see the placeholder and format limitations below. |
| [get_Footer](https://reference.aspose.com/slides/cpp/aspose.slides/fieldtype/get_footer/) | A footer field. |

For example, [get_DateTime3](https://reference.aspose.com/slides/cpp/aspose.slides/fieldtype/get_datetime3/) provides a day, full month name, and year in English. These are predefined field formats, not arbitrary date-format strings. The portion's language, set with [IBasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseportionformat/set_languageid/), and the application processing the presentation can affect the displayed result.

## **Create a Field from an Internal String**

The string overload of [AddField](https://reference.aspose.com/slides/cpp/aspose.slides/iportion/addfield/) accepts an internal field identifier. Use it when preserving an identifier supplied by another application that has no predefined value. You can also construct a [FieldType](https://reference.aspose.com/slides/cpp/aspose.slides/fieldtype/fieldtype/) from the identifier. [IFieldType::get_InternalString](https://reference.aspose.com/slides/cpp/aspose.slides/ifieldtype/get_internalstring/) exposes that identifier for inspection.

This example stores an application-specific `custom-report-id` field with the fallback text `Report-042`. No input file is required. The identifier does not register a calculation: Aspose.Slides does not generate report IDs for an unknown type. The application that understands this identifier must supply its meaning and update its value.

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

After this PPTX round trip, the expected type is `custom-report-id` and the expected text is `Report-042`. Passing a string such as `yyyy-MM-dd` would name a field type; it would not configure a custom date format. For a fixed date in an arbitrary format, use ordinary text.

## **Inspect, Modify, and Remove Date/Time Fields**

Read an existing field type through [IField::get_Type](https://reference.aspose.com/slides/cpp/aspose.slides/ifield/get_type/) and change it through [IField::set_Type](https://reference.aspose.com/slides/cpp/aspose.slides/ifield/set_type/). Check that the field exists before accessing its type. To stop automatic updates, call [IPortion::RemoveField](https://reference.aspose.com/slides/cpp/aspose.slides/iportion/removefield/). This keeps the portion and its current text while removing the field association. If you need a specific fixed value, assign that text after removing the field.

For the API setting associated with date/time field processing, see [Presentation::set_CurrentDateTime](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/set_currentdatetime/). The example below uses an explicit approval date when converting a field to ordinary text.

Download [sample.pptx](sample.pptx) and place it in the working directory. It contains two named text shapes, `UpdatedAt` and `ApprovedDate`, each with a date/time field, plus ordinary text labels. The following example walks top-level text shapes on regular slides. It changes date/time fields to a long-date format and makes them italic, while preserving their other formatting. Only fields in `ApprovedDate` become fixed text.

The sample recognizes the built-in internal identifiers `datetime` and `datetime1` through `datetime13`. Groups, tables, notes, layouts, and masters require traversal of their own text containers and are outside this example's scope.

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

After reopening, `UpdatedAt` should have type `datetime3` and remain dynamic. `ApprovedDate` should have no field and contain `05 April 2030`. Both date portions are italic, and their original font size, bold setting, and color remain intact. The ordinary text labels are unchanged. The verification reads the first portion of the two known shapes in the supplied sample.

## **Preserve Text Formatting**

Work with the existing portion when adding a field, changing its type, or removing it. These operations retain that portion's formatting. Use [IPortion::get_PortionFormat](https://reference.aspose.com/slides/cpp/aspose.slides/iportion/get_portionformat/) to change only the required properties, as the examples do for color or italics.

Avoid rebuilding an entire text frame just to update one field: doing so can lose the original portion boundaries and their individual formatting. Also distinguish explicitly set formatting from formatting inherited from the paragraph, layout, or theme. See [Text Formatting](/slides/cpp/text-formatting/) for broader formatting options.

## **Fields and Header/Footer Placeholders**

A field is part of a text portion. A placeholder is a shape with a presentation role, such as a footer or slide number. Adding a field to an ordinary text box does not turn that shape into a placeholder.

The header/footer managers control placeholder text and visibility on slides, layouts, and masters, including propagation to dependent slides. A number field in a custom text box can therefore be useful even when you are not using the slide-number placeholder. Conversely, changing placeholder visibility does not remove a field from an unrelated text box.

The predefined header and footer types do not create the corresponding placeholders or supply their content. In particular, a regular PowerPoint slide has no header placeholder; headers belong to notes pages and handouts. Do not assume that a header or footer field in an arbitrary shape will automatically obtain the text configured through a placeholder manager. For that workflow, see [Presentation Headers and Footers](/slides/cpp/presentation-header-and-footer/).

## **PPTX and PPT Limitations**

Check both the field type and its resulting text after saving and reopening. Preserving an identifier does not prove that an application can calculate or display its value.

| Format | Field behavior and limitations |
|---|---|
| PPTX | Stores internal field identifiers alongside field text. Use the examples above to check predefined types and custom identifiers after saving and reopening. An unknown custom type does not acquire automatic calculation logic. Another application may treat unsupported identifiers differently. |
| PPT | Uses legacy field representations and has more limited compatibility. Slide-number and predefined date/time fields have legacy representations. Unsupported custom fields or header fields in an ordinary slide text box can produce `*` as their text. Do not rely on custom fields or unsupported field contexts retaining their visible text. |

For portable, fixed output, convert unsupported fields to ordinary text and explicitly assign the value you want before saving. This preserves the chosen text but intentionally stops automatic updates. Test the target application as well when its own field recalculation is part of your workflow.

## **FAQ**

**How can I tell whether a displayed number or date is a field?**

Inspect [IPortion::get_Field](https://reference.aspose.com/slides/cpp/aspose.slides/iportion/get_field/). A non-null value identifies a field; the displayed text alone cannot tell you.

**Does removing a field remove its text or formatting?**

No. [RemoveField](https://reference.aspose.com/slides/cpp/aspose.slides/iportion/removefield/) converts the existing portion to ordinary text. Assign an explicit value afterward if you need a particular frozen date or fallback value.

**Can an internal string define a new date format or formula?**

No. It identifies a field type. An unknown identifier does not provide an evaluator or a date-format pattern. Use a supported predefined type or format a value yourself as ordinary text.

**Why check a presentation again after saving it?**

Field identifiers, calculated text, and formatting are separate things to verify. Format conversion can change the visible result even when the field identifier is still present.

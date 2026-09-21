---
title: إدارة حقول النص في عروض PowerPoint التقديمية بلغة C++
linktitle: حقول النص
type: docs
weight: 52
url: /ar/cpp/text-fields/
keywords:
- حقل نص
- نص تلقائي
- رقم الشريحة
- التاريخ والوقت
- رأس الصفحة
- تذييل الصفحة
- جزء نص
- PowerPoint
- PPT
- PPTX
- C++
- Aspose.Slides
description: "إنشاء، فحص، تعديل، وإزالة حقول النص في عروض PowerPoint التقديمية باستخدام Aspose.Slides للغة C++. الحفاظ على التنسيق والتحقق من ملفات PPTX و PPT المحفوظة."
---
## **نظرة عامة**

يتكون فقرة النص من أجزاء. يحتوي [IPortion](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iportion/) العادي على نص حرفي؛ يحتوي جزء الحقل أيضًا على [IField](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ifield/) يحدد نوعه قيمة يتم تحديثها تلقائيًا، مثل رقم الشريحة أو التاريخ. يمكن لجزأين عرض نفس الأحرف بينما يحتوي أحدهما فقط على حقل.

استخدم [IPortion::get_Field](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iportion/get_field/) للتمييز بينهما: يُعيد `nullptr` للنص العادي. يقوم [IPortion::AddField](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iportion/addfield/) بتحويل جزء موجود إلى حقل. احتفظ بالعلامة والقيمة الديناميكية في أجزاء منفصلة حتى لا يؤدي تحويل القيمة إلى استبدال العلامة.

يغطي هذا الدليل الحقول داخل النص، وتنسيقها، وحفظها في PPTX و PPT. للحصول على إطارات النص والفقرات، راجع [Manage Text](/slides/ar/cpp/manage-text/).

## **إنشاء حقل رقم الشريحة**

المثال التالي ينشئ مربع نص يحتوي على تسمية حرفية `Slide ` متبوعًا برقم يتم تحديثه تلقائيًا. يضبط حجم الرقم ووزنه ولونه قبل إضافة الحقل، ثم يعيد فتح العرض المحفوظ ويتحقق من نوع الحقل والنص والتنسيق. لا يلزم ملف إدخال.

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

يبدأ العرض الجديد برقم شريحة 1، لذلك يكون النص المتوقع هو `Slide 1`، ويجب أن تطبع كلتا الفحصين `True`. يظل الرقم حقلًا بعد إعادة الفتح؛ فهو ليس النص الحرفي `1`. الإشارة والمؤشرات في التحقق تشير إلى الشكل والأجزاء التي أنشأها هذا المثال.

## **اختيار نوع الحقل**

[FieldType](https://reference.aspose.com/slides/ar/cpp/aspose.slides/fieldtype/) ينفّذ [IFieldType](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ifieldtype/) ويوفر القيم المحددة مسبقًا التالية. مرّر القيمة المناسبة إلى [AddField](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iportion/addfield/).

| المستخرج | الغرض |
|---|---|
| [get_SlideNumber](https://reference.aspose.com/slides/ar/cpp/aspose.slides/fieldtype/get_slidenumber/) | رقم الشريحة الحالي. |
| [get_DateTime](https://reference.aspose.com/slides/ar/cpp/aspose.slides/fieldtype/get_datetime/) | التاريخ/الوقت بتنسيق التطبيق الافتراضي. |
| [get_DateTime1](https://reference.aspose.com/slides/ar/cpp/aspose.slides/fieldtype/get_datetime1/)–[get_DateTime9](https://reference.aspose.com/slides/ar/cpp/aspose.slides/fieldtype/get_datetime9/) | تواريخ أو تنسيقات تاريخ/وقت مُحددة مسبقًا. |
| [get_DateTime10](https://reference.aspose.com/slides/ar/cpp/aspose.slides/fieldtype/get_datetime10/)–[get_DateTime13](https://reference.aspose.com/slides/ar/cpp/aspose.slides/fieldtype/get_datetime13/) | تنسيقات وقت مُحددة مسبقًا، مع خيارات للثواني وساعة 12 ساعة. |
| [get_Header](https://reference.aspose.com/slides/ar/cpp/aspose.slides/fieldtype/get_header/) | حقل رأس الصفحة؛ راجع قيود العنصر النائب والتنسيق أدناه. |
| [get_Footer](https://reference.aspose.com/slides/ar/cpp/aspose.slides/fieldtype/get_footer/) | حقل تذييل الصفحة. |

على سبيل المثال، يوفر [get_DateTime3](https://reference.aspose.com/slides/ar/cpp/aspose.slides/fieldtype/get_datetime3/) يومًا، اسم شهر كامل، وسنة باللغة الإنجليزية. هذه تنسيقات حقل محددة مسبقًا، ليست سلاسل تنسيق تاريخ عشوائية. يمكن أن تؤثر لغة الجزء، التي تُضبط عبر [IBasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ibaseportionformat/set_languageid/)، والتطبيق الذي يعالج العرض على النتيجة المعروضة.

## **إنشاء حقل من سلسلة داخلية**

تقبل النسخة التي تستقبل سلسلة من [AddField](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iportion/addfield/) معرف حقل داخلي. استخدمها عند الحفاظ على معرف قدمه تطبيق آخر لا يملك قيمة محددة مسبقًا. يمكنك أيضًا إنشاء [FieldType](https://reference.aspose.com/slides/ar/cpp/aspose.slides/fieldtype/fieldtype/) من المعرف. يُظهر [IFieldType::get_InternalString](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ifieldtype/get_internalstring/) ذلك المعرف للفحص.

هذا المثال يخزن حقلًا خاصًا بالتطبيق `custom-report-id` مع النص الاحتياطي `Report-042`. لا يلزم ملف إدخال. المعرف لا يسجل حسابًا: Aspose.Slides لا يُنشئ معرفات تقارير لأنواع غير معروفة. يجب على التطبيق الذي يفهم هذا المعرف توفير معناه وتحديث قيمته.

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

بعد جولة حفظ وإعادة فتح PPTX، يكون النوع المتوقع هو `custom-report-id` والنص المتوقع هو `Report-042`. تمرير سلسلة مثل `yyyy-MM-dd` سيحدد نوع حقل؛ لن يكوّن تنسيق تاريخ مخصص. لتاريخ ثابت بأي تنسيق اختياري، استخدم نصًا عاديًا.

## **فحص، تعديل، وإزالة حقول التاريخ/الوقت**

اقرأ نوع حقل موجود عبر [IField::get_Type](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ifield/get_type/) وغيّره عبر [IField::set_Type](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ifield/set_type/). تحقق من وجود الحقل قبل الوصول إلى نوعه. لإيقاف التحديثات التلقائية، استدعِ [IPortion::RemoveField](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iportion/removefield/). هذا يبقي الجزء ونصه الحالي مع إزالة ارتباط الحقل. إذا كنت تحتاج قيمة ثابتة محددة، عيّن ذلك النص بعد إزالة الحقل.

لإعداد واجهة برمجة التطبيقات المرتبطة بمعالجة حقول التاريخ/الوقت، راجع [Presentation::set_CurrentDateTime](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/set_currentdatetime/). يستخدم المثال أدناه تاريخ موافقة صريح عند تحويل حقل إلى نص عادي.

حمّل [sample.pptx](sample.pptx) وضعه في دليل العمل. يحتوي على شكلين نصيين مسميين، `UpdatedAt` و `ApprovedDate`، كل منهما به حقل تاريخ/وقت، بالإضافة إلى تسميات نصية عادية. يتجول المثال التالي عبر الأشكال النصية على الشرائح العادية. يغيّر حقول التاريخ/الوقت إلى تنسيق تاريخ طويل ويجعلها مائلة، مع الحفاظ على باقي التنسيقات. فقط الحقول في `ApprovedDate` تصبح نصًا ثابتًا.

التعرف على المعرفات الداخلية المدمجة `datetime` و `datetime1` حتى `datetime13`. المجموعات والجداول والملاحظات والتنسيقات الرئيسية تحتاج إلى استعراض حاويات النص الخاصة بها وهي خارج نطاق هذا المثال.

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

بعد إعادة الفتح، يجب أن يكون لـ `UpdatedAt` النوع `datetime3` ويظل ديناميكيًا. يجب أن لا يحتوي `ApprovedDate` على حقل ويحتوي على `05 April 2030`. كلا جزئي التاريخ مائلان، ويظل حجم الخط الأصلي، وإعداد السُمك، واللون كما كان. تبقى تسميات النص العادي دون تغيير. يقرأ التحقق الجزء الأول من الشكلين المعروفين في العينة المرفقة.

## **الحفاظ على تنسيق النص**

اعمل مع الجزء الموجود عند إضافة حقل أو تغيير نوعه أو إزالته. هذه العمليات تحتفظ بتنسيق ذلك الجزء. استخدم [IPortion::get_PortionFormat](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iportion/get_portionformat/) لتغيير الخصائص المطلوبة فقط، كما تفعل الأمثلة للون أو الميل.

تجنب إعادة بناء إطار نص كامل فقط لتحديث حقل واحد: قد يؤدي ذلك إلى فقدان حدود الأجزاء الأصلية وتنسيقها الفردي. كذلك ميز بين التنسيق المحدد صراحةً والتنسيق الموروث من الفقرة أو التنسيق أو السمة. راجع [Text Formatting](/slides/ar/cpp/text-formatting/) للحصول على خيارات تنسيق أوسع.

## **الحقول وعناصر العنصر النائب للرأس/التذييل**

الحقل هو جزء من جزء النص. العنصر النائب هو شكل له دور في العرض، مثل تذييل أو رقم شريحة. إضافة حقل إلى مربع نص عادي لا يحول ذلك الشكل إلى عنصر نائب.

يدير مديرو الرأس/التذييل نص العنصر النائب ورؤيته على الشرائح، التنسيقات، والماستر، بما في ذلك انتشار التغييرات إلى الشرائح التابعة. لذا يمكن أن يكون حقل رقم في مربع نص مخصص مفيدًا حتى إذا لم تستخدم عنصر نائب رقم الشريحة. بالمقابل، تغيير رؤية العنصر النائب لا يزيل الحقل من مربع نص غير مرتبط.

أنواع الرأس والتذييل المحددة مسبقًا لا تنشئ العناصر النائب المقابلة ولا تزودها بمحتواها. على وجه الخصوص، لا يحتوي شريحة PowerPoint عادية على عنصر نائب رأس؛ تتواجد الرؤوس في صفحات الملاحظات والنشرات. لا تفترض أن حقل رأس أو تذييل في شكل عشوائي سيحصل تلقائيًا على النص المكوّن عبر مدير العنصر النائب. لهذا سير العمل، راجع [Presentation Headers and Footers](/slides/ar/cpp/presentation-header-and-footer/).

## **قيود PPTX و PPT**

تحقق من كل من نوع الحقل والنص الناتج بعد الحفظ وإعادة الفتح. الحفاظ على معرف لا يثبت أن تطبيقًا ما يستطيع حساب أو عرض قيمته.

| التنسيق | سلوك الحقل والقيود |
|---|---|
| PPTX | يخزن معرفات الحقول الداخلية إلى جانب نص الحقل. استخدم الأمثلة أعلاه للتحقق من الأنواع المحددة مسبقًا والمعرفات المخصصة بعد الحفظ وإعادة الفتح. النوع المخصص غير المعروف لا يكتسب منطق حساب تلقائي. قد يعامل تطبيق آخر المعرفات غير المدعومة بشكل مختلف. |
| PPT | يستخدم تمثيلات حقول قديمة وله توافقية أكثر محدودية. حقول رقم الشريحة والوقت/التاريخ المحددة مسبقًا لها تمثيلات قديمة. الحقول المخصصة غير المدعومة أو حقول الرأس في مربع نص شريحة عادي يمكن أن تُظهر `*` كنص. لا تعتمد على حفاظ الحقول المخصصة أو السياقات غير المدعومة على نصها الظاهر. |

لإنتاج ثابت ومحمول، حوّل الحقول غير المدعومة إلى نص عادي وعين القيمة التي تريدها صراحةً قبل الحفظ. هذا يحفظ النص المختار لكنه يوقف التحديثات التلقائية عن عمد. اختبر التطبيق الهدف أيضًا عندما يكون إعادة حساب الحقول جزءًا من سير عملك.

## **الأسئلة الشائعة**

**كيف يمكنني معرفة ما إذا كان الرقم أو التاريخ المعروض حقلًا؟**

افحص [IPortion::get_Field](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iportion/get_field/). قيمة غير فارغة تُعرّف حقلًا؛ لا يمكن للنص الظاهر وحده أن يحدد ذلك.

**هل إزالة الحقل تُزيل نصه أو تنسيقه؟**

لا. تقوم [RemoveField](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iportion/removefield/) بتحويل الجزء الموجود إلى نص عادي. عيّن قيمة صريحة بعد ذلك إذا كنت بحاجة إلى تاريخ ثابت أو قيمة احتياطية.

**هل يمكن لسلسلة داخلية تعريف تنسيق تاريخ أو صيغة جديدة؟**

لا. هي مجرد معرف لنوع الحقل. المعرف غير المعروف لا يوفر مقيمًا أو نمط تاريخ. استخدم نوعًا محددًا مسبقًا مدعومًا أو نسق القيمة كالنص العادي بنفسك.

**لماذا أفحص العرض مرة أخرى بعد حفظه؟**

معرفات الحقول، النص المُحسب، والتنسيق هي أشياء منفصلة تحتاج إلى تحقق. قد يغيّر تحويل التنسيق النتيجة الظاهرة حتى مع بقاء معرف الحقل موجودًا.
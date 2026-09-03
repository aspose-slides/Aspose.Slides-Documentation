---
title: إدارة صناديق النص في العروض التقديمية باستخدام C++
linktitle: إدارة صندوق النص
type: docs
weight: 20
url: /ar/cpp/manage-textbox/
keywords:
- صندوق نص
- إطار نص
- إضافة نص
- تحديث نص
- إنشاء صندوق نص
- التحقق من صندوق النص
- إضافة عمود نص
- إضافة ارتباط تشعبي
- PowerPoint
- عرض تقديمي
- C++
- Aspose.Slides
description: "إنشاء وتحديد وتنسيق وتحديث صناديق النص في عروض PowerPoint وOpenDocument باستخدام Aspose.Slides للـ C++."
---
## **مقدمة**

في Aspose.Slides للـ C++، يتم تخزين نص الشريحة في إطارات نصية تنتمي إلى الأشكال. تمثل الواجهة [IAutoShape](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iautoshape/) الشكل الأكثر شيوعًا الذي يحمل نصًا وتكشف نصه عبر طريقة [IAutoShape::get_TextFrame](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iautoshape/get_textframe/).

{{% alert color="info" title="ملاحظة" %}}

كل شكل تلقائي ينفذ [IShape](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ishape/)، ولكن ليس كل شكل هو شكل تلقائي أو يدعم إطار نص. عند معالجة عرض تقديمي موجود، تحقق من أن الشكل ينفذ [IAutoShape](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iautoshape/) قبل الوصول إلى نصه.

{{% /alert %}}

## **إنشاء صندوق نص على شريحة**

لإنشاء صندوق نص، أضف شكلاً تلقائيًا إلى شريحة، أضف نصًا إلى إطاره النصي، واحفظ العرض التقديمي. المثال التالي ينشئ صندوق نص مستطيل:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/shared_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto textBox = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150, 75, 300, 50);
textBox->AddTextFrame(u"Aspose TextBox");

presentation->Save(u"TextBox.pptx", SaveFormat::Pptx);
```

الإحداثيات والأبعاد التي تمرر إلى [IShapeCollection::AddAutoShape](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ishapecollection/addautoshape/) تقاس بالنقاط. تقوم [IAutoShape::AddTextFrame](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iautoshape/addtextframe/) بتهيئة إطار النص بالنص المقدم.

## **التحقق من وجود شكل صندوق نص**

استخدم طريقة [IAutoShape::get_IsTextBox](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iautoshape/get_istextbox/) لتحديد ما إذا كان الشكل التلقائي يُعامل كصندوق نص. هذا مفيد عندما يحتوي العرض التقديمي على كل من الأشكال التي تحمل نصًا والأشكال الرسومية فقط.

![صندوق نص وشكل](istextbox.png)

المثال التالي يفحص كل شكل تلقائي في عرض تقديمي:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/console.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto textBox = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 10, 120, 40);
textBox->AddTextFrame(u"Text box");
slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 150, 10, 40, 40);

for (const auto& currentSlide : IterateOver(presentation->get_Slides()))
{
    for (const auto& shape : IterateOver(currentSlide->get_Shapes()))
    {
        auto autoShape = AsCast<IAutoShape>(shape);
        if (autoShape != nullptr)
        {
            Console::WriteLine(autoShape->get_IsTextBox() ? u"The shape is a text box." : u"The shape is not a text box.");
        }
    }
}
```

الشكل التلقائي المضاف حديثًا لا يُعتبر صندوق نص إلا إذا احتوى على نص غير فارغ. يمكنك إمداد هذا النص عبر [IAutoShape::AddTextFrame](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iautoshape/addtextframe/) أو [ITextFrame::set_Text](https://reference.aspose.com/slides/ar/cpp/aspose.slides/itextframe/set_text/). إضافة أو تعيين سلسلة فارغة يجعل [IAutoShape::get_IsTextBox](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iautoshape/get_istextbox/) تُعيد `false`:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/console.h>
#include <system/shared_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape1 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 10, 100, 40);
shape1->AddTextFrame(u"Shape 1");
Console::WriteLine(shape1->get_IsTextBox());

auto shape2 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 70, 100, 40);
shape2->get_TextFrame()->set_Text(u"Shape 2");
Console::WriteLine(shape2->get_IsTextBox());

auto shape3 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 130, 100, 40);
shape3->AddTextFrame(u"");
Console::WriteLine(shape3->get_IsTextBox());

auto shape4 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 190, 100, 40);
shape4->get_TextFrame()->set_Text(u"");
Console::WriteLine(shape4->get_IsTextBox());
```

الفحصان الأولان يُعيدان `true`؛ الفحصان الأخيران يُعيدان `false`.

## **العثور على الشكل الذي يمتلك إطار نص**

قد يتلقى كود معالجة النص العامة كائنًا من نوع [ITextFrame](https://reference.aspose.com/slides/ar/cpp/aspose.slides/itextframe/) دون معرفة أي كائن عرض تقديمي يحتويه. استخدم طريقة [ITextFrame::get_ParentShape](https://reference.aspose.com/slides/ar/cpp/aspose.slides/itextframe/get_parentshape/) للعودة إلى [IShape](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ishape/) المالك.

بالنسبة لإطار نص مملوك لشكل تلقائي أو شكل آخر يحمل نصًا، تُرجع [ITextFrame::get_ParentShape](https://reference.aspose.com/slides/ar/cpp/aspose.slides/itextframe/get_parentshape/) المالك و[ITextFrame::get_ParentCell](https://reference.aspose.com/slides/ar/cpp/aspose.slides/itextframe/get_parentcell/) تُعيد `nullptr`. كلا الطريقتين توفران تنقلًا للقراءة فقط. تحقق من القيمة المرتجعة لتكون ليست `nullptr` قبل الوصول إليها. لتحديد كل من مالكي الشكل وخلايا الجدول، بما في ذلك الأشكال المرتبطة بعقد SmartArt، راجع [Search and Replace Text](/slides/ar/cpp/search-and-replace-text/).

## **إضافة أعمدة إلى صندوق نص**

تقسّم طريقة [ITextFrameFormat::set_ColumnCount](https://reference.aspose.com/slides/ar/cpp/aspose.slides/itextframeformat/set_columncount/) إطار النص إلى أعمدة، بينما تُحدد طريقة [ITextFrameFormat::set_ColumnSpacing](https://reference.aspose.com/slides/ar/cpp/aspose.slides/itextframeformat/set_columnspacing/) الفجوة بين الأعمدة بالنقاط. كلا الطريقتين تنتميان إلى [ITextFrameFormat](https://reference.aspose.com/slides/ar/cpp/aspose.slides/itextframeformat/) ويمكن استدعاؤهما عبر إطار النص لصندوق نص موجود. يعاد تدفق النص بين الأعمدة داخل الشكل نفسه؛ لا يستمر في شكل آخر.

المثال التالي ينشئ صندوق نص بثلاثة أعمدة مع 10 نقاط بين الأعمدة، يحفظ العرض التقديمي، ويقرأ الإعدادات المخزنة مرة أخرى من الملف الناتج:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto textBox = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 300, 200);
textBox->AddTextFrame(u"This text is distributed automatically across all columns in the text box.");

auto textFrameFormat = textBox->get_TextFrame()->get_TextFrameFormat();
textFrameFormat->set_ColumnCount(3);
textFrameFormat->set_ColumnSpacing(10);

presentation->Save(u"TextBoxColumns.pptx", SaveFormat::Pptx);

auto savedPresentation = MakeObject<Presentation>(u"TextBoxColumns.pptx");
auto savedTextBox = ExplicitCast<IAutoShape>(savedPresentation->get_Slide(0)->get_Shape(0));
auto savedFormat = savedTextBox->get_TextFrame()->get_TextFrameFormat();
Console::WriteLine(u"Columns: {0}; spacing: {1} points", savedFormat->get_ColumnCount(), savedFormat->get_ColumnSpacing());
```

## **استخراج النص من الأعمدة الفردية**

استخدم [ITextFrame::SplitTextByColumns](https://reference.aspose.com/slides/ar/cpp/aspose.slides/itextframe/splittextbycolumns/) لاسترجاع النص المخصص لكل عمود بصري في إطار نص موجود. تُعيد الطريقة سلسلة واحدة لكل عمود، وفق ترتيب القراءة القائم على الأعمدة. يُنتج إطار نص بعمود واحد مصفوفة ذات عنصر واحد، والعمود الفارغ يُمثَّل بسلسلة فارغة. السلاسل تحتوي على نص عادي فقط؛ لا يتم حفظ تنسيق المستوى الجزئي.

هذا مفيد عندما تحتاج إلى:

- استخراج النص مع الحفاظ على ترتيب القراءة القائم على الأعمدة.
- فهرسة أو مقارنة محتوى الشرائح متعددة الأعمدة.
- تصدير كل عمود إلى ملف منفصل أو حقل قاعدة بيانات أو وجهة أخرى.
- فحص كيفية إعادة توزيع النص بعد ضبط عدد الأعمدة باستخدام [ITextFrameFormat::set_ColumnCount](https://reference.aspose.com/slides/ar/cpp/aspose.slides/itextframeformat/set_columncount/) أو الفجوة باستخدام [ITextFrameFormat::set_ColumnSpacing](https://reference.aspose.com/slides/ar/cpp/aspose.slides/itextframeformat/set_columnspacing/)، أو تغيير الخط أو حجم إطار النص.

تُبلغ الطريقة النص المُوزَّع داخل [ITextFrame](https://reference.aspose.com/slides/ar/cpp/aspose.slides/itextframe/) الحالي؛ لا تقوم تلقائيًا بتدفق النص بين أشكال أو صناديق نص منفصلة. قد يعتمد توزيع الأعمدة على الخطوط المتاحة وإعدادات تخطيط النص الأخرى، لذا تأكد من توفر الخطوط المطلوبة عندما تكون النتائج المتسقة مهمة.

المثال التالي يحمل عرضًا تقديميًا، يجد أول شكل تلقائي متعدد الأعمدة يحتوي على إطار نص في الشريحة الأولى، يقرأ عدد الأعمدة المكوَّن، ويكتب النص من كل عمود إلى ملف منفصل. تُتخطى الأشكال التي لا توفر إطار نص.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/Presentation.h>
#include <system/array.h>
#include <system/console.h>
#include <system/enumerator_adapter.h>
#include <system/io/file.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"MultiColumnText.pptx");

SharedPtr<IAutoShape> textBox = nullptr;
for (const auto& shape : IterateOver(presentation->get_Slide(0)->get_Shapes()))
{
    auto autoShape = AsCast<IAutoShape>(shape);
    if (autoShape != nullptr && autoShape->get_TextFrame() != nullptr)
    {
        auto columnCount = autoShape->get_TextFrame()->get_TextFrameFormat()->get_ColumnCount();
        if (columnCount > 1)
        {
            textBox = autoShape;
            break;
        }
    }
}

if (textBox == nullptr)
{
    Console::WriteLine(u"No multi-column text frame was found.");
}
else
{
    auto textFrame = textBox->get_TextFrame();
    auto configuredColumnCount = textFrame->get_TextFrameFormat()->get_ColumnCount();
    auto columnTexts = textFrame->SplitTextByColumns();

    Console::WriteLine(u"Configured columns: {0}", configuredColumnCount);

    for (auto columnIndex = 0; columnIndex < columnTexts->get_Length(); columnIndex++)
    {
        auto columnNumber = columnIndex + 1;
        auto columnText = columnTexts->idx_get(columnIndex);
        Console::WriteLine(u"Column {0}: {1}", columnNumber, columnText);
        auto fileName = String::Format(u"Column-{0}.txt", columnNumber);
        File::WriteAllText(fileName, columnText);
    }
}
```

## **تحديث النص**

لتحديث النص في جميع أنحاء العرض التقديمي، قم بالتكرار عبر الشرائح والأشكال، حدد الأشكال التلقائية، ثم حرر مقاطع النص الخاصة بها. يتيح لك العمل على مستوى المقطع تغيير كل من النص وتنسيق الأحرف.

المثال التالي يستبدل كل ظهور لـ `years` بـ `months` داخل مقاطع النص للأشكال التلقائية ويجعل كل مقاطع متأثرة عريضة:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Text.pptx");

for (const auto& slide : IterateOver(presentation->get_Slides()))
{
    for (const auto& shape : IterateOver(slide->get_Shapes()))
    {
        auto autoShape = AsCast<IAutoShape>(shape);
        if (autoShape == nullptr || autoShape->get_TextFrame() == nullptr)
        {
            continue;
        }

        for (const auto& paragraph : IterateOver(autoShape->get_TextFrame()->get_Paragraphs()))
        {
            for (const auto& portion : IterateOver(paragraph->get_Portions()))
            {
                auto text = portion->get_Text();
                if (!String::IsNullOrEmpty(text) && text.Contains(u"years"))
                {
                    portion->set_Text(text.Replace(u"years", u"months"));
                    portion->get_PortionFormat()->set_FontBold(NullableBool::True);
                }
            }
        }
    }
}

presentation->Save(u"TextChanged.pptx", SaveFormat::Pptx);
```

هذا الاستعراض يُحدِّث النص فقط في الأشكال التلقائية. النص المخزن في الجداول أو المخططات أو SmartArt أو الأشكال المجمعة يتطلب استعراض مجموعات تلك الكائنات الخاصة.

## **إضافة صندوق نص مع ارتباط تشعبي**

يمكن إسناد ارتباط تشعبي إلى مقطع نص محدد، بحيث يكون ذلك النص فقط هو القابل للنقر. استخدم [IHyperlinkManager::SetExternalHyperlinkClick](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ihyperlinkmanager/setexternalhyperlinkclick/) لربط المقطع بعنوان URL خارجي.

المثال التالي ينشئ نصًا مرتبطًا ويحفظه إلى عرض تقديمي:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IHyperlinkManager.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/shared_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto textBox = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150, 150, 200, 50);
textBox->AddTextFrame(u"Aspose.Slides");

auto textPortion = textBox->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
textPortion->get_PortionFormat()->get_HyperlinkManager()->SetExternalHyperlinkClick(u"https://www.aspose.com/");

presentation->Save(u"Hyperlink.pptx", SaveFormat::Pptx);
```

## **الأسئلة المتكررة**

**ما الفرق بين صندوق النص وعلامة نائب النص في الشريحة الرئيسة أو شريحة التخطيط؟**

يمكن أن يرث [placeholder](/slides/ar/cpp/manage-placeholder/) موضعه وتنسيقه من [الشريحة الرئيسة](https://reference.aspose.com/slides/ar/cpp/aspose.slides/masterslide/) أو [شريحة التخطيط](https://reference.aspose.com/slides/ar/cpp/aspose.slides/layoutslide/). صندوق النص العادي هو شكل مستقل على الشريحة التي تم إنشاؤه فيها ولا يكتسب سلوك علامة نائب النص عند تغيير التخطيط.

**كيف يمكنني استبدال النص دون تغيير النص في المخططات أو الجداول أو SmartArt؟**

قصر الاستعراض على الأشكال التي تنفذ [IAutoShape](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iautoshape/)، كما هو موضح في مثال تحديث النص. المخططات والجداول وSmartArt تخزن النص في نماذج الكائنات الخاصة بها، لذا لا يتم تعديلها بهذه الحلقة.
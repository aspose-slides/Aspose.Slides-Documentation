---
title: إدارة مربعات النص في العروض التقديمية باستخدام C++
linktitle: إدارة مربع النص
type: docs
weight: 20
url: /ar/cpp/manage-textbox/
keywords:
- مربع نص
- إطار نص
- إضافة نص
- تحديث النص
- إنشاء مربع نص
- التحقق من مربع النص
- إضافة عمود نص
- إضافة رابط تشعبي
- PowerPoint
- عرض تقديمي
- C++
- Aspose.Slides
description: "يتيح Aspose.Slides للغة C++ إنشاء وتحرير واستنساخ مربعات النص بسهولة في ملفات PowerPoint وOpenDocument، مما يعزز أتمتة عروضك التقديمية."
---
## **المقدمة**

عادةً ما تكون النصوص على الشرائح موجودة في مربعات النص أو الأشكال. لذلك، لإضافة نص إلى شريحة، عليك إضافة مربع نص ثم وضع بعض النص داخل مربع النص. توفر Aspose.Slides للغة C++ الواجهة [IAutoShape](https://reference.aspose.com/slides/ar/cpp/class/aspose.slides.i_auto_shape) التي تسمح لك بإضافة شكل يحتوي على نص.

{{% alert title="Info" color="info" %}}

توفر Aspose.Slides أيضًا الواجهة [IShape](https://reference.aspose.com/slides/ar/cpp/class/aspose.slides.i_shape) التي تسمح لك بإضافة أشكال إلى الشرائح. ومع ذلك، ليس كل الأشكال التي تُضاف عبر واجهة `IShape` يمكنها احتواء نص. أما الأشكال التي تُضاف عبر واجهة [IAutoShape](https://reference.aspose.com/slides/ar/cpp/class/aspose.slides.i_auto_shape) فقد تحتوي على نص. 

{{% /alert %}}

{{% alert title="Note" color="warning" %}} 

لذلك، عند التعامل مع شكل ترغب في إضافة نص إليه، قد تحتاج إلى التحقق والتأكد من أنه تم تحويله عبر واجهة `IAutoShape`. فقط عندها ستتمكن من العمل مع [TextFrame](https://reference.aspose.com/slides/ar/cpp/class/aspose.slides.text_frame)، وهي خاصية ضمن `IAutoShape`. راجع قسم [Update Text](https://docs.aspose.com/slides/ar/cpp/manage-textbox/#update-text) في هذه الصفحة. 

{{% /alert %}}

## **إنشاء مربع نص على شريحة**

لإنشاء مربع نص على شريحة، اتبع الخطوات التالية:

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/ar/cpp/class/aspose.slides.presentation). 
2. الحصول على مرجع للشفرة الأولى في العرض التقديمي الجديد. 
3. إضافة كائن [IAutoShape](https://reference.aspose.com/slides/ar/cpp/class/aspose.slides.i_auto_shape) مع تعيين [ShapeType](https://reference.aspose.com/slides/ar/cpp/class/aspose.slides.i_geometry_shape#ad941a828a2d9dd58ae1417b5c00c9a5c) إلى `Rectangle` في موضع محدد على الشريحة والحصول على مرجع لكائن `IAutoShape` المضاف حديثًا. 
4. إضافة خاصية `TextFrame` إلى كائن `IAutoShape` الذي سيحمل نصًا. في المثال أدناه، أضفنا هذا النص: *Aspose TextBox*
5. أخيرًا، احفظ ملف PPTX عبر كائن `Presentation`. 

يعرض لك هذا الكود C++—تنفيذ للخطوات السابقة—كيفية إضافة نص إلى شريحة:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

// ينشئ كائن Presentation
auto pres = System::MakeObject<Presentation>();

// يحصل على الشريحة الأولى في العرض التقديمي
auto sld = pres->get_Slides()->idx_get(0);

// يضيف AutoShape مع تعيين النوع إلى Rectangle
auto ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 75.0f, 150.0f, 50.0f);

// يضيف TextFrame إلى الـ Rectangle
ashp->AddTextFrame(u" ");

// يصل إلى إطار النص
auto txtFrame = ashp->get_TextFrame();

// ينشئ كائن Paragraph لإطار النص
auto para = txtFrame->get_Paragraphs()->idx_get(0);

// ينشئ كائن Portion للفقرة
auto portion = para->get_Portions()->idx_get(0);

// يضبط النص
portion->set_Text(u"Aspose TextBox");

// يحفظ العرض التقديمي إلى القرص
pres->Save(u"TextBox_out.pptx", SaveFormat::Pptx);
```

## **التحقق من شكل مربع النص**

توفر Aspose.Slides طريقة [get_IsTextBox](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iautoshape/get_istextbox/) من واجهة [IAutoShape](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iautoshape/)، مما يتيح لك فحص الأشكال وتحديد مربعات النص.

![مربع نص وشكل](istextbox.png)

يظهر لك هذا الكود C++ كيفية التحقق مما إذا كان الشكل قد تم إنشاؤه كمربع نص: 

```c++
#include <DOM/IAutoShape.h>
#include <DOM/Presentation.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <system/console.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
for (auto&& slide : System::IterateOver(presentation->get_Slides()))
{
    for (auto&& shape : System::IterateOver(slide->get_Shapes()))
    {
        if (ObjectExt::Is<IAutoShape>(shape))
        {
            auto autoShape = ExplicitCast<IAutoShape>(shape);
            Console::WriteLine(autoShape->get_IsTextBox() ? u"shape is a text box" : u"shape is not a text box");
        }
    }
}

presentation->Dispose();
```

لاحظ أنه إذا قمت ببساطة بإضافة شكل تلقائي باستخدام طريقة `AddAutoShape` من واجهة [IShapeCollection](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ishapecollection/)، فإن طريقة `get_IsTextBox` للشكل التلقائي ستعيد `false`. ومع ذلك، بعد إضافة نص إلى الشكل التلقائي باستخدام طريقة `AddTextFrame` أو طريقة `set_Text`، تُعيد طريقة `get_IsTextBox` القيمة `true`.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape1 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 10, 100, 40);
// shape1->get_IsTextBox() ترجع false
shape1->AddTextFrame(u"shape 1");
// shape1->get_IsTextBox() ترجع true

auto shape2 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 110, 100, 40);
// shape2->get_IsTextBox() ترجع false
shape2->get_TextFrame()->set_Text(u"shape 2");
// shape2->get_IsTextBox() ترجع true

auto shape3 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 210, 100, 40);
// shape3->get_IsTextBox() ترجع false
shape3->AddTextFrame(u"");
// shape3->get_IsTextBox() ترجع false

auto shape4 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 310, 100, 40);
// shape4->get_IsTextBox() ترجع false
shape4->get_TextFrame()->set_Text(u"");
// shape4->get_IsTextBox() ترجع false
```

## **العثور على الشكل الذي يمتلك إطار النص**

في شفرة معالجة النصوص العامة، قد تستقبل كائن [ITextFrame](https://reference.aspose.com/slides/ar/cpp/aspose.slides/itextframe/) دون معرفة مسبقة أي كائن عرض تقديمي يحتويه. استخدم [ITextFrame::get_ParentShape](https://reference.aspose.com/slides/ar/cpp/aspose.slides/itextframe/get_parentshape/) للعودة إلى الشكل المالك [IShape](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ishape/).

بالنسبة لإطار نص ينتمي إلى [IAutoShape](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iautoshape/) أو شكل آخر يحتوي نصًا، تُعيد [ITextFrame::get_ParentShape](https://reference.aspose.com/slides/ar/cpp/aspose.slides/itextframe/get_parentshape/) المالك وتُعيد [ITextFrame::get_ParentCell](https://reference.aspose.com/slides/ar/cpp/aspose.slides/itextframe/get_parentcell/) القيمة `nullptr`. توفر الطريقتان تنقلًا للقراءة فقط، لذا لا يغيّر استدعاؤهما الملكية. تحقق دائمًا من أن القيمة المرتجعة ليست `nullptr` قبل الوصول إلى الشكل.

للحصول على مثال كامل يحدد مالكي الأشكال وخلايا الجداول، بما في ذلك الأشكال المرتبطة بعقد SmartArt، راجع [بحث واستبدال النص](/slides/ar/cpp/search-and-replace-text/).

## **إضافة أعمدة إلى مربع النص**

توفر Aspose.Slides الطريقتين [set_ColumnCount](https://reference.aspose.com/slides/ar/cpp/class/aspose.slides.i_text_frame_format#a969f998a2573e1540250855ce67df620) و[set_ColumnSpacing](https://reference.aspose.com/slides/ar/cpp/class/aspose.slides.i_text_frame_format#a5254ce6acdc2cd90f4db1c861a94716a) (من واجهة [ITextFrameFormat](https://reference.aspose.com/slides/ar/cpp/class/aspose.slides.i_text_frame_format) والفئة [TextFrameFormat](https://reference.aspose.com/slides/ar/cpp/class/aspose.slides.i_text_frame_format)) اللتين تتيحان لك إضافة أعمدة إلى مربعات النص. يمكنك تحديد عدد الأعمدة في مربع النص وتعيين مقدار التباعد بين الأعمدة بوحدات النقاط.

يوضح لك هذا الكود C++ العملية المذكورة: 

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = System::MakeObject<Presentation>();
// يحصل على الشريحة الأولى في العرض التقديمي
auto slide = presentation->get_Slides()->idx_get(0);

// إضافة AutoShape مع تعيين النوع إلى Rectangle
auto aShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 300.0f, 300.0f);

// إضافة TextFrame إلى الـ Rectangle
aShape->AddTextFrame(String(u"All these columns are limited to be within a single text container -- ") 
    + u"you can add or delete text and the new or remaining text automatically adjusts " 
    + u"itself to flow within the container. You cannot have text flow from one container " 
    + u"to other though -- we told you PowerPoint's column options for text are limited!");

// يحصل على تنسيق النص لإطار النص
auto format = aShape->get_TextFrame()->get_TextFrameFormat();

// تحديد عدد الأعمدة في TextFrame
format->set_ColumnCount(3);

// تحديد التباعد بين الأعمدة
format->set_ColumnSpacing(10);

// يحفظ العرض التقديمي
presentation->Save(u"ColumnCount.pptx", SaveFormat::Pptx);
```

## **إضافة أعمدة إلى إطار النص**

توفر Aspose.Slides للغة C++ طريقة [set_ColumnCount](https://reference.aspose.com/slides/ar/cpp/class/aspose.slides.i_text_frame_format#a969f998a2573e1540250855ce67df620) (من واجهة [ITextFrameFormat](https://reference.aspose.com/slides/ar/cpp/class/aspose.slides.i_text_frame_format)) التي تتيح لك إضافة أعمدة في إطارات النص. من خلال هذه الطريقة، يمكنك تحديد عدد الأعمدة المفضل لديك في إطار النص. 

يظهر لك هذا الكود C++ كيفية إضافة عمود داخل إطار النص:

```cpp
#include <DOM/AutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/TextFrameFormat.h>
#include <Export/SaveFormat.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

String outPptxFileName = u"ColumnsTest.pptx";
    
auto pres = System::MakeObject<Presentation>();
auto shape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 300.0f, 300.0f);
auto format = System::ExplicitCast<TextFrameFormat>(shape->get_TextFrame()->get_TextFrameFormat());

format->set_ColumnCount(2);
shape->get_TextFrame()->set_Text(String(u"All these columns are forced to stay within a single text container -- ") 
    + u"you can add or delete text - and the new or remaining text automatically adjusts " 
    + u"itself to stay within the container. You cannot have text spill over from one container " 
    + u"to other, though -- because PowerPoint's column options for text are limited!");
pres->Save(outPptxFileName, SaveFormat::Pptx);

{
    auto test = System::MakeObject<Presentation>(outPptxFileName);
    auto format1 = System::ExplicitCast<AutoShape>(test->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0))->get_TextFrame()->get_TextFrameFormat();
    CODEPORTING_DEBUG_ASSERT1(2 == format1->get_ColumnCount());
    CODEPORTING_DEBUG_ASSERT1(std::numeric_limits<double>::quiet_NaN() == format1->get_ColumnSpacing());
}

format->set_ColumnSpacing(20);
pres->Save(outPptxFileName, SaveFormat::Pptx);

{
    auto test = System::MakeObject<Presentation>(outPptxFileName);
    auto format2 = System::ExplicitCast<AutoShape>(test->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0))->get_TextFrame()->get_TextFrameFormat();
    CODEPORTING_DEBUG_ASSERT1(2 == format2->get_ColumnCount());
    CODEPORTING_DEBUG_ASSERT1(20 == format2->get_ColumnSpacing());
}

format->set_ColumnCount(3);
format->set_ColumnSpacing(15);
pres->Save(outPptxFileName, SaveFormat::Pptx);

{
    auto test = System::MakeObject<Presentation>(outPptxFileName);
    auto format3 = System::ExplicitCast<AutoShape>(test->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0))->get_TextFrame()->get_TextFrameFormat();
    CODEPORTING_DEBUG_ASSERT1(3 == format3->get_ColumnCount());
    CODEPORTING_DEBUG_ASSERT1(15 == format3->get_ColumnSpacing());
}
```

## **تحديث النص**

تتيح لك Aspose.Slides تغيير أو تحديث النص الموجود في مربع النص أو جميع النصوص الموجودة في العرض التقديمي. 

يبين لك هذا الكود C++ عملية يتم فيها تحديث أو تغيير جميع النصوص في عرض تقديمي:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pres = System::MakeObject<Presentation>(u"text.pptx");
for (const auto& slide : System::IterateOver(pres->get_Slides()))
{
    for (const auto& shape : System::IterateOver(slide->get_Shapes()))
    {
        if (ObjectExt::Is<IAutoShape>(shape))
        {
            auto autoShape = System::AsCast<IAutoShape>(shape);
            for (const auto& paragraph : System::IterateOver(autoShape->get_TextFrame()->get_Paragraphs()))
            {
                for (const auto& portion : System::IterateOver(paragraph->get_Portions()))
                {
                    //تغيير النص
                    portion->set_Text(portion->get_Text().Replace(u"years", u"months"));
                    //تغيير التنسيق
                    portion->get_PortionFormat()->set_FontBold(NullableBool::True);
                }
            }
        }
    }
}

//حفظ العرض التقديمي المعدل
pres->Save(u"text-changed.pptx", SaveFormat::Pptx);
```

## **إضافة مربع نص مع رابط تشعبي** 

يمكنك إدراج رابط داخل مربع نص. عند النقر على مربع النص، يتم توجيه المستخدمين لفتح الرابط. 

لإضافة مربع نص يحتوي على رابط، اتبع الخطوات التالية:

1. إنشاء نسخة من الفئة `Presentation`. 
2. الحصول على مرجع للشفرة الأولى في العرض التقديمي الجديد. 
3. إضافة كائن `AutoShape` مع تعيين `ShapeType` إلى `Rectangle` في موضع محدد على الشريحة والحصول على مرجع لكائن AutoShape المضاف حديثًا.
4. إضافة `TextFrame` إلى كائن `AutoShape` الذي يحتوي على *Aspose TextBox* كنص افتراضي. 
5. إنشاء نسخة من الفئة `IHyperlinkManager`. 
6. تعيين كائن `IHyperlinkManager` إلى طريقة [set_HyperlinkClick](https://reference.aspose.com/slides/ar/cpp/class/aspose.slides.shape#a617f857c862b71ac2093ed7866677a5c) المرتبطة بالجزء المفضل لديك من `TextFrame`. 
7. أخيرًا، احفظ ملف PPTX عبر كائن `Presentation`. 

يعرض لك هذا الكود C++—تنفيذ للخطوات السابقة—كيفية إضافة مربع نص مع رابط تشعبي إلى شريحة:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IHyperlinkManager.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

// ينشئ كائن Presentation يمثل ملف PPTX
auto presentation = System::MakeObject<Presentation>();

// يحصل على الشريحة الأولى في العرض التقديمي
auto slide = presentation->get_Slides()->idx_get(0);

// يضيف كائن AutoShape مع تعيين النوع إلى Rectangle
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 150.0f, 150.0f, 50.0f);

// يحول الشكل إلى AutoShape
auto autoShape = System::ExplicitCast<IAutoShape>(shape);

// يصل إلى خاصية ITextFrame المرتبطة بـ AutoShape
autoShape->AddTextFrame(u"");

auto textFrame = autoShape->get_TextFrame();

// يضيف بعض النص إلى الإطار
textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->set_Text(u"Aspose.Slides");

// يضبط الرابط التشعبي لنص الجزء
auto linkManager = textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->get_PortionFormat()->get_HyperlinkManager();
linkManager->SetExternalHyperlinkClick(u"http://www.aspose.com");

// يحفظ عرض PPTX التقديمي
presentation->Save(u"hLinkPPTX_out.pptx", SaveFormat::Pptx);
```

## **الأسئلة المتكررة**

**ما الفرق بين مربع النص وعناصر النائب النصي عند العمل مع الشرائح الرئيسة؟**

يُورث الـ[placeholder](/slides/ar/cpp/manage-placeholder/) النمط/الموضع من الـ[master](https://reference.aspose.com/slides/ar/cpp/aspose.slides/masterslide/)، ويمكن تعديلّه على الـ[layouts](https://reference.aspose.com/slides/ar/cpp/aspose.slides/layoutslide/)، بينما مربع النص العادي هو كائن مستقل على شريحة معينة ولا يتغير عند تبديل التخطيطات.

**كيف يمكنني تنفيذ استبدال نصي جماعي عبر العرض التقديمي دون التأثير على النص داخل المخططات والجداول وSmartArt؟**

قصر تكرارك على الأشكال التلقائية التي تحتوي على إطارات نصية واستبعاد الكائنات المضمنة ([charts](https://reference.aspose.com/slides/ar/cpp/aspose.slides.charts/chart/), [tables](https://reference.aspose.com/slides/ar/cpp/aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/ar/cpp/aspose.slides.smartart/smartart/)) عن طريق تصفح مجموعاتهم بشكل منفصل أو تخطي تلك الأنواع من الكائنات.
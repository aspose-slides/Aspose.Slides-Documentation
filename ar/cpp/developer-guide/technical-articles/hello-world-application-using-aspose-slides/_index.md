---
title: تطبيق Hello World باستخدام Aspose.Slides
type: docs
weight: 80
url: /cpp/hello-world-application-using-aspose-slides/
---

## **خطوات إنشاء تطبيق Hello World**
في هذا التطبيق البسيط، سنقوم بإنشاء عرض تقديمي باستخدام برنامج PowerPoint يحتوي على نص **Hello World** في موضع محدد في الشريحة. يرجى اتباع الخطوات أدناه لإنشاء تطبيق **Hello World** باستخدام واجهة برمجة تطبيقات Aspose.Slides لـ C++:

- إنشاء مثيل من فئة Presentation
- الحصول على مرجع الشريحة الأولى في العرض التقديمي الذي تم إنشاؤه عند إنشاء Presentation.
- إضافة شكل تلقائي مع نوع الشكل Rectangle في موضع محدد من الشريحة.
- إضافة إطار نصي إلى الشكل التلقائي يحتوي على Hello World كنص افتراضي
- تغيير لون النص إلى الأسود لأنه أبيض بشكل افتراضي وغير مرئي على الشريحة ذات الخلفية البيضاء
- تغيير لون خط الشكل إلى الأبيض لإخفاء حدود الشكل
- إزالة تنسيق التعبئة الافتراضي للشكل
- أخيرًا، كتابة العرض التقديمي إلى تنسيق الملف المطلوب باستخدام كائن Presentation

يتم عرض تنفيذ الخطوات أعلاه أدناه في مثال.

``` cpp
#include <DOM/Presentation.h>
#include <DOM/SlideCollection.h>
#include <DOM/Slide.h>
#include <DOM/ShapeCollection.h>
#include <DOM/AutoShape.h>
#include <DOM/Paragraph.h>
#include <DOM/ParagraphCollection.h>
#include <DOM/TextFrame.h>
#include <DOM/PortionCollection.h>
#include <DOM/Portion.h>
#include <DOM/PortionFormat.h>
#include <DOM/ColorFormat.h>
#include <DOM/FillFormat.h>
#include <DOM/ShapeStyle.h>
#include <DOM/ShapeType.h>
#include <DOM/FillType.h>

#include <Export/SaveFormat.h>

#include <drawing/color.h>

using namespace Aspose;
using namespace Slides;
using namespace Export;

using namespace System;

int main(int argc, const char argv[])
{
    auto pres = System::MakeObject<Presentation>();

    // احصل على الشريحة الأولى
    auto slide = pres->get_Slides()->idx_get(0);

    // أضف شكلًا تلقائيًا من نوع Rectangle
    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 75.0f, 150.0f, 50.0f);

    // أضف إطار نصي إلى المستطيل
    shape->AddTextFrame(u"Hello World");

    // غير لون النص إلى الأسود (والذي هو أبيض بشكل افتراضي)
    auto portionFillFormat = shape->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->get_PortionFormat()->get_FillFormat();
    portionFillFormat->set_FillType(FillType::Solid);
    portionFillFormat->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());

    // غير لون خط المستطيل إلى الأبيض
    shape->get_ShapeStyle()->get_LineColor()->set_Color(System::Drawing::Color::get_White());

    // أزل أي تنسيق تعبئة في الشكل
    shape->get_FillFormat()->set_FillType(FillType::NoFill);

    // احفظ العرض التقديمي على القرص
    pres->Save(u"output.pptx", SaveFormat::Pptx);

    return 0;
}
```
---
title: الحصول على حدود الفقرة من العروض التقديمية في C++
linktitle: الفقرة
type: docs
weight: 60
url: /ar/cpp/paragraph/
keywords:
- حدود الفقرة
- حدود الجزء النصي
- إحداثيات الفقرة
- إحداثيات الجزء
- حجم الفقرة
- حجم الجزء النصي
- إطار النص
- PowerPoint
- عرض تقديمي
- C++
- Aspose.Slides
description: "تعلم كيفية استرداد حدود الفقرة والجزء النصي في Aspose.Slides for C++ لتحسين موضع النص في عروض PowerPoint التقديمية."
---

## **الحصول على إحداثيات الفقرة والجزء داخل TextFrame**
باستخدام Aspose.Slides for C++، يمكن للمطورين الآن الحصول على إحداثيات المستطيل للفقرة داخل مجموعة الفقرات في TextFrame. كما يتيح لك الحصول على إحداثيات الجزء داخل مجموعة الأجزاء للفقرة. في هذا الموضوع، سنوضح بمساعدة مثال كيفية الحصول على إحداثيات المستطيل للفقرة مع موضع الجزء داخل الفقرة.

## **الحصول على إحداثيات المستطيل لفقرة**
تم إضافة الطريقة **GetRect()** الجديدة. تسمح بالحصول على مستطيل حدود الفقرة.
``` cpp
// إنشاء كائن Presentation يمثل ملف عرض تقديمي
auto presentation = System::MakeObject<Presentation>(u"Shapes.pptx");
auto shape = System::ExplicitCast<IAutoShape>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
auto textFrame = shape->get_TextFrame();
auto rect = textFrame->get_Paragraphs()->idx_get(0)->GetRect();
```


## **الحصول على حجم الفقرة والجزء داخل TextFrame لخلية جدول**
للحصول على حجم و إحداثيات [الجزء](https://reference.aspose.com/slides/cpp/class/aspose.slides.portion) أو [الفقرة](https://reference.aspose.com/slides/cpp/class/aspose.slides.paragraph) في TextFrame لخلية جدول، يمكنك استعمال الطرق [IPortion::GetRect](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_portion#a9e2fd8b58529d493b40835b8463838a9) و[IParagraph::GetRect](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_paragraph#a56f6e0026bbb81aa948bb0b000b8cf08t).

هذا المثال البرمجي يوضح العملية الموصوفة:
``` cpp
auto pres = System::MakeObject<Presentation>(u"source.pptx");
auto tbl = System::AsCast<Table>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));

auto cell = tbl->get_Rows()->idx_get(1)->idx_get(1);

double x = tbl->get_X() + tbl->get_Rows()->idx_get(1)->idx_get(1)->get_OffsetX();
double y = tbl->get_Y() + tbl->get_Rows()->idx_get(1)->idx_get(1)->get_OffsetY();

for (const auto& para : cell->get_TextFrame()->get_Paragraphs())
{
    if (para->get_Text() == u"")
    {
        continue;
    }

    auto rect = para->GetRect();
    auto shape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, rect.get_X() + x, rect.get_Y() + y, rect.get_Width(), rect.get_Height());

    shape->get_FillFormat()->set_FillType(FillType::NoFill);
    shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Yellow());
    shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);

    for (const auto& portion : para->get_Portions())
    {
        if (portion->get_Text().Contains(u"0"))
        {
            rect = portion->GetRect();
            shape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, rect.get_X() + x, rect.get_Y() + y, rect.get_Width(), rect.get_Height());

            shape->get_FillFormat()->set_FillType(FillType::NoFill);
        }
    }
}
```


## **FAQ**

**بأي وحدات تُرجع الإحداثيات للفقرة وأجزاء النص؟**  
بالنقاط، حيث 1 بوصة = 72 نقطة. وهذا ينطبق على جميع الإحداثيات والأبعاد في الشريحة.

**هل يؤثر التفاف النص على حدود الفقرة؟**  
نعم. إذا تم تمكين [التفاف](https://reference.aspose.com/slides/cpp/aspose.slides/textframeformat/set_wraptext/) في [TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/textframe/)، فإن النص يُقسَّم ليتناسب مع عرض المنطقة، مما يغيّر الحدود الفعلية للفقرة.

**هل يمكن ربط إحداثيات الفقرة ببيكسلات في الصورة المصدَّرة بشكل موثوق؟**  
نعم. حوِّل النقاط إلى بيكسلات باستخدام المعادلة: البيكسلات = النقاط × (DPI / 72). النتيجة تعتمد على قيمة DPI المختارة للتصيير/التصدير.

**كيف أحصل على معلمات تنسيق الفقرة "الفعالة" مع مراعاة توريث النمط؟**  
استخدم [الهيكل الفعال لتنسيق الفقرة](/slides/ar/cpp/shape-effective-properties/); فهو يُرجع القيم النهائية المدمجة للهوامش، والتباعد، والتفاف النص، والاتجاه من اليمين إلى اليسار، والمزيد.
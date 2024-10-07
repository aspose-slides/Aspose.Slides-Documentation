---
title: فقرة
type: docs
weight: 60
url: /cpp/paragraph/
---

## **الحصول على إحداثيات الفقرة والجزء في TextFrame**
باستخدام Aspose.Slides لـ C++، يمكن للمطورين الآن الحصول على إحداثيات مستطيلة للفقرة داخل مجموعة الفقرات لـ TextFrame. كما أنه يسمح لك بالحصول على إحداثيات الجزء داخل مجموعة الأجزاء لفقرة. في هذا الموضوع، سنقوم بتقديم مثال يوضح كيفية الحصول على الإحداثيات المستطيلة للفقرة مع موقع الجزء داخل فقرة.

## **الحصول على الإحداثيات المستطيلة للفقرة**
تم إضافة الطريقة الجديدة **GetRect()**. تسمح بالحصول على حدود مستطيل الفقرة.

``` cpp
// إنشاء كائن Presentation يمثل ملف عرض تقديمي
auto presentation = System::MakeObject<Presentation>(u"Shapes.pptx");
auto shape = System::ExplicitCast<IAutoShape>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
auto textFrame = shape->get_TextFrame();
auto rect = textFrame->get_Paragraphs()->idx_get(0)->GetRect();
```

## **الحصول على حجم الفقرة والجزء داخل نص إطار الخلية في الجدول** ##

للحصول على [Portion](https://reference.aspose.com/slides/cpp/class/aspose.slides.portion) أو [Paragraph](https://reference.aspose.com/slides/cpp/class/aspose.slides.paragraph) وحجمها وإحداثياتها في إطار نص خلية جدول، يمكنك استخدام [IPortion::GetRect](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_portion#a9e2fd8b58529d493b40835b8463838a9) و [IParagraph::GetRect](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_paragraph#a56f6e0026bbb81aa948bb0b000b8cf08t) الطريقتين.

هذا الكود التجريبي يوضح العملية الموصوفة:

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
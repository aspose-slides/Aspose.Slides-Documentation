---
title: الحصول على حدود الفقرات من العروض التقديمية بلغة C++
linktitle: حدود الفقرة
type: docs
weight: 43
url: /ar/cpp/paragraph-bounds/
keywords:
- حدود الفقرة
- إحداثيات الفقرة
- حجم الفقرة
- إطار النص
- PowerPoint
- عرض تقديمي
- C++
- Aspose.Slides
description: "تعلم كيفية استرجاع حدود الفقرة في Aspose.Slides للغة C++ لتحسين موضع النص في عروض PowerPoint التقديمية."
---
## **نظرة عامة**

تشرح هذه المقالة كيفية الحصول على حدود الفقرات وحجمها وإحداثياتها في Aspose.Slides. تُظهر كيفية استرجاع مستطيل الفقرة من [ITextFrame](https://reference.aspose.com/slides/ar/cpp/aspose.slides/itextframe/) باستخدام [IParagraph::GetRect](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iparagraph/getrect/)، وكيفية الحصول على إحداثيات الفقرة داخل إطار نص خلية جدول، وتبرز تفاصيل مهمة مثل وحدات القياس، وتأثير تغليف النص على الحدود، وتحويل البكسل، وقيم تنسيق الفقرة الفعّالة.

## **الحصول على إحداثيات مستطيلة لفقرة**

استخدم [IParagraph::GetRect](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iparagraph/getrect/) للحصول على المستطيل المحيط بفقرة.

```cpp
auto presentation = System::MakeObject<Presentation>(u"Shapes.pptx");
auto slide = presentation->get_Slide(0);
auto shape = System::ExplicitCast<IAutoShape>(slide->get_Shape(0));
auto paragraph = shape->get_TextFrame()->get_Paragraph(0);
auto rectangle = paragraph->GetRect();

presentation->Dispose();
```

## **الحصول على حجم الفقرة داخل إطار نص خلية جدول**

للحصول على الحجم والإحداثيات لـ[IParagraph](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iparagraph/) داخل إطار نص خلية جدول، استخدم [IParagraph::GetRect](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iparagraph/getrect/). المستطيل المرتجع يكون نسبياً لإطار نص خلية الجدول، لذا أضف موقع الجدول وإزاحة الخلية عندما تحتاج إلى إحداثيات على مستوى الشريحة.

المثال التالي يحصل على حدود الفقرة داخل خلية جدول ويرسم مستطيلات على الشريحة لتصوّر تلك الحدود:

```cpp
auto presentation = System::MakeObject<Presentation>(u"source.pptx");
auto slide = presentation->get_Slide(0);
auto table = System::ExplicitCast<ITable>(slide->get_Shape(0));
auto cell = table->get_Row(1)->idx_get(1);

auto cellX = table->get_X() + cell->get_OffsetX();
auto cellY = table->get_Y() + cell->get_OffsetY();
auto paragraphs = cell->get_TextFrame()->get_Paragraphs();

for (const auto& paragraph : paragraphs)
{
    if (paragraph->get_Text().IsEmpty())
    {
        continue;
    }

    auto paragraphRectangle = paragraph->GetRect();
    auto paragraphRectangleX = paragraphRectangle.get_X() + cellX;
    auto paragraphRectangleY = paragraphRectangle.get_Y() + cellY;

    auto paragraphBoundsShape = slide->get_Shapes()->AddAutoShape(
        ShapeType::Rectangle,
        paragraphRectangleX,
        paragraphRectangleY,
        paragraphRectangle.get_Width(),
        paragraphRectangle.get_Height());

    paragraphBoundsShape->get_FillFormat()->set_FillType(FillType::NoFill);
    paragraphBoundsShape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Yellow());
    paragraphBoundsShape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **الأسئلة الشائعة**

**بأي وحدات تُقاس إحداثيات الفقرة؟**

يتم قياسها بالنقاط، حيث إن البوصة الواحدة تساوي 72 نقطة. ينطبق هذا على جميع الإحداثيات والأبعاد على الشريحة.

**هل يؤثر تغليف الكلمات على حدود الفقرة؟**

نعم. إذا تم تمكين [ITextFrameFormat::set_WrapText](https://reference.aspose.com/slides/ar/cpp/aspose.slides/itextframeformat/set_wraptext/) لإطار النص [ITextFrame](https://reference.aspose.com/slides/ar/cpp/aspose.slides/itextframe/)، فإن النص يُقسّم ليتناسب مع عرض المنطقة، مما يغيّر الحدود الفعلية للفقرة.

**هل يمكن ربط إحداثيات الفقرة بشكل موثوق بالبكسل في الصورة المصدّرة؟**

نعم. يمكن تحويل النقاط إلى بكسل باستخدام الصيغة التالية: البكسل = النقاط × (DPI / 72). تعتمد النتيجة على DPI المختار للتصوير أو التصدير.

**كيف أحصل على معلمات تنسيق الفقرة "الفعّالة" مع مراعاة وراثة النمط؟**

استخدم [effective paragraph formatting data structure](/slides/ar/cpp/shape-effective-properties/); تُعيد القيم النهائية المجمعة للمسافات البادئة، والمسافات، والتغليف، والكتابة من اليمين إلى اليسار، وغيرها.
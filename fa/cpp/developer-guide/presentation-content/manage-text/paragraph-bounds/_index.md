---
title: دریافت محدوده پاراگراف‌ها از ارائه‌ها در C++
linktitle: محدوده پاراگراف
type: docs
weight: 43
url: /fa/cpp/paragraph-bounds/
keywords:
- محدوده پاراگراف
- مختصات پاراگراف
- اندازه پاراگراف
- چارچوب متن
- PowerPoint
- ارائه
- C++
- Aspose.Slides
description: "یاد بگیرید چگونه محدوده‌های پاراگراف را در Aspose.Slides برای C++ بازیابی کنید تا موقعیت‌یابی متن را در ارائه‌های PowerPoint بهینه کنید."
---
## **بررسی کلی**

این مقاله توضیح می‌دهد که چگونه مرزها، اندازه و مختصات پاراگراف‌ها در Aspose.Slides را به دست آورید. نشان می‌دهد چگونه یک مستطیل پاراگراف را از یک [ITextFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/itextframe/) با استفاده از [IParagraph::GetRect](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iparagraph/getrect/) دریافت کنید، چگونه مختصات پاراگراف را داخل یک چارچوب متن سلول جدول به دست آورید، و جزئیات مهمی مانند واحدهای اندازه‌گیری، اثر می‌پیچاندن متن بر مرزها، تبدیل به پیکسل و مقادیر قالب‌بندی مؤثر پاراگراف را برجسته می‌کند.

## **دریافت مختصات مستطیلی یک پاراگراف**

از [IParagraph::GetRect](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iparagraph/getrect/) برای دریافت مستطیل محاطی یک پاراگراف استفاده کنید.

```cpp
auto presentation = System::MakeObject<Presentation>(u"Shapes.pptx");
auto slide = presentation->get_Slide(0);
auto shape = System::ExplicitCast<IAutoShape>(slide->get_Shape(0));
auto paragraph = shape->get_TextFrame()->get_Paragraph(0);
auto rectangle = paragraph->GetRect();

presentation->Dispose();
```

## **دریافت اندازه یک پاراگراف داخل چارچوب متن سلول جدول**

برای به دست آوردن اندازه و مختصات یک [IParagraph](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iparagraph/) در چارچوب متن سلول جدول، از [IParagraph::GetRect](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iparagraph/getrect/) استفاده کنید. مستطیل بازگشتی نسبت به چارچوب متن سلول جدول است، بنابراین برای دریافت مختصات سطح اسلاید موقعیت جدول و جابجایی سلول را به آن اضافه کنید.

مثال زیر محدوده‌های پاراگراف داخل یک سلول جدول را دریافت کرده و مستطیل‌هایی را روی اسلاید رسم می‌کند تا این محدوده‌ها را به تصویر بکشد:

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

## **پرسش‌های متداول**

**مختصات پاراگراف‌ها به چه واحدهایی اندازه‌گیری می‌شوند؟**

آنها بر حسب پوینت اندازه‌گیری می‌شوند، به‌طوری که 1 اینچ برابر 72 پوینت است. این برای تمام مختصات و ابعاد روی اسلاید اعمال می‌شود.

**آیا بسته شدن متن (Word Wrap) بر مرزهای پاراگراف تأثیر می‌گذارد؟**

بله. اگر [ITextFrameFormat::set_WrapText](https://reference.aspose.com/slides/fa/cpp/aspose.slides/itextframeformat/set_wraptext/) برای [ITextFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/itextframe/) فعال باشد، متن برای تطبیق با عرض ناحیه شکسته می‌شود که مرزهای واقعی پاراگراف را تغییر می‌دهد.

**آیا می‌توان مختصات پاراگراف را به‌صورت قابل اعتماد به پیکسل‌ها در تصویر خروجی تبدیل کرد؟**

بله. پوینت‌ها را به پیکسل‌ها با استفاده از این فرمول تبدیل کنید: پیکسل‌ها = پوینت‌ها × (DPI / 72). نتیجه بستگی به DPI انتخاب‌شده برای رندر یا خروجی دارد.

**چگونه پارامترهای قالب‌بندی «مؤثر» پاراگراف را دریافت کنم که وراثت سبک را در نظر می‌گیرد؟**

از [effective paragraph formatting data structure](/slides/fa/cpp/shape-effective-properties/) استفاده کنید؛ این ساختار مقادیر نهایی یکپارچه برای تورفتگی‌ها، فاصله‌ها، پیچاندن، راست به چپ و موارد دیگر را برمی‌گرداند.
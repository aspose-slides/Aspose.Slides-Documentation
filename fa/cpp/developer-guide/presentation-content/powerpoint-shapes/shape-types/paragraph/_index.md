---
title: دریافت حدود پاراگراف از ارائه‌ها در C++
linktitle: پاراگراف
type: docs
weight: 60
url: /fa/cpp/paragraph/
keywords:
- حدود پاراگراف
- حدود بخش متن
- مختصات پاراگراف
- مختصات بخش
- اندازه پاراگراف
- اندازه بخش متن
- فریم متن
- PowerPoint
- ارائه
- C++
- Aspose.Slides
description: "بیاموزید چگونه حدود پاراگراف و بخش متنی را در Aspose.Slides برای C++ دریافت کنید تا موقعیت‌بندی متن در ارائه‌های PowerPoint بهینه شود."
---
## **بررسی کلی**

این مقاله توضیح می‌دهد که چگونه مرزها، اندازه و مختصات پاراگراف‌ها و بخش‌های متنی را در Aspose.Slides به دست آورید. نشان می‌دهد که چگونه با استفاده از `GetRect()` مستطیل یک پاراگراف را در یک `TextFrame` بازیابی کنید، چگونه مختصات پاراگراف و بخش را درون فریم متنی یک سلول جدول دریافت کنید، و جزئیات مهمی مانند واحدهای اندازه‌گیری، تأثیر شکست متن بر مرزها، تبدیل به پیکسل و مقادیر فرمت‌بندی «موثر» پاراگراف را برجسته می‌کند.

## **دریافت مختصات پاراگراف و بخش در یک TextFrame**
با استفاده از Aspose.Slides برای C++، توسعه‌دهندگان اکنون می‌توانند مختصات مستطیلی پاراگراف را در مجموعهٔ پاراگراف‌های یک TextFrame به دست آورند. همچنین امکان دریافت مختصات بخش داخل مجموعهٔ بخش‌های یک پاراگراف فراهم شده است. در این بخش، با کمک یک مثال نشان می‌دهیم چگونه مختصات مستطیلی پاراگراف و موقعیت بخش درون یک پاراگراف را دریافت کنیم.

## **دریافت مختصات مستطیلی یک پاراگراف**
روش جدید **GetRect()** افزوده شده است. این روش امکان دریافت مستطیل مرزهای پاراگراف را فراهم می‌کند.

``` cpp
// یک شی Presentation ایجاد می‌کند که نمایانگر یک فایل ارائه است
auto presentation = System::MakeObject<Presentation>(u"Shapes.pptx");
auto shape = System::ExplicitCast<IAutoShape>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
auto textFrame = shape->get_TextFrame();
auto rect = textFrame->get_Paragraphs()->idx_get(0)->GetRect();
```

## **دریافت اندازه یک پاراگراف و بخش درون فریم متنی سلول جدول**

برای به دست آوردن اندازه و مختصات [بخش](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.portion) یا [پاراگراف](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.paragraph) در فریم متنی سلول جدول، می‌توانید از متدهای [IPortion::GetRect](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.i_portion#a9e2fd8b58529d493b40835b8463838a9) و [IParagraph::GetRect](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.i_paragraph#a56f6e0026bbb81aa948bb0b000b8cf08t) استفاده کنید.

این کد نمونه عملیات توصیف‌شده را نشان می‌دهد:

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

**واحدهای اندازه‌گیری مختصات برگشت‌خورده برای پاراگراف و بخش‌های متنی چیست؟**

در پوینت، جایی که 1 اینچ = 72 پوینت. این برای تمام مختصات و ابعاد روی اسلاید صدق می‌کند.

**آیا شکست متن بر مرزهای پاراگراف تأثیر می‌گذارد؟**

بله. اگر [wrapping](https://reference.aspose.com/slides/fa/cpp/aspose.slides/textframeformat/set_wraptext/) در [TextFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/textframe/) فعال باشد، متن برای متناسب شدن با عرض ناحیه شکسته می‌شود که مرزهای واقعی پاراگراف را تغییر می‌دهد.

**آیا می‌توان مختصات پاراگراف را به‌طور قابل اعتماد به پیکسل در تصویر صادر شده تبدیل کرد؟**

بله. تبدیل پوینت به پیکسل با استفاده از: pixels = points × (DPI / 72). نتیجه بسته به DPI انتخاب‌شده برای رندر/صادرات متغیر است.

**چگونه پارامترهای فرمت‌بندی «موثر» پاراگراف را با در نظر گرفتن وراثت سبک دریافت کنیم؟**

از [ساختار دادهٔ فرمت‌بندی مؤثر پاراگراف](/slides/fa/cpp/shape-effective-properties/) استفاده کنید؛ این ساختار مقادیر نهایی یک‌پارچه برای تورفتگی‌ها، فاصله‌ها، بسته‌بندی، جهت راست به چپ و موارد دیگر را برمی‌گرداند.
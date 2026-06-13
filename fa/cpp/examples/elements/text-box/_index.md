---
title: جعبه متن
type: docs
weight: 40
url: /fa/cpp/examples/elements/text-box/
keywords:
- مثال کد
- جعبه متن
- PowerPoint
- OpenDocument
- ارائه
- C++
- Aspose.Slides
description: "کار با جعبه‌های متن در Aspose.Slides برای C++: افزودن، قالب‌بندی، تراز کردن، پیچاندن، خودتنظیم و سبک‌دهی به متن با استفاده از C++ برای ارائه‌های PPT، PPTX و ODP."
---
در Aspose.Slides، **جعبه متن** توسط یک `AutoShape` نمایان می‌شود. تقریباً هر شکل می‌تواند متن داشته باشد، اما یک جعبه متن معمولی پر یا حاشیه‌ای ندارد و فقط متن را نمایش می‌دهد.

این راهنما توضیح می‌دهد که چگونه به‌صورت برنامه‌نویسی جعبه‌های متن را اضافه، دسترسی یافته و حذف کنید.

## **افزودن جعبه متن**

جعبه متن صرفاً یک `AutoShape` بدون پر یا حاشیه و با متنی قالب‌بندی‌شده است. در اینجا نحوه ایجاد یک جعبه متن را می‌بینید:

```cpp
static void AddTextBox()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // یک شکل مستطیل ایجاد می‌کند (به‌صورت پیش‌فرض پر شده با حاشیه و بدون متن).
    auto textBox = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 75, 150, 100);

    // حذف پر و حاشیه برای اینکه شبیه یک جعبه متن معمولی به‌نظر برسد.
    textBox->get_FillFormat()->set_FillType(FillType::NoFill);
    textBox->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);

    // تنظیم قالب‌بندی متن.
    auto paragraph = textBox->get_TextFrame()->get_Paragraph(0);
    auto textFormat = paragraph->get_ParagraphFormat()->get_DefaultPortionFormat();
    textFormat->get_FillFormat()->set_FillType(FillType::Solid);
    textFormat->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());

    // اختصاص محتوا متن واقعی.
    textBox->get_TextFrame()->set_Text(u"Some text...");

    presentation->Dispose();
}
```

> 💡 **نکته:** هر `AutoShape` که شامل `TextFrame` غیر خالی باشد می‌تواند به عنوان جعبه متن عمل کند.

## **دسترسی به جعبه‌های متن بر اساس محتوا**

برای یافتن تمام جعبه‌های متنی که شامل یک کلیدواژه خاص هستند (مثلاً "Slide")، از میان اشکال عبور کنید و متن آن‌ها را بررسی کنید:

```cpp
static void AccessTextBox()
{
    auto presentation = MakeObject<Presentation>(u"sample.pptx");
    auto slide = presentation->get_Slide(0);

    for (auto&& shape : slide->get_Shapes())
    {
        // فقط AutoShapes می‌توانند متن قابل ویرایش داشته باشند.
        if (ObjectExt::Is<IAutoShape>(shape))
        {
            auto autoShape = ExplicitCast<IAutoShape>(shape);
            auto text = autoShape->get_TextFrame()->get_Text();
            if (text.Contains(u"Slide"))
            {
                // کاری با جعبه متن مطابق انجام دهید.
            }
        }
    }

    presentation->Dispose();
}
```

## **حذف جعبه‌های متن بر اساس محتوا**

این مثال تمام جعبه‌های متنی را که در اولین اسلاید وجود دارند و شامل یک کلیدواژه خاص هستند پیدا کرده و حذف می‌کند:

```cpp
static void RemoveTextBox()
{
    auto presentation = MakeObject<Presentation>(u"sample.pptx");
    auto slide = presentation->get_Slide(0);

    auto shapesToRemove = MakeObject<List<SharedPtr<IShape>>>();
    for (auto&& shape : slide->get_Shapes())
    {
        if (ObjectExt::Is<IAutoShape>(shape))
        {
            auto autoShape = ExplicitCast<IAutoShape>(shape);
            if (autoShape->get_TextFrame()->get_Text().Contains(u"Slide"))
            {
                shapesToRemove->Add(shape);
            }
        }
    }

    for (auto&& shape : shapesToRemove)
    {
        slide->get_Shapes()->Remove(shape);
    }

    presentation->Dispose();
}
```

> 💡 **نکته:** همیشه قبل از تغییر مجموعه اشکال در حین تکرار، یک کپی از آن ایجاد کنید تا از خطاهای ناشی از تغییر مجموعه جلوگیری شود.
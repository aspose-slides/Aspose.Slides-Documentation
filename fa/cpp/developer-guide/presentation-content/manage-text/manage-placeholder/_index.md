---
title: مدیریت نگهدارنده‌های ارائه در C++
linktitle: مدیریت نگهدارنده‌ها
type: docs
weight: 10
url: /fa/cpp/manage-placeholder/
keywords:
- نگهدارنده
- نگهدارنده متن
- نگهدارنده تصویر
- نگهدارنده نمودار
- متن پرامپت
- PowerPoint
- OpenDocument
- ارائه
- C++
- Aspose.Slides
description: "به راحتی نگهدارنده‌ها را در Aspose.Slides برای C++ مدیریت کنید: متن را جایگزین کنید، پرامپت‌ها را سفارشی کنید و شفافیت تصویر را در PowerPoint و OpenDocument تنظیم کنید."
---
## **بررسی کلی**

Aspose.Slides به شما اجازه می‌دهد تا نگهدارنده‌های ارائه را به‌صورت برنامه‌نویسی مدیریت کنید. این مقاله توضیح می‌دهد که چگونه نگهدارنده‌ها را روی اسلایدها پیدا کنید و متن آن‌ها را تغییر دهید، متن پرامپت سفارشی برای طرح‌بندی‌های نگهدارنده تنظیم کنید و شفافیت تصویری که به‌عنوان پس‌زمینه نگهدارنده استفاده می‌شود را تنظیم کنید. همچنین شامل یک بخش کوتاه پرسش‌های متداول است که تفاوت بین نگهدارنده‌های پایه و اشکال محلی را شفاف می‌کند، توضیح می‌دهد که چگونه تغییرات نگهدارنده می‌توانند از طریق طرح‌بندی‌ها یا مسترها اعمال شوند و به مدیریت نگهدارنده‌های سرصفحه و پاصفحه اشاره می‌کند.

## **تغییر متن در یک نگهدارنده**

با استفاده از [Aspose.Slides for C++](/slides/fa/cpp/)، می‌توانید نگهدارنده‌ها را در اسلایدهای ارائه پیدا کنید و ویرایش کنید. Aspose.Slides به شما اجازه می‌دهد تا تغییرات متن در یک نگهدارنده اعمال کنید.

**پیش‌نیاز**: شما به یک ارائه نیاز دارید که شامل یک نگهدارنده باشد. می‌توانید چنین ارائه‌ای را در برنامهٔ استاندارد Microsoft PowerPoint ایجاد کنید.

این‌طور می‌توانید از Aspose.Slides برای جایگزینی متن در نگهدارندهٔ آن ارائه استفاده کنید:

1. نمونه‌ای از کلاس [`Presentation`](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.presentation/) ایجاد کنید و ارائه را به‌عنوان آرگومان پاس دهید.
2. از طریق ایندکس، به یک اسلاید ارجاع بگیرید.
3. از میان اشکال عبور کنید تا نگهدارنده را پیدا کنید.
4. شکل نگهدارنده را به یک [`AutoShape`](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.auto_shape/) تبدیل (typecast) کنید و متن را با استفاده از [`TextFrame`](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.text_frame/) مرتبط با [`AutoShape`](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.auto_shape/) تغییر دهید.
5. ارائهٔ تغییر یافته را ذخیره کنید.

این کد C++ نشان می‌دهد چگونه متن در یک نگهدارنده را تغییر دهید:

```c++
// مسیر پوشه اسناد.
const String outPath = u"../out/ReplacingText_out.pptx";
const String templatePath = u"../templates/DefaultFonts.pptx";


// ارائه مورد نظر را بارگیری می‌کند
SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

// به اسلاید اول دسترسی پیدا می‌کند
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// به اولین و دومین نگهدارنده در اسلاید دسترسی پیدا می‌کند و آن را به یک AutoShape تبدیل می‌کند
SharedPtr<IShape> shape = slide->get_Shapes()->idx_get(0);
SharedPtr<AutoShape> ashp = ExplicitCast<Aspose::Slides::AutoShape>(shape);

SharedPtr<ITextFrame> textframe = ashp->get_TextFrame();

textframe->set_Text(u"This is Placeholder");
	
// ارائه را روی دیسک ذخیره می‌کند
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **تنظیم متن پرامپت در یک نگهدارنده**

طرح‌بندی‌های استاندارد و پیش‌ساخته شامل متن‌های پرامپت نگهدارنده مانند ***Click to add a title*** یا ***Click to add a subtitle*** هستند. با استفاده از Aspose.Slides، می‌توانید متن پرامپت دلخواه خود را در طرح‌بندی‌های نگهدارنده وارد کنید.

این کد C++ نشان می‌دهد چگونه متن پرامپت را در یک نگهدارنده تنظیم کنید:

```c++
const System::String templatePath = u"../templates/Presentation2.pptx";
    
auto pres = System::MakeObject<Presentation>(templatePath);
auto slide = pres->get_Slides()->idx_get(0);

for (auto& shape : slide->get_Shapes())
{
    if (shape->get_Placeholder() != NULL)
    {
        System::String text = u"";
        if (shape->get_Placeholder()->get_Type() == PlaceholderType::CenteredTitle) // زمانی که متنی در آن وجود نداشته باشد، PowerPoint متن "Click to add title" را نمایش می‌دهد. 
        {
            text = u"Click to add title";
        }
        else if (shape->get_Placeholder()->get_Type() == PlaceholderType::Subtitle) // همین کار را برای زیرعنوان انجام می‌دهد.
        {
            text = u"Click to add subtitle";
        }
        System::Console::WriteLine(u"Placeholder : {0}", text);
    }
}

pres->Save(u"../out/Placeholders_PromptText.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **تنظیم شفافیت تصویر نگهدارنده**

Aspose.Slides به شما اجازه می‌دهد تا شفافیت تصویر پس‌زمینه در یک نگهدارندهٔ متن را تنظیم کنید. با تنظیم شفافیت تصویر در چنین قاب‌گذاری، می‌توانید متن یا تصویر را برجسته کنید (بسته به رنگ‌های متن و تصویر).

این کد C++ نشان می‌دهد چگونه شفافیت پس‌زمینهٔ تصویر (داخل یک شکل) را تنظیم کنید:

```c++
auto presentation = System::MakeObject<Presentation>();
    
auto autoShape = presentation->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(Aspose::Slides::ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f);
    
auto fillFormat = autoShape->get_FillFormat();
fillFormat->set_FillType(Aspose::Slides::FillType::Picture);
fillFormat->get_PictureFillFormat()->get_Picture()->set_Image(presentation->get_Images()->AddImage(System::IO::File::ReadAllBytes(u"image.png")));

auto pictureFillFormat = fillFormat->get_PictureFillFormat();
pictureFillFormat->set_PictureFillMode(Aspose::Slides::PictureFillMode::Stretch);
pictureFillFormat->get_Picture()->get_ImageTransform()->AddAlphaModulateFixedEffect(75.0f);
```

## **پرسش‌های متداول**

**نگهدارندهٔ پایه چیست و چگونه با یک شکل محلی در اسلاید متفاوت است؟**

نگهدارندهٔ پایه، شکل اصلی در یک طرح‌بندی یا مستر است که شکل اسلاید از آن به ارث می‌برد—نوع، موقعیت و برخی فرمت‌بندی‌ها از آن می‌آیند. یک شکل محلی مستقل است؛ اگر نگهدارندهٔ پایه‌ای وجود نداشته باشد، ارث‌بری اعمال نمی‌شود.

**چگونه می‌توانم تمام عناوین یا کپشن‌ها را در یک ارائه بدون عبور از هر اسلاید به‌روزرسانی کنم؟**

نگهدارندهٔ مربوطه را در طرح‌بندی یا مستر ویرایش کنید. اسلایدهایی که بر پایهٔ آن طرح‌بندی/مستر ساخته شده‌اند، به‌صورت خودکار تغییر را به ارث می‌برند.

**چگونه می‌توانم نگهدارنده‌های استاندارد سرصفحه/پاصفحه—تاریخ و زمان، شماره اسلاید و متن پاصفحه—را کنترل کنم؟**

از مدیران HeaderFooter در دامنهٔ مناسب (اسلایدهای عادی، طرح‌بندی‌ها، مستر، یادداشت‌ها/برگه‌های توزیع) استفاده کنید تا این نگهدارنده‌ها را روشن یا خاموش کنید و محتوای آن‌ها را تنظیم کنید.
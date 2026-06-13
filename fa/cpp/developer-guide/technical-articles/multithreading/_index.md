---
title: "کار چندنخی در Aspose.Slides برای C++"
linktitle: "کار چندنخی"
type: docs
weight: 200
url: /fa/cpp/multithreading/
keywords:
- چندنخی
- چندین رشته
- کار موازی
- تبدیل اسلایدها
- اسلایدها به تصاویر
- PowerPoint
- OpenDocument
- ارائه
- C++
- Aspose.Slides
description: "چندنخی Aspose.Slides برای C++ پردازش PowerPoint و OpenDocument را بهبود می‌بخشد. بهترین روش‌ها برای جریان کاری کارآمد ارائه را کشف کنید."
---
## **معرفی**

در حالی که کار موازی با ارائه‌ها ممکن است (به جز تجزیه/بارگذاری/کلونینگ) و اکثر اوقات همه چیز خوب پیش می‌رود، اما احتمال کمی وجود دارد که در صورت استفاده از کتابخانه در چندین رشته نتایج نادرستی دریافت کنید.

ما قویاً توصیه می‌کنیم که **نکنید** از یک نمونهٔ [Presentation](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.presentation) در محیط چند رشته‌ای استفاده **نکنید** زیرا ممکن است منجر به خطاها یا شکست‌های پیش‌بینی‌نشده‌ای شود که به راحتی قابل شناسایی نیستند.  

این **نه** امن است که یک نمونهٔ [Presentation](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.presentation) را در چندین رشته بارگذاری، ذخیره‌سازی و/یا کلون کنید. چنین عملیات‌ها **نه** پشتیبانی می‌شوند. اگر نیاز به انجام این کارها دارید، باید عملیات را به‌صورت موازی با استفاده از چندین فرآیند تک‌رشته‌ای انجام دهید و هر یک از این فرآیندها باید از نمونهٔ ارائه خود استفاده کنند.

## **تبدیل اسلایدهای ارائه به تصاویر به‌صورت موازی**

فرض کنید می‌خواهیم تمام اسلایدهای یک ارائهٔ PowerPoint را به‌صورت موازی به تصاویر PNG تبدیل کنیم. از آنجا که استفاده از یک نمونهٔ `Presentation` در چندین رشته ناامن است، اسلایدهای ارائه را به ارائه‌های جداگانه تقسیم می‌کنیم و اسلایدها را به‌صورت موازی به تصاویر تبدیل می‌کنیم، بطوریکه هر ارائه در یک رشتهٔ جدا استفاده می‌شود. مثال کد زیر نشان می‌دهد که چگونه این کار را انجام دهیم.

```cpp
auto inputFilePath = u"sample.pptx";
auto outputFilePathTemplate = u"slide_{0}.png";
auto imageScale = 2;

auto presentation = MakeObject<Presentation>(inputFilePath);

auto slideCount = presentation->get_Slides()->get_Count();
auto slideSize = presentation->get_SlideSize()->get_Size();

std::vector<std::future<void>> conversionTasks;

for (auto slideIndex = 0; slideIndex < slideCount; slideIndex++) {
    // استخراج اسلاید i به یک ارائهٔ جداگانه.
    auto slidePresentation = MakeObject<Presentation>();
    slidePresentation->get_SlideSize()->SetSize(slideSize.get_Width(), slideSize.get_Height(), SlideSizeScaleType::DoNotScale);
    slidePresentation->get_Slides()->RemoveAt(0);
    slidePresentation->get_Slides()->AddClone(presentation->get_Slide(slideIndex));

    // تبدیل اسلاید به تصویر در یک وظیفهٔ جداگانه.
    auto slideNumber = slideIndex + 1;
    conversionTasks.push_back(std::async(std::launch::async, [slidePresentation = std::move(slidePresentation), slideNumber, outputFilePathTemplate, imageScale]() {
        SharedPtr<IImage> image = nullptr;
        try {
            auto slide = slidePresentation->get_Slide(0);

            auto image = slide->GetImage(imageScale, imageScale);
            auto imageFilePath = String::Format(outputFilePathTemplate, slideNumber);
            image->Save(imageFilePath, ImageFormat::Png);
        }
        catch (Exception e) {
            if(image != nullptr) image->Dispose();
            slidePresentation->Dispose();
        }
    }));
}

// انتظار برای اتمام همهٔ وظایف.
for (auto& task : conversionTasks) {
    task.get();
}

presentation->Dispose();
```

## **سوالات متداول**

**آیا لازم است در هر رشته تنظیم مجوز را فراخوانی کنم؟**

خیر. کافی است یک بار برای هر فرآیند/دامنهٔ برنامه قبل از شروع رشته‌ها انجام شود. اگر [تنظیم مجوز](/slides/fa/cpp/licensing/) ممکن است به‌صورت همزمان فراخوانی شود (مثلاً در هنگام مقداردهی اولیه تنبل)، آن فراخوانی را همگام‌سازی کنید زیرا خود متد تنظیم مجوز **thread-safe** نیست.

**آیا می‌توانم شیءهای `Presentation` یا `Slide` را بین رشته‌ها عبور دهم؟**

عبور دادن اشیای «زنده» ارائه بین رشته‌ها توصیه نمی‌شود: برای هر رشته از نمونه‌های مستقل استفاده کنید یا پیشاپیش ارائه‌ها/محفظه‌های اسلاید جداگانه برای هر رشته ایجاد کنید. این رویکرد مطابق با توصیهٔ کلی عدم اشتراک یک نمونهٔ ارائه بین رشته‌ها است.

**آیا ایمن است که خروجی به فرمت‌های مختلف (PDF، HTML، تصاویر) را به‌صورت موازی انجام داد، به‌شرطی که هر رشته نمونهٔ `Presentation` خود را داشته باشد؟**

بله. با نمونه‌های مستقل و مسیرهای خروجی جدا، اینگونه کارها معمولاً به‌درستی موازی می‌شوند؛ از هر گونه اشیای مشترک ارائه و جریان‌های I/O مشترک اجتناب کنید.

**در محیط چندرشته‌ای باید با تنظیمات کلی فونت (پوشه‌ها، جایگزینی‌ها) چه کار کنم؟**

تمام تنظیمات کلی فونت را پیش از شروع رشته‌ها مقداردهی اولیه کنید و در طول کار موازی آنها را تغییر ندهید. این کار شرایط مسابقه‌ای دسترسی به منابع فونت مشترک را از بین می‌برد.
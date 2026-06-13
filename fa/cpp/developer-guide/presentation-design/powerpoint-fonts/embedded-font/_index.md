---
title: قراردادن فونت‌ها در ارائه‌ها با استفاده از C++
linktitle: توکارسازی فونت
type: docs
weight: 40
url: /fa/cpp/embedded-font/
keywords:
- افزودن فونت
- توکارسازی فونت
- توکارسازی فونت
- دریافت فونت توکار
- افزودن فونت توکار
- حذف فونت توکار
- فشرده‌سازی فونت توکار
- PowerPoint
- OpenDocument
- ارائه
- C++
- Aspose.Slides
description: "فونت‌های TrueType را در ارائه‌های PowerPoint و OpenDocument با Aspose.Slides برای C++ توکار کنید تا رندر دقیق در تمام پلتفرم‌ها تضمین شود."
---
## **معرفی**

**Embedded fonts in PowerPoint** به شما کمک می‌کند تا ظاهر مطلوب ارائه‌تان هنگام باز شدن در هر سیستم یا دستگاهی حفظ شود. این موضوع به‌ویژه هنگام استفاده از فونت‌های سفارشی، شخص ثالث یا غیر استاندارد برای برندینگ یا مقاصد خلاقانه اهمیت دارد. بدون فونت‌های توکار، ممکن است متن جایگزین شود، طرح‌بندی‌ها خراب شوند و حروف به‌صورت نمادهای غیرقابل خواندن یا مستطیل‌ها نمایش داده شوند و طراحی کلی زیر سؤال برود.

Aspose.Slides for C++ مجموعه‌ای قدرتمند از APIها را برای مدیریت برنامه‌نویسی فونت‌های توکار ارائه می‌دهد. می‌توانید از کلاس‌های [FontsManager](https://reference.aspose.com/slides/fa/cpp/aspose.slides/fontsmanager/) و [FontData](https://reference.aspose.com/slides/fa/cpp/aspose.slides/fontdata/) برای بررسی، افزودن یا حذف فونت‌های توکار در فایل‌های ارائه خود استفاده کنید. علاوه بر این، کلاس [Compress](https://reference.aspose.com/slides/fa/cpp/aspose.slides.lowcode/compress/) به شما امکان بهینه‌سازی اندازه فایل را با فشرده‌سازی داده‌های فونت بدون تأثیر بر کیفیت یا ظاهر می‌دهد.

این ابزارها کنترل کامل بر توکارسازی فونت‌ها را در اختیار شما می‌گذارند و به حفظ تایپوگرافی یک‌دست در سرتاسر پلتفرم‌ها کمک می‌کنند، در حالی که در صورت نیاز اندازه فایل را کاهش می‌دهند.

## **دریافت فونت‌های توکار از یک ارائه**

Aspose.Slides for C++ متد `GetEmbeddedFonts` را از طریق کلاس [FontsManager](https://reference.aspose.com/slides/fa/cpp/aspose.slides/fontsmanager/) فراهم می‌کند که به شما امکان دریافت فهرستی از فونت‌های توکار در یک ارائه PowerPoint را می‌دهد. این می‌تواند برای بررسی استفاده از فونت، اطمینان از تطابق با راهنمایی‌های برند یا تأیید اینکه تمام فونت‌های لازم به‌درستی گنجانده شده‌اند پیش از اشتراک‌گذاری فایل مفید باشد.

کد C++ زیر نحوه دریافت فونت‌های توکار از یک فایل ارائه را نشان می‌دهد:

```cpp
// یک شیء از کلاس Presentation که نمایانگر یک فایل ارائه است، ایجاد کنید.
auto presentation = MakeObject<Presentation>(u"embedded_fonts.pptx");

// دریافت همه فونت‌های توکار.
auto embeddedFonts = presentation->get_FontsManager()->GetEmbeddedFonts();

// نام فونت‌های توكار را چاپ کنید.
for (auto&& fontData : embeddedFonts)
{
    Console::WriteLine(fontData->get_FontName());
}

presentation->Dispose();
```

## **افزودن فونت‌های توکار به یک ارائه**

Aspose.Slides for C++ به شما امکان توکارسازی فونت‌ها در یک ارائه PowerPoint را با استفاده از متد [AddEmbeddedFont](https://reference.aspose.com/slides/fa/cpp/aspose.slides/fontsmanager/addembeddedfont/) می‌دهد که دو overload برای استفاده منعطف دارد. می‌توانید با استفاده از شمارش‌گر [EmbedFontCharacters](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/embedfontcharacters/) میزان توکارسازی فونت را کنترل کنید—به‌عنوان مثال، فقط حروف استفاده‌شده یا تمام مجموعه فونت را توکار کنید. این ویژگی هنگام آماده‌سازی ارائه برای اشتراک یا توزیع بسیار مفید است، زیرا اطمینان می‌دهد فونت‌های سفارشی یا غیراستاندارد بر روی تمام سیستم‌ها به‌درستی نمایش داده شوند حتی اگر بر روی آنها نصب نشده باشند.

کد C++ زیر تمام فونت‌های استفاده‌شده در یک ارائه را بررسی می‌کند و هر فونتی که هنوز توکار نشده باشد، اضافه می‌نماید:

```cpp
// فایل ارائه را بارگذاری کنید.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto usedFonts = presentation->get_FontsManager()->GetFonts();
auto embeddedFonts = presentation->get_FontsManager()->GetEmbeddedFonts();

for (auto&& fontData : usedFonts)
{
    std::function<bool(SharedPtr<IFontData> data)> comparer = [&fontData](SharedPtr<IFontData> data) -> bool
        {
            return data == fontData;
        };

    // بررسی کنید آیا فونت قبلاً توکار شده است.
    bool isEmbeddedFont = Array<SharedPtr<IFontData>>::Exists(embeddedFonts, comparer);
    if (!isEmbeddedFont)
    {
        // فونت را در ارائه توکار کنید.
        presentation->get_FontsManager()->AddEmbeddedFont(fontData, EmbedFontCharacters::All);
    }

}

// ارائه را روی دیسک ذخیره کنید.
presentation->Save(u"embedded_fonts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **حذف فونت‌های توکار از یک ارائه**

Aspose.Slides for C++ متد `RemoveEmbeddedFont` را از طریق کلاس [FontsManager](https://reference.aspose.com/slides/fa/cpp/aspose.slides/fontsmanager/) ارائه می‌دهد که به شما امکان حذف فونت‌های خاص توکار شده در یک ارائه PowerPoint را می‌دهد. این می‌تواند به کاهش اندازه کلی فایل کمک کند، به‌ویژه اگر فونت‌های توکار دیگر استفاده نشوند یا نیازی به آنها نباشد. حذف فونت‌های استفاده‌نشده می‌تواند عملکرد را بهبود بخشد و اطمینان دهد که ارائه شما فقط شامل منابع ضروری است.

کد C++ زیر نحوه حذف یک فونت توکار از یک ارائه را نشان می‌دهد:

```cpp
auto fontName = u"Calibri";

// یک شیء از کلاس Presentation که نمایانگر یک فایل ارائه است، ایجاد کنید.
auto presentation = MakeObject<Presentation>(u"embedded_fonts.pptx");

// دریافت تمام فونت‌های توکار.
auto embeddedFonts = presentation->get_FontsManager()->GetEmbeddedFonts();

for (auto&& fontData : embeddedFonts)
{
    if (fontData->get_FontName().Equals(fontName))
    {
        // حذف فونت توکار.
        presentation->get_FontsManager()->RemoveEmbeddedFont(fontData);

        break;
    }
}

presentation->Save(u"removed_font.ppt", SaveFormat::Ppt);
presentation->Dispose();
```

## **فشرده‌سازی فونت‌های توکار**

Aspose.Slides for C++ متد `CompressEmbeddedFonts` را از طریق کلاس [Compress](https://reference.aspose.com/slides/fa/cpp/aspose.slides.lowcode/compress/) فراهم می‌کند که به شما امکان کاهش اندازه کلی فایل ارائه با بهینه‌سازی داده‌های فونت توکار را می‌دهد. این برای مواقعی که ارائه شما شامل فونت‌های بزرگ یا متعدد است و می‌خواهید فایل را برای اشتراک‌گذاری، ذخیره‌سازی یا استفاده آنلاین سبک نگه دارید—بدون کاهش وفاداری بصری محتوا—بسیار مفید است.

کد C++ زیر نحوه فشرده‌سازی فونت‌های توکار در یک ارائه PowerPoint را نشان می‌دهد:

```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");

Compress::CompressEmbeddedFonts(presentation);

presentation->Save(u"compressed_fonts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **سوالات متداول**

**چگونه می‌توانم تشخیص دهم که یک فونت خاص در ارائه علیرغم توکارسازی، هنگام رندر جایگزین می‌شود؟**

اطلاعات [substitution information](/slides/fa/cpp/font-substitution/) را در مدیر فونت و [fallback/substitution rules](/slides/fa/cpp/fallback-font/) را بررسی کنید: اگر فونت در دسترس نباشد یا محدود شود، یک فونت پیش‌فرض استفاده خواهد شد.

**آیا توکارسازی فونت‌های «سیستمی» مانند Arial/Calibri ارزش دارد؟**

معمولاً نه—این فونت‌ها تقریباً همیشه موجود هستند. اما برای قابلیت حمل کامل در محیط‌های «نازک» (Docker، سرور لینکس بدون فونت‌های پیش‌نصب‌شده) توکارسازی فونت‌های سیستمی می‌تواند خطر جایگزینی‌های غیرمنتظره را از بین ببرد.
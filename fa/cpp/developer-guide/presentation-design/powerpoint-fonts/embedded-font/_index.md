---
title: "جاسازی فونت‌ها در ارائه‌ها با استفاده از C++"
linktitle: "جاسازی فونت"
type: docs
weight: 40
url: /fa/cpp/embedded-font/
keywords:
- "افزودن فونت"
- "جاسازی فونت"
- "جاسازی فونت‌ها"
- "دریافت فونت جاسازی‌شده"
- "افزودن فونت جاسازی‌شده"
- "حذف فونت جاسازی‌شده"
- "فشرده‌سازی فونت جاسازی‌شده"
- "PowerPoint"
- "OpenDocument"
- "ارائه"
- "C++"
- "Aspose.Slides"
description: "فونت‌های TrueType را در ارائه‌های PowerPoint و OpenDocument با Aspose.Slides برای C++ جاسازی کنید تا رندر دقیق در همه پلتفرم‌ها تضمین شود."
---
## **معرفی**

**فونت‌های جاسازی‌شده در PowerPoint** به شما کمک می‌کنند تا اطمینان حاصل کنید ارائه شما ظاهر مورد نظرتان را در هر سیستم یا دستگاهی حفظ می‌کند. این موضوع به‌ویژه زمانی مهم است که از فونت‌های سفارشی، ثالث یا غیراستاندارد برای برندینگ یا اهداف خلاقانه استفاده می‌کنید. بدون فونت‌های جاسازی‌شده، متن ممکن است جایگزین شود، چینش‌ها ممکن است خراب شوند و کاراکترها ممکن است به شکل نمادهای نامقابل‌خواندن یا مستطیل‌ها ظاهر شوند که باعث کاهش کیفیت کلی طراحی می‌شود.

Aspose.Slides for C++ مجموعه‌ای از APIهای قدرتمند برای مدیریت برنامه‌نویسی فونت‌های جاسازی‌شده ارائه می‌دهد. می‌توانید از کلاس‌های [FontsManager](https://reference.aspose.com/slides/fa/cpp/aspose.slides/fontsmanager/) و [FontData](https://reference.aspose.com/slides/fa/cpp/aspose.slides/fontdata/) برای بررسی، افزودن یا حذف فونت‌های جاسازی‌شده در فایل‌های ارائه خود استفاده کنید. علاوه بر این، کلاس [Compress](https://reference.aspose.com/slides/fa/cpp/aspose.slides.lowcode/compress/) به شما امکان بهینه‌سازی اندازه فایل را با فشرده‌سازی داده‌های فونت بدون تأثیر بر کیفیت یا ظاهر می‌دهد.

این ابزارها به شما کنترل کامل بر روی جاسازی فونت‌ها می‌دهند و به شما کمک می‌کنند تا تایپوگرافی سازگار را در تمام پلتفرم‌ها حفظ کنید در حالی‌که در صورت لزوم اندازه فایل را کاهش می‌دهند.

## **دریافت فونت‌های جاسازی‌شده از یک ارائه**

Aspose.Slides for C++ روش `GetEmbeddedFonts` را از طریق کلاس [FontsManager](https://reference.aspose.com/slides/fa/cpp/aspose.slides/fontsmanager/) ارائه می‌دهد که به شما امکان می‌دهد فهرستی از فونت‌های جاسازی‌شده در یک ارائه PowerPoint دریافت کنید. این می‌تواند برای حسابرسی استفاده از فونت، اطمینان از انطباق با راهنمایی‌های برندینگ، یا تأیید اینکه تمام فونت‌های ضروری به‌درستی قبل از به‌اشتراک‌گذاری فایل گنجانده شده‌اند، مفید باشد.

```cpp
// شیء Presentation را که نمایانگر یک فایل ارائه است، نمونه‌سازی می‌کند.
auto presentation = MakeObject<Presentation>(u"embedded_fonts.pptx");

// دریافت تمام فونت‌های جاسازی‌شده.
auto embeddedFonts = presentation->get_FontsManager()->GetEmbeddedFonts();

// چاپ نام‌های فونت‌های جاسازی‌شده.
for (auto&& fontData : embeddedFonts)
{
    Console::WriteLine(fontData->get_FontName());
}

presentation->Dispose();
```

## **افزودن فونت‌های جاسازی‌شده به یک ارائه**

Aspose.Slides for C++ به شما امکان می‌دهد با استفاده از روش [AddEmbeddedFont](https://reference.aspose.com/slides/fa/cpp/aspose.slides/fontsmanager/addembeddedfont/) فونت‌ها را به یک ارائه PowerPoint جاسازی کنید؛ این روش دو overload برای استفاده انعطاف‌پذیر دارد. می‌توانید میزان جاسازی فونت را با استفاده از نوع Enumerations [EmbedFontCharacters](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/embedfontcharacters/) کنترل کنید — به عنوان مثال، می‌توانید فقط کاراکترهای استفاده‌شده یا کل مجموعه فونت را جاسازی کنید. این ویژگی به‌ویژه هنگام آماده‌سازی یک ارائه برای به‌اشتراک‌گذاری یا توزیع مفید است، به طوری که اطمینان حاصل می‌شود فونت‌های سفارشی یا غیراستاندارد در تمام سیستم‌ها به‌درستی نمایش داده شوند، حتی اگر آن فونت‌ها نصب نشده باشند.

```cpp
// یک فایل ارائه را بارگذاری می‌کند.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto usedFonts = presentation->get_FontsManager()->GetFonts();
auto embeddedFonts = presentation->get_FontsManager()->GetEmbeddedFonts();

for (auto&& fontData : usedFonts)
{
    std::function<bool(SharedPtr<IFontData> data)> comparer = [&fontData](SharedPtr<IFontData> data) -> bool
        {
            return data == fontData;
        };

    // بررسی می‌کند آیا فونت قبلاً جاسازی شده است.
    bool isEmbeddedFont = Array<SharedPtr<IFontData>>::Exists(embeddedFonts, comparer);
    if (!isEmbeddedFont)
    {
        // فونت را به ارائه جاسازی می‌کند.
        presentation->get_FontsManager()->AddEmbeddedFont(fontData, EmbedFontCharacters::All);
    }

}

// ارائه را بر روی دیسک ذخیره می‌کند.
presentation->Save(u"embedded_fonts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **حذف فونت‌های جاسازی‌شده از یک ارائه**

Aspose.Slides for C++ روش `RemoveEmbeddedFont` را از طریق کلاس [FontsManager](https://reference.aspose.com/slides/fa/cpp/aspose.slides/fontsmanager/) فراهم می‌کند که به شما امکان حذف فونت‌های خاص جاسازی‌شده در یک ارائه PowerPoint را می‌دهد. این می‌تواند به کاهش اندازه کلی فایل کمک کند، به‌ویژه اگر فونت‌های جاسازی‌شده دیگر استفاده یا نیازی به آن‌ها نباشد. حذف فونت‌های استفاده‌نشده همچنین می‌تواند عملکرد را بهبود بخشد و اطمینان حاصل کند که ارائه شما فقط شامل منابع ضروری است.

```cpp
auto fontName = u"Calibri";

// نمونه‌سازی کلاس Presentation که نمایانگر یک فایل ارائه است.
auto presentation = MakeObject<Presentation>(u"embedded_fonts.pptx");

// دریافت تمام فونت‌های جاسازی‌شده.
auto embeddedFonts = presentation->get_FontsManager()->GetEmbeddedFonts();

for (auto&& fontData : embeddedFonts)
{
    if (fontData->get_FontName().Equals(fontName))
    {
        // حذف فونت جاسازی‌شده.
        presentation->get_FontsManager()->RemoveEmbeddedFont(fontData);

        break;
    }
}

presentation->Save(u"removed_font.ppt", SaveFormat::Ppt);
presentation->Dispose();
```

## **فشرده‌سازی فونت‌های جاسازی‌شده**

Aspose.Slides for C++ روش `CompressEmbeddedFonts` را از طریق کلاس [Compress](https://reference.aspose.com/slides/fa/cpp/aspose.slides.lowcode/compress/) ارائه می‌دهد که به شما امکان کاهش اندازه کلی فایل یک ارائه را با بهینه‌سازی داده‌های فونت جاسازی‌شده می‌دهد. این به‌ویژه زمانی مفید است که ارائه شما شامل فونت‌های بزرگ یا متعدد باشد و می‌خواهید فایل را برای به‌اشتراک‌گذاری، ذخیره‌سازی یا استفاده آنلاین سبک نگه دارید — بدون آنکه به صحت بصری محتوا آسیب بزنید.

```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");

Compress::CompressEmbeddedFonts(presentation);

presentation->Save(u"compressed_fonts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **سؤالات متداول**

**چگونه می‌توانم بفهمم یک فونت خاص در ارائه همچنان در حین رندر شدن جایگزین می‌شود حتی با وجود جاسازی آن؟**

اطلاعات جایگزینی را در مدیر فونت بررسی کنید و به [قوانین پیش‌فرض/جایگزینی](/slides/fa/cpp/fallback-font/) مراجعه نمایید: اگر فونت در دسترس نباشد یا محدود باشد، یک فونت پیش‌فرض استفاده خواهد شد.

**آیا ارزش دارد که فونت‌های «سیستمی» مانند Arial/Calibri را جاسازی کنیم؟**

معمولاً نه — این فونت‌ها تقریباً همیشه در دسترس هستند. اما برای قابلیت حمل کامل در محیط‌های «نازک» (Docker، یک سرور لینوکسی بدون فونت‌های پیش‌نصب‌شده)، جاسازی فونت‌های سیستمی می‌تواند خطر جایگزینی‌های ناخواسته را از بین ببرد.
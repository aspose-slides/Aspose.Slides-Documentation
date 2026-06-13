---
title: تبدیل PPT و PPTX به PDF در C++ [ویژگی‌های پیشرفته گنجانده شده]
linktitle: PowerPoint به PDF
type: docs
weight: 40
url: /fa/cpp/convert-powerpoint-to-pdf/
keywords:
- تبدیل PowerPoint
- تبدیل ارائه
- PowerPoint به PDF
- ارائه به PDF
- PPT به PDF
- تبدیل PPT به PDF
- PPTX به PDF
- تبدیل PPTX به PDF
- ذخیره PowerPoint به عنوان PDF
- ذخیره PPT به عنوان PDF
- ذخیره PPTX به عنوان PDF
- صادر کردن PPT به PDF
- صادر کردن PPTX به PDF
- PDF/A1a
- PDF/A1b
- PDF/UA
- C++
- Aspose.Slides
description: "تبدیل PowerPoint PPT/PPTX به PDFهای با کیفیت بالا و قابل جستجو در C++ با استفاده از Aspose.Slides، با مثال‌های کد سریع و گزینه‌های پیشرفته تبدیل."
---
## **نمای کلی**

تبدیل ارائه‌های PowerPoint (PPT، PPTX، ODP و غیره) به فرمت PDF در C++ مزایای متعددی دارد، از جمله سازگاری با دستگاه‌های مختلف و حفظ چیدمان و قالب‌بندی ارائه شما. این راهنما نشان می‌دهد چگونه ارائه‌ها را به اسناد PDF تبدیل کنید، از گزینه‌های مختلف برای کنترل کیفیت تصویر استفاده کنید، اسلایدهای پنهان را شامل کنید، فایل‌های PDF را با رمز عبور محافظت کنید، جایگزینی فونت‌ها را تشخیص دهید، اسلایدهای خاصی را برای تبدیل انتخاب کنید و استانداردهای انطباق را بر اسناد خروجی اعمال کنید.

## **تبدیل PowerPoint به PDF**

با استفاده از Aspose.Slides، می‌توانید ارائه‌ها را در فرمت‌های زیر به PDF تبدیل کنید:

* **PPT**
* **PPTX**
* **ODP**

برای تبدیل یک ارائه به PDF، نام فایل را به‌عنوان ورودی به کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) بدهید و سپس ارائه را با متد `Save` به PDF ذخیره کنید. کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) متدی به‌نام `Save` در اختیار می‌گذارد که معمولاً برای تبدیل ارائه به PDF استفاده می‌شود.

{{%  alert title="توجه"  color="warning"   %}} 

Aspose.Slides برای C++ اطلاعات API و شماره نسخه خود را در اسناد خروجی درج می‌کند. به‌عنوان مثال، هنگام تبدیل یک ارائه به PDF، فیلد Application با "*Aspose.Slides*" و فیلد PDF Producer با مقداری به فرم "*Aspose.Slides v XX.XX*" پر می‌شود. **توجه** داشته باشید که نمی‌توانید از Aspose.Slides بخواهید این اطلاعات را در اسناد خروجی تغییر یا حذف کند.

{{% /alert %}}

Aspose.Slides به شما امکان می‌دهد:

* کل ارائه‌ها را به PDF تبدیل کنید
* اسلایدهای خاصی از یک ارائه را به PDF تبدیل کنید

Aspose.Slides ارائه‌ها را به PDF صادر می‌کند و تضمین می‌کند که PDFهای حاصل به‌دقت با ارائه‌های اصلی مطابقت داشته باشند. عناصر و ویژگی‌ها در تبدیل به‌درستی رندر می‌شوند، از جمله:

* تصاویر
* جعبه‌های متن و شکل‌ها
* قالب‌بندی متن
* قالب‌بندی پاراگراف
* پیوندها
* سرصفحه و پاصفحه
* بولت‌ها
* جداول

## **تبدیل PowerPoint به PDF**

فرآیند استاندارد تبدیل PowerPoint به PDF از گزینه‌های پیش‌فرض استفاده می‌کند. در این حالت، Aspose.Slides سعی می‌کند ارائه ارائه‌شده را با تنظیمات بهینه و حداکثر کیفیت به PDF تبدیل کند.

این کد C++ نشان می‌دهد چگونه یک ارائه (PPT، PPTX، ODP و غیره) را به PDF تبدیل کنید:

```c++
// این شیء از کلاس Presentation را که نمایانگر یک فایل PowerPoint یا OpenDocument است، ایجاد می‌کند.
auto presentation = MakeObject<Presentation>(u"PowerPoint.ppt");

// ارائه را به‌عنوان PDF ذخیره می‌کند.
presentation->Save(u"PPT-to-PDF.pdf", SaveFormat::Pdf);

presentation->Dispose();
```

{{%  alert  color="primary"  %}} 

Aspose یک [**مبدل PowerPoint به PDF**](https://products.aspose.app/slides/fa/conversion/ppt-to-pdf) رایگان آنلاین ارائه می‌دهد که فرآیند تبدیل ارائه به PDF را نمایش می‌دهد. می‌توانید با این مبدل یک آزمایش زنده از روند توصیف‌شده در اینجا انجام دهید.

{{% /alert %}}

## **تبدیل PowerPoint به PDF با گزینه‌ها**

Aspose.Slides گزینه‌های سفارشی—خصوصیات تحت کلاس [PdfOptions](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/pdfoptions/)—را فراهم می‌کند که به شما اجازه می‌دهد PDF حاصل را سفارشی کنید، PDF را با رمز عبور قفل کنید یا نحوه پیشرفت فرآیند تبدیل را تعیین کنید.

### **تبدیل PowerPoint به PDF با گزینه‌های سفارشی**

با استفاده از گزینه‌های تبدیل سفارشی، می‌توانید تنظیم کیفیت دلخواه برای تصاویر رستر، نحوه پردازش متافایل‌ها، سطح فشرده‌سازی متن، DPI برای تصاویر و موارد دیگر را تعریف کنید.

مثال کد زیر نشان می‌دهد چگونه یک ارائه PowerPoint را به PDF با چندین گزینه سفارشی تبدیل کنید.

```c++
// یک شیء از کلاس PdfOptions ایجاد می‌کند.
auto pdfOptions = MakeObject<PdfOptions>();

// کیفیت تصاویر JPG را تنظیم می‌کند.
pdfOptions->set_JpegQuality(90);

// DPI تصاویر را تنظیم می‌کند.
pdfOptions->set_SufficientResolution(300);

// رفتار متافایل‌ها را تنظیم می‌کند.
pdfOptions->set_SaveMetafilesAsPng(true);

// سطح فشرده‌سازی متن برای محتوای متنی را تنظیم می‌کند.
pdfOptions->set_TextCompression(PdfTextCompression::Flate);

// حالت انطباق PDF را تعریف می‌کند.
pdfOptions->set_Compliance(PdfCompliance::Pdf15);

// یک شیء از کلاس Presentation که نمایانگر یک فایل PowerPoint یا OpenDocument است، ایجاد می‌کند.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// ارائه را به‌عنوان یک سند PDF ذخیره می‌کند.
presentation->Save(u"PowerPoint-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

### **تبدیل PowerPoint به PDF با اسلایدهای مخفی**

اگر ارائه شامل اسلایدهای مخفی باشد، می‌توانید از متد [set_ShowHiddenSlides](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/pdfoptions/set_showhiddenslides/) از کلاس [PdfOptions](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/pdfoptions/) استفاده کنید تا اسلایدهای مخفی را به‌عنوان صفحات در PDF نتیجه گنجانید.

این کد C++ نشان می‌دهد چگونه یک ارائه PowerPoint را به PDF با اسلایدهای مخفی گنجانده‌شده تبدیل کنید:

```c++
// یک شیء از کلاس Presentation که نمایانگر یک فایل PowerPoint یا OpenDocument است، ایجاد می‌کند.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// یک شیء از کلاس PdfOptions ایجاد می‌کند.
auto pdfOptions = MakeObject<PdfOptions>();

// اسلایدهای مخفی را اضافه می‌کند.
pdfOptions->set_ShowHiddenSlides(true);

// ارائه را به‌عنوان PDF ذخیره می‌کند.
presentation->Save(u"PowerPoint-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

### **تبدیل PowerPoint به PDF با حفاظت با رمز عبور**

این کد C++ نشان می‌دهد چگونه یک ارائه PowerPoint را به PDF محافظت‌شده با رمز عبور تبدیل کنید با استفاده از پارامترهای حفاظتی کلاس [PdfOptions](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/pdfoptions/):

```c++
// یک شیء از کلاس Presentation که نمایانگر یک فایل PowerPoint یا OpenDocument است، ایجاد می‌کند.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// یک شیء از کلاس PdfOptions ایجاد می‌کند.
auto pdfOptions = MakeObject<PdfOptions>();

// یک گذرواژه PDF و مجوزهای دسترسی تنظیم می‌کند.
pdfOptions->set_Password(u"password");
pdfOptions->set_AccessPermissions(PdfAccessPermissions::PrintDocument | PdfAccessPermissions::HighQualityPrint);

// ارائه را به‌عنوان PDF ذخیره می‌کند.
presentation->Save(u"PPTX-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

### **تشخیص جایگزینی فونت‌ها**

Aspose.Slides متد [set_WarningCallback](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/saveoptions/set_warningcallback/) را تحت کلاس [PdfOptions](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/pdfoptions/) فراهم می‌کند تا بتوانید هنگام تبدیل ارائه به PDF، جایگزینی فونت‌ها را تشخیص دهید.

این کد C++ نشان می‌دهد چگونه جایگزینی فونت‌ها را تشخیص دهید:

```c++
// پیاده‌سازی callback هشدار.
class FontSubstitutionHandler : public IWarningCallback
{
public:
    ReturnAction Warning(SharedPtr<IWarningInfo> warning) override;
};

ReturnAction FontSubstitutionHandler::Warning(SharedPtr<IWarningInfo> warning)
{
    if (warning->get_WarningType() == WarningType::DataLoss && 
        warning->get_Description().StartsWith(u"Font will be substituted"))
    {
        Console::WriteLine(u"Font substitution warning: {0}", warning->get_Description());
    }

    return ReturnAction::Continue;
}

int main()
{
    // یک شیء از کلاس Presentation که نمایانگر یک فایل PowerPoint یا OpenDocument است، ایجاد می‌کند.
    auto presentation = MakeObject<Presentation>(u"sample.pptx");

    // تنظیم callback هشدار در گزینه‌های PDF.
    auto pdfOptions = MakeObject<PdfOptions>();
    pdfOptions->set_WarningCallback(MakeObject<FontSubstitutionHandler>());

    // ارائه را به‌عنوان PDF ذخیره می‌کند.
    presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);
    
    presentation->Dispose();

    return 0;
}
```

{{%  alert color="primary"  %}} 

برای اطلاعات بیشتر درباره دریافت callback برای جایگزینی فونت‌ها در طول فرآیند رندر، به مقاله [دریافت Callback هشدار برای جایگزینی فونت‌ها](/slides/fa/cpp/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/) مراجعه کنید.

برای اطلاعات بیشتر درباره جایگزینی فونت، مقاله [جایگزینی فونت](/slides/fa/cpp/font-substitution/) را ببینید.

{{% /alert %}} 

## **تبدیل اسلایدهای انتخابی از PowerPoint به PDF**

این کد C++ نشان می‌دهد چگونه تنها اسلایدهای خاصی از یک ارائه PowerPoint را به PDF تبدیل کنید:

```C++
// یک شیء از کلاس Presentation که نمایانگر یک فایل PowerPoint یا OpenDocument است، ایجاد می‌کند.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// آرایه‌ای از شماره اسلایدها تنظیم می‌کند.
auto slides = MakeArray<int32_t>({ 1, 3 });

// ارائه را به‌عنوان PDF ذخیره می‌کند.
presentation->Save(u"PPTX-to-PDF.pdf", slides, SaveFormat::Pdf);

presentation->Dispose();
```

## **تبدیل PowerPoint به PDF با اندازه اسلاید سفارشی**

این کد C++ نشان می‌دهد چگونه یک ارائه PowerPoint را به PDF با اندازه اسلاید مشخص تبدیل کنید:

```C++
auto slideWidth = 612;
auto slideHeight = 792;

// Instantiate the Presentation class that represents a PowerPoint or OpenDocument file.
auto presentation = MakeObject<Presentation>(u"SelectedSlides.pptx");

// Create a new presentation with an adjusted slide size.
auto resizedPresentation = MakeObject<Presentation>();

// Set the custom slide size.
resizedPresentation->get_SlideSize()->SetSize(slideWidth, slideHeight, SlideSizeScaleType::EnsureFit);

// Clone the first slide from the original presentation.
auto slide = presentation->get_Slide(0);
resizedPresentation->get_Slides()->InsertClone(0, slide);

// Save the resized presentation to a PDF with notes.
resizedPresentation->Save(u"PDF_with_notes.pdf", SaveFormat::Pdf);

resizedPresentation->Dispose();
presentation->Dispose();
```

## **تبدیل PowerPoint به PDF در نمای اسلاید یادداشت‌ها**

این کد C++ نشان می‌دهد چگونه یک ارائه PowerPoint را به PDF که شامل یادداشت‌ها است، تبدیل کنید:

```C++
// یک شیء از کلاس Presentation که نمایانگر یک فایل PowerPoint یا OpenDocument است، ایجاد می‌کند.
auto presentation = MakeObject<Presentation>(u"SelectedSlides.pptx");

// گزینه‌های PDF را با چیدمان یادداشت‌ها تنظیم می‌کند.
auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull);
auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(notesOptions);

// ارائه را به یک PDF با یادداشت‌ها ذخیره می‌کند.
presentation->Save(u"PDF_with_notes.tiff", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

## **استانداردهای دسترس‌پذیری و انطباق برای PDF**

Aspose.Slides به شما امکان می‌دهد از روش تبدیل پیروی کنید که با [راهنمای دسترس‌پذیری محتوای وب (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) مطابقت داشته باشد. می‌توانید یک سند PowerPoint را به PDF صادر کنید با هر یک از این استانداردهای انطباق: **PDF/A1a**، **PDF/A1b** و **PDF/UA**.

این کد C++ یک فرآیند تبدیل PowerPoint به PDF را نشان می‌دهد که بر اساس استانداردهای انطباق مختلف، چندین PDF تولید می‌کند:

```C++
auto presentation = MakeObject<Presentation>(u"pres.pptx");

auto pdfOptionsA1a = MakeObject<PdfOptions>();

pdfOptionsA1a->set_Compliance(PdfCompliance::PdfA1a);
presentation->Save(u"pres-a1a-compliance.pdf", SaveFormat::Pdf, pdfOptionsA1a);

auto pdfOptionsA1b = MakeObject<PdfOptions>();
pdfOptionsA1b->set_Compliance(PdfCompliance::PdfA1b);
presentation->Save(u"pres-a1b-compliance.pdf", SaveFormat::Pdf, pdfOptionsA1b);

auto pdfOptionsUa = MakeObject<PdfOptions>();
pdfOptionsUa->set_Compliance(PdfCompliance::PdfUa);

presentation->Save(u"pres-ua-compliance.pdf", SaveFormat::Pdf, pdfOptionsUa);

presentation->Dispose();
```

{{% alert title="یادداشت" color="warning" %}} 

Aspose.Slides عملیات‌های تبدیل PDF را پشتیبانی می‌کند و به شما اجازه می‌دهد فایل‌های PDF را به فرمت‌های محبوب دیگر تبدیل کنید. می‌توانید تبدیل‌های [PDF به HTML](https://products.aspose.com/slides/fa/cpp/conversion/pdf-to-html/)، [PDF به تصویر](https://products.aspose.com/slides/fa/cpp/conversion/pdf-to-image/)، [PDF به JPG](https://products.aspose.com/slides/fa/cpp/conversion/pdf-to-jpg/)، و [PDF به PNG](https://products.aspose.com/slides/fa/cpp/conversion/pdf-to-png/) را انجام دهید. سایر عملیات‌های تبدیل PDF به فرمت‌های تخصصی—[PDF به SVG](https://products.aspose.com/slides/fa/cpp/conversion/pdf-to-svg/)، [PDF به TIFF](https://products.aspose.com/slides/fa/cpp/conversion/pdf-to-tiff/)، و [PDF به XML](https://products.aspose.com/slides/fa/cpp/conversion/pdf-to-xml/)—نیز پشتیبانی می‌شوند.

{{% /alert %}}

> **تذکر:** هنگام خروجی به PDF/UA، Aspose.Slides گرافیک‌های پیچیده مانند SmartArt، نمودارها و فرمول‌ها را به‌عنوان یک شکل واحد درنظر می‌گیرد. عناصر مسیر جداگانه به‌عنوان محتوا حفظ نمی‌شوند و ممکن است به‌عنوان عیوب علامت‌گذاری شوند؛ متن جایگزین فقط برای کل شکل ارائه می‌شود.

## **پرسش‌های متداول**

**آیا می‌توانم چندین فایل PowerPoint را به صورت دسته‌ای به PDF تبدیل کنم؟**

بله، Aspose.Slides از تبدیل دسته‌ای چندین فایل PPT یا PPTX به PDF پشتیبانی می‌کند. می‌توانید به‌صورت برنامه‌نویسی بر روی فایل‌های خود تکرار کنید و فرآیند تبدیل را اعمال کنید.

**آیا می‌توانم PDF تبدیل‌شده را با رمز عبور محافظت کنم؟**

به‌طور قطع. از کلاس [PdfOptions](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/pdfoptions/) برای تنظیم رمز عبور و تعریف مجوزهای دسترسی در طول فرآیند تبدیل استفاده کنید.

**چگونه اسلایدهای مخفی را در PDF گنجانده کنم؟**

از متد `set_ShowHiddenSlides` در کلاس [PdfOptions](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/pdfoptions/) برای گنجاندن اسلایدهای مخفی در PDF حاصل استفاده کنید.

**آیا Aspose.Slides می‌تواند کیفیت بالای تصویر را در PDF حفظ کند؟**

بله، می‌توانید با استفاده از متدهایی مانند `set_JpegQuality` و `set_SufficientResolution` در کلاس [PdfOptions](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/pdfoptions/) کیفیت تصویر را در PDF تضمین کنید.

**آیا Aspose.Slides استانداردهای انطباق PDF/A را پشتیبانی می‌کند؟**

بله، Aspose.Slides به شما امکان می‌دهد PDFهایی صادر کنید که با استانداردهای مختلف از جمله PDF/A1a، PDF/A1b و PDF/UA مطابقت داشته باشند و نیازهای دسترس‌پذیری و بایگانی اسناد شما را برآورده سازند.

## **منابع اضافی**

- [مستندات Aspose.Slides برای C++](/slides/fa/cpp/)
- [مرجع API Aspose.Slides برای C++](https://reference.aspose.com/slides/fa/cpp/)
- [مبدل‌های آنلاین رایگان Aspose](https://products.aspose.app/slides/fa/conversion)
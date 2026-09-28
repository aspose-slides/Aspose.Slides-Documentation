---
title: قالب‌های فایل پشتیبانی‌شده
type: docs
weight: 96
url: /fa/net/supported-file-formats/
keywords:
- قالب‌های فایل پشتیبانی‌شده
- بارگذاری پرزentation
- وارد کردن PDF
- وارد کردن HTML
- ذخیره پرزentation
- رندر اسلایدها
- پاورپوینت
- OpenDocument
- PPT
- PPTX
- ODP
- PDF
- HTML
- XPS
- SVG
- XAML
- .NET
- C#
- Aspose.Slides
description: "مشاهده کنید که کدام قالب‌های فایل Aspose.Slides برای .NET می‌توانند بارگذاری، وارد کردن، ذخیره و رندر شوند و کدام API هر یک را می‌خواند یا می‌نویسد."
---
## **مروری کلی**

Aspose.Slides for .NET پرزentationهای PowerPoint و OpenDocument را باز می‌کند و ذخیره می‌سازد. همچنین محتوای PDF و HTML را به اسلایدها وارد می‌کند، پرزentationها را به قالب‌های سند، وب و تصویر ذخیره می‌کند و اسلایدها و اشکال را به‌صورت تصویر رندر می‌نماید. این مقاله هر قالب پشتیبانی‌شده را فهرست کرده و نام APIی که آن را می‌خواند یا می‌نویسد را می‌گوید.

هر دو بسته NuGet، Aspose.Slides.NET و Aspose.Slides.NET6.CrossPlatform، یکسانی از قالب‌ها را پشتیبانی می‌کنند؛ برای انتخاب بین آن‌ها به [نصب](/slides/fa/net/installation/) مراجعه کنید. برای مرور کلی ویژگی‌های ویرایشی، به [مروری بر ویژگی‌ها](/slides/fa/net/features-overview/) نگاه کنید.

## **نسخه‌های پشتیبانی‌شده مایکروسافت پاورپوینت**

- مایکروسافت پاورپوینت 97
- مایکروسافت پاورپوینت 2000
- مایکروسافت پاورپوینت XP
- مایکروسافت پاورپوینت 2003
- مایکروسافت پاورپوینت 2007
- مایکروسافت پاورپوینت 2010
- مایکروسافت پاورپوینت 2013
- مایکروسافت پاورپوینت 2016
- مایکروسافت پاورپوینت 2019
- مایکروسافت پاورپوینت برای Mac
- پاورپوینت برای مایکروسافت 365 (قبلاً Office 365)

{{% alert color="info" title="Note" %}}

ارائه‌های ذخیره‌شده توسط پاورپوینت 95 و نسخه‌های قبلی قابل باز شدن نیستند. [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/net/aspose.slides/presentationfactory/getpresentationinfo/) یک فایل پاورپوینت 95 را شناسایی می‌کند و `LoadFormat.Ppt95` را گزارش می‌دهد، اما سازندهٔ [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/presentation/) خطای [PptUnsupportedFormatException](https://reference.aspose.com/slides/net/aspose.slides/pptunsupportedformatexception/) را برای آن پرتاب می‌کند.

{{% /alert %}}

## **قالب‌های پشتیبانی‌شده**

جدول از چهار عملیات استفاده می‌کند:

- **بارگذاری**: سازندهٔ [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/presentation/) فایل را به‌عنوان یک پرزentation قابل ویرایش باز می‌کند.
- **وارد کردن**: یک متد از [SlideCollection](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/) اسلایدها را از محتوای فایل می‌سازد و به یک پرزentation موجود اضافه می‌کند. سازندهٔ Presentation این فایل‌ها را به‌عنوان پرزentation بارگذاری نمی‌کند.
- **ذخیره**: [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) پرزentation را به یک فایل یا جریان می‌نویسد. هر قالب به‌جز XAML با مقدار یک [SaveFormat](https://reference.aspose.com/slides/net/aspose.slides.export/saveformat/) انتخاب می‌شود.
- **رندر**: یک متد رندر اسلاید یا شکل را به‌صورت تصویر می‌کشد. قالب‌هایی که فقط رندر می‌شوند، مقادیر SaveFormat ندارند.

|**قالب**|**توضیح**|**بارگذاری / وارد کردن**|**ذخیره / رندر**|**API**|
| :- | :- | :- | :- | :- |
|[PPT](https://docs.fileformat.com/presentation/ppt/)|ارائهٔ پاورپوینت 97-2003|بارگذاری|ذخیره|`LoadFormat.Ppt`, `SaveFormat.Ppt`|
|[POT](https://docs.fileformat.com/presentation/pot/)|قالب پاورپوینت 97-2003|بارگذاری|ذخیره|`LoadFormat.Pot`, `SaveFormat.Pot`|
|[PPS](https://docs.fileformat.com/presentation/pps/)|نمایش اسلاید پاورپوینت 97-2003|بارگذاری|ذخیره|`LoadFormat.Pps`, `SaveFormat.Pps`|
|[PPTX](https://docs.fileformat.com/presentation/pptx/)|پرزentation پاورپوینت|بارگذاری|ذخیره|`LoadFormat.Pptx`, `SaveFormat.Pptx`|
|[POTX](https://docs.fileformat.com/presentation/potx/)|قالب پاورپوینت|بارگذاری|ذخیره|`LoadFormat.Potx`, `SaveFormat.Potx`|
|[PPSX](https://docs.fileformat.com/presentation/ppsx/)|نمایش اسلاید پاورپوینت|بارگذاری|ذخیره|`LoadFormat.Ppsx`, `SaveFormat.Ppsx`|
|[PPTM](https://docs.fileformat.com/presentation/pptm/)|پرزentation ماکرو‌دار پاورپوینت|بارگذاری|ذخیره|`LoadFormat.Pptm`, `SaveFormat.Pptm`|
|[POTM](https://docs.fileformat.com/presentation/potm/)|قالب ماکرو‌دار پاورپوینت|بارگذاری|ذخیره|`LoadFormat.Potm`, `SaveFormat.Potm`|
|[PPSM](https://docs.fileformat.com/presentation/ppsm/)|نمایش اسلاید ماکرو‌دار پاورپوینت|بارگذاری|ذخیره|`LoadFormat.Ppsm`, `SaveFormat.Ppsm`|
|[ODP](https://docs.fileformat.com/presentation/odp/)|پرزentation OpenDocument|بارگذاری|ذخیره|`LoadFormat.Odp`, `SaveFormat.Odp`|
|FODP|پرزentation Flat XML OpenDocument|بارگذاری|ذخیره|`LoadFormat.Fodp`, `SaveFormat.Fodp`|
|[OTP](https://docs.fileformat.com/presentation/otp/)|قالب پرزentation OpenDocument|بارگذاری|ذخیره|`LoadFormat.Otp`, `SaveFormat.Otp`|
|[XML](https://docs.fileformat.com/web/xml/)|پرزentation XML پاورپوینت|بارگذاری|ذخیره|`SaveFormat.Xml`; فایل‌های بارگذاری‌شده مقدار `SourceFormat.Xml` را گزارش می‌دهند (هیچ مقدار `LoadFormat` وجود ندارد)|
|[PDF](https://docs.fileformat.com/pdf/)|قالب سند قابل حمل|وارد کردن|ذخیره|`SlideCollection.AddFromPdf`; `SaveFormat.Pdf`|
|[HTML](https://docs.fileformat.com/web/html/)|Hypertext Markup Language|وارد کردن|ذخیره|`SlideCollection.AddFromHtml`, `SlideCollection.InsertFromHtml`; `SaveFormat.Html`, `SaveFormat.Html5`|
|[XPS](https://docs.fileformat.com/page-description-language/xps/)|XML Paper Specification|—|ذخیره|`SaveFormat.Xps`|
|[TIFF](https://docs.fileformat.com/image/tiff/)|Tagged Image File Format|—|ذخیره, رندر|`SaveFormat.Tiff`; `ImageFormat.Tiff` (یک اسلاید)|
|[GIF](https://docs.fileformat.com/image/gif/)|Graphics Interchange Format|—|ذخیره, رندر|`SaveFormat.Gif` (انیمیشن، تمام اسلایدها); `ImageFormat.Gif` (یک اسلاید)|
|[SWF](https://docs.fileformat.com/page-description-language/swf/)|Small Web Format (Flash)|—|ذخیره|`SaveFormat.Swf`|
|[MD](https://docs.fileformat.com/word-processing/md/)|Markdown|—|ذخیره|`SaveFormat.Md`|
|[XAML](https://docs.fileformat.com/web/xaml/)|Extensible Application Markup Language|—|ذخیره|`Presentation.Save(IXamlOptions)`, یک فایل XAML برای هر اسلاید؛ مقدار `SaveFormat` نیست|
|[PNG](https://docs.fileformat.com/image/png/)|Portable Network Graphics|—|رندر|`ImageFormat.Png`|
|[JPEG](https://docs.fileformat.com/image/jpeg/)|JPEG Image|—|رندر|`ImageFormat.Jpeg`|
|[BMP](https://docs.fileformat.com/image/bmp/)|Bitmap Image|—|رندر|`ImageFormat.Bmp`|
|[EMF](https://docs.fileformat.com/image/emf/)|Enhanced Metafile|—|رندر|`Slide.WriteAsEmf`|
|[SVG](https://docs.fileformat.com/page-description-language/svg/)|Scalable Vector Graphics|—|رندر|`Slide.WriteAsSvg`, `Shape.WriteAsSvg`|

## **بارگذاری و وارد کردن**

- **بارگذاری:** مسیر فایل یا یک جریان را به سازندهٔ [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/presentation/) پاس دهید. قالب از محتوا تشخیص داده می‌شود؛ [LoadOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/) تنظیماتی مانند رمز عبور را فراهم می‌کند. برای بررسی یک فایل قبل از باز کردن، [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/net/aspose.slides/presentationfactory/getpresentationinfo/) را فراخوانی کنید که مقدار یک [LoadFormat](https://reference.aspose.com/slides/net/aspose.slides/loadformat/) را گزارش می‌دهد. برای PowerPoint XML مقدار `LoadFormat.Unknown` گزارش می‌شود، اما سازنده چنین فایلی را باز می‌کند و سپس [Presentation.SourceFormat](https://reference.aspose.com/slides/net/aspose.slides/presentation/sourceformat/) مقدار `SourceFormat.Xml` را برمی‌گرداند. برای جزئیات بیشتر به [باز کردن پرزentationها](/slides/fa/net/open-presentation/) و [تشخیص قالب اصلی پرزentation](/slides/fa/net/detect-presentation-source-format/) مراجعه کنید.
- **وارد کردن:** [SlideCollection.AddFromPdf](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/addfrompdf/) یک اسلاید برای هر صفحه PDF به انتهای پرزentation اضافه می‌کند. [SlideCollection.AddFromHtml](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/addfromhtml/) اسلایدهای ساخته‌شده از HTML را اضافه می‌کند و [SlideCollection.InsertFromHtml](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/insertfromhtml/) آن‌ها را در موقعیت دلخواه قرار می‌دهد. سازندهٔ Presentation وارد نمی‌کند: برای یک فایل PDF خطای [PptUnsupportedFormatException](https://reference.aspose.com/slides/net/aspose.slides/pptunsupportedformatexception/) پرتاب می‌شود و HTML به‌صورت خودکار به محتوای اسلاید تبدیل نمی‌شود. برای جزئیات به [وارد کردن پرزentationها از PDF یا HTML](/slides/fa/net/import-presentation/) نگاه کنید.

## **ذخیره و رندر**

- **ذخیره:** [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) پرزentation را با مقدار یک [SaveFormat](https://reference.aspose.com/slides/net/aspose.slides.export/saveformat/) می‌نویسد. overloadهایی که یک شی گزینه‌ها را می‌پذیرند، خروجی را کنترل می‌کنند؛ برای مثال [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/)، [HtmlOptions](https://reference.aspose.com/slides/net/aspose.slides.export/htmloptions/)، [Html5Options](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/)، [TiffOptions](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/)، و [GifOptions](https://reference.aspose.com/slides/net/aspose.slides.export/gifoptions/). overloadهایی که آرایه‌ای از موقعیت اسلایدها (از 1 شروع) می‌پذیرند، فقط آن اسلایدها را می‌نویسند؛ این overloadها PDF، XPS، TIFF، HTML، HTML5، SWF، GIF و Markdown را پشتیبانی می‌کنند، اما قالب‌های پرزentation یا PowerPoint XML را نمی‌پذیرند. XAML overload ویژه‌ای دارد که [IXamlOptions](https://reference.aspose.com/slides/net/aspose.slides.export.xaml/ixamloptions/) را می‌گیرد. برای جزئیات به [ذخیره پرزentationها](/slides/fa/net/save-presentation/)، [تبدیل پرزentationها](/slides/fa/net/convert-presentation/) و [صادرات پرزentationها به XAML](/slides/fa/net/export-to-xaml/) مراجعه کنید.
- **رندر:** [Slide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage/) و [Shape.GetImage](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage/) یک شیء [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) بازمی‌گردانند و [IImage.Save](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/) آن را به‌صورت PNG، JPEG، BMP، GIF یا TIFF می‌نویسد؛ نوع خروجی با یک مقدار [ImageFormat](https://reference.aspose.com/slides/net/aspose.slides/imageformat/) انتخاب می‌شود. [Presentation.GetImages](https://reference.aspose.com/slides/net/aspose.slides/presentation/getimages/) تمام اسلایدها یا اسلایدهای منتخب را به‌صورت همزمان رندر می‌کند. [Slide.WriteAsSvg](https://reference.aspose.com/slides/net/aspose.slides/slide/writeassvg/) و [Shape.WriteAsSvg](https://reference.aspose.com/slides/net/aspose.slides/shape/writeassvg/) SVG می‌نویسند و [Slide.WriteAsEmf](https://reference.aspose.com/slides/net/aspose.slides/slide/writeasemf/) EMF می‌نویسد. برای جزئیات به [تبدیل اسلایدهای پرزentation به تصاویر](/slides/fa/net/convert-slide/) و [رندر یک اسلاید به عنوان تصویر SVG](/slides/fa/net/render-a-slide-as-an-svg-image/) نگاه کنید.

{{% alert color="warning" title="Warning" %}}

ImageFormat همچنین مقادیر `Emf`، `Wmf`، `Icon`، `Exif` و `MemoryBmp` دارد، اما IImage.Save آن‌ها را تولید نمی‌کند: فایلی که نوشته می‌شود حاوی داده‌های PNG است. برای دریافت تصویر EMF از یک اسلاید، از Slide.WriteAsEmf استفاده کنید.

{{% /alert %}}

## **پرسش‌های متداول**

**آیا می‌توانم یک پرزentation PPT را به PPTX یا ODP تبدیل کنم؟**

بله. فایل PPT را با سازندهٔ Presentation باز کنید و با `SaveFormat.Pptx` یا `SaveFormat.Odp` ذخیره کنید. برای جزئیات به [تبدیل PPT به PPTX](/slides/fa/net/convert-ppt-to-pptx/) مراجعه کنید.

**آیا می‌توانم یک فایل PDF یا HTML را به‌عنوان پرزentation باز کنم؟**

نه. یک پرزentation جدید یا موجود بسازید، صفحات PDF یا محتوای HTML را با روش‌های مجموعه اسلایدهای توضیح داده‌شده وارد کنید و سپس آن را در هر قالب پشتیبانی‌شده‌ای ذخیره کنید.

**آیا می‌توانم یک تصویر PNG یا SVG صادرشده را به‌عنوان پرزentation قابل ویرایش بارگذاری کنم؟**

نه. خروجی تصویر فقط ظاهر اسلاید را ثبت می‌کند، نه متن، اشکال یا نمودارهای آن. برای ویرایش‌های بعدی، منبع پرزentation را نگه دارید.

**آیا می‌توانم اسناد PDF/A یا PDF/UA ذخیره کنم؟**

بله. ویژگی [PdfOptions.Compliance](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/compliance/) را به یک مقدار [PdfCompliance](https://reference.aspose.com/slides/net/aspose.slides.export/pdfcompliance/) تنظیم کنید: PDF/A-1a، PDF/A-1b، PDF/A-2a، PDF/A-2b، PDF/A-2u، PDF/A-3a، PDF/A-3b یا PDF/UA.

**آیا می‌توانم پیش از باز کردن بررسی کنم که آیا فایل با رمز عبور محافظت شده است؟**

بله. [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/net/aspose.slides/presentationfactory/getpresentationinfo/) بدون ایجاد شی Presentation فایل را بررسی می‌کند و ویژگی [IsPasswordProtected](https://reference.aspose.com/slides/net/aspose.slides/ipresentationinfo/ispasswordprotected/) آن نشان می‌دهد که آیا نیاز به رمز عبور است یا نه. برای جزئیات به [محافظت با رمز عبور پرزresentationها](/slides/fa/net/password-protected-presentation/) نگاه کنید.

**آیا دو بسته NuGet قالب‌های متفاوتی را پشتیبانی می‌کنند؟**

نه. Aspose.Slides.NET و Aspose.Slides.NET6.CrossPlatform مقادیر LoadFormat و SaveFormat و متدهای وارد کردن و رندر یکسانی دارند. تفاوت آن‌ها در پلتفرم‌های اجرا و نیازهای آن پلتفرم‌هاست؛ برای جزئیات به [نصب](/slides/fa/net/installation/) مراجعه کنید.
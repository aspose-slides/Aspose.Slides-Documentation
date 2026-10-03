---
title: فرمت‌های فایل پشتیبانی‌شده
type: docs
weight: 106
url: /fa/java/supported-file-formats/
keywords:
- فرمت‌های فایل پشتیبانی‌شده
- بارگذاری ارائه
- وارد کردن PDF
- وارد کردن HTML
- ذخیره ارائه
- رندر اسلایدها
- PowerPoint
- OpenDocument
- PPT
- PPTX
- ODP
- PDF
- HTML
- XPS
- SVG
- XAML
- Java
- Aspose.Slides
description: "مشاهده کنید که Aspose.Slides for Java می‌تواند کدام فرمت‌های فایل را بارگذاری، وارد کردن، ذخیره و رندر کند و کدام API هرکدام را می‌خواند یا می‌نویسد."
---
## **بررسی کلی**

Aspose.Slides for Java فایل‌های ارائه PowerPoint و OpenDocument را باز و ذخیره می‌کند. همچنین محتوای PDF و HTML را به اسلایدها وارد می‌کند، ارائه‌ها را به فرمت‌های سند، وب و تصویر ذخیره می‌کند، و اسلایدها و اشکال را به صورت تصویر رندر می‌کند. این مقاله هر فرمت پشتیبانی‌شده را فهرست می‌کند و نام API ای که آن را می‌خواند یا می‌نویسد را ارائه می‌دهد.

برای مرور کلی ویژگی‌های ویرایشی، ببینید [نمای کلی ویژگی‌ها](/slides/fa/java/features-overview/).

## **نسخه‌های پشتیبانی‌شده مایکروسافت پاورپوینت**

- Microsoft PowerPoint 97
- Microsoft PowerPoint 2000
- Microsoft PowerPoint XP
- Microsoft PowerPoint 2003
- Microsoft PowerPoint 2007
- Microsoft PowerPoint 2010
- Microsoft PowerPoint 2013
- Microsoft PowerPoint 2016
- Microsoft PowerPoint 2019
- Microsoft PowerPoint for Mac
- PowerPoint for Microsoft 365 (formerly Office 365)

{{% alert color="info" title="Note" %}}

ارائه‌های ذخیره‌شده توسط PowerPoint 95 و نسخه‌های قبلی آن قابل باز شدن نیستند. [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) یک فایل PowerPoint 95 را شناسایی می‌کند و `LoadFormat.Ppt95` را گزارش می‌دهد، اما سازنده [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/#Presentation-java.lang.String-) برای آن [PptUnsupportedFormatException]((https://reference.aspose.com/slides/fa/java/com.aspose.slides/pptunsupportedformatexception/)) پرتاب می‌کند.

{{% /alert %}}

## **فرمت‌های فایل پشتیبانی‌شده**

جدول از چهار عملیات استفاده می‌کند:

- **بارگذاری**: سازندهٔ [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/#Presentation-java.lang.String-) فایل را به عنوان یک ارائه قابل ویرایش باز می‌کند.
- **وارد کردن**: یک متد از [SlideCollection](https://reference.aspose.com/slides/fa/java/com.aspose.slides/slidecollection/) اسلایدها را از محتوای فایل ایجاد کرده و به ارائهٔ موجود اضافه می‌کند. سازندهٔ Presentation این فایل‌ها را به اسلاید تبدیل نمی‌کند.
- **ذخیره**: [Presentation.save](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/#save-java.lang.String-int-) ارائه را در فایلی یا جریان می‌نویسد. هر فرمت به‌جز XAML با مقدار [SaveFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/saveformat/) انتخاب می‌شود.
- **رندر**: یک متد رندر یک اسلاید یا یک شکل را به صورت تصویر می‌کشد. فرمت‌هایی که فقط رندر می‌شوند، مقدار SaveFormat ندارند.

|**فرمت**|**توضیح**|**بارگذاری / ورود**|**ذخیره / رندر**|**API**|
| :- | :- | :- | :- | :- |
|[PPT](https://docs.fileformat.com/presentation/ppt/)|ارائهٔ PowerPoint 97-2003|Load|Save|`LoadFormat.Ppt`, `SaveFormat.Ppt`|
|[POT](https://docs.fileformat.com/presentation/pot/)|قالب PowerPoint 97-2003|Load|Save|`LoadFormat.Pot`, `SaveFormat.Pot`|
|[PPS](https://docs.fileformat.com/presentation/pps/)|نمایش اسلاید PowerPoint 97-2003|Load|Save|`LoadFormat.Pps`, `SaveFormat.Pps`|
|[PPTX](https://docs.fileformat.com/presentation/pptx/)|ارائهٔ PowerPoint|Load|Save|`LoadFormat.Pptx`, `SaveFormat.Pptx`|
|[POTX](https://docs.fileformat.com/presentation/potx/)|قالب PowerPoint|Load|Save|`LoadFormat.Potx`, `SaveFormat.Potx`|
|[PPSX](https://docs.fileformat.com/presentation/ppsx/)|نمایش اسلاید PowerPoint|Load|Save|`LoadFormat.Ppsx`, `SaveFormat.Ppsx`|
|[PPTM](https://docs.fileformat.com/presentation/pptm/)|ارائهٔ PowerPoint با ماکرو|Load|Save|`LoadFormat.Pptm`, `SaveFormat.Pptm`|
|[POTM](https://docs.fileformat.com/presentation/potm/)|قالب PowerPoint با ماکرو|Load|Save|`LoadFormat.Potm`, `SaveFormat.Potm`|
|[PPSM](https://docs.fileformat.com/presentation/ppsm/)|نمایش اسلاید PowerPoint با ماکرو|Load|Save|`LoadFormat.Ppsm`, `SaveFormat.Ppsm`|
|[ODP](https://docs.fileformat.com/presentation/odp/)|ارائهٔ OpenDocument|Load|Save|`LoadFormat.Odp`, `SaveFormat.Odp`|
|FODP|ارائهٔ Flat XML OpenDocument|Load|Save|`LoadFormat.Fodp`, `SaveFormat.Fodp`|
|[OTP](https://docs.fileformat.com/presentation/otp/)|قالب ارائهٔ OpenDocument|Load|Save|`LoadFormat.Otp`, `SaveFormat.Otp`|
|[XML](https://docs.fileformat.com/web/xml/)|ارائهٔ XML PowerPoint|Load|Save|`SaveFormat.Xml`; فایل‌های بارگذاری‌شده مقدار `SourceFormat.Xml` را گزارش می‌دهند (مقدار `LoadFormat` وجود ندارد)|
|[PDF](https://docs.fileformat.com/pdf/)|قالب پروندهٔ PDF|Import|Save|`SlideCollection.addFromPdf`; `SaveFormat.Pdf`|
|[HTML](https://docs.fileformat.com/web/html/)|زبان نشانه‌گذاری ابرمتن|Import|Save|`SlideCollection.addFromHtml`, `SlideCollection.insertFromHtml`; `SaveFormat.Html`, `SaveFormat.Html5`|
|[XPS](https://docs.fileformat.com/page-description-language/xps/)|XML Paper Specification|—|Save|`SaveFormat.Xps`|
|[TIFF](https://docs.fileformat.com/image/tiff/)|فرمت تصویر برچسب‌دار|—|Save, Render|`SaveFormat.Tiff` (یک صفحه برای هر اسلاید); `ImageFormat.Tiff` (یک اسلاید)|
|[GIF](https://docs.fileformat.com/image/gif/)|قالب گرافیک تعاملی|—|Save, Render|`SaveFormat.Gif` (پویانمایی، همهٔ اسلایدها); `ImageFormat.Gif` (یک اسلاید)|
|[SWF](https://docs.fileformat.com/page-description-language/swf/)|فرمت وب کوچک (Flash)|—|Save|`SaveFormat.Swf`|
|[MD](https://docs.fileformat.com/word-processing/md/)|مارک‌داون|—|Save|`SaveFormat.Md`|
|[XAML](https://docs.fileformat.com/web/xaml/)|زبان نشانه‌گذاری برنامه‌های گسترده|—|Save|`Presentation.save(IXamlOptions)`, یک فایل XAML برای هر اسلاید؛ مقدار `SaveFormat` ندارد|
|[PNG](https://docs.fileformat.com/image/png/)|پرتابل‌نت‌ورک گرافیک|—|Render|`ImageFormat.Png`|
|[JPEG](https://docs.fileformat.com/image/jpeg/)|تصویر JPEG|—|Render|`ImageFormat.Jpeg`|
|[BMP](https://docs.fileformat.com/image/bmp/)|تصویر Bitmap|—|Render|`ImageFormat.Bmp`|
|[EMF](https://docs.fileformat.com/image/emf/)|متافایل ارتقا یافته|—|Render|`Slide.writeAsEmf`|
|[SVG](https://docs.fileformat.com/page-description-language/svg/)|گرافیک‌های بسط‌پذیر مقیاس‌پذیر|—|Render|`Slide.writeAsSvg`, `Shape.writeAsSvg`|

## **بارگذاری و وارد کردن**

- **بارگذاری:** یک مسیر فایل یا جریان را به سازندهٔ [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/#Presentation-java.lang.String-) پاس دهید. فرمت از محتوا شناسایی می‌شود؛ [LoadOptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/loadoptions/) تنظیماتی مانند رمز عبور را فراهم می‌کند. برای بررسی فایل قبل از باز کردن، متد [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) را فراخوانی کنید که مقدار یک [LoadFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/loadformat/) را گزارش می‌دهد. برای PowerPoint XML مقدار `LoadFormat.Unknown` گزارش می‌شود، اما سازنده آن فایل را باز می‌کند و سپس [Presentation.getSourceFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/#getSourceFormat--) مقدار `SourceFormat.Xml` را برمی‌گرداند. ببینید [Open Presentations](/slides/fa/java/open-presentation/) و [Determine the Original Presentation Format](/slides/fa/java/detect-presentation-source-format/).
- **وارد کردن:** [SlideCollection.addFromPdf](https://reference.aspose.com/slides/fa/java/com.aspose.slides/slidecollection/#addFromPdf-java.lang.String-) یک اسلاید برای هر صفحهٔ PDF به انتهای ارائه اضافه می‌کند. [SlideCollection.addFromHtml](https://reference.aspose.com/slides/fa/java/com.aspose.slides/slidecollection/#addFromHtml-java.lang.String-) اسلایدهای ایجادشده از HTML را اضافه می‌کند و [SlideCollection.insertFromHtml](https://reference.aspose.com/slides/fa/java/com.aspose.slides/slidecollection/#insertFromHtml-int-java.lang.String-) آنها را در موقعیتی معین وارد می‌سازد. سازندهٔ Presentation وارد نمی‌کند: برای فایل PDF [PptUnsupportedFormatException]((https://reference.aspose.com/slides/fa/java/com.aspose.slides/pptunsupportedformatexception/)) پرتاب می‌شود و برای HTML تبدیل به محتوی اسلاید نمی‌شود. ببینید [Import Presentations from PDF or HTML](/slides/fa/java/import-presentation/).

## **ذخیره و رندر**

- **ذخیره:** [Presentation.save](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/#save-java.lang.String-int-) ارائه را با مقدار یک [SaveFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/saveformat/) می‌نویسد. اورلودهایی که شیء گزینه‌ها را نیز می‌پذیرند خروجی را کنترل می‌کنند، برای مثال [PdfOptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/pdfoptions/)، [HtmlOptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/htmloptions/)، [Html5Options](https://reference.aspose.com/slides/fa/java/com.aspose.slides/html5options/)، [TiffOptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/tiffoptions/)، و [GifOptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/gifoptions/). اورلودهایی که آرایه‌ای از موقعیت‌های اسلاید (از ۱ شروع) را می‌پذیرند فقط همان اسلایدها را می‌نویسند؛ این اورلودها PDF، XPS، TIFF، HTML، HTML5، SWF، GIF و Markdown را می‌پذیرند، اما نه فرمت‌های ارائه یا PowerPoint XML. XAML اورلود ویژه‌ای دارد، [Presentation.save](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/#save-com.aspose.slides.IXamlOptions-) که [IXamlOptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ixamloptions/) را می‌گیرد. ببینید [Save Presentations](/slides/fa/java/save-presentation/)، [Convert Presentations](/slides/fa/java/convert-presentation/)، و [Export Presentations to XAML](/slides/fa/java/export-to-xaml/).
- **رندر:** [Slide.getImage](https://reference.aspose.com/slides/fa/java/com.aspose.slides/slide/#getImage-float-float-) و [Shape.getImage](https://reference.aspose.com/slides/fa/java/com.aspose.slides/shape/#getImage--) یک [IImage](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iimage/) بر می‌گردانند و [IImage.save](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iimage/#save-java.lang.String-int-) آن را به صورت PNG، JPEG، BMP، GIF یا TIFF می‌نویسد که با مقدار یک [ImageFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/imageformat/) انتخاب می‌شود. [Presentation.getImages](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/#getImages-com.aspose.slides.IRenderingOptions-) تمام اسلایدها یا اسلایدهای انتخابی را هم‌زمان رندر می‌کند. [Slide.writeAsSvg](https://reference.aspose.com/slides/fa/java/com.aspose.slides/slide/#writeAsSvg-java.io.OutputStream-) و [Shape.writeAsSvg](https://reference.aspose.com/slides/fa/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-) SVG می‌نویسند و [Slide.writeAsEmf](https://reference.aspose.com/slides/fa/java/com.aspose.slides/slide/#writeAsEmf-java.io.OutputStream-) EMF می‌نویسد. ببینید [Convert Presentation Slides to Images](/slides/fa/java/convert-slide/) و [Render Presentation Slides as SVG Images](/slides/fa/java/render-a-slide-as-an-svg-image/).

{{% alert color="warning" title="Warning" %}}

ImageFormat مقادیر `Emf`، `Wmf`، `Icon`، `Exif` و `MemoryBmp` را هم دارد، اما [IImage.save]((https://reference.aspose.com/slides/fa/java/com.aspose.slides/iimage/#save-java.lang.String-int-)) آنها را تولید نمی‌کند: فایلی که می‌نویسد حاوی داده‌های PNG است. برای دریافت تصویر EMF از یک اسلاید، از `Slide.writeAsEmf` استفاده کنید.

{{% /alert %}}

## **پرسش‌های متداول**

**آیا می‌توانم یک ارائهٔ PPT را به PPTX یا ODP تبدیل کنم؟**

بله. فایل PPT را با سازندهٔ Presentation باز کنید و با `SaveFormat.Pptx` یا `SaveFormat.Odp` ذخیره کنید. ببینید [Convert PPT to PPTX](/slides/fa/java/convert-ppt-to-pptx/).

**آیا می‌توانم یک فایل PDF یا HTML را به عنوان ارائه باز کنم؟**

خیر. سازندهٔ Presentation برای فایل PDF [PptUnsupportedFormatException]((https://reference.aspose.com/slides/fa/java/com.aspose.slides/pptunsupportedformatexception/)) پرتاب می‌کند و HTML را به اسلاید تبدیل نمی‌کند. یک ارائه ایجاد یا باز کنید، صفحات PDF یا محتوای HTML را با روش‌های مجموعهٔ اسلایدهای توضیح داده‌شده وارد کنید و سپس در هر فرمت پشتیبانی‌شده‌ای ذخیره کنید.

**آیا می‌توانم یک تصویر PNG یا SVG صادرشده را به عنوان ارائهٔ قابل ویرایش بارگذاری کنم؟**

خیر. خروجی تصویر فقط ظاهر اسلاید را ثبت می‌کند، نه متن، اشکال یا نمودارها. اگر نیاز به ویرایش بعدی دارید، ارائهٔ منبع را نگه دارید.

**آیا می‌توانم اسناد PDF/A یا PDF/UA ذخیره کنم؟**

بله. یک مقدار [PdfCompliance](https://reference.aspose.com/slides/fa/java/com.aspose.slides/pdfcompliance/) را به [PdfOptions.setCompliance](https://reference.aspose.com/slides/fa/java/com.aspose.slides/pdfoptions/#setCompliance-int-) پاس دهید: PDF/A-1a، PDF/A-1b، PDF/A-2a، PDF/A-2b، PDF/A-2u، PDF/A-3a، PDF/A-3b یا PDF/UA.

**آیا می‌توانم پیش از باز کردن بررسی کنم که فایل دارای رمز عبور است؟**

بله. [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) فایلی را بدون ساختن شیء Presentation بررسی می‌کند و [IPresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipresentationinfo/#isPasswordProtected--) گزارش می‌دهد که آیا رمز عبور لازم است یا نه. ببینید [Password-Protect Presentations](/slides/fa/java/password-protected-presentation/).
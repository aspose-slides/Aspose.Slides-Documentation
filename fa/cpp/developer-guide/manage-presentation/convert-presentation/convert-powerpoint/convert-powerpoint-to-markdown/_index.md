---
title: تبدیل ارائه‌های PowerPoint به Markdown در C++
linktitle: PowerPoint به Markdown
type: docs
weight: 140
url: /fa/cpp/convert-powerpoint-to-markdown/
keywords:
- تبدیل PowerPoint
- تبدیل ارائه
- تبدیل اسلاید
- تبدیل PPT
- تبدیل PPTX
- PowerPoint به MD
- ارائه به MD
- اسلاید به MD
- PPT به MD
- PPTX به MD
- ذخیره PowerPoint به عنوان Markdown
- ذخیره ارائه به عنوان Markdown
- ذخیره اسلاید به عنوان Markdown
- ذخیره PPT به عنوان MD
- ذخیره PPTX به عنوان MD
- صادرات PPT به MD
- صادرات PPTX به MD
- PowerPoint
- ارائه
- Markdown
- C++
- Aspose.Slides
description: "تبدیل اسلایدهای PowerPoint—PPT، PPTX—به Markdown تمیز با Aspose.Slides برای C++، مستندسازی را خودکار کنید و قالب‌بندی را حفظ کنید."
---
## **مقدمه**

Aspose.Slides به شما امکان می‌دهد ارائه‌های PowerPoint را به Markdown تبدیل کنید، که می‌تواند برای کارهای مستندسازی، تولید سایت‌های ایستا، مهاجرت محتوا و انتشار متن تحت کنترل نسخه مفید باشد. API از صادرات مستقیم ارائه‌های PPT و PPTX به فایل‌های MD پشتیبانی می‌کند و گزینه‌های اضافی برای کنترل نحوه نمایش محتوای اسلایدها در سند Markdown حاصل ارائه می‌دهد.

شما می‌توانید ارائه‌ها را به صورت Markdown ساده صادر کنید، از میان انواع مختلف Markdown مانند CommonMark و GitHub Flavored Markdown انتخاب کنید و نحوه مدیریت تصاویر هنگام صادرات را پیکربندی کنید. برای ارائه‌هایی که محتوای تصویری دارند، Aspose.Slides همچنین امکان ذخیره تصاویر در پوشه‌ای جداگانه و ارجاع به آن‌ها از فایل Markdown تولیدشده را فراهم می‌کند.

{{% alert color="warning" %}} 
صادرات PowerPoint به markdown به طور پیش‌فرض **بدون تصاویر** است. اگر می‌خواهید سند PowerPoint حاوی تصاویر را صادر کنید، باید `SaveOptions::MarkdownExportType::Visual)` را تنظیم کنید و همچنین `BasePath` را که تصاویر ارجاع‌شده در سند markdown در آن ذخیره می‌شوند، تعیین کنید.
{{% /alert %}} 

## **تبدیل PowerPoint به Markdown**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) را برای نمایش یک شیء ارائه ایجاد کنید.
2. از متد [Save ](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/save/#presentationsavesystemsharedptrexportxamlixamloptions-method) برای ذخیره‌سازی شیء به عنوان یک فایل markdown استفاده کنید.

این کد C++ نشان می‌دهد چگونه PowerPoint را به markdown تبدیل کنید:

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.md", SaveFormat::Md);
```

## **تبدیل PowerPoint به فرمت Markdown**

Aspose.Slides به شما امکان می‌دهد PowerPoint را به markdown (شامل سینتکس پایه)، CommonMark، GitHub flavored markdown، Trello، XWiki، GitLab و ۱۷ فرمت دیگر markdown تبدیل کنید.

این کد C++ نشان می‌دهد چگونه PowerPoint را به CommonMark تبدیل کنید: 

```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto opt = System::MakeObject<MarkdownSaveOptions>();
opt->set_Flavor(Aspose::Slides::DOM::Export::Markdown::SaveOptions::Flavor::CommonMark);
pres->Save(u"pres.md", Aspose::Slides::Export::SaveFormat::Md, opt);
```

۲۳ فرمت markdown پشتیبانی‌شده در [Flavor enumeration](https://reference.aspose.com/slides/fa/cpp/aspose.slides.dom.export.markdown.saveoptions/flavor/) از کلاس [MarkdownSaveOptions](https://reference.aspose.com/slides/fa/cpp/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/) فهرست شده‌اند.

## **تبدیل ارائه حاوی تصاویر به Markdown**

کلاس [MarkdownSaveOptions](https://reference.aspose.com/slides/fa/cpp/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/) ویژگی‌ها و enumهایی را فراهم می‌کند که به شما اجازه می‌دهد برخی گزینه‌ها یا تنظیمات را برای فایل markdown حاصل استفاده کنید. به عنوان مثال enum [MarkdownExportType](https://reference.aspose.com/slides/fa/cpp/aspose.slides.dom.export.markdown.saveoptions/markdownexporttype/) می‌تواند به مقادیری تنظیم شود که نحوه رندر یا پردازش تصاویر را تعیین می‌کنند: `Sequential`، `TextOnly`، `Visual`.

### **تبدیل تصاویر به ترتیب**

اگر می‌خواهید تصاویر به صورت جداگانه یکی پس از دیگری در markdown نهایی ظاهر شوند، باید گزینه sequential را انتخاب کنید. این کد C++ نشان می‌دهد چگونه یک ارائه حاوی تصاویر را به markdown تبدیل کنید:

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

System::SharedPtr<MarkdownSaveOptions> markdownSaveOptions = System::MakeObject<MarkdownSaveOptions>();

markdownSaveOptions->set_ShowHiddenSlides(true);
markdownSaveOptions->set_ShowSlideNumber(true);
markdownSaveOptions->set_Flavor(Flavor::Github);
markdownSaveOptions->set_ExportType(MarkdownExportType::Sequential);
markdownSaveOptions->set_NewLineType(NewLineType::Windows);

pres->Save(u"doc.md", System::MakeArray<int32_t>({1, 2, 3, 4, 5, 6, 7, 8, 9}), SaveFormat::Md, markdownSaveOptions);
```

### **تبدیل تصاویر به صورت بصری**

اگر می‌خواهید تصاویر به صورت گروهی در markdown نهایی ظاهر شوند، باید گزینه visual را انتخاب کنید. در این حالت، تصاویر در دایرکتوری جاری برنامه ذخیره می‌شوند (و مسیر نسبی برای آن‌ها در سند markdown ساخته می‌شود)، یا می‌توانید مسیر و نام پوشه دلخواه خود را مشخص کنید.

این کد C++ عملکرد را نشان می‌دهد: 

```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
const System::String outPath = u"x:\\documents";
auto opt = System::MakeObject<MarkdownSaveOptions>();
opt->set_ExportType(Aspose::Slides::DOM::Export::Markdown::SaveOptions::MarkdownExportType::Visual);
opt->set_ImagesSaveFolderName(u"md-images");
opt->set_BasePath(outPath);
pres->Save(System::IO::Path::Combine(outPath, u"pres.md"), Aspose::Slides::Export::SaveFormat::Md, opt);
```

## **سوالات متداول**

**آیا پیوندهای ابرمتنی پس از صادرات به Markdown حفظ می‌شوند؟**

بله. متن [hyperlinks](/slides/fa/cpp/manage-hyperlinks/) به عنوان لینک‌های استاندارد Markdown حفظ می‌شود. [transitions](/slides/fa/cpp/slide-transition/) اسلاید و [animations](/slides/fa/cpp/powerpoint-animation/) تبدیل نمی‌شوند.

**آیا می‌توانم با اجرای تبدیل در چندین رشته (thread) سرعت آن را افزایش دهم؟**

می‌توانید پردازش را بر روی فایل‌ها موازی کنید، اما [don’t share](/slides/fa/cpp/multithreading/) همان نمونهٔ [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) را بین رشته‌ها به اشتراک نگذارید. برای هر فایل از نمونه‌ها/فرآیندهای جداگانه استفاده کنید تا از تداخل جلوگیری شود.

**چه اتفاقی برای تصاویر می‌افتد—کجا ذخیره می‌شوند و آیا مسیرها نسبی هستند؟**

[Images](/slides/fa/cpp/image/) به یک پوشهٔ مخصوص صادر می‌شوند و به طور پیش‌فرض فایل Markdown با مسیرهای نسبی به آن‌ها ارجاع می‌دهد. می‌توانید مسیر خروجی پایه و نام پوشهٔ دارایی‌ها را پیکربندی کنید تا ساختار مخزن پیش‌بینی‌پذیر باقی بماند.
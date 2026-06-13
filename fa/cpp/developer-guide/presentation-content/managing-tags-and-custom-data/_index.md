---
title: مدیریت برچسب‌ها و داده‌های سفارشی در ارائه‌ها با استفاده از C++
linktitle: برچسب‌ها و داده‌های سفارشی
type: docs
weight: 300
url: /fa/cpp/managing-tags-and-custom-data/
keywords:
- ویژگی‌های سند
- برچسب
- داده‌های سفارشی
- افزودن برچسب
- مقادیر جفت
- پاورپوینت
- ارائه
- C++
- Aspose.Slides
description: "یاد بگیرید چگونه برچسب‌ها و داده‌های سفارشی را در Aspose.Slides برای C++ اضافه، بخوانید، به‌روزرسانی و حذف کنید، به همراه مثال‌هایی برای ارائه‌های پاورپوینت و OpenDocument."
---
## **نمای کلی**

این مقاله توضیح می‌دهد که Aspose.Slides چگونه با برچسب‌ها و داده‌های سفارشی در ارائه‌های PowerPoint کار می‌کند. به‌طور خلاصه نحوه ذخیره‌سازی داده‌ها در فایل‌های PPTX را بیان می‌کند، اشاره می‌کند که داده‌های مخصوص به ارائه می‌تواند به‌صورت برچسب‌ها و بخش‌های XML سفارشی وجود داشته باشد، و برچسب‌ها را به‌عنوان جفت‌های کلید‑مقدار رشته‌ای توصیف می‌کند. همچنین نشان می‌دهد چگونه مقادیر برچسب‌ها را بخوانید و چگونه برچسب‌ها را به یک ارائه، یک اسلاید منفرد یا یک شکل اضافه کنید. علاوه بر این، مقاله به وظایف معمول مدیریت برچسب مانند پاک‌سازی تمام برچسب‌ها، حذف برچسب بر اساس نام و بازیابی لیست نام‌های برچسب می‌پردازد.

## **ذخیره‌سازی داده‌ها در فایل‌های ارائه**

فایل‌های PPTX—آیتم‌هایی با پسوند .pptx—در قالب PresentationML ذخیره می‌شوند که بخشی از مشخصات Office Open XML است. فرمت Office Open XML ساختار داده‌های موجود در ارائه‌ها را تعریف می‌کند.

یک *اسلاید* یکی از عناصر موجود در ارائه‌ها است و یک *بخش اسلاید* شامل محتوای یک اسلاید واحد می‌شود. یک بخش اسلاید می‌تواند روابط صریحی با بسیاری از بخش‌ها—مانند برچسب‌های تعریف‌شده توسط کاربر—که توسط ISO/IEC 29500 تعریف شده‌اند، داشته باشد.

داده‌های سفارشی (خاص یک ارائه) یا کاربر می‌تواند به‌صورت برچسب‌ها ([ITagCollection](https://reference.aspose.com/slides/fa/cpp/aspose.slides/itagcollection/)) و CustomXmlParts ([ICustomXmlPartCollection](https://reference.aspose.com/slides/fa/cpp/aspose.slides/icustomxmlpartcollection/)) وجود داشته باشد.

{{% alert color="primary" %}} 
برچسب‌ها در اصل مقادیر جفت کلید‑رشته‌ای هستند. 
{{% /alert %}} 

## **دریافت مقادیر برچسب‌ها**

در اسلایدها، یک برچسب معادل ویژگی IDocumentProperties.Keywords است. این کد نمونه نشان می‌دهد چگونه مقدار یک برچسب را با Aspose.Slides برای C++ برای [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) دریافت کنید:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
System::String keywords = pres->get_DocumentProperties()->get_Keywords();
```

## **افزودن برچسب‌ها به ارائه‌ها**

Aspose.Slides به شما امکان می‌دهد برچسب‌ها را به ارائه‌ها اضافه کنید. یک برچسب معمولاً شامل دو مورد است:

- نام یک ویژگی سفارشی - `MyTag`
- مقدار ویژگی سفارشی - `My Tag Value`

اگر نیاز دارید برخی از ارائه‌ها را بر اساس قاعده یا ویژگی خاصی طبقه‌بندی کنید، می‌توانید از افزودن برچسب‌ها به آن ارائه‌ها بهره ببرید. به‌عنوان مثال، اگر می‌خواهید تمام ارائه‌های کشورهای آمریکای شمالی را دسته‌بندی یا گروه‌بندی کنید، می‌توانید یک برچسب North American ایجاد کرده و کشورهای مرتبط (ایالات متحده، مکزیک و کانادا) را به‌عنوان مقادیر اختصاص دهید.

این کد نمونه نشان می‌دهد چگونه یک برچسب به یک [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) اضافه کنید با استفاده از Aspose.Slides برای C++:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

System::SharedPtr<ITagCollection> tags = pres->get_CustomData()->get_Tags();
pres->get_CustomData()->get_Tags()->idx_set(u"MyTag", u"My Tag Value");
```

برچسب‌ها همچنین می‌توانند برای [Slide](https://reference.aspose.com/slides/fa/cpp/aspose.slides/slide/) تنظیم شوند:

``` cpp
auto pres = System::MakeObject<Presentation>();

auto slide = pres->get_Slides()->idx_get(0);
slide->get_CustomData()->get_Tags()->idx_set(u"tag", u"value");
```

یا برای هر [Shape](https://reference.aspose.com/slides/fa/cpp/aspose.slides/shape/) به‌صورت منفرد:

``` cpp
auto pres = System::MakeObject<Presentation>();

auto slide = pres->get_Slides()->idx_get(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 50.0f);
shape->get_TextFrame()->set_Text(u"My text");
shape->get_CustomData()->get_Tags()->idx_set(u"tag", u"value");
```

### **محدودیت‌ها**

برچسب‌هایی که از طریق مجموعه برچسب‌های داده سفارشی با استفاده از `get_CustomData()->get_Tags()` اضافه می‌شوند، فقط در فایل PowerPoint ذخیره می‌شوند. آنها **به** ساختار برچسب‌های PDF هنگام صادر کردن ارائه به PDF منتقل نمی‌شوند. در نتیجه، یک شناسه سفارشی که به‌عنوان برچسب اختصاص داده شده است، نمی‌تواند از PDF دارای برچسب بازیابی شود.

**راه‌حل**: می‌توانید یک شناسه سفارشی را در **متن جایگزین** (Alt Text) شیء ذخیره کنید (مثال: `shape->set_AlternativeText(u"MyId")`). پس از صادر کردن به PDF، Alt Text ممکن است در ساختار برچسب‌های PDF ظاهر شود.

## **سؤالات متداول**

**آیا می‌توانم تمام برچسب‌ها را از یک ارائه، اسلاید یا شکل در یک عملیات حذف کنم؟**

بله. [tag collection](https://reference.aspose.com/slides/fa/cpp/aspose.slides/tagcollection/) از عملیات [clear](https://reference.aspose.com/slides/fa/cpp/aspose.slides/tagcollection/clear/) پشتیبانی می‌کند که تمام جفت‌های کلید‑مقدار را یک‌باره حذف می‌نماید.

**چگونه می‌توان یک برچسب تک را بر اساس نام آن حذف کرد بدون اینکه کل مجموعه را مرور کنم؟**

از عملیات [Remove(name)](https://reference.aspose.com/slides/fa/cpp/aspose.slides/tagcollection/remove/) بر روی [TagCollection](https://reference.aspose.com/slides/fa/cpp/aspose.slides/tagcollection/) استفاده کنید تا برچسب را بر اساس کلید (نام) آن حذف کنید.

**چگونه می‌توان لیست کامل نام‌های برچسب را برای تحلیل یا فیلتر کردن دریافت کرد؟**

از [GetNamesOfTags](https://reference.aspose.com/slides/fa/cpp/aspose.slides/tagcollection/getnamesoftags/) بر روی [tag collection](https://reference.aspose.com/slides/fa/cpp/aspose.slides/tagcollection/) استفاده کنید؛ این متد یک آرایه شامل تمام نام‌های برچسب را برمی‌گرداند.
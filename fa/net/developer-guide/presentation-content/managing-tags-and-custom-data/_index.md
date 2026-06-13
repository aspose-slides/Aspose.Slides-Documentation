---
title: مدیریت برچسب‌ها و داده‌های سفارشی در ارائه‌ها در .NET
linktitle: برچسب‌ها و داده‌های سفارشی
type: docs
weight: 300
url: /fa/net/managing-tags-and-custom-data/
keywords:
- ویژگی‌های سند
- برچسب
- داده‌های سفارشی
- افزودن برچسب
- مقدارهای جفت
- PowerPoint
- ارائه
- .NET
- C#
- Aspose.Slides
description: "با مثال‌هایی برای ارائه‌های PowerPoint و OpenDocument، بیاموزید چگونه برچسب‌ها و داده‌های سفارشی را در Aspose.Slides برای .NET اضافه، بخوانید، به‌روز کنید و حذف نمایید."
---
## **مرور کلی**

این مقاله توضیح می‌دهد که Aspose.Slides چگونه با برچسب‌ها و داده‌های سفارشی در ارائه‌های PowerPoint کار می‌کند. به‌صورت خلاصه نحوه ذخیره‌سازی داده‌ها در فایل‌های PPTX را شرح می‌دهد، اشاره می‌کند که داده‌های خاص یک ارائه می‌توانند به‌عنوان برچسب‌ها و بخش‌های XML سفارشی وجود داشته باشند و برچسب‌ها را به‌عنوان جفت‌های کلید‑مقدار رشته‌ای توصیف می‌کند.

همچنین نشان می‌دهد چگونه مقادیر برچسب‌ها را بخوانید و برچسب‌ها را به یک ارائه، یک اسلاید منفرد یا یک شکل اضافه کنید. علاوه بر این، مقاله به وظایف رایج مدیریت برچسب‌ها مانند پاک‌سازی تمام برچسب‌ها، حذف یک برچسب بر اساس نام و بازیابی فهرست نام‌های برچسب می‌پردازد.

## **ذخیره‌سازی داده‌ها در فایل‌های ارائه**

فایل‌های PPTX—آیتم‌هایی با پسوند .pptx—در قالب PresentationML که بخشی از مشخصات Office Open XML است، ذخیره می‌شوند. فرمت Office Open XML ساختار داده‌های موجود در ارائه‌ها را تعریف می‌کند.

با در نظر گرفتن *اسلاید* به‌عنوان یکی از عناصر ارائه‌ها، یک *بخش اسلاید* محتویات یک اسلاید را شامل می‌شود. یک بخش اسلاید می‌تواند روابط صریحی با بسیاری از بخش‌ها داشته باشد—مانند برچسب‌های تعریف‌شده توسط کاربر—که توسط ISO/IEC 29500 تعریف شده‌اند.

داده‌های سفارشی (مختص یک ارائه) یا کاربر می‌توانند به‌صورت برچسب‌ها ([ITagCollection](https://reference.aspose.com/slides/fa/net/aspose.slides/itagcollection)) و CustomXmlParts ([ICustomXmlPartCollection](https://reference.aspose.com/slides/fa/net/aspose.slides/icustomxmlpartcollection)) وجود داشته باشند.

{{% alert color="primary" %}} 
برچسب‌ها به‌طور اساسی مقادیر جفت کلید‑رشته‌ای هستند. 
{{% /alert %}} 

## **دریافت مقدارهای برچسب‌ها**

در اسلایدها، یک برچسب متناظر با ویژگی IDocumentProperties.Keywords است. این کد نمونه نشان می‌دهد چگونه مقدار یک برچسب را با Aspose.Slides برای .NET برای [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) دریافت کنید:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   string keywords = pres.DocumentProperties.Keywords;
}
```

## **افزودن برچسب‌ها به ارائه‌ها**

Aspose.Slides به شما امکان می‌دهد برچسب‌ها را به ارائه‌ها اضافه کنید. یک برچسب معمولاً از دو مورد تشکیل شده است:

- نام یک ویژگی سفارشی - `MyTag` 
- مقدار ویژگی سفارشی - `My Tag Value`

اگر نیاز به طبقه‌بندی برخی ارائه‌ها بر اساس یک قانون یا ویژگی خاص داشته باشید، می‌توانید از افزودن برچسب‌ها به آن ارائه‌ها بهره ببرید. به‌عنوان مثال، اگر می‌خواهید تمام ارائه‌های کشورهای آمریکای شمالی را گروه‌بندی کنید، می‌توانید یک برچسب «North American» ایجاد کنید و سپس کشورهای مرتبط (ایالات متحده، مکزیک و کانادا) را به‌عنوان مقادیر آن تعیین کنید.

این کد نمونه نشان می‌دهد چگونه یک برچسب به یک [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) اضافه کنید با استفاده از Aspose.Slides برای .NET:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   ITagCollection tags = pres.CustomData.Tags;
   pres.CustomData.Tags["MyTag"] = "My Tag Value";
}
```

برچسب‌ها همچنین می‌توانند برای [Slide](https://reference.aspose.com/slides/fa/net/aspose.slides/slide) تنظیم شوند:

```csharp
using(Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    slide.CustomData.Tags["tag"] = "value";
}
```

یا برای هر [Shape](https://reference.aspose.com/slides/fa/net/aspose.slides/shape) فردی:

```csharp
using(Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 50);
    shape.TextFrame.Text = "My text";
    shape.CustomData.Tags["tag"] = "value";
}
```

### **محدودیت‌ها**

برچسب‌هایی که از طریق مجموعه `CustomData.Tags` اضافه می‌شوند، فقط در فایل PowerPoint ذخیره می‌شوند. آن‌ها **به** ساختار برچسب PDF منتقل نمی‌شوند وقتی ارائه به PDF صادر می‌شود. بنابراین، یک شناسه سفارشی که به‌عنوان برچسب اختصاص داده شده است، نمی‌تواند از PDF برچسب‌دار بازیابی شود.

**راه‌حل**: می‌توانید یک شناسه سفارشی را در **متن جایگزین** (Alt Text) شیء ذخیره کنید (به‌عنوان مثال، `shape.AlternativeText = "MyId"`). پس از صادر شدن به PDF، متن جایگزین ممکن است در ساختار برچسب PDF ظاهر شود.

## **پرسش‌های متداول**

**آیا می‌توان تمام برچسب‌ها را از یک ارائه، اسلاید یا شکل در یک عملیات حذف کرد؟**

بله. [tag collection](https://reference.aspose.com/slides/fa/net/aspose.slides/tagcollection/) از عملیات [clear](https://reference.aspose.com/slides/fa/net/aspose.slides/tagcollection/clear/) پشتیبانی می‌کند که تمام جفت‌های کلید‑مقدار را یک‌بار حذف می‌نماید.

**چگونه می‌توان یک برچسب واحد را بر اساس نام آن حذف کرد بدون این‌که کل مجموعه را مرور کنم؟**

از عملیات [Remove(name)](https://reference.aspose.com/slides/fa/net/aspose.slides/tagcollection/remove/) بر روی [TagCollection](https://reference.aspose.com/slides/fa/net/aspose.slides/tagcollection/) استفاده کنید تا برچسب را بر اساس کلید آن حذف کنید.

**چگونه می‌توان فهرست کامل نام‌های برچسب‌ها را برای تجزیه و تحلیل یا فیلتر کردن بازیابی کرد؟**

از [GetNamesOfTags](https://reference.aspose.com/slides/fa/net/aspose.slides/tagcollection/getnamesoftags/) بر روی [tag collection](https://reference.aspose.com/slides/fa/net/aspose.slides/tagcollection/) استفاده کنید؛ این متد آرایه‌ای از تمام نام‌های برچسب را برمی‌گرداند.
---
title: ویرایش اسناد PDF در .NET
linktitle: ویرایش PDF
type: docs
weight: 65
url: /fa/net/edit-pdf/
keywords:
- ویرایش PDF
- جایگزینی متن PDF
- PDF به PPTX
- PPTX به PDF
- .NET
- C#
- Aspose.Slides
description: "اسناد PDF را در C# با وارد کردن آن‌ها به Aspose.Slides، جایگزینی متن و ذخیره ارائه اصلاح شده به‌صورت PDF ویرایش کنید."
---
## **نمای کلی**

Aspose.Slides for .NET به شما امکان می‌دهد محتوای PDF را با وارد کردن صفحات آن به صورت اسلاید، اصلاح ارائه و صادر کردن دوباره به PDF ویرایش کنید. این مقاله یک جایگزینی متن ساده را نشان می‌دهد. ارائه در حافظه می‌ماند، بنابراین ذخیره یک فایل PPTX میانی اختیاری است.

## **جایگزینی متن در PDF**

از [AddFromPdf](https://reference.aspose.com/slides/fa/net/aspose.slides/slidecollection/addfrompdf/) برای وارد کردن صفحات، [ReplaceText](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/replacetext/) برای به‌روزرسانی متن و [Save](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/save/) برای استخراج نتیجه استفاده کنید.

مثال زیر انتظار دارد که `input.pdf` پس از وارد کردن حاوی کلمه «Draft» به عنوان متن قابل ویرایش باشد. این کلمه را با «Final» جایگزین می‌کند و `edited.pdf` را می‌نویسد. پاک‌سازی اسلاید اولیه قبل از وارد کردن، از ایجاد یک صفحه خالی اضافی در خروجی جلوگیری می‌کند. جستجو کلمات کامل را با همان حروف بزرگ و کوچک مطابقت می‌دهد؛ `null` به این معنی است که نیازی به فراخوانی نتیجه نیست.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.Slides.RemoveAt(0);

presentation.Slides.AddFromPdf("input.pdf");

var searchOptions = new TextSearchOptions
{
    WholeWordsOnly = true,
    CaseSensitive = true
};
presentation.ReplaceText("Draft", "Final", searchOptions, null);

presentation.Save("edited.pdf", SaveFormat.Pdf);
```

برای گزینه‌های بیشتر، به [Search and Replace Text](/slides/fa/net/search-and-replace-text/) و [Convert PowerPoint to PDF](/slides/fa/net/convert-powerpoint-to-pdf/) مراجعه کنید.

{{% alert color="info" title="Note" %}}
جایگزینی متن بر روی متن وارد شده اعمال می‌شود، نه متنی که در داخل تصاویر اسکن شده باشد. تبدیل می‌تواند برچیدمان و قالب‌بندی را تحت تأثیر قرار دهد، بنابراین خروجی را مرور کنید، به‌ویژه وقتی متن جایگزین طولانی‌تر از متن اصلی باشد.
{{% /alert %}}

## **سؤالات متداول**

**آیا لازم است قبل از استخراج PDF فایل PPTX را ذخیره کنم؟**

خیر. می‌توانید همان ارائه را در حافظه ویرایش و استخراج کنید. فقط در صورتی که بخواهید ادامه دهید آن را در PowerPoint ویرایش کنید، یک نسخه PPTX ذخیره کنید؛ به [Save Presentations](/slides/fa/net/save-presentation/) مراجعه کنید.

**چرا ممکن است برخی از متن‌ها تغییر نکند؟**

این مثال کلمه کامل «Draft» را با حروف دقیق مطابقت می‌دهد. متنی که به‌عنوان تصویر وارد شده یا در فریم‌های متنی جداگانه تقسیم شده است، لزوماً با جستجو سازگار نخواهد بود. محتوای وارد شده را بررسی کنید و جستجو را برای سند خود تنظیم کنید.
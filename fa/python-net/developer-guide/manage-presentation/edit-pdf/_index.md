---
title: ویرایش اسناد PDF در پایتون
linktitle: ویرایش PDF
type: docs
weight: 65
url: /fa/python-net/edit-pdf/
keywords:
- ویرایش PDF
- جایگزینی متن PDF
- PDF به PPTX
- PPTX به PDF
- پایتون
- Aspose.Slides
description: "اسناد PDF را در پایتون با وارد کردن آنها به Aspose.Slides، جایگزینی متن و ذخیره ارائه اصلاح‌شده به‌صورت PDF ویرایش کنید."
---
## **نمای کلی**

Aspose.Slides for Python via .NET به شما اجازه می‌دهد محتوای PDF را با وارد کردن صفحات به‌صورت اسلاید، ویرایش ارائه و سپس صادرات دوباره به PDF ویرایش کنید. این مقاله یک جایگزینی ساده متن را نشان می‌دهد. ارائه در حافظه باقی می‌ماند، بنابراین ذخیره یک فایل PPTX میانی اختیاری است.

## **جایگزینی متن در PDF**

از [add_from_pdf](https://reference.aspose.com/slides/fa/python-net/aspose.slides/slidecollection/add_from_pdf/) برای وارد کردن صفحات، [replace_text](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/replace_text/) برای به‌روزرسانی متن و [save](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/save/) برای صادرات نتیجه استفاده کنید.

مثال زیر انتظار دارد `input.pdf` شامل کلمه "Draft" به‌عنوان متن قابل ویرایش پس از وارد کردن باشد. این کلمه را با "Final" جایگزین می‌کند و `edited.pdf` را می‌نویسد. پاک‌سازی اسلاید اولیه قبل از وارد کردن از ایجاد یک صفحه خالی اضافی در خروجی جلوگیری می‌کند. جستجو فقط کلمات کامل با همان حروف کوچک و بزرگ را می‌گیرد؛ `None` به این معنی است که نیازی به فراخوانی نتیجه نیست.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slides.remove_at(0)

    presentation.slides.add_from_pdf("input.pdf")

    search_options = slides.TextSearchOptions()
    search_options.whole_words_only = True
    search_options.case_sensitive = True
    presentation.replace_text("Draft", "Final", search_options, None)

    presentation.save("edited.pdf", slides.export.SaveFormat.PDF)
```

برای گزینه‌های بیشتر، به [Search and Replace Text](/slides/fa/python-net/search-and-replace-text/) و [Convert PowerPoint to PDF](/slides/fa/python-net/convert-powerpoint-to-pdf/) مراجعه کنید.

{{% alert color="info" title="Note" %}}
جایگزینی متن بر روی متنی که وارد شده است اعمال می‌شود و نه متن داخل تصاویر اسکن‌شده. تبدیل ممکن است بر چیدمان و قالب‌بندی تأثیر بگذارد، بنابراین خروجی را بررسی کنید، به‌ویژه زمانی که متن جایگزین طولانی‌تر از متن اصلی باشد.
{{% /alert %}}

## **سوالات متداول**

**آیا قبل از صادرات به PDF نیاز به ذخیره فایل PPTX دارم؟**

نه. می‌توانید همان ارائه را در حافظه ویرایش و صادرات کنید. فقط در صورتی که بخواهید ادامه ویرایش را در PowerPoint انجام دهید، یک نسخه PPTX ذخیره کنید؛ برای جزئیات به [Save Presentations](/slides/fa/python-net/save-presentation/) مراجعه کنید.

**چرا ممکن است برخی از متن‌ها تغییر نکنند؟**

مثال فوق کلمه کامل "Draft" را با حروف دقیق مطابقت می‌دهد. متنی که به‌عنوان تصویر وارد شده یا در فریم‌های متنی جداگانه تقسیم شده باشد لزوماً با جستجو مطابقت نخواهد داشت. محتوای وارد شده را بررسی کنید و جستجو را برای سند خود تنظیم کنید.